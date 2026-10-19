# Suikoden II Geographic Area Catalog: Drakemouth Mountain Settlement

**Geographic Scope & Role**: Highland mountain pass hamlet; rocky ascents, traveler inn cabins, and checkpoint bridges leading into Tinto territory.

**Regional Category**: Region `VG` | **Master Maps Included**: `vg04`, `vg06`

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

## Location Map: `vg04`

- **Master Map Container**: `vg04.json`
- **Submap Layer Files**: vg04_00.json
- **Collision Grid Files**: vg04_map_00.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 3

### Submap Layer `vg04_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `50`, Rate: `5`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `4` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (4 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Player within Box [116..116, 2..51] AND Condition Check #51 | Animate Door obj[6] (State: 3); Open Dialogue Message Window; Mark NPC Talk Interaction Complete (Flag #51) |
| `ev[01]` | `128 (Loop)` | Temp Event Flag #128 SET AND Player within Box [98..120, 2..45] AND Condition Check #55 AND Story Flag 3 (mask 255) SET | Warp Room -> Submap 0 at (6,5); Launch Tactical War Battle (128) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [118..122, 2..47] AND Condition Check #55 AND Story Flag 3 (mask 255) SET | Warp Map Transition (3, 0, 3, 30, 255) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [0..1, 2..34] AND Condition Check #40 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 116]; Toggle Random Encounters (255) |

---

### Submap Layer `vg04_01` (Index 1)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `50`, Rate: `5`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `5` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (5 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [118..120, 2..33] AND Condition Check #41 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 3]; Toggle Random Encounters (255) |
| `ev[01]` | `2 (Map Init)` | Player within Box [12..12, 2..17] AND Star of Destiny #255 Not Yet Recruited | Warp to Castle HQ (0, 3, 254) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [5..7, 2..10] AND Party Formation Check AND Story Flag 2 (mask 255) SET | Place Scenery Structure (5); Engine Action #6; Show Dialogue Portrait (0, 90, 18) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [76..78, 2..10] AND Party Formation Check AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 8]; Engine Action #80 |
| `ev[04]` | `1 (Action / Talk)` | Story Flag 190 (bit 4) SET AND Story Flag 190 (bit 8) CLEAR AND Player within Box [50..75, 2..23] AND Condition Check #24 | Set Render Priority (pri) (0, 62); Branch on Choice (8, 33); Warp Room -> Submap 0 at (1,3) facing South (Down); Warp to Castle HQ (5, 1, 3); Warp to Castle HQ (1, 0, 5); Engine Action #5; Warp Town -> Area 0 Map 30 Submap 24 at (1,0); Pan Camera (39, 34, 3); Open Dialogue Message Window; Warp Room -> Submap 190 at (8,255) facing 254 |

---

### Submap Layer `vg04_02` (Index 2)

- **Map Number (`mapno`)**: `2`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `50`, Rate: `5`)
- **Entity Count (`okaz`)**: `2` Objects | **Script Count (`evkaz`)**: `6` Scripts

#### Complete Physical Entity Inventory (2 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 4)** | `0` | `(80, 18)` | `0x0` | Frame 4 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 5)** | `0` | `(80, 18)` | `0x0` | Frame 5 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(80, 18)` with state parameter `4`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(80, 18)` with state parameter `5`.


#### Complete Bytecode Script Catalog (6 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Treasure Byte 20 Bit 64 FRESH (Unopened) | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[01]` | `2 (Map Init)` | Treasure Byte 20 Bit 64 LOOTED | Open Dialogue Message Window; Engine Action #9 |
| `ev[02]` | `128 (Loop)` | Temp Event Flag #1 SET AND Player within Box [8..8, 2..80] AND Condition Check #80 | Launch Tactical War Battle (1); Warp Room -> Submap 0 at (6,4) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [1..3, 2..72] AND Condition Check #80 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 71]; Change Portrait Expression (255) |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [20..26, 2..4] AND Temp Event Flag #9 SET AND Player X within Range [255..254] | Warp Map Transition (3, 0, 23, 57, 255) |
| `ev[05]` | `1 (Action / Talk)` | Treasure Byte 20 Bit 64 FRESH (Unopened) AND Target Inspected is obj[8] | Make obj[1] Hidden (disp = 0); Reset Camera Tracking (0); Engine Action #9; Teleport obj[101] to (4,7); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (0); Exit to World Map (0, 27, 16); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,20) facing 64; Warp Room -> Submap 1 at (9,0) facing 8; Teleport obj[255] to (254,204) |

---



## Location Map: `vg06`

- **Master Map Container**: `vg06.json`
- **Submap Layer Files**: vg06_00.json, vg06_01.json, vg06_04.json, vg06_09.json, vg06_10.json, vg06_12.json, vg06_24.json, vg06_25.json
- **Collision Grid Files**: vg06_map_00.json, vg06_map_01.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 2

### Submap Layer `vg06_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `30` Objects | **Script Count (`evkaz`)**: `65` Scripts

