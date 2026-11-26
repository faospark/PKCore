# Suikoden II War Battle Animation Assets (`war`)

## Overview

Complementing the tactical combat, ability, and squad guide in [war_battle_modding.md](war_battle_modding.md), `D:\Modding\suikodum\Mobobehaviour\Suikoden2` contains **19** *Suikoden II* `AnimeSpriteData` JSON files (`war_01_00.json`–`war_01_18.json`, `m_Script.m_PathID: -3654021563660114729`, `"path": "war"`).

> [!NOTE]
> The 8 `war_gara_00.json`–`war_gara_07.json` files (`spr0: war_000000..war_000223`) also use `"path": "war"`, but Addressables (`gsd1/classic/opd_hd/war/war_gara_07`, `gsd1/hd/war/war_gara_map_00`) confirm they belong to **Suikoden I (`GSD1`)** and have been organized into `Suikoden1\`.

---

## 1. Suikoden II `war_01_*` Asset Catalog (19 Files)

Addressables paths (`stringliteral.json`): `"gsd2/hd/war/war_01_01"`, `"gsd2/hd/war/eff_gsd2_war_01/eff_gsd2_war_01"`, `"csr/war_01_warlcsr"`, `"war/war_01"`.

| File | `anime_kazu` | `pattern_kazu` | `spr0` | Role |
| :--- | :---: | :---: | :--- | :--- |
| `war_01_00.json` | 116 | 236 | `war_01_00_00_00` | Master war unit animation bank (idle, march, attack, wounded states) |
| `war_01_01.json` | 6 | 34 | `war_01_01_00_00` | Shared war UI / cursor / indicator animations |
| `war_01_02.json` | 13 | 64 | `war_01_02_00_00` | Tactical overlay / unit action effects |
| `war_01_03.json` | 4 | 4 | `war_01_03_00_00` | Minimal state icon set |
| `war_01_04.json` | 24 | 74 | `war_01_04_00_00` | Unit class / faction animation set |
| `war_01_05.json` | 30 | 94 | `war_01_05_00_00` | Extended unit class animation set |
| `war_01_06.json` | 24 | 114 | `war_01_06_00_00` | Unit class animation set |
| `war_01_07.json` | 30 | 136 | `war_01_07_00_00` | Extended unit class animation set |
| `war_01_08.json` | 24 | 114 | `war_01_08_00_00` | Unit class animation set |
| `war_01_09.json` | 22 | 136 | `war_01_09_00_00` | Unit class animation set |
| `war_01_10.json` | 4 | 12 | `war_01_10_00_00` | Small effect / projectile set |
| `war_01_11.json` | 6 | 70 | `war_01_11_00_00` | Effect / overlay set |
| `war_01_12.json` | 17 | 57 | `war_01_12_00_00` | Special unit / boss animation set |
| `war_01_13.json` | 24 | 114 | `war_01_13_00_00` | Unit class animation set |
| `war_01_14.json` | 30 | 136 | `war_01_14_00_00` | Extended unit class animation set |
| `war_01_15.json` | 30 | 136 | `war_01_14_00_00` | Extended unit class animation set (shares `war_01_14` base sprite) |
| `war_01_16.json` | 24 | 114 | `war_01_16_00_00` | Unit class animation set |
| `war_01_17.json` | 24 | 114 | `war_01_17_00_00` | Unit class animation set |
| `war_01_18.json` | 24 | 114 | `war_01_18_00_00` | Unit class animation set |

---

## 2. Runtime Engine Architecture (`w_anime`, `war_h`, `war_data_h`, `WAR_DATA`)

### 2.1 `w_anime` Methods (`GSD2.dll` / `script.json`)
| Method | VA | RVA | Purpose |
| :--- | :--- | :--- | :--- |
| `war_InitAnime(int max_anime)` | `0x181E2E0E0` | `0x01E2E0E0` | Allocates the war animation pool |
| `war_WaitInitAnime()` | `0x181E2E930` | `0x01E2E930` | Waits for async `war_01_*.json` atlas loading |
| `war_SetAnimeType(int type)` | `0x181E2E760` | `0x01E2E760` | Instantiates `ANIME_o*` for a unit/effect type |
| `war_ChangeAnime(ANIME anime, int num)` | `0x181E2DF50` | `0x01E2DF50` | Switches active `anime_table[num]` sequence |
| `war_SetAnimePri(...)` | `0x181E2E740` | `0x01E2E740` | Sets draw priority on the war grid |

### 2.2 `war_h`, `war_data_h`, & `WAR_DATA`
- **Map & Grid (`war_h`):** `g_w_map_no`, `g_w_war_no`, `war2map`, `SQUARE_MAX_X`, `SQUARE_MAX_Y`, `SQUARE_X_SIZE`, `SQUARE_Y_SIZE`, `getWarFlag(int f)`, `getWarNoName()`.
- **Forces & Control (`war_h`):** `ALLIANCE_FORCE`, `KINGDOM_FORCE`, `ALL_FORCE`, `CONTROL_PLAYER`, `CONTROL_CPU`, `CONTROL_EXTRUST`, `UNIT_MAX`.
- **Draw Priority Layers (`war_h`):** `UNIT_PRIORITY`, `FIELD_EFFECT_PRIORITY`, `CHIBI_PRIORITY_MIN..MAX`, `ARROW_PRIORITY`, `CURSOR_PRIORITY`, `EVENT_ANIME_PRIORITY`, `FADE_PRIORITY`.
- **Unit Classes & Flags (`war_data_h`):** `INFANTRY`, `ARCHER`, `MAGICIANS`, `MAGIC_THUNDER`, `MAGIC_FIRE`, `MAGIC_WIND`, `UNIT_FLAG_WAIT`, `UNIT_FLAG_ON_STAGE`, `UNIT_FLAG_DESTROY`, `UNIT_FLAG_PRE_*`.
- **`WAR_DATA`:** Stores `byte[] leader_no`, `byte[] sub_no`, `sbyte[] sub_to_leader`, which determine which unit sprites `w_anime` binds to each squad.

---

## 3. Harmonization with Existing `PKCore` Docs & Patches

| Existing Doc / Code | Connection |
| :--- | :--- |
| [war_battle_modding.md](war_battle_modding.md) | Documents `w_battle`, `w_unit`, `w_chara`, `w_data`, and `tagSPECIAL_ABILITY` combat formulas that drive `w_anime` state transitions. |
| [S2WarReplayData.cs](../forlater/WarBattleReplay/S2WarReplayData.cs) & `S2WarReplayMenu.cs` | Catalogs all **16** Suikoden II War Battles (`w_dat_1..16`, `WarNo`, `MapNo`, `AllyCount`, `EnemyCount`, `CheckSyouhai` rules) that load `war_01_*` sheets. |
| [CommandRuneReusePatch.cs](../Patches/CommandRuneReusePatch.cs) & [WarAbilityConfigLoader.cs](../Patches/WarAbilityConfigLoader.cs) | Hooks `w_battle.SetSelectTokusyuStepInit` / `SelectTokusyuStepInit` and parses `war_data_h.tagSPECIAL_ABILITY` for custom war abilities. |
| [custom_textures_guide.md](custom_textures_guide.md) | Explains HD texture replacement for `war_01_*` unit/banner sprites. |

---

## 4. Modding Opportunities

1. **Expanding Animation Pool for Custom / Replay Scenarios (`w_anime.war_InitAnime`):**
   - Prefix `w_anime.war_InitAnime(ref int max_anime)` (`0x181E2E0E0`) when spawning extra squads beyond `UNIT_MAX` in custom war battles or `WarBattleReplay` scenarios.
2. **Custom Faction & Unit Sprite Overrides (`war_01_00`–`war_01_18`):**
   - Remap `sprite_name` entries or `w_anime.war_ChangeAnime` (`0x181E2DF50`) to swap unit class visuals (Infantry / Archer / Magicians / Cavalry) or add custom faction banners.
3. **War Battle Speed-Up:**
   - Halve `timer_table[].timer` values in `war_01_00.json`–`war_01_18.json` (or scale `w_anime` frame timers) to speed up slow marching and clash animations across all 16 war battles.
