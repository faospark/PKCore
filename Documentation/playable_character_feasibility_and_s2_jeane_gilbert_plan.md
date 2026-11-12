# Playable Battle Character Feasibility Research & Suikoden II Jeane / Gilbert Roadmap

This document records the technical feasibility analysis for adding new playable combat characters in **Suikoden I & II HD Remaster** (`GameAssembly.dll`, Unity 2022.3.28f1 IL2CPP, BepInEx 6.0.0-pre.2), followed by the **Suikoden II (`GSD2`)** implementation blueprint specifically targeting existing non-combat recruits **Jeane (ID `116`)** and **Gilbert (ID `121`)**.

---

## 1. Executive Verdict

- **Adding a playable character to battle (Suikoden II & Suikoden I)**: **Yes — fully feasible** at runtime via BepInEx 6 + Harmony, **without repacking Addressables `.bundle` files**.
- **Promoting existing Suikoden II NPC recruits (`Jeane = 116`, `Gilbert = 121`)**: **Ideal starting path.** Both IDs already sit inside the engine's `128`-slot character/flag tables (`chara_flag`, `ckd_info`, `suki_value`), below the `128` ceiling in `G2_SYS.G2_chara_size`, within `c_teg_dat.name[180]`, and already have official Classic and HD portraits in `ImageLoader` (`fp_116` and `fp_121`).
- **Expanding active battle party size beyond 6 members**: **Practically blocked.** Both games hard-cap active combat slots at `6` across `PARTY_DATA`, HUD controllers (`UIBattleWindowUnit.MAX_MEMBER_NUM = 6`), initialization (`BattleManager.PlayerInit`), and save/store loops.

### Approach Comparison Matrix

| Approach | Feasibility | Complexity | Key Constraints & Blockers |
| :--- | :--- | :--- | :--- |
| **A. Promote existing NPC IDs `116` (Jeane) & `121` (Gilbert) in Suikoden II** | **High** | **Moderate** | Requires expanding `c_kotei_dat`, `c_varia_dat`, and `arms_data` to `>= 122`; patching `Overlay_partychg`/`Overlay_partychg1` `< 0x52` loops; synthesizing `P_GRAPH_DATA` / `OPD_DATA` battle sprite sheets & action tables at runtime |
| **B. Repurpose empty slot `84` (Suikoden II)** | **High** | **Moderate** | Slot `84` (`Bonaparte` in `gamedata.json`) is zeroed in `c_kotei_dat`/`c_varia_dat` (`len = 85`), lacks `arms_data` (`len = 84`), lacks `player_tbl` entry, and is skipped by `Overlay_partychg` (`< 0x52`) |
| **C. Add brand-new ID `>= 128` (`128..254`)** | **Moderate–High** | **High** | `chara_id` is typed as `byte` (`1..254` hard ceiling; `0` / `255` are sentinels). Requires also expanding `chara_flag`/`ckd_info`/`suki_value` (default `128`) and bypassing `G2_SYS.G2_chara_size` (`< 0x80`) |
| **D. Exceed 6 active battle party members** | **Very Low** | **Extreme** | Hardcoded `6`-slot bounds in `BattleManager.PlayerInit`, `PARTY_DATA`, `UIBattleWindowUnit.MAX_MEMBER_NUM = 6`, GSD1 `GAME_WORK.player_data[6]`, and GSD1 `BATTLE_WORK.p_battle_data[7]` |

---

## 2. Suikoden II (`GSD2`) Subsystem Breakdown

