using HarmonyLib;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using System.Reflection;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Injection;
using PKCore.Models;
using PKCore.Utils;
using BepInEx;

namespace PKCore.Patches;

/// <summary>
/// Manages insertion of custom objects defined in JSON configuration
/// </summary>
public class CustomObjectInsertion
{
    private static HashSet<int> _processedScenes = new HashSet<int>();
    private static Dictionary<string, List<DiscoveredObject>> _loadedObjects = new Dictionary<string, List<DiscoveredObject>>();
    private static bool _configLoaded = false;

    // Cache for the current MapBGManagerHD instance
    private static object _currentMapBGManager = null;

    // Path to the JSON file - trying multiple locations
    private static string GetConfigPath()
    {
        // 0. Try GameRoot/PKCore/Config/CustomObjectTexture.json (User Preference)
        string gameRootPath = Path.Combine(Paths.GameRootPath, "PKCore", "Config", "CustomObjectTexture.json");
        if (File.Exists(gameRootPath))
        {
            // Plugin.Log.LogInfo($"[Custom Objects] Found config in GameRoot: {gameRootPath}");
            return gameRootPath;
        }

        // 1. Try PKCore/Config/CustomObjectTexture.json (standard BepInEx)
        string path = Path.Combine(Paths.PluginPath, "PKCore", "Config", "CustomObjectTexture.json");
        if (File.Exists(path)) return path;

        // 2. Try PKCore/CustomObjects/objects.json (fallback/legacy)
        path = Path.Combine(Paths.PluginPath, "PKCore", "CustomObjects", "objects.json");
        if (File.Exists(path)) return path;

        return null;
    }

    public static void Initialize(bool enabled, Harmony harmony)
    {
        if (!enabled) return;

        if (Plugin.Config.DetailedLogs.Value)
            Plugin.Log.LogInfo("[Custom Objects] Initializing object insertion system...");

        LoadConfiguration();

        if (Plugin.Config.DetailedLogs.Value)
            Plugin.Log.LogInfo($"[Custom Objects] Objects will be created when scenes are activated");

        // Apply patches
        harmony.PatchAll(typeof(RefleshObjectPatch));
        harmony.PatchAll(typeof(MACHICON_OnMapInitPatch));
        harmony.PatchAll(typeof(MapBGManagerHDSetMapPostfix));
        harmony.PatchAll(typeof(MachiLoader_Load_Patch));
    }

    // Called by MapBGManagerHDSetMapPostfix to cache the instance
    internal static void SetMapBGManagerInstance(object instance)
    {
        _currentMapBGManager = instance;
    }

    private static void LoadConfiguration()
    {
        try
        {
            string configPath = GetConfigPath();
            if (string.IsNullOrEmpty(configPath))
            {
                Plugin.Log.LogWarning("[Custom Objects] No CustomObjectTexture.json found. Searched: GameRoot/PKCore/Config/CustomObjectTexture.json, PKCore/Config/CustomObjectTexture.json");
                return;
            }

            // objects.json format: { "mapId": [ {...}, {...} ], "mapId2": [...] }
            // Load as flat dictionary directly
            var rawDict = AssetLoader.LoadJsonAsync<Dictionary<string, List<DiscoveredObject>>>(configPath).Result;
            if (rawDict != null && rawDict.Count > 0)
            {
                _loadedObjects = rawDict;
                _configLoaded = true;
                Plugin.Log.LogInfo($"[Custom Objects] Loaded {rawDict.Count} map(s) from {System.IO.Path.GetFileName(configPath)}");
                foreach (var kvp in rawDict)
                    Plugin.Log.LogInfo($"[Custom Objects]  → {kvp.Key}: {kvp.Value.Count} object(s)");
            }
            else
            {
                Plugin.Log.LogWarning($"[Custom Objects] objects.json loaded but no maps found or empty: {configPath}");
            }
        }
        catch (System.Exception ex)
        {
            Plugin.Log.LogError($"[Custom Objects] Error loading configuration: {ex.Message}");
        }
    }

    internal static List<DiscoveredObject> GetObjectsForMap(string mapId)
    {
        if (!_configLoaded || _loadedObjects == null) return null;
        if (_loadedObjects.TryGetValue(mapId, out var objects)) return objects;
        return null;
    }

