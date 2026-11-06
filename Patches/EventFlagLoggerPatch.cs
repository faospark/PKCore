extern alias GSD1;
extern alias GSD2;

using System;
using HarmonyLib;

namespace PKCore.Patches;

/// <summary>
/// Intercepts runtime event flag modifications in Suikoden I and Suikoden II,
/// outputting real-time flag offsets and bitmasks to the BepInEx console/log.
/// Controlled independently via ModConfiguration toggles (LogEventFlagsS1 and LogEventFlagsS2).
/// </summary>
public static class EventFlagLoggerPatch
{
    public static void Initialize(Harmony harmony)
    {
        try
        {
            harmony.PatchAll(typeof(EventFlagLoggerPatch));
            Plugin.Log.LogInfo("[EventFlagLoggerPatch] Initialized event flag logging hooks.");
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[EventFlagLoggerPatch] Failed to patch: {ex}");
        }
    }

    // =========================================================================
    // Suikoden II (GSD2) Flag Hooks
    // =========================================================================

    [HarmonyPatch(typeof(GSD2::GAME_WORK), nameof(GSD2::GAME_WORK.eventFlgON))]
    [HarmonyPostfix]
    public static void S2_OnEventFlagON(int _fno, byte _bno)
    {
        if (Plugin.Config?.LogEventFlagsS2?.Value != true) return;
        Plugin.Log.LogInfo($"[S2 FLAG ON ] Byte 0x{_fno:X2} ({_fno:D3}) |= Mask 0x{_bno:X2} (Bits: {Convert.ToString(_bno, 2).PadLeft(8, '0')})");
    }

    [HarmonyPatch(typeof(GSD2::GAME_WORK), nameof(GSD2::GAME_WORK.eventFlgOFF))]
    [HarmonyPostfix]
    public static void S2_OnEventFlagOFF(int _fno, byte _bno)
    {
        if (Plugin.Config?.LogEventFlagsS2?.Value != true) return;
        Plugin.Log.LogInfo($"[S2 FLAG OFF] Byte 0x{_fno:X2} ({_fno:D3}) &= ~Mask 0x{_bno:X2}");
    }

    // =========================================================================
    // Suikoden I (GSD1) Flag Hooks
    // =========================================================================

    [HarmonyPatch(typeof(GSD1::GAME_WORK), nameof(GSD1::GAME_WORK.SetStoryFlagS))]
    [HarmonyPostfix]
    public static void S1_OnSetStoryFlagS(int index, byte flag)
    {
        if (Plugin.Config?.LogEventFlagsS1?.Value != true) return;
        Plugin.Log.LogInfo($"[S1 STORY FLAG ON ] Index 0x{index:X2} ({index:D3}) |= Mask 0x{flag:X2} (Bits: {Convert.ToString(flag, 2).PadLeft(8, '0')})");
    }

    [HarmonyPatch(typeof(GSD1::GAME_WORK), nameof(GSD1::GAME_WORK.OverwriteStoryFlagS))]
    [HarmonyPostfix]
    public static void S1_OnOverwriteStoryFlagS(int index, byte value)
    {
        if (Plugin.Config?.LogEventFlagsS1?.Value != true) return;
        Plugin.Log.LogInfo($"[S1 STORY FLAG SET] Index 0x{index:X2} ({index:D3}) = 0x{value:X2} (Bits: {Convert.ToString(value, 2).PadLeft(8, '0')})");
    }

    [HarmonyPatch(typeof(GSD1::GAME_WORK), nameof(GSD1::GAME_WORK.SetTmpEventFlagS))]
    [HarmonyPostfix]
    public static void S1_OnSetTmpEventFlagS(int index, byte flag)
    {
        if (Plugin.Config?.LogEventFlagsS1?.Value != true) return;
        Plugin.Log.LogInfo($"[S1 TMP FLAG ON   ] Index 0x{index:X2} ({index:D3}) |= Mask 0x{flag:X2} (Bits: {Convert.ToString(flag, 2).PadLeft(8, '0')})");
    }

    [HarmonyPatch(typeof(GSD1::GAME_WORK), nameof(GSD1::GAME_WORK.ClearTmpEventFlagS))]
    [HarmonyPostfix]
    public static void S1_OnClearTmpEventFlagS(int index, byte flag)
    {
        if (Plugin.Config?.LogEventFlagsS1?.Value != true) return;
        Plugin.Log.LogInfo($"[S1 TMP FLAG OFF  ] Index 0x{index:X2} ({index:D3}) &= ~Mask 0x{flag:X2}");
    }

    [HarmonyPatch(typeof(GSD1::GAME_WORK), nameof(GSD1::GAME_WORK.OverwriteTmpEventFlagS))]
    [HarmonyPostfix]
    public static void S1_OnOverwriteTmpEventFlagS(int index, byte value)
    {
        if (Plugin.Config?.LogEventFlagsS1?.Value != true) return;
        Plugin.Log.LogInfo($"[S1 TMP FLAG SET  ] Index 0x{index:X2} ({index:D3}) = 0x{value:X2} (Bits: {Convert.ToString(value, 2).PadLeft(8, '0')})");
    }
}
