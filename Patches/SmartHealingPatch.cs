extern alias GSD2;

using System;
using System.Collections.Generic;
using HarmonyLib;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using ShareUI.Menu;
using UnityEngine.SceneManagement;

namespace PKCore.Patches;

/// <summary>
/// Smart After-Battle Healing Patch for Suikoden 2:
/// Automatically consumes healing items (Medicine, Mega Medicine, Healing Wind scrolls,
/// Sacrificial Jizo, Antitoxin) after battle to revive, cure poison, and heal injured party members.
/// Controlled entirely via the master toggle EnableSmartHealing.
/// 
/// Smart Features:
/// 1. Prioritizes the most critically injured party members first (lowest HP percentage).
/// 2. Evaluates HP deficits and chooses the best-fit item:
///    - Uses Medicine (100 HP) for smaller wounds to avoid wasting rare Mega Medicine.
///    - Uses Mega Medicine (500 HP) for large wounds (>=300 HP deficit).
///    - Uses Healing Wind (999 HP) for massive wounds (>=600 HP deficit).
///    - Prevents wasting high-tier items on small scratches.
///    - Ignores trivial chip damage (< 20 HP).
/// 3. Consumes items from the shared Party Bag first, then equipped Character personal inventories.
/// 4. Compacts the Party Bag when items are fully consumed to maintain clean inventory.
/// 5. Automatically uses Sacrificial Jizo to revive fallen members (0 HP) to 50% max HP.
/// 6. Automatically uses Antitoxin to cure Poison on living members.
/// </summary>
public static class SmartHealingPatch
{
    public static bool IsLoaded { get; private set; }
    private static bool _hasHealedThisBattle = false;

    public class ItemSourceRef
    {
        public bool IsBag;
        public int CharaNo;
        public string OwnerName;
        public int SlotIndex;
        public GSD2::PARTY_ITEM ItemRef;
        public byte ItemNo;
        public byte UseCnt;
        public int HealAmount;
        public string ItemName;
    }

    public class InjuredMember
    {
        public int SlotIndex;
        public int CharaNo;
        public string CharaName;
        public int CurHp;
        public int MaxHp;
        public GSD2::C_VARIA_DAT Varia;
        public GSD2::BattlePlayerCharacter Bpc;
    }

    public static void Initialize(Harmony harmony)
    {
        try
        {
            Plugin.Log.LogInfo("[SmartHealingPatch] Initializing Smart Auto-Healing for Suikoden 2...");
            harmony.PatchAll(typeof(SmartHealingPatch));
            SceneManager.sceneLoaded += (UnityEngine.Events.UnityAction<Scene, LoadSceneMode>)OnSceneLoaded;
            IsLoaded = true;
            Plugin.Log.LogInfo("[SmartHealingPatch] Initialized Smart Auto-Healing successfully.");
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[SmartHealingPatch] Failed to initialize: {ex}");
        }
    }

