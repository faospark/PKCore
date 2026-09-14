extern alias GSD2;

using System;
using System.Collections.Generic;
using System.IO;
using HarmonyLib;
using UnityEngine;

namespace PKCore.Patches;

/// <summary>
/// Allows customizable weapon battle range overrides for Suikoden 2 (GSD2) characters.
/// Defaults to making Kasumi, Luc, Mazus, and Viki Medium Range (M).
/// Overrides work across all UI displays (Status, Formation/Tavern party swap, Field command)
/// and native battle calculations (enabling back-row attacks).
/// Fully configurable via PKCore/Config/S2CharacterRanges.json.
/// </summary>
public static class CharacterRangePatch
{
    // Maps character ID -> Range (0 = Short, 1 = Medium, 2 = Long)
    private static readonly Dictionary<int, int> RangeOverrides = new();
    private static readonly Dictionary<string, int> RawNameOverrides = new(StringComparer.OrdinalIgnoreCase);

    // Master character mapping for Suikoden 2 internal character indices and party IDs
    private static readonly Dictionary<string, int[]> KnownCharacterIds = new(StringComparer.OrdinalIgnoreCase)
    {
        { "riou", new[] { 0 } }, { "hero", new[] { 0 } }, { "syu", new[] { 0 } }, { "shu_hero", new[] { 0 } },
        { "flik", new[] { 1 } }, { "frk", new[] { 1 } }, { "fri", new[] { 1 } },
        { "viktor", new[] { 2 } }, { "vic", new[] { 2 } },
        { "viki", new[] { 4, 55 } }, { "wig", new[] { 4, 55 } }, { "wiki", new[] { 4, 55 } },
        { "sheena", new[] { 4 } }, { "see", new[] { 4 } },
        { "clive", new[] { 5 } }, { "cry", new[] { 5 } },
        { "hix", new[] { 6 } }, { "hic", new[] { 6 } },
        { "tengaar", new[] { 7 } }, { "ten", new[] { 7 } },
        { "futch", new[] { 8 } }, { "fut", new[] { 8 } },
        { "humphrey", new[] { 9 } }, { "hnf", new[] { 9 } },
        { "georg", new[] { 10 } }, { "geo", new[] { 10 } },
        { "valeria", new[] { 11 } }, { "val", new[] { 11 } },
        { "pesmerga", new[] { 12 } }, { "pec", new[] { 12 } },
        { "shin", new[] { 14 } }, { "sin", new[] { 14 } },
        { "rikimaru", new[] { 15 } }, { "rik", new[] { 15 } },
        { "tuta", new[] { 16 } }, { "zko", new[] { 16 } },
        { "nanami", new[] { 17, 18 } }, { "nan", new[] { 17, 18 } },
        { "eilie", new[] { 18 } }, { "air", new[] { 18 } },
        { "rina", new[] { 19 } }, { "ryn", new[] { 19 } },
        { "bolgan", new[] { 20 } }, { "bor", new[] { 20 } },
        { "haiyo", new[] { 21 } }, { "hai_yo", new[] { 21 } }, { "tou", new[] { 21 } },
        { "hanna", new[] { 22 } }, { "han", new[] { 22 } },
        { "millie", new[] { 23 } }, { "mil", new[] { 23 } },
        { "karen", new[] { 24 } }, { "kal", new[] { 24 } },
        { "shiro", new[] { 25 } }, { "sir", new[] { 25 } },
        { "zamza", new[] { 26 } }, { "zam", new[] { 26 } },
        { "gengen", new[] { 27 } }, { "gen", new[] { 27 } },
        { "gabocha", new[] { 28 } }, { "gab", new[] { 28 } },
        { "kinnison", new[] { 29 } }, { "kni", new[] { 29 } },
        { "shilo", new[] { 30 } }, { "sro", new[] { 30 } },
        { "miklotov", new[] { 31 } }, { "mcr", new[] { 31 } },
        { "camus", new[] { 32 } }, { "kmu", new[] { 32 } },
        { "freed", new[] { 34 } }, { "freedy", new[] { 34 } }, { "fre", new[] { 34 } },
        { "kahn", new[] { 35 } }, { "kan", new[] { 35 } },
        { "amada", new[] { 36 } }, { "amd", new[] { 36 } },
        { "taiho", new[] { 37 } }, { "tai_ho", new[] { 37 } }, { "tai", new[] { 37 } },
        { "anita", new[] { 38 } }, { "ani", new[] { 38 } },
        { "bob", new[] { 39 } }, { "wol", new[] { 39 } },
        { "ayda", new[] { 40 } }, { "kks", new[] { 40 } },
        { "feather", new[] { 41 } },
        { "abizboah", new[] { 42 } }, { "ada", new[] { 42 } },
        { "sid", new[] { 43 } }, { "sna", new[] { 43 } }, { "sed", new[] { 43 } },
        { "sierra", new[] { 44 } }, { "sie", new[] { 44 } },
        { "oulan", new[] { 45 } }, { "ora", new[] { 45 } },
        { "yoshino", new[] { 46 } }, { "sen", new[] { 46 } },
        { "mukumuku", new[] { 47 } }, { "muk", new[] { 47 } },
        { "mekumeku", new[] { 48 } }, { "klk", new[] { 48 } },
        { "sigfried", new[] { 49 } }, { "gri", new[] { 49 } },
        { "mazus", new[] { 50, 61 } }, { "msm", new[] { 50, 61 } },
        { "chaco", new[] { 51 } }, { "zai", new[] { 51 } },
        { "lcchan", new[] { 52 } }, { "lkk", new[] { 52 } }, { "longchanchan", new[] { 52 } },
        { "luc", new[] { 53, 139 } }, { "ruk", new[] { 53, 139 } }, { "luk", new[] { 53, 139 } }, { "cyk", new[] { 53, 139 } },
        { "nina", new[] { 54 } }, { "nia", new[] { 54 } },
        { "stallion", new[] { 56 } }, { "stk", new[] { 56 } }, { "sta", new[] { 56 } },
        { "gadget", new[] { 57 } }, { "gjm", new[] { 57 } },
        { "hoi", new[] { 58 } }, { "kyu", new[] { 58 } }, { "hjo", new[] { 58 } },
        { "gantetsu", new[] { 60 } }, { "jij", new[] { 60 } }, { "gsu", new[] { 60 } },
        { "tirmcdohl", new[] { 62 } }, { "mcdohl", new[] { 62 } }, { "mdo", new[] { 62 } }, { "tir", new[] { 62 } },
        { "vincent", new[] { 63 } }, { "van", new[] { 63 } },
        { "simone", new[] { 64 } }, { "smb", new[] { 64 } },
        { "rulodia", new[] { 67 } }, { "lfi", new[] { 67 } },
        { "meg", new[] { 68 } }, { "mfi", new[] { 68 } },
        { "chuchura", new[] { 70 } }, { "ksd", new[] { 70 } },
        { "badeaux", new[] { 71 } }, { "uni", new[] { 71 } },
        { "kasumi", new[] { 72, 73 } }, { "ksm", new[] { 72, 73 } },
        { "mikumiku", new[] { 87 } }, { "rkl", new[] { 87 } },
        { "makumaku", new[] { 88 } }, { "mto", new[] { 88 } },
        { "mokumoku", new[] { 89 } }, { "mts", new[] { 89 } },
        { "jowy", new[] { 93 } }, { "joi", new[] { 93 } }
    };

