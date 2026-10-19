# Suikoden II Geographic Area Catalog: Kuskus Town & River Docks

**Geographic Scope & Role**: River crossing settlement; Tai Ho's ferry landing, stone arched bridge, blacksmith forge, and watermill wheel.

**Regional Category**: Region `VD` | **Master Maps Included**: `vd15`, `vd16`

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

## Location Map: `vd15`

- **Master Map Container**: `vd15.json`
- **Submap Layer Files**: vd15_03.json
- **Collision Grid Files**: vd15_map_00.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 1

### Submap Layer `vd15_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `19` Objects | **Script Count (`evkaz`)**: `25` Scripts

#### Complete Physical Entity Inventory (19 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Market Vegetable Basket** | `65217` | `(30, 30)` | `14x7` | South (Down) | Visible (1) | Special (3) | 4 | 128 | 0 |
| `obj[01]` | NPC / Actor | **Actor ID 65224** | `65224` | `(61, 51)` | `15x8` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[02]` | NPC / Actor | **Actor ID 65040** | `65040` | `(8, 62)` | `9x10` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[03]` | NPC / Actor | **Actor ID 64550** | `64550` | `(41, 30)` | `0x0` | West (Left) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | NPC / Actor | **Actor ID 64546** | `64546` | `(37, 30)` | `0x0` | West (Left) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | NPC / Actor | **Actor ID 64566** | `64566` | `(63, 48)` | `0x0` | West (Left) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | Trigger / Hitbox | **Hitbox Zone (2x4)** | `0` | `(21, 36)` | `1x3` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(22, 27)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(26, 27)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Trigger / Hitbox | **Hitbox Zone (2x4)** | `0` | `(28, 36)` | `1x3` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Trigger / Hitbox | **Hitbox Zone (2x4)** | `0` | `(28, 42)` | `1x3` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Trigger / Hitbox | **Hitbox Zone (9x2)** | `0` | `(39, 34)` | `8x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | Trigger / Hitbox | **Hitbox Zone (2x4)** | `0` | `(46, 31)` | `1x3` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | Trigger / Hitbox | **Hitbox Zone (8x3)** | `0` | `(33, 62)` | `7x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | Trigger / Hitbox | **Hitbox Zone (2x4)** | `0` | `(38, 60)` | `1x3` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[15]` | Trigger / Hitbox | **Hitbox Zone (8x4)** | `0` | `(46, 64)` | `7x3` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[16]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(58, 63)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[17]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(62, 63)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[18]` | Trigger / Hitbox | **Hitbox Zone (6x2)** | `0` | `(55, 63)` | `5x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Market Vegetable Basket)**: Positioned at tile `(30, 30)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Object 65224)**: Positioned at tile `(61, 51)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Object 65040)**: Positioned at tile `(8, 62)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Object 64550)**: Positioned at tile `(41, 30)`, facing West (Left). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Object 64546)**: Positioned at tile `(37, 30)`, facing West (Left). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Object 64566)**: Positioned at tile `(63, 48)`, facing West (Left). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[06]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `4` tiles high from `(21, 36)` to `(22, 39)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[07]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(22, 27)` to `(25, 28)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[08]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(26, 27)` to `(29, 28)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[09]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `4` tiles high from `(28, 36)` to `(29, 39)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[10]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `4` tiles high from `(28, 42)` to `(29, 45)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[11]` (Hitbox Zone)**: Bounding trigger area covering `9` tiles wide by `2` tiles high from `(39, 34)` to `(47, 35)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[12]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `4` tiles high from `(46, 31)` to `(47, 34)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[13]` (Hitbox Zone)**: Bounding trigger area covering `8` tiles wide by `3` tiles high from `(33, 62)` to `(40, 64)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[14]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `4` tiles high from `(38, 60)` to `(39, 63)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[15]` (Hitbox Zone)**: Bounding trigger area covering `8` tiles wide by `4` tiles high from `(46, 64)` to `(53, 67)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[16]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(58, 63)` to `(60, 65)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[17]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(62, 63)` to `(64, 65)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[18]` (Hitbox Zone)**: Bounding trigger area covering `6` tiles wide by `2` tiles high from `(55, 63)` to `(60, 64)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (25 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Target Inspected is obj[8] | Dismiss Emotion Bubble (0); Warp Room -> Submap 23 at (7,0) facing 255 |
| `ev[01]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Dismiss Emotion Bubble (0); Warp Room -> Submap 23 at (7,1) facing 255 |
| `ev[02]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #38 AND Player Y within Range [5..10] | Open Dialogue Sub-Window (2); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[03]` | `1 (Action / Talk)` | Story Flag 112 (bit 64) SET AND Target Inspected is obj[10] | Open Dialogue Sub-Window (1); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[04]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Open Dialogue Sub-Window (0); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[05]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Dismiss Emotion Bubble (0); Warp Room -> Submap 23 at (7,3) facing East (Right); Close Dialogue Window; Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[06]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Dismiss Emotion Bubble (0); Warp Room -> Submap 23 at (7,4) facing East (Right); Display Dialogue Box [Bank: 1, MsgID: 255] |
| `ev[07]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Dismiss Emotion Bubble (0); Warp Room -> Submap 23 at (7,5) facing East (Right); Place Scenery Structure (1) |
| `ev[08]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Close Dialogue Sub-Window (14); Reset Camera Tracking (0) |
| `ev[09]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Close Dialogue Sub-Window (15); Reset Camera Tracking (1) |
| `ev[10]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Close Dialogue Sub-Window (16); Reset Camera Tracking (2) |
| `ev[11]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Close Dialogue Sub-Window (17); Reset Camera Tracking (3) |
| `ev[12]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Close Dialogue Sub-Window (18); Reset Camera Tracking (4) |
| `ev[13]` | `1 (Action / Talk)` | Target Inspected is obj[19] | Close Dialogue Sub-Window (19); Reset Camera Tracking (5) |
| `ev[14]` | `1 (Action / Talk)` | Target Inspected is obj[20] | Close Dialogue Sub-Window (20); Reset Camera Tracking (6) |
| `ev[15]` | `1 (Action / Talk)` | Target Inspected is obj[21] | Close Dialogue Sub-Window (21); Reset Camera Tracking (7) |
| `ev[16]` | `1 (Action / Talk)` | Target Inspected is obj[22] | Close Dialogue Sub-Window (22); Reset Camera Tracking (8) |
| `ev[17]` | `1 (Action / Talk)` | Target Inspected is obj[23] | Close Dialogue Sub-Window (23); Reset Camera Tracking (9) |
| `ev[18]` | `1 (Action / Talk)` | Target Inspected is obj[24] | Close Dialogue Sub-Window (24); Reset Camera Tracking (10) |
| `ev[19]` | `1 (Action / Talk)` | Target Inspected is obj[25] | Close Dialogue Sub-Window (25); Reset Camera Tracking (11) |
| `ev[20]` | `1 (Action / Talk)` | Target Inspected is obj[26] | Close Dialogue Sub-Window (26); Reset Camera Tracking (12) |
| `ev[21]` | `128 (Loop)` | Player within Box [20..21, 2..59] AND Condition Check #76 AND Story Flag 2 (mask 255) SET | Warp Room -> Submap 0 at (3,0) |
| `ev[22]` | `1 (Action / Talk)` | Player within Box [0..1, 2..59] AND Condition Check #76 AND Story Flag 2 (mask 255) SET | Engine Action #99; Engine Action #6; Exit to World Map (32, 3, 0); Engine Action #121; Warp Map Transition (255, 254, 204, 204, 204) |
| `ev[23]` | `128 (Loop)` | Player within Box [55..56, 2..59] AND Condition Check #76 AND Story Flag 3 (mask 255) SET | Warp Room -> Submap 0 at (3,15) |
| `ev[24]` | `1 (Action / Talk)` | Player within Box [83..84, 2..59] AND Condition Check #76 AND Story Flag 3 (mask 255) SET | Warp Map Transition (3, 0, 3, 69, 255) |

