extern alias GSD2;

using System;

namespace PKCore.Patches;

/// <summary>
/// Allows replaying Clive's pursuit quest from Lakewest onward after viewing/finishing
/// the Elza finale duel in Sajah Village.
///
/// Because early-game Muse and South Window are tied to early story states that no longer
/// exist late-game, this patch restarts the quest in event-agnostic territory starting at Lakewest.
///
/// When entering Lakewest (vh02 / vh10) with the Sajah finale completed:
/// 1. Clears milestone bits 2-7 on event_flag[94], preserving Bit 0 (Muse) and Bit 1 (Clive joined).
/// 2. Clears the master quest completion lockout (event_flag[89] bit 7) and temporary markers (bits 4, 5).
/// 3. Clears the Rockaxe completion marker (event_flag[59] bit 0).
/// 4. Clears the Radat tavern hostage standoff flag (event_flag[158] bit 2).
/// 5. Clears the Castle HQ infirmary cutscene completion flag (event_flag[146] bit 7).
///
/// Also includes live in-flight self-healing: if entering Rockaxe (vi01), Radat (vd19), or Castle HQ (vk04 / vk35)
/// while that step is pending, any lingering step lockout bit is immediately cleared.
///
/// Note: In Suikoden II HD Remaster, the side-quest event timer can be disabled natively
/// in the game settings (UIConfigWindow -> EventTimer), so no clock manipulation is required.
/// </summary>
public static class S2CliveQuestReplayPatch
{
    private const int CLIVE_QUEST_MILESTONE_BYTE = 94;
    private const byte FLAG_SAJAH_FINALE_BIT = 0x80; // Bit 7: Sajah finale duel completed

    private const int MASTER_LOCKOUT_BYTE = 89;
    private const byte FLAG_MASTER_LOCKOUT_BIT = 0x80; // Bit 7: Master quest completion lockout
    private const byte FLAG_FOREST_VILLAGE_TEMP_BITS = 0x30; // Bits 4 & 5: Forest Village temp markers

    private const int ROCKAXE_VISITED_BYTE = 59;
    private const byte FLAG_ROCKAXE_VISITED_BIT = 0x01; // Bit 0: Rockaxe inn cutscene completed

    private const int RADAT_STANDOFF_BYTE = 158;
    private const byte FLAG_RADAT_STANDOFF_BIT = 0x04; // Bit 2: Radat tavern hostage duel completed

    private const int INFIRMARY_SCENE_BYTE = 146;
    private const byte FLAG_INFIRMARY_SCENE_BIT = 0x80; // Bit 7: Castle HQ infirmary cutscene completed

