extern alias GSD1;
extern alias GSD2;

using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using HarmonyLib;
using ImGuiNET;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = System.Numerics.Vector2;
using Vector3 = System.Numerics.Vector3;
using Vector4 = System.Numerics.Vector4;

namespace PKCore.Patches;

/// <summary>
/// Dear ImGui in-game debug, inspection, and feature overlay for PKCore.
/// Powered by native DirectX 11 Present injection (via DearImGuiInjection / ImGui.NET).
/// Accessible via [F10]. Provides:
/// - Real-time Search and fast section jump buttons
/// - Dedicated Castle Bathhouse Inspector window and sidebar button
/// - General & Debug Section (Encounter None [F4], Mouse Cursor, Quick Heal, Live Map Snapshot)
/// - Combat & Runes (Memory Auto-Battle, Unlimited Runes, Unbalance Removal, Range Overrides, Battle HUD)
/// - Recovery & Progression (Smart Healing, Sajah Shop Early, Tenzan Chimera, Muse Survivors)
/// - Visuals & World (Save Crystal Color Picker, Sprite Filtering)
/// - Castle Bathhouse Inspector (12-slot tubs, gender separation, and restored Castle NPC visitors)
/// - Party & Roster Inspector (Active 8-character roster & visitor pools)
/// - Live Scene & Engine Telemetry
/// </summary>
public static class ImGuiOverlayUI
{
    public static bool IsOpen = false;
    public static bool ShowBathhouseWindow = false;
    public static bool ShowLocationHUD
    {
        get => Plugin.Config?.ShowLocationHUD?.Value ?? true;
        set
        {
            if (Plugin.Config?.ShowLocationHUD != null)
            {
                Plugin.Config.ShowLocationHUD.Value = value;
            }
        }
    }

    public static bool IsInjectorAvailable { get; private set; } = false;

    /// <summary>
    /// Thread-safe indicator for whether the game's pad and controller/keyboard input should be silenced.
    /// Active when the Dear ImGui overlay is open, bathhouse inspector is open, note input is active,
    /// or when the mouse cursor is hovering over any Dear ImGui window/widget (io.WantCaptureMouse).
    /// </summary>
    public static volatile bool IsInputBlocked = false;

    private static bool _initialized = false;
    private static float _lastToggleTime = 0f;
    private static string _searchQuery = "";
    private static int _selectedSection = 0;

    // Theme presets
    public enum ThemePreset
    {
        ClassicBlue,
        Matrix,
        ObsidianBlack,
        DarkMagenta
    }

    private static ThemePreset _currentTheme = ThemePreset.ClassicBlue;
    private static ThemePreset _appliedTheme = (ThemePreset)(-1);

    // Action feedback
    private static string _healFeedback = "";
    private static float _healFeedbackTime = 0f;
    private static string _memoryFeedback = "";
    private static float _memoryFeedbackTime = 0f;
    private static string _dumpFeedback = "";
    private static float _dumpFeedbackTime = 0f;
    private static string _locationNotes = "";
    private static bool _showHudNoteInput = false;
    private static bool _focusNoteInputNextFrame = false;
    private static float _hudWidth = 320f;
    private static float _hudHeight = 60f;

    // Main thread action queue for thread-safe mutations
    private static readonly Queue<Action> _mainThreadQueue = new Queue<Action>();

    // Cached telemetry data updated on Unity main thread
    private static string _cachedMapId = "(None)";
    private static int _cachedStars = 0;
    private static bool _cachedInBath = false;
    private static int _cachedBathersCount = 0;
    private static short _cachedHotVal = 0;
    private static short _cachedCoolVal = 0;
    private static readonly (byte id, string name, bool isFemale, int hp, int maxHp)[] _cachedParty = new (byte, string, bool, int, int)[8];
    private static readonly (int pos, int charaId, string name, bool isMen, string origin, string atlas)[] _cachedTubSlots = new (int, int, string, bool, string, string)[12];
    private static string _cachedBathVisitors = "(None)";

    public static void Initialize()
    {
        if (_initialized) return;
        _initialized = true;

        SyncThemeFromConfig();

        try
        {
            DearImGuiInjection.DearImGuiInjection.Render += DrawOverlay;
            IsInjectorAvailable = true;
            Plugin.Log.LogInfo("[ImGuiOverlayUI] Successfully registered DearImGuiInjection.Render hook.");
        }
        catch (Exception ex)
        {
            IsInjectorAvailable = false;
            Plugin.Log.LogWarning($"[ImGuiOverlayUI] DearImGuiInjection not available: {ex.Message}");
        }

        try
        {
            var harmony = new Harmony("faospark.pkcore.imguiinputblocker");
            try { harmony.PatchAll(typeof(GRInputManagerBlockerPatch)); }
            catch (Exception ex) { Plugin.Log.LogWarning($"[ImGuiOverlayUI] GRInputManager blocker skipped: {ex.Message}"); }

            try { harmony.PatchAll(typeof(G2PadBlockerPatch)); }
            catch (Exception ex) { Plugin.Log.LogWarning($"[ImGuiOverlayUI] G2_PAD blocker skipped: {ex.Message}"); }

            try { harmony.PatchAll(typeof(G1PadBlockerPatch)); }
            catch (Exception ex) { Plugin.Log.LogWarning($"[ImGuiOverlayUI] G1 Pad blocker skipped: {ex.Message}"); }

            Plugin.Log.LogInfo("[ImGuiOverlayUI] Successfully registered input blocker hooks.");
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[ImGuiOverlayUI] Failed to register input blocker hooks: {ex}");
        }
    }

    public static void SyncThemeFromConfig()
    {
        try
        {
            if (Plugin.Config?.ImGuiTheme != null)
            {
                string cfg = Plugin.Config.ImGuiTheme.Value?.ToLowerInvariant() ?? "";
                if (cfg.Contains("matrix")) _currentTheme = ThemePreset.Matrix;
                else if (cfg.Contains("obsidian") || cfg.Contains("black")) _currentTheme = ThemePreset.ObsidianBlack;
                else if (cfg.Contains("magenta") || cfg.Contains("purple") || cfg.Contains("dark magenta")) _currentTheme = ThemePreset.DarkMagenta;
                else _currentTheme = ThemePreset.ClassicBlue;
            }
        }
        catch { }
    }

    public static void SetTheme(ThemePreset theme, bool persist = true)
    {
        _currentTheme = theme;
        if (persist && Plugin.Config?.ImGuiTheme != null)
        {
            Plugin.Config.ImGuiTheme.Value = theme switch
            {
                ThemePreset.ClassicBlue => "Classic Blue",
                ThemePreset.Matrix => "Matrix",
                ThemePreset.ObsidianBlack => "Obsidian Black",
                ThemePreset.DarkMagenta => "Dark Magenta",
                _ => "Classic Blue"
            };
        }
        ApplyCurrentTheme();
    }

    public static Vector4 GetAccentColor()
    {
        return _currentTheme switch
        {
            ThemePreset.ClassicBlue => new Vector4(0.35f, 0.75f, 1.00f, 1f),
            ThemePreset.Matrix => new Vector4(0.20f, 1.00f, 0.40f, 1f),
            ThemePreset.ObsidianBlack => new Vector4(0.85f, 0.88f, 0.95f, 1f),
            ThemePreset.DarkMagenta => new Vector4(0.95f, 0.35f, 0.95f, 1f),
            _ => new Vector4(0.35f, 0.75f, 1.00f, 1f)
        };
    }

    public static string GetCurrentThemeName()
    {
        return _currentTheme switch
        {
            ThemePreset.ClassicBlue => "Classic Blue",
            ThemePreset.Matrix => "Matrix",
            ThemePreset.ObsidianBlack => "Obsidian Black",
            ThemePreset.DarkMagenta => "Dark Magenta",
            _ => "Classic Blue"
        };
    }

