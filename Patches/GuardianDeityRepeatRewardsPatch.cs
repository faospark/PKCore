extern alias GSD2;

using System;
using HarmonyLib;

namespace PKCore.Patches;

/// <summary>
/// Enables repeatable Guardian Deity statue rewards in Suikoden 2.
/// In retail, Jude only bestows a blessing reward for the very first statue built.
/// When the player subsequently alters or rebuilds the statue at Jude's workshop (h_shugo),
/// this patch clears the reward claimed lock (Story Flag 148 bit 32), re-arms the shrine inspection
/// trigger (Story Flag 148 bit 16), and resets parts_no[3] = 0, allowing unlimited rewards upon visiting
/// the roof shrine (vk33).
/// </summary>
public static class GuardianDeityRepeatRewardsPatch
{
    private static int _lastRewardedStatueCombo = -1;
    private static byte _statueBeforeCustomizer = 0;
    private static bool _customizerActive = false;

    public static void SetLastRewardedStatue(int comboId)
    {
        _lastRewardedStatueCombo = comboId;
    }

    public static void ArmStatueReward(GSD2::GAME_WORK gameWork, string reason)
    {
        if (gameWork?.game_data?.parts_no == null || gameWork.game_data.parts_no.Length <= 3)
            return;

        byte currentCombo = gameWork.game_data.parts_no[2];

        // 1. Reset claimed flag byte
        gameWork.game_data.parts_no[3] = 0;

        // 2. Clear Story Flag 148 bit 32 (0x20) - Reward Received Lock
        gameWork.eventFlgOFF(148, 0x20);

        // 3. Set Story Flag 148 bit 16 (0x10) - Inspection Ready Trigger
        gameWork.eventFlgON(148, 0x10);

        _lastRewardedStatueCombo = -1;

        Plugin.Log.LogInfo($"[GuardianDeity] Re-armed statue reward (Combo: 0x{currentCombo:X2}, Reason: {reason})");
    }

    /// <summary>
    /// Hook Jude's statue customizer initialization (h_shugo.Entry).
    /// </summary>
    [HarmonyPatch(typeof(GSD2::EventOverlayClass.h_shugo), "Entry")]
    [HarmonyPrefix]
    public static void H_Shugo_Entry_Prefix()
    {
        if (!Plugin.Config.EnableRepeatStatueRewards.Value || !GameDetection.IsGSD2()) return;

        try
        {
            var gw = GSD2::OldSrcBase.game_work;
            if (gw?.game_data?.parts_no != null && gw.game_data.parts_no.Length > 2)
            {
                _statueBeforeCustomizer = gw.game_data.parts_no[2];
                _customizerActive = true;
            }
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[GuardianDeity] Error during h_shugo.Entry prefix: {ex}");
        }
    }

    /// <summary>
    /// Hook Jude's statue customizer cleanup (h_shugo.Destroy).
    /// Fires when exiting the workshop customization menu.
    /// </summary>
    [HarmonyPatch(typeof(GSD2::EventOverlayClass.h_shugo), "Destroy")]
    [HarmonyPostfix]
    public static void H_Shugo_Destroy_Postfix(GSD2::EventOverlayClass.h_shugo __instance)
    {
        if (!Plugin.Config.EnableRepeatStatueRewards.Value || !GameDetection.IsGSD2()) return;

        try
        {
            if (!_customizerActive) return;
            _customizerActive = false;

            var gw = GSD2::OldSrcBase.game_work;
            if (gw?.game_data?.parts_no == null || gw.game_data.parts_no.Length <= 3) return;

            byte currentCombo = gw.game_data.parts_no[2];

            // Check if build was confirmed (step 0x5b) or if combination changed
            bool confirmed = false;
            if (__instance?.shugo_work != null)
            {
                confirmed = (__instance.shugo_work.step == 0x5b);
            }

            if (confirmed || currentCombo != _statueBeforeCustomizer)
            {
                ArmStatueReward(gw, confirmed ? "Workshop Build Confirmed" : "Statue Combination Changed");
            }
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[GuardianDeity] Error during h_shugo.Destroy postfix: {ex}");
        }
    }

    /// <summary>
    /// Hook the Guardian Deity Shrine evaluation initialization (syugoSet.Entry).
    /// Called when visiting the roof shrine (vk33).
    /// </summary>
    [HarmonyPatch(typeof(GSD2::EventOverlayClass.syugoSet), "Entry")]
    [HarmonyPrefix]
    public static void SyugoSet_Entry_Prefix()
    {
        if (!Plugin.Config.EnableRepeatStatueRewards.Value || !GameDetection.IsGSD2()) return;

        try
        {
            var gw = GSD2::OldSrcBase.game_work;
            if (gw?.game_data?.parts_no == null || gw.game_data.parts_no.Length <= 3) return;

            byte currentCombo = gw.game_data.parts_no[2];
            byte claimedFlag = gw.game_data.parts_no[3];

            // If the player loaded a save with an unclaimed statue or changed statue combination
            if (claimedFlag == 0 || (_lastRewardedStatueCombo >= 0 && currentCombo != _lastRewardedStatueCombo))
            {
                // Ensure the shrine event can trigger
                gw.eventFlgOFF(148, 0x20); // Clear Claimed Lock
                gw.eventFlgON(148, 0x10);  // Set Ready Flag
                gw.game_data.parts_no[3] = 0;
            }
            else if (_lastRewardedStatueCombo < 0 && claimedFlag == 1)
            {
                // Preserve already claimed state from previous session
                _lastRewardedStatueCombo = currentCombo;
            }
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[GuardianDeity] Error during syugoSet.Entry prefix: {ex}");
        }
    }

    /// <summary>
    /// Hook the item reward delivery (syugoitm.s_OverlayAddItem2Main).
    /// Marks the current statue combination as rewarded once Jude grants the blessing.
    /// </summary>
    [HarmonyPatch(typeof(GSD2::EventOverlayClass.syugoitm), "s_OverlayAddItem2Main")]
    [HarmonyPostfix]
    public static void Syugoitm_Reward_Postfix(int __result)
    {
        if (!Plugin.Config.EnableRepeatStatueRewards.Value || !GameDetection.IsGSD2()) return;

        try
        {
            // Returns 1 when item delivery sequence completes
            if (__result == 1)
            {
                var gw = GSD2::OldSrcBase.game_work;
                if (gw?.game_data?.parts_no != null && gw.game_data.parts_no.Length > 2)
                {
                    byte currentCombo = gw.game_data.parts_no[2];
                    SetLastRewardedStatue(currentCombo);
                    Plugin.Log.LogInfo($"[GuardianDeity] Successfully delivered reward for statue 0x{currentCombo:X2}!");
                }
            }
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[GuardianDeity] Error during syugoitm reward postfix: {ex}");
        }
    }
}
