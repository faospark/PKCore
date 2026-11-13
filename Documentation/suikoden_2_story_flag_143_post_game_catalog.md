# Suikoden II Story Flag `143` (`0x8F`) — Post-Final-Boss Gated Content Catalog

## Overview

In **Suikoden II HD Remaster** (`GSD2`), **Event Flag `143` (`0x8F`), bit `0x01`** (`1`) tracks whether the player has **defeated the final boss (Silver Beast Rune)** in L'Renouille (`vj08`) and entered the post-war / epilogue world state.

Scanning all **4,733** map JSONs in `D:\Modding\suikodum\Mobobehaviour` via `tools/mobo_query.bat --flag 143 --map "*" --limit 10000` reveals **1,084** `FlgOnAnd(143, 1)` / `FlgOffAnd(143, 1)` checks across **43 maps**.

> [!NOTE]
> `event_flag[143]` is an 8-bit byte. Only **bit `0x01`** (`1`) represents defeating the Beast Rune. Other bits on byte `143` track unrelated progression (for example, bit `0x02` tracks the Greenhill liberation arc used for Castle Level 3 in [`suikoden_2_castle_level_upgrade_mechanics.md`](suikoden_2_castle_level_upgrade_mechanics.md)).

---

## 1. Shops, Ending Gates & Special Triggers

| Map ID | Location | Submap & Event(s) | Condition (`eventForm`) | Behavior Gated by `143 & 0x01` |
| :---: | :--- | :--- | :--- | :--- |
| **`vj17`** | **Sajah Village** (Multi-Shop Interior) | `sub=1` `ev[2]` (`etyp=2`)<br>`sub=1` `ev[10]`, `ev[11]` (`etyp=1`) | `[3, 143, 1, 255, 254]`<br>`[3, 143, 1, 5, 11/15, 255, 254]` | **Hidden Rare Item Shop**: Spawns the upper-right rare item vendor (`eventobj[3]`, `fpno=65174` at `x: 45, y: 26`) and counter hitbox (`eventobj[7]` at `x: 44, y: 28`), and unlocks the shop dialogue and buy menu (`opcode 96`). See [`sajah_village_rare_shop_vj17.md`](sajah_village_rare_shop_vj17.md). |
| **`vk07`**<br>**`vk13`**<br>**`vk16`** | **Dunan Castle HQ** (Castle Levels 1–4) | `vk07` `sub=3` `ev[122..123]` (Lv1)<br>`vk13` `sub=0` `ev[91..92]` (Lv2)<br>`vk13` `sub=7` `ev[48..49]` (Lv3)<br>`vk16` `sub=0` `ev[13..14]` (Lv4) | `[3, 143, 1, 4, 134, 1, ..., 33, 0, <1..4>, 255, 254]` | **Great Hall Celebration / Ending Gate**: When `143 & 0x01` is ON and `134 & 0x01` is OFF, spawns a guard (`vk07 obj[31]`, `vk13 sub=0 obj[14]`, `vk13 sub=7 obj[10]`, `vk16 obj[14]`) who directs Riou to the Great Hall (*"Many important people from across the land are in the hall above. Shouldn't you be there too, Commander?"*) and sets ending/celebration state flags (`134 \|= 0x01`, `134 \|= 0x08`, `144 \|= 0x10`, `45..48`). |
| **`vj08`** | **L'Renouille — Beast Rune Sanctum** | `sub=0` `ev[11]` (`etyp=128`)<br>`sub=0` `ev[13]` (`etyp=1`) | `[3, 143, 1, ...]` | **Post-Boss Sanctum Exit**: Enables `ECMachiStControll` (`31`) and `ECSMapChenge` (`32`) transitions out of the Beast Rune chamber. |
| **`vj16`** | **L'Renouille — Royal Throne Room** | `sub=0` `ev[3]` (`etyp=128`)<br>`sub=0` `ev[4]` (`etyp=1`) | `[3, 220, 2, 3, 220, 1, 3, 143, 1, ...]` | **Post-Boss Throne Room Exit**: Enables `ECMachiStControll` (`31`) and `ECSMapChenge` (`32`) transitions after victory. |
| **`vj04`** | **L'Renouille — Interior** | `sub=0` `ev[5]`, `ev[6]` (`etyp=128`) | `[..., 3, 143, 1, 3, 220, 1, ...]` | **Post-Boss Castle Transitions**: `ECMachiStControll` (`31`) transitions (`6` `FlgOffAnd(143, 1)` events disable pre-victory state). |
| **`vj01`** | **L'Renouille — Outer Fortress & Gates** | `sub=0` `ev[17]` (`etyp=128`) | `[1, 19, 61, 2, 70, 97, 3, 143, 1, 255, 254]` | **Post-Boss Gate Transition**: `ECMachiStControll` (`31`) transition, while `86` `FlgOffAnd(143, 1)` events disable pre-victory Highland garrisons and barricades. |
| **`va03`** | **Kyaro Town** | `sub=1` `ev[61]`, `ev[66]`, `ev[71]` (`etyp=1`) | `[3, 143, 1, 5, <9..11>, 255, 254]` | **Post-War Shop / Service Menus**: `opcode 96` shop/service interactions in Kyaro Town alongside 15 epilogue NPC dialogues. |
| **`va05`** | **Kyaro — Genkaku & Riou's Home** | `sub=0` `ev[12]`, `ev[13]` (`etyp=1`) | `[3, 143, 1, 4/3, 37, 32, 5, 30, 9, 1, 255, 254]` | **Post-War Dojo Interaction**: Conditional interaction gated by `143 & 0x01` and `flag 37 & 0x20`. |
| **`va13`** | **Kyaro / Highland Interior** | `sub=0` `ev[2]` (`etyp=2`)<br>`sub=0` `ev[9]` (`etyp=1`) | `[3, 143, 1, 255, 254]`<br>`[3, 143, 1, 7, 1, 255, 254]` | **Post-War Room Init & Interaction**: `etyp=2` object initialization (`ev[2]`) and `etyp=1` interaction (`ev[9]`). |
| **`vg13`** | **Crom Village — Village Center** | `sub=1` `ev[1]` (`etyp=2`) | `[3, 143, 1, 255, 254]` | **Post-War Map Init**: `etyp=2` object state setup (`ev[1]`) in addition to 16 epilogue NPC dialogues. |

