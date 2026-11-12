#nullable enable
extern alias GSD2;

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

namespace PKCore.Patches;

/// <summary>
/// Unity Canvas UI and input controller for Apple's War Room menu, War Battle Replay selector,
/// and post-simulation return banner in Suikoden II.
/// </summary>
public static class S2WarReplayMenu
{
    public enum MenuScreen
    {
        Closed,
        HubChoice,
        BattleSelector
    }

    public static MenuScreen CurrentScreen { get; private set; } = MenuScreen.Closed;
    public static bool IsOpen => CurrentScreen != MenuScreen.Closed;

    private static Action? _onChooseOrganize;
    private static Action<int>? _onChooseReplayBattle;
    private static Action? _onCancel;

    private static GameObject? _canvasRoot;
    private static GameObject? _hubPanel;
    private static GameObject? _selectorPanel;
    private static GameObject? _toastPanel;
    private static TMP_Text? _toastText;
    private static float _toastHideAt = -1f;

    // Hub state
    private static int _hubIndex = 0;
    private static readonly Image?[] _hubRowBg = new Image?[3];
    private static readonly TMP_Text?[] _hubRowText = new TMP_Text?[3];

    // Selector state
    private const int VisibleRows = 10;
    private static int _battleIndex = 0;
    private static int _scrollOffset = 0;
    private static readonly Image?[] _rowBg = new Image?[VisibleRows];
    private static readonly TMP_Text?[] _rowLabel = new TMP_Text?[VisibleRows];
    private static readonly TMP_Text?[] _rowTag = new TMP_Text?[VisibleRows];
    private static readonly int[] _rowToBattleIdx = new int[VisibleRows];

    private static TMP_Text? _detailTitle;
    private static TMP_Text? _detailMeta;
    private static TMP_Text? _detailRules;
    private static TMP_Text? _detailRoster;
    private static TMP_Text? _detailSandbox;
    private static TMP_Text? _scrollHint;
    private static Image? _launchBtnImg;
    private static TMP_Text? _launchBtnText;

    private static TMP_FontAsset? _cachedTmpFont;
    private static float _lastMoveTime = 0f;
    private static float _openedAt = 0f;
    private static bool _prevPadUp, _prevPadDown, _prevPadLeft, _prevPadRight, _prevPadDecide, _prevPadCancel;

    private static readonly Color ColBackdrop = new(0.02f, 0.04f, 0.09f, 0.72f);
    private static readonly Color ColPanelBg = new(0.055f, 0.09f, 0.18f, 0.96f);
    private static readonly Color ColSubPanelBg = new(0.035f, 0.06f, 0.13f, 0.92f);
    private static readonly Color ColGoldBorder = new(0.80f, 0.65f, 0.28f, 0.95f);
    private static readonly Color ColRowIdle = new(0.08f, 0.13f, 0.25f, 0.75f);
    private static readonly Color ColRowSelected = new(0.20f, 0.34f, 0.58f, 0.95f);
    private static readonly Color ColBtnLaunch = new(0.16f, 0.42f, 0.28f, 0.95f);
    private static readonly Color ColBtnDisabled = new(0.18f, 0.18f, 0.22f, 0.75f);
    private static readonly Color ColTextMain = new(0.95f, 0.93f, 0.87f, 1f);
    private static readonly Color ColTextGold = new(0.96f, 0.82f, 0.42f, 1f);
    private static readonly Color ColTextMuted = new(0.62f, 0.66f, 0.75f, 1f);
    private static readonly Color ColTextWarn = new(0.95f, 0.62f, 0.35f, 1f);
    private static readonly Color ColTextReady = new(0.55f, 0.92f, 0.65f, 1f);

