using HarmonyLib;
using UnityEngine;

namespace PKCore.Patches;

/// <summary>
/// Patches for Material.mainTexture to catch suikozu texture assignments
/// </summary>
public class HwMeshTexturePatch
{
    /// <summary>
    /// Intercept Material.mainTexture setter to catch suikozu texture assignments
    /// </summary>
    [HarmonyPatch(typeof(Material), nameof(Material.mainTexture), MethodType.Setter)]
    [HarmonyPrefix]
    public static void Material_set_mainTexture_Prefix(Material __instance, ref Texture value)
    {
        if (!Plugin.Config.EnableCustomTextures.Value || value == null)
            return;

        try
        {
            if (value is Texture2D texture)
            {
                string textureName = texture.name;
                
                // Check if this is a suikozu texture
                if (textureName != null && textureName.StartsWith("suikozu_", System.StringComparison.OrdinalIgnoreCase))
                {
                    if (Plugin.Config.DetailedTextureLog.Value)
                    {
                        Plugin.Log.LogInfo($"[Suikozu DEBUG] Material.mainTexture setter found: {textureName}");
                    }
                    
                    // Try to replace the texture
                    if (CustomTexturePatch.ReplaceTextureInPlace(texture, textureName))
                    {
                        if (Plugin.Config.DetailedTextureLog.Value)
                        {
                            Plugin.Log.LogInfo($"[Suikozu] ✓ Replaced via Material.mainTexture: {textureName}");
                        }
                    }
                }
            }
        }
        catch (System.Exception ex)
        {
            Plugin.Log.LogError($"[Material.mainTexture] Error in setter prefix: {ex}");
        }
    }

    public static void Initialize()
    {
        Plugin.Log.LogInfo("[Material.mainTexture] Suikozu texture patches initialized");
    }
}
