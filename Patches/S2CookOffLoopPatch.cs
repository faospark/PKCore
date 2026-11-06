extern alias GSD2;

using System;
using HarmonyLib;
using UnityEngine;

namespace PKCore.Patches;

/// <summary>
/// Handles infinite looping, synchronization, and cooldown management of Suikoden 2 cook-off minigame battles (Chef Hai Yo).
///
/// Features:
/// 1. LoopCookOffMatches: After the player defeats the final chef (Jinkai, Match 12) and the post-contest
///    celebration cutscene in the castle farm (vk19) concludes, this patch detects the completion gate (Flag 494)
///    upon leaving vk19 and automatically resets the match progression and scheduling flags back to Match 1 (Chef Ky Yun / Yu Kum).
///    All collected recipes (food_resipi) and seasoning bonuses remain completely preserved.
///
/// 2. Match Queue Synchronization: In vanilla Suikoden II, the cooking battle minigame (Overlay_rbattle.rbattleinit)
///    determines the rival chef by counting the total number of set bits across event_flag[152] and event_flag[153],
///    while the arena map cutscene (vk30) checks the specific bit corresponding to the challenger.
///    This patch ensures continuous bitmask consistency across flags 148, 152, and 153, preventing desync
///    where the introduced cutscene chef differs from the opponent fought in the arena.
///
/// 3. ReduceCookOffCooldown: In vanilla Suikoden II, the castle hub (vk06) and restaurant (vk05) check internal
///    gameplay timers (Timer 8 and Timer 10 via Opcode 37) requiring 30-60 minutes of active player movement between matches.
///    When enabled, this patch saturates elapsed timer seconds so the next rival chef can be challenged immediately.
/// </summary>
public static class S2CookOffLoopPatch
{
    private const int MASTER_COMPLETION_BYTE = 61;
    private const byte FLAG_494_BIT = 0x40; // Cook-off master completion gate
    private const byte FLAG_493_BIT = 0x20; // Post-contest cutscene active marker

    private const int MATCHES_1_TO_8_WON_BYTE = 71;
    private const int MATCHES_9_TO_12_WON_BYTE = 72;
    private const byte MATCH_12_WON_BIT = 0x08; // 4th bit (0x01=M9, 0x02=M10, 0x04=M11, 0x08=M12)

    private const int MATCHES_1_TO_8_QUEUE_BYTE = 152;
    private const int MATCHES_9_TO_12_QUEUE_BYTE = 153;

    private const int RESTAURANT_CHALLENGER_WAITING_BYTE = 148;
    private const byte FLAG_1185_BIT = 0x02; // Bit 1 of byte 148 (Challenger waiting in restaurant)
    private const byte STALE_CHALLENGER_BITS_148 = 0x0E; // Bits 1, 2, 3 (0x02=waiting, 0x04=M8/Lester intermediate, 0x08=M8/Lester intermediate)

    private const int KITCHEN_TRIGGER_BYTE = 132;
    private const byte FLAG_1062_BIT = 0x40; // Bit 6 of byte 132

    private const ushort SATURATED_TIMER_SECONDS = 7200; // 2 hours (bypasses all 30-60 min thresholds)
    private static float _cooldownTimerThrottle = 0f;

    /// <summary>
    /// Vanilla Suikoden II chef table mapping match index (0..11) to native chef ID:
    /// Match 1: Ky Yun (Yu Kum) -> 0
    /// Match 2: Goetsu -> 1
    /// Match 3: Shinki -> 2
    /// Match 4: Ryuki -> 3
    /// Match 5: Bashok -> 4
    /// Match 6: Ryuko -> 5
    /// Match 7: Antonio -> 6
    /// Match 8: Gyokuran -> 8
    /// Match 9: Retso (Match 1) -> 9
    /// Match 10: Lester -> 7
    /// Match 11: Retso (Match 2) -> 9
    /// Match 12: Jinkai -> 10
    /// </summary>
    public static readonly byte[] ChefTable = { 0, 1, 2, 3, 4, 5, 6, 8, 9, 7, 9, 10 };

    public static readonly string[] ChefNames = {
        "Ky Yun (Yu Kum)", "Goetsu", "Shinki", "Ryuki", "Bashok", "Ryuko",
        "Antonio", "Gyokuran", "Retso (Match 1)", "Lester", "Retso (Match 2)", "Jinkai"
    };