    private static void ApplyCurrentTheme()
    {
        try
        {
            var style = ImGui.GetStyle();
            _appliedTheme = _currentTheme;

            style.WindowRounding = 6.0f;
            style.ChildRounding = 4.0f;
            style.FrameRounding = 4.0f;
            style.PopupRounding = 4.0f;
            style.ScrollbarRounding = 9.0f;
            style.GrabRounding = 3.0f;
            style.TabRounding = 4.0f;
            style.WindowBorderSize = 1.0f;
            style.ChildBorderSize = 1.0f;
            style.PopupBorderSize = 1.0f;
            style.FrameBorderSize = 1.0f;
            style.TabBorderSize = 0.0f;
            style.WindowPadding = new Vector2(10f, 10f);
            style.FramePadding = new Vector2(8f, 5f);
            style.ItemSpacing = new Vector2(8f, 6f);
            style.ItemInnerSpacing = new Vector2(6f, 4f);
            style.ScrollbarSize = 14f;

            var colors = style.Colors;

            switch (_currentTheme)
            {
                case ThemePreset.ClassicBlue:
                    colors[(int)ImGuiCol.Text]                  = new Vector4(0.95f, 0.96f, 0.98f, 1.00f);
                    colors[(int)ImGuiCol.TextDisabled]          = new Vector4(0.50f, 0.60f, 0.72f, 1.00f);
                    colors[(int)ImGuiCol.WindowBg]              = new Vector4(0.06f, 0.09f, 0.14f, 0.96f);
                    colors[(int)ImGuiCol.ChildBg]               = new Vector4(0.08f, 0.12f, 0.18f, 0.85f);
                    colors[(int)ImGuiCol.PopupBg]               = new Vector4(0.08f, 0.12f, 0.18f, 0.98f);
                    colors[(int)ImGuiCol.Border]                = new Vector4(0.18f, 0.30f, 0.48f, 0.65f);
                    colors[(int)ImGuiCol.BorderShadow]          = new Vector4(0.00f, 0.00f, 0.00f, 0.00f);
                    colors[(int)ImGuiCol.FrameBg]               = new Vector4(0.12f, 0.18f, 0.28f, 0.70f);
                    colors[(int)ImGuiCol.FrameBgHovered]        = new Vector4(0.18f, 0.28f, 0.45f, 0.85f);
                    colors[(int)ImGuiCol.FrameBgActive]         = new Vector4(0.22f, 0.36f, 0.58f, 1.00f);
                    colors[(int)ImGuiCol.TitleBg]               = new Vector4(0.08f, 0.13f, 0.22f, 1.00f);
                    colors[(int)ImGuiCol.TitleBgActive]         = new Vector4(0.12f, 0.26f, 0.50f, 1.00f);
                    colors[(int)ImGuiCol.TitleBgCollapsed]      = new Vector4(0.06f, 0.09f, 0.14f, 0.75f);
                    colors[(int)ImGuiCol.MenuBarBg]             = new Vector4(0.10f, 0.15f, 0.24f, 1.00f);
                    colors[(int)ImGuiCol.ScrollbarBg]           = new Vector4(0.04f, 0.07f, 0.11f, 0.60f);
                    colors[(int)ImGuiCol.ScrollbarGrab]         = new Vector4(0.18f, 0.30f, 0.48f, 0.80f);
                    colors[(int)ImGuiCol.ScrollbarGrabHovered]  = new Vector4(0.24f, 0.40f, 0.65f, 0.90f);
                    colors[(int)ImGuiCol.ScrollbarGrabActive]   = new Vector4(0.30f, 0.52f, 0.85f, 1.00f);
                    colors[(int)ImGuiCol.CheckMark]             = new Vector4(0.35f, 0.75f, 1.00f, 1.00f);
                    colors[(int)ImGuiCol.SliderGrab]            = new Vector4(0.28f, 0.58f, 0.95f, 1.00f);
                    colors[(int)ImGuiCol.SliderGrabActive]      = new Vector4(0.40f, 0.75f, 1.00f, 1.00f);
                    colors[(int)ImGuiCol.Button]                = new Vector4(0.14f, 0.28f, 0.52f, 0.75f);
                    colors[(int)ImGuiCol.ButtonHovered]         = new Vector4(0.20f, 0.42f, 0.78f, 0.90f);
                    colors[(int)ImGuiCol.ButtonActive]          = new Vector4(0.26f, 0.52f, 0.95f, 1.00f);
                    colors[(int)ImGuiCol.Header]                = new Vector4(0.14f, 0.28f, 0.50f, 0.65f);
                    colors[(int)ImGuiCol.HeaderHovered]         = new Vector4(0.20f, 0.40f, 0.72f, 0.85f);
                    colors[(int)ImGuiCol.HeaderActive]          = new Vector4(0.26f, 0.50f, 0.90f, 1.00f);
                    colors[(int)ImGuiCol.Separator]             = new Vector4(0.18f, 0.30f, 0.48f, 0.60f);
                    colors[(int)ImGuiCol.SeparatorHovered]      = new Vector4(0.24f, 0.45f, 0.75f, 0.80f);
                    colors[(int)ImGuiCol.SeparatorActive]       = new Vector4(0.32f, 0.58f, 0.95f, 1.00f);
                    colors[(int)ImGuiCol.ResizeGrip]            = new Vector4(0.18f, 0.30f, 0.48f, 0.40f);
                    colors[(int)ImGuiCol.ResizeGripHovered]     = new Vector4(0.28f, 0.50f, 0.82f, 0.75f);
                    colors[(int)ImGuiCol.ResizeGripActive]      = new Vector4(0.35f, 0.65f, 1.00f, 1.00f);
                    colors[(int)ImGuiCol.Tab]                   = new Vector4(0.10f, 0.16f, 0.26f, 0.85f);
                    colors[(int)ImGuiCol.TabHovered]            = new Vector4(0.20f, 0.38f, 0.65f, 0.90f);
                    colors[(int)ImGuiCol.TabActive]             = new Vector4(0.16f, 0.32f, 0.56f, 1.00f);
                    colors[(int)ImGuiCol.TabUnfocused]          = new Vector4(0.08f, 0.12f, 0.18f, 0.80f);
                    colors[(int)ImGuiCol.TabUnfocusedActive]    = new Vector4(0.12f, 0.22f, 0.38f, 1.00f);
                    colors[(int)ImGuiCol.PlotLines]             = new Vector4(0.35f, 0.75f, 1.00f, 1.00f);
                    colors[(int)ImGuiCol.PlotLinesHovered]      = new Vector4(0.55f, 0.85f, 1.00f, 1.00f);
                    colors[(int)ImGuiCol.PlotHistogram]         = new Vector4(0.22f, 0.50f, 0.85f, 1.00f);
                    colors[(int)ImGuiCol.PlotHistogramHovered]  = new Vector4(0.32f, 0.65f, 1.00f, 1.00f);
                    colors[(int)ImGuiCol.TableHeaderBg]         = new Vector4(0.12f, 0.20f, 0.35f, 1.00f);
                    colors[(int)ImGuiCol.TableBorderStrong]     = new Vector4(0.20f, 0.35f, 0.55f, 0.70f);
                    colors[(int)ImGuiCol.TableBorderLight]      = new Vector4(0.15f, 0.25f, 0.40f, 0.50f);
                    colors[(int)ImGuiCol.TableRowBg]            = new Vector4(0.00f, 0.00f, 0.00f, 0.00f);
                    colors[(int)ImGuiCol.TableRowBgAlt]         = new Vector4(0.10f, 0.14f, 0.22f, 0.45f);
                    colors[(int)ImGuiCol.TextSelectedBg]        = new Vector4(0.18f, 0.42f, 0.82f, 0.55f);
                    colors[(int)ImGuiCol.NavHighlight]          = new Vector4(0.35f, 0.75f, 1.00f, 1.00f);
                    break;

                case ThemePreset.Matrix:
                    colors[(int)ImGuiCol.Text]                  = new Vector4(0.35f, 1.00f, 0.45f, 1.00f);
                    colors[(int)ImGuiCol.TextDisabled]          = new Vector4(0.16f, 0.55f, 0.24f, 1.00f);
                    colors[(int)ImGuiCol.WindowBg]              = new Vector4(0.02f, 0.04f, 0.02f, 0.97f);
                    colors[(int)ImGuiCol.ChildBg]               = new Vector4(0.03f, 0.06f, 0.03f, 0.85f);
                    colors[(int)ImGuiCol.PopupBg]               = new Vector4(0.04f, 0.07f, 0.04f, 0.97f);
                    colors[(int)ImGuiCol.Border]                = new Vector4(0.05f, 0.55f, 0.18f, 0.65f);
                    colors[(int)ImGuiCol.BorderShadow]          = new Vector4(0.00f, 0.25f, 0.05f, 0.25f);
                    colors[(int)ImGuiCol.FrameBg]               = new Vector4(0.04f, 0.12f, 0.05f, 0.75f);
                    colors[(int)ImGuiCol.FrameBgHovered]        = new Vector4(0.07f, 0.24f, 0.09f, 0.85f);
                    colors[(int)ImGuiCol.FrameBgActive]         = new Vector4(0.10f, 0.35f, 0.14f, 1.00f);
                    colors[(int)ImGuiCol.TitleBg]               = new Vector4(0.02f, 0.08f, 0.03f, 1.00f);
                    colors[(int)ImGuiCol.TitleBgActive]         = new Vector4(0.04f, 0.18f, 0.06f, 1.00f);
                    colors[(int)ImGuiCol.TitleBgCollapsed]      = new Vector4(0.02f, 0.05f, 0.02f, 0.75f);
                    colors[(int)ImGuiCol.MenuBarBg]             = new Vector4(0.03f, 0.10f, 0.04f, 1.00f);
                    colors[(int)ImGuiCol.ScrollbarBg]           = new Vector4(0.02f, 0.05f, 0.02f, 0.60f);
                    colors[(int)ImGuiCol.ScrollbarGrab]         = new Vector4(0.06f, 0.28f, 0.10f, 0.80f);
                    colors[(int)ImGuiCol.ScrollbarGrabHovered]  = new Vector4(0.09f, 0.45f, 0.16f, 0.90f);
                    colors[(int)ImGuiCol.ScrollbarGrabActive]   = new Vector4(0.14f, 0.65f, 0.24f, 1.00f);
                    colors[(int)ImGuiCol.CheckMark]             = new Vector4(0.20f, 1.00f, 0.40f, 1.00f);
                    colors[(int)ImGuiCol.SliderGrab]            = new Vector4(0.15f, 0.85f, 0.30f, 1.00f);
                    colors[(int)ImGuiCol.SliderGrabActive]      = new Vector4(0.30f, 1.00f, 0.50f, 1.00f);
                    colors[(int)ImGuiCol.Button]                = new Vector4(0.05f, 0.22f, 0.08f, 0.80f);
                    colors[(int)ImGuiCol.ButtonHovered]         = new Vector4(0.08f, 0.38f, 0.13f, 0.90f);
                    colors[(int)ImGuiCol.ButtonActive]          = new Vector4(0.12f, 0.55f, 0.18f, 1.00f);
                    colors[(int)ImGuiCol.Header]                = new Vector4(0.05f, 0.20f, 0.08f, 0.70f);
                    colors[(int)ImGuiCol.HeaderHovered]         = new Vector4(0.08f, 0.35f, 0.13f, 0.85f);
                    colors[(int)ImGuiCol.HeaderActive]          = new Vector4(0.12f, 0.50f, 0.18f, 1.00f);
                    colors[(int)ImGuiCol.Separator]             = new Vector4(0.08f, 0.38f, 0.13f, 0.60f);
                    colors[(int)ImGuiCol.SeparatorHovered]      = new Vector4(0.12f, 0.55f, 0.20f, 0.80f);
                    colors[(int)ImGuiCol.SeparatorActive]       = new Vector4(0.18f, 0.75f, 0.28f, 1.00f);
                    colors[(int)ImGuiCol.ResizeGrip]            = new Vector4(0.05f, 0.28f, 0.10f, 0.40f);
                    colors[(int)ImGuiCol.ResizeGripHovered]     = new Vector4(0.10f, 0.50f, 0.18f, 0.75f);
                    colors[(int)ImGuiCol.ResizeGripActive]      = new Vector4(0.20f, 0.85f, 0.32f, 1.00f);
                    colors[(int)ImGuiCol.Tab]                   = new Vector4(0.04f, 0.14f, 0.06f, 0.85f);
                    colors[(int)ImGuiCol.TabHovered]            = new Vector4(0.08f, 0.32f, 0.12f, 0.90f);
                    colors[(int)ImGuiCol.TabActive]             = new Vector4(0.06f, 0.24f, 0.09f, 1.00f);
                    colors[(int)ImGuiCol.TabUnfocused]          = new Vector4(0.03f, 0.09f, 0.04f, 0.80f);
                    colors[(int)ImGuiCol.TabUnfocusedActive]    = new Vector4(0.05f, 0.18f, 0.07f, 1.00f);
                    colors[(int)ImGuiCol.PlotLines]             = new Vector4(0.20f, 1.00f, 0.40f, 1.00f);
                    colors[(int)ImGuiCol.PlotLinesHovered]      = new Vector4(0.40f, 1.00f, 0.60f, 1.00f);
                    colors[(int)ImGuiCol.PlotHistogram]         = new Vector4(0.10f, 0.70f, 0.25f, 1.00f);
                    colors[(int)ImGuiCol.PlotHistogramHovered]  = new Vector4(0.20f, 0.90f, 0.35f, 1.00f);
                    colors[(int)ImGuiCol.TableHeaderBg]         = new Vector4(0.04f, 0.15f, 0.06f, 1.00f);
                    colors[(int)ImGuiCol.TableBorderStrong]     = new Vector4(0.08f, 0.42f, 0.15f, 0.70f);
                    colors[(int)ImGuiCol.TableBorderLight]      = new Vector4(0.05f, 0.28f, 0.10f, 0.50f);
                    colors[(int)ImGuiCol.TableRowBg]            = new Vector4(0.00f, 0.00f, 0.00f, 0.00f);
                    colors[(int)ImGuiCol.TableRowBgAlt]         = new Vector4(0.04f, 0.09f, 0.04f, 0.45f);
                    colors[(int)ImGuiCol.TextSelectedBg]        = new Vector4(0.05f, 0.45f, 0.15f, 0.45f);
                    colors[(int)ImGuiCol.NavHighlight]          = new Vector4(0.20f, 1.00f, 0.40f, 1.00f);
                    break;

                case ThemePreset.ObsidianBlack:
                    colors[(int)ImGuiCol.Text]                  = new Vector4(0.92f, 0.93f, 0.95f, 1.00f);
                    colors[(int)ImGuiCol.TextDisabled]          = new Vector4(0.48f, 0.50f, 0.55f, 1.00f);
                    colors[(int)ImGuiCol.WindowBg]              = new Vector4(0.05f, 0.05f, 0.06f, 0.98f);
                    colors[(int)ImGuiCol.ChildBg]               = new Vector4(0.07f, 0.07f, 0.08f, 0.85f);
                    colors[(int)ImGuiCol.PopupBg]               = new Vector4(0.08f, 0.08f, 0.09f, 0.98f);
                    colors[(int)ImGuiCol.Border]                = new Vector4(0.22f, 0.23f, 0.26f, 0.70f);
                    colors[(int)ImGuiCol.BorderShadow]          = new Vector4(0.00f, 0.00f, 0.00f, 0.00f);
                    colors[(int)ImGuiCol.FrameBg]               = new Vector4(0.11f, 0.11f, 0.13f, 0.80f);
                    colors[(int)ImGuiCol.FrameBgHovered]        = new Vector4(0.18f, 0.18f, 0.21f, 0.85f);
                    colors[(int)ImGuiCol.FrameBgActive]         = new Vector4(0.25f, 0.25f, 0.29f, 1.00f);
                    colors[(int)ImGuiCol.TitleBg]               = new Vector4(0.06f, 0.06f, 0.07f, 1.00f);
                    colors[(int)ImGuiCol.TitleBgActive]         = new Vector4(0.13f, 0.13f, 0.15f, 1.00f);
                    colors[(int)ImGuiCol.TitleBgCollapsed]      = new Vector4(0.05f, 0.05f, 0.06f, 0.75f);
                    colors[(int)ImGuiCol.MenuBarBg]             = new Vector4(0.09f, 0.09f, 0.10f, 1.00f);
                    colors[(int)ImGuiCol.ScrollbarBg]           = new Vector4(0.04f, 0.04f, 0.05f, 0.60f);
                    colors[(int)ImGuiCol.ScrollbarGrab]         = new Vector4(0.20f, 0.20f, 0.23f, 0.80f);
                    colors[(int)ImGuiCol.ScrollbarGrabHovered]  = new Vector4(0.28f, 0.28f, 0.32f, 0.90f);
                    colors[(int)ImGuiCol.ScrollbarGrabActive]   = new Vector4(0.38f, 0.38f, 0.44f, 1.00f);
                    colors[(int)ImGuiCol.CheckMark]             = new Vector4(0.85f, 0.88f, 0.95f, 1.00f);
                    colors[(int)ImGuiCol.SliderGrab]            = new Vector4(0.55f, 0.58f, 0.65f, 1.00f);
                    colors[(int)ImGuiCol.SliderGrabActive]      = new Vector4(0.80f, 0.83f, 0.90f, 1.00f);
                    colors[(int)ImGuiCol.Button]                = new Vector4(0.14f, 0.14f, 0.17f, 0.85f);
                    colors[(int)ImGuiCol.ButtonHovered]         = new Vector4(0.22f, 0.22f, 0.26f, 0.95f);
                    colors[(int)ImGuiCol.ButtonActive]          = new Vector4(0.30f, 0.30f, 0.36f, 1.00f);
                    colors[(int)ImGuiCol.Header]                = new Vector4(0.14f, 0.14f, 0.17f, 0.70f);
                    colors[(int)ImGuiCol.HeaderHovered]         = new Vector4(0.22f, 0.22f, 0.26f, 0.85f);
                    colors[(int)ImGuiCol.HeaderActive]          = new Vector4(0.30f, 0.30f, 0.35f, 1.00f);
                    colors[(int)ImGuiCol.Separator]             = new Vector4(0.18f, 0.19f, 0.23f, 0.65f);
                    colors[(int)ImGuiCol.SeparatorHovered]      = new Vector4(0.26f, 0.27f, 0.32f, 0.80f);
                    colors[(int)ImGuiCol.SeparatorActive]       = new Vector4(0.36f, 0.38f, 0.45f, 1.00f);
                    colors[(int)ImGuiCol.ResizeGrip]            = new Vector4(0.18f, 0.18f, 0.22f, 0.40f);
                    colors[(int)ImGuiCol.ResizeGripHovered]     = new Vector4(0.28f, 0.28f, 0.34f, 0.75f);
                    colors[(int)ImGuiCol.ResizeGripActive]      = new Vector4(0.40f, 0.40f, 0.48f, 1.00f);
                    colors[(int)ImGuiCol.Tab]                   = new Vector4(0.09f, 0.09f, 0.11f, 0.85f);
                    colors[(int)ImGuiCol.TabHovered]            = new Vector4(0.18f, 0.18f, 0.22f, 0.90f);
                    colors[(int)ImGuiCol.TabActive]             = new Vector4(0.14f, 0.14f, 0.17f, 1.00f);
                    colors[(int)ImGuiCol.TabUnfocused]          = new Vector4(0.07f, 0.07f, 0.08f, 0.80f);
                    colors[(int)ImGuiCol.TabUnfocusedActive]    = new Vector4(0.11f, 0.11f, 0.13f, 1.00f);
                    colors[(int)ImGuiCol.PlotLines]             = new Vector4(0.85f, 0.88f, 0.95f, 1.00f);
                    colors[(int)ImGuiCol.PlotLinesHovered]      = new Vector4(1.00f, 1.00f, 1.00f, 1.00f);
                    colors[(int)ImGuiCol.PlotHistogram]         = new Vector4(0.45f, 0.48f, 0.55f, 1.00f);
                    colors[(int)ImGuiCol.PlotHistogramHovered]  = new Vector4(0.65f, 0.68f, 0.75f, 1.00f);
                    colors[(int)ImGuiCol.TableHeaderBg]         = new Vector4(0.10f, 0.10f, 0.12f, 1.00f);
                    colors[(int)ImGuiCol.TableBorderStrong]     = new Vector4(0.22f, 0.23f, 0.27f, 0.70f);
                    colors[(int)ImGuiCol.TableBorderLight]      = new Vector4(0.15f, 0.16f, 0.18f, 0.50f);
                    colors[(int)ImGuiCol.TableRowBg]            = new Vector4(0.00f, 0.00f, 0.00f, 0.00f);
                    colors[(int)ImGuiCol.TableRowBgAlt]         = new Vector4(0.08f, 0.08f, 0.10f, 0.45f);
                    colors[(int)ImGuiCol.TextSelectedBg]        = new Vector4(0.35f, 0.38f, 0.45f, 0.50f);
                    colors[(int)ImGuiCol.NavHighlight]          = new Vector4(0.85f, 0.88f, 0.95f, 1.00f);
                    break;

                case ThemePreset.DarkMagenta:
                    colors[(int)ImGuiCol.Text]                  = new Vector4(0.97f, 0.92f, 1.00f, 1.00f);
                    colors[(int)ImGuiCol.TextDisabled]          = new Vector4(0.58f, 0.42f, 0.65f, 1.00f);
                    colors[(int)ImGuiCol.WindowBg]              = new Vector4(0.07f, 0.04f, 0.10f, 0.97f);
                    colors[(int)ImGuiCol.ChildBg]               = new Vector4(0.09f, 0.05f, 0.13f, 0.85f);
                    colors[(int)ImGuiCol.PopupBg]               = new Vector4(0.10f, 0.06f, 0.15f, 0.98f);
                    colors[(int)ImGuiCol.Border]                = new Vector4(0.48f, 0.15f, 0.52f, 0.65f);
                    colors[(int)ImGuiCol.BorderShadow]          = new Vector4(0.18f, 0.02f, 0.22f, 0.25f);
                    colors[(int)ImGuiCol.FrameBg]               = new Vector4(0.16f, 0.08f, 0.22f, 0.75f);
                    colors[(int)ImGuiCol.FrameBgHovered]        = new Vector4(0.26f, 0.12f, 0.36f, 0.85f);
                    colors[(int)ImGuiCol.FrameBgActive]         = new Vector4(0.38f, 0.16f, 0.52f, 1.00f);
                    colors[(int)ImGuiCol.TitleBg]               = new Vector4(0.10f, 0.05f, 0.14f, 1.00f);
                    colors[(int)ImGuiCol.TitleBgActive]         = new Vector4(0.24f, 0.08f, 0.34f, 1.00f);
                    colors[(int)ImGuiCol.TitleBgCollapsed]      = new Vector4(0.07f, 0.04f, 0.10f, 0.75f);
                    colors[(int)ImGuiCol.MenuBarBg]             = new Vector4(0.12f, 0.06f, 0.17f, 1.00f);
                    colors[(int)ImGuiCol.ScrollbarBg]           = new Vector4(0.05f, 0.03f, 0.08f, 0.60f);
                    colors[(int)ImGuiCol.ScrollbarGrab]         = new Vector4(0.30f, 0.10f, 0.42f, 0.80f);
                    colors[(int)ImGuiCol.ScrollbarGrabHovered]  = new Vector4(0.46f, 0.15f, 0.64f, 0.90f);
                    colors[(int)ImGuiCol.ScrollbarGrabActive]   = new Vector4(0.68f, 0.20f, 0.90f, 1.00f);
                    colors[(int)ImGuiCol.CheckMark]             = new Vector4(0.95f, 0.35f, 0.95f, 1.00f);
                    colors[(int)ImGuiCol.SliderGrab]            = new Vector4(0.78f, 0.25f, 0.85f, 1.00f);
                    colors[(int)ImGuiCol.SliderGrabActive]      = new Vector4(0.98f, 0.45f, 1.00f, 1.00f);
                    colors[(int)ImGuiCol.Button]                = new Vector4(0.26f, 0.09f, 0.36f, 0.80f);
                    colors[(int)ImGuiCol.ButtonHovered]         = new Vector4(0.42f, 0.14f, 0.58f, 0.90f);
                    colors[(int)ImGuiCol.ButtonActive]          = new Vector4(0.60f, 0.18f, 0.80f, 1.00f);
                    colors[(int)ImGuiCol.Header]                = new Vector4(0.25f, 0.09f, 0.35f, 0.70f);
                    colors[(int)ImGuiCol.HeaderHovered]         = new Vector4(0.38f, 0.13f, 0.52f, 0.85f);
                    colors[(int)ImGuiCol.HeaderActive]          = new Vector4(0.55f, 0.18f, 0.75f, 1.00f);
                    colors[(int)ImGuiCol.Separator]             = new Vector4(0.40f, 0.14f, 0.52f, 0.60f);
                    colors[(int)ImGuiCol.SeparatorHovered]      = new Vector4(0.58f, 0.20f, 0.75f, 0.80f);
                    colors[(int)ImGuiCol.SeparatorActive]       = new Vector4(0.82f, 0.28f, 1.00f, 1.00f);
                    colors[(int)ImGuiCol.ResizeGrip]            = new Vector4(0.30f, 0.10f, 0.42f, 0.40f);
                    colors[(int)ImGuiCol.ResizeGripHovered]     = new Vector4(0.50f, 0.16f, 0.70f, 0.75f);
                    colors[(int)ImGuiCol.ResizeGripActive]      = new Vector4(0.75f, 0.25f, 1.00f, 1.00f);
                    colors[(int)ImGuiCol.Tab]                   = new Vector4(0.18f, 0.07f, 0.25f, 0.85f);
                    colors[(int)ImGuiCol.TabHovered]            = new Vector4(0.35f, 0.12f, 0.48f, 0.90f);
                    colors[(int)ImGuiCol.TabActive]             = new Vector4(0.28f, 0.10f, 0.40f, 1.00f);
                    colors[(int)ImGuiCol.TabUnfocused]          = new Vector4(0.12f, 0.05f, 0.17f, 0.80f);
                    colors[(int)ImGuiCol.TabUnfocusedActive]    = new Vector4(0.20f, 0.08f, 0.28f, 1.00f);
                    colors[(int)ImGuiCol.PlotLines]             = new Vector4(0.95f, 0.35f, 0.95f, 1.00f);
                    colors[(int)ImGuiCol.PlotLinesHovered]      = new Vector4(1.00f, 0.55f, 1.00f, 1.00f);
                    colors[(int)ImGuiCol.PlotHistogram]         = new Vector4(0.65f, 0.18f, 0.85f, 1.00f);
                    colors[(int)ImGuiCol.PlotHistogramHovered]  = new Vector4(0.85f, 0.28f, 1.00f, 1.00f);
                    colors[(int)ImGuiCol.TableHeaderBg]         = new Vector4(0.16f, 0.07f, 0.24f, 1.00f);
                    colors[(int)ImGuiCol.TableBorderStrong]     = new Vector4(0.42f, 0.14f, 0.56f, 0.70f);
                    colors[(int)ImGuiCol.TableBorderLight]      = new Vector4(0.28f, 0.10f, 0.38f, 0.50f);
                    colors[(int)ImGuiCol.TableRowBg]            = new Vector4(0.00f, 0.00f, 0.00f, 0.00f);
                    colors[(int)ImGuiCol.TableRowBgAlt]         = new Vector4(0.11f, 0.06f, 0.16f, 0.45f);
                    colors[(int)ImGuiCol.TextSelectedBg]        = new Vector4(0.50f, 0.15f, 0.65f, 0.50f);
                    colors[(int)ImGuiCol.NavHighlight]          = new Vector4(0.95f, 0.35f, 0.95f, 1.00f);
                    break;
            }
        }
        catch (Exception ex)
        {
            Plugin.Log.LogWarning($"[ImGuiOverlayUI] ApplyCurrentTheme error: {ex.Message}");
        }
    }

