extern alias S1;
extern alias GSD2;

using System;
using System.Reflection;
using HarmonyLib;
using UnityEngine;

namespace PKCore.Patches;

/// <summary>
/// Controls random encounter suppression for debugging purposes.
/// Toggled via [F4] hotkey or through the Dear ImGui overlay.
/// If Suikoden_Fix is present, sets Suikoden_Fix.Plugin.Config.EncounterRateMultiplier to 0 (and restores it on toggle off).
/// Otherwise, provides native PKCore Harmony prefix hooks to bypass encounter checks.
/// </summary>
public static class EncounterNonePatch
{
    public static bool IsEncounterNone { get; private set; } = false;
    public static bool IsUsingSuikoFix { get; private set; } = false;
    public static string BackendStatus { get; private set; } = "Not Initialized";

    private static object _suikoFixConfigEntry = null;
    private static PropertyInfo _suikoFixValueProp = null;
    private static float _savedSuikoFixMultiplier = 1.0f;
    private static bool _initialized = false;
    private static float _lastToggleTime = 0f;

    public static void Initialize()
    {
        if (_initialized) return;
        _initialized = true;

        DetectSuikoFix();
    }

    private static void DetectSuikoFix()
    {
        try
        {
            Assembly suikoFixAss = null;
            foreach (var ass in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (string.Equals(ass.GetName().Name, "Suikoden_Fix", StringComparison.OrdinalIgnoreCase))
                {
                    suikoFixAss = ass;
                    break;
                }
            }

            if (suikoFixAss != null)
            {
                var pluginType = suikoFixAss.GetType("Suikoden_Fix.Plugin");
                if (pluginType != null)
                {
                    var configProp = pluginType.GetProperty("Config", BindingFlags.Public | BindingFlags.Static);
                    var configObj = configProp?.GetValue(null);
                    if (configObj != null)
                    {
                        var multField = configObj.GetType().GetField("EncounterRateMultiplier", BindingFlags.Public | BindingFlags.Instance);
                        var entryObj = multField?.GetValue(configObj);
                        if (entryObj != null)
                        {
                            var valProp = entryObj.GetType().GetProperty("Value", BindingFlags.Public | BindingFlags.Instance);
                            if (valProp != null)
                            {
                                _suikoFixConfigEntry = entryObj;
                                _suikoFixValueProp = valProp;
                                IsUsingSuikoFix = true;
                                BackendStatus = "Suikoden_Fix (EncounterRateMultiplier)";

                                object val = valProp.GetValue(entryObj);
                                if (val is float f && f > 0f)
                                {
                                    _savedSuikoFixMultiplier = f;
                                }
                                Plugin.Log.LogInfo($"[EncounterNonePatch] Suikoden_Fix detected. Backend: {BackendStatus} (Default multiplier: {_savedSuikoFixMultiplier})");
                                return;
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Plugin.Log.LogWarning($"[EncounterNonePatch] Exception detecting Suikoden_Fix: {ex.Message}");
        }

        IsUsingSuikoFix = false;
        BackendStatus = "PKCore Native Hook";
        Plugin.Log.LogInfo($"[EncounterNonePatch] Suikoden_Fix not found. Backend: {BackendStatus}");
    }

    public static void Toggle()
    {
        SetEncounterNone(!IsEncounterNone);
    }

    public static void SetEncounterNone(bool enable)
    {
        Initialize();
        IsEncounterNone = enable;

        if (IsUsingSuikoFix && _suikoFixConfigEntry != null && _suikoFixValueProp != null)
        {
            try
            {
                if (enable)
                {
                    object currentVal = _suikoFixValueProp.GetValue(_suikoFixConfigEntry);
                    if (currentVal is float f && f > 0f)
                    {
                        _savedSuikoFixMultiplier = f;
                    }
                    _suikoFixValueProp.SetValue(_suikoFixConfigEntry, 0f);
                    Plugin.Log.LogInfo($"[EncounterNonePatch] [F4] Encounter None: ON (SuikoFix EncounterRateMultiplier set to 0. Saved: {_savedSuikoFixMultiplier})");
                }
                else
                {
                    float restore = _savedSuikoFixMultiplier > 0f ? _savedSuikoFixMultiplier : 1.0f;
                    _suikoFixValueProp.SetValue(_suikoFixConfigEntry, restore);
                    Plugin.Log.LogInfo($"[EncounterNonePatch] [F4] Encounter None: OFF (SuikoFix EncounterRateMultiplier restored to {restore})");
                }
                return;
            }
            catch (Exception ex)
            {
                Plugin.Log.LogWarning($"[EncounterNonePatch] Error communicating with Suikoden_Fix: {ex.Message}");
            }
        }

        Plugin.Log.LogInfo($"[EncounterNonePatch] [F4] Encounter None (Native): {(enable ? "ON" : "OFF")}");
    }

    public static void UpdateInput()
    {
        try
        {
            var keyboard = UnityEngine.InputSystem.Keyboard.current;
            if (keyboard != null && keyboard.f4Key.wasPressedThisFrame && (Time.time - _lastToggleTime > 0.25f))
            {
                _lastToggleTime = Time.time;
                Toggle();
            }
        }
        catch { }
    }

    // =========================================================================
    // NATIVE FALLBACK HOOKS (Active when Suikoden_Fix is not installed/used)
    // =========================================================================

    [HarmonyPatch(typeof(GSD2::EVENTCON), "EventBatlleCheck")]
    [HarmonyPrefix]
    public static bool GSD2_EventBatlleCheck_Prefix()
    {
        if (IsEncounterNone && !IsUsingSuikoFix)
        {
            return false;
        }
        return true;
    }

    [HarmonyPatch(typeof(S1::Village_c), "v_wanderingMonsterChk")]
    [HarmonyPrefix]
    public static bool GSD1_Village_MonsterChk_Prefix(ref int __result)
    {
        if (IsEncounterNone && !IsUsingSuikoFix)
        {
            __result = 0;
            return false;
        }
        return true;
    }

    [HarmonyPatch(typeof(S1::Fmain_c), "f_wanderingMonsterChk")]
    [HarmonyPrefix]
    public static bool GSD1_Fmain_MonsterChk_Prefix(ref int __result)
    {
        if (IsEncounterNone && !IsUsingSuikoFix)
        {
            __result = 0;
            return false;
        }
        return true;
    }
}
