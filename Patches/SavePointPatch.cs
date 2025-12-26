using HarmonyLib;
using UnityEngine;
using UnityEngine.U2D;
using System;

namespace PKCore.Patches;

/// <summary>
/// MonoBehaviour that monitors a save point SpriteRenderer and ensures custom sprites are applied
/// This is needed because the Animator uses direct field access, bypassing our Harmony patches
/// </summary>
public class SavePointSpriteMonitor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private static bool hasLoggedGlowDisable = false; // Track if we've logged glow disable
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Plugin.Log.LogWarning("[SavePoint Monitor] No SpriteRenderer found on GameObject!");
            enabled = false;
        }
        else
        {
            // Plugin.Log.LogInfo($"[SavePoint Monitor] Started monitoring: {gameObject.name}");
            
            // Try to replace the underlying texture directly (better solution)
            if (spriteRenderer.sprite != null && spriteRenderer.sprite.texture != null)
            {
                string textureName = spriteRenderer.sprite.texture.name;
                // Plugin.Log.LogInfo($"[SavePoint Monitor] Original Texture Name: {textureName}");

                if (textureName == "t_obj_savePoint_ball" && CustomTexturePatch.HasCustomTexture(textureName))
                {
                    bool success = CustomTexturePatch.ReplaceTextureInPlace(spriteRenderer.sprite.texture, textureName);
                    if (success)
                    {
                        if (Plugin.Config.DetailedTextureLog.Value)
                        {
                            Plugin.Log.LogInfo("[SavePoint Monitor] ✓ Successfully replaced texture in-place. Disabling monitor.");
                        }
                        enabled = false; // No need to monitor frames anymore!
                    }
                }
            }
            
            // Disable glow effect if configured
            if (Plugin.Config.DisableSavePointGlow.Value)
            {
                // Navigate up to find the save point root, then find Glow_add
                Transform current = transform;
                while (current != null && !current.name.Contains("savePoint"))
                {
                    current = current.parent;
                }
                
                if (current != null)
                {
                    // Look for Glow_add in children
                    Transform glowTransform = current.Find("Fire_add/Glow_add");
                    if (glowTransform == null)
                    {
                        // Try alternate path
                        glowTransform = current.Find("Particle_add/Glow_add");
                    }
                    
                    if (glowTransform != null)
                    {
                        glowTransform.gameObject.SetActive(false);
                        if (!hasLoggedGlowDisable)
                        {
                            Plugin.Log.LogInfo("[SavePoint] ✓ Disabled save point glow effect");
                            hasLoggedGlowDisable = true;
                        }
                    }
                }
            }
        }
    }
    
    void LateUpdate()
    {
        // Must check EVERY frame to fight the Animator
        // Flickering happens if we skip frames (Animator wins on skipped frames)
            
        if (spriteRenderer == null || spriteRenderer.sprite == null)
            return;
        
        string currentSpriteName = spriteRenderer.sprite.name;
        
            // Check if this is a save point ball sprite
        if (currentSpriteName.StartsWith("t_obj_savePoint_ball_"))
        {
            // STRATEGY: Check if the current sprite is our custom sprite instance
            // checking texture width is unreliable because our Harmony patch might intercept Sprite.texture getter
            // for the original sprite too!
            
            bool isWrongSprite = true;
            
            // Try to find the custom sprite in cache
            if (CustomTexturePatch.customSpriteCache.TryGetValue(currentSpriteName, out Sprite cachedCustomSprite))
            {
                // If we have a cached custom sprite, and the current sprite is NOT it, then it's wrong
                if (spriteRenderer.sprite == cachedCustomSprite)
                {
                    isWrongSprite = false;
                }
            }
            
            if (isWrongSprite)
            {
                // Try to get custom sprite (from cache or load it)
                if (cachedCustomSprite != null)
                {
                    // IMPORTANT: Duplicate assignment is intentional and necessary!
                    // Setting the sprite twice ensures it "sticks" in IL2CPP/Unity.
                    // Removing the duplicate breaks texture replacement. Do not remove!
                    spriteRenderer.sprite = cachedCustomSprite;
                     spriteRenderer.sprite = cachedCustomSprite;
                    // Log less frequently to avoid spam if it fights the animator constanty
                    // if (Time.frameCount % 60 == 0) 
                    //    Plugin.Log.LogInfo($"[SavePoint Monitor] Enforcing custom sprite: {currentSpriteName}");
                }
                else
                {
                    // Sprite not in cache, try to load it
                    Sprite loadedSprite = CustomTexturePatch.LoadCustomSprite(currentSpriteName, spriteRenderer.sprite);
                    if (loadedSprite != null)
                    {
                        // IMPORTANT: Duplicate assignment is intentional and necessary!
                        // Setting the sprite twice ensures it "sticks" in IL2CPP/Unity.
                        // Removing the duplicate breaks texture replacement. Do not remove!
                        spriteRenderer.sprite = loadedSprite;
                        spriteRenderer.sprite = loadedSprite;
                        // Plugin.Log.LogInfo($"[SavePoint Monitor] ✓ Loaded and enforced custom sprite: {currentSpriteName}");
                    }
                }
            }
        }
    }
}

