extern alias GSD2;

using System;
using System.Collections.Generic;
using HarmonyLib;
using UnityEngine;

namespace PKCore.Patches;

/// <summary>
/// Restores unused NPC bathhouse sprites and prevents the engine crash when bathing with non-combatant recruits or convoy members in Suikoden 2.
/// Automatically fills unoccupied bath slots with recruited castle companions (e.g. Apple, Shu, Leona, Richmond, Barbara, Pilika, Teresa, etc.).
/// </summary>
public static class NPCBathVisitorPatch
{
    private static bool _initialized = false;
    public static bool IsInsideBath { get; private set; } = false;

    private static byte[] _savedPartyMembers = null;
    private static bool _isPartyModified = false;

    private static GSD2::P_GRAPH_DATA _dummyGraphData = null;

    // All canonically female characters in Suikoden 2 (Ground truth mapped from player_*.json and ckd_info)
    public static readonly HashSet<byte> FemaleCharaIds = new HashSet<byte>
    {
        // Playable / Combat females
        8,   // Tengaar (player_ten)
        12,  // Valeria (player_val / player_val_d)
        14,  // Karen (player_rol)
        18,  // Nanami (player_nan / player_nan_d)
        19,  // Eilie (player_air / player_air_d)
        20,  // Rina (player_ryn)
        23,  // Hanna (player_han)
        24,  // Millie (player_mil)
        25,  // Meg (player_kal)
        39,  // Anita (player_ani)
        41,  // Kasumi (player_kks)
        42,  // Sierra (vanilla hardcoded female)
        43,  // Ayda (player_ada)
        45,  // Sierra (player_sie / player_sie_d)
        46,  // Oulan (player_ora)
        55,  // Nina (player_nia)
        57,  // Tomo (player_stk)
        60,  // Viki (player_rye)
        68,  // Wakaba (player_lfi)
        71,  // Rulodia (player_ksd)
        73,  // Kasumi alternate (player_ksm / player_ksm_d)
        83,  // Mikumiku (player_mi2)

        // Castle Recruit / Convoy / Facility females with authentic bath sprites
        84,  // Apple (npc_84)
        85,  // Apple (player_app_d)
        91,  // Teresa Wisemail (npc_91)
        94,  // Leona (npc_94)
        96,  // Barbara (npc_96)
        97,  // Jeane (npc_97)
        98,  // Yuzu (npc_98)
        99,  // Taki (npc_99)
        100, // Pilika (npc_100)
        102, // Emilia (npc_102)
        104, // Hilda (npc_104)
        105, // Raura (npc_105)
        123, // Pilika (player_prk_d)
        124, // Pilika (player_pr2_d)
        172  // Elza (player_eri_d)
    };

    // Recruited castle female NPCs with authentic bath sprites in hp_furo_XX_atlas
    public static readonly byte[] FemaleCastleNPCs = new byte[]
    {
        84,  // Apple
        85,  // Apple (convoy)
        91,  // Teresa Wisemail
        94,  // Leona
        96,  // Barbara
        97,  // Jeane
        98,  // Yuzu
        99,  // Taki
        100, // Pilika
        102, // Emilia
        104, // Hilda
        105, // Raura
        123  // Pilika
    };

    // Recruited castle male NPCs with authentic bath sprites in hp_furo_XX_atlas
    public static readonly byte[] MaleCastleNPCs = new byte[]
    {
        86,  // Hauser / General Kiba (npc)
        87,  // Kiba (player_kib_d)
        88,  // Fitcher (player_fic_d)
        89,  // Jess
        90,  // Gilbert
        92,  // Marlowe (npc)
        93,  // Richmond
        95,  // Alex (player_alx_d) / Hai Yo
        101, // Templeton (player_tel_d)
        103, // Alex
        107, // Adlai
        108, // Sansuke
        109, // Tetsu
        110, // Maximillian
        120, // Marlowe (player_mrl_d)
        125, // Grenmeyer (player_gre_d)
        143  // Klaus (player_kru_d)
    };

    public static void Initialize(Harmony harmony)
    {
        if (_initialized) return;

        try
        {
            harmony.PatchAll(typeof(NPCBathVisitorPatch));
            _initialized = true;
            Plugin.Log.LogInfo("[NPCBathVisitorPatch] Successfully initialized Suikoden 2 NPC Bath Sprites & Castle Visitors patch.");
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[NPCBathVisitorPatch] Failed to initialize: {ex}");
        }
    }

