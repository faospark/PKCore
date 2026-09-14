extern alias GSD2;

using System;
using System.Collections.Generic;
using System.IO;
using HarmonyLib;
using UnityEngine;

namespace PKCore.Patches;

/// <summary>
/// Allows customizable weapon battle range overrides for Suikoden 2 (GSD2) characters.
/// Defaults to making Kasumi, Luc, Mazus, Viki, Gantetsu, and Badeaux Medium Range (M).
/// Overrides work across all UI displays (Status, Formation/Tavern party swap, Field command)
/// and native battle calculations (enabling back-row attacks).
/// Fully configurable via BepInEx config (faospark.pkcore.cfg).
/// </summary>
public static class CharacterRangePatch
{
    // Maps character ID -> Range (0 = Short, 1 = Medium, 2 = Long)
    private static readonly Dictionary<int, int> RangeOverrides = new();

    // Character mapping for the targeted characters and their internal party/catalog IDs
    private static readonly Dictionary<string, int[]> KnownCharacterIds = new(StringComparer.OrdinalIgnoreCase)
    {
        { "kasumi", new[] { 72, 73 } }, { "ksm", new[] { 72, 73 } },
        { "luc", new[] { 53, 139 } }, { "ruk", new[] { 53, 139 } }, { "luk", new[] { 53, 139 } },
        { "mazus", new[] { 50, 61 } }, { "msm", new[] { 50, 61 } },
        { "viki", new[] { 4, 55 } }, { "wig", new[] { 4, 55 } }, { "wiki", new[] { 4, 55 } },
        { "gantetsu", new[] { 60, 70, 71, 137 } }, { "gentetsu", new[] { 60, 70, 71, 137 } }, { "jij", new[] { 60, 70, 71, 137 } }, { "gsu", new[] { 60, 70, 71, 137 } },
        { "badeaux", new[] { 51, 52, 71, 72 } }, { "uni", new[] { 51, 52, 71, 72 } },
        { "sierra", new[] { 44, 45, 46 } }, { "siera", new[] { 44, 45, 46 } }, { "sie", new[] { 44, 45, 46 } }
    };

    private static readonly string[] RangeLetters = { "S", "M", "L" };
    public static bool IsLoaded { get; private set; }
    private static float _lastMemorySyncTime = 0f;

    public static void Initialize(Harmony harmony)
    {
        try
        {
            LoadConfiguration();

            if (Plugin.Config != null)
            {
                Plugin.Config.S2CharacterRangeOverrides.SettingChanged += (_, _) =>
                {
                    LoadConfiguration();
                    ApplyArmsDataOverrides();
                };
                Plugin.Config.EnableCharacterRangeOverrides.SettingChanged += (_, _) =>
                {
                    LoadConfiguration();
                    ApplyArmsDataOverrides();
                };
            }

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

        try
        {
            string configStr = Plugin.Config?.S2CharacterRangeOverrides?.Value;
            if (string.IsNullOrWhiteSpace(configStr) || configStr.Equals("default", StringComparison.OrdinalIgnoreCase))
            {
                configStr = "Kasumi:M, Luc:M, Mazus:M, Viki:M, Gantetsu:M, Badeaux:M, Sierra:M";
            }

            ParseConfigString(configStr);
            IsLoaded = true;

            Plugin.Log.LogInfo($"[CharacterRangePatch] Loaded {RangeOverrides.Count} character range overrides from BepInEx config.");
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[CharacterRangePatch] Error loading configuration: {ex}");
            ApplyFallbackDefaults();
        }
    }

    private static void ApplyFallbackDefaults()
    {
        ParseConfigString("Kasumi:M, Luc:M, Mazus:M, Viki:M, Gantetsu:M, Badeaux:M, Sierra:M");
    }

    private static void ParseConfigString(string configStr)
    {
        try
        {
            var entries = configStr.Split(new[] { ',', ';', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var rawEntry in entries)
            {
                var entry = rawEntry.Trim();
                if (string.IsNullOrEmpty(entry) || entry.StartsWith("#") || entry.StartsWith("//"))
                    continue;

                var parts = entry.Split(new[] { ':', '=' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != 2)
                    continue;

                string key = parts[0].Trim().Trim('"', '\'');
                string val = parts[1].Trim().Trim('"', '\'').ToUpperInvariant();

                int rangeValue = val switch
                {
                    "M" or "MEDIUM" or "1" => 1,
                    "L" or "LONG" or "2" => 2,
                    "S" or "SHORT" or "0" => 0,
                    _ => -1
                };

                if (rangeValue < 0)
                    continue;

                if (int.TryParse(key, out int numericId))
                {
                    RangeOverrides[numericId] = rangeValue;
                }
                else
                {
                    int[] charaIds = ResolveCharacterIdsByName(key);
                    if (charaIds != null && charaIds.Length > 0)
                    {
                        foreach (int id in charaIds)
                        {
                            RangeOverrides[id] = rangeValue;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[CharacterRangePatch] Failed parsing config string: {ex}");
        }
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

                if (TryGetRangeOverride(characterID, out int customRange))
                {
                    if (customRange >= 0 && customRange < RangeLetters.Length)
                    {
                        __instance.WeaponRangeText.text = RangeLetters[customRange];
                    }
                }
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"[CharacterRangePatch:UIStatusWindow] Postfix error: {ex}");
            }
        }
    }
}

