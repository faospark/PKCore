using HarmonyLib;
using UnityEngine;
using UnityEngine.U2D;
using System;

namespace PKCore.Patches;

/// <summary>
/// Patches for save point sprite replacement
/// Handles preloading and Resources.Load interception for save point animation frames
/// </summary>
public partial class CustomTexturePatch
{
    private static bool _loggedSavePointColor = false;
    private static string _activeSavePointColorVariant;

    private static readonly string[] SavePointColorVariants =
    {
        "black", "blue", "cyan", "green", "navy", "pink", "purple", "red", "white", "yellow"
    };

    /// <summary>
    /// Returns the currently active save point color variant.
    /// In Random mode this value is selected per room/scene entry.
    /// </summary>
    internal static string GetActiveSavePointColorVariant()
    {
        string configured = Plugin.Config.SavePointColor.Value?.Trim();
        if (string.IsNullOrEmpty(configured))
            return "default";

        if (configured.Equals("random", StringComparison.OrdinalIgnoreCase))
        {
            if (string.IsNullOrEmpty(_activeSavePointColorVariant))
                SelectRandomSavePointColor();

            return _activeSavePointColorVariant;
        }

        if (configured.Equals("dark", StringComparison.OrdinalIgnoreCase))
            return "black";

        return configured.ToLowerInvariant();
    }

    /// <summary>
    /// Refresh save point color state when entering a new room/scene.
    /// </summary>
    internal static void RefreshSavePointColorForRoomEntry(string roomName)
    {
        if (!Plugin.Config.SavePointColor.Value.Equals("random", StringComparison.OrdinalIgnoreCase))
            return;

        SelectRandomSavePointColor();
        ClearSavePointVariantCaches();

        if (Plugin.Config.DetailedLogs.Value)
        {
            Plugin.Log.LogInfo($"[SavePoint Color] Room '{roomName}' selected: {_activeSavePointColorVariant}");
        }
    }

    /// <summary>
    /// Pick a random save point color variant.
    /// Tries to avoid repeating the previous color when possible.
    /// </summary>
    private static void SelectRandomSavePointColor()
    {
        string previous = _activeSavePointColorVariant;
        string next = SavePointColorVariants[UnityEngine.Random.Range(0, SavePointColorVariants.Length)];

        if (SavePointColorVariants.Length > 1 &&
            !string.IsNullOrEmpty(previous) &&
            next.Equals(previous, StringComparison.OrdinalIgnoreCase))
        {
            next = SavePointColorVariants[UnityEngine.Random.Range(0, SavePointColorVariants.Length)];
        }

        _activeSavePointColorVariant = next;
        _loggedSavePointColor = false;
    }

    /// <summary>
    /// Clears only save point-related texture/sprite caches so Random mode can swap variants.
    /// </summary>
    private static void ClearSavePointVariantCaches()
    {
        var textureKeys = new System.Collections.Generic.List<string>();
        foreach (var key in customTextureCache.Keys)
        {
            if (key.StartsWith("t_obj_savePoint_ball", StringComparison.OrdinalIgnoreCase))
                textureKeys.Add(key);
        }

        foreach (var key in textureKeys)
        {
            if (customTextureCache.TryGetValue(key, out Texture2D tex) && tex)
                UnityEngine.Object.Destroy(tex);

            customTextureCache.Remove(key);
        }

        var spriteKeys = new System.Collections.Generic.List<string>();
        foreach (var key in customSpriteCache.Keys)
        {
            if (key.StartsWith("t_obj_savePoint_ball", StringComparison.OrdinalIgnoreCase))
                spriteKeys.Add(key);
        }

        foreach (var key in spriteKeys)
        {
            if (customSpriteCache.TryGetValue(key, out Sprite sprite) && sprite)
                UnityEngine.Object.Destroy(sprite);

            customSpriteCache.Remove(key);
        }

        preloadedSavePointSprites.Clear();
    }

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

        // Check if this is a bgManagerHD object OR if it's a save point itself
        string objectPath = GetGameObjectPath(__instance);
        bool isBgManager = objectPath.Contains("bgManagerHD") || objectPath.Contains("MapBackGround");
        bool isSavePointObj = __instance.name.Contains("savePoint", StringComparison.OrdinalIgnoreCase);

        if (!isBgManager && !isSavePointObj)
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

                if (Plugin.Config.DetailedLogs.Value)
                {
                    Plugin.Log.LogInfo($"[SavePoint GameObject] Found sprite: {spriteName} in {objectPath}");
                }