    /// <summary>
    /// Periodic tick called by PkCoreMainLoop.Update() to maintain cooldown saturation in GSD2.
    /// </summary>
    public static void Update()
    {
        if (!GameDetection.IsGSD2())
            return;

        if (Plugin.Config?.ReduceCookOffCooldown?.Value != true)
            return;

        _cooldownTimerThrottle += Time.unscaledDeltaTime;
        if (_cooldownTimerThrottle < 1.0f)
            return;
        _cooldownTimerThrottle = 0f;

        ApplyCooldownReduction();
    }

    /// <summary>
    /// Resolves the currently scheduled cook-off match (1..12) based on the highest set queue flag.
    /// Returns 0 if no match is currently scheduled.
    /// </summary>
    public static int GetCurrentScheduledMatch()
    {
        try
        {
            var gw = GSD2::OldSrcBase.game_work;
            if (gw?.event_flag == null || gw.event_flag.Length <= MATCHES_9_TO_12_QUEUE_BYTE)
                return 0;

            byte f152 = gw.event_flag[MATCHES_1_TO_8_QUEUE_BYTE];
            byte f153 = gw.event_flag[MATCHES_9_TO_12_QUEUE_BYTE];

            // Evaluate in reverse order (highest scheduled match wins)
            if ((f153 & 0x08) != 0) return 12; // Jinkai
            if ((f153 & 0x04) != 0) return 11; // Retso 2
            if ((f153 & 0x02) != 0) return 10; // Lester
            if ((f153 & 0x01) != 0) return 9;  // Retso 1
            if ((f152 & 0x80) != 0) return 8;  // Gyokuran
            if ((f152 & 0x40) != 0) return 7;  // Antonio
            if ((f152 & 0x20) != 0) return 6;  // Ryuko
            if ((f152 & 0x10) != 0) return 5;  // Bashok
            if ((f152 & 0x08) != 0) return 4;  // Ryuki
            if ((f152 & 0x04) != 0) return 3;  // Shinki
            if ((f152 & 0x02) != 0) return 2;  // Goetsu
            if ((f152 & 0x01) != 0) return 1;  // Ky Yun
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[Cook-Off Loop] Error detecting scheduled match: {ex}");
        }

        return 0;
    }

    /// <summary>
    /// Ensures event_flag[152] and event_flag[153] contain the EXACT continuous set bits (1..targetMatch)
    /// expected by the vanilla battle_num counting loop in Overlay_rbattle.rbattleinit.
    /// Eliminates any bit fragmentation or desync between cutscenes and minigame arenas.
    /// </summary>
    public static void SynchronizeMatchQueue(int targetMatch)
    {
        if (targetMatch < 1 || targetMatch > 12)
            return;

        var gw = GSD2::OldSrcBase.game_work;
        if (gw?.event_flag == null || gw.event_flag.Length <= MATCHES_9_TO_12_QUEUE_BYTE)
            return;

        // In vanilla, for match N (1..12), exactly the first N bits across bytes 152 and 153 are set:
        // Byte 152 holds matches 1..8 (bits 0..7).
        // Byte 153 holds matches 9..12 (bits 0..3).
        byte expected152 = 0;
        byte expected153 = 0;

        if (targetMatch <= 8)
        {
            expected152 = (byte)((1 << targetMatch) - 1);
            expected153 = 0;
        }
        else
        {
            expected152 = 0xFF;
            expected153 = (byte)((1 << (targetMatch - 8)) - 1);
        }

        // Preserve non-queue high bits of byte 153 (e.g. 0x10=in-scene, 0x20=lost, 0x40=won)
        byte highBits153 = (byte)(gw.event_flag[MATCHES_9_TO_12_QUEUE_BYTE] & 0xF0);

        if (gw.event_flag[MATCHES_1_TO_8_QUEUE_BYTE] != expected152 ||
            (gw.event_flag[MATCHES_9_TO_12_QUEUE_BYTE] & 0x0F) != expected153)
        {
            Plugin.Log.LogInfo($"[Cook-Off Loop] Synchronizing match flags for Match {targetMatch} ({ChefNames[targetMatch - 1]}): " +
                               $"flag[152] 0x{gw.event_flag[MATCHES_1_TO_8_QUEUE_BYTE]:X2} -> 0x{expected152:X2}, " +
                               $"flag[153] 0x{gw.event_flag[MATCHES_9_TO_12_QUEUE_BYTE]:X2} -> 0x{(expected153 | highBits153):X2}");

            gw.event_flag[MATCHES_1_TO_8_QUEUE_BYTE] = expected152;
            gw.event_flag[MATCHES_9_TO_12_QUEUE_BYTE] = (byte)(expected153 | highBits153);
        }
    }

