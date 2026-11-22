# Suikoden I & II Positive Battle Status Effects Reference

## Overview

This document catalogs positive (beneficial) battle status effects in **Suikoden II (`GSD2`)** and **Suikoden I (`GSD1`)**, along with the exact data structures, bitmasks, counters, and functions the game engine uses to programmatically apply, sync, and clear them.

---

## Suikoden II (`GSD2`)

Suikoden II splits battle buffs across **three separate data layers**, depending on whether the effect is a general character status, a player-only magic/rune flag, or a party-wide battlefield buff.

### 1. General Character Statuses (`PM_DATA.status`)

Stored as a 32-bit bitmask in `PM_DATA.status` (native offset `+0x60`; visual mirror in `PM_DATA.disp_status` at `+0x6c`). Status IDs are defined in `battle_h` (`SC_*`) and mapped to bitmasks via the static `uint[34]` lookup table `PM_DATA.status_henkan_table`.

| Status Constant | ID | Bitmask | Effect & Notes |
| :--- | :---: | :--- | :--- |
| `SC_HOKA` | `5` | `status_henkan_table[5]` | **Warm (Hoka-Hoka)** — Restores HP each turn (`battle_h.HOKA_KAIFUKU`). Cleared automatically via `StatusClear(5)` when `SC_ANGRY` is cleared in `AllGoodStatusClear()`. |
| `SC_ANGRY` | `11` (`0x0B`) | `0x00020000` | **Berserk / Fury** — Physical ATK boost scaled by `PLAYER_STATUS_DATA.ikari_val` (set to `100` by Fury Rune `#87` or Battle Oath). Mutually exclusive with `SC_BOOST` and `SC_AWAKE`. |
| `SC_BOOST` | `12` (`0x0C`) | `0x00040000` | **Attack Boost** — Lasts 3 turns (`PLAYER_STATUS_DATA.boost_cnt = 3`). Applying it automatically clears `SC_ANGRY` (zeroing `ikari_val`) and `SC_AWAKE` (zeroing `awake_cnt`). |
| `SC_AWAKE` | `13` (`0x0D`) | `0x00080000` | **Awaken / Magic Boost** — Lasts 3 turns (`PLAYER_STATUS_DATA.awake_cnt = 3`). Boosts magic power/healing by 1.5x (verified in `BattlePlayerCharacter.MagicShieldFunc04`). Mutually exclusive with `SC_ANGRY` and `SC_BOOST`. |
| `SC_MUTEKI` | `14` (`0x0E`) | `status_henkan_table[14]` | **Invincible** — Nullifies incoming damage; tracked by `PLAYER_STATUS_DATA.muteki_cnt`. |
| `SC_RE_MAG` | `20` (`0x14`) | `status_henkan_table[20]` | **Magic Reflect** — Reflects enemy spells. |
| `SC_HP_REF` | `21` (`0x15`) | `status_henkan_table[21]` | **HP Regen / Drain** — Passive HP recovery effect. |
| `SC_TARGET` | `22` (`0x16`) | `status_henkan_table[22]` | **Target / Attract** — Draws enemy attacks (e.g., Firefly Rune). `StatusSet()` loops through all allies and clears `SC_TARGET` from everyone else so only one character holds it at a time. |
| `SC_RE_ATT` | `24` (`0x18`) | `status_henkan_table[24]` | **Physical Counter / Reflect** — Counter-damage state (e.g., Revenge Earth / Fire Wall). |
| `SC_JIZOU` | `27` (`0x1B`) | `status_henkan_table[27]` | **Sacrificial Jizo** — Auto-revives the character when K.O.'d (applied via `BattleManager.StatusFunc01` when equipped). |
| `SC_GUARD` | `29` (`0x1D`) | `status_henkan_table[29]` | **Defend / Guard** — Applied when the character selects the Defend command (`CMD_GUARD`). |
| `SC_KAIFUKU` | `30` (`0x1E`) | `status_henkan_table[30]` | **Auto-Heal** — Applied when `BattlePlayerCharacter.PlayerKaifukuCheck()` returns `true` (e.g., Medicine / auto-recovery equipment or runes). |

> **Good Status Purge (`PM_DATA.AllGoodStatusClear`, VA `0x181A781E0`):** Explicitly clears `SC_ANGRY` (11, + `ikari_val = 0` + `StatusClear(5)` for `SC_HOKA`), `SC_BOOST` (12, + `boost_cnt = 0`), `SC_AWAKE` (13, + `awake_cnt = 0`), `SC_MUTEKI` (14), and index `9`.

### 2. Player-Specific Magic Buffs (`PLAYER_STATUS_DATA`)

Stored per party member in `BATTLE_WORK.p_status_data[chara_no]` (`PLAYER_STATUS_DATA`).

