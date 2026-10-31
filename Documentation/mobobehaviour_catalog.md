# Suikoden Remaster - Serialized MonoBehaviour Master Catalog

Comprehensive mapping, technical analysis, and master catalog of all **4,733 serialized MonoBehaviour assets** in `D:\Modding\suikodum\Mobobehaviour` across *Suikoden I & II HD Remaster*.

---

## Master Table of Contents

- **[Suikoden II Geographic Map & World Assets](#suikoden-ii-geographic-map-world-assets)** (2,706 assets)
  - [Overworld Region WA](#overworld-region-wa) (16 assets)
  - [Overworld Region WB](#overworld-region-wb) (19 assets)
  - [Overworld Region WC](#overworld-region-wc) (28 assets)
  - [Overworld Region WD](#overworld-region-wd) (12 assets)
  - [Overworld Region WE](#overworld-region-we) (24 assets)
  - [Overworld Region WG](#overworld-region-wg) (11 assets)
  - [Overworld Region WH](#overworld-region-wh) (13 assets)
  - [Overworld Region WI](#overworld-region-wi) (22 assets)
  - [Overworld Region WJ](#overworld-region-wj) (11 assets)
  - [Region VA: Tenzan Pass / Kyaro / North Sparrow / Ryube](#region-va-tenzan-pass-kyaro-north-sparrow-ryube) (427 assets)
  - [Region VB: Toto / Mercenary Fort / Muse City / White Deer](#region-vb-toto-mercenary-fort-muse-city-white-deer) (366 assets)
  - [Region VC: Coronet / Kuskus / South Window / Radat](#region-vc-coronet-kuskus-south-window-radat) (318 assets)
  - [Region VD: Two River / Kobold Village / Lakewest / Drakemouth](#region-vd-two-river-kobold-village-lakewest-drakemouth) (252 assets)
  - [Region VE: Greenhill / Matilda / Muse-Matilda Border](#region-ve-greenhill-matilda-muse-matilda-border) (200 assets)
  - [Region VF: Highway / Rockaxe / Mt. Rakutei](#region-vf-highway-rockaxe-mt-rakutei) (160 assets)
  - [Region VG: Tinto / Crom / Tigermouth / Mines](#region-vg-tinto-crom-tigermouth-mines) (152 assets)
  - [Region VH: Banner Village / Gregminster / Rokkaku](#region-vh-banner-village-gregminster-rokkaku) (140 assets)
  - [Region VI: Castle Headquarters Tiers (Levels 1-4)](#region-vi-castle-headquarters-tiers-levels-1-4) (118 assets)
  - [Region VJ: L'Renouille / Sajah Village / Beast Rune Altar](#region-vj-lrenouille-sajah-village-beast-rune-altar) (228 assets)
  - [Region VK: Castle HQ Facilities & Special Event Staging](#region-vk-castle-hq-facilities-special-event-staging) (160 assets)
  - [Region VS: Suikoden I Retrospective Special Maps](#region-vs-suikoden-i-retrospective-special-maps) (29 assets)
- **[Battle Encounters & Monster Formation Tables](#battle-encounters-monster-formation-tables)** (193 assets)
  - [Dungeon Encounter Zone Tables](#dungeon-encounter-zone-tables) (50 assets)
  - [Monster Party Formation Slot Definitions](#monster-party-formation-slot-definitions) (80 assets)
  - [Monster Stats & Unit Parameters](#monster-stats-unit-parameters) (63 assets)
- **[Boss Encounters & Combat Arenas](#boss-encounters-combat-arenas)** (133 assets)
  - [Boss AI & Combat Parameter Packages (`boss_*`)](#boss-ai-combat-parameter-packages-boss_) (86 assets)
  - [Boss Arena 3D Models & Props (`boss_*_obj`)](#boss-arena-3d-models-props-boss__obj) (14 assets)
  - [Boss VFX & Cinematic Resources (`boss_*_res`)](#boss-vfx-cinematic-resources-boss__res) (33 assets)
- **[Scripted Story Event Battles](#scripted-story-event-battles)** (119 assets)
  - [Scripted Event Battle Scenarios (`eb_*`)](#scripted-event-battle-scenarios-eb_) (119 assets)
- **[Castle HQ Facilities, Bathhouse & Minigames](#castle-hq-facilities-bathhouse-minigames)** (254 assets)
  - [Bathhouse Scenes & Dialogue Triggers (`hp_furo_*`)](#bathhouse-scenes-dialogue-triggers-hp_furo_) (52 assets)
  - [Castle Facility Sub-Assets (`hp_*`)](#castle-facility-sub-assets-hp_) (165 assets)
  - [Chinchirorin Dice Minigame (`hp_chin_*`)](#chinchirorin-dice-minigame-hp_chin_) (2 assets)
  - [Detective Floor Plans & Castle Maps (`hp_hmap_*`)](#detective-floor-plans-castle-maps-hp_hmap_) (9 assets)
  - [Fishing Minigame (`hp_fish_*`)](#fishing-minigame-hp_fish_) (6 assets)
  - [Library Readable Old Books (`hp_book_*`)](#library-readable-old-books-hp_book_) (4 assets)
  - [Sound Room Jukebox Playlists (`hp_hsound_*`)](#sound-room-jukebox-playlists-hp_hsound_) (10 assets)
  - [Wood Chopping Minigame (`hp_kikori_*`)](#wood-chopping-minigame-hp_kikori_) (6 assets)
- **[Playable & NPC Character Entities](#playable-npc-character-entities)** (141 assets)
  - [Character Field Avatars, Battle Models & Dialogues](#character-field-avatars-battle-models-dialogues) (141 assets)
- **[Suikoden I Subsystems & Legacy Assets](#suikoden-i-subsystems-legacy-assets)** (66 assets)
  - [Core Engine, Shaders & Credits (`g1_*`, `GS1*`)](#core-engine-shaders-credits-g1_-gs1) (7 assets)
  - [One-on-One Duel Subsystem (`pan_teo*`)](#one-on-one-duel-subsystem-pan_teo) (7 assets)
  - [Tactical War Battles (`war_*`)](#tactical-war-battles-war_) (52 assets)
- **[User Interface & Menu Subsystems](#user-interface-menu-subsystems)** (87 assets)
  - [UI Menus, Battle HUDs, Save Windows & Dialogue Backlog](#ui-menus-battle-huds-save-windows-dialogue-backlog) (87 assets)
- **[Audio & CRIWARE Sound Infrastructure](#audio-criware-sound-infrastructure)** (7 assets)
  - [CRIWARE Emitters, Sound Triggers & Attenuation](#criware-emitters-sound-triggers-attenuation) (7 assets)
- **[Cinematics, VFX & Timelines](#cinematics-vfx-timelines)** (37 assets)
  - [Cinematic Tracks, Spell Timelines & Particle VFX](#cinematic-tracks-spell-timelines-particle-vfx) (37 assets)
- **[Top-Level Launcher Hub Assets](#top-level-launcher-hub-assets)** (8 assets)
  - [Launcher Hub Assets](#launcher-hub-assets) (8 assets)
- **[Engine Framework, Shaders & Shared Assets](#engine-framework-shaders-shared-assets)** (982 assets)
  - [Unity Engine Components, TMP Fonts & Post-Processing](#unity-engine-components-tmp-fonts-post-processing) (982 assets)

---

## Global Architecture & Subsystem Distribution

| Master Subsystem | Asset Count | Percentage | Primary Engine Subsystems & Roles |
|---|:---:|:---:|---|
| **Suikoden II Geographic Map & World Assets** | **2,706** | 57.2% | Map configurations, `MACHIDAT` deserialized event bytecode, 3D prop models, collision layers, warp zones, and background tiles for Regions VA-VS and World Map Sectors WA-WJ. |
| **Battle Encounters & Monster Formation Tables** | **193** | 4.1% | Zone encounter tables (`a_data` - `z_data`), monster combat stats, reward drop tables, and enemy party formation slot coordinates. |
| **Boss Encounters & Combat Arenas** | **133** | 2.8% | Boss combat AI controller packages (`boss_*`), dedicated arena 3D prop models (`_obj`), and visual cinematic resources (`_res`). |
| **Scripted Story Event Battles** | **119** | 2.5% | Scripted story event combat scenarios (`eb_*`) synchronizing pre-battle dialogue, loss/victory conditions, and scene transitions. |
| **Castle HQ Facilities, Bathhouse & Minigames** | **254** | 5.4% | All 44 bathhouse dialogue interaction combinations (`hp_furo`), Chinchirorin dice, fishing, wood-chopping, library books, detective maps, and jukebox playlists. |
| **Playable & NPC Character Entities** | **141** | 3.0% | Overworld NPC field avatars, combat battle 3D meshes, skeleton animation tracks, and interaction scripts for 108 Stars and townspeople. |
| **Suikoden I Subsystems & Legacy Assets** | **66** | 1.4% | Tactical army war battles (`war_01`–`war_16`, Garan, Kuwaba, Teo, Shasarazade), Pahn vs. Teo duels, and S1 core engine shaders. |
| **User Interface & Menu Subsystems** | **87** | 1.8% | Combat battle HUD, main menu party formation, status screens, classic PSX save windows, and dialogue history backlog buffer. |
| **Audio & CRIWARE Sound Infrastructure** | **7** | 0.1% | CRI Atom 2D/3D audio playback emitters, listener position binders, attenuation radius controllers, and sound effect trigger assets. |
| **Cinematics, VFX & Timelines** | **37** | 0.8% | Unity PlayableDirector timelines, cinematic cutscene sequence controllers (`EM2_*`), spell timelines (`TL_*`), and particle VFX assets (`EFF_*`). |
| **Top-Level Launcher Hub Assets** | **8** | 0.2% | Top-level game selection hub timelines, gallery/sound menus, and game-switching controllers between Suikoden I and Suikoden II. |
| **Engine Framework, Shaders & Shared Assets** | **982** | 20.7% | TextMeshPro SDF font atlases, Demigiant DOTween visual components, Post-Processing Stack v2 profiles (Color Grading, Bloom), and Unity UI base components. |

---

## <a id="suikoden-ii-geographic-map-world-assets"></a>Suikoden II Geographic Map & World Assets

Total assets in subsystem: **2,706**

### <a id="overworld-region-wa"></a>Overworld Region WA (16 files)

| File Name | Subsystem / Type | Technical Role & Grounded Description |
|---|---|---|
| `WarHDHeader.json` | Engine / Game Asset | Asset file storing serialized component state for `WarHDHeader` (keys: m_Script, m_Name, bars, poochiText). |
| `WarUIStatus.json` | Engine / Game Asset | Asset file storing serialized component state for `WarUIStatus` (keys: m_Script, m_Name, imperialArmyStatus, peoplesliberationarmyStatus). |
| `WarUIStatusComponent.json` | Engine / Game Asset | Asset file storing serialized component state for `WarUIStatusComponent` (keys: m_Script, m_Name, titleText, unitText). |
| `WarUITitle.json` | Engine / Game Asset | Asset file storing serialized component state for `WarUITitle` (keys: m_Script, m_Name, mapLeft, mapRight). |
| `WaypointMovementManager.json` | Engine / Game Asset | Asset file storing serialized component state for `WaypointMovementManager` (keys: m_Script, m_Name, objectsToMove, speed). |
| `WaypointMoving.json` | Engine / Game Asset | Asset file storing serialized component state for `WaypointMoving` (keys: m_Script, m_Name, waypoints). |
| `wa.json` | Map Data (WA) | Core map asset for `wa` in World Map Region A. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `wa_00.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `wa_0` (World Map Region A). |
| `wa_00_00.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `wa_0` (World Map Region A). |
| `wa_00_01.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `wa_0` (World Map Region A). |
| `wa_00_02.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `wa_0` (World Map Region A). |
| `wa_00_04.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `wa_0` (World Map Region A). |
| `wa_00_obj.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `wa_0` (World Map Region A). |
| `wa_map_00.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `wa_m` (World Map Region A). |
| `wall_fresco.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `wall` (World Map Region A). |
| `wall_fresco_root.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `wall` (World Map Region A). |

### <a id="overworld-region-wb"></a>Overworld Region WB (19 files)

| File Name | Subsystem / Type | Technical Role & Grounded Description |
|---|---|---|
| `wb.json` | Map Data (WB) | Core map asset for `wb` in World Map Region B. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `wb_00.json` | Map Sub-Asset (WB) | Map background layer / 3D prop configuration for `wb_0` (World Map Region B). |
| `wb_00_00.json` | Map Sub-Asset (WB) | Map background layer / 3D prop configuration for `wb_0` (World Map Region B). |
| `wb_00_01.json` | Map Sub-Asset (WB) | Map background layer / 3D prop configuration for `wb_0` (World Map Region B). |
| `wb_00_02.json` | Map Sub-Asset (WB) | Map background layer / 3D prop configuration for `wb_0` (World Map Region B). |
| `wb_00_03.json` | Map Sub-Asset (WB) | Map background layer / 3D prop configuration for `wb_0` (World Map Region B). |
| `wb_00_04.json` | Map Sub-Asset (WB) | Map background layer / 3D prop configuration for `wb_0` (World Map Region B). |
| `wb_00_05.json` | Map Sub-Asset (WB) | Map background layer / 3D prop configuration for `wb_0` (World Map Region B). |
| `wb_00_06.json` | Map Sub-Asset (WB) | Map background layer / 3D prop configuration for `wb_0` (World Map Region B). |
| `wb_00_obj.json` | Map Sub-Asset (WB) | Map background layer / 3D prop configuration for `wb_0` (World Map Region B). |
| `wb_01.json` | Map Sub-Asset (WB) | Map background layer / 3D prop configuration for `wb_0` (World Map Region B). |
| `wb_01_00.json` | Map Sub-Asset (WB) | Map background layer / 3D prop configuration for `wb_0` (World Map Region B). |
| `wb_01_01.json` | Map Sub-Asset (WB) | Map background layer / 3D prop configuration for `wb_0` (World Map Region B). |
| `wb_01_02.json` | Map Sub-Asset (WB) | Map background layer / 3D prop configuration for `wb_0` (World Map Region B). |
| `wb_01_03.json` | Map Sub-Asset (WB) | Map background layer / 3D prop configuration for `wb_0` (World Map Region B). |
| `wb_01_04.json` | Map Sub-Asset (WB) | Map background layer / 3D prop configuration for `wb_0` (World Map Region B). |
| `wb_01_05.json` | Map Sub-Asset (WB) | Map background layer / 3D prop configuration for `wb_0` (World Map Region B). |
| `wb_01_06.json` | Map Sub-Asset (WB) | Map background layer / 3D prop configuration for `wb_0` (World Map Region B). |
| `wb_map_00.json` | Map Sub-Asset (WB) | Map background layer / 3D prop configuration for `wb_m` (World Map Region B). |

### <a id="overworld-region-wc"></a>Overworld Region WC (28 files)

| File Name | Subsystem / Type | Technical Role & Grounded Description |
|---|---|---|
| `wc.json` | Map Data (WC) | Core map asset for `wc` in World Map Region C. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `wc_00.json` | Map Sub-Asset (WC) | Map background layer / 3D prop configuration for `wc_0` (World Map Region C). |
| `wc_00_00.json` | Map Sub-Asset (WC) | Map background layer / 3D prop configuration for `wc_0` (World Map Region C). |
| `wc_00_01.json` | Map Sub-Asset (WC) | Map background layer / 3D prop configuration for `wc_0` (World Map Region C). |
| `wc_00_02.json` | Map Sub-Asset (WC) | Map background layer / 3D prop configuration for `wc_0` (World Map Region C). |
| `wc_00_03.json` | Map Sub-Asset (WC) | Map background layer / 3D prop configuration for `wc_0` (World Map Region C). |
| `wc_00_04.json` | Map Sub-Asset (WC) | Map background layer / 3D prop configuration for `wc_0` (World Map Region C). |
| `wc_00_05.json` | Map Sub-Asset (WC) | Map background layer / 3D prop configuration for `wc_0` (World Map Region C). |
| `wc_00_06.json` | Map Sub-Asset (WC) | Map background layer / 3D prop configuration for `wc_0` (World Map Region C). |
| `wc_00_07.json` | Map Sub-Asset (WC) | Map background layer / 3D prop configuration for `wc_0` (World Map Region C). |
| `wc_01.json` | Map Sub-Asset (WC) | Map background layer / 3D prop configuration for `wc_0` (World Map Region C). |
| `wc_01_00.json` | Map Sub-Asset (WC) | Map background layer / 3D prop configuration for `wc_0` (World Map Region C). |
| `wc_01_02.json` | Map Sub-Asset (WC) | Map background layer / 3D prop configuration for `wc_0` (World Map Region C). |
| `wc_01_03.json` | Map Sub-Asset (WC) | Map background layer / 3D prop configuration for `wc_0` (World Map Region C). |
| `wc_01_04.json` | Map Sub-Asset (WC) | Map background layer / 3D prop configuration for `wc_0` (World Map Region C). |
| `wc_01_06.json` | Map Sub-Asset (WC) | Map background layer / 3D prop configuration for `wc_0` (World Map Region C). |
| `wc_01_07.json` | Map Sub-Asset (WC) | Map background layer / 3D prop configuration for `wc_0` (World Map Region C). |
| `wc_02.json` | Map Sub-Asset (WC) | Map background layer / 3D prop configuration for `wc_0` (World Map Region C). |
| `wc_02_00.json` | Map Sub-Asset (WC) | Map background layer / 3D prop configuration for `wc_0` (World Map Region C). |
| `wc_02_02.json` | Map Sub-Asset (WC) | Map background layer / 3D prop configuration for `wc_0` (World Map Region C). |
| `wc_02_05.json` | Map Sub-Asset (WC) | Map background layer / 3D prop configuration for `wc_0` (World Map Region C). |
| `wc_02_06.json` | Map Sub-Asset (WC) | Map background layer / 3D prop configuration for `wc_0` (World Map Region C). |
| `wc_02_08.json` | Map Sub-Asset (WC) | Map background layer / 3D prop configuration for `wc_0` (World Map Region C). |
| `wc_02_09.json` | Map Sub-Asset (WC) | Map background layer / 3D prop configuration for `wc_0` (World Map Region C). |
| `wc_02_12.json` | Map Sub-Asset (WC) | Map background layer / 3D prop configuration for `wc_0` (World Map Region C). |
| `wc_02_14.json` | Map Sub-Asset (WC) | Map background layer / 3D prop configuration for `wc_0` (World Map Region C). |
| `wc_etc_05.json` | Map Sub-Asset (WC) | Map background layer / 3D prop configuration for `wc_e` (World Map Region C). |
| `wc_map_00.json` | Map Sub-Asset (WC) | Map background layer / 3D prop configuration for `wc_m` (World Map Region C). |

### <a id="overworld-region-wd"></a>Overworld Region WD (12 files)

| File Name | Subsystem / Type | Technical Role & Grounded Description |
|---|---|---|
| `wd.json` | Map Data (WD) | Core map asset for `wd` in World Map Region D. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `wd_00.json` | Map Sub-Asset (WD) | Map background layer / 3D prop configuration for `wd_0` (World Map Region D). |
| `wd_00_00.json` | Map Sub-Asset (WD) | Map background layer / 3D prop configuration for `wd_0` (World Map Region D). |
| `wd_00_01.json` | Map Sub-Asset (WD) | Map background layer / 3D prop configuration for `wd_0` (World Map Region D). |
| `wd_00_02.json` | Map Sub-Asset (WD) | Map background layer / 3D prop configuration for `wd_0` (World Map Region D). |
| `wd_00_03.json` | Map Sub-Asset (WD) | Map background layer / 3D prop configuration for `wd_0` (World Map Region D). |
| `wd_00_04.json` | Map Sub-Asset (WD) | Map background layer / 3D prop configuration for `wd_0` (World Map Region D). |
| `wd_00_05.json` | Map Sub-Asset (WD) | Map background layer / 3D prop configuration for `wd_0` (World Map Region D). |
| `wd_00_06.json` | Map Sub-Asset (WD) | Map background layer / 3D prop configuration for `wd_0` (World Map Region D). |
| `wd_00_08.json` | Map Sub-Asset (WD) | Map background layer / 3D prop configuration for `wd_0` (World Map Region D). |
| `wd_00_obj.json` | Map Sub-Asset (WD) | Map background layer / 3D prop configuration for `wd_0` (World Map Region D). |
| `wd_map_00.json` | Map Sub-Asset (WD) | Map background layer / 3D prop configuration for `wd_m` (World Map Region D). |

### <a id="overworld-region-we"></a>Overworld Region WE (24 files)

| File Name | Subsystem / Type | Technical Role & Grounded Description |
|---|---|---|
| `we.json` | Map Data (WE) | Core map asset for `we` in World Map Region E. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `we_00.json` | Map Sub-Asset (WE) | Map background layer / 3D prop configuration for `we_0` (World Map Region E). |
| `we_00_00.json` | Map Sub-Asset (WE) | Map background layer / 3D prop configuration for `we_0` (World Map Region E). |
| `we_00_01.json` | Map Sub-Asset (WE) | Map background layer / 3D prop configuration for `we_0` (World Map Region E). |
| `we_00_02.json` | Map Sub-Asset (WE) | Map background layer / 3D prop configuration for `we_0` (World Map Region E). |
| `we_00_03.json` | Map Sub-Asset (WE) | Map background layer / 3D prop configuration for `we_0` (World Map Region E). |
| `we_00_04.json` | Map Sub-Asset (WE) | Map background layer / 3D prop configuration for `we_0` (World Map Region E). |
| `we_00_05.json` | Map Sub-Asset (WE) | Map background layer / 3D prop configuration for `we_0` (World Map Region E). |
| `we_00_06.json` | Map Sub-Asset (WE) | Map background layer / 3D prop configuration for `we_0` (World Map Region E). |
| `we_00_07.json` | Map Sub-Asset (WE) | Map background layer / 3D prop configuration for `we_0` (World Map Region E). |
| `we_00_08.json` | Map Sub-Asset (WE) | Map background layer / 3D prop configuration for `we_0` (World Map Region E). |
| `we_00_09.json` | Map Sub-Asset (WE) | Map background layer / 3D prop configuration for `we_0` (World Map Region E). |
| `we_00_10.json` | Map Sub-Asset (WE) | Map background layer / 3D prop configuration for `we_0` (World Map Region E). |
| `we_00_obj.json` | Map Sub-Asset (WE) | Map background layer / 3D prop configuration for `we_0` (World Map Region E). |
| `we_01.json` | Map Sub-Asset (WE) | Map background layer / 3D prop configuration for `we_0` (World Map Region E). |
| `we_01_00.json` | Map Sub-Asset (WE) | Map background layer / 3D prop configuration for `we_0` (World Map Region E). |
| `we_01_02.json` | Map Sub-Asset (WE) | Map background layer / 3D prop configuration for `we_0` (World Map Region E). |
| `we_01_04.json` | Map Sub-Asset (WE) | Map background layer / 3D prop configuration for `we_0` (World Map Region E). |
| `we_01_05.json` | Map Sub-Asset (WE) | Map background layer / 3D prop configuration for `we_0` (World Map Region E). |
| `we_01_08.json` | Map Sub-Asset (WE) | Map background layer / 3D prop configuration for `we_0` (World Map Region E). |
| `we_02.json` | Map Sub-Asset (WE) | Map background layer / 3D prop configuration for `we_0` (World Map Region E). |
| `we_02_00.json` | Map Sub-Asset (WE) | Map background layer / 3D prop configuration for `we_0` (World Map Region E). |
| `we_02_02.json` | Map Sub-Asset (WE) | Map background layer / 3D prop configuration for `we_0` (World Map Region E). |
| `we_02_03.json` | Map Sub-Asset (WE) | Map background layer / 3D prop configuration for `we_0` (World Map Region E). |

### <a id="overworld-region-wg"></a>Overworld Region WG (11 files)

| File Name | Subsystem / Type | Technical Role & Grounded Description |
|---|---|---|
| `wg.json` | Map Data (WG) | Core map asset for `wg` in World Map Region G. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `wg_00.json` | Map Sub-Asset (WG) | Map background layer / 3D prop configuration for `wg_0` (World Map Region G). |
| `wg_00_00.json` | Map Sub-Asset (WG) | Map background layer / 3D prop configuration for `wg_0` (World Map Region G). |
| `wg_00_01.json` | Map Sub-Asset (WG) | Map background layer / 3D prop configuration for `wg_0` (World Map Region G). |
| `wg_00_02.json` | Map Sub-Asset (WG) | Map background layer / 3D prop configuration for `wg_0` (World Map Region G). |
| `wg_00_04.json` | Map Sub-Asset (WG) | Map background layer / 3D prop configuration for `wg_0` (World Map Region G). |
| `wg_00_05.json` | Map Sub-Asset (WG) | Map background layer / 3D prop configuration for `wg_0` (World Map Region G). |
| `wg_00_06.json` | Map Sub-Asset (WG) | Map background layer / 3D prop configuration for `wg_0` (World Map Region G). |
| `wg_00_08.json` | Map Sub-Asset (WG) | Map background layer / 3D prop configuration for `wg_0` (World Map Region G). |
| `wg_00_10.json` | Map Sub-Asset (WG) | Map background layer / 3D prop configuration for `wg_0` (World Map Region G). |
| `wg_00_obj.json` | Map Sub-Asset (WG) | Map background layer / 3D prop configuration for `wg_0` (World Map Region G). |

### <a id="overworld-region-wh"></a>Overworld Region WH (13 files)

| File Name | Subsystem / Type | Technical Role & Grounded Description |
|---|---|---|
| `wh.json` | Map Data (WH) | Core map asset for `wh` in World Map Region H. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `wh_00.json` | Map Sub-Asset (WH) | Map background layer / 3D prop configuration for `wh_0` (World Map Region H). |
| `wh_00_00.json` | Map Sub-Asset (WH) | Map background layer / 3D prop configuration for `wh_0` (World Map Region H). |
| `wh_00_01.json` | Map Sub-Asset (WH) | Map background layer / 3D prop configuration for `wh_0` (World Map Region H). |
| `wh_00_02.json` | Map Sub-Asset (WH) | Map background layer / 3D prop configuration for `wh_0` (World Map Region H). |
| `wh_00_05.json` | Map Sub-Asset (WH) | Map background layer / 3D prop configuration for `wh_0` (World Map Region H). |
| `wh_00_06.json` | Map Sub-Asset (WH) | Map background layer / 3D prop configuration for `wh_0` (World Map Region H). |
| `wh_00_08.json` | Map Sub-Asset (WH) | Map background layer / 3D prop configuration for `wh_0` (World Map Region H). |
| `wh_00_10.json` | Map Sub-Asset (WH) | Map background layer / 3D prop configuration for `wh_0` (World Map Region H). |
| `wh_00_11.json` | Map Sub-Asset (WH) | Map background layer / 3D prop configuration for `wh_0` (World Map Region H). |
| `wh_00_12.json` | Map Sub-Asset (WH) | Map background layer / 3D prop configuration for `wh_0` (World Map Region H). |
| `wh_00_13.json` | Map Sub-Asset (WH) | Map background layer / 3D prop configuration for `wh_0` (World Map Region H). |
| `wh_map_00.json` | Map Sub-Asset (WH) | Map background layer / 3D prop configuration for `wh_m` (World Map Region H). |

### <a id="overworld-region-wi"></a>Overworld Region WI (22 files)

| File Name | Subsystem / Type | Technical Role & Grounded Description |
|---|---|---|
| `wi.json` | Map Data (WI) | Core map asset for `wi` in World Map Region I. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `wi_00.json` | Map Sub-Asset (WI) | Map background layer / 3D prop configuration for `wi_0` (World Map Region I). |
| `wi_00_00.json` | Map Sub-Asset (WI) | Map background layer / 3D prop configuration for `wi_0` (World Map Region I). |
| `wi_00_01.json` | Map Sub-Asset (WI) | Map background layer / 3D prop configuration for `wi_0` (World Map Region I). |
| `wi_00_02.json` | Map Sub-Asset (WI) | Map background layer / 3D prop configuration for `wi_0` (World Map Region I). |
| `wi_00_03.json` | Map Sub-Asset (WI) | Map background layer / 3D prop configuration for `wi_0` (World Map Region I). |
| `wi_00_04.json` | Map Sub-Asset (WI) | Map background layer / 3D prop configuration for `wi_0` (World Map Region I). |
| `wi_00_05.json` | Map Sub-Asset (WI) | Map background layer / 3D prop configuration for `wi_0` (World Map Region I). |
| `wi_00_06.json` | Map Sub-Asset (WI) | Map background layer / 3D prop configuration for `wi_0` (World Map Region I). |
| `wi_00_08.json` | Map Sub-Asset (WI) | Map background layer / 3D prop configuration for `wi_0` (World Map Region I). |
| `wi_00_09.json` | Map Sub-Asset (WI) | Map background layer / 3D prop configuration for `wi_0` (World Map Region I). |
| `wi_00_13.json` | Map Sub-Asset (WI) | Map background layer / 3D prop configuration for `wi_0` (World Map Region I). |
| `wi_00_17.json` | Map Sub-Asset (WI) | Map background layer / 3D prop configuration for `wi_0` (World Map Region I). |
| `wi_01.json` | Map Sub-Asset (WI) | Map background layer / 3D prop configuration for `wi_0` (World Map Region I). |
| `wi_01_00.json` | Map Sub-Asset (WI) | Map background layer / 3D prop configuration for `wi_0` (World Map Region I). |
| `wi_01_03.json` | Map Sub-Asset (WI) | Map background layer / 3D prop configuration for `wi_0` (World Map Region I). |
| `wi_01_05.json` | Map Sub-Asset (WI) | Map background layer / 3D prop configuration for `wi_0` (World Map Region I). |
| `wi_01_06.json` | Map Sub-Asset (WI) | Map background layer / 3D prop configuration for `wi_0` (World Map Region I). |
| `wi_01_07.json` | Map Sub-Asset (WI) | Map background layer / 3D prop configuration for `wi_0` (World Map Region I). |
| `wi_map_00.json` | Map Sub-Asset (WI) | Map background layer / 3D prop configuration for `wi_m` (World Map Region I). |
| `wig.json` | Map Data (WI) | Core map asset for `wig` in World Map Region I. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `window_mark_asset.json` | Map Sub-Asset (WI) | Map background layer / 3D prop configuration for `wind` (World Map Region I). |

### <a id="overworld-region-wj"></a>Overworld Region WJ (11 files)

| File Name | Subsystem / Type | Technical Role & Grounded Description |
|---|---|---|
| `wj.json` | Map Data (WJ) | Core map asset for `wj` in World Map Region J. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `wj_00.json` | Map Sub-Asset (WJ) | Map background layer / 3D prop configuration for `wj_0` (World Map Region J). |
| `wj_00_00.json` | Map Sub-Asset (WJ) | Map background layer / 3D prop configuration for `wj_0` (World Map Region J). |
| `wj_00_01.json` | Map Sub-Asset (WJ) | Map background layer / 3D prop configuration for `wj_0` (World Map Region J). |
| `wj_00_02.json` | Map Sub-Asset (WJ) | Map background layer / 3D prop configuration for `wj_0` (World Map Region J). |
| `wj_00_03.json` | Map Sub-Asset (WJ) | Map background layer / 3D prop configuration for `wj_0` (World Map Region J). |
| `wj_00_05.json` | Map Sub-Asset (WJ) | Map background layer / 3D prop configuration for `wj_0` (World Map Region J). |
| `wj_00_07.json` | Map Sub-Asset (WJ) | Map background layer / 3D prop configuration for `wj_0` (World Map Region J). |
| `wj_00_08.json` | Map Sub-Asset (WJ) | Map background layer / 3D prop configuration for `wj_0` (World Map Region J). |
| `wj_00_obj.json` | Map Sub-Asset (WJ) | Map background layer / 3D prop configuration for `wj_0` (World Map Region J). |
| `wj_map_00.json` | Map Sub-Asset (WJ) | Map background layer / 3D prop configuration for `wj_m` (World Map Region J). |

### <a id="region-va-tenzan-pass-kyaro-north-sparrow-ryube"></a>Region VA: Tenzan Pass / Kyaro / North Sparrow / Ryube (427 files)

| File Name | Subsystem / Type | Technical Role & Grounded Description |
|---|---|---|
| `va01.json` | Map Data (VA) | Core map asset for `va01` in Ryube / Kyaro / North Sparrow / Tenzan. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `va01_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va01` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va01_00_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va01` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va01_00_01.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va01` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va01_00_02.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va01` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va01_00_obj.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va01` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va01_01.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va01` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va01_02.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va01` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va01_03.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va01` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va01_04.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va01` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va01_05.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va01` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va01_06.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va01` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va01_07.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va01` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va01_08.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va01` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va01_09.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va01` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va01_10.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va01` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va01_11.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va01` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va01_12.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va01` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va01_map_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va01` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va01_map_01.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va01` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va02.json` | Map Data (VA) | Core map asset for `va02` in Ryube / Kyaro / North Sparrow / Tenzan. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `va02_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va02` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va02_01.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va02` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va02_02.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va02` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va02_03.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va02` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va02_04.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va02` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va02_05.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va02` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va02_map_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va02` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va03.json` | Map Data (VA) | Core map asset for `va03` in Ryube / Kyaro / North Sparrow / Tenzan. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `va03_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va03` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va03_01.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va03` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va03_02.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va03` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va03_03.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va03` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va03_04.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va03` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va03_05.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va03` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va03_09.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va03` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va03_10.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va03` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va03_11.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va03` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va03_13.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va03` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va03_14.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va03` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va03_15.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va03` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va03_16.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va03` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va03_17.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va03` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va03_18.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va03` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va03_19.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va03` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va03_20.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va03` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va03_21.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va03` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va03_22.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va03` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va03_24.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va03` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va03_25.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va03` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va03_26.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va03` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va03_27.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va03` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va03_28.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va03` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va03_29.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va03` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va03_30.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va03` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va03_31.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va03` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va03_map_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va03` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va03_map_01.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va03` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va04.json` | Map Data (VA) | Core map asset for `va04` in Ryube / Kyaro / North Sparrow / Tenzan. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `va04_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va04` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va04_03.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va04` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va04_05.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va04` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va04_06.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va04` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va04_07.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va04` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va04_08.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va04` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va04_09.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va04` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va04_10.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va04` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va04_11.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va04` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va04_12.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va04` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va04_13.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va04` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va04_14.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va04` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va04_15.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va04` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va04_16.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va04` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va04_17.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va04` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va04_18.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va04` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va04_20.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va04` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va04_21.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va04` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va04_22.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va04` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va04_23.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va04` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va04_25.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va04` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va04_26.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va04` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va04_27.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va04` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va04_28.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va04` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va04_29.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va04` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va04_30.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va04` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va04_31.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va04` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va04_33.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va04` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va04_34.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va04` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va04_35.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va04` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va05.json` | Map Data (VA) | Core map asset for `va05` in Ryube / Kyaro / North Sparrow / Tenzan. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `va05_05.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va05` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va05_06.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va05` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va05_07.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va05` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va05_08.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va05` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va05_11.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va05` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va05_map_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va05` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va06.json` | Map Data (VA) | Core map asset for `va06` in Ryube / Kyaro / North Sparrow / Tenzan. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `va06_02.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va06` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va06_04.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va06` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va06_map_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va06` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va07.json` | Map Data (VA) | Core map asset for `va07` in Ryube / Kyaro / North Sparrow / Tenzan. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `va07_04.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va07` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va07_map_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va07` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va08.json` | Map Data (VA) | Core map asset for `va08` in Ryube / Kyaro / North Sparrow / Tenzan. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `va08_01.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va08` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va08_02.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va08` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va08_05.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va08` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va08_06.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va08` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va08_map_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va08` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va09.json` | Map Data (VA) | Core map asset for `va09` in Ryube / Kyaro / North Sparrow / Tenzan. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `va09_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va09` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va09_00_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va09` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va09_00_01.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va09` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va09_00_02.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va09` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va09_07.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va09` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va09_map_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va09` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va1.json` | Map Data (VA) | Core map asset for `va1` in Ryube / Kyaro / North Sparrow / Tenzan. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `va10.json` | Map Data (VA) | Core map asset for `va10` in Ryube / Kyaro / North Sparrow / Tenzan. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `va10_map_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va10` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va11.json` | Map Data (VA) | Core map asset for `va11` in Ryube / Kyaro / North Sparrow / Tenzan. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `va11_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va11` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va11_00_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va11` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va11_00_01.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va11` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va11_00_02.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va11` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va11_00_04.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va11` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va11_00_05.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va11` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va11_00_07.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va11` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va11_00_09.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va11` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va11_00_obj.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va11` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va11_map_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va11` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va12.json` | Map Data (VA) | Core map asset for `va12` in Ryube / Kyaro / North Sparrow / Tenzan. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `va12_map_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va12` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va13.json` | Map Data (VA) | Core map asset for `va13` in Ryube / Kyaro / North Sparrow / Tenzan. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `va13_01.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va13` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va13_02.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va13` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va13_map_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va13` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va14.json` | Map Data (VA) | Core map asset for `va14` in Ryube / Kyaro / North Sparrow / Tenzan. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `va14_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va14` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va14_01.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va14` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va14_02.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va14` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va14_04.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va14` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va15.json` | Map Data (VA) | Core map asset for `va15` in Ryube / Kyaro / North Sparrow / Tenzan. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `va15_01.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va15` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va15_02.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va15` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va15_04.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va15` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va15_05.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va15` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va15_06.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va15` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va15_07.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va15` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va15_08.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va15` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va15_09.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va15` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va15_10.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va15` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va15_map_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va15` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va16.json` | Map Data (VA) | Core map asset for `va16` in Ryube / Kyaro / North Sparrow / Tenzan. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `va16_01.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va16` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va16_03.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va16` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va16_04.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va16` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va16_05.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va16` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va16_06.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va16` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va16_07.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va16` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va16_08.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va16` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va16_09.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va16` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va16_10.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va16` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va16_11.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va16` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va16_12.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va16` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va16_14.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va16` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va16_17.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va16` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va16_18.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va16` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va16_22.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va16` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va16_23.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va16` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va16_24.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va16` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va16_25.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va16` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va17.json` | Map Data (VA) | Core map asset for `va17` in Ryube / Kyaro / North Sparrow / Tenzan. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `va17_03.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va17` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va17_04.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va17` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va18.json` | Map Data (VA) | Core map asset for `va18` in Ryube / Kyaro / North Sparrow / Tenzan. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `va18_04.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va18` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va18_12.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va18` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va19.json` | Map Data (VA) | Core map asset for `va19` in Ryube / Kyaro / North Sparrow / Tenzan. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `va19_04.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va19` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va1_map_00_01.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va1_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va1_map_00_02.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va1_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va1_map_00_03.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va1_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va1_map_00_04.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va1_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va1_map_00_05.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va1_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va1_map_00_06.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va1_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va1_map_00_07.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va1_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va1_map_00_08.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va1_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va1_map_00_10.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va1_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va1_map_01_02.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va1_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va1_map_01_09.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va1_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va1_map_01_10.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va1_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va1_map_03_06.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va1_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va1_map_05_01.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va1_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va1_map_13_02.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va1_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va1_map_27_01.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va1_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va1_map_27_05.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va1_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va2.json` | Map Data (VA) | Core map asset for `va2` in Ryube / Kyaro / North Sparrow / Tenzan. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `va20.json` | Map Data (VA) | Core map asset for `va20` in Ryube / Kyaro / North Sparrow / Tenzan. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `va20_05.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va20` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va21.json` | Map Data (VA) | Core map asset for `va21` in Ryube / Kyaro / North Sparrow / Tenzan. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `va22.json` | Map Data (VA) | Core map asset for `va22` in Ryube / Kyaro / North Sparrow / Tenzan. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `va22_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va22` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va22_map_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va22` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va23.json` | Map Data (VA) | Core map asset for `va23` in Ryube / Kyaro / North Sparrow / Tenzan. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `va23_map_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va23` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va24.json` | Map Data (VA) | Core map asset for `va24` in Ryube / Kyaro / North Sparrow / Tenzan. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `va24_01.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va24` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va24_02.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va24` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va24_03.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va24` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va24_04.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va24` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va24_map_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va24` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va25.json` | Map Data (VA) | Core map asset for `va25` in Ryube / Kyaro / North Sparrow / Tenzan. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `va25_map_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va25` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va26.json` | Map Data (VA) | Core map asset for `va26` in Ryube / Kyaro / North Sparrow / Tenzan. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `va26_03.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va26` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va26_04.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va26` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va26_05.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va26` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va26_06.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va26` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va26_07.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va26` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va26_08.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va26` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va2_map_00_01.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va2_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va2_map_00_02.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va2_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va2_map_00_07.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va2_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va2_map_00_08.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va2_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va2_map_00_09.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va2_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va2_map_00_10.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va2_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va2_map_00_battle_01.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va2_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va2_map_00_battle_01_field.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va2_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va2_map_00_battle_01_field_srn.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va2_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va2_map_00_battle_01_monster_data_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va2_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va2_map_00_battle_01_monster_data_00_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va2_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va2_map_00_battle_01_monster_data_01.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va2_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va2_map_00_battle_01_monster_data_01_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va2_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va2_map_00_battle_01_monster_data_02.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va2_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va2_map_00_battle_01_monster_data_02_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va2_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va2_map_00_battle_01_monster_data_03.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va2_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va2_map_00_battle_01_monster_data_03_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va2_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va2_map_00_battle_01_monster_data_04.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va2_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va2_map_00_battle_01_monster_data_04_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va2_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va2_map_00_battle_01_monster_data_05.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va2_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va2_map_00_battle_01_monster_data_05_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va2_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va2_map_00_battle_01_monster_party_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va2_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va2_map_05_01.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va2_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va2_map_05_battle_01.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va2_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va2_map_05_battle_01_field.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va2_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va2_map_05_battle_01_field_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va2_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va2_map_05_battle_01_field_srn.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va2_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va2_map_05_battle_01_monster_party_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va2_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va2_map_05_battle_02.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va2_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va2_map_05_battle_02_monster_party_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va2_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va2_map_13_battle_01.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va2_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va2_map_13_battle_01_monster_party_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va2_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va3.json` | Map Data (VA) | Core map asset for `va3` in Ryube / Kyaro / North Sparrow / Tenzan. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `va3_map_00_01.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va3_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va3_map_01_05.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va3_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va3_map_01_09.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va3_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va3_map_01_10.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va3_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va3_map_01_11.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va3_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va3_map_01_battle_01.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va3_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va3_map_01_battle_01_field.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va3_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va3_map_01_battle_01_field_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va3_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va3_map_01_battle_01_field_srn.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va3_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va3_map_01_battle_01_monster_data_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va3_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va3_map_01_battle_01_monster_data_01.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va3_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va3_map_01_battle_01_monster_data_02.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va3_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va3_map_01_battle_01_monster_party_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va3_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va3_map_02_04.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va3_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va3_map_02_06.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va3_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va3_map_04_01.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va3_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va3_map_05_01.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va3_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va3_map_06_01.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va3_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va4.json` | Map Data (VA) | Core map asset for `va4` in Ryube / Kyaro / North Sparrow / Tenzan. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `va4_map_00_01.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va4_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va4_map_00_03.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va4_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va4_map_01_battle_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va4_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va4_map_01_battle_00_field.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va4_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va4_map_01_battle_00_field_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va4_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va4_map_01_battle_00_field_srn.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va4_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va4_map_01_battle_00_monster_data_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va4_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va4_map_01_battle_00_monster_data_00_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va4_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va4_map_01_battle_00_monster_data_01.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va4_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va4_map_01_battle_00_monster_data_01_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va4_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va4_map_01_battle_00_monster_party_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va4_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va4_map_01_battle_00_monster_party_01.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va4_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va4_map_01_battle_00_monster_party_02.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va4_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va4_map_01_battle_00_monster_party_03.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va4_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va4_map_01_battle_00_monster_party_08.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va4_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va4_map_03_battle_01.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va4_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va4_map_03_battle_01_monster_data_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va4_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va4_map_03_battle_01_monster_data_00_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va4_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va4_map_03_battle_01_monster_party_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va4_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va4_map_08_02.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va4_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va4b.json` | Map Data (VA) | Core map asset for `va4b` in Ryube / Kyaro / North Sparrow / Tenzan. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `va5.json` | Map Data (VA) | Core map asset for `va5` in Ryube / Kyaro / North Sparrow / Tenzan. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `va6.json` | Map Data (VA) | Core map asset for `va6` in Ryube / Kyaro / North Sparrow / Tenzan. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `va6_map_00_02.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va6_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va6_map_00_03.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va6_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va6_map_00_04.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va6_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va6_map_02_01.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va6_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va7.json` | Map Data (VA) | Core map asset for `va7` in Ryube / Kyaro / North Sparrow / Tenzan. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `va7_map_00_battle_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va7_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va7_map_00_battle_00_field.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va7_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va7_map_00_battle_00_field_srn.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va7_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va7_map_00_battle_00_monster_data_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va7_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va7_map_00_battle_00_monster_data_00_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va7_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va7_map_00_battle_00_monster_data_01.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va7_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va7_map_00_battle_00_monster_data_01_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va7_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va7_map_00_battle_00_monster_data_02.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va7_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va7_map_00_battle_00_monster_data_02_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va7_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va7_map_00_battle_00_monster_data_03.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va7_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va7_map_00_battle_00_monster_data_03_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va7_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va7_map_00_battle_00_monster_data_04.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va7_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va7_map_00_battle_00_monster_party_01.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va7_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va7_map_00_battle_00_monster_party_02.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va7_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va7_map_00_battle_00_monster_party_03.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va7_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va7_map_00_battle_00_monster_party_04.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va7_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va7_map_01_battle_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va7_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va7_map_01_battle_00_field.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va7_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va7_map_01_battle_00_field_srn.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va7_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va7_map_17_02.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va7_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va7_map_17_battle_01.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va7_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va7_map_17_battle_01_field.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va7_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va7_map_17_battle_01_field_srn.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va7_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va7_map_17_battle_01_monster_data_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va7_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va7_map_17_battle_01_monster_data_00_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va7_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va7_map_17_battle_01_monster_data_02.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va7_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va7_map_17_battle_01_monster_data_02_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va7_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va7_map_17_battle_01_monster_data_03.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va7_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va7_map_17_battle_01_monster_data_03_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va7_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va7_map_17_battle_01_monster_party_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va7_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va7_map_17_battle_02.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va7_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va7_map_17_battle_02_monster_party_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va7_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va7_map_24_battle_01.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va7_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va7_map_24_battle_01_field.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va7_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va7_map_24_battle_01_monster_party_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va7_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va7_map_24_battle_02.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va7_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va7_map_24_battle_02_monster_party_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va7_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va8.json` | Map Data (VA) | Core map asset for `va8` in Ryube / Kyaro / North Sparrow / Tenzan. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `va8_map_00_battle_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va8_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va8_map_00_battle_00_field.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va8_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va8_map_00_battle_00_field_srn.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va8_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va8_map_00_battle_00_monster_data_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va8_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va8_map_00_battle_00_monster_data_00_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va8_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va8_map_00_battle_00_monster_data_01.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va8_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va8_map_00_battle_00_monster_data_01_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va8_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va8_map_00_battle_00_monster_data_02.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va8_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va8_map_00_battle_00_monster_data_02_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va8_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va8_map_00_battle_00_monster_party_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va8_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va8_map_00_battle_00_monster_party_01.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va8_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va8_map_00_battle_00_monster_party_02.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va8_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va8_map_00_battle_00_monster_party_04.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va8_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va8_map_05_01.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va8_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va8_map_10_02.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va8_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va9.json` | Map Data (VA) | Core map asset for `va9` in Ryube / Kyaro / North Sparrow / Tenzan. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `va9_map_00_04.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va9_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va9_map_00_05.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va9_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `va9_map_01_02.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `va9_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vaa.json` | Map Data (VA) | Core map asset for `vaa` in Ryube / Kyaro / North Sparrow / Tenzan. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vaa_map_01_01.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vaa_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vaa_map_02_02.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vaa_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vaa_map_02_08.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vaa_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vaa_map_02_09.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vaa_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vaad.json` | Map Data (VA) | Core map asset for `vaad` in Ryube / Kyaro / North Sparrow / Tenzan. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vaad_map_00_01.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vaad` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vaad_map_00_02.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vaad` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vaad_map_00_03.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vaad` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vaad_map_00_04.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vaad` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vaad_map_00_05.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vaad` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vaad_map_00_08.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vaad` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vaad_map_00_09.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vaad` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vaad_map_00_10.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vaad` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vaad_map_01_02.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vaad` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vaad_map_01_03.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vaad` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vaad_map_01_05.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vaad` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vaad_map_01_07.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vaad` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vaad_map_01_11.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vaad` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vac.json` | Map Data (VA) | Core map asset for `vac` in Ryube / Kyaro / North Sparrow / Tenzan. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vac_map_28_02.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vac_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vac_map_28_battle_01.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vac_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vac_map_28_battle_01_field.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vac_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vac_map_28_battle_01_field_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vac_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vac_map_28_battle_01_field_srn.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vac_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vac_map_28_battle_01_monster_data_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vac_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vac_map_28_battle_01_monster_data_00_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vac_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vac_map_28_battle_01_monster_party_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vac_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vac_map_31_07.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vac_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vac_map_31_10.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vac_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vad.json` | Map Data (VA) | Core map asset for `vad` in Ryube / Kyaro / North Sparrow / Tenzan. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vad_map_00_battle_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vad_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vad_map_00_battle_00_field.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vad_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vad_map_00_battle_00_field_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vad_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vad_map_00_battle_00_field_srn.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vad_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vad_map_00_battle_00_monster_data_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vad_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vad_map_00_battle_00_monster_data_01.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vad_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vad_map_00_battle_00_monster_data_02.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vad_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vad_map_00_battle_00_monster_data_02_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vad_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vad_map_00_battle_00_monster_data_03.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vad_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vad_map_00_battle_00_monster_data_03_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vad_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vad_map_00_battle_00_monster_data_04.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vad_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vad_map_00_battle_00_monster_data_04_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vad_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vad_map_00_battle_00_monster_party_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vad_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vad_map_00_battle_00_monster_party_01.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vad_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vad_map_00_battle_00_monster_party_02.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vad_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vad_map_00_battle_00_monster_party_03.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vad_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vad_map_00_battle_00_monster_party_04.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vad_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vad_map_00_battle_00_monster_party_05.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vad_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vad_map_00_battle_00_monster_party_06.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vad_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vad_map_00_battle_00_monster_party_07.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vad_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vad_map_00_battle_00_monster_party_08.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vad_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vad_map_00_battle_00_monster_party_09.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vad_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vad_map_00_battle_00_monster_party_10.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vad_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vad_map_01_battle_01.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vad_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vad_map_01_battle_01_field.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vad_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vad_map_01_battle_01_field_srn.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vad_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vad_map_01_battle_01_monster_party_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vad_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vad_map_09_03.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vad_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vad_map_09_04.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vad_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vad_map_09_06.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vad_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vad_map_09_07.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vad_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vad_map_11_battle_01.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vad_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vad_map_11_battle_01_monster_party_00.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vad_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vad_map_17_07.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vad_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vad_map_17_08.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vad_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vad_map_17_09.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vad_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `vad_map_17_10.json` | Map Sub-Asset (VA) | Map background layer / 3D prop configuration for `vad_` (Ryube / Kyaro / North Sparrow / Tenzan). |
| `val.json` | Map Data (VA) | Core map asset for `val` in Ryube / Kyaro / North Sparrow / Tenzan. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `van.json` | Map Data (VA) | Core map asset for `van` in Ryube / Kyaro / North Sparrow / Tenzan. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |

### <a id="region-vb-toto-mercenary-fort-muse-city-white-deer"></a>Region VB: Toto / Mercenary Fort / Muse City / White Deer (366 files)

| File Name | Subsystem / Type | Technical Role & Grounded Description |
|---|---|---|
| `vb01.json` | Map Data (VB) | Core map asset for `vb01` in Toto / Mercenary Camp / Muse City / White Deer. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vb01_02.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb01` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb01_03.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb01` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb01_map_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb01` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb02.json` | Map Data (VB) | Core map asset for `vb02` in Toto / Mercenary Camp / Muse City / White Deer. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vb02_03.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb02` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb02_04.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb02` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb02_05.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb02` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb02_07.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb02` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb02_08.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb02` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb02_09.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb02` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb02_11.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb02` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb02_12.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb02` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb02_14.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb02` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb02_15.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb02` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb02_16.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb02` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb02_17.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb02` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb02_map_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb02` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb03.json` | Map Data (VB) | Core map asset for `vb03` in Toto / Mercenary Camp / Muse City / White Deer. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vb03_02.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb03` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb03_03.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb03` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb03_04.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb03` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb03_07.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb03` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb03_08.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb03` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb03_09.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb03` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb03_10.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb03` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb03_11.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb03` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb03_12.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb03` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb03_13.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb03` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb03_14.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb03` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb03_15.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb03` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb03_16.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb03` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb03_17.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb03` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb03_18.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb03` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb03_19.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb03` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb03_20.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb03` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb03_21.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb03` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb03_22.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb03` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb03_23.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb03` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb03_24.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb03` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb03_25.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb03` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb03_26.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb03` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb03_27.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb03` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb03_map_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb03` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb03_map_01.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb03` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb04.json` | Map Data (VB) | Core map asset for `vb04` in Toto / Mercenary Camp / Muse City / White Deer. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vb04_05.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb04` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb04_06.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb04` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb04_08.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb04` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb04_11.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb04` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb04_map_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb04` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb05.json` | Map Data (VB) | Core map asset for `vb05` in Toto / Mercenary Camp / Muse City / White Deer. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vb05_01.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb05` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb05_02.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb05` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb05_03.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb05` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb05_04.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb05` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb05_12.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb05` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb05_13.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb05` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb05_14.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb05` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb05_16.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb05` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb05_18.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb05` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb05_19.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb05` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb05_21.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb05` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb05_22.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb05` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb05_23.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb05` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb05_24.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb05` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb05_25.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb05` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb05_26.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb05` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb05_map_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb05` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb05_map_01.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb05` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb06.json` | Map Data (VB) | Core map asset for `vb06` in Toto / Mercenary Camp / Muse City / White Deer. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vb06_01.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb06` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb06_03.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb06` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb06_07.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb06` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb06_map_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb06` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb07.json` | Map Data (VB) | Core map asset for `vb07` in Toto / Mercenary Camp / Muse City / White Deer. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vb07_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb07` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb07_00_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb07` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb07_00_01.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb07` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb07_00_02.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb07` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb07_00_03.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb07` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb07_00_06.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb07` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb07_00_08.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb07` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb07_00_11.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb07` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb07_00_13.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb07` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb07_00_obj.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb07` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb07_01.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb07` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb07_02.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb07` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb07_04.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb07` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb07_05.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb07` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb07_map_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb07` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb08.json` | Map Data (VB) | Core map asset for `vb08` in Toto / Mercenary Camp / Muse City / White Deer. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vb08_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb08` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb08_00_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb08` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb08_00_01.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb08` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb08_00_02.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb08` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb08_00_03.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb08` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb08_00_04.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb08` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb08_00_05.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb08` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb08_00_06.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb08` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb08_00_07.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb08` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb08_00_08.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb08` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb08_map_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb08` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb09.json` | Map Data (VB) | Core map asset for `vb09` in Toto / Mercenary Camp / Muse City / White Deer. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vb09_01.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb09` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb09_map_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb09` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb09_map_01.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb09` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb1.json` | Map Data (VB) | Core map asset for `vb1` in Toto / Mercenary Camp / Muse City / White Deer. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vb10.json` | Map Data (VB) | Core map asset for `vb10` in Toto / Mercenary Camp / Muse City / White Deer. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vb10_05.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb10` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb10_06.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb10` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb11.json` | Map Data (VB) | Core map asset for `vb11` in Toto / Mercenary Camp / Muse City / White Deer. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vb11_05.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb11` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb11_07.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb11` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb11_09.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb11` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb11_10.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb11` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb11_11.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb11` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb11_12.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb11` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb11_13.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb11` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb11_14.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb11` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb11_15.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb11` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb11_16.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb11` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb11_18.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb11` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb11_20.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb11` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb11_21.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb11` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb11_22.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb11` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb11_23.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb11` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb11_24.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb11` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb11_25.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb11` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb11_etc_10.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb11` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb11_etc_11.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb11` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb11_etc_12.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb11` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb11_etc_map_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb11` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb11_etc_map_01.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb11` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb11_etc_map_02.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb11` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb11_map_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb11` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb11_map_01.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb11` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb11_map_02.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb11` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb12.json` | Map Data (VB) | Core map asset for `vb12` in Toto / Mercenary Camp / Muse City / White Deer. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vb12_02.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb12` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb12_map_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb12` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb12_map_03.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb12` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb13.json` | Map Data (VB) | Core map asset for `vb13` in Toto / Mercenary Camp / Muse City / White Deer. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vb13_01.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb13` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb13_map_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb13` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb14.json` | Map Data (VB) | Core map asset for `vb14` in Toto / Mercenary Camp / Muse City / White Deer. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vb14_map_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb14` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb14_map_01.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb14` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb14_map_02.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb14` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb15.json` | Map Data (VB) | Core map asset for `vb15` in Toto / Mercenary Camp / Muse City / White Deer. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vb15_06.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb15` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb15_07.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb15` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb15_08.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb15` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb15_map_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb15` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb16.json` | Map Data (VB) | Core map asset for `vb16` in Toto / Mercenary Camp / Muse City / White Deer. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vb16_01.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb16` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb16_04.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb16` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb16_08.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb16` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb16_map_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb16` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb17.json` | Map Data (VB) | Core map asset for `vb17` in Toto / Mercenary Camp / Muse City / White Deer. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vb17_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb17` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb17_00_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb17` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb17_00_01.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb17` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb17_00_02.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb17` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb17_00_03.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb17` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb17_00_04.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb17` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb17_00_05.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb17` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb17_00_06.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb17` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb17_00_07.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb17` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb17_00_08.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb17` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb17_01.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb17` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb17_01_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb17` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb17_01_01.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb17` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb17_01_03.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb17` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb17_01_04.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb17` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb17_01_05.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb17` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb17_01_07.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb17` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb18.json` | Map Data (VB) | Core map asset for `vb18` in Toto / Mercenary Camp / Muse City / White Deer. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vb18_03.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb18` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb18_04.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb18` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb18_05.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb18` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb18_06.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb18` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb18_07.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb18` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb18_08.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb18` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb18_09.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb18` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb18_10.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb18` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb18_20.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb18` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb18_26.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb18` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb19.json` | Map Data (VB) | Core map asset for `vb19` in Toto / Mercenary Camp / Muse City / White Deer. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vb19_04.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb19` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb1_map_01_01.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb1_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb1_map_05_06.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb1_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb1_map_05_battle_01.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb1_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb1_map_05_battle_01_field.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb1_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb1_map_05_battle_01_field_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb1_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb1_map_05_battle_01_field_srn.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb1_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb1_map_05_battle_01_monster_data_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb1_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb1_map_05_battle_01_monster_data_01.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb1_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb1_map_05_battle_01_monster_party_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb1_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb2.json` | Map Data (VB) | Core map asset for `vb2` in Toto / Mercenary Camp / Muse City / White Deer. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vb20.json` | Map Data (VB) | Core map asset for `vb20` in Toto / Mercenary Camp / Muse City / White Deer. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vb20_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb20` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb20_01.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb20` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb20_02.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb20` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb20_03.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb20` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb20_04.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb20` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb20_map_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb20` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb21.json` | Map Data (VB) | Core map asset for `vb21` in Toto / Mercenary Camp / Muse City / White Deer. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vb21_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb21` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb21_00_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb21` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb21_00_01.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb21` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb21_00_02.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb21` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb21_00_03.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb21` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb21_00_04.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb21` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb21_00_05.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb21` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb21_00_06.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb21` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb21_03.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb21` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb2_map_00_06.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb2_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb2_map_06_03.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb2_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb3.json` | Map Data (VB) | Core map asset for `vb3` in Toto / Mercenary Camp / Muse City / White Deer. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vb3_map_00_03.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb3_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb3_map_05_battle_02.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb3_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb3_map_05_battle_02_field.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb3_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb3_map_05_battle_02_field_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb3_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb3_map_05_battle_02_field_srn.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb3_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb3_map_05_battle_02_monster_data_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb3_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb3_map_05_battle_02_monster_data_00_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb3_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb3_map_05_battle_02_monster_data_01.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb3_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb3_map_05_battle_02_monster_data_01_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb3_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb3_map_05_battle_02_monster_data_02.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb3_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb3_map_05_battle_02_monster_data_02_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb3_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb3_map_05_battle_02_monster_data_03.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb3_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb3_map_05_battle_02_monster_party_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb3_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb3_map_13_01.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb3_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb3_map_13_battle_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb3_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb3_map_13_battle_00_monster_party_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb3_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb3_map_13_battle_00_monster_party_01.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb3_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb3_map_13_battle_00_monster_party_02.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb3_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb3_map_17_01.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb3_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb3_map_17_battle_01.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb3_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb3_map_17_battle_01_monster_party_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb3_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb4.json` | Map Data (VB) | Core map asset for `vb4` in Toto / Mercenary Camp / Muse City / White Deer. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vb5.json` | Map Data (VB) | Core map asset for `vb5` in Toto / Mercenary Camp / Muse City / White Deer. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vb5_map_14_battle_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5_map_14_battle_00_field.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5_map_14_battle_00_field_srn.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5_map_14_battle_00_monster_data_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5_map_14_battle_00_monster_data_00_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5_map_14_battle_00_monster_data_01.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5_map_14_battle_00_monster_data_01_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5_map_14_battle_00_monster_data_02.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5_map_14_battle_00_monster_data_02_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5_map_14_battle_00_monster_party_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5_map_14_battle_00_monster_party_02.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5_map_14_battle_00_monster_party_03.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5_map_14_battle_00_monster_party_04.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5_map_14_battle_00_monster_party_05.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5_map_14_battle_00_monster_party_06.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5a1.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5a` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5a1_map_01_02.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5a` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5a2.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5a` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5a2_map_00_11.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5a` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5a2_map_08_11.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5a` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5a2_map_08_battle_01.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5a` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5a2_map_08_battle_01_field.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5a` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5a2_map_08_battle_01_field_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5a` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5a2_map_08_battle_01_field_srn.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5a` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5a2_map_08_battle_01_monster_data_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5a` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5a2_map_08_battle_01_monster_data_00_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5a` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5a2_map_08_battle_01_monster_party_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5a` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5ab.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5a` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5ag.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5a` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5ag_map_00_06.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5a` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5ag_map_02_01.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5a` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5b1.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5b` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5b1_map_00_07.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5b` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5b1_map_00_09.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5b` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5b2.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5b` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5b2_map_00_03.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5b` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5b2_map_00_05.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5b` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5b2_map_08_02.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5b` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5b3.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5b` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5b3_map_00_02.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5b` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5b3_map_06_04.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5b` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5b4.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5b` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5ba.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5b` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5ba_map_03_02.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5b` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5ba_map_03_03.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5b` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5ba_map_03_04.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5b` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5bb.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5b` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5bb_map_02_02.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5b` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5bg.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5b` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5bg_map_02_09.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5b` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5bg_map_03_04.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5b` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5bg_map_03_05.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5b` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5bg_map_03_06.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5b` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5c1.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5c` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5c1_map_00_04.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5c` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5c2.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5c` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5c3.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5c` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5c3_map_00_06.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5c` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5c3_map_00_08.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5c` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5c4.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5c` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5c4_map_03_04.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5c` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5c4_map_03_05.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5c` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5ca.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5c` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5ca_map_02_04.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5c` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5ca_map_03_05.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5c` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5ca_map_03_06.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5c` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5cb.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5c` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5cc.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5c` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5cg.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5c` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5cg_map_00_02.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5c` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5g.json` | Map Data (VB) | Core map asset for `vb5g` in Toto / Mercenary Camp / Muse City / White Deer. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vb5g_map_01_01.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5g` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5g_map_01_battle_01.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5g` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5g_map_01_battle_01_field.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5g` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5g_map_01_battle_01_field_srn.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5g` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5g_map_01_battle_01_monster_data_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5g` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5g_map_01_battle_01_monster_data_00_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5g` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5g_map_01_battle_01_monster_party_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5g` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5i0.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5i` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5i2.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5i` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5i3.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5i` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb5i4.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb5i` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb6.json` | Map Data (VB) | Core map asset for `vb6` in Toto / Mercenary Camp / Muse City / White Deer. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vb6_map_00_02.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb6_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb6_map_01_battle_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb6_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb6_map_01_battle_00_field.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb6_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb6_map_01_battle_00_field_srn.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb6_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb6_map_01_battle_00_monster_data_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb6_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb6_map_01_battle_00_monster_data_01.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb6_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb6_map_01_battle_00_monster_data_02.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb6_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb6_map_01_battle_00_monster_data_02_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb6_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb6_map_01_battle_00_monster_data_03.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb6_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb6_map_01_battle_00_monster_data_03_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb6_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb6_map_01_battle_00_monster_data_04.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb6_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb6_map_01_battle_00_monster_party_02.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb6_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb6_map_01_battle_00_monster_party_04.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb6_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb6_map_01_battle_00_monster_party_05.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb6_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb6_map_01_battle_00_monster_party_06.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb6_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb6_map_01_battle_00_monster_party_07.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb6_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb6_map_06_09.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb6_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb6_map_06_10.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb6_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb6_map_06_battle_02.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb6_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb6_map_06_battle_02_monster_party_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb6_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb7.json` | Map Data (VB) | Core map asset for `vb7` in Toto / Mercenary Camp / Muse City / White Deer. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vb7a.json` | Map Data (VB) | Core map asset for `vb7a` in Toto / Mercenary Camp / Muse City / White Deer. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vb7d.json` | Map Data (VB) | Core map asset for `vb7d` in Toto / Mercenary Camp / Muse City / White Deer. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vb7d_map_00_07.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb7d` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb7d_map_00_08.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb7d` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb7d_map_00_09.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb7d` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb7d_map_01_08.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb7d` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb8.json` | Map Data (VB) | Core map asset for `vb8` in Toto / Mercenary Camp / Muse City / White Deer. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vb8_map_01_battle_01.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb8_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb8_map_01_battle_01_field.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb8_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb8_map_01_battle_01_field_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb8_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb8_map_01_battle_01_field_srn.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb8_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb8_map_01_battle_01_monster_data_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb8_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb8_map_01_battle_01_monster_data_00_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb8_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb8_map_01_battle_01_monster_data_01.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb8_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb8_map_01_battle_01_monster_data_01_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb8_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb8_map_01_battle_01_monster_data_02.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb8_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb8_map_01_battle_01_monster_data_02_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb8_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb8_map_01_battle_01_monster_party_00.json` | Map Sub-Asset (VB) | Map background layer / 3D prop configuration for `vb8_` (Toto / Mercenary Camp / Muse City / White Deer). |
| `vb9.json` | Map Data (VB) | Core map asset for `vb9` in Toto / Mercenary Camp / Muse City / White Deer. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |

### <a id="region-vc-coronet-kuskus-south-window-radat"></a>Region VC: Coronet / Kuskus / South Window / Radat (318 files)

| File Name | Subsystem / Type | Technical Role & Grounded Description |
|---|---|---|
| `vc01.json` | Map Data (VC) | Core map asset for `vc01` in Coronet / Kuskus / South Window / Radat. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vc01_03.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc01` (Coronet / Kuskus / South Window / Radat). |
| `vc01_04.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc01` (Coronet / Kuskus / South Window / Radat). |
| `vc01_05.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc01` (Coronet / Kuskus / South Window / Radat). |
| `vc01_07.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc01` (Coronet / Kuskus / South Window / Radat). |
| `vc01_09.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc01` (Coronet / Kuskus / South Window / Radat). |
| `vc01_10.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc01` (Coronet / Kuskus / South Window / Radat). |
| `vc01_11.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc01` (Coronet / Kuskus / South Window / Radat). |
| `vc01_12.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc01` (Coronet / Kuskus / South Window / Radat). |
| `vc01_14.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc01` (Coronet / Kuskus / South Window / Radat). |
| `vc01_21.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc01` (Coronet / Kuskus / South Window / Radat). |
| `vc01_27.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc01` (Coronet / Kuskus / South Window / Radat). |
| `vc01_28.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc01` (Coronet / Kuskus / South Window / Radat). |
| `vc01_30.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc01` (Coronet / Kuskus / South Window / Radat). |
| `vc01_map_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc01` (Coronet / Kuskus / South Window / Radat). |
| `vc01_map_01.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc01` (Coronet / Kuskus / South Window / Radat). |
| `vc02.json` | Map Data (VC) | Core map asset for `vc02` in Coronet / Kuskus / South Window / Radat. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vc02_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc02` (Coronet / Kuskus / South Window / Radat). |
| `vc02_00_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc02` (Coronet / Kuskus / South Window / Radat). |
| `vc02_00_01.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc02` (Coronet / Kuskus / South Window / Radat). |
| `vc02_00_02.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc02` (Coronet / Kuskus / South Window / Radat). |
| `vc02_00_03.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc02` (Coronet / Kuskus / South Window / Radat). |
| `vc02_00_05.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc02` (Coronet / Kuskus / South Window / Radat). |
| `vc02_00_obj.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc02` (Coronet / Kuskus / South Window / Radat). |
| `vc02_map_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc02` (Coronet / Kuskus / South Window / Radat). |
| `vc02_map_01.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc02` (Coronet / Kuskus / South Window / Radat). |
| `vc02_map_02.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc02` (Coronet / Kuskus / South Window / Radat). |
| `vc03.json` | Map Data (VC) | Core map asset for `vc03` in Coronet / Kuskus / South Window / Radat. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vc03_04.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc03` (Coronet / Kuskus / South Window / Radat). |
| `vc03_map_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc03` (Coronet / Kuskus / South Window / Radat). |
| `vc04.json` | Map Data (VC) | Core map asset for `vc04` in Coronet / Kuskus / South Window / Radat. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vc04_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc04` (Coronet / Kuskus / South Window / Radat). |
| `vc04_02.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc04` (Coronet / Kuskus / South Window / Radat). |
| `vc04_03.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc04` (Coronet / Kuskus / South Window / Radat). |
| `vc04_04.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc04` (Coronet / Kuskus / South Window / Radat). |
| `vc04_08.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc04` (Coronet / Kuskus / South Window / Radat). |
| `vc04_09.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc04` (Coronet / Kuskus / South Window / Radat). |
| `vc04_10.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc04` (Coronet / Kuskus / South Window / Radat). |
| `vc04_map_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc04` (Coronet / Kuskus / South Window / Radat). |
| `vc04_map_01.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc04` (Coronet / Kuskus / South Window / Radat). |
| `vc05.json` | Map Data (VC) | Core map asset for `vc05` in Coronet / Kuskus / South Window / Radat. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vc05_01.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc05` (Coronet / Kuskus / South Window / Radat). |
| `vc06.json` | Map Data (VC) | Core map asset for `vc06` in Coronet / Kuskus / South Window / Radat. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vc06_04.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc06` (Coronet / Kuskus / South Window / Radat). |
| `vc06_08.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc06` (Coronet / Kuskus / South Window / Radat). |
| `vc06_09.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc06` (Coronet / Kuskus / South Window / Radat). |
| `vc06_13.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc06` (Coronet / Kuskus / South Window / Radat). |
| `vc06_14.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc06` (Coronet / Kuskus / South Window / Radat). |
| `vc06_16.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc06` (Coronet / Kuskus / South Window / Radat). |
| `vc06_18.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc06` (Coronet / Kuskus / South Window / Radat). |
| `vc06_19.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc06` (Coronet / Kuskus / South Window / Radat). |
| `vc06_21.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc06` (Coronet / Kuskus / South Window / Radat). |
| `vc06_22.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc06` (Coronet / Kuskus / South Window / Radat). |
| `vc06_23.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc06` (Coronet / Kuskus / South Window / Radat). |
| `vc06_26.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc06` (Coronet / Kuskus / South Window / Radat). |
| `vc06_map_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc06` (Coronet / Kuskus / South Window / Radat). |
| `vc06_map_01.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc06` (Coronet / Kuskus / South Window / Radat). |
| `vc07.json` | Map Data (VC) | Core map asset for `vc07` in Coronet / Kuskus / South Window / Radat. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vc07_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc07` (Coronet / Kuskus / South Window / Radat). |
| `vc07_00_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc07` (Coronet / Kuskus / South Window / Radat). |
| `vc07_00_01.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc07` (Coronet / Kuskus / South Window / Radat). |
| `vc07_00_02.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc07` (Coronet / Kuskus / South Window / Radat). |
| `vc07_00_03.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc07` (Coronet / Kuskus / South Window / Radat). |
| `vc07_00_04.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc07` (Coronet / Kuskus / South Window / Radat). |
| `vc07_00_08.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc07` (Coronet / Kuskus / South Window / Radat). |
| `vc07_00_10.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc07` (Coronet / Kuskus / South Window / Radat). |
| `vc07_00_11.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc07` (Coronet / Kuskus / South Window / Radat). |
| `vc07_00_12.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc07` (Coronet / Kuskus / South Window / Radat). |
| `vc07_00_obj.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc07` (Coronet / Kuskus / South Window / Radat). |
| `vc07_etc_10.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc07` (Coronet / Kuskus / South Window / Radat). |
| `vc07_etc_11.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc07` (Coronet / Kuskus / South Window / Radat). |
| `vc07_map_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc07` (Coronet / Kuskus / South Window / Radat). |
| `vc08.json` | Map Data (VC) | Core map asset for `vc08` in Coronet / Kuskus / South Window / Radat. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vc08_02.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc08` (Coronet / Kuskus / South Window / Radat). |
| `vc08_map_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc08` (Coronet / Kuskus / South Window / Radat). |
| `vc09.json` | Map Data (VC) | Core map asset for `vc09` in Coronet / Kuskus / South Window / Radat. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vc09_01.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc09` (Coronet / Kuskus / South Window / Radat). |
| `vc09_02.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc09` (Coronet / Kuskus / South Window / Radat). |
| `vc09_03.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc09` (Coronet / Kuskus / South Window / Radat). |
| `vc09_04.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc09` (Coronet / Kuskus / South Window / Radat). |
| `vc09_05.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc09` (Coronet / Kuskus / South Window / Radat). |
| `vc09_06.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc09` (Coronet / Kuskus / South Window / Radat). |
| `vc09_07.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc09` (Coronet / Kuskus / South Window / Radat). |
| `vc09_10.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc09` (Coronet / Kuskus / South Window / Radat). |
| `vc09_14.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc09` (Coronet / Kuskus / South Window / Radat). |
| `vc09_17.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc09` (Coronet / Kuskus / South Window / Radat). |
| `vc09_19.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc09` (Coronet / Kuskus / South Window / Radat). |
| `vc09_20.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc09` (Coronet / Kuskus / South Window / Radat). |
| `vc09_21.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc09` (Coronet / Kuskus / South Window / Radat). |
| `vc09_22.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc09` (Coronet / Kuskus / South Window / Radat). |
| `vc09_map_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc09` (Coronet / Kuskus / South Window / Radat). |
| `vc1.json` | Map Data (VC) | Core map asset for `vc1` in Coronet / Kuskus / South Window / Radat. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vc10.json` | Map Data (VC) | Core map asset for `vc10` in Coronet / Kuskus / South Window / Radat. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vc10_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc10` (Coronet / Kuskus / South Window / Radat). |
| `vc10_04.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc10` (Coronet / Kuskus / South Window / Radat). |
| `vc10_05.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc10` (Coronet / Kuskus / South Window / Radat). |
| `vc10_06.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc10` (Coronet / Kuskus / South Window / Radat). |
| `vc10_10.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc10` (Coronet / Kuskus / South Window / Radat). |
| `vc10_11.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc10` (Coronet / Kuskus / South Window / Radat). |
| `vc10_12.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc10` (Coronet / Kuskus / South Window / Radat). |
| `vc10_13.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc10` (Coronet / Kuskus / South Window / Radat). |
| `vc10_14.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc10` (Coronet / Kuskus / South Window / Radat). |
| `vc10_18.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc10` (Coronet / Kuskus / South Window / Radat). |
| `vc10_20.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc10` (Coronet / Kuskus / South Window / Radat). |
| `vc10_26.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc10` (Coronet / Kuskus / South Window / Radat). |
| `vc10_27.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc10` (Coronet / Kuskus / South Window / Radat). |
| `vc10_28.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc10` (Coronet / Kuskus / South Window / Radat). |
| `vc10_29.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc10` (Coronet / Kuskus / South Window / Radat). |
| `vc10_map_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc10` (Coronet / Kuskus / South Window / Radat). |
| `vc10_map_01.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc10` (Coronet / Kuskus / South Window / Radat). |
| `vc11.json` | Map Data (VC) | Core map asset for `vc11` in Coronet / Kuskus / South Window / Radat. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vc11_08.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc11` (Coronet / Kuskus / South Window / Radat). |
| `vc11_11.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc11` (Coronet / Kuskus / South Window / Radat). |
| `vc11_map_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc11` (Coronet / Kuskus / South Window / Radat). |
| `vc12.json` | Map Data (VC) | Core map asset for `vc12` in Coronet / Kuskus / South Window / Radat. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vc12_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc12` (Coronet / Kuskus / South Window / Radat). |
| `vc12_00_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc12` (Coronet / Kuskus / South Window / Radat). |
| `vc12_00_01.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc12` (Coronet / Kuskus / South Window / Radat). |
| `vc12_00_02.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc12` (Coronet / Kuskus / South Window / Radat). |
| `vc12_00_03.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc12` (Coronet / Kuskus / South Window / Radat). |
| `vc12_00_04.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc12` (Coronet / Kuskus / South Window / Radat). |
| `vc12_00_05.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc12` (Coronet / Kuskus / South Window / Radat). |
| `vc12_00_06.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc12` (Coronet / Kuskus / South Window / Radat). |
| `vc12_00_obj.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc12` (Coronet / Kuskus / South Window / Radat). |
| `vc12_map_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc12` (Coronet / Kuskus / South Window / Radat). |
| `vc12_map_09.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc12` (Coronet / Kuskus / South Window / Radat). |
| `vc13.json` | Map Data (VC) | Core map asset for `vc13` in Coronet / Kuskus / South Window / Radat. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vc13_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc13` (Coronet / Kuskus / South Window / Radat). |
| `vc13_00_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc13` (Coronet / Kuskus / South Window / Radat). |
| `vc13_00_01.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc13` (Coronet / Kuskus / South Window / Radat). |
| `vc13_00_02.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc13` (Coronet / Kuskus / South Window / Radat). |
| `vc13_00_03.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc13` (Coronet / Kuskus / South Window / Radat). |
| `vc13_00_04.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc13` (Coronet / Kuskus / South Window / Radat). |
| `vc13_00_05.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc13` (Coronet / Kuskus / South Window / Radat). |
| `vc13_00_06.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc13` (Coronet / Kuskus / South Window / Radat). |
| `vc13_00_07.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc13` (Coronet / Kuskus / South Window / Radat). |
| `vc13_00_obj.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc13` (Coronet / Kuskus / South Window / Radat). |
| `vc13_01.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc13` (Coronet / Kuskus / South Window / Radat). |
| `vc13_map_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc13` (Coronet / Kuskus / South Window / Radat). |
| `vc13_map_09.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc13` (Coronet / Kuskus / South Window / Radat). |
| `vc14.json` | Map Data (VC) | Core map asset for `vc14` in Coronet / Kuskus / South Window / Radat. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vc14_map_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc14` (Coronet / Kuskus / South Window / Radat). |
| `vc15.json` | Map Data (VC) | Core map asset for `vc15` in Coronet / Kuskus / South Window / Radat. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vc16.json` | Map Data (VC) | Core map asset for `vc16` in Coronet / Kuskus / South Window / Radat. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vc16_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc16` (Coronet / Kuskus / South Window / Radat). |
| `vc16_00_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc16` (Coronet / Kuskus / South Window / Radat). |
| `vc16_00_01.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc16` (Coronet / Kuskus / South Window / Radat). |
| `vc16_00_02.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc16` (Coronet / Kuskus / South Window / Radat). |
| `vc16_00_obj.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc16` (Coronet / Kuskus / South Window / Radat). |
| `vc16_04.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc16` (Coronet / Kuskus / South Window / Radat). |
| `vc17.json` | Map Data (VC) | Core map asset for `vc17` in Coronet / Kuskus / South Window / Radat. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vc17_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc17` (Coronet / Kuskus / South Window / Radat). |
| `vc17_04.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc17` (Coronet / Kuskus / South Window / Radat). |
| `vc17_05.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc17` (Coronet / Kuskus / South Window / Radat). |
| `vc17_map_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc17` (Coronet / Kuskus / South Window / Radat). |
| `vc18.json` | Map Data (VC) | Core map asset for `vc18` in Coronet / Kuskus / South Window / Radat. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vc18_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc18` (Coronet / Kuskus / South Window / Radat). |
| `vc18_08.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc18` (Coronet / Kuskus / South Window / Radat). |
| `vc18_09.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc18` (Coronet / Kuskus / South Window / Radat). |
| `vc18_map_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc18` (Coronet / Kuskus / South Window / Radat). |
| `vc19.json` | Map Data (VC) | Core map asset for `vc19` in Coronet / Kuskus / South Window / Radat. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vc19_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc19` (Coronet / Kuskus / South Window / Radat). |
| `vc19_01.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc19` (Coronet / Kuskus / South Window / Radat). |
| `vc19_02.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc19` (Coronet / Kuskus / South Window / Radat). |
| `vc19_map_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc19` (Coronet / Kuskus / South Window / Radat). |
| `vc1_map_00_battle_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc1_` (Coronet / Kuskus / South Window / Radat). |
| `vc1_map_00_battle_00_field.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc1_` (Coronet / Kuskus / South Window / Radat). |
| `vc1_map_00_battle_00_field_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc1_` (Coronet / Kuskus / South Window / Radat). |
| `vc1_map_00_battle_00_field_srn.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc1_` (Coronet / Kuskus / South Window / Radat). |
| `vc1_map_00_battle_00_monster_data_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc1_` (Coronet / Kuskus / South Window / Radat). |
| `vc1_map_00_battle_00_monster_data_00_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc1_` (Coronet / Kuskus / South Window / Radat). |
| `vc1_map_00_battle_00_monster_data_01.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc1_` (Coronet / Kuskus / South Window / Radat). |
| `vc1_map_00_battle_00_monster_data_01_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc1_` (Coronet / Kuskus / South Window / Radat). |
| `vc1_map_00_battle_00_monster_data_02.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc1_` (Coronet / Kuskus / South Window / Radat). |
| `vc1_map_00_battle_00_monster_data_02_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc1_` (Coronet / Kuskus / South Window / Radat). |
| `vc1_map_00_battle_00_monster_party_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc1_` (Coronet / Kuskus / South Window / Radat). |
| `vc1_map_00_battle_00_monster_party_06.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc1_` (Coronet / Kuskus / South Window / Radat). |
| `vc1_map_00_battle_00_monster_party_09.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc1_` (Coronet / Kuskus / South Window / Radat). |
| `vc1_map_00_battle_00_monster_party_10.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc1_` (Coronet / Kuskus / South Window / Radat). |
| `vc1_map_00_battle_00_monster_party_11.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc1_` (Coronet / Kuskus / South Window / Radat). |
| `vc1_map_00_battle_00_monster_party_12.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc1_` (Coronet / Kuskus / South Window / Radat). |
| `vc1_map_00_battle_00_monster_party_13.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc1_` (Coronet / Kuskus / South Window / Radat). |
| `vc1_map_05_battle_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc1_` (Coronet / Kuskus / South Window / Radat). |
| `vc1_map_05_battle_00_field.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc1_` (Coronet / Kuskus / South Window / Radat). |
| `vc1_map_05_battle_00_field_srn.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc1_` (Coronet / Kuskus / South Window / Radat). |
| `vc1_map_09_battle_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc1_` (Coronet / Kuskus / South Window / Radat). |
| `vc1_map_09_battle_00_field.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc1_` (Coronet / Kuskus / South Window / Radat). |
| `vc1_map_09_battle_00_field_srn.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc1_` (Coronet / Kuskus / South Window / Radat). |
| `vc2.json` | Map Data (VC) | Core map asset for `vc2` in Coronet / Kuskus / South Window / Radat. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vc20.json` | Map Data (VC) | Core map asset for `vc20` in Coronet / Kuskus / South Window / Radat. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vc20_03.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc20` (Coronet / Kuskus / South Window / Radat). |
| `vc20_05.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc20` (Coronet / Kuskus / South Window / Radat). |
| `vc20_06.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc20` (Coronet / Kuskus / South Window / Radat). |
| `vc20_map_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc20` (Coronet / Kuskus / South Window / Radat). |
| `vc21.json` | Map Data (VC) | Core map asset for `vc21` in Coronet / Kuskus / South Window / Radat. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vc21_08.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc21` (Coronet / Kuskus / South Window / Radat). |
| `vc21_09.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc21` (Coronet / Kuskus / South Window / Radat). |
| `vc21_11.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc21` (Coronet / Kuskus / South Window / Radat). |
| `vc21_12.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc21` (Coronet / Kuskus / South Window / Radat). |
| `vc21_13.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc21` (Coronet / Kuskus / South Window / Radat). |
| `vc21_14.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc21` (Coronet / Kuskus / South Window / Radat). |
| `vc21_17.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc21` (Coronet / Kuskus / South Window / Radat). |
| `vc21_30.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc21` (Coronet / Kuskus / South Window / Radat). |
| `vc21_31.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc21` (Coronet / Kuskus / South Window / Radat). |
| `vc21_32.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc21` (Coronet / Kuskus / South Window / Radat). |
| `vc21_34.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc21` (Coronet / Kuskus / South Window / Radat). |
| `vc21_map_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc21` (Coronet / Kuskus / South Window / Radat). |
| `vc22.json` | Map Data (VC) | Core map asset for `vc22` in Coronet / Kuskus / South Window / Radat. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vc23.json` | Map Data (VC) | Core map asset for `vc23` in Coronet / Kuskus / South Window / Radat. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vc23_02.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc23` (Coronet / Kuskus / South Window / Radat). |
| `vc23_map_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc23` (Coronet / Kuskus / South Window / Radat). |
| `vc24.json` | Map Data (VC) | Core map asset for `vc24` in Coronet / Kuskus / South Window / Radat. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vc24_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc24` (Coronet / Kuskus / South Window / Radat). |
| `vc24_00_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc24` (Coronet / Kuskus / South Window / Radat). |
| `vc24_00_01.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc24` (Coronet / Kuskus / South Window / Radat). |
| `vc24_00_02.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc24` (Coronet / Kuskus / South Window / Radat). |
| `vc24_00_03.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc24` (Coronet / Kuskus / South Window / Radat). |
| `vc25.json` | Map Data (VC) | Core map asset for `vc25` in Coronet / Kuskus / South Window / Radat. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vc25_03.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc25` (Coronet / Kuskus / South Window / Radat). |
| `vc25_07.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc25` (Coronet / Kuskus / South Window / Radat). |
| `vc26.json` | Map Data (VC) | Core map asset for `vc26` in Coronet / Kuskus / South Window / Radat. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vc27.json` | Map Data (VC) | Core map asset for `vc27` in Coronet / Kuskus / South Window / Radat. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vc27_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc27` (Coronet / Kuskus / South Window / Radat). |
| `vc28.json` | Map Data (VC) | Core map asset for `vc28` in Coronet / Kuskus / South Window / Radat. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vc28_06.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc28` (Coronet / Kuskus / South Window / Radat). |
| `vc28_07.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc28` (Coronet / Kuskus / South Window / Radat). |
| `vc28_08.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc28` (Coronet / Kuskus / South Window / Radat). |
| `vc28_09.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc28` (Coronet / Kuskus / South Window / Radat). |
| `vc29.json` | Map Data (VC) | Core map asset for `vc29` in Coronet / Kuskus / South Window / Radat. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vc2_map_00_01.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc2_` (Coronet / Kuskus / South Window / Radat). |
| `vc2_map_00_02.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc2_` (Coronet / Kuskus / South Window / Radat). |
| `vc2_map_00_03.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc2_` (Coronet / Kuskus / South Window / Radat). |
| `vc2_map_00_04.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc2_` (Coronet / Kuskus / South Window / Radat). |
| `vc2_map_05_02.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc2_` (Coronet / Kuskus / South Window / Radat). |
| `vc3.json` | Map Data (VC) | Core map asset for `vc3` in Coronet / Kuskus / South Window / Radat. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vc30.json` | Map Data (VC) | Core map asset for `vc30` in Coronet / Kuskus / South Window / Radat. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vc30_01.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc30` (Coronet / Kuskus / South Window / Radat). |
| `vc31.json` | Map Data (VC) | Core map asset for `vc31` in Coronet / Kuskus / South Window / Radat. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vc31_01.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc31` (Coronet / Kuskus / South Window / Radat). |
| `vc31_02.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc31` (Coronet / Kuskus / South Window / Radat). |
| `vc3_map_00_01.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc3_` (Coronet / Kuskus / South Window / Radat). |
| `vc3_map_01_battle_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc3_` (Coronet / Kuskus / South Window / Radat). |
| `vc3_map_01_battle_00_field.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc3_` (Coronet / Kuskus / South Window / Radat). |
| `vc3_map_01_battle_00_field_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc3_` (Coronet / Kuskus / South Window / Radat). |
| `vc3_map_01_battle_00_field_srn.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc3_` (Coronet / Kuskus / South Window / Radat). |
| `vc3_map_01_battle_00_monster_data_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc3_` (Coronet / Kuskus / South Window / Radat). |
| `vc3_map_01_battle_00_monster_data_00_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc3_` (Coronet / Kuskus / South Window / Radat). |
| `vc3_map_01_battle_00_monster_data_01.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc3_` (Coronet / Kuskus / South Window / Radat). |
| `vc3_map_01_battle_00_monster_data_01_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc3_` (Coronet / Kuskus / South Window / Radat). |
| `vc3_map_01_battle_00_monster_data_02.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc3_` (Coronet / Kuskus / South Window / Radat). |
| `vc3_map_01_battle_00_monster_data_03.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc3_` (Coronet / Kuskus / South Window / Radat). |
| `vc3_map_01_battle_00_monster_data_03_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc3_` (Coronet / Kuskus / South Window / Radat). |
| `vc3_map_01_battle_00_monster_party_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc3_` (Coronet / Kuskus / South Window / Radat). |
| `vc3_map_01_battle_00_monster_party_01.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc3_` (Coronet / Kuskus / South Window / Radat). |
| `vc3_map_01_battle_00_monster_party_02.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc3_` (Coronet / Kuskus / South Window / Radat). |
| `vc3_map_01_battle_00_monster_party_03.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc3_` (Coronet / Kuskus / South Window / Radat). |
| `vc3_map_01_battle_00_monster_party_04.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc3_` (Coronet / Kuskus / South Window / Radat). |
| `vc3_map_01_battle_00_monster_party_05.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc3_` (Coronet / Kuskus / South Window / Radat). |
| `vc3_map_01_battle_00_monster_party_06.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc3_` (Coronet / Kuskus / South Window / Radat). |
| `vc3_map_01_battle_00_monster_party_07.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc3_` (Coronet / Kuskus / South Window / Radat). |
| `vc3_map_01_battle_00_monster_party_08.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc3_` (Coronet / Kuskus / South Window / Radat). |
| `vc3_map_01_battle_00_monster_party_09.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc3_` (Coronet / Kuskus / South Window / Radat). |
| `vc3_map_01_battle_00_monster_party_10.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc3_` (Coronet / Kuskus / South Window / Radat). |
| `vc3_map_01_battle_00_monster_party_11.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc3_` (Coronet / Kuskus / South Window / Radat). |
| `vc3_map_01_battle_00_monster_party_13.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc3_` (Coronet / Kuskus / South Window / Radat). |
| `vc3_map_04_battle_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc3_` (Coronet / Kuskus / South Window / Radat). |
| `vc3_map_04_battle_00_field.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc3_` (Coronet / Kuskus / South Window / Radat). |
| `vc3_map_04_battle_00_field_srn.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc3_` (Coronet / Kuskus / South Window / Radat). |
| `vc3_map_09_battle_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc3_` (Coronet / Kuskus / South Window / Radat). |
| `vc3_map_09_battle_00_field.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc3_` (Coronet / Kuskus / South Window / Radat). |
| `vc3_map_09_battle_00_field_srn.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc3_` (Coronet / Kuskus / South Window / Radat). |
| `vc3_map_14_battle_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc3_` (Coronet / Kuskus / South Window / Radat). |
| `vc3_map_14_battle_00_field.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc3_` (Coronet / Kuskus / South Window / Radat). |
| `vc3_map_14_battle_00_field_srn.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc3_` (Coronet / Kuskus / South Window / Radat). |
| `vc3_map_19_battle_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc3_` (Coronet / Kuskus / South Window / Radat). |
| `vc3_map_19_battle_00_field.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc3_` (Coronet / Kuskus / South Window / Radat). |
| `vc3_map_19_battle_00_field_srn.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc3_` (Coronet / Kuskus / South Window / Radat). |
| `vc3_map_29_01.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc3_` (Coronet / Kuskus / South Window / Radat). |
| `vc3_map_29_battle_01.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc3_` (Coronet / Kuskus / South Window / Radat). |
| `vc3_map_29_battle_01_field.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc3_` (Coronet / Kuskus / South Window / Radat). |
| `vc3_map_29_battle_01_monster_data_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc3_` (Coronet / Kuskus / South Window / Radat). |
| `vc3_map_29_battle_01_monster_data_00_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc3_` (Coronet / Kuskus / South Window / Radat). |
| `vc3_map_29_battle_01_monster_party_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc3_` (Coronet / Kuskus / South Window / Radat). |
| `vc3_map_33_01.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc3_` (Coronet / Kuskus / South Window / Radat). |
| `vc4.json` | Map Data (VC) | Core map asset for `vc4` in Coronet / Kuskus / South Window / Radat. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vc4_map_01_02.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc4_` (Coronet / Kuskus / South Window / Radat). |
| `vc4_map_01_03.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc4_` (Coronet / Kuskus / South Window / Radat). |
| `vc4_map_01_04.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc4_` (Coronet / Kuskus / South Window / Radat). |
| `vc5.json` | Map Data (VC) | Core map asset for `vc5` in Coronet / Kuskus / South Window / Radat. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vc5_map_00_02.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc5_` (Coronet / Kuskus / South Window / Radat). |
| `vc5_map_00_03.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc5_` (Coronet / Kuskus / South Window / Radat). |
| `vc6.json` | Map Data (VC) | Core map asset for `vc6` in Coronet / Kuskus / South Window / Radat. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vc6_map_00_01.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc6_` (Coronet / Kuskus / South Window / Radat). |
| `vc6_map_00_09.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc6_` (Coronet / Kuskus / South Window / Radat). |
| `vc6_map_00_10.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc6_` (Coronet / Kuskus / South Window / Radat). |
| `vc6_map_02_battle_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc6_` (Coronet / Kuskus / South Window / Radat). |
| `vc6_map_02_battle_00_field.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc6_` (Coronet / Kuskus / South Window / Radat). |
| `vc6_map_02_battle_00_field_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc6_` (Coronet / Kuskus / South Window / Radat). |
| `vc6_map_02_battle_00_field_srn.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc6_` (Coronet / Kuskus / South Window / Radat). |
| `vc6_map_02_battle_00_monster_data_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc6_` (Coronet / Kuskus / South Window / Radat). |
| `vc6_map_02_battle_00_monster_data_01.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc6_` (Coronet / Kuskus / South Window / Radat). |
| `vc6_map_02_battle_00_monster_data_02.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc6_` (Coronet / Kuskus / South Window / Radat). |
| `vc6_map_02_battle_00_monster_data_03.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc6_` (Coronet / Kuskus / South Window / Radat). |
| `vc6_map_02_battle_00_monster_data_03_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc6_` (Coronet / Kuskus / South Window / Radat). |
| `vc6_map_02_battle_00_monster_data_04.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc6_` (Coronet / Kuskus / South Window / Radat). |
| `vc6_map_02_battle_00_monster_data_04_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc6_` (Coronet / Kuskus / South Window / Radat). |
| `vc6_map_02_battle_00_monster_party_02.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc6_` (Coronet / Kuskus / South Window / Radat). |
| `vc6_map_02_battle_00_monster_party_03.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc6_` (Coronet / Kuskus / South Window / Radat). |
| `vc6_map_02_battle_00_monster_party_06.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc6_` (Coronet / Kuskus / South Window / Radat). |
| `vc6_map_02_battle_00_monster_party_07.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc6_` (Coronet / Kuskus / South Window / Radat). |
| `vc6_map_02_battle_00_monster_party_09.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc6_` (Coronet / Kuskus / South Window / Radat). |
| `vc6_map_13_01.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc6_` (Coronet / Kuskus / South Window / Radat). |
| `vc6_map_13_battle_01.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc6_` (Coronet / Kuskus / South Window / Radat). |
| `vc6_map_13_battle_01_field.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc6_` (Coronet / Kuskus / South Window / Radat). |
| `vc6_map_13_battle_01_field_srn.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc6_` (Coronet / Kuskus / South Window / Radat). |
| `vc6_map_13_battle_01_monster_data_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc6_` (Coronet / Kuskus / South Window / Radat). |
| `vc6_map_13_battle_01_monster_data_00_00.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc6_` (Coronet / Kuskus / South Window / Radat). |
| `vc6_map_14_03.json` | Map Sub-Asset (VC) | Map background layer / 3D prop configuration for `vc6_` (Coronet / Kuskus / South Window / Radat). |

### <a id="region-vd-two-river-kobold-village-lakewest-drakemouth"></a>Region VD: Two River / Kobold Village / Lakewest / Drakemouth (252 files)

| File Name | Subsystem / Type | Technical Role & Grounded Description |
|---|---|---|
| `vd01.json` | Map Data (VD) | Core map asset for `vd01` in Two River / Kobold Village / Lakewest / Drakemouth. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vd01_05.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd01` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd01_06.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd01` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd01_07.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd01` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd01_10.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd01` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd01_11.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd01` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd01_12.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd01` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd01_15.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd01` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd01_17.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd01` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd01_18.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd01` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd01_19.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd01` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd01_21.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd01` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd01_map_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd01` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd01_map_01.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd01` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd02.json` | Map Data (VD) | Core map asset for `vd02` in Two River / Kobold Village / Lakewest / Drakemouth. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vd02_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd02` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd02_01.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd02` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd02_02.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd02` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd02_03.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd02` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd02_04.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd02` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd02_08.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd02` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd02_09.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd02` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd02_10.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd02` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd02_12.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd02` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd02_13.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd02` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd02_15.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd02` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd02_16.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd02` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd02_map_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd02` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd03.json` | Map Data (VD) | Core map asset for `vd03` in Two River / Kobold Village / Lakewest / Drakemouth. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vd03_01.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd03` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd03_02.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd03` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd03_03.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd03` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd03_04.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd03` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd03_06.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd03` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd03_10.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd03` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd03_11.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd03` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd03_16.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd03` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd03_17.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd03` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd03_18.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd03` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd03_23.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd03` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd03_map_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd03` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd04.json` | Map Data (VD) | Core map asset for `vd04` in Two River / Kobold Village / Lakewest / Drakemouth. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vd04_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd04` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd04_01.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd04` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd04_02.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd04` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd04_map_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd04` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd05.json` | Map Data (VD) | Core map asset for `vd05` in Two River / Kobold Village / Lakewest / Drakemouth. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vd05_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd05` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd05_02.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd05` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd05_03.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd05` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd05_04.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd05` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd05_05.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd05` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd05_06.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd05` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd05_19.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd05` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd05_27.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd05` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd05_30.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd05` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd05_31.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd05` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd05_map_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd05` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd06.json` | Map Data (VD) | Core map asset for `vd06` in Two River / Kobold Village / Lakewest / Drakemouth. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vd06_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd06` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd06_00_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd06` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd06_00_01.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd06` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd06_00_02.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd06` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd06_00_03.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd06` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd06_00_04.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd06` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd06_00_05.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd06` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd06_00_06.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd06` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd06_00_07.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd06` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd06_00_08.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd06` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd06_01.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd06` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd06_04.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd06` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd06_map_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd06` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd07.json` | Map Data (VD) | Core map asset for `vd07` in Two River / Kobold Village / Lakewest / Drakemouth. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vd07_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd07` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd07_02.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd07` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd07_06.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd07` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd07_10.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd07` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd07_11.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd07` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd07_map_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd07` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd08.json` | Map Data (VD) | Core map asset for `vd08` in Two River / Kobold Village / Lakewest / Drakemouth. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vd08_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd08` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd08_01.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd08` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd08_02.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd08` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd08_03.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd08` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd08_04.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd08` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd08_07.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd08` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd08_map_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd08` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd09.json` | Map Data (VD) | Core map asset for `vd09` in Two River / Kobold Village / Lakewest / Drakemouth. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vd09_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd09` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd09_03.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd09` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd09_04.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd09` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd09_map_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd09` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd1.json` | Map Data (VD) | Core map asset for `vd1` in Two River / Kobold Village / Lakewest / Drakemouth. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vd10.json` | Map Data (VD) | Core map asset for `vd10` in Two River / Kobold Village / Lakewest / Drakemouth. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vd10_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd10` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd10_00_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd10` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd10_00_01.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd10` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd10_00_02.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd10` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd10_00_03.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd10` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd10_00_04.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd10` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd10_00_05.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd10` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd10_00_06.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd10` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd10_00_07.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd10` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd10_00_08.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd10` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd10_00_09.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd10` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd10_00_obj.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd10` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd10_map_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd10` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd11.json` | Map Data (VD) | Core map asset for `vd11` in Two River / Kobold Village / Lakewest / Drakemouth. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vd11_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd11` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd11_00_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd11` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd11_00_01.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd11` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd11_00_02.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd11` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd11_00_03.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd11` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd11_00_04.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd11` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd11_00_05.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd11` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd11_00_06.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd11` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd11_00_07.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd11` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd11_00_08.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd11` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd11_00_09.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd11` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd11_map_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd11` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd12.json` | Map Data (VD) | Core map asset for `vd12` in Two River / Kobold Village / Lakewest / Drakemouth. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vd12_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd12` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd12_00_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd12` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd12_00_01.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd12` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd12_00_02.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd12` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd12_00_03.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd12` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd12_00_04.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd12` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd12_00_05.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd12` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd12_00_06.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd12` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd12_00_07.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd12` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd12_00_08.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd12` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd12_00_09.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd12` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd12_map_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd12` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd13.json` | Map Data (VD) | Core map asset for `vd13` in Two River / Kobold Village / Lakewest / Drakemouth. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vd13_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd13` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd13_00_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd13` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd13_00_01.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd13` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd13_00_02.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd13` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd13_00_03.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd13` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd13_00_04.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd13` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd13_00_05.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd13` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd13_00_06.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd13` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd13_00_07.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd13` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd13_00_08.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd13` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd13_00_09.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd13` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd13_map_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd13` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd13_map_04.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd13` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd13_map_06.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd13` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd14.json` | Map Data (VD) | Core map asset for `vd14` in Two River / Kobold Village / Lakewest / Drakemouth. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vd14_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd14` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd14_02.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd14` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd14_03.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd14` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd14_04.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd14` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd14_05.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd14` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd15.json` | Map Data (VD) | Core map asset for `vd15` in Two River / Kobold Village / Lakewest / Drakemouth. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vd15_03.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd15` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd15_map_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd15` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd16.json` | Map Data (VD) | Core map asset for `vd16` in Two River / Kobold Village / Lakewest / Drakemouth. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vd16_01.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd16` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd16_11.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd16` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd16_map_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd16` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd17.json` | Map Data (VD) | Core map asset for `vd17` in Two River / Kobold Village / Lakewest / Drakemouth. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vd17_11.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd17` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd17_18.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd17` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd17_22.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd17` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd17_23.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd17` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd17_32.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd17` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd17_33.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd17` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd17_38.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd17` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd17_39.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd17` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd17_map_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd17` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd18.json` | Map Data (VD) | Core map asset for `vd18` in Two River / Kobold Village / Lakewest / Drakemouth. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vd19.json` | Map Data (VD) | Core map asset for `vd19` in Two River / Kobold Village / Lakewest / Drakemouth. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vd19_15.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd19` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd19_16.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd19` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd19_21.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd19` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd19_25.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd19` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd19_28.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd19` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd19_29.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd19` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd19_32.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd19` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd19_map_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd19` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd1_map_00_04.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd1_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd1_map_00_05.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd1_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd1_map_03_02.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd1_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd1_map_06_02.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd1_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd1_map_06_03.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd1_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd1_map_06_04.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd1_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd2.json` | Map Data (VD) | Core map asset for `vd2` in Two River / Kobold Village / Lakewest / Drakemouth. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vd20.json` | Map Data (VD) | Core map asset for `vd20` in Two River / Kobold Village / Lakewest / Drakemouth. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vd20_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd20` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd20_map_01.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd20` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd3.json` | Map Data (VD) | Core map asset for `vd3` in Two River / Kobold Village / Lakewest / Drakemouth. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vd4.json` | Map Data (VD) | Core map asset for `vd4` in Two River / Kobold Village / Lakewest / Drakemouth. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vd4_map_00_03.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd4_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd4_map_00_04.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd4_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd5.json` | Map Data (VD) | Core map asset for `vd5` in Two River / Kobold Village / Lakewest / Drakemouth. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vd5_map_01_04.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd5_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd5_map_01_05.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd5_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd5_map_01_battle_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd5_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd5_map_01_battle_00_field.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd5_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd5_map_01_battle_00_field_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd5_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd5_map_01_battle_00_field_srn.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd5_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd5_map_01_battle_00_monster_data_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd5_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd5_map_01_battle_00_monster_data_00_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd5_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd5_map_01_battle_00_monster_data_01.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd5_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd5_map_01_battle_00_monster_data_01_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd5_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd5_map_01_battle_00_monster_data_02.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd5_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd5_map_01_battle_00_monster_data_02_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd5_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd5_map_01_battle_00_monster_data_03.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd5_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd5_map_01_battle_00_monster_data_03_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd5_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd5_map_01_battle_00_monster_data_04.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd5_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd5_map_01_battle_00_monster_data_05.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd5_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd5_map_01_battle_00_monster_party_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd5_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd5_map_01_battle_00_monster_party_04.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd5_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd5_map_01_battle_00_monster_party_05.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd5_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd5_map_01_battle_00_monster_party_06.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd5_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd5_map_01_battle_00_monster_party_07.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd5_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd5_map_02_battle_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd5_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd5_map_02_battle_00_field.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd5_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd5_map_02_battle_00_field_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd5_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd5_map_02_battle_00_field_srn.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd5_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd5_map_07_battle_01.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd5_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd5_map_07_battle_01_monster_party_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd5_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd5_map_07_battle_02.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd5_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd5_map_07_battle_02_monster_party_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd5_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd5_map_07_battle_03.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd5_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd5_map_07_battle_03_monster_party_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd5_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd5_map_07_battle_04.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd5_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd5_map_07_battle_04_monster_party_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd5_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd5_map_07_battle_05.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd5_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd5_map_07_battle_05_monster_party_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd5_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd6.json` | Map Data (VD) | Core map asset for `vd6` in Two River / Kobold Village / Lakewest / Drakemouth. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vd6_map_00_07.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd6_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd6_map_00_08.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd6_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd6_map_00_battle_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd6_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd6_map_00_battle_00_field.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd6_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd6_map_00_battle_00_field_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd6_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd6_map_00_battle_00_field_srn.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd6_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd6_map_00_battle_00_monster_data_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd6_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd6_map_00_battle_00_monster_data_01.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd6_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd6_map_00_battle_00_monster_data_02.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd6_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd6_map_00_battle_00_monster_party_02.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd6_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd6_map_00_battle_00_monster_party_03.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd6_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd6_map_00_battle_00_monster_party_05.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd6_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd6_map_01_battle_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd6_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd6_map_01_battle_00_field.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd6_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd6_map_01_battle_00_field_srn.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd6_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd6_map_03_battle_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd6_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd6_map_03_battle_00_field.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd6_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd6_map_03_battle_00_field_00.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd6_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd6_map_03_battle_00_field_srn.json` | Map Sub-Asset (VD) | Map background layer / 3D prop configuration for `vd6_` (Two River / Kobold Village / Lakewest / Drakemouth). |
| `vd7.json` | Map Data (VD) | Core map asset for `vd7` in Two River / Kobold Village / Lakewest / Drakemouth. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |

### <a id="region-ve-greenhill-matilda-muse-matilda-border"></a>Region VE: Greenhill / Matilda / Muse-Matilda Border (200 files)

| File Name | Subsystem / Type | Technical Role & Grounded Description |
|---|---|---|
| `VerticalLayoutGroup.json` | Unity UI Engine Component | Standard Unity UI `VerticalLayoutGroup` component serialized parameters. |
| `ve01.json` | Map Data (VE) | Core map asset for `ve01` in Greenhill / Matilda / Muse-Matilda Border. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `ve01_07.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve01` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve01_14.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve01` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve01_map_00.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve01` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve01_map_01.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve01` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve02.json` | Map Data (VE) | Core map asset for `ve02` in Greenhill / Matilda / Muse-Matilda Border. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `ve02_00.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve02` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve02_05.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve02` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve02_06.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve02` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve02_07.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve02` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve02_08.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve02` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve02_14.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve02` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve02_15.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve02` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve02_18.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve02` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve02_19.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve02` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve02_24.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve02` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve02_map_00.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve02` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve02_map_01.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve02` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve03.json` | Map Data (VE) | Core map asset for `ve03` in Greenhill / Matilda / Muse-Matilda Border. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `ve03_00.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve03` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve03_00_00.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve03` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve03_00_01.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve03` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve03_00_02.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve03` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve03_00_03.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve03` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve03_00_05.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve03` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve03_00_06.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve03` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve03_00_07.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve03` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve03_00_08.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve03` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve03_00_10.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve03` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve03_00_obj.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve03` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve03_04.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve03` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve03_07.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve03` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve03_map_01.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve03` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve04.json` | Map Data (VE) | Core map asset for `ve04` in Greenhill / Matilda / Muse-Matilda Border. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `ve04_00.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve04` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve04_00_00.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve04` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve04_00_01.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve04` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve04_00_02.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve04` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve04_00_03.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve04` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve04_00_04.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve04` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve04_00_05.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve04` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve04_00_06.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve04` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve04_00_07.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve04` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve04_00_08.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve04` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve04_00_09.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve04` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve04_00_10.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve04` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve04_00_obj.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve04` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve04_01.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve04` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve04_03.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve04` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve04_06.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve04` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve04_07.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve04` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve04_map_00.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve04` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve05.json` | Map Data (VE) | Core map asset for `ve05` in Greenhill / Matilda / Muse-Matilda Border. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `ve05_02.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve05` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve05_03.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve05` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve05_04.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve05` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve05_map_00.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve05` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve06.json` | Map Data (VE) | Core map asset for `ve06` in Greenhill / Matilda / Muse-Matilda Border. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `ve06_00.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve06` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve06_06.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve06` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve06_07.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve06` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve06_14.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve06` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve06_15.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve06` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve06_16.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve06` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve06_17.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve06` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve06_18.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve06` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve06_19.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve06` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve06_map_00.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve06` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve07.json` | Map Data (VE) | Core map asset for `ve07` in Greenhill / Matilda / Muse-Matilda Border. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `ve07_05.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve07` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve07_06.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve07` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve07_08.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve07` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve07_11.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve07` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve07_map_00.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve07` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve08.json` | Map Data (VE) | Core map asset for `ve08` in Greenhill / Matilda / Muse-Matilda Border. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `ve08_00.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve08` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve08_00_00.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve08` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve08_00_01.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve08` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve08_00_02.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve08` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve08_00_03.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve08` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve08_00_04.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve08` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve08_00_05.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve08` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve08_00_06.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve08` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve08_00_07.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve08` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve08_00_08.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve08` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve08_00_09.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve08` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve08_02.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve08` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve08_map_00.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve08` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve09.json` | Map Data (VE) | Core map asset for `ve09` in Greenhill / Matilda / Muse-Matilda Border. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `ve1.json` | Map Data (VE) | Core map asset for `ve1` in Greenhill / Matilda / Muse-Matilda Border. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `ve10.json` | Map Data (VE) | Core map asset for `ve10` in Greenhill / Matilda / Muse-Matilda Border. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `ve10_03.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve10` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve10_09.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve10` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve10_11.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve10` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve10_16.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve10` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve10_map_00.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve10` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve11.json` | Map Data (VE) | Core map asset for `ve11` in Greenhill / Matilda / Muse-Matilda Border. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `ve11_00.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve11` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve11_01.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve11` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve12.json` | Map Data (VE) | Core map asset for `ve12` in Greenhill / Matilda / Muse-Matilda Border. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `ve12_01.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve12` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve12_02.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve12` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve12_04.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve12` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve12_05.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve12` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve12_07.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve12` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve12_08.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve12` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve12_10.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve12` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve13.json` | Map Data (VE) | Core map asset for `ve13` in Greenhill / Matilda / Muse-Matilda Border. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `ve13_13.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve13` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve14.json` | Map Data (VE) | Core map asset for `ve14` in Greenhill / Matilda / Muse-Matilda Border. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `ve14_00.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve14` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve14_00_00.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve14` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve14_00_01.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve14` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve14_00_02.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve14` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve14_00_03.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve14` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve14_00_05.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve14` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve14_00_06.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve14` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve14_00_07.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve14` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve14_00_08.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve14` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve14_00_10.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve14` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve14_02.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve14` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve15.json` | Map Data (VE) | Core map asset for `ve15` in Greenhill / Matilda / Muse-Matilda Border. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `ve15_00.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve15` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve15_00_00.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve15` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve15_00_01.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve15` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve15_00_02.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve15` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve15_00_03.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve15` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve15_00_04.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve15` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve15_00_05.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve15` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve15_00_06.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve15` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve15_00_07.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve15` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve15_00_08.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve15` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve15_00_09.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve15` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve16.json` | Map Data (VE) | Core map asset for `ve16` in Greenhill / Matilda / Muse-Matilda Border. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `ve1_map_00_06.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve1_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve1_map_00_07.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve1_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve1_map_00_10.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve1_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve1_map_00_battle_01.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve1_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve1_map_00_battle_01_field.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve1_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve1_map_00_battle_01_field_srn.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve1_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve1_map_00_battle_01_monster_data_00.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve1_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve1_map_00_battle_01_monster_data_00_00.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve1_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve1_map_00_battle_01_monster_party_00.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve1_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve2.json` | Map Data (VE) | Core map asset for `ve2` in Greenhill / Matilda / Muse-Matilda Border. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `ve2_map_00_battle_00.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve2_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve2_map_00_battle_00_field.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve2_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve2_map_00_battle_00_field_srn.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve2_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve2_map_00_battle_00_monster_data_00.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve2_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve2_map_00_battle_00_monster_data_00_00.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve2_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve2_map_00_battle_00_monster_data_01.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve2_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve2_map_00_battle_00_monster_data_02.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve2_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve2_map_00_battle_00_monster_data_02_00.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve2_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve2_map_00_battle_00_monster_party_00.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve2_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve2_map_00_battle_00_monster_party_01.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve2_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve2_map_00_battle_00_monster_party_02.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve2_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve2_map_00_battle_00_monster_party_03.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve2_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve2_map_00_battle_00_monster_party_04.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve2_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve2_map_00_battle_00_monster_party_05.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve2_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve2_map_00_battle_00_monster_party_06.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve2_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve2_map_00_battle_00_monster_party_07.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve2_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve2_map_00_battle_00_monster_party_08.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve2_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve2_map_00_battle_00_monster_party_09.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve2_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve2_map_00_battle_00_monster_party_10.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve2_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve2_map_20_03.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve2_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve3.json` | Map Data (VE) | Core map asset for `ve3` in Greenhill / Matilda / Muse-Matilda Border. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `ve3_map_01_battle_00.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve3_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve3_map_01_battle_00_field.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve3_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve3_map_01_battle_00_field_00.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve3_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve3_map_01_battle_00_field_srn.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve3_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve3_map_01_battle_00_monster_data_00.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve3_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve3_map_01_battle_00_monster_data_00_00.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve3_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve3_map_01_battle_00_monster_data_01.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve3_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve3_map_01_battle_00_monster_data_01_00.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve3_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve3_map_01_battle_00_monster_data_02.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve3_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve3_map_01_battle_00_monster_data_02_00.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve3_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve3_map_01_battle_00_monster_party_00.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve3_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve3_map_01_battle_00_monster_party_01.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve3_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve3_map_01_battle_00_monster_party_02.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve3_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve3_map_01_battle_00_monster_party_03.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve3_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve3_map_01_battle_00_monster_party_04.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve3_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve3_map_01_battle_00_monster_party_05.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve3_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve3_map_01_battle_00_monster_party_06.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve3_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve3_map_01_battle_00_monster_party_07.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve3_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve3_map_01_battle_00_monster_party_08.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve3_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve3_map_04_battle_00.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve3_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve3_map_04_battle_00_field.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve3_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve3_map_04_battle_00_field_srn.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve3_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve3_map_20_03.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve3_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve3_map_20_04.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve3_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve3_map_20_07.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve3_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve3_map_20_08.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve3_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve3_map_20_battle_01.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve3_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve3_map_20_battle_01_field.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve3_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve3_map_20_battle_01_field_srn.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve3_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve3_map_20_battle_01_monster_data_00.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve3_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve3_map_20_battle_01_monster_party_00.json` | Map Sub-Asset (VE) | Map background layer / 3D prop configuration for `ve3_` (Greenhill / Matilda / Muse-Matilda Border). |
| `ve4.json` | Map Data (VE) | Core map asset for `ve4` in Greenhill / Matilda / Muse-Matilda Border. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `ve5.json` | Map Data (VE) | Core map asset for `ve5` in Greenhill / Matilda / Muse-Matilda Border. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `ve6.json` | Map Data (VE) | Core map asset for `ve6` in Greenhill / Matilda / Muse-Matilda Border. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |

### <a id="region-vf-highway-rockaxe-mt-rakutei"></a>Region VF: Highway / Rockaxe / Mt. Rakutei (160 files)

| File Name | Subsystem / Type | Technical Role & Grounded Description |
|---|---|---|
| `vf01.json` | Map Data (VF) | Core map asset for `vf01` in Highway / Rockaxe / Mt. Rakutei. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vf01_00.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf01` (Highway / Rockaxe / Mt. Rakutei). |
| `vf01_01.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf01` (Highway / Rockaxe / Mt. Rakutei). |
| `vf01_02.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf01` (Highway / Rockaxe / Mt. Rakutei). |
| `vf01_03.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf01` (Highway / Rockaxe / Mt. Rakutei). |
| `vf01_04.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf01` (Highway / Rockaxe / Mt. Rakutei). |
| `vf01_05.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf01` (Highway / Rockaxe / Mt. Rakutei). |
| `vf01_06.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf01` (Highway / Rockaxe / Mt. Rakutei). |
| `vf01_07.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf01` (Highway / Rockaxe / Mt. Rakutei). |
| `vf01_08.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf01` (Highway / Rockaxe / Mt. Rakutei). |
| `vf01_09.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf01` (Highway / Rockaxe / Mt. Rakutei). |
| `vf01_10.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf01` (Highway / Rockaxe / Mt. Rakutei). |
| `vf01_11.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf01` (Highway / Rockaxe / Mt. Rakutei). |
| `vf01_12.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf01` (Highway / Rockaxe / Mt. Rakutei). |
| `vf01_13.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf01` (Highway / Rockaxe / Mt. Rakutei). |
| `vf01_14.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf01` (Highway / Rockaxe / Mt. Rakutei). |
| `vf01_map_00.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf01` (Highway / Rockaxe / Mt. Rakutei). |
| `vf01_map_02.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf01` (Highway / Rockaxe / Mt. Rakutei). |
| `vf02.json` | Map Data (VF) | Core map asset for `vf02` in Highway / Rockaxe / Mt. Rakutei. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vf02_00.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf02` (Highway / Rockaxe / Mt. Rakutei). |
| `vf02_01.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf02` (Highway / Rockaxe / Mt. Rakutei). |
| `vf02_02.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf02` (Highway / Rockaxe / Mt. Rakutei). |
| `vf02_03.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf02` (Highway / Rockaxe / Mt. Rakutei). |
| `vf02_04.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf02` (Highway / Rockaxe / Mt. Rakutei). |
| `vf02_05.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf02` (Highway / Rockaxe / Mt. Rakutei). |
| `vf02_06.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf02` (Highway / Rockaxe / Mt. Rakutei). |
| `vf02_18.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf02` (Highway / Rockaxe / Mt. Rakutei). |
| `vf02_map_00.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf02` (Highway / Rockaxe / Mt. Rakutei). |
| `vf03.json` | Map Data (VF) | Core map asset for `vf03` in Highway / Rockaxe / Mt. Rakutei. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vf03_00.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf03` (Highway / Rockaxe / Mt. Rakutei). |
| `vf03_03.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf03` (Highway / Rockaxe / Mt. Rakutei). |
| `vf03_04.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf03` (Highway / Rockaxe / Mt. Rakutei). |
| `vf03_11.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf03` (Highway / Rockaxe / Mt. Rakutei). |
| `vf03_14.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf03` (Highway / Rockaxe / Mt. Rakutei). |
| `vf03_15.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf03` (Highway / Rockaxe / Mt. Rakutei). |
| `vf03_22.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf03` (Highway / Rockaxe / Mt. Rakutei). |
| `vf03_30.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf03` (Highway / Rockaxe / Mt. Rakutei). |
| `vf03_map_00.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf03` (Highway / Rockaxe / Mt. Rakutei). |
| `vf03_map_01.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf03` (Highway / Rockaxe / Mt. Rakutei). |
| `vf04.json` | Map Data (VF) | Core map asset for `vf04` in Highway / Rockaxe / Mt. Rakutei. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vf04_00.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf04` (Highway / Rockaxe / Mt. Rakutei). |
| `vf04_01.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf04` (Highway / Rockaxe / Mt. Rakutei). |
| `vf04_02.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf04` (Highway / Rockaxe / Mt. Rakutei). |
| `vf04_03.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf04` (Highway / Rockaxe / Mt. Rakutei). |
| `vf04_06.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf04` (Highway / Rockaxe / Mt. Rakutei). |
| `vf04_07.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf04` (Highway / Rockaxe / Mt. Rakutei). |
| `vf04_08.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf04` (Highway / Rockaxe / Mt. Rakutei). |
| `vf04_09.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf04` (Highway / Rockaxe / Mt. Rakutei). |
| `vf04_10.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf04` (Highway / Rockaxe / Mt. Rakutei). |
| `vf04_11.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf04` (Highway / Rockaxe / Mt. Rakutei). |
| `vf04_12.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf04` (Highway / Rockaxe / Mt. Rakutei). |
| `vf04_13.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf04` (Highway / Rockaxe / Mt. Rakutei). |
| `vf04_14.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf04` (Highway / Rockaxe / Mt. Rakutei). |
| `vf04_15.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf04` (Highway / Rockaxe / Mt. Rakutei). |
| `vf04_16.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf04` (Highway / Rockaxe / Mt. Rakutei). |
| `vf04_17.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf04` (Highway / Rockaxe / Mt. Rakutei). |
| `vf04_18.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf04` (Highway / Rockaxe / Mt. Rakutei). |
| `vf04_19.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf04` (Highway / Rockaxe / Mt. Rakutei). |
| `vf04_20.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf04` (Highway / Rockaxe / Mt. Rakutei). |
| `vf04_map_00.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf04` (Highway / Rockaxe / Mt. Rakutei). |
| `vf05.json` | Map Data (VF) | Core map asset for `vf05` in Highway / Rockaxe / Mt. Rakutei. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vf05_01.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf05` (Highway / Rockaxe / Mt. Rakutei). |
| `vf05_03.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf05` (Highway / Rockaxe / Mt. Rakutei). |
| `vf05_06.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf05` (Highway / Rockaxe / Mt. Rakutei). |
| `vf05_09.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf05` (Highway / Rockaxe / Mt. Rakutei). |
| `vf05_12.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf05` (Highway / Rockaxe / Mt. Rakutei). |
| `vf05_14.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf05` (Highway / Rockaxe / Mt. Rakutei). |
| `vf05_22.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf05` (Highway / Rockaxe / Mt. Rakutei). |
| `vf05_24.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf05` (Highway / Rockaxe / Mt. Rakutei). |
| `vf05_map_00.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf05` (Highway / Rockaxe / Mt. Rakutei). |
| `vf05_map_01.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf05` (Highway / Rockaxe / Mt. Rakutei). |
| `vf06.json` | Map Data (VF) | Core map asset for `vf06` in Highway / Rockaxe / Mt. Rakutei. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vf06_00.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf06` (Highway / Rockaxe / Mt. Rakutei). |
| `vf06_00_00.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf06` (Highway / Rockaxe / Mt. Rakutei). |
| `vf06_00_01.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf06` (Highway / Rockaxe / Mt. Rakutei). |
| `vf06_00_02.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf06` (Highway / Rockaxe / Mt. Rakutei). |
| `vf06_00_03.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf06` (Highway / Rockaxe / Mt. Rakutei). |
| `vf06_00_04.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf06` (Highway / Rockaxe / Mt. Rakutei). |
| `vf06_00_07.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf06` (Highway / Rockaxe / Mt. Rakutei). |
| `vf06_00_08.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf06` (Highway / Rockaxe / Mt. Rakutei). |
| `vf06_00_14.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf06` (Highway / Rockaxe / Mt. Rakutei). |
| `vf06_00_17.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf06` (Highway / Rockaxe / Mt. Rakutei). |
| `vf06_00_20.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf06` (Highway / Rockaxe / Mt. Rakutei). |
| `vf06_00_21.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf06` (Highway / Rockaxe / Mt. Rakutei). |
| `vf06_00_obj.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf06` (Highway / Rockaxe / Mt. Rakutei). |
| `vf06_02.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf06` (Highway / Rockaxe / Mt. Rakutei). |
| `vf06_map_00.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf06` (Highway / Rockaxe / Mt. Rakutei). |
| `vf07.json` | Map Data (VF) | Core map asset for `vf07` in Highway / Rockaxe / Mt. Rakutei. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vf07_00.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf07` (Highway / Rockaxe / Mt. Rakutei). |
| `vf07_00_00.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf07` (Highway / Rockaxe / Mt. Rakutei). |
| `vf07_00_01.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf07` (Highway / Rockaxe / Mt. Rakutei). |
| `vf07_00_02.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf07` (Highway / Rockaxe / Mt. Rakutei). |
| `vf07_00_03.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf07` (Highway / Rockaxe / Mt. Rakutei). |
| `vf07_00_04.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf07` (Highway / Rockaxe / Mt. Rakutei). |
| `vf07_00_07.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf07` (Highway / Rockaxe / Mt. Rakutei). |
| `vf07_00_08.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf07` (Highway / Rockaxe / Mt. Rakutei). |
| `vf07_00_14.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf07` (Highway / Rockaxe / Mt. Rakutei). |
| `vf07_00_17.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf07` (Highway / Rockaxe / Mt. Rakutei). |
| `vf07_00_20.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf07` (Highway / Rockaxe / Mt. Rakutei). |
| `vf07_00_21.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf07` (Highway / Rockaxe / Mt. Rakutei). |
| `vf07_03.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf07` (Highway / Rockaxe / Mt. Rakutei). |
| `vf07_04.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf07` (Highway / Rockaxe / Mt. Rakutei). |
| `vf07_05.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf07` (Highway / Rockaxe / Mt. Rakutei). |
| `vf07_06.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf07` (Highway / Rockaxe / Mt. Rakutei). |
| `vf07_07.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf07` (Highway / Rockaxe / Mt. Rakutei). |
| `vf1.json` | Map Data (VF) | Core map asset for `vf1` in Highway / Rockaxe / Mt. Rakutei. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vf1_map_00_01.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf1_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf1_map_01_battle_00.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf1_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf1_map_01_battle_00_field.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf1_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf1_map_01_battle_00_field_srn.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf1_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf1_map_01_battle_00_monster_data_00.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf1_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf1_map_01_battle_00_monster_data_00_00.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf1_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf1_map_01_battle_00_monster_data_01.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf1_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf1_map_01_battle_00_monster_data_01_00.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf1_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf1_map_01_battle_00_monster_data_02.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf1_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf1_map_01_battle_00_monster_data_02_00.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf1_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf1_map_01_battle_00_monster_party_00.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf1_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf1_map_01_battle_00_monster_party_01.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf1_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf1_map_01_battle_00_monster_party_02.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf1_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf1_map_01_battle_00_monster_party_03.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf1_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf1_map_01_battle_00_monster_party_04.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf1_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf1_map_01_battle_00_monster_party_06.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf1_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf2.json` | Map Data (VF) | Core map asset for `vf2` in Highway / Rockaxe / Mt. Rakutei. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vf2_map_00_01.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf2_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf2_map_00_battle_00.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf2_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf2_map_00_battle_00_field.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf2_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf2_map_00_battle_00_field_00.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf2_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf2_map_00_battle_00_field_srn.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf2_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf2_map_00_battle_00_monster_data_00.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf2_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf2_map_00_battle_00_monster_data_01.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf2_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf2_map_00_battle_00_monster_data_01_00.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf2_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf2_map_00_battle_00_monster_data_02.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf2_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf2_map_00_battle_00_monster_data_03.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf2_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf2_map_00_battle_00_monster_data_03_00.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf2_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf2_map_00_battle_00_monster_party_01.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf2_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf2_map_00_battle_00_monster_party_02.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf2_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf2_map_00_battle_00_monster_party_05.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf2_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf2_map_00_battle_00_monster_party_06.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf2_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf2_map_00_battle_00_monster_party_08.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf2_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf2_map_00_battle_00_monster_party_09.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf2_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf2_map_00_battle_00_monster_party_10.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf2_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf2_map_00_battle_00_monster_party_11.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf2_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf2_map_09_01.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf2_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf2_map_09_battle_01.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf2_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf2_map_09_battle_01_field.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf2_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf2_map_09_battle_01_field_srn.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf2_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf2_map_09_battle_01_monster_data_00.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf2_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf2_map_09_battle_01_monster_data_00_00.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf2_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf2_map_09_battle_01_monster_data_01.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf2_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf2_map_09_battle_01_monster_data_01_00.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf2_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf2_map_09_battle_01_monster_party_00.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf2_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf3.json` | Map Data (VF) | Core map asset for `vf3` in Highway / Rockaxe / Mt. Rakutei. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vf3_map_00_04.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf3_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf3_map_00_05.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf3_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf3_map_01_04.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf3_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf3_map_01_06.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf3_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf4.json` | Map Data (VF) | Core map asset for `vf4` in Highway / Rockaxe / Mt. Rakutei. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vf4_map_00_07.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf4_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf4_map_00_08.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf4_` (Highway / Rockaxe / Mt. Rakutei). |
| `vf4_map_00_09.json` | Map Sub-Asset (VF) | Map background layer / 3D prop configuration for `vf4_` (Highway / Rockaxe / Mt. Rakutei). |

### <a id="region-vg-tinto-crom-tigermouth-mines"></a>Region VG: Tinto / Crom / Tigermouth / Mines (152 files)

| File Name | Subsystem / Type | Technical Role & Grounded Description |
|---|---|---|
| `vg01.json` | Map Data (VG) | Core map asset for `vg01` in Tinto / Crom / Tigermouth / South Mine. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vg01_01.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg01` (Tinto / Crom / Tigermouth / South Mine). |
| `vg01_02.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg01` (Tinto / Crom / Tigermouth / South Mine). |
| `vg01_05.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg01` (Tinto / Crom / Tigermouth / South Mine). |
| `vg01_06.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg01` (Tinto / Crom / Tigermouth / South Mine). |
| `vg01_10.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg01` (Tinto / Crom / Tigermouth / South Mine). |
| `vg01_14.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg01` (Tinto / Crom / Tigermouth / South Mine). |
| `vg01_map_00.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg01` (Tinto / Crom / Tigermouth / South Mine). |
| `vg02.json` | Map Data (VG) | Core map asset for `vg02` in Tinto / Crom / Tigermouth / South Mine. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vg02_00.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg02` (Tinto / Crom / Tigermouth / South Mine). |
| `vg02_00_00.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg02` (Tinto / Crom / Tigermouth / South Mine). |
| `vg02_00_01.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg02` (Tinto / Crom / Tigermouth / South Mine). |
| `vg02_00_02.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg02` (Tinto / Crom / Tigermouth / South Mine). |
| `vg02_00_03.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg02` (Tinto / Crom / Tigermouth / South Mine). |
| `vg02_00_04.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg02` (Tinto / Crom / Tigermouth / South Mine). |
| `vg02_00_05.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg02` (Tinto / Crom / Tigermouth / South Mine). |
| `vg02_00_06.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg02` (Tinto / Crom / Tigermouth / South Mine). |
| `vg02_00_07.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg02` (Tinto / Crom / Tigermouth / South Mine). |
| `vg02_00_08.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg02` (Tinto / Crom / Tigermouth / South Mine). |
| `vg02_00_09.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg02` (Tinto / Crom / Tigermouth / South Mine). |
| `vg02_00_10.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg02` (Tinto / Crom / Tigermouth / South Mine). |
| `vg02_00_obj.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg02` (Tinto / Crom / Tigermouth / South Mine). |
| `vg02_map_00.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg02` (Tinto / Crom / Tigermouth / South Mine). |
| `vg02_map_02.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg02` (Tinto / Crom / Tigermouth / South Mine). |
| `vg03.json` | Map Data (VG) | Core map asset for `vg03` in Tinto / Crom / Tigermouth / South Mine. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vg03_02.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg03` (Tinto / Crom / Tigermouth / South Mine). |
| `vg03_11.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg03` (Tinto / Crom / Tigermouth / South Mine). |
| `vg03_19.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg03` (Tinto / Crom / Tigermouth / South Mine). |
| `vg03_21.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg03` (Tinto / Crom / Tigermouth / South Mine). |
| `vg03_map_00.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg03` (Tinto / Crom / Tigermouth / South Mine). |
| `vg04.json` | Map Data (VG) | Core map asset for `vg04` in Tinto / Crom / Tigermouth / South Mine. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vg04_00.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg04` (Tinto / Crom / Tigermouth / South Mine). |
| `vg04_00_00.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg04` (Tinto / Crom / Tigermouth / South Mine). |
| `vg04_00_01.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg04` (Tinto / Crom / Tigermouth / South Mine). |
| `vg04_00_03.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg04` (Tinto / Crom / Tigermouth / South Mine). |
| `vg04_00_05.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg04` (Tinto / Crom / Tigermouth / South Mine). |
| `vg04_00_06.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg04` (Tinto / Crom / Tigermouth / South Mine). |
| `vg04_00_10.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg04` (Tinto / Crom / Tigermouth / South Mine). |
| `vg04_00_11.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg04` (Tinto / Crom / Tigermouth / South Mine). |
| `vg04_map_00.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg04` (Tinto / Crom / Tigermouth / South Mine). |
| `vg05.json` | Map Data (VG) | Core map asset for `vg05` in Tinto / Crom / Tigermouth / South Mine. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vg06.json` | Map Data (VG) | Core map asset for `vg06` in Tinto / Crom / Tigermouth / South Mine. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vg06_00.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg06` (Tinto / Crom / Tigermouth / South Mine). |
| `vg06_01.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg06` (Tinto / Crom / Tigermouth / South Mine). |
| `vg06_04.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg06` (Tinto / Crom / Tigermouth / South Mine). |
| `vg06_09.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg06` (Tinto / Crom / Tigermouth / South Mine). |
| `vg06_10.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg06` (Tinto / Crom / Tigermouth / South Mine). |
| `vg06_12.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg06` (Tinto / Crom / Tigermouth / South Mine). |
| `vg06_24.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg06` (Tinto / Crom / Tigermouth / South Mine). |
| `vg06_25.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg06` (Tinto / Crom / Tigermouth / South Mine). |
| `vg06_map_00.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg06` (Tinto / Crom / Tigermouth / South Mine). |
| `vg06_map_01.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg06` (Tinto / Crom / Tigermouth / South Mine). |
| `vg07.json` | Map Data (VG) | Core map asset for `vg07` in Tinto / Crom / Tigermouth / South Mine. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vg07_01.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg07` (Tinto / Crom / Tigermouth / South Mine). |
| `vg07_03.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg07` (Tinto / Crom / Tigermouth / South Mine). |
| `vg07_04.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg07` (Tinto / Crom / Tigermouth / South Mine). |
| `vg07_05.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg07` (Tinto / Crom / Tigermouth / South Mine). |
| `vg07_10.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg07` (Tinto / Crom / Tigermouth / South Mine). |
| `vg07_13.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg07` (Tinto / Crom / Tigermouth / South Mine). |
| `vg07_map_00.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg07` (Tinto / Crom / Tigermouth / South Mine). |
| `vg07_map_01.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg07` (Tinto / Crom / Tigermouth / South Mine). |
| `vg08.json` | Map Data (VG) | Core map asset for `vg08` in Tinto / Crom / Tigermouth / South Mine. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vg08_04.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg08` (Tinto / Crom / Tigermouth / South Mine). |
| `vg08_23.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg08` (Tinto / Crom / Tigermouth / South Mine). |
| `vg08_24.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg08` (Tinto / Crom / Tigermouth / South Mine). |
| `vg08_map_00.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg08` (Tinto / Crom / Tigermouth / South Mine). |
| `vg08_map_01.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg08` (Tinto / Crom / Tigermouth / South Mine). |
| `vg09.json` | Map Data (VG) | Core map asset for `vg09` in Tinto / Crom / Tigermouth / South Mine. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vg09_05.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg09` (Tinto / Crom / Tigermouth / South Mine). |
| `vg09_map_00.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg09` (Tinto / Crom / Tigermouth / South Mine). |
| `vg09_map_01.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg09` (Tinto / Crom / Tigermouth / South Mine). |
| `vg1.json` | Map Data (VG) | Core map asset for `vg1` in Tinto / Crom / Tigermouth / South Mine. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vg10.json` | Map Data (VG) | Core map asset for `vg10` in Tinto / Crom / Tigermouth / South Mine. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vg11.json` | Map Data (VG) | Core map asset for `vg11` in Tinto / Crom / Tigermouth / South Mine. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vg11_00.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg11` (Tinto / Crom / Tigermouth / South Mine). |
| `vg11_00_00.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg11` (Tinto / Crom / Tigermouth / South Mine). |
| `vg11_00_01.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg11` (Tinto / Crom / Tigermouth / South Mine). |
| `vg11_00_02.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg11` (Tinto / Crom / Tigermouth / South Mine). |
| `vg11_00_03.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg11` (Tinto / Crom / Tigermouth / South Mine). |
| `vg11_00_04.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg11` (Tinto / Crom / Tigermouth / South Mine). |
| `vg11_00_05.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg11` (Tinto / Crom / Tigermouth / South Mine). |
| `vg11_00_06.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg11` (Tinto / Crom / Tigermouth / South Mine). |
| `vg11_00_07.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg11` (Tinto / Crom / Tigermouth / South Mine). |
| `vg11_00_08.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg11` (Tinto / Crom / Tigermouth / South Mine). |
| `vg11_00_09.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg11` (Tinto / Crom / Tigermouth / South Mine). |
| `vg11_00_10.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg11` (Tinto / Crom / Tigermouth / South Mine). |
| `vg11_00_obj.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg11` (Tinto / Crom / Tigermouth / South Mine). |
| `vg11_01.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg11` (Tinto / Crom / Tigermouth / South Mine). |
| `vg11_01_00.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg11` (Tinto / Crom / Tigermouth / South Mine). |
| `vg11_01_obj.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg11` (Tinto / Crom / Tigermouth / South Mine). |
| `vg11_map_00.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg11` (Tinto / Crom / Tigermouth / South Mine). |
| `vg12.json` | Map Data (VG) | Core map asset for `vg12` in Tinto / Crom / Tigermouth / South Mine. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vg13.json` | Map Data (VG) | Core map asset for `vg13` in Tinto / Crom / Tigermouth / South Mine. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vg13_11.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg13` (Tinto / Crom / Tigermouth / South Mine). |
| `vg13_29.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg13` (Tinto / Crom / Tigermouth / South Mine). |
| `vg13_30.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg13` (Tinto / Crom / Tigermouth / South Mine). |
| `vg13_map_00.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg13` (Tinto / Crom / Tigermouth / South Mine). |
| `vg13_map_01.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg13` (Tinto / Crom / Tigermouth / South Mine). |
| `vg14.json` | Map Data (VG) | Core map asset for `vg14` in Tinto / Crom / Tigermouth / South Mine. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vg14_map_00.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg14` (Tinto / Crom / Tigermouth / South Mine). |
| `vg15.json` | Map Data (VG) | Core map asset for `vg15` in Tinto / Crom / Tigermouth / South Mine. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vg15_00.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg15` (Tinto / Crom / Tigermouth / South Mine). |
| `vg15_00_00.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg15` (Tinto / Crom / Tigermouth / South Mine). |
| `vg15_00_01.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg15` (Tinto / Crom / Tigermouth / South Mine). |
| `vg15_00_02.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg15` (Tinto / Crom / Tigermouth / South Mine). |
| `vg15_00_03.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg15` (Tinto / Crom / Tigermouth / South Mine). |
| `vg15_00_04.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg15` (Tinto / Crom / Tigermouth / South Mine). |
| `vg15_00_05.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg15` (Tinto / Crom / Tigermouth / South Mine). |
| `vg15_00_06.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg15` (Tinto / Crom / Tigermouth / South Mine). |
| `vg15_00_07.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg15` (Tinto / Crom / Tigermouth / South Mine). |
| `vg15_00_08.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg15` (Tinto / Crom / Tigermouth / South Mine). |
| `vg15_00_09.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg15` (Tinto / Crom / Tigermouth / South Mine). |
| `vg15_00_10.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg15` (Tinto / Crom / Tigermouth / South Mine). |
| `vg15_01.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg15` (Tinto / Crom / Tigermouth / South Mine). |
| `vg15_map_00.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg15` (Tinto / Crom / Tigermouth / South Mine). |
| `vg15_map_03.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg15` (Tinto / Crom / Tigermouth / South Mine). |
| `vg16.json` | Map Data (VG) | Core map asset for `vg16` in Tinto / Crom / Tigermouth / South Mine. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vg16_00.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg16` (Tinto / Crom / Tigermouth / South Mine). |
| `vg16_00_00.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg16` (Tinto / Crom / Tigermouth / South Mine). |
| `vg16_00_01.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg16` (Tinto / Crom / Tigermouth / South Mine). |
| `vg16_00_03.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg16` (Tinto / Crom / Tigermouth / South Mine). |
| `vg16_00_05.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg16` (Tinto / Crom / Tigermouth / South Mine). |
| `vg16_00_06.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg16` (Tinto / Crom / Tigermouth / South Mine). |
| `vg16_00_10.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg16` (Tinto / Crom / Tigermouth / South Mine). |
| `vg16_00_11.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg16` (Tinto / Crom / Tigermouth / South Mine). |
| `vg16_01.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg16` (Tinto / Crom / Tigermouth / South Mine). |
| `vg16_map_00.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg16` (Tinto / Crom / Tigermouth / South Mine). |
| `vg17.json` | Map Data (VG) | Core map asset for `vg17` in Tinto / Crom / Tigermouth / South Mine. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vg1_map_00_11.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg1_` (Tinto / Crom / Tigermouth / South Mine). |
| `vg1_map_00_12.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg1_` (Tinto / Crom / Tigermouth / South Mine). |
| `vg2.json` | Map Data (VG) | Core map asset for `vg2` in Tinto / Crom / Tigermouth / South Mine. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vg2_map_00_battle_00.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg2_` (Tinto / Crom / Tigermouth / South Mine). |
| `vg2_map_00_battle_00_field.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg2_` (Tinto / Crom / Tigermouth / South Mine). |
| `vg2_map_00_battle_00_field_00.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg2_` (Tinto / Crom / Tigermouth / South Mine). |
| `vg2_map_00_battle_00_field_srn.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg2_` (Tinto / Crom / Tigermouth / South Mine). |
| `vg2_map_00_battle_00_monster_data_00.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg2_` (Tinto / Crom / Tigermouth / South Mine). |
| `vg2_map_00_battle_00_monster_data_00_00.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg2_` (Tinto / Crom / Tigermouth / South Mine). |
| `vg2_map_00_battle_00_monster_data_01.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg2_` (Tinto / Crom / Tigermouth / South Mine). |
| `vg2_map_00_battle_00_monster_data_02.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg2_` (Tinto / Crom / Tigermouth / South Mine). |
| `vg2_map_00_battle_00_monster_data_02_00.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg2_` (Tinto / Crom / Tigermouth / South Mine). |
| `vg2_map_00_battle_00_monster_party_00.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg2_` (Tinto / Crom / Tigermouth / South Mine). |
| `vg2_map_00_battle_00_monster_party_01.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg2_` (Tinto / Crom / Tigermouth / South Mine). |
| `vg2_map_00_battle_00_monster_party_02.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg2_` (Tinto / Crom / Tigermouth / South Mine). |
| `vg2_map_00_battle_00_monster_party_03.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg2_` (Tinto / Crom / Tigermouth / South Mine). |
| `vg2_map_00_battle_00_monster_party_04.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg2_` (Tinto / Crom / Tigermouth / South Mine). |
| `vg2_map_00_battle_00_monster_party_05.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg2_` (Tinto / Crom / Tigermouth / South Mine). |
| `vg2_map_00_battle_00_monster_party_06.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg2_` (Tinto / Crom / Tigermouth / South Mine). |
| `vg2_map_01_01.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg2_` (Tinto / Crom / Tigermouth / South Mine). |
| `vg2_map_01_battle_00.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg2_` (Tinto / Crom / Tigermouth / South Mine). |
| `vg2_map_01_battle_00_field.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg2_` (Tinto / Crom / Tigermouth / South Mine). |
| `vg2_map_01_battle_00_field_srn.json` | Map Sub-Asset (VG) | Map background layer / 3D prop configuration for `vg2_` (Tinto / Crom / Tigermouth / South Mine). |
| `vg3.json` | Map Data (VG) | Core map asset for `vg3` in Tinto / Crom / Tigermouth / South Mine. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |

### <a id="region-vh-banner-village-gregminster-rokkaku"></a>Region VH: Banner Village / Gregminster / Rokkaku (140 files)

| File Name | Subsystem / Type | Technical Role & Grounded Description |
|---|---|---|
| `vh01.json` | Map Data (VH) | Core map asset for `vh01` in Banner Village / Gregminster / Rokkaku. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vh01_02.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh01` (Banner Village / Gregminster / Rokkaku). |
| `vh01_03.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh01` (Banner Village / Gregminster / Rokkaku). |
| `vh01_06.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh01` (Banner Village / Gregminster / Rokkaku). |
| `vh01_14.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh01` (Banner Village / Gregminster / Rokkaku). |
| `vh01_17.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh01` (Banner Village / Gregminster / Rokkaku). |
| `vh01_map_00.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh01` (Banner Village / Gregminster / Rokkaku). |
| `vh02.json` | Map Data (VH) | Core map asset for `vh02` in Banner Village / Gregminster / Rokkaku. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vh02_08.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh02` (Banner Village / Gregminster / Rokkaku). |
| `vh02_09.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh02` (Banner Village / Gregminster / Rokkaku). |
| `vh02_10.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh02` (Banner Village / Gregminster / Rokkaku). |
| `vh02_14.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh02` (Banner Village / Gregminster / Rokkaku). |
| `vh02_15.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh02` (Banner Village / Gregminster / Rokkaku). |
| `vh02_16.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh02` (Banner Village / Gregminster / Rokkaku). |
| `vh02_map_00.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh02` (Banner Village / Gregminster / Rokkaku). |
| `vh02_map_01.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh02` (Banner Village / Gregminster / Rokkaku). |
| `vh03.json` | Map Data (VH) | Core map asset for `vh03` in Banner Village / Gregminster / Rokkaku. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vh03_02.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh03` (Banner Village / Gregminster / Rokkaku). |
| `vh03_03.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh03` (Banner Village / Gregminster / Rokkaku). |
| `vh03_05.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh03` (Banner Village / Gregminster / Rokkaku). |
| `vh03_06.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh03` (Banner Village / Gregminster / Rokkaku). |
| `vh03_07.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh03` (Banner Village / Gregminster / Rokkaku). |
| `vh03_08.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh03` (Banner Village / Gregminster / Rokkaku). |
| `vh03_10.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh03` (Banner Village / Gregminster / Rokkaku). |
| `vh03_11.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh03` (Banner Village / Gregminster / Rokkaku). |
| `vh03_12.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh03` (Banner Village / Gregminster / Rokkaku). |
| `vh03_13.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh03` (Banner Village / Gregminster / Rokkaku). |
| `vh03_14.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh03` (Banner Village / Gregminster / Rokkaku). |
| `vh03_15.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh03` (Banner Village / Gregminster / Rokkaku). |
| `vh03_16.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh03` (Banner Village / Gregminster / Rokkaku). |
| `vh03_17.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh03` (Banner Village / Gregminster / Rokkaku). |
| `vh03_20.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh03` (Banner Village / Gregminster / Rokkaku). |
| `vh03_21.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh03` (Banner Village / Gregminster / Rokkaku). |
| `vh03_22.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh03` (Banner Village / Gregminster / Rokkaku). |
| `vh03_23.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh03` (Banner Village / Gregminster / Rokkaku). |
| `vh03_24.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh03` (Banner Village / Gregminster / Rokkaku). |
| `vh03_map_00.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh03` (Banner Village / Gregminster / Rokkaku). |
| `vh03_map_01.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh03` (Banner Village / Gregminster / Rokkaku). |
| `vh04.json` | Map Data (VH) | Core map asset for `vh04` in Banner Village / Gregminster / Rokkaku. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vh04_00.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh04` (Banner Village / Gregminster / Rokkaku). |
| `vh04_00_00.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh04` (Banner Village / Gregminster / Rokkaku). |
| `vh04_00_01.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh04` (Banner Village / Gregminster / Rokkaku). |
| `vh04_00_02.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh04` (Banner Village / Gregminster / Rokkaku). |
| `vh04_00_03.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh04` (Banner Village / Gregminster / Rokkaku). |
| `vh04_00_05.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh04` (Banner Village / Gregminster / Rokkaku). |
| `vh04_00_06.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh04` (Banner Village / Gregminster / Rokkaku). |
| `vh04_00_07.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh04` (Banner Village / Gregminster / Rokkaku). |
| `vh04_00_09.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh04` (Banner Village / Gregminster / Rokkaku). |
| `vh04_00_10.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh04` (Banner Village / Gregminster / Rokkaku). |
| `vh04_00_11.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh04` (Banner Village / Gregminster / Rokkaku). |
| `vh04_00_13.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh04` (Banner Village / Gregminster / Rokkaku). |
| `vh04_00_14.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh04` (Banner Village / Gregminster / Rokkaku). |
| `vh04_00_obj.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh04` (Banner Village / Gregminster / Rokkaku). |
| `vh04_01.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh04` (Banner Village / Gregminster / Rokkaku). |
| `vh04_02.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh04` (Banner Village / Gregminster / Rokkaku). |
| `vh04_map_01.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh04` (Banner Village / Gregminster / Rokkaku). |
| `vh04_map_03.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh04` (Banner Village / Gregminster / Rokkaku). |
| `vh04_map_04.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh04` (Banner Village / Gregminster / Rokkaku). |
| `vh04_map_07.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh04` (Banner Village / Gregminster / Rokkaku). |
| `vh05.json` | Map Data (VH) | Core map asset for `vh05` in Banner Village / Gregminster / Rokkaku. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vh05_01.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh05` (Banner Village / Gregminster / Rokkaku). |
| `vh05_02.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh05` (Banner Village / Gregminster / Rokkaku). |
| `vh05_03.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh05` (Banner Village / Gregminster / Rokkaku). |
| `vh05_04.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh05` (Banner Village / Gregminster / Rokkaku). |
| `vh05_05.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh05` (Banner Village / Gregminster / Rokkaku). |
| `vh05_07.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh05` (Banner Village / Gregminster / Rokkaku). |
| `vh05_08.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh05` (Banner Village / Gregminster / Rokkaku). |
| `vh05_10.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh05` (Banner Village / Gregminster / Rokkaku). |
| `vh05_11.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh05` (Banner Village / Gregminster / Rokkaku). |
| `vh05_12.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh05` (Banner Village / Gregminster / Rokkaku). |
| `vh05_13.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh05` (Banner Village / Gregminster / Rokkaku). |
| `vh05_14.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh05` (Banner Village / Gregminster / Rokkaku). |
| `vh05_15.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh05` (Banner Village / Gregminster / Rokkaku). |
| `vh05_16.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh05` (Banner Village / Gregminster / Rokkaku). |
| `vh05_map_00.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh05` (Banner Village / Gregminster / Rokkaku). |
| `vh05_map_01.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh05` (Banner Village / Gregminster / Rokkaku). |
| `vh06.json` | Map Data (VH) | Core map asset for `vh06` in Banner Village / Gregminster / Rokkaku. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vh06_00.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh06` (Banner Village / Gregminster / Rokkaku). |
| `vh06_09.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh06` (Banner Village / Gregminster / Rokkaku). |
| `vh06_10.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh06` (Banner Village / Gregminster / Rokkaku). |
| `vh06_12.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh06` (Banner Village / Gregminster / Rokkaku). |
| `vh06_13.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh06` (Banner Village / Gregminster / Rokkaku). |
| `vh06_19.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh06` (Banner Village / Gregminster / Rokkaku). |
| `vh06_20.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh06` (Banner Village / Gregminster / Rokkaku). |
| `vh06_21.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh06` (Banner Village / Gregminster / Rokkaku). |
| `vh06_map_00.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh06` (Banner Village / Gregminster / Rokkaku). |
| `vh06_map_01.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh06` (Banner Village / Gregminster / Rokkaku). |
| `vh07.json` | Map Data (VH) | Core map asset for `vh07` in Banner Village / Gregminster / Rokkaku. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vh08.json` | Map Data (VH) | Core map asset for `vh08` in Banner Village / Gregminster / Rokkaku. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vh08_03.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh08` (Banner Village / Gregminster / Rokkaku). |
| `vh08_05.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh08` (Banner Village / Gregminster / Rokkaku). |
| `vh08_07.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh08` (Banner Village / Gregminster / Rokkaku). |
| `vh09.json` | Map Data (VH) | Core map asset for `vh09` in Banner Village / Gregminster / Rokkaku. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vh09_map_00.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh09` (Banner Village / Gregminster / Rokkaku). |
| `vh1.json` | Map Data (VH) | Core map asset for `vh1` in Banner Village / Gregminster / Rokkaku. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vh10.json` | Map Data (VH) | Core map asset for `vh10` in Banner Village / Gregminster / Rokkaku. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vh10_00.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh10` (Banner Village / Gregminster / Rokkaku). |
| `vh10_00_00.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh10` (Banner Village / Gregminster / Rokkaku). |
| `vh10_00_01.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh10` (Banner Village / Gregminster / Rokkaku). |
| `vh10_00_03.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh10` (Banner Village / Gregminster / Rokkaku). |
| `vh10_00_06.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh10` (Banner Village / Gregminster / Rokkaku). |
| `vh10_00_07.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh10` (Banner Village / Gregminster / Rokkaku). |
| `vh10_00_10.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh10` (Banner Village / Gregminster / Rokkaku). |
| `vh10_00_12.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh10` (Banner Village / Gregminster / Rokkaku). |
| `vh10_00_obj.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh10` (Banner Village / Gregminster / Rokkaku). |
| `vh10_04.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh10` (Banner Village / Gregminster / Rokkaku). |
| `vh10_05.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh10` (Banner Village / Gregminster / Rokkaku). |
| `vh10_map_00.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh10` (Banner Village / Gregminster / Rokkaku). |
| `vh11.json` | Map Data (VH) | Core map asset for `vh11` in Banner Village / Gregminster / Rokkaku. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vh11_11.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh11` (Banner Village / Gregminster / Rokkaku). |
| `vh11_12.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh11` (Banner Village / Gregminster / Rokkaku). |
| `vh11_14.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh11` (Banner Village / Gregminster / Rokkaku). |
| `vh11_map_00.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh11` (Banner Village / Gregminster / Rokkaku). |
| `vh12.json` | Map Data (VH) | Core map asset for `vh12` in Banner Village / Gregminster / Rokkaku. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vh12_17.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh12` (Banner Village / Gregminster / Rokkaku). |
| `vh1_map_01_battle_00.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh1_` (Banner Village / Gregminster / Rokkaku). |
| `vh1_map_01_battle_00_field.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh1_` (Banner Village / Gregminster / Rokkaku). |
| `vh1_map_01_battle_00_field_00.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh1_` (Banner Village / Gregminster / Rokkaku). |
| `vh1_map_01_battle_00_field_srn.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh1_` (Banner Village / Gregminster / Rokkaku). |
| `vh1_map_01_battle_00_monster_data_00.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh1_` (Banner Village / Gregminster / Rokkaku). |
| `vh1_map_01_battle_00_monster_data_00_00.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh1_` (Banner Village / Gregminster / Rokkaku). |
| `vh1_map_01_battle_00_monster_data_01.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh1_` (Banner Village / Gregminster / Rokkaku). |
| `vh1_map_01_battle_00_monster_data_02.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh1_` (Banner Village / Gregminster / Rokkaku). |
| `vh1_map_01_battle_00_monster_data_02_00.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh1_` (Banner Village / Gregminster / Rokkaku). |
| `vh1_map_01_battle_00_monster_data_03.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh1_` (Banner Village / Gregminster / Rokkaku). |
| `vh1_map_01_battle_00_monster_data_04.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh1_` (Banner Village / Gregminster / Rokkaku). |
| `vh1_map_01_battle_00_monster_party_01.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh1_` (Banner Village / Gregminster / Rokkaku). |
| `vh1_map_01_battle_00_monster_party_02.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh1_` (Banner Village / Gregminster / Rokkaku). |
| `vh1_map_01_battle_00_monster_party_03.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh1_` (Banner Village / Gregminster / Rokkaku). |
| `vh1_map_01_battle_00_monster_party_04.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh1_` (Banner Village / Gregminster / Rokkaku). |
| `vh1_map_01_battle_00_monster_party_05.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh1_` (Banner Village / Gregminster / Rokkaku). |
| `vh1_map_01_battle_00_monster_party_06.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh1_` (Banner Village / Gregminster / Rokkaku). |
| `vh1_map_01_battle_00_monster_party_07.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh1_` (Banner Village / Gregminster / Rokkaku). |
| `vh1_map_01_battle_00_monster_party_08.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh1_` (Banner Village / Gregminster / Rokkaku). |
| `vh1_map_01_battle_00_monster_party_09.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh1_` (Banner Village / Gregminster / Rokkaku). |
| `vh1_map_01_battle_00_monster_party_11.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh1_` (Banner Village / Gregminster / Rokkaku). |
| `vh1_map_01_battle_00_monster_party_12.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh1_` (Banner Village / Gregminster / Rokkaku). |
| `vh1_map_01_battle_00_monster_party_14.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh1_` (Banner Village / Gregminster / Rokkaku). |
| `vh1_map_01_battle_00_monster_party_15.json` | Map Sub-Asset (VH) | Map background layer / 3D prop configuration for `vh1_` (Banner Village / Gregminster / Rokkaku). |
| `vh2.json` | Map Data (VH) | Core map asset for `vh2` in Banner Village / Gregminster / Rokkaku. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |

### <a id="region-vi-castle-headquarters-tiers-levels-1-4"></a>Region VI: Castle Headquarters Tiers (Levels 1-4) (118 files)

| File Name | Subsystem / Type | Technical Role & Grounded Description |
|---|---|---|
| `vi01.json` | Map Data (VI) | Core map asset for `vi01` in Headquarters (Castle Level 1-4). Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vi01_map_00.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi01` (Headquarters (Castle Level 1-4)). |
| `vi01_map_01.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi01` (Headquarters (Castle Level 1-4)). |
| `vi02.json` | Map Data (VI) | Core map asset for `vi02` in Headquarters (Castle Level 1-4). Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vi02_map_00.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi02` (Headquarters (Castle Level 1-4)). |
| `vi02_map_01.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi02` (Headquarters (Castle Level 1-4)). |
| `vi03.json` | Map Data (VI) | Core map asset for `vi03` in Headquarters (Castle Level 1-4). Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vi03_00.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi03` (Headquarters (Castle Level 1-4)). |
| `vi03_00_00.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi03` (Headquarters (Castle Level 1-4)). |
| `vi03_00_obj.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi03` (Headquarters (Castle Level 1-4)). |
| `vi03_map_00.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi03` (Headquarters (Castle Level 1-4)). |
| `vi04.json` | Map Data (VI) | Core map asset for `vi04` in Headquarters (Castle Level 1-4). Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vi04_map_00.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi04` (Headquarters (Castle Level 1-4)). |
| `vi05.json` | Map Data (VI) | Core map asset for `vi05` in Headquarters (Castle Level 1-4). Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vi05_06.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi05` (Headquarters (Castle Level 1-4)). |
| `vi05_07.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi05` (Headquarters (Castle Level 1-4)). |
| `vi05_08.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi05` (Headquarters (Castle Level 1-4)). |
| `vi05_09.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi05` (Headquarters (Castle Level 1-4)). |
| `vi05_map_00.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi05` (Headquarters (Castle Level 1-4)). |
| `vi06.json` | Map Data (VI) | Core map asset for `vi06` in Headquarters (Castle Level 1-4). Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vi06_00.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi06` (Headquarters (Castle Level 1-4)). |
| `vi06_00_00.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi06` (Headquarters (Castle Level 1-4)). |
| `vi06_00_01.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi06` (Headquarters (Castle Level 1-4)). |
| `vi06_00_02.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi06` (Headquarters (Castle Level 1-4)). |
| `vi06_00_03.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi06` (Headquarters (Castle Level 1-4)). |
| `vi06_00_04.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi06` (Headquarters (Castle Level 1-4)). |
| `vi06_00_05.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi06` (Headquarters (Castle Level 1-4)). |
| `vi06_00_06.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi06` (Headquarters (Castle Level 1-4)). |
| `vi06_00_07.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi06` (Headquarters (Castle Level 1-4)). |
| `vi06_00_09.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi06` (Headquarters (Castle Level 1-4)). |
| `vi06_00_10.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi06` (Headquarters (Castle Level 1-4)). |
| `vi06_00_12.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi06` (Headquarters (Castle Level 1-4)). |
| `vi06_00_14.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi06` (Headquarters (Castle Level 1-4)). |
| `vi06_00_16.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi06` (Headquarters (Castle Level 1-4)). |
| `vi06_00_18.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi06` (Headquarters (Castle Level 1-4)). |
| `vi06_00_20.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi06` (Headquarters (Castle Level 1-4)). |
| `vi06_00_obj.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi06` (Headquarters (Castle Level 1-4)). |
| `vi06_map_00.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi06` (Headquarters (Castle Level 1-4)). |
| `vi07.json` | Map Data (VI) | Core map asset for `vi07` in Headquarters (Castle Level 1-4). Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vi07_map_01.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi07` (Headquarters (Castle Level 1-4)). |
| `vi08.json` | Map Data (VI) | Core map asset for `vi08` in Headquarters (Castle Level 1-4). Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vi08_00.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi08` (Headquarters (Castle Level 1-4)). |
| `vi08_00_00.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi08` (Headquarters (Castle Level 1-4)). |
| `vi08_00_01.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi08` (Headquarters (Castle Level 1-4)). |
| `vi08_00_02.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi08` (Headquarters (Castle Level 1-4)). |
| `vi08_00_03.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi08` (Headquarters (Castle Level 1-4)). |
| `vi08_00_04.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi08` (Headquarters (Castle Level 1-4)). |
| `vi08_00_05.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi08` (Headquarters (Castle Level 1-4)). |
| `vi08_00_06.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi08` (Headquarters (Castle Level 1-4)). |
| `vi08_00_08.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi08` (Headquarters (Castle Level 1-4)). |
| `vi08_00_10.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi08` (Headquarters (Castle Level 1-4)). |
| `vi08_00_12.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi08` (Headquarters (Castle Level 1-4)). |
| `vi08_00_14.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi08` (Headquarters (Castle Level 1-4)). |
| `vi08_00_16.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi08` (Headquarters (Castle Level 1-4)). |
| `vi08_00_obj.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi08` (Headquarters (Castle Level 1-4)). |
| `vi08_01.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi08` (Headquarters (Castle Level 1-4)). |
| `vi08_01_obj.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi08` (Headquarters (Castle Level 1-4)). |
| `vi08_02.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi08` (Headquarters (Castle Level 1-4)). |
| `vi08_02_00.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi08` (Headquarters (Castle Level 1-4)). |
| `vi08_map_00.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi08` (Headquarters (Castle Level 1-4)). |
| `vi09.json` | Map Data (VI) | Core map asset for `vi09` in Headquarters (Castle Level 1-4). Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vi1.json` | Map Data (VI) | Core map asset for `vi1` in Headquarters (Castle Level 1-4). Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vi10.json` | Map Data (VI) | Core map asset for `vi10` in Headquarters (Castle Level 1-4). Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vi10_00.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi10` (Headquarters (Castle Level 1-4)). |
| `vi10_01.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi10` (Headquarters (Castle Level 1-4)). |
| `vi10_07.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi10` (Headquarters (Castle Level 1-4)). |
| `vi10_08.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi10` (Headquarters (Castle Level 1-4)). |
| `vi10_09.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi10` (Headquarters (Castle Level 1-4)). |
| `vi10_15.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi10` (Headquarters (Castle Level 1-4)). |
| `vi11.json` | Map Data (VI) | Core map asset for `vi11` in Headquarters (Castle Level 1-4). Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vi11_map_00.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi11` (Headquarters (Castle Level 1-4)). |
| `vi12.json` | Map Data (VI) | Core map asset for `vi12` in Headquarters (Castle Level 1-4). Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vi12_00.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi12` (Headquarters (Castle Level 1-4)). |
| `vi12_01.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi12` (Headquarters (Castle Level 1-4)). |
| `vi12_02.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi12` (Headquarters (Castle Level 1-4)). |
| `vi12_28.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi12` (Headquarters (Castle Level 1-4)). |
| `vi12_map_00.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi12` (Headquarters (Castle Level 1-4)). |
| `vi12_map_01.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi12` (Headquarters (Castle Level 1-4)). |
| `vi13.json` | Map Data (VI) | Core map asset for `vi13` in Headquarters (Castle Level 1-4). Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vi13_00.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi13` (Headquarters (Castle Level 1-4)). |
| `vi13_00_00.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi13` (Headquarters (Castle Level 1-4)). |
| `vi13_00_01.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi13` (Headquarters (Castle Level 1-4)). |
| `vi13_00_02.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi13` (Headquarters (Castle Level 1-4)). |
| `vi13_00_03.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi13` (Headquarters (Castle Level 1-4)). |
| `vi13_00_04.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi13` (Headquarters (Castle Level 1-4)). |
| `vi13_00_05.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi13` (Headquarters (Castle Level 1-4)). |
| `vi13_00_06.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi13` (Headquarters (Castle Level 1-4)). |
| `vi13_00_07.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi13` (Headquarters (Castle Level 1-4)). |
| `vi13_00_08.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi13` (Headquarters (Castle Level 1-4)). |
| `vi13_00_09.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi13` (Headquarters (Castle Level 1-4)). |
| `vi13_00_11.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi13` (Headquarters (Castle Level 1-4)). |
| `vi13_00_13.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi13` (Headquarters (Castle Level 1-4)). |
| `vi13_00_14.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi13` (Headquarters (Castle Level 1-4)). |
| `vi13_00_15.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi13` (Headquarters (Castle Level 1-4)). |
| `vi13_01.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi13` (Headquarters (Castle Level 1-4)). |
| `vi13_01_00.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi13` (Headquarters (Castle Level 1-4)). |
| `vi13_01_01.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi13` (Headquarters (Castle Level 1-4)). |
| `vi13_01_03.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi13` (Headquarters (Castle Level 1-4)). |
| `vi13_01_04.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi13` (Headquarters (Castle Level 1-4)). |
| `vi13_01_06.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi13` (Headquarters (Castle Level 1-4)). |
| `vi13_01_08.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi13` (Headquarters (Castle Level 1-4)). |
| `vi13_01_10.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi13` (Headquarters (Castle Level 1-4)). |
| `vi13_01_12.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi13` (Headquarters (Castle Level 1-4)). |
| `vi13_01_13.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi13` (Headquarters (Castle Level 1-4)). |
| `vi13_01_16.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi13` (Headquarters (Castle Level 1-4)). |
| `vi13_map_00.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi13` (Headquarters (Castle Level 1-4)). |
| `vi14.json` | Map Data (VI) | Core map asset for `vi14` in Headquarters (Castle Level 1-4). Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vi14_map_00.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi14` (Headquarters (Castle Level 1-4)). |
| `vi15.json` | Map Data (VI) | Core map asset for `vi15` in Headquarters (Castle Level 1-4). Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vi15_00.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi15` (Headquarters (Castle Level 1-4)). |
| `vi15_02.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi15` (Headquarters (Castle Level 1-4)). |
| `vi15_03.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi15` (Headquarters (Castle Level 1-4)). |
| `vi15_04.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi15` (Headquarters (Castle Level 1-4)). |
| `vi1_map_00_04.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vi1_` (Headquarters (Castle Level 1-4)). |
| `vi2.json` | Map Data (VI) | Core map asset for `vi2` in Headquarters (Castle Level 1-4). Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vic.json` | Map Data (VI) | Core map asset for `vic` in Headquarters (Castle Level 1-4). Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vic_battle_00.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vic_` (Headquarters (Castle Level 1-4)). |
| `vic_field_00.json` | Map Sub-Asset (VI) | Map background layer / 3D prop configuration for `vic_` (Headquarters (Castle Level 1-4)). |

### <a id="region-vj-lrenouille-sajah-village-beast-rune-altar"></a>Region VJ: L'Renouille / Sajah Village / Beast Rune Altar (228 files)

| File Name | Subsystem / Type | Technical Role & Grounded Description |
|---|---|---|
| `vj01.json` | Map Data (VJ) | Core map asset for `vj01` in L'Renouille / Sajah Village / Beast Rune Altar. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vj01_map_00.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj01` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj02.json` | Map Data (VJ) | Core map asset for `vj02` in L'Renouille / Sajah Village / Beast Rune Altar. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vj02_00.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj02` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj02_00_00.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj02` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj02_00_01.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj02` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj02_00_02.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj02` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj02_00_03.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj02` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj02_00_04.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj02` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj02_00_05.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj02` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj02_00_06.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj02` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj02_00_obj.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj02` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj02_01.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj02` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj02_01_00.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj02` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj02_01_03.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj02` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj02_01_07.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj02` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj02_01_08.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj02` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj02_02.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj02` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj02_02_00.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj02` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj02_03.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj02` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj02_04.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj02` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj02_05.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj02` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj02_06.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj02` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj02_07.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj02` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj02_08.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj02` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj02_map_00.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj02` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj03.json` | Map Data (VJ) | Core map asset for `vj03` in L'Renouille / Sajah Village / Beast Rune Altar. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vj03_00.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj03` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj03_00_00.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj03` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj03_00_01.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj03` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj03_00_02.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj03` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj03_00_03.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj03` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj03_00_04.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj03` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj03_00_05.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj03` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj03_00_06.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj03` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj03_00_07.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj03` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj03_00_08.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj03` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj03_00_09.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj03` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj03_00_12.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj03` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj03_00_14.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj03` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj03_00_17.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj03` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj03_01.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj03` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj03_01_00.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj03` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj04.json` | Map Data (VJ) | Core map asset for `vj04` in L'Renouille / Sajah Village / Beast Rune Altar. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vj04_00.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj04` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj04_00_00.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj04` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj04_00_01.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj04` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj04_00_02.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj04` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj04_00_03.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj04` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj04_00_04.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj04` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj04_00_05.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj04` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj04_00_06.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj04` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj04_00_07.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj04` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj04_00_08.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj04` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj04_00_09.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj04` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj04_00_12.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj04` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj04_00_14.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj04` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj04_00_17.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj04` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj04_00_obj.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj04` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj04_01.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj04` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj04_01_00.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj04` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj04_map_00.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj04` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj05.json` | Map Data (VJ) | Core map asset for `vj05` in L'Renouille / Sajah Village / Beast Rune Altar. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vj05_00.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj05` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj05_00_00.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj05` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj05_00_01.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj05` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj05_00_02.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj05` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj05_00_03.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj05` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj05_00_04.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj05` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj05_00_05.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj05` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj05_00_06.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj05` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj05_00_07.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj05` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj05_00_08.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj05` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj05_00_09.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj05` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj05_00_12.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj05` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj05_00_14.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj05` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj05_00_17.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj05` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj05_00_obj.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj05` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj05_01.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj05` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj05_01_00.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj05` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj05_map_00.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj05` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj06.json` | Map Data (VJ) | Core map asset for `vj06` in L'Renouille / Sajah Village / Beast Rune Altar. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vj06_00.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj06` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj06_00_00.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj06` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj06_00_01.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj06` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj06_00_02.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj06` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj06_00_03.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj06` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj06_00_04.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj06` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj06_00_05.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj06` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj06_00_06.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj06` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj07.json` | Map Data (VJ) | Core map asset for `vj07` in L'Renouille / Sajah Village / Beast Rune Altar. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vj07_01.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj07` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj07_03.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj07` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj07_map_00.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj07` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj08.json` | Map Data (VJ) | Core map asset for `vj08` in L'Renouille / Sajah Village / Beast Rune Altar. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vj08_01.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj08` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj08_02.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj08` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj08_03.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj08` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj08_04.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj08` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj08_06.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj08` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj08_map_00.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj08` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj09.json` | Map Data (VJ) | Core map asset for `vj09` in L'Renouille / Sajah Village / Beast Rune Altar. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vj09_03.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj09` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj10.json` | Map Data (VJ) | Core map asset for `vj10` in L'Renouille / Sajah Village / Beast Rune Altar. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vj10_01.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj10` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj10_03.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj10` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj10_05.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj10` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj10_06.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj10` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj10_08.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj10` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj10_10.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj10` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj10_map_00.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj10` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj11.json` | Map Data (VJ) | Core map asset for `vj11` in L'Renouille / Sajah Village / Beast Rune Altar. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vj11_00.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj11` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj11_00_00.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj11` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj11_00_01.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj11` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj11_00_02.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj11` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj11_00_03.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj11` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj11_00_04.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj11` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj11_00_05.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj11` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj11_00_06.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj11` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj11_00_07.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj11` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj11_00_08.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj11` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj11_00_09.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj11` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj11_00_12.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj11` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj11_00_14.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj11` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj11_00_17.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj11` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj11_01.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj11` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj11_01_00.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj11` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj11_02.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj11` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj11_map_00.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj11` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj12.json` | Map Data (VJ) | Core map asset for `vj12` in L'Renouille / Sajah Village / Beast Rune Altar. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vj12_map_00.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj12` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj13.json` | Map Data (VJ) | Core map asset for `vj13` in L'Renouille / Sajah Village / Beast Rune Altar. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vj13_01.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj13` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj13_06.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj13` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj13_11.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj13` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj13_map_00.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj13` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj14.json` | Map Data (VJ) | Core map asset for `vj14` in L'Renouille / Sajah Village / Beast Rune Altar. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vj14_map_00.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj14` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj15.json` | Map Data (VJ) | Core map asset for `vj15` in L'Renouille / Sajah Village / Beast Rune Altar. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vj15_map_00.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj15` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj16.json` | Map Data (VJ) | Core map asset for `vj16` in L'Renouille / Sajah Village / Beast Rune Altar. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vj16_00.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj16` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj16_map_00.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj16` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj17.json` | Map Data (VJ) | Core map asset for `vj17` in L'Renouille / Sajah Village / Beast Rune Altar. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vj17_01.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj17` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj17_02.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj17` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj17_03.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj17` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj17_09.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj17` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj17_15.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj17` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj17_map_00.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj17` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj17_map_01.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj17` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj18.json` | Map Data (VJ) | Core map asset for `vj18` in L'Renouille / Sajah Village / Beast Rune Altar. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vj18_00.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj18` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj18_00_00.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj18` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj18_00_01.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj18` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj18_00_02.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj18` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj18_00_03.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj18` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj18_00_04.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj18` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj18_00_05.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj18` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj18_00_06.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj18` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj18_00_obj.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj18` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj18_map_00.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj18` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj18_map_01.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj18` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj18_map_02.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj18` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj18_map_03.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj18` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj19.json` | Map Data (VJ) | Core map asset for `vj19` in L'Renouille / Sajah Village / Beast Rune Altar. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vj19_01.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj19` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj19_05.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj19` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj19_07.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj19` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj20.json` | Map Data (VJ) | Core map asset for `vj20` in L'Renouille / Sajah Village / Beast Rune Altar. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vj20_00.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj20` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj20_00_00.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj20` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj20_00_01.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj20` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj20_00_02.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj20` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj20_00_03.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj20` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj20_00_04.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj20` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj20_00_07.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj20` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj20_00_08.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj20` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj20_00_14.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj20` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj20_00_17.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj20` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj20_00_20.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj20` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj20_00_21.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj20` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj21.json` | Map Data (VJ) | Core map asset for `vj21` in L'Renouille / Sajah Village / Beast Rune Altar. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vj21_00.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj21` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj21_00_00.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj21` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj21_00_01.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj21` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj21_00_02.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj21` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj21_00_05.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj21` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj21_00_06.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj21` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj21_00_08.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj21` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj21_00_09.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj21` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj21_00_12.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj21` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj21_00_14.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj21` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj22.json` | Map Data (VJ) | Core map asset for `vj22` in L'Renouille / Sajah Village / Beast Rune Altar. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vj22_00.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj22` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj22_00_00.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj22` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj22_00_01.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj22` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj22_00_02.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj22` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj22_00_03.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj22` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj22_00_04.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj22` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj22_00_05.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj22` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj22_00_06.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj22` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj22_00_07.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj22` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj22_00_08.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj22` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj22_00_09.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj22` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj22_00_10.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj22` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj23.json` | Map Data (VJ) | Core map asset for `vj23` in L'Renouille / Sajah Village / Beast Rune Altar. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vj23_00.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj23` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj23_00_00.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj23` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj23_00_01.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj23` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj23_00_03.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj23` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj23_00_06.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj23` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj23_00_08.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj23` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj23_00_09.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj23` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj23_00_13.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj23` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj23_00_17.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj23` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj24.json` | Map Data (VJ) | Core map asset for `vj24` in L'Renouille / Sajah Village / Beast Rune Altar. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vj24_00.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj24` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj24_00_00.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj24` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj24_00_01.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj24` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj24_00_02.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj24` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj24_00_03.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj24` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj24_00_05.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj24` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj24_00_07.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj24` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj24_00_08.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj24` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj24_00_09.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj24` (L'Renouille / Sajah Village / Beast Rune Altar). |
| `vj24_00_12.json` | Map Sub-Asset (VJ) | Map background layer / 3D prop configuration for `vj24` (L'Renouille / Sajah Village / Beast Rune Altar). |

### <a id="region-vk-castle-hq-facilities-special-event-staging"></a>Region VK: Castle HQ Facilities & Special Event Staging (160 files)

| File Name | Subsystem / Type | Technical Role & Grounded Description |
|---|---|---|
| `vk01.json` | Map Data (VK) | Core map asset for `vk01` in Special / Cutscene / Intro Areas. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vk01_03.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk01` (Special / Cutscene / Intro Areas). |
| `vk01_24.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk01` (Special / Cutscene / Intro Areas). |
| `vk01_map_00.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk01` (Special / Cutscene / Intro Areas). |
| `vk01_map_01.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk01` (Special / Cutscene / Intro Areas). |
| `vk01_map_02.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk01` (Special / Cutscene / Intro Areas). |
| `vk02.json` | Map Data (VK) | Core map asset for `vk02` in Special / Cutscene / Intro Areas. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vk02_11.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk02` (Special / Cutscene / Intro Areas). |
| `vk02_map_00.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk02` (Special / Cutscene / Intro Areas). |
| `vk02_map_01.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk02` (Special / Cutscene / Intro Areas). |
| `vk02_map_02.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk02` (Special / Cutscene / Intro Areas). |
| `vk02_map_03.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk02` (Special / Cutscene / Intro Areas). |
| `vk02_map_04.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk02` (Special / Cutscene / Intro Areas). |
| `vk02_map_05.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk02` (Special / Cutscene / Intro Areas). |
| `vk02_map_06.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk02` (Special / Cutscene / Intro Areas). |
| `vk03.json` | Map Data (VK) | Core map asset for `vk03` in Special / Cutscene / Intro Areas. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vk03_04.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk03` (Special / Cutscene / Intro Areas). |
| `vk03_06.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk03` (Special / Cutscene / Intro Areas). |
| `vk03_08.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk03` (Special / Cutscene / Intro Areas). |
| `vk03_map_00.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk03` (Special / Cutscene / Intro Areas). |
| `vk04.json` | Map Data (VK) | Core map asset for `vk04` in Special / Cutscene / Intro Areas. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vk04_01.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk04` (Special / Cutscene / Intro Areas). |
| `vk04_04.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk04` (Special / Cutscene / Intro Areas). |
| `vk04_08.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk04` (Special / Cutscene / Intro Areas). |
| `vk04_10.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk04` (Special / Cutscene / Intro Areas). |
| `vk04_22.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk04` (Special / Cutscene / Intro Areas). |
| `vk04_30.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk04` (Special / Cutscene / Intro Areas). |
| `vk04_map_00.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk04` (Special / Cutscene / Intro Areas). |
| `vk05.json` | Map Data (VK) | Core map asset for `vk05` in Special / Cutscene / Intro Areas. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vk06.json` | Map Data (VK) | Core map asset for `vk06` in Special / Cutscene / Intro Areas. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vk06_17.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk06` (Special / Cutscene / Intro Areas). |
| `vk06_18.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk06` (Special / Cutscene / Intro Areas). |
| `vk06_24.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk06` (Special / Cutscene / Intro Areas). |
| `vk06_25.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk06` (Special / Cutscene / Intro Areas). |
| `vk06_26.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk06` (Special / Cutscene / Intro Areas). |
| `vk06_map_00.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk06` (Special / Cutscene / Intro Areas). |
| `vk06_map_01.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk06` (Special / Cutscene / Intro Areas). |
| `vk06_map_02.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk06` (Special / Cutscene / Intro Areas). |
| `vk07.json` | Map Data (VK) | Core map asset for `vk07` in Special / Cutscene / Intro Areas. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vk07_22.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk07` (Special / Cutscene / Intro Areas). |
| `vk07_etc_map_00.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk07` (Special / Cutscene / Intro Areas). |
| `vk07_etc_map_01.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk07` (Special / Cutscene / Intro Areas). |
| `vk07_map_00.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk07` (Special / Cutscene / Intro Areas). |
| `vk07_map_01.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk07` (Special / Cutscene / Intro Areas). |
| `vk08.json` | Map Data (VK) | Core map asset for `vk08` in Special / Cutscene / Intro Areas. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vk08_13.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk08` (Special / Cutscene / Intro Areas). |
| `vk08_16.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk08` (Special / Cutscene / Intro Areas). |
| `vk08_19.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk08` (Special / Cutscene / Intro Areas). |
| `vk08_20.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk08` (Special / Cutscene / Intro Areas). |
| `vk08_22.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk08` (Special / Cutscene / Intro Areas). |
| `vk08_25.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk08` (Special / Cutscene / Intro Areas). |
| `vk08_28.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk08` (Special / Cutscene / Intro Areas). |
| `vk08_30.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk08` (Special / Cutscene / Intro Areas). |
| `vk08_33.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk08` (Special / Cutscene / Intro Areas). |
| `vk08_35.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk08` (Special / Cutscene / Intro Areas). |
| `vk08_37.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk08` (Special / Cutscene / Intro Areas). |
| `vk08_39.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk08` (Special / Cutscene / Intro Areas). |
| `vk08_etc_map_00.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk08` (Special / Cutscene / Intro Areas). |
| `vk08_map_00.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk08` (Special / Cutscene / Intro Areas). |
| `vk09.json` | Map Data (VK) | Core map asset for `vk09` in Special / Cutscene / Intro Areas. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vk09_01.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk09` (Special / Cutscene / Intro Areas). |
| `vk09_03.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk09` (Special / Cutscene / Intro Areas). |
| `vk09_05.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk09` (Special / Cutscene / Intro Areas). |
| `vk09_14.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk09` (Special / Cutscene / Intro Areas). |
| `vk09_16.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk09` (Special / Cutscene / Intro Areas). |
| `vk09_map_00.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk09` (Special / Cutscene / Intro Areas). |
| `vk10.json` | Map Data (VK) | Core map asset for `vk10` in Special / Cutscene / Intro Areas. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vk10_map_00.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk10` (Special / Cutscene / Intro Areas). |
| `vk11.json` | Map Data (VK) | Core map asset for `vk11` in Special / Cutscene / Intro Areas. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vk11_12.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk11` (Special / Cutscene / Intro Areas). |
| `vk11_17.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk11` (Special / Cutscene / Intro Areas). |
| `vk11_map_00.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk11` (Special / Cutscene / Intro Areas). |
| `vk12.json` | Map Data (VK) | Core map asset for `vk12` in Special / Cutscene / Intro Areas. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vk12_map_00.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk12` (Special / Cutscene / Intro Areas). |
| `vk13.json` | Map Data (VK) | Core map asset for `vk13` in Special / Cutscene / Intro Areas. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vk13_etc_map_00.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk13` (Special / Cutscene / Intro Areas). |
| `vk13_etc_map_01.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk13` (Special / Cutscene / Intro Areas). |
| `vk13_etc_map_02.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk13` (Special / Cutscene / Intro Areas). |
| `vk13_map_00.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk13` (Special / Cutscene / Intro Areas). |
| `vk13_map_01.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk13` (Special / Cutscene / Intro Areas). |
| `vk13_map_02.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk13` (Special / Cutscene / Intro Areas). |
| `vk14.json` | Map Data (VK) | Core map asset for `vk14` in Special / Cutscene / Intro Areas. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vk14_10.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk14` (Special / Cutscene / Intro Areas). |
| `vk14_12.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk14` (Special / Cutscene / Intro Areas). |
| `vk14_15.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk14` (Special / Cutscene / Intro Areas). |
| `vk14_17.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk14` (Special / Cutscene / Intro Areas). |
| `vk14_19.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk14` (Special / Cutscene / Intro Areas). |
| `vk14_21.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk14` (Special / Cutscene / Intro Areas). |
| `vk14_23.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk14` (Special / Cutscene / Intro Areas). |
| `vk14_33.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk14` (Special / Cutscene / Intro Areas). |
| `vk14_map_00.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk14` (Special / Cutscene / Intro Areas). |
| `vk15.json` | Map Data (VK) | Core map asset for `vk15` in Special / Cutscene / Intro Areas. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vk15_map_00.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk15` (Special / Cutscene / Intro Areas). |
| `vk16.json` | Map Data (VK) | Core map asset for `vk16` in Special / Cutscene / Intro Areas. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vk16_etc_map_00.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk16` (Special / Cutscene / Intro Areas). |
| `vk16_map_00.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk16` (Special / Cutscene / Intro Areas). |
| `vk17.json` | Map Data (VK) | Core map asset for `vk17` in Special / Cutscene / Intro Areas. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vk17_map_00.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk17` (Special / Cutscene / Intro Areas). |
| `vk18.json` | Map Data (VK) | Core map asset for `vk18` in Special / Cutscene / Intro Areas. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vk18_09.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk18` (Special / Cutscene / Intro Areas). |
| `vk18_map_00.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk18` (Special / Cutscene / Intro Areas). |
| `vk19.json` | Map Data (VK) | Core map asset for `vk19` in Special / Cutscene / Intro Areas. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vk19_01.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk19` (Special / Cutscene / Intro Areas). |
| `vk19_03.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk19` (Special / Cutscene / Intro Areas). |
| `vk19_09.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk19` (Special / Cutscene / Intro Areas). |
| `vk19_18.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk19` (Special / Cutscene / Intro Areas). |
| `vk19_19.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk19` (Special / Cutscene / Intro Areas). |
| `vk19_21.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk19` (Special / Cutscene / Intro Areas). |
| `vk19_map_00.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk19` (Special / Cutscene / Intro Areas). |
| `vk20.json` | Map Data (VK) | Core map asset for `vk20` in Special / Cutscene / Intro Areas. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vk20_map_00.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk20` (Special / Cutscene / Intro Areas). |
| `vk21.json` | Map Data (VK) | Core map asset for `vk21` in Special / Cutscene / Intro Areas. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vk21_02.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk21` (Special / Cutscene / Intro Areas). |
| `vk21_map_00.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk21` (Special / Cutscene / Intro Areas). |
| `vk22.json` | Map Data (VK) | Core map asset for `vk22` in Special / Cutscene / Intro Areas. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vk22_06.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk22` (Special / Cutscene / Intro Areas). |
| `vk22_08.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk22` (Special / Cutscene / Intro Areas). |
| `vk22_09.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk22` (Special / Cutscene / Intro Areas). |
| `vk22_map_00.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk22` (Special / Cutscene / Intro Areas). |
| `vk23.json` | Map Data (VK) | Core map asset for `vk23` in Special / Cutscene / Intro Areas. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vk23_11.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk23` (Special / Cutscene / Intro Areas). |
| `vk23_map_00.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk23` (Special / Cutscene / Intro Areas). |
| `vk24.json` | Map Data (VK) | Core map asset for `vk24` in Special / Cutscene / Intro Areas. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vk25.json` | Map Data (VK) | Core map asset for `vk25` in Special / Cutscene / Intro Areas. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vk26.json` | Map Data (VK) | Core map asset for `vk26` in Special / Cutscene / Intro Areas. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vk27.json` | Map Data (VK) | Core map asset for `vk27` in Special / Cutscene / Intro Areas. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vk28.json` | Map Data (VK) | Core map asset for `vk28` in Special / Cutscene / Intro Areas. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vk29.json` | Map Data (VK) | Core map asset for `vk29` in Special / Cutscene / Intro Areas. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vk29_etc_12.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk29` (Special / Cutscene / Intro Areas). |
| `vk29_map_01.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk29` (Special / Cutscene / Intro Areas). |
| `vk30.json` | Map Data (VK) | Core map asset for `vk30` in Special / Cutscene / Intro Areas. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vk30_02.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk30` (Special / Cutscene / Intro Areas). |
| `vk30_09.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk30` (Special / Cutscene / Intro Areas). |
| `vk30_10.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk30` (Special / Cutscene / Intro Areas). |
| `vk30_11.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk30` (Special / Cutscene / Intro Areas). |
| `vk30_12.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk30` (Special / Cutscene / Intro Areas). |
| `vk30_13.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk30` (Special / Cutscene / Intro Areas). |
| `vk30_14.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk30` (Special / Cutscene / Intro Areas). |
| `vk30_15.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk30` (Special / Cutscene / Intro Areas). |
| `vk30_16.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk30` (Special / Cutscene / Intro Areas). |
| `vk30_17.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk30` (Special / Cutscene / Intro Areas). |
| `vk30_18.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk30` (Special / Cutscene / Intro Areas). |
| `vk30_19.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk30` (Special / Cutscene / Intro Areas). |
| `vk30_21.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk30` (Special / Cutscene / Intro Areas). |
| `vk30_23.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk30` (Special / Cutscene / Intro Areas). |
| `vk30_24.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk30` (Special / Cutscene / Intro Areas). |
| `vk30_25.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk30` (Special / Cutscene / Intro Areas). |
| `vk30_26.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk30` (Special / Cutscene / Intro Areas). |
| `vk31.json` | Map Data (VK) | Core map asset for `vk31` in Special / Cutscene / Intro Areas. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vk32.json` | Map Data (VK) | Core map asset for `vk32` in Special / Cutscene / Intro Areas. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vk32_etc_map_01.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk32` (Special / Cutscene / Intro Areas). |
| `vk33.json` | Map Data (VK) | Core map asset for `vk33` in Special / Cutscene / Intro Areas. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vk33_22.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk33` (Special / Cutscene / Intro Areas). |
| `vk34.json` | Map Data (VK) | Core map asset for `vk34` in Special / Cutscene / Intro Areas. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vk34_19.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk34` (Special / Cutscene / Intro Areas). |
| `vk35.json` | Map Data (VK) | Core map asset for `vk35` in Special / Cutscene / Intro Areas. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vk35_map_00.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk35` (Special / Cutscene / Intro Areas). |
| `vk36.json` | Map Data (VK) | Core map asset for `vk36` in Special / Cutscene / Intro Areas. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vk37.json` | Map Data (VK) | Core map asset for `vk37` in Special / Cutscene / Intro Areas. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vk37_map_00.json` | Map Sub-Asset (VK) | Map background layer / 3D prop configuration for `vk37` (Special / Cutscene / Intro Areas). |

### <a id="region-vs-suikoden-i-retrospective-special-maps"></a>Region VS: Suikoden I Retrospective Special Maps (29 files)

| File Name | Subsystem / Type | Technical Role & Grounded Description |
|---|---|---|
| `vs1.json` | Map Data (VS) | Core map asset for `vs1` in Suikoden 1 Retrospective / Special Maps. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vs1_map_02_02.json` | Map Sub-Asset (VS) | Map background layer / 3D prop configuration for `vs1_` (Suikoden 1 Retrospective / Special Maps). |
| `vs1_map_02_battle_00.json` | Map Sub-Asset (VS) | Map background layer / 3D prop configuration for `vs1_` (Suikoden 1 Retrospective / Special Maps). |
| `vs1_map_02_battle_00_field.json` | Map Sub-Asset (VS) | Map background layer / 3D prop configuration for `vs1_` (Suikoden 1 Retrospective / Special Maps). |
| `vs1_map_02_battle_00_field_00.json` | Map Sub-Asset (VS) | Map background layer / 3D prop configuration for `vs1_` (Suikoden 1 Retrospective / Special Maps). |
| `vs1_map_02_battle_00_field_srn.json` | Map Sub-Asset (VS) | Map background layer / 3D prop configuration for `vs1_` (Suikoden 1 Retrospective / Special Maps). |
| `vs1_map_02_battle_00_monster_data_00.json` | Map Sub-Asset (VS) | Map background layer / 3D prop configuration for `vs1_` (Suikoden 1 Retrospective / Special Maps). |
| `vs1_map_02_battle_00_monster_data_01.json` | Map Sub-Asset (VS) | Map background layer / 3D prop configuration for `vs1_` (Suikoden 1 Retrospective / Special Maps). |
| `vs1_map_02_battle_00_monster_data_02.json` | Map Sub-Asset (VS) | Map background layer / 3D prop configuration for `vs1_` (Suikoden 1 Retrospective / Special Maps). |
| `vs1_map_02_battle_00_monster_data_02_00.json` | Map Sub-Asset (VS) | Map background layer / 3D prop configuration for `vs1_` (Suikoden 1 Retrospective / Special Maps). |
| `vs1_map_02_battle_00_monster_party_00.json` | Map Sub-Asset (VS) | Map background layer / 3D prop configuration for `vs1_` (Suikoden 1 Retrospective / Special Maps). |
| `vs1_map_02_battle_00_monster_party_04.json` | Map Sub-Asset (VS) | Map background layer / 3D prop configuration for `vs1_` (Suikoden 1 Retrospective / Special Maps). |
| `vs1_map_02_battle_00_monster_party_05.json` | Map Sub-Asset (VS) | Map background layer / 3D prop configuration for `vs1_` (Suikoden 1 Retrospective / Special Maps). |
| `vs1_map_02_battle_00_monster_party_06.json` | Map Sub-Asset (VS) | Map background layer / 3D prop configuration for `vs1_` (Suikoden 1 Retrospective / Special Maps). |
| `vs1_map_02_battle_01.json` | Map Sub-Asset (VS) | Map background layer / 3D prop configuration for `vs1_` (Suikoden 1 Retrospective / Special Maps). |
| `vs1_map_02_battle_01_field.json` | Map Sub-Asset (VS) | Map background layer / 3D prop configuration for `vs1_` (Suikoden 1 Retrospective / Special Maps). |
| `vs1_map_02_battle_01_field_00.json` | Map Sub-Asset (VS) | Map background layer / 3D prop configuration for `vs1_` (Suikoden 1 Retrospective / Special Maps). |
| `vs1_map_02_battle_01_field_srn.json` | Map Sub-Asset (VS) | Map background layer / 3D prop configuration for `vs1_` (Suikoden 1 Retrospective / Special Maps). |
| `vs1_map_02_battle_01_monster_data_00.json` | Map Sub-Asset (VS) | Map background layer / 3D prop configuration for `vs1_` (Suikoden 1 Retrospective / Special Maps). |
| `vs1_map_02_battle_01_monster_data_00_00.json` | Map Sub-Asset (VS) | Map background layer / 3D prop configuration for `vs1_` (Suikoden 1 Retrospective / Special Maps). |
| `vs1_map_02_battle_01_monster_data_01.json` | Map Sub-Asset (VS) | Map background layer / 3D prop configuration for `vs1_` (Suikoden 1 Retrospective / Special Maps). |
| `vs1_map_02_battle_01_monster_data_01_00.json` | Map Sub-Asset (VS) | Map background layer / 3D prop configuration for `vs1_` (Suikoden 1 Retrospective / Special Maps). |
| `vs1_map_02_battle_01_monster_party_00.json` | Map Sub-Asset (VS) | Map background layer / 3D prop configuration for `vs1_` (Suikoden 1 Retrospective / Special Maps). |
| `vs1_map_06_02.json` | Map Sub-Asset (VS) | Map background layer / 3D prop configuration for `vs1_` (Suikoden 1 Retrospective / Special Maps). |
| `vs1_map_06_03.json` | Map Sub-Asset (VS) | Map background layer / 3D prop configuration for `vs1_` (Suikoden 1 Retrospective / Special Maps). |
| `vs1_map_06_battle_01.json` | Map Sub-Asset (VS) | Map background layer / 3D prop configuration for `vs1_` (Suikoden 1 Retrospective / Special Maps). |
| `vs2.json` | Map Data (VS) | Core map asset for `vs2` in Suikoden 1 Retrospective / Special Maps. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers. |
| `vs2_map_00_04.json` | Map Sub-Asset (VS) | Map background layer / 3D prop configuration for `vs2_` (Suikoden 1 Retrospective / Special Maps). |
| `vs2_map_00_07.json` | Map Sub-Asset (VS) | Map background layer / 3D prop configuration for `vs2_` (Suikoden 1 Retrospective / Special Maps). |

---

## <a id="battle-encounters-monster-formation-tables"></a>Battle Encounters & Monster Formation Tables

Total assets in subsystem: **193**

### <a id="dungeon-encounter-zone-tables"></a>Dungeon Encounter Zone Tables (50 files)

| File Name | Subsystem / Type | Technical Role & Grounded Description |
|---|---|---|
| `a_data.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `A`. |
| `a_data_00.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `A`. |
| `a_data_01.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `A`. |
| `a_data_02.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `A`. |
| `a_data_03.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `A`. |
| `a_data_battle_00.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `A`. |
| `a_data_battle_00_field.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `A`. |
| `a_data_battle_00_field_00.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `A`. |
| `a_data_battle_00_field_srn.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `A`. |
| `a_data_srn.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `A`. |
| `b_data.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `B`. |
| `b_data_battle_00.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `B`. |
| `b_data_battle_00_field.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `B`. |
| `b_data_battle_00_field_00.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `B`. |
| `b_data_battle_00_field_srn.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `B`. |
| `b_data_srn.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `B`. |
| `c_data.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `C`. |
| `c_data_battle_00.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `C`. |
| `c_data_battle_00_field.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `C`. |
| `c_data_battle_00_field_00.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `C`. |
| `c_data_battle_00_field_srn.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `C`. |
| `c_data_srn.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `C`. |
| `d_data.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `D`. |
| `d_data_battle_00.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `D`. |
| `d_data_srn.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `D`. |
| `e_data.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `E`. |
| `e_data_battle_00.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `E`. |
| `e_data_srn.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `E`. |
| `f_data.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `F`. |
| `f_data_battle_00.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `F`. |
| `f_data_srn.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `F`. |
| `g_data.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `G`. |
| `g_data_battle_00.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `G`. |
| `g_data_battle_00_field.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `G`. |
| `g_data_battle_00_field_srn.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `G`. |
| `g_data_srn.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `G`. |
| `h_data.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `H`. |
| `h_data_battle_00.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `H`. |
| `h_data_battle_00_field.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `H`. |
| `h_data_battle_00_field_00.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `H`. |
| `h_data_battle_00_field_srn.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `H`. |
| `h_data_srn.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `H`. |
| `j_data.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `J`. |
| `j_data_srn.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `J`. |
| `k_data.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `K`. |
| `k_data_srn.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `K`. |
| `z_data.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `Z`. |
| `z_data_battle_00.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `Z`. |
| `z_data_battle_00_field.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `Z`. |
| `z_data_srn.json` | Battle Region Encounter Table | Encounter zone table and field spawn configuration for Dungeon Group `Z`. |

### <a id="monster-party-formation-slot-definitions"></a>Monster Party Formation Slot Definitions (80 files)

| File Name | Subsystem / Type | Technical Role & Grounded Description |
|---|---|---|
| `a_data_battle_00_monster_party_00.json` | Monster Party Formation | Enemy party composition #00 for Dungeon Group `A`, specifying enemy formation layout. |
| `a_data_battle_00_monster_party_01.json` | Monster Party Formation | Enemy party composition #01 for Dungeon Group `A`, specifying enemy formation layout. |
| `a_data_battle_00_monster_party_02.json` | Monster Party Formation | Enemy party composition #02 for Dungeon Group `A`, specifying enemy formation layout. |
| `a_data_battle_00_monster_party_03.json` | Monster Party Formation | Enemy party composition #03 for Dungeon Group `A`, specifying enemy formation layout. |
| `a_data_battle_00_monster_party_04.json` | Monster Party Formation | Enemy party composition #04 for Dungeon Group `A`, specifying enemy formation layout. |
| `a_data_battle_00_monster_party_05.json` | Monster Party Formation | Enemy party composition #05 for Dungeon Group `A`, specifying enemy formation layout. |
| `a_data_battle_00_monster_party_06.json` | Monster Party Formation | Enemy party composition #06 for Dungeon Group `A`, specifying enemy formation layout. |
| `a_data_battle_00_monster_party_07.json` | Monster Party Formation | Enemy party composition #07 for Dungeon Group `A`, specifying enemy formation layout. |
| `a_data_battle_00_monster_party_08.json` | Monster Party Formation | Enemy party composition #08 for Dungeon Group `A`, specifying enemy formation layout. |
| `b_data_battle_00_monster_party_00.json` | Monster Party Formation | Enemy party composition #00 for Dungeon Group `B`, specifying enemy formation layout. |
| `b_data_battle_00_monster_party_01.json` | Monster Party Formation | Enemy party composition #01 for Dungeon Group `B`, specifying enemy formation layout. |
| `b_data_battle_00_monster_party_02.json` | Monster Party Formation | Enemy party composition #02 for Dungeon Group `B`, specifying enemy formation layout. |
| `b_data_battle_00_monster_party_03.json` | Monster Party Formation | Enemy party composition #03 for Dungeon Group `B`, specifying enemy formation layout. |
| `b_data_battle_00_monster_party_04.json` | Monster Party Formation | Enemy party composition #04 for Dungeon Group `B`, specifying enemy formation layout. |
| `b_data_battle_00_monster_party_05.json` | Monster Party Formation | Enemy party composition #05 for Dungeon Group `B`, specifying enemy formation layout. |
| `b_data_battle_00_monster_party_06.json` | Monster Party Formation | Enemy party composition #06 for Dungeon Group `B`, specifying enemy formation layout. |
| `b_data_battle_00_monster_party_07.json` | Monster Party Formation | Enemy party composition #07 for Dungeon Group `B`, specifying enemy formation layout. |
| `c_data_battle_00_monster_party_00.json` | Monster Party Formation | Enemy party composition #00 for Dungeon Group `C`, specifying enemy formation layout. |
| `c_data_battle_00_monster_party_01.json` | Monster Party Formation | Enemy party composition #01 for Dungeon Group `C`, specifying enemy formation layout. |
| `c_data_battle_00_monster_party_02.json` | Monster Party Formation | Enemy party composition #02 for Dungeon Group `C`, specifying enemy formation layout. |
| `c_data_battle_00_monster_party_03.json` | Monster Party Formation | Enemy party composition #03 for Dungeon Group `C`, specifying enemy formation layout. |
| `c_data_battle_00_monster_party_04.json` | Monster Party Formation | Enemy party composition #04 for Dungeon Group `C`, specifying enemy formation layout. |
| `c_data_battle_00_monster_party_05.json` | Monster Party Formation | Enemy party composition #05 for Dungeon Group `C`, specifying enemy formation layout. |
| `c_data_battle_00_monster_party_06.json` | Monster Party Formation | Enemy party composition #06 for Dungeon Group `C`, specifying enemy formation layout. |
| `c_data_battle_00_monster_party_07.json` | Monster Party Formation | Enemy party composition #07 for Dungeon Group `C`, specifying enemy formation layout. |
| `d_data_battle_00_monster_party_00.json` | Monster Party Formation | Enemy party composition #00 for Dungeon Group `D`, specifying enemy formation layout. |
| `d_data_battle_00_monster_party_01.json` | Monster Party Formation | Enemy party composition #01 for Dungeon Group `D`, specifying enemy formation layout. |
| `d_data_battle_00_monster_party_02.json` | Monster Party Formation | Enemy party composition #02 for Dungeon Group `D`, specifying enemy formation layout. |
| `d_data_battle_00_monster_party_03.json` | Monster Party Formation | Enemy party composition #03 for Dungeon Group `D`, specifying enemy formation layout. |
| `d_data_battle_00_monster_party_04.json` | Monster Party Formation | Enemy party composition #04 for Dungeon Group `D`, specifying enemy formation layout. |
| `d_data_battle_00_monster_party_05.json` | Monster Party Formation | Enemy party composition #05 for Dungeon Group `D`, specifying enemy formation layout. |
| `d_data_battle_00_monster_party_06.json` | Monster Party Formation | Enemy party composition #06 for Dungeon Group `D`, specifying enemy formation layout. |
| `d_data_battle_00_monster_party_07.json` | Monster Party Formation | Enemy party composition #07 for Dungeon Group `D`, specifying enemy formation layout. |
| `d_data_battle_00_monster_party_08.json` | Monster Party Formation | Enemy party composition #08 for Dungeon Group `D`, specifying enemy formation layout. |
| `d_data_battle_00_monster_party_09.json` | Monster Party Formation | Enemy party composition #09 for Dungeon Group `D`, specifying enemy formation layout. |
| `d_data_battle_00_monster_party_10.json` | Monster Party Formation | Enemy party composition #10 for Dungeon Group `D`, specifying enemy formation layout. |
| `d_data_battle_00_monster_party_11.json` | Monster Party Formation | Enemy party composition #11 for Dungeon Group `D`, specifying enemy formation layout. |
| `e_data_battle_00_monster_party_00.json` | Monster Party Formation | Enemy party composition #00 for Dungeon Group `E`, specifying enemy formation layout. |
| `e_data_battle_00_monster_party_02.json` | Monster Party Formation | Enemy party composition #02 for Dungeon Group `E`, specifying enemy formation layout. |
| `e_data_battle_00_monster_party_03.json` | Monster Party Formation | Enemy party composition #03 for Dungeon Group `E`, specifying enemy formation layout. |
| `e_data_battle_00_monster_party_05.json` | Monster Party Formation | Enemy party composition #05 for Dungeon Group `E`, specifying enemy formation layout. |
| `e_data_battle_00_monster_party_06.json` | Monster Party Formation | Enemy party composition #06 for Dungeon Group `E`, specifying enemy formation layout. |
| `e_data_battle_00_monster_party_07.json` | Monster Party Formation | Enemy party composition #07 for Dungeon Group `E`, specifying enemy formation layout. |
| `e_data_battle_00_monster_party_08.json` | Monster Party Formation | Enemy party composition #08 for Dungeon Group `E`, specifying enemy formation layout. |
| `e_data_battle_00_monster_party_09.json` | Monster Party Formation | Enemy party composition #09 for Dungeon Group `E`, specifying enemy formation layout. |
| `e_data_battle_00_monster_party_10.json` | Monster Party Formation | Enemy party composition #10 for Dungeon Group `E`, specifying enemy formation layout. |
| `f_data_battle_00_monster_party_00.json` | Monster Party Formation | Enemy party composition #00 for Dungeon Group `F`, specifying enemy formation layout. |
| `f_data_battle_00_monster_party_01.json` | Monster Party Formation | Enemy party composition #01 for Dungeon Group `F`, specifying enemy formation layout. |
| `f_data_battle_00_monster_party_02.json` | Monster Party Formation | Enemy party composition #02 for Dungeon Group `F`, specifying enemy formation layout. |
| `f_data_battle_00_monster_party_03.json` | Monster Party Formation | Enemy party composition #03 for Dungeon Group `F`, specifying enemy formation layout. |
| `f_data_battle_00_monster_party_04.json` | Monster Party Formation | Enemy party composition #04 for Dungeon Group `F`, specifying enemy formation layout. |
| `f_data_battle_00_monster_party_05.json` | Monster Party Formation | Enemy party composition #05 for Dungeon Group `F`, specifying enemy formation layout. |
| `f_data_battle_00_monster_party_06.json` | Monster Party Formation | Enemy party composition #06 for Dungeon Group `F`, specifying enemy formation layout. |
| `f_data_battle_00_monster_party_07.json` | Monster Party Formation | Enemy party composition #07 for Dungeon Group `F`, specifying enemy formation layout. |
| `g_data_battle_00_monster_party_00.json` | Monster Party Formation | Enemy party composition #00 for Dungeon Group `G`, specifying enemy formation layout. |
| `g_data_battle_00_monster_party_01.json` | Monster Party Formation | Enemy party composition #01 for Dungeon Group `G`, specifying enemy formation layout. |
| `g_data_battle_00_monster_party_02.json` | Monster Party Formation | Enemy party composition #02 for Dungeon Group `G`, specifying enemy formation layout. |
| `g_data_battle_00_monster_party_03.json` | Monster Party Formation | Enemy party composition #03 for Dungeon Group `G`, specifying enemy formation layout. |
| `g_data_battle_00_monster_party_04.json` | Monster Party Formation | Enemy party composition #04 for Dungeon Group `G`, specifying enemy formation layout. |
| `g_data_battle_00_monster_party_05.json` | Monster Party Formation | Enemy party composition #05 for Dungeon Group `G`, specifying enemy formation layout. |
| `g_data_battle_00_monster_party_06.json` | Monster Party Formation | Enemy party composition #06 for Dungeon Group `G`, specifying enemy formation layout. |
| `g_data_battle_00_monster_party_07.json` | Monster Party Formation | Enemy party composition #07 for Dungeon Group `G`, specifying enemy formation layout. |
| `g_data_battle_00_monster_party_08.json` | Monster Party Formation | Enemy party composition #08 for Dungeon Group `G`, specifying enemy formation layout. |
| `h_data_battle_00_monster_party_01.json` | Monster Party Formation | Enemy party composition #01 for Dungeon Group `H`, specifying enemy formation layout. |
| `h_data_battle_00_monster_party_05.json` | Monster Party Formation | Enemy party composition #05 for Dungeon Group `H`, specifying enemy formation layout. |
| `h_data_battle_00_monster_party_10.json` | Monster Party Formation | Enemy party composition #10 for Dungeon Group `H`, specifying enemy formation layout. |
| `h_data_battle_00_monster_party_11.json` | Monster Party Formation | Enemy party composition #11 for Dungeon Group `H`, specifying enemy formation layout. |
| `z_data_battle_00_monster_party_00.json` | Monster Party Formation | Enemy party composition #00 for Dungeon Group `Z`, specifying enemy formation layout. |
| `z_data_battle_00_monster_party_01.json` | Monster Party Formation | Enemy party composition #01 for Dungeon Group `Z`, specifying enemy formation layout. |
| `z_data_battle_00_monster_party_02.json` | Monster Party Formation | Enemy party composition #02 for Dungeon Group `Z`, specifying enemy formation layout. |
| `z_data_battle_00_monster_party_03.json` | Monster Party Formation | Enemy party composition #03 for Dungeon Group `Z`, specifying enemy formation layout. |
| `z_data_battle_00_monster_party_04.json` | Monster Party Formation | Enemy party composition #04 for Dungeon Group `Z`, specifying enemy formation layout. |
| `z_data_battle_00_monster_party_05.json` | Monster Party Formation | Enemy party composition #05 for Dungeon Group `Z`, specifying enemy formation layout. |
| `z_data_battle_00_monster_party_06.json` | Monster Party Formation | Enemy party composition #06 for Dungeon Group `Z`, specifying enemy formation layout. |
| `z_data_battle_00_monster_party_07.json` | Monster Party Formation | Enemy party composition #07 for Dungeon Group `Z`, specifying enemy formation layout. |
| `z_data_battle_00_monster_party_08.json` | Monster Party Formation | Enemy party composition #08 for Dungeon Group `Z`, specifying enemy formation layout. |
| `z_data_battle_00_monster_party_09.json` | Monster Party Formation | Enemy party composition #09 for Dungeon Group `Z`, specifying enemy formation layout. |
| `z_data_battle_00_monster_party_10.json` | Monster Party Formation | Enemy party composition #10 for Dungeon Group `Z`, specifying enemy formation layout. |
| `z_data_battle_00_monster_party_11.json` | Monster Party Formation | Enemy party composition #11 for Dungeon Group `Z`, specifying enemy formation layout. |
| `z_data_battle_00_monster_party_12.json` | Monster Party Formation | Enemy party composition #12 for Dungeon Group `Z`, specifying enemy formation layout. |

### <a id="monster-stats-unit-parameters"></a>Monster Stats & Unit Parameters (63 files)

| File Name | Subsystem / Type | Technical Role & Grounded Description |
|---|---|---|
| `a_data_battle_00_monster_data_00.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `A`, defining stats, attack damage, and rewards. |
| `a_data_battle_00_monster_data_00_00.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `A`, defining stats, attack damage, and rewards. |
| `a_data_battle_00_monster_data_01.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `A`, defining stats, attack damage, and rewards. |
| `a_data_battle_00_monster_data_01_00.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `A`, defining stats, attack damage, and rewards. |
| `a_data_battle_00_monster_data_02.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `A`, defining stats, attack damage, and rewards. |
| `a_data_battle_00_monster_data_02_00.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `A`, defining stats, attack damage, and rewards. |
| `a_data_battle_00_monster_data_03.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `A`, defining stats, attack damage, and rewards. |
| `a_data_battle_00_monster_data_03_00.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `A`, defining stats, attack damage, and rewards. |
| `a_data_battle_00_monster_data_04.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `A`, defining stats, attack damage, and rewards. |
| `a_data_battle_00_monster_data_04_00.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `A`, defining stats, attack damage, and rewards. |
| `b_data_battle_00_monster_data_00.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `B`, defining stats, attack damage, and rewards. |
| `b_data_battle_00_monster_data_00_00.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `B`, defining stats, attack damage, and rewards. |
| `b_data_battle_00_monster_data_01.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `B`, defining stats, attack damage, and rewards. |
| `b_data_battle_00_monster_data_01_00.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `B`, defining stats, attack damage, and rewards. |
| `b_data_battle_00_monster_data_02.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `B`, defining stats, attack damage, and rewards. |
| `b_data_battle_00_monster_data_02_00.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `B`, defining stats, attack damage, and rewards. |
| `b_data_battle_00_monster_data_03.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `B`, defining stats, attack damage, and rewards. |
| `b_data_battle_00_monster_data_03_00.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `B`, defining stats, attack damage, and rewards. |
| `c_data_battle_00_monster_data_00.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `C`, defining stats, attack damage, and rewards. |
| `c_data_battle_00_monster_data_00_00.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `C`, defining stats, attack damage, and rewards. |
| `c_data_battle_00_monster_data_01.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `C`, defining stats, attack damage, and rewards. |
| `c_data_battle_00_monster_data_01_00.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `C`, defining stats, attack damage, and rewards. |
| `c_data_battle_00_monster_data_02.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `C`, defining stats, attack damage, and rewards. |
| `c_data_battle_00_monster_data_02_00.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `C`, defining stats, attack damage, and rewards. |
| `c_data_battle_00_monster_data_03.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `C`, defining stats, attack damage, and rewards. |
| `c_data_battle_00_monster_data_03_00.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `C`, defining stats, attack damage, and rewards. |
| `d_data_battle_00_monster_data_00.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `D`, defining stats, attack damage, and rewards. |
| `d_data_battle_00_monster_data_00_00.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `D`, defining stats, attack damage, and rewards. |
| `d_data_battle_00_monster_data_01.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `D`, defining stats, attack damage, and rewards. |
| `d_data_battle_00_monster_data_01_00.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `D`, defining stats, attack damage, and rewards. |
| `d_data_battle_00_monster_data_02.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `D`, defining stats, attack damage, and rewards. |
| `d_data_battle_00_monster_data_02_00.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `D`, defining stats, attack damage, and rewards. |
| `e_data_battle_00_monster_data_00.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `E`, defining stats, attack damage, and rewards. |
| `e_data_battle_00_monster_data_00_00.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `E`, defining stats, attack damage, and rewards. |
| `e_data_battle_00_monster_data_01.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `E`, defining stats, attack damage, and rewards. |
| `e_data_battle_00_monster_data_01_00.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `E`, defining stats, attack damage, and rewards. |
| `e_data_battle_00_monster_data_02.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `E`, defining stats, attack damage, and rewards. |
| `e_data_battle_00_monster_data_02_00.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `E`, defining stats, attack damage, and rewards. |
| `e_data_battle_00_monster_data_03.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `E`, defining stats, attack damage, and rewards. |
| `e_data_battle_00_monster_data_03_00.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `E`, defining stats, attack damage, and rewards. |
| `f_data_battle_00_monster_data_00.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `F`, defining stats, attack damage, and rewards. |
| `f_data_battle_00_monster_data_00_00.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `F`, defining stats, attack damage, and rewards. |
| `f_data_battle_00_monster_data_01.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `F`, defining stats, attack damage, and rewards. |
| `f_data_battle_00_monster_data_01_00.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `F`, defining stats, attack damage, and rewards. |
| `f_data_battle_00_monster_data_02.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `F`, defining stats, attack damage, and rewards. |
| `f_data_battle_00_monster_data_02_00.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `F`, defining stats, attack damage, and rewards. |
| `g_data_battle_00_monster_data_00.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `G`, defining stats, attack damage, and rewards. |
| `g_data_battle_00_monster_data_00_00.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `G`, defining stats, attack damage, and rewards. |
| `g_data_battle_00_monster_data_01.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `G`, defining stats, attack damage, and rewards. |
| `g_data_battle_00_monster_data_01_00.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `G`, defining stats, attack damage, and rewards. |
| `g_data_battle_00_monster_data_02.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `G`, defining stats, attack damage, and rewards. |
| `g_data_battle_00_monster_data_02_00.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `G`, defining stats, attack damage, and rewards. |
| `h_data_battle_00_monster_data_00.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `H`, defining stats, attack damage, and rewards. |
| `h_data_battle_00_monster_data_00_00.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `H`, defining stats, attack damage, and rewards. |
| `h_data_battle_00_monster_data_01.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `H`, defining stats, attack damage, and rewards. |
| `h_data_battle_00_monster_data_02.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `H`, defining stats, attack damage, and rewards. |
| `h_data_battle_00_monster_data_02_00.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `H`, defining stats, attack damage, and rewards. |
| `z_data_battle_00_monster_data_00.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `Z`, defining stats, attack damage, and rewards. |
| `z_data_battle_00_monster_data_00_00.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `Z`, defining stats, attack damage, and rewards. |
| `z_data_battle_00_monster_data_01.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `Z`, defining stats, attack damage, and rewards. |
| `z_data_battle_00_monster_data_01_00.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `Z`, defining stats, attack damage, and rewards. |
| `z_data_battle_00_monster_data_02.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `Z`, defining stats, attack damage, and rewards. |
| `z_data_battle_00_monster_data_02_00.json` | Monster Stats & AI | Monster unit parameters for Dungeon Group `Z`, defining stats, attack damage, and rewards. |

---

## <a id="boss-encounters-combat-arenas"></a>Boss Encounters & Combat Arenas

Total assets in subsystem: **133**

### <a id="boss-ai-combat-parameter-packages-boss_"></a>Boss AI & Combat Parameter Packages (`boss_*`) (86 files)

| File Name | Subsystem / Type | Technical Role & Grounded Description |
|---|---|---|
| `boss_dor.json` | Boss Encounter Data | Boss entity configuration for `Dorothy` (boss_dor), setting stats, AI script, actions, and loot drops. |
| `boss_dor_00.json` | Boss Encounter Data | Boss entity configuration for `Dorothy` (boss_dor_00), setting stats, AI script, actions, and loot drops. |
| `boss_gol.json` | Boss Encounter Data | Boss entity configuration for `Goran` (boss_gol), setting stats, AI script, actions, and loot drops. |
| `boss_gol_00.json` | Boss Encounter Data | Boss entity configuration for `Goran` (boss_gol_00), setting stats, AI script, actions, and loot drops. |
| `boss_gor.json` | Boss Encounter Data | Boss entity configuration for `Gor` (boss_gor), setting stats, AI script, actions, and loot drops. |
| `boss_gor_00.json` | Boss Encounter Data | Boss entity configuration for `Gor` (boss_gor_00), setting stats, AI script, actions, and loot drops. |
| `boss_gor_01.json` | Boss Encounter Data | Boss entity configuration for `Gor` (boss_gor_01), setting stats, AI script, actions, and loot drops. |
| `boss_gwo1.json` | Boss Encounter Data | Boss entity configuration for `Gwo1` (boss_gwo1), setting stats, AI script, actions, and loot drops. |
| `boss_gwo1_00.json` | Boss Encounter Data | Boss entity configuration for `Gwo1` (boss_gwo1_00), setting stats, AI script, actions, and loot drops. |
| `boss_gwo2.json` | Boss Encounter Data | Boss entity configuration for `Gwo2` (boss_gwo2), setting stats, AI script, actions, and loot drops. |
| `boss_gwo2_00.json` | Boss Encounter Data | Boss entity configuration for `Gwo2` (boss_gwo2_00), setting stats, AI script, actions, and loot drops. |
| `boss_hap1.json` | Boss Encounter Data | Boss entity configuration for `Hap1` (boss_hap1), setting stats, AI script, actions, and loot drops. |
| `boss_hap1_00.json` | Boss Encounter Data | Boss entity configuration for `Hap1` (boss_hap1_00), setting stats, AI script, actions, and loot drops. |
| `boss_hap2.json` | Boss Encounter Data | Boss entity configuration for `Hap2` (boss_hap2), setting stats, AI script, actions, and loot drops. |
| `boss_hap2_00.json` | Boss Encounter Data | Boss entity configuration for `Hap2` (boss_hap2_00), setting stats, AI script, actions, and loot drops. |
| `boss_imo1.json` | Boss Encounter Data | Boss entity configuration for `Imo1` (boss_imo1), setting stats, AI script, actions, and loot drops. |
| `boss_imo1_00.json` | Boss Encounter Data | Boss entity configuration for `Imo1` (boss_imo1_00), setting stats, AI script, actions, and loot drops. |
| `boss_imo2.json` | Boss Encounter Data | Boss entity configuration for `Imo2` (boss_imo2), setting stats, AI script, actions, and loot drops. |
| `boss_imo2_00.json` | Boss Encounter Data | Boss entity configuration for `Imo2` (boss_imo2_00), setting stats, AI script, actions, and loot drops. |
| `boss_imo2_01.json` | Boss Encounter Data | Boss entity configuration for `Imo2` (boss_imo2_01), setting stats, AI script, actions, and loot drops. |
| `boss_imo3.json` | Boss Encounter Data | Boss entity configuration for `Imo3` (boss_imo3), setting stats, AI script, actions, and loot drops. |
| `boss_imo3_00.json` | Boss Encounter Data | Boss entity configuration for `Imo3` (boss_imo3_00), setting stats, AI script, actions, and loot drops. |
| `boss_ki1.json` | Boss Encounter Data | Boss entity configuration for `Ki1` (boss_ki1), setting stats, AI script, actions, and loot drops. |
| `boss_ki1_00.json` | Boss Encounter Data | Boss entity configuration for `Ki1` (boss_ki1_00), setting stats, AI script, actions, and loot drops. |
| `boss_ki1_01.json` | Boss Encounter Data | Boss entity configuration for `Ki1` (boss_ki1_01), setting stats, AI script, actions, and loot drops. |
| `boss_kul_sid.json` | Boss Encounter Data | Boss entity configuration for `Kul` (boss_kul_sid), setting stats, AI script, actions, and loot drops. |
| `boss_kul_sid_00.json` | Boss Encounter Data | Boss entity configuration for `Kul` (boss_kul_sid_00), setting stats, AI script, actions, and loot drops. |
| `boss_kul_sid_01.json` | Boss Encounter Data | Boss entity configuration for `Kul` (boss_kul_sid_01), setting stats, AI script, actions, and loot drops. |
| `boss_las.json` | Boss Encounter Data | Boss entity configuration for `Las` (boss_las), setting stats, AI script, actions, and loot drops. |
| `boss_las_00.json` | Boss Encounter Data | Boss entity configuration for `Las` (boss_las_00), setting stats, AI script, actions, and loot drops. |
| `boss_las_01.json` | Boss Encounter Data | Boss entity configuration for `Las` (boss_las_01), setting stats, AI script, actions, and loot drops. |
| `boss_las_02.json` | Boss Encounter Data | Boss entity configuration for `Las` (boss_las_02), setting stats, AI script, actions, and loot drops. |
| `boss_las_03.json` | Boss Encounter Data | Boss entity configuration for `Las` (boss_las_03), setting stats, AI script, actions, and loot drops. |
| `boss_las_04.json` | Boss Encounter Data | Boss entity configuration for `Las` (boss_las_04), setting stats, AI script, actions, and loot drops. |
| `boss_las_05.json` | Boss Encounter Data | Boss entity configuration for `Las` (boss_las_05), setting stats, AI script, actions, and loot drops. |
| `boss_luc1.json` | Boss Encounter Data | Boss entity configuration for `Luc1` (boss_luc1), setting stats, AI script, actions, and loot drops. |
| `boss_luc1_00.json` | Boss Encounter Data | Boss entity configuration for `Luc1` (boss_luc1_00), setting stats, AI script, actions, and loot drops. |
| `boss_luc1_01.json` | Boss Encounter Data | Boss entity configuration for `Luc1` (boss_luc1_01), setting stats, AI script, actions, and loot drops. |
| `boss_luc1_02.json` | Boss Encounter Data | Boss entity configuration for `Luc1` (boss_luc1_02), setting stats, AI script, actions, and loot drops. |
| `boss_luc2.json` | Boss Encounter Data | Boss entity configuration for `Luc2` (boss_luc2), setting stats, AI script, actions, and loot drops. |
| `boss_luc2_00.json` | Boss Encounter Data | Boss entity configuration for `Luc2` (boss_luc2_00), setting stats, AI script, actions, and loot drops. |
| `boss_luc2_01.json` | Boss Encounter Data | Boss entity configuration for `Luc2` (boss_luc2_01), setting stats, AI script, actions, and loot drops. |
| `boss_luc2_02.json` | Boss Encounter Data | Boss entity configuration for `Luc2` (boss_luc2_02), setting stats, AI script, actions, and loot drops. |
| `boss_luc3.json` | Boss Encounter Data | Boss entity configuration for `Luc3` (boss_luc3), setting stats, AI script, actions, and loot drops. |
| `boss_luc3_00.json` | Boss Encounter Data | Boss entity configuration for `Luc3` (boss_luc3_00), setting stats, AI script, actions, and loot drops. |
| `boss_lus1.json` | Boss Encounter Data | Boss entity configuration for `Lus1` (boss_lus1), setting stats, AI script, actions, and loot drops. |
| `boss_lus1_00.json` | Boss Encounter Data | Boss entity configuration for `Lus1` (boss_lus1_00), setting stats, AI script, actions, and loot drops. |
| `boss_lus1_01.json` | Boss Encounter Data | Boss entity configuration for `Lus1` (boss_lus1_01), setting stats, AI script, actions, and loot drops. |
| `boss_lus1_02.json` | Boss Encounter Data | Boss entity configuration for `Lus1` (boss_lus1_02), setting stats, AI script, actions, and loot drops. |
| `boss_lus1_03.json` | Boss Encounter Data | Boss entity configuration for `Lus1` (boss_lus1_03), setting stats, AI script, actions, and loot drops. |
| `boss_lus2.json` | Boss Encounter Data | Boss entity configuration for `Lus2` (boss_lus2), setting stats, AI script, actions, and loot drops. |
| `boss_lus2_00.json` | Boss Encounter Data | Boss entity configuration for `Lus2` (boss_lus2_00), setting stats, AI script, actions, and loot drops. |
| `boss_lus3.json` | Boss Encounter Data | Boss entity configuration for `Lus3` (boss_lus3), setting stats, AI script, actions, and loot drops. |
| `boss_lus3_00.json` | Boss Encounter Data | Boss entity configuration for `Lus3` (boss_lus3_00), setting stats, AI script, actions, and loot drops. |
| `boss_lus4.json` | Boss Encounter Data | Boss entity configuration for `Lus4` (boss_lus4), setting stats, AI script, actions, and loot drops. |
| `boss_lus4_00.json` | Boss Encounter Data | Boss entity configuration for `Lus4` (boss_lus4_00), setting stats, AI script, actions, and loot drops. |
| `boss_lus5.json` | Boss Encounter Data | Boss entity configuration for `Lus5` (boss_lus5), setting stats, AI script, actions, and loot drops. |
| `boss_lus5_00.json` | Boss Encounter Data | Boss entity configuration for `Lus5` (boss_lus5_00), setting stats, AI script, actions, and loot drops. |
| `boss_nec1.json` | Boss Encounter Data | Boss entity configuration for `Nec1` (boss_nec1), setting stats, AI script, actions, and loot drops. |
| `boss_nec1_00.json` | Boss Encounter Data | Boss entity configuration for `Nec1` (boss_nec1_00), setting stats, AI script, actions, and loot drops. |
| `boss_nec1_01.json` | Boss Encounter Data | Boss entity configuration for `Nec1` (boss_nec1_01), setting stats, AI script, actions, and loot drops. |
| `boss_nec1_02.json` | Boss Encounter Data | Boss entity configuration for `Nec1` (boss_nec1_02), setting stats, AI script, actions, and loot drops. |
| `boss_nec2.json` | Boss Encounter Data | Boss entity configuration for `Nec2` (boss_nec2), setting stats, AI script, actions, and loot drops. |
| `boss_nec2_00.json` | Boss Encounter Data | Boss entity configuration for `Nec2` (boss_nec2_00), setting stats, AI script, actions, and loot drops. |
| `boss_nec3.json` | Boss Encounter Data | Boss entity configuration for `Nec3` (boss_nec3), setting stats, AI script, actions, and loot drops. |
| `boss_nec3_00.json` | Boss Encounter Data | Boss entity configuration for `Nec3` (boss_nec3_00), setting stats, AI script, actions, and loot drops. |
| `boss_nik.json` | Boss Encounter Data | Boss entity configuration for `Nik` (boss_nik), setting stats, AI script, actions, and loot drops. |
| `boss_nik_00.json` | Boss Encounter Data | Boss entity configuration for `Nik` (boss_nik_00), setting stats, AI script, actions, and loot drops. |
| `boss_rat.json` | Boss Encounter Data | Boss entity configuration for `Rat` (boss_rat), setting stats, AI script, actions, and loot drops. |
| `boss_rat_00.json` | Boss Encounter Data | Boss entity configuration for `Rat` (boss_rat_00), setting stats, AI script, actions, and loot drops. |
| `boss_rau1.json` | Boss Encounter Data | Boss entity configuration for `Rau1` (boss_rau1), setting stats, AI script, actions, and loot drops. |
| `boss_rau1_00.json` | Boss Encounter Data | Boss entity configuration for `Rau1` (boss_rau1_00), setting stats, AI script, actions, and loot drops. |
| `boss_rau1_01.json` | Boss Encounter Data | Boss entity configuration for `Rau1` (boss_rau1_01), setting stats, AI script, actions, and loot drops. |
| `boss_rau1_02.json` | Boss Encounter Data | Boss entity configuration for `Rau1` (boss_rau1_02), setting stats, AI script, actions, and loot drops. |
| `boss_rau1_03.json` | Boss Encounter Data | Boss entity configuration for `Rau1` (boss_rau1_03), setting stats, AI script, actions, and loot drops. |
| `boss_rau2.json` | Boss Encounter Data | Boss entity configuration for `Rau2` (boss_rau2), setting stats, AI script, actions, and loot drops. |
| `boss_rau2_00.json` | Boss Encounter Data | Boss entity configuration for `Rau2` (boss_rau2_00), setting stats, AI script, actions, and loot drops. |
| `boss_rau2_01.json` | Boss Encounter Data | Boss entity configuration for `Rau2` (boss_rau2_01), setting stats, AI script, actions, and loot drops. |
| `boss_rau2_02.json` | Boss Encounter Data | Boss entity configuration for `Rau2` (boss_rau2_02), setting stats, AI script, actions, and loot drops. |
| `boss_rau2_03.json` | Boss Encounter Data | Boss entity configuration for `Rau2` (boss_rau2_03), setting stats, AI script, actions, and loot drops. |
| `boss_ryo.json` | Boss Encounter Data | Boss entity configuration for `Riou (Hero)` (boss_ryo), setting stats, AI script, actions, and loot drops. |
| `boss_ryo_00.json` | Boss Encounter Data | Boss entity configuration for `Riou (Hero)` (boss_ryo_00), setting stats, AI script, actions, and loot drops. |
| `boss_sei.json` | Boss Encounter Data | Boss entity configuration for `Sei` (boss_sei), setting stats, AI script, actions, and loot drops. |
| `boss_sei_00.json` | Boss Encounter Data | Boss entity configuration for `Sei` (boss_sei_00), setting stats, AI script, actions, and loot drops. |
| `boss_sie1.json` | Boss Encounter Data | Boss entity configuration for `Sie1` (boss_sie1), setting stats, AI script, actions, and loot drops. |
| `boss_sie1_00.json` | Boss Encounter Data | Boss entity configuration for `Sie1` (boss_sie1_00), setting stats, AI script, actions, and loot drops. |

### <a id="boss-arena-3d-models-props-boss__obj"></a>Boss Arena 3D Models & Props (`boss_*_obj`) (14 files)

| File Name | Subsystem / Type | Technical Role & Grounded Description |
|---|---|---|
| `boss_dor_obj.json` | Boss Battle Object | Boss arena 3D model/prop asset for `Dorothy`. |
| `boss_gor_obj.json` | Boss Battle Object | Boss arena 3D model/prop asset for `Gor`. |
| `boss_gwo1_obj.json` | Boss Battle Object | Boss arena 3D model/prop asset for `Gwo1`. |
| `boss_imo1_obj.json` | Boss Battle Object | Boss arena 3D model/prop asset for `Imo1`. |
| `boss_kul_sid_obj.json` | Boss Battle Object | Boss arena 3D model/prop asset for `Kul`. |
| `boss_las_obj.json` | Boss Battle Object | Boss arena 3D model/prop asset for `Las`. |
| `boss_lus3_obj.json` | Boss Battle Object | Boss arena 3D model/prop asset for `Lus3`. |
| `boss_lus4_obj.json` | Boss Battle Object | Boss arena 3D model/prop asset for `Lus4`. |
| `boss_lus5_obj.json` | Boss Battle Object | Boss arena 3D model/prop asset for `Lus5`. |
| `boss_nec1_obj.json` | Boss Battle Object | Boss arena 3D model/prop asset for `Nec1`. |
| `boss_nec3_obj.json` | Boss Battle Object | Boss arena 3D model/prop asset for `Nec3`. |
| `boss_nik_obj.json` | Boss Battle Object | Boss arena 3D model/prop asset for `Nik`. |
| `boss_rat_obj.json` | Boss Battle Object | Boss arena 3D model/prop asset for `Rat`. |
| `boss_ryo_obj.json` | Boss Battle Object | Boss arena 3D model/prop asset for `Riou (Hero)`. |

### <a id="boss-vfx-cinematic-resources-boss__res"></a>Boss VFX & Cinematic Resources (`boss_*_res`) (33 files)

| File Name | Subsystem / Type | Technical Role & Grounded Description |
|---|---|---|
| `boss_res_dor_00.json` | Boss VFX / Resource | Boss combat visual effect / resource asset for `Res` encounter. |
| `boss_res_dor_01.json` | Boss VFX / Resource | Boss combat visual effect / resource asset for `Res` encounter. |
| `boss_res_gol_00.json` | Boss VFX / Resource | Boss combat visual effect / resource asset for `Res` encounter. |
| `boss_res_gol_01.json` | Boss VFX / Resource | Boss combat visual effect / resource asset for `Res` encounter. |
| `boss_res_hap_02.json` | Boss VFX / Resource | Boss combat visual effect / resource asset for `Res` encounter. |
| `boss_res_imo1_00.json` | Boss VFX / Resource | Boss combat visual effect / resource asset for `Res` encounter. |
| `boss_res_imo1_01.json` | Boss VFX / Resource | Boss combat visual effect / resource asset for `Res` encounter. |
| `boss_res_imo1_03.json` | Boss VFX / Resource | Boss combat visual effect / resource asset for `Res` encounter. |
| `boss_res_imo2_00.json` | Boss VFX / Resource | Boss combat visual effect / resource asset for `Res` encounter. |
| `boss_res_imo2_04.json` | Boss VFX / Resource | Boss combat visual effect / resource asset for `Res` encounter. |
| `boss_res_ki1_00.json` | Boss VFX / Resource | Boss combat visual effect / resource asset for `Res` encounter. |
| `boss_res_ki1_01.json` | Boss VFX / Resource | Boss combat visual effect / resource asset for `Res` encounter. |
| `boss_res_ki1_02.json` | Boss VFX / Resource | Boss combat visual effect / resource asset for `Res` encounter. |
| `boss_res_ki1_03.json` | Boss VFX / Resource | Boss combat visual effect / resource asset for `Res` encounter. |
| `boss_res_ki1_04.json` | Boss VFX / Resource | Boss combat visual effect / resource asset for `Res` encounter. |
| `boss_res_ki1_05.json` | Boss VFX / Resource | Boss combat visual effect / resource asset for `Res` encounter. |
| `boss_res_kul_sid_00.json` | Boss VFX / Resource | Boss combat visual effect / resource asset for `Res` encounter. |
| `boss_res_las_01.json` | Boss VFX / Resource | Boss combat visual effect / resource asset for `Res` encounter. |
| `boss_res_las_02.json` | Boss VFX / Resource | Boss combat visual effect / resource asset for `Res` encounter. |
| `boss_res_las_03.json` | Boss VFX / Resource | Boss combat visual effect / resource asset for `Res` encounter. |
| `boss_res_las_04.json` | Boss VFX / Resource | Boss combat visual effect / resource asset for `Res` encounter. |
| `boss_res_luc_00.json` | Boss VFX / Resource | Boss combat visual effect / resource asset for `Res` encounter. |
| `boss_res_luc_01.json` | Boss VFX / Resource | Boss combat visual effect / resource asset for `Res` encounter. |
| `boss_res_nec3_00.json` | Boss VFX / Resource | Boss combat visual effect / resource asset for `Res` encounter. |
| `boss_res_nec3_01.json` | Boss VFX / Resource | Boss combat visual effect / resource asset for `Res` encounter. |
| `boss_res_nec3_02.json` | Boss VFX / Resource | Boss combat visual effect / resource asset for `Res` encounter. |
| `boss_res_nik_00.json` | Boss VFX / Resource | Boss combat visual effect / resource asset for `Res` encounter. |
| `boss_res_nik_02.json` | Boss VFX / Resource | Boss combat visual effect / resource asset for `Res` encounter. |
| `boss_res_ryo_00.json` | Boss VFX / Resource | Boss combat visual effect / resource asset for `Res` encounter. |
| `boss_res_ryo_02.json` | Boss VFX / Resource | Boss combat visual effect / resource asset for `Res` encounter. |
| `boss_res_ryo_03.json` | Boss VFX / Resource | Boss combat visual effect / resource asset for `Res` encounter. |
| `boss_res_sei_00.json` | Boss VFX / Resource | Boss combat visual effect / resource asset for `Res` encounter. |
| `boss_res_sei_01.json` | Boss VFX / Resource | Boss combat visual effect / resource asset for `Res` encounter. |

---

## <a id="scripted-story-event-battles"></a>Scripted Story Event Battles

Total assets in subsystem: **119**

### <a id="scripted-event-battle-scenarios-eb_"></a>Scripted Event Battle Scenarios (`eb_*`) (119 files)

| File Name | Subsystem / Type | Technical Role & Grounded Description |
|---|---|---|
| `eb_va05.json` | Story Event Battle Data | Scripted event battle occurring in map `va05`, coordinating story dialogue triggers and combat conditions. |
| `eb_va05_00.json` | Story Event Battle Data | Scripted event battle occurring in map `va05`, coordinating story dialogue triggers and combat conditions. |
| `eb_va05_01.json` | Story Event Battle Data | Scripted event battle occurring in map `va05`, coordinating story dialogue triggers and combat conditions. |
| `eb_va05_02.json` | Story Event Battle Data | Scripted event battle occurring in map `va05`, coordinating story dialogue triggers and combat conditions. |
| `eb_va05_obj.json` | Story Event Battle Data | Scripted event battle occurring in map `va05`, coordinating story dialogue triggers and combat conditions. |
| `eb_vb02.json` | Story Event Battle Data | Scripted event battle occurring in map `vb02`, coordinating story dialogue triggers and combat conditions. |
| `eb_vb02_00.json` | Story Event Battle Data | Scripted event battle occurring in map `vb02`, coordinating story dialogue triggers and combat conditions. |
| `eb_vb02_01.json` | Story Event Battle Data | Scripted event battle occurring in map `vb02`, coordinating story dialogue triggers and combat conditions. |
| `eb_vb02_02.json` | Story Event Battle Data | Scripted event battle occurring in map `vb02`, coordinating story dialogue triggers and combat conditions. |
| `eb_vb02_03.json` | Story Event Battle Data | Scripted event battle occurring in map `vb02`, coordinating story dialogue triggers and combat conditions. |
| `eb_vb02b.json` | Story Event Battle Data | Scripted event battle occurring in map `vb02`, coordinating story dialogue triggers and combat conditions. |
| `eb_vb02b_00.json` | Story Event Battle Data | Scripted event battle occurring in map `vb02`, coordinating story dialogue triggers and combat conditions. |
| `eb_vb02b_01.json` | Story Event Battle Data | Scripted event battle occurring in map `vb02`, coordinating story dialogue triggers and combat conditions. |
| `eb_vb02b_02.json` | Story Event Battle Data | Scripted event battle occurring in map `vb02`, coordinating story dialogue triggers and combat conditions. |
| `eb_vb02b_03.json` | Story Event Battle Data | Scripted event battle occurring in map `vb02`, coordinating story dialogue triggers and combat conditions. |
| `eb_vb02b_obj.json` | Story Event Battle Data | Scripted event battle occurring in map `vb02`, coordinating story dialogue triggers and combat conditions. |
| `eb_vb02c.json` | Story Event Battle Data | Scripted event battle occurring in map `vb02`, coordinating story dialogue triggers and combat conditions. |
| `eb_vb02c_00.json` | Story Event Battle Data | Scripted event battle occurring in map `vb02`, coordinating story dialogue triggers and combat conditions. |
| `eb_vb02c_01.json` | Story Event Battle Data | Scripted event battle occurring in map `vb02`, coordinating story dialogue triggers and combat conditions. |
| `eb_vb02c_02.json` | Story Event Battle Data | Scripted event battle occurring in map `vb02`, coordinating story dialogue triggers and combat conditions. |
| `eb_vb02c_03.json` | Story Event Battle Data | Scripted event battle occurring in map `vb02`, coordinating story dialogue triggers and combat conditions. |
| `eb_vb07.json` | Story Event Battle Data | Scripted event battle occurring in map `vb07`, coordinating story dialogue triggers and combat conditions. |
| `eb_vb07_00.json` | Story Event Battle Data | Scripted event battle occurring in map `vb07`, coordinating story dialogue triggers and combat conditions. |
| `eb_vb19.json` | Story Event Battle Data | Scripted event battle occurring in map `vb19`, coordinating story dialogue triggers and combat conditions. |
| `eb_vb19_00.json` | Story Event Battle Data | Scripted event battle occurring in map `vb19`, coordinating story dialogue triggers and combat conditions. |
| `eb_vb19_01.json` | Story Event Battle Data | Scripted event battle occurring in map `vb19`, coordinating story dialogue triggers and combat conditions. |
| `eb_vb19_02.json` | Story Event Battle Data | Scripted event battle occurring in map `vb19`, coordinating story dialogue triggers and combat conditions. |
| `eb_vb19_03.json` | Story Event Battle Data | Scripted event battle occurring in map `vb19`, coordinating story dialogue triggers and combat conditions. |
| `eb_vc07.json` | Story Event Battle Data | Scripted event battle occurring in map `vc07`, coordinating story dialogue triggers and combat conditions. |
| `eb_vc07_00.json` | Story Event Battle Data | Scripted event battle occurring in map `vc07`, coordinating story dialogue triggers and combat conditions. |
| `eb_vc07_01.json` | Story Event Battle Data | Scripted event battle occurring in map `vc07`, coordinating story dialogue triggers and combat conditions. |
| `eb_vc07_02.json` | Story Event Battle Data | Scripted event battle occurring in map `vc07`, coordinating story dialogue triggers and combat conditions. |
| `eb_vc07_obj.json` | Story Event Battle Data | Scripted event battle occurring in map `vc07`, coordinating story dialogue triggers and combat conditions. |
| `eb_vc07b.json` | Story Event Battle Data | Scripted event battle occurring in map `vc07`, coordinating story dialogue triggers and combat conditions. |
| `eb_vc07b_00.json` | Story Event Battle Data | Scripted event battle occurring in map `vc07`, coordinating story dialogue triggers and combat conditions. |
| `eb_vc07b_01.json` | Story Event Battle Data | Scripted event battle occurring in map `vc07`, coordinating story dialogue triggers and combat conditions. |
| `eb_vc07b_02.json` | Story Event Battle Data | Scripted event battle occurring in map `vc07`, coordinating story dialogue triggers and combat conditions. |
| `eb_vc11.json` | Story Event Battle Data | Scripted event battle occurring in map `vc11`, coordinating story dialogue triggers and combat conditions. |
| `eb_vc11_00.json` | Story Event Battle Data | Scripted event battle occurring in map `vc11`, coordinating story dialogue triggers and combat conditions. |
| `eb_vc11_01.json` | Story Event Battle Data | Scripted event battle occurring in map `vc11`, coordinating story dialogue triggers and combat conditions. |
| `eb_vc11_02.json` | Story Event Battle Data | Scripted event battle occurring in map `vc11`, coordinating story dialogue triggers and combat conditions. |
| `eb_vc11_03.json` | Story Event Battle Data | Scripted event battle occurring in map `vc11`, coordinating story dialogue triggers and combat conditions. |
| `eb_vc11_obj.json` | Story Event Battle Data | Scripted event battle occurring in map `vc11`, coordinating story dialogue triggers and combat conditions. |
| `eb_vc16.json` | Story Event Battle Data | Scripted event battle occurring in map `vc16`, coordinating story dialogue triggers and combat conditions. |
| `eb_vc16_00.json` | Story Event Battle Data | Scripted event battle occurring in map `vc16`, coordinating story dialogue triggers and combat conditions. |
| `eb_vc16_01.json` | Story Event Battle Data | Scripted event battle occurring in map `vc16`, coordinating story dialogue triggers and combat conditions. |
| `eb_vc16_02.json` | Story Event Battle Data | Scripted event battle occurring in map `vc16`, coordinating story dialogue triggers and combat conditions. |
| `eb_vc16b.json` | Story Event Battle Data | Scripted event battle occurring in map `vc16`, coordinating story dialogue triggers and combat conditions. |
| `eb_vc16b_00.json` | Story Event Battle Data | Scripted event battle occurring in map `vc16`, coordinating story dialogue triggers and combat conditions. |
| `eb_vc16b_01.json` | Story Event Battle Data | Scripted event battle occurring in map `vc16`, coordinating story dialogue triggers and combat conditions. |
| `eb_vc16b_02.json` | Story Event Battle Data | Scripted event battle occurring in map `vc16`, coordinating story dialogue triggers and combat conditions. |
| `eb_vc16b_03.json` | Story Event Battle Data | Scripted event battle occurring in map `vc16`, coordinating story dialogue triggers and combat conditions. |
| `eb_vc16b_obj.json` | Story Event Battle Data | Scripted event battle occurring in map `vc16`, coordinating story dialogue triggers and combat conditions. |
| `eb_vd07.json` | Story Event Battle Data | Scripted event battle occurring in map `vd07`, coordinating story dialogue triggers and combat conditions. |
| `eb_vd07_00.json` | Story Event Battle Data | Scripted event battle occurring in map `vd07`, coordinating story dialogue triggers and combat conditions. |
| `eb_vd07_01.json` | Story Event Battle Data | Scripted event battle occurring in map `vd07`, coordinating story dialogue triggers and combat conditions. |
| `eb_vd07b.json` | Story Event Battle Data | Scripted event battle occurring in map `vd07`, coordinating story dialogue triggers and combat conditions. |
| `eb_vd07b_00.json` | Story Event Battle Data | Scripted event battle occurring in map `vd07`, coordinating story dialogue triggers and combat conditions. |
| `eb_vd07b_01.json` | Story Event Battle Data | Scripted event battle occurring in map `vd07`, coordinating story dialogue triggers and combat conditions. |
| `eb_vd07b_obj.json` | Story Event Battle Data | Scripted event battle occurring in map `vd07`, coordinating story dialogue triggers and combat conditions. |
| `eb_ve01.json` | Story Event Battle Data | Scripted event battle occurring in map `ve01`, coordinating story dialogue triggers and combat conditions. |
| `eb_ve01_00.json` | Story Event Battle Data | Scripted event battle occurring in map `ve01`, coordinating story dialogue triggers and combat conditions. |
| `eb_ve01_01.json` | Story Event Battle Data | Scripted event battle occurring in map `ve01`, coordinating story dialogue triggers and combat conditions. |
| `eb_ve01_02.json` | Story Event Battle Data | Scripted event battle occurring in map `ve01`, coordinating story dialogue triggers and combat conditions. |
| `eb_ve01_obj.json` | Story Event Battle Data | Scripted event battle occurring in map `ve01`, coordinating story dialogue triggers and combat conditions. |
| `eb_ve02.json` | Story Event Battle Data | Scripted event battle occurring in map `ve02`, coordinating story dialogue triggers and combat conditions. |
| `eb_ve02_00.json` | Story Event Battle Data | Scripted event battle occurring in map `ve02`, coordinating story dialogue triggers and combat conditions. |
| `eb_ve02_obj.json` | Story Event Battle Data | Scripted event battle occurring in map `ve02`, coordinating story dialogue triggers and combat conditions. |
| `eb_ve03.json` | Story Event Battle Data | Scripted event battle occurring in map `ve03`, coordinating story dialogue triggers and combat conditions. |
| `eb_ve03_00.json` | Story Event Battle Data | Scripted event battle occurring in map `ve03`, coordinating story dialogue triggers and combat conditions. |
| `eb_ve03_01.json` | Story Event Battle Data | Scripted event battle occurring in map `ve03`, coordinating story dialogue triggers and combat conditions. |
| `eb_ve03_02.json` | Story Event Battle Data | Scripted event battle occurring in map `ve03`, coordinating story dialogue triggers and combat conditions. |
| `eb_ve06.json` | Story Event Battle Data | Scripted event battle occurring in map `ve06`, coordinating story dialogue triggers and combat conditions. |
| `eb_ve06_00.json` | Story Event Battle Data | Scripted event battle occurring in map `ve06`, coordinating story dialogue triggers and combat conditions. |
| `eb_ve06_01.json` | Story Event Battle Data | Scripted event battle occurring in map `ve06`, coordinating story dialogue triggers and combat conditions. |
| `eb_ve06_02.json` | Story Event Battle Data | Scripted event battle occurring in map `ve06`, coordinating story dialogue triggers and combat conditions. |
| `eb_ve06_obj.json` | Story Event Battle Data | Scripted event battle occurring in map `ve06`, coordinating story dialogue triggers and combat conditions. |
| `eb_ve08.json` | Story Event Battle Data | Scripted event battle occurring in map `ve08`, coordinating story dialogue triggers and combat conditions. |
| `eb_ve08_00.json` | Story Event Battle Data | Scripted event battle occurring in map `ve08`, coordinating story dialogue triggers and combat conditions. |
| `eb_ve08_01.json` | Story Event Battle Data | Scripted event battle occurring in map `ve08`, coordinating story dialogue triggers and combat conditions. |
| `eb_ve08_02.json` | Story Event Battle Data | Scripted event battle occurring in map `ve08`, coordinating story dialogue triggers and combat conditions. |
| `eb_ve08_03.json` | Story Event Battle Data | Scripted event battle occurring in map `ve08`, coordinating story dialogue triggers and combat conditions. |
| `eb_ve15.json` | Story Event Battle Data | Scripted event battle occurring in map `ve15`, coordinating story dialogue triggers and combat conditions. |
| `eb_ve15_00.json` | Story Event Battle Data | Scripted event battle occurring in map `ve15`, coordinating story dialogue triggers and combat conditions. |
| `eb_ve15_01.json` | Story Event Battle Data | Scripted event battle occurring in map `ve15`, coordinating story dialogue triggers and combat conditions. |
| `eb_ve15_02.json` | Story Event Battle Data | Scripted event battle occurring in map `ve15`, coordinating story dialogue triggers and combat conditions. |
| `eb_ve15_03.json` | Story Event Battle Data | Scripted event battle occurring in map `ve15`, coordinating story dialogue triggers and combat conditions. |
| `eb_vg01.json` | Story Event Battle Data | Scripted event battle occurring in map `vg01`, coordinating story dialogue triggers and combat conditions. |
| `eb_vg01_00.json` | Story Event Battle Data | Scripted event battle occurring in map `vg01`, coordinating story dialogue triggers and combat conditions. |
| `eb_vg01_01.json` | Story Event Battle Data | Scripted event battle occurring in map `vg01`, coordinating story dialogue triggers and combat conditions. |
| `eb_vg01_obj.json` | Story Event Battle Data | Scripted event battle occurring in map `vg01`, coordinating story dialogue triggers and combat conditions. |
| `eb_vg03.json` | Story Event Battle Data | Scripted event battle occurring in map `vg03`, coordinating story dialogue triggers and combat conditions. |
| `eb_vg03_00.json` | Story Event Battle Data | Scripted event battle occurring in map `vg03`, coordinating story dialogue triggers and combat conditions. |
| `eb_vg03_01.json` | Story Event Battle Data | Scripted event battle occurring in map `vg03`, coordinating story dialogue triggers and combat conditions. |
| `eb_vg03_obj.json` | Story Event Battle Data | Scripted event battle occurring in map `vg03`, coordinating story dialogue triggers and combat conditions. |
| `eb_vg04.json` | Story Event Battle Data | Scripted event battle occurring in map `vg04`, coordinating story dialogue triggers and combat conditions. |
| `eb_vg04_00.json` | Story Event Battle Data | Scripted event battle occurring in map `vg04`, coordinating story dialogue triggers and combat conditions. |
| `eb_vg04_01.json` | Story Event Battle Data | Scripted event battle occurring in map `vg04`, coordinating story dialogue triggers and combat conditions. |
| `eb_vg07.json` | Story Event Battle Data | Scripted event battle occurring in map `vg07`, coordinating story dialogue triggers and combat conditions. |
| `eb_vg07_00.json` | Story Event Battle Data | Scripted event battle occurring in map `vg07`, coordinating story dialogue triggers and combat conditions. |
| `eb_vg07_01.json` | Story Event Battle Data | Scripted event battle occurring in map `vg07`, coordinating story dialogue triggers and combat conditions. |
| `eb_vg07_obj.json` | Story Event Battle Data | Scripted event battle occurring in map `vg07`, coordinating story dialogue triggers and combat conditions. |
| `eb_vh01.json` | Story Event Battle Data | Scripted event battle occurring in map `vh01`, coordinating story dialogue triggers and combat conditions. |
| `eb_vh01_00.json` | Story Event Battle Data | Scripted event battle occurring in map `vh01`, coordinating story dialogue triggers and combat conditions. |
| `eb_vh01_01.json` | Story Event Battle Data | Scripted event battle occurring in map `vh01`, coordinating story dialogue triggers and combat conditions. |
| `eb_vh01_02.json` | Story Event Battle Data | Scripted event battle occurring in map `vh01`, coordinating story dialogue triggers and combat conditions. |
| `eb_vh01_03.json` | Story Event Battle Data | Scripted event battle occurring in map `vh01`, coordinating story dialogue triggers and combat conditions. |
| `eb_vh01_obj.json` | Story Event Battle Data | Scripted event battle occurring in map `vh01`, coordinating story dialogue triggers and combat conditions. |
| `eb_vh08.json` | Story Event Battle Data | Scripted event battle occurring in map `vh08`, coordinating story dialogue triggers and combat conditions. |
| `eb_vh08_00.json` | Story Event Battle Data | Scripted event battle occurring in map `vh08`, coordinating story dialogue triggers and combat conditions. |
| `eb_vh08_01.json` | Story Event Battle Data | Scripted event battle occurring in map `vh08`, coordinating story dialogue triggers and combat conditions. |
| `eb_vh08_02.json` | Story Event Battle Data | Scripted event battle occurring in map `vh08`, coordinating story dialogue triggers and combat conditions. |
| `eb_vh08_03.json` | Story Event Battle Data | Scripted event battle occurring in map `vh08`, coordinating story dialogue triggers and combat conditions. |
| `eb_vj04.json` | Story Event Battle Data | Scripted event battle occurring in map `vj04`, coordinating story dialogue triggers and combat conditions. |
| `eb_vj04_00.json` | Story Event Battle Data | Scripted event battle occurring in map `vj04`, coordinating story dialogue triggers and combat conditions. |
| `eb_vj04_01.json` | Story Event Battle Data | Scripted event battle occurring in map `vj04`, coordinating story dialogue triggers and combat conditions. |
| `eb_vj04_02.json` | Story Event Battle Data | Scripted event battle occurring in map `vj04`, coordinating story dialogue triggers and combat conditions. |
| `eb_vj04_03.json` | Story Event Battle Data | Scripted event battle occurring in map `vj04`, coordinating story dialogue triggers and combat conditions. |
| `eb_vj04_obj.json` | Story Event Battle Data | Scripted event battle occurring in map `vj04`, coordinating story dialogue triggers and combat conditions. |

---

## <a id="castle-hq-facilities-bathhouse-minigames"></a>Castle HQ Facilities, Bathhouse & Minigames

Total assets in subsystem: **254**

### <a id="bathhouse-scenes-dialogue-triggers-hp_furo_"></a>Bathhouse Scenes & Dialogue Triggers (`hp_furo_*`) (52 files)

| File Name | Subsystem / Type | Technical Role & Grounded Description |
|---|---|---|
| `HDBath.json` | HQ Bathhouse Asset | Castle Bathhouse visual parameters (HDBath), tub models, water colors, or steam effects. |
| `HDBathColour.json` | HQ Bathhouse Asset | Castle Bathhouse visual parameters (HDBathColour), tub models, water colors, or steam effects. |
| `bath.json` | HQ Bathhouse Asset | Castle Bathhouse visual parameters (bath), tub models, water colors, or steam effects. |
| `hp_furo.json` | HQ Bathhouse Asset | Castle Bathhouse visual parameters (hp_furo), tub models, water colors, or steam effects. |
| `hp_furo_00.json` | HQ Bathhouse Interaction | Castle Bathhouse scene config #00: character dialogue combinations, bath accessories, and reactions. |
| `hp_furo_01.json` | HQ Bathhouse Interaction | Castle Bathhouse scene config #01: character dialogue combinations, bath accessories, and reactions. |
| `hp_furo_02.json` | HQ Bathhouse Interaction | Castle Bathhouse scene config #02: character dialogue combinations, bath accessories, and reactions. |
| `hp_furo_03.json` | HQ Bathhouse Interaction | Castle Bathhouse scene config #03: character dialogue combinations, bath accessories, and reactions. |
| `hp_furo_04.json` | HQ Bathhouse Interaction | Castle Bathhouse scene config #04: character dialogue combinations, bath accessories, and reactions. |
| `hp_furo_05.json` | HQ Bathhouse Interaction | Castle Bathhouse scene config #05: character dialogue combinations, bath accessories, and reactions. |
| `hp_furo_06.json` | HQ Bathhouse Interaction | Castle Bathhouse scene config #06: character dialogue combinations, bath accessories, and reactions. |
| `hp_furo_07.json` | HQ Bathhouse Interaction | Castle Bathhouse scene config #07: character dialogue combinations, bath accessories, and reactions. |
| `hp_furo_08.json` | HQ Bathhouse Interaction | Castle Bathhouse scene config #08: character dialogue combinations, bath accessories, and reactions. |
| `hp_furo_09.json` | HQ Bathhouse Interaction | Castle Bathhouse scene config #09: character dialogue combinations, bath accessories, and reactions. |
| `hp_furo_10.json` | HQ Bathhouse Interaction | Castle Bathhouse scene config #10: character dialogue combinations, bath accessories, and reactions. |
| `hp_furo_11.json` | HQ Bathhouse Interaction | Castle Bathhouse scene config #11: character dialogue combinations, bath accessories, and reactions. |
| `hp_furo_12.json` | HQ Bathhouse Interaction | Castle Bathhouse scene config #12: character dialogue combinations, bath accessories, and reactions. |
| `hp_furo_13.json` | HQ Bathhouse Interaction | Castle Bathhouse scene config #13: character dialogue combinations, bath accessories, and reactions. |
| `hp_furo_14.json` | HQ Bathhouse Interaction | Castle Bathhouse scene config #14: character dialogue combinations, bath accessories, and reactions. |
| `hp_furo_15.json` | HQ Bathhouse Interaction | Castle Bathhouse scene config #15: character dialogue combinations, bath accessories, and reactions. |
| `hp_furo_16.json` | HQ Bathhouse Interaction | Castle Bathhouse scene config #16: character dialogue combinations, bath accessories, and reactions. |
| `hp_furo_17.json` | HQ Bathhouse Interaction | Castle Bathhouse scene config #17: character dialogue combinations, bath accessories, and reactions. |
| `hp_furo_18.json` | HQ Bathhouse Interaction | Castle Bathhouse scene config #18: character dialogue combinations, bath accessories, and reactions. |
| `hp_furo_19.json` | HQ Bathhouse Interaction | Castle Bathhouse scene config #19: character dialogue combinations, bath accessories, and reactions. |
| `hp_furo_20.json` | HQ Bathhouse Interaction | Castle Bathhouse scene config #20: character dialogue combinations, bath accessories, and reactions. |
| `hp_furo_21.json` | HQ Bathhouse Interaction | Castle Bathhouse scene config #21: character dialogue combinations, bath accessories, and reactions. |
| `hp_furo_22.json` | HQ Bathhouse Interaction | Castle Bathhouse scene config #22: character dialogue combinations, bath accessories, and reactions. |
| `hp_furo_23.json` | HQ Bathhouse Interaction | Castle Bathhouse scene config #23: character dialogue combinations, bath accessories, and reactions. |
| `hp_furo_24.json` | HQ Bathhouse Interaction | Castle Bathhouse scene config #24: character dialogue combinations, bath accessories, and reactions. |
| `hp_furo_25.json` | HQ Bathhouse Interaction | Castle Bathhouse scene config #25: character dialogue combinations, bath accessories, and reactions. |
| `hp_furo_26.json` | HQ Bathhouse Interaction | Castle Bathhouse scene config #26: character dialogue combinations, bath accessories, and reactions. |
| `hp_furo_28.json` | HQ Bathhouse Interaction | Castle Bathhouse scene config #28: character dialogue combinations, bath accessories, and reactions. |
| `hp_furo_29.json` | HQ Bathhouse Interaction | Castle Bathhouse scene config #29: character dialogue combinations, bath accessories, and reactions. |
| `hp_furo_30.json` | HQ Bathhouse Interaction | Castle Bathhouse scene config #30: character dialogue combinations, bath accessories, and reactions. |
| `hp_furo_31.json` | HQ Bathhouse Interaction | Castle Bathhouse scene config #31: character dialogue combinations, bath accessories, and reactions. |
| `hp_furo_32.json` | HQ Bathhouse Interaction | Castle Bathhouse scene config #32: character dialogue combinations, bath accessories, and reactions. |
| `hp_furo_33.json` | HQ Bathhouse Interaction | Castle Bathhouse scene config #33: character dialogue combinations, bath accessories, and reactions. |
| `hp_furo_34.json` | HQ Bathhouse Interaction | Castle Bathhouse scene config #34: character dialogue combinations, bath accessories, and reactions. |
| `hp_furo_35.json` | HQ Bathhouse Interaction | Castle Bathhouse scene config #35: character dialogue combinations, bath accessories, and reactions. |
| `hp_furo_36.json` | HQ Bathhouse Interaction | Castle Bathhouse scene config #36: character dialogue combinations, bath accessories, and reactions. |
| `hp_furo_37.json` | HQ Bathhouse Interaction | Castle Bathhouse scene config #37: character dialogue combinations, bath accessories, and reactions. |
| `hp_furo_38.json` | HQ Bathhouse Interaction | Castle Bathhouse scene config #38: character dialogue combinations, bath accessories, and reactions. |
| `hp_furo_39.json` | HQ Bathhouse Interaction | Castle Bathhouse scene config #39: character dialogue combinations, bath accessories, and reactions. |
| `hp_furo_40.json` | HQ Bathhouse Interaction | Castle Bathhouse scene config #40: character dialogue combinations, bath accessories, and reactions. |
| `hp_furo_41.json` | HQ Bathhouse Interaction | Castle Bathhouse scene config #41: character dialogue combinations, bath accessories, and reactions. |
| `hp_furo_42.json` | HQ Bathhouse Interaction | Castle Bathhouse scene config #42: character dialogue combinations, bath accessories, and reactions. |
| `hp_furo_43.json` | HQ Bathhouse Interaction | Castle Bathhouse scene config #43: character dialogue combinations, bath accessories, and reactions. |
| `hp_furo_bg1.json` | HQ Bathhouse Asset | Castle Bathhouse visual parameters (hp_furo_bg1), tub models, water colors, or steam effects. |
| `hp_furo_bg2.json` | HQ Bathhouse Asset | Castle Bathhouse visual parameters (hp_furo_bg2), tub models, water colors, or steam effects. |
| `hp_furo_bg3.json` | HQ Bathhouse Asset | Castle Bathhouse visual parameters (hp_furo_bg3), tub models, water colors, or steam effects. |
| `hp_furo_bg4.json` | HQ Bathhouse Asset | Castle Bathhouse visual parameters (hp_furo_bg4), tub models, water colors, or steam effects. |
| `hp_furo_bg5.json` | HQ Bathhouse Asset | Castle Bathhouse visual parameters (hp_furo_bg5), tub models, water colors, or steam effects. |

### <a id="castle-facility-sub-assets-hp_"></a>Castle Facility Sub-Assets (`hp_*`) (165 files)

| File Name | Subsystem / Type | Technical Role & Grounded Description |
|---|---|---|
| `hp_hwindow.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_hwindow`. |
| `hp_hwindow_00.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_hwindow_00`. |
| `hp_meyasu.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_meyasu`. |
| `hp_meyasu_00.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_meyasu_00`. |
| `hp_mogura.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_mogura`. |
| `hp_mogura_00.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_mogura_00`. |
| `hp_mogura_01.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_mogura_01`. |
| `hp_mogura_02.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_mogura_02`. |
| `hp_mogura_03.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_mogura_03`. |
| `hp_mogura_04.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_mogura_04`. |
| `hp_odori.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_odori`. |
| `hp_odori_00.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_odori_00`. |
| `hp_odori_01.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_odori_01`. |
| `hp_odori_02.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_odori_02`. |
| `hp_odori_03.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_odori_03`. |
| `hp_odori_04.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_odori_04`. |
| `hp_partychg.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_partychg`. |
| `hp_peeping.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_peeping`. |
| `hp_peeping_00.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_peeping_00`. |
| `hp_rbat.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat`. |
| `hp_rbat0.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat0`. |
| `hp_rbat0_00.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat0_00`. |
| `hp_rbat0_01.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat0_01`. |
| `hp_rbat0_02.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat0_02`. |
| `hp_rbat0_03.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat0_03`. |
| `hp_rbat1.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat1`. |
| `hp_rbat10.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat10`. |
| `hp_rbat10_02.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat10_02`. |
| `hp_rbat10_03.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat10_03`. |
| `hp_rbat1_00.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat1_00`. |
| `hp_rbat1_01.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat1_01`. |
| `hp_rbat1_02.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat1_02`. |
| `hp_rbat1_03.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat1_03`. |
| `hp_rbat2.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat2`. |
| `hp_rbat2_00.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat2_00`. |
| `hp_rbat2_01.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat2_01`. |
| `hp_rbat2_02.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat2_02`. |
| `hp_rbat2_03.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat2_03`. |
| `hp_rbat3.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat3`. |
| `hp_rbat3_00.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat3_00`. |
| `hp_rbat3_01.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat3_01`. |
| `hp_rbat3_02.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat3_02`. |
| `hp_rbat3_03.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat3_03`. |
| `hp_rbat4.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat4`. |
| `hp_rbat4_00.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat4_00`. |
| `hp_rbat4_01.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat4_01`. |
| `hp_rbat4_02.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat4_02`. |
| `hp_rbat4_03.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat4_03`. |
| `hp_rbat5.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat5`. |
| `hp_rbat5_00.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat5_00`. |
| `hp_rbat5_01.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat5_01`. |
| `hp_rbat5_02.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat5_02`. |
| `hp_rbat5_03.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat5_03`. |
| `hp_rbat6.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat6`. |
| `hp_rbat6_00.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat6_00`. |
| `hp_rbat6_01.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat6_01`. |
| `hp_rbat6_02.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat6_02`. |
| `hp_rbat6_03.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat6_03`. |
| `hp_rbat7.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat7`. |
| `hp_rbat7_02.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat7_02`. |
| `hp_rbat7_03.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat7_03`. |
| `hp_rbat8.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat8`. |
| `hp_rbat8_02.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat8_02`. |
| `hp_rbat8_03.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat8_03`. |
| `hp_rbat9.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat9`. |
| `hp_rbat9_02.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat9_02`. |
| `hp_rbat9_03.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat9_03`. |
| `hp_rbat_00.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat_00`. |
| `hp_rbat_01.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat_01`. |
| `hp_rbat_02.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat_02`. |
| `hp_rbat_03.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat_03`. |
| `hp_rbat_04.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat_04`. |
| `hp_rbat_05.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat_05`. |
| `hp_rbat_06.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat_06`. |
| `hp_rbat_07.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat_07`. |
| `hp_rbat_08.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat_08`. |
| `hp_rbat_09.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat_09`. |
| `hp_rbat_10.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat_10`. |
| `hp_rbat_11.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat_11`. |
| `hp_rbat_12.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat_12`. |
| `hp_rbat_13.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat_13`. |
| `hp_rbat_14.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat_14`. |
| `hp_rbat_15.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat_15`. |
| `hp_rbat_16.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat_16`. |
| `hp_rbat_17.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat_17`. |
| `hp_rbat_18.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat_18`. |
| `hp_rbat_19.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat_19`. |
| `hp_rbat_20.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat_20`. |
| `hp_rbat_21.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat_21`. |
| `hp_rbat_22.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat_22`. |
| `hp_rbat_23.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat_23`. |
| `hp_rbat_24.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat_24`. |
| `hp_rbat_25.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat_25`. |
| `hp_rbat_26.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat_26`. |
| `hp_rbat_27.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat_27`. |
| `hp_rbat_28.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat_28`. |
| `hp_rbat_29.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat_29`. |
| `hp_rbat_30.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat_30`. |
| `hp_rbat_31.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat_31`. |
| `hp_rbat_32.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat_32`. |
| `hp_rbat_33.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat_33`. |
| `hp_rbat_34.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat_34`. |
| `hp_rbat_35.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat_35`. |
| `hp_rbat_36.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat_36`. |
| `hp_rbat_37.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat_37`. |
| `hp_rbat_38.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rbat_38`. |
| `hp_rest.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rest`. |
| `hp_rest_00.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_rest_00`. |
| `hp_shugo.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_shugo`. |
| `hp_shugo_00.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_shugo_00`. |
| `hp_sndtest.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_sndtest`. |
| `hp_sndtest_00.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_sndtest_00`. |
| `hp_sndtest_02.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_sndtest_02`. |
| `hp_sndtest_03.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_sndtest_03`. |
| `hp_sndtest_04.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_sndtest_04`. |
| `hp_sndtest_05.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_sndtest_05`. |
| `hp_souko.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_souko`. |
| `hp_souko_00.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_souko_00`. |
| `hp_souko_01.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_souko_01`. |
| `hp_stone.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_stone`. |
| `hp_stone_00.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_stone_00`. |
| `hp_stone_01.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_stone_01`. |
| `hp_stone_02.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_stone_02`. |
| `hp_tantei.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_tantei`. |
| `hp_tantei_00.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_tantei_00`. |
| `hp_teamchg.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_teamchg`. |
| `hp_telepo.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_telepo`. |
| `hp_wakeup.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_wakeup`. |
| `hp_wakeup_00.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_wakeup_00`. |
| `hp_wakeup_01.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_wakeup_01`. |
| `hp_wakeup_02.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_wakeup_02`. |
| `hp_wakeup_03.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_wakeup_03`. |
| `hp_wakeup_04.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_wakeup_04`. |
| `hp_wakeup_05.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_wakeup_05`. |
| `hp_wakeup_06.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_wakeup_06`. |
| `hp_wakeup_07.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_wakeup_07`. |
| `hp_wakeup_08.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_wakeup_08`. |
| `hp_wakeup_09.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_wakeup_09`. |
| `hp_wakeup_10.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_wakeup_10`. |
| `hp_wakeup_11.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_wakeup_11`. |
| `hp_wakeup_12.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_wakeup_12`. |
| `hp_wakeup_13.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_wakeup_13`. |
| `hp_wakeup_14.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_wakeup_14`. |
| `hp_wakeup_16.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_wakeup_16`. |
| `hp_wakeup_17.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_wakeup_17`. |
| `hp_wakeup_18.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_wakeup_18`. |
| `hp_wakeup_19.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_wakeup_19`. |
| `hp_wakeup_20.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_wakeup_20`. |
| `hp_wakeup_21.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_wakeup_21`. |
| `hp_wakeup_22.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_wakeup_22`. |
| `hp_wakeup_23.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_wakeup_23`. |
| `hp_wakeup_24.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_wakeup_24`. |
| `hp_wakeup_25.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_wakeup_25`. |
| `hp_wakeup_26.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_wakeup_26`. |
| `hp_wakeup_27.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_wakeup_27`. |
| `hp_wakeup_28.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_wakeup_28`. |
| `hp_wakeup_29.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_wakeup_29`. |
| `hp_wakeup_30.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_wakeup_30`. |
| `hp_wakeup_31.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_wakeup_31`. |
| `hp_wakeup_32.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_wakeup_32`. |
| `hp_wakeup_33.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_wakeup_33`. |
| `hp_wakeup_34.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_wakeup_34`. |
| `hp_wakeup_35.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_wakeup_35`. |
| `hp_wakeup_36.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_wakeup_36`. |
| `hp_wakeup_37.json` | HQ Minigame / Facility | Headquarters castle activity asset for `hp_wakeup_37`. |

### <a id="chinchirorin-dice-minigame-hp_chin_"></a>Chinchirorin Dice Minigame (`hp_chin_*`) (2 files)

| File Name | Subsystem / Type | Technical Role & Grounded Description |
|---|---|---|
| `CoinPanel.json` | HQ Minigame UI | Chinchirorin cup-and-dice minigame UI component binding cup sprite, shadows, and coin/dice positions. |
| `hp_chin.json` | HQ Chinchirorin Minigame | Chinchirorin dice minigame asset (hp_chin) controlling stakes and dice rolls. |

### <a id="detective-floor-plans-castle-maps-hp_hmap_"></a>Detective Floor Plans & Castle Maps (`hp_hmap_*`) (9 files)

| File Name | Subsystem / Type | Technical Role & Grounded Description |
|---|---|---|
| `hp_hmap.json` | HQ Detective / Castle Map | Castle floor map asset (hp_hmap) tracking NPC rooms and layout. |
| `hp_hmap_00.json` | HQ Detective / Castle Map | Castle floor map asset (hp_hmap_00) tracking NPC rooms and layout. |
| `hp_hmap_01.json` | HQ Detective / Castle Map | Castle floor map asset (hp_hmap_01) tracking NPC rooms and layout. |
| `hp_hmap_02.json` | HQ Detective / Castle Map | Castle floor map asset (hp_hmap_02) tracking NPC rooms and layout. |
| `hp_hmap_03.json` | HQ Detective / Castle Map | Castle floor map asset (hp_hmap_03) tracking NPC rooms and layout. |
| `hp_hmap_04.json` | HQ Detective / Castle Map | Castle floor map asset (hp_hmap_04) tracking NPC rooms and layout. |
| `hp_hmap_05.json` | HQ Detective / Castle Map | Castle floor map asset (hp_hmap_05) tracking NPC rooms and layout. |
| `hp_hmap_06.json` | HQ Detective / Castle Map | Castle floor map asset (hp_hmap_06) tracking NPC rooms and layout. |
| `hp_hmap_07.json` | HQ Detective / Castle Map | Castle floor map asset (hp_hmap_07) tracking NPC rooms and layout. |

### <a id="fishing-minigame-hp_fish_"></a>Fishing Minigame (`hp_fish_*`) (6 files)

| File Name | Subsystem / Type | Technical Role & Grounded Description |
|---|---|---|
| `hp_fish.json` | HQ Fishing Minigame | Castle fishing pond asset (hp_fish) configuring fish types, bites, and prizes. |
| `hp_fish_00.json` | HQ Fishing Minigame | Castle fishing pond asset (hp_fish_00) configuring fish types, bites, and prizes. |
| `hp_fish_01.json` | HQ Fishing Minigame | Castle fishing pond asset (hp_fish_01) configuring fish types, bites, and prizes. |
| `hp_fish_02.json` | HQ Fishing Minigame | Castle fishing pond asset (hp_fish_02) configuring fish types, bites, and prizes. |
| `hp_fish_03.json` | HQ Fishing Minigame | Castle fishing pond asset (hp_fish_03) configuring fish types, bites, and prizes. |
| `hp_fish_04.json` | HQ Fishing Minigame | Castle fishing pond asset (hp_fish_04) configuring fish types, bites, and prizes. |

### <a id="library-readable-old-books-hp_book_"></a>Library Readable Old Books (`hp_book_*`) (4 files)

| File Name | Subsystem / Type | Technical Role & Grounded Description |
|---|---|---|
| `hp_book.json` | HQ Library Old Book | Castle library readable Old Book asset (hp_book) storing lore text. |
| `hp_book_00.json` | HQ Library Old Book | Castle library readable Old Book asset (hp_book_00) storing lore text. |
| `hp_book_01.json` | HQ Library Old Book | Castle library readable Old Book asset (hp_book_01) storing lore text. |
| `hp_book_02.json` | HQ Library Old Book | Castle library readable Old Book asset (hp_book_02) storing lore text. |

### <a id="sound-room-jukebox-playlists-hp_hsound_"></a>Sound Room Jukebox Playlists (`hp_hsound_*`) (10 files)

| File Name | Subsystem / Type | Technical Role & Grounded Description |
|---|---|---|
| `hp_hsound.json` | HQ Sound Room Jukebox | Castle sound room music track playlist asset (hp_hsound). |
| `hp_hsound_01.json` | HQ Sound Room Jukebox | Castle sound room music track playlist asset (hp_hsound_01). |
| `hp_hsound_02.json` | HQ Sound Room Jukebox | Castle sound room music track playlist asset (hp_hsound_02). |
| `hp_hsound_03.json` | HQ Sound Room Jukebox | Castle sound room music track playlist asset (hp_hsound_03). |
| `hp_hsound_04.json` | HQ Sound Room Jukebox | Castle sound room music track playlist asset (hp_hsound_04). |
| `hp_hsound_05.json` | HQ Sound Room Jukebox | Castle sound room music track playlist asset (hp_hsound_05). |
| `hp_hsound_06.json` | HQ Sound Room Jukebox | Castle sound room music track playlist asset (hp_hsound_06). |
| `hp_hsound_07.json` | HQ Sound Room Jukebox | Castle sound room music track playlist asset (hp_hsound_07). |
| `hp_hsound_08.json` | HQ Sound Room Jukebox | Castle sound room music track playlist asset (hp_hsound_08). |
| `hp_hsound_09.json` | HQ Sound Room Jukebox | Castle sound room music track playlist asset (hp_hsound_09). |

### <a id="wood-chopping-minigame-hp_kikori_"></a>Wood Chopping Minigame (`hp_kikori_*`) (6 files)

| File Name | Subsystem / Type | Technical Role & Grounded Description |
|---|---|---|
| `hp_kikori.json` | HQ Wood Chopping Minigame | Wood-cutting minigame asset (hp_kikori) managing swing timing and stamina. |
| `hp_kikori_00.json` | HQ Wood Chopping Minigame | Wood-cutting minigame asset (hp_kikori_00) managing swing timing and stamina. |
| `hp_kikori_01.json` | HQ Wood Chopping Minigame | Wood-cutting minigame asset (hp_kikori_01) managing swing timing and stamina. |
| `hp_kikori_02.json` | HQ Wood Chopping Minigame | Wood-cutting minigame asset (hp_kikori_02) managing swing timing and stamina. |
| `hp_kikori_03.json` | HQ Wood Chopping Minigame | Wood-cutting minigame asset (hp_kikori_03) managing swing timing and stamina. |
| `hp_kikori_04.json` | HQ Wood Chopping Minigame | Wood-cutting minigame asset (hp_kikori_04) managing swing timing and stamina. |

---

## <a id="playable-npc-character-entities"></a>Playable & NPC Character Entities

Total assets in subsystem: **141**

### <a id="character-field-avatars-battle-models-dialogues"></a>Character Field Avatars, Battle Models & Dialogues (141 files)

| File Name | Subsystem / Type | Technical Role & Grounded Description |
|---|---|---|
| `ada.json` | Character Asset (Adlai) | Character profile asset for Adlai (ada). |
| `ail.json` | Character Asset (Aileen) | Character profile asset for Aileen (ail). |
| `ail_battle_00.json` | Character Battle Asset (Aileen) | Combat unit model and animation bindings for Aileen. |
| `ail_field_00.json` | Character Field Asset (Aileen) | Overworld field NPC configuration and sprite triggers for Aileen. |
| `air.json` | Character Asset (Anita) | Character profile asset for Anita (air). |
| `alx_d.json` | Character Asset (Alex) | Character profile asset for Alex (alx). |
| `amd.json` | Character Asset (Amada) | Character profile asset for Amada (amd). |
| `ani.json` | Character Asset (Annallee) | Character profile asset for Annallee (ani). |
| `anj.json` | Character Asset (Annallee (Alt)) | Character profile asset for Annallee (Alt) (anj). |
| `anj_battle_00.json` | Character Battle Asset (Annallee (Alt)) | Combat unit model and animation bindings for Annallee (Alt). |
| `anj_field_00.json` | Character Field Asset (Annallee (Alt)) | Overworld field NPC configuration and sprite triggers for Annallee (Alt). |
| `ant.json` | Character Asset (Antonio) | Character profile asset for Antonio (ant). |
| `ant_battle_00.json` | Character Battle Asset (Antonio) | Combat unit model and animation bindings for Antonio. |
| `ant_field_00.json` | Character Field Asset (Antonio) | Overworld field NPC configuration and sprite triggers for Antonio. |
| `app_d.json` | Character Asset (Apple) | Character profile asset for Apple (app). |
| `are.json` | Character Asset (Ayda) | Character profile asset for Ayda (are). |
| `are_battle_00.json` | Character Battle Asset (Ayda) | Combat unit model and animation bindings for Ayda. |
| `are_field_00.json` | Character Field Asset (Ayda) | Overworld field NPC configuration and sprite triggers for Ayda. |
| `bal.json` | Character Asset (Barbara) | Character profile asset for Barbara (bal). |
| `bal_battle_00.json` | Character Battle Asset (Barbara) | Combat unit model and animation bindings for Barbara. |
| `bal_field_00.json` | Character Field Asset (Barbara) | Overworld field NPC configuration and sprite triggers for Barbara. |
| `bel.json` | Character Asset (Belle) | Character profile asset for Belle (bel). |
| `bel_battle_00.json` | Character Battle Asset (Belle) | Combat unit model and animation bindings for Belle. |
| `bel_field_00.json` | Character Field Asset (Belle) | Overworld field NPC configuration and sprite triggers for Belle. |
| `bic.json` | Character Asset (Bob) | Character profile asset for Bob (bic). |
| `blk.json` | Character Asset (Bolgan) | Character profile asset for Bolgan (blk). |
| `blk_battle_00.json` | Character Battle Asset (Bolgan) | Combat unit model and animation bindings for Bolgan. |
| `blk_field_00.json` | Character Field Asset (Bolgan) | Overworld field NPC configuration and sprite triggers for Bolgan. |
| `bor.json` | Character Asset (Boris) | Character profile asset for Boris (bor). |
| `boz.json` | Character Asset (Boc) | Character profile asset for Boc (boz). |
| `cam.json` | Character Asset (Camus) | Character profile asset for Camus (cam). |
| `cam_battle_00.json` | Character Battle Asset (Camus) | Combat unit model and animation bindings for Camus. |
| `cam_field_00.json` | Character Field Asset (Camus) | Overworld field NPC configuration and sprite triggers for Camus. |
| `cob.json` | Character Asset (Clive) | Character profile asset for Clive (cob). |
| `cob_battle_00.json` | Character Battle Asset (Clive) | Combat unit model and animation bindings for Clive. |
| `cob_field_00.json` | Character Field Asset (Clive) | Overworld field NPC configuration and sprite triggers for Clive. |
| `cre.json` | Character Asset (Connell) | Character profile asset for Connell (cre). |
| `cre_battle_00.json` | Character Battle Asset (Connell) | Combat unit model and animation bindings for Connell. |
| `cre_field_00.json` | Character Field Asset (Connell) | Overworld field NPC configuration and sprite triggers for Connell. |
| `cri.json` | Character Asset (Chris) | Character profile asset for Chris (cri). |
| `cri_battle_00.json` | Character Battle Asset (Chris) | Combat unit model and animation bindings for Chris. |
| `cri_field_00.json` | Character Field Asset (Chris) | Overworld field NPC configuration and sprite triggers for Chris. |
| `cro.json` | Character Asset (Crowley) | Character profile asset for Crowley (cro). |
| `cro_battle_00.json` | Character Battle Asset (Crowley) | Combat unit model and animation bindings for Crowley. |
| `cro_field_00.json` | Character Field Asset (Crowley) | Overworld field NPC configuration and sprite triggers for Crowley. |
| `crw.json` | Character Asset (Chaco) | Character profile asset for Chaco (crw). |
| `crw_battle_00.json` | Character Battle Asset (Chaco) | Combat unit model and animation bindings for Chaco. |
| `crw_field_00.json` | Character Field Asset (Chaco) | Overworld field NPC configuration and sprite triggers for Chaco. |
| `cry.json` | Character Asset (Circe) | Character profile asset for Circe (cry). |
| `csi.json` | Character Asset (Casper) | Character profile asset for Casper (csi). |
| `csi_battle_00.json` | Character Battle Asset (Casper) | Combat unit model and animation bindings for Casper. |
| `csi_field_00.json` | Character Field Asset (Casper) | Overworld field NPC configuration and sprite triggers for Casper. |
| `cyk.json` | Character Asset (Chaco (Alt)) | Character profile asset for Chaco (Alt) (cyk). |
| `dor.json` | Character Asset (Dorothy) | Character profile asset for Dorothy (dor). |
| `eik.json` | Character Asset (Eike) | Character profile asset for Eike (eik). |
| `eik_battle_00.json` | Character Battle Asset (Eike) | Combat unit model and animation bindings for Eike. |
| `eik_field_00.json` | Character Field Asset (Eike) | Overworld field NPC configuration and sprite triggers for Eike. |
| `eri_d.json` | Character Asset (Eilie) | Character profile asset for Eilie (eri). |
| `fma.json` | Character Asset (Fitcher) | Character profile asset for Fitcher (fma). |
| `fma_battle_00.json` | Character Battle Asset (Fitcher) | Combat unit model and animation bindings for Fitcher. |
| `fma_field_00.json` | Character Field Asset (Fitcher) | Overworld field NPC configuration and sprite triggers for Fitcher. |
| `fre.json` | Character Asset (Freed Y) | Character profile asset for Freed Y (fre). |
| `fri.json` | Character Asset (Freed Y) | Character profile asset for Freed Y (fri). |
| `fri_battle_00.json` | Character Battle Asset (Freed Y) | Combat unit model and animation bindings for Freed Y. |
| `fri_field_00.json` | Character Field Asset (Freed Y) | Overworld field NPC configuration and sprite triggers for Freed Y. |
| `frk.json` | Character Asset (Frank) | Character profile asset for Frank (frk). |
| `fuk.json` | Character Asset (Futch) | Character profile asset for Futch (fuk). |
| `fuk_battle_00.json` | Character Battle Asset (Futch) | Combat unit model and animation bindings for Futch. |
| `fuk_field_00.json` | Character Field Asset (Futch) | Overworld field NPC configuration and sprite triggers for Futch. |
| `fut.json` | Character Asset (Futch) | Character profile asset for Futch (fut). |
| `fut_battle_00.json` | Character Battle Asset (Futch) | Combat unit model and animation bindings for Futch. |
| `fut_field_00.json` | Character Field Asset (Futch) | Overworld field NPC configuration and sprite triggers for Futch. |
| `fuu.json` | Character Asset (Fumi) | Character profile asset for Fumi (fuu). |
| `fuu_battle_00.json` | Character Battle Asset (Fumi) | Combat unit model and animation bindings for Fumi. |
| `fuu_field_00.json` | Character Field Asset (Fumi) | Overworld field NPC configuration and sprite triggers for Fumi. |
| `gab.json` | Character Asset (Gabriel) | Character profile asset for Gabriel (gab). |
| `gen.json` | Character Asset (Gengen) | Character profile asset for Gengen (gen). |
| `gen_battle_00.json` | Character Battle Asset (Gengen) | Combat unit model and animation bindings for Gengen. |
| `gen_field_00.json` | Character Field Asset (Gengen) | Overworld field NPC configuration and sprite triggers for Gengen. |
| `geo.json` | Character Asset (Georg) | Character profile asset for Georg (geo). |
| `gjm.json` | Character Asset (Gijimu) | Character profile asset for Gijimu (gjm). |
| `gol.json` | Character Asset (Goran) | Character profile asset for Goran (gol). |
| `gon.json` | Character Asset (Gonso) | Character profile asset for Gonso (gon). |
| `gon_battle_00.json` | Character Battle Asset (Gonso) | Combat unit model and animation bindings for Gonso. |
| `gon_field_00.json` | Character Field Asset (Gonso) | Overworld field NPC configuration and sprite triggers for Gonso. |
| `gre.json` | Character Asset (Gremio) | Character profile asset for Gremio (gre). |
| `gre_battle_00.json` | Character Battle Asset (Gremio) | Combat unit model and animation bindings for Gremio. |
| `gre_d.json` | Character Asset (Gremio) | Character profile asset for Gremio (gre). |
| `gre_field_00.json` | Character Field Asset (Gremio) | Overworld field NPC configuration and sprite triggers for Gremio. |
| `gri.json` | Character Asset (Granmeyer) | Character profile asset for Granmeyer (gri). |
| `gri_battle_00.json` | Character Battle Asset (Granmeyer) | Combat unit model and animation bindings for Granmeyer. |
| `gri_field_00.json` | Character Field Asset (Granmeyer) | Overworld field NPC configuration and sprite triggers for Granmeyer. |
| `grn.json` | Character Asset (Gordon) | Character profile asset for Gordon (grn). |
| `grn_battle_00.json` | Character Battle Asset (Gordon) | Combat unit model and animation bindings for Gordon. |
| `grn_field_00.json` | Character Field Asset (Gordon) | Overworld field NPC configuration and sprite triggers for Gordon. |
| `haf.json` | Character Asset (Hauser) | Character profile asset for Hauser (haf). |
| `haf_battle_00.json` | Character Battle Asset (Hauser) | Combat unit model and animation bindings for Hauser. |
| `haf_field_00.json` | Character Field Asset (Hauser) | Overworld field NPC configuration and sprite triggers for Hauser. |
| `han.json` | Character Asset (Han) | Character profile asset for Han (han). |
| `hap.json` | Character Asset (Hanna) | Character profile asset for Hanna (hap). |
| `haw.json` | Character Asset (Hai Yo) | Character profile asset for Hai Yo (haw). |
| `hel.json` | Character Asset (Hix) | Character profile asset for Hix (hel). |
| `hel_battle_00.json` | Character Battle Asset (Hix) | Combat unit model and animation bindings for Hix. |
| `hel_field_00.json` | Character Field Asset (Hix) | Overworld field NPC configuration and sprite triggers for Hix. |
| `hic.json` | Character Asset (Hix) | Character profile asset for Hix (hic). |
| `hic_battle_00.json` | Character Battle Asset (Hix) | Combat unit model and animation bindings for Hix. |
| `hic_field_00.json` | Character Field Asset (Hix) | Overworld field NPC configuration and sprite triggers for Hix. |
| `hnf.json` | Character Asset (Hanna) | Character profile asset for Hanna (hnf). |
| `kas.json` | Character Asset (Kasumi) | Character profile asset for Kasumi (kas). |
| `kas_battle_00.json` | Character Battle Asset (Kasumi) | Combat unit model and animation bindings for Kasumi. |
| `kas_field_00.json` | Character Field Asset (Kasumi) | Overworld field NPC configuration and sprite triggers for Kasumi. |
| `luc.json` | Character Asset (Luca Blight) | Character profile asset for Luca Blight (luc). |
| `mil.json` | Character Asset (Millie) | Character profile asset for Millie (mil). |
| `mil_battle_00.json` | Character Battle Asset (Millie) | Combat unit model and animation bindings for Millie. |
| `mil_field_00.json` | Character Field Asset (Millie) | Overworld field NPC configuration and sprite triggers for Millie. |
| `nan.json` | Character Asset (Nanami) | Character profile asset for Nanami (nan). |
| `nec3.json` | Character Asset (Neclord) | Character profile asset for Neclord (nec). |
| `ryo.json` | Character Asset (Riou (Hero)) | Character profile asset for Riou (Hero) (ryo). |
| `shu.json` | Character Asset (Shu) | Character profile asset for Shu (shu). |
| `shu_01.json` | Character Asset (Shu) | Character profile asset for Shu (shu). |
| `shu_02.json` | Character Asset (Shu) | Character profile asset for Shu (shu). |
| `shu_03.json` | Character Asset (Shu) | Character profile asset for Shu (shu). |
| `shu_04.json` | Character Asset (Shu) | Character profile asset for Shu (shu). |
| `shu_04_hd.json` | Character Asset (Shu) | Character profile asset for Shu (shu). |
| `shu_battle_00.json` | Character Battle Asset (Shu) | Combat unit model and animation bindings for Shu. |
| `shu_field_00.json` | Character Field Asset (Shu) | Overworld field NPC configuration and sprite triggers for Shu. |
| `shu_field_01.json` | Character Field Asset (Shu) | Overworld field NPC configuration and sprite triggers for Shu. |
| `shu_kwa.json` | Character Asset (Shu) | Character profile asset for Shu (shu). |
| `shu_kwa_00.json` | Character Asset (Shu) | Character profile asset for Shu (shu). |
| `shu_kwa_01.json` | Character Asset (Shu) | Character profile asset for Shu (shu). |
| `shu_kwa_field.json` | Character Field Asset (Shu) | Overworld field NPC configuration and sprite triggers for Shu. |
| `shu_kwa_field_srn.json` | Character Field Asset (Shu) | Overworld field NPC configuration and sprite triggers for Shu. |
| `shu_teo.json` | Character Asset (Shu) | Character profile asset for Shu (shu). |
| `shu_teo_01.json` | Character Asset (Shu) | Character profile asset for Shu (shu). |
| `sie.json` | Character Asset (Sierra) | Character profile asset for Sierra (sie). |
| `tai.json` | Character Asset (Tai Ho) | Character profile asset for Tai Ho (tai). |
| `tai_battle_00.json` | Character Battle Asset (Tai Ho) | Combat unit model and animation bindings for Tai Ho. |
| `tai_field_00.json` | Character Field Asset (Tai Ho) | Overworld field NPC configuration and sprite triggers for Tai Ho. |
| `ten.json` | Character Asset (Tengaar) | Character profile asset for Tengaar (ten). |
| `ten_battle_00.json` | Character Battle Asset (Tengaar) | Combat unit model and animation bindings for Tengaar. |
| `ten_field_00.json` | Character Field Asset (Tengaar) | Overworld field NPC configuration and sprite triggers for Tengaar. |

---

## <a id="suikoden-i-subsystems-legacy-assets"></a>Suikoden I Subsystems & Legacy Assets

Total assets in subsystem: **66**

### <a id="core-engine-shaders-credits-g1_-gs1"></a>Core Engine, Shaders & Credits (`g1_*`, `GS1*`) (7 files)

| File Name | Subsystem / Type | Technical Role & Grounded Description |
|---|---|---|
| `CREDITS_GSD1.json` | Suikoden I Credits Data | Stores complete staff roll credits hierarchy, department headers, and logo texture paths for Suikoden I. |
| `GS1.json` | Engine / Game Asset | Asset file storing serialized component state for `GS1` (keys: m_Script, m_Name, m_Version, m_AnimClip). |
| `GSD1LangTextSetter.json` | Engine / Game Asset | Asset file storing serialized component state for `GSD1LangTextSetter` (keys: m_Script, m_Name, textMP, id). |
| `GSD1TreeSpriteScript.json` | Engine / Game Asset | Asset file storing serialized component state for `GSD1TreeSpriteScript` (keys: m_Script, m_Name, maskTex, windRate). |
| `GSD1TreeWindCtrl.json` | Engine / Game Asset | Asset file storing serialized component state for `GSD1TreeWindCtrl` (keys: m_Script, m_Name, strongWindEffect, windPower). |
| `HDCREDITS_GSD1.json` | Suikoden I Credits Data | Stores complete staff roll credits hierarchy, department headers, and logo texture paths for Suikoden I (HD Edition). |
| `g1_main.json` | Engine / Game Asset | Asset file storing serialized component state for `g1_main` (keys: m_Script, m_Name, face64_kazu, face128_kazu). |

### <a id="one-on-one-duel-subsystem-pan_teo"></a>One-on-One Duel Subsystem (`pan_teo*`) (7 files)

| File Name | Subsystem / Type | Technical Role & Grounded Description |
|---|---|---|
| `pan_battle_00.json` | Engine / Game Asset | Asset file storing serialized component state for `pan_battle_00` (keys: m_Script, m_Name, id, path). |
| `pan_field_00.json` | Engine / Game Asset | Asset file storing serialized component state for `pan_field_00` (keys: m_Script, m_Name, id, path). |
| `pan_teo.json` | Engine / Game Asset | Asset file storing serialized component state for `pan_teo` (keys: m_Script, m_Name, anime_table, field). |
| `pan_teo_00.json` | Engine / Game Asset | Asset file storing serialized component state for `pan_teo_00` (keys: m_Script, m_Name, id, path). |
| `pan_teo_01.json` | Engine / Game Asset | Asset file storing serialized component state for `pan_teo_01` (keys: m_Script, m_Name, id, path). |
| `pan_teo_field.json` | Engine / Game Asset | Asset file storing serialized component state for `pan_teo_field` (keys: m_Script, m_Name, id, jimen_data). |
| `pan_teo_field_srn.json` | Engine / Game Asset | Asset file storing serialized component state for `pan_teo_field_srn` (keys: m_Script, m_Name, id, sprite_name). |

### <a id="tactical-war-battles-war_"></a>Tactical War Battles (`war_*`) (52 files)

| File Name | Subsystem / Type | Technical Role & Grounded Description |
|---|---|---|
| `war_01.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_01_00.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_01_01.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_01_02.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_01_03.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_01_04.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_01_05.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_01_06.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_01_07.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_01_08.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_01_09.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_01_10.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_01_11.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_01_12.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_01_13.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_01_14.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_01_15.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_01_16.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_01_17.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_01_18.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_02.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_03.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_04.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_05.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_06.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_07.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_08.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_09.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_10.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_11.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_12.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_13.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_14.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_15.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_16.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_gara.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_gara_00.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_gara_01.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_gara_02.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_gara_03.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_gara_04.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_gara_05.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_gara_06.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_gara_07.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_kita.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_kuwa.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_last.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_sca1.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_sca2.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_shas.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_teo1.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |
| `war_teo2.json` | Map Sub-Asset (WA) | Map background layer / 3D prop configuration for `war_` (World Map Region A). |

---

## <a id="user-interface-menu-subsystems"></a>User Interface & Menu Subsystems

Total assets in subsystem: **87**

### <a id="ui-menus-battle-huds-save-windows-dialogue-backlog"></a>UI Menus, Battle HUDs, Save Windows & Dialogue Backlog (87 files)

| File Name | Subsystem / Type | Technical Role & Grounded Description |
|---|---|---|
| `AddLangTextSetter.json` | UI Localization | Suikoden HD runtime text setter linking a TextMeshPro component to a localized text ID (`id: 791`). |
| `BackLogListItem.json` | Dialogue Backlog UI | UI prefab script managing individual lines in dialogue history (character speaker name, dialogue text, choice selection). |
| `BackLogPanel.json` | Dialogue Backlog UI | Master dialogue history backlog panel controller handling display toggling, scrolling layout, and animation. |
| `CharacterDetailSetter.json` | Status Window UI | Populates character profile window elements: face portrait image, character name text, and stat block panels. |
| `CharacterInfoSetter.json` | Menu Party UI | Sets summary party slot data across menus: face icon, level, and character name. |
| `UIBaseSlateSet.json` | Suikoden UI Window | Suikoden HD UI component/window controller for `UIBaseSlateSet`. |
| `UIBattle.json` | Battle HUD Subsystem | Combat battle interface component managing battle actions, player stats, targeting, or results (`UIBattle`). |
| `UIBattleDamage.json` | Battle HUD Subsystem | Combat battle interface component managing battle actions, player stats, targeting, or results (`UIBattleDamage`). |
| `UIBattleDialog.json` | Battle HUD Subsystem | Combat battle interface component managing battle actions, player stats, targeting, or results (`UIBattleDialog`). |
| `UIBattleMain.json` | Battle HUD Subsystem | Combat battle interface component managing battle actions, player stats, targeting, or results (`UIBattleMain`). |
| `UIBattleMarker.json` | Battle HUD Subsystem | Combat battle interface component managing battle actions, player stats, targeting, or results (`UIBattleMarker`). |
| `UIBattlePlayerStatus.json` | Battle HUD Subsystem | Combat battle interface component managing battle actions, player stats, targeting, or results (`UIBattlePlayerStatus`). |
| `UIBattleResult.json` | Battle HUD Subsystem | Combat battle interface component managing battle actions, player stats, targeting, or results (`UIBattleResult`). |
| `UIBattleResultCharacter.json` | Battle HUD Subsystem | Combat battle interface component managing battle actions, player stats, targeting, or results (`UIBattleResultCharacter`). |
| `UIBattleResultMain.json` | Battle HUD Subsystem | Combat battle interface component managing battle actions, player stats, targeting, or results (`UIBattleResultMain`). |
| `UIBattleStatusAilment.json` | Battle HUD Subsystem | Combat battle interface component managing battle actions, player stats, targeting, or results (`UIBattleStatusAilment`). |
| `UIBattleWindowMonster.json` | Battle HUD Subsystem | Combat battle interface component managing battle actions, player stats, targeting, or results (`UIBattleWindowMonster`). |
| `UIBattleWindowParty.json` | Battle HUD Subsystem | Combat battle interface component managing battle actions, player stats, targeting, or results (`UIBattleWindowParty`). |
| `UIButtonComponent.json` | Suikoden UI Window | Suikoden HD UI component/window controller for `UIButtonComponent`. |
| `UICoinText.json` | Suikoden UI Window | Suikoden HD UI component/window controller for `UICoinText`. |
| `UIConfig2Window.json` | Config / Settings UI | Options & configuration menu controller managing sound, graphics, controls, and language (`UIConfig2Window`). |
| `UIConfig2WindowItem.json` | Config / Settings UI | Options & configuration menu controller managing sound, graphics, controls, and language (`UIConfig2WindowItem`). |
| `UIConfigController.json` | Config / Settings UI | Options & configuration menu controller managing sound, graphics, controls, and language (`UIConfigController`). |
| `UIConfigTitle.json` | Config / Settings UI | Options & configuration menu controller managing sound, graphics, controls, and language (`UIConfigTitle`). |
| `UIConfigWindow.json` | Config / Settings UI | Options & configuration menu controller managing sound, graphics, controls, and language (`UIConfigWindow`). |
| `UICreditsRoll.json` | Suikoden UI Window | Suikoden HD UI component/window controller for `UICreditsRoll`. |
| `UIDialog.json` | Suikoden UI Window | Suikoden HD UI component/window controller for `UIDialog`. |
| `UIFontBehabiour.json` | Suikoden UI Window | Suikoden HD UI component/window controller for `UIFontBehabiour`. |
| `UIGallery01.json` | Gallery / Extras UI | Bonus gallery interface controller for artwork, sound jukebox, and cutscene player (`UIGallery01`). |
| `UIGallery02.json` | Gallery / Extras UI | Bonus gallery interface controller for artwork, sound jukebox, and cutscene player (`UIGallery02`). |
| `UIGalleryMvSet.json` | Gallery / Extras UI | Bonus gallery interface controller for artwork, sound jukebox, and cutscene player (`UIGalleryMvSet`). |
| `UIGallerySoundList.json` | Gallery / Extras UI | Bonus gallery interface controller for artwork, sound jukebox, and cutscene player (`UIGallerySoundList`). |
| `UIGalleryTop01.json` | Gallery / Extras UI | Bonus gallery interface controller for artwork, sound jukebox, and cutscene player (`UIGalleryTop01`). |
| `UIHDCreditsRoll.json` | Suikoden UI Window | Suikoden HD UI component/window controller for `UIHDCreditsRoll`. |
| `UIHealthWindow.json` | Suikoden UI Window | Suikoden HD UI component/window controller for `UIHealthWindow`. |
| `UIKikoriEffect.json` | Suikoden UI Window | Suikoden HD UI component/window controller for `UIKikoriEffect`. |
| `UILicense.json` | Suikoden UI Window | Suikoden HD UI component/window controller for `UILicense`. |
| `UIMainCompanionMenu.json` | Main Menu Subsystem | Main menu interface component managing inventory, formation, equip, runes, or companion status (`UIMainCompanionMenu`). |
| `UIMainEmblemMenu.json` | Main Menu Subsystem | Main menu interface component managing inventory, formation, equip, runes, or companion status (`UIMainEmblemMenu`). |
| `UIMainEquipMenu.json` | Main Menu Subsystem | Main menu interface component managing inventory, formation, equip, runes, or companion status (`UIMainEquipMenu`). |
| `UIMainFormationMenu.json` | Main Menu Subsystem | Main menu interface component managing inventory, formation, equip, runes, or companion status (`UIMainFormationMenu`). |
| `UIMainItemMenu.json` | Main Menu Subsystem | Main menu interface component managing inventory, formation, equip, runes, or companion status (`UIMainItemMenu`). |
| `UIMainMenu.json` | Main Menu Subsystem | Main menu interface component managing inventory, formation, equip, runes, or companion status (`UIMainMenu`). |
| `UIMainMenuCommon.json` | Main Menu Subsystem | Main menu interface component managing inventory, formation, equip, runes, or companion status (`UIMainMenuCommon`). |
| `UIMainMenuFormationOPDChara.json` | Main Menu Subsystem | Main menu interface component managing inventory, formation, equip, runes, or companion status (`UIMainMenuFormationOPDChara`). |
| `UIMainMenuPartyList.json` | Main Menu Subsystem | Main menu interface component managing inventory, formation, equip, runes, or companion status (`UIMainMenuPartyList`). |
| `UIMainMenuPartyListItem.json` | Main Menu Subsystem | Main menu interface component managing inventory, formation, equip, runes, or companion status (`UIMainMenuPartyListItem`). |
| `UIMainMenuTips.json` | Main Menu Subsystem | Main menu interface component managing inventory, formation, equip, runes, or companion status (`UIMainMenuTips`). |
| `UIMainStrengthMenu.json` | Main Menu Subsystem | Main menu interface component managing inventory, formation, equip, runes, or companion status (`UIMainStrengthMenu`). |
| `UIManual.json` | Suikoden UI Window | Suikoden HD UI component/window controller for `UIManual`. |
| `UIManualButton.json` | Suikoden UI Window | Suikoden HD UI component/window controller for `UIManualButton`. |
| `UIMenuWindow.json` | Suikoden UI Window | Suikoden HD UI component/window controller for `UIMenuWindow`. |
| `UIMessageWindow.json` | Suikoden UI Window | Suikoden HD UI component/window controller for `UIMessageWindow`. |
| `UIMoguraHeader.json` | Suikoden UI Window | Suikoden HD UI component/window controller for `UIMoguraHeader`. |
| `UIMoneyWindow.json` | Suikoden UI Window | Suikoden HD UI component/window controller for `UIMoneyWindow`. |
| `UIPartyEntry.json` | Suikoden UI Window | Suikoden HD UI component/window controller for `UIPartyEntry`. |
| `UISaveLoad1.json` | Save/Load Subsystem | Save & load memory card interface component managing save slots, dialogs, and metadata (`UISaveLoad1`). |
| `UISaveLoad2.json` | Save/Load Subsystem | Save & load memory card interface component managing save slots, dialogs, and metadata (`UISaveLoad2`). |
| `UISaveLoadSlot.json` | Save/Load Subsystem | Save & load memory card interface component managing save slots, dialogs, and metadata (`UISaveLoadSlot`). |
| `UISelectCursor.json` | Suikoden UI Window | Suikoden HD UI component/window controller for `UISelectCursor`. |
| `UISelectMenu.json` | Suikoden UI Window | Suikoden HD UI component/window controller for `UISelectMenu`. |
| `UISoundList01.json` | Suikoden UI Window | Suikoden HD UI component/window controller for `UISoundList01`. |
| `UIStatusWindow.json` | Suikoden UI Window | Suikoden HD UI component/window controller for `UIStatusWindow`. |
| `UIStorage.json` | Suikoden UI Window | Suikoden HD UI component/window controller for `UIStorage`. |
| `UIStorageWindow.json` | Suikoden UI Window | Suikoden HD UI component/window controller for `UIStorageWindow`. |
| `UIStuffrollHD.json` | Suikoden UI Window | Suikoden HD UI component/window controller for `UIStuffrollHD`. |
| `UISummary.json` | Suikoden UI Window | Suikoden HD UI component/window controller for `UISummary`. |
| `UISystemDialog.json` | Suikoden UI Window | Suikoden HD UI component/window controller for `UISystemDialog`. |
| `UISystemEDChara.json` | Suikoden UI Window | Suikoden HD UI component/window controller for `UISystemEDChara`. |
| `UISystemInputName.json` | Suikoden UI Window | Suikoden HD UI component/window controller for `UISystemInputName`. |
| `UISystemInputName_cell.json` | Suikoden UI Window | Suikoden HD UI component/window controller for `UISystemInputName_cell`. |
| `UISystemInputName_editor.json` | Suikoden UI Window | Suikoden HD UI component/window controller for `UISystemInputName_editor`. |
| `UISystemLogo.json` | Suikoden UI Window | Suikoden HD UI component/window controller for `UISystemLogo`. |
| `UITips.json` | Suikoden UI Window | Suikoden HD UI component/window controller for `UITips`. |
| `UITipsOperationContent.json` | Suikoden UI Window | Suikoden HD UI component/window controller for `UITipsOperationContent`. |
| `UIUnitStatus.json` | Suikoden UI Window | Suikoden HD UI component/window controller for `UIUnitStatus`. |
| `UIWindow.json` | Suikoden UI Window | Suikoden HD UI component/window controller for `UIWindow`. |
| `UIWindowBoxLine.json` | Suikoden UI Window | Suikoden HD UI component/window controller for `UIWindowBoxLine`. |
| `UIWindowBoxTile.json` | Suikoden UI Window | Suikoden HD UI component/window controller for `UIWindowBoxTile`. |
| `UIWindowList.json` | Suikoden UI Window | Suikoden HD UI component/window controller for `UIWindowList`. |
| `UIWindowListCell.json` | Suikoden UI Window | Suikoden HD UI component/window controller for `UIWindowListCell`. |
| `UIWindowListTop.json` | Suikoden UI Window | Suikoden HD UI component/window controller for `UIWindowListTop`. |
| `UIWindowMonitor.json` | Suikoden UI Window | Suikoden HD UI component/window controller for `UIWindowMonitor`. |
| `UI_System_InputName_Cursor.json` | Suikoden UI Window | Suikoden HD UI component/window controller for `UI_System_InputName_Cursor`. |
| `UI_Title_Post_process.json` | Suikoden UI Window | Suikoden HD UI component/window controller for `UI_Title_Post_process`. |
| `UI_Title_menu_corsor_Timeline.json` | Timeline Asset | Cinematic / Timeline asset controlling animation sequence `UI_Title_menu_corsor_Timeline`. |
| `UI_Title_menu_word_Timeline.json` | Timeline Asset | Cinematic / Timeline asset controlling animation sequence `UI_Title_menu_word_Timeline`. |

---

## <a id="audio-criware-sound-infrastructure"></a>Audio & CRIWARE Sound Infrastructure

Total assets in subsystem: **7**

### <a id="criware-emitters-sound-triggers-attenuation"></a>CRIWARE Emitters, Sound Triggers & Attenuation (7 files)

| File Name | Subsystem / Type | Technical Role & Grounded Description |
|---|---|---|
| `CriAtomSource.json` | CRIWARE Audio Component | CRIWARE audio playback emitter component for 2D/3D in-game sound. |
| `CriAtomSourceControll.json` | CRIWARE Audio Component | Controls 3D audio attenuation distances and radius for CRI Atom sound sources. |
| `CriAtomSourceOn2D.json` | CRIWARE Audio Component | Maps 3D audio cues to 2D UI coordinates. |
| `CriObjManager.json` | CRIWARE Audio Component | Lifecycle manager component for CRI audio objects. |
| `SE_GS2.json` | CRIWARE Audio Component | CRIWARE audio sound effect trigger/config asset for `SE_GS2`. |
| `f_se_pita.json` | CRIWARE Audio Component | CRIWARE audio sound effect trigger/config asset for `f_se_pita`. |
| `f_se_pota.json` | CRIWARE Audio Component | CRIWARE audio sound effect trigger/config asset for `f_se_pota`. |

---

## <a id="cinematics-vfx-timelines"></a>Cinematics, VFX & Timelines

Total assets in subsystem: **37**

### <a id="cinematic-tracks-spell-timelines-particle-vfx"></a>Cinematic Tracks, Spell Timelines & Particle VFX (37 files)

| File Name | Subsystem / Type | Technical Role & Grounded Description |
|---|---|---|
| `Action.json` | Timeline Asset | Cinematic / Timeline asset controlling animation sequence `Action`. |
| `Activation Track.json` | Timeline Track | Unity Timeline track asset (`Activation Track`) controlling track clips, mute states, and animation tracks. |
| `Animation Track (2).json` | Timeline Track | Unity Timeline track asset (`Animation Track (2)`) controlling track clips, mute states, and animation tracks. |
| `Animation Track.json` | Timeline Track | Unity Timeline track asset (`Animation Track`) controlling track clips, mute states, and animation tracks. |
| `BG_Cloud_Para_01.json` | Environment Timeline | Timeline asset animating background parallax cloud scrolling layer 01. |
| `BattleEffectTimelineController.json` | Combat Cinematic Director | Controls battle visual effect timelines, syncing camera moves and particle VFX to PlayableDirectors. |
| `Control Track (1).json` | Timeline Track | Unity Timeline track asset (`Control Track (1)`) controlling track clips, mute states, and animation tracks. |
| `Control Track (10).json` | Timeline Track | Unity Timeline track asset (`Control Track (10)`) controlling track clips, mute states, and animation tracks. |
| `Control Track (11).json` | Timeline Track | Unity Timeline track asset (`Control Track (11)`) controlling track clips, mute states, and animation tracks. |
| `Control Track (12).json` | Timeline Track | Unity Timeline track asset (`Control Track (12)`) controlling track clips, mute states, and animation tracks. |
| `Control Track (14).json` | Timeline Track | Unity Timeline track asset (`Control Track (14)`) controlling track clips, mute states, and animation tracks. |
| `Control Track (19).json` | Timeline Track | Unity Timeline track asset (`Control Track (19)`) controlling track clips, mute states, and animation tracks. |
| `Control Track (2).json` | Timeline Track | Unity Timeline track asset (`Control Track (2)`) controlling track clips, mute states, and animation tracks. |
| `Control Track (20).json` | Timeline Track | Unity Timeline track asset (`Control Track (20)`) controlling track clips, mute states, and animation tracks. |
| `Control Track (4).json` | Timeline Track | Unity Timeline track asset (`Control Track (4)`) controlling track clips, mute states, and animation tracks. |
| `Control Track (5).json` | Timeline Track | Unity Timeline track asset (`Control Track (5)`) controlling track clips, mute states, and animation tracks. |
| `Control Track (6).json` | Timeline Track | Unity Timeline track asset (`Control Track (6)`) controlling track clips, mute states, and animation tracks. |
| `Control Track (7).json` | Timeline Track | Unity Timeline track asset (`Control Track (7)`) controlling track clips, mute states, and animation tracks. |
| `Control Track (9).json` | Timeline Track | Unity Timeline track asset (`Control Track (9)`) controlling track clips, mute states, and animation tracks. |
| `Control Track.json` | Timeline Track | Unity Timeline track asset (`Control Track`) controlling track clips, mute states, and animation tracks. |
| `ControlPlayableAsset.json` | Timeline Playable Asset | Playable asset used within Control Tracks to spawn and control child prefabs or particle systems. |
| `Cursor.json` | Timeline Asset | Cinematic / Timeline asset controlling animation sequence `Cursor`. |
| `EFF_Dungeon_66_06.json` | VFX Timeline Asset | Combat / VFX visual effect timeline animation asset for effect `EFF_Dungeon_66_06`. |
| `EFF_Dungeon_66_07.json` | VFX Timeline Asset | Combat / VFX visual effect timeline animation asset for effect `EFF_Dungeon_66_07`. |
| `EFF_GSD2_battle_04_Timeline.json` | VFX Timeline Asset | Combat / VFX visual effect timeline animation asset for effect `EFF_GSD2_battle_04_Timeline`. |
| `EM2_B12_06_Timeline.json` | Event Cinematic Timeline | Suikoden II event/monster cinematic cutscene timeline asset for sequence `EM2_B12_06_Timeline`. |
| `Effect.json` | Timeline Asset | Cinematic / Timeline asset controlling animation sequence `Effect`. |
| `Label Track.json` | Timeline Track | Unity Timeline track asset (`Label Track`) controlling track clips, mute states, and animation tracks. |
| `M_GATE3_00_01_Timeline_hit.json` | Timeline Asset | Cinematic / Timeline asset controlling animation sequence `M_GATE3_00_01_Timeline_hit`. |
| `M_GATE3_00_01_Timeline_root.json` | Timeline Asset | Cinematic / Timeline asset controlling animation sequence `M_GATE3_00_01_Timeline_root`. |
| `M_GATE4_00_monster_Timeline_01.json` | Timeline Asset | Cinematic / Timeline asset controlling animation sequence `M_GATE4_00_monster_Timeline_01`. |
| `M_SHIELD2_00_Timeline.json` | Timeline Asset | Cinematic / Timeline asset controlling animation sequence `M_SHIELD2_00_Timeline`. |
| `M_SWORD2_00_Timeline.json` | Timeline Asset | Cinematic / Timeline asset controlling animation sequence `M_SWORD2_00_Timeline`. |
| `Playable Track.json` | Timeline Track | Unity Timeline track asset (`Playable Track`) controlling track clips, mute states, and animation tracks. |
| `SeTimeline.json` | Timeline Asset | Cinematic / Timeline asset controlling animation sequence `SeTimeline`. |
| `Signal Track.json` | Timeline Track | Unity Timeline track asset (`Signal Track`) controlling track clips, mute states, and animation tracks. |
| `TL_M_FIRE5_00.json` | Spell / Skill Timeline | Timeline sequence for magic/skill cast `TL_M_FIRE5_00`. |

---

## <a id="top-level-launcher-hub-assets"></a>Top-Level Launcher Hub Assets

Total assets in subsystem: **8**

### <a id="launcher-hub-assets"></a>Launcher Hub Assets (8 files)

| File Name | Subsystem / Type | Technical Role & Grounded Description |
|---|---|---|
| `Launcher_Root_3d_bg_Timeline.json` | Timeline Asset | Cinematic / Timeline asset controlling animation sequence `Launcher_Root_3d_bg_Timeline`. |
| `Launcher_header_Timeline.json` | Timeline Asset | Cinematic / Timeline asset controlling animation sequence `Launcher_header_Timeline`. |
| `Launcher_menu_gallery_Timeline.json` | Timeline Asset | Cinematic / Timeline asset controlling animation sequence `Launcher_menu_gallery_Timeline`. |
| `Launcher_menu_group_Timeline.json` | Timeline Asset | Cinematic / Timeline asset controlling animation sequence `Launcher_menu_group_Timeline`. |
| `Launcher_menu_gs1_gs2_Timeline.json` | Timeline Asset | Cinematic / Timeline asset controlling animation sequence `Launcher_menu_gs1_gs2_Timeline`. |
| `Launcher_menu_setting_Timeline.json` | Timeline Asset | Cinematic / Timeline asset controlling animation sequence `Launcher_menu_setting_Timeline`. |
| `Launcher_menu_title_Timeline.json` | Timeline Asset | Cinematic / Timeline asset controlling animation sequence `Launcher_menu_title_Timeline`. |
| `Launcher_title_enter_efc_Timeline.json` | Timeline Asset | Cinematic / Timeline asset controlling animation sequence `Launcher_title_enter_efc_Timeline`. |

---

## <a id="engine-framework-shaders-shared-assets"></a>Engine Framework, Shaders & Shared Assets

Total assets in subsystem: **982**

### <a id="unity-engine-components-tmp-fonts-post-processing"></a>Unity Engine Components, TMP Fonts & Post-Processing (982 files)

| File Name | Subsystem / Type | Technical Role & Grounded Description |
|---|---|---|
| `BackGroundProfile.json` | Engine / Game Asset | Asset file storing serialized component state for `BackGroundProfile` (keys: m_Script, m_Name, settings). |
| `BindCamera.json` | Camera Controller | Binds the rendering camera to target transforms and synchronizes field startup coordinates. |
| `Button.json` | Unity UI Engine Component | Standard Unity UI `Button` component serialized parameters. |
| `CALLYB__ SDF.json` | TextMeshPro Font Asset | Signed Distance Field (SDF) glyph atlas and typography metrics asset for font `CALLYB__`. |
| `CREDITS_GSD2.json` | Suikoden II Credits Data | Stores complete staff roll credits hierarchy, department headers, and logo texture paths for Suikoden II. |
| `ColorGrading.json` | Post-Processing Effect | Post-processing Color Grading profile setting active grading mode, tonemapping, and color balance. |
| `ConstraintCameraBinder.json` | Camera Controller | Constrains camera viewport bounds relative to target gameobjects or field boundaries. |
| `ContentSizeFitter.json` | Unity UI Engine Component | Standard Unity UI `ContentSizeFitter` component serialized parameters. |
| `DFGB_S7 SDF.json` | TextMeshPro Font Asset | Signed Distance Field (SDF) glyph atlas and typography metrics asset for font `DFGB_S7`. |
| `DFT_M7 SDF.json` | TextMeshPro Font Asset | Signed Distance Field (SDF) glyph atlas and typography metrics asset for font `DFT_M7`. |
| `DOTweenAnimation.json` | Tween Animation Utility | Demigiant DOTween visual component managing procedural UI / transform tween animations. |
| `DOTweenVisualManager.json` | Tween Animation Utility | Demigiant DOTween visual component managing procedural UI / transform tween animations. |
| `EffectProfile.json` | Engine / Game Asset | Asset file storing serialized component state for `EffectProfile` (keys: m_Script, m_Name, settings). |
| `FontColorSetter.json` | Engine / Game Asset | Asset file storing serialized component state for `FontColorSetter` (keys: m_Script, m_Name, color, textMP). |
| `GSD2LangTextSetter.json` | Engine / Game Asset | Asset file storing serialized component state for `GSD2LangTextSetter` (keys: m_Script, m_Name, textMP, id). |
| `GridLayoutGroup.json` | Unity UI Engine Component | Standard Unity UI `GridLayoutGroup` component serialized parameters. |
| `HDCREDITS_GSD2.json` | Suikoden II Credits Data | Stores complete staff roll credits hierarchy, department headers, and logo texture paths for Suikoden II (HD Edition). |
| `HDFuroEffectManager.json` | Engine / Game Asset | Asset file storing serialized component state for `HDFuroEffectManager` (keys: m_Script, m_Name, peeObject, flashObject). |
| `HorizontalLayoutGroup.json` | Unity UI Engine Component | Standard Unity UI `HorizontalLayoutGroup` component serialized parameters. |
| `IkkiFieldComponent.json` | Engine / Game Asset | Asset file storing serialized component state for `IkkiFieldComponent` (keys: m_Script, m_Name, FieldCamera, BGCamera). |
| `IkkiHDAttackPatternIcon.json` | Engine / Game Asset | Asset file storing serialized component state for `IkkiHDAttackPatternIcon` (keys: m_Script, m_Name, advantagesMark, disadvantagesMark). |
| `IkkiHDCommandWindow.json` | Engine / Game Asset | Asset file storing serialized component state for `IkkiHDCommandWindow` (keys: m_Script, m_Name, texts, face). |
| `IkkiHDUIComponent.json` | Engine / Game Asset | Asset file storing serialized component state for `IkkiHDUIComponent` (keys: m_Script, m_Name, gaugeUI, hpImageR). |
| `IkkiHDWindow.json` | Engine / Game Asset | Asset file storing serialized component state for `IkkiHDWindow` (keys: m_Script, m_Name, texts, face). |
| `Image.json` | Unity UI Engine Component | Standard Unity UI `Image` component serialized parameters. |
| `ImageColorSetter.json` | Engine / Game Asset | Asset file storing serialized component state for `ImageColorSetter` (keys: m_Script, m_Name, color, m_image). |
| `KarutaPanel.json` | Engine / Game Asset | Asset file storing serialized component state for `KarutaPanel` (keys: m_Script, m_Name, Cards, Yubi). |
| `LabelPlayableAsset(Clone)(Clone)(Clone)(Clone)(Clone)(Clone)(Clone)(Clone).json` | Engine / Game Asset | Asset file storing serialized component state for `LabelPlayableAsset(Clone)(Clone)(Clone)(Clone)(Clone)(Clone)(Clone)(Clone)` (keys: m_Script, m_Name, m_label). |
| `LabelPlayableAsset(Clone)(Clone)(Clone)(Clone)(Clone)(Clone)(Clone).json` | Engine / Game Asset | Asset file storing serialized component state for `LabelPlayableAsset(Clone)(Clone)(Clone)(Clone)(Clone)(Clone)(Clone)` (keys: m_Script, m_Name, m_label). |
| `LabelPlayableAsset(Clone)(Clone)(Clone)(Clone)(Clone)(Clone).json` | Engine / Game Asset | Asset file storing serialized component state for `LabelPlayableAsset(Clone)(Clone)(Clone)(Clone)(Clone)(Clone)` (keys: m_Script, m_Name, m_label). |
| `LabelPlayableAsset(Clone)(Clone)(Clone)(Clone)(Clone).json` | Engine / Game Asset | Asset file storing serialized component state for `LabelPlayableAsset(Clone)(Clone)(Clone)(Clone)(Clone)` (keys: m_Script, m_Name, m_label). |
| `LabelPlayableAsset(Clone)(Clone)(Clone)(Clone).json` | Engine / Game Asset | Asset file storing serialized component state for `LabelPlayableAsset(Clone)(Clone)(Clone)(Clone)` (keys: m_Script, m_Name, m_label). |
| `Launcer_Post_process.json` | Engine / Game Asset | Asset file storing serialized component state for `Launcer_Post_process` (keys: m_Script, m_Name, settings). |
| `LayoutElement.json` | Engine / Game Asset | Asset file storing serialized component state for `LayoutElement` (keys: m_Script, m_Name, m_IgnoreLayout, m_MinWidth). |
| `M_GRI3_00.json` | Engine / Game Asset | Asset file storing serialized component state for `M_GRI3_00` (keys: m_Script, m_Name, m_Version, m_Tracks). |
| `MapBGColorHD.json` | HD Map Engine Object | HD map engine utility component managing environmental sprites, animated tiles, or footstep surface audio (`MapBGColorHD`). |
| `MapBGScroll.json` | HD Map Engine Object | HD map engine utility component managing environmental sprites, animated tiles, or footstep surface audio (`MapBGScroll`). |
| `MapCovermaskHD.json` | HD Map Engine Object | HD map engine utility component managing environmental sprites, animated tiles, or footstep surface audio (`MapCovermaskHD`). |
| `MapEventObjectHD.json` | HD Map Engine Object | HD map engine utility component managing environmental sprites, animated tiles, or footstep surface audio (`MapEventObjectHD`). |
| `MapFlagCheckObjectHD.json` | HD Map Engine Object | HD map engine utility component managing environmental sprites, animated tiles, or footstep surface audio (`MapFlagCheckObjectHD`). |
| `MapFootSound.json` | HD Map Engine Object | HD map engine utility component managing environmental sprites, animated tiles, or footstep surface audio (`MapFootSound`). |
| `MapInfoHD.json` | HD Map Engine Object | HD map engine utility component managing environmental sprites, animated tiles, or footstep surface audio (`MapInfoHD`). |
| `MapObjAnimHD.json` | HD Map Engine Object | HD map engine utility component managing environmental sprites, animated tiles, or footstep surface audio (`MapObjAnimHD`). |
| `MapObjAnimHD_Auto.json` | HD Map Engine Object | HD map engine utility component managing environmental sprites, animated tiles, or footstep surface audio (`MapObjAnimHD_Auto`). |
| `MapObjSwapHD.json` | HD Map Engine Object | HD map engine utility component managing environmental sprites, animated tiles, or footstep surface audio (`MapObjSwapHD`). |
| `MapRandomAnimation.json` | HD Map Engine Object | HD map engine utility component managing environmental sprites, animated tiles, or footstep surface audio (`MapRandomAnimation`). |
| `MapRotObj.json` | HD Map Engine Object | HD map engine utility component managing environmental sprites, animated tiles, or footstep surface audio (`MapRotObj`). |
| `MapRotObjManager.json` | HD Map Engine Object | HD map engine utility component managing environmental sprites, animated tiles, or footstep surface audio (`MapRotObjManager`). |
| `MapSpriteHD.json` | HD Map Engine Object | HD map engine utility component managing environmental sprites, animated tiles, or footstep surface audio (`MapSpriteHD`). |
| `MapVerticalScroll.json` | HD Map Engine Object | HD map engine utility component managing environmental sprites, animated tiles, or footstep surface audio (`MapVerticalScroll`). |
| `Markers.json` | Engine / Game Asset | Asset file storing serialized component state for `Markers` (keys: m_Script, m_Name, m_Version, m_AnimClip). |
| `Mask.json` | Unity UI Engine Component | Standard Unity UI `Mask` component serialized parameters. |
| `MeshSortingOrder.json` | Engine / Game Asset | Asset file storing serialized component state for `MeshSortingOrder` (keys: m_Script, m_Name, sortingOrder). |
| `MiniMapDataCmp.json` | Engine / Game Asset | Asset file storing serialized component state for `MiniMapDataCmp` (keys: m_Script, m_Name, dataList, customRectList). |
| `MiniMapDataReplace.json` | Engine / Game Asset | Asset file storing serialized component state for `MiniMapDataReplace` (keys: m_Script, m_Name, m_target, m_default). |
| `MiniMapPanel.json` | Engine / Game Asset | Asset file storing serialized component state for `MiniMapPanel` (keys: m_Script, m_Name, AnimObject2, WholeMapObject). |
| `MinigameControllerButton.json` | Engine / Game Asset | Asset file storing serialized component state for `MinigameControllerButton` (keys: m_Script, m_Name, leftButtons, leftButtonSprites). |
| `MoguraBG.json` | Engine / Game Asset | Asset file storing serialized component state for `MoguraBG` (keys: m_Script, m_Name, holl, groundTrans). |
| `NotoSerifJP-Bold SDF.json` | TextMeshPro Font Asset | Signed Distance Field (SDF) glyph atlas and typography metrics asset for font `NotoSerifJP-Bold`. |
| `ObjectActivator.json` | Engine / Game Asset | Asset file storing serialized component state for `ObjectActivator` (keys: m_Script, m_Name, m_sceneName, m_value). |
| `ObjectLayerChanger.json` | Engine / Game Asset | Asset file storing serialized component state for `ObjectLayerChanger` (keys: m_Script, m_Name). |
| `OptimizeScrollContent.json` | Engine / Game Asset | Asset file storing serialized component state for `OptimizeScrollContent` (keys: m_Script, m_Name, m_listItemBase, m_instantateItemCount). |
| `Outline.json` | Unity UI Engine Component | Standard Unity UI `Outline` component serialized parameters. |
| `PostProcessEffectManager.json` | Post-Processing Profile | Unity Post-Processing Stack profile managing bloom, vignette, color grading, and ambient occlusion (`PostProcessEffectManager`). |
| `PostProcessManager.json` | Post-Processing Profile | Unity Post-Processing Stack profile managing bloom, vignette, color grading, and ambient occlusion (`PostProcessManager`). |
| `PostProcessResources.json` | Post-Processing Profile | Unity Post-Processing Stack profile managing bloom, vignette, color grading, and ambient occlusion (`PostProcessResources`). |
| `PostProcessVolume Profile_gsd2_va07_00.json` | Post-Processing Profile | Unity Post-Processing Stack profile managing bloom, vignette, color grading, and ambient occlusion (`PostProcessVolume Profile_gsd2_va07_00`). |
| `PostProcessVolume Profile_gsd2_va08_00.json` | Post-Processing Profile | Unity Post-Processing Stack profile managing bloom, vignette, color grading, and ambient occlusion (`PostProcessVolume Profile_gsd2_va08_00`). |
| `PostProcessVolume Profile_gsd2_va24_00.json` | Post-Processing Profile | Unity Post-Processing Stack profile managing bloom, vignette, color grading, and ambient occlusion (`PostProcessVolume Profile_gsd2_va24_00`). |
| `PostProcessVolume Profile_gsd2_va26_00.json` | Post-Processing Profile | Unity Post-Processing Stack profile managing bloom, vignette, color grading, and ambient occlusion (`PostProcessVolume Profile_gsd2_va26_00`). |
| `PostProcessVolume Profile_gsd2_vb01_00.json` | Post-Processing Profile | Unity Post-Processing Stack profile managing bloom, vignette, color grading, and ambient occlusion (`PostProcessVolume Profile_gsd2_vb01_00`). |
| `PostProcessVolume Profile_gsd2_vc08_00.json` | Post-Processing Profile | Unity Post-Processing Stack profile managing bloom, vignette, color grading, and ambient occlusion (`PostProcessVolume Profile_gsd2_vc08_00`). |
| `PostProcessVolume Profile_gsd2_vd12_00.json` | Post-Processing Profile | Unity Post-Processing Stack profile managing bloom, vignette, color grading, and ambient occlusion (`PostProcessVolume Profile_gsd2_vd12_00`). |
| `PostProcessVolume Profile_gsd2_vd14_00.json` | Post-Processing Profile | Unity Post-Processing Stack profile managing bloom, vignette, color grading, and ambient occlusion (`PostProcessVolume Profile_gsd2_vd14_00`). |
| `PostProcessVolume Profile_gsd2_vg09_01.json` | Post-Processing Profile | Unity Post-Processing Stack profile managing bloom, vignette, color grading, and ambient occlusion (`PostProcessVolume Profile_gsd2_vg09_01`). |
| `PostProcessVolume Profile_gsd2_vg10_00.json` | Post-Processing Profile | Unity Post-Processing Stack profile managing bloom, vignette, color grading, and ambient occlusion (`PostProcessVolume Profile_gsd2_vg10_00`). |
| `PostProcessVolume Profile_gsd2_vh10_05.json` | Post-Processing Profile | Unity Post-Processing Stack profile managing bloom, vignette, color grading, and ambient occlusion (`PostProcessVolume Profile_gsd2_vh10_05`). |
| `PostProcessVolume Profile_gsd2_vi03_00.json` | Post-Processing Profile | Unity Post-Processing Stack profile managing bloom, vignette, color grading, and ambient occlusion (`PostProcessVolume Profile_gsd2_vi03_00`). |
| `PostProcessVolume Profile_gsd2_vj08_00.json` | Post-Processing Profile | Unity Post-Processing Stack profile managing bloom, vignette, color grading, and ambient occlusion (`PostProcessVolume Profile_gsd2_vj08_00`). |
| `PostProcessVolume Profile_gsd2_vj09_00.json` | Post-Processing Profile | Unity Post-Processing Stack profile managing bloom, vignette, color grading, and ambient occlusion (`PostProcessVolume Profile_gsd2_vj09_00`). |
| `PostProcessVolume Profile_gsd2_vj16_00.json` | Post-Processing Profile | Unity Post-Processing Stack profile managing bloom, vignette, color grading, and ambient occlusion (`PostProcessVolume Profile_gsd2_vj16_00`). |
| `PostProcessVolume Profile_gsd2_vk37_00_02.json` | Post-Processing Profile | Unity Post-Processing Stack profile managing bloom, vignette, color grading, and ambient occlusion (`PostProcessVolume Profile_gsd2_vk37_00_02`). |
| `PostProcessVolume Profile_va01_00b.json` | Post-Processing Profile | Unity Post-Processing Stack profile managing bloom, vignette, color grading, and ambient occlusion (`PostProcessVolume Profile_va01_00b`). |
| `PostProcessVolume Profile_vb06_00b.json` | Post-Processing Profile | Unity Post-Processing Stack profile managing bloom, vignette, color grading, and ambient occlusion (`PostProcessVolume Profile_vb06_00b`). |
| `PostProcessVolume Profile_vb15_00.json` | Post-Processing Profile | Unity Post-Processing Stack profile managing bloom, vignette, color grading, and ambient occlusion (`PostProcessVolume Profile_vb15_00`). |
| `PostProcessVolume Profile_vd04_00.json` | Post-Processing Profile | Unity Post-Processing Stack profile managing bloom, vignette, color grading, and ambient occlusion (`PostProcessVolume Profile_vd04_00`). |
| `PostProcessVolume Profile_vd08_00.json` | Post-Processing Profile | Unity Post-Processing Stack profile managing bloom, vignette, color grading, and ambient occlusion (`PostProcessVolume Profile_vd08_00`). |
| `PostProcessVolume Profile_ve02_00.json` | Post-Processing Profile | Unity Post-Processing Stack profile managing bloom, vignette, color grading, and ambient occlusion (`PostProcessVolume Profile_ve02_00`). |
| `PostProcessVolume Profile_vf01_00.json` | Post-Processing Profile | Unity Post-Processing Stack profile managing bloom, vignette, color grading, and ambient occlusion (`PostProcessVolume Profile_vf01_00`). |
| `PostProcessVolume Profile_war_kita.json` | Post-Processing Profile | Unity Post-Processing Stack profile managing bloom, vignette, color grading, and ambient occlusion (`PostProcessVolume Profile_war_kita`). |
| `PostProcessVolume Profile_war_teo2.json` | Post-Processing Profile | Unity Post-Processing Stack profile managing bloom, vignette, color grading, and ambient occlusion (`PostProcessVolume Profile_war_teo2`). |
| `PostProcessVolume.json` | Post-Processing Profile | Unity Post-Processing Stack profile managing bloom, vignette, color grading, and ambient occlusion (`PostProcessVolume`). |
| `RawImage.json` | Unity UI Engine Component | Standard Unity UI `RawImage` component serialized parameters. |
| `RectMask2D.json` | Unity UI Engine Component | Standard Unity UI `RectMask2D` component serialized parameters. |
| `ReleaseCheckCmp.json` | Engine / Game Asset | Asset file storing serialized component state for `ReleaseCheckCmp` (keys: m_Script, m_Name). |
| `ScreenScript.json` | Engine / Game Asset | Asset file storing serialized component state for `ScreenScript` (keys: m_Script, m_Name, wipe, maskTex). |
| `ScrollRect.json` | Unity UI Engine Component | Standard Unity UI `ScrollRect` component serialized parameters. |
| `Scrollbar.json` | Unity UI Engine Component | Standard Unity UI `Scrollbar` component serialized parameters. |
| `Shadow.json` | Unity UI Engine Component | Standard Unity UI `Shadow` component serialized parameters. |
| `SignalReceiver.json` | Engine / Game Asset | Asset file storing serialized component state for `SignalReceiver` (keys: m_Script, m_Name, m_Events). |
| `Slider.json` | Unity UI Engine Component | Standard Unity UI `Slider` component serialized parameters. |
| `StaffMemberAreaView.json` | Engine / Game Asset | Asset file storing serialized component state for `StaffMemberAreaView` (keys: m_Script, m_Name, RollText, MemberNameText). |
| `StaffOutlineAreaView.json` | Engine / Game Asset | Asset file storing serialized component state for `StaffOutlineAreaView` (keys: m_Script, m_Name, OutlineText). |
| `StaffSpaceAreaView.json` | Engine / Game Asset | Asset file storing serialized component state for `StaffSpaceAreaView` (keys: m_Script, m_Name, layoutElement). |
| `THU5_00.json` | Engine / Game Asset | Asset file storing serialized component state for `THU5_00` (keys: m_Script, m_Name, m_Version, m_Tracks). |
| `Text.json` | Unity UI Engine Component | Standard Unity UI `Text` component serialized parameters. |
| `TextMeshPro.json` | Unity UI Engine Component | Standard Unity UI `TextMeshPro` component serialized parameters. |
| `TextMeshProUGUI.json` | Unity UI Engine Component | Standard Unity UI `TextMeshProUGUI` component serialized parameters. |
| `Tmp.json` | Engine / Game Asset | Asset file storing serialized component state for `Tmp` (keys: m_Script, m_Name, m_Version, m_AnimClip). |
| `Toggle.json` | Unity UI Engine Component | Standard Unity UI `Toggle` component serialized parameters. |
| `ToggleGroup.json` | Unity UI Engine Component | Standard Unity UI `ToggleGroup` component serialized parameters. |
| `TreeShadowScript.json` | Engine / Game Asset | Asset file storing serialized component state for `TreeShadowScript` (keys: m_Script, m_Name, maskTex, noiseTileOffset1). |
| `TreeSpriteScript.json` | Engine / Game Asset | Asset file storing serialized component state for `TreeSpriteScript` (keys: m_Script, m_Name, maskTex, windRate). |
| `TreeWindCtrl.json` | Engine / Game Asset | Asset file storing serialized component state for `TreeWindCtrl` (keys: m_Script, m_Name, strongWindEffect, windPower). |
| `UniteBindSprite.json` | Engine / Game Asset | Asset file storing serialized component state for `UniteBindSprite` (keys: m_Script, m_Name, bindCamera, isTest). |
| `battle.json` | Engine / Game Asset | Asset file storing serialized component state for `battle` (keys: m_Script, m_Name, face64_kazu, face128_kazu). |
| `battle_00.json` | Engine / Game Asset | Asset file storing serialized component state for `battle_00` (keys: m_Script, m_Name, id, path). |
| `battle_01.json` | Engine / Game Asset | Asset file storing serialized component state for `battle_01` (keys: m_Script, m_Name, id, path). |
| `battle_02.json` | Engine / Game Asset | Asset file storing serialized component state for `battle_02` (keys: m_Script, m_Name, id, path). |
| `battle_03.json` | Engine / Game Asset | Asset file storing serialized component state for `battle_03` (keys: m_Script, m_Name, id, path). |
| `battle_04.json` | Engine / Game Asset | Asset file storing serialized component state for `battle_04` (keys: m_Script, m_Name, id, path). |
| `battle_05.json` | Engine / Game Asset | Asset file storing serialized component state for `battle_05` (keys: m_Script, m_Name, id, path). |
| `battle_06.json` | Engine / Game Asset | Asset file storing serialized component state for `battle_06` (keys: m_Script, m_Name, id, path). |
| `battle_07.json` | Engine / Game Asset | Asset file storing serialized component state for `battle_07` (keys: m_Script, m_Name, id, path). |
| `battle_08.json` | Engine / Game Asset | Asset file storing serialized component state for `battle_08` (keys: m_Script, m_Name, id, path). |
| `bc_udat.json` | Engine / Game Asset | Asset file storing serialized component state for `bc_udat` (keys: m_Script, m_Name, unite_data). |
| `boot.json` | Engine / Game Asset | Asset file storing serialized component state for `boot` (keys: m_Script, m_Name, face64_kazu, face128_kazu). |
| `boot_00.json` | Engine / Game Asset | Asset file storing serialized component state for `boot_00` (keys: m_Script, m_Name, id, path). |
| `boot_01.json` | Engine / Game Asset | Asset file storing serialized component state for `boot_01` (keys: m_Script, m_Name, id, path). |
| `boot_02.json` | Engine / Game Asset | Asset file storing serialized component state for `boot_02` (keys: m_Script, m_Name, id, path). |
| `boot_03.json` | Engine / Game Asset | Asset file storing serialized component state for `boot_03` (keys: m_Script, m_Name, id, path). |
| `boot_04.json` | Engine / Game Asset | Asset file storing serialized component state for `boot_04` (keys: m_Script, m_Name, id, path). |
| `boot_05.json` | Engine / Game Asset | Asset file storing serialized component state for `boot_05` (keys: m_Script, m_Name, id, path). |
| `boot_06.json` | Engine / Game Asset | Asset file storing serialized component state for `boot_06` (keys: m_Script, m_Name, id, path). |
| `boot_07.json` | Engine / Game Asset | Asset file storing serialized component state for `boot_07` (keys: m_Script, m_Name, id, path). |
| `center_core_thunder.json` | Engine / Game Asset | Asset file storing serialized component state for `center_core_thunder` (keys: m_Script, m_Name, m_Version, m_AnimClip). |
| `cloud_volume_center.json` | Engine / Game Asset | Asset file storing serialized component state for `cloud_volume_center` (keys: m_Script, m_Name, m_Version, m_AnimClip). |
| `cloud_volume_outside_back.json` | Engine / Game Asset | Asset file storing serialized component state for `cloud_volume_outside_back` (keys: m_Script, m_Name, m_Version, m_AnimClip). |
| `cloud_volume_outside_front.json` | Engine / Game Asset | Asset file storing serialized component state for `cloud_volume_outside_front` (keys: m_Script, m_Name, m_Version, m_AnimClip). |
| `coin.json` | Engine / Game Asset | Asset file storing serialized component state for `coin` (keys: m_Script, m_Name, face64_kazu, face128_kazu). |
| `dragon.json` | Engine / Game Asset | Asset file storing serialized component state for `dragon` (keys: m_Script, m_Name, face64_kazu, face128_kazu). |
| `dragon_00.json` | Engine / Game Asset | Asset file storing serialized component state for `dragon_00` (keys: m_Script, m_Name, id, path). |
| `ending.json` | Engine / Game Asset | Asset file storing serialized component state for `ending` (keys: m_Script, m_Name, opd_tbl, map). |
| `ending_00.json` | Engine / Game Asset | Asset file storing serialized component state for `ending_00` (keys: m_Script, m_Name, id, path). |
| `ending_01.json` | Engine / Game Asset | Asset file storing serialized component state for `ending_01` (keys: m_Script, m_Name, id, path). |
| `ending_02.json` | Engine / Game Asset | Asset file storing serialized component state for `ending_02` (keys: m_Script, m_Name, id, path). |
| `ending_03.json` | Engine / Game Asset | Asset file storing serialized component state for `ending_03` (keys: m_Script, m_Name, id, path). |
| `ending_04.json` | Engine / Game Asset | Asset file storing serialized component state for `ending_04` (keys: m_Script, m_Name, id, path). |
| `ending_05.json` | Engine / Game Asset | Asset file storing serialized component state for `ending_05` (keys: m_Script, m_Name, id, path). |
| `fe_dat00.json` | Engine / Game Asset | Asset file storing serialized component state for `fe_dat00` (keys: m_Script, m_Name, opd_tbl, map). |
| `fe_dat00_00.json` | Engine / Game Asset | Asset file storing serialized component state for `fe_dat00_00` (keys: m_Script, m_Name, id, path). |
| `fe_dat01.json` | Engine / Game Asset | Asset file storing serialized component state for `fe_dat01` (keys: m_Script, m_Name, opd_tbl, map). |
| `fe_dat01_00.json` | Engine / Game Asset | Asset file storing serialized component state for `fe_dat01_00` (keys: m_Script, m_Name, id, path). |
| `fe_dat01_01.json` | Engine / Game Asset | Asset file storing serialized component state for `fe_dat01_01` (keys: m_Script, m_Name, id, path). |
| `fe_dat02.json` | Engine / Game Asset | Asset file storing serialized component state for `fe_dat02` (keys: m_Script, m_Name, opd_tbl, map). |
| `fe_dat02_00.json` | Engine / Game Asset | Asset file storing serialized component state for `fe_dat02_00` (keys: m_Script, m_Name, id, path). |
| `fe_dat02_01.json` | Engine / Game Asset | Asset file storing serialized component state for `fe_dat02_01` (keys: m_Script, m_Name, id, path). |
| `fe_dat03.json` | Engine / Game Asset | Asset file storing serialized component state for `fe_dat03` (keys: m_Script, m_Name, opd_tbl, map). |
| `fe_dat03_01.json` | Engine / Game Asset | Asset file storing serialized component state for `fe_dat03_01` (keys: m_Script, m_Name, id, path). |
| `fe_dat04.json` | Engine / Game Asset | Asset file storing serialized component state for `fe_dat04` (keys: m_Script, m_Name, opd_tbl, map). |
| `fe_dat05.json` | Engine / Game Asset | Asset file storing serialized component state for `fe_dat05` (keys: m_Script, m_Name, opd_tbl, map). |
| `fe_dat05_00.json` | Engine / Game Asset | Asset file storing serialized component state for `fe_dat05_00` (keys: m_Script, m_Name, id, path). |
| `fe_dat06.json` | Engine / Game Asset | Asset file storing serialized component state for `fe_dat06` (keys: m_Script, m_Name, opd_tbl, map). |
| `fe_dat08.json` | Engine / Game Asset | Asset file storing serialized component state for `fe_dat08` (keys: m_Script, m_Name, opd_tbl, map). |
| `fe_dat08_00.json` | Engine / Game Asset | Asset file storing serialized component state for `fe_dat08_00` (keys: m_Script, m_Name, id, path). |
| `fe_dat09.json` | Engine / Game Asset | Asset file storing serialized component state for `fe_dat09` (keys: m_Script, m_Name, opd_tbl, map). |
| `fe_dat09_00.json` | Engine / Game Asset | Asset file storing serialized component state for `fe_dat09_00` (keys: m_Script, m_Name, id, path). |
| `fe_dat10.json` | Engine / Game Asset | Asset file storing serialized component state for `fe_dat10` (keys: m_Script, m_Name, opd_tbl, map). |
| `fe_dat12.json` | Engine / Game Asset | Asset file storing serialized component state for `fe_dat12` (keys: m_Script, m_Name, opd_tbl, map). |
| `fe_dat13.json` | Engine / Game Asset | Asset file storing serialized component state for `fe_dat13` (keys: m_Script, m_Name, opd_tbl, map). |
| `fe_dat13_00.json` | Engine / Game Asset | Asset file storing serialized component state for `fe_dat13_00` (keys: m_Script, m_Name, id, path). |
| `fe_dat14.json` | Engine / Game Asset | Asset file storing serialized component state for `fe_dat14` (keys: m_Script, m_Name, opd_tbl, map). |
| `fe_dat14_00.json` | Engine / Game Asset | Asset file storing serialized component state for `fe_dat14_00` (keys: m_Script, m_Name, id, path). |
| `fe_dat14_01.json` | Engine / Game Asset | Asset file storing serialized component state for `fe_dat14_01` (keys: m_Script, m_Name, id, path). |
| `fe_dat15.json` | Engine / Game Asset | Asset file storing serialized component state for `fe_dat15` (keys: m_Script, m_Name, opd_tbl, map). |
| `fe_dat16.json` | Engine / Game Asset | Asset file storing serialized component state for `fe_dat16` (keys: m_Script, m_Name, opd_tbl, map). |
| `fe_dat17.json` | Engine / Game Asset | Asset file storing serialized component state for `fe_dat17` (keys: m_Script, m_Name, opd_tbl, map). |
| `fe_dat18.json` | Engine / Game Asset | Asset file storing serialized component state for `fe_dat18` (keys: m_Script, m_Name, opd_tbl, map). |
| `fe_dat20.json` | Engine / Game Asset | Asset file storing serialized component state for `fe_dat20` (keys: m_Script, m_Name, opd_tbl, map). |
| `fic_d.json` | Engine / Game Asset | Asset file storing serialized component state for `fic_d` (keys: m_Script, m_Name, id, path). |
| `fish_map_00.json` | Engine / Game Asset | Asset file storing serialized component state for `fish_map_00` (keys: m_Script, m_Name, id, path). |
| `gamedata.json` | Engine / Game Asset | Asset file storing serialized component state for `gamedata` (keys: m_Script, m_Name, all_data_table, arms_data). |
| `gameover.json` | Engine / Game Asset | Asset file storing serialized component state for `gameover` (keys: m_Script, m_Name, face64_kazu, face128_kazu). |
| `gameover_00.json` | Engine / Game Asset | Asset file storing serialized component state for `gameover_00` (keys: m_Script, m_Name, id, path). |
| `idat_a3.json` | Engine / Game Asset | Asset file storing serialized component state for `idat_a3` (keys: m_Script, m_Name, ikki_type, battle_field_data). |
| `idat_a3_00.json` | Engine / Game Asset | Asset file storing serialized component state for `idat_a3_00` (keys: m_Script, m_Name, id, path). |
| `idat_a3_01.json` | Engine / Game Asset | Asset file storing serialized component state for `idat_a3_01` (keys: m_Script, m_Name, id, path). |
| `idat_a3_effect.json` | Engine / Game Asset | Asset file storing serialized component state for `idat_a3_effect` (keys: m_Script, m_Name, id, path). |
| `idat_a3_obj.json` | Engine / Game Asset | Asset file storing serialized component state for `idat_a3_obj` (keys: m_Script, m_Name, id, path). |
| `idat_a4.json` | Engine / Game Asset | Asset file storing serialized component state for `idat_a4` (keys: m_Script, m_Name, ikki_type, battle_field_data). |
| `idat_b2.json` | Engine / Game Asset | Asset file storing serialized component state for `idat_b2` (keys: m_Script, m_Name, ikki_type, battle_field_data). |
| `idat_b2_01.json` | Engine / Game Asset | Asset file storing serialized component state for `idat_b2_01` (keys: m_Script, m_Name, id, path). |
| `idat_b2_obj.json` | Engine / Game Asset | Asset file storing serialized component state for `idat_b2_obj` (keys: m_Script, m_Name, id, path). |
| `idat_d.json` | Engine / Game Asset | Asset file storing serialized component state for `idat_d` (keys: m_Script, m_Name, ikki_type, battle_field_data). |
| `idat_d2.json` | Engine / Game Asset | Asset file storing serialized component state for `idat_d2` (keys: m_Script, m_Name, id, hd_field_id). |
| `idat_d2_01.json` | Engine / Game Asset | Asset file storing serialized component state for `idat_d2_01` (keys: m_Script, m_Name, id, path). |
| `idat_d2_obj.json` | Engine / Game Asset | Asset file storing serialized component state for `idat_d2_obj` (keys: m_Script, m_Name, id, path). |
| `idat_d3.json` | Engine / Game Asset | Asset file storing serialized component state for `idat_d3` (keys: m_Script, m_Name, ikki_type, battle_field_data). |
| `idat_d3_01.json` | Engine / Game Asset | Asset file storing serialized component state for `idat_d3_01` (keys: m_Script, m_Name, id, path). |
| `idat_d3_obj.json` | Engine / Game Asset | Asset file storing serialized component state for `idat_d3_obj` (keys: m_Script, m_Name, id, path). |
| `idat_j.json` | Engine / Game Asset | Asset file storing serialized component state for `idat_j` (keys: m_Script, m_Name, ikki_type, battle_field_data). |
| `idat_j_01.json` | Engine / Game Asset | Asset file storing serialized component state for `idat_j_01` (keys: m_Script, m_Name, id, path). |
| `idat_j_obj.json` | Engine / Game Asset | Asset file storing serialized component state for `idat_j_obj` (keys: m_Script, m_Name, id, path). |
| `ikki.json` | Engine / Game Asset | Asset file storing serialized component state for `ikki` (keys: m_Script, m_Name, opd_tbl, map). |
| `ikki_00.json` | Engine / Game Asset | Asset file storing serialized component state for `ikki_00` (keys: m_Script, m_Name, id, path). |
| `ikki_01.json` | Engine / Game Asset | Asset file storing serialized component state for `ikki_01` (keys: m_Script, m_Name, id, path). |
| `ikki_02.json` | Engine / Game Asset | Asset file storing serialized component state for `ikki_02` (keys: m_Script, m_Name, id, path). |
| `ikki_03.json` | Engine / Game Asset | Asset file storing serialized component state for `ikki_03` (keys: m_Script, m_Name, id, path). |
| `ikki_04.json` | Engine / Game Asset | Asset file storing serialized component state for `ikki_04` (keys: m_Script, m_Name, id, path). |
| `imo1.json` | Engine / Game Asset | Asset file storing serialized component state for `imo1` (keys: m_Script, m_Name, opd_tbl, map). |
| `imo2.json` | Engine / Game Asset | Asset file storing serialized component state for `imo2` (keys: m_Script, m_Name, opd_tbl, map). |
| `imo3.json` | Engine / Game Asset | Asset file storing serialized component state for `imo3` (keys: m_Script, m_Name, opd_tbl, map). |
| `jij.json` | Engine / Game Asset | Asset file storing serialized component state for `jij` (keys: m_Script, m_Name, id, path). |
| `jo2.json` | Engine / Game Asset | Asset file storing serialized component state for `jo2` (keys: m_Script, m_Name, id, path). |
| `joi.json` | Engine / Game Asset | Asset file storing serialized component state for `joi` (keys: m_Script, m_Name, id, path). |
| `jup.json` | Engine / Game Asset | Asset file storing serialized component state for `jup` (keys: m_Script, m_Name, chara_id, n_1). |
| `jup_battle_00.json` | Engine / Game Asset | Asset file storing serialized component state for `jup_battle_00` (keys: m_Script, m_Name, id, path). |
| `jup_field_00.json` | Engine / Game Asset | Asset file storing serialized component state for `jup_field_00` (keys: m_Script, m_Name, id, path). |
| `kag.json` | Engine / Game Asset | Asset file storing serialized component state for `kag` (keys: m_Script, m_Name, chara_id, n_1). |
| `kag_battle_00.json` | Engine / Game Asset | Asset file storing serialized component state for `kag_battle_00` (keys: m_Script, m_Name, id, path). |
| `kag_field_00.json` | Engine / Game Asset | Asset file storing serialized component state for `kag_field_00` (keys: m_Script, m_Name, id, path). |
| `kai.json` | Engine / Game Asset | Asset file storing serialized component state for `kai` (keys: m_Script, m_Name, chara_id, n_1). |
| `kai_battle_00.json` | Engine / Game Asset | Asset file storing serialized component state for `kai_battle_00` (keys: m_Script, m_Name, id, path). |
| `kai_field_00.json` | Engine / Game Asset | Asset file storing serialized component state for `kai_field_00` (keys: m_Script, m_Name, id, path). |
| `kal.json` | Engine / Game Asset | Asset file storing serialized component state for `kal` (keys: m_Script, m_Name, id, path). |
| `kam.json` | Engine / Game Asset | Asset file storing serialized component state for `kam` (keys: m_Script, m_Name, chara_id, n_1). |
| `kam_battle_00.json` | Engine / Game Asset | Asset file storing serialized component state for `kam_battle_00` (keys: m_Script, m_Name, id, path). |
| `kam_field_00.json` | Engine / Game Asset | Asset file storing serialized component state for `kam_field_00` (keys: m_Script, m_Name, id, path). |
| `kan.json` | Engine / Game Asset | Asset file storing serialized component state for `kan` (keys: m_Script, m_Name, id, path). |
| `karuta.json` | Engine / Game Asset | Asset file storing serialized component state for `karuta` (keys: m_Script, m_Name, face64_kazu, face128_kazu). |
| `kes.json` | Engine / Game Asset | Asset file storing serialized component state for `kes` (keys: m_Script, m_Name, chara_id, n_1). |
| `kes_battle_00.json` | Engine / Game Asset | Asset file storing serialized component state for `kes_battle_00` (keys: m_Script, m_Name, id, path). |
| `kes_field_00.json` | Engine / Game Asset | Asset file storing serialized component state for `kes_field_00` (keys: m_Script, m_Name, id, path). |
| `ki1.json` | Engine / Game Asset | Asset file storing serialized component state for `ki1` (keys: m_Script, m_Name, opd_tbl, map). |
| `kib.json` | Engine / Game Asset | Asset file storing serialized component state for `kib` (keys: m_Script, m_Name, chara_id, n_1). |
| `kib_battle_00.json` | Engine / Game Asset | Asset file storing serialized component state for `kib_battle_00` (keys: m_Script, m_Name, id, path). |
| `kib_d.json` | Engine / Game Asset | Asset file storing serialized component state for `kib_d` (keys: m_Script, m_Name, id, path). |
| `kib_field_00.json` | Engine / Game Asset | Asset file storing serialized component state for `kib_field_00` (keys: m_Script, m_Name, id, path). |
| `kil.json` | Engine / Game Asset | Asset file storing serialized component state for `kil` (keys: m_Script, m_Name, chara_id, n_1). |
| `kil_battle_00.json` | Engine / Game Asset | Asset file storing serialized component state for `kil_battle_00` (keys: m_Script, m_Name, id, path). |
| `kil_field_00.json` | Engine / Game Asset | Asset file storing serialized component state for `kil_field_00` (keys: m_Script, m_Name, id, path). |
| `kkl.json` | Engine / Game Asset | Asset file storing serialized component state for `kkl` (keys: m_Script, m_Name, id, path). |
| `kks.json` | Engine / Game Asset | Asset file storing serialized component state for `kks` (keys: m_Script, m_Name, id, path). |
| `klk.json` | Engine / Game Asset | Asset file storing serialized component state for `klk` (keys: m_Script, m_Name, id, path). |
| `kmu.json` | Engine / Game Asset | Asset file storing serialized component state for `kmu` (keys: m_Script, m_Name, id, path). |
| `kna.json` | Engine / Game Asset | Asset file storing serialized component state for `kna` (keys: m_Script, m_Name, chara_id, n_1). |
| `kna_battle_00.json` | Engine / Game Asset | Asset file storing serialized component state for `kna_battle_00` (keys: m_Script, m_Name, id, path). |
| `kna_field_00.json` | Engine / Game Asset | Asset file storing serialized component state for `kna_field_00` (keys: m_Script, m_Name, id, path). |
| `kni.json` | Engine / Game Asset | Asset file storing serialized component state for `kni` (keys: m_Script, m_Name, id, path). |
| `kra.json` | Engine / Game Asset | Asset file storing serialized component state for `kra` (keys: m_Script, m_Name, chara_id, n_1). |
| `kra_battle_00.json` | Engine / Game Asset | Asset file storing serialized component state for `kra_battle_00` (keys: m_Script, m_Name, id, path). |
| `kra_field_00.json` | Engine / Game Asset | Asset file storing serialized component state for `kra_field_00` (keys: m_Script, m_Name, id, path). |
| `krk.json` | Engine / Game Asset | Asset file storing serialized component state for `krk` (keys: m_Script, m_Name, chara_id, n_1). |
| `krk_battle_00.json` | Engine / Game Asset | Asset file storing serialized component state for `krk_battle_00` (keys: m_Script, m_Name, id, path). |
| `krk_field_00.json` | Engine / Game Asset | Asset file storing serialized component state for `krk_field_00` (keys: m_Script, m_Name, id, path). |
| `kru_d.json` | Engine / Game Asset | Asset file storing serialized component state for `kru_d` (keys: m_Script, m_Name, id, path). |
| `ksd.json` | Engine / Game Asset | Asset file storing serialized component state for `ksd` (keys: m_Script, m_Name, id, path). |
| `ksm.json` | Engine / Game Asset | Asset file storing serialized component state for `ksm` (keys: m_Script, m_Name, id, path). |
| `kul_sid.json` | Engine / Game Asset | Asset file storing serialized component state for `kul_sid` (keys: m_Script, m_Name, opd_tbl, map). |
| `kwa.json` | Engine / Game Asset | Asset file storing serialized component state for `kwa` (keys: m_Script, m_Name, chara_id, n_1). |
| `kwa_battle_00.json` | Engine / Game Asset | Asset file storing serialized component state for `kwa_battle_00` (keys: m_Script, m_Name, id, path). |
| `kwa_field_00.json` | Engine / Game Asset | Asset file storing serialized component state for `kwa_field_00` (keys: m_Script, m_Name, id, path). |
| `kyu.json` | Engine / Game Asset | Asset file storing serialized component state for `kyu` (keys: m_Script, m_Name, id, path). |
| `las.json` | Engine / Game Asset | Asset file storing serialized component state for `las` (keys: m_Script, m_Name, opd_tbl, map). |
| `leo.json` | Engine / Game Asset | Asset file storing serialized component state for `leo` (keys: m_Script, m_Name, chara_id, n_1). |
| `leo_battle_00.json` | Engine / Game Asset | Asset file storing serialized component state for `leo_battle_00` (keys: m_Script, m_Name, id, path). |
| `leo_field_00.json` | Engine / Game Asset | Asset file storing serialized component state for `leo_field_00` (keys: m_Script, m_Name, id, path). |
| `lfi.json` | Engine / Game Asset | Asset file storing serialized component state for `lfi` (keys: m_Script, m_Name, id, path). |
| `light_pre_center_core_thunder.json` | Engine / Game Asset | Asset file storing serialized component state for `light_pre_center_core_thunder` (keys: m_Script, m_Name, m_Version, m_AnimClip). |
| `light_white_out.json` | Engine / Game Asset | Asset file storing serialized component state for `light_white_out` (keys: m_Script, m_Name, m_Version, m_AnimClip). |
| `line1.json` | Engine / Game Asset | Asset file storing serialized component state for `line1` (keys: m_Script, m_Name, m_Version, m_AnimClip). |
| `lkk.json` | Engine / Game Asset | Asset file storing serialized component state for `lkk` (keys: m_Script, m_Name, id, path). |
| `loading.json` | Engine / Game Asset | Asset file storing serialized component state for `loading` (keys: m_Script, m_Name, face64_kazu, face128_kazu). |
| `loading_00.json` | Engine / Game Asset | Asset file storing serialized component state for `loading_00` (keys: m_Script, m_Name, id, path). |
| `loading_01.json` | Engine / Game Asset | Asset file storing serialized component state for `loading_01` (keys: m_Script, m_Name, id, path). |
| `loading_02.json` | Engine / Game Asset | Asset file storing serialized component state for `loading_02` (keys: m_Script, m_Name, id, path). |
| `lot.json` | Engine / Game Asset | Asset file storing serialized component state for `lot` (keys: m_Script, m_Name, chara_id, n_1). |
| `lot_battle_00.json` | Engine / Game Asset | Asset file storing serialized component state for `lot_battle_00` (keys: m_Script, m_Name, id, path). |
| `lot_field_00.json` | Engine / Game Asset | Asset file storing serialized component state for `lot_field_00` (keys: m_Script, m_Name, id, path). |
| `lub.json` | Engine / Game Asset | Asset file storing serialized component state for `lub` (keys: m_Script, m_Name, chara_id, n_1). |
| `lub_battle_00.json` | Engine / Game Asset | Asset file storing serialized component state for `lub_battle_00` (keys: m_Script, m_Name, id, path). |
| `lub_field_00.json` | Engine / Game Asset | Asset file storing serialized component state for `lub_field_00` (keys: m_Script, m_Name, id, path). |
| `luk.json` | Engine / Game Asset | Asset file storing serialized component state for `luk` (keys: m_Script, m_Name, chara_id, n_1). |
| `luk_battle_00.json` | Engine / Game Asset | Asset file storing serialized component state for `luk_battle_00` (keys: m_Script, m_Name, id, path). |
| `luk_field_00.json` | Engine / Game Asset | Asset file storing serialized component state for `luk_field_00` (keys: m_Script, m_Name, id, path). |
| `m_bln1.json` | Engine / Game Asset | Asset file storing serialized component state for `m_bln1` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_bln1_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_bln1_00` (keys: m_Script, m_Name, id, path). |
| `m_bln1_01.json` | Engine / Game Asset | Asset file storing serialized component state for `m_bln1_01` (keys: m_Script, m_Name, id, path). |
| `m_bln2.json` | Engine / Game Asset | Asset file storing serialized component state for `m_bln2` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_bln2_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_bln2_00` (keys: m_Script, m_Name, id, path). |
| `m_bln2_01.json` | Engine / Game Asset | Asset file storing serialized component state for `m_bln2_01` (keys: m_Script, m_Name, id, path). |
| `m_bln3.json` | Engine / Game Asset | Asset file storing serialized component state for `m_bln3` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_bor.json` | Engine / Game Asset | Asset file storing serialized component state for `m_bor` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_bor_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_bor_00` (keys: m_Script, m_Name, id, path). |
| `m_bor_01.json` | Engine / Game Asset | Asset file storing serialized component state for `m_bor_01` (keys: m_Script, m_Name, id, path). |
| `m_bur.json` | Engine / Game Asset | Asset file storing serialized component state for `m_bur` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_bur_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_bur_00` (keys: m_Script, m_Name, id, path). |
| `m_dar1.json` | Engine / Game Asset | Asset file storing serialized component state for `m_dar1` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_dar1_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_dar1_00` (keys: m_Script, m_Name, id, path). |
| `m_dar2.json` | Engine / Game Asset | Asset file storing serialized component state for `m_dar2` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_dar2_01.json` | Engine / Game Asset | Asset file storing serialized component state for `m_dar2_01` (keys: m_Script, m_Name, id, path). |
| `m_dar3.json` | Engine / Game Asset | Asset file storing serialized component state for `m_dar3` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_dar3_01.json` | Engine / Game Asset | Asset file storing serialized component state for `m_dar3_01` (keys: m_Script, m_Name, id, path). |
| `m_dar3_02.json` | Engine / Game Asset | Asset file storing serialized component state for `m_dar3_02` (keys: m_Script, m_Name, id, path). |
| `m_dar4.json` | Engine / Game Asset | Asset file storing serialized component state for `m_dar4` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_dar4_01.json` | Engine / Game Asset | Asset file storing serialized component state for `m_dar4_01` (keys: m_Script, m_Name, id, path). |
| `m_dar5.json` | Engine / Game Asset | Asset file storing serialized component state for `m_dar5` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_dar5_01.json` | Engine / Game Asset | Asset file storing serialized component state for `m_dar5_01` (keys: m_Script, m_Name, id, path). |
| `m_dar6.json` | Engine / Game Asset | Asset file storing serialized component state for `m_dar6` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_dar6_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_dar6_00` (keys: m_Script, m_Name, id, path). |
| `m_eat1.json` | Engine / Game Asset | Asset file storing serialized component state for `m_eat1` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_eat1_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_eat1_00` (keys: m_Script, m_Name, id, path). |
| `m_eat1_01.json` | Engine / Game Asset | Asset file storing serialized component state for `m_eat1_01` (keys: m_Script, m_Name, id, path). |
| `m_eat2.json` | Engine / Game Asset | Asset file storing serialized component state for `m_eat2` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_eat2_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_eat2_00` (keys: m_Script, m_Name, id, path). |
| `m_eat3.json` | Engine / Game Asset | Asset file storing serialized component state for `m_eat3` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_eat3_01.json` | Engine / Game Asset | Asset file storing serialized component state for `m_eat3_01` (keys: m_Script, m_Name, id, path). |
| `m_eat4.json` | Engine / Game Asset | Asset file storing serialized component state for `m_eat4` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_eat4_01.json` | Engine / Game Asset | Asset file storing serialized component state for `m_eat4_01` (keys: m_Script, m_Name, id, path). |
| `m_eat5.json` | Engine / Game Asset | Asset file storing serialized component state for `m_eat5` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_eat5_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_eat5_00` (keys: m_Script, m_Name, id, path). |
| `m_eat5_01.json` | Engine / Game Asset | Asset file storing serialized component state for `m_eat5_01` (keys: m_Script, m_Name, id, path). |
| `m_fir1.json` | Engine / Game Asset | Asset file storing serialized component state for `m_fir1` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_fir1_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_fir1_00` (keys: m_Script, m_Name, id, path). |
| `m_fir1_01.json` | Engine / Game Asset | Asset file storing serialized component state for `m_fir1_01` (keys: m_Script, m_Name, id, path). |
| `m_fir2.json` | Engine / Game Asset | Asset file storing serialized component state for `m_fir2` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_fir2_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_fir2_00` (keys: m_Script, m_Name, id, path). |
| `m_fir2_01.json` | Engine / Game Asset | Asset file storing serialized component state for `m_fir2_01` (keys: m_Script, m_Name, id, path). |
| `m_fir3.json` | Engine / Game Asset | Asset file storing serialized component state for `m_fir3` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_fir3_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_fir3_00` (keys: m_Script, m_Name, id, path). |
| `m_fir3_01.json` | Engine / Game Asset | Asset file storing serialized component state for `m_fir3_01` (keys: m_Script, m_Name, id, path). |
| `m_fir3_02.json` | Engine / Game Asset | Asset file storing serialized component state for `m_fir3_02` (keys: m_Script, m_Name, id, path). |
| `m_fir3_03.json` | Engine / Game Asset | Asset file storing serialized component state for `m_fir3_03` (keys: m_Script, m_Name, id, path). |
| `m_fir4.json` | Engine / Game Asset | Asset file storing serialized component state for `m_fir4` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_fir5.json` | Engine / Game Asset | Asset file storing serialized component state for `m_fir5` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_fir5_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_fir5_00` (keys: m_Script, m_Name, id, path). |
| `m_fur.json` | Engine / Game Asset | Asset file storing serialized component state for `m_fur` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_fur_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_fur_00` (keys: m_Script, m_Name, id, path). |
| `m_fur_01.json` | Engine / Game Asset | Asset file storing serialized component state for `m_fur_01` (keys: m_Script, m_Name, id, path). |
| `m_gat1.json` | Engine / Game Asset | Asset file storing serialized component state for `m_gat1` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_gat1_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_gat1_00` (keys: m_Script, m_Name, id, path). |
| `m_gat1_01.json` | Engine / Game Asset | Asset file storing serialized component state for `m_gat1_01` (keys: m_Script, m_Name, id, path). |
| `m_gat1_02.json` | Engine / Game Asset | Asset file storing serialized component state for `m_gat1_02` (keys: m_Script, m_Name, id, path). |
| `m_gat2.json` | Engine / Game Asset | Asset file storing serialized component state for `m_gat2` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_gat2_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_gat2_00` (keys: m_Script, m_Name, id, path). |
| `m_gat2_01.json` | Engine / Game Asset | Asset file storing serialized component state for `m_gat2_01` (keys: m_Script, m_Name, id, path). |
| `m_gat2_02.json` | Engine / Game Asset | Asset file storing serialized component state for `m_gat2_02` (keys: m_Script, m_Name, id, path). |
| `m_gat3.json` | Engine / Game Asset | Asset file storing serialized component state for `m_gat3` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_gat3_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_gat3_00` (keys: m_Script, m_Name, id, path). |
| `m_gat3_02.json` | Engine / Game Asset | Asset file storing serialized component state for `m_gat3_02` (keys: m_Script, m_Name, id, path). |
| `m_gat3_03.json` | Engine / Game Asset | Asset file storing serialized component state for `m_gat3_03` (keys: m_Script, m_Name, id, path). |
| `m_gat4.json` | Engine / Game Asset | Asset file storing serialized component state for `m_gat4` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_gat4_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_gat4_00` (keys: m_Script, m_Name, id, path). |
| `m_gat4_01.json` | Engine / Game Asset | Asset file storing serialized component state for `m_gat4_01` (keys: m_Script, m_Name, id, path). |
| `m_gat4_02.json` | Engine / Game Asset | Asset file storing serialized component state for `m_gat4_02` (keys: m_Script, m_Name, id, path). |
| `m_gat4_03.json` | Engine / Game Asset | Asset file storing serialized component state for `m_gat4_03` (keys: m_Script, m_Name, id, path). |
| `m_gri1.json` | Engine / Game Asset | Asset file storing serialized component state for `m_gri1` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_gri1_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_gri1_00` (keys: m_Script, m_Name, id, path). |
| `m_gri2.json` | Engine / Game Asset | Asset file storing serialized component state for `m_gri2` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_gri3.json` | Engine / Game Asset | Asset file storing serialized component state for `m_gri3` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_hol1.json` | Engine / Game Asset | Asset file storing serialized component state for `m_hol1` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_hol1_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_hol1_00` (keys: m_Script, m_Name, id, path). |
| `m_hol1_01.json` | Engine / Game Asset | Asset file storing serialized component state for `m_hol1_01` (keys: m_Script, m_Name, id, path). |
| `m_hol2.json` | Engine / Game Asset | Asset file storing serialized component state for `m_hol2` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_hol2_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_hol2_00` (keys: m_Script, m_Name, id, path). |
| `m_hol3.json` | Engine / Game Asset | Asset file storing serialized component state for `m_hol3` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_hol3_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_hol3_00` (keys: m_Script, m_Name, id, path). |
| `m_hol4.json` | Engine / Game Asset | Asset file storing serialized component state for `m_hol4` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_hol4_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_hol4_00` (keys: m_Script, m_Name, id, path). |
| `m_kae.json` | Engine / Game Asset | Asset file storing serialized component state for `m_kae` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_kae_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_kae_00` (keys: m_Script, m_Name, id, path). |
| `m_kae_01.json` | Engine / Game Asset | Asset file storing serialized component state for `m_kae_01` (keys: m_Script, m_Name, id, path). |
| `m_kae_02.json` | Engine / Game Asset | Asset file storing serialized component state for `m_kae_02` (keys: m_Script, m_Name, id, path). |
| `m_kae_03.json` | Engine / Game Asset | Asset file storing serialized component state for `m_kae_03` (keys: m_Script, m_Name, id, path). |
| `m_kal.json` | Engine / Game Asset | Asset file storing serialized component state for `m_kal` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_kal_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_kal_00` (keys: m_Script, m_Name, id, path). |
| `m_kks.json` | Engine / Game Asset | Asset file storing serialized component state for `m_kks` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_kks_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_kks_00` (keys: m_Script, m_Name, id, path). |
| `m_klk1.json` | Engine / Game Asset | Asset file storing serialized component state for `m_klk1` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_klk1_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_klk1_00` (keys: m_Script, m_Name, id, path). |
| `m_klk1_01.json` | Engine / Game Asset | Asset file storing serialized component state for `m_klk1_01` (keys: m_Script, m_Name, id, path). |
| `m_klk1_02.json` | Engine / Game Asset | Asset file storing serialized component state for `m_klk1_02` (keys: m_Script, m_Name, id, path). |
| `m_klk2.json` | Engine / Game Asset | Asset file storing serialized component state for `m_klk2` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_klk3.json` | Engine / Game Asset | Asset file storing serialized component state for `m_klk3` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_ksm.json` | Engine / Game Asset | Asset file storing serialized component state for `m_ksm` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_lfi.json` | Engine / Game Asset | Asset file storing serialized component state for `m_lfi` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_lfi_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_lfi_00` (keys: m_Script, m_Name, id, path). |
| `m_lfi_01.json` | Engine / Game Asset | Asset file storing serialized component state for `m_lfi_01` (keys: m_Script, m_Name, id, path). |
| `m_lfi_02.json` | Engine / Game Asset | Asset file storing serialized component state for `m_lfi_02` (keys: m_Script, m_Name, id, path). |
| `m_mdo.json` | Engine / Game Asset | Asset file storing serialized component state for `m_mdo` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_mil.json` | Engine / Game Asset | Asset file storing serialized component state for `m_mil` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_mil_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_mil_00` (keys: m_Script, m_Name, id, path). |
| `m_mil_01.json` | Engine / Game Asset | Asset file storing serialized component state for `m_mil_01` (keys: m_Script, m_Name, id, path). |
| `m_msm.json` | Engine / Game Asset | Asset file storing serialized component state for `m_msm` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_ora.json` | Engine / Game Asset | Asset file storing serialized component state for `m_ora` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_ora_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_ora_00` (keys: m_Script, m_Name, id, path). |
| `m_rai.json` | Engine / Game Asset | Asset file storing serialized component state for `m_rai` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_rai_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_rai_00` (keys: m_Script, m_Name, id, path). |
| `m_rai_01.json` | Engine / Game Asset | Asset file storing serialized component state for `m_rai_01` (keys: m_Script, m_Name, id, path). |
| `m_sen.json` | Engine / Game Asset | Asset file storing serialized component state for `m_sen` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_sen_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_sen_00` (keys: m_Script, m_Name, id, path). |
| `m_sen_01.json` | Engine / Game Asset | Asset file storing serialized component state for `m_sen_01` (keys: m_Script, m_Name, id, path). |
| `m_shi1.json` | Engine / Game Asset | Asset file storing serialized component state for `m_shi1` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_shi1_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_shi1_00` (keys: m_Script, m_Name, id, path). |
| `m_shi2.json` | Engine / Game Asset | Asset file storing serialized component state for `m_shi2` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_shi2_01.json` | Engine / Game Asset | Asset file storing serialized component state for `m_shi2_01` (keys: m_Script, m_Name, id, path). |
| `m_shi3.json` | Engine / Game Asset | Asset file storing serialized component state for `m_shi3` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_shi3_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_shi3_00` (keys: m_Script, m_Name, id, path). |
| `m_shi3_01.json` | Engine / Game Asset | Asset file storing serialized component state for `m_shi3_01` (keys: m_Script, m_Name, id, path). |
| `m_shi4.json` | Engine / Game Asset | Asset file storing serialized component state for `m_shi4` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_shi4_01.json` | Engine / Game Asset | Asset file storing serialized component state for `m_shi4_01` (keys: m_Script, m_Name, id, path). |
| `m_sin.json` | Engine / Game Asset | Asset file storing serialized component state for `m_sin` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_sin_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_sin_00` (keys: m_Script, m_Name, id, path). |
| `m_sin_01.json` | Engine / Game Asset | Asset file storing serialized component state for `m_sin_01` (keys: m_Script, m_Name, id, path). |
| `m_spc1.json` | Engine / Game Asset | Asset file storing serialized component state for `m_spc1` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_spc10.json` | Engine / Game Asset | Asset file storing serialized component state for `m_spc10` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_spc10_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_spc10_00` (keys: m_Script, m_Name, id, path). |
| `m_spc11.json` | Engine / Game Asset | Asset file storing serialized component state for `m_spc11` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_spc12.json` | Engine / Game Asset | Asset file storing serialized component state for `m_spc12` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_spc12_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_spc12_00` (keys: m_Script, m_Name, id, path). |
| `m_spc13.json` | Engine / Game Asset | Asset file storing serialized component state for `m_spc13` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_spc14.json` | Engine / Game Asset | Asset file storing serialized component state for `m_spc14` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_spc2.json` | Engine / Game Asset | Asset file storing serialized component state for `m_spc2` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_spc3.json` | Engine / Game Asset | Asset file storing serialized component state for `m_spc3` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_spc4.json` | Engine / Game Asset | Asset file storing serialized component state for `m_spc4` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_spc5.json` | Engine / Game Asset | Asset file storing serialized component state for `m_spc5` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_spc6.json` | Engine / Game Asset | Asset file storing serialized component state for `m_spc6` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_spc7.json` | Engine / Game Asset | Asset file storing serialized component state for `m_spc7` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_spc8.json` | Engine / Game Asset | Asset file storing serialized component state for `m_spc8` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_spc9.json` | Engine / Game Asset | Asset file storing serialized component state for `m_spc9` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_sui.json` | Engine / Game Asset | Asset file storing serialized component state for `m_sui` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_sui_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_sui_00` (keys: m_Script, m_Name, id, path). |
| `m_swo1.json` | Engine / Game Asset | Asset file storing serialized component state for `m_swo1` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_swo1_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_swo1_00` (keys: m_Script, m_Name, id, path). |
| `m_swo1_01.json` | Engine / Game Asset | Asset file storing serialized component state for `m_swo1_01` (keys: m_Script, m_Name, id, path). |
| `m_swo2.json` | Engine / Game Asset | Asset file storing serialized component state for `m_swo2` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_swo3.json` | Engine / Game Asset | Asset file storing serialized component state for `m_swo3` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_swo3_01.json` | Engine / Game Asset | Asset file storing serialized component state for `m_swo3_01` (keys: m_Script, m_Name, id, path). |
| `m_swo4.json` | Engine / Game Asset | Asset file storing serialized component state for `m_swo4` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_swo4_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_swo4_00` (keys: m_Script, m_Name, id, path). |
| `m_syo.json` | Engine / Game Asset | Asset file storing serialized component state for `m_syo` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_syo_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_syo_00` (keys: m_Script, m_Name, id, path). |
| `m_syo_03.json` | Engine / Game Asset | Asset file storing serialized component state for `m_syo_03` (keys: m_Script, m_Name, id, path). |
| `m_syo_04.json` | Engine / Game Asset | Asset file storing serialized component state for `m_syo_04` (keys: m_Script, m_Name, id, path). |
| `m_thu1.json` | Engine / Game Asset | Asset file storing serialized component state for `m_thu1` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_thu1_02.json` | Engine / Game Asset | Asset file storing serialized component state for `m_thu1_02` (keys: m_Script, m_Name, id, path). |
| `m_thu2.json` | Engine / Game Asset | Asset file storing serialized component state for `m_thu2` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_thu2_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_thu2_00` (keys: m_Script, m_Name, id, path). |
| `m_thu3.json` | Engine / Game Asset | Asset file storing serialized component state for `m_thu3` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_thu3_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_thu3_00` (keys: m_Script, m_Name, id, path). |
| `m_thu4.json` | Engine / Game Asset | Asset file storing serialized component state for `m_thu4` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_thu5.json` | Engine / Game Asset | Asset file storing serialized component state for `m_thu5` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_thu5_01.json` | Engine / Game Asset | Asset file storing serialized component state for `m_thu5_01` (keys: m_Script, m_Name, id, path). |
| `m_uni1.json` | Engine / Game Asset | Asset file storing serialized component state for `m_uni1` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_uni1_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_uni1_00` (keys: m_Script, m_Name, id, path). |
| `m_uni2.json` | Engine / Game Asset | Asset file storing serialized component state for `m_uni2` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_uni3.json` | Engine / Game Asset | Asset file storing serialized component state for `m_uni3` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_val.json` | Engine / Game Asset | Asset file storing serialized component state for `m_val` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_wat1.json` | Engine / Game Asset | Asset file storing serialized component state for `m_wat1` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_wat1_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_wat1_00` (keys: m_Script, m_Name, id, path). |
| `m_wat2.json` | Engine / Game Asset | Asset file storing serialized component state for `m_wat2` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_wat2_01.json` | Engine / Game Asset | Asset file storing serialized component state for `m_wat2_01` (keys: m_Script, m_Name, id, path). |
| `m_wat3.json` | Engine / Game Asset | Asset file storing serialized component state for `m_wat3` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_wat4.json` | Engine / Game Asset | Asset file storing serialized component state for `m_wat4` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_wat4_01.json` | Engine / Game Asset | Asset file storing serialized component state for `m_wat4_01` (keys: m_Script, m_Name, id, path). |
| `m_wat4_02.json` | Engine / Game Asset | Asset file storing serialized component state for `m_wat4_02` (keys: m_Script, m_Name, id, path). |
| `m_wat5.json` | Engine / Game Asset | Asset file storing serialized component state for `m_wat5` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_win1.json` | Engine / Game Asset | Asset file storing serialized component state for `m_win1` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_win1_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_win1_00` (keys: m_Script, m_Name, id, path). |
| `m_win2.json` | Engine / Game Asset | Asset file storing serialized component state for `m_win2` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_win3.json` | Engine / Game Asset | Asset file storing serialized component state for `m_win3` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_win3_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_win3_00` (keys: m_Script, m_Name, id, path). |
| `m_win4.json` | Engine / Game Asset | Asset file storing serialized component state for `m_win4` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_win4_01.json` | Engine / Game Asset | Asset file storing serialized component state for `m_win4_01` (keys: m_Script, m_Name, id, path). |
| `m_win5.json` | Engine / Game Asset | Asset file storing serialized component state for `m_win5` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_win5_01.json` | Engine / Game Asset | Asset file storing serialized component state for `m_win5_01` (keys: m_Script, m_Name, id, path). |
| `m_winr.json` | Engine / Game Asset | Asset file storing serialized component state for `m_winr` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_winr_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_winr_00` (keys: m_Script, m_Name, id, path). |
| `m_wol.json` | Engine / Game Asset | Asset file storing serialized component state for `m_wol` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_wol_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_wol_00` (keys: m_Script, m_Name, id, path). |
| `m_wol_01.json` | Engine / Game Asset | Asset file storing serialized component state for `m_wol_01` (keys: m_Script, m_Name, id, path). |
| `m_wol_02.json` | Engine / Game Asset | Asset file storing serialized component state for `m_wol_02` (keys: m_Script, m_Name, id, path). |
| `m_zam.json` | Engine / Game Asset | Asset file storing serialized component state for `m_zam` (keys: m_Script, m_Name, opd_tbl, map). |
| `m_zam_00.json` | Engine / Game Asset | Asset file storing serialized component state for `m_zam_00` (keys: m_Script, m_Name, id, path). |
| `maa.json` | Engine / Game Asset | Asset file storing serialized component state for `maa` (keys: m_Script, m_Name, chara_id, n_1). |
| `maa_battle_00.json` | Engine / Game Asset | Asset file storing serialized component state for `maa_battle_00` (keys: m_Script, m_Name, id, path). |
| `maa_field_00.json` | Engine / Game Asset | Asset file storing serialized component state for `maa_field_00` (keys: m_Script, m_Name, id, path). |
| `main.json` | Engine / Game Asset | Asset file storing serialized component state for `main` (keys: m_Script, m_Name, opd_tbl, map). |
| `main_00.json` | Engine / Game Asset | Asset file storing serialized component state for `main_00` (keys: m_Script, m_Name, id, path). |
| `main_01.json` | Engine / Game Asset | Asset file storing serialized component state for `main_01` (keys: m_Script, m_Name, id, path). |
| `main_02.json` | Engine / Game Asset | Asset file storing serialized component state for `main_02` (keys: m_Script, m_Name, id, path). |
| `main_03.json` | Engine / Game Asset | Asset file storing serialized component state for `main_03` (keys: m_Script, m_Name, id, path). |
| `main_05.json` | Engine / Game Asset | Asset file storing serialized component state for `main_05` (keys: m_Script, m_Name, id, path). |
| `main_06.json` | Engine / Game Asset | Asset file storing serialized component state for `main_06` (keys: m_Script, m_Name, id, path). |
| `main_07.json` | Engine / Game Asset | Asset file storing serialized component state for `main_07` (keys: m_Script, m_Name, id, path). |
| `main_08.json` | Engine / Game Asset | Asset file storing serialized component state for `main_08` (keys: m_Script, m_Name, id, path). |
| `main_09.json` | Engine / Game Asset | Asset file storing serialized component state for `main_09` (keys: m_Script, m_Name, id, path). |
| `main_10.json` | Engine / Game Asset | Asset file storing serialized component state for `main_10` (keys: m_Script, m_Name, id, path). |
| `main_11.json` | Engine / Game Asset | Asset file storing serialized component state for `main_11` (keys: m_Script, m_Name, id, path). |
| `main_13.json` | Engine / Game Asset | Asset file storing serialized component state for `main_13` (keys: m_Script, m_Name, id, path). |
| `mcr.json` | Engine / Game Asset | Asset file storing serialized component state for `mcr` (keys: m_Script, m_Name, id, path). |
| `mdo.json` | Engine / Game Asset | Asset file storing serialized component state for `mdo` (keys: m_Script, m_Name, id, path). |
| `meg.json` | Engine / Game Asset | Asset file storing serialized component state for `meg` (keys: m_Script, m_Name, chara_id, n_1). |
| `meg_battle_00.json` | Engine / Game Asset | Asset file storing serialized component state for `meg_battle_00` (keys: m_Script, m_Name, id, path). |
| `meg_field_00.json` | Engine / Game Asset | Asset file storing serialized component state for `meg_field_00` (keys: m_Script, m_Name, id, path). |
| `mes.json` | Engine / Game Asset | Asset file storing serialized component state for `mes` (keys: m_Script, m_Name, chara_id, n_1). |
| `mes_battle_00.json` | Engine / Game Asset | Asset file storing serialized component state for `mes_battle_00` (keys: m_Script, m_Name, id, path). |
| `mes_field_00.json` | Engine / Game Asset | Asset file storing serialized component state for `mes_field_00` (keys: m_Script, m_Name, id, path). |
| `mf_boa0.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_boa0` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_boa0_00.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_boa0_00` (keys: m_Script, m_Name, id, path). |
| `mf_boa0_01.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_boa0_01` (keys: m_Script, m_Name, id, path). |
| `mf_boa0_02.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_boa0_02` (keys: m_Script, m_Name, id, path). |
| `mf_cim0.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_cim0` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_cim0_00.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_cim0_00` (keys: m_Script, m_Name, id, path). |
| `mf_cim1.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_cim1` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_cim1_00.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_cim1_00` (keys: m_Script, m_Name, id, path). |
| `mf_cim2.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_cim2` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_cim2_00.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_cim2_00` (keys: m_Script, m_Name, id, path). |
| `mf_coc0.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_coc0` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_coc1.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_coc1` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_coc1_00.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_coc1_00` (keys: m_Script, m_Name, id, path). |
| `mf_coc1_01.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_coc1_01` (keys: m_Script, m_Name, id, path). |
| `mf_col0.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_col0` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_col0_00.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_col0_00` (keys: m_Script, m_Name, id, path). |
| `mf_col0_01.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_col0_01` (keys: m_Script, m_Name, id, path). |
| `mf_col1.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_col1` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_col1_00.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_col1_00` (keys: m_Script, m_Name, id, path). |
| `mf_col1_01.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_col1_01` (keys: m_Script, m_Name, id, path). |
| `mf_col1_02.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_col1_02` (keys: m_Script, m_Name, id, path). |
| `mf_dre0.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_dre0` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_dre0_00.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_dre0_00` (keys: m_Script, m_Name, id, path). |
| `mf_dre1.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_dre1` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_dre2.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_dre2` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_dre3.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_dre3` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_dre4.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_dre4` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_dre5.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_dre5` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_dre6.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_dre6` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_dre7.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_dre7` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_dre8.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_dre8` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_dre9.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_dre9` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_ear4.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_ear4` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_ear4_01.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_ear4_01` (keys: m_Script, m_Name, id, path). |
| `mf_fir1.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_fir1` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_fir1_00.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_fir1_00` (keys: m_Script, m_Name, id, path). |
| `mf_fir1_01.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_fir1_01` (keys: m_Script, m_Name, id, path). |
| `mf_fir1_02.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_fir1_02` (keys: m_Script, m_Name, id, path). |
| `mf_fir3.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_fir3` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_fir3_00.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_fir3_00` (keys: m_Script, m_Name, id, path). |
| `mf_fir3_01.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_fir3_01` (keys: m_Script, m_Name, id, path). |
| `mf_fir3_02.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_fir3_02` (keys: m_Script, m_Name, id, path). |
| `mf_fir3_03.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_fir3_03` (keys: m_Script, m_Name, id, path). |
| `mf_fir4.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_fir4` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_fir5.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_fir5` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_fir5_00.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_fir5_00` (keys: m_Script, m_Name, id, path). |
| `mf_gek0.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_gek0` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_gek0_00.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_gek0_00` (keys: m_Script, m_Name, id, path). |
| `mf_gek1.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_gek1` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_gek1_00.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_gek1_00` (keys: m_Script, m_Name, id, path). |
| `mf_gol0.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_gol0` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_gol1.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_gol1` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_gol1_01.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_gol1_01` (keys: m_Script, m_Name, id, path). |
| `mf_gol1_03.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_gol1_03` (keys: m_Script, m_Name, id, path). |
| `mf_gol1_04.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_gol1_04` (keys: m_Script, m_Name, id, path). |
| `mf_gor0.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_gor0` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_gwo0.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_gwo0` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_gwo0_01.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_gwo0_01` (keys: m_Script, m_Name, id, path). |
| `mf_gwo1.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_gwo1` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_gwo1_00.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_gwo1_00` (keys: m_Script, m_Name, id, path). |
| `mf_hap0.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_hap0` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_hap0_00.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_hap0_00` (keys: m_Script, m_Name, id, path). |
| `mf_hap1.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_hap1` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_hap1_01.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_hap1_01` (keys: m_Script, m_Name, id, path). |
| `mf_imo0.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_imo0` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_imo0_00.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_imo0_00` (keys: m_Script, m_Name, id, path). |
| `mf_imo1.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_imo1` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_imo2.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_imo2` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_imo2_00.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_imo2_00` (keys: m_Script, m_Name, id, path). |
| `mf_ki20.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_ki20` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_ki20_00.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_ki20_00` (keys: m_Script, m_Name, id, path). |
| `mf_ki21.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_ki21` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_ki21_00.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_ki21_00` (keys: m_Script, m_Name, id, path). |
| `mf_kul0.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_kul0` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_kul0_00.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_kul0_00` (keys: m_Script, m_Name, id, path). |
| `mf_kul1.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_kul1` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_kul1_00.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_kul1_00` (keys: m_Script, m_Name, id, path). |
| `mf_las0.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_las0` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_las0_00.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_las0_00` (keys: m_Script, m_Name, id, path). |
| `mf_las0_01.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_las0_01` (keys: m_Script, m_Name, id, path). |
| `mf_las1.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_las1` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_las2.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_las2` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_las2_00.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_las2_00` (keys: m_Script, m_Name, id, path). |
| `mf_las3.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_las3` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_las3_00.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_las3_00` (keys: m_Script, m_Name, id, path). |
| `mf_las4.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_las4` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_las4_00.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_las4_00` (keys: m_Script, m_Name, id, path). |
| `mf_las5.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_las5` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_las5_00.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_las5_00` (keys: m_Script, m_Name, id, path). |
| `mf_las5_01.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_las5_01` (keys: m_Script, m_Name, id, path). |
| `mf_las6.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_las6` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_las7.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_las7` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_las7_00.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_las7_00` (keys: m_Script, m_Name, id, path). |
| `mf_las7_01.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_las7_01` (keys: m_Script, m_Name, id, path). |
| `mf_las7_02.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_las7_02` (keys: m_Script, m_Name, id, path). |
| `mf_las7_03.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_las7_03` (keys: m_Script, m_Name, id, path). |
| `mf_las7_04.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_las7_04` (keys: m_Script, m_Name, id, path). |
| `mf_lus0.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_lus0` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_lus0_00.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_lus0_00` (keys: m_Script, m_Name, id, path). |
| `mf_mag0.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_mag0` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_mag1.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_mag1` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_mag1_00.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_mag1_00` (keys: m_Script, m_Name, id, path). |
| `mf_mag2.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_mag2` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_mag3.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_mag3` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_mao0.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_mao0` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_mao0_01.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_mao0_01` (keys: m_Script, m_Name, id, path). |
| `mf_mao1.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_mao1` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_mei0.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_mei0` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_nec0.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_nec0` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_nec1.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_nec1` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_nec1_00.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_nec1_00` (keys: m_Script, m_Name, id, path). |
| `mf_ned0.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_ned0` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_ned1.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_ned1` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_rau0.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_rau0` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_sam0.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_sam0` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_sam0_00.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_sam0_00` (keys: m_Script, m_Name, id, path). |
| `mf_sid0.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_sid0` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_sid0_01.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_sid0_01` (keys: m_Script, m_Name, id, path). |
| `mf_sid0_02.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_sid0_02` (keys: m_Script, m_Name, id, path). |
| `mf_sid0_03.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_sid0_03` (keys: m_Script, m_Name, id, path). |
| `mf_sie0.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_sie0` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_sie0_00.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_sie0_00` (keys: m_Script, m_Name, id, path). |
| `mf_sie0_01.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_sie0_01` (keys: m_Script, m_Name, id, path). |
| `mf_sie1.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_sie1` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_sir0.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_sir0` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_tar0.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_tar0` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_tar1.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_tar1` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_uni0.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_uni0` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_uni0_00.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_uni0_00` (keys: m_Script, m_Name, id, path). |
| `mf_win1.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_win1` (keys: m_Script, m_Name, opd_tbl, map). |
| `mf_win3.json` | Engine / Game Asset | Asset file storing serialized component state for `mf_win3` (keys: m_Script, m_Name, opd_tbl, map). |
| `mfi.json` | Engine / Game Asset | Asset file storing serialized component state for `mfi` (keys: m_Script, m_Name, id, path). |
| `mi2.json` | Engine / Game Asset | Asset file storing serialized component state for `mi2` (keys: m_Script, m_Name, id, path). |
| `mis.json` | Engine / Game Asset | Asset file storing serialized component state for `mis` (keys: m_Script, m_Name, chara_id, n_1). |
| `mis_battle_00.json` | Engine / Game Asset | Asset file storing serialized component state for `mis_battle_00` (keys: m_Script, m_Name, id, path). |
| `mis_field_00.json` | Engine / Game Asset | Asset file storing serialized component state for `mis_field_00` (keys: m_Script, m_Name, id, path). |
| `moh.json` | Engine / Game Asset | Asset file storing serialized component state for `moh` (keys: m_Script, m_Name, chara_id, n_1). |
| `moh_battle_00.json` | Engine / Game Asset | Asset file storing serialized component state for `moh_battle_00` (keys: m_Script, m_Name, id, path). |
| `moh_field_00.json` | Engine / Game Asset | Asset file storing serialized component state for `moh_field_00` (keys: m_Script, m_Name, id, path). |
| `mos.json` | Engine / Game Asset | Asset file storing serialized component state for `mos` (keys: m_Script, m_Name, chara_id, n_1). |
| `mos_battle_00.json` | Engine / Game Asset | Asset file storing serialized component state for `mos_battle_00` (keys: m_Script, m_Name, id, path). |
| `mos_field_00.json` | Engine / Game Asset | Asset file storing serialized component state for `mos_field_00` (keys: m_Script, m_Name, id, path). |
| `mri.json` | Engine / Game Asset | Asset file storing serialized component state for `mri` (keys: m_Script, m_Name, chara_id, n_1). |
| `mri_battle_00.json` | Engine / Game Asset | Asset file storing serialized component state for `mri_battle_00` (keys: m_Script, m_Name, id, path). |
| `mri_field_00.json` | Engine / Game Asset | Asset file storing serialized component state for `mri_field_00` (keys: m_Script, m_Name, id, path). |
| `mrl_d.json` | Engine / Game Asset | Asset file storing serialized component state for `mrl_d` (keys: m_Script, m_Name, id, path). |
| `msm.json` | Engine / Game Asset | Asset file storing serialized component state for `msm` (keys: m_Script, m_Name, id, path). |
| `mtf.json` | Engine / Game Asset | Asset file storing serialized component state for `mtf` (keys: m_Script, m_Name, id, path). |
| `mto.json` | Engine / Game Asset | Asset file storing serialized component state for `mto` (keys: m_Script, m_Name, id, path). |
| `mts.json` | Engine / Game Asset | Asset file storing serialized component state for `mts` (keys: m_Script, m_Name, id, path). |
| `mtt.json` | Engine / Game Asset | Asset file storing serialized component state for `mtt` (keys: m_Script, m_Name, id, path). |
| `muk.json` | Engine / Game Asset | Asset file storing serialized component state for `muk` (keys: m_Script, m_Name, id, path). |
| `muu.json` | Engine / Game Asset | Asset file storing serialized component state for `muu` (keys: m_Script, m_Name, chara_id, n_1). |
| `muu_battle_00.json` | Engine / Game Asset | Asset file storing serialized component state for `muu_battle_00` (keys: m_Script, m_Name, id, path). |
| `muu_field_00.json` | Engine / Game Asset | Asset file storing serialized component state for `muu_field_00` (keys: m_Script, m_Name, id, path). |
| `myi.json` | Engine / Game Asset | Asset file storing serialized component state for `myi` (keys: m_Script, m_Name, chara_id, n_1). |
| `myi_battle_00.json` | Engine / Game Asset | Asset file storing serialized component state for `myi_battle_00` (keys: m_Script, m_Name, id, path). |
| `myi_field_00.json` | Engine / Game Asset | Asset file storing serialized component state for `myi_field_00` (keys: m_Script, m_Name, id, path). |
| `nia.json` | Engine / Game Asset | Asset file storing serialized component state for `nia` (keys: m_Script, m_Name, id, path). |
| `nik.json` | Engine / Game Asset | Asset file storing serialized component state for `nik` (keys: m_Script, m_Name, opd_tbl, map). |
| `ode.json` | Engine / Game Asset | Asset file storing serialized component state for `ode` (keys: m_Script, m_Name, chara_id, n_1). |
| `ode_battle_00.json` | Engine / Game Asset | Asset file storing serialized component state for `ode_battle_00` (keys: m_Script, m_Name, id, path). |
| `ode_field_00.json` | Engine / Game Asset | Asset file storing serialized component state for `ode_field_00` (keys: m_Script, m_Name, id, path). |
| `opd_elf.json` | Engine / Game Asset | Asset file storing serialized component state for `opd_elf` (keys: m_Script, m_Name, id, path). |
| `opd_uzu.json` | Engine / Game Asset | Asset file storing serialized component state for `opd_uzu` (keys: m_Script, m_Name, id, path). |
| `ora.json` | Engine / Game Asset | Asset file storing serialized component state for `ora` (keys: m_Script, m_Name, id, path). |
| `over.json` | Engine / Game Asset | Asset file storing serialized component state for `over` (keys: m_Script, m_Name, opd_tbl, map). |
| `over_04.json` | Engine / Game Asset | Asset file storing serialized component state for `over_04` (keys: m_Script, m_Name, id, path). |
| `over_06.json` | Engine / Game Asset | Asset file storing serialized component state for `over_06` (keys: m_Script, m_Name, id, path). |
| `over_07.json` | Engine / Game Asset | Asset file storing serialized component state for `over_07` (keys: m_Script, m_Name, id, path). |
| `over_08.json` | Engine / Game Asset | Asset file storing serialized component state for `over_08` (keys: m_Script, m_Name, id, path). |
| `pan.json` | Engine / Game Asset | Asset file storing serialized component state for `pan` (keys: m_Script, m_Name, chara_id, n_1). |
| `pec.json` | Engine / Game Asset | Asset file storing serialized component state for `pec` (keys: m_Script, m_Name, id, path). |
| `player_ada.json` | Engine / Game Asset | Asset file storing serialized component state for `player_ada` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_air.json` | Engine / Game Asset | Asset file storing serialized component state for `player_air` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_air_d.json` | Engine / Game Asset | Asset file storing serialized component state for `player_air_d` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_alx_d.json` | Engine / Game Asset | Asset file storing serialized component state for `player_alx_d` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_amd.json` | Engine / Game Asset | Asset file storing serialized component state for `player_amd` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_amd_d.json` | Engine / Game Asset | Asset file storing serialized component state for `player_amd_d` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_ani.json` | Engine / Game Asset | Asset file storing serialized component state for `player_ani` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_app_d.json` | Engine / Game Asset | Asset file storing serialized component state for `player_app_d` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_bic.json` | Engine / Game Asset | Asset file storing serialized component state for `player_bic` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_bor.json` | Engine / Game Asset | Asset file storing serialized component state for `player_bor` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_boz.json` | Engine / Game Asset | Asset file storing serialized component state for `player_boz` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_cry.json` | Engine / Game Asset | Asset file storing serialized component state for `player_cry` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_cyk.json` | Engine / Game Asset | Asset file storing serialized component state for `player_cyk` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_cyk_d.json` | Engine / Game Asset | Asset file storing serialized component state for `player_cyk_d` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_eri_d.json` | Engine / Game Asset | Asset file storing serialized component state for `player_eri_d` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_fic_d.json` | Engine / Game Asset | Asset file storing serialized component state for `player_fic_d` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_fre.json` | Engine / Game Asset | Asset file storing serialized component state for `player_fre` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_fre_d.json` | Engine / Game Asset | Asset file storing serialized component state for `player_fre_d` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_fri.json` | Engine / Game Asset | Asset file storing serialized component state for `player_fri` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_fri_d.json` | Engine / Game Asset | Asset file storing serialized component state for `player_fri_d` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_frk.json` | Engine / Game Asset | Asset file storing serialized component state for `player_frk` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_fut.json` | Engine / Game Asset | Asset file storing serialized component state for `player_fut` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_gab.json` | Engine / Game Asset | Asset file storing serialized component state for `player_gab` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_gen.json` | Engine / Game Asset | Asset file storing serialized component state for `player_gen` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_geo.json` | Engine / Game Asset | Asset file storing serialized component state for `player_geo` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_gjm.json` | Engine / Game Asset | Asset file storing serialized component state for `player_gjm` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_gre_d.json` | Engine / Game Asset | Asset file storing serialized component state for `player_gre_d` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_gri.json` | Engine / Game Asset | Asset file storing serialized component state for `player_gri` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_han.json` | Engine / Game Asset | Asset file storing serialized component state for `player_han` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_haw.json` | Engine / Game Asset | Asset file storing serialized component state for `player_haw` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_hic.json` | Engine / Game Asset | Asset file storing serialized component state for `player_hic` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_hnf.json` | Engine / Game Asset | Asset file storing serialized component state for `player_hnf` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_jij.json` | Engine / Game Asset | Asset file storing serialized component state for `player_jij` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_jo2.json` | Engine / Game Asset | Asset file storing serialized component state for `player_jo2` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_joi.json` | Engine / Game Asset | Asset file storing serialized component state for `player_joi` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_kal.json` | Engine / Game Asset | Asset file storing serialized component state for `player_kal` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_kan.json` | Engine / Game Asset | Asset file storing serialized component state for `player_kan` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_kan_d.json` | Engine / Game Asset | Asset file storing serialized component state for `player_kan_d` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_kib_d.json` | Engine / Game Asset | Asset file storing serialized component state for `player_kib_d` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_kkl.json` | Engine / Game Asset | Asset file storing serialized component state for `player_kkl` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_kks.json` | Engine / Game Asset | Asset file storing serialized component state for `player_kks` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_klk.json` | Engine / Game Asset | Asset file storing serialized component state for `player_klk` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_kmu.json` | Engine / Game Asset | Asset file storing serialized component state for `player_kmu` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_kni.json` | Engine / Game Asset | Asset file storing serialized component state for `player_kni` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_kru_d.json` | Engine / Game Asset | Asset file storing serialized component state for `player_kru_d` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_ksd.json` | Engine / Game Asset | Asset file storing serialized component state for `player_ksd` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_ksm.json` | Engine / Game Asset | Asset file storing serialized component state for `player_ksm` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_ksm_d.json` | Engine / Game Asset | Asset file storing serialized component state for `player_ksm_d` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_kyu.json` | Engine / Game Asset | Asset file storing serialized component state for `player_kyu` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_kyu_d.json` | Engine / Game Asset | Asset file storing serialized component state for `player_kyu_d` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_lfi.json` | Engine / Game Asset | Asset file storing serialized component state for `player_lfi` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_lkk.json` | Engine / Game Asset | Asset file storing serialized component state for `player_lkk` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_mcr.json` | Engine / Game Asset | Asset file storing serialized component state for `player_mcr` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_mcr_d.json` | Engine / Game Asset | Asset file storing serialized component state for `player_mcr_d` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_mdo.json` | Engine / Game Asset | Asset file storing serialized component state for `player_mdo` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_mfi.json` | Engine / Game Asset | Asset file storing serialized component state for `player_mfi` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_mi2.json` | Engine / Game Asset | Asset file storing serialized component state for `player_mi2` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_mil.json` | Engine / Game Asset | Asset file storing serialized component state for `player_mil` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_mrl_d.json` | Engine / Game Asset | Asset file storing serialized component state for `player_mrl_d` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_msm.json` | Engine / Game Asset | Asset file storing serialized component state for `player_msm` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_mtf.json` | Engine / Game Asset | Asset file storing serialized component state for `player_mtf` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_mto.json` | Engine / Game Asset | Asset file storing serialized component state for `player_mto` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_mts.json` | Engine / Game Asset | Asset file storing serialized component state for `player_mts` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_mtt.json` | Engine / Game Asset | Asset file storing serialized component state for `player_mtt` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_muk.json` | Engine / Game Asset | Asset file storing serialized component state for `player_muk` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_nan.json` | Engine / Game Asset | Asset file storing serialized component state for `player_nan` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_nan_d.json` | Engine / Game Asset | Asset file storing serialized component state for `player_nan_d` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_nia.json` | Engine / Game Asset | Asset file storing serialized component state for `player_nia` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_ora.json` | Engine / Game Asset | Asset file storing serialized component state for `player_ora` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_pec.json` | Engine / Game Asset | Asset file storing serialized component state for `player_pec` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_pr2_d.json` | Engine / Game Asset | Asset file storing serialized component state for `player_pr2_d` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_prk_d.json` | Engine / Game Asset | Asset file storing serialized component state for `player_prk_d` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_rik.json` | Engine / Game Asset | Asset file storing serialized component state for `player_rik` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_rkl.json` | Engine / Game Asset | Asset file storing serialized component state for `player_rkl` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_rol.json` | Engine / Game Asset | Asset file storing serialized component state for `player_rol` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_rye.json` | Engine / Game Asset | Asset file storing serialized component state for `player_rye` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_ryn.json` | Engine / Game Asset | Asset file storing serialized component state for `player_ryn` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_see.json` | Engine / Game Asset | Asset file storing serialized component state for `player_see` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_see_d.json` | Engine / Game Asset | Asset file storing serialized component state for `player_see_d` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_sen.json` | Engine / Game Asset | Asset file storing serialized component state for `player_sen` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_she.json` | Engine / Game Asset | Asset file storing serialized component state for `player_she` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_shu.json` | Engine / Game Asset | Asset file storing serialized component state for `player_shu` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_sie.json` | Engine / Game Asset | Asset file storing serialized component state for `player_sie` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_sie_d.json` | Engine / Game Asset | Asset file storing serialized component state for `player_sie_d` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_sin.json` | Engine / Game Asset | Asset file storing serialized component state for `player_sin` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_sin_d.json` | Engine / Game Asset | Asset file storing serialized component state for `player_sin_d` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_sir.json` | Engine / Game Asset | Asset file storing serialized component state for `player_sir` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_smb.json` | Engine / Game Asset | Asset file storing serialized component state for `player_smb` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_sna.json` | Engine / Game Asset | Asset file storing serialized component state for `player_sna` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_sro.json` | Engine / Game Asset | Asset file storing serialized component state for `player_sro` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_ssk.json` | Engine / Game Asset | Asset file storing serialized component state for `player_ssk` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_sta.json` | Engine / Game Asset | Asset file storing serialized component state for `player_sta` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_stk.json` | Engine / Game Asset | Asset file storing serialized component state for `player_stk` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_tai.json` | Engine / Game Asset | Asset file storing serialized component state for `player_tai` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_tai_d.json` | Engine / Game Asset | Asset file storing serialized component state for `player_tai_d` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_tel_d.json` | Engine / Game Asset | Asset file storing serialized component state for `player_tel_d` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_ten.json` | Engine / Game Asset | Asset file storing serialized component state for `player_ten` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_tou.json` | Engine / Game Asset | Asset file storing serialized component state for `player_tou` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_uni.json` | Engine / Game Asset | Asset file storing serialized component state for `player_uni` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_val.json` | Engine / Game Asset | Asset file storing serialized component state for `player_val` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_val_d.json` | Engine / Game Asset | Asset file storing serialized component state for `player_val_d` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_van.json` | Engine / Game Asset | Asset file storing serialized component state for `player_van` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_vic.json` | Engine / Game Asset | Asset file storing serialized component state for `player_vic` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_vic_d.json` | Engine / Game Asset | Asset file storing serialized component state for `player_vic_d` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_wig.json` | Engine / Game Asset | Asset file storing serialized component state for `player_wig` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_wol.json` | Engine / Game Asset | Asset file storing serialized component state for `player_wol` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_zai.json` | Engine / Game Asset | Asset file storing serialized component state for `player_zai` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_zai_d.json` | Engine / Game Asset | Asset file storing serialized component state for `player_zai_d` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_zam.json` | Engine / Game Asset | Asset file storing serialized component state for `player_zam` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_zko.json` | Engine / Game Asset | Asset file storing serialized component state for `player_zko` (keys: m_Script, m_Name, chara_id, battle_data). |
| `player_zsh.json` | Engine / Game Asset | Asset file storing serialized component state for `player_zsh` (keys: m_Script, m_Name, chara_id, battle_data). |
| `pr2_d.json` | Engine / Game Asset | Asset file storing serialized component state for `pr2_d` (keys: m_Script, m_Name, id, path). |
| `preview.json` | Engine / Game Asset | Asset file storing serialized component state for `preview` (keys: m_Script, m_Name, m_Version, m_AnimClip). |
| `psu.json` | Engine / Game Asset | Asset file storing serialized component state for `psu` (keys: m_Script, m_Name, chara_id, n_1). |
| `psu_battle_00.json` | Engine / Game Asset | Asset file storing serialized component state for `psu_battle_00` (keys: m_Script, m_Name, id, path). |
| `psu_field_00.json` | Engine / Game Asset | Asset file storing serialized component state for `psu_field_00` (keys: m_Script, m_Name, id, path). |
| `qin.json` | Engine / Game Asset | Asset file storing serialized component state for `qin` (keys: m_Script, m_Name, chara_id, n_1). |
| `qin_battle_00.json` | Engine / Game Asset | Asset file storing serialized component state for `qin_battle_00` (keys: m_Script, m_Name, id, path). |
| `qin_field_00.json` | Engine / Game Asset | Asset file storing serialized component state for `qin_field_00` (keys: m_Script, m_Name, id, path). |
| `rat.json` | Engine / Game Asset | Asset file storing serialized component state for `rat` (keys: m_Script, m_Name, opd_tbl, map). |
| `rep.json` | Engine / Game Asset | Asset file storing serialized component state for `rep` (keys: m_Script, m_Name, chara_id, n_1). |
| `rep_battle_00.json` | Engine / Game Asset | Asset file storing serialized component state for `rep_battle_00` (keys: m_Script, m_Name, id, path). |
| `rep_field_00.json` | Engine / Game Asset | Asset file storing serialized component state for `rep_field_00` (keys: m_Script, m_Name, id, path). |
| `res.json` | Engine / Game Asset | Asset file storing serialized component state for `res` (keys: m_Script, m_Name, chara_id, n_1). |
| `res_battle_00.json` | Engine / Game Asset | Asset file storing serialized component state for `res_battle_00` (keys: m_Script, m_Name, id, path). |
| `res_field_00.json` | Engine / Game Asset | Asset file storing serialized component state for `res_field_00` (keys: m_Script, m_Name, id, path). |
| `rik.json` | Engine / Game Asset | Asset file storing serialized component state for `rik` (keys: m_Script, m_Name, id, path). |
| `rkl.json` | Engine / Game Asset | Asset file storing serialized component state for `rkl` (keys: m_Script, m_Name, id, path). |
| `rol.json` | Engine / Game Asset | Asset file storing serialized component state for `rol` (keys: m_Script, m_Name, id, path). |
| `ror.json` | Engine / Game Asset | Asset file storing serialized component state for `ror` (keys: m_Script, m_Name, chara_id, n_1). |
| `ror_battle_00.json` | Engine / Game Asset | Asset file storing serialized component state for `ror_battle_00` (keys: m_Script, m_Name, id, path). |
| `ror_field_00.json` | Engine / Game Asset | Asset file storing serialized component state for `ror_field_00` (keys: m_Script, m_Name, id, path). |
| `rye.json` | Engine / Game Asset | Asset file storing serialized component state for `rye` (keys: m_Script, m_Name, id, path). |
| `ryk.json` | Engine / Game Asset | Asset file storing serialized component state for `ryk` (keys: m_Script, m_Name, chara_id, n_1). |
| `ryk_battle_00.json` | Engine / Game Asset | Asset file storing serialized component state for `ryk_battle_00` (keys: m_Script, m_Name, id, path). |
| `ryk_field_00.json` | Engine / Game Asset | Asset file storing serialized component state for `ryk_field_00` (keys: m_Script, m_Name, id, path). |
| `ryn.json` | Engine / Game Asset | Asset file storing serialized component state for `ryn` (keys: m_Script, m_Name, id, path). |
| `sas.json` | Engine / Game Asset | Asset file storing serialized component state for `sas` (keys: m_Script, m_Name, chara_id, n_1). |
| `sas_battle_00.json` | Engine / Game Asset | Asset file storing serialized component state for `sas_battle_00` (keys: m_Script, m_Name, id, path). |
| `sas_field_00.json` | Engine / Game Asset | Asset file storing serialized component state for `sas_field_00` (keys: m_Script, m_Name, id, path). |
| `sdtest_00.json` | Engine / Game Asset | Asset file storing serialized component state for `sdtest_00` (keys: m_Script, m_Name, id, path). |
| `see.json` | Engine / Game Asset | Asset file storing serialized component state for `see` (keys: m_Script, m_Name, id, path). |
| `sei.json` | Engine / Game Asset | Asset file storing serialized component state for `sei` (keys: m_Script, m_Name, opd_tbl, map). |
| `sei_battle_00.json` | Engine / Game Asset | Asset file storing serialized component state for `sei_battle_00` (keys: m_Script, m_Name, id, path). |
| `sei_field_00.json` | Engine / Game Asset | Asset file storing serialized component state for `sei_field_00` (keys: m_Script, m_Name, id, path). |
| `sel.json` | Engine / Game Asset | Asset file storing serialized component state for `sel` (keys: m_Script, m_Name, chara_id, n_1). |
| `sel_battle_00.json` | Engine / Game Asset | Asset file storing serialized component state for `sel_battle_00` (keys: m_Script, m_Name, id, path). |
| `sel_field_00.json` | Engine / Game Asset | Asset file storing serialized component state for `sel_field_00` (keys: m_Script, m_Name, id, path). |
| `select.json` | Engine / Game Asset | Asset file storing serialized component state for `select` (keys: m_Script, m_Name, opd_tbl, map). |
| `sen.json` | Engine / Game Asset | Asset file storing serialized component state for `sen` (keys: m_Script, m_Name, id, path). |
| `she.json` | Engine / Game Asset | Asset file storing serialized component state for `she` (keys: m_Script, m_Name, id, path). |
| `sid.json` | Engine / Game Asset | Asset file storing serialized component state for `sid` (keys: m_Script, m_Name, chara_id, n_1). |
| `sid_battle_00.json` | Engine / Game Asset | Asset file storing serialized component state for `sid_battle_00` (keys: m_Script, m_Name, id, path). |
| `sid_field_00.json` | Engine / Game Asset | Asset file storing serialized component state for `sid_field_00` (keys: m_Script, m_Name, id, path). |
| `sil.json` | Engine / Game Asset | Asset file storing serialized component state for `sil` (keys: m_Script, m_Name, chara_id, n_1). |
| `sil_battle_00.json` | Engine / Game Asset | Asset file storing serialized component state for `sil_battle_00` (keys: m_Script, m_Name, id, path). |
| `sil_field_00.json` | Engine / Game Asset | Asset file storing serialized component state for `sil_field_00` (keys: m_Script, m_Name, id, path). |
| `sin.json` | Engine / Game Asset | Asset file storing serialized component state for `sin` (keys: m_Script, m_Name, id, path). |
| `sir.json` | Engine / Game Asset | Asset file storing serialized component state for `sir` (keys: m_Script, m_Name, id, path). |
| `smb.json` | Engine / Game Asset | Asset file storing serialized component state for `smb` (keys: m_Script, m_Name, id, path). |
| `sna.json` | Engine / Game Asset | Asset file storing serialized component state for `sna` (keys: m_Script, m_Name, id, path). |
| `sni.json` | Engine / Game Asset | Asset file storing serialized component state for `sni` (keys: m_Script, m_Name, chara_id, n_1). |
| `sni_battle_00.json` | Engine / Game Asset | Asset file storing serialized component state for `sni_battle_00` (keys: m_Script, m_Name, id, path). |
| `sni_field_00.json` | Engine / Game Asset | Asset file storing serialized component state for `sni_field_00` (keys: m_Script, m_Name, id, path). |
| `sro.json` | Engine / Game Asset | Asset file storing serialized component state for `sro` (keys: m_Script, m_Name, id, path). |
| `ssk.json` | Engine / Game Asset | Asset file storing serialized component state for `ssk` (keys: m_Script, m_Name, id, path). |
| `sta.json` | Engine / Game Asset | Asset file storing serialized component state for `sta` (keys: m_Script, m_Name, chara_id, n_1). |
| `sta_battle_00.json` | Engine / Game Asset | Asset file storing serialized component state for `sta_battle_00` (keys: m_Script, m_Name, id, path). |
| `sta_field_00.json` | Engine / Game Asset | Asset file storing serialized component state for `sta_field_00` (keys: m_Script, m_Name, id, path). |
| `staff.json` | Engine / Game Asset | Asset file storing serialized component state for `staff` (keys: m_Script, m_Name, opd_tbl, map). |
| `staff_00.json` | Engine / Game Asset | Asset file storing serialized component state for `staff_00` (keys: m_Script, m_Name, id, path). |
| `staff_01.json` | Engine / Game Asset | Asset file storing serialized component state for `staff_01` (keys: m_Script, m_Name, id, path). |
| `staff_02.json` | Engine / Game Asset | Asset file storing serialized component state for `staff_02` (keys: m_Script, m_Name, id, path). |
| `staff_03.json` | Engine / Game Asset | Asset file storing serialized component state for `staff_03` (keys: m_Script, m_Name, id, path). |
| `staff_04.json` | Engine / Game Asset | Asset file storing serialized component state for `staff_04` (keys: m_Script, m_Name, id, path). |
| `stk.json` | Engine / Game Asset | Asset file storing serialized component state for `stk` (keys: m_Script, m_Name, id, path). |
| `suikozu.json` | Engine / Game Asset | Asset file storing serialized component state for `suikozu` (keys: m_Script, m_Name, opd_tbl, map). |
| `syy.json` | Engine / Game Asset | Asset file storing serialized component state for `syy` (keys: m_Script, m_Name, chara_id, n_1). |
| `syy_battle_00.json` | Engine / Game Asset | Asset file storing serialized component state for `syy_battle_00` (keys: m_Script, m_Name, id, path). |
| `syy_field_00.json` | Engine / Game Asset | Asset file storing serialized component state for `syy_field_00` (keys: m_Script, m_Name, id, path). |
| `ted.json` | Engine / Game Asset | Asset file storing serialized component state for `ted` (keys: m_Script, m_Name, chara_id, n_1). |
| `ted_battle_00.json` | Engine / Game Asset | Asset file storing serialized component state for `ted_battle_00` (keys: m_Script, m_Name, id, path). |
| `ted_field_00.json` | Engine / Game Asset | Asset file storing serialized component state for `ted_field_00` (keys: m_Script, m_Name, id, path). |
| `tel_d.json` | Engine / Game Asset | Asset file storing serialized component state for `tel_d` (keys: m_Script, m_Name, id, path). |
| `tou.json` | Engine / Game Asset | Asset file storing serialized component state for `tou` (keys: m_Script, m_Name, id, path). |
| `treasure_box.json` | Engine / Game Asset | Asset file storing serialized component state for `treasure_box` (keys: m_Script, m_Name, id, path). |
| `uni.json` | Engine / Game Asset | Asset file storing serialized component state for `uni` (keys: m_Script, m_Name, id, path). |
| `unite01.json` | Engine / Game Asset | Asset file storing serialized component state for `unite01` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite02.json` | Engine / Game Asset | Asset file storing serialized component state for `unite02` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite03.json` | Engine / Game Asset | Asset file storing serialized component state for `unite03` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite04.json` | Engine / Game Asset | Asset file storing serialized component state for `unite04` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite04_00.json` | Engine / Game Asset | Asset file storing serialized component state for `unite04_00` (keys: m_Script, m_Name, id, path). |
| `unite05.json` | Engine / Game Asset | Asset file storing serialized component state for `unite05` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite06.json` | Engine / Game Asset | Asset file storing serialized component state for `unite06` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite07.json` | Engine / Game Asset | Asset file storing serialized component state for `unite07` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite08.json` | Engine / Game Asset | Asset file storing serialized component state for `unite08` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite08_00.json` | Engine / Game Asset | Asset file storing serialized component state for `unite08_00` (keys: m_Script, m_Name, id, path). |
| `unite09.json` | Engine / Game Asset | Asset file storing serialized component state for `unite09` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite09_00.json` | Engine / Game Asset | Asset file storing serialized component state for `unite09_00` (keys: m_Script, m_Name, id, path). |
| `unite10.json` | Engine / Game Asset | Asset file storing serialized component state for `unite10` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite11.json` | Engine / Game Asset | Asset file storing serialized component state for `unite11` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite12.json` | Engine / Game Asset | Asset file storing serialized component state for `unite12` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite13.json` | Engine / Game Asset | Asset file storing serialized component state for `unite13` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite14.json` | Engine / Game Asset | Asset file storing serialized component state for `unite14` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite15.json` | Engine / Game Asset | Asset file storing serialized component state for `unite15` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite15_00.json` | Engine / Game Asset | Asset file storing serialized component state for `unite15_00` (keys: m_Script, m_Name, id, path). |
| `unite15_01.json` | Engine / Game Asset | Asset file storing serialized component state for `unite15_01` (keys: m_Script, m_Name, id, path). |
| `unite16.json` | Engine / Game Asset | Asset file storing serialized component state for `unite16` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite16_00.json` | Engine / Game Asset | Asset file storing serialized component state for `unite16_00` (keys: m_Script, m_Name, id, path). |
| `unite17.json` | Engine / Game Asset | Asset file storing serialized component state for `unite17` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite18.json` | Engine / Game Asset | Asset file storing serialized component state for `unite18` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite18_00.json` | Engine / Game Asset | Asset file storing serialized component state for `unite18_00` (keys: m_Script, m_Name, id, path). |
| `unite19.json` | Engine / Game Asset | Asset file storing serialized component state for `unite19` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite19_00.json` | Engine / Game Asset | Asset file storing serialized component state for `unite19_00` (keys: m_Script, m_Name, id, path). |
| `unite19_01.json` | Engine / Game Asset | Asset file storing serialized component state for `unite19_01` (keys: m_Script, m_Name, id, path). |
| `unite20.json` | Engine / Game Asset | Asset file storing serialized component state for `unite20` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite20_00.json` | Engine / Game Asset | Asset file storing serialized component state for `unite20_00` (keys: m_Script, m_Name, id, path). |
| `unite20_01.json` | Engine / Game Asset | Asset file storing serialized component state for `unite20_01` (keys: m_Script, m_Name, id, path). |
| `unite21.json` | Engine / Game Asset | Asset file storing serialized component state for `unite21` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite21_00.json` | Engine / Game Asset | Asset file storing serialized component state for `unite21_00` (keys: m_Script, m_Name, id, path). |
| `unite21_01.json` | Engine / Game Asset | Asset file storing serialized component state for `unite21_01` (keys: m_Script, m_Name, id, path). |
| `unite22.json` | Engine / Game Asset | Asset file storing serialized component state for `unite22` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite22_00.json` | Engine / Game Asset | Asset file storing serialized component state for `unite22_00` (keys: m_Script, m_Name, id, path). |
| `unite23.json` | Engine / Game Asset | Asset file storing serialized component state for `unite23` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite23_00.json` | Engine / Game Asset | Asset file storing serialized component state for `unite23_00` (keys: m_Script, m_Name, id, path). |
| `unite23_01.json` | Engine / Game Asset | Asset file storing serialized component state for `unite23_01` (keys: m_Script, m_Name, id, path). |
| `unite24.json` | Engine / Game Asset | Asset file storing serialized component state for `unite24` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite25.json` | Engine / Game Asset | Asset file storing serialized component state for `unite25` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite26.json` | Engine / Game Asset | Asset file storing serialized component state for `unite26` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite27.json` | Engine / Game Asset | Asset file storing serialized component state for `unite27` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite27_00.json` | Engine / Game Asset | Asset file storing serialized component state for `unite27_00` (keys: m_Script, m_Name, id, path). |
| `unite28.json` | Engine / Game Asset | Asset file storing serialized component state for `unite28` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite28_00.json` | Engine / Game Asset | Asset file storing serialized component state for `unite28_00` (keys: m_Script, m_Name, id, path). |
| `unite29.json` | Engine / Game Asset | Asset file storing serialized component state for `unite29` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite29_00.json` | Engine / Game Asset | Asset file storing serialized component state for `unite29_00` (keys: m_Script, m_Name, id, path). |
| `unite29_01.json` | Engine / Game Asset | Asset file storing serialized component state for `unite29_01` (keys: m_Script, m_Name, id, path). |
| `unite30.json` | Engine / Game Asset | Asset file storing serialized component state for `unite30` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite30_00.json` | Engine / Game Asset | Asset file storing serialized component state for `unite30_00` (keys: m_Script, m_Name, id, path). |
| `unite30_02.json` | Engine / Game Asset | Asset file storing serialized component state for `unite30_02` (keys: m_Script, m_Name, id, path). |
| `unite31.json` | Engine / Game Asset | Asset file storing serialized component state for `unite31` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite32.json` | Engine / Game Asset | Asset file storing serialized component state for `unite32` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite32_00.json` | Engine / Game Asset | Asset file storing serialized component state for `unite32_00` (keys: m_Script, m_Name, id, path). |
| `unite33.json` | Engine / Game Asset | Asset file storing serialized component state for `unite33` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite34.json` | Engine / Game Asset | Asset file storing serialized component state for `unite34` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite35.json` | Engine / Game Asset | Asset file storing serialized component state for `unite35` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite35_00.json` | Engine / Game Asset | Asset file storing serialized component state for `unite35_00` (keys: m_Script, m_Name, id, path). |
| `unite36.json` | Engine / Game Asset | Asset file storing serialized component state for `unite36` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite36_00.json` | Engine / Game Asset | Asset file storing serialized component state for `unite36_00` (keys: m_Script, m_Name, id, path). |
| `unite37.json` | Engine / Game Asset | Asset file storing serialized component state for `unite37` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite37_00.json` | Engine / Game Asset | Asset file storing serialized component state for `unite37_00` (keys: m_Script, m_Name, id, path). |
| `unite38.json` | Engine / Game Asset | Asset file storing serialized component state for `unite38` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite39.json` | Engine / Game Asset | Asset file storing serialized component state for `unite39` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite40.json` | Engine / Game Asset | Asset file storing serialized component state for `unite40` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite40_00.json` | Engine / Game Asset | Asset file storing serialized component state for `unite40_00` (keys: m_Script, m_Name, id, path). |
| `unite40_01.json` | Engine / Game Asset | Asset file storing serialized component state for `unite40_01` (keys: m_Script, m_Name, id, path). |
| `unite41.json` | Engine / Game Asset | Asset file storing serialized component state for `unite41` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite41_00.json` | Engine / Game Asset | Asset file storing serialized component state for `unite41_00` (keys: m_Script, m_Name, id, path). |
| `unite42.json` | Engine / Game Asset | Asset file storing serialized component state for `unite42` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite43.json` | Engine / Game Asset | Asset file storing serialized component state for `unite43` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite44.json` | Engine / Game Asset | Asset file storing serialized component state for `unite44` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite45.json` | Engine / Game Asset | Asset file storing serialized component state for `unite45` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite45_00.json` | Engine / Game Asset | Asset file storing serialized component state for `unite45_00` (keys: m_Script, m_Name, id, path). |
| `unite45_01.json` | Engine / Game Asset | Asset file storing serialized component state for `unite45_01` (keys: m_Script, m_Name, id, path). |
| `unite46.json` | Engine / Game Asset | Asset file storing serialized component state for `unite46` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite46_01.json` | Engine / Game Asset | Asset file storing serialized component state for `unite46_01` (keys: m_Script, m_Name, id, path). |
| `unite47.json` | Engine / Game Asset | Asset file storing serialized component state for `unite47` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite48.json` | Engine / Game Asset | Asset file storing serialized component state for `unite48` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite49.json` | Engine / Game Asset | Asset file storing serialized component state for `unite49` (keys: m_Script, m_Name, opd_tbl, map). |
| `unite50.json` | Engine / Game Asset | Asset file storing serialized component state for `unite50` (keys: m_Script, m_Name, opd_tbl, map). |
| `vre.json` | Engine / Game Asset | Asset file storing serialized component state for `vre` (keys: m_Script, m_Name, chara_id, n_1). |
| `vre_battle_00.json` | Engine / Game Asset | Asset file storing serialized component state for `vre_battle_00` (keys: m_Script, m_Name, id, path). |
| `vre_field_00.json` | Engine / Game Asset | Asset file storing serialized component state for `vre_field_00` (keys: m_Script, m_Name, id, path). |
| `vz1.json` | Engine / Game Asset | Asset file storing serialized component state for `vz1` (keys: m_Script, m_Name, map_kazu, map_table). |
| `vz1_map_00_03.json` | Engine / Game Asset | Asset file storing serialized component state for `vz1_map_00_03` (keys: m_Script, m_Name, id, path). |
| `vz2.json` | Engine / Game Asset | Asset file storing serialized component state for `vz2` (keys: m_Script, m_Name, map_kazu, map_table). |
| `vz3.json` | Engine / Game Asset | Asset file storing serialized component state for `vz3` (keys: m_Script, m_Name, map_kazu, map_table). |
| `vz5.json` | Engine / Game Asset | Asset file storing serialized component state for `vz5` (keys: m_Script, m_Name, map_kazu, map_table). |
| `vz7.json` | Engine / Game Asset | Asset file storing serialized component state for `vz7` (keys: m_Script, m_Name, map_kazu, map_table). |
| `vz8.json` | Engine / Game Asset | Asset file storing serialized component state for `vz8` (keys: m_Script, m_Name, map_kazu, map_table). |
| `vzv.json` | Engine / Game Asset | Asset file storing serialized component state for `vzv` (keys: m_Script, m_Name, map_kazu, map_table). |
| `vzv_map_00_battle_00.json` | Engine / Game Asset | Asset file storing serialized component state for `vzv_map_00_battle_00` (keys: m_Script, m_Name, id, field). |
| `vzv_map_00_battle_00_field.json` | Engine / Game Asset | Asset file storing serialized component state for `vzv_map_00_battle_00_field` (keys: m_Script, m_Name, id, r). |
| `vzv_map_00_battle_00_field_srn.json` | Engine / Game Asset | Asset file storing serialized component state for `vzv_map_00_battle_00_field_srn` (keys: m_Script, m_Name, id, sprite_name). |
| `vzv_map_00_battle_00_monster_data_00.json` | Engine / Game Asset | Asset file storing serialized component state for `vzv_map_00_battle_00_monster_data_00` (keys: m_Script, m_Name, id, monster_name). |
| `vzv_map_00_battle_00_monster_data_00_00.json` | Engine / Game Asset | Asset file storing serialized component state for `vzv_map_00_battle_00_monster_data_00_00` (keys: m_Script, m_Name, id, path). |
| `vzv_map_00_battle_00_monster_data_01.json` | Engine / Game Asset | Asset file storing serialized component state for `vzv_map_00_battle_00_monster_data_01` (keys: m_Script, m_Name, id, monster_name). |
| `vzv_map_00_battle_00_monster_data_02.json` | Engine / Game Asset | Asset file storing serialized component state for `vzv_map_00_battle_00_monster_data_02` (keys: m_Script, m_Name, id, monster_name). |
| `vzv_map_00_battle_00_monster_party_00.json` | Engine / Game Asset | Asset file storing serialized component state for `vzv_map_00_battle_00_monster_party_00` (keys: m_Script, m_Name, id, data). |
| `wk.json` | Engine / Game Asset | Asset file storing serialized component state for `wk` (keys: m_Script, m_Name, eventdata, skaz). |
| `wk_map_00.json` | Engine / Game Asset | Asset file storing serialized component state for `wk_map_00` (keys: m_Script, m_Name, id, path). |
| `wol.json` | Engine / Game Asset | Asset file storing serialized component state for `wol` (keys: m_Script, m_Name, id, path). |
| `wou.json` | Engine / Game Asset | Asset file storing serialized component state for `wou` (keys: m_Script, m_Name, chara_id, n_1). |
| `wou_battle_00.json` | Engine / Game Asset | Asset file storing serialized component state for `wou_battle_00` (keys: m_Script, m_Name, id, path). |
| `wou_field_00.json` | Engine / Game Asset | Asset file storing serialized component state for `wou_field_00` (keys: m_Script, m_Name, id, path). |
| `yam.json` | Engine / Game Asset | Asset file storing serialized component state for `yam` (keys: m_Script, m_Name, chara_id, n_1). |
| `yam_battle_00.json` | Engine / Game Asset | Asset file storing serialized component state for `yam_battle_00` (keys: m_Script, m_Name, id, path). |
| `yam_field_00.json` | Engine / Game Asset | Asset file storing serialized component state for `yam_field_00` (keys: m_Script, m_Name, id, path). |
| `zai.json` | Engine / Game Asset | Asset file storing serialized component state for `zai` (keys: m_Script, m_Name, id, path). |
| `zam.json` | Engine / Game Asset | Asset file storing serialized component state for `zam` (keys: m_Script, m_Name, id, path). |
| `zko.json` | Engine / Game Asset | Asset file storing serialized component state for `zko` (keys: m_Script, m_Name, id, path). |
| `zsh.json` | Engine / Game Asset | Asset file storing serialized component state for `zsh` (keys: m_Script, m_Name, id, path). |

---