### 2.1 Master Character Tables & `byte` ID Limits
- **Hard `byte` ID ceiling (`1..254`)**: Core runtime structs store character IDs as `uint8_t` / `byte` (e.g., `P_GRAPH_DATA.chara_id`, `PARTY_DATA.party_cha_no[]`, `P_BATTLE_DATA.chara_id`, `UIStatusWindow.UpdateStatusData(uint8_t)`, `BattlePlayerCharacter..ctor(..., uint8_t ID, ...)`). Any mod ID must remain within `1..254`.
- **Vanilla array sizes** (verified in `GAME_WORK..ctor` `0x181A47510`, `CHARA_DATA..ctor` `0x181A441D0`, decrypted `Data0.json`, and `PKCore/tools/symbol_indexer/gamedata.json`):
  - `CHARA_DATA.c_kotei_dat`: length **`0x55` (`85`)** — indices `1..83` populated (`80..83` = Jowy 1, Jowy 2, McDohl, Milie Sans Bonapart); indices `0` and `84` are all-zeroes in `Data0.json`.
  - `CHARA_DATA.c_varia_dat`: length **`0x55` (`85`)** — mirrors `c_kotei_dat` for mutable stats (level, HP, EXP, weapon level, equipped runes, armor).
  - `GAME_WORK.arms_data`: length **`0x54` (`84`, indices `0..83`)** (`ARMS_DATA`: `name_1`, `name_2`, `name_3`, `byte[] info`, `byte mon_no`). Loaded at initialization from `IMPORT_GAME_DATA` (`"gamedata/gamedata"`).
  - `CHARA_DATA.chara_flag`, `ckd_info`, `suki_value`: length **`0x80` (`128`)** — War/NPC/convoy characters occupy indices `85..121`, and `126..127` are `"NA-"` placeholders.
  - `GAME_WORK.c_teg_dat.name`: length **`0xb4` (`180`)** — maps character IDs to name string IDs read by `G2_SYS.G2_name_get_org` (`0x181A34CB0`) -> `string_h.SID_NAME` (`0x181A54230`).
  - `PARTY_DATA.party_cha_no`: length **`8`** — indices `0..5` are active combat members; indices `6..7` are convoy/attendant slots. `status`, `st_cnt`, and `hoka_time` are length **`6`**.

### 2.2 `G2_SYS` Bounds Checks (Dynamic vs. Hardcoded)
Disassembly of core `G2_SYS` accessors shows almost all lookup functions check `.Length` (`[reg + 0x18]`) dynamically rather than hardcoding `84`, `85`, or `128`:
- **Dynamic `.Length` checks**:
  - `G2_SYS.G2_kotei_dat` (`0x181A330E0`)
  - `G2_SYS.G2_varia_dat` (`0x181A370B0`)
  - `G2_SYS.G2_gra_dat` (`0x181A2F1F0`)
  - `G2_SYS.G2_cha_flag` (`0x181A29990`)
  - `G2_SYS.G2_arms_range` (`0x181A28D40`)
  - `G2_SYS.G2_arms_name` (`0x181A28A60`)
  - `G2_SYS.G2_arms_lv_up` (`0x181A28710`)
  - `G2_SYS.G2_name_get` (`0x181A34C10`) / `G2_name_get_org` (`0x181A34CB0`)
  - `G2_SYS.G2_chara_para` (`0x181A2BCD0`)
- **Hardcoded checks found**:
  - `G2_SYS.G2_chara_size` (`0x181A2C6A0`): explicitly checks **`cmp ebx, 0x80` (`>= 128`)** and returns early. Using IDs `< 128` (such as `116` and `121`) stays under this check naturally.

### 2.3 Save / Load Serialization (`GSD2SaveData`)
- `GSD2SaveData.SaveFile` (`0x181E01EF0`) builds `GSD2SaveData.TmpSave` holding direct references to live `chara_data`, `party_data`, `chara_flag`, etc., and serializes via **`LitJson.JsonMapper.ToJson` (`0x18235E8C0`)**.
- `GSD2SaveData.LoadDataCore` (`0x181E01130`) deserializes via **`UnityEngine.JsonUtility.FromJson<TmpSave>` (`0x1806BE570`)** and assigns the deserialized object/array references directly onto `G2_SYS` (`[rdi + 0x50]` `chara_data`, `[rdi + 0x78]` `chara_flag`, etc.) **without copying elements into fixed preallocated arrays**.
- **Result**: Expanding `c_kotei_dat` and `c_varia_dat` past `85` survives save/load round-trips cleanly. A Harmony postfix on `LoadDataCore` (plus new-game initialization) is still required to pad vanilla `85`-length saves when loaded with the mod active.

