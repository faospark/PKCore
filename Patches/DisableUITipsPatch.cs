using HarmonyLib;
using UnityEngine;

namespace PKCore.Patches;

/// <summary>
/// Disables the UITips UI element (UI_Root/UI_Canvas_Root/UITips/).
/// This hides the control/button tips overlay shown across battles, menus, and fields.
/// </summary>
public static class DisableUITipsPatch
{
    private static bool _isProcessing = false;

    public static void Initialize(Harmony harmony)
    {
        harmony.PatchAll(typeof(DisableUITipsPatch));
    }

    /// <summary>
    /// Only suppress UITips while inside Suikoden 1 or 2.
    /// The Main launcher scene keeps its tips visible.
    /// </summary>
    private static bool ShouldDisable()
    {
        if (Plugin.Config == null || !Plugin.Config.DisableUITips.Value)
            return false;

        return GameDetection.IsGSD1() || GameDetection.IsGSD2();
    }

    [HarmonyPatch(typeof(GameObject), nameof(GameObject.SetActive))]
    [HarmonyPostfix]
    public static void GameObject_SetActive_Postfix(GameObject __instance, bool value)
    {
        if (_isProcessing || !value || !ShouldDisable())
            return;

        try
        {
            _isProcessing = true;

            // Direct activation of UITips
            if (__instance.name == "UITips" || __instance.name == "UITips(Clone)")
            {
                Transform parent = __instance.transform.parent;
                if (parent != null && (parent.name == "UI_Canvas_Root" || parent.name.StartsWith("UI_Canvas_Root")))
                {
                    __instance.SetActive(false);
                    if (Plugin.Config.DetailedLogs.Value)
                        Plugin.Log.LogInfo("[DisableUITips] Disabled UITips on direct activation");
                    return;
                }
            }
            // Activation of UI_Canvas_Root parent
            else if (__instance.name == "UI_Canvas_Root" || __instance.name.StartsWith("UI_Canvas_Root"))
            {
                for (int i = 0; i < __instance.transform.childCount; i++)
                {
                    Transform child = __instance.transform.GetChild(i);
                    if (child.name == "UITips" || child.name.StartsWith("UITips"))
                    {
                        if (child.gameObject.activeSelf)
                        {
                            child.gameObject.SetActive(false);
                            if (Plugin.Config.DetailedLogs.Value)
                                Plugin.Log.LogInfo("[DisableUITips] Disabled UITips child on UI_Canvas_Root activation");
                        }
                    }
                }
            }
            // Activation of UI_Root parent
            else if (__instance.name == "UI_Root" || __instance.name.StartsWith("UI_Root"))
            {
                Transform canvasRoot = __instance.transform.Find("UI_Canvas_Root");
                if (canvasRoot != null)
                {
                    for (int i = 0; i < canvasRoot.childCount; i++)
                    {
                        Transform child = canvasRoot.GetChild(i);
                        if (child.name == "UITips" || child.name.StartsWith("UITips"))
                        {
                            if (child.gameObject.activeSelf)
                            {
                                child.gameObject.SetActive(false);
                                if (Plugin.Config.DetailedLogs.Value)
                                    Plugin.Log.LogInfo("[DisableUITips] Disabled UITips child on UI_Root activation");
                            }
                        }
                    }
                }
            }
        }
        finally
        {
            _isProcessing = false;
        }
    }

    [HarmonyPatch(typeof(UITips), nameof(UITips.OpenTips))]
    [HarmonyPrefix]
    public static bool UITips_OpenTips_Prefix(UITips __instance)
    {
        if (ShouldDisable())
        {
            if (__instance != null && __instance.gameObject != null && __instance.gameObject.activeSelf)
            {
                __instance.gameObject.SetActive(false);
            }
            return false;
        }

        return true;
    }

    [HarmonyPatch(typeof(UITips), "Update")]
    [HarmonyPrefix]
    public static bool UITips_Update_Prefix(UITips __instance)
    {
        if (ShouldDisable())
        {
            if (__instance != null && __instance.gameObject != null && __instance.gameObject.activeSelf)
            {
                __instance.gameObject.SetActive(false);
            }
            return false;
        }

        return true;
    }
}