    private static GSD2::P_GRAPH_DATA GetDummyGraphData()
    {
        if (_dummyGraphData == null)
        {
            try
            {
                _dummyGraphData = ScriptableObject.CreateInstance(Il2CppInterop.Runtime.Il2CppType.Of<GSD2::P_GRAPH_DATA>())?.Cast<GSD2::P_GRAPH_DATA>();
            }
            catch
            {
                _dummyGraphData = new GSD2::P_GRAPH_DATA();
            }

            if (_dummyGraphData != null)
            {
                _dummyGraphData.field_data = new GSD2::PLAYER_FIELD();
                _dummyGraphData.battle_data = new GSD2::PLAYER_BATTLE();
            }
        }
        return _dummyGraphData;
    }

    /// <summary>
    /// Corrects character gender classification for castle bathhouse separation (GetFuroPos).
    /// Returns 1 (Female) for all true canonical females (routes to women's tub 6..11).
    /// Returns 0 (Male) for all males (routes to men's tub 0..5), fixing Konami vanilla data bugs
    /// where male characters like Bob (ID 4), Chaco (ID 17), Kiba (ID 86), and Alex (ID 103)
    /// were incorrectly flagged as female in ckd_info.
    /// </summary>
    [HarmonyPatch(typeof(GSD2::EventOverlayClass.f_main), nameof(GSD2::EventOverlayClass.f_main.GetSeibetu))]
    [HarmonyPrefix]
    public static bool GetSeibetu_Prefix(int chara_id, ref int __result)
    {
        if (FemaleCharaIds.Contains((byte)chara_id))
        {
            __result = 1; // 1 = Female (routes to women's bath positions 6..11 behind partition)
        }
        else
        {
            __result = 0; // 0 = Male (routes to men's bath positions 0..5)
        }
        return false;
    }


    /// <summary>
    /// Unlocks full 8-character bathhouse capacity (matching FURO_WORK internal array sizes).
    /// In vanilla, G2_pamem_num(0) only counted combat members (0..5, max 6).
    /// When inside the bathhouse, returns the count of all active bathers across all 8 slots (0..7),
    /// allowing up to 8 characters (combat members + convoy + castle visitors) to soak simultaneously.
    /// Bypasses override if a special vanilla bath vignette party is active so exact party counts (3 or 4) are preserved.
    /// </summary>
    [HarmonyPatch(typeof(GSD2::G2_SYS), nameof(GSD2::G2_SYS.G2_pamem_num))]
    [HarmonyPrefix]
    public static bool G2_pamem_num_Prefix(int mode, ref int __result)
    {
        if (!Plugin.Config.EnableNPCBathVisitors.Value) return true;

        if (IsInsideBath)
        {
            try
            {
                var party = GSD2::G2_SYS.G2_party_dat();
                if (party?.party_cha_no != null)
                {
                    int count = 0;
                    var arr = party.party_cha_no;
                    for (int i = 0; i < arr.Length && i < 8; i++)
                    {
                        if (arr[i] > 0) count++;
                    }
                    __result = count;
                    return false;
                }
            }
            catch { }
        }
        return true;
    }

    /// <summary>
    /// Prevents IndexOutOfRangeException and null-dereference crashes (0x182016059) in CreateFuroChara
    /// by supplying dummy P_GRAPH_DATA with non-null field_data & battle_data when an NPC is loaded into the bathhouse.
    /// </summary>
    [HarmonyPatch(typeof(GSD2::G2_SYS), nameof(GSD2::G2_SYS.G2_gra_dat))]
    [HarmonyPrefix]
    public static bool G2_gra_dat_Prefix(int pcno, ref GSD2::P_GRAPH_DATA __result)
    {
        if (!Plugin.Config.EnableNPCBathVisitors.Value) return true;

        if (IsInsideBath && (pcno < 0 || pcno >= 8))
        {
            __result = GetDummyGraphData();
            return false;
        }
        return true;
    }

