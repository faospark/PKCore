# Changelog

All notable changes to PKCore (formerly PKextended) are documented in this file.

---

## [2026.10.20]

- **Suikoden I Map Identifiers & Regional Breakdown Reference Guide**:
  - Authored complete architecture and geographic guide in [suikoden_1_map_ids_and_areas_breakdown.md](Documentation/suikoden_1_map_ids_and_areas_breakdown.md).
  - Documents all 12 regional sectors (`area_a` through `area_k`, `area_z`) and all 85 background maps (`bg_va1` through `bg_vz5`), mapped to their C# decompiled handlers (`G1_fdata_c.cs`, `VillageManager.cs`, `Village_c.cs`, `Event_c.cs`, `Fmain_c.cs`).
  - Cataloged the Suikoden 1 event command bytecode engine (`EVENT_COMMAND` enum with 70+ opcodes: `WINOP`, `WINCL`, `PUSHMARU`, `VILLAGEOUT`, `EVENTMSG`, `EVENTSHOP`, `EVENTITEM`, `EVENTBATTLE`, `PADD`, `PDEL`, etc.).
  - Side-by-side architectural comparison between Suikoden I and Suikoden II engine layers, detailing runtime coordinators, asset models, and PKCore Harmony hook targets.

- **High-Speed Symbol & Map Indexer Integration (`tools\sym.bat`)**:
  - Harmonized all 62 Suikoden II geographic areas and all 12 Suikoden I regional sectors (360 total map entries) directly into the SQLite symbol indexer database (`symbols.db`).
  - Added full map asset resolution in <1ms: querying by map ID (e.g. `vc18`, `va01`, `bg_va1`), area name (e.g. `Banner`, `Toto`, `Gregminster`), or region code instantly returns the C# handler class, source file location, documentation path, and narrative summary alongside types, members, and native addresses.
  - Added `--maps` CLI flag to filter queries strictly to map environments.
  - Integrated full FTS5 full-text indexing over map identifiers, area names, and narrative descriptions.

- **Human-Readable Field & Engine Legends across All 62 Geographic Area Volumes**:
  - Embedded the comprehensive **Field & Engine Legend** across all 62 area volumes in `Documentation/areas/` (`otyp`, `ozok`, `ano`, `disp`, `spd`, `wt`, `pri`, `etyp`, `eventForm`, `eventCom`).
  - Replaced all raw numerical opcodes across every trigger table with human-readable descriptions (`Display Dialogue Box`, `Warp Room`, `Open Save Crystal Menu`, `Recruit Character`, `Full Rest & Healing`, `Open Shop / Trade Interface`, `Add Character to Party`, `Adjust Potch Money`, `Play Sound Effect`, etc.).

- **Suikoden II Master Map Entities, Triggers & World Objects Catalog**:
  - Authored comprehensive technical documentation in [suikoden_2_master_map_entities_and_triggers_catalog.md](Documentation/suikoden_2_master_map_entities_and_triggers_catalog.md).
  - Documents the complete runtime entity architecture across all 226 master map assets (`va01` through `vk37`), compiling census data for all **4,901 NPCs**, **1,552 Dynamic Props**, **3,207 Collision Triggers & Single-Tile Dots**, **90 Save Orbs**, and **27 Dungeon Chest Clusters**.
  - **Bit-Level Entity Layout (`EVENT_OBJ`)**: Exhaustive mapping of all 13 physical fields (`otyp`, `disp`, `spd`, `wt`, `ano`, `ityp`, `fpno`, `ozok`, `pri`, `x`, `y`, `w`, `h`), explaining solid vs passable masks (`ozok`), facing frames, multi-tile bounding volumes, and single-tile dots (`w:0, h:0`).
  - **Trigger Evaluation Modes (`etyp`)**: Documents the 4 execution contexts: `etyp = 1` (Action/Confirm inspect), `etyp = 2` (Room Init / `OnMapLoad`), `etyp = 3` (Step-On Tripwire / Warp), and `etyp = 4` (Continuous Frame Loop).
  - **Condition Bytecode (`eventForm`)**: Full parameter specifications for condition opcodes (Story flags `3`/`4`, spatial boxes `1`, orientation `2`, target matching `5`, inventory `6`, party members `10`/`11`, treasure bits `27`/`28`, castle tiers `30`).
  - **Master Action Command Catalog (`eventCom`)**: Cataloged all 147 `EC*` action methods in `EVENTCON.eventCommandFunction` (dialogue, camera tracking, screens, movement, pathfinding, warp transitions, shop overlays, party recruitment, stat buffs, potch, and battles).
  - **In-Memory Injection Pattern**: Established the verified Harmony postfix blueprint on `MACHICON.EventInit` to dynamically expand `eventobj` and `eventdat` arrays at runtime, enabling modders to add custom actors, bonsai props, trigger dots, and shops without repacking Unity asset bundles.

