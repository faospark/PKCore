extern alias GSD2;

using System;
using System.Collections.Generic;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using UnityEngine;

namespace PKCore.Patches;

/// <summary>
/// Core Manager for the restored Suikoden II Hero Bedroom Decoration System (room_item).
/// Manages state, validation, item transfers, and flavor text for GAME_DATA.room_item (8 slots).
/// </summary>
public static class RoomItemManager
{
    public const int ROOM_ITEM_MAX = 8;

    /// <summary>
    /// Slot placement display labels corresponding to Riou's bedroom furniture / positions in vk16.
    /// </summary>
    public static readonly string[] SlotDescriptions =
    {
        "Bedside Nightstand (Left)",      // Slot 0
        "Bedside Nightstand (Right)",     // Slot 1
        "Main Desk (Center)",             // Slot 2
        "Main Desk (Corner Display)",     // Slot 3
        "Display Cabinet Shelf (Upper)",  // Slot 4
        "Display Cabinet Shelf (Lower)",  // Slot 5
        "Bedroom Wall (West)",            // Slot 6 (Paintings / Scrolls)
        "Bedroom Wall (East)"             // Slot 7 (Paintings / Scrolls)
    };

    /// <summary>
    /// Gets the active Suikoden 2 GAME_DATA instance.
    /// </summary>
    public static GSD2::GAME_DATA GetGameData()
    {
        try
        {
            return GSD2::OldSrcBase.game_work?.game_data;
        }
        catch (Exception ex)
        {
            Plugin.Log.LogWarning($"[RoomItemManager] Failed to access game_data: {ex.Message}");
            return null;
        }
    }

    /// <summary>
    /// Returns the native 8-element room_item array from GAME_DATA.
    /// </summary>
    public static Il2CppReferenceArray<GSD2::PARTY_ITEM> GetRoomItems()
    {
        var gd = GetGameData();
        return gd?.room_item;
    }

    /// <summary>
    /// Returns the PARTY_ITEM at the specified slot index (0..7).
    /// </summary>
    public static GSD2::PARTY_ITEM GetRoomItem(int slotIndex)
    {
        if (slotIndex < 0 || slotIndex >= ROOM_ITEM_MAX) return null;
        var items = GetRoomItems();
        if (items == null || slotIndex >= items.Length) return null;
        return items[slotIndex];
    }

    /// <summary>
    /// Checks if a slot is currently occupied by an item.
    /// </summary>
    public static bool IsSlotOccupied(int slotIndex)
    {
        var item = GetRoomItem(slotIndex);
        return item != null && item.item_no != 0;
    }

    /// <summary>
    /// Sets the item in a specific room_item slot.
    /// </summary>
    public static bool SetRoomItem(int slotIndex, byte itemNo, byte useCnt)
    {
        if (slotIndex < 0 || slotIndex >= ROOM_ITEM_MAX) return false;
        var items = GetRoomItems();
        if (items == null || slotIndex >= items.Length) return false;

        var slot = items[slotIndex];
        if (slot == null)
        {
            slot = new GSD2::PARTY_ITEM();
            items[slotIndex] = slot;
        }

        slot.item_no = itemNo;
        slot.use_cnt = useCnt;

        Plugin.Log.LogInfo($"[RoomItemManager] Slot {slotIndex} ({SlotDescriptions[slotIndex]}) set to item_no={itemNo}, use_cnt=0x{useCnt:X2} ({GetItemName(slot)})");
        return true;
    }

    /// <summary>
    /// Clears a room_item slot (sets item_no = 0, use_cnt = 0).
    /// </summary>
    public static bool ClearRoomItem(int slotIndex)
    {
        return SetRoomItem(slotIndex, 0, 0);
    }

    /// <summary>
    /// Validates whether an item qualifies as an antique / bedroom decoration.
    /// In Suikoden 2, antiques/curios carry category high-nibble 0x40 in use_cnt (64 decimal).
    /// </summary>
    public static bool IsDecorItem(GSD2::PARTY_ITEM item)
    {
        if (item == null || item.item_no == 0) return false;

        // Category 0x40 (Antiques / Curios / Paintings / Urns / Statues)
        byte category = (byte)(item.use_cnt & 0xF0);
        if (category == 0x40) return true;

        // Specific antique index fallback range
        return item.use_cnt == 64;
    }

    /// <summary>
    /// Resolves the in-game display name of a PARTY_ITEM.
    /// </summary>
    public static string GetItemName(GSD2::PARTY_ITEM item)
    {
        if (item == null || item.item_no == 0) return "Empty";
        try
        {
            string name = GSD2::fcommand.FC_ItemName(item.use_cnt, item.item_no);
            if (!string.IsNullOrEmpty(name)) return name.Trim();
        }
        catch { }
        return $"Item #{item.item_no} (Cat 0x{item.use_cnt:X2})";
    }

    /// <summary>
    /// Resolves the in-game help / description text of a PARTY_ITEM.
    /// </summary>
    public static string GetItemDescription(GSD2::PARTY_ITEM item)
    {
        if (item == null || item.item_no == 0) return "No item placed.";
        try
        {
            string text = GSD2::fcommand.FC_ItemText(item.use_cnt, item.item_no);
            if (!string.IsNullOrEmpty(text)) return text.Trim();
        }
        catch { }
        return "An antique item.";
    }

