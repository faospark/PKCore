# Suikoden II Geographic Area Catalog: Ancient Sindar Ruins Caverns

**Geographic Scope & Role**: Subterranean ancient Sindar stone temple; sluice gate floodgate puzzles, healing rune pedestals, double-headed water snake boss arena, and ancient treasure chambers.

**Regional Category**: Region `VC` | **Master Maps Included**: `vc06`, `vc07`, `vc08`, `vc12`, `vc13`

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

## Location Map: `vc06`

- **Master Map Container**: `vc06.json`
- **Submap Layer Files**: vc06_04.json, vc06_08.json, vc06_09.json, vc06_13.json, vc06_14.json, vc06_16.json, vc06_18.json, vc06_19.json, vc06_21.json, vc06_22.json, vc06_23.json, vc06_26.json
- **Collision Grid Files**: vc06_map_00.json, vc06_map_01.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 2

### Submap Layer `vc06_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `29` Objects | **Script Count (`evkaz`)**: `100` Scripts

#### Complete Physical Entity Inventory (29 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Leona** | `16` | `(33, 14)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[01]` | Prop / Scenery | **Prop ID 33040** | `33040` | `(32, 22)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | Trigger / Hitbox | **Hitbox Zone (3x4)** | `0` | `(31, 21)` | `2x3` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(60, 88)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(59, 86)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | Trigger / Hitbox | **Hitbox Zone (8x3)** | `0` | `(33, 80)` | `7x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(65, 30)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(62, 30)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(60, 30)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(57, 30)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(54, 30)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Trigger / Hitbox | **Hitbox Zone (2x3)** | `0` | `(37, 23)` | `1x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | Trigger / Hitbox | **Hitbox Zone (2x3)** | `0` | `(37, 19)` | `1x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | Trigger / Hitbox | **Hitbox Zone (2x3)** | `0` | `(37, 21)` | `1x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(9, 43)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[15]` | Trigger / Hitbox | **Hitbox Zone (2x3)** | `0` | `(9, 38)` | `1x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[16]` | Trigger / Hitbox | **Hitbox Zone (2x3)** | `0` | `(9, 36)` | `1x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[17]` | Trigger / Hitbox | **Hitbox Zone (2x3)** | `0` | `(9, 34)` | `1x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[18]` | NPC / Actor | **Actor ID 65085** | `65085` | `(19, 31)` | `3x3` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[19]` | NPC / Actor | **Actor ID 65040** | `65040` | `(33, 52)` | `3x3` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[20]` | NPC / Actor | **Actor ID 65178** | `65178` | `(46, 49)` | `3x3` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[21]` | NPC / Actor | **Actor ID 65226** | `65226` | `(59, 50)` | `3x3` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[22]` | NPC / Actor | **Actor ID 65219** | `65219` | `(76, 43)` | `3x3` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[23]` | NPC / Actor | **Actor ID 65175** | `65175` | `(52, 84)` | `3x3` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[24]` | NPC / Actor | **Actor ID 65085** | `65085` | `(69, 100)` | `3x3` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[25]` | NPC / Actor | **Actor ID 65228** | `65228` | `(18, 69)` | `3x3` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[26]` | NPC / Actor | **Actor ID 65046** | `65046` | `(14, 88)` | `3x3` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[27]` | NPC / Actor | **Actor ID 65104** | `65104` | `(25, 79)` | `3x3` | South (Down) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[28]` | NPC / Actor | **Actor ID 65104** | `65104` | `(25, 23)` | `5x3` | South (Down) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Leona)**: Positioned at tile `(33, 14)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Prop: Object 33040)**: Environmental world dressing prop placed at tile `(32, 22)`. Solid collision is set to `0`.
- **`obj[02]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `4` tiles high from `(31, 21)` to `(33, 24)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[03]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(60, 88)` to `(61, 89)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[04]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(59, 86)` to `(60, 87)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[05]` (Hitbox Zone)**: Bounding trigger area covering `8` tiles wide by `3` tiles high from `(33, 80)` to `(40, 82)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[06]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(65, 30)` to `(67, 31)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[07]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(62, 30)` to `(63, 31)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[08]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(60, 30)` to `(61, 31)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[09]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(57, 30)` to `(58, 31)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[10]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(54, 30)` to `(55, 31)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[11]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `3` tiles high from `(37, 23)` to `(38, 25)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[12]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `3` tiles high from `(37, 19)` to `(38, 21)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[13]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `3` tiles high from `(37, 21)` to `(38, 23)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[14]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(9, 43)` to `(10, 44)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[15]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `3` tiles high from `(9, 38)` to `(10, 40)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[16]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `3` tiles high from `(9, 36)` to `(10, 38)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[17]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `3` tiles high from `(9, 34)` to `(10, 36)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[18]` (Object 65085)**: Positioned at tile `(19, 31)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[19]` (Object 65040)**: Positioned at tile `(33, 52)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[20]` (Object 65178)**: Positioned at tile `(46, 49)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[21]` (Object 65226)**: Positioned at tile `(59, 50)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[22]` (Object 65219)**: Positioned at tile `(76, 43)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[23]` (Object 65175)**: Positioned at tile `(52, 84)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[24]` (Object 65085)**: Positioned at tile `(69, 100)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[25]` (Object 65228)**: Positioned at tile `(18, 69)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[26]` (Object 65046)**: Positioned at tile `(14, 88)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[27]` (Object 65104)**: Positioned at tile `(25, 79)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[28]` (Object 65104)**: Positioned at tile `(25, 23)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.


