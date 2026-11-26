extern alias GSD2;

using System;
using HarmonyLib;

namespace PKCore.Patches;

/// <summary>
/// Enhances the Suikoden II Bright Shield Rune (RUNE #13) spells:
/// - Lv1 Great Blessing (magi_no = 0x22): Also applies Clay Guardian (MS_EARTH_PROTECT_FLG,
///   1.5x DEF — the same buff granted by Meringue Pie) to all healed allies.
/// - Lv2 Shining Light (magi_no = 0x23): Multiplies the computed base magic damage by 2,
///   then adds 2x the player's current recruit count.
/// - Lv3 Battle Oath (magi_no = 0x24): Independently rolls a 50% chance per ally to also
///   apply Awakened / Magic Boost (SC_AWAKE, 3 turns) alongside vanilla's 50% Anger (SC_ANGRY)
///   roll, allowing both buffs to coexist on the same character.
/// </summary>
public static class S2BrightShieldEnhancementPatch
{
    private const byte MagiGreatBlessing = 0x22;
    private const byte MagiShiningLight = 0x23;
    private const byte MagiBattleOath = 0x24;

    private const ushort MsEarthProtectFlag = 0x0001; // Clay Guardian (1.5x DEF)
    private const uint StatusAwakeBit = 0x00080000u;  // SC_AWAKE (0x0D)
    private const sbyte AwakeDurationTurns = 3;
    private const int BattleOathAwakeChancePercent = 50;

    private static GSD2::Magic.Eat1 _clayGuardianVisualHelper;
    private static byte _activeDamageMagiNo;

    public static void Initialize(Harmony harmony)
    {
        harmony.PatchAll(typeof(NormalMagicKaifukuFuncPatch));
        harmony.PatchAll(typeof(NormalMagicDamageFuncPatch));
        harmony.PatchAll(typeof(PlayerCalcMagicDamagePatch));
        harmony.PatchAll(typeof(ReactionDataSetCharaPatch));
    }

    private static void ShowClayGuardianPopup(GSD2::BATTLE_WORK bw, int charaNo)
    {
        if (bw == null || charaNo < 0 || charaNo >= bw.player_kazu)
            return;

        if (_clayGuardianVisualHelper == null)
            _clayGuardianVisualHelper = new GSD2::Magic.Eat1(null);

        _clayGuardianVisualHelper.SetStatusAnime(bw, charaNo);
    }

    private static int GetRecruitCount()
    {
        int count = 0;
        for (int id = 1; id < 0x7b; id++)
        {
            if (GSD2::G2_SYS.G2_cha_flag(2, id) == 1)
                count++;
        }
        return count;
    }

    private static GSD2::ACTION_DATA GetLatestActionDataForMagic(GSD2::BattlePlayerCharacter caster, byte magiNo)
    {
        var ad = caster.action_data;
        GSD2::ACTION_DATA match = null;
        while (ad != null)
        {
            if (ad.data != null && ad.data.Length > 0 && ad.data[0] == magiNo)
                match = ad;
            ad = ad.next_action_data;
        }
        return match;
    }