---

## 2. World-Wide Epilogue NPC Dialogue

Across the world, **`FlgOnAnd(143, 1)`** swaps in post-war / epilogue NPC dialogue (replacing **`FlgOffAnd(143, 1)`** pre-victory lines) in the following maps:

| Region | Map ID | Location | `FlgOnAnd(143, 1)` | `FlgOffAnd(143, 1)` | Notes |
| :---: | :---: | :--- | :---: | :---: | :--- |
| **`va`** | `va03` | Kyaro Town | 18 | 19 | 15 dialogues + 3 `opcode 96` shop/service events |
| **`vc`** | `vc06` | Sindar Ruins — Exterior | 24 | 24 | Post-war NPC dialogue |
| **`vc`** | `vc17` | Coronet Town | 2 | 2 | Post-war NPC dialogue |
| **`vc`** | `vc18` | Coronet Port | 10 | 10 | Post-war NPC dialogue |
| **`vc`** | `vc21` | Muse / Coronet Commercial District | 24 | 24 | Post-war NPC dialogue |
| **`vc`** | `vc26` | Muse City — Post-Liberation Square | 33 | 33 | Post-war NPC dialogue |
| **`vd`** | `vd03` | South Window City Hall | 13 | 13 | Post-war NPC dialogue (`opcode 24`) |
| **`vd`** | `vd16` | Kuskus Town — Main Streets | 0 | 1 | Disables 1 pre-victory event |
| **`vd`** | `vd17` | South Window / Radat Shops | 20 | 20 | Post-war NPC dialogue (`opcode 24`) |
| **`ve`** | `ve01` | Greenhill City Gates | 10 | 10 | Post-war NPC dialogue |
| **`ve`** | `ve02` | Forest Village | 14 | 14 | Post-war NPC dialogue (`opcode 24`) |
| **`ve`** | `ve06` | New Leaf Academy — Dormitory | 8 | 8 | Post-war NPC dialogue |
| **`ve`** | `ve07` | New Leaf Academy — Campus & Cellar | 44 | 44 | Post-war NPC dialogue |
| **`ve`** | `ve10` | Forest Village — Inn & Residences | 14 | 14 | Post-war NPC dialogue |
| **`ve`** | `ve13` | Greenhill Mountain Escape Path | 10 | 10 | Post-war NPC dialogue |
| **`vg`** | `vg03` | Tinto — Riou's Bedroom | 7 | 7 | Post-war NPC dialogue |
| **`vg`** | `vg06` | Tigermouth Village — Inn & Lodges | 13 | 13 | Post-war NPC dialogue |
| **`vg`** | `vg07` | Tinto Mines — Lower Depths | 16 | 16 | Post-war NPC dialogue |
| **`vg`** | `vg08` | Crom Village — Inn & Elder's Lodge | 14 | 14 | Post-war NPC dialogue |
| **`vg`** | `vg09` | Tigermouth Pass | 4 | 4 | Post-war NPC dialogue |
| **`vg`** | `vg13` | Crom Village — Village Center | 17 | 16 | 16 dialogues + 1 `etyp=2` map init |
| **`vg`** | `vg17` | Liberated Tinto City | 12 | 12 | Post-war NPC dialogue |
| **`vh`** | `vh01` | Two River — Human District | 6 | 6 | Post-war NPC dialogue |
| **`vh`** | `vh02` | Lakewest Town | 15 | 15 | Post-war NPC dialogue |
| **`vh`** | `vh05` | Two River — Wingly District | 16 | 16 | Post-war NPC dialogue |
| **`vh`** | `vh06` | Two River — Kobold District | 19 | 19 | Post-war NPC dialogue |
| **`vh`** | `vh11` | Two River — Liberated Tavern | 9 | 9 | Post-war NPC dialogue |
| **`vi`** | `vi01` | Rockaxe Castle Keep | 24 | 24 | Post-war NPC dialogue |
| **`vi`** | `vi02` | Rockaxe Castle Interior | 15 | 15 | Post-war NPC dialogue |
| **`vi`** | `vi11` | Highway Village | 2 | 2 | Post-war NPC dialogue |
| **`vi`** | `vi12` | Highway Village Outskirts | 30 | 30 | Post-war NPC dialogue |
| **`vj`** | `vj02` | L'Renouille — Armory & Guard Hall | 0 | 4 | Disables pre-victory states |
| **`vj`** | `vj05` | L'Renouille — Tactical War Room | 0 | 4 | Disables pre-victory states |
| **`vj`** | `vj17` | Sajah Village | 18 | 16 | 12 dialogues + 3 NPC turn/talk + 3 rare shop events |

---

## 3. Potential `PKCore` Patch Ideas

1. **Sajah Rare Item Shop Early Unlock (`vj17`)**: Bypass `FlgOnAnd(143, 1)` on `vj17` `sub=1` `ev[2, 10, 11]` (detailed in [`sajah_village_rare_shop_vj17.md`](sajah_village_rare_shop_vj17.md)) so players can access Sajah's hidden rare-finds shop before defeating the Beast Rune.
2. **Post-Game Free-Roam / Epilogue Mode**: Allow toggling or persisting `event_flag[143] |= 0x01` while optionally suppressing the Great Hall ending trigger (`vk07`/`vk13`/`vk16` `flag 134 |= 0x01`) so players can freely explore all 30+ towns' epilogue dialogues, use Sajah's rare shop, and play minigames in a true post-war world state.
3. **Final Boss / L'Renouille Replay**: Similar to `S2WarReplayPatch.cs` and `S2CliveQuestReplayPatch.cs`, clearing `event_flag[143] & ~0x01` (along with L'Renouille victory/exit flags) enables re-challenging L'Renouille and the Beast Rune on demand.
