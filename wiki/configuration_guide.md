# PKCore Configuration Guide

This document outlines all available configuration options for **PKCore** located in `BepInEx/config/faospark.pkcore.cfg`, along with references for companion plugins within the Project Kyaro Suite.

---

## [01 Project Kyaro Sprites]

**Enhanced Sprite & Visual Settings**

| Setting | Type | Default | Description |
| :--- | :---: | :---: | :--- |
| **EnableProjectKyaroSprites** | `bool` | `true` | Enable Project Kyaro HD sprite textures from `PKS1` and `PKS2` folders. Set to `false` to use original pixel-based sprites. |
| **DisableSpritePostProcessing** | `bool` | `true` | Prevent post-processing (bloom, vignette, depth of field, etc.) from affecting sprites, eliminating white outlines on edges and exposed sprite seams. |
| **SpriteFilteringEnabled** | `bool` | `true` | Enable texture filtering for sprites (Bilinear + 2x Anisotropic). Set to `false` to retain the original pixelated look. |
| **SMAAQuality** | `string` | `Low` | Anti-aliasing quality for sprites (`Off`, `Low`, `Medium`, `High`). `Low` is recommended. Does not affect game UI. |

---

## [02 User Interface]

**UI & Presentation Customization**

| Setting | Type | Default | Description |
| :--- | :---: | :---: | :--- |
| **LoadLauncherUITextures** | `bool` | `true` | Load custom launcher UI textures based on unused game assets in `Textures/launcher/`. |
| **MinimalUI** | `bool` | `true` | Enable minimal UI texture variants. When `false`, custom textures with `minimal` in their path are skipped. |
| **ClassicSaveWindow** | `bool` | `true` | Restores classic PSX-style Save/Load window layout for a nostalgic presentation in both games. |
| **ShowSaveSlotPartyPortraits** | `bool` | `true` | Displays mini party member portraits next to character levels (`Txt_Lv`) in save/load slots for both Suikoden I and Suikoden II with 0ms in-memory caching. |
| **DisablePortraitDialogMask** | `bool` | `false` | Disable the `Face_Mask_01` texture overlay on character portraits in dialog windows. Supports custom DDS/PNG masks. |
| **ScaleDownDialogBox** | `bool` | `true` | Compact dialog box (`80%` size with adjusted positioning for improved scene visibility). |
| **ScaledDownMenu** | `string` | `true` | Scaled-down main pause/status menu (`80%` size with adjusted positioning). |
| **PSPLauncher** | `bool` | `false` | Enable the PSP-inspired alternative launcher interface with auto language detection. |
| **EnhancedGallery** | `bool` | `true` | Replaces Movies, Events, and Sounds gallery backgrounds with custom textures inspired by the PSP release. |
| **DisableUITips** | `bool` | `false` | Disables the `UITips` bottom-screen controller prompt and UI tip overlay bar. |

> [!NOTE]
> Controller button prompt glyph overrides (`PlayStation`, `DualSense`, `Xbox`, `Switch`, `Custom`) are managed by the dedicated companion plugin **`PKButtonPrompts`** (`BepInEx/config/faospark.pkbuttonprompts.cfg`).

---

## [03 General]

**General Game & Aesthetic Settings**

| Setting | Type | Default | Description |
| :--- | :---: | :---: | :--- |
| **SavePointColor** | `string` | `default` | Save point crystal orb color. Options: `black`, `blue`, `cyan`, `green`, `navy`, `pink`, `purple`, `red`, `white`, `yellow`, `default`, `random` (`random` chooses a new color on room entry). Some hardcoded save points do not change. |
| **DisableSavePointGlow** | `bool` | `true` | Disable the washed-out white glow effect on save point orbs to preserve rich crystal colors. |
| **DisableWorldMapClouds** | `bool` | `true` | Disable cloud overlay effects on the world map for Suikoden 1 and 2. |
| **DisableWorldMapSunrays** | `bool` | `true` | Disable sunray glow effects on the world map for Suikoden 1 and 2. |
| **BetterLauncherBGM** | `bool` | `true` | Enable Better Launcher BGM mod. Loads replacement audio from `PKCore/00-Mods/Better-Launcher-BGM-Mod/Sound/` to replace the ambient launcher music with Suikoden 2's adventure start theme. |

