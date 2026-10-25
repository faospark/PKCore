extern alias S1;

using System;
using HarmonyLib;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PKCore.Patches;

/// <summary>
/// Suikoden I: Remote Castle Rune Master (Jeane) Access Patch.
/// Enables pressing Right Stick Down (or [F7] on keyboard) to open the Toran Castle
/// Rune Master directly from anywhere on the field, immune to glitches and softlocks.
/// </summary>
public static class S1QuickRunePatch
{
    public static bool IsQuickRuneMasterOpen { get; private set; } = false;

    public static S1::Village_c CurrentVillage => S1QuickStoragePatch.CurrentVillage;
    public static S1::Fmain_c CurrentField => S1QuickStoragePatch.CurrentField;

    private static S1::COMMAND_FUNC_TABLE _activeRuneDelegate = null;
    private static float _lastToggleTime = 0f;
    private static bool _wasRightStickDownPrev = false;

    /// <summary>
    /// Per-frame update called on the Unity main thread via Plugin.Update().
    /// </summary>
    public static void Update()
    {
        if (!GameDetection.IsGSD1())
            return;

        if (Plugin.Config == null || !Plugin.Config.EnableS1QuickRuneMaster.Value)
            return;

        // Mutual exclusion: only one quick window can be active or activated at a time
        if (S1QuickStoragePatch.IsQuickStorageOpen)
        {
            _wasRightStickDownPrev = false;
            return;
        }

        // Check if Right Stick Down, R3 (Right Stick Press), or [F7] was pressed
        bool triggerPressed = false;
        try
        {
            var pad = Gamepad.current;
            if (pad != null)
            {
                // Right stick down detection (analog threshold + clean edge detection)
                float stickY = pad.rightStick.y.ReadValue();
                bool isStickDown = stickY < -0.65f;
                bool stickDownPressed = isStickDown && !_wasRightStickDownPrev;
                _wasRightStickDownPrev = isStickDown;

                if (stickDownPressed || pad.rightStickButton.wasPressedThisFrame)
                {
                    triggerPressed = true;
                }
            }
            else
            {
                _wasRightStickDownPrev = false;
            }

            var kb = Keyboard.current;
            if (kb != null && kb.f7Key.wasPressedThisFrame)
            {
                triggerPressed = true;
            }
        }
        catch { }

        // If rune master is currently active, advance the native state machine
        if (IsQuickRuneMasterOpen)
        {
            // Allow pressing trigger again to close early
            if (triggerPressed && Time.time - _lastToggleTime > 0.4f)
            {
                _lastToggleTime = Time.time;
                CloseRuneMasterSafely();
                return;
            }

            StepRuneLoop();
            return;
        }

        // Attempt to open rune master on trigger press
        if (triggerPressed && Time.time - _lastToggleTime > 0.4f)
        {
            _lastToggleTime = Time.time;

            if (CanOpenRuneMaster(out string failReason))
            {
                OpenRuneMaster();
            }
            else
            {
                Plugin.Log.LogInfo($"[S1QuickRuneMaster] Cannot open Rune Master right now: {failReason}");
            }
        }
    }

    /// <summary>
    /// Comprehensive safety checks to guarantee immunity to softlocks, crashes, and narrative breaks.
    /// </summary>
    public static bool CanOpenRuneMaster(out string failReason)
    {
        failReason = null;

        // 0. Ensure map background has loaded Tir on the area
        if (!S1QuickStoragePatch.HasMapBackgroundChild())
        {
            failReason = "Map background has not loaded Tir on the area";
            return false;
        }

        // Rejection: Loading screen, scene change, or screen fade
        if (S1QuickStoragePatch.IsGameInLoadingOrTransition(out var loadingReason))
        {
            failReason = loadingReason;
            return false;
        }

        var gw = S1::OldSrcBase.game_work;
        if (gw == null)
        {
            failReason = "Game session not active";
            return false;
        }

        // Ensure castle data is present
        var shiro = gw.shiro_data;
        if (shiro == null)
        {
            shiro = new S1::SHIRO_DATA();
            gw.shiro_data = shiro;
        }

        // Jeane recruitment requirement
        if (Plugin.Config.S1QuickRuneMasterRequireJeane.Value)
        {
            if (shiro.level <= 0)
            {
                failReason = "Jeane is not yet recruited (Toran Castle rune master locked)";
                return false;
            }
        }

        // Rejection: In Battle
        if (S1QuickStoragePatch.IsInBattle)
        {
            failReason = "Currently in battle";
            return false;
        }

        // Rejection: If Quick Storage or another overlay is currently open
        if (S1QuickStoragePatch.IsQuickStorageOpen)
        {
            failReason = "Castle Vault is currently open";
            return false;
        }

        // Rejection: In Village during an active cutscene, event dialogue, or transition
        if (CurrentVillage != null)
        {
            try
            {
                if (!CurrentVillage.isEnableOpenMenu)
                {
                    failReason = "Scene is currently busy with event, dialog, or cutscene";
                    return false;
                }
            }
            catch { }
        }

        // Rejection: WindowManager uninitialized
        if (S1::WindowManager.Instance == null)
        {
            failReason = "UI WindowManager is not available";
            return false;
        }

        return true;
    }

