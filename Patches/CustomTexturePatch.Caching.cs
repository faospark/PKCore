using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using BepInEx;
using System.Xml.Serialization;

namespace PKCore.Patches;

public partial class CustomTexturePatch
{
    private static string cachePath;
    private static string manifestPath;
    
    [Serializable]
    public class ManifestEntry
    {
        [XmlAttribute]
        public string Key;
        [XmlAttribute]
        public string Value;
    }

    [Serializable]
    public class TextureManifest
    {
        public long LastModified;
        public long BuildTime; // Ticks when manifest was built
        public string ConfigHash; // Hash of texture-related config settings
        public int FileCount; // Total number of texture files indexed
        public List<ManifestEntry> Entries = new List<ManifestEntry>();
        
        public void FromDictionary(Dictionary<string, string> dict)
        {
            Entries.Clear();
            foreach(var kvp in dict)
            {
                Entries.Add(new ManifestEntry { Key = kvp.Key, Value = kvp.Value });
            }
        }
        
        public Dictionary<string, string> ToDictionary()
        {
            var dict = new Dictionary<string, string>();
            foreach(var entry in Entries)
            {
                if (!dict.ContainsKey(entry.Key))
                    dict.Add(entry.Key, entry.Value);
            }
            return dict;
        }
    }

    /// <summary>
    /// Initialize caching paths
    /// </summary>
    private static void InitializeCaching()
    {
        cachePath = Path.Combine(BepInEx.Paths.GameRootPath, "PKCore", "Cache");
        // Changing extension to .xml
        manifestPath = Path.Combine(cachePath, "texture_manifest.xml");

        if (!Directory.Exists(cachePath))
        {
            Directory.CreateDirectory(cachePath);
        }
    }

    /// <summary>
    /// Compute hash of texture-related config settings
    /// If any of these change, the manifest should be invalidated
    /// </summary>
    private static string ComputeConfigHash()
    {
        // Combine all texture-related config values into a string
        string configString = $"{Plugin.Config.LoadLauncherUITextures.Value}|" +
                            $"{Plugin.Config.LoadBattleTextures.Value}|" +
                            $"{Plugin.Config.LoadCharacterTextures.Value}|" +
                            $"{Plugin.Config.SavePointColor.Value}";
        
        // Use stable hash (SHA256) instead of GetHashCode which is not stable across runs
        using (var sha256 = System.Security.Cryptography.SHA256.Create())
        {
            byte[] hashBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(configString));
            return BitConverter.ToString(hashBytes).Replace("-", "");
        }
    }

    /// <summary>
    /// Try to load texture index from manifest (XML)
    /// </summary>
    private static bool TryLoadManifestIndex()
    {
        if (!File.Exists(manifestPath))
            return false;

        try
        {
            // Check if textures directory has been modified since manifest
            long currentModified = Directory.GetLastWriteTime(customTexturesPath).Ticks;
            
            XmlSerializer serializer = new XmlSerializer(typeof(TextureManifest));
            using (FileStream stream = new FileStream(manifestPath, FileMode.Open))
            {
                TextureManifest manifest = (TextureManifest)serializer.Deserialize(stream);

                // Check if config has changed since manifest was created
                string currentConfigHash = ComputeConfigHash();
                
                // Count current texture files
                int currentFileCount = Directory.GetFiles(customTexturesPath, "*.png", SearchOption.AllDirectories).Length;
                
                // Check if 48 hours have passed since last build
                long currentTicks = DateTime.Now.Ticks;
                long ticksSinceBuild = currentTicks - manifest.BuildTime;
                double hoursSinceBuild = TimeSpan.FromTicks(ticksSinceBuild).TotalHours;
                bool buildExpired = hoursSinceBuild >= 48.0;
                
                if (manifest != null && 
                    manifest.LastModified == currentModified && 
                    manifest.ConfigHash == currentConfigHash &&
                    manifest.FileCount == currentFileCount &&
                    !buildExpired &&
                    manifest.Entries != null && 
                    manifest.Entries.Count > 0)
                {
                    texturePathIndex = manifest.ToDictionary();
                    // Loaded from cache (silent)
                    return true;
                }
                else if (manifest != null)
                {
                    if (buildExpired)
                        Plugin.Log.LogInfo($"Build expired ({hoursSinceBuild:F1} hours old) - rebuilding texture index");
                    else if (manifest.ConfigHash != currentConfigHash)
                        Plugin.Log.LogInfo("Config changed - rebuilding texture index");
                    else if (manifest.FileCount != currentFileCount)
                        Plugin.Log.LogInfo($"File count changed ({manifest.FileCount} -> {currentFileCount}) - rebuilding texture index");
                }
            }
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"Failed to load manifest: {ex.Message}");
        }

        return false;
    }

    /// <summary>
    /// Save texture index to manifest (XML)
    /// </summary>
    private static void SaveManifestIndex()
    {
        try
        {
            int fileCount = Directory.GetFiles(customTexturesPath, "*.png", SearchOption.AllDirectories).Length;
            
            TextureManifest manifest = new TextureManifest
            {
                LastModified = Directory.GetLastWriteTime(customTexturesPath).Ticks,
                BuildTime = DateTime.Now.Ticks,
                ConfigHash = ComputeConfigHash(),
                FileCount = fileCount
            };
            manifest.FromDictionary(texturePathIndex);

            XmlSerializer serializer = new XmlSerializer(typeof(TextureManifest));
            using (FileStream stream = new FileStream(manifestPath, FileMode.Create))
            {
                serializer.Serialize(stream, manifest);
            }
            // Manifest saved successfully (silent)
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"Failed to save manifest: {ex.Message}");
        }
    }
}
