# Suikoden II — Epilogue Leona Party Change Restoration (`s2EpilogueLeona`)

## 1. Overview

In vanilla **Suikoden II HD Remaster**, entering the epilogue/post-game free roam locks the player out of the Castle Tavern Party Change menu. When visiting Dunan Castle Tavern (`vk08_00`), **Leona** is missing from behind the counter and is replaced by a substitute maid NPC who says:

> *"Leona went to one of the towns nearby to restock on spirits."*

The **`s2EpilogueLeona`** patch ([`S2EpilogueLeonaPatch.cs`](file:///d:/Appz/SuikodenModding/PKCore/Patches/S2EpilogueLeonaPatch.cs)) restores Leona (`fpno = 91`) to her rightful place behind the bar counter and completely restores the Castle Party Change menu in post-game free roam.

---

## 2. Forensic Bytecode Breakdown (`vk08`)

### 2.1 The Two-Pronged Vanilla Lockout Trap

Inspection of `vk08.json` in `Mobobehaviour` reveals why simply clearing flags via memory is insufficient:

1. **The Flag 144 Bit 4 Condition**:
   - The epilogue sets **`event_flag[144] |= 0x04`**.
   - In `vk08_00`, `ev[33]` (`etyp = 2`, map init) requires `form [3, 144, 4]`. If true, it moves `obj[20]` (`fpno = 65085`, substitute maid) from its holding spot `(37, 51)` to `(58, 84)` behind the bar counter.
   - `ev[34]` (`etyp = 1`, talk trigger) checks `form [3, 144, 4, 1, 49, 67, 2, 81, 82]` (standing at the counter). It executes opcode `[24, 20, 15, 4]` (Bank 15, Message 4: *"Leona went to one of the towns nearby to restock on spirits."*).

2. **The Out-of-Bounds Retail Object Bug**:
   - In retail Suikoden II, the `eventobj` table for `vk08_00` contains **only 25 objects** (`obj[00..24]`).
   - Normal Leona spawn scripts `ev[38..42]` require `event_flag[144] & 0x04 == 0` and attempt to spawn **`obj[28..32]`**!
   - Because `obj[28..32]` do not exist in the map data, clearing flag 144 alone leaves the bar counter vacant, and talk scripts `ev[43..47]` (which look for `obj[28..32]`) fail to match.

---

## 3. The `s2EpilogueLeona` Solution

The patch uses in-memory bytecode interception when `vk08` loads:

```
[MachiLoader / EventInit]
         │
         ├──> Patch obj[20].fpno: 65085 (Maid) ──> 91 (Leona)
         ├──> Position obj[20]: (58, 84) facing South (ano: 0), disp: 1
         ├──> Patch ev[33] MapInit: unconditional [255, 254]
         ├──> Patch ev[34] Talk: replace dialogue with [30, 4, 1, 0, 23, 6, 4, 255, 254]
         └──> Clear event_flag[144] bit 0x04 across game_work & eventFlgCHK hooks
```

### Key Values:
- **Leona Sprite ID**: `fpno = 91`
- **Substitute Maid Sprite ID**: `fpno = 65085`
- **Bar Counter Coordinates**: `(58, 84)`
- **Party Change Menu Bytecode**: `[30, 4, 1, 0, 23, 6, 4, 255, 254]` (Opcode 23 = Castle Facility Menu, Subcommand 6 = Party Change, Tier 4).

### Submap Coverage:
- **`vk08_00` (Entrance & Tavern 1F)**: Patches `obj[20]` and `ev[33..34]`.
- **`vk08_01` (Expanded Tavern)**: Patches `obj[43]` and `ev[77]`.
- **`vk08_02` (Inn & Item Shop)**: Patches `obj[17]`.

---

## 4. Configuration

Controlled in `BepInEx/config/faospark.pkcore.cfg` under `[05 Game : Suikoden 2]`:

| Key | Type | Default | Description |
|---|:---:|:---:|---|
| `EnableLeonaPostFinalBoss` | `bool` | `true` | Restores Leona (`fpno = 91`) at Dunan Castle Tavern (`vk08`) after the final boss battle / in the epilogue, re-enabling the party change menu. |
