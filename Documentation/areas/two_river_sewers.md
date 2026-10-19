# Suikoden II Geographic Area Catalog: Two River Subterranean Sewers

**Geographic Scope & Role**: Dark underground aqueducts; slimy brick waterways, iron sluice gates, and the Pestilence monster nest.

**Regional Category**: Region `VH` | **Master Maps Included**: `vh04`

**Grounding Reference**: Compiled from `suikoden_2_map_ids_and_areas_breakdown.md` and direct bytecode inspection of all corresponding assets in `D:\Modding\suikodum\Mobobehaviour`.

---

## 📖 Human-Readable Field & Engine Legend

| Field / Concept | Engine Term | Human Meaning & Allowed Values |
|---|---|---|
| **Class (`otyp`)** | Object Type | **1** = NPC / Actor (living characters)<br>**2** = Prop / Scenery (wells, buckets, bonsai, tables, chairs)<br>**3** = World Device (Journeyman save crystals, chests, inn beds, fire)<br>**4** = Trigger / Hitbox (invisible door warps, counter barriers, single-tile dots) |
| **Collision (`ozok`)** | Obstacle Mask | **0** = Passable (walk-through, floor warps, rugs)<br>**2** = Solid Obstacle (impassable physical barrier you bump into)<br>**3** = Special Barrier (counters, low tables, railings you can interact over) |
| **Facing (`ano`)** | Animation / State | For NPCs: **0** = Down (South), **1** = Left (West), **2** = Up (North), **3** = Right (East)<br>For Devices: **2** = Closed Chest, **3** = Open Chest, **14/25/53+** = Spinning Save Crystal, **12/26** = Inn Rest Bed |
| **Display (`disp`)** | Visibility State | **1** = Active & Rendered on screen<br>**0** = Dormant / Hidden (waiting for story flags to spawn) |
| **Coords (`x, y`)** | Tile Grid Position | Exact tile coordinate on the map layout (`(0, 0)` is top-left) |
| **Size (`w, h`)** | Trigger Dimensions | `0x0` = 1 single 1x1 tile ("A Dot"). `4x1` = Bounding box 5 tiles wide by 2 tiles tall |
| **Speed (`spd`)** | Movement Rate | **0** = Immobile fixture; **4** = Standard walking; **5–8** = Running |
| **Wait (`wt`)** | Wander Timer | **255** = Stationary (fixed orientation); **0–254** = Idle ticks before wandering |
| **Priority (`pri`)** | Z-Order Layer | **0** = Standard ground layer; **40–180** = Elevated/floating (save crystals, chandeliers) |
| **Mode (`etyp`)** | Trigger Mode | **1 (Action / Talk)** = Fired when standing adjacent/inside and pressing Confirm button<br>**2 (Map Init)** = Fired once immediately upon loading the room before fade-in<br>**3 (Step-On Tripwire)** = Fired the instant player steps onto the tile<br>**4 (Loop)** = Continuous per-frame background script |
| **`eventForm`** | Preconditions | Conditions that MUST be true for the script to execute (Story flags, items, party members, position) |
| **`eventCom`** | Action Sequence | The actual actions executed when triggered (dialogue, warps, healing, shops, loot, spawns) |

---

## Location Map: `vh04`

- **Master Map Container**: `vh04.json`
- **Submap Layer Files**: vh04_00.json, vh04_01.json, vh04_02.json
- **Collision Grid Files**: vh04_map_01.json, vh04_map_03.json, vh04_map_04.json, vh04_map_07.json
- **Sprite Animation Bundles**: vh04_00_obj.json
- **Submap Room Count**: 13

### Submap Layer `vh04_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `2` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (2 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [24..24, 2..5] AND Temp Event Flag #9 SET AND Player X within Range [255..254] | Close Dialogue Window; Warp Town -> Area 2 Map 40 Submap 69 at (1,61); Open Dialogue Message Window; Open Dialogue Message Window; Warp Map Transition (2, 1, 42, 189, 255) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [24..24, 2..36] AND Condition Check #37 AND Story Flag 0 (mask 255) SET | Close Dialogue Window; Warp Town -> Area 2 Map 40 Submap 69 at (1,61); Open Dialogue Message Window; Open Dialogue Message Window; Display Dialogue Box [Bank: 1, MsgID: 30]; Display Emotion Bubble (255, 254) |

---

