# Suikoden II HD Remaster: Live Event Flags & Progression Telemetry Log

This document serves as the live repository of reverse-engineered event flags, quest milestones, recruitment conditions, and minigame states captured directly during gameplay using **PKCore's Real-Time Event Flag Logger** (`EventFlagLoggerPatch.cs`).

Findings documented here are directly applied to:
- **PKCore** (`d:\Appz\SuikodenModding\PKCore`) for runtime event hooks and QoL fixes.
- **SuiSaveEditor** (`e:\xampp\htdocs\suisaveeditor`) for accurate flag definitions, recruitment status resets, and quest editors.

---

## 1. Grounded Recruitment & Quest Log

### 1.0 Prologue & Highland Youth Brigade Camp (`va01`)

- **Locations**: Highland Unicorn Brigade Camp Exterior (`va01_00`), Camp Tent Interior (`va01_01`).
- **Initial Setup Telemetry (New Game Commit)**:
  ```text
  [S2 FLAG ON ] Byte 0x96 (150) |= Mask 0x01 (Bits: 00000001)  <-- Prologue World State Initialized
  [S2 FLAG ON ] Byte 0x96 (150) |= Mask 0x02 (Bits: 00000010)  <-- Unicorn Brigade State Active
  [S2 FLAG ON ] Byte 0x96 (150) |= Mask 0x20 (Bits: 00100000)  <-- Night Scene / Tent Lighting Configured
  ```
- **"Let's Go Outside" Choice with Jowy**:
  - Talking to Jowy inside the tent (`va01_01`) presents the dialogue choice to leave the tent.
  - Selecting *"Let's go outside"* triggers:
    ```text
    [Map Tracking] MACHICON MapID resolved to: va01_01 (Tent Interior)
    [S2 FLAG ON ] Byte 0x00 (000) |= Mask 0x01 (Bits: 00000001)  <-- Master Prologue Flag #1
    ```
- **Youth Brigade Sparring Scene (Outside Encampment)**:
  - Approaching the three young soldiers sparring near the fire pit in `va01_00` triggers dialogue and practice combat.
  - Progressing the scene triggers:
    ```text
    [Map Tracking] MACHICON MapID resolved to: va01_00 (Camp Exterior)
    [Map Tracking] MACHICON MapID resolved to: va01_01 (Tent Return)
    [S2 FLAG ON ] Byte 0x00 (000) |= Mask 0x10 (Bits: 00010000)  <-- Viewed Sparring Scene
    ```
- **Spoke to Captain Rowd in Tent & Night Ambush Commences**:
  - Speaking to Captain Rowd in the tent (`va01_01`) and returning to sleep triggers the night ambush sequence:
    ```text
    [Map Tracking] MACHICON MapID resolved to: va01_01 (Tent Interior)
    [S2 FLAG ON ] Byte 0x00 (000) |= Mask 0x08 (Bits: 00001000)  <-- Spoke to Captain Rowd / Night Ambush Begins
    ```
- **East Clearing Encounter with Shadowy Figure (Luca Blight & Rowd)**:
  - Moving east through the burning camp corridors (`va01_00` -> `va01_02` -> `va01_03`) into the clearing triggers the cutscene where Captain Rowd meets the shadowy figure ("????", Prince Luca Blight), exposing Rowd's treason:
    ```text
    [Map Tracking] MACHICON MapID resolved to: va01_02 (Burning Corridor)
    [Map Tracking] MACHICON MapID resolved to: va01_03 (East Clearing)
    [PotraitSystem] Attempting to inject portrait for '????' directly into Img_Face
    [S2 FLAG ON ] Byte 0x00 (000) |= Mask 0x40 (Bits: 01000000)  <-- Witnessed Shadowy Figure & Rowd Betrayal
    ```
- **Return to Tent, Fleeing Camp & Responding to Jowy**:
  - Running back west to the tent after discovering the betrayal:
    ```text
    [Map Tracking] MACHICON MapID resolved to: va01_01 (Tent Return)
    [S2 FLAG ON ] Byte 0x00 (000) |= Mask 0x20 (Bits: 00100000)  <-- Returned to tent after warning
    [S2 FLAG ON ] Byte 0x00 (000) |= Mask 0x80 (Bits: 10000000)  <-- Riou & Jowy agree to flee / pack up
    ```
  - Breaking out of the burning tent and fleeing along the east corridor:
    ```text
    [Map Tracking] MACHICON MapID resolved to: va01_00 (Burning Camp Grounds)
    [S2 FLAG ON ] Byte 0x01 (001) |= Mask 0x01 (Bits: 00000001)  <-- Escaped tent into burning camp
    [Map Tracking] MACHICON MapID resolved to: va01_02 (Corridor)
    [S2 FLAG ON ] Byte 0x01 (001) |= Mask 0x08 (Bits: 00001000)  <-- Confronted by Highland soldiers
    [Map Tracking] MACHICON MapID resolved to: va01_03 (Clearing Approach)
    [S2 FLAG ON ] Byte 0x01 (001) |= Mask 0x20 (Bits: 00100000)  <-- Reached east forest clearing
    [S2 FLAG ON ] Byte 0x01 (001) |= Mask 0x10 (Bits: 00010000)  <-- Responded to Jowy dialogue choice
    [S2 FLAG ON ] Byte 0x01 (001) |= Mask 0x80 (Bits: 10000000)  <-- Fleeing north towards waterfall cliff
    ```
  - Turning back west into the burning camp to confront Captain Rowd:
    ```text
    [Map Tracking] MACHICON MapID resolved to: va01_02 (Corridor Return)
    [Map Tracking] MACHICON MapID resolved to: va01_00 (Camp Center)
    [S2 FLAG ON ] Byte 0x01 (001) |= Mask 0x40 (Bits: 01000000)  <-- Confronted Captain Rowd; Cutscene & Ambush Battle
    ```
- **Bytecode Grounding (`Mobobehaviour/va01.json`)**:
  - `va01` Submap 1 Event 10 Com (offset 275): Executes opcode `ECEvFlgSet(flag=0, bit=0x01)`.
  - `va01` Submap 0 Event 37 Com (offset 119): Executes opcode `ECEvFlgSet(flag=0, bit=0x10)` upon completing sparring interaction.
  - `va01` Submap 1 Event 26 / 27: Sets `event_flag[0] |= 0x08` to initiate burning camp upon sleeping.
  - `va01` Submap 3 Event 8: Trigger boundary `[1, 55, 56, 2, 27, 53]` executes `ECEvFlgSet(flag=0, bit=0x40)` when entering clearing cutscene with Luca Blight.
  - `va01` Submap 1 Event 15 & 37: Sets `event_flag[0] |= 0x20` and `|= 0x80` upon returning to tent and packing up to flee.
  - `va01` Submap 0 Event 29: Sets `event_flag[1] |= 0x01` when escaping tent into camp grounds.
  - `va01` Submap 2 Event 10: Sets `event_flag[1] |= 0x08` upon encountering Highland ambush on path.
  - `va01` Submap 3 Event 3 & 11: Sets `event_flag[1] |= 0x20`, `|= 0x10`, and `|= 0x80` during Jowy's clearing dialogue and sprint to cliff.
  - `va01` Submap 0 Event 10: Triggered when `event_flag[1] & 0x80` is set; executes `ECEvFlgSet(flag=1, bit=0x40)` when Riou re-enters camp grounds to confront Captain Rowd directly.