    [HarmonyPatch(typeof(GSD2::G2_SYS), nameof(GSD2::G2_SYS.G2_gra_dat))]
    [HarmonyPostfix]
    public static void G2_gra_dat_Postfix(int pcno, ref GSD2::P_GRAPH_DATA __result)
    {
        if (!Plugin.Config.EnableNPCBathVisitors.Value) return;

        if (IsInsideBath)
        {
            if (__result == null)
            {
                __result = GetDummyGraphData();
            }
            else
            {
                if (__result.field_data == null)
                    __result.field_data = GetDummyGraphData().field_data;
                if (__result.battle_data == null)
                    __result.battle_data = GetDummyGraphData().battle_data;
            }
        }
    }

    /// <summary>
    /// Prevents IndexOutOfRangeException when querying variable character data for NPCs (IDs >= 83).
    /// In Suikoden 2, c_varia_dat only contains entries for combat characters (0..82).
    /// When an NPC is queried, safely return null so callers like CheckfuroItemEquip gracefully treat them as having no equipment.
    /// </summary>
    [HarmonyPatch(typeof(GSD2::G2_SYS), nameof(GSD2::G2_SYS.G2_varia_dat))]
    [HarmonyPrefix]
    public static bool G2_varia_dat_Prefix(int chano, ref GSD2::C_VARIA_DAT __result)
    {
        if (chano < 0 || chano >= 83)
        {
            __result = null;
            return false;
        }
        return true;
    }

    /// <summary>
    /// Preemptively intercepts bath equipment checks for NPCs (IDs >= 83), returning 0 (no bath item equipped).
    /// </summary>
    [HarmonyPatch(typeof(GSD2::EventOverlayClass.f_main), nameof(GSD2::EventOverlayClass.f_main.CheckfuroItemEquip))]
    [HarmonyPrefix]
    public static bool CheckfuroItemEquip_Prefix(int chara_no, int item_no, ref int __result)
    {
        if (chara_no < 0 || chara_no >= 83)
        {
            __result = 0;
            return false;
        }
        return true;
    }

    /// <summary>
    /// When bathhouse initialization begins, mark bath state and populate party with convoy / recruited castle NPCs.
    /// </summary>
    [HarmonyPatch(typeof(GSD2::EventOverlayClass.f_main), nameof(GSD2::EventOverlayClass.f_main.FuroInit))]
    [HarmonyPrefix]
    public static void FuroInit_Prefix(GSD2::EventOverlayClass.furo_h.FURO_WORK fw)
    {
        if (!Plugin.Config.EnableNPCBathVisitors.Value) return;

        IsInsideBath = true;
        PrepareBathParty();
    }

    /// <summary>
    /// When bathhouse exits, restore the original party and reset state.
    /// </summary>
    [HarmonyPatch(typeof(GSD2::EventOverlayClass.f_main), nameof(GSD2::EventOverlayClass.f_main.FuroEnd))]
    [HarmonyPostfix]
    public static void FuroEnd_Postfix(GSD2::EventOverlayClass.furo_h.FURO_WORK fw)
    {
        IsInsideBath = false;
        RestoreParty();
    }

    private static readonly HashSet<byte> PermanentCastleFemales = new HashSet<byte>
    {
        85,  // Apple
        94,  // Leona
        96,  // Barbara
        100  // Pilika
    };

    private static readonly HashSet<byte> PermanentCastleMales = new HashSet<byte>
    {
        86,  // Hauser
        93   // Richmond
    };

