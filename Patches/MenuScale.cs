using HarmonyLib;
using UnityEngine;
using ShareUI.Menu;
using ShareUI.Battle;
using DG.Tweening;
using System;

namespace PKCore.Patches;

/// <summary>
/// Monitor-based approach for UI scaling - similar to DragonPatch
/// Automatically detects and scales UI elements as they are created
/// </summary>
public class MenuScalePatch
{
    private static bool _isRegistered = false;
    
    // Lazy registration - only register when first UI is encountered
    private static void EnsureRegistered()
    {
        if (_isRegistered) return;
        
        try 
        {
            Il2CppInterop.Runtime.Injection.ClassInjector.RegisterTypeInIl2Cpp<UIScaleMonitor>();
            Plugin.Log.LogInfo("[MenuScale] Registered UIScaleMonitor type (lazy-loaded on first UI encounter)");
            _isRegistered = true;
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[MenuScale] Failed to register UIScaleMonitor: {ex.Message}");
        }
    }
    
    // Called at startup - no longer registers immediately
    public static void Initialize()
    {
        // Registration is now deferred until first UI is encountered (silent)
    }

    /// <summary>
    /// Checks if an object is a known UI element and attaches a monitor if needed
    /// </summary>
    public static void CheckAndAttachMonitor(GameObject go)
    {
        if (go == null) return;

        // Check configuration setting first
        if (!Plugin.Config.ScaledDownMenu.Value.Equals("true", StringComparison.OrdinalIgnoreCase)) return;

        // Check if this is a UI object we care about
        bool isTargetUI = go.name.Contains("UIMainMenu") || 
                         go.name.Contains("UI_Battle_Result") ||
                         go.name.Contains("UI_Com_Header") ||
                         go.name.Contains("UI_Com_BackLog") ||
                         go.name.Contains("UI_Config_01");
        
        if (!isTargetUI) return;

        // Ensure the type is registered before trying to add the component
        EnsureRegistered();

        // Avoid adding multiple monitors
        if (go.GetComponent<UIScaleMonitor>() != null) return;

        if (Plugin.Config.DetailedTextureLog.Value)
        {
            Plugin.Log.LogInfo($"[MenuScale] Attaching UI scale monitor to: {go.name}");
        }
        go.AddComponent<UIScaleMonitor>();
    }
}

/// <summary>
/// Component that monitors UI elements and applies scaling transformations
/// </summary>
public class UIScaleMonitor : MonoBehaviour
{
    private bool _hasAppliedScaling = false;
    private float _checkDelay = 0.1f; // Small delay to let UI fully initialize
    private float _timer = 0f;

    private void Update()
    {
        if (_hasAppliedScaling) return;

        _timer += Time.deltaTime;
        if (_timer < _checkDelay) return;

        ApplyUIScaling();
    }

    private void ApplyUIScaling()
    {
        // Find UI_Canvas_Root from this object
        Transform uiCanvasRoot = FindUICanvasRoot(transform);
        
        if (uiCanvasRoot == null)
        {
            // Try again next frame if not found yet
            _timer = 0f;
            _checkDelay += 0.1f; // Increase delay slightly each attempt
            
            // Give up after 2 seconds
            if (_checkDelay > 2.0f)
            {
                Plugin.Log.LogWarning($"[MenuScale] Could not find UI_Canvas_Root for {gameObject.name}");
                _hasAppliedScaling = true;
            }
            return;
        }

        ApplyMenuTransformations(uiCanvasRoot);
        _hasAppliedScaling = true;
        
        if (Plugin.Config.DetailedTextureLog.Value)
        {
            Plugin.Log.LogInfo($"[MenuScale] Applied scaling to UI: {gameObject.name}");
        }
    }

    private Transform FindUICanvasRoot(Transform current)
    {
        // Walk up the hierarchy to find UI_Canvas_Root
        while (current != null)
        {
            if (current.name == "UI_Canvas_Root")
                return current;
            current = current.parent;
        }
        return null;
    }

