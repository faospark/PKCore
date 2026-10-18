# Sajah Village Rare Item Shop Early Unlock & Runtime Map Data Overrides

## Overview
In **Suikoden II HD Remaster**, the village of Sajah (map ID `vj17`) features a hidden / very late-game rare item vendor situated in the upper-right corner of the multi-shop building (`vj17_01`). Under vanilla rules, this vendor only becomes accessible after defeating the Beast Rune (Event Flag `143`, bit `0x01`).

This document details:
1. **The Script & Entity Architecture** behind the vendor lock.
2. **Exact Asset/JSON Edits** for manual bundle editing via UABEA.
3. **Mod-Based Runtime Overrides (PKCore)** to export and hot-reload map event JSONs at runtime without ever touching Unity asset bundles.

---

## 1. Map & Script Analysis (`vj17`)

- **Target Submap**: `vj17_01` (Sajah Village multi-shop interior, stored at `mapeventdat[1]` in `MACHIDAT.eventdata`).
- **Vendor NPC Sprite**: `mapeventdat[1].eventobj[3]`
  - Position: `x: 45, y: 26`
  - Face Sprite / Model (`fpno`): `65174` (Rare shop merchant)
  - Default Visibility: `"disp": 0` (Hidden)
- **Counter Interaction Hitbox**: `mapeventdat[1].eventobj[7]`
  - Position: `x: 44, y: 28`
  - Collision Area: `w: 2, h: 0`
  - Object Type: `4` (`EVENT_TALK` trigger zone)
  - Default Visibility: `"disp": 0` (Inactive)
- **Map Initialization Script**: `mapeventdat[1].eventdat[2]`
  - Condition (`eventForm`): `[3, 143, 1, 255, 254]`
    - `3` = Check event flag
    - `143` = Flag ID (Beast Rune defeated / End-game state)
    - `1` = Bit mask (`0x01`)
    - `255, 254` = Terminator / End of condition
  - Action (`eventCom`): Executes opcodes that toggle `disp = 1` on `eventobj[3]` and `eventobj[7]`.
- **Shop Dialogue & Menu Triggers**: `mapeventdat[1].eventdat[10]` and `eventdat[11]`
  - Form: `[3, 143, 1, 5, 11, 255, 254]` and `[3, 143, 1, 5, 15, 255, 254]`
  - Condition checks flag `143, 1` before allowing the shop dialogue and buy menu to open.

---

## 2. Manual Bundle Editing (UABEA / JSON Method)

Target JSON file: `D:\Modding\suikodum\Mobobehaviour\vj17.json`

To activate the hidden late-game item shop vendor in Sajah Village (`vj17`) early without defeating the Beast Rune, make the following replacements across 5 fields in `D:\Modding\suikodum\Mobobehaviour\vj17.json`:

### 1. Enable the Vendor Sprite
At line 3128–3130 (`mapeventdat[1].eventobj[3]`):
```diff
          {
            "otyp": 1,
-           "disp": 0,
+           "disp": 1,
            "spd": 4,
            "wt": 255,
            "ano": 0,
            "ityp": 0,
            "fpno": 65174,
```

### 2. Enable the Counter Interaction Tile
At line 3188–3190 (`mapeventdat[1].eventobj[7]`):
```diff
          {
            "otyp": 4,
-           "disp": 0,
+           "disp": 1,
            "spd": 4,
            "wt": 255,
            "ano": 0,
            "ityp": 0,
            "fpno": 0,
            "ozok": 0,
            "pri": 0,
            "x": 44,
            "y": 28,
```

### 3. Make the Shop Setup Script Run Unconditionally
At lines 3622–3629 (`mapeventdat[1].eventdat[2]`):
```diff
          {
            "etyp": 2,
            "eventForm": [
-             3,
-             143,
-             1,
+             0,
              255,
              254
            ],
```
*(Opcode 0 is the unconditional pass condition, matching eventdat[0]).*

### 4. Enable Counter Talk Interaction 1
At lines 3850–3859 (`mapeventdat[1].eventdat[10]`):
```diff
          {
            "etyp": 1,
            "eventForm": [
-             3,
-             143,
-             1,
              5,
              11,
              255,
              254
            ],
```

### 5. Enable Counter Talk Interaction 2
At lines 3883–3892 (`mapeventdat[1].eventdat[11]`):
```diff
          {
            "etyp": 1,
            "eventForm": [
-             3,
-             143,
-             1,
              5,
              15,
              255,
              254
            ],
```

---

### How to Import Back Into the Asset Bundle
1. Open **UABEA** (Unity Asset Bundle Extractor Avalonia).
2. Open the `.bundle` file containing the `vj17` scene/assets.
3. Locate and select the `MonoBehaviour` `vj17` asset.
4. Click **Plugins** -> **Import Dump** (or Import Text/JSON).
5. Select your edited `D:\Modding\suikodum\Mobobehaviour\vj17.json`.
6. Click **File** -> **Save** (and save/replace the bundle file).

When you enter the Sajah Village item shop, the second vendor on the left counter will be present and interactable immediately.

---

## 3. Mod-Based Runtime Export & Overrides (No Bundle Edits)

### Is it possible to export and override these JSONs via PKCore?
**Yes, 100%.** 