---

## [04 Game : Suikoden 1]

**Suikoden 1 Specific Options**

| Setting | Type | Default | Description |
| :--- | :---: | :---: | :--- |
| **S1ScaledDownWorldMap** | `bool` | `true` | Scale down Suikoden 1 world map UI (`smap`) to `80%` with adjusted positioning for better screen visibility. |
| **TirRunTexture** | `string` | `default` | Texture variant for Tir's running animation (`default`, `alt`, `pixel`). `alt` looks for `..._alt.png` (Smooth); `pixel` looks for `..._pixel.png` (Pixel). Works with Project Kyaro Sprites on or off. |

> [!NOTE]
> Remote Toran Castle Rune Master access (`Right Stick Down` / `F7`) and Rune Shop expansion are managed by **`PKRuneSagePlus`**. Remote Toran Castle Vault storage access (`Right Stick Up` / `R3` / `F6`) is managed by **`PKS1CastleStorageAnywhere`**.

---

## [05 Game : Suikoden 2]

**Suikoden 2 Specific Options**

| Setting | Type | Default | Description |
| :--- | :---: | :---: | :--- |
| **EnablePortraitSystem** | `bool` | `true` | Enable custom NPC portrait injection. Supports both Suikoden I and II. Supports PNG and DDS (BC1/BC3/BC7) in `Textures/NPCPortraits/`, `Textures/GSD1/NPCPortraits/`, and `Textures/GSD2/NPCPortraits/`. |
| **MercFortFence** | `string` | `default` | Mercenary Fortress fence texture variant (e.g., `default`, `bamboo`, `green`, `custom`; looks for suffix `_<value>`). |
| **ColoredIntroAndFlashbacks** | `bool` | `true` | Restores full color to Suikoden 2 intro and flashback scenes by disabling `CustomPostEffect` grayscale post-processing. |
| **EnableWarAbilityMod** | `bool` | `true` | Enable tactical war battle ability and stat customization via `PKCore/Config/S2WarAbilities.json`, live synchronized into Apple's squad formation menu at Castle HQ. |
| **LoopCookOffMatches** | `bool` | `true` | Automatically restart Hai Yo's cook-off battles from Match 1 (Chef Antonio) after defeating Chef Jinkai and viewing the garden celebration, retaining all learned recipes and seasonings. |
| **ReduceCookOffCooldown** | `bool` | `true` | Bypasses the vanilla 30–60 minute active movement timer between cook-off challenges. |
| **ShowCookOffScoreHelper** | `bool` | `true` | Displays real-time scoring predictions and optimal menu recommendations on screen during Suikoden 2 cook-off minigame battles. |

> [!NOTE]
> Other Suikoden II gameplay systems are modularized into companion plugins:
> - **`PKReplayPlus`**: Final Boss Gauntlet replay, Epilogue Leona & minigames restoration, Clive's Pursuit Quest replay, and Guardian Deity repeatable rewards.
> - **`PKBattlePatch`**: Enemy Level/HP HUD, Party Max HP bar, Memory Auto-Battle, post-battle smart healing, formation spacing (`wide`, `widest`), weapon range overrides, and rune enhancements.
> - **`PKRuneSagePlus`**: Early Sajah Village rare shop & rune sage.
> - **`PKRecruitmentPatch`**: Early Stars of Destiny recruitments, HQ clones, and story-independent Castle HQ upgrades.
> - **`PKOpenPaths`**: Cave of the Wind auto-solved boulders, Tinto Mines shortcuts, and early Forest Village Armor Shop door.
> - **`PKMatildaGlitchRestoration`**: Restores the Muse–Matilda border gate push glitch (or opens the border) with HD sprite sync.
> - **`PKS2BathNPCPatch`**: Cut bath sprite restorations, 8-character capacity, and gender-based tub separation.
> - **`PKTenzanPassPatch`**: Restores Tenzan Pass Chimera encounters & Cyclone Rune drops.