- **Save Editor Mapping**:
  - **`event_flag[0]`**:
    - `Bit 0` (`0x01`): Prologue Phase 1 — Jowy & Riou exited tent ("Let's go outside").
    - `Bit 3` (`0x08`): Prologue Phase 3 — Spoke to Captain Rowd; night ambush commenced.
    - `Bit 4` (`0x10`): Prologue Phase 2 — Viewed Youth Brigade sparring scene outside.
    - `Bit 5` (`0x20`): Prologue Phase 5 — Returned to tent after warning / suspecting ambush.
    - `Bit 6` (`0x40`): Prologue Phase 4 — Moved east; witnessed Shadowy Figure (Luca Blight) & Rowd cutscene.
    - `Bit 7` (`0x80`): Prologue Phase 6 — Riou & Jowy pack up / agree to flee burning camp.
  - **`event_flag[1]`**:
    - `Bit 0` (`0x01`): Prologue Phase 7 — Escaped tent into burning camp exterior.
    - `Bit 3` (`0x08`): Prologue Phase 8 — Confronted by Highland soldiers on camp path.
    - `Bit 4` (`0x10`): Prologue Phase 9 — Responded to Jowy's warning ("Okay, I'll go with you").
    - `Bit 5` (`0x20`): Prologue Phase 10 — Reached east forest clearing.
    - `Bit 6` (`0x40`): Prologue Phase 12 — Returned west to camp to confront Captain Rowd; cutscene & ambush battle.
    - `Bit 7` (`0x80`): Prologue Phase 11 — Fleeing north towards waterfall cliff.
- **Tenzan Pass Waterfall Cliff Escape & Jump Decision (`va09`)**:
  - Reaching the waterfall cliff edge triggers the first forced battle against Highland Soldiers:
    ```text
    [Map Tracking] MACHICON MapID resolved to: va09_00 (Waterfall Cliff)
    [S2 FLAG ON ] Byte 0x02 (002) |= Mask 0x01 (Bits: 00000001)  <-- Reached Tenzan Pass cliff approach
    [S2 FLAG ON ] Byte 0x02 (002) |= Mask 0x02 (Bits: 00000010)  <-- First cliff battle initiated
    [S2 FLAG ON ] Byte 0x02 (002) |= Mask 0x04 (Bits: 00000100)  <-- First cliff battle won
    [S2 FLAG ON ] Byte 0x02 (002) |= Mask 0x08 (Bits: 00001000)  <-- Cliff edge decision dialogue initiated
    ```
  - **Refusing to Jump ("Look at the current...")**:
    - Choosing *"Look at the current..."* sets a refusal bit and triggers another soldier wave:
      ```text
      [S2 FLAG ON ] Byte 0x02 (002) |= Mask 0x40 (Bits: 01000000)  <-- Refused jump / wave trigger
      [S2 FLAG OFF] Byte 0x02 (002) &= ~Mask 0x40                 <-- Debounced for next round
      ```
  - **Agreeing to Jump into the River**:
    - When selecting the jump choice with Jowy:
      ```text
      [S2 FLAG ON ] Byte 0x02 (002) |= Mask 0x10 (Bits: 00010000)  <-- Riou & Jowy agree to jump ("Promise" mark on rock)
      [S2 FLAG ON ] Byte 0x05 (005) |= Mask 0x80 (Bits: 10000000)  <-- Master Prologue Milestone Completed
      [S2 FLAG ON ] Byte 0x02 (002) |= Mask 0x20 (Bits: 00100000)  <-- Jumped into waterfall plunge
      ```

- **Foggy River Rescue & Mercenary Fortress Arrival (`va04`, `va13`, `vb01`)**:
  - Riou is washed ashore and discovered by Viktor and Flik in the fog:
    ```text
    [Map Tracking] MACHICON MapID resolved to: va04_00 (Foggy Riverbank)
    [S2 FLAG ON ] Byte 0x03 (003) |= Mask 0x01 (Bits: 00000001)  <-- Rescued from river by Viktor & Flik
    [Map Tracking] MACHICON MapID resolved to: va13_00 (Foggy Dream / Flashback)
    [S2 FLAG ON ] Byte 0x03 (003) |= Mask 0x02 (Bits: 00000010)  <-- Viewed river dream / flashback cutscene
    [Map Tracking] MACHICON MapID resolved to: va04_00 (Riverbank Waking)
    [Map Tracking] MACHICON MapID resolved to: vb01_00 (Mercenary Fortress 1F)
    ```

### 1.1 Mercenary Fortress: Pohl's Chores & Escape Preparation (`vb01`, `vb02`, `vb11`)

- **Locations**: Fortress 1F Hall (`vb01`), Corridor/Stairs (`vb02`), Cellar Storeroom & Cell (`vb11_02`).
- **Sentencing & Meeting Pohl**:
  - Interrogated in hall by Viktor & Flik; assigned to cell under Pohl's custody:
    ```text
    [Map Tracking] MACHICON MapID resolved to: vb01_00 (Fortress 1F)
    [S2 FLAG ON ] Byte 0xA0 (160) |= Mask 0x01 (Bits: 00000001)  <-- Brought to Mercenary Fortress
    [S2 FLAG ON ] Byte 0xA0 (160) |= Mask 0x40 (Bits: 01000000)  <-- Interrogated by Viktor & Flik; sentenced to cell
    [Map Tracking] MACHICON MapID resolved to: vb11_02 (Cellar & Storeroom)
    [S2 FLAG ON ] Byte 0xEC (236) |= Mask 0x01 (Bits: 00000001)  <-- Met Pohl in cellar; chore sequence begins
    [S2 FLAG ON ] Byte 0xA0 (160) |= Mask 0x80 (Bits: 10000000)  <-- Pohl custody active
    [S2 FLAG ON ] Byte 0xA1 (161) |= Mask 0x01 (Bits: 00000001)  <-- Chore #1 Assigned: Move Storeroom Cargo Boxes
    ```
