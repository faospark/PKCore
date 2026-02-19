using System;
using UnityEngine;
using HarmonyLib;
using Share.UI.Window;
using System.Collections.Generic;
using BepInEx.Logging;

namespace PKCore.Patches
{
    /// <summary>
    /// Monitors the covert mission state by checking for specific background elements.
    /// Redirects Hero and Jowy portraits to their disguised versions when active.
    /// </summary>
    [HarmonyPatch]
    public class CovertMissionPortraitMonitor : MonoBehaviour
    {
        private static ManualLogSource Logger => Plugin.Log;
        private static CovertMissionPortraitMonitor instance;

        // Configuration
        // The background objects that indicate the covert mission is active
        private const string COVERT_BG_NAME_1 = "vc30_01(Clone)"; 
        private const string COVERT_BG_NAME_2 = "vc08_00(Clone)"; 
        // We might need a more specific path if simple name check is too broad, 
        // but finding by name is safer if hierarchy changes.
        // User provided: "bgManagerHD/vc30_01(Clone)" -> implying checking parent might be good if possible,
        // but GameObject.Find(name) is standard.
        
        // Portrait filenames
        private const string HERO_PORTRAIT_ORIGINAL = "fp_001";
        private const string HERO_PORTRAIT_DISGUISE = "s2_hero_disguise";
        private const string JOWY_PORTRAIT_ORIGINAL = "fp_080";
        private const string JOWY_PORTRAIT_DISGUISE = "fp_080_highland";

        // State
        public static bool IsCovertMissionActive { get; private set; } = false;
        
        private float checkInterval = 1.0f; 
        private float timer = 0f;
        
        // Caching sprites to avoid reloading every frame/call
        private static Sprite cachedHeroDisguise;
        private static Sprite cachedJowyDisguise;

        public static void Initialize()
        {
            if (instance != null) return;

            GameObject host = new GameObject("PKCore_CovertMissionPortraitMonitor");
            UnityEngine.Object.DontDestroyOnLoad(host);
            host.hideFlags = HideFlags.HideAndDontSave;
            
            instance = host.AddComponent<CovertMissionPortraitMonitor>();
            Logger.LogInfo("[CovertMissionPortraitMonitor] Initialized");
        }

        private void Update()
        {
            // Check less frequently to save performance
            timer += Time.unscaledDeltaTime;
            if (timer < checkInterval) return;
            timer = 0f;

            CheckMissionState();
        }

        private void CheckMissionState()
        {
            // Logic: Check if "vc30_01(Clone)" exists and is active
            // The user specified "bgManagerHD/vc30_01(Clone)". 
            // We'll search for the objects.
            
            GameObject bgObj1 = GameObject.Find(COVERT_BG_NAME_1);
            GameObject bgObj2 = GameObject.Find(COVERT_BG_NAME_2);
            
            // If strictly needed to be under bgManagerHD, we could check parent, 
            // but usually unique name + active is enough.
            bool isActive = (bgObj1 != null && bgObj1.activeInHierarchy) || (bgObj2 != null && bgObj2.activeInHierarchy);
            
            if (isActive != IsCovertMissionActive)
            {
                IsCovertMissionActive = isActive;
                Logger.LogInfo($"[CovertMissionPortraitMonitor] Covert Mission State Changed: {IsCovertMissionActive}");
                
                // Preload sprites if we just became active
                if (IsCovertMissionActive)
                {
                    PreloadSprites();
                }
            }
        }
        
        private static void PreloadSprites()
        {
            if (cachedHeroDisguise == null)
                cachedHeroDisguise = LoadSprite(HERO_PORTRAIT_DISGUISE);
                
            if (cachedJowyDisguise == null)
                cachedJowyDisguise = LoadSprite(JOWY_PORTRAIT_DISGUISE);
        }

        private static Sprite LoadSprite(string portraitName)
        {
            Texture2D tex = PortraitSystemPatch.LoadPortraitTexture(portraitName);
            if (tex != null)
            {
                // Create sprite with standard pivot/PPU
                Sprite sprite = Sprite.Create(
                    tex, 
                    new Rect(0, 0, tex.width, tex.height), 
                    new Vector2(0.5f, 0.5f), 
                    100f, 
                    0, 
                    SpriteMeshType.FullRect
                );
                UnityEngine.Object.DontDestroyOnLoad(sprite);
                UnityEngine.Object.DontDestroyOnLoad(tex);
                return sprite;
            }
            return null;
        }

        // --- Harmony Patches ---

        /// <summary>
        /// Patch OpenChoicesWindow to replace Hero portrait (fp_000) with s2_hero_disguise
        /// when Covert Mission is active.
        /// </summary>
        [HarmonyPatch(typeof(UIMessageWindow), nameof(UIMessageWindow.OpenChoicesWindow))]
        [HarmonyPrefix]
        public static void OpenChoicesWindow_Prefix(ref Sprite faceImage)
        {
            if (!IsCovertMissionActive) return;
            if (faceImage == null) return;
            
            // Check if it's the Hero's portrait
            // Note: faceImage.name might be instance name, check texture name or rely on sprite name if consistent
            if (faceImage.name.Contains(HERO_PORTRAIT_ORIGINAL) || (faceImage.texture != null && faceImage.texture.name.Contains(HERO_PORTRAIT_ORIGINAL)))
            {
                Logger.LogInfo($"[CovertMissionPortraitMonitor] Replacing Hero portrait in Choices Window");
                
                if (cachedHeroDisguise == null) PreloadSprites(); // Just in case
                
                if (cachedHeroDisguise != null)
                {
                    faceImage = cachedHeroDisguise;
                }
            }
        }

        /// <summary>
        /// Patch OpenMessageWindow to replace Jowy/fp_080 with s2_jowy_disguise
        /// when Covert Mission is active.
        /// </summary>
        [HarmonyPatch(typeof(UIMessageWindow), nameof(UIMessageWindow.OpenMessageWindow))]
        [HarmonyPatch(new[] { typeof(Sprite), typeof(string), typeof(string), typeof(Vector3), typeof(bool) })]
        [HarmonyPrefix]
        public static void OpenMessageWindow_Prefix(ref Sprite faceImage, ref string name)
        {
            if (!IsCovertMissionActive) return;

            // Condition 1: Name is "Jowy" (simple check)
            // Condition 2: Portrait is fp_080 using the provided "any calll on fp_080" rule
            
            bool isJowyName = !string.IsNullOrEmpty(name) && name.Contains("Jowy");
            bool isJowyPortrait = faceImage != null && (faceImage.name.Contains(JOWY_PORTRAIT_ORIGINAL) || (faceImage.texture != null && faceImage.texture.name.Contains(JOWY_PORTRAIT_ORIGINAL)));

            if (isJowyName || isJowyPortrait)
            {
                Logger.LogInfo($"[CovertMissionPortraitMonitor] Replacing Jowy portrait in Message Window (Name: {name}, Sprite: {(faceImage ? faceImage.name : "null")})");

                if (cachedJowyDisguise == null) PreloadSprites();
                
                if (cachedJowyDisguise != null)
                {
                    faceImage = cachedJowyDisguise;
                }
            }
        }
    }
}
