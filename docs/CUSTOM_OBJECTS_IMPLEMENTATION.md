# Map-Specific Object Configuration - Implementation Plan

## Goal

Add JSON configuration support so users can define custom objects per map without editing C# code.

## Configuration File Structure

### Location
`PKCore/CustomObjects/objects.json`

### Format
```json
{
  "vk07_01": {
    "objects": [
      {
        "name": "custom_table",
        "texture": "my_table.png",
        "position": { "x": 100, "y": 50, "z": 0 },
        "scale": { "x": 1, "y": 1, "z": 1 },
        "rotation": 0,
        "sortingOrder": 10,
        "hasCollision": true,
        "colliderSize": { "x": 100, "y": 80 },
        "isWalkable": false
      },
      {
        "name": "custom_carpet",
        "texture": "my_carpet.png",
        "position": { "x": 0, "y": 0, "z": -0.5 },
        "scale": { "x": 3, "y": 3, "z": 1 },
        "sortingOrder": 1,
        "hasCollision": false,
        "isWalkable": true,
        "walkSound": "carpet_step.wav"
      },
      {
        "name": "custom_chest",
        "texture": "my_chest.png",
        "position": { "x": -100, "y": 50, "z": 0 },
        "scale": { "x": 2, "y": 2, "z": 1 },
        "sortingOrder": 15,
        "hasCollision": true,
        "isWalkable": false
      }
    ]
  },
  "vk13_00": {
    "objects": [
      {
        "name": "shop_sign",
        "texture": "sign.png",
        "position": { "x": 0, "y": 100, "z": 0 },
        "scale": { "x": 1.5, "y": 1.5, "z": 1 },
        "hasCollision": false
      }
    ]
  }
}
```

### Field Descriptions
- **Map ID** (e.g., `vk07_01`): Extracted from scene name `vk07_01(Clone)`
- **name**: GameObject name (must be unique per map)
- **texture**: Filename in `PKCore/Textures/` (optional, uses fallback if missing)
- **position**: `{x, y, z}` relative to object folder (optional, defaults to `0,0,0`)
- **scale**: `{x, y, z}` scale multiplier (optional, defaults to `1,1,1`)
- **rotation**: Z-axis rotation in degrees (optional, defaults to `0`)
- **sortingOrder**: Render order (optional, defaults to `10`)
- **hasCollision**: Enable collision/blocking (optional, defaults to `false`)
- **colliderSize**: `{x, y}` collision box size (optional, auto-sized if not specified)
- **colliderOffset**: `{x, y}` collision box offset (optional, defaults to `0,0`)
- **isWalkable**: Can player walk through? (optional, defaults to `true` if no collision)
- **walkSound**: Sound file to play when walking over (optional, e.g., `"carpet_step.wav"`)
- **interactSound**: Sound file to play when interacting (optional, for future interactive objects)

---

## Proposed Changes

### New Files

#### `Models/CustomObjectConfig.cs`
Data models for JSON deserialization:
```csharp
public class CustomObjectsConfig
{
    public Dictionary<string, MapObjectsConfig> Maps { get; set; }
}

public class MapObjectsConfig
{
    public List<ObjectDefinition> Objects { get; set; }
}

public class ObjectDefinition
{
    public string Name { get; set; }
    public string Texture { get; set; }
    public Vector3Config Position { get; set; }
    public Vector3Config Scale { get; set; }
    public float Rotation { get; set; }
    public int SortingOrder { get; set; }
    
    // Collision & Movement
    public bool HasCollision { get; set; }
    public Vector2Config ColliderSize { get; set; }
    public Vector2Config ColliderOffset { get; set; }
    public bool IsWalkable { get; set; } = true;
    
    // Sound Effects
    public string WalkSound { get; set; }
    public string InteractSound { get; set; }
}

public class Vector3Config
{
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }
    
    public Vector3 ToVector3() => new Vector3(X, Y, Z);
}
```

#### `Utils/ObjectConfigLoader.cs`
Handles loading and parsing JSON:
```csharp
public static class ObjectConfigLoader
{
    private static CustomObjectsConfig _config;
    private static string ConfigPath => Path.Combine(Paths.PluginPath, "PKCore", "CustomObjects", "objects.json");
    
    public static void LoadConfig();
    public static List<ObjectDefinition> GetObjectsForMap(string mapId);
    public static bool HasObjectsForMap(string mapId);
}
```

### Modified Files