#### Complete Bytecode Script Catalog (100 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 14 (bit 128) SET AND Story Flag 20 (bit 128) CLEAR | Make obj[0] Hidden (disp = 0); Start Boss Battle #0 (BGM: 36); Teleport obj[255] to (254,255) |
| `ev[01]` | `2 (Map Init)` | Story Flag 23 (bit 1) SET AND Story Flag 23 (bit 128) CLEAR | Make obj[1] Hidden (disp = 0); Start Boss Battle #1 (BGM: 36); Teleport obj[255] to (254,255) |
| `ev[02]` | `2 (Map Init)` | Story Flag 166 (bit 32) SET AND Story Flag 165 (bit 4) CLEAR AND Story Flag 165 (bit 16) CLEAR AND Story Flag 28 (bit 1) CLEAR | Make obj[2] Hidden (disp = 0); Reset Camera Tracking (32); Fade Out to Black (1); Reset Camera Tracking (2); Engine Action #9; Warp Map Transition (22, 89, 9, 2, 0); Open Dialogue Message Window; Engine Action #9; Open Dialogue Message Window; Screen Fade Transition (47, 255, 254) |
| `ev[03]` | `128 (Loop)` | Player within Box [26..37, 2..21] AND Inventory Lacks Item #9 AND Player X within Range [255..254] | Warp Room -> Submap 2 at (12,2) |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [27..95, 2..5] AND Inventory Holds Item #9 [Kindness Drops] AND Player X within Range [255..254] | Warp Room -> Submap 2 at (12,2); Warp Map Transition (0, 0, 169, 171, 255) |
| `ev[05]` | `1 (Action / Talk)` | Player within Box [93..94, 2..6] AND Condition Check #102 AND Story Flag 3 (mask 255) SET | Warp Room -> Submap 2 at (12,2); Warp Map Transition (0, 0, 169, 171, 255) |
| `ev[06]` | `1 (Action / Talk)` | Player within Box [8..16, 2..26] AND Treasure Byte 9 Bit 1 LOOTED | Display Dialogue Box [Bank: 1, MsgID: 96]; Engine Action #58 |
| `ev[07]` | `1 (Action / Talk)` | Player within Box [20..24, 2..21] AND Inventory Lacks Item #9 AND Player X within Range [255..254] | Display Dialogue Box [Bank: 1, MsgID: 114]; Engine Action #40 |
| `ev[08]` | `1 (Action / Talk)` | Story Flag 15 (bit 2) CLEAR AND Player within Box [42..46, 2..29] AND Condition Check #30 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 158]; Set Animation Pose (255, 254) |
| `ev[09]` | `1 (Action / Talk)` | Story Flag 15 (bit 2) SET AND Story Flag 15 (bit 4) CLEAR AND Player within Box [42..46, 2..29] AND Condition Check #30 AND Story Flag 1 (mask 255) SET | Wait for Audio / Window Sync (2); Display Dialogue Box [Bank: 1, MsgID: 158]; Trigger Character Emotion Effect (255, 254) |
| `ev[10]` | `1 (Action / Talk)` | Story Flag 15 (bit 4) SET AND Player within Box [42..46, 2..29] AND Condition Check #30 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 158]; Set Animation Pose (255, 254) |
| `ev[11]` | `1 (Action / Talk)` | Story Flag 21 (bit 1) CLEAR AND Player within Box [42..48, 2..43] AND Condition Check #44 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 160]; Engine Action #116 |
| `ev[12]` | `1 (Action / Talk)` | Story Flag 21 (bit 1) CLEAR AND Player within Box [50..56, 2..43] AND Condition Check #44 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 176]; Engine Action #116 |
| `ev[13]` | `1 (Action / Talk)` | Story Flag 21 (bit 1) SET AND Story Flag 21 (bit 2) CLEAR AND Player within Box [42..56, 2..43] AND Condition Check #44 AND Story Flag 1 (mask 255) SET | Wait for Audio / Window Sync (2); Display Dialogue Box [Bank: 1, MsgID: 172]; Engine Action #121 |
| `ev[14]` | `1 (Action / Talk)` | Story Flag 21 (bit 2) SET AND Player within Box [42..48, 2..43] AND Condition Check #44 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 160]; Engine Action #116 |
| `ev[15]` | `1 (Action / Talk)` | Story Flag 21 (bit 2) SET AND Player within Box [50..56, 2..43] AND Condition Check #44 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 176]; Engine Action #116 |
| `ev[16]` | `1 (Action / Talk)` | Player within Box [18..22, 2..61] AND Condition Check #62 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 56]; Turn obj[255] facing 254 |
| `ev[17]` | `1 (Action / Talk)` | Player within Box [64..68, 2..69] AND Condition Check #70 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 30]; Clear Story Milestone Flag 255 (mask 254) |
| `ev[18]` | `128 (Loop)` | Player within Box [15..31, 2..76] AND Condition Check #77 AND Story Flag 0 (mask 255) SET | Warp Room -> Submap 1 at (2,16) |
| `ev[19]` | `128 (Loop)` | Player within Box [45..51, 2..63] AND Condition Check #64 AND Story Flag 0 (mask 255) SET | Warp Room -> Submap 1 at (2,16) |
| `ev[20]` | `1 (Action / Talk)` | Player within Box [58..74, 2..107] AND Condition Check #108 AND Story Flag 0 (mask 255) SET | Warp Room -> Submap 1 at (2,16); Set Special Scene BGM (1); Warp Map Transition (2, 250, 0, 0, 255) |
| `ev[21]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) SET AND Story Flag 15 (bit 1) CLEAR AND Player within Box [33..33, 2..8] AND Temp Event Flag #9 CLEAR AND Always Passes (Unconditional) | Recruit Character into Active Party (33 [Camus], 2); Display Speaker Name Box (124); Make obj[0] Hidden (disp = 0); Warp Room -> Submap 2 at (47,49) facing Up (North); Engine Action #5; Warp Room -> Submap 5 at (3,3) facing South (Down); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp Town -> Area 0 Map 5 Submap 15 at (30,255); Engine Action #5; Warp Town -> Area 4 Map 5 Submap 0 at (2,3); Warp Room -> Submap 0 at (30,255) facing 254; Walk obj[24] to (1,1); Open Dialogue Message Window; Set Combat Battle BGM (15); Close Dialogue Sub-Window (2); Warp Room -> Submap 5 at (1,5) facing 15; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 24, 1); Warp Room -> Submap 73 at (30,39) facing 34; Engine Action #9; Show Dialogue Portrait (1, 58, 255) |
| `ev[22]` | `1 (Action / Talk)` | Story Flag 165 (bit 4) CLEAR AND Story Flag 165 (bit 16) CLEAR AND Story Flag 28 (bit 1) CLEAR AND Target Inspected is obj[10] | Recruit Character into Active Party (84 [Bonaparte], 16); Dismiss Emotion Bubble (73); Dismiss Emotion Bubble (24); Reset Camera Tracking (2); Engine Action #5; Set Combat Battle BGM (30); Set Combat Battle BGM (20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp to Castle HQ (2, 8, 2); Engine Action #6; Warp Town -> Area 7 Map 73 Submap 15 at (41,3); Open Dialogue Message Window; Warp Room -> Submap 255 at (0,24) facing 8; Warp Town -> Area 9 Map 51 Submap 2 at (255,1); Close Dialogue Sub-Window (8); Warp Town -> Area 10 Map 73 Submap 15 at (73,20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 2 Map 11 Submap 2 at (12,73); Show Dialogue Portrait (101, 0, 204); Set Combat Battle BGM (15); Close Dialogue Sub-Window (8); Warp Town -> Area 13 Map 73 Submap 15 at (73,20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 2 Map 15 Submap 2 at (14,73); Show Dialogue Portrait (41, 2, 3); Exit to World Map (255, 3, 24); Reset Camera Tracking (2); Dismiss Dialogue Portrait; Engine Action #51; Warp Town -> Area 255 Map 4 Submap 24 at (8,2); Change Portrait Expression (73); Show Dialogue Portrait (11, 2, 2); Mark NPC Talk Interaction Complete (Flag #9); Display Chapter Text (1); Wait for Audio / Window Sync (3); Warp to Castle HQ (0, 3, 12); Warp Room -> Submap 108 at (255,2) facing 58 |
| `ev[23]` | `1 (Action / Talk)` | Story Flag 171 (bit 1) CLEAR AND Story Flag 28 (bit 4) SET AND Story Flag 28 (bit 8) CLEAR AND Player within Box [51..51, 2..48] AND Condition Check #48 AND Story Flag 3 (mask 255) SET | Recruit Character into Active Party (46 [Oulan], 2); Reset Camera Tracking (55); Turn obj[3] facing 8; Warp Town -> Area 0 Map 8 Submap 47 at (11,1); Warp Town -> Area 100 Map 73 Submap 30 at (24,8); Warp Town -> Area 38 Map 46 Submap 115 at (16,8); Dismiss Character to Castle Base (16 [Rikimaru]); Warp Room -> Submap 47 at (5,0); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 101, 4); Engine Action #6; Engine Action #5; Open Dialogue Message Window; Warp Town -> Area 0 Map 5 Submap 3 at (1,0); Engine Action #5; Warp to Castle HQ (3, 0, 5); Warp to Castle HQ (0, 0, 5); Warp to Castle HQ (30, 89, 0); Warp Town -> Area 8 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Engine Action #89; Open Dialogue Message Window; Warp Town -> Area 9 Map 5 Submap 0 at (6,2); Dismiss Emotion Bubble (89); Open Dialogue Message Window; Warp Town -> Area 10 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Dismiss Emotion Bubble (0); Warp Room -> Submap 5 at (0,0) facing South (Down); Engine Action #5; Show Dialogue Portrait (3, 0, 30); Set Combat Battle BGM (15); Close Dialogue Sub-Window (8); Warp Town -> Area 39 Map 73 Submap 15 at (72,1); Open Dialogue Message Window; Exit to World Map (73, 15, 72); Open Dialogue Message Window; Open Dialogue Message Window; Close Dialogue Window; Warp Town -> Area 2 Map 40 Submap 1 at (8,3); Open Dialogue Message Window; Open Dialogue Message Window; Close Dialogue Window; Warp Room -> Submap 40 at (9,28) facing 8; Engine Action #58 |
| `ev[24]` | `1 (Action / Talk)` | Story Flag 171 (bit 1) SET AND Story Flag 28 (bit 4) SET AND Story Flag 28 (bit 8) CLEAR AND Player within Box [51..51, 2..48] AND Condition Check #48 AND Story Flag 3 (mask 255) SET | Recruit Character into Active Party (46 [Oulan], 2); Reset Camera Tracking (55); Turn obj[3] facing 8; Warp Town -> Area 0 Map 8 Submap 47 at (11,1); Warp Town -> Area 100 Map 73 Submap 30 at (24,8); Warp Town -> Area 40 Map 46 Submap 84 at (16,30); Dismiss Character to Castle Base (16 [Rikimaru]); Warp Room -> Submap 47 at (5,0); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 101, 4); Engine Action #6; Engine Action #5; Open Dialogue Message Window; Warp Town -> Area 0 Map 5 Submap 3 at (1,0); Engine Action #5; Warp to Castle HQ (3, 0, 5); Warp to Castle HQ (0, 0, 5); Warp to Castle HQ (30, 89, 0); Warp Town -> Area 8 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Engine Action #89; Open Dialogue Message Window; Warp Town -> Area 9 Map 5 Submap 0 at (6,2); Dismiss Emotion Bubble (89); Open Dialogue Message Window; Warp Town -> Area 10 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Dismiss Emotion Bubble (0); Warp Room -> Submap 5 at (0,0) facing South (Down); Engine Action #5; Show Dialogue Portrait (3, 0, 30); Set Combat Battle BGM (15); Close Dialogue Sub-Window (8); Warp Town -> Area 41 Map 73 Submap 15 at (72,1); Open Dialogue Message Window; Exit to World Map (73, 15, 72); Open Dialogue Message Window; Open Dialogue Message Window; Close Dialogue Window; Warp Town -> Area 2 Map 40 Submap 1 at (8,3); Open Dialogue Message Window; Open Dialogue Message Window; Close Dialogue Window; Warp Room -> Submap 40 at (9,28) facing 8; Engine Action #58 |
| `ev[25]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) CLEAR AND Target Inspected is obj[26] | Open Dialogue Sub-Window (5); Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[26]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) SET AND Story Flag 17 (bit 16) CLEAR AND Target Inspected is obj[26] | Open Dialogue Sub-Window (7); Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[27]` | `1 (Action / Talk)` | Story Flag 17 (bit 16) SET AND Story Flag 124 (bit 16) CLEAR AND Target Inspected is obj[26] | Open Dialogue Sub-Window (8); Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[28]` | `1 (Action / Talk)` | Story Flag 124 (bit 16) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[26] | Open Dialogue Sub-Window (9); Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[29]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[26] | Open Dialogue Sub-Window (10); Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[30]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[26] | Open Dialogue Sub-Window (11); Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[31]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) CLEAR AND Target Inspected is obj[27] | Open Dialogue Sub-Window (5); Warp Town -> Area 255 Map 254 Submap 255 at (254,204) |
| `ev[32]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) SET AND Story Flag 17 (bit 16) CLEAR AND Target Inspected is obj[27] | Open Dialogue Sub-Window (7); Warp Town -> Area 255 Map 254 Submap 255 at (254,204) |
| `ev[33]` | `1 (Action / Talk)` | Story Flag 17 (bit 16) SET AND Story Flag 124 (bit 16) CLEAR AND Target Inspected is obj[27] | Open Dialogue Sub-Window (8); Warp Town -> Area 255 Map 254 Submap 255 at (254,204) |
| `ev[34]` | `1 (Action / Talk)` | Story Flag 124 (bit 16) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[27] | Open Dialogue Sub-Window (9); Warp Town -> Area 255 Map 254 Submap 255 at (254,204) |
| `ev[35]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[27] | Open Dialogue Sub-Window (10); Warp Town -> Area 255 Map 254 Submap 255 at (254,204) |
| `ev[36]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[27] | Open Dialogue Sub-Window (11); Warp Town -> Area 255 Map 254 Submap 255 at (254,204) |
| `ev[37]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) CLEAR AND Target Inspected is obj[28] | Open Dialogue Sub-Window (5); Warp to Castle HQ (255, 254, 255) |
| `ev[38]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) SET AND Story Flag 17 (bit 16) CLEAR AND Target Inspected is obj[28] | Open Dialogue Sub-Window (7); Warp to Castle HQ (255, 254, 255) |
| `ev[39]` | `1 (Action / Talk)` | Story Flag 17 (bit 16) SET AND Story Flag 124 (bit 16) CLEAR AND Target Inspected is obj[28] | Open Dialogue Sub-Window (8); Warp to Castle HQ (255, 254, 255) |
| `ev[40]` | `1 (Action / Talk)` | Story Flag 124 (bit 16) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[28] | Open Dialogue Sub-Window (9); Warp to Castle HQ (255, 254, 255) |
| `ev[41]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[28] | Open Dialogue Sub-Window (10); Warp to Castle HQ (255, 254, 255) |
| `ev[42]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[28] | Open Dialogue Sub-Window (11); Warp to Castle HQ (255, 254, 255) |
| `ev[43]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) CLEAR AND Target Inspected is obj[29] | Open Dialogue Sub-Window (5); Exit to World Map (255, 254, 255) |
| `ev[44]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) SET AND Story Flag 17 (bit 16) CLEAR AND Target Inspected is obj[29] | Open Dialogue Sub-Window (7); Exit to World Map (255, 254, 255) |
| `ev[45]` | `1 (Action / Talk)` | Story Flag 17 (bit 16) SET AND Story Flag 124 (bit 16) CLEAR AND Target Inspected is obj[29] | Open Dialogue Sub-Window (8); Exit to World Map (255, 254, 255) |
| `ev[46]` | `1 (Action / Talk)` | Story Flag 124 (bit 16) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[29] | Open Dialogue Sub-Window (9); Exit to World Map (255, 254, 255) |
| `ev[47]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[29] | Open Dialogue Sub-Window (10); Exit to World Map (255, 254, 255) |
| `ev[48]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[29] | Open Dialogue Sub-Window (11); Exit to World Map (255, 254, 255) |
| `ev[49]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) CLEAR AND Target Inspected is obj[30] | Open Dialogue Sub-Window (5); Engine Action #5 |
| `ev[50]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) SET AND Story Flag 17 (bit 16) CLEAR AND Target Inspected is obj[30] | Open Dialogue Sub-Window (7); Engine Action #5 |
| `ev[51]` | `1 (Action / Talk)` | Story Flag 17 (bit 16) SET AND Story Flag 124 (bit 16) CLEAR AND Target Inspected is obj[30] | Open Dialogue Sub-Window (8); Engine Action #5 |
| `ev[52]` | `1 (Action / Talk)` | Story Flag 124 (bit 16) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[30] | Open Dialogue Sub-Window (9); Engine Action #5 |
| `ev[53]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[30] | Open Dialogue Sub-Window (10); Engine Action #5 |
| `ev[54]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[30] | Open Dialogue Sub-Window (11); Engine Action #5 |
| `ev[55]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) CLEAR AND Target Inspected is obj[31] | Open Dialogue Sub-Window (5); Engine Action #6 |
| `ev[56]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) SET AND Story Flag 17 (bit 16) CLEAR AND Target Inspected is obj[31] | Open Dialogue Sub-Window (7); Engine Action #6 |
| `ev[57]` | `1 (Action / Talk)` | Story Flag 17 (bit 16) SET AND Story Flag 124 (bit 16) CLEAR AND Target Inspected is obj[31] | Open Dialogue Sub-Window (8); Engine Action #6 |
| `ev[58]` | `1 (Action / Talk)` | Story Flag 124 (bit 16) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[31] | Open Dialogue Sub-Window (9); Engine Action #6 |
| `ev[59]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[31] | Open Dialogue Sub-Window (10); Engine Action #6 |
| `ev[60]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[31] | Open Dialogue Sub-Window (11); Engine Action #6 |
| `ev[61]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) CLEAR AND Target Inspected is obj[32] | Open Dialogue Sub-Window (5); Pan Camera (255, 254, 255) |
| `ev[62]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) SET AND Story Flag 17 (bit 16) CLEAR AND Target Inspected is obj[32] | Open Dialogue Sub-Window (7); Pan Camera (255, 254, 255) |
| `ev[63]` | `1 (Action / Talk)` | Story Flag 17 (bit 16) SET AND Story Flag 124 (bit 16) CLEAR AND Target Inspected is obj[32] | Open Dialogue Sub-Window (8); Pan Camera (255, 254, 255) |
| `ev[64]` | `1 (Action / Talk)` | Story Flag 124 (bit 16) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[32] | Open Dialogue Sub-Window (9); Pan Camera (255, 254, 255) |
| `ev[65]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[32] | Open Dialogue Sub-Window (10); Pan Camera (255, 254, 255) |
| `ev[66]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[32] | Open Dialogue Sub-Window (11); Pan Camera (255, 254, 255) |
| `ev[67]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) CLEAR AND Target Inspected is obj[33] | Open Dialogue Sub-Window (5); Reset Camera Tracking (255) |
| `ev[68]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) SET AND Story Flag 17 (bit 16) CLEAR AND Target Inspected is obj[33] | Open Dialogue Sub-Window (7); Reset Camera Tracking (255) |
| `ev[69]` | `1 (Action / Talk)` | Story Flag 17 (bit 16) SET AND Story Flag 124 (bit 16) CLEAR AND Target Inspected is obj[33] | Open Dialogue Sub-Window (8); Reset Camera Tracking (255) |
| `ev[70]` | `1 (Action / Talk)` | Story Flag 124 (bit 16) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[33] | Open Dialogue Sub-Window (9); Reset Camera Tracking (255) |
| `ev[71]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[33] | Open Dialogue Sub-Window (10); Reset Camera Tracking (255) |
| `ev[72]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[33] | Open Dialogue Sub-Window (11); Reset Camera Tracking (255) |
| `ev[73]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) CLEAR AND Target Inspected is obj[34] | Open Dialogue Sub-Window (5); Engine Action #9 |
| `ev[74]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) SET AND Story Flag 17 (bit 16) CLEAR AND Target Inspected is obj[34] | Open Dialogue Sub-Window (7); Engine Action #9 |
| `ev[75]` | `1 (Action / Talk)` | Story Flag 17 (bit 16) SET AND Story Flag 124 (bit 16) CLEAR AND Target Inspected is obj[34] | Open Dialogue Sub-Window (8); Engine Action #9 |
| `ev[76]` | `1 (Action / Talk)` | Story Flag 124 (bit 16) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[34] | Open Dialogue Sub-Window (9); Engine Action #9 |
| `ev[77]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[34] | Open Dialogue Sub-Window (10); Engine Action #9 |
| `ev[78]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[34] | Open Dialogue Sub-Window (11); Engine Action #9 |
| `ev[79]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) SET AND Story Flag 17 (bit 16) CLEAR AND Target Inspected is obj[35] | Engine Action #119; Warp to Castle HQ (8, 7, 50) |
| `ev[80]` | `1 (Action / Talk)` | Story Flag 17 (bit 16) SET AND Story Flag 124 (bit 16) CLEAR AND Target Inspected is obj[35] | Engine Action #119; Warp to Castle HQ (8, 8, 50) |
| `ev[81]` | `1 (Action / Talk)` | Story Flag 124 (bit 16) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[35] | Engine Action #119; Warp to Castle HQ (8, 9, 50) |
| `ev[82]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) SET AND Story Flag 17 (bit 16) CLEAR AND Target Inspected is obj[36] | Engine Action #119; Warp to Castle HQ (8, 7, 51) |
| `ev[83]` | `1 (Action / Talk)` | Story Flag 17 (bit 16) SET AND Story Flag 124 (bit 16) CLEAR AND Target Inspected is obj[36] | Engine Action #119; Warp to Castle HQ (8, 8, 51) |
| `ev[84]` | `1 (Action / Talk)` | Story Flag 124 (bit 16) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[36] | Engine Action #119; Warp to Castle HQ (8, 9, 51) |
| `ev[85]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Open Dialogue Sub-Window (6); Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[86]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Open Dialogue Sub-Window (6); Warp Town -> Area 255 Map 254 Submap 255 at (254,204) |
| `ev[87]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Open Dialogue Sub-Window (6); Warp to Castle HQ (255, 254, 255) |
| `ev[88]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Open Dialogue Sub-Window (6); Exit to World Map (255, 254, 255) |
| `ev[89]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Open Dialogue Sub-Window (6); Engine Action #5 |
| `ev[90]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Open Dialogue Sub-Window (6); Engine Action #6 |
| `ev[91]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Open Dialogue Sub-Window (6); Pan Camera (255, 254, 255) |
| `ev[92]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Open Dialogue Sub-Window (6); Reset Camera Tracking (255) |
| `ev[93]` | `1 (Action / Talk)` | Target Inspected is obj[19] | Open Dialogue Sub-Window (6); Engine Action #9 |
| `ev[94]` | `1 (Action / Talk)` | Target Inspected is obj[20] | Open Dialogue Sub-Window (6); Screen Fade Transition (255, 254, 255) |
| `ev[95]` | `1 (Action / Talk)` | Target Inspected is obj[21] | Open Dialogue Sub-Window (6); Close Dialogue Window |
| `ev[96]` | `1 (Action / Talk)` | Target Inspected is obj[22] | Open Dialogue Sub-Window (6); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[97]` | `1 (Action / Talk)` | Target Inspected is obj[23] | Open Dialogue Sub-Window (6); Place Scenery Structure (255) |
| `ev[98]` | `1 (Action / Talk)` | Target Inspected is obj[24] | Open Dialogue Sub-Window (6); Animate Door Open |
| `ev[99]` | `1 (Action / Talk)` | Target Inspected is obj[25] | Open Dialogue Sub-Window (6); Show Dialogue Portrait (255, 254, 255) |

---

### Submap Layer `vc06_01` (Index 1)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `86` Objects | **Script Count (`evkaz`)**: `193` Scripts

#### Complete Physical Entity Inventory (86 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Eilie** | `19` | `(33, 14)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Rina** | `20` | `(33, 14)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Actor ID 53523** | `53523` | `(172, 112)` | `0x0` | Up (North) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(171, 109)` | `2x1` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | NPC / Actor | **Actor ID 53524** | `53524` | `(164, 112)` | `0x0` | East (Right) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[05]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(163, 109)` | `2x1` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | NPC / Actor | **Bolgan** | `21` | `(33, 14)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[07]` | NPC / Actor | **Leona** | `16` | `(33, 14)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[08]` | Prop / Scenery | **Prop ID 33040** | `33040` | `(32, 22)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[09]` | NPC / Actor | **Actor ID 65228** | `65228` | `(92, 46)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[10]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(91, 47)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | NPC / Actor | **Actor ID 65234** | `65234` | `(29, 34)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[12]` | NPC / Actor | **Actor ID 65072** | `65072` | `(192, 86)` | `0x0` | East (Right) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[13]` | NPC / Actor | **Actor ID 65085** | `65085` | `(155, 98)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | NPC / Actor | **Actor ID 65060** | `65060` | `(156, 48)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[15]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(155, 49)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[16]` | Trigger / Hitbox | **Hitbox Zone (2x3)** | `0` | `(159, 46)` | `1x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[17]` | Prop / Scenery | **Prop ID 33040** | `33040` | `(32, 22)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 180 |
| `obj[18]` | Prop / Scenery | **Prop ID 33040** | `33040` | `(32, 22)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 180 |
| `obj[19]` | World Device | **Mechanism (ano 22)** | `0` | `(167, 114)` | `0x0` | Frame 22 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 180 |
| `obj[20]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(87, 40)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[21]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(91, 40)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[22]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(99, 48)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[23]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(103, 48)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[24]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(109, 28)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[25]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(121, 28)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[26]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(189, 30)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[27]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(191, 30)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[28]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(194, 30)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[29]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(198, 30)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[30]` | Trigger / Hitbox | **Hitbox Zone (2x5)** | `0` | `(167, 44)` | `1x4` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[31]` | Trigger / Hitbox | **Hitbox Zone (2x5)** | `0` | `(185, 44)` | `1x4` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[32]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(154, 42)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[33]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(154, 115)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[34]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(182, 115)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[35]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(167, 86)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[36]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(171, 86)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[37]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(177, 88)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[38]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(181, 92)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[39]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(179, 88)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[40]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(187, 84)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[41]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(199, 85)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[42]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(196, 110)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[43]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(196, 108)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[44]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(198, 112)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[45]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(198, 116)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[46]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(189, 116)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[47]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(187, 114)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[48]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(31, 31)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[49]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(25, 28)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[50]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(25, 32)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[51]` | Trigger / Hitbox | **Hitbox Zone (5x3)** | `0` | `(23, 36)` | `4x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[52]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(39, 30)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[53]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(39, 28)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[54]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(43, 28)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[55]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(47, 28)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[56]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(40, 38)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[57]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(58, 38)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[58]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(37, 41)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[59]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(41, 41)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[60]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(53, 42)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[61]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(57, 44)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[62]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(23, 82)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[63]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(31, 82)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[64]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(41, 83)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[65]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(61, 88)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[66]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(49, 102)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[67]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(53, 102)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[68]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(181, 90)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[69]` | NPC / Actor | **Actor ID 65203** | `65203` | `(122, 31)` | `3x3` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[70]` | NPC / Actor | **Actor ID 65042** | `65042` | `(89, 31)` | `3x3` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[71]` | NPC / Actor | **Actor ID 65029** | `65029` | `(93, 31)` | `3x3` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[72]` | NPC / Actor | **Actor ID 65178** | `65178` | `(176, 46)` | `3x3` | South (Down) | Visible (1) | Special (3) | 3 | 255 | 0 |
| `obj[73]` | NPC / Actor | **Actor ID 65046** | `65046` | `(168, 89)` | `3x3` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[74]` | NPC / Actor | **Actor ID 64932** | `64932` | `(157, 107)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[75]` | NPC / Actor | **Actor ID 65037** | `65037` | `(175, 111)` | `6x6` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[76]` | NPC / Actor | **Actor ID 64554** | `64554` | `(200, 97)` | `0x0` | West (Left) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[77]` | NPC / Actor | **Actor ID 65085** | `65085` | `(199, 92)` | `3x3` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[78]` | NPC / Actor | **Actor ID 65226** | `65226` | `(54, 34)` | `3x3` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[79]` | NPC / Actor | **Actor ID 65234** | `65234` | `(26, 49)` | `3x3` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[80]` | NPC / Actor | **Actor ID 65042** | `65042` | `(53, 128)` | `3x3` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[81]` | NPC / Actor | **Actor ID 65065** | `65065` | `(61, 107)` | `3x3` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[82]` | NPC / Actor | **Actor ID 64937** | `64937` | `(57, 113)` | `0x0` | West (Left) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[83]` | NPC / Actor | **Actor ID 65072** | `65072` | `(58, 86)` | `3x3` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[84]` | NPC / Actor | **Actor ID 65039** | `65039` | `(31, 85)` | `3x3` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[85]` | NPC / Actor | **Actor ID 65104** | `65104` | `(193, 45)` | `3x5` | South (Down) | Dormant / Hidden (0) | Special (3) | 3 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Eilie)**: Positioned at tile `(33, 14)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Rina)**: Positioned at tile `(33, 14)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Object 53523)**: Positioned at tile `(172, 112)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(171, 109)` to `(173, 110)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[04]` (Object 53524)**: Positioned at tile `(164, 112)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(163, 109)` to `(165, 110)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[06]` (Bolgan)**: Positioned at tile `(33, 14)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[07]` (Leona)**: Positioned at tile `(33, 14)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[08]` (Prop: Object 33040)**: Environmental world dressing prop placed at tile `(32, 22)`. Solid collision is set to `2`.
- **`obj[09]` (Object 65228)**: Positioned at tile `(92, 46)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[10]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(91, 47)` to `(93, 48)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[11]` (Object 65234)**: Positioned at tile `(29, 34)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[12]` (Object 65072)**: Positioned at tile `(192, 86)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[13]` (Object 65085)**: Positioned at tile `(155, 98)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[14]` (Object 65060)**: Positioned at tile `(156, 48)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[15]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(155, 49)` to `(157, 50)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[16]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `3` tiles high from `(159, 46)` to `(160, 48)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[17]` (Prop: Object 33040)**: Environmental world dressing prop placed at tile `(32, 22)`. Solid collision is set to `2`.
- **`obj[18]` (Prop: Object 33040)**: Environmental world dressing prop placed at tile `(32, 22)`. Solid collision is set to `2`.
- **`obj[19]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(167, 114)` with state parameter `22`.
- **`obj[20]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(87, 40)` to `(90, 41)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[21]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(91, 40)` to `(94, 41)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[22]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(99, 48)` to `(102, 49)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[23]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(103, 48)` to `(106, 49)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[24]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(109, 28)` to `(112, 29)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[25]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(121, 28)` to `(124, 29)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[26]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(189, 30)` to `(190, 31)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[27]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(191, 30)` to `(193, 31)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[28]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(194, 30)` to `(196, 31)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[29]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(198, 30)` to `(199, 31)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[30]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `5` tiles high from `(167, 44)` to `(168, 48)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[31]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `5` tiles high from `(185, 44)` to `(186, 48)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[32]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(154, 42)` to `(155, 43)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[33]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(154, 115)` to `(155, 116)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[34]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(182, 115)` to `(183, 116)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[35]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(167, 86)` to `(170, 87)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[36]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(171, 86)` to `(174, 87)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[37]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(177, 88)` to `(179, 89)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[38]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(181, 92)` to `(183, 94)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[39]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(179, 88)` to `(181, 89)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[40]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(187, 84)` to `(190, 85)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[41]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(199, 85)` to `(202, 86)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[42]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(196, 110)` to `(198, 111)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[43]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(196, 108)` to `(198, 110)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[44]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(198, 112)` to `(200, 114)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[45]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(198, 116)` to `(200, 118)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[46]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(189, 116)` to `(190, 117)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[47]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(187, 114)` to `(188, 115)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[48]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(31, 31)` to `(34, 32)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[49]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(25, 28)` to `(26, 29)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[50]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(25, 32)` to `(26, 33)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[51]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `3` tiles high from `(23, 36)` to `(27, 38)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[52]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(39, 30)` to `(40, 31)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[53]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(39, 28)` to `(42, 29)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[54]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(43, 28)` to `(46, 29)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[55]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(47, 28)` to `(50, 29)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[56]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(40, 38)` to `(41, 39)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[57]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(58, 38)` to `(59, 39)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[58]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(37, 41)` to `(39, 42)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[59]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(41, 41)` to `(43, 42)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[60]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(53, 42)` to `(55, 43)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[61]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(57, 44)` to `(59, 45)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[62]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(23, 82)` to `(26, 83)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[63]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(31, 82)` to `(34, 83)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[64]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(41, 83)` to `(44, 84)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[65]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(61, 88)` to `(63, 89)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[66]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(49, 102)` to `(52, 103)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[67]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(53, 102)` to `(56, 103)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[68]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(181, 90)` to `(183, 92)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[69]` (Object 65203)**: Positioned at tile `(122, 31)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[70]` (Object 65042)**: Positioned at tile `(89, 31)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[71]` (Object 65029)**: Positioned at tile `(93, 31)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[72]` (Object 65178)**: Positioned at tile `(176, 46)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[73]` (Object 65046)**: Positioned at tile `(168, 89)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[74]` (Object 64932)**: Positioned at tile `(157, 107)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[75]` (Object 65037)**: Positioned at tile `(175, 111)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[76]` (Object 64554)**: Positioned at tile `(200, 97)`, facing West (Left). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[77]` (Object 65085)**: Positioned at tile `(199, 92)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[78]` (Object 65226)**: Positioned at tile `(54, 34)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[79]` (Object 65234)**: Positioned at tile `(26, 49)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[80]` (Object 65042)**: Positioned at tile `(53, 128)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[81]` (Object 65065)**: Positioned at tile `(61, 107)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[82]` (Object 64937)**: Positioned at tile `(57, 113)`, facing West (Left). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[83]` (Object 65072)**: Positioned at tile `(58, 86)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[84]` (Object 65039)**: Positioned at tile `(31, 85)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[85]` (Object 65104)**: Positioned at tile `(193, 45)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.


#### Complete Bytecode Script Catalog (193 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 14 (bit 128) SET AND Story Flag 20 (bit 128) CLEAR | Make obj[0] Hidden (disp = 0); Engine Action #93; Teleport obj[255] to (254,255) |
| `ev[01]` | `2 (Map Init)` | Story Flag 23 (bit 1) SET AND Story Flag 23 (bit 128) CLEAR | Make obj[1] Hidden (disp = 0); Engine Action #93; Teleport obj[255] to (254,255) |
| `ev[02]` | `2 (Map Init)` | Story Flag 17 (bit 16) SET | Make obj[1] Hidden (disp = 0); Engine Action #80; Teleport obj[255] to (254,255) |
| `ev[03]` | `2 (Map Init)` | Story Flag 15 (bit 2) SET AND Story Flag 15 (bit 4) CLEAR | Make obj[0] Hidden (disp = 0); Execute Choice Result (47) |
| `ev[04]` | `2 (Map Init)` | Story Flag 21 (bit 1) SET AND Story Flag 21 (bit 2) CLEAR | Make obj[2] Hidden (disp = 0); Execute Choice Result (156); Award Potch Loot (+21 Potch); Warp to Castle HQ (21, 0, 47) |
| `ev[05]` | `2 (Map Init)` | Story Flag 15 (bit 4) SET AND Story Flag 21 (bit 2) CLEAR | Make obj[2] Hidden (disp = 0); Reset Camera Tracking (172); Pathfind and Walk to Coordinates (1, 8, 2); Engine Action #9; Engine Action #164; Pathfind and Walk to Coordinates (1, 9, 0); Screen Fade Transition (0, 11, 0); Display Dialogue Box [Bank: 0, MsgID: 13]; Warp Town -> Area 14 Map 167 Submap 103 at (0,14); Warp to Castle HQ (14, 0, 47) |
| `ev[06]` | `2 (Map Init)` | Story Flag 28 (bit 2) SET AND Story Flag 28 (bit 4) CLEAR | Make obj[2] Hidden (disp = 0); Show Dialogue Portrait (200, 88, 0); Show Dialogue Portrait (3, 15, 1); Load Sound Bank into Memory (1, 15); Engine Action #9; Warp Town -> Area 20 Map 199 Submap 90 at (0,20); Warp to Castle HQ (20, 1, 47) |
| `ev[07]` | `1 (Action / Talk)` | Player within Box [88..104, 2..61] AND Condition Check #62 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 12]; Dismiss Emotion Bubble (255) |
| `ev[08]` | `1 (Action / Talk)` | Player within Box [112..116, 2..43] AND Condition Check #44 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 22]; Close Dialogue Sub-Window (255) |
| `ev[09]` | `1 (Action / Talk)` | Player within Box [156..160, 2..59] AND Condition Check #60 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 44]; Warp Map Transition (255, 254, 204, 204, 204) |
| `ev[10]` | `1 (Action / Talk)` | Player within Box [152..157, 2..40] AND Condition Check #41 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 155]; Teleport Object to Coordinates (255, 254, 204) |
| `ev[11]` | `1 (Action / Talk)` | Player within Box [152..158, 2..96] AND Condition Check #97 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 155]; Return Warp to Castle Base (255, 254) |
| `ev[12]` | `1 (Action / Talk)` | Player within Box [154..166, 2..119] AND Condition Check #120 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 45]; Teleport obj[255] to (254,204) |
| `ev[13]` | `1 (Action / Talk)` | Player within Box [170..182, 2..119] AND Condition Check #120 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 53]; Teleport obj[255] to (254,204) |
| `ev[14]` | `1 (Action / Talk)` | Player within Box [54..58, 2..51] AND Condition Check #52 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 20]; Animate Doorway State (255, 254) |
| `ev[15]` | `1 (Action / Talk)` | Player within Box [28..32, 2..99] AND Condition Check #100 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 65]; Load Sound Bank into Memory (255, 254) |
| `ev[16]` | `1 (Action / Talk)` | Story Flag 15 (bit 2) SET AND Story Flag 15 (bit 4) CLEAR AND Player within Box [152..158, 2..101] AND Condition Check #102 AND Story Flag 1 (mask 255) SET | Recruit Character into Active Party (5 [Sheena], 21); Warp to Castle HQ (0, 5, 5); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 24, 21); Display Dialogue Box [Bank: 1, MsgID: 73]; Show Dialogue Portrait (49, 2, 5); Execute Choice Result (2); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp Room -> Submap 30 at (255,254) facing 5; Open Dialogue Message Window; Warp to Castle HQ (0, 5, 5); Exit to World Map (4, 0, 2); Dismiss Emotion Bubble (255); Walk obj[58] to (255,254) |
| `ev[17]` | `1 (Action / Talk)` | Story Flag 15 (bit 2) SET AND Story Flag 15 (bit 4) CLEAR AND Player within Box [158..158, 2..60] AND Condition Check #60 AND Story Flag 1 (mask 255) SET | Recruit Character into Active Party (33 [Camus], 2); Display Speaker Name Box (124); Make obj[2] Hidden (disp = 0); Reset Camera Tracking (189); Make obj[0] Hidden (disp = 0); Reset Camera Tracking (3); Reset Camera Tracking (1); Warp Town -> Area 9 Map 191 Submap 46 at (0,9); Warp to Castle HQ (9, 1, 2); Animate Door Open; Engine Action #190; Set Entity Movement Speed (0, 14); Warp to Castle HQ (14, 1, 1); Engine Action #93; Teleport obj[46] to (36,1); Launch Tactical War Battle (16); Teleport obj[5] to (0,4); Exit to World Map (1, 8, 30); Make obj[2] Hidden (disp = 0); Warp Room -> Submap 52 at (0,1) facing Up (North); Warp Town -> Area 158 Map 52 Submap 0 at (2,47); Set Entity Movement Speed (2, 5); Warp Room -> Submap 5 at (3,2) facing West (Left); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Warp Town -> Area 4 Map 5 Submap 2 at (2,1); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Walk obj[36] to (2,54); Open Dialogue Message Window; Warp Town -> Area 73 Map 8 Submap 72 at (1,8); Engine Action #6; Engine Action #5; Reset Camera Tracking (6); Warp Town -> Area 30 Map 72 Submap 0 at (8,49); Warp Town -> Area 5 Map 8 Submap 4 at (6,0); Reset Camera Tracking (30); Jump to Bytecode Offset (0, 179); Engine Action #5; Reset Camera Tracking (2); Warp Room -> Submap 255 at (254,5) facing West (Left); Exit to World Map (7, 5, 12); Warp to Castle HQ (0, 5, 2); Open Dialogue Message Window; Engine Action #5; Dismiss Emotion Bubble (255); Walk obj[5] to (0,3); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Dismiss Emotion Bubble (5); Warp Town -> Area 3 Map 0 Submap 30 at (36,4); Close Dialogue Sub-Window (8); Warp Room -> Submap 54 at (0,4) facing 44; Set Entity Movement Speed (4, 5); Warp Room -> Submap 4 at (1,2) facing East (Right); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Open Dialogue Message Window; Engine Action #5; Engine Action #5; Exit to World Map (5, 7, 1); Dismiss Emotion Bubble (255); Engine Action #5; Warp Town -> Area 5 Map 5 Submap 4 at (5,7); Warp Room -> Submap 255 at (254,5) facing 8; Engine Action #5; Engine Action #5; Exit to World Map (5, 7, 1); Dismiss Emotion Bubble (255); Walk obj[72] to (1,1); Engine Action #9; Close Dialogue Sub-Window (1); Warp Room -> Submap 72 at (0,1) facing 73; Screen Fade Transition (24, 8, 1); Display Dialogue Box [Bank: 5, MsgID: 1]; Engine Action #5; Show Dialogue Portrait (0, 0, 5); Engine Action #5; Warp Town -> Area 0 Map 30 Submap 73 at (20,40); Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 1 Map 13 Submap 1 at (14,5); Warp Room -> Submap 8 at (0,0) facing 5; Engine Action #5; Warp to Castle HQ (0, 5, 8); Dismiss Emotion Bubble (41); Warp Town -> Area 0 Map 1 Submap 255 at (0,24); Reset Camera Tracking (1); Show Dialogue Portrait (51, 2, 255); Warp Room -> Submap 8 at (1,16) facing 255; Warp Town -> Area 36 Map 8 Submap 49 at (6,5); Reset Camera Tracking (5); Dismiss Emotion Bubble (4); Exit to World Map (0, 3, 2); Warp to Castle HQ (0, 4, 30); Engine Action #5; Open Dialogue Message Window; Engine Action #5; Make obj[4] Visible (disp = 1); Exit to World Map (0, 6, 30); Engine Action #5; Warp Room -> Submap 60 at (4,4) facing South (Down); Engine Action #6; Dismiss Emotion Bubble (255); Engine Action #5; Warp Town -> Area 5 Map 75 Submap 4 at (4,3); Warp Town -> Area 0 Map 4 Submap 30 at (255,254); Engine Action #5; Engine Action #9; Engine Action #5; Set Render Priority (pri) (4, 4); Open Dialogue Message Window; Engine Action #5; Warp Town -> Area 2 Map 30 Submap 255 at (254,5); Animate Door Open; Engine Action #5; Play Sound Effect (SE) (4); Exit to World Map (0, 6, 30); Walk obj[54] to (0,8); Display Emotion Bubble (7, 77); Open Dialogue Message Window; Exit to World Map (7, 3, 11); Open Dialogue Message Window; Walk obj[30] to (28,0); Engine Action #5; Pan Camera (46, 2, 1); Engine Action #168; Engine Action #114; Open Dialogue Message Window; Warp Room -> Submap 1 at (1,2) facing Up (North); Engine Action #165; Engine Action #115; Open Dialogue Message Window; Warp Town -> Area 3 Map 2 Submap 2 at (2,8); Engine Action #172; Pathfind and Walk to Coordinates (1, 8, 2); Engine Action #9; Engine Action #164; Pathfind and Walk to Coordinates (1, 9, 0); Screen Fade Transition (0, 11, 3); Screen Fade Transition (1, 0, 12); Open Dialogue Message Window; Place Scenery Structure (3); Display Dialogue Box [Bank: 1, MsgID: 2]; Animate Door Open; Engine Action #162; Engine Action #115; Open Dialogue Message Window; Animate Door Open; Warp to Castle HQ (14, 3, 0); Fade Out to Black (47); Close Dialogue Window; Warp Room -> Submap 100 at (73,30) facing 24; Engine Action #9; Warp Room -> Submap 5 at (14,5) facing 10; Warp Room -> Submap 5 at (10,30) facing 24; Animate Door Open; Warp Room -> Submap 5 at (14,5) facing 10; Warp to Castle HQ (0, 30, 73); Show Dialogue Portrait (3, 12, 3); Set Combat Battle BGM (5); Warp to Castle HQ (12, 0, 73); Screen Fade Transition (24, 9, 1); Display Choice Selection (73, 15); Load Sound Bank into Memory (1, 1); Engine Action #9; Close Dialogue Sub-Window (1); Warp Room -> Submap 72 at (0,1) facing 73; Screen Fade Transition (3, 12, 3); Set Combat Battle BGM (10); Close Dialogue Sub-Window (9); Warp Room -> Submap 73 at (10,3) facing 10; Warp Town -> Area 73 Map 10 Submap 24 at (8,1); Set Story Flag (73, 10); Warp to Castle HQ (12, 1, 73); Screen Fade Transition (24, 9, 1); Open Dialogue Sub-Window (73); Dismiss Emotion Bubble (11); Warp Town -> Area 2 Map 60 Submap 73 at (60,3); Screen Fade Transition (1, 36, 32); Close Dialogue Window; Warp Room -> Submap 60 at (73,30) facing 24; Reset Camera Tracking (1); Close Dialogue Sub-Window (73); Show Dialogue Portrait (24, 1, 1); Clear Dialogue Sub-Window; Set Combat Battle BGM (10); Warp to Castle HQ (12, 3, 73); Engine Action #5; Warp to Castle HQ (12, 0, 73); Screen Fade Transition (24, 9, 1); Fade In from Black (73); Show Dialogue Portrait (24, 1, 1); Fade Out to Black (73); Screen Fade Transition (3, 10, 0); Set Combat Battle BGM (10); Close Dialogue Sub-Window (8); Warp Room -> Submap 36 at (64,73) facing 10; Engine Action #54; Warp Room -> Submap 5 at (2,1) facing South (Down); Engine Action #5; Screen Fade Transition (30, 24, 2); Warp Room -> Submap 73 at (15,24) facing West (Left); Warp Room -> Submap 73 at (15,3) facing 10; Warp Town -> Area 73 Map 5 Submap 3 at (10,1); Warp to Castle HQ (12, 3, 73); Engine Action #5; Warp to Castle HQ (12, 1, 73); Dismiss Emotion Bubble (11); Warp Town -> Area 2 Map 150 Submap 34 at (9,15); Exit to World Map (12, 0, 45); Teleport obj[58] to (255,254) |
| `ev[18]` | `128 (Loop)` | Story Flag 15 (bit 2) SET AND Story Flag 15 (bit 4) CLEAR AND Inventory Holds Item #1 [Medicine] | Full Rest & Healing (Restore HP/MP); Warp Room -> Submap 3 at (23,4) facing 37; Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[19]` | `128 (Loop)` | Story Flag 15 (bit 2) SET AND Story Flag 15 (bit 4) CLEAR AND Inventory Holds Item #2 [Mega Medicine] | Set Entity Movement Speed (3, 5); Reset Camera Tracking (4); Exit to World Map (1, 12, 3); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Engine Action #9; Exit to World Map (4, 5, 5); Warp Room -> Submap 2 at (0,30) facing 255; Engine Action #5; Animate Door Open; Exit to World Map (4, 5, 15); Warp Room -> Submap 30 at (255,254) facing 50; Close Dialogue Sub-Window (8); Warp Room -> Submap 79 at (1,49) facing East (Right); Engine Action #5; Reset Camera Tracking (4); Exit to World Map (0, 0, 5); Engine Action #5; Warp Town -> Area 28 Map 0 Submap 0 at (5,5); Warp to Castle HQ (0, 30, 255); Engine Action #5; Engine Action #9; Exit to World Map (4, 5, 15); Warp Town -> Area 28 Map 30 Submap 255 at (254,5); Animate Door Open; Exit to World Map (4, 5, 25); Warp Room -> Submap 2 at (26,0) facing South (Down); Dismiss Emotion Bubble (255); Walk obj[81] to (1,2); Bytecode Subroutine Return; Exit to World Map (49, 3, 5); Reset Camera Tracking (4); Exit to World Map (0, 10, 30); Engine Action #5; Engine Action #9; Exit to World Map (4, 5, 5); Open Dialogue Message Window; Screen Fade Transition (30, 255, 254); Engine Action #5; Animate Door Open; Exit to World Map (4, 5, 15); Warp Town -> Area 2 Map 0 Submap 9 at (30,255); Walk obj[81] to (1,8); Toggle Random Encounters (2) |
| `ev[20]` | `128 (Loop)` | Story Flag 15 (bit 2) SET AND Story Flag 15 (bit 4) CLEAR AND Character #1 Level >= 255 | Set Combat Battle BGM (15); Close Dialogue Sub-Window (9); Warp Room -> Submap 79 at (2,81) facing West (Left); Exit to World Map (24, 8, 1); Engine Action #9; Bytecode Subroutine Return; Reset Camera Tracking (80); Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[21]` | `128 (Loop)` | Story Flag 15 (bit 2) SET AND Story Flag 15 (bit 4) CLEAR AND Character #1 Level >= 255 | Display Chapter Text (2); Open Dialogue Sub-Window (4); Engine Action #81; Warp Room -> Submap 28 at (0,5) facing 4; Engine Action #81; Warp Room -> Submap 28 at (0,10) facing 5; Engine Action #80; Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[22]` | `128 (Loop)` | Story Flag 15 (bit 2) SET AND Story Flag 15 (bit 4) CLEAR AND Inventory Holds Item #4 [Throat Drops] | Set Entity Movement Speed (3, 5); Warp Room -> Submap 0 at (5,5) facing West (Left); Open Dialogue Message Window; Engine Action #5; Dismiss Emotion Bubble (6); Warp Room -> Submap 5 at (2,1) facing West (Left); Warp to Castle HQ (30, 255, 254); Engine Action #5; Engine Action #9; Exit to World Map (4, 0, 8); Warp Town -> Area 0 Map 30 Submap 255 at (254,5); Animate Door Open; Exit to World Map (4, 0, 8); Dismiss Emotion Bubble (255); Walk obj[37] to (4,255) |
| `ev[23]` | `128 (Loop)` | Story Flag 15 (bit 2) SET AND Story Flag 15 (bit 4) CLEAR AND Inventory Holds Item #8 [Fire Wall] | Close Dialogue Window; Warp Town -> Area 2 Map 100 Submap 37 at (8,255) |
| `ev[24]` | `128 (Loop)` | Story Flag 15 (bit 2) SET AND Story Flag 15 (bit 4) CLEAR AND Inventory Holds Item #16 [Revenge Earth] | Close Dialogue Window; Warp Room -> Submap 40 at (37,16) facing 255 |
| `ev[25]` | `128 (Loop)` | Story Flag 15 (bit 2) SET AND Story Flag 15 (bit 4) CLEAR AND Inventory Holds Item #32 [Drinking Set] AND Temp Event Flag #64 SET | Toggle Random Encounters (32); Engine Action #5; Warp Town -> Area 4 Map 6 Submap 2 at (2,4); Engine Action #5; Pan Camera (2, 5, 60); Dismiss Emotion Bubble (36); Warp Map Transition (255, 254, 255, 254, 204) |
| `ev[26]` | `1 (Action / Talk)` | Story Flag 15 (bit 4) SET AND Story Flag 21 (bit 1) CLEAR AND Target Inspected is obj[10] | Close Dialogue Sub-Window (8); Display Dialogue Box [Bank: 2, MsgID: 5]; Screen Fade Transition (5, 10, 2); Open Dialogue Message Window; Dismiss Emotion Bubble (255) |
| `ev[27]` | `1 (Action / Talk)` | Story Flag 15 (bit 4) SET AND Story Flag 21 (bit 1) CLEAR AND Target Inspected is obj[11] AND Story Flag 0 (mask 255) SET | Warp to Castle HQ (10, 1, 24); Reset Camera Tracking (12); Warp Town -> Area 5 Map 10 Submap 5 at (10,2); Open Dialogue Message Window; Dismiss Emotion Bubble (255) |
| `ev[28]` | `1 (Action / Talk)` | Story Flag 15 (bit 4) SET AND Story Flag 21 (bit 1) CLEAR AND Target Inspected is obj[12] | Close Dialogue Sub-Window (9); Display Dialogue Box [Bank: 3, MsgID: 5]; Display Dialogue Box [Bank: 5, MsgID: 10]; Warp to Castle HQ (0, 30, 255) |
| `ev[29]` | `1 (Action / Talk)` | Story Flag 15 (bit 4) SET AND Story Flag 21 (bit 1) CLEAR AND Target Inspected is obj[13] AND Story Flag 0 (mask 255) SET | Warp to Castle HQ (12, 1, 24); Engine Action #9; Display Dialogue Box [Bank: 3, MsgID: 5]; Display Dialogue Box [Bank: 5, MsgID: 10]; Warp to Castle HQ (0, 30, 255) |
| `ev[30]` | `1 (Action / Talk)` | Story Flag 15 (bit 4) SET AND Story Flag 21 (bit 1) CLEAR AND Target Inspected is obj[14] | Close Dialogue Sub-Window (14); Display Dialogue Box [Bank: 4, MsgID: 5]; Animate Door Open; Engine Action #5; Screen Fade Transition (0, 0, 30) |
| `ev[31]` | `1 (Action / Talk)` | Story Flag 21 (bit 1) SET AND Story Flag 21 (bit 2) CLEAR AND Player within Box [152..157, 2..35] AND Condition Check #36 AND Story Flag 0 (mask 255) SET | Recruit Character into Active Party (5 [Sheena], 21); Warp Town -> Area 0 Map 5 Submap 5 at (1,0); Engine Action #5; Show Dialogue Portrait (30, 24, 21); Display Dialogue Box [Bank: 1, MsgID: 73]; Show Dialogue Portrait (49, 2, 5); Execute Choice Result (3); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Open Dialogue Message Window; Warp Town -> Area 0 Map 5 Submap 5 at (4,4); Warp Room -> Submap 30 at (255,254) facing 50; Engine Action #58 |
| `ev[32]` | `1 (Action / Talk)` | Story Flag 21 (bit 1) SET AND Story Flag 21 (bit 2) CLEAR AND Player within Box [172..172, 2..121] AND Condition Check #121 AND Story Flag 1 (mask 255) SET | Recruit Character into Active Party (46 [Oulan], 1); Engine Action #83; Warp Town -> Area 14 Map 171 Submap 107 at (3,14); Open Dialogue Message Window; Launch Tactical War Battle (1); Launch Tactical War Battle (2); Teleport obj[5] to (0,4); Exit to World Map (1, 6, 30); Return to Previous Memory Map (2); Display Speaker Name Box (124); Make obj[0] Hidden (disp = 0); Warp Room -> Submap 2 at (47,49) facing Up (North); Engine Action #5; Warp Room -> Submap 5 at (3,2) facing West (Left); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Warp Town -> Area 4 Map 5 Submap 2 at (2,1); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Walk obj[73] to (5,3); Screen Fade Transition (0, 73, 10); Warp to Castle HQ (12, 0, 73); Screen Fade Transition (24, 8, 1); Engine Action #61; Set Combat Battle BGM (15); Close Dialogue Sub-Window (1); Warp Room -> Submap 73 at (30,11) facing Up (North); Warp Town -> Area 60 Map 46 Submap 2 at (14,170); Engine Action #107; Warp to Castle HQ (14, 3, 2); Warp Town -> Area 174 Map 107 Submap 3 at (2,2); Launch Tactical War Battle (4); Teleport obj[49] to (2,5); Open Dialogue Message Window; Exit to World Map (7, 2, 1); Warp Room -> Submap 30 at (255,254) facing 5; Warp Room -> Submap 7 at (2,1) facing West (Left); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Walk obj[73] to (45,11); Warp Room -> Submap 60 at (73,30) facing 24; Reset Camera Tracking (1); Engine Action #63; Set Combat Battle BGM (15); Close Dialogue Sub-Window (9); Warp Room -> Submap 5 at (10,5) facing 10; Warp Town -> Area 0 Map 5 Submap 10 at (30,24); Reset Camera Tracking (1); Play Sound Effect (SE) (5); Screen Fade Transition (5, 10, 0); Open Dialogue Message Window; Engine Action #5; Screen Fade Transition (30, 24, 14); Warp Room -> Submap 73 at (15,24) facing 9; Warp Room -> Submap 36 at (8,73) facing 10; Engine Action #54; Warp Room -> Submap 49 at (2,5) facing Up (North); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Screen Fade Transition (6, 1, 6); Warp Town -> Area 6 Map 1 Submap 5 at (10,30); Engine Action #5; Animate Door Open; Engine Action #5; Show Dialogue Portrait (0, 0, 30); Walk obj[24] to (1,1); Play CD / Ambient BGM Track (73); Show Dialogue Portrait (39, 34, 54); Open Dialogue Message Window; Warp Room -> Submap 115 at (19,19) facing 115; Branch on Choice (19, 115); Execute Choice Result (19); Dismiss Character to Castle Base (19 [Eilie]); Dismiss Emotion Bubble (84); Display Choice Selection (31, 84); Branch on Choice (30, 84); Branch on Choice (31, 84); Execute Choice Result (30); Dismiss Character to Castle Base (21 [Bolgan]); Warp Room -> Submap 47 at (112,8); Open Dialogue Message Window; Warp to Castle HQ (19, 1, 20); Warp Room -> Submap 1 at (70,2) facing South (Down); Set Combat Battle BGM (15); Close Dialogue Window; Warp Town -> Area 2 Map 100 Submap 3 at (0,0); Wait for Audio / Window Sync (1); Engine Action #9; Execute Choice Result (2); Display Dialogue Box [Bank: 0, MsgID: 52]; Turn obj[58] facing 255 |
| `ev[33]` | `128 (Loop)` | Story Flag 21 (bit 1) SET AND Story Flag 21 (bit 2) CLEAR AND Inventory Holds Item #1 [Medicine] | Warp Room -> Submap 2 at (13,28); Toggle Random Encounters (1) |
| `ev[34]` | `128 (Loop)` | Story Flag 21 (bit 1) SET AND Story Flag 21 (bit 2) CLEAR AND Inventory Holds Item #2 [Mega Medicine] | Close Dialogue Window; Warp Room -> Submap 80 at (37,2) facing 255 |
| `ev[35]` | `128 (Loop)` | Story Flag 21 (bit 1) SET AND Story Flag 21 (bit 2) CLEAR AND Inventory Holds Item #4 [Throat Drops] AND Temp Event Flag #8 SET | Toggle Random Encounters (4); Engine Action #5; Warp Town -> Area 4 Map 6 Submap 2 at (2,4); Engine Action #5; Pan Camera (2, 5, 60); Dismiss Emotion Bubble (36); Exit to World Map (255, 254, 255) |
| `ev[36]` | `1 (Action / Talk)` | Party Member Count == 0 AND Condition Check #30 AND Story Flag 28 (bit 1) SET AND Story Flag 28 (bit 2) CLEAR AND Player within Box [164..164, 2..108] AND Condition Check #108 AND Story Flag 3 (mask 255) SET | Recruit Character into Active Party (46 [Oulan], 2); Dismiss Dialogue Portrait; Engine Action #168; Engine Action #108; Engine Action #89; Dismiss Dialogue Portrait; Warp Town -> Area 1 Map 0 Submap 16 at (2,26); Engine Action #168; Engine Action #108; Engine Action #89; Fade In from Black (2); Pan Camera (0, 26, 2); Branch on Choice (177, 92); Open Dialogue Message Window; Branch on Choice (47, 11); Warp Room -> Submap 100 at (73,180) facing 89; Dismiss Dialogue Portrait; Warp Town -> Area 2 Map 73 Submap 20 at (46,2); Clear Dialogue Sub-Window; Engine Action #168; Engine Action #107; Engine Action #89; Clear Dialogue Sub-Window; Warp Town -> Area 6 Map 0 Submap 25 at (47,89); Dismiss Dialogue Portrait; Engine Action #5; Engine Action #89; Dismiss Dialogue Portrait; Engine Action #5; Engine Action #89; Dismiss Dialogue Portrait; Warp Town -> Area 3 Map 89 Submap 16 at (5,89); Dismiss Dialogue Portrait; Engine Action #5; Launch Tactical War Battle (1); Clear Dialogue Sub-Window; Dismiss Dialogue Portrait; Dismiss Dialogue Portrait; Warp Town -> Area 18 Map 54 Submap 0 at (1,89); Dismiss Dialogue Portrait; Warp Town -> Area 4 Map 24 Submap 20 at (2,19); Engine Action #89; Dismiss Dialogue Portrait; Engine Action #5; Engine Action #89; Dismiss Dialogue Portrait; Engine Action #5; Set Combat Battle BGM (15); Set Combat Battle BGM (20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 2 Map 21 Submap 2 at (20,73); Show Dialogue Portrait (41, 2, 0); Warp Room -> Submap 0 at (89,16) facing Up (North); Engine Action #5; Clear Dialogue Sub-Window; Dismiss Dialogue Portrait; Dismiss Dialogue Portrait; Warp Town -> Area 22 Map 51 Submap 2 at (255,1); Engine Action #5; Open Dialogue Message Window; Exit to World Map (4, 1, 3); Warp to Castle HQ (8, 0, 2); Engine Action #5; Engine Action #5; Dismiss Emotion Bubble (5); Branch on Choice (1, 0); Engine Action #5; Dismiss Emotion Bubble (30); Load Sound Bank into Memory (1, 20); Exit to World Map (24, 20, 2); Open Dialogue Sub-Window (72); Open Dialogue Message Window; Branch on Choice (73, 15); Engine Action #89; Dismiss Dialogue Portrait; Warp Town -> Area 5 Map 25 Submap 16 at (16,2); Close Dialogue Sub-Window (255); Warp Town -> Area 73 Map 15 Submap 11 at (2,2); Engine Action #120; Make obj[1] Hidden (disp = 0); Dismiss Dialogue Portrait; Warp Room -> Submap 1 at (26,2) facing 15; Engine Action #199; Engine Action #88; Open Dialogue Message Window; Show Dialogue Portrait (3, 15, 1); Load Sound Bank into Memory (1, 15); Engine Action #9; Warp Town -> Area 20 Map 198 Submap 90 at (0,20); Warp to Castle HQ (20, 1, 47); Open Shop Menu #7 (Type: 0); Exit to World Map (0, 187, 95); Engine Action #9; Close Dialogue Window; Warp Room -> Submap 120 at (73,15) facing 24; Branch on Choice (2, 25); Set Combat Battle BGM (15); Close Dialogue Sub-Window (15); Warp Town -> Area 26 Map 73 Submap 15 at (9,28); Warp Town -> Area 58 Map 255 Submap 254 at (255,254) |
| `ev[37]` | `128 (Loop)` | Story Flag 28 (bit 1) SET AND Story Flag 28 (bit 2) CLEAR AND Inventory Holds Item #1 [Medicine] | Engine Action #5; Branch on Choice (4, 4); Open Dialogue Message Window; Dismiss Dialogue Portrait; Warp Town -> Area 4 Map 30 Submap 37 at (1,255) |
| `ev[38]` | `1 (Action / Talk)` | Party Member Count == 1 AND Condition Check #30 AND Story Flag 28 (bit 1) SET AND Story Flag 28 (bit 2) CLEAR AND Player within Box [164..164, 2..108] AND Condition Check #108 AND Story Flag 3 (mask 255) SET | Recruit Character into Active Party (46 [Oulan], 2); Dismiss Dialogue Portrait; Engine Action #168; Engine Action #108; Engine Action #89; Dismiss Dialogue Portrait; Warp Town -> Area 1 Map 0 Submap 16 at (2,26); Engine Action #168; Engine Action #108; Engine Action #89; Fade In from Black (2); Pan Camera (0, 26, 2); Branch on Choice (177, 92); Open Dialogue Message Window; Branch on Choice (47, 11); Warp Room -> Submap 100 at (73,180) facing 89; Dismiss Dialogue Portrait; Warp Town -> Area 2 Map 73 Submap 20 at (46,2); Clear Dialogue Sub-Window; Engine Action #168; Engine Action #107; Engine Action #89; Clear Dialogue Sub-Window; Warp Town -> Area 6 Map 0 Submap 25 at (47,89); Dismiss Dialogue Portrait; Engine Action #5; Engine Action #89; Dismiss Dialogue Portrait; Engine Action #5; Engine Action #89; Dismiss Dialogue Portrait; Warp Town -> Area 3 Map 89 Submap 16 at (5,89); Dismiss Dialogue Portrait; Engine Action #5; Clear Dialogue Sub-Window; Dismiss Dialogue Portrait; Dismiss Dialogue Portrait; Warp Town -> Area 18 Map 54 Submap 0 at (1,89); Dismiss Dialogue Portrait; Warp Town -> Area 4 Map 24 Submap 20 at (2,19); Engine Action #89; Dismiss Dialogue Portrait; Engine Action #5; Engine Action #89; Dismiss Dialogue Portrait; Engine Action #5; Set Combat Battle BGM (15); Set Combat Battle BGM (20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 2 Map 21 Submap 2 at (20,73); Show Dialogue Portrait (41, 2, 0); Warp Room -> Submap 0 at (89,16) facing Up (North); Engine Action #5; Clear Dialogue Sub-Window; Dismiss Dialogue Portrait; Dismiss Dialogue Portrait; Warp Town -> Area 22 Map 73 Submap 15 at (11,2); Warp Town -> Area 120 Map 46 Submap 1 at (16,1); Clear Dialogue Sub-Window; Warp Room -> Submap 2 at (15,200) facing 88; Open Dialogue Message Window; Show Dialogue Portrait (3, 15, 1); Load Sound Bank into Memory (1, 15); Engine Action #9; Warp Town -> Area 20 Map 199 Submap 90 at (0,20); Warp to Castle HQ (20, 1, 47); Open Shop Menu #7 (Type: 0); Exit to World Map (0, 187, 95); Engine Action #9; Close Dialogue Window; Warp Room -> Submap 120 at (73,15) facing 24; Branch on Choice (2, 25); Set Combat Battle BGM (15); Close Dialogue Sub-Window (15); Warp Town -> Area 26 Map 73 Submap 15 at (9,28); Warp Town -> Area 58 Map 255 Submap 254 at (255,1); Engine Action #89; Dismiss Dialogue Portrait; Warp Town -> Area 5 Map 89 Submap 16 at (5,89); Dismiss Dialogue Portrait; Engine Action #5; Engine Action #89; Dismiss Dialogue Portrait; Warp Town -> Area 3 Map 89 Submap 16 at (5,89); Dismiss Dialogue Portrait; Engine Action #5; Clear Dialogue Sub-Window; Dismiss Dialogue Portrait; Dismiss Dialogue Portrait; Warp Town -> Area 37 Map 73 Submap 15 at (11,2); Warp Town -> Area 100 Map 9 Submap 28 at (2,9); Display Chapter Text (4); Wait for Audio / Window Sync (3); Warp to Castle HQ (0, 3, 12); Open Dialogue Message Window; Engine Action #51; Turn obj[255] facing 254 |
| `ev[39]` | `1 (Action / Talk)` | Story Flag 28 (bit 2) SET AND Story Flag 28 (bit 4) CLEAR AND Target Inspected is obj[15] | Recruit Character into Active Party (72 [Siegfried], 0); Show Dialogue Portrait (24, 15, 2); Fade Out to Black (5); Show Dialogue Portrait (1, 0, 5); Show Dialogue Portrait (30, 72, 1); Show Dialogue Portrait (9, 58, 255) |
| `ev[40]` | `1 (Action / Talk)` | Party Member Count == 0 AND Condition Check #30 AND Story Flag 28 (bit 2) SET AND Story Flag 28 (bit 4) CLEAR AND Target Inspected is obj[20] | Recruit Character into Active Party (24 [Milie], 20); Warp Town -> Area 28 Map 72 Submap 0 at (15,73); Show Dialogue Portrait (73, 20, 40); Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 2 Map 29 Submap 2 at (30,73); Show Dialogue Portrait (41, 2, 0); Warp Room -> Submap 0 at (24,20) facing Up (North); Warp Room -> Submap 5 at (20,1); Open Dialogue Message Window; Engine Action #5; Screen Fade Transition (30, 72, 1); Show Dialogue Portrait (9, 24, 15); Warp Town -> Area 32 Map 51 Submap 2 at (255,1); Engine Action #5; Branch on Choice (1, 0); Engine Action #5; Screen Fade Transition (30, 24, 20); Warp Town -> Area 35 Map 73 Submap 15 at (72,1); Show Dialogue Portrait (9, 24, 15); Warp Town -> Area 36 Map 255 Submap 2 at (58,255) |
| `ev[41]` | `1 (Action / Talk)` | Story Flag 28 (bit 2) SET AND Story Flag 28 (bit 4) CLEAR AND Target Inspected is obj[20] | Recruit Character into Active Party (24 [Milie], 20); Warp Town -> Area 28 Map 72 Submap 0 at (15,73); Show Dialogue Portrait (73, 20, 40); Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 2 Map 29 Submap 2 at (30,73); Show Dialogue Portrait (41, 2, 0); Warp Room -> Submap 0 at (24,20) facing Up (North); Return to Previous Memory Map (73); Show Dialogue Portrait (5, 15, 2); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 24, 15); Warp Town -> Area 34 Map 73 Submap 15 at (11,2); Warp Town -> Area 100 Map 9 Submap 28 at (2,9); Display Chapter Text (4); Wait for Audio / Window Sync (3); Warp to Castle HQ (0, 3, 12); Open Dialogue Message Window; Engine Action #51; Turn obj[255] facing 254; Warp Room -> Submap 20 at (1,0) facing 5; Screen Fade Transition (30, 24, 20); Warp Town -> Area 35 Map 73 Submap 15 at (72,1); Show Dialogue Portrait (9, 24, 15); Warp Town -> Area 36 Map 58 Submap 255 at (254,255) |
| `ev[42]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Clear Story Milestone Flag 7 (mask 17); Warp to Castle HQ (0, 4, 1); Warp to Castle HQ (0, 10, 8); Warp to Castle HQ (17, 0, 255) |
| `ev[43]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Clear Story Milestone Flag 7 (mask 17); Warp to Castle HQ (0, 4, 1); Warp to Castle HQ (0, 10, 8); Warp to Castle HQ (17, 0, 255) |
| `ev[44]` | `1 (Action / Talk)` | Target Inspected is obj[22] | Clear Story Milestone Flag 15 (mask 22); Warp to Castle HQ (2, 4, 0); Warp Town -> Area 11 Map 0 Submap 3 at (22,0) |
| `ev[45]` | `1 (Action / Talk)` | Target Inspected is obj[23] | Clear Story Milestone Flag 15 (mask 22); Warp to Castle HQ (2, 4, 0); Warp Town -> Area 11 Map 0 Submap 3 at (22,0) |
| `ev[46]` | `1 (Action / Talk)` | Target Inspected is obj[24] AND Story Flag 2 (mask 255) SET | Warp to Castle HQ (22, 3, 96); Show Dialogue Portrait (22, 3, 2); Exit to World Map (0, 2, 11); Open Dialogue Message Window; Warp to Castle HQ (22, 0, 255) |
| `ev[47]` | `1 (Action / Talk)` | Target Inspected is obj[19] | Clear Story Milestone Flag 9 (mask 19); Warp to Castle HQ (3, 4, 2); Warp Town -> Area 12 Map 5 Submap 3 at (19,0) |
| `ev[48]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) CLEAR AND Target Inspected is obj[77] | Open Dialogue Sub-Window (5); Screen Fade Transition (255, 254, 255) |
| `ev[49]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) SET AND Story Flag 17 (bit 16) CLEAR AND Target Inspected is obj[77] | Open Dialogue Sub-Window (7); Screen Fade Transition (255, 254, 255) |
| `ev[50]` | `1 (Action / Talk)` | Story Flag 17 (bit 16) SET AND Story Flag 124 (bit 16) CLEAR AND Target Inspected is obj[77] | Open Dialogue Sub-Window (8); Screen Fade Transition (255, 254, 255) |
| `ev[51]` | `1 (Action / Talk)` | Story Flag 124 (bit 16) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[77] | Open Dialogue Sub-Window (9); Screen Fade Transition (255, 254, 255) |
| `ev[52]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[77] | Open Dialogue Sub-Window (10); Screen Fade Transition (255, 254, 255) |
| `ev[53]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[77] | Open Dialogue Sub-Window (11); Screen Fade Transition (255, 254, 255) |
| `ev[54]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) CLEAR AND Target Inspected is obj[78] | Open Dialogue Sub-Window (5); Close Dialogue Window |
| `ev[55]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) SET AND Story Flag 17 (bit 16) CLEAR AND Target Inspected is obj[78] | Open Dialogue Sub-Window (7); Close Dialogue Window |
| `ev[56]` | `1 (Action / Talk)` | Story Flag 17 (bit 16) SET AND Story Flag 124 (bit 16) CLEAR AND Target Inspected is obj[78] | Open Dialogue Sub-Window (8); Close Dialogue Window |
| `ev[57]` | `1 (Action / Talk)` | Story Flag 124 (bit 16) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[78] | Open Dialogue Sub-Window (9); Close Dialogue Window |
| `ev[58]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[78] | Open Dialogue Sub-Window (10); Close Dialogue Window |
| `ev[59]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[78] | Open Dialogue Sub-Window (11); Close Dialogue Window |
| `ev[60]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) CLEAR AND Target Inspected is obj[79] | Open Dialogue Sub-Window (5); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[61]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) SET AND Story Flag 17 (bit 16) CLEAR AND Target Inspected is obj[79] | Open Dialogue Sub-Window (7); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[62]` | `1 (Action / Talk)` | Story Flag 17 (bit 16) SET AND Story Flag 124 (bit 16) CLEAR AND Target Inspected is obj[79] | Open Dialogue Sub-Window (8); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[63]` | `1 (Action / Talk)` | Story Flag 124 (bit 16) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[79] | Open Dialogue Sub-Window (9); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[64]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[79] | Open Dialogue Sub-Window (10); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[65]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[79] | Open Dialogue Sub-Window (11); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[66]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) CLEAR AND Target Inspected is obj[80] | Open Dialogue Sub-Window (5); Place Scenery Structure (255) |
| `ev[67]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) SET AND Story Flag 17 (bit 16) CLEAR AND Target Inspected is obj[80] | Open Dialogue Sub-Window (7); Place Scenery Structure (255) |
| `ev[68]` | `1 (Action / Talk)` | Story Flag 35 (bit 64) CLEAR AND Target Inspected is obj[81] | Open Dialogue Sub-Window (5); Animate Door Open; Set Combat Battle BGM (15); Jump to Bytecode Offset (4, 6); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (1); Exit to World Map (0, 47, 80); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (9,35) facing 64; Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[69]` | `1 (Action / Talk)` | Story Flag 35 (bit 64) SET AND Story Flag 14 (bit 128) CLEAR AND Target Inspected is obj[81] | Open Dialogue Sub-Window (5); Animate Door Open |
| `ev[70]` | `1 (Action / Talk)` | Story Flag 35 (bit 64) SET AND Story Flag 14 (bit 128) SET AND Story Flag 17 (bit 16) CLEAR AND Target Inspected is obj[81] | Open Dialogue Sub-Window (7); Animate Door Open |
| `ev[71]` | `1 (Action / Talk)` | Story Flag 35 (bit 64) SET AND Story Flag 17 (bit 16) SET AND Story Flag 124 (bit 16) CLEAR AND Target Inspected is obj[81] | Open Dialogue Sub-Window (8); Animate Door Open |
| `ev[72]` | `1 (Action / Talk)` | Story Flag 35 (bit 64) SET AND Story Flag 124 (bit 16) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[81] | Open Dialogue Sub-Window (9); Animate Door Open |
| `ev[73]` | `1 (Action / Talk)` | Story Flag 35 (bit 64) SET AND Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[81] | Open Dialogue Sub-Window (10); Animate Door Open |
| `ev[74]` | `1 (Action / Talk)` | Story Flag 35 (bit 64) SET AND Story Flag 143 (bit 1) SET AND Target Inspected is obj[81] | Open Dialogue Sub-Window (11); Animate Door Open |
| `ev[75]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) CLEAR AND Target Inspected is obj[82] | Open Dialogue Sub-Window (5); Show Dialogue Portrait (3, 82, 0) |
| `ev[76]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) SET AND Story Flag 17 (bit 16) CLEAR AND Target Inspected is obj[82] | Open Dialogue Sub-Window (7); Show Dialogue Portrait (3, 82, 0) |
| `ev[77]` | `1 (Action / Talk)` | Story Flag 17 (bit 16) SET AND Story Flag 124 (bit 16) CLEAR AND Target Inspected is obj[82] | Open Dialogue Sub-Window (8); Show Dialogue Portrait (3, 82, 0) |
| `ev[78]` | `1 (Action / Talk)` | Story Flag 124 (bit 16) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[82] | Open Dialogue Sub-Window (9); Show Dialogue Portrait (3, 82, 0) |
| `ev[79]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[82] | Open Dialogue Sub-Window (10); Show Dialogue Portrait (3, 82, 0) |
| `ev[80]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[82] | Open Dialogue Sub-Window (11); Show Dialogue Portrait (3, 82, 0) |
| `ev[81]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) CLEAR AND Target Inspected is obj[83] | Open Dialogue Sub-Window (5); Dismiss Dialogue Portrait |
| `ev[82]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) SET AND Story Flag 17 (bit 16) CLEAR AND Target Inspected is obj[83] | Open Dialogue Sub-Window (7); Dismiss Dialogue Portrait |
| `ev[83]` | `1 (Action / Talk)` | Story Flag 17 (bit 16) SET AND Story Flag 124 (bit 16) CLEAR AND Target Inspected is obj[83] | Open Dialogue Sub-Window (8); Dismiss Dialogue Portrait |
| `ev[84]` | `1 (Action / Talk)` | Story Flag 124 (bit 16) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[83] | Open Dialogue Sub-Window (9); Dismiss Dialogue Portrait |
| `ev[85]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[83] | Open Dialogue Sub-Window (10); Dismiss Dialogue Portrait |
| `ev[86]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[83] | Open Dialogue Sub-Window (11); Dismiss Dialogue Portrait |
| `ev[87]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) CLEAR AND Target Inspected is obj[84] | Open Dialogue Sub-Window (5); Change Portrait Expression (3); Dismiss Character to Castle Base (1 [Riou]) |
| `ev[88]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) SET AND Story Flag 17 (bit 16) CLEAR AND Target Inspected is obj[84] | Open Dialogue Sub-Window (7); Change Portrait Expression (3); Dismiss Character to Castle Base (1 [Riou]) |
| `ev[89]` | `1 (Action / Talk)` | Story Flag 17 (bit 16) SET AND Story Flag 124 (bit 16) CLEAR AND Target Inspected is obj[84] | Open Dialogue Sub-Window (8); Change Portrait Expression (3); Dismiss Character to Castle Base (1 [Riou]) |
| `ev[90]` | `1 (Action / Talk)` | Story Flag 124 (bit 16) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[84] | Open Dialogue Sub-Window (9); Change Portrait Expression (3); Dismiss Character to Castle Base (1 [Riou]) |
| `ev[91]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[84] | Open Dialogue Sub-Window (10); Change Portrait Expression (3); Dismiss Character to Castle Base (1 [Riou]) |
| `ev[92]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[84] | Open Dialogue Sub-Window (11); Change Portrait Expression (3); Dismiss Character to Castle Base (1 [Riou]) |
| `ev[93]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) CLEAR AND Target Inspected is obj[85] | Open Dialogue Sub-Window (5); Display Speaker Name Box (255) |
| `ev[94]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) SET AND Story Flag 17 (bit 16) CLEAR AND Target Inspected is obj[85] | Open Dialogue Sub-Window (7); Display Speaker Name Box (255) |
| `ev[95]` | `1 (Action / Talk)` | Story Flag 17 (bit 16) SET AND Story Flag 124 (bit 16) CLEAR AND Target Inspected is obj[85] | Open Dialogue Sub-Window (8); Display Speaker Name Box (255) |
| `ev[96]` | `1 (Action / Talk)` | Story Flag 124 (bit 16) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[85] | Open Dialogue Sub-Window (9); Display Speaker Name Box (255) |
| `ev[97]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[85] | Open Dialogue Sub-Window (10); Display Speaker Name Box (255) |
| `ev[98]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[85] | Open Dialogue Sub-Window (11); Display Speaker Name Box (255) |
| `ev[99]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) CLEAR AND Target Inspected is obj[86] | Open Dialogue Sub-Window (5); Display Choice Selection (255, 254) |
| `ev[100]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) SET AND Story Flag 17 (bit 16) CLEAR AND Target Inspected is obj[86] | Open Dialogue Sub-Window (7); Display Choice Selection (255, 254) |
| `ev[101]` | `1 (Action / Talk)` | Story Flag 17 (bit 16) SET AND Story Flag 124 (bit 16) CLEAR AND Target Inspected is obj[86] | Open Dialogue Sub-Window (8); Display Choice Selection (255, 254) |
| `ev[102]` | `1 (Action / Talk)` | Story Flag 124 (bit 16) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[86] | Open Dialogue Sub-Window (9); Display Choice Selection (255, 254) |
| `ev[103]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[86] | Open Dialogue Sub-Window (10); Display Choice Selection (255, 254) |
| `ev[104]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[86] | Open Dialogue Sub-Window (11); Display Choice Selection (255, 254) |
| `ev[105]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) CLEAR AND Target Inspected is obj[87] | Open Dialogue Sub-Window (5); Branch on Choice (255, 254) |
| `ev[106]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) SET AND Story Flag 17 (bit 16) CLEAR AND Target Inspected is obj[87] | Open Dialogue Sub-Window (7); Branch on Choice (255, 254) |
| `ev[107]` | `1 (Action / Talk)` | Story Flag 17 (bit 16) SET AND Story Flag 124 (bit 16) CLEAR AND Target Inspected is obj[87] | Open Dialogue Sub-Window (8); Branch on Choice (255, 254) |
| `ev[108]` | `1 (Action / Talk)` | Story Flag 124 (bit 16) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[87] | Open Dialogue Sub-Window (9); Branch on Choice (255, 254) |
| `ev[109]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[87] | Open Dialogue Sub-Window (10); Branch on Choice (255, 254) |
| `ev[110]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[87] | Open Dialogue Sub-Window (11); Branch on Choice (255, 254) |
| `ev[111]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) CLEAR AND Target Inspected is obj[88] | Open Dialogue Sub-Window (5); Execute Choice Result (255) |
| `ev[112]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) SET AND Story Flag 17 (bit 16) CLEAR AND Target Inspected is obj[88] | Open Dialogue Sub-Window (7); Execute Choice Result (255) |
| `ev[113]` | `1 (Action / Talk)` | Story Flag 17 (bit 16) SET AND Story Flag 124 (bit 16) CLEAR AND Target Inspected is obj[88] | Open Dialogue Sub-Window (8); Execute Choice Result (255) |
| `ev[114]` | `1 (Action / Talk)` | Story Flag 124 (bit 16) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[88] | Open Dialogue Sub-Window (9); Execute Choice Result (255) |
| `ev[115]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[88] | Open Dialogue Sub-Window (10); Execute Choice Result (255) |
| `ev[116]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[88] | Open Dialogue Sub-Window (11); Execute Choice Result (255) |
| `ev[117]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) CLEAR AND Target Inspected is obj[89] | Open Dialogue Sub-Window (5); Set Story Flag (255, 254) |
| `ev[118]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) SET AND Story Flag 17 (bit 16) CLEAR AND Target Inspected is obj[89] | Open Dialogue Sub-Window (7); Set Story Flag (255, 254) |
| `ev[119]` | `1 (Action / Talk)` | Story Flag 17 (bit 16) SET AND Story Flag 124 (bit 16) CLEAR AND Target Inspected is obj[89] | Open Dialogue Sub-Window (8); Set Story Flag (255, 254) |
| `ev[120]` | `1 (Action / Talk)` | Story Flag 124 (bit 16) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[89] | Open Dialogue Sub-Window (9); Set Story Flag (255, 254) |
| `ev[121]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[89] | Open Dialogue Sub-Window (10); Set Story Flag (255, 254) |
| `ev[122]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[89] | Open Dialogue Sub-Window (11); Set Story Flag (255, 254) |
| `ev[123]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) CLEAR AND Target Inspected is obj[90] | Open Dialogue Sub-Window (5); Open Dialogue Sub-Window (3); Engine Action #90; Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[124]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) SET AND Story Flag 17 (bit 16) CLEAR AND Target Inspected is obj[90] | Open Dialogue Sub-Window (7); Open Dialogue Sub-Window (3); Engine Action #90; Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[125]` | `1 (Action / Talk)` | Story Flag 17 (bit 16) SET AND Story Flag 124 (bit 16) CLEAR AND Target Inspected is obj[90] | Open Dialogue Sub-Window (8); Open Dialogue Sub-Window (3); Engine Action #90; Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[126]` | `1 (Action / Talk)` | Story Flag 124 (bit 16) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[90] | Open Dialogue Sub-Window (9); Open Dialogue Sub-Window (3); Engine Action #90; Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[127]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[90] | Open Dialogue Sub-Window (10); Open Dialogue Sub-Window (3); Engine Action #90; Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[128]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[90] | Open Dialogue Sub-Window (11); Open Dialogue Sub-Window (3); Engine Action #90; Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[129]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) CLEAR AND Target Inspected is obj[91] | Open Dialogue Sub-Window (5); Close Dialogue Sub-Window (255) |
| `ev[130]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) SET AND Story Flag 17 (bit 16) CLEAR AND Target Inspected is obj[91] | Open Dialogue Sub-Window (7); Close Dialogue Sub-Window (255) |
| `ev[131]` | `1 (Action / Talk)` | Story Flag 17 (bit 16) SET AND Story Flag 124 (bit 16) CLEAR AND Target Inspected is obj[91] | Open Dialogue Sub-Window (8); Close Dialogue Sub-Window (255) |
| `ev[132]` | `1 (Action / Talk)` | Story Flag 124 (bit 16) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[91] | Open Dialogue Sub-Window (9); Close Dialogue Sub-Window (255) |
| `ev[133]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[91] | Open Dialogue Sub-Window (10); Close Dialogue Sub-Window (255) |
| `ev[134]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[91] | Open Dialogue Sub-Window (11); Close Dialogue Sub-Window (255) |
| `ev[135]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) CLEAR AND Target Inspected is obj[92] | Open Dialogue Sub-Window (5); Clear Dialogue Sub-Window |
| `ev[136]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) SET AND Story Flag 17 (bit 16) CLEAR AND Target Inspected is obj[92] | Open Dialogue Sub-Window (7); Clear Dialogue Sub-Window |
| `ev[137]` | `1 (Action / Talk)` | Story Flag 17 (bit 16) SET AND Story Flag 124 (bit 16) CLEAR AND Target Inspected is obj[92] | Open Dialogue Sub-Window (8); Clear Dialogue Sub-Window |
| `ev[138]` | `1 (Action / Talk)` | Story Flag 124 (bit 16) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[92] | Open Dialogue Sub-Window (9); Clear Dialogue Sub-Window |
| `ev[139]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[92] | Open Dialogue Sub-Window (10); Clear Dialogue Sub-Window |
| `ev[140]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[92] | Open Dialogue Sub-Window (11); Clear Dialogue Sub-Window |
| `ev[141]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) SET AND Story Flag 17 (bit 16) CLEAR AND Target Inspected is obj[93] | Engine Action #119; Warp to Castle HQ (8, 7, 52) |
| `ev[142]` | `1 (Action / Talk)` | Story Flag 17 (bit 16) SET AND Story Flag 124 (bit 16) CLEAR AND Target Inspected is obj[93] | Engine Action #119; Warp to Castle HQ (8, 8, 52) |
| `ev[143]` | `1 (Action / Talk)` | Story Flag 124 (bit 16) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[93] | Engine Action #119; Warp to Castle HQ (8, 9, 52) |
| `ev[144]` | `1 (Action / Talk)` | Target Inspected is obj[28] | Open Dialogue Sub-Window (6); Engine Action #51 |
| `ev[145]` | `1 (Action / Talk)` | Target Inspected is obj[29] | Open Dialogue Sub-Window (6); Engine Action #52 |
| `ev[146]` | `1 (Action / Talk)` | Target Inspected is obj[30] | Open Dialogue Sub-Window (6); Engine Action #53 |
| `ev[147]` | `1 (Action / Talk)` | Target Inspected is obj[31] | Open Dialogue Sub-Window (6); Engine Action #54 |
| `ev[148]` | `1 (Action / Talk)` | Target Inspected is obj[32] | Open Dialogue Sub-Window (6); Set Render Priority (pri) (255, 254) |
| `ev[149]` | `1 (Action / Talk)` | Target Inspected is obj[33] | Open Dialogue Sub-Window (6); Set Animation Pose (255, 254) |
| `ev[150]` | `1 (Action / Talk)` | Target Inspected is obj[34] | Open Dialogue Sub-Window (6); Recruit Character into Active Party (255, 254) |
| `ev[151]` | `1 (Action / Talk)` | Target Inspected is obj[35] | Open Dialogue Sub-Window (6); Engine Action #58 |
| `ev[152]` | `1 (Action / Talk)` | Target Inspected is obj[36] | Open Dialogue Sub-Window (6); Set obj[255] Collision to Passable |
| `ev[153]` | `1 (Action / Talk)` | Target Inspected is obj[37] | Open Dialogue Sub-Window (6); Trigger Character Emotion Effect (255, 254) |
| `ev[154]` | `1 (Action / Talk)` | Target Inspected is obj[38] | Open Dialogue Sub-Window (6); Engine Action #61 |
| `ev[155]` | `1 (Action / Talk)` | Target Inspected is obj[39] | Open Dialogue Sub-Window (6); Engine Action #62 |
| `ev[156]` | `1 (Action / Talk)` | Target Inspected is obj[40] | Open Dialogue Sub-Window (6); Engine Action #63 |
| `ev[157]` | `1 (Action / Talk)` | Target Inspected is obj[41] | Open Dialogue Sub-Window (6); Animate Doorway State (255, 254) |
| `ev[158]` | `1 (Action / Talk)` | Target Inspected is obj[42] | Open Dialogue Sub-Window (6); Play Sound Effect (SE) (255) |
| `ev[159]` | `1 (Action / Talk)` | Target Inspected is obj[43] | Open Dialogue Sub-Window (6); Engine Action #66 |
| `ev[160]` | `1 (Action / Talk)` | Target Inspected is obj[44] | Open Dialogue Sub-Window (6); Open Shop Interface #255 |
| `ev[161]` | `1 (Action / Talk)` | Target Inspected is obj[45] | Open Dialogue Sub-Window (6); Play CD / Ambient BGM Track (255) |
| `ev[162]` | `1 (Action / Talk)` | Target Inspected is obj[46] | Open Dialogue Sub-Window (6); Wait for Audio / Window Sync (255) |
| `ev[163]` | `1 (Action / Talk)` | Target Inspected is obj[47] | Open Dialogue Sub-Window (6); Recruit Hero #255 into Battle Slot 254 |
| `ev[164]` | `1 (Action / Talk)` | Target Inspected is obj[48] | Open Dialogue Sub-Window (6); Remove Character from Active Party (255) |
| `ev[165]` | `1 (Action / Talk)` | Target Inspected is obj[49] | Open Dialogue Sub-Window (6); Load Sound Bank into Memory (255, 254) |
| `ev[166]` | `1 (Action / Talk)` | Target Inspected is obj[50] | Open Dialogue Sub-Window (6); Set Combat Battle BGM (255) |
| `ev[167]` | `1 (Action / Talk)` | Target Inspected is obj[51] | Open Dialogue Sub-Window (6); Set Special Scene BGM (255) |
| `ev[168]` | `1 (Action / Talk)` | Target Inspected is obj[52] | Open Dialogue Sub-Window (6); Full Rest & Healing (Restore HP/MP) |
| `ev[169]` | `1 (Action / Talk)` | Target Inspected is obj[53] | Open Dialogue Sub-Window (6); Full Rest & Healing (Restore HP/MP) |
| `ev[170]` | `1 (Action / Talk)` | Target Inspected is obj[54] | Open Dialogue Sub-Window (6); Award Potch Currency (255,254) |
| `ev[171]` | `1 (Action / Talk)` | Target Inspected is obj[55] | Open Dialogue Sub-Window (6); Engine Action #78 |
| `ev[172]` | `1 (Action / Talk)` | Target Inspected is obj[56] | Open Dialogue Sub-Window (6); Bytecode Subroutine Return |
| `ev[173]` | `1 (Action / Talk)` | Target Inspected is obj[57] | Open Dialogue Sub-Window (6); Engine Action #80 |
| `ev[174]` | `1 (Action / Talk)` | Target Inspected is obj[58] | Open Dialogue Sub-Window (6); Engine Action #81 |
| `ev[175]` | `1 (Action / Talk)` | Target Inspected is obj[59] | Open Dialogue Sub-Window (6); Remove Item from Inventory (255, 254) |
| `ev[176]` | `1 (Action / Talk)` | Target Inspected is obj[60] | Open Dialogue Sub-Window (6); Engine Action #83 |
| `ev[177]` | `1 (Action / Talk)` | Target Inspected is obj[61] | Open Dialogue Sub-Window (6); Dismiss Character to Castle Base (255) |
| `ev[178]` | `1 (Action / Talk)` | Target Inspected is obj[62] | Open Dialogue Sub-Window (6); Engine Action #85 |
| `ev[179]` | `1 (Action / Talk)` | Target Inspected is obj[63] | Open Dialogue Sub-Window (6); Animate Door obj[255] (State: 254) |
| `ev[180]` | `1 (Action / Talk)` | Target Inspected is obj[64] | Open Dialogue Sub-Window (6); Engine Action #87 |
| `ev[181]` | `1 (Action / Talk)` | Target Inspected is obj[65] | Open Dialogue Sub-Window (6); Engine Action #88 |
| `ev[182]` | `1 (Action / Talk)` | Target Inspected is obj[66] | Open Dialogue Sub-Window (6); Engine Action #89 |
| `ev[183]` | `1 (Action / Talk)` | Target Inspected is obj[67] | Open Dialogue Sub-Window (6); Engine Action #90 |
| `ev[184]` | `1 (Action / Talk)` | Target Inspected is obj[68] | Open Dialogue Sub-Window (6); Make Object Visible (disp = 1) (255) |
| `ev[185]` | `1 (Action / Talk)` | Target Inspected is obj[69] | Open Dialogue Sub-Window (6); Make Object Hidden (disp = 0) (255) |
| `ev[186]` | `1 (Action / Talk)` | Target Inspected is obj[70] | Open Dialogue Sub-Window (6); Engine Action #93 |
| `ev[187]` | `1 (Action / Talk)` | Target Inspected is obj[71] | Open Dialogue Sub-Window (6); Engine Action #94 |
| `ev[188]` | `1 (Action / Talk)` | Target Inspected is obj[72] | Open Dialogue Sub-Window (6); Set Story Milestone Flag 255 (mask 254) |
| `ev[189]` | `1 (Action / Talk)` | Target Inspected is obj[73] | Open Dialogue Sub-Window (6); Clear Story Milestone Flag 255 (mask 254) |
| `ev[190]` | `1 (Action / Talk)` | Target Inspected is obj[74] | Open Dialogue Sub-Window (6); Mark Chest Looted (Byte 255, Bit 254) |
| `ev[191]` | `1 (Action / Talk)` | Target Inspected is obj[75] | Open Dialogue Sub-Window (6); Clear Chest Looted Flag (255, 254) |
| `ev[192]` | `1 (Action / Talk)` | Target Inspected is obj[76] | Open Dialogue Sub-Window (6); Engine Action #99 |

