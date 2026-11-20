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
| **EnableButtonPrompts** | `bool` | `true` | Enable controller button prompt overrides across the game (reabsorbed from `PKButtonPrompts`). |
| **ControllerPromptType** | `string` | `PlayStation` | Override controller button prompts across the game (`PlayStation`, `PlayStation 5`, `Xbox`, `Switch`, `Custom`, `Generic`). |

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
| **LoopCliveQuest** | `bool` | `true` | Automatically resets Clive's pursuit quest back to Lakewest upon entering Lakewest after completing the Sajah Village finale. |
| **LoopFinalBossGauntlet** | `bool` | `true` | Automatically resets enabled L'Renouille encounters upon entering `vj01` after defeating the final boss. |
| **ResetGauntletOnNextEntry** | `bool` | `false` | Forces a one-time reset of enabled L'Renouille encounters on next L'Renouille map entry (auto-resets to `false`). |
| **ReplayHighlandGuards** | `bool` | `false` | Include Highland Soldier guard ambushes and outer gate assault segments when resetting L'Renouille. |
| **ReplayHanCunningham** | `bool` | `true` | Include the General Han Cunningham 1v1 duel (`vj01`) when resetting L'Renouille. |
| **ReplayLucia** | `bool` | `true` | Include the Lucia 6v6 boss battle (`vj02`) when resetting L'Renouille. |
| **ReplaySeedAndCulgan** | `bool` | `true` | Include the Generals Seed & Culgan 6v2 boss battle (`vj07`) when resetting L'Renouille. |
| **ReplayBeastRune** | `bool` | `true` | Include the Silver Beast Rune final boss battle (`vj08`) when resetting L'Renouille. |
| **EnableLeonaPostFinalBoss** | `bool` | `true` | Restores Leona and party changing at Dunan Castle Tavern (`vk08`) during the post-final-boss epilogue. |
| **EnableCastleMinigamesPostFinalBoss** | `bool` | `true` | Restores Dunan Castle minigames (`vk18` Laundry & Gardens) during the post-final-boss epilogue. |
| **EnableRepeatStatueRewards** | `bool` | `true` | Re-arms the Guardian Deity blessing reward whenever the statue design is rebuilt or altered at Jude's workshop. |
| **AlwaysKeepStatueAssembled** | `bool` | `true` | Ensures the Guardian Deity statue maintains its assembled 3D model (`parts_no[3] = 1`). |

> [!NOTE]
> Other Suikoden II gameplay systems are modularized into companion plugins:
> - **`PKRuneSagePlus`**: Early Sajah Village rare shop & rune sage.
> - **`PKRecruitmentPatch`**: Early Stars of Destiny recruitments, HQ clones, and story-independent Castle HQ upgrades.
> - **`PKOpenPaths`**: Cave of the Wind auto-solved boulders, Tinto Mines shortcuts, and early Forest Village Armor Shop door.
> - **`PKMatildaGlitchRestoration`**: Restores the Muse–Matilda border gate push glitch (or opens the border) with HD sprite sync.
> - **`PKS2BathNPCPatch`**: Cut bath sprite restorations, 8-character capacity, and gender-based tub separation.
> - **`PKTenzanPassPatch`**: Restores Tenzan Pass Chimera encounters & Cyclone Rune drops.

---

## [06 Battle & Combat]

**Battle HUD, Combat QoL & Balance (Reabsorbed from `PKBattlePatch`)**

| Setting | Type | Default | Description |
| :--- | :---: | :---: | :--- |
| **ShowBattleMaxHP** | `bool` | `true` | Displays both current and maximum HP (e.g., `587/587`) in the battle party window (S1 & S2). |
| **ShowEnemyLevelInBattle** | `bool` | `true` | Displays enemy level in the battle target selection window (S1 & S2). |
| **ShowEnemyHpInBattle** | `bool` | `true` | Displays enemy current and maximum HP on a new line in the battle target selection window (S1 & S2). |
| **EnableMemoryAutoBattle** | `bool` | `true` | Remembers each character's last manually chosen action (Attack vs. Rune/Magic) and replays it during Auto-Battle (S2). |
| **EnableSmartHealing** | `bool` | `true` | Automatically revives fallen allies, cures Poison, and heals party wounds after battle using healing items/scrolls (S2). |
| **EnableBattlePositionAdjustments** | `bool` | `true` | Adjusts the 6 character battle positions so back-row sprites do not obscure front-row characters (S2). |
| **S2BattlePositionPreset** | `string` | `wide` | Battle formation spacing preset for Suikoden 2 (`default`, `wide`, `widest`). |
| **EnableBattleCameraZoom** | `bool` | `true` | Zooms out the battle camera for a wider field of view during combat (S1 & S2). |
| **S1BattleCameraFovPercent** | `float` | `125` | Battle camera zoom-out percentage in Suikoden 1 (`100` = vanilla `-1100.0` distance). |
| **S2BattleCameraFovPercent** | `float` | `125` | Battle camera zoom-out percentage in Suikoden 2 (`100` = vanilla `15.0` FOV / `1.2` OrthoSize). |
| **EnableUnlimitedCommandRunes** | `bool` | `true` | Removes 1-use-per-battle lockouts on character command runes (Trick, Groundhog, Spider Slay, Angry Dragon) (S2). |
| **AlwaysAvailableAngryDragon** | `bool` | `true` | Allows Oulan's Angry Dragon Rune to always be usable without requiring initial damage or losing Fury (S2). |
| **EnableRuneUnbalanceRemoval** | `bool` | `true` | Disables self-unbalance penalties on physical ability command runes (S2). |
| **EnableCharacterRangeOverrides** | `bool` | `true` | Enables custom character battle attack range overrides (S2). |
| **S2CharacterRangeOverrides** | `string` | `Kasumi:M, ...` | Comma-separated `Character:Range` (`S`/`M`/`L`) overrides for Suikoden 2 (includes `Chuchara:M`). |

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
| **LogBattlePositions** | `bool` | `false` | Log party member coordinates and battle position adjustments on battle start. |
| **LogBattleUnitWindow** | `bool` | `false` | Log the battle party window layout (HP/MP text elements, max HP visibility, slot hierarchy) once per slot per battle. |
| **EnableGuardianDeityDiagnostics** | `bool` | `false` | Enable detailed diagnostics logging for Guardian Deity state transitions and event triggers. |

> [!NOTE]
> Live event-flag telemetry (`LogEventFlagsS1` / `LogEventFlagsS2`), Dear ImGui telemetry HUD, Battle Lab, and crash diagnostics are provided by **`PKDev`** (requires `PKCore`).

---

## [zz - Experimental]

**Work In Progress**

| Setting | Type | Default | Description |
| :--- | :---: | :---: | :--- |
| **EnableDebugMenu2** | `bool` | `false` | [EXPERIMENTAL] Enable the hidden internal `DebugMenu2` developer menu object. |