#### Complete Physical Entity Inventory (30 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 64777** | `64777` | `(161, 80)` | `6x6` | South (Down) | Visible (1) | Special (3) | 2 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Actor ID 64782** | `64782` | `(161, 80)` | `6x6` | South (Down) | Visible (1) | Special (3) | 2 | 255 | 0 |
| `obj[02]` | Prop / Scenery | **Prop ID 64794** | `64794` | `(170, 91)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | Trigger / Hitbox | **Hitbox Zone (9x3)** | `0` | `(166, 89)` | `8x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | NPC / Actor | **Village Blacksmith Anvil** | `65056` | `(115, 71)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[05]` | NPC / Actor | **Actor ID 64793** | `64793` | `(118, 71)` | `5x0` | South (Down) | Dormant / Hidden (0) | Special (3) | 2 | 255 | 0 |
| `obj[06]` | NPC / Actor | **Matilda Knight Guard** | `65106` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[07]` | NPC / Actor | **Jowy Atreides** | `2` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[08]` | NPC / Actor | **Actor ID 89** | `89` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[09]` | NPC / Actor | **Rowd** | `85` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[10]` | Prop / Scenery | **Prop ID 42241** | `42241` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Prop / Scenery | **Prop ID 33113** | `33113` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[12]` | Prop / Scenery | **Prop ID 33113** | `33113` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[13]` | Prop / Scenery | **Prop ID 64965** | `64965` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[14]` | Prop / Scenery | **Prop ID 64965** | `64965` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[15]` | Prop / Scenery | **Prop ID 64965** | `64965` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[16]` | Prop / Scenery | **Prop ID 35090** | `35090` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[17]` | NPC / Actor | **Market Fruit Crate** | `65216` | `(125, 131)` | `20x5` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[18]` | NPC / Actor | **Storage Sack / Flour Bag** | `65079` | `(135, 101)` | `20x20` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[19]` | NPC / Actor | **Spice Stall & Jars** | `65223` | `(116, 123)` | `20x10` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[20]` | NPC / Actor | **Actor ID 65028** | `65028` | `(91, 94)` | `1x1` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[21]` | NPC / Actor | **Actor ID 65047** | `65047` | `(52, 129)` | `20x5` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[22]` | NPC / Actor | **Storage Sack / Flour Bag** | `65079` | `(59, 68)` | `20x20` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[23]` | NPC / Actor | **Spice Stall & Jars** | `65223` | `(91, 59)` | `5x20` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[24]` | NPC / Actor | **Actor ID 65058** | `65058` | `(101, 78)` | `20x20` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[25]` | NPC / Actor | **Jowy (Camp/Prologue)** | `18` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[26]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(113, 115)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[27]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(121, 49)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[28]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(39, 103)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[29]` | Trigger / Hitbox | **Hitbox Zone (4x3)** | `0` | `(37, 99)` | `3x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 64777)**: Positioned at tile `(161, 80)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Object 64782)**: Positioned at tile `(161, 80)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Prop: Object 64794)**: Environmental world dressing prop placed at tile `(170, 91)`. Solid collision is set to `0`.
- **`obj[03]` (Hitbox Zone)**: Bounding trigger area covering `9` tiles wide by `3` tiles high from `(166, 89)` to `(174, 91)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[04]` (Village Blacksmith Anvil)**: Positioned at tile `(115, 71)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Object 64793)**: Positioned at tile `(118, 71)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[06]` (Matilda Knight Guard)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[07]` (Jowy Atreides)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[08]` (Object 89)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[09]` (Rowd)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[10]` (Prop: Object 42241)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `32`.
- **`obj[11]` (Prop: Object 33113)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `2`.
- **`obj[12]` (Prop: Object 33113)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `2`.
- **`obj[13]` (Prop: Object 64965)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `2`.
- **`obj[14]` (Prop: Object 64965)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `2`.
- **`obj[15]` (Prop: Object 64965)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `2`.
- **`obj[16]` (Prop: Object 35090)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[17]` (Market Fruit Crate)**: Positioned at tile `(125, 131)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[18]` (Storage Sack / Flour Bag)**: Positioned at tile `(135, 101)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[19]` (Spice Stall & Jars)**: Positioned at tile `(116, 123)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[20]` (Object 65028)**: Positioned at tile `(91, 94)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[21]` (Object 65047)**: Positioned at tile `(52, 129)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[22]` (Storage Sack / Flour Bag)**: Positioned at tile `(59, 68)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[23]` (Spice Stall & Jars)**: Positioned at tile `(91, 59)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[24]` (Object 65058)**: Positioned at tile `(101, 78)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[25]` (Jowy (Camp/Prologue))**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[26]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(113, 115)` to `(115, 116)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[27]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(121, 49)` to `(123, 50)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[28]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(39, 103)` to `(41, 104)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[29]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `3` tiles high from `(37, 99)` to `(40, 101)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (65 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `128 (Loop)` | Player Y within Range [48..63] AND Story Flag 1 (mask 255) SET | Warp Room -> Submap 1 at (6,3) |
| `ev[01]` | `128 (Loop)` | Player within Box [89..171, 2..110] AND Condition Check #148 AND Story Flag 0 (mask 255) SET | Warp Room -> Submap 2 at (12,7) |
| `ev[02]` | `1 (Action / Talk)` | Player Y within Range [149..155] AND Story Flag 0 (mask 255) SET | Warp Map Transition (0, 0, 81, 189, 255) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [0..1, 2..20] AND Condition Check #44 AND Story Flag 2 (mask 255) SET | Warp Map Transition (2, 0, 116, 51, 255) |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [95..97, 2..117] AND Condition Check #119 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 57]; Teleport obj[255] to (254,204) |
| `ev[05]` | `1 (Action / Talk)` | Player within Box [107..109, 2..57] AND Condition Check #59 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 59]; Engine Action #121 |
| `ev[06]` | `1 (Action / Talk)` | Player within Box [49..51, 2..99] AND Condition Check #101 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 113]; Recruit Character into Active Party (255, 254) |
| `ev[07]` | `1 (Action / Talk)` | Player within Box [144..145, 2..88] AND Condition Check #92 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 128]; Engine Action #121 |
| `ev[08]` | `2 (Map Init)` | Always Passes (Unconditional) | Make obj[2] Hidden (disp = 0); Animate Door Open; Set Animation Pose (55, 3); Animate Door Open; Open Dialogue Message Window; Open Dialogue Message Window; Animate Door Open; Teleport obj[255] to (254,204) |
| `ev[09]` | `1 (Action / Talk)` | Story Flag 125 (bit 32) SET AND Story Flag 190 (bit 2) CLEAR AND Player within Box [126..140, 2..135] AND Condition Check #136 AND Star of Destiny #1 Recruited AND Condition Check #59 | Screen Fade Transition (237, 254, 10); Engine Action #238; Screen Fade Transition (239, 254, 33); Warp Room -> Submap 0 at (1,5) facing West (Left); Exit to World Map (5, 1, 3); Warp to Castle HQ (0, 5, 3); Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (24); Warp Room -> Submap 0 at (5,1) facing South (Down); Warp to Castle HQ (30, 1, 1); Engine Action #9; Engine Action #190; Warp Town -> Area 34 Map 255 Submap 254 at (204,204) |
| `ev[10]` | `1 (Action / Talk)` | Story Flag 190 (bit 2) SET AND Story Flag 190 (bit 4) CLEAR AND Player within Box [53..59, 2..52] AND Condition Check #58 | Exit to World Map (0, 57, 61); Engine Action #9; Make obj[3] Hidden (disp = 0); Animate Door Open; Open Dialogue Message Window; Warp to Castle HQ (0, 1, 47); Return to Previous Memory Map (1); Set obj[24] Collision to Passable; Open Dialogue Message Window; Warp Room -> Submap 1 at (5,1) facing 4; Engine Action #5; Warp to Castle HQ (3, 1, 5); Warp Town -> Area 0 Map 30 Submap 24 at (1,0); Warp Town -> Area 3 Map 14 Submap 3 at (72,1); Animate Door Open; Warp Town -> Area 24 Map 14 Submap 0 at (3,3); Open Dialogue Message Window; Warp Room -> Submap 0 at (14,24) facing West (Left); Open Dialogue Message Window; Exit to World Map (3, 14, 1); Set Combat Battle BGM (45); Warp to Castle HQ (14, 3, 24); Animate Door Open; Open Dialogue Message Window; Engine Action #5; Set Entity Movement Speed (3, 5); Animate Door Open; Warp Room -> Submap 4 at (5,3) facing 38; Dismiss Emotion Bubble (255); Engine Action #5; Warp Room -> Submap 120 at (3,0) facing 30; Engine Action #5; Open Dialogue Message Window; Engine Action #5; Engine Action #135; Warp to Castle HQ (0, 30, 255); Walk obj[1] to (14,3); Warp Room -> Submap 24 at (1,0) facing 6; Warp to Castle HQ (0, 1, 48); Warp Room -> Submap 3 at (0,1) facing South (Down); Reset Camera Tracking (1); Warp Room -> Submap 9 at (190,4) facing 255 |
| `ev[11]` | `1 (Action / Talk)` | Story Flag 190 (bit 2) CLEAR AND Player within Box [52..63, 2..52] AND Condition Check #61 | Set Render Priority (pri) (0, 60); Set Render Priority (pri) (8, 3); Open Dialogue Message Window; Warp Town -> Area 3 Map 14 Submap 3 at (24,14); Engine Action #6; Open Dialogue Message Window; Set Render Priority (pri) (0, 62); Engine Action #62; Reset Camera Tracking (3); Open Dialogue Message Window; Open Dialogue Message Window; Warp to Castle HQ (14, 0, 255) |
| `ev[12]` | `1 (Action / Talk)` | Story Flag 190 (bit 4) SET AND Target Inspected is obj[14] | Open Dialogue Sub-Window (6); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[13]` | `1 (Action / Talk)` | Story Flag 193 (bit 16) SET AND Story Flag 198 (bit 64) SET AND Story Flag 199 (bit 2) CLEAR AND Story Flag 202 (bit 2) CLEAR AND Player within Box [18..20, 2..22] AND Condition Check #42 AND Story Flag 3 (mask 255) SET | Set Render Priority (pri) (0, 22); Return to Previous Memory Map (8); Warp to Castle HQ (0, 3, 33); Warp Room -> Submap 0 at (1,5) facing West (Left); Warp to Castle HQ (0, 1, 4); Engine Action #5; Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (3); Open Dialogue Message Window; Warp Room -> Submap 1 at (1,76) facing 101; Engine Action #9; Engine Action #9; Jump to Bytecode Offset (0, 177); Make obj[106] Hidden (disp = 0); Open Dialogue Message Window; Display Speaker Name Box (89); Display Speaker Name Box (2); Open Dialogue Message Window; Warp Room -> Submap 0 at (18,47) facing 89; Display Speaker Name Box (5); Engine Action #89; Display Speaker Name Box (5); Engine Action #89; Display Speaker Name Box (2); Warp Room -> Submap 1 at (1,2) facing 24; Warp Room -> Submap 77 at (11,2) facing Up (North); Engine Action #180; Load Sound Bank into Memory (0, 1); Wait for Audio / Window Sync (3); Engine Action #9; Engine Action #199; Warp Town -> Area 102 Map 0 Submap 117 at (0,0); Place Scenery Structure (5); Warp Town -> Area 8 Map 0 Submap 125 at (17,255) |
| `ev[14]` | `2 (Map Init)` | Story Flag 193 (bit 16) SET AND Story Flag 199 (bit 4) SET AND Story Flag 199 (bit 8) CLEAR AND Story Flag 202 (bit 2) CLEAR AND Player within Box [132..132, 2..93] AND Condition Check #93 | Make obj[44] Hidden (disp = 0); Engine Action #63; Warp Room -> Submap 2 at (0,147) facing 90; Warp Town -> Area 1 Map 141 Submap 87 at (2,24); Engine Action #141; Engine Action #87; Warp Town -> Area 15 Map 139 Submap 88 at (2,16); Engine Action #132; Engine Action #90; Warp Town -> Area 17 Map 135 Submap 93 at (2,21); Engine Action #126; Engine Action #89; Warp Town -> Area 22 Map 134 Submap 100 at (2,23); Engine Action #140; Mark Chest Looted (Byte 3, Bit 15); Warp to Castle HQ (3, 16, 3); Warp to Castle HQ (17, 1, 89); Close Dialogue Sub-Window (2); Open Dialogue Message Window; Engine Action #89; Execute Choice Result (2); Screen Fade Transition (89, 22, 2); Screen Fade Transition (89, 23, 2); Close Dialogue Window; Warp Room -> Submap 0 at (15,0) facing 16; Open Dialogue Message Window; Close Dialogue Sub-Window (0); Change Portrait Expression (0); Execute Choice Result (0); Set Story Flag (0, 23); Warp Room -> Submap 1 at (26,1) facing 27; Warp Room -> Submap 1 at (29,1) facing 30; Warp Room -> Submap 1 at (32,47) facing 255 |
| `ev[15]` | `1 (Action / Talk)` | Story Flag 193 (bit 16) SET AND Story Flag 199 (bit 4) SET AND Story Flag 199 (bit 8) CLEAR AND Story Flag 202 (bit 2) CLEAR | Engine Action #102; Open Dialogue Message Window; Engine Action #117; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #89; Close Dialogue Sub-Window (3); Dismiss Character to Castle Base (117); Return to Previous Memory Map (11); Warp Room -> Submap 150 at (43,1) facing 4; Engine Action #89; Close Dialogue Sub-Window (4); Close Dialogue Sub-Window (15); Warp Room -> Submap 89 at (24,2) facing West (Left); Close Dialogue Sub-Window (1); Warp Room -> Submap 89 at (24,2) facing Up (North); Engine Action #89; Close Dialogue Sub-Window (5); Engine Action #89; Close Dialogue Sub-Window (5); Make obj[1] Hidden (disp = 0); Close Dialogue Sub-Window (0); Warp Room -> Submap 101 at (9,9) facing South (Down); Open Dialogue Message Window; Engine Action #5; Open Dialogue Message Window; Warp Town -> Area 8 Map 30 Submap 101 at (1,1); Warp to Castle HQ (15, 0, 29); Engine Action #5; Close Dialogue Sub-Window (16); Warp Room -> Submap 73 at (20,40) facing South (Down); Open Dialogue Message Window; Warp Town -> Area 1 Map 87 Submap 1 at (88,41); Warp Town -> Area 0 Map 1 Submap 255 at (0,255); Warp Town -> Area 36 Map 4 Submap 24 at (16,1); Engine Action #111; Close Dialogue Sub-Window (1); Warp Room -> Submap 48 at (16,0) facing Up (North); Warp Town -> Area 1 Map 0 Submap 9 at (3,16); Warp to Castle HQ (73, 60, 46); Set Character Quest Milestone (16, 19); Engine Action #89; Display Choice Selection (2, 0); Warp Room -> Submap 0 at (19,47) facing 46; Set Character Quest Milestone (0, 20); Engine Action #89; Display Choice Selection (2, 1); Engine Action #89; Branch on Choice (2, 2); Warp Room -> Submap 0 at (20,47) facing 101; Open Dialogue Message Window; Engine Action #176; Engine Action #90; Branch on Choice (19, 1); Dismiss Emotion Bubble (89); Branch on Choice (2, 3); Engine Action #89; Branch on Choice (5, 89); Branch on Choice (5, 46); Warp Room -> Submap 0 at (16,47) facing 5; Dismiss Dialogue Portrait; Warp to Castle HQ (0, 7, 2); Dismiss Emotion Bubble (73); Trigger Character Emotion Effect (24, 16); Warp Room -> Submap 89 at (20,2) facing 4; Engine Action #89; Branch on Choice (5, 89); Branch on Choice (5, 24); Dismiss Dialogue Portrait; Warp Room -> Submap 24 at (15,1) facing 115; Set Combat Battle BGM (60); Close Dialogue Window; Warp Town -> Area 2 Map 180 Submap 46 at (1,20); Warp Town -> Area 0 Map 140 Submap 90 at (3,0); Warp Room -> Submap 0 at (47,73) facing 30; Make obj[1] Hidden (disp = 0); Dismiss Dialogue Portrait; Warp Room -> Submap 1 at (21,1) facing 22; Warp Room -> Submap 47 at (29,4) facing 73; Dismiss Emotion Bubble (3); Warp Room -> Submap 101 at (9,9) facing 11; Warp Room -> Submap 180 at (24,1) facing West (Left); Engine Action #116; Engine Action #39; Return Warp to Castle Base (48, 15); Open Dialogue Message Window; Warp to Castle HQ (0, 1, 0); Reset Camera Tracking (1); Show Dialogue Portrait (54, 0, 4); Pathfind and Walk to Coordinates (4, 0, 1); Warp Town -> Area 2 Map 70 Submap 2 at (0,101); Warp Room -> Submap 9 at (199,8) facing 9; Engine Action #199; Dismiss Dialogue Portrait; Warp Room -> Submap 16 at (1,89) facing 73; Branch on Choice (40, 0); Open Dialogue Message Window; Warp Town -> Area 1 Map 87 Submap 1 at (90,41); Warp Town -> Area 2 Map 3 Submap 255 at (3,24); Change Portrait Expression (1); Make Object Visible (disp = 1) (24); Warp Room -> Submap 92 at (24,16) facing West (Left); Engine Action #93; Turn obj[16] facing South (Down); Warp Town -> Area 2 Map 1 Submap 0 at (9,3); Dismiss Dialogue Portrait; Warp to Castle HQ (48, 16, 0); Warp Town -> Area 2 Map 1 Submap 0 at (9,3); Dismiss Dialogue Portrait; Warp to Castle HQ (73, 60, 46); Set Character Quest Milestone (16, 19); Engine Action #89; Display Choice Selection (2, 0); Warp Room -> Submap 0 at (19,47) facing 46; Set Character Quest Milestone (0, 20); Engine Action #89; Display Choice Selection (2, 1); Engine Action #89; Branch on Choice (2, 2); Warp Room -> Submap 0 at (20,47) facing 101; Open Dialogue Message Window; Engine Action #176; Engine Action #90; Branch on Choice (19, 1); Dismiss Emotion Bubble (89); Branch on Choice (2, 3); Engine Action #89; Branch on Choice (5, 89); Branch on Choice (5, 46); Warp Room -> Submap 0 at (16,47) facing 5; Dismiss Dialogue Portrait; Warp to Castle HQ (0, 7, 2); Dismiss Emotion Bubble (73); Trigger Character Emotion Effect (24, 16); Warp Room -> Submap 89 at (20,2) facing 4; Engine Action #89; Branch on Choice (5, 89); Branch on Choice (5, 73); Branch on Choice (40, 0); Open Dialogue Message Window; Warp Town -> Area 1 Map 87 Submap 1 at (95,41); Warp Town -> Area 4 Map 5 Submap 255 at (4,36); Exit to World Map (24, 16, 1); Engine Action #117; Close Dialogue Sub-Window (15); Warp Room -> Submap 73 at (60,11) facing Up (North); Warp Town -> Area 180 Map 46 Submap 1 at (20,2); Open Dialogue Message Window; Engine Action #140; Engine Action #90; Warp to Castle HQ (0, 1, 0); Open Dialogue Message Window; Teleport obj[73] to (30,46); Warp Room -> Submap 1 at (17,1) facing 21; Warp Room -> Submap 1 at (23,47) facing 29; Exit to World Map (101, 9, 9); Close Dialogue Window; Warp Room -> Submap 180 at (24,1) facing West (Left); Engine Action #119; Engine Action #39; Return Warp to Castle Base (48, 15); Open Dialogue Message Window; Warp to Castle HQ (0, 1, 0); Reset Camera Tracking (1); Show Dialogue Portrait (54, 0, 4); Pathfind and Walk to Coordinates (4, 0, 1); Warp Town -> Area 2 Map 70 Submap 2 at (0,101); Warp Room -> Submap 9 at (199,8) facing 9; Engine Action #199; Dismiss Dialogue Portrait; Engine Action #5; Close Dialogue Sub-Window (1); Warp Room -> Submap 73 at (60,5) facing West (Left); Warp to Castle HQ (0, 5, 10); Warp Room -> Submap 30 at (24,1) facing West (Left); Mark Chest Looted (Byte 24, Bit 16); Warp Room -> Submap 5 at (16,1) facing South (Down); Engine Action #5; Engine Action #9; Warp Town -> Area 3 Map 30 Submap 3 at (15,2); Close Dialogue Sub-Window (15); Warp Room -> Submap 5 at (16,1) facing South (Down); Engine Action #5; Engine Action #5; Warp to Castle HQ (0, 30, 24); Dismiss Dialogue Portrait; Warp Room -> Submap 5 at (16,0) facing South (Down); Engine Action #5; Screen Fade Transition (2, 3, 0); Engine Action #5; Warp Town -> Area 22 Map 30 Submap 1 at (16,24); Show Dialogue Portrait (1, 101, 5); Show Dialogue Portrait (2, 10, 0); Engine Action #6; Warp Town -> Area 23 Map 30 Submap 1 at (15,24); Change Portrait Expression (1); Engine Action #102; Engine Action #5; Change Portrait Expression (1); Open Dialogue Message Window; Engine Action #5; Screen Fade Transition (2, 28, 30); Set Combat Battle BGM (60); Close Dialogue Window; Warp Town -> Area 2 Map 180 Submap 46 at (1,20); Open Dialogue Message Window; Open Dialogue Message Window; Warp Room -> Submap 1 at (15,1) facing 17; Warp Room -> Submap 1 at (22,1) facing 23; Set Character Quest Milestone (0, 2); Set Character Quest Milestone (0, 3); Teleport obj[11] to (1,2); Engine Action #180; Open Dialogue Message Window; Warp Town -> Area 0 Map 3 Submap 49 at (2,5); Warp Town -> Area 1 Map 2 Submap 2 at (4,0); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp to Castle HQ (0, 30, 255); Engine Action #5; Warp to Castle HQ (0, 2, 2); Exit to World Map (1, 0, 5); Engine Action #5; Warp to Castle HQ (0, 30, 255); Walk obj[120] to (2,11); Open Dialogue Message Window; Close Dialogue Window; Engine Action #120; Warp to Castle HQ (11, 0, 11); Engine Action #139; Warp Town -> Area 1 Map 18 Submap 49 at (2,5); Warp Town -> Area 1 Map 0 Submap 5 at (5,2); Dismiss Emotion Bubble (30); Engine Action #5; Warp to Castle HQ (0, 0, 5); Engine Action #5; Warp Town -> Area 30 Map 30 Submap 255 at (254,50); Make obj[1] Hidden (disp = 0); Warp Town -> Area 1 Map 3 Submap 47 at (5,1); Warp Town -> Area 0 Map 5 Submap 5 at (0,0); Dismiss Emotion Bubble (73); Turn obj[3] facing South (Down); Warp Room -> Submap 48 at (24,1) facing West (Left); Set Object Direction (48, 1); Open Dialogue Message Window; Warp to Castle HQ (0, 1, 0); Reset Camera Tracking (1); Warp Room -> Submap 4 at (9,199) facing 8; Engine Action #9; Engine Action #199; Warp Map Transition (101, 1, 0, 34, 255) |
| `ev[16]` | `128 (Loop)` | Story Flag 193 (bit 16) SET AND Story Flag 199 (bit 4) SET AND Story Flag 199 (bit 8) CLEAR AND Story Flag 202 (bit 2) CLEAR AND Inventory Holds Item #4 | Warp Room -> Submap 2 at (13,28); Toggle Random Encounters (4) |
| `ev[17]` | `1 (Action / Talk)` | Story Flag 193 (bit 16) SET AND Story Flag 199 (bit 32) SET AND Story Flag 199 (bit 64) CLEAR AND Story Flag 200 (bit 8) CLEAR AND Story Flag 202 (bit 2) CLEAR AND Player within Box [126..140, 2..136] AND Condition Check #137 | Return to Previous Memory Map (1); Display Speaker Name Box (0); Warp Room -> Submap 1 at (4,5) facing South (Down); Warp to Castle HQ (3, 0, 5); Engine Action #5; Warp Room -> Submap 4 at (4,30) facing 24; Warp Room -> Submap 106 at (73,20) facing 40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 1 Map 107 Submap 1 at (108,41); Warp Town -> Area 0 Map 1 Submap 255 at (0,24); Warp Room -> Submap 110 at (73,30) facing 39; Return Warp to Castle Base (5, 0); Open Dialogue Message Window; Open Dialogue Message Window; Pan Camera (3, 30, 255); Warp Room -> Submap 1 at (1,109) facing 49; Warp Town -> Area 5 Map 0 Submap 4 at (4,3); Warp Town -> Area 0 Map 3 Submap 2 at (0,30); Engine Action #5; Warp Room -> Submap 30 at (3,0) facing 4; Exit to World Map (30, 255, 254); Walk obj[73] to (30,49); Warp Town -> Area 5 Map 0 Submap 4 at (3,0); Change Portrait Expression (30); Engine Action #5; Warp Room -> Submap 3 at (0,17) facing 30; Walk obj[9] to (199,64); Engine Action #54; Open Dialogue Message Window; Warp Town -> Area 69 Map 3 Submap 101 at (9,6); Close Dialogue Window; Warp Town -> Area 2 Map 250 Submap 13 at (5,6); Close Dialogue Window; Open Dialogue Message Window; Open Dialogue Message Window; Open Dialogue Message Window |
| `ev[18]` | `128 (Loop)` | Story Flag 193 (bit 16) SET AND Story Flag 199 (bit 32) SET AND Story Flag 199 (bit 64) CLEAR AND Story Flag 200 (bit 8) CLEAR AND Story Flag 202 (bit 2) CLEAR AND Inventory Holds Item #2 | Warp Room -> Submap 1 at (6,11); Toggle Random Encounters (2) |
| `ev[19]` | `1 (Action / Talk)` | Target Inspected is obj[25] AND Story Flag 193 (bit 4) CLEAR | Open Dialogue Sub-Window (4); Open Dialogue Message Window |
| `ev[20]` | `1 (Action / Talk)` | Target Inspected is obj[25] AND Story Flag 193 (bit 4) SET AND Story Flag 202 (bit 2) CLEAR | Open Dialogue Sub-Window (7); Open Dialogue Message Window |
| `ev[21]` | `1 (Action / Talk)` | Target Inspected is obj[25] AND Story Flag 202 (bit 2) SET AND Story Flag 131 (bit 64) CLEAR | Open Dialogue Sub-Window (8); Open Dialogue Message Window |
| `ev[22]` | `1 (Action / Talk)` | Target Inspected is obj[25] AND Story Flag 131 (bit 64) SET AND Story Flag 143 (bit 1) CLEAR | Open Dialogue Sub-Window (9); Open Dialogue Message Window |
| `ev[23]` | `1 (Action / Talk)` | Target Inspected is obj[25] AND Story Flag 143 (bit 1) SET | Open Dialogue Sub-Window (10); Open Dialogue Message Window |
| `ev[24]` | `1 (Action / Talk)` | Target Inspected is obj[26] AND Story Flag 190 (bit 4) CLEAR | Open Dialogue Sub-Window (4); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[25]` | `1 (Action / Talk)` | Target Inspected is obj[26] AND Story Flag 190 (bit 4) SET | Open Dialogue Sub-Window (7); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[26]` | `1 (Action / Talk)` | Target Inspected is obj[27] AND Story Flag 193 (bit 4) CLEAR | Open Dialogue Sub-Window (4); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[27]` | `1 (Action / Talk)` | Target Inspected is obj[27] AND Story Flag 193 (bit 4) SET AND Story Flag 202 (bit 2) CLEAR | Open Dialogue Sub-Window (7); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[28]` | `1 (Action / Talk)` | Target Inspected is obj[27] AND Story Flag 202 (bit 2) SET AND Story Flag 131 (bit 64) CLEAR | Open Dialogue Sub-Window (8); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[29]` | `1 (Action / Talk)` | Target Inspected is obj[27] AND Story Flag 131 (bit 64) SET AND Story Flag 143 (bit 1) CLEAR | Open Dialogue Sub-Window (9); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[30]` | `1 (Action / Talk)` | Target Inspected is obj[27] AND Story Flag 143 (bit 1) SET | Open Dialogue Sub-Window (10); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[31]` | `1 (Action / Talk)` | Target Inspected is obj[28] AND Story Flag 193 (bit 4) CLEAR | Open Dialogue Sub-Window (4); Warp to Castle HQ (255, 254, 204) |
| `ev[32]` | `1 (Action / Talk)` | Target Inspected is obj[28] AND Story Flag 193 (bit 4) SET AND Story Flag 202 (bit 2) CLEAR | Open Dialogue Sub-Window (7); Warp to Castle HQ (255, 254, 204) |
| `ev[33]` | `1 (Action / Talk)` | Target Inspected is obj[28] AND Story Flag 202 (bit 2) SET AND Story Flag 131 (bit 64) CLEAR | Open Dialogue Sub-Window (8); Warp to Castle HQ (255, 254, 204) |
| `ev[34]` | `1 (Action / Talk)` | Target Inspected is obj[28] AND Story Flag 131 (bit 64) SET AND Story Flag 143 (bit 1) CLEAR | Open Dialogue Sub-Window (9); Warp to Castle HQ (255, 254, 204) |
| `ev[35]` | `1 (Action / Talk)` | Target Inspected is obj[28] AND Story Flag 143 (bit 1) SET | Open Dialogue Sub-Window (10); Warp to Castle HQ (255, 254, 204) |
| `ev[36]` | `1 (Action / Talk)` | Target Inspected is obj[29] AND Story Flag 190 (bit 4) CLEAR | Open Dialogue Sub-Window (4); Exit to World Map (255, 254, 204) |
| `ev[37]` | `1 (Action / Talk)` | Target Inspected is obj[29] AND Story Flag 190 (bit 4) SET | Open Dialogue Sub-Window (7); Exit to World Map (255, 254, 204) |
| `ev[38]` | `1 (Action / Talk)` | Target Inspected is obj[30] AND Story Flag 202 (bit 2) CLEAR | Open Dialogue Sub-Window (4); Engine Action #5 |
| `ev[39]` | `1 (Action / Talk)` | Target Inspected is obj[30] AND Condition Check #24 AND Condition Check #102 AND Player Y within Range [3..202] AND Player Y within Range [4..230] AND Star of Destiny #255 Recruited | Open Dialogue Sub-Window (4); Engine Action #5 |
| `ev[40]` | `1 (Action / Talk)` | Target Inspected is obj[30] AND Condition Check #23 AND Condition Check #102 AND Player Y within Range [3..202] AND Player Y within Range [3..230] AND Star of Destiny #255 Recruited | Open Dialogue Sub-Window (4); Engine Action #5 |
| `ev[41]` | `1 (Action / Talk)` | Target Inspected is obj[30] AND Condition Check #23 AND Condition Check #102 AND Player Y within Range [3..202] AND Player Y within Range [4..230] AND Star of Destiny #255 Recruited | Open Dialogue Sub-Window (7); Engine Action #5 |
| `ev[42]` | `1 (Action / Talk)` | Target Inspected is obj[31] AND Story Flag 193 (bit 4) CLEAR | Open Dialogue Sub-Window (4); Engine Action #6 |
| `ev[43]` | `1 (Action / Talk)` | Target Inspected is obj[31] AND Story Flag 193 (bit 4) SET AND Story Flag 202 (bit 2) CLEAR | Open Dialogue Sub-Window (7); Engine Action #6 |
| `ev[44]` | `1 (Action / Talk)` | Target Inspected is obj[31] AND Story Flag 202 (bit 2) SET AND Story Flag 131 (bit 64) CLEAR | Open Dialogue Sub-Window (8); Engine Action #6 |
| `ev[45]` | `1 (Action / Talk)` | Target Inspected is obj[31] AND Story Flag 131 (bit 64) SET AND Story Flag 143 (bit 1) CLEAR | Open Dialogue Sub-Window (9); Engine Action #6 |
| `ev[46]` | `1 (Action / Talk)` | Target Inspected is obj[31] AND Story Flag 143 (bit 1) SET | Open Dialogue Sub-Window (10); Engine Action #6 |
| `ev[47]` | `1 (Action / Talk)` | Target Inspected is obj[32] AND Story Flag 193 (bit 4) CLEAR | Open Dialogue Sub-Window (4); Pan Camera (255, 254, 204) |
| `ev[48]` | `1 (Action / Talk)` | Target Inspected is obj[32] AND Story Flag 193 (bit 4) SET AND Story Flag 202 (bit 2) CLEAR | Open Dialogue Sub-Window (7); Pan Camera (255, 254, 204) |
| `ev[49]` | `1 (Action / Talk)` | Target Inspected is obj[32] AND Story Flag 202 (bit 2) SET AND Story Flag 131 (bit 64) CLEAR | Open Dialogue Sub-Window (8); Pan Camera (255, 254, 204) |
| `ev[50]` | `1 (Action / Talk)` | Target Inspected is obj[32] AND Story Flag 131 (bit 64) SET AND Story Flag 143 (bit 1) CLEAR | Open Dialogue Sub-Window (9); Pan Camera (255, 254, 204) |
| `ev[51]` | `1 (Action / Talk)` | Target Inspected is obj[32] AND Story Flag 143 (bit 1) SET | Open Dialogue Sub-Window (10); Pan Camera (255, 254, 204) |
| `ev[52]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #102 AND Player Y within Range [4..197] AND Condition Check #64 AND Story Flag 230 (bit 16) CLEAR | Make obj[0] Hidden (disp = 0); Place Scenery Structure (0); Display Dialogue Box [Bank: 47, MsgID: 255] |
| `ev[53]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #102 AND Player Y within Range [3..202] AND Player Y within Range [4..230] AND Star of Destiny #255 Recruited | Make obj[0] Hidden (disp = 0); Place Scenery Structure (0); Display Dialogue Box [Bank: 47, MsgID: 255] |
| `ev[54]` | `1 (Action / Talk)` | Target Inspected is obj[12] AND Condition Check #23 AND Condition Check #102 AND Player Y within Range [4..230] AND Star of Destiny #18 Recruited AND Player X within Range [60..255] | Close Dialogue Sub-Window (12); Warp to Castle HQ (1, 73, 20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 3 Map 2 Submap 3 at (3,41); Warp Town -> Area 0 Map 1 Submap 255 at (0,101); Exit to World Map (7, 30, 0); Exit to World Map (0, 8, 48); Open Dialogue Message Window; Award Potch Loot (+514 Potch); Warp to Castle HQ (255, 2, 24); Display Dialogue Box [Bank: 3, MsgID: 4]; Close Dialogue Window; Warp Town -> Area 2 Map 40 Submap 1 at (12,1); Place Scenery Structure (73); Dismiss Emotion Bubble (11); Warp Room -> Submap 40 at (107,1) facing 60; Engine Action #9; Engine Action #230; Dismiss Dialogue Portrait; Warp to Castle HQ (24, 12, 3); Pan Camera (255, 254, 255); Warp Room -> Submap 12 at (3,5) facing 255 |
| `ev[55]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #102 AND Player Y within Range [4..230] AND Star of Destiny #5 Recruited AND Player Y in Range [18..0] AND Condition Check #60 | Close Dialogue Sub-Window (12); Warp to Castle HQ (1, 73, 20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 3 Map 2 Submap 3 at (3,41); Warp Town -> Area 0 Map 1 Submap 255 at (0,24); Display Dialogue Box [Bank: 3, MsgID: 6]; Warp Room -> Submap 12 at (3,8) facing 255 |
| `ev[56]` | `1 (Action / Talk)` | Story Flag 230 (bit 16) SET AND Target Inspected is obj[12] | Close Dialogue Sub-Window (12); Warp to Castle HQ (9, 255, 254) |
| `ev[57]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Close Dialogue Sub-Window (13); Warp to Castle HQ (10, 255, 254) |
| `ev[58]` | `1 (Action / Talk)` | Target Inspected is obj[8] | Open Dialogue Sub-Window (4); Change Portrait Expression (255) |
| `ev[59]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Open Dialogue Sub-Window (4); Dismiss Dialogue Portrait |
| `ev[60]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Open Dialogue Sub-Window (4); Display Speaker Name Box (255) |
| `ev[61]` | `1 (Action / Talk)` | Target Inspected is obj[34] | Open Dialogue Sub-Window (5); Open Dialogue Message Window |
| `ev[62]` | `1 (Action / Talk)` | Target Inspected is obj[35] | Open Dialogue Sub-Window (5); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[63]` | `1 (Action / Talk)` | Target Inspected is obj[36] | Open Dialogue Sub-Window (5); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[64]` | `1 (Action / Talk)` | Target Inspected is obj[37] | Open Dialogue Sub-Window (5); Warp to Castle HQ (255, 254, 204) |

---

### Submap Layer `vg06_01` (Index 1)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `40` Objects | **Script Count (`evkaz`)**: `76` Scripts

#### Complete Physical Entity Inventory (40 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 65055** | `65055` | `(58, 33)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 3 | 255 | 0 |
| `obj[01]` | Prop / Scenery | **Prop ID 34305** | `34305` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | World Device | **Mechanism (ano 36)** | `0` | `(130, 98)` | `0x0` | Frame 36 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(130, 100)` | `1x1` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | Trigger / Hitbox | **Hitbox Zone (2x5)** | `0` | `(54, 29)` | `1x4` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | Trigger / Hitbox | **Hitbox Zone (6x2)** | `0` | `(57, 34)` | `5x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | NPC / Actor | **Actor ID 65041** | `65041` | `(68, 34)` | `3x10` | South (Down) | Visible (1) | Special (3) | 3 | 255 | 0 |
| `obj[07]` | NPC / Actor | **Actor ID 65037** | `65037` | `(28, 38)` | `10x3` | South (Down) | Visible (1) | Special (3) | 3 | 255 | 0 |
| `obj[08]` | NPC / Actor | **Actor ID 65041** | `65041` | `(71, 104)` | `5x5` | South (Down) | Visible (1) | Special (3) | 3 | 255 | 0 |
| `obj[09]` | NPC / Actor | **Actor ID 64549** | `64549` | `(55, 95)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[10]` | NPC / Actor | **Actor ID 65047** | `65047` | `(28, 101)` | `5x5` | South (Down) | Visible (1) | Special (3) | 3 | 255 | 0 |
| `obj[11]` | NPC / Actor | **Actor ID 65058** | `65058` | `(39, 96)` | `5x5` | South (Down) | Visible (1) | Special (3) | 3 | 255 | 0 |
| `obj[12]` | NPC / Actor | **Actor ID 64563** | `64563` | `(113, 32)` | `0x0` | Up (North) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[13]` | NPC / Actor | **Storage Sack / Flour Bag** | `65079` | `(101, 50)` | `3x5` | South (Down) | Visible (1) | Special (3) | 3 | 255 | 0 |
| `obj[14]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(63, 43)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[15]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(51, 43)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[16]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(71, 38)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[17]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(71, 31)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[18]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(45, 29)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[19]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(39, 39)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[20]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(25, 37)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[21]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(135, 92)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[22]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(129, 92)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[23]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(135, 102)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[24]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(107, 100)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[25]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(103, 102)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[26]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(75, 107)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[27]` | Trigger / Hitbox | **Hitbox Zone (5x2)** | `0` | `(39, 92)` | `4x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[28]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(27, 93)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[29]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(37, 92)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[30]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(51, 112)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[31]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(53, 118)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[32]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(65, 118)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[33]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(127, 53)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[34]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(123, 44)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[35]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(111, 44)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[36]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(107, 44)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[37]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(117, 29)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[38]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(99, 28)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[39]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(97, 49)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 65055)**: Positioned at tile `(58, 33)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Prop: Object 34305)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `130`.
- **`obj[02]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(130, 98)` with state parameter `36`.
- **`obj[03]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(130, 100)` to `(131, 101)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[04]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `5` tiles high from `(54, 29)` to `(55, 33)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[05]` (Hitbox Zone)**: Bounding trigger area covering `6` tiles wide by `2` tiles high from `(57, 34)` to `(62, 35)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[06]` (Object 65041)**: Positioned at tile `(68, 34)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[07]` (Object 65037)**: Positioned at tile `(28, 38)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[08]` (Object 65041)**: Positioned at tile `(71, 104)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[09]` (Object 64549)**: Positioned at tile `(55, 95)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[10]` (Object 65047)**: Positioned at tile `(28, 101)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[11]` (Object 65058)**: Positioned at tile `(39, 96)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[12]` (Object 64563)**: Positioned at tile `(113, 32)`, facing Up (North). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[13]` (Storage Sack / Flour Bag)**: Positioned at tile `(101, 50)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[14]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(63, 43)` to `(64, 44)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[15]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(51, 43)` to `(52, 44)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[16]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(71, 38)` to `(74, 39)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[17]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(71, 31)` to `(72, 32)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[18]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(45, 29)` to `(47, 30)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[19]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(39, 39)` to `(41, 41)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[20]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(25, 37)` to `(26, 38)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[21]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(135, 92)` to `(138, 93)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[22]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(129, 92)` to `(131, 93)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[23]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(135, 102)` to `(137, 103)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[24]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(107, 100)` to `(109, 101)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[25]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(103, 102)` to `(105, 103)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[26]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(75, 107)` to `(77, 108)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[27]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `2` tiles high from `(39, 92)` to `(43, 93)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[28]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(27, 93)` to `(29, 94)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[29]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(37, 92)` to `(38, 93)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[30]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(51, 112)` to `(53, 113)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[31]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(53, 118)` to `(54, 119)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[32]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(65, 118)` to `(66, 119)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[33]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(127, 53)` to `(128, 54)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[34]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(123, 44)` to `(125, 45)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[35]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(111, 44)` to `(112, 45)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[36]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(107, 44)` to `(109, 45)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[37]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(117, 29)` to `(120, 30)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[38]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(99, 28)` to `(100, 29)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[39]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(97, 49)` to `(99, 51)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (76 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [55..59, 2..51] AND Condition Check #53 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 96]; Engine Action #122 |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [57..61, 2..125] AND Condition Check #127 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 108]; Engine Action #62 |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [111..115, 2..61] AND Condition Check #63 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 50]; Engine Action #104 |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [125..126, 2..119] AND Condition Check #124 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 143]; Make Object Visible (disp = 1) (255) |
| `ev[04]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Warp to Castle HQ (8, 2, 96); Show Dialogue Portrait (8, 2, 2); Warp to Castle HQ (0, 2, 10); Open Dialogue Message Window; Warp to Castle HQ (8, 0, 255) |
| `ev[05]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Clear Story Milestone Flag 15 (mask 8); Warp Town -> Area 2 Map 3 Submap 0 at (2,10); Open Dialogue Message Window |
| `ev[06]` | `2 (Map Init)` | Story Flag 193 (bit 16) SET AND Story Flag 199 (bit 2) SET AND Story Flag 199 (bit 4) CLEAR AND Story Flag 202 (bit 2) CLEAR AND Player within Box [117..117, 2..100] AND Condition Check #100 | Make obj[63] Hidden (disp = 0); Warp Room -> Submap 1 at (0,2) facing 9; Engine Action #117; Mark NPC Talk Interaction Complete (Flag #2); Warp Room -> Submap 100 at (3,0) facing South (Down); Warp to Castle HQ (1, 3, 0); Engine Action #9; Open Dialogue Message Window; Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[07]` | `1 (Action / Talk)` | Story Flag 193 (bit 16) SET AND Story Flag 199 (bit 2) SET AND Story Flag 199 (bit 4) CLEAR AND Story Flag 202 (bit 2) CLEAR | Close Dialogue Window; Warp Room -> Submap 180 at (84,91) facing 35; Dismiss Character to Castle Base (2); Engine Action #40; Engine Action #89; Engine Action #9; Exit to World Map (73, 45, 72); Warp Room -> Submap 0 at (5,1) facing 6; Warp Town -> Area 6 Map 2 Submap 30 at (72,0); Warp Room -> Submap 9 at (5,89) facing 9; Engine Action #5; Make obj[1] Hidden (disp = 0); Engine Action #9; Open Dialogue Message Window; Open Dialogue Message Window; Teleport obj[3] to (0,2); Turn obj[1] facing South (Down); Warp Town -> Area 3 Map 1 Submap 0 at (9,3); Warp Room -> Submap 24 at (1,1) facing 78; Set Combat Battle BGM (60); Close Dialogue Sub-Window (1); Warp Room -> Submap 73 at (60,24) facing West (Left); Warp Room -> Submap 73 at (60,24) facing West (Left); Warp Room -> Submap 44 at (3,0) facing South (Down); Jump to Bytecode Offset (10, 4); Set Combat Battle BGM (5); Set Combat Battle BGM (10); Set Combat Battle BGM (2); Close Dialogue Sub-Window (1); Warp Room -> Submap 49 at (2,5) facing West (Left); Engine Action #6; Warp Town -> Area 4 Map 5 Submap 0 at (5,3); Animate Door Open; Open Dialogue Message Window; Place Scenery Structure (3); Open Dialogue Message Window; Exit to World Map (4, 7, 1); Dismiss Emotion Bubble (255); Display Chapter Text (0); Branch on Choice (4, 255); Walk obj[73] to (30,24); Warp Room -> Submap 83 at (36,1) facing 5; Warp Room -> Submap 6 at (0,4) facing Up (North); Exit to World Map (30, 9, 199); Exit to World Map (54, 0, 1); Wait for Audio / Window Sync (2); Display Dialogue Box [Bank: 0, MsgID: 132]; Engine Action #93 |
| `ev[08]` | `128 (Loop)` | Story Flag 193 (bit 16) SET AND Story Flag 199 (bit 2) SET AND Story Flag 199 (bit 4) CLEAR AND Story Flag 202 (bit 2) CLEAR AND Inventory Holds Item #1 | Set Combat Battle BGM (30); Close Dialogue Window; Exit to World Map (2, 30, 37); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[09]` | `1 (Action / Talk)` | Target Inspected is obj[14] AND Story Flag 193 (bit 4) CLEAR | Open Dialogue Sub-Window (4); Reset Camera Tracking (255) |
| `ev[10]` | `1 (Action / Talk)` | Target Inspected is obj[14] AND Story Flag 193 (bit 4) SET AND Story Flag 202 (bit 2) CLEAR | Open Dialogue Sub-Window (7); Reset Camera Tracking (255) |
| `ev[11]` | `1 (Action / Talk)` | Target Inspected is obj[14] AND Story Flag 202 (bit 2) SET AND Story Flag 131 (bit 64) CLEAR | Open Dialogue Sub-Window (8); Reset Camera Tracking (255) |
| `ev[12]` | `1 (Action / Talk)` | Target Inspected is obj[14] AND Story Flag 131 (bit 64) SET AND Story Flag 143 (bit 1) CLEAR | Open Dialogue Sub-Window (9); Reset Camera Tracking (255) |
| `ev[13]` | `1 (Action / Talk)` | Target Inspected is obj[14] AND Story Flag 143 (bit 1) SET | Open Dialogue Sub-Window (10); Reset Camera Tracking (255) |
| `ev[14]` | `1 (Action / Talk)` | Target Inspected is obj[15] AND Story Flag 193 (bit 4) CLEAR | Open Dialogue Sub-Window (4); Engine Action #9 |
| `ev[15]` | `1 (Action / Talk)` | Target Inspected is obj[15] AND Story Flag 193 (bit 4) SET AND Story Flag 202 (bit 2) CLEAR | Open Dialogue Sub-Window (7); Engine Action #9 |
| `ev[16]` | `1 (Action / Talk)` | Target Inspected is obj[15] AND Story Flag 202 (bit 2) SET AND Story Flag 131 (bit 64) CLEAR | Open Dialogue Sub-Window (8); Engine Action #9 |
| `ev[17]` | `1 (Action / Talk)` | Target Inspected is obj[15] AND Story Flag 131 (bit 64) SET AND Story Flag 143 (bit 1) CLEAR | Open Dialogue Sub-Window (9); Engine Action #9 |
| `ev[18]` | `1 (Action / Talk)` | Target Inspected is obj[15] AND Story Flag 143 (bit 1) SET | Open Dialogue Sub-Window (10); Engine Action #9 |
| `ev[19]` | `1 (Action / Talk)` | Target Inspected is obj[16] AND Story Flag 193 (bit 4) CLEAR | Open Dialogue Sub-Window (4); Screen Fade Transition (255, 254, 204) |
| `ev[20]` | `1 (Action / Talk)` | Target Inspected is obj[16] AND Story Flag 193 (bit 4) SET AND Story Flag 202 (bit 2) CLEAR | Open Dialogue Sub-Window (7); Screen Fade Transition (255, 254, 204) |
| `ev[21]` | `1 (Action / Talk)` | Target Inspected is obj[16] AND Story Flag 202 (bit 2) SET AND Story Flag 131 (bit 64) CLEAR | Open Dialogue Sub-Window (8); Screen Fade Transition (255, 254, 204) |
| `ev[22]` | `1 (Action / Talk)` | Target Inspected is obj[16] AND Story Flag 131 (bit 64) SET AND Story Flag 143 (bit 1) CLEAR | Open Dialogue Sub-Window (9); Screen Fade Transition (255, 254, 204) |
| `ev[23]` | `1 (Action / Talk)` | Target Inspected is obj[16] AND Story Flag 143 (bit 1) SET | Open Dialogue Sub-Window (10); Screen Fade Transition (255, 254, 204) |
| `ev[24]` | `1 (Action / Talk)` | Target Inspected is obj[17] AND Story Flag 193 (bit 4) CLEAR | Open Dialogue Sub-Window (4); Close Dialogue Window; Warp to Castle HQ (17, 0, 255) |
| `ev[25]` | `1 (Action / Talk)` | Target Inspected is obj[17] AND Story Flag 193 (bit 4) SET AND Story Flag 202 (bit 2) CLEAR | Open Dialogue Sub-Window (7); Close Dialogue Window; Warp to Castle HQ (17, 0, 255) |
| `ev[26]` | `1 (Action / Talk)` | Target Inspected is obj[17] AND Story Flag 202 (bit 2) SET AND Story Flag 131 (bit 64) CLEAR | Open Dialogue Sub-Window (8); Close Dialogue Window; Warp to Castle HQ (17, 0, 255) |
| `ev[27]` | `1 (Action / Talk)` | Target Inspected is obj[17] AND Story Flag 131 (bit 64) SET AND Story Flag 143 (bit 1) CLEAR | Open Dialogue Sub-Window (9); Close Dialogue Window; Warp to Castle HQ (17, 0, 255) |
| `ev[28]` | `1 (Action / Talk)` | Target Inspected is obj[17] AND Story Flag 143 (bit 1) SET | Open Dialogue Sub-Window (10); Close Dialogue Window; Warp to Castle HQ (17, 0, 255) |
| `ev[29]` | `1 (Action / Talk)` | Target Inspected is obj[18] AND Story Flag 193 (bit 4) CLEAR | Open Dialogue Sub-Window (4); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[30]` | `1 (Action / Talk)` | Target Inspected is obj[18] AND Story Flag 193 (bit 4) SET AND Story Flag 202 (bit 2) CLEAR | Open Dialogue Sub-Window (7); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[31]` | `1 (Action / Talk)` | Target Inspected is obj[18] AND Story Flag 202 (bit 2) SET AND Story Flag 131 (bit 64) CLEAR | Open Dialogue Sub-Window (8); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[32]` | `1 (Action / Talk)` | Target Inspected is obj[18] AND Story Flag 131 (bit 64) SET AND Story Flag 143 (bit 1) CLEAR | Open Dialogue Sub-Window (9); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[33]` | `1 (Action / Talk)` | Target Inspected is obj[18] AND Story Flag 143 (bit 1) SET | Open Dialogue Sub-Window (10); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[34]` | `1 (Action / Talk)` | Target Inspected is obj[19] AND Story Flag 193 (bit 4) CLEAR | Open Dialogue Sub-Window (4); Place Scenery Structure (255) |
| `ev[35]` | `1 (Action / Talk)` | Target Inspected is obj[19] AND Story Flag 193 (bit 4) SET AND Story Flag 202 (bit 2) CLEAR | Open Dialogue Sub-Window (7); Place Scenery Structure (255) |
| `ev[36]` | `1 (Action / Talk)` | Target Inspected is obj[19] AND Story Flag 202 (bit 2) SET AND Story Flag 131 (bit 64) CLEAR | Open Dialogue Sub-Window (8); Place Scenery Structure (255) |
| `ev[37]` | `1 (Action / Talk)` | Target Inspected is obj[19] AND Story Flag 131 (bit 64) SET AND Story Flag 143 (bit 1) CLEAR | Open Dialogue Sub-Window (9); Place Scenery Structure (255) |
| `ev[38]` | `1 (Action / Talk)` | Target Inspected is obj[19] AND Story Flag 143 (bit 1) SET | Open Dialogue Sub-Window (10); Place Scenery Structure (255) |
| `ev[39]` | `1 (Action / Talk)` | Target Inspected is obj[20] AND Story Flag 193 (bit 4) CLEAR | Open Dialogue Sub-Window (4); Animate Door Open; Warp to Castle HQ (20, 2, 255) |
| `ev[40]` | `1 (Action / Talk)` | Target Inspected is obj[20] AND Story Flag 193 (bit 4) SET AND Story Flag 202 (bit 2) CLEAR | Open Dialogue Sub-Window (7); Animate Door Open; Warp to Castle HQ (20, 2, 255) |
| `ev[41]` | `1 (Action / Talk)` | Target Inspected is obj[20] AND Story Flag 202 (bit 2) SET AND Story Flag 131 (bit 64) CLEAR | Open Dialogue Sub-Window (8); Animate Door Open; Warp to Castle HQ (20, 2, 255) |
| `ev[42]` | `1 (Action / Talk)` | Target Inspected is obj[20] AND Story Flag 131 (bit 64) SET AND Story Flag 143 (bit 1) CLEAR | Open Dialogue Sub-Window (9); Animate Door Open; Warp to Castle HQ (20, 2, 255) |
| `ev[43]` | `1 (Action / Talk)` | Target Inspected is obj[20] AND Story Flag 143 (bit 1) SET | Open Dialogue Sub-Window (10); Animate Door Open; Warp to Castle HQ (20, 2, 255) |
| `ev[44]` | `1 (Action / Talk)` | Target Inspected is obj[21] AND Story Flag 193 (bit 4) CLEAR | Open Dialogue Sub-Window (4); Show Dialogue Portrait (255, 254, 204) |
| `ev[45]` | `1 (Action / Talk)` | Target Inspected is obj[21] AND Story Flag 193 (bit 4) SET AND Story Flag 202 (bit 2) CLEAR | Open Dialogue Sub-Window (7); Show Dialogue Portrait (255, 254, 204) |
| `ev[46]` | `1 (Action / Talk)` | Target Inspected is obj[21] AND Story Flag 202 (bit 2) SET AND Story Flag 131 (bit 64) CLEAR | Open Dialogue Sub-Window (8); Show Dialogue Portrait (255, 254, 204) |
| `ev[47]` | `1 (Action / Talk)` | Target Inspected is obj[21] AND Story Flag 131 (bit 64) SET AND Story Flag 143 (bit 1) CLEAR | Open Dialogue Sub-Window (9); Show Dialogue Portrait (255, 254, 204) |
| `ev[48]` | `1 (Action / Talk)` | Target Inspected is obj[21] AND Story Flag 143 (bit 1) SET | Open Dialogue Sub-Window (10); Show Dialogue Portrait (255, 254, 204) |
| `ev[49]` | `1 (Action / Talk)` | Target Inspected is obj[22] | Open Dialogue Sub-Window (5); Exit to World Map (255, 254, 204) |
| `ev[50]` | `1 (Action / Talk)` | Target Inspected is obj[23] | Open Dialogue Sub-Window (5); Engine Action #5 |
| `ev[51]` | `1 (Action / Talk)` | Target Inspected is obj[24] | Open Dialogue Sub-Window (5); Engine Action #6 |
| `ev[52]` | `1 (Action / Talk)` | Target Inspected is obj[26] | Open Dialogue Sub-Window (5); Reset Camera Tracking (255) |
| `ev[53]` | `1 (Action / Talk)` | Target Inspected is obj[27] | Open Dialogue Sub-Window (5); Engine Action #9 |
| `ev[54]` | `1 (Action / Talk)` | Target Inspected is obj[28] | Open Dialogue Sub-Window (5); Screen Fade Transition (255, 254, 204) |
| `ev[55]` | `1 (Action / Talk)` | Target Inspected is obj[29] | Open Dialogue Sub-Window (5); Close Dialogue Window |
| `ev[56]` | `1 (Action / Talk)` | Target Inspected is obj[30] | Open Dialogue Sub-Window (5); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[57]` | `1 (Action / Talk)` | Target Inspected is obj[31] | Open Dialogue Sub-Window (5); Place Scenery Structure (255) |
| `ev[58]` | `1 (Action / Talk)` | Target Inspected is obj[32] | Open Dialogue Sub-Window (5); Animate Door Open |
| `ev[59]` | `1 (Action / Talk)` | Target Inspected is obj[33] | Open Dialogue Sub-Window (5); Show Dialogue Portrait (255, 254, 204) |
| `ev[60]` | `1 (Action / Talk)` | Target Inspected is obj[34] | Open Dialogue Sub-Window (5); Dismiss Dialogue Portrait |
| `ev[61]` | `1 (Action / Talk)` | Target Inspected is obj[35] | Open Dialogue Sub-Window (5); Change Portrait Expression (255) |
| `ev[62]` | `1 (Action / Talk)` | Target Inspected is obj[36] | Open Dialogue Sub-Window (5); Display Speaker Name Box (255) |
| `ev[63]` | `1 (Action / Talk)` | Target Inspected is obj[37] | Open Dialogue Sub-Window (5); Display Choice Selection (255, 254) |
| `ev[64]` | `1 (Action / Talk)` | Target Inspected is obj[38] | Open Dialogue Sub-Window (5); Branch on Choice (255, 254) |
| `ev[65]` | `1 (Action / Talk)` | Target Inspected is obj[39] | Open Dialogue Sub-Window (5); Execute Choice Result (255) |
| `ev[66]` | `1 (Action / Talk)` | Target Inspected is obj[40] | Open Dialogue Sub-Window (5); Set Story Flag (255, 254) |
| `ev[67]` | `1 (Action / Talk)` | Target Inspected is obj[42] | Open Dialogue Sub-Window (5); Close Dialogue Sub-Window (255) |
| `ev[68]` | `1 (Action / Talk)` | Target Inspected is obj[43] | Open Dialogue Sub-Window (5); Clear Dialogue Sub-Window |
| `ev[69]` | `1 (Action / Talk)` | Target Inspected is obj[44] | Open Dialogue Sub-Window (5); Fade In from Black (255) |
| `ev[70]` | `1 (Action / Talk)` | Target Inspected is obj[45] | Open Dialogue Sub-Window (5); Fade Out to Black (255) |
| `ev[71]` | `1 (Action / Talk)` | Target Inspected is obj[46] | Open Dialogue Sub-Window (5); Display Chapter Text (255) |
| `ev[72]` | `1 (Action / Talk)` | Target Inspected is obj[47] | Open Dialogue Sub-Window (5); Display Emotion Bubble (255, 254) |
| `ev[73]` | `2 (Map Init)` | Treasure Byte 24 Bit 2 FRESH (Unopened) | Make obj[0] Hidden (disp = 0); Screen Fade Transition (0, 11, 47) |
| `ev[74]` | `128 (Loop)` | Treasure Byte 24 Bit 2 FRESH (Unopened) AND Temp Event Flag #2 SET | Engine Action #93; Open Dialogue Message Window; Screen Fade Transition (50, 36, 2) |
| `ev[75]` | `1 (Action / Talk)` | Target Inspected is obj[11] AND Treasure Byte 24 Bit 2 FRESH (Unopened) | Open Dialogue Sub-Window (5); Dismiss Emotion Bubble (73); Branch on Choice (101, 4); Pan Camera (101, 4, 7); Dismiss Emotion Bubble (0); Exit to World Map (0, 1, 48); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,24) facing Up (North); Warp Room -> Submap 1 at (10,255) facing 254; Warp Room -> Submap 254 at (255,254) facing 204 |

---


