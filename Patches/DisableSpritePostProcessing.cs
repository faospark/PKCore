using HarmonyLib;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace PKCore.Patches;

public class DisableSpritePostProcessingPatch
{
    private const int SpriteLayerMask = 1 << 31; // Use layer 31 for sprites to exclude from post-processing
    private static bool _isEnabled = false;

    /// <summary>
    /// Check if a sprite is a battle sprite by examining its name
    /// </summary>
    private static bool IsBattleSprite(Sprite sprite)
    {
        if (sprite == null) return false;
        
        // Battle sprites are named like: battle_monster_*, battle_player_*, etc.
        string spriteName = sprite.name;
        return spriteName.StartsWith("battle_");
    }

    /// <summary>
    /// Apply the correct layer to a renderer based on its sprite
    /// </summary>
    private static void UpdateRendererLayer(GRSpriteRenderer renderer)
    {
        if (renderer == null || renderer.gameObject == null) return;
        
        bool shouldDisablePostProcessing = IsBattleSprite(renderer.sprite);
        
        if (shouldDisablePostProcessing)
        {
            // Move to layer 31 (No Post-Processing)
            if (renderer.gameObject.layer != 31)
            {
                renderer.gameObject.layer = 31;
                // Plugin.Log.LogInfo($"[DisablePostProcess] Moved {renderer.gameObject.name} (Sprite: {renderer.sprite?.name}) to Layer 31");
            }
        }
        else
        {
            // Revert to default layer (0) if it was previously set to 31
            // Warning: This assumes the default was 0. Most sprites are on Default (0) or TransparentFX (1).
            // Safe to assume 0 for standard sprites, but use caution.
            if (renderer.gameObject.layer == 31)
            {
                renderer.gameObject.layer = 0;
            }
        }
    }

    // Hook into GRSpriteRenderer (Awake is more reliable than Start for IL2CPP proxies usually)
    [HarmonyPatch(typeof(GRSpriteRenderer), nameof(GRSpriteRenderer.Awake))]
    [HarmonyPostfix]
    static void GRSpriteRenderer_Awake_Postfix(GRSpriteRenderer __instance)
    {
        if (!_isEnabled || __instance == null) return;
        UpdateRendererLayer(__instance);
    }
    
    // Hook into sprite setter to catch runtime changes (animations, swaps)
    [HarmonyPatch(typeof(GRSpriteRenderer), nameof(GRSpriteRenderer.sprite), MethodType.Setter)]
    [HarmonyPostfix]
    static void GRSpriteRenderer_set_sprite_Postfix(GRSpriteRenderer __instance)
    {
        if (!_isEnabled || __instance == null) return;
        UpdateRendererLayer(__instance);
    }

    // Hook ForceSprite to catch that too
    [HarmonyPatch(typeof(GRSpriteRenderer), nameof(GRSpriteRenderer.SetForceSprite))]
    [HarmonyPostfix]
    static void GRSpriteRenderer_SetForceSprite_Postfix(GRSpriteRenderer __instance)
    {
        if (!_isEnabled || __instance == null) return;
        UpdateRendererLayer(__instance);
    }
    
    // OnEnable is also a good place to check
    [HarmonyPatch(typeof(GRSpriteRenderer), nameof(GRSpriteRenderer.OnEnable))]
    [HarmonyPostfix]
    static void GRSpriteRenderer_OnEnable_Postfix(GRSpriteRenderer __instance)
    {
        if (!_isEnabled || __instance == null) return;
        UpdateRendererLayer(__instance);
    }

    // Alternative approach: Disable specific post-processing effects on sprite materials
    // This runs AFTER AntiAliasingPatch to preserve anti-aliasing settings
    [HarmonyPatch(typeof(GRSpriteRenderer), nameof(GRSpriteRenderer.material), MethodType.Setter)]
    [HarmonyPriority(Priority.LowerThanNormal)] // Run after other patches (like AntiAliasing)
    [HarmonyPostfix]
    static void DisablePostProcessOnMaterial(GRSpriteRenderer __instance)
    {
        if (!_isEnabled || __instance == null || __instance._mat == null)
        {
            return;
        }

        // Only apply if this is a target battle sprite
        if (!IsBattleSprite(__instance.sprite))
        {
            return;
        }

        var material = __instance._mat;
        
        // Disable post-processing keywords/features on the sprite material
        if (material.HasProperty("_MainTex"))
        {
            // Only set render queue if it hasn't been modified by other patches
            // Default sprite queue is 2000, if it's still default, move it to overlay
            if (material.renderQueue >= 2000 && material.renderQueue < 3000)
            {
                material.renderQueue = 3000; // Overlay queue renders after post-processing
            }
            
            // Disable shader features that would apply post-processing effects
            // These don't affect texture filtering (used by anti-aliasing)
            material.DisableKeyword("BLOOM");
            material.DisableKeyword("BLOOM_LENS_DIRT");
            material.DisableKeyword("CHROMATIC_ABERRATION");
            material.DisableKeyword("DISTORT");
            material.DisableKeyword("VIGNETTE");
            material.DisableKeyword("GRAIN");
        }
    }

    // Ensure post-processing effects don't affect sprite renderers
    [HarmonyPatch(typeof(UnityEngine.Rendering.PostProcessing.PostProcessLayer), nameof(UnityEngine.Rendering.PostProcessing.PostProcessLayer.OnEnable))]
    [HarmonyPostfix]
    static void ConfigurePostProcessLayer(UnityEngine.Rendering.PostProcessing.PostProcessLayer __instance)
    {
        if (!_isEnabled || __instance == null)
        {
            return;
        }

        // Exclude sprite layer from post-processing volume triggers
        __instance.volumeLayer &= ~SpriteLayerMask;
    }

    public static void Initialize()
    {
        _isEnabled = Plugin.Config.DisableSpritePostProcessing.Value;

        if (_isEnabled)
        {
            // Find all existing sprite renderers and update them
            var spriteRenderers = Object.FindObjectsOfType<GRSpriteRenderer>();
            
            foreach (var renderer in spriteRenderers)
            {
                UpdateRendererLayer(renderer);
                
                if (renderer != null && renderer._mat != null)
                {
                    DisablePostProcessOnMaterial(renderer);
                }
            }

            // Update existing post-process layers
            var postProcessLayers = Object.FindObjectsOfType<PostProcessLayer>();
            foreach (var layer in postProcessLayers)
            {
                if (layer != null)
                {
                    layer.volumeLayer &= ~SpriteLayerMask;
                }
            }
        }
    }
}
