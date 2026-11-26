# Suikoden II Unite & Spell Animation Assets (`unite`, `magic`, `m_effect`, `f_effect`)

## Overview

In `D:\Modding\suikodum\Mobobehaviour\Suikoden2`, **210** `AnimeSpriteData` JSON files (`m_Script.m_PathID: -3654021563660114729`) define sprite sequences, frame durations, and alpha-blending for Unite Attacks (`unite`: **32**), player/rune spells (`magic`: **105**), boss/enemy VFX (`m_effect`: **61**), and field/shared effects (`f_effect`: **12**).

This document pairs those Unity `AnimeSpriteData` sheets with the `b_read` slot architecture in [suikoden_1_and_2_battle_skills_and_animations_catalog.md](suikoden_1_and_2_battle_skills_and_animations_catalog.md) and the decoded `text_gsd2_en` specs.

---

## 1. Unite Attacks: Names, Specs, & Assets

### 1.1 Engine Dispatch (`bc_udat.json` $\rightarrow$ `UNITE_DATA` $\rightarrow$ `Unite01..50`)
- **`bc_udat.json` (`UNITE_DATAS.GetCopyData()`):** Loads `UNITE_DATA[]` (`1..50`) via `BATTLE_WORK.GetUniteData(int unite_id)` (`0x181A41050`).
  - `player_kazu` / `player_id[]` — Required party members (`2` or `3` characters).
  - `func_no` — Index into `UniteList.UNITE_LIST` (`Unite01..Unite50`), dispatched via `b_read` slots `114..163` (`UNITE_BASE = 113`).
  - `hosei` — Damage multiplier; `m_status` / `m_status_prob` (enemy status); `p_status` / `p_status_prob` (self-unbalance/status).
- **Vanilla Menu Cap:** `WINDOW_WORK` caps the battle Unite list at **6** entries per party unless expanded (see `_archive/PKCustomUnites/Patches/UniteTableAndWindowPatch.cs`).

### 1.2 Decoded Unite Attack Names & Specs (`text_gsd2_en` `1261..1303`)

| Text ID | Unite Attack Name | In-Game Spec / Effect (`text_gsd2_en`) |
| :---: | :--- | :--- |
| `1261` | **Twin Fighter Attack** | `1x DMG to front row` (`1260`) |
| `1263` | **Buddy Attack** | `3x DMG to 1 E` / `Berserk only` (`1262`) |
| `1265` | **Ninja Attack** | `1x DMG to all Es` (`1264`) |
| `1266` | **Husband & Wife Attack** | `2x DMG to 1 E` / `Yoshino Unbalance` (`1267`) |
| `1268` | **Double Kraken Attack** | Kraken duo attack (Abizboah & Rulodia) |
| `1269` | **Swordsman Attack** | `0.5x DMG to all Es` / `Sudden death (20%)` (`1270`) |
| `1271` | **Copycat Attack** | `1x DMG to 1 E` (`1272`) |
| `1273` | **Double Leader Attack** | `0.75x DMG to all Es` (`1274`) |
| `1275` | **Circus Attack** | `2x DMG to 1 E` / `Bolgan Unbalance` (`1276`) |
| `1277` | **Flash Attack** | `1.5x DMG to all Es` / `0.5x DMG to allies` (`1278`) |
| `1279` | **Beauty Attack** | `0.25x DMG to all Es` / `Sleep (30%)` (`1280`) |
| `1281` | **Warriors' Village Attack** | `2x DMG to 1 E` / `Hix takes DMG` (`1282`) |
| `1283` | **Groupie Attack** | `2.5x DMG to 1 E` / `Nina Unbalance` (`1284`) |
| `1285` | **Tackle Attack** | `0.75x DMG to all Es` / `Unbalance` (`1286`) |
| `1287` | **Family Attack** | `2x DMG to 1 E` / `Nanami Unbalance` (`1288`) |
| `1289` | **Pretty Boy Attack** | `1x DMG to all Es` / `Become Hostile` / `Futch & Sasuke takes DMG` (`1290`) |
| `1291` | **Pretty Girl Attack** | Female trio/duo unite |
| `1292` | **100 Kobolds Attack** | Kobold squad attack |
| `1293` | **Fancy Lad Attack** | `1.5x DMG to 1 E` / `Sudden death (25%)` (`1294`) |
| `1295` | **Bandit Attack** | Bandit duo attack |
| `1296` | **Underling Attack** | `4x DMG to 1 E` / `Drains Bob & Bolgan's HP To Heal Sierra` (`1297`) |
| `1298` | **True Beauty Attack** | `0.25x DMG to all Es` / `Sleep (70%)` (`1299`) |
| `1300` | **Five Squirrel Attack** | `Takes E far away` (`1301`) — uses `unite45_01.json` (`battle_player_muk_00_00`, Mukumuku) |
| `1302` | **Beastmaster Attack** | `1.5x DMG to 1 E` / `Causes Berserk` (`1303`) |

