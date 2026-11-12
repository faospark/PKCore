using HarmonyLib;
using Share.UI.Window;
using UnityEngine;

namespace PKCore.Patches;

/// <summary>
/// Keeps the game's display settings UI (<see cref="UIConfigWindow"/>) synchronized with PKCore's
/// active display mode and scaled resolution so opening Settings does not reset non-preset resolutions
/// back to 1920x1080 Windowed.
/// </summary>
public class DisplaySettingsUiPatch
{
    private static bool IsDisplayReinforcementActive =>
        Plugin.Config.EnableBorderlessWindow.Value ||
        !Mathf.Approximately(Plugin.Config.ResolutionScale.Value, 1.0f);

    private static FullScreenMode GetEnforcedMode()
    {
        if (Plugin.Config.EnableBorderlessWindow.Value)
            return FullScreenMode.Windowed;

        if (!Mathf.Approximately(Plugin.Config.ResolutionScale.Value, 1.0f))
            return FullScreenMode.FullScreenWindow;

        return Screen.fullScreenMode;
    }

    private static int FindMatchingPresetIndex(int activeWidth, int activeHeight, int fallbackIndex)
    {
        var presets = DisplayConfig.c_ScreenSize;
        if (presets == null || presets.Length == 0)
            return fallbackIndex;

        float scale = Plugin.Config.ResolutionScale.Value;
        int baseWidth = !Mathf.Approximately(scale, 1.0f) && scale > 0f
            ? Mathf.RoundToInt(activeWidth / scale)
            : activeWidth;
        int baseHeight = !Mathf.Approximately(scale, 1.0f) && scale > 0f
            ? Mathf.RoundToInt(activeHeight / scale)
            : activeHeight;

        for (int i = 0; i < presets.Length; i++)
        {
            var entry = presets[i];
            if (entry == null || entry.Length < 2) continue;

            if (Mathf.Abs(entry[0] - baseWidth) <= 2 && Mathf.Abs(entry[1] - baseHeight) <= 2)
                return i;
        }

        return fallbackIndex >= 0 && fallbackIndex < presets.Length ? fallbackIndex : 0;
    }

    /// <summary>
    /// Replaces <see cref="UIConfigWindow.checkScreen"/> when PKCore display patches are active.
    /// Prevents Unity/GSDShare from falling back to <c>Screen.SetResolution(1920, 1080, Windowed)</c>
    /// when the active resolution is not in <see cref="DisplayConfig.c_ScreenSize"/>.
    /// </summary>
    [HarmonyPatch(typeof(UIConfigWindow), nameof(UIConfigWindow.checkScreen))]
    [HarmonyPrefix]
    [HarmonyPriority(Priority.Last)]
    static bool CheckScreenPrefix(UIConfigWindow __instance)
    {
        if (!IsDisplayReinforcementActive || __instance == null)
            return true;

        FullScreenMode activeMode = GetEnforcedMode();
        int activeWidth = Screen.width;
        int activeHeight = Screen.height;
        int fallbackPreset = __instance.m_ScreenInfo != null ? (int)__instance.m_ScreenInfo.m_Size : 0;
        int matchedPreset = FindMatchingPresetIndex(activeWidth, activeHeight, fallbackPreset);

        if (__instance.m_ScreenInfo != null)
        {
            __instance.m_ScreenInfo.m_Size = (DisplayConfig.eScreen)matchedPreset;
            __instance.m_ScreenInfo.m_Width = activeWidth;
            __instance.m_ScreenInfo.m_Height = activeHeight;
            __instance.m_ScreenInfo.m_Mode = activeMode;
        }

        if (__instance.m_ScreenInfoBakup != null && __instance.m_ScreenInfo != null)
        {
            __instance.m_ScreenInfoBakup.Copy(__instance.m_ScreenInfo);
        }

        __instance.display_mode_index = (byte)(activeMode == FullScreenMode.Windowed ? 0 : 1);
        __instance.resolution_index = (byte)matchedPreset;

        if (__instance.now_display_mode != null)
        {
            __instance.now_display_mode.text = __instance.getDisplayModeName(activeMode);
        }

        if (__instance.now_resolution != null)
        {
            __instance.now_resolution.text = __instance.getResolutionString(activeWidth, activeHeight);
        }

        return false;
    }
}
