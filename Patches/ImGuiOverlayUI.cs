extern alias GSD2;

using System;
using System.IO;
using System.Numerics;
using ImGuiNET;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;
using Vector4 = System.Numerics.Vector4;

namespace PKCore.Patches;

/// <summary>
/// Streamlined Dear ImGui Location & Notes HUD for PKCore.
/// Displays current map / location telemetry and allows fast note taking and dumping to locationdump.log.
/// Does not block gamepad, analog movement, or mod movement inputs.
/// </summary>
public static class ImGuiOverlayUI
{
    public static bool IsOpen { get => false; set { } }
    public static bool ShowBathhouseWindow { get => false; set { } }

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

    private static bool _initialized = false;

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

    // Location & Notes state
    private static string _locationNotes = "";
    private static bool _showHudNoteInput = false;
    private static bool _focusNoteInputNextFrame = false;
    private static float _hudWidth = 320f;
    private static float _hudHeight = 60f;
    private static string _dumpFeedback = "";
    private static float _dumpFeedbackTime = 0f;

    // Cached telemetry data updated on Unity main thread
    private static string _cachedMapId = "(None)";
    private static int _cachedStars = 0;

    // Cursor visibility management
    private static System.Reflection.PropertyInfo _isCursorVisibleProp;
    private static System.Reflection.MethodInfo _updateCursorVisibilityMethod;
    private static bool? _pendingCursorVisible = null;

