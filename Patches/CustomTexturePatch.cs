using HarmonyLib;
using UnityEngine;
using UnityEngine.UI; // UI components (Image, RawImage)
using UnityEngine.U2D; // SpriteAtlas support
using UnityEngine.SceneManagement; // Scene loading
using UnityEngine.AddressableAssets; // Addressables support
using UnityEngine.ResourceManagement.AsyncOperations; // AsyncOperationHandle
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace PKextended.Patches;

/// <summary>
/// Replaces game textures/sprites with custom PNG files from a folder
/// </summary>
public class CustomTexturePatch
{
    private static Dictionary<string, Sprite> customSpriteCache = new Dictionary<string, Sprite>();
    private static Dictionary<string, Texture2D> customTextureCache = new Dictionary<string, Texture2D>();
    private static Dictionary<string, string> texturePathIndex = new Dictionary<string, string>(); // Maps texture name -> full file path
    private static HashSet<string> loggedTextures = new HashSet<string>(); // Track logged textures to prevent duplicates
    private static string customTexturesPath;

    /// <summary>
    /// Intercept SpriteRenderer.sprite setter to replace with custom textures
    /// </summary>
    [HarmonyPatch(typeof(SpriteRenderer), nameof(SpriteRenderer.sprite), MethodType.Setter)]
    [HarmonyPrefix]
    public static void SpriteRenderer_set_sprite_Prefix(SpriteRenderer __instance, ref Sprite value)
    {
        if (value == null)
            return;

        string originalName = value.name;
        
        // Log replaceable textures if enabled (only once per texture)
        if (Plugin.Config.LogReplaceableTextures.Value && !loggedTextures.Contains(originalName))
        {
            loggedTextures.Add(originalName);
            Plugin.Log.LogInfo($"[Replaceable Sprite] {originalName}");
        }
        
        // Try to load custom sprite replacement
        Sprite customSprite = LoadCustomSprite(originalName, value);
        if (customSprite != null)
        {
            Plugin.Log.LogInfo($"Replaced sprite: {originalName}");
            value = customSprite;
        }
    }

    /// <summary>
    /// Intercept SpriteAtlas.GetSprite to catch sprites loaded from atlases
    /// This catches background sprites and other atlas-based sprites
    /// </summary>
    [HarmonyPatch(typeof(SpriteAtlas), nameof(SpriteAtlas.GetSprite))]
    [HarmonyPostfix]
    public static void SpriteAtlas_GetSprite_Postfix(SpriteAtlas __instance, string name, ref Sprite __result)
    {
        if (__result == null)
            return;

        string spriteName = __result.name;
        
        // Remove (Clone) suffix if present to prevent duplicate logging
        if (spriteName.EndsWith("(Clone)"))
            spriteName = spriteName.Substring(0, spriteName.Length - 7);

        // Log if enabled and not already logged
        if (Plugin.Config.LogReplaceableTextures.Value && !loggedTextures.Contains(spriteName))
        {
            loggedTextures.Add(spriteName);
            Plugin.Log.LogInfo($"[Replaceable Sprite - Atlas] {spriteName}");
        }

        // Try to replace with custom sprite
        if (Plugin.Config.EnableCustomTextures.Value)
        {
            Sprite customSprite = LoadCustomSprite(spriteName, __result);
            if (customSprite != null)
            {
                __result = customSprite;
                Plugin.Log.LogInfo($"Replaced atlas sprite: {spriteName}");
            }
        }
    }

