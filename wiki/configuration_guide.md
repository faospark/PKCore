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
| **DisableUITips** | `bool` | `false` | Disables the bottom-screen controller prompt and UI tip overlay bar across all scenes. |
| **ScaleDownDialogBox** | `bool` | `true` | Compact dialog box (`80%` size with adjusted positioning for improved scene visibility). |
| **ScaledDownMenu** | `string` / `bool` | `true` | Scaled-down main pause/status menu (`80%` size with adjusted positioning). |
| **PSPLauncher** | `bool` | `false` | Enable the PSP-inspired launcher interface. |
| **EnhancedGallery** | `bool` | `true` | Replaces Movies, Events, and Sounds gallery backgrounds with custom textures inspired by the PSP release. |

> [!NOTE]
> Controller button prompt glyph overrides (`Xbox`, `PlayStation`, `Switch`) are now managed by the dedicated companion plugin **`PKButtonPrompts`** (`BepInEx/config/faospark.pkbuttonprompts.cfg`).

---

## [03 General]

**General Game & Aesthetic Settings**

| Setting | Type | Default | Description |
| :--- | :---: | :---: | :--- |
| **SavePointColor** | `string` | `default` | Save point crystal orb color. Options: `black`, `blue`, `cyan`, `green`, `navy`, `pink`, `purple`, `red`, `white`, `yellow`, `default`, `random`. (`random` chooses a new color on room entry). |
| **DisableSavePointGlow** | `bool` | `true` | Disable the washed-out white glow effect on save point orbs to preserve rich crystal colors. |
| **DisableWorldMapClouds** | `bool` | `true` | Disable cloud overlay effects on the world map for Suikoden 1 and 2. |
| **DisableWorldMapSunrays** | `bool` | `true` | Disable sunray glow effects on the world map for Suikoden 1 and 2. |
| **BetterLauncherBGM** | `bool` | `true` | Enable Better Launcher BGM mod. Loads replacement audio from `PKCore/00-Mods/Better-Launcher-BGM-Mod/Sound/` to replace the ambient launcher music with Suikoden 2's adventure start theme. |

---

## [04 Game : Suikoden 1]

**Suikoden 1 Specific Options**

| Setting | Type | Default | Description |
| :--- | :---: | :---: | :--- |
| **S1ScaledDownWorldMap** | `bool` | `true` | Scale down Suikoden 1 world map UI to `80%` with adjusted positioning for better screen visibility. |
| **TirRunTexture** | `string` | `default` | Texture variant for Tir's running animation (`default`, `alt`, `pixel`). Works with Project Kyaro Sprites on or off. |
| **EnableS1QuickRuneMaster** | `bool` | `false` | Open Jeane's Castle Rune Master shop from anywhere in the field by clicking the Right Stick Down ([R3]). |
| **S1QuickRuneMasterRequireJeane** | `bool` | `true` | Require Jeane to be recruited before remote rune master access is permitted. |

---

## [05 Game : Suikoden 2]

**Suikoden 2 Specific Options**

| Setting | Type | Default | Description |
| :--- | :---: | :---: | :--- |
| **EnablePortraitSystem** | `bool` | `true` | Enable custom NPC portrait injection. Supports both Suikoden I and II. Supports PNG and DDS (BC1/BC3/BC7) in `Textures/GSD1/NPCPortraits/` and `Textures/GSD2/NPCPortraits/`. |
| **MercFortFence** | `string` | `default` | Mercenary Fortress fence texture variant (`default`, `bamboo`, etc., looks for suffix `_<value>`). |
| **ColoredIntroAndFlashbacks** | `bool` | `true` | Restores full color to Suikoden 2 intro and flashback scenes by disabling grayscale post-processing effects. |
| **EnableWarAbilityMod** | `bool` | `true` | Enable tactical war battle ability and stat customization via `PKCore/Config/S2WarAbilities.json`, live synchronized into Apple's squad formation menu at Castle HQ. |
| **LoopCookOffMatches** | `bool` | `false` | Automatically restart Hai Yo's cook-off battles from Match 1 (Antonio) after defeating Chef Jinkai, retaining all learned recipes, seasonings, and bonuses. |
| **ReduceCookOffCooldown** | `bool` | `false` | Bypasses the vanilla 30-60 minute active movement timer between cook-off challenges. |
| **LoopCliveQuest** | `bool` | `false` | Automatically re-arms Clive's pursuit quest from Lakewest upon entering Lakewest after completing the Sajah finale. |