    private static System.Reflection.PropertyInfo _isCursorVisibleProp;
    private static System.Reflection.MethodInfo _updateCursorVisibilityMethod;
    private static bool? _pendingCursorVisible = null;

    public static void RequestCursorVisible(bool visible)
    {
        _pendingCursorVisible = visible;
    }

    public static void SetImGuiCursorVisible(bool visible)
    {
        try
        {
            if (_isCursorVisibleProp == null)
            {
                var type = typeof(DearImGuiInjection.DearImGuiInjection);
                _isCursorVisibleProp = type.GetProperty("IsCursorVisible", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
                _updateCursorVisibilityMethod = type.GetMethod("UpdateCursorVisibility", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            }

            _isCursorVisibleProp?.SetValue(null, visible);
            _updateCursorVisibilityMethod?.Invoke(null, null);

            MouseCursorPatch.IsEnabled = visible;
        }
        catch (Exception ex)
        {
            Plugin.Log.LogWarning($"[ImGuiOverlayUI] SetImGuiCursorVisible error: {ex.Message}");
        }
    }

    public static void RunOnMainThread(Action action)
    {
        if (action == null) return;
        lock (_mainThreadQueue)
        {
            _mainThreadQueue.Enqueue(action);
        }
    }

    /// <summary>
    /// Update loop checking for F10 hotkey and refreshing state cache on Unity main thread.
    /// </summary>
    public static void Update()
    {
        // 1. Process queued actions
        lock (_mainThreadQueue)
        {
            while (_mainThreadQueue.Count > 0)
            {
                try { _mainThreadQueue.Dequeue().Invoke(); }
                catch (Exception ex) { Plugin.Log.LogError($"[ImGuiOverlayUI] Queue error: {ex}"); }
            }
        }

        // 2. Process pending cursor visibility requested from render thread
        if (_pendingCursorVisible.HasValue)
        {
            bool val = _pendingCursorVisible.Value;
            _pendingCursorVisible = null;
            SetImGuiCursorVisible(val);
        }

        // 2. Hotkey check [F10]
        try
        {
            var keyboard = UnityEngine.InputSystem.Keyboard.current;
            if (keyboard != null)
            {
                if (keyboard.f10Key.wasPressedThisFrame && Time.time - _lastToggleTime > 0.25f)
                {
                    _lastToggleTime = Time.time;
                    IsOpen = !IsOpen;
                    IsInputBlocked = IsOpen || ShowBathhouseWindow || _showHudNoteInput;

                    SetImGuiCursorVisible(IsOpen || ShowBathhouseWindow || _showHudNoteInput);
                    Plugin.Log.LogInfo($"[ImGuiOverlayUI] Toggled Dear ImGui Overlay (Open: {IsOpen})");
                }
                else if (keyboard.escapeKey.wasPressedThisFrame)
                {
                    if (_showHudNoteInput && !IsOpen)
                    {
                        _showHudNoteInput = false;
                        SetImGuiCursorVisible(false);
                    }
                    else if (IsOpen || ShowBathhouseWindow)
                    {
                        IsOpen = false;
                        ShowBathhouseWindow = false;
                        SetImGuiCursorVisible(false);
                    }
                    IsInputBlocked = IsOpen || ShowBathhouseWindow || _showHudNoteInput;
                }
                else if (keyboard.numpad5Key.wasPressedThisFrame)
                {
                    DumpCurrentLocation();
                }
                else if (keyboard.numpad6Key.wasPressedThisFrame || keyboard.f9Key.wasPressedThisFrame)
                {
                    _showHudNoteInput = !_showHudNoteInput;
                    _focusNoteInputNextFrame = _showHudNoteInput;
                    IsInputBlocked = _showHudNoteInput || IsOpen || ShowBathhouseWindow;
                    SetImGuiCursorVisible(_showHudNoteInput || IsOpen || ShowBathhouseWindow);
                }
            }

            // Detect mouse click inside bottom-left HUD bounds to activate note text field
            if (ShowLocationHUD && !IsOpen && !_showHudNoteInput)
            {
                var mouse = UnityEngine.InputSystem.Mouse.current;
                if (mouse != null && mouse.leftButton.wasPressedThisFrame)
                {
                    UnityEngine.Vector2 mPos = mouse.position.ReadValue();
                    if (mPos.x >= 0 && mPos.x <= _hudWidth && mPos.y >= 0 && mPos.y <= _hudHeight)
                    {
                        _showHudNoteInput = true;
                        _focusNoteInputNextFrame = true;
                        IsInputBlocked = true;
                        SetImGuiCursorVisible(true);
                    }
                }
            }
        }
        catch { }

        // 3. Cache telemetry only when needed
        if (IsOpen || ShowBathhouseWindow || ShowLocationHUD)
        {
            UpdateTelemetryCache();
        }
    }

    private static void UpdateTelemetryCache()
    {
        try
        {
            _cachedMapId = MACHICON_OnMapInitPatch.CurrentMapId ?? "(None)";
            try { _cachedStars = GSD2::G2_SYS.Mem108Chk(0); } catch { _cachedStars = 0; }

            _cachedInBath = NPCBathVisitorPatch.IsInsideBath;
            var fw = NPCBathVisitorPatch.CurrentFuroWork;
            if (fw != null)
            {
                _cachedBathersCount = fw.furo_chara_num;
                _cachedHotVal = (short)fw.furo_hot_val;
                _cachedCoolVal = (short)fw.furo_cool_val;
            }
            else
            {
                _cachedBathersCount = NPCBathVisitorPatch.ActivePartyInBath.Count;
                _cachedHotVal = 0;
                _cachedCoolVal = 0;
            }

            // Party cache
            var party = GSD2::G2_SYS.G2_party_dat();
            var chaArr = party?.party_cha_no;
            for (int i = 0; i < 8; i++)
            {
                byte id = (chaArr != null && i < chaArr.Length) ? chaArr[i] : (byte)0;
                if (id > 0)
                {
                    string name = GetCharacterName(id);
                    bool isFemale = NPCBathVisitorPatch.FemaleCharaIds.Contains(id);
                    int hp = 0, maxHp = 0;
                    try
                    {
                        var varia = GSD2::G2_SYS.G2_varia_dat(id);
                        if (varia != null) { hp = varia.now_hp; maxHp = varia.max_hp; }
                    }
                    catch { }
                    _cachedParty[i] = (id, name, isFemale, hp, maxHp);
                }
                else
                {
                    _cachedParty[i] = (0, "(Empty)", false, 0, 0);
                }
            }

            // Bath tub slots cache (12 slots)
            for (int pos = 0; pos < 12; pos++)
            {
                bool isMen = pos < 6;
                int charaId = GetBatherAtPosition(pos, fw);
                if (charaId > 0)
                {
                    string name = GetCharacterName(charaId);
                    string origin = GetBatherOrigin(charaId);
                    int atlasIdx = (charaId - 1) / 5;
                    int slotIdx = (charaId - 1) % 5;
                    string atlasStr = $"hp_furo_{atlasIdx:02d}_atlas (Slot {slotIdx})";
                    _cachedTubSlots[pos] = (pos, charaId, name, isMen, origin, atlasStr);
                }
                else
                {
                    _cachedTubSlots[pos] = (pos, 0, "[Empty Tub Position]", isMen, "", "");
                }
            }

            // Visitors string
            _cachedBathVisitors = NPCBathVisitorPatch.ActiveBathVisitors.Count > 0
                ? string.Join(", ", GetVisitorNames(NPCBathVisitorPatch.ActiveBathVisitors))
                : "(None -- party alone or special bath vignette active)";
        }
        catch { }
    }

    public static void DumpCurrentLocation()
    {
        try
        {
            UpdateTelemetryCache();

            string logsDir = Path.Combine(BepInEx.Paths.GameRootPath, "PKCore", "Logs");
            if (!Directory.Exists(logsDir))
            {
                Directory.CreateDirectory(logsDir);
            }

            string logPath = Path.Combine(logsDir, "locationdump.log");
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            string notePart = !string.IsNullOrWhiteSpace(_locationNotes) ? $" | Note: {_locationNotes.Trim()}" : "";
            string entry = $"[{timestamp}] Location: {_cachedMapId} | Stars: {_cachedStars} / 108{notePart}" + Environment.NewLine;
            File.AppendAllText(logPath, entry);

            _dumpFeedback = $"Saved! ({DateTime.Now:HH:mm:ss})";
            _dumpFeedbackTime = Time.time;

            Plugin.Log.LogInfo($"[ImGuiOverlayUI] [NumPad 5] Location dumped to {logPath}: {_cachedMapId}{notePart}");
        }
        catch (Exception ex)
        {
            _dumpFeedback = $"Error: {ex.Message}";
            _dumpFeedbackTime = Time.time;
            Plugin.Log.LogError($"[ImGuiOverlayUI] Failed to dump location: {ex}");
        }
    }

    public static void OpenDumpLocation()
    {
        System.Threading.ThreadPool.QueueUserWorkItem(_ =>
        {
            try
            {
                string logsDir = Path.Combine(BepInEx.Paths.GameRootPath, "PKCore", "Logs");
                if (!Directory.Exists(logsDir))
                {
                    Directory.CreateDirectory(logsDir);
                }

                string logPath = Path.Combine(logsDir, "locationdump.log");
                string target = File.Exists(logPath) ? logPath : logsDir;

                var psi = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = target,
                    UseShellExecute = true
                };
                System.Diagnostics.Process.Start(psi);
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"[ImGuiOverlayUI] Failed to open dump location: {ex}");
            }
        });
    }

