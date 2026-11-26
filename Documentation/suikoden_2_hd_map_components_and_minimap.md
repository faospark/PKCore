# Suikoden II HD Map Architecture (`MapBGManagerHD`, `Map*HD`, & `MiniMapDataCmp`)

## Overview

In *Suikoden II HD Remaster*, every map runs two parallel layers at the same time:

1. **The legacy PS1 logic layer (`MACHICON` / `MACHIDAT`):** Handles tile collision, warps, `eventobj` positions, and event bytecode (`eventForm` / `eventCom`).
2. **The Unity HD presentation layer (`MapBGManagerHD` + `GSDShare` `Map*HD` components):** Renders HD backgrounds, depth-sorts sprites every frame, animates doors, toggles castle-level/story props, and draws the minimap.

Understanding how `MapBGManagerHD` (`GSD2.dll`) bridges those two layers is essential whenever a mod **injects custom objects**, **unlocks cut/blocked rooms**, **replaces map textures**, or **modifies minimap bounds**. If you only patch `MACHIDAT`, the Unity HD layer will often leave doors visually shut, hide/unhide props based on its own flag checks, or draw injected sprites at the wrong depth.

---

## 1. How the Legacy Map & HD Scene Connect (`MapBGManagerHD`)

`MapBGManagerHD` (in `Suisource/GSD2/GSD2/MapBGManagerHD.cs`) inherits `MapBGManager` and owns all HD components in the currently loaded map prefab:

- **`sprites` (`List<MapSpriteHD>`):** Every visual map prop and sprite registered for per-frame Y-sorting.
- **`eventObjects` (`List<MapEventObjectHD>`):** Every object synced with `MACHIDAT.eventobj[]` (positions, visibility, doors).
- **`animObjects` (`List<MapObjAnimHD>`):** Frame-based HD sprite animations (doors, torches, water, flags).
- **`flagCheckObjects` (`List<MapFlagCheckObjectHD>`):** Unity-side prop toggles that check story flags, day/night, and **HQ Castle Level** every frame.
- **`scrolls` (`List<MapBGScroll>`):** Parallax/cloud/water background layers.
- **`atomList` (`List<CriAtomSource>`):** Map ambient sound emitters.

### Key `MapBGManagerHD` Methods (`GSD2.dll` / `script.json`)

| Method | VA | What It Actually Does |
| :--- | :--- | :--- |
| `SetMap(MAP map, GameObject obj)` | `0x18148FF90` | Binds the legacy `MAP` struct to the loaded Unity map prefab. |
| `SetSpriteSortingOrder(int py)` | `0x1814904A0` | Runs **every frame** over `sprites` (`List<MapSpriteHD>`), updating `SpriteRenderer.sortingOrder` relative to player Y (`py`) and `PriorityOffset`. |
| `RefleshObject(int id, Vector2 pos, bool isVisible, int an, int eventMapNo, bool isInitVisible)` | — | Syncs `MACHIDAT.eventobj[id]` state into the matching `MapEventObjectHD` (`FindEventObject(id)`). |
| `OnDoor(int tatemonoID, int type)` | `0x18148F470` | Triggers `MapEventObjectHD.OnDoor(isOpen)` to play `MapObjAnimHD` door animations. |
| `CreateRoomMask(int ano, int vno, int mno, Vector2 point)` | `0x18148DBA0` | Spawns interior room cutout masks (`MapCovermaskHD`) when entering buildings. |
| `SetNight()` / `ClearNight()` | — | Switches `IsNight` and applies `nightShaderSetting` across the map. |

---

## 2. The Components That Actually Affect Modding

### 2.1 `MapSpriteHD` (266 JSONs in `Suikoden2\`) — Depth Sorting & Custom Textures
Defined in `Suisource/GSDShare/GSDShare/MapSpriteHD.cs` (inherits `MapComponentHDBase`).

