extern alias GSD2;

using System;
using System.IO;
using System.Numerics;
using HarmonyLib;
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
    public static bool IsOpen { get => _showDevMenu; set => _showDevMenu = value; }
    public static bool ShowBathhouseWindow { get => false; set { } }
    private static bool _showDevMenu = false;

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

    public class AreaObjectSnapshot
    {
        public int Index;
        public int Fpno;
        public string Name = "";
        public int X;
        public int Y;
        public int W;
        public int H;
        public int Otyp;
        public byte Disp;
    }

    // Cached telemetry data updated strictly on Unity main thread
    private static string _cachedMapId = "(None)";
    private static int _cachedStars = 0;
    private static int _cachedPlayerX = 0;
    private static int _cachedPlayerY = 0;
    private static int _cachedMx = 0;
    private static int _cachedMy = 0;
    private static byte _cachedCastleStage = 0;
    private static bool _cachedHasCastleData = false;
    private static readonly System.Collections.Generic.List<AreaObjectSnapshot> _cachedAreaObjects = new();

    // Queued mutations applied strictly on Unity main thread
    private static readonly System.Collections.Generic.List<(int Index, byte NewDisp)> _pendingObjectToggles = new();
    private static byte? _pendingCastleStage = null;
    private static bool _pendingDanceTrigger = false;
    private static bool _pendingRoomReload = false;
    private static bool _pendingOpenRuneMaster = false;

    // Camera Zoom / FOV management
    public static float CameraZoom => _cameraZoom;
    private static float _cameraZoom = 1.0f;
    private static readonly System.Collections.Generic.Dictionary<int, float> _originalOrthoSizes = new();
    private static readonly System.Collections.Generic.Dictionary<int, float> _originalFovs = new();

    public static void SetCameraZoom(float zoom)
    {
        _cameraZoom = UnityEngine.Mathf.Clamp(zoom, 0.25f, 5.0f);
        Plugin.Log.LogInfo($"[ImGuiOverlayUI] SetCameraZoom -> {_cameraZoom:F2}x");
        UpdateCameras();
    }

    public static void OnMapChanged()
    {
        _originalOrthoSizes.Clear();
        _originalFovs.Clear();
        if (Math.Abs(_cameraZoom - 1.0f) > 0.001f)
        {
            UpdateCameras();
        }
    }

    public static void ApplyZoomToCamera(UnityEngine.Camera cam)
    {
        if (cam == null) return;
        try
        {
            string cname = cam.name ?? "";
            if (cname.IndexOf("UI", StringComparison.OrdinalIgnoreCase) >= 0) return;

            int id = cam.GetInstanceID();

            if (cam.orthographic)
            {
                if (!_originalOrthoSizes.TryGetValue(id, out float orig) || orig <= 0f)
                {
                    orig = cam.orthographicSize;
                    if (orig > 0f) _originalOrthoSizes[id] = orig;
                }
                if (orig > 0f)
                {
                    cam.orthographicSize = orig * _cameraZoom;
                }
            }
            else
            {
                if (!_originalFovs.TryGetValue(id, out float orig) || orig <= 0f)
                {
                    orig = cam.fieldOfView;
                    if (orig > 0f) _originalFovs[id] = orig;
                }
                if (orig > 0f)
                {
                    cam.fieldOfView = UnityEngine.Mathf.Clamp(orig * _cameraZoom, 5f, 175f);
                }
            }
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[ImGuiOverlayUI] ApplyZoomToCamera error: {ex.Message}");
        }
    }

    public static void UpdateCameras()
    {
        try
        {
            // 1. CameraManager active & filter cameras
            try
            {
                var mgr = CameraManager.Instance;
                if (mgr != null)
                {
                    if (mgr.ActiveCamera != null) ApplyZoomToCamera(mgr.ActiveCamera);
                    if (mgr.noFilterCamera != null) ApplyZoomToCamera(mgr.noFilterCamera);
                }
            }
            catch { }

            // 2. Camera.main
            try
            {
                var mainCam = UnityEngine.Camera.main;
                if (mainCam != null) ApplyZoomToCamera(mainCam);
            }
            catch { }

            // 3. All scene cameras
            try
            {
                var cameras = UnityEngine.Camera.allCameras;
                if (cameras != null)
                {
                    for (int i = 0; i < cameras.Length; i++)
                    {
                        var c = cameras[i];
                        if (c != null) ApplyZoomToCamera(c);
                    }
                }
            }
            catch { }

            // 4. BindCamera instances
            try
            {
                var boundList = BindCamera.activeCameras;
                if (boundList != null)
                {
                    for (int i = 0; i < boundList.Count; i++)
                    {
                        var b = boundList[i];
                        if (b != null)
                        {
                            if (b.bindTarget != null) ApplyZoomToCamera(b.bindTarget);
                            if (b.myCamera != null) ApplyZoomToCamera(b.myCamera);
                        }
                    }
                }
            }
            catch { }
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[ImGuiOverlayUI] UpdateCameras error: {ex}");
        }
    }

    public static void LateUpdate()
    {
        if (Math.Abs(_cameraZoom - 1.0f) > 0.001f)
        {
            UpdateCameras();
        }
    }

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
        // Drain pending main-thread mutations safely
        if (_pendingCastleStage.HasValue)
        {
            try
            {
                var gw = GSD2::GAME_WORK.Instance;
                if (gw?.game_data != null)
                {
                    gw.game_data.base_lv = _pendingCastleStage.Value;
                    Plugin.Log.LogInfo($"[DevMenu] Set Castle base_lv -> {_pendingCastleStage.Value}");
                }
            }
            catch { }
            _pendingCastleStage = null;
        }

        if (_pendingDanceTrigger)
        {
            try
            {
                var econ = MachiLoader_Load_Patch.LastLoadedEventcon;
                if (econ != null)
                {
                    econ.EventControll(1);
                    Plugin.Log.LogInfo("[DevMenu] Triggered Ballroom Dance Routine via EventControll(1).");
                }
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"[DevMenu] Dance trigger failed: {ex.Message}");
            }
            _pendingDanceTrigger = false;
        }

        if (_pendingObjectToggles.Count > 0)
        {
            try
            {
                var mdat = MachiLoader_Load_Patch.LastLoadedMachiDat;
                int submapIdx = MACHICON_OnMapInitPatch.CurrentSubmapIndex;
                var ed = mdat?.eventdata;

                if (ed?.mapeventdat != null && submapIdx >= 0 && submapIdx < ed.mapeventdat.Count)
                {
                    var objs = ed.mapeventdat[submapIdx]?.eventobj;
                    if (objs != null)
                    {
                        foreach (var (idx, newDisp) in _pendingObjectToggles)
                        {
                            if (idx >= 0 && idx < objs.Count && objs[idx] != null)
                            {
                                objs[idx].disp = newDisp;
                                Plugin.Log.LogInfo($"[DevMenu] Mutated obj[{idx}].disp -> {newDisp}");

                                // Live update scene GameObject if present
                                try
                                {
                                    var hdList = UnityEngine.Object.FindObjectsOfType<MapEventObjectHD>();
                                    if (hdList != null)
                                    {
                                        foreach (var hd in hdList)
                                        {
                                            if (hd != null && hd.objID == idx)
                                            {
                                                hd.gameObject.SetActive(newDisp != 0);
                                                hd.visibleSync = (newDisp != 0);
                                                try { hd.ExclusiveCheck(newDisp != 0); } catch { }
                                            }
                                        }
                                    }
                                }
                                catch { }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"[DevMenu] Error applying object toggles: {ex.Message}");
            }
            _pendingObjectToggles.Clear();
        }

        if (_pendingRoomReload)
        {
            _pendingRoomReload = false;
            try
            {
                var mc = MACHICON_OnMapInitPatch.CurrentMachicon;
                if (mc != null)
                {
                    mc.OnMapInit();
                    Plugin.Log.LogInfo("[DevMenu] Hot-reloaded current room via CurrentMachicon.OnMapInit().");
                }
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"[DevMenu] Room reload error: {ex.Message}");
            }
        }

        if (_pendingOpenRuneMaster)
        {
            _pendingOpenRuneMaster = false;
            try
            {
                if (S1QuickRunePatch.CanOpenRuneMaster(out string reason))
                {
                    S1QuickRunePatch.OpenRuneMaster();
                    Plugin.Log.LogInfo("[ImGui] Triggered Remote Castle Rune Master from ImGui menu.");
                }
                else
                {
                    Plugin.Log.LogWarning($"[ImGui] Cannot open Remote Rune Master: {reason}");
                }
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"[ImGui] Error opening Remote Rune Master: {ex.Message}");
            }
        }

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
                if (keyboard.escapeKey.wasPressedThisFrame)
                {
                    if (_showHudNoteInput || _showDevMenu)
                    {
                        _showHudNoteInput = false;
                        _showDevMenu = false;
                        SetImGuiCursorVisible(false);
                    }
                }
                else if (keyboard.f10Key.wasPressedThisFrame)
                {
                    _showDevMenu = !_showDevMenu;
                    SetImGuiCursorVisible(_showDevMenu || _showHudNoteInput);
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
                else if (keyboard.pageUpKey.wasPressedThisFrame)
                {
                    SetCameraZoom(_cameraZoom - 0.25f);
                }
                else if (keyboard.pageDownKey.wasPressedThisFrame)
                {
                    SetCameraZoom(_cameraZoom + 0.25f);
                }
                else if (keyboard.homeKey.wasPressedThisFrame)
                {
                    SetCameraZoom(1.0f);
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
            _cachedPlayerX = MACHICON_OnMapInitPatch.PlayerX;
            _cachedPlayerY = MACHICON_OnMapInitPatch.PlayerY;

            try
            {
                var mc = MACHICON_OnMapInitPatch.CurrentMachicon;
                if (mc != null)
                {
                    _cachedMx = mc.mx;
                    _cachedMy = mc.my;
                }
                else
                {
                    _cachedMx = 0;
                    _cachedMy = 0;
                }
            }
            catch
            {
                _cachedMx = 0;
                _cachedMy = 0;
            }

            try
            {
                var gw = GSD2::GAME_WORK.Instance;
                if (gw != null && gw.game_data != null)
                {
                    _cachedCastleStage = gw.game_data.base_lv;
                    _cachedHasCastleData = true;
                }
                else
                {
                    _cachedHasCastleData = false;
                }
            }
            catch
            {
                _cachedHasCastleData = false;
            }

            if (_showDevMenu)
            {
                EnsureDynamicNamesPopulated();
                try
                {
                    var mdat = MachiLoader_Load_Patch.LastLoadedMachiDat;
                    int submapIdx = MACHICON_OnMapInitPatch.CurrentSubmapIndex;
                    var ed = mdat?.eventdata;

                    _cachedAreaObjects.Clear();
                    if (ed?.mapeventdat != null && submapIdx >= 0 && submapIdx < ed.mapeventdat.Count)
                    {
                        var objs = ed.mapeventdat[submapIdx]?.eventobj;
                        if (objs != null)
                        {
                            for (int i = 0; i < objs.Count; i++)
                            {
                                var o = objs[i];
                                if (o == null) continue;
                                _cachedAreaObjects.Add(new AreaObjectSnapshot
                                {
                                    Index = i,
                                    Fpno = o.fpno,
                                    Name = GetEntityName(o.fpno, o.otyp),
                                    X = o.x,
                                    Y = o.y,
                                    W = o.w,
                                    H = o.h,
                                    Otyp = o.otyp,
                                    Disp = o.disp
                                });
                            }
                        }
                    }
                }
                catch { }
            }
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
            string entry = $"[{timestamp}] Location: {_cachedMapId} | Pos: ({_cachedPlayerX}, {_cachedPlayerY}) | Stars: {_cachedStars} / 108{notePart}" + Environment.NewLine;
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


    private static readonly System.Collections.Generic.Dictionary<int, string> _staticFpnoNames = new()
    {
        { 1, "Riou" },
        { 2, "Flik" },
        { 3, "Viktor" },
        { 4, "Viki" },
        { 5, "Sheena" },
        { 6, "Clive" },
        { 7, "Hix" },
        { 8, "Tengaar" },
        { 9, "Futch" },
        { 10, "Humphrey" },
        { 11, "Georg" },
        { 12, "Valeria" },
        { 13, "Pesmerga" },
        { 14, "Lorelai" },
        { 15, "Shin" },
        { 16, "Rikimaru" },
        { 17, "Tomo" },
        { 18, "Nanami" },
        { 19, "Eilie" },
        { 20, "Rina" },
        { 21, "Bolgan" },
        { 22, "Tuta" },
        { 23, "Hanna" },
        { 24, "Milie" },
        { 25, "Karen" },
        { 26, "Shiro" },
        { 27, "Zamza" },
        { 28, "Gengen" },
        { 29, "Gabotcha" },
        { 30, "Kinnison" },
        { 31, "Shilo" },
        { 32, "Miklotov" },
        { 33, "Camus" },
        { 34, "Hauser" },
        { 35, "Freed Y" },
        { 36, "Kahn" },
        { 37, "Amada" },
        { 38, "Tai Ho" },
        { 39, "Anita" },
        { 40, "Bob" },
        { 41, "Meg" },
        { 42, "Gadget" },
        { 43, "Ayda" },
        { 44, "Killey" },
        { 45, "Sierra" },
        { 46, "Oulan" },
        { 47, "Genshu" },
        { 48, "Mukumuku" },
        { 49, "Abizboah" },
        { 50, "Feather" },
        { 51, "Badeaux" },
        { 52, "Tsai" },
        { 53, "Luc" },
        { 54, "Chaco" },
        { 55, "Nina" },
        { 56, "Sid" },
        { 57, "Yoshino" },
        { 58, "Gijimu" },
        { 59, "Koyu" },
        { 60, "Lo Wen" },
        { 61, "Mazus" },
        { 62, "Sasuke" },
        { 63, "Mondo" },
        { 64, "Vincent" },
        { 65, "Simone" },
        { 66, "Hai Yo" },
        { 67, "Stallion" },
        { 68, "Wakaba" },
        { 69, "Long Chan-Chan" },
        { 70, "Gantetsu" },
        { 71, "Hoi" },
        { 72, "Siegfried" },
        { 73, "Kasumi" },
        { 74, "Rulodia" },
        { 75, "Makumaku" },
        { 76, "Mikumiku" },
        { 77, "Mekumeku" },
        { 78, "MokuMoku" },
        { 79, "Chuchara" },
        { 80, "Jowy 1" },
        { 81, "Jowy 2" },
        { 82, "McDohl" },
        { 83, "Milie Sans Bonapart" },
        { 84, "Bonaparte" },
        { 85, "Apple" },
        { 86, "Templton" },
        { 87, "Kiba" },
        { 88, "Fitcher" },
        { 89, "Shu" },
        { 90, "Tetsu" },
        { 91, "Leona" },
        { 92, "Huan" },
        { 93, "Jess" },
        { 94, "Hilda" },
        { 95, "Alex" },
        { 96, "Emilia" },
        { 97, "Tenkou" },
        { 98, "Barbara" },
        { 99, "Richmond" },
        { 100, "Yam Koo" },
        { 101, "Teresa" },
        { 102, "Yuzu" },
        { 103, "Taki" },
        { 104, "Tony" },
        { 105, "Adlai" },
        { 106, "Gordon" },
        { 107, "Hans" },
        { 108, "Connell" },
        { 109, "Lebrante" },
        { 110, "Tessai" },
        { 111, "Raura" },
        { 112, "Annallee" },
        { 113, "Pico" },
        { 114, "Alberto" },
        { 115, "Jude" },
        { 116, "Jeane" },
        { 117, "Ridley" },
        { 118, "Klaus" },
        { 119, "Max" },
        { 120, "Marlowe" },
        { 121, "Gilbert" },
        { 122, "Boris" },
        { 123, "Pilika 1" },
        { 124, "Pilika 2" },
        { 125, "Gremio" },
        { 126, "NA-" },
        { 127, "NA-" },
        { 128, "Marx" },
        { 129, "Joanna" },
        { 130, "Leknaat" },
        { 131, "Lepant" },
        { 132, "Varkas" },
        { 133, "Alen" },
        { 134, "Glenshiel" },
        { 135, "Anabelle" },
        { 136, "Granmeyer" },
        { 137, "Makai" },
        { 138, "Gustav" },
        { 139, "Gordeau" },
        { 140, "Luca" },
        { 141, "Jillia" },
        { 142, "Solon Jhee" },
        { 143, "Culgan" },
        { 144, "Seed" },
        { 145, "Rowd" },
        { 146, "Agares" },
        { 147, "Leon" },
        { 148, "Han" },
        { 149, "Genkaku" },
        { 150, "Sasarai" },
        { 151, "Neclord" },
        { 152, "Suikoden" },
        { 153, "Celestial Sword" },
        { 154, "Lilly" },
        { 155, "Lucia" },
        { 156, "Yuber" },
        { 157, "Kage" },
        { 158, "Antonio" },
        { 159, "Lester" },
        { 160, "Cleo" },
        { 161, "Pahn" },
        { 162, "Marie" },
        { 163, "Sarah" },
        { 164, "Tesla" },
        { 165, "Liukan" },
        { 166, "Eileen" },
        { 167, "Elza" },
        { 168, "Ellie" },
        { 169, "Pohl" },
    };

    private static readonly System.Collections.Generic.Dictionary<int, string> _dynamicFpnoNames = new();
    private static bool _dynamicNamesPopulated = false;

    private static void EnsureDynamicNamesPopulated()
    {
        if (_dynamicNamesPopulated || !GameDetection.IsGSD2()) return;
        try
        {
            for (int i = 0; i <= 200; i++)
            {
                try
                {
                    int faceNo = GSD2::w_chara.GetCharaFaceNo(i);
                    if (faceNo > 0)
                    {
                        string bigName = GSD2::w_chara.GetCharaBigNameString(i);
                        if (!string.IsNullOrWhiteSpace(bigName))
                        {
                            _dynamicFpnoNames[faceNo] = bigName.Trim();
                        }
                    }
                }
                catch { }
            }
            _dynamicNamesPopulated = true;
        }
        catch { }
    }

    public static string GetEntityName(int fpno, int otyp)
    {
        short signedFp = (short)fpno;

        if (signedFp == 0)
        {
            return otyp == 0 ? "Trigger / Zone" : "Mechanism";
        }

        if (_dynamicFpnoNames.TryGetValue(signedFp, out string dynName) && !string.IsNullOrEmpty(dynName))
        {
            return dynName;
        }

        if (_staticFpnoNames.TryGetValue(signedFp, out string statName))
        {
            return statName;
        }

        if (signedFp < 0 || signedFp > 1000)
        {
            return $"Prop #{fpno & 0xFFFF}";
        }

        return $"NPC #{signedFp}";
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
            if (_showHudNoteInput || _showDevMenu)
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
        if (_showDevMenu)
        {
            DrawDevMenu();
        }
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
                ImGui.TextColored(new Vector4(0.35f, 0.85f, 1f, 1f), $"P:({_cachedPlayerX},{_cachedPlayerY}) M:({_cachedMx},{_cachedMy}) T:({_cachedMx/16},{_cachedMy/16})");

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

                ImGui.SameLine();
                string menuBtnLabel = _showDevMenu ? "[Close Menu]" : "[Menu]";
                if (ImGui.SmallButton(menuBtnLabel + "##ToggleDevMenu"))
                {
                    _showDevMenu = !_showDevMenu;
                    RequestCursorVisible(_showDevMenu || _showHudNoteInput);
                }

                ImGui.SameLine();
                ImGui.TextDisabled("|");
                ImGui.SameLine();
                ImGui.TextColored(new Vector4(0.9f, 0.7f, 0.2f, 1f), $"FOV: {_cameraZoom:F2}x");
                ImGui.SameLine();
                if (ImGui.SmallButton("[Out]##ZoomOut"))
                {
                    SetCameraZoom(_cameraZoom + 0.25f);
                }
                ImGui.SameLine();
                if (ImGui.SmallButton("[In]##ZoomIn"))
                {
                    SetCameraZoom(_cameraZoom - 0.25f);
                }
                ImGui.SameLine();
                if (ImGui.SmallButton("[1x]##ZoomReset"))
                {
                    SetCameraZoom(1.0f);
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

    private static readonly string[] _availableThemes = new[]
    {
        "Classic Blue",
        "Matrix",
        "Obsidian Black",
        "Dark Magenta"
    };

    private static readonly string[] _availableSaveColors = new[]
    {
        "default", "black", "blue", "cyan", "green", "navy", "pink", "purple", "red", "white", "yellow", "random"
    };

    private static readonly string[] _availableSMAAOptions = new[]
    {
        "Off", "Low", "Medium", "High"
    };

    /// <summary>
    /// Renders the unified PKCore Control Suite & Feature Dashboard.
    /// </summary>
    private static void DrawDevMenu()
    {
        try
        {
            ImGui.SetNextWindowSize(new Vector2(620f, 520f), ImGuiCond.FirstUseEver);
            if (ImGui.Begin("PKCore Control Suite [F10]###PKCoreControlSuite", ref _showDevMenu, ImGuiWindowFlags.NoCollapse))
            {
                ImGui.TextColored(GetAccentColor(), "Project Kyaro Core Dashboard");
                ImGui.SameLine();
                string activeGame = GameDetection.IsGSD1() ? "[Suikoden I]" : (GameDetection.IsGSD2() ? "[Suikoden II]" : "[Launcher / Menu]");
                ImGui.TextColored(new Vector4(0.35f, 0.85f, 1f, 1f), activeGame);
                ImGui.Separator();

                if (ImGui.BeginTabBar("PKCoreMainTabs", ImGuiTabBarFlags.None))
                {
                    // =========================================================
                    // TAB 1: GAMEPLAY & EXPLORATION
                    // =========================================================
                    if (ImGui.BeginTabItem("Gameplay & Exploration###TabGameplay"))
                    {
                        ImGui.Spacing();
                        ImGui.TextColored(GetAccentColor(), "Encounters & Battles");

                        bool encNone = EncounterNonePatch.IsEncounterNone;
                        if (ImGui.Checkbox("Suppress Random Encounters (Encounter None [F4])", ref encNone))
                        {
                            EncounterNonePatch.SetEncounterNone(encNone);
                        }
                        ImGui.TextDisabled($"Status: {(EncounterNonePatch.IsEncounterNone ? "SUPPRESSED" : "Normal")} | Backend: {EncounterNonePatch.BackendStatus}");

                        ImGui.Spacing();
                        ImGui.Separator();
                        ImGui.Spacing();
                        ImGui.TextColored(GetAccentColor(), "World Map Visuals");

                        if (Plugin.Config != null)
                        {
                            bool noClouds = Plugin.Config.DisableWorldMapClouds.Value;
                            if (ImGui.Checkbox("Disable World Map Clouds", ref noClouds))
                            {
                                Plugin.Config.DisableWorldMapClouds.Value = noClouds;
                            }

                            bool noSunrays = Plugin.Config.DisableWorldMapSunrays.Value;
                            if (ImGui.Checkbox("Disable World Map Sunrays", ref noSunrays))
                            {
                                Plugin.Config.DisableWorldMapSunrays.Value = noSunrays;
                            }
                        }

                        if (GameDetection.IsGSD1())
                        {
                            ImGui.Spacing();
                            ImGui.Separator();
                            ImGui.Spacing();
                            ImGui.TextColored(GetAccentColor(), "Suikoden I Castle Services");

                            bool canOpenRune = S1QuickRunePatch.CanOpenRuneMaster(out string runeReason);
                            if (!canOpenRune)
                            {
                                ImGui.BeginDisabled();
                            }
                            if (ImGui.Button("Open Remote Castle Rune Master (Jeane)##QuickRuneBtn"))
                            {
                                _pendingOpenRuneMaster = true;
                            }
                            if (!canOpenRune)
                            {
                                ImGui.EndDisabled();
                                ImGui.SameLine();
                                ImGui.TextColored(new Vector4(1f, 0.4f, 0.4f, 1f), $"({runeReason})");
                            }
                        }

                        ImGui.EndTabItem();
                    }

                    // =========================================================
                    // TAB 2: VISUALS & SHADERS
                    // =========================================================
                    if (ImGui.BeginTabItem("Visuals & Shaders###TabVisuals"))
                    {
                        ImGui.Spacing();
                        ImGui.TextColored(GetAccentColor(), "Save Point Customization");

                        if (Plugin.Config != null)
                        {
                            string curColor = Plugin.Config.SavePointColor.Value ?? "default";
                            int colorIdx = Array.FindIndex(_availableSaveColors, c => string.Equals(c, curColor, StringComparison.OrdinalIgnoreCase));
                            if (colorIdx < 0) colorIdx = 0;

                            ImGui.SetNextItemWidth(160f);
                            if (ImGui.Combo("Save Point Color", ref colorIdx, _availableSaveColors, _availableSaveColors.Length))
                            {
                                Plugin.Config.SavePointColor.Value = _availableSaveColors[colorIdx];
                                CustomTexturePatch.RefreshSavePointColorForRoomEntry(_cachedMapId);
                            }

                            bool noGlow = Plugin.Config.DisableSavePointGlow.Value;
                            if (ImGui.Checkbox("Disable Save Point White Glow", ref noGlow))
                            {
                                Plugin.Config.DisableSavePointGlow.Value = noGlow;
                            }

                            ImGui.Spacing();
                            ImGui.Separator();
                            ImGui.Spacing();
                            ImGui.TextColored(GetAccentColor(), "Sprite Rendering & Anti-Aliasing");

                            bool spriteFilt = Plugin.Config.SpriteFilteringEnabled.Value;
                            if (ImGui.Checkbox("Sprite Filtering (Bilinear + 2x Anisotropic)", ref spriteFilt))
                            {
                                Plugin.Config.SpriteFilteringEnabled.Value = spriteFilt;
                                SpriteFilteringPatch.Initialize();
                            }

                            bool noPostProc = Plugin.Config.DisableSpritePostProcessing.Value;
                            if (ImGui.Checkbox("Disable Sprite Post-Processing (Fixes outline bleed & bloom)", ref noPostProc))
                            {
                                Plugin.Config.DisableSpritePostProcessing.Value = noPostProc;
                                DisableSpritePostProcessingPatch.Initialize();
                            }

                            string curSMAA = Plugin.Config.SMAAQuality.Value ?? "Low";
                            int smaaIdx = Array.FindIndex(_availableSMAAOptions, opt => string.Equals(opt, curSMAA, StringComparison.OrdinalIgnoreCase));
                            if (smaaIdx < 0) smaaIdx = 1;

                            ImGui.SetNextItemWidth(160f);
                            if (ImGui.Combo("SMAA Anti-Aliasing", ref smaaIdx, _availableSMAAOptions, _availableSMAAOptions.Length))
                            {
                                Plugin.Config.SMAAQuality.Value = _availableSMAAOptions[smaaIdx];
                            }
                        }

                        ImGui.EndTabItem();
                    }

                    // =========================================================
                    // TAB 3: INTERFACE & WINDOW
                    // =========================================================
                    if (ImGui.BeginTabItem("Interface & Window###TabInterface"))
                    {
                        ImGui.Spacing();
                        ImGui.TextColored(GetAccentColor(), "Window Display Modes");

                        if (Plugin.Config != null)
                        {
                            bool borderless = Plugin.Config.EnableBorderlessWindow.Value;
                            if (ImGui.Checkbox("Borderless Floating Window Mode", ref borderless))
                            {
                                Plugin.Config.EnableBorderlessWindow.Value = borderless;
                                BorderlessWindowPatch.Initialize();
                            }
                            ImGui.TextDisabled("Removes OS titlebar and borders in windowed mode for custom compact sizes.");

                            ImGui.Spacing();
                            ImGui.Separator();
                            ImGui.Spacing();
                            ImGui.TextColored(GetAccentColor(), "Dialog & Menu Scaling");

                            bool scaleDialog = Plugin.Config.ScaleDownDialogBox.Value;
                            if (ImGui.Checkbox("Scale Down Dialog Box (80% Size)", ref scaleDialog))
                            {
                                Plugin.Config.ScaleDownDialogBox.Value = scaleDialog;
                            }

                            bool miniUI = Plugin.Config.MinimalUI.Value;
                            if (ImGui.Checkbox("Minimal UI Texture Variants", ref miniUI))
                            {
                                Plugin.Config.MinimalUI.Value = miniUI;
                            }

                            bool noMask = Plugin.Config.DisablePortraitDialogMask.Value;
                            if (ImGui.Checkbox("Disable Portrait Dialog Mask", ref noMask))
                            {
                                Plugin.Config.DisablePortraitDialogMask.Value = noMask;
                            }

                            bool noTips = Plugin.Config.DisableUITips.Value;
                            if (ImGui.Checkbox("Disable Control Tips Overlay (UITips)", ref noTips))
                            {
                                Plugin.Config.DisableUITips.Value = noTips;
                            }

                            ImGui.Spacing();
                            ImGui.Separator();
                            ImGui.Spacing();
                            ImGui.TextColored(GetAccentColor(), "Save Window Aesthetics");

                            bool classicSave = Plugin.Config.ClassicSaveWindow.Value;
                            if (ImGui.Checkbox("Classic PSX Save Window Look", ref classicSave))
                            {
                                Plugin.Config.ClassicSaveWindow.Value = classicSave;
                            }

                            bool partyPortraits = Plugin.Config.ShowSaveSlotPartyPortraits.Value;
                            if (ImGui.Checkbox("Show Save Slot Party Member Mini-Portraits", ref partyPortraits))
                            {
                                Plugin.Config.ShowSaveSlotPartyPortraits.Value = partyPortraits;
                            }
                        }

                        ImGui.EndTabItem();
                    }

                    // =========================================================
                    // TAB 4: CASTLE & WORLD STATE (S2)
                    // =========================================================
                    if (ImGui.BeginTabItem("Castle & World State###TabCastle"))
                    {
                        ImGui.Spacing();
                        if (!GameDetection.IsGSD2())
                        {
                            ImGui.TextColored(new Vector4(1f, 0.4f, 0.4f, 1f), "Suikoden II Feature");
                            ImGui.TextWrapped("The Castle Stage modifier and Area Object Inspector are currently designed exclusively for Suikoden II map structures.");
                        }
                        else
                        {
                            ImGui.Text("Active Map: " + (_cachedMapId ?? "None"));

                            ImGui.Spacing();
                            if (ImGui.CollapsingHeader("Castle Stage & State", ImGuiTreeNodeFlags.DefaultOpen))
                            {
                                if (_cachedHasCastleData)
                                {
                                    byte currentTier = _cachedCastleStage;
                                    ImGui.Text($"Current Castle Stage: Level {currentTier} (internal base_lv: {currentTier})");
                                    ImGui.Spacing();

                                    for (byte lvl = 0; lvl <= 4; lvl++)
                                    {
                                        string label = lvl switch
                                        {
                                            0 => "Stage 0 (Mobile / Fort)",
                                            1 => "Stage 1 (Castle Level 1)",
                                            2 => "Stage 2 (Castle Level 2 - Two River)",
                                            3 => "Stage 3 (Castle Level 3 - Post-Greenhill)",
                                            4 => "Stage 4 (Castle Level 4 - Grand Fortress)",
                                            _ => $"Stage {lvl}"
                                        };

                                        if (currentTier == lvl)
                                        {
                                            ImGui.TextColored(new Vector4(0.2f, 0.9f, 0.55f, 1f), $"-> {label} [Active]");
                                        }
                                        else
                                        {
                                            if (ImGui.Button($"Set {label}##SetBaseLv{lvl}"))
                                            {
                                                _pendingCastleStage = lvl;
                                                _cachedCastleStage = lvl;
                                                Plugin.Log.LogInfo($"[DevMenu] Queued Castle base_lv -> {lvl}.");
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    ImGui.TextDisabled("Game state not yet loaded.");
                                }
                            }

                            ImGui.Spacing();
                            if (ImGui.CollapsingHeader("Area Objects & NPC Inspector", ImGuiTreeNodeFlags.DefaultOpen))
                            {
                                if (_cachedAreaObjects != null && _cachedAreaObjects.Count > 0)
                                {
                                    int disabledCount = 0;
                                    int enabledCount = 0;
                                    for (int i = 0; i < _cachedAreaObjects.Count; i++)
                                    {
                                        if (_cachedAreaObjects[i].Disp == 0) disabledCount++;
                                        else enabledCount++;
                                    }

                                    ImGui.Text($"Total Objects: {_cachedAreaObjects.Count}  |  Visible: {enabledCount}  |  Hidden: {disabledCount}");
                                    ImGui.SameLine();
                                    if (ImGui.SmallButton("Reload Room / Objects##DevReloadBtn"))
                                    {
                                        _pendingRoomReload = true;
                                    }

                                    ImGui.Spacing();
                                    ImGui.BeginChild("ObjectsListScroll", new Vector2(0, 200f), true);

                                    for (int i = 0; i < _cachedAreaObjects.Count; i++)
                                    {
                                        var o = _cachedAreaObjects[i];

                                        bool isVisible = o.Disp != 0;
                                        Vector4 statusColor = isVisible ? new Vector4(0.3f, 1f, 0.4f, 1f) : new Vector4(0.85f, 0.4f, 0.4f, 1f);
                                        string statusText = isVisible ? "[Show]" : "[Hide]";

                                        ImGui.PushID($"ObjRow_{o.Index}");

                                        ImGui.TextColored(statusColor, statusText);
                                        ImGui.SameLine();
                                        ImGui.TextColored(new Vector4(0.9f, 0.9f, 0.4f, 1f), $"[{o.Index:D2}]");
                                        ImGui.SameLine();

                                        Vector4 nameColor = isVisible ? new Vector4(0.95f, 0.95f, 0.95f, 1f) : new Vector4(0.55f, 0.55f, 0.55f, 1f);
                                        ImGui.TextColored(nameColor, $"{o.Name,-18}");
                                        ImGui.SameLine();

                                        ImGui.TextDisabled($"fp:{o.Fpno,-3} ({o.X,2},{o.Y,2})");

                                        ImGui.SameLine();
                                        string toggleLabel = isVisible ? "Hide##Toggle" : "Show##Toggle";
                                        if (ImGui.SmallButton(toggleLabel))
                                        {
                                            byte nextDisp = (byte)(isVisible ? 0 : 1);
                                            _pendingObjectToggles.Add((o.Index, nextDisp));
                                            o.Disp = nextDisp;
                                            _pendingRoomReload = true;
                                        }

                                        ImGui.PopID();
                                    }

                                    ImGui.EndChild();
                                }
                                else
                                {
                                    ImGui.TextDisabled("No event objects found in current submap.");
                                }
                            }

                            ImGui.Spacing();
                            if (ImGui.CollapsingHeader("Restored Features & Cut Content", ImGuiTreeNodeFlags.None))
                            {
                                if (ImGui.Button("Trigger Ballroom Dance Routine (vk19)"))
                                {
                                    _pendingDanceTrigger = true;
                                }

                                ImGui.Spacing();
                                ImGui.TextDisabled("Castle Level 4 Dormant Features:");
                                ImGui.BulletText("vk03: Animal Paddock tier 4 feeding troughs (obj 37..40)");
                                ImGui.BulletText("vk09: Theater / Concert Hall expansion & backstage");
                                ImGui.BulletText("vk11: Armory / Forge upper expansion tiers");
                                ImGui.BulletText("vk13: Riou's Living Quarters / Penthouse exterior pathing");
                                ImGui.BulletText("vk14: Stone tablet & library archive expansions");
                                ImGui.BulletText("vk16: Cut Fallen Heroes Memorial Stage");
                            }
                        }

                        ImGui.EndTabItem();
                    }

                    // =========================================================
                    // TAB 5: SYSTEM & TELEMETRY
                    // =========================================================
                    if (ImGui.BeginTabItem("System & Themes###TabSystem"))
                    {
                        ImGui.Spacing();
                        ImGui.TextColored(GetAccentColor(), "Overlay Themes & Customization");

                        int themeIdx = (int)_currentTheme;
                        ImGui.SetNextItemWidth(160f);
                        if (ImGui.Combo("Color Theme", ref themeIdx, _availableThemes, _availableThemes.Length))
                        {
                            SetTheme((ThemePreset)themeIdx);
                        }

                        bool showHud = ShowLocationHUD;
                        if (ImGui.Checkbox("Show Bottom-Left Location HUD", ref showHud))
                        {
                            ShowLocationHUD = showHud;
                        }

                        bool mouseVis = MouseCursorPatch.IsEnabled;
                        if (ImGui.Checkbox("Force OS Mouse Cursor Visible", ref mouseVis))
                        {
                            MouseCursorPatch.IsEnabled = mouseVis;
                            RequestCursorVisible(mouseVis);
                        }

                        ImGui.Spacing();
                        ImGui.Separator();
                        ImGui.Spacing();
                        ImGui.TextColored(GetAccentColor(), "Camera Telemetry & Logs");

                        ImGui.Text($"Camera FOV Zoom: {_cameraZoom:F2}x");
                        ImGui.SameLine();
                        if (ImGui.SmallButton("Reset (1x)##SysResetZoom"))
                        {
                            SetCameraZoom(1.0f);
                        }

                        ImGui.Spacing();
                        if (ImGui.Button("Dump Current Location to Log [NumPad 5]##SysDumpBtn"))
                        {
                            DumpCurrentLocation();
                        }
                        ImGui.SameLine();
                        if (ImGui.Button("Open Logs Directory##SysOpenLogBtn"))
                        {
                            OpenDumpLocation();
                        }

                        ImGui.EndTabItem();
                    }

                    ImGui.EndTabBar();
                }

                ImGui.Spacing();
                ImGui.Separator();
                if (ImGui.Button("Close Menu##DevMenuClose"))
                {
                    _showDevMenu = false;
                    RequestCursorVisible(_showHudNoteInput);
                }
            }
            ImGui.End();
        }
        catch { }
    }
}

/// <summary>
/// Ensures BindCamera.LateUpdate does not wipe out camera zoom when synchronizing cameras.
/// </summary>
[HarmonyPatch(typeof(BindCamera), nameof(BindCamera.Sync))]
public static class BindCamera_Sync_Patch
{
    [HarmonyPostfix]
    public static void Postfix(BindCamera __instance, bool isDetailCopy)
    {
        try
        {
            if (Math.Abs(ImGuiOverlayUI.CameraZoom - 1.0f) < 0.001f || __instance == null || __instance.myCamera == null)
                return;

            ImGuiOverlayUI.ApplyZoomToCamera(__instance.myCamera);
        }
        catch { }
    }
}