    public static void OpenHub(Action onOrganize, Action<int> onReplayBattle, Action onCancel)
    {
        _onChooseOrganize = onOrganize;
        _onChooseReplayBattle = onReplayBattle;
        _onCancel = onCancel;

        EnsureCanvas();
        if (_canvasRoot == null) return;

        _hubIndex = 0;
        _openedAt = Time.unscaledTime;
        SyncPrevInputs();

        CurrentScreen = MenuScreen.HubChoice;
        _canvasRoot.SetActive(true);
        if (_hubPanel != null) _hubPanel.SetActive(true);
        if (_selectorPanel != null) _selectorPanel.SetActive(false);

        RefreshHubVisuals();
    }

    public static void Close()
    {
        CurrentScreen = MenuScreen.Closed;
        if (_hubPanel != null) _hubPanel.SetActive(false);
        if (_selectorPanel != null) _selectorPanel.SetActive(false);

        if (_canvasRoot != null && (_toastPanel == null || !_toastPanel.activeSelf))
        {
            _canvasRoot.SetActive(false);
        }
    }

    public static void ShowToast(string message, float durationSeconds = 4.5f)
    {
        EnsureCanvas();
        if (_canvasRoot == null || _toastPanel == null || _toastText == null) return;

        _toastText.text = message;
        _toastHideAt = Time.unscaledTime + durationSeconds;
        _canvasRoot.SetActive(true);
        _toastPanel.SetActive(true);
    }

    public static void Update()
    {
        if (_toastPanel != null && _toastPanel.activeSelf && Time.unscaledTime >= _toastHideAt)
        {
            _toastPanel.SetActive(false);
            if (!IsOpen && _canvasRoot != null)
                _canvasRoot.SetActive(false);
        }

        if (!IsOpen) return;

        // Ignore the first frame press left over from confirming Apple's dialogue
        if (Time.unscaledTime - _openedAt < 0.16f)
        {
            SyncPrevInputs();
            return;
        }

        bool up = PollPress(GRInputManager.Type.Up, Key.UpArrow, Key.W, ref _prevPadUp, allowRepeat: true);
        bool down = PollPress(GRInputManager.Type.Down, Key.DownArrow, Key.S, ref _prevPadDown, allowRepeat: true);
        bool left = PollPress(GRInputManager.Type.Left, Key.LeftArrow, Key.A, ref _prevPadLeft, allowRepeat: true);
        bool right = PollPress(GRInputManager.Type.Right, Key.RightArrow, Key.D, ref _prevPadRight, allowRepeat: true);
        bool decide = PollPress(GRInputManager.Type.Decide, Key.Enter, Key.Z, ref _prevPadDecide, allowRepeat: false)
                      || IsKeyDownSafe(Key.Space) || IsKeyDownSafe(Key.NumpadEnter);
        bool cancel = PollPress(GRInputManager.Type.Cancel, Key.Escape, Key.X, ref _prevPadCancel, allowRepeat: false)
                      || IsKeyDownSafe(Key.Backspace);

        if (CurrentScreen == MenuScreen.HubChoice)
        {
            if (up)
            {
                _hubIndex = (_hubIndex + 2) % 3;
                RefreshHubVisuals();
            }
            else if (down)
            {
                _hubIndex = (_hubIndex + 1) % 3;
                RefreshHubVisuals();
            }
            else if (cancel)
            {
                Close();
                _onCancel?.Invoke();
            }
            else if (decide)
            {
                ActivateHubOption(_hubIndex);
            }
        }
        else if (CurrentScreen == MenuScreen.BattleSelector)
        {
            int count = S2WarReplayData.Battles.Count;
            if (count == 0) return;

            if (up)
            {
                _battleIndex = (_battleIndex - 1 + count) % count;
                EnsureVisibleSelection();
                RefreshSelectorVisuals();
            }
            else if (down)
            {
                _battleIndex = (_battleIndex + 1) % count;
                EnsureVisibleSelection();
                RefreshSelectorVisuals();
            }
            else if (left)
            {
                _battleIndex = Math.Max(0, _battleIndex - VisibleRows);
                EnsureVisibleSelection();
                RefreshSelectorVisuals();
            }
            else if (right)
            {
                _battleIndex = Math.Min(count - 1, _battleIndex + VisibleRows);
                EnsureVisibleSelection();
                RefreshSelectorVisuals();
            }
            else if (cancel)
            {
                SwitchToHub();
            }
            else if (decide)
            {
                TryLaunchSelectedBattle();
            }
        }
    }