- **Suikoden II Bathhouse Unisex Routing Restoration (Simone & Vincent)**:
  - Updated [NPCBathVisitorPatch.cs](Patches/NPCBathVisitorPatch.cs) to preserve the special gender code `2` for **Vincent de Boule** (ID 64) and **Simone Verdricci** (ID 65).
  - In vanilla Suikoden II, `EventOverlayClass.f_main$$GetFuroPos` evaluates gender code `2` at `0x18201a861` (Case 2): when no female party members are present, both Vincent and Simone are routed to **Positions 6..11** (the women's tub on the left side of the bathhouse), allowing them to bathe on the other side. If female party members are present, they join the men's tub (positions 0..5).
  - Fixed an overly strict binary check in `GetSeibetu_Prefix` that previously forced both characters to `0` (strictly Male).

- **Suikoden II Bathhouse Grounding: Ridley & Boris, Gadget, and Beasts Native Architecture**:
  - **Ridley & Boris Men's Side Routing**: Fixed a catalog error where ID 123 (Boris) was previously listed in `FemaleCharaIds` / `FemaleCastleNPCs`. Removed 123 from female pools, and added Ridley (IDs 118, 121) and Boris (ID 123) to `MaleCastleNPCs`, guaranteeing they both soak on the men's side (Positions 0..5).
  - **Native Gadget Implementation (ID 26)**: Grounded native hardcoded check at `0x18201ac20` in `EventOverlayClass.f_main$$GetSeibetu` (`cmp ebx, 0x1a -> xor eax, eax`) returning `0` (Male), giving Meg's barrel robot dedicated tub graphics in `hp_furo_26_atlas` on the men's side.
  - **Native Beasts Architecture**: Corrected documentation in [suikoden_2_character_attributes_gender_and_baths.md](Documentation/suikoden_2_character_attributes_gender_and_baths.md). All recruited beasts and monsters (Abizboah, Rulodia, Chuchara, Feather, Siegfried, Shiro, Mukumuku) have native bathhouse implementations, authentic sprite atlases via `(chara_id - 1)/5` indexing, and routing through the native gender jump table at `0x18201ac84`.

- **Suikoden II Bathhouse Grounding: Tenkou (99) and Teresa (95/102) Sprite Reclassification & Tub Routing**:
  - **Visual Sprite Verification**: Extracted and verified sprite blocks across `hp_furo_17_atlas` through `hp_furo_22_atlas`:
    - **Tenkou (ID 99)**: Visual cross-correlation confirmed ID 99 (`hp_furo_19_atlas` slot 3) is the bearded man with the gold headband (Tenkou). Previously miscataloged under female pools, causing him to appear in the women's tub. Reclassified ID 99 to `MaleCastleNPCs` and `PermanentCastleMales`, ensuring he routes strictly to the men's tub (Positions 0..5).
    - **Teresa Wisemail (ID 95 / 102)**: Visual inspection of `hp_furo_18_atlas` slot 4 verified the dark green haired female sprite (Teresa Wisemail). ID 95 was previously miscategorized in `MaleCastleNPCs`, causing her to appear in the men's tub. Reclassified ID 95 and ID 102 (blonde/light-green hair) to `FemaleCharaIds`, `FemaleCastleNPCs`, and `PermanentCastleFemales`, ensuring they route strictly to the women's tub (Positions 6..11).
    - **Male NPC Reclassifications**: Reclassified ID 91 (bare-chested young man), ID 94 (bare-chested spiky-haired man), and ID 97 (green-hat boy) to `MaleCastleNPCs`.
  - **Runtime Tub Placement Logging**: Added `GetFuroPos_Postfix` hook to log exact character ID and tub assignments (`Men's tub` vs `Women's tub`) to `LogOutput.log`. Unconditionally logged visitor selection in `PrepareBathParty` for runtime clarity.

## [2026.10.19]

- **Suikoden II NPC Bathhouse Sprites & Castle Visitors Restoration**:
  - Implemented in [NPCBathVisitorPatch.cs](Patches/NPCBathVisitorPatch.cs).
  - Restores the unused bathhouse sprites drawn for non-combatant castle recruits and story characters (stored across texture atlases `hp_furo_00_atlas` through `hp_furo_37_atlas`).
  - **Eliminated the Engine Crash Traps**:
    - **P_GRAPH_DATA Null Trap (`CreateFuroChara` at `0x182016059`)**: Disassembled and resolved the fatal null-dereference check in `EventOverlayClass.f_main$$CreateFuroChara` where non-combatants lacking combat `battle_data` and `field_data` triggered an immediate `NullReferenceException` crash (`0x182016725`). Hooked `G2_SYS.G2_gra_dat` to supply a lightweight dummy `P_GRAPH_DATA` fallback while inside the bathhouse, allowing all characters to render safely through `CreateFuroAnime` without altering any combat systems.
    - **Equipment Scan Bounds Trap (`CreateFuroEquipAnime` & `G2_varia_dat`)**: Disassembled `EventOverlayClass.f_main$$CheckfuroItemEquip` and `G2_SYS$$G2_varia_dat`. In Suikoden II, variable player stats (`c_varia_dat`) only exist for combat characters (IDs 0..82). When `CreateFuroEquipAnime` scanned bath accessory equipment for NPCs (`ID >= 83`), `G2_varia_dat` threw `System.IndexOutOfRangeException`. Added bounds-guard prefixes to `G2_varia_dat` and `CheckfuroItemEquip` to return `null` / `0` for any non-combatant, completely extinguishing the log exception.
  - **Convoy Slot Inclusion**:
    - Extends bath party evaluation to include the convoy slot (`party_data.party_cha_no[6]`). Any character placed in the convoy (via story progression or save editors) is automatically included in the bathhouse session.
  - **Gender Identification Hook (`f_main.GetSeibetu` at `0x18201ab90`)**:
    - Disassembled `EventOverlayClass.f_main$$GetSeibetu` and identified that vanilla queries `ckd_info[chara_id][1] & 0xf`. This revealed two major engine data flaws:
      1. **NPC Gender Zeroing**: Non-combatant castle NPCs have no combat equipment attributes (`ckd_info` zeroed), causing `GetSeibetu` to evaluate to `0` (Male) for all NPCs (routing women like Apple, Leona, Barbara, Teresa, and Pilika to the men's tub).
      2. **Vanilla Male Data Misclassifications**: Konami's original data tables assigned female attribute bitmasks (`0x21` / `val = 1` or `4`) to several male combatants, notably **Bob** (`player_bic`, ID 4), **Chaco** (`player_zko`, ID 17), **General Kiba** (ID 86), and **Alex** (ID 103), causing Bob and Chaco to be misplaced into the women's tub behind the partition.
    - Added a comprehensive Harmony prefix to `f_main.GetSeibetu` using verified ground-truth GSD2 character IDs (`player_*.json`). Strictly maps all canonical female characters (Nanami [18], Eilie [19], Rina [20], Nina [55], Tengaar [8], Millie [24], Meg [25], Karen [14], Kasumi [41/73], Valeria [12], Anita [39], Ayda [43], Sierra [42/45], Oulan [46], Tomo [57], Viki [60], Wakaba [68], Hanna [23], Mikumiku [83], Rulodia [71], Apple [84/85], Teresa [91], Leona [94], Barbara [96], Jeane [97], Yuzu [98], Taki [99], Pilika [100/123/124], Emilia [101/102], Hilda [104], Raura [105]) to `1` (Female), while strictly classifying all other characters (including Bob [4], Chaco [17], Kiba [86], and Alex [103]) as `0` (Male).
    - Guarantees that Bob and male companions always bathe in the men's tub (positions 0..5), female bathers are placed in the women's tub (positions 6..11), and peeping interactions accurately register female bathers.
  - **Balanced Castle NPC Visitor Pool & Guaranteed Female Representation**:
    - Segregated candidates into dedicated female and male recruited star pools (`FemaleCastleNPCs` and `MaleCastleNPCs`).
    - If the player enters the bathhouse with no female party members present, the first unoccupied slot is guaranteed to select a female castle recruit (e.g. Apple, Leona, Barbara, Teresa, Jeane, Pilika, etc.), ensuring the women's tub is never empty.
    - Unoccupied slots alternate between male and female visitors so both sides of the bathhouse are populated simultaneously.
  - **Zero Save-Data Footprint**:
    - Party slots are substituted strictly in memory for the duration of the bath session and cleanly restored back to the player's exact party configuration upon bath exit (`f_main.FuroEnd`).
  - Master configuration toggle under `[05 Game : Suikoden 2]`:
    - `EnableNPCBathVisitors` (Default: `true`)
  - **Full 8-Character Bathhouse Expansion (+2 Convoy & Castle Visitor Slots)**:
    - Disassembled `EventOverlayClass.f_main$$CreateFuroChara`, `GetFuroPos`, and `furo_h.FURO_WORK$$ctor` (`0x181ff5cf0`).
    - Discovered that the entire bathhouse engine in Suikoden II was architecturally engineered for **8 actors**: all internal character tracking structures (`furo_pos_data`, `furo_chara_id`, `furo_chara_info`, `furo_chara_palette`, `chara_status`, `FuroInit` loop `0x182019956`) are sized for 8 characters across 12 tub positions (0..5 men's tub, 6..11 women's tub).
    - Vanilla was artificially capped at 6 bathers because `CreateFuroChara` and `GetFuroPos` invoked `G2_SYS.G2_pamem_num(0)`, which only counts battle slots (`0..5`), completely ignoring convoy slots (`6..7`).
    - Hooked `G2_SYS.G2_pamem_num` during bath sessions to count all active non-zero characters across all 8 slots (`party_cha_no[0..7]`), unlocking the full 8-character bathhouse capacity.
    - `PrepareBathParty` now scans and populates all 8 slots (`0..7`). Even when entering with a full 6-character combat party, slots 6 and 7 (+2 over party count) are filled with recruited castle companions or convoy members, allowing up to 8 characters to soak together.
    - If entering with fewer than 6 combat members (e.g. Riou alone), all empty slots across 1..7 are filled with castle recruits, balanced between male and female visitors so both the men's and women's tubs are populated with up to 8 companions.
  - **Permanent Castle Facility Candidates & Balanced Visitor Pool**:
    - Recruited candidates are segregated into `FemaleCastleNPCs` and `MaleCastleNPCs`.
    - Added guaranteed inclusion for permanent castle facility residents (**Apple [85]**, **Leona [94]**, **Barbara [96]**, and **Pilika [100]** for women; **Hauser [86]** and **Richmond [93]** for men) who reside at HQ without requiring standard Star of Destiny recruitment flags (`G2_cha_flag`), guaranteeing the female candidate pool never runs out.
    - Unoccupied bath slots alternate between female and male companions to evenly balance both the men's tub (right side) and women's tub (left side) up to 8 total bathers.
  - **Character ID Corrections (Tenkou, Adlai, Templeton & Apple)**:
    - Verified exact ID mappings against game character and asset schemas:
      - **Tenkou** (ID 104) & **Adlai** (ID 105): Canonical male recruits (window maker and elevator inventor) who were mistakenly placed under `FemaleCharaIds` / `FemaleCastleNPCs`, causing them to soak in the women's tub. Removed from female lists and reclassified into `MaleCastleNPCs`.
      - **Templeton** (ID 101, `player_tel_d.json`): Male cartographer, previously miscataloged under female IDs, which caused him to soak in the women's tub. Corrected to `MaleCastleNPCs`.
      - **Apple** (ID 85, `player_app_d.json`): Female convoy strategist, previously misclassified under `MaleCastleNPCs`. Corrected to `FemaleCastleNPCs`.
  - **Recruitment Flag Bounds Guard (`SafeIsRecruited`)**:
    - Preemptively validates candidate ID bounds (`npcId <= 108`) before querying `G2_SYS.G2_cha_flag(2, npcId)`, completely extinguishing the `IndexOutOfRangeException` thrown when scanning characters with IDs beyond the 108 Stars table.
  - Complete technical documentation and binary disassembly notes recorded in [suikoden_2_character_attributes_gender_and_baths.md](Documentation/suikoden_2_character_attributes_gender_and_baths.md).

- **High-Speed Decompiled Symbol Indexer & Query CLI**:
  - Implemented high-performance symbol indexing and sub-millisecond query tooling for decompiled C# sources and native IL2CPP symbol tables in `tools/symbol_indexer/`.
  - **Comprehensive Multi-Target Coverage**:
    - **Suikoden 1 (GSD1)**: 445 decompiled C# files.
    - **Suikoden 2 (GSD2)**: 1,483 decompiled C# files.
    - **Shared Engine (GSDShare)**: 354 decompiled C# files.
    - **Native IL2CPP Symbols (`symbols.txt`)**: 189,523 native function and method address mappings.
    - Total cataloged inventory: 6,147 types, 259,139 members (methods, properties, fields), and 189,523 virtual memory addresses.
  - **High-Performance Architecture (`indexer.py` & `sym.py`)**:
    - **Streamlined SQLite Backend (`symbols.db`)**: Indexed B-Trees and SQLite memory-mapping (`PRAGMA mmap_size = 256MB`) delivering query execution speeds between 0.5ms and 3ms.
    - **Full-Text Search (FTS5)**: Integrated FTS5 virtual tables for rapid prefix, substring, and wildcard matching across all games.
    - **Hex Address Resolution**: Resolves any IL2CPP memory address (e.g. `0x1818bb190`) directly to its native symbol (`MACHICON$$EventInit`) and pairs it with the decompiled C# source file and line (`MACHICON.cs#L947`).
    - **Type Inspection (`-m` / `--members`)**: Dumps all members of any class or struct with signatures, native addresses, and line numbers.
    - **Fine-Grained Filtering**: Supports game scoping (`--gsd1`, `--gsd2`, `--share`), kind scoping (`--methods`, `--fields`, `--props`, `--types`, `--native`), and JSON formatting (`--json`).
  - **Batch Convenience Wrapper**:
    - Created `tools/sym.bat` for seamless command-line queries directly from the PKCore root workspace.
  - **Hand-in-Hand Workflow with REA (Reverse Engineer Anything)**:
    - Integrated multi-phase reverse engineering protocol: use `sym.bat` to instantly anchor C# types and IL2CPP memory addresses, feed virtual addresses directly into REA for binary disassembly/pseudocode analysis, cross-correlate discovered sub-procedure calls back into `sym.bat`, and write grounded Harmony patches.
  - Complete technical documentation added in [symbol_indexer_guide.md](Documentation/symbol_indexer_guide.md).

---

## [2026.10.18]

- **Battle Enemy HP Display & Expanded Target Selection Window (Suikoden I & II)**:
  - Enhanced [BattleEnemyLevelPatch.cs](Patches/BattleEnemyLevelPatch.cs) to display both current and maximum enemy HP on a new line beneath the enemy name and level (e.g. `Bonapart Lv.25\nHP 120/120`).
  - Implemented live enemy HP retrieval across combatants:
    - **Suikoden I**: Reads live HP and Max HP from `GSD1::BattleBase.battle_work.pm_data` with fallback to `monster_data_table` base parameters.
    - **Suikoden II**: Reads live HP (`pm.hp`) and Max HP (`pm.max_hp` / `pm.monster_data.hp`) directly from `GSD2::BattleManager.Instance.battle_work.pm_data` across front and back row formation slots.
  - **Expanded Monster Window Container Width (+50%)**:
    - Automatically widens `UIBattleWindowMonster`, its game-specific sub-layouts (`m_GS1Layout`, `m_GS2Layout`, `m_GS2BackLayout`), and child background frames by 50% (`1.5x` multiplier) to prevent text clipping and cramped layouts.
    - Proportionally widens each target selection cell (`UIWindowListCell.rectTransform`) and text component (`leftText.rectTransform`).
    - Intelligently scales and redistributes column horizontal positions (`anchoredPosition.x`) across both center-anchored and offset-anchored multi-column grids (such as Suikoden II's 2x3 target grid), as well as auto-layout groups (`GridLayoutGroup.cellSize` and `spacing`).
    - Configures TextMeshPro multi-line rendering with auto-sizing (`fontSizeMin = 10f`, `fontSizeMax = 18f`), hard newline separation (`enableWordWrapping = false`), and `TextOverflowModes.Overflow` to guarantee full, crisp visibility for multi-line stats.
  - Added dedicated configuration settings under `[02 User Interface]`:
    - `ShowEnemyHpInBattle` (Default: `true`)
    - `MonsterWindowWidthScale` (Default: `1.5`, range `1.0`-`2.0`)

- **Smart After-Battle Auto-Healing (Suikoden II)**:
  - Implemented in [SmartHealingPatch.cs](Patches/SmartHealingPatch.cs).
  - Automatically assesses party status and consumes restorative items after battle across a multi-phase recovery pipeline:
    - **Sacrificial Jizo Fallen Revival**: Detects knocked-out (0 HP) party members and revives them using Sacrificial Jizo (Item #30) from the shared party bag or living party members' personal inventories. Restores fallen characters to 50% max HP, clears KO/dead status flags (`dead_flg`), and clears negative battle status so they can be further healed.
    - **Antitoxin Poison Curing**: Scans all party members (including newly revived characters) and administers Antitoxin (Item #5) from the party bag or personal inventories to cure Poison (`G2_SYS.G2_poison(2, 0, slot)` and battle status flags).
    - **Smart HP Deficit Recovery**: Prioritizes living damaged members by lowest HP percentage first. Automatically selects the best-fit item: regular Medicine (+100 HP) for smaller wounds, Mega Medicine (+500 HP) for deficits $\ge 300$ HP, and Healing Wind (Wind Card 2 / scroll, +999 HP full heal) for massive wounds ($\ge 600$ HP).
    - **Overheal Waste Protection**: Guards rare Mega Medicine and Healing Wind from being wasted on minor scratches ($< 250$ HP deficit for Mega Medicine, $< 400$ HP deficit for Healing Wind). Ignores trivial chip damage below 20 HP deficit.
    - **Inventory Compaction**: Automatically compacts the shared Party Bag when items are fully consumed to avoid empty gaps in inventory slots.
    - **Battle Exit Latching**: Hooks `BattleManager.calc_exp`, `BattleManager.StorePlayerData`, `BattleManager.exit_sub00`, and `BattleManager.battle_exit99` with a one-shot latch to ensure seamless HP synchronization (`G2_SYS.G2_pamem_hp`, `C_VARIA_DAT.now_hp`, and `BattlePlayerCharacter.hp`) regardless of victory or escape.
  - Controlled via a single master toggle under `[05 Game : Suikoden 2]`:
    - `EnableSmartHealing` (Default: `true`)

- **Suikoden II Map Identifiers & Geographic Areas Architectural Reference**:
  - Migrated and integrated master map identifier documentation [suikoden_2_map_ids_and_areas_breakdown.md](Documentation/suikoden_2_map_ids_and_areas_breakdown.md) into PKCore.
  - Documents the anatomy of the 4-character venue naming system (`v` + region letter `a`-`k` + map number `01`-`37`), submap layout (`_00`, `_01`, `_obj`, `_map_00`), dialog message ID encoding formulas (`100` + region + map + offset), and provides an exhaustive cross-reference table against active PKCore patches ([GenshuRecruitmentPatch.cs](Patches/GenshuRecruitmentPatch.cs), [VincentRecruitmentPatch.cs](Patches/VincentRecruitmentPatch.cs), [GreenhillMatildaBorderPatch.cs](Patches/GreenhillMatildaBorderPatch.cs), [SajahShopUnlockPatch.cs](Patches/SajahShopUnlockPatch.cs), [TenzanPassEncounterPatch.cs](Patches/TenzanPassEncounterPatch.cs)).
- **Memory Auto-Battle (Suikoden II)**:
  - Implemented in [MemoryAutoBattlePatch.cs](Patches/MemoryAutoBattlePatch.cs).
  - Remembers the last manually chosen action per character (Attack vs Rune/Magic) and automatically replays it during Auto-Battle (Omakase / おまかせ) instead of forcing basic physical attacks.
  - Automatically verifies MP levels, status ailments (silence, sleep, death), and rune usability before casting, gracefully falling back to basic physical attacks if resources are depleted.
  - Configured under `[05 Game : Suikoden 2]`:
    - `EnableMemoryAutoBattle` (Default: `true`) — Remembers last actions and persists across battles.
- **Tenzan Pass Chimera Encounters & Cyclone Rune Drop Restoration (Suikoden II)**:
  - Implemented in [TenzanPassEncounterPatch.cs](Patches/TenzanPassEncounterPatch.cs) with technical architecture documented in [tenzan_pass_chimera_va11.md](Documentation/tenzan_pass_chimera_va11.md).
  - Restores the omitted Chimera encounters (Parties 6, 7, and 8) in Tenzan Pass (`va11`), resolving a 25-year bug dating back to the original PS1 release where the 10-slot encounter table omitted them in favor of duplicates.
  - Recreates Pyriel's community fix layout by substituting duplicate slots 1, 3, and 6 with:
    - **Slot 1 (Party 6)**: Chimera Solo (1 Chimera, centered at front row position 1).
    - **Slot 3 (Party 7)**: Chimera + Magus x 2 (Chimera centered, flanked by 2 Magus at positions 0 and 2).
    - **Slot 6 (Party 8)**: Chimera + Minotaurus (Chimera at position 1, Minotaurus at position 0).
    - Results in an authentic ~30% encounter rate in Tenzan Pass.
  - **HD Remaster Engine Crash Prevention**:
    - Overcomes an engine bug in the Remaster where `monster_data` was hardcoded to a 3-element array, which crashed the game with `IndexOutOfRangeException` whenever Chimera (MID 3) spawned.
    - Dynamically expands `monster_data` to a safe 4-element structure across `MACHICON.EventInit`, `BattleManager.BattleDataSetup`, and `BattleManager.InitNewMonster`.
    - Supplies canonical 18-element 3D battlefield grid coordinates (`monster_position`) for every formation, preventing camera and position lockups.
  - **Cyclone Rune Drop & Loot Integration**:
    - Configures guaranteed or customizable Cyclone Rune drops (`use_cnt = 0x20` [Category 2 = `embl_data`], `item_no = 6` [Cyclone Orb]) on Chimera.
    - Hooks post-battle loot calculation (`BattleManager.get_monster_okane`) and fallback item delivery (`BattleManager.b_OverlayAddItem2Init`) so that defeating a Chimera awards the Cyclone Rune directly into `battle_work.exit_work.monster_item`, seamlessly triggering the item fanfare, dialogue, and inventory addition.
  - **Runtime In-Memory Patching**:
    - Operates entirely in memory via `[HarmonyPatch(typeof(MACHICON), "EventInit")]` without modifying or repacking any `.bundle` asset files, providing complete resilience against official game updates.
  - Added configuration options under `[05 Game : Suikoden 2]`:
    - `EnableTenzanChimeraFix` (Default: `true`)
    - `ForceTenzanChimeraEncounter` (Default: `false` - debug/testing option to force 100% Chimera encounters in Tenzan Pass)
    - `TenzanChimeraCycloneDropRate` (Default: `100`, range 1-100% - configurable drop chance upon victory)
- **Sajah Village Rare Shop & Rune Sage Early Access Unlock (Suikoden II)**:
  - Implemented in [SajahShopUnlockPatch.cs](Patches/SajahShopUnlockPatch.cs) with technical architecture documented in [sajah_village_rare_shop_vj17.md](Documentation/sajah_village_rare_shop_vj17.md).
  - Unlocks the hidden late-game rare item and rune sage vendor located in the upper-right corner of the multi-shop building in Sajah Village (`vj17` / `vj17_01`), bypassing the vanilla Story Flag 143 requirement (Beast Rune defeated).
  - Follows the in-memory map patching pattern by hooking `MACHICON.EventInit` Postfix when loading Sajah Village:
    - Forces the vendor NPC sprite visible (`mapeventdat[1].eventobj[3].disp = 1`).
    - Activates the counter interaction hitbox (`mapeventdat[1].eventobj[7].disp = 1`).
    - Neutralizes the room initialization script (`mapeventdat[1].eventdat[2].eventForm = new byte[] { 0, 255, 254 }`), preventing the game engine from re-hiding the vendor if flag 143 is off.
    - Rewrites the talk interaction scripts (`eventdat[10]` and `eventdat[11]`) to bypass flag 143 (`{ 5, 11, 255, 254 }` and `{ 5, 15, 255, 254 }`), opening the rare item vendor interface and inventory immediately upon visiting Sajah Village.
  - Operates completely in memory with zero asset bundle extraction or UABEA repacking required.
  - Added configuration option under `[05 Game : Suikoden 2]`:
    - `UnlockSajahRareShopEarly` (Default: `true`)

---

## [2026.10.05]

- **Battle Enemy Level Display (Suikoden I & II)**:
  - Created [BattleEnemyLevelPatch.cs](Patches/BattleEnemyLevelPatch.cs) to display enemy levels in the battle target selection window (e.g. `Bonapart Lv.25`, `Highland Captain Lv.34`).
  - Implemented automatic level lookup from active battle combatants across both games:
    - **Suikoden I**: Reads `GSD1::BattleBase.battle_work` and `window_work` position mappings to retrieve monster levels from `monster_data_table`.
    - **Suikoden II**: Reads `GSD2::BattleParty` and `PM_DATA.monster_data.level` with front/back row formation slot indexing.
  - Dynamically configures TextMeshPro auto-sizing on the monster selection cell text (`leftText`) with single-line clamping (`enableWordWrapping = false`, `fontSizeMin = 13f`) to prevent truncation or line wrapping on longer enemy names.
  - Configurable via `ShowEnemyLevelInBattle` under `[02 User Interface]` (enabled by default).
- **Unlimited & Reusable Command Runes in Battle (Suikoden II)**:
  - Created [CommandRuneUnlimitedPatch.cs](Patches/CommandRuneUnlimitedPatch.cs) to remove the 1-use-per-battle lockouts on unique ability command runes:
    - **Meg & Gadget**: Trick / Gadget Rune (からくりの紋章 / Windup Doll ATK) is now reusable every turn.
    - **Millie & Bonaparte**: Groundhog Rune (モグラの紋章) is now reusable every turn.
    - **Shin**: Spider Slay Rune (八房の紋章 / 蜘蛛斬り) is now reusable every turn.
    - **Oulan**: Angry Dragon Rune (怒竜の紋章 / 狂竜 / 激怒) is now permanently available across every battle turn without requiring damage-triggered Fury or losing Fury status after execution.
  - Implemented multi-layered battle engine overrides:
    - Hooked `BattleManager.GetEmblMagicNum` and `PM_DATA.SpecialCanCheck` to enforce valid ability usage counts across turns.
    - Automatic `C_VARIA_DAT.mp` replenishment and `w_battle.tokusyu_sel_kaisu` / `tokusyu_sel_flag` state refresh during battle turn cycles.
    - Hooked `BattlePlayerCharacter.CalcIkariEnd` and `PlayerStatusClear` to preserve Oulan's Fury state (`0x20`).
  - Added dedicated BepInEx configuration options under `[05 Game : Suikoden 2]`:
    - `EnableUnlimitedCommandRunes` (Default: `true`)
    - `UnlimitedTrickRune` (Default: `true`)
    - `UnlimitedGroundhogRune` (Default: `true`)
    - `UnlimitedSpiderSlayRune` (Default: `true`)
    - `AlwaysAvailableAngryDragon` (Default: `true`)
- **Rune Unbalance Removal (Suikoden II)**:
  - Created [RuneUnbalancePatch.cs](Patches/RuneUnbalancePatch.cs) to disable the Unbalance status penalty and dizzy stars animation on physical ability runes (e.g. Titan, Falcon, Viper, Shrike, Swallow, Trick, Fire Breath, Mayfly, Lion, Unicorn, Pixie, Blue Drop).
- **Battle Party Max HP Display (Suikoden I & II)**:
  - Added configurable current / max HP display (`ShowBattleMaxHP`) in the battle party status window (e.g. `587/587` instead of just `587`).
  - Enabled dynamic auto-sizing on the HP text mesh (`m_hpText`) to ensure clean alignment without clipping or overflow on larger values (e.g. `999/999`).
- **Summon & Battle Magic Stutter Fix (Suikoden II)**:
  - Resolved severe frame drops, memory spikes, and crashes when casting summon spells (e.g. Pale Gate Rune) by removing intrusive Il2Cpp effect hooks and running summon animations natively.
- **Texture Engine Memory & Performance Fixes**:
  - Fixed a memory leak where temporary DDS textures accumulated in memory during gameplay.
  - Added in-memory file byte caching (`rawFileBytesCache`) to accelerate texture loading and eliminate duplicate disk I/O.
- **Battle Window Diagnostic Suite**:
  - Added internal runtime inspection tools (`BattleUnitWindowDiagnostics`) to diagnose battle party window hierarchies and UI text components across both games.

---

## [2026.09.15]

- **Battle Position Adjustments (Suikoden II)**:
  - Added configurable 6-character party formation spacing via `EnableBattlePositionAdjustments` and `S2BattlePositionPreset` (`wide`, `widest`, `default`).
  - Adjusts front/back row spacing and vertical slot offsets during Suikoden II battles so that back-row characters do not visually obstruct front-row party members.
  - Added `LogBattlePositions` diagnostics setting (disabled by default) to suppress verbose coordinate/offset logs unless explicitly enabled for debugging.
- **Character Battle Range Overrides (Suikoden II)**:
  - Added configurable weapon range modification via `S2CharacterRangeOverrides` in `BepInEx/config/faospark.pkcore.cfg` (enabled by `EnableCharacterRangeOverrides`).
  - Default enhancements change **Kasumi, Luc, Mazus, Viki, Gantetsu, Badeaux, and Sierra** from Short (`S`) to Medium (`M`) Range, allowing them to attack with physical weapons directly from the back row.
  - Automatically synchronizes `fcommand.range`, `s_phase.arms_range`, `G2_arms_range`, and native `arms_data` memory tables across battle, formation, tavern, and status UI screens.
  - Resolved party formation warnings (removes red `[X]` / `S` indicator over back-row platforms in Castle Tavern) and displays `M` in the Status menu.

- **Save Slot Party Member Portraits (Suikoden I & II)**:
  - Added visual party member mini portraits next to character level (`Txt_Lv`) in save and load menu slots (`ShowSaveSlotPartyPortraits` configuration option).
  - High-performance in-memory portrait caching ensuring 0ms lookups after initial load, prioritizing crisp custom textures from `PKCore/Textures/` over native sprites.
  - **Suikoden I Integration**:
    - Hooked `UISaveLoad1.Init` and dynamic slot virtualization (`UISaveLoadSlot.UpdateItem` / `UISaveLoadBase.OnUpdateItem`).
    - Resolved party member codes (`chara_code`) across in-memory save data (`UISaveLoad1.Inst.saveDataList`), native temp saves (`SaveDataManager.TmpSavePath`), and decrypted JSON fallbacks.
    - Integrated `Ws_face_c.CharacterIDConvertToFaceIDStatic` for character ID to Face ID mapping to support standard Suikoden I portrait indexing (e.g. `fp_gsd1_000` for Joshua Levenheit, Tir McDohl, etc.).
    - Added textured candidate resolution supporting `fp_gsd1_{faceId:D3}`, `fp_gsd1_{faceId}`, `fp_{faceId:D3}`, and `fp_gsd1_{charId:D3}` variants.
  - **Suikoden II Integration**:
    - Hooked `UISaveLoad2.Init` and party member array (`party_cha_no`) via `UISaveLoad2.Inst.saveDataList`, `GSD2SaveData.TmpSavePath`, and native `ImageLoader` fallback.
  - Isolated cached portrait keys per game (`$"{game}_{charId}"`) to prevent portrait collisions between Suikoden I and Suikoden II during the same session.

- **Battle Engine & Targeting Stability**:
  - Removed intrusive `PM_DATA` check postfixes (`AttackCanCheck`, `MokuhyoCanCheck`, `CheckRowFormation`) to eliminate battle state machine freezes, enabling native enemy target selection and animation flow.
- **Live Configuration Hot-Reloading**:
  - Added real-time event listeners for `SettingChanged` on `S2CharacterRangeOverrides` and `EnableCharacterRangeOverrides`, allowing on-the-fly configuration updates via BepInEx Configuration Manager or UnityExplorer without restarting the game.
- **DDS Portrait Format & Directory Search (Fix for previous update oversight)**:
  - Fixed an issue where converting textures to `.dds` format in the previous update caused custom portraits and UI masks to stop loading (previously only `.png` was supported).
  - Added full DDS format support (BC1/BC3/BC7) to the NPC & Dialogue Portrait System using `AssetLoader`.
  - Added recursive directory searching across both `Portraits/` and `NPCPortraits/` subfolders within `Textures/GSD1/`, `Textures/GSD2/`, `Textures/`, and `00-Mods/`.
  - Preserved native in-game portraits in Event Viewer and cutscenes: missing custom emotion/expression variants will no longer overwrite original dialogue faces with question mark fallbacks (`fp_219`).
- **UI Mask Replacement Pipeline**:
  - Updated `DisablePortraitDialogMask.cs` to use the unified custom texture pipeline, adding DDS texture support for custom mask replacements.
- **Activation Log Spam Reduction**:
  - Deduplicated sprite and mesh texture replacement logging in `GameObjectPatch.cs` during background manager and scene activations to prevent repeated messages for duplicate environment assets (e.g. repeated trees).

---

## [2026.03.01] - 2026-03-22

- **PSP Launcher UI**:
  - Added `PSPLauncher` configuration option (off by default) to recreate the PSP Launcher interface.
- **Enhanced Gallery UI**:
  - Added `EnhancedGallery` configuration option (enabled by default) inspired by the PSP version to replace Movies, Events, and Sounds gallery backgrounds with custom textures independently of the PSP launcher mode.
- **BGM Replacement System**:
  - Added non-destructive Background Music replacement support for swapping music without modifying game files.
  - Place `.acb` / `.awb` audio files under `PKCore/00-Mods/<ModName>/Sound/`.
- **Better Launcher BGM**:
  - Included `BetterLauncherBGM` (enabled by default), replacing the launcher ambient music with Suikoden 2's adventure start theme as a reference implementation.
- **Modular 00-Mods Directory Structure**:
  - Relocated `00-Mods` to the root of PKCore for enhanced visibility and ease of use.
  - Expanded mod support beyond textures to include texture, sound, dialogue, and war battle customization packages.
  - Moved Suikoden 2 war battle assets to `PKS2` to allow individual toggling.
- **Suikoden 1 Dialogue & Portrait System**:
  - Full portrait injection support for Suikoden 1 with custom name display in dialog boxes for unnamed NPCs.
  - Fixed portrait display logic for named characters during story-based name changes (e.g. Kanaan and Viktor dialogue scenes).
  - Added custom portraits for Grady, Assassin (Iga), Rosh, Elder Dwarf (Durin), Elven Elder (Soveliss), Imperial Guard, and Zombie (Andie).
  - Split dialogue override loading per game (`TextDB_GSD1` / `TextDB_GSD2`) to prevent cross-game message ID collisions.
- **Visual & Location Polish**:
  - Foliage overhaul for Magician's Island.
  - Removed unnecessary mask overlays in Dragon's Den for improved visibility.
  - Transferred menu and object strings from Reworded+ into PKCore.
  - Converted performance-critical textures to `.dds` format.
  - Renamed `DisablePortraitDialogMaskPortraitDialog` to `DisablePortraitDialogMask`.
  - Revised Project Kyaro sprites for young Riou, Jowy, Nanami, Teo (1v1 duel sprite), and Kasios (instrument playing).

---

## [2026.02.2] - 2026-02-17

- **Dialogue Placeholders**:
  - Added dynamic parsing of text placeholders to reflect custom names of protagonists and headquarters from save files.
- **Texture Discovery & Logging**:
  - Restored `LogReplaceableTextures` configuration toggle to give users control over detailed log volume when logging text IDs.
  - Custom texture patch logging now outputs exact file index names instead of indexed variants.
  - Removed obsolete texture filename sanitization that previously caused hash collisions.
- **Portrait & Mask Refactoring**:
  - Renamed `NPCPortraits` class to `PortraitSystemPatch` to represent broader functionality.
  - Renamed `DisableMask` to `DisablePortraitDialogMask` for clarity.
  - Removed deprecated `ReactionMonitor`.
- **Window Management**:
  - Replaced internal borderless window patch with recommendation to use Unity's native `-popupwindow` launch parameter.
- **Suikoden 1 UI**:
  - Refined Suikoden 1 dialog scaling calculations.

---

## [2026.02.0] - 2026-02-09

- **Reaction Portrait UI**:
  - Enhanced visual presentation with smooth fade-in animation, removed purple background artifact, and standardized dimensions (300x300 at x:636.85, y:-262.34).
- **Log Spam Reduction**:
  - Suppressed `DisablePortraitDialogMask` log spam, routing messages only when `DetailedTextureLog` is active.
  - Coalesced repeated sprite variations in `GRSpriteRenderer` (e.g. `person_vj10_01_XX`) into single aggregated log entries.
- **Dialogue & Config Fixes**:
  - Fixed CS0029 compilation error in `ModConfiguration.cs`.
  - Removed obsolete dialog chaining functionality (Interceptor Pattern).
  - Reverted experimental multi-character support for Jowy's disguise.

---

## [2026.01.1] - 2026-02-05

- **World Map Visual Improvements**:
  - Disabled `sm_wk_cloud` objects to remove visual clutter and artifacts on the world map.
  - Corrected sunray glow rendering for consistent lighting.
- **Configuration Cleanup**:
  - Moved developer debug options (`LogReplaceableTextures`, `LogTexturePaths`) to internal hidden settings.
- **Caching Documentation**:
  - Updated `Caching.md` with technical documentation on priority layers, DDS compression handling, and memory persistence.

---

## [2026.01.0] - 2026-01-31

- **SpriteAtlas Loose File Interception**:
  - Implemented postfix interception for Unity SpriteAtlas, allowing runtime replacement of packed sprites using loose external texture files.
- **Minimal UI & Selective Filtering**:
  - Added `MinimalUI` boolean option to control minimal UI texture variant loading.
  - Implemented selective texture filtering system for Project Kyaro, Launcher, and Minimal UI assets.
  - Enhanced cache invalidation to track `MinimalUI` state.
- **UI Scaling & Dialog Simplification**:
  - Refactored `DialogBoxScale` to boolean `ScaleDownDialogBox` (`false` = normal, `true` = 80% compact size).
  - Improved `MenuTopPartyStatus` texture refresh with `UIMainMenu.Open` hook for proper atlas updating.
  - Enhanced menu transformation logic and footer container handling.
- **Performance & Diagnostics**:
  - Added `HashSet` tracking in `TextDatabasePatch` to eliminate duplicate runtime log entries.
  - Streamlined portrait directory scanning and loading performance.
  - Fixed save point replacement log message formatting.
  - Simplified battle sprite detection in `DisableSpritePostProcessingPatch`.
  - Upgraded core asset loader with asynchronous operations and DDS support.
- **Version Numbering**:
  - Adopted year-based versioning format (`YYYY.MM.MINOR`) for clearer release tracking.

---

## [2.1.0] - 2026-01-23

- **Native DDS Support**:
  - Pre-compressed `.dds` (BC1/BC3/BC7) texture loading for reduced VRAM usage and faster startup times.
- **Manifest Caching**:
  - XML-based texture index cache system dramatically reducing startup loading times.
- **SMAA Anti-Aliasing**:
  - High-quality Subpixel Morphological Anti-Aliasing applied to the main camera (`SMAAQuality`).
- **Custom NPC Portraits & Dialogue Overrides**:
  - High-resolution portrait injection system for NPCs lacking base-game portraits (`PKCore/NPCPortraits/`).
  - JSON-based dialogue replacement system with custom speaker injection via `<speaker:Name>` tags.
- **Visual Enhancements**:
  - Portrait mask removal (`DisablePortraitDialogMask`) disabling the `Face_Mask_01` overlay.
  - Restored full color to Suikoden 2 intros and flashbacks (`ColoredIntroAndFlashbacks`).
  - Classic PSX-style fullscreen Save/Load interface for Suikoden 2 (`ClassicSaveWindow`).
  - Save point customization with 5 color options (`SavePointColor`) and glow toggle (`DisableSavePointGlow`).
- **Specialized Suikoden 2 Support**:
  - `SummonMonitor` system for replacing summon effect textures (`Eff_tex_Summon_*`).
  - Configurable war battle character stats and abilities via `PKCore/Config/S2WarAbilities.json`.
  - Texture variants for Tir's running animation (`TirRunTexture`) and Mercenary Fortress fence (`MercFortFence`).
- **UI Scaling**:
  - Compact dialog box sizing (`ScaleDownDialogBox`) and compact main menu layout (`ScaledDownMenu`).
  - Borderless fullscreen window mode and cursor visibility toggle (`ShowMouseCursor`).
- **Static Object Insertion**:
  - Framework for inserting static objects into scenes via `fixed_objects.json`.

---

## [2.0.0] - 2025-12-23

- **Save Point Customization**:
  - 5 selectable color options (blue, red, yellow, pink, green, default) via `SavePointColor` with automatic fallback.
  - Option to disable save point orb glow effect via `DisableSavePointGlow`.
- **Config-Aware Manifest Caching**:
  - Texture cache tracks configuration changes (`LoadLauncherUITextures`, `SavePointColor`, `EnableProjectKyaroSprites`) and automatically rebuilds without requiring manual file deletion.
- **Centralized Texture Variant System**:
  - Added unified `TextureOptions.GetTextureNameWithVariant()` handler for organized texture variant lookup.

---

## [1.6.0] - 2025-12-20

- **Project Rebranding**:
  - Rebranded from `PKextended` (`faospark.pkextended`) to **`PKCore`** (`faospark.pkcore`).
  - Updated paths: `BepInEx/plugins/PKCore/Textures/` and `PKCore.dll`.
- **Priority Override System**:
  - Added `00-Mods/` root folder with highest priority over base textures, allowing modular add-on packs.
- **Logging Optimizations**:
  - Deduplicated texture replacement logs to log only once per texture.
  - Startup shows aggregate indexed count instead of listing every file (detailed list available when `DetailedLogs = true`).
- **Bath Backgrounds**:
  - Added support for custom bath background sprite replacement.

---

## [1.5.0 - 1.5.1] - 2025-12-16

- **Custom PNG/JPG/TGA Texture Replacement**:
  - Runtime texture injection for UI elements, event backgrounds, and static sprites.
  - Automatic subfolder scanning under `PKCore/Textures/`.
  - Added `LogReplaceableTextures` discovery helper to inspect replaceable sprite names.
- **Controller Prompt Override System**:
  - Global button prompt override for PlayStation 4 (`_01`), PlayStation 5 (`_02`), and Xbox/Generic (`_00`).
  - Patches `UnityEngine.UI.Image.sprite` setter across menus, battles, dialogues, and minigames.
  - Smart minigame button sequence cycle conversion.

---

## [1.0.0] - 2025-12-01

- **Granular Sprite Filtering**:
  - Bilinear, Trilinear, Anisotropic (up to 8x), and Mipmap bias controls tailored for Project Kyaro HD upscaled sprites.
- **Resolution Scaling**:
  - Dynamic internal rendering resolution multiplier (0.5x to 2.0x) without requiring game restarts.
- **Borderless Fullscreen**:
  - Native window frame removal and multi-monitor borderless display support.
- **Sprite Post-Processing Isolation**:
  - Selectively removes bloom and vignette distortion from character sprites to eliminate outline and seam artifacts during battles and exploration.
