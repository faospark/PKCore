using HarmonyLib;
using UnityEngine;
using System.Collections.Generic;

namespace PKCore.Patches;

/// <summary>
/// Disables specific map objects in Suikoden 1.
/// Targets:
/// - AppRoot/Map/MapBackGround/va4_04(Clone)/object/large/
/// - AppRoot/Map/MapBackGround/vf1_08(Clone)/mask/
/// </summary>
public static class S1DisableObjectsPatch
{
    private static bool _isProcessing = false;

    private static readonly HashSet<string> _va4LargeObjectNames = new HashSet<string>
    {
        "t_gsd1_va4_00_obj_small_Leaf_2 (2)",
        "t_gsd1_va4_00_obj_small_Trunk",
        "t_gsd1_va4_00_obj_small_Leaf_2 (3)",
        "t_gsd1_va4_00_obj_small_Trunk (1)",
        "t_gsd1_va4_00_obj_small_Leaf_2 (4)",
        "t_gsd1_va4_00_obj_small_Trunk (2)",
        "t_gsd1_va4_00_obj_small_Leaf_2 (5)",
        "t_gsd1_va4_00_obj_small_Trunk (3)",
        "t_gsd1_va4_00_obj_small_Leaf_2 (9)",
        "t_gsd1_va4_00_obj_small_Trunk (7)",
        "t_gsd1_va4_00_obj_small_Leaf_2 (10)",
        "t_gsd1_va4_00_obj_small_Trunk (8)",
        "t_gsd1_va4_00_obj_small_Leaf_2 (16)",
        "t_gsd1_va4_00_obj_small_Trunk (14)",
    };

    private const string Vf108MaskObjectName = "t_gsd1_vf1_08_mask";

    [HarmonyPatch(typeof(GameObject), nameof(GameObject.SetActive))]
    [HarmonyPostfix]
    public static void GameObject_SetActive_Postfix(GameObject __instance, bool value)
    {
        if (_isProcessing || !value)
            return;

        bool isVa404 = __instance.name.Equals("va4_04(Clone)");
        bool isVf108 = __instance.name.Equals("vf1_08(Clone)");
        if (!isVa404 && !isVf108)
            return;

        try
        {
            _isProcessing = true;

            if (isVa404)
                DisableVa404Objects(__instance);

            if (isVf108)
                DisableVf108MaskObject(__instance);
        }
        finally
        {
            _isProcessing = false;
        }
    }

    private static void DisableVa404Objects(GameObject mapRoot)
    {
        Transform objectFolder = mapRoot.transform.Find("object");
        if (objectFolder == null)
        {
            Plugin.Log.LogWarning("[S1DisableObjects] Could not find 'object' folder in va4_04(Clone)");
            return;
        }

        Transform largeFolder = objectFolder.Find("large");
        if (largeFolder == null)
        {
            Plugin.Log.LogWarning("[S1DisableObjects] Could not find 'object/large' folder in va4_04(Clone)");
            return;
        }

        int disabledCount = 0;
        for (int i = 0; i < largeFolder.childCount; i++)
        {
            Transform child = largeFolder.GetChild(i);
            if (_va4LargeObjectNames.Contains(child.name))
            {
                child.gameObject.SetActive(false);
                disabledCount++;

                if (Plugin.Config.DetailedLogs.Value)
                    Plugin.Log.LogInfo($"[S1DisableObjects] Disabled: {child.name}");
            }
        }

        if (disabledCount > 0)
            Plugin.Log.LogInfo($"[S1DisableObjects] Disabled {disabledCount} objects in va4_04/object/large/");
    }

    private static void DisableVf108MaskObject(GameObject mapRoot)
    {
        Transform maskFolder = mapRoot.transform.Find("mask");
        if (maskFolder == null)
        {
            Plugin.Log.LogWarning("[S1DisableObjects] Could not find 'mask' folder in vf1_08(Clone)");
            return;
        }

        Transform maskObject = maskFolder.Find(Vf108MaskObjectName);
        if (maskObject == null)
        {
            Plugin.Log.LogWarning($"[S1DisableObjects] Could not find '{Vf108MaskObjectName}' in vf1_08(Clone)/mask");
            return;
        }

        if (maskObject.gameObject.activeSelf)
            maskObject.gameObject.SetActive(false);

        Plugin.Log.LogInfo($"[S1DisableObjects] Disabled {Vf108MaskObjectName} in vf1_08/mask/");
    }
}