                Sprite customSprite = LoadCustomSprite(spriteName, sr.sprite);
                if (customSprite != null)
                {
                    sr.sprite = customSprite;
                    if (Plugin.Config.DetailedLogs.Value)
                    {
                        Plugin.Log.LogInfo($"[SavePoint GameObject] ✓ SET custom sprite: {spriteName}");
                    }

                    // Add monitor component for animated save point ball
                    if (spriteName.StartsWith("t_obj_savePoint_ball_"))
                    {
                        try
                        {
                            if (sr.GetComponent<SavePointSpriteMonitor>() == null)
                            {
                                sr.gameObject.AddComponent<SavePointSpriteMonitor>();
                                if (Plugin.Config.DetailedLogs.Value)
                                {
                                    Plugin.Log.LogInfo($"[SavePoint Monitor] Added monitor to: {sr.gameObject.name}");
                                }
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

    /// <summary>
    /// Try to load a save point sprite (returns null if not a save point sprite or atlas not found)
    /// </summary>
    private static Sprite TryLoadSavePointSprite(string spriteName, Sprite originalSprite)
    {
        // Only process save point sprites
        if (!spriteName.StartsWith("t_obj_savePoint_ball_"))
            return null;

        // Check if we have the atlas texture (including selected color variant)
        string atlasLookupName = TextureOptions.GetTextureNameWithVariant("t_obj_savePoint_ball");
        if (!texturePathIndex.ContainsKey(atlasLookupName))
        {
            Plugin.Log.LogWarning($"[SavePoint] Atlas texture '{atlasLookupName}' not found in texture index");
            return null;
        }

        Sprite sprite = CreateSavePointSpriteFromAtlas(spriteName, originalSprite);
        if (sprite != null)
        {
            customSpriteCache[spriteName] = sprite;
        }
        return sprite;
    }

    /// <summary>
    /// Create a save point sprite from the atlas texture for a specific frame
    /// </summary>
    private static Sprite CreateSavePointSpriteFromAtlas(string spriteName, Sprite originalSprite)
    {
        // Extract frame number from sprite name (e.g., "t_obj_savePoint_ball_0" -> 0)
        string frameNumStr = spriteName.Substring("t_obj_savePoint_ball_".Length);
        if (!int.TryParse(frameNumStr, out int frameNum))
            return null;

        // Removed individual frame logging
        // Load the atlas texture
        Texture2D atlasTexture = LoadCustomTexture("t_obj_savePoint_ball");
        if (atlasTexture == null)
        {
            Plugin.Log.LogError($"[SavePoint] Failed to load atlas texture: t_obj_savePoint_ball");
            return null;
        }

        // Atlas is 400x200 with 8 frames in a 4x2 grid (each frame is 100x100)
        int frameWidth = 100;
        int frameHeight = 100;
        int columns = 4;

        // Calculate frame position (cycle through 8 frames if more than 8)
        int frameIndex = frameNum % 8;
        int col = frameIndex % columns;
        int row = frameIndex / columns;

        // Calculate rect (flip Y for Unity's bottom-left origin)
        float x = col * frameWidth;
        float y = atlasTexture.height - (row + 1) * frameHeight;

        // Preserve original sprite properties if available
        Vector2 customPivot = originalSprite != null ? originalSprite.pivot / originalSprite.rect.size : new Vector2(0.5f, 0.5f);
        float customPPU = originalSprite != null ? originalSprite.pixelsPerUnit : 100f;

        // Auto-scale pixelsPerUnit to maintain original display size
        if (originalSprite != null)
        {
            float scaleRatio = frameWidth / originalSprite.rect.width;
            customPPU = originalSprite.pixelsPerUnit * scaleRatio;
        }

        // Removed individual sprite creation logging

        Sprite customSprite = Sprite.Create(
            atlasTexture,
            new Rect(x, y, frameWidth, frameHeight),
            customPivot,
            customPPU,
            0,
            SpriteMeshType.FullRect
        );

        if (customSprite != null)
        {
            UnityEngine.Object.DontDestroyOnLoad(customSprite);
            UnityEngine.Object.DontDestroyOnLoad(atlasTexture);

            if (Plugin.Config.DetailedLogs.Value && !_loggedSavePointColor)
            {
                string color = GetActiveSavePointColorVariant();
                Plugin.Log.LogInfo($"[SavePoint] Custom {color} created and cached");
                _loggedSavePointColor = true;
            }
            return customSprite;
        }
        else
        {
            Plugin.Log.LogError($"[SavePoint] Sprite.Create returned null for: {spriteName}");
        }

        return null;
    }
}