---



## Location Map: `vc07`

- **Master Map Container**: `vc07.json`
- **Submap Layer Files**: vc07_00.json
- **Collision Grid Files**: vc07_map_00.json
- **Sprite Animation Bundles**: vc07_00_obj.json
- **Submap Room Count**: 6

### Submap Layer `vc07_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `9` Objects | **Script Count (`evkaz`)**: `39` Scripts

#### Complete Physical Entity Inventory (9 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Matilda Knight Guard** | `65106` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Matilda Knight Guard** | `65106` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Matilda Knight Guard** | `65106` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | NPC / Actor | **Actor ID 65104** | `65104` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[04]` | NPC / Actor | **Actor ID 65104** | `65104` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[05]` | NPC / Actor | **Actor ID 65105** | `65105` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[06]` | NPC / Actor | **Actor ID 65105** | `65105` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[07]` | NPC / Actor | **Actor ID 65105** | `65105` | `(56, 21)` | `0x0` | Up (North) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[08]` | World Device | **Mechanism (ano 0)** | `0` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Matilda Knight Guard)**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Matilda Knight Guard)**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Matilda Knight Guard)**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Object 65104)**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Object 65104)**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Object 65105)**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[06]` (Object 65105)**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[07]` (Object 65105)**: Positioned at tile `(56, 21)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[08]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(0, 0)` with state parameter `0`.


