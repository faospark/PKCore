# PKCore Plugin Architecture & Feature Reference

PKCore is a modular, high-performance modding and enhancements framework for the **Suikoden I & II HD Remaster** (`faospark.pkcore`), built on top of **BepInEx 6 (IL2CPP)** and **HarmonyX**.

---

## 1. High-Level Architecture Overview

```
                                +---------------------------+
                                |      BasePlugin (Load)    |
                                +-------------+-------------+
                                              |
        +-----------------------+-------------+-------------+-----------------------+
        |                       |                           |                       |
+-------v-------+       +-------v-------+           +-------v-------+       +-------v-------+
| Configuration |       | Asset Pipeline|           | Mono Injection|       | Harmony Engine|
| ModConfig.cs  |       | AssetLoader   |           | ClassInjector |       | ApplyPatches()|
+---------------+       +-------+-------+           +-------+-------+       +-------+-------+
                                |                           |                       |
                                v                           v                       v
                         +-------------+             +-------------+         +-------------+
                         | DDS / IO    |             | PkCoreMain- |         | 65 Active   |
                         | Disk Cache  |             | Loop (Tick) |         | Patch Units |
                         +-------------+             +-------------+         +-------------+
```

### Core Execution Flow

1. **Bootstrap & Lifecycle (`Plugin.cs`)**:
   - `Plugin.Load()` initializes configuration (`ModConfiguration.cs`), the asynchronous asset loading service (`AssetLoader.Initialize()`), registers custom IL2CPP `MonoBehaviour` subclasses into the runtime domain via `Il2CppInterop.Runtime.Injection.ClassInjector`, and registers an unkillable game object `PkCoreMainLoop` (`DontDestroyOnLoad`) to deliver tick events to `Plugin.Update()`.
   - Forces clean exit on application quit to avoid Unity 2022 / BepInEx 6 shutdown hangs on Windows.

2. **Asset Pipeline & Layered Override System (`AssetLoader.cs`, `DDSLoader.cs`)**:
   - Supports pre-compressed DirectX texture formats (`BC1/DXT1`, `BC3/DXT5`, `BC7` with DX10 header support) directly bypassing slow runtime Unity CPU compression.
   - Enforces hierarchical mod asset resolution:
     1. High-priority individual mod folders (`00-Mods/<ModName>/...`)
     2. Game-specific prefixes (`GSD1/...`, `GSD2/...`)
     3. Shared Root directories (`PKCore/Textures/...`, `PKCore/Sound/...`)

3. **Multi-Layer Interception Model**:
   - **Engine Renderers**: Intercepts `UnityEngine.SpriteRenderer`, custom game component `GRSpriteRenderer`, overworld `MapSpriteHD`, and `UnityEngine.UI.Image`.
   - **Dialogue & Story Engine**: Intercepts `OpenMessageWindow`, `GetSystemTextEx`, and `TextMasterData` to bind custom NPC portraits, expression variants, and localized string overrides.
   - **Native Mechanics Hooks**: Direct patches into battle character placement, weapon range getters, rune unbalance status calculations, war battle skill arrays, and save slot metadata.

---

## 2. Architectural Subsystems

The 65 active patch modules are structured into 9 specialized subsystems:

| Subsystem | Scope | Key Responsibilities |
| :--- | :--- | :--- |
| **1. Texture & Rendering Engine** | Universal | Texture replacement, DDS loading, GRSprite & Unity SpriteRenderer patching, Atlas caching, Animator monitors, Memory management. |
| **2. NPC & Dialogue Portrait System** | GSD1 & GSD2 | Adding portraits for un-portrait NPCs, dynamic expressions, context reactions (Covert Mission, Cook-Off, War Room), disk indexing cache. |
| **3. UI & UX Modernization** | Universal | Dialog window scaling, menu layout scaling, S1 world map UI resizing, UITips toggle, global controller prompt remapping (Xbox/PlayStation/Nintendo). |
| **4. Save & Data Systems** | GSD1 & GSD2 | Mini party portrait rendering on save/load slots, classic save window styling, name placeholder token resolution (protagonist/castle). |
| **5. Combat & Battle Overhauls** | GSD1 & GSD2 | Battle party Current/Max HP displays, S2 6-party battle formation positioning, weapon range overrides, unlimited command runes, rune unbalance removal. |
| **6. Strategic War Battles** | GSD2 | Custom war unit abilities, JSON configuration loader for character battle skills. |
| **7. Map, Environment & Custom Objects** | GSD1 & GSD2 | Disabling unwanted scene clutter (clouds, rays, test objects), overworld Suikozu minimap re-texturing, custom map object injection & discovery. |
| **8. Audio & Media Enhancements** | Universal | CriWare ACB/AWB sound redirection, custom launcher PSP gallery backgrounds, video/event background overrides. |
| **9. Infrastructure & Diagnostics** | Universal | Game version detection, language tracking, asset address pointer tracking, debug menus, cursor visibility, battle window inspections. |