- **Pushing Storeroom Cargo Boxes & Taking Rope**:
  - Pushing each of the 5 movable cargo boxes into proper position in `vb11_02`:
    ```text
    [S2 FLAG ON ] Byte 0xEC (236) |= Mask 0x02 (Bits: 00000010)  <-- Storeroom Box #1 pushed into position
    [S2 FLAG ON ] Byte 0xEC (236) |= Mask 0x04 (Bits: 00000100)  <-- Storeroom Box #2 pushed into position
    [S2 FLAG ON ] Byte 0xEC (236) |= Mask 0x08 (Bits: 00001000)  <-- Storeroom Box #3 pushed into position
    [S2 FLAG ON ] Byte 0xEC (236) |= Mask 0x10 (Bits: 00010000)  <-- Storeroom Box #4 pushed into position
    [S2 FLAG ON ] Byte 0xEC (236) |= Mask 0x20 (Bits: 00100000)  <-- Storeroom Box #5 pushed into position (All 5 done)
    ```
  - Interacting with storeroom shelf to take the **Rope** and reporting to Pohl:
    ```text
    [S2 FLAG ON ] Byte 0xCD (205) |= Mask 0x08 (Bits: 00001000)  <-- Storeroom shelf inspected
    [S2 FLAG ON ] Byte 0xCD (205) |= Mask 0x20 (Bits: 00100000)  <-- Acquired Rope from storeroom
    [S2 FLAG ON ] Byte 0xA1 (161) |= Mask 0x02 (Bits: 00000010)  <-- Chore #1 Completed: Boxes organized
    [S2 FLAG ON ] Byte 0xA1 (161) |= Mask 0x04 (Bits: 00000100)  <-- Escape Tool #1 Secured: Rope in possession
    [S2 FLAG ON ] Byte 0xA1 (161) |= Mask 0x08 (Bits: 00001000)  <-- Day 1 Chore Finished / Pohl feeds Riou & locks cell
    ```

- **Day 2 Chores: Flint Stones, Out of Flour & Ryube Errand (`vb11`)**:
  - Pohl tasks Riou with gathering supplies (two pairs of boots, flint stones, and flour):
    ```text
    [S2 FLAG ON ] Byte 0xA1 (161) |= Mask 0x40 (Bits: 01000000)  <-- Day 2 Assigned: Fetch Boots, Flint Stones & Flour
    [Map Tracking] MACHICON MapID resolved to: vb11_02 (Cellar Blacksmith)
    [S2 FLAG ON ] Byte 0xA1 (161) |= Mask 0x10 (Bits: 00010000)  <-- Acquired Flint Stones from Blacksmith
    [Map Tracking] MACHICON MapID resolved to: vb11_00 (Fortress Store)
    [S2 FLAG ON ] Byte 0xA1 (161) |= Mask 0x20 (Bits: 00100000)  <-- Item Store is out of flour; directed to Ryube Village
    [Map Tracking] MACHICON MapID resolved to: vb11_02 (Cellar Return)
    [S2 FLAG ON ] Byte 0xA1 (161) |= Mask 0x80 (Bits: 10000000)  <-- Reported to Pohl; instructed to see Leona for escort
    [Map Tracking] MACHICON MapID resolved to: vb11_00 (Fortress Tavern)
    [S2 FLAG ON ] Byte 0xA2 (162) |= Mask 0x01 (Bits: 00000001)  <-- Spoke to Leona; Gengen & Tuta join party for Ryube Flour trip!
    ```
- **Bytecode Grounding (`Mobobehaviour/vb11.json`)**:
  - `vb11` Submap 2 Event 18: Form checks `FlgOnAnd(flag=236, bit=0x01)`.
  - `vb11` Submap 2 Events 19–33: Track the 5 pushable boxes via `event_flag[236]` bits `0x02`, `0x04`, `0x08`, `0x10`, `0x20`.
  - `vb11` Submap 2 Event 36: Validates all 5 box bits are ON to conclude chore.
  - `vb11` Submap 2 Events 44–47: Evaluates combinatorial progress:
    - Ev 44: `event_flag[161]` bits: `1` ON, `2` OFF, `4` OFF (Chore active, boxes pending, rope pending).
    - Ev 45: `event_flag[161]` bits: `1` ON, `2` OFF, `4` ON (Rope secured, boxes pending).
    - Ev 46: `event_flag[161]` bits: `1` ON, `2` ON, `4` OFF (Boxes done, rope pending).
    - Ev 47: `event_flag[161]` bits: `1` ON, `2` ON, `4` ON (Boxes done AND Rope secured).
- **Save Editor Mapping**:
  - **`event_flag[2]`**:
    - `Bit 0` (`0x01`): Prologue Phase 13 — Reached Tenzan Pass cliff approach.
    - `Bit 1` (`0x02`): Prologue Phase 14 — First cliff edge battle initiated.
    - `Bit 2` (`0x04`): Prologue Phase 15 — First cliff edge battle won.
    - `Bit 3` (`0x08`): Prologue Phase 16 — Cliff edge jump decision dialogue.
    - `Bit 4` (`0x10`): Prologue Phase 17 — Agreed to jump; carved 'X' promise mark on rock.
    - `Bit 5` (`0x20`): Prologue Phase 18 — Plunged off waterfall cliff into river.
    - `Bit 6` (`0x40`): Refused jump ("Look at the current..."); spawns next Highland squad wave.
  - **`event_flag[3]`**:
    - `Bit 0` (`0x01`): Prologue Phase 19 — Discovered / fished out of foggy river by Viktor and Flik (`va04`).
    - `Bit 1` (`0x02`): Prologue Phase 20 — Foggy river dream sequence completed (`va13`).
  - **`event_flag[5]`**:
    - `Bit 7` (`0x80`): Prologue Master Completion Milestone (Unlocks Chapter 1 / Mercenary Fortress).

---

### 1.1 Yuzu (Star #102) & Kobold Village Sheep Minigame

- **Locations**: Kobold Village (`vh03`), Unicorn Woods / Enclosure (`vh10`).
- **Recruitment Requirement**: Dunan Castle HQ Level 2+. Talk to Yuzu in Kobold Village to initiate the sheep chase minigame, catch all 3 runaway sheep in the pasture, and return to Yuzu.

#### Live Telemetry Capture:
```text
[Map Tracking] MACHICON MapID resolved to: vh03_00 (Kobold Village)
[S2 FLAG ON ] Byte 0x44 (068) |= Mask 0x10 (Bits: 00010000)  <-- Accepted sheep quest

[Map Tracking] MACHICON MapID resolved to: vh10_05 (Pasture Enclosure)
[S2 FLAG ON ] Byte 0x44 (068) |= Mask 0x20 (Bits: 00100000)  <-- Sheep #1 caught
[S2 FLAG ON ] Byte 0x44 (068) |= Mask 0x40 (Bits: 01000000)  <-- Sheep #2 caught
[S2 FLAG ON ] Byte 0x44 (068) |= Mask 0x80 (Bits: 10000000)  <-- Sheep #3 caught (All 3 secured)

[Map Tracking] MACHICON MapID resolved to: vh03_00 (Return to Kobold Village)
[S2 FLAG ON ] Byte 0x46 (070) |= Mask 0x01 (Bits: 00000001)  <-- Yuzu Recruited! Joined Castle HQ
```

