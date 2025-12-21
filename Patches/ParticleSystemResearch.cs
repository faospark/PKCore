using HarmonyLib;
using UnityEngine;
using BepInEx.Logging;
using System.Reflection;

namespace PKCore.Patches
{
    /// <summary>
    /// Research patch to understand how ParticleSystem components use textures in summon effects.
    /// This is a diagnostic tool - enable via config to gather information.
    /// </summary>
    public class ParticleSystemResearch
    {
        private static ManualLogSource Logger => Plugin.Log;
        private static bool enableLogging = false; // Set via config

        public static void Initialize(bool enabled)
        {
            enableLogging = enabled;
            if (enabled)
            {
                Logger.LogInfo("[ParticleSystem Research] Diagnostic logging enabled");
                
                // Manual patching for IL2CPP compatibility
                var harmony = new Harmony("faospark.pkcore.particleresearch");
                
                // Patch ParticleSystem.Play
                try
                {
                    var playMethod = typeof(ParticleSystem).GetMethod("Play", new System.Type[] { });
                    if (playMethod != null)
                    {
                        harmony.Patch(playMethod, prefix: new HarmonyMethod(typeof(ParticleSystemResearch).GetMethod(nameof(ParticleSystem_Play_Prefix), BindingFlags.NonPublic | BindingFlags.Static)));
                        Logger.LogInfo("[ParticleSystem Research] Successfully patched ParticleSystem.Play");
                    }
                }
                catch (System.Exception ex)
                {
                    Logger.LogWarning($"[ParticleSystem Research] Failed to patch ParticleSystem.Play: {ex.Message}");
                }
                
                // Patch GameObject.SetActive to catch HDEffect activation
                try
                {
                    var setActiveMethod = typeof(GameObject).GetMethod("SetActive", new System.Type[] { typeof(bool) });
                    if (setActiveMethod != null)
                    {
                        harmony.Patch(setActiveMethod, prefix: new HarmonyMethod(typeof(ParticleSystemResearch).GetMethod(nameof(GameObject_SetActive_Prefix), BindingFlags.NonPublic | BindingFlags.Static)));
                        Logger.LogInfo("[ParticleSystem Research] Successfully patched GameObject.SetActive");
                    }
                }
                catch (System.Exception ex)
                {
                    Logger.LogWarning($"[ParticleSystem Research] Failed to patch GameObject.SetActive: {ex.Message}");
                }
            }
        }


        /// <summary>
        /// Log when GameObjects in HDEffect hierarchy are activated
        /// </summary>
        private static void GameObject_SetActive_Prefix(GameObject __instance, bool value)
        {
            if (!enableLogging || !value) return; // Only log when activating (true)

            string objName = __instance.name;
            string path = GetFullPath(__instance);
            
            // Only log if this is in the HDEffect hierarchy
            if (path.Contains("HDEffect", System.StringComparison.OrdinalIgnoreCase))
            {
                Logger.LogInfo($"[ParticleSystem] GameObject activated: '{objName}'");
                Logger.LogInfo($"  Hierarchy: {path}");
                
                // Check for ParticleSystemRenderer
                ParticleSystemRenderer renderer = __instance.GetComponent<ParticleSystemRenderer>();
                if (renderer != null)
                {
                    try
                    {
                        Material mat = renderer.sharedMaterial;
                        if (mat != null)
                        {
                            Logger.LogInfo($"  Has ParticleSystemRenderer");
                            Logger.LogInfo($"  Material: {mat.name}");
                            if (mat.mainTexture != null)
                            {
                                Logger.LogInfo($"  Texture: {mat.mainTexture.name} ({mat.mainTexture.width}x{mat.mainTexture.height})");
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        Logger.LogWarning($"  Failed to read material: {ex.Message}");
                    }
                }
            }
        }

        /// <summary>
        /// Log when ParticleSystem is enabled (summon starts)
        /// </summary>
        private static void ParticleSystem_Play_Prefix(ParticleSystem __instance)
        {
            if (!enableLogging) return;

            string objName = __instance.gameObject.name;
            if (objName.Contains("gate", System.StringComparison.OrdinalIgnoreCase) ||
                objName.Contains("summon", System.StringComparison.OrdinalIgnoreCase) ||
                objName.Contains("eff", System.StringComparison.OrdinalIgnoreCase))
            {
                Logger.LogInfo($"[ParticleSystem] Play() called on '{objName}'");
                Logger.LogInfo($"  Hierarchy: {GetFullPath(__instance.gameObject)}");
                
                // Check if it has a renderer
                ParticleSystemRenderer renderer = __instance.GetComponent<ParticleSystemRenderer>();
                if (renderer != null)
                {
                    try
                    {
                        Material mat = renderer.sharedMaterial;
                        if (mat != null)
                        {
                            Logger.LogInfo($"  Material: {mat.name}");
                            if (mat.mainTexture != null)
                            {
                                Logger.LogInfo($"  Current Texture: {mat.mainTexture.name} ({mat.mainTexture.width}x{mat.mainTexture.height})");
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        Logger.LogWarning($"  Failed to read material: {ex.Message}");
                    }
                }
            }
        }

        /// <summary>
        /// Helper to get full GameObject hierarchy path
        /// </summary>
        private static string GetFullPath(GameObject obj)
        {
            string path = obj.name;
            Transform parent = obj.transform.parent;
            while (parent != null)
            {
                path = parent.name + "/" + path;
                parent = parent.parent;
            }
            return path;
        }
    }
}
