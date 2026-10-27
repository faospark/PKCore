# Suikoden II Geographic Area Catalog: Castle HQ: Tetsu's Castle Bathhouse

**Geographic Scope & Role**: Hot springs bathhouse; wooden tubs, steam vents, decorative vases, men's and women's partitions, and special character dialogue bathing scenes.

**Regional Category**: Region `VK` | **Master Maps Included**: `vk06`

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

## Location Map: `vk06`

- **Master Map Container**: `vk06.json`
- **Submap Layer Files**: vk06_17.json, vk06_18.json, vk06_24.json, vk06_25.json, vk06_26.json
- **Collision Grid Files**: vk06_map_00.json, vk06_map_01.json, vk06_map_02.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 4

### Submap Layer `vk06_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `13` Objects | **Script Count (`evkaz`)**: `78` Scripts

#### Complete Physical Entity Inventory (13 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Kiba** | `90` | `(59, 81)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | Prop / Scenery | **Prop ID 53279** | `53279` | `(59, 81)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(58, 80)` | `2x1` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | NPC / Actor | **Tuta** | `71` | `(49, 83)` | `3x2` | East (Right) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[04]` | World Device | **Mechanism (ano 9)** | `0` | `(50, 80)` | `0x0` | Frame 9 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[05]` | World Device | **Mechanism (ano 1)** | `0` | `(50, 87)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[06]` | World Device | **Mechanism (ano 1)** | `0` | `(54, 87)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[07]` | NPC / Actor | **Actor ID 65089** | `65089` | `(66, 92)` | `0x0` | Up (North) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[08]` | NPC / Actor | **Actor ID 65072** | `65072` | `(50, 21)` | `7x3` | South (Down) | Dormant / Hidden (0) | Special (3) | 2 | 128 | 0 |
| `obj[09]` | NPC / Actor | **Actor ID 65042** | `65042` | `(113, 43)` | `3x3` | South (Down) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[10]` | NPC / Actor | **Actor ID 65182** | `65182` | `(54, 90)` | `3x3` | South (Down) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[11]` | NPC / Actor | **Actor ID 65105** | `65105` | `(45, 95)` | `3x3` | South (Down) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[12]` | NPC / Actor | **Actor ID 65105** | `65105` | `(33, 34)` | `3x3` | South (Down) | Dormant / Hidden (0) | Special (3) | 1 | 128 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Kiba)**: Positioned at tile `(59, 81)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Prop: Object 53279)**: Environmental world dressing prop placed at tile `(59, 81)`. Solid collision is set to `0`.
- **`obj[02]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(58, 80)` to `(60, 81)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[03]` (Tuta)**: Positioned at tile `(49, 83)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(50, 80)` with state parameter `9`.
- **`obj[05]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(50, 87)` with state parameter `1`.
- **`obj[06]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(54, 87)` with state parameter `1`.
- **`obj[07]` (Object 65089)**: Positioned at tile `(66, 92)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[08]` (Object 65072)**: Positioned at tile `(50, 21)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[09]` (Object 65042)**: Positioned at tile `(113, 43)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[10]` (Object 65182)**: Positioned at tile `(54, 90)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[11]` (Object 65105)**: Positioned at tile `(45, 95)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[12]` (Object 65105)**: Positioned at tile `(33, 34)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.


#### Complete Bytecode Script Catalog (78 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #90 AND Player X within Range [255..254] | Make obj[89] Hidden (disp = 0); Engine Action #9; Warp Town -> Area 3 Map 0 Submap 9 at (0,10); Teleport obj[255] to (254,204) |
| `ev[01]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #90 AND Player Y within Range [255..254] | Make obj[0] Hidden (disp = 0); Place Scenery Structure (0); Animate Door Open; Teleport obj[255] to (254,204) |
| `ev[02]` | `2 (Map Init)` | Condition Check #24 AND Condition Check #90 AND Player Y within Range [255..254] | Make obj[0] Hidden (disp = 0); Display Dialogue Box [Bank: 47, MsgID: 255] |
| `ev[03]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Condition Check #23 AND Condition Check #90 AND Player within Box [1..56, 57..5] AND Story Flag 255 (mask 254) CLEAR | Engine Action #89; Engine Action #9; Warp Town -> Area 4 Map 24 Submap 8 at (0,0); Engine Action #89; Engine Action #9; Warp Town -> Area 3 Map 73 Submap 20 at (108,24) |
| `ev[04]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Condition Check #23 AND Condition Check #90 AND Player within Box [1..61, 62..5] AND Story Flag 255 (mask 254) CLEAR | Engine Action #89; Engine Action #9; Warp Town -> Area 5 Map 24 Submap 8 at (0,0); Engine Action #89; Engine Action #9; Warp Town -> Area 3 Map 73 Submap 20 at (108,24) |
| `ev[05]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Condition Check #23 AND Condition Check #90 AND Player within Box [5..10, 255..254] | Close Dialogue Sub-Window (8); Open Dialogue Message Window; Open Dialogue Message Window; Set Combat Battle BGM (20); Engine Action #108; Close Dialogue Sub-Window (255) |
| `ev[06]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Condition Check #23 AND Condition Check #90 AND Player within Box [1..50, 58..2] AND Condition Check #80 AND Condition Check #81 | Exit to World Map (0, 56, 82); Engine Action #9; Warp to Castle HQ (0, 3, 89); Engine Action #9; Warp Town -> Area 4 Map 24 Submap 8 at (0,0); Set Combat Battle BGM (20); Engine Action #89; Engine Action #9; Warp Town -> Area 3 Map 108 Submap 24 at (255,254) |
| `ev[07]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Condition Check #23 AND Condition Check #90 AND Player within Box [1..56, 57..5] AND Story Flag 255 (mask 254) CLEAR | Engine Action #89; Engine Action #9; Warp Town -> Area 4 Map 24 Submap 8 at (0,0); Engine Action #89; Engine Action #9; Warp Town -> Area 3 Map 73 Submap 20 at (108,24) |
| `ev[08]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Condition Check #23 AND Condition Check #90 AND Player within Box [1..61, 62..5] AND Story Flag 255 (mask 254) CLEAR | Engine Action #89; Engine Action #9; Warp Town -> Area 5 Map 24 Submap 8 at (0,0); Engine Action #89; Engine Action #9; Warp Town -> Area 3 Map 73 Submap 20 at (108,24) |
| `ev[09]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Condition Check #23 AND Condition Check #90 AND Player within Box [5..10, 255..254] | Close Dialogue Sub-Window (8); Open Dialogue Message Window; Open Dialogue Message Window; Set Combat Battle BGM (20); Engine Action #108; Close Dialogue Sub-Window (255) |
| `ev[10]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Condition Check #23 AND Condition Check #90 AND Player within Box [1..50, 58..2] AND Condition Check #80 AND Condition Check #81 | Exit to World Map (0, 56, 82); Engine Action #9; Warp to Castle HQ (0, 3, 89); Engine Action #9; Warp Town -> Area 4 Map 24 Submap 8 at (0,0); Set Combat Battle BGM (20); Engine Action #89; Engine Action #9; Warp Town -> Area 3 Map 108 Submap 24 at (255,254) |
| `ev[11]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Condition Check #23 AND Condition Check #90 AND Player within Box [1..56, 57..5] AND Story Flag 255 (mask 254) CLEAR | Engine Action #89; Engine Action #9; Warp Town -> Area 4 Map 24 Submap 8 at (13,6); Engine Action #89; Engine Action #9; Warp Town -> Area 3 Map 255 Submap 254 at (204,204) |
| `ev[12]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Condition Check #23 AND Condition Check #90 AND Player within Box [1..61, 62..5] AND Story Flag 255 (mask 254) CLEAR | Engine Action #89; Engine Action #9; Warp Town -> Area 5 Map 24 Submap 8 at (13,6); Engine Action #89; Engine Action #9; Warp Town -> Area 3 Map 255 Submap 254 at (204,204) |
| `ev[13]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Condition Check #23 AND Condition Check #90 AND Player within Box [5..10, 255..254] | Close Dialogue Sub-Window (8); Place Scenery Structure (6) |
| `ev[14]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Condition Check #23 AND Condition Check #90 AND Player within Box [1..50, 58..2] AND Condition Check #80 AND Condition Check #81 | Exit to World Map (0, 56, 82); Engine Action #9; Warp to Castle HQ (0, 3, 89); Engine Action #9; Warp Town -> Area 4 Map 24 Submap 8 at (13,6); Set Combat Battle BGM (20); Engine Action #89; Engine Action #9; Warp Town -> Area 3 Map 255 Submap 254 at (204,204) |
| `ev[15]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Condition Check #23 AND Condition Check #90 AND Player within Box [1..56, 57..5] AND Story Flag 255 (mask 254) CLEAR | Engine Action #89; Engine Action #9; Warp Town -> Area 4 Map 24 Submap 8 at (0,0); Engine Action #89; Engine Action #9; Warp Town -> Area 3 Map 73 Submap 20 at (108,24) |
| `ev[16]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Condition Check #23 AND Condition Check #90 AND Player within Box [1..61, 62..5] AND Story Flag 255 (mask 254) CLEAR | Engine Action #89; Engine Action #9; Warp Town -> Area 5 Map 24 Submap 8 at (0,0); Engine Action #89; Engine Action #9; Warp Town -> Area 3 Map 73 Submap 20 at (108,24) |
| `ev[17]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Condition Check #23 AND Condition Check #90 AND Player within Box [5..10, 255..254] | Close Dialogue Sub-Window (8); Open Dialogue Message Window; Open Dialogue Message Window; Set Combat Battle BGM (20); Engine Action #108; Close Dialogue Sub-Window (255) |
| `ev[18]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Condition Check #23 AND Condition Check #90 AND Player within Box [1..50, 58..2] AND Condition Check #80 AND Condition Check #81 | Exit to World Map (0, 56, 82); Engine Action #9; Warp to Castle HQ (0, 3, 89); Engine Action #9; Warp Town -> Area 4 Map 24 Submap 8 at (0,0); Set Combat Battle BGM (20); Engine Action #89; Engine Action #9; Warp Town -> Area 3 Map 108 Submap 24 at (255,254) |
| `ev[19]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Condition Check #23 AND Condition Check #90 AND Player within Box [1..56, 57..5] AND Story Flag 255 (mask 254) CLEAR | Engine Action #89; Engine Action #9; Warp Town -> Area 4 Map 24 Submap 8 at (0,0); Engine Action #89; Engine Action #9; Warp Town -> Area 3 Map 73 Submap 20 at (108,24) |
| `ev[20]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Condition Check #23 AND Condition Check #90 AND Player within Box [1..61, 62..5] AND Story Flag 255 (mask 254) CLEAR | Engine Action #89; Engine Action #9; Warp Town -> Area 5 Map 24 Submap 8 at (0,0); Engine Action #89; Engine Action #9; Warp Town -> Area 3 Map 73 Submap 20 at (108,24) |
| `ev[21]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Condition Check #23 AND Condition Check #90 AND Player within Box [5..10, 255..254] | Close Dialogue Sub-Window (8); Open Dialogue Message Window; Open Dialogue Message Window; Set Combat Battle BGM (20); Engine Action #108; Close Dialogue Sub-Window (255) |
| `ev[22]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Condition Check #23 AND Condition Check #90 AND Player within Box [1..50, 58..2] AND Condition Check #80 AND Condition Check #81 | Exit to World Map (0, 56, 82); Engine Action #9; Warp to Castle HQ (0, 3, 89); Engine Action #9; Warp Town -> Area 4 Map 24 Submap 8 at (0,0); Set Combat Battle BGM (20); Engine Action #89; Engine Action #9; Warp Town -> Area 3 Map 108 Submap 24 at (255,254) |
| `ev[23]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #90 AND Player within Box [1..56, 57..5] AND Story Flag 255 (mask 254) CLEAR | Engine Action #89; Engine Action #9; Warp Town -> Area 4 Map 24 Submap 8 at (0,0); Engine Action #89; Engine Action #9; Warp Town -> Area 3 Map 73 Submap 20 at (108,24) |
| `ev[24]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #90 AND Player within Box [1..61, 62..5] AND Story Flag 255 (mask 254) CLEAR | Engine Action #89; Engine Action #9; Warp Town -> Area 5 Map 24 Submap 8 at (0,0); Engine Action #89; Engine Action #9; Warp Town -> Area 3 Map 73 Submap 20 at (108,24) |
| `ev[25]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #90 AND Player within Box [5..10, 255..254] | Close Dialogue Sub-Window (8); Open Dialogue Message Window; Open Dialogue Message Window; Set Combat Battle BGM (20); Engine Action #108; Close Dialogue Sub-Window (255) |
| `ev[26]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #90 AND Player within Box [1..50, 58..2] AND Condition Check #80 AND Condition Check #81 | Exit to World Map (0, 56, 82); Engine Action #9; Warp to Castle HQ (0, 3, 89); Engine Action #9; Warp Town -> Area 4 Map 24 Submap 8 at (0,0); Set Combat Battle BGM (20); Engine Action #89; Engine Action #9; Warp Town -> Area 3 Map 108 Submap 24 at (255,254) |
| `ev[27]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #71 AND Player within Box [34..4, 32..33] AND Player X within Range [3..255] | Make obj[0] Hidden (disp = 0); Close Dialogue Window; Teleport obj[255] to (254,204) |
| `ev[28]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[11] | Open Dialogue Sub-Window (5); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[29]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[11] | Open Dialogue Sub-Window (6); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[30]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[11] | Open Dialogue Sub-Window (7); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[31]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[11] | Open Dialogue Sub-Window (8); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[32]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[11] | Open Dialogue Sub-Window (9); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[33]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Open Dialogue Sub-Window (0); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[34]` | `128 (Loop)` | Player within Box [33..71, 2..88] AND Condition Check #96 | Warp Room -> Submap 1 at (10,1) |
| `ev[35]` | `128 (Loop)` | Player within Box [32..42, 2..19] AND Condition Check #45 AND Story Flag 144 (bit 16) SET | Engine Action #109; Screen Fade Transition (28, 255, 254) |
| `ev[36]` | `128 (Loop)` | Player within Box [32..42, 2..19] AND Condition Check #45 AND Story Flag 144 (bit 16) CLEAR | Engine Action #109; Screen Fade Transition (31, 255, 254) |
| `ev[37]` | `128 (Loop)` | Player within Box [108..116, 2..21] AND Condition Check #61 | Warp Room -> Submap 1 at (10,18) |
| `ev[38]` | `1 (Action / Talk)` | Player within Box [54..62, 2..100] AND Condition Check #101 AND Story Flag 0 (mask 255) SET | Warp Map Transition (2, 0, 46, 29, 255) |
| `ev[39]` | `1 (Action / Talk)` | Player within Box [34..38, 2..82] AND Condition Check #83 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 36]; Make obj[255] Visible (disp = 1) |
| `ev[40]` | `1 (Action / Talk)` | Player within Box [34..38, 2..48] AND Condition Check #49 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 36]; Engine Action #85 |
| `ev[41]` | `1 (Action / Talk)` | Player within Box [68..69, 2..18] AND Treasure Byte 9 Bit 3 FRESH (Unopened) | Display Dialogue Box [Bank: 0, MsgID: 110]; Fade In from Black (255) |
| `ev[42]` | `1 (Action / Talk)` | Player within Box [107..108, 2..22] AND Condition Check #32 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 66]; Open Dialogue Sub-Window (255) |
| `ev[43]` | `1 (Action / Talk)` | Player within Box [64..70, 2..85] AND Condition Check #86 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 123]; Engine Action #40 |
| `ev[44]` | `2 (Map Init)` | Player within Box [33..35, 2..19] AND Inventory Holds Item #255 | Warp to Castle HQ (0, 3, 255) |
| `ev[45]` | `1 (Action / Talk)` | Player within Box [31..32, 2..15] AND Treasure Byte 9 Bit 2 LOOTED AND Story Flag 144 (bit 16) SET | Place Scenery Structure (5); Screen Fade Transition (28, 1, 64); Engine Action #174 |
| `ev[46]` | `1 (Action / Talk)` | Player within Box [31..32, 2..15] AND Treasure Byte 9 Bit 2 LOOTED AND Story Flag 144 (bit 16) CLEAR | Place Scenery Structure (5); Screen Fade Transition (31, 1, 64); Engine Action #174 |
| `ev[47]` | `1 (Action / Talk)` | Player within Box [115..116, 2..50] AND Condition Check #56 AND Story Flag 3 (mask 255) SET | Warp Map Transition (2, 0, 6, 51, 255) |
| `ev[48]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [1..255] | Open Dialogue Message Window; Show Dialogue Portrait (255, 254, 204) |
| `ev[49]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #23 AND Condition Check #90 AND Player Y within Range [33..1] AND Player Y within Range [255..254] | Open Dialogue Message Window; Display Speaker Name Box (255) |
| `ev[50]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #23 AND Condition Check #90 AND Player Y within Range [33..1] AND Story Flag 255 (bit 254) SET | Open Dialogue Message Window; Display Choice Selection (255, 254) |
| `ev[51]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [1..255] | Open Dialogue Message Window; Dismiss Dialogue Portrait |
| `ev[52]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [1..255] | Open Dialogue Message Window; Change Portrait Expression (255) |
| `ev[53]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #23 AND Condition Check #90 AND Player Y within Range [33..1] AND Player X within Range [255..254] | Open Dialogue Message Window; Branch on Choice (255, 254) |
| `ev[54]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #66 AND Player Y within Range [23..57] AND Player Y within Range [5..15] | Close Dialogue Sub-Window (15); Display Dialogue Box [Bank: 0, MsgID: 255] |
| `ev[55]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #66 AND Player Y within Range [24..57] AND Player Y within Range [5..15] | Close Dialogue Sub-Window (15); Close Dialogue Window; Open Dialogue Message Window |
| `ev[56]` | `1 (Action / Talk)` | Condition Check #24 AND Condition Check #66 AND Player Y within Range [23..57] AND Player Y within Range [5..15] | Close Dialogue Sub-Window (15); Screen Fade Transition (0, 255, 254) |
| `ev[57]` | `1 (Action / Talk)` | Condition Check #24 AND Condition Check #66 AND Player Y within Range [24..57] AND Player Y within Range [5..15] | Close Dialogue Sub-Window (15); Warp to Castle HQ (0, 255, 254) |
| `ev[58]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[18] | Close Dialogue Sub-Window (18); Screen Fade Transition (1, 255, 254) |
| `ev[59]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[18] | Close Dialogue Sub-Window (18); Close Dialogue Window; Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[60]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[18] | Close Dialogue Sub-Window (18); Display Dialogue Box [Bank: 1, MsgID: 255] |
| `ev[61]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Close Dialogue Sub-Window (18); Warp to Castle HQ (1, 255, 254) |
| `ev[62]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[19] | Close Dialogue Sub-Window (19); Screen Fade Transition (2, 255, 254) |
| `ev[63]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[19] | Close Dialogue Sub-Window (19); Close Dialogue Window; Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[64]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[19] | Close Dialogue Sub-Window (19); Display Dialogue Box [Bank: 2, MsgID: 255] |
| `ev[65]` | `1 (Action / Talk)` | Target Inspected is obj[19] | Close Dialogue Sub-Window (19); Warp to Castle HQ (2, 255, 254) |
| `ev[66]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #104 AND Player Y within Range [23..102] AND Player Y within Range [5..16] | Close Dialogue Sub-Window (16); Screen Fade Transition (3, 255, 254) |
| `ev[67]` | `1 (Action / Talk)` | Condition Check #24 AND Condition Check #104 AND Player Y within Range [23..102] AND Player Y within Range [5..16] | Close Dialogue Sub-Window (16); Close Dialogue Window; Warp to Castle HQ (255, 254, 204) |
| `ev[68]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #104 AND Player Y within Range [24..102] AND Player Y within Range [5..16] | Close Dialogue Sub-Window (16); Display Dialogue Box [Bank: 3, MsgID: 255] |
| `ev[69]` | `1 (Action / Talk)` | Condition Check #24 AND Condition Check #104 AND Player Y within Range [24..102] AND Player Y within Range [5..16] | Close Dialogue Sub-Window (16); Warp to Castle HQ (3, 255, 254) |
| `ev[70]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #104 AND Player Y within Range [23..102] AND Player Y within Range [5..17] | Close Dialogue Sub-Window (17); Screen Fade Transition (4, 255, 254) |
| `ev[71]` | `1 (Action / Talk)` | Condition Check #24 AND Condition Check #104 AND Player Y within Range [23..102] AND Player Y within Range [5..17] | Close Dialogue Sub-Window (17); Close Dialogue Window; Exit to World Map (255, 254, 204) |
| `ev[72]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #104 AND Player Y within Range [24..102] AND Player Y within Range [5..17] | Close Dialogue Sub-Window (17); Display Dialogue Box [Bank: 4, MsgID: 255] |
| `ev[73]` | `1 (Action / Talk)` | Condition Check #24 AND Condition Check #104 AND Player Y within Range [24..102] AND Player Y within Range [5..17] | Close Dialogue Sub-Window (17); Warp to Castle HQ (4, 255, 254) |
| `ev[74]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[20] | Close Dialogue Sub-Window (20); Screen Fade Transition (5, 255, 254) |
| `ev[75]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[20] | Close Dialogue Sub-Window (20); Close Dialogue Window; Engine Action #5 |
| `ev[76]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[20] | Close Dialogue Sub-Window (20); Display Dialogue Box [Bank: 5, MsgID: 255] |
| `ev[77]` | `1 (Action / Talk)` | Target Inspected is obj[20] | Close Dialogue Sub-Window (20); Warp to Castle HQ (5, 255, 254) |

---

### Submap Layer `vk06_01` (Index 1)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `14` Objects | **Script Count (`evkaz`)**: `88` Scripts

#### Complete Physical Entity Inventory (14 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | Trigger / Hitbox | **Hitbox Zone (2x5)** | `0` | `(52, 34)` | `1x4` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Actor ID 117** | `117` | `(133, 26)` | `5x5` | East (Right) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[02]` | NPC / Actor | **Actor ID 122** | `122` | `(133, 26)` | `5x5` | East (Right) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[03]` | NPC / Actor | **Actor ID 118** | `118` | `(102, 25)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[04]` | NPC / Actor | **Culgan** | `87` | `(98, 25)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[05]` | NPC / Actor | **Gorudo** | `34` | `(110, 28)` | `5x5` | South (Down) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[06]` | World Device | **Mechanism (ano 9)** | `0` | `(130, 36)` | `0x0` | Frame 9 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[07]` | World Device | **Mechanism (ano 9)** | `0` | `(94, 36)` | `0x0` | Frame 9 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[08]` | World Device | **Mechanism (ano 10)** | `0` | `(132, 38)` | `0x0` | Frame 10 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 480 |
| `obj[09]` | World Device | **Mechanism (ano 10)** | `0` | `(96, 38)` | `0x0` | Frame 10 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 480 |
| `obj[10]` | NPC / Actor | **Actor ID 65188** | `65188` | `(132, 29)` | `3x3` | South (Down) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[11]` | NPC / Actor | **Actor ID 65189** | `65189` | `(137, 32)` | `3x3` | South (Down) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[12]` | NPC / Actor | **Actor ID 65152** | `65152` | `(110, 35)` | `3x3` | South (Down) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[13]` | NPC / Actor | **Actor ID 65039** | `65039` | `(114, 34)` | `3x3` | South (Down) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `5` tiles high from `(52, 34)` to `(53, 38)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[01]` (Object 117)**: Positioned at tile `(133, 26)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Object 122)**: Positioned at tile `(133, 26)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Object 118)**: Positioned at tile `(102, 25)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Culgan)**: Positioned at tile `(98, 25)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Gorudo)**: Positioned at tile `(110, 28)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[06]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(130, 36)` with state parameter `9`.
- **`obj[07]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(94, 36)` with state parameter `9`.
- **`obj[08]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(132, 38)` with state parameter `10`.
- **`obj[09]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(96, 38)` with state parameter `10`.
- **`obj[10]` (Object 65188)**: Positioned at tile `(132, 29)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[11]` (Object 65189)**: Positioned at tile `(137, 32)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[12]` (Object 65152)**: Positioned at tile `(110, 35)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[13]` (Object 65039)**: Positioned at tile `(114, 34)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.