    /// <summary>
    /// Renders a small, non-intrusive HUD in the bottom-left corner of the screen when the main overlay is closed.
    /// Displays current map location with interactive notes editing and direct dumping.
    /// </summary>
    private static void DrawBottomLocationHUD()
    {
        try
        {
            var io = ImGui.GetIO();
            // Positioned at bottom-left with 14px padding (pivot at bottom-left (0, 1))
            ImGui.SetNextWindowPos(new Vector2(14f, io.DisplaySize.Y - 14f), ImGuiCond.Always, new Vector2(0.0f, 1.0f));
            ImGui.SetNextWindowBgAlpha(0.85f);

            ImGuiWindowFlags hudFlags = ImGuiWindowFlags.NoDecoration
                | ImGuiWindowFlags.AlwaysAutoResize
                | ImGuiWindowFlags.NoFocusOnAppearing
                | ImGuiWindowFlags.NoNav
                | ImGuiWindowFlags.NoMove
                | ImGuiWindowFlags.NoSavedSettings;

            ImGui.PushStyleVar(ImGuiStyleVar.WindowRounding, 6.0f);
            ImGui.PushStyleVar(ImGuiStyleVar.WindowPadding, new Vector2(10f, 6f));
            ImGui.PushStyleVar(ImGuiStyleVar.WindowBorderSize, 1.0f);

            if (ImGui.Begin("PKCoreLocationHUD###PKCoreLocationHUD", hudFlags))
            {
                ImGui.TextColored(GetAccentColor(), "Location:");
                ImGui.SameLine();
                ImGui.TextColored(new Vector4(1f, 0.9f, 0.4f, 1f), _cachedMapId);

                ImGui.SameLine();
                string noteBtnLabel = _showHudNoteInput ? "[Hide Note]" : (string.IsNullOrEmpty(_locationNotes) ? "[+ Note]" : "[Edit Note]");
                if (ImGui.SmallButton(noteBtnLabel + "##ToggleNoteHud"))
                {
                    _showHudNoteInput = !_showHudNoteInput;
                    _focusNoteInputNextFrame = _showHudNoteInput;
                    RequestCursorVisible(_showHudNoteInput || IsOpen || ShowBathhouseWindow);
                }

                ImGui.SameLine();
                if (ImGui.SmallButton("Dump##HudDump"))
                {
                    DumpCurrentLocation();
                }

                ImGui.SameLine();
                if (ImGui.SmallButton("Open Log##HudOpenLog"))
                {
                    OpenDumpLocation();
                }

                if (!string.IsNullOrEmpty(_dumpFeedback) && Time.time - _dumpFeedbackTime < 3f)
                {
                    ImGui.SameLine();
                    ImGui.TextColored(new Vector4(0.2f, 0.9f, 0.55f, 1f), _dumpFeedback);
                }

                // If not actively editing note input, but a note was entered, display it
                if (!string.IsNullOrEmpty(_locationNotes) && !_showHudNoteInput)
                {
                    ImGui.TextDisabled("Note:");
                    ImGui.SameLine();
                    ImGui.TextColored(new Vector4(0.9f, 0.9f, 0.9f, 1f), _locationNotes);
                }

                // If note input is expanded, show input field
                if (_showHudNoteInput)
                {
                    ImGui.SetNextItemWidth(220);
                    if (_focusNoteInputNextFrame)
                    {
                        ImGui.SetKeyboardFocusHere();
                        _focusNoteInputNextFrame = false;
                    }

                    if (ImGui.InputTextWithHint("##HudLocNotesInput", "Area description... [Enter to save]", ref _locationNotes, 256, ImGuiInputTextFlags.EnterReturnsTrue))
                    {
                        DumpCurrentLocation();
                        _showHudNoteInput = false;
                        RequestCursorVisible(IsOpen || ShowBathhouseWindow);
                    }

                    ImGui.SameLine();
                    if (ImGui.SmallButton("X##ClearHudNote"))
                    {
                        _locationNotes = "";
                    }

                    ImGui.SameLine();
                    if (ImGui.SmallButton("Save & Close##SaveCloseHudNote"))
                    {
                        _showHudNoteInput = false;
                        RequestCursorVisible(IsOpen || ShowBathhouseWindow);
                    }
                }

                var size = ImGui.GetWindowSize();
                _hudWidth = Math.Max(size.X + 20f, 320f);
                _hudHeight = Math.Max(size.Y + 20f, 60f);
            }
            ImGui.End();

            ImGui.PopStyleVar(3);
        }
        catch { }
    }

