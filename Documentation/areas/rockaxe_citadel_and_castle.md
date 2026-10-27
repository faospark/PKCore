# Suikoden II Geographic Area Catalog: Rockaxe Castle Citadel & Ramparts

**Geographic Scope & Role**: Fortress of the White Knights of Matilda; grand castle keep, throne room, knightly barracks, stone battlements, and Gorudo's war room.

**Regional Category**: Region `VI` | **Master Maps Included**: `vi01`, `vi02`, `vi03`, `vi04`, `vi05`, `vi06`, `vi07`, `vi10`

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

## Location Map: `vi01`

- **Master Map Container**: `vi01.json`
- **Submap Layer Files**: Embedded in master
- **Collision Grid Files**: vi01_map_00.json, vi01_map_01.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 2

### Submap Layer `vi01_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `37` Objects | **Script Count (`evkaz`)**: `76` Scripts

#### Complete Physical Entity Inventory (37 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Camus** | `32` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Miklotov** | `33` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Actor ID 65140** | `65140` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | NPC / Actor | **Actor ID 65140** | `65140` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[04]` | NPC / Actor | **Actor ID 65141** | `65141` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[05]` | NPC / Actor | **Actor ID 65139** | `65139` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[06]` | NPC / Actor | **Actor ID 69** | `69` | `(64, 92)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | NPC / Actor | **Actor ID 65193** | `65193` | `(153, 36)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[08]` | Prop / Scenery | **Prop ID 40449** | `40449` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[09]` | Prop / Scenery | **Prop ID 53573** | `53573` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[10]` | World Device | **Mechanism (ano 46)** | `0` | `(48, 58)` | `0x0` | Frame 46 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | World Device | **Mechanism (ano 1)** | `0` | `(16, 102)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[12]` | World Device | **Mechanism (ano 1)** | `0` | `(62, 118)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[13]` | World Device | **Mechanism (ano 1)** | `0` | `(2, 66)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[14]` | World Device | **Mechanism (ano 1)** | `0` | `(68, 52)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[15]` | Trigger / Hitbox | **Hitbox Zone (2x13)** | `0` | `(66, 67)` | `1x12` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[16]` | NPC / Actor | **Actor ID 64841** | `64841` | `(17, 32)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[17]` | NPC / Actor | **Actor ID 65177** | `65177` | `(55, 35)` | `3x4` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[18]` | NPC / Actor | **Actor ID 65226** | `65226` | `(44, 63)` | `3x2` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[19]` | NPC / Actor | **Actor ID 65218** | `65218` | `(56, 62)` | `3x3` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[20]` | NPC / Actor | **Actor ID 65140** | `65140` | `(53, 109)` | `4x4` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[21]` | NPC / Actor | **Actor ID 65141** | `65141` | `(3, 85)` | `5x5` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[22]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(11, 102)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[23]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(22, 104)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[24]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(24, 104)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[25]` | Trigger / Hitbox | **Hitbox Zone (4x3)** | `0` | `(71, 119)` | `3x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[26]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(55, 92)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[27]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(55, 90)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[28]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(75, 91)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[29]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(62, 53)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[30]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(66, 54)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[31]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(41, 61)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[32]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(31, 61)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[33]` | Trigger / Hitbox | **Hitbox Zone (5x4)** | `0` | `(52, 31)` | `4x3` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[34]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(21, 56)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[35]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(23, 56)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[36]` | Trigger / Hitbox | **Hitbox Zone (4x3)** | `0` | `(21, 52)` | `3x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Camus)**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Miklotov)**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Object 65140)**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Object 65140)**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Object 65141)**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Object 65139)**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[06]` (Object 69)**: Positioned at tile `(64, 92)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[07]` (Object 65193)**: Positioned at tile `(153, 36)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[08]` (Prop: Object 40449)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[09]` (Prop: Object 53573)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[10]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(48, 58)` with state parameter `46`.
- **`obj[11]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(16, 102)` with state parameter `1`.
- **`obj[12]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(62, 118)` with state parameter `1`.
- **`obj[13]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(2, 66)` with state parameter `1`.
- **`obj[14]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(68, 52)` with state parameter `1`.
- **`obj[15]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `13` tiles high from `(66, 67)` to `(67, 79)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[16]` (Object 64841)**: Positioned at tile `(17, 32)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[17]` (Object 65177)**: Positioned at tile `(55, 35)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[18]` (Object 65226)**: Positioned at tile `(44, 63)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[19]` (Object 65218)**: Positioned at tile `(56, 62)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[20]` (Object 65140)**: Positioned at tile `(53, 109)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[21]` (Object 65141)**: Positioned at tile `(3, 85)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[22]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(11, 102)` to `(13, 103)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[23]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(22, 104)` to `(23, 104)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[24]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(24, 104)` to `(25, 104)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[25]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `3` tiles high from `(71, 119)` to `(74, 121)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[26]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(55, 92)` to `(57, 93)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[27]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(55, 90)` to `(57, 91)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[28]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(75, 91)` to `(78, 92)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[29]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(62, 53)` to `(64, 54)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[30]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(66, 54)` to `(67, 54)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[31]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(41, 61)` to `(43, 62)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[32]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(31, 61)` to `(33, 62)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[33]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `4` tiles high from `(52, 31)` to `(56, 34)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[34]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(21, 56)` to `(22, 56)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[35]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(23, 56)` to `(24, 56)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[36]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `3` tiles high from `(21, 52)` to `(24, 54)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (76 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Star of Destiny #1 Recruited AND Condition Check #68 AND Story Flag 31 (bit 2) SET AND Story Flag 31 (bit 4) CLEAR AND Story Flag 214 (bit 64) CLEAR | Open Dialogue Message Window; Animate Door Open |
| `ev[01]` | `2 (Map Init)` | Story Flag 18 (bit 128) SET | Make obj[1] Hidden (disp = 0); Display Chapter Text (1); Display Emotion Bubble (47, 255) |
| `ev[02]` | `2 (Map Init)` | Story Flag 20 (bit 1) CLEAR | Open Dialogue Message Window; Display Speaker Name Box (255) |
| `ev[03]` | `2 (Map Init)` | Story Flag 20 (bit 1) SET AND Story Flag 20 (bit 2) CLEAR | Make obj[2] Hidden (disp = 0); Display Dialogue Box [Bank: 53, MsgID: 61]; Open Dialogue Message Window; Display Dialogue Box [Bank: 3, MsgID: 12]; Open Dialogue Message Window; Warp Town -> Area 10 Map 47 Submap 61 at (0,10); Warp to Castle HQ (10, 0, 2); Place Scenery Structure (24); Recruit Character into Active Party (0, 13); Warp to Castle HQ (13, 0, 1); Close Dialogue Sub-Window (1); Clear Dialogue Sub-Window; Warp Room -> Submap 1 at (27,1) facing 28; Warp Room -> Submap 0 at (23,138) facing South (Down); Warp Town -> Area 138 Map 1 Submap 2 at (138,2); Warp Town -> Area 138 Map 3 Submap 2 at (47,255) |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [17..19, 2..101] AND Condition Check #102 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 40]; Engine Action #163 |
| `ev[05]` | `1 (Action / Talk)` | Story Flag 94 (bit 8) SET AND Story Flag 59 (bit 1) CLEAR AND Star of Destiny #1 Recruited AND Inventory Holds Item #1 [Medicine] AND Condition Check #63 AND Condition Check #65 AND Player Y within Range [117..118] AND Story Flag 1 (mask 255) SET | Wait for Audio / Window Sync (2); Display Dialogue Box [Bank: 1, MsgID: 35]; Award Potch Currency (255,254) |
| `ev[06]` | `1 (Action / Talk)` | Player within Box [63..65, 2..117] AND Condition Check #118 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 36]; Remove Character from Active Party (255) |
| `ev[07]` | `1 (Action / Talk)` | Player within Box [69..71, 2..51] AND Condition Check #52 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 188]; Wait for Audio / Window Sync (255) |
| `ev[08]` | `1 (Action / Talk)` | Player within Box [3..5, 2..65] AND Condition Check #66 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 154]; Display Dialogue Message (255, 254) |
| `ev[09]` | `1 (Action / Talk)` | Player within Box [66..67, 2..68] AND Condition Check #78 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 143]; Engine Action #179 |
| `ev[10]` | `1 (Action / Talk)` | Player within Box [11..17, 2..15] AND Star of Destiny #9 Recruited AND Player X within Range [255..254] | Warp Room -> Submap 1 at (8,1); Set Special Scene BGM (1); Warp Map Transition (2, 250, 0, 0, 255) |
| `ev[11]` | `1 (Action / Talk)` | Story Flag 20 (bit 1) SET AND Player within Box [49..51, 2..57] AND Condition Check #58 AND Story Flag 1 (mask 255) SET | Warp Room -> Submap 1 at (8,5); Set Special Scene BGM (1); Warp Map Transition (2, 0, 130, 78, 255) |
| `ev[12]` | `128 (Loop)` | Player within Box [44..59, 2..43] AND Condition Check #44 AND Story Flag 1 (mask 255) SET | Warp Room -> Submap 1 at (8,1) |
| `ev[13]` | `128 (Loop)` | Player within Box [35..45, 2..79] AND Condition Check #80 AND Story Flag 1 (mask 255) SET | Warp Room -> Submap 1 at (8,5) |
| `ev[14]` | `128 (Loop)` | Player within Box [1..59, 2..105] AND Condition Check #106 AND Story Flag 0 (mask 255) SET | Warp Room -> Submap 2 at (12,8) |
| `ev[15]` | `128 (Loop)` | Player within Box [64..64, 2..120] AND Condition Check #120 AND Story Flag 0 (mask 255) SET | Warp Room -> Submap 2 at (12,8) |
| `ev[16]` | `1 (Action / Talk)` | Player within Box [33..47, 2..120] AND Condition Check #121 AND Story Flag 0 (mask 255) SET | Warp Room -> Submap 2 at (12,8); Warp Map Transition (0, 0, 52, 84, 255) |
| `ev[17]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) SET AND Story Flag 16 (bit 2) CLEAR AND Player within Box [40..40, 2..122] AND Condition Check #122 | Recruit Character into Active Party (36 [Kahn], 1); Engine Action #5; Open Dialogue Message Window; Exit to World Map (4, 1, 13); Engine Action #5; Screen Fade Transition (30, 46, 2); Reset Camera Tracking (40); Engine Action #109; Open Dialogue Message Window; Reset Camera Tracking (47); Engine Action #5; Reset Camera Tracking (4); Engine Action #5; Warp Room -> Submap 5 at (5,3) facing South (Down); Engine Action #5; Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 24, 8); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Reset Camera Tracking (5); Show Dialogue Portrait (2, 0, 5); Engine Action #5; Warp Room -> Submap 5 at (15,30) facing 11; Warp Town -> Area 2 Map 80 Submap 69 at (3,13); Engine Action #5; Reset Camera Tracking (3); Open Dialogue Message Window; Engine Action #44; Engine Action #90; Engine Action #58 |
| `ev[18]` | `128 (Loop)` | Story Flag 16 (bit 1) SET AND Story Flag 16 (bit 2) CLEAR AND Inventory Holds Item #1 [Medicine] AND Temp Event Flag #2 SET | Close Dialogue Window; Warp Room -> Submap 100 at (36,2) facing 255 |
| `ev[19]` | `1 (Action / Talk)` | Story Flag 17 (bit 2) SET AND Story Flag 19 (bit 1) CLEAR AND Story Flag 17 (bit 4) CLEAR AND Player within Box [48..58, 2..42] AND Condition Check #43 AND Story Flag 0 (mask 255) SET | Recruit Character into Active Party (43 [Ayda], 0); Exit to World Map (55, 0, 48); Teleport obj[8] to (72,1); Open Dialogue Message Window; Open Dialogue Message Window; Set Combat Battle BGM (6); Load Sound Bank into Memory (0, 0); Set Combat Battle BGM (5); Engine Action #44; Make obj[2] Hidden (disp = 0); Reset Camera Tracking (39); Set Character Quest Milestone (0, 8); Warp to Castle HQ (8, 0, 2); Screen Fade Transition (37, 108, 0); Screen Fade Transition (3, 10, 1); Warp Town -> Area 11 Map 41 Submap 108 at (0,11); Warp to Castle HQ (11, 1, 1); Display Chapter Text (47); Full Rest & Healing (Restore HP/MP); Open Dialogue Message Window; Set Animation Pose (2, 8); Engine Action #5; Set Combat Battle BGM (15); Close Dialogue Sub-Window (10); Open Dialogue Message Window; Engine Action #51; Set Combat Battle BGM (15); Close Dialogue Sub-Window (8); Open Dialogue Message Window; Engine Action #52; Set Combat Battle BGM (15); Close Dialogue Sub-Window (11); Open Dialogue Message Window; Engine Action #53; Set Combat Battle BGM (15); Close Dialogue Sub-Window (8); Open Dialogue Message Window; Engine Action #54; Set Combat Battle BGM (15); Launch Tactical War Battle (1); Set Entity Movement Speed (3, 5); Reset Camera Tracking (4); Exit to World Map (0, 17, 30); Engine Action #5; Screen Fade Transition (5, 16, 3); Open Dialogue Message Window; Engine Action #5; Screen Fade Transition (0, 0, 30); Engine Action #5; Close Dialogue Window; Engine Action #5; Change Portrait Expression (2); Open Dialogue Message Window; Engine Action #5; Screen Fade Transition (0, 0, 30); Walk obj[54] to (0,1); Make obj[1] Hidden (disp = 0); Reset Camera Tracking (1); Screen Fade Transition (1, 11, 0); Display Chapter Text (9); Display Choice Selection (1, 47); Engine Action #58 |
| `ev[20]` | `128 (Loop)` | Story Flag 17 (bit 2) SET AND Story Flag 19 (bit 1) CLEAR AND Story Flag 17 (bit 4) CLEAR AND Inventory Holds Item #1 [Medicine] | Set Combat Battle BGM (90); Full Rest & Healing (Restore HP/MP); Warp Room -> Submap 3 at (8,5) facing 29; Pan Camera (37, 1, 255) |
| `ev[21]` | `1 (Action / Talk)` | Story Flag 18 (bit 4) SET AND Story Flag 19 (bit 2) CLEAR AND Story Flag 18 (bit 8) CLEAR AND Player within Box [34..46, 2..110] AND Condition Check #111 AND Story Flag 1 (mask 255) SET | Recruit Character into Active Party (43 [Ayda], 0); Exit to World Map (55, 0, 40); Engine Action #108; Reset Camera Tracking (73); Show Dialogue Portrait (33, 2, 18); Warp Map Transition (46, 0, 1, 0, 2); Teleport obj[49] to (2,5); Warp Room -> Submap 5 at (2,1) facing West (Left); Warp Town -> Area 3 Map 0 Submap 30 at (255,254); Engine Action #5; Warp Town -> Area 4 Map 5 Submap 3 at (2,1); Warp Town -> Area 2 Map 0 Submap 30 at (255,254); Walk obj[73] to (15,24); Warp Room -> Submap 44 at (73,15) facing 24; Warp Town -> Area 1 Map 45 Submap 73 at (15,24); Warp Room -> Submap 46 at (73,15) facing 49; Warp Town -> Area 5 Map 1 Submap 4 at (5,0); Warp Town -> Area 3 Map 1 Submap 30 at (1,1); Engine Action #5; Warp Town -> Area 4 Map 5 Submap 0 at (2,2); Warp Town -> Area 30 Map 1 Submap 2 at (255,254); Walk obj[9] to (19,2); Engine Action #58 |
| `ev[22]` | `1 (Action / Talk)` | Story Flag 18 (bit 16) SET AND Story Flag 18 (bit 128) CLEAR AND Player within Box [16..16, 2..11] AND Player X in Range [9..0] | Recruit Character into Active Party (46 [Oulan], 2); Reset Camera Tracking (17); Show Dialogue Portrait (0, 8, 2); Engine Action #9; Place Scenery Structure (13); Open Dialogue Message Window; Engine Action #9; Warp Room -> Submap 36 at (1,36) facing Up (North); Teleport obj[49] to (3,5); Open Dialogue Message Window; Exit to World Map (4, 0, 15); Dismiss Emotion Bubble (255); Engine Action #5; Reset Camera Tracking (4); Exit to World Map (0, 14, 2); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp Room -> Submap 30 at (255,254) facing 5; Engine Action #9; Exit to World Map (4, 0, 15); Warp to Castle HQ (0, 5, 5); Warp Room -> Submap 30 at (255,254) facing 50; Set Combat Battle BGM (15); Close Dialogue Sub-Window (8); Warp Room -> Submap 5 at (9,5) facing 15; Warp to Castle HQ (0, 30, 5); Reset Camera Tracking (5); Screen Fade Transition (2, 0, 5); Show Dialogue Portrait (30, 24, 9); Warp Room -> Submap 73 at (15,24) facing 8; Warp Room -> Submap 73 at (15,24) facing 9; Warp Room -> Submap 49 at (2,5) facing 9; Exit to World Map (4, 1, 2); Warp to Castle HQ (0, 30, 255); Engine Action #5; Reset Camera Tracking (5); Screen Fade Transition (1, 0, 30); Walk obj[5] to (0,5); Screen Fade Transition (2, 0, 5); Dismiss Emotion Bubble (30); Set Entity Movement Speed (2, 5); Engine Action #9; Exit to World Map (4, 1, 15); Dismiss Emotion Bubble (255); Engine Action #5; Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp Room -> Submap 30 at (255,254) facing 50; Warp Room -> Submap 5 at (0,5) facing 30; Warp to Castle HQ (0, 5, 5); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 24, 8); Warp Room -> Submap 73 at (20,54) facing South (Down); Warp Town -> Area 112 Map 4 Submap 0 at (1,32); Warp Town -> Area 70 Map 2 Submap 0 at (5,8); Exit to World Map (5, 2, 1); Warp Room -> Submap 30 at (1,8) facing 46; Show Character Dialogue Portrait (35, 64, 124); Return Warp to Castle Base (64, 124); Make obj[64] Hidden (disp = 0); Show Character Dialogue Portrait (36, 64, 9); Display Speaker Name Box (128); Teleport obj[13] to (5,4); Warp to Castle HQ (4, 60, 32); Engine Action #58 |
| `ev[23]` | `128 (Loop)` | Story Flag 18 (bit 16) SET AND Story Flag 18 (bit 32) CLEAR AND Inventory Holds Item #1 [Medicine] | Close Dialogue Window; Warp Room -> Submap 100 at (37,1) facing 255 |
| `ev[24]` | `128 (Loop)` | Story Flag 18 (bit 16) SET AND Story Flag 18 (bit 32) CLEAR AND Inventory Holds Item #2 [Mega Medicine] | Warp Room -> Submap 2 at (13,28); Toggle Random Encounters (2) |
| `ev[25]` | `1 (Action / Talk)` | Story Flag 20 (bit 1) SET AND Story Flag 20 (bit 2) CLEAR AND Story Flag 20 (bit 32) CLEAR AND Player within Box [50..50, 2..66] AND Condition Check #66 | Recruit Character into Active Party (46 [Oulan], 36); Warp Room -> Submap 0 at (1,2) facing 12; Engine Action #53; Engine Action #61; Open Dialogue Message Window; Display Dialogue Box [Bank: 3, MsgID: 12]; Open Dialogue Message Window; Warp Town -> Area 10 Map 47 Submap 61 at (0,10); Warp to Castle HQ (10, 0, 2); Place Scenery Structure (24); Set Animation Pose (0, 13); Warp to Castle HQ (13, 0, 1); Close Dialogue Sub-Window (1); Clear Dialogue Sub-Window; Warp Room -> Submap 1 at (27,1) facing 28; Teleport obj[11] to (1,2); Mark NPC Talk Interaction Complete (Flag #73); Show Dialogue Portrait (24, 10, 3); Open Dialogue Message Window; Set Combat Battle BGM (15); Close Dialogue Sub-Window (12); Warp to Castle HQ (1, 73, 15); Engine Action #54; Open Dialogue Message Window; Warp Room -> Submap 0 at (4,4) facing West (Left); Reset Camera Tracking (30); Engine Action #9; Branch on Choice (32, 74); Warp Room -> Submap 2 at (0,130) facing 78; Engine Action #58 |
| `ev[26]` | `128 (Loop)` | Story Flag 20 (bit 1) SET AND Story Flag 20 (bit 2) CLEAR AND Story Flag 20 (bit 32) CLEAR AND Inventory Holds Item #1 [Medicine] | Warp Room -> Submap 1 at (8,5); Toggle Random Encounters (1) |
| `ev[27]` | `1 (Action / Talk)` | Story Flag 20 (bit 1) SET AND Story Flag 20 (bit 2) CLEAR AND Target Inspected is obj[10] | Open Dialogue Sub-Window (3); Warp Town -> Area 3 Map 10 Submap 0 at (255,254) |
| `ev[28]` | `1 (Action / Talk)` | Story Flag 20 (bit 1) SET AND Story Flag 20 (bit 2) CLEAR AND Target Inspected is obj[12] | Open Dialogue Sub-Window (3); Warp to Castle HQ (3, 12, 0) |
| `ev[29]` | `1 (Action / Talk)` | Story Flag 20 (bit 1) SET AND Story Flag 20 (bit 2) CLEAR AND Player within Box [20..26, 2..60] AND Condition Check #61 AND Story Flag 1 (mask 255) SET | Recruit Character into Active Party (24 [Milie], 13); Warp to Castle HQ (4, 5, 0); Warp to Castle HQ (0, 5, 5); Exit to World Map (4, 0, 3); Dismiss Emotion Bubble (58) |
| `ev[30]` | `1 (Action / Talk)` | Story Flag 31 (bit 2) SET AND Story Flag 31 (bit 4) CLEAR AND Target Inspected is obj[14] | Recruit Character into Active Party (43 [Ayda], 0); Exit to World Map (55, 0, 63); Engine Action #89; Engine Action #9; Warp to Castle HQ (0, 0, 3); Animate Door Open; Warp Town -> Area 33 Map 1 Submap 68 at (0,1); Engine Action #5; Warp Room -> Submap 5 at (2,2) facing South (Down); Warp to Castle HQ (3, 0, 5); Show Dialogue Portrait (30, 24, 1); Exit to World Map (6, 73, 15); Close Dialogue Sub-Window (14); Exit to World Map (7, 73, 15); Close Dialogue Sub-Window (1); Exit to World Map (8, 73, 15); Close Dialogue Sub-Window (14); Exit to World Map (9, 73, 15); Close Dialogue Sub-Window (1); Exit to World Map (10, 73, 15); Close Dialogue Sub-Window (14); Exit to World Map (11, 72, 1); Animate Door Open; Engine Action #6; Set Combat Battle BGM (5); Load Sound Bank into Memory (0, 14); Set Entity Movement Speed (3, 5); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Exit to World Map (5, 2, 1); Dismiss Emotion Bubble (255); Engine Action #5; Animate Door Open; Exit to World Map (6, 2, 6); Dismiss Emotion Bubble (255); Engine Action #5; Warp Room -> Submap 2 at (4,6) facing 7; Engine Action #5; Dismiss Emotion Bubble (255); Walk obj[24] to (1,4); Display Dialogue Box [Bank: 73, MsgID: 15]; Close Dialogue Sub-Window (14); Exit to World Map (13, 46, 2); Show Dialogue Portrait (26, 84, 0); Show Dialogue Portrait (47, 5, 15); Exit to World Map (6, 3, 22); Engine Action #5; Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Dismiss Emotion Bubble (2); Open Dialogue Message Window; Engine Action #5; Dismiss Emotion Bubble (0); Display Chapter Text (30); Set Combat Battle BGM (30); Close Dialogue Sub-Window (1); Exit to World Map (14, 49, 2); Engine Action #5; Animate Door Open; Exit to World Map (3, 5, 15); Pan Camera (4, 5, 15); Dismiss Emotion Bubble (255); Engine Action #5; Warp Room -> Submap 3 at (5,30) facing East (Right); Warp to Castle HQ (30, 68, 1); Dismiss Emotion Bubble (208); Engine Action #208; Engine Action #208; Walk obj[3] to (0,0); Close Dialogue Sub-Window (14); Exit to World Map (15, 73, 15); Close Dialogue Sub-Window (1); Exit to World Map (16, 5, 1); Engine Action #5; Screen Fade Transition (4, 4, 1); Warp to Castle HQ (3, 1, 5); Show Dialogue Portrait (0, 0, 30); Engine Action #5; Animate Door Open; Engine Action #5; Engine Action #5; Warp Room -> Submap 5 at (10,30) facing 24; Warp Room -> Submap 17 at (73,15) facing 24; Animate Door Open; Exit to World Map (18, 73, 15); Make obj[2] Hidden (disp = 0); Dismiss Dialogue Portrait; Engine Action #62; Engine Action #89; Engine Action #89; Dismiss Dialogue Portrait; Warp Town -> Area 0 Map 1 Submap 0 at (0,16); Teleport obj[73] to (30,49); Warp Town -> Area 5 Map 14 Submap 4 at (7,7); Warp Town -> Area 30 Map 255 Submap 254 at (5,1); Exit to World Map (7, 3, 0); Pan Camera (2, 30, 255); Walk obj[73] to (10,101); Open Dialogue Message Window; Engine Action #186; Make obj[2] Hidden (disp = 0); Change Portrait Expression (62); Engine Action #94; Engine Action #89; Change Portrait Expression (2); Warp to Castle HQ (1, 14, 0); Change Portrait Expression (47); Set Combat Battle BGM (30); Load Sound Bank into Memory (1, 1); Engine Action #9; Close Dialogue Sub-Window (1); Exit to World Map (19, 73, 120); Engine Action #89; Dismiss Dialogue Portrait; Warp Town -> Area 1 Map 73 Submap 40 at (101,0); Engine Action #186; Engine Action #89; Dismiss Dialogue Portrait; Engine Action #5; Engine Action #89; Dismiss Dialogue Portrait; Engine Action #5; Make obj[0] Hidden (disp = 0); Open Dialogue Message Window; Warp Room -> Submap 0 at (14,1) facing 17; Teleport obj[24] to (14,4); Branch on Choice (5, 1); Engine Action #5; Screen Fade Transition (0, 0, 5); Screen Fade Transition (30, 72, 0); Warp Room -> Submap 1 at (4,21) facing 73; Show Dialogue Portrait (24, 14, 4); Set Story Flag (5, 1); Engine Action #5; Screen Fade Transition (6, 1, 5); Screen Fade Transition (30, 24, 1); Exit to World Map (23, 73, 15); Close Dialogue Sub-Window (14); Exit to World Map (24, 73, 30); Make obj[116] Hidden (disp = 0); Wait for Audio / Window Sync (68); Open Dialogue Message Window; Pan Camera (84, 69, 30); Dismiss Character to Castle Base (69 [Long Chan-Chan]); Warp Room -> Submap 47 at (5,0); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 101, 4); Engine Action #6; Engine Action #5; Open Dialogue Message Window; Warp Town -> Area 0 Map 5 Submap 3 at (1,0); Engine Action #5; Warp to Castle HQ (3, 0, 5); Warp to Castle HQ (0, 0, 5); Warp to Castle HQ (30, 89, 0); Warp Town -> Area 8 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Engine Action #89; Open Dialogue Message Window; Warp Town -> Area 9 Map 5 Submap 0 at (6,2); Dismiss Emotion Bubble (89); Open Dialogue Message Window; Warp Town -> Area 10 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Dismiss Emotion Bubble (0); Warp Room -> Submap 5 at (0,0) facing South (Down); Engine Action #5; Show Dialogue Portrait (0, 0, 30); Set Combat Battle BGM (15); Close Dialogue Sub-Window (14); Exit to World Map (25, 73, 15); Close Dialogue Sub-Window (1); Exit to World Map (26, 73, 15); Close Dialogue Sub-Window (14); Exit to World Map (27, 73, 15); Close Dialogue Sub-Window (1); Exit to World Map (28, 5, 14); Exit to World Map (5, 5, 10); Warp Town -> Area 6 Map 30 Submap 24 at (1,4); Display Emotion Bubble (5, 14); Warp Room -> Submap 5 at (15,30) facing 24; Animate Door Open; Exit to World Map (30, 5, 14); Exit to World Map (5, 2, 0); Engine Action #5; Engine Action #5; Open Dialogue Message Window; Display Speaker Name Box (30); Make obj[2] Hidden (disp = 0); Animate Door Open; Teleport obj[112] to (0,14); Teleport obj[73] to (60,49); Exit to World Map (5, 14, 4); Engine Action #6; Warp Room -> Submap 2 at (23,30) facing West (Left); Animate Door Open; Engine Action #5; Show Dialogue Portrait (4, 6, 5); Dismiss Emotion Bubble (1); Fade Out to Black (2); Open Dialogue Sub-Window (30); Warp Room -> Submap 255 at (254,5) facing South (Down); Engine Action #5; Dismiss Emotion Bubble (2); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Warp Room -> Submap 36 at (2,0) facing 30; Walk obj[72] to (1,1); Exit to World Map (73, 60, 72); Open Dialogue Message Window; Warp Room -> Submap 1 at (5,15) facing South (Down); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp to Castle HQ (0, 30, 39); Warp to Castle HQ (0, 0, 34); Engine Action #9; Warp Room -> Submap 4 at (58,255) |
| `ev[31]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) CLEAR AND Target Inspected is obj[24] | Open Dialogue Sub-Window (7); Warp Room -> Submap 24 at (0,255) facing 254 |
| `ev[32]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) SET AND Story Flag 18 (bit 128) CLEAR AND Target Inspected is obj[24] | Open Dialogue Sub-Window (9); Warp Room -> Submap 24 at (0,255) facing 254 |
| `ev[33]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[24] | Open Dialogue Sub-Window (10); Warp Room -> Submap 24 at (0,255) facing 254 |
| `ev[34]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[24] | Open Dialogue Sub-Window (11); Warp Room -> Submap 24 at (0,255) facing 254 |
| `ev[35]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[24] | Open Dialogue Sub-Window (12); Warp Room -> Submap 24 at (0,255) facing 254 |
| `ev[36]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) CLEAR AND Target Inspected is obj[25] | Open Dialogue Sub-Window (7); Warp Town -> Area 255 Map 254 Submap 255 at (254,204) |
| `ev[37]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) SET AND Story Flag 18 (bit 128) CLEAR AND Target Inspected is obj[25] | Open Dialogue Sub-Window (9); Warp Town -> Area 255 Map 254 Submap 255 at (254,204) |
| `ev[38]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[25] | Open Dialogue Sub-Window (10); Warp Town -> Area 255 Map 254 Submap 255 at (254,204) |
| `ev[39]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[25] | Open Dialogue Sub-Window (11); Warp Town -> Area 255 Map 254 Submap 255 at (254,204) |
| `ev[40]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[25] | Open Dialogue Sub-Window (12); Warp Town -> Area 255 Map 254 Submap 255 at (254,204) |
| `ev[41]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) CLEAR AND Target Inspected is obj[26] | Open Dialogue Sub-Window (7); Warp to Castle HQ (255, 254, 255) |
| `ev[42]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) SET AND Story Flag 18 (bit 128) CLEAR AND Target Inspected is obj[26] | Open Dialogue Sub-Window (9); Warp to Castle HQ (255, 254, 255) |
| `ev[43]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[26] | Open Dialogue Sub-Window (10); Warp to Castle HQ (255, 254, 255) |
| `ev[44]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[26] | Open Dialogue Sub-Window (11); Warp to Castle HQ (255, 254, 255) |
| `ev[45]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[26] | Open Dialogue Sub-Window (12); Warp to Castle HQ (255, 254, 255) |
| `ev[46]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) CLEAR AND Target Inspected is obj[27] | Open Dialogue Sub-Window (7); Exit to World Map (255, 254, 255) |
| `ev[47]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) SET AND Story Flag 18 (bit 128) CLEAR AND Target Inspected is obj[27] | Open Dialogue Sub-Window (9); Exit to World Map (255, 254, 255) |
| `ev[48]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[27] | Open Dialogue Sub-Window (10); Exit to World Map (255, 254, 255) |
| `ev[49]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[27] | Open Dialogue Sub-Window (11); Exit to World Map (255, 254, 255) |
| `ev[50]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[27] | Open Dialogue Sub-Window (12); Exit to World Map (255, 254, 255) |
| `ev[51]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) CLEAR AND Target Inspected is obj[28] | Open Dialogue Sub-Window (7); Engine Action #5 |
| `ev[52]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) SET AND Story Flag 18 (bit 128) CLEAR AND Target Inspected is obj[28] | Open Dialogue Sub-Window (9); Engine Action #5 |
| `ev[53]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[28] | Open Dialogue Sub-Window (10); Engine Action #5 |
| `ev[54]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[28] | Open Dialogue Sub-Window (11); Engine Action #5 |
| `ev[55]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[28] | Open Dialogue Sub-Window (12); Engine Action #5 |
| `ev[56]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) CLEAR AND Target Inspected is obj[29] | Open Dialogue Sub-Window (7); Execute Choice Result (255) |
| `ev[57]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) SET AND Story Flag 18 (bit 128) CLEAR AND Target Inspected is obj[29] | Open Dialogue Sub-Window (9); Execute Choice Result (255) |
| `ev[58]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[29] | Open Dialogue Sub-Window (10); Execute Choice Result (255) |
| `ev[59]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[29] | Open Dialogue Sub-Window (11); Execute Choice Result (255) |
| `ev[60]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[29] | Open Dialogue Sub-Window (12); Execute Choice Result (255) |
| `ev[61]` | `1 (Action / Talk)` | Target Inspected is obj[30] | Open Dialogue Sub-Window (8); Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[62]` | `1 (Action / Talk)` | Target Inspected is obj[31] | Open Dialogue Sub-Window (8); Warp Town -> Area 255 Map 254 Submap 255 at (254,204) |
| `ev[63]` | `1 (Action / Talk)` | Target Inspected is obj[32] | Open Dialogue Sub-Window (8); Warp to Castle HQ (255, 254, 255) |
| `ev[64]` | `1 (Action / Talk)` | Target Inspected is obj[33] | Open Dialogue Sub-Window (8); Exit to World Map (255, 254, 255) |
| `ev[65]` | `1 (Action / Talk)` | Target Inspected is obj[34] | Open Dialogue Sub-Window (8); Engine Action #5 |
| `ev[66]` | `1 (Action / Talk)` | Target Inspected is obj[35] | Open Dialogue Sub-Window (8); Engine Action #6 |
| `ev[67]` | `1 (Action / Talk)` | Target Inspected is obj[36] | Open Dialogue Sub-Window (8); Pan Camera (255, 254, 255) |
| `ev[68]` | `1 (Action / Talk)` | Target Inspected is obj[37] | Open Dialogue Sub-Window (8); Reset Camera Tracking (255) |
| `ev[69]` | `1 (Action / Talk)` | Target Inspected is obj[38] | Open Dialogue Sub-Window (8); Engine Action #9 |
| `ev[70]` | `1 (Action / Talk)` | Target Inspected is obj[39] | Open Dialogue Sub-Window (8); Screen Fade Transition (255, 254, 255) |
| `ev[71]` | `1 (Action / Talk)` | Target Inspected is obj[40] | Open Dialogue Sub-Window (8); Close Dialogue Window |
| `ev[72]` | `1 (Action / Talk)` | Target Inspected is obj[41] | Open Dialogue Sub-Window (8); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[73]` | `1 (Action / Talk)` | Target Inspected is obj[42] | Open Dialogue Sub-Window (8); Place Scenery Structure (255) |
| `ev[74]` | `1 (Action / Talk)` | Target Inspected is obj[43] | Open Dialogue Sub-Window (8); Animate Door Open |
| `ev[75]` | `1 (Action / Talk)` | Target Inspected is obj[44] | Open Dialogue Sub-Window (8); Show Dialogue Portrait (255, 254, 255) |

