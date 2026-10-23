# PKCore - Project Kyaro Core

**By faospark**

The **core DLL component** for **[Project Kyaro](https://www.nexusmods.com/suikoden1and2hdremaster/mods/6)** that provides a variety of features such as texture replacement framework, sprite smoothing, anti-aliasing, graphical and visual enhancement, and some gameplay enhancement for **Suikoden I & II HD Remaster**. As of 2026, PKExtended has been Transformed to PKCore as this is now the backbone of Project Kyaro . Special K has now been removed as a Dependecy .

> **Note**: This repository contains the **source code for the PKCore.dll** file. The complete Project Kyaro mod package (including upscaled textures) is available on [Nexus Mods](https://www.nexusmods.com/suikoden1and2hdremaster/mods/6).

## Features


**[Can Be Toggled]**

* Re-Texture Framework (PNG, JPG, TGA, and DDS with BC1/BC3/BC7 DX10 header support)
* Upscaled Smooth Sprites (can be toggled off)
* Sprite Filtering and Anti-Aliasing (SMAA)
* NPC Portraits Framework
* Comprehensive Portrait Variant Support
* Colored Intros and Flashbacks
* Boosted War Battles (S2)
* Restore Chimera Encounters in Tenzan Pass (30% encounter rate with Cyclone Rune drop restoration, S2)
* Early Sajah Village Rare Shop & Rune Sage Vendor Unlock (S2)
* Memory Auto-Battle (Replays last manually chosen action, S2)
* Smart After-Battle Auto-Healing (Automatic Medicine & Healing Wind HP recovery, Sacrificial Jizo revival, and Antitoxin poison curing, S2)
* Battle Enemy Level & HP Display (S1 & S2)
* Battle Party Current / Max HP Display (S1 & S2)
* Unlimited & Reusable Command Runes in Battle (Trick, Groundhog, Spider Slay, Angry Dragon, S2)
* Rune Unbalance Removal (S2)
* Character Battle Range Overrides (e.g. Medium range Kasumi, Luc, Mazus, Viki, Gantetsu, Badeaux, Sierra, S2)
* Battle Formation Position Adjustments (S2)
* Save Slot Party Member Mini Portraits (S1 & S2)
* Button Controller Prompt Support (expanded to include more options)
* Alternative Launcher (based on unused in‑game assets)
* Minimal UI
* Classic‑ish Save Menu UI
* Disable Dialogue Portrait Mask
* Scaled‑Down Dialogue Box
* Scaled‑Down Menu
* Customizable Save Point Crystal Color
* Disable White Save Point Glow (reduces the washed‑out look of the crystal)
* Disable World Map Clouds
* Disable World Map Sun Rays
* Scaled‑Down World Map of Suikoden 1
* Alternative Run Animation for Tir (Project Kyaro sprites)
* Restore Bamboo Fence on Mercenary Fortress
* NPC Bathhouse Sprites & Castle Visitors Restoration (S2)
* Muse Ruins Survivors Restoration & 108 Stars Spiritual Reward (S2)
* Remote Castle Vault Access via Right Stick Up / R3 (Open Rock's warehouse from anywhere on the field with transparent background overlay, area background load verification, loading screen immunity, and complete background player movement silencing, S1)
* Remote Castle Rune Master Access via Right Stick Down (Open Jeane's rune shop from anywhere on the field with area background load verification, loading screen immunity, and complete background player movement silencing, S1)
* Castle Rune Master (Jeane) Shop Expansion & Progressive Crystal Store (Re-indexes Jeane's menu to Attach, Remove, Buy, and Exit; introduces Chandler-style progressive Rune Crystal purchasing unlocked from town rune shops visited across the world, S1)

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
* Replaced Low‑Quality Upscaled Doors in the Inn Area (S2)

**[Utility]**
* Dear ImGui In-Game Runtime Feature & Diagnostics Suite (Toggle with F10; clean two-column layout with searchable sections for General & Debug, Combat, Runes, Recovery, Visuals & Shaders, Castle Bathhouse, Party Roster, Scene Telemetry, and a dedicated Themes & Settings page; includes prominent Location Data & Notes widget with [NumPad 5] log dump, bottom-left in-game HUD, and context-aware input isolation that automatically silences gamepad controller and keyboard inputs to the main game whenever the overlay is open or hovered)
* Map Teleport & Time-Phase Re-entry Warper (Jump directly into any story-phase map variant across the game via 35 presets or custom map codes, and reposition Riou anywhere on the active map via Dear ImGui [F10])
* Location Dump [NumPad 5] (Press [NumPad 5] anytime in gameplay or click the overlay button to instantly dump current map, player tile coordinates, and location telemetry to `\Suikoden I and II HD Remaster\PKCore\Logs\locationdump.log`)
* Encounter None [F4] (Toggle random battle encounters on/off with [F4] or via Dear ImGui overlay; automatically delegates to Suikoden_Fix multiplier when present, with native fallback hooks for S1 & S2)
* Show Mouse Cursor (Live runtime toggle via Dear ImGui overlay and configuration to unlock and force OS cursor visibility)
* Clean Exit on ALT+F4 (Force immediate shutdown instead of hanging)
* High-Speed Decompiled Symbol Indexer & CLI Query Tool (Sub-millisecond lookups for C# types, members, and native IL2CPP addresses)

> **Borderless Mode**: For borderless fullscreen window, use Unity's native `-popupwindow` launch argument:
> - **Steam**: Right-click game → Properties → Launch Options → Add `-popupwindow`
> - **Epic Games**: Create a shortcut to the game executable and add `-popupwindow` to the Target field

**[Additionals from Nexus Bundle]**

* Restore the Dash in the Letter “Z” via Custom Font
* Alternate CRC Bypass for Version 1.0.4



Replace game textures with custom PNG or DDS files in `BepInEx/plugins/PKCore/Textures/`. Use `00-Mods/` subfolder for highest priority custom mods.

**Performance Optimization**: Built-in manifest caching dramatically improves boot times. DDS format support allows pre-compressed textures (**BC1**, **BC3**, and high-quality **BC7** with DX10 header support) for reduced VRAM usage and faster loading.

### Advanced Customization

- **Tenzan Pass Chimera Encounters Restoration**: Restores omitted Chimera monster encounters (Parties 6, 7, and 8) in Tenzan Pass (`va11`) with Pyriel's community fix layout (~30% encounter rate), guaranteed or configurable Cyclone Rune drops, and multi-tier engine bounds protection against Remaster crash bugs. See [Tenzan Pass Guide](Documentation/tenzan_pass_chimera_va11.md).
- **Sajah Village Rare Shop & Rune Sage Unlock**: Early access unlock for the hidden late-game rare item/rune vendor and counter trigger in Sajah Village (`vj17`) bypassing story flag 143 via in-memory map patching. See [Sajah Shop Guide](Documentation/sajah_village_rare_shop_vj17.md).
- **Muse Ruins Survivors & 108 Stars Spiritual Reward**: Restores interaction triggers and authored dialogues for the 8 dormant/silent actors (`obj[02]`–`obj[09]`) in Muse Ruins (`vc26_01`) by re-targeting orphaned interaction scripts (`ev[62]`–`ev[77]`). Uniting all 108 Stars of Destiny cleanses all 33 spirits and survivors, switching them to their hidden, peaceful dialogue as a spiritual reward.
- **NPC Bathhouse Sprites & Castle Visitors Restoration**: Restores unused bathhouse sprites for non-combatant recruits and convoy members in Suikoden 2, unlocks full 8-character bathhouse capacity (+2 convoy/visitor slots over a 6-man party), eliminates engine null-dereference crashes, guarantees accurate gender-based tub separation via verified sprite atlases (routes Tenkou [99] and Boris [123] to men's tub; routes Teresa [95/102] to women's tub), preserves vanilla Case 2 unisex routing for Simone and Vincent (allowing them into the other tub), preserves native implementations for Gadget and beasts (Abizboah, Rulodia, Feather, Siegfried, Shiro, Mukumuku), and populates vacant bath positions with recruited castle companions (Apple, Shu, Leona, Richmond, Barbara, Pilika, Teresa, etc.). See [Bath Attributes Guide](Documentation/suikoden_2_character_attributes_gender_and_baths.md).
- **Memory Auto-Battle**: Replays last manually chosen actions (Attack vs Rune/Magic) in Auto-Battle with resource and status checks.
- **Suikoden I Map Identifiers & Regional Breakdown Reference Guide**: Complete architectural reference and regional sector catalog for Suikoden 1, documenting all 12 regional sectors (`area_a` through `area_k`, `area_z`), 85 background map assets (`bg_va1`–`bg_vz5`), C# decompiled handlers (`G1_fdata_c.cs`, `VillageManager.cs`, `Village_c.cs`, `Event_c.cs`), and the 70+ `EVENT_COMMAND` bytecode opcodes. See [Suikoden 1 Map Guide](Documentation/suikoden_1_map_ids_and_areas_breakdown.md).
- **Suikoden II Map Identifiers & Geographic Areas Reference**: Master architectural reference and exhaustive breakdown of all 4-character map and venue identifiers (`va01` through `vk37`), chronological story chapters, extracted asset conventions, text message encoding keys, and associated PKCore patches. See [Map Identifiers Guide](Documentation/suikoden_2_map_ids_and_areas_breakdown.md).
- **Suikoden II Master Map Entities, Triggers & World Objects Catalog**: Exhaustive technical census and bytecode reference across all 226 master map assets in Suikoden 2, documenting all 4,901 NPCs, 1,552 dynamic props (bonsai trees, flower pots, furniture), 3,207 collision triggers and single-tile dots, 90 save points, 27 chest clusters, hidden/unfinished entities, trigger types (`etyp`), and all 147 event command opcodes (`EC*`) with in-memory injection blueprints. See [Master Map Entities Guide](Documentation/suikoden_2_master_map_entities_and_triggers_catalog.md).
- **Individual Geographic Area Volumes (62 Areas)**: Complete standalone documentation files for every village, dungeon, city, pass, and castle area in `Documentation/areas/`, complete with embedded **Human-Readable Field & Engine Legends** and decoded plain-English event actions (no raw opcode numbers).
- **Placeholder Text Replacement**: Automatic replacement of protagonist and HQ name placeholders in dialogs. See [Placeholder Text Guide](Documentation/PlaceholderText.md).
- **Active Launcher Language Detection**: Automatically detects the active launcher language on startup (English, Traditional Chinese, Simplified Chinese, Japanese, French, German, Spanish, Italian, Korean) and tracks manual language changes via `LanguageSelectionPatch`.
- **High-Speed Decompiled Symbol & Map Indexer**: Instant lookup tool for C# classes, methods, fields, native IL2CPP memory addresses, and all 360 Maps & World Environments across both Suikoden 1 and Suikoden 2 (`tools\sym.bat <Query>`, `tools\sym.bat --maps <MapID>`). See [Symbol Indexer Guide](Documentation/symbol_indexer_guide.md).
- **Dear ImGui In-Game Runtime Inspector & Diagnostics Overlay**: Toggled with keyboard key **`[F10]`** (and closed with `[Escape]` or `[X]`). Powered natively by **Dear ImGui** (via `DearImGuiInjection` / `ImGui.NET` over DirectX 11 Present injection), with zero bundle bloat inside `PKCore.dll`. Features an ergonomic **Two-Column Split Layout**:
  - **Bottom-Screen Location HUD & Hotkey Dump (`[NumPad 5]`)**: Displays a compact, semi-transparent location box at the bottom-left of the screen during gameplay when the main overlay is closed (`Location: <MapId>`). Pressing **`[NumPad 5]`** immediately appends a formatted location snapshot to `\PKCore\Logs\locationdump.log`. Can be toggled on/off in the overlay menu or sidebar and persists in `PKCore.cfg` (`ShowLocationHUD`).
  - **4 Selectable Visual Themes**: **Classic Blue** (traditional Dear ImGui deep navy & royal blue), **Matrix** (deep black & phosphor terminal green), **Obsidian Black** (monochrome pure graphite obsidian & ice silver), and **Dark Magenta** (midnight indigo & neon fuchsia). Switchable on the fly via MenuBar or Themes & Settings section.
  - **Left Sidebar**: Real-time keyword filter search box and clean selectable section list.
  - **Right Content Pane**: Balanced two-column cards across General & Debug, Combat & Runes (Memory Auto-Battle, Unlimited Runes, Unbalance Removal, Range Overrides, Battle HUD), Recovery & Progression toggles, Save Crystal Color Picker, 12-slot Castle Bathhouse Inspector (Men's slots 0..5 vs Women's slots 6..11, origin, character IDs, atlas coordinates), live scene telemetry, the **Map Teleport & Time-Phase Re-entry Warper** (jump to any story map state or reposition player coordinates on the active grid), and the **Tile & Entity Editor** (inspect any tile's physical objects and trigger scripts, inject custom actors, props, save crystals, or warp doors in memory, and export placements to JSON; see [Tile & Entity Editor Guide](Documentation/tile_and_entity_editor_guide.md)).
- **Encounter None Hotkey & Toggle (`[F4]`)**: Quickly suppress random wandering and field encounters for testing and exploration. Automatically integrates with `Suikoden_Fix` if installed (setting its `EncounterRateMultiplier` to 0.0), or activates native Harmony hooks across both Suikoden I and Suikoden II.
- **NPC Portraits**: Inject custom high-resolution portraits for any NPC.
- **War Battle Modding**: Customize character stats, abilities, and subunit bonus values in Suikoden 2 war battles via JSON.
- **UI Scaling**: Presets for dialog box size and menu layout scaling.
- **Classic UI**: Revert Suikoden 2 save windows to the classic PSX look.
- **Controller Prompt Override**: Force specific button icons (Xbox/PS4/PS5/Switch) regardless of detected controller.


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

If you have **PKextended.dll** or Older Versions of Project Kyaro installed from a previous version:

1. **Remove Old files**:

   - Delete `PKextended.dll` from `BepInEx/plugins/`
   - Old config: `BepInEx/config/faospark.pkextended.cfg`
   - Delete or Back-up `dxgi.dll` or `d3d11.dll` of what every .dll name you loaded SpecialK
   - Delete all of the texture file `SK_Res\inject\textures` as they are now necessesary
2. **Config File** (optional - will auto-generate):

   - New config: `BepInEx/config/faospark.pkcore.cfg`

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
