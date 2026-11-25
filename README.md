# P.K. - Core

**By [faospark](https://github.com/faospark)**

The **core DLL component** for **[Project Kyaro](https://www.nexusmods.com/suikoden1and2hdremaster/mods/6)**, providing custom texture/portrait injection, sprite smoothing & SMAA, UI/visual enhancements, Cook-Off & War Battle tools, and reverse-engineering utilities for **Suikoden I & II HD Remaster**.

> **Note**: This repository contains the source code for `PKCore.dll`. The full Project Kyaro package (including upscaled textures) is available on [Nexus Mods](https://www.nexusmods.com/suikoden1and2hdremaster/mods/6).

## Features

```text
Features General
- Retexture Framework (PNG, JPG, TGA, and compressed DDS with BC1/BC3/BC7 support)
- Comprehensive Portraits Framework
- Texture Variant Support
- YOU can create mods on top of this mod as base
- Sound Swap Feature
- SpriteAtlas Loose File Interception Framework

Toggleable Options (Change them via "{gameroot}\BepInEx\config\faospark.pkcore.cfg")
- Upscaled Smooth Sprites AKA Project Kyaro Sprites (can be toggled off)
- Disable Sprite Post-Processing (Prevents white outlines and sprite seams)
- Save Slot Party Member Portraits with Disk Thumbnail Caching (Suikoden I & II) [Updated]
- Show Battle Party Max HP (Suikoden I & II) [New]
- Show Enemy Level & HP in Battle (Suikoden I & II) [New]
- Battle Camera FOV / Zoom-Out (Suikoden I & II) [New]
- Battle Position Adjustments (Suikoden II)
- Character Battle Range Overrides (Suikoden II)
- Memory Auto-Battle (Suikoden II) [New]
- Smart After-Battle Healing (Suikoden II) [New]
- Remove 1-Time Use Limit on Certain Command Runes (Trick, Groundhog, Spider Slay, Angry Dragon) (Suikoden II) [New]
- Remove Mandatory Self-Unbalance on Certain Command Runes (Swallow, Fire Breath, Mayfly, White Tiger, Blue Drop, Twin Ring, Gozu, Trick) (Suikoden II) [New]
- Bright Shield Rune Enhancement (Great Blessing Clay Guardian DEF buff, Shining Light 2x recruit-count bonus damage, Battle Oath Anger + Awakened) (Suikoden II) [New]
- Infinite Cook-Off Match Loop & Cooldown Bypass (Suikoden II) [New]
- Live Cook-Off Score Helper & Optimal Menu Recommendations (Suikoden II) [New]
- Clive's Pursuit Quest Replay Loop (Suikoden II) [New]
- Final Boss Gauntlet Replay with Per-Boss Toggles (Suikoden II) [New]
- Epilogue Leona & Castle Minigames Restoration (Suikoden II) [New]
- Guardian Deity Repeatable Rewards & Assembled 3D Statue Fix (Suikoden II) [New]
- Save General Kiba (108 Stars / Forgiver Sign) with HQ Restoration, Custom Epilogue & L'Renouille Standalone War Unit (Suikoden II) [New]
- Live Configuration Hot-Reloading
- Colored Intros and Flashbacks
- Boosted War Battles with Apple Formation Menu Sync (Suikoden II)
- Button Controller Prompt Support (now uses native PS4, PS5, Generic, Switch, Xbox, and Custom controllers)
- Alternative Launcher (based on unused/Beta in-game assets)
- PSP Launcher (Based on PSP version title screen)
- Better Launcher BGM
- Minimal UI
- Enhanced Gallery UI
- Classic-style Save Menu UI
- Disable Dialog Portrait Mask
- Disable UITips Control Overlay [New]
- Scaled-Down Menus and Dialog Box
- Customizable Save Point Crystal Color
- Disable White Save Point Glow (reduces washed-out look of the crystal)
- Disable World Map Clouds and Map Sun Rays
- Scaled-Down Mini-World Map (Suikoden I)
- Alternative Run Animation for Tir (Project Kyaro Sprites)
- Restore Bamboo Fence at Mercenary Fortress
- Anti-Aliasing (SMAA)
- Sprite Filtering

Performance Features
- Smart Texture Memory Caching (Keeps RAM usage low)
- Resolution Scaling (Use when you are playing in lower end machines)
- Texture Manifest Cache (Only use when you are experiencing slow game boot up)
- Native DDS Texture Compression (BC1 / BC3 / BC7 for lower VRAM and fast loading)

Baked-In Enhancements
- Automatic Text Placeholder Replacement (Protagonist & HQ names auto-synced from save files)
- Active Launcher Language Detection (Auto-detects and tracks in-game language)
- Retranslated/Reworded Menus
- Additional NPC Portraits for Both Games (80+ characters now)
- Additional Dialogs especially on Flashbacks
- Soft Reset Battle Crash Fix (Suikoden II BATTLE_WORK.PreRelease NullReferenceException guard) [New]
- Revamped foliage on Magician's Island (Suikoden I)
- Removed unnecessary Mask on the Last Area on Dragon's Den (Suikoden I)
- Fixed/Closed open Windows on Baths for Both Games (with custom background support)
- Added Headquarters signages (Suikoden I)
- Fixed Backgrounds with poor baked-in Depth of Field effect (Suikoden II)
- Removed the Harmonian Flag on Matilda Castle
- Fixed Inconsistent Telescope Graphic at HQ (Suikoden II)
- Added HQ Signages and Decorations (Suikoden II)
- Replaced Low-Quality Upscaled Doors in the Inn Area (Suikoden II)
- War Room Custom Background Support (Suikoden II) [New]
- Added Portrait for [Cook-Off] Announcer Chen & Covert Mission Portraits (Suikoden II)
- Calligraphic Font Used for [Cook-Off] Results
- Suikoden II Summon Effect Texture System
- Additional fixes and enhancements

Utility
- Floating Borderless Window Mode (EnableBorderlessWindow) with In-Game Display Settings UI Sync & Fullscreen Borderless via Unity's -popupwindow launch option [Updated]
- Show Mouse Cursor (Live Runtime Toggle) [Updated]
- Clean Exit on ALT+F4
- Modder & Developer Diagnostics (Text ID logging, TextDB dumping, JSON asset overrides, Battle/Tavern/Guardian Deity diagnostics) [Updated]
- DebugMenu2 Toggle (Experimental)

Extras (from Nexus Bundle)
- Restored the Dash in the Letter "Z" via custom font, Must be activated via suikoden fix
- Alternate CRC Bypass for version 1.0.4
```

## Companion Plugins (Modularized from PKCore)

- **PKRuneSagePlus**: Remote Castle Rune Master (`Right Stick Down` / `F7`), early Sajah Village rare shop & rune sage (S2), and S1 Castle Rune Master shop expansion.
- **PKRecruitmentPatch**: Early Stars of Destiny recruitments, HQ clones, and story-independent Castle HQ upgrades (S2).
- **PKOpenPaths**: Cave of the Wind auto-solved boulders, Tinto Mines shortcuts, and early Forest Village Armor Shop door (S2).
- **PKS1CastleStorageAnywhere**: Remote Toran Castle Vault access (`Right Stick Up` / `R3` / `F6`) (S1).
- **PKMatildaGlitchRestoration**: Restores the Muse–Matilda border gate push glitch (or opens the border) with HD sprite sync (S2).
- **PKS2BathNPCPatch**: Cut bath sprite restorations, 8-character capacity, and gender-based tub separation (S2).
- **PKTenzanPassPatch**: Restores Tenzan Pass Chimera encounters & Cyclone Rune drops (S2).
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