* **Bitmask `magic_status_flg` (`ushort`, offset `+0x10`):**
  * `MS_EARTH_PROTECT_FLG` (`0x0001`) — **Clay Guardian** (Earth Lv1, `magi_no == 0x10`; also cast by **Meringue Pie** `#75`): 1.5x DEF to 1 ally for the battle.
  * `MS_WIND_RE_MAG_FLG` (`0x0002`) — **Storm Warning** (Wind Lv3, `magi_no == 0x0E`): user only; reflects magic damage and stores reflected damage in `wind_re_mag_damage` (`+0x20`). Checked first in `BattlePlayerCharacter.ReMagCheck()`.
  * `0x0010` / `0x0020` — Special rune/command flags set via `BattlePlayerCharacter.PlayerStatusSet(ushort)` when `PlayerUseMagicCheck(0x3B)` or `PlayerUseMagicCheck(0x40)` is active.
  * `MS_GEKIDO_PRE_FLG` (`0x0200`) / `MS_GEKIDO_FLG` (`0x0400`) — Rage/Gekido turn-tracking flags managed in `BattleManager.StatusFunc01`.
* **Turn Counters & Values on `PLAYER_STATUS_DATA`:**
  * `earth_re_atk_cnt` (`+0x12`) — **Revenge Earth** (Earth Lv2, `magi_no == 0x11`): 100% counterattack to 1 ally for `3` turns.
  * `muteki_cnt` (`+0x13`) — Invincibility turn counter.
  * `boost_cnt` (`+0x1B`) / `awake_cnt` (`+0x1C`) — 3-turn counters for `SC_BOOST` and `SC_AWAKE`.
  * `wind_re_mag_damage` (`+0x20`) / `fire_re_atk_damage` (`+0x22`) / `vanpier_recover` (`+0x24`) / `ikari_val` (`+0x26`) / `damage_buff` (`+0x28`) — Buff magnitude and counter-damage storage.

### 3. Party-Wide Battlefield Buffs (`BATTLE_MAGIC_STATUS`)

Stored on `BATTLE_WORK.battle_magic_status` (`BATTLE_MAGIC_STATUS`):

* `water_re_mag_cnt` (`+0x14`) — **Protection Mist** (Water Lv2, `magi_no == 0x07`): set to `3` turns; repels magic for all allies (flat 20% / `0x14` rate in `BattlePlayerCharacter.ReMagCheck()`).
* `water_silent_cnt` (`+0x15`) — **Silent Lake** (Water Lv4, `BattlePlayerCharacter.MagicWater4Func`): set to `3` turns; blocks magic use on the field.
* `earth_re_mag_flg` (`+0x16`) — **Canopy Defense** (Earth Lv3, `magi_no == 0x12`): set to `1`; protects all allies from 1 magic attack.
* `earth_protect_cnt` (`+0x17`) — **Guardian Earth** (Earth Lv4, `magi_no == 0x14`): set to `5` turns; PROT and MDEF Up for all allies.

### Programmatic Application Flows (`GSD2`)

1. **Direct Character Status Application — `PM_DATA.StatusSet(int status_id)` (`0x181A7C5D0`)**
   * Resolves `uint bit = PM_DATA.status_henkan_table[status_id]`.
   * Checks armor/equipment status immunities via `BattlePlayerCharacter.CheckBoguStatusBlock(status_id)`.
   * Dispatches through a jump table on `status_id`:
     * ORs `bit` into `this.status` (`[this + 0x60]`).
     * Initializes companion counters on `PLAYER_STATUS_DATA` (e.g., `boost_cnt = 3` for `SC_BOOST`, `awake_cnt = 3` for `SC_AWAKE`).
     * Enforces mutual exclusions (`SC_BOOST` and `SC_AWAKE` clear `SC_ANGRY` and each other; `SC_TARGET` clears `SC_TARGET` from all other allies).
   * To trigger the floating status icon/animation and SFX when `disp_status` syncs with `status`, the engine calls `PM_DATA.CheckStatusStart(uint org_status, uint new_status, bool is_disp_damage)` (`0x181A796D0`), which diffs the bitmasks and invokes `BATTLE_CHARA.SetStatusStartAnime(status_id, ...)`.

2. **Enchant / Buff Spells — `BattlePlayerCharacter.MagicEnchantFunc(byte embl_no, byte magi_no)` (`0x181B72620`) & `MagicWater4Func` (`0x181B73010`)**
   * Party-wide buffs write directly to `BATTLE_WORK.battle_magic_status` (`water_re_mag_cnt = 3`, `earth_re_mag_flg = 1`, `earth_protect_cnt = 5`, `water_silent_cnt = 3`).
   * Target-specific buffs loop over resolved targets and write directly to `p_status_data[target]` (`magic_status_flg |= 1` for Clay Guardian, `magic_status_flg |= 2` for Storm Warning, `earth_re_atk_cnt = 3` for Revenge Earth, or `ikari_val = 100` + `pm.status |= 0x20000` for **Howling** `magi_no == 0x5E` on monster allies).
   * Appends a reaction entry (`reaction_type = 9` / `RAD_SET_STATUS`) containing the target's updated `pm.status` bitmask so the animation playback phase syncs `disp_status` and plays the visual effect.