    [HarmonyPatch(typeof(GSD2::BattlePlayerCharacter), nameof(GSD2::BattlePlayerCharacter.NormalMagicKaifukuFunc))]
    private static class NormalMagicKaifukuFuncPatch
    {
        [HarmonyPostfix]
        public static void Postfix(GSD2::BattlePlayerCharacter __instance, byte embl_no, byte magi_no, int __result)
        {
            try
            {
                if (__result == 0 || __instance == null)
                    return;

                if (Plugin.Config == null || !Plugin.Config.EnhanceBrightShieldRune.Value)
                    return;

                if (magi_no != MagiGreatBlessing && magi_no != MagiBattleOath)
                    return;

                var bw = GSD2::BATTLE_WORK.Instance;
                if (bw == null || bw.pm_data == null || bw.p_status_data == null)
                    return;

                var actionData = GetLatestActionDataForMagic(__instance, magi_no);
                if (actionData == null || actionData.reaction_data == null)
                    return;

                int playerCount = Math.Min(bw.player_kazu, Math.Min(bw.pm_data.Length, bw.p_status_data.Length));
                int reactionCount = actionData.reaction_data.Count;

                if (magi_no == MagiGreatBlessing)
                {
                    int buffed = 0;
                    for (int i = 0; i < reactionCount; i++)
                    {
                        var rd = actionData.reaction_data[i];
                        if (rd == null) continue;

                        int targetIdx = rd.mokuhyo;
                        if (targetIdx < 0 || targetIdx >= playerCount) continue;

                        var pStatus = bw.p_status_data[targetIdx];
                        if (pStatus == null) continue;

                        pStatus.magic_status_flg = (ushort)(pStatus.magic_status_flg | MsEarthProtectFlag);
                        buffed++;
                    }

                    Plugin.Log.LogInfo($"[S2BrightShield] Great Blessing applied Clay Guardian (1.5x DEF) to {buffed} allies.");
                }
                else if (magi_no == MagiBattleOath)
                {
                    int awakened = 0;
                    for (int i = 0; i < reactionCount; i++)
                    {
                        var rd = actionData.reaction_data[i];
                        if (rd == null) continue;

                        int targetIdx = rd.mokuhyo;
                        if (targetIdx < 0 || targetIdx >= playerCount) continue;

                        var pm = bw.pm_data[targetIdx];
                        var pStatus = bw.p_status_data[targetIdx];
                        if (pm == null || pStatus == null || pm.IsDead) continue;

                        if (UnityEngine.Random.Range(0, 100) < BattleOathAwakeChancePercent)
                        {
                            // Set SC_AWAKE directly without calling StatusSet(0x0D) so we preserve
                            // SC_ANGRY / ikari_val when both buffs proc on the same ally.
                            pm.status |= StatusAwakeBit;
                            pStatus.awake_cnt = AwakeDurationTurns;
                            rd.reaction_status = pm.status;
                            awakened++;
                        }
                    }

                    Plugin.Log.LogInfo($"[S2BrightShield] Battle Oath applied Awakened (SC_AWAKE) to {awakened} allies.");
                }
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"[S2BrightShield] Error in NormalMagicKaifukuFunc Postfix: {ex.Message}");
            }
        }
    }

    [HarmonyPatch(typeof(GSD2::BattlePlayerCharacter), nameof(GSD2::BattlePlayerCharacter.NormalMagicDamageFunc))]
    private static class NormalMagicDamageFuncPatch
    {
        [HarmonyPrefix]
        public static void Prefix(byte embl_no, byte magi_no)
        {
            _activeDamageMagiNo = magi_no;
        }

        [HarmonyFinalizer]
        public static void Finalizer()
        {
            _activeDamageMagiNo = 0;
        }
    }

    [HarmonyPatch(typeof(GSD2::BattlePlayerCharacter), nameof(GSD2::BattlePlayerCharacter.PlayerCalcMagicDamage))]
    private static class PlayerCalcMagicDamagePatch
    {
        [HarmonyPostfix]
        public static void Postfix(GSD2::BattlePlayerCharacter __instance, GSD2::MAGI_DATA magi_data, int mokuhyo, ref int __result)
        {
            try
            {
                if (magi_data == null || __instance == null)
                    return;

                if (Plugin.Config == null || !Plugin.Config.EnhanceBrightShieldRune.Value)
                    return;

                if (_activeDamageMagiNo != MagiShiningLight)
                    return;

                int recruits = GetRecruitCount();
                int original = __result;
                int bonus = recruits * 2;
                __result = (original * 2) + bonus;

                Plugin.Log.LogInfo($"[S2BrightShield] Shining Light (target {mokuhyo}): ({original} * 2) + ({recruits} recruits * 2 = {bonus}) = {__result}");
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"[S2BrightShield] Error in PlayerCalcMagicDamage Postfix: {ex.Message}");
            }
        }
    }

    [HarmonyPatch(typeof(GSD2::PM_DATA), nameof(GSD2::PM_DATA.ReactionDataSetChara))]
    private static class ReactionDataSetCharaPatch
    {
        [HarmonyPostfix]
        public static void Postfix(GSD2::PM_DATA __instance, int data_no)
        {
            try
            {
                if (__instance == null)
                    return;

                if (Plugin.Config == null || !Plugin.Config.EnhanceBrightShieldRune.Value)
                    return;

                var actionData = __instance.action_data;
                if (actionData == null || actionData.data == null || actionData.data.Length == 0)
                    return;

                if (actionData.data[0] != MagiGreatBlessing)
                    return;

                var reactions = actionData.reaction_data;
                var bw = GSD2::BATTLE_WORK.Instance;
                if (reactions == null || bw == null)
                    return;

                if (data_no < 0)
                {
                    for (int i = 0; i < reactions.Count; i++)
                    {
                        var rd = reactions[i];
                        if (rd != null)
                            ShowClayGuardianPopup(bw, rd.mokuhyo);
                    }
                }
                else if (data_no < reactions.Count)
                {
                    var rd = reactions[data_no];
                    if (rd != null)
                        ShowClayGuardianPopup(bw, rd.mokuhyo);
                }
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"[S2BrightShield] Error in ReactionDataSetChara Postfix: {ex.Message}");
            }
        }
    }
}
