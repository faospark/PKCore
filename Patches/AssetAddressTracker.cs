using System;
using System.Collections.Generic;
using HarmonyLib;
using UnityEngine;

namespace PKCore.Patches
{
    /// <summary>
    /// Tracks Unity addressable/AssetBundle asset paths by their native pointer.
    /// Hooks UnityEngine.AssetBundle.LoadAsset_Internal to record loaded assets.
    /// </summary>
    [HarmonyPatch(typeof(UnityEngine.AssetBundle), "LoadAsset_Internal")]
    internal static class AssetAddressTracker
    {
        // Maps IL2CPP native pointer → asset bundle path key
        private static readonly Dictionary<IntPtr, string> AddressByPointer = new Dictionary<IntPtr, string>();

        /// <summary>
        /// Retrieves the asset path for a given native pointer or object.
        /// </summary>
        public static bool TryGetAddress(Sprite sprite, Texture2D texture, out string assetAddress)
        {
            assetAddress = null;

            if (sprite != null && sprite.Pointer != IntPtr.Zero)
            {
                if (AddressByPointer.TryGetValue(sprite.Pointer, out assetAddress))
                    return true;
            }

            if (texture != null && texture.Pointer != IntPtr.Zero)
            {
                if (AddressByPointer.TryGetValue(texture.Pointer, out assetAddress))
                    return true;
            }

            return false;
        }

        [HarmonyPostfix]
        private static void Postfix(UnityEngine.AssetBundle __instance, string name, Il2CppSystem.Type type, UnityEngine.Object __result)
        {
            if (__result == null || string.IsNullOrEmpty(name))
                return;

            try
            {
                // Record the loaded asset's pointer
                AddressByPointer[__result.Pointer] = name;

                // Also index nested texture pointer for sprites
                var sprite = __result.TryCast<Sprite>();
                if (sprite != null && sprite.texture != null)
                {
                    AddressByPointer[sprite.texture.Pointer] = name;
                }
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"[AssetAddressTracker] Error in AssetBundle hook: {ex.Message}");
            }
        }
    }
}