    /// <summary>
    /// Render callback invoked by DearImGuiInjection on DirectX Present.
    /// </summary>
    private static void DrawOverlay()
    {
        bool anyInteractiveOpen = IsOpen || ShowBathhouseWindow || _showHudNoteInput;

        if (!anyInteractiveOpen && !ShowLocationHUD)
        {
            IsInputBlocked = false;
            return;
        }

        if (_appliedTheme != _currentTheme)
        {
            ApplyCurrentTheme();
        }

        try
        {
            var io = ImGui.GetIO();
            if (anyInteractiveOpen)
            {
                io.ConfigFlags &= ~ImGuiConfigFlags.NoMouse;
                io.MouseDrawCursor = true;
            }
            else
            {
                io.ConfigFlags |= ImGuiConfigFlags.NoMouse;
                io.MouseDrawCursor = false;
            }
        }
        catch { }

        if (!IsOpen && ShowLocationHUD)
        {
            DrawBottomLocationHUD();
        }

        if (ShowBathhouseWindow)
        {
            DrawDedicatedBathhouseWindow();
        }

        if (!IsOpen)
        {
            UpdateInputCaptureState(anyInteractiveOpen);
            return;
        }

        try
        {
            ImGui.SetNextWindowSize(new System.Numerics.Vector2(1060, 740), ImGuiCond.FirstUseEver);
            if (ImGui.Begin("PKCore - Dear ImGui Runtime Feature & Diagnostics Inspector###PKCoreMain", ref IsOpen, ImGuiWindowFlags.MenuBar))
            {
                DrawMenuBar();

                ImGui.Columns(2, "PKCoreColumns", true);
                if (ImGui.GetColumnWidth(0) < 50f || ImGui.GetColumnWidth(0) > 400f)
                {
                    ImGui.SetColumnWidth(0, 240f);
                }

                DrawSidebar();

                ImGui.NextColumn();

                DrawMainContentPane();

                ImGui.Columns(1);

                ImGui.Separator();
                DrawFooterStatusBar();
            }
            ImGui.End();
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[PKCore] ImGui Overlay render error: {ex}");
        }

        UpdateInputCaptureState(anyInteractiveOpen);
    }

    private static void UpdateInputCaptureState(bool anyInteractiveOpen)
    {
        try
        {
            var io = ImGui.GetIO();
            IsInputBlocked = anyInteractiveOpen || io.WantCaptureMouse || io.WantCaptureKeyboard;
        }
        catch
        {
            IsInputBlocked = anyInteractiveOpen;
        }
    }

    private static void DrawMenuBar()
    {
        if (ImGui.BeginMenuBar())
        {
            if (ImGui.BeginMenu("Overlays"))
            {
                if (ImGui.MenuItem("Castle Bathhouse Window", null, ShowBathhouseWindow))
                {
                    ShowBathhouseWindow = !ShowBathhouseWindow;
                }
                bool hudOn = ShowLocationHUD;
                if (ImGui.MenuItem("Bottom Screen Location HUD", null, hudOn))
                {
                    ShowLocationHUD = !hudOn;
                }
                ImGui.Separator();
                if (ImGui.MenuItem("Close Overlay [F10]"))
                {
                    IsOpen = false;
                }
                ImGui.EndMenu();
            }

            if (ImGui.BeginMenu("Themes"))
            {
                if (ImGui.MenuItem("Classic Blue", null, _currentTheme == ThemePreset.ClassicBlue)) SetTheme(ThemePreset.ClassicBlue);
                if (ImGui.MenuItem("Matrix", null, _currentTheme == ThemePreset.Matrix)) SetTheme(ThemePreset.Matrix);
                if (ImGui.MenuItem("Obsidian Black", null, _currentTheme == ThemePreset.ObsidianBlack)) SetTheme(ThemePreset.ObsidianBlack);
                if (ImGui.MenuItem("Dark Magenta", null, _currentTheme == ThemePreset.DarkMagenta)) SetTheme(ThemePreset.DarkMagenta);
                ImGui.EndMenu();
            }

            if (ImGui.BeginMenu("Quick Actions"))
            {
                if (ImGui.MenuItem("Toggle Encounter None [F4]"))
                {
                    RunOnMainThread(() => EncounterNonePatch.Toggle());
                }
                if (ImGui.MenuItem("Toggle Mouse Cursor"))
                {
                    RunOnMainThread(() => MouseCursorPatch.Toggle());
                }
                ImGui.Separator();
                if (ImGui.MenuItem("Restore Party HP & MP"))
                {
                    RunOnMainThread(QuickHealParty);
                }
                ImGui.Separator();
                if (ImGui.MenuItem("Dump Location to Log [NumPad 5]"))
                {
                    DumpCurrentLocation();
                }
                ImGui.EndMenu();
            }

            ImGui.EndMenuBar();
        }
    }

    private static void DrawSidebar()
    {
        if (ImGui.BeginChild("PKCoreSidebarChild", new System.Numerics.Vector2(0, -28), false))
        {
            // 1. Search Box
            ImGui.AlignTextToFramePadding();
            ImGui.Text("Find:");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(-32);
            ImGui.InputTextWithHint("##SearchQuery", "Filter...", ref _searchQuery, 100);
            ImGui.SameLine();
            if (ImGui.Button("X##ClearSearch"))
            {
                _searchQuery = "";
            }

            ImGui.Spacing();
            ImGui.Separator();

            // 2. Navigation Selectables
            ImGui.TextDisabled("SECTIONS");

            DrawNavSelectable(0, "General & Debug");
            DrawNavSelectable(1, "Combat & Runes");
            DrawNavSelectable(2, "Recovery & World");
            DrawNavSelectable(3, "Visuals & Crystal");
            DrawNavSelectable(4, "Castle Bathhouse");
            DrawNavSelectable(5, "Party & Roster");
            DrawNavSelectable(6, "Scene & Engine");
            DrawNavSelectable(7, "Themes & Settings");
        }
        ImGui.EndChild();
    }

    private static void DrawNavSelectable(int index, string label)
    {
        bool isSelected = (_selectedSection == index && string.IsNullOrWhiteSpace(_searchQuery));
        string prefix = isSelected ? "> " : "  ";
        if (ImGui.Selectable(prefix + label + "##Nav", isSelected, ImGuiSelectableFlags.None, new System.Numerics.Vector2(0, 24)))
        {
            _selectedSection = index;
            _searchQuery = "";
        }
    }

    private static void DrawMainContentPane()
    {
        if (ImGui.BeginChild("PKCoreMainContentChild", new System.Numerics.Vector2(0, -28), false, ImGuiWindowFlags.HorizontalScrollbar))
        {
            if (!string.IsNullOrWhiteSpace(_searchQuery))
            {
                ImGui.TextColored(GetAccentColor(), $"[Search Results for \"{_searchQuery}\"]");
                ImGui.Separator();

                if (MatchesSearch("debug general encounter none f4 mouse cursor heal snapshot"))
                    DrawGeneralDebugSection();

                if (MatchesSearch("combat battle runes memory auto trick groundhog spider angry unbalance range level hp"))
                    DrawCombatSection();

                if (MatchesSearch("recovery heal smart sajah shop tenzan chimera muse survivors"))
                    DrawRecoverySection();

                if (MatchesSearch("visuals crystal save color glow clouds sunrays sprite filtering smaa"))
                    DrawVisualsSection();

                if (MatchesSearch("bathhouse bath tubs men women visitors furo"))
                    DrawBathhouseSection();

                if (MatchesSearch("party roster convoy slot members characters"))
                    DrawPartyRosterSection();

                if (MatchesSearch("scene map flags telemetry stats engine"))
                    DrawSceneSection();

                if (MatchesSearch("theme settings appearance ui style color preset"))
                    DrawSettingsThemeSection();
            }
            else
            {
                switch (_selectedSection)
                {
                    case 0: DrawGeneralDebugSection(); break;
                    case 1: DrawCombatSection(); break;
                    case 2: DrawRecoverySection(); break;
                    case 3: DrawVisualsSection(); break;
                    case 4: DrawBathhouseSection(); break;
                    case 5: DrawPartyRosterSection(); break;
                    case 6: DrawSceneSection(); break;
                    case 7: DrawSettingsThemeSection(); break;
                }
            }
        }
        ImGui.EndChild();
    }

    // =========================================================================
    // SECTION 0: GENERAL & DEBUG TOGGLES
    // =========================================================================
    private static void DrawGeneralDebugSection()
    {
        if (ImGui.CollapsingHeader("General & Runtime Debug Controls", ImGuiTreeNodeFlags.DefaultOpen))
        {
            if (ImGui.BeginTable("GeneralTwoCol", 2, ImGuiTableFlags.SizingStretchSame))
            {
                ImGui.TableSetupColumn("GeneralColLeft", ImGuiTableColumnFlags.WidthStretch);
                ImGui.TableSetupColumn("GeneralColRight", ImGuiTableColumnFlags.WidthStretch);

                ImGui.TableNextColumn();
                ImGui.TextColored(GetAccentColor(), "Runtime Controls & Hotkeys");
                ImGui.Separator();

                bool noEnc = EncounterNonePatch.IsEncounterNone;
                ImGui.TextColored(GetAccentColor(), "Encounter None [F4]");
                ImGui.TextWrapped($"Suppresses random wandering and field encounters.\nBackend: {EncounterNonePatch.BackendStatus}");
                if (ImGui.Button((noEnc ? "Disable [F4] (Enable Battles)" : "Enable [F4] (Suppress Battles)") + "##EncBtn", new Vector2(-1, 28)))
                    RunOnMainThread(() => EncounterNonePatch.Toggle());

                ImGui.Spacing();

                bool mouseOn = MouseCursorPatch.IsEnabled;
                ImGui.TextColored(GetAccentColor(), "Show Mouse Cursor");
                ImGui.TextWrapped("Shows or hides the system hardware mouse cursor over the game window.");
                if (ImGui.Button((mouseOn ? "Hide Mouse Cursor" : "Show Mouse Cursor") + "##MouseBtn", new Vector2(-1, 26)))
                    RunOnMainThread(() => MouseCursorPatch.Toggle());

                ImGui.Spacing();

                ImGui.TextColored(GetAccentColor(), "Quick Full Party Restore");
                ImGui.TextWrapped("Fully restores all party members to maximum HP and resets all spell tier MP to 9.");
                if (ImGui.Button("Full Party Heal (HP & MP)##HealBtn", new Vector2(-1, 28)))
                    RunOnMainThread(QuickHealParty);

                if (!string.IsNullOrEmpty(_healFeedback) && Time.time - _healFeedbackTime < 5f)
                {
                    ImGui.TextColored(new Vector4(0.2f, 0.95f, 0.45f, 1f), _healFeedback);
                }

                ImGui.TableNextColumn();
                ImGui.TextColored(GetAccentColor(), "Telemetry & Location Data");
                ImGui.Separator();

                ImGui.TextColored(GetAccentColor(), "Live Location & Stars Context");
                ImGui.Text($"Active Map ID: {_cachedMapId}");
                ImGui.Text($"Stars of Destiny: {_cachedStars} / 108");

                ImGui.Spacing();
                ImGui.TextColored(GetAccentColor(), "Area Notes & Snapshot Export [NumPad 5]");
                ImGui.TextWrapped("Attach custom notes to the current location and export to locationdump.log.");

                ImGui.SetNextItemWidth(-32);
                ImGui.InputTextWithHint("##GeneralAreaNotes", "Description / area notes...", ref _locationNotes, 256);
                ImGui.SameLine();
                if (ImGui.Button("X##ClearGenNotes"))
                {
                    _locationNotes = "";
                }

                if (ImGui.Button("Append to locationdump.log [NumPad 5]##DumpActionBtn", new Vector2(-75, 26)))
                {
                    DumpCurrentLocation();
                }
                ImGui.SameLine();
                if (ImGui.Button("Open Log##OpenLogGenBtn", new Vector2(-1, 26)))
                {
                    OpenDumpLocation();
                }

                if (!string.IsNullOrEmpty(_dumpFeedback) && Time.time - _dumpFeedbackTime < 4f)
                {
                    ImGui.TextColored(new Vector4(0.2f, 0.95f, 0.45f, 1f), _dumpFeedback);
                }

                ImGui.Spacing();
                bool hudOn = ShowLocationHUD;
                if (ImGui.Checkbox("Display In-Game Location HUD (When Overlay Closed)", ref hudOn))
                {
                    ShowLocationHUD = hudOn;
                }
                ImGui.TextDisabled("Shows a compact semi-transparent location indicator at screen bottom.");

                ImGui.EndTable();
            }
            ImGui.Spacing();
        }
    }