---

## 3. Exhaustive Patch Enumeration & Feature Breakdown

*(Blank files such as `RestoreBaseWindow.cs` and `.bak` backups have been omitted).*

---

### Subsystem 1: Texture & Rendering Engine

#### 1. `AnimatedTexturePatch.cs`
- **Classes**: `AnimatedTexturePatch`, `AnimatedSpriteMonitor`
- **Scope**: Both Games (Universal)
- **Features**:
  - Solves the problem where Unity `Animator` components constantly overwrite sprite assignments each frame (e.g. Castle bath dragons, cows, animated NPCs).
  - Injects a `LateUpdate` monitor onto animated game objects that re-asserts the custom sprite after Unity's animator completes its cycle.

#### 2. `BathTexturePatch.cs`
- **Classes**: `CustomTexturePatch` (Partial)
- **Scope**: Suikoden 1 & 2
- **Features**:
  - Hooks `HDBath` components and background loading routines (`BGManagerHD.Load`).
  - Preloads and replaces bath background textures and scenery sprites.

#### 3. `CustomTexturePatch.cs`
- **Classes**: `CustomTexturePatch`
- **Scope**: Universal Core
- **Features**:
  - The central texture replacement hub for the entire mod.
  - Builds dynamic in-memory maps of replaceable textures, supports fuzzy path matching, checks file timestamps, and loads PNG, JPG, and DDS assets.
  - Coordinates fallback paths and handles logging when `LogReplaceableTextures` is active.

#### 4. `CustomTexturePatch.Caching.cs`
- **Classes**: `CustomTexturePatch` (Partial), `TextureManifest`, `ManifestEntry`
- **Scope**: Universal
- **Features**:
  - Provides disk-level manifest caching (`texture_manifest.json`) for texture resolutions and paths.
  - Significantly reduces initial boot and scene load times by indexing modded texture directories and avoiding redundant file lookups.

#### 5. `CustomTexturePersist.cs`
- **Classes**: `CustomTexturePersist`
- **Scope**: Universal
- **Features**:
  - Manages persistent textures that must survive Unity scene changes (e.g. global HUD elements, font atlases, window frames).
  - Preloads game-specific persistent textures into `DontDestroyOnLoad` containers.

#### 6. `DDSLoader.cs`
- **Classes**: `DDSLoader`, `DDSHeader`
- **Scope**: Engine Core
- **Features**:
  - Native binary DDS parser for pre-compressed textures.
  - Full support for `BC1` (`DXT1`), `BC3` (`DXT5`), and modern `BC7` formats (including DX10 four-word extended headers).
  - Bypasses Unity runtime software compression for near-instant asset load speeds and dramatically lower VRAM usage.

#### 7. `DisableCustomPostEffect.cs`
- **Classes**: `DisableCustomPostEffectPatch`
- **Scope**: Suikoden 2 (GSD2)
- **Features**:
  - Hooks the `CustomPostEffect` camera component under `AppRoot`.
  - Disables the heavy sepia/monochrome post-processing during flashback sequences and intro scenes, allowing full-color rendering.

#### 8. `DisablePortraitDialogMask.cs`
- **Classes**: `DisablePortraitDialogMask`
- **Scope**: Both Games
- **Features**:
  - Intercepts material properties with `_Mask_Map` assignments (such as `Face_Mask_01`).
  - Replaces restrictive dialog border clipping masks with full-bleed masks, allowing custom oversized NPC portraits to render without edge cutoffs.