    /// <summary>
    /// Returns lore-friendly inspection commentary when examining displayed room items.
    /// Features character reactions from Nanami and Riou.
    /// </summary>
    public static string GetSlotFlavorText(int slotIndex, GSD2::PARTY_ITEM item)
    {
        if (item == null || item.item_no == 0)
        {
            return $"{SlotDescriptions[slotIndex]}: The display space is clean and ready for an antique.";
        }

        string itemName = GetItemName(item);

        // Custom flavor text based on notable Suikoden 2 antiques
        if (itemName.Contains("Celadon", StringComparison.OrdinalIgnoreCase))
        {
            return $"[{itemName}] A rare and prized Celadon Urn. Lebrante would be green with envy seeing this displayed in your room!";
        }
        if (itemName.Contains("Peeing Boy", StringComparison.OrdinalIgnoreCase))
        {
            return $"[{itemName}] Nanami: \"Riou!! Why on earth did you put that ridiculous statue right there?! Put it away!\"";
        }
        if (itemName.Contains("Bonsai", StringComparison.OrdinalIgnoreCase))
        {
            return $"[{itemName}] A meticulously pruned bonsai tree. Its tranquil aura brings peace to the room.";
        }
        if (itemName.Contains("Hex Doll", StringComparison.OrdinalIgnoreCase))
        {
            return $"[{itemName}] An eerie hex doll. You could swear its eyes follow you around the room...";
        }
        if (itemName.Contains("Genkaku", StringComparison.OrdinalIgnoreCase))
        {
            return $"[{itemName}] Grandfather Genkaku's cherished urn. Looking at it fills your heart with warmth and resolve.";
        }
        if (itemName.Contains("Goddess", StringComparison.OrdinalIgnoreCase))
        {
            return $"[{itemName}] A magnificent goddess statue crafted from pure marble, radiating gentle grace.";
        }
        if (itemName.Contains("Knight", StringComparison.OrdinalIgnoreCase))
        {
            return $"[{itemName}] A proud knight statuette standing watch over the commander's quarters.";
        }
        if (itemName.Contains("Painting", StringComparison.OrdinalIgnoreCase) || itemName.Contains("Scroll", StringComparison.OrdinalIgnoreCase))
        {
            return $"[{itemName}] A masterwork artwork hung gracefully on the bedroom wall, filling the chamber with color.";
        }

        return $"[{itemName}] {GetItemDescription(item)}";
    }

    /// <summary>
    /// Scans the entire party and returns all held antique / decor items.
    /// </summary>
    public static List<(int charaIndex, int slotIndex, GSD2::PARTY_ITEM item)> GetPartyDecorItems()
    {
        var list = new List<(int, int, GSD2::PARTY_ITEM)>();
        try
        {
            var gw = GSD2::OldSrcBase.game_work;
            if (gw?.party_data?.party_cha_no == null) return list;

            var charaData = gw.chara_data;
            if (charaData == null) return list;

            // Scan through all active party member bags
            var chaNos = gw.party_data.party_cha_no;
            for (int c = 0; c < chaNos.Length; c++)
            {
                byte cno = chaNos[c];
                if (cno == 0 || cno == 255) continue;

                // Character item bag in c_varia_dat
                if (charaData.c_varia_dat != null && cno < charaData.c_varia_dat.Length)
                {
                    var varia = charaData.c_varia_dat[cno];
                    var partyItems = varia?.item_eqp;
                    if (partyItems != null)
                    {
                        for (int i = 0; i < partyItems.Length; i++)
                        {
                            var it = partyItems[i];
                            if (IsDecorItem(it))
                            {
                                list.Add(((int)cno, i, it));
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Plugin.Log.LogWarning($"[RoomItemManager] Failed scanning party decor items: {ex.Message}");
        }
        return list;
    }

    /// <summary>
    /// Dumps the current room_item status to the BepInEx console log.
    /// </summary>
    public static void DumpStatus()
    {
        Plugin.Log.LogInfo("=== [RoomItemManager] Suikoden II Hero Bedroom Display Status ===");
        var items = GetRoomItems();
        if (items == null)
        {
            Plugin.Log.LogWarning("room_item array is currently null (Game not loaded yet or not Suikoden 2).");
            return;
        }

        int occupiedCount = 0;
        for (int i = 0; i < ROOM_ITEM_MAX; i++)
        {
            var it = (i < items.Length) ? items[i] : null;
            if (it != null && it.item_no != 0)
            {
                occupiedCount++;
                Plugin.Log.LogInfo($"  Slot [{i}] ({SlotDescriptions[i]}): item_no={it.item_no}, use_cnt=0x{it.use_cnt:X2} -> \"{GetItemName(it)}\"");
                Plugin.Log.LogInfo($"           Flavor: {GetSlotFlavorText(i, it)}");
            }
            else
            {
                Plugin.Log.LogInfo($"  Slot [{i}] ({SlotDescriptions[i]}): [Empty]");
            }
        }

        Plugin.Log.LogInfo($"Total Occupied Bedroom Slots: {occupiedCount}/{ROOM_ITEM_MAX}");
        Plugin.Log.LogInfo("=================================================================");
    }
}