### Submap Layer `vh04_01` (Index 1)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `50`, Rate: `4`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `3` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (3 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Player within Box [30..30, 2..30] AND Condition Check #30 | Animate Door obj[7] (State: 3); Warp Room -> Submap 32 at (255,254) facing 204 |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [29..31, 2..25] AND Condition Check #26 AND Story Flag 1 (mask 255) SET | Close Dialogue Window; Warp Town -> Area 2 Map 40 Submap 101 at (9,9); Set Object Direction (0, 1); Remove Item from Inventory (117, 1); Warp Room -> Submap 1 at (7,4) facing 69; Warp to Castle HQ (32, 2, 1); Remove Item from Inventory (187, 255) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [58..60, 2..31] AND Condition Check #33 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 30]; Display Chapter Text (255) |

---

### Submap Layer `vh04_02` (Index 2)

- **Map Number (`mapno`)**: `2`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `50`, Rate: `4`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `3` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (3 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `128 (Loop)` | Player within Box [61..63, 2..24] AND Condition Check #36 | Warp Room -> Submap 1 at (7,4) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [26..29, 2..28] AND Condition Check #29 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 58]; Warp Map Transition (255, 254, 204, 204, 204) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [66..70, 2..51] AND Condition Check #52 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 3, MsgID: 26]; Display Chapter Text (255) |

---

### Submap Layer `vh04_03` (Index 3)

- **Map Number (`mapno`)**: `3`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `50`, Rate: `4`)
- **Entity Count (`okaz`)**: `4` Objects | **Script Count (`evkaz`)**: `8` Scripts

#### Complete Physical Entity Inventory (4 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 0)** | `0` | `(37, 28)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 1)** | `0` | `(37, 28)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | World Device | **Mechanism (ano 0)** | `0` | `(104, 44)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | World Device | **Mechanism (ano 1)** | `0` | `(104, 44)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(37, 28)` with state parameter `0`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(37, 28)` with state parameter `1`.
- **`obj[02]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(104, 44)` with state parameter `0`.
- **`obj[03]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(104, 44)` with state parameter `1`.


#### Complete Bytecode Script Catalog (8 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Treasure Byte 17 Bit 64 FRESH (Unopened) | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[01]` | `2 (Map Init)` | Treasure Byte 17 Bit 64 LOOTED | Open Dialogue Message Window; Engine Action #9 |
| `ev[02]` | `2 (Map Init)` | Treasure Byte 17 Bit 128 FRESH (Unopened) | Open Dialogue Message Window; Screen Fade Transition (255, 254, 204) |
| `ev[03]` | `2 (Map Init)` | Treasure Byte 17 Bit 128 LOOTED | Open Dialogue Message Window; Close Dialogue Window |
| `ev[04]` | `1 (Action / Talk)` | Treasure Byte 17 Bit 64 FRESH (Unopened) AND Target Inspected is obj[8] | Make obj[1] Hidden (disp = 0); Reset Camera Tracking (0); Engine Action #9; Teleport obj[101] to (4,7); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (2); Exit to World Map (0, 7, 16); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,17) facing 64; Warp Room -> Submap 1 at (9,0) facing 8; Teleport obj[255] to (254,255) |
| `ev[05]` | `1 (Action / Talk)` | Treasure Byte 17 Bit 128 FRESH (Unopened) AND Target Inspected is obj[10] | Make obj[1] Hidden (disp = 0); Screen Fade Transition (0, 11, 47); Jump to Bytecode Offset (4, 7); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (2); Exit to World Map (0, 12, 32); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,17) facing 128; Warp Room -> Submap 1 at (11,0) facing 10; Teleport obj[255] to (254,255) |
| `ev[06]` | `1 (Action / Talk)` | Player within Box [25..27, 2..24] AND Condition Check #25 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 68]; Teleport obj[255] to (254,204) |
| `ev[07]` | `1 (Action / Talk)` | Player within Box [66..75, 2..102] AND Condition Check #105 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 4, MsgID: 78]; Screen Fade Transition (255, 254, 204) |

---

### Submap Layer `vh04_04` (Index 4)

- **Map Number (`mapno`)**: `4`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `50`, Rate: `4`)
- **Entity Count (`okaz`)**: `1` Objects | **Script Count (`evkaz`)**: `8` Scripts

