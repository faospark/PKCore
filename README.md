# P.K. - Core

**By [faospark](https://github.com/faospark)**

The **core DLL component** for **[Project Kyaro](https://www.nexusmods.com/suikoden1and2hdremaster/mods/6)**, providing custom texture/portrait injection, sprite smoothing & SMAA, UI/visual enhancements, Cook-Off & War Battle tools, and reverse-engineering utilities for **Suikoden I & II HD Remaster**.

> **Note**: This repository contains the source code for `PKCore.dll`. The full Project Kyaro package (including upscaled textures) is available on [Nexus Mods](https://www.nexusmods.com/suikoden1and2hdremaster/mods/6).

## Features

- **Re-Texture & Portrait Framework**: Custom texture injection (`PNG`, `JPG`, `TGA`, `DDS` BC1/BC3/BC7) with manifest/memory caching, high-resolution NPC portraits (S1 & S2), and automatic protagonist/HQ text placeholder replacement.
- **Visuals & Anti-Aliasing**: Toggleable Project Kyaro HD sprites vs. original pixel sprites, bilinear + 2x anisotropic filtering, selectable SMAA (`Off`, `Low`, `Medium`, `High`), resolution scaling (`0.5x`–`2.0x`), and sprite post-processing removal.
- **UI & Launcher Enhancements**: PSP-inspired Alternative Launcher with auto language detection and custom BGM, compact 80% dialogue/menu scaling, S1 scaled world map, save-slot party mini portraits, floating borderless window mode, customizable save point crystals, and toggles for world map clouds/sunrays, dialogue masks, `UITips`, and Tir's run animation.
- **Gameplay & Asset Restorations (S1 & S2)**: Infinite Cook-Off loop, cooldown bypass, and live Cook-Off scoring helper (S2); customizable War Battle stats/abilities via `S2WarAbilities.json` with Apple's formation menu sync (S2); colored intros/flashbacks (S2); Mercenary Fortress bamboo fence (S2); and visual fixes for HQ signage, DOF backgrounds, telescope, and inn doors.
- **Diagnostics & Dev Utilities**: Clean `Alt+F4` exit, runtime text/JSON asset dumper (`PKCore/Debug/`), and decompiled symbol/map indexer (`tools/sym.bat`).

## Companion Plugins (Modularized from PKCore)

- **PKReplayPlus**: Final Boss Gauntlet replay, Epilogue Leona & minigames restoration, Clive's Pursuit Quest replay, and Guardian Deity repeatable rewards.
- **PKBattlePatch**: Enemy Level/HP HUD, Party Max HP bar, Memory Auto-Battle, after-battle auto-heal, formation spacing, unlimited command runes, rune unbalance removal, and attack range overrides.
- **PKRuneSagePlus**: Remote Castle Rune Master (`Right Stick Down` / `F7`), early Sajah Village rare shop & rune sage (S2), and S1 Castle Rune Master shop expansion.
- **PKRecruitmentPatch**: Early Stars of Destiny recruitments, HQ clones, and story-independent Castle HQ upgrades (S2).
- **PKOpenPaths**: Cave of the Wind auto-solved boulders, Tinto Mines shortcuts, and early Forest Village Armor Shop door (S2).
- **PKS1CastleStorageAnywhere**: Remote Toran Castle Vault access (`Right Stick Up` / `R3` / `F6`) (S1).
- **PKMatildaGlitchRestoration**: Restores the Muse–Matilda border gate push glitch (or opens the border) with HD sprite sync (S2).
- **PKS2BathNPCPatch**: Cut bath sprite restorations, 8-character capacity, and gender-based tub separation (S2).
- **PKTenzanPassPatch**: Restores Tenzan Pass Chimera encounters & Cyclone Rune drops (S2).
- **PKButtonPrompts**: Global PlayStation / DualSense / Xbox / Switch / Custom button prompt overrides.
- **PKDev**: Dear ImGui telemetry HUD, live event-flag logger, Battle Lab, and crash diagnostics (requires `PKCore`).

> For custom texture setup, `-popupwindow` borderless notes, `PKextended` migration steps, and the full `Documentation/` index, see [TECHNICAL.md](TECHNICAL.md).

## Requirements

- **BepInEx 6.0.0-pre.2 IL2CPP**
- **Suikoden I & II HD Remaster** (Unity 2022.3.28f1)
- **Recommended:** [Suikoden Fix](https://github.com/d3xMachina/SuikodenFix) by d3xMachina

## Installation

1. Install [BepInEx 6.0 (Unity IL2CPP x64)](https://github.com/BepInEx/BepInEx/releases/download/v6.0.0-pre.2/BepInEx-Unity.IL2CPP-win-x64-6.0.0-pre.2.zip) into your game root directory.
2. Extract the release ZIP (or place `PKCore.dll` and its assets into `BepInEx/plugins/PKCore/`).
3. Launch the game once to generate `BepInEx/config/faospark.pkcore.cfg`.

## Credits & License

- **[faospark](https://github.com/faospark)** — Primary Author & Lead Researcher
- **[d3xMachina](https://github.com/d3xMachina/Suikoden-Fix)** — Creator of Suikoden-Fix & BepInEx IL2CPP foundation
- **[asilverthorn](https://github.com/asilverthorn/suikoden_ref)** — Reference tables, internal IDs, and save structure research
- **Mod Suite:** [Project Kyaro](https://www.nexusmods.com/suikoden1and2hdremaster/mods/6)
- **Moogles & Mods Discord** — Community support & research ([Invite](https://discord.com/invite/bSnpVBV))
- **Framework:** [BepInEx](https://github.com/BepInEx/BepInEx) & [HarmonyX](https://github.com/BepInEx/HarmonyX)

Distributed under the MIT License. See `LICENSE.txt` for details.