---

### Submap Layer `vi01_01` (Index 1)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `58` Objects | **Script Count (`evkaz`)**: `155` Scripts

#### Complete Physical Entity Inventory (58 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 69** | `69` | `(28, 58)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | Prop / Scenery | **Prop ID 53573** | `53573` | `(28, 58)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 180 |
| `obj[02]` | Prop / Scenery | **Prop ID 53573** | `53573` | `(28, 58)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 180 |
| `obj[03]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(27, 56)` | `2x2` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | NPC / Actor | **Actor ID 65193** | `65193` | `(44, 60)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[05]` | Trigger / Hitbox | **Hitbox Zone (11x2)** | `0` | `(39, 61)` | `10x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | NPC / Actor | **Actor ID 65192** | `65192` | `(38, 152)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Hitbox Zone (11x2)** | `0` | `(33, 153)` | `10x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | NPC / Actor | **Actor ID 65192** | `65192` | `(50, 152)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[09]` | Trigger / Hitbox | **Hitbox Zone (11x2)** | `0` | `(45, 153)` | `10x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | NPC / Actor | **Rare Items Dealer** | `65174` | `(186, 60)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[11]` | Trigger / Hitbox | **Hitbox Zone (11x2)** | `0` | `(181, 61)` | `10x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | NPC / Actor | **Actor ID 65177** | `65177` | `(42, 67)` | `0x0` | East (Right) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[13]` | NPC / Actor | **Actor ID 65085** | `65085` | `(45, 67)` | `0x0` | Up (North) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[14]` | NPC / Actor | **Actor ID 64932** | `64932` | `(30, 48)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[15]` | NPC / Actor | **Actor ID 64936** | `64936` | `(38, 48)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[16]` | NPC / Actor | **Actor ID 64937** | `64937` | `(38, 53)` | `0x0` | West (Left) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[17]` | NPC / Actor | **Actor ID 65055** | `65055` | `(26, 67)` | `4x4` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[18]` | NPC / Actor | **Actor ID 65088** | `65088` | `(55, 45)` | `5x3` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[19]` | NPC / Actor | **Actor ID 65218** | `65218` | `(138, 48)` | `4x4` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[20]` | NPC / Actor | **Actor ID 65057** | `65057` | `(123, 45)` | `2x4` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[21]` | NPC / Actor | **Actor ID 65177** | `65177` | `(134, 53)` | `1x0` | South (Down) | Dormant / Hidden (0) | Special (3) | 1 | 128 | 0 |
| `obj[22]` | NPC / Actor | **Actor ID 65226** | `65226` | `(46, 159)` | `8x5` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[23]` | NPC / Actor | **Actor ID 65085** | `65085` | `(34, 115)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[24]` | NPC / Actor | **Actor ID 65031** | `65031` | `(200, 41)` | `3x4` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[25]` | NPC / Actor | **Actor ID 64937** | `64937` | `(194, 43)` | `0x0` | West (Left) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[26]` | NPC / Actor | **Actor ID 65088** | `65088` | `(151, 189)` | `9x5` | West (Left) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[27]` | NPC / Actor | **Actor ID 64938** | `64938` | `(173, 184)` | `0x0` | Up (North) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[28]` | NPC / Actor | **Actor ID 65139** | `65139` | `(99, 201)` | `10x3` | West (Left) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[29]` | NPC / Actor | **Actor ID 64841** | `64841` | `(162, 114)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[30]` | NPC / Actor | **Actor ID 65057** | `65057` | `(181, 111)` | `6x4` | West (Left) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[31]` | NPC / Actor | **Actor ID 64936** | `64936` | `(112, 158)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[32]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(31, 113)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[33]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(35, 113)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[34]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(107, 107)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[35]` | Trigger / Hitbox | **Hitbox Zone (3x1)** | `0` | `(111, 107)` | `2x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[36]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(113, 111)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[37]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(113, 109)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[38]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(97, 112)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[39]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(93, 113)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[40]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(91, 114)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[41]` | Trigger / Hitbox | **Hitbox Zone (1x4)** | `0` | `(89, 114)` | `0x3` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[42]` | Trigger / Hitbox | **Hitbox Zone (6x3)** | `0` | `(45, 42)` | `5x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[43]` | Trigger / Hitbox | **Hitbox Zone (4x1)** | `0` | `(69, 66)` | `3x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[44]` | Trigger / Hitbox | **Hitbox Zone (6x3)** | `0` | `(139, 42)` | `5x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[45]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(151, 185)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[46]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(175, 178)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[47]` | Trigger / Hitbox | **Hitbox Zone (6x3)** | `0` | `(99, 198)` | `5x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[48]` | Trigger / Hitbox | **Hitbox Zone (6x3)** | `0` | `(105, 198)` | `5x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[49]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(93, 217)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[50]` | Trigger / Hitbox | **Hitbox Zone (6x3)** | `0` | `(183, 106)` | `5x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[51]` | Trigger / Hitbox | **Hitbox Zone (6x3)** | `0` | `(103, 150)` | `5x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[52]` | Trigger / Hitbox | **Hitbox Zone (6x3)** | `0` | `(193, 54)` | `5x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[53]` | Trigger / Hitbox | **Hitbox Zone (6x3)** | `0` | `(199, 54)` | `5x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[54]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(173, 41)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[55]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(173, 39)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[56]` | Trigger / Hitbox | **Hitbox Zone (2x3)** | `0` | `(177, 36)` | `1x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[57]` | Trigger / Hitbox | **Hitbox Zone (6x3)** | `0` | `(195, 32)` | `5x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 69)**: Positioned at tile `(28, 58)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Prop: Object 53573)**: Environmental world dressing prop placed at tile `(28, 58)`. Solid collision is set to `2`.
- **`obj[02]` (Prop: Object 53573)**: Environmental world dressing prop placed at tile `(28, 58)`. Solid collision is set to `2`.
- **`obj[03]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(27, 56)` to `(29, 58)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[04]` (Object 65193)**: Positioned at tile `(44, 60)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Hitbox Zone)**: Bounding trigger area covering `11` tiles wide by `2` tiles high from `(39, 61)` to `(49, 62)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[06]` (Object 65192)**: Positioned at tile `(38, 152)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[07]` (Hitbox Zone)**: Bounding trigger area covering `11` tiles wide by `2` tiles high from `(33, 153)` to `(43, 154)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[08]` (Object 65192)**: Positioned at tile `(50, 152)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[09]` (Hitbox Zone)**: Bounding trigger area covering `11` tiles wide by `2` tiles high from `(45, 153)` to `(55, 154)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[10]` (Rare Items Dealer)**: Positioned at tile `(186, 60)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[11]` (Hitbox Zone)**: Bounding trigger area covering `11` tiles wide by `2` tiles high from `(181, 61)` to `(191, 62)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[12]` (Object 65177)**: Positioned at tile `(42, 67)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[13]` (Object 65085)**: Positioned at tile `(45, 67)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[14]` (Object 64932)**: Positioned at tile `(30, 48)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[15]` (Object 64936)**: Positioned at tile `(38, 48)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[16]` (Object 64937)**: Positioned at tile `(38, 53)`, facing West (Left). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[17]` (Object 65055)**: Positioned at tile `(26, 67)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[18]` (Object 65088)**: Positioned at tile `(55, 45)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[19]` (Object 65218)**: Positioned at tile `(138, 48)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[20]` (Object 65057)**: Positioned at tile `(123, 45)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[21]` (Object 65177)**: Positioned at tile `(134, 53)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[22]` (Object 65226)**: Positioned at tile `(46, 159)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[23]` (Object 65085)**: Positioned at tile `(34, 115)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[24]` (Object 65031)**: Positioned at tile `(200, 41)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[25]` (Object 64937)**: Positioned at tile `(194, 43)`, facing West (Left). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[26]` (Object 65088)**: Positioned at tile `(151, 189)`, facing West (Left). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[27]` (Object 64938)**: Positioned at tile `(173, 184)`, facing Up (North). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[28]` (Object 65139)**: Positioned at tile `(99, 201)`, facing West (Left). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[29]` (Object 64841)**: Positioned at tile `(162, 114)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[30]` (Object 65057)**: Positioned at tile `(181, 111)`, facing West (Left). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[31]` (Object 64936)**: Positioned at tile `(112, 158)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[32]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(31, 113)` to `(34, 114)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[33]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(35, 113)`. Evaluates player step-on or Confirm button inputs.
- **`obj[34]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(107, 107)` to `(110, 108)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[35]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `1` tiles high from `(111, 107)` to `(113, 107)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[36]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(113, 111)` to `(115, 112)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[37]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(113, 109)` to `(115, 110)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[38]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(97, 112)` to `(98, 112)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[39]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(93, 113)` to `(95, 114)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[40]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(91, 114)` to `(92, 114)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[41]` (Hitbox Zone)**: Bounding trigger area covering `1` tiles wide by `4` tiles high from `(89, 114)` to `(89, 117)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[42]` (Hitbox Zone)**: Bounding trigger area covering `6` tiles wide by `3` tiles high from `(45, 42)` to `(50, 44)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[43]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `1` tiles high from `(69, 66)` to `(72, 66)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[44]` (Hitbox Zone)**: Bounding trigger area covering `6` tiles wide by `3` tiles high from `(139, 42)` to `(144, 44)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[45]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(151, 185)` to `(153, 186)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[46]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(175, 178)` to `(176, 178)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[47]` (Hitbox Zone)**: Bounding trigger area covering `6` tiles wide by `3` tiles high from `(99, 198)` to `(104, 200)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[48]` (Hitbox Zone)**: Bounding trigger area covering `6` tiles wide by `3` tiles high from `(105, 198)` to `(110, 200)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[49]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(93, 217)` to `(95, 218)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[50]` (Hitbox Zone)**: Bounding trigger area covering `6` tiles wide by `3` tiles high from `(183, 106)` to `(188, 108)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[51]` (Hitbox Zone)**: Bounding trigger area covering `6` tiles wide by `3` tiles high from `(103, 150)` to `(108, 152)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[52]` (Hitbox Zone)**: Bounding trigger area covering `6` tiles wide by `3` tiles high from `(193, 54)` to `(198, 56)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[53]` (Hitbox Zone)**: Bounding trigger area covering `6` tiles wide by `3` tiles high from `(199, 54)` to `(204, 56)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[54]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(173, 41)` to `(175, 42)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[55]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(173, 39)` to `(175, 40)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[56]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `3` tiles high from `(177, 36)` to `(178, 38)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[57]` (Hitbox Zone)**: Bounding trigger area covering `6` tiles wide by `3` tiles high from `(195, 32)` to `(200, 34)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (155 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Condition Check #33 AND Player Y within Range [2..16] AND Always Passes (Unconditional) AND Condition Check #68 AND Story Flag 31 (bit 2) CLEAR AND Story Flag 214 (bit 64) CLEAR | Make obj[0] Hidden (disp = 0); Engine Action #9; Open Dialogue Message Window; Close Dialogue Window; Teleport obj[255] to (254,255) |
| `ev[01]` | `2 (Map Init)` | Condition Check #33 AND Player within Box [3..4, 31..2] AND Story Flag 214 (bit 64) CLEAR | Make obj[0] Hidden (disp = 0); Engine Action #9; Open Dialogue Message Window; Close Dialogue Window; Teleport obj[255] to (254,255) |
| `ev[02]` | `2 (Map Init)` | Story Flag 31 (bit 2) SET AND Story Flag 31 (bit 4) CLEAR AND Story Flag 214 (bit 64) CLEAR | Make obj[1] Hidden (disp = 0); Display Dialogue Box [Bank: 1, MsgID: 13]; Teleport obj[255] to (254,255) |
| `ev[03]` | `2 (Map Init)` | Story Flag 20 (bit 128) SET | Make obj[1] Hidden (disp = 0); Launch Tactical War Battle (1); Toggle Random Encounters (47) |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [36..44, 2..167] AND Condition Check #168 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 18]; Engine Action #104 |
| `ev[05]` | `1 (Action / Talk)` | Player within Box [32..40, 2..75] AND Condition Check #76 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 64]; Engine Action #120 |
| `ev[06]` | `1 (Action / Talk)` | Player within Box [184..192, 2..73] AND Condition Check #74 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 70]; Engine Action #54 |
| `ev[07]` | `1 (Action / Talk)` | Player within Box [150..158, 2..133] AND Condition Check #134 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 4]; Play CD / Ambient BGM Track (255) |
| `ev[08]` | `1 (Action / Talk)` | Player within Box [34..35, 2..108] AND Condition Check #113 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 104]; Engine Action #110 |
| `ev[09]` | `1 (Action / Talk)` | Player within Box [96..97, 2..99] AND Condition Check #109 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 30]; Engine Action #110 |
| `ev[10]` | `1 (Action / Talk)` | Player within Box [47..49, 2..146] AND Condition Check #147 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 106]; Engine Action #116 |
| `ev[11]` | `1 (Action / Talk)` | Player within Box [105..107, 2..119] AND Condition Check #120 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 48]; Engine Action #149 |
| `ev[12]` | `1 (Action / Talk)` | Player within Box [67..68, 2..59] AND Condition Check #63 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 138]; Engine Action #66 |
| `ev[13]` | `1 (Action / Talk)` | Player within Box [134..135, 2..63] AND Condition Check #68 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 62]; Play Sound Effect (SE) (255) |
| `ev[14]` | `1 (Action / Talk)` | Player within Box [141..142, 2..177] AND Condition Check #182 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 65]; Set Special Scene BGM (255) |
| `ev[15]` | `1 (Action / Talk)` | Player within Box [177..181, 2..198] AND Condition Check #199 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 115]; Engine Action #212 |
| `ev[16]` | `1 (Action / Talk)` | Player within Box [113..117, 2..207] AND Condition Check #208 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 179]; Engine Action #188 |
| `ev[17]` | `1 (Action / Talk)` | Player within Box [143..149, 2..109] AND Condition Check #110 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 87]; Engine Action #160 |
| `ev[18]` | `1 (Action / Talk)` | Player within Box [85..89, 2..168] AND Condition Check #169 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 146]; Engine Action #119 |
| `ev[19]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Clear Story Milestone Flag 15 (mask 12); Show Dialogue Portrait (2, 5, 0); Warp Town -> Area 10 Map 0 Submap 3 at (12,0) |
| `ev[20]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Clear Story Milestone Flag 15 (mask 12); Show Dialogue Portrait (2, 5, 0); Warp Town -> Area 10 Map 0 Submap 255 at (254,255) |
| `ev[21]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Engine Action #118; Animate Door Open; Show Dialogue Portrait (0, 14, 13); Warp to Castle HQ (14, 0, 255) |
| `ev[22]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[15] | Clear Story Milestone Flag 7 (mask 14); Show Dialogue Portrait (0, 5, 1); Warp to Castle HQ (0, 11, 16) |
| `ev[23]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Target Inspected is obj[15] | Clear Story Milestone Flag 7 (mask 14); Show Dialogue Portrait (0, 5, 1); Warp to Castle HQ (0, 12, 25) |
| `ev[24]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Engine Action #118; Dismiss Dialogue Portrait; Show Dialogue Portrait (1, 14, 13); Warp to Castle HQ (16, 0, 255) |
| `ev[25]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[17] | Clear Story Milestone Flag 7 (mask 16); Show Dialogue Portrait (1, 5, 3); Warp to Castle HQ (1, 13, 6) |
| `ev[26]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Target Inspected is obj[17] | Clear Story Milestone Flag 7 (mask 16); Show Dialogue Portrait (1, 5, 3); Warp to Castle HQ (1, 14, 9) |
| `ev[27]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[19] | Clear Story Milestone Flag 13 (mask 18); Show Dialogue Portrait (5, 5, 2); Warp Town -> Area 15 Map 5 Submap 255 at (254,255) |
| `ev[28]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Target Inspected is obj[19] | Clear Story Milestone Flag 13 (mask 18); Show Dialogue Portrait (5, 5, 2); Warp Town -> Area 16 Map 8 Submap 255 at (254,255) |
| `ev[29]` | `1 (Action / Talk)` | Star of Destiny #0 Recruited AND Condition Check #68 AND Target Inspected is obj[11] AND Story Flag 0 (mask 255) SET | Recruit Character into Active Party (84 [Bonaparte], 69); Dismiss Emotion Bubble (89); Engine Action #9; Warp Town -> Area 1 Map 24 Submap 8 at (4,0); Engine Action #89; Engine Action #9; Warp Town -> Area 0 Map 58 Submap 255 at (254,255) |
| `ev[30]` | `1 (Action / Talk)` | Star of Destiny #0 Recruited AND Condition Check #68 AND Target Inspected is obj[11] AND Story Flag 3 (mask 255) SET | Recruit Character into Active Party (84 [Bonaparte], 69); Dismiss Emotion Bubble (89); Engine Action #9; Warp Town -> Area 1 Map 24 Submap 8 at (4,0); Engine Action #89; Engine Action #9; Warp Town -> Area 0 Map 58 Submap 255 at (254,255) |
| `ev[31]` | `1 (Action / Talk)` | Star of Destiny #0 Recruited AND Condition Check #68 AND Target Inspected is obj[11] AND Story Flag 2 (mask 255) SET | Recruit Character into Active Party (84 [Bonaparte], 69); Dismiss Emotion Bubble (89); Engine Action #9; Warp Town -> Area 2 Map 24 Submap 8 at (4,0); Engine Action #89; Engine Action #9; Warp Town -> Area 0 Map 58 Submap 255 at (254,255) |
| `ev[32]` | `1 (Action / Talk)` | Star of Destiny #1 Recruited AND Condition Check #68 AND Target Inspected is obj[11] | Recruit Character into Active Party (84 [Bonaparte], 69); Dismiss Emotion Bubble (43); Open Dialogue Message Window; Engine Action #5; Set Render Priority (pri) (0, 33); Engine Action #58; Reset Camera Tracking (3); Open Dialogue Message Window; Warp Town -> Area 33 Map 1 Submap 68 at (0,1); Engine Action #5; Warp Room -> Submap 5 at (2,2) facing 5; Show Dialogue Portrait (30, 24, 1); Exit to World Map (1, 36, 8); Set Combat Battle BGM (15); Engine Action #89; Engine Action #9; Warp Town -> Area 2 Map 24 Submap 8 at (4,2); Set Combat Battle BGM (15); Launch Tactical War Battle (16); Close Dialogue Sub-Window (1); Exit to World Map (3, 54, 0); Dismiss Dialogue Portrait; Set Combat Battle BGM (10); Close Dialogue Sub-Window (12); Place Scenery Structure (0); Engine Action #5; Display Dialogue Box [Bank: 4, MsgID: 6]; Open Dialogue Message Window; Branch on Choice (30, 1); Display Dialogue Box [Bank: 1, MsgID: 13]; Close Dialogue Sub-Window (1); Exit to World Map (5, 73, 60); Engine Action #39; Return Warp to Castle Base (5, 0); Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (9); Warp Room -> Submap 2 at (58,255) |
| `ev[33]` | `128 (Loop)` | Star of Destiny #1 Recruited AND Condition Check #68 AND Story Flag 31 (bit 2) CLEAR AND Inventory Holds Item #8 [Fire Wall] | Set Render Priority (pri) (12, 41); Engine Action #58; Engine Action #9; Toggle Random Encounters (8) |
| `ev[34]` | `128 (Loop)` | Star of Destiny #1 Recruited AND Condition Check #68 AND Story Flag 31 (bit 2) CLEAR AND Inventory Holds Item #16 [Revenge Earth] | Engine Action #89; Engine Action #9; Warp Town -> Area 4 Map 46 Submap 89 at (10,2); Engine Action #5; Open Dialogue Message Window; Screen Fade Transition (47, 89, 9); Engine Action #5; Engine Action #89; Engine Action #9; Engine Action #5; Make obj[1] Hidden (disp = 0); Engine Action #9; Warp Room -> Submap 0 at (8,47) facing 49; Warp to Castle HQ (5, 8, 4); Engine Action #5; Warp Town -> Area 2 Map 1 Submap 2 at (3,9); Open Dialogue Message Window; Warp Town -> Area 5 Map 15 Submap 3 at (0,5); Dismiss Emotion Bubble (4); Engine Action #6; Open Dialogue Message Window; Execute Choice Result (30); Engine Action #5; Warp Room -> Submap 40 at (1,0) facing 5; Show Dialogue Portrait (3, 0, 5); Trigger Character Emotion Effect (0, 0); Dismiss Emotion Bubble (255); Engine Action #5; Display Dialogue Box [Bank: 5, MsgID: 110]; Engine Action #6; Warp Town -> Area 4 Map 5 Submap 2 at (5,0); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Walk obj[1] to (8,37); Dismiss Dialogue Portrait |
| `ev[35]` | `1 (Action / Talk)` | Story Flag 94 (bit 8) SET AND Story Flag 59 (bit 1) CLEAR AND Story Flag 89 (bit 128) CLEAR AND Star of Destiny #1 Recruited AND Inventory Holds Item #1 [Medicine] AND Condition Check #35 AND Condition Check #35 AND Player Y within Range [77..77] AND Story Flag 1 (mask 255) SET | Recruit Character into Active Party (33 [Camus], 1); Engine Action #6; Make obj[0] Hidden (disp = 0); Branch on Choice (0, 21); Open Dialogue Message Window; Warp Room -> Submap 5 at (1,4) facing 7; Warp to Castle HQ (3, 1, 1); Dismiss Emotion Bubble (36); Warp Room -> Submap 2 at (5,0) facing 4; Exit to World Map (1, 7, 30); Engine Action #5; Warp Room -> Submap 4 at (1,9) facing East (Right); Warp Room -> Submap 15 at (30,255) facing 254; Walk obj[54] to (0,1); Launch Tactical War Battle (2); Dismiss Emotion Bubble (1); Warp Town -> Area 14 Map 0 Submap 41 at (2,0); Warp Room -> Submap 0 at (24,1) facing 6; Open Dialogue Message Window; Set Combat Battle BGM (15); Close Dialogue Sub-Window (20); Engine Action #6; Warp Room -> Submap 15 at (24,1) facing 6; Warp Town -> Area 73 Map 15 Submap 24 at (21,6); Warp to Castle HQ (73, 15, 24); Branch on Choice (6, 4); Set Combat Battle BGM (15); Close Dialogue Sub-Window (21); Engine Action #6; Engine Action #5; Set Combat Battle BGM (15); Close Dialogue Sub-Window (1); Engine Action #6; Engine Action #6; Set Combat Battle BGM (15); Close Dialogue Sub-Window (20); Engine Action #6; Pan Camera (73, 15, 24); Execute Choice Result (6); Reset Camera Tracking (73); Show Dialogue Portrait (24, 1, 6); Engine Action #9; Engine Action #5; Branch on Choice (6, 2); Engine Action #5; Screen Fade Transition (30, 72, 1); Branch on Choice (9, 24); Branch on Choice (6, 10); Load Sound Bank into Memory (0, 20); Set Combat Battle BGM (15); Close Dialogue Sub-Window (21); Engine Action #6; Close Dialogue Window; Set Combat Battle BGM (15); Launch Tactical War Battle (4); Close Dialogue Sub-Window (1); Engine Action #6; Display Dialogue Box [Bank: 73, MsgID: 15]; Close Dialogue Window; Warp Town -> Area 2 Map 120 Submap 3 at (0,0); Wait for Audio / Window Sync (1); Engine Action #9; Set obj[1] Collision to Passable; Engine Action #89; Engine Action #128; Display Dialogue Box [Bank: 0, MsgID: 64]; Engine Action #120; Engine Action #58; Warp Room -> Submap 1 at (6,13) facing 73; Show Dialogue Portrait (24, 20, 6); Animate Door Open; Set Combat Battle BGM (15); Close Dialogue Sub-Window (1); Engine Action #6; Show Dialogue Portrait (73, 15, 24); Execute Choice Result (6); Dismiss Dialogue Portrait; Set Combat Battle BGM (15); Close Dialogue Sub-Window (20); Engine Action #6; Change Portrait Expression (73); Show Dialogue Portrait (24, 21, 6); Display Speaker Name Box (73); Show Dialogue Portrait (24, 1, 6); Display Choice Selection (73, 15); Close Dialogue Sub-Window (20); Engine Action #6; Branch on Choice (73, 15); Close Dialogue Sub-Window (21); Engine Action #6; Execute Choice Result (73); Show Dialogue Portrait (24, 1, 6); Set Story Flag (73, 15); Close Dialogue Sub-Window (20); Engine Action #6; Open Dialogue Sub-Window (73); Show Dialogue Portrait (24, 21, 6); Close Dialogue Sub-Window (73); Show Dialogue Portrait (24, 1, 6); Clear Dialogue Sub-Window; Engine Action #5; Warp Room -> Submap 4 at (5,10) facing South (Down); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp Town -> Area 3 Map 0 Submap 1 at (5,10); Dismiss Emotion Bubble (24); Warp Room -> Submap 26 at (73,15) facing 11; Warp Town -> Area 2 Map 120 Submap 3 at (0,0); Wait for Audio / Window Sync (1); Engine Action #9; Set obj[1] Collision to Passable; Engine Action #94; Dismiss Dialogue Portrait; Display Dialogue Box [Bank: 0, MsgID: 64]; Engine Action #120; Engine Action #58 |
| `ev[36]` | `128 (Loop)` | Story Flag 94 (bit 8) SET AND Story Flag 59 (bit 1) CLEAR AND Story Flag 89 (bit 128) CLEAR AND Inventory Holds Item #1 [Medicine] | Close Dialogue Window; Warp Room -> Submap 40 at (37,1) facing 255 |
| `ev[37]` | `128 (Loop)` | Story Flag 94 (bit 8) SET AND Story Flag 59 (bit 1) CLEAR AND Story Flag 89 (bit 128) CLEAR AND Inventory Holds Item #2 [Mega Medicine] | Load Sound Bank into Memory (1, 20); Open Dialogue Message Window; Set Combat Battle BGM (8); Load Sound Bank into Memory (0, 20); Engine Action #5; Branch on Choice (0, 0); Engine Action #5; Engine Action #5; Warp Town -> Area 0 Map 30 Submap 37 at (2,255) |
| `ev[38]` | `128 (Loop)` | Story Flag 94 (bit 8) SET AND Story Flag 59 (bit 1) CLEAR AND Story Flag 89 (bit 128) CLEAR AND Inventory Holds Item #4 [Throat Drops] | Engine Action #5; Warp Room -> Submap 15 at (0,0) facing 30; Toggle Random Encounters (4) |
| `ev[39]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) CLEAR AND Player within Box [30..32, 2..106] AND Condition Check #112 AND Story Flag 3 (mask 255) SET | Recruit Character into Active Party (5 [Sheena], 31); Warp Town -> Area 0 Map 5 Submap 5 at (1,0); Engine Action #5; Screen Fade Transition (30, 24, 31); Animate Door Open; Display Dialogue Box [Bank: 49, MsgID: 2]; Engine Action #5; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (0, 0, 5); Engine Action #5; Exit to World Map (4, 2, 3); Dismiss Emotion Bubble (255); Engine Action #5; Warp Room -> Submap 3 at (0,5); Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (255); Walk obj[58] to (255,254) |
| `ev[40]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) CLEAR AND Target Inspected is obj[22] | Open Dialogue Sub-Window (7); Engine Action #6; Warp to Castle HQ (22, 0, 255) |
| `ev[41]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) SET AND Story Flag 18 (bit 128) CLEAR AND Target Inspected is obj[22] | Open Dialogue Sub-Window (9); Engine Action #6; Warp to Castle HQ (22, 0, 255) |
| `ev[42]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[22] | Open Dialogue Sub-Window (10); Engine Action #6; Warp to Castle HQ (22, 0, 255) |
| `ev[43]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[22] | Open Dialogue Sub-Window (11); Engine Action #6; Warp to Castle HQ (22, 0, 255) |
| `ev[44]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[22] | Open Dialogue Sub-Window (12); Engine Action #6; Warp to Castle HQ (22, 0, 255) |
| `ev[45]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) CLEAR AND Target Inspected is obj[23] | Open Dialogue Sub-Window (7); Pan Camera (3, 23, 0) |
| `ev[46]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) SET AND Story Flag 18 (bit 128) CLEAR AND Target Inspected is obj[23] | Open Dialogue Sub-Window (9); Pan Camera (3, 23, 0) |
| `ev[47]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[23] | Open Dialogue Sub-Window (10); Pan Camera (3, 23, 0) |
| `ev[48]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[23] | Open Dialogue Sub-Window (11); Pan Camera (3, 23, 0) |
| `ev[49]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[23] | Open Dialogue Sub-Window (12); Pan Camera (3, 23, 0) |
| `ev[50]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) CLEAR AND Target Inspected is obj[24] | Open Dialogue Sub-Window (7); Reset Camera Tracking (3); Close Dialogue Sub-Window (1) |
| `ev[51]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) SET AND Story Flag 18 (bit 128) CLEAR AND Target Inspected is obj[24] | Open Dialogue Sub-Window (9); Reset Camera Tracking (3); Close Dialogue Sub-Window (1) |
| `ev[52]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[24] | Open Dialogue Sub-Window (10); Reset Camera Tracking (3); Close Dialogue Sub-Window (1) |
| `ev[53]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[24] | Open Dialogue Sub-Window (11); Reset Camera Tracking (3); Close Dialogue Sub-Window (1) |
| `ev[54]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[24] | Open Dialogue Sub-Window (12); Reset Camera Tracking (3); Close Dialogue Sub-Window (1) |
| `ev[55]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) CLEAR AND Target Inspected is obj[25] | Open Dialogue Sub-Window (7); Engine Action #9 |
| `ev[56]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) SET AND Story Flag 18 (bit 128) CLEAR AND Target Inspected is obj[25] | Open Dialogue Sub-Window (9); Engine Action #9 |
| `ev[57]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[25] | Open Dialogue Sub-Window (10); Engine Action #9 |
| `ev[58]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[25] | Open Dialogue Sub-Window (11); Engine Action #9 |
| `ev[59]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[25] | Open Dialogue Sub-Window (12); Engine Action #9 |
| `ev[60]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) CLEAR AND Target Inspected is obj[26] | Open Dialogue Sub-Window (7); Screen Fade Transition (255, 254, 255) |
| `ev[61]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) SET AND Story Flag 18 (bit 128) CLEAR AND Target Inspected is obj[26] | Open Dialogue Sub-Window (9); Screen Fade Transition (255, 254, 255) |
| `ev[62]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[26] | Open Dialogue Sub-Window (10); Screen Fade Transition (255, 254, 255) |
| `ev[63]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[26] | Open Dialogue Sub-Window (11); Screen Fade Transition (255, 254, 255) |
| `ev[64]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[26] | Open Dialogue Sub-Window (12); Screen Fade Transition (255, 254, 255) |
| `ev[65]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) CLEAR AND Target Inspected is obj[27] | Open Dialogue Sub-Window (7); Close Dialogue Window |
| `ev[66]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) SET AND Story Flag 18 (bit 128) CLEAR AND Target Inspected is obj[27] | Open Dialogue Sub-Window (9); Close Dialogue Window |
| `ev[67]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[27] | Open Dialogue Sub-Window (10); Close Dialogue Window |
| `ev[68]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[27] | Open Dialogue Sub-Window (11); Close Dialogue Window |
| `ev[69]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[27] | Open Dialogue Sub-Window (12); Close Dialogue Window |
| `ev[70]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) CLEAR AND Target Inspected is obj[28] | Open Dialogue Sub-Window (7); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[71]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) SET AND Story Flag 18 (bit 128) CLEAR AND Target Inspected is obj[28] | Open Dialogue Sub-Window (9); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[72]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[28] | Open Dialogue Sub-Window (10); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[73]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[28] | Open Dialogue Sub-Window (11); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[74]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[28] | Open Dialogue Sub-Window (12); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[75]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[29] | Open Dialogue Sub-Window (10); Place Scenery Structure (255) |
| `ev[76]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[29] | Open Dialogue Sub-Window (11); Place Scenery Structure (255) |
| `ev[77]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[29] | Open Dialogue Sub-Window (12); Place Scenery Structure (255) |
| `ev[78]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) CLEAR AND Target Inspected is obj[30] | Open Dialogue Sub-Window (7); Animate Door Open |
| `ev[79]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) SET AND Story Flag 18 (bit 128) CLEAR AND Target Inspected is obj[30] | Open Dialogue Sub-Window (9); Animate Door Open |
| `ev[80]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[30] | Open Dialogue Sub-Window (10); Animate Door Open |
| `ev[81]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[30] | Open Dialogue Sub-Window (11); Animate Door Open |
| `ev[82]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[30] | Open Dialogue Sub-Window (12); Animate Door Open |
| `ev[83]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) CLEAR AND Target Inspected is obj[31] | Open Dialogue Sub-Window (7); Show Dialogue Portrait (5, 31, 5); Screen Fade Transition (0, 0, 30) |
| `ev[84]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) SET AND Story Flag 18 (bit 128) CLEAR AND Target Inspected is obj[31] | Open Dialogue Sub-Window (9); Show Dialogue Portrait (5, 31, 5); Screen Fade Transition (0, 0, 30) |
| `ev[85]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[31] | Open Dialogue Sub-Window (10); Show Dialogue Portrait (5, 31, 5); Screen Fade Transition (0, 0, 30) |
| `ev[86]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[31] | Open Dialogue Sub-Window (11); Show Dialogue Portrait (5, 31, 5); Screen Fade Transition (0, 0, 30) |
| `ev[87]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[31] | Open Dialogue Sub-Window (12); Show Dialogue Portrait (5, 31, 5); Screen Fade Transition (0, 0, 30) |
| `ev[88]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) CLEAR AND Target Inspected is obj[32] | Open Dialogue Sub-Window (7); Dismiss Dialogue Portrait |
| `ev[89]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) SET AND Story Flag 18 (bit 128) CLEAR AND Target Inspected is obj[32] | Open Dialogue Sub-Window (9); Dismiss Dialogue Portrait |
| `ev[90]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[32] | Open Dialogue Sub-Window (10); Dismiss Dialogue Portrait |
| `ev[91]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[32] | Open Dialogue Sub-Window (11); Dismiss Dialogue Portrait |
| `ev[92]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[32] | Open Dialogue Sub-Window (12); Dismiss Dialogue Portrait |
| `ev[93]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) CLEAR AND Target Inspected is obj[33] | Open Dialogue Sub-Window (7); Change Portrait Expression (3); Return to Previous Memory Map (1) |
| `ev[94]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) SET AND Story Flag 18 (bit 128) CLEAR AND Target Inspected is obj[33] | Open Dialogue Sub-Window (9); Change Portrait Expression (3); Return to Previous Memory Map (1) |
| `ev[95]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[33] | Open Dialogue Sub-Window (10); Change Portrait Expression (3); Return to Previous Memory Map (1) |
| `ev[96]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[33] | Open Dialogue Sub-Window (11); Change Portrait Expression (3); Return to Previous Memory Map (1) |
| `ev[97]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[33] | Open Dialogue Sub-Window (12); Change Portrait Expression (3); Return to Previous Memory Map (1) |
| `ev[98]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) CLEAR AND Target Inspected is obj[34] | Open Dialogue Sub-Window (7); Display Speaker Name Box (255) |
| `ev[99]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) SET AND Story Flag 18 (bit 128) CLEAR AND Target Inspected is obj[34] | Open Dialogue Sub-Window (9); Display Speaker Name Box (255) |
| `ev[100]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[34] | Open Dialogue Sub-Window (10); Display Speaker Name Box (255) |
| `ev[101]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[34] | Open Dialogue Sub-Window (11); Display Speaker Name Box (255) |
| `ev[102]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[34] | Open Dialogue Sub-Window (12); Display Speaker Name Box (255) |
| `ev[103]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) CLEAR AND Target Inspected is obj[35] | Open Dialogue Sub-Window (7); Display Choice Selection (3, 35); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[104]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) SET AND Story Flag 18 (bit 128) CLEAR AND Target Inspected is obj[35] | Open Dialogue Sub-Window (9); Display Choice Selection (3, 35); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[105]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[35] | Open Dialogue Sub-Window (10); Display Choice Selection (3, 35); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[106]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[35] | Open Dialogue Sub-Window (11); Display Choice Selection (3, 35); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[107]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[35] | Open Dialogue Sub-Window (12); Display Choice Selection (3, 35); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[108]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) CLEAR AND Target Inspected is obj[36] | Open Dialogue Sub-Window (7); Branch on Choice (255, 254) |
| `ev[109]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) SET AND Story Flag 18 (bit 128) CLEAR AND Target Inspected is obj[36] | Open Dialogue Sub-Window (9); Branch on Choice (255, 254) |
| `ev[110]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[36] | Open Dialogue Sub-Window (10); Branch on Choice (255, 254) |
| `ev[111]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[36] | Open Dialogue Sub-Window (11); Branch on Choice (255, 254) |
| `ev[112]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[36] | Open Dialogue Sub-Window (12); Branch on Choice (255, 254) |
| `ev[113]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) CLEAR AND Target Inspected is obj[37] | Open Dialogue Sub-Window (7); Set Story Flag (3, 37); Open Dialogue Message Window |
| `ev[114]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) SET AND Story Flag 18 (bit 128) CLEAR AND Target Inspected is obj[37] | Open Dialogue Sub-Window (9); Set Story Flag (3, 37); Open Dialogue Message Window |
| `ev[115]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[37] | Open Dialogue Sub-Window (10); Set Story Flag (3, 37); Open Dialogue Message Window |
| `ev[116]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[37] | Open Dialogue Sub-Window (11); Set Story Flag (3, 37); Open Dialogue Message Window |
| `ev[117]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[37] | Open Dialogue Sub-Window (12); Set Story Flag (3, 37); Open Dialogue Message Window |
| `ev[118]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) CLEAR AND Target Inspected is obj[38] | Open Dialogue Sub-Window (7); Open Dialogue Sub-Window (255) |
| `ev[119]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) SET AND Story Flag 18 (bit 128) CLEAR AND Target Inspected is obj[38] | Open Dialogue Sub-Window (9); Open Dialogue Sub-Window (255) |
| `ev[120]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[38] | Open Dialogue Sub-Window (10); Open Dialogue Sub-Window (255) |
| `ev[121]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[38] | Open Dialogue Sub-Window (11); Open Dialogue Sub-Window (255) |
| `ev[122]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[38] | Open Dialogue Sub-Window (12); Open Dialogue Sub-Window (255) |
| `ev[123]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) CLEAR AND Target Inspected is obj[39] | Open Dialogue Sub-Window (7); Close Dialogue Sub-Window (3); Engine Action #39; Open Dialogue Message Window |
| `ev[124]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) SET AND Story Flag 18 (bit 128) CLEAR AND Target Inspected is obj[39] | Open Dialogue Sub-Window (9); Close Dialogue Sub-Window (3); Engine Action #39; Open Dialogue Message Window |
| `ev[125]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[39] | Open Dialogue Sub-Window (10); Close Dialogue Sub-Window (3); Engine Action #39; Open Dialogue Message Window |
| `ev[126]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[39] | Open Dialogue Sub-Window (11); Close Dialogue Sub-Window (3); Engine Action #39; Open Dialogue Message Window |
| `ev[127]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[39] | Open Dialogue Sub-Window (12); Close Dialogue Sub-Window (3); Engine Action #39; Open Dialogue Message Window |
| `ev[128]` | `1 (Action / Talk)` | Target Inspected is obj[40] | Open Dialogue Sub-Window (8); Engine Action #51 |
| `ev[129]` | `1 (Action / Talk)` | Target Inspected is obj[41] | Open Dialogue Sub-Window (8); Engine Action #52 |
| `ev[130]` | `1 (Action / Talk)` | Target Inspected is obj[42] | Open Dialogue Sub-Window (8); Engine Action #53 |
| `ev[131]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 36 (bit 16) CLEAR AND Target Inspected is obj[43] | Jump to Bytecode Offset (4, 6); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (2); Exit to World Map (0, 11, 80); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (9,36) facing 16; Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[132]` | `1 (Action / Talk)` | Target Inspected is obj[43] | Open Dialogue Sub-Window (8); Engine Action #54 |
| `ev[133]` | `1 (Action / Talk)` | Target Inspected is obj[44] | Open Dialogue Sub-Window (8); Set Render Priority (pri) (255, 254) |
| `ev[134]` | `1 (Action / Talk)` | Target Inspected is obj[45] | Open Dialogue Sub-Window (8); Set Animation Pose (255, 254) |
| `ev[135]` | `1 (Action / Talk)` | Target Inspected is obj[46] | Open Dialogue Sub-Window (8); Recruit Character into Active Party (255, 254) |
| `ev[136]` | `1 (Action / Talk)` | Target Inspected is obj[47] | Open Dialogue Sub-Window (8); Engine Action #58 |
| `ev[137]` | `1 (Action / Talk)` | Target Inspected is obj[48] | Open Dialogue Sub-Window (8); Set obj[255] Collision to Passable |
| `ev[138]` | `1 (Action / Talk)` | Target Inspected is obj[49] | Open Dialogue Sub-Window (8); Trigger Character Emotion Effect (255, 254) |
| `ev[139]` | `1 (Action / Talk)` | Target Inspected is obj[50] | Open Dialogue Sub-Window (8); Engine Action #61 |
| `ev[140]` | `1 (Action / Talk)` | Target Inspected is obj[51] | Open Dialogue Sub-Window (8); Engine Action #62 |
| `ev[141]` | `1 (Action / Talk)` | Target Inspected is obj[52] | Open Dialogue Sub-Window (8); Engine Action #63 |
| `ev[142]` | `1 (Action / Talk)` | Target Inspected is obj[53] | Open Dialogue Sub-Window (8); Animate Doorway State (255, 254) |
| `ev[143]` | `1 (Action / Talk)` | Target Inspected is obj[54] | Open Dialogue Sub-Window (8); Play Sound Effect (SE) (255) |
| `ev[144]` | `1 (Action / Talk)` | Target Inspected is obj[55] | Open Dialogue Sub-Window (8); Engine Action #66 |
| `ev[145]` | `1 (Action / Talk)` | Target Inspected is obj[56] | Open Dialogue Sub-Window (8); Open Shop Interface #255 |
| `ev[146]` | `1 (Action / Talk)` | Target Inspected is obj[57] | Open Dialogue Sub-Window (8); Play CD / Ambient BGM Track (255) |
| `ev[147]` | `1 (Action / Talk)` | Target Inspected is obj[58] | Open Dialogue Sub-Window (8); Wait for Audio / Window Sync (255) |
| `ev[148]` | `1 (Action / Talk)` | Target Inspected is obj[59] | Open Dialogue Sub-Window (8); Recruit Hero #255 into Battle Slot 254 |
| `ev[149]` | `1 (Action / Talk)` | Target Inspected is obj[60] | Open Dialogue Sub-Window (8); Remove Character from Active Party (255) |
| `ev[150]` | `1 (Action / Talk)` | Target Inspected is obj[61] | Open Dialogue Sub-Window (8); Load Sound Bank into Memory (255, 254) |
| `ev[151]` | `1 (Action / Talk)` | Target Inspected is obj[62] | Open Dialogue Sub-Window (8); Set Combat Battle BGM (255) |
| `ev[152]` | `1 (Action / Talk)` | Target Inspected is obj[63] | Open Dialogue Sub-Window (8); Set Special Scene BGM (255) |
| `ev[153]` | `1 (Action / Talk)` | Target Inspected is obj[64] | Open Dialogue Sub-Window (8); Full Rest & Healing (Restore HP/MP) |
| `ev[154]` | `1 (Action / Talk)` | Target Inspected is obj[65] | Open Dialogue Sub-Window (8); Full Rest & Healing (Restore HP/MP) |

---



## Location Map: `vi02`

- **Master Map Container**: `vi02.json`
- **Submap Layer Files**: Embedded in master
- **Collision Grid Files**: vi02_map_00.json, vi02_map_01.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 2

### Submap Layer `vi02_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `58` Objects | **Script Count (`evkaz`)**: `89` Scripts