    /// <summary>
    /// Inject custom objects as native EVENT_OBJ entries into the MACHIDAT eventobj arrays.
    /// Called from MachiLoader_Load_Patch after EventInit() returns a live EVENTCON.
    /// </summary>
    internal static void InjectNativeEventObjects(string mapId, List<DiscoveredObject> customObjects, MACHIDAT machi)
    {
        Plugin.Log.LogInfo($"[Custom Objects] ➔ InjectNativeEventObjects called for map: {mapId} | Objects to inject: {customObjects?.Count ?? 0}");

        if (machi == null)
        {
            Plugin.Log.LogError($"[Custom Objects] ❌ Cannot inject native objects for {mapId}: MACHIDAT is null!");
            return;
        }

        if (machi.eventdata == null)
        {
            Plugin.Log.LogError($"[Custom Objects] ❌ Cannot inject native objects for {mapId}: MACHIDAT.eventdata is null!");
            return;
        }

        var mapEvents = machi.eventdata.mapeventdat;
        if (mapEvents == null || mapEvents.Count == 0)
        {
            Plugin.Log.LogWarning($"[Custom Objects] ⚠️ Cannot inject native objects for {mapId}: mapeventdat list is empty or null.");
            return;
        }

        foreach (var mapData in mapEvents)
        {
            var oldArray = mapData.eventobj;
            if (oldArray == null) continue;

            // Expanded array
            var newArray = new Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray<EVENT_OBJ>(oldArray.Length + customObjects.Count);

            // Copy existing
            for (int i = 0; i < oldArray.Length; i++)
            {
                newArray[i] = oldArray[i];
            }

            // Append custom
            for (int i = 0; i < customObjects.Count; i++)
            {
                var copy = customObjects[i];
                var no = new EVENT_OBJ();

                // Prioritize NativeX/Y if provided, otherwise fallback to Position.X/Y
                no.x = copy.NativeX != 0 ? (short)copy.NativeX : (short)copy.Position.X;
                no.y = copy.NativeY != 0 ? (short)copy.NativeY : (short)copy.Position.Y;
                no.w = (byte)(copy.NativeW != 0 ? copy.NativeW : copy.Scale.X);
                no.h = (byte)(copy.NativeH != 0 ? copy.NativeH : copy.Scale.Y);

                no.otyp = copy.ObjectType > 0 ? copy.ObjectType : (byte)1; // Default to EVENT_HUMAN
                no.wt = copy.WalkType;
                no.spd = copy.Speed;
                no.fpno = copy.FaceNo;
                no.ano = copy.AnimationNo;
                no.disp = 1; // Force visible
                no.ityp = copy.InteractType > 0 ? copy.InteractType : (byte)(copy.IsInteractable ? 1 : 0);

                newArray[oldArray.Length + i] = no;
            }

            mapData.eventobj = newArray;
        }

        Plugin.Log.LogInfo($"[Custom Objects] Natively injected {customObjects.Count} EVENT_OBJ instances into {mapId} MACHIDAT.");
    }

    /// <summary>
    /// Try to create custom objects in the given scene GameObject.
    /// Called from MapBGManagerHDSetMapPostfix when SetMap fires.
    /// </summary>
    public static void TryCreateCustomObjects(GameObject sceneRoot)
    {
        try
        {
            // Run discovery first if enabled — outputs ExistingMapObjects.json
            if (Plugin.Config.LogExistingMapObjects.Value)
            {
                ObjectDiscovery.DiscoverObjectsInScene(sceneRoot);
            }

            // Only create custom objects once per scene instance
            if (_processedScenes.Contains(sceneRoot.GetInstanceID()))
            {
                return;
            }

            if (!_configLoaded)
            {
                // Try loading again just in case it was created late
                LoadConfiguration();
                if (!_configLoaded) return;
            }

            string mapId = sceneRoot.name.Replace("(Clone)", "");

            if (!_loadedObjects.ContainsKey(mapId))
            {
                // No objects for this map
                return;
            }

            if (Plugin.Config.DetailedLogs.Value)
                Plugin.Log.LogInfo($"[Custom Objects] Finding object folder in scene: {sceneRoot.name}");

            Transform objectFolder = FindObjectFolderInScene(sceneRoot.transform);
            if (objectFolder == null)
            {
                // Fallback: parent directly to sceneRoot
                objectFolder = sceneRoot.transform;
                Plugin.Log.LogWarning($"[Custom Objects] No 'object' folder found in {sceneRoot.name} — parenting to scene root.");
            }

            // Create a "Custom" group folder under the target folder
            GameObject customGroup = new GameObject("Custom");
            customGroup.transform.SetParent(objectFolder);
            customGroup.transform.localPosition = Vector3.zero;
            customGroup.transform.localScale = Vector3.one;
            customGroup.transform.localRotation = Quaternion.identity;

            Transform customFolder = customGroup.transform;

            // Try to find the MapBGManagerHD directly from the scene root's parent
            object activeManager = _currentMapBGManager;
            if (activeManager == null)
            {
                var managerType = FindMapBGManagerType();
                if (managerType != null)
                {
                    var il2cppType = Il2CppType.From(managerType);
                    var comp = UnityEngine.Object.FindObjectOfType(il2cppType);
                    if (comp != null)
                    {
                        var ptrProperty = comp.GetType().GetProperty("Pointer");
                        if (ptrProperty != null)
                        {
                            var ptr = (IntPtr)ptrProperty.GetValue(comp);
                            activeManager = System.Activator.CreateInstance(managerType, ptr);
                            if (Plugin.Config.DetailedLogs.Value)
                                Plugin.Log.LogInfo($"[Custom Objects] Extracted MapBGManagerHD using FindObjectOfType");
                        }
                    }
                    else
                    {
                        Plugin.Log.LogWarning($"[Custom Objects] Failed to find MapBGManagerHD in the scene!");
                    }
                }
            }

            // Spawn visual GameObjects for all custom objects in this map
            CreateCustomObjectsForMap(mapId, customFolder, activeManager);

            _processedScenes.Add(sceneRoot.GetInstanceID());
        }
        catch (System.Exception ex)
        {
            Plugin.Log.LogError($"[Custom Objects] Error creating objects: {ex}");
        }
    }

