extern alias GSD2;

using System;
using System.Collections.Generic;
using HarmonyLib;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PKCore.Patches;

/// <summary>
/// Disables the Unbalance (botch) status effect penalty when using ability command runes in Suikoden 2 (GSD2).
/// Target runes include: Titan, Falcon, Viper, Shrike, Swallow, Trick, Fire Breath, Mayfly, Lion, Unicorn, Pixie, Blue Drop, etc.
/// Fully configurable via BepInEx config (faospark.pkcore.cfg).
/// </summary>
public static class RuneUnbalancePatch
{
    private static readonly Dictionary<int, ushort> OriginalBotchValues = new();
    private static readonly HashSet<string> TargetRuneKeywords = new(StringComparer.OrdinalIgnoreCase);
    private static readonly HashSet<int> TargetRuneIds = new();

    // Known alias dictionary to support matching English, Japanese, and romanized rune names
    private static readonly Dictionary<string, string[]> KnownRuneAliases = new(StringComparer.OrdinalIgnoreCase)
    {
        { "titan", new[] { "titan", "タイタン" } },
        { "falcon", new[] { "falcon", "はやぶさ", "hayabusa" } },
        { "viper", new[] { "viper", "バイパー" } },
        { "shrike", new[] { "shrike", "しぎ", "moorgate" } },
        { "swallow", new[] { "swallow", "つばめ" } },
        { "trick", new[] { "trick", "からくり" } },
        { "fire breath", new[] { "fire breath", "firebreath", "火炎", "火吹き" } },
        { "mayfly", new[] { "mayfly", "かげろう" } },
        { "lion", new[] { "lion", "しし", "獅子" } },
        { "unicorn", new[] { "unicorn", "ユニコーン" } },
        { "pixie", new[] { "pixie", "ピクシー", "妖精" } },
        { "great hawk", new[] { "great hawk", "greathawk", "hawk", "大鷹", "とび", "kite" } },
        { "blue drop", new[] { "blue drop", "bluedrop", "blue_drop", "青雫", "あおしずく", "drop", "shizuku" } },
        { "nymph", new[] { "nymph", "ニンフ" } },
        { "sylph", new[] { "sylph", "シルフ" } }
    };

    public static bool IsLoaded { get; private set; }
    private static float _lastSyncTime = 0f;
    private static bool _loggedInitialPatch = false;

    public static void Initialize(Harmony harmony)
    {
        try
        {
            LoadConfiguration();

            if (Plugin.Config != null)
            {
                Plugin.Config.EnableRuneUnbalanceRemoval.SettingChanged += (_, _) =>
                {
                    LoadConfiguration();
                    ApplyRuneOverrides();
                };
                Plugin.Config.DisableAllRuneUnbalance.SettingChanged += (_, _) =>
                {
                    LoadConfiguration();
                    ApplyRuneOverrides();
                };
                Plugin.Config.DisabledRuneUnbalanceList.SettingChanged += (_, _) =>
                {
                    LoadConfiguration();
                    ApplyRuneOverrides();
                };
            }

            harmony.PatchAll(typeof(RuneUnbalancePatch));

            SceneManager.sceneLoaded += (UnityEngine.Events.UnityAction<Scene, LoadSceneMode>)OnSceneLoaded;

            ApplyRuneOverrides();

            Plugin.Log.LogInfo("[RuneUnbalancePatch] Initialized rune unbalance removal system successfully with all runtime hooks.");
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[RuneUnbalancePatch] Failed to initialize: {ex}");
        }
    }

    private static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (!GameDetection.IsGSD2())
            return;