    /// <summary>
    /// Intercept GameObject.SetActive to catch sprites when objects are activated
    /// This catches sprites in objects that are instantiated/activated after scene load
    /// </summary>
    [HarmonyPatch(typeof(GameObject), nameof(GameObject.SetActive))]
    [HarmonyPostfix]
    public static void GameObject_SetActive_Postfix(GameObject __instance, bool value)
    {
        // Only scan when activating (not deactivating)
        if (!value || !Plugin.Config.EnableCustomTextures.Value && !Plugin.Config.LogReplaceableTextures.Value)
            return;

        // Scan all SpriteRenderers in this GameObject and its children
        var spriteRenderers = __instance.GetComponentsInChildren<SpriteRenderer>(true);
        foreach (var sr in spriteRenderers)
        {
            if (sr.sprite != null)
            {
                string spriteName = sr.sprite.name;

                // Log if not already logged
                if (Plugin.Config.LogReplaceableTextures.Value && !loggedTextures.Contains(spriteName))
                {
                    loggedTextures.Add(spriteName);
                    Plugin.Log.LogInfo($"[Replaceable Sprite - Activated] {spriteName}");
                }

                // Try to replace
                if (Plugin.Config.EnableCustomTextures.Value)
                {
                    Sprite customSprite = LoadCustomSprite(spriteName, sr.sprite);
                    if (customSprite != null)
                    {
                        sr.sprite = customSprite;
                        Plugin.Log.LogInfo($"Replaced sprite on activation: {spriteName}");
                    }
                }
            }
        }
    }


    /// <summary>
    /// Intercept Material.mainTexture setter to replace textures
    /// </summary>
    [HarmonyPatch(typeof(Material), nameof(Material.mainTexture), MethodType.Setter)]
    [HarmonyPrefix]
    public static void Material_set_mainTexture_Prefix(Material __instance, ref Texture value)
    {
        if (value == null)
            return;

        string originalName = value.name;
        
        // Log replaceable textures if enabled (only once per texture)
        if (Plugin.Config.LogReplaceableTextures.Value && !loggedTextures.Contains(originalName))
        {
            loggedTextures.Add(originalName);
            Plugin.Log.LogInfo($"[Replaceable Texture] {originalName}");
        }
        
        // Try to load custom texture replacement
        Texture2D customTexture = LoadCustomTexture(originalName);
        if (customTexture != null)
        {
            Plugin.Log.LogInfo($"Replaced texture: {originalName}");
            value = customTexture;
        }
    }

    /// <summary>
    /// Intercept Image.sprite setter to replace UI sprites
    /// </summary>
    [HarmonyPatch(typeof(Image), nameof(Image.sprite), MethodType.Setter)]
    [HarmonyPrefix]
    public static void Image_set_sprite_Prefix(Image __instance, ref Sprite value)
    {
        if (value == null)
            return;

        string originalName = value.name;
        
        // Log replaceable textures if enabled (only once per texture)
        if (Plugin.Config.LogReplaceableTextures.Value && !loggedTextures.Contains(originalName))
        {
            loggedTextures.Add(originalName);
            if (Plugin.Config.LogTexturePaths.Value)
            {
                string gameObjectPath = GetGameObjectPath(__instance.gameObject);
                Plugin.Log.LogInfo($"[Replaceable UI Sprite] {originalName}\n  Path: {gameObjectPath}");
            }
            else
            {
                Plugin.Log.LogInfo($"[Replaceable UI Sprite] {originalName}");
            }
        }
        
        // Try to load custom sprite replacement
        Sprite customSprite = LoadCustomSprite(originalName, value);
        if (customSprite != null)
        {
            Plugin.Log.LogInfo($"Replaced UI sprite: {originalName}");
            value = customSprite;
        }
    }


    /// <summary>
    /// Intercept Image.overrideSprite setter (this is what actually sets the sprite)
    /// </summary>
    [HarmonyPatch(typeof(Image), nameof(Image.overrideSprite), MethodType.Setter)]
    [HarmonyPrefix]
    public static void Image_set_overrideSprite_Prefix(Image __instance, ref Sprite value)
    {
        if (value == null)
            return;

        string originalName = value.name;
        
        // Log replaceable textures if enabled (only once per texture)
        if (Plugin.Config.LogReplaceableTextures.Value && !loggedTextures.Contains(originalName))
        {
            loggedTextures.Add(originalName);
            if (Plugin.Config.LogTexturePaths.Value)
            {
                string gameObjectPath = GetGameObjectPath(__instance.gameObject);
                Plugin.Log.LogInfo($"[Replaceable UI Override Sprite] {originalName}\n  Path: {gameObjectPath}");
            }
            else
            {
                Plugin.Log.LogInfo($"[Replaceable UI Override Sprite] {originalName}");
            }
        }
        
        // Try to load custom sprite replacement
        Sprite customSprite = LoadCustomSprite(originalName, value);
        if (customSprite != null)
        {
            Plugin.Log.LogInfo($"Replaced UI override sprite: {originalName}");
            value = customSprite;
        }
    }