#### 9. `DisableSpritePostProcessing.cs`
- **Classes**: `DisableSpritePostProcessingPatch`
- **Scope**: Both Games
- **Features**:
  - Hooks `GRSpriteRenderer` to reassign sprites away from blur or distortion post-processing layers to clean rendering layers.

#### 10. `GRSpriteRendererPatch.cs`
- **Classes**: `GRSpriteRendererPatch`
- **Scope**: Engine Core (GSD1/GSD2)
- **Features**:
  - Intercepts the HD Remaster's proprietary `GRSpriteRenderer` component.
  - Hooks sprite setter methods and render preparation calls to redirect game sprites to user textures from `PKCore/Textures/`.

#### 11. `MapSpriteHDPatch.cs`
- **Classes**: `CustomTexturePatch` (Partial)
- **Scope**: Both Games (Overworld / Field Maps)
- **Features**:
  - Targets `MapSpriteHD` components used on world maps and large field environments that bypass standard `SpriteRenderer` calls.

#### 12. `MapTexturePatch.cs`
- **Classes**: `MapTexturePatch`
- **Scope**: Both Games
- **Features**:
  - Intercepts native map background texture assignments (`MapBGManagerHD`) and routes them through the central caching system.

#### 13. `SMAAPatch.cs`
- **Classes**: `SMAAPatch`
- **Scope**: Both Games
- **Features**:
  - Patches the camera's post-processing stack to enable true Subpixel Morphological Anti-Aliasing (SMAA).
  - Offers configurable quality presets (`Low`, `Medium`, `High`), preventing pixel art blurring caused by temporal anti-aliasing.

#### 14. `SavePointMonitor.cs`
- **Classes**: `SavePointSpriteMonitor`
- **Scope**: Both Games
- **Features**:
  - Injected `MonoBehaviour` tracking save point objects in real-time.
  - Overcomes engine state where save orb animations force direct sprite properties during loop transitions.

#### 15. `SavePointPatch.cs`
- **Classes**: `CustomTexturePatch` (Partial), `Resources_Load_Sprite_Patch`
- **Scope**: Both Games
- **Features**:
  - Hooks `Resources.Load<Sprite>` and related resource loaders specifically for save point crystal animations and light pillars.

#### 16. `SpriteAtlasPatch.cs`
- **Classes**: `CustomTexturePatch` (Partial)
- **Scope**: Both Games
- **Features**:
  - Intercepts sprite extraction from Unity `SpriteAtlas` containers (`Sprite.texture`), substituting packed atlas textures with standalone custom high-definition textures.

#### 17. `SpriteFilteringPatch.cs`
- **Classes**: `SpriteFilteringPatch`
- **Scope**: Universal
- **Features**:
  - Applies Bilinear filtering and 2x Anisotropic filtering directly to `GRSpriteRenderer` textures to eliminate pixel shimmering during camera scrolling.

#### 18. `SpriteRendererPatch.cs`
- **Classes**: `CustomTexturePatch` (Partial)
- **Scope**: Universal
- **Features**:
  - Harmony patch on `UnityEngine.SpriteRenderer.set_sprite` and `OnEnable`.
  - Replaces standard 2D Unity sprites with mod assets.

#### 19. `TextureMemoryCachePatch.cs`
- **Classes**: `TextureMemoryCachePatch`, `TextureMetadata`
- **Scope**: Universal
- **Features**:
  - Dynamic scene-aware memory management system.
  - Tracks texture allocations per scene using unique content hashes; automatically purges stale, unreferenced textures during map transitions to prevent memory bloat.

#### 20. `TextureOptions.cs`
- **Classes**: `TextureOptions`
- **Scope**: Configuration Helper
- **Features**:
  - Defines filtering categories, folder priority tags, and resolution whitelist rules for the texture loading pipeline.

#### 21. `UIImagePatch.cs`
- **Classes**: `CustomTexturePatch` (Partial)
- **Scope**: Universal UI
- **Features**:
  - Patches `UnityEngine.UI.Image` to swap UI sprites (dialog borders, selection cursors, battle icons, inventory graphics).

#### 22. `UnitySpriteRendererPatch.cs`
- **Classes**: `UnitySpriteRendererPatch`
- **Scope**: Universal
- **Features**:
  - Explicit interceptor targeting vanilla `UnityEngine.SpriteRenderer` instances that exist alongside proprietary `GRSpriteRenderer` objects.

