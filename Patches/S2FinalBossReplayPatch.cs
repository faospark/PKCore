extern alias GSD2;

using System;
using HarmonyLib;

namespace PKCore.Patches;

/// <summary>
/// Allows replaying the complete L'Renouille Final Boss Gauntlet in Suikoden II:
/// 1. Lucia & Karaya Vanguard 6v6 Boss Battle in the 2F Keep (vj02)
/// 2. General Han Cunningham 1v1 Duel at the Outer Fortress Gates (vj01)
/// 3. Generals Seed & Culgan 6v2 Boss Battle in the Sanctum Hallway (vj07)
/// 4. Silver Beast Rune / Golden Hydra Final Boss in the Inner Sanctum (vj08)
///
/// When entering L'Renouille (vj01) after defeating the Beast Rune (Story Flag 143 Bit 0 or Map Flag 98 Bit 0),
/// or on-demand via the ResetGauntletOnNextEntry config toggle:
/// - Clears Beast Rune defeat bits (event_flag[143] bit 0, event_flag[98] bit 0)
/// - Clears Seed & Culgan defeat bits and resets door (event_flag[96] bits 2 and 3; ensures bit 1 is set)
/// - Clears Han Cunningham defeat bits and resets gate sequence (event_flag[220] bits 0 and 1, event_flag[222] = 0, event_flag[223] bit 0)
/// - Clears Lucia defeat bit (event_flag[220] bit 6)
/// - Preserves L'Renouille assault states (event_flag[95] bit 7, event_flag[98] bit 7)
/// </summary>
public static class S2FinalBossReplayPatch
{
    // Byte 143: Global Story Flag (Post-final-boss epilogue)
    public const int FLAG_BYTE_STORY_143 = 143;
    public const byte FLAG_BEAST_RUNE_DEFEATED_BIT = 0x01; // Bit 0: Beast Rune defeated globally
    public const byte FLAG_EPILOGUE_COMPLETE_BIT = 0x40;   // Bit 6: Epilogue / ending complete (0xE2 vs 0xA2)

    // Byte 134 & 144: Castle wake-up / ending progression flags (vk16_00)
    public const int FLAG_BYTE_ENDING_134 = 134;
    public const byte FLAG_ENDING_134_RESET_MASK = 0x1B;   // Bits 0,1,3,4 (0x1B -> 0x00)

    public const int FLAG_BYTE_ENDING_144 = 144;
    public const byte FLAG_ENDING_144_RESET_MASK = 0x14;   // Bits 2,4 (0x10 -> 0x00)

    // Byte 98: vj08 Beast Rune defeat marker & assault state
    public const int FLAG_BYTE_BEAST_RUNE_98 = 98;
    public const byte FLAG_BEAST_RUNE_SANCTUM_BIT = 0x01;  // Bit 0: Beast Rune defeated in vj08
    public const byte FLAG_LRENOUILLE_ASSAULT_98_BIT = 0x80; // Bit 7: Assault active

    // Byte 96: vj07 Seed & Culgan and Sanctum Gate
    public const int FLAG_BYTE_SANCTUM_96 = 96;
    public const byte FLAG_SANCTUM_PROGRESS_MASK = 0x0F;    // Bits 0-3: Keep/Sanctum gate & Seed/Culgan progression (0xBF -> 0xB0)

    // Byte 220: L'Renouille encounter state bits (Lucia, Han, Beast Rune post-battle)
    public const int FLAG_BYTE_LRENOUILLE_220 = 220;
    public const byte FLAG_LRENOUILLE_220_RESET_MASK = 0x7B; // Bits 0,1,3,4,5,6 (0x3B -> 0x00)

    // Byte 221: L'Renouille vanguard / outer gate progression bits
    public const int FLAG_BYTE_LRENOUILLE_221 = 221;
    public const byte FLAG_LRENOUILLE_221_RESET_MASK = 0x90; // Bits 4,7 (0x90 -> 0x00)

