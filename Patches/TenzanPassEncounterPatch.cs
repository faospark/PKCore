extern alias GSD2;

using System;
using System.Collections.Generic;
using HarmonyLib;
using Il2CppInterop.Runtime.InteropTypes.Arrays;

namespace PKCore.Patches
{
    /// <summary>
    /// Restores the missing Chimera monster encounters in Tenzan Pass (Suikoden 2 / GSD2).
    ///
    /// Background:
    /// In the original Suikoden II PS1 release (VA11.BIN), Chimera was fully defined with stats,
    /// drops (including the rare Cyclone Rune), animations, and 3 party formations (Parties 6, 7, 8).
    /// However, due to a developer oversight, the 10-slot encounter table only referenced Parties 0 to 5,
    /// leaving Chimera inaccessible in normal gameplay.
    ///
    /// The classic community bugfix by Pyriel (tenzan.asm) restored Chimera by substituting duplicate
    /// slots 1, 3, and 6 in the 10-slot encounter table with the 3 omitted Chimera formations,
    /// giving Chimera an intended ~30% encounter rate in Tenzan Pass.
    ///
    /// The HD Remaster ported the original encounter table without fixing this bug. This patch
    /// intercepts BattleDataSetup when in Tenzan Pass (map prefix 'va11'), verifies the monster data,
    /// ensures valid battlefield position arrays are provided for multi-monster parties,
    /// and safely places the 3 Chimera party formations in slots 1, 3, and 6.
    /// </summary>
    public static class TenzanPassEncounterPatch
    {
        private static bool _loggedTenzanInfo = false;
        internal static GSD2::MONSTER_DATA _cachedMinotaur = null;
        internal static GSD2::MONSTER_DATA _cachedMagus = null;
        internal static GSD2::MONSTER_DATA _cachedChimera = null;

        public static void Initialize(Harmony harmony)
        {
            try
            {
                harmony.PatchAll(typeof(BattleDataSetupPatch));
                harmony.PatchAll(typeof(InitNewMonsterPatch));
                Plugin.Log.LogInfo("[TenzanPassEncounterPatch] Registered Tenzan Pass encounter patches successfully.");
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"[TenzanPassEncounterPatch] Failed to register patch: {ex}");
            }
        }