---

### Subsystem 2: NPC & Dialogue Portrait System

#### 23. `CovertMissionPortraitMonitor.cs`
- **Classes**: `CovertMissionPortraitMonitor`
- **Scope**: Suikoden 2 (GSD2)
- **Features**:
  - Detects covert mission story events (such as the Highland camp infiltration).
  - Dynamically switches Riou (Hero) and Jowy portraits to their Highland soldier uniform variants based on background event tags.

#### 24. `PortraitIndexCache.cs`
- **Classes**: `PortraitIndexCache`, `PortraitManifest`
- **Scope**: GSD1 & GSD2
- **Features**:
  - High-speed cache for dialogue portrait disk locations.
  - Builds `portrait_cache.json` to enable instant NPC dialogue portrait lookups without per-dialog disk I/O.

#### 25. `PortraitSystemPatch.cs`
- **Classes**: `PortraitSystemPatch`, `PortraitEntry`
- **Scope**: Suikoden 1 & 2
- **Features**:
  - Complete NPC portrait injection pipeline.
  - Allows assigning dialogue portraits to generic NPCs that never had portraits in the original release.
  - Correlates message window dialogue triggers with text IDs, maps, and character indices.

#### 26. `PortraitVariants.cs`
- **Classes**: `PortraitVariants`
- **Scope**: Suikoden 1 & 2
- **Features**:
  - Expression and costume variant resolver (e.g. happy, angry, sad, wounded, disguised).
  - Resolves naming schemas across shared, GSD1, and GSD2 portrait repositories.

#### 27. `S2CookOffPortraitMonitor.cs`
- **Classes**: `S2CookOffPortraitMonitor`
- **Scope**: Suikoden 2 (Hai Yo Cook-Off)
- **Features**:
  - Injected monitor tracking `MapChara/r_action` activation during Cook-Off minigames.
  - Renders custom reaction overlays and portraits for judges tasting dishes.

#### 28. `WarRoomBGPatch.cs`
- **Classes**: `WarRoomBGPatch`
- **Scope**: Suikoden 2 (GSD2)
- **Features**:
  - Tracks war council dialogue states.
  - Dynamically swaps the message window backdrop (`EventBG`) when strategist characters (e.g. Shu / `fp_085`) are actively speaking.

---

### Subsystem 3: UI & UX Modernization

#### 29. `DialogBoxScalePatch.cs`
- **Classes**: `DialogBoxScalePatch`
- **Scope**: Suikoden 1 & 2
- **Features**:
  - Hooks `OpenMessageWindow` in both games.
  - Allows custom scaling (e.g. scaling down overly large HD Remaster text boxes) and adjusts vertical screen offsets for cleaner framing.

#### 30. `DisableUITipsPatch.cs`
- **Classes**: `DisableUITipsPatch`
- **Scope**: Both Games
- **Features**:
  - Disables the intrusive `UI_Root/UI_Canvas_Root/UITips/` overlay that displays controller tips across battles, field exploration, and menus.

#### 31. `GlobalControllerPromptPatch.cs`
- **Classes**: `GlobalControllerPromptPatch`
- **Scope**: Universal
- **Features**:
  - Intercepts all button prompt `Image.sprite` assignments across the entire game.
  - Automatically swaps button prompts according to user configuration: `Xbox`, `PlayStation`, `Switch`, or `SteamDeck`.

#### 32. `MenuScale.cs`
- **Classes**: `MenuScalePatch`
- **Scope**: Both Games
- **Features**:
  - Scales and repositions `UIMainTopMenu` and `UIMainItemMenu` elements.
  - Provides compact, modern UI layout proportions on widescreen and 4K displays.

#### 33. `S1WorldMapScaleUI.cs`
- **Classes**: `S1WorldMapScaleUIPatch`
- **Scope**: Suikoden 1 (GSD1)
- **Features**:
  - Scales the Suikoden 1 world map UI down to 0.8x and shifts positioning to prevent blocking overworld navigation and scenery.

---

### Subsystem 4: Save & Data Systems