#### Complete Physical Entity Inventory (1 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(90, 47)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(90, 47)` to `(92, 48)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (8 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [74..84, 2..5] AND Inventory Holds Item #9 AND Player X within Range [255..254] | Display Dialogue Box [Bank: 3, MsgID: 70]; Clear Chest Looted Flag (255, 254) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [114..122, 2..66] AND Condition Check #67 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 5, MsgID: 74]; Screen Fade Transition (255, 254, 204) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [22..29, 2..66] AND Condition Check #67 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 6, MsgID: 26]; Reset Camera Tracking (255) |
| `ev[03]` | `1 (Action / Talk)` | Target Inspected is obj[8] | Engine Action #99; Screen Fade Transition (1, 26, 3); Exit to World Map (73, 20, 40); Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 3 Map 2 Submap 3 at (3,73); Branch on Choice (41, 2); Open Dialogue Message Window; Warp Room -> Submap 0 at (127,0) facing 10; Warp Room -> Submap 1 at (1,255) facing 254; Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[04]` | `128 (Loop)` | Condition Check #29 AND Story Flag 1 (mask 255) CLEAR | Warp Room -> Submap 1 at (13,45); Mark NPC Talk Interaction Complete (Flag #10); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[05]` | `1 (Action / Talk)` | Player within Box [37..39, 2..29] AND Condition Check #30 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 7, MsgID: 28]; Engine Action #53 |
| `ev[06]` | `1 (Action / Talk)` | Story Flag 182 (bit 2) CLEAR AND Player within Box [73..75, 2..45] AND Condition Check #46 AND Story Flag 1 (mask 255) SET | Wait for Audio / Window Sync (2); Display Dialogue Box [Bank: 8, MsgID: 32]; Teleport Object to Coordinates (255, 254, 204) |
| `ev[07]` | `1 (Action / Talk)` | Story Flag 182 (bit 2) SET AND Player within Box [73..75, 2..45] AND Condition Check #46 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 12, MsgID: 32]; Teleport Object to Coordinates (255, 254, 204) |

---

### Submap Layer `vh04_05` (Index 5)

- **Map Number (`mapno`)**: `5`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `50`, Rate: `4`)
- **Entity Count (`okaz`)**: `4` Objects | **Script Count (`evkaz`)**: `6` Scripts

#### Complete Physical Entity Inventory (4 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | Prop / Scenery | **Prop ID 64964** | `64964` | `(20, 28)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | Prop / Scenery | **Prop ID 64964** | `64964` | `(20, 28)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | World Device | **Mechanism (ano 0)** | `0` | `(33, 57)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | World Device | **Mechanism (ano 1)** | `0` | `(33, 57)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Prop: Object 64964)**: Environmental world dressing prop placed at tile `(20, 28)`. Solid collision is set to `2`.
- **`obj[01]` (Prop: Object 64964)**: Environmental world dressing prop placed at tile `(20, 28)`. Solid collision is set to `2`.
- **`obj[02]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(33, 57)` with state parameter `0`.
- **`obj[03]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(33, 57)` with state parameter `1`.