- **Why it matters for custom object injection:**
  - `MapBGManagerHD.SetSpriteSortingOrder(int py)` recalculates `sortingOrder` every frame for everything in `MapBGManagerHD.sprites`.
  - **Cross-reference ([S2CustomObjectInsertionPatch.cs](file:///d:/Appz/SuikodenModding/PKCore/Patches/S2CustomObjectInsertionPatch.cs#L555-L610)):** When injecting a custom object or NPC into a map, `PKCore` attaches a `MapSpriteHD` component (`hasSpriteRenderer = true`, `spriteRenderer = sr`, `Size = (100, 100, 0.2f)`) and registers it into `MapBGManagerHD.sprites`. Without `MapSpriteHD`, the object will not depth-sort against the player as you walk in front of or behind it.
  - **Gotcha (`Awake` overwrite):** `MapSpriteHD.Awake()` (`0x18226D480`) overwrites `sortingOrder` and transform values on initialization, which is why `S2CustomObjectInsertionPatch` stores and re-applies custom transforms/sorting *after* `Awake()`.
- **Why it matters for custom textures:**
  - **Cross-reference ([MapSpriteHDPatch.cs](file:///d:/Appz/SuikodenModding/PKCore/Patches/MapSpriteHDPatch.cs#L13-L52)):** Overworld and map props with `MapSpriteHD` often use `Renderer.material.mainTexture` directly rather than a `SpriteRenderer` sprite. Standard `SpriteRenderer` texture hooks miss them, so `PKCore` postfixes `MapSpriteHD.Awake` to replace both `renderer.material.mainTexture` and `spriteRenderer.sprite`.
- **Key JSON / Runtime Fields:**
  - `objID` (`ID` getter at `0x1803BF9A0`) — Links to `MACHIDAT.eventobj[objID]`.
  - `priorityOffset` (`Vector3`, e.g. `y: 60.0`) — Constant Y/Z bias applied in `SetSortingOrder(int n, bool isLadder)` (`0x18226D920`).
  - `parentPrioritySprite` / `parentPriorityOffset` — Locks a child prop's sorting order to a parent sprite (used for wall hangings, tables, signs).
  - `controlChildSortingOrder`, `specialLadder`.

### 2.2 `MapEventObjectHD` (99 JSONs) & `MapObjAnimHD` (50 JSONs) — Doors, Blockers, & Synced Objects
Defined in `Suisource/GSDShare/GSDShare/MapEventObjectHD.cs` and `MapObjAnimHD.cs`.

- **Why it matters for room restoration & object injection:**
  - Even if you patch `MACHIDAT` (`eventForm` / `eventCom` / `eventobj`) to unlock a room or show an object, `MapEventObjectHD` controls the HD Unity GameObject's visibility, position, and door animation state:
    - `SetPosition(Vector2 pos, bool isVisible, bool isSetFromInitEvent)` (`0x182260FB0`) — Syncs transform and active state when `positionSync` / `visibleSync` are enabled.
    - `ExclusiveCheck(bool isVisible)` (`0x182260E20`) — Toggles `ExclusiveObject` / `initDisableObject` (used to swap or hide blockers/props).
    - `OnDoor(bool isOpen)` (`0x182260EA0`) — Plays `doorOpenAnimationID` or `doorCloseAnimationID` from `MapObjAnimHD.animationInfo[]`.
  - **Cross-reference ([S2CustomObjectInsertionPatch.cs](file:///d:/Appz/SuikodenModding/PKCore/Patches/S2CustomObjectInsertionPatch.cs#L612-L625)):** `PKCore` attaches `MapEventObjectHD` (`positionSync = true`, `visibleSync = true`) and registers it in `MapBGManagerHD.eventObjects` (initializing the `List<MapEventObjectHD>` if null) so injected objects stay synced with map state.
- **Observed Data Across the 99 `MapEventObjectHD` JSONs (`Suikoden2\`):**
  - **Doors (`doorObject = 1`):** Most standard doors use `doorOpenAnimationID = 1`, `doorCloseAnimationID = 2` (or `0 / 1`). Multi-door maps (e.g. castles/mansions) use distinct pairs: `6 / 7`, `12 / 13`, `19 / 20`, and `21 / 22`.
  - **Dynamic Add-On Objects (`addObj = 1`):** `MapEventObjectHD #21926.json`, `#21929.json`, `#22009.json` use `objID = 22, 23, 24` with matching `eventNo = 22, 23, 24`.

### 2.3 `MapFlagCheckObjectHD` (`GSD2.dll`) — Unity-Side Flag & Castle Level Toggles
Defined in `Suisource/GSD2/GSD2/MapFlagCheckObjectHD.cs`.

- **`OnFrameUpdate(MapBGManagerHD bgManager, bool isNight)` (`0x181492230`):** Runs every frame to show/hide HD map props independently of `MACHIDAT` bytecode.
- **Fields checked:**
  - `flagParam1`, `flagParam2`, `command` — Story event flag checks.
  - `night` — Day/night visibility toggle.
  - `bcon16Check` — Checks `bcon[16]` / HQ state.
  - `baseLevelCheck` — Checks **Dunan Castle HQ Level (`base_lv`)**.
- **Cross-reference ([suikoden_2_castle_level_upgrade_mechanics.md](suikoden_2_castle_level_upgrade_mechanics.md)):** Visual castle upgrades (banners, statues, repaired structures) in the HD layer are toggled here via `baseLevelCheck`, not just in `MACHIDAT` `eventobj` display conditions.

### 2.4 `MapInfoHD` (23 JSONs) — Footstep Sounds, Shadows, Reverb, & Blur
Defined in `Suisource/GSDShare/GSDShare/MapInfoHD.cs`.

- **Runtime Methods:**
  - `GetDefaultFootSound(string mapID)` (`0x182261560`) & `SetDefaultFootSoundType(string mapID)` (`0x182261700`)
  - `ColliderCheck(Vector3 pos, out MapFootSound.Type soundID, bool isOverLayer)` (`0x1822612B0`) — Overrides footstep audio when walking over bridges, water, carpet, or stone colliders.
  - `ShadowCheck(Vector3 pos)` (`0x1822618F0`) — Determines whether character shadows render at `pos`.
- **Observed Values Across All 23 `MapInfoHD` JSONs (`Suikoden2\`):**
  - `commonSetting.defaultFootSoundType`: Ranges `0`–`6` (`1` is most common; `0`, `2`, `3`, `4`, `5`, `6` appear on specific terrain maps).
  - `commonSetting.reverbSetting`: `0` (dry) or `1` (cave/hall echo — observed on `MapInfoHD #29203.json` and `MonoBehaviour #1122.json`).
  - `shadowSetting.Offset`: Consistently `{ x: 0.0, y: -3.0 }`, `Rot: 30.0`, `Scale: { x: 1.0, y: 1.0 }`.
  - `blurSetting`: `rate = 0.002`, `wipe = 0.6` (`0.63` on `MapInfoHD.json`, `0.67` on `MapInfoHD #19344.json`).

### 2.5 `MiniMapDataCmp` (35 JSONs) & `MiniMapDataReplace` — Minimap Bounds & Party Swaps
Defined in `Suisource/GSDShare/GSDShare/MiniMapDataCmp.cs` and `MiniMapDataReplace.cs`, consumed by `GSD2.dll`'s `MiniMap` (`InitMiniMap` at `0x18104838`, `MainMiniMap` at `0x181048BC`).

- **`MiniMapDataCmp`:**
  - `customRectList[]` — All **35** non-empty minimap configs (`MiniMapDataCmp #*.json` and `MonoBehaviour #11301`–`11455.json`) define `{ x, y, width, height }` bounding boxes (from `380x456` for small interiors up to `1440x1096` for large areas) queried by `GetCustoMRect(Vector2 pos, out Rect rc)` (`0x1822D1B10`).
  - `dataList[]` — Sub-region visibility entries toggled via `SetVisible(int id, bool isVisible)` (`0x1822D1D30`).
- **`MiniMapDataReplace.Set(Func<int, bool> isMember)`:** Dynamically swaps minimap graphics (`m_target`, `m_default`, `m_data`) based on recruited/party member checks.

### 2.6 Other Scene Components (`MapObjSwapHD`, `TreeSpriteScript`, `MapBGScroll`)
- **`MapObjSwapHD` (`GSDShare`):** Swaps active HD objects on `OnEnable` / `OnDisable`.
- **`TreeSpriteScript` (14 JSONs):** Wind sway parameters (`maskTex`, `windRate`, `waveSpeed`, `wavePower`).
- **`MapBGScroll` (13 JSONs):** Scrolling sky/water layers (`speed`, `offset`, `autoScroll`).

---

## 3. Harmonization with Existing `PKCore` Documentation

| Existing Document | How It Connects to the HD Map Layer |
| :--- | :--- |
| [suikoden_2_room_item_restoration_whitepaper.md](suikoden_2_room_item_restoration_whitepaper.md) | Physical in-room placement of `room_item[8]` antiques in Riou's Bedroom (`vd06`) requires `MapSpriteHD` (in `MapBGManagerHD.sprites`) for Y-sorting and `MapEventObjectHD` (in `MapBGManagerHD.eventObjects`) for position/visibility sync. |
| [suikoden_2_castle_level_upgrade_mechanics.md](suikoden_2_castle_level_upgrade_mechanics.md) | `MapFlagCheckObjectHD.OnFrameUpdate` checks `baseLevelCheck` and `bcon16Check` every frame to toggle HD castle visual upgrades independently of `MACHIDAT`. |
| [custom_textures_guide.md](custom_textures_guide.md) | Map props with `MapSpriteHD` use `Renderer.material.mainTexture` directly, requiring the dedicated `MapSpriteHD.Awake` hook in [MapSpriteHDPatch.cs](../Patches/MapSpriteHDPatch.cs). |
| [sound_modding_guide.md](sound_modding_guide.md) | `MapInfoHD` (`defaultFootSoundType`, `ColliderCheck`, `reverbSetting`) and `MapBGManagerHD.atomList` (`List<CriAtomSource>`) govern map-level footsteps, cave/hall reverb, and ambient CriWare emitters. |
| [dunan_castle_hq_forensic_research.md](dunan_castle_hq_forensic_research.md) | HQ submap access, interior cutouts (`MapBGManagerHD.CreateRoomMask`), and door states (`MapEventObjectHD.OnDoor` / `ExclusiveCheck`) must stay synced with `MACHIDAT` when restoring HQ rooms. |

---

## 4. Modding Opportunities

1. **Physical `room_item[8]` Antique Placement in Riou's Bedroom (`vd06`):**
   - Attach both `MapSpriteHD` (registered in `MapBGManagerHD.sprites`) and `MapEventObjectHD` (`positionSync = true`, `visibleSync = true`, registered in `MapBGManagerHD.eventObjects`) using the pattern in [S2CustomObjectInsertionPatch.cs](../Patches/S2CustomObjectInsertionPatch.cs#L555-L625) so placed ornaments/paintings depth-sort cleanly as Riou walks past them.
2. **Syncing HD Doors & Blockers on Restored/Unlocked Submaps:**
   - Hook `MapEventObjectHD.ExclusiveCheck` (`0x182260E20`) and `MapEventObjectHD.OnDoor` (`0x182260EA0`) when unlocking cut or story-gated rooms in `MACHIDAT` so Unity's HD door/wall GameObjects actually open and hide.
3. **Castle Visual Upgrade Overrides (`MapFlagCheckObjectHD`):**
   - Hook `MapFlagCheckObjectHD.OnFrameUpdate` (`0x181492230`) to force or preview `baseLevelCheck`, `bcon16Check`, or `night` prop states in Dunan Castle without waiting for story progression.
4. **Expanded Minimap Bounds & Custom Room Icons:**
   - Hook `MiniMapDataCmp.GetCustoMRect` (`0x1822D1B10`) and `MiniMapDataCmp.SetVisible` (`0x1822D1D30`) when opening inaccessible submaps so the minimap doesn't clip or hide the restored area.
5. **Map Atmosphere, Footsteps, & Reverb Fixes:**
   - Postfix `MapBGManager.set_MapInfoHD` (`0x180561470`) to toggle `shadowSetting.enable`, `commonSetting.floorReflection`, `commonSetting.reverbSetting`, or `commonSetting.defaultFootSoundType` (`0`–`6`) on restored/custom maps.