    public static void ResetForNewScene()
    {
        _processedScenes.Clear();
        // Reload config on new scene allows live editing without restart
        LoadConfiguration();
    }


    private static Transform FindObjectFolderInScene(Transform sceneRoot)
    {
        // Search recursively in the scene root for "object" folder
        // For efficiency, we assume it's relatively shallow
        return FindObjectFolderRecursive(sceneRoot);
    }

    private static Transform FindObjectFolderRecursive(Transform parent)
    {
        if (parent.name == "object")
        {
            return parent;
        }

        for (int i = 0; i < parent.childCount; i++)
        {
            var result = FindObjectFolderRecursive(parent.GetChild(i));
            if (result != null)
            {
                return result;
            }
        }

        return null;
    }

    private static void CreateCustomObjectsForMap(string mapId, Transform objectFolder, object mapBGManager)
    {
        List<DiscoveredObject> objects = _loadedObjects[mapId];
        if (Plugin.Config.DetailedLogs.Value)
            Plugin.Log.LogInfo($"[Custom Objects] Creating {objects.Count} custom objects for {mapId}...");

        int successCount = 0;
        foreach (var objData in objects)
        {
            try
            {
                var (obj, sprite, position, scale, rotation) = CreateSingleObject(objData, objectFolder);
                if (obj != null)
                {
                    successCount++;

                    // Diagnostic logging for visibility debugging
                    if (Plugin.Config.DebugCustomObjects.Value)
                    {
                        Plugin.Log.LogInfo($"[Custom Objects] Object '{obj.name}' state:");
                        Plugin.Log.LogInfo($"  - Active: {obj.activeSelf}");
                        Plugin.Log.LogInfo($"  - Position: {obj.transform.position}");
                        Plugin.Log.LogInfo($"  - Local Position: {obj.transform.localPosition}");
                        Plugin.Log.LogInfo($"  - Parent: {obj.transform.parent?.name ?? "null"}");

                        var sr = obj.GetComponent<SpriteRenderer>();
                        if (sr != null)
                        {
                            Plugin.Log.LogInfo($"  - SpriteRenderer enabled: {sr.enabled}");
                            Plugin.Log.LogInfo($"  - Sprite BEFORE re-assignment: {sr.sprite?.name ?? "null"}");
                            Plugin.Log.LogInfo($"  - Sorting Layer: {sr.sortingLayerName} ({sr.sortingLayerID})");
                            Plugin.Log.LogInfo($"  - Sorting Order: {sr.sortingOrder}");
                            Plugin.Log.LogInfo($"  - Color: {sr.color}");
                        }
                    }

                    // Register with MapBGManagerHD if available
                    if (mapBGManager != null)
                    {
                        RegisterWithMapBGManager(obj, mapBGManager);
                    }

                    // Re-apply Y-based sortingOrder after MapSpriteHD.Awake() may have overridden it.
                    // Use pixel-space Y (NativeY if set, else Position.Y × HDScale) to match
                    // the same formula the game uses for characters in RefleshObject/SetSpriteSortingOrder.
                    var srFinal = obj.GetComponent<SpriteRenderer>();
                    if (srFinal != null && objData.SortingOrder != 0)
                        srFinal.sortingOrder = objData.SortingOrder;
                    else if (srFinal != null)
                        srFinal.sortingOrder = -(int)(GetPixelY(objData, objData.Position.Y) / 3.25f);

                    // RE-ASSIGN SPRITE AFTER ALL INITIALIZATION
                    // This is the final fix - sprite gets cleared somewhere, so we re-assign it last
                    if (sprite != null)
                    {
                        var sr = obj.GetComponent<SpriteRenderer>();
                        if (sr != null)
                        {
                            sr.sprite = sprite;
                            if (Plugin.Config.DetailedLogs.Value)
                                Plugin.Log.LogInfo($"[Custom Objects] ✓✓ FINAL sprite re-assignment for {obj.name}: {sprite.name}");

                            if (Plugin.Config.DebugCustomObjects.Value)
                            {
                                Plugin.Log.LogInfo($"  - Sprite AFTER final re-assignment: {sr.sprite?.name ?? "null"}");
                            }
                        }
                    }

                    // RE-APPLY TRANSFORM AFTER ALL INITIALIZATION
                    // Use negative Y-based Z so objects are pushed further from the camera
                    // (positive Z = closer to camera = always on top; negative Z = behind).
                    var yBasedZ = position.y * -0.01f;
                    obj.transform.localPosition = new Vector3(position.x, position.y, yBasedZ);
                    obj.transform.localScale = scale;
                    obj.transform.localRotation = rotation;
                    if (Plugin.Config.DetailedLogs.Value)
                    {
                        Plugin.Log.LogInfo($"[Custom Objects] ✓✓ FINAL transform re-application for {obj.name}:");
                        Plugin.Log.LogInfo($"  - Position: {obj.transform.localPosition}");
                        Plugin.Log.LogInfo($"  - Scale: {scale}");
                        Plugin.Log.LogInfo($"  - Rotation: {rotation.eulerAngles}");
                    }
                }
            }
            catch (System.Exception ex)
            {
                Plugin.Log.LogError($"[Custom Objects] Failed to create object {objData.Name}: {ex.Message}");
            }
        }

        if (Plugin.Config.DetailedLogs.Value)
            Plugin.Log.LogInfo($"[Custom Objects] Successfully created {successCount}/{objects.Count} objects");
    }