    private static void ActivateHubOption(int idx)
    {
        if (idx == 0)
        {
            Close();
            _onChooseOrganize?.Invoke();
        }
        else if (idx == 1)
        {
            SwitchToBattleSelector();
        }
        else
        {
            Close();
            _onCancel?.Invoke();
        }
    }

    private static void SwitchToHub()
    {
        CurrentScreen = MenuScreen.HubChoice;
        _openedAt = Time.unscaledTime;
        if (_hubPanel != null) _hubPanel.SetActive(true);
        if (_selectorPanel != null) _selectorPanel.SetActive(false);
        RefreshHubVisuals();
    }

    private static void SwitchToBattleSelector()
    {
        CurrentScreen = MenuScreen.BattleSelector;
        _openedAt = Time.unscaledTime;

        // Default to first unlocked non-cutscene battle if current selection is locked
        var gw = GetGameWork();
        if (!S2WarReplayData.IsUnlocked(S2WarReplayData.Battles[_battleIndex], gw))
        {
            for (int i = 0; i < S2WarReplayData.Battles.Count; i++)
            {
                if (S2WarReplayData.IsUnlocked(S2WarReplayData.Battles[i], gw))
                {
                    _battleIndex = i;
                    break;
                }
            }
        }

        EnsureVisibleSelection();
        if (_hubPanel != null) _hubPanel.SetActive(false);
        if (_selectorPanel != null) _selectorPanel.SetActive(true);
        RefreshSelectorVisuals();
    }

    private static void TryLaunchSelectedBattle()
    {
        var entry = S2WarReplayData.Battles[_battleIndex];
        var gw = GetGameWork();
        if (!S2WarReplayData.IsUnlocked(entry, gw))
            return;

        Close();
        _onChooseReplayBattle?.Invoke(entry.WarNo);
    }

    private static void EnsureVisibleSelection()
    {
        if (_battleIndex < _scrollOffset)
            _scrollOffset = _battleIndex;
        else if (_battleIndex >= _scrollOffset + VisibleRows)
            _scrollOffset = _battleIndex - VisibleRows + 1;

        int maxOffset = Math.Max(0, S2WarReplayData.Battles.Count - VisibleRows);
        _scrollOffset = Math.Clamp(_scrollOffset, 0, maxOffset);
    }

    private static void RefreshHubVisuals()
    {
        for (int i = 0; i < 3; i++)
        {
            bool sel = (i == _hubIndex);
            if (_hubRowBg[i] != null)
                _hubRowBg[i]!.color = sel ? ColRowSelected : ColRowIdle;
            if (_hubRowText[i] != null)
                _hubRowText[i]!.color = sel ? ColTextGold : ColTextMain;
        }
    }