    /// <summary>
    /// Intercept RawImage.texture setter to replace UI textures
    /// </summary>
    [HarmonyPatch(typeof(RawImage), nameof(RawImage.texture), MethodType.Setter)]
    [HarmonyPrefix]
    public static void RawImage_set_texture_Prefix(RawImage __instance, ref Texture value)
    {
        if (value == null)
            return;

        string originalName = value.name;
        
        // Log replaceable textures if enabled (only once per texture)
        if (Plugin.Config.LogReplaceableTextures.Value && !loggedTextures.Contains(originalName))
        {
            loggedTextures.Add(originalName);
            Plugin.Log.LogInfo($"[Replaceable UI Texture] {originalName}");
        }
        
        // Try to load custom texture replacement
        Texture2D customTexture = LoadCustomTexture(originalName);
        if (customTexture != null)
        {
            Plugin.Log.LogInfo($"Replaced UI texture: {originalName}");
            value = customTexture;
        }
    }

    /// <summary>
    /// Intercept Graphic.mainTexture getter to log UI textures (base class for Image, RawImage, Text, etc.)
    /// This catches textures on GameObjects with RectTransform and CanvasRenderer
    /// </summary>
    [HarmonyPatch(typeof(Graphic), nameof(Graphic.mainTexture), MethodType.Getter)]
    [HarmonyPostfix]
    public static void Graphic_get_mainTexture_Postfix(Graphic __instance, Texture __result)
    {
        if (__result == null)
            return;

        string originalName = __result.name;
        
        // Log replaceable textures if enabled (only once per texture)
        if (Plugin.Config.LogReplaceableTextures.Value && !loggedTextures.Contains(originalName))
        {
            loggedTextures.Add(originalName);
            Plugin.Log.LogInfo($"[Replaceable Graphic Texture] {originalName} (Component: {__instance.GetType().Name})");
        }
    }

    /// <summary>
    /// Intercept Image.OnEnable to catch sprites that were set before patches loaded
    /// This runs when Image components become active, allowing us to detect and replace
    /// sprites that were assigned during Awake/Start or scene initialization
    /// </summary>
    [HarmonyPatch(typeof(Image), "OnEnable")]
    [HarmonyPostfix]
    public static void Image_OnEnable_Postfix(Image __instance)
    {
        if (!Plugin.Config.EnableCustomTextures.Value)
            return;

        // Check both sprite and overrideSprite
        Sprite activeSprite = __instance.overrideSprite ?? __instance.sprite;
        
        if (activeSprite != null)
        {
            string spriteName = activeSprite.name;
            
            // Log if enabled and not already logged
            if (Plugin.Config.LogReplaceableTextures.Value && !loggedTextures.Contains(spriteName))
            {
                loggedTextures.Add(spriteName);
                if (Plugin.Config.LogTexturePaths.Value)
                {
                    string gameObjectPath = GetGameObjectPath(__instance.gameObject);
                    Plugin.Log.LogInfo($"[Replaceable UI Sprite - OnEnable] {spriteName}\n  Path: {gameObjectPath}");
                }
                else
                {
                    Plugin.Log.LogInfo($"[Replaceable UI Sprite - OnEnable] {spriteName}");
                }
            }
            
            // Try to load custom sprite replacement
            Sprite customSprite = LoadCustomSprite(spriteName, activeSprite);
            if (customSprite != null)
            {
                __instance.sprite = customSprite;
                __instance.overrideSprite = customSprite;
                Plugin.Log.LogInfo($"Replaced UI sprite on enable: {spriteName}");
            }
        }
    }

