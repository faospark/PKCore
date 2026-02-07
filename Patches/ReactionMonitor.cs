using System;
using UnityEngine;
using UnityEngine.UI;
using BepInEx.Unity.IL2CPP;
using BepInEx.Logging;

namespace PKCore.Patches
{
    /// <summary>
    /// Monitors the game for specific object activation ('r_action') 
    /// and triggers a custom UI reaction overlay.
    /// </summary>
    public class ReactionMonitor : MonoBehaviour
    {
        private static ManualLogSource Logger => Plugin.Log;
        private static ReactionMonitor instance;

        // Configuration
        private const string TRIGGER_OBJECT_PATH = "AppRoot/Map/MapChara/r_action";
        private const string PORTRAIT_NAME = "fu"; // filename: fu.png
        
        // State
        private GameObject triggerObject;
        private GameObject overlayRoot;
        private Image overlayImage; // The purple background
        private Image portraitImage; // The "fu" portrait
        
        private float checkInterval = 0.2f; // Check every 200ms
        private float timer = 0f;
        private bool wasActive = false;
        
        // Fade effect
        private bool isFading = false;
        private float fadeTimer = 0f;
        private float fadeDuration = 1.5f;

        public static void Initialize()
        {
            if (instance != null) return;

            // Create a hidden GameObject to host this script
            GameObject host = new GameObject("PKCore_ReactionMonitor");
            UnityEngine.Object.DontDestroyOnLoad(host);
            host.hideFlags = HideFlags.HideAndDontSave;
            
            instance = host.AddComponent<ReactionMonitor>();
            Logger.LogInfo("[ReactionMonitor] Initialized");
        }

        private void Update()
        {
            // Handle fade animation
            if (isFading && portraitImage != null)
            {
                fadeTimer += Time.unscaledDeltaTime;
                float progress = Mathf.Clamp01(fadeTimer / fadeDuration);
                
                // Fade the portrait image
                Color c = portraitImage.color;
                c.a = progress;
                portraitImage.color = c;
                
                if (progress >= 1f)
                    isFading = false;
            }

            // Throttle checks
            timer += Time.unscaledDeltaTime;
            if (timer < checkInterval) return;
            timer = 0f;

            CheckTrigger();
        }

        private void CheckTrigger()
        {
            // 1. Find the trigger object if we lost it
            if (triggerObject == null)
            {
                triggerObject = GameObject.Find(TRIGGER_OBJECT_PATH);
                if (triggerObject != null)
                     Logger.LogInfo($"[ReactionMonitor] Found '{TRIGGER_OBJECT_PATH}' (Active: {triggerObject.activeInHierarchy})");
            }

            // 2. Check active state
            bool isActive = triggerObject != null && triggerObject.activeInHierarchy;

            // 3. Handle state change
            if (isActive != wasActive)
            {
                wasActive = isActive;
                
                if (isActive)
                {
                    OnTriggerActivated();
                }
                else
                {
                    OnTriggerDeactivated();
                }
            }
        }

        private void OnTriggerActivated()
        {
            Logger.LogInfo($"[ReactionMonitor] Trigger '{TRIGGER_OBJECT_PATH}' ACTIVATED! Showing overlay.");
            ShowOverlay();
        }

        private void OnTriggerDeactivated()
        {
            // Logger.LogInfo($"[ReactionMonitor] Trigger Deactivated.");
            HideOverlay();
        }

        private void ShowOverlay()
        {
            // Ensure UI exists
            if (overlayRoot == null)
            {
                CreateOverlay();
            }

            if (overlayRoot != null)
            {
                overlayRoot.SetActive(true);
                // Start fade in
                if (portraitImage != null)
                {
                    Color c = portraitImage.color;
                    c.a = 0f;
                    portraitImage.color = c;
                    
                    isFading = true;
                    fadeTimer = 0f;
                }
            }
        }

        private void HideOverlay()
        {
            if (overlayRoot != null)
            {
                overlayRoot.SetActive(false);
            }
        }

        private void CreateOverlay()
        {
            try
            {
                // Find a canvas to attach to. UI_Root/UI_Canvas_Root is standard.
                GameObject canvasRoot = GameObject.Find("UI_Root/UI_Canvas_Root");
                if (canvasRoot == null)
                {
                    Logger.LogWarning("[ReactionMonitor] Could not find UI_Root/UI_Canvas_Root");
                    return; // Try again later
                }

                // 1. Create Root Panel (Purple Background)
                overlayRoot = new GameObject("fu");
                overlayRoot.transform.SetParent(canvasRoot.transform, false);
                
                RectTransform rootRect = overlayRoot.AddComponent<RectTransform>();
                // User requested size 300x300 and specific position.
                rootRect.anchorMin = new Vector2(0.5f, 0.5f);
                rootRect.anchorMax = new Vector2(0.5f, 0.5f);
                rootRect.pivot = new Vector2(0.5f, 0.5f);
                rootRect.sizeDelta = new Vector2(300, 300); 
                rootRect.anchoredPosition = new Vector2(587.9171f, -313.2f); // Updated per user request (587.9171, -313.2, 0)
                // Note: user asked for "local position ... 0", anchoredPosition is safe for Canvas UIs.
                
                // Add Image for background color (DISABLED per request)
                overlayImage = overlayRoot.AddComponent<Image>();
                overlayImage.color = Color.clear; // Invisible
                overlayImage.raycastTarget = false;

                // 2. Create Portrait Image (Child)
                GameObject portraitObj = new GameObject("Portrait");
                portraitObj.transform.SetParent(overlayRoot.transform, false);
                
                RectTransform portraitRect = portraitObj.AddComponent<RectTransform>();
                portraitRect.anchorMin = Vector2.zero;
                portraitRect.anchorMax = Vector2.one;
                portraitRect.offsetMin = Vector2.zero;
                portraitRect.offsetMax = Vector2.zero; // Fill the purple box?
                
                portraitImage = portraitObj.AddComponent<Image>();
                portraitImage.raycastTarget = false;
                portraitImage.preserveAspect = true;

                // Load the texture
                Texture2D tex = NPCPortraitPatch.LoadPortraitTexture(PORTRAIT_NAME);
                if (tex != null)
                {
                    Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100f);
                    UnityEngine.Object.DontDestroyOnLoad(sprite);
                    UnityEngine.Object.DontDestroyOnLoad(tex);
                    portraitImage.sprite = sprite;
                }
                else
                {
                    Logger.LogWarning($"[ReactionMonitor] Could not load portrait '{PORTRAIT_NAME}'");
                }
                
                Logger.LogInfo("[ReactionMonitor] Overlay UI created successfully.");
            }
            catch (Exception ex)
            {
                Logger.LogError($"[ReactionMonitor] Failed to create overlay: {ex.Message}");
            }
        }
    }
}
