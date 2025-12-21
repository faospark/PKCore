using System;
using System.IO;

namespace PKCore.Patches;

/// <summary>
/// Texture category filtering options - separate file for easy customization
/// Add your texture folder filters here without modifying CustomTexturePatch.cs
/// </summary>
public static class TextureOptions
{
    /// <summary>
    /// Check if a texture should be loaded based on its folder path
    /// Returns false to skip loading the texture
    /// </summary>
    public static bool ShouldLoadTexture(string filePath)
    {
        // Disable launcher UI textures
        if (!Plugin.Config.LoadLauncherUITextures.Value && 
            filePath.Contains("\\launcher\\", StringComparison.OrdinalIgnoreCase))
            return false;

        // Disable battle effect textures
        if (!Plugin.Config.LoadBattleEffectTextures.Value && 
            filePath.Contains("\\battle\\", StringComparison.OrdinalIgnoreCase))
            return false;

        // Disable character textures
        if (!Plugin.Config.LoadCharacterTextures.Value && 
            filePath.Contains("\\characters\\", StringComparison.OrdinalIgnoreCase))
            return false;

        // Add more filters here as needed:
        // if (filePath.Contains("\\yourfolder\\", StringComparison.OrdinalIgnoreCase))
        //     return false;

        return true; // Load the texture
    }
}
