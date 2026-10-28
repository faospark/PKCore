# Grounded Area & Map Documentation Reference Guide

This rule ensures all agents are strictly aligned with the canonical geographic layout, map assets, and entity catalogues for **Suikoden II (and Suikoden I)**.

---

## 1. Primary Documentation Architecture

When researching map locations, NPC placements, trigger bytecodes, or treasure chests, agents MUST consult these ground-truth documents located in `PKCore\Documentation\`:

| Document | Path | Purpose & Grounded Contents |
|---|---|---|
| **Area Catalogs (63 Files)** | `Documentation\areas\<area_slug>.md` | 63 unabridged geographic catalogues detailing all 4,901 NPCs, props, coordinates `(x, y)`, `otyp`, `fpno`, collision `ozok`, and trigger bytecode actions (`eventCom` / `eventForm`). |
| **Master Map Catalog** | `Documentation\suikoden_2_master_map_entities_and_triggers_catalog.md` | Master index table of all 63 areas with map lists, line counts, and direct relative file links. |
| **Regional Map Breakdown** | `Documentation\suikoden_2_map_ids_and_areas_breakdown.md` | Complete region-by-region map ID breakdown (`va` through `vk`) mapping engine codes to narrative areas. |
| **Treasure Chest Catalog** | `Documentation\treasure_chests_catalog.md` | Complete directory of all 171 treasure chests across 22 areas with coordinates, submaps, save flags (`ByteIndex, BitMask`), and item rewards. |
| **Chest Save Flag Architecture** | `Documentation\suikoden_2_t_box_flag_architecture.md` | Complete bitmask blueprint of the 32-byte chest persistence array (`GAME_DATA.t_box`) and multi-act map state sharing rules. |
| **Entity Correction Audit Log** | `Documentation\areas_correction_audit_report.md` | Comprehensive log of verified character IDs, item drops, and sprite corrections. |

---

## 2. Mandatory Disambiguations & Misnomers (DO NOT CONFUSE)

Never repeat the following historical naming errors or cross-game conflations:

1. **`ryube_forest.md` (`vb09`, `vb10`, `vb11`, `vb20`, `vb21`)**:
   - **Correct Name**: **Ryube Forest & Tsai's Hermit Hut** (*リューベの森 / 深き森 / Deep Woods*).
   - **Never**: Do NOT call this "Mt. Tigerwolf". Mt. Tigerwolf is an iconic Suikoden I mountain in Toran Republic (`bg_va7`–`bg_vad`), completely absent in Suikoden II.
2. **`tigermouth_village.md` (`vg04`, `vg06`)**:
   - **Correct Name**: **Tigermouth Mountain Settlement** (*虎口の村*).
   - **Never**: Do NOT confuse with Drakemouth. `vg04`/`vg06` is located in Region `VG` (Tinto Republic). **Drakemouth Village** (*龍口の村*) is on the opposite Two River side of the mountain pass (`vh08`).
3. **`banner_pass.md` (`vf03`)**:
   - **Correct Name**: **Banner Pass (Toran Mountain Trail)** (*バナー峠*).
   - **Never**: Do NOT call this "Mt. Ryukan". Mt. Ryukan is Doctor Ryukan's mountain hermitage in Suikoden I (`bg_vc0`). `vf03` connects Banner Village to Gregminster in Suikoden II, featuring the Giant Worm boss and the hidden approach to Rokkaku Hamlet.
4. **`swallow_pass.md` (`vb07`, `vb08`, `vb17`)**:
   - **Correct Name**: **Swallow Pass & Highland Border Gate** (*燕の峠*).
   - Disambiguated from Ryube Forest so it exclusively covers the trail between Toto/Ryube and the Highland border gate.
5. **Sprite Pattern `fpno 83`**:
   - **Identity**: In Suikoden II map data, `fpno 83` is **Bonaparte** (Millie's runaway wild boar/beast), NOT Luca Blight.

---

## 3. High-Speed Sub-Millisecond Search Tooling (`tools\sym.bat`)

All maps, areas, and game entities are indexed into `tools\symbol_indexer\symbols.db` and queryable via `tools\sym.bat`:

- **Map Lookup by Map ID or Area Name**:
  ```cmd
  tools\sym.bat vb09
  tools\sym.bat ryube
  tools\sym.bat tigermouth
  tools\sym.bat banner_pass
  ```
  Returns submap info, asset JSON file, C# handler (`MACHICON.EventInit`), and link to the exact catalog markdown file.

- **Game Entity Lookup (Characters, Runes, Gear, Recipes, Items)**:
  ```cmd
  tools\sym.bat Bonaparte
  tools\sym.bat "Fire Cake"
  tools\sym.bat 84
  tools\sym.bat BAK2
  tools\sym.bat DI_CAKE6
  ```
  Returns entity name, category, internal symbol (`g2_name_h` / `g2_data_h`), and exact native item/chara ID.

---

## 4. Castle Level 0-Index Grounding (`base_lv`)

`GAME_DATA.base_lv` is 0-indexed in engine memory and event bytecode:
- **`base_lv == 0`**: Castle Level 1 (Mercenary Fort / Pre-Castle) $\rightarrow$ Opcode `[33, 0, 0]` or `< 1` $\rightarrow$ `[33, 2, 1]`.
- **`base_lv == 1`**: Castle Level 2 (North Window Castle newly established) $\rightarrow$ Opcode `[33, 1, 1]` (`base_lv >= 1`).
- **`base_lv == 2`**: Castle Level 3 (First castle expansion after Two River / Greenhill) $\rightarrow$ Opcode `[33, 1, 2]` (`base_lv >= 2`).
- **`base_lv == 3`**: Castle Level 4 (Late-game expansion) $\rightarrow$ Opcode `[33, 1, 3]` (`base_lv >= 3`).

