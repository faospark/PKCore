using HarmonyLib;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PKCore.Patches
{
    /// <summary>
    /// Enables the DebugMenu2 object which is normally disabled in the game
    /// </summary>
    public class EnableDebugMenu2
    {
        private static bool _initialized = false;

        public static void Initialize()
        {
            if (_initialized)
                return;

            // Use SceneManager.sceneLoaded event instead of patching Internal_ActiveSceneChanged
            // This avoids interfering with BepInEx's chainloader initialization
            // Use Action wrapper for IL2CPP compatibility
            SceneManager.sceneLoaded += (System.Action<Scene, LoadSceneMode>)OnSceneLoaded;
            _initialized = true;
            
            Plugin.Log.LogInfo("[EnableDebugMenu2] Initialized scene listener");
        }

        private static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (!Plugin.Config.EnableDebugMenu2.Value)
                return;

            // Only enable in GSD1 or GSD2 scenes (when a save is loaded)
            if (!scene.name.StartsWith("GSD1") && !scene.name.StartsWith("GSD2"))
                return;

            Plugin.Log.LogInfo($"[EnableDebugMenu2] Scene loaded: {scene.name}");

            // Search for DebugMenu2 in the new scene
            GameObject[] rootObjects = scene.GetRootGameObjects();
            Plugin.Log.LogInfo($"[EnableDebugMenu2] Found {rootObjects.Length} root objects");

            foreach (GameObject rootObj in rootObjects)
            {
                Plugin.Log.LogInfo($"[EnableDebugMenu2] Checking root object: {rootObj.name}");
                
                // Check if this is the UI_Root or UI_Canvas_Root
                if (rootObj.name.Contains("UI_Root") || rootObj.name.Contains("UI_Canvas_Root"))
                {
                    Plugin.Log.LogInfo($"[EnableDebugMenu2] Found UI root: {rootObj.name}, searching for DebugMenu2...");
                    
                    // Search for DebugMenu2 in children
                    Transform debugMenu2 = FindInChildren(rootObj.transform, "DebugMenu2");
                    if (debugMenu2 != null)
                    {
                        bool wasActive = debugMenu2.gameObject.activeSelf;
                        debugMenu2.gameObject.SetActive(true);
                        Plugin.Log.LogInfo($"[EnableDebugMenu2] Found and enabled DebugMenu2 in scene: {scene.name} (was active: {wasActive})");
                        return;
                    }
                    else
                    {
                        Plugin.Log.LogInfo($"[EnableDebugMenu2] DebugMenu2 not found in {rootObj.name}");
                    }
                }
            }
            
            Plugin.Log.LogInfo($"[EnableDebugMenu2] DebugMenu2 not found in scene: {scene.name}");
        }

        private static Transform FindInChildren(Transform parent, string name)
        {
            // IL2CPP-safe iteration
            for (int i = 0; i < parent.childCount; i++)
            {
                Transform child = parent.GetChild(i);
                if (child.name.Contains(name))
                    return child;

                Transform found = FindInChildren(child, name);
                if (found != null)
                    return found;
            }
            return null;
        }
    }
}