#### Complete Physical Entity Inventory (58 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 65219** | `65219` | `(22, 56)` | `3x2` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[01]` | NPC / Actor | **Actor ID 65065** | `65065` | `(48, 52)` | `3x3` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[02]` | NPC / Actor | **Actor ID 65039** | `65039` | `(77, 59)` | `2x4` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[03]` | NPC / Actor | **Actor ID 65141** | `65141` | `(27, 24)` | `4x3` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[04]` | NPC / Actor | **Actor ID 65139** | `65139` | `(38, 28)` | `3x3` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[05]` | NPC / Actor | **Actor ID 65011** | `65011` | `(34, 14)` | `0x0` | East (Right) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[06]` | NPC / Actor | **Actor ID 65011** | `65011` | `(36, 14)` | `0x0` | Up (North) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[07]` | World Device | **Mechanism (ano 1)** | `0` | `(70, 56)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[08]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(3, 52)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(4, 49)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(6, 49)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(50, 47)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(54, 50)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(57, 53)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(77, 57)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[15]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(79, 59)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[16]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(9, 15)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[17]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(17, 15)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[18]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(42, 21)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[19]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[20]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[21]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[22]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[23]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[24]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[25]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[26]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[27]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[28]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[29]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[30]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[31]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[32]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[33]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[34]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[35]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[36]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[37]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[38]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[39]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[40]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[41]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[42]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[43]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[44]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[45]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[46]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[47]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[48]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[49]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[50]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[51]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[52]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[53]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[54]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[55]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[56]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[57]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 65219)**: Positioned at tile `(22, 56)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Object 65065)**: Positioned at tile `(48, 52)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Object 65039)**: Positioned at tile `(77, 59)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Object 65141)**: Positioned at tile `(27, 24)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Object 65139)**: Positioned at tile `(38, 28)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Object 65011)**: Positioned at tile `(34, 14)`, facing East (Right). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[06]` (Object 65011)**: Positioned at tile `(36, 14)`, facing Up (North). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[07]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(70, 56)` with state parameter `1`.
- **`obj[08]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(3, 52)` to `(5, 53)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[09]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(4, 49)` to `(5, 49)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[10]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(6, 49)` to `(7, 50)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[11]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(50, 47)` to `(52, 48)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[12]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(54, 50)` to `(55, 50)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[13]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(57, 53)` to `(58, 53)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[14]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(77, 57)` to `(78, 58)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[15]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(79, 59)` to `(80, 59)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[16]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(9, 15)` to `(11, 16)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[17]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(17, 15)` to `(19, 16)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[18]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(42, 21)` to `(44, 22)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[19]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[20]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[21]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[22]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[23]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[24]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[25]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[26]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[27]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[28]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[29]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[30]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[31]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[32]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[33]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[34]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[35]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[36]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[37]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[38]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[39]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[40]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[41]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[42]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[43]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[44]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[45]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[46]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[47]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[48]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[49]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[50]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[51]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[52]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[53]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[54]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[55]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[56]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[57]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.


#### Complete Bytecode Script Catalog (89 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 20 (bit 128) CLEAR | Open Dialogue Message Window; Show Dialogue Portrait (255, 254, 255) |
| `ev[01]` | `2 (Map Init)` | Story Flag 18 (bit 128) SET | Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [11..17, 2..8] AND Story Flag 9 (mask 1) SET | Warp Room -> Submap 0 at (8,3); Screen Fade Transition (151, 32, 74); Warp Room -> Submap 3 at (250,0) facing South (Down) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [10..18, 2..79] AND Condition Check #80 AND Story Flag 0 (mask 255) SET | Warp Room -> Submap 0 at (8,0); Screen Fade Transition (151, 32, 74); Warp Room -> Submap 3 at (0,14) facing 20 |
| `ev[04]` | `128 (Loop)` | Player within Box [17..24, 2..34] AND Condition Check #35 AND Story Flag 1 (mask 255) SET | Warp Room -> Submap 0 at (8,3) |
| `ev[05]` | `128 (Loop)` | Player within Box [17..24, 2..36] AND Condition Check #37 AND Story Flag 0 (mask 255) SET | Warp Room -> Submap 0 at (8,0) |
| `ev[06]` | `128 (Loop)` | Player within Box [12..12, 2..50] AND Condition Check #50 AND Story Flag 0 (mask 255) SET | Warp Room -> Submap 0 at (8,0) |
| `ev[07]` | `128 (Loop)` | Player within Box [72..72, 2..58] AND Condition Check #58 AND Story Flag 0 (mask 255) SET | Warp Room -> Submap 0 at (8,0) |
| `ev[08]` | `1 (Action / Talk)` | Player within Box [11..13, 2..47] AND Condition Check #48 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 31]; Remove Item from Inventory (255, 254) |
| `ev[09]` | `1 (Action / Talk)` | Player within Box [71..73, 2..55] AND Condition Check #56 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 102]; Load Sound Bank into Memory (255, 254) |
| `ev[10]` | `128 (Loop)` | Story Flag 20 (bit 128) CLEAR AND Player within Box [69..75, 2..57] AND Condition Check #59 | Engine Action #9; Engine Action #151; Warp Map Transition (255, 254, 255, 254, 204) |
| `ev[11]` | `128 (Loop)` | Story Flag 20 (bit 128) CLEAR AND Player within Box [67..68, 2..56] AND Condition Check #61 | Screen Fade Transition (151, 32, 255) |
| `ev[12]` | `128 (Loop)` | Story Flag 20 (bit 128) CLEAR AND Player within Box [76..77, 2..56] AND Condition Check #61 | Screen Fade Transition (151, 32, 255) |
| `ev[13]` | `128 (Loop)` | Story Flag 20 (bit 128) CLEAR AND Player within Box [67..77, 2..60] AND Condition Check #61 | Screen Fade Transition (151, 32, 255) |
| `ev[14]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) CLEAR AND Target Inspected is obj[8] | Open Dialogue Sub-Window (2); Warp Room -> Submap 255 at (254,255) |
| `ev[15]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) SET AND Story Flag 18 (bit 128) CLEAR AND Target Inspected is obj[8] | Open Dialogue Sub-Window (4); Warp Room -> Submap 255 at (254,255) |
| `ev[16]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[8] | Open Dialogue Sub-Window (5); Warp Room -> Submap 255 at (254,255) |
| `ev[17]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[8] | Open Dialogue Sub-Window (6); Warp Room -> Submap 255 at (254,255) |
| `ev[18]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[8] | Open Dialogue Sub-Window (7); Warp Room -> Submap 255 at (254,255) |
| `ev[19]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) CLEAR AND Target Inspected is obj[9] | Open Dialogue Sub-Window (2); Warp Map Transition (255, 254, 255, 254, 204) |
| `ev[20]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) SET AND Story Flag 18 (bit 128) CLEAR AND Target Inspected is obj[9] | Open Dialogue Sub-Window (4); Warp Map Transition (255, 254, 255, 254, 204) |
| `ev[21]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[9] | Open Dialogue Sub-Window (5); Warp Map Transition (255, 254, 255, 254, 204) |
| `ev[22]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[9] | Open Dialogue Sub-Window (6); Warp Map Transition (255, 254, 255, 254, 204) |
| `ev[23]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[9] | Open Dialogue Sub-Window (7); Warp Map Transition (255, 254, 255, 254, 204) |
| `ev[24]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) CLEAR AND Target Inspected is obj[10] | Open Dialogue Sub-Window (2); Return to Previous Memory Map (255) |
| `ev[25]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) SET AND Story Flag 18 (bit 128) CLEAR AND Target Inspected is obj[10] | Open Dialogue Sub-Window (4); Return to Previous Memory Map (255) |
| `ev[26]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[10] | Open Dialogue Sub-Window (5); Return to Previous Memory Map (255) |
| `ev[27]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[10] | Open Dialogue Sub-Window (6); Return to Previous Memory Map (255) |
| `ev[28]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[10] | Open Dialogue Sub-Window (7); Return to Previous Memory Map (255) |
| `ev[29]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) CLEAR AND Target Inspected is obj[11] | Open Dialogue Sub-Window (2); Return Warp to Castle Base (255, 254) |
| `ev[30]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) SET AND Story Flag 18 (bit 128) CLEAR AND Target Inspected is obj[11] | Open Dialogue Sub-Window (4); Return Warp to Castle Base (255, 254) |
| `ev[31]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[11] | Open Dialogue Sub-Window (5); Return Warp to Castle Base (255, 254) |
| `ev[32]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[11] | Open Dialogue Sub-Window (6); Return Warp to Castle Base (255, 254) |
| `ev[33]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[11] | Open Dialogue Sub-Window (7); Return Warp to Castle Base (255, 254) |
| `ev[34]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) CLEAR AND Target Inspected is obj[12] | Open Dialogue Sub-Window (2); Start Boss Battle #255 (BGM: 254) |
| `ev[35]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) SET AND Story Flag 18 (bit 128) CLEAR AND Target Inspected is obj[12] | Open Dialogue Sub-Window (4); Start Boss Battle #255 (BGM: 254) |
| `ev[36]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[12] | Open Dialogue Sub-Window (5); Start Boss Battle #255 (BGM: 254) |
| `ev[37]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[12] | Open Dialogue Sub-Window (6); Start Boss Battle #255 (BGM: 254) |
| `ev[38]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[12] | Open Dialogue Sub-Window (7); Start Boss Battle #255 (BGM: 254) |
| `ev[39]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Open Dialogue Sub-Window (3); Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[40]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Open Dialogue Sub-Window (3); Warp Town -> Area 255 Map 254 Submap 255 at (254,204) |
| `ev[41]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Open Dialogue Sub-Window (3); Warp to Castle HQ (255, 254, 255) |
| `ev[42]` | `1 (Action / Talk)` | Target Inspected is obj[19] | Open Dialogue Sub-Window (3); Exit to World Map (255, 254, 255) |
| `ev[43]` | `1 (Action / Talk)` | Target Inspected is obj[20] | Open Dialogue Sub-Window (3); Engine Action #5 |
| `ev[44]` | `1 (Action / Talk)` | Target Inspected is obj[21] | Open Dialogue Sub-Window (3); Engine Action #6 |
| `ev[45]` | `1 (Action / Talk)` | Target Inspected is obj[22] | Open Dialogue Sub-Window (3); Pan Camera (255, 254, 255) |
| `ev[46]` | `1 (Action / Talk)` | Target Inspected is obj[23] | Open Dialogue Sub-Window (3); Reset Camera Tracking (255) |
| `ev[47]` | `1 (Action / Talk)` | Target Inspected is obj[24] | Open Dialogue Sub-Window (3); Engine Action #9 |
| `ev[48]` | `1 (Action / Talk)` | Target Inspected is obj[25] | Open Dialogue Sub-Window (3); Screen Fade Transition (255, 254, 255) |
| `ev[49]` | `1 (Action / Talk)` | Target Inspected is obj[26] | Open Dialogue Sub-Window (3); Close Dialogue Window |
| `ev[50]` | `1 (Action / Talk)` | Target Inspected is obj[27] | Open Dialogue Sub-Window (3); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[51]` | `1 (Action / Talk)` | Target Inspected is obj[28] | Open Dialogue Sub-Window (3); Place Scenery Structure (255) |
| `ev[52]` | `1 (Action / Talk)` | Target Inspected is obj[29] | Open Dialogue Sub-Window (3); Animate Door Open |
| `ev[53]` | `1 (Action / Talk)` | Target Inspected is obj[30] | Open Dialogue Sub-Window (3); Show Dialogue Portrait (255, 254, 255) |
| `ev[54]` | `1 (Action / Talk)` | Target Inspected is obj[31] | Open Dialogue Sub-Window (3); Dismiss Dialogue Portrait |
| `ev[55]` | `1 (Action / Talk)` | Target Inspected is obj[32] | Open Dialogue Sub-Window (3); Change Portrait Expression (255) |
| `ev[56]` | `1 (Action / Talk)` | Target Inspected is obj[33] | Open Dialogue Sub-Window (3); Display Speaker Name Box (255) |
| `ev[57]` | `1 (Action / Talk)` | Target Inspected is obj[34] | Open Dialogue Sub-Window (3); Display Choice Selection (255, 254) |
| `ev[58]` | `1 (Action / Talk)` | Target Inspected is obj[35] | Open Dialogue Sub-Window (3); Branch on Choice (255, 254) |
| `ev[59]` | `1 (Action / Talk)` | Target Inspected is obj[36] | Open Dialogue Sub-Window (3); Execute Choice Result (255) |
| `ev[60]` | `1 (Action / Talk)` | Target Inspected is obj[37] | Open Dialogue Sub-Window (3); Set Story Flag (255, 254) |
| `ev[61]` | `1 (Action / Talk)` | Target Inspected is obj[38] | Open Dialogue Sub-Window (3); Open Dialogue Sub-Window (255) |
| `ev[62]` | `1 (Action / Talk)` | Target Inspected is obj[39] | Open Dialogue Sub-Window (3); Close Dialogue Sub-Window (255) |
| `ev[63]` | `1 (Action / Talk)` | Target Inspected is obj[40] | Open Dialogue Sub-Window (3); Clear Dialogue Sub-Window |
| `ev[64]` | `1 (Action / Talk)` | Target Inspected is obj[41] | Open Dialogue Sub-Window (3); Fade In from Black (255) |
| `ev[65]` | `1 (Action / Talk)` | Target Inspected is obj[42] | Open Dialogue Sub-Window (3); Fade Out to Black (255) |
| `ev[66]` | `1 (Action / Talk)` | Target Inspected is obj[43] | Open Dialogue Sub-Window (3); Display Chapter Text (255) |
| `ev[67]` | `1 (Action / Talk)` | Target Inspected is obj[44] | Open Dialogue Sub-Window (3); Display Emotion Bubble (255, 254) |
| `ev[68]` | `1 (Action / Talk)` | Target Inspected is obj[45] | Open Dialogue Sub-Window (3); Dismiss Emotion Bubble (255) |
| `ev[69]` | `1 (Action / Talk)` | Target Inspected is obj[46] | Open Dialogue Sub-Window (3); Warp Room -> Submap 255 at (254,255) |
| `ev[70]` | `1 (Action / Talk)` | Target Inspected is obj[47] | Open Dialogue Sub-Window (3); Warp Map Transition (255, 254, 255, 254, 204) |
| `ev[71]` | `1 (Action / Talk)` | Target Inspected is obj[48] | Open Dialogue Sub-Window (3); Return to Previous Memory Map (255) |
| `ev[72]` | `1 (Action / Talk)` | Target Inspected is obj[49] | Open Dialogue Sub-Window (3); Return Warp to Castle Base (255, 254) |
| `ev[73]` | `1 (Action / Talk)` | Target Inspected is obj[50] | Open Dialogue Sub-Window (3); Start Boss Battle #255 (BGM: 254) |
| `ev[74]` | `1 (Action / Talk)` | Target Inspected is obj[51] | Open Dialogue Sub-Window (3); Launch Tactical War Battle (255) |
| `ev[75]` | `1 (Action / Talk)` | Target Inspected is obj[52] | Open Dialogue Sub-Window (3); Toggle Random Encounters (255) |
| `ev[76]` | `1 (Action / Talk)` | Target Inspected is obj[53] | Open Dialogue Sub-Window (3); Open Save Crystal Menu (MSaveInit) |
| `ev[77]` | `1 (Action / Talk)` | Target Inspected is obj[54] | Open Dialogue Sub-Window (3); Engine Action #39 |
| `ev[78]` | `1 (Action / Talk)` | Target Inspected is obj[55] | Open Dialogue Sub-Window (3); Engine Action #40 |
| `ev[79]` | `1 (Action / Talk)` | Target Inspected is obj[56] | Open Dialogue Sub-Window (3); Award Potch Loot (+65,534 Potch) |
| `ev[80]` | `1 (Action / Talk)` | Target Inspected is obj[57] | Open Dialogue Sub-Window (3); Remove Item from Inventory (255, 254) |
| `ev[81]` | `1 (Action / Talk)` | Target Inspected is obj[58] | Open Dialogue Sub-Window (3); Open Shop Menu #254 (Type: 255) |
| `ev[82]` | `1 (Action / Talk)` | Target Inspected is obj[59] | Open Dialogue Sub-Window (3); Engine Action #44 |
| `ev[83]` | `1 (Action / Talk)` | Target Inspected is obj[60] | Open Dialogue Sub-Window (3); Make obj[255] Visible (disp = 1) |
| `ev[84]` | `1 (Action / Talk)` | Target Inspected is obj[61] | Open Dialogue Sub-Window (3); Make obj[255] Hidden (disp = 0) |
| `ev[85]` | `1 (Action / Talk)` | Target Inspected is obj[62] | Open Dialogue Sub-Window (3); Teleport obj[255] to (254,255) |
| `ev[86]` | `1 (Action / Talk)` | Target Inspected is obj[63] | Open Dialogue Sub-Window (3); Turn obj[255] facing 254 |
| `ev[87]` | `1 (Action / Talk)` | Target Inspected is obj[64] | Open Dialogue Sub-Window (3); Set Entity Movement Speed (255, 254) |
| `ev[88]` | `1 (Action / Talk)` | Target Inspected is obj[65] | Open Dialogue Sub-Window (3); Walk obj[255] to (254,255) |

---

### Submap Layer `vi02_01` (Index 1)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `63` Objects | **Script Count (`evkaz`)**: `108` Scripts

#### Complete Physical Entity Inventory (63 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 65088** | `65088` | `(30, 75)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Actor ID 65178** | `65178` | `(102, 63)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | Trigger / Hitbox | **Hitbox Zone (5x2)** | `0` | `(100, 63)` | `4x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | NPC / Actor | **Actor ID 65087** | `65087` | `(46, 76)` | `4x4` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[04]` | NPC / Actor | **Actor ID 64569** | `64569` | `(34, 42)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[05]` | NPC / Actor | **Actor ID 65086** | `65086` | `(36, 53)` | `6x3` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[06]` | NPC / Actor | **Actor ID 65068** | `65068` | `(25, 46)` | `2x3` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[07]` | NPC / Actor | **Actor ID 65043** | `65043` | `(120, 65)` | `3x5` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[08]` | NPC / Actor | **Actor ID 65073** | `65073` | `(116, 39)` | `5x2` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[09]` | NPC / Actor | **Actor ID 64928** | `64928` | `(104, 46)` | `0x0` | Up (North) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[10]` | NPC / Actor | **Actor ID 64932** | `64932` | `(100, 46)` | `0x0` | East (Right) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[11]` | NPC / Actor | **Actor ID 65226** | `65226` | `(81, 40)` | `6x2` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[12]` | NPC / Actor | **Actor ID 65176** | `65176` | `(81, 58)` | `2x4` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[13]` | Trigger / Hitbox | **Hitbox Zone (6x1)** | `0` | `(47, 40)` | `5x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(115, 67)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[15]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(109, 59)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[16]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(93, 61)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[17]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(95, 59)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[18]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(155, 47)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[19]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(155, 45)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[20]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(155, 43)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[21]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(159, 41)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[22]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(161, 39)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[23]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(175, 47)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[24]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(179, 49)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[25]` | Trigger / Hitbox | **Hitbox Zone (2x7)** | `0` | `(173, 37)` | `1x6` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[26]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[27]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[28]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[29]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[30]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[31]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[32]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[33]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[34]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[35]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[36]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[37]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[38]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[39]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[40]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[41]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[42]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[43]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[44]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[45]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[46]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[47]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[48]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[49]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[50]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[51]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[52]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[53]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[54]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[55]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[56]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[57]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[58]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[59]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[60]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[61]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[62]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 65088)**: Positioned at tile `(30, 75)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Object 65178)**: Positioned at tile `(102, 63)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `2` tiles high from `(100, 63)` to `(104, 64)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[03]` (Object 65087)**: Positioned at tile `(46, 76)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Object 64569)**: Positioned at tile `(34, 42)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Object 65086)**: Positioned at tile `(36, 53)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[06]` (Object 65068)**: Positioned at tile `(25, 46)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[07]` (Object 65043)**: Positioned at tile `(120, 65)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[08]` (Object 65073)**: Positioned at tile `(116, 39)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[09]` (Object 64928)**: Positioned at tile `(104, 46)`, facing Up (North). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[10]` (Object 64932)**: Positioned at tile `(100, 46)`, facing East (Right). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[11]` (Object 65226)**: Positioned at tile `(81, 40)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[12]` (Object 65176)**: Positioned at tile `(81, 58)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[13]` (Hitbox Zone)**: Bounding trigger area covering `6` tiles wide by `1` tiles high from `(47, 40)` to `(52, 40)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[14]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(115, 67)` to `(117, 68)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[15]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(109, 59)` to `(111, 60)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[16]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(93, 61)` to `(94, 62)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[17]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(95, 59)` to `(96, 60)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[18]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(155, 47)` to `(157, 48)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[19]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(155, 45)` to `(157, 46)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[20]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(155, 43)` to `(157, 44)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[21]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(159, 41)` to `(160, 42)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[22]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(161, 39)` to `(163, 40)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[23]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(175, 47)` to `(177, 48)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[24]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(179, 49)` to `(181, 50)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[25]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `7` tiles high from `(173, 37)` to `(174, 43)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[26]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[27]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[28]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[29]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[30]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[31]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[32]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[33]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[34]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[35]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[36]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[37]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[38]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[39]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[40]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[41]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[42]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[43]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[44]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[45]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[46]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[47]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[48]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[49]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[50]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[51]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[52]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[53]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[54]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[55]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[56]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[57]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[58]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[59]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[60]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[61]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[62]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.


#### Complete Bytecode Script Catalog (108 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [101..103, 2..56] AND Condition Check #57 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 168]; Engine Action #52 |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [167..169, 2..55] AND Condition Check #56 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 102]; Trigger Character Emotion Effect (255, 254) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [99..105, 2..75] AND Condition Check #76 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 72]; Engine Action #58 |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [29..33, 2..85] AND Condition Check #86 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 12]; Walk obj[255] to (254,204) |
| `ev[04]` | `1 (Action / Talk)` | Target Inspected is obj[8] | Clear Story Milestone Flag 11 (mask 8); Reset Camera Tracking (4); Warp Room -> Submap 1 at (10,255) facing 254 |
| `ev[05]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Clear Story Milestone Flag 31 (mask 9); Reset Camera Tracking (6); Warp Room -> Submap 2 at (11,7) facing East (Right); Engine Action #9; Open Dialogue Message Window |
| `ev[06]` | `1 (Action / Talk)` | Target Inspected is obj[10] AND Story Flag 1 (mask 255) SET | Clear Story Milestone Flag 31 (mask 9); Reset Camera Tracking (6); Warp Room -> Submap 2 at (11,7) facing 255 |
| `ev[07]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) CLEAR AND Target Inspected is obj[11] | Open Dialogue Sub-Window (2); Engine Action #40 |
| `ev[08]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) SET AND Story Flag 18 (bit 128) CLEAR AND Target Inspected is obj[11] | Open Dialogue Sub-Window (4); Engine Action #40 |
| `ev[09]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[11] | Open Dialogue Sub-Window (5); Engine Action #40 |
| `ev[10]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[11] | Open Dialogue Sub-Window (6); Engine Action #40 |
| `ev[11]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[11] | Open Dialogue Sub-Window (7); Engine Action #40 |
| `ev[12]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) CLEAR AND Target Inspected is obj[12] | Open Dialogue Sub-Window (2); Award Potch Loot (+780 Potch); Open Dialogue Message Window |
| `ev[13]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) SET AND Story Flag 18 (bit 128) CLEAR AND Target Inspected is obj[12] | Open Dialogue Sub-Window (4); Award Potch Loot (+780 Potch); Open Dialogue Message Window |
| `ev[14]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[12] | Open Dialogue Sub-Window (5); Award Potch Loot (+780 Potch); Open Dialogue Message Window |
| `ev[15]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[12] | Open Dialogue Sub-Window (6); Award Potch Loot (+780 Potch); Open Dialogue Message Window |
| `ev[16]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[12] | Open Dialogue Sub-Window (7); Award Potch Loot (+780 Potch); Open Dialogue Message Window |
| `ev[17]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) CLEAR AND Target Inspected is obj[13] | Open Dialogue Sub-Window (2); Remove Item from Inventory (255, 254) |
| `ev[18]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) SET AND Story Flag 18 (bit 128) CLEAR AND Target Inspected is obj[13] | Open Dialogue Sub-Window (4); Remove Item from Inventory (255, 254) |
| `ev[19]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[13] | Open Dialogue Sub-Window (5); Remove Item from Inventory (255, 254) |
| `ev[20]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[13] | Open Dialogue Sub-Window (6); Remove Item from Inventory (255, 254) |
| `ev[21]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[13] | Open Dialogue Sub-Window (7); Remove Item from Inventory (255, 254) |
| `ev[22]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) CLEAR AND Target Inspected is obj[14] | Open Dialogue Sub-Window (2); Open Shop Menu #254 (Type: 255) |
| `ev[23]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) SET AND Story Flag 18 (bit 128) CLEAR AND Target Inspected is obj[14] | Open Dialogue Sub-Window (4); Open Shop Menu #254 (Type: 255) |
| `ev[24]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[14] | Open Dialogue Sub-Window (5); Open Shop Menu #254 (Type: 255) |
| `ev[25]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[14] | Open Dialogue Sub-Window (6); Open Shop Menu #254 (Type: 255) |
| `ev[26]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[14] | Open Dialogue Sub-Window (7); Open Shop Menu #254 (Type: 255) |
| `ev[27]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) CLEAR AND Target Inspected is obj[15] | Open Dialogue Sub-Window (2); Engine Action #44 |
| `ev[28]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) SET AND Story Flag 18 (bit 128) CLEAR AND Target Inspected is obj[15] | Open Dialogue Sub-Window (4); Engine Action #44 |
| `ev[29]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[15] | Open Dialogue Sub-Window (5); Engine Action #44 |
| `ev[30]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[15] | Open Dialogue Sub-Window (6); Engine Action #44 |
| `ev[31]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[15] | Open Dialogue Sub-Window (7); Engine Action #44 |
| `ev[32]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) CLEAR AND Target Inspected is obj[16] | Open Dialogue Sub-Window (2); Make obj[255] Visible (disp = 1) |
| `ev[33]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) SET AND Story Flag 18 (bit 128) CLEAR AND Target Inspected is obj[16] | Open Dialogue Sub-Window (4); Make obj[255] Visible (disp = 1) |
| `ev[34]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[16] | Open Dialogue Sub-Window (5); Make obj[255] Visible (disp = 1) |
| `ev[35]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[16] | Open Dialogue Sub-Window (6); Make obj[255] Visible (disp = 1) |
| `ev[36]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[16] | Open Dialogue Sub-Window (7); Make obj[255] Visible (disp = 1) |
| `ev[37]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) CLEAR AND Target Inspected is obj[17] | Open Dialogue Sub-Window (2); Make obj[3] Hidden (disp = 0); Change Portrait Expression (2) |
| `ev[38]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) SET AND Story Flag 18 (bit 128) CLEAR AND Target Inspected is obj[17] | Open Dialogue Sub-Window (4); Make obj[3] Hidden (disp = 0); Change Portrait Expression (2) |
| `ev[39]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[17] | Open Dialogue Sub-Window (5); Make obj[3] Hidden (disp = 0); Change Portrait Expression (2) |
| `ev[40]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[17] | Open Dialogue Sub-Window (6); Make obj[3] Hidden (disp = 0); Change Portrait Expression (2) |
| `ev[41]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[17] | Open Dialogue Sub-Window (7); Make obj[3] Hidden (disp = 0); Change Portrait Expression (2) |
| `ev[42]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) CLEAR AND Target Inspected is obj[18] | Open Dialogue Sub-Window (2); Teleport obj[3] to (18,3) |
| `ev[43]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) SET AND Story Flag 18 (bit 128) CLEAR AND Target Inspected is obj[18] | Open Dialogue Sub-Window (4); Teleport obj[3] to (18,3) |
| `ev[44]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[18] | Open Dialogue Sub-Window (5); Teleport obj[3] to (18,3) |
| `ev[45]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[18] | Open Dialogue Sub-Window (6); Teleport obj[3] to (18,3) |
| `ev[46]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[18] | Open Dialogue Sub-Window (7); Teleport obj[3] to (18,3) |
| `ev[47]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) CLEAR AND Target Inspected is obj[19] | Open Dialogue Sub-Window (2); Turn obj[255] facing 254 |
| `ev[48]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) SET AND Story Flag 18 (bit 128) CLEAR AND Target Inspected is obj[19] | Open Dialogue Sub-Window (4); Turn obj[255] facing 254 |
| `ev[49]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[19] | Open Dialogue Sub-Window (5); Turn obj[255] facing 254 |
| `ev[50]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[19] | Open Dialogue Sub-Window (6); Turn obj[255] facing 254 |
| `ev[51]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[19] | Open Dialogue Sub-Window (7); Turn obj[255] facing 254 |
| `ev[52]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) CLEAR AND Target Inspected is obj[20] | Open Dialogue Sub-Window (2); Set Entity Movement Speed (255, 254) |
| `ev[53]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) SET AND Story Flag 18 (bit 128) CLEAR AND Target Inspected is obj[20] | Open Dialogue Sub-Window (4); Set Entity Movement Speed (255, 254) |
| `ev[54]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[20] | Open Dialogue Sub-Window (5); Set Entity Movement Speed (255, 254) |
| `ev[55]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[20] | Open Dialogue Sub-Window (6); Set Entity Movement Speed (255, 254) |
| `ev[56]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[20] | Open Dialogue Sub-Window (7); Set Entity Movement Speed (255, 254) |
| `ev[57]` | `1 (Action / Talk)` | Story Flag 35 (bit 128) CLEAR AND Target Inspected is obj[21] | Jump to Bytecode Offset (4, 6); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (0); Exit to World Map (0, 88, 32); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (9,35) facing 128; Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[58]` | `1 (Action / Talk)` | Story Flag 35 (bit 128) SET AND Target Inspected is obj[21] | Open Dialogue Sub-Window (3); Engine Action #51 |
| `ev[59]` | `1 (Action / Talk)` | Target Inspected is obj[22] | Open Dialogue Sub-Window (3); Engine Action #52 |
| `ev[60]` | `1 (Action / Talk)` | Target Inspected is obj[23] | Open Dialogue Sub-Window (3); Engine Action #53 |
| `ev[61]` | `1 (Action / Talk)` | Target Inspected is obj[24] | Open Dialogue Sub-Window (3); Engine Action #54 |
| `ev[62]` | `1 (Action / Talk)` | Target Inspected is obj[25] | Open Dialogue Sub-Window (3); Set Render Priority (pri) (255, 254) |
| `ev[63]` | `1 (Action / Talk)` | Target Inspected is obj[26] | Open Dialogue Sub-Window (3); Set Animation Pose (255, 254) |
| `ev[64]` | `1 (Action / Talk)` | Target Inspected is obj[27] | Open Dialogue Sub-Window (3); Recruit Character into Active Party (255, 254) |
| `ev[65]` | `1 (Action / Talk)` | Target Inspected is obj[28] | Open Dialogue Sub-Window (3); Engine Action #58 |
| `ev[66]` | `1 (Action / Talk)` | Target Inspected is obj[29] | Open Dialogue Sub-Window (3); Set obj[255] Collision to Passable |
| `ev[67]` | `1 (Action / Talk)` | Target Inspected is obj[30] | Open Dialogue Sub-Window (3); Trigger Character Emotion Effect (255, 254) |
| `ev[68]` | `1 (Action / Talk)` | Target Inspected is obj[31] | Open Dialogue Sub-Window (3); Engine Action #61 |
| `ev[69]` | `1 (Action / Talk)` | Target Inspected is obj[32] | Open Dialogue Sub-Window (3); Engine Action #62 |
| `ev[70]` | `1 (Action / Talk)` | Target Inspected is obj[33] | Open Dialogue Sub-Window (3); Engine Action #63 |
| `ev[71]` | `1 (Action / Talk)` | Target Inspected is obj[34] | Open Dialogue Sub-Window (3); Animate Doorway State (255, 254) |
| `ev[72]` | `1 (Action / Talk)` | Target Inspected is obj[35] | Open Dialogue Sub-Window (3); Play Sound Effect (SE) (255) |
| `ev[73]` | `1 (Action / Talk)` | Target Inspected is obj[36] | Open Dialogue Sub-Window (3); Engine Action #66 |
| `ev[74]` | `1 (Action / Talk)` | Target Inspected is obj[37] | Open Dialogue Sub-Window (3); Open Shop Interface #255 |
| `ev[75]` | `1 (Action / Talk)` | Target Inspected is obj[38] | Open Dialogue Sub-Window (3); Play CD / Ambient BGM Track (255) |
| `ev[76]` | `1 (Action / Talk)` | Target Inspected is obj[39] | Open Dialogue Sub-Window (3); Wait for Audio / Window Sync (255) |
| `ev[77]` | `1 (Action / Talk)` | Target Inspected is obj[40] | Open Dialogue Sub-Window (3); Recruit Hero #255 into Battle Slot 254 |
| `ev[78]` | `1 (Action / Talk)` | Target Inspected is obj[41] | Open Dialogue Sub-Window (3); Remove Character from Active Party (255) |
| `ev[79]` | `1 (Action / Talk)` | Target Inspected is obj[42] | Open Dialogue Sub-Window (3); Load Sound Bank into Memory (255, 254) |
| `ev[80]` | `1 (Action / Talk)` | Target Inspected is obj[43] | Open Dialogue Sub-Window (3); Set Combat Battle BGM (255) |
| `ev[81]` | `1 (Action / Talk)` | Target Inspected is obj[44] | Open Dialogue Sub-Window (3); Set Special Scene BGM (255) |
| `ev[82]` | `1 (Action / Talk)` | Target Inspected is obj[45] | Open Dialogue Sub-Window (3); Full Rest & Healing (Restore HP/MP) |
| `ev[83]` | `1 (Action / Talk)` | Target Inspected is obj[46] | Open Dialogue Sub-Window (3); Full Rest & Healing (Restore HP/MP) |
| `ev[84]` | `1 (Action / Talk)` | Target Inspected is obj[47] | Open Dialogue Sub-Window (3); Award Potch Currency (255,254) |
| `ev[85]` | `1 (Action / Talk)` | Target Inspected is obj[48] | Open Dialogue Sub-Window (3); Engine Action #78 |
| `ev[86]` | `1 (Action / Talk)` | Target Inspected is obj[49] | Open Dialogue Sub-Window (3); Bytecode Subroutine Return |
| `ev[87]` | `1 (Action / Talk)` | Target Inspected is obj[50] | Open Dialogue Sub-Window (3); Engine Action #80 |
| `ev[88]` | `1 (Action / Talk)` | Target Inspected is obj[51] | Open Dialogue Sub-Window (3); Engine Action #81 |
| `ev[89]` | `1 (Action / Talk)` | Target Inspected is obj[52] | Open Dialogue Sub-Window (3); Remove Item from Inventory (255, 254) |
| `ev[90]` | `1 (Action / Talk)` | Target Inspected is obj[53] | Open Dialogue Sub-Window (3); Engine Action #83 |
| `ev[91]` | `1 (Action / Talk)` | Target Inspected is obj[54] | Open Dialogue Sub-Window (3); Dismiss Character to Castle Base (255) |
| `ev[92]` | `1 (Action / Talk)` | Target Inspected is obj[55] | Open Dialogue Sub-Window (3); Engine Action #85 |
| `ev[93]` | `1 (Action / Talk)` | Target Inspected is obj[56] | Open Dialogue Sub-Window (3); Animate Door obj[255] (State: 254) |
| `ev[94]` | `1 (Action / Talk)` | Target Inspected is obj[57] | Open Dialogue Sub-Window (3); Engine Action #87 |
| `ev[95]` | `1 (Action / Talk)` | Target Inspected is obj[58] | Open Dialogue Sub-Window (3); Engine Action #88 |
| `ev[96]` | `1 (Action / Talk)` | Target Inspected is obj[59] | Open Dialogue Sub-Window (3); Engine Action #89 |
| `ev[97]` | `1 (Action / Talk)` | Target Inspected is obj[60] | Open Dialogue Sub-Window (3); Engine Action #90 |
| `ev[98]` | `1 (Action / Talk)` | Target Inspected is obj[61] | Open Dialogue Sub-Window (3); Make Object Visible (disp = 1) (255) |
| `ev[99]` | `1 (Action / Talk)` | Target Inspected is obj[62] | Open Dialogue Sub-Window (3); Make Object Hidden (disp = 0) (255) |
| `ev[100]` | `1 (Action / Talk)` | Target Inspected is obj[63] | Open Dialogue Sub-Window (3); Engine Action #93 |
| `ev[101]` | `1 (Action / Talk)` | Target Inspected is obj[64] | Open Dialogue Sub-Window (3); Engine Action #94 |
| `ev[102]` | `1 (Action / Talk)` | Target Inspected is obj[65] | Open Dialogue Sub-Window (3); Set Story Milestone Flag 255 (mask 254) |
| `ev[103]` | `1 (Action / Talk)` | Target Inspected is obj[66] | Open Dialogue Sub-Window (3); Clear Story Milestone Flag 255 (mask 254) |
| `ev[104]` | `1 (Action / Talk)` | Target Inspected is obj[67] | Open Dialogue Sub-Window (3); Mark Chest Looted (Byte 255, Bit 254) |
| `ev[105]` | `1 (Action / Talk)` | Target Inspected is obj[68] | Open Dialogue Sub-Window (3); Clear Chest Looted Flag (255, 254) |
| `ev[106]` | `1 (Action / Talk)` | Target Inspected is obj[69] | Open Dialogue Sub-Window (3); Engine Action #99 |
| `ev[107]` | `1 (Action / Talk)` | Target Inspected is obj[70] | Open Dialogue Sub-Window (3); Mark NPC Talk Interaction Complete (Flag #255) |

---



## Location Map: `vi03`

- **Master Map Container**: `vi03.json`
- **Submap Layer Files**: vi03_00.json
- **Collision Grid Files**: vi03_map_00.json
- **Sprite Animation Bundles**: vi03_00_obj.json
- **Submap Room Count**: 1

### Submap Layer `vi03_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `3` Objects | **Script Count (`evkaz`)**: `10` Scripts