### 2.4 Battle Assets, Animations & `.bundle` Bypass (`PlayerDataLoader`, `OPD_DATA`, `area_func`)
- `PlayerDataLoader` (`0x182031E80` `.cctor`, `0x1820353A0` `LoadPlayerData`) resolves `player_tbl` (`Dictionary<int, string>`, keys `1..83`) and `doko_tbl` (convoy keys up to `172` / `0xac`) through `Addressables.LoadAssetAsync<P_GRAPH_DATA>` (`0x1806DC090`) and caches results in `loadPlayerDataList`.
- `P_GRAPH_DATA` contains:
  - `byte chara_id` (`+0x18`)
  - `PLAYER_BATTLE battle_data` (`+0x20`): `ACTION_TABLE_DATA[] action_table` (`short[] action`, `int action_num`, `int overlay_func_index`), `OPD_DATA opd_data`, `tokitama_data`, `tokitama_prob`, `shadow_offset_x/y`, `victory_action_no`
  - `PLAYER_FIELD field_data` (`+0x28`)
- **`OPD_DATA.GetSprite` (`0x1822974F0`)** checks **`Dictionary<string, Sprite> sprites` (`+0x48`) BEFORE calling `SpriteAtlas.GetSprite` (`+0x40`)**.
- **Result**: Custom `.bundle` repacking is unnecessary. A mod can load external PNG sheets into `Texture2D`, slice `Sprite` objects matching `pattern_table` frame names, populate `OPD_DATA.sprites`, clone `AnimeTable`/`PatternTable`/`ACTION_TABLE_DATA` from an existing donor character (which preserves `overlay_func_index` dispatch in `area_func.GetBattleCharaOverlayFunction` at `0x181AC9BB0`), and register the synthesized `P_GRAPH_DATA` into `PlayerDataLoader`.

### 2.5 Battle Pipeline & UI
- **Combat initialization & teardown**: `BattleManager.PlayerInit` (`0x18143C9C0`) iterates `party_cha_no[0..5]` (`cmp ebx, 6`), fetches `G2_gra_dat` / `G2_varia_dat`, constructs `BATTLE_CHARA` (`0x1814058C0`) and `BattlePlayerCharacter` (`0x181B82B10`), and saves back after combat via `BattleManager.StorePlayerData` (`0x181443460`).
- **HUD limit**: `UIBattleWindowUnit.MAX_MEMBER_NUM = 6`.
- **Optional per-ID battle tables**: `BattlePlayerCharacter` defines static per-ID tables (`kireru_chara_table`, `kabau_chara_table`, `ikari_data_table`, `status_character_from_item_henkan_table`, `ofuda_magic_table`) and `BATTLE_WORK.GetUniteData` (`0x181A41050`) looks up unite attacks. Missing entries fall back safely without breaking basic combat, or can be extended in memory if desired.
- **Party formation menu blocker**: `EventOverlayClass.Overlay_partychg.PCpartyAllTblSet` (`0x18210E760`) and `Overlay_partychg1.PCpartyAllTblSet` (`0x18217AD20`) both hardcode **`for (int i = 1; i < 0x52; i++)` (`1..81`)**, checking `G2_cha_flag(4, i) == 1 && G2_cha_flag(9, i) != 1`. Any character at `>= 82` requires patching or replacing `PCpartyAllTblSet` so the character appears in headquarters/entourage party selection.
- **Portraits**: `BattleManager.SetPartyCharacterFace` (`0x181440C90`), `UIBattleManager.<LoadCharacterFace>d__16.MoveNext` (`0x181F2E100`), and `UIStatusWindow.UpdateStatusData` (`0x181E1A1D0`) resolve via `ImageLoader.LoadAsyncImage` (`0x181E029B0`) -> `ImageLoader.GetImagePath` (`0x181E02900`) and static caches (`images`, `HDImages`, `AsyncImages`, `HDAsyncImages`, `imageList`, `hdImageList`).

---

## 3. Suikoden II Implementation Blueprint: Jeane (`116`) & Gilbert (`121`)

### 3.1 What Already Exists in Vanilla GSD2

