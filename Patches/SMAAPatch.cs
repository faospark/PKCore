using HarmonyLib;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace PKCore.Patches
{
    /// <summary>
    /// Enables real SMAA (Subpixel Morphological Anti-Aliasing) using the game's post-processing system.
    /// NOTE: 'Low' quality often provides the best results - higher settings add temporal sampling that can blur sprites.
    /// </summary>
    [HarmonyPatch]
    public class SMAAPatch
    {
        private static bool hasApplied = false;
        
        /// <summary>
        /// Hook into Camera rendering to enable SMAA on the main camera
        /// </summary>
        [HarmonyPatch(typeof(Camera), nameof(Camera.Render))]
        [HarmonyPrefix]
        public static void Camera_Render_Prefix(Camera __instance)
        {
            if (hasApplied)
                return;
            
            // Skip UI cameras - only apply to main game camera
            if (__instance.name.Contains("UI"))
                return;
            
            try
            {
                string quality = Plugin.Config.SMAAQuality.Value.ToLower();
                
                if (quality == "off")
                    return;
                
                // Find PostProcessLayer on the camera
                var postProcessLayer = __instance.GetComponent<PostProcessLayer>();
                if (postProcessLayer == null)
                {
                    Plugin.Log.LogWarning("[SMAA] No PostProcessLayer found on main camera");
                    return;
                }
                
                // Enable SMAA on the post-process layer
                postProcessLayer.antialiasingMode = PostProcessLayer.Antialiasing.SubpixelMorphologicalAntialiasing;
                
                // Configure quality based on setting
                var smaaQuality = GetSMAAQuality(quality);
                postProcessLayer.subpixelMorphologicalAntialiasing.quality = smaaQuality;
                
                hasApplied = true;
                Plugin.Log.LogInfo($"[SMAA] ✓ Enabled with quality: {quality} ({smaaQuality})");
            }
            catch (System.Exception ex)
            {
                Plugin.Log.LogError($"[SMAA] Failed to enable SMAA: {ex.Message}");
            }
        }
        
        /// <summary>
        /// Convert quality string to SMAA quality enum
        /// </summary>
        private static SubpixelMorphologicalAntialiasing.Quality GetSMAAQuality(string quality)
        {
            switch (quality)
            {
                case "low":
                    return SubpixelMorphologicalAntialiasing.Quality.Low;
                case "medium":
                    return SubpixelMorphologicalAntialiasing.Quality.Medium;
                case "high":
                    return SubpixelMorphologicalAntialiasing.Quality.High;
                default:
                    return SubpixelMorphologicalAntialiasing.Quality.Medium;
            }
        }
    }
}
