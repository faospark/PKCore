# Suikoden II (GSD2) — Adding New Treasure Chests Technical Reference

> Extensive reverse-engineering and save/script audit for adding new treasure boxes to *Suikoden II* / *Suikoden I & II HD Remaster* (`PKCore`).

---

## 1. Save Flag Capacity Audit

### 1.1 `GAME_WORK.t_box_flag` (`+0x98`, 32 bytes = 256 bits)

An audit of **155 real decrypted `gsd2` saves** (`SuikodenFix/Decrypted/gsd2/Data*.json`) initially showed 12 bytes at `0`, with a bitwise OR union across all 155 saves of:

```text
[255, 227, 255, 1, 255, 11, 121, 255, 0, 0, 255, 0, 255, 0, 0, 0,
 252, 255, 255, 255, 127, 7, 63, 118, 254, 0, 31, 0, 0, 0, 0, 0]
```

However, an exhaustive parse of **all 4,733 `Mobobehaviour/*.json` files** (0 parse errors; 489 `eventForm` op `27`/`28` (`0x1B`/`0x1C`) reads) proved that **Byte `8` (`0xFF`) and Byte `9` (`0x1F`) ARE used in map scripts**, even though they happened to be `0` in those 155 saves.

* **Guaranteed globally free `t_box_flag` capacity: 113 bits (113 chests):**
  * **10 completely unused bytes (`0x00` across all 4,733 Mobos = 80 bits):**
    `[11, 13, 14, 15, 25, 27, 28, 29, 30, 31]`
  * **33 unused bits in partially used bytes:**
    * Byte `1`: bits `[2, 3, 4]`
    * Byte `3`: bits `[1, 2, 3, 4, 5, 6, 7]`
    * Byte `5`: bits `[4, 5, 6, 7]`
    * Byte `6`: bit `[7]`
    * Byte `9`: bits `[5, 6, 7]`
    * Byte `16`: bits `[0, 1]`
    * Byte `20`: bit `[7]`
    * Byte `21`: bits `[3, 4, 5, 6, 7]`
    * Byte `22`: bits `[6, 7]`
    * Byte `23`: bit `[0]`
    * Byte `24`: bit `[0]`
    * Byte `26`: bits `[5, 6, 7]`
* **Exclusive code accessors (`GameAssembly.dll`):** Scanning the entire `il2cpp` section for `OldSrcBase$$get_game_work` (`0x181ac0270`) + offset `0x98` confirmed only four consumers read/write `t_box_flag`:
  1. `EVENTCON$$ECTkFlgSet` (`0x1821473b0`)
  2. `EVENTCON$$ECTkFlgOff` (`0x1821472c0`)
  3. `EVENTCON$$EventFormTbl` (`0x1821532e0`, cases `27` and `28`)
  4. `BootProgram.<gamework_dataset>` (save/load serialization)

### 1.2 Other Save Flag Arrays (Across 155 Real Saves)

If more than 113 chests are ever needed:
* `scpoi_flag` (`+0x90`, 8 bytes = 64 bits): all 8 bytes (`[0..7]`) are `0` across all 155 saves.
* `chara_flag` (`+0x78`, 128 bytes): 13 always-zero bytes (`[0, 49, 74, 80, 81, 82, 83, 84, 123, 124, 125, 126, 127]`).
* `town_flag` (`+0x80`, 71 bytes): 25 always-zero bytes (`[2, 26, 48..70]`).
* `event_flag` (`+0x88`, 256 bytes): 68 always-zero bytes (`[25, 26, 39..44, 56..58, 73..76, 81, 88, 100..109, 134..139, 141, 142, 159, 194, 195, 220..229, 231..233, 235, 240..255]`).

*(Note: Unlike `t_box_flag`, these four arrays were only audited against the 155 save files, not exhaustively scanned across all 4,733 Mobos.)*

### 1.3 Documentation Errata (Verified via `GameAssembly.dll`)