    public static bool IsLoaded { get; private set; }
    private static float _lastMemorySyncTime = 0f;

    public static void Initialize(Harmony harmony)
    {
        try
        {
            LoadConfiguration();

            harmony.PatchAll(typeof(G2ArmsRangePatch));
            harmony.PatchAll(typeof(UIStatusWindowUpdateStatusDataPatch));

            ApplyArmsDataOverrides();

            Plugin.Log.LogInfo("[CharacterRangePatch] Registered character battle range hooks successfully.");
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[CharacterRangePatch] Failed to register character range hooks: {ex}");
        }
    }

    public static void Update()
    {
        if (!GameDetection.IsGSD2())
            return;

        // Periodically sync weapon data in memory every 3 seconds to keep UI and menus updated
        if (Time.time - _lastMemorySyncTime > 3.0f)
        {
            _lastMemorySyncTime = Time.time;
            ApplyArmsDataOverrides();
        }
    }

    private static void LoadConfiguration()
    {
        RangeOverrides.Clear();
        RawNameOverrides.Clear();

        var pkCoreDir = Path.Combine(BepInEx.Paths.GameRootPath, "PKCore");
        var configDir = Path.Combine(pkCoreDir, "Config");
        var configPath = Path.Combine(configDir, "S2CharacterRanges.json");

        try
        {
            if (!Directory.Exists(configDir))
            {
                Directory.CreateDirectory(configDir);
            }

            // Create default config file if it doesn't exist
            if (!File.Exists(configPath))
            {
                string defaultConfig = @"{
  ""_description"": ""Configure battle range for Suikoden 2 characters. Options: 'S' (Short), 'M' (Medium), 'L' (Long)."",
  ""Kasumi"": ""M"",
  ""Luc"": ""M"",
  ""Mazus"": ""M"",
  ""Viki"": ""M""
}";
                File.WriteAllText(configPath, defaultConfig);
                Plugin.Log.LogInfo($"[CharacterRangePatch] Created default configuration file at: {configPath}");
            }

            string json = File.ReadAllText(configPath);
            ParseConfigJson(json);
            IsLoaded = true;

            Plugin.Log.LogInfo($"[CharacterRangePatch] Loaded {RangeOverrides.Count} character range overrides.");
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[CharacterRangePatch] Error loading configuration: {ex}");
            ApplyFallbackDefaults();
        }
    }

    private static void ApplyFallbackDefaults()
    {
        SetRangeForId(72, 1);  // Kasumi -> Medium
        SetRangeForId(73, 1);  // Kasumi -> Medium
        SetRangeForId(53, 1);  // Luc -> Medium
        SetRangeForId(139, 1); // Luc -> Medium
        SetRangeForId(50, 1);  // Mazus -> Medium
        SetRangeForId(61, 1);  // Mazus -> Medium
        SetRangeForId(4, 1);   // Viki -> Medium
        SetRangeForId(55, 1);  // Viki -> Medium
    }

    private static void ParseConfigJson(string json)
    {
        try
        {
            var lines = json.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var rawLine in lines)
            {
                var line = rawLine.Trim();
                if (string.IsNullOrEmpty(line) || line.StartsWith("{") || line.StartsWith("}") || line.StartsWith("\"_"))
                    continue;

                if (line.EndsWith(","))
                    line = line.Substring(0, line.Length - 1).Trim();

                var parts = line.Split(':');
                if (parts.Length != 2)
                    continue;

                string key = parts[0].Trim().Trim('"');
                string val = parts[1].Trim().Trim('"').ToUpperInvariant();

                int rangeValue = val switch
                {
                    "M" or "MEDIUM" or "1" => 1,
                    "L" or "LONG" or "2" => 2,
                    "S" or "SHORT" or "0" => 0,
                    _ => -1
                };

                if (rangeValue < 0)
                    continue;

                RawNameOverrides[key] = rangeValue;

                if (int.TryParse(key, out int numericId))
                {
                    SetRangeForId(numericId, rangeValue);
                }
                else
                {
                    int[] charaIds = ResolveCharacterIdsByName(key);
                    if (charaIds != null && charaIds.Length > 0)
                    {
                        foreach (int id in charaIds)
                        {
                            SetRangeForId(id, rangeValue);
                        }
                        Plugin.Log.LogInfo($"[CharacterRangePatch] Overriding {key} (IDs: {string.Join(", ", charaIds)}) -> Range {(rangeValue == 1 ? "Medium (M)" : rangeValue == 2 ? "Long (L)" : "Short (S)")}");
                    }
                }
            }

            // Ensure our target four default if missing from custom json
            if (!RangeOverrides.ContainsKey(72)) SetRangeForId(72, 1);
            if (!RangeOverrides.ContainsKey(73)) SetRangeForId(73, 1);
            if (!RangeOverrides.ContainsKey(53)) SetRangeForId(53, 1);
            if (!RangeOverrides.ContainsKey(139)) SetRangeForId(139, 1);
            if (!RangeOverrides.ContainsKey(50)) SetRangeForId(50, 1);
            if (!RangeOverrides.ContainsKey(61)) SetRangeForId(61, 1);
            if (!RangeOverrides.ContainsKey(4)) SetRangeForId(4, 1);
            if (!RangeOverrides.ContainsKey(55)) SetRangeForId(55, 1);
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[CharacterRangePatch] Failed parsing config JSON: {ex}");
            ApplyFallbackDefaults();
        }
    }

    private static void SetRangeForId(int id, int range)
    {
        RangeOverrides[id] = range;
    }

    private static int[] ResolveCharacterIdsByName(string name)
    {
        string cleanName = name.Trim().ToLowerInvariant();

        if (KnownCharacterIds.TryGetValue(cleanName, out int[] ids))
        {
            return ids;
        }

        return null;
    }

    public static bool TryGetRangeOverride(int charaId, out int range)
    {
        if (Plugin.Config != null && !Plugin.Config.EnableCharacterRangeOverrides.Value)
        {
            range = 0;
            return false;
        }

        return RangeOverrides.TryGetValue(charaId, out range);
    }

    /// <summary>
    /// Injects weapon range overrides directly into the game's memory tables:
    /// - fcommand.range (used by Party Formation, Tavern, and Field Menus)
    /// - s_phase.arms_range (used by Tablet of Stars / Status Menus)
    /// - G2_SYS.G2_arms_data (native C++ weapon definitions)
    /// - BootProgram.arms_data
    /// - OldSrcBase.game_work.arms_data
    /// </summary>
    public static void ApplyArmsDataOverrides()
    {
        if (!GameDetection.IsGSD2())
            return;

        try
        {
            // 1. Synchronize fcommand.range (Used by Tavern / Party Formation screen!)
            try
            {
                var fcmdRange = GSD2::fcommand.range;
                if (fcmdRange != null)
                {
                    int len = fcmdRange.Length;
                    foreach (var kvp in RangeOverrides)
                    {
                        if (kvp.Key >= 0 && kvp.Key < len)
                        {
                            if (fcmdRange[kvp.Key] != kvp.Value)
                            {
                                fcmdRange[kvp.Key] = kvp.Value;
                            }
                        }
                    }
                }
            }
            catch { }

            // 2. Synchronize s_phase.arms_range (Used by Status / Tablet of Stars)
            try
            {
                var sPhaseRange = GSD2::EventOverlayClass.s_phase.arms_range;
                if (sPhaseRange != null)
                {
                    int len = sPhaseRange.Length;
                    foreach (var kvp in RangeOverrides)
                    {
                        if (kvp.Key >= 0 && kvp.Key < len)
                        {
                            if (sPhaseRange[kvp.Key] != kvp.Value)
                            {
                                sPhaseRange[kvp.Key] = kvp.Value;
                            }
                        }
                    }
                }
            }
            catch { }

            // 3. Synchronize ARMS_DATA memory tables
            foreach (var kvp in RangeOverrides)
            {
                int charaId = kvp.Key;
                int desiredRange = kvp.Value;

                int armsNo = -1;
                try
                {
                    armsNo = GSD2::G2_SYS.G2_arms_val(charaId);
                }
                catch { }

                if (armsNo >= 0)
                {
                    try
                    {
                        var armsData = GSD2::G2_SYS.G2_arms_data(armsNo);
                        if (armsData != null && armsData.info != null && armsData.info.Length > 0)
                        {
                            if (armsData.info[0] != (byte)desiredRange)
                            {
                                armsData.info[0] = (byte)desiredRange;
                            }
                        }
                    }
                    catch { }

                    try
                    {
                        var bootArms = GSD2::BootProgram.arms_data;
                        if (bootArms != null && armsNo < bootArms.Length && bootArms[armsNo] != null)
                        {
                            var info = bootArms[armsNo].info;
                            if (info != null && info.Length > 0 && info[0] != (byte)desiredRange)
                            {
                                info[0] = (byte)desiredRange;
                            }
                        }
                    }
                    catch { }

                    try
                    {
                        var gw = GSD2::OldSrcBase.game_work?.arms_data;
                        if (gw != null && armsNo < gw.Length && gw[armsNo] != null)
                        {
                            var info = gw[armsNo].info;
                            if (info != null && info.Length > 0 && info[0] != (byte)desiredRange)
                            {
                                info[0] = (byte)desiredRange;
                            }
                        }
                    }
                    catch { }
                }
            }
        }
        catch { }
    }

    [HarmonyPatch(typeof(GSD2::G2_SYS), nameof(GSD2::G2_SYS.G2_arms_range))]
    public static class G2ArmsRangePatch
    {
        [HarmonyPostfix]
        public static void Postfix(int chano, ref int __result)
        {
            try
            {
                if (!GameDetection.IsGSD2())
                    return;

                if (TryGetRangeOverride(chano, out int customRange))
                {
                    __result = customRange;
                }
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"[CharacterRangePatch:G2_arms_range] Postfix error: {ex}");
            }
        }
    }

    [HarmonyPatch(typeof(GSD2::UIStatusWindow), nameof(GSD2::UIStatusWindow.UpdateStatusData))]
    public static class UIStatusWindowUpdateStatusDataPatch
    {
        [HarmonyPostfix]
        public static void Postfix(GSD2::UIStatusWindow __instance, byte characterID)
        {
            try
            {
                if (!GameDetection.IsGSD2() || __instance == null || __instance.WeaponRangeText == null)
                    return;

                ApplyArmsDataOverrides();

                if (TryGetRangeOverride(characterID, out int customRange))
                {
                    string rangeLetter = customRange switch
                    {
                        0 => "S",
                        1 => "M",
                        2 => "L",
                        _ => __instance.WeaponRangeText.text
                    };

                    __instance.WeaponRangeText.text = rangeLetter;
                }
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"[CharacterRangePatch:UIStatusWindow] Postfix error: {ex}");
            }
        }
    }
}