    public static void Initialize()
    {
        if (_initialized) return;
        _initialized = true;

        SyncThemeFromConfig();

        try
        {
            DearImGuiInjection.DearImGuiInjection.Render += DrawOverlay;
            IsInjectorAvailable = true;
            Plugin.Log.LogInfo("[ImGuiOverlayUI] Successfully registered DearImGuiInjection.Render hook for Location HUD.");
        }
        catch (Exception ex)
        {
            IsInjectorAvailable = false;
            Plugin.Log.LogWarning($"[ImGuiOverlayUI] DearImGuiInjection not available: {ex.Message}");
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
                    colors[(int)ImGuiCol.Button]                = new Vector4(0.14f, 0.28f, 0.52f, 0.75f);
                    colors[(int)ImGuiCol.ButtonHovered]         = new Vector4(0.20f, 0.42f, 0.78f, 0.90f);
                    colors[(int)ImGuiCol.ButtonActive]          = new Vector4(0.26f, 0.52f, 0.95f, 1.00f);
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
                    colors[(int)ImGuiCol.Button]                = new Vector4(0.05f, 0.22f, 0.08f, 0.80f);
                    colors[(int)ImGuiCol.ButtonHovered]         = new Vector4(0.08f, 0.38f, 0.13f, 0.90f);
                    colors[(int)ImGuiCol.ButtonActive]          = new Vector4(0.12f, 0.55f, 0.18f, 1.00f);
                    break;

                case ThemePreset.ObsidianBlack:
                    colors[(int)ImGuiCol.Text]                  = new Vector4(0.92f, 0.94f, 0.97f, 1.00f);
                    colors[(int)ImGuiCol.TextDisabled]          = new Vector4(0.48f, 0.50f, 0.56f, 1.00f);
                    colors[(int)ImGuiCol.WindowBg]              = new Vector4(0.06f, 0.06f, 0.08f, 0.97f);
                    colors[(int)ImGuiCol.ChildBg]               = new Vector4(0.08f, 0.08f, 0.10f, 0.85f);
                    colors[(int)ImGuiCol.PopupBg]               = new Vector4(0.08f, 0.08f, 0.10f, 0.97f);
                    colors[(int)ImGuiCol.Border]                = new Vector4(0.24f, 0.25f, 0.29f, 0.65f);
                    colors[(int)ImGuiCol.BorderShadow]          = new Vector4(0.00f, 0.00f, 0.00f, 0.00f);
                    colors[(int)ImGuiCol.FrameBg]               = new Vector4(0.12f, 0.12f, 0.15f, 0.75f);
                    colors[(int)ImGuiCol.FrameBgHovered]        = new Vector4(0.18f, 0.18f, 0.22f, 0.85f);
                    colors[(int)ImGuiCol.FrameBgActive]         = new Vector4(0.24f, 0.24f, 0.30f, 1.00f);
                    colors[(int)ImGuiCol.Button]                = new Vector4(0.14f, 0.14f, 0.17f, 0.85f);
                    colors[(int)ImGuiCol.ButtonHovered]         = new Vector4(0.22f, 0.22f, 0.26f, 0.95f);
                    colors[(int)ImGuiCol.ButtonActive]          = new Vector4(0.30f, 0.30f, 0.36f, 1.00f);
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
                    colors[(int)ImGuiCol.Button]                = new Vector4(0.26f, 0.09f, 0.36f, 0.80f);
                    colors[(int)ImGuiCol.ButtonHovered]         = new Vector4(0.42f, 0.14f, 0.58f, 0.90f);
                    colors[(int)ImGuiCol.ButtonActive]          = new Vector4(0.60f, 0.18f, 0.80f, 1.00f);
                    break;
            }
        }
        catch (Exception ex)
        {
            Plugin.Log.LogWarning($"[ImGuiOverlayUI] ApplyCurrentTheme error: {ex.Message}");
        }
    }

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

    /// <summary>
    /// Update loop handling hotkeys and telemetry caching on Unity main thread.
    /// </summary>
    public static void Update()
    {
        if (_pendingCursorVisible.HasValue)
        {
            bool val = _pendingCursorVisible.Value;
            _pendingCursorVisible = null;
            SetImGuiCursorVisible(val);
        }

        try
        {
            var keyboard = UnityEngine.InputSystem.Keyboard.current;
            if (keyboard != null)
            {
                if (keyboard.escapeKey.wasPressedThisFrame && _showHudNoteInput)
                {
                    _showHudNoteInput = false;
                    SetImGuiCursorVisible(false);
                }
                else if (keyboard.numpad5Key.wasPressedThisFrame)
                {
                    DumpCurrentLocation();
                }
                else if (keyboard.numpad6Key.wasPressedThisFrame || keyboard.f9Key.wasPressedThisFrame)
                {
                    _showHudNoteInput = !_showHudNoteInput;
                    _focusNoteInputNextFrame = _showHudNoteInput;
                    SetImGuiCursorVisible(_showHudNoteInput);
                }
            }

            // Detect mouse click inside bottom-left HUD bounds to activate note text field
            if (ShowLocationHUD && !_showHudNoteInput)
            {
                var mouse = UnityEngine.InputSystem.Mouse.current;
                if (mouse != null && mouse.leftButton.wasPressedThisFrame)
                {
                    UnityEngine.Vector2 mPos = mouse.position.ReadValue();
                    if (mPos.x >= 0 && mPos.x <= _hudWidth && mPos.y >= 0 && mPos.y <= _hudHeight)
                    {
                        _showHudNoteInput = true;
                        _focusNoteInputNextFrame = true;
                        SetImGuiCursorVisible(true);
                    }
                }
            }
        }
        catch { }

        if (ShowLocationHUD)
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
    /// Render callback invoked by DearImGuiInjection on DirectX Present.
    /// </summary>
    private static void DrawOverlay()
    {
        if (!ShowLocationHUD)
            return;

        if (_appliedTheme != _currentTheme)
        {
            ApplyCurrentTheme();
        }

        try
        {
            var io = ImGui.GetIO();
            if (_showHudNoteInput)
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

        DrawBottomLocationHUD();
    }

    /// <summary>
    /// Renders a small, non-intrusive HUD in the bottom-left corner of the screen.
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
                    RequestCursorVisible(_showHudNoteInput);
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
                    ImGui.SetNextItemWidth(260);
                    if (_focusNoteInputNextFrame)
                    {
                        ImGui.SetKeyboardFocusHere();
                        _focusNoteInputNextFrame = false;
                    }

                    if (ImGui.InputTextWithHint("##HudLocNotesInput", "Area description... [Enter to save]", ref _locationNotes, 256, ImGuiInputTextFlags.EnterReturnsTrue))
                    {
                        DumpCurrentLocation();
                        _showHudNoteInput = false;
                        RequestCursorVisible(false);
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
                        RequestCursorVisible(false);
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
}
