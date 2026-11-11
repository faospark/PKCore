# Suikoden II Geographic Area Catalog: Gregminster Town Interiors & Commercial District

**Geographic Scope & Role**: Comprehensive interior catalog for the capital of the Toran Republic (`vf03`); covers all 14 indoor residential and commercial buildings across Gregminster: the McDohl Family Estate (Gremio, Cleo & Pahn's rooms, Recipe #39), Marie's Famous Inn (Lobby, Dining Hall, Guestrooms, Save Crystal), Gordon's Mercantile & Appraisal Trading Post, Lady Sonya Shulen's Residence, the Gregminster Rune Sage Guild, the Master Armor & Item Shop (Toran's oldest store), and various private townhouses.

**Regional Category**: Region `VF` | **Master Maps Included**: `vf03`

**Grounding Reference**: Compiled from direct bytecode and string inspection of `D:\Modding\suikodum\Mobobehaviour\vf03.json` and `text_gsd2_en` (Bank `100603`).

---

## 📖 Human-Readable Field & Engine Legend

| Field / Concept | Engine Term | Human Meaning & Allowed Values |
|---|---|---|
| **Class (`otyp`)** | Object Type | **1** = NPC / Actor (living characters)<br>**2** = Prop / Scenery (wells, buckets, tables, chairs, decorations)<br>**3** = World Device (Journeyman save crystals, chests, inn rest beds, diaries)<br>**4** = Trigger / Hitbox (invisible door warps, counter barriers, interactive zones) |
| **Collision (`ozok`)** | Obstacle Mask | **0** = Passable (walk-through rugs, doorways, floor pads)<br>**2** = Solid Obstacle (impassable physical barrier you bump into)<br>**3** = Special Barrier (counters, railings, low tables you can speak across) |
| **Facing (`ano`)** | Animation / State | For NPCs: **0** = South, **1** = West, **2** = North, **3** = East<br>For Devices: **81 / 5** = Spinning Save Crystal, **26 / 12** = Inn Bed / Rest Device |
| **Display (`disp`)** | Visibility State | **1** = Active & Rendered on screen<br>**0** = Dormant / Hidden (spawned dynamically via story events or party flags) |
| **Coords (`x, y`)** | Tile Grid Position | Exact tile coordinates on the interior submap (`(0, 0)` is top-left) |
| **Size (`w, h`)** | Trigger Dimensions | Dimensions of interaction bounding box (`0x0` = 1x1 single tile) |
| **Speed (`spd`)** | Movement Rate | Movement velocity (**0** = stationary fixture, **4** = walking speed) |
| **Wait (`wt`)** | Wander Timer | Wander idle delay (**255** = fixed stationary orientation) |
| **Mode (`etyp`)** | Trigger Mode | **1 (Talk / Action)** = Inspect with Confirm button<br>**2 (Map Init)** = Execute on room load<br>**3 (Step-On Tripwire)** = Walk-over trigger<br>**4 (Loop)** = Continuous background trigger |
| **`eventForm`** | Preconditions | Preconditions required for script execution (story progress flags, inspected target object) |
| **`eventCom`** | Action Sequence | The decompiled sequence of engine opcodes executed when triggered |

---

## Location Map: `vf03` (All 14 Interior Submaps)

- **Master Map Container**: `vf03.json`
- **Submap Layer Files**: `vf03_00.json` through `vf03_30.json`
- **Collision Grid Files**: `vf03_map_00.json`, `vf03_map_01.json`
- **Submap Room Count**: 14 Independent Building Interiors
- **Message Bank Assigned**: Bank `100603` (135 Unique Dialogue & Inspection Entries)

---

### Submap Layer `vf03_00` (Index 0) — McDohl Estate — 1F Kitchen & Dining Hall

**Room Architecture & Role**: Ground floor of General Teo & Tir McDohl's private estate; dining hall, kitchen hearth with simmering special stew, cookbook shelves, and servant quarters. Key location for Gremio's Recipe #39 cutscene, Cleo's locked diary, and Pahn's eating diary.

- **Map Number (`mapno`)**: `0` | **Battle Encounter Zone (`batlno`)**: `0`
- **Physical Entity Count (`okaz`)**: `20` Objects | **Bytecode Script Count (`evkaz`)**: `38` Scripts

#### Complete Physical Entity Inventory

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Gremio (Kitchen Stove / Special Stew)** | `125` | `(72, 29)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Cleo** | `164` | `(50, 71)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Cleo** | `164` | `(29, 30)` | `6x6` | South (Down) | Dormant / Hidden (0) | Special (3) | 4 | 128 | 0 |
| `obj[03]` | NPC / Actor | **Pahn** | `165` | `(45, 32)` | `6x6` | South (Down) | Dormant / Hidden (0) | Special (3) | 4 | 128 | 0 |
| `obj[04]` | World Device | **Journeyman Save Crystal (Spinning)** | `0` | `(67, 21)` | `0x0` | Frame 81 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(71, 28)` | `1x1` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (4x2)** | `0` | `(35, 63)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (4x2)** | `0` | `(31, 27)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (4x2)** | `0` | `(41, 27)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(67, 27)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (4x2)** | `0` | `(71, 26)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (4x2)** | `0` | `(35, 27)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(78, 65)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (4x2)** | `0` | `(63, 64)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (4x2)** | `0` | `(63, 69)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[15]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (4x2)** | `0` | `(59, 31)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[16]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(63, 31)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[17]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(75, 28)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[18]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(77, 28)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[19]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(75, 48)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |

#### Complete Bytecode Script Catalog

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 64 (bit 16) SET AND Story Flag 150 (bit 2) SET AND Story Flag 150 (bit 4) CLEAR AND Player within Box [50..50, 71..71] | Engine Action #36; Engine Action #16 |
| `ev[01]` | `128 (Loop)` | Engine Condition #6 AND Engine Condition #16 | Stage/Verify Event Party Configuration (ECInitPartySet: chara=37, slot=16); Engine Action #101; Engine Action #5; Engine Action #0; Engine Action #105; Display Dialogue Box [Bank 0, Msg #68]; ... (+6 more opcodes) |
| `ev[02]` | `2 (Map Init)` | Story Flag 64 (bit 16) CLEAR | Engine Action #0; Engine Action #10 |
| `ev[03]` | `2 (Map Init)` | Story Flag 65 (bit 16) SET | Engine Action #46; Engine Action #0; Engine Action #10; Engine Action #0; Engine Action #11; Warp Room -> Submap 9 at (32,32); ... (+1 more opcodes) |
| `ev[04]` | `1 (Action / Talk)` | Target Inspected is obj[10] AND Story Flag 64 (bit 16) CLEAR | Display Dialogue Window [Msg 160]: "Welcome.  Oh, you must be the one President L..." |
| `ev[05]` | `1 (Action / Talk)` | Target Inspected is obj[10] AND Story Flag 65 (bit 16) SET | Display Dialogue Window [Msg 158]: "Oh, when did you get here, ♂㈱? Make yourself ..." |
| `ev[06]` | `1 (Action / Talk)` | Target Inspected is obj[11] AND Story Flag 65 (bit 16) SET | Display Dialogue Window [Msg 159]: "Ah, it's been a while... ♂㈱, right?..." |
| `ev[07]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Display Dialogue Window [Msg 173]: "☆0                Petunias..." |
| `ev[08]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Display Dialogue Window [Msg 174]: "☆0         Cleo's Diary◎6∨☆0            It's ..." |
| `ev[09]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Display Dialogue Window [Msg 175]: "☆0           Pahn's Diary∨Yesterday's Menu: S..." |
| `ev[10]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Open Dialogue Sub-Window (Bank 6, Index 3) |
| `ev[11]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Display Dialogue Window [Msg 177]: "☆0    A stew is simmering here.          It s..." |
| `ev[12]` | `1 (Action / Talk)` | Target Inspected is obj[19] | Open Dialogue Sub-Window (Bank 6, Index 50) |
| `ev[13]` | `1 (Action / Talk)` | Target Inspected is obj[20] | Display Dialogue Window [Msg 224]: "☆0          Wooden Bucket..." |
| `ev[14]` | `1 (Action / Talk)` | Target Inspected is obj[21] | Display Dialogue Window [Msg 225]: "☆0       "101 Savory Stews"..." |
| `ev[15]` | `1 (Action / Talk)` | Target Inspected is obj[22] | Display Dialogue Window [Msg 226]: "☆0          "World Cuisine"..." |
| `ev[16]` | `1 (Action / Talk)` | Target Inspected is obj[23] | Open Dialogue Sub-Window (Bank 6, Index 54) |
| `ev[17]` | `1 (Action / Talk)` | Target Inspected is obj[24] | Display Dialogue Window [Msg 228]: "☆0         Stacked Firewood..." |
| `ev[18]` | `1 (Action / Talk)` | Target Inspected is obj[25] | Open Dialogue Sub-Window (Bank 6, Index 56) |
| `ev[19]` | `1 (Action / Talk)` | Target Inspected is obj[26] | Display Dialogue Window [Msg 230]: "☆0     Pot Full of Cooking Wine..." |
| `ev[20]` | `1 (Action / Talk)` | Target Inspected is obj[27] | Open Dialogue Sub-Window (Bank 6, Index 58) |
| `ev[21]` | `128 (Loop)` | Player within Box [41..59, 62..74] | Engine Action #31; Display Dialogue [Msg 128]: "Are there Kobolds in the City-States, too? Re..." |
| `ev[22]` | `2 (Map Init)` | Story Flag 65 (bit 128) SET | Engine Action #46; Engine Action #0; Engine Action #13; Engine Action #0; Engine Action #8; Engine Action #47 |
| `ev[23]` | `2 (Map Init)` | Story Flag 150 (bit 4) SET | Engine Action #0; Engine Action #12 |
| `ev[24]` | `2 (Map Init)` | Story Flag 64 (bit 64) SET AND Story Flag 64 (bit 128) CLEAR AND Engine Condition #9 AND Engine Condition #0 | Engine Action #46; Engine Action #0; Engine Action #9; Engine Action #47 |
| `ev[25]` | `2 (Map Init)` | Story Flag 64 (bit 128) SET AND Story Flag 65 (bit 1) CLEAR AND Story Flag 150 (bit 4) CLEAR AND Engine Condition #16 AND Engine Condition #1 AND Engine Condition #82 AND Engine Condition #16 AND Engine Condition #1 AND Engine Condition #125 | Engine Action #46; Engine Action #63; Warp Room -> Submap 82 at (125,2); Exit / Warp to Gregminster Exterior (vf02) at (48,70); Exit / Warp to Gregminster Exterior (vf02) at (3,1); Warp Room -> Submap 2 at (52,70); ... (+2 more opcodes) |
| `ev[26]` | `2 (Map Init)` | Story Flag 64 (bit 128) SET AND Story Flag 65 (bit 1) CLEAR AND Story Flag 150 (bit 4) SET AND Engine Condition #16 AND Engine Condition #1 AND Engine Condition #82 AND Engine Condition #16 AND Engine Condition #1 AND Engine Condition #172 | Engine Action #46; Engine Action #63; Warp Room -> Submap 82 at (172,2); Exit / Warp to Gregminster Exterior (vf02) at (48,70); Exit / Warp to Gregminster Exterior (vf02) at (3,1); Warp Room -> Submap 2 at (52,70); ... (+2 more opcodes) |
| `ev[27]` | `1 (Action / Talk)` | Player within Box [49..51, 74..76] AND Engine Condition #16 AND Story Flag 150 (bit 2) SET AND Story Flag 150 (bit 4) CLEAR AND Engine Condition #9 AND Engine Condition #0 | Engine Action #101; Engine Action #9; Engine Action #8; Engine Action #102; Engine Action #0; Engine Action #69; ... (+7 more opcodes) |
| `ev[28]` | `1 (Action / Talk)` | Player within Box [49..51, 74..76] | Engine Action #102; Engine Action #0; Open Shop Menu / Commercial Interface (ShopID: 3, Type: 0) |
| `ev[29]` | `1 (Action / Talk)` | Player within Box [41..43, 59..60] | Engine Action #12; Exit / Warp to Gregminster Exterior (vf02) at (143,66) |
| `ev[30]` | `1 (Action / Talk)` | Player within Box [57..59, 58..59] | Engine Action #12; Exit / Warp to Gregminster Exterior (vf02) at (157,66) |
| `ev[31]` | `1 (Action / Talk)` | Story Flag 64 (bit 64) SET AND Story Flag 64 (bit 128) CLEAR AND Engine Condition #16 AND Engine Condition #1 AND Engine Condition #73 | Stage/Verify Event Party Configuration (ECInitPartySet: chara=48, slot=0); Engine Action #9; Screen Fade Transition / Room Switch; Display Dialogue Box [Bank 1, Msg #2]; Engine Action #9; Screen Fade Transition / Room Switch; ... (+24 more opcodes) |
| `ev[32]` | `1 (Action / Talk)` | Story Flag 64 (bit 64) SET AND Story Flag 64 (bit 128) CLEAR AND Engine Condition #16 AND Engine Condition #0 AND Engine Condition #73 | Stage/Verify Event Party Configuration (ECInitPartySet: chara=48, slot=0); Engine Action #9; Screen Fade Transition / Room Switch; Display Dialogue Box [Bank 1, Msg #2]; Engine Action #9; Screen Fade Transition / Room Switch; ... (+24 more opcodes) |
| `ev[33]` | `1 (Action / Talk)` | Story Flag 64 (bit 128) SET AND Story Flag 65 (bit 1) CLEAR AND Story Flag 150 (bit 4) CLEAR | Stage/Verify Event Party Configuration (ECInitPartySet: chara=11, slot=1); Warp Room -> Submap 90 at (24,2); Engine Action #0; Engine Action #42; Engine Action #49; Warp Room -> Submap 48 at (1,0); ... (+13 more opcodes) |
| `ev[34]` | `1 (Action / Talk)` | Story Flag 64 (bit 128) SET AND Story Flag 65 (bit 1) CLEAR AND Story Flag 150 (bit 4) SET | Stage/Verify Event Party Configuration (ECInitPartySet: chara=11, slot=1); Warp Room -> Submap 90 at (24,2); Engine Action #0; Engine Action #43; Engine Action #49; Warp Room -> Submap 48 at (1,0); ... (+13 more opcodes) |
| `ev[35]` | `1 (Action / Talk)` | Story Flag 65 (bit 128) SET AND Engine Condition #7 AND Engine Condition #32 AND Target Inspected is obj[13] | Stage/Verify Event Party Configuration (ECInitPartySet: chara=3, slot=8); Exit / Warp to Gregminster Exterior (vf02) at (55,0); Engine Action #31; Engine Action #9; Screen Fade Transition / Room Switch; Display Dialogue Box [Bank 1, Msg #24]; ... (+17 more opcodes) |
| `ev[36]` | `1 (Action / Talk)` | Story Flag 65 (bit 128) CLEAR AND Engine Condition #7 AND Engine Condition #32 AND Target Inspected is obj[13] | Stage/Verify Event Party Configuration (ECInitPartySet: chara=3, slot=8); Exit / Warp to Gregminster Exterior (vf02) at (55,0); Engine Action #31; Engine Action #9; Screen Fade Transition / Room Switch; Display Dialogue Box [Bank 1, Msg #24]; ... (+17 more opcodes) |
| `ev[37]` | `1 (Action / Talk)` | Engine Condition #6 AND Engine Condition #32 AND Target Inspected is obj[8] | Display Dialogue Window [Msg 316]: "Doesn't this smell delicious? This is my prid..."; Engine Action #73; Engine Action #20; Engine Action #101; Engine Action #4; Engine Action #7; ... (+19 more opcodes) |

---

### Submap Layer `vf03_01` (Index 1) — McDohl Estate — 2F Master Bedchamber & Study

**Room Architecture & Role**: Upper residential quarters of the McDohl mansion; Tir McDohl's former bedroom, writing desk, antique vase display, stately armor suit, and historical book collections.

- **Map Number (`mapno`)**: `0` | **Battle Encounter Zone (`batlno`)**: `0`
- **Physical Entity Count (`okaz`)**: `23` Objects | **Bytecode Script Count (`evkaz`)**: `26` Scripts

#### Complete Physical Entity Inventory

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **McDohl** | `82` | `(127, 67)` | `4x6` | South (Down) | Dormant / Hidden (0) | Special (3) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Gremio** | `125` | `(133, 65)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Pahn** | `165` | `(147, 39)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | NPC / Actor | **Cleo** | `164` | `(143, 39)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[04]` | Prop / Scenery | **Interior Furnishing / Decoration (Prop 53586)** | `53586` | `(145, 32)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | Prop / Scenery | **Interior Furnishing / Decoration (Prop 53586)** | `53586` | `(149, 32)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | Prop / Scenery | **Interior Furnishing / Decoration (Prop 53586)** | `53586` | `(143, 40)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Prop / Scenery | **Interior Furnishing / Decoration (Prop 53586)** | `53586` | `(147, 40)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Prop / Scenery | **Interior Furnishing / Decoration (Prop 53586)** | `53586` | `(151, 40)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | World Device | **Journeyman Save Crystal (Spinning)** | `0` | `(139, 38)` | `0x0` | Frame 5 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(145, 30)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(149, 30)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (4x2)** | `0` | `(135, 63)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(166, 71)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(150, 51)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[15]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(174, 63)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[16]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(175, 65)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[17]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (4x2)** | `0` | `(171, 27)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[18]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(162, 27)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[19]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(138, 27)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[20]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (4x2)** | `0` | `(127, 27)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[21]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(124, 27)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[22]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(176, 27)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |

#### Complete Bytecode Script Catalog

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Target Inspected is obj[20] | Open Dialogue Sub-Window (Bank 6, Index 5) |
| `ev[01]` | `1 (Action / Talk)` | Target Inspected is obj[21] | Open Dialogue Sub-Window (Bank 6, Index 6) |
| `ev[02]` | `1 (Action / Talk)` | Target Inspected is obj[22] | Display Dialogue Window [Msg 232]: "☆0            Reading Desk..." |
| `ev[03]` | `1 (Action / Talk)` | Target Inspected is obj[23] | Open Dialogue Sub-Window (Bank 6, Index 60) |
| `ev[04]` | `1 (Action / Talk)` | Target Inspected is obj[24] | Display Dialogue Window [Msg 234]: "☆0     Expensive-Looking Vase..." |
| `ev[05]` | `1 (Action / Talk)` | Target Inspected is obj[25] | Open Dialogue Sub-Window (Bank 6, Index 62) |
| `ev[06]` | `1 (Action / Talk)` | Target Inspected is obj[26] | Display Dialogue Window [Msg 236]: "☆0            Stately Armor..." |
| `ev[07]` | `1 (Action / Talk)` | Target Inspected is obj[27] | Open Dialogue Sub-Window (Bank 6, Index 64) |
| `ev[08]` | `1 (Action / Talk)` | Target Inspected is obj[28] | Display Dialogue Window [Msg 238]: "☆0               Bookcase..." |
| `ev[09]` | `1 (Action / Talk)` | Target Inspected is obj[29] | Open Dialogue Sub-Window (Bank 6, Index 66) |
| `ev[10]` | `1 (Action / Talk)` | Target Inspected is obj[30] | Open Dialogue Sub-Window (Bank 6, Index 67) |
| `ev[11]` | `2 (Map Init)` | Story Flag 65 (bit 16) SET AND Engine Condition #16 AND Engine Condition #0 AND Engine Condition #82 | Engine Action #0; Engine Action #8 |
| `ev[12]` | `2 (Map Init)` | Story Flag 65 (bit 16) SET AND Story Flag 65 (bit 128) CLEAR AND Story Flag 150 (bit 4) CLEAR | Engine Action #0; Engine Action #9 |
| `ev[13]` | `2 (Map Init)` | Player within Box [145..145, 31..31] AND Engine Condition #32 AND Engine Condition #9 AND Engine Condition #0 AND Engine Condition #16 AND Engine Condition #1 AND Engine Condition #82 AND Engine Condition #16 AND Engine Condition #1 AND Engine Condition #125 | Engine Action #46; Engine Action #36; Engine Action #8; Engine Action #63; Warp Room -> Submap 82 at (125,89); Engine Action #12; ... (+16 more opcodes) |
| `ev[14]` | `2 (Map Init)` | Player within Box [145..145, 31..31] AND Engine Condition #32 AND Engine Condition #9 AND Engine Condition #0 AND Engine Condition #16 AND Engine Condition #1 AND Engine Condition #82 AND Engine Condition #16 AND Engine Condition #1 AND Engine Condition #172 | Engine Action #46; Engine Action #36; Engine Action #8; Engine Action #63; Warp Room -> Submap 82 at (172,89); Engine Action #12; ... (+16 more opcodes) |
| `ev[15]` | `128 (Loop)` | Engine Condition #6 AND Engine Condition #8 AND Engine Condition #16 AND Engine Condition #1 AND Engine Condition #125 | Engine Action #37; Engine Action #8; Engine Action #101; Engine Action #5; Engine Action #0; Engine Action #105; ... (+3 more opcodes) |
| `ev[16]` | `128 (Loop)` | Engine Condition #6 AND Engine Condition #128 | Engine Action #31; Engine Action #0; Engine Action #13; Engine Action #27; Engine Action #37; Engine Action #128; ... (+2 more opcodes) |
| `ev[17]` | `1 (Action / Talk)` | Target Inspected is obj[8] AND Story Flag 150 (bit 4) CLEAR AND Story Flag 65 (bit 128) CLEAR | Stage/Verify Event Party Configuration (ECInitPartySet: chara=73, slot=20); Engine Action #40; Display Dialogue Box [Bank 0, Msg #2]; Engine Action #0; Engine Action #55; Engine Action #0; ... (+23 more opcodes) |
| `ev[18]` | `1 (Action / Talk)` | Target Inspected is obj[8] AND Story Flag 150 (bit 4) CLEAR AND Story Flag 65 (bit 128) SET | Stage/Verify Event Party Configuration (ECInitPartySet: chara=73, slot=20); Engine Action #40; Display Dialogue Box [Bank 0, Msg #2]; Engine Action #0; Engine Action #55; Engine Action #0; ... (+17 more opcodes) |
| `ev[19]` | `1 (Action / Talk)` | Target Inspected is obj[8] AND Story Flag 150 (bit 4) SET | Stage/Verify Event Party Configuration (ECInitPartySet: chara=73, slot=20); Engine Action #40; Display Dialogue Box [Bank 0, Msg #2]; Engine Action #0; Engine Action #55; Engine Action #0; ... (+17 more opcodes) |
| `ev[20]` | `1 (Action / Talk)` | Target Inspected is obj[9] AND Engine Condition #30 AND Engine Condition #0 AND Engine Condition #1 | Engine Action #99; Display Dialogue Box [Bank 1, Msg #23]; Engine Action #0; Engine Action #53 |
| `ev[21]` | `1 (Action / Talk)` | Target Inspected is obj[9] AND Engine Condition #29 AND Engine Condition #0 AND Engine Condition #1 | Open Dialogue Sub-Window (Bank 0, Index 54) |
| `ev[22]` | `1 (Action / Talk)` | Player within Box [141..145, 69..70] | Engine Action #12; Engine Action #0; Engine Action #42; Engine Action #66 |
| `ev[23]` | `1 (Action / Talk)` | Player within Box [155..159, 69..70] | Engine Action #12; Engine Action #0; Engine Action #58; Engine Action #66 |
| `ev[24]` | `1 (Action / Talk)` | Story Flag 64 (bit 32) SET AND Story Flag 64 (bit 64) CLEAR AND Story Flag 150 (bit 4) CLEAR AND Player within Box [145..145, 31..31] | Stage/Verify Event Party Configuration (ECInitPartySet: chara=73, slot=120); Engine Action #89; Engine Action #13; Warp Room -> Submap 3 at (73,30); Engine Action #46; Engine Action #89; ... (+24 more opcodes) |
| `ev[25]` | `1 (Action / Talk)` | Story Flag 64 (bit 32) SET AND Story Flag 64 (bit 64) CLEAR AND Story Flag 150 (bit 4) SET AND Player within Box [145..145, 31..31] | Stage/Verify Event Party Configuration (ECInitPartySet: chara=73, slot=120); Engine Action #89; Engine Action #13; Warp Room -> Submap 3 at (73,30); Engine Action #46; Engine Action #89; ... (+24 more opcodes) |

---

### Submap Layer `vf03_02` (Index 2) — Marie's Inn — 1F Reception Lobby & Dining Hall

**Room Architecture & Role**: Popular capital traveler's inn founded by Marie; main reception lobby, 50-potch lodging desk, dining room, whiskey barrel storage, traveler rest benches, and guest tavern.

- **Map Number (`mapno`)**: `0` | **Battle Encounter Zone (`batlno`)**: `0`
- **Physical Entity Count (`okaz`)**: `24` Objects | **Bytecode Script Count (`evkaz`)**: `30` Scripts

#### Complete Physical Entity Inventory

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Pahn** | `165` | `(147, 39)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Inn Patron / Traveler #1** | `65072` | `(53, 148)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (9x2)** | `0` | `(49, 152)` | `8x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x3)** | `0` | `(60, 146)` | `1x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | NPC / Actor | **Marie** | `166` | `(31, 158)` | `5x5` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[05]` | NPC / Actor | **Inn Patron / Traveler #5** | `65103` | `(31, 135)` | `5x10` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[06]` | NPC / Actor | **Inn Patron / Traveler #6** | `65075` | `(34, 127)` | `5x5` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[07]` | NPC / Actor | **Inn Patron / Traveler #7** | `65177` | `(28, 125)` | `5x5` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[08]` | NPC / Actor | **Inn Patron / Traveler #8** | `64934` | `(37, 120)` | `0x0` | Up (North) | Visible (1) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[09]` | NPC / Actor | **Inn Patron / Traveler #9** | `65072` | `(64, 123)` | `5x5` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[10]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(66, 119)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(70, 161)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(72, 163)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(74, 161)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(76, 163)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[15]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(78, 161)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[16]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(75, 157)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[17]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(45, 145)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[18]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (6x2)** | `0` | `(59, 119)` | `5x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[19]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (4x2)** | `0` | `(69, 119)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[20]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (4x2)** | `0` | `(73, 119)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[21]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(77, 120)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[22]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (6x2)** | `0` | `(57, 129)` | `5x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[23]` | World Device | **Journeyman Save Crystal (Spinning)** | `0` | `(67, 21)` | `0x0` | Frame 81 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |

#### Complete Bytecode Script Catalog

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Display Dialogue Window [Msg 127]: "Welcome. Please, make yourself at home...." |
| `ev[01]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Display Dialogue Window [Msg 128]: "Are there Kobolds in the City-States, too? Re..." |
| `ev[02]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Display Dialogue Window [Msg 129]: "Good afternoon. The food is delicious here, a..." |
| `ev[03]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Display Dialogue Window [Msg 130]: "I came all the way here to see the hero of th..." |
| `ev[04]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Display Dialogue Window [Msg 131]: "What? Ya hungry?..."; Screen Fade Transition / Room Switch; Engine Action #16; Warp Room -> Submap 255 at (254,204); Engine Action #204; Engine Action #204; ... (+1 more opcodes) |
| `ev[05]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Display Dialogue Window [Msg 132]: "East of here is the sea where we get all our ..." |
| `ev[06]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Open Dialogue Sub-Window (Bank 6, Index 7) |
| `ev[07]` | `1 (Action / Talk)` | Target Inspected is obj[19] | Open Dialogue Sub-Window (Bank 6, Index 68) |
| `ev[08]` | `1 (Action / Talk)` | Target Inspected is obj[20] | Open Dialogue Sub-Window (Bank 6, Index 69) |
| `ev[09]` | `1 (Action / Talk)` | Target Inspected is obj[21] | Display Dialogue Window [Msg 243]: "☆0         Whiskey Barrel..." |
| `ev[10]` | `1 (Action / Talk)` | Target Inspected is obj[22] | Open Dialogue Sub-Window (Bank 6, Index 71) |
| `ev[11]` | `1 (Action / Talk)` | Target Inspected is obj[23] | Open Dialogue Sub-Window (Bank 6, Index 72) |
| `ev[12]` | `1 (Action / Talk)` | Target Inspected is obj[24] | Open Dialogue Sub-Window (Bank 6, Index 73) |
| `ev[13]` | `1 (Action / Talk)` | Target Inspected is obj[25] | Display Dialogue Window [Msg 247]: "☆0         Case of Room Keys..." |
| `ev[14]` | `1 (Action / Talk)` | Target Inspected is obj[26] | Display Dialogue Window [Msg 248]: "☆0     Tasty-Looking Hamburger..." |
| `ev[15]` | `1 (Action / Talk)` | Target Inspected is obj[27] | Display Dialogue Window [Msg 249]: "☆0            Simmering Pot..." |
| `ev[16]` | `1 (Action / Talk)` | Target Inspected is obj[28] | Display Dialogue Window [Msg 250]: "☆0              Unlit Stove..." |
| `ev[17]` | `1 (Action / Talk)` | Target Inspected is obj[29] | Open Dialogue Sub-Window (Bank 6, Index 78) |
| `ev[18]` | `1 (Action / Talk)` | Target Inspected is obj[30] | Display Dialogue Window [Msg 252]: "☆0       Crate Full of Foodstuff..." |
| `ev[19]` | `128 (Loop)` | Player within Box [39..65, 157..166] | Engine Action #31; Display Dialogue [Msg 128]: "Are there Kobolds in the City-States, too? Re..." |
| `ev[20]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Engine Action #96; Engine Action #15; Engine Action #9; Exit / Warp to Gregminster Exterior (vf02) at (2,5); Warp Room -> Submap 11 at (0,255) |
| `ev[21]` | `1 (Action / Talk)` | Engine Condition #9 AND Engine Condition #1 AND Target Inspected is obj[10] | Engine Action #48; Engine Action #9; Display Dialogue Box [Bank 3, Msg #0]; Exit / Warp to Gregminster Exterior (vf02) at (6,8); Engine Action #9; Engine Action #0; ... (+5 more opcodes) |
| `ev[22]` | `1 (Action / Talk)` | Engine Condition #9 AND Engine Condition #2 AND Target Inspected is obj[11] | Engine Action #48; Engine Action #9; Display Dialogue Box [Bank 2, Msg #6]; Exit / Warp to Gregminster Exterior (vf02) at (0,9); Engine Action #9; Screen Fade Transition / Room Switch; ... (+5 more opcodes) |
| `ev[23]` | `2 (Map Init)` | Story Flag 64 (bit 64) SET AND Player within Box [130..130, 73..73] AND Engine Condition #73 | Engine Action #46; Engine Action #63; Warp Room -> Submap 82 at (73,2); Exit / Warp to Gregminster Exterior (vf02) at (130,73); Exit / Warp to Gregminster Exterior (vf02) at (3,1); Warp Room -> Submap 2 at (133,70); ... (+3 more opcodes) |
| `ev[24]` | `2 (Map Init)` | Story Flag 64 (bit 64) SET AND Player within Box [54..54, 30..30] | Engine Action #46; Warp Room -> Submap 8 at (54,31); Engine Action #0; Engine Action #8; Screen Fade Transition / Room Switch; Engine Action #8; ... (+2 more opcodes) |
| `ev[25]` | `1 (Action / Talk)` | Player within Box [49..51, 166..168] | Open Shop Menu / Commercial Interface (ShopID: 3, Type: 0) |
| `ev[26]` | `1 (Action / Talk)` | Player within Box [65..69, 130..131] | Engine Action #12; Screen Fade Transition / Room Switch; Engine Action #177; Engine Action #124 |
| `ev[27]` | `1 (Action / Talk)` | Story Flag 64 (bit 64) SET AND Player within Box [130..130, 73..73] AND Engine Condition #73 | Stage/Verify Event Party Configuration (ECInitPartySet: chara=11, slot=1); Warp Room -> Submap 90 at (73,120); Engine Action #24; Warp Room -> Submap 0 at (32,73); Engine Action #120; Engine Action #24; ... (+29 more opcodes) |
| `ev[28]` | `1 (Action / Talk)` | Story Flag 64 (bit 64) SET AND Player within Box [54..54, 30..30] | Stage/Verify Event Party Configuration (ECInitPartySet: chara=11, slot=1); Warp Room -> Submap 90 at (73,20); Engine Action #24; Engine Action #8; Engine Action #0; Engine Action #37; ... (+15 more opcodes) |
| `ev[29]` | `2 (Map Init)` | Story Flag 150 (bit 4) SET | Engine Action #0; Engine Action #31 |

---

### Submap Layer `vf03_03` (Index 3) — Marie's Inn — 2F Guest Lodgings & Maid Quarters

**Room Architecture & Role**: Upper floor guest rooms of Marie's Inn; traveler sleeping quarters, maid's laundry station, and traveler rest beds.

- **Map Number (`mapno`)**: `0` | **Battle Encounter Zone (`batlno`)**: `0`
- **Physical Entity Count (`okaz`)**: `12` Objects | **Bytecode Script Count (`evkaz`)**: `20` Scripts

#### Complete Physical Entity Inventory

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Journeyman Save Crystal (Spinning)** | `0` | `(67, 21)` | `0x0` | Frame 81 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Inn Lodger / Traveler #1** | `65196` | `(150, 158)` | `5x5` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[02]` | NPC / Actor | **Sarah** | `167` | `(152, 124)` | `5x5` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[03]` | NPC / Actor | **Inn Maid (Laundry & Bedmaking)** | `65176` | `(168, 158)` | `5x5` | South (Down) | Visible (1) | Special (3) | 2 | 128 | 0 |
| `obj[04]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (4x2)** | `0` | `(173, 119)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(163, 155)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (4x2)** | `0` | `(141, 155)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (4x2)** | `0` | `(145, 119)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (4x2)** | `0` | `(145, 119)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (4x2)** | `0` | `(129, 119)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (4x2)** | `0` | `(135, 119)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(124, 157)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |

#### Complete Bytecode Script Catalog

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Display Dialogue Window [Msg 133]: "There are humans, kobolds, elves, and dwarves..." |
| `ev[01]` | `1 (Action / Talk)` | Target Inspected is obj[10] AND Story Flag 49 (bit 64) CLEAR AND Engine Condition #7 AND Engine Condition #1 | Display Dialogue Window [Msg 134]: "What? Is there something on my face?◎5∨Wait....."; Engine Action #101; Engine Action #4; Engine Action #7; Engine Action #101; Engine Action #4; ... (+5 more opcodes) |
| `ev[02]` | `1 (Action / Talk)` | Target Inspected is obj[10] AND Story Flag 49 (bit 64) CLEAR AND Engine Condition #6 AND Engine Condition #1 | Display Dialogue Window [Msg 162]: "What do you want?◎2 Oh, that thing from befor..."; Engine Action #101; Engine Action #4; Engine Action #7; Engine Action #101; Engine Action #4; ... (+5 more opcodes) |
| `ev[03]` | `1 (Action / Talk)` | Target Inspected is obj[10] AND Story Flag 49 (bit 64) SET | Display Dialogue Window [Msg 163]: "Nobody can beat me when it comes to washing c..." |
| `ev[04]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Display Dialogue Window [Msg 135]: "*yawn* The lady who runs this place sure love..." |
| `ev[05]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Display Dialogue Window [Msg 253]: "☆0               Red Roses..." |
| `ev[06]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Open Dialogue Sub-Window (Bank 6, Index 81) |
| `ev[07]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Open Dialogue Sub-Window (Bank 6, Index 82) |
| `ev[08]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Open Dialogue Sub-Window (Bank 6, Index 83) |
| `ev[09]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Open Dialogue Sub-Window (Bank 6, Index 84) |
| `ev[10]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Open Dialogue Sub-Window (Bank 6, Index 85) |
| `ev[11]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Display Dialogue Window [Msg 259]: "☆0   Sideboard with White Roses on It..." |
| `ev[12]` | `1 (Action / Talk)` | Target Inspected is obj[19] | Open Dialogue Sub-Window (Bank 6, Index 87) |
| `ev[13]` | `2 (Map Init)` | Story Flag 150 (bit 4) SET | Engine Action #0; Engine Action #8 |
| `ev[14]` | `2 (Map Init)` | Story Flag 64 (bit 64) SET AND Story Flag 150 (bit 4) CLEAR AND Player within Box [71..71, 34..34] AND Engine Condition #82 AND Engine Condition #16 AND Engine Condition #1 AND Engine Condition #125 | Engine Action #46; Engine Action #63; Warp Room -> Submap 82 at (125,2); Exit / Warp to Gregminster Exterior (vf02) at (71,33); Exit / Warp to Gregminster Exterior (vf02) at (3,1); Warp Room -> Submap 2 at (72,29); ... (+3 more opcodes) |
| `ev[15]` | `2 (Map Init)` | Story Flag 64 (bit 64) SET AND Story Flag 150 (bit 4) SET AND Player within Box [71..71, 34..34] AND Engine Condition #82 AND Engine Condition #16 AND Engine Condition #1 AND Engine Condition #172 | Engine Action #46; Engine Action #63; Warp Room -> Submap 82 at (172,2); Exit / Warp to Gregminster Exterior (vf02) at (71,33); Exit / Warp to Gregminster Exterior (vf02) at (3,1); Warp Room -> Submap 2 at (68,30); ... (+3 more opcodes) |
| `ev[16]` | `1 (Action / Talk)` | Player within Box [175..179, 128..130] | Engine Action #12; Warp Room -> Submap 67 at (140,255) |
| `ev[17]` | `1 (Action / Talk)` | Player within Box [125..129, 147..148] | Engine Action #12; Engine Action #4; Engine Action #23; Engine Action #220 |
| `ev[18]` | `1 (Action / Talk)` | Story Flag 64 (bit 64) SET AND Story Flag 150 (bit 4) CLEAR AND Player within Box [71..71, 34..34] | Stage/Verify Event Party Configuration (ECInitPartySet: chara=11, slot=1); Warp Room -> Submap 90 at (73,90); Screen Fade Transition / Room Switch; Warp Room -> Submap 2 at (73,10); Screen Fade Transition / Room Switch; Warp Room -> Submap 0 at (24,2); ... (+17 more opcodes) |
| `ev[19]` | `1 (Action / Talk)` | Story Flag 64 (bit 64) SET AND Story Flag 150 (bit 4) SET AND Player within Box [71..71, 34..34] | Stage/Verify Event Party Configuration (ECInitPartySet: chara=11, slot=1); Warp Room -> Submap 90 at (73,90); Screen Fade Transition / Room Switch; Warp Room -> Submap 3 at (73,10); Screen Fade Transition / Room Switch; Warp Room -> Submap 0 at (73,30); ... (+30 more opcodes) |

---

### Submap Layer `vf03_04` (Index 4) — Marie's Inn — 2F Storage & Linens

**Room Architecture & Role**: Back storage room for Marie's Inn; linen cabinets, spare blankets, and guest luggage storage.

- **Map Number (`mapno`)**: `0` | **Battle Encounter Zone (`batlno`)**: `0`
- **Physical Entity Count (`okaz`)**: `4` Objects | **Bytecode Script Count (`evkaz`)**: `5` Scripts

#### Complete Physical Entity Inventory

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(32, 223)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[01]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(35, 223)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(43, 215)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(43, 219)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |

#### Complete Bytecode Script Catalog

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Target Inspected is obj[8] | Open Dialogue Sub-Window (Bank 6, Index 8) |
| `ev[01]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Display Dialogue Window [Msg 261]: "☆0      Crate of Miso Bean Paste..." |
| `ev[02]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Display Dialogue Window [Msg 262]: "☆0         Empty Wine Bottles..." |
| `ev[03]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Open Dialogue Sub-Window (Bank 6, Index 90) |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [21..25, 223..224] | Engine Action #12; Screen Fade Transition / Room Switch; Engine Action #127; Engine Action #156 |

---

### Submap Layer `vf03_05` (Index 5) — Gordon's Mercantile — Wine Cellar & Storeroom

**Room Architecture & Role**: Subterranean storage vault under Gordon's trading post; imported Kanakan fine wine barrels and secure storage for high-value merchandise.

- **Map Number (`mapno`)**: `0` | **Battle Encounter Zone (`batlno`)**: `0`
- **Physical Entity Count (`okaz`)**: `4` Objects | **Bytecode Script Count (`evkaz`)**: `5` Scripts

#### Complete Physical Entity Inventory

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Gordon's Wine Cellar Guard** | `64984` | `(107, 217)` | `2x5` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[01]` | NPC / Actor | **Actor (Sprite Pattern 64772)** | `64772` | `(100, 220)` | `5x3` | South (Down) | Visible (1) | Special (3) | 4 | 128 | 0 |
| `obj[02]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (4x2)** | `0` | `(103, 209)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (4x2)** | `0` | `(107, 209)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |

#### Complete Bytecode Script Catalog

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Target Inspected is obj[8] | Display Dialogue Window [Msg 136]: "Mina, Minaaa! Where are you??? Why can't she ..." |
| `ev[01]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Display Dialogue Window [Msg 164]: "*meow*..." |
| `ev[02]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Display Dialogue Window [Msg 264]: "☆0    Cabinet of Magic Implements..." |
| `ev[03]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Display Dialogue Window [Msg 265]: "☆0    "The ABC's of Cat-Rearing"..." |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [101..103, 228..229] | Open Shop Menu / Commercial Interface (ShopID: 3, Type: 0) |

---

### Submap Layer `vf03_06` (Index 6) — Lotte's Residence — The Cat House

**Room Architecture & Role**: Residential home of Lotte and her beloved cats (Mina and Momo); cat care guidebooks ('The ABC's of Cat-Rearing'), scratching posts, and domestic furnishings.

- **Map Number (`mapno`)**: `0` | **Battle Encounter Zone (`batlno`)**: `0`
- **Physical Entity Count (`okaz`)**: `8` Objects | **Bytecode Script Count (`evkaz`)**: `9` Scripts

#### Complete Physical Entity Inventory

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Lotte (Cat Owner)** | `65088` | `(169, 214)` | `15x15` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[01]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(160, 215)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(164, 213)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(172, 209)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(177, 213)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(164, 219)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(168, 219)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(172, 219)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |

#### Complete Bytecode Script Catalog

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Target Inspected is obj[8] | Display Dialogue Window [Msg 137]: "This is the wine storage for Gordon's Mercant..." |
| `ev[01]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Open Dialogue Sub-Window (Bank 6, Index 9) |
| `ev[02]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Open Dialogue Sub-Window (Bank 6, Index 10) |
| `ev[03]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Display Dialogue Window [Msg 184]: "☆0   Barrel Full of Fine Wine from Kanakan..." |
| `ev[04]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Open Dialogue Sub-Window (Bank 6, Index 12) |
| `ev[05]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Open Dialogue Sub-Window (Bank 6, Index 13) |
| `ev[06]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Open Dialogue Sub-Window (Bank 6, Index 14) |
| `ev[07]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Open Dialogue Sub-Window (Bank 6, Index 15) |
| `ev[08]` | `1 (Action / Talk)` | Player within Box [167..169, 228..229] | Open Shop Menu / Commercial Interface (ShopID: 3, Type: 0) |

---

### Submap Layer `vf03_07` (Index 7) — Lady Sonya Shulen's Residence

**Room Architecture & Role**: Private residence of Toran Republic Naval Admiral Sonya Shulen; kept pristine by her loyal estate caretaker. Contains Sonya's private diary reflecting on the Liberation War, Teo McDohl, and the fall of Shasarazade.

- **Map Number (`mapno`)**: `1` | **Battle Encounter Zone (`batlno`)**: `0`
- **Physical Entity Count (`okaz`)**: `15` Objects | **Bytecode Script Count (`evkaz`)**: `16` Scripts

#### Complete Physical Entity Inventory

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Sonya's Estate Caretaker** | `65027` | `(39, 29)` | `5x5` | South (Down) | Visible (1) | Special (3) | 2 | 128 | 0 |
| `obj[01]` | NPC / Actor | **Actor (Sprite Pattern 65037)** | `65037` | `(25, 48)` | `10x10` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[02]` | NPC / Actor | **Actor (Sprite Pattern 65210)** | `65210` | `(39, 32)` | `5x10` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[03]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(34, 25)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (4x2)** | `0` | `(55, 25)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(25, 25)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (6x2)** | `0` | `(37, 25)` | `5x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (4x2)** | `0` | `(45, 25)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (3x2)** | `0` | `(59, 24)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(72, 31)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (4x2)** | `0` | `(37, 45)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (4x2)** | `0` | `(37, 51)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(25, 50)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(35, 50)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (4x2)** | `0` | `(51, 25)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |

#### Complete Bytecode Script Catalog

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Target Inspected is obj[8] | Display Dialogue Window [Msg 138]: "There isn't a soul in these parts who doesn't..." |
| `ev[01]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Display Dialogue Window [Msg 139]: "We never know when Lady Sonya might be back, ..." |
| `ev[02]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Display Dialogue Window [Msg 140]: "This is the home of Lady Sonya Shulen, comman..." |
| `ev[03]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Open Dialogue Sub-Window (Bank 6, Index 16) |
| `ev[04]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Display Dialogue Window [Msg 190]: "☆0          Sonya's Diary∨Returning here from..." |
| `ev[05]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Open Dialogue Sub-Window (Bank 6, Index 93) |
| `ev[06]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Display Dialogue Window [Msg 267]: "☆0       Vegetables on a Table..." |
| `ev[07]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Open Dialogue Sub-Window (Bank 6, Index 95) |
| `ev[08]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Display Dialogue Window [Msg 269]: "☆0                 Trunk..." |
| `ev[09]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Open Dialogue Sub-Window (Bank 6, Index 97) |
| `ev[10]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Open Dialogue Sub-Window (Bank 6, Index 98) |
| `ev[11]` | `1 (Action / Talk)` | Target Inspected is obj[19] | Open Dialogue Sub-Window (Bank 6, Index 99) |
| `ev[12]` | `1 (Action / Talk)` | Target Inspected is obj[20] | Open Dialogue Sub-Window (Bank 6, Index 100) |
| `ev[13]` | `1 (Action / Talk)` | Target Inspected is obj[21] | Open Dialogue Sub-Window (Bank 6, Index 101) |
| `ev[14]` | `1 (Action / Talk)` | Target Inspected is obj[22] | Open Dialogue Sub-Window (Bank 6, Index 102) |
| `ev[15]` | `1 (Action / Talk)` | Player within Box [28..31, 61..62] | Open Shop Menu / Commercial Interface (ShopID: 3, Type: 0) |

---

### Submap Layer `vf03_08` (Index 8) — Town Residence — Republican Patriot's Home

**Room Architecture & Role**: Upper-district residence of a patriotic Toran family; home to a father loyal to President Lepant and an aspiring youth training to serve the Six Great Generals.

- **Map Number (`mapno`)**: `1` | **Battle Encounter Zone (`batlno`)**: `0`
- **Physical Entity Count (`okaz`)**: `9` Objects | **Bytecode Script Count (`evkaz`)**: `10` Scripts

#### Complete Physical Entity Inventory

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Patriotic Veteran** | `65086` | `(132, 29)` | `3x8` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[01]` | NPC / Actor | **Aspiring Soldier Son** | `65069` | `(123, 49)` | `10x10` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[02]` | NPC / Actor | **Actor (Sprite Pattern 65071)** | `65071` | `(150, 30)` | `20x20` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[03]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(160, 25)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (4x2)** | `0` | `(143, 27)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (4x2)** | `0` | `(139, 29)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(133, 25)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (4x2)** | `0` | `(115, 39)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (4x2)** | `0` | `(115, 53)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |

#### Complete Bytecode Script Catalog

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Target Inspected is obj[8] | Display Dialogue Window [Msg 141]: "Heehee, doesn't this stew smell great? A pers..." |
| `ev[01]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Display Dialogue Window [Msg 142]: "President Lepant is a magnificent leader. He ..." |
| `ev[02]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Display Dialogue Window [Msg 143]: "When I grow up I'm gonna join the Republican ..." |
| `ev[03]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Display Dialogue Window [Msg 191]: "☆0            Barrel of Milk..." |
| `ev[04]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Display Dialogue Window [Msg 192]: "☆0       Tasty-Smelling Stew..." |
| `ev[05]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Open Dialogue Sub-Window (Bank 6, Index 103) |
| `ev[06]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Open Dialogue Sub-Window (Bank 6, Index 104) |
| `ev[07]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Open Dialogue Sub-Window (Bank 6, Index 105) |
| `ev[08]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Open Dialogue Sub-Window (Bank 6, Index 106) |
| `ev[09]` | `1 (Action / Talk)` | Player within Box [155..157, 45..46] | Open Shop Menu / Commercial Interface (ShopID: 3, Type: 0) |

---

### Submap Layer `vf03_09` (Index 9) — Gregminster Master Armor & Item Shop

**Room Architecture & Role**: The oldest commercial shop in Toran; retail floor for high-tier armor suits, shields, medicinal herbs, throat drops, and rare accessory displays (Winged Boots).

- **Map Number (`mapno`)**: `1` | **Battle Encounter Zone (`batlno`)**: `0`
- **Physical Entity Count (`okaz`)**: `12` Objects | **Bytecode Script Count (`evkaz`)**: `15` Scripts

#### Complete Physical Entity Inventory

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Gregminster Master Armorer** | `65072` | `(29, 100)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Gregminster Item Shopkeeper** | `65060` | `(62, 100)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (19x2)** | `0` | `(21, 105)` | `18x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (19x2)** | `0` | `(55, 105)` | `18x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | NPC / Actor | **Actor (Sprite Pattern 65074)** | `65074` | `(46, 101)` | `3x10` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[05]` | NPC / Actor | **Actor (Sprite Pattern 65226)** | `65226` | `(58, 109)` | `5x5` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[06]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (8x2)** | `0` | `(25, 97)` | `7x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x6)** | `0` | `(33, 95)` | `1x5` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(48, 99)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(56, 97)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (4x2)** | `0` | `(63, 97)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(68, 97)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |

#### Complete Bytecode Script Catalog

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Display Dialogue Window [Msg 144]: "You can find Wing Boots here sometimes... I j..." |
| `ev[01]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Display Dialogue Window [Msg 145]: "So there's a war over in the City-States? We ..." |
| `ev[02]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Open Dialogue Sub-Window (Bank 6, Index 107) |
| `ev[03]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Display Dialogue Window [Msg 281]: "☆0   Crate Packed with Medicine..." |
| `ev[04]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Open Dialogue Sub-Window (Bank 6, Index 109) |
| `ev[05]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Display Dialogue Window [Msg 283]: "☆0             Display Armor..." |
| `ev[06]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Display Dialogue Window [Msg 284]: "☆0     Crate Packed with Armor..." |
| `ev[07]` | `1 (Action / Talk)` | Target Inspected is obj[19] | Open Dialogue Sub-Window (Bank 6, Index 112) |
| `ev[08]` | `128 (Loop)` | Player within Box [21..73, 109..116] | Engine Action #31; Display Dialogue [Msg 128]: "Are there Kobolds in the City-States, too? Re..." |
| `ev[09]` | `1 (Action / Talk)` | Target Inspected is obj[10] AND Engine Condition #9 AND Engine Condition #1 | Engine Action #48; Engine Action #8; Display Dialogue Box [Bank 3, Msg #0]; Exit / Warp to Gregminster Exterior (vf02) at (6,8); Engine Action #8; Engine Action #0; ... (+8 more opcodes) |
| `ev[10]` | `1 (Action / Talk)` | Target Inspected is obj[8] | Engine Action #96; Engine Action #7; Engine Action #8; Exit / Warp to Gregminster Exterior (vf02) at (0,5); Screen Fade Transition / Room Switch; Engine Action #0; ... (+2 more opcodes) |
| `ev[11]` | `1 (Action / Talk)` | Target Inspected is obj[11] AND Engine Condition #9 AND Engine Condition #1 | Engine Action #48; Engine Action #9; Display Dialogue Box [Bank 3, Msg #0]; Exit / Warp to Gregminster Exterior (vf02) at (6,8); Engine Action #9; Engine Action #0; ... (+6 more opcodes) |
| `ev[12]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Engine Action #96; Engine Action #7; Engine Action #9; Exit / Warp to Gregminster Exterior (vf02) at (1,5); Screen Fade Transition / Room Switch; Exit / Warp to Gregminster Exterior (vf02) at (13,7) |
| `ev[13]` | `1 (Action / Talk)` | Player within Box [29..31, 117..118] | Open Shop Menu / Commercial Interface (ShopID: 3, Type: 0) |
| `ev[14]` | `1 (Action / Talk)` | Player within Box [63..65, 117..118] | Open Shop Menu / Commercial Interface (ShopID: 3, Type: 0) |

---

### Submap Layer `vf03_10` (Index 10) — Town Residence — Liberation War Migrant Family

**Room Architecture & Role**: Suburban home purchased cheaply by a newly arrived migrant family following the fall of the Scarlet Moon Empire; decorated with white rose furnishings.

- **Map Number (`mapno`)**: `1` | **Battle Encounter Zone (`batlno`)**: `0`
- **Physical Entity Count (`okaz`)**: `10` Objects | **Bytecode Script Count (`evkaz`)**: `12` Scripts

#### Complete Physical Entity Inventory

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Migrant Family Member #0** | `65082` | `(161, 108)` | `5x5` | South (Down) | Visible (1) | Special (3) | 4 | 128 | 0 |
| `obj[01]` | NPC / Actor | **Migrant Family Member #1** | `65176` | `(139, 102)` | `5x5` | South (Down) | Visible (1) | Special (3) | 2 | 128 | 0 |
| `obj[02]` | NPC / Actor | **Migrant Family Member #2** | `65211` | `(125, 102)` | `3x3` | South (Down) | Visible (1) | Special (3) | 2 | 128 | 0 |
| `obj[03]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (4x2)** | `0` | `(139, 99)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(117, 99)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (4x2)** | `0` | `(119, 97)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (6x2)** | `0` | `(123, 97)` | `5x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(153, 97)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (4x2)** | `0` | `(155, 97)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (4x2)** | `0` | `(159, 97)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |

#### Complete Bytecode Script Catalog

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Target Inspected is obj[8] | Display Dialogue Window [Msg 146]: "Hi there. We just moved here, so...let's be f..." |
| `ev[01]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Display Dialogue Window [Msg 147]: "This house has been abandoned since the Liber..." |
| `ev[02]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Display Dialogue Window [Msg 148]: "Hohohoho, I'm glad these bottles didn't break..." |
| `ev[03]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Display Dialogue Window [Msg 193]: "☆0             Filthy Crate..." |
| `ev[04]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Open Dialogue Sub-Window (Bank 6, Index 113) |
| `ev[05]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Display Dialogue Window [Msg 287]: "☆0               Unlit Stove..." |
| `ev[06]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Display Dialogue Window [Msg 288]: "☆0        Vegetables on a Table..." |
| `ev[07]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Open Dialogue Sub-Window (Bank 6, Index 116) |
| `ev[08]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Display Dialogue Window [Msg 290]: "☆0               Large Case..." |
| `ev[09]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Display Dialogue Window [Msg 291]: "☆0   Drawers Decorated with White Roses..." |
| `ev[10]` | `1 (Action / Talk)` | Player within Box [123..125, 117..118] | Open Shop Menu / Commercial Interface (ShopID: 3, Type: 0) |
| `ev[11]` | `1 (Action / Talk)` | Player within Box [157..159, 117..118] | Open Shop Menu / Commercial Interface (ShopID: 3, Type: 0) |

---

### Submap Layer `vf03_11` (Index 11) — Gregminster Rune Sage Guild Workshop

**Room Architecture & Role**: Official capital guild of Rune Sages; rune affixing tables, magic implement cabinets, crystal ball sideboards, and sales of rare elemental orbs (Titan Orbs).

- **Map Number (`mapno`)**: `1` | **Battle Encounter Zone (`batlno`)**: `0`
- **Physical Entity Count (`okaz`)**: `8` Objects | **Bytecode Script Count (`evkaz`)**: `10` Scripts

#### Complete Physical Entity Inventory

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Master Rune Sage** | `65174` | `(32, 156)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (19x2)** | `0` | `(21, 160)` | `18x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Actor (Sprite Pattern 65072)** | `65072` | `(55, 161)` | `10x10` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[03]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(29, 153)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (4x2)** | `0` | `(31, 153)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (4x2)** | `0` | `(37, 153)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (4x2)** | `0` | `(61, 153)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (4x2)** | `0` | `(65, 153)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |

#### Complete Bytecode Script Catalog

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Display Dialogue Window [Msg 149]: "Rune sages are fussy and can be a real chore ..." |
| `ev[01]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Open Dialogue Sub-Window (Bank 6, Index 119) |
| `ev[02]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Display Dialogue Window [Msg 293]: "☆0      Cabinet Full of Documents..." |
| `ev[03]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Open Dialogue Sub-Window (Bank 6, Index 121) |
| `ev[04]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Display Dialogue Window [Msg 295]: "☆0   Crystal Ball on Top of a Sideboard..." |
| `ev[05]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Open Dialogue Sub-Window (Bank 6, Index 123) |
| `ev[06]` | `128 (Loop)` | Player within Box [21..50, 165..172] | Engine Action #31; Display Dialogue [Msg 128]: "Are there Kobolds in the City-States, too? Re..." |
| `ev[07]` | `1 (Action / Talk)` | Player within Box [29..31, 173..174] | Open Shop Menu / Commercial Interface (ShopID: 3, Type: 0) |
| `ev[08]` | `1 (Action / Talk)` | Target Inspected is obj[9] AND Engine Condition #9 AND Engine Condition #1 | Engine Action #48; Engine Action #8; Display Dialogue Box [Bank 3, Msg #0]; Exit / Warp to Gregminster Exterior (vf02) at (6,8); Engine Action #8; Engine Action #0; ... (+5 more opcodes) |
| `ev[09]` | `1 (Action / Talk)` | Target Inspected is obj[8] | Engine Action #96; Engine Action #13; Engine Action #8; Exit / Warp to Gregminster Exterior (vf02) at (5,5); Warp Room -> Submap 12 at (0,255) |

---

### Submap Layer `vf03_12` (Index 12) — Town Residence — Black Market War Profiteer

**Room Architecture & Role**: Lavish residence of a merchant who amassed wealth on the black market during the Liberation War, attended by an unenthusiastic domestic servant from Seika.

- **Map Number (`mapno`)**: `1` | **Battle Encounter Zone (`batlno`)**: `0`
- **Physical Entity Count (`okaz`)**: `15` Objects | **Bytecode Script Count (`evkaz`)**: `16` Scripts

#### Complete Physical Entity Inventory

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Wealthy Black Market Merchant** | `65037` | `(161, 184)` | `5x5` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[01]` | NPC / Actor | **Domestic Servant from Seika** | `65177` | `(158, 157)` | `10x10` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[02]` | NPC / Actor | **Actor (Sprite Pattern 65226)** | `65226` | `(143, 156)` | `10x10` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[03]` | NPC / Actor | **Actor (Sprite Pattern 65042)** | `65042` | `(125, 166)` | `5x5` | South (Down) | Visible (1) | Special (3) | 4 | 128 | 0 |
| `obj[04]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (4x2)** | `0` | `(163, 155)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (4x2)** | `0` | `(119, 153)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(168, 155)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(167, 158)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (6x2)** | `0` | `(157, 153)` | `5x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (4x2)** | `0` | `(149, 153)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (4x2)** | `0` | `(145, 153)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (4x2)** | `0` | `(141, 153)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (4x2)** | `0` | `(115, 183)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (4x2)** | `0` | `(115, 189)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (4x2)** | `0` | `(131, 153)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |

#### Complete Bytecode Script Catalog

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Target Inspected is obj[8] | Display Dialogue Window [Msg 150]: "Good day. Are you a guest of my master's?..." |
| `ev[01]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Display Dialogue Window [Msg 151]: "I made a lot of money on the black market dur..." |
| `ev[02]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Display Dialogue Window [Msg 152]: "Isn't this house wonderful? We're so happy, h..." |
| `ev[03]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Display Dialogue Window [Msg 153]: "I think I preferred our quiet house back in S..." |
| `ev[04]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Display Dialogue Window [Msg 194]: "☆0            Bubbling Pot..." |
| `ev[05]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Open Dialogue Sub-Window (Bank 6, Index 22) |
| `ev[06]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Display Dialogue Window [Msg 297]: "☆0          Bucket for Cleaning..." |
| `ev[07]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Display Dialogue Window [Msg 298]: "☆0           Stacked Firewood..." |
| `ev[08]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Open Dialogue Sub-Window (Bank 6, Index 126) |
| `ev[09]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Open Dialogue Sub-Window (Bank 6, Index 127) |
| `ev[10]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Open Dialogue Sub-Window (Bank 6, Index 128) |
| `ev[11]` | `1 (Action / Talk)` | Target Inspected is obj[19] | Open Dialogue Sub-Window (Bank 6, Index 129) |
| `ev[12]` | `1 (Action / Talk)` | Target Inspected is obj[20] | Open Dialogue Sub-Window (Bank 6, Index 130) |
| `ev[13]` | `1 (Action / Talk)` | Target Inspected is obj[21] | Open Dialogue Sub-Window (Bank 6, Index 131) |
| `ev[14]` | `1 (Action / Talk)` | Target Inspected is obj[22] | Open Dialogue Sub-Window (Bank 6, Index 132) |
| `ev[15]` | `1 (Action / Talk)` | Player within Box [141..143, 167..168] | Open Shop Menu / Commercial Interface (ShopID: 3, Type: 0) |

---

### Submap Layer `vf03_13` (Index 13) — Gordon's Mercantile — Trading Post & Antique Valuation

**Room Architecture & Role**: Main appraisal and trading floor operated by Gordon; valuation counter for rare antiques (defective urns, celadon vases), ancient texts, and commodity barrels (red pepper, soy sauce, green peppers). Prime recruitment hub for Gordon.

- **Map Number (`mapno`)**: `1` | **Battle Encounter Zone (`batlno`)**: `0`
- **Physical Entity Count (`okaz`)**: `14` Objects | **Bytecode Script Count (`evkaz`)**: `21` Scripts

#### Complete Physical Entity Inventory

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Gordon (Appraiser & Trade Post Operator)** | `106` | `(46, 213)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Gordon's Mercantile Trade Clerk #1** | `65089` | `(46, 213)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Gordon's Mercantile Trade Clerk #2** | `65090` | `(61, 214)` | `5x5` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[03]` | NPC / Actor | **Gordon's Mercantile Trade Clerk #3** | `65072` | `(64, 210)` | `4x4` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[04]` | NPC / Actor | **Actor (Sprite Pattern 65088)** | `65088` | `(23, 220)` | `5x5` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[05]` | NPC / Actor | **Actor (Sprite Pattern 65226)** | `65226` | `(59, 216)` | `5x5` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[06]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(28, 219)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(72, 211)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (2x2)** | `0` | `(70, 207)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (3x3)** | `0` | `(29, 210)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (3x3)** | `0` | `(29, 213)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (3x3)** | `0` | `(31, 220)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (4x2)** | `0` | `(21, 213)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | Trigger / Hitbox | **Doorway Warp / Room Boundary (6x2)** | `0` | `(21, 209)` | `5x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |

#### Complete Bytecode Script Catalog

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Display Dialogue Window [Msg 154]: "We sometimes have sales on ancient texts here..." |
| `ev[01]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Display Dialogue Window [Msg 155]: "Welcome. How about some traditional clothing?..." |
| `ev[02]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Display Dialogue Window [Msg 156]: "Antiques are quite pricey here in Gregminster..." |
| `ev[03]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Display Dialogue Window [Msg 157]: "Hmm, if you ask me, I'd go for wine. Cheap, d..." |
| `ev[04]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Display Dialogue Window [Msg 196]: "☆0   Barrel Packed with Red Pepper..." |
| `ev[05]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Display Dialogue Window [Msg 197]: "☆0        Barrel of Soy Sauce..." |
| `ev[06]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Open Dialogue Sub-Window (Bank 6, Index 25) |
| `ev[07]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Display Dialogue Window [Msg 199]: "☆0           Red Peppers         Sure smells ..." |
| `ev[08]` | `1 (Action / Talk)` | Target Inspected is obj[18] AND Engine Condition #40 AND Engine Condition #0 AND Engine Condition #12 | Open Dialogue Sub-Window (Bank 6, Index 40) |
| `ev[09]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Display Dialogue Window [Msg 200]: "☆0           Red Peppers..." |
| `ev[10]` | `1 (Action / Talk)` | Target Inspected is obj[19] | Display Dialogue Window [Msg 201]: "☆0          Green Peppers..." |
| `ev[11]` | `1 (Action / Talk)` | Target Inspected is obj[20] | Display Dialogue Window [Msg 306]: "☆0      Crate Full of Trade Goods..." |
| `ev[12]` | `1 (Action / Talk)` | Target Inspected is obj[21] | Open Dialogue Sub-Window (Bank 6, Index 134) |
| `ev[13]` | `128 (Loop)` | Player within Box [37..55, 216..226] | Engine Action #31; Display Dialogue [Msg 128]: "Are there Kobolds in the City-States, too? Re..." |
| `ev[14]` | `2 (Map Init)` | Engine Condition #24 AND Engine Condition #106 AND Engine Condition #2 | Engine Action #0; Engine Action #8 |
| `ev[15]` | `2 (Map Init)` | Engine Condition #23 AND Engine Condition #106 AND Engine Condition #2 | Engine Action #0; Engine Action #9 |
| `ev[16]` | `1 (Action / Talk)` | Story Flag 68 (bit 2) CLEAR AND Engine Condition #24 AND Engine Condition #106 AND Engine Condition #2 AND Target Inspected is obj[8] | Stage/Verify Event Party Configuration (ECInitPartySet: chara=84, slot=106); Engine Action #30; Engine Action #111; Engine Action #41; Engine Action #5; Engine Action #7; ... (+4 more opcodes) |
| `ev[17]` | `1 (Action / Talk)` | Story Flag 68 (bit 2) SET AND Engine Condition #24 AND Engine Condition #106 AND Engine Condition #2 AND Engine Condition #37 AND Player within Box [9..13, 19..5] | Stage/Verify Event Party Configuration (ECInitPartySet: chara=30, slot=1); Engine Action #0; Engine Action #96; Engine Action #31; Engine Action #8; Engine Action #240; ... (+4 more opcodes) |
| `ev[18]` | `1 (Action / Talk)` | Story Flag 68 (bit 2) SET AND Engine Condition #24 AND Engine Condition #106 AND Engine Condition #2 AND Engine Condition #37 AND Engine Condition #0 AND Engine Condition #9 AND Engine Condition #13 AND Engine Condition #53 AND Engine Condition #19 AND Target Inspected is obj[8] | Stage/Verify Event Party Configuration (ECInitPartySet: chara=23, slot=3); Engine Action #34; Engine Action #84; Engine Action #106; Engine Action #31; Engine Action #73; ... (+111 more opcodes) |
| `ev[19]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Engine Action #96; Engine Action #31; Engine Action #9; Engine Action #240; Engine Action #240; Screen Fade Transition / Room Switch; ... (+2 more opcodes) |
| `ev[20]` | `1 (Action / Talk)` | Player within Box [45..47, 227..228] | Open Shop Menu / Commercial Interface (ShopID: 3, Type: 0) |

---