        ApplyRuneOverrides();
    }

    public static void Update()
    {
        if (!GameDetection.IsGSD2())
            return;

        if (Plugin.Config != null && !Plugin.Config.EnableRuneUnbalanceRemoval.Value)
            return;

        // Periodic sync to keep in-memory botch overrides intact across save loads or asset reloads
        if (Time.time - _lastSyncTime > 3.0f)
        {
            _lastSyncTime = Time.time;
            ApplyRuneOverrides();
        }
    }

    private static void LoadConfiguration()
    {
        TargetRuneKeywords.Clear();
        TargetRuneIds.Clear();

        try
        {
            string listStr = Plugin.Config?.DisabledRuneUnbalanceList?.Value;
            if (string.IsNullOrWhiteSpace(listStr) || listStr.Equals("default", StringComparison.OrdinalIgnoreCase))
            {
                listStr = "Titan, Falcon, Viper, Shrike, Swallow, Trick, Fire Breath, Mayfly, Lion, Unicorn, Pixie, Blue Drop";
            }

            var entries = listStr.Split(new[] { ',', ';', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var rawEntry in entries)
            {
                var entry = rawEntry.Trim().ToLowerInvariant();
                if (string.IsNullOrEmpty(entry))
                    continue;

                if (int.TryParse(entry, out int numericId))
                {
                    TargetRuneIds.Add(numericId);
                }
                else
                {
                    TargetRuneKeywords.Add(entry);
                    if (KnownRuneAliases.TryGetValue(entry, out var aliases))
                    {
                        foreach (var alias in aliases)
                        {
                            TargetRuneKeywords.Add(alias);
                        }
                    }
                }
            }

            IsLoaded = true;
            Plugin.Log.LogInfo($"[RuneUnbalancePatch] Loaded {TargetRuneKeywords.Count} rune unbalance keyword/ID filters.");
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[RuneUnbalancePatch] Error loading configuration: {ex}");
        }
    }

    public static void ApplyRuneOverrides()
    {
        if (!GameDetection.IsGSD2())
            return;

        bool isEnabled = Plugin.Config == null || Plugin.Config.EnableRuneUnbalanceRemoval.Value;
        bool disableAll = Plugin.Config != null && Plugin.Config.DisableAllRuneUnbalance.Value;

        try
        {
            var ovit = GSD2::G2_SYS.Get_ovit_data();
            if (ovit == null || ovit.embl_data == null)
                return;

            var emblArray = ovit.embl_data;
            int count = emblArray.Length;
            int patchedCount = 0;

            for (int i = 0; i < count; i++)
            {
                var embl = emblArray[i];
                if (embl == null)
                    continue;

                // Cache original botch value if not already saved
                if (!OriginalBotchValues.ContainsKey(i))
                {
                    OriginalBotchValues[i] = embl.botch;
                }

                ushort originalBotch = OriginalBotchValues[i];

                if (!isEnabled)
                {
                    // Restore original value if disabled
                    if (embl.botch != originalBotch)
                    {
                        embl.botch = originalBotch;
                    }
                    continue;
                }

                string runeName = string.Empty;
                try
                {
                    runeName = GSD2::G2_SYS.G2_item_name(ovit, 5, i);
                }
                catch
                {
                    // Fallback
                }

                bool shouldDisable = disableAll || ShouldDisableUnbalanceForRune(i, runeName);

                if (shouldDisable)
                {
                    if (embl.botch != 0)
                    {
                        embl.botch = 0;
                        patchedCount++;

                        if (!_loggedInitialPatch)
                        {
                            Plugin.Log.LogInfo($"[RuneUnbalancePatch] Disabled unbalance penalty for Rune #{i} '{runeName}' (original botch: {originalBotch}).");
                        }
                    }

                    // Also clear unbalance status bytes in the associated MAGI_DATA spell table
                    try
                    {
                        if (embl.magic_no != null)
                        {
                            for (int m = 0; m < embl.magic_no.Length; m++)
                            {
                                byte magiNo = embl.magic_no[m];
                                if (magiNo > 0)
                                {
                                    var magi = GSD2::G2_SYS.G2_magi_data(magiNo);
                                    if (magi != null && magi.status != null)
                                    {
                                        for (int s = 0; s < magi.status.Length; s++)
                                        {
                                            if (magi.status[s] == 2 || magi.status[s] == 1)
                                            {
                                                magi.status[s] = 0;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch
                    {
                        // Ignore
                    }
                }
                else
                {
                    // Restore original if filtered out
                    if (embl.botch != originalBotch)
                    {
                        embl.botch = originalBotch;
                    }
                }
            }

            if (patchedCount > 0 && !_loggedInitialPatch)
            {
                _loggedInitialPatch = true;
                Plugin.Log.LogInfo($"[RuneUnbalancePatch] Successfully patched {patchedCount} ability runes to remove unbalance.");
            }
        }
        catch (Exception ex)
        {
            Plugin.Log.LogWarning($"[RuneUnbalancePatch] Error during rune unbalance override sync: {ex.Message}");
        }
    }

    private static bool ShouldDisableUnbalanceForRune(int runeId, string runeName)
    {
        if (TargetRuneIds.Contains(runeId))
            return true;

        if (string.IsNullOrWhiteSpace(runeName))
            return false;

        string cleanName = runeName.Trim().ToLowerInvariant();

        foreach (var keyword in TargetRuneKeywords)
        {
            if (cleanName.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                return true;
        }

        return false;
    }

    // =========================================================================
    // HARMONY RUNTIME HOOKS FOR BATTLE STATUS & ANIMATION INTERCEPTION
    // =========================================================================

    /// <summary>
    /// Intercepts party member status changes. If unbalance is set,
    /// blocks it and clears unbalance counters so the character is not incapacitated.
    /// </summary>
    [HarmonyPatch(typeof(GSD2::PM_DATA), nameof(GSD2::PM_DATA.StatusSet))]
    [HarmonyPrefix]
    public static bool PM_DATA_StatusSet_Prefix(GSD2::PM_DATA __instance, int status_id)
    {
        if (!GameDetection.IsGSD2())
            return true;

        if (Plugin.Config != null && !Plugin.Config.EnableRuneUnbalanceRemoval.Value)
            return true;

        // Status ID 2 = Unbalance (バランス崩れ / Stun / Botch)
        if (status_id == 2 || status_id == GSD2::battle_h.SC_UNVALA)
        {
            if (__instance != null)
            {
                __instance.unbalance_cnt = 0;
                __instance.unbalance_flg = 0;
                __instance.status &= ~2u;
            }

            Plugin.Log.LogInfo($"[RuneUnbalancePatch] Blocked Unbalance StatusSet({status_id}) for character {__instance?.chara_no}.");
            return false;
        }

        return true;
    }

    /// <summary>
    /// Intercepts player character status bitmask sets during battle. Strips unbalance bit (0x02).
    /// </summary>
    [HarmonyPatch(typeof(GSD2::BattlePlayerCharacter), nameof(GSD2::BattlePlayerCharacter.PlayerStatusSet))]
    [HarmonyPrefix]
    public static bool BattlePlayerCharacter_PlayerStatusSet_Prefix(GSD2::BattlePlayerCharacter __instance, ref ushort status)
    {
        if (!GameDetection.IsGSD2())
            return true;

        if (Plugin.Config != null && !Plugin.Config.EnableRuneUnbalanceRemoval.Value)
            return true;

        // 0x02 is the unbalance bit
        if ((status & 0x02) != 0)
        {
            status = (ushort)(status & ~0x02);
            Plugin.Log.LogInfo("[RuneUnbalancePatch] Stripped Unbalance bit (0x02) in PlayerStatusSet.");

            if (status == 0)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Intercepts status bitmask check on PM_DATA so unbalance check always returns false.
    /// </summary>
    [HarmonyPatch(typeof(GSD2::PM_DATA), nameof(GSD2::PM_DATA.StatusCheck))]
    [HarmonyPrefix]
    public static void PM_DATA_StatusCheck_Prefix(GSD2::PM_DATA __instance, ref uint status)
    {
        if (!GameDetection.IsGSD2())
            return;

        if (Plugin.Config != null && !Plugin.Config.EnableRuneUnbalanceRemoval.Value)
            return;

        if (__instance != null)
        {
            __instance.unbalance_cnt = 0;
            __instance.unbalance_flg = 0;
            __instance.status &= ~2u;
        }

        if ((status & 2u) != 0)
        {
            status &= ~2u;
        }
    }

    /// <summary>
    /// Strips unbalance status bit during battle visual check so unbalance sprite / dizziness is never enabled.
    /// </summary>
    [HarmonyPatch(typeof(GSD2::BATTLE_CHARA), nameof(GSD2::BATTLE_CHARA.DispStatusCheck), new[] { typeof(uint) })]
    [HarmonyPrefix]
    public static void DispStatusCheck_1_Prefix(GSD2::BATTLE_CHARA __instance, ref uint status)
    {
        if (!GameDetection.IsGSD2())
            return;

        if (Plugin.Config != null && !Plugin.Config.EnableRuneUnbalanceRemoval.Value)
            return;

        status &= ~2u;
    }

    /// <summary>
    /// Strips unbalance status bit during battle visual check overload.
    /// </summary>
    [HarmonyPatch(typeof(GSD2::BATTLE_CHARA), nameof(GSD2::BATTLE_CHARA.DispStatusCheck), new[] { typeof(uint), typeof(GSD2::BATTLE_WORK) })]
    [HarmonyPrefix]
    public static void DispStatusCheck_2_Prefix(GSD2::BATTLE_CHARA __instance, ref uint status, GSD2::BATTLE_WORK battle_work)
    {
        if (!GameDetection.IsGSD2())
            return;

        if (Plugin.Config != null && !Plugin.Config.EnableRuneUnbalanceRemoval.Value)
            return;

        status &= ~2u;
    }

    /// <summary>
    /// Blocks enabling the unbalance dizzy star animation object on the character sprite.
    /// </summary>
    [HarmonyPatch(typeof(GSD2::BATTLE_CHARA), nameof(GSD2::BATTLE_CHARA.StatusCharaDispOn))]
    [HarmonyPrefix]
    public static bool BATTLE_CHARA_StatusCharaDispOn_Prefix(GSD2::BATTLE_CHARA __instance, int status_chara_no)
    {
        if (!GameDetection.IsGSD2())
            return true;

        if (Plugin.Config != null && !Plugin.Config.EnableRuneUnbalanceRemoval.Value)
            return true;

        if (status_chara_no == GSD2::battle_h.SC_UNVALA)
        {
            Plugin.Log.LogInfo($"[RuneUnbalancePatch] Blocked StatusCharaDispOn for SC_UNVALA (ID: {status_chara_no}).");
            return false;
        }

        return true;
    }

    /// <summary>
    /// Suppresses the unbalance spinning stars / dizziness status animation start.
    /// </summary>
    [HarmonyPatch(typeof(GSD2::BATTLE_CHARA), nameof(GSD2::BATTLE_CHARA.SetStatusStartAnime))]
    [HarmonyPrefix]
    public static bool BATTLE_CHARA_SetStatusStartAnime_Prefix(GSD2::BATTLE_CHARA __instance, int status_id, ref bool __result)
    {
        if (!GameDetection.IsGSD2())
            return true;

        if (Plugin.Config != null && !Plugin.Config.EnableRuneUnbalanceRemoval.Value)
            return true;

        // Status ID 2 or SC_UNVALA = Unbalance dizziness / spinning stars visual effect
        if (status_id == 2 || status_id == GSD2::battle_h.SC_UNVALA)
        {
            Plugin.Log.LogInfo($"[RuneUnbalancePatch] Suppressed Unbalance dizziness animation (SetStatusStartAnime ID {status_id}).");
            __result = false;
            return false;
        }

        return true;
    }
}