    /// <summary>
    /// Evaluates cook-off completion state upon map initialization and resets flags if eligible.
    /// Also applies cooldown reduction immediately upon map load and self-heals desynced flags.
    /// </summary>
    public static void CheckAndResetCookOffs(string currentMapId)
    {
        if (!GameDetection.IsGSD2())
            return;

        // Apply cooldown reduction on map transitions
        ApplyCooldownReduction();

        if (Plugin.Config?.LoopCookOffMatches?.Value != true)
            return;

        // Never reset while actively inside the castle farm/garden (vk19) where the post-contest scene plays
        if (string.IsNullOrEmpty(currentMapId) || currentMapId.StartsWith("vk19", StringComparison.OrdinalIgnoreCase))
            return;

        try
        {
            var gw = GSD2::OldSrcBase.game_work;
            if (gw?.event_flag == null || gw.event_flag.Length <= MATCHES_9_TO_12_QUEUE_BYTE)
                return;

            // Check if Master Completion Gate (Flag 494) is set
            bool isCompletedGateActive = (gw.event_flag[MASTER_COMPLETION_BYTE] & FLAG_494_BIT) != 0;

            // Check if Match 12 (Jinkai) is won
            bool isMatch12Won = (gw.event_flag[MATCHES_9_TO_12_WON_BYTE] & MATCH_12_WON_BIT) != 0;

            if (isCompletedGateActive && isMatch12Won)
            {
                Plugin.Log.LogInfo("[Cook-Off Loop] Detected completed cook-off storyline with Jinkai defeated and celebration scene finished.");

                // 1. Clear Master Completion Gate (Flag 494) and post-contest cutscene flag (Flag 493)
                gw.event_flag[MASTER_COMPLETION_BYTE] = (byte)(gw.event_flag[MASTER_COMPLETION_BYTE] & ~(FLAG_494_BIT | FLAG_493_BIT));

                // 2. Clear Match Win Flags 1-12
                gw.event_flag[MATCHES_1_TO_8_WON_BYTE] = 0;
                gw.event_flag[MATCHES_9_TO_12_WON_BYTE] = (byte)(gw.event_flag[MATCHES_9_TO_12_WON_BYTE] & 0xF0); // Clear lower 4 bits, preserve upper bits

                // 3. Clear Scheduled Match Queue Flags 1-12 and auxiliary markers
                gw.event_flag[MATCHES_1_TO_8_QUEUE_BYTE] = 0;
                gw.event_flag[MATCHES_9_TO_12_QUEUE_BYTE] = 0;

                // 4. Clear challenger waiting flags AND intermediate stage markers (bits 1, 2, 3: 0x02, 0x04, 0x08)
                if (gw.event_flag.Length > RESTAURANT_CHALLENGER_WAITING_BYTE)
                {
                    gw.event_flag[RESTAURANT_CHALLENGER_WAITING_BYTE] = (byte)(gw.event_flag[RESTAURANT_CHALLENGER_WAITING_BYTE] & ~STALE_CHALLENGER_BITS_148);
                }

                if (gw.event_flag.Length > KITCHEN_TRIGGER_BYTE)
                {
                    gw.event_flag[KITCHEN_TRIGGER_BYTE] = (byte)(gw.event_flag[KITCHEN_TRIGGER_BYTE] & ~FLAG_1062_BIT);
                }

                Plugin.Log.LogInfo("[Cook-Off Loop] Successfully reset cook-off match progression back to Match 1 (Ky Yun). All recipes and seasonings preserved.");
            }
            else if (gw.event_flag[MATCHES_1_TO_8_WON_BYTE] == 0 && (gw.event_flag[MATCHES_9_TO_12_WON_BYTE] & 0x0F) == 0)
            {
                // Self-healing check: If the player has not yet won Match 1, ensure no stale intermediate flags linger from a previous run
                if (gw.event_flag.Length > RESTAURANT_CHALLENGER_WAITING_BYTE &&
                    (gw.event_flag[RESTAURANT_CHALLENGER_WAITING_BYTE] & 0x0C) != 0)
                {
                    Plugin.Log.LogInfo("[Cook-Off Loop] Self-healing: Purged lingering intermediate challenger flags on byte 148.");
                    gw.event_flag[RESTAURANT_CHALLENGER_WAITING_BYTE] = (byte)(gw.event_flag[RESTAURANT_CHALLENGER_WAITING_BYTE] & ~0x0C);
                }

                // If byte 152 has fragmented or extraneous bits beyond Match 1 (0x01)
                if (gw.event_flag[MATCHES_1_TO_8_QUEUE_BYTE] > 1)
                {
                    Plugin.Log.LogInfo($"[Cook-Off Loop] Self-healing: Corrected fragmented match 1 queue flag 0x{gw.event_flag[MATCHES_1_TO_8_QUEUE_BYTE]:X2} -> 0x01.");
                    gw.event_flag[MATCHES_1_TO_8_QUEUE_BYTE] = 1;
                    gw.event_flag[MATCHES_9_TO_12_QUEUE_BYTE] = 0;
                }
            }

            // If entering arena (vk30) or restaurant (vk05), synchronize the match queue to prevent any desync
            if (currentMapId.StartsWith("vk30", StringComparison.OrdinalIgnoreCase) ||
                currentMapId.StartsWith("vk05", StringComparison.OrdinalIgnoreCase))
            {
                int match = GetCurrentScheduledMatch();
                if (match > 0)
                {
                    SynchronizeMatchQueue(match);
                }
            }
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[Cook-Off Loop] Error checking/resetting cook-off flags: {ex}");
        }
    }

