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
* Restore Chimera Encounters in Tenzan Pass (migrated to dedicated PKTenzanPassPatch plugin, S2)
* Early Sajah Village Rare Shop & Rune Sage Vendor Unlock (migrated to dedicated PKRuneSagePlus plugin, S2)
* Combat Systems & Battle Enhancements (migrated to dedicated PKBattlePatch plugin: Enemy Level/HP HUD, Party Max HP, Memory Auto-Battle, Smart After-Battle Healing, Battle Formation Spacing, Unlimited Command Runes, Rune Unbalance Removal, Range Overrides)
* Save Slot Party Member Mini Portraits (S1 & S2 with high-performance caching)
* Button Controller Prompt Support (migrated to dedicated PKButtonPrompts plugin)
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
* Repeatable Guardian Deity Statue Rewards (Receive blessings from sculptor Jude every time you change or rebuild the statue combination at his workshop, rather than the vanilla one-time limit, S2)
* Restore Dormant Castle Features (Restores the secret pasture shortcut door in residential quarters [vk13] and Karen's cut stage choreography routines 5-8 [vk19], S2)
* Remote Castle Rune Master Access via Right Stick Down (Open Jeane's rune shop from anywhere on the field with area background load verification, loading screen immunity, and complete background player movement silencing, S1)
* Castle Rune Master (Jeane) Shop Expansion & Progressive Crystal Store (migrated to dedicated PKRuneSagePlus plugin, S1)

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
* Dear ImGui Location & Notes HUD (Streamlined bottom-left telemetry HUD displaying current map and location name, live camera zoom / FOV controls with [PageDown]/[PageUp]/[Home] hotkeys, interactive notes entry, [NumPad 5] log dump to `\PKCore\Logs\locationdump.log`, and zero gamepad or movement input interference)
* Location Dump [NumPad 5] (Press [NumPad 5] anytime in gameplay or click the HUD button to instantly dump current map and location notes to `\Suikoden I and II HD Remaster\PKCore\Logs\locationdump.log`)
* Encounter None [F4] (Toggle random battle encounters on/off with [F4] or via Dear ImGui overlay; automatically delegates to Suikoden_Fix multiplier when present, with native fallback hooks for S1 & S2)
* Show Mouse Cursor (Live runtime toggle via Dear ImGui overlay and configuration to unlock and force OS cursor visibility)
* Borderless Floating Window Mode (Strips Win32 title bars and borders while remaining in windowed mode, enabling custom smaller resolutions in clean borderless windows)
* Clean Exit on ALT+F4 (Force immediate shutdown instead of hanging)
* High-Speed Decompiled Symbol Indexer & CLI Query Tool (Sub-millisecond lookups for C# types, members, and native IL2CPP addresses)

> **Borderless Modes**:
> - **Floating Windowed Borderless (Custom Resolutions / Smaller Windows)**: Enable `EnableBorderlessWindow = true` under `[Utilty]` in `PKCore.cfg`. Strips the OS window caption and resizing frame while retaining windowed mode.
> - **Fullscreen Borderless (Full Desktop)**: Use Unity's native `-popupwindow` launch argument:
>   - **Steam**: Right-click game → Properties → Launch Options → Add `-popupwindow`
>   - **Epic Games**: Create a shortcut to the game executable and add `-popupwindow` to the Target field

**[Additionals from Nexus Bundle]**

* Restore the Dash in the Letter “Z” via Custom Font
* Alternate CRC Bypass for Version 1.0.4



Replace game textures with custom PNG or DDS files in `BepInEx/plugins/PKCore/Textures/`. Use `00-Mods/` subfolder for highest priority custom mods.

**Performance Optimization**: Built-in manifest caching dramatically improves boot times. DDS format support allows pre-compressed textures (**BC1**, **BC3**, and high-quality **BC7** with DX10 header support) for reduced VRAM usage and faster loading.

### Advanced Customization

- **Tenzan Pass Chimera Encounters Restoration**: Migrated to dedicated standalone plugin `PKTenzanPassPatch` (`faospark.pktenzanpasspatch`). Restores omitted Chimera monster encounters (Parties 6, 7, and 8) in Tenzan Pass (`va11`) with Pyriel's community fix layout (~30% encounter rate), guaranteed or configurable Cyclone Rune drops, and multi-tier engine bounds protection against Remaster crash bugs. See [Tenzan Pass Guide](Documentation/tenzan_pass_chimera_va11.md).
- **Sajah Village Rare Shop & Rune Sage Unlock**: Migrated to dedicated standalone plugin `PKRuneSagePlus` (`faospark.pkrunesageplus`). Early access unlock for the hidden late-game rare item/rune vendor and counter trigger in Sajah Village (`vj17`) bypassing story flag 143 via in-memory map patching. See [Sajah Shop Guide](Documentation/sajah_village_rare_shop_vj17.md).
- **NPC Bathhouse Sprites & Castle Visitors Restoration**: Migrated to dedicated standalone plugin `PKS2BathNPCPatch` (`faospark.pks2bathnpcpatch`). Restores unused bathhouse sprites for non-combatant recruits and convoy members in Suikoden 2, unlocks full 8-character bathhouse capacity (+2 convoy/visitor slots over a 6-man party), eliminates engine null-dereference crashes, guarantees accurate gender-based tub separation via verified canonical character IDs (routes Tenkou [97], Richmond [99], Boris [122] to men's tub; routes Teresa [101], Emilia [96], Barbara [98], Leona [91], Pilika [123] to women's tub), gates Pilika's presence to before the Muse Peace Conference, preserves vanilla Case 2 unisex routing for Simone and Vincent, preserves native implementations for Gadget and beasts (Abizboah, Rulodia, Feather, Siegfried, Shiro, Mukumuku), and populates vacant bath positions with recruited castle companions. See [Bath Attributes Guide](Documentation/suikoden_2_character_attributes_gender_and_baths.md).
- **Dunan Castle HQ Dormant Features Restoration**: Bytecode-level restoration of cut and dormant features inside Dunan Castle HQ (`MACHICON.EventInit` in-memory patching via `RestoreDormantCastleFeatures` toggle in `PKCore.cfg` under `[zz - Experimental]`):
  - **Secret Pasture Shortcut Door (`vk13` Submap 4)**: Bypasses the dead `base_lv == 4` condition on the residential floor back door (`ev[12]`, `ev[13]`), allowing the player to press Action on the door to warp straight outside to Yuzu's animal pasture in `vk03` (and step back inside via the paddock zone) without climbing down multiple floors.
  - **Karen's Cut Stage Choreography (`vk19` Submap 0)**: Eliminates the impossible bitmask condition `[9, 26, 0]` (`event_flag[26] & 0 != 0`) on event slots `ev[62]` through `ev[65]`, unlocking 4 previously unreachable dance routines and backup dancer stage formations with Karen in the tavern. See [Dunan Castle Forensic Research](Documentation/dunan_castle_hq_forensic_research.md).
- **Suikoden I Map Identifiers & Regional Breakdown Reference Guide**: Complete architectural reference and regional sector catalog for Suikoden 1, documenting all 12 regional sectors (`area_a` through `area_k`, `area_z`), 85 background map assets (`bg_va1`–`bg_vz5`), C# decompiled handlers (`G1_fdata_c.cs`, `VillageManager.cs`, `Village_c.cs`, `Event_c.cs`), and the 70+ `EVENT_COMMAND` bytecode opcodes. See [Suikoden 1 Map Guide](Documentation/suikoden_1_map_ids_and_areas_breakdown.md).
- **Suikoden II Map Identifiers & Geographic Areas Reference**: Master architectural reference and exhaustive breakdown of all 4-character map and venue identifiers (`va01` through `vk37`), chronological story chapters, extracted asset conventions, text message encoding keys, and associated PKCore patches. See [Map Identifiers Guide](Documentation/suikoden_2_map_ids_and_areas_breakdown.md).
- **Suikoden II Master Map Entities, Triggers & World Objects Catalog**: Exhaustive technical census and bytecode reference across all 226 master map assets in Suikoden 2, documenting all 4,901 NPCs, 1,552 dynamic props (bonsai trees, flower pots, furniture), 3,207 collision triggers and single-tile dots, 90 save points, 27 chest clusters, hidden/unfinished entities, trigger types (`etyp`), and all 147 event command opcodes (`EC*`) with in-memory injection blueprints. See [Master Map Entities Guide](Documentation/suikoden_2_master_map_entities_and_triggers_catalog.md).
- **Individual Geographic Area Volumes (62 Areas)**: Complete standalone documentation files for every village, dungeon, city, pass, and castle area in `Documentation/areas/`, complete with embedded **Human-Readable Field & Engine Legends** and decoded plain-English event actions (no raw opcode numbers).
- **Placeholder Text Replacement**: Automatic replacement of protagonist and HQ name placeholders in dialogs. See [Placeholder Text Guide](Documentation/PlaceholderText.md).
- **Active Launcher Language Detection**: Automatically detects the active launcher language on startup (English, Traditional Chinese, Simplified Chinese, Japanese, French, German, Spanish, Italian, Korean) and tracks manual language changes via `LanguageSelectionPatch`.
- **High-Speed Decompiled Symbol & Map Indexer**: Instant lookup tool for C# classes, methods, fields, native IL2CPP memory addresses, and all 360 Maps & World Environments across both Suikoden 1 and Suikoden 2 (`tools\sym.bat <Query>`, `tools\sym.bat --maps <MapID>`). See [Symbol Indexer Guide](Documentation/symbol_indexer_guide.md).
- **Dear ImGui Location & Notes HUD**: Lightweight, non-intrusive on-screen telemetry and notes tool powered natively by **Dear ImGui** (via `DearImGuiInjection` / `ImGui.NET` over DirectX 11 Present injection):
  - **Live Location Telemetry & Notes Input**: Displays a compact, semi-transparent location box at the bottom-left of the screen during gameplay (`Location: <MapId>`). Click the HUD or press **`[NumPad 6]`** / **`[F9]`** to expand the note field, type area descriptions, and hit Enter to save.
  - **Hotkey Location Dump (`[NumPad 5]`)**: Pressing **`[NumPad 5]`** (or clicking `Dump`) immediately appends a formatted location snapshot with current notes to `\PKCore\Logs\locationdump.log`. Click `Open Log` to open the file directly.
  - **Zero Input Interference**: Operates cleanly without invasive input blockers on gamepads, analog sticks, or movement systems, ensuring seamless compatibility with player controls and third-party movement mods.
  - **Visual Themes & Configuration**: Supports 4 color themes (**Classic Blue**, **Matrix**, **Obsidian Black**, and **Dark Magenta**) configurable in `PKCore.cfg` (`ShowLocationHUD`, `ImGuiTheme`).
- **Encounter None Hotkey & Toggle (`[F4]`)**: Quickly suppress random wandering and field encounters for testing and exploration. Automatically integrates with `Suikoden_Fix` if installed (setting its `EncounterRateMultiplier` to 0.0), or activates native Harmony hooks across both Suikoden I and Suikoden II.
- **NPC Portraits**: Inject custom high-resolution portraits for any NPC.
- **War Battle Modding**: Customize character stats, abilities, and subunit bonus values in Suikoden 2 war battles via JSON.
- **UI Scaling**: Presets for dialog box size and menu layout scaling.
- **Classic UI**: Revert Suikoden 2 save windows to the classic PSX look.
- **Controller Prompt Override**: Force specific button icons (Xbox/PS4/PS5/Switch) regardless of detected controller (migrated to `PKButtonPrompts`).


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
