# Suikoden II HQ Minigames & Castle Subsystems (`honprg`)

## Overview

Dunan Castle's minigames and interactive headquarters subsystems are implemented as **Event Overlays** in `GSD2.dll` (`EventOverlayClass.*` inheriting from `OverlayClassBase`) paired with **211** `AnimeSpriteData` JSON assets (`m_Script.m_PathID: -3654021563660114729`, `"path": "honprg"`) in `D:\Modding\suikodum\Mobobehaviour\Suikoden2`.

When a player interacts with an HQ facility or minigame NPC, `MACHIDAT` bytecode (`ECOverlayPset` / `ECOverlayGo`) instantiates the matching `OverlayClassBase` subclass, streams its `honprg` sprite atlases via Unity Addressables (`gsd2/hd/honprg/...` or `gsd2/classic/honprg/...`), and runs a dedicated per-frame state machine.

---

## 1. `honprg` Asset-to-Code & HQ Area Mapping (211 Files)

| `honprg` Prefix | Count | Addressables Path (`stringliteral.json`) | `EventOverlayClass` & `GSD2` Classes | HQ Map / Cross-Reference |
| :--- | :---: | :--- | :--- | :--- |
| `hp_furo_00`–`42`, `hp_peeping_00` | 44 | `gsd2/hd/honprg/bath/hp_furo`, `bath_{0}/bath_{1}`, `peeping/hp_peeping_1` | `Overlay_furo`, `furo_h`, `f_phase` | `vk06` ([dunan_castle_hq_bathhouse.md](areas/dunan_castle_hq_bathhouse.md)) |
| `hp_rbat_00`–`38`, `hp_rbat0`–`10` | 71 | `"hp_rbat"`, `"hp_rbat0"`–`"hp_rbat10"` | `r_dat`, `r_evdat`, `r_action`, `r_action_h`, `ryo_an` | `vk20` ([dunan_castle_hq_restaurant_and_kitchen.md](areas/dunan_castle_hq_restaurant_and_kitchen.md)) |
| `hp_fish_00`–`04` | 5 | `gsd2/hd/honprg/fishing/fishing_bg` | `Overlay_fishing`, `fish_cal`, `fish_dat`, `fish_def_h`, `fish_dsp`, `Fish108` | HQ Harbor / Pier |
| `hp_mogura_00`–`04` | 5 | `gsd2/{0}/honprg/mogura/hp_mogura_00`, `mogurabg` | `Overlay_mogura`, `mogura_h`, `MoguraBG`, `UIMoguraHeader` | [dunan_castle_hq_farm_and_pastures.md](areas/dunan_castle_hq_farm_and_pastures.md) |
| `hp_kikori_00`–`04` | 5 | `gsd2/hd/honprg/kikori/hp_kikori_00` | `Overlay_kikori`, `kikori_h`, `UIKikoriEffect` | Cliff / Rope Climbing Race (`vb15` / HQ) |
| `hp_odori_00`–`04` | 5 | `"hp_odori"` | Karen's Dance (`odori`) | `vk09` ([dunan_castle_hq_concert_stage.md](areas/dunan_castle_hq_concert_stage.md)) |
| `hp_hsound_01`–`09`, `hp_sndtest_*` | 14 | `gsd2/hd/honprg/opd_parts/sound01` | `hsound`, `hsound_h`, `CheckSoundSet` | Connell's Sound Room |
| `hp_book_00`–`02` | 3 | `opd/honprg/hp_book_01_atlas`, `gsd2/hd/honprg/opd_parts/book` | `book`, `book_h`, `book_main`, `BOOK_DATA`, `BOOK_WORK` | [dunan_castle_hq_library_and_archives.md](areas/dunan_castle_hq_library_and_archives.md) |
| `hp_stone_00`–`02` | 3 | `gsd2/hd/honprg/stone/stonebg` | `stone`, `stone_h`, `STONE_WORK` | Stone of Destiny Tablet |
| `hp_shugo_00` | 1 | `gsd2/hd/honprg/shugo/hp_shugo_00` | `h_shugo` | [dunan_castle_hq_guardian_deity_shrine.md](areas/dunan_castle_hq_guardian_deity_shrine.md) |
| `hp_meyasu_00` | 1 | `"hp_meyasu"` | `meyasu`, `meyasu_h`, `meyasu_main`, `MEYASU_DATA` | Suggestion Box |
| `hp_tantei_00` | 1 | `"hp_tantei"` | `tantei`, `tantei_h`, `TANTEI_WORK` | Richmond's Investigation |
| `hp_rest_00` | 1 | `"hp_rest"` | `h_rest`, `Overlay_h_rest` | Restaurant |
| `hp_souko_00`–`01` | 2 | `"hp_souko"` | `h_souko` | Storage / Warehouse |
| `hp_hmap_00`–`07`, `hp_hwindow_00` | 9 | `honprg/csr/hp_hmap_`, `honprg/csr/hp_hwindow_` | `CheckWindowSet` | HQ Map / Window Set UI |
| `hp_wakeup_00`–`36` | 37 | `"hp_wakeup"` | HQ morning/room wake-up sequences | HQ Bedrooms |