#### Bytecode Grounding (`Mobobehaviour/vh03.json` & `vh10.json`):
- `vh03` Submap 0 Event 76 / 86: Checks `event_flag[70] & 0x01`. Once set, Yuzu despawns from Kobold Village and spawns at Castle HQ (`vk04`).
- `vh10` Submap 6 Events 12–18: Evaluates `event_flag[68]` bits:
  - `0x10` (16): Quest active.
  - `0x20` (32): Sheep 1 corralled.
  - `0x40` (64): Sheep 2 corralled.
  - `0x80` (128): Sheep 3 corralled.

#### Save Editor Mapping:
- **`event_flag[68]`**:
  - `Bit 4` (`0x10`): Yuzu Quest Initiated.
  - `Bit 5` (`0x20`): Sheep 1 Caught.
  - `Bit 6` (`0x40`): Sheep 2 Caught.
  - `Bit 7` (`0x80`): Sheep 3 Caught.
- **`event_flag[70]`**:
  - `Bit 0` (`0x01`): Yuzu Master Recruitment Flag.
- **Recruitment Reset**:
  - When setting Yuzu to Not Recruited: `event_flag[68] &= ~0xF0` and `event_flag[70] &= ~0x01`.

---

### 1.2 Jeane (Star #116) & Two River City Rune Shop

- **Locations**: Two River City Human District (`vh01`), Two River Rune Shop (`vh11`).
- **Recruitment Requirement**: Dunan Castle HQ Level 2+. Speak with Jeane inside the Two River Rune Shop (`vh11_00`) to invite her to join the Allied Army.

#### Live Telemetry Capture:
```text
[Map Tracking] MACHICON MapID resolved to: vh01_00 (Two River City Human District)
[Map Tracking] MACHICON MapID resolved to: vh11_00 (Two River Rune Shop)
[Info   :PK Recruitment Patch] [PKRecruitmentPatch] Jeane recruitment unlocked at Castle Level 2+ in vh11!
[Info   :    PKCore] [S2 FLAG ON ] Byte 0xD5 (213) |= Mask 0x80 (Bits: 10000000)  <-- Jeane Recruited! Joined Castle HQ
```

#### Bytecode Grounding (`Mobobehaviour/vh11.json` & `vh01.json`):
- `vh11` Submap 0 Events 68–86: Evaluates `event_flag[213] & 0x80`.
  - Ev 69, 85, 86: `FlgOnAnd(flag=213, bit=128/0x80)`.
  - Ev 68, 70, 71: `FlgOffAnd(flag=213, bit=128/0x80)`.
  - When set, Jeane permanently departs Two River and opens the Dunan Castle HQ Rune Sage shop.
- `vh01` Submap 0 Events 109–111: External NPC dialogue checks `event_flag[213] & 0x80` to comment on Jeane's departure.

#### Save Editor Mapping:
- **`event_flag[213]`**:
  - `Bit 7` (`0x80`): Jeane Recruited into Castle HQ.
- **Recruitment Reset**:
  - When setting Jeane to Not Recruited: `event_flag[213] &= ~0x80`.

---

### 1.3 Greenhill Reconnaissance Mission & Academy Infiltration (`ve01` / `ve07` / `ve14`)

- **Locations**: Dunan Castle War Conference Room (`vk32`), Castle Tavern (`vk08`), Greenhill City Entrance (`ve01`), New Alliance Academy (`ve07`), Academy Dormitory (`ve14`).
- **Story Context**: Shu briefs Riou on Highland's covert occupation of Greenhill and Mayor Teresa Wisemail's disappearance. Riou, Nanami, and Flik form the reconnaissance team disguised as transfer students to infiltrate New Alliance Academy.