    private static (GameObject obj, Sprite sprite, Vector3 position, Vector3 scale, Quaternion rotation) CreateSingleObject(DiscoveredObject data, Transform parent)
    {
        // Create GameObject
        GameObject customObj = new GameObject(data.Name);
        customObj.transform.SetParent(parent);

        // Store desired transform values to re-apply later (after MapSpriteHD interference)
        Vector3 desiredPosition;
        Vector3 desiredScale;
        Quaternion desiredRotation;

        // Transform
        if (data.Position != null)
            desiredPosition = data.Position.ToVector3();
        else
            desiredPosition = Vector3.zero;

        if (data.Scale != null)
        {
            var scale = data.Scale.ToVector3();
            // Prevent zero scale (causes invisible objects)
            if (scale.x == 0) scale.x = 1;
            if (scale.y == 0) scale.y = 1;
            if (scale.z == 0) scale.z = 1;
            desiredScale = scale;
        }
        else
            desiredScale = Vector3.one;

        desiredRotation = Quaternion.Euler(0, 0, data.Rotation);

        // Log native EVENT_OBJ fields if specified (for modder verification)
        if (Plugin.Config.DetailedLogs.Value && (data.NativeX != 0 || data.NativeY != 0 || data.ObjectType != 0 || data.FaceNo != 0))
        {
            Plugin.Log.LogInfo($"[Custom Objects] Native fields for '{data.Name}': " +
                $"otyp={data.ObjectType} wt={data.WalkType} ityp={data.InteractType} " +
                $"fpno={data.FaceNo} disp={data.Disp} " +
                $"x={data.NativeX} y={data.NativeY} w={data.NativeW} h={data.NativeH}");
        }

        // Apply transform initially (will be re-applied later)
        customObj.transform.localPosition = desiredPosition;
        customObj.transform.localScale = desiredScale;
        customObj.transform.localRotation = desiredRotation;


        // (Layer and Tag are not stored; custom objects use default layer/tag)

        // SpriteRenderer
        SpriteRenderer sr = null;
        Sprite spriteToAssign = null; // Store sprite reference to assign AFTER MapSpriteHD component

        if (data.HasSpriteRenderer || !string.IsNullOrEmpty(data.Texture))
        {
            sr = customObj.AddComponent<SpriteRenderer>();
            sr.sortingOrder = data.SortingOrder;

            // Attempt to copy Sorting Layer AND Material from a sibling
            // This is critical because the map might render on a specific layer (e.g. "Background")
            // preventing our object from being seen if it's on "Default"
            var siblingSr = parent.GetComponentInChildren<SpriteRenderer>();
            if (siblingSr == null && parent.parent != null)
            {
                siblingSr = parent.parent.GetComponentInChildren<SpriteRenderer>();
            }

            if (siblingSr != null)
            {
                // Copy the GameObject Layer (Physics/Rendering Layer) from sibling
                // This is CRITICAL if the camera Culling Mask excludes "Default" (Layer 0)
                if (customObj.layer == 0) // Only override if not set in JSON
                {
                    customObj.layer = siblingSr.gameObject.layer;
                    if (Plugin.Config.DetailedLogs.Value)
                        Plugin.Log.LogInfo($"[Custom Objects] Copied GameObject Layer from {siblingSr.name}: {LayerMask.LayerToName(customObj.layer)} ({customObj.layer})");
                }

                sr.sortingLayerID = siblingSr.sortingLayerID;

                // Copy the material from the sibling to ensure compatibility
                if (siblingSr.material != null)
                {
                    sr.material = siblingSr.material;
                    if (Plugin.Config.DetailedLogs.Value)
                        Plugin.Log.LogInfo($"[Custom Objects] Copied material from {siblingSr.name}: {siblingSr.material.name} (shader: {siblingSr.material.shader.name})");
                }
                else
                {
                    // Fallback if sibling has no material
                    sr.material = new Material(Shader.Find("Sprites/Default"));
                    if (Plugin.Config.DetailedLogs.Value)
                        Plugin.Log.LogInfo($"[Custom Objects] Sibling has no material, using Sprites/Default");
                }

                if (Plugin.Config.DetailedLogs.Value)
                    Plugin.Log.LogInfo($"[Custom Objects] Copied Sorting Layer from {siblingSr.name}: {sr.sortingLayerName} ({sr.sortingLayerID})");
            }
            else
            {
                // No sibling found, force standard shader
                sr.material = new Material(Shader.Find("Sprites/Default"));
                if (Plugin.Config.DetailedLogs.Value)
                    Plugin.Log.LogInfo($"[Custom Objects] No sibling found, using Sprites/Default");
            }

            // Use the SortingOrder from the JSON. If 0, derive from pixel-space Y using the
            // same formula the game uses (verified: char at pixelY≈1200 → sortingOrder=-369
            // matching -(int)(pixelY / 3.25)).
            // IMPORTANT: desiredPosition.y is in Unity world units — multiply by HDScale to get
            // pixel Y so our depth is comparable to character sortingOrders from RefleshObject.
            float pixelY = GetPixelY(data, desiredPosition.y);
            if (data.SortingOrder != 0)
                sr.sortingOrder = data.SortingOrder;
            else
                sr.sortingOrder = -(int)(pixelY / 3.25f);

            // Y-based Z: negative so objects are pushed behind the camera plane.
            // Positive Z brings things closer to camera (on top); negative pushes them back.
            // Native objects use Z=0 or very slightly negative (-0.1, -0.2).
            // We use a stronger offset so the character (Z~0) always renders in front.
            var pos = customObj.transform.localPosition;
            customObj.transform.localPosition = new Vector3(pos.x, pos.y, pos.y * -0.01f);


            // Handle texture - Load sprite but don't assign yet (assign after activation)
            if (!string.IsNullOrEmpty(data.Texture) && data.Texture.ToLower() != "none" && data.Texture != "Native")
            {
                spriteToAssign = LoadCustomSprite(data.Texture);
                if (spriteToAssign != null)
                {
                    if (Plugin.Config.DetailedLogs.Value)
                        Plugin.Log.LogInfo($"[Custom Objects] Loaded sprite '{spriteToAssign.name}' for {customObj.name}");
                }
                else
                {
                    Plugin.Log.LogWarning($"[Custom Objects] FAILED to load sprite for '{data.Texture}'.");
                    // Only use debug sprite if enabled
                    if (Plugin.Config.DebugCustomObjects.Value)
                    {
                        spriteToAssign = CreateDebugSprite();
                        spriteToAssign.name = "DEBUG_TEXTURE_FAIL";
                        sr.color = Color.red;
                    }
                }
            }

            // Fallback for "none" texture
            if (spriteToAssign == null && Plugin.Config.DebugCustomObjects.Value)
            {
                spriteToAssign = CreateDebugSprite();
                spriteToAssign.name = "DEBUG_NO_TEXTURE";
                sr.color = new Color(0, 1, 1, 0.5f); // Cyan
            }
        }

        // MapSpriteHD Component — required for RegisterWithMapBGManager to add our object to
        // MapBGManagerHD.sprites, which makes SetSpriteSortingOrder(py) update our depth every frame.
        if (sr != null)
        {
            AddMapSpriteHD(customObj, sr, data);
        }


        // Active state - activate BEFORE assigning sprite (activation may clear sprite)
        customObj.SetActive(data.Active);

        // NOW assign the sprite AFTER object is activated
        if (sr != null && spriteToAssign != null)
        {
            sr.sprite = spriteToAssign;
            if (Plugin.Config.DetailedLogs.Value)
                Plugin.Log.LogInfo($"[Custom Objects] ✓ Assigned sprite '{spriteToAssign.name}' to {customObj.name} AFTER activation");

            if (Plugin.Config.DetailedLogs.Value)
            {
                Plugin.Log.LogInfo($"[Custom Objects] VERIFY: sr.sprite after final assignment: {(sr.sprite != null ? $"EXISTS (name='{sr.sprite.name}')" : "NULL")}");
                if (sr.sprite != null)
                {
                    Plugin.Log.LogInfo($"[Custom Objects]   - Sprite texture: {(sr.sprite.texture != null ? $"{sr.sprite.texture.name} ({sr.sprite.texture.width}x{sr.sprite.texture.height})" : "NULL")}");
                    Plugin.Log.LogInfo($"[Custom Objects]   - Sprite rect: {sr.sprite.rect}");
                    Plugin.Log.LogInfo($"[Custom Objects]   - Sprite bounds: {sr.sprite.bounds}");
                }
            }
        }
        else
        {
            if (spriteToAssign == null)
                Plugin.Log.LogWarning($"[Custom Objects] No sprite to assign for {customObj.name}");
        }

        // Return the created object, sprite, AND transform data for re-assignment
        return (customObj, spriteToAssign, desiredPosition, desiredScale, desiredRotation);
    }

