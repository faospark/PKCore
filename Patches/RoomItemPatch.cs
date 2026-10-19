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

        bool isHeroRoom = IsHeroBedroom(mapId, __result);
        RoomItemUI.IsInHeroBedroom = isHeroRoom;

        if (isHeroRoom)
        {
            Plugin.Log.LogInfo($"[RoomItemPatch] Entered Hero's Bedroom (map: {mapId ?? "vk16"}). Active decor slots:");
            RoomItemManager.DumpStatus();
        }
    }

    /// <summary>
    /// Postfix on kantei.WinOpenFunc to detect when player talks to Lebrante at Castle Appraiser.
    /// </summary>
    [HarmonyPatch(typeof(GSD2::kantei), "WinOpenFunc")]
    [HarmonyPostfix]
    public static void OnKanteiWinOpen()
    {
        RoomItemUI.IsLebranteActive = true;
        Plugin.Log.LogInfo("[RoomItemPatch] Lebrante Appraisal window opened. Bedroom Curation interface ready.");
    }

    /// <summary>
    /// Postfix on kantei.WinCloseFunc to detect when player exits Lebrante's counter.
    /// </summary>
    [HarmonyPatch(typeof(GSD2::kantei), "WinCloseFunc")]
    [HarmonyPostfix]
    public static void OnKanteiWinClose()
    {
        RoomItemUI.IsLebranteActive = false;
        Plugin.Log.LogInfo("[RoomItemPatch] Lebrante Appraisal window closed.");
    }

    /// <summary>
    /// Runtime update loop called from Plugin.Update().
    /// Handles toggle hotkey (F9) to open/close the interactive Bedroom Decorator UI.
    /// </summary>
    public static void Update()
    {
        if (!Plugin.Config.EnableRoomItemRestoration.Value) return;

        // Keep room state updated from current map ID
        string curMap = MACHICON_OnMapInitPatch.CurrentMapId;
        if (!string.IsNullOrEmpty(curMap))
        {
            RoomItemUI.IsInHeroBedroom = curMap.StartsWith("vk16", StringComparison.OrdinalIgnoreCase);
        }

        try
        {
            var keyboard = UnityEngine.InputSystem.Keyboard.current;
            if (keyboard != null)
            {
                if (keyboard.f9Key.wasPressedThisFrame && Time.time - _lastHotbarTime > 0.3f)
                {
                    _lastHotbarTime = Time.time;
                    RoomItemUI.IsOpen = !RoomItemUI.IsOpen;
                    Plugin.Log.LogInfo($"[RoomItemPatch] Toggled Room Item Decorator UI (Open: {RoomItemUI.IsOpen})");
                }
                else if (keyboard.escapeKey.wasPressedThisFrame && RoomItemUI.IsOpen)
                {
                    RoomItemUI.IsOpen = false;
                }
            }
        }
        catch
        {
            // Suppress input polling exceptions to prevent spamming the trampoline
        }
    }
}
