# P.K. - Core

**By [faospark](https://github.com/faospark)**

The **core DLL component** for **[Project Kyaro](https://www.nexusmods.com/suikoden1and2hdremaster/mods/6)** that provides a variety of features such as texture replacement framework, sprite smoothing, anti-aliasing, graphical and visual enhancements, and telemetry/gameplay tools for **Suikoden I & II HD Remaster**. As of 2026, PKExtended has been transformed to PKCore as the core backbone of Project Kyaro, with Special K completely removed as a dependency.

> **Note**: This repository contains the **source code for the PKCore.dll** file. The complete Project Kyaro mod package (including upscaled textures and companion plugins) is available on [Nexus Mods](https://www.nexusmods.com/suikoden1and2hdremaster/mods/6).

## Features

**[Can Be Toggled]**

* **Re-Texture Framework**: Custom texture injection supporting PNG, JPG, TGA, and DDS with BC1/BC3/BC7 DX10 header support.
* **Upscaled Smooth Sprites**: Toggle between Project Kyaro HD sprites and original pixel sprites.
* **Sprite Filtering & Anti-Aliasing (SMAA)**: Bilinear + 2x anisotropic texture filtering and selectable SMAA quality presets (Off, Low, Medium, High).
* **NPC Portraits Framework**: High-resolution NPC portrait injection with comprehensive variant support (S1 & S2).
* **Clive's Pursuit Quest Replay (S2)**: Indefinitely replay the pursuit arc from Lakewest after the Sajah finale with in-flight self-healing flags.
* **Infinite Cook-Off Battles Loop & Cooldown Reduction (S2)**: Loop Hai Yo's cook-off battles after Jinkai with full recipe preservation, plus instant cooldown bypass.
* **Cook-Off Live Scoring Assistant & Optimal Menu Recommendations (S2)**: Real-time scoring predictions and optimal recipe + spice recommendations on screen as you select dishes during Chef Hai Yo's cook-off battles, with full judge taste profile breakdown.
* **Remote Castle Rune Master Access (S1)**: Press Right Stick Down or `[F7]` to open Jeane's Toran Castle rune shop from anywhere on the field with field state validation.
* **Boosted War Battles & Formation Menu Synchronization (S2)**: Customize war stats/abilities via `S2WarAbilities.json` with live synchronization into Apple's squad formation UI.
* **Save Slot Party Member Mini Portraits (S1 & S2)**: Display party member portraits next to save slots in the Save/Load window with high-performance caching.
* **Colored Intros and Flashbacks (S2)**: Restore full color to intro and flashback sequences by disabling the monochrome custom post-effect.
* **Restore Bamboo Fence on Mercenary Fortress (S2)**: Restores the Mercenary Fortress perimeter fence texture variant.
* **Customizable Save Point Crystal Color & Glow Toggle**: 12 palette presets or randomizer, plus an option to disable the washed-out glow effect.
* **Disable World Map Clouds & Sun Rays**: Clean up world map visuals by toggling cloud and sunray glow effects independently.
* **Scaled-Down Dialogue Box & Menus**: Compact 80% size layout presets for dialogue boxes and main menus with adjusted screen positioning.
* **Disable Dialogue Portrait Mask & UITips**: Remove the portrait face mask overlay and suppress control/button prompt overlays (`UITips`).
* **Scaled-Down World Map of Suikoden 1**: Scales down the S1 world map UI element to 80% with adjusted positioning for improved field visibility.
* **Alternative Run Animation for Tir**: Selectable running animation variants for Tir (Default, Alt, Pixel).
* **Alternative Launcher**: PSP-inspired launcher UI based on unused in-game assets, featuring automatic language detection and custom BGM support.
* **Floating Borderless Window Mode**: Strips Win32 window chrome while remaining in windowed mode, enabling custom smaller resolutions in clean borderless windows.
* **Mouse Cursor Visibility Toggle**: Unlock and force OS mouse cursor visibility via config (`ShowMouseCursor`) for debugging.

**[Performance Features]**

* **Texture Manifest Cache**: Caches texture indexes to skip re-scanning the disk on every boot.
* **Texture Memory Caching**: Intelligent area-transition cleanup to free RAM while keeping persistent UI textures loaded.
* **Resolution Scaling**: Render scaling multiplier (0.5x to 2.0x) for performance boost or supersampling.

**[Baked In]**

* **Automatic Text Placeholder Replacement**: Resolves protagonist and HQ name placeholders from active save data.
* **Active Launcher Language Detection**: Automatically detects and synchronizes launcher language across English, Traditional/Simplified Chinese, Japanese, French, German, Spanish, Italian, and Korean.
* **Added Headquarters Signage (S1)**: Visual fixes for Toran Castle exterior signage.
* **Fixed Backgrounds with Bad Baked DOF (S2)**: Cleans up background assets affected by inaccurate depth-of-field artifacts.
* **Fixed Inconsistent Telescope on HQ (S2)**: Corrects mismatched telescope assets at Dunan Castle.
* **Replaced Low-Quality Upscaled Doors (S2)**: Upgrades low-resolution door textures in castle inn areas.
* **Clean Exit on Alt+F4**: Prevents process shutdown hanging on quit (Unity 2022 / BepInEx 6 issue).

**[Diagnostics & Developer Tools]**

* **Real-Time Event Flag Logger (S1 & S2)**: Intercepts flag operations live in Suikoden 1 and Suikoden 2, logging byte offsets, bitmasks, and binary values to the BepInEx console/log (`LogEventFlagsS1`, `LogEventFlagsS2`).
* **Text Database & JSON Asset Dumper**: Dumps runtime dialogue IDs and AssetBundle TextAssets/JSON to `PKCore/Debug/` for reverse-engineering.
* **High-Speed Decompiled Symbol Indexer & CLI Query Tool**: Instant sub-millisecond lookup tool for C# classes, members, native IL2CPP memory addresses, and all 360 game maps (`tools/sym.bat`).

---

## Modularized Standalone Plugins (Migrated from PKCore)

To keep PKCore focused as the core texture engine, asset framework, and foundation layer, several gameplay systems previously part of PKextended/early PKCore have been decoupled into dedicated, standalone companion plugins within the Project Kyaro mod suite:

* **[PKBattlePatch](https://www.nexusmods.com/suikoden1and2hdremaster/mods/6)**: Combat enhancements including live Enemy Level/HP HUD bars, Party Max HP gauge, Memory Auto-Battle with persistent battle commands, Smart After-Battle Auto-Healing, customizable battle formation spacing, unlimited command runes, rune unbalance removal, and attack range overrides.
* **[PKRuneSagePlus](https://www.nexusmods.com/suikoden1and2hdremaster/mods/6)**: Rune vendor expansions including early Sajah Village rare shop & rune sage unlock (bypassing story flag 143, S2) and S1 Castle Rune Master (Jeane) inventory expansion with a progressive crystal vendor.
* **[PKS2BathNPCPatch](https://www.nexusmods.com/suikoden1and2hdremaster/mods/6)**: Complete bathhouse overhaul restoring cut bath sprites for non-combatant recruits and convoy members, unlocking 8-character bathhouse capacity, and enforcing canonical gender-based tub separation.
* **[PKTenzanPassPatch](https://www.nexusmods.com/suikoden1and2hdremaster/mods/6)**: Restoration of omitted Chimera monster encounters (Parties 6, 7, and 8) in Tenzan Pass (`va11`) with Pyriel's community fix layout and crash prevention bounds checks.
* **[PKButtonPrompts](https://www.nexusmods.com/suikoden1and2hdremaster/mods/6)**: Universal controller button prompt override framework supporting Xbox, PS4, PS5, and Nintendo Switch layouts.

---

## Texture Replacement Guide

Replace game textures by placing custom PNG, JPG, TGA, or DDS files in `BepInEx/plugins/PKCore/Textures/`.
* **Mod Priority**: Use the `00-Mods/` subfolder for highest priority custom mods.
* **Performance Optimization**: DDS format support allows pre-compressed textures (**BC1**, **BC3**, and high-quality **BC7** with DX10 header support) for reduced VRAM usage and faster loading times.

---

## Systems Documentation & Reference Guides

### Built-In Systems

- **Clive's Pursuit Quest Replay (S2)**: Automatically resets Clive's questline back to Lakewest upon entering Lakewest after finishing the Sajah Village finale, allowing indefinite replay of the pursuit arc in late game with in-flight self-healing flags for Rockaxe and Radat.
- **Infinite Cook-Off Minigame Loop & Cooldown Reduction (S2)**: Automatically restarts Hai Yo's cook-off battles from Chef Antonio (Match 1) after defeating final chef Jinkai and viewing the garden cutscene, while preserving all recipes, seasonings, and bonuses. Also provides a configurable toggle (`ReduceCookOffCooldown`) to bypass the vanilla 30–60 minute active movement cooldown between matches.
- **Remote Castle Rune Master Access (S1)**: Open Jeane's rune shop from anywhere on the field via Right Stick Down (or keyboard `[F7]`), complete with area background load verification, loading screen immunity, and background player movement silencing.
- **War Battle Modding & Formation Menu Synchronization (S2)**: Customize character stats, tactical abilities, and subunit bonuses in Suikoden 2 war battles via `PKCore/Config/S2WarAbilities.json`. Synchronizes custom war stats not only into active combat, but also live into Apple's squad formation roster and team change menu at Castle HQ (`w_dat_butai.chara_butai`), including proper indexing for subunit specialists (Apple, Klaus, Huan). See [War Battle Modding Guide](Documentation/war_battle_modding.md).
- **Floating Borderless Window Mode**: Strips Win32 window chrome (`WS_CAPTION`, `WS_THICKFRAME`, `WS_SYSMENU`, `WS_MINIMIZEBOX`, `WS_MAXIMIZEBOX`) via native `SetWindowLong` and `SetWindowPos` while keeping the engine in `FullScreenMode.Windowed`. Allows players to run arbitrary custom or lower window resolutions in clean borderless windows without desktop stretching. Configurable via `EnableBorderlessWindow` under `[Utilty]` in `faospark.pkcore.cfg`.
  > **Note on Fullscreen Borderless (Desktop Resolution)**: To run fullscreen borderless at your desktop's native resolution, use Unity's native `-popupwindow` launch option in Steam (Properties → General → Launch Options) or Epic Games shortcut target.
- **NPC Portraits & Placeholder Text Replacement**: Inject custom high-resolution portraits for any NPC with variant support and automatic replacement of protagonist and HQ name placeholders in dialogs. See [Dialog Text Placeholders Guide](Documentation/dialog_text_placeholders.md).
- **High-Speed Decompiled Symbol & Map Indexer**: Instant lookup tool for C# classes, methods, fields, native IL2CPP memory addresses, and all 360 Maps & World Environments across both Suikoden I and Suikoden II (`tools\sym.bat <Query>`, `tools\sym.bat --maps <MapID>`). See [Symbol Indexer Guide](Documentation/symbol_indexer_guide.md).

### Reference Guides & Catalogs

- **Suikoden I Map Identifiers & Regional Breakdown Reference Guide**: Complete architectural reference and regional sector catalog for Suikoden 1, documenting all 12 regional sectors (`area_a` through `area_k`, `area_z`), 85 background map assets (`bg_va1`–`bg_vz5`), C# decompiled handlers (`G1_fdata_c.cs`, `VillageManager.cs`, `Village_c.cs`, `Event_c.cs`), and the 70+ `EVENT_COMMAND` bytecode opcodes. See [Suikoden 1 Map Guide](Documentation/suikoden_1_map_ids_and_areas_breakdown.md).
- **Suikoden II Map Identifiers & Geographic Areas Reference**: Master architectural reference and exhaustive breakdown of all 4-character map and venue identifiers (`va01` through `vk37`), chronological story chapters, extracted asset conventions, text message encoding keys, and associated PKCore patches. See [Map Identifiers Guide](Documentation/suikoden_2_map_ids_and_areas_breakdown.md).
- **Suikoden II Master Map Entities, Triggers & World Objects Catalog**: Exhaustive technical census and bytecode reference across all 226 master map assets in Suikoden 2, documenting all 4,901 NPCs, 1,552 dynamic props (bonsai trees, flower pots, furniture), 3,207 collision triggers and single-tile dots, 90 save points, 27 chest clusters, hidden/unfinished entities, trigger types (`etyp`), and all 147 event command opcodes (`EC*`) with in-memory injection blueprints. See [Master Map Entities Guide](Documentation/suikoden_2_master_map_entities_and_triggers_catalog.md).
- **Individual Geographic Area Volumes (62 Areas)**: Complete standalone documentation files for every village, dungeon, city, pass, and castle area in `Documentation/areas/`, complete with embedded **Human-Readable Field & Engine Legends** and decoded plain-English event actions.
- **Standalone Companion Plugin Deep Dives**: Historical research documentation for features migrated to companion plugins remains preserved for reference:
  - [Sajah Village Rare Shop & Rune Sage Unlock](Documentation/sajah_village_rare_shop_vj17.md) (`PKRuneSagePlus`)
  - [Character Attributes, Gender, and Bathhouse Mechanics](Documentation/suikoden_2_character_attributes_gender_and_baths.md) (`PKS2BathNPCPatch`)

---

## Requirements

- **BepInEx 6.0.0-pre.2 IL2CPP**
- **Suikoden I & II HD Remaster** (Unity 2022.3.28f1)
- **Highly Recommended**: [Suikoden Fix](https://github.com/d3xMachina/SuikodenFix) by d3xMachina for the optimal remaster experience.

## Installation

- **Prerequisite**: [BepInEx 6.0 (Unity IL2CPP x64)](https://github.com/BepInEx/BepInEx/releases/download/v6.0.0-pre.2/BepInEx-Unity.IL2CPP-win-x64-6.0.0-pre.2.zip) installed in your game root directory.
- **Install**: Extract the release ZIP directly into your game's root directory (or place `PKCore.dll` and its assets into `BepInEx/plugins/PKCore/`).
- **Verify**: Launch the game; `BepInEx/LogOutput.log` will confirm `[PKCore] loaded successfully!`.

---

## Migration Guide (PKextended → PKCore)

If upgrading from **PKextended.dll** or older versions of Project Kyaro:

1. **Remove Old Files**:
   - Delete `PKextended.dll` from `BepInEx/plugins/`
   - Delete legacy config: `BepInEx/config/faospark.pkextended.cfg`
   - Delete any older Special K files (`dxgi.dll`, `d3d11.dll`, or `SK_Res/` folder) as Special K is no longer used or supported.
2. **Configuration File**:
   - New settings auto-generate in `BepInEx/config/faospark.pkcore.cfg` on initial launch.
3. **Install Companion Plugins as Needed**:
   - Gameplay features that were decoupled into standalone plugins can be installed alongside PKCore:
     - Combat enhancements & auto-battle: `PKBattlePatch.dll`
     - Rune sage & vendor expansions: `PKRuneSagePlus.dll`
     - Bathhouse sprites & capacity expansion: `PKS2BathNPCPatch.dll`
     - Tenzan Pass Chimera encounters: `PKTenzanPassPatch.dll`
     - Controller button prompt overrides: `PKButtonPrompts.dll`

---

## Credits & License

- **[d3xMachina](https://github.com/d3xMachina/Suikoden-Fix)**: Creator of [Suikoden-Fix](https://github.com/d3xMachina/Suikoden-Fix). Bootstrapped the foundational BepInEx IL2CPP implementation and provided early inspiration for Remaster modding.
- **[asilverthorn](https://github.com/asilverthorn/suikoden_ref)**: Creator of [suikoden_ref](https://github.com/asilverthorn/suikoden_ref). Invaluable early reference tables, internal IDs, and save structure research.
- **[faospark](https://github.com/faospark)**: Primary Author & Lead Researcher.
- **Mod Suite**: [Project Kyaro](https://www.nexusmods.com/suikoden1and2hdremaster/mods/6)
- **Moogles & Mods Discord Community**: For ongoing support, research, collaboration, and keeping the Suikoden modding scene thriving. Join us on the [Moogles & Mods Discord](https://discord.com/invite/bSnpVBV).
- **Special Thanks**:
  - **Pyriel**: For the original community Tenzan Pass encounter layout research.
- **Framework**: [BepInEx](https://github.com/BepInEx/BepInEx) & [HarmonyX](https://github.com/BepInEx/HarmonyX).

Distributed under the MIT License. See `LICENSE.txt` for details.