#### Complete Bytecode Script Catalog (6 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [70..78, 2..3] AND Inventory Holds Item #9 AND Player X within Range [255..254] | Display Dialogue Box [Bank: 4, MsgID: 118]; Engine Action #62 |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [0..1, 2..19] AND Treasure Byte 9 Bit 2 FRESH (Unopened) | Display Dialogue Box [Bank: 6, MsgID: 120]; Engine Action #62 |
| `ev[02]` | `2 (Map Init)` | Treasure Byte 18 Bit 4 FRESH (Unopened) | Open Dialogue Message Window; Screen Fade Transition (255, 254, 204) |
| `ev[03]` | `2 (Map Init)` | Treasure Byte 18 Bit 4 LOOTED | Open Dialogue Message Window; Close Dialogue Window |
| `ev[04]` | `1 (Action / Talk)` | Treasure Byte 18 Bit 4 FRESH (Unopened) AND Target Inspected is obj[10] | Make obj[1] Hidden (disp = 0); Screen Fade Transition (0, 11, 47); Jump to Bytecode Offset (4, 7); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (2); Exit to World Map (0, 13, 0); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,18) facing 4; Warp Room -> Submap 1 at (11,0) facing 10; Teleport obj[255] to (254,255) |
| `ev[05]` | `1 (Action / Talk)` | Story Flag 67 (bit 1) SET AND Story Flag 67 (bit 2) CLEAR AND Player within Box [27..29, 2..45] AND Condition Check #48 AND Star of Destiny #1 Recruited AND Temp Event Flag #255 SET | Make obj[0] Hidden (disp = 0); Reset Camera Tracking (89); Reset Camera Tracking (2); Open Dialogue Message Window; Engine Action #89; Reset Camera Tracking (3); Teleport obj[76] to (1,10); Warp Town -> Area 8 Map 5 Submap 73 at (20,89); Reset Camera Tracking (4); Set Combat Battle BGM (14); Jump to Bytecode Offset (0, 177); Engine Action #89; Reset Camera Tracking (5); Engine Action #89; Reset Camera Tracking (5); Set Combat Battle BGM (45); Make obj[0] Hidden (disp = 0); Engine Action #9; Engine Action #89; Engine Action #9; Warp Town -> Area 1 Map 47 Submap 73 at (20,76); Open Dialogue Message Window; Screen Fade Transition (3, 8, 5); Warp Room -> Submap 33 at (1,7) facing South (Down); Warp Room -> Submap 0 at (2,5) facing West (Left); Exit to World Map (5, 2, 3); Warp to Castle HQ (0, 6, 1); Exit to World Map (4, 30, 24); Warp Room -> Submap 0 at (73,20) facing 40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 1 Map 1 Submap 1 at (2,76); Warp Room -> Submap 2 at (8,5) facing 4; Warp Room -> Submap 34 at (8,3) facing South (Down); Warp Room -> Submap 1 at (2,0) facing 5; Show Dialogue Portrait (1, 0, 5); Show Dialogue Portrait (3, 0, 5); Show Dialogue Portrait (1, 0, 30); Close Dialogue Sub-Window (1); Warp Room -> Submap 72 at (1,1) facing Up (North); Engine Action #5; Warp Room -> Submap 0 at (6,2) facing 30; Close Dialogue Sub-Window (1); Warp Room -> Submap 72 at (0,1) facing 5; Warp Room -> Submap 1 at (1,4) facing 30; Warp Room -> Submap 73 at (60,5) facing West (Left); Warp to Castle HQ (0, 5, 5); Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (73); Trigger Character Emotion Effect (24, 1); Warp Room -> Submap 29 at (5,43) facing West (Left); Engine Action #5; Turn obj[1] facing South (Down); Warp to Castle HQ (0, 1, 0); Engine Action #9; Warp Room -> Submap 9 at (67,2) facing 255 |

---

### Submap Layer `vh04_06` (Index 6)

- **Map Number (`mapno`)**: `6`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `50`, Rate: `4`)
- **Entity Count (`okaz`)**: `4` Objects | **Script Count (`evkaz`)**: `8` Scripts

#### Complete Physical Entity Inventory (4 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 0)** | `0` | `(50, 24)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 1)** | `0` | `(50, 24)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | World Device | **Mechanism (ano 0)** | `0` | `(50, 34)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | World Device | **Mechanism (ano 1)** | `0` | `(50, 34)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(50, 24)` with state parameter `0`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(50, 24)` with state parameter `1`.
- **`obj[02]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(50, 34)` with state parameter `0`.
- **`obj[03]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(50, 34)` with state parameter `1`.


#### Complete Bytecode Script Catalog (8 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Treasure Byte 18 Bit 1 FRESH (Unopened) | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[01]` | `2 (Map Init)` | Treasure Byte 18 Bit 1 LOOTED | Open Dialogue Message Window; Engine Action #9 |
| `ev[02]` | `2 (Map Init)` | Treasure Byte 18 Bit 2 FRESH (Unopened) | Open Dialogue Message Window; Screen Fade Transition (255, 254, 204) |
| `ev[03]` | `2 (Map Init)` | Treasure Byte 18 Bit 2 LOOTED | Open Dialogue Message Window; Close Dialogue Window |
| `ev[04]` | `1 (Action / Talk)` | Treasure Byte 18 Bit 1 FRESH (Unopened) AND Target Inspected is obj[8] | Make obj[1] Hidden (disp = 0); Reset Camera Tracking (0); Engine Action #9; Teleport obj[101] to (4,7); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (2); Exit to World Map (0, 69, 16); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,18) facing West (Left); Warp Room -> Submap 1 at (9,0) facing 8; Teleport obj[255] to (254,255) |
| `ev[05]` | `1 (Action / Talk)` | Treasure Byte 18 Bit 2 FRESH (Unopened) AND Target Inspected is obj[10] | Make obj[1] Hidden (disp = 0); Screen Fade Transition (0, 11, 47); Jump to Bytecode Offset (4, 7); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (2); Exit to World Map (0, 23, 0); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,18) facing Up (North); Warp Room -> Submap 1 at (11,0) facing 10; Teleport obj[255] to (254,255) |
| `ev[06]` | `1 (Action / Talk)` | Player within Box [122..125, 2..59] AND Condition Check #68 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 5, MsgID: 3]; Set Story Flag (255, 254) |
| `ev[07]` | `1 (Action / Talk)` | Player within Box [23..28, 2..3] AND Target Inspected is obj[9] AND Player X within Range [255..254] | Display Dialogue Box [Bank: 4, MsgID: 26]; Engine Action #62 |