#### Live Telemetry Capture:
```text
[Map Tracking] MACHICON MapID resolved to: vk32_00 / vk32_01 (Castle War Room Briefing)
[Map Tracking] MACHICON MapID resolved to: vk08_00 (Leona's Tavern - Recon Party Locked: Riou, Flik, Nanami)
[Map Tracking] MACHICON MapID resolved to: we_00 (Matilda / Greenhill Overworld)
[Info   :    PKCore] [S2 FLAG ON ] Byte 0x33 (051) |= Mask 0x20 (Bits: 00100000)  <-- Greenhill Region Discovered on World Map
[Map Tracking] MACHICON MapID resolved to: ve01_00 (Greenhill City Entrance)

[Info   :    PKCore] [S2 FLAG OFF] Byte 0xEE (238) &= ~Mask 0x01                 <-- Peacetime Gate State Cleared
[Info   :    PKCore] [S2 FLAG ON ] Byte 0xEF (239) |= Mask 0x01 (Bits: 00000001)  <-- Arrived at Greenhill Gate; Met Fitcher
[Info   :    PKCore] [S2 FLAG ON ] Byte 0xEF (239) |= Mask 0x02 (Bits: 00000010)  <-- Spoke with Fitcher; Entry Briefing Active
[Info   :    PKCore] [S2 FLAG ON ] Byte 0xEF (239) |= Mask 0x04 (Bits: 00000100)  <-- Named Nanami & Flik Aliases (Disguises Confirmed)
[Info   :    PKCore] [S2 FLAG ON ] Byte 0xEF (239) |= Mask 0x04 (Bits: 00000100)  <-- Both Alias Prompts Completed
[Info   :    PKCore] [S2 FLAG ON ] Byte 0xAC (172) |= Mask 0x40 (Bits: 01000000)  <-- Fitcher Checkpoint Inspection Passed
[Info   :    PKCore] [S2 FLAG ON ] Byte 0xAC (172) |= Mask 0x80 (Bits: 10000000)  <-- Walked North Past Checkpoint into Town
[Map Tracking] MACHICON MapID resolved to: ve01_01 (Greenhill Town Square)
[Info   :    PKCore] [S2 FLAG ON ] Byte 0xAD (173) |= Mask 0x01 (Bits: 00000001)  <-- Town Square Initial Arrival Cutscene
[Info   :    PKCore] [S2 FLAG ON ] Byte 0xAD (173) |= Mask 0x02 (Bits: 00000010)  <-- Encountered Nina on Town Square
[Info   :    PKCore] [S2 FLAG ON ] Byte 0xAC (172) |= Mask 0x01 (Bits: 00000001)  <-- Picked Riou & Nanami to Help Nina
[Map Tracking] MACHICON MapID resolved to: ve06_00 (New Leaf Academy Courtyard)
[Map Tracking] MACHICON MapID resolved to: ve07_00 (New Leaf Academy Main Building 1F - Reception)
[Info   :    PKCore] [S2 FLAG ON ] Byte 0xAD (173) |= Mask 0x04 (Bits: 00000100)  <-- Entered Academy Reception / Met Emilia
[Info   :    PKCore] [S2 FLAG ON ] Byte 0xAD (173) |= Mask 0x08 (Bits: 00001000)  <-- Spoke with Emilia; Student Registration Completed
[Info   :    PKCore] [S2 FLAG ON ] Byte 0xD1 (209) |= Mask 0x40 (Bits: 01000000)  <-- Revealed True Identity to Emilia ("Searching for Teresa" / Allied Army)
[Info   :    PKCore] [S2 FLAG ON ] Byte 0xD5 (213) |= Mask 0x20 (Bits: 00100000)  <-- Spoke to Jeane in Academy 1F Rune Classroom
[Map Tracking] MACHICON MapID resolved to: ve06_00 (New Leaf Academy Courtyard)
[Info   :    PKCore] [S2 FLAG ON ] Byte 0xAD (173) |= Mask 0x10 (Bits: 00010000)  <-- Nina Obsessing Over Flik in Front of Academy
[Map Tracking] MACHICON MapID resolved to: ve07_01 (New Leaf Academy Dormitory)
[Info   :    PKCore] [S2 FLAG ON ] Byte 0xAD (173) |= Mask 0x20 (Bits: 00100000)  <-- Spoke to Dormitory Matron; Assigned Rooms Upstairs
[Info   :    PKCore] [S2 FLAG ON ] Byte 0xAD (173) |= Mask 0x40 (Bits: 01000000)  <-- Chose "Let's have another look around" Upstairs
[Info   :    PKCore] [S2 FLAG ON ] Byte 0xAE (174) |= Mask 0x01 (Bits: 00000001)  <-- Decided to Sleep / Supper; Night Hallway with Nina Active
[Info   :    PKCore] [S2 FLAG ON ] Byte 0xAE (174) |= Mask 0x02 (Bits: 00000010)  <-- Completed Night Hallway Encounter with Nina
[Map Tracking] MACHICON MapID resolved to: ve06_00 (New Leaf Academy Courtyard - Morning)
[Info   :    PKCore] [S2 FLAG ON ] Byte 0xAE (174) |= Mask 0x04 (Bits: 00000100)  <-- Exited Dormitory Next Morning (Courtyard Scene)
[Info   :    PKCore] [S2 FLAG ON ] Byte 0xAE (174) |= Mask 0x08 (Bits: 00001000)  <-- Met Flik Outside Dormitory ("Meet up with Fitcher in town")
[Map Tracking] MACHICON MapID resolved to: ve01_01 (Greenhill Town - Outside Inn)
[Info   :    PKCore] [S2 FLAG OFF] Byte 0xAC (172) &= ~Mask 0x02                 <-- Chose "Keep our heads down" During Inn Inspection
[Info   :    PKCore] [S2 FLAG ON ] Byte 0xAE (174) |= Mask 0x10 (Bits: 00010000)  <-- Witnessed Shin, Rowd & Fitcher Scene Outside Greenhill Inn
```

#### Bytecode Grounding (`Mobobehaviour/ve01.json`, `ve06.json`, `ve07.json`, `ve14.json`):
- **`event_flag[238]` (`0xEE`)**:
  - `Bit 0` (`0x01`): Cleared (`&= ~0x01`) upon starting the Greenhill infiltration mission to disable peacetime gate guards.
- **`event_flag[239]` (`0xEF`)**: Master Greenhill Arc Phase State Machine (77 map occurrences).
  - `Bit 0` (`0x01`): Initiated Greenhill Recon Arc / Met Fitcher outside gate (`ve01` Submap 0 Ev 9, 10).
  - `Bit 1` (`0x02`): Fitcher briefing at city gate (`ve01` Submap 0 Ev 11, 12, 13).
  - `Bit 2` (`0x04`): Fake student names chosen for Nanami & Flik (`ve01` Submap 0 Ev 14, 15, 17; `ve07` Ev 64–71; `ve14` Ev 7–10). Fired twice in sequence as each alias prompt completes.
- **`event_flag[172]` (`0xAC`)**:
  - `Bit 0` (`0x01`): Picked **Riou & Nanami** to help Nina in Town Square (`ve01` Submap 1 Ev 12 Com offset 646: `ECEvFlgSet(flag=172, bit=1/0x01)`).
  - `Bit 1` (`0x02`): Choice during Highland soldier inspection outside Greenhill Inn (`ve01` Submap 1 Ev 15 Com offset 161: Choice 0 sets `|= 0x02`, Choice 1 *"Keep our heads down"* clears `&= ~0x02`).
  - `Bit 6` (`0x40`): Fitcher checkpoint inspection cutscene completed at Greenhill Gate (`ve01` Submap 0 Event 18).
  - `Bit 7` (`0x80`): Stepped past the Greenhill checkpoint into `ve01_01` (`ve01` Submap 0 Ev 20 & Submap 1 Ev 11).
- **`event_flag[173]` (`0xAD`)**: Greenhill Town Square & New Leaf Academy Registration State Machine (61 map occurrences).
  - `Bit 0` (`0x01`): Entered Greenhill Town Square (`ve01` Submap 1 Ev 11).
  - `Bit 1` (`0x02`): Encountered Nina in Greenhill Town Square (`ve01` Submap 1 Ev 12).
  - `Bit 2` (`0x04`): Entered New Leaf Academy 1F & approached Emilia at reception (`ve07` Submap 0 Ev 34–35).
  - `Bit 3` (`0x08`): Spoke with Emilia at reception; student registration completed & directed to dormitory (`ve07` Submap 0 Ev 36–43; unlocks `ve06` Ev 35–40).
  - `Bit 4` (`0x10`): Nina obsessing over Flik cutscene in front of the Academy (`ve06` Submap 0 Ev 35–40); transitions party to the Academy Dormitory (`ve07_01`).
  - `Bit 5` (`0x20`): Spoke to the Dormitory Matron (`Obj 47`) at the front desk (`ve07` Submap 1 Ev 13–14); checked in and shown upstairs to rooms.
  - `Bit 6` (`0x40`): Chose *"Let's have another look around."* during Nanami's upstairs room dialogue (`ve07` Submap 1 Ev 18; `1005070212` -> `1005070213`).
