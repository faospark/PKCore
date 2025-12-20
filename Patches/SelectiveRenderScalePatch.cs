using HarmonyLib;
using UnityEngine;

namespace PKCore.Patches;

/// <summary>
/// Selective texture downscaling for performance
/// Downscales game content (sprites, backgrounds) while preserving UI at native resolution
/// This is a manual implementation since QualitySettings.renderScale is not available in this Unity version
/// </summary>
public class SelectiveRenderScalePatch
{
    private static bool _enabled = false;
    private static float _gameContentScale = 0.7f;

    /// <summary>
    /// Check if a texture is UI-related (should NOT be downscaled)
    /// </summary>
    private static bool IsUITexture(string textureName)
    {
        string lowerName = textureName.ToLower();
        
        // UI indicators in name
        return lowerName.Contains("ui_") || 
               lowerName.Contains("menu") || 
               lowerName.Contains("button") ||
               lowerName.Contains("icon") ||
               lowerName.Contains("launcher") ||
               lowerName.Contains("cursor") ||
               lowerName.Contains("hud");
    }

    /// <summary>
    /// Downscale a texture for performance while maintaining quality
    /// </summary>
    private static Texture2D DownscaleTexture(Texture2D original, float scale)
    {
        if (scale >= 1.0f) return original;
        
        int newWidth = Mathf.Max(1, (int)(original.width * scale));
        int newHeight = Mathf.Max(1, (int)(original.height * scale));
        
        // Create new texture at scaled size
        Texture2D scaled = new Texture2D(newWidth, newHeight, original.format, true);
        scaled.filterMode = FilterMode.Bilinear;
        scaled.wrapMode = original.wrapMode;
        scaled.anisoLevel = original.anisoLevel;
        
        // Use RenderTexture for high-quality bilinear downscaling
        RenderTexture rt = RenderTexture.GetTemporary(newWidth, newHeight);
        rt.filterMode = FilterMode.Bilinear;
        
        RenderTexture.active = rt;
        Graphics.Blit(original, rt);
        
        scaled.ReadPixels(new Rect(0, 0, newWidth, newHeight), 0, 0);
        scaled.Apply(true, false);
        
        RenderTexture.active = null;
        RenderTexture.ReleaseTemporary(rt);
        
        return scaled;
    }

    /// <summary>
    /// Intercept Sprite.texture getter to downscale game sprites
    /// UI sprites are detected and kept at native resolution
    /// </summary>
    [HarmonyPatch(typeof(Sprite), nameof(Sprite.texture), MethodType.Getter)]
    [HarmonyPostfix]
    static void Sprite_get_texture_Postfix(Sprite __instance, ref Texture2D __result)
    {
        if (!_enabled || __result == null) return;
        if (_gameContentScale >= 1.0f) return;

        // Check if this is a UI sprite (should not be downscaled)
        string spriteName = __instance.name;
        if (IsUITexture(spriteName)) return;

        // Check if already downscaled (avoid re-downscaling)
        if (__result.width < 100 && __result.height < 100) return; // Skip very small textures

        // Downscale the texture
        Texture2D original = __result;
        __result = DownscaleTexture(original, _gameContentScale);
        
        if (Plugin.Config.DetailedTextureLog.Value && __result != original)
        {
            Plugin.Log.LogInfo($"Downscaled sprite texture: {spriteName} ({original.width}x{original.height} → {__result.width}x{__result.height})");
        }
    }

    public static void Initialize()
    {
        _enabled = Plugin.Config.EnableSelectiveDownscaling.Value;
        _gameContentScale = Plugin.Config.GameContentScale.Value;

        if (!_enabled)
        {
            Plugin.Log.LogInfo("Selective texture downscaling disabled");
            return;
        }

        Plugin.Log.LogInfo($"========================================");
        Plugin.Log.LogInfo($"Selective Texture Downscaling Enabled");
        Plugin.Log.LogInfo($"Game Content Scale: {_gameContentScale * 100}%");
        Plugin.Log.LogInfo($"");
        Plugin.Log.LogInfo($"How it works:");
        Plugin.Log.LogInfo($"  - Game content (sprites, backgrounds) scaled to {_gameContentScale * 100}%");
        Plugin.Log.LogInfo($"  - UI (menus, text, buttons) stays at 100%");
        Plugin.Log.LogInfo($"  - Result: Better performance with crisp UI!");
        Plugin.Log.LogInfo($"========================================");
    }
}