3. **Items & Dishes — `BattlePlayerCharacter.SetDoguStatus(DOGU_DATA)` (`0x181B7B1A0`), `CalcDishStatus(byte)` (`0x181B6D590`), & `DishMagicFunc(byte)` (`0x181B6F2E0`)**
   * Standard buff dishes/items translate `DOGU_DATA.status` bits via `BattlePlayerCharacter.status_character_from_item_henkan_table`, roll the item's success probability (`100%`, `60%`, `30%`, or `10%`), and call `PM_DATA.StatusSet(status_id)`.
   * Special magic-casting dishes route through `DishMagicFunc(dish_no)` and invoke `magic_func_table[magi_no](0xFE, magi_no)` directly (e.g., **Meringue Pie** `#75` -> Clay Guardian `0x10`).

4. **Battle-Start Passive Runes — `BattlePlayerCharacter.StatusDataInit(int player_no, int chara_size)` (`0x181B7D740`)**
   * Runs when initializing each party member at battle start: checks equipped runes (e.g., Fury Rune `#87` sets `ikari_val = 100` and `status |= 0x20000`) and mirrors `status` into `disp_status`.

5. **Player Magic Flag Helper — `BattlePlayerCharacter.PlayerStatusSet(ushort status)` (`0x181B7ABC0`)**
   * Directly sets bit flags in `p_status_data[chara_no].magic_status_flg` (`PlayerStatusClear` at `0x181B7AAB0` and `PlayerStatusCheck` at `0x181B7A9A0` clear and test them).

### Buff-Granting Dishes (`GSD2`)

| Buff Type | Dishes |
| :--- | :--- |
| **Invincible (`SC_MUTEKI`)** | Fried Ice Cream (100 HP, 30%), Cream Cutlets (600 HP, 60%), Mayo Curry (700 HP, 60%) |
| **Boost (`SC_BOOST`, 3 turns)** | Red Pepper Ice Cream (250 HP, 30%), Kobold Pie (300 HP, 30%), Spicy Pizza (600 HP, 30%), Kobold Burger (450 HP, 60%), Kobold Course (650 HP, 60%), Salt House (900 HP, 60%) |
| **Awakened (`SC_AWAKE`, 3 turns)** | Pudding (100 HP, 30%), Salmon Meuniere (500 HP, 30%), Elf Course (650 HP, 30%), Sweet Syrup (750 HP, 30%), Black Cake (350 HP, 60%), Sugar-Cured Meat (450 HP, 60%) |
| **Anger / Berserk (`SC_ANGRY`)** | Szechuan Gyoza (100 HP, 30%), Blackened Sole (300 HP, 30%), Cajun Shrimp (400 HP, 30%), Anchovy Pizza (600 HP, 30%), Tinto Specialty (650 HP, 60%) |
| **Toasty / Warm (`SC_HOKA`)** | Baked Ice Cream (100 HP, 30%), Fried Tacos (250 HP, 30%), Sea bream hot pot (350 HP, 30%), Matilda Course (650 HP, 30%) |
| **Clay Guardian (`MS_EARTH_PROTECT_FLG`, 1.5x DEF)** | **Meringue Pie** (`#75` / `0x4B`) — Hardcoded in `DishMagicFunc` to cast Earth Lv1 Clay Guardian (`magi_no = 0x10`) with no HP heal |
| **Random Status (6-way roll, 30%)** | **Mai Mai???** (`#48` / `0x30`, 200 HP), **Dark Stew** (`#203` / `0xCB`, 550 HP) — Hardcoded in `CalcDishStatus` to roll one of `SC_ANGRY`, `SC_HOKA`, `SC_BOOST`, `SC_MUTEKI`, `SC_AWAKE`, or `SC_PANIC` |

---

## Suikoden I (`GSD1`)

Suikoden I has a compact status set defined in `G1_battle_h`:

| Status Constant | Visual/ID Constant | Bitmask / Location | Effect |
| :--- | :--- | :--- | :--- |
| `STATUS_TWICE` | — | `0x4000` in `chara.status` (`+0x46`) | **Double Action / Twice** — Checked by `BattleBase.twice_check(int chara_no)` (`0x1810E19D0`) to grant a second attack/action. |
| `STATUS_MUTEKI` | `SC_MUTEKI` | Lookup table -> `chara.status` (`+0x46`) + flag `[chara + 0x42] = 1` | **Invincible / Protection** (e.g., Earth Rune's Clay Guardian / Protection) — Nullifies physical damage. |

### Programmatic Application Flow (`GSD1`)

* **`BattleBase.set_status(int chara_no, int status_id)` (`0x1810DEFD0`)** is the central entry point:
  1. Checks if the character already has the status active in `BATTLE_WORK.status_chara[chara_no, status_id]`.
  2. Runs a switch on `status_id` (for `SC_MUTEKI`, sets the protection byte `[chara + 0x42] = 1` and maps its animation ID).
  3. ORs the corresponding `ushort` bit from `BattleBase`'s static status-bit table into `[chara + 0x46]`.
  4. Spawns the visual status effect and HD ailment text (`UIBattleStatusAilment`).
* **`BattleBase.reset_status(int chara_no, int status_id)` (`0x1810DCB10`)** clears the bit and removes the visual indicator.