#### Complete Bytecode Script Catalog (88 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #66 AND Player Y within Range [16..0] AND Condition Check #66 AND Story Flag 61 (bit 64) CLEAR AND Story Flag 152 (bit 1) CLEAR AND Story Flag 153 (bit 16) CLEAR AND Condition Check #33 AND Player within Box [2..37, 0..8] AND Always Passes (Unconditional) AND Condition Check #30 AND Always Passes (Unconditional) | Make obj[9] Hidden (disp = 0); Engine Action #152; Warp Room -> Submap 148 at (2,47) facing 255 |
| `ev[01]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #66 AND Player Y within Range [16..0] AND Condition Check #66 AND Story Flag 61 (bit 64) CLEAR AND Story Flag 71 (bit 1) SET AND Story Flag 152 (bit 2) CLEAR AND Story Flag 153 (bit 16) CLEAR AND Condition Check #33 AND Player within Box [2..37, 0..8] AND Always Passes (Unconditional) AND Condition Check #45 AND Always Passes (Unconditional) | Make obj[9] Hidden (disp = 0); Engine Action #152; Warp Town -> Area 9 Map 148 Submap 2 at (47,255) |
| `ev[02]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #66 AND Player Y within Range [16..0] AND Condition Check #66 AND Story Flag 61 (bit 64) CLEAR AND Story Flag 71 (bit 2) SET AND Story Flag 152 (bit 4) CLEAR AND Story Flag 153 (bit 16) CLEAR AND Condition Check #33 AND Player within Box [2..37, 0..8] AND Always Passes (Unconditional) AND Condition Check #40 AND Always Passes (Unconditional) | Make obj[9] Hidden (disp = 0); Engine Action #152; Exit to World Map (9, 148, 2); Teleport obj[255] to (254,204) |
| `ev[03]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #66 AND Player Y within Range [16..0] AND Condition Check #66 AND Story Flag 61 (bit 64) CLEAR AND Story Flag 71 (bit 4) SET AND Story Flag 152 (bit 8) CLEAR AND Story Flag 153 (bit 16) CLEAR AND Condition Check #33 AND Player within Box [2..37, 0..8] AND Always Passes (Unconditional) AND Condition Check #30 AND Always Passes (Unconditional) | Make obj[9] Hidden (disp = 0); Engine Action #152; Reset Camera Tracking (9); Engine Action #148; Warp Town -> Area 47 Map 255 Submap 254 at (204,204) |
| `ev[04]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #66 AND Player Y within Range [4..61] AND Condition Check #64 AND Story Flag 152 (bit 8) SET AND Story Flag 71 (bit 8) CLEAR AND Story Flag 153 (bit 16) SET AND Story Flag 153 (bit 128) CLEAR AND Condition Check #37 AND Always Passes (Unconditional) AND Temp Event Flag #0 CLEAR AND Condition Check #30 AND Always Passes (Unconditional) | Make obj[9] Hidden (disp = 0); Engine Action #153; Engine Action #128; Teleport obj[255] to (254,204) |
| `ev[05]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #66 AND Player Y within Range [16..0] AND Condition Check #66 AND Story Flag 61 (bit 64) CLEAR AND Story Flag 71 (bit 8) SET AND Story Flag 152 (bit 16) CLEAR AND Story Flag 153 (bit 16) CLEAR AND Condition Check #33 AND Player within Box [2..37, 0..8] AND Always Passes (Unconditional) AND Condition Check #60 AND Always Passes (Unconditional) | Make obj[9] Hidden (disp = 0); Engine Action #152; Dismiss Dialogue Portrait; Engine Action #9; Engine Action #148; Warp Town -> Area 47 Map 255 Submap 254 at (204,204) |
| `ev[06]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #66 AND Player Y within Range [16..0] AND Condition Check #66 AND Story Flag 61 (bit 64) CLEAR AND Story Flag 71 (bit 16) SET AND Story Flag 152 (bit 32) CLEAR AND Story Flag 153 (bit 16) CLEAR AND Condition Check #33 AND Player within Box [2..37, 0..8] AND Always Passes (Unconditional) AND Condition Check #30 AND Always Passes (Unconditional) | Make obj[9] Hidden (disp = 0); Engine Action #152; Warp Map Transition (9, 148, 2, 47, 255) |
| `ev[07]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #66 AND Player Y within Range [16..0] AND Condition Check #66 AND Story Flag 61 (bit 64) CLEAR AND Story Flag 71 (bit 32) SET AND Story Flag 152 (bit 64) CLEAR AND Story Flag 153 (bit 16) CLEAR AND Condition Check #33 AND Player within Box [2..37, 0..8] AND Always Passes (Unconditional) AND Condition Check #50 AND Always Passes (Unconditional) | Make obj[9] Hidden (disp = 0); Engine Action #152; Animate Doorway State (9, 148); Warp Town -> Area 47 Map 255 Submap 254 at (204,204) |
| `ev[08]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #66 AND Player Y within Range [16..0] AND Condition Check #66 AND Story Flag 61 (bit 64) CLEAR AND Story Flag 71 (bit 64) SET AND Story Flag 148 (bit 4) CLEAR AND Story Flag 153 (bit 16) CLEAR AND Condition Check #33 AND Player within Box [2..37, 0..8] AND Always Passes (Unconditional) AND Condition Check #50 AND Always Passes (Unconditional) | Make obj[9] Hidden (disp = 0); Engine Action #148; Exit to World Map (47, 255, 254) |
| `ev[09]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #66 AND Player Y within Range [16..0] AND Condition Check #66 AND Story Flag 61 (bit 64) CLEAR AND Story Flag 148 (bit 8) SET AND Story Flag 152 (bit 128) CLEAR AND Story Flag 153 (bit 16) CLEAR AND Condition Check #33 AND Player within Box [2..37, 0..8] AND Always Passes (Unconditional) AND Target Inspected is obj[0] | Make obj[9] Hidden (disp = 0); Engine Action #152; Engine Action #128; Engine Action #9; Engine Action #148; Warp Town -> Area 47 Map 255 Submap 254 at (204,204) |
| `ev[10]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #66 AND Player Y within Range [16..0] AND Condition Check #66 AND Story Flag 61 (bit 64) CLEAR AND Story Flag 71 (bit 128) SET AND Story Flag 153 (bit 1) CLEAR AND Story Flag 153 (bit 16) CLEAR AND Condition Check #33 AND Player within Box [2..37, 0..8] AND Always Passes (Unconditional) AND Condition Check #40 AND Always Passes (Unconditional) | Make obj[9] Hidden (disp = 0); Engine Action #153; Warp Room -> Submap 148 at (2,47) facing 255 |
| `ev[11]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #66 AND Player Y within Range [16..0] AND Condition Check #66 AND Story Flag 61 (bit 64) CLEAR AND Story Flag 72 (bit 1) SET AND Story Flag 153 (bit 2) CLEAR AND Story Flag 153 (bit 16) CLEAR AND Condition Check #33 AND Player within Box [2..37, 0..8] AND Always Passes (Unconditional) AND Condition Check #30 AND Always Passes (Unconditional) | Make obj[9] Hidden (disp = 0); Engine Action #153; Warp Town -> Area 9 Map 148 Submap 2 at (47,255) |
| `ev[12]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #66 AND Player Y within Range [16..0] AND Condition Check #66 AND Story Flag 61 (bit 64) CLEAR AND Story Flag 72 (bit 2) SET AND Story Flag 153 (bit 4) CLEAR AND Story Flag 153 (bit 16) CLEAR AND Condition Check #33 AND Player within Box [2..37, 0..8] AND Always Passes (Unconditional) AND Condition Check #30 AND Always Passes (Unconditional) | Make obj[9] Hidden (disp = 0); Engine Action #153; Exit to World Map (9, 148, 2); Teleport obj[255] to (254,204) |
| `ev[13]` | `2 (Map Init)` | Story Flag 47 (bit 1) CLEAR AND Condition Check #23 AND Condition Check #117 AND Player within Box [33..0, 1..24] AND Condition Check #117 AND Temp Event Flag #255 SET | Make obj[0] Hidden (disp = 0); Engine Action #9; Teleport obj[255] to (254,204) |
| `ev[14]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[9] | Open Dialogue Sub-Window (5); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[15]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[9] | Open Dialogue Sub-Window (6); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[16]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[9] | Open Dialogue Sub-Window (7); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[17]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[9] | Open Dialogue Sub-Window (8); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[18]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[9] | Open Dialogue Sub-Window (9); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[19]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Open Dialogue Sub-Window (0); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[20]` | `2 (Map Init)` | Story Flag 48 (bit 8) CLEAR AND Condition Check #23 AND Condition Check #122 AND Player within Box [33..0, 1..23] AND Condition Check #117 AND Temp Event Flag #255 SET | Make obj[0] Hidden (disp = 0); Screen Fade Transition (47, 255, 254) |
| `ev[21]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[10] | Open Dialogue Sub-Window (5); Warp to Castle HQ (255, 254, 204) |
| `ev[22]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[10] | Open Dialogue Sub-Window (6); Warp to Castle HQ (255, 254, 204) |
| `ev[23]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[10] | Open Dialogue Sub-Window (7); Warp to Castle HQ (255, 254, 204) |
| `ev[24]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[10] | Open Dialogue Sub-Window (8); Warp to Castle HQ (255, 254, 204) |
| `ev[25]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[10] | Open Dialogue Sub-Window (9); Warp to Castle HQ (255, 254, 204) |
| `ev[26]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Open Dialogue Sub-Window (0); Warp to Castle HQ (255, 254, 204) |
| `ev[27]` | `2 (Map Init)` | Story Flag 47 (bit 16) CLEAR AND Condition Check #23 AND Condition Check #87 AND Player within Box [35..20, 32..33] AND Always Passes (Unconditional) AND Player X within Range [255..254] | Open Dialogue Message Window; Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[28]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[12] | Open Dialogue Sub-Window (5); Exit to World Map (255, 254, 204) |
| `ev[29]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[12] | Open Dialogue Sub-Window (6); Exit to World Map (255, 254, 204) |
| `ev[30]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[12] | Open Dialogue Sub-Window (7); Exit to World Map (255, 254, 204) |
| `ev[31]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[12] | Open Dialogue Sub-Window (8); Exit to World Map (255, 254, 204) |
| `ev[32]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[12] | Open Dialogue Sub-Window (9); Exit to World Map (255, 254, 204) |
| `ev[33]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Open Dialogue Sub-Window (0); Exit to World Map (255, 254, 204) |
| `ev[34]` | `2 (Map Init)` | Story Flag 47 (bit 32) CLEAR AND Condition Check #23 AND Condition Check #118 AND Player within Box [33..0, 1..255] | Make obj[0] Hidden (disp = 0); Close Dialogue Window; Teleport obj[255] to (254,204) |
| `ev[35]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[11] | Open Dialogue Sub-Window (5); Engine Action #5 |
| `ev[36]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[11] | Open Dialogue Sub-Window (6); Engine Action #5 |
| `ev[37]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[11] | Open Dialogue Sub-Window (7); Engine Action #5 |
| `ev[38]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[11] | Open Dialogue Sub-Window (8); Engine Action #5 |
| `ev[39]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[11] | Open Dialogue Sub-Window (9); Engine Action #5 |
| `ev[40]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Open Dialogue Sub-Window (0); Engine Action #5 |
| `ev[41]` | `2 (Map Init)` | Story Flag 48 (bit 16) CLEAR AND Condition Check #23 AND Condition Check #34 AND Player within Box [33..0, 1..255] | Make obj[0] Hidden (disp = 0); Place Scenery Structure (47) |
| `ev[42]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[13] | Open Dialogue Sub-Window (5); Engine Action #6 |
| `ev[43]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[13] | Open Dialogue Sub-Window (6); Engine Action #6 |
| `ev[44]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[13] | Open Dialogue Sub-Window (7); Engine Action #6 |
| `ev[45]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[13] | Open Dialogue Sub-Window (8); Engine Action #6 |
| `ev[46]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[13] | Open Dialogue Sub-Window (9); Engine Action #6 |
| `ev[47]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Open Dialogue Sub-Window (0); Engine Action #6 |
| `ev[48]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #66 AND Player Y within Range [255..254] | Make obj[0] Hidden (disp = 0); Show Dialogue Portrait (0, 17, 47) |
| `ev[49]` | `2 (Map Init)` | Condition Check #29 AND Party Holds At Least 100 Potch | Engine Action #99; Animate Door Open; Animate Doorway State (255, 254) |
| `ev[50]` | `2 (Map Init)` | Condition Check #29 AND Party Holds At Least 200 Potch | Engine Action #99; Animate Door Open; Engine Action #128 |
| `ev[51]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Dismiss Emotion Bubble (0); Open Dialogue Message Window |
| `ev[52]` | `128 (Loop)` | Player within Box [33..51, 2..22] AND Condition Check #52 | Warp Room -> Submap 1 at (10,8) |
| `ev[53]` | `128 (Loop)` | Player within Box [96..142, 2..25] AND Condition Check #39 | Warp Room -> Submap 1 at (10,17) |
| `ev[54]` | `1 (Action / Talk)` | Player within Box [118..128, 2..43] AND Condition Check #44 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 67]; Engine Action #89 |
| `ev[55]` | `1 (Action / Talk)` | Player within Box [134..138, 2..40] AND Condition Check #41 AND Story Flag 0 (mask 23) SET AND Condition Check #66 AND Player Y within Range [3..148] AND Player Y within Range [255..254] | Screen Fade Transition (153, 32, 10); Engine Action #153; Animate Doorway State (13, 5); Screen Fade Transition (29, 0, 30); Dismiss Emotion Bubble (255) |
| `ev[56]` | `1 (Action / Talk)` | Player within Box [134..138, 2..40] AND Condition Check #41 AND Story Flag 0 (mask 23) SET AND Condition Check #66 AND Player Y within Range [3..148] AND Story Flag 4 (bit 148) CLEAR AND Temp Event Flag #255 CLEAR | Display Dialogue Box [Bank: 2, MsgID: 30]; Display Emotion Bubble (255, 254) |
| `ev[57]` | `1 (Action / Talk)` | Player within Box [134..138, 2..40] AND Condition Check #41 AND Story Flag 0 (mask 23) SET AND Condition Check #66 AND Player Y within Range [4..148] AND Player Y within Range [255..254] | Display Dialogue Box [Bank: 2, MsgID: 66]; Display Emotion Bubble (255, 254) |
| `ev[58]` | `1 (Action / Talk)` | Player within Box [134..138, 2..40] AND Condition Check #41 AND Story Flag 0 (mask 24) SET AND Condition Check #66 AND Player Y within Range [255..254] | Display Dialogue Box [Bank: 3, MsgID: 66]; Jump to Bytecode Offset (255, 254) |
| `ev[59]` | `1 (Action / Talk)` | Player within Box [98..102, 2..40] AND Condition Check #41 AND Story Flag 0 (mask 23) SET AND Condition Check #66 AND Player Y within Range [3..148] AND Player Y within Range [255..254] | Screen Fade Transition (153, 32, 10); Engine Action #153; Animate Doorway State (13, 5); Screen Fade Transition (29, 0, 30); Dismiss Emotion Bubble (255) |
| `ev[60]` | `1 (Action / Talk)` | Player within Box [98..102, 2..40] AND Condition Check #41 AND Story Flag 0 (mask 23) SET AND Condition Check #66 AND Player Y within Range [4..148] AND Player Y within Range [255..254] | Display Dialogue Box [Bank: 2, MsgID: 30]; Display Emotion Bubble (255, 254) |
| `ev[61]` | `1 (Action / Talk)` | Player within Box [98..102, 2..40] AND Condition Check #41 AND Story Flag 0 (mask 24) SET AND Condition Check #66 AND Player Y within Range [255..254] | Display Dialogue Box [Bank: 3, MsgID: 30]; Jump to Bytecode Offset (255, 254) |
| `ev[62]` | `1 (Action / Talk)` | Player within Box [93..94, 2..25] AND Condition Check #35 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 50]; Award Potch Loot (+65,534 Potch) |
| `ev[63]` | `1 (Action / Talk)` | Player within Box [52..53, 2..36] AND Condition Check #46 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 96]; Dismiss Emotion Bubble (255) |
| `ev[64]` | `1 (Action / Talk)` | Player within Box [31..32, 2..34] AND Condition Check #41 AND Story Flag 2 (mask 33) SET AND Player X within Range [3..255] | Warp Map Transition (2, 0, 56, 75, 255) |
| `ev[65]` | `1 (Action / Talk)` | Player within Box [31..32, 2..34] AND Condition Check #41 AND Story Flag 2 (mask 33) SET AND Player Y within Range [2..255] | Warp Map Transition (2, 2, 136, 75, 255) |
| `ev[66]` | `1 (Action / Talk)` | Player within Box [114..122, 2..20] AND Inventory Lacks Item #9 AND Player within Box [23..57, 2..255] | Warp Map Transition (2, 0, 26, 46, 255) |
| `ev[67]` | `1 (Action / Talk)` | Player within Box [114..122, 2..20] AND Inventory Lacks Item #9 AND Player within Box [24..57, 2..255] | Warp Map Transition (2, 1, 26, 46, 255) |
| `ev[68]` | `1 (Action / Talk)` | Player within Box [104..112, 2..20] AND Inventory Lacks Item #9 AND Player within Box [23..57, 2..255] | Warp Map Transition (2, 0, 16, 46, 255) |
| `ev[69]` | `1 (Action / Talk)` | Player within Box [104..112, 2..20] AND Inventory Lacks Item #9 AND Player within Box [24..57, 2..255] | Warp Map Transition (2, 1, 16, 46, 255) |
| `ev[70]` | `1 (Action / Talk)` | Player within Box [124..132, 2..20] AND Inventory Lacks Item #9 AND Player within Box [23..57, 2..255] | Warp Map Transition (2, 0, 34, 46, 255) |
| `ev[71]` | `1 (Action / Talk)` | Player within Box [124..132, 2..20] AND Inventory Lacks Item #9 AND Player within Box [24..57, 2..255] | Warp Map Transition (2, 1, 34, 46, 255) |
| `ev[72]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [2..255] | Open Dialogue Message Window; Display Speaker Name Box (255) |
| `ev[73]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [3..255] | Open Dialogue Message Window; Display Choice Selection (255, 254) |
| `ev[74]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #23 AND Condition Check #66 AND Player Y within Range [33..1] AND Player Y within Range [255..254] | Open Dialogue Message Window; Branch on Choice (255, 254) |
| `ev[75]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #23 AND Condition Check #66 AND Player Y within Range [33..1] AND Story Flag 255 (bit 254) SET | Open Dialogue Message Window; Execute Choice Result (255) |
| `ev[76]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #57 AND Player Y within Range [5..18] | Close Dialogue Sub-Window (18); Display Dialogue Box [Bank: 6, MsgID: 255] |
| `ev[77]` | `1 (Action / Talk)` | Condition Check #24 AND Condition Check #57 AND Player Y within Range [5..18] | Close Dialogue Sub-Window (18); Warp to Castle HQ (6, 255, 254) |
| `ev[78]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #57 AND Player Y within Range [5..19] | Close Dialogue Sub-Window (19); Display Dialogue Box [Bank: 7, MsgID: 255] |
| `ev[79]` | `1 (Action / Talk)` | Condition Check #24 AND Condition Check #57 AND Player Y within Range [5..19] | Close Dialogue Sub-Window (19); Warp to Castle HQ (7, 255, 254) |
| `ev[80]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[20] | Close Dialogue Sub-Window (20); Screen Fade Transition (8, 255, 254) |
| `ev[81]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[20] | Close Dialogue Sub-Window (20); Close Dialogue Window; Reset Camera Tracking (255) |
| `ev[82]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[20] | Close Dialogue Sub-Window (20); Display Dialogue Box [Bank: 8, MsgID: 255] |
| `ev[83]` | `1 (Action / Talk)` | Target Inspected is obj[20] | Close Dialogue Sub-Window (20); Warp to Castle HQ (8, 255, 254) |
| `ev[84]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[21] | Close Dialogue Sub-Window (21); Screen Fade Transition (9, 255, 254) |
| `ev[85]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[21] | Close Dialogue Sub-Window (21); Close Dialogue Window; Engine Action #9 |
| `ev[86]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[21] | Close Dialogue Sub-Window (21); Display Dialogue Box [Bank: 9, MsgID: 255] |
| `ev[87]` | `1 (Action / Talk)` | Target Inspected is obj[21] | Close Dialogue Sub-Window (21); Warp to Castle HQ (9, 255, 254) |

---

### Submap Layer `vk06_02` (Index 2)

- **Map Number (`mapno`)**: `2`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `36` Objects | **Script Count (`evkaz`)**: `125` Scripts

#### Complete Physical Entity Inventory (36 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | Trigger / Hitbox | **Hitbox Zone (7x4)** | `0` | `(27, 58)` | `6x3` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[01]` | Trigger / Hitbox | **Hitbox Zone (7x4)** | `0` | `(40, 46)` | `6x3` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | Trigger / Hitbox | **Hitbox Zone (7x4)** | `0` | `(40, 58)` | `6x3` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | Trigger / Hitbox | **Hitbox Zone (7x4)** | `0` | `(54, 46)` | `6x3` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | Trigger / Hitbox | **Hitbox Zone (7x4)** | `0` | `(54, 58)` | `6x3` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | Trigger / Hitbox | **Hitbox Zone (7x4)** | `0` | `(66, 58)` | `6x3` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(70, 35)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(60, 32)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(38, 33)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(40, 33)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(54, 33)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(56, 33)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(62, 30)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | Trigger / Hitbox | **Hitbox Zone (2x4)** | `0` | `(70, 30)` | `1x3` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | Prop / Scenery | **Prop ID 53314** | `53314` | `(43, 35)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[15]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(42, 34)` | `2x1` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[16]` | NPC / Actor | **Actor ID 66** | `66` | `(43, 35)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[17]` | NPC / Actor | **Yam Koo** | `23` | `(43, 59)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[18]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(42, 56)` | `2x2` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[19]` | NPC / Actor | **Leona** | `16` | `(30, 59)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[20]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(29, 56)` | `2x2` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[21]` | NPC / Actor | **Oulan** | `46` | `(69, 59)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[22]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(68, 56)` | `2x2` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[23]` | NPC / Actor | **Actor ID 40** | `40` | `(57, 59)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[24]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(56, 56)` | `2x2` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[25]` | NPC / Actor | **Bonaparte** | `83` | `(47, 53)` | `5x2` | West (Left) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[26]` | NPC / Actor | **Actor ID 64522** | `64522` | `(0, 0)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[27]` | NPC / Actor | **Actor ID 64824** | `64824` | `(59, 54)` | `10x10` | South (Down) | Dormant / Hidden (0) | Special (3) | 4 | 128 | 0 |
| `obj[28]` | NPC / Actor | **Actor ID 64826** | `64826` | `(49, 35)` | `0x0` | Up (North) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[29]` | NPC / Actor | **Actor ID 64826** | `64826` | `(35, 52)` | `10x10` | South (Down) | Dormant / Hidden (0) | Special (3) | 4 | 128 | 0 |
| `obj[30]` | NPC / Actor | **Actor ID 64826** | `64826` | `(48, 58)` | `10x10` | South (Down) | Dormant / Hidden (0) | Special (3) | 4 | 128 | 0 |
| `obj[31]` | NPC / Actor | **Actor ID 64553** | `64553` | `(69, 58)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[32]` | NPC / Actor | **Actor ID 64928** | `64928` | `(57, 58)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[33]` | NPC / Actor | **Actor ID 64933** | `64933` | `(43, 63)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[34]` | NPC / Actor | **Actor ID 64550** | `64550` | `(43, 51)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[35]` | NPC / Actor | **Actor ID 64554** | `64554` | `(69, 63)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Hitbox Zone)**: Bounding trigger area covering `7` tiles wide by `4` tiles high from `(27, 58)` to `(33, 61)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[01]` (Hitbox Zone)**: Bounding trigger area covering `7` tiles wide by `4` tiles high from `(40, 46)` to `(46, 49)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[02]` (Hitbox Zone)**: Bounding trigger area covering `7` tiles wide by `4` tiles high from `(40, 58)` to `(46, 61)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[03]` (Hitbox Zone)**: Bounding trigger area covering `7` tiles wide by `4` tiles high from `(54, 46)` to `(60, 49)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[04]` (Hitbox Zone)**: Bounding trigger area covering `7` tiles wide by `4` tiles high from `(54, 58)` to `(60, 61)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[05]` (Hitbox Zone)**: Bounding trigger area covering `7` tiles wide by `4` tiles high from `(66, 58)` to `(72, 61)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[06]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(70, 35)` to `(72, 36)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[07]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(60, 32)` to `(62, 33)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[08]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(38, 33)` to `(40, 34)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[09]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(40, 33)` to `(42, 34)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[10]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(54, 33)` to `(56, 34)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[11]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(56, 33)` to `(59, 34)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[12]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(62, 30)` to `(64, 31)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[13]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `4` tiles high from `(70, 30)` to `(71, 33)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[14]` (Prop: Object 53314)**: Environmental world dressing prop placed at tile `(43, 35)`. Solid collision is set to `0`.
- **`obj[15]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(42, 34)` to `(44, 35)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[16]` (Object 66)**: Positioned at tile `(43, 35)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[17]` (Yam Koo)**: Positioned at tile `(43, 59)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[18]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(42, 56)` to `(44, 58)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[19]` (Leona)**: Positioned at tile `(30, 59)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[20]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(29, 56)` to `(31, 58)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[21]` (Oulan)**: Positioned at tile `(69, 59)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[22]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(68, 56)` to `(70, 58)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[23]` (Object 40)**: Positioned at tile `(57, 59)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[24]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(56, 56)` to `(58, 58)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[25]` (Bonaparte)**: Positioned at tile `(47, 53)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[26]` (Object 64522)**: Positioned at tile `(0, 0)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[27]` (Object 64824)**: Positioned at tile `(59, 54)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[28]` (Object 64826)**: Positioned at tile `(49, 35)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[29]` (Object 64826)**: Positioned at tile `(35, 52)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[30]` (Object 64826)**: Positioned at tile `(48, 58)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[31]` (Object 64553)**: Positioned at tile `(69, 58)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[32]` (Object 64928)**: Positioned at tile `(57, 58)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[33]` (Object 64933)**: Positioned at tile `(43, 63)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[34]` (Object 64550)**: Positioned at tile `(43, 51)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[35]` (Object 64554)**: Positioned at tile `(69, 63)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.