#### 34. `SaveDataProcessor.cs`
- **Classes**: `SaveDataProcessor`
- **Scope**: Both Games
- **Features**:
  - Parses save files (supporting both decrypted Suikoden Fix saves and encrypted vanilla saves).
  - Caches the protagonist's name and Castle/HQ name, substituting runtime string placeholder tokens (`{HERO}`, `{CASTLE}`) inside custom text and dialogue overrides.

#### 35. `SaveSlotPartyPortraitPatch.cs`
- **Classes**: `SaveSlotPartyPortraitPatch`, `SaveSlotPortraitMonitor`
- **Scope**: Both Games
- **Features**:
  - Renders miniature character party portraits inside the save/load slot UI windows.
  - Pulls character slot data from the save file headers and renders crisp custom or native portraits for the 6 active party members.

#### 36. `SaveWindowPatch.cs`
- **Classes**: `SaveWindowPatch`
- **Scope**: Both Games
- **Features**:
  - Hooks `GameObject.SetActive` on save menus to apply custom backgrounds and classical PS1 save window visual styling.

---

### Subsystem 5: Combat & Battle Overhauls

#### 37. `BattlePartyHPPatch.cs`
- **Classes**: `BattlePartyHPPatch`
- **Scope**: Suikoden 1 & 2
- **Features**:
  - Overhauls the party status window during combat.
  - Replaces current HP only (e.g. `587`) with formatted Current/Max HP displays (e.g. `587/587`).

#### 38. `BattlePositionPatch.cs`
- **Classes**: `BattlePositionPatch`, `BattleCharaSetup3ArgPatch`, `BattleManagerPlayerInitPatch`
- **Scope**: Suikoden 2 (GSD2)
- **Features**:
  - Re-calculates 3D/2D battle coordinates for the 6 player characters.
  - Increases horizontal spacing between front and back rows and spreads characters vertically so back-row party members are not obscured by front-row members.

#### 39. `CharacterRangePatch.cs`
- **Classes**: `CharacterRangePatch`, `G2ArmsRangePatch`, `UIStatusWindowUpdateStatusDataPatch`
- **Scope**: Suikoden 2 (GSD2)
- **Features**:
  - Overrides hardcoded character weapon ranges (Short `S`, Medium `M`, Long `L`).
  - By default fixes short-ranged staff/magic users (Kasumi, Luc, Mazus, Viki, Gantetsu, Badeaux) to Medium range (`M`), allowing attacks from the back row.
  - Updates all status windows, formation menus, and combat targeting engines synchronously.

#### 40. `CommandRuneUnlimitedPatch.cs`
- **Classes**: `CommandRuneUnlimitedPatch`
- **Scope**: Suikoden 2 (GSD2)
- **Features**:
  - Removes the single-use per battle restriction from command runes:
    - Meg / Gadget (*Trick Rune*)
    - Millie / Bonaparte (*Groundhog Rune*)
    - Shin (*Spider Slay Rune*)
    - Oulan (*Angry Dragon Rune*)
    - Bolgan (*Fire Breath Rune*)
    - Shiro / Kinnison, Mukumuku, and others.

#### 41. `RuneUnbalancePatch.cs`
- **Classes**: `RuneUnbalancePatch`
- **Scope**: Suikoden 2 (GSD2)
- **Features**:
  - Eliminates the crippling **Unbalance** (botch) status effect penalty applied to physical command runes (*Titan, Falcon, Viper, Shrike, Swallow, Mayfly, Lion, Unicorn, Pixie, Blue Drop*).

---

### Subsystem 6: Strategic War Battles

#### 42. `WarAbilityConfigLoader.cs`
- **Classes**: `WarAbilityConfigLoader`, `WarAbilityConfig`, `CharacterAbilityConfig`
- **Scope**: Suikoden 2 (GSD2)
- **Features**:
  - Loads custom war unit skills from `PKCore/WarAbilities/war_abilities.json`.
  - Supports unit movement range, defense values, magic types, and unit commander skill assignments.

#### 43. `WarAbilityPatch.cs`
- **Classes**: `WarAbilityPatch`
- **Scope**: Suikoden 2 (GSD2)
- **Features**:
  - Patches native Suikoden 2 war battle character data structures.
  - Overrides default commander abilities and injects modded war abilities into tactical major battles.

---

### Subsystem 7: Map, Environment & Custom Objects

