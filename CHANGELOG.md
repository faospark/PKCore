# Changelog

All notable changes to PKCore (formerly PKextended) are documented in this file.

---

## [Unreleased]

- **Battle Position Adjustments (Suikoden II)**:
  - Added configurable 6-character party formation spacing via `EnableBattlePositionAdjustments` and `S2BattlePositionPreset` (`wide`, `widest`, `default`).
  - Adjusts front/back row spacing and vertical slot offsets during Suikoden II battles so that back-row characters do not visually obstruct front-row party members.
  - Added `LogBattlePositions` diagnostics setting (disabled by default) to suppress verbose coordinate/offset logs unless explicitly enabled for debugging.
- **Character Battle Range Overrides (Suikoden II)**:
  - Added configurable weapon range modification via `S2CharacterRangeOverrides` in `BepInEx/config/faospark.pkcore.cfg` (enabled by `EnableCharacterRangeOverrides`).
  - Default enhancements change **Kasumi, Luc, Mazus, Viki, Gantetsu, Badeaux, and Sierra** from Short (`S`) to Medium (`M`) Range, allowing them to attack with physical weapons directly from the back row.
  - Automatically synchronizes `fcommand.range`, `s_phase.arms_range`, `G2_arms_range`, and native `arms_data` memory tables across battle, formation, tavern, and status UI screens.
  - Resolved party formation warnings (removes red `[X]` / `S` indicator over back-row platforms in Castle Tavern) and displays `M` in the Status menu.
- **Battle Engine & Targeting Stability**:
  - Removed intrusive `PM_DATA` check postfixes (`AttackCanCheck`, `MokuhyoCanCheck`, `CheckRowFormation`) to eliminate battle state machine freezes, enabling native enemy target selection and animation flow.
- **Live Configuration Hot-Reloading**:
  - Added real-time event listeners for `SettingChanged` on `S2CharacterRangeOverrides` and `EnableCharacterRangeOverrides`, allowing on-the-fly configuration updates via BepInEx Configuration Manager or UnityExplorer without restarting the game.
- **DDS Portrait Format & Directory Search (Fix for previous update oversight)**:
  - Fixed an issue where converting textures to `.dds` format in the previous update caused custom portraits and UI masks to stop loading (previously only `.png` was supported).
  - Added full DDS format support (BC1/BC3/BC7) to the NPC & Dialogue Portrait System using `AssetLoader`.
  - Added recursive directory searching across both `Portraits/` and `NPCPortraits/` subfolders within `Textures/GSD1/`, `Textures/GSD2/`, `Textures/`, and `00-Mods/`.
  - Preserved native in-game portraits in Event Viewer and cutscenes: missing custom emotion/expression variants will no longer overwrite original dialogue faces with question mark fallbacks (`fp_219`).
- **UI Mask Replacement Pipeline**:
  - Updated `DisablePortraitDialogMask.cs` to use the unified custom texture pipeline, adding DDS texture support for custom mask replacements.
- **Activation Log Spam Reduction**:
  - Deduplicated sprite and mesh texture replacement logging in `GameObjectPatch.cs` during background manager and scene activations to prevent repeated messages for duplicate environment assets (e.g. repeated trees).

---

## [2026.03.01] - 2026-03-22

- **PSP Launcher UI**:
  - Added `PSPLauncher` configuration option (off by default) to recreate the PSP Launcher interface.
- **Enhanced Gallery UI**:
  - Added `EnhancedGallery` configuration option (enabled by default) inspired by the PSP version to replace Movies, Events, and Sounds gallery backgrounds with custom textures independently of the PSP launcher mode.
- **BGM Replacement System**:
  - Added non-destructive Background Music replacement support for swapping music without modifying game files.
  - Place `.acb` / `.awb` audio files under `PKCore/00-Mods/<ModName>/Sound/`.
- **Better Launcher BGM**:
  - Included `BetterLauncherBGM` (enabled by default), replacing the launcher ambient music with Suikoden 2's adventure start theme as a reference implementation.
- **Modular 00-Mods Directory Structure**:
  - Relocated `00-Mods` to the root of PKCore for enhanced visibility and ease of use.
  - Expanded mod support beyond textures to include texture, sound, dialogue, and war battle customization packages.
  - Moved Suikoden 2 war battle assets to `PKS2` to allow individual toggling.
