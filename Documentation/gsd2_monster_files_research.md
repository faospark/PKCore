# Suikoden II (`GSD2`) Monster & Battle Files Forensic Research Report

> [!NOTE]
> Scope: **Suikoden II (`GSD2`) only** (`gsd1-*` excluded). Findings are derived directly from live Steam Addressables bundles (`catalog.json` + `StandaloneWindows64/*.bundle`), IL2CPP binary disassembly/metadata (`GameAssembly.dll` + `script.json`), and all `236` decompiled `GSD2` `MACHIDAT` map assets (`v[a-z]\d\d.json`, `w[a-z].json`).

---

## 1. Executive Inventory & Link Totals

| Asset Layer | Addressables / Game Count | Referenced in Data Graph | Unused / Unreachable / Anomalous |
| :--- | :---: | :---: | :--- |
| **`BATTLE_DATA`** (`gsd2-classic-battle-battle`) | **133** | **131** reachable (`76` map/event + `55` boss/`eb_*`) | **2** completely unreachable bosses (`boss_hap2`, `boss_rau2`); **5** OOB `ECFieldCdRead` boss loads (`vj20`–`vj24`, `sub=67..71`) |
| **`MONSTER_PARTY_DATA`** (`gsd2-classic-battle-monster_party`) | **540** | **540** linked in `BATTLE_DATA.monster_party` | **2** unreachable via cut bosses (`boss_hap2_00`, `boss_rau2_00`) |
| **`MONSTER_DATA`** (`gsd2-classic-battle-monster_data`) | **414** | **414** linked in `BATTLE_DATA.monster_data` | **3** unspawned field monsters (`va11_00_02`, `vc12_00_00`, `vc12_00_04`); **3** unused/dummy boss-or-EB entries (`boss_las_05`, `eb_vh01_01`, `eb_vh08_01`); **5** unreachable via `boss_hap2`/`boss_rau2` (`boss_hap2_00`, `boss_rau2_00..03`); **10** C#/wave-only spawns (`boss_imo2_01`, `boss_ki1_01`, 8 `eb_*`) |
| **`opd-battle-monster`** (`gsd2-classic-opd-battle-monster`) | **177** | **177** (`144` via `MONSTER_DATA.opd_data` + `35` via `boss_res*.opd_tbl`, overlap `2`) | **0** orphaned sprites (`boss_hap2_00` reuses `boss_hap1_00`; `boss_res_hap_02` sits in `boss_res[hap].opd_tbl`) |
| **`boss_res*`** (`gsd2-classic-boss_res-*`) | **16** keys | Shared by `BattleLoader$$CreateBossResPath` dict | Packed together cleanly; no missing dependency bundles |
| **Text (`text_gsd2_en` / `text_gsd2_ja`)** | `textList` JSON | Direct lookup by `MONSTER_DATA.name_id` | **298** `MONSTER_DATA` `name_id`s absent from `textList`; **`boss_hap2_00` (`name_id=808`)** has blank EN `""` and garbled JA `"ビタジ　グノド見"` |

---

## 2. Completely Unused / Cut Boss Battles (`BATTLE_DATA`)

From `BattleLoader$$.cctor` (`0x181f21ad6`), `btl_bos_data` defines **67** boss/event/duel slots (`0..66`):
- Slots `2` and `46` are `None` (`null`).
- `boss_dor` appears twice (`idx 4` and `idx 10`); `idx 4` IS loaded via `[31] ECFieldCdRead(dir=15, sub=4)` in `ve13`, so `boss_dor` is **used**.
- `7` slots are `idat_*` one-on-one duels (`idat_a3, a4, b2, d, d2, d3, j`).
- **All `76` field/map `BATTLE_DATA` are verified used**: `55` via static `mapeventdat[].batlno` (`batlpro > 0` in every case; `0` zero-rate static encounters) and all remaining `21` via `[83] ECEventBattleGo(btyp=1, bno=...)` or `[121] ECBatParChg(bno)` (including `va01_00`, `va09_00`, `vc13_00`, `vc24_00`, `vg11_01`, `vj02_02`, `vj02_03`, `vj04_01`, `vj05_01`, `vj11_01`). Note that `[83] ECEventBattleGo` takes `(arg0=btyp, arg1=bno)` (`0x182136b10`), where `bno=240` (`0xf0`) uses the preloaded `MemoryInfo` slot from `[31] ECFieldCdRead` and `btyp=2` directly indexes `btl_bos_data[bno]`.

Scanning all `236` `GSD2` `MACHIDAT` scripts (`21,029` script segments verified with `0` parse failures) leaves **only two** `BATTLE_DATA` assets with **zero** `[31]`, `[83]`, `[121]`, or `batlno` callers anywhere:

