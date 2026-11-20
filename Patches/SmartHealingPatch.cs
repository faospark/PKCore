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
/// Automatically consumes healing items (Medicine, Fried Tacos, Mega Medicine, Kindness Drops,
/// Kindness Rain, Healing Wind, Sacrificial Jizo, Antitoxin) after battle to revive,
/// cure poison, and heal injured party members.
/// Controlled entirely via the master toggle EnableSmartHealing.
/// 
/// Smart Features:
/// 1. Prioritizes the most critically injured party members first (lowest HP percentage).
/// 2. Evaluates party-wide wounds and HP deficits to choose best-fit recovery:
///    - Uses Kindness Rain (300 HP all) / Healing Wind (999 HP all) for collective group damage.
///    - Uses Medicine (100 HP) for smaller single wounds.
///    - Uses Fried Tacos (250 HP + Toasty status) for medium single wounds or fallback.
///    - Uses Mega Medicine (500 HP) for large wounds or as fallback when smaller items are depleted.
///    - Uses Kindness Drops (999 HP) for critical single-target wounds or fallback.
///    - Prevents leaving injured characters wounded when higher tier items exist.
///    - Ignores trivial chip damage (< 10 HP).
/// 3. Consumes items from the shared Party Bag first, then equipped Character personal inventories.
/// 4. Compacts the Party Bag when items are fully consumed to maintain clean inventory.
/// 5. Automatically uses Sacrificial Jizo to revive fallen members (0 HP) to 50% max HP.
/// 6. Automatically uses Antitoxin to cure Poison on living members.
/// </summary>
public static class SmartHealingPatch
{
    public const byte KindDogu = 0;
    public const byte KindDish = 6;
    public const byte FriedTacosItemNo = 54;
    public const byte ToastyStatusBit = 0x08;

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
        public byte Kind;
        public byte Count;
        public int HealAmount;
        public bool IsPartyWide;
        public string ItemName;
    }

    /// <summary>
    /// Gets the count / charges from a PARTY_ITEM.
    /// In Suikoden 2, charges are stored strictly in the lower 4 bits (use_cnt & 0x0F).
    /// </summary>
    public static byte GetItemCount(GSD2::PARTY_ITEM item)
    {
        return item != null ? (byte)(item.use_cnt & 0x0F) : (byte)0;
    }

    /// <summary>
    /// Gets the item kind / category table index from a PARTY_ITEM.
    /// In Suikoden 2, kind is stored in bits 4-6 ((use_cnt >> 4) & 0x07).
    /// Kind 0 represents dogu_data (consumables, tools, scrolls).
    /// Kind 6 represents dish_data (cooked food dishes such as Fried Tacos).
    /// </summary>
    public static byte GetItemKind(GSD2::PARTY_ITEM item)
    {
        return item != null ? (byte)((item.use_cnt >> 4) & 0x07) : (byte)0;
    }

    /// <summary>
    /// Consumes 1 charge from a PARTY_ITEM.
    /// Decrements the lower 4 bits (Count) while preserving the upper bits (Kind and flags).
    /// When charges reach 0, completely zeroes out the slot (item_no = 0, use_cnt = 0).
    /// Returns true if the slot was completely depleted and emptied.
    /// </summary>
    public static bool ConsumeItemCharge(GSD2::PARTY_ITEM item)
    {
        if (item == null || item.item_no == 0) return true;
        byte count = (byte)(item.use_cnt & 0x0F);
        if (count > 0) count--;

        if (count > 0)
        {
            item.use_cnt = (byte)((item.use_cnt & 0xF0) | (count & 0x0F));
            return false;
        }
        else
        {
            item.item_no = 0;
            item.use_cnt = 0;
            return true;
        }
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
            if (Plugin.Config.DetailedLogs.Value)
                Plugin.Log.LogInfo("[SmartHealingPatch] Initializing Smart Auto-Healing for Suikoden 2...");
            harmony.PatchAll(typeof(SmartHealingPatch));
            SceneManager.sceneLoaded += (UnityEngine.Events.UnityAction<Scene, LoadSceneMode>)OnSceneLoaded;
            IsLoaded = true;
            if (Plugin.Config.DetailedLogs.Value)
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
            if (Plugin.Config == null || !Plugin.Config.EnableSmartHealing.Value)
                return;

            if (battleManager == null)
            {
                var party = GSD2::G2_SYS.G2_party_dat();
                if (party == null || party.party_cha_no == null)
                    return;
            }

            if (battleManager != null)
            {
                if (_hasHealedThisBattle)
                    return;
                _hasHealedThisBattle = true;
            }

            // Evaluates party recovery silently unless healing occurs
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

    /// <summary>
    /// Applies the Toasty ("Hoka-Hoka") status effect to a party member slot after consuming spicy food (Fried Tacos).
    /// Uses native G2_SYS.G2_hoka(1, slotIndex) which sets partyData.status[slotIndex] |= 0x08 and hoka_cnt = 600.
    /// </summary>
    private static void ApplyToastyStatusGSD2(GSD2::PARTY_DATA partyData, int slotIndex, GSD2::BattlePlayerCharacter bpc)
    {
        try
        {
            GSD2::G2_SYS.G2_hoka(1, slotIndex);
        }
        catch { }

        if (partyData != null)
        {
            if (partyData.status != null && slotIndex >= 0 && slotIndex < partyData.status.Length)
            {
                partyData.status[slotIndex] |= ToastyStatusBit;
            }
            if (partyData.hoka_time != null && slotIndex >= 0 && slotIndex < partyData.hoka_time.Length)
            {
                if (partyData.hoka_time[slotIndex] < 600)
                    partyData.hoka_time[slotIndex] = 600;
            }
        }

        if (bpc != null)
        {
            bpc.status |= ToastyStatusBit;
        }
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

            // Note: bit 0x08 in partyData.status[i] is Toasty (G2_hoka), NOT KO/Dead!
            bool isDead = curHp <= 0 || (bpc != null && bpc.dead_flg != 0);

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

        // Phase 4: Heal injured party members with Medicine / Fried Tacos / Mega Medicine / Kindness Drops / Kindness Rain / Healing Wind
        if (injuredMembers.Count > 0)
        {
            var availableItems = GatherHealingItemsGSD2(partyData);
            if (availableItems.Count > 0)
            {
                // Step 4A: Evaluate Party-Wide Healing if multiple members are wounded
                while (injuredMembers.Count >= 2)
                {
                    int totalDeficit = 0;
                    for (int m = 0; m < injuredMembers.Count; m++)
                        totalDeficit += (injuredMembers[m].MaxHp - injuredMembers[m].CurHp);

                    if (totalDeficit < 300)
                        break;

                    var partyItem = SelectBestPartyItemGSD2(availableItems, totalDeficit, injuredMembers.Count);
                    if (partyItem == null)
                        break;

                    string pSource = partyItem.IsBag ? "Party Bag" : $"{partyItem.OwnerName}'s Inventory";
                    Plugin.Log.LogInfo($"[SmartHealing] Using party-wide {partyItem.ItemName} from {pSource} for {injuredMembers.Count} injured member(s) (Total deficit: {totalDeficit} HP)...");

                    foreach (var member in injuredMembers)
                    {
                        int deficit = member.MaxHp - member.CurHp;
                        if (deficit <= 0) continue;

                        int heal = Math.Min(partyItem.HealAmount, deficit);
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

                        Plugin.Log.LogInfo($"[SmartHealing] -> {member.CharaName} healed +{heal} HP ({member.CurHp}/{member.MaxHp}).");
                    }

                    bool slotEmptied = ConsumeItemCharge(partyItem.ItemRef);
                    partyItem.Count = GetItemCount(partyItem.ItemRef);
                    totalItemsUsed++;
                    totalHealedCount++;

                    if (partyItem.IsBag && slotEmptied)
                        bagModified = true;

                    if (slotEmptied)
                    {
                        availableItems.Remove(partyItem);
                    }

                    // Remove any members who reached full HP or have deficit < minDeficit
                    injuredMembers.RemoveAll(m => (m.MaxHp - m.CurHp) < minDeficit);
                }

                // Step 4B: Single-Target Smart Healing for remaining injured members
                if (injuredMembers.Count > 0)
                {
                    // Sort by HP percentage ascending: lowest HP% gets healed first!
                    injuredMembers.Sort((a, b) => ((float)a.CurHp / a.MaxHp).CompareTo((float)b.CurHp / b.MaxHp));

                    foreach (var member in injuredMembers)
                    {
                        bool memberHealed = false;

                        while (member.CurHp < member.MaxHp)
                        {
                            int deficit = member.MaxHp - member.CurHp;
                            if (deficit < minDeficit)
                                break;

                            var chosen = SelectBestSingleItemGSD2(availableItems, deficit, minDeficit);
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

                            bool appliedToasty = false;
                            if (chosen.Kind == KindDish && chosen.ItemNo == FriedTacosItemNo)
                            {
                                ApplyToastyStatusGSD2(partyData, member.SlotIndex, member.Bpc);
                                appliedToasty = true;
                            }

                            bool slotEmptied = ConsumeItemCharge(chosen.ItemRef);
                            chosen.Count = GetItemCount(chosen.ItemRef);
                            totalItemsUsed++;
                            memberHealed = true;

                            if (chosen.IsBag && slotEmptied)
                                bagModified = true;

                            string source = chosen.IsBag ? "Party Bag" : $"{chosen.OwnerName}'s Inventory";
                            string statusSuffix = appliedToasty ? " [+Toasty status]" : "";
                            Plugin.Log.LogInfo($"[SmartHealing] {member.CharaName} healed +{heal} HP ({member.CurHp}/{member.MaxHp}) using {chosen.ItemName} from {source} ({chosen.Count} use(s) left){statusSuffix}.");

                            if (slotEmptied)
                            {
                                availableItems.Remove(chosen);
                            }
                        }

                        if (memberHealed)
                            totalHealedCount++;
                    }
                }
            }
            else
            {
                Plugin.Log.LogInfo($"[SmartHealing] {injuredMembers.Count} member(s) damaged, but no healing items available in inventory.");
            }
        }
        else if (totalRevivedCount == 0 && totalPoisonCuredCount == 0)
        {
            // No-op when all living members are full HP
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

    public static (int healAmount, bool isPartyWide, string name) GetItemInfo(byte kind, byte itemNo)
    {
        if (itemNo == 0) return (0, false, null);

        // Support Fried Tacos (Dish Kind 6, ItemNo 54: 250 HP + Toasty status)
        if (kind == KindDish)
        {
            if (itemNo != FriedTacosItemNo)
                return (0, false, null);

            int tacoHeal = 250;
            string tacoName = null;
            try
            {
                var ovit = GSD2::OldSrcBase.game_work?.ovit_data;
                if (ovit != null)
                {
                    if (ovit.dish_data != null && itemNo < ovit.dish_data.Length)
                    {
                        var dish = ovit.dish_data[itemNo];
                        if (dish != null && dish.eff_val > 0)
                            tacoHeal = dish.eff_val;
                    }
                    try { tacoName = GSD2::G2_SYS.G2_item_name(ovit, KindDish, itemNo); } catch { }
                }
            }
            catch { }

            if (string.IsNullOrEmpty(tacoName))
                tacoName = "Fried Tacos";

            return (tacoHeal, false, tacoName);
        }

        if (kind != KindDogu) return (0, false, null);

        // Dynamic query via game's ovit_data if available
        try
        {
            var ovit = GSD2::OldSrcBase.game_work?.ovit_data;
            if (ovit != null && ovit.dogu_data != null && itemNo < ovit.dogu_data.Length)
            {
                var dogu = ovit.dogu_data[itemNo];
                if (dogu != null && dogu.eff_val > 0)
                {
                    // CRITICAL: In Suikoden 2, dogu.info[0] specifies target type:
                    // (info[0] & 0x30) == 0x10 specifies ally target
                    // (info[0] & 0xC0) == 0x40 specifies all allies (party-wide)
                    // and dogu.info[1] & 0x20 specifies HP recovery items!
                    // (Bit 0x04 specifies permanent stat-booster stones such as Stone of Power, Stone of Magic, etc.)
                    // NEVER consume stat booster stones, attack scrolls, or non-HP items!
                    bool isAllyTarget = dogu.info != null && dogu.info.Length > 0 && (dogu.info[0] & 0x30) == 0x10;
                    bool isHpHeal = dogu.info != null && dogu.info.Length > 1 && (dogu.info[1] & 0x20) != 0;
                    bool isStatStone = dogu.info != null && dogu.info.Length > 1 && (dogu.info[1] & 0x04) != 0;

                    if (isAllyTarget && isHpHeal && !isStatStone)
                    {
                        bool isPartyWide = (dogu.info[0] & 0xC0) == 0x40;
                        string name = null;
                        try { name = GSD2::G2_SYS.G2_item_name(ovit, 0, itemNo); } catch { }
                        if (string.IsNullOrEmpty(name))
                        {
                            name = itemNo switch
                            {
                                1 => "Medicine",
                                2 => "Mega Medicine",
                                4 => "Dragon Mist",
                                9 => "Kindness Drops",
                                11 => "Kindness Rain",
                                13 => "Healing Wind",
                                _ => $"Item #{itemNo}"
                            };
                        }
                        int healAmount = dogu.eff_val >= 999 ? 999 : dogu.eff_val;
                        if (itemNo == 9) healAmount = 999;
                        if (itemNo == 11) { healAmount = 300; isPartyWide = true; }
                        if (itemNo == 13) { healAmount = 999; isPartyWide = true; }
                        return (healAmount, isPartyWide, name);
                    }
                }
            }
        }
        catch { }

        // Fallback to static lookup for standard known items if ovit_data is unavailable
        if (itemNo == 1) return (100, false, "Medicine");
        if (itemNo == 2) return (500, false, "Mega Medicine");
        if (itemNo == 4) return (100, false, "Dragon Mist");
        if (itemNo == 9) return (999, false, "Kindness Drops");
        if (itemNo == 11) return (300, true, "Kindness Rain");
        if (itemNo == 13) return (999, true, "Healing Wind");

        return (0, false, null);
    }

    private static List<ItemSourceRef> GatherHealingItemsGSD2(GSD2::PARTY_DATA partyData)
    {
        var list = new List<ItemSourceRef>();

        // 1. Party Bag (Shared Stash) - searched first
        if (partyData.party_item != null)
        {
            for (int i = 0; i < partyData.party_item.Length; i++)
            {
                var it = partyData.party_item[i];
                if (it == null || it.item_no == 0)
                    continue;

                byte kind = GetItemKind(it);
                byte count = GetItemCount(it);
                if (count == 0 || (kind != KindDogu && kind != KindDish))
                    continue;

                var (healAmount, isPartyWide, name) = GetItemInfo(kind, it.item_no);
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
                        Kind = kind,
                        Count = count,
                        HealAmount = healAmount,
                        IsPartyWide = isPartyWide,
                        ItemName = name
                    });
                }
            }
        }

        // 2. Active Party Members' Personal Item Slots - fallback after Party Bag
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
                        if (it == null || it.item_no == 0)
                            continue;

                        byte kind = GetItemKind(it);
                        byte count = GetItemCount(it);
                        if (count == 0 || (kind != KindDogu && kind != KindDish))
                            continue;

                        var (healAmount, isPartyWide, name) = GetItemInfo(kind, it.item_no);
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
                                Kind = kind,
                                Count = count,
                                HealAmount = healAmount,
                                IsPartyWide = isPartyWide,
                                ItemName = name
                            });
                        }
                    }
                }
            }
        }

        return list;
    }

    private static ItemSourceRef SelectBestPartyItemGSD2(List<ItemSourceRef> items, int totalDeficit, int injuredCount)
    {
        if (items == null || items.Count == 0 || injuredCount < 2 || totalDeficit < 300) return null;

        // Party-wide items: Kindness Rain (300 HP all), Healing Wind (999 HP all)
        // Partition into Party Bag first (pass 0), then Character Equips (pass 1)
        for (int pass = 0; pass < 2; pass++)
        {
            bool checkBag = pass == 0;

            // If total deficit is massive (>= 600) or high injured count, prefer Healing Wind
            if (totalDeficit >= 600)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    var it = items[i];
                    if (it.IsBag == checkBag && it.IsPartyWide && it.HealAmount >= 900)
                        return it;
                }
            }

            // Otherwise prefer Kindness Rain (300 HP all)
            for (int i = 0; i < items.Count; i++)
            {
                var it = items[i];
                if (it.IsBag == checkBag && it.IsPartyWide && it.HealAmount >= 300 && it.HealAmount < 900)
                    return it;
            }

            // Fallback to Healing Wind if totalDeficit >= 450
            if (totalDeficit >= 450)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    var it = items[i];
                    if (it.IsBag == checkBag && it.IsPartyWide && it.HealAmount >= 900)
                        return it;
                }
            }
        }

        return null;
    }

    private static ItemSourceRef SelectBestSingleItemGSD2(List<ItemSourceRef> items, int deficit, int minDeficit)
    {
        if (items == null || items.Count == 0 || deficit < minDeficit) return null;

        // Partition into Party Bag first (pass 0), then Character Equips (pass 1)
        for (int pass = 0; pass < 2; pass++)
        {
            bool checkBag = pass == 0;

            // 1. If deficit >= 400:
            // Prefer Kindness Drops (999 HP), then Mega Medicine (500 HP), then Fried Tacos (250 HP), then Medicine (100 HP)
            if (deficit >= 400)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    var it = items[i];
                    if (it.IsBag == checkBag && !it.IsPartyWide && it.HealAmount >= 900)
                        return it;
                }
                for (int i = 0; i < items.Count; i++)
                {
                    var it = items[i];
                    if (it.IsBag == checkBag && !it.IsPartyWide && it.HealAmount > 300 && it.HealAmount < 900)
                        return it;
                }
                for (int i = 0; i < items.Count; i++)
                {
                    var it = items[i];
                    if (it.IsBag == checkBag && !it.IsPartyWide && it.HealAmount > 150 && it.HealAmount <= 300)
                        return it;
                }
                for (int i = 0; i < items.Count; i++)
                {
                    var it = items[i];
                    if (it.IsBag == checkBag && !it.IsPartyWide && it.HealAmount <= 150)
                        return it;
                }
            }
            // 2. If 300 <= deficit < 400:
            // Prefer Mega Medicine (500 HP), then Fried Tacos (250 HP), then Medicine (100 HP), then Kindness Drops (999 HP)
            else if (deficit >= 300)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    var it = items[i];
                    if (it.IsBag == checkBag && !it.IsPartyWide && it.HealAmount > 300 && it.HealAmount < 900)
                        return it;
                }
                for (int i = 0; i < items.Count; i++)
                {
                    var it = items[i];
                    if (it.IsBag == checkBag && !it.IsPartyWide && it.HealAmount > 150 && it.HealAmount <= 300)
                        return it;
                }
                for (int i = 0; i < items.Count; i++)
                {
                    var it = items[i];
                    if (it.IsBag == checkBag && !it.IsPartyWide && it.HealAmount <= 150)
                        return it;
                }
                for (int i = 0; i < items.Count; i++)
                {
                    var it = items[i];
                    if (it.IsBag == checkBag && !it.IsPartyWide && it.HealAmount >= 900)
                        return it;
                }
            }
            // 3. If 180 <= deficit < 300:
            // Prefer Fried Tacos (250 HP), then Mega Medicine (500 HP), then Medicine (100 HP), then Kindness Drops (999 HP)
            else if (deficit >= 180)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    var it = items[i];
                    if (it.IsBag == checkBag && !it.IsPartyWide && it.HealAmount > 150 && it.HealAmount <= 300)
                        return it;
                }
                for (int i = 0; i < items.Count; i++)
                {
                    var it = items[i];
                    if (it.IsBag == checkBag && !it.IsPartyWide && it.HealAmount > 300 && it.HealAmount < 900)
                        return it;
                }
                for (int i = 0; i < items.Count; i++)
                {
                    var it = items[i];
                    if (it.IsBag == checkBag && !it.IsPartyWide && it.HealAmount <= 150)
                        return it;
                }
                for (int i = 0; i < items.Count; i++)
                {
                    var it = items[i];
                    if (it.IsBag == checkBag && !it.IsPartyWide && it.HealAmount >= 900)
                        return it;
                }
            }
            // 4. If deficit < 180:
            // Prefer Medicine (100 HP) first to avoid waste.
            // If Medicine is depleted / unavailable, fall back to Fried Tacos (250 HP), then Mega Medicine (500 HP), then Kindness Drops!
            else
            {
                for (int i = 0; i < items.Count; i++)
                {
                    var it = items[i];
                    if (it.IsBag == checkBag && !it.IsPartyWide && it.HealAmount <= 150)
                        return it;
                }
                for (int i = 0; i < items.Count; i++)
                {
                    var it = items[i];
                    if (it.IsBag == checkBag && !it.IsPartyWide && it.HealAmount > 150 && it.HealAmount <= 300)
                        return it;
                }
                for (int i = 0; i < items.Count; i++)
                {
                    var it = items[i];
                    if (it.IsBag == checkBag && !it.IsPartyWide && it.HealAmount > 300 && it.HealAmount < 900)
                        return it;
                }
                for (int i = 0; i < items.Count; i++)
                {
                    var it = items[i];
                    if (it.IsBag == checkBag && !it.IsPartyWide && it.HealAmount >= 900)
                        return it;
                }
            }

            // 5. If no single-target items exist in this source, allow party-wide items as emergency fallback
            if (deficit >= 150)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    var it = items[i];
                    if (it.IsBag == checkBag && it.IsPartyWide)
                        return it;
                }
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
                    if (it != null && (it.item_no == jizouId || it.item_no == 30))
                    {
                        byte kind = GetItemKind(it);
                        byte count = GetItemCount(it);
                        if (kind == 0 && count > 0)
                        {
                            jizouItem = it;
                            isBag = true;
                            source = "Party Bag";
                            break;
                        }
                    }
                }
            }

            // 2. Search active party characters' personal inventories
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
                                if (it != null && (it.item_no == jizouId || it.item_no == 30))
                                {
                                    byte kind = GetItemKind(it);
                                    byte count = GetItemCount(it);
                                    if (kind == 0 && count > 0)
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
                        }
                        if (jizouItem != null) break;
                    }
                }
            }

            if (jizouItem != null)
            {
                bool emptied = ConsumeItemCharge(jizouItem);
                totalItemsUsed++;
                if (emptied && isBag) bagModified = true;

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
                    // Clear bad status bits (0x07) while preserving any non-bad flags
                    partyData.status[slotIndex] = (byte)(partyData.status[slotIndex] & ~0x07);
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

    private static bool IsAntitoxinItem(GSD2::PARTY_ITEM item)
    {
        if (item == null || item.item_no == 0) return false;
        byte kind = GetItemKind(item);
        if (kind != 0) return false;
        if (item.item_no == 3 || item.item_no == 5) return true;
        try
        {
            var ovit = GSD2::OldSrcBase.game_work?.ovit_data;
            if (ovit != null && ovit.dogu_data != null && item.item_no < ovit.dogu_data.Length)
            {
                var dogu = ovit.dogu_data[item.item_no];
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
                    if (it != null && IsAntitoxinItem(it) && GetItemCount(it) > 0)
                    {
                        antitoxin = it;
                        isBag = true;
                        source = "Party Bag";
                        break;
                    }
                }
            }

            // 2. Search in active party characters' personal inventories
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
                                if (it != null && IsAntitoxinItem(it) && GetItemCount(it) > 0)
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
                bool emptied = ConsumeItemCharge(antitoxin);
                totalItemsUsed++;
                if (emptied && isBag) bagModified = true;

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

                Plugin.Log.LogInfo($"[SmartHealing] Cured Poison on {charaName} using Antitoxin from {source} ({GetItemCount(antitoxin)} use(s) remaining).");
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
            if (item != null && item.item_no != 0)
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