#### `Patches/CustomObjectInsertion.cs`
**Changes:**
1. Remove hardcoded test object
2. Add `GetMapIdFromScene(GameObject sceneRoot)` method
3. Modify `TryCreateCustomObjects()` to:
   - Extract map ID from scene name
   - Load objects for that map from config
   - Create each object from definition
4. Update `CreateCustomObject()` to accept `ObjectDefinition` parameter
5. Apply position, scale, rotation, sortingOrder from definition

**New Methods:**
```csharp
private static string GetMapIdFromScene(GameObject sceneRoot)
{
    // Extract "vk07_01" from "vk07_01(Clone)"
    string name = sceneRoot.name;
    return name.Replace("(Clone)", "").Trim();
}

private static void CreateObjectFromDefinition(Transform objectFolder, ObjectDefinition def)
{
    // Create GameObject with all properties from definition
}
```

#### `Plugin.cs`
**Changes:**
1. Call `ObjectConfigLoader.LoadConfig()` during initialization
2. Create default `objects.json` if it doesn't exist

---

## Implementation Steps

### Phase 1: Data Models & Config Loading
- [x] Create `Models/CustomObjectConfig.cs`
- [ ] Create `Utils/ObjectConfigLoader.cs`
- [ ] Add JSON parsing (use `System.Text.Json` or `Newtonsoft.Json`)
- [ ] Add config validation

### Phase 2: Update Object Creation
- [ ] Modify `CustomObjectInsertion.cs` to use config
- [ ] Add `GetMapIdFromScene()` method to extract map ID
- [ ] Modify `TryCreateCustomObjects()` to load from config
- [ ] Refactor `CreateCustomObject()` to accept `ObjectDefinition`
- [ ] Apply position, scale, rotation from config
- [ ] Apply sortingOrder from config

### Phase 2.5: Collision & Sound Research
- [ ] Use Unity Explorer to check existing objects for Collider components
- [ ] Research how game handles player collision (Rigidbody2D? Collider2D?)
- [ ] Identify collision layers and tags used by game
- [ ] Research sound system (AudioSource? Custom sound manager?)
- [ ] Find examples of walkable surfaces with sound effects
- [ ] Document collision component requirements

### Phase 2.6: Implement Collision (if supported)
- [ ] Add BoxCollider2D or appropriate collider component
- [ ] Apply collider size and offset from config
- [ ] Set collision layer appropriately
- [ ] Test player collision blocking
- [ ] Handle walkable vs non-walkable objects

### Phase 2.7: Implement Sound Effects (if supported)
- [ ] Research game's audio system
- [ ] Add AudioSource component if needed
- [ ] Load sound files from config
- [ ] Trigger walk sounds when player enters area
- [ ] Test sound playback

### Phase 3: Default Config & Integration
- [ ] Create default `objects.json` template
- [ ] Auto-create config file if missing
- [ ] Update `Plugin.cs` initialization
- [ ] Add config reload support (optional)

### Phase 4: Testing & Documentation
- [ ] Test with multiple maps
- [ ] Test with multiple objects per map
- [ ] Test missing textures (fallback)
- [ ] Update README with configuration guide
- [ ] Create example configurations

---

## Verification Plan

### Test Cases
1. **Empty config**: No objects created
2. **Single map, single object**: Object appears correctly
3. **Single map, multiple objects**: All objects appear
4. **Multiple maps**: Correct objects per map
5. **Missing texture**: Fallback texture used
6. **Invalid position/scale**: Defaults applied
7. **Map not in config**: No objects created (no error)

### Manual Testing
1. Create test config with 2-3 maps
2. Enter each map and verify objects
3. Check Unity Explorer for correct hierarchy
4. Verify positions, scales, textures

---

## Migration from Current System

**Current**: Hardcoded test object at (0,0,0)  
**After**: Config-driven, map-specific objects

**Backward Compatibility**:
- If `objects.json` doesn't exist, create default with test object
- Keep `EnableCustomObjects` config option

---

## Example Default Config

```json
{
  "vk07_01": {
    "objects": [
      {
        "name": "example_object",
        "texture": "custom_object_test.png",
        "position": { "x": 0, "y": 0, "z": 0 },
        "scale": { "x": 5, "y": 5, "z": 1 },
        "rotation": 0,
        "sortingOrder": 31
      }
    ]
  }
}
```

---

## Next Steps After Implementation

1. **Interactive Objects**: Add `isInteractive`, `eventId` fields
2. **Animations**: Add `animationId` field
3. **Conditional Spawning**: Add `requiresFlag`, `requiresItem` fields
4. **Hot Reload**: Reload config without restarting game