#### Complete Physical Entity Inventory (3 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 65139** | `65139` | `(47, 40)` | `0x0` | East (Right) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Actor ID 65139** | `65139` | `(46, 42)` | `0x0` | East (Right) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | World Device | **Mechanism (ano 23)** | `0` | `(38, 16)` | `0x0` | Frame 23 | Visible (1) | Passable (0) | 4 | 255 | 180 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 65139)**: Positioned at tile `(47, 40)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Object 65139)**: Positioned at tile `(46, 42)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(38, 16)` with state parameter `23`.


#### Complete Bytecode Script Catalog (10 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 38 (bit 1) CLEAR | Make obj[0] Hidden (disp = 0); Reset Camera Tracking (0); Engine Action #9; Teleport obj[255] to (254,255) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [5..7, 2..36] AND Condition Check #37 AND Story Flag 1 (mask 255) SET | Warp Room -> Submap 1 at (8,5); Set Special Scene BGM (1); Warp Map Transition (2, 2, 202, 128, 255) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [56..64, 2..54] AND Condition Check #55 AND Story Flag 1 (mask 255) SET | Warp Room -> Submap 1 at (8,7); Set Special Scene BGM (1); Warp Map Transition (2, 0, 130, 140, 255) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [26..30, 2..40] AND Condition Check #41 AND Story Flag 1 (mask 255) SET | Warp Room -> Submap 1 at (8,7); Set Special Scene BGM (1); Warp Map Transition (2, 1, 42, 94, 255) |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [38..42, 2..30] AND Condition Check #31 AND Story Flag 1 (mask 255) SET | Warp Room -> Submap 1 at (8,7); Set Special Scene BGM (1); Warp Map Transition (2, 1, 208, 128, 255) |
| `ev[05]` | `1 (Action / Talk)` | Player within Box [78..82, 2..24] AND Condition Check #25 AND Story Flag 1 (mask 255) SET | Warp Room -> Submap 1 at (8,7); Set Special Scene BGM (1); Warp Map Transition (2, 1, 196, 58, 255) |
| `ev[06]` | `128 (Loop)` | Player within Box [4..23, 2..56] AND Condition Check #58 AND Story Flag 0 (mask 255) SET | Warp Room -> Submap 1 at (8,7) |
| `ev[07]` | `128 (Loop)` | Player within Box [4..13, 2..44] AND Condition Check #45 AND Story Flag 1 (mask 255) SET | Warp Room -> Submap 1 at (8,5) |
| `ev[08]` | `1 (Action / Talk)` | Story Flag 38 (bit 1) CLEAR AND Player within Box [70..72, 2..39] AND Condition Check #43 AND Story Flag 2 (mask 255) SET | Recruit Character into Active Party (36 [Kahn], 1); Open Shop Menu #4 (Type: 0); Set Render Priority (pri) (0, 68); Engine Action #40; Engine Action #9; Engine Action #54; Open Dialogue Message Window; Warp Room -> Submap 1 at (1,46) facing West (Left); Reset Camera Tracking (1); Engine Action #9; Teleport obj[9] to (38,1); Engine Action #58 |
| `ev[09]` | `128 (Loop)` | Story Flag 38 (bit 1) CLEAR AND Inventory Holds Item #1 [Medicine] | Make obj[0] Hidden (disp = 0); Reset Camera Tracking (0); Engine Action #9; Teleport obj[49] to (2,5); Reset Camera Tracking (4); Engine Action #6; Warp to Castle HQ (18, 30, 255); Engine Action #5; Engine Action #9; Exit to World Map (6, 3, 19); Dismiss Emotion Bubble (255); Walk obj[37] to (1,255) |

---



## Location Map: `vi04`

- **Master Map Container**: `vi04.json`
- **Submap Layer Files**: Embedded in master
- **Collision Grid Files**: vi04_map_00.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 1

### Submap Layer `vi04_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `6` Objects | **Script Count (`evkaz`)**: `22` Scripts

#### Complete Physical Entity Inventory (6 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Camus** | `32` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Miklotov** | `33` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Actor ID 65037** | `65037` | `(34, 54)` | `1x1` | South (Down) | Visible (1) | Special (3) | 3 | 255 | 0 |
| `obj[03]` | NPC / Actor | **Actor ID 65140** | `65140` | `(37, 35)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[04]` | NPC / Actor | **Actor ID 65141** | `65141` | `(51, 35)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[05]` | World Device | **Mechanism (ano 1)** | `0` | `(42, 34)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Camus)**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Miklotov)**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Object 65037)**: Positioned at tile `(34, 54)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Object 65140)**: Positioned at tile `(37, 35)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Object 65141)**: Positioned at tile `(51, 35)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(42, 34)` with state parameter `1`.


#### Complete Bytecode Script Catalog (22 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 16 (bit 2) SET AND Story Flag 16 (bit 4) CLEAR | Make obj[2] Hidden (disp = 0); Reset Camera Tracking (44); Recruit Youth Brigade Recruit into Battle Slot 8; Warp Room -> Submap 8 at (47,255) facing 254 |
| `ev[01]` | `2 (Map Init)` | Story Flag 18 (bit 128) SET | Make obj[1] Hidden (disp = 0); Close Dialogue Window; Warp Room -> Submap 47 at (255,254) facing 255 |
| `ev[02]` | `2 (Map Init)` | Story Flag 20 (bit 128) SET | Make obj[1] Hidden (disp = 0); Screen Fade Transition (138, 4, 2); Teleport obj[255] to (254,255) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [43..45, 2..32] AND Condition Check #33 AND Story Flag 1 (mask 255) SET | Warp Room -> Submap 1 at (8,4); Set Special Scene BGM (1); Warp Map Transition (2, 250, 0, 0, 255) |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [41..47, 2..85] AND Condition Check #86 AND Story Flag 0 (mask 255) SET | Warp Room -> Submap 1 at (8,1); Set Special Scene BGM (1); Warp Map Transition (2, 0, 14, 11, 255) |
| `ev[05]` | `128 (Loop)` | Player within Box [41..47, 2..60] AND Condition Check #61 AND Story Flag 1 (mask 255) SET | Warp Room -> Submap 1 at (8,4) |
| `ev[06]` | `128 (Loop)` | Player within Box [41..47, 2..62] AND Condition Check #63 AND Story Flag 0 (mask 255) SET | Warp Room -> Submap 1 at (8,1) |
| `ev[07]` | `1 (Action / Talk)` | Story Flag 17 (bit 2) SET AND Story Flag 59 (bit 64) CLEAR | Jump to Bytecode Offset (1, 0); Engine Action #102; Open Dialogue Message Window; Engine Action #9; Set obj[64] Collision to Passable |
| `ev[08]` | `1 (Action / Talk)` | Story Flag 16 (bit 1) SET AND Story Flag 16 (bit 2) CLEAR AND Player within Box [44..44, 2..90] AND Condition Check #90 | Recruit Character into Active Party (46 [Oulan], 2); Reset Camera Tracking (44); Engine Action #87; Open Dialogue Message Window; Reset Camera Tracking (47); Launch Tactical War Battle (1); Set Entity Movement Speed (2, 5); Open Dialogue Message Window; Exit to World Map (4, 1, 20); Dismiss Emotion Bubble (255); Engine Action #5; Reset Camera Tracking (4); Exit to World Map (1, 19, 3); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (255); Walk obj[54] to (0,1); Set Combat Battle BGM (15); Close Dialogue Sub-Window (8); Open Dialogue Message Window; Warp Room -> Submap 8 at (5,15) facing Up (North); Open Dialogue Message Window; Pan Camera (2, 30, 49); Warp Town -> Area 5 Map 0 Submap 1 at (5,30); Engine Action #5; Reset Camera Tracking (5); Dismiss Emotion Bubble (0); Warp Town -> Area 2 Map 2 Submap 1 at (0,30); Walk obj[9] to (16,2); Engine Action #58 |
| `ev[09]` | `128 (Loop)` | Story Flag 16 (bit 1) SET AND Story Flag 16 (bit 2) CLEAR AND Inventory Holds Item #1 [Medicine] | Close Dialogue Window; Warp Room -> Submap 100 at (37,1) facing 255 |
| `ev[10]` | `1 (Action / Talk)` | Story Flag 16 (bit 2) SET AND Story Flag 16 (bit 4) CLEAR AND Target Inspected is obj[8] | Open Dialogue Sub-Window (0); Warp Room -> Submap 8 at (5,10) facing West (Left); Open Dialogue Message Window; Dismiss Emotion Bubble (255) |
| `ev[11]` | `1 (Action / Talk)` | Story Flag 16 (bit 2) SET AND Story Flag 16 (bit 4) CLEAR AND Player within Box [41..43, 2..70] AND Condition Check #72 | Recruit Character into Active Party (5 [Sheena], 8); Warp Town -> Area 0 Map 5 Submap 10 at (30,24); Reset Camera Tracking (0); Warp Room -> Submap 2 at (5,8) facing 5; Dismiss Emotion Bubble (1); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Open Dialogue Message Window; Warp Town -> Area 0 Map 5 Submap 5 at (4,4); Warp Room -> Submap 30 at (255,254) facing 50; Engine Action #58 |
| `ev[12]` | `1 (Action / Talk)` | Story Flag 16 (bit 2) SET AND Story Flag 16 (bit 4) CLEAR AND Player within Box [45..47, 2..70] AND Condition Check #72 | Recruit Character into Active Party (5 [Sheena], 8); Warp to Castle HQ (0, 5, 10); Dismiss Emotion Bubble (24); Reset Camera Tracking (0); Warp Room -> Submap 2 at (5,8) facing 5; Dismiss Emotion Bubble (1); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Open Dialogue Message Window; Warp Town -> Area 0 Map 5 Submap 5 at (4,4); Warp Room -> Submap 30 at (255,254) facing 50; Engine Action #58 |
| `ev[13]` | `1 (Action / Talk)` | Story Flag 17 (bit 2) CLEAR AND Target Inspected is obj[10] | Open Dialogue Sub-Window (2); Trigger Character Emotion Effect (255, 254) |
| `ev[14]` | `1 (Action / Talk)` | Story Flag 17 (bit 2) SET AND Story Flag 18 (bit 4) CLEAR AND Target Inspected is obj[10] | Open Dialogue Sub-Window (4); Trigger Character Emotion Effect (255, 254) |
| `ev[15]` | `1 (Action / Talk)` | Story Flag 18 (bit 4) SET AND Target Inspected is obj[10] | Open Dialogue Sub-Window (5); Trigger Character Emotion Effect (255, 254) |
| `ev[16]` | `1 (Action / Talk)` | Story Flag 17 (bit 2) CLEAR AND Target Inspected is obj[11] | Open Dialogue Sub-Window (2); Engine Action #61; Engine Action #5; Close Dialogue Window; Engine Action #5; Screen Fade Transition (0, 0, 30) |
| `ev[17]` | `1 (Action / Talk)` | Story Flag 17 (bit 2) SET AND Story Flag 18 (bit 4) CLEAR AND Target Inspected is obj[11] | Open Dialogue Sub-Window (4); Engine Action #61; Engine Action #5; Close Dialogue Window; Engine Action #5; Screen Fade Transition (0, 0, 30) |
| `ev[18]` | `1 (Action / Talk)` | Story Flag 18 (bit 4) SET AND Target Inspected is obj[11] | Open Dialogue Sub-Window (5); Engine Action #61; Engine Action #5; Close Dialogue Window; Engine Action #5; Screen Fade Transition (0, 0, 30) |
| `ev[19]` | `1 (Action / Talk)` | Story Flag 17 (bit 2) CLEAR AND Target Inspected is obj[12] | Open Dialogue Sub-Window (2); Engine Action #62; Engine Action #5; Display Dialogue Box [Bank: 5, MsgID: 10]; Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (255) |
| `ev[20]` | `1 (Action / Talk)` | Story Flag 17 (bit 2) SET AND Story Flag 18 (bit 4) CLEAR AND Target Inspected is obj[12] | Open Dialogue Sub-Window (4); Engine Action #62; Engine Action #5; Display Dialogue Box [Bank: 5, MsgID: 10]; Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (255) |
| `ev[21]` | `1 (Action / Talk)` | Story Flag 18 (bit 4) SET AND Target Inspected is obj[12] | Open Dialogue Sub-Window (5); Engine Action #62; Engine Action #5; Display Dialogue Box [Bank: 5, MsgID: 10]; Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (255) |

---



## Location Map: `vi05`

- **Master Map Container**: `vi05.json`
- **Submap Layer Files**: vi05_06.json, vi05_07.json, vi05_08.json, vi05_09.json
- **Collision Grid Files**: vi05_map_00.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 1

### Submap Layer `vi05_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `48` Objects | **Script Count (`evkaz`)**: `88` Scripts