- **`event_flag[174]` (`0xAE`)**: Academy Dormitory Night & Investigation State Machine (49 map occurrences).
  - `Bit 0` (`0x01`): Decided to sleep / eat supper in the upstairs dorm room (`ve07` Submap 1 Ev 18–19); transitions to night and spawns **Nina** in the 2F dorm hallway (`ve07` Submap 1 Ev 21–22; `1005070222`).
  - `Bit 1` (`0x02`): Completed the night hallway confrontation with **Nina** (`ve07` Submap 1 Ev 22: *"Aha! There you are, Nanami! You outplayed me this afternoon, but our duel is just beginning."*), waking up the next morning (`ve07` Submap 1 Ev 24–27).
  - `Bit 2` (`0x04`): Stepped outside the dormitory into the Academy Courtyard the next morning (`ve06` Submap 0 Ev 41–43).
  - `Bit 3` (`0x08`): Encountered **Flik** outside the dormitory (`ve06` Submap 0 Ev 44; `1005010234`: *"All right, let's head for town. I got instructions yesterday. We're to meet up with Fitcher."*), unlocking the Fitcher meeting in Greenhill Town Square (`ve01` Submap 1 Ev 14–18).
  - `Bit 4` (`0x10`): Witnessed the **Shin, Rowd & Fitcher cutscene** in front of the Greenhill Inn (`ve01` Submap 1 Ev 15; unlocks return to Academy Courtyard `ve06` Submap 0 Ev 46).