    private static void PrepareBathParty()
    {
        try
        {
            var party = GSD2::G2_SYS.G2_party_dat();
            if (party == null || party.party_cha_no == null) return;

            var chaNoArray = party.party_cha_no;
            int totalSlots = chaNoArray.Length;
            if (totalSlots < 6) return;

            // Backup original party (all 8 slots)
            _savedPartyMembers = new byte[totalSlots];
            for (int i = 0; i < totalSlots; i++)
            {
                _savedPartyMembers[i] = chaNoArray[i];
            }
            _isPartyModified = true;

            // Track existing characters in all slots (0..7) and count gender
            HashSet<byte> activeIds = new HashSet<byte>();
            int maleCount = 0;
            int femaleCount = 0;

            for (int i = 0; i < totalSlots && i < 8; i++)
            {
                byte id = chaNoArray[i];
                if (id > 0)
                {
                    activeIds.Add(id);
                    if (FemaleCharaIds.Contains(id))
                    {
                        femaleCount++;
                    }
                    else
                    {
                        maleCount++;
                    }
                }
            }

            // Collect recruited castle candidates, segregated by gender
            List<byte> recruitedFemales = new List<byte>();
            List<byte> recruitedMales = new List<byte>();

            foreach (byte npcId in FemaleCastleNPCs)
            {
                if (!activeIds.Contains(npcId))
                {
                    try
                    {
                        if (PermanentCastleFemales.Contains(npcId) || GSD2::G2_SYS.G2_cha_flag(2, npcId) == 1)
                            recruitedFemales.Add(npcId);
                    }
                    catch { }
                }
            }

            foreach (byte npcId in MaleCastleNPCs)
            {
                if (!activeIds.Contains(npcId))
                {
                    try
                    {
                        if (PermanentCastleMales.Contains(npcId) || GSD2::G2_SYS.G2_cha_flag(2, npcId) == 1)
                            recruitedMales.Add(npcId);
                    }
                    catch { }
                }
            }

            Plugin.Log.LogInfo($"[NPCBathVisitorPatch] Bath entry: initial party has {maleCount} males, {femaleCount} females. Castle pool: {recruitedFemales.Count} females, {recruitedMales.Count} males.");

            // Shuffle both candidate pools
            System.Random rng = new System.Random();
            Shuffle(recruitedFemales, rng);
            Shuffle(recruitedMales, rng);

            int femaleIdx = 0;
            int maleIdx = 0;

            // Fill all empty slots across index 1..7 (up to 8 total bathers).
            // Even if the combat party has 6 members (slots 0..5), slots 6 and 7 (+2 over party count)
            // will now be filled with castle visitors so up to 8 companions bathe together!
            // Each tub (men's 0..5, women's 6..11) holds 6 spots, so cap each gender at 6.
            for (int i = 1; i < totalSlots && i < 8; i++)
            {
                if (chaNoArray[i] == 0)
                {
                    byte chosenId = 0;

                    // Guarantee female representation first if women's tub is empty, or alternate to balance tubs
                    if (femaleCount < 6 && (femaleCount == 0 || (femaleCount < maleCount && femaleIdx < recruitedFemales.Count)))
                    {
                        if (femaleIdx < recruitedFemales.Count)
                        {
                            chosenId = recruitedFemales[femaleIdx++];
                            femaleCount++;
                        }
                        else if (maleCount < 6 && maleIdx < recruitedMales.Count)
                        {
                            chosenId = recruitedMales[maleIdx++];
                            maleCount++;
                        }
                    }
                    else if (maleCount < 6 && maleIdx < recruitedMales.Count)
                    {
                        chosenId = recruitedMales[maleIdx++];
                        maleCount++;
                    }
                    else if (femaleCount < 6 && femaleIdx < recruitedFemales.Count)
                    {
                        chosenId = recruitedFemales[femaleIdx++];
                        femaleCount++;
                    }

                    if (chosenId > 0)
                    {
                        chaNoArray[i] = chosenId;
                        activeIds.Add(chosenId);
                        string genderStr = FemaleCharaIds.Contains(chosenId) ? "Female (Women's tub)" : "Male (Men's tub)";
                        if (Plugin.Config.DetailedLogs.Value)
                            Plugin.Log.LogInfo($"[NPCBathVisitorPatch] Added castle visitor NPC ID {chosenId} [{genderStr}] to bath slot {i}. Total bathers now: {maleCount + femaleCount} (Men: {maleCount}, Women: {femaleCount}).");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[NPCBathVisitorPatch] Error in PrepareBathParty: {ex}");
            RestoreParty();
        }
    }

    private static void Shuffle<T>(List<T> list, System.Random rng)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int k = rng.Next(i + 1);
            T tmp = list[i];
            list[i] = list[k];
            list[k] = tmp;
        }
    }

    public static void RestoreParty()
    {
        if (!_isPartyModified || _savedPartyMembers == null) return;

        try
        {
            var party = GSD2::G2_SYS.G2_party_dat();
            if (party != null && party.party_cha_no != null)
            {
                for (int i = 0; i < party.party_cha_no.Length && i < _savedPartyMembers.Length; i++)
                {
                    party.party_cha_no[i] = _savedPartyMembers[i];
                }
                if (Plugin.Config.DetailedLogs.Value)
                    Plugin.Log.LogInfo("[NPCBathVisitorPatch] Restored original party data after bathhouse exit.");
            }
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[NPCBathVisitorPatch] Error restoring party data: {ex}");
        }
        finally
        {
            _isPartyModified = false;
            _savedPartyMembers = null;
        }
    }
}