/// <summary>
/// Patches for save point sprite replacement
/// Handles preloading and Resources.Load interception for save point animation frames
/// </summary>
public partial class CustomTexturePatch
{
    /// <summary>
    /// Intercept Resources.Load<Sprite>() to replace save point animation frames
    /// The Animator loads sprite frames via Resources.Load, not through sprite property setters
    /// </summary>
    [HarmonyPatch(typeof(Resources))]
    [HarmonyPatch(nameof(Resources.Load))]
    [HarmonyPatch(new Type[] { typeof(string) }, new ArgumentType[] { ArgumentType.Normal })]
    [HarmonyPatch(MethodType.Normal)]
    public static class Resources_Load_Sprite_Patch
    {
        [HarmonyPostfix]
        [HarmonyPatch]
        public static void Postfix(string path, ref UnityEngine.Object __result)
        {
            // Only process if result is a Sprite
            if (__result == null || !(__result is Sprite))
                return;

            Sprite sprite = __result as Sprite;
            string spriteName = sprite.name;

            // DIAGNOSTIC: Log save point sprite loads
            bool isSavePoint = spriteName.Contains("savePoint", StringComparison.OrdinalIgnoreCase);
            if (isSavePoint)
            {
                Plugin.Log.LogInfo($"[SavePoint] Resources.Load<Sprite>() called for: {spriteName}");
                Plugin.Log.LogInfo($"[SavePoint]   Path: {path}");
            }

            // Check if this is a save point animation frame
            if (spriteName.StartsWith("t_obj_savePoint_ball_") && preloadedSavePointSprites.TryGetValue(spriteName, out Sprite customSprite))
            {
                Plugin.Log.LogInfo($"[SavePoint] ✓ Replacing Resources.Load sprite: {spriteName}");
                __result = customSprite;
            }
            else if (isSavePoint)
            {
                Plugin.Log.LogWarning($"[SavePoint] ✗ No preloaded sprite found for: {spriteName}");
            }
        }
    }

