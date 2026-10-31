extern alias GSD2;

using HarmonyLib;
using System;

namespace PKCore.Patches;

/// <summary>
/// Tracks the active map identifier whenever MACHICON initializes or changes maps.
/// Shared across map-specific patches (Sajah Shop, Tenzan Chimera, Muse Ruins, Room Items, etc.).
/// </summary>
[HarmonyPatch(typeof(MACHICON), "OnMapInit")]
public static class MACHICON_OnMapInitPatch
{
    public static string CurrentMapId = "";

    public static MACHICON CurrentMachicon;

    [HarmonyPostfix]
    public static void Postfix(MACHICON __instance)
    {
        if (__instance == null) return;

        CurrentMachicon = __instance;
        if (__instance.mdat != null)
        {
            MachiLoader_Load_Patch.LastLoadedMachiDat = __instance.mdat;
        }
        if (__instance.econ != null)
        {
            MachiLoader_Load_Patch.LastLoadedEventcon = __instance.econ;
        }
        string machiName = __instance.GetMapName();
        CurrentMapId = ParseMapIdFromMachiName(machiName);

        Plugin.Log.LogInfo($"[Map Tracking] MACHICON MapID resolved to: {CurrentMapId ?? "null"} (Raw: {machiName})");

        try
        {
            string rawName = machiName ?? string.Empty;
            string assetName = __instance.mdat?.name ?? string.Empty;
            MachiLoader_Load_Patch.ApplyDormantCastleRestorations(__instance.mdat, rawName, assetName);

            if (__instance.econ?.mdat != null && __instance.econ.mdat != __instance.mdat)
            {
                MachiLoader_Load_Patch.ApplyDormantCastleRestorations(__instance.econ.mdat, rawName, __instance.econ.mdat.name);
            }
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[MapTrackingPatch] Error during OnMapInit dormant restorations: {ex}");
        }
    }

    public static int PlayerX => CurrentMachicon != null ? CurrentMachicon.px : 0;
    public static int PlayerY => CurrentMachicon != null ? CurrentMachicon.py : 0;

    public static void SetPlayerPos(int x, int y)
    {
        if (CurrentMachicon != null)
        {
            CurrentMachicon.px = x;
            CurrentMachicon.py = y;
            CurrentMachicon.mx = x * 16;
            CurrentMachicon.my = y * 16;
        }
    }

    public static int CurrentSubmapIndex
    {
        get
        {
            if (CurrentMachicon != null)
            {
                try
                {
                    string machiName = CurrentMachicon.GetMapName();
                    if (!string.IsNullOrEmpty(machiName))
                    {
                        var parts = machiName.Split(' ');
                        foreach (var part in parts)
                        {
                            if (part.StartsWith("mno:") && int.TryParse(part.Substring(4), out int mno))
                                return mno;
                        }
                    }
                }
                catch { }
            }
            return 0;
        }
    }

    public static string ParseMapIdFromMachiName(string machiName)
    {
        // Example: "vk07 mno:1 evmno:3" -> Output: "vk07_01"
        if (string.IsNullOrEmpty(machiName)) return null;

        var parts = machiName.Split(' ');
        if (parts.Length >= 2)
        {
            string basePrefix = parts[0];

            for (int i = 1; i < parts.Length; i++)
            {
                if (parts[i].StartsWith("mno:"))
                {
                    if (int.TryParse(parts[i].Substring(4), out int mno))
                    {
                        return $"{basePrefix}_{mno:D2}";
                    }
                }
            }
            return basePrefix;
        }
        return machiName;
    }
}

/// <summary>
/// Intercepts MACHICON.EventInit to capture the deserialized MACHIDAT (mdat) object.
/// Optionally activates dormant castle entities before EventInit constructs the scene.
/// </summary>
[HarmonyPatch(typeof(MACHICON), "EventInit")]
public static class MachiLoader_Load_Patch
{
    public static MACHIDAT LastLoadedMachiDat;
    public static EVENTCON LastLoadedEventcon;

    [HarmonyPrefix]
    public static void Prefix(MACHICON __instance)
    {
        if (__instance == null) return;
        try
        {
            string rawName = __instance.GetMapName() ?? string.Empty;
            string assetName = __instance.mdat?.name ?? string.Empty;

            ApplyDormantCastleRestorations(__instance.mdat, rawName, assetName);
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[MapTrackingPatch] Error during EventInit prefix: {ex}");
        }
    }

