# Changelog

All notable changes to PKCore (formerly PKextended) are documented in this file.

---

## [2026.10.31]

- **Floating Borderless Window Mode Restoration (`BorderlessWindowPatch.cs`)**:
  - Restored `BorderlessWindowPatch.cs` to enable true floating borderless windowed mode.
  - Unlike Unity's native `-popupwindow` (which forces full-screen borderless stretched to desktop resolution), this feature strips Win32 OS window chrome (`WS_CAPTION`, `WS_THICKFRAME`, `WS_SYSMENU`, `WS_MINIMIZEBOX`, `WS_MAXIMIZEBOX`) via `SetWindowLong` and `SetWindowPos` while keeping the engine in `FullScreenMode.Windowed`.
  - Enables players to run the game at lower or arbitrary custom window resolutions without window borders or title bars.
  - Re-added configuration binding `EnableBorderlessWindow = false` under section `[Utilty]` in `faospark.pkcore.cfg`.
  - Intercepts `Screen.SetResolution` overloads to re-apply borderless styling cleanly on any resolution change.

## [2026.10.29]

- **Living Quarters Shortcut Door Restoration (`MapTrackingPatch.cs`)**:
  - **Resolution of Map Load Lifecycle Hook**:
    - Discovered that `ApplyDormantCastleRestorations` was previously only invoked during `MACHICON.EventInit`. In Suikoden II HD Remaster, `EventInit` is not called when transitioning rooms within Castle HQ or loading saves; instead, `MACHICON.OnMapInit` executes for every room load.
    - Added hook in `MACHICON_OnMapInitPatch.Postfix` to execute restorations reliably on every scene transition.
  - **Bytecode Scan & Strict Array Length Preservation**:
    - Replaced hardcoded offset assumptions with a sliding 3-byte window search across `eventForm` arrays to find `[33, 0, 4]` (`base_lv == 4`) and overwrite with NOPs `[0, 0, 0]`.
  - **Active Restorations**:
    - `vk13` Submap 4 `ev[13]`: Restored Konami's cut interactive shortcut door at `(X: 23..24, Y: 135..148)` executing `ECMapChenge` directly to the Combat Dojo (`vk03` at 50, 23).
    - `vk13` Submap 4 `ev[12]`: Restored the step-on tripwire at `(X: 28..46, Y: 133..146)` executing `ECSubmapChenge` back to the main living quarters corridor (`vk13_00` at 10, 15).
  - **Configuration (`RestoreDormantCastleFeatures`)**:
    - Routed through existing setting `RestoreDormantCastleFeatures = true` under `[zz - Experimental]` in `faospark.pkcore.cfg`.

- **Repeatable Guardian Deity Statue Rewards (`GuardianDeityRepeatRewardsPatch.cs`, `ModConfiguration.cs`, `Plugin.cs`)**:
  - **Resolution of Retail One-Time Reward Lock**:
    - Discovered that retail Suikoden II permanently locks Guardian Deity statue blessings after the player's first statue evaluation (`syugoitm` / `vk33`). When receiving the reward, the engine sets `parts_no[3] = 1` and marks **Story Flag 148 bit 32 (0x20)** as claimed.
    - When the player subsequently alters or rebuilds the statue at Jude's workshop (`h_shugo` / `vk20`), vanilla code writes the new packed combination to `parts_no[2]` and sets inspection bit 16 (0x10), but **fails to clear lock bit 32**, rendering all subsequent statue blessings permanently unobtainable.
  - **Forensic Fixes & Lifecycle Robustness**:
    - **Workshop Exit Hook**: Identified that `h_shugo.Destroy` is uncalled dead code in the retail engine. Relocated the workshop exit trigger to `h_shugo.ShugoMain` returning `1`, ensuring `ArmStatueReward` reliably executes every time the customizer closes.
    - **Visual Mesh Preservation**: Discovered that retail `syugoSet$$Entry` skips 3D model loading when `parts_no[3] == 0`, causing the statue to revert to an uncarved plain stone rock (`ano = 15`). Locked `parts_no[3] = 1` in memory across all transitions so the custom statue model is permanently visible.
    - **Cutscene Map Scoping**: Scoped `syugoSet.Entry` evaluation strictly to `vk33` (Castle Roof Shrine) via `MACHICON_OnMapInitPatch.CurrentMapId`, preventing corridor transitions (`vk32`) from misfiring the evaluation state.
    - **Party Reaction & Flag 123 Reset**: Cleared Story Flag 123 bits (`8`, `16`, `32`, `64`) in `ArmStatueReward` so party member reactions, portraits, and commentary refresh properly for every newly sculpted statue.
    - **Clean Cutscene Completion**: Removed premature flag modifications from `syugoitm`, allowing native cutscene `Ev 16` to naturally fade in and set Story Flag 148 bit 32 upon full completion without causing black screen locks.
  - **Configuration (`EnableRepeatStatueRewards`)**:
    - Added `EnableRepeatStatueRewards` (Boolean, default `true`) under `[05 Game : Suikoden 2]` in `ModConfiguration.cs`.

- **Reversion of Blanket Dormant Castle NPC Activation (`MapTrackingPatch.cs`, `ModConfiguration.cs`, `ImGuiOverlayUI.cs`)**:
  - **Resolution of Room Load Engine Crash**:
    - Discovered that blanket setting `disp = 1` across all dormant castle actors crashes the Remaster engine upon loading rooms such as `vk07_01` (Great Hall / War Strategy Room, Submap 3).
    - **Forensic Root Causes**:
      1. **Coordinate Stacking / Mutually Exclusive Story Branches**: Vanilla map files contain mutually exclusive story actors mapped to the exact same coordinates (e.g., Slot 1 Shu `fpno=89` and Slot 11 Apple `fpno=85` both at `(60, 52)`; Slot 4 Nanami and Slot 5 Klaus both at `(48, 45)`; Slot 6 Kiba and Slot 7 Boris both at `(58, 46)`).
      2. **Origin Stacking**: Over 100 dormant actors across the castle are parked at `(0, 0)` with solid collision (`ozok = 2`).
      3. **HD Engine Object Mapping**: `MapBGManagerHD` requires matching `MapEventObjectHD` scene instances in the Unity scene hierarchy. Rooms designed for 2 active objects hit null dereferences when 50+ objects are forcefully activated without scene GameObject backings.
    - **Resolution**:
      - Completely removed the blanket `disp = 1` activation loop from `MachiLoader_Load_Patch.Prefix` in `MapTrackingPatch.cs`.
      - Removed the experimental `SpawnDormantCastleNPCs` config entry and disabled it in `faospark.pkcore.cfg`.
      - Removed experimental dormant NPC UI controls from `ImGuiOverlayUI.cs`.
      - Preserved the verified, isolated section restorations under `RestoreDormantCastleFeatures` (Yuzu pasture direct door shortcut and Karen cut dance routines).

- **Restoration of Dormant Castle Features (`MapTrackingPatch.cs`, `ModConfiguration.cs`)**:
  - **Secret Pasture Shortcut Door (`vk13` Submap 4 -> `vk03` Submap 0)**:
    - Restored the cut Tier 5 fast-travel doorway in Riou's residential quarters hallway (`X=23..24, Y=135..148`) by hooking `MACHICON.EventInit` in `MapTrackingPatch.cs`.
    - Patched `eventForm` in `eventdat[12]` (Step-on zone) and `eventdat[13]` (Action door), replacing the unreachable `[33, 0, 4]` condition with NOP padding `[0, 0, 0]`, strictly preserving bytecode array length.
    - Allows players to transition directly from the residential chambers out to Yuzu's animal farm (`vk03` at `(50, 23)` via `ECMapChenge`), eliminating castle elevator rides and stair climbing.
  - **Karen & Stage Performers Cut Dance Choreography (`vk19` Submap 0)**:
    - Fixed a vanilla developer bug where `eventdat[62..65]` evaluated `[9, 26, 0]` (bitwise AND against bitmask 0x00, permanently evaluating to false).
    - Replaced the faulty condition with NOP padding `[0, 0, 0]`, allowing dance performance sequences 5, 6, 7, and 8 to execute across the stage floor with full movement choreography (`ECOPosMove`).
  - **Configuration (`RestoreDormantCastleFeatures`)**:
    - Added `RestoreDormantCastleFeatures` (Boolean, default `true`) under `[zz - Experimental]` in `ModConfiguration.cs`.

---

## [2026.10.28]

- **Experimental Load-Time Dormant Castle NPC Activation (Superseded & Reverted on 2026.10.29)**:
  - Explored load-time pre-activation of dormant castle NPCs in `MachiLoader_Load_Patch` to determine if engine sprite buffers could be generated before room render.
  - Testing confirmed blanket activation across castle submaps causes crashes in complex rooms (e.g. `vk07_01`) due to mutually exclusive story actor overlaps and missing `MapBGManagerHD` prefab instances; reverted in 2026.10.29 in favor of isolated feature restorations (`RestoreDormantCastleFeatures`).

---

## [2026.10.27]

- **Fixed & Enhanced Camera Zoom / FOV Controls (`ImGuiOverlayUI.cs`, `Plugin.cs`, `MapTrackingPatch.cs`)**:
  - **Resolution of Inactive FOV / Camera Zoom**:
    - Identified that `BindCamera.Sync` (called every frame in `LateUpdate` on `NoFilterCamera` and bound cameras) was continually copying the target camera's unzoomed FOV/orthographic size and overwriting modifications made in `Update`.
    - Added `BindCamera_Sync_Patch` (`[HarmonyPostfix]` on `BindCamera.Sync`) and wired `LateUpdate` into `PkCoreMainLoop` and `Plugin.cs` so camera scaling is reliably applied and preserved right before rendering.
    - Updated camera discovery to scan `CameraManager.Instance.ActiveCamera`, `noFilterCamera`, `Camera.main`, `BindCamera.activeCameras`, and `Camera.allCameras` with robust per-camera exception isolation.
    - Added `ImGuiOverlayUI.OnMapChanged` hook into `MACHICON.EventInit` (`MachiLoader_Load_Patch`) to reset baseline size caches and reapply zoom smoothly upon map transitions.
    - Moved hotkeys (`PageUp` = zoom in, `PageDown` = zoom out, `Home` = 1.0x reset) to `ImGuiOverlayUI.Update()` directly so shortcuts work regardless of whether the HUD bar is shown or hidden.
    - Clarified HUD button labels to `FOV: <Scale>x [Out] [In] [1x]`.