    /// <summary>
    /// Checks map transitions and resets or heals Clive quest flags.
    /// </summary>
    public static void CheckAndResetCliveQuest(string currentMapId)
    {
        if (!GameDetection.IsGSD2())
            return;

        if (Plugin.Config?.LoopCliveQuest?.Value != true)
            return;

        if (string.IsNullOrEmpty(currentMapId))
            return;

        try
        {
            var gw = GSD2::OldSrcBase.game_work;
            if (gw == null || gw.event_flag == null || gw.event_flag.Length <= RADAT_STANDOFF_BYTE)
                return;

            byte flag94 = gw.event_flag[CLIVE_QUEST_MILESTONE_BYTE];
            byte flag89 = gw.event_flag[MASTER_LOCKOUT_BYTE];

            // 1. Lakewest Reset: Entering Lakewest (vh02 exterior/docks or vh10 interiors)
            bool isLakewest = currentMapId.StartsWith("vh02", StringComparison.OrdinalIgnoreCase) ||
                              currentMapId.StartsWith("vh10", StringComparison.OrdinalIgnoreCase);

            if (isLakewest)
            {
                bool isCompleted = (flag94 & FLAG_SAJAH_FINALE_BIT) != 0 || (flag89 & FLAG_MASTER_LOCKOUT_BIT) != 0;

                if (isCompleted)
                {
                    Plugin.Log.LogInfo("[Clive Quest Replay] Detected completed Clive quest upon entering Lakewest. Resetting quest flags back to Lakewest...");

                    // Reset milestone byte: preserve Bit 0 (Muse) and Bit 1 (Clive joined), clear bits 2..7 (Lakewest..Sajah)
                    gw.event_flag[CLIVE_QUEST_MILESTONE_BYTE] = (byte)((flag94 & 0x01) | 0x02);

                    // Clear master quest completion lockout (bit 7) and temp markers (bits 4, 5)
                    gw.event_flag[MASTER_LOCKOUT_BYTE] = (byte)(flag89 & ~(FLAG_MASTER_LOCKOUT_BIT | FLAG_FOREST_VILLAGE_TEMP_BITS));

                    // Clear Rockaxe cutscene completed flag (bit 0)
                    gw.event_flag[ROCKAXE_VISITED_BYTE] = (byte)(gw.event_flag[ROCKAXE_VISITED_BYTE] & ~FLAG_ROCKAXE_VISITED_BIT);

                    // Clear Radat tavern hostage standoff flag (bit 2)
                    gw.event_flag[RADAT_STANDOFF_BYTE] = (byte)(gw.event_flag[RADAT_STANDOFF_BYTE] & ~FLAG_RADAT_STANDOFF_BIT);

                    // Clear Castle HQ infirmary cutscene completed flag (bit 7)
                    gw.event_flag[INFIRMARY_SCENE_BYTE] = (byte)(gw.event_flag[INFIRMARY_SCENE_BYTE] & ~FLAG_INFIRMARY_SCENE_BIT);

                    Plugin.Log.LogInfo($"[Clive Quest Replay] Successfully reset Clive quest flags: " +
                                       $"event_flag[94]=0x{gw.event_flag[CLIVE_QUEST_MILESTONE_BYTE]:X2}, " +
                                       $"event_flag[89]=0x{gw.event_flag[MASTER_LOCKOUT_BYTE]:X2}, " +
                                       $"event_flag[59]=0x{gw.event_flag[ROCKAXE_VISITED_BYTE]:X2}, " +
                                       $"event_flag[158]=0x{gw.event_flag[RADAT_STANDOFF_BYTE]:X2}, " +
                                       $"event_flag[146]=0x{gw.event_flag[INFIRMARY_SCENE_BYTE]:X2}. " +
                                       $"Player can now replay the quest from Lakewest to Sajah.");
                }
                return;
            }

            // 2. Rockaxe Self-Healing: Entering Rockaxe (vi01) while on the Rockaxe quest milestone
            // Requires Forest Village done (bit 3 / 0x08) and Rockaxe not yet completed in milestone byte (bit 4 / 0x10 == 0)
            bool isRockaxe = currentMapId.StartsWith("vi01", StringComparison.OrdinalIgnoreCase);
            if (isRockaxe)
            {
                bool isRockaxePending = (flag94 & 0x08) != 0 && (flag94 & 0x10) == 0;
                if (isRockaxePending)
                {
                    bool isLockedOut = (gw.event_flag[ROCKAXE_VISITED_BYTE] & FLAG_ROCKAXE_VISITED_BIT) != 0 ||
                                       (gw.event_flag[MASTER_LOCKOUT_BYTE] & FLAG_MASTER_LOCKOUT_BIT) != 0;

                    if (isLockedOut)
                    {
                        gw.event_flag[ROCKAXE_VISITED_BYTE] = (byte)(gw.event_flag[ROCKAXE_VISITED_BYTE] & ~FLAG_ROCKAXE_VISITED_BIT);
                        gw.event_flag[MASTER_LOCKOUT_BYTE] = (byte)(gw.event_flag[MASTER_LOCKOUT_BYTE] & ~FLAG_MASTER_LOCKOUT_BIT);
                        Plugin.Log.LogInfo($"[Clive Quest Replay] Rockaxe pending: Cleared lingering lockout flags " +
                                           $"(event_flag[59] bit 0, event_flag[89] bit 7). Rockaxe cutscenes are now active!");
                    }
                }
                return;
            }

            // 3. Radat Self-Healing: Entering Radat (vd19) while on the Radat quest milestone
            // Requires Rockaxe done (bit 4 / 0x10) and Radat not yet completed in milestone byte (bit 5 / 0x20 == 0)
            bool isRadat = currentMapId.StartsWith("vd19", StringComparison.OrdinalIgnoreCase);
            if (isRadat)
            {
                bool isRadatPending = (flag94 & 0x10) != 0 && (flag94 & 0x20) == 0;
                if (isRadatPending)
                {
                    bool isLockedOut = (gw.event_flag[RADAT_STANDOFF_BYTE] & FLAG_RADAT_STANDOFF_BIT) != 0 ||
                                       (gw.event_flag[MASTER_LOCKOUT_BYTE] & FLAG_MASTER_LOCKOUT_BIT) != 0;

                    if (isLockedOut)
                    {
                        gw.event_flag[RADAT_STANDOFF_BYTE] = (byte)(gw.event_flag[RADAT_STANDOFF_BYTE] & ~FLAG_RADAT_STANDOFF_BIT);
                        gw.event_flag[MASTER_LOCKOUT_BYTE] = (byte)(gw.event_flag[MASTER_LOCKOUT_BYTE] & ~FLAG_MASTER_LOCKOUT_BIT);
                        Plugin.Log.LogInfo($"[Clive Quest Replay] Radat pending: Cleared lingering lockout flags " +
                                           $"(event_flag[158] bit 2, event_flag[89] bit 7). Radat cutscenes are now active!");
                    }

                    // Preemptively ensure the infirmary cutscene flag is clear before Radat teleports the player to Castle HQ
                    if ((gw.event_flag[INFIRMARY_SCENE_BYTE] & FLAG_INFIRMARY_SCENE_BIT) != 0)
                    {
                        gw.event_flag[INFIRMARY_SCENE_BYTE] = (byte)(gw.event_flag[INFIRMARY_SCENE_BYTE] & ~FLAG_INFIRMARY_SCENE_BIT);
                        Plugin.Log.LogInfo($"[Clive Quest Replay] Radat active: Preemptively cleared Castle Infirmary lockout flag (event_flag[146] bit 7).");
                    }
                }
                return;
            }

            // 4. Castle Infirmary Self-Healing: Entering Castle HQ living quarters (vk04 / vk35) while on the Infirmary quest milestone
            // Requires Radat done (bit 5 / 0x20) and Muse Hill not yet completed in milestone byte (bit 6 / 0x40 == 0)
            bool isCastleLivingQuarters = currentMapId.StartsWith("vk04", StringComparison.OrdinalIgnoreCase) ||
                                         currentMapId.StartsWith("vk35", StringComparison.OrdinalIgnoreCase);
            if (isCastleLivingQuarters)
            {
                bool isInfirmaryPending = (flag94 & 0x20) != 0 && (flag94 & 0x40) == 0;
                if (isInfirmaryPending)
                {
                    bool isLockedOut = (gw.event_flag[INFIRMARY_SCENE_BYTE] & FLAG_INFIRMARY_SCENE_BIT) != 0 ||
                                       (gw.event_flag[MASTER_LOCKOUT_BYTE] & FLAG_MASTER_LOCKOUT_BIT) != 0;

                    if (isLockedOut)
                    {
                        gw.event_flag[INFIRMARY_SCENE_BYTE] = (byte)(gw.event_flag[INFIRMARY_SCENE_BYTE] & ~FLAG_INFIRMARY_SCENE_BIT);
                        gw.event_flag[MASTER_LOCKOUT_BYTE] = (byte)(gw.event_flag[MASTER_LOCKOUT_BYTE] & ~FLAG_MASTER_LOCKOUT_BIT);
                        Plugin.Log.LogInfo($"[Clive Quest Replay] Castle Infirmary pending: Cleared lingering lockout flags " +
                                           $"(event_flag[146] bit 7, event_flag[89] bit 7). Castle infirmary scene is now active!");
                    }
                }
                return;
            }
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[Clive Quest Replay] Error during Clive quest check: {ex}");
        }
    }
}