In Unity IL2CPP:
1. Unity AssetBundles are only read once when `MachiLoader.LoadMACHIDAT` deserializes the `ScriptableObject`.
2. Once loaded, the resulting `MACHIDAT` object is held in normal memory.
3. PKCore (via BepInEx and `Il2CppInterop`) has full read/write access to all properties: `MACHIDAT.eventdata.mapeventdat[mno].eventobj` and `eventdat`.
4. PKCore already hooks `MACHICON.EventInit` in `PKCore.Patches.CustomObjectInsertion`.

### Architecture: How to Implement in PKCore

#### 1. Runtime JSON Exporter
Whenever the player enters a map, PKCore can dump the loaded `MACHIDAT.eventdata` directly to a local JSON file:

```csharp
[HarmonyPatch(typeof(MACHICON), "EventInit")]
public static class MapDataDumpPatch
{
    [HarmonyPostfix]
    public static void Postfix(MACHICON __instance, EVENTCON __result)
    {
        if (__result == null || __result.mdat == null) return;
        
        string mapId = MACHICON_OnMapInitPatch.CurrentMapId; // e.g. "vj17_01"
        string dumpDir = Path.Combine(Paths.PluginPath, "PKCore", "MapDumps");
        Directory.CreateDirectory(dumpDir);
        
        string dumpPath = Path.Combine(dumpDir, $"{mapId}.json");
        if (!File.Exists(dumpPath))
        {
            // Dump JSON using System.Text.Json or custom serializer
            ExportMapEventsToJson(__result.mdat, dumpPath);
            Plugin.Log.LogInfo($"[MapExport] Exported map event data to {dumpPath}");
        }
    }
}
```

#### 2. Runtime JSON Override Loader
Similarly, PKCore can check for an external JSON file inside `BepInEx/plugins/PKCore/MapOverrides/{mapId}.json`. If present, it deserializes the JSON and replaces or mutates `__result.mdat.eventdata.mapeventdat`:

```csharp
string overridePath = Path.Combine(Paths.PluginPath, "PKCore", "MapOverrides", $"{mapId}.json");
if (File.Exists(overridePath))
{
    Plugin.Log.LogInfo($"[MapOverride] Applying JSON override for {mapId}...");
    ApplyJsonOverrideToMachiDat(__result.mdat, overridePath);
}
```

#### 3. Lightweight In-Memory C# Patch (Zero Files Needed)
For specific tweaks like the Sajah Village vendor, you do not even need an external JSON file. You can simply modify the in-memory `MACHIDAT` directly when `vj17` loads:

```csharp
[HarmonyPatch(typeof(MACHICON), "EventInit")]
public static class SajahShopUnlockPatch
{
    [HarmonyPostfix]
    public static void Postfix(MACHICON __instance, EVENTCON __result)
    {
        if (__result == null || __result.mdat?.eventdata?.mapeventdat == null) return;
        
        string mapId = MACHICON_OnMapInitPatch.CurrentMapId;
        if (string.IsNullOrEmpty(mapId) && __instance != null)
        {
            string raw = __instance.GetMapName();
            if (!string.IsNullOrEmpty(raw))
            {
                mapId = raw.Split(' ')[0];
            }
        }

        // Match any submap of vj17 or the underlying vj17 asset itself (vj17.json)
        bool isVj17 = (!string.IsNullOrEmpty(mapId) && mapId.StartsWith("vj17", System.StringComparison.OrdinalIgnoreCase))
            || string.Equals(__result.mdat.name, "vj17", System.StringComparison.OrdinalIgnoreCase);

        if (!isVj17) return;
        if (__result.mdat.eventdata.mapeventdat.Count <= 1) return;

        var interior = __result.mdat.eventdata.mapeventdat[1];

        // 1. Force vendor sprite visible
        if (interior.eventobj.Length > 3 && interior.eventobj[3] != null)
            interior.eventobj[3].disp = 1;

        // 2. Force counter interaction trigger active
        if (interior.eventobj.Length > 7 && interior.eventobj[7] != null)
            interior.eventobj[7].disp = 1;

        // Neutralize room initialization hide check (prevents re-hiding if flag 143 is off)
        if (interior.eventdat.Length > 2 && interior.eventdat[2] != null)
            interior.eventdat[2].eventForm = new byte[] { 0, 255, 254 };

        // 3. Bypass flag 143 in interaction scripts
        if (interior.eventdat.Length > 10 && interior.eventdat[10] != null)
            interior.eventdat[10].eventForm = new byte[] { 5, 11, 255, 254 };

        if (interior.eventdat.Length > 11 && interior.eventdat[11] != null)
            interior.eventdat[11].eventForm = new byte[] { 5, 15, 255, 254 };

        Plugin.Log.LogInfo("[PKCore] Sajah Village rare item vendor unlocked early!");
    }
}
```

### Advantages Over Bundle Editing
- **Game Updates**: Game patches or verifying Steam files will never overwrite the changes.
- **Portability**: Distributable as a standard BepInEx / PKCore plugin without multi-gigabyte asset bundle redistributions.
- **Clean Toggling**: Can be toggled on/off in `ModConfiguration.cs` via a simple config boolean.
