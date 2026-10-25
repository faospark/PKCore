using System;
using UnityEngine.SceneManagement;

namespace PKCore.Patches;

/// <summary>
/// High-reliability game context detection for Project Kyaro (PKCore).
/// Accurately detects whether Suikoden 1 (GSD1), Suikoden 2 (GSD2), or the Main Menu/Launcher is active.
/// Powered by active Unity scene matching with instant SceneManager.sceneLoaded event dispatch.
/// </summary>
public static class GameDetection
{
    private static string _cachedGameId = "Main";
    private static string _lastSceneName = "";
    private static bool _initialized = false;

    /// <summary>
    /// Event fired when the detected game context changes ("GSD1", "GSD2", "Main").
    /// </summary>
    public static event Action<string> OnGameChanged;

    public static void Initialize()
    {
        if (_initialized) return;
        _initialized = true;

        try
        {
            SceneManager.sceneLoaded += (UnityEngine.Events.UnityAction<Scene, LoadSceneMode>)((scene, mode) =>
            {
                Update();
            });
        }
        catch { }

        Update();
    }

    /// <summary>
    /// Frame update called by PkCoreMainLoop and SceneManager.sceneLoaded.
    /// </summary>
    public static void Update()
    {
        string sceneName = "";
        try { sceneName = SceneManager.GetActiveScene().name; } catch { }

        if (string.IsNullOrEmpty(sceneName) || sceneName == _lastSceneName)
            return;

        _lastSceneName = sceneName;

        string newGameId = _cachedGameId;
        if (sceneName.Contains("GSD1", StringComparison.OrdinalIgnoreCase))
        {
            newGameId = "GSD1";
        }
        else if (sceneName.Contains("GSD2", StringComparison.OrdinalIgnoreCase))
        {
            newGameId = "GSD2";
        }
        else if (sceneName.Equals("main", StringComparison.OrdinalIgnoreCase) || sceneName.Equals("init", StringComparison.OrdinalIgnoreCase))
        {
            newGameId = "Main";
        }

        if (newGameId != _cachedGameId)
        {
            Plugin.Log.LogInfo($"[GameDetection] Game context changed: {_cachedGameId} -> {newGameId} (Scene: '{sceneName}')");
            _cachedGameId = newGameId;
            OnGameChanged?.Invoke(_cachedGameId);
        }
    }

    /// <summary>
    /// Get the current game identifier ("GSD1", "GSD2", or "Main").
    /// </summary>
    public static string GetCurrentGame()
    {
        if (_cachedGameId == "Main")
        {
            string sceneName = "";
            try { sceneName = SceneManager.GetActiveScene().name; } catch { }
            if (!string.IsNullOrEmpty(sceneName) && sceneName != _lastSceneName)
            {
                Update();
            }
        }
        return _cachedGameId;
    }

    /// <summary>
    /// Check if Suikoden 1 is currently running.
    /// </summary>
    public static bool IsGSD1() => GetCurrentGame() == "GSD1";

    /// <summary>
    /// Check if Suikoden 2 is currently running.
    /// </summary>
    public static bool IsGSD2() => GetCurrentGame() == "GSD2";

    /// <summary>
    /// Check if currently in the Main menu or launcher.
    /// </summary>
    public static bool IsMain() => GetCurrentGame() == "Main";
}