---

## 2. Subsystem Deep Dives

### 2.1 Cook-Off (`hp_rbat*`, `r_dat`, `r_evdat`, `r_action`)
- **`hp_rbat0`–`hp_rbat10` Sprite Mapping:** `hp_rbat0_00` uses `hp_rbat0_00_00_00`, while `hp_rbat1`–`hp_rbat10` map to HQ character sheets (`person_vk06_24_01_00` and `person_vk30_16_01_00`–`person_vk30_26_01_00`).
- **Data Tables (`EventOverlayClass.r_dat`):**
  - `menu00_msg`–`menu41_msg` (**42** recipes) indexed via `menu_msg_table`.
  - Seasonings: `sugar_msg`, `salt_msg`, `soy_msg`, `mayo_msg`, `pepper_msg`, `pepper_msg_table`.
  - Categories: `FOOD_A`–`FOOD_E`, `food_kind_table`, `item_num`.
- **Stage Slots (`EventOverlayClass.r_evdat`):** `InitializeEventCharaDataPositions()` sets up `pc_ann_data`, `pc_hyo_data`, `pc_cha_data`, and 4 judge slots (`pc_ex0_data`–`pc_ex3_data`).
- **Runtime (`EventOverlayClass.r_action`):**
  - `CreateEventWork(EVENT_DATA)` (`0x182186770`)
  - `RB_EventSetAction(ew, action_data, rb_work)` (`0x182188B20`) / `RB_EventActionFunc(ew, func_step, rb_work)` (`0x182187C30`)
  - `CheckEXChara(rb_work, chara_id)` (`0x182186600`) / `GetPCharaData(chara_id)` (`0x182187190`)
  - **Unity Scene Path:** `AppRoot/Map/MapChara/r_action` (monitored by `PKCore`'s [S2CookOffPortraitMonitor.cs](../Patches/S2CookOffPortraitMonitor.cs)).

### 2.2 Fishing (`hp_fish_*`, `Overlay_fishing`, `fish_cal`, `fish_dat`)
- **`Overlay_fishing.BASE_FISHING` (47 fields):**
  - State: `stp`, `demo_stp`, `sub_stp`, `sub_count`, `fishing_mode`, `line_mode`, `msg_stp`, `rtn_to_main`.
  - Tension/Weight: `power_y`, `power_h`, `max_weight`, `distance`, `shu_power`, `shu_pow_timer`, `over_count`, `under_count`.
  - Payout/Stats: `get_fish`, `food_fish`, `add_money`, `wait_time`, `pl_luck`, `pl_power`, `pl_tech`, `pl_speed`.
- **`Overlay_fishing.FISH_DAT` (`fish_dat.fish_init_data[]`):** `normal_size`, `variable_size`, `price`, `add_distance`, `away_count`, `power`, `variable_power`, `pow_range`, `pow_speed`, `max_resist`, `min_resist`.
- **Key Methods:** `fish_cal.BFI_WaitFishing` (`0x181FEB690`), `fish_cal.BFI_IncleaseMoney` (`0x181FEB280`), `fish_cal.gedo_fish_check` (`0x181FEBE50`), `fish_dsp.BFI_DispFishingLine` (`0x181FEEC00`).

### 2.3 Mole Whacking (`hp_mogura_*`, `Overlay_mogura`, `mogura_h`)
- **Methods:** `Overlay_mogura.Entry` (`0x182109BF0`), `mogurainit` (`0x182109C50`), `Load` (`0x182109C00`), `moguramain` (`0x182109E70`), `MoguraBG.<LoadInstance>d__9.MoveNext` (`0x181BFC7C0`).
- **`mogura_h.MOGURA_DAM_WORK`:** `now_score`, `max_score`, `mogura_timer`, `mogura_miss_num`, `mogura_win_flg`, `get_item`, `holl`, `mogura`, `hamon`, `mw` (`UIMoguraHeader`).

### 2.4 Bathhouse (`hp_furo_*`, `Overlay_furo`, `furo_h`, `f_phase`)
- **Methods:** `Overlay_furo.furoinit` (`0x182053D10`), `Overlay_furo.furomain` (`0x182053E60`), `f_phase.FuroPhaseChangeBath` (`0x18201C970`).
- **`furo_h` Constants:** `TENJI_KAIGA` / `TENJI_OKIMONO` (`POS_FRONT`, `POS_RIGHT`, `POS_LEFT`), `FURO_KOMONO_OKE1/OKE2/SHABON/ISU`, `CHARA_STATUS_FURO/ARAI/NOROI`, `HOKA_RGB_VAL` / `COOL_RGB_VAL`.

### 2.5 Guardian Deity (`hp_shugo_00`), Cliff/Rope Climbing (`hp_kikori`), Suggestion Box (`hp_meyasu`), Investigation (`hp_tantei`), Stone (`hp_stone`)
- **`h_shugo`:** Driven by `h_shugo.Entry` and `h_shugo.ShugoMain` (already hooked in `PKCore`'s [GuardianDeityRepeatRewardsPatch.cs](../Patches/GuardianDeityRepeatRewardsPatch.cs)).
- **`Overlay_kikori` (`hp_kikori_00`–`04`):** Despite the internal name `kikori`, `kikori_h.cs` reveals this is the **Cliff / Rope Climbing Race** (`DICE_ICX..ICR`, `CLIFF_UP_FLG`, `CLIFF_DOWN_FLG`, `CLIFF_FALL_FLG`, `CLIME_TIME`, `FALL_TIME`, `START_POS`, `GOAL_POS`, and `UIKikoriEffect.OpenRrankEffect(int rank)`), using `person_va01_09` and `person_vb15_08` sprites.
- **`MEYASU_DATA`:** `SetData(int title_id, int _msg_id, int _chara_id)` (`title`, `msg`, `chara_id` fields), loaded by `EventOverlayClass.meyasu` (`Entry` at `0x1820EDA50`).
- **`tantei` (`Entry` at `0x1821BCCC0`)** & **`stone` (`Entry` at `0x1821A8930`)**.

---

## 3. Harmonization with Existing `PKCore` Docs & Patches

| Existing Doc / Patch | Connection to `honprg` |
| :--- | :--- |
| [suikoden_2_character_attributes_gender_and_baths.md](suikoden_2_character_attributes_gender_and_baths.md) & [suikoden_2_room_item_restoration_whitepaper.md](suikoden_2_room_item_restoration_whitepaper.md) | `Overlay_furo` reads `GAME_DATA.furo_item[8]` (offset `0xA0`, identical structure to unused `room_item[8]` at `0xA8`) for `TENJI_KAIGA` / `TENJI_OKIMONO` bathhouse displays, and enforces male/female/monster bath rules. |
| [guardian_deity_statues_complete_guide.md](guardian_deity_statues_complete_guide.md) & [GuardianDeityRepeatRewardsPatch.cs](../Patches/GuardianDeityRepeatRewardsPatch.cs) | `GuardianDeityRepeatRewardsPatch` hooks `h_shugo.Entry` and `h_shugo.ShugoMain` directly to allow repeat statue combination rewards. |
| [S2CookOffPortraitMonitor.cs](../Patches/S2CookOffPortraitMonitor.cs) | Monitors `AppRoot/Map/MapChara/r_action` during Cook-Off (`vk20`) to render custom portrait overlays. |

---

## 4. Modding Opportunities

1. **Cook-Off (`r_dat` / `r_action` / `r_evdat`):**
   - Hook `r_action.CreateEventWork` (`0x182186770`) or `CheckEXChara` (`0x182186600`) to customize judge lineups (`pc_ex0_data`–`pc_ex3_data`), unlock all 42 recipes (`menu00_msg`–`menu41_msg`) early, or rebalance judge preferences.
2. **Fishing QoL & Rewards (`fish_cal` / `fish_dat`):**
   - Prefix `fish_cal.BFI_WaitFishing` (`0x181FEB690`) to cap `BASE_FISHING.wait_time` for instant bites, or postfix `BFI_IncleaseMoney` (`0x181FEB280`) / modify `FISH_DAT.price` and `max_resist` to adjust payouts and catch difficulty.
3. **Mole Whacking & Dance (`Overlay_mogura` / `hp_odori`):**
   - Postfix `Overlay_mogura.mogurainit` (`0x182109C50`) to extend `MOGURA_DAM_WORK.mogura_timer`, adjust `get_item` reward thresholds, or tweak mole speed flags (`MG_SLOW_ACTION`..`MG_FAST_ACTION`).
4. **Bathhouse Restrictions & Custom Entries (`f_phase` / `Overlay_furo`):**
   - Hook `f_phase.FuroPhaseChangeBath` (`0x18201C970`) to allow mixed/unrestricted party bath combinations or custom `HOKA_RGB_VAL` lighting.
5. **Custom Suggestion Box Entries (`MEYASU_DATA` / `meyasu`):**
   - Hook `EventOverlayClass.meyasu.Entry` (`0x1820EDA50`) and call `MEYASU_DATA.SetData(titleId, msgId, charaId)` with `text_add` IDs to inject custom player hints or mod announcements into the Suggestion Box.
