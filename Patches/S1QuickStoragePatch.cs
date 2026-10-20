extern alias GSD1;

using System;
using HarmonyLib;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PKCore.Patches;

/// <summary>
/// Suikoden I: R3 Castle Vault Access Patch.
/// Enables pressing R3 (Right Stick Click or [V] on keyboard) to open Rock's Castle Vault
/// directly from anywhere on the field, immune to glitches and softlocks.
/// </summary>
public static class S1QuickStoragePatch
{
    public static bool IsQuickStorageOpen { get; private set; } = false;

    public static GSD1::Village_c CurrentVillage { get; private set; }
    public static GSD1::Fmain_c CurrentField { get; private set; }

    private static GSD1::SHIRO_FUNC_DELEGATE _activeStorageDelegate = null;
    private static float _lastToggleTime = 0f;
    private static bool _wasRightStickUpPrev = false;

    /// <summary>
    /// Per-frame update called on the Unity main thread via Plugin.Update().
    /// </summary>
    public static void Update()
    {
        if (!GameDetection.IsGSD1())
            return;

        if (Plugin.Config == null || !Plugin.Config.EnableS1QuickStorage.Value)
            return;

        // Check if Right Stick Up, R3 (Right Stick Press), or [F6] was pressed
        bool triggerPressed = false;
        try
        {
            var pad = Gamepad.current;
            if (pad != null)
            {
                // Right stick up detection (analog threshold + edge detection)
                float stickY = pad.rightStick.y.ReadValue();
                bool isStickUp = stickY > 0.65f;
                bool stickUpPressed = (isStickUp && !_wasRightStickUpPrev) || pad.rightStick.up.wasPressedThisFrame;
                _wasRightStickUpPrev = isStickUp;

                if (stickUpPressed || pad.rightStickButton.wasPressedThisFrame)
                {
                    triggerPressed = true;
                }
            }
            else
            {
                _wasRightStickUpPrev = false;
            }

            var kb = Keyboard.current;
            if (kb != null && (kb.f6Key.wasPressedThisFrame || kb.bKey.wasPressedThisFrame))
            {
                triggerPressed = true;
            }
        }
        catch { }

        // If storage is currently active, advance the native state machine
        if (IsQuickStorageOpen)
        {
            // Allow pressing trigger again to close early
            if (triggerPressed && Time.time - _lastToggleTime > 0.4f)
            {
                _lastToggleTime = Time.time;
                CloseStorageSafely();
                return;
            }

            StepStorageLoop();
            return;
        }

        // Attempt to open storage on trigger press
        if (triggerPressed && Time.time - _lastToggleTime > 0.4f)
        {
            _lastToggleTime = Time.time;

            if (CanOpenStorage(out string failReason))
            {
                OpenStorage();
            }
            else
            {
                Plugin.Log.LogInfo($"[S1QuickStorage] Cannot open vault right now: {failReason}");
            }
        }
    }

