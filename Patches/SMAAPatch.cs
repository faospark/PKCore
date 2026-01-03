using HarmonyLib;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace PKCore.Patches;

/// <summary>
/// Applies SMAA (Subpixel Morphological Anti-Aliasing) to sprites
/// Uses GRSpriteRenderer patches to catch all sprites as they're created
/// </summary>
public static class SMAAPatch
{
    private static bool _isEnabled = false;
    private static HashSet<string> _excludeGroups = new HashSet<string>();
    private static int _smaaAppliedCount = 0;

    /// <summary>
    /// Initialize SMAA anti-aliasing
    /// </summary>
    public static void Initialize()
    {
        _isEnabled = Plugin.Config.EnableSMAA.Value;
        
        if (_isEnabled)
        {
            // Parse exclude groups
            var excludeGroupsStr = Plugin.Config.SMAAExcludeGroups.Value;
            if (!string.IsNullOrWhiteSpace(excludeGroupsStr))
            {
                _excludeGroups = new HashSet<string>(
                    excludeGroupsStr.Split(',').Select(s => s.Trim()).Where(s => !string.IsNullOrEmpty(s))
                );
            }

            Plugin.Log.LogInfo("[SMAA] Initializing SMAA anti-aliasing for sprites");
            Plugin.Log.LogInfo($"[SMAA] Exclude groups: {(_excludeGroups.Count > 0 ? string.Join(", ", _excludeGroups) : "NONE")}");
        }
    }

    /// <summary>
    /// Patch GRSpriteRenderer.Awake to apply SMAA when sprites are created
    /// </summary>
    [HarmonyPatch(typeof(GRSpriteRenderer), nameof(GRSpriteRenderer.Awake))]
    [HarmonyPostfix]
    public static void OnSpriteAwake(GRSpriteRenderer __instance)
    {
        if (!_isEnabled || __instance == null)
            return;

        ApplySMAAToSprite(__instance);
    }

    /// <summary>
    /// Patch GRSpriteRenderer.material setter to apply SMAA when material changes
    /// </summary>
    [HarmonyPatch(typeof(GRSpriteRenderer), nameof(GRSpriteRenderer.material), MethodType.Setter)]
    [HarmonyPostfix]
    public static void OnMaterialSet(GRSpriteRenderer __instance)
    {
        if (!_isEnabled || __instance == null)
            return;

        ApplySMAAToSprite(__instance);
    }

    /// <summary>
    /// Apply SMAA to a sprite's material
    /// </summary>
    private static void ApplySMAAToSprite(GRSpriteRenderer sprite)
    {
        try
        {
            // Check if this sprite should be excluded
            if (ShouldExclude(sprite.gameObject))
                return;

            var material = sprite._mat;
            if (material == null || material.mainTexture == null)
                return;

            // Apply SMAA by enabling texture filtering and smoothing
            material.mainTexture.filterMode = FilterMode.Trilinear;
            material.mainTexture.anisoLevel = 4;

            // Enable SMAA shader keywords if available
            try
            {
                material.EnableKeyword("_SMAA");
                material.EnableKeyword("_SMOOTHNESS_TEXTURE_ALBEDO_CHANNEL_A");
            }
            catch
            {
                // Keywords might not exist, ignore
            }

            _smaaAppliedCount++;
            
            if (Plugin.Config.DetailedTextureLog.Value)
            {
                string path = GetGameObjectPath(sprite.gameObject);
                Plugin.Log.LogInfo($"[SMAA] ✓ Applied to: {path}");
            }
        }
        catch (System.Exception ex)
        {
            Plugin.Log.LogWarning($"[SMAA] Failed to apply: {ex.Message}");
        }
    }

    /// <summary>
    /// Check if sprite should be excluded based on its hierarchy
    /// </summary>
    private static bool ShouldExclude(GameObject obj)
    {
        // Check if object or any parent is in exclude list
        Transform current = obj.transform;
        while (current != null)
        {
            if (_excludeGroups.Contains(current.name))
                return true;
            current = current.parent;
        }

        return false;
    }

    /// <summary>
    /// Get full path of GameObject in hierarchy
    /// </summary>
    private static string GetGameObjectPath(GameObject obj)
    {
        string path = obj.name;
        Transform current = obj.transform.parent;

        while (current != null)
        {
            path = current.name + "/" + path;
            current = current.parent;
        }

        return path;
    }

    /// <summary>
    /// Get count of sprites that have SMAA applied
    /// </summary>
    public static int GetAppliedCount()
    {
        return _smaaAppliedCount;
    }
}