* [`suikoden_2_t_box_flag_architecture.md`](suikoden_2_t_box_flag_architecture.md): Incorrectly claims `ECTkFlgSet` = `96` (`0x60`) and `ECTkFlgOff` = `97` (`0x61`). In `EVENTCON$$AssignCmdFunction` (`0x1821316f0`), **`96` (`0x60`) is `ECShopOverlayGo`**, **`97` (`0x61`) is `ECTkFlgSet`**, and **`98` (`0x62`) is `ECTkFlgOff`**.
* [`treasure_chests_catalog.md`](treasure_chests_catalog.md): Incorrectly calls opcode `97` `ECWkEvFlgSet` (`ECWkEvFlgSet` is opcode `36`/`0x24` at `0x18214c5a0`), and misreads `vg08` Submap 0 Ev 98 as "Byte 28, Bit 23". In `vg08.json`, `eventForm` is `[5, 28, 28, 23, 32, 255, 254]`—player interaction on `ehuman[28]` (`eventobj[20]`) followed by `EventForm` opcode `28` (`0x1C`) testing **Byte `23`, Mask `32` (`1 << 5`)**, matching `ECTkFlgSet(23, 32)`.

---

## 2. Chest Data, Indexing & Bytecode Anatomy

### 2.1 `MAPEVDAT`, `EVENT_OBJ`, and the `+8` `ehuman` Rule

Per submap in `MAPEVENTDAT.mapeventdat[]` (`MAPEVDAT`):
* `okaz` = `eventobj.Length`
* `evkaz` = `eventdat.Length`
* `MACHICON$$EventInit` (`0x1818bb190`) allocates `ehuman` with length **`8 + okaz`**:
  * `ehuman[0..7]` are reserved for party/companion slots.
  * **`eventobj[i]` maps to `ehuman[8 + i]`**.
  * All `eventForm` op `5` and `eventCom` op `0`/`1` object indices reference **`8 + i`**.
  * **Important:** `MapEventObjectHD.objID` uses **raw `i`** (`EVENTCON$$EventPlayerDisp` passes `i - 8` to `MapBGManagerHD$$RefleshObject`).

### 2.2 Standard Two-Object Chest Pattern (`EVENT_OBJ`)

Standard chests (`vf06`, `vb21`, `vb07`, `vd06`) create **two `EVENT_OBJ` entries at identical `(x, y)`** coordinates:

| Field | Closed Chest `eventobj[i]` (`ehuman[8+i]`) | Open Chest `eventobj[i+1]` (`ehuman[9+i]`) | Notes |
|---|---|---|---|
| `otyp` | `3` | `3` | Object/prop type |
| `disp` | `0` | `0` | Hidden at spawn; enabled on init via `etyp = 2` |
| `spd` | `4` | `4` | Standard speed |
| `wt` | `255` | `255` | Sentinel |
| `ano` | Map closed anim ID (e.g., `vf06`: `1`, `vb21`: `11`, `vb07`: `19`, `vd06`: `8`) | Map open anim ID (e.g., `vf06`: `0`, `vb21`: `12`, `vb07`: `20`, `vd06`: `7`) | Matches `OPD_DATA` & `MapObjAnimHD` `animID` |
| `ityp` | `0` | `0` | — |
| `fpno` | `0` | `0` | Ignored when `otyp == 3` |
| `ozok` | `2` | `2` | Bit `1` (`0x02`) enables collision |
| `pri` | `0` | `0` | Render priority |
| `x`, `y` | Map coordinates `(X, Y)` | Identical `(X, Y)` | Shared position |
| `w`, `h` | `0`, `0` | `0`, `0` | Unused by `otyp == 3` collision |

### 2.3 Three `EVENT_DAT` (`eventdat[]`) Entries Per Chest

Let:
* `B` = `t_box_flag` byte index (`0..31`)
* `M` = bitmask (`1 << bit`, e.g., `1, 2, 4, 8, 16, 32, 64, 128`)
* `C = 8 + i` (closed `ehuman` index), `O = 8 + i + 1` (open `ehuman` index)
* `slot` = index into `mdat.overlay_func[]` pointing to `"OverlayAddItem2Init"`