    private static void AddMapSpriteHD(GameObject obj, SpriteRenderer sr, DiscoveredObject data)
    {
        try
        {
            var mapSpriteHDType = FindMapSpriteHDType();
            if (mapSpriteHDType != null)
            {
                var il2cppType = Il2CppType.From(mapSpriteHDType);

                // Component 1: visual sprite — linked to MapBGManagerHD.sprites
                var mapSpriteComponent = obj.AddComponent(il2cppType);
                SetProperty(mapSpriteComponent, "hasSpriteRenderer", true);
                SetProperty(mapSpriteComponent, "spriteRenderer", sr);
                SetProperty(mapSpriteComponent, "Size", new Vector3(100, 100, 0.2f));
                SetProperty(mapSpriteComponent, "gameObject", obj);
                SetProperty(mapSpriteComponent, "transform", obj.transform);
            }

            var mapEventObjectHDType = FindMapEventObjectHDType();
            if (mapEventObjectHDType != null)
            {
                var il2cppTypeEvent = Il2CppType.From(mapEventObjectHDType);

                // Component 2: event/collision object — linked to MapBGManagerHD.eventObjects
                var mapEventComponent = obj.AddComponent(il2cppTypeEvent);
                SetProperty(mapEventComponent, "positionSync", true);
                SetProperty(mapEventComponent, "visibleSync", true);
                SetProperty(mapEventComponent, "gameObject", obj);
                SetProperty(mapEventComponent, "transform", obj.transform);

                if (Plugin.Config.DetailedLogs.Value)
                    Plugin.Log.LogInfo($"[Custom Objects] Added MapSpriteHD + MapEventObjectHD components to {obj.name}");
            }
        }
        catch (System.Exception ex)
        {
            Plugin.Log.LogWarning($"[Custom Objects] Error adding Map components: {ex.Message}");
        }
    }