    /// <summary>
    /// Get full hierarchy path of a GameObject for debugging
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
    /// Load a custom sprite from PNG file
    /// </summary>
    private static Sprite LoadCustomSprite(string spriteName, Sprite originalSprite)
    {
        // NO CACHING - Always create new sprite with fresh texture

        // Try to load texture from file
        Texture2D texture = LoadCustomTexture(spriteName);
        if (texture == null)
            return null;

        // Preserve original sprite properties if available
        Vector2 pivot = originalSprite != null ? originalSprite.pivot / originalSprite.rect.size : new Vector2(0.5f, 0.5f);
        float pixelsPerUnit = originalSprite != null ? originalSprite.pixelsPerUnit : 100f;
        Vector4 border = originalSprite != null ? originalSprite.border : Vector4.zero;

        // Auto-scale pixelsPerUnit to maintain original display size (like Special K)
        // This allows higher resolution textures to display at the same size as originals
        if (originalSprite != null)
        {
            float originalWidth = originalSprite.rect.width;
            float originalHeight = originalSprite.rect.height;
            float customWidth = texture.width;
            float customHeight = texture.height;

            // Calculate scale ratio (use width as primary dimension)
            float scaleRatio = customWidth / originalWidth;
            
            // Adjust pixelsPerUnit proportionally
            // Higher resolution = higher pixelsPerUnit to maintain same display size
            pixelsPerUnit = originalSprite.pixelsPerUnit * scaleRatio;
            
            Plugin.Log.LogInfo($"Texture scaling: {spriteName}");
            Plugin.Log.LogInfo($"  Original: {originalWidth}x{originalHeight} @ {originalSprite.pixelsPerUnit} ppu");
            Plugin.Log.LogInfo($"  Custom: {customWidth}x{customHeight} @ {pixelsPerUnit:F2} ppu (scale: {scaleRatio:F2}x)");
        }

        // Create sprite from texture with adjusted properties
        Sprite sprite = Sprite.Create(
            texture,
            new Rect(0, 0, texture.width, texture.height),
            pivot,
            pixelsPerUnit,
            0, // extrude
            SpriteMeshType.FullRect,
            border
        );

        // Prevent Unity from destroying the sprite
        Object.DontDestroyOnLoad(sprite);
        Object.DontDestroyOnLoad(texture);

        // NO CACHING - sprite will be recreated next time
        Plugin.Log.LogInfo($"Created sprite: {spriteName} (pivot: {pivot}, ppu: {pixelsPerUnit:F2})");
        
        return sprite;
    }

    /// <summary>
    /// Load a custom texture from image file (supports PNG, JPG, TGA)
    /// </summary>
    private static Texture2D LoadCustomTexture(string textureName)
    {
        // NO CACHING - Always reload from disk
        // Look up full path from index (supports subfolders)
        if (!texturePathIndex.TryGetValue(textureName, out string filePath))
            return null;

        try
        {
            // Load image file
            byte[] fileData = File.ReadAllBytes(filePath);
            
            // Create texture with mipmaps enabled for better quality
            // IMPORTANT: Must be readable for IL2CPP
            Texture2D texture = new Texture2D(2, 2, TextureFormat.RGBA32, true);
            
            // Use ImageConversion static class (IL2CPP compatible)
            // Supports PNG, JPG, TGA formats automatically
            if (!UnityEngine.ImageConversion.LoadImage(texture, fileData))
            {
                Plugin.Log.LogError($"Failed to load image: {filePath}");
                Object.Destroy(texture);
                return null;
            }

            // Apply texture settings for quality
            texture.filterMode = FilterMode.Bilinear;
            texture.wrapMode = TextureWrapMode.Clamp;
            texture.anisoLevel = 4; // Better quality at angles
            
            // CRITICAL: Apply with mipmaps enabled and keep readable
            texture.Apply(true, false); // updateMipmaps=true, makeNoLongerReadable=false
            
            // Prevent Unity from unloading the texture
            Object.DontDestroyOnLoad(texture);

            // NO CACHING - texture will be reloaded next time
            Plugin.Log.LogInfo($"Loaded custom texture: {textureName} ({texture.width}x{texture.height}) from {Path.GetExtension(filePath)}");
            
            return texture;
        }
        catch (System.Exception ex)
        {
            Plugin.Log.LogError($"Error loading texture {textureName}: {ex.Message}");
            return null;
        }
    }

