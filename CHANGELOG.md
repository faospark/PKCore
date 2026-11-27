# Changelog

All notable changes to PKCore (formerly PKextended) are documented in this file.

---

## [2026.11.27]

### Suikoden II Cook-Off Fixes & Scoring Accuracy (`[05 Game : Suikoden 2]`)
- **Cook-Off Scoring Engine Accuracy ([CookOffScoreEngine.cs](Patches/CookOffScoreEngine.cs), [S2CookOffScorePatch.cs](Patches/S2CookOffScorePatch.cs))**:
  - Verified all 240 dishes × 12 tastes against native `rb_dat.hyoka_table` and fixed 2 matrix mismatches (`Sunomono` Chinese score `2` -> `1`; `Flaming Sea` full row `[3,2,5,3,3,3,3,2,3,5,1,3]`).
  - Updated `GetJudgeTaste()` to read native `rb_dat.favorite[examIdx].table` first (matching `Overlay_rbattle.CalcPoints`), falling back to `CharacterTastes` only if unavailable.
  - Added the native `0.5x` (`pts /= 2`) off-course penalty to `CalculateDishScore()` when evaluating fallback dishes outside the active course.
  - Added `IsSpecialGamble` tracking for all 18 `food_kind_table == 4` gamble dishes, marking them with `!` in the recipe menu (e.g. `[14:Pepper!]`).
- **Menu Board Cooldown Mode (`ReduceCookOffCooldown`)**: Converted `ReduceCookOffCooldown` in [ModConfiguration.cs](ModConfiguration.cs) from a boolean to `CookOffCooldownMode` (`Off`, `Instant`, `MenuBoard`), defaulting to `MenuBoard`.
  - In `MenuBoard` mode, interacting with the **"Today's Special"** menu board in Hai Yo's restaurant (`vk06_01`, text IDs `1664` / `1666` via [TextDatabasePatch.cs](Patches/TextDatabasePatch.cs)) primes the next cook-off match on demand (`ApplyCooldownReduction()`), instead of automatically priming on every room transition (`Instant`).
- **Tetsu Bathhouse Flag Fix & Save Self-Healing ([S2CookOffLoopPatch.cs](Patches/S2CookOffLoopPatch.cs))**:
  - Removed the unintended clear of `event_flag[132]` bit `0x40` (`KITCHEN_TRIGGER_BYTE` / `FLAG_1062_BIT`) from `CheckAndResetCookOffs()` after defeating Jinkai (Match 12), which was deactivating Tetsu's hot bath in `vk06_00`.
  - Added automatic self-healing in `CheckAndResetCookOffs()` to restore `event_flag[132]` bit `0x40` for saves that already completed Match 12 under the earlier build (when Tetsu is recruited, `event_flag[128] & 0x01` is set, and `event_flag[134] & 0x01` is clear).