1. **`boss_hap2`** (`btl_bos_data[50]`) — **Unused Harpy Variant**
   - **`MONSTER_PARTY_DATA`**: `boss_hap2_00` (`monster_kazu=1`, `battle_start_func_index=1303`)
   - **`MONSTER_DATA`**: `boss_hap2_00` — **Lv 60**, **12,000 HP**, **15,000 Potch** (vs. used `boss_hap1_00` Harpy: Lv 45, 7,400 HP, 4,000 Potch). Drops: none.
   - **OPD Sprite**: Reuses `boss_hap1_00`.
   - **Localized Name (`name_id=808`)**: `EN = ""` (empty string), `JA = "ビタジ　グノド見"` (garbled placeholder/shift-JIS artifact).
   - **Code Status**: C# overlay class `boss_hap2` and `area_func` registration (`hap2_normal_mae_func00`, referencing `"gsd2/hd/effect/2_enemy/EM2_B07_02"`) are compiled into `GameAssembly.dll`, but **never invoked by any map**.

2. **`boss_rau2`** (`btl_bos_data[24]`) — **Unused / Cut Luca Blight Variant**
   - **`MONSTER_PARTY_DATA`**: `boss_rau2_00` (`monster_kazu=6`, `monster_id=[4,3,2,1,0,0]`, `monster_code=[3,4,3,2,1,2]`, `battle_start_func_index=1478`)
   - **`MONSTER_DATA`**:
     - `boss_rau2_00` (`name_id=849`): **Lv 22**, **30,000 HP**, **1,000 Potch** (`opd=boss_rau1_03` — Luca sprite; compare to used `boss_rau1_03`: Lv 25, 3,000 HP)
     - `boss_rau2_01` (`name_id=850`): Lv 19, 80 HP, 150 Potch (`opd=vc02_00_00`)
     - `boss_rau2_02` (`name_id=851`): Lv 19, 90 HP, 150 Potch (`opd=va01_00_00`)
     - `boss_rau2_03` (`name_id=852`): Lv 19, 110 HP, 150 Potch (`opd=va01_00_01`)
   - **Code Status**: C# overlay class `boss_rau2` and `area_func` registration (`rau2_special_mae_func00`, etc.) exist in `GameAssembly.dll`, and `boss_rau2_00..03` have missing (`None`) names in `text_gsd2_en`/`ja`. Never preloaded (`[31] sub=24`) or started (`[83]`) in any map.

---

## 3. Out-of-Bounds `ECFieldCdRead` Calls in `vj20`–`vj24` (`sub = 67..71`)

Five placeholder/cut map files (`vj20` through `vj24`, whose `msdat.name` IDs `663, 667, 674, 677, 681` all resolve to `EN=""` / `JA="■"` and carry `battle_dat = [0, vj2x_00, vj2x_00, vj2x_00]`) execute `[31] ECFieldCdRead(slot, dir=15, sub=67..71)` before `[83] ECEventBattleGo(1, 240)`:

- `vj20.json` `me[4].ev[4]`: `slot=1, dir=15, sub=67`
- `vj21.json` `me[4].ev[4]`: `slot=0, dir=15, sub=68`
- `vj22.json` `me[4].ev[4]`: `slot=1, dir=15, sub=69`
- `vj23.json` `me[4].ev[7]`: `slot=0, dir=15, sub=70`
- `vj24.json` `me[4].ev[15]`: `slot=1, dir=15, sub=71`