    // =========================================================================
    // SECTION 1: COMBAT & RUNES
    // =========================================================================
    private static void DrawCombatSection()
    {
        if (ImGui.CollapsingHeader("Combat, Runes & Battle Systems", ImGuiTreeNodeFlags.DefaultOpen))
        {
            if (ImGui.BeginTable("CombatTwoCol", 2, ImGuiTableFlags.SizingStretchSame))
            {
                ImGui.TableSetupColumn("CombatColLeft", ImGuiTableColumnFlags.WidthStretch);
                ImGui.TableSetupColumn("CombatColRight", ImGuiTableColumnFlags.WidthStretch);

                ImGui.TableNextColumn();
                ImGui.TextColored(GetAccentColor(), "Battle Actions & Memory Auto-Battle");
                ImGui.Separator();

                bool memEnabled = Plugin.Config.EnableMemoryAutoBattle.Value;
                ImGui.TextColored(GetAccentColor(), "Memory Auto-Battle (Suikoden 2)");
                ImGui.TextWrapped($"Status: {(memEnabled ? "ENABLED" : "DISABLED")} - Repeats previous turn's commands.");
                if (ImGui.Button("Clear Memory Auto-Battle Buffer##ClearMemBtn", new Vector2(-1, 26)))
                {
                    ResetAutoBattleMemory();
                }
                if (!string.IsNullOrEmpty(_memoryFeedback) && Time.time - _memoryFeedbackTime < 4f)
                {
                    ImGui.TextColored(new Vector4(0.2f, 0.95f, 0.45f, 1f), _memoryFeedback);
                }

                ImGui.Spacing();
                ImGui.TextColored(GetAccentColor(), "Command Runes & Status Overrides");
                ImGui.BulletText($"Unlimited Command Runes: {(Plugin.Config.EnableUnlimitedCommandRunes.Value ? "ENABLED" : "DISABLED")}");
                ImGui.TextDisabled("Allows Trick, Groundhog, Angry, Spider, etc. to be reused repeatedly without vanishing.");

                ImGui.Spacing();
                ImGui.BulletText($"Rune Unbalance Removal: {(Plugin.Config.EnableRuneUnbalanceRemoval.Value ? "ENABLED" : "DISABLED")}");
                ImGui.TextDisabled("Removes Unbalance from Titans, Kite, and high-impact physical runes.");

                ImGui.TableNextColumn();
                ImGui.TextColored(GetAccentColor(), "Weapon Ranges & Battle Window UI");
                ImGui.Separator();

                ImGui.TextColored(GetAccentColor(), "Character Weapon Range Overrides");
                ImGui.TextWrapped("Overrides short-range characters (Kasumi, Luc, Mazus, Viki, Gantetsu, Badeaux, Sierra) to Medium (M), allowing back-row melee.");
                ImGui.BulletText($"Status: {(Plugin.Config.EnableCharacterRangeOverrides.Value ? "ACTIVE" : "DISABLED")}");

                ImGui.Spacing();
                ImGui.TextColored(GetAccentColor(), "Battle Enemy Target Window");
                ImGui.BulletText($"Show Enemy Levels: {(Plugin.Config.ShowEnemyLevelInBattle.Value ? "ON" : "OFF")}");
                ImGui.BulletText($"Show Enemy HP: {(Plugin.Config.ShowEnemyHpInBattle.Value ? "ON" : "OFF")}");
                ImGui.BulletText($"Target Window Scale: {Plugin.Config.MonsterWindowWidthScale.Value:0.##}x");

                ImGui.EndTable();
            }
            ImGui.Spacing();
        }
    }

    // =========================================================================
    // SECTION 2: RECOVERY & PROGRESSION
    // =========================================================================
    private static void DrawRecoverySection()
    {
        if (ImGui.CollapsingHeader("Recovery & Story Progression", ImGuiTreeNodeFlags.DefaultOpen))
        {
            if (ImGui.BeginTable("RecoveryTwoCol", 2, ImGuiTableFlags.SizingStretchSame))
            {
                ImGui.TableSetupColumn("RecColLeft", ImGuiTableColumnFlags.WidthStretch);
                ImGui.TableSetupColumn("RecColRight", ImGuiTableColumnFlags.WidthStretch);

                ImGui.TableNextColumn();
                ImGui.TextColored(GetAccentColor(), "Smart Auto-Healing");
                ImGui.Separator();

                bool smartOn = Plugin.Config.EnableSmartHealing.Value;
                ImGui.TextColored(GetAccentColor(), "Smart After-Battle Auto-Healing");
                ImGui.TextWrapped($"Status: {(smartOn ? "ENABLED" : "DISABLED")} - Intelligently cleanses poison, revives KO'd allies via Jizo, and tops off wounded heroes after battle using party items without waste.");

                ImGui.Spacing();
                ImGui.TextColored(GetAccentColor(), "Quick Party HP / MP Restore");
                if (ImGui.Button("Full Party Heal Now##RecHeal", new Vector2(-1, 28)))
                    RunOnMainThread(QuickHealParty);

                ImGui.TableNextColumn();
                ImGui.TextColored(GetAccentColor(), "Story Progression & Rare Restorations");
                ImGui.Separator();

                ImGui.TextColored(GetAccentColor(), "Sajah Village Early Rare Finds Shop");
                ImGui.TextWrapped("Enables the late-game Sajah Village rare item shop from the start of the game.");
                ImGui.BulletText($"Status: {(Plugin.Config.UnlockSajahRareShopEarly.Value ? "UNLOCKED" : "VANILLA")}");

                ImGui.Spacing();
                ImGui.TextColored(GetAccentColor(), "Tenzan Pass Double-Chimera Restoration");
                ImGui.TextWrapped("Restores the cut Double-Chimera world encounter on Tenzan Pass.");
                ImGui.BulletText($"Status: {(Plugin.Config.EnableTenzanChimeraFix.Value ? "RESTORED" : "VANILLA")}");

                ImGui.Spacing();
                ImGui.TextColored(GetAccentColor(), "Muse Ruins Survivors & 108 Stars");
                ImGui.TextWrapped("Ensures post-liberation recruitment logic and event safety in Muse City.");
                ImGui.BulletText($"Status: {(Plugin.Config.EnableMuseRuinsSurvivorsRestoration.Value ? "ACTIVE" : "DISABLED")}");

                ImGui.EndTable();
            }
            ImGui.Spacing();
        }
    }

    // =========================================================================
    // SECTION 3: VISUALS & SAVE POINT ORB
    // =========================================================================
    private static void DrawVisualsSection()
    {
        if (ImGui.CollapsingHeader("Visuals, Shaders & Save Orb", ImGuiTreeNodeFlags.DefaultOpen))
        {
            if (ImGui.BeginTable("VisualsTwoCol", 2, ImGuiTableFlags.SizingStretchSame))
            {
                ImGui.TableSetupColumn("VisColLeft", ImGuiTableColumnFlags.WidthStretch);
                ImGui.TableSetupColumn("VisColRight", ImGuiTableColumnFlags.WidthStretch);

                ImGui.TableNextColumn();
                ImGui.TextColored(GetAccentColor(), "Save Point Orb Variant");
                ImGui.Separator();

                string currentColor = Plugin.Config.SavePointColor.Value ?? "default";
                ImGui.BulletText($"Current Variant: {currentColor.ToUpperInvariant()}");
                ImGui.BulletText($"Glow Effect: {(Plugin.Config.DisableSavePointGlow.Value ? "DISABLED" : "ENABLED")}");

                ImGui.Spacing();
                ImGui.TextDisabled("Select Color Variant:");
                if (ImGui.BeginTable("SavePointPresets", 3, ImGuiTableFlags.SizingStretchSame))
                {
                    ImGui.TableSetupColumn("OrbCol1", ImGuiTableColumnFlags.WidthStretch);
                    ImGui.TableSetupColumn("OrbCol2", ImGuiTableColumnFlags.WidthStretch);
                    ImGui.TableSetupColumn("OrbCol3", ImGuiTableColumnFlags.WidthStretch);
                    string[] variants = { "default", "cyan", "blue", "green", "yellow", "red", "purple", "pink", "white", "black", "navy", "random" };
                    for (int i = 0; i < variants.Length; i++)
                    {
                        if (i % 3 == 0 && i > 0)
                            ImGui.TableNextRow();

                        ImGui.TableNextColumn();
                        string varName = variants[i];
                        bool isSelected = string.Equals(currentColor, varName, StringComparison.OrdinalIgnoreCase);
                        string label = isSelected ? $"[{varName.ToUpper()}]" : char.ToUpper(varName[0]) + varName.Substring(1);
                        if (ImGui.Button($"{label}##{varName}", new Vector2(-1, 24)))
                        {
                            Plugin.Config.SavePointColor.Value = varName;
                            CustomTexturePatch.ClearSavePointVariantCaches();
                        }
                    }
                    ImGui.EndTable();
                }

                ImGui.TableNextColumn();
                ImGui.TextColored(GetAccentColor(), "Rendering & Shaders");
                ImGui.Separator();

                ImGui.BulletText($"Disable Sprite Post-Processing: {(Plugin.Config.DisableSpritePostProcessing.Value ? "ON" : "OFF")}");
                ImGui.TextDisabled("Prevents blur and glowing seams around upscaled sprites.");

                ImGui.Spacing();
                ImGui.BulletText($"Sprite Filtering: {(Plugin.Config.SpriteFilteringEnabled.Value ? "ENABLED" : "OFF")}");
                ImGui.BulletText($"SMAA Anti-Aliasing Quality: {Plugin.Config.SMAAQuality.Value}");
                ImGui.BulletText($"Compact Dialogue Box: {(Plugin.Config.ScaleDownDialogBox.Value ? "ON (80%)" : "OFF (100%)")}");

                ImGui.EndTable();
            }
            ImGui.Spacing();
        }
    }

    // =========================================================================
    // SECTION 4: CASTLE BATHHOUSE INSPECTOR
    // =========================================================================
    private static void DrawBathhouseSection()
    {
        if (ImGui.CollapsingHeader("Castle Bathhouse Inspector (12-Slot Tubs & Visitors)", ImGuiTreeNodeFlags.DefaultOpen))
        {
            ImGui.TextColored(GetAccentColor(), "Bathhouse Engine Telemetry");
            ImGui.Separator();

            string statusText = _cachedInBath ? "ACTIVE BATH SESSION" : "INACTIVE (Outside Bath Session)";
            Vector4 statusColor = _cachedInBath ? new Vector4(0.2f, 0.95f, 0.45f, 1f) : new Vector4(0.7f, 0.7f, 0.7f, 1f);

            ImGui.Text("Session Status:");
            ImGui.SameLine();
            ImGui.TextColored(statusColor, statusText);

            ImGui.SameLine(320);
            ImGui.Text($"Bathers: {_cachedBathersCount} / 12");

            ImGui.SameLine(500);
            ImGui.Text($"Water Temp: {_cachedHotVal} Hot / {_cachedCoolVal} Cool");

            ImGui.Spacing();
            if (ImGui.Button(ShowBathhouseWindow ? "Close Dedicated Window" : "Open Dedicated Floating Window##DedicatedBathBtn", new Vector2(260, 26)))
            {
                ShowBathhouseWindow = !ShowBathhouseWindow;
            }

            ImGui.Spacing();
            ImGui.TextDisabled("12-Slot Bath Tub State (Men: 0..5, Women: 6..11):");

            if (ImGui.BeginTable("BathTubsTable", 2, ImGuiTableFlags.BordersInnerV | ImGuiTableFlags.Resizable))
            {
                ImGui.TableSetupColumn("MenCol", ImGuiTableColumnFlags.WidthStretch);
                ImGui.TableSetupColumn("WomenCol", ImGuiTableColumnFlags.WidthStretch);

                ImGui.TableNextColumn();
                ImGui.TextColored(new Vector4(0.4f, 0.75f, 1.0f, 1f), "MEN'S TUB (Positions 0 to 5)");
                ImGui.Separator();
                for (int p = 0; p < 6; p++)
                {
                    var slot = _cachedTubSlots[p];
                    if (slot.charaId > 0)
                    {
                        ImGui.Text($"Pos {p}: {slot.name} (#{slot.charaId}) [{slot.origin}]");
                        ImGui.TextDisabled($"       Atlas: {slot.atlas}");
                    }
                    else
                    {
                        ImGui.TextDisabled($"Pos {p}: [Empty Tub Position]");
                    }
                }

                ImGui.TableNextColumn();
                ImGui.TextColored(new Vector4(1.0f, 0.55f, 0.8f, 1f), "WOMEN'S TUB (Positions 6 to 11)");
                ImGui.Separator();
                for (int p = 6; p < 12; p++)
                {
                    var slot = _cachedTubSlots[p];
                    if (slot.charaId > 0)
                    {
                        ImGui.Text($"Pos {p}: {slot.name} (#{slot.charaId}) [{slot.origin}]");
                        ImGui.TextDisabled($"       Atlas: {slot.atlas}");
                    }
                    else
                    {
                        ImGui.TextDisabled($"Pos {p}: [Empty Tub Position]");
                    }
                }

                ImGui.EndTable();
            }

            ImGui.Spacing();
            ImGui.TextColored(GetAccentColor(), "Restored Castle Visitors In Bath:");
            ImGui.TextWrapped(_cachedBathVisitors);
            ImGui.Spacing();
        }
    }