- **Epilogue Leona Tavern Crash Fix ([S2EpilogueLeonaPatch.cs](Patches/S2EpilogueLeonaPatch.cs))**:
  - Guarded `s2EpilogueLeona.ApplyForMap()` so flag spoofing (`event_flag[144]` bit `0x04`) only activates during the post-final-boss epilogue (`event_flag[143] & 0x01` set: Beast Rune defeated), preventing wrong `vk08` Map Init events and `MACHICON.EBGSet()` crashes during normal story scenes (such as solo Riou before L'Renouille).

---

## [2026.11.20]

### Suikoden II Side Quests, Replay & Post-Game (`[05 Game : Suikoden 2]`)
- **Cook-Off Live Scoring Assistant**: Added a full cook-off scoring engine modeling all 12 judge taste profiles and 104 dishes, displaying a live on-screen rating card (`/20`) and optimal unlocked-recipe recommendations per course during dish selection (`ShowCookOffScoreHelper`), with accurate course tracking via `menu_step`.
- **Infinite Cook-Off Loop & Cooldown Removal**:
  - Automatically restarts the 12-chef cook-off circuit after defeating Jinkai while preserving all recipes and seasonings, with automatic queue self-healing to prevent opponent desyncs (`LoopCookOffMatches`).
  - Removes the 30-60 minute active gameplay cooldown between cook-off matches (`ReduceCookOffCooldown`).
- **Clive Quest Replay**: Automatically resets Clive's pursuit questline back to Lakewest upon entering Lakewest after completing the Sajah Village finale, allowing indefinite late-game replays (`LoopCliveQuest`).
- **Final Boss Gauntlet Replay**: Added configurable replay support for L'Renouille encounters (`LoopFinalBossGauntlet`, `ResetGauntletOnNextEntry`) with per-encounter toggles (`ReplayHighlandGuards`, `ReplayHanCunningham`, `ReplayLucia`, `ReplaySeedAndCulgan`, `ReplayBeastRune`).
- **Post-Final-Boss Epilogue Access**:
  - Restores Leona at Dunan Castle Tavern for party management during the epilogue (`EnableLeonaPostFinalBoss`).
  - Re-enables Dunan Castle minigames (such as Laundry & Gardens) during the epilogue (`EnableCastleMinigamesPostFinalBoss`).
- **Repeatable Guardian Deity Statue Rewards**: Re-arms the Guardian Deity blessing reward whenever the statue design is rebuilt or altered at Jude's workshop (`EnableRepeatStatueRewards`) and keeps the assembled 3D statue model visible instead of reverting to plain stone (`AlwaysKeepStatueAssembled`).
- **War Battle Formation Menu Sync**: Synchronized custom `S2WarAbilities.json` character stats and subunit bonuses (`bonusAttack`/`bonusDefense`) directly into Apple's Unit Formation & Team Change menu.
- **Save General Kiba & L'Renouille War Unit (S2)**: Added [S2SaveKibaPatch.cs](Patches/S2SaveKibaPatch.cs) (`EnableSaveKiba`, enabled by default) — when all 108 Stars of Destiny are recruited (`G2_SYS.Mem108Chk(1) >= 108`, Forgiver Sign unlocked), prevents Kiba's scripted death in Mercenary Fortress Ruins (`vb10` Sub 0 `Ev [17]`, NOPing `[0x54, 0x57, 0x21]` and guarding `G2_cha_flag(33, 87)`), restores him to Dunan Castle HQ (`vk07`, `vk06`, `vk13`), updates his epilogue card (`3001000213`) and post-Rockaxe dialogue (`1009010114`, `1011050014`), and deploys him as a standalone general unit in War Battle 16 (The Conquest of L'Renouille).

### Battle & Combat (`[06 Battle & Combat]`)
- **Battle Enemy HP Display & Typography (S1 & S2)**: Added live current/max enemy HP beneath enemy names and levels in the battle target selection window (`ShowEnemyHpInBattle`), and aligned S2 enemy name typography to native `25f` font sizing.
- **Battle Camera Zoom (S1 & S2)**: Added configurable combat camera zoom-out for a wider battlefield view (`EnableBattleCameraZoom`, `S1BattleCameraFovPercent`, `S2BattleCameraFovPercent`, defaulting to `125%`) with synchronized S2 `GroundCamera`/`FieldFrontCamera` alignment for front-layer status effects.
- **Memory Auto-Battle (S2)**: Remembers each character's last manually chosen command (Attack, Defend, or Rune/Magic — including Riou, ID `0`) across battles and replays it during Auto-Battle, automatically falling back to Attack if MP is depleted or the character is silenced (`EnableMemoryAutoBattle`).
- **Smart After-Battle Auto-Healing (S2)**: Automated post-battle recovery pipeline (`EnableSmartHealing`) that revives fallen allies with Sacrificial Jizo, cures Poison with Antitoxin, and heals HP deficits using all 5 healing items (Medicine, Mega Medicine, Kindness Drops, Kindness Rain, Healing Wind) with party-wide group healing priority, strict Party Bag scoping (preserving characters' personal equipped items), bit-masked charge decrementing, and stat-stone protection.
- **Command Rune Enhancements (S2)**:
  - Streamlined reusable command runes under `RemoveCommandRuneUseLimit` (Trick, Groundhog, Spider Slay, Angry Dragon) and `AlwaysAvailableAngryDragon`.
  - Refined `RemoveCommandRuneSelfUnbalance` into a language-independent boolean toggle covering all 8 authentic self-unbalancing physical command runes (Swallow, Fire Breath, Mayfly, White Tiger, Blue Drop, Twin Ring, Gozu, Trick) while preserving enemy and Unite attack unbalance.
- **Character Range Overrides (S2)**: Expanded default Medium-range (`M`) roster to include **Freed Y** and **Chuchara** alongside Kasumi, Luc, Mazus, Viki, Gantetsu, Badeaux, and Sierra (`S2CharacterRangeOverrides`).
- **Bright Shield Rune Enhancement (S2)**: Added [S2BrightShieldEnhancementPatch.cs](Patches/S2BrightShieldEnhancementPatch.cs) (`EnhanceBrightShieldRune`, enabled by default):
  - **Great Blessing (Lv1)**: Also applies Clay Guardian (`MS_EARTH_PROTECT_FLG`, 1.5x DEF) to all healed allies.
  - **Shining Light (Lv2)**: Adds `2x` the player's current recruit count directly to computed magic damage.
  - **Battle Oath (Lv3)**: Adds an independent 50% chance per ally to apply Awakened (`SC_AWAKE`, 3 turns) alongside vanilla's 50% Anger (`SC_ANGRY`) roll, allowing both buffs to coexist.

### UI, Display & Performance
- **Save Slot Party Portraits Overhaul & Stutter Elimination (S1 & S2)**:
  - Added pre-generated persistent disk thumbnail caching (`thumb_{portraitId}.dds`/`.png`) and RAM preservation for instant menu scrolling.
  - Added negative lookup caching for missing portraits and bypassed redundant save-directory scans inside the Save/Load menu, eliminating menu stutter.
  - Fixed blank white-square portraits appearing after soft-resetting or returning to the title screen.
- **Disable UI Tips**: Added `DisableUITips` (`DisableUITipsPatch`) to hide `UI_Root/UI_Canvas_Root/UITips` overlay prompts.
- **Floating Borderless Window Mode & Display Settings UI Sync**: Restored true Win32 borderless windowed mode at arbitrary custom resolutions (`EnableBorderlessWindow`) and added `DisplaySettingsUiPatch` to keep the in-game display settings UI synchronized with borderless/resolution overrides.
- **Resolution Scaling Simplification**: Removed the redundant `EnableResolutionScaling` toggle; `ResolutionScale` now controls scaling directly (`1.0` = native).
- **Runtime Mouse Cursor Toggle**: Added live OS cursor visibility toggling without requiring a restart.

### Stability & Core Engine
- **Soft Reset Battle Fix (S2)**: Fixed a `NullReferenceException` when soft-resetting during battle.
- **Submap Index Tracking**: Added `CurrentSubmapIndex` (`mno:`) parsing in `MACHICON_OnMapInitPatch` ([MapTrackingPatch.cs](Patches/MapTrackingPatch.cs)).
- **Multi-Tier Game Context Detection**: Upgraded `GameDetection` to a 4-tier zero-latency architecture (active scene match, `SceneManager.sceneLoaded` dispatch, native memory validation, and on-demand resolution) to eliminate startup and scene-transition race conditions.
- **Log Spam Reduction**: Gated routine startup, battle, resolution, sound redirect, texture preload, and monitor logs behind `DetailedLogs` for clean default output.

### Plugin Consolidation & Companion Migrations
- **Plugin Realignment Called Off (Re-absorbed Standalone Plugins)**: The planned split into separate standalone plugins has been called off — `PKBattlePatch`, `PKButtonPrompts`, and `PKReplayPlus` have been folded back into `PKCore` for a simpler single-DLL installation. Added automatic legacy plugin detection (`DetectLegacyStandalonePlugins`) that skips built-in patches and logs a warning if any of the old standalone DLLs are still present in `BepInEx/plugins/`.
- **Controller Button Prompt Overrides (`GlobalControllerPromptPatch`)**: Restored built-in PlayStation/Xbox/Generic button prompt override support (`EnableButtonPrompts`, `ControllerPromptType`).
- **Removals & Migrations**:
  - Removed `EncounterNonePatch` (delegated to `Suikoden_Fix`).
  - Migrated `S1QuickRunePatch` to `PKRuneSagePlus` and `EventFlagLogger` to `PKDev`.

---

## [2026.10.05]

- **Battle Enemy Level Display (Suikoden I & II)**:
  - Created [BattleEnemyLevelPatch.cs](Patches/BattleEnemyLevelPatch.cs) to display enemy levels in the battle target selection window (e.g. `Bonapart Lv.25`, `Highland Captain Lv.34`).
  - Implemented automatic level lookup from active battle combatants across both games:
    - **Suikoden I**: Reads `GSD1::BattleBase.battle_work` and `window_work` position mappings to retrieve monster levels from `monster_data_table`.
    - **Suikoden II**: Reads `GSD2::BattleParty` and `PM_DATA.monster_data.level` with front/back row formation slot indexing.
  - Dynamically configures TextMeshPro auto-sizing on the monster selection cell text (`leftText`) with single-line clamping (`enableWordWrapping = false`, `fontSizeMin = 13f`) to prevent truncation or line wrapping on longer enemy names.
  - Configurable via `ShowEnemyLevelInBattle` under `[02 User Interface]` (enabled by default).
- **Unlimited & Reusable Command Runes in Battle (Suikoden II)**:
  - Created [CommandRuneUnlimitedPatch.cs](Patches/CommandRuneUnlimitedPatch.cs) to remove the 1-use-per-battle lockouts on unique ability command runes:
    - **Meg & Gadget**: Trick / Gadget Rune (からくりの紋章 / Windup Doll ATK) is now reusable every turn.
    - **Millie & Bonaparte**: Groundhog Rune (モグラの紋章) is now reusable every turn.
    - **Shin**: Spider Slay Rune (八房の紋章 / 蜘蛛斬り) is now reusable every turn.
    - **Oulan**: Angry Dragon Rune (怒竜の紋章 / 狂竜 / 激怒) is now permanently available across every battle turn without requiring damage-triggered Fury or losing Fury status after execution.
  - Implemented multi-layered battle engine overrides:
    - Hooked `BattleManager.GetEmblMagicNum` and `PM_DATA.SpecialCanCheck` to enforce valid ability usage counts across turns.
    - Automatic `C_VARIA_DAT.mp` replenishment and `w_battle.tokusyu_sel_kaisu` / `tokusyu_sel_flag` state refresh during battle turn cycles.
    - Hooked `BattlePlayerCharacter.CalcIkariEnd` and `PlayerStatusClear` to preserve Oulan's Fury state (`0x20`).
  - Added dedicated BepInEx configuration options under `[05 Game : Suikoden 2]`:
    - `EnableUnlimitedCommandRunes` (Default: `true`)
    - `UnlimitedTrickRune` (Default: `true`)
    - `UnlimitedGroundhogRune` (Default: `true`)
    - `UnlimitedSpiderSlayRune` (Default: `true`)
    - `AlwaysAvailableAngryDragon` (Default: `true`)
- **Rune Unbalance Removal (Suikoden II)**:
  - Created [RuneUnbalancePatch.cs](Patches/RuneUnbalancePatch.cs) to disable the Unbalance status penalty and dizzy stars animation on physical ability runes (e.g. Titan, Falcon, Viper, Shrike, Swallow, Trick, Fire Breath, Mayfly, Lion, Unicorn, Pixie, Blue Drop).
- **Battle Party Max HP Display (Suikoden I & II)**:
  - Added configurable current / max HP display (`ShowBattleMaxHP`) in the battle party status window (e.g. `587/587` instead of just `587`).
  - Enabled dynamic auto-sizing on the HP text mesh (`m_hpText`) to ensure clean alignment without clipping or overflow on larger values (e.g. `999/999`).
- **Summon & Battle Magic Stutter Fix (Suikoden II)**:
  - Resolved severe frame drops, memory spikes, and crashes when casting summon spells (e.g. Pale Gate Rune) by removing intrusive Il2Cpp effect hooks and running summon animations natively.
- **Texture Engine Memory & Performance Fixes**:
  - Fixed a memory leak where temporary DDS textures accumulated in memory during gameplay.
  - Added in-memory file byte caching (`rawFileBytesCache`) to accelerate texture loading and eliminate duplicate disk I/O.
- **Battle Window Diagnostic Suite**:
  - Added internal runtime inspection tools (`BattleUnitWindowDiagnostics`) to diagnose battle party window hierarchies and UI text components across both games.

---

## [2026.09.15]

- **Battle Position Adjustments (Suikoden II)**:
  - Added configurable 6-character party formation spacing via `EnableBattlePositionAdjustments` and `S2BattlePositionPreset` (`wide`, `widest`, `default`).
  - Adjusts front/back row spacing and vertical slot offsets during Suikoden II battles so that back-row characters do not visually obstruct front-row party members.
  - Added `LogBattlePositions` diagnostics setting (disabled by default) to suppress verbose coordinate/offset logs unless explicitly enabled for debugging.
- **Character Battle Range Overrides (Suikoden II)**:
  - Added configurable weapon range modification via `S2CharacterRangeOverrides` in `BepInEx/config/faospark.pkcore.cfg` (enabled by `EnableCharacterRangeOverrides`).
  - Default enhancements change **Kasumi, Luc, Mazus, Viki, Gantetsu, Badeaux, and Sierra** from Short (`S`) to Medium (`M`) Range, allowing them to attack with physical weapons directly from the back row.
  - Automatically synchronizes `fcommand.range`, `s_phase.arms_range`, `G2_arms_range`, and native `arms_data` memory tables across battle, formation, tavern, and status UI screens.
  - Resolved party formation warnings (removes red `[X]` / `S` indicator over back-row platforms in Castle Tavern) and displays `M` in the Status menu.

- **Save Slot Party Member Portraits (Suikoden I & II)**:
  - Added visual party member mini portraits next to character level (`Txt_Lv`) in save and load menu slots (`ShowSaveSlotPartyPortraits` configuration option).
  - High-performance in-memory portrait caching ensuring 0ms lookups after initial load, prioritizing crisp custom textures from `PKCore/Textures/` over native sprites.
  - **Suikoden I Integration**:
    - Hooked `UISaveLoad1.Init` and dynamic slot virtualization (`UISaveLoadSlot.UpdateItem` / `UISaveLoadBase.OnUpdateItem`).
    - Resolved party member codes (`chara_code`) across in-memory save data (`UISaveLoad1.Inst.saveDataList`), native temp saves (`SaveDataManager.TmpSavePath`), and decrypted JSON fallbacks.
    - Integrated `Ws_face_c.CharacterIDConvertToFaceIDStatic` for character ID to Face ID mapping to support standard Suikoden I portrait indexing (e.g. `fp_gsd1_000` for Joshua Levenheit, Tir McDohl, etc.).
    - Added textured candidate resolution supporting `fp_gsd1_{faceId:D3}`, `fp_gsd1_{faceId}`, `fp_{faceId:D3}`, and `fp_gsd1_{charId:D3}` variants.
  - **Suikoden II Integration**:
    - Hooked `UISaveLoad2.Init` and party member array (`party_cha_no`) via `UISaveLoad2.Inst.saveDataList`, `GSD2SaveData.TmpSavePath`, and native `ImageLoader` fallback.
  - Isolated cached portrait keys per game (`$"{game}_{charId}"`) to prevent portrait collisions between Suikoden I and Suikoden II during the same session.

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