#### Complete Bytecode Script Catalog (39 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Always Passes (Unconditional) | Make obj[2] Hidden (disp = 0); Dismiss Dialogue Portrait; Dismiss Dialogue Portrait; Engine Action #40; Open Dialogue Message Window; Dismiss Dialogue Portrait; Teleport obj[255] to (254,255) |
| `ev[01]` | `2 (Map Init)` | Story Flag 14 (bit 128) CLEAR | Make obj[2] Hidden (disp = 0); Reset Camera Tracking (23); Open Shop Menu #8 (Type: 0); Warp to Castle HQ (8, 0, 2); Engine Action #9; Change Portrait Expression (43); Open Dialogue Message Window; Engine Action #9; Warp to Castle HQ (9, 0, 2); Screen Fade Transition (20, 7, 0); Screen Fade Transition (3, 10, 0); Teleport obj[255] to (254,255) |
| `ev[02]` | `2 (Map Init)` | Story Flag 10 (bit 2) SET AND Story Flag 10 (bit 8) CLEAR | Make obj[2] Hidden (disp = 0); Reset Camera Tracking (39); Open Dialogue Sub-Window (0); Reset Camera Tracking (3); Reset Camera Tracking (2); Teleport obj[255] to (254,255) |
| `ev[03]` | `2 (Map Init)` | Story Flag 10 (bit 4) SET AND Story Flag 10 (bit 8) CLEAR | Make obj[2] Hidden (disp = 0); Engine Action #9; Engine Action #39; Open Dialogue Sub-Window (0); Engine Action #9; Warp to Castle HQ (9, 2, 47) |
| `ev[04]` | `2 (Map Init)` | Story Flag 14 (bit 128) SET AND Story Flag 98 (bit 128) CLEAR | Make obj[2] Hidden (disp = 0); Close Dialogue Window; Open Dialogue Sub-Window (43); Open Dialogue Message Window; Close Dialogue Window; Warp to Castle HQ (11, 0, 2); Display Dialogue Box [Bank: 17, MsgID: 43]; Open Dialogue Message Window; Display Dialogue Box [Bank: 3, MsgID: 12]; Open Dialogue Message Window; Warp Room -> Submap 1 at (9,1) facing 10; Teleport obj[255] to (254,255) |
| `ev[05]` | `2 (Map Init)` | Story Flag 98 (bit 128) SET | Make obj[1] Hidden (disp = 0); Close Dialogue Window; Warp Room -> Submap 1 at (8,1) facing 9; Warp Room -> Submap 2 at (13,23) facing 43; Open Dialogue Message Window; Place Scenery Structure (3); Place Scenery Structure (0); Warp Town -> Area 14 Map 17 Submap 43 at (0,14); Warp to Castle HQ (14, 0, 0); Show Dialogue Portrait (47, 255, 254) |
| `ev[06]` | `2 (Map Init)` | Story Flag 10 (bit 6) SET AND Story Flag 14 (bit 128) CLEAR | Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[07]` | `2 (Map Init)` | Story Flag 98 (bit 128) SET | Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[08]` | `1 (Action / Talk)` | Player within Box [58..59, 2..17] AND Condition Check #30 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 3]; Branch on Choice (255, 254) |
| `ev[09]` | `1 (Action / Talk)` | Player within Box [0..30, 2..60] AND Condition Check #61 AND Story Flag 0 (mask 255) SET | Warp Room -> Submap 2 at (12,2); Warp Map Transition (0, 0, 202, 57, 255) |
| `ev[10]` | `128 (Loop)` | Player within Box [0..35, 2..55] AND Condition Check #60 | Warp Room -> Submap 2 at (12,2) |
| `ev[11]` | `1 (Action / Talk)` | Player within Box [10..30, 2..0] AND Inventory Holds Item #9 [Kindness Drops] AND Player X within Range [255..254] | Warp Room -> Submap 2 at (12,9); Warp Map Transition (0, 0, 73, 190, 255) |
| `ev[12]` | `1 (Action / Talk)` | Story Flag 9 (bit 128) CLEAR AND Target Inspected is obj[8] | Open Dialogue Sub-Window (5); Open Dialogue Message Window; Warp to Castle HQ (8, 0, 255) |
| `ev[13]` | `1 (Action / Talk)` | Story Flag 9 (bit 128) CLEAR AND Target Inspected is obj[9] | Open Dialogue Sub-Window (5); Warp Room -> Submap 9 at (0,255) facing 254 |
| `ev[14]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Open Dialogue Sub-Window (5); Warp Town -> Area 3 Map 11 Submap 0 at (255,254) |
| `ev[15]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Open Dialogue Sub-Window (5); Warp to Castle HQ (3, 12, 0) |
| `ev[16]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Open Dialogue Sub-Window (5); Exit to World Map (3, 13, 0) |
| `ev[17]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Open Dialogue Sub-Window (5); Engine Action #5; Warp to Castle HQ (14, 0, 255) |
| `ev[18]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) CLEAR AND Player within Box [0..35, 2..10] AND Player X in Range [9..1] | Recruit Character into Active Party (24 [Milie], 10); Warp Room -> Submap 5 at (0,4) facing 4; Engine Action #5; Show Dialogue Portrait (7, 1, 3); Open Dialogue Message Window; Engine Action #5; Exit to World Map (0, 1, 30); Engine Action #58 |
| `ev[19]` | `1 (Action / Talk)` | Story Flag 9 (bit 128) SET AND Story Flag 10 (bit 2) CLEAR AND Story Flag 10 (bit 4) CLEAR AND Target Inspected is obj[8] | Recruit Character into Active Party (43 [Ayda], 0); Engine Action #5; Set Render Priority (pri) (0, 23); Make obj[8] Hidden (disp = 0); Warp to Castle HQ (8, 0, 33); Warp Town -> Area 18 Map 80 Submap 46 at (0,1); Open Dialogue Message Window; Warp Town -> Area 0 Map 3 Submap 0 at (4,0); Engine Action #5; Teleport obj[49] to (6,5); Open Dialogue Message Window; Warp Town -> Area 0 Map 5 Submap 5 at (1,0); Dismiss Emotion Bubble (255); Engine Action #5; Warp Room -> Submap 5 at (2,2) facing South (Down); Warp Room -> Submap 0 at (5,5) facing West (Left); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Warp Town -> Area 4 Map 5 Submap 3 at (2,0); Warp Room -> Submap 0 at (5,5) facing West (Left); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Warp to Castle HQ (4, 5, 0); Exit to World Map (2, 0, 5); Engine Action #5; Warp Room -> Submap 30 at (255,254) facing 5; Exit to World Map (4, 5, 0); Exit to World Map (2, 3, 1); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Engine Action #5; Exit to World Map (5, 0, 4); Warp to Castle HQ (3, 1, 0); Dismiss Emotion Bubble (255); Walk obj[73] to (15,24); Reset Camera Tracking (0); Open Dialogue Message Window; Engine Action #5; Warp Town -> Area 4 Map 4 Submap 1 at (1,5); Show Dialogue Portrait (30, 24, 2); Open Dialogue Message Window; Warp Room -> Submap 15 at (24,8) facing South (Down); Warp Town -> Area 5 Map 8 Submap 5 at (15,2); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Exit to World Map (4, 1, 2); Engine Action #5; Engine Action #5; Warp to Castle HQ (0, 30, 101); Open Dialogue Message Window; Engine Action #178; Set Combat Battle BGM (30); Jump to Bytecode Offset (0, 176); Engine Action #90; Dismiss Dialogue Portrait; Exit to World Map (3, 17, 6); Dismiss Emotion Bubble (101); Engine Action #5; Engine Action #176; Warp Room -> Submap 5 at (8,4) facing 4; Engine Action #5; Show Dialogue Portrait (1, 8, 30); Engine Action #5; Warp Room -> Submap 30 at (4,4) facing West (Left); Warp Room -> Submap 0 at (30,5) facing South (Down); Engine Action #5; Warp to Castle HQ (2, 0, 30); Engine Action #5; Warp Town -> Area 5 Map 12 Submap 2 at (0,30); Close Dialogue Sub-Window (1); Open Dialogue Message Window; Warp to Castle HQ (73, 6, 72); Warp Room -> Submap 4 at (24,2) facing South (Down); Exit to World Map (72, 0, 2); Set Entity Movement Speed (4, 5); Reset Camera Tracking (4); Exit to World Map (0, 10, 30); Engine Action #5; Open Dialogue Message Window; Engine Action #5; Engine Action #90; Warp Room -> Submap 30 at (255,254) facing 5; Warp Room -> Submap 80 at (1,0) facing 30; Engine Action #5; Warp Town -> Area 5 Map 100 Submap 1 at (0,30); Walk obj[24] to (8,0); Engine Action #5; Launch Tactical War Battle (1); Set Combat Battle BGM (100); Set Entity Movement Speed (5, 5); Warp Room -> Submap 5 at (3,2) facing 30; Warp Room -> Submap 255 at (254,5) facing Up (North); Exit to World Map (5, 2, 2); Dismiss Emotion Bubble (1); Warp Town -> Area 255 Map 254 Submap 5 at (3,4); Engine Action #5; Warp Room -> Submap 30 at (1,3) facing 255; Engine Action #5; Exit to World Map (4, 5, 1); Exit to World Map (3, 3, 30); Warp Room -> Submap 255 at (254,5) facing 5; Exit to World Map (5, 1, 4); Warp Town -> Area 3 Map 30 Submap 1 at (5,255); Walk obj[73] to (30,34); Engine Action #9; Screen Fade Transition (2, 37, 254); Engine Action #58 |
| `ev[20]` | `128 (Loop)` | Story Flag 9 (bit 128) SET AND Story Flag 10 (bit 2) CLEAR AND Inventory Holds Item #1 [Medicine] AND Temp Event Flag #2 SET | Engine Action #5; Reset Camera Tracking (4); Exit to World Map (1, 20, 4); Engine Action #5; Warp to Castle HQ (16, 0, 0); Engine Action #5; Engine Action #5; Warp Town -> Area 0 Map 30 Submap 36 at (2,255) |
| `ev[21]` | `1 (Action / Talk)` | Story Flag 9 (bit 128) SET AND Story Flag 10 (bit 2) CLEAR AND Story Flag 10 (bit 4) CLEAR AND Target Inspected is obj[9] | Recruit Character into Active Party (43 [Ayda], 0); Engine Action #5; Set Render Priority (pri) (0, 17); Make obj[8] Hidden (disp = 0); Warp to Castle HQ (9, 0, 33); Warp Town -> Area 18 Map 80 Submap 46 at (0,1); Open Dialogue Message Window; Warp Town -> Area 0 Map 3 Submap 0 at (4,0); Engine Action #5; Teleport obj[49] to (6,5); Open Dialogue Message Window; Warp Town -> Area 0 Map 5 Submap 5 at (1,0); Dismiss Emotion Bubble (255); Engine Action #5; Warp Room -> Submap 5 at (2,2) facing South (Down); Warp Room -> Submap 0 at (5,5) facing West (Left); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Warp Town -> Area 4 Map 5 Submap 3 at (2,0); Warp Room -> Submap 0 at (5,5) facing West (Left); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Warp to Castle HQ (4, 5, 0); Exit to World Map (2, 0, 5); Engine Action #5; Warp Room -> Submap 30 at (255,254) facing 5; Exit to World Map (4, 5, 0); Exit to World Map (2, 3, 1); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Engine Action #5; Exit to World Map (5, 0, 4); Warp to Castle HQ (3, 1, 0); Dismiss Emotion Bubble (255); Walk obj[73] to (15,24); Engine Action #9; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Warp Town -> Area 4 Map 4 Submap 1 at (1,5); Show Dialogue Portrait (30, 24, 2); Open Dialogue Message Window; Warp Room -> Submap 15 at (24,9) facing South (Down); Warp Town -> Area 5 Map 9 Submap 5 at (15,3); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Exit to World Map (4, 1, 2); Engine Action #5; Engine Action #5; Warp Town -> Area 0 Map 30 Submap 101 at (0,178); Set Combat Battle BGM (30); Jump to Bytecode Offset (0, 176); Engine Action #90; Dismiss Dialogue Portrait; Exit to World Map (3, 17, 6); Dismiss Emotion Bubble (101); Engine Action #5; Engine Action #176; Warp Room -> Submap 5 at (9,4) facing 4; Engine Action #5; Show Dialogue Portrait (1, 8, 30); Engine Action #5; Warp Room -> Submap 30 at (4,4) facing West (Left); Warp Room -> Submap 0 at (30,5) facing South (Down); Engine Action #5; Warp to Castle HQ (2, 0, 30); Engine Action #5; Warp Town -> Area 5 Map 12 Submap 2 at (0,30); Close Dialogue Sub-Window (1); Open Dialogue Message Window; Warp to Castle HQ (73, 6, 72); Warp Room -> Submap 4 at (24,2) facing South (Down); Exit to World Map (72, 0, 2); Set Entity Movement Speed (4, 5); Engine Action #9; Exit to World Map (4, 0, 10); Dismiss Emotion Bubble (255); Engine Action #5; Open Dialogue Message Window; Engine Action #5; Engine Action #90; Warp Room -> Submap 30 at (255,254) facing 5; Warp Room -> Submap 100 at (1,0) facing 30; Engine Action #5; Warp Town -> Area 5 Map 80 Submap 1 at (0,30); Walk obj[24] to (9,0); Engine Action #5; Launch Tactical War Battle (4); Set Combat Battle BGM (100); Set Entity Movement Speed (5, 5); Warp Room -> Submap 5 at (3,2) facing 30; Warp Room -> Submap 255 at (254,5) facing Up (North); Exit to World Map (5, 2, 2); Dismiss Emotion Bubble (1); Warp Town -> Area 255 Map 254 Submap 5 at (3,4); Engine Action #5; Warp Room -> Submap 30 at (1,3) facing 255; Engine Action #5; Exit to World Map (4, 5, 1); Exit to World Map (3, 3, 30); Warp Room -> Submap 255 at (254,5) facing 5; Exit to World Map (5, 1, 4); Warp Town -> Area 3 Map 30 Submap 1 at (5,255); Walk obj[73] to (30,34); Engine Action #9; Screen Fade Transition (4, 37, 254); Engine Action #58 |
| `ev[22]` | `128 (Loop)` | Story Flag 9 (bit 128) SET AND Story Flag 10 (bit 2) CLEAR AND Inventory Holds Item #4 [Throat Drops] AND Temp Event Flag #8 SET | Engine Action #5; Engine Action #9; Exit to World Map (4, 3, 3); Warp Room -> Submap 4 at (5,3) facing 19; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp Town -> Area 0 Map 30 Submap 36 at (8,255) |
| `ev[23]` | `1 (Action / Talk)` | Story Flag 10 (bit 4) SET AND Story Flag 10 (bit 8) CLEAR AND Target Inspected is obj[8] | Recruit Character into Active Party (24 [Milie], 8); Warp Room -> Submap 3 at (8,0) facing 58 |
| `ev[24]` | `1 (Action / Talk)` | Story Flag 10 (bit 2) SET AND Story Flag 10 (bit 8) CLEAR AND Target Inspected is obj[9] | Recruit Character into Active Party (24 [Milie], 9); Warp Room -> Submap 3 at (9,0) facing 58 |
| `ev[25]` | `1 (Action / Talk)` | Story Flag 10 (bit 2) SET AND Story Flag 10 (bit 8) CLEAR AND Player within Box [43..45, 2..15] AND Condition Check #30 AND Story Flag 3 (mask 255) SET | Recruit Character into Active Party (33 [Camus], 1); Display Speaker Name Box (0); Warp Room -> Submap 1 at (4,5) facing East (Right); Warp to Castle HQ (0, 0, 5); Engine Action #5; Warp Town -> Area 0 Map 5 Submap 15 at (30,24); Warp Room -> Submap 14 at (5,1) facing 5; Show Dialogue Portrait (2, 3, 30); Warp Room -> Submap 5 at (0,0) facing South (Down); Engine Action #5; Show Dialogue Portrait (4, 4, 2); Warp Town -> Area 30 Map 34 Submap 58 at (255,254) |
| `ev[26]` | `1 (Action / Talk)` | Story Flag 10 (bit 4) SET AND Story Flag 10 (bit 8) CLEAR AND Player within Box [43..45, 2..15] AND Condition Check #30 AND Story Flag 3 (mask 255) SET | Recruit Character into Active Party (33 [Camus], 1); Display Speaker Name Box (0); Warp Room -> Submap 1 at (4,5) facing East (Right); Warp to Castle HQ (0, 0, 5); Engine Action #5; Warp Town -> Area 0 Map 5 Submap 15 at (30,24); Warp Room -> Submap 14 at (5,1) facing 5; Show Dialogue Portrait (2, 3, 30); Warp Room -> Submap 5 at (0,0) facing South (Down); Engine Action #5; Show Dialogue Portrait (4, 4, 2); Warp Town -> Area 30 Map 34 Submap 58 at (255,254) |
| `ev[27]` | `1 (Action / Talk)` | Story Flag 10 (bit 2) SET AND Story Flag 10 (bit 8) CLEAR AND Target Inspected is obj[8] | Recruit Character into Active Party (43 [Ayda], 0); Engine Action #5; Set Render Priority (pri) (0, 40); Execute Choice Result (9); Warp to Castle HQ (0, 0, 5); Reset Camera Tracking (1); Open Dialogue Message Window; Engine Action #5; Dismiss Emotion Bubble (3); Open Dialogue Message Window; Dismiss Emotion Bubble (24); Reset Camera Tracking (0); Engine Action #6; Set Combat Battle BGM (15); Launch Tactical War Battle (16); Set Combat Battle BGM (30); Return to Previous Memory Map (2); Display Speaker Name Box (80); Make obj[0] Hidden (disp = 0); Warp Room -> Submap 2 at (0,3) facing South (Down); Exit to World Map (0, 5, 47); Set Entity Movement Speed (5, 5); Warp Room -> Submap 5 at (2,2) facing South (Down); Warp Town -> Area 2 Map 0 Submap 5 at (5,1); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Warp Town -> Area 4 Map 5 Submap 3 at (2,0); Warp Town -> Area 3 Map 0 Submap 5 at (5,1); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Warp to Castle HQ (4, 5, 0); Exit to World Map (2, 0, 5); Engine Action #5; Warp Room -> Submap 30 at (255,254) facing 5; Exit to World Map (4, 5, 0); Exit to World Map (2, 3, 1); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Engine Action #5; Exit to World Map (5, 0, 4); Warp to Castle HQ (3, 1, 0); Dismiss Emotion Bubble (255); Walk obj[5] to (2,5); Show Dialogue Portrait (2, 0, 5); Show Dialogue Portrait (30, 5, 1); Warp to Castle HQ (0, 30, 24); Warp Town -> Area 0 Map 7 Submap 73 at (15,24); Warp Room -> Submap 8 at (73,30) facing 39; Return Warp to Castle Base (3, 0); Warp to Castle HQ (9, 10, 4); Engine Action #9; Screen Fade Transition (8, 37, 254); Engine Action #58 |
| `ev[28]` | `128 (Loop)` | Story Flag 10 (bit 2) SET AND Story Flag 10 (bit 8) CLEAR AND Inventory Holds Item #16 [Revenge Earth] AND Temp Event Flag #32 SET | Engine Action #5; Reset Camera Tracking (4); Exit to World Map (1, 0, 5); Engine Action #5; Warp Town -> Area 18 Map 0 Submap 20 at (4,5); Warp to Castle HQ (2, 0, 0); Dismiss Emotion Bubble (36); Warp Map Transition (255, 254, 255, 254, 204) |
| `ev[29]` | `1 (Action / Talk)` | Story Flag 10 (bit 4) SET AND Story Flag 10 (bit 8) CLEAR AND Target Inspected is obj[9] | Recruit Character into Active Party (43 [Ayda], 0); Engine Action #5; Set Render Priority (pri) (0, 40); Execute Choice Result (9); Warp to Castle HQ (0, 0, 5); Engine Action #9; Warp Room -> Submap 5 at (30,3) facing South (Down); Dismiss Emotion Bubble (24); Engine Action #9; Open Dialogue Message Window; Engine Action #6; Set Combat Battle BGM (15); Launch Tactical War Battle (64); Set Combat Battle BGM (30); Return to Previous Memory Map (2); Display Speaker Name Box (80); Make obj[0] Hidden (disp = 0); Warp Room -> Submap 2 at (0,3) facing South (Down); Exit to World Map (0, 5, 47); Set Entity Movement Speed (5, 5); Warp Room -> Submap 5 at (2,2) facing South (Down); Warp Town -> Area 2 Map 0 Submap 5 at (5,1); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Warp Town -> Area 4 Map 5 Submap 3 at (2,0); Warp Town -> Area 3 Map 0 Submap 5 at (5,1); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Warp to Castle HQ (4, 5, 0); Exit to World Map (2, 0, 5); Engine Action #5; Warp Room -> Submap 30 at (255,254) facing 5; Exit to World Map (4, 5, 0); Exit to World Map (2, 3, 1); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Engine Action #5; Exit to World Map (5, 0, 4); Warp to Castle HQ (3, 1, 0); Dismiss Emotion Bubble (255); Walk obj[5] to (2,5); Show Dialogue Portrait (2, 0, 5); Show Dialogue Portrait (30, 5, 1); Warp to Castle HQ (0, 30, 24); Warp Town -> Area 0 Map 7 Submap 73 at (15,24); Warp Room -> Submap 8 at (73,30) facing 39; Return Warp to Castle Base (3, 0); Warp to Castle HQ (9, 10, 2); Engine Action #9; Screen Fade Transition (8, 37, 254); Engine Action #58 |
| `ev[30]` | `128 (Loop)` | Story Flag 10 (bit 4) SET AND Story Flag 10 (bit 8) CLEAR AND Inventory Holds Item #64 [Recipe #33] AND Temp Event Flag #128 SET | Engine Action #5; Engine Action #9; Exit to World Map (4, 5, 30); Warp Room -> Submap 5 at (5,2) facing 19; Open Dialogue Message Window; Branch on Choice (2, 3); Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (36); Engine Action #128 |
| `ev[31]` | `1 (Action / Talk)` | Story Flag 10 (bit 8) SET AND Story Flag 10 (bit 16) CLEAR AND Target Inspected is obj[8] | Recruit Character into Active Party (24 [Milie], 8); Warp Room -> Submap 3 at (8,0) facing 58 |
| `ev[32]` | `1 (Action / Talk)` | Story Flag 10 (bit 8) SET AND Story Flag 10 (bit 16) CLEAR AND Target Inspected is obj[9] | Recruit Character into Active Party (24 [Milie], 9); Warp Room -> Submap 3 at (9,0) facing 58 |
| `ev[33]` | `1 (Action / Talk)` | Story Flag 10 (bit 16) SET AND Story Flag 10 (bit 32) CLEAR AND Story Flag 1 (bit 8) SET AND Player within Box [56..56, 2..22] AND Inventory Lacks Item #255 | Recruit Character into Active Party (33 [Camus], 1); Display Speaker Name Box (46); Launch Tactical War Battle (128); Open Dialogue Message Window; Warp Room -> Submap 2 at (0,3) facing South (Down); Exit to World Map (47, 49, 4); Engine Action #5; Warp Room -> Submap 6 at (0,2) facing Up (North); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Warp Town -> Area 4 Map 6 Submap 3 at (3,1); Warp Town -> Area 2 Map 0 Submap 30 at (255,254); Engine Action #5; Warp to Castle HQ (4, 6, 3); Exit to World Map (2, 0, 30); Engine Action #5; Exit to World Map (4, 6, 3); Warp to Castle HQ (0, 2, 2); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Walk obj[101] to (1,0); Launch Tactical War Battle (1); Set Entity Movement Speed (5, 5); Open Dialogue Message Window; Exit to World Map (4, 5, 10); Warp Town -> Area 17 Map 30 Submap 255 at (254,5); Warp Room -> Submap 4 at (5,3) facing Up (North); Change Portrait Expression (30); Engine Action #5; Warp Town -> Area 4 Map 4 Submap 5 at (15,2); Change Portrait Expression (30); Engine Action #5; Warp to Castle HQ (4, 4, 5); Clear Dialogue Sub-Window; Warp Town -> Area 17 Map 30 Submap 255 at (254,5); Exit to World Map (4, 4, 5); Branch on Choice (2, 17); Dismiss Emotion Bubble (255); Walk obj[54] to (1,2); Set Combat Battle BGM (30); Engine Action #5; Warp Room -> Submap 0 at (5,15) facing 30; Close Dialogue Sub-Window (1); Open Dialogue Message Window; Engine Action #121; Set Combat Battle BGM (30); Close Dialogue Sub-Window (1); Open Dialogue Message Window; Engine Action #122; Engine Action #5; Open Dialogue Message Window; Engine Action #5; Trigger Character Emotion Effect (0, 0); Engine Action #5; Trigger Character Emotion Effect (30, 39); Return Warp to Castle Base (46, 9); Screen Fade Transition (1, 9, 10); Warp Map Transition (10, 0, 254, 10, 1); Teleport obj[54] to (0,128); Engine Action #58 |
| `ev[34]` | `128 (Loop)` | Story Flag 10 (bit 16) SET AND Story Flag 10 (bit 32) CLEAR AND Story Flag 1 (bit 8) SET AND Inventory Holds Item #1 [Medicine] AND Temp Event Flag #2 SET | Close Dialogue Window; Warp Room -> Submap 90 at (36,2) facing 255 |
| `ev[35]` | `128 (Loop)` | Story Flag 10 (bit 16) SET AND Story Flag 10 (bit 32) CLEAR AND Story Flag 1 (bit 8) SET AND Inventory Holds Item #128 | Warp Room -> Submap 2 at (12,2); Toggle Random Encounters (128) |
| `ev[36]` | `1 (Action / Talk)` | Story Flag 10 (bit 32) SET AND Target Inspected is obj[8] | Recruit Character into Active Party (24 [Milie], 8); Warp Room -> Submap 3 at (8,0) facing 58 |
| `ev[37]` | `1 (Action / Talk)` | Story Flag 10 (bit 32) SET AND Target Inspected is obj[9] | Recruit Character into Active Party (24 [Milie], 9); Warp Room -> Submap 3 at (9,0) facing 58 |
| `ev[38]` | `1 (Action / Talk)` | Story Flag 98 (bit 128) SET AND Player within Box [43..45, 2..15] AND Condition Check #30 AND Story Flag 3 (mask 255) SET | Recruit Character into Active Party (43 [Ayda], 0); Exit to World Map (4, 0, 46); Execute Choice Result (9); Set Combat Battle BGM (15); Engine Action #118; Show Dialogue Portrait (2, 7, 4); Place Scenery Structure (5); Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (0, 0, 5); Engine Action #5; Exit to World Map (4, 2, 5); Dismiss Emotion Bubble (58) |

---

### Submap Layer `vc07_01` (Index 1)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `30`, Rate: `8`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `2` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (2 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [0..1, 2..16] AND Condition Check #30 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 56]; Execute Choice Result (255) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [25..48, 2..2] AND Story Flag 9 (bit 1) SET | Display Dialogue Box [Bank: 2, MsgID: 23]; Engine Action #89 |

---

### Submap Layer `vc07_02` (Index 2)

- **Map Number (`mapno`)**: `2`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `30`, Rate: `8`)
- **Entity Count (`okaz`)**: `2` Objects | **Script Count (`evkaz`)**: `5` Scripts

#### Complete Physical Entity Inventory (2 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | Treasure Chest | **Closed Chest (Unopened)** | `0` | `(94, 47)` | `0x0` | Up (North) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | Treasure Chest | **Opened Chest** | `0` | `(94, 47)` | `0x0` | East (Right) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Treasure Chest)**: Placed at tile `(94, 47)`. Initial state is Closed (Unopened). Controlled by map loot bitflags.
- **`obj[01]` (Treasure Chest)**: Placed at tile `(94, 47)`. Initial state is Open. Controlled by map loot bitflags.


#### Complete Bytecode Script Catalog (5 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Treasure Byte 1 Bit 64 LOOTED | Make obj[1] Hidden (disp = 0); Reset Camera Tracking (0); Engine Action #9; Teleport obj[255] to (254,255) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [96..121, 2..5] AND Inventory Holds Item #9 [Kindness Drops] AND Player X within Range [255..254] | Display Dialogue Box [Bank: 3, MsgID: 12]; Engine Action #89 |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [0..36, 2..91] AND Condition Check #92 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 36]; Exit to World Map (255, 254, 204) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [160..161, 2..76] AND Condition Check #90 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 5, MsgID: 3]; Branch on Choice (255, 254) |
| `ev[04]` | `1 (Action / Talk)` | Treasure Byte 1 Bit 64 FRESH (Unopened) AND Target Inspected is obj[8] | Recruit Character into Active Party (46 [Oulan], 0); Engine Action #9; Warp Room -> Submap 47 at (101,4) facing 7; Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (2); Exit to World Map (0, 68, 16); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,1) facing 64; Engine Action #51; Warp Town -> Area 255 Map 1 Submap 46 at (0,8); Warp Room -> Submap 47 at (255,2) facing 58 |

---

### Submap Layer `vc07_03` (Index 3)

- **Map Number (`mapno`)**: `3`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `30`, Rate: `8`)
- **Entity Count (`okaz`)**: `2` Objects | **Script Count (`evkaz`)**: `4` Scripts

#### Complete Physical Entity Inventory (2 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Matilda Knight Guard** | `65106` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Matilda Knight Guard** | `65106` | `(10, 10)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Matilda Knight Guard)**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Matilda Knight Guard)**: Positioned at tile `(10, 10)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.


#### Complete Bytecode Script Catalog (4 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 10 (bit 32) SET AND Story Flag 14 (bit 128) CLEAR | Make obj[2] Hidden (disp = 0); Reset Camera Tracking (15); Engine Action #61; Open Dialogue Message Window; Reset Camera Tracking (3); Reset Camera Tracking (1); Warp Town -> Area 9 Map 19 Submap 61 at (0,9); Warp to Castle HQ (9, 1, 47) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [12..33, 2..2] AND Story Flag 9 (bit 1) SET | Display Dialogue Box [Bank: 4, MsgID: 15]; Set obj[255] Collision to Passable |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [0..22, 2..91] AND Condition Check #92 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 110]; Reset Camera Tracking (255) |
| `ev[03]` | `1 (Action / Talk)` | Story Flag 10 (bit 32) SET AND Story Flag 14 (bit 128) CLEAR AND Player within Box [0..25, 2..68] AND Condition Check #70 AND Story Flag 1 (mask 255) SET | Recruit Character into Active Party (49 [Abizboah], 2); Engine Action #5; Reset Camera Tracking (3); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Engine Action #9; Engine Action #5; Engine Action #5; Warp Town -> Area 0 Map 5 Submap 5 at (0,0); Engine Action #5; Screen Fade Transition (30, 255, 254); Walk obj[24] to (8,1); Display Speaker Name Box (5); Open Dialogue Message Window; Exit to World Map (4, 5, 15); Pan Camera (1, 3, 0); Engine Action #5; Engine Action #5; Open Dialogue Message Window; Warp Room -> Submap 49 at (2,5) facing 8; Warp to Castle HQ (0, 5, 5); Warp Room -> Submap 30 at (255,254) facing 5; Engine Action #9; Engine Action #5; Engine Action #5; Warp Town -> Area 0 Map 5 Submap 5 at (1,0); Dismiss Emotion Bubble (255); Walk obj[58] to (255,254) |

---

### Submap Layer `vc07_04` (Index 4)

- **Map Number (`mapno`)**: `4`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `30`, Rate: `8`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `3` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (3 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [98..120, 2..5] AND Inventory Holds Item #9 [Kindness Drops] AND Player X within Range [255..254] | Warp Room -> Submap 1 at (2,29); Warp Map Transition (2, 250, 0, 0, 255) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [0..24, 2..61] AND Condition Check #62 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 3, MsgID: 22]; Exit to World Map (255, 254, 204) |
| `ev[02]` | `128 (Loop)` | Player within Box [0..30, 2..55] AND Condition Check #57 | Warp Room -> Submap 1 at (2,29) |

---

### Submap Layer `vc07_05` (Index 5)

- **Map Number (`mapno`)**: `5`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `30`, Rate: `8`)
- **Entity Count (`okaz`)**: `2` Objects | **Script Count (`evkaz`)**: `3` Scripts

#### Complete Physical Entity Inventory (2 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | Treasure Chest | **Closed Chest (Unopened)** | `0` | `(65, 17)` | `0x0` | Up (North) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | Treasure Chest | **Opened Chest** | `0` | `(65, 17)` | `0x0` | East (Right) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Treasure Chest)**: Placed at tile `(65, 17)`. Initial state is Closed (Unopened). Controlled by map loot bitflags.
- **`obj[01]` (Treasure Chest)**: Placed at tile `(65, 17)`. Initial state is Open. Controlled by map loot bitflags.


#### Complete Bytecode Script Catalog (3 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Treasure Byte 1 Bit 128 LOOTED | Make obj[1] Hidden (disp = 0); Reset Camera Tracking (0); Engine Action #9; Teleport obj[255] to (254,255) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [0..1, 2..16] AND Condition Check #30 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 158]; Dismiss Character to Castle Base (255) |
| `ev[02]` | `1 (Action / Talk)` | Treasure Byte 1 Bit 128 FRESH (Unopened) AND Target Inspected is obj[8] | Recruit Character into Active Party (46 [Oulan], 0); Engine Action #9; Warp Room -> Submap 47 at (101,4) facing 7; Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (2); Exit to World Map (0, 5, 16); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,1) facing 128; Engine Action #51; Warp Town -> Area 255 Map 1 Submap 46 at (0,8); Warp Room -> Submap 47 at (255,2) facing 58 |

---



## Location Map: `vc08`

- **Master Map Container**: `vc08.json`
- **Submap Layer Files**: vc08_02.json
- **Collision Grid Files**: vc08_map_00.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 1

### Submap Layer `vc08_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `8` Objects | **Script Count (`evkaz`)**: `8` Scripts