        public static bool IsTenzanPass(string currentMapId, GSD2::BATTLE_DATA battleData)
        {
            if (!string.IsNullOrEmpty(currentMapId) && currentMapId.StartsWith("va11", StringComparison.OrdinalIgnoreCase))
                return true;

            if (battleData != null && !string.IsNullOrEmpty(battleData.id))
            {
                if (battleData.id.IndexOf("va11", StringComparison.OrdinalIgnoreCase) >= 0 ||
                    battleData.id.IndexOf("tenzan", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return true;
                }
            }

            return false;
        }

        [HarmonyPatch(typeof(GSD2::BattleManager), "BattleDataSetup")]
        public static class BattleDataSetupPatch
        {
            [HarmonyPrefix]
            public static void Prefix(GSD2::BattleManager __instance)
            {
                try
                {
                    if (!GameDetection.IsGSD2() || Plugin.Config == null || !Plugin.Config.EnableTenzanChimeraFix.Value)
                        return;

                    var sysWork = GSD2::OldSrcBase.sys_work;
                    if (sysWork == null || sysWork.battle_data == null)
                        return;

                    var battleData = sysWork.battle_data;
                    string currentMapId = MACHICON_OnMapInitPatch.CurrentMapId ?? "";

                    if (!IsTenzanPass(currentMapId, battleData))
                        return;

                    var parties = battleData.monster_party;
                    var monsters = battleData.monster_data;

                    if (parties == null || parties.Length == 0 || monsters == null || monsters.Length == 0)
                    {
                        Plugin.Log.LogWarning("[TenzanPassEncounterPatch] Encountered Tenzan Pass battle data with empty parties or monsters.");
                        return;
                    }

                    // 1. Identify monsters in Tenzan Pass monster_data
                    int chimeraIndex = -1;
                    int minotaurIndex = -1;
                    int magusIndex = -1;

                    for (int i = 0; i < monsters.Length; i++)
                    {
                        var m = monsters[i];
                        if (m == null) continue;
                        string mId = m.id ?? "";

                        // In HD Remaster, monsters are named va11_00_00 (Minotaur), va11_00_01 (Magus), va11_00_02 (Chimera)
                        if (mId.EndsWith("_02", StringComparison.OrdinalIgnoreCase) ||
                            mId.EndsWith("02", StringComparison.OrdinalIgnoreCase) ||
                            mId.IndexOf("cim", StringComparison.OrdinalIgnoreCase) >= 0 ||
                            mId.IndexOf("chimera", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            chimeraIndex = i;
                        }
                        else if (mId.EndsWith("_00", StringComparison.OrdinalIgnoreCase) ||
                                 mId.EndsWith("00", StringComparison.OrdinalIgnoreCase) ||
                                 mId.IndexOf("mino", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                 mId.IndexOf("mao", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            minotaurIndex = i;
                        }
                        else if (mId.EndsWith("_01", StringComparison.OrdinalIgnoreCase) ||
                                 mId.EndsWith("01", StringComparison.OrdinalIgnoreCase) ||
                                 mId.IndexOf("mag", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            magusIndex = i;
                        }
                    }

                    // Fallback to standard 3-monster layout (1 = Minotaurus, 2 = Magus, 3 = Chimera or 0, 1, 2)
                    if (chimeraIndex == -1 && monsters.Length >= 4)
                    {
                        minotaurIndex = 1;
                        magusIndex = 2;
                        chimeraIndex = 3;
                    }
                    else if (chimeraIndex == -1 && monsters.Length >= 3)
                    {
                        minotaurIndex = 0;
                        magusIndex = 1;
                        chimeraIndex = 2;
                    }

                    if (chimeraIndex == -1)
                    {
                        Plugin.Log.LogWarning("[TenzanPassEncounterPatch] Could not identify Chimera in monster_data.");
                        return;
                    }

                    // 2. Expand monster_data to 4 slots (1-based indexing)
                    // In Suikoden 2's BattleManager.InitNewMonster:
                    //   target_monster = battle_work.monster_data[monster_id];
                    // Because monster_id == 0 means empty slot, authentic monster IDs are:
                    //   1 = Minotaurus, 2 = Magus, 3 = Chimera
                    // In the HD Remaster, the porting team packed the 3 monsters into a 3-element array (indices 0..2).
                    // When Chimera (MID 3) is spawned, battle_work.monster_data[3] throws IndexOutOfRangeException!
                    // To fix this, we ensure monster_data has 4 slots (0: dummy, 1: Minotaur, 2: Magus, 3: Chimera).
                    var minotaurObj = (minotaurIndex >= 0 && minotaurIndex < monsters.Length) ? monsters[minotaurIndex] : monsters[0];
                    var magusObj = (magusIndex >= 0 && magusIndex < monsters.Length) ? monsters[magusIndex] : (monsters.Length > 1 ? monsters[1] : monsters[0]);
                    var chimeraObj = (chimeraIndex >= 0 && chimeraIndex < monsters.Length) ? monsters[chimeraIndex] : (monsters.Length > 2 ? monsters[2] : monsters[0]);

                    _cachedMinotaur = minotaurObj;
                    _cachedMagus = magusObj;
                    _cachedChimera = chimeraObj;

                    if (monsters.Length < 4 || monsters[3] == null)
                    {
                        var expanded = new Il2CppReferenceArray<GSD2::MONSTER_DATA>(Math.Max(4, monsters.Length));
                        for (int i = 0; i < monsters.Length; i++)
                            expanded[i] = monsters[i];

                        expanded[0] = minotaurObj; // dummy/placeholder
                        expanded[1] = minotaurObj; // MID 1 = Minotaurus
                        expanded[2] = magusObj;    // MID 2 = Magus
                        expanded[3] = chimeraObj;  // MID 3 = Chimera

                        battleData.monster_data = expanded;
                        monsters = expanded;
                        Plugin.Log.LogInfo($"[TenzanPassEncounterPatch] Expanded battleData.monster_data to {expanded.Length} slots (1: Minotaur, 2: Magus, 3: Chimera) to support Chimera MID 3.");
                    }

                    sbyte minotaurMid = 1;
                    sbyte magusMid = 2;
                    sbyte chimeraMid = 3;

                    // 3. Extract authentic battlefield monster position templates from untouched parties before modifying
                    short[] pos1Monster = null;
                    short[] pos2Monster = null;
                    short[] pos3Monster = null;

                    for (int i = 0; i < parties.Length; i++)
                    {
                        // Slots 1, 3, and 6 will be modified, so prefer templates from other slots
                        var p = parties[i];
                        if (p == null || p.data == null || p.data.monster_position == null) continue;
                        var pos = p.data.monster_position;

                        if (p.monster_kazu == 1 && pos.Length >= 3 && pos1Monster == null)
                        {
                            pos1Monster = new short[pos.Length];
                            for (int k = 0; k < pos.Length; k++) pos1Monster[k] = pos[k];
                        }
                        else if (p.monster_kazu == 2 && pos.Length >= 6 && pos2Monster == null)
                        {
                            pos2Monster = new short[pos.Length];
                            for (int k = 0; k < pos.Length; k++) pos2Monster[k] = pos[k];
                        }
                        else if (p.monster_kazu == 3 && pos.Length >= 9 && pos3Monster == null)
                        {
                            pos3Monster = new short[pos.Length];
                            for (int k = 0; k < pos.Length; k++) pos3Monster[k] = pos[k];
                        }
                    }

                    // 4. Check if Chimera is already present in any encounter party
                    bool chimeraAlreadyInTable = false;
                    for (int i = 0; i < parties.Length; i++)
                    {
                        var p = parties[i];
                        if (p == null || p.monster_id == null) continue;
                        for (int s = 0; s < p.monster_id.Length; s++)
                        {
                            if (p.monster_id[s] == chimeraMid)
                            {
                                chimeraAlreadyInTable = true;
                                break;
                            }
                        }
                        if (chimeraAlreadyInTable) break;
                    }

                    if (!chimeraAlreadyInTable)
                    {
                        Plugin.Log.LogInfo($"[TenzanPassEncounterPatch] Restoring missing Chimera encounters in Tenzan Pass (Parties: {parties.Length}, Chimera MID: {chimeraMid}, Minotaur MID: {minotaurMid}, Magus MID: {magusMid}).");

                        // Apply Pyriel's bugfix layout to the 10 encounter slots:
                        // Replace duplicate slots 1, 3, and 6 with the 3 Chimera formations.
                        if (parties.Length >= 7)
                        {
                            // Slot 1: Chimera Solo (1 Chimera)
                            ConfigurePartyFormation(parties[1], 1, chimeraMid, 0, 0, pos1Monster);

                            // Slot 3: Chimera + Magus x 2 (1 Chimera, 2 Magus)
                            ConfigurePartyFormation(parties[3], 3, chimeraMid, magusMid, magusMid, pos3Monster);

                            // Slot 6: Chimera + Minotaurus (1 Chimera, 1 Minotaurus)
                            ConfigurePartyFormation(parties[6], 2, chimeraMid, minotaurMid, 0, pos2Monster);

                            Plugin.Log.LogInfo("[TenzanPassEncounterPatch] Restored 3 Chimera parties into encounter slots 1, 3, and 6 (30% spawn rate) with complete position arrays.");
                        }
                        else
                        {
                            // If table is smaller than 7, configure slot 1 as Chimera
                            ConfigurePartyFormation(parties[parties.Length > 1 ? 1 : 0], 1, chimeraMid, 0, 0, pos1Monster);
                            Plugin.Log.LogInfo("[TenzanPassEncounterPatch] Restored Chimera party into slot 1.");
                        }
                    }
                    else if (!_loggedTenzanInfo)
                    {
                        _loggedTenzanInfo = true;
                        Plugin.Log.LogInfo("[TenzanPassEncounterPatch] Chimera encounters already confirmed active in Tenzan Pass.");
                    }
                }
                catch (Exception ex)
                {
                    Plugin.Log.LogError($"[TenzanPassEncounterPatch] Prefix error: {ex}");
                }
            }

            [HarmonyPostfix]
            public static void Postfix(GSD2::BattleManager __instance)
            {
                try
                {
                    if (!GameDetection.IsGSD2() || Plugin.Config == null || !Plugin.Config.EnableTenzanChimeraFix.Value)
                        return;

                    if (__instance == null || __instance.battle_work == null)
                        return;

                    string currentMapId = MACHICON_OnMapInitPatch.CurrentMapId ?? "";
                    var battleData = __instance.battle_work.battle_data ?? GSD2::OldSrcBase.sys_work?.battle_data;

                    if (!IsTenzanPass(currentMapId, battleData))
                        return;

                    // Crucial safety reinforcement: Ensure battle_work.monster_data has at least 4 slots
                    // so InitNewMonster never throws IndexOutOfRangeException on monster_id = 3
                    var bwMonsters = __instance.battle_work.monster_data;
                    var srcMonsters = battleData?.monster_data;
                    if (bwMonsters == null || bwMonsters.Length < 4)
                    {
                        var bwExpanded = new Il2CppReferenceArray<GSD2::MONSTER_DATA>(4);
                        if (bwMonsters != null)
                        {
                            for (int i = 0; i < bwMonsters.Length && i < 4; i++)
                                bwExpanded[i] = bwMonsters[i];
                        }
                        if (srcMonsters != null && srcMonsters.Length >= 4)
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                if (bwExpanded[i] == null)
                                    bwExpanded[i] = srcMonsters[i];
                            }
                        }
                        __instance.battle_work.monster_data = bwExpanded;
                        Plugin.Log.LogInfo("[TenzanPassEncounterPatch] Reinforced battle_work.monster_data to 4 slots in Postfix.");
                    }

                    var parties = battleData?.monster_party;

                    // Support Debug / Force Chimera Encounter testing
                    if (Plugin.Config.ForceTenzanChimeraEncounter.Value && parties != null && parties.Length > 1)
                    {
                        // Pick randomly between the 3 restored Chimera slots (1, 3, 6)
                        int[] chimeraSlots = parties.Length >= 7 ? new[] { 1, 3, 6 } : new[] { 1 };
                        int chosenSlot = chimeraSlots[UnityEngine.Random.Range(0, chimeraSlots.Length)];

                        __instance.battle_work.monster_party_data = parties[chosenSlot];
                        __instance.battle_work.monster_party_index = chosenSlot + 1;

                        Plugin.Log.LogInfo($"[TenzanPassEncounterPatch] ForceTenzanChimeraEncounter active: Forced battle to Chimera slot {chosenSlot}.");
                    }

                    var selectedParty = __instance.battle_work.monster_party_data;
                    int partyIndex = __instance.battle_work.monster_party_index;

                    if (selectedParty != null)
                    {
                        string formationInfo = "";
                        if (selectedParty.monster_id != null)
                        {
                            for (int i = 0; i < selectedParty.monster_id.Length; i++)
                            {
                                sbyte mid = selectedParty.monster_id[i];
                                if (mid != 0)
                                    formationInfo += $"[Slot {i}: ID {mid}] ";
                            }
                        }
                        int posCount = selectedParty.data?.monster_position?.Length ?? 0;
                        Plugin.Log.LogInfo($"[TenzanPassEncounterPatch] Tenzan Battle Initialized -> Party #{partyIndex} (Monsters: {selectedParty.monster_kazu}, PositionShorts: {posCount}): {formationInfo}");
                    }
                }
                catch (Exception ex)
                {
                    Plugin.Log.LogError($"[TenzanPassEncounterPatch] Postfix error: {ex}");
                }
            }

            private static void ConfigurePartyFormation(
                GSD2::MONSTER_PARTY_DATA party,
                int count,
                sbyte monster1,
                sbyte monster2,
                sbyte monster3,
                short[] positionTemplate)
            {
                if (party == null) return;

                party.monster_kazu = count;

                if (party.monster_id == null || party.monster_id.Length < 6)
                {
                    party.monster_id = new Il2CppStructArray<sbyte>(6);
                }
                party.monster_id[0] = monster1;
                party.monster_id[1] = monster2;
                party.monster_id[2] = monster3;
                party.monster_id[3] = 0;
                party.monster_id[4] = 0;
                party.monster_id[5] = 0;

                // In the HD Remaster engine, BattleManager.MonsterInit reads party.monster_code (offset 0x30)
                // and passes it as monster_id to InitNewMonster. Therefore, monster_code MUST contain the
                // monster_data array index (1 = Minotaur, 2 = Magus, 3 = Chimera), NOT the legacy PS1 MF_ constants.
                if (party.monster_code == null || party.monster_code.Length < 6)
                {
                    party.monster_code = new Il2CppStructArray<sbyte>(6);
                }
                party.monster_code[0] = monster1;
                party.monster_code[1] = monster2;
                party.monster_code[2] = monster3;
                party.monster_code[3] = 0;
                party.monster_code[4] = 0;
                party.monster_code[5] = 0;

                if (party.data == null)
                {
                    party.data = new GSD2::MONSTER_PARTY_SUB_DATA();
                }

                // Crucial fix: The engine's BattleManager.InitNewMonster accesses party.data.monster_position
                // at (position - 1) * 3 for each monster in the party. If monster_position is smaller than
                // count * 3, an IndexOutOfRangeException crashes the battle initialization coroutine,
                // leaving the screen black and hanging the game indefinitely.
                short[] coords;
                if (positionTemplate != null && positionTemplate.Length >= count * 3)
                {
                    coords = positionTemplate;
                }
                else
                {
                    // Safe canonical battlefield positions for Suikoden 2 (3 shorts per monster: X, Y, Z)
                    coords = count switch
                    {
                        1 => new short[] { 0, 0, 0 },
                        2 => new short[] { 0, -35, 0, 0, 35, 0 },
                        3 => new short[] { 25, 0, 0, -25, -40, 0, -25, 40, 0 },
                        _ => new short[count * 3]
                    };
                }

                int requiredShorts = Math.Max(count * 3, coords.Length);
                var posArray = new Il2CppStructArray<short>(requiredShorts);
                for (int i = 0; i < coords.Length; i++)
                {
                    posArray[i] = coords[i];
                }
                party.data.monster_position = posArray;
            }
        }

        [HarmonyPatch(typeof(GSD2::BattleManager), "InitNewMonster")]
        public static class InitNewMonsterPatch
        {
            [HarmonyPrefix]
            public static void Prefix(GSD2::BattleManager __instance, int chara_no, ref int monster_id, int position)
            {
                try
                {
                    if (!GameDetection.IsGSD2() || Plugin.Config == null || !Plugin.Config.EnableTenzanChimeraFix.Value)
                        return;

                    if (__instance == null || __instance.battle_work == null)
                        return;

                    string currentMapId = MACHICON_OnMapInitPatch.CurrentMapId ?? "";
                    var battleData = __instance.battle_work.battle_data ?? GSD2::OldSrcBase.sys_work?.battle_data;

                    if (!IsTenzanPass(currentMapId, battleData))
                        return;

                    // Remap negative/macro values if any slipped through from legacy code
                    if (monster_id == -79 || monster_id == 177 || (sbyte)monster_id == (sbyte)GSD2::b_read_h.MF_CIM_0)
                    {
                        Plugin.Log.LogInfo($"[TenzanPassEncounterPatch] InitNewMonster: Sanitizing chimera monster_id {monster_id} -> 3");
                        monster_id = 3;
                    }
                    else if (monster_id == (sbyte)GSD2::b_read_h.MF_MAG_0)
                    {
                        Plugin.Log.LogInfo($"[TenzanPassEncounterPatch] InitNewMonster: Sanitizing magus monster_id {monster_id} -> 2");
                        monster_id = 2;
                    }
                    else if (monster_id == (sbyte)GSD2::b_read_h.MF_MAO_0)
                    {
                        Plugin.Log.LogInfo($"[TenzanPassEncounterPatch] InitNewMonster: Sanitizing minotaur monster_id {monster_id} -> 1");
                        monster_id = 1;
                    }

                    var bw = __instance.battle_work;

                    Plugin.Log.LogInfo($"[TenzanPassEncounterPatch] InitNewMonster Prefix: chara_no={chara_no}, monster_id={monster_id}, position={position}, mdLen={bw.monster_data?.Length}, posLen={bw.monster_position?.Length}");

                    // 1. Guard against monster_data array bounds (InitNewMonster checks battle_work.monster_data.Length <= monster_id)
                    bool needsMdExpand = false;
                    if (bw.monster_data == null)
                    {
                        needsMdExpand = true;
                    }
                    else if (monster_id < 0 || monster_id >= bw.monster_data.Length)
                    {
                        needsMdExpand = true;
                    }
                    else if (bw.monster_data[monster_id] == null)
                    {
                        needsMdExpand = true;
                    }

                    if (needsMdExpand)
                    {
                        int targetSize = Math.Max(Math.Max(monster_id + 1, 4), bw.monster_data != null ? bw.monster_data.Length : 4);
                        var newArr = new Il2CppReferenceArray<GSD2::MONSTER_DATA>(targetSize);
                        if (bw.monster_data != null)
                        {
                            for (int i = 0; i < bw.monster_data.Length && i < targetSize; i++)
                                newArr[i] = bw.monster_data[i];
                        }
                        if (_cachedMinotaur != null)
                        {
                            newArr[0] = _cachedMinotaur;
                            if (newArr.Length > 1 && newArr[1] == null) newArr[1] = _cachedMinotaur;
                        }
                        if (_cachedMagus != null && newArr.Length > 2 && newArr[2] == null)
                        {
                            newArr[2] = _cachedMagus;
                        }
                        if (_cachedChimera != null && newArr.Length > 3 && newArr[3] == null)
                        {
                            newArr[3] = _cachedChimera;
                        }
                        bw.monster_data = newArr;
                        Plugin.Log.LogInfo($"[TenzanPassEncounterPatch] Dynamically protected InitNewMonster: expanded monster_data to length {targetSize} for monster_id {monster_id}.");
                    }

                    // 2. Guard against monster_position array bounds (position is 1-based, uses position * 3)
                    int requiredShorts = Math.Max(0, position) * 3;
                    if (bw.monster_position == null || bw.monster_position.Length < requiredShorts)
                    {
                        int targetPosSize = Math.Max(18, requiredShorts);
                        var newPos = new Il2CppStructArray<short>(targetPosSize);
                        if (bw.monster_position != null)
                        {
                            for (int i = 0; i < bw.monster_position.Length && i < targetPosSize; i++)
                                newPos[i] = bw.monster_position[i];
                        }
                        bw.monster_position = newPos;
                        Plugin.Log.LogInfo($"[TenzanPassEncounterPatch] Dynamically protected InitNewMonster: expanded monster_position to {targetPosSize} shorts for position {position}.");
                    }
                }
                catch (Exception ex)
                {
                    Plugin.Log.LogError($"[TenzanPassEncounterPatch] InitNewMonster Prefix error: {ex}");
                }
            }

            [HarmonyPostfix]
            public static void Postfix(GSD2::BattleManager __instance, int chara_no, int monster_id, int position)
            {
                try
                {
                    if (__instance?.battle_work?.b_chara != null && chara_no >= 0 && chara_no < __instance.battle_work.b_chara.Length)
                    {
                        var chara = __instance.battle_work.b_chara[chara_no];
                        Plugin.Log.LogInfo($"[TenzanPassEncounterPatch] InitNewMonster Postfix: chara_no={chara_no} initialized -> {(chara != null ? "SUCCESS" : "NULL!")}");
                    }
                }
                catch (Exception ex)
                {
                    Plugin.Log.LogError($"[TenzanPassEncounterPatch] InitNewMonster Postfix error: {ex}");
                }
            }
        }
    }
}
