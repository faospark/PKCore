using HarmonyLib;
using UnityEngine;
using Share.UI.Window;

namespace PKCore.Patches
{
    public class DialogPatch
    {
        // Hook into UIMessageWindow.OpenMessageWindow (5-parameter overload)
        // This is used by Suikoden 2
        [HarmonyPatch(typeof(UIMessageWindow), nameof(UIMessageWindow.OpenMessageWindow))]
        [HarmonyPatch(new[] { typeof(Sprite), typeof(string), typeof(string), typeof(Vector3), typeof(bool) })]
        [HarmonyPostfix]
        public static void OpenMessageWindow_Postfix(UIMessageWindow __instance)
        {
            if (!Plugin.Config.SmallerDialogBox.Value)
                return;

            GameObject dialogWindow = __instance.gameObject;
            ApplyTransform(dialogWindow);
            Plugin.Log.LogInfo($"[DialogPatch] Applied dialog transform via OpenMessageWindow");
        }

        // Hook into UIMessageWindow.SetCharacterFace
        // This appears to be used by Suikoden 1 for dialog display
        [HarmonyPatch(typeof(UIMessageWindow), nameof(UIMessageWindow.SetCharacterFace))]
        [HarmonyPostfix]
        public static void SetCharacterFace_Postfix(UIMessageWindow __instance)
        {
            if (!Plugin.Config.SmallerDialogBox.Value)
                return;

            GameObject dialogWindow = __instance.gameObject;
            ApplyTransform(dialogWindow);
            Plugin.Log.LogInfo($"[DialogPatch] Applied dialog transform via SetCharacterFace");
        }

        private static void ApplyTransform(GameObject obj)
        {
            // Apply position offset (0, -84, 0)
            obj.transform.localPosition = new Vector3(0f, -104f, 0f);
            
            // Apply scale (0.8, 0.8, 1)
            obj.transform.localScale = new Vector3(0.8f, 0.8f, 1f);
        }
    }
}