#### Complete Physical Entity Inventory (8 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 34384** | `34384` | `(16, 16)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Lebrante (Appraiser)** | `141` | `(16, 16)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[02]` | Prop / Scenery | **Prop ID 53389** | `53389` | `(127, 30)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 55 | 180 |
| `obj[03]` | Prop / Scenery | **Prop ID 53389** | `53389` | `(53, 32)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 55 | 180 |
| `obj[04]` | NPC / Actor | **Jeane (Rune Sage)** | `145` | `(48, 92)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[05]` | World Device | **Mechanism (ano 10)** | `0` | `(29, 33)` | `0x0` | Frame 10 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 180 |
| `obj[06]` | World Device | **Mechanism (ano 10)** | `0` | `(31, 33)` | `0x0` | Frame 10 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 180 |
| `obj[07]` | World Device | **Mechanism (ano 27)** | `0` | `(29, 27)` | `0x0` | Frame 27 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 180 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 34384)**: Positioned at tile `(16, 16)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Lebrante (Appraiser))**: Positioned at tile `(16, 16)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Prop: Object 53389)**: Environmental world dressing prop placed at tile `(127, 30)`. Solid collision is set to `0`.
- **`obj[03]` (Prop: Object 53389)**: Environmental world dressing prop placed at tile `(53, 32)`. Solid collision is set to `0`.
- **`obj[04]` (Jeane (Rune Sage))**: Positioned at tile `(48, 92)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(29, 33)` with state parameter `10`.
- **`obj[06]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(31, 33)` with state parameter `10`.
- **`obj[07]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(29, 27)` with state parameter `27`.


#### Complete Bytecode Script Catalog (8 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Always Passes (Unconditional) | Make obj[2] Hidden (disp = 0); Engine Action #9; Engine Action #39; Set Story Flag (0, 9); Warp to Castle HQ (9, 0, 0); Close Dialogue Window; Engine Action #89; Close Dialogue Window; Warp Town -> Area 4 Map 47 Submap 255 at (254,255) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [39..41, 2..44] AND Condition Check #45 AND Story Flag 0 (mask 255) SET | Warp Room -> Submap 1 at (2,29); Warp Map Transition (2, 1, 36, 61, 255) |
| `ev[02]` | `1 (Action / Talk)` | Story Flag 10 (bit 16) SET AND Story Flag 10 (bit 32) CLEAR AND Story Flag 0 (bit 2) SET AND Story Flag 0 (bit 8) CLEAR AND Player within Box [106..106, 2..47] AND Condition Check #47 AND Story Flag 1 (mask 255) SET | Recruit Character into Active Party (46 [Oulan], 2); Reset Camera Tracking (106); Teleport obj[0] to (8,47); Launch Tactical War Battle (1); Set Entity Movement Speed (2, 5); Reset Camera Tracking (4); Exit to World Map (1, 11, 30); Engine Action #5; Open Dialogue Message Window; Engine Action #5; Dismiss Emotion Bubble (4); Exit to World Map (1, 8, 30); Walk obj[5] to (8,5); Show Dialogue Portrait (3, 0, 5); Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 25, 8); Engine Action #80; Open Dialogue Message Window; Turn obj[49] facing Up (North); Engine Action #5; Open Dialogue Message Window; Exit to World Map (4, 5, 30); Warp Room -> Submap 30 at (255,254) facing 5; Reset Camera Tracking (4); Exit to World Map (5, 15, 3); Warp to Castle HQ (1, 5, 30); Walk obj[73] to (60,49); Warp Town -> Area 5 Map 0 Submap 4 at (4,5); Branch on Choice (3, 7); Warp Room -> Submap 3 at (3,30) facing 255; Engine Action #5; Reset Camera Tracking (4); Exit to World Map (3, 5, 1); Exit to World Map (3, 2, 30); Walk obj[73] to (60,49); Warp Town -> Area 5 Map 0 Submap 4 at (4,1); Exit to World Map (2, 7, 1); Warp Room -> Submap 30 at (2,5) facing West (Left); Warp Room -> Submap 60 at (2,0) facing 5; Engine Action #5; Open Dialogue Message Window; Warp Town -> Area 2 Map 2 Submap 30 at (255,254); Engine Action #5; Reset Camera Tracking (4); Exit to World Map (1, 1, 2); Reset Camera Tracking (0); Open Dialogue Message Window; Engine Action #5; Dismiss Emotion Bubble (2); Pan Camera (5, 30, 1); Warp Town -> Area 2 Map 2 Submap 1 at (3,30); Walk obj[5] to (8,5); Screen Fade Transition (3, 0, 5); Show Dialogue Portrait (30, 25, 8); Engine Action #80; Open Dialogue Message Window; Set Entity Movement Speed (73, 30); Launch Tactical War Battle (4); Set Entity Movement Speed (2, 5); Open Dialogue Message Window; Exit to World Map (4, 0, 18); Dismiss Emotion Bubble (255); Engine Action #5; Reset Camera Tracking (4); Exit to World Map (0, 3, 5); Engine Action #5; Warp to Castle HQ (2, 0, 15); Dismiss Emotion Bubble (255); Walk obj[54] to (1,8); Wait for Audio / Window Sync (3); Warp Room -> Submap 1 at (2,29); Engine Action #9; Open Dialogue Message Window; Reset Camera Tracking (32); Warp Town -> Area 1 Map 106 Submap 38 at (58,255) |
| `ev[03]` | `128 (Loop)` | Story Flag 10 (bit 16) SET AND Story Flag 10 (bit 32) CLEAR AND Story Flag 0 (bit 2) SET AND Story Flag 0 (bit 8) CLEAR AND Inventory Holds Item #1 [Medicine] AND Temp Event Flag #2 SET | Close Dialogue Window; Warp Room -> Submap 90 at (36,2) facing 255 |
| `ev[04]` | `128 (Loop)` | Story Flag 10 (bit 16) SET AND Story Flag 10 (bit 32) CLEAR AND Story Flag 0 (bit 2) SET AND Story Flag 0 (bit 8) CLEAR AND Inventory Holds Item #4 [Throat Drops] AND Temp Event Flag #8 SET | Close Dialogue Window; Warp Town -> Area 2 Map 150 Submap 36 at (8,255) |
| `ev[05]` | `1 (Action / Talk)` | Story Flag 10 (bit 16) SET AND Story Flag 10 (bit 32) CLEAR AND Story Flag 0 (bit 64) SET AND Story Flag 0 (bit 128) CLEAR AND Player within Box [40..40, 2..40] AND Condition Check #40 AND Story Flag 1 (mask 255) SET | Recruit Character into Active Party (46 [Oulan], 2); Reset Camera Tracking (40); Engine Action #40; Open Dialogue Message Window; Reset Camera Tracking (47); Set Entity Movement Speed (2, 5); Open Dialogue Message Window; Exit to World Map (4, 5, 5); Warp Room -> Submap 30 at (255,254) facing 5; Reset Camera Tracking (4); Exit to World Map (3, 2, 1); Warp to Castle HQ (30, 255, 254); Walk obj[73] to (15,49); Warp Town -> Area 5 Map 0 Submap 5 at (15,2); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Reset Camera Tracking (3); Open Dialogue Message Window; Engine Action #5; Dismiss Emotion Bubble (0); Open Dialogue Message Window; Engine Action #5; Dismiss Emotion Bubble (3); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Walk obj[102] to (0,101); Engine Action #9; Engine Action #9; Make Object Hidden (disp = 0) (1); Warp Town -> Area 9 Map 1 Submap 4 at (73,10); Jump to Bytecode Offset (9, 14); Set Entity Movement Speed (2, 5); Open Dialogue Message Window; Warp Room -> Submap 30 at (255,254) facing 5; Reset Camera Tracking (1); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Walk obj[46] to (72,1); Open Dialogue Message Window; Open Dialogue Message Window; Load Sound Bank into Memory (1, 8); Open Dialogue Message Window; Teleport obj[73] to (10,46); Load Sound Bank into Memory (0, 0); Load Sound Bank into Memory (0, 8); Teleport obj[5] to (9,4); Warp to Castle HQ (0, 6, 5); Show Dialogue Portrait (30, 24, 9); Warp Room -> Submap 5 at (8,4) facing East (Right); Engine Action #5; Show Dialogue Portrait (1, 1, 5); Screen Fade Transition (30, 24, 8); Open Dialogue Message Window; Engine Action #58; Close Dialogue Window; Warp Town -> Area 2 Map 100 Submap 44 at (43,0); Pan Camera (4, 0, 34); Open Dialogue Sub-Window (9); Warp Town -> Area 8 Map 45 Submap 24 at (0,8); Warp Town -> Area 12 Map 40 Submap 47 at (0,12); Warp to Castle HQ (12, 1, 3); Engine Action #9; Warp Room -> Submap 30 at (105,0) facing West (Left); Dismiss Emotion Bubble (11); Warp Room -> Submap 90 at (5,12) facing 4; Engine Action #5; Engine Action #5; Trigger Character Emotion Effect (1, 7); Engine Action #5; Show Dialogue Portrait (30, 24, 12); Open Dialogue Message Window; Set obj[5] Collision to Passable; Warp to Castle HQ (0, 5, 15); Warp Room -> Submap 5 at (30,3) facing South (Down); Engine Action #5; Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 24, 9); Open Dialogue Message Window; Trigger Character Emotion Effect (5, 12); Exit to World Map (4, 5, 15); Warp Room -> Submap 5 at (15,30) facing 24; Display Dialogue Box [Bank: 0, MsgID: 61]; Engine Action #5; Engine Action #9; Engine Action #5; Dismiss Emotion Bubble (4); Warp to Castle HQ (3, 2, 5); Dismiss Emotion Bubble (0); Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 24, 9); Open Dialogue Message Window; Engine Action #62; Engine Action #5; Display Dialogue Box [Bank: 4, MsgID: 5]; Engine Action #5; Show Dialogue Portrait (1, 2, 5); Show Dialogue Portrait (30, 24, 12); Open Dialogue Message Window; Engine Action #63; Set Combat Battle BGM (15); Close Dialogue Sub-Window (9); Open Dialogue Message Window; Animate Doorway State (5, 12); Exit to World Map (3, 7, 2); Engine Action #5; Show Dialogue Portrait (30, 24, 12); Open Dialogue Message Window; Play Sound Effect (SE) (5); Display Dialogue Box [Bank: 4, MsgID: 5]; Engine Action #5; Show Dialogue Portrait (3, 0, 5); Engine Action #5; Open Dialogue Message Window; Reset Camera Tracking (5); Show Dialogue Portrait (30, 1, 12); Set Combat Battle BGM (120); Launch Tactical War Battle (1); Engine Action #5; Engine Action #9; Warp Town -> Area 0 Map 5 Submap 5 at (1,0); Engine Action #5; Show Dialogue Portrait (30, 24, 9); Open Dialogue Message Window; Engine Action #66; Set Combat Battle BGM (60); Set Entity Movement Speed (2, 5); Open Dialogue Message Window; Exit to World Map (3, 5, 20); Warp to Castle HQ (5, 0, 2); Dismiss Emotion Bubble (255); Engine Action #5; Reset Camera Tracking (4); Warp to Castle HQ (2, 4, 0); Warp Town -> Area 30 Map 255 Submap 254 at (50,73); Show Dialogue Portrait (24, 8, 0); Open Shop Interface #73; Show Dialogue Portrait (24, 9, 0); Play CD / Ambient BGM Track (5); Engine Action #9; Exit to World Map (3, 5, 15); Pan Camera (2, 3, 0); Engine Action #5; Engine Action #5; Open Dialogue Message Window; Warp Town -> Area 5 Map 15 Submap 3 at (0,5); Show Dialogue Portrait (30, 46, 2); Screen Fade Transition (41, 32, 89); Screen Fade Transition (2, 3, 0); Screen Fade Transition (1, 9, 47); Engine Action #90; Screen Fade Transition (4, 3, 19); Display Dialogue Box [Bank: 30, MsgID: 89]; Screen Fade Transition (2, 2, 5); Reset Camera Tracking (4); Exit to World Map (0, 1, 5); Screen Fade Transition (30, 24, 8); Open Dialogue Message Window; Wait for Audio / Window Sync (89); Screen Fade Transition (2, 5, 89); Screen Fade Transition (5, 89, 10); Engine Action #5; Make obj[89] Hidden (disp = 0); Screen Fade Transition (2, 6, 1); Close Dialogue Window; Teleport obj[89] to (10,5); Engine Action #89; Screen Fade Transition (5, 89, 10); Warp Town -> Area 7 Map 89 Submap 10 at (5,89); Screen Fade Transition (5, 89, 10); Warp Town -> Area 8 Map 89 Submap 10 at (5,89); Screen Fade Transition (5, 2, 9); Engine Action #53; Warp Map Transition (24, 9, 0, 70, 73); Show Dialogue Portrait (89, 10, 2); Engine Action #9; Engine Action #90; Screen Fade Transition (18, 10, 30); Engine Action #89; Screen Fade Transition (2, 8, 73); Show Dialogue Portrait (2, 9, 43); Warp Map Transition (89, 10, 2, 10, 24); Engine Action #9; Open Dialogue Message Window; Remove Character from Active Party (73); Dismiss Emotion Bubble (24); Reset Camera Tracking (0); Load Sound Bank into Memory (73, 15); Engine Action #89; Screen Fade Transition (2, 12, 89); Screen Fade Transition (5, 89, 10); Engine Action #5; Launch Tactical War Battle (2); Engine Action #89; Screen Fade Transition (2, 9, 90); Screen Fade Transition (18, 5, 30); Engine Action #54; Open Dialogue Message Window; Warp Town -> Area 73 Map 30 Submap 1 at (10,0); Engine Action #9; Warp Town -> Area 9 Map 31 Submap 28 at (3,9); Open Dialogue Message Window; Warp Town -> Area 8 Map 32 Submap 33 at (3,8); Warp Room -> Submap 0 at (7,4) facing South (Down); Dismiss Emotion Bubble (33); Reset Camera Tracking (3); Open Dialogue Message Window; Warp Room -> Submap 76 at (2,8) facing South (Down); Warp to Castle HQ (7, 0, 15); Open Dialogue Message Window; Place Scenery Structure (0); Animate Door Open; Jump to Bytecode Offset (1, 0); Close Dialogue Window; Warp Room -> Submap 90 at (73,160) facing 24; Engine Action #9; Open Dialogue Message Window; Set Combat Battle BGM (73); Show Dialogue Portrait (24, 8, 0); Set Special Scene BGM (73); Show Dialogue Portrait (73, 20, 40); Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 0 Map 75 Submap 0 at (76,41); Warp Town -> Area 0 Map 1 Submap 255 at (0,24); Engine Action #9; Open Dialogue Message Window; Award Potch Currency (51,2); Warp Room -> Submap 9 at (0,78) facing 255; Warp Town -> Area 73 Map 100 Submap 24 at (8,0); Bytecode Subroutine Return; Set Combat Battle BGM (30); Close Dialogue Sub-Window (9); Open Dialogue Message Window; Engine Action #80; Set Combat Battle BGM (20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 0 Map 81 Submap 0 at (82,41); Warp Town -> Area 3 Map 4 Submap 255 at (3,24); Engine Action #9; Open Dialogue Message Window; Engine Action #83; Engine Action #51; Engine Action #5; Exit to World Map (24, 8, 0); Dismiss Character to Castle Base (24 [Milie]); Engine Action #9; Open Dialogue Message Window; Engine Action #85; Engine Action #5; Close Dialogue Sub-Window (9); Open Dialogue Message Window; Animate Door obj[73] (State: 100); Jump to Bytecode Offset (9, 8); Close Dialogue Sub-Window (9); Open Dialogue Message Window; Engine Action #87; Set Combat Battle BGM (20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 0 Map 88 Submap 0 at (89,101); Pan Camera (0, 24, 9); Open Dialogue Message Window; Engine Action #90; Close Dialogue Sub-Window (8); Open Dialogue Message Window; Make Object Visible (disp = 1) (73); Dismiss Emotion Bubble (105); Open Dialogue Message Window; Warp Room -> Submap 11 at (2,2) facing 150; Engine Action #9; Open Dialogue Message Window; Engine Action #128; Wait for Audio / Window Sync (1); Warp Room -> Submap 1 at (2,29); Warp to Castle HQ (0, 0, 101); Warp Room -> Submap 102 at (1,32) facing Up (North); Warp Room -> Submap 61 at (58,255) facing 254 |
| `ev[06]` | `128 (Loop)` | Story Flag 10 (bit 16) SET AND Story Flag 10 (bit 32) CLEAR AND Story Flag 0 (bit 64) SET AND Story Flag 0 (bit 128) CLEAR AND Inventory Holds Item #1 [Medicine] | Display Chapter Text (1); Reset Camera Tracking (3); Toggle Random Encounters (1) |
| `ev[07]` | `128 (Loop)` | Story Flag 10 (bit 16) SET AND Story Flag 10 (bit 32) CLEAR AND Story Flag 0 (bit 64) SET AND Story Flag 0 (bit 128) CLEAR AND Inventory Holds Item #2 [Mega Medicine] | Close Dialogue Window; Warp Town -> Area 2 Map 100 Submap 37 at (2,255) |

---



## Location Map: `vc12`

- **Master Map Container**: `vc12.json`
- **Submap Layer Files**: vc12_00.json
- **Collision Grid Files**: vc12_map_00.json, vc12_map_09.json
- **Sprite Animation Bundles**: vc12_00_obj.json
- **Submap Room Count**: 11

### Submap Layer `vc12_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `3` Objects | **Script Count (`evkaz`)**: `6` Scripts

#### Complete Physical Entity Inventory (3 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 5)** | `0` | `(0, 0)` | `0x0` | Frame 5 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 6)** | `0` | `(0, 0)` | `0x0` | Frame 6 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | Trigger / Hitbox | **Hitbox Zone (3x4)** | `0` | `(43, 30)` | `2x3` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(0, 0)` with state parameter `5`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(0, 0)` with state parameter `6`.
- **`obj[02]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `4` tiles high from `(43, 30)` to `(45, 33)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (6 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Always Passes (Unconditional) | Make obj[2] Hidden (disp = 0); Reset Camera Tracking (34); Display Emotion Bubble (0, 8); Warp Town -> Area 9 Map 38 Submap 29 at (0,9); Warp Town -> Area 10 Map 43 Submap 29 at (0,10); Teleport obj[255] to (254,255) |
| `ev[01]` | `2 (Map Init)` | Always Passes (Unconditional) | Animate Door obj[2] (State: 11); Open Dialogue Message Window; Open Save Crystal Menu (MSaveInit); Open Shop Interface #255 |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [34..42, 2..27] AND Treasure Byte 9 Bit 1 FRESH (Unopened) | Display Dialogue Box [Bank: 1, MsgID: 72]; Engine Action #134 |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [36..40, 2..71] AND Condition Check #72 AND Story Flag 0 (mask 255) SET | Warp Room -> Submap 0 at (2,3); Set Special Scene BGM (1); Warp Map Transition (3, 3, 36, 15, 255) |
| `ev[04]` | `1 (Action / Talk)` | Story Flag 6 (bit 32) CLEAR AND Target Inspected is obj[10] | Recruit Character into Active Party (43 [Ayda], 0); Exit to World Map (55, 0, 41); Return to Previous Memory Map (8); Warp to Castle HQ (0, 3, 33); Warp Room -> Submap 0 at (1,5) facing West (Left); Exit to World Map (4, 3, 3); Warp Room -> Submap 5 at (30,30) facing 24; Warp Room -> Submap 24 at (73,15) facing 101; Open Dialogue Message Window; Engine Action #176; Set Combat Battle BGM (60); Jump to Bytecode Offset (0, 177); Set Entity Movement Speed (3, 5); Open Dialogue Message Window; Engine Action #5; Dismiss Emotion Bubble (1); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #90; Reset Camera Tracking (4); Warp Town -> Area 18 Map 3 Submap 30 at (255,254); Engine Action #90; Engine Action #9; Exit to World Map (2, 19, 3); Dismiss Emotion Bubble (255); Walk obj[101] to (5,177); Jump to Bytecode Offset (0, 178); Engine Action #5; Warp Room -> Submap 4 at (5,30) facing Up (North); Warp to Castle HQ (5, 30, 30); Return Warp to Castle Base (58, 36); Warp Room -> Submap 6 at (32,255) facing 254 |
| `ev[05]` | `1 (Action / Talk)` | Temp Event Flag #1 SET AND Target Inspected is obj[10] | Recruit Character into Active Party (101 [Teresa], 0); Engine Action #176; Set Combat Battle BGM (15); Jump to Bytecode Offset (0, 177); Set Entity Movement Speed (2, 90); Reset Camera Tracking (4); Warp Town -> Area 18 Map 3 Submap 30 at (255,254); Engine Action #90; Engine Action #9; Exit to World Map (2, 19, 3); Dismiss Emotion Bubble (255); Walk obj[101] to (5,177); Jump to Bytecode Offset (0, 178); Launch Tactical War Battle (1); Engine Action #58 |

---

### Submap Layer `vc12_01` (Index 1)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `90`, Rate: `4`)
- **Entity Count (`okaz`)**: `4` Objects | **Script Count (`evkaz`)**: `8` Scripts

#### Complete Physical Entity Inventory (4 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 23)** | `0` | `(32, 30)` | `0x0` | Frame 23 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 23)** | `0` | `(37, 30)` | `0x0` | Frame 23 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | World Device | **Mechanism (ano 24)** | `0` | `(32, 30)` | `0x0` | Frame 24 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | World Device | **Mechanism (ano 24)** | `0` | `(37, 30)` | `0x0` | Frame 24 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(32, 30)` with state parameter `23`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(37, 30)` with state parameter `23`.
- **`obj[02]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(32, 30)` with state parameter `24`.
- **`obj[03]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(37, 30)` with state parameter `24`.


#### Complete Bytecode Script Catalog (8 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Treasure Byte 0 Bit 1 FRESH (Unopened) | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[01]` | `2 (Map Init)` | Treasure Byte 0 Bit 2 FRESH (Unopened) | Open Dialogue Message Window; Engine Action #9 |
| `ev[02]` | `2 (Map Init)` | Treasure Byte 0 Bit 1 LOOTED | Open Dialogue Message Window; Screen Fade Transition (255, 254, 255) |
| `ev[03]` | `2 (Map Init)` | Treasure Byte 0 Bit 2 LOOTED | Open Dialogue Message Window; Close Dialogue Window |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [69..75, 2..138] AND Condition Check #139 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 38]; Warp Map Transition (255, 254, 204, 204, 204) |
| `ev[05]` | `1 (Action / Talk)` | Player within Box [114..127, 2..5] AND Inventory Holds Item #9 [Kindness Drops] AND Player X within Range [255..254] | Display Dialogue Box [Bank: 2, MsgID: 28]; Engine Action #159 |
| `ev[06]` | `1 (Action / Talk)` | Treasure Byte 0 Bit 1 FRESH (Unopened) AND Target Inspected is obj[8] | Recruit Character into Active Party (46 [Oulan], 0); Screen Fade Transition (1, 8, 47); Jump to Bytecode Offset (4, 7); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (0); Exit to World Map (0, 2, 0); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,0) facing West (Left); Engine Action #51; Warp Town -> Area 255 Map 1 Submap 46 at (0,8); Warp Room -> Submap 47 at (255,2) facing 58 |
| `ev[07]` | `1 (Action / Talk)` | Treasure Byte 0 Bit 2 FRESH (Unopened) AND Target Inspected is obj[9] | Recruit Character into Active Party (46 [Oulan], 0); Close Dialogue Window; Warp Room -> Submap 47 at (101,4) facing 7; Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (0); Exit to World Map (0, 22, 0); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,0) facing Up (North); Engine Action #51; Warp Town -> Area 255 Map 1 Submap 46 at (0,9); Warp Room -> Submap 47 at (255,2) facing 58 |

---

### Submap Layer `vc12_02` (Index 2)

- **Map Number (`mapno`)**: `2`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `90`, Rate: `4`)
- **Entity Count (`okaz`)**: `6` Objects | **Script Count (`evkaz`)**: `16` Scripts

#### Complete Physical Entity Inventory (6 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 23)** | `0` | `(47, 139)` | `0x0` | Frame 23 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 24)** | `0` | `(47, 139)` | `0x0` | Frame 24 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | World Device | **Mechanism (ano 23)** | `0` | `(101, 36)` | `0x0` | Frame 23 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | World Device | **Mechanism (ano 24)** | `0` | `(101, 36)` | `0x0` | Frame 24 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[04]` | World Device | **Mechanism (ano 23)** | `0` | `(46, 33)` | `0x0` | Frame 23 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[05]` | World Device | **Mechanism (ano 24)** | `0` | `(46, 33)` | `0x0` | Frame 24 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(47, 139)` with state parameter `23`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(47, 139)` with state parameter `24`.
- **`obj[02]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(101, 36)` with state parameter `23`.
- **`obj[03]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(101, 36)` with state parameter `24`.
- **`obj[04]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(46, 33)` with state parameter `23`.
- **`obj[05]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(46, 33)` with state parameter `24`.


#### Complete Bytecode Script Catalog (16 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Treasure Byte 0 Bit 4 FRESH (Unopened) | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[01]` | `2 (Map Init)` | Treasure Byte 0 Bit 4 LOOTED | Open Dialogue Message Window; Engine Action #9 |
| `ev[02]` | `2 (Map Init)` | Treasure Byte 0 Bit 8 FRESH (Unopened) | Open Dialogue Message Window; Screen Fade Transition (255, 254, 255) |
| `ev[03]` | `2 (Map Init)` | Treasure Byte 0 Bit 8 LOOTED | Open Dialogue Message Window; Close Dialogue Window |
| `ev[04]` | `2 (Map Init)` | Treasure Byte 0 Bit 16 FRESH (Unopened) | Open Dialogue Message Window; Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[05]` | `2 (Map Init)` | Treasure Byte 0 Bit 16 LOOTED | Open Dialogue Message Window; Place Scenery Structure (255) |
| `ev[06]` | `1 (Action / Talk)` | Player within Box [21..35, 2..161] AND Condition Check #162 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 120]; Reset Camera Tracking (255) |
| `ev[07]` | `1 (Action / Talk)` | Player within Box [65..67, 2..5] AND Inventory Holds Item #9 [Kindness Drops] AND Player X within Range [255..254] | Display Dialogue Box [Bank: 3, MsgID: 50]; Remove Character from Active Party (255) |
| `ev[08]` | `1 (Action / Talk)` | Player within Box [54..62, 2..5] AND Inventory Holds Item #9 [Kindness Drops] AND Player X within Range [255..254] | Display Dialogue Box [Bank: 3, MsgID: 42]; Remove Character from Active Party (255) |
| `ev[09]` | `1 (Action / Talk)` | Treasure Byte 0 Bit 4 FRESH (Unopened) AND Target Inspected is obj[8] | Recruit Character into Active Party (46 [Oulan], 0); Engine Action #9; Warp Room -> Submap 47 at (101,4) facing 7; Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (0); Exit to World Map (0, 18, 0); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,0) facing 4; Engine Action #51; Warp Town -> Area 255 Map 1 Submap 46 at (0,8); Warp Room -> Submap 47 at (255,2) facing 58 |
| `ev[10]` | `1 (Action / Talk)` | Treasure Byte 0 Bit 8 FRESH (Unopened) AND Target Inspected is obj[10] | Recruit Character into Active Party (46 [Oulan], 0); Close Dialogue Window; Warp Room -> Submap 47 at (101,4) facing 7; Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (0); Exit to World Map (0, 51, 16); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,0) facing 8; Engine Action #51; Warp Town -> Area 255 Map 1 Submap 46 at (0,10); Warp Room -> Submap 47 at (255,2) facing 58 |
| `ev[11]` | `1 (Action / Talk)` | Treasure Byte 0 Bit 16 FRESH (Unopened) AND Target Inspected is obj[12] | Recruit Character into Active Party (46 [Oulan], 0); Place Scenery Structure (1); Display Dialogue Box [Bank: 47, MsgID: 101]; Exit to World Map (7, 101, 4); Pan Camera (30, 0, 4); Open Dialogue Message Window; Warp to Castle HQ (32, 0, 41); Warp Town -> Area 0 Map 1 Submap 255 at (0,97); Open Dialogue Message Window; Dismiss Dialogue Portrait; Engine Action #51; Warp Town -> Area 255 Map 1 Submap 46 at (0,12); Warp Room -> Submap 47 at (255,2) facing 58 |
| `ev[12]` | `128 (Loop)` | Player within Box [32..33, 2..79] AND Condition Check #82 AND Story Flag 3 (mask 255) SET | Open Choice Selection Menu (1, 255) |
| `ev[13]` | `128 (Loop)` | Player within Box [91..92, 2..79] AND Condition Check #82 AND Story Flag 2 (mask 255) SET | Open Choice Selection Menu (1, 255) |
| `ev[14]` | `128 (Loop)` | Player within Box [30..31, 2..79] AND Condition Check #82 AND Story Flag 2 (mask 255) SET | Open Choice Selection Menu (0, 255) |
| `ev[15]` | `128 (Loop)` | Player within Box [93..94, 2..79] AND Condition Check #82 AND Story Flag 3 (mask 255) SET | Open Choice Selection Menu (0, 255) |

---

### Submap Layer `vc12_03` (Index 3)

- **Map Number (`mapno`)**: `3`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `90`, Rate: `4`)
- **Entity Count (`okaz`)**: `4` Objects | **Script Count (`evkaz`)**: `15` Scripts

#### Complete Physical Entity Inventory (4 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 69)** | `0` | `(68, 36)` | `0x0` | Frame 69 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 5)** | `0` | `(72, 35)` | `0x0` | Frame 5 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | World Device | **Mechanism (ano 6)** | `0` | `(76, 35)` | `0x0` | Frame 6 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | Trigger / Hitbox | **Hitbox Zone (3x6)** | `0` | `(69, 31)` | `2x5` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(68, 36)` with state parameter `69`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(72, 35)` with state parameter `5`.
- **`obj[02]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(76, 35)` with state parameter `6`.
- **`obj[03]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `6` tiles high from `(69, 31)` to `(71, 36)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (15 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 7 (bit 1) CLEAR | Make obj[0] Hidden (disp = 0); Engine Action #9; Open Dialogue Message Window; Screen Fade Transition (0, 11, 47) |
| `ev[01]` | `2 (Map Init)` | Story Flag 7 (bit 1) SET | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [47..56, 2..73] AND Condition Check #74 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 66]; Reset Camera Tracking (255) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [33..47, 2..73] AND Condition Check #74 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 59]; Reset Camera Tracking (255) |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [0..1, 2..37] AND Condition Check #44 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 4, MsgID: 101]; Set Special Scene BGM (255) |
| `ev[05]` | `1 (Action / Talk)` | Player within Box [0..1, 2..50] AND Condition Check #55 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 4, MsgID: 101]; Engine Action #83 |
| `ev[06]` | `1 (Action / Talk)` | Player within Box [70..82, 2..5] AND Inventory Holds Item #9 [Kindness Drops] AND Player X within Range [255..254] | Display Dialogue Box [Bank: 6, MsgID: 108]; Engine Action #195 |
| `ev[07]` | `1 (Action / Talk)` | Player within Box [33..53, 2..5] AND Inventory Holds Item #9 [Kindness Drops] AND Player X within Range [255..254] | Display Dialogue Box [Bank: 6, MsgID: 74]; Engine Action #195 |
| `ev[08]` | `1 (Action / Talk)` | Story Flag 6 (bit 64) CLEAR AND Target Inspected is obj[11] | Recruit Character into Active Party (43 [Ayda], 0); Exit to World Map (55, 0, 70); Engine Action #40; Reset Camera Tracking (3); Open Dialogue Message Window; Warp Room -> Submap 1 at (95,0) facing West (Left); Engine Action #5; Warp Room -> Submap 4 at (1,3) facing 5; Show Dialogue Portrait (30, 24, 1); Warp Room -> Submap 73 at (90,72) facing West (Left); Warp Room -> Submap 73 at (30,72) facing South (Down); Warp Room -> Submap 1 at (4,2) facing 7; Warp Room -> Submap 15 at (30,72) facing West (Left); Warp Room -> Submap 73 at (60,72) facing South (Down); Warp Room -> Submap 1 at (4,4) facing West (Left); Warp Room -> Submap 20 at (30,72) facing West (Left); Warp Room -> Submap 73 at (60,72) facing South (Down); Warp Room -> Submap 1 at (4,2) facing 7; Warp Room -> Submap 15 at (30,72) facing West (Left); Warp Room -> Submap 73 at (60,72) facing South (Down); Warp Room -> Submap 1 at (5,30) facing Up (North); Open Dialogue Message Window; Engine Action #5; Exit to World Map (0, 0, 5); Screen Fade Transition (30, 24, 1); Warp Room -> Submap 73 at (15,5) facing West (Left); Exit to World Map (4, 0, 2); Dismiss Emotion Bubble (1); Warp Room -> Submap 9 at (6,64) facing 36; Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[09]` | `1 (Action / Talk)` | Story Flag 6 (bit 64) SET AND Story Flag 6 (bit 128) CLEAR AND Temp Event Flag #1 SET AND Target Inspected is obj[11] | Recruit Character into Active Party (43 [Ayda], 0); Exit to World Map (55, 0, 70); Engine Action #40; Reset Camera Tracking (3); Open Dialogue Message Window; Warp Room -> Submap 1 at (95,0) facing West (Left); Engine Action #5; Warp Room -> Submap 4 at (1,3) facing 5; Trigger Character Emotion Effect (2, 0); Engine Action #5; Exit to World Map (0, 0, 30); Close Dialogue Sub-Window (1); Warp Room -> Submap 73 at (15,5) facing West (Left); Exit to World Map (5, 0, 3); Dismiss Emotion Bubble (1); Warp Room -> Submap 58 at (36,1) facing 255 |
| `ev[10]` | `1 (Action / Talk)` | Story Flag 6 (bit 128) SET AND Story Flag 7 (bit 1) CLEAR AND Temp Event Flag #1 SET AND Target Inspected is obj[11] | Recruit Character into Active Party (101 [Teresa], 0); Engine Action #176; Open Dialogue Message Window; Reset Camera Tracking (73); Show Dialogue Portrait (101, 0, 177); Set Entity Movement Speed (2, 90); Engine Action #9; Exit to World Map (2, 18, 3); Dismiss Emotion Bubble (255); Engine Action #90; Screen Fade Transition (4, 2, 19); Warp to Castle HQ (30, 255, 254); Walk obj[101] to (5,177); Jump to Bytecode Offset (0, 178); Dismiss Emotion Bubble (1); Warp Town -> Area 1 Map 51 Submap 46 at (9,7); Warp Room -> Submap 1 at (47,58) facing 255 |
| `ev[11]` | `128 (Loop)` | Player within Box [24..25, 2..39] AND Condition Check #42 AND Story Flag 3 (mask 255) SET | Open Choice Selection Menu (1, 255) |
| `ev[12]` | `128 (Loop)` | Player within Box [59..60, 2..39] AND Condition Check #42 AND Story Flag 2 (mask 255) SET | Open Choice Selection Menu (1, 255) |
| `ev[13]` | `128 (Loop)` | Player within Box [22..23, 2..39] AND Condition Check #42 AND Story Flag 2 (mask 255) SET | Open Choice Selection Menu (0, 255) |
| `ev[14]` | `128 (Loop)` | Player within Box [61..62, 2..39] AND Condition Check #42 AND Story Flag 3 (mask 255) SET | Open Choice Selection Menu (0, 255) |

---

### Submap Layer `vc12_04` (Index 4)

- **Map Number (`mapno`)**: `4`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `16` Objects | **Script Count (`evkaz`)**: `9` Scripts

#### Complete Physical Entity Inventory (16 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 5)** | `0` | `(56, 31)` | `0x0` | Frame 5 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 6)** | `0` | `(60, 31)` | `0x0` | Frame 6 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | Save Point | **Journeyman Save Orb** | `0` | `(68, 36)` | `0x0` | Frame 14 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 1 | 0 |
| `obj[03]` | Save Point | **Journeyman Save Orb** | `0` | `(68, 44)` | `0x0` | Frame 14 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 1 | 0 |
| `obj[04]` | Save Point | **Journeyman Save Orb** | `0` | `(68, 52)` | `0x0` | Frame 14 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 1 | 0 |
| `obj[05]` | Save Point | **Journeyman Save Orb** | `0` | `(48, 36)` | `0x0` | Frame 14 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 1 | 0 |
| `obj[06]` | Save Point | **Journeyman Save Orb** | `0` | `(48, 44)` | `0x0` | Frame 14 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 1 | 0 |
| `obj[07]` | Save Point | **Journeyman Save Orb** | `0` | `(48, 52)` | `0x0` | Frame 14 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 1 | 0 |
| `obj[08]` | Save Point | **Journeyman Save Orb** | `0` | `(68, 36)` | `0x0` | Frame 14 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[09]` | Save Point | **Journeyman Save Orb** | `0` | `(68, 44)` | `0x0` | Frame 14 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[10]` | Save Point | **Journeyman Save Orb** | `0` | `(68, 52)` | `0x0` | Frame 14 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[11]` | Save Point | **Journeyman Save Orb** | `0` | `(48, 36)` | `0x0` | Frame 14 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[12]` | Save Point | **Journeyman Save Orb** | `0` | `(48, 44)` | `0x0` | Frame 14 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[13]` | Save Point | **Journeyman Save Orb** | `0` | `(48, 52)` | `0x0` | Frame 14 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[14]` | World Device | **Mechanism (ano 11)** | `0` | `(45, 60)` | `0x0` | Frame 11 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[15]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(45, 63)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(56, 31)` with state parameter `5`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(60, 31)` with state parameter `6`.
- **`obj[02]` (Journeyman Save Crystal)**: Floating save station orb at tile `(68, 36)`, priority `0`. Triggers `MSaveInit` save system dialog.
- **`obj[03]` (Journeyman Save Crystal)**: Floating save station orb at tile `(68, 44)`, priority `0`. Triggers `MSaveInit` save system dialog.
- **`obj[04]` (Journeyman Save Crystal)**: Floating save station orb at tile `(68, 52)`, priority `0`. Triggers `MSaveInit` save system dialog.
- **`obj[05]` (Journeyman Save Crystal)**: Floating save station orb at tile `(48, 36)`, priority `0`. Triggers `MSaveInit` save system dialog.
- **`obj[06]` (Journeyman Save Crystal)**: Floating save station orb at tile `(48, 44)`, priority `0`. Triggers `MSaveInit` save system dialog.
- **`obj[07]` (Journeyman Save Crystal)**: Floating save station orb at tile `(48, 52)`, priority `0`. Triggers `MSaveInit` save system dialog.
- **`obj[08]` (Journeyman Save Crystal)**: Floating save station orb at tile `(68, 36)`, priority `0`. Triggers `MSaveInit` save system dialog.
- **`obj[09]` (Journeyman Save Crystal)**: Floating save station orb at tile `(68, 44)`, priority `0`. Triggers `MSaveInit` save system dialog.
- **`obj[10]` (Journeyman Save Crystal)**: Floating save station orb at tile `(68, 52)`, priority `0`. Triggers `MSaveInit` save system dialog.
- **`obj[11]` (Journeyman Save Crystal)**: Floating save station orb at tile `(48, 36)`, priority `0`. Triggers `MSaveInit` save system dialog.
- **`obj[12]` (Journeyman Save Crystal)**: Floating save station orb at tile `(48, 44)`, priority `0`. Triggers `MSaveInit` save system dialog.
- **`obj[13]` (Journeyman Save Crystal)**: Floating save station orb at tile `(48, 52)`, priority `0`. Triggers `MSaveInit` save system dialog.
- **`obj[14]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(45, 60)` with state parameter `11`.
- **`obj[15]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(45, 63)` to `(47, 65)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (9 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Always Passes (Unconditional) | Dismiss Emotion Bubble (2); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[01]` | `2 (Map Init)` | Always Passes (Unconditional) | Make obj[0] Hidden (disp = 0); Reset Camera Tracking (0); Engine Action #9; Warp Town -> Area 10 Map 66 Submap 36 at (0,10); Open Dialogue Message Window; Change Portrait Expression (0); Display Speaker Name Box (0); Display Choice Selection (0, 20); Open Dialogue Message Window; Execute Choice Result (47) |
| `ev[02]` | `2 (Map Init)` | Story Flag 7 (bit 16) CLEAR | Make obj[0] Hidden (disp = 0); Open Dialogue Sub-Window (0); Set Story Flag (47, 255) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [102..103, 2..68] AND Condition Check #79 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 3, MsgID: 2]; Remove Item from Inventory (255, 254) |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [102..103, 2..82] AND Condition Check #87 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 3, MsgID: 2]; Engine Action #51 |
| `ev[05]` | `1 (Action / Talk)` | Player within Box [56..64, 2..30] AND Condition Check #31 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 5, MsgID: 38]; Load Sound Bank into Memory (255, 254) |
| `ev[06]` | `1 (Action / Talk)` | Temp Event Flag #1 SET AND Active Party Has Character #10 AND Condition Check #68 AND Condition Check #68 AND Party Formation Check AND Story Flag 36 (mask 36) CLEAR | Recruit Character into Active Party (9 [Futch], 2); Engine Action #128; Engine Action #53; Open Dialogue Message Window; Warp Town -> Area 128 Map 36 Submap 1 at (9,60); Warp Town -> Area 58 Map 255 Submap 254 at (255,254) |
| `ev[07]` | `128 (Loop)` | Story Flag 2 (bit 128) SET | Jump to Bytecode Offset (0, 176); Set Combat Battle BGM (15); Jump to Bytecode Offset (0, 177); Set Entity Movement Speed (2, 90); Reset Camera Tracking (4); Warp Town -> Area 18 Map 3 Submap 30 at (255,254); Engine Action #90; Engine Action #9; Exit to World Map (2, 19, 3); Dismiss Emotion Bubble (255); Walk obj[101] to (5,177); Jump to Bytecode Offset (0, 178); Screen Fade Transition (2, 128, 255) |
| `ev[08]` | `1 (Action / Talk)` | Story Flag 7 (bit 8) SET AND Story Flag 7 (bit 16) CLEAR AND Target Inspected is obj[23] | Recruit Character into Active Party (43 [Ayda], 0); Exit to World Map (55, 0, 46); Wait for Audio / Window Sync (8); Warp to Castle HQ (0, 1, 33); Warp Room -> Submap 0 at (1,5) facing West (Left); Exit to World Map (5, 1, 3); Engine Action #5; Show Dialogue Portrait (30, 24, 1); Warp Room -> Submap 5 at (1,5) facing 15; Warp Room -> Submap 30 at (1,22) facing 5; Warp Room -> Submap 1 at (5,15) facing East (Right); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Open Dialogue Message Window; Warp to Castle HQ (30, 1, 1); Return Warp to Castle Base (101, 4); Engine Action #6; Dismiss Emotion Bubble (1); Warp Town -> Area 0 Map 53 Submap 9 at (7,16); Engine Action #58 |

---

### Submap Layer `vc12_05` (Index 5)

- **Map Number (`mapno`)**: `5`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `90`, Rate: `4`)
- **Entity Count (`okaz`)**: `4` Objects | **Script Count (`evkaz`)**: `7` Scripts