    /// <summary>
    /// Opens the native Rune Master shop UI.
    /// </summary>
    private static void OpenRuneMaster()
    {
        try
        {
            Plugin.Log.LogInfo("[S1QuickRuneMaster] Invoking Castle Rune Master via Right Stick Down...");

            var omiseData = S1::Event_c.shiro_monsyou_data;
            if (omiseData == null)
            {
                omiseData = new S1::OMISE_DATA();
            }

            if (omiseData.syohin == null)
            {
                omiseData.syohin = new Il2CppStructArray<byte>(0);
            }

            if (omiseData.message == null)
            {
                omiseData.message = new Il2CppStructArray<int>(0);
            }

            if (S1::Event_c.shiro_monsyou_data == null)
            {
                S1::Event_c.shiro_monsyou_data = omiseData;
            }

            var initialDelegate = S1::h_monsyo_c.init_monsyo(omiseData);
            if (initialDelegate != null)
            {
                _activeRuneDelegate = initialDelegate;
                IsQuickRuneMasterOpen = true;
                S1QuickStoragePatch.PlaySoundOpen();
                Plugin.Log.LogInfo("[S1QuickRuneMaster] Rune Master opened successfully.");
            }
            else
            {
                Plugin.Log.LogWarning("[S1QuickRuneMaster] init_monsyo() returned null delegate.");
                IsQuickRuneMasterOpen = false;
                _activeRuneDelegate = null;
            }
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[S1QuickRuneMaster] Exception opening Rune Master: {ex}");
            IsQuickRuneMasterOpen = false;
            _activeRuneDelegate = null;
        }
    }

    /// <summary>
    /// Steps the native rune shop frame delegate each Unity update.
    /// </summary>
    private static void StepRuneLoop()
    {
        if (_activeRuneDelegate == null)
        {
            CloseRuneMasterSafely();
            return;
        }

        try
        {
            var nextDelegate = _activeRuneDelegate.Invoke();
            if (nextDelegate != null && S1::h_monsyo_c.monsyo_work != null)
            {
                _activeRuneDelegate = nextDelegate;
            }
            else
            {
                // Native rune routine finished cleanly (user chose Exit/Back)
                Plugin.Log.LogInfo("[S1QuickRuneMaster] Rune Master session completed cleanly.");
                S1QuickStoragePatch.PlaySoundClose();
                IsQuickRuneMasterOpen = false;
                _activeRuneDelegate = null;
            }
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[S1QuickRuneMaster] Exception in rune master step: {ex}");
            CloseRuneMasterSafely();
        }
    }

    /// <summary>
    /// Safely forces the Rune Master window to close if interrupted or toggled off with Right Stick Down.
    /// </summary>
    public static void CloseRuneMasterSafely()
    {
        if (IsQuickRuneMasterOpen)
        {
            S1QuickStoragePatch.PlaySoundClose();
        }

        try
        {
            S1::h_monsyo_c.monsyo_exit();
        }
        catch { }

        IsQuickRuneMasterOpen = false;
        _activeRuneDelegate = null;
        Plugin.Log.LogInfo("[S1QuickRuneMaster] Rune Master closed and player control restored.");
    }
}
