# Welcome to the PKCore Wiki ⚔️

[![Framework: BepInEx 6 IL2CPP](https://img.shields.io/badge/Framework-BepInEx_6_IL2CPP-6B46C1.svg)](https://github.com/faospark/PKCore)
[![Game: Suikoden I & II HD Remaster](https://img.shields.io/badge/Game-Suikoden_I_%26_II_HD_Remaster-0078D7.svg)](https://store.steampowered.com/app/1932640/)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://opensource.org/licenses/MIT)
[![Nexus Mods](https://img.shields.io/badge/Download-Nexus_Mods-DA6A00.svg)](https://www.nexusmods.com/suikoden1and2hdremaster/mods/6)

> **PKCore (Project Kyaro Core)** is the core DLL component and foundational modding framework for **[Project Kyaro](https://www.nexusmods.com/suikoden1and2hdremaster/mods/6)** on **Suikoden I & II HD Remaster**. It provides custom texture injection (`PNG`, `JPG`, `TGA`, `DDS` BC1/BC3/BC7), CriWare sound swapping (`ACB`/`AWB` redirection), dynamic dialogue and NPC portrait frameworks (with expression variants across both games), save slot party member mini portraits, PSP-inspired launcher & UI presets, data-driven Suikoden II war battle rebalancing, Cook-Off loop/cooldown/live score helper, floating borderless window mode, and reverse-engineering utilities.
>
> Specialized gameplay overhauls (such as quest/boss replays, combat HUDs, battle formation spacing, attack range overrides, early recruitments, vendor expansions, bathhouse overhauls, and controller button prompt overrides) are modularized into dedicated companion plugins within the **Project Kyaro Suite**.

---

## 🧭 Navigation Portal

<div align="center">

| 🚀 [Getting Started](#-getting-started) | ⚙️ [Configuration Guide](configuration_guide) | 🎨 [Texture Modding](custom_textures_guide) |
| :--- | :--- | :--- |
| • Requirements<br>• Installation<br>• Directory Layout | • Settings Reference<br>• Visual & UI Toggles<br>• Diagnostics & Tools | • Formats (PNG, DDS BC7)<br>• Priority Hierarchy<br>• Manifest Caching |

| 🎭 [NPC & Dialogue Portraits](walkthrough_npc_portraits) | 🔊 [Sound Swapping](sound_modding_guide) | ⚔️ [War Battles](war_battle_modding) |
| :--- | :--- | :--- |
| • Speaker ID Mapping<br>• Expression Variants<br>• S1 & S2 Integration | • ACB / AWB Audio Banks<br>• Music & SFX Redirection<br>• Better Launcher BGM | • JSON Ability Overrides<br>• 14 Canonical Battles<br>• Matilda Refugee Battle |

| 📦 [00-Mods Guide](00-mods_guide) | 🖼️ [Save Slot Party Portraits](#-save-slot-party-member-portraits) | 🧩 [Companion Plugins Suite](#-the-project-kyaro-companion-plugins-suite) |
| :--- | :--- | :--- |
| • Mod Packaging<br>• Isolated Folders<br>• Conflict Resolution | • In-Memory Portrait Cache<br>• S1 & S2 Save/Load UI<br>• Zero-Lag Lookups | • PKReplayPlus / PKBattlePatch<br>• PKRuneSagePlus / PKRecruitmentPatch<br>• PKButtonPrompts / PKDev & more |

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
│  & Texture Engine│     │ Overrides & Audio│         │ & Save Portraits │      │ Cook-Off Systems │
│ (BC1 / BC3 / BC7)│     │ (Top-Priority)   │         │ (S1 & S2 Support)│      │ (S2 Gameplay)    │
└──────────────────┘     └──────────────────┘         └──────────────────┘      └──────────────────┘
```

* **⚡ Zero-Lag Manifest Caching**: Scans thousands of texture replacements and caches indices in XML (`texture_manifest.xml`) — boot times drop from seconds to milliseconds.
* **🚀 Native GPU DDS Acceleration**: Direct in-place memory replacement using `BC1`, `BC3`, and high-fidelity `BC7` textures (with DX10 header support).
* **🖼️ Save Slot Party Member Portraits**: Automatically renders high-resolution mini party portraits in save/load slots for both Suikoden I and II with instant 0ms cached lookups.
* **🎭 Dynamic NPC & Dialogue Portrait Framework**: Inject high-res dialogue portraits for any NPC or character with multi-language, emotion variant (`smile`, `angry`, `sad`, `shock`, `hurt`), and cutscene fallback support across both games, plus automatic protagonist/HQ text placeholder replacement.
* **🛡️ Data-Driven War Battles**: Deep rebalancing of Suikoden II Tactical War Battles via `S2WarAbilities.json`, synchronized live into Apple's squad formation menu at Castle HQ.
* **🍲 Cook-Off Suite (S2)**: Infinite Cook-Off loop (`LoopCookOffMatches`) restarting from Chef Antonio after defeating Jinkai while preserving all recipes/seasonings, instant cooldown bypass (`ReduceCookOffCooldown`), and an on-screen **Live Cook-Off Score Helper** (`ShowCookOffScoreHelper`) with real-time judge taste scoring and optimal course recommendations.
* **🔊 CriWare Sound Swapping**: Drop-in `.acb`/`.awb` sound and music redirection without modifying game archives, including `BetterLauncherBGM`.
* **🎮 Visuals, UI & Immersion Customization**: Toggleable Project Kyaro HD sprites vs. original pixel sprites, bilinear + 2x anisotropic filtering, selectable SMAA (`Off`, `Low`, `Medium`, `High`), `ResolutionScale` (`0.5x`–`2.0x`), PSP-inspired Alternative Launcher with auto language detection, compact 80% dialogue/menu scaling, S1 scaled world map, customizable Save Point Crystal colors, colored S2 intros/flashbacks, Mercenary Fortress fence variants, Enhanced Gallery backgrounds, and classic PSX save windows.
* **🖥️ Floating Borderless Window Mode**: Strips Win32 title bars and borders while remaining in windowed mode, enabling custom smaller resolutions in clean borderless windows without desktop stretching.
* **📊 Diagnostics & Reverse-Engineering Utilities**: Clean `Alt+F4` exit, runtime text/JSON asset dumpers (`PKCore/Debug/`), JSON TextAsset overrides (`PKCore/JsonOverrides/`), and high-speed decompiled symbol/map indexer (`tools/sym.bat`).

---

## 🧩 The Project Kyaro Companion Plugins Suite

To keep PKCore focused as the foundational core engine, specialized gameplay and developer systems are modularized into dedicated companion plugins:

* **PKReplayPlus**: Final Boss Gauntlet replay, Epilogue Leona & minigames restoration, Clive's Pursuit Quest replay, and Guardian Deity repeatable rewards.
* **PKBattlePatch**: Enemy Level/HP HUD, Party Max HP bar, Memory Auto-Battle, after-battle auto-heal, formation spacing (`wide`, `widest`), unlimited command runes, rune unbalance removal, and attack range overrides.
* **PKRuneSagePlus**: Remote Castle Rune Master (`Right Stick Down` / `F7`), early Sajah Village rare shop & rune sage (S2), and S1 Castle Rune Master shop expansion.
* **PKRecruitmentPatch**: Early Stars of Destiny recruitments, HQ clones, and story-independent Castle HQ upgrades (S2).
* **PKOpenPaths**: Cave of the Wind auto-solved boulders, Tinto Mines shortcuts, and early Forest Village Armor Shop door (S2).
* **PKS1CastleStorageAnywhere**: Remote Toran Castle Vault access (`Right Stick Up` / `R3` / `F6`) (S1).
* **PKMatildaGlitchRestoration**: Restores the Muse–Matilda border gate push glitch (or opens the border) with HD sprite sync (S2).
* **PKS2BathNPCPatch**: Cut bath sprite restorations, 8-character capacity, and canonical gender-based tub separation (S2).
* **PKTenzanPassPatch**: Restores omitted Tenzan Pass Chimera encounters & Cyclone Rune drops with crash-prevention bounds checks (S2).
* **PKButtonPrompts**: Global PlayStation / DualSense / Xbox / Switch / Custom button prompt overrides.
* **PKDev**: Dear ImGui telemetry HUD, live event-flag logger (`LogEventFlagsS1` / `LogEventFlagsS2`), Battle Lab, and crash diagnostics (requires `PKCore`).

---

## 🚀 Getting Started

### Requirements
* **Game**: Suikoden I & II HD Remaster (Steam or Epic Games, Unity 2022.3.28f1)
* **Mod Loader**: [BepInEx 6.0.0-pre.2 (IL2CPP 64-bit)](https://github.com/BepInEx/BepInEx/releases/download/v6.0.0-pre.2/BepInEx-Unity.IL2CPP-win-x64-6.0.0-pre.2.zip)
* **Recommended Companion**: [Suikoden Fix](https://github.com/d3xMachina/SuikodenFix) by d3xMachina

### Quick Installation

1. Install **BepInEx 6.0.0-pre.2 IL2CPP** into your game root folder.
2. Download the latest **[Project Kyaro / PKCore](https://www.nexusmods.com/suikoden1and2hdremaster/mods/6)** release.
3. Place `PKCore.dll` and its assets in `BepInEx/plugins/PKCore/`, and place any mod overrides in `PKCore/Textures/`, `PKCore/Sound/`, or `PKCore/00-Mods/`.
4. Install any desired companion plugins (such as `PKReplayPlus.dll`, `PKBattlePatch.dll`, `PKButtonPrompts.dll`) into `BepInEx/plugins/`.
5. Launch the game once to auto-generate configuration files at `BepInEx/config/`.

### Directory Layout

```
<Game Directory>/
├── BepInEx/
│   ├── config/
│   │   ├── faospark.pkcore.cfg         <-- Primary PKCore configuration
│   │   ├── faospark.pkbattlepatch.cfg  <-- Battle patch configuration (optional)
│   │   └── faospark.pkbuttonprompts.cfg<-- Button prompt configuration (optional)
│   └── plugins/
│       ├── PKCore/
│       │   └── PKCore.dll              <-- Core engine plugin
│       └── PKBattlePatch/              <-- Companion combat plugin (optional)
│           └── PKBattlePatch.dll
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

All options for PKCore are configurable in `BepInEx/config/faospark.pkcore.cfg` (see the full [Configuration Reference](configuration_guide)):

### 🎨 Visual & Sprites
* `EnableProjectKyaroSprites` (`true`/`false`): Toggle Project Kyaro HD upscaled sprites.
* `DisableSpritePostProcessing` (`true`/`false`): Strips bloom/vignette from sprites to eliminate bright border seams.
* `SpriteFilteringEnabled` (`true`/`false`): Bilinear + 2x Anisotropic filtering for smooth rendering.
* `SMAAQuality` (`Off`, `Low`, `Medium`, `High`): Anti-aliasing quality level for sprites.
* `ResolutionScale` (`0.5`–`2.0`): Resolution scale multiplier (`1.0` = native).

### 🖥️ User Interface & Presentation
* `MinimalUI` (`true`/`false`): Enable minimal UI texture variants.
* `ScaleDownDialogBox` (`true`/`false`): Compact dialogue box (80% size) for improved scene visibility.
* `ScaledDownMenu` (`"true"`/`"false"`): Scaled-down main pause/status menu.
* `ClassicSaveWindow` (`true`/`false`): Restores the classic PSX-style save slot interface in both games.
* `ShowSaveSlotPartyPortraits` (`true`/`false`): Displays mini party member portraits in save/load slots.
* `DisablePortraitDialogMask` (`true`/`false`): Removes the dark vignette gradient overlay from dialogue portraits.
* `DisableUITips` (`true`/`false`): Disables the bottom-screen controller tip overlay bar.
* `EnhancedGallery` (`true`/`false`): Replaces Movies, Events, and Sounds gallery backgrounds with custom textures inspired by the PSP release.
* `PSPLauncher` (`true`/`false`): Enable the PSP-inspired launcher interface.
* `S1ScaledDownWorldMap` (`true`/`false`): Scales down the Suikoden 1 world map UI to 80%.

### 🌟 Aesthetics & Gameplay Toggles
* `SavePointColor` (`default`, `blue`, `green`, `red`, `purple`, `yellow`, `cyan`, `random`, etc.): Customizes the crystal save orb.
* `DisableSavePointGlow` (`true`/`false`): Removes the washed-out white glare from save points.
* `DisableWorldMapClouds` / `DisableWorldMapSunrays` (`true`/`false`): Cleans up the world map visuals.
* `TirRunTexture` (`default`, `alt`, `pixel`): Texture variant for Tir's running animation (S1).
* `MercFortFence` (`default`, `bamboo`, etc.): Mercenary Fortress fence texture variant (S2).
* `ColoredIntroAndFlashbacks` (`true`/`false`): Restores vibrant colors to S2 intro/flashback sequences.
* `BetterLauncherBGM` (`true`/`false`): Replaces launcher ambient music with Suikoden 2's adventure start theme.
* `LoopCookOffMatches` (`true`/`false`): Restarts cook-off battles from Antonio after defeating Jinkai with all recipes preserved.
* `ReduceCookOffCooldown` (`true`/`false`): Bypasses the 30–60 minute wait between cook-off matches.
* `ShowCookOffScoreHelper` (`true`/`false`): Displays live judge taste scoring and optimal course recommendations during Cook-Off battles.
* `EnableWarAbilityMod` (`true`/`false`): Tactical war battle ability customization via `S2WarAbilities.json`.

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
| 🏹 [**Character Battle Ranges & Formations**](suikoden_2_character_battle_ranges) | Modifying character weapon ranges (S/M/L) and adjusting battle formation spacing (powered by `PKBattlePatch`). |
| ⚔️ [**War Battle Modding Guide**](war_battle_modding) | Customizing Suikoden II tactical units, leader bonuses, special skills, and 14 canonical battles. |
| 🔊 [**Sound Swapping Guide**](sound_modding_guide) | CriWare ACB/AWB audio swapping and custom BGM/SFX redirection. |
| ⚡ [**Caching & Performance**](caching_mechanism) | Deep dive into the XML manifest cache, scene unloader, and smart memory. |
| 📝 [**Placeholder Text System**](place_holder_text) | Dynamic replacement of protagonist and castle names in dialogue. |
| 🗺️ [**Map IDs & Areas Reference**](suikoden_2_map_ids_and_areas_breakdown) | Exhaustive breakdown of Suikoden II map IDs (`va01`–`vk37`), story chapters, and areas. |
| ⚙️ [**Configuration Reference**](configuration_guide) | Full variable list and default value reference table. |

---

## 🛠️ Troubleshooting & FAQ

<details>
<summary><b>Q: My custom texture is not showing up in-game.</b></summary>

1. Verify that your file is named to match the Unity texture name or hash pattern.
2. Enable `DetailedLogs = true` in `faospark.pkcore.cfg` to verify exact runtime names in the console/log.
3. If you added new files with manifest caching enabled, delete `PKCore/Cache/texture_manifest.xml` to force a re-index.
</details>

<details>
<summary><b>Q: How do I run borderless fullscreen or windowed borderless?</b></summary>

* **Floating Windowed Borderless (Smaller/Custom Resolutions)**: Set `EnableBorderlessWindow = true` in `faospark.pkcore.cfg`.
* **Fullscreen Desktop Borderless**: Use Unity's native `-popupwindow` launch parameter:
  * **Steam**: Right-click Game → Properties → General → Launch Options → add `-popupwindow`
  * **Epic Games**: Add `-popupwindow` to your desktop shortcut target.
</details>

<details>
<summary><b>Q: Where did battle formations, Clive's quest replay, remote Rune Master, or event flag logging go?</b></summary>

Those systems were modularized out of `PKCore` into dedicated companion plugins so `PKCore` stays focused on the core engine and asset frameworks:
* **Battle formations, range overrides & HP bars** → `PKBattlePatch`
* **Clive's Quest replay, Final Boss replay, Epilogue Leona & Guardian Deity** → `PKReplayPlus`
* **Remote Castle Rune Master (S1) & Sajah Village rare shop (S2)** → `PKRuneSagePlus`
* **Live Event Flag Logger & ImGui Telemetry HUD** → `PKDev`
</details>

---

## 🤝 Credits & Acknowledgements

* **Author**: [faospark](https://github.com/faospark)
* **Texture Pack**: [Project Kyaro HD Remaster Mod](https://www.nexusmods.com/suikoden1and2hdremaster/mods/6)
* **Special Thanks**: [d3xMachina](https://github.com/d3xMachina) for [Suikoden Fix](https://github.com/d3xMachina/SuikodenFix) and speaker identification research, and [asilverthorn](https://github.com/asilverthorn/suikoden_ref) for reference tables and internal IDs.