#### Complete Physical Entity Inventory (4 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 23)** | `0` | `(43, 32)` | `0x0` | Frame 23 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 24)** | `0` | `(43, 32)` | `0x0` | Frame 24 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | World Device | **Mechanism (ano 9)** | `0` | `(37, 19)` | `0x0` | Frame 9 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(37, 22)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(43, 32)` with state parameter `23`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(43, 32)` with state parameter `24`.
- **`obj[02]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(37, 19)` with state parameter `9`.
- **`obj[03]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(37, 22)` to `(39, 24)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (7 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Treasure Byte 0 Bit 32 FRESH (Unopened) | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[01]` | `2 (Map Init)` | Treasure Byte 0 Bit 32 LOOTED | Open Dialogue Message Window; Engine Action #9 |
| `ev[02]` | `2 (Map Init)` | Story Flag 6 (bit 128) CLEAR | Make obj[0] Hidden (disp = 0); Close Dialogue Window; Open Dialogue Message Window; Screen Fade Transition (47, 255, 254) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [32..44, 2..76] AND Condition Check #77 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 4, MsgID: 60]; Return Warp to Castle Base (255, 254) |
| `ev[04]` | `1 (Action / Talk)` | Story Flag 6 (bit 64) SET AND Story Flag 6 (bit 128) CLEAR AND Target Inspected is obj[11] | Recruit Character into Active Party (43 [Ayda], 0); Exit to World Map (55, 0, 38); Display Chapter Text (8); Warp to Castle HQ (0, 1, 33); Warp Room -> Submap 0 at (1,5) facing West (Left); Exit to World Map (5, 1, 3); Engine Action #5; Show Dialogue Portrait (30, 24, 1); Warp Room -> Submap 5 at (1,5) facing 15; Warp Room -> Submap 30 at (1,10) facing 5; Warp Room -> Submap 1 at (5,15) facing East (Right); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Open Dialogue Message Window; Warp to Castle HQ (30, 1, 1); Return Warp to Castle Base (101, 4); Engine Action #6; Dismiss Emotion Bubble (1); Warp Town -> Area 0 Map 51 Submap 9 at (6,128); Engine Action #58 |
| `ev[05]` | `1 (Action / Talk)` | Story Flag 6 (bit 64) CLEAR AND Story Flag 6 (bit 128) CLEAR AND Target Inspected is obj[11] | Recruit Character into Active Party (43 [Ayda], 0); Exit to World Map (55, 0, 38); Display Chapter Text (8); Warp to Castle HQ (0, 1, 33); Warp Room -> Submap 0 at (1,5) facing West (Left); Exit to World Map (5, 1, 3); Engine Action #5; Show Dialogue Portrait (30, 24, 1); Warp Room -> Submap 5 at (1,5) facing 15; Warp Room -> Submap 30 at (1,10) facing 5; Warp Room -> Submap 1 at (5,15) facing East (Right); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Open Dialogue Message Window; Warp to Castle HQ (30, 1, 1); Return Warp to Castle Base (101, 4); Engine Action #6; Dismiss Emotion Bubble (1); Warp Town -> Area 0 Map 51 Submap 9 at (6,64); Engine Action #9; Engine Action #6; Engine Action #128; Engine Action #58 |
| `ev[06]` | `1 (Action / Talk)` | Treasure Byte 0 Bit 32 FRESH (Unopened) AND Target Inspected is obj[8] | Recruit Character into Active Party (46 [Oulan], 0); Engine Action #9; Warp Room -> Submap 47 at (101,4) facing 7; Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (0); Exit to World Map (0, 66, 16); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,0) facing 32; Engine Action #51; Warp Town -> Area 255 Map 1 Submap 46 at (0,8); Warp Room -> Submap 47 at (255,2) facing 58 |

---

### Submap Layer `vc12_06` (Index 6)

- **Map Number (`mapno`)**: `6`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `90`, Rate: `4`)
- **Entity Count (`okaz`)**: `11` Objects | **Script Count (`evkaz`)**: `26` Scripts

#### Complete Physical Entity Inventory (11 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 23)** | `0` | `(114, 26)` | `0x0` | Frame 23 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 24)** | `0` | `(114, 26)` | `0x0` | Frame 24 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | World Device | **Mechanism (ano 10)** | `0` | `(39, 127)` | `0x0` | Frame 10 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | World Device | **Mechanism (ano 5)** | `0` | `(0, 0)` | `0x0` | Frame 5 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | World Device | **Mechanism (ano 6)** | `0` | `(0, 0)` | `0x0` | Frame 6 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | World Device | **Mechanism (ano 71)** | `0` | `(24, 36)` | `0x0` | Frame 71 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[06]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(39, 130)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Hitbox Zone (3x6)** | `0` | `(25, 31)` | `2x5` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(40, 49)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(107, 160)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(31, 44)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(114, 26)` with state parameter `23`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(114, 26)` with state parameter `24`.
- **`obj[02]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(39, 127)` with state parameter `10`.
- **`obj[03]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(0, 0)` with state parameter `5`.
- **`obj[04]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(0, 0)` with state parameter `6`.
- **`obj[05]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(24, 36)` with state parameter `71`.
- **`obj[06]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(39, 130)` to `(41, 132)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[07]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `6` tiles high from `(25, 31)` to `(27, 36)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[08]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(40, 49)` to `(42, 51)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[09]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(107, 160)` to `(109, 162)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[10]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(31, 44)` to `(33, 46)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (26 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Treasure Byte 0 Bit 64 FRESH (Unopened) | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[01]` | `2 (Map Init)` | Treasure Byte 0 Bit 64 LOOTED | Open Dialogue Message Window; Engine Action #9 |
| `ev[02]` | `2 (Map Init)` | Story Flag 7 (bit 2) CLEAR | Make obj[0] Hidden (disp = 0); Screen Fade Transition (0, 14, 47) |
| `ev[03]` | `2 (Map Init)` | Always Passes (Unconditional) | Make obj[2] Hidden (disp = 0); Close Dialogue Window; Display Chapter Text (35); Open Dialogue Message Window; Close Dialogue Window; Warp Town -> Area 12 Map 32 Submap 35 at (0,12); Open Dialogue Message Window; Show Dialogue Portrait (47, 255, 254) |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [105..111, 2..197] AND Condition Check #198 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 3, MsgID: 76]; Reset Camera Tracking (255) |
| `ev[05]` | `1 (Action / Talk)` | Player within Box [70..78, 2..197] AND Condition Check #198 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 3, MsgID: 42]; Reset Camera Tracking (255) |
| `ev[06]` | `1 (Action / Talk)` | Player within Box [0..1, 2..157] AND Condition Check #164 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 7, MsgID: 89]; Engine Action #120 |
| `ev[07]` | `1 (Action / Talk)` | Player within Box [150..151, 2..101] AND Condition Check #108 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 8, MsgID: 2]; Engine Action #94 |
| `ev[08]` | `1 (Action / Talk)` | Player within Box [150..151, 2..169] AND Condition Check #176 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 9, MsgID: 2]; Engine Action #132 |
| `ev[09]` | `1 (Action / Talk)` | Player within Box [29..35, 2..34] AND Condition Check #35 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 10, MsgID: 38]; Play CD / Ambient BGM Track (255) |
| `ev[10]` | `1 (Action / Talk)` | Story Flag 7 (bit 1) SET AND Story Flag 7 (bit 2) CLEAR AND Target Inspected is obj[14] | Recruit Character into Active Party (43 [Ayda], 0); Exit to World Map (55, 0, 40); Engine Action #136; Reset Camera Tracking (3); Open Dialogue Message Window; Warp Room -> Submap 1 at (95,0) facing West (Left); Engine Action #5; Warp Room -> Submap 5 at (1,3) facing 5; Show Dialogue Portrait (30, 24, 1); Warp Room -> Submap 5 at (1,5) facing 15; Warp Room -> Submap 30 at (1,10) facing 5; Warp Room -> Submap 1 at (5,15) facing East (Right); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Open Dialogue Message Window; Warp to Castle HQ (30, 1, 1); Return Warp to Castle Base (101, 4); Engine Action #6; Dismiss Emotion Bubble (1); Warp Town -> Area 0 Map 52 Submap 9 at (7,2); Engine Action #58 |
| `ev[11]` | `1 (Action / Talk)` | Story Flag 7 (bit 16) CLEAR AND Temp Event Flag #1 SET AND Target Inspected is obj[15] | Recruit Character into Active Party (43 [Ayda], 0); Exit to World Map (55, 0, 26); Award Potch Loot (+2,051 Potch); Open Dialogue Message Window; Warp Room -> Submap 1 at (95,0) facing West (Left); Engine Action #5; Warp Room -> Submap 4 at (1,3) facing 5; Show Dialogue Portrait (30, 73, 60); Engine Action #5; Warp Room -> Submap 0 at (5,4) facing South (Down); Open Dialogue Message Window; Dismiss Emotion Bubble (24); Warp Room -> Submap 26 at (73,15) facing 5; Warp Room -> Submap 4 at (0,3) facing 30; Warp Room -> Submap 34 at (36,1) facing 58 |
| `ev[12]` | `1 (Action / Talk)` | Story Flag 7 (bit 16) SET AND Temp Event Flag #1 SET AND Target Inspected is obj[15] | Recruit Character into Active Party (0, 13); Set Combat Battle BGM (15); Set Entity Movement Speed (2, 90); Close Dialogue Window; Exit to World Map (2, 18, 3); Dismiss Emotion Bubble (255); Engine Action #90; Display Dialogue Box [Bank: 4, MsgID: 2]; Display Choice Selection (3, 30); Walk obj[73] to (15,1); Place Scenery Structure (36); Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[13]` | `1 (Action / Talk)` | Treasure Byte 0 Bit 64 FRESH (Unopened) AND Target Inspected is obj[8] | Recruit Character into Active Party (46 [Oulan], 0); Engine Action #9; Warp Room -> Submap 47 at (101,4) facing 7; Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (0); Exit to World Map (0, 20, 16); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,0) facing 64; Engine Action #51; Warp Town -> Area 255 Map 1 Submap 46 at (0,8); Warp Room -> Submap 47 at (255,2) facing 58 |
| `ev[14]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Launch Tactical War Battle (2); Fade In from Black (2); Exit to World Map (73, 20, 40); Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 2 Map 2 Submap 2 at (3,73); Branch on Choice (41, 2); Open Dialogue Message Window; Warp Room -> Submap 0 at (54,0) facing Up (North); Recruit Invisible / Hitbox Trigger into Battle Slot 1; Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[15]` | `128 (Loop)` | Inventory Holds Item #2 [Mega Medicine] | Warp Room -> Submap 0 at (13,44); Toggle Random Encounters (2) |
| `ev[16]` | `128 (Loop)` | Player within Box [52..53, 2..159] AND Condition Check #162 AND Story Flag 3 (mask 255) SET | Open Choice Selection Menu (1, 255) |
| `ev[17]` | `128 (Loop)` | Player within Box [95..96, 2..159] AND Condition Check #162 AND Story Flag 2 (mask 255) SET | Open Choice Selection Menu (1, 255) |
| `ev[18]` | `128 (Loop)` | Player within Box [50..51, 2..159] AND Condition Check #162 AND Story Flag 2 (mask 255) SET | Open Choice Selection Menu (0, 255) |
| `ev[19]` | `128 (Loop)` | Player within Box [97..98, 2..159] AND Condition Check #162 AND Story Flag 3 (mask 255) SET | Open Choice Selection Menu (0, 255) |
| `ev[20]` | `128 (Loop)` | Player within Box [52..53, 2..103] AND Condition Check #107 AND Story Flag 3 (mask 255) SET | Open Choice Selection Menu (1, 255) |
| `ev[21]` | `128 (Loop)` | Player within Box [95..96, 2..103] AND Condition Check #107 AND Story Flag 2 (mask 255) SET | Open Choice Selection Menu (1, 255) |
| `ev[22]` | `128 (Loop)` | Player within Box [50..51, 2..103] AND Condition Check #107 AND Story Flag 2 (mask 255) SET | Open Choice Selection Menu (0, 255) |
| `ev[23]` | `128 (Loop)` | Player within Box [97..98, 2..103] AND Condition Check #107 AND Story Flag 3 (mask 255) SET | Open Choice Selection Menu (0, 255) |
| `ev[24]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Open Dialogue Sub-Window (3); Open Dialogue Message Window |
| `ev[25]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Open Dialogue Sub-Window (3); Warp Room -> Submap 254 at (255,254) facing 204 |

---

### Submap Layer `vc12_07` (Index 7)

- **Map Number (`mapno`)**: `7`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `90`, Rate: `4`)
- **Entity Count (`okaz`)**: `4` Objects | **Script Count (`evkaz`)**: `5` Scripts

#### Complete Physical Entity Inventory (4 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 23)** | `0` | `(34, 92)` | `0x0` | Frame 23 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 24)** | `0` | `(34, 92)` | `0x0` | Frame 24 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | World Device | **Mechanism (ano 5)** | `0` | `(0, 0)` | `0x0` | Frame 5 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | World Device | **Mechanism (ano 6)** | `0` | `(0, 0)` | `0x0` | Frame 6 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(34, 92)` with state parameter `23`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(34, 92)` with state parameter `24`.
- **`obj[02]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(0, 0)` with state parameter `5`.
- **`obj[03]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(0, 0)` with state parameter `6`.


#### Complete Bytecode Script Catalog (5 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Treasure Byte 0 Bit 128 FRESH (Unopened) | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[01]` | `2 (Map Init)` | Treasure Byte 0 Bit 128 LOOTED | Open Dialogue Message Window; Engine Action #9 |
| `ev[02]` | `2 (Map Init)` | Always Passes (Unconditional) | Make obj[2] Hidden (disp = 0); Screen Fade Transition (31, 113, 0); Screen Fade Transition (2, 11, 37); Engine Action #113; Open Dialogue Message Window; Close Dialogue Window; Teleport obj[255] to (254,255) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [90..91, 2..115] AND Condition Check #122 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 6, MsgID: 2]; Engine Action #162 |
| `ev[04]` | `1 (Action / Talk)` | Treasure Byte 0 Bit 128 FRESH (Unopened) AND Target Inspected is obj[8] | Recruit Character into Active Party (46 [Oulan], 0); Engine Action #9; Warp Room -> Submap 47 at (101,4) facing 7; Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (0); Exit to World Map (0, 92, 32); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,0) facing 128; Engine Action #51; Warp Town -> Area 255 Map 1 Submap 46 at (0,8); Warp Room -> Submap 47 at (255,2) facing 58 |

---

### Submap Layer `vc12_08` (Index 8)

- **Map Number (`mapno`)**: `8`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `90`, Rate: `4`)
- **Entity Count (`okaz`)**: `50` Objects | **Script Count (`evkaz`)**: `14` Scripts

#### Complete Physical Entity Inventory (50 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 10)** | `0` | `(51, 21)` | `0x0` | Frame 10 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 41)** | `0` | `(40, 40)` | `0x0` | Frame 41 | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | World Device | **Mechanism (ano 41)** | `0` | `(40, 58)` | `0x0` | Frame 41 | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | World Device | **Mechanism (ano 41)** | `0` | `(36, 40)` | `0x0` | Frame 41 | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[04]` | World Device | **Mechanism (ano 41)** | `0` | `(36, 58)` | `0x0` | Frame 41 | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[05]` | World Device | **Mechanism (ano 41)** | `0` | `(32, 40)` | `0x0` | Frame 41 | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[06]` | World Device | **Mechanism (ano 41)** | `0` | `(32, 58)` | `0x0` | Frame 41 | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[07]` | World Device | **Mechanism (ano 41)** | `0` | `(28, 40)` | `0x0` | Frame 41 | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[08]` | World Device | **Mechanism (ano 41)** | `0` | `(28, 58)` | `0x0` | Frame 41 | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[09]` | World Device | **Mechanism (ano 41)** | `0` | `(24, 40)` | `0x0` | Frame 41 | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[10]` | World Device | **Mechanism (ano 41)** | `0` | `(24, 58)` | `0x0` | Frame 41 | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[11]` | World Device | **Mechanism (ano 41)** | `0` | `(20, 40)` | `0x0` | Frame 41 | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[12]` | World Device | **Mechanism (ano 41)** | `0` | `(20, 58)` | `0x0` | Frame 41 | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[13]` | World Device | **Mechanism (ano 43)** | `0` | `(40, 24)` | `0x0` | Frame 43 | Visible (1) | Solid (Obstacle) | 4 | 255 | 180 |
| `obj[14]` | World Device | **Mechanism (ano 43)** | `0` | `(36, 24)` | `0x0` | Frame 43 | Visible (1) | Solid (Obstacle) | 4 | 255 | 180 |
| `obj[15]` | World Device | **Mechanism (ano 43)** | `0` | `(32, 24)` | `0x0` | Frame 43 | Visible (1) | Solid (Obstacle) | 4 | 255 | 180 |
| `obj[16]` | World Device | **Mechanism (ano 43)** | `0` | `(28, 24)` | `0x0` | Frame 43 | Visible (1) | Solid (Obstacle) | 4 | 255 | 180 |
| `obj[17]` | World Device | **Mechanism (ano 43)** | `0` | `(24, 24)` | `0x0` | Frame 43 | Visible (1) | Solid (Obstacle) | 4 | 255 | 180 |
| `obj[18]` | World Device | **Mechanism (ano 43)** | `0` | `(20, 24)` | `0x0` | Frame 43 | Visible (1) | Solid (Obstacle) | 4 | 255 | 180 |
| `obj[19]` | World Device | **Mechanism (ano 42)** | `0` | `(40, 60)` | `0x0` | Frame 42 | Visible (1) | Passable (0) | 4 | 255 | 180 |
| `obj[20]` | World Device | **Mechanism (ano 42)** | `0` | `(36, 60)` | `0x0` | Frame 42 | Visible (1) | Passable (0) | 4 | 255 | 180 |
| `obj[21]` | World Device | **Mechanism (ano 42)** | `0` | `(32, 60)` | `0x0` | Frame 42 | Visible (1) | Passable (0) | 4 | 255 | 180 |
| `obj[22]` | World Device | **Mechanism (ano 42)** | `0` | `(28, 60)` | `0x0` | Frame 42 | Visible (1) | Passable (0) | 4 | 255 | 180 |
| `obj[23]` | World Device | **Mechanism (ano 42)** | `0` | `(24, 60)` | `0x0` | Frame 42 | Visible (1) | Passable (0) | 4 | 255 | 180 |
| `obj[24]` | World Device | **Mechanism (ano 42)** | `0` | `(20, 60)` | `0x0` | Frame 42 | Visible (1) | Passable (0) | 4 | 255 | 180 |
| `obj[25]` | World Device | **Mechanism (ano 45)** | `0` | `(40, 60)` | `0x0` | Frame 45 | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[26]` | World Device | **Mechanism (ano 45)** | `0` | `(36, 60)` | `0x0` | Frame 45 | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[27]` | World Device | **Mechanism (ano 45)** | `0` | `(32, 60)` | `0x0` | Frame 45 | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[28]` | World Device | **Mechanism (ano 45)** | `0` | `(28, 60)` | `0x0` | Frame 45 | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[29]` | World Device | **Mechanism (ano 45)** | `0` | `(24, 60)` | `0x0` | Frame 45 | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[30]` | World Device | **Mechanism (ano 45)** | `0` | `(20, 60)` | `0x0` | Frame 45 | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[31]` | World Device | **Mechanism (ano 44)** | `0` | `(40, 33)` | `0x0` | Frame 44 | Visible (1) | Solid (Obstacle) | 4 | 255 | 180 |
| `obj[32]` | World Device | **Mechanism (ano 44)** | `0` | `(40, 47)` | `0x0` | Frame 44 | Visible (1) | Solid (Obstacle) | 4 | 255 | 180 |
| `obj[33]` | World Device | **Mechanism (ano 44)** | `0` | `(36, 33)` | `0x0` | Frame 44 | Visible (1) | Solid (Obstacle) | 4 | 255 | 180 |
| `obj[34]` | World Device | **Mechanism (ano 44)** | `0` | `(36, 47)` | `0x0` | Frame 44 | Visible (1) | Solid (Obstacle) | 4 | 255 | 180 |
| `obj[35]` | World Device | **Mechanism (ano 44)** | `0` | `(32, 33)` | `0x0` | Frame 44 | Visible (1) | Solid (Obstacle) | 4 | 255 | 180 |
| `obj[36]` | World Device | **Mechanism (ano 44)** | `0` | `(32, 47)` | `0x0` | Frame 44 | Visible (1) | Solid (Obstacle) | 4 | 255 | 180 |
| `obj[37]` | World Device | **Mechanism (ano 44)** | `0` | `(28, 33)` | `0x0` | Frame 44 | Visible (1) | Solid (Obstacle) | 4 | 255 | 180 |
| `obj[38]` | World Device | **Mechanism (ano 44)** | `0` | `(28, 47)` | `0x0` | Frame 44 | Visible (1) | Solid (Obstacle) | 4 | 255 | 180 |
| `obj[39]` | World Device | **Mechanism (ano 44)** | `0` | `(24, 33)` | `0x0` | Frame 44 | Visible (1) | Solid (Obstacle) | 4 | 255 | 180 |
| `obj[40]` | World Device | **Mechanism (ano 44)** | `0` | `(24, 47)` | `0x0` | Frame 44 | Visible (1) | Solid (Obstacle) | 4 | 255 | 180 |
| `obj[41]` | World Device | **Mechanism (ano 44)** | `0` | `(20, 33)` | `0x0` | Frame 44 | Visible (1) | Solid (Obstacle) | 4 | 255 | 180 |
| `obj[42]` | World Device | **Mechanism (ano 44)** | `0` | `(20, 47)` | `0x0` | Frame 44 | Visible (1) | Solid (Obstacle) | 4 | 255 | 180 |
| `obj[43]` | World Device | **Mechanism (ano 46)** | `0` | `(40, 42)` | `0x0` | Frame 46 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[44]` | World Device | **Mechanism (ano 46)** | `0` | `(36, 42)` | `0x0` | Frame 46 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[45]` | World Device | **Mechanism (ano 46)** | `0` | `(32, 42)` | `0x0` | Frame 46 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[46]` | World Device | **Mechanism (ano 46)** | `0` | `(28, 42)` | `0x0` | Frame 46 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[47]` | World Device | **Mechanism (ano 46)** | `0` | `(24, 42)` | `0x0` | Frame 46 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[48]` | World Device | **Mechanism (ano 46)** | `0` | `(20, 42)` | `0x0` | Frame 46 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[49]` | Trigger / Hitbox | **Hitbox Zone (3x6)** | `0` | `(51, 19)` | `2x5` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(51, 21)` with state parameter `10`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(40, 40)` with state parameter `41`.
- **`obj[02]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(40, 58)` with state parameter `41`.
- **`obj[03]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(36, 40)` with state parameter `41`.
- **`obj[04]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(36, 58)` with state parameter `41`.
- **`obj[05]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(32, 40)` with state parameter `41`.
- **`obj[06]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(32, 58)` with state parameter `41`.
- **`obj[07]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(28, 40)` with state parameter `41`.
- **`obj[08]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(28, 58)` with state parameter `41`.
- **`obj[09]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(24, 40)` with state parameter `41`.
- **`obj[10]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(24, 58)` with state parameter `41`.
- **`obj[11]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(20, 40)` with state parameter `41`.
- **`obj[12]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(20, 58)` with state parameter `41`.
- **`obj[13]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(40, 24)` with state parameter `43`.
- **`obj[14]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(36, 24)` with state parameter `43`.
- **`obj[15]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(32, 24)` with state parameter `43`.
- **`obj[16]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(28, 24)` with state parameter `43`.
- **`obj[17]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(24, 24)` with state parameter `43`.
- **`obj[18]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(20, 24)` with state parameter `43`.
- **`obj[19]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(40, 60)` with state parameter `42`.
- **`obj[20]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(36, 60)` with state parameter `42`.
- **`obj[21]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(32, 60)` with state parameter `42`.
- **`obj[22]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(28, 60)` with state parameter `42`.
- **`obj[23]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(24, 60)` with state parameter `42`.
- **`obj[24]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(20, 60)` with state parameter `42`.
- **`obj[25]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(40, 60)` with state parameter `45`.
- **`obj[26]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(36, 60)` with state parameter `45`.
- **`obj[27]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(32, 60)` with state parameter `45`.
- **`obj[28]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(28, 60)` with state parameter `45`.
- **`obj[29]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(24, 60)` with state parameter `45`.
- **`obj[30]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(20, 60)` with state parameter `45`.
- **`obj[31]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(40, 33)` with state parameter `44`.
- **`obj[32]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(40, 47)` with state parameter `44`.
- **`obj[33]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(36, 33)` with state parameter `44`.
- **`obj[34]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(36, 47)` with state parameter `44`.
- **`obj[35]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(32, 33)` with state parameter `44`.
- **`obj[36]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(32, 47)` with state parameter `44`.
- **`obj[37]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(28, 33)` with state parameter `44`.
- **`obj[38]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(28, 47)` with state parameter `44`.
- **`obj[39]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(24, 33)` with state parameter `44`.
- **`obj[40]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(24, 47)` with state parameter `44`.
- **`obj[41]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(20, 33)` with state parameter `44`.
- **`obj[42]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(20, 47)` with state parameter `44`.
- **`obj[43]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(40, 42)` with state parameter `46`.
- **`obj[44]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(36, 42)` with state parameter `46`.
- **`obj[45]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(32, 42)` with state parameter `46`.
- **`obj[46]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(28, 42)` with state parameter `46`.
- **`obj[47]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(24, 42)` with state parameter `46`.
- **`obj[48]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(20, 42)` with state parameter `46`.
- **`obj[49]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `6` tiles high from `(51, 19)` to `(53, 24)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (14 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Always Passes (Unconditional) | Make obj[104] Hidden (disp = 0); Open Dialogue Message Window; Engine Action #9; Exit to World Map (104, 0, 10); Exit to World Map (104, 0, 11); Exit to World Map (104, 0, 12); Exit to World Map (104, 0, 13); Exit to World Map (104, 0, 14); Exit to World Map (104, 0, 15); Exit to World Map (104, 0, 16); Exit to World Map (104, 0, 17); Exit to World Map (104, 0, 18); Exit to World Map (104, 0, 19); Exit to World Map (104, 0, 20); Exit to World Map (104, 0, 21); Warp Room -> Submap 0 at (22,1) facing 104; Open Dialogue Message Window; Open Dialogue Sub-Window (1); Engine Action #104; Open Dialogue Message Window; Close Dialogue Sub-Window (1); Engine Action #104; Open Dialogue Message Window; Clear Dialogue Sub-Window; Warp Room -> Submap 0 at (26,1) facing 104; Open Dialogue Message Window; Fade Out to Black (1); Engine Action #104; Open Dialogue Message Window; Display Chapter Text (1); Engine Action #104; Open Dialogue Message Window; Display Emotion Bubble (1, 104); Open Dialogue Message Window; Dismiss Emotion Bubble (1); Engine Action #104; Open Dialogue Message Window; Warp Room -> Submap 1 at (104,0); Warp Map Transition (1, 104, 0, 33, 1); Engine Action #104; Open Dialogue Message Window; Return Warp to Castle Base (1, 104); Open Dialogue Message Window; Start Boss Battle #1 (BGM: 104); Open Dialogue Message Window; Launch Tactical War Battle (1); Engine Action #104; Open Dialogue Message Window; Toggle Random Encounters (1); Engine Action #104; Open Dialogue Message Window; Open Save Crystal Menu (MSaveInit); Warp Room -> Submap 0 at (39,1) facing 104; Open Dialogue Message Window; Engine Action #40; Warp Room -> Submap 0 at (41,1) facing 104; Open Dialogue Message Window; Remove Item from Inventory (1, 104); Open Dialogue Message Window; Open Shop Menu #104 (Type: 1); Open Dialogue Message Window; Engine Action #44; Warp Room -> Submap 0 at (45,1) facing 104; Open Dialogue Message Window; Make obj[1] Hidden (disp = 0); Engine Action #104; Open Dialogue Message Window; Teleport obj[1] to (104,0); Turn obj[1] facing 104; Open Dialogue Message Window; Set Entity Movement Speed (1, 104); Open Dialogue Message Window; Walk obj[1] to (2,57); Engine Action #51; Display Choice Selection (0, 57); Teleport obj[255] to (254,255) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [0..1, 2..93] AND Condition Check #100 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 6, MsgID: 149]; Engine Action #102 |
| `ev[02]` | `1 (Action / Talk)` | Story Flag 7 (bit 2) CLEAR AND Temp Event Flag #1 SET AND Target Inspected is obj[57] | Recruit Character into Active Party (43 [Ayda], 0); Exit to World Map (55, 0, 52); Display Chapter Text (8); Warp to Castle HQ (0, 1, 33); Warp Room -> Submap 0 at (1,5) facing West (Left); Exit to World Map (4, 1, 3); Engine Action #5; Show Dialogue Portrait (30, 73, 60); Engine Action #5; Warp Room -> Submap 0 at (5,4) facing South (Down); Open Dialogue Message Window; Dismiss Emotion Bubble (24); Warp Room -> Submap 26 at (73,15) facing 5; Warp Room -> Submap 4 at (0,3) facing 30; Return Warp to Castle Base (58, 36); Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[03]` | `1 (Action / Talk)` | Story Flag 7 (bit 2) SET AND Story Flag 7 (bit 4) CLEAR AND Target Inspected is obj[57] | Recruit Character into Active Party (101 [Teresa], 0); Engine Action #176; Open Dialogue Message Window; Reset Camera Tracking (36); Warp Town -> Area 73 Map 15 Submap 99 at (0,1); Set Combat Battle BGM (30); Engine Action #99; Open Dialogue Message Window; Warp Town -> Area 73 Map 30 Submap 99 at (0,4); Set Combat Battle BGM (30); Engine Action #99; Open Dialogue Message Window; Reset Camera Tracking (73); Dismiss Emotion Bubble (99); Open Dialogue Message Window; Dismiss Dialogue Portrait; Set Combat Battle BGM (30); Engine Action #99; Open Dialogue Message Window; Warp Map Transition (73, 60, 54, 0, 2); Launch Tactical War Battle (1); Jump to Bytecode Offset (4, 66); Jump to Bytecode Offset (0, 181); Display Chapter Text (1); Warp Room -> Submap 28 at (2,1) facing 6; Display Chapter Text (0); Warp Room -> Submap 28 at (3,1) facing 6; Display Chapter Text (1); Warp Room -> Submap 28 at (3,1) facing 6; Display Chapter Text (0); Warp Room -> Submap 28 at (2,1) facing 6; Display Chapter Text (0); Warp Room -> Submap 28 at (2,1) facing 6; Display Chapter Text (1); Warp Room -> Submap 28 at (3,1) facing 6; Display Chapter Text (0); Warp Room -> Submap 28 at (3,1) facing 6; Display Chapter Text (1); Warp Room -> Submap 28 at (2,1) facing 6; Display Chapter Text (1); Warp Room -> Submap 28 at (2,1) facing 6; Display Chapter Text (0); Warp Room -> Submap 28 at (3,1) facing 6; Display Chapter Text (1); Warp Room -> Submap 28 at (3,1) facing 6; Display Chapter Text (0); Warp Room -> Submap 28 at (2,1) facing 6; Display Chapter Text (0); Warp Room -> Submap 28 at (2,1) facing 6; Display Chapter Text (1); Warp Room -> Submap 28 at (3,1) facing 6; Display Chapter Text (0); Warp Room -> Submap 28 at (3,1) facing 6; Display Chapter Text (1); Warp Room -> Submap 28 at (2,1) facing 6; Display Chapter Text (1); Warp Room -> Submap 28 at (2,1) facing 6; Display Chapter Text (0); Warp Room -> Submap 28 at (3,1) facing 6; Display Chapter Text (1); Warp Room -> Submap 28 at (3,1) facing 6; Display Chapter Text (0); Warp Room -> Submap 28 at (2,1) facing 6; Display Chapter Text (0); Warp Room -> Submap 28 at (2,1) facing 6; Display Chapter Text (1); Warp Room -> Submap 28 at (3,1) facing 6; Display Chapter Text (0); Warp Room -> Submap 28 at (3,1) facing 6; Display Chapter Text (1); Warp Room -> Submap 28 at (2,1) facing 6; Display Chapter Text (1); Warp Room -> Submap 28 at (2,1) facing 6; Display Chapter Text (0); Warp Room -> Submap 28 at (3,1) facing 6; Jump to Bytecode Offset (9, 8); Display Chapter Text (1); Warp Room -> Submap 28 at (3,1) facing 6; Display Chapter Text (0); Warp Room -> Submap 28 at (2,1) facing 6; Display Chapter Text (0); Warp Room -> Submap 28 at (2,1) facing 6; Display Chapter Text (1); Warp Room -> Submap 28 at (3,1) facing 6; Display Chapter Text (0); Warp Room -> Submap 28 at (3,1) facing 6; Display Chapter Text (1); Warp Room -> Submap 28 at (2,1) facing 6; Engine Action #54; Open Dialogue Message Window; Warp Room -> Submap 69 at (3,101) facing 9; Animate Door Open; Dismiss Emotion Bubble (1); Warp Town -> Area 1 Map 52 Submap 9 at (7,4); Place Scenery Structure (5); Warp Town -> Area 12 Map 8 Submap 52 at (25,58) |
| `ev[04]` | `128 (Loop)` | Story Flag 7 (bit 2) SET AND Story Flag 7 (bit 4) CLEAR AND Inventory Holds Item #1 [Medicine] | Set Combat Battle BGM (60); Close Dialogue Window; Warp Town -> Area 2 Map 150 Submap 37 at (1,255) |
| `ev[05]` | `128 (Loop)` | Story Flag 7 (bit 2) SET AND Story Flag 7 (bit 4) CLEAR AND Inventory Holds Item #2 [Mega Medicine] | Engine Action #44; Full Rest & Healing (Restore HP/MP); Warp Town -> Area 14 Map 0 Submap 14 at (3,37); Warp Town -> Area 255 Map 254 Submap 255 at (254,204) |
| `ev[06]` | `128 (Loop)` | Story Flag 7 (bit 2) SET AND Story Flag 7 (bit 4) CLEAR AND Condition Check #29 AND Always Passes (Unconditional) AND Player X within Range [255..254] | Jump to Bytecode Offset (0, 177); Make obj[0] Hidden (disp = 0); Engine Action #51; Warp Room -> Submap 1 at (10,1) facing 21; Warp Room -> Submap 1 at (33,1) facing 39; Warp Room -> Submap 104 at (0,51) facing 4; Teleport obj[89] to (51,5); Engine Action #89; Engine Action #51; Engine Action #5; Jump to Bytecode Offset (5, 177); Jump to Bytecode Offset (0, 178); Mark NPC Talk Interaction Complete (Flag #0); Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[07]` | `128 (Loop)` | Story Flag 7 (bit 2) SET AND Story Flag 7 (bit 4) CLEAR AND Condition Check #29 AND Always Passes (Unconditional) AND Player Y within Range [255..254] | Jump to Bytecode Offset (0, 177); Make obj[0] Hidden (disp = 0); Engine Action #52; Warp Room -> Submap 1 at (12,1) facing 22; Warp Room -> Submap 1 at (34,1) facing 41; Warp Room -> Submap 104 at (0,52) facing 4; Teleport obj[89] to (52,5); Engine Action #89; Engine Action #52; Engine Action #5; Jump to Bytecode Offset (5, 177); Jump to Bytecode Offset (0, 178); Mark NPC Talk Interaction Complete (Flag #0); Warp Town -> Area 255 Map 254 Submap 255 at (254,204) |
| `ev[08]` | `128 (Loop)` | Story Flag 7 (bit 2) SET AND Story Flag 7 (bit 4) CLEAR AND Condition Check #29 AND Always Passes (Unconditional) AND Story Flag 255 (bit 254) CLEAR | Jump to Bytecode Offset (0, 177); Make obj[0] Hidden (disp = 0); Engine Action #53; Warp Room -> Submap 1 at (14,1) facing 23; Warp Room -> Submap 1 at (35,1) facing 43; Warp Room -> Submap 104 at (0,53) facing 4; Teleport obj[89] to (53,5); Engine Action #89; Engine Action #53; Engine Action #5; Jump to Bytecode Offset (5, 177); Jump to Bytecode Offset (0, 178); Mark NPC Talk Interaction Complete (Flag #0); Exit to World Map (255, 254, 255) |
| `ev[09]` | `128 (Loop)` | Story Flag 7 (bit 2) SET AND Story Flag 7 (bit 4) CLEAR AND Condition Check #29 AND Always Passes (Unconditional) AND Temp Event Flag #255 CLEAR | Jump to Bytecode Offset (0, 177); Make obj[0] Hidden (disp = 0); Engine Action #54; Warp Room -> Submap 1 at (16,1) facing 24; Warp Room -> Submap 1 at (36,1) facing 45; Warp Room -> Submap 104 at (0,54) facing 4; Teleport obj[89] to (54,5); Engine Action #89; Engine Action #54; Engine Action #5; Jump to Bytecode Offset (5, 177); Jump to Bytecode Offset (0, 178); Mark NPC Talk Interaction Complete (Flag #0); Reset Camera Tracking (255) |
| `ev[10]` | `128 (Loop)` | Story Flag 7 (bit 2) SET AND Story Flag 7 (bit 4) CLEAR AND Condition Check #29 AND Always Passes (Unconditional) AND Star of Destiny #255 Recruited | Jump to Bytecode Offset (0, 177); Make obj[0] Hidden (disp = 0); Set Render Priority (pri) (1, 17); Warp Room -> Submap 1 at (25,1) facing 31; Warp Room -> Submap 1 at (47,1) facing 48; Engine Action #104; Open Dialogue Message Window; Set Render Priority (pri) (4, 47); Engine Action #89; Set Render Priority (pri) (5, 89); Set Render Priority (pri) (5, 101); Engine Action #5; Engine Action #177; Jump to Bytecode Offset (0, 178); Mark NPC Talk Interaction Complete (Flag #0); Dismiss Dialogue Portrait |
| `ev[11]` | `128 (Loop)` | Story Flag 7 (bit 2) SET AND Story Flag 7 (bit 4) CLEAR AND Condition Check #29 AND Always Passes (Unconditional) AND Condition Check #32 | Jump to Bytecode Offset (0, 177); Make obj[0] Hidden (disp = 0); Set Animation Pose (1, 19); Warp Room -> Submap 1 at (26,1) facing 32; Warp Room -> Submap 1 at (49,1) facing 50; Engine Action #104; Open Dialogue Message Window; Set Animation Pose (4, 47); Engine Action #89; Set Animation Pose (5, 89); Set Animation Pose (5, 101); Engine Action #5; Engine Action #177; Jump to Bytecode Offset (0, 178); Mark NPC Talk Interaction Complete (Flag #0); Warp Map Transition (255, 254, 255, 254, 204) |
| `ev[12]` | `1 (Action / Talk)` | Story Flag 7 (bit 4) SET AND Story Flag 7 (bit 8) CLEAR AND Player within Box [52..52, 2..25] AND Condition Check #25 | Recruit Character into Active Party (44 [Killey], 46); Open Dialogue Message Window; Reset Camera Tracking (36); Warp Room -> Submap 0 at (1,47) facing 28; Warp Room -> Submap 5 at (28,2) facing West (Left); Engine Action #6; Display Chapter Text (0); Warp Room -> Submap 28 at (3,1) facing 6; Display Chapter Text (1); Warp Room -> Submap 28 at (3,1) facing 6; Display Chapter Text (0); Warp Room -> Submap 28 at (2,1) facing 6; Display Chapter Text (0); Warp Room -> Submap 28 at (2,1) facing 6; Display Chapter Text (1); Warp Room -> Submap 28 at (3,1) facing 6; Display Chapter Text (0); Warp Room -> Submap 28 at (3,1) facing 6; Display Chapter Text (1); Warp Room -> Submap 28 at (2,1) facing 6; Display Chapter Text (1); Warp Room -> Submap 28 at (2,1) facing 6; Display Chapter Text (0); Warp Room -> Submap 28 at (3,1) facing 6; Display Chapter Text (1); Warp Room -> Submap 28 at (3,1) facing 6; Display Chapter Text (0); Warp Room -> Submap 28 at (2,1) facing 6; Display Chapter Text (0); Warp Room -> Submap 28 at (2,1) facing 6; Display Chapter Text (1); Warp Room -> Submap 28 at (3,1) facing 6; Display Chapter Text (0); Warp Room -> Submap 28 at (3,1) facing 6; Display Chapter Text (1); Warp Room -> Submap 28 at (2,1) facing 6; Display Chapter Text (1); Warp Room -> Submap 28 at (2,1) facing 6; Display Chapter Text (0); Warp Room -> Submap 28 at (3,1) facing 6; Display Chapter Text (1); Warp Room -> Submap 28 at (3,1) facing 6; Display Chapter Text (0); Warp Room -> Submap 28 at (2,1) facing 6; Display Chapter Text (0); Warp Room -> Submap 28 at (2,1) facing 6; Display Chapter Text (1); Warp Room -> Submap 28 at (3,1) facing 6; Display Chapter Text (0); Warp Room -> Submap 28 at (3,1) facing 6; Display Chapter Text (1); Warp Room -> Submap 28 at (2,1) facing 6; Display Chapter Text (1); Warp Room -> Submap 28 at (2,1) facing 6; Display Chapter Text (0); Warp Room -> Submap 28 at (3,1) facing 6; Display Chapter Text (1); Warp Room -> Submap 28 at (3,1) facing 6; Display Chapter Text (0); Warp Room -> Submap 28 at (2,1) facing 6; Display Chapter Text (0); Warp Room -> Submap 28 at (2,1) facing 6; Display Chapter Text (1); Warp Room -> Submap 28 at (3,1) facing 6; Display Chapter Text (0); Warp Room -> Submap 28 at (3,1) facing 6; Display Chapter Text (1); Warp Room -> Submap 28 at (2,1) facing 6; Engine Action #54; Warp Room -> Submap 45 at (73,45) facing West (Left); Reset Camera Tracking (73); Trigger Character Emotion Effect (5, 0); Exit to World Map (4, 2, 0); Engine Action #5; Engine Action #5; Open Dialogue Message Window; Warp Room -> Submap 2 at (30,33) facing West (Left); Set Story Milestone Flag 0 (mask 1); Engine Action #5; Warp Room -> Submap 5 at (0,3) facing Up (North); Open Dialogue Message Window; Engine Action #5; Trigger Character Emotion Effect (1, 0); Dismiss Emotion Bubble (24); Warp Room -> Submap 28 at (73,15) facing 49; Warp Town -> Area 5 Map 0 Submap 5 at (15,0); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp to Castle HQ (0, 30, 255); Engine Action #5; Warp Room -> Submap 5 at (1,3) facing 30; Warp Room -> Submap 255 at (254,50) facing 34; Engine Action #9; Pan Camera (8, 58, 255) |
| `ev[13]` | `128 (Loop)` | Story Flag 7 (bit 4) SET AND Story Flag 7 (bit 8) CLEAR AND Inventory Holds Item #1 [Medicine] AND Temp Event Flag #2 SET | Set Combat Battle BGM (40); Close Dialogue Window; Warp Room -> Submap 150 at (36,2) facing 255 |

---

### Submap Layer `vc12_09` (Index 9)

- **Map Number (`mapno`)**: `9`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `90`, Rate: `4`)
- **Entity Count (`okaz`)**: `8` Objects | **Script Count (`evkaz`)**: `10` Scripts

