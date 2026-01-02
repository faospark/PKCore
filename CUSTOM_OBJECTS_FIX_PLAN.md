# Fix Custom Object Invisibility Issue

## Root Cause

Custom objects are invisible because **UnitySpriteRendererPatch** interferes with sprite assignment.

**The Flow:**
1. Custom object created with `AddComponent<SpriteRenderer>()`
2. Sprite loaded: `spriteToAssign = LoadCustomSprite(data.Texture)`
3. Sprite assigned: `sr.sprite = spriteToAssign` (line 451)
4. **UnitySpriteRendererPatch intercepts** and tries to replace it
5. Patch might fail or interfere, causing invisibility

## Solution

Add a **marker component** to custom objects that sprite replacement patches can check.

### Approach 1: Custom Marker Component (Recommended)

**Create a marker:**
```csharp
public class CustomObjectMarker : MonoBehaviour
{
    // Empty marker component
}
```

**In CustomObjectInsertion.cs:**
```csharp
// Add marker before adding SpriteRenderer
customObj.AddComponent<CustomObjectMarker>();
sr = customObj.AddComponent<SpriteRenderer>();
```

**In UnitySpriteRendererPatch.cs:**
```csharp
// Check for marker at the start
if (__instance.GetComponent<CustomObjectMarker>() != null)
    return; // Skip custom objects
```

### Approach 2: Path-Based Detection (Current, Too Broad)

The old approach checked the GameObject path, but it was too broad and blocked legitimate game objects.

**Old code (removed):**
```csharp
bool isCustomObject = path.Contains("/object/") && path.Contains("MapBackGround");
```

**Problem:** Blocked game objects like `MapBackGround/.../object/event_28/ev28_wall`

### Approach 3: Name-Based Detection

Check if the object name starts with a specific prefix:

**In CustomObjectInsertion.cs:**
```csharp
customObj.name = "CUSTOM_" + data.Name;
```

**In UnitySpriteRendererPatch.cs:**
```csharp
if (__instance.gameObject.name.StartsWith("CUSTOM_"))
    return;
```

## Recommended Implementation

Use **Approach 1** (marker component) as it's the cleanest and most reliable.

### Steps:

1. Create `CustomObjectMarker.cs` component
2. Register it with IL2CPP in `Plugin.cs`
3. Add marker to custom objects in `CustomObjectInsertion.cs`
4. Check for marker in `UnitySpriteRendererPatch.cs`
5. Check for marker in `GRSpriteRendererPatch.cs` (if needed)
6. Test custom object visibility

## Testing

1. Enable `EnableCustomObjects = true`
2. Create a test object in `objects.json`
3. Verify object is visible
4. Verify sprite is correctly assigned
5. Verify normal texture replacement still works (wall sprites, etc.)