    /// <summary>
    /// Safely restores verified dormant castle features in memory without altering JSON files on disk.
    /// Preserves strict byte lengths by using NOP padding [0, 0, 0].
    /// </summary>
    public static void ApplyDormantCastleRestorations(MACHIDAT mdat, string rawName, string assetName)
    {
        if (Plugin.Config?.RestoreDormantCastleFeatures?.Value != true)
            return;

        string currentMapId = MACHICON_OnMapInitPatch.CurrentMapId ?? string.Empty;
        bool isVk19 = (!string.IsNullOrEmpty(rawName) && rawName.StartsWith("vk19", StringComparison.OrdinalIgnoreCase))
            || (!string.IsNullOrEmpty(assetName) && assetName.StartsWith("vk19", StringComparison.OrdinalIgnoreCase))
            || (!string.IsNullOrEmpty(currentMapId) && currentMapId.StartsWith("vk19", StringComparison.OrdinalIgnoreCase));

        bool isVk16 = (!string.IsNullOrEmpty(rawName) && rawName.StartsWith("vk16", StringComparison.OrdinalIgnoreCase))
            || (!string.IsNullOrEmpty(assetName) && assetName.StartsWith("vk16", StringComparison.OrdinalIgnoreCase))
            || (!string.IsNullOrEmpty(currentMapId) && currentMapId.StartsWith("vk16", StringComparison.OrdinalIgnoreCase));

        if (!isVk19 && !isVk16)
            return;

        var ed = mdat?.eventdata;
        if (ed?.mapeventdat == null || ed.mapeventdat.Count == 0)
            return;

        // 1. vk19 Submap 0: Karen & Stage Dancers Cut Choreography
        // ev[62..65]: [5, 9, 26, 0, 48, <seq>, 1, 1, 255, 254]
        if (isVk19 && ed.mapeventdat.Count > 0)
        {
            var sub0 = ed.mapeventdat[0];
            if (sub0?.eventdat != null)
            {
                int choreoCount = 0;
                for (int evIdx = 62; evIdx <= 65; evIdx++)
                {
                    if (sub0.eventdat.Count > evIdx && sub0.eventdat[evIdx]?.eventForm != null)
                    {
                        var form = sub0.eventdat[evIdx].eventForm;
                        // Search for the broken [9, 26, 0] token (Opcode 9 = flag check, flag 26, mask 0x00)
                        for (int i = 0; i <= form.Length - 3; i++)
                        {
                            if (form[i] == 9 && form[i + 1] == 26 && form[i + 2] == 0)
                            {
                                form[i] = 0;     // NOP
                                form[i + 1] = 0; // NOP
                                form[i + 2] = 0; // NOP
                                choreoCount++;
                                break;
                            }
                        }
                    }
                }
                if (choreoCount > 0)
                {
                    Plugin.Log.LogInfo($"[DormantCastle] Restored {choreoCount} cut dance choreography routines (ev[62..65]) on vk19 stage.");
                }
            }
        }

        // 2. vk16 Submap 0: Fallen Heroes Memorial Sequence (Castle Cemetery)
        // ev[1, 2, 5, 6, 7, 8, 9, 10, 11, 13, 14]: NOP the [33, 0, 4] Castle Tier check
        // Strictly preserves byte length with [0, 0, 0] NOP padding per engine rules.
        if (isVk16 && ed.mapeventdat.Count > 0)
        {
            var sub0 = ed.mapeventdat[0];
            if (sub0?.eventdat != null)
            {
                int memorialRestoredCount = 0;
                int[] targetEvents = new int[] { 1, 2, 5, 6, 7, 8, 9, 10, 11, 13, 14 };

                foreach (int evIdx in targetEvents)
                {
                    if (sub0.eventdat.Count > evIdx && sub0.eventdat[evIdx]?.eventForm != null)
                    {
                        var form = sub0.eventdat[evIdx].eventForm;
                        for (int i = 0; i <= form.Length - 3; i++)
                        {
                            // Opcode 33: [33, 0, 4] (base_lv == 4)
                            if (form[i] == 33 && form[i + 1] == 0 && form[i + 2] == 4)
                            {
                                form[i] = 0;     // NOP
                                form[i + 1] = 0; // NOP
                                form[i + 2] = 0; // NOP
                                memorialRestoredCount++;
                                break;
                            }
                        }
                    }
                }

                if (memorialRestoredCount > 0)
                {
                    Plugin.Log.LogInfo($"[DormantCastle] Restored {memorialRestoredCount} Fallen Heroes Memorial scripts (vk16 cemetery) by NOPing [33, 0, 4].");
                }
            }
        }
    }

    [HarmonyPostfix]
    public static void Postfix(MACHICON __instance, EVENTCON __result)
    {
        if (__instance != null)
        {
            MACHICON_OnMapInitPatch.CurrentMachicon = __instance;
        }
        if (__result != null)
        {
            LastLoadedEventcon = __result;
            LastLoadedMachiDat = __result.mdat;

            try
            {
                string rawName = __instance != null ? __instance.GetMapName() ?? string.Empty : string.Empty;
                string assetName = __result.mdat?.name ?? string.Empty;
                ApplyDormantCastleRestorations(__result.mdat, rawName, assetName);
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"[MapTrackingPatch] Error during EventInit postfix: {ex}");
            }
        }
        ImGuiOverlayUI.OnMapChanged();
    }
}