    public static void DrawDedicatedBathhouseWindow()
    {
        ImGui.SetNextWindowSize(new Vector2(880, 560), ImGuiCond.FirstUseEver);
        if (ImGui.Begin("Castle Bathhouse Inspector###DedicatedBathWindow", ref ShowBathhouseWindow))
        {
            DrawBathhouseSection();
        }
        ImGui.End();
    }

    // =========================================================================
    // SECTION 5: PARTY & ROSTER INSPECTOR
    // =========================================================================
    private static void DrawPartyRosterSection()
    {
        if (ImGui.CollapsingHeader("Active Party & Convoy Roster (8 Slots)", ImGuiTreeNodeFlags.DefaultOpen))
        {
            ImGui.TextColored(GetAccentColor(), "Current Battle & Convoy Members");
            ImGui.Separator();

            if (ImGui.BeginTable("PartyRosterTable", 5, ImGuiTableFlags.Borders | ImGuiTableFlags.RowBg))
            {
                ImGui.TableSetupColumn("Slot", ImGuiTableColumnFlags.WidthFixed, 40f);
                ImGui.TableSetupColumn("ID", ImGuiTableColumnFlags.WidthFixed, 50f);
                ImGui.TableSetupColumn("Character Name", ImGuiTableColumnFlags.WidthStretch);
                ImGui.TableSetupColumn("Gender", ImGuiTableColumnFlags.WidthFixed, 80f);
                ImGui.TableSetupColumn("Live HP", ImGuiTableColumnFlags.WidthFixed, 120f);
                ImGui.TableHeadersRow();

                for (int i = 0; i < 8; i++)
                {
                    var p = _cachedParty[i];
                    ImGui.TableNextRow();
                    ImGui.TableNextColumn();
                    ImGui.Text($"#{i + 1}");

                    ImGui.TableNextColumn();
                    if (p.id > 0) ImGui.Text($"{p.id}");
                    else ImGui.TextDisabled("-");

                    ImGui.TableNextColumn();
                    if (p.id > 0) ImGui.Text(p.name);
                    else ImGui.TextDisabled("(Empty Slot)");

                    ImGui.TableNextColumn();
                    if (p.id > 0)
                    {
                        if (p.isFemale) ImGui.TextColored(new Vector4(1f, 0.6f, 0.8f, 1f), "Female");
                        else ImGui.TextColored(new Vector4(0.4f, 0.75f, 1f, 1f), "Male");
                    }
                    else ImGui.TextDisabled("-");

                    ImGui.TableNextColumn();
                    if (p.id > 0 && p.maxHp > 0)
                    {
                        float pct = (float)p.hp / p.maxHp;
                        Vector4 hpColor = pct > 0.5f ? new Vector4(0.2f, 0.95f, 0.45f, 1f) : pct > 0.2f ? new Vector4(1f, 0.85f, 0.2f, 1f) : new Vector4(1f, 0.3f, 0.3f, 1f);
                        ImGui.TextColored(hpColor, $"{p.hp} / {p.maxHp}");
                    }
                    else ImGui.TextDisabled("-");
                }

                ImGui.EndTable();
            }
            ImGui.Spacing();
        }
    }

    // =========================================================================
    // SECTION 6: SCENE & ENGINE TELEMETRY
    // =========================================================================
    private static void DrawSceneSection()
    {
        if (ImGui.CollapsingHeader("Live Scene & Subsystem Telemetry", ImGuiTreeNodeFlags.DefaultOpen))
        {
            if (ImGui.BeginTable("SceneTelemetryTable", 2, ImGuiTableFlags.SizingStretchSame))
            {
                ImGui.TableSetupColumn("SceneColLeft", ImGuiTableColumnFlags.WidthStretch);
                ImGui.TableSetupColumn("SceneColRight", ImGuiTableColumnFlags.WidthStretch);

                ImGui.TableNextColumn();
                ImGui.TextColored(GetAccentColor(), "Live Scene Telemetry");
                ImGui.Separator();

                ImGui.Text("Active Map ID:");
                ImGui.SameLine();
                ImGui.TextColored(new Vector4(1f, 0.9f, 0.4f, 1f), _cachedMapId);

                ImGui.Text("Stars of Destiny Recruited:");
                ImGui.SameLine();
                ImGui.TextColored(new Vector4(1f, 0.9f, 0.4f, 1f), $"{_cachedStars} / 108");

                ImGui.Spacing();
                ImGui.TextColored(GetAccentColor(), "Area Notes & Dump:");
                ImGui.SetNextItemWidth(-30);
                ImGui.InputTextWithHint("##SceneNotes", "Description / notes...", ref _locationNotes, 256);
                ImGui.SameLine();
                if (ImGui.Button("X##ClearSceneNotes"))
                {
                    _locationNotes = "";
                }
                if (ImGui.Button("Dump Location & Notes to Log##SceneDumpBtn", new Vector2(-90, 22)))
                {
                    DumpCurrentLocation();
                }
                ImGui.SameLine();
                if (ImGui.Button("Open Log##SceneOpenLogBtn", new Vector2(-1, 22)))
                {
                    OpenDumpLocation();
                }

                ImGui.Spacing();
                ImGui.Text("Bathhouse Session Active:");
                ImGui.SameLine();
                if (_cachedInBath) ImGui.TextColored(new Vector4(0.2f, 0.9f, 0.55f, 1f), "YES");
                else ImGui.TextColored(new Vector4(0.6f, 0.65f, 0.7f, 1f), "NO");

                ImGui.Text("Encounter Suppression Backend:");
                ImGui.SameLine();
                ImGui.TextColored(new Vector4(0.5f, 0.8f, 1.0f, 1f), EncounterNonePatch.BackendStatus);

                ImGui.Text("Dear ImGui Rendering Backend:");
                ImGui.SameLine();
                ImGui.TextColored(new Vector4(0.5f, 0.8f, 1.0f, 1f), "DirectX 11 (DearImGuiInjection)");

                ImGui.TableNextColumn();
                ImGui.TextColored(GetAccentColor(), "Active Engine Subsystems");
                ImGui.Separator();

                ImGui.BulletText("Full 8-Character Bathhouse Capacity (+2 Convoy/Visitor Expansion)");
                ImGui.BulletText("Gender-Segregated Tub Separation & Restored Castle NPC Bathers");
                ImGui.BulletText("Native Gadget & Beast Bathhouse Routing");
                ImGui.BulletText("Sub-millisecond Symbol Indexer & IL2CPP Memory Resolution");
                ImGui.BulletText("DirectX 11 ImGui Injection with Thread-Safe Action Dispatch");

                ImGui.EndTable();
            }
            ImGui.Spacing();
        }
    }

    // =========================================================================
    // SECTION 7: THEMES & OVERLAY SETTINGS
    // =========================================================================
    private static void DrawSettingsThemeSection()
    {
        if (ImGui.CollapsingHeader("UI Themes & Overlay Appearance", ImGuiTreeNodeFlags.DefaultOpen))
        {
            ImGui.TextColored(GetAccentColor(), "Overlay Theme Preset");
            ImGui.TextWrapped("Select a visual style preset for the Dear ImGui runtime overlay and diagnostics windows.");
            ImGui.Spacing();

            string currentThemeName = GetCurrentThemeName();
            ImGui.Text("Active Preset: ");
            ImGui.SameLine();
            ImGui.TextColored(GetAccentColor(), currentThemeName);

            ImGui.Spacing();
            ImGui.Separator();

            if (ImGui.BeginTable("ThemesGridTable", 2, ImGuiTableFlags.SizingStretchSame))
            {
                ImGui.TableSetupColumn("ThemeColLeft", ImGuiTableColumnFlags.WidthStretch);
                ImGui.TableSetupColumn("ThemeColRight", ImGuiTableColumnFlags.WidthStretch);

                // Row 1: Classic Blue & Matrix Green
                ImGui.TableNextColumn();
                bool isBlue = _currentTheme == ThemePreset.ClassicBlue;
                if (ImGui.Button((isBlue ? "★ Classic Blue (Active)" : "Classic Blue") + "##PresetBlue", new Vector2(-1, 32)))
                {
                    SetTheme(ThemePreset.ClassicBlue);
                }
                ImGui.TextDisabled("Modern deep blue with cobalt accents and high contrast text.");

                ImGui.TableNextColumn();
                bool isMatrix = _currentTheme == ThemePreset.Matrix;
                if (ImGui.Button((isMatrix ? "★ Matrix Green (Active)" : "Matrix Green") + "##PresetMatrix", new Vector2(-1, 32)))
                {
                    SetTheme(ThemePreset.Matrix);
                }
                ImGui.TextDisabled("Cyberpunk emerald terminal palette with vibrant mint headers.");

                // Row 2: Obsidian Black & Dark Magenta
                ImGui.TableNextRow();
                ImGui.TableNextColumn();
                bool isObsidian = _currentTheme == ThemePreset.ObsidianBlack;
                if (ImGui.Button((isObsidian ? "★ Obsidian Black (Active)" : "Obsidian Black") + "##PresetObsidian", new Vector2(-1, 32)))
                {
                    SetTheme(ThemePreset.ObsidianBlack);
                }
                ImGui.TextDisabled("Stealth OLED dark gray and charcoal with clean slate accents.");

                ImGui.TableNextColumn();
                bool isMagenta = _currentTheme == ThemePreset.DarkMagenta;
                if (ImGui.Button((isMagenta ? "★ Dark Magenta (Active)" : "Dark Magenta") + "##PresetMagenta", new Vector2(-1, 32)))
                {
                    SetTheme(ThemePreset.DarkMagenta);
                }
                ImGui.TextDisabled("Royal plum and violet tones with bright fuchsia accents.");

                ImGui.EndTable();
            }

            ImGui.Spacing();
            ImGui.Separator();

            ImGui.TextColored(GetAccentColor(), "Overlay & Input Preferences");
            ImGui.Spacing();

            bool hudActive = ShowLocationHUD;
            if (ImGui.Checkbox("In-Game Bottom Location HUD Indicator", ref hudActive))
            {
                ShowLocationHUD = hudActive;
            }
            ImGui.TextDisabled("Shows current map ID and stars at the bottom-left of the game screen.");

            ImGui.Spacing();
            bool mouseActive = MouseCursorPatch.IsEnabled;
            if (ImGui.Checkbox("Show System Hardware Mouse Cursor", ref mouseActive))
            {
                RunOnMainThread(() => MouseCursorPatch.Toggle());
            }
            ImGui.TextDisabled("Ensures mouse cursor is visible when navigating menus or playing with mouse.");

            ImGui.Spacing();
            ImGui.Separator();
            ImGui.TextColored(GetAccentColor(), "Quick Hotkey Reminders");
            ImGui.BulletText("[F10] : Toggle this Dear ImGui Runtime Feature & Diagnostics Inspector");
            ImGui.BulletText("[F4]  : Toggle Encounter None (Instant battle suppression)");
            ImGui.BulletText("[NumPad 5] : Instant location & notes snapshot to locationdump.log");
            ImGui.BulletText("[ESC] : Close overlay (when open)");
            ImGui.Spacing();
        }
    }

    private static void DrawFooterStatusBar()
    {
        ImGui.TextDisabled($"Theme: {GetCurrentThemeName()} | Hotkeys: [F10] Overlay | [F4] Encounter None | [NumPad 5] Dump Location | Backend: {EncounterNonePatch.BackendStatus} | ESC to dismiss");
    }