    private static void RefreshSelectorVisuals()
    {
        var gw = GetGameWork();
        int count = S2WarReplayData.Battles.Count;

        for (int r = 0; r < VisibleRows; r++)
        {
            int idx = _scrollOffset + r;
            _rowToBattleIdx[r] = idx;

            if (idx >= count)
            {
                if (_rowBg[r] != null) _rowBg[r]!.gameObject.SetActive(false);
                continue;
            }

            if (_rowBg[r] != null) _rowBg[r]!.gameObject.SetActive(true);

            var entry = S2WarReplayData.Battles[idx];
            bool unlocked = S2WarReplayData.IsUnlocked(entry, gw);
            bool sel = (idx == _battleIndex);

            if (_rowBg[r] != null)
                _rowBg[r]!.color = sel ? ColRowSelected : ColRowIdle;

            if (_rowLabel[r] != null)
            {
                _rowLabel[r]!.text = $"{entry.WarNo:D2}. {entry.Title}";
                _rowLabel[r]!.color = unlocked ? (sel ? ColTextGold : ColTextMain) : ColTextMuted;
            }

            if (_rowTag[r] != null)
            {
                if (!unlocked)
                {
                    _rowTag[r]!.text = "LOCKED";
                    _rowTag[r]!.color = ColTextMuted;
                }
                else if (entry.IsCutsceneOnly)
                {
                    _rowTag[r]!.text = "SCENE";
                    _rowTag[r]!.color = ColTextWarn;
                }
                else
                {
                    _rowTag[r]!.text = $"MAP {entry.MapNo}";
                    _rowTag[r]!.color = sel ? ColTextGold : ColTextReady;
                }
            }
        }

        if (_scrollHint != null)
            _scrollHint.text = $"Showing {_scrollOffset + 1}-{Math.Min(count, _scrollOffset + VisibleRows)} of {count}   (Left/Right: Page)";

        var selected = S2WarReplayData.Battles[_battleIndex];
        bool canLaunch = S2WarReplayData.IsUnlocked(selected, gw);

        if (_detailTitle != null)
        {
            _detailTitle.text = $"Battle {selected.WarNo:D2}: {selected.Title}";
            _detailTitle.color = canLaunch ? ColTextGold : ColTextMuted;
        }

        if (_detailMeta != null)
        {
            _detailMeta.text = $"Campaign: {selected.Region}\nWar Map ID: {selected.MapNo}   |   Forces: {selected.AllyCount} Allied vs {selected.EnemyCount} Enemy units";
        }

        if (_detailRules != null)
        {
            string statusLine = !canLaunch
                ? "Status: Locked (Progress further in the story or set UnlockAllWarReplays = true in config)"
                : selected.IsCutsceneOnly
                    ? "Note: Scripted confrontation battle — ends immediately on Turn 1."
                    : "Status: Ready for simulation.";
            _detailRules.text = $"Objectives:\n{selected.VictoryRules}\n\n{statusLine}";
        }

        if (_detailRoster != null)
        {
            _detailRoster.text = selected.UsesCustomArmyRoster
                ? "Deployment: Uses your current Castle HQ Battle Units (War 6+)."
                : "Deployment: Uses fixed historical story units (Wars 1-5).";
        }

        if (_detailSandbox != null)
        {
            _detailSandbox.text = "Simulation Safeguards Active: Character mortality is disabled; story flags, character flags, and unit assignments are restored upon return to Apple.";
        }

        if (_launchBtnImg != null)
            _launchBtnImg.color = canLaunch ? ColBtnLaunch : ColBtnDisabled;
        if (_launchBtnText != null)
            _launchBtnText.color = canLaunch ? ColTextMain : ColTextMuted;
    }

    private static GSD2::GAME_WORK? GetGameWork()
    {
        try { return GSD2::OldSrcBase.game_work; }
        catch { return null; }
    }

    private static void SyncPrevInputs()
    {
        _prevPadUp = ReadInputRaw(GRInputManager.Type.Up, Key.UpArrow, Key.W);
        _prevPadDown = ReadInputRaw(GRInputManager.Type.Down, Key.DownArrow, Key.S);
        _prevPadLeft = ReadInputRaw(GRInputManager.Type.Left, Key.LeftArrow, Key.A);
        _prevPadRight = ReadInputRaw(GRInputManager.Type.Right, Key.RightArrow, Key.D);
        _prevPadDecide = ReadInputRaw(GRInputManager.Type.Decide, Key.Enter, Key.Z);
        _prevPadCancel = ReadInputRaw(GRInputManager.Type.Cancel, Key.Escape, Key.X);
    }

    private static bool PollPress(GRInputManager.Type padType, Key key1, Key key2, ref bool prevState, bool allowRepeat)
    {
        bool current = ReadInputRaw(padType, key1, key2);
        bool edge = current && !prevState;
        prevState = current;

        if (edge)
        {
            _lastMoveTime = Time.unscaledTime;
            return true;
        }

        if (allowRepeat && current && Time.unscaledTime - _lastMoveTime >= 0.16f)
        {
            _lastMoveTime = Time.unscaledTime;
            return true;
        }

        return false;
    }

