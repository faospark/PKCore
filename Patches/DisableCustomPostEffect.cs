using HarmonyLib;
using UnityEngine;
using System.Reflection;

namespace PKCore.Patches;

/// <summary>
/// Disables the CustomPostEffect component on the Camera GameObject under AppRoot
/// This prevents unwanted post-processing effects from being applied
/// </summary>
[HarmonyPatch]
public static class DisableCustomPostEffectPatch
{
    private static bool hasPatched = false;

    /// <summary>
    /// Manually patch CustomPostEffect.OnRenderImage to skip execution
    /// This is more reliable than trying to disable the component
    /// </summary>
    public static void Initialize(Harmony harmony)
    {
        if (hasPatched)
            return;

        try
        {
            Plugin.Log.LogInfo("Applying ColoredIntroAndFlashbacks Patch");
            
            // Find the CustomPostEffect type
            System.Type customPostEffectType = FindCustomPostEffectType();
            
            if (customPostEffectType == null)
            {
                Plugin.Log.LogWarning("[DisableCustomPostEffect] Could not find CustomPostEffect type");
                return;
            }

            // Find the OnRenderImage method
            var onRenderImageMethod = customPostEffectType.GetMethod("OnRenderImage", 
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            
            if (onRenderImageMethod == null)
            {
                Plugin.Log.LogWarning("[DisableCustomPostEffect] Could not find OnRenderImage method");
                return;
            }

            // Create prefix method to skip execution
            var prefixMethod = typeof(DisableCustomPostEffectPatch).GetMethod(nameof(OnRenderImage_Prefix), 
                BindingFlags.Public | BindingFlags.Static);

            // Apply the patch
            harmony.Patch(onRenderImageMethod, prefix: new HarmonyMethod(prefixMethod));
            

            hasPatched = true;
        }
        catch (System.Exception ex)
        {
            Plugin.Log.LogError($"[DisableCustomPostEffect] Error patching CustomPostEffect: {ex.Message}");
            Plugin.Log.LogError($"[DisableCustomPostEffect] Stack trace: {ex.StackTrace}");
        }
    }

    /// <summary>
    /// Prefix for CustomPostEffect.OnRenderImage - selectively skips execution only for sepia/monotone flashbacks
    /// Preserves nighttime (CameraNightMaterial) and combat effect shaders
    /// </summary>
    public static bool OnRenderImage_Prefix(CustomPostEffect __instance)
    {
        if (__instance == null || __instance.material == null)
            return true;

        string matName = __instance.material.name;
        if (string.IsNullOrEmpty(matName))
            return true;

        // Never disable night scenes or combat/war special visual filters
        if (matName.IndexOf("Night", System.StringComparison.OrdinalIgnoreCase) >= 0 ||
            matName.IndexOf("RevColor", System.StringComparison.OrdinalIgnoreCase) >= 0)
        {
            return true; // Allow original OnRenderImage to render the night/filter effect
        }

        // Only skip for monotone / sepia filters (intro and flashback sequences)
        if (matName.IndexOf("Monotone", System.StringComparison.OrdinalIgnoreCase) >= 0 ||
            matName.IndexOf("Sepia", System.StringComparison.OrdinalIgnoreCase) >= 0)
        {
            return false; // Skip original method to keep intro/flashbacks in full color
        }

        return true;
    }

    /// <summary>
    /// Find the CustomPostEffect type in loaded assemblies
    /// </summary>
    private static System.Type FindCustomPostEffectType()
    {
        foreach (var assembly in System.AppDomain.CurrentDomain.GetAssemblies())
        {
            var assemblyName = assembly.GetName().Name;
            
            // Check game assemblies
            if (assemblyName == "GSD2" || assemblyName == "GSDShare" || assemblyName == "GSD1" || assemblyName == "Assembly-CSharp")
            {
                var type = assembly.GetType("CustomPostEffect");
                if (type != null)
                {

                    return type;
                }
            }
        }
        
        Plugin.Log.LogWarning("[DisableCustomPostEffect] CustomPostEffect type not found in any assembly");
        return null;
    }
}