### 1.3 `unite` JSON Asset Inventory (32 Files) & Sprite Bindings
Not all 50 `Unite01..50` slots have custom `uniteXX_*.json` sheets; **32** sheets exist (several reuse boss, magic, or `f_effect` sprites):

- **Dedicated `uniteXX` Sheets:** `unite08_00` (`10/26`), `unite09_00` (`10/26`), `unite16_00` (`8/24`), `unite20_00/01` (`12/16`), `unite21_00` (`23/60`), `unite22_00` (`14/39`), `unite29_01` (`1/3`), `unite36_00` (`34/34`), `unite40_00` (`13/38`), `unite41_00` (`3/3`), `unite45_00` (`7/80`), `unite46_01` (`12/18`).
- **Character-Specific Sheets:** `unite15_00/01` (`kks` + `frk`), `unite19_00/01` (`lfi` + `mfi`), `unite23_00/01` (`klk` + `rkl`), `unite32_00` (`fri`), `unite45_01` (`muk` — Mukumuku / Five Squirrel Attack).
- **Reused Effect Sheets:** `unite04_00` & `unite29_00` (`mf_mag1`), `unite18_00` (`mf_hap1`), `unite21_01` (`fe_dat00`), `unite27_00` (`system_main_07`), `unite28_00` (`fe_dat14_01`), `unite30_00/02` (`vd06_00_03` + `boss_res_nik_02`), `unite35_00` (`m_lfi_02`), `unite37_00` (`m_winr_00`), `unite40_01` (`boss_res_gol`).

---

## 2. Magic Specs (`magic` — 105 Files & `Magic/*` Classes)

Loaded by `MagicManager` (`LoadResource`, `CreateEffect`, `ReleaseAllEffect`) for `MagicBase` subclasses (`b_read` slots `1..72, 79..98, 106..107`):