    private static Sprite LoadCustomSprite(string textureName)
    {
        try
        {
            if (textureName.EndsWith(".png")) textureName = textureName.Substring(0, textureName.Length - 4);

            // Use AssetLoader for unified and optimized loading
            Texture2D texture = AssetLoader.LoadTextureSync(textureName, "CustomObject");

            if (texture != null)
            {
                Sprite sprite = Sprite.Create(
                    texture,
                    new Rect(0, 0, texture.width, texture.height),
                    new Vector2(0.5f, 0.5f),
                    100f
                );
                sprite.name = textureName;
                return sprite;
            }
        }
        catch (System.Exception ex)
        {
            Plugin.Log.LogError($"[Custom Objects] Exception loading {textureName}: {ex.Message}");
        }

        return null;
    }

    private static Sprite CreateDebugSprite()
    {
        Texture2D texture = new Texture2D(64, 64);
        Color[] pixels = new Color[64 * 64];
        for (int i = 0; i < pixels.Length; i++) pixels[i] = Color.white;
        texture.SetPixels(pixels);
        texture.Apply();
        return Sprite.Create(texture, new Rect(0, 0, 64, 64), new Vector2(0.5f, 0.5f), 100f);
    }

    private static System.Type FindMapSpriteHDType()
    {
        return FindTypeInGameAssemblies("MapSpriteHD");
    }

    private static System.Type FindMapEventObjectHDType()
    {
        return FindTypeInGameAssemblies("MapEventObjectHD");
    }

    private static System.Type FindMapBGManagerType()
    {
        return FindTypeInGameAssemblies("MapBGManagerHD");
    }

    private static System.Type FindTypeInGameAssemblies(string typeName)
    {
        foreach (var assembly in System.AppDomain.CurrentDomain.GetAssemblies())
        {
            var assemblyName = assembly.GetName().Name;
            if (assemblyName == "GSD2" || assemblyName == "GSDShare" || assemblyName == "GSD1")
            {
                var type = assembly.GetType(typeName);
                if (type != null) return type;
            }
        }
        return null;
    }

    private static object FindMapBGManagerHD(GameObject sceneRoot)
    {
        try
        {
            // First, check if the PARENT is bgManagerHD (common structure: bgManagerHD/vk08_00(Clone))
            if (sceneRoot.transform.parent != null && sceneRoot.transform.parent.name == "bgManagerHD")
            {
                var mapBGManagerType = FindMapBGManagerType();
                if (mapBGManagerType != null)
                {
                    var il2cppType = Il2CppType.From(mapBGManagerType);
                    // IMPORTANT: Return the component directly - it's already the IL2CPP wrapper
                    var component = sceneRoot.transform.parent.gameObject.GetComponent(il2cppType);
                    if (component != null)
                    {
                        if (Plugin.Config.DetailedLogs.Value)
                            Plugin.Log.LogInfo($"[Custom Objects] Found MapBGManagerHD instance (parent of scene)");
                        return component;
                    }
                }
            }

            // Fallback: Search for bgManagerHD as a child
            Transform bgManager = sceneRoot.transform.Find("bgManagerHD");
            if (bgManager == null)
            {
                // Try recursive search
                bgManager = FindBgManagerRecursive(sceneRoot.transform);
            }

            if (bgManager != null)
            {
                // Get the MapBGManagerHD component
                var mapBGManagerType = FindMapBGManagerType();
                if (mapBGManagerType != null)
                {
                    var il2cppType = Il2CppType.From(mapBGManagerType);
                    var component = bgManager.gameObject.GetComponent(il2cppType);
                    if (component != null)
                    {
                        if (Plugin.Config.DetailedLogs.Value)
                            Plugin.Log.LogInfo($"[Custom Objects] Found MapBGManagerHD instance (child of scene)");
                        return component;
                    }
                }
            }
        }
        catch (System.Exception ex)
        {
            Plugin.Log.LogWarning($"[Custom Objects] Error finding MapBGManagerHD: {ex.Message}");
        }

        return null;
    }

    private static Transform FindBgManagerRecursive(Transform parent)
    {
        if (parent.name == "bgManagerHD")
        {
            return parent;
        }

        for (int i = 0; i < parent.childCount; i++)
        {
            var result = FindBgManagerRecursive(parent.GetChild(i));
            if (result != null)
            {
                return result;
            }
        }

        return null;
    }