However, `BattleLoader$$btl_bos_data` has length **67** (`0..66`), and `BattleLoader$$GetBattleDataType` (`0x181f213ab..0x181f214aa`) performs an unconditional array bounds check jumping straight to `RaiseIndexOutOfRangeException` (`0x1803250e0`) for `sub >= 67`. No `eb_vj20`–`eb_vj24` entries exist in `btl_bos_data` or the Addressables catalog. *(Separately, the `vj20_00..vj24_00` field `BATTLE_DATA` assets themselves hold populated `MONSTER_DATA` entries, e.g. `vj21` `Iron Moon` / `Copper Sun` / `Fisheye`, `vj23` `Phantom` / `Pink Bird`, and `vj24_00_02` reusing `va11_00_02`'s Chimera OPD.)*

---

## 4. Unspawned & Unused `MONSTER_DATA` (Out of 414)

In all `133` `BATTLE_DATA` assets, `monster_data[0]` is `NULL` (`m_PathID: 0`), while `MONSTER_PARTY_DATA.monster_code[0..5]` (6 battle-grid slots) and `monster_id[]` use **1-based** indices (`0` = empty slot). Checking all `414` `MONSTER_DATA` against all `540` `MONSTER_PARTY_DATA`:

- **`393` `MONSTER_DATA`** appear in `MONSTER_PARTY_DATA.monster_code[0..5]` of reachable `BATTLE_DATA`.
- **`5` `MONSTER_DATA`** belong strictly to the unreachable cut bosses above (`boss_hap2_00`, `boss_rau2_00..03`).
- **`16` `MONSTER_DATA`** sit in reachable `BATTLE_DATA.monster_data[]` arrays without appearing in **any** `MONSTER_PARTY_DATA.monster_code[0..5]` formation slot:

### A. Completely Unspawned Regular Field Monsters (`3`)
| Asset | Map / Area | `name_id` | EN / JA Name | Stats | Item Drops | Notes |
| :--- | :--- | :---: | :--- | :--- | :--- | :--- |
| **`va11_00_02`** | `va11` (Tenzan Pass) | `223` | `Chimera` / `キメラ` | Lv 55, 765 HP, 19,000 Potch | Item `6` @ 2% | Never placed in any `va11_00_*` party (`monster_id` & `monster_code` never reference index `3`). Sprite `va11_00_02` is later reused by `vj24_00_02`. |
| **`vc12_00_00`** | `vc12` (Sindar Ruins) | `318` | `Mr. Venus` / `月光老師` | Lv 16, 270 HP, 400 Potch | Items `19`, `24` @ 10% | Never placed in any `vc12_00_*` party (`monster_code`/`monster_id` only use indices `2, 3, 4`). |
| **`vc12_00_04`** | `vc12` (Sindar Ruins) | `322` | *(none)* / *(none)* | Lv 15, 200 HP, 200 Potch | Item `92` @ 5% | Same as above — index `5` in `vc12_00.monster_data`, unused by every `vc12_00_*` party. |

### B. Unused / Dummy Boss & Event-Battle Entries (`3`)
- **`boss_las_05`** (`name_id=822`): `EN="Last Boss"` / `JA="ラスボス"`, **Lv 11**, **1,000 HP**, **400 Potch**, drops items `1, 64` @ 20%, `opd=boss_las_05`. Completely mismatched against the real final-boss Beast Rune parts (`boss_las_00..04`, e.g. `boss_las_04` Lv 75, 4,500–5,700 HP), and omitted from both `monster_code[0..5]` and `monster_id[0..5]` of `boss_las_00`. *(Note: OPD `boss_las_05` is still slotted at `boss_res[las].opd_tbl[0]`.)*
- **`eb_vh01_01`** (`name_id=969`, Lv 32, 120 HP, 500 Potch, item `39` @ 10%): Absent from both `monster_code[0..5]` and `monster_id[0..5]` of `eb_vh01`.
- **`eb_vh08_01`** (`name_id=973`, Lv 32, 120 HP, 500 Potch, item `39` @ 10%): Absent from both `monster_code[0..5]` and `monster_id[0..5]` of `eb_vh08`.

### C. Runtime / C#-Spawned Forms (`10` — Intentionally Omitted from Static Grid `monster_code`)
- **Boss transformations / clones (`2`)**: `boss_imo2_01` (`Poison Moth` / `ポイズンモス`, Lv 47, 6,800 HP, spawned during `boss_imo2` phase change via `imo2_boss_hensin_func00`), `boss_ki1_01` (`name_id=814`, Lv 10, 800 HP, item `9` @ 255, Mist Shade clone).
- **Event-battle wave reinforcements (`8`, present in `monster_id[]`)**: `eb_va05_01`, `eb_vb02_03`, `eb_vb02b_00`, `eb_vb02b_02`, `eb_vb19_00`, `eb_vc16b_01`, `eb_vc16b_03`, `eb_ve03_02`.

---

## 5. Additional Integrity & Text Observations

- **Zero stat/structural corruption in live `BATTLE_DATA` / `MONSTER_PARTY_DATA` / `MONSTER_DATA`**:
  - `0` assets have `hp <= 0`, `level <= 0`, `battle_field_data == NULL`, `monster_party_num != len(monster_party)`, or `item_no`/`item_prob` mismatches.
- **Unreferenced Monster Strings & Sparse `name_id` Coverage**:
  - `298` `MONSTER_DATA` entries have a `name_id` absent from `text_gsd2_en`/`text_gsd2_ja` (`None`), while `1` (`boss_hap2_00`, `808`) has blank EN / garbled JA.
  - `107` non-empty IDs in the `200..999` ID range are unreferenced by `MONSTER_DATA.name_id` (these are shared low-range map/NPC/location labels such as `Kyaro Town`, `Sindar Ruins`, `Greenhill City`, `White Knight`, etc.).