---



## Location Map: `vd16`

- **Master Map Container**: `vd16.json`
- **Submap Layer Files**: vd16_01.json, vd16_11.json
- **Collision Grid Files**: vd16_map_00.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 1

### Submap Layer `vd16_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `55` Objects | **Script Count (`evkaz`)**: `52` Scripts

#### Complete Physical Entity Inventory (55 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 65104** | `65104` | `(39, 61)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Actor ID 65104** | `65104` | `(42, 61)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | Prop / Scenery | **Prop ID 35858** | `35858` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | NPC / Actor | **Jowy (Camp/Prologue)** | `18` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[04]` | NPC / Actor | **Eilie** | `19` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | NPC / Actor | **Rina** | `20` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | NPC / Actor | **Bolgan** | `21` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | NPC / Actor | **Pilika (Traumatized)** | `123` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | NPC / Actor | **Richmond** | `38` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[09]` | NPC / Actor | **Humphrey Mintz** | `100` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[10]` | NPC / Actor | **Chaco** | `54` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | NPC / Actor | **Futch** | `101` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | NPC / Actor | **Actor ID 143** | `143` | `(0, 0)` | `0x0` | Up (North) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | NPC / Actor | **Actor ID 65104** | `65104` | `(0, 0)` | `0x0` | Up (North) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | NPC / Actor | **Actor ID 65104** | `65104` | `(0, 0)` | `0x0` | Up (North) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[15]` | NPC / Actor | **Actor ID 65098** | `65098` | `(0, 0)` | `0x0` | Up (North) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[16]` | NPC / Actor | **Village Fence Gate** | `65099` | `(0, 0)` | `0x0` | Up (North) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[17]` | NPC / Actor | **Storage Sack / Flour Bag** | `65079` | `(0, 0)` | `0x0` | Up (North) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[18]` | NPC / Actor | **Actor ID 65187** | `65187` | `(0, 0)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[19]` | NPC / Actor | **Actor ID 65186** | `65186` | `(0, 0)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[20]` | NPC / Actor | **Actor ID 65209** | `65209` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[21]` | NPC / Actor | **Actor ID 65224** | `65224` | `(0, 0)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[22]` | NPC / Actor | **Actor ID 65225** | `65225` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[23]` | NPC / Actor | **Actor ID 65188** | `65188` | `(0, 0)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[24]` | World Device | **Mechanism (ano 4)** | `0` | `(0, 0)` | `0x0` | Frame 4 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[25]` | World Device | **Mechanism (ano 28)** | `0` | `(0, 0)` | `0x0` | Frame 28 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[26]` | NPC / Actor | **Actor ID 65187** | `65187` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[27]` | NPC / Actor | **Village Fence Gate** | `65099` | `(38, 91)` | `13x6` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[28]` | NPC / Actor | **Actor ID 64545** | `64545` | `(33, 63)` | `3x3` | South (Down) | Visible (1) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[29]` | Trigger / Hitbox | **Hitbox Zone (2x3)** | `0` | `(33, 63)` | `1x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[30]` | NPC / Actor | **Actor ID 65179** | `65179` | `(53, 67)` | `15x8` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[31]` | NPC / Actor | **Actor ID 65184** | `65184` | `(44, 72)` | `9x10` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[32]` | NPC / Actor | **Market Vegetable Basket** | `65217` | `(21, 27)` | `12x5` | South (Down) | Visible (1) | Special (3) | 4 | 128 | 0 |
| `obj[33]` | NPC / Actor | **Actor ID 65180** | `65180` | `(59, 68)` | `13x4` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[34]` | Trigger / Hitbox | **Hitbox Zone (9x2)** | `0` | `(53, 59)` | `8x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[35]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(12, 64)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[36]` | Trigger / Hitbox | **Hitbox Zone (5x2)** | `0` | `(31, 65)` | `4x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[37]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(50, 64)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[38]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(26, 24)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[39]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(12, 24)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[40]` | Trigger / Hitbox | **Hitbox Zone (12x3)** | `0` | `(13, 45)` | `11x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[41]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(28, 25)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[42]` | Trigger / Hitbox | **Hitbox Zone (5x3)** | `0` | `(32, 24)` | `4x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[43]` | Trigger / Hitbox | **Hitbox Zone (5x2)** | `0` | `(38, 23)` | `4x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[44]` | Trigger / Hitbox | **Hitbox Zone (2x4)** | `0` | `(12, 43)` | `1x3` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[45]` | Trigger / Hitbox | **Hitbox Zone (2x3)** | `0` | `(35, 50)` | `1x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[46]` | Trigger / Hitbox | **Hitbox Zone (7x3)** | `0` | `(16, 63)` | `6x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[47]` | Trigger / Hitbox | **Hitbox Zone (8x4)** | `0` | `(22, 62)` | `7x3` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[48]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(47, 63)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[49]` | Trigger / Hitbox | **Hitbox Zone (4x3)** | `0` | `(48, 61)` | `3x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[50]` | Trigger / Hitbox | **Hitbox Zone (13x11)** | `0` | `(56, 69)` | `12x10` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[51]` | Trigger / Hitbox | **Hitbox Zone (5x2)** | `0` | `(60, 65)` | `4x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[52]` | Trigger / Hitbox | **Hitbox Zone (7x2)** | `0` | `(64, 65)` | `6x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[53]` | Trigger / Hitbox | **Hitbox Zone (2x5)** | `0` | `(66, 66)` | `1x4` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[54]` | Trigger / Hitbox | **Hitbox Zone (2x9)** | `0` | `(35, 89)` | `1x8` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 65104)**: Positioned at tile `(39, 61)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Object 65104)**: Positioned at tile `(42, 61)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Prop: Object 35858)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[03]` (Jowy (Camp/Prologue))**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Eilie)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Rina)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[06]` (Bolgan)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[07]` (Pilika (Traumatized))**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[08]` (Richmond)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[09]` (Humphrey Mintz)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[10]` (Chaco)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[11]` (Futch)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[12]` (Object 143)**: Positioned at tile `(0, 0)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[13]` (Object 65104)**: Positioned at tile `(0, 0)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[14]` (Object 65104)**: Positioned at tile `(0, 0)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[15]` (Object 65098)**: Positioned at tile `(0, 0)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[16]` (Village Fence Gate)**: Positioned at tile `(0, 0)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[17]` (Storage Sack / Flour Bag)**: Positioned at tile `(0, 0)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[18]` (Object 65187)**: Positioned at tile `(0, 0)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[19]` (Object 65186)**: Positioned at tile `(0, 0)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[20]` (Object 65209)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[21]` (Object 65224)**: Positioned at tile `(0, 0)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[22]` (Object 65225)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[23]` (Object 65188)**: Positioned at tile `(0, 0)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[24]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(0, 0)` with state parameter `4`.
- **`obj[25]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(0, 0)` with state parameter `28`.
- **`obj[26]` (Object 65187)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[27]` (Village Fence Gate)**: Positioned at tile `(38, 91)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[28]` (Object 64545)**: Positioned at tile `(33, 63)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[29]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `3` tiles high from `(33, 63)` to `(34, 65)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[30]` (Object 65179)**: Positioned at tile `(53, 67)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[31]` (Object 65184)**: Positioned at tile `(44, 72)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[32]` (Market Vegetable Basket)**: Positioned at tile `(21, 27)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[33]` (Object 65180)**: Positioned at tile `(59, 68)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[34]` (Hitbox Zone)**: Bounding trigger area covering `9` tiles wide by `2` tiles high from `(53, 59)` to `(61, 60)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[35]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(12, 64)` to `(14, 66)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[36]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `2` tiles high from `(31, 65)` to `(35, 66)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[37]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(50, 64)` to `(52, 66)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[38]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(26, 24)` to `(28, 26)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[39]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(12, 24)` to `(15, 25)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[40]` (Hitbox Zone)**: Bounding trigger area covering `12` tiles wide by `3` tiles high from `(13, 45)` to `(24, 47)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[41]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(28, 25)` to `(30, 26)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[42]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `3` tiles high from `(32, 24)` to `(36, 26)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[43]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `2` tiles high from `(38, 23)` to `(42, 24)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[44]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `4` tiles high from `(12, 43)` to `(13, 46)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[45]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `3` tiles high from `(35, 50)` to `(36, 52)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[46]` (Hitbox Zone)**: Bounding trigger area covering `7` tiles wide by `3` tiles high from `(16, 63)` to `(22, 65)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[47]` (Hitbox Zone)**: Bounding trigger area covering `8` tiles wide by `4` tiles high from `(22, 62)` to `(29, 65)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[48]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(47, 63)` to `(48, 64)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[49]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `3` tiles high from `(48, 61)` to `(51, 63)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[50]` (Hitbox Zone)**: Bounding trigger area covering `13` tiles wide by `11` tiles high from `(56, 69)` to `(68, 79)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[51]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `2` tiles high from `(60, 65)` to `(64, 66)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[52]` (Hitbox Zone)**: Bounding trigger area covering `7` tiles wide by `2` tiles high from `(64, 65)` to `(70, 66)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[53]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `5` tiles high from `(66, 66)` to `(67, 70)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[54]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `9` tiles high from `(35, 89)` to `(36, 97)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (52 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Target Inspected is obj[35] | Dismiss Emotion Bubble (0); Warp Room -> Submap 23 at (7,0) facing 255 |
| `ev[01]` | `1 (Action / Talk)` | Target Inspected is obj[36] | Dismiss Emotion Bubble (0); Warp Room -> Submap 23 at (7,1) facing East (Right); Launch Tactical War Battle (0) |
| `ev[02]` | `1 (Action / Talk)` | Target Inspected is obj[38] | Dismiss Emotion Bubble (0); Warp Room -> Submap 23 at (7,2) facing 255 |
| `ev[03]` | `1 (Action / Talk)` | Target Inspected is obj[39] | Dismiss Emotion Bubble (0); Warp Room -> Submap 23 at (7,3) facing 255 |
| `ev[04]` | `2 (Map Init)` | Story Flag 143 (bit 2) SET AND Story Flag 143 (bit 1) CLEAR | Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[05]` | `1 (Action / Talk)` | Target Inspected is obj[40] | Dismiss Emotion Bubble (0); Warp Room -> Submap 23 at (7,4) facing 255 |
| `ev[06]` | `1 (Action / Talk)` | Target Inspected is obj[41] | Dismiss Emotion Bubble (0); Warp Room -> Submap 23 at (7,5) facing 255 |
| `ev[07]` | `1 (Action / Talk)` | Target Inspected is obj[42] AND Story Flag 1 (mask 255) SET | Close Dialogue Sub-Window (42); Reset Camera Tracking (0) |
| `ev[08]` | `1 (Action / Talk)` | Target Inspected is obj[43] | Close Dialogue Sub-Window (43); Reset Camera Tracking (1) |
| `ev[09]` | `1 (Action / Talk)` | Target Inspected is obj[44] AND Story Flag 1 (mask 255) SET | Warp to Castle HQ (36, 0, 30); Open Dialogue Message Window; Warp Room -> Submap 23 at (7,1) facing 255 |
| `ev[10]` | `1 (Action / Talk)` | Target Inspected is obj[45] | Close Dialogue Sub-Window (45); Reset Camera Tracking (3) |
| `ev[11]` | `1 (Action / Talk)` | Target Inspected is obj[46] | Close Dialogue Sub-Window (46); Reset Camera Tracking (4) |
| `ev[12]` | `1 (Action / Talk)` | Target Inspected is obj[47] AND Story Flag 1 (mask 255) SET | Close Dialogue Sub-Window (47); Reset Camera Tracking (5) |
| `ev[13]` | `1 (Action / Talk)` | Target Inspected is obj[48] AND Story Flag 0 (mask 255) SET | Close Dialogue Sub-Window (48); Reset Camera Tracking (6) |
| `ev[14]` | `1 (Action / Talk)` | Target Inspected is obj[49] | Close Dialogue Sub-Window (49); Reset Camera Tracking (7) |
| `ev[15]` | `1 (Action / Talk)` | Target Inspected is obj[50] | Close Dialogue Sub-Window (50); Reset Camera Tracking (8) |
| `ev[16]` | `1 (Action / Talk)` | Target Inspected is obj[51] | Close Dialogue Sub-Window (51); Reset Camera Tracking (9) |
| `ev[17]` | `1 (Action / Talk)` | Target Inspected is obj[52] | Close Dialogue Sub-Window (52); Reset Camera Tracking (10) |
| `ev[18]` | `1 (Action / Talk)` | Target Inspected is obj[53] | Close Dialogue Sub-Window (53); Reset Camera Tracking (11) |
| `ev[19]` | `1 (Action / Talk)` | Target Inspected is obj[54] | Close Dialogue Sub-Window (54); Reset Camera Tracking (12) |
| `ev[20]` | `1 (Action / Talk)` | Target Inspected is obj[55] | Close Dialogue Sub-Window (55); Reset Camera Tracking (13) |
| `ev[21]` | `1 (Action / Talk)` | Target Inspected is obj[56] | Close Dialogue Sub-Window (56); Reset Camera Tracking (14) |
| `ev[22]` | `1 (Action / Talk)` | Target Inspected is obj[57] | Close Dialogue Sub-Window (57); Reset Camera Tracking (15) |
| `ev[23]` | `1 (Action / Talk)` | Target Inspected is obj[58] | Close Dialogue Sub-Window (58); Reset Camera Tracking (16) |
| `ev[24]` | `1 (Action / Talk)` | Target Inspected is obj[59] | Close Dialogue Sub-Window (59); Reset Camera Tracking (17) |
| `ev[25]` | `1 (Action / Talk)` | Target Inspected is obj[60] | Close Dialogue Sub-Window (60); Reset Camera Tracking (18) |
| `ev[26]` | `1 (Action / Talk)` | Target Inspected is obj[61] | Close Dialogue Sub-Window (61); Reset Camera Tracking (19) |
| `ev[27]` | `1 (Action / Talk)` | Target Inspected is obj[62] | Close Dialogue Sub-Window (62); Reset Camera Tracking (20) |
| `ev[28]` | `2 (Map Init)` | Story Flag 86 (bit 128) SET AND Story Flag 112 (bit 64) CLEAR | Make obj[0] Hidden (disp = 0); Reset Camera Tracking (0); Engine Action #9; Teleport obj[255] to (254,255) |
| `ev[29]` | `1 (Action / Talk)` | Story Flag 86 (bit 128) SET AND Story Flag 112 (bit 64) CLEAR AND Target Inspected is obj[8] | Close Dialogue Sub-Window (8); Warp Town -> Area 0 Map 5 Submap 0 at (7,1); Dismiss Emotion Bubble (255) |
| `ev[30]` | `1 (Action / Talk)` | Story Flag 86 (bit 128) SET AND Story Flag 112 (bit 64) CLEAR AND Target Inspected is obj[9] | Close Dialogue Sub-Window (9); Warp Town -> Area 1 Map 5 Submap 0 at (7,1); Dismiss Emotion Bubble (255) |
| `ev[31]` | `2 (Map Init)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR | Make obj[0] Hidden (disp = 0); Reset Camera Tracking (0); Engine Action #9; Teleport obj[255] to (254,255) |
| `ev[32]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[8] | Close Dialogue Sub-Window (8); Warp Town -> Area 2 Map 5 Submap 0 at (7,1); Dismiss Emotion Bubble (255) |
| `ev[33]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[9] | Close Dialogue Sub-Window (9); Warp Town -> Area 3 Map 5 Submap 0 at (7,1); Dismiss Emotion Bubble (255) |
| `ev[34]` | `1 (Action / Talk)` | Story Flag 21 (bit 4) SET AND Story Flag 154 (bit 1) CLEAR | Make obj[1] Hidden (disp = 0); Engine Action #40; Warp Town -> Area 32 Map 8 Submap 36 at (0,32); Warp Town -> Area 16 Map 34 Submap 28 at (2,17); Warp Room -> Submap 30 at (2,13); Open Save Crystal Menu (MSaveInit); Fade Out to Black (2); Open Dialogue Message Window; Open Save Crystal Menu (MSaveInit); Warp Room -> Submap 2 at (12,38); Start Boss Battle #2 (BGM: 14); Award Potch Loot (+6,914 Potch); Show Dialogue Portrait (41, 31, 2); Close Dialogue Window; Award Potch Loot (+8,963 Potch); Dismiss Dialogue Portrait; Warp to Castle HQ (3, 17, 3); Warp to Castle HQ (0, 2, 3); Place Scenery Structure (2); Warp to Castle HQ (12, 2, 3); Close Dialogue Window; Warp Town -> Area 3 Map 15 Submap 2 at (3,14); Warp Town -> Area 0 Map 16 Submap 0 at (17,0); Place Scenery Structure (0); Display Dialogue Box [Bank: 0, MsgID: 11]; Open Dialogue Message Window; Show Dialogue Portrait (0, 14, 47); Close Dialogue Window; Warp Room -> Submap 40 at (24,16) facing South (Down); Open Dialogue Message Window; Engine Action #5; Place Scenery Structure (2); Warp Room -> Submap 24 at (13,0) facing West (Left); Warp to Castle HQ (12, 1, 24); Display Dialogue Box [Bank: 0, MsgID: 2]; Warp to Castle HQ (17, 0, 24); Change Portrait Expression (0); Warp to Castle HQ (3, 15, 1); Warp to Castle HQ (14, 0, 49); Warp Town -> Area 5 Map 14 Submap 0 at (1,30); Engine Action #5; Show Dialogue Portrait (1, 2, 30); Walk obj[9] to (154,128); Close Dialogue Sub-Window (14); Open Dialogue Message Window; Exit to World Map (24, 11, 0); Engine Action #5; Open Shop Menu #2 (Type: 12); Set Animation Pose (12, 0); Warp to Castle HQ (0, 0, 2); Reset Camera Tracking (24); Display Dialogue Box [Bank: 0, MsgID: 6]; Warp to Castle HQ (11, 1, 43); Display Dialogue Box [Bank: 1, MsgID: 56]; Display Dialogue Box [Bank: 0, MsgID: 3]; Open Dialogue Message Window; Open Dialogue Message Window; Warp Room -> Submap 73 at (30,3) facing 11; Open Dialogue Message Window; Load Sound Bank into Memory (1, 11); Engine Action #9; Close Dialogue Sub-Window (11); Open Dialogue Message Window; Pan Camera (9, 154, 64); Set Combat Battle BGM (30); Load Sound Bank into Memory (0, 11); Set Entity Movement Speed (2, 5); Dismiss Dialogue Portrait; Warp Town -> Area 18 Map 0 Submap 5 at (30,1); Dismiss Dialogue Portrait; Engine Action #5; Change Portrait Expression (2); Show Dialogue Portrait (0, 3, 30); Warp Room -> Submap 255 at (254,50) facing 46; Open Shop Menu #5 (Type: 13); Open Shop Menu #5 (Type: 12); Open Shop Menu #5 (Type: 11); Open Shop Menu #5 (Type: 15); Open Shop Menu #5 (Type: 14); Teleport obj[49] to (5,48); Place Scenery Structure (0); Warp Town -> Area 0 Map 1 Submap 0 at (8,1); Place Scenery Structure (255); Turn obj[12] facing South (Down); Warp Town -> Area 0 Map 1 Submap 0 at (8,1); Display Dialogue Box [Bank: 255, MsgID: 254]; Turn obj[11] facing South (Down); Warp Town -> Area 0 Map 1 Submap 0 at (8,1); Close Dialogue Window; Turn obj[15] facing South (Down); Warp Town -> Area 0 Map 1 Submap 0 at (8,1); Show Dialogue Portrait (255, 254, 48); Animate Door Open; Open Dialogue Message Window; Warp Town -> Area 0 Map 1 Submap 0 at (8,1); Animate Door Open; Walk obj[124] to (9,64); Show Character Dialogue Portrait (10, 64, 124); Display Dialogue Box [Bank: 64, MsgID: 124]; Toggle Random Encounters (64); Show Character Dialogue Portrait (47, 64, 9); Engine Action #154; Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[35]` | `128 (Loop)` | Story Flag 154 (bit 128) SET AND Story Flag 154 (bit 64) CLEAR | Award Potch Currency (14,6); Warp Room -> Submap 77 at (15,6) facing West (Left); Dismiss Emotion Bubble (255) |
| `ev[36]` | `128 (Loop)` | Story Flag 156 (bit 1) SET AND Story Flag 156 (bit 2) CLEAR AND Inventory Holds Item #1 | Warp Room -> Submap 2 at (13,28); Toggle Random Encounters (1) |
| `ev[37]` | `2 (Map Init)` | Story Flag 156 (bit 1) SET AND Story Flag 156 (bit 2) CLEAR | Make obj[1] Hidden (disp = 0); Start Boss Battle #1 (BGM: 36); Warp Room -> Submap 1 at (39,1) facing 40; Warp Town -> Area 20 Map 41 Submap 69 at (0,20); Warp Town -> Area 21 Map 39 Submap 67 at (0,21); Warp Town -> Area 22 Map 39 Submap 71 at (0,22); Warp Town -> Area 26 Map 37 Submap 67 at (0,26); Warp Town -> Area 27 Map 37 Submap 71 at (0,27); Warp Town -> Area 28 Map 39 Submap 65 at (0,28); Warp Town -> Area 29 Map 39 Submap 73 at (0,29); Warp Town -> Area 23 Map 20 Submap 69 at (0,23); Warp Town -> Area 24 Map 24 Submap 73 at (0,24); Warp Town -> Area 25 Map 18 Submap 67 at (0,25); Warp Town -> Area 31 Map 14 Submap 67 at (0,31); Teleport obj[255] to (254,255) |
| `ev[38]` | `1 (Action / Talk)` | Story Flag 156 (bit 1) SET AND Story Flag 156 (bit 2) CLEAR | Launch Tactical War Battle (1); Warp Town -> Area 0 Map 3 Submap 69 at (3,0); Warp to Castle HQ (73, 20, 24); Clear Dialogue Sub-Window; Warp Room -> Submap 3 at (31,2) facing 24; Warp Room -> Submap 1 at (3,43); Open Dialogue Sub-Window (5); Set Animation Pose (23, 0); Warp to Castle HQ (3, 1, 0); Reset Camera Tracking (24); Open Dialogue Sub-Window (1); Exit to World Map (43, 23, 4); Set Character Quest Milestone (0, 11); Open Dialogue Message Window; Close Dialogue Window; Set Entity Movement Speed (3, 4); Open Dialogue Sub-Window (33); Full Rest & Healing (Restore HP/MP); Reset Camera Tracking (255); Exit to World Map (0, 29, 69); Reset Camera Tracking (255); Exit to World Map (11, 29, 71); Engine Action #9; Walk obj[3] to (23,1); Warp to Castle HQ (24, 3, 3); Warp Room -> Submap 3 at (101,9); Pan Camera (73, 60, 101); Warp Room -> Submap 24 at (20,1) facing 5; Set Entity Movement Speed (7, 5); Fade In from Black (1); Warp to Castle HQ (2, 0, 30); Engine Action #5; Fade Out to Black (0); Warp to Castle HQ (2, 0, 30); Engine Action #5; Display Chapter Text (3); Warp Town -> Area 2 Map 0 Submap 30 at (255,254); Engine Action #5; Display Emotion Bubble (3, 2); Warp Town -> Area 0 Map 30 Submap 255 at (254,5); Execute Choice Result (1); Warp Town -> Area 2 Map 0 Submap 30 at (255,254); Engine Action #5; Set Story Flag (0, 2); Warp Town -> Area 0 Map 30 Submap 255 at (254,5); Branch on Choice (2, 5); Dismiss Emotion Bubble (255); Walk obj[43] to (11,5); Set Animation Pose (11, 0); Warp to Castle HQ (2, 0, 0); Reset Camera Tracking (3); Close Dialogue Window; Warp to Castle HQ (43, 11, 4); Make obj[106] Hidden (disp = 0); Close Dialogue Window; Screen Fade Transition (1, 11, 0); Screen Fade Transition (47, 89, 10); Warp Town -> Area 8 Map 24 Submap 11 at (1,6); Set Animation Pose (20, 0); Warp to Castle HQ (6, 1, 0); Reset Camera Tracking (24); Branch on Choice (1, 7); Set Combat Battle BGM (100); Engine Action #89; Screen Fade Transition (2, 9, 89); Screen Fade Transition (5, 89, 10); Engine Action #5; Make obj[1] Hidden (disp = 0); Screen Fade Transition (0, 11, 47); Set Animation Pose (11, 20); Warp Town -> Area 3 Map 0 Submap 2 at (9,3); Close Dialogue Window; Warp to Castle HQ (73, 30, 56); Open Dialogue Message Window; Branch on Choice (2, 3); Warp Room -> Submap 8 at (24,11) facing West (Left); Reset Camera Tracking (24); Branch on Choice (1, 9); Load Sound Bank into Memory (1, 11); Warp Town -> Area 73 Map 30 Submap 72 at (0,11); Close Dialogue Sub-Window (11); Warp Room -> Submap 24 at (20,1) facing 11; Close Dialogue Sub-Window (11); Warp Room -> Submap 24 at (20,1) facing 13; Close Dialogue Sub-Window (11); Warp Room -> Submap 24 at (20,1) facing 15; Warp to Castle HQ (11, 1, 24); Close Dialogue Window; Warp Room -> Submap 24 at (20,1) facing 17; Engine Action #5; Execute Choice Result (0); Warp Town -> Area 2 Map 2 Submap 30 at (24,21); Warp Room -> Submap 3 at (20,3) facing 73; Dismiss Emotion Bubble (3); Branch on Choice (2, 24); Branch on Choice (1, 19); Warp to Castle HQ (11, 3, 24); Close Dialogue Window; Warp Room -> Submap 101 at (9,8) facing 48; Branch on Choice (0, 2); Open Dialogue Message Window; Warp Room -> Submap 8 at (1,20) facing 54; Open Dialogue Message Window; Warp Room -> Submap 4 at (1,1) facing 143; Open Dialogue Message Window; Recruit Jowy Atreides into Battle Slot 0; Jump to Bytecode Offset (1, 0); Open Shop Menu #5 (Type: 28); Open Shop Menu #5 (Type: 29); Set Entity Movement Speed (2, 55); Display Chapter Text (44); Play CD / Ambient BGM Track (8); Set Render Priority (pri) (29, 47); Play CD / Ambient BGM Track (8); Walk obj[3] to (28,3); Warp to Castle HQ (29, 2, 28); Warp to Castle HQ (10, 5, 24); Display Chapter Text (1); Execute Choice Result (24); Display Emotion Bubble (1, 22); Close Dialogue Sub-Window (28); Warp Room -> Submap 11 at (2,2) facing 100; Display Emotion Bubble (7, 46); Open Dialogue Message Window; Start Boss Battle #0 (BGM: 36); Open Dialogue Message Window; Open Save Crystal Menu (MSaveInit); Open Dialogue Message Window; Engine Action #39; Warp Room -> Submap 1 at (24,1) facing 25; Warp Room -> Submap 1 at (27,1) facing 28; Warp Room -> Submap 1 at (31,1) facing 11; Warp Room -> Submap 1 at (22,47) facing 11; Warp Room -> Submap 100 at (9,47) facing 16; Engine Action #9; Teleport obj[32] to (9,156); Warp Town -> Area 9 Map 123 Submap 4 at (9,144); Dismiss Dialogue Portrait |
| `ev[39]` | `2 (Map Init)` | Story Flag 113 (bit 64) SET AND Story Flag 112 (bit 64) SET AND Condition Check #24 AND Condition Check #38 AND Player Y within Range [4..151] AND Condition Check #64 | Make obj[2] Hidden (disp = 0); Change Portrait Expression (26); Make obj[2] Visible (disp = 1); Dismiss Dialogue Portrait; Display Emotion Bubble (45, 0); Dismiss Dialogue Portrait; Open Dialogue Message Window; Change Portrait Expression (3); Dismiss Dialogue Portrait; Warp Town -> Area 3 Map 17 Submap 3 at (47,255) |
| `ev[40]` | `128 (Loop)` | Condition Check #29 AND Player X within Range [1..255] | Warp Room -> Submap 2 at (13,50); Mark NPC Talk Interaction Complete (Flag #1); Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[41]` | `1 (Action / Talk)` | Condition Check #29 AND Always Passes (Unconditional) AND Player within Box [18..0, 1..255] | Close Dialogue Sub-Window (16); Animate Door Open; Award Potch Loot (+25,600 Potch); Warp Room -> Submap 16 at (2,255) facing 254 |
| `ev[42]` | `1 (Action / Talk)` | Condition Check #29 AND Always Passes (Unconditional) AND Player within Box [18..1, 1..255] | Mark NPC Talk Interaction Complete (Flag #0); Warp Room -> Submap 0 at (1,1) facing 101; Engine Action #9; Reset Camera Tracking (73); Dismiss Emotion Bubble (134); Warp Room -> Submap 70 at (1,1) facing 30; Warp Room -> Submap 155 at (32,41) facing Up (North); Open Dialogue Message Window; Warp Room -> Submap 0 at (24,16) facing 14; Remove Item from Inventory (255, 254); Warp Room -> Submap 16 at (14,43) facing East (Right); Change Portrait Expression (3); Close Dialogue Sub-Window (17); Animate Door Open; Engine Action #44; Close Dialogue Sub-Window (16); Animate Door Open; Make obj[24] Visible (disp = 1); Change Portrait Expression (14); Make obj[115] Hidden (disp = 0); Open Save Crystal Menu (MSaveInit); Fade Out to Black (5); Open Dialogue Message Window; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 101, 4); Engine Action #6; Engine Action #5; Open Dialogue Message Window; Warp Town -> Area 0 Map 5 Submap 3 at (1,0); Engine Action #5; Warp to Castle HQ (3, 0, 5); Warp to Castle HQ (0, 0, 5); Warp to Castle HQ (30, 89, 0); Warp Town -> Area 8 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Engine Action #89; Open Dialogue Message Window; Warp Town -> Area 9 Map 5 Submap 0 at (6,2); Dismiss Emotion Bubble (89); Open Dialogue Message Window; Warp Town -> Area 10 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Dismiss Emotion Bubble (2); Warp Room -> Submap 5 at (0,0) facing South (Down); Engine Action #5; Show Dialogue Portrait (2, 0, 30); Dismiss Character to Castle Base (38); Dismiss Emotion Bubble (84); Open Save Crystal Menu (MSaveInit); Warp Room -> Submap 5 at (0,0); Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 101, 4); Engine Action #6; Engine Action #5; Open Dialogue Message Window; Warp Town -> Area 0 Map 5 Submap 3 at (1,0); Engine Action #5; Warp to Castle HQ (3, 0, 5); Warp to Castle HQ (0, 0, 5); Warp to Castle HQ (30, 89, 0); Warp Town -> Area 8 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Engine Action #89; Open Dialogue Message Window; Warp Town -> Area 9 Map 5 Submap 0 at (6,2); Dismiss Emotion Bubble (89); Open Dialogue Message Window; Warp Town -> Area 10 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Dismiss Emotion Bubble (2); Warp Room -> Submap 5 at (0,0) facing South (Down); Engine Action #5; Show Dialogue Portrait (2, 0, 30); Dismiss Character to Castle Base (100); Dismiss Emotion Bubble (84); Mark NPC Talk Interaction Complete (Flag #31); Dismiss Emotion Bubble (3); Open Dialogue Message Window; Close Dialogue Sub-Window (16); Animate Door Open; Teleport obj[3] to (16,2); Close Dialogue Sub-Window (17); Animate Door Open; Turn obj[43] facing 16; Engine Action #5; Open Shop Menu #5 (Type: 17); Set Entity Movement Speed (2, 4); Dismiss Dialogue Portrait; Engine Action #40; Open Shop Interface #8; Exit to World Map (17, 40, 67); Reset Camera Tracking (255); Walk obj[1] to (16,1); Change Portrait Expression (255) |
| `ev[43]` | `1 (Action / Talk)` | Story Flag 112 (bit 64) SET AND Target Inspected is obj[16] AND Story Flag 155 (bit 16) CLEAR AND Condition Check #24 AND Condition Check #38 AND Player Y within Range [255..254] | Dismiss Character to Castle Base (38); Dismiss Emotion Bubble (84); Mark NPC Talk Interaction Complete (Flag #30); Engine Action #99; Warp Room -> Submap 24 at (16,14) facing 28; Set Combat Battle BGM (20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 14 Map 29 Submap 14 at (30,41); Warp Town -> Area 9 Map 10 Submap 255 at (10,24); Dismiss Dialogue Portrait; Animate Door Open; Warp Room -> Submap 3 at (16,2); Engine Action #9; Close Dialogue Sub-Window (16); Animate Door Open; Warp Map Transition (3, 17, 3, 24, 17); Animate Door Open; Return to Previous Memory Map (24); Dismiss Dialogue Portrait; Animate Door Open; Return Warp to Castle Base (73, 20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 14 Map 35 Submap 14 at (36,41); Warp Town -> Area 11 Map 12 Submap 255 at (12,24); Change Portrait Expression (14); Toggle Random Encounters (3); Dismiss Dialogue Portrait; Warp Town -> Area 24 Map 16 Submap 14 at (38,9); Engine Action #155; Dismiss Dialogue Portrait; Close Dialogue Window; Close Dialogue Sub-Window (16); Animate Door Open; Engine Action #40; Engine Action #9; Engine Action #155; Dismiss Dialogue Portrait; Engine Action #99; Open Dialogue Message Window; Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[44]` | `1 (Action / Talk)` | Story Flag 112 (bit 64) SET AND Target Inspected is obj[16] AND Story Flag 155 (bit 16) SET AND Condition Check #24 AND Condition Check #38 AND Player Y within Range [255..254] | Engine Action #99; Warp Room -> Submap 24 at (16,14) facing 39; Set Combat Battle BGM (20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 14 Map 35 Submap 14 at (36,41); Warp Town -> Area 13 Map 14 Submap 255 at (13,24); Dismiss Dialogue Portrait; Animate Door Open; Engine Action #40; Engine Action #99; Open Dialogue Message Window; Warp Room -> Submap 254 at (255,14) facing 24; Change Portrait Expression (14); Toggle Random Encounters (3); Dismiss Dialogue Portrait; Warp Town -> Area 24 Map 16 Submap 14 at (38,9); Engine Action #155; Dismiss Dialogue Portrait |
| `ev[45]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Close Dialogue Sub-Window (17); Animate Door Open; Set Entity Movement Speed (3, 17); Warp to Castle HQ (255, 254, 255) |
| `ev[46]` | `128 (Loop)` | Condition Check #29 AND Player Y within Range [1..255] | Make obj[1] Hidden (disp = 0); Warp Map Transition (0, 33, 47, 90, 33); Exit to World Map (2, 18, 18); Dismiss Emotion Bubble (255) |
| `ev[47]` | `2 (Map Init)` | Story Flag 114 (bit 1) SET | Make obj[2] Hidden (disp = 0); Warp Map Transition (8, 36, 2, 33, 8); Launch Tactical War Battle (0); Warp Map Transition (2, 34, 37, 28, 0); Return Warp to Castle Base (47, 255) |
| `ev[48]` | `1 (Action / Talk)` | Story Flag 114 (bit 1) SET AND Target Inspected is obj[34] | Close Dialogue Sub-Window (34); Warp Town -> Area 4 Map 73 Submap 20 at (40,0); Open Dialogue Message Window; Warp Town -> Area 2 Map 5 Submap 2 at (6,41); Warp Town -> Area 0 Map 1 Submap 255 at (1,255); Open Dialogue Message Window; Set Entity Movement Speed (2, 4); Return Warp to Castle Base (22, 28); Engine Action #9; Exit to World Map (0, 22, 29); Engine Action #9; Walk obj[46] to (1,34); Warp Room -> Submap 47 at (73,30) facing 99; Warp Town -> Area 1 Map 73 Submap 160 at (122,1); Warp Map Transition (0, 0, 139, 145, 255) |
| `ev[49]` | `128 (Loop)` | Player within Box [37..44, 2..38] AND Condition Check #40 | Warp Room -> Submap 2 at (12,10) |
| `ev[50]` | `128 (Loop)` | Player within Box [20..21, 2..60] AND Condition Check #76 AND Story Flag 2 (mask 255) SET | Warp Room -> Submap 1 at (3,14) |
| `ev[51]` | `1 (Action / Talk)` | Player within Box [0..1, 2..60] AND Condition Check #76 AND Story Flag 2 (mask 255) SET | Warp Map Transition (2, 0, 81, 67, 255) |

---