| Component | Jeane (ID `116` / `0x74`) | Gilbert (ID `121` / `0x79`) | Notes |
| :--- | :--- | :--- | :--- |
| **`chara_flag[id]`** | Populated (`71` = `0x47` in late save) | Populated (`71` = `0x47` in late save) | Mode 4 (`0x04`) = recruited is set natively when they join headquarters/after Muse |
| **`ckd_info[id]`** | `[36, 160]` in `Data0.json` | `[4, 160]` in `Data0.json` | Within `128`-slot `ckd_info` and `suki_value` |
| **`G2_chara_size` (`< 128`)** | Valid (`116 < 128`) | Valid (`121 < 128`) | No `G2_chara_size` patch needed |
| **Portraits (`ImageLoader`)** | `"gsd2/classic/face/fp_116"` & `"gsd2/hd/face/fp_116"` | `"gsd2/classic/face/fp_121"` & `"gsd2/hd/face/fp_121"` | **Built-in Classic & HD portraits exist** (`stringliteral.json` `0x3861968`/`0x386BC70`, `0x3861D30`/`0x386C050`) |
| **Name (`c_teg_dat.name[180]`)** | Within `180` (`SID_NAME` entry exists) | Within `180` (`SID_NAME` entry exists) | May still verify/alias weapon names (`arms_data[id]`) |
| **`c_kotei_dat` & `c_varia_dat` (`len 85`)** | **Missing** (`116 >= 85`) | **Missing** (`121 >= 85`) | Must resize arrays to `>= 122` (recommend `128`) & initialize entries |
| **`GAME_WORK.arms_data` (`len 84`)** | **Missing** (`116 >= 84`) | **Missing** (`121 >= 84`) | Must resize array to `>= 122` (recommend `128`) & add `ARMS_DATA` |
| **`PlayerDataLoader.player_tbl` / `doko_tbl`** | **Missing in both** | **Missing in both** | Neither has a vanilla `P_GRAPH_DATA` SO; needs runtime synthesis + PNG battle sprite sheet |
| **Party Selection (`PCpartyAllTblSet`)** | **Skipped (`>= 82`)** | **Skipped (`>= 82`)** | Must hook `Overlay_partychg` / `Overlay_partychg1` |

### 3.2 Step-by-Step Implementation Checklist (Suikoden II)

1. **Expand Runtime Arrays to `128` Slots (`>= 122`) Safely**:
   - Hook `GAME_WORK` / `IMPORT_GAME_DATA` initialization **and** `GSD2SaveData.LoadDataCore` (`0x181E01130`) postfix.
   - Resize `CHARA_DATA.c_kotei_dat` (from `85` -> `128`), `CHARA_DATA.c_varia_dat` (from `85` -> `128`), and `GAME_WORK.arms_data` (from `84` -> `128`) if `.Length < 128`, preserving all existing elements (`0..84` / `0..83`).
   - Populate `C_KOTEI_DAT`, initial `C_VARIA_DAT` (level, HP, weapon level, initial rune(s), armor/helm), and `ARMS_DATA` (weapon names/levels/range/element/unattachable rune if any) for indices `116` (Jeane) and `121` (Gilbert).
     - Recommended donor stat/weapon templates: e.g., magic/mid-or-long-range staff user (like Luc / Mazus / Viki) for **Jeane (`116`)**, and short-range spear/halberdier (like Tsai / Shiro / Viktor / Humphrey) for **Gilbert (`121`)**.

2. **Synthesize & Register `P_GRAPH_DATA` / `PLAYER_BATTLE` / `OPD_DATA` at Runtime**:
   - Prepare custom HD/Classic PNG battle sprite sheets for Jeane (`116`) and Gilbert (`121`) matching a chosen donor's frame layout (`PatternTable` frame keys & `AnimeTable` frame timing), plus custom/cloned field walking frames if they will follow Riou or appear on maps when active.
   - Clone a donor `P_GRAPH_DATA` (e.g., matching desired attack range and `overlay_func_index` in `ACTION_TABLE_DATA` so `area_func.GetBattleCharaOverlayFunction` handles movement, hit frames, return, spell casting, and victory pose accurately).
   - Set `pGraph.chara_id = 116` / `121`, clear `opd_data.atlas` / populate `opd_data.sprites` (`Dictionary<string, Sprite>`) with sliced `Sprite`s (`Sprite.Create(...)`) so `OPD_DATA.GetSprite` (`0x1822974F0`) returns custom sprites immediately.
   - Insert into `PlayerDataLoader.loadPlayerDataList` (and `player_tbl`, or prefix `PlayerDataLoader.LoadPlayerData` to return the cached object immediately and invoke `onLoadEnd`).