    // Byte 222 & 223: Outer Gate Cutscene and sequence flags
    public const int FLAG_BYTE_OUTER_GATE_222 = 222;      // All 8 bits track assault cutscene segments
    public const int FLAG_BYTE_OUTER_GATE_223 = 223;
    public const byte FLAG_GATE_SEQ_MASK = 0x3D;          // Bits 0,2,3,4,5: Outer gate / Han sequence (0x3C -> 0x00)

    // Byte 225: L'Renouille inner boss completion bits
    public const int FLAG_BYTE_LRENOUILLE_225 = 225;
    public const byte FLAG_LRENOUILLE_225_RESET_MASK = 0x05; // Bits 0,2 (0x05 -> 0x00)

    // Byte 95: L'Renouille assault active state
    public const int FLAG_BYTE_ASSAULT_95 = 95;
    public const byte FLAG_LRENOUILLE_ASSAULT_95_BIT = 0x80; // Bit 7: Assault active

    /// <summary>
    /// Checks map transitions and resets the final boss gauntlet if appropriate.
    /// Called directly in MachiLoader_Load_Patch.Prefix and MACHICON_OnMapInitPatch.Postfix.
    /// </summary>
    public static void CheckAndResetFinalBoss(string currentMapId, string fromMapId = null)
    {
        if (!GameDetection.IsGSD2())
            return;

        if (string.IsNullOrEmpty(currentMapId))
            return;

        try
        {
            var gw = GSD2::OldSrcBase.game_work;
            if (gw == null || gw.event_flag == null || gw.event_flag.Length <= FLAG_BYTE_LRENOUILLE_225)
                return;

            bool isFinalBossDefeated = (gw.event_flag[FLAG_BYTE_STORY_143] & FLAG_BEAST_RUNE_DEFEATED_BIT) != 0 ||
                                       (gw.event_flag[FLAG_BYTE_BEAST_RUNE_98] & FLAG_BEAST_RUNE_SANCTUM_BIT) != 0;

            // L'Renouille Final Boss Gauntlet Replay:
            bool isLRenouilleMap = currentMapId.StartsWith("vj", StringComparison.OrdinalIgnoreCase);
            if (!isLRenouilleMap)
                return;

            bool isOuterGate = currentMapId.StartsWith("vj01", StringComparison.OrdinalIgnoreCase);
            bool comingFromInsideLRenouille = !string.IsNullOrEmpty(fromMapId) &&
                                              fromMapId.StartsWith("vj", StringComparison.OrdinalIgnoreCase);
            bool forceReset = Plugin.Config?.ResetGauntletOnNextEntry?.Value == true;
            bool loopEnabled = Plugin.Config?.LoopFinalBossGauntlet?.Value == true;

            // Trigger reset if forced, OR if entering the outer gates from outside L'Renouille (not escaping from vj02->vj01) with the final boss already defeated
            if (forceReset || (isOuterGate && !comingFromInsideLRenouille && loopEnabled && isFinalBossDefeated))
            {
                string reason = forceReset ? "Forced via config (ResetGauntletOnNextEntry)" : "Post-game outer gate entry";
                Plugin.Log.LogInfo($"[Final Boss Replay] Triggering full L'Renouille gauntlet reset ({reason}). Current map: {currentMapId}");

                ResetGauntlet(gw, true);

                if (forceReset && Plugin.Config?.ResetGauntletOnNextEntry != null)
                {
                    Plugin.Config.ResetGauntletOnNextEntry.Value = false;
                }
            }
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[Final Boss Replay] Error during final boss check: {ex}");
        }
    }

