extern alias GSD2;

using System;
using HarmonyLib;
using UnityEngine;

namespace PKCore.Patches;

/// <summary>
/// Harmony patches and runtime monitoring for the restored Suikoden II Hero Bedroom Decoration System.
/// Hooks map initialization in Riou's room (vk16) and manages runtime display synchronization.
/// </summary>
[HarmonyPatch]
public static class RoomItemPatch
{
    private static float _lastHotbarTime = 0f;

    /// <summary>
    /// Checks whether the given map ID corresponds to Riou's Castle bedroom (vk16).
    /// </summary>
    public static bool IsHeroBedroom(string mapId, EVENTCON eventcon)
    {
        if (!string.IsNullOrEmpty(mapId) && mapId.StartsWith("vk16", StringComparison.OrdinalIgnoreCase))
            return true;

        if (eventcon?.mdat != null && string.Equals(eventcon.mdat.name, "vk16", StringComparison.OrdinalIgnoreCase))
            return true;

        return false;
    }

    /// <summary>
    /// Postfix on MACHICON.EventInit to synchronize room_item displays upon map entry.
    /// </summary>
    [HarmonyPatch(typeof(MACHICON), "EventInit")]
    [HarmonyPostfix]
    public static void OnMapEventInit(MACHICON __instance, EVENTCON __result)
    {
        if (!Plugin.Config.EnableRoomItemRestoration.Value) return;
        if (__result == null || __result.mdat?.eventdata?.mapeventdat == null) return;

        string mapId = MACHICON_OnMapInitPatch.CurrentMapId;
        if (string.IsNullOrEmpty(mapId) && __instance != null)
        {
            string raw = __instance.GetMapName();
            if (!string.IsNullOrEmpty(raw))
            {
                mapId = raw.Split(' ')[0];
            }
        }

        if (!IsHeroBedroom(mapId, __result)) return;

        Plugin.Log.LogInfo($"[RoomItemPatch] Entered Hero's Bedroom (map: {mapId ?? "vk16"}). Active decor slots:");
        RoomItemManager.DumpStatus();
    }

    /// <summary>
    /// Runtime update loop called from Plugin.Update().
    /// Handles diagnostic hotkey (F9 by default) to inspect and test room decor items in real time.
    /// </summary>
    public static void Update()
    {
        if (!Plugin.Config.EnableRoomItemRestoration.Value) return;

        // Diagnostic hotkey (F9) with 0.5s debounce
        if (Input.GetKeyDown(KeyCode.F9) && Time.time - _lastHotbarTime > 0.5f)
        {
            _lastHotbarTime = Time.time;
            HandleDiagnosticHotkey();
        }
    }

    /// <summary>
    /// Diagnostic helper for testing: logs status or seeds sample antiques into room_item.
    /// </summary>
    private static void HandleDiagnosticHotkey()
    {
        Plugin.Log.LogInfo("[RoomItemPatch] Hotkey (F9) triggered: Inspecting Hero Bedroom Decor...");
        
        var gd = RoomItemManager.GetGameData();
        if (gd == null || gd.room_item == null)
        {
            Plugin.Log.LogWarning("[RoomItemPatch] Cannot inspect room items - Suikoden 2 save session not currently active.");
            return;
        }

        // If slots are currently empty, provide a sample seeding test option
        bool anyOccupied = false;
        for (int i = 0; i < RoomItemManager.ROOM_ITEM_MAX; i++)
        {
            if (RoomItemManager.IsSlotOccupied(i))
            {
                anyOccupied = true;
                break;
            }
        }

        if (!anyOccupied)
        {
            Plugin.Log.LogInfo("[RoomItemPatch] All 8 bedroom slots are currently empty. Seeding initial display set for testing...");
            // Sample Antiques (use_cnt = 0x40 / 64)
            // Item 10: Celadon Urn
            // Item 18: Peeing Boy
            // Item 19: Bonsai Tree
            // Item 20: Knight Statue
            RoomItemManager.SetRoomItem(0, 10, 64); // Slot 0: Celadon Urn
            RoomItemManager.SetRoomItem(1, 18, 64); // Slot 1: Peeing Boy
            RoomItemManager.SetRoomItem(2, 19, 64); // Slot 2: Bonsai Tree
            RoomItemManager.SetRoomItem(3, 20, 64); // Slot 3: Knight Statue
            Plugin.Log.LogInfo("[RoomItemPatch] Sample antiques seeded! These will persist automatically into your next game save.");
        }

        RoomItemManager.DumpStatus();
    }
}