#### Complete Physical Entity Inventory (8 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 23)** | `0` | `(63, 56)` | `0x0` | Frame 23 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 24)** | `0` | `(63, 56)` | `0x0` | Frame 24 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | World Device | **Mechanism (ano 23)** | `0` | `(73, 58)` | `0x0` | Frame 23 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | World Device | **Mechanism (ano 24)** | `0` | `(73, 58)` | `0x0` | Frame 24 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[04]` | World Device | **Mechanism (ano 5)** | `0` | `(0, 0)` | `0x0` | Frame 5 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[05]` | World Device | **Mechanism (ano 6)** | `0` | `(0, 0)` | `0x0` | Frame 6 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[06]` | World Device | **Mechanism (ano 67)** | `0` | `(71, 78)` | `0x0` | Frame 67 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Hitbox Zone (3x6)** | `0` | `(73, 73)` | `2x5` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(63, 56)` with state parameter `23`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(63, 56)` with state parameter `24`.
- **`obj[02]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(73, 58)` with state parameter `23`.
- **`obj[03]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(73, 58)` with state parameter `24`.
- **`obj[04]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(0, 0)` with state parameter `5`.
- **`obj[05]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(0, 0)` with state parameter `6`.
- **`obj[06]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(71, 78)` with state parameter `67`.
- **`obj[07]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `6` tiles high from `(73, 73)` to `(75, 78)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (10 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Treasure Byte 1 Bit 1 FRESH (Unopened) | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[01]` | `2 (Map Init)` | Treasure Byte 1 Bit 2 FRESH (Unopened) | Open Dialogue Message Window; Screen Fade Transition (255, 254, 255) |
| `ev[02]` | `2 (Map Init)` | Treasure Byte 1 Bit 1 LOOTED | Open Dialogue Message Window; Engine Action #9 |
| `ev[03]` | `2 (Map Init)` | Treasure Byte 1 Bit 2 LOOTED | Open Dialogue Message Window; Close Dialogue Window |
| `ev[04]` | `2 (Map Init)` | Always Passes (Unconditional) | Make obj[2] Hidden (disp = 0); Display Dialogue Box [Bank: 64, MsgID: 77]; Open Dialogue Message Window; Display Dialogue Box [Bank: 2, MsgID: 13]; Play CD / Ambient BGM Track (77); Open Dialogue Message Window; Place Scenery Structure (0); Show Dialogue Portrait (47, 255, 254) |
| `ev[05]` | `1 (Action / Talk)` | Player within Box [0..1, 2..124] AND Condition Check #138 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 6, MsgID: 149]; Engine Action #170 |
| `ev[06]` | `1 (Action / Talk)` | Story Flag 7 (bit 16) CLEAR AND Temp Event Flag #1 SET AND Target Inspected is obj[15] | Recruit Character into Active Party (43 [Ayda], 0); Exit to World Map (55, 0, 74); Remove Item from Inventory (8, 3); Open Dialogue Message Window; Warp Room -> Submap 1 at (95,0) facing West (Left); Engine Action #5; Warp Room -> Submap 4 at (1,3) facing 5; Show Dialogue Portrait (30, 73, 60); Engine Action #5; Warp Room -> Submap 0 at (5,4) facing South (Down); Open Dialogue Message Window; Dismiss Emotion Bubble (24); Warp Room -> Submap 26 at (73,15) facing 5; Warp Room -> Submap 4 at (0,3) facing 30; Warp Room -> Submap 34 at (58,36) facing West (Left) |
| `ev[07]` | `1 (Action / Talk)` | Story Flag 7 (bit 16) SET AND Temp Event Flag #1 SET AND Target Inspected is obj[15] | Recruit Character into Active Party (0, 14); Set Combat Battle BGM (15); Set Entity Movement Speed (2, 90); Display Dialogue Box [Bank: 4, MsgID: 2]; Display Speaker Name Box (3); Dismiss Emotion Bubble (255); Engine Action #90; Place Scenery Structure (4); Warp Town -> Area 19 Map 3 Submap 30 at (255,254); Walk obj[73] to (15,1); Animate Door Open; Engine Action #58; Launch Tactical War Battle (1) |
| `ev[08]` | `1 (Action / Talk)` | Treasure Byte 1 Bit 1 FRESH (Unopened) AND Target Inspected is obj[8] | Recruit Character into Active Party (46 [Oulan], 0); Engine Action #9; Warp Room -> Submap 47 at (101,4) facing 7; Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (0); Exit to World Map (0, 93, 32); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,1) facing West (Left); Engine Action #51; Warp Town -> Area 255 Map 1 Submap 46 at (0,8); Warp Room -> Submap 47 at (255,2) facing 58 |
| `ev[09]` | `1 (Action / Talk)` | Treasure Byte 1 Bit 2 FRESH (Unopened) AND Target Inspected is obj[10] | Recruit Character into Active Party (46 [Oulan], 0); Close Dialogue Window; Warp Room -> Submap 47 at (101,4) facing 7; Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (0); Exit to World Map (0, 2, 80); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,1) facing Up (North); Engine Action #51; Warp Town -> Area 255 Map 1 Submap 46 at (0,10); Warp Room -> Submap 47 at (255,2) facing 58 |

---

### Submap Layer `vc12_10` (Index 10)

- **Map Number (`mapno`)**: `10`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `3` Objects | **Script Count (`evkaz`)**: `5` Scripts

#### Complete Physical Entity Inventory (3 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 5)** | `0` | `(0, 0)` | `0x0` | Frame 5 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 6)** | `0` | `(0, 0)` | `0x0` | Frame 6 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | Trigger / Hitbox | **Hitbox Zone (3x6)** | `0` | `(43, 25)` | `2x5` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(0, 0)` with state parameter `5`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(0, 0)` with state parameter `6`.
- **`obj[02]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `6` tiles high from `(43, 25)` to `(45, 30)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (5 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 7 (bit 32) CLEAR | Make obj[2] Hidden (disp = 0); Reset Camera Tracking (34); Display Emotion Bubble (0, 8); Warp Town -> Area 9 Map 38 Submap 29 at (0,9); Open Dialogue Message Window; Screen Fade Transition (47, 255, 254) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [36..40, 2..71] AND Condition Check #72 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 6, MsgID: 32]; Open Save Crystal Menu (MSaveInit) |
| `ev[02]` | `128 (Loop)` | Player within Box [38..38, 2..68] AND Condition Check #68 | Warp Room -> Submap 0 at (2,13) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [36..40, 2..28] AND Condition Check #29 AND Story Flag 1 (mask 255) SET | Warp Room -> Submap 0 at (2,13); Warp Map Transition (3, 0, 40, 88, 255) |
| `ev[04]` | `1 (Action / Talk)` | Story Flag 7 (bit 16) SET AND Story Flag 7 (bit 32) CLEAR AND Target Inspected is obj[10] | Recruit Character into Active Party (43 [Ayda], 0); Exit to World Map (55, 0, 44); Return Warp to Castle Base (8, 3); Open Dialogue Message Window; Warp Room -> Submap 3 at (95,18) facing 80; Make obj[0] Hidden (disp = 0); Warp Room -> Submap 2 at (0,3) facing South (Down); Exit to World Map (0, 5, 0); Engine Action #6; Teleport obj[49] to (6,5); Warp Room -> Submap 5 at (1,3) facing 5; Show Dialogue Portrait (30, 255, 254); Engine Action #5; Warp Town -> Area 4 Map 5 Submap 3 at (2,1); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Warp to Castle HQ (4, 5, 2); Warp Town -> Area 1 Map 0 Submap 30 at (255,254); Engine Action #5; Exit to World Map (4, 5, 3); Exit to World Map (1, 0, 30); Engine Action #5; Engine Action #5; Exit to World Map (5, 2, 4); Warp Room -> Submap 30 at (255,254) facing 5; Engine Action #6; Exit to World Map (5, 2, 6); Warp Room -> Submap 30 at (255,254) facing 50; Engine Action #5; Warp Room -> Submap 60 at (2,0) facing 5; Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (24); Warp Room -> Submap 60 at (73,15) facing 24; Warp Town -> Area 0 Map 61 Submap 73 at (15,24); Warp Room -> Submap 62 at (5,1) facing 5; Show Dialogue Portrait (2, 0, 5); Engine Action #5; Warp Room -> Submap 5 at (30,30) facing 24; Warp Room -> Submap 63 at (5,2) facing 5; Trigger Character Emotion Effect (2, 0); Engine Action #5; Show Dialogue Portrait (30, 24, 2); Open Dialogue Message Window; Animate Doorway State (5, 0); Engine Action #5; Engine Action #5; Warp to Castle HQ (0, 5, 5); Dismiss Emotion Bubble (5); Warp to Castle HQ (3, 0, 5); Show Dialogue Portrait (30, 24, 3); Open Dialogue Message Window; Play Sound Effect (SE) (73); Show Dialogue Portrait (73, 20, 40); Open Dialogue Message Window; Open Dialogue Message Window; Warp to Castle HQ (0, 66, 0); Open Shop Interface #0; Play CD / Ambient BGM Track (41); Warp to Castle HQ (0, 1, 2); Open Dialogue Message Window; Close Dialogue Sub-Window (3); Open Dialogue Message Window; Wait for Audio / Window Sync (51); Warp to Castle HQ (255, 1, 24); Warp to Castle HQ (0, 70, 51); Warp to Castle HQ (255, 2, 24); Warp to Castle HQ (0, 71, 255); Warp to Castle HQ (5, 1, 5); Show Dialogue Portrait (2, 0, 5); Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 24, 1); Open Dialogue Message Window; Load Sound Bank into Memory (49, 4); Engine Action #5; Warp Room -> Submap 15 at (2,0) facing 5; Engine Action #5; Warp Room -> Submap 5 at (100,30) facing 255; Engine Action #5; Open Dialogue Message Window; Engine Action #5; Dismiss Emotion Bubble (1); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Warp Town -> Area 5 Map 40 Submap 1 at (0,30); Engine Action #5; Warp to Castle HQ (5, 50, 1); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Walk obj[45] to (49,2); Engine Action #90; Reset Camera Tracking (4); Warp Town -> Area 18 Map 3 Submap 30 at (255,254); Engine Action #90; Engine Action #9; Exit to World Map (2, 19, 3); Dismiss Emotion Bubble (255); Walk obj[24] to (1,1); Set Story Flag (73, 15); Engine Action #39; Return Warp to Castle Base (58, 9); Pan Camera (32, 255, 254) |

---



## Location Map: `vc13`

- **Master Map Container**: `vc13.json`
- **Submap Layer Files**: vc13_00.json, vc13_01.json
- **Collision Grid Files**: vc13_map_00.json, vc13_map_09.json
- **Sprite Animation Bundles**: vc13_00_obj.json
- **Submap Room Count**: 11

### Submap Layer `vc13_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `3` Objects | **Script Count (`evkaz`)**: `5` Scripts

#### Complete Physical Entity Inventory (3 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 5)** | `0` | `(0, 0)` | `0x0` | Frame 5 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 6)** | `0` | `(0, 0)` | `0x0` | Frame 6 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | Trigger / Hitbox | **Hitbox Zone (3x4)** | `0` | `(43, 30)` | `2x3` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(0, 0)` with state parameter `5`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(0, 0)` with state parameter `6`.
- **`obj[02]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `4` tiles high from `(43, 30)` to `(45, 33)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (5 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Always Passes (Unconditional) | Make obj[2] Hidden (disp = 0); Reset Camera Tracking (34); Display Emotion Bubble (0, 8); Warp Town -> Area 9 Map 38 Submap 29 at (0,9); Warp Town -> Area 10 Map 43 Submap 29 at (0,10); Teleport obj[255] to (254,255) |
| `ev[01]` | `2 (Map Init)` | Always Passes (Unconditional) | Animate Door obj[2] (State: 12); Open Dialogue Message Window; Open Save Crystal Menu (MSaveInit); Open Shop Interface #255 |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [34..42, 2..27] AND Treasure Byte 9 Bit 1 FRESH (Unopened) | Display Dialogue Box [Bank: 1, MsgID: 72]; Engine Action #134 |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [36..40, 2..71] AND Condition Check #72 AND Story Flag 0 (mask 255) SET | Warp Room -> Submap 0 at (2,3); Set Special Scene BGM (1); Warp Map Transition (3, 3, 36, 15, 255) |
| `ev[04]` | `1 (Action / Talk)` | Temp Event Flag #1 SET AND Target Inspected is obj[10] | Recruit Character into Active Party (101 [Teresa], 0); Engine Action #176; Set Combat Battle BGM (15); Jump to Bytecode Offset (0, 177); Set Entity Movement Speed (2, 90); Reset Camera Tracking (4); Warp Town -> Area 18 Map 3 Submap 30 at (255,254); Engine Action #90; Engine Action #9; Exit to World Map (2, 19, 3); Dismiss Emotion Bubble (255); Walk obj[101] to (5,177); Jump to Bytecode Offset (0, 178); Launch Tactical War Battle (1); Engine Action #58 |

---

### Submap Layer `vc13_01` (Index 1)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `2` (Timer: `90`, Rate: `4`)
- **Entity Count (`okaz`)**: `4` Objects | **Script Count (`evkaz`)**: `9` Scripts

#### Complete Physical Entity Inventory (4 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 19)** | `0` | `(32, 30)` | `0x0` | Frame 19 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 19)** | `0` | `(37, 30)` | `0x0` | Frame 19 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | World Device | **Mechanism (ano 20)** | `0` | `(32, 30)` | `0x0` | Frame 20 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | World Device | **Mechanism (ano 20)** | `0` | `(37, 30)` | `0x0` | Frame 20 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(32, 30)` with state parameter `19`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(37, 30)` with state parameter `19`.
- **`obj[02]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(32, 30)` with state parameter `20`.
- **`obj[03]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(37, 30)` with state parameter `20`.


#### Complete Bytecode Script Catalog (9 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 8 (bit 1) SET | Open Choice Selection Menu (1, 255) |
| `ev[01]` | `2 (Map Init)` | Treasure Byte 0 Bit 1 FRESH (Unopened) | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[02]` | `2 (Map Init)` | Treasure Byte 0 Bit 2 FRESH (Unopened) | Open Dialogue Message Window; Engine Action #9 |
| `ev[03]` | `2 (Map Init)` | Treasure Byte 0 Bit 1 LOOTED | Open Dialogue Message Window; Screen Fade Transition (255, 254, 255) |
| `ev[04]` | `2 (Map Init)` | Treasure Byte 0 Bit 2 LOOTED | Open Dialogue Message Window; Close Dialogue Window |
| `ev[05]` | `1 (Action / Talk)` | Player within Box [69..75, 2..138] AND Condition Check #139 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 38]; Warp Map Transition (255, 254, 204, 204, 204) |
| `ev[06]` | `1 (Action / Talk)` | Player within Box [114..127, 2..5] AND Inventory Holds Item #9 [Kindness Drops] AND Player X within Range [255..254] | Display Dialogue Box [Bank: 2, MsgID: 28]; Engine Action #159 |
| `ev[07]` | `1 (Action / Talk)` | Treasure Byte 0 Bit 1 FRESH (Unopened) AND Target Inspected is obj[8] | Recruit Character into Active Party (46 [Oulan], 0); Screen Fade Transition (1, 8, 47); Jump to Bytecode Offset (4, 7); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (0); Exit to World Map (0, 2, 0); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,0) facing West (Left); Engine Action #51; Warp Town -> Area 255 Map 1 Submap 46 at (0,8); Warp Room -> Submap 47 at (255,2) facing 58 |
| `ev[08]` | `1 (Action / Talk)` | Treasure Byte 0 Bit 2 FRESH (Unopened) AND Target Inspected is obj[9] | Recruit Character into Active Party (46 [Oulan], 0); Close Dialogue Window; Warp Room -> Submap 47 at (101,4) facing 7; Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (0); Exit to World Map (0, 22, 0); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,0) facing Up (North); Engine Action #51; Warp Town -> Area 255 Map 1 Submap 46 at (0,9); Warp Room -> Submap 47 at (255,2) facing 58 |

---

### Submap Layer `vc13_02` (Index 2)

- **Map Number (`mapno`)**: `2`
- **Battle Encounter Zone (`batlno`)**: `2` (Timer: `90`, Rate: `4`)
- **Entity Count (`okaz`)**: `6` Objects | **Script Count (`evkaz`)**: `23` Scripts

#### Complete Physical Entity Inventory (6 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 19)** | `0` | `(47, 139)` | `0x0` | Frame 19 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 20)** | `0` | `(47, 139)` | `0x0` | Frame 20 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | World Device | **Mechanism (ano 19)** | `0` | `(101, 36)` | `0x0` | Frame 19 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | World Device | **Mechanism (ano 20)** | `0` | `(101, 36)` | `0x0` | Frame 20 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[04]` | World Device | **Mechanism (ano 19)** | `0` | `(46, 33)` | `0x0` | Frame 19 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[05]` | World Device | **Mechanism (ano 20)** | `0` | `(46, 33)` | `0x0` | Frame 20 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(47, 139)` with state parameter `19`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(47, 139)` with state parameter `20`.
- **`obj[02]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(101, 36)` with state parameter `19`.
- **`obj[03]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(101, 36)` with state parameter `20`.
- **`obj[04]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(46, 33)` with state parameter `19`.
- **`obj[05]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(46, 33)` with state parameter `20`.


#### Complete Bytecode Script Catalog (23 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 8 (bit 1) SET | Open Choice Selection Menu (1, 255) |
| `ev[01]` | `2 (Map Init)` | Treasure Byte 0 Bit 4 FRESH (Unopened) | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[02]` | `2 (Map Init)` | Treasure Byte 0 Bit 4 LOOTED | Open Dialogue Message Window; Engine Action #9 |
| `ev[03]` | `2 (Map Init)` | Treasure Byte 0 Bit 8 FRESH (Unopened) | Open Dialogue Message Window; Screen Fade Transition (255, 254, 255) |
| `ev[04]` | `2 (Map Init)` | Treasure Byte 0 Bit 8 LOOTED | Open Dialogue Message Window; Close Dialogue Window |
| `ev[05]` | `2 (Map Init)` | Treasure Byte 0 Bit 16 FRESH (Unopened) | Open Dialogue Message Window; Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[06]` | `2 (Map Init)` | Treasure Byte 0 Bit 16 LOOTED | Open Dialogue Message Window; Place Scenery Structure (255) |
| `ev[07]` | `128 (Loop)` | Story Flag 8 (bit 1) CLEAR AND Player within Box [30..31, 2..79] AND Condition Check #82 AND Story Flag 2 (mask 255) SET | Open Choice Selection Menu (0, 255) |
| `ev[08]` | `128 (Loop)` | Story Flag 8 (bit 1) CLEAR AND Player within Box [32..33, 2..79] AND Condition Check #82 AND Story Flag 3 (mask 255) SET | Open Choice Selection Menu (1, 255) |
| `ev[09]` | `128 (Loop)` | Story Flag 8 (bit 1) CLEAR AND Player within Box [91..92, 2..79] AND Condition Check #82 AND Story Flag 2 (mask 255) SET | Open Choice Selection Menu (1, 255) |
| `ev[10]` | `128 (Loop)` | Story Flag 8 (bit 1) CLEAR AND Player within Box [93..94, 2..79] AND Condition Check #82 AND Story Flag 3 (mask 255) SET | Open Choice Selection Menu (0, 255) |
| `ev[11]` | `128 (Loop)` | Temp Event Flag #1 SET AND Player within Box [54..62, 2..0] AND Story Flag 255 (mask 254) SET | Make obj[121] Hidden (disp = 0); Warp Room -> Submap 1 at (37,2) facing 47 |
| `ev[12]` | `128 (Loop)` | Temp Event Flag #2 SET AND Player within Box [65..67, 2..0] AND Story Flag 255 (mask 254) SET | Make obj[121] Hidden (disp = 0); Warp Town -> Area 36 Map 2 Submap 37 at (1,47) |
| `ev[13]` | `128 (Loop)` | Temp Event Flag #1 SET AND Player within Box [46..50, 2..41] AND Condition Check #42 | Make obj[121] Hidden (disp = 0); Warp Room -> Submap 1 at (37,2) facing 47 |
| `ev[14]` | `128 (Loop)` | Temp Event Flag #2 SET AND Player within Box [41..51, 2..39] AND Condition Check #40 | Make obj[121] Hidden (disp = 0); Warp Town -> Area 36 Map 2 Submap 37 at (1,47) |
| `ev[15]` | `128 (Loop)` | Temp Event Flag #2 SET AND Player within Box [45..51, 2..53] AND Condition Check #54 | Make obj[121] Hidden (disp = 0); Warp Town -> Area 36 Map 2 Submap 37 at (1,47) |
| `ev[16]` | `128 (Loop)` | Temp Event Flag #1 SET AND Player within Box [46..50, 2..51] AND Condition Check #52 | Make obj[121] Hidden (disp = 0); Warp Room -> Submap 1 at (37,2) facing 47 |
| `ev[17]` | `1 (Action / Talk)` | Player within Box [21..35, 2..161] AND Condition Check #162 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 120]; Reset Camera Tracking (255) |
| `ev[18]` | `1 (Action / Talk)` | Player within Box [65..67, 2..5] AND Inventory Holds Item #9 [Kindness Drops] AND Player X within Range [255..254] | Display Dialogue Box [Bank: 3, MsgID: 50]; Remove Character from Active Party (255) |
| `ev[19]` | `1 (Action / Talk)` | Player within Box [54..62, 2..5] AND Inventory Holds Item #9 [Kindness Drops] AND Player X within Range [255..254] | Display Dialogue Box [Bank: 3, MsgID: 42]; Remove Character from Active Party (255) |
| `ev[20]` | `1 (Action / Talk)` | Treasure Byte 0 Bit 4 FRESH (Unopened) AND Target Inspected is obj[8] | Recruit Character into Active Party (46 [Oulan], 0); Engine Action #9; Warp Room -> Submap 47 at (101,4) facing 7; Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (0); Exit to World Map (0, 18, 0); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,0) facing 4; Engine Action #51; Warp Town -> Area 255 Map 1 Submap 46 at (0,8); Warp Room -> Submap 47 at (255,2) facing 58 |
| `ev[21]` | `1 (Action / Talk)` | Treasure Byte 0 Bit 8 FRESH (Unopened) AND Target Inspected is obj[10] | Recruit Character into Active Party (46 [Oulan], 0); Close Dialogue Window; Warp Room -> Submap 47 at (101,4) facing 7; Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (0); Exit to World Map (0, 51, 16); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,0) facing 8; Engine Action #51; Warp Town -> Area 255 Map 1 Submap 46 at (0,10); Warp Room -> Submap 47 at (255,2) facing 58 |
| `ev[22]` | `1 (Action / Talk)` | Treasure Byte 0 Bit 16 FRESH (Unopened) AND Target Inspected is obj[12] | Recruit Character into Active Party (46 [Oulan], 0); Place Scenery Structure (1); Display Dialogue Box [Bank: 47, MsgID: 101]; Exit to World Map (7, 101, 4); Pan Camera (30, 0, 4); Open Dialogue Message Window; Warp to Castle HQ (32, 0, 41); Warp Town -> Area 0 Map 1 Submap 255 at (0,97); Open Dialogue Message Window; Dismiss Dialogue Portrait; Engine Action #51; Warp Town -> Area 255 Map 1 Submap 46 at (0,12); Warp Room -> Submap 47 at (255,2) facing 58 |

---

### Submap Layer `vc13_03` (Index 3)

- **Map Number (`mapno`)**: `3`
- **Battle Encounter Zone (`batlno`)**: `2` (Timer: `90`, Rate: `4`)
- **Entity Count (`okaz`)**: `4` Objects | **Script Count (`evkaz`)**: `17` Scripts

#### Complete Physical Entity Inventory (4 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 47)** | `0` | `(68, 36)` | `0x0` | Frame 47 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 5)** | `0` | `(72, 35)` | `0x0` | Frame 5 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | World Device | **Mechanism (ano 6)** | `0` | `(76, 35)` | `0x0` | Frame 6 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | Trigger / Hitbox | **Hitbox Zone (3x6)** | `0` | `(69, 31)` | `2x5` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(68, 36)` with state parameter `47`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(72, 35)` with state parameter `5`.
- **`obj[02]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(76, 35)` with state parameter `6`.
- **`obj[03]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `6` tiles high from `(69, 31)` to `(71, 36)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (17 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 8 (bit 1) SET | Open Choice Selection Menu (1, 255) |
| `ev[01]` | `2 (Map Init)` | Always Passes (Unconditional) | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[02]` | `128 (Loop)` | Story Flag 8 (bit 1) CLEAR AND Player within Box [22..23, 2..39] AND Condition Check #42 AND Story Flag 2 (mask 255) SET | Open Choice Selection Menu (0, 255) |
| `ev[03]` | `128 (Loop)` | Story Flag 8 (bit 1) CLEAR AND Player within Box [24..25, 2..39] AND Condition Check #42 AND Story Flag 3 (mask 255) SET | Open Choice Selection Menu (1, 255) |
| `ev[04]` | `128 (Loop)` | Story Flag 8 (bit 1) CLEAR AND Player within Box [59..60, 2..39] AND Condition Check #42 AND Story Flag 2 (mask 255) SET | Open Choice Selection Menu (1, 255) |
| `ev[05]` | `128 (Loop)` | Story Flag 8 (bit 1) CLEAR AND Player within Box [61..62, 2..39] AND Condition Check #42 AND Story Flag 3 (mask 255) SET | Open Choice Selection Menu (0, 255) |
| `ev[06]` | `128 (Loop)` | Temp Event Flag #1 SET AND Player within Box [38..46, 2..69] AND Condition Check #72 | Make obj[121] Hidden (disp = 0); Warp Room -> Submap 1 at (37,2) facing 47 |
| `ev[07]` | `128 (Loop)` | Temp Event Flag #2 SET AND Player within Box [49..51, 2..69] AND Condition Check #72 | Make obj[121] Hidden (disp = 0); Warp Town -> Area 36 Map 2 Submap 37 at (1,47) |
| `ev[08]` | `128 (Loop)` | Temp Event Flag #1 SET AND Player within Box [38..46, 2..0] AND Story Flag 255 (mask 254) SET | Make obj[121] Hidden (disp = 0); Warp Room -> Submap 1 at (37,2) facing 47 |
| `ev[09]` | `128 (Loop)` | Temp Event Flag #1 SET AND Player within Box [0..3, 2..50] AND Condition Check #55 | Make obj[121] Hidden (disp = 0); Warp Room -> Submap 1 at (37,2) facing 47 |
| `ev[10]` | `128 (Loop)` | Temp Event Flag #2 SET AND Player within Box [0..3, 2..37] AND Condition Check #44 | Make obj[121] Hidden (disp = 0); Warp Town -> Area 36 Map 2 Submap 37 at (1,47) |
| `ev[11]` | `1 (Action / Talk)` | Player within Box [47..56, 2..73] AND Condition Check #74 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 66]; Reset Camera Tracking (255) |
| `ev[12]` | `1 (Action / Talk)` | Player within Box [33..47, 2..73] AND Condition Check #74 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 59]; Reset Camera Tracking (255) |
| `ev[13]` | `1 (Action / Talk)` | Player within Box [0..1, 2..37] AND Condition Check #44 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 4, MsgID: 101]; Set Special Scene BGM (255) |
| `ev[14]` | `1 (Action / Talk)` | Player within Box [0..1, 2..50] AND Condition Check #55 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 4, MsgID: 101]; Engine Action #83 |
| `ev[15]` | `1 (Action / Talk)` | Player within Box [70..82, 2..5] AND Inventory Holds Item #9 [Kindness Drops] AND Player X within Range [255..254] | Display Dialogue Box [Bank: 6, MsgID: 108]; Engine Action #195 |
| `ev[16]` | `1 (Action / Talk)` | Player within Box [33..53, 2..5] AND Inventory Holds Item #9 [Kindness Drops] AND Player X within Range [255..254] | Display Dialogue Box [Bank: 6, MsgID: 74]; Engine Action #195 |

---

### Submap Layer `vc13_04` (Index 4)

- **Map Number (`mapno`)**: `4`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `10` Objects | **Script Count (`evkaz`)**: `15` Scripts

#### Complete Physical Entity Inventory (10 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 5)** | `0` | `(56, 31)` | `0x0` | Frame 5 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 6)** | `0` | `(60, 31)` | `0x0` | Frame 6 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | Save Point | **Journeyman Save Orb** | `0` | `(66, 36)` | `0x0` | Frame 14 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 1 | 0 |
| `obj[03]` | Save Point | **Journeyman Save Orb** | `0` | `(68, 44)` | `0x0` | Frame 14 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[04]` | Save Point | **Journeyman Save Orb** | `0` | `(68, 52)` | `0x0` | Frame 14 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[05]` | Save Point | **Journeyman Save Orb** | `0` | `(48, 36)` | `0x0` | Frame 14 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[06]` | Save Point | **Journeyman Save Orb** | `0` | `(48, 44)` | `0x0` | Frame 14 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[07]` | Save Point | **Journeyman Save Orb** | `0` | `(48, 52)` | `0x0` | Frame 14 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[08]` | World Device | **Mechanism (ano 11)** | `0` | `(45, 60)` | `0x0` | Frame 11 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[09]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(45, 63)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(56, 31)` with state parameter `5`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(60, 31)` with state parameter `6`.
- **`obj[02]` (Journeyman Save Crystal)**: Floating save station orb at tile `(66, 36)`, priority `0`. Triggers `MSaveInit` save system dialog.
- **`obj[03]` (Journeyman Save Crystal)**: Floating save station orb at tile `(68, 44)`, priority `0`. Triggers `MSaveInit` save system dialog.
- **`obj[04]` (Journeyman Save Crystal)**: Floating save station orb at tile `(68, 52)`, priority `0`. Triggers `MSaveInit` save system dialog.
- **`obj[05]` (Journeyman Save Crystal)**: Floating save station orb at tile `(48, 36)`, priority `0`. Triggers `MSaveInit` save system dialog.
- **`obj[06]` (Journeyman Save Crystal)**: Floating save station orb at tile `(48, 44)`, priority `0`. Triggers `MSaveInit` save system dialog.
- **`obj[07]` (Journeyman Save Crystal)**: Floating save station orb at tile `(48, 52)`, priority `0`. Triggers `MSaveInit` save system dialog.
- **`obj[08]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(45, 60)` with state parameter `11`.
- **`obj[09]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(45, 63)` to `(47, 65)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (15 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Always Passes (Unconditional) | Dismiss Emotion Bubble (2); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[01]` | `2 (Map Init)` | Always Passes (Unconditional) | Make obj[0] Hidden (disp = 0); Reset Camera Tracking (0); Engine Action #9; Open Dialogue Message Window; Screen Fade Transition (0, 11, 0); Display Dialogue Box [Bank: 0, MsgID: 13]; Open Dialogue Message Window; Animate Door Open; Open Dialogue Message Window; Show Dialogue Portrait (47, 255, 254) |
| `ev[02]` | `2 (Map Init)` | Story Flag 7 (bit 16) CLEAR | Make obj[0] Hidden (disp = 0); Change Portrait Expression (0); Dismiss Dialogue Portrait; Teleport obj[255] to (254,255) |
| `ev[03]` | `128 (Loop)` | Story Flag 8 (bit 1) CLEAR AND Player within Box [65..67, 2..67] AND Condition Check #68 AND Story Flag 0 (mask 255) SET | Open Choice Selection Menu (0, 255) |
| `ev[04]` | `128 (Loop)` | Story Flag 8 (bit 1) CLEAR AND Player within Box [65..67, 2..65] AND Condition Check #66 AND Story Flag 1 (mask 255) SET | Open Choice Selection Menu (1, 255) |
| `ev[05]` | `128 (Loop)` | Story Flag 8 (bit 1) CLEAR AND Player within Box [60..60, 2..34] AND Condition Check #34 AND Story Flag 0 (mask 255) SET | Open Choice Selection Menu (1, 255) |
| `ev[06]` | `128 (Loop)` | Temp Event Flag #1 SET AND Player within Box [100..103, 2..82] AND Condition Check #87 | Make obj[121] Hidden (disp = 0); Warp Room -> Submap 1 at (37,2) facing 47 |
| `ev[07]` | `128 (Loop)` | Temp Event Flag #2 SET AND Player within Box [100..103, 2..69] AND Condition Check #76 | Make obj[121] Hidden (disp = 0); Warp Town -> Area 36 Map 2 Submap 37 at (1,47) |
| `ev[08]` | `128 (Loop)` | Temp Event Flag #1 SET AND Player within Box [44..48, 2..77] AND Condition Check #78 | Make obj[121] Hidden (disp = 0); Warp Room -> Submap 1 at (37,2) facing 47 |
| `ev[09]` | `128 (Loop)` | Temp Event Flag #2 SET AND Player within Box [41..51, 2..75] AND Condition Check #76 | Make obj[121] Hidden (disp = 0); Warp Town -> Area 36 Map 2 Submap 37 at (1,47) |
| `ev[10]` | `1 (Action / Talk)` | Player within Box [102..103, 2..68] AND Condition Check #79 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 3, MsgID: 2]; Remove Item from Inventory (255, 254) |
| `ev[11]` | `1 (Action / Talk)` | Player within Box [102..103, 2..82] AND Condition Check #87 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 3, MsgID: 2]; Engine Action #51 |
| `ev[12]` | `1 (Action / Talk)` | Player within Box [56..64, 2..30] AND Condition Check #31 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 5, MsgID: 38]; Load Sound Bank into Memory (255, 254) |
| `ev[13]` | `1 (Action / Talk)` | Temp Event Flag #4 SET AND Active Party Has Character #10 AND Condition Check #68 AND Condition Check #68 AND Party Formation Check AND Story Flag 36 (mask 36) CLEAR | Jump to Bytecode Offset (0, 176); Recruit Character into Active Party (101 [Teresa], 0); Engine Action #177; Set Entity Movement Speed (2, 90); Reset Camera Tracking (4); Warp Town -> Area 18 Map 3 Submap 30 at (255,254); Engine Action #90; Engine Action #9; Exit to World Map (2, 19, 3); Dismiss Emotion Bubble (255); Walk obj[101] to (5,177); Jump to Bytecode Offset (0, 178); Launch Tactical War Battle (4); Engine Action #58 |
| `ev[14]` | `1 (Action / Talk)` | Story Flag 7 (bit 8) SET AND Story Flag 7 (bit 16) CLEAR AND Target Inspected is obj[17] | Recruit Character into Active Party (43 [Ayda], 0); Exit to World Map (55, 0, 46); Wait for Audio / Window Sync (8); Warp to Castle HQ (0, 1, 33); Warp Room -> Submap 0 at (1,5) facing West (Left); Exit to World Map (5, 1, 3); Engine Action #5; Show Dialogue Portrait (30, 24, 1); Warp Room -> Submap 5 at (1,5) facing 15; Warp Room -> Submap 30 at (1,16) facing 5; Warp Room -> Submap 1 at (5,15) facing East (Right); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Open Dialogue Message Window; Warp to Castle HQ (30, 1, 1); Return Warp to Castle Base (101, 4); Engine Action #6; Dismiss Emotion Bubble (1); Warp Town -> Area 0 Map 53 Submap 9 at (7,16); Engine Action #58 |

---

### Submap Layer `vc13_05` (Index 5)

- **Map Number (`mapno`)**: `5`
- **Battle Encounter Zone (`batlno`)**: `2` (Timer: `90`, Rate: `4`)
- **Entity Count (`okaz`)**: `2` Objects | **Script Count (`evkaz`)**: `5` Scripts

#### Complete Physical Entity Inventory (2 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 19)** | `0` | `(43, 32)` | `0x0` | Frame 19 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 20)** | `0` | `(43, 32)` | `0x0` | Frame 20 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(43, 32)` with state parameter `19`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(43, 32)` with state parameter `20`.


#### Complete Bytecode Script Catalog (5 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 8 (bit 1) SET | Open Choice Selection Menu (1, 255) |
| `ev[01]` | `2 (Map Init)` | Treasure Byte 0 Bit 32 FRESH (Unopened) | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[02]` | `2 (Map Init)` | Treasure Byte 0 Bit 32 LOOTED | Open Dialogue Message Window; Engine Action #9 |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [32..44, 2..76] AND Condition Check #77 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 4, MsgID: 60]; Return Warp to Castle Base (255, 254) |
| `ev[04]` | `1 (Action / Talk)` | Treasure Byte 0 Bit 32 FRESH (Unopened) AND Target Inspected is obj[8] | Recruit Character into Active Party (46 [Oulan], 0); Engine Action #9; Warp Room -> Submap 47 at (101,4) facing 7; Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (0); Exit to World Map (0, 66, 16); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,0) facing 32; Engine Action #51; Warp Town -> Area 255 Map 1 Submap 46 at (0,8); Warp Room -> Submap 47 at (255,2) facing 58 |

---

### Submap Layer `vc13_06` (Index 6)

- **Map Number (`mapno`)**: `6`
- **Battle Encounter Zone (`batlno`)**: `2` (Timer: `90`, Rate: `4`)
- **Entity Count (`okaz`)**: `9` Objects | **Script Count (`evkaz`)**: `33` Scripts

#### Complete Physical Entity Inventory (9 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 19)** | `0` | `(114, 26)` | `0x0` | Frame 19 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 20)** | `0` | `(114, 26)` | `0x0` | Frame 20 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | World Device | **Mechanism (ano 5)** | `0` | `(0, 0)` | `0x0` | Frame 5 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | World Device | **Mechanism (ano 6)** | `0` | `(0, 0)` | `0x0` | Frame 6 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | World Device | **Mechanism (ano 49)** | `0` | `(24, 36)` | `0x0` | Frame 49 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[05]` | Trigger / Hitbox | **Hitbox Zone (3x6)** | `0` | `(25, 31)` | `2x5` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(40, 49)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(107, 160)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(31, 44)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(114, 26)` with state parameter `19`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(114, 26)` with state parameter `20`.
- **`obj[02]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(0, 0)` with state parameter `5`.
- **`obj[03]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(0, 0)` with state parameter `6`.
- **`obj[04]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(24, 36)` with state parameter `49`.
- **`obj[05]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `6` tiles high from `(25, 31)` to `(27, 36)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[06]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(40, 49)` to `(42, 51)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[07]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(107, 160)` to `(109, 162)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[08]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(31, 44)` to `(33, 46)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (33 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 8 (bit 1) SET | Open Choice Selection Menu (1, 255) |
| `ev[01]` | `2 (Map Init)` | Treasure Byte 0 Bit 64 FRESH (Unopened) | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[02]` | `2 (Map Init)` | Treasure Byte 0 Bit 64 LOOTED | Open Dialogue Message Window; Engine Action #9 |
| `ev[03]` | `2 (Map Init)` | Always Passes (Unconditional) | Make obj[2] Hidden (disp = 0); Screen Fade Transition (28, 35, 0); Screen Fade Transition (2, 11, 32); Start Boss Battle #0 (BGM: 11); Open Dialogue Message Window; Place Scenery Structure (47) |
| `ev[04]` | `2 (Map Init)` | Story Flag 30 (bit 1) SET | Make obj[1] Hidden (disp = 0); Screen Fade Transition (1, 11, 1); Place Scenery Structure (0); Display Dialogue Box [Bank: 47, MsgID: 255] |
| `ev[05]` | `128 (Loop)` | Story Flag 8 (bit 1) CLEAR AND Player within Box [29..35, 2..62] AND Condition Check #63 AND Story Flag 1 (mask 255) SET | Open Choice Selection Menu (1, 255) |
| `ev[06]` | `128 (Loop)` | Story Flag 8 (bit 1) CLEAR AND Player within Box [29..35, 2..64] AND Condition Check #65 AND Story Flag 0 (mask 255) SET | Open Choice Selection Menu (0, 255) |
| `ev[07]` | `128 (Loop)` | Story Flag 8 (bit 1) CLEAR AND Player within Box [52..53, 2..159] AND Condition Check #162 AND Story Flag 3 (mask 255) SET | Open Choice Selection Menu (1, 255) |
| `ev[08]` | `128 (Loop)` | Story Flag 8 (bit 1) CLEAR AND Player within Box [95..96, 2..159] AND Condition Check #162 AND Story Flag 2 (mask 255) SET | Open Choice Selection Menu (1, 255) |
| `ev[09]` | `128 (Loop)` | Story Flag 8 (bit 1) CLEAR AND Player within Box [50..51, 2..159] AND Condition Check #162 AND Story Flag 2 (mask 255) SET | Open Choice Selection Menu (0, 255) |
| `ev[10]` | `128 (Loop)` | Story Flag 8 (bit 1) CLEAR AND Player within Box [97..98, 2..159] AND Condition Check #162 AND Story Flag 3 (mask 255) SET | Open Choice Selection Menu (0, 255) |
| `ev[11]` | `128 (Loop)` | Story Flag 8 (bit 1) CLEAR AND Player within Box [52..53, 2..103] AND Condition Check #107 AND Story Flag 3 (mask 255) SET | Open Choice Selection Menu (1, 255) |
| `ev[12]` | `128 (Loop)` | Story Flag 8 (bit 1) CLEAR AND Player within Box [95..96, 2..103] AND Condition Check #107 AND Story Flag 2 (mask 255) SET | Open Choice Selection Menu (1, 255) |
| `ev[13]` | `128 (Loop)` | Story Flag 8 (bit 1) CLEAR AND Player within Box [50..51, 2..103] AND Condition Check #107 AND Story Flag 2 (mask 255) SET | Open Choice Selection Menu (0, 255) |
| `ev[14]` | `128 (Loop)` | Story Flag 8 (bit 1) CLEAR AND Player within Box [97..98, 2..103] AND Condition Check #107 AND Story Flag 3 (mask 255) SET | Open Choice Selection Menu (0, 255) |
| `ev[15]` | `128 (Loop)` | Temp Event Flag #1 SET AND Player within Box [70..78, 2..193] AND Condition Check #197 | Make obj[121] Hidden (disp = 0); Warp Room -> Submap 1 at (37,2) facing 47 |
| `ev[16]` | `128 (Loop)` | Temp Event Flag #1 SET AND Player within Box [98..102, 2..75] AND Condition Check #76 | Make obj[121] Hidden (disp = 0); Warp Room -> Submap 1 at (37,2) facing 47 |
| `ev[17]` | `128 (Loop)` | Temp Event Flag #2 SET AND Player within Box [97..103, 2..77] AND Condition Check #78 | Make obj[121] Hidden (disp = 0); Warp Town -> Area 36 Map 2 Submap 37 at (1,47) |
| `ev[18]` | `128 (Loop)` | Temp Event Flag #1 SET AND Player within Box [98..102, 2..65] AND Condition Check #66 | Make obj[121] Hidden (disp = 0); Warp Room -> Submap 1 at (37,2) facing 47 |
| `ev[19]` | `128 (Loop)` | Temp Event Flag #2 SET AND Player within Box [97..103, 2..63] AND Condition Check #64 | Make obj[121] Hidden (disp = 0); Warp Town -> Area 36 Map 2 Submap 37 at (1,47) |
| `ev[20]` | `1 (Action / Talk)` | Player within Box [105..111, 2..197] AND Condition Check #198 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 3, MsgID: 76]; Reset Camera Tracking (255) |
| `ev[21]` | `1 (Action / Talk)` | Player within Box [70..78, 2..197] AND Condition Check #198 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 3, MsgID: 42]; Reset Camera Tracking (255) |
| `ev[22]` | `1 (Action / Talk)` | Player within Box [0..1, 2..157] AND Condition Check #164 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 7, MsgID: 89]; Engine Action #120 |
| `ev[23]` | `1 (Action / Talk)` | Player within Box [150..151, 2..101] AND Condition Check #108 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 8, MsgID: 2]; Engine Action #94 |
| `ev[24]` | `1 (Action / Talk)` | Player within Box [150..151, 2..169] AND Condition Check #176 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 9, MsgID: 2]; Engine Action #132 |
| `ev[25]` | `1 (Action / Talk)` | Player within Box [29..35, 2..34] AND Condition Check #35 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 10, MsgID: 38]; Play CD / Ambient BGM Track (255) |
| `ev[26]` | `1 (Action / Talk)` | Story Flag 7 (bit 16) CLEAR AND Temp Event Flag #4 SET AND Target Inspected is obj[13] | Recruit Character into Active Party (43 [Ayda], 0); Exit to World Map (55, 0, 26); Award Potch Loot (+2,051 Potch); Open Dialogue Message Window; Warp Room -> Submap 1 at (95,0) facing West (Left); Engine Action #5; Warp Room -> Submap 4 at (1,3) facing 5; Show Dialogue Portrait (30, 73, 60); Engine Action #5; Warp Room -> Submap 0 at (5,4) facing South (Down); Open Dialogue Message Window; Dismiss Emotion Bubble (24); Warp Room -> Submap 26 at (73,15) facing 5; Warp Room -> Submap 4 at (0,3) facing 30; Warp Room -> Submap 34 at (36,4) facing 58 |
| `ev[27]` | `1 (Action / Talk)` | Story Flag 7 (bit 16) SET AND Story Flag 30 (bit 1) CLEAR AND Target Inspected is obj[13] | Recruit Character into Active Party (101 [Teresa], 0); Engine Action #176; Open Dialogue Message Window; Display Dialogue Box [Bank: 73, MsgID: 15]; Jump to Bytecode Offset (0, 177); Set Entity Movement Speed (2, 90); Screen Fade Transition (4, 2, 18); Warp to Castle HQ (30, 255, 254); Engine Action #90; Close Dialogue Window; Exit to World Map (2, 19, 3); Dismiss Emotion Bubble (255); Walk obj[101] to (5,177); Jump to Bytecode Offset (0, 178); Dismiss Emotion Bubble (1); Warp Town -> Area 1 Map 53 Submap 9 at (30,1); Engine Action #58 |
| `ev[28]` | `1 (Action / Talk)` | Treasure Byte 0 Bit 64 FRESH (Unopened) AND Target Inspected is obj[8] | Recruit Character into Active Party (46 [Oulan], 0); Engine Action #9; Warp Room -> Submap 47 at (101,4) facing 7; Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (0); Exit to World Map (0, 20, 16); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,0) facing 64; Engine Action #51; Warp Town -> Area 255 Map 1 Submap 46 at (0,8); Warp Room -> Submap 47 at (255,2) facing 58 |
| `ev[29]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Launch Tactical War Battle (8); Fade In from Black (2); Exit to World Map (73, 20, 40); Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 2 Map 2 Submap 2 at (3,73); Branch on Choice (41, 2); Open Dialogue Message Window; Warp Room -> Submap 0 at (54,0) facing 8; Recruit Invisible / Hitbox Trigger into Battle Slot 1; Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[30]` | `128 (Loop)` | Inventory Holds Item #8 [Fire Wall] | Warp Room -> Submap 0 at (13,44); Toggle Random Encounters (8) |
| `ev[31]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Open Dialogue Sub-Window (3); Open Dialogue Message Window |
| `ev[32]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Open Dialogue Sub-Window (3); Warp Room -> Submap 254 at (255,254) facing 204 |

---

### Submap Layer `vc13_07` (Index 7)

- **Map Number (`mapno`)**: `7`
- **Battle Encounter Zone (`batlno`)**: `2` (Timer: `90`, Rate: `4`)
- **Entity Count (`okaz`)**: `4` Objects | **Script Count (`evkaz`)**: `6` Scripts

#### Complete Physical Entity Inventory (4 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 19)** | `0` | `(34, 92)` | `0x0` | Frame 19 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 20)** | `0` | `(34, 92)` | `0x0` | Frame 20 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | World Device | **Mechanism (ano 5)** | `0` | `(0, 0)` | `0x0` | Frame 5 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | World Device | **Mechanism (ano 6)** | `0` | `(0, 0)` | `0x0` | Frame 6 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(34, 92)` with state parameter `19`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(34, 92)` with state parameter `20`.
- **`obj[02]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(0, 0)` with state parameter `5`.
- **`obj[03]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(0, 0)` with state parameter `6`.


#### Complete Bytecode Script Catalog (6 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 8 (bit 1) SET | Open Choice Selection Menu (1, 255) |
| `ev[01]` | `2 (Map Init)` | Treasure Byte 0 Bit 128 FRESH (Unopened) | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[02]` | `2 (Map Init)` | Treasure Byte 0 Bit 128 LOOTED | Open Dialogue Message Window; Engine Action #9 |
| `ev[03]` | `2 (Map Init)` | Always Passes (Unconditional) | Make obj[2] Hidden (disp = 0); Screen Fade Transition (31, 113, 0); Screen Fade Transition (2, 11, 37); Engine Action #113; Open Dialogue Message Window; Close Dialogue Window; Teleport obj[255] to (254,255) |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [90..91, 2..115] AND Condition Check #122 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 6, MsgID: 2]; Engine Action #162 |
| `ev[05]` | `1 (Action / Talk)` | Treasure Byte 0 Bit 128 FRESH (Unopened) AND Target Inspected is obj[8] | Recruit Character into Active Party (46 [Oulan], 0); Engine Action #9; Warp Room -> Submap 47 at (101,4) facing 7; Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (0); Exit to World Map (0, 92, 32); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,0) facing 128; Engine Action #51; Warp Town -> Area 255 Map 1 Submap 46 at (0,8); Warp Room -> Submap 47 at (255,2) facing 58 |

---

### Submap Layer `vc13_08` (Index 8)

- **Map Number (`mapno`)**: `8`
- **Battle Encounter Zone (`batlno`)**: `2` (Timer: `90`, Rate: `4`)
- **Entity Count (`okaz`)**: `1` Objects | **Script Count (`evkaz`)**: `6` Scripts

#### Complete Physical Entity Inventory (1 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 10)** | `0` | `(51, 21)` | `0x0` | Frame 10 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(51, 21)` with state parameter `10`.


#### Complete Bytecode Script Catalog (6 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 8 (bit 1) SET | Open Choice Selection Menu (1, 255) |
| `ev[01]` | `2 (Map Init)` | Always Passes (Unconditional) | Make obj[0] Hidden (disp = 0); Reset Camera Tracking (47) |
| `ev[02]` | `2 (Map Init)` | Always Passes (Unconditional) | Animate Door obj[2] (State: 12); Open Dialogue Message Window; Open Save Crystal Menu (MSaveInit); Open Shop Interface #255 |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [0..1, 2..93] AND Condition Check #100 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 6, MsgID: 149]; Engine Action #102 |
| `ev[04]` | `1 (Action / Talk)` | Story Flag 7 (bit 4) SET AND Story Flag 7 (bit 8) CLEAR AND Player within Box [52..52, 2..25] AND Condition Check #25 | Recruit Character into Active Party (44 [Killey], 46); Open Dialogue Message Window; Reset Camera Tracking (36); Warp Room -> Submap 0 at (1,47) facing 28; Warp Room -> Submap 5 at (28,2) facing West (Left); Engine Action #6; Display Chapter Text (0); Warp Room -> Submap 28 at (3,1) facing 6; Display Chapter Text (1); Warp Room -> Submap 28 at (3,1) facing 6; Display Chapter Text (0); Warp Room -> Submap 28 at (2,1) facing 6; Display Chapter Text (0); Warp Room -> Submap 28 at (2,1) facing 6; Display Chapter Text (1); Warp Room -> Submap 28 at (3,1) facing 6; Display Chapter Text (0); Warp Room -> Submap 28 at (3,1) facing 6; Display Chapter Text (1); Warp Room -> Submap 28 at (2,1) facing 6; Display Chapter Text (1); Warp Room -> Submap 28 at (2,1) facing 6; Display Chapter Text (0); Warp Room -> Submap 28 at (3,1) facing 6; Display Chapter Text (1); Warp Room -> Submap 28 at (3,1) facing 6; Display Chapter Text (0); Warp Room -> Submap 28 at (2,1) facing 6; Display Chapter Text (0); Warp Room -> Submap 28 at (2,1) facing 6; Display Chapter Text (1); Warp Room -> Submap 28 at (3,1) facing 6; Display Chapter Text (0); Warp Room -> Submap 28 at (3,1) facing 6; Display Chapter Text (1); Warp Room -> Submap 28 at (2,1) facing 6; Display Chapter Text (1); Warp Room -> Submap 28 at (2,1) facing 6; Display Chapter Text (0); Warp Room -> Submap 28 at (3,1) facing 6; Display Chapter Text (1); Warp Room -> Submap 28 at (3,1) facing 6; Display Chapter Text (0); Warp Room -> Submap 28 at (2,1) facing 6; Display Chapter Text (0); Warp Room -> Submap 28 at (2,1) facing 6; Display Chapter Text (1); Warp Room -> Submap 28 at (3,1) facing 6; Display Chapter Text (0); Warp Room -> Submap 28 at (3,1) facing 6; Display Chapter Text (1); Warp Room -> Submap 28 at (2,1) facing 6; Display Chapter Text (1); Warp Room -> Submap 28 at (2,1) facing 6; Display Chapter Text (0); Warp Room -> Submap 28 at (3,1) facing 6; Display Chapter Text (1); Warp Room -> Submap 28 at (3,1) facing 6; Display Chapter Text (0); Warp Room -> Submap 28 at (2,1) facing 6; Display Chapter Text (0); Warp Room -> Submap 28 at (2,1) facing 6; Display Chapter Text (1); Warp Room -> Submap 28 at (3,1) facing 6; Display Chapter Text (0); Warp Room -> Submap 28 at (3,1) facing 6; Display Chapter Text (1); Warp Room -> Submap 28 at (2,1) facing 6; Jump to Bytecode Offset (6, 66); Engine Action #54; Warp Room -> Submap 45 at (73,60) facing 101; Warp Room -> Submap 5 at (0,4) facing 4; Warp Town -> Area 0 Map 5 Submap 5 at (0,1); Warp Town -> Area 2 Map 30 Submap 33 at (1,95); Open Dialogue Message Window; Warp Room -> Submap 1 at (4,5) facing South (Down); Warp to Castle HQ (2, 0, 5); Trigger Character Emotion Effect (1, 0); Dismiss Emotion Bubble (24); Warp Room -> Submap 28 at (73,15) facing 49; Warp Town -> Area 5 Map 0 Submap 5 at (15,0); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp to Castle HQ (0, 30, 255); Engine Action #5; Warp Room -> Submap 5 at (1,3) facing 30; Warp Room -> Submap 255 at (254,50) facing 34; Engine Action #9; Pan Camera (8, 58, 255) |
| `ev[05]` | `128 (Loop)` | Story Flag 7 (bit 4) SET AND Story Flag 7 (bit 8) CLEAR AND Inventory Holds Item #1 [Medicine] AND Temp Event Flag #2 SET | Set Combat Battle BGM (40); Close Dialogue Window; Warp Room -> Submap 150 at (36,2) facing 255 |

---

### Submap Layer `vc13_09` (Index 9)

- **Map Number (`mapno`)**: `9`
- **Battle Encounter Zone (`batlno`)**: `2` (Timer: `90`, Rate: `4`)
- **Entity Count (`okaz`)**: `8` Objects | **Script Count (`evkaz`)**: `12` Scripts

#### Complete Physical Entity Inventory (8 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 19)** | `0` | `(63, 56)` | `0x0` | Frame 19 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 20)** | `0` | `(63, 56)` | `0x0` | Frame 20 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | World Device | **Mechanism (ano 19)** | `0` | `(73, 58)` | `0x0` | Frame 19 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | World Device | **Mechanism (ano 20)** | `0` | `(73, 58)` | `0x0` | Frame 20 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[04]` | World Device | **Mechanism (ano 5)** | `0` | `(0, 0)` | `0x0` | Frame 5 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[05]` | World Device | **Mechanism (ano 6)** | `0` | `(0, 0)` | `0x0` | Frame 6 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[06]` | World Device | **Mechanism (ano 45)** | `0` | `(71, 78)` | `0x0` | Frame 45 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Hitbox Zone (3x6)** | `0` | `(73, 73)` | `2x5` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(63, 56)` with state parameter `19`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(63, 56)` with state parameter `20`.
- **`obj[02]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(73, 58)` with state parameter `19`.
- **`obj[03]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(73, 58)` with state parameter `20`.
- **`obj[04]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(0, 0)` with state parameter `5`.
- **`obj[05]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(0, 0)` with state parameter `6`.
- **`obj[06]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(71, 78)` with state parameter `45`.
- **`obj[07]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `6` tiles high from `(73, 73)` to `(75, 78)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (12 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 8 (bit 1) SET | Open Choice Selection Menu (1, 255) |
| `ev[01]` | `2 (Map Init)` | Treasure Byte 1 Bit 1 FRESH (Unopened) | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[02]` | `2 (Map Init)` | Treasure Byte 1 Bit 2 FRESH (Unopened) | Open Dialogue Message Window; Screen Fade Transition (255, 254, 255) |
| `ev[03]` | `2 (Map Init)` | Treasure Byte 1 Bit 1 LOOTED | Open Dialogue Message Window; Engine Action #9 |
| `ev[04]` | `2 (Map Init)` | Treasure Byte 1 Bit 2 LOOTED | Open Dialogue Message Window; Close Dialogue Window |
| `ev[05]` | `2 (Map Init)` | Always Passes (Unconditional) | Make obj[2] Hidden (disp = 0); Display Dialogue Box [Bank: 64, MsgID: 77]; Open Dialogue Message Window; Display Dialogue Box [Bank: 2, MsgID: 13]; Play CD / Ambient BGM Track (77); Open Dialogue Message Window; Place Scenery Structure (0); Show Dialogue Portrait (47, 255, 254) |
| `ev[06]` | `2 (Map Init)` | Story Flag 30 (bit 1) SET | Make obj[2] Hidden (disp = 0); Display Dialogue Box [Bank: 63, MsgID: 77]; Open Dialogue Message Window; Display Dialogue Box [Bank: 2, MsgID: 13]; Wait for Audio / Window Sync (77); Open Dialogue Message Window; Place Scenery Structure (1); Show Dialogue Portrait (47, 255, 254) |
| `ev[07]` | `1 (Action / Talk)` | Player within Box [0..1, 2..124] AND Condition Check #138 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 6, MsgID: 149]; Engine Action #170 |
| `ev[08]` | `1 (Action / Talk)` | Story Flag 7 (bit 16) CLEAR AND Temp Event Flag #1 SET AND Target Inspected is obj[15] | Recruit Character into Active Party (43 [Ayda], 0); Exit to World Map (55, 0, 74); Remove Item from Inventory (8, 3); Open Dialogue Message Window; Warp Room -> Submap 1 at (95,0) facing West (Left); Engine Action #5; Warp Room -> Submap 4 at (1,3) facing 5; Show Dialogue Portrait (30, 73, 60); Engine Action #5; Warp Room -> Submap 0 at (5,4) facing South (Down); Open Dialogue Message Window; Dismiss Emotion Bubble (24); Warp Room -> Submap 26 at (73,15) facing 5; Warp Room -> Submap 4 at (0,3) facing 30; Warp Room -> Submap 34 at (58,36) facing West (Left) |
| `ev[09]` | `1 (Action / Talk)` | Story Flag 7 (bit 16) SET AND Temp Event Flag #1 SET AND Target Inspected is obj[15] | Recruit Character into Active Party (0, 14); Jump to Bytecode Offset (0, 176); Recruit Character into Active Party (101 [Teresa], 0); Engine Action #177; Set Entity Movement Speed (2, 90); Display Dialogue Box [Bank: 4, MsgID: 2]; Display Speaker Name Box (3); Dismiss Emotion Bubble (255); Engine Action #90; Place Scenery Structure (4); Warp Town -> Area 19 Map 3 Submap 30 at (255,254); Walk obj[101] to (5,177); Jump to Bytecode Offset (0, 178); Set Combat Battle BGM (15); Warp Room -> Submap 58 at (36,1) facing 255 |
| `ev[10]` | `1 (Action / Talk)` | Treasure Byte 1 Bit 1 FRESH (Unopened) AND Target Inspected is obj[8] | Recruit Character into Active Party (46 [Oulan], 0); Engine Action #9; Warp Room -> Submap 47 at (101,4) facing 7; Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (0); Exit to World Map (0, 93, 32); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,1) facing West (Left); Engine Action #51; Warp Town -> Area 255 Map 1 Submap 46 at (0,8); Warp Room -> Submap 47 at (255,2) facing 58 |
| `ev[11]` | `1 (Action / Talk)` | Treasure Byte 1 Bit 2 FRESH (Unopened) AND Target Inspected is obj[10] | Recruit Character into Active Party (46 [Oulan], 0); Close Dialogue Window; Warp Room -> Submap 47 at (101,4) facing 7; Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (0); Exit to World Map (0, 2, 80); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,1) facing Up (North); Engine Action #51; Warp Town -> Area 255 Map 1 Submap 46 at (0,10); Warp Room -> Submap 47 at (255,2) facing 58 |

---

### Submap Layer `vc13_10` (Index 10)

- **Map Number (`mapno`)**: `10`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `3` Objects | **Script Count (`evkaz`)**: `6` Scripts

#### Complete Physical Entity Inventory (3 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 5)** | `0` | `(0, 0)` | `0x0` | Frame 5 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 6)** | `0` | `(0, 0)` | `0x0` | Frame 6 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | Trigger / Hitbox | **Hitbox Zone (3x6)** | `0` | `(43, 25)` | `2x5` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(0, 0)` with state parameter `5`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(0, 0)` with state parameter `6`.
- **`obj[02]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `6` tiles high from `(43, 25)` to `(45, 30)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (6 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 7 (bit 32) CLEAR | Make obj[2] Hidden (disp = 0); Reset Camera Tracking (34); Display Emotion Bubble (0, 8); Warp Town -> Area 9 Map 38 Submap 29 at (0,9); Open Dialogue Message Window; Screen Fade Transition (47, 255, 254) |
| `ev[01]` | `2 (Map Init)` | Always Passes (Unconditional) | Animate Door obj[2] (State: 12); Open Dialogue Message Window; Open Save Crystal Menu (MSaveInit); Open Shop Interface #255 |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [36..40, 2..71] AND Condition Check #72 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 6, MsgID: 32]; Open Save Crystal Menu (MSaveInit) |
| `ev[03]` | `128 (Loop)` | Player within Box [38..38, 2..68] AND Condition Check #68 | Warp Room -> Submap 0 at (2,13) |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [36..40, 2..28] AND Condition Check #29 AND Story Flag 1 (mask 255) SET | Warp Room -> Submap 0 at (2,13); Warp Map Transition (3, 0, 40, 88, 255) |
| `ev[05]` | `1 (Action / Talk)` | Story Flag 7 (bit 16) SET AND Story Flag 7 (bit 32) CLEAR AND Target Inspected is obj[10] | Recruit Character into Active Party (43 [Ayda], 0); Exit to World Map (55, 0, 44); Return Warp to Castle Base (8, 3); Open Dialogue Message Window; Warp Room -> Submap 3 at (95,18) facing 80; Make obj[0] Hidden (disp = 0); Warp Room -> Submap 2 at (0,3) facing South (Down); Exit to World Map (0, 5, 0); Engine Action #6; Teleport obj[49] to (6,5); Warp Room -> Submap 5 at (1,3) facing 5; Show Dialogue Portrait (30, 255, 254); Engine Action #5; Warp Town -> Area 4 Map 5 Submap 3 at (2,1); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Warp to Castle HQ (4, 5, 2); Warp Town -> Area 1 Map 0 Submap 30 at (255,254); Engine Action #5; Exit to World Map (4, 5, 3); Exit to World Map (1, 0, 30); Engine Action #5; Engine Action #5; Exit to World Map (5, 2, 4); Warp Room -> Submap 30 at (255,254) facing 5; Engine Action #6; Exit to World Map (5, 2, 6); Warp Room -> Submap 30 at (255,254) facing 50; Engine Action #5; Warp Room -> Submap 60 at (2,0) facing 5; Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Screen Fade Transition (30, 24, 1); Open Dialogue Message Window; Trigger Character Emotion Effect (73, 15); Close Dialogue Sub-Window (2); Open Dialogue Message Window; Engine Action #61; Set Combat Battle BGM (15); Close Dialogue Sub-Window (1); Open Dialogue Message Window; Engine Action #62; Engine Action #5; Warp Room -> Submap 15 at (2,0) facing 5; Engine Action #5; Warp Room -> Submap 5 at (30,30) facing 24; Warp Room -> Submap 63 at (5,2) facing 5; Trigger Character Emotion Effect (2, 0); Engine Action #5; Show Dialogue Portrait (30, 24, 2); Open Dialogue Message Window; Animate Doorway State (5, 0); Engine Action #5; Engine Action #5; Warp to Castle HQ (0, 5, 5); Dismiss Emotion Bubble (5); Warp to Castle HQ (3, 0, 5); Show Dialogue Portrait (30, 24, 3); Open Dialogue Message Window; Play Sound Effect (SE) (73); Show Dialogue Portrait (73, 20, 40); Open Dialogue Message Window; Open Dialogue Message Window; Warp to Castle HQ (0, 66, 0); Open Shop Interface #0; Play CD / Ambient BGM Track (73); Show Dialogue Portrait (41, 3, 0); Warp Room -> Submap 255 at (0,24) facing East (Right); Open Dialogue Message Window; Wait for Audio / Window Sync (51); Warp to Castle HQ (255, 1, 24); Warp to Castle HQ (0, 70, 51); Warp to Castle HQ (255, 2, 24); Warp to Castle HQ (0, 71, 255); Warp to Castle HQ (5, 1, 5); Show Dialogue Portrait (2, 0, 5); Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 24, 1); Open Dialogue Message Window; Load Sound Bank into Memory (49, 4); Engine Action #5; Warp Room -> Submap 15 at (2,0) facing 5; Engine Action #5; Warp Room -> Submap 5 at (100,30) facing 255; Engine Action #5; Open Dialogue Message Window; Engine Action #5; Dismiss Emotion Bubble (1); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Warp Town -> Area 5 Map 40 Submap 1 at (0,30); Engine Action #5; Warp to Castle HQ (5, 50, 1); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Walk obj[101] to (0,176); Make obj[101] Visible (disp = 1); Open Dialogue Message Window; Engine Action #177; Set Entity Movement Speed (2, 90); Reset Camera Tracking (4); Warp Town -> Area 18 Map 3 Submap 30 at (255,254); Engine Action #90; Engine Action #9; Exit to World Map (2, 19, 3); Dismiss Emotion Bubble (255); Walk obj[101] to (5,177); Jump to Bytecode Offset (0, 178); Close Dialogue Sub-Window (1); Warp Room -> Submap 73 at (15,39) facing 34; Engine Action #58; Engine Action #9; Pan Camera (32, 255, 254) |

---


