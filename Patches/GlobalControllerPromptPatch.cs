using HarmonyLib;
using BepInEx;
using BepInEx.Logging;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Collections.Generic;

namespace PKCore.Patches
{
    /// <summary>
    /// Global sprite swap patch that intercepts ALL Image.sprite assignments
    /// and automatically swaps controller button sprites based on user preference.
    /// </summary>
    [HarmonyPatch]
    public class GlobalControllerPromptPatch
    {
        private static ManualLogSource Logger => Plugin.Log;
        private static readonly Dictionary<string, Sprite> spriteCache = new Dictionary<string, Sprite>(StringComparer.OrdinalIgnoreCase);
        private static readonly Dictionary<string, string> customTextureFiles = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        private static bool customTextureIndexBuilt = false;

        // Counter for cycling through PlayStation face buttons when Xbox uses generic sprite
        private static int xboxGenericButtonCounter = 0;
        private static readonly string[] psButtonCycle = { "05", "06", "07", "08" }; // Square, Triangle, Circle, Cross

        /// <summary>
        /// Intercept all Image.sprite setter calls to swap controller button sprites
        /// </summary>
        [HarmonyPatch(typeof(Image), nameof(Image.sprite), MethodType.Setter)]
        [HarmonyPrefix]
        public static void Image_set_sprite_Prefix(Image __instance, ref Sprite value)
        {
            if (!Plugin.Config.EnableButtonPrompts.Value || value == null)
                return;

            string originalName = value.name;
            if (string.IsNullOrEmpty(originalName))
                return;

            // Check if this is a controller button sprite (ends with _00, _01, _02, _03, _04, or _05)
            if (!IsControllerSprite(originalName))
                return;

            // Determine desired controller suffix based on config
            string desiredSuffix = GetControllerSuffix(Plugin.Config.ControllerPromptType.Value);

            // If sprite already has correct suffix, no need to swap
            if (originalName.EndsWith(desiredSuffix))
                return;

            // Special case: Xbox minigame uses one sprite for all 4 face buttons
            // Cycle through PlayStation's 4 separate sprites based on occurrence order
            string targetName;
            if (IsXboxGenericMinigameButton(originalName) && desiredSuffix != "_00")
            {
                targetName = GetCycledPlayStationButton(desiredSuffix);
                Logger.LogDebug($"Xbox generic button #{xboxGenericButtonCounter} -> {targetName}");
            }
            else
            {
                // Build the target sprite name normally
                targetName = ReplaceControllerSuffix(originalName, desiredSuffix);
            }

            // Try to load the swapped sprite
            Sprite swappedSprite = LoadSprite(targetName);
            if (swappedSprite != null)
            {
                Logger.LogDebug($"Swapped controller sprite: {originalName} -> {targetName}");
                value = swappedSprite;
            }
            else
            {
                Logger.LogWarning($"Failed to load swapped sprite: {targetName}");
            }
        }

        /// <summary>
        /// Check if this is the Xbox generic minigame button (UI_MiniGame_Icon05_001_00)
        /// Xbox uses ONE sprite for all 4 face buttons, but PlayStation uses 4 separate sprites.
        /// </summary>
        private static bool IsXboxGenericMinigameButton(string spriteName)
        {
            return spriteName == "UI_MiniGame_Icon05_001_00";
        }

        /// <summary>
        /// Cycle through PlayStation face button sprites in order: Square, Triangle, Circle, Cross
        /// </summary>
        private static string GetCycledPlayStationButton(string suffix)
        {
            // Get the button icon number based on counter (cycles 0-3)
            string iconNumber = psButtonCycle[xboxGenericButtonCounter % 4];

            // Build sprite name: UI_MiniGame_Icon05_001_01 -> UI_MiniGame_Icon06_001_01, etc.
            string spriteName = $"UI_MiniGame_Icon{iconNumber}_001{suffix}";

            // Increment counter for next occurrence
            xboxGenericButtonCounter++;

            return spriteName;
        }

