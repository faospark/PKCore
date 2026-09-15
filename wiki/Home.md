# Welcome to the PKCore Wiki ⚔️

[![Framework: BepInEx 6 IL2CPP](https://img.shields.io/badge/Framework-BepInEx_6_IL2CPP-6B46C1.svg)](https://github.com/faospark/PKCore)
[![Game: Suikoden I & II HD Remaster](https://img.shields.io/badge/Game-Suikoden_I_%26_II_HD_Remaster-0078D7.svg)](https://store.steampowered.com/app/1932640/)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://opensource.org/licenses/MIT)
[![Nexus Mods](https://img.shields.io/badge/Download-Nexus_Mods-DA6A00.svg)](https://www.nexusmods.com/suikoden1and2hdremaster/mods/6)

> **PKCore (Project Kyaro Core)** is the next-generation core engine and modding framework for **Suikoden I & II HD Remaster**. It provides zero-compromise runtime texture injection, high-performance DDS decoding (BC1/BC3/BC7), CriWare sound swapping (ACB/AWB file redirection), dynamic dialogue and NPC portrait frameworks (for both Suikoden I & II), save slot party member mini portraits, battle formation spacing adjustments, character weapon range overrides, Suikoden II war battle rebalancing, UI scaling enhancements, and extensive graphical customization.

---

## 🧭 Navigation Portal

<div align="center">

| 🚀 [Getting Started](#-getting-started) | ⚙️ [Configuration Guide](#%EF%B8%8F-configuration-overview) | 🎨 [Texture Modding](custom_textures_guide) |
| :--- | :--- | :--- |
| • Requirements<br>• Installation<br>• Directory Layout | • Settings Reference<br>• Visual & UI Toggles<br>• Live Hot-Reloading | • Formats (PNG, DDS BC7)<br>• Priority Hierarchy<br>• Manifest Caching |

| 🎭 [NPC & Dialogue Portraits](walkthrough_npc_portraits) | 🔊 [Sound Swapping](sound_modding_guide) | ⚔️ [War Battles](war_battle_modding) |
| :--- | :--- | :--- |
| • Speaker ID Mapping<br>• Expression Variants<br>• S1 & S2 Integration | • ACB / AWB Audio Banks<br>• Music & SFX Redirection<br>• Better Launcher BGM | • JSON Ability Overrides<br>• Unit Stats & Attributes<br>• Commander Traits |

| 🏹 [Battle Ranges & Formations](suikoden_2_character_battle_ranges) | 🖼️ [Save Slot Party Portraits](#-save-slot-party-member-portraits) | 📦 [00-Mods Guide](00-mods_guide) |
| :--- | :--- | :--- |
| • Weapon Range Overrides<br>• 6-Hero Formation Spacing<br>• Hot-Reloadable Config | • In-Memory Portrait Cache<br>• S1 & S2 Save/Load UI<br>• Custom Texture Priority | • Mod Packaging<br>• Isolated Folders<br>• Conflict Resolution |

</div>

---

## ⚡ Key Highlights & Architecture

```
                                  ┌───────────────────────────────┐
                                  │      PKCore Architecture      │
                                  └───────────────┬───────────────┘
                                                  │
         ┌─────────────────────────┬──────────────┴─────────────┬─────────────────────────┐
         ▼                         ▼                            ▼                         ▼
┌──────────────────┐     ┌──────────────────┐         ┌──────────────────┐      ┌──────────────────┐
│  High-Perf DDS   │     │  00-Mods Layer   │         │  NPC Portraits   │      │ War Battle &     │
│  & Texture Engine│     │ Overrides & Audio│         │ & Save Portraits │      │ Battle Formation │
│ (BC1 / BC3 / BC7)│     │ (Top-Priority)   │         │ (S1 & S2 Support)│      │ (S2 Range Mods)  │
└──────────────────┘     └──────────────────┘         └──────────────────┘      └──────────────────┘
```

* **⚡ Zero-Lag Manifest Caching**: Scans thousands of texture replacements and caches indices in XML — boot times drop from seconds to milliseconds.
* **🚀 Native GPU DDS Acceleration**: Direct in-place memory replacement using BC1, BC3, and high-fidelity BC7 textures (with DX10 header support).
* **🖼️ Save Slot Party Member Portraits**: Automatically renders high-resolution mini party portraits in save/load slots for both Suikoden I and II with instant 0ms cached lookups.
* **🏹 Character Battle Range Overrides (S2)**: Configurable weapon range modification (e.g. Kasumi, Luc, Mazus, Viki, Gantetsu, Badeaux, Sierra from Short `S` to Medium `M`), removing formation warnings and allowing back-row attacks.
* **📐 Battle Position Formation Adjustments (S2)**: Configurable party formation spacing presets (`wide`, `widest`) preventing back-row party members from blocking front-row characters.
* **🎭 Dynamic NPC & Dialogue Portrait Framework**: Inject high-res dialogue portraits for any NPC or character with multi-language, emotion variant, and cutscene fallback support across both games.
* **🛡️ Data-Driven War Battles**: Deep rebalancing of Suikoden II Tactical War Battles via intuitive `S2WarAbilities.json`.
* **🔊 CriWare Sound Swapping**: Drop-in `.acb`/`.awb` sound and music redirection without modifying game archives.
* **🎮 UI & Immersion Customization**: Customizable Save Point Crystal colors, UI scaling, Enhanced Gallery backgrounds, classic PSX save windows, and controller button prompt overrides.

---

## 🚀 Getting Started

### Requirements
* **Game**: Suikoden I & II HD Remaster (Steam or Epic Games, Unity 2022.3.28f1)
* **Mod Loader**: [BepInEx 6.0.0-pre.2 (IL2CPP 64-bit)](https://github.com/BepInEx/BepInEx/releases)
* **Recommended Companion**: [Suikoden Fix](https://github.com/d3xMachina/SuikodenFix) by d3xMachina

### Quick Installation

1. Install **BepInEx 6.0.0-pre.2 IL2CPP** into your game root folder.
2. Download the latest **[Project Kyaro / PKCore](https://www.nexusmods.com/suikoden1and2hdremaster/mods/6)** release.
3. Place `PKCore.dll` in `BepInEx/plugins/PKCore/` and any mod assets in `PKCore/Textures/`, `PKCore/Sound/`, or `PKCore/00-Mods/`.
4. Launch the game once to auto-generate the configuration file at `BepInEx/config/faospark.pkcore.cfg`.

### Directory Layout

```
<Game Directory>/
├── BepInEx/
│   ├── config/
│   │   └── faospark.pkcore.cfg         <-- Primary BepInEx configuration
│   └── plugins/
│       └── PKCore/
│           └── PKCore.dll              <-- Core engine plugin
└── PKCore/
    ├── Cache/
    │   └── texture_manifest.xml        <-- Auto-generated texture index
    ├── Config/                         <-- Data-driven JSON configuration
    │   ├── S2WarAbilities.json         <-- War battle custom stats & abilities (S2)
    │   ├── PortraitMappings.json       <-- Character name to portrait image map
    │   ├── PortraitVariants.json       <-- Expression & emotion variant definitions
    │   ├── DialogOverrides.json        <-- Specific dialogue line portrait overrides
    │   ├── S1SpeakerOverrides.json     <-- Suikoden 1 speaker ID overrides
    │   └── S2SpeakerOverrides.json     <-- Suikoden 2 speaker ID overrides
    ├── Debug/                          <-- Runtime database & asset dumps
    │   ├── JsonDumps/                  <-- AssetBundle TextAsset & JSON dumps
    │   ├── TextDB_GSD1.json            <-- Suikoden 1 dialogue database dump
    │   └── TextDB_GSD2.json            <-- Suikoden 2 dialogue database dump
    ├── JsonOverrides/                  <-- Custom JSON TextAsset replacements
    ├── Textures/                       <-- Base texture overrides
    │   ├── GSD1/                       <-- Suikoden 1 specific
    │   │   └── NPCPortraits/           <-- S1 dialogue portraits (PNG / DDS)
    │   ├── GSD2/                       <-- Suikoden 2 specific
    │   │   └── NPCPortraits/           <-- S2 dialogue portraits (PNG / DDS)
    │   └── NPCPortraits/               <-- Shared dialogue portraits
    ├── Sound/                          <-- Base CriWare sound banks
    └── 00-Mods/                        <-- High-priority mod packages
        ├── PKS1/                       <-- Project Kyaro S1 sprites
        ├── PKS2/                       <-- Project Kyaro S2 sprites
        └── Better-Launcher-BGM-Mod/    <-- Launcher BGM mod
```

---

## 📄 Data-Driven JSON Files

PKCore uses several JSON files located in `PKCore/Config/` for deep data-driven customization. Mod packages in `PKCore/00-Mods/<ModName>/` can also supply their own versions to seamlessly merge overrides:

| JSON File | Default Location | Description |
| :--- | :--- | :--- |
| **`S2WarAbilities.json`** | `PKCore/Config/` | Custom unit stats (ATK, DEF, MOV, HP), subunit leader bonuses, and tactical abilities for Suikoden II war battles. |
| **`PortraitMappings.json`** | `PKCore/Config/` | Links speaker and character names directly to high-resolution portrait texture filenames. |
| **`PortraitVariants.json`** | `PKCore/Config/` | Configures emotional expression mapping rules (e.g., `smile`, `angry`, `sad`, `shock`, `hurt`, `close`). |
| **`DialogOverrides.json`** | `PKCore/Config/` | Granular per-line dialogue overrides mapping specific dialogue IDs to custom portraits. |
| **`S1SpeakerOverrides.json`** | `PKCore/Config/` | Maps Suikoden 1 internal speaker IDs to character names and portrait keys. |
| **`S2SpeakerOverrides.json`** | `PKCore/Config/` | Maps Suikoden 2 internal speaker IDs to character names and portrait keys. |
| **`TextDB_GSD1.json` / `TextDB_GSD2.json`** | `PKCore/Debug/` | Cumulative dialogue and speaker dumps created at runtime when exploring scenes. Useful for finding dialogue IDs and text references. |

---

## 📂 Priority & Layering Hierarchy

PKCore implements a multi-tier override system ensuring modularity and conflict resolution:

| Priority | Layer | Path | Description |
| :--- | :--- | :--- | :--- |
| **1 (Lowest)** | **Vanilla Asset** | `StreamingAssets/` | Original base game files |
| **2** | **Base Overrides** | `PKCore/Textures/` & `PKCore/Sound/` | Default Project Kyaro replacements |
| **3** | **Game Isolation** | `PKCore/Textures/GSD1/` or `GSD2/` | Overrides restricted to Suikoden 1 or 2 |
| **4 (Highest)** | **00-Mods Packages** | `PKCore/00-Mods/<ModName>/` | **Always wins.** Multiple mods sorted alphabetically (`zz_` prefix wins) |

---

## ⚙️ Configuration Overview

All options are configurable in `BepInEx/config/faospark.pkcore.cfg`:

### 🎨 Visual & Sprites
* `EnableProjectKyaroSprites` (`true`/`false`): Toggle Project Kyaro HD upscaled sprites.
* `DisableSpritePostProcessing` (`true`/`false`): Strips bloom/vignette from sprites to eliminate bright border seams.
* `SpriteFilteringEnabled` (`true`/`false`): Bilinear + Anisotropic filtering for smooth rendering.
* `SMAAQuality` (`Off`, `Low`, `Medium`, `High`): Anti-aliasing quality level.

### 🖥️ User Interface & Controls
* `ControllerPromptType` (`PlayStation`, `PlayStation5`, `Xbox`, `Switch`, `Generic`): Force controller prompt button glyphs.
* `ScaleDownDialogBox` (`true`/`false`): Compact dialogue box (80% size) for improved scene visibility.
* `ScaledDownMenu` (`true`/`false`): Scaled-down main pause/status menu.
* `ClassicSaveWindow` (`true`/`false`): Restores the classic PSX-style save slot interface in Suikoden II.
* `ShowSaveSlotPartyPortraits` (`true`/`false`): Displays mini party member portraits next to character level (`Txt_Lv`) in save/load slots.
* `DisablePortraitDialogMask` (`true`/`false`): Removes the dark vignette gradient overlay from dialogue portraits.
* `EnhancedGallery` (`true`/`false`): Replaces Movies, Events, and Sounds gallery backgrounds with custom textures inspired by the PSP release.
* `PSPLauncher` (`true`/`false`): Enable the PSP-inspired launcher interface.

### ⚔️ Combat & Formations (Suikoden II)
* `EnableBattlePositionAdjustments` (`true`/`false`): Adjusts 6-character party formation spacing so back-row characters don't obstruct front-row members.
* `S2BattlePositionPreset` (`default`, `wide`, `widest`): Formation spacing preset (`wide` is recommended).
* `EnableCharacterRangeOverrides` (`true`/`false`): Enable custom weapon/attack range modification with live hot-reloading.
* `S2CharacterRangeOverrides` (string): Comma-separated list of range overrides (e.g. `Kasumi:M, Luc:M, Mazus:M, Viki:M, Gantetsu:M, Badeaux:M, Sierra:M`).
* `EnableWarAbilityMod` (`true`/`false`): Tactical war battle ability customization via `S2WarAbilities.json`.

### 🌟 Aesthetics & General
* `SavePointColor` (`default`, `blue`, `green`, `red`, `purple`, `yellow`, `cyan`, `random`, etc.): Customizes the crystal save orb.
* `DisableSavePointGlow` (`true`/`false`): Removes the washed-out white glare from save points.
* `DisableWorldMapClouds` / `DisableWorldMapSunrays` (`true`/`false`): Cleans up the world map visuals.
* `ColoredIntroAndFlashbacks` (`true`/`false`): Restores vibrant colors to flashback sequences.
* `BetterLauncherBGM` (`true`/`false`): Replaces launcher ambient music with Suikoden 2's adventure start theme.

---

## 🖼️ Save Slot Party Member Portraits

With `ShowSaveSlotPartyPortraits = true`, PKCore brings party member portraits directly into the Save and Load screens for both **Suikoden I** and **Suikoden II**:

- **Suikoden I**: Dynamic resolution across in-memory save lists and decrypted save data, utilizing `Ws_face_c.CharacterIDConvertToFaceIDStatic` to index portraits accurately (e.g. `fp_gsd1_000` for Tir, Joshua, etc.).
- **Suikoden II**: Instant party member array lookup (`party_cha_no`) mapped directly to high-res character portraits.
- **In-Memory Caching**: 0ms lookups after initial read during save menu scrolling, prioritizing custom DDS/PNG textures from `PKCore/Textures/` over vanilla sprites.

---

## 📚 Wiki Documentation Index

Explore in-depth documentation pages for every system:

| Guide | Description |
| :--- | :--- |
| 📖 [**00-Mods Guide**](00-mods_guide) | How to build, package, and structure plug-and-play mods. |
| 🖼️ [**Custom Textures Guide**](custom_textures_guide) | Dumping textures, DDS BC7 compression, naming syntax, and hash bypasses. |
| 🎭 [**NPC Portrait Walkthrough**](walkthrough_npc_portraits) | Adding portraits to faceless NPCs, variant expressions, DDS BC7 support, and speaker IDs. |
| 🏹 [**Character Battle Ranges & Formations**](suikoden_2_character_battle_ranges) | Modifying character weapon ranges (S/M/L) and adjusting battle formation spacing presets. |
| ⚔️ [**War Battle Modding Guide**](war_battle_modding) | Customizing Suikoden II tactical units, leader bonuses, and special skills. |
| 🔊 [**Sound Swapping Guide**](sound_modding_guide) | CriWare ACB/AWB audio swapping and custom BGM/SFX redirection. |
| ⚡ [**Caching & Performance**](caching_mechanism) | Deep dive into the XML manifest cache, scene unloader, and smart memory. |
| 📝 [**Placeholder Text System**](place_holder_text) | Dynamic replacement of protagonist and castle names in dialogue. |
| ⚙️ [**Configuration Reference**](configuration_guide) | Full variable list and default value reference table. |

---

## 🛠️ Troubleshooting & FAQ

<details>
<summary><b>Q: My custom texture is not showing up in-game.</b></summary>

1. Verify that your file is named to match the Unity texture name or hash pattern.
2. Enable `LogReplaceableTextures = true` in `faospark.pkcore.cfg` to verify exact runtime names in the console/log.
3. If you added new files with manifest caching enabled, delete `PKCore/Cache/texture_manifest.xml` to force a re-index.
</details>

<details>
<summary><b>Q: How do I run borderless fullscreen?</b></summary>

Use Unity's native `-popupwindow` launch parameter:
* **Steam**: Right-click Game → Properties → General → Launch Options → add `-popupwindow`
* **Epic Games**: Add `-popupwindow` to your desktop shortcut target.
</details>

<details>
<summary><b>Q: Migrating from old PKExtended / Special K?</b></summary>

1. Remove `PKextended.dll` and `faospark.pkextended.cfg` from `BepInEx/`.
2. Remove Special K (`dxgi.dll` / `d3d11.dll`) and `SK_Res/` folder — Special K is no longer required as PKCore handles all injection natively.
</details>

---

## 🤝 Credits & Acknowledgements

* **Author**: [faospark](https://github.com/faospark)
* **Texture Pack**: [Project Kyaro HD Remaster Mod](https://www.nexusmods.com/suikoden1and2hdremaster/mods/6)
* **Special Thanks**: [d3xMachina](https://github.com/d3xMachina) for [Suikoden Fix](https://github.com/d3xMachina/SuikodenFix) and speaker identification research.