#### 44. `CustomObjectConfig.cs`
- **Classes**: `CustomObjectsConfig`, `MapObjectsConfig`, `ObjectDefinition`, `Vector2Config`
- **Scope**: Map System
- **Features**:
  - Data contract model for custom map objects, defining object positions, collision flags, sprite mappings, and interaction triggers per map ID.

#### 45. `CustomObjectInsertion.cs`
- **Classes**: `CustomObjectInsertion`, `MACHICON_OnMapInitPatch`, `MapBGManagerHDSetMapPostfix`, `MachiLoader_Load_Patch`
- **Scope**: Map Engine
- **Features**:
  - Injects entirely new custom visual and interactive objects into field maps at runtime.
  - Hooks map initialization (`MACHICON.OnMapInit`) and loader events.

#### 46. `DiscoveredObject.cs`
- **Classes**: `DiscoveredObject`
- **Scope**: Tooling / Object Engine
- **Features**:
  - Data representation of map objects bridging Unity visual transforms and native Suikoden `EVENT_OBJ` structures.

#### 47. `ObjectConfigLoader.cs`
- **Classes**: `ObjectConfigLoader`
- **Scope**: Map Engine
- **Features**:
  - Discovers and deserializes JSON configurations from `PKCore/CustomObjects/` on map transition.

#### 48. `ObjectDiscovery.cs`
- **Classes**: `ObjectDiscovery`
- **Scope**: Modding Tools
- **Features**:
  - Diagnostic engine that logs all active map objects and native `EVENT_OBJ` data to disk, allowing modders to easily clone coordinates and properties for custom objects.

#### 49. `S1DisableObjects.cs`
- **Classes**: `S1DisableObjectsPatch`
- **Scope**: Suikoden 1 (GSD1)
- **Features**:
  - Selectively removes buggy or intrusive map elements in Suikoden 1 (e.g. oversized clutter in `va4_04`, mask artifacts in `vf1_08`, visual glitches in `vf4_00`).

#### 50. `S2WorldMiniMap.cs`
- **Classes**: `SuikozuPatch`, `SuikozuTextureEnforcer`
- **Scope**: Suikoden 2 (GSD2)
- **Features**:
  - Hooks `EventOverlayClass.OverlaySuikozu2` (the world minimap / blinking dot navigation item).
  - Isolates the map canvas from the player cursor dot, allowing HD texture replacement of the map graphic without breaking the tracking dot.

#### 51. `WorldMapEffectsPatch.cs`
- **Classes**: `WorldMapEffectsPatch`
- **Scope**: Both Games
- **Features**:
  - Disables distracting overworld visual effects including drifting cloud shadows (`sm_wk_cloud`) and sunray light sweeps.

---

### Subsystem 8: Audio & Media Enhancements

#### 52. `PSPGalleryEnhanced.cs`
- **Classes**: `PSPGalleryEnhanced`
- **Scope**: Launcher / Gallery
- **Features**:
  - Enhances the movie, sound, and event gallery menus in the launcher with custom full-art backdrops.

#### 53. `PSPLaucherPatch.cs`
- **Classes**: `PSPLauncherPatch`
- **Scope**: Launcher Screen
- **Features**:
  - Provides a customized, animated PSP-style aesthetic for the title and game selection launcher.

#### 54. `SoundRedirectPatch.cs`
- **Classes**: `SoundRedirectPatch`
- **Scope**: Audio Engine (CriWare)
- **Features**:
  - Redirects CriWare audio loading (`CriFsServer.LoadFile` / ACB & AWB sound archives).
  - Allows full replacement of BGMs and sound effects via `PKCore/Sound/` overrides.

---

### Subsystem 9: Infrastructure, Dialogue & Diagnostics

#### 55. `AssetAddressTracker.cs`
- **Classes**: `AssetAddressTracker`
- **Scope**: Diagnostics / Engine
- **Features**:
  - Hooks `UnityEngine.AssetBundle.LoadAsset_Internal` to record native asset pointers and trace internal Addressable asset identifiers.

#### 56. `AssetLoader.cs`
- **Classes**: `AssetLoader`
- **Scope**: Core Asset Service
- **Features**:
  - Background asynchronous asset loader handling queue management, thread synchronization, and file validation.