1. **Unopened state init (`etyp = 2`):**
   * `eventForm`: `[28, B, M, 255, 254]` (`t_box_flag[B] & M == 0`)
   * `eventCom`: `[0, C, 255, 254]` (`ECODispOn(C)`)
2. **Opened state init (`etyp = 2`):**
   * `eventForm`: `[27, B, M, 255, 254]` (`t_box_flag[B] & M != 0`)
   * `eventCom`: `[0, O, 255, 254]` (`ECODispOn(O)`)
3. **Player interact & grant (`etyp = 1`):**
   * `eventForm`: `[28, B, M, 5, C, 255, 254]` (`t_box_flag[B] & M == 0` AND player talks/interacts with `C`)
   * `eventCom`:

     ```text
     46                        ; 0x2E ECRenzokOn
     1, C, 0, O                ; 0x01 ECODispOff(C), 0x00 ECODispOn(O)
     47                        ; 0x2F ECRenzokOff
     101, 4, 7                 ; 0x65 ECSoundCall(bank=4, se=7) - chest SFX
     30, slot, 4,              ; 0x1E ECOverlayGo(slot, len=4, ...)
       0, itemId, catMask, 0   ; mode=0, add_item_no, add_use_cnt/category, identification=0
     41, 2, 0, 1               ; 0x29 ECSentakuJump(count=2, lbl_ok=0, lbl_full=1)
     255, 0                    ; FF 00: acquired
       97, B, M                ; 0x61 ECTkFlgSet(B, M)
       255, 254                ; FF FE: return
     255, 1                    ; FF 01: bag full / cancelled
       46, 1, O, 0, C, 47      ; atomic revert open -> closed
       255, 254                ; FF FE: return
     255, 254                  ; FF FE: end
     ```

### 2.4 `EventFormTbl` Lengths Reference (`0x1821532e0`)

Disassembled byte lengths (opcode + args) from `0x182156b74` (cases `0..41` + `254`/`255`):
```text
0:1, 1:3, 2:3, 3:3, 4:3, 5:2, 6:2, 7:2, 8:2, 9:2, 10:2, 11:2, 12:2, 13:2,
14:4, 15:4, 16:3, 17:1, 18:3, 19:2, 20:2, 21:2, 22:2, 23:3, 24:3, 25:2, 26:6,
27:3, 28:3, 29:3, 30:3, 31:5, 32:5, 33:3, 34:3, 35:3, 36:4, 37:6, 38:3, 39:4,
40:3, 41:7, 254(FE):1, 255(FF):1
```

### 2.5 Granting Any Item via `OverlayAddItem2Init`

Disassembly of `EVENTCON$$ECOverlayGo` (`0x18213f7e0`), `area_func$$GetEventOverlayFunction` (`0x181ac9eb0`), `area_func$$.cctor` (`0x181aa3b80`), and `EventOverlayClass.Overlay_AddItem2` (`OverlayAddItem2Init` `0x181f88d20`, `AddItemWinInit` `0x181f87bd0`, `AI2EV_SetItem` `0x181f85ad0`, `OverlayAddItem2Main` `0x181f88e40`):

* `area_func.g_area_func_name` holds 1,584 entries preserving historical PS1 overlay IDs. Multiple indices resolve directly to `"OverlayAddItem2Init"` (verified: **`61`**, **`144`**, **`145`**, **`299`**, **`610`**).
* On any map whose `mdat.overlay_func` lacks an item overlay, simply append `610` (or check if an existing `"OverlayAddItem2Init"` ID is already present) to `mdat.overlay_func` and reference its array index as `slot` in `1E <slot> 04 ...`.
* `OverlayAddItem2Init` `para[0..3]` layout in `ADD_ITEM_WIN`:
  * `para[0]` (`mode`): `0` = normal chest acquire; `3` = unidentified appraisal item (`cursor_pos_default = 1`).
  * `para[1]` (`add_item_no`): item ID (`byte`).
  * `para[2]` (`add_use_cnt`): item category/use byte—observed in real chests as `0` (`0x00`, consumables/`dogu_data`), `16` (`0x10`, equipment/`bogu_data`), `32` (`0x20`, runes/`embl_data`), `80` (`0x50`, extra/key items/`ex_it_data`, e.g. `vg08`).
  * `para[3]` (`identification`): `0`.