---

### Submap Layer `vh04_07` (Index 7)

- **Map Number (`mapno`)**: `7`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `1` Objects | **Script Count (`evkaz`)**: `5` Scripts

#### Complete Physical Entity Inventory (1 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Adlai** | `56` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Adlai)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.


#### Complete Bytecode Script Catalog (5 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [26..30, 2..57] AND Condition Check #58 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 4, MsgID: 38]; Warp Room -> Submap 255 at (254,204) |
| `ev[01]` | `2 (Map Init)` | Story Flag 151 (bit 64) CLEAR AND Story Flag 217 (bit 64) CLEAR AND Star of Destiny #0 Recruited AND Condition Check #54 | Make obj[2] Hidden (disp = 0); Reset Camera Tracking (28); Warp Map Transition (3, 8, 0, 0, 8); Teleport obj[255] to (254,204) |
| `ev[02]` | `1 (Action / Talk)` | Story Flag 151 (bit 64) CLEAR AND Story Flag 217 (bit 64) CLEAR AND Star of Destiny #0 Recruited AND Condition Check #54 AND Player within Box [23..33, 2..42] AND Condition Check #43 AND Story Flag 1 (mask 255) SET | Dismiss Character to Castle Base (56); Dismiss Emotion Bubble (56); Open Dialogue Message Window; Reset Camera Tracking (3); Open Dialogue Message Window; Open Dialogue Message Window; Exit to World Map (8, 3, 0); Warp Room -> Submap 8 at (2,11) facing 49; Warp Town -> Area 5 Map 8 Submap 4 at (2,0); Engine Action #5; Exit to World Map (3, 0, 15); Dismiss Emotion Bubble (255); Engine Action #5; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (4, 2, 1); Open Dialogue Message Window; Pan Camera (5, 4, 3); Pan Camera (16, 30, 255); Walk obj[12] to (4,38); Warp Room -> Submap 255 at (254,204) |
| `ev[03]` | `1 (Action / Talk)` | Story Flag 151 (bit 64) CLEAR AND Story Flag 217 (bit 64) CLEAR AND Star of Destiny #1 Recruited AND Condition Check #54 AND Condition Check #33 AND Player Y within Range [1..1] AND Condition Check #23 AND Condition Check #33 AND Player Y within Range [42..43] AND Story Flag 1 (mask 7) SET AND Condition Check #128 | Exit to World Map (0, 31, 35); Engine Action #9; Warp to Castle HQ (0, 1, 33); Warp Room -> Submap 0 at (1,5) facing West (Left); Exit to World Map (5, 3, 3); Warp Room -> Submap 30 at (73,30) facing 24; Warp Room -> Submap 12 at (73,30) facing 39; Return Warp to Castle Base (36, 128) |
| `ev[04]` | `1 (Action / Talk)` | Story Flag 151 (bit 64) CLEAR AND Story Flag 217 (bit 64) CLEAR AND Star of Destiny #1 Recruited AND Condition Check #54 AND Condition Check #33 AND Player within Box [2..1, 23..33] AND Player Y within Range [42..43] AND Story Flag 1 (mask 7) SET AND Condition Check #128 | Dismiss Character to Castle Base (56); Dismiss Emotion Bubble (4); Open Dialogue Message Window; Warp Room -> Submap 35 at (9,3); Open Dialogue Message Window; Warp to Castle HQ (33, 1, 54); Open Dialogue Message Window; Warp Room -> Submap 1 at (4,5) facing West (Left); Warp to Castle HQ (3, 0, 30); Set Combat Battle BGM (30); Close Dialogue Sub-Window (1); Warp Town -> Area 13 Map 11 Submap 2 at (23,40); Make obj[2] Hidden (disp = 0); Reset Camera Tracking (27); Warp Map Transition (3, 8, 3, 0, 8); Teleport obj[73] to (60,24); Reset Camera Tracking (2); Animate Door Open; Close Dialogue Sub-Window (1); Warp Town -> Area 15 Map 72 Submap 1 at (1,9); Close Dialogue Window; Warp Room -> Submap 40 at (73,15) facing East (Right); Open Dialogue Message Window; Warp Room -> Submap 1 at (1,0) facing 5; Engine Action #5; Warp to Castle HQ (0, 5, 5); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp to Castle HQ (0, 5, 5); Warp Room -> Submap 5 at (5,3) facing South (Down); Engine Action #5; Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp to Castle HQ (0, 30, 24); Reset Camera Tracking (2); Dismiss Dialogue Portrait; Load Sound Bank into Memory (0, 1); Load Sound Bank into Memory (1, 1); Warp Town -> Area 5 Map 1 Submap 0 at (0,2); Open Dialogue Message Window; Engine Action #6; Warp Town -> Area 4 Map 6 Submap 7 at (5,30); Close Dialogue Sub-Window (1); Warp Town -> Area 17 Map 72 Submap 0 at (1,24); Reset Camera Tracking (2); Display Speaker Name Box (5); Reset Camera Tracking (4); Warp Town -> Area 3 Map 1 Submap 30 at (5,1); Warp Town -> Area 0 Map 5 Submap 4 at (1,0); Engine Action #5; Exit to World Map (2, 0, 5); Exit to World Map (0, 0, 5); Exit to World Map (2, 0, 30); Close Dialogue Sub-Window (1); Warp Town -> Area 19 Map 73 Submap 30 at (24,8); Warp Town -> Area 20 Map 72 Submap 1 at (1,9); Engine Action #5; Warp Room -> Submap 0 at (6,1) facing Up (North); Open Dialogue Message Window; Engine Action #5; Warp to Castle HQ (1, 0, 5); Warp to Castle HQ (2, 0, 6); Warp Room -> Submap 0 at (5,3) facing West (Left); Open Dialogue Message Window; Engine Action #6; Warp Room -> Submap 3 at (2,0) facing 5; Warp to Castle HQ (0, 0, 5); Warp to Castle HQ (2, 0, 30); Close Dialogue Sub-Window (1); Warp Town -> Area 21 Map 72 Submap 0 at (1,73); Trigger Character Emotion Effect (24, 8); Warp Town -> Area 22 Map 3 Submap 1 at (0,24); Warp Room -> Submap 23 at (3,0) facing East (Right); Set Combat Battle BGM (20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 2 Map 24 Submap 2 at (25,73); Branch on Choice (48, 8); Open Dialogue Message Window; Warp to Castle HQ (0, 1, 3); Reset Camera Tracking (46); Warp to Castle HQ (0, 1, 3); Reset Camera Tracking (0); Teleport obj[73] to (30,24); Reset Camera Tracking (2); Fade In from Black (5); Warp Room -> Submap 4 at (2,2) facing 30; Close Dialogue Sub-Window (1); Warp Town -> Area 27 Map 3 Submap 8 at (3,73); Screen Fade Transition (24, 8, 2); Display Chapter Text (72); Warp Room -> Submap 11 at (5,1) facing Up (North); Open Dialogue Message Window; Engine Action #6; Warp Room -> Submap 72 at (0,1) facing 24; Warp Room -> Submap 29 at (73,10) facing 24; Reset Camera Tracking (2); Dismiss Emotion Bubble (73); Branch on Choice (72, 1); Warp Room -> Submap 24 at (1,2) facing 31; Load Sound Bank into Memory (0, 1); Set Combat Battle BGM (10); Close Dialogue Sub-Window (8); Warp Town -> Area 32 Map 5 Submap 1 at (2,0); Engine Action #6; Warp Room -> Submap 0 at (5,5) facing East (Right); Open Dialogue Message Window; Dismiss Emotion Bubble (73); Engine Action #40; Warp to Castle HQ (8, 0, 73); Engine Action #40; Warp to Castle HQ (8, 3, 73); Branch on Choice (24, 8); Warp Town -> Area 34 Map 5 Submap 1 at (0,0); Engine Action #5; Engine Action #5; Warp Town -> Area 0 Map 30 Submap 24 at (1,2); Start Boss Battle #49 (BGM: 2); Engine Action #5; Reset Camera Tracking (3); Warp Room -> Submap 255 at (254,5) facing West (Left); Engine Action #5; Warp to Castle HQ (2, 0, 7); Warp Room -> Submap 255 at (254,50) facing 24; Reset Camera Tracking (2); Launch Tactical War Battle (72); Warp Room -> Submap 9 at (5,1) facing Up (North); Open Dialogue Message Window; Engine Action #6; Warp Room -> Submap 24 at (1,2) facing 37; Load Sound Bank into Memory (0, 1); Set Combat Battle BGM (60); Close Dialogue Sub-Window (8); Warp Town -> Area 38 Map 72 Submap 1 at (1,2); Close Dialogue Sub-Window (1); Warp Town -> Area 39 Map 72 Submap 0 at (1,73); Branch on Choice (24, 8); Warp Town -> Area 40 Map 72 Submap 1 at (1,7); Close Dialogue Sub-Window (1); Warp Town -> Area 41 Map 24 Submap 8 at (2,42); Load Sound Bank into Memory (0, 1); Engine Action #5; Warp Room -> Submap 0 at (7,1) facing 30; Close Dialogue Sub-Window (1); Warp Town -> Area 43 Map 48 Submap 8 at (0,3); Open Dialogue Message Window; Warp Room -> Submap 8 at (3,8) facing South (Down); Warp to Castle HQ (0, 1, 24); Reset Camera Tracking (2); Engine Action #44; Engine Action #115; Set Animation Pose (28, 84); Set Animation Pose (31, 5); Open Dialogue Message Window; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 101, 4); Engine Action #6; Engine Action #5; Open Dialogue Message Window; Warp Town -> Area 0 Map 5 Submap 3 at (1,0); Engine Action #5; Warp to Castle HQ (3, 0, 5); Warp to Castle HQ (0, 0, 5); Warp to Castle HQ (30, 89, 0); Warp Town -> Area 8 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Engine Action #89; Open Dialogue Message Window; Warp Town -> Area 9 Map 5 Submap 0 at (6,2); Dismiss Emotion Bubble (89); Open Dialogue Message Window; Warp Town -> Area 10 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Dismiss Emotion Bubble (3); Warp Room -> Submap 5 at (0,0) facing South (Down); Engine Action #5; Show Dialogue Portrait (1, 0, 30); Close Dialogue Sub-Window (8); Warp Town -> Area 45 Map 24 Submap 1 at (2,46); Close Dialogue Sub-Window (8); Warp Town -> Area 47 Map 3 Submap 1 at (1,43); Reset Camera Tracking (5); Set Render Priority (pri) (8, 27); Set Animation Pose (8, 1); Reset Camera Tracking (72); Warp Room -> Submap 4 at (24,1) facing Up (North); Turn obj[72] facing South (Down); Warp Room -> Submap 45 at (43,1) facing East (Right); Turn obj[1] facing South (Down); Warp to Castle HQ (0, 1, 0); Reset Camera Tracking (1); Warp Room -> Submap 9 at (217,64) facing 255 |