#### 57. `BattleUnitWindowDiagnostics.cs`
- **Classes**: `BattleUnitWindowDiagnostics`
- **Scope**: Diagnostics
- **Features**:
  - Live inspection tool that analyzes battle UI hierarchy structures (`ShareUI.Battle.UIBattleMainWindowUnit`) across both games.

#### 58. `EnableDebugMenu2.cs`
- **Classes**: `EnableDebugMenu2`
- **Scope**: Debugging
- **Features**:
  - Unhides and enables the disabled internal developer `DebugMenu2` interface in the engine.

#### 59. `GameDetection.cs`
- **Classes**: `GameDetection`
- **Scope**: Utility Core
- **Features**:
  - Tracks scene transitions and determines whether the active game context is Launcher, Suikoden 1 (`GSD1`), or Suikoden 2 (`GSD2`).

#### 60. `GameObjectPatch.cs`
- **Classes**: `CustomTexturePatch` (Partial)
- **Scope**: Core Interception
- **Features**:
  - Hooks `GameObject.SetActive` across UI menus to trigger texture re-binding when menus are toggled.
  - Automatically resolves status portrait display bugs on `TopMenuPartyList`.

#### 61. `LanguageSelectionPatch.cs`
- **Classes**: `LanguageSelectionPatch`
- **Scope**: Localization Core
- **Features**:
  - Hooks `TitlePanel` and `TextMasterData` to monitor language changes in real time (English, French, German, Spanish, Italian, Japanese, Traditional Chinese, Korean).

#### 62. `LocalizedOverrideMap.cs`
- **Classes**: `LocalizedOverrideMap`
- **Scope**: Localization Core
- **Features**:
  - Thread-safe localized text registry supporting language wrappers, hierarchical fallback chains, and token lookups.

#### 63. `MouseCursorPatch.cs`
- **Classes**: `MouseCursorPatch`
- **Scope**: Utility
- **Features**:
  - Toggles OS mouse cursor visibility during gameplay for mod development and UI inspection.

#### 64. `ResolutionPatch.cs`
- **Classes**: `ResolutionPatch`
- **Scope**: Display Engine
- **Features**:
  - Intercepts `Screen.SetResolution` calls with trailing priority to enforce custom render scale factors and prevent resolution reset bugs.

#### 65. `TextDatabasePatch.cs`
- **Classes**: `TextDatabasePatch`
- **Scope**: Dialogue Engine
- **Features**:
  - Intercepts `GetSystemTextEx` and text queries to track active dialogue string IDs, enabling targeted portrait injection and dialogue replacements.
  - Supports dumping the game text database to disk for localization and mod writing.

---

## 4. Complete Alphabetical File Reference