    /// <summary>
    /// Build index of all texture files (supports subfolders)
    /// </summary>
    private static void BuildTextureIndex()
    {
        texturePathIndex.Clear();
        
        if (!Directory.Exists(customTexturesPath))
            return;

        // Supported image extensions
        string[] extensions = { "*.png", "*.jpg", "*.jpeg", "*.tga" };
        
        // Recursively find all image files in all subdirectories
        foreach (string extension in extensions)
        {
            string[] files = Directory.GetFiles(customTexturesPath, extension, SearchOption.AllDirectories);
            
            foreach (string filePath in files)
            {
                string textureName = Path.GetFileNameWithoutExtension(filePath);
                
                // Check for duplicate texture names
                if (texturePathIndex.ContainsKey(textureName))
                {
                    string existingPath = texturePathIndex[textureName];
                    string existingRelative = existingPath.Replace(customTexturesPath, "").TrimStart('\\', '/');
                    string newRelative = filePath.Replace(customTexturesPath, "").TrimStart('\\', '/');
                    
                    Plugin.Log.LogWarning($"Duplicate texture name '{textureName}':");
                    Plugin.Log.LogWarning($"  Using: {existingRelative}");
                    Plugin.Log.LogWarning($"  Ignoring: {newRelative}");
                }
                else
                {
                    texturePathIndex[textureName] = filePath;
                }
            }
        }
    }

    public static void Initialize()
    {
        // Set custom textures folder path
        // BepInEx/plugins/PKextended/Textures/
        customTexturesPath = Path.Combine(
            BepInEx.Paths.PluginPath,
            "PKextended",
            "Textures"
        );

        // Create directory if it doesn't exist
        if (!Directory.Exists(customTexturesPath))
        {
            Directory.CreateDirectory(customTexturesPath);
            Plugin.Log.LogInfo($"Created custom textures directory: {customTexturesPath}");
        }
        else
        {
            Plugin.Log.LogInfo($"Custom textures directory: {customTexturesPath}");
        }

        // Build texture index (supports subfolders)
        BuildTextureIndex();
        
        // Log indexed textures
        if (texturePathIndex.Count > 0)
        {
            Plugin.Log.LogInfo($"Indexed {texturePathIndex.Count} custom texture(s):");
            
            // Group by directory for cleaner output
            var groupedByDir = texturePathIndex
                .GroupBy(kvp => Path.GetDirectoryName(kvp.Value))
                .OrderBy(g => g.Key);
            
            foreach (var dirGroup in groupedByDir)
            {
                string relativePath = dirGroup.Key.Replace(customTexturesPath, "").TrimStart('\\', '/');
                string displayPath = string.IsNullOrEmpty(relativePath) ? "[Root]" : relativePath;
                
                Plugin.Log.LogInfo($"  {displayPath}/");
                foreach (var texture in dirGroup.OrderBy(kvp => kvp.Key))
                {
                    Plugin.Log.LogInfo($"    - {texture.Key}{Path.GetExtension(texture.Value)}");
                }
            }
        }
        else
        {
            Plugin.Log.LogInfo("No custom textures found. Place PNG/JPG/TGA files in the Textures folder.");
        }

        // Register scene loaded callback to scan for sprites (IL2CPP compatible)
        SceneManager.sceneLoaded += (System.Action<Scene, LoadSceneMode>)OnSceneLoaded;
    }

    /// <summary>
    /// Called when a scene is loaded - scans all sprites in the scene and replaces them
    /// </summary>
    private static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Plugin.Log.LogInfo($"Scanning scene '{scene.name}' for textures...");

        int replacedCount = 0;