3. **Expose in Party Change Menu (`Overlay_partychg` & `Overlay_partychg1`)**:
   - Hook `EventOverlayClass.Overlay_partychg.PCpartyAllTblSet` (`0x18210E760`) and `Overlay_partychg1.PCpartyAllTblSet` (`0x18217AD20`).
   - Replace/extend the `< 0x52` loop so `116` (Jeane) and `121` (Gilbert) are evaluated against `G2_cha_flag(4, id) == 1 && G2_cha_flag(9, id) != 1` (plus optional story/mod availability gates, e.g., ensuring Gilbert survives/is recruited before adding him, and guarding edge cases like rune-shop/war scenes).

4. **Weapon Names, Status / Blacksmith / Bath / Unite Edge Cases**:
   - Register custom weapon name text keys used by `ARMS_DATA.name_1..name_3` via a `TextDatabasePatch`-style lookup hook so Blacksmith (`kaji`) and Status windows display proper weapon titles for Jeane and Gilbert.
   - Verify `EquipPossibleType` / `C_KOTEI_DAT.soubi_kanou` & `soubi_henkou = 1` so Jeane gets female/mage-compatible armor (`Body_Robe`, `Head_Hat`, female accessories) and Gilbert gets male/warrior gear.
   - Check `EventOverlayClass.f_main.GetSeibetu` / bathhouse behavior (`suikoden_2_character_attributes_gender_and_baths.md`) and NPC conflict rules (e.g., what happens at the HQ Rune Shop when Jeane is currently in `party_cha_no` or during war battles involving Gilbert).

---

## 4. Reference Notes: Suikoden I (`GSD1`) Architecture (Future Phase)

Unlike Suikoden II's direct ID-indexed arrays, **Suikoden I (`GSD1`) uses an indirection layer** with tighter hardcoded limits:

- **Enum vs. `player_base` split**: `CHARACTER_ID` defines **`166`** constants (`0..165`) and `GAME_WORK.member_flag` has **`128` (`0x80`)** bytes, whereas `GAME_WORK.player_base` (`PLAYER_BASE[]`) allocates only **`0x4e` (`78`)** elements (`GAME_WORK..ctor` `0x1812541C0`). Each `PLAYER_BASE` carries an explicit `int chara_no` (`+0x10`), alongside stats, `seicho_type`, `buki_data`, `monsyo_data`, and `item`.
- **Hardcoded `0x4e` (`78`) linear searches**: `D_azukar_c.get_player_base_address` (`0x18127CC40`) and `Village_c.get_player_base` (`0x18139D170`) scan **`for (int i = 0; i < 0x4e; i++)`** comparing `player_base[i].chara_no == chara_id`. Expanding `player_base` past `78` requires Harmony prefixes replacing these loops (and any equivalents in party/status UI), even though `SaveDataManager.CopyGameWorkToSaveData` (`0x181325380`) and `CopySaveDataToGameWork` (`0x181325640`) assign array references directly via JSON like `GSD2`.
- **Runtime character data**: `PlayerManager.player_id_table` (`0x1813B2B70`) maps `CHARACTER_ID -> asset name`, cached in `player_cache` (`Dictionary<int, PLAYER_DATA>`) returned by `PlayerManager.GetPlayerData` (`0x1813B25C0`, called by `P_player_c.LoadPlayer` `0x181255F40`, `BattleDirect.SetMember` `0x1811CB910`, `UICharacterStatusExtension.SetCharacterStatus` `0x181333820`). `PLAYER_DATA` embeds `byte chara_id` (`1..254` ceiling), `PLAYER_BASE`, `PLAYER_BATTLE_SO` (`action_table`, `action_function_index`, `opd_data`), `PLAYER_FIELD`, and `PLAYER_FACE`.
- **Party size limit (`6`)**: `GAME_WORK.player_data` is `PLAYER_DATA[6]`, `PARTY_DATA.chara_code` is `short[6]`, and `BATTLE_WORK..ctor` (`0x1812520D0`) allocates `p_battle_data` at length `7` (`b_chara` `0x14`, `pm_data` `0xd`).