### 2.1 Elemental & Standard Runes
- **Fire (`m_fir1_00/01`, `m_fir2_00/01`, `m_fir3_00..03`, `m_fir5_00` / `Fire1..5`):** Fire Rune spells (Flaming Arrows, Fire Storm, Dancing Flames, Explosion, Final Flame).
- **Water (`m_wat1_00`, `m_wat2_01`, `m_wat4_01/02` / `Wat1..5`):** Water Rune healing & protection spells.
- **Wind (`m_win1_00`, `m_win3_00`, `m_win4_01`, `m_win5_01`, `m_winr_00` / `Win1..5`, `Winr`):** Wind Rune spells (Wind of Sleep, Healing Wind, Storm, Shining Wind).
- **Lightning (`m_thu1_02`, `m_thu2_00`, `m_thu3_00`, `m_thu5_01` / `Thu1..5`):** Lightning Rune spells (Angry Blow, Thunderbolt, Ball of Lightning, Thor's Hammer).
- **Earth (`m_eat1_00/01`, `m_eat2_00`, `m_eat3_01`, `m_eat4_01`, `m_eat5_00/01` / `Eat1..5`):** Earth Rune buffs & attacks (Clay Guardian, Voice of Earth, Guardian Earth, Canopy Defense, Earthquake).

### 2.2 True Runes & High-Tier Runes
- **Bright Shield (`m_hol1_00/01`, `m_hol2_00`, `m_hol3_00`, `m_hol4_00` / `Hol1..4`, `Shi1..4`):** Riou's True Rune (`Great Blessing`, `Shining Light`, `Battle Oath`, `Forgiver Sign`).
- **Black Sword (`m_swo1_00/01`, `m_swo3_01`, `m_swo4_00` / `Swo1..4`):** Jowy's True Rune (`Flash Judgment`, `Twinkling Blade`, `Pierce`, `Hungry Friend`).
- **Soul Eater / Darkness (`m_dar1_00`–`m_dar6_00` / `Dark1..6`):** Tir's Soul Eater / Darkness spells (`Deadly Fingertips`, `Black Shadow`, `Hell`, `Judgment`).
- **Pale Gate (`m_gat1_00..02`, `m_gat2_00..02`, `m_gat3_00..03`, `m_gat4_00..03` / `Gate1..4`):** Summoning gate spells (`Open Gate`, `King's Road`, `Star Dragon`, `Empty World`).
- **Blinking (`m_bln1_00/01`, `m_bln2_00/01` / `Bli1..3`):** Viki's Blinking Rune teleport/attack spells.
- **True Rune Combos (`Comb1..5`):** Scorched Earth & combined True Rune magic.

### 2.3 Character-Specific & Command Runes
- `m_bor_00/01` (`Bor`), `m_bur_00` (`Burn`), `m_fur_00/01`, `m_gri1_00` (`Gri1..3`), `m_kae_00..03`, `m_kal_00` (`Kal`), `m_kks_00` (`Kks`), `m_klk1_00..02` (`Klk1..3`), `m_ksm_00` (`Ksm`), `m_lfi_00..02` (`Lfi`), `m_mil_00/01` (`Mil`), `m_ora_00` (`Ora`), `m_rai_00/01`, `m_sen_00/01` (`Sen`), `m_sin_00/01` (`Sin`), `m_sui_00`, `m_syo_00/03/04`, `m_uni1_00` (`Uni1..3`), `m_wol_00..02` (`Wol`), `m_zam_00` (`Zam`), `m_spc10_00`, `m_spc12_00` (`Spc1..14` command-rune specials).

---

## 3. `m_effect` (61 Files) & `f_effect` (12 Files)

### 3.1 `m_effect` (`mf_*` — Boss & Enemy Battle VFX, `b_read` `175..254`)
These are enemy/boss-specific attack animations (paired with `M_Effect.mf_*` in [suikoden_1_and_2_battle_skills_and_animations_catalog.md](suikoden_1_and_2_battle_skills_and_animations_catalog.md)):
- **`mf_las0..7` (11 files):** Final Boss / Beast Rune phases (`Silver Wolf` / `Beast Rune`).
- **`mf_nec1_00`:** Neclord boss VFX.
- **`mf_hap0_00`, `mf_hap1_01`:** Harpy (`boss_hap1` / unused `boss_hap2`).
- **`mf_gol1_01/03/04`:** Golem (`boss_gol`).
- **`mf_gwo0_01`, `mf_gwo1_00`:** Giant Wolf / Silver Wolf (`boss_gwo1`).
- **`mf_imo0_00`, `mf_imo2_00`:** Larva / Caterpillar (`boss_imo2`).
- **`mf_boa0`, `mf_cim0..2`, `mf_coc1`, `mf_col0..1`, `mf_dre0`, `mf_ear4`, `mf_fir1/3/5`, `mf_gek0..1`, `mf_ki20..21`, `mf_kul0..1`, `mf_lus0`, `mf_mag1`, `mf_mao0`, `mf_sam0`, `mf_sid0`, `mf_sie0`, `mf_uni0`:** Specific boss/monster attack overlays.

### 3.2 `f_effect` (`fe_dat*` — Field & Shared Event Visual Effects, 12 Files)
`fe_dat00_00` through `fe_dat14_01` are field/event visual effect overlays (not standard rune casts). Several share boss/character atlases or are reused by Unites:
- `fe_dat00_00` (reused by `unite21_01`), `fe_dat14_01` (reused by `unite28_00`), `fe_dat01_01` (`boss_res_gol`), `fe_dat05_00` (`boss_res_kul_sid`), `fe_dat08_00` (`boss_res_sei`), plus standalone `fe_dat01_00`, `02_00`, `02_01`, `03_01`, `09_00`, `13_00`, `14_00`.

---

## 4. Harmonization with Existing `PKCore` Docs & Patches

| Existing Doc / Archive | Connection |
| :--- | :--- |
| [suikoden_1_and_2_battle_skills_and_animations_catalog.md](suikoden_1_and_2_battle_skills_and_animations_catalog.md) | Documents the `b_read` slot IDs (`1..107` magic, `114..163` Unite, `175..254` `M_Effect.mf_*`, including unused slots `188, 200, 231..234, 249..252`). |
| [gsd2_monster_files_research.md](gsd2_monster_files_research.md) | Links `boss_hap2` and `boss_imo2` / `boss_rau2` to `boss_res*` and `M_Effect` VFX. |
| [battle_and_combat_patches.md](battle_and_combat_patches.md) | Documents `CommandRuneSelfUnbalancePatch.cs` alongside `UNITE_DATA.p_status` self-unbalance penalties. |
| `_archive/PKCustomUnites/Patches/UniteTableAndWindowPatch.cs` | Reference implementation for injecting custom `UNITE_DATA` via `UNITE_DATAS.GetCopyData()`, expanding `WINDOW_WORK` past the 6-unite cap, and hooking `b_read` dispatch. |

---

## 5. Modding Opportunities

1. **Custom Unite Attacks (`UNITE_DATAS` + `UniteBase`):** Inject new `UNITE_DATA` entries in `UNITE_DATAS.GetCopyData()`, expand `WINDOW_WORK` arrays beyond 6 slots, and reuse `Unite01..50` choreography or `unite*.json` sprite sheets.
2. **Unite Rebalancing & Removing Self-Unbalance:** Postfix `BATTLE_WORK.GetUniteData` (`0x181A41050`) to clear `p_status` / `p_status_prob` (e.g. Yoshino, Bolgan, Nina, Nanami Unbalance), remove ally damage on `Flash Attack` / `Pretty Boy Attack`, or tune `hosei` multipliers.
3. **Fast-Forwarding Long Spell / Unite Animations:** Halve `timer_table[].timer` values (keeping `>= 1`) in `unite*.json` / `m_*.json` or hook `UniteBase.Update()` / `MagicBase.Update()`.
4. **Custom Spell & Boss VFX Swaps:** Hook `MagicManager.CreateEffect(ref string name, Vector3 position)` to redirect spell prefabs or tap into unused `b_read` `M_Effect` slots (`188, 200, 231..234, 249..252`).