        /// <summary>
        /// Reset the button cycle counter (call when entering/exiting minigames)
        /// </summary>
        public static void ResetButtonCycle()
        {
            xboxGenericButtonCounter = 0;
            Logger.LogDebug("Reset Xbox generic button cycle counter");
        }

        /// <summary>
        /// Check if sprite name follows controller button naming pattern
        /// Pattern: SomeName_XX where XX is 00 (Xbox/Generic), 01 (PS4), 02 (PS5), 03 (Xbox Native), 04 (Switch), 05 (Custom)
        /// </summary>
        private static bool IsControllerSprite(string spriteName)
        {
            if (string.IsNullOrEmpty(spriteName) || spriteName.Length < 3)
                return false;

            return spriteName.EndsWith("_00") ||
                   spriteName.EndsWith("_01") ||
                   spriteName.EndsWith("_02") ||
                   spriteName.EndsWith("_03") ||
                   spriteName.EndsWith("_04") ||
                   spriteName.EndsWith("_05");
        }

        /// <summary>
        /// Get the sprite suffix for the desired controller type
        /// </summary>
        private static string GetControllerSuffix(string controllerTypeStr)
        {
            if (string.IsNullOrEmpty(controllerTypeStr))
                return "_01";

            // Try to parse as int first (for backward compatibility)
            if (int.TryParse(controllerTypeStr, out int controllerType))
            {
                return GetControllerSuffixByIndex(controllerType);
            }

            // Parse by name
            string normalized = controllerTypeStr.ToLowerInvariant().Replace(" ", "").Replace("-", "");

            // PS4 variants -> _01
            if (normalized == "playstation" ||
                normalized == "playstation4" ||
                normalized == "ds4" ||
                normalized == "ps4")
            {
                return "_01";
            }

            // PS5 variants -> _02
            if (normalized == "playstation5" ||
                normalized == "dualsense" ||
                normalized == "ps5")
            {
                return "_02";
            }

            // Xbox Native -> _03
            if (normalized == "xboxnative" ||
                normalized == "xbox")
            {
                return "_03";
            }

            // Switch / Nintendo -> _04
            if (normalized == "switch" ||
                normalized == "nintendo")
            {
                return "_04";
            }

            // Custom -> _05
            if (normalized == "custom" ||
                normalized == "custom1" ||
                normalized == "custom2")
            {
                return "_05";
            }

            // Xbox / Generic / PC -> _00
            if (normalized == "generic" ||
                normalized == "pc" ||
                normalized == "keyboard")
            {
                return "_00";
            }

            // Default fallback
            Logger.LogWarning($"Unknown controller type: {controllerTypeStr}, defaulting to PlayStation (PS4)");
            return "_01";
        }

        /// <summary>
        /// Get suffix by numeric index (for backward compatibility)
        /// </summary>
        private static string GetControllerSuffixByIndex(int controllerType)
        {
            switch (controllerType)
            {
                case 0: // PlayStation (PS4)
                    return "_01";
                case 1: // Xbox/Generic/PC
                    return "_00";
                case 2: // Switch/Nintendo
                    return "_04";
                case 3: // PS5
                    return "_02";
                case 4: // Xbox Native
                    return "_03";
                case 5: // Custom
                    return "_05";
                default:
                    return "_01";
            }
        }

        /// <summary>
        /// Replace the controller suffix in a sprite name
        /// </summary>
        private static string ReplaceControllerSuffix(string spriteName, string newSuffix)
        {
            if (spriteName.Length < 3)
                return spriteName;

            // Remove last 3 characters (_XX) and add new suffix
            return spriteName.Substring(0, spriteName.Length - 3) + newSuffix;
        }