- **`event_flag[209]` (`0xD1`) & `event_flag[210]` (`0xD2`) — Emilia (#96) Pre-Recruitment & Recruitment**:
  - `event_flag[209]` `Bit 6` (`0x40`): Revealed true identity to **Emilia** during the student recon mission (`ve07` Submap 0 Ev 96–99: asked about Shin -> *"We're searching for Teresa..."* -> *"The truth is, we're actually..."* -> `[9, 209, 64]`). Emilia promises to help and remembers this later.
  - `event_flag[209]` `Bit 7` (`0x80`): Chose flattery dialogue option (*"You sure are beautiful."*) with Emilia (`[9, 209, 128]`).
  - `event_flag[210]` `Bit 0` (`0x01`): **Emilia Master Recruitment Flag** (`ve07` Submap 0 Ev 100–103: `[30, 3, 1, 96]` + `[9, 210, 1]`).
  - `event_flag[210]` `Bit 1` (`0x02`): Declined Emilia's offer to join (`ve07` Submap 0 Ev 102–103: `[9, 210, 2]`).
- **`event_flag[213]` (`0xD5`) — Jeane Classroom Interaction (`ve07`)**:
  - `Bit 5` (`0x20`): Spoke to **Jeane** in the New Leaf Academy 1F Rune Sage classroom (`ve07` Submap 0 Ev 106: `[84, 116, 30, 23, 8, 44, 3, 14, 0, 9, 213, 32]`).

#### Save Editor Mapping:
- **`event_flag[239]`**:
  - `Bit 0` (`0x01`): Greenhill Recon Phase 1 — Arrived at Greenhill Gate & Met Fitcher.
  - `Bit 1` (`0x02`): Greenhill Recon Phase 2 — Spoke with Fitcher at Checkpoint.
  - `Bit 2` (`0x04`): Greenhill Recon Phase 3 — Named Nanami & Flik Student Aliases.
- **`event_flag[172]`**:
  - `Bit 0` (`0x01`): Town Square — Picked Riou & Nanami to Help Nina.
  - `Bit 1` (`0x02`): Outside Greenhill Inn — Chose to Intervene (`ON`) vs "Keep our heads down" (`OFF`).
  - `Bit 6` (`0x40`): Greenhill Gate — Fitcher Checkpoint Inspection Passed.
  - `Bit 7` (`0x80`): Greenhill Gate — Stepped Past Checkpoint into City (`ve01_00` -> `ve01_01`).
- **`event_flag[173]`**:
  - `Bit 0` (`0x01`): Greenhill Town Square (`ve01_01`) Initial Arrival Cutscene Completed.
  - `Bit 1` (`0x02`): Greenhill Town Square (`ve01_01`) Nina Encounter Triggered.
  - `Bit 2` (`0x04`): New Leaf Academy (`ve07_00`) Entered Reception / Met Emilia.
  - `Bit 3` (`0x08`): New Leaf Academy (`ve07_00`) Spoke with Emilia / Student Registration Completed.
  - `Bit 4` (`0x10`): Academy Courtyard (`ve06_00`) Nina Obsessing Over Flik Cutscene Completed.
  - `Bit 5` (`0x20`): Academy Dormitory (`ve07_01`) Checked In with Dormitory Matron.
  - `Bit 6` (`0x40`): Academy Dormitory (`ve07_01`) Chose "Let's Have Another Look Around" Upstairs.
- **`event_flag[174]`**:
  - `Bit 0` (`0x01`): Academy Dormitory (`ve07_01`) Decided to Sleep / Supper; Night Hallway with Nina Active.
  - `Bit 1` (`0x02`): Academy Dormitory (`ve07_01`) Completed Night Hallway Encounter with Nina.
  - `Bit 2` (`0x04`): Academy Courtyard (`ve06_00`) Exited Dormitory Next Morning.
  - `Bit 3` (`0x08`): Academy Courtyard (`ve06_00`) Met Flik Outside ("Meet up with Fitcher in town").
  - `Bit 4` (`0x10`): Outside Greenhill Inn (`ve01_01`) Witnessed Shin, Rowd & Fitcher Cutscene.
- **`event_flag[209]`**:
  - `Bit 6` (`0x40`): New Leaf Academy (`ve07_00`) Revealed True Identity to Emilia During Recon Mission.
  - `Bit 7` (`0x80`): New Leaf Academy (`ve07_00`) Used Flattery Dialogue Option with Emilia.
- **`event_flag[210]`**:
  - `Bit 0` (`0x01`): Emilia Recruited at New Leaf Academy (`ve07_00`).
  - `Bit 1` (`0x02`): Emilia Join Offer Declined Re-prompt (`ve07_00`).
- **`event_flag[213]`**:
  - `Bit 5` (`0x20`): Spoke to Jeane in New Leaf Academy 1F Rune Classroom (`ve07_00`).

---

### 1.4 Pico (Star #113) & Greenhill Inn Recruitment (`ve10`)

- **Location**: Greenhill Inn (`ve10_00`).
- **Recruitment Requirement**: Annallee (#112) must already be recruited; speak to Mairie and Pico inside the Greenhill Inn room (`ve10_00` x: 114..117, y: 148..157). (In vanilla, gated behind Greenhill Liberation `event_flag[187] & 0x40` and Castle Level 4; unlocked early at Castle Level 2+ via `PicoRecruitmentPatch.cs`).

#### Live Telemetry & Save Diff Capture (`Data150.json` -> `Data151.json`):
```text
[Map Tracking] MACHICON MapID resolved to: ve01_01 (Greenhill Town Square)
[Info   :    PKCore] [S2 FLAG ON ] Byte 0xAD (173) |= Mask 0x01 (Bits: 00000001)
[Map Tracking] MACHICON MapID resolved to: ve10_00 (Greenhill Inn)
[Info   :    PKCore] [PotraitSystem] Using cached portrait sprite for 'Mairie'
[Info   :    PKCore] [S2 FLAG ON ] Byte 0xD2 (210) |= Mask 0x20 (Bits: 00100000)  <-- Pico Recruited! Joined Castle HQ

--- Save Inspector Diff (Data150.json -> Data151.json) ---
  Flag [210]: 0x80 (128) -> 0xA0 (160)  [diff: 10000000 -> 10100000]
```

#### Bytecode Grounding (`Mobobehaviour/ve10.json`):
- `ve10` Submap 0 Event 21 (Map Init Spawn): Checks `FlgOffAnd(flag=210, bit=32/0x20)` along with Annallee recruited (`[23, 112, 2]`).
- `ve10` Submap 0 Event 22 (Recruitment Cutscene): Triggered when stepping in front of Pico (`x: 114..117, y: 148..157`) while `event_flag[210] & 0x20` is OFF. Executes `ECEvFlgSet(flag=210, bit=32/0x20)` when Pico joins the Allied Army.
- `ve10` Submap 0 Events 23, 24, 35: Check `FlgOnAnd(flag=210, bit=32/0x20)` for Mairie's post-recruitment dialogue after Pico leaves for Castle HQ.

#### Save Editor Mapping:
- **`event_flag[210]`**:
  - `Bit 5` (`0x20` / Mask 32): Pico Recruited in Greenhill Inn (`ve10`).
- **Recruitment Reset**:
  - When setting Pico (#113) to Not Recruited: `event_flag[210] &= ~0x20`.

---

## 2. Livestock & Pasture Deliveries (Yuzu's Ranch)

- **System Context**: Once Yuzu is recruited, players can acquire livestock throughout the world and deliver them to Yuzu's pasture at Dunan Castle.
- **Animal Vendors / Pickups**:
  - **Lamb**: Kobold Village (`vh10_02`, vendor 4,000 Potch), Forest Village, Sajah Village.
  - **Calf**: Highway Village, Forest Village, Sajah Village.
  - **Piglet**: Rokkaku Hamlet, Forest Village, Sajah Village.
  - **Chick**: Radat Wharf, Forest Village, Sajah Village.

### Dual-Storage Architecture:
1. **Acquisition / Transit**:
   - Animals purchased from merchants or found in the field enter the player's inventory or key items (`party_item` / `event_item`) as portable animal items.
   - For vendor purchases that immediately deliver to the farm without occupying bag slots, the game sets a delivery flag or directly increments the ranch counter.
2. **Castle HQ Pasture Storage**:
   - Stored in `game_data.food_num[4..7]` (Chicks: `food_num[4]`, Pigs: `food_num[5]`, Sheep: `food_num[6]`, Cattle: `food_num[7]`).
   - Synchronized with display flags in `hon_flag[31..33]`:
     - `hon_flag[31]` (bits 4–7): Chicks 1–3
     - `hon_flag[32]` (bits 0–7): Pigs 1–3, Sheep 1–4, Calf 1
     - `hon_flag[33]` (bit 0): Calves 2–3

---

## 3. Map Transition Flags (Engine Volatile Flags)

Throughout map transitions, the game engine repeatedly clears specific volatile flag masks:

| Byte Index | Cleared Mask | Purpose |
| :---: | :---: | :--- |
| **`0x94` (148)** | `&= ~0x10` (16) | Temporary room/actor state reset during map entry (`OnMapInit`). |
| **`0x94` (148)** | `&= ~0x20` (32) | Temporary interactive prompt debounce reset. |

These bits are volatile runtime markers and should not be persisted as permanent progression in save files.

---

## 4. Telemetry Capture Session Log

| Date / Time | Map ID | Location | Action / Event | Log Output |
| :--- | :--- | :--- | :--- | :--- |
| 2026-11-03 12:14 | `vh03_00` | Kobold Village | Speak to Yuzu | `[S2 FLAG ON ] Byte 0x44 (068) \|= Mask 0x10` |
| 2026-11-03 12:14 | `vh10_05` | Unicorn Pasture | Catch Sheep #1 | `[S2 FLAG ON ] Byte 0x44 (068) \|= Mask 0x20` |
| 2026-11-03 12:14 | `vh10_05` | Unicorn Pasture | Catch Sheep #2 | `[S2 FLAG ON ] Byte 0x44 (068) \|= Mask 0x40` |
| 2026-11-03 12:14 | `vh10_05` | Unicorn Pasture | Catch Sheep #3 | `[S2 FLAG ON ] Byte 0x44 (068) \|= Mask 0x80` |
| 2026-11-03 12:14 | `vh03_00` | Kobold Village | Yuzu Joins | `[S2 FLAG ON ] Byte 0x46 (070) \|= Mask 0x01` |
| 2026-11-03 12:29 | `vh10_02` | Unicorn Woods | Buy Lamb (4,000p) | In-progress delivery / inventory item |
| 2026-11-03 12:38 | `wh_00` | World Map | Overworld step | `[S2 FLAG ON ] Byte 0x35 (053) \|= Mask 0x04` |
| 2026-11-03 12:38 | `vh11_00` | Two River Rune Shop | Jeane Joins | `[S2 FLAG ON ] Byte 0xD5 (213) \|= Mask 0x80` |
| 2026-11-03 12:54 | Title/Intro | New Game Startup | Prologue Setup | `[S2 FLAG ON ] Byte 0x96 (150) \|= Mask 0x01, 0x02, 0x20` |
| 2026-11-03 13:00 | `va01_01` | Youth Brigade Tent | "Let's go outside" | `[S2 FLAG ON ] Byte 0x00 (000) \|= Mask 0x01` |
| 2026-11-03 13:04 | `va01_00` / `01` | Camp Grounds / Tent | Sparring Scene Viewed | `[S2 FLAG ON ] Byte 0x00 (000) \|= Mask 0x10` |
| 2026-11-03 13:07 | `va01_01` | Youth Brigade Tent | Spoke to Captain Rowd | `[S2 FLAG ON ] Byte 0x00 (000) \|= Mask 0x08` |
| 2026-11-03 13:09 | `va01_02` -> `03` | Burning Camp -> Clearing | Met Shadowy Figure (Luca) | `[S2 FLAG ON ] Byte 0x00 (000) \|= Mask 0x40` |
| 2026-11-03 13:16 | `va01_01` | Tent Return | Returned to tent after warning | `[S2 FLAG ON ] Byte 0x00 (000) \|= Mask 0x20` |
| 2026-11-03 13:16 | `va01_01` | Tent Interior | Pack up / agree to flee | `[S2 FLAG ON ] Byte 0x00 (000) \|= Mask 0x80` |
| 2026-11-03 13:16 | `va01_00` | Burning Camp Grounds | Escaped tent exterior | `[S2 FLAG ON ] Byte 0x01 (001) \|= Mask 0x01` |
| 2026-11-03 13:17 | `va01_02` | Burning Corridor | Highland soldier encounter | `[S2 FLAG ON ] Byte 0x01 (001) \|= Mask 0x08` |
| 2026-11-03 13:17 | `va01_03` | East Forest Clearing | Reached clearing | `[S2 FLAG ON ] Byte 0x01 (001) \|= Mask 0x20` |
| 2026-11-03 13:17 | `va01_03` | East Forest Clearing | Responded to Jowy ("Okay") | `[S2 FLAG ON ] Byte 0x01 (001) \|= Mask 0x10` |
| 2026-11-03 13:17 | `va01_03` | North Path to Cliff | Sprint towards cliff face | `[S2 FLAG ON ] Byte 0x01 (001) \|= Mask 0x80` |
| 2026-11-03 13:37 | `va01_00` | Burning Camp Grounds | Turn back to confront Rowd | `[S2 FLAG ON ] Byte 0x01 (001) \|= Mask 0x40` |
| 2026-11-03 13:39 | `va09_00` | Tenzan Pass Cliff | Reach cliff approach | `[S2 FLAG ON ] Byte 0x02 (002) \|= Mask 0x01` |
| 2026-11-03 13:39 | `va09_00` | Tenzan Pass Cliff | First cliff battle | `[S2 FLAG ON ] Byte 0x02 (002) \|= Mask 0x02, 0x04` |
| 2026-11-03 13:39 | `va09_00` | Tenzan Pass Cliff | Jump decision dialogue | `[S2 FLAG ON ] Byte 0x02 (002) \|= Mask 0x08` |
| 2026-11-03 13:40 | `va09_00` | Tenzan Pass Cliff | Refuse jump ("Look at current") | `[S2 FLAG ON ] Byte 0x02 (002) \|= Mask 0x40` |
| 2026-11-03 18:48 | `we_00` | Greenhill Overworld | Approach Greenhill City | `[S2 FLAG ON ] Byte 0x33 (051) \|= Mask 0x20` |
| 2026-11-03 18:48 | `ve01_00` | Greenhill Entrance | Disable peacetime gate state | `[S2 FLAG OFF] Byte 0xEE (238) &= ~Mask 0x01` |
| 2026-11-03 18:48 | `ve01_00` | Greenhill Entrance | Meet Fitcher at gate | `[S2 FLAG ON ] Byte 0xEF (239) \|= Mask 0x01` |
| 2026-11-03 18:48 | `ve01_00` | Greenhill Entrance | Speak with Fitcher / Briefing | `[S2 FLAG ON ] Byte 0xEF (239) \|= Mask 0x02` |
| 2026-11-03 18:48 | `ve01_00` | Greenhill Entrance | Name Nanami & Flik aliases | `[S2 FLAG ON ] Byte 0xEF (239) \|= Mask 0x04` (x2) |
| 2026-11-03 18:48 | `ve01_00` | Greenhill Entrance | Fitcher checkpoint inspection passed | `[S2 FLAG ON ] Byte 0xAC (172) \|= Mask 0x40` |
| 2026-11-03 18:52 | `ve01_00` | Greenhill Entrance | Step past checkpoint into city | `[S2 FLAG ON ] Byte 0xAC (172) \|= Mask 0x80` |
| 2026-11-03 18:52 | `ve01_01` | Greenhill Town Square | Initial town square scene | `[S2 FLAG ON ] Byte 0xAD (173) \|= Mask 0x01` |
| 2026-11-03 18:53 | `ve10_00` | Greenhill Inn | Recruit Pico (with Annallee) | `[S2 FLAG ON ] Byte 0xD2 (210) \|= Mask 0x20` |
| 2026-11-03 18:56 | `ve01_01` | Greenhill Town Square | Encounter Nina on the square | `[S2 FLAG ON ] Byte 0xAD (173) \|= Mask 0x02` |
| 2026-11-03 18:56 | `ve01_01` | Greenhill Town Square | Pick Riou & Nanami to help Nina | `[S2 FLAG ON ] Byte 0xAC (172) \|= Mask 0x01` |
| 2026-11-03 19:03 | `ve07_00` | New Leaf Academy 1F | Enter Reception / Meet Emilia | `[S2 FLAG ON ] Byte 0xAD (173) \|= Mask 0x04` |
| 2026-11-03 19:03 | `ve07_00` | New Leaf Academy 1F | Speak with Emilia (Registration) | `[S2 FLAG ON ] Byte 0xAD (173) \|= Mask 0x08` |
| 2026-11-03 19:07 | `ve07_00` | New Leaf Academy 1F | Reveal true identity to Emilia ("Searching for Teresa") | `[S2 FLAG ON ] Byte 0xD1 (209) \|= Mask 0x40` |
| 2026-11-03 19:07 | `ve07_00` | New Leaf Academy 1F | Speak to Jeane in Rune Classroom | `[S2 FLAG ON ] Byte 0xD5 (213) \|= Mask 0x20` |
| 2026-11-03 19:43 | `ve06_00` | Academy Courtyard | Nina obsessing over Flik in front of Academy | `[S2 FLAG ON ] Byte 0xAD (173) \|= Mask 0x10` |
| 2026-11-03 19:44 | `ve07_01` | Academy Dormitory | Speak to Dormitory Matron (Room check-in) | `[S2 FLAG ON ] Byte 0xAD (173) \|= Mask 0x20` |
| 2026-11-03 19:44 | `ve07_01` | Academy Dormitory 2F | Choose "Let's have another look around" | `[S2 FLAG ON ] Byte 0xAD (173) \|= Mask 0x40` |
| 2026-11-03 19:49 | `ve07_01` | Academy Dormitory 2F | Decide to sleep / Encounter Nina in night hallway | `[S2 FLAG ON ] Byte 0xAE (174) \|= Mask 0x01` |
| 2026-11-03 19:50 | `ve07_01` | Academy Dormitory 2F | Complete Nina night hallway encounter & wake up | `[S2 FLAG ON ] Byte 0xAE (174) \|= Mask 0x02` |
| 2026-11-03 19:50 | `ve06_00` | Academy Courtyard | Exit dormitory next morning | `[S2 FLAG ON ] Byte 0xAE (174) \|= Mask 0x04` |
| 2026-11-03 19:50 | `ve06_00` | Academy Courtyard | Meet Flik outside ("Meet up with Fitcher") | `[S2 FLAG ON ] Byte 0xAE (174) \|= Mask 0x08` |
| 2026-11-03 19:53 | `ve01_01` | Outside Greenhill Inn | Choose "Keep our heads down" | `[S2 FLAG OFF] Byte 0xAC (172) &= ~Mask 0x02` |
| 2026-11-03 19:53 | `ve01_01` | Outside Greenhill Inn | Witness Shin, Rowd & Fitcher cutscene | `[S2 FLAG ON ] Byte 0xAE (174) \|= Mask 0x10` |