---

## [Performance]

**Optimization & Engine Settings**

| Setting | Type | Default | Description |
| :--- | :---: | :---: | :--- |
| **EnableTextureManifestCache** | `bool` | `false` | Caches the texture index in `PKCore/Cache/texture_manifest.xml` to skip re-scanning folders on startup. Disable when actively adding/removing textures. |
| **EnableMemoryCaching** | `bool` | `true` | Intelligent texture memory management. Clears non-persistent textures during scene transitions to free RAM while keeping persistent UI in memory. **Recommended: Keep Enabled.** |
| **ResolutionScale** | `float` | `1.0` | Resolution multiplier (`0.5` to `2.0`). `1.0` = off / native, `0.5` = half resolution for performance, `1.5`–`2.0` = super-sampling. Do not use alongside Suikoden Fix's resolution changer. |

---

## [Utilty]

**Window & Cursor Options** *(section header `[Utilty]` in `faospark.pkcore.cfg`)*

| Setting | Type | Default | Description |
| :--- | :---: | :---: | :--- |
| **ShowMouseCursor** | `bool` | `false` | Show mouse cursor when hovering over the game window. Useful for debugging with Unity Explorer or accessing overlays. |
| **EnableBorderlessWindow** | `bool` | `false` | Floating borderless window mode. Strips OS title bars and window frames while remaining windowed, allowing custom smaller resolutions without stretching across the desktop. |

> **Fullscreen Desktop Borderless**: Set Unity's native `-popupwindow` launch parameter in Steam Properties → Launch Options.

---

## [zz - Diagnostics]

**Logging, Data Dumps & Asset Overrides**

| Setting | Type | Default | Description |
| :--- | :---: | :---: | :--- |
| **LogTextIDs** | `bool` | `false` | Log dialogue message IDs to console. Useful for identifying IDs for `DialogOverrides.json` and `SpeakerOverrides.json`. |
| **DumpTextDatabase** | `bool` | `false` | Accumulates all seen text IDs and dialogue lines into `PKCore/Debug/TextDB_GSD1.json` and `TextDB_GSD2.json` at runtime. |
| **DumpJsonAssets** | `bool` | `true` | Dumps all loaded AssetBundle `TextAsset` and JSON files (e.g., `vd01.json`, event data, map data) to `PKCore/Debug/JsonDumps/`. |
| **EnableJsonOverrides** | `bool` | `true` | Enable loading custom JSON asset overrides from `PKCore/JsonOverrides/` to replace game AssetBundle `TextAsset`s. |
| **DetailedLogs** | `bool` | `false` | Enable verbose logging for texture replacements and patch lifecycle events. |
| **LogReplaceableTextures** | `bool` | `false` | Log all replaceable texture names discovered during gameplay. Independent of `DetailedLogs`. |
| **EnableTavernDiagnostics** | `bool` | `false` | Enable forensic diagnostic logging for Dunan Castle Tavern (`vk08`) event flags, flag checks, dialogue, and party-change triggers. |

> [!NOTE]
> Live event-flag telemetry (`LogEventFlagsS1` / `LogEventFlagsS2`), Dear ImGui telemetry HUD, Battle Lab, and crash diagnostics are provided by **`PKDev`** (requires `PKCore`).

---

## [zz - Experimental]

**Work In Progress**

| Setting | Type | Default | Description |
| :--- | :---: | :---: | :--- |
| **EnableDebugMenu2** | `bool` | `false` | [EXPERIMENTAL] Enable the hidden internal `DebugMenu2` developer menu object. |