#### Complete Bytecode Script Catalog (125 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #66 AND Player within Box [33..1, 2..255] | Make obj[89] Hidden (disp = 0); Set Story Flag (2, 0); Open Dialogue Message Window; Set Story Flag (0, 23); Teleport obj[255] to (254,204) |
| `ev[01]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #23 AND Player within Box [33..1, 2..255] | Make obj[0] Hidden (disp = 0); Clear Dialogue Sub-Window; Open Dialogue Message Window; Fade In from Black (47) |
| `ev[02]` | `2 (Map Init)` | Condition Check #23 AND Star of Destiny #1 Recruited AND Condition Check #34 AND Inventory Holds Item #1 [Medicine] AND Condition Check #33 AND Player X within Range [2..255] | Make obj[0] Hidden (disp = 0); Fade Out to Black (0); Display Chapter Text (47) |
| `ev[03]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #46 AND Player within Box [34..23, 1..33] AND Player X within Range [2..255] | Make obj[0] Hidden (disp = 0); Display Emotion Bubble (0, 30); Teleport obj[255] to (254,204) |
| `ev[04]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #24 AND Player within Box [34..8, 64..33] AND Player X within Range [2..255] | Make obj[0] Hidden (disp = 0); Return to Previous Memory Map (47) |
| `ev[05]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #40 AND Player within Box [34..22, 32..33] AND Player X within Range [3..255] | Make obj[0] Hidden (disp = 0); Warp Room -> Submap 0 at (32,47) |
| `ev[06]` | `1 (Action / Talk)` | Story Flag 148 (bit 4) SET AND Story Flag 148 (bit 8) CLEAR | Display Chapter Text (3); Display Speaker Name Box (4); Set Combat Battle BGM (60); Warp Town -> Area 34 Map 66 Submap 50 at (0,34); Launch Tactical War Battle (1); Set Combat Battle BGM (20); Engine Action #89; Set Story Flag (2, 2); Set Combat Battle BGM (10); Load Sound Bank into Memory (1, 22); Warp to Castle HQ (73, 60, 72); Open Dialogue Message Window; Set Story Flag (54, 0); Warp Room -> Submap 4 at (123,0) facing 8; Engine Action #9; Engine Action #148; Reset Camera Tracking (255) |
| `ev[07]` | `128 (Loop)` | Story Flag 148 (bit 4) SET AND Story Flag 148 (bit 8) CLEAR AND Inventory Holds Item #1 [Medicine] | Jump to Bytecode Offset (0, 54); Engine Action #5; Return Warp to Castle Base (4, 6); Warp Room -> Submap 30 at (101,5) facing 54; Warp Room -> Submap 37 at (1,255) facing 254 |
| `ev[08]` | `1 (Action / Talk)` | Story Flag 148 (bit 8) SET AND Story Flag 152 (bit 128) CLEAR AND Condition Check #23 AND Condition Check #66 AND Player within Box [33..1, 2..5] AND Condition Check #23 | Close Dialogue Sub-Window (24); Warp Town -> Area 0 Map 255 Submap 254 at (204,204) |
| `ev[09]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #66 AND Player within Box [33..1, 2..1] AND Condition Check #45 AND Condition Check #46 AND Story Flag 134 (bit 1) SET AND Target Inspected is obj[23] | Engine Action #89; Set Story Flag (2, 2); Engine Action #99; Dismiss Dialogue Portrait; Dismiss Dialogue Portrait; Close Dialogue Sub-Window (24); Open Dialogue Message Window; Pan Camera (99, 13, 128) |
| `ev[10]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #66 AND Player within Box [33..1, 2..1] AND Condition Check #40 AND Condition Check #41 AND Story Flag 134 (bit 1) SET AND Target Inspected is obj[23] | Engine Action #89; Set Story Flag (2, 1); Engine Action #99; Dismiss Dialogue Portrait; Dismiss Dialogue Portrait; Close Dialogue Sub-Window (24); Open Dialogue Message Window; Pan Camera (99, 13, 128) |
| `ev[11]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #66 AND Player within Box [33..1, 2..2] AND Condition Check #36 AND Condition Check #37 AND Story Flag 134 (bit 1) SET AND Target Inspected is obj[23] | Engine Action #89; Set Story Flag (2, 3); Engine Action #99; Dismiss Dialogue Portrait; Dismiss Dialogue Portrait; Close Dialogue Sub-Window (24); Open Dialogue Message Window; Pan Camera (99, 13, 128) |
| `ev[12]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #66 AND Player within Box [33..1, 2..1] AND Condition Check #45 AND Condition Check #46 AND Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[23] | Engine Action #89; Set Story Flag (2, 2); Engine Action #99; Dismiss Dialogue Portrait; Dismiss Dialogue Portrait; Close Dialogue Sub-Window (24); Open Dialogue Message Window; Pan Camera (99, 13, 128) |
| `ev[13]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #66 AND Player within Box [33..1, 2..1] AND Condition Check #40 AND Condition Check #41 AND Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[23] | Engine Action #89; Set Story Flag (2, 1); Engine Action #99; Dismiss Dialogue Portrait; Dismiss Dialogue Portrait; Close Dialogue Sub-Window (24); Open Dialogue Message Window; Pan Camera (99, 13, 128) |
| `ev[14]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #66 AND Player within Box [33..1, 2..2] AND Condition Check #36 AND Condition Check #37 AND Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[23] | Engine Action #89; Set Story Flag (2, 3); Engine Action #99; Dismiss Dialogue Portrait; Dismiss Dialogue Portrait; Close Dialogue Sub-Window (24); Open Dialogue Message Window; Pan Camera (99, 13, 128) |
| `ev[15]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #66 AND Player within Box [33..1, 2..1] AND Condition Check #45 AND Condition Check #46 AND Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[23] | Engine Action #89; Set Story Flag (2, 2); Engine Action #99; Dismiss Dialogue Portrait; Dismiss Dialogue Portrait; Close Dialogue Sub-Window (24); Open Dialogue Message Window; Pan Camera (99, 13, 128) |
| `ev[16]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #66 AND Player within Box [33..1, 2..1] AND Condition Check #40 AND Condition Check #41 AND Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[23] | Engine Action #89; Set Story Flag (2, 1); Engine Action #99; Dismiss Dialogue Portrait; Dismiss Dialogue Portrait; Close Dialogue Sub-Window (24); Open Dialogue Message Window; Pan Camera (99, 13, 128) |
| `ev[17]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #66 AND Player within Box [33..1, 2..2] AND Condition Check #36 AND Condition Check #37 AND Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[23] | Engine Action #89; Set Story Flag (2, 3); Engine Action #99; Dismiss Dialogue Portrait; Dismiss Dialogue Portrait; Close Dialogue Sub-Window (24); Open Dialogue Message Window; Pan Camera (99, 13, 128) |
| `ev[18]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #66 AND Player within Box [33..1, 2..1] AND Condition Check #45 AND Condition Check #46 AND Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[23] | Engine Action #89; Set Story Flag (2, 2); Engine Action #99; Dismiss Dialogue Portrait; Dismiss Dialogue Portrait; Close Dialogue Sub-Window (24); Open Dialogue Message Window; Pan Camera (99, 13, 128) |
| `ev[19]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #66 AND Player within Box [33..1, 2..1] AND Condition Check #40 AND Condition Check #41 AND Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[23] | Engine Action #89; Set Story Flag (2, 1); Engine Action #99; Dismiss Dialogue Portrait; Dismiss Dialogue Portrait; Close Dialogue Sub-Window (24); Open Dialogue Message Window; Pan Camera (99, 13, 128) |
| `ev[20]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #66 AND Player within Box [33..1, 2..2] AND Condition Check #36 AND Condition Check #37 AND Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[23] | Engine Action #89; Set Story Flag (2, 3); Engine Action #99; Dismiss Dialogue Portrait; Dismiss Dialogue Portrait; Close Dialogue Sub-Window (24); Open Dialogue Message Window; Pan Camera (99, 13, 128) |
| `ev[21]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #66 AND Player within Box [33..1, 2..1] AND Condition Check #45 AND Condition Check #46 AND Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[23] | Engine Action #89; Set Story Flag (2, 2); Engine Action #99; Dismiss Dialogue Portrait; Dismiss Dialogue Portrait; Close Dialogue Sub-Window (24); Open Dialogue Message Window; Pan Camera (99, 13, 128) |
| `ev[22]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #66 AND Player within Box [33..1, 2..1] AND Condition Check #40 AND Condition Check #41 AND Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[23] | Engine Action #89; Set Story Flag (2, 1); Engine Action #99; Dismiss Dialogue Portrait; Dismiss Dialogue Portrait; Close Dialogue Sub-Window (24); Open Dialogue Message Window; Pan Camera (99, 13, 128) |
| `ev[23]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #66 AND Player within Box [33..1, 2..2] AND Condition Check #36 AND Condition Check #37 AND Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[23] | Engine Action #89; Set Story Flag (2, 3); Engine Action #99; Dismiss Dialogue Portrait; Dismiss Dialogue Portrait; Close Dialogue Sub-Window (24); Open Dialogue Message Window; Pan Camera (99, 13, 128) |
| `ev[24]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #66 AND Player within Box [33..1, 2..1] AND Condition Check #45 AND Condition Check #46 AND Target Inspected is obj[23] | Engine Action #89; Set Story Flag (2, 2); Engine Action #99; Dismiss Dialogue Portrait; Dismiss Dialogue Portrait; Close Dialogue Sub-Window (24); Open Dialogue Message Window; Pan Camera (99, 13, 128) |
| `ev[25]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #66 AND Player within Box [33..1, 2..1] AND Condition Check #40 AND Condition Check #41 AND Target Inspected is obj[23] | Engine Action #89; Set Story Flag (2, 1); Engine Action #99; Dismiss Dialogue Portrait; Dismiss Dialogue Portrait; Close Dialogue Sub-Window (24); Open Dialogue Message Window; Pan Camera (99, 13, 128) |
| `ev[26]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #66 AND Player within Box [33..1, 2..2] AND Condition Check #36 AND Condition Check #37 AND Target Inspected is obj[23] | Engine Action #89; Set Story Flag (2, 3); Engine Action #99; Dismiss Dialogue Portrait; Dismiss Dialogue Portrait; Close Dialogue Sub-Window (24); Open Dialogue Message Window; Pan Camera (99, 13, 128) |
| `ev[27]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #66 AND Player within Box [33..1, 2..29] AND Party Holds At Least 12,800 Potch | Set Combat Battle BGM (20); Engine Action #127; Open Dialogue Message Window; Dismiss Dialogue Portrait; Dismiss Dialogue Portrait; Recruit Riou (Hero) into Battle Slot 0; Engine Action #9; Load Sound Bank into Memory (16, 89); Set Story Flag (2, 0); Mark NPC Talk Interaction Complete (Flag #13); Engine Action #128 |
| `ev[28]` | `128 (Loop)` | Condition Check #23 AND Condition Check #66 AND Player within Box [33..1, 2..29] AND Star of Destiny #16 Recruited | Warp Room -> Submap 1 at (13,19); Mark NPC Talk Interaction Complete (Flag #16); Dismiss Dialogue Portrait |
| `ev[29]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[26] | Close Dialogue Sub-Window (25); Engine Action #5; Reset Camera Tracking (3); Clear Dialogue Sub-Window; Open Dialogue Message Window |
| `ev[30]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[26] | Close Dialogue Sub-Window (25); Engine Action #6; Reset Camera Tracking (3); Clear Dialogue Sub-Window; Open Dialogue Message Window |
| `ev[31]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[26] | Close Dialogue Sub-Window (25); Pan Camera (8, 3, 25); Open Dialogue Message Window |
| `ev[32]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[26] | Close Dialogue Sub-Window (25); Reset Camera Tracking (8); Warp to Castle HQ (25, 0, 255) |
| `ev[33]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[26] | Close Dialogue Sub-Window (25); Engine Action #9; Reset Camera Tracking (3); Clear Dialogue Sub-Window; Open Dialogue Message Window |
| `ev[34]` | `1 (Action / Talk)` | Target Inspected is obj[26] | Close Dialogue Sub-Window (25); Open Dialogue Message Window; Reset Camera Tracking (3); Clear Dialogue Sub-Window; Open Dialogue Message Window |
| `ev[35]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[28] | Close Dialogue Sub-Window (27); Engine Action #5; Engine Action #9 |
| `ev[36]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[28] | Close Dialogue Sub-Window (27); Engine Action #6; Engine Action #9 |
| `ev[37]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[28] | Close Dialogue Sub-Window (27); Pan Camera (9, 255, 254) |
| `ev[38]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[28] | Close Dialogue Sub-Window (27); Reset Camera Tracking (9) |
| `ev[39]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[28] | Close Dialogue Sub-Window (27); Engine Action #9; Engine Action #9 |
| `ev[40]` | `1 (Action / Talk)` | Target Inspected is obj[28] | Close Dialogue Sub-Window (27); Open Dialogue Message Window; Engine Action #9 |
| `ev[41]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[30] | Close Dialogue Sub-Window (29); Engine Action #5; Close Dialogue Window |
| `ev[42]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[30] | Close Dialogue Sub-Window (29); Engine Action #6; Close Dialogue Window |
| `ev[43]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[30] | Close Dialogue Sub-Window (29); Pan Camera (11, 255, 254) |
| `ev[44]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[30] | Close Dialogue Sub-Window (29); Reset Camera Tracking (11) |
| `ev[45]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[30] | Close Dialogue Sub-Window (29); Engine Action #9; Close Dialogue Window |
| `ev[46]` | `1 (Action / Talk)` | Target Inspected is obj[30] | Close Dialogue Sub-Window (29); Open Dialogue Message Window; Close Dialogue Window |
| `ev[47]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[33] | Open Dialogue Sub-Window (5); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[48]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[33] | Open Dialogue Sub-Window (6); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[49]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[33] | Open Dialogue Sub-Window (7); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[50]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[33] | Open Dialogue Sub-Window (8); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[51]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[33] | Open Dialogue Sub-Window (9); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[52]` | `1 (Action / Talk)` | Target Inspected is obj[33] | Open Dialogue Sub-Window (0); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[53]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[32] | Close Dialogue Sub-Window (31); Engine Action #5; Place Scenery Structure (255) |
| `ev[54]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[32] | Close Dialogue Sub-Window (31); Engine Action #6; Place Scenery Structure (255) |
| `ev[55]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[32] | Close Dialogue Sub-Window (31); Pan Camera (13, 255, 254) |
| `ev[56]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[32] | Close Dialogue Sub-Window (31); Reset Camera Tracking (13) |
| `ev[57]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[32] | Close Dialogue Sub-Window (31); Engine Action #9; Place Scenery Structure (255) |
| `ev[58]` | `1 (Action / Talk)` | Target Inspected is obj[32] | Close Dialogue Sub-Window (31); Open Dialogue Message Window; Place Scenery Structure (255) |
| `ev[59]` | `128 (Loop)` | Player within Box [24..72, 2..44] AND Condition Check #64 | Warp Room -> Submap 1 at (10,19) |
| `ev[60]` | `1 (Action / Talk)` | Player within Box [64..68, 2..26] AND Treasure Byte 9 Bit 1 LOOTED | Display Dialogue Box [Bank: 1, MsgID: 136]; Toggle Random Encounters (255) |
| `ev[61]` | `1 (Action / Talk)` | Player within Box [28..32, 2..26] AND Treasure Byte 9 Bit 1 LOOTED | Display Dialogue Box [Bank: 1, MsgID: 100]; Toggle Random Encounters (255) |
| `ev[62]` | `1 (Action / Talk)` | Player within Box [26..34, 2..68] AND Condition Check #69 AND Story Flag 0 (mask 255) SET | Warp Map Transition (2, 0, 18, 11, 255) |
| `ev[63]` | `1 (Action / Talk)` | Player within Box [38..46, 2..68] AND Condition Check #69 AND Story Flag 0 (mask 255) SET | Warp Map Transition (2, 0, 30, 11, 255) |
| `ev[64]` | `1 (Action / Talk)` | Player within Box [50..58, 2..68] AND Condition Check #69 AND Story Flag 0 (mask 255) SET | Warp Map Transition (2, 0, 42, 11, 255) |
| `ev[65]` | `1 (Action / Talk)` | Player within Box [62..70, 2..68] AND Condition Check #69 AND Story Flag 0 (mask 255) SET | Warp Map Transition (2, 0, 54, 11, 255) |
| `ev[66]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [2..255] | Open Dialogue Message Window; Start Boss Battle #255 (BGM: 254) |
| `ev[67]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [2..255] | Open Dialogue Message Window; Launch Tactical War Battle (255) |
| `ev[68]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [2..255] | Open Dialogue Message Window; Toggle Random Encounters (255) |
| `ev[69]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [3..255] | Open Dialogue Message Window; Open Save Crystal Menu (MSaveInit) |
| `ev[70]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #35 AND Condition Check #23 AND Player within Box [33..1, 2..255] | Open Dialogue Message Window; Engine Action #39 |
| `ev[71]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #35 AND Inventory Lacks Item #32 AND Condition Check #33 AND Player X within Range [3..255] | Open Dialogue Message Window; Engine Action #40 |
| `ev[72]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [2..255] | Open Dialogue Message Window; Award Potch Loot (+65,534 Potch) |
| `ev[73]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [2..255] | Open Dialogue Message Window; Remove Item from Inventory (255, 254) |
| `ev[74]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [3..255] | Open Dialogue Message Window; Open Shop Menu #254 (Type: 255) |
| `ev[75]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[35] | Engine Action #118; Start Boss Battle #4 (BGM: 0); Screen Fade Transition (10, 255, 254) |
| `ev[76]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[35] | Engine Action #118; Start Boss Battle #4 (BGM: 0); Close Dialogue Window; Screen Fade Transition (255, 254, 204) |
| `ev[77]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[35] | Engine Action #118; Start Boss Battle #4 (BGM: 0); Display Dialogue Box [Bank: 10, MsgID: 255] |
| `ev[78]` | `1 (Action / Talk)` | Target Inspected is obj[35] | Engine Action #118; Start Boss Battle #4 (BGM: 0); Warp to Castle HQ (10, 255, 254) |
| `ev[79]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[36] | Close Dialogue Sub-Window (36); Screen Fade Transition (11, 255, 254) |
| `ev[80]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[36] | Close Dialogue Sub-Window (36); Close Dialogue Window; Close Dialogue Window |
| `ev[81]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[36] | Close Dialogue Sub-Window (36); Display Dialogue Box [Bank: 11, MsgID: 255] |
| `ev[82]` | `1 (Action / Talk)` | Target Inspected is obj[36] | Close Dialogue Sub-Window (36); Warp to Castle HQ (11, 255, 254) |
| `ev[83]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[37] | Close Dialogue Sub-Window (37); Screen Fade Transition (12, 255, 254) |
| `ev[84]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[37] | Close Dialogue Sub-Window (37); Close Dialogue Window; Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[85]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[37] | Close Dialogue Sub-Window (37); Display Dialogue Box [Bank: 12, MsgID: 255] |
| `ev[86]` | `1 (Action / Talk)` | Target Inspected is obj[37] | Close Dialogue Sub-Window (37); Warp to Castle HQ (12, 255, 254) |
| `ev[87]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[38] | Close Dialogue Sub-Window (38); Screen Fade Transition (13, 255, 254) |
| `ev[88]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[38] | Close Dialogue Sub-Window (38); Close Dialogue Window; Place Scenery Structure (255) |
| `ev[89]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[38] | Close Dialogue Sub-Window (38); Display Dialogue Box [Bank: 13, MsgID: 255] |
| `ev[90]` | `1 (Action / Talk)` | Target Inspected is obj[38] | Close Dialogue Sub-Window (38); Warp to Castle HQ (13, 255, 254) |
| `ev[91]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[39] | Close Dialogue Sub-Window (39); Screen Fade Transition (14, 3, 39); Open Dialogue Message Window |
| `ev[92]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[39] | Close Dialogue Sub-Window (39); Close Dialogue Window; Animate Door Open; Warp to Castle HQ (39, 0, 255) |
| `ev[93]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[39] | Close Dialogue Sub-Window (39); Display Dialogue Box [Bank: 14, MsgID: 3]; Engine Action #39; Open Dialogue Message Window |
| `ev[94]` | `1 (Action / Talk)` | Target Inspected is obj[39] | Close Dialogue Sub-Window (39); Warp to Castle HQ (14, 3, 39); Open Dialogue Message Window |
| `ev[95]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[40] | Close Dialogue Sub-Window (40); Screen Fade Transition (15, 3, 40); Open Dialogue Message Window |
| `ev[96]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[40] | Close Dialogue Sub-Window (40); Close Dialogue Window; Show Dialogue Portrait (3, 40, 0) |
| `ev[97]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[40] | Close Dialogue Sub-Window (40); Display Dialogue Box [Bank: 15, MsgID: 3]; Engine Action #40; Open Dialogue Message Window |
| `ev[98]` | `1 (Action / Talk)` | Target Inspected is obj[40] | Close Dialogue Sub-Window (40); Warp to Castle HQ (15, 3, 40); Open Dialogue Message Window |
| `ev[99]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[41] | Close Dialogue Sub-Window (41); Screen Fade Transition (16, 3, 41); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[100]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[41] | Close Dialogue Sub-Window (41); Close Dialogue Window; Dismiss Dialogue Portrait; Warp to Castle HQ (41, 1, 255) |
| `ev[101]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[41] | Close Dialogue Sub-Window (41); Display Dialogue Box [Bank: 16, MsgID: 3]; Award Potch Loot (+511 Potch) |
| `ev[102]` | `1 (Action / Talk)` | Target Inspected is obj[41] | Close Dialogue Sub-Window (41); Warp to Castle HQ (16, 3, 41); Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[103]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[42] | Close Dialogue Sub-Window (42); Screen Fade Transition (17, 3, 42); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[104]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[42] | Close Dialogue Sub-Window (42); Close Dialogue Window; Change Portrait Expression (3); Remove Item from Inventory (1, 255) |
| `ev[105]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[42] | Close Dialogue Sub-Window (42); Display Dialogue Box [Bank: 17, MsgID: 3]; Remove Item from Inventory (1, 255) |
| `ev[106]` | `1 (Action / Talk)` | Target Inspected is obj[42] | Close Dialogue Sub-Window (42); Warp to Castle HQ (17, 3, 42); Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[107]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[43] | Close Dialogue Sub-Window (43); Screen Fade Transition (18, 3, 43); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[108]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[43] | Close Dialogue Sub-Window (43); Close Dialogue Window; Display Speaker Name Box (3); Open Shop Menu #255 (Type: 1) |
| `ev[109]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[43] | Close Dialogue Sub-Window (43); Display Dialogue Box [Bank: 18, MsgID: 3]; Open Shop Menu #255 (Type: 1) |
| `ev[110]` | `1 (Action / Talk)` | Target Inspected is obj[43] | Close Dialogue Sub-Window (43); Warp to Castle HQ (18, 3, 43); Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[111]` | `1 (Action / Talk)` | Target Inspected is obj[8] | Open Dialogue Sub-Window (1); Open Dialogue Message Window |
| `ev[112]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Open Dialogue Sub-Window (1); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[113]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Open Dialogue Sub-Window (1); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[114]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Open Dialogue Sub-Window (1); Warp to Castle HQ (255, 254, 204) |
| `ev[115]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Open Dialogue Sub-Window (1); Exit to World Map (255, 254, 204) |
| `ev[116]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Open Dialogue Sub-Window (1); Engine Action #5 |
| `ev[117]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Open Dialogue Sub-Window (1); Engine Action #6 |
| `ev[118]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Open Dialogue Sub-Window (1); Pan Camera (255, 254, 204) |
| `ev[119]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Open Dialogue Sub-Window (1); Reset Camera Tracking (255) |
| `ev[120]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Open Dialogue Sub-Window (1); Engine Action #9 |
| `ev[121]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Open Dialogue Sub-Window (1); Screen Fade Transition (255, 254, 204) |
| `ev[122]` | `1 (Action / Talk)` | Target Inspected is obj[19] | Open Dialogue Sub-Window (1); Close Dialogue Window |
| `ev[123]` | `1 (Action / Talk)` | Target Inspected is obj[20] | Open Dialogue Sub-Window (1); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[124]` | `1 (Action / Talk)` | Target Inspected is obj[21] | Open Dialogue Sub-Window (1); Place Scenery Structure (255) |