---

### Submap Layer `vh04_08` (Index 8)

- **Map Number (`mapno`)**: `8`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `1` Objects | **Script Count (`evkaz`)**: `10` Scripts

#### Complete Physical Entity Inventory (1 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | Prop / Scenery | **Prop ID 64963** | `64963` | `(32, 35)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Prop: Object 64963)**: Environmental world dressing prop placed at tile `(32, 35)`. Solid collision is set to `2`.


#### Complete Bytecode Script Catalog (10 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Story Flag 182 (bit 2) SET AND Player within Box [30..34, 2..107] AND Condition Check #108 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 4, MsgID: 74]; Teleport obj[255] to (254,204) |
| `ev[01]` | `1 (Action / Talk)` | Story Flag 182 (bit 2) CLEAR AND Player within Box [30..34, 2..107] AND Condition Check #108 AND Story Flag 0 (mask 255) SET | Engine Action #9; Engine Action #182; Exit to World Map (12, 4, 74); Teleport obj[255] to (254,204) |
| `ev[02]` | `1 (Action / Talk)` | Story Flag 182 (bit 2) SET AND Player within Box [31..33, 2..29] AND Condition Check #30 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 9, MsgID: 28]; Teleport obj[255] to (254,204) |
| `ev[03]` | `1 (Action / Talk)` | Story Flag 182 (bit 2) CLEAR AND Player within Box [31..33, 2..29] AND Condition Check #30 AND Story Flag 1 (mask 255) SET | Engine Action #9; Engine Action #182; Exit to World Map (12, 9, 28); Teleport obj[255] to (254,204) |
| `ev[04]` | `2 (Map Init)` | Always Passes (Unconditional) | Screen Fade Transition (182, 4, 255) |
| `ev[05]` | `1 (Action / Talk)` | Story Flag 182 (bit 2) CLEAR AND Temp Event Flag #2 SET | Recruit Character into Active Party (11, 1); Warp Town -> Area 40 Map 58 Submap 36 at (2,255) |
| `ev[06]` | `2 (Map Init)` | Always Passes (Unconditional) | Make obj[68] Hidden (disp = 0); Open Dialogue Message Window; Open Dialogue Message Window; Animate Doorway State (64, 64); Teleport obj[255] to (254,204) |
| `ev[07]` | `128 (Loop)` | Story Flag 182 (bit 2) CLEAR AND Temp Event Flag #1 SET | Dismiss Emotion Bubble (0); Engine Action #5; Engine Action #182; Warp Town -> Area 45 Map 45 Submap 96 at (36,1) |
| `ev[08]` | `128 (Loop)` | Story Flag 182 (bit 2) CLEAR AND Inventory Holds Item #4 | Warp Room -> Submap 1 at (15,18); Toggle Random Encounters (4) |
| `ev[09]` | `1 (Action / Talk)` | Story Flag 182 (bit 2) CLEAR AND Player within Box [29..35, 2..48] AND Condition Check #49 | Launch Tactical War Battle (4); Exit to World Map (0, 32, 39); Reset Camera Tracking (101); Engine Action #9; Engine Action #9; Set Combat Battle BGM (60); Engine Action #54; Open Dialogue Message Window; Exit to World Map (69, 2, 83); Warp Room -> Submap 9 at (182,2) facing 69; Warp Room -> Submap 182 at (4,12) facing 12; Warp Map Transition (42, 255, 254, 204, 204) |

