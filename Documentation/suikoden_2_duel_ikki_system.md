# Suikoden II Duel (`Ikki`) System, Encounters, & Assets

## Overview

One-on-one duels (`Ikki`) in *Suikoden II* are launched through the same `BattleLoader` boss/event slot table (`btl_bos_data`) as boss battles, but hand off execution to `IkkiChapter` (`GSD2.dll`). Each duel is defined by an `IKKI_DATA` ScriptableObject (`idat_*.json`), driven by `IKKI_WORK` (`Singleton<IKKI_WORK>`) and `ikki_h` phase delegates, and rendered with `IkkiHDWindow` + `AnimeSpriteData` (`"path": "ikki"`).

---

## 1. How Duels Are Loaded (`BattleLoader` $\rightarrow$ `IkkiChapter`)

**Cross-reference ([gsd2_monster_files_research.md](gsd2_monster_files_research.md)):**
- `BattleLoader..cctor` (`0x181f21ad6`) populates `btl_bos_data` (**67** slots, `0..66`), of which **7** slots are `idat_*` duels: `idat_a3`, `idat_a4`, `idat_b2`, `idat_d`, `idat_d2`, `idat_d3`, and `idat_j`.
- Maps preload a duel via `MACHIDAT` opcode `[31] ECFieldCdRead(slot, dir=15, sub=...)` and start it via `[83] ECEventBattleGo(btyp=1, bno=240)` (using the preloaded `MemoryInfo` slot) or `btyp=2` (direct `btl_bos_data[bno]` index).
- `PM_DATA.get_ikki_chara_data` (`0x1811E0080`) / `set_ikki_chara_data` (`0x181A7DEE0`) bridge the player's party stats into `chara_data[0]` (Riou's base template in JSON is `hp = 100/100`, `para = [18, 11, 12, 13, 14, 15, 16]`).

---

## 2. Decoded `IKKI_DATA` Duel Encounters (`Suikoden2\`)

All **6** `IKKI_DATA` JSONs present in `D:\Modding\suikodum\Mobobehaviour\Suikoden2` (plus the `idat_d2` field/sprite assets):

