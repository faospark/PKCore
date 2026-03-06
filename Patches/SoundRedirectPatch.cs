using System.IO;
using CriWare;
using HarmonyLib;

namespace PKCore.Patches;

/// <summary>
/// Redirects CriWare ACB/AWB file loads through a user override folder.
/// 
/// Place custom .acb and .awb files under:
///   {GameRoot}/PKCore/Sound/
/// 
/// Mirror the original Sound folder structure exactly, e.g.:
///   PKCore/Sound/BGM2/BATTLE1.acb
///   PKCore/Sound/BGM2/BATTLE1.awb
///   PKCore/Sound/SEHD1/SE1.acb
/// 
/// Any file present in the override folder will replace the original.
/// Files not present fall back to the original StreamingAssets/Sound/ files.
/// </summary>
public static class SoundRedirectPatch
{
    private static string _overrideRoot;
    private static string _streamingSoundRoot;

    public static void Initialize()
    {
        // GameRoot = parent of Application.dataPath (the _Data folder)
        string gameRoot = Path.GetDirectoryName(UnityEngine.Application.dataPath);
        _overrideRoot = Path.Combine(gameRoot, "PKCore", "Sound");
        _streamingSoundRoot = Path.Combine(UnityEngine.Application.streamingAssetsPath, "Sound");

        Plugin.Log.LogInfo($"[SoundRedirect] Override folder: {_overrideRoot}");

        if (!Directory.Exists(_overrideRoot))
        {
            Directory.CreateDirectory(_overrideRoot);
            Plugin.Log.LogInfo("[SoundRedirect] Created override folder (empty - add .acb/.awb files to override sounds).");
        }
        else
        {
            // Count override files present
            var files = Directory.GetFiles(_overrideRoot, "*.acb", SearchOption.AllDirectories);
            Plugin.Log.LogInfo($"[SoundRedirect] Found {files.Length} .acb override file(s).");
        }
    }

    /// <summary>
    /// If an override file exists for the given CriWare path, returns the override path.
    /// Otherwise returns the original path unchanged.
    /// 
    /// Handles three path formats CriWare may use:
    ///   1. Absolute:   D:\...\Sound\BGM2\BATTLE1.acb
    ///   2. SA-relative: Sound/BGM2/BATTLE1 or Sound/BGM2/BATTLE1.acb
    ///   3. Sound-relative: BGM2/BATTLE1 or BGM2/BATTLE1.acb
    /// </summary>
    private static string TryRedirect(string originalPath)
    {
        if (string.IsNullOrEmpty(originalPath))
            return originalPath;

        // -- Normalise to a path relative to the Sound folder --
        string rel = originalPath.Replace('/', Path.DirectorySeparatorChar)
                                 .Replace('\\', Path.DirectorySeparatorChar);

        // Strip the streaming assets Sound prefix if present
        string soundPrefix = _streamingSoundRoot + Path.DirectorySeparatorChar;
        if (rel.StartsWith(soundPrefix, System.StringComparison.OrdinalIgnoreCase))
        {
            rel = rel.Substring(soundPrefix.Length);
        }
        else if (rel.Contains($"{Path.DirectorySeparatorChar}Sound{Path.DirectorySeparatorChar}"))
        {
            // Absolute path containing \Sound\ somewhere
            int idx = rel.LastIndexOf($"{Path.DirectorySeparatorChar}Sound{Path.DirectorySeparatorChar}",
                                      System.StringComparison.OrdinalIgnoreCase);
            rel = rel.Substring(idx + 7); // skip \Sound\
        }
        else if (rel.StartsWith("Sound" + Path.DirectorySeparatorChar, System.StringComparison.OrdinalIgnoreCase))
        {
            rel = rel.Substring(6); // skip "Sound\"
        }
        // else: already relative to Sound folder (e.g. "BGM2\BATTLE1.acb")

        string overridePath = Path.Combine(_overrideRoot, rel);

        if (File.Exists(overridePath))
        {
            Plugin.Log.LogInfo($"[SoundRedirect] → '{rel}' overridden");
            return overridePath;
        }

        return originalPath;
    }

    // -------------------------------------------------------------------------
    // Harmony patch — CriAtomExAcb.LoadAcbFile(awb, acbPath, awbPath)
    //
    // This is the primary CriWare API for loading an ACB+AWB pair from disk.
    // By redirecting the path arguments here we capture all BGM and SE loads.
    // -------------------------------------------------------------------------
    [HarmonyPatch(typeof(CriAtomExAcb), nameof(CriAtomExAcb.LoadAcbFile))]
    [HarmonyPrefix]
    public static void LoadAcbFile_Prefix(ref string acbPath, ref string awbPath)
    {
        acbPath = TryRedirect(acbPath);
        if (!string.IsNullOrEmpty(awbPath))
            awbPath = TryRedirect(awbPath);
    }
}