    /// <summary>
    /// Preload save point animation frames (t_obj_savePoint_ball_0 through _10)
    /// This ensures all animation frames use the custom texture
    /// </summary>
    private static void PreloadSavePointSprites()
    {
        Plugin.Log.LogInfo("[SavePoint Preload] Starting save point sprite preloading...");
        
        // Check if we have the atlas texture
        string atlasName = "t_obj_savePoint_ball";
        if (!texturePathIndex.ContainsKey(atlasName))
        {
            Plugin.Log.LogWarning($"[SavePoint Preload] Atlas texture '{atlasName}' not found in texture index!");
            return;
        }

        Plugin.Log.LogInfo($"[SavePoint Preload] Found atlas '{atlasName}' in index, loading texture...");
        Texture2D atlasTexture = LoadCustomTexture(atlasName);
        if (atlasTexture == null)
        {
            Plugin.Log.LogError($"[SavePoint Preload] Failed to load atlas texture '{atlasName}'!");
            return;
        }

        if (Plugin.Config.DetailedTextureLog.Value)
        {
            Plugin.Log.LogInfo($"[SavePoint Preload] Atlas loaded: {atlasTexture.width}x{atlasTexture.height}");
        }
        int preloaded = 0;
        
        // Atlas is 400x200 with 8 frames in a 4x2 grid (each frame is 100x100)
        int frameWidth = 100;
        int frameHeight = 100;
        int columns = 4;
        
        // Preload frames 0-10 (11 frames total for the animation)
        // Note: Atlas only has 8 unique frames, so some frames may repeat
        for (int i = 0; i <= 10; i++)
        {
            string frameName = $"t_obj_savePoint_ball_{i}";
            
            // Calculate frame position in the atlas (4 columns, 2 rows)
            // Frames are arranged left-to-right, top-to-bottom
            int frameIndex = i % 8; // Cycle through 8 frames if there are more than 8
            int col = frameIndex % columns;
            int row = frameIndex / columns;
            
            // Calculate the rect for this frame
            // Unity's Rect origin is bottom-left, but texture coords are top-left
            // So we need to flip the Y coordinate
            float x = col * frameWidth;
            float y = atlasTexture.height - (row + 1) * frameHeight; // Flip Y
            
            if (Plugin.Config.DetailedTextureLog.Value)
            {
                Plugin.Log.LogInfo($"[SavePoint Preload] Creating sprite {frameName}: rect=({x},{y},{frameWidth},{frameHeight})");
            }
            
            Sprite sprite = Sprite.Create(
                atlasTexture,
                new Rect(x, y, frameWidth, frameHeight),
                new Vector2(0.5f, 0.5f), // Center pivot
                100f, // Default ppu for save point
                0,
                SpriteMeshType.FullRect
            );

            if (sprite == null)
            {
                Plugin.Log.LogError($"[SavePoint Preload] Sprite.Create returned NULL for {frameName}!");
            }
            else if (Plugin.Config.DetailedTextureLog.Value)
            {
                Plugin.Log.LogInfo($"[SavePoint Preload] Created sprite {frameName} successfully");
            }

            UnityEngine.Object.DontDestroyOnLoad(sprite);
            preloadedSavePointSprites[frameName] = sprite;
            preloaded++;
        }
        
        // Don't destroy the atlas texture
        UnityEngine.Object.DontDestroyOnLoad(atlasTexture);

        if (preloaded > 0)
        {
            Plugin.Log.LogInfo($"Preloaded {preloaded} save point animation frame(s) for instant replacement");
        }
    }

    /// <summary>
    /// Intercept GameObject.SetActive to replace save point sprites when bgManagerHD activates
    /// This handles the initial sprite replacement when save point objects are first activated
    /// </summary>
    [HarmonyPatch(typeof(GameObject), nameof(GameObject.SetActive))]
    [HarmonyPostfix]
    public static void GameObject_SetActive_SavePoint_Postfix(GameObject __instance, bool value)
    {
        // Only scan when activating
        if (!value || !Plugin.Config.EnableCustomTextures.Value)
            return;

        // Check if this is a bgManagerHD object (save points are children of this)
        string objectPath = GetGameObjectPath(__instance);
        if (!objectPath.Contains("bgManagerHD"))
            return;

        // Scan for save point sprites in this object's children
        var spriteRenderers = __instance.GetComponentsInChildren<SpriteRenderer>(true);
        foreach (var sr in spriteRenderers)
        {
            if (sr.sprite != null)
            {
                string spriteName = sr.sprite.name;
                
                // Only process save point sprites
                bool isSavePoint = spriteName.Contains("savePoint", StringComparison.OrdinalIgnoreCase);
                if (!isSavePoint)
                    continue;

                Plugin.Log.LogInfo($"[SavePoint GameObject] Found sprite: {spriteName} in {objectPath}");
                
                Sprite customSprite = LoadCustomSprite(spriteName, sr.sprite);
                if (customSprite != null)
                {
                    sr.sprite = customSprite;
                    Plugin.Log.LogInfo($"[SavePoint GameObject] ✓ SET custom sprite: {spriteName}");
                    
                    // Add monitor component for animated save point ball
                    if (spriteName.StartsWith("t_obj_savePoint_ball_"))
                    {
                        try
                        {
                            if (sr.GetComponent<SavePointSpriteMonitor>() == null)
                            {
                                sr.gameObject.AddComponent<SavePointSpriteMonitor>();
                                Plugin.Log.LogInfo($"[SavePoint Monitor] Added monitor to: {sr.gameObject.name}");
                            }
                        }
                        catch (System.Exception ex)
                        {
                            if (!ex.Message.Contains("already has"))
                            {
                                Plugin.Log.LogWarning($"[SavePoint Monitor] Note: {ex.Message}");
                            }
                        }
                    }
                }
                else
                {
                    Plugin.Log.LogWarning($"[SavePoint GameObject] ✗ LoadCustomSprite returned null for: {spriteName}");
                }
            }
        }
    }
}

