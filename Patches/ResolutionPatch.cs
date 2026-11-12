using HarmonyLib;
using UnityEngine;

namespace PKCore.Patches;

public class ResolutionPatch
{
    private static bool _enabled = false;
    private static float _resolutionScale = 1.0f;
    private static bool _isApplyingScale = false;
    private static bool _hasAppliedOnce = false;
    private static bool _hasAppliedAfterInitialDisplay = false;
    private static bool _hasAppliedAfterIntro = false;

    private static bool ShouldScale => _enabled && !Mathf.Approximately(_resolutionScale, 1.0f);
    private static bool UseBorderlessWindow => Plugin.Config.EnableBorderlessWindow.Value;
    private static FullScreenMode TargetFullScreenMode =>
        UseBorderlessWindow ? FullScreenMode.Windowed : FullScreenMode.FullScreenWindow;

    private static void ScaleDimensions(ref int width, ref int height)
    {
        int originalWidth = width;
        int originalHeight = height;

        width = (int)(width * _resolutionScale);
        height = (int)(height * _resolutionScale);

        if (!_hasAppliedOnce)
        {
            if (Plugin.Config.DetailedLogs.Value)
                Plugin.Log.LogInfo($"✓ First SetResolution intercept: {originalWidth}x{originalHeight} -> {width}x{height}");
            _hasAppliedOnce = true;
        }
        else if (Plugin.Config.DetailedLogs.Value)
        {
            Plugin.Log.LogInfo($"✓ SetResolution intercept: {originalWidth}x{originalHeight} -> {width}x{height}");
        }
    }

    // Intercept ALL SetResolution overloads with LAST priority
    [HarmonyPatch(typeof(Screen), nameof(Screen.SetResolution), new[] { typeof(int), typeof(int), typeof(FullScreenMode) })]
    [HarmonyPrefix]
    [HarmonyPriority(Priority.Last)]
    static void SetResolution(ref int width, ref int height, ref FullScreenMode fullscreenMode)
    {
        if (_isApplyingScale || !ShouldScale) return;

        ScaleDimensions(ref width, ref height);
        fullscreenMode = TargetFullScreenMode;
    }

    [HarmonyPatch(typeof(Screen), nameof(Screen.SetResolution), new[] { typeof(int), typeof(int), typeof(FullScreenMode), typeof(RefreshRate) })]
    [HarmonyPrefix]
    [HarmonyPriority(Priority.Last)]
    static void SetResolutionWithRefreshRate(ref int width, ref int height, ref FullScreenMode fullscreenMode)
    {
        if (_isApplyingScale || !ShouldScale) return;

        ScaleDimensions(ref width, ref height);
        fullscreenMode = TargetFullScreenMode;
    }

    [HarmonyPatch(typeof(Screen), nameof(Screen.SetResolution), new[] { typeof(int), typeof(int), typeof(bool) })]
    [HarmonyPrefix]
    [HarmonyPriority(Priority.Last)]
    static void SetResolution2(ref int width, ref int height, ref bool fullscreen)
    {
        if (_isApplyingScale || !ShouldScale) return;

        ScaleDimensions(ref width, ref height);
        fullscreen = !UseBorderlessWindow;
    }

    [HarmonyPatch(typeof(Screen), nameof(Screen.SetResolution), new[] { typeof(int), typeof(int), typeof(bool), typeof(int) })]
    [HarmonyPrefix]
    [HarmonyPriority(Priority.Last)]
    static void SetResolution2WithRefreshRate(ref int width, ref int height, ref bool fullscreen)
    {
        if (_isApplyingScale || !ShouldScale) return;

        ScaleDimensions(ref width, ref height);
        fullscreen = !UseBorderlessWindow;
    }

    // Ensure Launcher / startup respects PKCore scaling right after DisplayConfig.SetInitialDisplay
    [HarmonyPatch(typeof(DisplayConfig), nameof(DisplayConfig.SetInitialDisplay))]
    [HarmonyPostfix]
    [HarmonyPriority(Priority.Last)]
    static void OnSetInitialDisplay()
    {
        if (!ShouldScale || _hasAppliedAfterInitialDisplay) return;
        _hasAppliedAfterInitialDisplay = true;

        if (!UseBorderlessWindow)
        {
            ApplyResolutionScaling("after SetInitialDisplay");
        }
    }

    // Apply resolution after splash screens complete (when title screen appears)
    // This works whether splash screens are shown or skipped by Suikoden Fix
    [HarmonyPatch(typeof(GSDTitleSelect), nameof(GSDTitleSelect.Main))]
    [HarmonyPostfix]
    [HarmonyPriority(Priority.Last)]
    static void OnTitleSelect(GSDTitleSelect __instance)
    {
        if (!ShouldScale || _hasAppliedAfterIntro) return;

        // Check if we've passed the splash screens (Konami logo) and reached sprite loading
        // WaitSpriteLoad happens after splash screens OR immediately if skipped
        // Also apply during later states to catch all cases
        if (__instance.step >= (int)GSDTitleSelect.State.WaitSpriteLoad)
        {
            _hasAppliedAfterIntro = true;
            ApplyResolutionScaling("after splash screens");
        }
    }

    private static void ApplyResolutionScaling(string reason)
    {
        if (Display.main == null || Display.main.systemWidth <= 0 || Display.main.systemHeight <= 0)
            return;

        // Use native display resolution as base
        int baseWidth = Display.main.systemWidth;
        int baseHeight = Display.main.systemHeight;

        int targetWidth = (int)(baseWidth * _resolutionScale);
        int targetHeight = (int)(baseHeight * _resolutionScale);
        FullScreenMode targetMode = TargetFullScreenMode;

        if (Screen.width == targetWidth && Screen.height == targetHeight && Screen.fullScreenMode == targetMode)
            return;

        Plugin.Log.LogInfo($"✓ Applying resolution {reason}: {baseWidth}x{baseHeight} -> {targetWidth}x{targetHeight} ({targetMode})");

        _isApplyingScale = true;
        try
        {
            Screen.SetResolution(targetWidth, targetHeight, targetMode);
        }
        finally
        {
            _isApplyingScale = false;
        }
    }

    public static void Initialize()
    {
        _resolutionScale = Plugin.Config.ResolutionScale.Value;
        _enabled = !Mathf.Approximately(_resolutionScale, 1.0f);

        if (_enabled)
        {
            ApplyResolutionScaling("at initialization");
        }

        if (Plugin.Config.DetailedLogs.Value)
        {
            Plugin.Log.LogInfo($"========================================");
            Plugin.Log.LogInfo($"Resolution Scaling Enabled");
            Plugin.Log.LogInfo($"Scale: {_resolutionScale}x (dynamic based on window size)");
            Plugin.Log.LogInfo($"Example: 1920x1080 at {_resolutionScale}x = {(int)(1920 * _resolutionScale)}x{(int)(1080 * _resolutionScale)}");
            Plugin.Log.LogInfo($"========================================");
            Plugin.Log.LogWarning("IMPORTANT: If using Suikoden Fix, set these in d3xMachina.suikoden_fix.cfg:");
            Plugin.Log.LogWarning("  Width = -1");
            Plugin.Log.LogWarning("  Height = -1");
            Plugin.Log.LogWarning("  Fullscreen = -1");
            Plugin.Log.LogWarning("This prevents conflicts between the two resolution systems!");
            Plugin.Log.LogInfo($"========================================");
        }
    }
}