- **Save/Load Screen Performance Optimization & Stutter Elimination**:
  - **Negative Lookup Caching (`SaveSlotPartyPortraitPatch.cs`)**:
    - Introduced `missingPortraitCache` (`HashSet<string>`) to record missing portrait IDs on their very first lookup.
    - Resolved a severe performance regression in Suikoden 1 where characters lacking custom textures in `PKCore/Textures/` failed all 8 candidate filename lookups, returned `null`, and were never cached. This previously forced the save menu and background monitor to re-run up to 48 filesystem/index searches per slot on every render, scroll, and 0.5s timer tick. With negative caching, subsequent checks now return in 0 ms.
  - **Save Slot Enumeration Bypass for Name Refresh (`SaveDataProcessor.cs`)**:
    - Guarded `SaveDataProcessor.OnSaveLoaded` (`SystemSave.Load` postfix) to skip execution when inside the Save/Load menu (`UISaveLoad1.Inst != null || UISaveLoad2.Inst != null`).
    - Eliminates redundant, heavy synchronous disk directory scanning, timestamp sorting, and JSON parsing that previously fired 142 times consecutively in S1 and 75 times in S2 during initial menu opening.

---

## [2026.10.26]

- **Project Kyaro Suite Realignment: Dedicated Suikoden 2 Bathhouse Plugin (`PKS2BathNPCPatch`)**:
  - Migrated the Suikoden 2 NPC Bathhouse Visitors feature (restoring the cut 1998 PS1 companion bathing mechanics utilizing accessible sprite assets) from PKCore into an independent, standalone BepInEx IL2CPP plugin: `PKS2BathNPCPatch.dll` (`faospark.pks2bathnpcpatch`).
  - Includes full native crash prevention (dummy `P_GRAPH_DATA`, safe `G2_varia_dat`/equipment checks), canonical ID roster mapping (IDs `85`..`123`), 8-character capacity expansion, authentic gender separation (men's tub `0..5`, women's tub `6..11`, Case 2 Simone/Vincent unisex preservation), special vanilla vignette preservation (Flik & Viktor, Matilda Knights), and dynamic narrative gating for Pilika (`IsPilikaInCastle()` checking Story Flag 14 / Muse Peace Conference).
  - Removed `Patches/NPCBathVisitorPatch.cs` and configuration binding `EnableNPCBathVisitors` from `PKCore/ModConfiguration.cs` and `PKCore/Plugin.cs`.

- **Project Kyaro Suite Realignment: Dedicated Rune Sage Plugin (`PKRuneSagePlus`)**:
  - Migrated the Suikoden 1 Castle Rune Master Shop Expansion (`S1JeaneRuneShopPatch`) and Suikoden 2 Sajah Village Rare Rune Shop Early Unlock (`SajahShopUnlockPatch`) from PKCore into an independent, standalone BepInEx IL2CPP plugin: `PKRuneSagePlus.dll` (`faospark.pkrunesageplus`).
  - Jeane's 4-choice menu layout (`Attach`, `Remove`, `Buy`, `Exit`), progressive town rune catalog, and Toran Castle level scaling are now cleanly encapsulated in `PKRuneSagePlus`.
  - Sajah Village rare rune vendor early unlock in `vj17` is now managed with self-contained map initialization and event patching.
  - Removed `Patches/S1JeaneRuneShopPatch.cs`, `Patches/SajahShopUnlockPatch.cs`, and corresponding configuration bindings (`EnableS1JeaneRuneShop`, `UnlockSajahRareShopEarly`) from `ModConfiguration.cs` and `Plugin.cs`.

- **Project Kyaro Suite Realignment: Dedicated Castle Storage Plugin (`PKS1CastleStorageAnywhere`)**:
  - Migrated the Suikoden 1 Remote Castle Vault Access feature (`S1QuickStoragePatch`) from PKCore into an independent, standalone BepInEx IL2CPP plugin: `PKS1CastleStorageAnywhere.dll` (`faospark.pks1castlestorageanywhere`).
  - Encapsulated complete vault management, native state machine lifecycle, Rock warehouse background suppression, and input handling (Right Stick Up / R3 / [F6]) into the new dedicated project.
  - Refactored `S1QuickRunePatch` in PKCore to maintain self-contained field context tracking and input/movement blocking hooks without inter-patch coupling.
  - Removed `Patches/S1QuickStoragePatch.cs` and configuration bindings (`EnableS1QuickStorage`, `S1QuickStorageRequireRock`) from `ModConfiguration.cs` and `Plugin.cs`.

- **Project Kyaro Suite Realignment: Dedicated Tenzan Pass Plugin (`PKTenzanPassPatch`)**:
  - Migrated the Tenzan Pass Chimera Encounters Restoration feature from PKCore into an independent, standalone BepInEx IL2CPP plugin: `PKTenzanPassPatch.dll` (`faospark.pktenzanpasspatch`).
  - Copied the full patch implementation directly to `PKTenzanPassPatch` with built-in map tracking (`MACHICON.EventInit`) and eliminated redundant game context detection dependencies.
  - Removed `Patches/TenzanPassEncounterPatch.cs` and configuration bindings (`EnableTenzanChimeraFix`, `ForceTenzanChimeraEncounter`, `TenzanChimeraCycloneDropRate`) from `ModConfiguration.cs` and `Plugin.cs`.

---

## [2026.10.25]

- **Suikoden II: Muse Ruins Survivors Restoration Removal**:
  - Removed `Patches/MuseRuinsSurvivorsPatch.cs` and disabled runtime patching.
  - Removed configuration entry `EnableMuseRuinsSurvivorsRestoration` from `ModConfiguration.cs` and `Plugin.cs`.
  - Updated documentation to reflect the removal of the patch.

- **Project Kyaro: Multi-Tier Game Context Detection Architecture**:
  - Upgraded `GameDetection.cs` across PKCore and PKBattlePatch to a high-reliability, zero-latency detection algorithm.
  - **Tier 1 (Instant Scene Matching)**: Inspects the active Unity scene container (`GSD1`, `GSD2`, `main`, `init`).
  - **Tier 2 (Event-Driven Scene Dispatch)**: Subscribes to `SceneManager.sceneLoaded` upon startup so game transitions update immediately without waiting a frame for the `Update` loop.
  - **Tier 3 (Native Ground-Truth Memory Validation)**: Falls back to verifying native memory structures (`GSD2::G2_SYS.G2_party_dat()`, `GSD2::OldSrcBase.game_work`, `UISaveLoad2.Inst` for S2; `S1::OldSrcBase.game_work`, `UISaveLoad1.Inst` for S1).
  - **Tier 4 (On-Demand Query Resolution)**: `GetCurrentGame()`, `IsGSD1()`, and `IsGSD2()` now resolve on-demand if queried during early startup or scene transitions, eliminating race conditions across texture replacement, portraits, and combat patches.

- **Dear ImGui Overlay Streamlining & Movement Input De-Interference**:
  - Streamlined `ImGuiOverlayUI.cs` from ~2,000 lines down to a dedicated, lightweight Location & Notes tool, eliminating the heavy debug inspector panes, multi-tab layout, and bathhouse/roster diagnostic windows.
  - **Zero Input Interference**: Completely eliminated invasive input blockers (`GRInputManagerBlockerPatch`, `G2PadBlockerPatch`, and `G1PadBlockerPatch`). Gamepad inputs, analog sticks, and keyboard inputs are no longer intercepted or zeroed out, resolving movement stutter and restoring full compatibility with player movement and movement mods.
  - **Streamlined Location & Notes HUD**: Retained the live Map ID telemetry display in the bottom-left corner with interactive notes editing (`[+ Note]` / `[Edit Note]`), inline area notes text box with Enter-to-save, `[Dump]` button / `[NumPad 5]` shortcut to append to `locationdump.log`, and `[Open Log]` direct launcher.
  - **Hotkeys & Ergonomics**: Added `[NumPad 6]` / `[F9]` (or clicking inside HUD bounds) to open note input, `[Escape]` to dismiss, and dynamic mouse cursor unlocking only when note editing is active.

- **Project Kyaro Suite Realignment: Dedicated Combat & Battle Plugin (`PKBattlePatch`)**:
  - Graduated all combat, battle HUD, and battle balance systems from PKCore into a standalone BepInEx IL2CPP plugin: `PKBattlePatch.dll` (`faospark.pkbattlepatch`).
  - Decoupled 9 battle patches and their respective configuration settings from PKCore:
    - **Battle HUD**: `BattleEnemyLevelPatch.cs` (enemy Level & HP display for S1 & S2), `BattlePartyHPPatch.cs` (party status window Max HP display for S1 & S2).
    - **Combat QoL**: `MemoryAutoBattlePatch.cs` (command memory auto-battle loop for S2), `SmartHealingPatch.cs` (post-battle automated triage & item healing for S2), `BattlePositionPatch.cs` (formation spacing adjustments for S2).
    - **Combat Balance**: `CommandRuneUnlimitedPatch.cs` (unlimited uses for Trick, Groundhog, Spider Slay, Angry Dragon runes for S2), `RuneUnbalancePatch.cs` (unbalance status removal for S2), `CharacterRangePatch.cs` (character weapon range adjustments for S2).
    - **Diagnostics**: `BattleUnitWindowDiagnostics.cs` (party status window layout dump for S1 & S2), `BattlePositionPatch.cs` (formation coordinate reporting for S2).
  - Updated `ImGuiOverlayUI.cs` to document the migration of battle settings to `PKBattlePatch.cfg`.
  - Removed obsolete battle configuration entries from `ModConfiguration.cs` and lifecycle calls from `Plugin.cs`.

- **Project Kyaro Suite Realignment: Dedicated Button Prompts Plugin (`PKButtonPrompts`)**:
  - Migrated controller button prompt override features from PKCore into a standalone BepInEx plugin (`PKButtonPrompts`).
  - Removed `Patches/GlobalControllerPromptPatch.cs` and configuration bindings (`ForceControllerPrompts`, `ControllerPromptType`) from PKCore.
  - Purged button prompt cache keys from texture manifest calculation in `Patches/CustomTexturePatch.Caching.cs`.

- **Suikoden I & II: Assembly Alias Conflict Resolution (`S1` / `S2`)**:
  - Configured dedicated `S1` and `S2` assembly aliases in [PKCore.csproj](PKCore.csproj) (`<Aliases>global,GSD1,S1</Aliases>` and `<Aliases>global,GSD2,S2</Aliases>`).
  - Migrated Suikoden 1 patch files ([S1JeaneRuneShopPatch.cs](Patches/S1JeaneRuneShopPatch.cs), [S1QuickRunePatch.cs](Patches/S1QuickRunePatch.cs), [S1QuickStoragePatch.cs](Patches/S1QuickStoragePatch.cs), [BattleEnemyLevelPatch.cs](Patches/BattleEnemyLevelPatch.cs), [EncounterNonePatch.cs](Patches/EncounterNonePatch.cs), and [ImGuiOverlayUI.cs](Patches/ImGuiOverlayUI.cs)) from `extern alias GSD1;` to `extern alias S1;`.
  - Permanently eliminates Roslyn / VS Code CS0234 false-positive red underlines caused by namespace ambiguity with internal `GSD1.UI.Component` and `GSD2.UI.Component` namespaces.

