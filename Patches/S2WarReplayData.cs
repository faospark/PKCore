#nullable enable
extern alias GSD2;

using System;
using System.Collections.Generic;

namespace PKCore.Patches;

/// <summary>
/// Verified catalog of all 16 Suikoden II War Battles (w_dat_1..16) with map IDs,
/// roster compositions, authentic CheckSyouhai win/loss rules, and story unlock flags.
/// </summary>
public static class S2WarReplayData
{
    public sealed class WarBattleEntry
    {
        public int WarNo { get; init; }
        public int MapNo { get; init; }
        public string Title { get; init; } = "";
        public string Region { get; init; } = "";
        public int AllyCount { get; init; }
        public int EnemyCount { get; init; }
        public string VictoryRules { get; init; } = "";
        public bool UsesCustomArmyRoster { get; init; }
        public bool IsCutsceneOnly { get; init; }
        public Func<GSD2::GAME_WORK, bool> IsUnlockedByStory { get; init; } = _ => false;
    }

    public static IReadOnlyList<WarBattleEntry> Battles { get; } = new List<WarBattleEntry>
    {
        new()
        {
            WarNo = 1, MapNo = 1,
            Title = "Defending the Mercenary Fortress",
            Region = "Mercenary Fortress (Act 1)",
            AllyCount = 4, EnemyCount = 5,
            VictoryRules = "Survive past Turn 3. Defeat if all allied units fall.",
            UsesCustomArmyRoster = false,
            IsUnlockedByStory = gw => HasFlag(gw, 0xA9, 0x40) || HasHqReached(gw)
        },
        new()
        {
            WarNo = 2, MapNo = 1,
            Title = "Second Defense of Mercenary Fortress",
            Region = "Mercenary Fortress (Act 1)",
            AllyCount = 4, EnemyCount = 12,
            VictoryRules = "Scripted battle ends when an enemy enters the fort gate (x=3..5, y=6..8) or allies fall.",
            UsesCustomArmyRoster = false,
            IsUnlockedByStory = gw => HasFlag(gw, 0xAA, 0x02) || HasHqReached(gw)
        },
        new()
        {
            WarNo = 3, MapNo = 9,
            Title = "The Defense of Muse City",
            Region = "Muse City (Act 1)",
            AllyCount = 10, EnemyCount = 8,
            VictoryRules = "Defeat Highland vanguard commander or hold past Turn 13. Defeat if all allies fall.",
            UsesCustomArmyRoster = false,
            IsUnlockedByStory = gw => HasFlag(gw, 0x0C, 0x80) || HasHqReached(gw)
        },
        new()
        {
            WarNo = 4, MapNo = 3,
            Title = "Defending Headquarters",
            Region = "Dunan Castle HQ (Act 2)",
            AllyCount = 5, EnemyCount = 7,
            VictoryRules = "Defeat Seed or survive until scripted timer triggers (>5 after flag). Lose if Riou falls.",
            UsesCustomArmyRoster = false,
            IsUnlockedByStory = gw => HasFlag(gw, 111, 0x10)
        },
        new()
        {
            WarNo = 5, MapNo = 4,
            Title = "Battle Alongside the Matilda Knights",
            Region = "Muse-Matilda Border (Act 2)",
            AllyCount = 9, EnemyCount = 7,
            VictoryRules = "Defeat Kiba or ends if all three Refugee units (slots 6-8) fall.",
            UsesCustomArmyRoster = false,
            IsUnlockedByStory = gw => HasFlag(gw, 0x10, 0x80)
        },
        new()
        {
            WarNo = 6, MapNo = 11,
            Title = "The Defense of South Window",
            Region = "Radat / South Window (Act 2)",
            AllyCount = 10, EnemyCount = 11,
            VictoryRules = "Reach Turn 9 or defeat Rowd. Lose if Riou falls.",
            UsesCustomArmyRoster = true,
            IsUnlockedByStory = gw => HasFlag(gw, 0x74, 0x20)
        },
        new()
        {
            WarNo = 7, MapNo = 5,
            Title = "Showdown with the Kibas",
            Region = "Kiba Campaign (Act 2)",
            AllyCount = 10, EnemyCount = 12,
            VictoryRules = "Defeat enemy flagship or trigger Shu's pincer maneuver timer. Lose if Riou falls.",
            UsesCustomArmyRoster = true,
            IsUnlockedByStory = gw => HasFlag(gw, 0x75, 0x08)
        },
        new()
        {
            WarNo = 8, MapNo = 11,
            Title = "The Battle to Rescue Ridley",
            Region = "Two River / Radat (Act 2)",
            AllyCount = 10, EnemyCount = 11,
            VictoryRules = "Link up adjacent to Ridley (slot 5) or watch scripted branches if Ridley/Riou falls.",
            UsesCustomArmyRoster = true,
            IsUnlockedByStory = gw => HasFlag(gw, 0x77, 0x10)
        },
        new()
        {
            WarNo = 9, MapNo = 5,
            Title = "The Final Battle with Luca",
            Region = "Luca Ambush (Act 2)",
            AllyCount = 10, EnemyCount = 11,
            VictoryRules = "Damage Yuber/flagship after ambush flag, reach Turn 21, or defeat Yuber. Lose if Riou falls.",
            UsesCustomArmyRoster = true,
            IsUnlockedByStory = gw => HasFlag(gw, 0x78, 0x10)
        },
        new()
        {
            WarNo = 10, MapNo = 7,
            Title = "The Battle to Reclaim Greenhill",
            Region = "Greenhill Campaign (Act 3)",
            AllyCount = 7, EnemyCount = 11,
            VictoryRules = "Defeat Seed or hold past Turn 14. Lose if Riou falls.",
            UsesCustomArmyRoster = true,
            IsUnlockedByStory = gw => HasFlag(gw, 127, 0x09)
        },
        new()
        {
            WarNo = 11, MapNo = 6,
            Title = "Diversion to Reclaim Greenhill",
            Region = "Greenhill Forest Route (Act 3)",
            AllyCount = 7, EnemyCount = 8,
            VictoryRules = "Defeat Lucia's unit directly. Lose if Riou falls.",
            UsesCustomArmyRoster = true,
            IsUnlockedByStory = gw => HasFlag(gw, 127, 0x09)
        },
        new()
        {
            WarNo = 12, MapNo = 2,
            Title = "The Battle to Retake Muse City",
            Region = "Muse Plains (Act 3)",
            AllyCount = 14, EnemyCount = 11,
            VictoryRules = "Break through to Muse City (x=12..13, y=8..9) or defeat Jowy. Lose if Riou falls.",
            UsesCustomArmyRoster = true,
            IsUnlockedByStory = gw => HasFlag(gw, 188, 0x10)
        },
        new()
        {
            WarNo = 13, MapNo = 8,
            Title = "The Assault on Matilda (First Wave)",
            Region = "Rockaxe / Matilda (Act 3)",
            AllyCount = 15, EnemyCount = 14,
            VictoryRules = "Hold through Turn 7 (scripted Gorudo standoff) or defeat Seed. Lose if Riou falls.",
            UsesCustomArmyRoster = true,
            IsUnlockedByStory = gw => HasFlag(gw, 131, 0x08)
        },
        new()
        {
            WarNo = 14, MapNo = 8,
            Title = "Matilda Castle Gate Confrontation",
            Region = "Rockaxe Gate (Cutscene Battle)",
            AllyCount = 15, EnemyCount = 14,
            VictoryRules = "Cutscene-only skirmish: CheckSyouhai ends immediately on Turn 1.",
            UsesCustomArmyRoster = true,
            IsCutsceneOnly = true,
            IsUnlockedByStory = gw => HasFlag(gw, 20, 0x04)
        },
        new()
        {
            WarNo = 15, MapNo = 9,
            Title = "The Conquest of Matilda (Rockaxe)",
            Region = "Rockaxe Keep (Act 3)",
            AllyCount = 15, EnemyCount = 14,
            VictoryRules = "Survive to Turn 7 or defeat Seed. Lose if Riou falls.",
            UsesCustomArmyRoster = true,
            IsUnlockedByStory = gw => HasFlag(gw, 90, 0x02)
        },
        new()
        {
            WarNo = 16, MapNo = 10,
            Title = "The Conquest of L'Renouille",
            Region = "L'Renouille Gates (Act 4)",
            AllyCount = 15, EnemyCount = 7,
            VictoryRules = "Breach L'Renouille Gate (x=11..13, y=2..4) or defeat Seed. Lose if Riou falls.",
            UsesCustomArmyRoster = true,
            // Available once Rockaxe war (15) is completed so final-act players can practice it at HQ
            IsUnlockedByStory = gw => HasFlag(gw, 90, 0x02)
        }
    };

    public static WarBattleEntry? GetByWarNo(int warNo)
    {
        for (int i = 0; i < Battles.Count; i++)
        {
            if (Battles[i].WarNo == warNo)
                return Battles[i];
        }
        return null;
    }

    public static bool IsUnlocked(WarBattleEntry entry, GSD2::GAME_WORK? gw)
    {
        if (Plugin.Config?.UnlockAllWarReplays?.Value == true)
            return true;
        if (gw == null)
            return false;
        return entry.IsUnlockedByStory(gw);
    }

    private static bool HasFlag(GSD2::GAME_WORK gw, int byteIndex, byte mask)
    {
        if (gw?.event_flag == null || byteIndex < 0 || byteIndex >= gw.event_flag.Length)
            return false;
        return (gw.event_flag[byteIndex] & mask) != 0;
    }

    private static bool HasHqReached(GSD2::GAME_WORK gw)
    {
        // Apple War Room requires base_lv >= 3; any save reaching HQ Lv3 has already passed Wars 1-3.
        return gw?.game_data != null && gw.game_data.base_lv >= 3;
    }
}