    private static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        _hasHealedThisBattle = false;
    }

    public static void ResetBattleState()
    {
        _hasHealedThisBattle = false;
    }

    /// <summary>
    /// Reset healing lock when a new battle initializes player party.
    /// </summary>
    [HarmonyPatch(typeof(GSD2::BattleManager), "PlayerInit")]
    [HarmonyPostfix]
    public static void BattleManager_PlayerInit_Postfix()
    {
        _hasHealedThisBattle = false;
    }

    /// <summary>
    /// Trigger smart healing when battle player data is stored back to the party upon confirming exit.
    /// This is the primary trigger that executes towards the end of battle when confirming exit.
    /// </summary>
    [HarmonyPatch(typeof(GSD2::BattleManager), "StorePlayerData")]
    [HarmonyPostfix]
    public static void BattleManager_StorePlayerData_Postfix(GSD2::BattleManager __instance)
    {
        TryPerformSmartHeal(__instance, "Battle Exit Confirm (StorePlayerData)");
    }

    /// <summary>
    /// Trigger smart healing at battle exit cleanup (fallback for escapes / early exits).
    /// </summary>
    [HarmonyPatch(typeof(GSD2::BattleManager), "battle_exit99")]
    [HarmonyPostfix]
    public static void BattleManager_battle_exit99_Postfix(GSD2::BattleManager __instance)
    {
        TryPerformSmartHeal(__instance, "Battle Exit (battle_exit99)");
    }

    /// <summary>
    /// Safety net: Trigger smart healing when accessing the field menu.
    /// Ensures any consumed items and restored health are instantly applied when checking the party list.
    /// </summary>
    [HarmonyPatch(typeof(UIMainMenu), nameof(UIMainMenu.Open))]
    [HarmonyPrefix]
    public static void UIMainMenu_Open_Prefix()
    {
        TryPerformSmartHeal(null, "Menu Access (UIMainMenu.Open)");
    }

    public static void TryPerformSmartHeal(GSD2::BattleManager battleManager, string sourceTrigger)
    {
        try
        {
            if (!GameDetection.IsGSD2() || Plugin.Config == null || !Plugin.Config.EnableSmartHealing.Value)
                return;

            if (battleManager != null)
            {
                if (_hasHealedThisBattle)
                    return;
                _hasHealedThisBattle = true;
            }

            PerformSmartHealGSD2(battleManager, sourceTrigger);
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[SmartHealing] Error during smart heal ({sourceTrigger}): {ex}");
        }
    }

    private static GSD2::BattlePlayerCharacter FindBattlePlayerCharacter(GSD2::BattleManager battleManager, int charaNo)
    {
        if (battleManager != null)
        {
            var party = battleManager.PlayerParty;
            if (party == null && battleManager.parties != null && battleManager.parties.Length > 0)
                party = battleManager.parties[0];

            if (party != null)
            {
                for (int p = 0; p < party.Count; p++)
                {
                    var pm = party[p];
                    if (pm != null && (pm.chara_no == charaNo || pm.chara_id == charaNo))
                    {
                        return pm.TryCast<GSD2::BattlePlayerCharacter>();
                    }
                }
            }
        }
        return null;
    }

    private static void PerformSmartHealGSD2(GSD2::BattleManager battleManager, string sourceTrigger)
    {
        var partyData = GSD2::G2_SYS.G2_party_dat();
        if (partyData == null) return;

        var partyChaNo = partyData.party_cha_no;
        if (partyChaNo == null) return;

        int totalRevivedCount = 0;
        int totalPoisonCuredCount = 0;
        int totalHealedCount = 0;
        int totalItemsUsed = 0;
        bool bagModified = false;

        // Phase 1: Revive fallen / dead (0 HP / KO) party members using Sacrificial Jizo
        for (int i = 0; i < partyChaNo.Length; i++)
        {
            int charaNo = partyChaNo[i];
            if (charaNo <= 0) continue;

            var varia = GSD2::G2_SYS.G2_varia_dat(charaNo);
            if (varia == null) continue;

            var bpc = FindBattlePlayerCharacter(battleManager, charaNo);
            ushort pamemHp = 0;
            try { GSD2::G2_SYS.G2_pamem_hp(0, 0, i, ref pamemHp); } catch { }

            int curHp = (int)varia.now_hp;
            if (pamemHp > 0) curHp = pamemHp;
            if (bpc != null) curHp = Math.Max(0, (int)bpc.hp);

            bool isDead = curHp <= 0 || (bpc != null && bpc.dead_flg != 0) || (partyData.status != null && i < partyData.status.Length && (partyData.status[i] & 0x08) != 0);

            if (isDead)
            {
                string charaName = null;
                try { charaName = GSD2::G2_SYS.G2_name_get(charaNo); } catch { }
                if (string.IsNullOrEmpty(charaName)) charaName = $"Chara #{charaNo}";

                int maxHp = Math.Max((int)varia.max_hp, bpc != null ? (int)bpc.max_hp : 0);
                if (maxHp <= 0) maxHp = 100;

                if (TryReviveWithJizoGSD2(partyData, i, charaNo, charaName, varia, bpc, maxHp, ref totalItemsUsed, out bool jizoBagModified))
                {
                    if (jizoBagModified) bagModified = true;
                    totalRevivedCount++;
                }
            }
        }

        // Phase 2: Cure Poison on living party members (including any newly revived) using Antitoxin
        for (int i = 0; i < partyChaNo.Length; i++)
        {
            int charaNo = partyChaNo[i];
            if (charaNo <= 0) continue;

            var varia = GSD2::G2_SYS.G2_varia_dat(charaNo);
            if (varia == null) continue;

            var bpc = FindBattlePlayerCharacter(battleManager, charaNo);
            ushort pamemHp = 0;
            try { GSD2::G2_SYS.G2_pamem_hp(0, 0, i, ref pamemHp); } catch { }

            int curHp = (int)varia.now_hp;
            if (pamemHp > 0) curHp = pamemHp;
            if (bpc != null) curHp = Math.Max(0, (int)bpc.hp);

            // Skip unrevived dead characters
            if (curHp <= 0 || (bpc != null && bpc.dead_flg != 0))
                continue;

            string charaName = null;
            try { charaName = GSD2::G2_SYS.G2_name_get(charaNo); } catch { }
            if (string.IsNullOrEmpty(charaName)) charaName = $"Chara #{charaNo}";

            if (TryCurePoisonGSD2(partyData, i, charaNo, charaName, bpc, ref totalItemsUsed, out bool poisonBagModified))
            {
                if (poisonBagModified) bagModified = true;
                totalPoisonCuredCount++;
            }
        }

        // Phase 3: Gather living injured party members (including newly revived)
        var injuredMembers = new List<InjuredMember>();
        const int minDeficit = 10;

        for (int i = 0; i < partyChaNo.Length; i++)
        {
            int charaNo = partyChaNo[i];
            if (charaNo <= 0) continue;

            var varia = GSD2::G2_SYS.G2_varia_dat(charaNo);
            if (varia == null) continue;

            var bpc = FindBattlePlayerCharacter(battleManager, charaNo);
            ushort pamemHp = 0;
            try { GSD2::G2_SYS.G2_pamem_hp(0, 0, i, ref pamemHp); } catch { }

            int curHp = (int)varia.now_hp;
            if (pamemHp > 0) curHp = pamemHp;
            if (bpc != null) curHp = Math.Max(0, (int)bpc.hp);

            int maxHp = Math.Max((int)varia.max_hp, bpc != null ? (int)bpc.max_hp : 0);

            // Skip unrevived dead characters
            if (curHp <= 0 || (bpc != null && bpc.dead_flg != 0))
                continue;

            int missing = maxHp - curHp;
            if (missing >= minDeficit)
            {
                string charaName = null;
                try { charaName = GSD2::G2_SYS.G2_name_get(charaNo); } catch { }
                if (string.IsNullOrEmpty(charaName)) charaName = $"Chara #{charaNo}";

                injuredMembers.Add(new InjuredMember
                {
                    SlotIndex = i,
                    CharaNo = charaNo,
                    CharaName = charaName,
                    CurHp = curHp,
                    MaxHp = maxHp,
                    Varia = varia,
                    Bpc = bpc
                });
            }
        }

        // Phase 4: Heal injured party members with Medicine / Mega Medicine
        if (injuredMembers.Count > 0)
        {
            // Sort by HP percentage ascending: lowest HP% gets healed first!
            injuredMembers.Sort((a, b) => ((float)a.CurHp / a.MaxHp).CompareTo((float)b.CurHp / b.MaxHp));

            var availableItems = GatherHealingItemsGSD2(partyData);
            if (availableItems.Count > 0)
            {
                foreach (var member in injuredMembers)
                {
                    bool memberHealed = false;

                    while (member.CurHp < member.MaxHp)
                    {
                        int deficit = member.MaxHp - member.CurHp;
                        if (deficit < minDeficit)
                            break;

                        var chosen = SelectBestItemGSD2(availableItems, deficit, minDeficit);
                        if (chosen == null)
                            break;

                        int heal = Math.Min(chosen.HealAmount, deficit);
                        member.CurHp += heal;
                        member.Varia.now_hp = (ushort)member.CurHp;
                        try
                        {
                            ushort dummyHp = 0;
                            GSD2::G2_SYS.G2_pamem_hp(2, member.CurHp, member.SlotIndex, ref dummyHp);
                        }
                        catch { }

                        if (member.Bpc != null)
                        {
                            member.Bpc.hp = (short)member.CurHp;
                            member.Bpc.disp_hp = (short)member.CurHp;
                            if (member.Bpc.c_varia_dat != null)
                                member.Bpc.c_varia_dat.now_hp = (ushort)member.CurHp;
                        }

                        chosen.UseCnt--;
                        chosen.ItemRef.use_cnt = chosen.UseCnt;
                        totalItemsUsed++;
                        memberHealed = true;

                        if (chosen.IsBag)
                            bagModified = true;

                        string source = chosen.IsBag ? "Party Bag" : $"{chosen.OwnerName}'s Inventory";
                        Plugin.Log.LogInfo($"[SmartHealing] {member.CharaName} healed +{heal} HP ({member.CurHp}/{member.MaxHp}) using {chosen.ItemName} from {source} ({chosen.UseCnt} use(s) left).");

                        if (chosen.UseCnt <= 0)
                        {
                            chosen.ItemRef.item_no = 0;
                            chosen.ItemRef.use_cnt = 0;
                            availableItems.Remove(chosen);
                        }
                    }

                    if (memberHealed)
                        totalHealedCount++;
                }
            }
            else if (Plugin.Config != null && Plugin.Config.DetailedLogs.Value)
            {
                Plugin.Log.LogInfo($"[SmartHealing] {injuredMembers.Count} member(s) damaged, but no healing items available in inventory.");
            }
        }

        // Compact bag if any bag slots became empty
        if (bagModified && partyData.party_item != null)
        {
            CompactPartyBag(partyData.party_item);
        }

        if (totalRevivedCount > 0 || totalPoisonCuredCount > 0 || totalHealedCount > 0)
        {
            Plugin.Log.LogInfo($"[SmartHealing] Smart Auto-Heal complete ({sourceTrigger}): {totalRevivedCount} revived, {totalPoisonCuredCount} cured of poison, {totalHealedCount} member(s) healed, {totalItemsUsed} total item(s) consumed.");
        }
    }

    public static (int healAmount, string name) GetItemInfo(byte itemNo)
    {
        if (itemNo == 0) return (0, null);

        // Dynamic query via game's ovit_data if available
        try
        {
            var ovit = GSD2::OldSrcBase.game_work?.ovit_data;
            if (ovit != null && ovit.dogu_data != null && itemNo < ovit.dogu_data.Length)
            {
                var dogu = ovit.dogu_data[itemNo];
                if (dogu != null && dogu.eff_val > 0)
                {
                    // CRITICAL: In Suikoden 2, dogu.info[1] & 0x20 specifies HP recovery items!
                    // (Bit 0x04 specifies permanent stat-booster stones such as Stone of Power, Stone of Magic, etc.)
                    // NEVER consume stat booster stones or non-HP items!
                    bool isHpHeal = false;
                    if (dogu.info != null && dogu.info.Length > 1)
                    {
                        isHpHeal = (dogu.info[1] & 0x20) != 0;
                    }

                    if (isHpHeal)
                    {
                        string name = null;
                        try { name = GSD2::G2_SYS.G2_item_name(ovit, 0, itemNo); } catch { }
                        return (dogu.eff_val, string.IsNullOrEmpty(name) ? $"Item #{itemNo}" : name);
                    }
                }
            }
        }
        catch { }

        // Fallback to static lookup for standard known items if ovit_data is unavailable
        if (itemNo == 1) return (100, "Medicine");
        if (itemNo == 2) return (500, "Mega Medicine");
        if (itemNo == 3) return (999, "Kindness Drops");
        if (itemNo == 4) return (100, "Dragon Mist");
        if (itemNo == 9) return (300, "Water Card (Drops of Kindness)");

        int windCard2 = 13;
        try { windCard2 = GSD2::g2_data_h.I_WIND_CARD2; } catch { }
        if (itemNo == windCard2 || itemNo == 13)
        {
            return (999, "Healing Wind");
        }

        return (0, null);
    }

    private static List<ItemSourceRef> GatherHealingItemsGSD2(GSD2::PARTY_DATA partyData)
    {
        var list = new List<ItemSourceRef>();

        // 1. Party Bag (Shared Stash)
        if (partyData.party_item != null)
        {
            for (int i = 0; i < partyData.party_item.Length; i++)
            {
                var it = partyData.party_item[i];
                if (it == null || it.item_no == 0 || it.use_cnt == 0)
                    continue;

                var (healAmount, name) = GetItemInfo(it.item_no);
                if (healAmount > 0)
                {
                    list.Add(new ItemSourceRef
                    {
                        IsBag = true,
                        CharaNo = 0,
                        OwnerName = "Party Bag",
                        SlotIndex = i,
                        ItemRef = it,
                        ItemNo = it.item_no,
                        UseCnt = it.use_cnt,
                        HealAmount = healAmount,
                        ItemName = name
                    });
                }
            }
        }

        // 2. Character Equips across ALL party members in the active party
        var partyChaNo = partyData.party_cha_no;
        if (partyChaNo != null)
        {
            for (int p = 0; p < partyChaNo.Length; p++)
            {
                int pCharaNo = partyChaNo[p];
                if (pCharaNo <= 0) continue;

                var varia = GSD2::G2_SYS.G2_varia_dat(pCharaNo);
                if (varia != null && varia.item_eqp != null)
                {
                    string pName = null;
                    try { pName = GSD2::G2_SYS.G2_name_get(pCharaNo); } catch { }
                    if (string.IsNullOrEmpty(pName)) pName = $"Chara #{pCharaNo}";

                    for (int s = 0; s < varia.item_eqp.Length; s++)
                    {
                        var it = varia.item_eqp[s];
                        if (it == null || it.item_no == 0 || it.use_cnt == 0)
                            continue;

                        var (healAmount, name) = GetItemInfo(it.item_no);
                        if (healAmount > 0)
                        {
                            list.Add(new ItemSourceRef
                            {
                                IsBag = false,
                                CharaNo = pCharaNo,
                                OwnerName = pName,
                                SlotIndex = s,
                                ItemRef = it,
                                ItemNo = it.item_no,
                                UseCnt = it.use_cnt,
                                HealAmount = healAmount,
                                ItemName = name
                            });
                        }
                    }
                }
            }
        }

        return list;
    }

    private static ItemSourceRef SelectBestItemGSD2(List<ItemSourceRef> items, int deficit, int minDeficit)
    {
        if (items == null || items.Count == 0 || deficit < minDeficit) return null;

        // 1. If deficit is large (>= 300), prioritize heavy / mid heals
        if (deficit >= 300)
        {
            // For massive wounds (>= 600 HP deficit), look for full-heal items like Healing Wind (>= 900)
            if (deficit >= 600)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].HealAmount >= 900)
                        return items[i];
                }
            }

            // Otherwise prioritize Mega Medicine / mid-tier heals (300-899)
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].HealAmount >= 300 && items[i].HealAmount < 900)
                    return items[i];
            }

            // If no mid-tier heal is available, allow full heals for wounds >= 450
            if (deficit >= 450)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].HealAmount >= 900)
                        return items[i];
                }
            }
        }

        // 2. Look for items that don't overheal (healAmount <= deficit), picking the largest one to minimize item usage
        int maxNonOverheal = 0;
        ItemSourceRef largestNonOverheal = null;
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].HealAmount <= deficit)
            {
                if (items[i].HealAmount > maxNonOverheal)
                {
                    maxNonOverheal = items[i].HealAmount;
                    largestNonOverheal = items[i];
                }
            }
        }

        if (largestNonOverheal != null)
            return largestNonOverheal;

        // 3. All available items overheal (healAmount > deficit).
        // Pick the item with the smallest healAmount to minimize overheal waste.
        int minOverheal = int.MaxValue;
        ItemSourceRef smallestOverheal = null;
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].HealAmount < minOverheal)
            {
                minOverheal = items[i].HealAmount;
                smallestOverheal = items[i];
            }
        }

        if (smallestOverheal != null)
        {
            // Standard/minor heals (Medicine, Dragon Mist, recovery food <= 150 HP):
            // Always allow topping off party members if missing health is at or above minDeficit!
            if (smallestOverheal.HealAmount <= 150)
            {
                return smallestOverheal;
            }

            // Mid-tier heals (Mega Medicine <= 500 HP):
            // Allow if deficit is substantial (>= 200 HP)
            if (smallestOverheal.HealAmount <= 500 && deficit >= 200)
            {
                return smallestOverheal;
            }

            // Massive heals (Healing Wind / Kindness Drops >= 900 HP):
            // Only allow if deficit is massive (>= 450 HP)
            if (smallestOverheal.HealAmount >= 900 && deficit >= 450)
            {
                return smallestOverheal;
            }
        }

        return null;
    }

    private static bool TryReviveWithJizoGSD2(
        GSD2::PARTY_DATA partyData,
        int slotIndex,
        int charaNo,
        string charaName,
        GSD2::C_VARIA_DAT varia,
        GSD2::BattlePlayerCharacter bpc,
        int maxHp,
        ref int totalItemsUsed,
        out bool bagModified)
    {
        bagModified = false;
        try
        {
            int jizouId = 30;
            try { jizouId = GSD2::g2_data_h.I_JIZOU; } catch { }

            GSD2::PARTY_ITEM jizouItem = null;
            bool isBag = true;
            string source = "Party Bag";

            // 1. Search in Party Bag first
            if (partyData.party_item != null)
            {
                for (int i = 0; i < partyData.party_item.Length; i++)
                {
                    var it = partyData.party_item[i];
                    if (it != null && (it.item_no == jizouId || it.item_no == 30) && it.use_cnt > 0)
                    {
                        jizouItem = it;
                        isBag = true;
                        break;
                    }
                }
            }

            // 2. Search in character personal inventories across party
            if (jizouItem == null)
            {
                var partyChaNo = partyData.party_cha_no;
                if (partyChaNo != null)
                {
                    for (int p = 0; p < partyChaNo.Length; p++)
                    {
                        int pCharaNo = partyChaNo[p];
                        if (pCharaNo <= 0) continue;

                        var pVaria = GSD2::G2_SYS.G2_varia_dat(pCharaNo);
                        if (pVaria != null && pVaria.item_eqp != null)
                        {
                            for (int s = 0; s < pVaria.item_eqp.Length; s++)
                            {
                                var it = pVaria.item_eqp[s];
                                if (it != null && (it.item_no == jizouId || it.item_no == 30) && it.use_cnt > 0)
                                {
                                    jizouItem = it;
                                    isBag = false;
                                    string pName = null;
                                    try { pName = GSD2::G2_SYS.G2_name_get(pCharaNo); } catch { }
                                    source = string.IsNullOrEmpty(pName) ? $"Chara #{pCharaNo}'s Inventory" : $"{pName}'s Inventory";
                                    break;
                                }
                            }
                        }
                        if (jizouItem != null) break;
                    }
                }
            }

            if (jizouItem != null)
            {
                jizouItem.use_cnt--;
                totalItemsUsed++;
                if (jizouItem.use_cnt == 0)
                {
                    jizouItem.item_no = 0;
                    if (isBag) bagModified = true;
                }

                // Revive at 50% max HP (vanilla Sacrificial Jizo effect)
                int reviveHp = Math.Max(1, maxHp / 2);
                varia.now_hp = (ushort)reviveHp;

                try
                {
                    ushort dummyHp = 0;
                    GSD2::G2_SYS.G2_pamem_hp(2, reviveHp, slotIndex, ref dummyHp);
                }
                catch { }

                if (partyData != null && partyData.status != null && slotIndex < partyData.status.Length)
                {
                    partyData.status[slotIndex] = 0;
                }

                if (bpc != null)
                {
                    bpc.dead_flg = 0;
                    bpc.hp = (short)reviveHp;
                    bpc.disp_hp = (short)reviveHp;
                    bpc.status &= ~0x800000u;
                    if (bpc.c_varia_dat != null)
                        bpc.c_varia_dat.now_hp = (ushort)reviveHp;

                    try
                    {
                        bpc.AllBadStatusClear();
                    }
                    catch { }
                }

                Plugin.Log.LogInfo($"[SmartHealing] Revived fallen member {charaName} with Sacrificial Jizo from {source} (Restored to {reviveHp}/{maxHp} HP).");
                return true;
            }
        }
        catch (Exception ex)
        {
            Plugin.Log.LogWarning($"[SmartHealing] Error attempting to revive {charaName} with Jizo: {ex.Message}");
        }

        return false;
    }

    private static bool IsAntitoxinItem(byte itemNo)
    {
        if (itemNo == 5) return true;
        try
        {
            var ovit = GSD2::OldSrcBase.game_work?.ovit_data;
            if (ovit != null && ovit.dogu_data != null && itemNo < ovit.dogu_data.Length)
            {
                var dogu = ovit.dogu_data[itemNo];
                if (dogu != null && dogu.status != null && dogu.status.Length > 0)
                {
                    return (dogu.status[0] & 4) != 0;
                }
            }
        }
        catch { }
        return false;
    }

    private static bool TryCurePoisonGSD2(
        GSD2::PARTY_DATA partyData,
        int slotIndex,
        int charaNo,
        string charaName,
        GSD2::BattlePlayerCharacter bpc,
        ref int totalItemsUsed,
        out bool bagModified)
    {
        bagModified = false;
        try
        {
            uint poisonStatus = 0x10;
            try { poisonStatus = GSD2::b_game_h.STATUS_POISON; } catch { }

            int poisonVal = 0;
            try { poisonVal = GSD2::G2_SYS.G2_poison(0, 0, slotIndex); } catch { }

            bool isPoisoned = poisonVal != 0;
            if (!isPoisoned && bpc != null)
            {
                try
                {
                    isPoisoned = bpc.PlayerStatusCheck((ushort)poisonStatus) || bpc.PlayerStatusCheck(2);
                }
                catch { }
            }

            if (!isPoisoned) return false;

            GSD2::PARTY_ITEM antitoxin = null;
            bool isBag = true;
            string source = "Party Bag";

            // 1. Search in Party Bag first
            if (partyData.party_item != null)
            {
                for (int i = 0; i < partyData.party_item.Length; i++)
                {
                    var it = partyData.party_item[i];
                    if (it != null && IsAntitoxinItem(it.item_no) && it.use_cnt > 0)
                    {
                        antitoxin = it;
                        isBag = true;
                        break;
                    }
                }
            }

            // 2. Search in character personal inventories across party
            if (antitoxin == null)
            {
                var partyChaNo = partyData.party_cha_no;
                if (partyChaNo != null)
                {
                    for (int p = 0; p < partyChaNo.Length; p++)
                    {
                        int pCharaNo = partyChaNo[p];
                        if (pCharaNo <= 0) continue;

                        var pVaria = GSD2::G2_SYS.G2_varia_dat(pCharaNo);
                        if (pVaria != null && pVaria.item_eqp != null)
                        {
                            for (int s = 0; s < pVaria.item_eqp.Length; s++)
                            {
                                var it = pVaria.item_eqp[s];
                                if (it != null && IsAntitoxinItem(it.item_no) && it.use_cnt > 0)
                                {
                                    antitoxin = it;
                                    isBag = false;
                                    string pName = null;
                                    try { pName = GSD2::G2_SYS.G2_name_get(pCharaNo); } catch { }
                                    source = string.IsNullOrEmpty(pName) ? $"Chara #{pCharaNo}'s Inventory" : $"{pName}'s Inventory";
                                    break;
                                }
                            }
                        }
                        if (antitoxin != null) break;
                    }
                }
            }

            if (antitoxin != null)
            {
                antitoxin.use_cnt--;
                totalItemsUsed++;
                if (antitoxin.use_cnt == 0)
                {
                    antitoxin.item_no = 0;
                    if (isBag) bagModified = true;
                }

                // G2_SYS.G2_poison mode 2 clears poison
                try { GSD2::G2_SYS.G2_poison(2, 0, slotIndex); } catch { }
                if (partyData != null && partyData.status != null && slotIndex < partyData.status.Length)
                {
                    partyData.status[slotIndex] = (byte)(partyData.status[slotIndex] & ~1);
                }
                if (bpc != null)
                {
                    try
                    {
                        bpc.PlayerStatusClear((ushort)poisonStatus);
                        bpc.PlayerStatusClear(2);
                    }
                    catch { }
                }

                Plugin.Log.LogInfo($"[SmartHealing] Cured Poison on {charaName} using Antitoxin from {source} ({antitoxin.use_cnt} use(s) remaining).");
                return true;
            }
        }
        catch (Exception ex)
        {
            Plugin.Log.LogWarning($"[SmartHealing] Error checking/curing poison for {charaName}: {ex.Message}");
        }

        return false;
    }

    private static void CompactPartyBag(Il2CppReferenceArray<GSD2::PARTY_ITEM> bag)
    {
        if (bag == null) return;
        int writeIdx = 0;
        for (int readIdx = 0; readIdx < bag.Length; readIdx++)
        {
            var item = bag[readIdx];
            if (item != null && item.item_no != 0 && item.use_cnt > 0)
            {
                if (writeIdx != readIdx)
                {
                    var target = bag[writeIdx];
                    if (target == null)
                    {
                        target = new GSD2::PARTY_ITEM();
                        bag[writeIdx] = target;
                    }
                    target.item_no = item.item_no;
                    target.use_cnt = item.use_cnt;

                    item.item_no = 0;
                    item.use_cnt = 0;
                }
                writeIdx++;
            }
        }

        // Clear trailing slots
        for (int i = writeIdx; i < bag.Length; i++)
        {
            if (bag[i] != null)
            {
                bag[i].item_no = 0;
                bag[i].use_cnt = 0;
            }
        }
    }
}