        // Scan all SpriteRenderers
        var spriteRenderers = Object.FindObjectsOfType<SpriteRenderer>();
        foreach (var sr in spriteRenderers)
        {
            if (sr.sprite != null)
            {
                string spriteName = sr.sprite.name;
                
                // Log if enabled and not already logged
                if (Plugin.Config.LogReplaceableTextures.Value && !loggedTextures.Contains(spriteName))
                {
                    loggedTextures.Add(spriteName);
                    Plugin.Log.LogInfo($"[Replaceable Sprite - Scene] {spriteName}");
                }

                // Try to replace with custom sprite if enabled
                if (Plugin.Config.EnableCustomTextures.Value)
                {
                    Sprite customSprite = LoadCustomSprite(spriteName, sr.sprite);
                    if (customSprite != null)
                    {
                        sr.sprite = customSprite;
                        Plugin.Log.LogInfo($"Replaced sprite in scene: {spriteName}");
                        replacedCount++;
                    }
                }
            }
        }

        // Scan all UI Images
        var images = Object.FindObjectsOfType<Image>();
        Plugin.Log.LogInfo($"Found {images.Length} UI Image components in scene");
        
        foreach (var img in images)
        {
            string gameObjectPath = GetGameObjectPath(img.gameObject);
            
            // Check both sprite and overrideSprite
            Sprite activeSprite = img.overrideSprite ?? img.sprite;
            
            if (activeSprite != null)
            {
                string spriteName = activeSprite.name;
                
                // Log if enabled and not already logged
                if (Plugin.Config.LogReplaceableTextures.Value && !loggedTextures.Contains(spriteName))
                {
                    loggedTextures.Add(spriteName);
                    if (Plugin.Config.LogTexturePaths.Value)
                    {
                        Plugin.Log.LogInfo($"[Replaceable UI Sprite - Scene] {spriteName}\n  Path: {gameObjectPath}");
                    }
                    else
                    {
                        Plugin.Log.LogInfo($"[Replaceable UI Sprite - Scene] {spriteName}");
                    }
                }

                // Try to replace with custom sprite if enabled
                if (Plugin.Config.EnableCustomTextures.Value)
                {
                    Sprite customSprite = LoadCustomSprite(spriteName, activeSprite);
                    if (customSprite != null)
                    {
                        // Set both to ensure replacement works
                        img.sprite = customSprite;
                        img.overrideSprite = customSprite;
                        Plugin.Log.LogInfo($"Replaced UI sprite in scene: {spriteName}");
                        replacedCount++;
                    }
                }
            }
            else if (Plugin.Config.LogReplaceableTextures.Value && Plugin.Config.LogTexturePaths.Value)
            {
                // Log Image components with no sprite (might use material directly)
                Plugin.Log.LogInfo($"[UI Image - No Sprite]\n  Path: {gameObjectPath}");
            }
        }

        // Scan all RawImages
        var rawImages = Object.FindObjectsOfType<RawImage>();
        foreach (var raw in rawImages)
        {
            if (raw.texture != null)
            {
                string textureName = raw.texture.name;
                
                // Log if enabled and not already logged
                if (Plugin.Config.LogReplaceableTextures.Value && !loggedTextures.Contains(textureName))
                {
                    loggedTextures.Add(textureName);
                    Plugin.Log.LogInfo($"[Replaceable UI Texture - Scene] {textureName}");
                }

                // Try to replace with custom texture if enabled
                if (Plugin.Config.EnableCustomTextures.Value)
                {
                    Texture2D customTexture = LoadCustomTexture(textureName);
                    if (customTexture != null)
                    {
                        raw.texture = customTexture;
                        Plugin.Log.LogInfo($"Replaced UI texture in scene: {textureName}");
                        replacedCount++;
                    }
                }
            }
        }