## [2026.10.24]

- **Suikoden I: Castle Rune Master (Jeane) Earth Rune Level 1 & Canonical Rune Mapping Fix**:

## [2026.10.23]

- **Suikoden I: Castle Rune Master (Jeane) Shop Catalog & Scrolling Fix**:
  - Implemented in [S1JeaneRuneShopPatch.cs](Patches/S1JeaneRuneShopPatch.cs).
  - **Shop Catalog Population & Scrolling Resolution**:
    - Fixed an issue where the Buy shop item list stopped at "Lightning Orb" (index 3) and could not be scrolled down further.
    - Resolved root cause: IL2CPP static constants in `GSD1.G_monsyo_h.monsyo_*` evaluated to `0` at runtime, causing castle tier progression runes to fail item ID resolution and be omitted from the shop catalog.
    - Replaced runtime static field lookups with explicit canonical rune ID integer constants for Castle Tiers 1 through 4:
      - Castle Level 1: Water (`1`), Fire (`2`), Wind (`3`), Earth (`4`), Lightning (`5`), Fortune (`23`), Prosperity (`24`).
      - Castle Level 2: Resurrection (`7`), Clone (`13`), Counter (`14`), Killer (`15`), Phero (`16`), Spark (`17`), Haziness (`18`), Gale (`19`).
      - Castle Level 3: Rage (`28`), Flowing (`29`), Cyclone (`30`), Mother Earth (`31`), Thunder (`32`).
      - Castle Level 4: Sunbeam (`20`), Champion's (`25`), Turtle (`26`), Double-Beat (`27`).
    - Added Fire Orb (`2`) and Earth Orb (`4`) to the baseline starter shop catalog alongside Water (`1`), Wind (`3`), and Lightning (`5`) Orbs.
    - Corrected Warriors' Village catalog entry from duplicate Fortune Rune (`23`) to Killer Rune (`15`).
    - Added direct table lookup fallback against `h_monsyo_c.monsyo_fuuin_table` to guarantee rune crystal item ID resolution across all game states.

- **Suikoden I: Quick Castle Vault & Quick Rune Master Battle Guard False-Positive Fix**:
  - Implemented in [S1QuickStoragePatch.cs](Patches/S1QuickStoragePatch.cs) and [S1QuickRunePatch.cs](Patches/S1QuickRunePatch.cs).
  - Fixed an issue where Quick Castle Vault (Right Stick Up) and Quick Rune Master (Right Stick Down) became permanently disabled with `"Cannot open: Currently in battle"` after fighting any battle or entering an encounter area:
    - Root cause: The guard check inspected `GAME_WORK.battle_data != null`. In Suikoden 1 (`BATTLE_DATA`), this object is actually the map encounter counter and step probability structure, which is allocated once when entering any encounter zone or fighting a monster party and remains allocated for the rest of the game session.
    - Replaced the `gw.battle_data != null` check with explicit battle lifecycle tracking (`IsInBattle`).
    - Added Harmony hooks to `GSD1.BattleChapter`:
      - `BattleChapter.Start()` sets `IsInBattle = true`.
      - `BattleChapter.BattleEnd()` and `BattleChapter.OnDestroy()` reset `IsInBattle = false`.
      - `Village_c.village_main` and `Fmain_c.fieldMain` also guarantee `IsInBattle = false` whenever village or world map updates execute.

- **Suikoden I: Quick Rune Master & Quick Vault Transition Guard Fix**:
  - Implemented in [S1QuickStoragePatch.cs](Patches/S1QuickStoragePatch.cs).
  - Fixed a false-positive state lock where Quick Rune Master and Quick Vault became unresponsive after entering a village, castle, or reloading a save:
    - Root cause: `CurrentField` (`Fmain_c`) retained references across map transitions when moving from world map to village/interior. The transition exit flags (`loadVillage` / `field_exit_flg`) remained non-zero on the stale field instance, permanently triggering the `"World map transition in progress"` safety guard.
    - Updated `CurrentVillage_main` prefix to clear `CurrentField = null` when active in a village/castle, and updated `fieldMain` prefix to clear `CurrentVillage = null` when on the world map.
    - Guard check now explicitly requires `CurrentVillage == null && CurrentField != null` before checking world map transition flags.

## [2026.10.22]

