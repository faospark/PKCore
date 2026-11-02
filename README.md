# PKCore - Project Kyaro Core

**By faospark**

The **core DLL component** for **[Project Kyaro](https://www.nexusmods.com/suikoden1and2hdremaster/mods/6)** that provides a variety of features such as texture replacement framework, sprite smoothing, anti-aliasing, graphical and visual enhancement, and telemetry/gameplay tools for **Suikoden I & II HD Remaster**. As of 2026, PKExtended has been transformed to PKCore as the core backbone of Project Kyaro, with Special K completely removed as a dependency.

> **Note**: This repository contains the **source code for the PKCore.dll** file. The complete Project Kyaro mod package (including upscaled textures and companion plugins) is available on [Nexus Mods](https://www.nexusmods.com/suikoden1and2hdremaster/mods/6).

## Features

**[Can Be Toggled]**

* Re-Texture Framework (PNG, JPG, TGA, and DDS with BC1/BC3/BC7 DX10 header support)
* Upscaled Smooth Sprites (can be toggled off)
* Sprite Filtering and Anti-Aliasing (SMAA)
* NPC Portraits Framework & Comprehensive Portrait Variant Support
* Clive's Pursuit Quest Replay (S2, indefinitely replay the pursuit arc from Lakewest after the Sajah finale with in-flight self-healing flags)
* Infinite Cook-Off Battles Loop & Cooldown Reduction (S2, loop Hai Yo's cook-off battles after Jinkai with full recipe preservation, plus instant cooldown bypass)
* Expanded Town Field of View (FOV) (S1 & S2, expands town and indoor camera FOV to 110 with full depth camera synchronization)
* Repeatable Guardian Deity Statue Rewards (S2, receive blessings from Jude every time you redesign the statue at his workshop)
* Remote Castle Rune Master Access via Right Stick Down (S1, open Jeane's rune shop from anywhere on the field with field state validation)
* Boosted War Battles & Formation Menu Synchronization (S2, customize war stats/abilities with live synchronization into Apple's squad formation UI)
* Save Slot Party Member Mini Portraits (S1 & S2 with high-performance caching)
* Colored Intros and Flashbacks (S2)
* Restore Bamboo Fence on Mercenary Fortress (S2)
* Customizable Save Point Crystal Color & Glow Toggle (12 palette presets or randomizer, plus disable washed-out glow)
* Disable World Map Clouds & Sun Rays
* Scaled-Down Dialogue Box & Scaled-Down Menus
* Disable Dialogue Portrait Mask & UITips Control Overlay
* Scaled-Down World Map of Suikoden 1
* Alternative Run Animation for Tir (Project Kyaro sprites)
* Alternative Launcher (based on unused in-game assets with automatic language detection)
* Floating Borderless Window Mode (Strips Win32 title bars and borders while remaining in windowed mode, enabling custom smaller resolutions in clean borderless windows)

**[Performance Features]**

* Texture Manifest Cache
* Texture Memory Caching
* Resolution Scaling

**[Baked In]**

* Automatic Text Placeholder Replacement (protagonist/HQ names from save data)
* Active Launcher Language Detection (detects game/launcher language on startup and manual selection)
* Added Headquarters Signage (S1)
* Fixed Backgrounds with Bad Baked DOF (S2)
* Fixed Inconsistent Telescope on HQ (S2)
* Replaced Low-Quality Upscaled Doors in the Inn Area (S2)

**[Utility & In-Game Tools]**

* Dear ImGui Feature Dashboard & In-Game Control Suite [F10] (Multi-tabbed real-time configuration overlay for gameplay toggles, shader/crystal colors, UI adjustments, Castle HQ state modifiers, live scene object inspector, and system themes)
* Dear ImGui Location & Notes HUD (Streamlined bottom-left telemetry HUD displaying current map and location name, live camera zoom / FOV controls with [PageDown]/[PageUp]/[Home] hotkeys, interactive notes entry, [NumPad 5] log dump to `\PKCore\Logs\locationdump.log`, and zero gamepad or movement input interference)
* Location Dump [NumPad 5] (Press [NumPad 5] anytime in gameplay or click the HUD button to instantly dump current map and location notes to `\Suikoden I and II HD Remaster\PKCore\Logs\locationdump.log`)
* Encounter None [F4] (Toggle random battle encounters on/off with [F4] or via Dear ImGui overlay; automatically delegates to Suikoden_Fix multiplier when present, with native fallback hooks for S1 & S2)
* Show Mouse Cursor (Live runtime toggle via Dear ImGui overlay and configuration to unlock and force OS cursor visibility)
* Clean Exit on ALT+F4 (Force immediate shutdown instead of hanging)
* High-Speed Decompiled Symbol Indexer & CLI Query Tool (Sub-millisecond lookups for C# types, members, native IL2CPP addresses, and all 360 game maps)

**[Modularized Standalone Plugins (Migrated from PKCore)]**

To keep PKCore focused as the core texture engine, telemetry HUD, and foundational framework, several major gameplay systems previously part of PKextended/early PKCore have been decoupled into dedicated, standalone companion plugins within the Project Kyaro mod suite:

* **[PKBattlePatch](https://www.nexusmods.com/suikoden1and2hdremaster/mods/6)**: Dedicated combat enhancements including live Enemy Level/HP HUD bars, Party Max HP gauge, Memory Auto-Battle with persistent battle commands, Smart After-Battle Auto-Healing, customizable battle formation spacing, unlimited command runes, rune unbalance removal, and attack range overrides.
* **[PKRuneSagePlus](https://www.nexusmods.com/suikoden1and2hdremaster/mods/6)**: Full rune vendor enhancements including the early Sajah Village rare shop & rune sage unlock (bypassing story flag 143, S2) and S1 Castle Rune Master (Jeane) shop inventory expansion with a progressive crystal vendor.
* **[PKS2BathNPCPatch](https://www.nexusmods.com/suikoden1and2hdremaster/mods/6)**: Complete bathhouse overhaul restoring cut bath sprites for non-combatant recruits and convoy members, unlocking 8-character bathhouse capacity, and enforcing canonical gender-based tub separation.
* **[PKTenzanPassPatch](https://www.nexusmods.com/suikoden1and2hdremaster/mods/6)**: Dedicated restoration of omitted Chimera monster encounters (Parties 6, 7, and 8) in Tenzan Pass (`va11`) with Pyriel's community fix layout, configurable Cyclone Rune drops, and crash prevention bounds checks.
* **[PKButtonPrompts](https://www.nexusmods.com/suikoden1and2hdremaster/mods/6)**: Universal controller button prompt override framework supporting Xbox, PS4, PS5, and Nintendo Switch layouts.

> **Borderless Modes**:
> - **Floating Windowed Borderless (Custom Resolutions / Smaller Windows)**: Enable `EnableBorderlessWindow = true` under `[Utilty]` in `faospark.pkcore.cfg`. Strips the OS window caption and resizing frame while retaining windowed mode.
> - **Fullscreen Borderless (Full Desktop)**: Use Unity's native `-popupwindow` launch argument:
>   - **Steam**: Right-click game → Properties → Launch Options → Add `-popupwindow`
>   - **Epic Games**: Create a shortcut to the game executable and add `-popupwindow` to the Target field

**[Additionals from Nexus Bundle]**

* Restore the Dash in the Letter “Z” via Custom Font
* Alternate CRC Bypass for Version 1.0.4

Replace game textures with custom PNG or DDS files in `BepInEx/plugins/PKCore/Textures/`. Use `00-Mods/` subfolder for highest priority custom mods.

**Performance Optimization**: Built-in manifest caching dramatically improves boot times. DDS format support allows pre-compressed textures (**BC1**, **BC3**, and high-quality **BC7** with DX10 header support) for reduced VRAM usage and faster loading.

### Advanced Customization & Systems Documentation

#### Standalone Companion Plugins (Migrated Features)
The following features are now managed in their own dedicated plugins, but their deep-dive documentation remains preserved here for reference:
- **Tenzan Pass Chimera Encounters Restoration**: Migrated to dedicated standalone plugin `PKTenzanPassPatch` (`faospark.pktenzanpasspatch`). Restores omitted Chimera monster encounters (Parties 6, 7, and 8) in Tenzan Pass (`va11`) with Pyriel's community fix layout (~30% encounter rate), guaranteed or configurable Cyclone Rune drops, and multi-tier engine bounds protection against Remaster crash bugs. See [Tenzan Pass Guide](Documentation/tenzan_pass_chimera_va11.md).
- **Sajah Village Rare Shop & Rune Sage Unlock**: Migrated to dedicated standalone plugin `PKRuneSagePlus` (`faospark.pkrunesageplus`). Early access unlock for the hidden late-game rare item/rune vendor and counter trigger in Sajah Village (`vj17`) bypassing story flag 143 via in-memory map patching. See [Sajah Shop Guide](Documentation/sajah_village_rare_shop_vj17.md).
- **NPC Bathhouse Sprites & Castle Visitors Restoration**: Migrated to dedicated standalone plugin `PKS2BathNPCPatch` (`faospark.pks2bathnpcpatch`). Restores unused bathhouse sprites for non-combatant recruits and convoy members in Suikoden 2, unlocks full 8-character bathhouse capacity (+2 convoy/visitor slots over a 6-man party), eliminates engine null-dereference crashes, guarantees accurate gender-based tub separation via verified canonical character IDs (routes Tenkou [97], Richmond [99], Boris [122] to men's tub; routes Teresa [101], Emilia [96], Barbara [98], Leona [91], Pilika [123] to women's tub), gates Pilika's presence to before the Muse Peace Conference, preserves vanilla Case 2 unisex routing for Simone and Vincent, preserves native implementations for Gadget and beasts (Abizboah, Rulodia, Feather, Siegfried, Shiro, Mukumuku), and populates vacant bath positions with recruited castle companions. See [Bath Attributes Guide](Documentation/suikoden_2_character_attributes_gender_and_baths.md).
- **Controller Prompt Override**: Migrated to dedicated standalone plugin `PKButtonPrompts` (`faospark.pkbuttonprompts`). Force specific button icons (Xbox/PS4/PS5/Switch) regardless of detected controller.
- **Combat Systems & Battle Enhancements**: Migrated to dedicated standalone plugin `PKBattlePatch` (`faospark.pkbattlepatch`). Enemy HP/Level bars, Party Max HP, Memory Auto-Battle, Smart After-Battle Healing, battle formation spacing, unlimited command runes, rune unbalance removal, and range overrides.

#### PKCore Built-In Systems
- **Clive's Pursuit Quest Replay (S2)**: Automatically resets Clive's questline back to Lakewest upon entering Lakewest after finishing the Sajah Village finale, allowing indefinite replay of the pursuit arc in late game with in-flight self-healing flags for Rockaxe and Radat.
- **Infinite Cook-Off Minigame Loop & Cooldown Reduction (S2)**: Automatically restarts Hai Yo's cook-off battles from Chef Antonio (Match 1) after defeating final chef Jinkai and viewing the garden cutscene, while preserving all recipes, seasonings, and bonuses. Also provides a configurable toggle (`ReduceCookOffCooldown`) to bypass the vanilla 30-60 minute active movement cooldown between matches.
- **Town & Indoor Field of View Expansion (FOV 110)**: Expands the camera FOV to 110 in towns and indoor maps for both Suikoden I and Suikoden II with full secondary depth camera (`BindCamera.Sync`) synchronization and interior scene persistence.
- **Remote Castle Rune Master Access via Right Stick Down (S1)**: Open Jeane's rune shop from anywhere on the field with area background load verification, loading screen immunity, and complete background player movement silencing.
- **Repeatable Guardian Deity Statue Rewards (S2)**: In retail Suikoden II, Guardian Deity blessings are locked permanently after your first statue evaluation (setting Story Flag 148 bit 32), leaving subsequent statue redesigns at Jude's workshop (`vk20`) without rewards. PKCore monitors workshop exits, reliably re-arms reward triggers, preserves the custom 3D statue model across transitions, and refreshes party reactions (Story Flag 123) for every newly sculpted combination. Configurable via `EnableRepeatStatueRewards` under `[05 Game : Suikoden 2]` in `faospark.pkcore.cfg`.
- **War Battle Modding & Formation Menu Synchronization (S2)**: Customize character stats, tactical abilities, and subunit bonuses in Suikoden 2 war battles via `S2WarAbilities.json`. Synchronizes custom war stats not only into active combat, but also live into Apple's squad formation roster and team change menu at Castle HQ (`w_dat_butai.chara_butai`), including proper indexing for subunit specialists (Apple, Klaus, Huan).
- **Dear ImGui Feature Dashboard & In-Game Control Suite (`[F10]`)**: Comprehensive, real-time in-game control suite powered natively by **Dear ImGui** (via `DearImGuiInjection` / `ImGui.NET` over DirectX 11 Present injection), allowing players to tweak and test features live without restarting the game:
  - **Gameplay & Exploration**: Live toggle for Encounter None (`[F4]`) with active backend provider indicator, world map cloud and sunray toggles, and remote trigger for Castle Rune Master (Jeane, S1) with safe field state validation.
  - **Visuals & Shaders**: Interactive save crystal color picker (12 preset palette hues + randomizer) with instant shader refresh, crystal glow toggle, sprite bilinear & 2x anisotropic texture filtering, sprite post-processing toggle (fixes bloom/outline tile seam bleeding), and SMAA anti-aliasing selector.
  - **Interface & Window**: Floating borderless window mode toggle, dialog box 80% scaling, minimal UI textures, portrait dialog mask disable, UITips control overlay disable, classic PSX save window, and save slot party mini-portraits.
  - **Castle & World State (S2)**: Castle stage visualizer and level modifier (Stages 0-4), Live Submap Object & NPC Inspector tracking active Unity scene instances against map bytecode (`[Shown]` green, `[Off/Trig]` yellow, `[Hidden]` red) with per-object visibility toggles and hot scene synchronization, hot room reload, and cut ballroom choreography trigger.
  - **System & Themes**: 4 ImGui color themes (**Classic Blue**, **Matrix**, **Obsidian Black**, and **Dark Magenta**), OS mouse cursor visibility toggle, FOV camera zoom reset, and integrated Location Dump log viewer.
- **Dear ImGui Location & Notes HUD**: Lightweight, non-intrusive on-screen telemetry and notes tool:
  - **Live Location Telemetry & Notes Input**: Displays a compact, semi-transparent location box at the bottom-left of the screen during gameplay (`Location: <MapId>`). Click the HUD or press **`[NumPad 6]`** / **`[F9]`** to expand the note field, type area descriptions, and hit Enter to save.
  - **Hotkey Location Dump (`[NumPad 5]`)**: Pressing **`[NumPad 5]`** (or clicking `Dump`) immediately appends a formatted location snapshot with current notes to `\PKCore\Logs\locationdump.log`. Click `Open Log` to open the file directly.
  - **Zero Input Interference**: Operates cleanly without invasive input blockers on gamepads, analog sticks, or movement systems, ensuring seamless compatibility with player controls and third-party movement mods.
  - **Visual Themes & Configuration**: Configurable in `faospark.pkcore.cfg` (`ShowLocationHUD`, `ImGuiTheme`).
- **Floating Borderless Window Mode**: Strips Win32 window chrome (`WS_CAPTION`, `WS_THICKFRAME`, `WS_SYSMENU`, `WS_MINIMIZEBOX`, `WS_MAXIMIZEBOX`) via native `SetWindowLong` and `SetWindowPos` while keeping the engine in `FullScreenMode.Windowed`. Allows players to run arbitrary custom or lower window resolutions in clean borderless windows without desktop stretching. Configurable via `EnableBorderlessWindow` under `[Utilty]` in `faospark.pkcore.cfg`.
- **Encounter None Hotkey & Toggle (`[F4]`)**: Quickly suppress random wandering and field encounters for testing and exploration. Automatically integrates with `Suikoden_Fix` if installed (setting its `EncounterRateMultiplier` to 0.0), or activates native Harmony hooks across both Suikoden I and Suikoden II.
- **NPC Portraits**: Inject custom high-resolution portraits for any NPC with variant support.
- **Placeholder Text Replacement**: Automatic replacement of protagonist and HQ name placeholders in dialogs. See [Placeholder Text Guide](Documentation/PlaceholderText.md).
- **Active Launcher Language Detection**: Automatically detects the active launcher language on startup (English, Traditional Chinese, Simplified Chinese, Japanese, French, German, Spanish, Italian, Korean) and tracks manual language changes via `LanguageSelectionPatch`.
- **High-Speed Decompiled Symbol & Map Indexer**: Instant lookup tool for C# classes, methods, fields, native IL2CPP memory addresses, and all 360 Maps & World Environments across both Suikoden I and Suikoden II (`tools\sym.bat <Query>`, `tools\sym.bat --maps <MapID>`). See [Symbol Indexer Guide](Documentation/symbol_indexer_guide.md).

#### Reference Guides & Catalogs
- **Suikoden I Map Identifiers & Regional Breakdown Reference Guide**: Complete architectural reference and regional sector catalog for Suikoden 1, documenting all 12 regional sectors (`area_a` through `area_k`, `area_z`), 85 background map assets (`bg_va1`–`bg_vz5`), C# decompiled handlers (`G1_fdata_c.cs`, `VillageManager.cs`, `Village_c.cs`, `Event_c.cs`), and the 70+ `EVENT_COMMAND` bytecode opcodes. See [Suikoden 1 Map Guide](Documentation/suikoden_1_map_ids_and_areas_breakdown.md).
- **Suikoden II Map Identifiers & Geographic Areas Reference**: Master architectural reference and exhaustive breakdown of all 4-character map and venue identifiers (`va01` through `vk37`), chronological story chapters, extracted asset conventions, text message encoding keys, and associated PKCore patches. See [Map Identifiers Guide](Documentation/suikoden_2_map_ids_and_areas_breakdown.md).
- **Suikoden II Master Map Entities, Triggers & World Objects Catalog**: Exhaustive technical census and bytecode reference across all 226 master map assets in Suikoden 2, documenting all 4,901 NPCs, 1,552 dynamic props (bonsai trees, flower pots, furniture), 3,207 collision triggers and single-tile dots, 90 save points, 27 chest clusters, hidden/unfinished entities, trigger types (`etyp`), and all 147 event command opcodes (`EC*`) with in-memory injection blueprints. See [Master Map Entities Guide](Documentation/suikoden_2_master_map_entities_and_triggers_catalog.md).
- **Individual Geographic Area Volumes (62 Areas)**: Complete standalone documentation files for every village, dungeon, city, pass, and castle area in `Documentation/areas/`, complete with embedded **Human-Readable Field & Engine Legends** and decoded plain-English event actions (no raw opcode numbers).

## Requirements

- **BepInEx 6.0.0-pre.2 IL2CPP**
- **Suikoden I & II HD Remaster** (Unity 2022.3.28f1)
- **Highly Recommended**: [Suikoden Fix](https://github.com/d3xMachina/BepInEx.Suikoden) for best experience

## Installation

1. Install **BepInEx 6.0.0-pre.2 IL2CPP**
2. Install **[Project Kyaro](https://www.nexusmods.com/suikoden1and2hdremaster/mods/6)**
3. Launch game (config auto-generates in `BepInEx\config\faospark.pkcore.cfg`)

## Configuration

Config file auto-generates at `BepInEx\config\faospark.pkcore.cfg` on first launch.

## Migration Guide (PKextended → PKCore)

If you have **PKextended.dll** or older versions of Project Kyaro installed:

1. **Remove Old files**:
   - Delete `PKextended.dll` from `BepInEx/plugins/`
   - Old config: `BepInEx/config/faospark.pkextended.cfg`
   - Delete or back up `dxgi.dll` or `d3d11.dll` from any earlier Special K installations
   - Delete `SK_Res\inject\textures` as Special K is no longer used or supported
2. **Config File** (auto-generates on boot):
   - New config: `BepInEx/config/faospark.pkcore.cfg`

### Features Migrated to Standalone Companion Plugins
If you were using gameplay features from older versions of PKextended / PKCore, they are now packaged as dedicated standalone companion plugins within the Project Kyaro suite:
- **Combat Features & Auto-Battle**: Install `PKBattlePatch.dll` (`faospark.pkbattlepatch`).
- **Rune Sage & Shop Expansions**: Install `PKRuneSagePlus.dll` (`faospark.pkrunesageplus`).
- **Bathhouse Sprites & Expanded Capacity**: Install `PKS2BathNPCPatch.dll` (`faospark.pks2bathnpcpatch`).
- **Tenzan Pass Chimera Encounters**: Install `PKTenzanPassPatch.dll` (`faospark.pktenzanpasspatch`).
- **Controller Button Prompt Overrides**: Install `PKButtonPrompts.dll` (`faospark.pkbuttonprompts`).

## Development

This mod uses BepInEx 6 IL2CPP and Harmony for runtime patching.

## License

MIT License - See LICENSE.txt

## Credits

**Author**: faospark
**For**: [Project Kyaro](https://www.nexusmods.com/suikoden1and2hdremaster/mods/6) HD sprite pack
**Compatible with**: [Suikoden Fix](https://github.com/d3xMachina/SuikodenFix) by d3xMachina

**Special Thanks & Credits**:
- **[d3xMachina](https://github.com/d3xMachina)**: For the excellent [Suikoden Fix](https://github.com/d3xMachina/SuikodenFix) mod. PKCore is built to work alongside it.
  - The **NPC Portrait** feature leverages his `TextDatabase` research and speaker identification logic.