- **Suikoden 1 Dialogue & Portrait System**:
  - Full portrait injection support for Suikoden 1 with custom name display in dialog boxes for unnamed NPCs.
  - Fixed portrait display logic for named characters during story-based name changes (e.g. Kanaan and Viktor dialogue scenes).
  - Added custom portraits for Grady, Assassin (Iga), Rosh, Elder Dwarf (Durin), Elven Elder (Soveliss), Imperial Guard, and Zombie (Andie).
  - Split dialogue override loading per game (`TextDB_GSD1` / `TextDB_GSD2`) to prevent cross-game message ID collisions.
- **Visual & Location Polish**:
  - Foliage overhaul for Magician's Island.
  - Removed unnecessary mask overlays in Dragon's Den for improved visibility.
  - Transferred menu and object strings from Reworded+ into PKCore.
  - Converted performance-critical textures to `.dds` format.
  - Renamed `DisablePortraitDialogMaskPortraitDialog` to `DisablePortraitDialogMask`.
  - Revised Project Kyaro sprites for young Riou, Jowy, Nanami, Teo (1v1 duel sprite), and Kasios (instrument playing).

---

## [2026.02.2] - 2026-02-17

- **Dialogue Placeholders**:
  - Added dynamic parsing of text placeholders to reflect custom names of protagonists and headquarters from save files.
- **Texture Discovery & Logging**:
  - Restored `LogReplaceableTextures` configuration toggle to give users control over detailed log volume when logging text IDs.
  - Custom texture patch logging now outputs exact file index names instead of indexed variants.
  - Removed obsolete texture filename sanitization that previously caused hash collisions.
- **Portrait & Mask Refactoring**:
  - Renamed `NPCPortraits` class to `PortraitSystemPatch` to represent broader functionality.
  - Renamed `DisableMask` to `DisablePortraitDialogMask` for clarity.
  - Removed deprecated `ReactionMonitor`.
- **Window Management**:
  - Replaced internal borderless window patch with recommendation to use Unity's native `-popupwindow` launch parameter.
- **Suikoden 1 UI**:
  - Refined Suikoden 1 dialog scaling calculations.

---

## [2026.02.0] - 2026-02-09

- **Reaction Portrait UI**:
  - Enhanced visual presentation with smooth fade-in animation, removed purple background artifact, and standardized dimensions (300x300 at x:636.85, y:-262.34).
- **Log Spam Reduction**:
  - Suppressed `DisablePortraitDialogMask` log spam, routing messages only when `DetailedTextureLog` is active.
  - Coalesced repeated sprite variations in `GRSpriteRenderer` (e.g. `person_vj10_01_XX`) into single aggregated log entries.
- **Dialogue & Config Fixes**:
  - Fixed CS0029 compilation error in `ModConfiguration.cs`.
  - Removed obsolete dialog chaining functionality (Interceptor Pattern).
  - Reverted experimental multi-character support for Jowy's disguise.

---

## [2026.01.1] - 2026-02-05

- **World Map Visual Improvements**:
  - Disabled `sm_wk_cloud` objects to remove visual clutter and artifacts on the world map.
  - Corrected sunray glow rendering for consistent lighting.
- **Configuration Cleanup**:
  - Moved developer debug options (`LogReplaceableTextures`, `LogTexturePaths`) to internal hidden settings.
- **Caching Documentation**:
  - Updated `Caching.md` with technical documentation on priority layers, DDS compression handling, and memory persistence.

---

## [2026.01.0] - 2026-01-31

- **SpriteAtlas Loose File Interception**:
  - Implemented postfix interception for Unity SpriteAtlas, allowing runtime replacement of packed sprites using loose external texture files.
- **Minimal UI & Selective Filtering**:
  - Added `MinimalUI` boolean option to control minimal UI texture variant loading.
  - Implemented selective texture filtering system for Project Kyaro, Launcher, and Minimal UI assets.
  - Enhanced cache invalidation to track `MinimalUI` state.
- **UI Scaling & Dialog Simplification**:
  - Refactored `DialogBoxScale` to boolean `ScaleDownDialogBox` (`false` = normal, `true` = 80% compact size).
  - Improved `MenuTopPartyStatus` texture refresh with `UIMainMenu.Open` hook for proper atlas updating.
  - Enhanced menu transformation logic and footer container handling.
- **Performance & Diagnostics**:
  - Added `HashSet` tracking in `TextDatabasePatch` to eliminate duplicate runtime log entries.
  - Streamlined portrait directory scanning and loading performance.
  - Fixed save point replacement log message formatting.
  - Simplified battle sprite detection in `DisableSpritePostProcessingPatch`.
  - Upgraded core asset loader with asynchronous operations and DDS support.
- **Version Numbering**:
  - Adopted year-based versioning format (`YYYY.MM.MINOR`) for clearer release tracking.

---