- **Suikoden I: Castle Rune Master (Jeane) Shop Expansion & Progressive Crystal Store**:
  - Implemented in [S1JeaneRuneShopPatch.cs](Patches/S1JeaneRuneShopPatch.cs).
  - **Menu Expansion & Re-Indexing**:
    - Re-indexed Jeane's command selection menu to 4 options: `[0] Attach`, `[1] Remove`, `[2] Buy`, and `[3] Exit`.
    - Dynamically resizes the selection window (`KAU_WIN`) to cleanly accommodate 4 rows without visual overlap or text clipping.
    - Integrated native menu navigation for 4-way cursor wrapping with standard sound effects (`D_azukar_c.SE_MOVE`, `G_cmd_c.SE_OK`, `G_cmd_c.SE_CANCEL`).
  - **Native Buy Sub-Shop Integration (`h_omise_c`)**:
    - Selecting `Buy` launches the native item purchase interface (`h_omise_c`) populated exclusively with Rune Crystals, bypassing redundant shop sub-menus.
    - Players can view crystal prices, read in-game lore/help descriptions, select party members to receive items, and confirm purchases with full audio feedback and inventory checks.
    - Exiting the buy catalog returns smoothly to Jeane's main menu, allowing players to immediately attach newly purchased runes.
  - **Progressive Town Rune Stock (Chandler-Style)**:
    - Automatically aggregates Rune Crystals from town rune shops visited across the world (Gregminster, Lenankamp, Kaku, Kouan, Sarady, Antei, Rikon, Warriors' Village, Kirov, and Qlon Temple).
    - Excludes Holy Rune as it is exclusive to Stallion and Suikoden HD Remaster has built-in running.
    - Unlocks items in real-time as Tir explores towns and verifies visited locations via save data points (`Event_c.point_chk`).
    - **Castle Level Progression Tiers**:
      - **Castle Level 1**: Water, Fire, Wind, Earth, Lightning, Fortune, Prosperity.
      - **Castle Level 2**: Clone, Resurrection, Killer, Gale, Counter, Spark, Haziness.
      - **Castle Level 3**: Rage, Cyclone, Flowing, Thunder, Mother Earth.
      - **Castle Level 4**: Turtle, Phero (Pheromone), Sunbeam, Double-Beat, Champion's.
  - **Remote Access Synergy**:
    - Fully compatible with direct in-person interaction at Toran Castle and remote field access via [S1QuickRunePatch.cs](Patches/S1QuickRunePatch.cs) (**Right Stick Down** / **[F7]**).
  - **Configuration Setting**:
    - `EnableS1JeaneRuneShop` (default: `true`) — Toggles Jeane's expanded 4-choice menu and progressive crystal shop.

## [2026.10.21]

- **Suikoden I: Quick Storage & Rune Master Area Load Verification**:
  - Implemented in [S1QuickStoragePatch.cs](Patches/S1QuickStoragePatch.cs) and [S1QuickRunePatch.cs](Patches/S1QuickRunePatch.cs).
  - Added `HasMapBackgroundChild()` check inspecting `AppRoot/Map/MapBackGround` for active child transforms (`childCount > 0`).
  - Ensures Remote Castle Vault (Rock) and Remote Rune Master (Jeane) are only functional once Suikoden I has fully loaded the map background and placed Tir McDohl on the active area, preventing activation during scene loading or transitions.
  - Reverted unnecessary overengineered transition and fade checks, restoring the fast, clean baseline behavior.
  - Streamlined Castle recruit requirements: when `S1QuickStorageRequireRock` or `S1QuickRuneMasterRequireJeane` is true, verified against established Toran Castle status (`shiro.level > 0`), ensuring non-combatant castle staff recruits are correctly recognized without relying on party member slots. When false, unlocks access unconditionally from anywhere.
    - Both features can now be accessed anywhere on the field without requiring Rock, Jeane, or Toran Castle establishment.

## [2026.10.20]

- **Suikoden I: Audio Feedback & Input Robustness for Quick Storage & Quick Rune Master**:
  - Implemented in [S1QuickStoragePatch.cs](Patches/S1QuickStoragePatch.cs) and [S1QuickRunePatch.cs](Patches/S1QuickRunePatch.cs).
  - **Native Open & Close Sound Effects**:
    - Triggering either menu (Right Stick Up for Castle Vault or Right Stick Down for Castle Rune Master) now plays the authentic Suikoden 1 menu open chime (`P_sound_c.Qsd_call(G_cmd_c.SE_OK)`).
    - Closing either menu (via native Back/Cancel button, selecting "Exit"/"Quit" in the menu, or toggling with R3 / Right Stick / function keys) plays the authentic Suikoden 1 menu cancel/close chime (`P_sound_c.Qsd_call(G_cmd_c.SE_CANCEL)`).
  - **Castle Vault Black Flash Elimination**:
    - Identified that `IsQuickStorageOpen` was being set after `D_azukar_c.azukari_demo()` returned, which allowed native `Initialize()` and `SetFadeBright(0f)` to execute on frame 0, rendering a brief black transition quad before suppression applied.
    - Switched state flag activation to frame 0 *before* calling `azukari_demo()`, ensuring all suppression patches are active from the very first instruction.
    - Extended background suppression to disable both `bg_obj` and `azukari_obj` across `UIAzukari.Initialize`, `CriateAzukari`, and `SetFadeBright`.
    - Hooked `UIManager.FadeOut`, `FadeIn`, and `Fade` during quick menus to completely block full-screen screen fades while retaining callback completion. Result: completely seamless, zero-flash transparent overlay opening.
  - **Rune Master Input Edge-Detection Fix**:
    - Replaced raw synthetic button checks with clean single-edge analog threshold detection (`isStickDown && !_wasRightStickDownPrev`).
    - Resolved an issue where moving the analog stick down to browse runes or menu options within Rune Master could trigger an early close.
    - Removed conflicting keyboard letter keys (`[R]`, `[B]`) to avoid accidental triggers while running or typing; standardized keyboard controls on **[F6]** (Vault) and **[F7]** (Rune Master).
    - Added full fallback initialization for `OMISE_DATA.message` and static castle reference assignment in `OpenRuneMaster()`.

- **Suikoden I: Right Stick Down Castle Rune Master Remote Access (Jeane Anywhere)**:
  - Implemented in [S1QuickRunePatch.cs](Patches/S1QuickRunePatch.cs).
  - **Direct Field Access**: Flicking **Right Stick Down** (or pressing **[F7]** on keyboard) opens the Toran Castle Rune Master shop directly from anywhere on the field (dungeons, towns, world map) without needing to travel back to Toran Castle.
  - **Native Remaster UI Lifecycle**: Directly initializes and advances the native `h_monsyo_c.init_monsyo()` state machine with `Event_c.shiro_monsyou_data`, providing full access to attaching runes, removing runes, and rune purchasing. Pressing Back/Cancel (or Right Stick Down again) safely executes `h_monsyo_c.monsyo_exit()` to tear down the window hierarchy and restore field gameplay.
  - **Loading Screen & Scene Transition Immunity**:
    - Pre-flight validation checks `UIManager.isFadeInState`, `isFadeOutState`, `IsFadeOutEnd`, `UIManager.Instance.loading`, `UILoadingAnim.IsLoadingAnimeResources`, `UILoadingAnim.instance.doStopAnime`, and background asset loading (`MapBGManager.IsLoading`, `FieldBGManager.IsLoading`).
    - Guarantees the Rune Master window cannot be opened during loading screens, map shifts, or screen transitions.
  - **Single-Window Mutual Exclusion & Dialogue Lock**:
    - Strictly prevents opening the Rune Master if the Castle Vault is open or currently activating (`IsQuickStorageOpen`).
    - Blocks opening during active story NPC dialogue, message windows, or choice popups (`WindowManager.GetIsOpen()`, `IsUseMessageWindow`, `IsOpenCommonDialogWindow()`).
  - **Complete Background Movement & Input Silencing**:
    - Silences Tir McDohl and party follower movement while the shop is active by intercepting all movement and controller processing across `Village_c` (`NewPlayerMove`, `OldPlayerMove`, `playerMoveBase1/2/3`, `player_move`, `playerOP_move`, `CheckArrivedEvent`) and `Fmain_c` (`userMove`, `userMoveSet`, `padReaction`). Prevents the protagonist from moving or triggering events in the background while navigating rune menus.
    - Suppresses wandering monster encounters (`v_wanderingMonsterChk` / `f_wanderingMonsterChk`) and normal pause menu activation while open.
  - **Configuration Settings**:
    - `EnableS1QuickRuneMaster` (default: `true`) — Toggles the feature.
    - `S1QuickRuneMasterRequireJeane` (default: `false`) — When true, restricts access until Jeane is recruited in Antei (`member_flag[FP_JIJ] != 0`). When `false`, unlocks access anytime from anywhere without recruitment or castle restrictions.

- **Suikoden I: Right Stick Up Castle Vault Remote Access (Rock's Warehouse Anywhere)**:
  - Implemented in [S1QuickStoragePatch.cs](Patches/S1QuickStoragePatch.cs).
  - **Direct Field Access**: Flicking **Right Stick Up** (or pressing **R3** / **[F6]** on keyboard) opens Rock's Castle Vault directly from anywhere on the field (dungeons, towns, world map) without needing to travel back to Toran Castle.
  - **Native Remaster UI Lifecycle**: Directly initializes and advances the native `D_azukar_c.azukari_demo()` state machine and `WindowManager.OpenStorageWindowUI`, retaining full native HD Remaster menus, audio, item descriptions, and deposit/withdraw controls. Pressing Back/Cancel (or Right Stick Up / R3 again) safely tears down the storage windows and terminates `UIAzukari`.
  - **Zero-Delay Instant Opening & Background Asset Bypass**:
    - By default, the native game asynchronously loads Rock's static warehouse background illustration and pauses execution every frame until `UIAzukari.IsCompleteInitialize()` completes.
    - Patched `UIAzukari.Initialize` and `IsCompleteInitialize` to bypass the asynchronous background sprite loading completely and signal instant readiness on frame 0.
    - Completely eliminates the delay when opening the vault, allowing the menu to open instantly and keeping the current field scene cleanly visible behind the UI.
  - **Loading Screen & Scene Transition Immunity**:
    - Pre-flight validation checks `UIManager.isFadeInState`, `isFadeOutState`, `IsFadeOutEnd`, `UIManager.Instance.loading`, `UILoadingAnim.IsLoadingAnimeResources`, `UILoadingAnim.instance.doStopAnime`, and background asset loading (`MapBGManager.IsLoading`, `FieldBGManager.IsLoading`).
    - Guarantees the vault cannot be opened during loading screens, map shifts, or screen transitions.
  - **Single-Window Mutual Exclusion & Dialogue Lock**:
    - Strictly prevents opening the Castle Vault if the Rune Master is open or currently activating (`IsQuickRuneMasterOpen`).
    - Blocks opening during active story NPC dialogue, message windows, or choice popups (`WindowManager.GetIsOpen()`, `IsUseMessageWindow`, `IsOpenCommonDialogWindow()`).
  - **Complete Background Movement & Input Silencing**:
    - Completely stops Tir McDohl and follower movement while browsing vault items by intercepting all input and locomotion logic across `Village_c` (`NewPlayerMove`, `OldPlayerMove`, `playerMoveBase1/2/3`, `player_move`, `playerOP_move`, `CheckArrivedEvent`) and `Fmain_c` (`userMove`, `userMoveSet`, `padReaction`). Eliminates background character walking while scrolling through vault items.
    - Suppresses wandering monster encounters (`v_wanderingMonsterChk` / `f_wanderingMonsterChk`) and standard menu open calls while open.
  - **Configuration Settings**:
    - `EnableS1QuickStorage` (default: `true`) — Toggles the feature.
    - `S1QuickStorageRequireRock` (default: `false`) — When true, restricts vault access until Rock is recruited (`member_flag[FP_LOK] != 0`). When `false`, unlocks access anytime from anywhere without recruitment or castle restrictions.

- **Dear ImGui Overlay Input Isolation & Controller/Keyboard Game Silencing**:
  - Implemented in [ImGuiOverlayUI.cs](Patches/ImGuiOverlayUI.cs).
  - **Dynamic Input Silencing**: Fixed an issue where gamepad controller buttons, analog sticks, and keyboard strokes passed through to the main game while navigating, clicking, or typing into the overlay.
  - **Context-Aware Focus Tracking**: Silences background game controls whenever:
    - The main Dear ImGui overlay window is open (`IsOpen`).
    - The dedicated Castle Bathhouse inspector is open (`ShowBathhouseWindow`).
    - The area note input popup is active (`_showHudNoteInput`).
    - The mouse cursor is hovering over any Dear ImGui window, menu bar, or widget (`io.WantCaptureMouse` or `io.WantCaptureKeyboard`), including when interacting with the bottom-left Location HUD.
  - **Multi-Subsystem Interception**: Harmony hooks across `GRInputManager` (`IsOn`, `IsPress`, `IsHold`, `IsRepeat`, `IsOff`, `IsAny`, `IsKeyDown`, `IsKeyPress`, `GetValue`, `IsRunValue`), `G2_PAD` (`PadRead`, `PadRRead`), and `Pad` (`PadRead`, `PadRRead`) ensure complete silence of background movement, menu actuation, and combat commands without affecting ImGui's direct input processing or hotkeys (`[F10]`, `[Escape]`).

- **Dear ImGui Overlay Sidebar Streamlining & Dedicated Themes / Settings Page**:
  - Implemented in [ImGuiOverlayUI.cs](Patches/ImGuiOverlayUI.cs).
  - **Sidebar Decluttering**: Streamlined the left navigation panel strictly to the search filter and section navigation buttons. Removed duplicate theme dropdowns, pills, redundant bathhouse buttons, quick toggles, and the cramped mini-location child window to ensure the sidebar fits entirely without scrolling.
  - **Relocated Location & Area Notes Widget**: Moved the full telemetry and area notes interface (Map ID, Stars of Destiny count, Area Notes text input with `[X]` clear, `Append to locationdump.log [NumPad 5]`, and `Open Log`) into the **General & Debug** section where it has full horizontal breathing room.
  - **Dedicated Themes & Settings Section**: Added **Section 7: Themes & Settings** accessible via sidebar navigation and keyword search (`theme`, `settings`, `appearance`, `style`, `color`). Includes full interactive preset cards for **Classic Blue**, **Matrix Green**, **Obsidian Black**, and **Dark Magenta**, descriptions, live swatch feedback, and overlay hotkey reminders.
  - **Layout & Column Fix**: Resolved Dear ImGui channel splitter access violation crashes and line-wrap blank rendering by converting the two-column master-detail layout to `ImGui.Columns(2, "PKCoreColumns", true)` with independent scrolling and unconditional child window lifecycles.

- **Tile & Entity Editor (Live Map Inspector & In-Memory Entity Placer)**:
  - Implemented in [ImGuiOverlayUI.cs](Patches/ImGuiOverlayUI.cs).
  - Accessible directly in the Dear ImGui overlay via **Section 8: Tile & Entity Editor** (or via keyword filter `tile`, `entity`, `object`, `placer`, `inspect`, etc.).
  - **Live Tile Inspector**: Select any tile coordinate `(X, Y)` with quick buttons (`[Sync Riou]`, `Auto-follow Riou`, and `[<-]`/`[->]`/`[^]`/`[v]` nudge stepping). Scans the active submap's `eventobj` and `eventdat` arrays to display all physical entities (Class `otyp`, Sprite pattern `fpno`, Collision `ozok`, Facing `ano`, Dimensions `w`x`h`, and Active state `disp`) and all active trigger scripts (`etyp`, condition bounding box, and action bytecode summary). Includes quick `[Use]` buttons to clone any inspected object's properties directly into the placer.
  - **In-Memory Entity Placer & Injector**: Allows configuring and injecting new custom entities into the active map in memory:
    - Object Class (`otyp`: Actor/NPC 1, Environmental Prop 2, Device 3, Trigger Hitbox 4).
    - Sprite pattern picker with preset dropdown (Riou, Jowy, Nanami, Pilika, Apple, Clive, Millie, Shiro, Viki, Soldier, Villager, Save Crystal, Chests, Bonsai, Signpost) and direct integer `fpno` input.
    - Collision attributes (`ozok`: Passable 0, Solid barrier 2, Counter table 3).
    - Facing direction (`ano`: South, East, North, West).
    - Optional interactive behavior:
      - **Warp Door**: Injects trigger bytecode allowing the object to act as a transition to any target map and submap.
      - **Save Point**: Injects native `ECSaveGo` (`opcode 38`) action trigger to open the game's `MSaveInit()` save system dialog.
      - **Full Rest & Inn Heal**: Restores all party HP and spell slots.
  - **Export Placements to JSON**: Appends configured custom object definitions to `\PKCore\Logs\custom_map_objects.json` for persistence, sharing, and mod authoring.
  - **Session Injection History**: Tracks all custom objects created during the session with map code, coordinates, sprite, class, and interaction summary, with a one-click `[Clear Session History]` action.
  - **Comprehensive Documentation**: Detailed architectural guide, UI layout breakdown, bytecode reference, and step-by-step tutorials documented in [Tile & Entity Editor Guide](Documentation/tile_and_entity_editor_guide.md).

- **Map Teleport & Time-Phase Re-entry Warper (Dear ImGui Overlay)**:
  - Implemented in [ImGuiOverlayUI.cs](Patches/ImGuiOverlayUI.cs) and [MapTrackingPatch.cs](Patches/MapTrackingPatch.cs).
  - **Inter-Map Time-Phase Warper**: Allows traveling to any map code and story-phase variant across the game (such as Muse Normal `vc01`, Night Siege `vc02`, Highland Occupation `vc25`, Post-Liberation Rebuilding `vc26`, City Hall Early `vc09` vs Post-Liberation `vc27`, Courtyard `vc31`, etc.) directly from the Dear ImGui overlay (**Section 7: Map Teleport & Warp**).
  - **Safe Native Bytecode Warp Execution**: Arms a clean native map transition (`opcode 31` room change + `opcode 32` town transition) dynamically injected at the player's current tile. Taking one step or pressing Confirm activates the game's native fade-and-load pipeline, ensuring sound banks, cameras, and collision grids initialize cleanly without crashing.
  - **Story Phase Presets & Custom Map Codes**: Includes 35 built-in presets for major story locations, as well as custom text and submap inputs for entering any arbitrary map code (`va` through `vt`).
  - **Intra-Map Direct Coordinate Teleport**: Allows instantly repositioning Riou's tile coordinates (`px`, `py`) and world coordinates (`mx`, `my`) on the active map without walking.
  - **Live Coordinate Telemetry & Dump Integration**: Displays player grid coordinates `(X, Y)` live on the bottom-left Location HUD and includes exact player coordinates in all location dump logs (`[NumPad 5]`).

- **Save Slot Party Member Portrait Soft-Reset Reloading Fix**:
  - Fixed in [SaveSlotPartyPortraitPatch.cs](Patches/SaveSlotPartyPortraitPatch.cs).
  - **Zombie Sprite Texture Invalidation**: Fixed a bug where soft-resetting or returning to the title screen caused character preview portraits in the save/load window to turn into blank white squares. The static `portraitCache` previously returned stale Sprite wrappers whose underlying Unity `Texture2D`s had been destroyed during scene unloading and texture cleanup.
  - **Texture & Dimension Verification**: Added `IsSpriteValid` verification checking that both the `Sprite` and its underlying `Texture2D` are non-null with active native IL2CPP pointers and valid dimensions before any cached entry is used. If invalid, the dead entry is immediately evicted and triggered for full reload.
  - **Scene & Save Window Lifecycle Cache Purging**: Registered a listener on `SceneManager.sceneLoaded` and hooked `UISaveLoad1.Init` / `UISaveLoad2.Init` to call `ResetCache()`, guaranteeing that `portraitCache`, `pendingLoadIds`, `gcRoots`, and `slotPortraitContainers` are cleared across soft resets and scene loads so all character portraits are loaded cleanly from disk/resources.
  - **Active Coroutine Runner & Null Guard**: Provided a guaranteed fallback runner (`slotInstance`) for async portrait loading if `SaveSlotPortraitMonitor.Instance` is destroyed or resetting, and initialized portrait images to transparent while awaiting async decoding to prevent untextured white box rendering.

- **Dear ImGui Current Data Location Box, Bottom HUD & Hotkey Dump (`[NumPad 5]`)**:
  - Implemented strictly within [ImGuiOverlayUI.cs](Patches/ImGuiOverlayUI.cs) and [ModConfiguration.cs](ModConfiguration.cs).
  - **Bottom-Left Location HUD**: When the main Dear ImGui overlay is closed, the compact HUD is anchored at the **bottom-left** of the screen (`Location: <MapId>`). Clicking anywhere on the HUD or pressing **`[NumPad 6]`** / **`[F9]`** seamlessly activates the inline text field and transfers input focus.
  - **Inline Notes & Dump in HUD**: Players can write an area description right in the HUD, press Enter or click **`[Dump]`** (or hotkey **`[NumPad 5]`**), and see active notes right alongside the location.
  - **Open Dump Log Button**: Added an **`[Open Log]`** button directly beside every Dump button (in the bottom-left HUD, overlay sidebar, and Scene Telemetry). Clicking it immediately opens `\Suikoden I and II HD Remaster\PKCore\Logs\locationdump.log` (or the containing folder) in Windows Explorer / default text editor.
  - **In-Overlay Stars & Telemetry Cleanup**: Stars of Destiny count resides cleanly inside the main overlay (`Stars: <Count> / 108`).
  - **In-Overlay Toggle & Persistence**: Can be toggled on/off at any time from inside the overlay via **MenuBar > Overlays > Bottom Screen Location HUD** or the **General & Debug** section. Persists cleanly across sessions in `PKCore.cfg` via `ShowLocationHUD`.
  - **Hotkey Dump (`[NumPad 5]`)**: Pressing **`[NumPad 5]`** at any point in gameplay immediately appends a formatted location snapshot (with any current notes) to `\Suikoden I and II HD Remaster\PKCore\Logs\locationdump.log`.

- **Smart After-Battle Auto-Healing Fixes & Safeguards**:
  - Fixed in [SmartHealingPatch.cs](Patches/SmartHealingPatch.cs).
  - **Battle Exit Confirmation Execution**: Relocated smart healing execution from premature mid-victory routines (`calc_exp` / `exit_sub00`) to the exact battle conclusion point: `BattleManager.StorePlayerData` Postfix (when the player confirms exit from the victory results screen) and `BattleManager.battle_exit99` Postfix (battle exit cleanup fallback). This guarantees all victory EXP, level-up calculations, and native character storage have finished before healing items are consumed and HP is applied.
  - **Field Menu Access Safety Net**: Added an additional trigger on `UIMainMenu.Open` Prefix (`ShareUI.Menu`), ensuring that whenever the field menu is accessed, any unhealed damage or poison is immediately treated before the party list is drawn.
  - **Direct Data Persistence**: Explicitly synchronizes healed HP and revived status across `G2_SYS.G2_pamem_hp`, `G2_SYS.G2_varia_dat(charaNo).now_hp`, and `G2_SYS.G2_party_dat().status[slot]`, ensuring that full recovery persists seamlessly when returning to the world map and opening menus.
  - **Stat-Booster Item Safeguard**: Fixed critical flaw in `GetItemInfo` dynamic discovery where permanent stat-boosting items (e.g. Stone of Power, Stone of Magic, Stone of Defense) were erroneously identified as healing items due to having positive `eff_val`. Enforced strict verification of the game's actual HP recovery flag `(dogu.info[1] & 0x20) != 0`, guaranteeing permanent stat stones are never consumed as potions.
  - **Top-Off & Overheal Policy**: Fixed flawed logic in `SelectBestItemGSD2` where `allowOverheal = false` and an artificial `deficit >= 40` floor blocked standard Medicine from healing characters missing under 40 (or under 100) HP. Standard/minor heals (`HealAmount <= 150`, such as Medicine) now reliably top off party members when missing health meets or exceeds `minDeficit` (10 HP), while mid-tier (`Mega Medicine`) and full-heal (`Healing Wind`) items remain strictly guarded against small-wound waste.
  - **Whole-Party Personal Inventory Gathering**: Fixed `GatherHealingItemsGSD2` to scan personal equipment inventories across all active party members (`partyChaNo`) rather than exclusively inspecting already-injured members, allowing backline or unhurt members' spare Medicines to be utilized if the Party Bag runs dry.
  - **Revived Character Status Flag Clearing**: Added clearing of dead status bit (`bpc.status &= ~0x800000u`) and `partyData.status[slot] = 0` during Sacrificial Jizo revival to prevent `BattleManager.StorePlayerData` from re-zeroing HP on battle transition.
  - **Dynamic Poison Cure Items**: Added `IsAntitoxinItem` to check both standard Antitoxin (#5) and any items/food with poison-curing status bit (`status[0] & 4 != 0`).

- **Encounter None Hotkey & Overlay Toggle (`[F4]`)**:
  - Implemented in [EncounterNonePatch.cs](Patches/EncounterNonePatch.cs).
  - Toggled via keyboard key **`[F4]`** or directly through the Dear ImGui overlay interface.
  - **SuikoFix Synergy**: Automatically detects whether `Suikoden_Fix` is loaded. If present, it directly manipulates `Suikoden_Fix.Plugin.Config.EncounterRateMultiplier` (setting it to `0.0f` to prevent battles, and cleanly restoring the player's prior multiplier when disabled).
  - **Native PKCore Fallback**: If Suikoden_Fix is not installed, it executes native Harmony prefix hooks on `EVENTCON.EventBatlleCheck` (Suikoden II), `Village_c.v_wanderingMonsterChk` (Suikoden I), and `Fmain_c.f_wanderingMonsterChk` (Suikoden I), ensuring zero random encounters across both games.
  - Displays real-time status badges and backend attribution in the Dear ImGui overlay.

- **Native Dear ImGui Overlay Engine (`[F10]` Multi-Theme & Two-Column Layout)**:
  - Implemented in [ImGuiOverlayUI.cs](Patches/ImGuiOverlayUI.cs) using genuine **Dear ImGui** (via `DearImGuiInjection` / `ImGui.NET`).
  - Rendered natively in DirectX 11 via swapchain present hooks with zero overhead, hardware mouse cursor acceleration, and thread-safe main loop action queues.
  - **Clean ASCII Typography**: Uses clean ASCII characters to prevent Dear ImGui font atlas fallback `?` question marks.
  - **4 Selectable Themes**:
    - **Classic Blue**: Deep navy and dark slate styling with vibrant blue headers, sky blue highlights, and clean borders.
    - **Matrix**: Pure carbon black with glowing phosphor green text, cyber-hacker accents, and electric green borders.
    - **Obsidian Black**: Sleek monochrome pure graphite obsidian with sophisticated ice silver and platinum accents.
    - **Dark Magenta**: Cyberpunk royal purple and midnight indigo with electric magenta and vivid fuchsia accents.
    - Switchable in real-time and persisted to `PKCore.cfg` under `ImGuiTheme`.
  - **Unbundled Plugin Design**: Installed as an independent standalone plugin in `BepInEx/plugins/DearImGuiInjection/` (referenced with `<Private>false</Private>` in `PKCore.csproj`), ensuring zero bloat bundled inside `PKCore.dll`.
  - **Combat & Runes Section**: Interactive controls for Memory Auto-Battle (S2) with memory reset, Unlimited Command Runes (Trick, Groundhog, Spider Slay, Angry Dragon), Rune Unbalance Removal, Range Overrides, and Enemy Level & HP toggles.
  - **Recovery & Progression Section**: Smart After-Battle Auto-Healing, Quick Party Heal, Early Sajah Village Rare Shop & Sage (vj17), Tenzan Pass Chimera Encounters Restoration with drop rates (`100%`, `50%`, `25%`, `2%`), and Muse Ruins Survivors Restoration.
  - **Visuals & World Section**: Save Point Crystal Color Picker (9 presets + cache clearing + glow toggle), World Map Clouds & Sunrays toggles, and Sprite Filtering (SMAA / Point) toggle.
  - **Castle Bathhouse Live Monitor**: Real-time inspection of who is soaking in the castle bathhouse across Men's Tub (slots 0..5) and Women's Tub (slots 6..11), displaying bather names, character IDs, gender classifications, origin, texture atlas coordinates, and water temperature gauges.
  - **Party & Roster Section**: Active 8-character roster table (Slots 0..7) with live HP, Max HP, and Castle Recruit visitor pools.
  - **Scene & Telemetry Section**: Live Map ID, Stars of Destiny count (108), bath status, encounter backend, and active subsystems.

- **Runtime Mouse Cursor Visibility Toggle**:
  - Enhanced in [MouseCursorPatch.cs](Patches/MouseCursorPatch.cs).
  - Added dynamic `IsEnabled` getter/setter and `Toggle()` method, enabling live OS cursor unlocking from the ImGui overlay without requiring game restarts.

- **Suikoden II Muse Ruins Survivors Restoration & 108 Stars Spiritual Reward (`EnableMuseRuinsSurvivorsRestoration`)**:
  - Implemented in [MuseRuinsSurvivorsPatch.cs](Patches/MuseRuinsSurvivorsPatch.cs).
  - **Dormant Victims Restoration**: Discovered 8 placed but untargeted NPC sprites (`obj[02]` through `obj[09]`) and 16 orphaned interaction scripts (`ev[62]` through `ev[77]`) in Muse Ruins (`vc26_01`). Re-targets these orphan scripts from non-existent slots `obj[35]..obj[42]` to the actual placed actors `obj[02]..obj[09]`, restoring their authored tragic dialogues (Bank 1, Messages 26–33).
  - **108 Stars Spiritual Reward**: Checks if all 108 Stars of Destiny have been gathered (`G2_SYS.Mem108Chk(0) >= 108`) or the Beast Rune has been defeated. When united, all 33 spirits and survivors throughout Muse Ruins (`obj[02]` through `obj[34]`) are cleansed and at peace, speaking their hidden, peaceful survivor dialogues (Bank 1, Messages 51–83).
  - Configurable via `EnableMuseRuinsSurvivorsRestoration` (Default: `true`).

- **Suikoden I Map Identifiers & Regional Breakdown Reference Guide**:
  - Authored complete architecture and geographic guide in [suikoden_1_map_ids_and_areas_breakdown.md](Documentation/suikoden_1_map_ids_and_areas_breakdown.md).
  - Documents all 12 regional sectors (`area_a` through `area_k`, `area_z`) and all 85 background maps (`bg_va1` through `bg_vz5`), mapped to their C# decompiled handlers (`G1_fdata_c.cs`, `VillageManager.cs`, `Village_c.cs`, `Event_c.cs`, `Fmain_c.cs`).
  - Cataloged the Suikoden 1 event command bytecode engine (`EVENT_COMMAND` enum with 70+ opcodes: `WINOP`, `WINCL`, `PUSHMARU`, `VILLAGEOUT`, `EVENTMSG`, `EVENTSHOP`, `EVENTITEM`, `EVENTBATTLE`, `PADD`, `PDEL`, etc.).
  - Side-by-side architectural comparison between Suikoden I and Suikoden II engine layers, detailing runtime coordinators, asset models, and PKCore Harmony hook targets.

- **High-Speed Symbol & Map Indexer Integration (`tools\sym.bat`)**:
  - Harmonized all 62 Suikoden II geographic areas and all 12 Suikoden I regional sectors (360 total map entries) directly into the SQLite symbol indexer database (`symbols.db`).
  - Added full map asset resolution in <1ms: querying by map ID (e.g. `vc18`, `va01`, `bg_va1`), area name (e.g. `Banner`, `Toto`, `Gregminster`), or region code instantly returns the C# handler class, source file location, documentation path, and narrative summary alongside types, members, and native addresses.
  - Added `--maps` CLI flag to filter queries strictly to map environments.
  - Integrated full FTS5 full-text indexing over map identifiers, area names, and narrative descriptions.

- **Human-Readable Field & Engine Legends across All 62 Geographic Area Volumes**:
  - Embedded the comprehensive **Field & Engine Legend** across all 62 area volumes in `Documentation/areas/` (`otyp`, `ozok`, `ano`, `disp`, `spd`, `wt`, `pri`, `etyp`, `eventForm`, `eventCom`).
  - Replaced all raw numerical opcodes across every trigger table with human-readable descriptions (`Display Dialogue Box`, `Warp Room`, `Open Save Crystal Menu`, `Recruit Character`, `Full Rest & Healing`, `Open Shop / Trade Interface`, `Add Character to Party`, `Adjust Potch Money`, `Play Sound Effect`, etc.).

- **Suikoden II Master Map Entities, Triggers & World Objects Catalog**:
  - Authored comprehensive technical documentation in [suikoden_2_master_map_entities_and_triggers_catalog.md](Documentation/suikoden_2_master_map_entities_and_triggers_catalog.md).
  - Documents the complete runtime entity architecture across all 226 master map assets (`va01` through `vk37`), compiling census data for all **4,901 NPCs**, **1,552 Dynamic Props**, **3,207 Collision Triggers & Single-Tile Dots**, **90 Save Orbs**, and **27 Dungeon Chest Clusters**.
  - **Bit-Level Entity Layout (`EVENT_OBJ`)**: Exhaustive mapping of all 13 physical fields (`otyp`, `disp`, `spd`, `wt`, `ano`, `ityp`, `fpno`, `ozok`, `pri`, `x`, `y`, `w`, `h`), explaining solid vs passable masks (`ozok`), facing frames, multi-tile bounding volumes, and single-tile dots (`w:0, h:0`).
  - **Trigger Evaluation Modes (`etyp`)**: Documents the 4 execution contexts: `etyp = 1` (Action/Confirm inspect), `etyp = 2` (Room Init / `OnMapLoad`), `etyp = 3` (Step-On Tripwire / Warp), and `etyp = 4` (Continuous Frame Loop).
  - **Condition Bytecode (`eventForm`)**: Full parameter specifications for condition opcodes (Story flags `3`/`4`, spatial boxes `1`, orientation `2`, target matching `5`, inventory `6`, party members `10`/`11`, treasure bits `27`/`28`, castle tiers `30`).
  - **Master Action Command Catalog (`eventCom`)**: Cataloged all 147 `EC*` action methods in `EVENTCON.eventCommandFunction` (dialogue, camera tracking, screens, movement, pathfinding, warp transitions, shop overlays, party recruitment, stat buffs, potch, and battles).
  - **In-Memory Injection Pattern**: Established the verified Harmony postfix blueprint on `MACHICON.EventInit` to dynamically expand `eventobj` and `eventdat` arrays at runtime, enabling modders to add custom actors, bonsai props, trigger dots, and shops without repacking Unity asset bundles.

- **Suikoden II Bathhouse Unisex Routing Restoration (Simone & Vincent)**:
  - Updated [NPCBathVisitorPatch.cs](Patches/NPCBathVisitorPatch.cs) to preserve the special gender code `2` for **Vincent de Boule** (ID 64) and **Simone Verdricci** (ID 65).
  - In vanilla Suikoden II, `EventOverlayClass.f_main$$GetFuroPos` evaluates gender code `2` at `0x18201a861` (Case 2): when no female party members are present, both Vincent and Simone are routed to **Positions 6..11** (the women's tub on the left side of the bathhouse), allowing them to bathe on the other side. If female party members are present, they join the men's tub (positions 0..5).
  - Fixed an overly strict binary check in `GetSeibetu_Prefix` that previously forced both characters to `0` (strictly Male).

- **Suikoden II Bathhouse Grounding: Ridley & Boris, Gadget, and Beasts Native Architecture**:
  - **Ridley & Boris Men's Side Routing**: Fixed a catalog error where ID 123 (Boris) was previously listed in `FemaleCharaIds` / `FemaleCastleNPCs`. Removed 123 from female pools, and added Ridley (IDs 118, 121) and Boris (ID 123) to `MaleCastleNPCs`, guaranteeing they both soak on the men's side (Positions 0..5).
  - **Native Gadget Implementation (ID 26)**: Grounded native hardcoded check at `0x18201ac20` in `EventOverlayClass.f_main$$GetSeibetu` (`cmp ebx, 0x1a -> xor eax, eax`) returning `0` (Male), giving Meg's barrel robot dedicated tub graphics in `hp_furo_26_atlas` on the men's side.
  - **Native Beasts Architecture**: Corrected documentation in [suikoden_2_character_attributes_gender_and_baths.md](Documentation/suikoden_2_character_attributes_gender_and_baths.md). All recruited beasts and monsters (Abizboah, Rulodia, Chuchara, Feather, Siegfried, Shiro, Mukumuku) have native bathhouse implementations, authentic sprite atlases via `(chara_id - 1)/5` indexing, and routing through the native gender jump table at `0x18201ac84`.

- **Suikoden II Bathhouse Grounding: Tenkou (99) and Teresa (95/102) Sprite Reclassification & Tub Routing**:
  - **Visual Sprite Verification**: Extracted and verified sprite blocks across `hp_furo_17_atlas` through `hp_furo_22_atlas`:
    - **Tenkou (ID 99)**: Visual cross-correlation confirmed ID 99 (`hp_furo_19_atlas` slot 3) is the bearded man with the gold headband (Tenkou). Previously miscataloged under female pools, causing him to appear in the women's tub. Reclassified ID 99 to `MaleCastleNPCs` and `PermanentCastleMales`, ensuring he routes strictly to the men's tub (Positions 0..5).
    - **Teresa Wisemail (ID 95 / 102)**: Visual inspection of `hp_furo_18_atlas` slot 4 verified the dark green haired female sprite (Teresa Wisemail). ID 95 was previously miscategorized in `MaleCastleNPCs`, causing her to appear in the men's tub. Reclassified ID 95 and ID 102 (blonde/light-green hair) to `FemaleCharaIds`, `FemaleCastleNPCs`, and `PermanentCastleFemales`, ensuring they route strictly to the women's tub (Positions 6..11).
    - **Male NPC Reclassifications**: Reclassified ID 91 (bare-chested young man), ID 94 (bare-chested spiky-haired man), and ID 97 (green-hat boy) to `MaleCastleNPCs`.
  - **Runtime Tub Placement Logging**: Added `GetFuroPos_Postfix` hook to log exact character ID and tub assignments (`Men's tub` vs `Women's tub`) to `LogOutput.log`. Unconditionally logged visitor selection in `PrepareBathParty` for runtime clarity.

## [2026.10.19]

- **Suikoden II NPC Bathhouse Sprites & Castle Visitors Restoration**:
  - Implemented in [NPCBathVisitorPatch.cs](Patches/NPCBathVisitorPatch.cs).
  - Restores the unused bathhouse sprites drawn for non-combatant castle recruits and story characters (stored across texture atlases `hp_furo_00_atlas` through `hp_furo_37_atlas`).
  - **Eliminated the Engine Crash Traps**:
    - **P_GRAPH_DATA Null Trap (`CreateFuroChara` at `0x182016059`)**: Disassembled and resolved the fatal null-dereference check in `EventOverlayClass.f_main$$CreateFuroChara` where non-combatants lacking combat `battle_data` and `field_data` triggered an immediate `NullReferenceException` crash (`0x182016725`). Hooked `G2_SYS.G2_gra_dat` to supply a lightweight dummy `P_GRAPH_DATA` fallback while inside the bathhouse, allowing all characters to render safely through `CreateFuroAnime` without altering any combat systems.
    - **Equipment Scan Bounds Trap (`CreateFuroEquipAnime` & `G2_varia_dat`)**: Disassembled `EventOverlayClass.f_main$$CheckfuroItemEquip` and `G2_SYS$$G2_varia_dat`. In Suikoden II, variable player stats (`c_varia_dat`) only exist for combat characters (IDs 0..82). When `CreateFuroEquipAnime` scanned bath accessory equipment for NPCs (`ID >= 83`), `G2_varia_dat` threw `System.IndexOutOfRangeException`. Added bounds-guard prefixes to `G2_varia_dat` and `CheckfuroItemEquip` to return `null` / `0` for any non-combatant, completely extinguishing the log exception.
  - **Convoy Slot Inclusion**:
    - Extends bath party evaluation to include the convoy slot (`party_data.party_cha_no[6]`). Any character placed in the convoy (via story progression or save editors) is automatically included in the bathhouse session.
  - **Gender Identification Hook (`f_main.GetSeibetu` at `0x18201ab90`)**:
    - Disassembled `EventOverlayClass.f_main$$GetSeibetu` and identified that vanilla queries `ckd_info[chara_id][1] & 0xf`. This revealed two major engine data flaws:
      1. **NPC Gender Zeroing**: Non-combatant castle NPCs have no combat equipment attributes (`ckd_info` zeroed), causing `GetSeibetu` to evaluate to `0` (Male) for all NPCs (routing women like Apple, Leona, Barbara, Teresa, and Pilika to the men's tub).
      2. **Vanilla Male Data Misclassifications**: Konami's original data tables assigned female attribute bitmasks (`0x21` / `val = 1` or `4`) to several male combatants, notably **Bob** (`player_bic`, ID 4), **Chaco** (`player_zko`, ID 17), **General Kiba** (ID 86), and **Alex** (ID 103), causing Bob and Chaco to be misplaced into the women's tub behind the partition.
    - Added a comprehensive Harmony prefix to `f_main.GetSeibetu` using verified ground-truth GSD2 character IDs (`player_*.json`). Strictly maps all canonical female characters (Nanami [18], Eilie [19], Rina [20], Nina [55], Tengaar [8], Millie [24], Meg [25], Karen [14], Kasumi [41/73], Valeria [12], Anita [39], Ayda [43], Sierra [42/45], Oulan [46], Tomo [57], Viki [60], Wakaba [68], Hanna [23], Mikumiku [83], Rulodia [71], Apple [84/85], Teresa [91], Leona [94], Barbara [96], Jeane [97], Yuzu [98], Taki [99], Pilika [100/123/124], Emilia [101/102], Hilda [104], Raura [105]) to `1` (Female), while strictly classifying all other characters (including Bob [4], Chaco [17], Kiba [86], and Alex [103]) as `0` (Male).
    - Guarantees that Bob and male companions always bathe in the men's tub (positions 0..5), female bathers are placed in the women's tub (positions 6..11), and peeping interactions accurately register female bathers.
  - **Balanced Castle NPC Visitor Pool & Guaranteed Female Representation**:
    - Segregated candidates into dedicated female and male recruited star pools (`FemaleCastleNPCs` and `MaleCastleNPCs`).
    - If the player enters the bathhouse with no female party members present, the first unoccupied slot is guaranteed to select a female castle recruit (e.g. Apple, Leona, Barbara, Teresa, Jeane, Pilika, etc.), ensuring the women's tub is never empty.
    - Unoccupied slots alternate between male and female visitors so both sides of the bathhouse are populated simultaneously.
  - **Zero Save-Data Footprint**:
    - Party slots are substituted strictly in memory for the duration of the bath session and cleanly restored back to the player's exact party configuration upon bath exit (`f_main.FuroEnd`).
  - Master configuration toggle under `[05 Game : Suikoden 2]`:
    - `EnableNPCBathVisitors` (Default: `true`)
  - **Full 8-Character Bathhouse Expansion (+2 Convoy & Castle Visitor Slots)**:
    - Disassembled `EventOverlayClass.f_main$$CreateFuroChara`, `GetFuroPos`, and `furo_h.FURO_WORK$$ctor` (`0x181ff5cf0`).
    - Discovered that the entire bathhouse engine in Suikoden II was architecturally engineered for **8 actors**: all internal character tracking structures (`furo_pos_data`, `furo_chara_id`, `furo_chara_info`, `furo_chara_palette`, `chara_status`, `FuroInit` loop `0x182019956`) are sized for 8 characters across 12 tub positions (0..5 men's tub, 6..11 women's tub).
    - Vanilla was artificially capped at 6 bathers because `CreateFuroChara` and `GetFuroPos` invoked `G2_SYS.G2_pamem_num(0)`, which only counts battle slots (`0..5`), completely ignoring convoy slots (`6..7`).
    - Hooked `G2_SYS.G2_pamem_num` during bath sessions to count all active non-zero characters across all 8 slots (`party_cha_no[0..7]`), unlocking the full 8-character bathhouse capacity.
    - `PrepareBathParty` now scans and populates all 8 slots (`0..7`). Even when entering with a full 6-character combat party, slots 6 and 7 (+2 over party count) are filled with recruited castle companions or convoy members, allowing up to 8 characters to soak together.
    - If entering with fewer than 6 combat members (e.g. Riou alone), all empty slots across 1..7 are filled with castle recruits, balanced between male and female visitors so both the men's and women's tubs are populated with up to 8 companions.
  - **Permanent Castle Facility Candidates & Balanced Visitor Pool**:
    - Recruited candidates are segregated into `FemaleCastleNPCs` and `MaleCastleNPCs`.
    - Added guaranteed inclusion for permanent castle facility residents (**Apple [85]**, **Leona [94]**, **Barbara [96]**, and **Pilika [100]** for women; **Hauser [86]** and **Richmond [93]** for men) who reside at HQ without requiring standard Star of Destiny recruitment flags (`G2_cha_flag`), guaranteeing the female candidate pool never runs out.
    - Unoccupied bath slots alternate between female and male companions to evenly balance both the men's tub (right side) and women's tub (left side) up to 8 total bathers.
  - **Character ID Corrections (Tenkou, Adlai, Templeton & Apple)**:
    - Verified exact ID mappings against game character and asset schemas:
      - **Tenkou** (ID 104) & **Adlai** (ID 105): Canonical male recruits (window maker and elevator inventor) who were mistakenly placed under `FemaleCharaIds` / `FemaleCastleNPCs`, causing them to soak in the women's tub. Removed from female lists and reclassified into `MaleCastleNPCs`.
      - **Templeton** (ID 101, `player_tel_d.json`): Male cartographer, previously miscataloged under female IDs, which caused him to soak in the women's tub. Corrected to `MaleCastleNPCs`.
      - **Apple** (ID 85, `player_app_d.json`): Female convoy strategist, previously misclassified under `MaleCastleNPCs`. Corrected to `FemaleCastleNPCs`.
  - **Recruitment Flag Bounds Guard (`SafeIsRecruited`)**:
    - Preemptively validates candidate ID bounds (`npcId <= 108`) before querying `G2_SYS.G2_cha_flag(2, npcId)`, completely extinguishing the `IndexOutOfRangeException` thrown when scanning characters with IDs beyond the 108 Stars table.
  - Complete technical documentation and binary disassembly notes recorded in [suikoden_2_character_attributes_gender_and_baths.md](Documentation/suikoden_2_character_attributes_gender_and_baths.md).

- **High-Speed Decompiled Symbol Indexer & Query CLI**:
  - Implemented high-performance symbol indexing and sub-millisecond query tooling for decompiled C# sources and native IL2CPP symbol tables in `tools/symbol_indexer/`.
  - **Comprehensive Multi-Target Coverage**:
    - **Suikoden 1 (GSD1)**: 445 decompiled C# files.
    - **Suikoden 2 (GSD2)**: 1,483 decompiled C# files.
    - **Shared Engine (GSDShare)**: 354 decompiled C# files.
    - **Native IL2CPP Symbols (`symbols.txt`)**: 189,523 native function and method address mappings.
    - Total cataloged inventory: 6,147 types, 259,139 members (methods, properties, fields), and 189,523 virtual memory addresses.
  - **High-Performance Architecture (`indexer.py` & `sym.py`)**:
    - **Streamlined SQLite Backend (`symbols.db`)**: Indexed B-Trees and SQLite memory-mapping (`PRAGMA mmap_size = 256MB`) delivering query execution speeds between 0.5ms and 3ms.
    - **Full-Text Search (FTS5)**: Integrated FTS5 virtual tables for rapid prefix, substring, and wildcard matching across all games.
    - **Hex Address Resolution**: Resolves any IL2CPP memory address (e.g. `0x1818bb190`) directly to its native symbol (`MACHICON$$EventInit`) and pairs it with the decompiled C# source file and line (`MACHICON.cs#L947`).
    - **Type Inspection (`-m` / `--members`)**: Dumps all members of any class or struct with signatures, native addresses, and line numbers.
    - **Fine-Grained Filtering**: Supports game scoping (`--gsd1`, `--gsd2`, `--share`), kind scoping (`--methods`, `--fields`, `--props`, `--types`, `--native`), and JSON formatting (`--json`).
  - **Batch Convenience Wrapper**:
    - Created `tools/sym.bat` for seamless command-line queries directly from the PKCore root workspace.
  - **Hand-in-Hand Workflow with REA (Reverse Engineer Anything)**:
    - Integrated multi-phase reverse engineering protocol: use `sym.bat` to instantly anchor C# types and IL2CPP memory addresses, feed virtual addresses directly into REA for binary disassembly/pseudocode analysis, cross-correlate discovered sub-procedure calls back into `sym.bat`, and write grounded Harmony patches.
  - Complete technical documentation added in [symbol_indexer_guide.md](Documentation/symbol_indexer_guide.md).

---

## [2026.10.18]

- **Battle Enemy HP Display (Suikoden I & II)**:
  - Enhanced [BattleEnemyLevelPatch.cs](Patches/BattleEnemyLevelPatch.cs) to display both current and maximum enemy HP on a new line beneath the enemy name and level (e.g. `Bonapart Lv.25\nHP 120/120`).
  - Implemented live enemy HP retrieval across combatants:
    - **Suikoden I**: Reads live HP and Max HP from `GSD1::BattleBase.battle_work.pm_data` with fallback to `monster_data_table` base parameters.
    - **Suikoden II**: Reads live HP (`pm.hp`) and Max HP (`pm.max_hp` / `pm.monster_data.hp`) directly from `GSD2::BattleManager.Instance.battle_work.pm_data` across front and back row formation slots.
  - Configures TextMeshPro multi-line rendering with auto-sizing (`fontSizeMin = 10f`, `fontSizeMax = 18f`), hard newline separation (`enableWordWrapping = false`), and `TextOverflowModes.Overflow` to guarantee full, crisp visibility for multi-line stats.
  - Added dedicated configuration setting under `[02 User Interface]`:
    - `ShowEnemyHpInBattle` (Default: `true`)

- **Smart After-Battle Auto-Healing (Suikoden II)**:
  - Implemented in [SmartHealingPatch.cs](Patches/SmartHealingPatch.cs).
  - Automatically assesses party status and consumes restorative items after battle across a multi-phase recovery pipeline:
    - **Sacrificial Jizo Fallen Revival**: Detects knocked-out (0 HP) party members and revives them using Sacrificial Jizo (Item #30) from the shared party bag or living party members' personal inventories. Restores fallen characters to 50% max HP, clears KO/dead status flags (`dead_flg`), and clears negative battle status so they can be further healed.
    - **Antitoxin Poison Curing**: Scans all party members (including newly revived characters) and administers Antitoxin (Item #5) from the party bag or personal inventories to cure Poison (`G2_SYS.G2_poison(2, 0, slot)` and battle status flags).
    - **Smart HP Deficit Recovery**: Prioritizes living damaged members by lowest HP percentage first. Automatically selects the best-fit item: regular Medicine (+100 HP) for smaller wounds, Mega Medicine (+500 HP) for deficits $\ge 300$ HP, and Healing Wind (Wind Card 2 / scroll, +999 HP full heal) for massive wounds ($\ge 600$ HP).
    - **Overheal Waste Protection**: Guards rare Mega Medicine and Healing Wind from being wasted on minor scratches ($< 250$ HP deficit for Mega Medicine, $< 400$ HP deficit for Healing Wind). Ignores trivial chip damage below 20 HP deficit.
    - **Inventory Compaction**: Automatically compacts the shared Party Bag when items are fully consumed to avoid empty gaps in inventory slots.
    - **Battle Exit Latching**: Hooks `BattleManager.calc_exp`, `BattleManager.StorePlayerData`, `BattleManager.exit_sub00`, and `BattleManager.battle_exit99` with a one-shot latch to ensure seamless HP synchronization (`G2_SYS.G2_pamem_hp`, `C_VARIA_DAT.now_hp`, and `BattlePlayerCharacter.hp`) regardless of victory or escape.
  - Controlled via a single master toggle under `[05 Game : Suikoden 2]`:
    - `EnableSmartHealing` (Default: `true`)

- **Suikoden II Map Identifiers & Geographic Areas Architectural Reference**:
  - Migrated and integrated master map identifier documentation [suikoden_2_map_ids_and_areas_breakdown.md](Documentation/suikoden_2_map_ids_and_areas_breakdown.md) into PKCore.
  - Documents the anatomy of the 4-character venue naming system (`v` + region letter `a`-`k` + map number `01`-`37`), submap layout (`_00`, `_01`, `_obj`, `_map_00`), dialog message ID encoding formulas (`100` + region + map + offset), and provides an exhaustive cross-reference table against active PKCore patches ([GenshuRecruitmentPatch.cs](Patches/GenshuRecruitmentPatch.cs), [VincentRecruitmentPatch.cs](Patches/VincentRecruitmentPatch.cs), [GreenhillMatildaBorderPatch.cs](Patches/GreenhillMatildaBorderPatch.cs), [SajahShopUnlockPatch.cs](Patches/SajahShopUnlockPatch.cs), [TenzanPassEncounterPatch.cs](Patches/TenzanPassEncounterPatch.cs)).
- **Memory Auto-Battle (Suikoden II)**:
  - Implemented in [MemoryAutoBattlePatch.cs](Patches/MemoryAutoBattlePatch.cs).
  - Remembers the last manually chosen action per character (Attack vs Rune/Magic) and automatically replays it during Auto-Battle (Omakase / おまかせ) instead of forcing basic physical attacks.
  - Automatically verifies MP levels, status ailments (silence, sleep, death), and rune usability before casting, gracefully falling back to basic physical attacks if resources are depleted.
  - Configured under `[05 Game : Suikoden 2]`:
    - `EnableMemoryAutoBattle` (Default: `true`) — Remembers last actions and persists across battles.
- **Tenzan Pass Chimera Encounters & Cyclone Rune Drop Restoration (Suikoden II)**:
  - Implemented in [TenzanPassEncounterPatch.cs](Patches/TenzanPassEncounterPatch.cs) with technical architecture documented in [tenzan_pass_chimera_va11.md](Documentation/tenzan_pass_chimera_va11.md).
  - Restores the omitted Chimera encounters (Parties 6, 7, and 8) in Tenzan Pass (`va11`), resolving a 25-year bug dating back to the original PS1 release where the 10-slot encounter table omitted them in favor of duplicates.
  - Recreates Pyriel's community fix layout by substituting duplicate slots 1, 3, and 6 with:
    - **Slot 1 (Party 6)**: Chimera Solo (1 Chimera, centered at front row position 1).
    - **Slot 3 (Party 7)**: Chimera + Magus x 2 (Chimera centered, flanked by 2 Magus at positions 0 and 2).
    - **Slot 6 (Party 8)**: Chimera + Minotaurus (Chimera at position 1, Minotaurus at position 0).
    - Results in an authentic ~30% encounter rate in Tenzan Pass.
  - **HD Remaster Engine Crash Prevention**:
    - Overcomes an engine bug in the Remaster where `monster_data` was hardcoded to a 3-element array, which crashed the game with `IndexOutOfRangeException` whenever Chimera (MID 3) spawned.
    - Dynamically expands `monster_data` to a safe 4-element structure across `MACHICON.EventInit`, `BattleManager.BattleDataSetup`, and `BattleManager.InitNewMonster`.
    - Supplies canonical 18-element 3D battlefield grid coordinates (`monster_position`) for every formation, preventing camera and position lockups.
  - **Cyclone Rune Drop & Loot Integration**:
    - Configures guaranteed or customizable Cyclone Rune drops (`use_cnt = 0x20` [Category 2 = `embl_data`], `item_no = 6` [Cyclone Orb]) on Chimera.
    - Hooks post-battle loot calculation (`BattleManager.get_monster_okane`) and fallback item delivery (`BattleManager.b_OverlayAddItem2Init`) so that defeating a Chimera awards the Cyclone Rune directly into `battle_work.exit_work.monster_item`, seamlessly triggering the item fanfare, dialogue, and inventory addition.
  - **Runtime In-Memory Patching**:
    - Operates entirely in memory via `[HarmonyPatch(typeof(MACHICON), "EventInit")]` without modifying or repacking any `.bundle` asset files, providing complete resilience against official game updates.
  - Added configuration options under `[05 Game : Suikoden 2]`:
    - `EnableTenzanChimeraFix` (Default: `true`)
    - `ForceTenzanChimeraEncounter` (Default: `false` - debug/testing option to force 100% Chimera encounters in Tenzan Pass)
    - `TenzanChimeraCycloneDropRate` (Default: `100`, range 1-100% - configurable drop chance upon victory)
- **Sajah Village Rare Shop & Rune Sage Early Access Unlock (Suikoden II)**:
  - Implemented in [SajahShopUnlockPatch.cs](Patches/SajahShopUnlockPatch.cs) with technical architecture documented in [sajah_village_rare_shop_vj17.md](Documentation/sajah_village_rare_shop_vj17.md).
  - Unlocks the hidden late-game rare item and rune sage vendor located in the upper-right corner of the multi-shop building in Sajah Village (`vj17` / `vj17_01`), bypassing the vanilla Story Flag 143 requirement (Beast Rune defeated).
  - Follows the in-memory map patching pattern by hooking `MACHICON.EventInit` Postfix when loading Sajah Village:
    - Forces the vendor NPC sprite visible (`mapeventdat[1].eventobj[3].disp = 1`).
    - Activates the counter interaction hitbox (`mapeventdat[1].eventobj[7].disp = 1`).
    - Neutralizes the room initialization script (`mapeventdat[1].eventdat[2].eventForm = new byte[] { 0, 255, 254 }`), preventing the game engine from re-hiding the vendor if flag 143 is off.
    - Rewrites the talk interaction scripts (`eventdat[10]` and `eventdat[11]`) to bypass flag 143 (`{ 5, 11, 255, 254 }` and `{ 5, 15, 255, 254 }`), opening the rare item vendor interface and inventory immediately upon visiting Sajah Village.
  - Operates completely in memory with zero asset bundle extraction or UABEA repacking required.
  - Added configuration option under `[05 Game : Suikoden 2]`:
    - `UnlockSajahRareShopEarly` (Default: `true`)

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
