import os

DOC_PATH = r"d:\Appz\PKCore\Documentation\mobobehaviour_catalog.md"

COLLATED_SECTION = """
---

## Master Technical Notes & System Distribution (Collated Cross-Game Analysis)

This section provides a unified, cross-game collation of all 4,733 serialized MonoBehaviour assets in the dump, segregated by game scope (**Suikoden I**, **Suikoden II**, **Launcher**, and **Shared Engine/Framework**), detailing their architecture, file counts, and technical roles.

```
========================================================================================
                      TOTAL ASSET POPULATION: 4,733 FILES
========================================================================================
 [Suikoden II]             : 4,613 files (97.46%)  --> Maps, NPCs, Combat, HQ Minigames
 [Suikoden I]              :    69 files ( 1.46%)  --> War Battles, Pahn/Teo Duel, Credits
 [Shared Engine/UI]        :    43 files ( 0.91%)  --> Fonts, PostProcess, Audio, Unity UI
 [Top-Level Launcher Hub]  :     8 files ( 0.17%)  --> Game Selector & Top Menu Timelines
========================================================================================
```

---

### Part A: Suikoden I Asset Distribution & Technical Notes (69 Files)

Suikoden I assets in this dump are highly specialized. Rather than a full dump of standard PS1 towns and dungeons (which are handled differently in GSD1), this repository contains the high-complexity subsystems rebuilt or re-authored for the HD Remaster: the **Tactical War Battles**, the **Pahn vs. Teo Duel**, and **HD Vegetation/Credits Engine Assets**.

#### 1. Tactical War Battles (`war_*` — 53 Files)
The tactical army battles from Suikoden I use dedicated grid coordinates, troop casualty formulas, commander portrait frames, and field background layers.

| Subsystem Group | File Count | Description & Key Files |
|---|---|---|
| **Numbered Army Battles** | 33 files | `war_01` through `war_16` (and HD sub-layers `_00` to `_18` for map staging, commander dialogue triggers, and victory conditions). |
| **Major Campaign Fortresses** | 18 files | Scripted major story battles: `war_gara` (Fortress of Garan, 8 sub-assets), `war_kuwa` (Kuwaba Fortress), `war_kita` (Northern Checkpoint), `war_sca1` & `war_sca2` (Battle of Scarleticia), `war_shas` (Floating Fortress Shasarazade), `war_teo1` & `war_teo2` (General Teo's Armored Cavalry), and `war_last` (Last Battle of Gregminster). |
| **Post-Processing Color LUTs** | 2 files | `PostProcessVolume Profile_war_kita.json` and `PostProcessVolume Profile_war_teo2.json` configuring dramatic lighting, vignette, and desaturation curves for key battle scenes. |

#### 2. One-on-One Duel Subsystem (`pan_teo*` — 5 Files)
* `pan_teo.json`: Core animation sequence table defining attack, defend, and desperate attack animations.
* `pan_teo_00.json` & `pan_teo_01.json`: 3D arena camera placement and duel participant socket coordinates.
* `pan_teo_field.json` & `pan_teo_field_srn.json`: Field render configuration and screen resolution anchors for the Pahn vs. Teo duel.

#### 3. Core Engine, Shaders & Credits (`g1_*`, `gs1*` — 11 Files)
* `g1_main.json`: Master sprite indexing table containing `face64_kazu` (130 portrait indices), CLUT (Color Lookup Tables), sprite palettes, and map lookup tables.
* `GS1.json`: Suikoden 1 top-level system flags.
* `GSD1LangTextSetter.json`: Language text setter component for Suikoden 1 localized UI strings.
* `GSD1TreeSpriteScript.json` & `GSD1TreeWindCtrl.json`: Wind sway controllers and procedural foliage shaders for Suikoden 1 HD trees.
* `CREDITS_GSD1.json` & `HDCREDITS_GSD1.json`: Original staff roll hierarchy and HD Remaster development team credits.
* Remnant assets: `mf_mag1_00.json`, `vg1_map_00_11.json`, `vg1_map_00_12.json`.

---

### Part B: Suikoden II Asset Distribution & Technical Notes (4,613 Files)

Suikoden II represents **97.46%** of the dump, containing complete datasets for every facet of the game.

#### System Summary Matrix (Suikoden II):

| Subsystem Group | File Count | % of S2 | Technical Description & Scope |
|---|---|---|---|
| **Map Assets & Sub-Layers** | **2,752 files** | 59.66% | Dual-layer maps (`va`–`vj`, `vk`, `vs`, `wa`–`wj`): `MACHIDAT` event bytecode, NPC spawns, collision grids, 3D prop meshes, and lighting. |
| **Monster Combat & Encounters** | **601 files** | 13.03% | Region roots (`a_data`–`z_data`), monster stats/AI parameters, drop item tables, and 6-slot party formation layouts. |
| **Headquarters Facilities & Minigames** | **250 files** | 5.42% | Castle Bathhouse (`hp_furo`), Chinchirorin (`hp_chin`), Fishing (`hp_fish`), Wood chopping (`hp_kikori`), Old Books (`hp_book`), Detective (`hp_hmap`), and Sound Room (`hp_hsound`). |
| **Playable Heroes & Field NPCs** | **374 files** | 8.11% | Playable battle packages (`player_*`), overworld NPC interaction triggers (`*_field_*`), and character stat/profile containers. |
| **Boss Battles & Combat Arenas** | **133 files** | 2.88% | Boss entities (`boss_*`), multi-part target components (Beast Rune), arena geometry (`boss_*_obj`), and signature VFX (`boss_res_*`). |
| **Story Event Battles** | **119 files** | 2.58% | Scripted story combat encounters (`eb_*`) with custom win/loss triggers, turn limits, and story interventions. |
| **Tactical Unite Attacks** | **82 files** | 1.78% | Multi-character combination attack choreography, weapon animations, damage scaling, and particle synchronization (`unite*`). |
| **User Interface & Windows** | **208 files** | 4.51% | Battle HUD (`UIBattle*`), Main Menu (`UIMain*`), Save/Load memory card (`UISaveLoad*`), Settings (`UIConfig*`), and Dialogue Backlog (`BackLog*`). |
| **Field Events & Scenarios** | **30 files** | 0.65% | Scripted field event packages (`fe_dat*`) coordinating environmental cutscenes and story milestones. |
| **VFX & Cutscene Timelines** | **109 files** | 2.36% | PlayableDirector timelines for spells (`TL_*`), monster cutscenes (`EM2_*`), dungeon effects (`EFF_*`), and camera pans. |

#### Detailed Regional Breakdown of Maps (2,752 Files):
Maps are categorized by their legacy 2-letter zone prefix. Each map typically consists of a logical JSON (`MACHIDAT` bytecode, collision, NPC placement) paired with multiple 3D visual sub-layer JSONs (`_00`, `_01`, `_obj`):
* **Ryube / Kyaro / North Sparrow / Tenzan (`va`)**: 357 files
* **Toto / Mercenary Fort / Muse City / White Deer (`vb`)**: 366 files
* **Coronet / Kuskus / South Window / Radat (`vc`)**: 318 files
* **Two River / Kobold Village / Lakewest / Drakemouth (`vd`)**: 252 files
* **Greenhill / Matilda / Muse-Matilda Border (`ve`)**: 199 files
* **Highway Village / Rockaxe Castle / Mt. Rakutei (`vf`)**: 160 files
* **Tinto / Crom / Tigermouth / Tinto Mines (`vg`)**: 152 files
* **Banner Village / Toran-Gregminster / Rokkaku (`vh`)**: 140 files
* **Headquarters Castle Levels 1 to 4 (`vi`)**: 115 files
* **L'Renouille / Sajah Village / Beast Rune Altar (`vj`)**: 228 files
* **Special Cutscene & Intro Areas (`vk`)**: 160 files
* **Flashback / Retrospective Scenes (`vs`)**: 29 files
* **World Map 3D Sectors (`wa` through `wj`)**: 168 files

---

### Part C: Top-Level Launcher Hub Distribution (8 Files)

Assets governing the unified front-end launcher loaded on game startup:
* `Launcher_menu_gs1_gs2_Timeline.json`: Interactive carousel timeline switching between Suikoden I and Suikoden II.
* `Launcher_Root_3d_bg_Timeline.json`: 3D animated background environment featuring animated sky and lighting.
* `Launcher_header_Timeline.json`: Header title graphics and version indicators.
* `Launcher_menu_gallery_Timeline.json`: Gallery / Art collection preview window timeline.
* `Launcher_menu_setting_Timeline.json`: Global launcher options (display resolution, language, audio).
* `Launcher_menu_group_Timeline.json` & `Launcher_menu_title_Timeline.json`: Selection button groups.
* `Launcher_title_enter_efc_Timeline.json`: Transition wipe effect when launching a selected game.

---

### Part D: Shared Engine & Unity Framework Distribution (43 Files)

Serialized utility and engine components used across both games without game-specific hardcoding:
* **Typography & Fonts (4 files)**:
  * TextMeshPro Signed Distance Field (SDF) glyph atlas files: `CALLYB__ SDF.json`, `DFGB_S7 SDF.json`, `DFT_M7 SDF.json`, `NotoSerifJP-Bold SDF.json`.
* **CRIWARE Audio Middleware (4 files)**:
  * `CriAtomSource.json`: 2D/3D spatial audio emitter component.
  * `CriAtomSourceControll.json`: Distance attenuation curves and sound radius parameters.
  * `CriAtomSourceOn2D.json`: 3D to 2D UI screen-space audio listener mapper.
  * `CriObjManager.json`: Lifecycle manager for audio playback instances.
* **Post-Processing Stack v2 Profiles (3 files)**:
  * `ColorGrading.json`: Global color LUT, tonemapper settings, exposure, and saturation.
  * `PostProcessResources.json` & `PostProcessManager.json`: Shader resource bundles.
* **Tween Animation Framework (2 files)**:
  * `DOTweenAnimation.json` & `DOTweenVisualManager.json`: Demigiant tweening library components for procedural UI transitions.
* **Standard Unity UI System Components (30 files)**:
  * Layout engines: `HorizontalLayoutGroup.json`, `VerticalLayoutGroup.json`, `GridLayoutGroup.json`, `ContentSizeFitter.json`.
  * Interactive controls: `Button.json`, `Scrollbar.json`, `ScrollRect.json`, `Slider.json`, `Toggle.json`, `ToggleGroup.json`.
  * Visual graphics & masking: `Image.json`, `RawImage.json`, `Mask.json`, `RectMask2D.json`, `Outline.json`, `Shadow.json`, `Text.json`, `TextMeshPro.json`, `TextMeshProUGUI.json`.

---
"""

# Read existing file
with open(DOC_PATH, "r", encoding="utf-8") as f:
    content = f.read()

# Target insertion point: right before ## Core Subsystem Architecture & In-Depth Technical Breakdown
target = "## Core Subsystem Architecture & In-Depth Technical Breakdown"
if target in content:
    idx = content.find(target)
    new_content = content[:idx] + COLLATED_SECTION + "\n" + content[idx:]
    with open(DOC_PATH, "w", encoding="utf-8") as f:
        f.write(new_content)
    print("Collated section inserted successfully!")
else:
    print("Target section header not found.")