    /// <summary>
    /// Removes the 30-60 minute active gameplay cooldown between cook-off matches.
    /// In vanilla Suikoden II:
    /// - Timer 8 (event_time[8][1]) controls match scheduling in the castle hall (vk06).
    /// - Timer 10 (event_time[10][1]) controls the restaurant challenger readiness check in vk05.
    /// - Timer 1 (event_time[1][1]) controls dialogue readiness.
    /// </summary>
    public static void ApplyCooldownReduction()
    {
        if (!GameDetection.IsGSD2())
            return;

        if (Plugin.Config?.ReduceCookOffCooldown?.Value != true)
            return;

        try
        {
            var gw = GSD2::OldSrcBase.game_work;
            var gd = gw?.game_data;
            if (gd?.event_time == null || gd.event_time.Length <= 10)
                return;

            // Timer 8: Match scheduling queue in vk06 (30-60 min cooldown per match)
            var timer8 = gd.event_time[8];
            if (timer8 != null && timer8.Length > 1 && timer8[1] < SATURATED_TIMER_SECONDS)
            {
                timer8[1] = SATURATED_TIMER_SECONDS;
            }

            // Timer 10: Restaurant event check in vk05 & vk01 (30 min cooldown)
            var timer10 = gd.event_time[10];
            if (timer10 != null && timer10.Length > 1 && timer10[1] < SATURATED_TIMER_SECONDS)
            {
                timer10[1] = SATURATED_TIMER_SECONDS;
            }

            // Timer 1: Initial challenger event pacing
            var timer1 = gd.event_time[1];
            if (timer1 != null && timer1.Length > 1 && timer1[1] < SATURATED_TIMER_SECONDS)
            {
                timer1[1] = SATURATED_TIMER_SECONDS;
            }

            // --- CHALLENGER QUEUE SELF-HEALING & WAITING STATUS ---
            if (gw.event_flag == null || gw.event_flag.Length <= MATCHES_9_TO_12_QUEUE_BYTE)
                return;

            // Never tamper with flags while actively inside the cook-off arena (vk30)
            string currentMapId = MACHICON_OnMapInitPatch.CurrentMapId ?? "";
            if (currentMapId.StartsWith("vk30", StringComparison.OrdinalIgnoreCase))
                return;

            // Chef Hai Yo (Character ID 66, 0-indexed) must be recruited (mode 2)
            if (GSD2::G2_SYS.G2_cha_flag(2, 66) == 0)
                return;

            // If the cook-off master completion gate (Flag 494) is active, do not force challengers
            if ((gw.event_flag[MASTER_COMPLETION_BYTE] & FLAG_494_BIT) != 0)
                return;

            // Calculate victories to determine upcoming match (1..12)
            byte won1 = gw.event_flag[MATCHES_1_TO_8_WON_BYTE];
            byte won2 = (byte)(gw.event_flag[MATCHES_9_TO_12_WON_BYTE] & 0x0F);
            int wonCount = 0;
            for (int i = 0; i < 8; i++) if ((won1 & (1 << i)) != 0) wonCount++;
            for (int i = 0; i < 4; i++) if ((won2 & (1 << i)) != 0) wonCount++;

            if (wonCount >= 12)
                return;

            int targetMatch = wonCount + 1;

            // 1. Purge stale in-scene / battle / lost flags from byte 153 (bits 4..6: 0x10, 0x20, 0x40).
            // Stale bits (such as 0x20 left after an exit or loss) block arena (vk30) pre-battle cutscenes.
            gw.event_flag[MATCHES_9_TO_12_QUEUE_BYTE] = (byte)(gw.event_flag[MATCHES_9_TO_12_QUEUE_BYTE] & 0x0F);

            // 2. Synchronize queue bitmasks on flags 152 and 153 for targetMatch
            SynchronizeMatchQueue(targetMatch);

            // 3. Ensure challenger waiting flag is set on flag 148 (Bit 1 / 0x02).
            // Without this, the restaurant entrance in vk06 never triggers the match cutscene.
            if (gw.event_flag.Length > RESTAURANT_CHALLENGER_WAITING_BYTE &&
                (gw.event_flag[RESTAURANT_CHALLENGER_WAITING_BYTE] & FLAG_1185_BIT) == 0)
            {
                gw.event_flag[RESTAURANT_CHALLENGER_WAITING_BYTE] |= FLAG_1185_BIT;
                Plugin.Log.LogInfo($"[Cook-Off Loop] Challenger for Match {targetMatch} ({ChefNames[targetMatch - 1]}) is now WAITING in the restaurant (Flag 148 bit 1 set).");
            }
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[Cook-Off Loop] Error applying cooldown reduction: {ex}");
        }
    }