---

### Submap Layer `vk06_03` (Index 3)

- **Map Number (`mapno`)**: `2`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `5` Objects | **Script Count (`evkaz`)**: `41` Scripts

#### Complete Physical Entity Inventory (5 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 93** | `93` | `(26, 105)` | `5x5` | East (Right) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[01]` | NPC / Actor | **Jowy Atreides** | `2` | `(25, 114)` | `5x5` | East (Right) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[02]` | NPC / Actor | **Emilia** | `55` | `(25, 114)` | `5x5` | East (Right) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[03]` | NPC / Actor | **Youth Brigade Recruit** | `3` | `(64, 121)` | `5x5` | East (Right) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[04]` | NPC / Actor | **Actor ID 65107** | `65107` | `(31, 133)` | `15x5` | South (Down) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 93)**: Positioned at tile `(26, 105)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Jowy Atreides)**: Positioned at tile `(25, 114)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Emilia)**: Positioned at tile `(25, 114)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Youth Brigade Recruit)**: Positioned at tile `(64, 121)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Object 65107)**: Positioned at tile `(31, 133)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.


#### Complete Bytecode Script Catalog (41 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 48 (bit 32) CLEAR AND Condition Check #23 AND Condition Check #93 AND Player within Box [33..0, 1..255] | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[01]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[8] | Open Dialogue Sub-Window (5); Animate Door Open |
| `ev[02]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[8] | Open Dialogue Sub-Window (6); Animate Door Open |
| `ev[03]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[8] | Open Dialogue Sub-Window (7); Animate Door Open |
| `ev[04]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[8] | Open Dialogue Sub-Window (8); Animate Door Open |
| `ev[05]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[8] | Open Dialogue Sub-Window (9); Animate Door Open |
| `ev[06]` | `1 (Action / Talk)` | Target Inspected is obj[8] | Open Dialogue Sub-Window (0); Animate Door Open |
| `ev[07]` | `2 (Map Init)` | Story Flag 45 (bit 1) CLEAR AND Condition Check #23 AND Player Y within Range [1..34] AND Always Passes (Unconditional) AND Player within Box [33..0, 1..255] | Open Dialogue Message Window; Engine Action #9 |
| `ev[08]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[9] | Open Dialogue Sub-Window (5); Show Dialogue Portrait (255, 254, 204) |
| `ev[09]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[9] | Open Dialogue Sub-Window (6); Show Dialogue Portrait (255, 254, 204) |
| `ev[10]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[9] | Open Dialogue Sub-Window (7); Show Dialogue Portrait (255, 254, 204) |
| `ev[11]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[9] | Open Dialogue Sub-Window (8); Show Dialogue Portrait (255, 254, 204) |
| `ev[12]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[9] | Open Dialogue Sub-Window (9); Show Dialogue Portrait (255, 254, 204) |
| `ev[13]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Open Dialogue Sub-Window (0); Show Dialogue Portrait (255, 254, 204) |
| `ev[14]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #55 AND Player within Box [34..5, 1..33] AND Always Passes (Unconditional) AND Player X within Range [255..254] | Open Dialogue Message Window; Screen Fade Transition (255, 254, 204) |
| `ev[15]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[10] | Open Dialogue Sub-Window (5); Dismiss Dialogue Portrait |
| `ev[16]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[10] | Open Dialogue Sub-Window (6); Dismiss Dialogue Portrait |
| `ev[17]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[10] | Open Dialogue Sub-Window (7); Dismiss Dialogue Portrait |
| `ev[18]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[10] | Open Dialogue Sub-Window (8); Dismiss Dialogue Portrait |
| `ev[19]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[10] | Open Dialogue Sub-Window (9); Dismiss Dialogue Portrait |
| `ev[20]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Open Dialogue Sub-Window (0); Dismiss Dialogue Portrait |
| `ev[21]` | `2 (Map Init)` | Story Flag 46 (bit 1) CLEAR AND Condition Check #23 AND Story Flag 1 (bit 34) SET AND Player within Box [1..33, 0..1] | Open Dialogue Message Window; Close Dialogue Window |
| `ev[22]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[11] | Open Dialogue Sub-Window (5); Change Portrait Expression (255) |
| `ev[23]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[11] | Open Dialogue Sub-Window (6); Change Portrait Expression (255) |
| `ev[24]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[11] | Open Dialogue Sub-Window (7); Change Portrait Expression (255) |
| `ev[25]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[11] | Open Dialogue Sub-Window (8); Change Portrait Expression (255) |
| `ev[26]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[11] | Open Dialogue Sub-Window (9); Change Portrait Expression (255) |
| `ev[27]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Open Dialogue Sub-Window (0); Change Portrait Expression (255) |
| `ev[28]` | `128 (Loop)` | Player within Box [24..72, 2..102] AND Condition Check #135 | Warp Room -> Submap 1 at (10,19) |
| `ev[29]` | `1 (Action / Talk)` | Player within Box [64..68, 2..98] AND Condition Check #99 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 136]; Toggle Random Encounters (255) |
| `ev[30]` | `1 (Action / Talk)` | Player within Box [28..32, 2..98] AND Condition Check #99 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 100]; Toggle Random Encounters (255) |
| `ev[31]` | `1 (Action / Talk)` | Player within Box [64..68, 2..26] AND Treasure Byte 9 Bit 1 LOOTED | Display Dialogue Box [Bank: 1, MsgID: 136]; Toggle Random Encounters (255) |
| `ev[32]` | `1 (Action / Talk)` | Player within Box [26..34, 2..140] AND Condition Check #141 AND Story Flag 0 (mask 255) SET | Warp Map Transition (2, 1, 18, 11, 255) |
| `ev[33]` | `1 (Action / Talk)` | Player within Box [38..46, 2..140] AND Condition Check #141 AND Story Flag 0 (mask 255) SET | Warp Map Transition (2, 1, 30, 11, 255) |
| `ev[34]` | `1 (Action / Talk)` | Player within Box [50..58, 2..140] AND Condition Check #141 AND Story Flag 0 (mask 255) SET | Warp Map Transition (2, 1, 42, 11, 255) |
| `ev[35]` | `1 (Action / Talk)` | Player within Box [62..70, 2..140] AND Condition Check #141 AND Story Flag 0 (mask 255) SET | Warp Map Transition (2, 1, 54, 11, 255) |
| `ev[36]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [1..255] | Open Dialogue Message Window; Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[37]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[12] | Close Dialogue Sub-Window (12); Screen Fade Transition (19, 255, 254) |
| `ev[38]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[12] | Close Dialogue Sub-Window (12); Close Dialogue Window; Display Choice Selection (255, 254) |
| `ev[39]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[12] | Close Dialogue Sub-Window (12); Display Dialogue Box [Bank: 19, MsgID: 255] |
| `ev[40]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Close Dialogue Sub-Window (12); Warp to Castle HQ (19, 255, 254) |

---


