extern alias GSD2;

using System;
using System.Collections.Generic;
using System.Text;
using HarmonyLib;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PKCore.Patches;

/// <summary>
/// Enables unlimited / reusable command runes in battle for Suikoden 2 (GSD2):
/// - Meg / Gadget: Trick Rune / Gadget Rune (からくりの紋章)
/// - Millie / Bonaparte: Groundhog Rune (モグラの紋章)
/// - Shin: Spider Slay Rune (八房の紋章 / 蜘蛛斬り)
/// - Oulan: Angry Dragon Rune (怒竜の紋章 / 狂竜 / 激怒)
/// Fully configurable via BepInEx config (faospark.pkcore.cfg).
/// </summary>
public static class CommandRuneUnlimitedPatch
{
    public static bool IsLoaded { get; private set; }
    private static float _lastSyncTime = 0f;
    private static bool _loggedRuneDump = false;

    // Track identified rune indices
    private static readonly HashSet<int> CommandRuneIndices = new();

    public static void Initialize(Harmony harmony)
    {
        try
        {
            Plugin.Log.LogInfo("[CommandRuneUnlimitedPatch] Initializing reusable command runes patch for Suikoden 2...");
            harmony.PatchAll(typeof(CommandRuneUnlimitedPatch));
            SceneManager.sceneLoaded += (UnityEngine.Events.UnityAction<Scene, LoadSceneMode>)OnSceneLoaded;
            IsLoaded = true;
            Plugin.Log.LogInfo("[CommandRuneUnlimitedPatch] Initialized reusable command runes patch successfully.");

            DumpAndIdentifyRunes();
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[CommandRuneUnlimitedPatch] Failed to initialize: {ex}");
        }
    }

    private static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (!GameDetection.IsGSD2())
            return;