    /// <summary>
    /// Apply menu transformations - same logic as before but adapted for monitor
    /// </summary>
    private void ApplyMenuTransformations(Transform uiCanvasRoot)
    {
        // Header: Apply scale and position
        Transform header = uiCanvasRoot.Find("UI_Com_Header(Clone)") ?? uiCanvasRoot.Find("UI_Com_Header");
        if (header != null)
        {
            Vector3 targetScale = new Vector3(0.8f, 0.8f, 1f);
            Vector3 targetPosition = new Vector3(194.4f, 108f, 0f);
            header.DOKill();
            header.DOScale(targetScale, 0.2f).SetEase(Ease.OutCubic);
            header.DOLocalMove(targetPosition, 0.2f).SetEase(Ease.OutCubic);
        }

        // BackLog: Apply scale and position to Set01 child
        Transform backLog = uiCanvasRoot.Find("UI_Com_BackLog01(Clone)") ?? uiCanvasRoot.Find("UI_Com_BackLog01");
        if (backLog != null)
        {
            Transform set01 = backLog.Find("Set01");
            if (set01 != null)
            {
                Vector3 targetScale = new Vector3(0.8f, 0.8f, 1f);
                Vector3 targetPosition = new Vector3(0f, 86.4f, 0f);
                set01.DOKill();
                set01.DOScale(targetScale, 0.2f).SetEase(Ease.OutCubic);
                set01.DOLocalMove(targetPosition, 0.2f).SetEase(Ease.OutCubic);
            }
        }

        // Config: Apply scale and position
        Transform config = uiCanvasRoot.Find("UI_Config_01(Clone)") ?? uiCanvasRoot.Find("UI_Config_01");
        if (config != null)
        {
            Vector3 targetScale = new Vector3(0.8f, 0.8f, 1f);
            Vector3 targetPosition = new Vector3(0f, 86.4f, 0f);
            config.DOKill();
            config.DOScale(targetScale, 0.2f).SetEase(Ease.OutCubic);
            config.DOLocalMove(targetPosition, 0.2f).SetEase(Ease.OutCubic);
        }

        // Battle Result: Apply scale and position to Result_layout child
        Transform battleresult = uiCanvasRoot.Find("UI_Battle_Result_Main(Clone)") ?? uiCanvasRoot.Find("UI_Battle_Result_Main");
        if (battleresult != null)
        {
            Transform resultLayout = battleresult.Find("Result_layout");
            if (resultLayout != null)
            {
                Vector3 targetScale = new Vector3(0.8f, 0.8f, 1f);
                Vector3 targetPosition = new Vector3(0f, 86.4f, 0f);
                resultLayout.DOKill();
                resultLayout.DOScale(targetScale, 0.2f).SetEase(Ease.OutCubic);
                resultLayout.DOLocalMove(targetPosition, 0.2f).SetEase(Ease.OutCubic);
            }
        }

        // UIMainMenu(Clone) -> UI_Set for specific menu items
        Transform uiMainMenuClone = uiCanvasRoot.Find("UIMainMenu(Clone)");
        if (uiMainMenuClone != null)
        {
            Transform uiSet = uiMainMenuClone.Find("UI_Set");
            if (uiSet != null)
            {
                // TopMenu: Apply scale only (no position change)
                Transform topMenu = uiSet.Find("TopMenu");
                if (topMenu != null)
                {
                    Vector3 targetScale = new Vector3(0.8f, 0.8f, 1f);
                    topMenu.DOKill();
                    topMenu.DOScale(targetScale, 0.2f).SetEase(Ease.OutCubic);
                }
                
                // Other menus: Apply both scale and position
                string[] menuNames = { "ItemMenu", "EmblemMenu", "Equipment_Set", "State_Set", "Formation_Set" };
                
                foreach (string menuName in menuNames)
                {
                    Transform menuTransform = uiSet.Find(menuName);
                    if (menuTransform != null)
                    {
                        // Apply transformations with smooth animation
                        Vector3 targetScale = new Vector3(0.8f, 0.8f, 1f);
                        Vector3 targetPosition = new Vector3(0f, 75.6f, 0f);
                        
                        // Kill any existing tweens on this transform
                        menuTransform.DOKill();
                        
                        // Animate scale and position smoothly
                        menuTransform.DOScale(targetScale, 0.2f).SetEase(Ease.OutCubic);
                        menuTransform.DOLocalMove(targetPosition, 0.2f).SetEase(Ease.OutCubic);
                    }
                }
            }
        }
    }
}