    private static bool MatchesSearch(string terms)
    {
        if (string.IsNullOrWhiteSpace(_searchQuery)) return true;
        string[] parts = _searchQuery.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var p in parts)
        {
            if (terms.IndexOf(p, StringComparison.OrdinalIgnoreCase) >= 0)
                return true;
        }
        return false;
    }

    // =========================================================================
    // QUICK ON-DEMAND PARTY HEAL
    // =========================================================================
    public static void QuickHealParty()
    {
        try
        {
            int count = 0;
            var party = GSD2::G2_SYS.G2_party_dat();
            if (party?.party_cha_no != null)
            {
                for (int i = 0; i < party.party_cha_no.Length; i++)
                {
                    byte charaId = party.party_cha_no[i];
                    if (charaId == 0) continue;

                    var varia = GSD2::G2_SYS.G2_varia_dat(charaId);
                    if (varia != null)
                    {
                        varia.now_hp = varia.max_hp;
                        if (varia.mp != null)
                        {
                            for (int m = 0; m < varia.mp.Length; m++)
                            {
                                varia.mp[m] = 9;
                            }
                        }
                        count++;
                    }
                }
                _healFeedback = $"Restored {count} party members to full HP & MP (all spell tiers maxed)!";
                _healFeedbackTime = Time.time;
                Plugin.Log.LogInfo($"[ImGuiOverlayUI] QuickHealParty: {_healFeedback}");
                return;
            }
            _healFeedback = "No active party found.";
            _healFeedbackTime = Time.time;
        }
        catch (Exception ex)
        {
            _healFeedback = $"Heal error: {ex.Message}";
            _healFeedbackTime = Time.time;
        }
    }

    public static void ResetAutoBattleMemory()
    {
        MemoryAutoBattlePatch.ResetMemory();
        _memoryFeedback = "Cleared remembered battle actions!";
        _memoryFeedbackTime = Time.time;
        Plugin.Log.LogInfo("[ImGuiOverlayUI] Cleared Auto-Battle memory.");
    }

    private static int GetBatherAtPosition(int pos, GSD2::EventOverlayClass.furo_h.FURO_WORK fw)
    {
        if (NPCBathVisitorPatch.FuroSlotToCharacter.TryGetValue(pos, out int recordedId) && recordedId > 0)
        {
            return recordedId;
        }

        if (fw != null && fw.furo_chara != null)
        {
            try
            {
                if (pos < fw.furo_chara.Length)
                {
                    var anime = fw.furo_chara[pos];
                    if (anime != null && anime.chara_id > 0)
                    {
                        int idVal = (int)anime.chara_id;
                        if (fw.furo_chara_id != null && idVal <= fw.furo_chara_id.Length && idVal > 0)
                        {
                            int mappedId = fw.furo_chara_id[idVal - 1];
                            if (mappedId > 0) return mappedId;
                        }
                        return idVal;
                    }
                }
            }
            catch { }
        }

        if (!NPCBathVisitorPatch.IsInsideBath)
        {
            try
            {
                var party = GSD2::G2_SYS.G2_party_dat();
                if (party?.party_cha_no != null)
                {
                    int menCount = 0;
                    int womenCount = 0;

                    for (int i = 0; i < party.party_cha_no.Length && i < 8; i++)
                    {
                        byte id = party.party_cha_no[i];
                        if (id == 0) continue;

                        bool isFemale = NPCBathVisitorPatch.FemaleCharaIds.Contains(id);
                        if (!isFemale)
                        {
                            if (pos == menCount) return id;
                            menCount++;
                        }
                        else
                        {
                            if (pos == 6 + womenCount) return id;
                            womenCount++;
                        }
                    }
                }
            }
            catch { }
        }

        return 0;
    }

    private static string GetBatherOrigin(int charaId)
    {
        if (NPCBathVisitorPatch.ActiveBathVisitors.Contains((byte)charaId))
            return "Recruited Castle Visitor";

        if (charaId == 1)
            return "Protagonist (Riou)";

        return "Active Party / Convoy";
    }

    private static List<string> GetVisitorNames(HashSet<byte> visitors)
    {
        List<string> list = new List<string>();
        foreach (byte id in visitors)
        {
            list.Add($"{GetCharacterName(id)} ({id})");
        }
        return list;
    }

    // =========================================================================
    // CANONICAL CHARACTER NAME LOOKUP
    // =========================================================================
    public static string GetCharacterName(int id)
    {
        if (CharacterNames.TryGetValue(id, out string name))
            return name;

        return $"Character #{id}";
    }

    private static readonly Dictionary<int, string> CharacterNames = new Dictionary<int, string>
    {
        { 1, "Riou (Hero)" },
        { 2, "Jowy Atreides" },
        { 3, "Flik" },
        { 4, "Viktor" },
        { 5, "Nanami" },
        { 6, "Pilika" },
        { 7, "Mukumuku" },
        { 8, "Tengaar" },
        { 9, "Freed Y" },
        { 10, "Apple" },
        { 11, "Humphrey" },
        { 12, "Valeria" },
        { 13, "Shin" },
        { 14, "Karen" },
        { 15, "Lorelai" },
        { 16, "Shin" },
        { 17, "Chaco" },
        { 18, "Nanami" },
        { 19, "Eilie" },
        { 20, "Rina" },
        { 21, "Bolgan" },
        { 22, "Clive" },
        { 23, "Hanna" },
        { 24, "Millie" },
        { 25, "Meg" },
        { 26, "Gadget" },
        { 27, "Stallion" },
        { 28, "Hai Yo" },
        { 29, "Zamza" },
        { 30, "Richmond" },
        { 31, "Sheena" },
        { 32, "Camus" },
        { 33, "Miklotov" },
        { 34, "Flik" },
        { 35, "Hauser" },
        { 36, "Gengen" },
        { 37, "Gabocha" },
        { 38, "Sierra" },
        { 39, "Anita" },
        { 40, "Kinnison" },
        { 41, "Kasumi" },
        { 42, "Sierra" },
        { 43, "Ayda" },
        { 44, "Bob" },
        { 45, "Sierra" },
        { 46, "Oulan" },
        { 47, "Oulan" },
        { 48, "Shiro" },
        { 49, "Alex" },
        { 50, "Hilda" },
        { 51, "Bob" },
        { 52, "Adlai" },
        { 53, "Tsai" },
        { 54, "Luc" },
        { 55, "Nina" },
        { 56, "Yoshino" },
        { 57, "Tomo" },
        { 58, "Maximillian" },
        { 59, "Gijimu" },
        { 60, "Viki" },
        { 61, "Lowen" },
        { 62, "Mazus" },
        { 63, "Mondo" },
        { 64, "Vincent de Boule" },
        { 65, "Simone Verdricci" },
        { 66, "Connell" },
        { 67, "Hans" },
        { 68, "Wakaba" },
        { 69, "L.C. Chan" },
        { 70, "Sid" },
        { 71, "Rulodia" },
        { 72, "Chuchara" },
        { 73, "Kasumi (alt)" },
        { 74, "Abizboah" },
        { 75, "Rulodia" },
        { 76, "Chuchara" },
        { 77, "Feather" },
        { 78, "Siegfried" },
        { 81, "Mukumuku" },
        { 82, "Makumaku" },
        { 83, "Mikumiku" },
        { 84, "Apple" },
        { 85, "Apple (convoy)" },
        { 86, "Hauser / Richmond" },
        { 87, "Kiba" },
        { 88, "Fitcher" },
        { 89, "Jess" },
        { 90, "Gilbert" },
        { 91, "Marlowe / Young Man" },
        { 92, "Marlowe" },
        { 93, "Richmond" },
        { 94, "Leona's Associate" },
        { 95, "Teresa Wisemail" },
        { 96, "Barbara" },
        { 97, "Templeton" },
        { 98, "Yuzu" },
        { 99, "Tenkou" },
        { 100, "Pilika" },
        { 101, "Adlai / Kiba" },
        { 102, "Emilia / Teresa" },
        { 103, "Alex" },
        { 104, "Raura" },
        { 105, "Adlai" },
        { 107, "Sansuke" },
        { 108, "Sansuke" },
        { 109, "Tetsu" },
        { 110, "Maximillian" },
        { 111, "Red-Hooded Recruit" },
        { 112, "Brown-Bob Recruit" },
        { 114, "Castle Recruit" },
        { 118, "Ridley Wizen" },
        { 120, "Marlowe" },
        { 121, "Ridley (actor)" },
        { 123, "Boris Wizen" },
        { 124, "Pilika" },
        { 125, "Grenmeyer" },
        { 143, "Klaus" },
        { 172, "Elza" }
    };

    // =========================================================================
    // INPUT BLOCKER HARMONY PATCHES
    // =========================================================================

    [HarmonyPatch(typeof(GRInputManager))]
    private static class GRInputManagerBlockerPatch
    {
        [HarmonyPatch(nameof(GRInputManager.IsOn))]
        [HarmonyPrefix]
        public static bool IsOn_Prefix(ref bool __result)
        {
            if (IsInputBlocked)
            {
                __result = false;
                return false;
            }
            return true;
        }

        [HarmonyPatch(nameof(GRInputManager.IsPress))]
        [HarmonyPrefix]
        public static bool IsPress_Prefix(ref bool __result)
        {
            if (IsInputBlocked)
            {
                __result = false;
                return false;
            }
            return true;
        }

        [HarmonyPatch(nameof(GRInputManager.IsHold))]
        [HarmonyPrefix]
        public static bool IsHold_Prefix(ref bool __result)
        {
            if (IsInputBlocked)
            {
                __result = false;
                return false;
            }
            return true;
        }

        [HarmonyPatch(nameof(GRInputManager.IsRepeat))]
        [HarmonyPrefix]
        public static bool IsRepeat_Prefix(ref bool __result)
        {
            if (IsInputBlocked)
            {
                __result = false;
                return false;
            }
            return true;
        }

        [HarmonyPatch(nameof(GRInputManager.IsOff))]
        [HarmonyPrefix]
        public static bool IsOff_Prefix(ref bool __result)
        {
            if (IsInputBlocked)
            {
                __result = true;
                return false;
            }
            return true;
        }

        [HarmonyPatch(nameof(GRInputManager.IsAny))]
        [HarmonyPrefix]
        public static bool IsAny_Prefix(ref bool __result)
        {
            if (IsInputBlocked)
            {
                __result = false;
                return false;
            }
            return true;
        }

        [HarmonyPatch(nameof(GRInputManager.IsKeyDown))]
        [HarmonyPrefix]
        public static bool IsKeyDown_Prefix(ref bool __result)
        {
            if (IsInputBlocked)
            {
                __result = false;
                return false;
            }
            return true;
        }

        [HarmonyPatch(nameof(GRInputManager.IsKeyPress))]
        [HarmonyPrefix]
        public static bool IsKeyPress_Prefix(ref bool __result)
        {
            if (IsInputBlocked)
            {
                __result = false;
                return false;
            }
            return true;
        }

        [HarmonyPatch(nameof(GRInputManager.GetValue))]
        [HarmonyPrefix]
        public static bool GetValue_Prefix(ref float __result)
        {
            if (IsInputBlocked)
            {
                __result = 0f;
                return false;
            }
            return true;
        }

        [HarmonyPatch(nameof(GRInputManager.IsRunValue))]
        [HarmonyPrefix]
        public static bool IsRunValue_Prefix(ref bool __result)
        {
            if (IsInputBlocked)
            {
                __result = false;
                return false;
            }
            return true;
        }
    }

    [HarmonyPatch(typeof(GSD2::G2_PAD))]
    private static class G2PadBlockerPatch
    {
        [HarmonyPatch(nameof(GSD2::G2_PAD.PadRead))]
        [HarmonyPrefix]
        public static bool PadRead_Prefix(ref uint __result, ref bool g_shu_dash)
        {
            if (IsInputBlocked)
            {
                g_shu_dash = false;
                __result = 0;
                return false;
            }
            return true;
        }

        [HarmonyPatch(nameof(GSD2::G2_PAD.PadRRead))]
        [HarmonyPrefix]
        public static bool PadRRead_Prefix(ref uint __result)
        {
            if (IsInputBlocked)
            {
                __result = 0;
                return false;
            }
            return true;
        }
    }

    [HarmonyPatch(typeof(GSD1::Pad))]
    private static class G1PadBlockerPatch
    {
        [HarmonyPatch(nameof(GSD1::Pad.PadRead))]
        [HarmonyPrefix]
        public static bool PadRead_Prefix(ref uint __result)
        {
            if (IsInputBlocked)
            {
                __result = 0;
                return false;
            }
            return true;
        }

        [HarmonyPatch(nameof(GSD1::Pad.PadRRead))]
        [HarmonyPrefix]
        public static bool PadRRead_Prefix(ref uint __result)
        {
            if (IsInputBlocked)
            {
                __result = 0;
                return false;
            }
            return true;
        }
    }
}
