using HarmonyLib;
using PKCore.Patches;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Encodings.Web;
using UnityEngine.SceneManagement;

namespace PKCore.Patches;

[HarmonyPatch]
public class TextDatabasePatch
{
    // Track logged text IDs to prevent duplicate logging
    private static readonly HashSet<string> loggedTextIDs = new HashSet<string>();

    // Store the last queried text ID for portrait injection
    public static string LastTextId { get; private set; }

    // Only updated by GetSystemTextEx (dialogue/message text in S1).
    // Isolated from GetSystemText which handles UI elements — avoids timing
    // issues where a UI lookup overwrites the ID before OpenMessageWindow fires.
    public static string LastMessageTextId { get; private set; }

    // ── Text Database Dump ──────────────────────────────────────────────────────
    // Additive per-session accumulator. Saved to PKCore/Debug/TextDB_GSD*.json on
    // scene unload so it grows across play sessions. Format matches DialogOverrides.json.
    private static Dictionary<string, string> _dumpGSD1 = new(StringComparer.OrdinalIgnoreCase);
    private static Dictionary<string, string> _dumpGSD2 = new(StringComparer.OrdinalIgnoreCase);
    private static int _newEntriesSinceLastSave = 0;
    private const int AutoSaveThreshold = 200; // also save mid-session after N new entries

    public static void Initialize()
    {
        if (!Plugin.Config.DumpTextDatabase.Value) return;

        string debugDir = Path.Combine(BepInEx.Paths.GameRootPath, "PKCore", "Debug");
        Directory.CreateDirectory(debugDir);

        // Load existing dumps so we don't overwrite already-collected data
        LoadExistingDump(Path.Combine(debugDir, "TextDB_GSD1.json"), _dumpGSD1);
        LoadExistingDump(Path.Combine(debugDir, "TextDB_GSD2.json"), _dumpGSD2);

        Plugin.Log.LogInfo($"[TextDump] Loaded existing: {_dumpGSD1.Count} GSD1 entries, {_dumpGSD2.Count} GSD2 entries");

        // Save on scene unload so we don't lose a session's data
        SceneManager.sceneUnloaded += (UnityEngine.Events.UnityAction<Scene>)(_ => SaveDumps());
    }