        /// <summary>
        /// Load a sprite by name from Resources, with custom textures fallback and caching
        /// </summary>
        private static Sprite LoadSprite(string spriteName)
        {
            // Check cache first
            if (spriteCache.TryGetValue(spriteName, out Sprite cachedSprite) && cachedSprite != null)
                return cachedSprite;

            // 1. Try to load from Resources
            try
            {
                var allSprites = Resources.FindObjectsOfTypeAll<Sprite>();
                foreach (var sprite in allSprites)
                {
                    if (sprite != null && sprite.name == spriteName)
                    {
                        spriteCache[spriteName] = sprite;
                        Logger.LogDebug($"Loaded sprite from resources: {spriteName}");
                        return sprite;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error searching for sprite {spriteName} in resources: {ex.Message}");
            }

            // 2. Fallback: Try to load from custom texture file if present
            Sprite customSprite = TryLoadCustomTextureSprite(spriteName);
            if (customSprite != null)
            {
                spriteCache[spriteName] = customSprite;
                Logger.LogInfo($"[GlobalControllerPromptPatch] Loaded custom button sprite: {spriteName}");
                return customSprite;
            }

            Logger.LogWarning($"Sprite not found in resources or custom textures: {spriteName}");
            return null;
        }

        /// <summary>
        /// Check custom texture search paths and attempt to load the sprite
        /// </summary>
        private static Sprite TryLoadCustomTextureSprite(string spriteName)
        {
            EnsureCustomTextureIndex();

            if (!customTextureFiles.TryGetValue(spriteName, out string filePath) || !File.Exists(filePath))
                return null;

            try
            {
                byte[] fileData = File.ReadAllBytes(filePath);
                Texture2D texture = new Texture2D(2, 2, TextureFormat.RGBA32, false);
                if (ImageConversion.LoadImage(texture, fileData))
                {
                    texture.name = spriteName;
                    Sprite sprite = Sprite.Create(
                        texture,
                        new Rect(0, 0, texture.width, texture.height),
                        new Vector2(0.5f, 0.5f),
                        100f,
                        0,
                        SpriteMeshType.FullRect,
                        Vector4.zero
                    );
                    sprite.name = spriteName;

                    UnityEngine.Object.DontDestroyOnLoad(texture);
                    UnityEngine.Object.DontDestroyOnLoad(sprite);

                    return sprite;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Failed loading custom texture image for {spriteName} from {filePath}: {ex.Message}");
            }

            return null;
        }

        /// <summary>
        /// Build index of available custom button texture files across standard directories
        /// </summary>
        private static void EnsureCustomTextureIndex()
        {
            if (customTextureIndexBuilt)
                return;

            customTextureIndexBuilt = true;

            try
            {
                string assemblyDir = Path.GetDirectoryName(typeof(GlobalControllerPromptPatch).Assembly.Location) ?? "";

                string[] searchDirs = new[]
                {
                    Path.Combine(assemblyDir, "Textures"),
                    Path.Combine(Paths.PluginPath, "PKButtonPrompts", "Textures"),
                    Path.Combine(Paths.PluginPath, "PKButtonPrompts"),
                    Path.Combine(Paths.GameRootPath, "PKButtonPrompts", "Textures"),
                    Path.Combine(Paths.GameRootPath, "PKCore", "Textures", "buttons"),
                    Path.Combine(Paths.GameRootPath, "PKCore", "Textures")
                };

                foreach (string dir in searchDirs)
                {
                    if (!Directory.Exists(dir))
                        continue;

                    foreach (string file in Directory.EnumerateFiles(dir, "*.png", SearchOption.AllDirectories))
                    {
                        string nameWithoutExt = Path.GetFileNameWithoutExtension(file);
                        if (!customTextureFiles.ContainsKey(nameWithoutExt))
                        {
                            customTextureFiles[nameWithoutExt] = file;
                        }
                    }
                }

                Logger.LogDebug($"Indexed {customTextureFiles.Count} custom button textures.");
            }
            catch (Exception ex)
            {
                Logger.LogWarning($"Error indexing custom button textures: {ex.Message}");
            }
        }

        /// <summary>
        /// Clear the sprite cache and texture index
        /// </summary>
        public static void ClearCache()
        {
            spriteCache.Clear();
            customTextureFiles.Clear();
            customTextureIndexBuilt = false;
            Logger.LogInfo("Controller sprite cache cleared");
        }
    }
}