> [!NOTE]
> Combat battle formation spacing (`wide`, `widest`), attack range overrides (`Kasumi:M, Luc:M, etc.`), live enemy Level/HP bars, memory auto-battle, and post-battle smart healing are managed by the companion plugin **`PKBattlePatch`** (`BepInEx/config/faospark.pkbattlepatch.cfg`).

---

## [Performance]

**Optimization & Engine Settings**

| Setting | Type | Default | Description |
| :--- | :---: | :---: | :--- |
| **EnableTextureManifestCache** | `bool` | `false` | Caches the texture index in `PKCore/Cache/texture_manifest.xml` to skip re-scanning folders on startup. Disable when adding/modifying textures. |
| **EnableMemoryCaching** | `bool` | `true` | Intelligent texture memory management. Clears non-persistent textures during scene transitions to free RAM while keeping persistent UI in memory. **Recommended: Keep Enabled.** |
| **ResolutionScale** | `float` | `1.0` | Resolution multiplier (`0.5` to `2.0`). `1.0` = off / native, `0.5` = half resolution for performance, `1.5`–`2.0` = super-sampling. |

---

## [Utility]

**Window, Telemetry & In-Game Tools**

| Setting | Type | Default | Description |
| :--- | :---: | :---: | :--- |
| **EnableBorderlessWindow** | `bool` | `false` | Floating borderless window mode. Strips OS title bars and window frames while remaining windowed, allowing custom resolutions without stretching across the entire desktop. |
| **ShowMouseCursor** | `bool` | `false` | Show mouse cursor over the game window. Useful for Dear ImGui overlay interaction and debugging. |

> **Fullscreen Desktop Borderless**: Set Unity's native `-popupwindow` launch parameter in Steam Properties → Launch Options.

---

## [zz - Diagnostics]

**Logging & Data Dumps**

| Setting | Type | Default | Description |
| :--- | :---: | :---: | :--- |
| **LogTextIDs** | `bool` | `false` | Log dialogue message IDs to console. Useful for identifying IDs for `DialogOverrides.json` and `SpeakerOverrides.json`. |
| **LogEventFlagsS1** | `bool` | `false` | Live telemetry logging every story flag operation (byte offset, bitmask, bit state) in Suikoden 1. |
| **LogEventFlagsS2** | `bool` | `false` | Live telemetry logging every story flag operation in Suikoden 2. |
| **DumpTextDatabase** | `bool` | `false` | Accumulates all seen text IDs and dialogue lines into `PKCore/Debug/TextDB_GSD1.json` and `TextDB_GSD2.json` at runtime. |
| **DumpJsonAssets** | `bool` | `true` | Dumps all loaded AssetBundle TextAssets and JSON files (e.g., event data, map data, scripts) to `PKCore/Debug/JsonDumps/`. |
| **EnableJsonOverrides** | `bool` | `true` | Enable loading custom JSON asset overrides from `PKCore/JsonOverrides/` to replace game AssetBundle TextAssets. |
| **DetailedLogs** | `bool` | `false` | Enable verbose logging for texture replacements and patch lifecycle events. |

---

## [zz - Experimental]

**Work In Progress**

| Setting | Type | Default | Description |
| :--- | :---: | :---: | :--- |
| **EnableDebugMenu2** | `bool` | `false` | [EXPERIMENTAL] Enable the hidden internal `DebugMenu2` developer menu object. |