#### Complete Physical Entity Inventory (48 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 139** | `139` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Camus** | `32` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Miklotov** | `33` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | NPC / Actor | **Rowd (Camp)** | `130` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[04]` | NPC / Actor | **Actor ID 65140** | `65140` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[05]` | NPC / Actor | **Actor ID 65140** | `65140` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[06]` | NPC / Actor | **Actor ID 65140** | `65140` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[07]` | NPC / Actor | **Actor ID 65140** | `65140` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[08]` | NPC / Actor | **Actor ID 65140** | `65140` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[09]` | NPC / Actor | **Actor ID 65141** | `65141` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[10]` | NPC / Actor | **Actor ID 65141** | `65141` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[11]` | NPC / Actor | **Actor ID 65141** | `65141` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[12]` | NPC / Actor | **Actor ID 65141** | `65141` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[13]` | NPC / Actor | **Actor ID 65141** | `65141` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[14]` | Prop / Scenery | **Prop ID 33056** | `33056` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[15]` | Prop / Scenery | **Prop ID 33057** | `33057` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[16]` | Prop / Scenery | **Prop ID 64974** | `64974` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[17]` | Prop / Scenery | **Prop ID 64974** | `64974` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[18]` | Prop / Scenery | **Prop ID 64974** | `64974` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[19]` | Prop / Scenery | **Prop ID 64974** | `64974` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[20]` | Prop / Scenery | **Prop ID 64974** | `64974` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[21]` | Prop / Scenery | **Prop ID 64975** | `64975` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[22]` | Prop / Scenery | **Prop ID 64975** | `64975` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[23]` | Prop / Scenery | **Prop ID 64975** | `64975` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[24]` | Prop / Scenery | **Prop ID 64975** | `64975` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[25]` | Prop / Scenery | **Prop ID 64975** | `64975` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[26]` | NPC / Actor | **Actor ID 65140** | `65140` | `(94, 115)` | `2x2` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[27]` | NPC / Actor | **Actor ID 65141** | `65141` | `(94, 124)` | `2x2` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[28]` | NPC / Actor | **Actor ID 65139** | `65139` | `(85, 116)` | `2x2` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[29]` | NPC / Actor | **Actor ID 65141** | `65141` | `(35, 116)` | `2x2` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[30]` | NPC / Actor | **Actor ID 65140** | `65140` | `(40, 122)` | `2x2` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[31]` | NPC / Actor | **Actor ID 65139** | `65139` | `(156, 50)` | `2x2` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[32]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(97, 106)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[33]` | Trigger / Hitbox | **Hitbox Zone (6x2)** | `0` | `(23, 106)` | `5x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[34]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(35, 126)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[35]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(52, 38)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[36]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(72, 38)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[37]` | Trigger / Hitbox | **Hitbox Zone (5x1)** | `0` | `(185, 104)` | `4x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[38]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(202, 116)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[39]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(205, 116)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[40]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(129, 105)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[41]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(139, 105)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[42]` | Trigger / Hitbox | **Hitbox Zone (5x2)** | `0` | `(135, 117)` | `4x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[43]` | Trigger / Hitbox | **Hitbox Zone (5x2)** | `0` | `(141, 117)` | `4x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[44]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(158, 46)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[45]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(171, 46)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[46]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(178, 46)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[47]` | Trigger / Hitbox | **Hitbox Zone (5x2)** | `0` | `(183, 57)` | `4x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 139)**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Camus)**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Miklotov)**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Rowd (Camp))**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Object 65140)**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Object 65140)**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[06]` (Object 65140)**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[07]` (Object 65140)**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[08]` (Object 65140)**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[09]` (Object 65141)**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[10]` (Object 65141)**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[11]` (Object 65141)**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[12]` (Object 65141)**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[13]` (Object 65141)**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[14]` (Prop: Object 33056)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[15]` (Prop: Object 33057)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[16]` (Prop: Object 64974)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[17]` (Prop: Object 64974)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[18]` (Prop: Object 64974)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[19]` (Prop: Object 64974)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[20]` (Prop: Object 64974)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[21]` (Prop: Object 64975)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[22]` (Prop: Object 64975)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[23]` (Prop: Object 64975)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[24]` (Prop: Object 64975)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[25]` (Prop: Object 64975)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[26]` (Object 65140)**: Positioned at tile `(94, 115)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[27]` (Object 65141)**: Positioned at tile `(94, 124)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[28]` (Object 65139)**: Positioned at tile `(85, 116)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[29]` (Object 65141)**: Positioned at tile `(35, 116)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[30]` (Object 65140)**: Positioned at tile `(40, 122)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[31]` (Object 65139)**: Positioned at tile `(156, 50)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[32]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(97, 106)` to `(100, 107)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[33]` (Hitbox Zone)**: Bounding trigger area covering `6` tiles wide by `2` tiles high from `(23, 106)` to `(28, 107)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[34]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(35, 126)` to `(36, 126)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[35]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(52, 38)` to `(53, 38)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[36]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(72, 38)` to `(73, 38)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[37]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `1` tiles high from `(185, 104)` to `(189, 104)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[38]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(202, 116)` to `(203, 116)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[39]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(205, 116)` to `(206, 116)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[40]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(129, 105)` to `(130, 105)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[41]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(139, 105)` to `(140, 105)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[42]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `2` tiles high from `(135, 117)` to `(139, 118)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[43]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `2` tiles high from `(141, 117)` to `(145, 118)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[44]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(158, 46)` to `(159, 46)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[45]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(171, 46)` to `(172, 46)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[46]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(178, 46)` to `(179, 46)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[47]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `2` tiles high from `(183, 57)` to `(187, 58)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (88 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 16 (bit 128) SET AND Story Flag 17 (bit 1) CLEAR AND Player within Box [62..62, 2..49] AND Condition Check #49 | Make obj[63] Hidden (disp = 0); Warp Room -> Submap 2 at (8,62) facing 43; Warp to Castle HQ (8, 0, 2); Screen Fade Transition (60, 46, 3); Screen Fade Transition (1, 2, 9); Animate Doorway State (46, 3); Engine Action #9; Warp Room -> Submap 1 at (63,51) facing East (Right); Warp Room -> Submap 2 at (2,61) facing 51; Warp to Castle HQ (2, 1, 2); Warp to Castle HQ (60, 53, 3); Warp to Castle HQ (1, 2, 4); Animate Doorway State (53, 3); Exit to World Map (1, 2, 5); Engine Action #62; Engine Action #54; Warp to Castle HQ (5, 1, 2); Engine Action #6; Engine Action #62; Set Animation Pose (3, 6); Warp Room -> Submap 1 at (0,2) facing South (Down); Warp to Castle HQ (0, 4, 0); Engine Action #5; Open Dialogue Message Window; Engine Action #6; Open Dialogue Message Window; Reset Camera Tracking (0); Engine Action #9; Open Dialogue Message Window; Screen Fade Transition (3, 0, 1); Teleport obj[255] to (254,255) |
| `ev[01]` | `2 (Map Init)` | Story Flag 16 (bit 32) SET AND Story Flag 16 (bit 64) CLEAR | Make obj[2] Hidden (disp = 0); Reset Camera Tracking (62); Open Shop Menu #8 (Type: 0); Warp to Castle HQ (8, 0, 2); Screen Fade Transition (59, 42, 0); Screen Fade Transition (3, 10, 0); Teleport obj[255] to (254,255) |
| `ev[02]` | `2 (Map Init)` | Story Flag 18 (bit 4) SET AND Story Flag 18 (bit 16) CLEAR | Make obj[2] Hidden (disp = 0); Reset Camera Tracking (62); Open Shop Menu #8 (Type: 0); Warp to Castle HQ (8, 0, 2); Display Dialogue Box [Bank: 71, MsgID: 49]; Open Dialogue Message Window; Display Dialogue Box [Bank: 3, MsgID: 12]; Warp Town -> Area 2 Map 13 Submap 71 at (52,0); Place Scenery Structure (3); Place Scenery Structure (2); Warp Town -> Area 14 Map 71 Submap 55 at (0,14); Warp to Castle HQ (14, 2, 2); Show Dialogue Portrait (71, 58, 0); Show Dialogue Portrait (3, 15, 2); Warp Town -> Area 16 Map 71 Submap 61 at (0,16); Warp to Castle HQ (16, 2, 2); Change Portrait Expression (53); Set Entity Movement Speed (0, 17); Warp to Castle HQ (17, 3, 2); Display Speaker Name Box (53); Engine Action #52; Open Dialogue Message Window; Display Speaker Name Box (3); Display Speaker Name Box (3); Warp Town -> Area 19 Map 53 Submap 55 at (0,19); Warp to Castle HQ (19, 3, 2); Branch on Choice (53, 58); Open Dialogue Message Window; Branch on Choice (3, 20); Warp to Castle HQ (2, 21, 53); Engine Action #61; Open Dialogue Message Window; Execute Choice Result (3); Execute Choice Result (3); Teleport obj[255] to (254,255) |
| `ev[03]` | `2 (Map Init)` | Story Flag 20 (bit 128) SET | Make obj[1] Hidden (disp = 0); Launch Tactical War Battle (47) |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [128..132, 2..42] AND Condition Check #43 AND Story Flag 1 (mask 255) SET | Close Dialogue Window; Warp Town -> Area 2 Map 40 Submap 3 at (0,0); Wait for Audio / Window Sync (1); Display Dialogue Box [Bank: 0, MsgID: 26]; Make obj[255] Hidden (disp = 0) |
| `ev[05]` | `1 (Action / Talk)` | Player within Box [196..200, 2..42] AND Condition Check #43 AND Story Flag 1 (mask 255) SET | Close Dialogue Window; Warp Town -> Area 2 Map 40 Submap 3 at (0,0); Wait for Audio / Window Sync (1); Display Dialogue Box [Bank: 0, MsgID: 98]; Make obj[255] Hidden (disp = 0) |
| `ev[06]` | `1 (Action / Talk)` | Player within Box [24..28, 2..41] AND Condition Check #42 AND Story Flag 1 (mask 255) SET | Close Dialogue Window; Warp Town -> Area 2 Map 40 Submap 3 at (0,0); Wait for Audio / Window Sync (1); Display Dialogue Box [Bank: 0, MsgID: 130]; Make obj[255] Hidden (disp = 0) |
| `ev[07]` | `1 (Action / Talk)` | Player within Box [96..100, 2..41] AND Condition Check #42 AND Story Flag 1 (mask 255) SET | Close Dialogue Window; Warp Town -> Area 2 Map 40 Submap 3 at (0,0); Wait for Audio / Window Sync (1); Display Dialogue Box [Bank: 0, MsgID: 198]; Make obj[255] Hidden (disp = 0) |
| `ev[08]` | `1 (Action / Talk)` | Player within Box [58..66, 2..111] AND Condition Check #112 AND Story Flag 0 (mask 255) SET | Warp Room -> Submap 0 at (8,3); Set Special Scene BGM (1); Warp Map Transition (3, 0, 44, 36, 255) |
| `ev[09]` | `1 (Action / Talk)` | Story Flag 16 (bit 2) SET AND Story Flag 16 (bit 4) CLEAR AND Player within Box [58..66, 2..65] AND Condition Check #66 AND Story Flag 1 (mask 255) SET | Recruit Character into Active Party (46 [Oulan], 10); Open Dialogue Message Window; Warp Town -> Area 8 Map 62 Submap 43 at (0,8); Warp to Castle HQ (8, 0, 2); Screen Fade Transition (59, 42, 0); Screen Fade Transition (3, 10, 0); Teleport obj[101] to (9,8); Open Shop Menu #4 (Type: 0); Set Render Priority (pri) (0, 62); Set Entity Movement Speed (8, 33); Warp Room -> Submap 46 at (0,1) facing South (Down); Warp Town -> Area 0 Map 3 Submap 0 at (4,0); Engine Action #5; Open Dialogue Message Window; Engine Action #6; Teleport obj[49] to (6,5); Warp Room -> Submap 5 at (2,2) facing West (Left); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Warp Town -> Area 4 Map 5 Submap 0 at (3,3); Warp Room -> Submap 0 at (30,255) facing 254; Engine Action #5; Warp to Castle HQ (4, 5, 0); Warp to Castle HQ (2, 1, 1); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Exit to World Map (4, 5, 0); Engine Action #5; Warp to Castle HQ (2, 1, 0); Dismiss Emotion Bubble (255); Engine Action #5; Engine Action #5; Exit to World Map (5, 0, 5); Warp Town -> Area 2 Map 1 Submap 0 at (30,255); Engine Action #5; Engine Action #6; Exit to World Map (5, 0, 6); Warp Town -> Area 0 Map 5 Submap 5 at (1,0); Dismiss Emotion Bubble (255); Walk obj[101] to (7,0); Jump to Bytecode Offset (1, 1); Close Dialogue Sub-Window (8); Open Dialogue Message Window; Warp Town -> Area 73 Map 20 Submap 40 at (0,0); Warp Town -> Area 0 Map 3 Submap 0 at (4,41); Warp Town -> Area 0 Map 1 Submap 255 at (0,5); Warp Room -> Submap 0 at (30,24) facing West (Left); Open Dialogue Message Window; Engine Action #5; Warp Room -> Submap 8 at (0,6) facing 73; Branch on Choice (40, 0); Open Dialogue Message Window; Warp Town -> Area 0 Map 7 Submap 0 at (8,41); Warp Town -> Area 2 Map 3 Submap 255 at (2,5); Warp Room -> Submap 0 at (30,24) facing West (Left); Open Dialogue Message Window; Engine Action #9; Warp to Castle HQ (24, 8, 0); Screen Fade Transition (5, 10, 4); Exit to World Map (0, 1, 5); Show Dialogue Portrait (30, 24, 10); Open Dialogue Message Window; Close Dialogue Window; Jump to Bytecode Offset (9, 8); Close Dialogue Window; Warp Town -> Area 2 Map 100 Submap 39 at (34,43); Open Dialogue Message Window; Pan Camera (4, 0, 194); Remove Item from Inventory (8, 101); Pan Camera (1, 3, 0); Warp Town -> Area 33 Map 1 Submap 18 at (46,0); Warp Room -> Submap 2 at (0,3) facing South (Down); Exit to World Map (0, 5, 0); Engine Action #6; Warp Town -> Area 10 Map 191 Submap 82 at (0,10); Warp to Castle HQ (10, 3, 47); Set Entity Movement Speed (6, 5); Warp Room -> Submap 7 at (3,1) facing South (Down); Warp Room -> Submap 0 at (30,255) facing 254; Engine Action #5; Warp Town -> Area 4 Map 7 Submap 3 at (4,1); Warp Room -> Submap 0 at (30,255) facing 254; Engine Action #5; Warp to Castle HQ (4, 7, 3); Exit to World Map (0, 1, 2); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Exit to World Map (4, 7, 3); Engine Action #6; Warp Room -> Submap 2 at (0,30) facing 255; Engine Action #5; Engine Action #5; Exit to World Map (7, 3, 6); Open Dialogue Message Window; Warp Room -> Submap 0 at (30,255) facing 254; Engine Action #5; Engine Action #6; Exit to World Map (7, 3, 8); Warp Town -> Area 0 Map 30 Submap 255 at (254,50); Jump to Bytecode Offset (1, 4); Close Dialogue Window; Warp Room -> Submap 100 at (5,10) facing 5; Dismiss Emotion Bubble (0); Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 24, 10); Open Dialogue Message Window; Display Dialogue Box [Bank: 5, MsgID: 10]; Engine Action #5; Show Dialogue Portrait (4, 4, 2); Engine Action #5; Engine Action #5; Dismiss Emotion Bubble (0); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp to Castle HQ (0, 5, 15); Dismiss Emotion Bubble (24); Screen Fade Transition (0, 13, 5); Screen Fade Transition (5, 15, 0); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Exit to World Map (5, 2, 23); Dismiss Emotion Bubble (1); Screen Fade Transition (5, 1, 1); Open Dialogue Message Window; Dismiss Emotion Bubble (5); Open Dialogue Message Window; Engine Action #5; Screen Fade Transition (0, 0, 30); Close Dialogue Sub-Window (1); Open Dialogue Message Window; Animate Door Open; Engine Action #5; Warp Room -> Submap 15 at (3,0) facing 5; Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (11); Warp Town -> Area 2 Map 100 Submap 39 at (34,43); Open Dialogue Message Window; Pan Camera (4, 0, 187); Dismiss Character Dialogue Portrait; Reset Camera Tracking (3); Open Dialogue Message Window; Warp Town -> Area 33 Map 1 Submap 18 at (0,1); Engine Action #5; Warp Room -> Submap 7 at (3,3) facing 30; Warp to Castle HQ (0, 3, 11); Warp Room -> Submap 100 at (5,1) facing 5; Dismiss Emotion Bubble (0); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp Town -> Area 0 Map 5 Submap 15 at (30,24); Warp Room -> Submap 15 at (73,20) facing 40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 0 Map 17 Submap 0 at (16,41); Warp Town -> Area 4 Map 5 Submap 255 at (4,24); Warp Room -> Submap 19 at (30,0) facing East (Right); Warp Town -> Area 1 Map 18 Submap 36 at (1,5); Warp Room -> Submap 15 at (0,0) facing 5; Engine Action #5; Warp to Castle HQ (0, 5, 30); Exit to World Map (6, 1, 1); Exit to World Map (5, 3, 1); Dismiss Emotion Bubble (73); Dismiss Emotion Bubble (49); Warp Town -> Area 5 Map 1 Submap 4 at (2,3); Exit to World Map (0, 0, 5); Engine Action #5; Warp Town -> Area 0 Map 30 Submap 255 at (254,5); Open Dialogue Message Window; Exit to World Map (3, 3, 3); Engine Action #5; Dismiss Emotion Bubble (4); Engine Action #6; Warp Room -> Submap 4 at (5,3) facing West (Left); Exit to World Map (2, 3, 2); Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (255); Walk obj[54] to (1,2); Return Warp to Castle Base (9, 0); Warp Room -> Submap 6 at (255,5) facing 24; Warp Room -> Submap 18 at (5,1) facing 4; Engine Action #5; Warp Town -> Area 3 Map 30 Submap 1 at (1,34); Dismiss Emotion Bubble (0); Warp to Castle HQ (2, 1, 18); Engine Action #5; Open Dialogue Message Window; Warp Room -> Submap 30 at (255,6) facing 9; Dismiss Dialogue Portrait; Exit to World Map (58, 255, 254) |
| `ev[10]` | `128 (Loop)` | Story Flag 16 (bit 2) SET AND Story Flag 16 (bit 4) CLEAR AND Inventory Holds Item #1 [Medicine] AND Temp Event Flag #2 SET | Set Combat Battle BGM (100); Close Dialogue Window; Warp Town -> Area 2 Map 200 Submap 36 at (2,255) |
| `ev[11]` | `1 (Action / Talk)` | Story Flag 16 (bit 4) SET AND Story Flag 16 (bit 8) CLEAR AND Player within Box [132..136, 2..89] AND Condition Check #90 AND Story Flag 0 (mask 255) SET | Recruit Character into Active Party (33 [Camus], 1); Display Speaker Name Box (0); Warp Room -> Submap 2 at (5,1) facing 4; Engine Action #5; Warp Room -> Submap 2 at (0,5) facing 5; Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Open Dialogue Message Window; Warp to Castle HQ (0, 5, 5); Exit to World Map (4, 1, 2); Dismiss Emotion Bubble (255); Walk obj[73] to (15,24); Warp Room -> Submap 1 at (5,1) facing 4; Engine Action #5; Engine Action #5; Show Dialogue Portrait (0, 3, 30); Warp Room -> Submap 34 at (58,255) facing 254 |
| `ev[12]` | `1 (Action / Talk)` | Story Flag 16 (bit 4) SET AND Story Flag 16 (bit 8) CLEAR AND Player within Box [51..73, 2..99] AND Condition Check #100 AND Story Flag 0 (mask 255) SET | Recruit Character into Active Party (33 [Camus], 1); Display Speaker Name Box (0); Warp Room -> Submap 1 at (4,5) facing West (Left); Warp to Castle HQ (2, 0, 5); Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (5); Open Dialogue Message Window; Warp to Castle HQ (0, 5, 5); Warp Room -> Submap 30 at (73,15) facing 24; Warp Room -> Submap 2 at (5,1) facing 4; Engine Action #5; Engine Action #5; Show Dialogue Portrait (0, 3, 30); Warp Room -> Submap 5 at (0,4) facing 4; Warp Room -> Submap 30 at (34,58) facing 255 |
| `ev[13]` | `1 (Action / Talk)` | Story Flag 16 (bit 4) SET AND Story Flag 16 (bit 8) CLEAR AND Player within Box [192..196, 2..105] AND Condition Check #106 AND Story Flag 0 (mask 255) SET | Recruit Character into Active Party (33 [Camus], 1); Display Speaker Name Box (0); Warp Room -> Submap 1 at (4,5) facing South (Down); Warp to Castle HQ (2, 0, 5); Engine Action #5; Warp Room -> Submap 5 at (15,30) facing 24; Warp Room -> Submap 0 at (73,15) facing 73; Branch on Choice (40, 0); Open Dialogue Message Window; Warp Town -> Area 0 Map 17 Submap 0 at (16,73); Show Dialogue Portrait (41, 2, 0); Warp Room -> Submap 0 at (24,1) facing South (Down); Display Choice Selection (11, 2); Warp Town -> Area 120 Map 34 Submap 43 at (0,7); Exit to World Map (0, 193, 124); Reset Camera Tracking (3); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #9; Open Dialogue Message Window; Warp Room -> Submap 2 at (255,1) facing 5; Warp Room -> Submap 5 at (1,3) facing 30; Warp Room -> Submap 5 at (0,3) facing South (Down); Engine Action #5; Engine Action #5; Exit to World Map (4, 1, 2); Dismiss Emotion Bubble (34); Warp Town -> Area 58 Map 255 Submap 254 at (255,254) |
| `ev[14]` | `1 (Action / Talk)` | Story Flag 16 (bit 4) SET AND Story Flag 16 (bit 8) CLEAR AND Story Flag 0 (bit 1) SET AND Player within Box [193..193, 2..124] AND Condition Check #124 AND Story Flag 0 (mask 255) SET | Recruit Character into Active Party (101 [Teresa], 9); Reset Camera Tracking (33); Warp Room -> Submap 46 at (2,11) facing 187; Engine Action #120; Warp Room -> Submap 3 at (11,0) facing East (Right); Open Dialogue Message Window; Warp to Castle HQ (0, 1, 47); Engine Action #5; Warp Room -> Submap 7 at (3,2) facing 30; Load Sound Bank into Memory (1, 1); Reset Camera Tracking (73); Engine Action #120; Launch Tactical War Battle (1); Set Combat Battle BGM (250); Close Dialogue Sub-Window (11); Open Dialogue Message Window; Branch on Choice (44, 5); Open Dialogue Message Window; Engine Action #5; Trigger Character Emotion Effect (0, 0); Engine Action #5; Trigger Character Emotion Effect (30, 72); Warp Room -> Submap 3 at (73,15) facing 72; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Open Dialogue Message Window; Engine Action #5; Dismiss Emotion Bubble (3); Open Dialogue Message Window; Engine Action #5; Trigger Character Emotion Effect (0, 0); Engine Action #5; Show Dialogue Portrait (2, 0, 5); Dismiss Emotion Bubble (30); Engine Action #5; Open Dialogue Message Window; Exit to World Map (2, 2, 2); Engine Action #5; Show Dialogue Portrait (4, 5, 2); Warp Room -> Submap 6 at (0,1) facing Up (North); Open Dialogue Message Window; Dismiss Emotion Bubble (5); Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (4, 3, 2); Warp Town -> Area 0 Map 0 Submap 5 at (5,3); Open Dialogue Message Window; Engine Action #5; Dismiss Emotion Bubble (0); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp Town -> Area 0 Map 5 Submap 30 at (0,0); Dismiss Emotion Bubble (101); Open Dialogue Message Window; Engine Action #205; Launch Tactical War Battle (8); Set Combat Battle BGM (1); Engine Action #54; Open Dialogue Message Window; Dismiss Dialogue Portrait; Launch Tactical War Battle (16); Set Combat Battle BGM (1); Engine Action #54; Open Dialogue Message Window; Dismiss Dialogue Portrait; Launch Tactical War Battle (16); Engine Action #5; Open Dialogue Message Window; Engine Action #5; Engine Action #90; Warp Town -> Area 0 Map 5 Submap 5 at (1,0); Dismiss Emotion Bubble (101); Engine Action #5; Engine Action #205; Engine Action #54; Open Dialogue Message Window; Dismiss Dialogue Portrait; Jump to Bytecode Offset (7, 4); Jump to Bytecode Offset (2, 10); Set Combat Battle BGM (30); Close Dialogue Sub-Window (11); Open Dialogue Message Window; Execute Choice Result (73); Dismiss Emotion Bubble (101); Engine Action #9; Reset Camera Tracking (36); Dismiss Dialogue Portrait; Jump to Bytecode Offset (0, 205); Set Combat Battle BGM (210); Jump to Bytecode Offset (5, 205); Engine Action #54; Open Dialogue Message Window; Dismiss Dialogue Portrait; Engine Action #9; Open Dialogue Message Window; Engine Action #128; Engine Action #54; Open Dialogue Message Window; Warp Room -> Submap 0 at (4,7) facing East (Right); Engine Action #5; Warp Room -> Submap 0 at (0,30) facing 73; Engine Action #120; Display Emotion Bubble (7, 72); Open Dialogue Message Window; Warp Room -> Submap 30 at (1,0) facing 33; Warp Room -> Submap 46 at (2,1) facing 189; Dismiss Character Dialogue Portrait; Open Dialogue Message Window; Warp Room -> Submap 1 at (3,47) facing 101; Engine Action #9; Animate Door Open; Set Combat Battle BGM (60); Jump to Bytecode Offset (2, 4); Close Dialogue Window; Warp Room -> Submap 150 at (24,1) facing South (Down); Set Story Flag (44, 49); Warp Town -> Area 5 Map 0 Submap 5 at (30,4); Warp Town -> Area 2 Map 2 Submap 5 at (15,4); Engine Action #5; Warp Town -> Area 1 Map 4 Submap 6 at (0,1); Warp Town -> Area 0 Map 30 Submap 255 at (254,5); Warp Room -> Submap 4 at (5,60) facing 7; Warp Town -> Area 30 Map 255 Submap 254 at (50,5); Open Dialogue Message Window; Exit to World Map (3, 2, 1); Dismiss Emotion Bubble (101); Engine Action #9; Reset Camera Tracking (36); Exit to World Map (5, 1, 5); Show Dialogue Portrait (4, 4, 3); Warp Town -> Area 30 Map 34 Submap 5 at (0,0); Open Dialogue Message Window; Dismiss Emotion Bubble (101); Engine Action #9; Animate Door Open; Jump to Bytecode Offset (1, 0); Screen Fade Transition (0, 1, 9); Dismiss Dialogue Portrait; Reset Camera Tracking (58) |
| `ev[15]` | `128 (Loop)` | Story Flag 16 (bit 4) SET AND Story Flag 16 (bit 8) CLEAR AND Story Flag 0 (bit 1) SET AND Inventory Holds Item #1 [Medicine] | Dismiss Emotion Bubble (3); Engine Action #5; Open Dialogue Message Window; Engine Action #128; Engine Action #150; Engine Action #150; Engine Action #80; Toggle Random Encounters (1) |
| `ev[16]` | `128 (Loop)` | Story Flag 16 (bit 4) SET AND Story Flag 16 (bit 8) CLEAR AND Story Flag 0 (bit 1) SET AND Inventory Holds Item #4 [Throat Drops] | Display Emotion Bubble (4, 37); Exit to World Map (255, 254, 255) |
| `ev[17]` | `128 (Loop)` | Story Flag 16 (bit 4) SET AND Story Flag 16 (bit 8) CLEAR AND Story Flag 0 (bit 1) SET AND Inventory Holds Item #8 [Fire Wall] | Toggle Random Encounters (8); Launch Tactical War Battle (16); Dismiss Emotion Bubble (4); Place Scenery Structure (130); Dismiss Dialogue Portrait; Engine Action #114; Open Dialogue Message Window; Engine Action #80; Open Dialogue Message Window; Engine Action #128; Mark NPC Talk Interaction Complete (Flag #100); Engine Action #128; Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[18]` | `1 (Action / Talk)` | Story Flag 16 (bit 8) SET AND Story Flag 16 (bit 16) CLEAR AND Player within Box [74..75, 2..76] AND Condition Check #93 AND Story Flag 2 (mask 255) SET | Recruit Character into Active Party (46 [Oulan], 2); Engine Action #9; Open Save Crystal Menu (MSaveInit); Engine Action #81; Open Dialogue Message Window; Engine Action #9; Warp to Castle HQ (9, 3, 47); Open Shop Menu #4 (Type: 0); Set Render Priority (pri) (0, 70); Engine Action #85; Engine Action #9; Set Entity Movement Speed (2, 5); Open Dialogue Message Window; Exit to World Map (4, 2, 8); Engine Action #5; Screen Fade Transition (1, 0, 30); Engine Action #5; Engine Action #9; Exit to World Map (5, 3, 25); Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (255); Walk obj[24] to (9,0); Open Dialogue Sub-Window (5); Engine Action #9; Engine Action #5; Screen Fade Transition (3, 0, 5); Engine Action #5; Warp Room -> Submap 4 at (7,1) facing 5; Dismiss Emotion Bubble (2); Engine Action #9; Engine Action #62; Teleport obj[33] to (1,18); Open Dialogue Message Window; Warp Room -> Submap 1 at (4,5) facing Up (North); Warp to Castle HQ (1, 0, 5); Engine Action #5; Warp to Castle HQ (0, 30, 5); Open Dialogue Message Window; Warp Town -> Area 0 Map 5 Submap 10 at (30,24); Warp Room -> Submap 24 at (73,15) facing 39; Return Warp to Castle Base (5, 0); Warp Room -> Submap 30 at (9,16) facing 16; Engine Action #58 |
| `ev[19]` | `1 (Action / Talk)` | Story Flag 16 (bit 8) SET AND Story Flag 16 (bit 16) CLEAR AND Player within Box [49..50, 2..76] AND Condition Check #93 AND Story Flag 3 (mask 255) SET | Recruit Character into Active Party (46 [Oulan], 2); Engine Action #9; Animate Door obj[81] (State: 0); Engine Action #9; Warp to Castle HQ (9, 2, 47); Open Shop Menu #4 (Type: 0); Set Render Priority (pri) (0, 54); Engine Action #85; Engine Action #9; Set Entity Movement Speed (2, 5); Open Dialogue Message Window; Exit to World Map (4, 3, 8); Engine Action #5; Screen Fade Transition (1, 0, 30); Engine Action #5; Engine Action #9; Exit to World Map (5, 2, 25); Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (255); Walk obj[24] to (9,0); Open Dialogue Sub-Window (5); Engine Action #9; Engine Action #5; Screen Fade Transition (2, 0, 5); Engine Action #5; Warp Room -> Submap 4 at (7,1) facing 5; Dismiss Emotion Bubble (2); Engine Action #9; Engine Action #62; Teleport obj[33] to (1,18); Open Dialogue Message Window; Warp Room -> Submap 1 at (4,5) facing East (Right); Warp to Castle HQ (1, 0, 5); Engine Action #5; Warp Town -> Area 0 Map 30 Submap 5 at (0,3); Open Dialogue Message Window; Engine Action #5; Screen Fade Transition (30, 24, 1); Open Dialogue Message Window; Close Dialogue Sub-Window (73); Show Dialogue Portrait (39, 34, 5); Open Dialogue Message Window; Warp Room -> Submap 30 at (9,16) facing 16; Engine Action #58 |
| `ev[20]` | `1 (Action / Talk)` | Story Flag 16 (bit 16) SET AND Story Flag 16 (bit 32) CLEAR AND Player within Box [51..73, 2..99] AND Condition Check #100 AND Story Flag 0 (mask 255) SET | Recruit Character into Active Party (33 [Camus], 1); Display Speaker Name Box (0); Warp Room -> Submap 1 at (4,5) facing West (Left); Warp to Castle HQ (2, 0, 5); Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (5); Open Dialogue Message Window; Warp to Castle HQ (0, 5, 5); Warp Room -> Submap 30 at (73,15) facing 24; Warp Room -> Submap 3 at (5,1) facing 4; Engine Action #5; Engine Action #5; Show Dialogue Portrait (3, 0, 5); Engine Action #5; Warp Room -> Submap 30 at (5,0) facing 4; Engine Action #5; Engine Action #5; Dismiss Emotion Bubble (1); Warp to Castle HQ (30, 1, 1); Return Warp to Castle Base (58, 255) |
| `ev[21]` | `1 (Action / Talk)` | Story Flag 16 (bit 16) SET AND Story Flag 16 (bit 32) CLEAR AND Player within Box [58..66, 2..65] AND Condition Check #66 AND Story Flag 1 (mask 255) SET | Recruit Character into Active Party (46 [Oulan], 2); Reset Camera Tracking (62); Open Shop Menu #8 (Type: 0); Warp to Castle HQ (8, 0, 2); Screen Fade Transition (59, 42, 0); Screen Fade Transition (3, 10, 0); Warp Town -> Area 9 Map 62 Submap 46 at (0,9); Warp to Castle HQ (9, 1, 47); Jump to Bytecode Offset (9, 8); Open Shop Menu #4 (Type: 0); Set Render Priority (pri) (0, 63); Engine Action #51; Reset Camera Tracking (33); Warp Room -> Submap 46 at (0,1) facing South (Down); Warp Town -> Area 0 Map 3 Submap 0 at (4,0); Engine Action #5; Open Dialogue Message Window; Engine Action #6; Teleport obj[49] to (6,5); Warp Room -> Submap 5 at (2,2) facing West (Left); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Warp Town -> Area 4 Map 5 Submap 0 at (3,3); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp Room -> Submap 30 at (255,254) facing 5; Warp to Castle HQ (4, 5, 0); Warp to Castle HQ (2, 2, 1); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Exit to World Map (4, 5, 0); Engine Action #5; Warp to Castle HQ (1, 1, 0); Dismiss Emotion Bubble (255); Engine Action #5; Engine Action #5; Exit to World Map (5, 0, 5); Warp Town -> Area 3 Map 1 Submap 0 at (30,255); Engine Action #5; Engine Action #6; Exit to World Map (5, 0, 7); Warp Town -> Area 1 Map 5 Submap 5 at (1,0); Dismiss Emotion Bubble (255); Walk obj[73] to (15,101); Pan Camera (0, 101, 1); Warp Room -> Submap 8 at (0,25) facing 73; Show Dialogue Portrait (24, 9, 0); Fade In from Black (73); Show Dialogue Portrait (24, 10, 0); Fade Out to Black (73); Show Dialogue Portrait (24, 8, 0); Display Chapter Text (73); Show Dialogue Portrait (24, 9, 0); Display Emotion Bubble (73, 15); Close Dialogue Sub-Window (8); Open Dialogue Message Window; Dismiss Emotion Bubble (73); Show Dialogue Portrait (24, 9, 0); Warp Room -> Submap 73 at (15,49); Reset Camera Tracking (5); Engine Action #9; Exit to World Map (5, 3, 0); Engine Action #5; Engine Action #5; Open Dialogue Message Window; Set Story Flag (30, 1); Engine Action #9; Engine Action #5; Open Dialogue Message Window; Exit to World Map (4, 5, 10); Warp Town -> Area 0 Map 7 Submap 2 at (30,255); Engine Action #5; Warp Room -> Submap 4 at (5,10) facing East (Right); Open Dialogue Message Window; Pan Camera (2, 30, 255); Engine Action #5; Warp Town -> Area 4 Map 4 Submap 5 at (20,2); Open Dialogue Message Window; Pan Camera (2, 30, 255); Engine Action #5; Warp to Castle HQ (4, 4, 5); Branch on Choice (3, 0); Pan Camera (2, 30, 255); Engine Action #5; Exit to World Map (4, 4, 5); Dismiss Emotion Bubble (2); Open Dialogue Message Window; Pan Camera (1, 30, 255); Engine Action #5; Engine Action #5; Exit to World Map (4, 5, 30); Warp to Castle HQ (0, 7, 1); Dismiss Emotion Bubble (255); Engine Action #5; Engine Action #6; Exit to World Map (4, 5, 20); Warp to Castle HQ (0, 7, 2); Dismiss Emotion Bubble (255); Walk obj[73] to (30,49); Pan Camera (5, 0, 4); Exit to World Map (2, 2, 1); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Warp Room -> Submap 4 at (3,2) facing West (Left); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Warp Town -> Area 4 Map 4 Submap 2 at (2,1); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Warp to Castle HQ (4, 4, 3); Warp Town -> Area 1 Map 0 Submap 30 at (255,254); Engine Action #5; Exit to World Map (4, 4, 2); Warp Room -> Submap 0 at (30,255) facing 254; Engine Action #5; Engine Action #5; Exit to World Map (4, 3, 1); Warp Room -> Submap 30 at (255,254) facing 5; Engine Action #6; Exit to World Map (4, 3, 2); Warp Room -> Submap 30 at (255,254) facing 50; Set Combat Battle BGM (15); Close Dialogue Sub-Window (8); Open Dialogue Message Window; Warp Map Transition (5, 10, 4, 4, 5); Show Dialogue Portrait (0, 3, 5); Show Dialogue Portrait (30, 24, 10); Open Dialogue Message Window; Return to Previous Memory Map (73); Show Dialogue Portrait (73, 20, 40); Open Dialogue Message Window; Open Dialogue Message Window; Warp to Castle HQ (0, 34, 0); Start Boss Battle #0 (BGM: 36); Set Combat Battle BGM (15); Award Potch Loot (+768 Potch); Warp Room -> Submap 255 at (0,24) facing 10; Open Dialogue Message Window; Toggle Random Encounters (73); Show Dialogue Portrait (24, 1, 0); Open Save Crystal Menu (MSaveInit); Set Combat Battle BGM (15); Close Dialogue Sub-Window (10); Open Dialogue Message Window; Engine Action #39; Set Combat Battle BGM (15); Close Dialogue Window; Warp Town -> Area 2 Map 120 Submap 34 at (69,1); Make obj[9] Hidden (disp = 0); Dismiss Dialogue Portrait; Warp Map Transition (9, 16, 64, 9, 5); Dismiss Dialogue Portrait; Teleport obj[117] to (0,0); Engine Action #117; Warp Room -> Submap 42 at (5,8) facing 4; Open Dialogue Message Window; Engine Action #62; Set Entity Movement Speed (58, 255); Warp Room -> Submap 10 at (0,40) facing 73; Show Dialogue Portrait (39, 34, 5); Open Dialogue Message Window; Warp Town -> Area 0 Map 5 Submap 5 at (0,0); Dismiss Emotion Bubble (9); Dismiss Dialogue Portrait; Warp Map Transition (58, 255, 254, 255, 2); Close Dialogue Sub-Window (10); Open Dialogue Message Window; Award Potch Loot (+18,703 Potch); Close Dialogue Sub-Window (1); Open Dialogue Message Window; Remove Item from Inventory (73, 15); Close Dialogue Sub-Window (10); Open Dialogue Message Window; Open Shop Menu #2 (Type: 11); Warp Town -> Area 120 Map 34 Submap 69 at (1,9); Dismiss Dialogue Portrait; Warp Map Transition (117, 0, 0, 117, 1); Warp Room -> Submap 5 at (8,4) facing South (Down); Engine Action #62; Set Entity Movement Speed (58, 255) |
| `ev[22]` | `1 (Action / Talk)` | Story Flag 16 (bit 32) SET AND Story Flag 16 (bit 64) CLEAR AND Target Inspected is obj[10] | Recruit Character into Active Party (24 [Milie], 10); Warp Town -> Area 4 Map 73 Submap 15 at (73,20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 2 Map 5 Submap 2 at (6,41); Warp Town -> Area 0 Map 1 Submap 73 at (15,255); Open Dialogue Message Window; Close Dialogue Sub-Window (10); Warp Town -> Area 7 Map 5 Submap 10 at (5,15); Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (58); Warp Room -> Submap 10 at (2,8) facing 73; Show Dialogue Portrait (11, 2, 2); Engine Action #120; Wait for Audio / Window Sync (1); Make obj[9] Hidden (disp = 0); Engine Action #5; Dismiss Dialogue Portrait; Engine Action #9; Dismiss Dialogue Portrait; Animate Doorway State (10, 0); Warp Town -> Area 47 Map 117 Submap 0 at (0,117); Warp Room -> Submap 42 at (5,8) facing 4; Open Dialogue Message Window; Engine Action #62; Set Entity Movement Speed (58, 255) |
| `ev[23]` | `1 (Action / Talk)` | Story Flag 16 (bit 32) SET AND Story Flag 16 (bit 64) CLEAR AND Story Flag 16 (bit 128) CLEAR AND Target Inspected is obj[8] | Recruit Character into Active Party (24 [Milie], 8); Warp Town -> Area 14 Map 3 Submap 8 at (0,58) |
| `ev[24]` | `1 (Action / Talk)` | Story Flag 16 (bit 32) SET AND Story Flag 16 (bit 64) CLEAR AND Story Flag 16 (bit 128) CLEAR AND Player within Box [51..73, 2..99] AND Condition Check #100 AND Story Flag 0 (mask 255) SET | Recruit Character into Active Party (33 [Camus], 1); Display Speaker Name Box (0); Warp Room -> Submap 1 at (4,5) facing West (Left); Warp to Castle HQ (2, 0, 5); Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (5); Open Dialogue Message Window; Warp to Castle HQ (0, 5, 5); Warp Room -> Submap 30 at (73,15) facing 24; Warp Room -> Submap 15 at (5,0) facing 4; Engine Action #5; Engine Action #5; Dismiss Emotion Bubble (1); Warp to Castle HQ (30, 1, 1); Return Warp to Castle Base (58, 255) |
| `ev[25]` | `1 (Action / Talk)` | Story Flag 16 (bit 128) SET AND Story Flag 17 (bit 1) CLEAR AND Player within Box [62..62, 2..49] AND Condition Check #49 | Recruit Character into Active Party (9 [Futch], 16); Animate Doorway State (73, 30); Close Dialogue Sub-Window (8); Open Dialogue Message Window; Engine Action #44; Set Combat Battle BGM (15); Close Dialogue Sub-Window (10); Open Dialogue Message Window; Make obj[73] Visible (disp = 1); Show Dialogue Portrait (24, 9, 0); Make obj[73] Hidden (disp = 0); Show Dialogue Portrait (49, 2, 5); Screen Fade Transition (4, 4, 2); Warp to Castle HQ (0, 16, 3); Warp to Castle HQ (0, 10, 30); Engine Action #5; Engine Action #9; Exit to World Map (4, 3, 3); Open Dialogue Message Window; Close Dialogue Window; Warp Town -> Area 3 Map 0 Submap 10 at (30,255); Walk obj[44] to (49,8); Engine Action #5; Reset Camera Tracking (4); Exit to World Map (0, 26, 30); Engine Action #5; Open Dialogue Message Window; Exit to World Map (5, 5, 15); Warp Town -> Area 0 Map 7 Submap 3 at (30,255); Engine Action #5; Warp Room -> Submap 5 at (5,30) facing Up (North); Open Dialogue Message Window; Pan Camera (2, 30, 255); Engine Action #5; Warp Town -> Area 4 Map 5 Submap 5 at (30,3); Open Dialogue Message Window; Pan Camera (2, 30, 255); Engine Action #5; Warp to Castle HQ (4, 5, 5); Make obj[3] Visible (disp = 1); Open Dialogue Message Window; Pan Camera (1, 30, 255); Engine Action #5; Exit to World Map (4, 5, 5); Make obj[2] Visible (disp = 1); Open Dialogue Message Window; Pan Camera (1, 30, 255); Engine Action #5; Engine Action #5; Exit to World Map (5, 5, 60); Warp to Castle HQ (0, 7, 3); Dismiss Emotion Bubble (255); Engine Action #5; Engine Action #6; Exit to World Map (5, 5, 65); Warp Town -> Area 0 Map 7 Submap 3 at (30,255); Walk obj[46] to (1,8); Warp Room -> Submap 1 at (9,2) facing 10; Set Special Scene BGM (84); Open Dialogue Message Window; Screen Fade Transition (3, 10, 2); Warp Town -> Area 9 Map 71 Submap 84 at (0,9); Warp to Castle HQ (9, 3, 47); Engine Action #5; Open Dialogue Message Window; Exit to World Map (4, 2, 3); Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (45); Engine Action #39; Return Warp to Castle Base (117, 0); Open Dialogue Message Window; Engine Action #102; Open Dialogue Message Window; Engine Action #9; Change Portrait Expression (1); Engine Action #58 |
| `ev[26]` | `1 (Action / Talk)` | Story Flag 17 (bit 1) SET AND Story Flag 17 (bit 2) CLEAR AND Player within Box [58..66, 2..77] AND Condition Check #78 AND Story Flag 0 (mask 255) SET | Recruit Character into Active Party (43 [Ayda], 0); Exit to World Map (55, 0, 62); Engine Action #80; Reset Camera Tracking (44); Display Chapter Text (0); Engine Action #5; Engine Action #5; Set Combat Battle BGM (15); Close Dialogue Sub-Window (10); Open Dialogue Message Window; Teleport obj[73] to (15,24); Engine Action #9; Open Dialogue Message Window; Turn obj[73] facing 15; Close Dialogue Sub-Window (10); Open Dialogue Message Window; Set Entity Movement Speed (73, 15); Set Entity Movement Speed (2, 5); Engine Action #9; Exit to World Map (5, 0, 25); Dismiss Emotion Bubble (255); Engine Action #5; Screen Fade Transition (4, 4, 5); Dismiss Emotion Bubble (2); Warp to Castle HQ (0, 0, 5); Engine Action #90; Warp Town -> Area 0 Map 5 Submap 15 at (30,255); Walk obj[73] to (15,24); Screen Fade Transition (0, 50, 5); Screen Fade Transition (5, 30, 4); Engine Action #5; Warp Room -> Submap 5 at (5,3) facing 25; Dismiss Emotion Bubble (1); Screen Fade Transition (1, 9, 29); Engine Action #5; Engine Action #9; Change Portrait Expression (2); Engine Action #58 |
| `ev[27]` | `1 (Action / Talk)` | Story Flag 18 (bit 4) SET AND Story Flag 18 (bit 8) CLEAR AND Player within Box [50..74, 2..98] AND Condition Check #99 AND Story Flag 1 (mask 255) SET | Recruit Character into Active Party (46 [Oulan], 2); Screen Fade Transition (62, 80, 0); Screen Fade Transition (3, 10, 0); Teleport obj[43] to (0,4); Set Render Priority (pri) (0, 62); Mark Chest Looted (Byte 8, Bit 5); Screen Fade Transition (4, 4, 0); Display Dialogue Box [Bank: 30, MsgID: 46]; Warp Town -> Area 9 Map 62 Submap 97 at (0,9); Warp to Castle HQ (9, 1, 47); Engine Action #5; Engine Action #9; Exit to World Map (5, 1, 2); Dismiss Emotion Bubble (24); Screen Fade Transition (1, 0, 24); Engine Action #9; Warp Room -> Submap 24 at (10,1) facing Up (North); Close Dialogue Sub-Window (9); Warp Room -> Submap 24 at (10,1) facing 4; Close Dialogue Sub-Window (9); Warp Room -> Submap 49 at (2,5) facing 9; Exit to World Map (5, 1, 25); Dismiss Emotion Bubble (255); Engine Action #5; Screen Fade Transition (3, 0, 4); Engine Action #5; Pan Camera (2, 1, 0); Dismiss Emotion Bubble (255); Walk obj[24] to (10,1); Engine Action #6; Engine Action #5; Screen Fade Transition (4, 5, 1); Reset Camera Tracking (2); Branch on Choice (1, 10); Dismiss Emotion Bubble (1); Screen Fade Transition (2, 9, 62); Teleport obj[84] to (32,38); Dismiss Character to Castle Base (32 [Miklotov]); Open Save Crystal Menu (MSaveInit); Engine Action #62; Open Dialogue Message Window; Warp Map Transition (9, 18, 8, 58, 255) |
| `ev[28]` | `1 (Action / Talk)` | Story Flag 18 (bit 8) SET AND Story Flag 18 (bit 16) CLEAR AND Player within Box [51..73, 2..99] AND Condition Check #100 AND Story Flag 0 (mask 255) SET | Recruit Character into Active Party (33 [Camus], 1); Display Speaker Name Box (0); Warp Room -> Submap 1 at (4,5) facing West (Left); Warp to Castle HQ (2, 0, 5); Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (5); Open Dialogue Message Window; Warp to Castle HQ (0, 5, 5); Warp Room -> Submap 30 at (73,15) facing 24; Warp Room -> Submap 9 at (5,1) facing 4; Engine Action #5; Engine Action #5; Show Dialogue Portrait (0, 3, 30); Warp Room -> Submap 5 at (0,4) facing 4; Warp Room -> Submap 30 at (34,58) facing 255 |
| `ev[29]` | `1 (Action / Talk)` | Story Flag 18 (bit 8) SET AND Story Flag 18 (bit 16) CLEAR AND Player within Box [58..66, 2..65] AND Condition Check #66 AND Story Flag 1 (mask 255) SET | Recruit Character into Active Party (46 [Oulan], 36); Animate Doorway State (2, 9); Engine Action #62; Teleport obj[0] to (9,3); Engine Action #9; Warp Room -> Submap 10 at (60,68) facing West (Left); Screen Fade Transition (3, 10, 1); Teleport obj[101] to (9,8); Open Shop Menu #4 (Type: 0); Launch Tactical War Battle (8); Set Render Priority (pri) (0, 62); Engine Action #54; Reset Camera Tracking (101); Pan Camera (0, 101, 1); Warp Room -> Submap 8 at (1,7) facing 5; Engine Action #9; Exit to World Map (4, 5, 15); Warp Room -> Submap 5 at (15,30) facing 24; Engine Action #9; Warp Room -> Submap 73 at (15,24) facing 8; Warp Room -> Submap 73 at (15,24) facing 9; Warp Room -> Submap 73 at (15,24) facing 8; Warp Room -> Submap 73 at (15,24) facing 9; Warp Room -> Submap 49 at (2,5) facing 8; Exit to World Map (4, 5, 15); Open Dialogue Message Window; Warp Room -> Submap 15 at (30,255) facing 254; Engine Action #5; Engine Action #9; Exit to World Map (4, 5, 25); Pan Camera (1, 30, 255); Walk obj[24] to (8,1); Place Scenery Structure (73); Show Dialogue Portrait (24, 9, 1); Animate Door Open; Set Combat Battle BGM (15); Close Dialogue Sub-Window (8); Warp Room -> Submap 73 at (15,24) facing 9; Warp Room -> Submap 5 at (9,4) facing East (Right); Engine Action #5; Show Dialogue Portrait (7, 1, 5); Dismiss Emotion Bubble (30); Close Dialogue Sub-Window (9); Warp Room -> Submap 73 at (15,24) facing 8; Warp Room -> Submap 73 at (15,24) facing 9; Warp Room -> Submap 73 at (15,24) facing 9; Warp Room -> Submap 101 at (9,8) facing 5; Engine Action #9; Engine Action #5; Screen Fade Transition (2, 0, 5); Engine Action #5; Dismiss Emotion Bubble (46); Warp Town -> Area 22 Map 62 Submap 48 at (89,22); Warp Town -> Area 0 Map 0 Submap 22 at (1,9); Teleport obj[73] to (60,89); Set Story Flag (5, 89); Set Story Flag (5, 89); Set Story Flag (2, 1); Set Object Direction (2, 10); Open Dialogue Message Window; Load Sound Bank into Memory (1, 8); Warp to Castle HQ (73, 30, 72); Open Dialogue Message Window; Reset Camera Tracking (73); Set Entity Movement Speed (101, 0); Engine Action #176; Load Sound Bank into Memory (1, 8); Engine Action #6; Set Combat Battle BGM (12); Load Sound Bank into Memory (0, 8); Engine Action #89; Set Story Flag (5, 89); Set Story Flag (5, 101); Warp Room -> Submap 89 at (22,2) facing Up (North); Engine Action #89; Set Story Flag (5, 89); Set Story Flag (5, 73); Show Dialogue Portrait (46, 3, 9); Warp Town -> Area 0 Map 9 Submap 1 at (22,47); Engine Action #5; Engine Action #9; Engine Action #5; Engine Action #5; Warp Room -> Submap 5 at (15,30) facing 24; Reset Camera Tracking (1); Execute Choice Result (36); Warp Room -> Submap 30 at (24,10) facing West (Left); Set Story Flag (54, 0); Warp Room -> Submap 8 at (1,23) facing 73; Show Dialogue Portrait (24, 10, 1); Close Dialogue Sub-Window (73); Show Dialogue Portrait (24, 8, 1); Clear Dialogue Sub-Window; Engine Action #5; Screen Fade Transition (5, 10, 3); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Dismiss Emotion Bubble (46); Warp Town -> Area 23 Map 60 Submap 50 at (89,23); Warp Town -> Area 0 Map 0 Submap 23 at (1,10); Teleport obj[89] to (23,5); Engine Action #89; Open Dialogue Sub-Window (5); Engine Action #89; Open Dialogue Sub-Window (2); Warp Room -> Submap 70 at (73,10) facing 72; Warp Room -> Submap 6 at (73,12) facing 72; Open Dialogue Message Window; Reset Camera Tracking (73); Place Scenery Structure (101); Open Dialogue Message Window; Engine Action #177; Engine Action #89; Open Dialogue Sub-Window (5); Engine Action #89; Open Dialogue Sub-Window (5); Engine Action #89; Open Dialogue Sub-Window (2); Warp Town -> Area 89 Map 23 Submap 5 at (89,23); Engine Action #5; Set Combat Battle BGM (15); Make obj[3] Hidden (disp = 0); Screen Fade Transition (3, 0, 10); Warp Room -> Submap 47 at (5,10) facing 5; Engine Action #5; Warp Room -> Submap 5 at (15,30) facing 24; Screen Fade Transition (1, 26, 73); Show Dialogue Portrait (24, 9, 1); Fade Out to Black (5); Screen Fade Transition (5, 15, 3); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 24, 10); Warp Room -> Submap 5 at (0,5) facing 15; Warp Town -> Area 0 Map 5 Submap 5 at (0,0); Dismiss Emotion Bubble (46); Engine Action #115; Return to Previous Memory Map (35); Dismiss Character to Castle Base (32 [Miklotov]); Dismiss Emotion Bubble (84); Warp Map Transition (31, 84, 33, 30, 84); Return to Previous Memory Map (31); Teleport obj[5] to (0,0); Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 101, 4); Engine Action #6; Engine Action #5; Open Dialogue Message Window; Warp Town -> Area 0 Map 5 Submap 3 at (1,0); Engine Action #5; Warp to Castle HQ (3, 0, 5); Warp to Castle HQ (0, 0, 5); Warp to Castle HQ (30, 89, 0); Warp Town -> Area 8 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Engine Action #89; Open Dialogue Message Window; Warp Town -> Area 9 Map 5 Submap 0 at (6,2); Dismiss Emotion Bubble (89); Open Dialogue Message Window; Warp Town -> Area 10 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Dismiss Emotion Bubble (2); Warp Room -> Submap 5 at (0,0) facing South (Down); Engine Action #5; Show Dialogue Portrait (0, 0, 30); Set Combat Battle BGM (15); Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 101, 4); Engine Action #6; Engine Action #5; Open Dialogue Message Window; Warp Town -> Area 0 Map 5 Submap 3 at (1,0); Engine Action #5; Warp to Castle HQ (3, 0, 5); Warp to Castle HQ (0, 0, 5); Warp to Castle HQ (30, 89, 0); Warp Town -> Area 8 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Engine Action #89; Open Dialogue Message Window; Warp Town -> Area 9 Map 5 Submap 0 at (6,2); Dismiss Emotion Bubble (89); Open Dialogue Message Window; Warp Town -> Area 10 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Dismiss Emotion Bubble (2); Warp Room -> Submap 5 at (0,0) facing South (Down); Engine Action #5; Show Dialogue Portrait (0, 0, 30); Engine Action #5; Open Dialogue Message Window; Engine Action #5; Screen Fade Transition (2, 0, 5); Engine Action #5; Warp Room -> Submap 30 at (5,8) facing 5; Show Dialogue Portrait (6, 1, 30); Close Dialogue Sub-Window (8); Warp Room -> Submap 5 at (8,2) facing South (Down); Engine Action #5; Branch on Choice (0, 0); Engine Action #5; Engine Action #5; Warp to Castle HQ (0, 5, 20); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 24, 8); Warp Room -> Submap 73 at (30,24) facing 12; Warp Room -> Submap 5 at (12,4) facing 4; Engine Action #5; Show Dialogue Portrait (2, 2, 5); Show Dialogue Portrait (30, 24, 12); Warp Room -> Submap 46 at (2,24) facing 69; Set Entity Movement Speed (89, 24); Warp Town -> Area 0 Map 0 Submap 24 at (1,12); Engine Action #9; Open Dialogue Message Window; Warp Room -> Submap 5 at (9,3) facing South (Down); Dismiss Emotion Bubble (5); Screen Fade Transition (5, 15, 3); Open Dialogue Message Window; Dismiss Emotion Bubble (24); Engine Action #9; Warp Room -> Submap 5 at (13,4) facing 5; Engine Action #5; Show Dialogue Portrait (2, 2, 5); Show Dialogue Portrait (30, 24, 13); Warp Room -> Submap 46 at (2,25) facing 69; Engine Action #52; Engine Action #89; Clear Dialogue Sub-Window; Warp Town -> Area 0 Map 0 Submap 25 at (1,13); Engine Action #9; Open Dialogue Message Window; Warp Town -> Area 47 Map 36 Submap 2 at (54,1); Exit to World Map (24, 8, 1); Start Boss Battle #5 (BGM: 8); Exit to World Map (5, 3, 3); Warp Room -> Submap 2 at (3,30) facing West (Left); Reset Camera Tracking (24); Engine Action #9; Warp to Castle HQ (0, 73, 30); Engine Action #54; Warp Room -> Submap 101 at (9,8) facing 11; Warp Town -> Area 2 Map 150 Submap 3 at (0,0); Engine Action #54; Open Dialogue Message Window; Animate Doorway State (74, 1); Wait for Audio / Window Sync (3); Engine Action #9; Display Speaker Name Box (16); Warp Map Transition (3, 0, 16, 11, 58) |
| `ev[30]` | `128 (Loop)` | Story Flag 18 (bit 8) SET AND Story Flag 18 (bit 16) CLEAR AND Inventory Holds Item #8 [Fire Wall] | Set Combat Battle BGM (60); Display Chapter Text (1); Engine Action #9; Engine Action #5; Toggle Random Encounters (8) |
| `ev[31]` | `128 (Loop)` | Story Flag 18 (bit 8) SET AND Story Flag 18 (bit 16) CLEAR AND Inventory Holds Item #1 [Medicine] | Open Dialogue Message Window; Screen Fade Transition (49, 3, 5); Screen Fade Transition (4, 4, 1); Display Speaker Name Box (30); Engine Action #5; Open Dialogue Message Window; Engine Action #5; Make obj[2] Visible (disp = 1); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Play Sound Effect (SE) (2); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp Room -> Submap 30 at (255,254) facing 5; Engine Action #9; Engine Action #5; Full Rest & Healing (Restore HP/MP); Warp Town -> Area 0 Map 5 Submap 5 at (0,0); Dismiss Emotion Bubble (255); Walk obj[37] to (1,255) |
| `ev[32]` | `128 (Loop)` | Story Flag 18 (bit 8) SET AND Story Flag 18 (bit 16) CLEAR AND Character #1 Level >= 7 AND Condition Check #128 | Engine Action #5; Engine Action #9; Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (5); Screen Fade Transition (5, 10, 0); Open Dialogue Message Window; Dismiss Emotion Bubble (36); Engine Action #128 |
| `ev[33]` | `128 (Loop)` | Story Flag 18 (bit 8) SET AND Story Flag 18 (bit 16) CLEAR AND Inventory Holds Item #2 [Mega Medicine] | Engine Action #5; Execute Choice Result (4); Engine Action #5; Engine Action #5; Show Dialogue Portrait (3, 2, 5); Show Dialogue Portrait (30, 46, 2); Return to Previous Memory Map (55); Engine Action #61; Engine Action #89; Return to Previous Memory Map (2); Open Dialogue Message Window; Open Dialogue Message Window; Return to Previous Memory Map (1); Execute Choice Result (9); Open Dialogue Message Window; Exit to World Map (47, 37, 2) |
| `ev[34]` | `128 (Loop)` | Story Flag 18 (bit 8) SET AND Story Flag 18 (bit 16) CLEAR AND Inventory Holds Item #2 [Mega Medicine] | Set Combat Battle BGM (20); Engine Action #5; Dismiss Dialogue Portrait; Exit to World Map (5, 5, 15); Warp Town -> Area 2 Map 5 Submap 15 at (30,46); Warp Town -> Area 28 Map 69 Submap 61 at (89,28); Warp Town -> Area 0 Map 0 Submap 28 at (1,16); Engine Action #9; Open Dialogue Message Window; Reset Camera Tracking (47); Toggle Random Encounters (2) |
| `ev[35]` | `128 (Loop)` | Story Flag 18 (bit 8) SET AND Story Flag 18 (bit 16) CLEAR AND Inventory Holds Item #2 [Mega Medicine] | Set Combat Battle BGM (40); Engine Action #5; Branch on Choice (4, 5); Engine Action #5; Show Dialogue Portrait (3, 2, 5); Show Dialogue Portrait (30, 46, 2); Warp Map Transition (55, 58, 89, 32, 2); Open Dialogue Message Window; Open Dialogue Message Window; Warp Map Transition (1, 20, 9, 0, 16); Teleport obj[37] to (2,255) |
| `ev[36]` | `128 (Loop)` | Story Flag 18 (bit 8) SET AND Story Flag 18 (bit 16) CLEAR AND Inventory Holds Item #2 [Mega Medicine] | Set Combat Battle BGM (60); Engine Action #5; Display Speaker Name Box (4); Engine Action #5; Engine Action #5; Show Dialogue Portrait (3, 2, 5); Show Dialogue Portrait (30, 46, 2); Dismiss Emotion Bubble (55); Engine Action #52; Engine Action #89; Dismiss Emotion Bubble (2); Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (1); Display Speaker Name Box (9); Open Dialogue Message Window; Warp Map Transition (47, 37, 2, 255, 254) |
| `ev[37]` | `128 (Loop)` | Story Flag 18 (bit 8) SET AND Story Flag 18 (bit 16) CLEAR AND Inventory Holds Item #2 [Mega Medicine] | Set Combat Battle BGM (80); Engine Action #5; Animate Door Open; Exit to World Map (5, 5, 15); Warp Town -> Area 2 Map 5 Submap 15 at (30,46); Warp Town -> Area 26 Map 69 Submap 55 at (89,26); Warp Town -> Area 0 Map 0 Submap 26 at (1,14); Engine Action #9; Open Dialogue Message Window; Animate Doorway State (47, 37); Warp Town -> Area 255 Map 254 Submap 255 at (254,204) |
| `ev[38]` | `128 (Loop)` | Story Flag 18 (bit 8) SET AND Story Flag 18 (bit 16) CLEAR AND Inventory Holds Item #2 [Mega Medicine] | Set Combat Battle BGM (100); Engine Action #5; Change Portrait Expression (4); Engine Action #5; Engine Action #5; Show Dialogue Portrait (3, 2, 5); Show Dialogue Portrait (30, 46, 2); Display Emotion Bubble (55, 49); Engine Action #89; Display Emotion Bubble (2, 0); Open Dialogue Message Window; Display Emotion Bubble (1, 17); Engine Action #9; Open Dialogue Message Window; Engine Action #128; Teleport obj[37] to (2,255) |
| `ev[39]` | `128 (Loop)` | Story Flag 18 (bit 8) SET AND Story Flag 18 (bit 16) CLEAR AND Inventory Holds Item #2 [Mega Medicine] | Set Combat Battle BGM (120); Engine Action #5; Show Dialogue Portrait (4, 5, 5); Show Dialogue Portrait (2, 2, 5); Show Dialogue Portrait (30, 46, 2); Fade Out to Black (69); Engine Action #58; Engine Action #89; Fade Out to Black (2); Open Dialogue Message Window; Open Dialogue Message Window; Fade Out to Black (1); Show Dialogue Portrait (9, 0, 1); Teleport obj[37] to (2,255) |
| `ev[40]` | `128 (Loop)` | Story Flag 18 (bit 8) SET AND Story Flag 18 (bit 16) CLEAR AND Inventory Holds Item #2 [Mega Medicine] | Set Combat Battle BGM (140); Engine Action #5; Display Choice Selection (4, 5); Engine Action #5; Show Dialogue Portrait (3, 2, 5); Show Dialogue Portrait (30, 46, 2); Warp Room -> Submap 55 at (55,89); Warp Room -> Submap 2 at (0,0); Warp Room -> Submap 1 at (19,9); Open Dialogue Message Window; Warp Town -> Area 47 Map 37 Submap 2 at (89,31); Engine Action #5; Engine Action #89; Warp Room -> Submap 5 at (36,4) |
| `ev[41]` | `128 (Loop)` | Story Flag 18 (bit 8) SET AND Story Flag 18 (bit 16) CLEAR AND Inventory Holds Item #64 [Recipe #33] | Warp Room -> Submap 0 at (8,0); Toggle Random Encounters (64) |
| `ev[42]` | `128 (Loop)` | Story Flag 18 (bit 8) SET AND Story Flag 18 (bit 16) CLEAR AND Story Flag 0 (bit 1) SET | Set Combat Battle BGM (118); Jump to Bytecode Offset (0, 178); Screen Fade Transition (0, 1, 255) |
| `ev[43]` | `128 (Loop)` | Story Flag 18 (bit 8) SET AND Story Flag 18 (bit 16) CLEAR AND Story Flag 0 (bit 2) SET | Set Combat Battle BGM (118); Jump to Bytecode Offset (0, 179); Screen Fade Transition (0, 2, 255) |
| `ev[44]` | `128 (Loop)` | Story Flag 18 (bit 8) SET AND Story Flag 18 (bit 16) CLEAR AND Story Flag 0 (bit 4) SET | Set Combat Battle BGM (118); Jump to Bytecode Offset (0, 180); Screen Fade Transition (0, 4, 255) |
| `ev[45]` | `128 (Loop)` | Story Flag 18 (bit 8) SET AND Story Flag 18 (bit 16) CLEAR AND Story Flag 0 (bit 8) SET | Set Combat Battle BGM (118); Jump to Bytecode Offset (0, 181); Screen Fade Transition (0, 8, 255) |
| `ev[46]` | `128 (Loop)` | Story Flag 18 (bit 8) SET AND Story Flag 18 (bit 16) CLEAR AND Story Flag 0 (bit 16) SET | Set Combat Battle BGM (118); Jump to Bytecode Offset (0, 182); Screen Fade Transition (0, 16, 255) |
| `ev[47]` | `128 (Loop)` | Story Flag 18 (bit 8) SET AND Story Flag 18 (bit 16) CLEAR AND Story Flag 0 (bit 32) SET | Set Combat Battle BGM (118); Jump to Bytecode Offset (0, 183); Screen Fade Transition (0, 32, 255) |
| `ev[48]` | `128 (Loop)` | Story Flag 18 (bit 8) SET AND Story Flag 18 (bit 16) CLEAR AND Story Flag 0 (bit 64) SET | Set Combat Battle BGM (118); Jump to Bytecode Offset (0, 184); Screen Fade Transition (0, 64, 255) |
| `ev[49]` | `128 (Loop)` | Story Flag 18 (bit 8) SET AND Story Flag 18 (bit 16) CLEAR AND Story Flag 0 (bit 128) SET | Set Combat Battle BGM (118); Jump to Bytecode Offset (0, 185); Screen Fade Transition (0, 128, 255) |
| `ev[50]` | `1 (Action / Talk)` | Target Inspected is obj[34] | Open Dialogue Sub-Window (4); Remove Character from Active Party (255) |
| `ev[51]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) CLEAR AND Target Inspected is obj[34] | Open Dialogue Sub-Window (6); Remove Character from Active Party (255) |
| `ev[52]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) SET AND Target Inspected is obj[34] | Open Dialogue Sub-Window (7); Remove Character from Active Party (255) |
| `ev[53]` | `1 (Action / Talk)` | Target Inspected is obj[35] | Open Dialogue Sub-Window (4); Load Sound Bank into Memory (255, 254) |
| `ev[54]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) CLEAR AND Target Inspected is obj[35] | Open Dialogue Sub-Window (6); Load Sound Bank into Memory (255, 254) |
| `ev[55]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) SET AND Target Inspected is obj[35] | Open Dialogue Sub-Window (7); Load Sound Bank into Memory (255, 254) |
| `ev[56]` | `1 (Action / Talk)` | Target Inspected is obj[36] | Open Dialogue Sub-Window (4); Set Combat Battle BGM (255) |
| `ev[57]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) CLEAR AND Target Inspected is obj[36] | Open Dialogue Sub-Window (6); Set Combat Battle BGM (255) |
| `ev[58]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) SET AND Target Inspected is obj[36] | Open Dialogue Sub-Window (7); Set Combat Battle BGM (255) |
| `ev[59]` | `1 (Action / Talk)` | Target Inspected is obj[37] | Open Dialogue Sub-Window (4); Set Special Scene BGM (255) |
| `ev[60]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) CLEAR AND Target Inspected is obj[37] | Open Dialogue Sub-Window (6); Set Special Scene BGM (255) |
| `ev[61]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) SET AND Target Inspected is obj[37] | Open Dialogue Sub-Window (7); Set Special Scene BGM (255) |
| `ev[62]` | `1 (Action / Talk)` | Target Inspected is obj[38] | Open Dialogue Sub-Window (4); Full Rest & Healing (Restore HP/MP) |
| `ev[63]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) CLEAR AND Target Inspected is obj[38] | Open Dialogue Sub-Window (6); Full Rest & Healing (Restore HP/MP) |
| `ev[64]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) SET AND Target Inspected is obj[38] | Open Dialogue Sub-Window (7); Full Rest & Healing (Restore HP/MP) |
| `ev[65]` | `1 (Action / Talk)` | Target Inspected is obj[39] | Open Dialogue Sub-Window (4); Full Rest & Healing (Restore HP/MP) |
| `ev[66]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) CLEAR AND Target Inspected is obj[39] | Open Dialogue Sub-Window (6); Full Rest & Healing (Restore HP/MP) |
| `ev[67]` | `1 (Action / Talk)` | Story Flag 18 (bit 128) SET AND Target Inspected is obj[39] | Open Dialogue Sub-Window (7); Full Rest & Healing (Restore HP/MP) |
| `ev[68]` | `1 (Action / Talk)` | Target Inspected is obj[40] | Open Dialogue Sub-Window (5); Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[69]` | `1 (Action / Talk)` | Target Inspected is obj[41] | Open Dialogue Sub-Window (5); Warp Town -> Area 255 Map 254 Submap 255 at (254,204) |
| `ev[70]` | `1 (Action / Talk)` | Target Inspected is obj[42] | Open Dialogue Sub-Window (5); Warp to Castle HQ (255, 254, 255) |
| `ev[71]` | `1 (Action / Talk)` | Target Inspected is obj[43] | Open Dialogue Sub-Window (5); Exit to World Map (255, 254, 255) |
| `ev[72]` | `1 (Action / Talk)` | Target Inspected is obj[44] | Open Dialogue Sub-Window (5); Engine Action #5 |
| `ev[73]` | `1 (Action / Talk)` | Target Inspected is obj[45] | Open Dialogue Sub-Window (5); Engine Action #6 |
| `ev[74]` | `1 (Action / Talk)` | Target Inspected is obj[46] | Open Dialogue Sub-Window (5); Pan Camera (255, 254, 255) |
| `ev[75]` | `1 (Action / Talk)` | Target Inspected is obj[47] | Open Dialogue Sub-Window (5); Reset Camera Tracking (255) |
| `ev[76]` | `1 (Action / Talk)` | Target Inspected is obj[48] | Open Dialogue Sub-Window (5); Engine Action #9 |
| `ev[77]` | `1 (Action / Talk)` | Target Inspected is obj[49] | Open Dialogue Sub-Window (5); Screen Fade Transition (255, 254, 255) |
| `ev[78]` | `1 (Action / Talk)` | Target Inspected is obj[50] | Open Dialogue Sub-Window (5); Close Dialogue Window |
| `ev[79]` | `1 (Action / Talk)` | Target Inspected is obj[51] | Open Dialogue Sub-Window (5); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[80]` | `1 (Action / Talk)` | Target Inspected is obj[52] | Open Dialogue Sub-Window (5); Place Scenery Structure (255) |
| `ev[81]` | `1 (Action / Talk)` | Target Inspected is obj[53] | Open Dialogue Sub-Window (5); Animate Door Open |
| `ev[82]` | `1 (Action / Talk)` | Target Inspected is obj[54] | Open Dialogue Sub-Window (5); Show Dialogue Portrait (255, 254, 255) |
| `ev[83]` | `1 (Action / Talk)` | Target Inspected is obj[55] | Open Dialogue Sub-Window (5); Dismiss Dialogue Portrait |
| `ev[84]` | `2 (Map Init)` | Story Flag 18 (bit 8) SET AND Story Flag 18 (bit 16) CLEAR | Make obj[2] Hidden (disp = 0); Engine Action #9; Engine Action #62; Teleport obj[3] to (9,1); Open Dialogue Message Window; Engine Action #9; Teleport Object to Coordinates |
| `ev[85]` | `2 (Map Init)` | Story Flag 16 (bit 2) SET AND Story Flag 16 (bit 4) CLEAR | Make obj[2] Hidden (disp = 0); Reset Camera Tracking (62); Open Shop Menu #8 (Type: 3); Open Dialogue Message Window; Open Dialogue Message Window; Reset Camera Tracking (2); Screen Fade Transition (59, 42, 3); Screen Fade Transition (0, 0, 10); Teleport Object to Coordinates |
| `ev[86]` | `2 (Map Init)` | Story Flag 16 (bit 8) SET AND Story Flag 16 (bit 32) CLEAR | Make obj[2] Hidden (disp = 0); Reset Camera Tracking (62); Open Shop Menu #8 (Type: 3); Open Dialogue Message Window; Open Dialogue Message Window; Reset Camera Tracking (2); Screen Fade Transition (59, 42, 3); Screen Fade Transition (0, 0, 10); Teleport Object to Coordinates |
| `ev[87]` | `2 (Map Init)` | Story Flag 16 (bit 16) SET AND Story Flag 16 (bit 32) CLEAR | Make obj[2] Hidden (disp = 0); Engine Action #9; Engine Action #62; Teleport obj[3] to (9,1); Open Dialogue Message Window; Engine Action #9; Teleport Object to Coordinates |

---



## Location Map: `vi06`

- **Master Map Container**: `vi06.json`
- **Submap Layer Files**: vi06_00.json
- **Collision Grid Files**: vi06_map_00.json
- **Sprite Animation Bundles**: vi06_00_obj.json
- **Submap Room Count**: 3

### Submap Layer `vi06_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `15`, Rate: `8`)
- **Entity Count (`okaz`)**: `34` Objects | **Script Count (`evkaz`)**: `51` Scripts