        Plugin.Log.LogInfo($"[CommandRuneUnlimitedPatch] Scene loaded: {scene.name}. Refreshing command rune tables...");
        DumpAndIdentifyRunes();
        RefreshCommandRunes();
    }

    public static void Update()
    {
        if (!GameDetection.IsGSD2())
            return;

        if (Plugin.Config != null && !Plugin.Config.EnableUnlimitedCommandRunes.Value)
            return;

        if (!_loggedRuneDump)
        {
            DumpAndIdentifyRunes();
        }

        // Periodic sync to ensure special command rune uses and MP slots are replenished during battle
        if (Time.time - _lastSyncTime > 0.5f)
        {
            _lastSyncTime = Time.time;
            RefreshCommandRunes();
        }
    }

    /// <summary>
    /// Scans ovit_data, identifies target command runes, and dumps database info to the log.
    /// </summary>
    public static void DumpAndIdentifyRunes()
    {
        if (!GameDetection.IsGSD2())
            return;

        try
        {
            var ovit = GSD2::G2_SYS.Get_ovit_data();
            if (ovit == null || ovit.embl_data == null)
                return;

            CommandRuneIndices.Clear();
            var sb = new StringBuilder();
            sb.AppendLine("[CommandRuneUnlimitedPatch] === SUIKODEN 2 RUNE DATABASE DUMP ===");

            int count = ovit.embl_data.Length;
            for (int i = 0; i < count; i++)
            {
                var embl = ovit.embl_data[i];
                if (embl == null)
                    continue;

                string runeName = string.Empty;
                try
                {
                    runeName = GSD2::G2_SYS.G2_item_name(ovit, 5, i);
                }
                catch { }

                string lower = runeName.ToLowerInvariant();
                bool isTarget = lower.Contains("trick") || lower.Contains("gadget") || lower.Contains("からくり") ||
                                lower.Contains("groundhog") || lower.Contains("モグラ") || lower.Contains("bonaparte") ||
                                lower.Contains("spider") || lower.Contains("八房") || lower.Contains("蜘蛛") ||
                                lower.Contains("angry dragon") || lower.Contains("狂竜") || lower.Contains("怒竜") || lower.Contains("激怒");

                if (isTarget)
                {
                    CommandRuneIndices.Add(i);
                }

                string magiInfo = string.Empty;
                if (embl.magic_no != null && embl.magic_no.Length > 0)
                {
                    var magList = new List<string>();
                    for (int m = 0; m < embl.magic_no.Length; m++)
                    {
                        byte mNo = embl.magic_no[m];
                        if (mNo > 0)
                        {
                            var magi = GSD2::G2_SYS.G2_magi_data(mNo);
                            string magName = magi != null ? $"Magi #{mNo} (Atrb:{magi.atrb}, Eff:{magi.eff_val})" : $"Magi #{mNo}";
                            magList.Add(magName);
                        }
                    }
                    magiInfo = string.Join(", ", magList);
                }

                if (isTarget || !_loggedRuneDump)
                {
                    sb.AppendLine($"  {(isTarget ? "[TARGET] " : "")}Rune #{i:D2}: '{runeName}' | Botch:{embl.botch} | Bonus:{embl.bonus} | Spells: [{magiInfo}]");
                }
            }

            if (!_loggedRuneDump)
            {
                _loggedRuneDump = true;
                Plugin.Log.LogInfo(sb.ToString());
            }
        }
        catch (Exception ex)
        {
            Plugin.Log.LogWarning($"[CommandRuneUnlimitedPatch] Error dumping runes: {ex.Message}");
        }
    }

    /// <summary>
    /// Refreshes special command rune selection counts and flags in memory.
    /// </summary>
    public static void RefreshCommandRunes()
    {
        if (!GameDetection.IsGSD2())
            return;

        if (Plugin.Config != null && !Plugin.Config.EnableUnlimitedCommandRunes.Value)
            return;

        try
        {
            // Replenish w_battle.tokusyu_sel_kaisu and tokusyu_sel_flag
            var kaisuArray = GSD2::w_battle.tokusyu_sel_kaisu;
            var maxKaisuArray = GSD2::w_battle.tokusyu_sel_kaisuMax;
            var flagArray = GSD2::w_battle.tokusyu_sel_flag;

            if (kaisuArray != null)
            {
                for (int i = 0; i < kaisuArray.Length; i++)
                {
                    sbyte maxCount = (maxKaisuArray != null && i < maxKaisuArray.Length && maxKaisuArray[i] > 0)
                        ? maxKaisuArray[i]
                        : (sbyte)1;

                    if (kaisuArray[i] == 0)
                    {
                        kaisuArray[i] = maxCount;
                        Plugin.Log.LogInfo($"[CommandRuneUnlimitedPatch] Replenished tokusyu_sel_kaisu[{i}] -> {maxCount}");
                    }
                }
            }

            if (flagArray != null)
            {
                for (int i = 0; i < flagArray.Length; i++)
                {
                    if (flagArray[i] == 0)
                    {
                        flagArray[i] = 1;
                        Plugin.Log.LogInfo($"[CommandRuneUnlimitedPatch] Enabled tokusyu_sel_flag[{i}] -> 1");
                    }
                }
            }

            // Also replenish C_VARIA_DAT.mp for party members who have target command runes equipped
            for (int c = 0; c < 108; c++)
            {
                try
                {
                    var varia = GSD2::G2_SYS.G2_varia_dat(c);
                    if (varia == null || varia.mon_eqp == null || varia.mp == null)
                        continue;

                    bool hasCommandRune = false;
                    for (int r = 0; r < varia.mon_eqp.Length; r++)
                    {
                        byte runeId = varia.mon_eqp[r];
                        if (runeId > 0 && CommandRuneIndices.Contains(runeId))
                        {
                            hasCommandRune = true;
                            break;
                        }
                    }

                    if (hasCommandRune)
                    {
                        for (int m = 0; m < varia.mp.Length; m++)
                        {
                            if (varia.mp[m] == 0)
                            {
                                varia.mp[m] = 1;
                                Plugin.Log.LogInfo($"[CommandRuneUnlimitedPatch] Replenished varia.mp[{m}] for character #{c}");
                            }
                        }
                    }
                }
                catch { }
            }
        }
        catch
        {
            // Ignore when not in battle
        }
    }

    // =========================================================================
    // HARMONY BATTLE INTERCEPTION HOOKS
    // =========================================================================

    /// <summary>
    /// Hook GetEmblMagicNum: If the rune is a target command rune or has 0 uses, force it to return at least 1 use.
    /// </summary>
    [HarmonyPatch(typeof(GSD2::BattleManager), nameof(GSD2::BattleManager.GetEmblMagicNum))]
    [HarmonyPostfix]
    public static void BattleManager_GetEmblMagicNum_Postfix(GSD2::BattleManager __instance, int player_no, byte embl_no, ref int __result)
    {
        if (!GameDetection.IsGSD2())
            return;

        if (Plugin.Config == null || !Plugin.Config.EnableUnlimitedCommandRunes.Value)
            return;

        Plugin.Log.LogInfo($"[CommandRuneUnlimitedPatch] GetEmblMagicNum(player:{player_no}, embl:{embl_no}) original result: {__result}");

        if (__result == 0)
        {
            __result = 1;
            Plugin.Log.LogInfo($"[CommandRuneUnlimitedPatch] Overrode GetEmblMagicNum(player:{player_no}, embl:{embl_no}) -> 1");
        }
    }

    /// <summary>
    /// Hook make_embl_window to replenish rune usage counts before and after the menu is displayed.
    /// </summary>
    [HarmonyPatch(typeof(GSD2::BattleManager), nameof(GSD2::BattleManager.make_embl_window))]
    [HarmonyPrefix]
    public static void BattleManager_make_embl_window_Prefix(GSD2::BattleManager __instance, int player_no)
    {
        if (!GameDetection.IsGSD2())
            return;

        Plugin.Log.LogInfo($"[CommandRuneUnlimitedPatch] make_embl_window Prefix - PlayerNo: {player_no}");
        RefreshCommandRunes();
    }

    [HarmonyPatch(typeof(GSD2::BattleManager), nameof(GSD2::BattleManager.make_embl_window))]
    [HarmonyPostfix]
    public static void BattleManager_make_embl_window_Postfix(GSD2::BattleManager __instance, int player_no)
    {
        if (!GameDetection.IsGSD2())
            return;

        Plugin.Log.LogInfo($"[CommandRuneUnlimitedPatch] make_embl_window Postfix - PlayerNo: {player_no}");
        RefreshCommandRunes();
    }

    /// <summary>
    /// Hook make_magic_window to replenish rune usage counts when viewing runes.
    /// </summary>
    [HarmonyPatch(typeof(GSD2::BattleManager), nameof(GSD2::BattleManager.make_magic_window))]
    [HarmonyPrefix]
    public static void BattleManager_make_magic_window_Prefix(GSD2::BattleManager __instance, int player_no)
    {
        if (!GameDetection.IsGSD2())
            return;

        Plugin.Log.LogInfo($"[CommandRuneUnlimitedPatch] make_magic_window Prefix - PlayerNo: {player_no}");
        RefreshCommandRunes();
    }

    [HarmonyPatch(typeof(GSD2::BattleManager), nameof(GSD2::BattleManager.make_magic_window))]
    [HarmonyPostfix]
    public static void BattleManager_make_magic_window_Postfix(GSD2::BattleManager __instance, int player_no)
    {
        if (!GameDetection.IsGSD2())
            return;

        Plugin.Log.LogInfo($"[CommandRuneUnlimitedPatch] make_magic_window Postfix - PlayerNo: {player_no}");
        RefreshCommandRunes();
    }

    /// <summary>
    /// Hook SetSelectTokusyuStepInit to ensure command rune slots are unblocked.
    /// </summary>
    [HarmonyPatch(typeof(GSD2::w_battle), nameof(GSD2::w_battle.SetSelectTokusyuStepInit))]
    [HarmonyPostfix]
    public static void w_battle_SetSelectTokusyuStepInit_Postfix()
    {
        if (!GameDetection.IsGSD2())
            return;

        Plugin.Log.LogInfo("[CommandRuneUnlimitedPatch] w_battle.SetSelectTokusyuStepInit Postfix fired.");
        RefreshCommandRunes();
    }

    /// <summary>
    /// Hook SelectTokusyuStepInit to keep command rune options selectable.
    /// </summary>
    [HarmonyPatch(typeof(GSD2::w_battle), nameof(GSD2::w_battle.SelectTokusyuStepInit))]
    [HarmonyPostfix]
    public static void w_battle_SelectTokusyuStepInit_Postfix()
    {
        if (!GameDetection.IsGSD2())
            return;

        Plugin.Log.LogInfo("[CommandRuneUnlimitedPatch] w_battle.SelectTokusyuStepInit Postfix fired.");
        RefreshCommandRunes();
    }

    /// <summary>
    /// Hook PM_DATA.SpecialCanCheck so special command runes are always considered available.
    /// </summary>
    [HarmonyPatch(typeof(GSD2::PM_DATA), nameof(GSD2::PM_DATA.SpecialCanCheck))]
    [HarmonyPostfix]
    public static void PM_DATA_SpecialCanCheck_Postfix(GSD2::PM_DATA __instance, ref bool __result)
    {
        if (!GameDetection.IsGSD2())
            return;

        if (Plugin.Config != null && Plugin.Config.EnableUnlimitedCommandRunes.Value)
        {
            Plugin.Log.LogInfo($"[CommandRuneUnlimitedPatch] PM_DATA.SpecialCanCheck for chara_no {__instance?.chara_no} (Original: {__result}) -> forcing True.");
            __result = true;
        }
    }

    /// <summary>
    /// Hook PM_DATA.StatusCheck so Fury check (0x20) returns non-zero (1) for Oulan if AlwaysAvailableAngryDragon is enabled.
    /// </summary>
    [HarmonyPatch(typeof(GSD2::PM_DATA), nameof(GSD2::PM_DATA.StatusCheck))]
    [HarmonyPostfix]
    public static void PM_DATA_StatusCheck_Postfix(GSD2::PM_DATA __instance, uint status, ref int __result)
    {
        if (!GameDetection.IsGSD2())
            return;

        if (Plugin.Config == null || !Plugin.Config.AlwaysAvailableAngryDragon.Value)
            return;

        // Status bit 0x20 = Fury / Ikari (怒り)
        if ((status & 0x20u) != 0 && __instance != null)
        {
            if (__instance.chara_no == 22 || __instance.chara_no == 47)
            {
                Plugin.Log.LogInfo($"[CommandRuneUnlimitedPatch] PM_DATA.StatusCheck for Oulan Fury (0x20) (Original: {__result}) -> forcing 1.");
                __result = 1;
            }
        }
    }

    /// <summary>
    /// Hook BattlePlayerCharacter.CalcIkariEnd so Oulan's Fury does not expire if AlwaysAvailableAngryDragon is enabled.
    /// </summary>
    [HarmonyPatch(typeof(GSD2::BattlePlayerCharacter), nameof(GSD2::BattlePlayerCharacter.CalcIkariEnd))]
    [HarmonyPostfix]
    public static void BattlePlayerCharacter_CalcIkariEnd_Postfix(GSD2::BattlePlayerCharacter __instance, ref int __result)
    {
        if (!GameDetection.IsGSD2())
            return;

        if (Plugin.Config == null || !Plugin.Config.AlwaysAvailableAngryDragon.Value)
            return;

        try
        {
            if (__instance != null)
            {
                Plugin.Log.LogInfo("[CommandRuneUnlimitedPatch] BattlePlayerCharacter.CalcIkariEnd: Restoring IkariVal to 100.");
                __instance.SetIkariVal(100);
            }
        }
        catch
        {
            // Ignore
        }
    }

    /// <summary>
    /// Hook BattlePlayerCharacter.PlayerStatusClear to prevent clearing the Fury status bit (0x20).
    /// </summary>
    [HarmonyPatch(typeof(GSD2::BattlePlayerCharacter), nameof(GSD2::BattlePlayerCharacter.PlayerStatusClear))]
    [HarmonyPrefix]
    public static bool BattlePlayerCharacter_PlayerStatusClear_Prefix(GSD2::BattlePlayerCharacter __instance, ref ushort status)
    {
        if (!GameDetection.IsGSD2())
            return true;

        if (Plugin.Config == null || !Plugin.Config.AlwaysAvailableAngryDragon.Value)
            return true;

        // If trying to clear Fury (0x20), strip it out so Fury is retained
        if ((status & 0x20) != 0)
        {
            Plugin.Log.LogInfo("[CommandRuneUnlimitedPatch] Prevented clearing Fury status bit (0x20) in PlayerStatusClear.");
            status = (ushort)(status & ~0x20);
            if (status == 0)
                return false;
        }

        return true;
    }
}