    /// <summary>
    /// Comprehensive safety checks to guarantee immunity to softlocks, crashes, and narrative breaks.
    /// </summary>
    public static bool CanOpenStorage(out string failReason)
    {
        failReason = null;

        var gw = GSD1::OldSrcBase.game_work;
        if (gw == null)
        {
            failReason = "Game session not active";
            return false;
        }

        // Must have initialized castle data and warehouse buffer
        var shiro = gw.shiro_data;
        if (shiro == null || shiro.azukari == null)
        {
            failReason = "Castle storage array not initialized";
            return false;
        }

        // Rock recruitment requirement
        if (Plugin.Config.S1QuickStorageRequireRock.Value)
        {
            var memberFlag = gw.member_flag;
            if (memberFlag == null || memberFlag.Length <= (int)GSD1::CHARACTER_ID.FP_LOK || memberFlag[(int)GSD1::CHARACTER_ID.FP_LOK] == 0)
            {
                failReason = "Rock is not yet recruited (Toran Castle vault locked)";
                return false;
            }
        }
        else
        {
            // At least require Toran Castle to be established (level > 0)
            if (shiro.level <= 0)
            {
                failReason = "Toran Castle not yet established";
                return false;
            }
        }

        // Rejection: In Battle
        if (gw.battle_data != null)
        {
            failReason = "Currently in battle";
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
        if (GSD1::WindowManager.Instance == null)
        {
            failReason = "UI WindowManager is not available";
            return false;
        }

        return true;
    }

    /// <summary>
    /// Opens the native HD Remaster storage UI.
    /// </summary>
    private static void OpenStorage()
    {
        try
        {
            Plugin.Log.LogInfo("[S1QuickStorage] Invoking Rock's Castle Vault via R3...");

            var initResult = GSD1::D_azukar_c.azukari_demo();
            if (initResult.Item1 && initResult.Item2 != null)
            {
                _activeStorageDelegate = initResult.Item2;
                IsQuickStorageOpen = true;
                Plugin.Log.LogInfo("[S1QuickStorage] Vault opened successfully.");
            }
            else
            {
                Plugin.Log.LogWarning("[S1QuickStorage] azukari_demo() returned inactive state.");
                IsQuickStorageOpen = false;
                _activeStorageDelegate = null;
            }
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[S1QuickStorage] Exception opening storage: {ex}");
            IsQuickStorageOpen = false;
            _activeStorageDelegate = null;
        }
    }

    /// <summary>
    /// Steps the native storage frame delegate each Unity update.
    /// </summary>
    private static void StepStorageLoop()
    {
        if (_activeStorageDelegate == null)
        {
            CloseStorageSafely();
            return;
        }

        try
        {
            var result = _activeStorageDelegate.Invoke();
            if (result.Item1 && result.Item2 != null)
            {
                _activeStorageDelegate = result.Item2;
            }
            else
            {
                // Native storage routine finished cleanly (user pressed Back/Cancel)
                Plugin.Log.LogInfo("[S1QuickStorage] Storage session completed cleanly.");
                IsQuickStorageOpen = false;
                _activeStorageDelegate = null;
            }
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[S1QuickStorage] Exception in storage step: {ex}");
            CloseStorageSafely();
        }
    }

    /// <summary>
    /// Safely forces the storage window to close if interrupted or toggled off with R3.
    /// </summary>
    public static void CloseStorageSafely()
    {
        try
        {
            GSD1::D_azukar_c.demo_exit();
        }
        catch { }

        try
        {
            if (GSD1::WindowManager.Instance != null)
            {
                GSD1::WindowManager.Instance.CloseStorageWindowUI(
                    Share.UI.Window.StorageMenuType.Deposit,
                    Share.UI.Window.StorageWindowType.Command);
            }
        }
        catch { }

        IsQuickStorageOpen = false;
        _activeStorageDelegate = null;
        Plugin.Log.LogInfo("[S1QuickStorage] Storage closed and player control restored.");
    }

    // =========================================================================
    // HARMONY HOOKS (Player Control & Encounter Guards)
    // =========================================================================

    [HarmonyPatch(typeof(GSD1::Village_c), nameof(GSD1::Village_c.village_main))]
    [HarmonyPrefix]
    public static void Village_village_main_Prefix(GSD1::Village_c __instance)
    {
        CurrentVillage = __instance;
    }

    [HarmonyPatch(typeof(GSD1::Fmain_c), nameof(GSD1::Fmain_c.fieldMain))]
    [HarmonyPrefix]
    public static void Fmain_fieldMain_Prefix(GSD1::Fmain_c __instance)
    {
        CurrentField = __instance;
    }

    [HarmonyPatch(typeof(GSD1::Village_c), nameof(GSD1::Village_c.player_move))]
    [HarmonyPrefix]
    public static bool Village_player_move_Prefix(ref byte __result)
    {
        if (IsQuickStorageOpen)
        {
            __result = 0;
            return false;
        }
        return true;
    }

    [HarmonyPatch(typeof(GSD1::Village_c), "isEnableOpenMenu", MethodType.Getter)]
    [HarmonyPrefix]
    public static bool Village_get_isEnableOpenMenu_Prefix(ref bool __result)
    {
        if (IsQuickStorageOpen)
        {
            __result = false;
            return false;
        }
        return true;
    }

    [HarmonyPatch(typeof(GSD1::Village_c), nameof(GSD1::Village_c.v_wanderingMonsterChk))]
    [HarmonyPrefix]
    public static bool Village_MonsterChk_Prefix(ref int __result)
    {
        if (IsQuickStorageOpen)
        {
            __result = 0;
            return false;
        }
        return true;
    }

    [HarmonyPatch(typeof(GSD1::Fmain_c), nameof(GSD1::Fmain_c.f_wanderingMonsterChk))]
    [HarmonyPrefix]
    public static bool Fmain_MonsterChk_Prefix(ref int __result)
    {
        if (IsQuickStorageOpen)
        {
            __result = 0;
            return false;
        }
        return true;
    }
}