#### Complete Physical Entity Inventory (34 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | Treasure Chest | **Opened Chest** | `0` | `(29, 32)` | `0x0` | East (Right) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | Treasure Chest | **Closed Chest (Unopened)** | `0` | `(29, 32)` | `0x0` | Up (North) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | Treasure Chest | **Opened Chest** | `0` | `(136, 188)` | `0x0` | East (Right) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | Treasure Chest | **Closed Chest (Unopened)** | `0` | `(136, 188)` | `0x0` | Up (North) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[04]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[15]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[16]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[17]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[18]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[19]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[20]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[21]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[22]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[23]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[24]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[25]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[26]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[27]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[28]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[29]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[30]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[31]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[32]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[33]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Treasure Chest)**: Placed at tile `(29, 32)`. Initial state is Open. Controlled by map loot bitflags.
- **`obj[01]` (Treasure Chest)**: Placed at tile `(29, 32)`. Initial state is Closed (Unopened). Controlled by map loot bitflags.
- **`obj[02]` (Treasure Chest)**: Placed at tile `(136, 188)`. Initial state is Open. Controlled by map loot bitflags.
- **`obj[03]` (Treasure Chest)**: Placed at tile `(136, 188)`. Initial state is Closed (Unopened). Controlled by map loot bitflags.
- **`obj[04]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[05]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[06]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[07]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[08]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[09]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[10]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[11]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[12]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[13]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[14]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[15]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[16]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[17]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[18]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[19]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[20]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[21]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[22]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[23]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[24]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[25]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[26]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[27]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[28]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[29]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[30]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[31]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[32]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[33]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.


#### Complete Bytecode Script Catalog (51 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 20 (bit 2) SET | Open Choice Selection Menu (1, 255) |
| `ev[01]` | `2 (Map Init)` | Treasure Byte 4 Bit 1 FRESH (Unopened) | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[02]` | `2 (Map Init)` | Treasure Byte 4 Bit 1 LOOTED | Open Dialogue Message Window; Engine Action #9 |
| `ev[03]` | `2 (Map Init)` | Treasure Byte 4 Bit 2 FRESH (Unopened) | Open Dialogue Message Window; Screen Fade Transition (255, 254, 255) |
| `ev[04]` | `2 (Map Init)` | Treasure Byte 4 Bit 2 LOOTED | Open Dialogue Message Window; Close Dialogue Window |
| `ev[05]` | `1 (Action / Talk)` | Player within Box [127..133, 2..62] AND Condition Check #63 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 138]; Warp Map Transition (255, 254, 204, 204, 204) |
| `ev[06]` | `1 (Action / Talk)` | Player within Box [136..140, 2..35] AND Condition Check #36 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 130]; Engine Action #66 |
| `ev[07]` | `1 (Action / Talk)` | Player within Box [71..72, 2..27] AND Condition Check #31 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 40]; Warp Room -> Submap 255 at (254,204) |
| `ev[08]` | `1 (Action / Talk)` | Player within Box [42..43, 2..28] AND Condition Check #32 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 74]; Display Chapter Text (255) |
| `ev[09]` | `1 (Action / Talk)` | Player within Box [30..30, 2..24] AND Condition Check #25 AND Story Flag 1 (mask 255) SET | Close Dialogue Window; Warp Town -> Area 2 Map 40 Submap 3 at (0,3); Wait for Audio / Window Sync (1); Display Dialogue Box [Bank: 0, MsgID: 191]; Engine Action #123 |
| `ev[10]` | `1 (Action / Talk)` | Player within Box [188..189, 2..123] AND Condition Check #124 | Close Dialogue Window; Warp Town -> Area 2 Map 40 Submap 3 at (0,0); Wait for Audio / Window Sync (1); Display Dialogue Box [Bank: 0, MsgID: 30]; Dismiss Emotion Bubble (255) |
| `ev[11]` | `1 (Action / Talk)` | Player within Box [183..184, 2..124] AND Condition Check #129 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 150]; Engine Action #128 |
| `ev[12]` | `1 (Action / Talk)` | Player within Box [200..201, 2..124] AND Condition Check #129 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 76]; Engine Action #186 |
| `ev[13]` | `1 (Action / Talk)` | Player within Box [152..153, 2..126] AND Condition Check #132 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 186]; Engine Action #127 |
| `ev[14]` | `1 (Action / Talk)` | Player within Box [73..74, 2..126] AND Condition Check #132 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 36]; Dismiss Character Dialogue Portrait |
| `ev[15]` | `1 (Action / Talk)` | Player within Box [38..39, 2..122] AND Condition Check #127 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 76]; Engine Action #128 |
| `ev[16]` | `1 (Action / Talk)` | Player within Box [26..26, 2..118] AND Condition Check #119 AND Story Flag 1 (mask 255) SET | Close Dialogue Window; Warp Town -> Area 2 Map 40 Submap 3 at (0,3); Wait for Audio / Window Sync (1); Display Dialogue Box [Bank: 1, MsgID: 189]; Engine Action #195 |
| `ev[17]` | `1 (Action / Talk)` | Player within Box [73..74, 2..184] AND Condition Check #190 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 198]; Engine Action #127 |
| `ev[18]` | `1 (Action / Talk)` | Player within Box [128..132, 2..81] AND Condition Check #82 AND Story Flag 0 (mask 255) SET | Warp Room -> Submap 0 at (8,0); Warp Map Transition (3, 0, 50, 60, 255) |
| `ev[19]` | `1 (Action / Talk)` | Treasure Byte 4 Bit 1 FRESH (Unopened) AND Target Inspected is obj[8] | Recruit Character into Active Party (46 [Oulan], 0); Engine Action #9; Warp Room -> Submap 47 at (101,4) facing 7; Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (0); Exit to World Map (0, 26, 0); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,4) facing West (Left); Engine Action #51; Warp Town -> Area 255 Map 1 Submap 46 at (0,8); Warp Room -> Submap 47 at (255,2) facing 58 |
| `ev[20]` | `1 (Action / Talk)` | Treasure Byte 4 Bit 2 FRESH (Unopened) AND Target Inspected is obj[10] | Recruit Character into Active Party (46 [Oulan], 0); Close Dialogue Window; Warp Room -> Submap 47 at (101,4) facing 7; Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (0); Exit to World Map (0, 34, 0); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,4) facing Up (North); Engine Action #51; Warp Town -> Area 255 Map 1 Submap 46 at (0,10); Warp Room -> Submap 47 at (255,2) facing 58 |
| `ev[21]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Open Dialogue Sub-Window (1); Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[22]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Open Dialogue Sub-Window (1); Warp Town -> Area 255 Map 254 Submap 255 at (254,204) |
| `ev[23]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Open Dialogue Sub-Window (1); Warp to Castle HQ (255, 254, 255) |
| `ev[24]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Open Dialogue Sub-Window (1); Exit to World Map (255, 254, 255) |
| `ev[25]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Open Dialogue Sub-Window (1); Engine Action #5 |
| `ev[26]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Open Dialogue Sub-Window (1); Engine Action #6 |
| `ev[27]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Open Dialogue Sub-Window (1); Pan Camera (255, 254, 255) |
| `ev[28]` | `1 (Action / Talk)` | Target Inspected is obj[19] | Open Dialogue Sub-Window (1); Reset Camera Tracking (255) |
| `ev[29]` | `1 (Action / Talk)` | Target Inspected is obj[20] | Open Dialogue Sub-Window (1); Engine Action #9 |
| `ev[30]` | `1 (Action / Talk)` | Target Inspected is obj[21] | Open Dialogue Sub-Window (1); Screen Fade Transition (255, 254, 255) |
| `ev[31]` | `1 (Action / Talk)` | Target Inspected is obj[22] | Open Dialogue Sub-Window (1); Close Dialogue Window |
| `ev[32]` | `1 (Action / Talk)` | Target Inspected is obj[23] | Open Dialogue Sub-Window (1); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[33]` | `1 (Action / Talk)` | Target Inspected is obj[24] | Open Dialogue Sub-Window (1); Place Scenery Structure (255) |
| `ev[34]` | `1 (Action / Talk)` | Target Inspected is obj[25] | Open Dialogue Sub-Window (1); Animate Door Open |
| `ev[35]` | `1 (Action / Talk)` | Target Inspected is obj[26] | Open Dialogue Sub-Window (1); Show Dialogue Portrait (255, 254, 255) |
| `ev[36]` | `1 (Action / Talk)` | Target Inspected is obj[27] | Open Dialogue Sub-Window (1); Dismiss Dialogue Portrait |
| `ev[37]` | `1 (Action / Talk)` | Target Inspected is obj[28] | Open Dialogue Sub-Window (1); Change Portrait Expression (255) |
| `ev[38]` | `1 (Action / Talk)` | Target Inspected is obj[29] | Open Dialogue Sub-Window (1); Display Speaker Name Box (255) |
| `ev[39]` | `1 (Action / Talk)` | Target Inspected is obj[30] | Open Dialogue Sub-Window (1); Display Choice Selection (255, 254) |
| `ev[40]` | `1 (Action / Talk)` | Target Inspected is obj[31] | Open Dialogue Sub-Window (1); Branch on Choice (255, 254) |
| `ev[41]` | `1 (Action / Talk)` | Target Inspected is obj[32] | Open Dialogue Sub-Window (1); Execute Choice Result (255) |
| `ev[42]` | `1 (Action / Talk)` | Target Inspected is obj[33] | Open Dialogue Sub-Window (1); Set Story Flag (255, 254) |
| `ev[43]` | `1 (Action / Talk)` | Target Inspected is obj[34] | Open Dialogue Sub-Window (1); Open Dialogue Sub-Window (255) |
| `ev[44]` | `1 (Action / Talk)` | Target Inspected is obj[35] | Open Dialogue Sub-Window (1); Close Dialogue Sub-Window (255) |
| `ev[45]` | `1 (Action / Talk)` | Target Inspected is obj[36] | Open Dialogue Sub-Window (1); Clear Dialogue Sub-Window |
| `ev[46]` | `1 (Action / Talk)` | Target Inspected is obj[37] | Open Dialogue Sub-Window (1); Fade In from Black (255) |
| `ev[47]` | `1 (Action / Talk)` | Target Inspected is obj[38] | Open Dialogue Sub-Window (1); Fade Out to Black (255) |
| `ev[48]` | `1 (Action / Talk)` | Target Inspected is obj[39] | Open Dialogue Sub-Window (1); Display Chapter Text (255) |
| `ev[49]` | `1 (Action / Talk)` | Target Inspected is obj[40] | Open Dialogue Sub-Window (1); Display Emotion Bubble (255, 254) |
| `ev[50]` | `1 (Action / Talk)` | Target Inspected is obj[41] | Open Dialogue Sub-Window (1); Dismiss Emotion Bubble (255) |

---

### Submap Layer `vi06_01` (Index 1)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `15`, Rate: `8`)
- **Entity Count (`okaz`)**: `54` Objects | **Script Count (`evkaz`)**: `53` Scripts

#### Complete Physical Entity Inventory (54 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | Treasure Chest | **Opened Chest** | `0` | `(24, 94)` | `0x0` | East (Right) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | Treasure Chest | **Closed Chest (Unopened)** | `0` | `(24, 94)` | `0x0` | Up (North) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | Treasure Chest | **Opened Chest** | `0` | `(24, 88)` | `0x0` | East (Right) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | Treasure Chest | **Closed Chest (Unopened)** | `0` | `(24, 88)` | `0x0` | Up (North) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[04]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[15]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[16]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[17]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[18]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[19]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[20]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[21]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[22]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[23]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[24]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[25]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[26]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[27]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[28]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[29]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[30]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[31]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[32]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[33]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[34]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[35]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[36]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[37]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[38]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[39]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[40]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[41]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[42]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[43]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[44]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[45]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[46]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[47]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[48]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[49]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[50]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[51]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[52]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[53]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Treasure Chest)**: Placed at tile `(24, 94)`. Initial state is Open. Controlled by map loot bitflags.
- **`obj[01]` (Treasure Chest)**: Placed at tile `(24, 94)`. Initial state is Closed (Unopened). Controlled by map loot bitflags.
- **`obj[02]` (Treasure Chest)**: Placed at tile `(24, 88)`. Initial state is Open. Controlled by map loot bitflags.
- **`obj[03]` (Treasure Chest)**: Placed at tile `(24, 88)`. Initial state is Closed (Unopened). Controlled by map loot bitflags.
- **`obj[04]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[05]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[06]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[07]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[08]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[09]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[10]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[11]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[12]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[13]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[14]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[15]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[16]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[17]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[18]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[19]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[20]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[21]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[22]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[23]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[24]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[25]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[26]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[27]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[28]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[29]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[30]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[31]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[32]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[33]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[34]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[35]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[36]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[37]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[38]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[39]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[40]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[41]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[42]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[43]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[44]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[45]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[46]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[47]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[48]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[49]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[50]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[51]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[52]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[53]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.