## [2.1.0] - 2026-01-23

- **Native DDS Support**:
  - Pre-compressed `.dds` (BC1/BC3/BC7) texture loading for reduced VRAM usage and faster startup times.
- **Manifest Caching**:
  - XML-based texture index cache system dramatically reducing startup loading times.
- **SMAA Anti-Aliasing**:
  - High-quality Subpixel Morphological Anti-Aliasing applied to the main camera (`SMAAQuality`).
- **Custom NPC Portraits & Dialogue Overrides**:
  - High-resolution portrait injection system for NPCs lacking base-game portraits (`PKCore/NPCPortraits/`).
  - JSON-based dialogue replacement system with custom speaker injection via `<speaker:Name>` tags.
- **Visual Enhancements**:
  - Portrait mask removal (`DisablePortraitDialogMask`) disabling the `Face_Mask_01` overlay.
  - Restored full color to Suikoden 2 intros and flashbacks (`ColoredIntroAndFlashbacks`).
  - Classic PSX-style fullscreen Save/Load interface for Suikoden 2 (`ClassicSaveWindow`).
  - Save point customization with 5 color options (`SavePointColor`) and glow toggle (`DisableSavePointGlow`).
- **Specialized Suikoden 2 Support**:
  - `SummonMonitor` system for replacing summon effect textures (`Eff_tex_Summon_*`).
  - Configurable war battle character stats and abilities via `PKCore/Config/S2WarAbilities.json`.
  - Texture variants for Tir's running animation (`TirRunTexture`) and Mercenary Fortress fence (`MercFortFence`).
- **UI Scaling**:
  - Compact dialog box sizing (`ScaleDownDialogBox`) and compact main menu layout (`ScaledDownMenu`).
  - Borderless fullscreen window mode and cursor visibility toggle (`ShowMouseCursor`).
- **Static Object Insertion**:
  - Framework for inserting static objects into scenes via `fixed_objects.json`.

---

## [2.0.0] - 2025-12-23

- **Save Point Customization**:
  - 5 selectable color options (blue, red, yellow, pink, green, default) via `SavePointColor` with automatic fallback.
  - Option to disable save point orb glow effect via `DisableSavePointGlow`.
- **Config-Aware Manifest Caching**:
  - Texture cache tracks configuration changes (`LoadLauncherUITextures`, `SavePointColor`, `EnableProjectKyaroSprites`) and automatically rebuilds without requiring manual file deletion.
- **Centralized Texture Variant System**:
  - Added unified `TextureOptions.GetTextureNameWithVariant()` handler for organized texture variant lookup.

---

## [1.6.0] - 2025-12-20

- **Project Rebranding**:
  - Rebranded from `PKextended` (`faospark.pkextended`) to **`PKCore`** (`faospark.pkcore`).
  - Updated paths: `BepInEx/plugins/PKCore/Textures/` and `PKCore.dll`.
- **Priority Override System**:
  - Added `00-Mods/` root folder with highest priority over base textures, allowing modular add-on packs.
- **Logging Optimizations**:
  - Deduplicated texture replacement logs to log only once per texture.
  - Startup shows aggregate indexed count instead of listing every file (detailed list available when `DetailedLogs = true`).
- **Bath Backgrounds**:
  - Added support for custom bath background sprite replacement.

---

## [1.5.0 - 1.5.1] - 2025-12-16

- **Custom PNG/JPG/TGA Texture Replacement**:
  - Runtime texture injection for UI elements, event backgrounds, and static sprites.
  - Automatic subfolder scanning under `PKCore/Textures/`.
  - Added `LogReplaceableTextures` discovery helper to inspect replaceable sprite names.
- **Controller Prompt Override System**:
  - Global button prompt override for PlayStation 4 (`_01`), PlayStation 5 (`_02`), and Xbox/Generic (`_00`).
  - Patches `UnityEngine.UI.Image.sprite` setter across menus, battles, dialogues, and minigames.
  - Smart minigame button sequence cycle conversion.

---

## [1.0.0] - 2025-12-01

- **Granular Sprite Filtering**:
  - Bilinear, Trilinear, Anisotropic (up to 8x), and Mipmap bias controls tailored for Project Kyaro HD upscaled sprites.
- **Resolution Scaling**:
  - Dynamic internal rendering resolution multiplier (0.5x to 2.0x) without requiring game restarts.
- **Borderless Fullscreen**:
  - Native window frame removal and multi-monitor borderless display support.
- **Sprite Post-Processing Isolation**:
  - Selectively removes bloom and vignette distortion from character sprites to eliminate outline and seam artifacts during battles and exploration.
