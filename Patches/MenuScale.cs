using HarmonyLib;
using UnityEngine;
using ShareUI.Menu;
using DG.Tweening;

namespace PKCore.Patches;

/// <summary>
/// Patches to apply custom scaling and positioning to UI menu elements
/// Hooks into both UIMainTopMenu and UIMainItemMenu OpenWindow to apply transformations
/// </summary>
public class MenuScalePatch
{
    /// <summary>
    /// Shared method to apply menu transformations
    /// </summary>
    private static void ApplyMenuTransformations(GameObject menuObject, string menuType)
    {
        // Check configuration setting
        string menuScaleSetting = Plugin.Config.MenuScale.Value.ToLower();
        if (menuScaleSetting != "alt")
            return;
        
        // Navigate to UI_Set: UIMainMenu -> UI_Canvas_Root -> UIMainMenu(Clone) -> UI_Set
        // First go up to UI_Canvas_Root
        Transform uiCanvasRoot = menuObject.transform.parent;
        if (uiCanvasRoot == null || uiCanvasRoot.name != "UI_Canvas_Root")
        {
            Plugin.Log.LogWarning($"[MenuScale] Expected UI_Canvas_Root parent for {menuObject.name}, got {uiCanvasRoot?.name ?? "null"}");
            return;
        }

        
        // Then find UIMainMenu(Clone) child
        Transform uiMainMenuClone = uiCanvasRoot.Find("UIMainMenu(Clone)");
        if (uiMainMenuClone == null)
        {
            Plugin.Log.LogWarning($"[MenuScale] Could not find UIMainMenu(Clone) in UI_Canvas_Root");
            return;
        }
        
        // Finally get UI_Set from UIMainMenu(Clone)
        Transform uiSet = uiMainMenuClone.Find("UI_Set");
        if (uiSet == null)
        {
            Plugin.Log.LogWarning($"[MenuScale] Expected UI_Set parent for {menuObject.name}, got {uiSet?.name ?? "null"}");
            return;
        }

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
    
    /// <summary>
    /// Patch for UIMainMenu opening - this controls all menus
    /// </summary>
    [HarmonyPatch(typeof(UIMainMenu), nameof(UIMainMenu.Open))]
    [HarmonyPostfix]
    public static void UIMainMenu_Open_Postfix(UIMainMenu __instance)
    {
        // UIMainMenu is the boss - apply transformations to all menus when it opens
        ApplyMenuTransformations(__instance.gameObject, "UIMainMenu");
    }
}