#### Complete Bytecode Script Catalog (53 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Treasure Byte 4 Bit 4 FRESH (Unopened) | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[01]` | `2 (Map Init)` | Treasure Byte 4 Bit 4 LOOTED | Open Dialogue Message Window; Engine Action #9 |
| `ev[02]` | `2 (Map Init)` | Treasure Byte 4 Bit 8 FRESH (Unopened) | Open Dialogue Message Window; Screen Fade Transition (255, 254, 255) |
| `ev[03]` | `2 (Map Init)` | Treasure Byte 4 Bit 8 LOOTED | Open Dialogue Message Window; Close Dialogue Window |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [186..187, 2..195] AND Condition Check #196 | Close Dialogue Window; Warp Town -> Area 2 Map 40 Submap 3 at (0,0); Wait for Audio / Window Sync (1); Display Dialogue Box [Bank: 0, MsgID: 26]; Show Character Dialogue Portrait (255, 254, 204) |
| `ev[05]` | `1 (Action / Talk)` | Player within Box [181..182, 2..196] AND Condition Check #201 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 150]; Engine Action #202 |
| `ev[06]` | `1 (Action / Talk)` | Player within Box [152..153, 2..199] AND Condition Check #207 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 184]; Engine Action #199 |
| `ev[07]` | `1 (Action / Talk)` | Player within Box [73..74, 2..199] AND Condition Check #207 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 36]; Engine Action #199 |
| `ev[08]` | `1 (Action / Talk)` | Player within Box [38..39, 2..196] AND Condition Check #201 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 76]; Engine Action #202 |
| `ev[09]` | `1 (Action / Talk)` | Player within Box [27..33, 2..190] AND Condition Check #191 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 30]; Engine Action #158 |
| `ev[10]` | `1 (Action / Talk)` | Player within Box [28..32, 2..161] AND Condition Check #162 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 30]; Engine Action #195 |
| `ev[11]` | `1 (Action / Talk)` | Player within Box [26..27, 2..195] AND Condition Check #196 | Close Dialogue Window; Warp Town -> Area 2 Map 40 Submap 3 at (0,0); Wait for Audio / Window Sync (1); Display Dialogue Box [Bank: 1, MsgID: 184]; Display Dialogue with Speaker Name (255, 254, 204) |
| `ev[12]` | `1 (Action / Talk)` | Player within Box [184..184, 2..124] AND Condition Check #125 AND Story Flag 1 (mask 255) SET | Close Dialogue Window; Warp Town -> Area 2 Map 40 Submap 3 at (0,3); Wait for Audio / Window Sync (1); Display Dialogue Box [Bank: 1, MsgID: 29]; Engine Action #195 |
| `ev[13]` | `1 (Action / Talk)` | Player within Box [187..190, 2..122] AND Condition Check #123 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 126]; Engine Action #148 |
| `ev[14]` | `1 (Action / Talk)` | Player within Box [124..128, 2..151] AND Condition Check #152 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 188]; Engine Action #127 |
| `ev[15]` | `1 (Action / Talk)` | Player within Box [123..129, 2..67] AND Condition Check #68 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 126]; Engine Action #40 |
| `ev[16]` | `1 (Action / Talk)` | Player within Box [123..129, 2..43] AND Condition Check #44 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 126]; Load Sound Bank into Memory (255, 254) |
| `ev[17]` | `1 (Action / Talk)` | Player within Box [122..122, 2..30] AND Condition Check #31 AND Story Flag 1 (mask 255) SET | Close Dialogue Window; Warp Town -> Area 2 Map 40 Submap 3 at (0,3); Wait for Audio / Window Sync (1); Display Dialogue Box [Bank: 1, MsgID: 29]; Open Shop Menu #254 (Type: 255) |
| `ev[18]` | `1 (Action / Talk)` | Player within Box [26..27, 2..43] AND Condition Check #44 | Close Dialogue Window; Warp Town -> Area 2 Map 40 Submap 3 at (0,0); Wait for Audio / Window Sync (1); Display Dialogue Box [Bank: 1, MsgID: 122]; Launch Tactical War Battle (255) |
| `ev[19]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) CLEAR AND Player within Box [38..39, 2..44] AND Condition Check #49 AND Story Flag 3 (mask 255) SET | Warp Room -> Submap 0 at (8,6); Warp Map Transition (3, 0, 3, 24, 255) |
| `ev[20]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Player within Box [38..39, 2..44] AND Condition Check #49 AND Story Flag 3 (mask 255) SET | Warp Room -> Submap 0 at (8,6); Warp Map Transition (3, 1, 3, 24, 255) |
| `ev[21]` | `1 (Action / Talk)` | Treasure Byte 4 Bit 4 FRESH (Unopened) AND Target Inspected is obj[8] | Recruit Character into Active Party (46 [Oulan], 0); Engine Action #9; Warp Room -> Submap 47 at (101,4) facing 7; Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (0); Exit to World Map (0, 59, 16); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,4) facing 4; Engine Action #51; Warp Town -> Area 255 Map 1 Submap 46 at (0,8); Warp Room -> Submap 47 at (255,2) facing 58 |
| `ev[22]` | `1 (Action / Talk)` | Treasure Byte 4 Bit 8 FRESH (Unopened) AND Target Inspected is obj[10] | Recruit Character into Active Party (46 [Oulan], 0); Close Dialogue Window; Warp Room -> Submap 47 at (101,4) facing 7; Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (0); Exit to World Map (0, 23, 0); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,4) facing 8; Engine Action #51; Warp Town -> Area 255 Map 1 Submap 46 at (0,10); Warp Room -> Submap 47 at (255,2) facing 58 |
| `ev[23]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Open Dialogue Sub-Window (1); Warp Room -> Submap 255 at (254,255) |
| `ev[24]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Open Dialogue Sub-Window (1); Warp Map Transition (255, 254, 255, 254, 204) |
| `ev[25]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Open Dialogue Sub-Window (1); Return to Previous Memory Map (255) |
| `ev[26]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Open Dialogue Sub-Window (1); Return Warp to Castle Base (255, 254) |
| `ev[27]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Open Dialogue Sub-Window (1); Start Boss Battle #255 (BGM: 254) |
| `ev[28]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Open Dialogue Sub-Window (1); Launch Tactical War Battle (255) |
| `ev[29]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Open Dialogue Sub-Window (1); Toggle Random Encounters (255) |
| `ev[30]` | `1 (Action / Talk)` | Target Inspected is obj[19] | Open Dialogue Sub-Window (1); Open Save Crystal Menu (MSaveInit) |
| `ev[31]` | `1 (Action / Talk)` | Target Inspected is obj[20] | Open Dialogue Sub-Window (1); Engine Action #39 |
| `ev[32]` | `1 (Action / Talk)` | Target Inspected is obj[21] | Open Dialogue Sub-Window (1); Engine Action #40 |
| `ev[33]` | `1 (Action / Talk)` | Target Inspected is obj[22] | Open Dialogue Sub-Window (1); Award Potch Loot (+65,534 Potch) |
| `ev[34]` | `1 (Action / Talk)` | Target Inspected is obj[23] | Open Dialogue Sub-Window (1); Remove Item from Inventory (255, 254) |
| `ev[35]` | `1 (Action / Talk)` | Target Inspected is obj[24] | Open Dialogue Sub-Window (1); Open Shop Menu #254 (Type: 255) |
| `ev[36]` | `1 (Action / Talk)` | Target Inspected is obj[25] | Open Dialogue Sub-Window (1); Engine Action #44 |
| `ev[37]` | `1 (Action / Talk)` | Target Inspected is obj[26] | Open Dialogue Sub-Window (1); Make obj[255] Visible (disp = 1) |
| `ev[38]` | `1 (Action / Talk)` | Target Inspected is obj[27] | Open Dialogue Sub-Window (1); Make obj[255] Hidden (disp = 0) |
| `ev[39]` | `1 (Action / Talk)` | Target Inspected is obj[28] | Open Dialogue Sub-Window (1); Teleport obj[255] to (254,255) |
| `ev[40]` | `1 (Action / Talk)` | Target Inspected is obj[29] | Open Dialogue Sub-Window (1); Turn obj[255] facing 254 |
| `ev[41]` | `1 (Action / Talk)` | Target Inspected is obj[30] | Open Dialogue Sub-Window (1); Set Entity Movement Speed (255, 254) |
| `ev[42]` | `1 (Action / Talk)` | Target Inspected is obj[31] | Open Dialogue Sub-Window (1); Walk obj[255] to (254,255) |
| `ev[43]` | `1 (Action / Talk)` | Target Inspected is obj[32] | Open Dialogue Sub-Window (1); Engine Action #51 |
| `ev[44]` | `1 (Action / Talk)` | Target Inspected is obj[33] | Open Dialogue Sub-Window (1); Engine Action #52 |
| `ev[45]` | `1 (Action / Talk)` | Target Inspected is obj[34] | Open Dialogue Sub-Window (1); Engine Action #53 |
| `ev[46]` | `1 (Action / Talk)` | Target Inspected is obj[35] | Open Dialogue Sub-Window (1); Engine Action #54 |
| `ev[47]` | `1 (Action / Talk)` | Target Inspected is obj[36] | Open Dialogue Sub-Window (1); Set Render Priority (pri) (255, 254) |
| `ev[48]` | `1 (Action / Talk)` | Target Inspected is obj[37] | Open Dialogue Sub-Window (1); Set Animation Pose (255, 254) |
| `ev[49]` | `1 (Action / Talk)` | Target Inspected is obj[38] | Open Dialogue Sub-Window (1); Recruit Character into Active Party (255, 254) |
| `ev[50]` | `1 (Action / Talk)` | Target Inspected is obj[39] | Open Dialogue Sub-Window (1); Engine Action #58 |
| `ev[51]` | `1 (Action / Talk)` | Target Inspected is obj[40] | Open Dialogue Sub-Window (1); Set obj[255] Collision to Passable |
| `ev[52]` | `1 (Action / Talk)` | Target Inspected is obj[41] | Open Dialogue Sub-Window (1); Trigger Character Emotion Effect (255, 254) |

---

### Submap Layer `vi06_02` (Index 2)

- **Map Number (`mapno`)**: `2`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `15`, Rate: `8`)
- **Entity Count (`okaz`)**: `24` Objects | **Script Count (`evkaz`)**: `45` Scripts

#### Complete Physical Entity Inventory (24 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | Treasure Chest | **Opened Chest** | `0` | `(142, 30)` | `0x0` | East (Right) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | Treasure Chest | **Closed Chest (Unopened)** | `0` | `(142, 30)` | `0x0` | Up (North) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | Treasure Chest | **Opened Chest** | `0` | `(86, 187)` | `0x0` | East (Right) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | Treasure Chest | **Closed Chest (Unopened)** | `0` | `(86, 187)` | `0x0` | Up (North) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[04]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[15]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[16]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[17]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[18]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[19]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[20]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[21]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[22]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[23]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Treasure Chest)**: Placed at tile `(142, 30)`. Initial state is Open. Controlled by map loot bitflags.
- **`obj[01]` (Treasure Chest)**: Placed at tile `(142, 30)`. Initial state is Closed (Unopened). Controlled by map loot bitflags.
- **`obj[02]` (Treasure Chest)**: Placed at tile `(86, 187)`. Initial state is Open. Controlled by map loot bitflags.
- **`obj[03]` (Treasure Chest)**: Placed at tile `(86, 187)`. Initial state is Closed (Unopened). Controlled by map loot bitflags.
- **`obj[04]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[05]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[06]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[07]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[08]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[09]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[10]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[11]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[12]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[13]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[14]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[15]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[16]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[17]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[18]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[19]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[20]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[21]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[22]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[23]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.