* `OverlayAddItem2Main` sets `SENTAKU_RET` (`wret` at `+0x50`) to `0` if acquired, or `1` if declined / inventory full (consumed by `41, 2, 0, 1`).

---

## 3. Collision & Interaction Mechanics

Even though `otyp == 3` chest `EVENT_OBJ`s have `w = 0, h = 0`:
1. **`EVENTCON$$EventObjAtariCheck` (`0x18215bd00`):**
   * Checks `(ozok & 2) != 0` (`0x18215c12a`) and `disp == 1`.
   * Passes both `player.anime.pattern_header` (`[+0x80] -> [+0x60]`) and **`obj.anime.pattern_header`** (`0x18215c517`) into collision helper `0x18215b970`.
2. **`EventFormTbl` Case `5` (`0x182153e50` / `0x182153ef0`):**
   * Calls `<EventFormTbl>g__CanCall_OSTOME|218_3` (`0x182171b50`) and `<EventFormTbl>g__CanCall_OSTATE_OSTOKU|218_2` (`0x1821718e0`), reading `obj.anime.pattern_header` sprite dimensions (`word [rcx+0x1c]`, `word [rcx+0x1e]`).
3. **`opd` & `anime` Requirement on Maps Without Chests:**
   * In `MACHICON$$EventInit` (`0x1818bc756..0x1818bc8fa`), `otyp == 3` objects ignore `fpno` and receive `eman.opd` from `ETC_DATA.GetData<object>(loadETCMap)` (if `loadETCMap >= 1`) or `MACHIDAT.map[mapMno(mno)].machi_opd`.
   * Dungeon maps (`vf06`, `vb21`, `vb07`, `vd06`, `vi01`) already carry chest patterns inside `machi_opd`. Town/interior maps (e.g., `va14`) can have empty `machi_opd` or omit chest patterns. On such maps, **you must populate `eman.opd` and `eman.anime` (with valid `PatternTable` bounds for `ano`) after `EventInit`** so collision and Case `5` interaction work.

---

## 4. HD Visual Rendering Pipeline (`GameAssembly.dll`)

Disassembly of `EVENTCON$$EventPlayerDisp` (`0x18215fa3f..0x1821605ab`), `MapBGManagerHD$$RefleshObject` (`0x18148f5a0`), `MapBGManagerHD$$FindEventObject` (`0x18148dd40`), `MapBGManagerHD$$Init` (`0x18148ec00`), and `ANIME$$AnimeDispFast` (`0x1818b1f90`) shows three visual paths when `GAME_WORK.<g_hd_mode>` (`+0xBA`) is enabled:

### 4.1 Native HD Path (`eman.forceHDDraw == false`)
For `otyp == 3 || otyp == 4`:
1. Calls `ANIME$$AnimeChange(eman.anime, eman.ano)` if `anime.ano != eman.ano`.
2. Computes HD world coordinates (`0x18215fb60..0x18215fc52`) using `MAP.maxw` (`+0x84`), `MAP.maxh` (`+0x88`), and frame offset `(offX, offY)`:
   $$\text{hdX} = (\text{anime.x} - \lfloor\text{maxw} / 2\rfloor) \times 4 + 2 \cdot \text{offX}$$
   $$\text{hdY} = (\lfloor\text{maxh} / 2\rfloor - \text{anime.y}) \times 4 + 2 \cdot \text{offY}$$
3. Calls `MapBGManagerHD.RefleshObject(i - 8, pos, disp == 1, eman.ano, globalMapID, eman.initilizeVisible)` and `ANIME.AnimUpdate(0)`—and **does NOT draw PS1 `ANIME` sprites**.
4. `FindEventObject(id, mno)` matches `!doorObject && objID == id && (eventMapNo == -1 || eventMapNo == mno)`. **Without a matching `MapEventObjectHD` in `MapBGManagerHD`, the chest is invisible in HD mode.**