| # | File Name | Primary Subsystem | Target Game |
| :-: | :--- | :--- | :--- |
| 1 | `AnimatedTexturePatch.cs` | Texture & Rendering | Both |
| 2 | `AssetAddressTracker.cs` | Infrastructure & Diagnostics | Both |
| 3 | `AssetLoader.cs` | Core Asset Pipeline | Both |
| 4 | `BathTexturePatch.cs` | Texture & Rendering | Both |
| 5 | `BattlePartyHPPatch.cs` | Combat & Battle | Both |
| 6 | `BattlePositionPatch.cs` | Combat & Battle | Suikoden 2 |
| 7 | `BattleUnitWindowDiagnostics.cs` | Infrastructure & Diagnostics | Both |
| 8 | `CharacterRangePatch.cs` | Combat & Battle | Suikoden 2 |
| 9 | `CommandRuneUnlimitedPatch.cs` | Combat & Battle | Suikoden 2 |
| 10 | `CovertMissionPortraitMonitor.cs` | Dialogue & Portraits | Suikoden 2 |
| 11 | `CustomObjectConfig.cs` | Maps & Custom Objects | Both |
| 12 | `CustomObjectInsertion.cs` | Maps & Custom Objects | Both |
| 13 | `CustomTexturePatch.Caching.cs` | Texture & Rendering | Both |
| 14 | `CustomTexturePatch.cs` | Texture & Rendering | Both |
| 15 | `CustomTexturePersist.cs` | Texture & Rendering | Both |
| 16 | `DDSLoader.cs` | Core Asset Pipeline | Both |
| 17 | `DialogBoxScalePatch.cs` | UI & UX | Both |
| 18 | `DisableCustomPostEffect.cs` | Visual & Shaders | Suikoden 2 |
| 19 | `DisablePortraitDialogMask.cs` | UI & Portraits | Both |
| 20 | `DisableSpritePostProcessing.cs` | Visual & Shaders | Both |
| 21 | `DisableUITipsPatch.cs` | UI & UX | Both |
| 22 | `DiscoveredObject.cs` | Maps & Custom Objects | Both |
| 23 | `EnableDebugMenu2.cs` | Infrastructure & Diagnostics | Both |
| 24 | `GameDetection.cs` | Infrastructure & Diagnostics | Both |
| 25 | `GameObjectPatch.cs` | Texture & UI | Both |
| 26 | `GlobalControllerPromptPatch.cs` | UI & UX | Both |
| 27 | `GRSpriteRendererPatch.cs` | Texture & Rendering | Both |
| 28 | `LanguageSelectionPatch.cs` | Localization & Dialogue | Both |
| 29 | `LocalizedOverrideMap.cs` | Localization & Dialogue | Both |
| 30 | `MapSpriteHDPatch.cs` | Texture & Rendering | Both |
| 31 | `MapTexturePatch.cs` | Texture & Rendering | Both |
| 32 | `MenuScale.cs` | UI & UX | Both |
| 33 | `MouseCursorPatch.cs` | Infrastructure & Diagnostics | Both |
| 34 | `ObjectConfigLoader.cs` | Maps & Custom Objects | Both |
| 35 | `ObjectDiscovery.cs` | Maps & Custom Objects | Both |
| 36 | `PortraitIndexCache.cs` | Dialogue & Portraits | Both |
| 37 | `PortraitSystemPatch.cs` | Dialogue & Portraits | Both |
| 38 | `PortraitVariants.cs` | Dialogue & Portraits | Both |
| 39 | `PSPGalleryEnhanced.cs` | Media & Launcher | Launcher |
| 40 | `PSPLaucherPatch.cs` | Media & Launcher | Launcher |
| 41 | `ResolutionPatch.cs` | Display Engine | Both |
| 42 | `RuneUnbalancePatch.cs` | Combat & Battle | Suikoden 2 |
| 43 | `S1DisableObjects.cs` | Maps & Environment | Suikoden 1 |
| 44 | `S1WorldMapScaleUI.cs` | UI & UX | Suikoden 1 |
| 45 | `S2CookOffPortraitMonitor.cs` | Dialogue & Portraits | Suikoden 2 |
| 46 | `S2WorldMiniMap.cs` | Maps & Environment | Suikoden 2 |
| 47 | `SMAAPatch.cs` | Visual & Shaders | Both |
| 48 | `SaveDataProcessor.cs` | Save & Data Systems | Both |
| 49 | `SavePointMonitor.cs` | Texture & Rendering | Both |
| 50 | `SavePointPatch.cs` | Texture & Rendering | Both |
| 51 | `SaveSlotPartyPortraitPatch.cs` | Save & Data Systems | Both |
| 52 | `SaveWindowPatch.cs` | Save & Data Systems | Both |
| 53 | `SoundRedirectPatch.cs` | Audio & Media | Both |
| 54 | `SpriteAtlasPatch.cs` | Texture & Rendering | Both |
| 55 | `SpriteFilteringPatch.cs` | Texture & Rendering | Both |
| 56 | `SpriteRendererPatch.cs` | Texture & Rendering | Both |
| 57 | `TextDatabasePatch.cs` | Dialogue & Localization | Both |
| 58 | `TextureMemoryCachePatch.cs` | Memory & Performance | Both |
| 59 | `TextureOptions.cs` | Texture & Rendering | Both |
| 60 | `UIImagePatch.cs` | Texture & UI | Both |
| 61 | `UnitySpriteRendererPatch.cs` | Texture & Rendering | Both |
| 62 | `WarAbilityConfigLoader.cs` | Strategic War Battles | Suikoden 2 |
| 63 | `WarAbilityPatch.cs` | Strategic War Battles | Suikoden 2 |
| 64 | `WarRoomBGPatch.cs` | Dialogue & Portraits | Suikoden 2 |
| 65 | `WorldMapEffectsPatch.cs` | Maps & Environment | Both |