---

### Submap Layer `vh04_09` (Index 9)

- **Map Number (`mapno`)**: `9`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `50`, Rate: `4`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `3` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (3 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `128 (Loop)` | Player within Box [33..35, 2..24] AND Condition Check #34 | Warp Room -> Submap 1 at (7,6) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [26..30, 2..51] AND Condition Check #52 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 12, MsgID: 32]; Warp Room -> Submap 255 at (254,204) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [65..69, 2..27] AND Condition Check #29 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 10, MsgID: 31]; Warp Map Transition (255, 254, 204, 204, 204) |

---

### Submap Layer `vh04_10` (Index 10)

- **Map Number (`mapno`)**: `10`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `50`, Rate: `4`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `4` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (4 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [25..29, 2..31] AND Condition Check #33 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 9, MsgID: 65]; Display Chapter Text (255) |
| `ev[01]` | `1 (Action / Talk)` | Story Flag 179 (bit 16) CLEAR AND Player within Box [58..58, 2..25] AND Condition Check #26 AND Story Flag 1 (mask 255) SET | Close Dialogue Window; Warp Town -> Area 2 Map 30 Submap 69 at (1,31); Warp Room -> Submap 6 at (73,30) facing 101; Engine Action #5; Engine Action #184; Warp Map Transition (2, 0, 89, 24, 255) |
| `ev[02]` | `1 (Action / Talk)` | Story Flag 179 (bit 16) SET AND Story Flag 182 (bit 1) CLEAR AND Player within Box [58..58, 2..25] AND Condition Check #26 AND Temp Event Flag #1 CLEAR | Fade Out to Black (118); Walk obj[7] to (1,4); Open Dialogue Message Window |
| `ev[03]` | `1 (Action / Talk)` | Story Flag 182 (bit 1) SET AND Player within Box [58..58, 2..25] AND Condition Check #26 AND Story Flag 1 (mask 255) SET | Place Scenery Structure (5); Pan Camera (5, 0, 89); Close Dialogue Sub-Window (255) |

---

### Submap Layer `vh04_11` (Index 11)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `1` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (1 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [23..25, 2..36] AND Condition Check #37 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 10, MsgID: 58]; Fade In from Black (255) |

---

### Submap Layer `vh04_12` (Index 12)

- **Map Number (`mapno`)**: `11`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `2` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (2 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Story Flag 182 (bit 2) SET AND Player within Box [30..34, 2..107] AND Condition Check #108 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 4, MsgID: 74]; Teleport obj[255] to (254,204) |
| `ev[01]` | `1 (Action / Talk)` | Story Flag 182 (bit 2) SET AND Player within Box [31..33, 2..29] AND Condition Check #30 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 9, MsgID: 28]; Teleport obj[255] to (254,204) |

---