### 4.2 Native HD Object Setup (Recommended Visual Approach)
Spawn or clone a Unity `GameObject` per chest object (or single object with 2 `AnimationPack`s) containing:
* `SpriteRenderer`
* `MapObjAnimHD` with `AnimationPack` entries matching `animID` (closed vs. open) and HD `Sprite`s (cloned from an existing HD chest or created from PNG via `Sprite.Create`).
* `MapEventObjectHD` configured with:
  * `objID = i` (`ehumanIndex - 8`)
  * `positionSync = true`, `visibleSync = true`, `animationSync = true`, `doorObject = false`, `eventMapNo = -1` (or target `globalMapID`)
* Register it into `MapBGManagerHD`'s `eventObjs` list (or parent it under `MapBGManagerHD` before `MapBGManagerHD.Init` runs `GetComponentsInChildren<MapEventObjectHD>`).

### 4.3 PS1 `OPDSprite` Fallback (`eman.forceHDDraw == true`)
At `0x18215faed`, setting `eman.forceHDDraw = true` (`+0xA0`) bypasses `RefleshObject` and routes `otyp == 3` to `0x18215fe30` -> `ANIME$$AnimeDispFast` (`OPDSprite`). Useful for quick coordinate/script verification on maps that already have chest `OPD_DATA` in `machi_opd` before wiring crisp HD `MapEventObjectHD` sprites.

---

## 5. Concrete `PKCore` Runtime Injection Blueprint

`Patches/MapTrackingPatch.cs` already hooks `MACHICON.OnMapInit` and `MACHICON.EventInit` and tracks `CurrentMapId`, `CurrentSubmapIndex`, and `CurrentMachicon`.

1. **Prefix on `MACHICON.EventInit` (Data Injection):**
   * Filter by target `(CurrentMapId, CurrentSubmapIndex)`.
   * Ensure `mdat.overlay_func` contains an `"OverlayAddItem2Init"` ID (e.g., `610`); append if missing and capture its `slot` index.
   * Append 2 `EVENT_OBJ` entries (`closedIdx = oldOkaz`, `openIdx = oldOkaz + 1`) with `otyp = 3, disp = 0, spd = 4, wt = 255, ozok = 2, x = X, y = Y, w = 0, h = 0, fpno = 0`, `ano` matching closed/open IDs, and increment `mapevdat.okaz += 2`.
   * Pick an unused `(B, M)` from the 113 free `t_box_flag` bits (e.g. Byte `11`, Mask `1`, `2`, `4`, ...).
   * Append the 3 `EVENT_DAT` entries (`etyp = 2` unopened, `etyp = 2` opened, `etyp = 1` interact with `ECOverlayGo` + `ECTkFlgSet`) and increment `mapevdat.evkaz += 3`.
2. **Postfix on `MACHICON.EventInit` (`OPD_DATA` / `ANIME` Guard):**
   * Verify `ehuman[8 + closedIdx]` and `ehuman[8 + openIdx]` have non-null `.opd` and `.anime` with valid `pattern_header` entries (supplying a cached/donor chest `OPD_DATA` on maps whose `machi_opd` lacks chest animations so collision and `FormCase 5` bounds work).
3. **HD Visual Spawn (when `GAME_WORK.HDMode` is active):**
   * Attach/register `MapEventObjectHD` + `MapObjAnimHD` + `SpriteRenderer` objects for `objID = closedIdx` and `objID = openIdx` on the active `MapBGManagerHD` (or toggle `forceHDDraw = true` for initial PS1-sprite testing).

> **Why runtime `PKCore` injection over static `Mobobehaviour` edits?** Even if you patch `Mobobehaviour` asset JSONs offline, HD Remaster scenes still require matching `MapEventObjectHD` + `MapObjAnimHD` Unity components inside the scene to render chests. Handling both the `MAPEVDAT` injection and `MapEventObjectHD` spawning inside `PKCore` keeps everything self-contained, toggleable, and resilient to game updates.
