using HarmonyLib;
using UnityEngine;
using System;
using System.Runtime.InteropServices;

namespace PKCore.Patches;

/// <summary>
/// Borderless Window Patch:
/// Strips Win32 window decorations (caption titlebar, sizing borders, system menu)
/// while maintaining windowed mode. This allows the game to run at custom, smaller window sizes
/// without window chrome, distinct from Unity's full-screen -popupwindow mode.
/// </summary>
public class BorderlessWindowPatch
{
    private static bool _enabled = false;

    #region Win32 API
    [DllImport("user32.dll")]
    private static extern IntPtr GetActiveWindow();

    [DllImport("user32.dll")]
    private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

    [DllImport("user32.dll")]
    private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

    [DllImport("user32.dll")]
    private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

    private const int GWL_STYLE = -16;
    private const int WS_CAPTION = 0x00C00000;
    private const int WS_THICKFRAME = 0x00040000;
    private const int WS_SYSMENU = 0x00080000;
    private const int WS_MINIMIZEBOX = 0x00020000;
    private const int WS_MAXIMIZEBOX = 0x00010000;
    private const uint SWP_FRAMECHANGED = 0x0020;
    private const uint SWP_NOMOVE = 0x0002;
    private const uint SWP_NOSIZE = 0x0001;
    private const uint SWP_NOZORDER = 0x0004;
    private const uint SWP_SHOWWINDOW = 0x0040;
    #endregion

    public static void Initialize()
    {
        _enabled = Plugin.Config.EnableBorderlessWindow.Value;

        if (!_enabled)
        {
            Plugin.Log.LogInfo("Borderless window mode disabled.");
            return;
        }

        try
        {
            // Force windowed mode first so we can strip borders without locking to native screen resolution
            if (Screen.fullScreenMode != FullScreenMode.Windowed)
            {
                Screen.fullScreenMode = FullScreenMode.Windowed;
            }

            // Apply border removal slightly delayed to ensure the window handle is initialized
            if (PkCoreMainLoop.Instance != null)
            {
                PkCoreMainLoop.Instance.Invoke(nameof(PkCoreMainLoop.ApplyBorderlessStyle), 0.1f);
            }
            else
            {
                Plugin.Log.LogWarning("PkCoreMainLoop not initialized, cannot defer borderless style update.");
            }

            Plugin.Log.LogInfo("✓ Windowed Borderless mode enabled.");
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"✗ Failed to enable borderless window: {ex.Message}");
        }
    }

    public static void ApplyBorderlessStyle()
    {
        try
        {
            IntPtr hWnd = GetActiveWindow();
            if (hWnd == IntPtr.Zero) return;

            int style = GetWindowLong(hWnd, GWL_STYLE);

            // Remove caption, sizing border, system menu, and min/max buttons
            style &= ~(WS_CAPTION | WS_THICKFRAME | WS_SYSMENU | WS_MINIMIZEBOX | WS_MAXIMIZEBOX);

            SetWindowLong(hWnd, GWL_STYLE, style);

            // Trigger window frame refresh without altering position or size
            SetWindowPos(hWnd, IntPtr.Zero, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOZORDER | SWP_FRAMECHANGED | SWP_SHOWWINDOW);

            Plugin.Log.LogInfo("Applied Win32 borderless window style.");
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"Error applying borderless style: {ex.Message}");
        }
    }

    // Intercept SetResolution with FullScreenMode enum to enforce Windowed mode + Borderless style
    [HarmonyPatch(typeof(Screen), nameof(Screen.SetResolution), new[] { typeof(int), typeof(int), typeof(FullScreenMode) })]
    [HarmonyPrefix]
    [HarmonyPriority(Priority.Last)]
    static void SetResolution(ref int width, ref int height, ref FullScreenMode fullscreenMode)
    {
        if (_enabled)
        {
            fullscreenMode = FullScreenMode.Windowed;

            if (PkCoreMainLoop.Instance != null)
            {
                PkCoreMainLoop.Instance.Invoke(nameof(PkCoreMainLoop.ApplyBorderlessStyle), 0.1f);
            }
        }
    }

    // Intercept boolean overload of SetResolution
    [HarmonyPatch(typeof(Screen), nameof(Screen.SetResolution), new[] { typeof(int), typeof(int), typeof(bool) })]
    [HarmonyPrefix]
    [HarmonyPriority(Priority.Last)]
    static bool SetResolution(int width, int height, bool fullscreen)
    {
        if (_enabled)
        {
            Screen.SetResolution(width, height, FullScreenMode.Windowed);

            if (PkCoreMainLoop.Instance != null)
            {
                PkCoreMainLoop.Instance.Invoke(nameof(PkCoreMainLoop.ApplyBorderlessStyle), 0.1f);
            }

            return false;
        }
        return true;
    }
}