    private static bool IsKeyDownSafe(Key key)
    {
        try { return GRInputManager.IsKeyDown(key); }
        catch { return false; }
    }

    private static bool ReadInputRaw(GRInputManager.Type padType, Key key1, Key key2)
    {
        try
        {
            return GRInputManager.IsKeyPress(key1)
                   || GRInputManager.IsKeyPress(key2)
                   || GRInputManager.IsOn(padType)
                   || GRInputManager.IsPress(padType);
        }
        catch
        {
            return false;
        }
    }

    private static void EnsureCanvas()
    {
        if (_canvasRoot != null)
            return;

        ResolveTmpFont();

        _canvasRoot = new GameObject("PKCore_WarReplayCanvas");
        UnityEngine.Object.DontDestroyOnLoad(_canvasRoot);
        _canvasRoot.hideFlags = HideFlags.HideAndDontSave;

        var canvas = _canvasRoot.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.sortingOrder = 5000;

        var scaler = _canvasRoot.AddComponent<CanvasScaler>();
        scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        scaler.referenceResolution = new Vector2(1920f, 1080f);
        scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
        scaler.matchWidthOrHeight = 0.5f;

        _canvasRoot.AddComponent<GraphicRaycaster>();

        BuildHubPanel();
        BuildSelectorPanel();
        BuildToastPanel();

        _hubPanel?.SetActive(false);
        _selectorPanel?.SetActive(false);
        _toastPanel?.SetActive(false);
        _canvasRoot.SetActive(false);
    }

    private static void BuildHubPanel()
    {
        if (_canvasRoot == null) return;

        _hubPanel = CreateBox(_canvasRoot.transform, "HubOverlay", Vector2.zero, new Vector2(1920f, 1080f), ColBackdrop, raycast: true);
        var card = CreateBorderedBox(_hubPanel.transform, "HubCard", new Vector2(0f, 0f), new Vector2(680f, 390f), ColPanelBg, ColGoldBorder);

        CreateLabel(card.transform, "Header", "APPLE  —  WAR ROOM", new Vector2(0f, 145f), new Vector2(620f, 44f), 28, ColTextGold, TextAlignmentOptions.Left, FontStyles.Bold);
        CreateLabel(card.transform, "Prompt", "\"Do you want to adjust our battle units, or run a tactical simulation of a past engagement?\"", new Vector2(0f, 82f), new Vector2(620f, 64f), 21, ColTextMain, TextAlignmentOptions.TopLeft);

        string[] labels =
        {
            "1. Organize Army Units  (Unit Formation)",
            "2. Tactical Simulation  (Replay War Battles)",
            "3. Never mind"
        };

        for (int i = 0; i < 3; i++)
        {
            int captured = i;
            var row = CreateButtonRow(card.transform, $"HubOpt_{i}", new Vector2(0f, -8f - i * 58f), new Vector2(610f, 48f), ColRowIdle, labels[i], 23, out var bg, out var txt, () => ActivateHubOption(captured));
            _hubRowBg[i] = bg;
            _hubRowText[i] = txt;
        }

        CreateLabel(card.transform, "Hint", "Up/Down: Choose   Enter/Click: Confirm   Esc: Cancel", new Vector2(0f, -166f), new Vector2(620f, 28f), 17, ColTextMuted, TextAlignmentOptions.Center);
    }