#### Complete Bytecode Script Catalog (45 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Treasure Byte 4 Bit 16 FRESH (Unopened) | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[01]` | `2 (Map Init)` | Treasure Byte 4 Bit 16 LOOTED | Open Dialogue Message Window; Engine Action #9 |
| `ev[02]` | `2 (Map Init)` | Treasure Byte 4 Bit 32 FRESH (Unopened) | Open Dialogue Message Window; Screen Fade Transition (255, 254, 255) |
| `ev[03]` | `2 (Map Init)` | Treasure Byte 4 Bit 32 LOOTED | Open Dialogue Message Window; Close Dialogue Window |
| `ev[04]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) CLEAR AND Player within Box [23..24, 2..175] AND Condition Check #179 AND Story Flag 2 (mask 255) SET | Warp Room -> Submap 0 at (8,6); Warp Map Transition (3, 0, 76, 24, 255) |
| `ev[05]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Player within Box [23..24, 2..175] AND Condition Check #179 AND Story Flag 2 (mask 255) SET | Warp Room -> Submap 0 at (8,6); Warp Map Transition (3, 1, 76, 24, 255) |
| `ev[06]` | `1 (Action / Talk)` | Player within Box [28..29, 2..173] AND Condition Check #174 | Close Dialogue Window; Warp Town -> Area 2 Map 40 Submap 3 at (0,0); Wait for Audio / Window Sync (1); Display Dialogue Box [Bank: 2, MsgID: 140]; Engine Action #206 |
| `ev[07]` | `1 (Action / Talk)` | Player within Box [140..140, 2..200] AND Condition Check #201 AND Story Flag 1 (mask 255) SET | Close Dialogue Window; Warp Town -> Area 2 Map 40 Submap 3 at (0,3); Wait for Audio / Window Sync (1); Display Dialogue Box [Bank: 2, MsgID: 31]; Engine Action #173 |
| `ev[08]` | `1 (Action / Talk)` | Player within Box [30..34, 2..168] AND Condition Check #169 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 32]; Engine Action #144 |
| `ev[09]` | `1 (Action / Talk)` | Player within Box [30..34, 2..147] AND Condition Check #148 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 32]; Engine Action #173 |
| `ev[10]` | `1 (Action / Talk)` | Player within Box [29..35, 2..63] AND Condition Check #64 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 32]; Return Warp to Castle Base (255, 254) |
| `ev[11]` | `1 (Action / Talk)` | Player within Box [29..35, 2..37] AND Condition Check #38 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 32]; Play CD / Ambient BGM Track (255) |
| `ev[12]` | `1 (Action / Talk)` | Player within Box [40..41, 2..29] AND Condition Check #33 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 80]; Display Chapter Text (255) |
| `ev[13]` | `1 (Action / Talk)` | Player within Box [77..78, 2..26] AND Condition Check #31 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 38]; Warp Room -> Submap 255 at (254,204) |
| `ev[14]` | `1 (Action / Talk)` | Player within Box [28..29, 2..27] AND Treasure Byte 255 Bit 254 FRESH (Unopened) | Close Dialogue Window; Warp Town -> Area 2 Map 40 Submap 3 at (0,0); Wait for Audio / Window Sync (1); Display Dialogue Box [Bank: 2, MsgID: 88]; Engine Action #78 |
| `ev[15]` | `1 (Action / Talk)` | Player within Box [88..88, 2..72] AND Condition Check #73 AND Story Flag 1 (mask 255) SET | Close Dialogue Window; Warp Town -> Area 2 Map 40 Submap 3 at (0,3); Wait for Audio / Window Sync (1); Display Dialogue Box [Bank: 2, MsgID: 31]; Fade Out to Black (255) |
| `ev[16]` | `1 (Action / Talk)` | Player within Box [89..95, 2..85] AND Condition Check #86 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 92]; Engine Action #116 |
| `ev[17]` | `1 (Action / Talk)` | Player within Box [89..95, 2..111] AND Condition Check #112 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 92]; Remove Item from Inventory (255, 254) |
| `ev[18]` | `1 (Action / Talk)` | Player within Box [100..101, 2..76] AND Condition Check #81 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 138]; Full Rest & Healing (Restore HP/MP) |
| `ev[19]` | `1 (Action / Talk)` | Player within Box [135..136, 2..74] AND Condition Check #80 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 98]; Bytecode Subroutine Return |
| `ev[20]` | `1 (Action / Talk)` | Player within Box [200..204, 2..83] AND Condition Check #84 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 202]; Engine Action #116 |
| `ev[21]` | `1 (Action / Talk)` | Player within Box [198..206, 2..112] AND Condition Check #113 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 202]; Engine Action #80 |
| `ev[22]` | `1 (Action / Talk)` | Player within Box [200..204, 2..131] AND Condition Check #132 AND Story Flag 0 (mask 255) SET | Warp Room -> Submap 0 at (8,2); Set Special Scene BGM (1); Warp Map Transition (3, 0, 6, 40, 255) |
| `ev[23]` | `1 (Action / Talk)` | Treasure Byte 4 Bit 16 FRESH (Unopened) AND Target Inspected is obj[8] | Recruit Character into Active Party (46 [Oulan], 0); Engine Action #9; Warp Room -> Submap 47 at (101,4) facing 7; Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (0); Exit to World Map (0, 44, 16); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,4) facing 16; Engine Action #51; Warp Town -> Area 255 Map 1 Submap 46 at (0,8); Warp Room -> Submap 47 at (255,2) facing 58 |
| `ev[24]` | `1 (Action / Talk)` | Treasure Byte 4 Bit 32 FRESH (Unopened) AND Target Inspected is obj[10] | Recruit Character into Active Party (46 [Oulan], 0); Close Dialogue Window; Warp Room -> Submap 47 at (101,4) facing 7; Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (0); Exit to World Map (0, 53, 16); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,4) facing 32; Engine Action #51; Warp Town -> Area 255 Map 1 Submap 46 at (0,10); Warp Room -> Submap 47 at (255,2) facing 58 |
| `ev[25]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Open Dialogue Sub-Window (1); Engine Action #61 |
| `ev[26]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Open Dialogue Sub-Window (1); Engine Action #62 |
| `ev[27]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Open Dialogue Sub-Window (1); Engine Action #63 |
| `ev[28]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Open Dialogue Sub-Window (1); Animate Doorway State (255, 254) |
| `ev[29]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Open Dialogue Sub-Window (1); Play Sound Effect (SE) (255) |
| `ev[30]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Open Dialogue Sub-Window (1); Engine Action #66 |
| `ev[31]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Open Dialogue Sub-Window (1); Open Shop Interface #255 |
| `ev[32]` | `1 (Action / Talk)` | Target Inspected is obj[19] | Open Dialogue Sub-Window (1); Play CD / Ambient BGM Track (255) |
| `ev[33]` | `1 (Action / Talk)` | Target Inspected is obj[20] | Open Dialogue Sub-Window (1); Wait for Audio / Window Sync (255) |
| `ev[34]` | `1 (Action / Talk)` | Target Inspected is obj[21] | Open Dialogue Sub-Window (1); Recruit Hero #255 into Battle Slot 254 |
| `ev[35]` | `1 (Action / Talk)` | Target Inspected is obj[22] | Open Dialogue Sub-Window (1); Remove Character from Active Party (255) |
| `ev[36]` | `1 (Action / Talk)` | Target Inspected is obj[23] | Open Dialogue Sub-Window (1); Load Sound Bank into Memory (255, 254) |
| `ev[37]` | `1 (Action / Talk)` | Target Inspected is obj[24] | Open Dialogue Sub-Window (1); Set Combat Battle BGM (255) |
| `ev[38]` | `1 (Action / Talk)` | Target Inspected is obj[25] | Open Dialogue Sub-Window (1); Set Special Scene BGM (255) |
| `ev[39]` | `1 (Action / Talk)` | Target Inspected is obj[26] | Open Dialogue Sub-Window (1); Full Rest & Healing (Restore HP/MP) |
| `ev[40]` | `1 (Action / Talk)` | Target Inspected is obj[27] | Open Dialogue Sub-Window (1); Full Rest & Healing (Restore HP/MP) |
| `ev[41]` | `1 (Action / Talk)` | Target Inspected is obj[28] | Open Dialogue Sub-Window (1); Award Potch Currency (255,254) |
| `ev[42]` | `1 (Action / Talk)` | Target Inspected is obj[29] | Open Dialogue Sub-Window (1); Engine Action #78 |
| `ev[43]` | `1 (Action / Talk)` | Target Inspected is obj[30] | Open Dialogue Sub-Window (1); Bytecode Subroutine Return |
| `ev[44]` | `1 (Action / Talk)` | Target Inspected is obj[31] | Open Dialogue Sub-Window (1); Engine Action #80 |

---



## Location Map: `vi07`

- **Master Map Container**: `vi07.json`
- **Submap Layer Files**: Embedded in master
- **Collision Grid Files**: vi07_map_01.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 2

### Submap Layer `vi07_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `2` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (2 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [0..1, 2..21] AND Treasure Byte 9 Bit 2 LOOTED | Warp Room -> Submap 1 at (8,5); Warp Map Transition (2, 1, 36, 47, 255) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [78..79, 2..21] AND Treasure Byte 9 Bit 3 LOOTED | Warp Room -> Submap 1 at (8,5); Warp Map Transition (2, 2, 26, 177, 255) |

---

### Submap Layer `vi07_01` (Index 1)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `2` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (2 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [0..1, 2..21] AND Treasure Byte 9 Bit 2 LOOTED | Warp Room -> Submap 1 at (8,5); Warp Map Transition (2, 1, 36, 47, 255) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [78..79, 2..21] AND Treasure Byte 9 Bit 3 LOOTED | Warp Room -> Submap 1 at (8,5); Warp Map Transition (2, 2, 26, 177, 255) |

---



## Location Map: `vi10`

- **Master Map Container**: `vi10.json`
- **Submap Layer Files**: vi10_00.json, vi10_01.json, vi10_07.json, vi10_08.json, vi10_09.json, vi10_15.json
- **Collision Grid Files**: None
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 1

### Submap Layer `vi10_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `35` Objects | **Script Count (`evkaz`)**: `20` Scripts

#### Complete Physical Entity Inventory (35 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | Prop / Scenery | **Prop ID 37138** | `37138` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 55 | 180 |
| `obj[01]` | Prop / Scenery | **Prop ID 37138** | `37138` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 55 | 180 |
| `obj[02]` | Prop / Scenery | **Prop ID 37138** | `37138` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 55 | 480 |
| `obj[03]` | Prop / Scenery | **Prop ID 37138** | `37138` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 55 | 480 |
| `obj[04]` | Prop / Scenery | **Prop ID 37138** | `37138` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 55 | 480 |
| `obj[05]` | Prop / Scenery | **Prop ID 37138** | `37138` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 55 | 480 |
| `obj[06]` | Prop / Scenery | **Prop ID 37138** | `37138` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 55 | 0 |
| `obj[07]` | Prop / Scenery | **Prop ID 37394** | `37394` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 55 | 0 |
| `obj[08]` | Prop / Scenery | **Prop ID 36882** | `36882` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 55 | 0 |
| `obj[09]` | Prop / Scenery | **Prop ID 37138** | `37138` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 55 | 180 |
| `obj[10]` | Prop / Scenery | **Prop ID 37394** | `37394` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 55 | 0 |
| `obj[11]` | NPC / Actor | **Riou (Hero)** | `1` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 480 |
| `obj[12]` | NPC / Actor | **Highland Officer** | `81` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[13]` | NPC / Actor | **Jowy (Camp/Prologue)** | `18` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[14]` | NPC / Actor | **Actor ID 139** | `139` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[15]` | Prop / Scenery | **Prop ID 34129** | `34129` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 55 | 180 |
| `obj[16]` | Prop / Scenery | **Prop ID 34129** | `34129` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 55 | 0 |
| `obj[17]` | Prop / Scenery | **Prop ID 43026** | `43026` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 55 | 0 |
| `obj[18]` | Prop / Scenery | **Prop ID 44289** | `44289` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 55 | 0 |
| `obj[19]` | NPC / Actor | **Actor ID 89** | `89` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[20]` | NPC / Actor | **Actor ID 92** | `92` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[21]` | NPC / Actor | **Actor ID 65139** | `65139` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[22]` | NPC / Actor | **Actor ID 65139** | `65139` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[23]` | NPC / Actor | **Actor ID 65105** | `65105` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[24]` | NPC / Actor | **Actor ID 65105** | `65105` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[25]` | NPC / Actor | **Actor ID 65105** | `65105` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[26]` | NPC / Actor | **Actor ID 65105** | `65105` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[27]` | NPC / Actor | **Actor ID 65105** | `65105` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[28]` | NPC / Actor | **Actor ID 64535** | `64535` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[29]` | NPC / Actor | **Actor ID 64535** | `64535` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[30]` | NPC / Actor | **Actor ID 64535** | `64535` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[31]` | NPC / Actor | **Actor ID 64535** | `64535` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[32]` | NPC / Actor | **Actor ID 64535** | `64535` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[33]` | Prop / Scenery | **Prop ID 64976** | `64976` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 55 | 0 |
| `obj[34]` | Prop / Scenery | **Prop ID 64976** | `64976` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 55 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Prop: Object 37138)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[01]` (Prop: Object 37138)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[02]` (Prop: Object 37138)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[03]` (Prop: Object 37138)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[04]` (Prop: Object 37138)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[05]` (Prop: Object 37138)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[06]` (Prop: Object 37138)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[07]` (Prop: Object 37394)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[08]` (Prop: Object 36882)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[09]` (Prop: Object 37138)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[10]` (Prop: Object 37394)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[11]` (Riou (Hero))**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[12]` (Highland Officer)**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[13]` (Jowy (Camp/Prologue))**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[14]` (Object 139)**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[15]` (Prop: Object 34129)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[16]` (Prop: Object 34129)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[17]` (Prop: Object 43026)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[18]` (Prop: Object 44289)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[19]` (Object 89)**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[20]` (Object 92)**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[21]` (Object 65139)**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[22]` (Object 65139)**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[23]` (Object 65105)**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[24]` (Object 65105)**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[25]` (Object 65105)**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[26]` (Object 65105)**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[27]` (Object 65105)**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[28]` (Object 64535)**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[29]` (Object 64535)**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[30]` (Object 64535)**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[31]` (Object 64535)**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[32]` (Object 64535)**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[33]` (Prop: Object 64976)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[34]` (Prop: Object 64976)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.


#### Complete Bytecode Script Catalog (20 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 20 (bit 8) SET AND Story Flag 20 (bit 16) CLEAR | Make obj[2] Hidden (disp = 0); Open Dialogue Message Window; Full Rest & Healing (Restore HP/MP); Display Choice Selection (1, 0); Warp Town -> Area 15 Map 72 Submap 18 at (89,15); Warp Town -> Area 9 Map 0 Submap 15 at (2,28); Set Special Scene BGM (19); Warp to Castle HQ (28, 1, 0); Display Chapter Text (2); Fade Out to Black (69); Display Choice Selection (3, 27); Warp to Castle HQ (0, 27, 2); Warp Room -> Submap 38 at (19,0); Warp Room -> Submap 47 at (255,254) |
| `ev[01]` | `1 (Action / Talk)` | Story Flag 20 (bit 1) SET AND Story Flag 20 (bit 2) CLEAR AND Player within Box [20..20, 2..19] AND Character #255 Level >= 254 | Recruit Character into Active Party (33 [Camus], 1); Display Speaker Name Box (0); Warp Room -> Submap 1 at (4,7) facing West (Left); Warp Room -> Submap 1 at (30,36) facing West (Left); Launch Tactical War Battle (128); Set Entity Movement Speed (2, 5); Warp Room -> Submap 4 at (3,40) facing 5; Dismiss Emotion Bubble (0); Open Dialogue Message Window; Engine Action #5; Screen Fade Transition (30, 255, 254); Engine Action #5; Open Dialogue Message Window; Exit to World Map (4, 5, 4); Warp to Castle HQ (40, 5, 40); Warp Room -> Submap 30 at (255,254) facing 50; Close Dialogue Sub-Window (1); Open Dialogue Message Window; Show Dialogue Portrait (46, 2, 20); Set Object Direction (19, 0); Branch on Choice (3, 20); Warp Town -> Area 47 Map 73 Submap 60 at (24,20); Open Dialogue Message Window; Dismiss Dialogue Portrait; Launch Tactical War Battle (2); Warp to Castle HQ (0, 3, 73); Engine Action #5; Warp to Castle HQ (1, 3, 101); Warp Room -> Submap 24 at (1,0) facing 17; Engine Action #54; Open Dialogue Message Window; Warp Town -> Area 36 Map 4 Submap 36 at (8,49); Warp Town -> Area 5 Map 1 Submap 4 at (5,3); Place Scenery Structure (30); Engine Action #5; Open Dialogue Message Window; Exit to World Map (4, 3, 12); Dismiss Emotion Bubble (255); Walk obj[46] to (2,25); Set Special Scene BGM (18); Engine Action #89; Clear Dialogue Sub-Window; Warp Town -> Area 0 Map 0 Submap 25 at (1,1); Teleport obj[54] to (0,4); Engine Action #54; Open Dialogue Message Window; Reset Camera Tracking (73); Show Dialogue Portrait (89, 25, 5); Engine Action #89; Clear Dialogue Sub-Window; Engine Action #5; Engine Action #89; Clear Dialogue Sub-Window; Warp Town -> Area 1 Map 73 Submap 5 at (89,24); Warp Town -> Area 1 Map 24 Submap 20 at (0,18); Engine Action #89; Close Dialogue Sub-Window (2); Warp Town -> Area 73 Map 10 Submap 101 at (0,183); Engine Action #89; Clear Dialogue Sub-Window; Warp Town -> Area 2 Map 89 Submap 24 at (5,89); Close Dialogue Sub-Window (5); Engine Action #89; Close Dialogue Sub-Window (2); Warp to Castle HQ (73, 15, 89); Clear Dialogue Sub-Window; Warp Town -> Area 4 Map 24 Submap 1 at (0,19); Engine Action #89; Clear Dialogue Sub-Window; Warp Town -> Area 3 Map 73 Submap 15 at (73,20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 0 Map 20 Submap 0 at (21,41); Warp Town -> Area 0 Map 1 Submap 255 at (0,73); Screen Fade Transition (89, 25, 2); Engine Action #6; Engine Action #89; Clear Dialogue Sub-Window; Engine Action #5; Engine Action #89; Clear Dialogue Sub-Window; Engine Action #5; Engine Action #89; Clear Dialogue Sub-Window; Warp Town -> Area 8 Map 24 Submap 1 at (0,22); Set Combat Battle BGM (10); Engine Action #89; Clear Dialogue Sub-Window; Warp Town -> Area 9 Map 89 Submap 25 at (5,89); Clear Dialogue Sub-Window; Engine Action #5; Engine Action #89; Clear Dialogue Sub-Window; Warp Town -> Area 11 Map 51 Submap 2 at (255,1); Set Combat Battle BGM (10); Engine Action #89; Clear Dialogue Sub-Window; Warp Town -> Area 4 Map 24 Submap 1 at (0,23); Engine Action #89; Clear Dialogue Sub-Window; Warp Town -> Area 3 Map 255 Submap 2 at (73,30); Engine Action #89; Close Dialogue Sub-Window (2); Exit to World Map (89, 24, 5); Engine Action #89; Close Dialogue Sub-Window (5); Engine Action #89; Close Dialogue Sub-Window (2); Engine Action #5; Set Combat Battle BGM (30); Close Dialogue Sub-Window (20); Open Dialogue Message Window; Close Dialogue Sub-Window (73); Dismiss Emotion Bubble (89); Clear Dialogue Sub-Window; Warp Town -> Area 5 Map 24 Submap 1 at (1,5); Engine Action #81; Open Dialogue Message Window; Warp Room -> Submap 0 at (1,73) facing 30; Close Dialogue Sub-Window (20); Warp Room -> Submap 73 at (30,73) facing 20; Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 0 Map 27 Submap 0 at (28,73); Screen Fade Transition (89, 25, 2); Show Dialogue Portrait (89, 25, 5); Engine Action #89; Clear Dialogue Sub-Window; Engine Action #5; Engine Action #89; Clear Dialogue Sub-Window; Warp Town -> Area 16 Map 73 Submap 10 at (24,20); Open Dialogue Message Window; Display Emotion Bubble (73, 15); Engine Action #89; Clear Dialogue Sub-Window; Warp Town -> Area 17 Map 89 Submap 25 at (5,89); Clear Dialogue Sub-Window; Engine Action #5; Launch Tactical War Battle (16); Make obj[0] Hidden (disp = 0); Warp Room -> Submap 25 at (47,73) facing 30; Engine Action #9; Open Dialogue Message Window; Warp Room -> Submap 1 at (0,30) facing 53; Open Dialogue Message Window; Open Dialogue Message Window; Warp Room -> Submap 0 at (16,46) facing Up (North); Set Story Flag (10, 20); Open Dialogue Message Window; Set Story Flag (3, 22); Warp to Castle HQ (2, 29, 8); Display Speaker Name Box (0); Display Emotion Bubble (3, 29); Warp to Castle HQ (2, 30, 9); Open Dialogue Sub-Window (0); Dismiss Emotion Bubble (3); Dismiss Emotion Bubble (3); Teleport obj[36] to (32,101); Engine Action #9; Reset Camera Tracking (28); Warp Town -> Area 50 Map 5 Submap 54 at (0,32); Jump to Bytecode Offset (1, 1); Close Dialogue Sub-Window (22); Open Dialogue Message Window; Warp Room -> Submap 28 at (3,45); Pan Camera (72, 1, 1); Open Dialogue Message Window; Engine Action #5; Warp Room -> Submap 0 at (5,5) facing Up (North); Open Dialogue Message Window; Dismiss Emotion Bubble (72); Open Dialogue Message Window; Warp Room -> Submap 0 at (4,1) facing South (Down); Warp Map Transition (1, 46, 2, 16, 70); Display Speaker Name Box (89); Dismiss Dialogue Portrait; Warp Town -> Area 2 Map 0 Submap 16 at (1,1); Warp Town -> Area 1 Map 67 Submap 18 at (47,90); Dismiss Dialogue Portrait; Exit to World Map (5, 18, 3); Dismiss Emotion Bubble (46); Warp Town -> Area 14 Map 67 Submap 18 at (89,14); Warp Town -> Area 0 Map 0 Submap 14 at (1,16); Teleport obj[5] to (0,1); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp Town -> Area 0 Map 30 Submap 73 at (10,101); Exit to World Map (41, 73, 20); Open Shop Interface #0; Open Dialogue Message Window; Warp Town -> Area 0 Map 33 Submap 0 at (35,3); Warp Town -> Area 73 Map 5 Submap 41 at (3,3); Exit to World Map (5, 255, 3); Engine Action #61; Warp Room -> Submap 5 at (0,1) facing South (Down); Exit to World Map (5, 2, 3); Dismiss Emotion Bubble (61); Open Dialogue Message Window; Warp Town -> Area 46 Map 2 Submap 26 at (69,19); Engine Action #89; Fade In from Black (2); Warp Room -> Submap 26 at (1,0) facing 47; Set Combat Battle BGM (20); Jump to Bytecode Offset (0, 186); Engine Action #89; Fade In from Black (5); Engine Action #89; Fade In from Black (5); Engine Action #89; Fade In from Black (2); Warp Town -> Area 9 Map 20 Submap 64 at (51,6); Exit to World Map (61, 1, 2); Engine Action #5; Open Dialogue Message Window; Warp Room -> Submap 4 at (5,2) facing East (Right); Dismiss Emotion Bubble (61); Open Dialogue Message Window; Warp Town -> Area 46 Map 2 Submap 26 at (69,19); Engine Action #89; Fade In from Black (2); Warp Room -> Submap 26 at (1,0) facing 47; Set Combat Battle BGM (20); Jump to Bytecode Offset (0, 186); Dismiss Emotion Bubble (0); Exit to World Map (20, 0, 36); Warp Room -> Submap 26 at (5,89) facing 26; Engine Action #5; Engine Action #89; Fade In from Black (2); Warp Town -> Area 9 Map 20 Submap 64 at (51,6); Engine Action #5; Make obj[2] Hidden (disp = 0); Fade In from Black (72); Display Choice Selection (89, 26); Warp Town -> Area 0 Map 0 Submap 26 at (1,0); Teleport obj[89] to (26,5); Engine Action #89; Fade In from Black (5); Engine Action #6; Engine Action #89; Animate Door Open; Engine Action #5; Engine Action #89; Animate Door Open; Engine Action #5; Dismiss Emotion Bubble (0); Exit to World Map (1, 0, 34); Warp Room -> Submap 64 at (89,14) facing Up (North); Warp Room -> Submap 14 at (5,89) facing 14; Engine Action #5; Engine Action #89; Animate Door Open; Warp Town -> Area 2 Map 73 Submap 1 at (46,2); Engine Action #9; Engine Action #63; Animate Door Open; Engine Action #89; Engine Action #9; Warp Town -> Area 25 Map 0 Submap 9 at (47,101); Open Dialogue Message Window; Engine Action #181; Set Combat Battle BGM (1); Make obj[2] Hidden (disp = 0); Reset Camera Tracking (63); Animate Door Open; Engine Action #89; Reset Camera Tracking (2); Fade In from Black (0); Reset Camera Tracking (47); Dismiss Emotion Bubble (4); Engine Action #5; Reset Camera Tracking (150); Mark NPC Talk Interaction Complete (Flag #128); Screen Fade Transition (1, 8, 89); Animate Door Open; Engine Action #5; Engine Action #89; Animate Door Open; Engine Action #5; Engine Action #89; Animate Door Open; Warp Town -> Area 3 Map 73 Submap 1 at (46,2); Reset Camera Tracking (63); Animate Door Open; Engine Action #89; Reset Camera Tracking (2); Clear Dialogue Sub-Window; Open Dialogue Message Window; Reset Camera Tracking (47); Set Combat Battle BGM (1); Make obj[2] Hidden (disp = 0); Engine Action #9; Engine Action #63; Animate Door Open; Engine Action #89; Engine Action #9; Warp Town -> Area 26 Map 0 Submap 9 at (47,101); Open Dialogue Message Window; Engine Action #181; Dismiss Emotion Bubble (4); Engine Action #5; Engine Action #9; Engine Action #140; Engine Action #170; Engine Action #128; Screen Fade Transition (1, 9, 89); Animate Door Open; Engine Action #5; Engine Action #89; Animate Door Open; Engine Action #5; Engine Action #89; Animate Door Open; Warp Town -> Area 4 Map 73 Submap 1 at (46,2); Engine Action #9; Engine Action #63; Place Scenery Structure (89); Engine Action #9; Warp Town -> Area 25 Map 0 Submap 9 at (47,101); Open Dialogue Message Window; Engine Action #181; Set Combat Battle BGM (1); Make obj[2] Hidden (disp = 0); Reset Camera Tracking (63); Place Scenery Structure (89); Reset Camera Tracking (2); Fade Out to Black (0); Reset Camera Tracking (47); Dismiss Emotion Bubble (4); Engine Action #5; Reset Camera Tracking (120); Engine Action #90; Engine Action #128; Screen Fade Transition (89, 14, 5); Engine Action #89; Animate Door Open; Engine Action #5; Engine Action #89; Animate Door Open; Warp Town -> Area 5 Map 101 Submap 4 at (39,30); Engine Action #5; Open Dialogue Message Window; Award Potch Loot (+519 Potch); Reset Camera Tracking (255); Pan Camera (11, 4, 2); Warp Room -> Submap 3 at (2,1) facing 51; Engine Action #9; Reset Camera Tracking (10); Branch on Choice (64, 255); Engine Action #9; Jump to Bytecode Offset (9, 14); Engine Action #90; Animate Door Open; Exit to World Map (6, 19, 2); Exit to World Map (5, 19, 2); Exit to World Map (4, 19, 1); Dismiss Emotion Bubble (30); Engine Action #6; Warp Town -> Area 20 Map 6 Submap 41 at (2,10); Close Dialogue Window; Screen Fade Transition (89, 26, 2); Warp to Castle HQ (51, 12, 255); Close Dialogue Window; Engine Action #89; Fade In from Black (2); Reset Camera Tracking (255); Display Dialogue Box [Bank: 89, MsgID: 14]; Engine Action #5; Engine Action #89; Animate Door Open; Engine Action #5; Engine Action #89; Animate Door Open; Warp Town -> Area 6 Map 73 Submap 19 at (101,0); Engine Action #180; Engine Action #89; Animate Door Open; Engine Action #5; Engine Action #89; Animate Door Open; Engine Action #5; Engine Action #89; Animate Door Open; Warp Town -> Area 24 Map 89 Submap 26 at (5,89); Fade In from Black (5); Dismiss Emotion Bubble (6); Warp Town -> Area 20 Map 6 Submap 41 at (2,13); Animate Door Open; Place Scenery Structure (89); Fade In from Black (2); Engine Action #5; Engine Action #51; Show Dialogue Portrait (255, 14, 89); Fade In from Black (2); Screen Fade Transition (255, 15, 73); Trigger Character Emotion Effect (2, 1); Set Special Scene BGM (21); Engine Action #78; Open Dialogue Message Window; Close Dialogue Sub-Window (1); Open Dialogue Message Window; Toggle Random Encounters (46); Open Dialogue Message Window; Display Emotion Bubble (0, 30); Warp Room -> Submap 1 at (42,47) facing 9; Open Dialogue Message Window; Warp Town -> Area 49 Map 3 Submap 5 at (22,4); Pan Camera (3, 30, 4); Exit to World Map (3, 16, 30); Engine Action #5; Display Emotion Bubble (4, 7); Warp to Castle HQ (30, 4, 4); Warp to Castle HQ (16, 30, 255); Engine Action #5; Dismiss Emotion Bubble (4); Pan Camera (3, 30, 4); Exit to World Map (3, 16, 30); Walk obj[73] to (15,24); Set Story Flag (0, 38); Set Combat Battle BGM (15); Engine Action #89; Close Dialogue Sub-Window (2); Display Speaker Name Box (24); Branch on Choice (0, 39); Set Combat Battle BGM (15); Return Warp to Castle Base (84, 18); Open Save Crystal Menu (MSaveInit); Dismiss Character to Castle Base (18 [Nanami]); Open Save Crystal Menu (MSaveInit); Engine Action #62; Open Dialogue Message Window; Display Speaker Name Box (54); Open Dialogue Message Window; Engine Action #128; Dismiss Emotion Bubble (1); Warp Town -> Area 1 Map 1 Submap 116 at (81,80); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #116; Engine Action #81; Warp Room -> Submap 5 at (30,2) facing Up (North); Engine Action #81; Warp Room -> Submap 2 at (102,1) facing 83; Warp Room -> Submap 46 at (1,29) facing West (Left); Dismiss Emotion Bubble (1); Animate Door Open; Engine Action #9; Branch on Choice (2, 10); Open Dialogue Message Window; Toggle Random Encounters (254); Engine Action #80; Teleport obj[255] to (254,255) |
| `ev[02]` | `128 (Loop)` | Story Flag 20 (bit 1) SET AND Story Flag 20 (bit 2) CLEAR AND Inventory Holds Item #1 [Medicine] | Close Dialogue Window; Warp Room -> Submap 200 at (37,1) facing 255 |
| `ev[03]` | `128 (Loop)` | Story Flag 20 (bit 1) SET AND Story Flag 20 (bit 2) CLEAR AND Inventory Holds Item #2 [Mega Medicine] | Display Chapter Text (3); Dismiss Emotion Bubble (7); Toggle Random Encounters (2) |
| `ev[04]` | `128 (Loop)` | Story Flag 20 (bit 1) SET AND Story Flag 20 (bit 2) CLEAR AND Inventory Holds Item #4 [Throat Drops] | Display Chapter Text (2); Display Speaker Name Box (4); Toggle Random Encounters (4) |
| `ev[05]` | `128 (Loop)` | Story Flag 20 (bit 1) SET AND Story Flag 20 (bit 2) CLEAR AND Inventory Holds Item #8 [Fire Wall] | Engine Action #5; Branch on Choice (4, 4); Warp Town -> Area 23 Map 30 Submap 46 at (2,24); Remove Item from Inventory (19, 89); Close Dialogue Sub-Window (2); Open Dialogue Message Window; Open Dialogue Message Window; Close Dialogue Sub-Window (1); Branch on Choice (47, 37); Reset Camera Tracking (255) |
| `ev[06]` | `128 (Loop)` | Story Flag 20 (bit 1) SET AND Story Flag 20 (bit 2) CLEAR AND Character #1 Level >= 255 | Engine Action #89; Clear Dialogue Sub-Window; Warp Town -> Area 10 Map 81 Submap 1 at (2,89); Clear Dialogue Sub-Window; Warp Town -> Area 12 Map 89 Submap 25 at (5,89); Clear Dialogue Sub-Window; Engine Action #5; Engine Action #89; Clear Dialogue Sub-Window; Warp Town -> Area 16 Map 81 Submap 1 at (4,89); Clear Dialogue Sub-Window; Warp Town -> Area 13 Map 89 Submap 25 at (5,89); Clear Dialogue Sub-Window; Engine Action #5; Engine Action #89; Clear Dialogue Sub-Window; Warp Town -> Area 14 Map 80 Submap 1 at (80,2); Engine Action #80; Exit to World Map (255, 254, 255) |
| `ev[07]` | `128 (Loop)` | Story Flag 20 (bit 1) SET AND Story Flag 20 (bit 2) CLEAR AND Character #8 Level >= 255 | Engine Action #89; Close Dialogue Sub-Window (2); Engine Action #6; Engine Action #89; Close Dialogue Sub-Window (5); Engine Action #89; Close Dialogue Sub-Window (5); Engine Action #89; Close Dialogue Sub-Window (2); Pan Camera (80, 8, 255) |
| `ev[08]` | `128 (Loop)` | Story Flag 20 (bit 1) SET AND Story Flag 20 (bit 2) CLEAR AND Inventory Holds Item #16 [Revenge Earth] | Set Combat Battle BGM (30); Engine Action #89; Close Dialogue Sub-Window (2); Reset Camera Tracking (90); Close Dialogue Sub-Window (4); Exit to World Map (18, 3, 30); Engine Action #89; Close Dialogue Sub-Window (2); Change Portrait Expression (89); Close Dialogue Sub-Window (5); Engine Action #89; Close Dialogue Sub-Window (5); Engine Action #89; Close Dialogue Sub-Window (2); Pan Camera (46, 2, 20); Bytecode Subroutine Return; Display Choice Selection (3, 20); Warp Town -> Area 1 Map 20 Submap 47 at (37,16) |
| `ev[09]` | `128 (Loop)` | Story Flag 20 (bit 1) SET AND Story Flag 20 (bit 2) CLEAR AND Inventory Holds Item #32 [Drinking Set] | Set Combat Battle BGM (150); Set Entity Movement Speed (3, 5); Set Story Flag (4, 4); Warp to Castle HQ (5, 30, 255); Engine Action #5; Display Emotion Bubble (4, 4); Warp to Castle HQ (5, 30, 255); Engine Action #5; Dismiss Emotion Bubble (4); Exit to World Map (3, 5, 30); Walk obj[46] to (2,41); Place Scenery Structure (18); Engine Action #89; Award Potch Loot (+512 Potch); Open Dialogue Message Window; Award Potch Loot (+285 Potch); Warp Town -> Area 42 Map 14 Submap 23 at (89,42); Warp Town -> Area 1 Map 0 Submap 42 at (1,30); Teleport obj[37] to (32,255) |
| `ev[10]` | `128 (Loop)` | Story Flag 20 (bit 1) SET AND Story Flag 20 (bit 2) CLEAR AND Inventory Holds Item #64 [Recipe #33] | Set Combat Battle BGM (10); Make obj[2] Hidden (disp = 0); Screen Fade Transition (48, 14, 89); Screen Fade Transition (2, 30, 0); Screen Fade Transition (47, 101, 0); Engine Action #178; Dismiss Emotion Bubble (4); Engine Action #5; Screen Fade Transition (250, 128, 128); Reset Camera Tracking (1); Screen Fade Transition (37, 64, 255) |
| `ev[11]` | `128 (Loop)` | Story Flag 20 (bit 1) SET AND Story Flag 20 (bit 2) CLEAR AND Inventory Holds Item #64 [Recipe #33] | Set Combat Battle BGM (39); Make obj[2] Hidden (disp = 0); Close Dialogue Window; Turn obj[14] facing 89; Close Dialogue Window; Warp Town -> Area 30 Map 0 Submap 11 at (47,101); Open Dialogue Message Window; Engine Action #178; Dismiss Emotion Bubble (4); Engine Action #5; Close Dialogue Window; Engine Action #250; Engine Action #128; Engine Action #128; Reset Camera Tracking (1); Close Dialogue Window; Toggle Random Encounters (64) |
| `ev[12]` | `128 (Loop)` | Story Flag 20 (bit 1) SET AND Story Flag 20 (bit 2) CLEAR AND Inventory Holds Item #64 [Recipe #33] | Set Combat Battle BGM (70); Make obj[2] Hidden (disp = 0); Display Dialogue Box [Bank: 48, MsgID: 13]; Engine Action #89; Display Dialogue Box [Bank: 2, MsgID: 30]; Open Dialogue Message Window; Display Dialogue Box [Bank: 47, MsgID: 101]; Open Dialogue Message Window; Engine Action #178; Dismiss Emotion Bubble (4); Engine Action #5; Display Dialogue Box [Bank: 250, MsgID: 128]; Engine Action #128; Reset Camera Tracking (1); Display Dialogue Box [Bank: 37, MsgID: 64] |
| `ev[13]` | `128 (Loop)` | Story Flag 20 (bit 1) SET AND Story Flag 20 (bit 2) CLEAR AND Inventory Holds Item #64 [Recipe #33] | Set Combat Battle BGM (92); Make obj[2] Hidden (disp = 0); Place Scenery Structure (49); Show Dialogue Portrait (89, 13, 2); Dismiss Emotion Bubble (0); Place Scenery Structure (47); Jump to Bytecode Offset (0, 178); Dismiss Emotion Bubble (4); Engine Action #5; Place Scenery Structure (250); Engine Action #128; Engine Action #128; Reset Camera Tracking (1); Place Scenery Structure (37); Animate Doorway State (255, 254) |
| `ev[14]` | `128 (Loop)` | Story Flag 20 (bit 1) SET AND Story Flag 20 (bit 2) CLEAR AND Inventory Holds Item #128 | Warp Room -> Submap 1 at (15,22); Toggle Random Encounters (128) |
| `ev[15]` | `128 (Loop)` | Story Flag 20 (bit 1) SET AND Story Flag 20 (bit 2) CLEAR AND Story Flag 0 (bit 1) SET | Engine Action #5; Warp Room -> Submap 3 at (7,4) facing 30; Screen Fade Transition (0, 1, 255) |
| `ev[16]` | `128 (Loop)` | Story Flag 20 (bit 1) SET AND Story Flag 20 (bit 2) CLEAR AND Story Flag 0 (bit 2) SET | Set Combat Battle BGM (60); Dismiss Emotion Bubble (6); Warp Town -> Area 20 Map 6 Submap 41 at (2,16); Change Portrait Expression (255); Dismiss Dialogue Portrait; Engine Action #89; Fade In from Black (2); Engine Action #6; Engine Action #51; Display Speaker Name Box (255); Change Portrait Expression (89); Fade In from Black (2); Close Dialogue Window; Display Speaker Name Box (89); Fade In from Black (5); Engine Action #89; Fade In from Black (5); Make obj[0] Hidden (disp = 0); Open Dialogue Message Window; Warp to Castle HQ (0, 3, 1); Fade In from Black (47); Engine Action #5; Open Dialogue Message Window; Engine Action #5; Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp Town -> Area 0 Map 30 Submap 10 at (0,2) |
| `ev[17]` | `1 (Action / Talk)` | Story Flag 20 (bit 2) SET AND Story Flag 20 (bit 4) CLEAR | Open Shop Menu #7 (Type: 0); Exit to World Map (0, 68, 19); Engine Action #9; Warp to Castle HQ (0, 2, 29); Pan Camera (102, 0, 3); Open Dialogue Message Window; Warp Town -> Area 62 Map 0 Submap 81 at (46,2); Display Choice Selection (68, 19); Open Dialogue Message Window; Display Choice Selection (3, 19); Warp Town -> Area 1 Map 0 Submap 2 at (22,61); Display Choice Selection (1, 22); Warp Town -> Area 23 Map 61 Submap 19 at (0,23); Engine Action #89; Open Dialogue Sub-Window (2); Display Choice Selection (2, 20); Set Combat Battle BGM (21); Warp to Castle HQ (20, 2, 1); Branch on Choice (2, 24); Set Combat Battle BGM (21); Open Dialogue Message Window; Close Dialogue Sub-Window (89); Close Dialogue Sub-Window (2); Display Speaker Name Box (2); Show Dialogue Portrait (72, 18, 89); Show Dialogue Portrait (2, 0, 0); Show Dialogue Portrait (2, 21, 74); Execute Choice Result (1); Execute Choice Result (47); Close Dialogue Window; Warp Room -> Submap 100 at (73,15) facing 24; Set Story Flag (0, 40); Engine Action #89; Open Dialogue Sub-Window (2); Branch on Choice (73, 30); Jump to Bytecode Offset (0, 208); Engine Action #89; Open Dialogue Sub-Window (5); Engine Action #89; Open Dialogue Sub-Window (5); Engine Action #89; Open Dialogue Sub-Window (2); Execute Choice Result (94); Warp Room -> Submap 23 at (150,73) facing 15; Engine Action #89; Close Dialogue Sub-Window (2); Engine Action #9; Engine Action #89; Close Dialogue Sub-Window (5); Engine Action #89; Close Dialogue Sub-Window (5); Engine Action #89; Close Dialogue Sub-Window (2); Warp Room -> Submap 24 at (5,89) facing 24; Engine Action #5; Make obj[0] Hidden (disp = 0); Branch on Choice (1, 24); Teleport obj[73] to (15,105); Warp Town -> Area 10 Map 0 Submap 101 at (1,32); Set Entity Movement Speed (3, 5); Open Dialogue Message Window; Exit to World Map (4, 1, 2); Warp to Castle HQ (4, 0, 1); Dismiss Emotion Bubble (255); Engine Action #5; Display Choice Selection (4, 4); Warp Room -> Submap 3 at (4,0) facing West (Left); Dismiss Emotion Bubble (255); Engine Action #5; Branch on Choice (4, 4); Warp to Castle HQ (3, 1, 1); Dismiss Emotion Bubble (255); Walk obj[46] to (2,18); Load Sound Bank into Memory (18, 89); Display Speaker Name Box (2); Warp Room -> Submap 18 at (1,19) facing Up (North); Change Portrait Expression (76); Branch on Choice (89, 17); Warp Town -> Area 28 Map 0 Submap 17 at (1,20); Warp Town -> Area 20 Map 76 Submap 21 at (47,89); Change Portrait Expression (5); Engine Action #89; Change Portrait Expression (5); Close Dialogue Sub-Window (20); Open Dialogue Message Window; Award Potch Loot (+18,718 Potch); Engine Action #78; Open Dialogue Message Window; Close Dialogue Sub-Window (21); Open Dialogue Message Window; Remove Item from Inventory (73, 15); Close Dialogue Sub-Window (20); Open Dialogue Message Window; Open Shop Menu #15 (Type: 73); Engine Action #89; Change Portrait Expression (2); Display Emotion Bubble (89, 17); Engine Action #5; Engine Action #89; Change Portrait Expression (5); Make obj[2] Hidden (disp = 0); Branch on Choice (76, 20); Warp to Castle HQ (20, 1, 0); Branch on Choice (1, 17); Teleport obj[5] to (20,5); Dismiss Emotion Bubble (3); Open Dialogue Message Window; Dismiss Emotion Bubble (46); Warp Town -> Area 24 Map 76 Submap 20 at (89,24); Warp Town -> Area 10 Map 0 Submap 24 at (1,20); Teleport obj[89] to (24,5); Engine Action #89; Close Dialogue Sub-Window (5); Set Combat Battle BGM (15); Launch Tactical War Battle (1); Close Dialogue Sub-Window (20); Warp Room -> Submap 54 at (0,1) facing 46; Open Dialogue Message Window; Branch on Choice (1, 24); Teleport obj[5] to (20,4); Engine Action #5; Engine Action #5; Show Dialogue Portrait (3, 35, 30); Warp Room -> Submap 44 at (5,0) facing 4; Pan Camera (0, 1, 30); Make obj[1] Hidden (disp = 0); Display Speaker Name Box (89); Show Dialogue Portrait (2, 2, 47); Engine Action #89; Show Dialogue Portrait (5, 89, 15); Engine Action #5; Engine Action #89; Show Dialogue Portrait (2, 3, 2); Execute Choice Result (73); Branch on Choice (78, 0); Close Dialogue Sub-Window (21); Open Dialogue Message Window; Make obj[73] Visible (disp = 1); Trigger Character Emotion Effect (89, 15); Warp Town -> Area 4 Map 89 Submap 15 at (5,89); Show Dialogue Portrait (5, 89, 15); Warp Town -> Area 5 Map 78 Submap 0 at (24,21); Open Dialogue Message Window; Make obj[73] Hidden (disp = 0); Branch on Choice (40, 0); Open Dialogue Message Window; Warp Town -> Area 0 Map 47 Submap 0 at (48,89); Show Dialogue Portrait (2, 6, 89); Show Dialogue Portrait (5, 89, 15); Engine Action #5; Engine Action #89; Show Dialogue Portrait (2, 3, 41); Warp Town -> Area 0 Map 1 Submap 255 at (0,78); Open Dialogue Message Window; Close Dialogue Sub-Window (21); Open Dialogue Message Window; Set Entity Movement Speed (51, 2); Warp Room -> Submap 0 at (24,21) facing South (Down); Walk obj[255] to (2,73); Trigger Character Emotion Effect (89, 15); Warp Town -> Area 4 Map 89 Submap 15 at (5,89); Show Dialogue Portrait (5, 89, 15); Warp Town -> Area 5 Map 78 Submap 0 at (24,21); Open Dialogue Message Window; Engine Action #51; Engine Action #89; Show Dialogue Portrait (2, 6, 89); Show Dialogue Portrait (5, 89, 15); Engine Action #5; Jump to Bytecode Offset (9, 8); Engine Action #89; Show Dialogue Portrait (2, 7, 89); Show Dialogue Portrait (5, 89, 15); Engine Action #5; Engine Action #89; Show Dialogue Portrait (2, 8, 89); Show Dialogue Portrait (5, 89, 15); Engine Action #5; Set Combat Battle BGM (240); Make obj[2] Hidden (disp = 0); Fade Out to Black (39); Branch on Choice (0, 27); Warp Town -> Area 31 Map 38 Submap 18 at (0,31); Warp Town -> Area 32 Map 37 Submap 22 at (0,32); Warp Town -> Area 33 Map 35 Submap 18 at (0,33); Warp Town -> Area 34 Map 34 Submap 22 at (0,34); Warp Town -> Area 35 Map 31 Submap 22 at (0,35); Teleport obj[49] to (6,5); Fade Out to Black (4); Engine Action #5; Engine Action #5; Warp Room -> Submap 26 at (30,255) facing 254; Engine Action #5; Warp Room -> Submap 4 at (5,5); Engine Action #5; Warp to Castle HQ (26, 30, 255); Engine Action #5; Warp Map Transition (4, 5, 5, 25, 3); Fade In from Black (30); Engine Action #5; Return to Previous Memory Map (4); Engine Action #5; Engine Action #5; Dismiss Emotion Bubble (3); Fade In from Black (30); Engine Action #5; Return Warp to Castle Base (4, 5); Engine Action #5; Show Dialogue Portrait (3, 26, 30); Engine Action #5; Start Boss Battle #4 (BGM: 5); Engine Action #5; Start Boss Battle #3 (BGM: 26); Dismiss Emotion Bubble (255); Walk obj[72] to (1,27); Warp Town -> Area 73 Map 15 Submap 72 at (0,27); Engine Action #5; Fade Out to Black (5); Show Dialogue Portrait (4, 3, 3); Warp Room -> Submap 30 at (30,24) facing 27; Open Dialogue Message Window; Engine Action #52; Engine Action #5; Fade Out to Black (5); Dismiss Emotion Bubble (0); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Dismiss Emotion Bubble (5); Warp Map Transition (1, 0, 5, 10, 30); Close Dialogue Sub-Window (27); Open Dialogue Message Window; Engine Action #53; Set Combat Battle BGM (15); Close Dialogue Sub-Window (32); Open Dialogue Message Window; Engine Action #54; Set Combat Battle BGM (15); Make obj[2] Hidden (disp = 0); Toggle Random Encounters (63); Set Story Flag (2, 39); Trigger Character Emotion Effect (22, 2); Engine Action #40; Recruit Character into Active Party (22 [Tuta], 3); Toggle Random Encounters (3); Warp to Castle HQ (39, 3, 3); Engine Action #40; Warp to Castle HQ (0, 37, 0); Engine Action #39; Open Dialogue Message Window; Engine Action #40; Warp Room -> Submap 1 at (34,1) facing 35; Teleport obj[49] to (3,5); Toggle Random Encounters (4); Engine Action #6; Warp to Castle HQ (46, 30, 255); Engine Action #5; Engine Action #39; Exit to World Map (6, 5, 2); Warp to Castle HQ (46, 30, 255); Engine Action #5; Engine Action #40; Exit to World Map (6, 5, 4); Warp to Castle HQ (46, 30, 255); Walk obj[5] to (27,2); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp Room -> Submap 5 at (5,30) facing 5; Warp Room -> Submap 0 at (0,5); Screen Fade Transition (30, 24, 27); Open Dialogue Message Window; Set Render Priority (pri) (73, 15); Set Entity Movement Speed (2, 5); Warp Room -> Submap 0 at (0,5); Engine Action #5; Warp Town -> Area 0 Map 30 Submap 255 at (254,5); Return to Previous Memory Map (0); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp Town -> Area 0 Map 30 Submap 255 at (254,50); Make obj[2] Hidden (disp = 0); Launch Tactical War Battle (64); Display Speaker Name Box (2); Open Save Crystal Menu (MSaveInit); Engine Action #61; Display Speaker Name Box (3); Launch Tactical War Battle (2); Warp to Castle HQ (38, 2, 0); Launch Tactical War Battle (0); Open Save Crystal Menu (MSaveInit); Warp Room -> Submap 1 at (33,47) facing 49; Warp Town -> Area 5 Map 36 Submap 4 at (6,5); Warp Town -> Area 2 Map 26 Submap 30 at (255,254); Engine Action #5; Open Save Crystal Menu (MSaveInit); Exit to World Map (6, 2, 26); Dismiss Emotion Bubble (255); Walk obj[5] to (27,3); Open Dialogue Message Window; Engine Action #5; Dismiss Emotion Bubble (30); Close Dialogue Sub-Window (27); Open Dialogue Message Window; Recruit Character into Active Party (46 [Oulan], 84); Display Speaker Name Box (33); Engine Action #9; Branch on Choice (4, 47); Close Dialogue Window; Warp Town -> Area 2 Map 150 Submap 69 at (3,30); Warp to Castle HQ (3, 17, 1); Warp Room -> Submap 60 at (69,1) facing 9; Branch on Choice (8, 42); Animate Door Open; Reset Camera Tracking (9); Open Dialogue Message Window; Full Rest & Healing (Restore HP/MP); Display Choice Selection (255, 254) |
| `ev[18]` | `128 (Loop)` | Story Flag 20 (bit 2) SET AND Story Flag 20 (bit 4) CLEAR AND Inventory Holds Item #1 [Medicine] | Engine Action #89; Close Dialogue Sub-Window (2); Close Dialogue Window; Engine Action #89; Close Dialogue Sub-Window (5); Engine Action #89; Close Dialogue Sub-Window (5); Engine Action #89; Close Dialogue Sub-Window (2); Place Scenery Structure (89); Close Dialogue Sub-Window (5); Engine Action #89; Close Dialogue Sub-Window (5); Engine Action #89; Close Dialogue Sub-Window (2); Animate Door Open; Engine Action #89; Close Dialogue Sub-Window (5); Engine Action #89; Close Dialogue Sub-Window (5); Engine Action #81; Warp Room -> Submap 89 at (24,2) facing 15; Engine Action #89; Close Dialogue Sub-Window (5); Engine Action #89; Close Dialogue Sub-Window (5); Engine Action #89; Close Dialogue Sub-Window (2); Dismiss Dialogue Portrait; Engine Action #80; Warp Room -> Submap 1 at (255,254) facing 255 |
| `ev[19]` | `1 (Action / Talk)` | Story Flag 20 (bit 8) SET AND Story Flag 20 (bit 16) CLEAR AND Player within Box [75..75, 2..19] AND Character #255 Level >= 254 | Recruit Character into Active Party (73 [Kasumi], 60); Close Dialogue Sub-Window (28); Open Dialogue Message Window; Engine Action #58; Engine Action #5; Display Chapter Text (5); Mark NPC Talk Interaction Complete (Flag #4); Warp Town -> Area 7 Map 1 Submap 30 at (24,28); Open Dialogue Message Window; Set obj[5] Collision to Passable; Exit to World Map (5, 3, 27); Dismiss Emotion Bubble (5); Fade Out to Black (5); Screen Fade Transition (0, 0, 5); Engine Action #5; Warp Town -> Area 0 Map 5 Submap 10 at (30,24); Warp Room -> Submap 0 at (60,73); Show Dialogue Portrait (24, 27, 0); Engine Action #61; Engine Action #5; Display Chapter Text (5); Screen Fade Transition (2, 0, 5); Screen Fade Transition (30, 24, 28); Open Dialogue Message Window; Engine Action #62; Set Combat Battle BGM (45); Close Dialogue Sub-Window (27); Open Dialogue Message Window; Engine Action #63; Close Dialogue Window; Warp Town -> Area 2 Map 240 Submap 10 at (19,128); Wait for Audio / Window Sync (3); Set Special Scene BGM (1); Engine Action #102; Warp Room -> Submap 125 at (9,64) facing 125; Display Dialogue Box [Bank: 64, MsgID: 125]; Screen Fade Transition (64, 125, 37); Animate Doorway State (125, 47); Animate Doorway State (125, 35); Animate Doorway State (125, 34); Animate Doorway State (125, 46); Animate Doorway State (125, 36); Animate Doorway State (9, 20); Dismiss Dialogue Portrait; Engine Action #9; Branch on Choice (128, 47); Engine Action #111; Award Potch Loot (+1,283 Potch); Exit to World Map (5, 6, 7); Warp to Castle HQ (255, 4, 13); Engine Action #5; Screen Fade Transition (34, 3, 44); Return to Previous Memory Map (255); Engine Action #5; Engine Action #6; Pan Camera (13, 5, 10); Exit to World Map (0, 66, 51) |

---


