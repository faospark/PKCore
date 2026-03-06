using UnityEngine;
using UnityEngine.SceneManagement;

namespace PKCore.Patches;

/// <summary>
/// Utility to detect which game (Suikoden 1 or 2) is currently running
/// Used for game-specific texture loading
/// </summary>
public static class GameDetection
{
    private static string _cachedGameId = "Main";
    private static string _lastSceneName = "";

    /// <summary>
    /// Event fired when the detected game context changes.
    /// Parameter is the new game ID ("GSD1", "GSD2", "Main")
    /// </summary>
    public static event System.Action<string> OnGameChanged;

    /// <summary>
    /// Update loop called by Plugin.Update()
    /// Monitors scene changes and fires events
    /// </summary>
    public static void Update()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        // Only check if scene has changed
        if (sceneName == _lastSceneName)
            return;

        _lastSceneName = sceneName;

        string newGameId = "Main";
        if (sceneName.Contains("GSD1"))
        {
            newGameId = "GSD1";
        }
        else if (sceneName.Contains("GSD2"))
        {
            newGameId = "GSD2";
        }
        else if (sceneName.Equals("main", System.StringComparison.OrdinalIgnoreCase))
        {
            newGameId = "Main";
        }

        // If detection changed, fire event
        if (newGameId != _cachedGameId)
        {
            Plugin.Log.LogInfo($"[GameDetection] Game detected: {newGameId} (Scene: {sceneName})");
            _cachedGameId = newGameId;
            OnGameChanged?.Invoke(_cachedGameId);
        }
    }

    /// <summary>
    /// Get the current game identifier (GSD1, GSD2, or Main)
    /// </summary>
    public static string GetCurrentGame()
    {
        return _cachedGameId;
    }

    /// <summary>
    /// Check if we're currently running Suikoden 1
    /// </summary>
    public static bool IsGSD1() => GetCurrentGame() == "GSD1";

    /// <summary>
    /// Check if we're currently running Suikoden 2
    /// </summary>
    public static bool IsGSD2() => GetCurrentGame() == "GSD2";

    /// <summary>
    /// Check if we're currently in the Main menu/launcher
    /// </summary>
    public static bool IsMain() => GetCurrentGame() == "Main";
}