    private static void BuildSelectorPanel()
    {
        if (_canvasRoot == null) return;

        _selectorPanel = CreateBox(_canvasRoot.transform, "SelectorOverlay", Vector2.zero, new Vector2(1920f, 1080f), ColBackdrop, raycast: true);
        var board = CreateBorderedBox(_selectorPanel.transform, "SelectorBoard", Vector2.zero, new Vector2(1240f, 700f), ColPanelBg, ColGoldBorder);

        CreateLabel(board.transform, "Title", "APPLE'S TACTICAL ARCHIVE  —  WAR BATTLE REPLAY", new Vector2(0f, 312f), new Vector2(1180f, 42f), 28, ColTextGold, TextAlignmentOptions.Left, FontStyles.Bold);

        // Left pane: Battle list
        var leftPane = CreateBorderedBox(board.transform, "LeftPane", new Vector2(-300f, -6f), new Vector2(580f, 540f), ColSubPanelBg, ColGoldBorder);
        for (int r = 0; r < VisibleRows; r++)
        {
            int capturedRow = r;
            float y = 226f - r * 48f;
            var rowGo = CreateBox(leftPane.transform, $"Row_{r}", new Vector2(0f, y), new Vector2(552f, 42f), ColRowIdle, raycast: true);
            _rowBg[r] = rowGo.GetComponent<Image>();

            var btn = rowGo.AddComponent<Button>();
            btn.transition = Selectable.Transition.None;
            btn.onClick.AddListener((UnityAction)(() =>
            {
                int target = _rowToBattleIdx[capturedRow];
                if (target < 0 || target >= S2WarReplayData.Battles.Count) return;
                if (_battleIndex == target)
                    TryLaunchSelectedBattle();
                else
                {
                    _battleIndex = target;
                    RefreshSelectorVisuals();
                }
            }));

            _rowLabel[r] = CreateLabel(rowGo.transform, "Name", "", new Vector2(-52f, 0f), new Vector2(420f, 36f), 20, ColTextMain, TextAlignmentOptions.Left);
            _rowTag[r] = CreateLabel(rowGo.transform, "Tag", "", new Vector2(215f, 0f), new Vector2(98f, 36f), 17, ColTextReady, TextAlignmentOptions.Right, FontStyles.Bold);
        }
        _scrollHint = CreateLabel(leftPane.transform, "ScrollHint", "", new Vector2(0f, -248f), new Vector2(540f, 26f), 16, ColTextMuted, TextAlignmentOptions.Center);

        // Right pane: Tactical briefing
        var rightPane = CreateBorderedBox(board.transform, "RightPane", new Vector2(300f, -6f), new Vector2(580f, 540f), ColSubPanelBg, ColGoldBorder);
        _detailTitle = CreateLabel(rightPane.transform, "DetailTitle", "", new Vector2(0f, 224f), new Vector2(536f, 48f), 24, ColTextGold, TextAlignmentOptions.TopLeft, FontStyles.Bold);
        _detailMeta = CreateLabel(rightPane.transform, "DetailMeta", "", new Vector2(0f, 152f), new Vector2(536f, 70f), 19, ColTextMain, TextAlignmentOptions.TopLeft);
        _detailRules = CreateLabel(rightPane.transform, "DetailRules", "", new Vector2(0f, 26f), new Vector2(536f, 150f), 19, ColTextMain, TextAlignmentOptions.TopLeft);
        _detailRoster = CreateLabel(rightPane.transform, "DetailRoster", "", new Vector2(0f, -72f), new Vector2(536f, 52f), 18, ColTextReady, TextAlignmentOptions.TopLeft);
        _detailSandbox = CreateLabel(rightPane.transform, "DetailSandbox", "", new Vector2(0f, -138f), new Vector2(536f, 68f), 17, ColTextMuted, TextAlignmentOptions.TopLeft);

        CreateButtonRow(rightPane.transform, "LaunchBtn", new Vector2(-120f, -220f), new Vector2(260f, 48f), ColBtnLaunch, "Launch Simulation", 21, out _launchBtnImg, out _launchBtnText, TryLaunchSelectedBattle);
        CreateButtonRow(rightPane.transform, "BackBtn", new Vector2(150f, -220f), new Vector2(200f, 48f), ColRowIdle, "Back", 21, out _, out _, SwitchToHub);

        CreateLabel(board.transform, "FooterHint", "Up/Down: Browse   Left/Right: Page   Enter/Click: Launch   Esc: Back", new Vector2(0f, -314f), new Vector2(1180f, 28f), 18, ColTextMuted, TextAlignmentOptions.Center);
    }