| Asset | `ikki_type` | `mon_select_func_index` | Opponent `chara_id` (`text_id = chara_id + 1`) | HP (`hp / max_hp`) | `para[0..6]` | `BATTLE_FIELD_DATA` (`hd_field_id`) | Sprite Sheet (`AnimeSpriteData`) |
| :--- | :---: | :---: | :--- | :---: | :--- | :--- | :--- |
| `idat_b2.json` | `0` | `1567` | `2` (**Flik**, `text_id 3`, Mercenary Fortress) | `300 / 300` | `[77, 60, 35, 45, 65, 75, 40]` | — | `idat_b2_01.json` (`45` anims / `60` pats) |
| `idat_d.json` | `1` | `1569` | `37` (**Amada**, `text_id 38`, Radat Town) | `250 / 250` | `[130, 80, 50, 55, 60, 50, 75]` | `idat_d #4388.json` (`ig02`, type `99`) | — |
| `idat_d2` | — | `1571` *(inferred)* | — | — | — | `idat_d2.json` (`ig02`, type `99`) | `idat_d2_01.json` (`45` anims / `45` pats) |
| `idat_d3.json` | `0` | `1573` | `140` (**Luca**, `text_id 141`) | `135 / 500` | `[270, 103, 105, 107, 170, 164, 68]` | — | `idat_d3_01.json` (`45` anims / `79` pats) |
| `idat_a3.json` | `1` | `1563` | `146` (`text_id 147` = `None`, **Jowy** `va*` slot 1) | `700 / 700` | `[300, 185, 220, 260, 220, 166, 175]` | — | `idat_a3_00.json` (`45/71`), `idat_a3_01.json` (`45/74`), `idat_a3_effect.json` (`1/4`) |
| `idat_a4.json` | `1` | `1565` | `146` (`text_id 147` = `None`, **Jowy** `va*` slot 2) | `700 / 700` | `[370, 185, 220, 260, 220, 166, 175]` | — | Shares `idat_a3_*` |
| `idat_j.json` | `0` | `1575` | `149` (**Han**, `text_id 150`, L'Renouille `vj*`) | `500 / 500` | `[335, 173, 220, 185, 170, 125, 140]` | `idat_j #7059.json` (`ig04`, type `96`) | `idat_j_01.json` (`45` anims / `61` pats) |

### Key Observations from the Raw Data
- **`idat_d3.json` (Luca Blight):** Starts with `hp = 135` out of `max_hp = 500`, reflecting his wounded state in the 1-on-1 duel after the 3-party ambush! (`chara_id = 140` maps to `text_id = 141` = `"Luca"` in `text_gsd2_en`).
- **`idat_a3.json` vs. `idat_a4.json`:** Both use `chara_id = 146` and `hp = 700 / 700`, but `idat_a4` increases `para[0]` from `300` to `370` and points `mon_select_func_index` to `1565` instead of `1563`.
- **Taunt Tables (`msg_table`):** Every `IKKI_CHARA_DATA` has `msg_table_kazu = 10` groups of 3 message indices (e.g. `[33, 34, 35]`, `[36, 37, 38]`, `[39, 40, 41]`), mapping opponent dialogue tells to `Attack`, `Defend`, and `Desperate Attack`.
- **Action Scripts (`action_table`):** Bytecode arrays (e.g. `action_num = 4`, `42`) controlling camera angles, movement, and sprite frame transitions.

---

## 3. Engine State Machine & Runtime Structures (`GSD2.dll`)

### 3.1 `IkkiChapter` & `ikki_h`
- **`IkkiChapter`** (`Chapter.ChapterBase`):
  - `Start()` (`<Start>d__10.MoveNext` at `0x181F30EE0`) / `Update()` / `OnDestroy()`.
  - `UIHDMode` — Toggles `IkkiHDWindow` (`texts[]` + `face`) vs. classic UI.
- **`ikki_h`:**
  - Step functions: `NextPhaseStep(IkkiOverlayDelegate)` (`0x181E71F60`), `NextTurnStep(IkkiOverlayDelegate)` (`0x181E72010`), `NextGameStep(IkkiOverlayDelegate)` (`0x181E71EB0`).
  - Phase constants: `IF_INITIALIZE` $\rightarrow$ `IF_GET_COMMAND` $\rightarrow$ `IF_PHASE_FUNC_INTERRUPT` $\rightarrow$ `IF_PLAYER_COMMAND` $\rightarrow$ `IF_BATTLE_MAIN_INITIALIZE` $\rightarrow$ `IF_BATTLE_MAIN` $\rightarrow$ `IF_NEXT_BATTLE` $\rightarrow$ `IF_NEXT_BATTLE_END` $\rightarrow$ `IKKI_EXIT` $\rightarrow$ `NEXT_IKKI_END`.

### 3.2 `IKKI_WORK` (`Singleton<IKKI_WORK>`)
- **Commands & Outcome:** `player_command`, `monster_command`, `battle_pattern`, `prev_battle_pattern`, `action_pattern`, `ikki_phase_no`, `ikki_result`, `battle_num`.
- **Timers & Flags:** `step`, `timer`, `index`, `hanyou_timer`, `damage_window_timer`, `demo_flg`.
- **Camera:** `camera_rot`, `pre_camera_rot`, `view_xyz`, `g_ang`, `g_scale`, `g_offset`, `not_camera_flg`.

---

## 4. Suikoden I Cross-Reference (`path: "ikki"` & `G1_ikki_h`)

**Cross-reference ([suikoden_1_map_ids_and_areas_breakdown.md](suikoden_1_map_ids_and_areas_breakdown.md), [suikoden_1_qol_and_recruitment_proposals.md](suikoden_1_qol_and_recruitment_proposals.md)):**
- Five `AnimeSpriteData` files under `"path": "ikki"` belong to *Suikoden I*'s `area_z` duels (all have **49** animations vs. **45** in *Suikoden II*):
  - `pan_teo_00.json` / `pan_teo_01.json` (`49/42`) — Pahn vs. Teo (referenced in `suikoden_1_qol_and_recruitment_proposals.md` for Pahn duel survival).
  - `shu_kwa_00.json` / `shu_kwa_01.json` (`49/50`, `49/42`) — Tir vs. Kwanda.
  - `shu_teo_01.json` (`49/42`) — Tir vs. Teo.
- In `GSD1.dll`, these run on `G1_ikki_h` (`G1_ikki_h.IKKI_DATA`, `G1_ikki_h.IKKI_CHARA`, `G1_ikki_h.IKKI_WORK`, `G1_ikki_h.IKKI_FUNC`).

---

## 5. Modding Opportunities & Hooks

1. **Duel Replay / Boss Rush Mode:**
   - Preload any of the 7 `BattleLoader.btl_bos_data` `idat_*` slots via `ECFieldCdRead(dir=15, sub=...)` and launch via `ECEventBattleGo(2, btl_bos_slot)` from an HQ NPC or ImGui menu to replay Flik (`idat_b2`), Amada (`idat_d`), Luca (`idat_d3`), Jowy (`idat_a3`/`a4`), or Han (`idat_j`) at any time.
2. **Full-HP Luca Blight Duel & Difficulty Scaling:**
   - Hook `IkkiChapter.Update` or `IKKI_WORK.Instance.ikki_data.chara_data[1]` to set Luca's `idat_d3.json` starting `hp` from `135` to `500` (full-HP Luca duel), or scale `max_hp` and `para[0..6]` (similar to how `idat_a4` raises `para[0]` from `300` to `370` over `idat_a3`).
3. **AI & Command Randomization:**
   - Override `IKKI_DATA.mon_select_func_index` (`1563`, `1565`, `1567`, `1569`, `1573`, `1575`) or `IKKI_WORK.monster_command` during `IF_GET_COMMAND` for randomized/harder duel AI.
4. **Duel Tell / Accessibility Indicator:**
   - Read `IKKI_WORK.Instance.monster_command` during `IF_PLAYER_COMMAND` to surface an optional ImGui indicator or audio cue for players who want duel tell assistance.
5. **Custom Player Duel Stats (`PM_DATA`):**
   - Hook `PM_DATA.get_ikki_chara_data` (`0x1811E0080`) to customize Riou's duel HP/attack scaling independently of party level/weapon.