    private static void LoadExistingDump(string path, Dictionary<string, string> target)
    {
        if (!File.Exists(path)) return;
        try
        {
            var loaded = JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText(path));
            if (loaded == null) return;
            foreach (var kvp in loaded)
                target[kvp.Key] = kvp.Value;
        }
        catch (Exception ex)
        {
            Plugin.Log.LogWarning($"[TextDump] Could not load {Path.GetFileName(path)}: {ex.Message}");
        }
    }

    private static void AccumulateEntry(string id, int index, int gsd, string text)
    {
        if (!Plugin.Config.DumpTextDatabase.Value) return;
        if (string.IsNullOrEmpty(text)) return;

        string key = $"{id}:{index}";
        var dict = gsd == 1 ? _dumpGSD1 : _dumpGSD2;

        if (!dict.ContainsKey(key) || dict[key] != text)
        {
            dict[key] = text;
            _newEntriesSinceLastSave++;

            if (_newEntriesSinceLastSave >= AutoSaveThreshold)
                SaveDumps();
        }
    }

    public static void SaveDumps()
    {
        if (!Plugin.Config.DumpTextDatabase.Value || _newEntriesSinceLastSave == 0) return;
        _newEntriesSinceLastSave = 0;

        string debugDir = Path.Combine(BepInEx.Paths.GameRootPath, "PKCore", "Debug");
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        System.Threading.Tasks.Task.Run(() =>
        {
            try
            {
                if (_dumpGSD1.Count > 0)
                    File.WriteAllText(Path.Combine(debugDir, "TextDB_GSD1.json"),
                        JsonSerializer.Serialize(new SortedDictionary<string, string>(_dumpGSD1), options));
                if (_dumpGSD2.Count > 0)
                    File.WriteAllText(Path.Combine(debugDir, "TextDB_GSD2.json"),
                        JsonSerializer.Serialize(new SortedDictionary<string, string>(_dumpGSD2), options));
                Plugin.Log.LogInfo($"[TextDump] Saved — {_dumpGSD1.Count} GSD1, {_dumpGSD2.Count} GSD2 entries");
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"[TextDump] Save failed: {ex.Message}");
            }
        });
    }
    // ────────────────────────────────────────────────────────────────────────────

    // Patch GetSystemText to intercept ID-based lookups
    // Using Priority.Last to run after other mods (like SuikodenFix) so we can override their fixes if a custom override exists
    [HarmonyPatch(typeof(TextMasterData), nameof(TextMasterData.GetSystemText))]
    [HarmonyPriority(Priority.Last)]
    [HarmonyPrefix]
    public static bool GetSystemText_Prefix(string id, int index, ref string __result)
    {
        if (!Plugin.Config.EnableDialogOverrides.Value)
            return true;

        // Try to get an override from PortraitSystemPatch (which holds the dictionary)
        // Format for ID key: "id:index" (e.g. "sys_01:5")
        string key = $"{id}:{index}";

        // We access the dictionary via a public method on PortraitSystemPatch (we'll need to add this)
        // Or we can move the dictionary to a shared location. For now, let's add a public accessor to PortraitSystemPatch.
        string replacement = PortraitSystemPatch.GetDialogOverride(key);

        if (replacement != null)
        {
            if (Plugin.Config.LogTextIDs.Value)
                Plugin.Log.LogInfo($"[TextDebug] Applying Override: [{key}] -> \"{replacement}\"");

            __result = replacement;
            return false; // Skip original method and other prefixes if possible (Harmony handles this)
        }

        return true; // Continue execution
    }

    // Postfix for Speaker Injection (S1SpeakerOverrides.json / S2SpeakerOverrides.json)
    // Runs AFTER SuikodenFix, so we perform injection on the final text (whether fixed or original)
    // Priority.Last ensures we run after SuikodenFix's potential Postfix (though they likely use Prefix)
    [HarmonyPatch(typeof(TextMasterData), nameof(TextMasterData.GetSystemText))]
    [HarmonyPriority(Priority.Last)]
    [HarmonyPostfix]
    public static void GetSystemText_Postfix(string id, int index, ref string __result)
    {
        // 1. Log ID if enabled
        if (Plugin.Config.LogTextIDs.Value)
        {
            string key = $"{id}:{index}";
            if (!loggedTextIDs.Contains(key))
            {
                loggedTextIDs.Add(key);
                Plugin.Log.LogInfo($"[TextDebug] [{key}] -> \"{__result}\"");
            }
        }

        LastTextId = $"{id}:{index}";

        // Accumulate for persistent text DB dump
        string currentGame = GameDetection.GetCurrentGame();
        int gsdNum = currentGame == "GSD1" ? 1 : currentGame == "GSD2" ? 2 : 0;
        if (gsdNum > 0)
            AccumulateEntry(id, index, gsdNum, __result);

        // 2. Speaker Injection
        if (!Plugin.Config.EnableDialogOverrides.Value)
            return;

        // Check for Speaker Override by ID
        string speakerKey = $"{id}:{index}";
        string speakerData = PortraitSystemPatch.GetSpeakerOverride(speakerKey);

        if (!string.IsNullOrEmpty(speakerData))
        {
            // S1 builds messages char-by-char via AddMessageText — tags are not parsed there
            // and would display as raw text.  AddNameText_S1_Prefix handles name injection for S1.
            if (GameDetection.IsGSD1())
            {
                if (Plugin.Config.LogTextIDs.Value)
                    Plugin.Log.LogInfo($"[TextDebug] S1 speaker '{speakerData}' stored for '{speakerKey}' (handled by AddNameText patch)");
            }
            else
            {
                // S2: inject <speaker:...> tag; OpenMessageWindow_Prefix strips it and sets the name
                string displayName = speakerData.Contains("|")
                    ? speakerData.Split('|')[0].Trim()
                    : speakerData;

                string speakerTag = $"<speaker:{speakerData}>";

                if (!__result.StartsWith(speakerTag))
                {
                    __result = $"{speakerTag}{__result}";

                    if (Plugin.Config.LogTextIDs.Value)
                        Plugin.Log.LogInfo($"[TextDebug] Injected Speaker: {speakerKey} -> {displayName}" +
                            (speakerData.Contains("|") ? $" (variant: {speakerData.Split('|')[1]})" : ""));
                }
            }
        }
    }


    // Patch GetSystemTextEx as well (it seems to be used for game-specific texts)
    [HarmonyPatch(typeof(TextMasterData), nameof(TextMasterData.GetSystemTextEx))]
    [HarmonyPriority(Priority.Last)]
    [HarmonyPrefix]
    public static bool GetSystemTextEx_Prefix(string id, int index, int gsd, ref string __result)
    {
        if (!Plugin.Config.EnableDialogOverrides.Value)
            return true;

        string key = $"{id}:{index}";
        string replacement = PortraitSystemPatch.GetDialogOverride(key);

        if (replacement != null)
        {
            if (Plugin.Config.LogTextIDs.Value)
                Plugin.Log.LogInfo($"[TextDebug] Applying Override (Ex): [{key}] (GSD:{gsd}) -> \"{replacement}\"");

            __result = replacement;
            return false;
        }

        return true;
    }

    [HarmonyPatch(typeof(TextMasterData), nameof(TextMasterData.GetSystemTextEx))]
    [HarmonyPriority(Priority.Last)]
    [HarmonyPostfix]
    public static void GetSystemTextEx_Postfix(string id, int index, int gsd, ref string __result)
    {
        // 1. Log ID if enabled
        if (Plugin.Config.LogTextIDs.Value)
        {
            string key = $"{id}:{index}:GSD{gsd}";
            if (!loggedTextIDs.Contains(key))
            {
                loggedTextIDs.Add(key);
                Plugin.Log.LogInfo($"[TextDebug] [{id}:{index}] (GSD:{gsd}) -> \"{__result}\"");
            }
        }

        LastTextId = $"{id}:{index}";
        LastMessageTextId = $"{id}:{index}"; // dedicated tracker — not polluted by UI text lookups

        // Accumulate for persistent text DB dump
        if (gsd == 1 || gsd == 2)
            AccumulateEntry(id, index, gsd, __result);

        // 2. Speaker Injection
        if (!Plugin.Config.EnableDialogOverrides.Value)
            return;

        string speakerKey = $"{id}:{index}";
        string speakerData = PortraitSystemPatch.GetSpeakerOverride(speakerKey);

        if (!string.IsNullOrEmpty(speakerData))
        {
            if (GameDetection.IsGSD1())
            {
                if (Plugin.Config.LogTextIDs.Value)
                    Plugin.Log.LogInfo($"[TextDebug] S1 speaker '{speakerData}' stored for '{speakerKey}' (handled by AddNameText patch)");
            }
            else
            {
                string displayName = speakerData.Contains("|")
                    ? speakerData.Split('|')[0].Trim()
                    : speakerData;

                string speakerTag = $"<speaker:{speakerData}>";

                if (!__result.StartsWith(speakerTag))
                {
                    __result = $"{speakerTag}{__result}";

                    if (Plugin.Config.LogTextIDs.Value)
                        Plugin.Log.LogInfo($"[TextDebug] Injected Speaker: {speakerKey} -> {displayName}" +
                            (speakerData.Contains("|") ? $" (variant: {speakerData.Split('|')[1]})" : ""));
                }
            }
        }
    }
}