        // Force replace specific background sprites that aren't caught by automatic detection
        if (Plugin.Config.EnableCustomTextures.Value)
        {
            // Base location codes - will try with common suffixes (_00, _01, _02)
            string[] baseLocations = new string[]
            {
                "bg", // Generic background
                "va06",
                "vb03", "vb04", "vb05", "vb06", "vb07", "vb09", "vb10", "vb11", "vb12",
                "vc01", "vc03", "vc04", "vc06", "vc18", "vc21",
                "vd01", "vd02", "vd03", "vd05", "vd06", "vd07", "vd08", "vd16", "vd17", "vd19",
                "ve01", "ve02", "ve03", "ve04", "ve05", "ve07", "ve10", "ve14",
                "vf01", "vf02", "vf03", "vf04", "vf05",
                "vg01", "vg02", "vg05", "vg08", "vg13", "vg15", "vg16", "vg17",
                "vh01", "vh02", "vh03", "vh04", "vh06", "vh10", "vh11",
                "vi01", "vi05", "vi12",
                "vk01", "vk06", "vk07", "vk08", "vk10", "vk20", "vk22", "vk29", "vk32"
            };

            // Common suffixes to try for each location
            string[] suffixes = new string[] { "", "_00", "_01", "_02", "_03", "_04", "_05", "_06", "_07", "_08" };

            foreach (var baseLocation in baseLocations)
            {
                foreach (var suffix in suffixes)
                {
                    string path = $"bgManagerHD/{baseLocation}{suffix}";
                    var bgManager = GameObject.Find(path);
                    
                    if (bgManager != null)
                    {
                        // Get all child SpriteRenderers
                        var bgSprites = bgManager.GetComponentsInChildren<SpriteRenderer>(true);
                        foreach (var sr in bgSprites)
                        {
                            if (sr.sprite != null)
                            {
                                string spriteName = sr.sprite.name;
                                
                                // Log if not already logged
                                if (Plugin.Config.LogReplaceableTextures.Value && !loggedTextures.Contains(spriteName))
                                {
                                    loggedTextures.Add(spriteName);
                                    Plugin.Log.LogInfo($"[Replaceable Sprite - Forced] {spriteName} (from {path})");
                                }
                                
                                // Try to replace
                                Sprite customSprite = LoadCustomSprite(spriteName, sr.sprite);
                                if (customSprite != null)
                                {
                                    sr.sprite = customSprite;
                                    Plugin.Log.LogInfo($"Force replaced background sprite: {spriteName} (from {path})");
                                    replacedCount++;
                                }
                            }
                        }
                    }
                }
            }

            // Scan bath backgrounds (bath_1 to bath_5)
            var bathBG = GameObject.Find("AppRoot/BathBG/bg");
            if (bathBG != null)
            {
                var bathSprites = bathBG.GetComponentsInChildren<SpriteRenderer>(true);
                foreach (var sr in bathSprites)
                {
                    if (sr.sprite != null)
                    {
                        string spriteName = sr.sprite.name;
                        
                        // Log if not already logged
                        if (Plugin.Config.LogReplaceableTextures.Value && !loggedTextures.Contains(spriteName))
                        {
                            loggedTextures.Add(spriteName);
                            Plugin.Log.LogInfo($"[Replaceable Sprite - Forced] {spriteName} (from AppRoot/BathBG/bg)");
                        }
                        
                        // Try to replace
                        Sprite customSprite = LoadCustomSprite(spriteName, sr.sprite);
                        if (customSprite != null)
                        {
                            sr.sprite = customSprite;
                            Plugin.Log.LogInfo($"Force replaced bath sprite: {spriteName} (from AppRoot/BathBG/bg)");
                            replacedCount++;
                        }
                    }
                }
            }
        }

        if (Plugin.Config.EnableCustomTextures.Value && replacedCount > 0)
        {
            Plugin.Log.LogInfo($"Scene scan complete. Replaced {replacedCount} texture(s).");
        }
        else
        {
            Plugin.Log.LogInfo($"Scene scan complete.");
        }
    }

    /// <summary>
    /// Clear all cached textures (useful for reloading)
    /// </summary>
    public static void ClearCache()
    {
        customSpriteCache.Clear();
        customTextureCache.Clear();
        Plugin.Log.LogInfo("Custom texture cache cleared");
    }
}