    /// <summary>
    /// Harmony hooks for Overlay_rbattle.rbattleinit to guarantee that the cooking minigame battle
    /// matches the cutscene challenger with 100% precision.
    /// </summary>
    [HarmonyPatch(typeof(GSD2::EventOverlayClass.Overlay_rbattle), "rbattleinit")]
    public static class OverlayRbattleInitPatch
    {
        [HarmonyPrefix]
        public static void Prefix(GSD2::EventOverlayClass.Overlay_rbattle __instance)
        {
            if (!GameDetection.IsGSD2())
                return;

            try
            {
                int match = GetCurrentScheduledMatch();
                if (match >= 1 && match <= 12)
                {
                    SynchronizeMatchQueue(match);
                }
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"[Cook-Off Loop] Error in Overlay_rbattle.rbattleinit Prefix: {ex}");
            }
        }

        [HarmonyPostfix]
        public static void Postfix(GSD2::EventOverlayClass.Overlay_rbattle __instance, GSD2::EventOverlayClass.rbattle_h.RB_WORK __result)
        {
            if (!GameDetection.IsGSD2())
                return;

            try
            {
                if (__result == null)
                    return;

                int match = GetCurrentScheduledMatch();
                if (match >= 1 && match <= 12)
                {
                    byte expectedChef = ChefTable[match - 1];
                    if (__result.battle_num != (byte)match || __result.chal_num != expectedChef)
                    {
                        Plugin.Log.LogWarning($"[Cook-Off Loop] Correcting battle desync: battle_num {__result.battle_num} -> {match}, chal_num {__result.chal_num} -> {expectedChef} ({ChefNames[match - 1]})");
                        __result.battle_num = (byte)match;
                        __result.chal_num = expectedChef;
                    }
                    else
                    {
                        Plugin.Log.LogInfo($"[Cook-Off Loop] Cooking battle successfully initialized: Match {match} against {ChefNames[match - 1]} (Chef ID {expectedChef}).");
                    }
                }
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"[Cook-Off Loop] Error in Overlay_rbattle.rbattleinit Postfix: {ex}");
            }
        }
    }
}