    /// <summary>
    /// Resets all 4 stages of the L'Renouille final battle gauntlet.
    /// </summary>
    public static void ResetGauntlet(GSD2::GAME_WORK gw, bool logDetails = true)
    {
        if (gw == null || gw.event_flag == null)
            return;

        // Stage 4: Reset Beast Rune final boss & epilogue/ending completion flags
        gw.event_flag[FLAG_BYTE_STORY_143] = (byte)(gw.event_flag[FLAG_BYTE_STORY_143] & ~(FLAG_BEAST_RUNE_DEFEATED_BIT | FLAG_EPILOGUE_COMPLETE_BIT));
        gw.event_flag[FLAG_BYTE_ENDING_134] = (byte)(gw.event_flag[FLAG_BYTE_ENDING_134] & ~FLAG_ENDING_134_RESET_MASK);
        gw.event_flag[FLAG_BYTE_ENDING_144] = (byte)(gw.event_flag[FLAG_BYTE_ENDING_144] & ~FLAG_ENDING_144_RESET_MASK);
        gw.event_flag[FLAG_BYTE_BEAST_RUNE_98] = (byte)(gw.event_flag[FLAG_BYTE_BEAST_RUNE_98] & ~FLAG_BEAST_RUNE_SANCTUM_BIT);

        // Stage 3: Reset Generals Seed & Culgan and Sanctum Door (0xBF -> 0xB0)
        gw.event_flag[FLAG_BYTE_SANCTUM_96] = (byte)(gw.event_flag[FLAG_BYTE_SANCTUM_96] & ~FLAG_SANCTUM_PROGRESS_MASK);

        // Stage 1 & 2: Reset Lucia, General Han Cunningham, and Outer Gate cutscenes
        gw.event_flag[FLAG_BYTE_LRENOUILLE_220] = (byte)(gw.event_flag[FLAG_BYTE_LRENOUILLE_220] & ~FLAG_LRENOUILLE_220_RESET_MASK);
        gw.event_flag[FLAG_BYTE_LRENOUILLE_221] = (byte)(gw.event_flag[FLAG_BYTE_LRENOUILLE_221] & ~FLAG_LRENOUILLE_221_RESET_MASK);
        gw.event_flag[FLAG_BYTE_OUTER_GATE_222] = 0x00;
        gw.event_flag[FLAG_BYTE_OUTER_GATE_223] = (byte)(gw.event_flag[FLAG_BYTE_OUTER_GATE_223] & ~FLAG_GATE_SEQ_MASK);
        gw.event_flag[FLAG_BYTE_LRENOUILLE_225] = (byte)(gw.event_flag[FLAG_BYTE_LRENOUILLE_225] & ~FLAG_LRENOUILLE_225_RESET_MASK);

        // Ensure fortress assault states remain active
        gw.event_flag[FLAG_BYTE_ASSAULT_95] = (byte)(gw.event_flag[FLAG_BYTE_ASSAULT_95] | FLAG_LRENOUILLE_ASSAULT_95_BIT);
        gw.event_flag[FLAG_BYTE_BEAST_RUNE_98] = (byte)(gw.event_flag[FLAG_BYTE_BEAST_RUNE_98] | FLAG_LRENOUILLE_ASSAULT_98_BIT);

        if (logDetails)
        {
            Plugin.Log.LogInfo($"[Final Boss Replay] Reset complete: " +
                               $"event_flag[143]=0x{gw.event_flag[FLAG_BYTE_STORY_143]:X2}, " +
                               $"event_flag[98]=0x{gw.event_flag[FLAG_BYTE_BEAST_RUNE_98]:X2}, " +
                               $"event_flag[96]=0x{gw.event_flag[FLAG_BYTE_SANCTUM_96]:X2}, " +
                               $"event_flag[220]=0x{gw.event_flag[FLAG_BYTE_LRENOUILLE_220]:X2}, " +
                               $"event_flag[221]=0x{gw.event_flag[FLAG_BYTE_LRENOUILLE_221]:X2}, " +
                               $"event_flag[222]=0x{gw.event_flag[FLAG_BYTE_OUTER_GATE_222]:X2}, " +
                               $"event_flag[223]=0x{gw.event_flag[FLAG_BYTE_OUTER_GATE_223]:X2}, " +
                               $"event_flag[225]=0x{gw.event_flag[FLAG_BYTE_LRENOUILLE_225]:X2}, " +
                               $"event_flag[95]=0x{gw.event_flag[FLAG_BYTE_ASSAULT_95]:X2}.");
        }
    }
}