    private static void RegisterWithMapBGManager(GameObject customObj, object mapBGManager)
    {
        try
        {
            var managerType = mapBGManager.GetType();
            if (Plugin.Config.DetailedLogs.Value)
                Plugin.Log.LogInfo($"[Custom Objects] MapBGManager type: {managerType.FullName}");

            var mapSpriteHDType = FindMapSpriteHDType();
            var mapEventObjectHDType = FindMapEventObjectHDType();

            if (mapSpriteHDType == null || mapEventObjectHDType == null)
            {
                Plugin.Log.LogWarning($"[Custom Objects] Could not find MapSpriteHD or MapEventObjectHD types");
                return;
            }

            // --- 1. Register to sprites list (visual) ---
            var spriteIl2cppType = Il2CppType.From(mapSpriteHDType);
            var spriteComponentPtr = customObj.GetComponent(spriteIl2cppType);

            if (spriteComponentPtr != null)
            {
                try
                {
                    var ptrProperty = spriteComponentPtr.GetType().GetProperty("Pointer");
                    if (ptrProperty != null)
                    {
                        var ptr = (IntPtr)ptrProperty.GetValue(spriteComponentPtr);
                        var mapSpriteHD = System.Activator.CreateInstance(mapSpriteHDType, ptr);

                        var spritesProp = managerType.GetProperty("sprites");
                        if (spritesProp != null)
                        {
                            var sprites = spritesProp.GetValue(mapBGManager);
                            if (sprites != null)
                            {
                                var addMethod = sprites.GetType().GetMethod("Add");
                                if (addMethod != null)
                                {
                                    addMethod.Invoke(sprites, new object[] { mapSpriteHD });
                                    var countProp = sprites.GetType().GetProperty("Count");
                                    var count = countProp?.GetValue(sprites) ?? 0;
                                    if (Plugin.Config.DetailedLogs.Value)
                                        Plugin.Log.LogInfo($"[Custom Objects] ✓ Registered {customObj.name} in sprites list (total: {count})");
                                }
                            }
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    Plugin.Log.LogError($"[Custom Objects] Failed to register to sprites list: {ex.Message}");
                }
            }

            // --- 2. Register to eventObjects list (physics/tangibility) ---
            var eventIl2cppType = Il2CppType.From(mapEventObjectHDType);
            var eventComponentPtr = customObj.GetComponent(eventIl2cppType);

            if (eventComponentPtr != null)
            {
                try
                {
                    var ptrProperty = eventComponentPtr.GetType().GetProperty("Pointer");
                    if (ptrProperty != null)
                    {
                        var ptr = (IntPtr)ptrProperty.GetValue(eventComponentPtr);
                        var mapEventObjectHD = System.Activator.CreateInstance(mapEventObjectHDType, ptr);

                        System.Reflection.MemberInfo eventObjectsProp = (System.Reflection.MemberInfo)managerType.GetField("eventObjects") ?? managerType.GetProperty("eventObjects");
                        if (eventObjectsProp != null)
                        {
                            object eventObjects = null;
                            if (eventObjectsProp is System.Reflection.PropertyInfo pi)
                                eventObjects = pi.GetValue(mapBGManager);
                            else if (eventObjectsProp is System.Reflection.FieldInfo fi)
                                eventObjects = fi.GetValue(mapBGManager);

                            if (eventObjects == null)
                            {
                                Plugin.Log.LogInfo($"[Custom Objects] 'eventObjects' list is null - initializing it ourselves");
                                var listType = typeof(Il2CppSystem.Collections.Generic.List<>).MakeGenericType(mapEventObjectHDType);
                                eventObjects = System.Activator.CreateInstance(listType);

                                if (eventObjectsProp is System.Reflection.PropertyInfo piSet)
                                    piSet.SetValue(mapBGManager, eventObjects);
                                else if (eventObjectsProp is System.Reflection.FieldInfo fiSet)
                                    fiSet.SetValue(mapBGManager, eventObjects);
                            }

                            if (eventObjects != null)
                            {
                                var addMethod = eventObjects.GetType().GetMethod("Add");
                                if (addMethod != null)
                                {
                                    addMethod.Invoke(eventObjects, new object[] { mapEventObjectHD });
                                    var countProp = eventObjects.GetType().GetProperty("Count");
                                    var count = countProp?.GetValue(eventObjects) ?? 0;
                                    if (Plugin.Config.DetailedLogs.Value)
                                        Plugin.Log.LogInfo($"[Custom Objects] ✓ Registered {customObj.name} in eventObjects list (total: {count})");
                                }
                            }
                        }
                        else
                        {
                            Plugin.Log.LogWarning($"[Custom Objects] 'eventObjects' field/property not found on MapBGManagerHD");
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    Plugin.Log.LogError($"[Custom Objects] Failed to register to eventObjects list: {ex.Message}");
                }
            }
        }
        catch (System.Exception ex)
        {
            Plugin.Log.LogError($"[Custom Objects] Failed to register {customObj.name}: {ex.Message}");
            if (Plugin.Config.DetailedLogs.Value)
            {
                Plugin.Log.LogError($"[Custom Objects] Stack trace: {ex.StackTrace}");
            }
        }
    }
    private static void SetProperty(object obj, string propertyName, object value)
    {
        var property = obj.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
        if (property != null && property.CanWrite)
        {
            property.SetValue(obj, value);
        }
    }

    /// <summary>
    /// Returns the game's HD scale factor (world units → pixel conversion).
    /// HDScale is a static int on MapBGManagerHD. Falls back to 4 if unavailable.
    /// </summary>
    private static int _cachedHDScale = -1;
    private static int GetHDScale()
    {
        if (_cachedHDScale > 0) return _cachedHDScale;
        try
        {
            var type = FindMapBGManagerType();
            if (type != null)
            {
                var prop = type.GetProperty("HDScale", BindingFlags.Public | BindingFlags.Static);
                if (prop != null) { _cachedHDScale = (int)prop.GetValue(null); return _cachedHDScale; }
                var field = type.GetField("HDScale", BindingFlags.Public | BindingFlags.Static);
                if (field != null) { _cachedHDScale = (int)field.GetValue(null); return _cachedHDScale; }
            }
        }
        catch { }
        _cachedHDScale = 4;
        return _cachedHDScale;
    }

    /// <summary>
    /// Converts a DiscoveredObject's position to pixel-space Y for depth sorting.
    /// Prefers NativeY (directly in pixel coords). Falls back to Position.Y × HDScale.
    /// </summary>
    private static float GetPixelY(DiscoveredObject data, float worldY)
    {
        if (data.NativeY != 0) return data.NativeY;
        return worldY * GetHDScale();
    }
}

[HarmonyPatch(typeof(MapBGManagerHD), "RefleshObject")]
public static class RefleshObjectPatch
{
    [HarmonyPostfix]
    public static void Postfix(int id, Vector2 pos, bool isVisible, int an, int eventMapNo, bool isInitVisible)
    {
        // Reserved for per-object diagnostic hooks
    }
}

// Patch to cache the map loading and trigger our object injection before MapBGManagerHD even sees it
[HarmonyPatch(typeof(MACHICON), "OnMapInit")]
public static class MACHICON_OnMapInitPatch
{
    public static string CurrentMapId = "";

    [HarmonyPostfix]
    public static void Postfix(MACHICON __instance)
    {
        if (__instance == null) return;

        string machiName = __instance.GetMapName();
        CurrentMapId = ParseMapIdFromMachiName(machiName);

        Plugin.Log.LogInfo($"[Custom Objects] ➔ MACHICON MapID resolved to: {CurrentMapId ?? "null"} (Raw: {machiName})");

        // Object injection is now handled in MachiLoader_Load_Patch
    }

    private static string ParseMapIdFromMachiName(string machiName)
    {
        // Example: "vk07 mno:1 evmno:3" -> Output: "vk07_01"
        if (string.IsNullOrEmpty(machiName)) return null;

        var parts = machiName.Split(' ');
        if (parts.Length >= 2)
        {
            string basePrefix = parts[0];

            for (int i = 1; i < parts.Length; i++)
            {
                if (parts[i].StartsWith("mno:"))
                {
                    if (int.TryParse(parts[i].Substring(4), out int mno))
                    {
                        return $"{basePrefix}_{mno:D2}";
                    }
                }
            }
            return basePrefix;
        }
        return machiName;
    }
}

[HarmonyPatch(typeof(MapBGManagerHD), "SetMap")]
public static class MapBGManagerHDSetMapPostfix
{
    [HarmonyPostfix]
    public static void Postfix(MapBGManagerHD __instance, object map, GameObject obj)
    {
        CustomObjectInsertion.SetMapBGManagerInstance(__instance);
        if (Plugin.Config.DetailedLogs.Value)
            Plugin.Log.LogInfo($"[Custom Objects] Cached MapBGManagerHD instance from SetMap() Postfix");

        if (obj != null)
        {
            if (Plugin.Config.DetailedLogs.Value)
                Plugin.Log.LogInfo($"[Custom Objects] SetMap fired for: {obj.name}");

            // This now only processes object discovery overrides, visual logic is bypassed inside TryCreateCustomObjects
            CustomObjectInsertion.TryCreateCustomObjects(obj);
        }
    }
}

// MACHICON.EventInit() calls native code that creates a fresh EVENTCON and populates it with
// the loaded MACHIDAT (mdat). By hooking it as a postfix we get the fully initialized object
// immediately — before the engine has processed any objects at all — which is ideal for injection.
[HarmonyPatch(typeof(MACHICON), "EventInit")]
public static class MachiLoader_Load_Patch
{
    /// <summary>The most recently loaded MACHIDAT from EventInit. Used by ObjectDiscovery.</summary>
    public static MACHIDAT LastLoadedMachiDat;

    [HarmonyPostfix]
    public static void Postfix(MACHICON __instance, EVENTCON __result)
    {
        Plugin.Log.LogInfo($"[Custom Objects] MACHICON.EventInit Postfix fired. EVENTCON: {(__result != null ? "valid" : "null")}");

        if (__result == null) return;
        if (__result.mdat == null)
        {
            Plugin.Log.LogWarning("[Custom Objects] EventInit returned EVENTCON with null mdat. Skipping.");
            return;
        }

        LastLoadedMachiDat = __result.mdat;

        string mapId = MACHICON_OnMapInitPatch.CurrentMapId;
        if (string.IsNullOrEmpty(mapId))
        {
            Plugin.Log.LogWarning("[Custom Objects] EventInit fired but CurrentMapId is empty. Skipping injection.");
            return;
        }

        var customObjects = CustomObjectInsertion.GetObjectsForMap(mapId);
        if (customObjects != null && customObjects.Count > 0)
        {
            Plugin.Log.LogInfo($"[Custom Objects] ➔ EventInit intercepted for {mapId}. Injecting {customObjects.Count} native objects...");
            CustomObjectInsertion.InjectNativeEventObjects(mapId, customObjects, __result.mdat);
        }
    }
}