    private static void BuildToastPanel()
    {
        if (_canvasRoot == null) return;

        _toastPanel = CreateBorderedBox(_canvasRoot.transform, "ReplayToast", new Vector2(0f, 456f), new Vector2(780f, 68f), ColPanelBg, ColGoldBorder);
        _toastText = CreateLabel(_toastPanel.transform, "ToastText", "", Vector2.zero, new Vector2(740f, 52f), 21, ColTextGold, TextAlignmentOptions.Center, FontStyles.Bold);
    }

    private static GameObject CreateBorderedBox(Transform parent, string name, Vector2 pos, Vector2 size, Color fill, Color border)
    {
        var borderObj = CreateBox(parent, name, pos, size, border, raycast: true);
        CreateBox(borderObj.transform, "InnerFill", Vector2.zero, size - new Vector2(4f, 4f), fill, raycast: false);
        return borderObj;
    }

    private static GameObject CreateBox(Transform parent, string name, Vector2 pos, Vector2 size, Color color, bool raycast)
    {
        var go = new GameObject(name);
        go.transform.SetParent(parent, false);
        var rt = go.AddComponent<RectTransform>();
        rt.anchorMin = new Vector2(0.5f, 0.5f);
        rt.anchorMax = new Vector2(0.5f, 0.5f);
        rt.pivot = new Vector2(0.5f, 0.5f);
        rt.anchoredPosition = pos;
        rt.sizeDelta = size;

        var img = go.AddComponent<Image>();
        img.color = color;
        img.raycastTarget = raycast;
        return go;
    }

    private static GameObject CreateButtonRow(Transform parent, string name, Vector2 pos, Vector2 size, Color bgColor, string text, float fontSize, out Image? bgImg, out TMP_Text? label, Action onClick)
    {
        var go = CreateBox(parent, name, pos, size, bgColor, raycast: true);
        bgImg = go.GetComponent<Image>();

        var btn = go.AddComponent<Button>();
        btn.transition = Selectable.Transition.None;
        btn.onClick.AddListener((UnityAction)onClick);

        label = CreateLabel(go.transform, "Label", text, Vector2.zero, size - new Vector2(24f, 6f), fontSize, ColTextMain, TextAlignmentOptions.Center);
        return go;
    }

    private static TMP_Text CreateLabel(Transform parent, string name, string text, Vector2 pos, Vector2 size, float fontSize, Color color, TextAlignmentOptions align, FontStyles style = FontStyles.Normal)
    {
        var go = new GameObject(name);
        go.transform.SetParent(parent, false);
        var rt = go.AddComponent<RectTransform>();
        rt.anchorMin = new Vector2(0.5f, 0.5f);
        rt.anchorMax = new Vector2(0.5f, 0.5f);
        rt.pivot = new Vector2(0.5f, 0.5f);
        rt.anchoredPosition = pos;
        rt.sizeDelta = size;

        var tmp = go.AddComponent<TextMeshProUGUI>();
        if (_cachedTmpFont != null)
            tmp.font = _cachedTmpFont;
        tmp.text = text;
        tmp.fontSize = fontSize;
        tmp.color = color;
        tmp.alignment = align;
        tmp.fontStyle = style;
        tmp.enableWordWrapping = true;
        tmp.overflowMode = TextOverflowModes.Ellipsis;
        tmp.raycastTarget = false;
        return tmp;
    }

    private static void ResolveTmpFont()
    {
        if (_cachedTmpFont != null)
            return;

        try
        {
            var existingTmp = UnityEngine.Object.FindObjectOfType<TextMeshProUGUI>();
            if (existingTmp != null && existingTmp.font != null)
            {
                _cachedTmpFont = existingTmp.font;
                return;
            }

            var fonts = Resources.FindObjectsOfTypeAll<TMP_FontAsset>();
            if (fonts != null && fonts.Length > 0)
            {
                _cachedTmpFont = fonts[0];
            }
        }
        catch (Exception ex)
        {
            Plugin.Log.LogWarning($"[WarReplayMenu] Font lookup warning: {ex.Message}");
        }
    }
}
