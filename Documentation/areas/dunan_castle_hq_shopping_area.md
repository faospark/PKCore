# Suikoden II Geographic Area Catalog: Castle HQ: Shopping Area (Commercial Wing & Shops)

**Geographic Scope & Role**: Castle commercial wing and shop facilities; Hans's Armor Shop, Jeane's Rune Shop, Lebrante's Appraisal, Tessai's Blacksmith Forge, Raura's Scroll Shop, Gordon's Trade Post, and Templeton's Room.

**Regional Category**: Region `VK` | **Master Maps Included**: `vk02`

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

## Location Map: `vk02`

- **Master Map Container**: `vk02.json`
- **Submap Layer Files**: vk02_11.json
- **Collision Grid Files**: vk02_map_00.json, vk02_map_01.json, vk02_map_02.json, vk02_map_03.json, vk02_map_04.json, vk02_map_05.json, vk02_map_06.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 13

### Submap Layer `vk02_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `2` Objects | **Script Count (`evkaz`)**: `15` Scripts

#### Complete Physical Entity Inventory (2 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 65105** | `65105` | `(32, 39)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Actor ID 65105** | `65105` | `(60, 39)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 65105)**: Positioned at tile `(32, 39)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Object 65105)**: Positioned at tile `(60, 39)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.


#### Complete Bytecode Script Catalog (15 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `128 (Loop)` | Player within Box [22..70, 2..37] AND Condition Check #52 AND Story Flag 144 (bit 32) CLEAR | Warp Room -> Submap 0 at (10,0) |
| `ev[01]` | `128 (Loop)` | Player within Box [22..70, 2..37] AND Condition Check #52 AND Story Flag 144 (bit 32) SET | Warp Room -> Submap 0 at (10,33) |
| `ev[02]` | `128 (Loop)` | Player within Box [22..70, 2..28] AND Condition Check #36 | Warp Room -> Submap 0 at (10,5) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [42..50, 2..56] AND Condition Check #57 AND Story Flag 0 (mask 255) SET | Engine Action #111; Award Potch Loot (+1,280 Potch); Warp Room -> Submap 3 at (4,255) facing South (Down); Warp Room -> Submap 3 at (2,84) facing 15; Warp Town -> Area 32 Map 3 Submap 1 at (84,15); Warp to Castle HQ (255, 4, 32); Warp to Castle HQ (0, 84, 15) |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [42..50, 2..25] AND Condition Check #26 AND Story Flag 1 (mask 255) SET | Warp Map Transition (3, 0, 58, 97, 255) |
| `ev[05]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [1..255] | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[06]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [3..255] | Open Dialogue Message Window; Engine Action #9 |
| `ev[07]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[8] | Close Dialogue Sub-Window (8); Engine Action #9; Open Dialogue Message Window |
| `ev[08]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[8] | Close Dialogue Sub-Window (8); Screen Fade Transition (0, 255, 254) |
| `ev[09]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[8] | Close Dialogue Sub-Window (8); Close Dialogue Window; Open Dialogue Message Window |
| `ev[10]` | `1 (Action / Talk)` | Target Inspected is obj[8] | Close Dialogue Sub-Window (8); Warp to Castle HQ (0, 255, 254) |
| `ev[11]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[9] | Close Dialogue Sub-Window (9); Engine Action #9; Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[12]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[9] | Close Dialogue Sub-Window (9); Screen Fade Transition (1, 255, 254) |
| `ev[13]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[9] | Close Dialogue Sub-Window (9); Close Dialogue Window; Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[14]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Close Dialogue Sub-Window (9); Warp to Castle HQ (1, 255, 254) |

---

### Submap Layer `vk02_01` (Index 1)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `20` Objects | **Script Count (`evkaz`)**: `62` Scripts

#### Complete Physical Entity Inventory (20 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(38, 98)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[01]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(25, 37)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(29, 37)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(33, 37)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(25, 41)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(29, 41)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(33, 41)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Hitbox Zone (5x5)** | `0` | `(26, 114)` | `4x4` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(36, 22)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | NPC / Actor | **Actor ID 65105** | `65105` | `(36, 38)` | `0x0` | Up (North) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[10]` | NPC / Actor | **Actor ID 65105** | `65105` | `(32, 49)` | `3x3` | Up (North) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[11]` | NPC / Actor | **Actor ID 65085** | `65085` | `(45, 30)` | `3x3` | Up (North) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[12]` | NPC / Actor | **Actor ID 65073** | `65073` | `(45, 100)` | `3x3` | Up (North) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[13]` | NPC / Actor | **Actor ID 86** | `86` | `(46, 29)` | `4x10` | South (Down) | Dormant / Hidden (0) | Special (3) | 4 | 128 | 0 |
| `obj[14]` | NPC / Actor | **Actor ID 107** | `107` | `(29, 32)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[15]` | NPC / Actor | **Tuta** | `71` | `(27, 41)` | `5x2` | East (Right) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[16]` | Trigger / Hitbox | **Hitbox Zone (5x2)** | `0` | `(27, 33)` | `4x1` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[17]` | Rest Device / Fire | **Inn Bed / Recovery Device** | `0` | `(34, 66)` | `0x0` | Frame 30 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 180 |
| `obj[18]` | Rest Device / Fire | **Inn Bed / Recovery Device** | `0` | `(40, 68)` | `0x0` | Frame 29 | Visible (1) | Solid (Obstacle) | 4 | 255 | 180 |
| `obj[19]` | World Device | **Mechanism (ano 28)** | `0` | `(40, 64)` | `0x0` | Frame 28 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 180 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(38, 98)` to `(40, 100)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[01]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(25, 37)` to `(26, 38)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[02]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(29, 37)` to `(30, 38)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[03]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(33, 37)` to `(34, 38)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[04]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(25, 41)` to `(26, 42)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[05]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(29, 41)` to `(30, 42)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[06]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(33, 41)` to `(34, 42)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[07]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `5` tiles high from `(26, 114)` to `(30, 118)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[08]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(36, 22)` to `(37, 23)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[09]` (Object 65105)**: Positioned at tile `(36, 38)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[10]` (Object 65105)**: Positioned at tile `(32, 49)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[11]` (Object 65085)**: Positioned at tile `(45, 30)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[12]` (Object 65073)**: Positioned at tile `(45, 100)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[13]` (Object 86)**: Positioned at tile `(46, 29)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[14]` (Object 107)**: Positioned at tile `(29, 32)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[15]` (Tuta)**: Positioned at tile `(27, 41)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[16]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `2` tiles high from `(27, 33)` to `(31, 34)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[17]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(34, 66)` with state parameter `30`.
- **`obj[18]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(40, 68)` with state parameter `29`.
- **`obj[19]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(40, 64)` with state parameter `28`.


#### Complete Bytecode Script Catalog (62 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Condition Check #33 AND Always Passes (Unconditional) AND Player X within Range [255..254] | Make obj[0] Hidden (disp = 0); Clear Dialogue Sub-Window; Open Dialogue Message Window; Fade Out to Black (1); Fade In from Black (47) |
| `ev[01]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #86 AND Player within Box [33..0, 1..255] | Open Dialogue Message Window; Execute Choice Result (255) |
| `ev[02]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #107 AND Player X within Range [255..254] | Make obj[0] Hidden (disp = 0); Set Story Flag (47, 255) |
| `ev[03]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #107 AND Player X within Range [255..254] | Make obj[0] Hidden (disp = 0); Close Dialogue Sub-Window (47) |
| `ev[04]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #86 AND Player within Box [5..21, 255..254] | Engine Action #99; Change Portrait Expression (8); Engine Action #99; Dismiss Dialogue Portrait; Exit to World Map (24, 21, 12); Open Dialogue Message Window; Set Combat Battle BGM (20); Engine Action #127; Open Dialogue Message Window; Dismiss Dialogue Portrait; Exit to World Map (70, 0, 1); Mark NPC Talk Interaction Complete (Flag #17); Reset Camera Tracking (255) |
| `ev[05]` | `128 (Loop)` | Condition Check #23 AND Condition Check #86 AND Player within Box [29..16, 4..255] | Warp Room -> Submap 0 at (13,79); Mark NPC Talk Interaction Complete (Flag #16); Exit to World Map (255, 254, 204) |
| `ev[06]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Condition Check #23 AND Condition Check #107 AND Player within Box [5..22, 255..254] | Clear Story Milestone Flag 34 (mask 22); Engine Action #240; Engine Action #240; Exit to World Map (0, 3, 1); Open Dialogue Message Window; Open Dialogue Message Window |
| `ev[07]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Condition Check #23 AND Condition Check #107 AND Player within Box [5..24, 255..254] | Warp to Castle HQ (22, 0, 96); Return Warp to Castle Base (22, 240); Engine Action #240; Exit to World Map (0, 3, 1); Open Dialogue Message Window; Open Dialogue Message Window |
| `ev[08]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Condition Check #23 AND Condition Check #107 AND Player within Box [5..22, 255..254] | Clear Story Milestone Flag 34 (mask 22); Engine Action #240; Engine Action #240; Engine Action #5; Open Dialogue Message Window; Warp to Castle HQ (1, 0, 0) |
| `ev[09]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Condition Check #23 AND Condition Check #107 AND Player within Box [5..24, 255..254] | Warp to Castle HQ (22, 0, 96); Return Warp to Castle Base (22, 240); Engine Action #240; Engine Action #5; Open Dialogue Message Window; Warp to Castle HQ (1, 0, 0) |
| `ev[10]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Condition Check #23 AND Condition Check #107 AND Player within Box [5..22, 255..254] | Clear Story Milestone Flag 34 (mask 22); Engine Action #240; Engine Action #240; Engine Action #6; Open Dialogue Message Window; Warp to Castle HQ (1, 0, 0) |
| `ev[11]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Condition Check #23 AND Condition Check #107 AND Player within Box [5..24, 255..254] | Warp to Castle HQ (22, 0, 96); Return Warp to Castle Base (22, 240); Engine Action #240; Engine Action #6; Open Dialogue Message Window; Warp to Castle HQ (1, 0, 0) |
| `ev[12]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Condition Check #23 AND Condition Check #107 AND Player within Box [5..22, 255..254] | Clear Story Milestone Flag 34 (mask 22); Engine Action #240; Engine Action #240; Pan Camera (0, 3, 1); Open Dialogue Message Window; Open Dialogue Message Window |
| `ev[13]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Condition Check #23 AND Condition Check #107 AND Player within Box [5..24, 255..254] | Warp to Castle HQ (22, 0, 96); Return Warp to Castle Base (22, 240); Engine Action #240; Pan Camera (0, 3, 1); Open Dialogue Message Window; Open Dialogue Message Window |
| `ev[14]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Condition Check #23 AND Condition Check #107 AND Player within Box [5..22, 255..254] | Clear Story Milestone Flag 34 (mask 22); Engine Action #240; Engine Action #240; Reset Camera Tracking (0); Warp to Castle HQ (1, 0, 0) |
| `ev[15]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Condition Check #23 AND Condition Check #107 AND Player within Box [5..24, 255..254] | Warp to Castle HQ (22, 0, 96); Return Warp to Castle Base (22, 240); Engine Action #240; Reset Camera Tracking (0); Warp to Castle HQ (1, 0, 0) |
| `ev[16]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #107 AND Player within Box [5..22, 255..254] | Clear Story Milestone Flag 34 (mask 22); Engine Action #240; Engine Action #240; Open Dialogue Message Window; Open Dialogue Message Window; Warp to Castle HQ (1, 0, 0) |
| `ev[17]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #107 AND Player within Box [5..24, 255..254] | Warp to Castle HQ (22, 0, 96); Return Warp to Castle Base (22, 240); Engine Action #240; Open Dialogue Message Window; Open Dialogue Message Window; Warp to Castle HQ (1, 0, 0) |
| `ev[18]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #71 AND Player within Box [34..4, 16..33] AND Player X within Range [3..255] | Make obj[0] Hidden (disp = 0); Open Dialogue Sub-Window (47) |
| `ev[19]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[23] | Open Dialogue Sub-Window (4); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[20]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[23] | Open Dialogue Sub-Window (5); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[21]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[23] | Open Dialogue Sub-Window (6); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[22]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[23] | Open Dialogue Sub-Window (7); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[23]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[23] | Open Dialogue Sub-Window (8); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[24]` | `1 (Action / Talk)` | Target Inspected is obj[23] | Open Dialogue Sub-Window (0); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[25]` | `128 (Loop)` | Player within Box [34..49, 2..23] AND Condition Check #59 AND Condition Check #30 AND Star of Destiny #8 Not Yet Recruited AND Story Flag 144 (bit 32) CLEAR | Warp Room -> Submap 0 at (10,0) |
| `ev[26]` | `128 (Loop)` | Player within Box [34..49, 2..23] AND Condition Check #59 AND Condition Check #30 AND Star of Destiny #8 Not Yet Recruited AND Story Flag 144 (bit 32) SET | Warp Room -> Submap 0 at (10,33) |
| `ev[27]` | `1 (Action / Talk)` | Player within Box [50..51, 2..34] AND Condition Check #40 AND Story Flag 3 (mask 255) SET | Engine Action #111; Award Potch Loot (+1,280 Potch); Warp Room -> Submap 3 at (4,255) facing South (Down); Warp Room -> Submap 3 at (2,77) facing 35; Warp Town -> Area 32 Map 3 Submap 1 at (77,35); Warp to Castle HQ (255, 4, 32); Warp to Castle HQ (0, 77, 35) |
| `ev[28]` | `1 (Action / Talk)` | Player within Box [42..46, 2..65] AND Condition Check #70 AND Story Flag 0 (mask 33) SET AND Always Passes (Unconditional) AND Player X within Range [255..254] | Warp Map Transition (3, 2, 68, 40, 255) |
| `ev[29]` | `1 (Action / Talk)` | Player within Box [28..32, 2..19] AND Treasure Byte 9 Bit 2 LOOTED | Display Dialogue Box [Bank: 1, MsgID: 27]; Clear Story Milestone Flag 255 (mask 254) |
| `ev[30]` | `1 (Action / Talk)` | Player within Box [29..30, 2..94] AND Condition Check #98 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 35]; Clear Dialogue Sub-Window |
| `ev[31]` | `1 (Action / Talk)` | Player within Box [34..36, 2..59] AND Condition Check #68 AND Story Flag 2 (mask 23) SET AND Condition Check #116 AND Player Y within Range [33..1] AND Player Y within Range [255..254] | Display Dialogue Box [Bank: 3, MsgID: 27]; Warp Map Transition (255, 254, 204, 204, 204) |
| `ev[32]` | `1 (Action / Talk)` | Player within Box [34..36, 2..59] AND Condition Check #68 AND Story Flag 2 (mask 33) SET AND Player within Box [2..24, 116..2] | Display Dialogue Box [Bank: 4, MsgID: 89]; Warp Map Transition (255, 254, 204, 204, 204) |
| `ev[33]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [2..255] | Open Dialogue Message Window; Change Portrait Expression (255) |
| `ev[34]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [3..255] | Open Dialogue Message Window; Display Speaker Name Box (255) |
| `ev[35]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [3..255] | Open Dialogue Message Window; Display Choice Selection (255, 254) |
| `ev[36]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [4..255] | Open Dialogue Message Window; Branch on Choice (255, 254) |
| `ev[37]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[17] | Close Dialogue Sub-Window (17); Engine Action #9; Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[38]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[17] | Close Dialogue Sub-Window (17); Screen Fade Transition (2, 255, 254) |
| `ev[39]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[17] | Close Dialogue Sub-Window (17); Close Dialogue Window; Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[40]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Close Dialogue Sub-Window (17); Warp to Castle HQ (2, 255, 254) |
| `ev[41]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[18] | Close Dialogue Sub-Window (18); Engine Action #9; Warp to Castle HQ (255, 254, 204) |
| `ev[42]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[18] | Close Dialogue Sub-Window (18); Screen Fade Transition (3, 255, 254) |
| `ev[43]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[18] | Close Dialogue Sub-Window (18); Close Dialogue Window; Warp to Castle HQ (255, 254, 204) |
| `ev[44]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Close Dialogue Sub-Window (18); Warp to Castle HQ (3, 255, 254) |
| `ev[45]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[19] | Close Dialogue Sub-Window (19); Engine Action #9; Exit to World Map (255, 254, 204) |
| `ev[46]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[19] | Close Dialogue Sub-Window (19); Screen Fade Transition (4, 255, 254) |
| `ev[47]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[19] | Close Dialogue Sub-Window (19); Close Dialogue Window; Exit to World Map (255, 254, 204) |
| `ev[48]` | `1 (Action / Talk)` | Target Inspected is obj[19] | Close Dialogue Sub-Window (19); Warp to Castle HQ (4, 255, 254) |
| `ev[49]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[20] | Close Dialogue Sub-Window (20); Engine Action #9; Engine Action #5 |
| `ev[50]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[20] | Close Dialogue Sub-Window (20); Screen Fade Transition (5, 255, 254) |
| `ev[51]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[20] | Close Dialogue Sub-Window (20); Close Dialogue Window; Engine Action #5 |
| `ev[52]` | `1 (Action / Talk)` | Target Inspected is obj[20] | Close Dialogue Sub-Window (20); Warp to Castle HQ (5, 255, 254) |
| `ev[53]` | `1 (Action / Talk)` | Target Inspected is obj[8] | Open Dialogue Sub-Window (1); Open Dialogue Message Window |
| `ev[54]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Open Dialogue Sub-Window (1); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[55]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Open Dialogue Sub-Window (1); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[56]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Open Dialogue Sub-Window (1); Warp to Castle HQ (255, 254, 204) |
| `ev[57]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Open Dialogue Sub-Window (1); Exit to World Map (255, 254, 204) |
| `ev[58]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Open Dialogue Sub-Window (1); Engine Action #5 |
| `ev[59]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Open Dialogue Sub-Window (1); Engine Action #6 |
| `ev[60]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Open Dialogue Sub-Window (1); Pan Camera (255, 254, 204) |
| `ev[61]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Open Dialogue Sub-Window (1); Reset Camera Tracking (255) |

---

### Submap Layer `vk02_02` (Index 2)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `14` Objects | **Script Count (`evkaz`)**: `24` Scripts

#### Complete Physical Entity Inventory (14 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 65105** | `65105` | `(107, 29)` | `3x3` | Up (North) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 31)** | `0` | `(98, 66)` | `0x0` | Frame 31 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 180 |
| `obj[02]` | Rest Device / Fire | **Inn Bed / Recovery Device** | `0` | `(104, 68)` | `0x0` | Frame 29 | Visible (1) | Solid (Obstacle) | 4 | 255 | 180 |
| `obj[03]` | World Device | **Mechanism (ano 28)** | `0` | `(104, 64)` | `0x0` | Frame 28 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 180 |
| `obj[04]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(38, 98)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(25, 37)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(29, 37)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(33, 37)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(25, 41)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(29, 41)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(33, 41)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Trigger / Hitbox | **Hitbox Zone (5x5)** | `0` | `(26, 114)` | `4x4` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(36, 22)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | NPC / Actor | **Actor ID 86** | `86` | `(108, 29)` | `4x10` | South (Down) | Dormant / Hidden (0) | Special (3) | 4 | 128 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 65105)**: Positioned at tile `(107, 29)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(98, 66)` with state parameter `31`.
- **`obj[02]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(104, 68)` with state parameter `29`.
- **`obj[03]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(104, 64)` with state parameter `28`.
- **`obj[04]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(38, 98)` to `(40, 100)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[05]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(25, 37)` to `(26, 38)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[06]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(29, 37)` to `(30, 38)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[07]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(33, 37)` to `(34, 38)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[08]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(25, 41)` to `(26, 42)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[09]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(29, 41)` to `(30, 42)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[10]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(33, 41)` to `(34, 42)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[11]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `5` tiles high from `(26, 114)` to `(30, 118)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[12]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(36, 22)` to `(37, 23)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[13]` (Object 86)**: Positioned at tile `(108, 29)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.


#### Complete Bytecode Script Catalog (24 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Condition Check #33 AND Always Passes (Unconditional) AND Player X within Range [255..254] | Make obj[0] Hidden (disp = 0); Engine Action #9; Open Dialogue Message Window; Close Dialogue Window; Warp Room -> Submap 47 at (255,254) facing 204 |
| `ev[01]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #86 AND Player within Box [33..0, 1..255] | Open Dialogue Message Window; Execute Choice Result (255) |
| `ev[02]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #86 AND Player within Box [5..21, 255..254] | Engine Action #99; Change Portrait Expression (8); Engine Action #99; Dismiss Dialogue Portrait; Exit to World Map (24, 21, 12); Open Dialogue Message Window; Set Combat Battle BGM (20); Engine Action #127; Open Dialogue Message Window; Dismiss Dialogue Portrait; Exit to World Map (70, 0, 1); Mark NPC Talk Interaction Complete (Flag #17); Reset Camera Tracking (255) |
| `ev[03]` | `128 (Loop)` | Condition Check #23 AND Condition Check #86 AND Player within Box [29..16, 4..255] | Warp Room -> Submap 0 at (13,79); Mark NPC Talk Interaction Complete (Flag #16); Exit to World Map (255, 254, 204) |
| `ev[04]` | `128 (Loop)` | Player within Box [86..114, 2..24] AND Condition Check #58 AND Condition Check #30 AND Star of Destiny #8 Not Yet Recruited AND Story Flag 144 (bit 32) CLEAR | Warp Room -> Submap 0 at (10,0) |
| `ev[05]` | `128 (Loop)` | Player within Box [86..114, 2..24] AND Condition Check #58 AND Condition Check #30 AND Star of Destiny #8 Not Yet Recruited AND Story Flag 144 (bit 32) SET | Warp Room -> Submap 0 at (10,33) |
| `ev[06]` | `1 (Action / Talk)` | Player within Box [114..115, 2..33] AND Condition Check #41 AND Story Flag 3 (mask 255) SET | Engine Action #111; Award Potch Loot (+1,280 Potch); Warp Room -> Submap 3 at (4,255) facing South (Down); Warp Room -> Submap 3 at (2,77) facing 35; Warp Town -> Area 32 Map 3 Submap 1 at (77,35); Warp to Castle HQ (255, 4, 32); Warp to Castle HQ (0, 77, 35) |
| `ev[07]` | `1 (Action / Talk)` | Player within Box [106..110, 2..65] AND Condition Check #70 AND Story Flag 0 (mask 33) SET AND Always Passes (Unconditional) AND Player X within Range [255..254] | Warp Map Transition (3, 2, 68, 40, 255) |
| `ev[08]` | `1 (Action / Talk)` | Player within Box [99..100, 2..58] AND Condition Check #68 AND Story Flag 2 (mask 33) SET AND Player within Box [2..23, 116..2] | Display Dialogue Box [Bank: 3, MsgID: 27]; Warp Map Transition (255, 254, 204, 204, 204) |
| `ev[09]` | `1 (Action / Talk)` | Player within Box [99..100, 2..58] AND Condition Check #68 AND Story Flag 2 (mask 33) SET AND Player within Box [2..24, 116..2] | Display Dialogue Box [Bank: 4, MsgID: 89]; Warp Map Transition (255, 254, 204, 204, 204) |
| `ev[10]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [3..255] | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[11]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[8] | Close Dialogue Sub-Window (8); Engine Action #9; Engine Action #6 |
| `ev[12]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[8] | Close Dialogue Sub-Window (8); Screen Fade Transition (6, 255, 254) |
| `ev[13]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[8] | Close Dialogue Sub-Window (8); Close Dialogue Window; Engine Action #6 |
| `ev[14]` | `1 (Action / Talk)` | Target Inspected is obj[8] | Close Dialogue Sub-Window (8); Warp to Castle HQ (6, 255, 254) |
| `ev[15]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Open Dialogue Sub-Window (1); Engine Action #9 |
| `ev[16]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Open Dialogue Sub-Window (1); Screen Fade Transition (255, 254, 204) |
| `ev[17]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Open Dialogue Sub-Window (1); Close Dialogue Window |
| `ev[18]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Open Dialogue Sub-Window (1); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[19]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Open Dialogue Sub-Window (1); Place Scenery Structure (255) |
| `ev[20]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Open Dialogue Sub-Window (1); Animate Door Open |
| `ev[21]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Open Dialogue Sub-Window (1); Show Dialogue Portrait (255, 254, 204) |
| `ev[22]` | `1 (Action / Talk)` | Target Inspected is obj[19] | Open Dialogue Sub-Window (1); Dismiss Dialogue Portrait |
| `ev[23]` | `1 (Action / Talk)` | Target Inspected is obj[20] | Open Dialogue Sub-Window (1); Change Portrait Expression (255) |

---

### Submap Layer `vk02_03` (Index 3)

- **Map Number (`mapno`)**: `2`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `7` Objects | **Script Count (`evkaz`)**: `39` Scripts

#### Complete Physical Entity Inventory (7 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 116** | `116` | `(50, 38)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | Trigger / Hitbox | **Hitbox Zone (5x2)** | `0` | `(48, 39)` | `4x1` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Actor ID 67** | `67` | `(24, 47)` | `7x2` | East (Right) | Dormant / Hidden (0) | Special (3) | 6 | 128 | 0 |
| `obj[03]` | NPC / Actor | **Karen** | `14` | `(47, 41)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[04]` | Trigger / Hitbox | **Hitbox Zone (4x3)** | `0` | `(51, 46)` | `3x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(38, 35)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | Trigger / Hitbox | **Hitbox Zone (4x3)** | `0` | `(30, 35)` | `3x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 116)**: Positioned at tile `(50, 38)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `2` tiles high from `(48, 39)` to `(52, 40)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[02]` (Object 67)**: Positioned at tile `(24, 47)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Karen)**: Positioned at tile `(47, 41)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `3` tiles high from `(51, 46)` to `(54, 48)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[05]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(38, 35)` to `(39, 36)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[06]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `3` tiles high from `(30, 35)` to `(33, 37)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (39 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #116 AND Player X within Range [255..254] | Make obj[0] Hidden (disp = 0); Reset Camera Tracking (47) |
| `ev[01]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #116 AND Player X within Range [255..254] | Make obj[0] Hidden (disp = 0); Engine Action #9; Teleport obj[255] to (254,204) |
| `ev[02]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Condition Check #23 AND Condition Check #116 AND Player within Box [5..8, 255..254] | Engine Action #99; Change Portrait Expression (1); Clear Story Milestone Flag 35 (mask 8); Engine Action #240; Engine Action #240; Exit to World Map (2, 2, 0); Open Dialogue Message Window; Mark NPC Talk Interaction Complete (Flag #17); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[03]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Condition Check #23 AND Condition Check #116 AND Player within Box [5..9, 255..254] | Engine Action #99; Change Portrait Expression (1); Warp to Castle HQ (8, 0, 96); Start Boss Battle #8 (BGM: 240); Engine Action #240; Exit to World Map (2, 2, 0); Open Dialogue Message Window; Mark NPC Talk Interaction Complete (Flag #17); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[04]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Condition Check #23 AND Condition Check #116 AND Player within Box [5..8, 255..254] | Engine Action #99; Change Portrait Expression (1); Clear Story Milestone Flag 35 (mask 8); Engine Action #240; Engine Action #240; Engine Action #5; Warp Town -> Area 2 Map 0 Submap 0 at (100,17); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[05]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Condition Check #23 AND Condition Check #116 AND Player within Box [5..9, 255..254] | Engine Action #99; Change Portrait Expression (1); Warp to Castle HQ (8, 0, 96); Start Boss Battle #8 (BGM: 240); Engine Action #240; Engine Action #5; Warp Town -> Area 2 Map 0 Submap 0 at (100,17); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[06]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Condition Check #23 AND Condition Check #116 AND Player within Box [5..8, 255..254] | Engine Action #99; Change Portrait Expression (1); Clear Story Milestone Flag 35 (mask 8); Engine Action #240; Engine Action #240; Engine Action #6; Warp Town -> Area 2 Map 0 Submap 0 at (100,17); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[07]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Condition Check #23 AND Condition Check #116 AND Player within Box [5..9, 255..254] | Engine Action #99; Change Portrait Expression (1); Warp to Castle HQ (8, 0, 96); Start Boss Battle #8 (BGM: 240); Engine Action #240; Engine Action #6; Warp Town -> Area 2 Map 0 Submap 0 at (100,17); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[08]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Condition Check #23 AND Condition Check #116 AND Player within Box [5..8, 255..254] | Engine Action #99; Change Portrait Expression (1); Clear Story Milestone Flag 35 (mask 8); Engine Action #240; Engine Action #240; Pan Camera (2, 2, 0); Open Dialogue Message Window; Mark NPC Talk Interaction Complete (Flag #17); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[09]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Condition Check #23 AND Condition Check #116 AND Player within Box [5..9, 255..254] | Engine Action #99; Change Portrait Expression (1); Warp to Castle HQ (8, 0, 96); Start Boss Battle #8 (BGM: 240); Engine Action #240; Pan Camera (2, 2, 0); Open Dialogue Message Window; Mark NPC Talk Interaction Complete (Flag #17); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[10]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Condition Check #23 AND Condition Check #116 AND Player within Box [5..8, 255..254] | Engine Action #99; Change Portrait Expression (1); Clear Story Milestone Flag 35 (mask 8); Engine Action #240; Engine Action #240; Reset Camera Tracking (2); Warp Town -> Area 0 Map 0 Submap 100 at (17,1) |
| `ev[11]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Condition Check #23 AND Condition Check #116 AND Player within Box [5..9, 255..254] | Engine Action #99; Change Portrait Expression (1); Warp to Castle HQ (8, 0, 96); Start Boss Battle #8 (BGM: 240); Engine Action #240; Reset Camera Tracking (2); Warp Town -> Area 0 Map 0 Submap 100 at (17,1) |
| `ev[12]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #116 AND Player within Box [5..8, 255..254] | Engine Action #99; Change Portrait Expression (1); Clear Story Milestone Flag 35 (mask 8); Engine Action #240; Engine Action #240; Open Dialogue Message Window; Warp Town -> Area 2 Map 0 Submap 0 at (100,17); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[13]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #116 AND Player within Box [5..9, 255..254] | Engine Action #99; Change Portrait Expression (1); Warp to Castle HQ (8, 0, 96); Start Boss Battle #8 (BGM: 240); Engine Action #240; Open Dialogue Message Window; Warp Town -> Area 2 Map 0 Submap 0 at (100,17); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[14]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #67 AND Player within Box [34..25, 4..255] | Make obj[0] Hidden (disp = 0); Screen Fade Transition (47, 255, 254) |
| `ev[15]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[10] | Open Dialogue Sub-Window (4); Warp to Castle HQ (255, 254, 204) |
| `ev[16]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[10] | Open Dialogue Sub-Window (5); Warp to Castle HQ (255, 254, 204) |
| `ev[17]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[10] | Open Dialogue Sub-Window (6); Warp to Castle HQ (255, 254, 204) |
| `ev[18]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[10] | Open Dialogue Sub-Window (7); Warp to Castle HQ (255, 254, 204) |
| `ev[19]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[10] | Open Dialogue Sub-Window (8); Warp to Castle HQ (255, 254, 204) |
| `ev[20]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Open Dialogue Sub-Window (0); Warp to Castle HQ (255, 254, 204) |
| `ev[21]` | `2 (Map Init)` | Condition Check #23 AND Active Party Has Character #1 AND Condition Check #34 AND Inventory Holds Item #1 [Medicine] AND Condition Check #33 AND Player X within Range [3..255] | Make obj[0] Hidden (disp = 0); Close Dialogue Window; Teleport obj[255] to (254,204) |
| `ev[22]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[11] | Open Dialogue Sub-Window (4); Exit to World Map (255, 254, 204) |
| `ev[23]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[11] | Open Dialogue Sub-Window (5); Exit to World Map (255, 254, 204) |
| `ev[24]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[11] | Open Dialogue Sub-Window (6); Exit to World Map (255, 254, 204) |
| `ev[25]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[11] | Open Dialogue Sub-Window (7); Exit to World Map (255, 254, 204) |
| `ev[26]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[11] | Open Dialogue Sub-Window (8); Exit to World Map (255, 254, 204) |
| `ev[27]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Open Dialogue Sub-Window (0); Exit to World Map (255, 254, 204) |
| `ev[28]` | `128 (Loop)` | Player within Box [23..53, 2..34] AND Condition Check #59 AND Condition Check #30 AND Star of Destiny #1 Not Yet Recruited AND Story Flag 144 (bit 32) CLEAR | Warp Room -> Submap 0 at (10,0) |
| `ev[29]` | `128 (Loop)` | Player within Box [23..53, 2..34] AND Condition Check #59 AND Condition Check #30 AND Star of Destiny #1 Not Yet Recruited AND Story Flag 144 (bit 32) SET | Warp Room -> Submap 0 at (10,33) |
| `ev[30]` | `1 (Action / Talk)` | Player within Box [54..55, 2..40] AND Condition Check #47 AND Story Flag 3 (mask 255) SET | Engine Action #111; Award Potch Loot (+1,280 Potch); Warp Room -> Submap 3 at (4,255) facing South (Down); Warp Room -> Submap 3 at (2,79) facing 59; Warp Town -> Area 32 Map 3 Submap 1 at (79,59); Warp to Castle HQ (255, 4, 32); Warp to Castle HQ (0, 79, 59) |
| `ev[31]` | `1 (Action / Talk)` | Player within Box [31..32, 2..25] AND Condition Check #33 AND Story Flag 3 (mask 23) SET AND Condition Check #107 AND Player Y within Range [255..254] | Display Dialogue Box [Bank: 1, MsgID: 39]; Engine Action #61 |
| `ev[32]` | `1 (Action / Talk)` | Player within Box [31..32, 2..25] AND Condition Check #33 AND Story Flag 3 (mask 24) SET AND Condition Check #107 AND Player Y within Range [255..254] | Display Dialogue Box [Bank: 2, MsgID: 103]; Engine Action #61 |
| `ev[33]` | `1 (Action / Talk)` | Player within Box [26..32, 2..64] AND Condition Check #65 AND Story Flag 0 (mask 33) SET AND Player within Box [3..23, 109..2] | Display Dialogue Box [Bank: 5, MsgID: 26]; Display Chapter Text (255) |
| `ev[34]` | `1 (Action / Talk)` | Player within Box [26..32, 2..64] AND Condition Check #65 AND Story Flag 0 (mask 33) SET AND Player within Box [3..24, 109..2] | Display Dialogue Box [Bank: 6, MsgID: 92]; Display Chapter Text (255) |
| `ev[35]` | `1 (Action / Talk)` | Player within Box [26..32, 2..64] AND Condition Check #65 AND Story Flag 0 (mask 33) SET AND Always Passes (Unconditional) AND Player Y within Range [255..254] | Warp Map Transition (3, 1, 66, 63, 255) |
| `ev[36]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Open Dialogue Sub-Window (1); Display Speaker Name Box (255) |
| `ev[37]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Open Dialogue Sub-Window (1); Display Choice Selection (255, 254) |
| `ev[38]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Open Dialogue Sub-Window (1); Branch on Choice (255, 254) |

---

### Submap Layer `vk02_04` (Index 4)

- **Map Number (`mapno`)**: `2`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `4` Objects | **Script Count (`evkaz`)**: `18` Scripts

#### Complete Physical Entity Inventory (4 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 67** | `67` | `(87, 48)` | `15x2` | East (Right) | Dormant / Hidden (0) | Special (3) | 5 | 128 | 0 |
| `obj[01]` | Trigger / Hitbox | **Hitbox Zone (4x3)** | `0` | `(51, 46)` | `3x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(38, 35)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | Trigger / Hitbox | **Hitbox Zone (4x3)** | `0` | `(30, 35)` | `3x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 67)**: Positioned at tile `(87, 48)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `3` tiles high from `(51, 46)` to `(54, 48)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[02]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(38, 35)` to `(39, 36)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[03]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `3` tiles high from `(30, 35)` to `(33, 37)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (18 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #67 AND Player within Box [34..25, 4..255] | Make obj[0] Hidden (disp = 0); Reset Camera Tracking (47) |
| `ev[01]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[8] | Open Dialogue Sub-Window (4); Engine Action #5 |
| `ev[02]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[8] | Open Dialogue Sub-Window (5); Engine Action #5 |
| `ev[03]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[8] | Open Dialogue Sub-Window (6); Engine Action #5 |
| `ev[04]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[8] | Open Dialogue Sub-Window (7); Engine Action #5 |
| `ev[05]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[8] | Open Dialogue Sub-Window (8); Engine Action #5 |
| `ev[06]` | `1 (Action / Talk)` | Target Inspected is obj[8] | Open Dialogue Sub-Window (0); Engine Action #5 |
| `ev[07]` | `128 (Loop)` | Player within Box [85..115, 2..30] AND Condition Check #60 AND Story Flag 144 (bit 32) CLEAR | Warp Room -> Submap 0 at (10,0) |
| `ev[08]` | `128 (Loop)` | Player within Box [85..115, 2..30] AND Condition Check #60 AND Story Flag 144 (bit 32) SET | Warp Room -> Submap 0 at (10,33) |
| `ev[09]` | `1 (Action / Talk)` | Player within Box [116..117, 2..40] AND Condition Check #47 AND Story Flag 3 (mask 255) SET | Engine Action #111; Award Potch Loot (+1,280 Potch); Warp Room -> Submap 3 at (4,255) facing South (Down); Warp Room -> Submap 3 at (2,79) facing 59; Warp Town -> Area 32 Map 3 Submap 1 at (79,59); Warp to Castle HQ (255, 4, 32); Warp to Castle HQ (0, 79, 59) |
| `ev[10]` | `1 (Action / Talk)` | Player within Box [92..93, 2..24] AND Condition Check #32 AND Story Flag 3 (mask 23) SET AND Condition Check #107 AND Player Y within Range [255..254] | Display Dialogue Box [Bank: 1, MsgID: 39]; Engine Action #61 |
| `ev[11]` | `1 (Action / Talk)` | Player within Box [92..93, 2..24] AND Condition Check #32 AND Story Flag 3 (mask 24) SET AND Condition Check #107 AND Player Y within Range [255..254] | Display Dialogue Box [Bank: 2, MsgID: 103]; Engine Action #61 |
| `ev[12]` | `1 (Action / Talk)` | Player within Box [88..94, 2..64] AND Condition Check #65 AND Story Flag 0 (mask 33) SET AND Player within Box [3..23, 109..2] | Display Dialogue Box [Bank: 5, MsgID: 26]; Display Chapter Text (255) |
| `ev[13]` | `1 (Action / Talk)` | Player within Box [88..94, 2..64] AND Condition Check #65 AND Story Flag 0 (mask 33) SET AND Player within Box [3..24, 109..2] | Display Dialogue Box [Bank: 6, MsgID: 92]; Display Chapter Text (255) |
| `ev[14]` | `1 (Action / Talk)` | Player within Box [88..94, 2..64] AND Condition Check #65 AND Story Flag 0 (mask 33) SET AND Always Passes (Unconditional) AND Player Y within Range [255..254] | Warp Map Transition (3, 1, 66, 63, 255) |
| `ev[15]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Open Dialogue Sub-Window (1); Execute Choice Result (255) |
| `ev[16]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Open Dialogue Sub-Window (1); Set Story Flag (255, 254) |
| `ev[17]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Open Dialogue Sub-Window (1); Open Dialogue Sub-Window (255) |

---

### Submap Layer `vk02_05` (Index 5)

- **Map Number (`mapno`)**: `3`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `11` Objects | **Script Count (`evkaz`)**: `36` Scripts

#### Complete Physical Entity Inventory (11 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 109** | `109` | `(31, 44)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | Trigger / Hitbox | **Hitbox Zone (5x3)** | `0` | `(29, 44)` | `4x2` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(45, 51)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(44, 31)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(35, 38)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(35, 40)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(35, 42)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(35, 43)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(35, 44)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | NPC / Actor | **Actor ID 64936** | `64936` | `(40, 42)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[10]` | NPC / Actor | **Actor ID 65105** | `65105` | `(32, 52)` | `4x0` | Up (North) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 109)**: Positioned at tile `(31, 44)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `3` tiles high from `(29, 44)` to `(33, 46)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[02]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(45, 51)` to `(47, 53)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[03]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(44, 31)` to `(46, 32)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[04]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(35, 38)` to `(36, 39)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[05]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(35, 40)` to `(36, 41)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[06]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(35, 42)` to `(36, 43)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[07]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(35, 43)` to `(36, 44)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[08]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(35, 44)` to `(36, 45)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[09]` (Object 64936)**: Positioned at tile `(40, 42)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[10]` (Object 65105)**: Positioned at tile `(32, 52)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.


#### Complete Bytecode Script Catalog (36 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #109 AND Player X within Range [255..254] | Make obj[0] Hidden (disp = 0); Reset Camera Tracking (47) |
| `ev[01]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #109 AND Player X within Range [255..254] | Make obj[0] Hidden (disp = 0); Engine Action #9; Teleport obj[255] to (254,204) |
| `ev[02]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Condition Check #23 AND Condition Check #109 AND Player within Box [5..8, 255..254] | Engine Action #99; Change Portrait Expression (2); Clear Story Milestone Flag 11 (mask 8); Engine Action #240; Engine Action #240; Exit to World Map (6, 1, 10); Mark NPC Talk Interaction Complete (Flag #17); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[03]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Condition Check #23 AND Condition Check #109 AND Player within Box [5..9, 255..254] | Engine Action #99; Change Portrait Expression (2); Clear Story Milestone Flag 11 (mask 8); Engine Action #240; Engine Action #240; Exit to World Map (6, 1, 10); Mark NPC Talk Interaction Complete (Flag #17); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[04]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Condition Check #23 AND Condition Check #109 AND Player within Box [5..8, 255..254] | Engine Action #99; Change Portrait Expression (2); Clear Story Milestone Flag 11 (mask 8); Engine Action #240; Engine Action #240; Engine Action #5; Engine Action #6; Warp Room -> Submap 100 at (17,2) facing 255 |
| `ev[05]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Condition Check #23 AND Condition Check #109 AND Player within Box [5..9, 255..254] | Engine Action #99; Change Portrait Expression (2); Clear Story Milestone Flag 11 (mask 8); Engine Action #240; Engine Action #240; Engine Action #5; Engine Action #6; Warp Room -> Submap 100 at (17,2) facing 255 |
| `ev[06]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Condition Check #23 AND Condition Check #109 AND Player within Box [5..8, 255..254] | Engine Action #99; Change Portrait Expression (2); Clear Story Milestone Flag 11 (mask 8); Engine Action #240; Engine Action #240; Engine Action #6; Engine Action #6; Warp Room -> Submap 100 at (17,2) facing 255 |
| `ev[07]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Condition Check #23 AND Condition Check #109 AND Player within Box [5..9, 255..254] | Engine Action #99; Change Portrait Expression (2); Clear Story Milestone Flag 11 (mask 8); Engine Action #240; Engine Action #240; Engine Action #6; Engine Action #6; Warp Room -> Submap 100 at (17,2) facing 255 |
| `ev[08]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Condition Check #23 AND Condition Check #109 AND Player within Box [5..8, 255..254] | Engine Action #99; Change Portrait Expression (2); Clear Story Milestone Flag 11 (mask 8); Engine Action #240; Engine Action #240; Pan Camera (6, 1, 10); Mark NPC Talk Interaction Complete (Flag #17); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[09]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Condition Check #23 AND Condition Check #109 AND Player within Box [5..9, 255..254] | Engine Action #99; Change Portrait Expression (2); Clear Story Milestone Flag 11 (mask 8); Engine Action #240; Engine Action #240; Pan Camera (6, 1, 10); Mark NPC Talk Interaction Complete (Flag #17); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[10]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Condition Check #23 AND Condition Check #109 AND Player within Box [5..8, 255..254] | Engine Action #99; Change Portrait Expression (2); Clear Story Milestone Flag 11 (mask 8); Engine Action #240; Engine Action #240; Reset Camera Tracking (6); Warp Room -> Submap 100 at (17,2) facing 255 |
| `ev[11]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Condition Check #23 AND Condition Check #109 AND Player within Box [5..9, 255..254] | Engine Action #99; Change Portrait Expression (2); Clear Story Milestone Flag 11 (mask 8); Engine Action #240; Engine Action #240; Reset Camera Tracking (6); Warp Room -> Submap 100 at (17,2) facing 255 |
| `ev[12]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #109 AND Player within Box [5..8, 255..254] | Engine Action #99; Change Portrait Expression (2); Clear Story Milestone Flag 11 (mask 8); Engine Action #240; Engine Action #240; Open Dialogue Message Window; Engine Action #6; Warp Room -> Submap 100 at (17,2) facing 255 |
| `ev[13]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #109 AND Player within Box [5..9, 255..254] | Engine Action #99; Change Portrait Expression (2); Clear Story Milestone Flag 11 (mask 8); Engine Action #240; Engine Action #240; Open Dialogue Message Window; Engine Action #6; Warp Room -> Submap 100 at (17,2) facing 255 |
| `ev[14]` | `128 (Loop)` | Player within Box [20..48, 2..38] AND Condition Check #53 AND Condition Check #30 AND Star of Destiny #2 Not Yet Recruited AND Story Flag 144 (bit 32) CLEAR | Warp Room -> Submap 0 at (10,0) |
| `ev[15]` | `128 (Loop)` | Player within Box [20..48, 2..38] AND Condition Check #53 AND Condition Check #30 AND Star of Destiny #2 Not Yet Recruited AND Story Flag 144 (bit 32) SET | Warp Room -> Submap 0 at (10,33) |
| `ev[16]` | `1 (Action / Talk)` | Player within Box [38..44, 2..56] AND Condition Check #57 AND Story Flag 0 (mask 255) SET | Engine Action #111; Award Potch Loot (+1,280 Potch); Warp Room -> Submap 3 at (4,255) facing South (Down); Warp Room -> Submap 3 at (2,72) facing 83; Warp Town -> Area 32 Map 3 Submap 1 at (72,83); Warp to Castle HQ (255, 4, 32); Warp to Castle HQ (0, 72, 83) |
| `ev[17]` | `1 (Action / Talk)` | Player within Box [24..28, 2..24] AND Condition Check #25 AND Story Flag 1 (mask 23) SET AND Condition Check #116 AND Player Y within Range [255..254] | Display Dialogue Box [Bank: 3, MsgID: 29]; Engine Action #61 |
| `ev[18]` | `1 (Action / Talk)` | Player within Box [24..28, 2..24] AND Condition Check #25 AND Story Flag 1 (mask 24) SET AND Condition Check #116 AND Player Y within Range [255..254] | Display Dialogue Box [Bank: 4, MsgID: 91]; Engine Action #61 |
| `ev[19]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [2..255] | Open Dialogue Message Window; Change Portrait Expression (255) |
| `ev[20]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [3..255] | Open Dialogue Message Window; Display Speaker Name Box (255) |
| `ev[21]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[17] | Close Dialogue Sub-Window (17); Engine Action #9; Pan Camera (255, 254, 204) |
| `ev[22]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[17] | Close Dialogue Sub-Window (17); Screen Fade Transition (7, 255, 254) |
| `ev[23]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[17] | Close Dialogue Sub-Window (17); Close Dialogue Window; Pan Camera (255, 254, 204) |
| `ev[24]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Close Dialogue Sub-Window (17); Warp to Castle HQ (7, 255, 254) |
| `ev[25]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[18] | Close Dialogue Sub-Window (18); Engine Action #9; Reset Camera Tracking (255) |
| `ev[26]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[18] | Close Dialogue Sub-Window (18); Screen Fade Transition (8, 255, 254) |
| `ev[27]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[18] | Close Dialogue Sub-Window (18); Close Dialogue Window; Reset Camera Tracking (255) |
| `ev[28]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Close Dialogue Sub-Window (18); Warp to Castle HQ (8, 255, 254) |
| `ev[29]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Open Dialogue Sub-Window (1); Close Dialogue Sub-Window (255) |
| `ev[30]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Open Dialogue Sub-Window (1); Clear Dialogue Sub-Window |
| `ev[31]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Open Dialogue Sub-Window (1); Fade In from Black (255) |
| `ev[32]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Open Dialogue Sub-Window (1); Fade Out to Black (255) |
| `ev[33]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Open Dialogue Sub-Window (1); Display Chapter Text (255) |
| `ev[34]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Open Dialogue Sub-Window (1); Display Emotion Bubble (255, 254) |
| `ev[35]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Open Dialogue Sub-Window (1); Dismiss Emotion Bubble (255) |

---

### Submap Layer `vk02_06` (Index 6)

- **Map Number (`mapno`)**: `3`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `9` Objects | **Script Count (`evkaz`)**: `22` Scripts

#### Complete Physical Entity Inventory (9 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(45, 51)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[01]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(44, 31)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(35, 38)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(35, 40)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(35, 42)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(35, 43)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(35, 44)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | NPC / Actor | **Actor ID 65155** | `65155` | `(92, 47)` | `4x4` | South (Down) | Dormant / Hidden (0) | Special (3) | 5 | 128 | 0 |
| `obj[08]` | NPC / Actor | **Actor ID 65197** | `65197` | `(99, 49)` | `4x4` | Up (North) | Dormant / Hidden (0) | Special (3) | 5 | 128 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(45, 51)` to `(47, 53)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[01]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(44, 31)` to `(45, 32)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[02]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(35, 38)` to `(36, 39)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[03]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(35, 40)` to `(36, 41)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[04]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(35, 42)` to `(36, 43)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[05]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(35, 43)` to `(36, 44)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[06]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(35, 44)` to `(36, 45)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[07]` (Object 65155)**: Positioned at tile `(92, 47)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[08]` (Object 65197)**: Positioned at tile `(99, 49)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.


#### Complete Bytecode Script Catalog (22 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `128 (Loop)` | Player within Box [87..113, 2..38] AND Condition Check #53 AND Story Flag 144 (bit 32) CLEAR | Warp Room -> Submap 0 at (10,0) |
| `ev[01]` | `128 (Loop)` | Player within Box [87..113, 2..38] AND Condition Check #53 AND Story Flag 144 (bit 32) SET | Warp Room -> Submap 0 at (10,33) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [104..110, 2..56] AND Condition Check #57 AND Story Flag 0 (mask 255) SET | Engine Action #111; Award Potch Loot (+1,280 Potch); Warp Room -> Submap 3 at (4,255) facing South (Down); Warp Room -> Submap 3 at (2,72) facing 83; Warp Town -> Area 32 Map 3 Submap 1 at (72,83); Warp to Castle HQ (255, 4, 32); Warp to Castle HQ (0, 72, 83) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [90..94, 2..24] AND Condition Check #25 AND Story Flag 1 (mask 23) SET AND Condition Check #116 AND Player Y within Range [255..254] | Display Dialogue Box [Bank: 3, MsgID: 29]; Engine Action #61 |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [90..94, 2..24] AND Condition Check #25 AND Story Flag 1 (mask 24) SET AND Condition Check #116 AND Player Y within Range [255..254] | Display Dialogue Box [Bank: 4, MsgID: 91]; Engine Action #61 |
| `ev[05]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [2..255] | Open Dialogue Message Window; Show Dialogue Portrait (255, 254, 204) |
| `ev[06]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [2..255] | Open Dialogue Message Window; Dismiss Dialogue Portrait |
| `ev[07]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[15] | Close Dialogue Sub-Window (15); Engine Action #9; Engine Action #9 |
| `ev[08]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[15] | Close Dialogue Sub-Window (15); Screen Fade Transition (9, 255, 254) |
| `ev[09]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[15] | Close Dialogue Sub-Window (15); Close Dialogue Window; Engine Action #9 |
| `ev[10]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Close Dialogue Sub-Window (15); Warp to Castle HQ (9, 255, 254) |
| `ev[11]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[16] | Close Dialogue Sub-Window (16); Engine Action #9; Screen Fade Transition (255, 254, 204) |
| `ev[12]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[16] | Close Dialogue Sub-Window (16); Screen Fade Transition (10, 255, 254) |
| `ev[13]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[16] | Close Dialogue Sub-Window (16); Close Dialogue Window; Screen Fade Transition (255, 254, 204) |
| `ev[14]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Close Dialogue Sub-Window (16); Warp to Castle HQ (10, 255, 254) |
| `ev[15]` | `1 (Action / Talk)` | Target Inspected is obj[8] | Open Dialogue Sub-Window (1); Warp Room -> Submap 255 at (254,204) |
| `ev[16]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Open Dialogue Sub-Window (1); Warp Map Transition (255, 254, 204, 204, 204) |
| `ev[17]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Open Dialogue Sub-Window (1); Return to Previous Memory Map (255) |
| `ev[18]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Open Dialogue Sub-Window (1); Return Warp to Castle Base (255, 254) |
| `ev[19]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Open Dialogue Sub-Window (1); Start Boss Battle #255 (BGM: 254) |
| `ev[20]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Open Dialogue Sub-Window (1); Launch Tactical War Battle (255) |
| `ev[21]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Open Dialogue Sub-Window (1); Toggle Random Encounters (255) |

---

### Submap Layer `vk02_07` (Index 7)

- **Map Number (`mapno`)**: `4`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `14` Objects | **Script Count (`evkaz`)**: `40` Scripts

#### Complete Physical Entity Inventory (14 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Clive** | `110` | `(28, 25)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | Trigger / Hitbox | **Hitbox Zone (5x2)** | `0` | `(38, 20)` | `4x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(42, 20)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | Trigger / Hitbox | **Hitbox Zone (4x3)** | `0` | `(33, 20)` | `3x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(27, 20)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | Trigger / Hitbox | **Hitbox Zone (4x4)** | `0` | `(26, 26)` | `3x3` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(34, 29)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(34, 32)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(34, 34)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(34, 37)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(24, 20)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(34, 39)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | NPC / Actor | **Actor ID 65043** | `65043` | `(32, 25)` | `0x0` | Up (North) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[13]` | NPC / Actor | **Actor ID 65105** | `65105` | `(30, 41)` | `4x2` | Up (North) | Dormant / Hidden (0) | Special (3) | 2 | 128 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Clive)**: Positioned at tile `(28, 25)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `2` tiles high from `(38, 20)` to `(42, 21)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[02]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(42, 20)` to `(43, 21)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[03]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `3` tiles high from `(33, 20)` to `(36, 22)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[04]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(27, 20)` to `(29, 22)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[05]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `4` tiles high from `(26, 26)` to `(29, 29)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[06]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(34, 29)` to `(35, 30)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[07]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(34, 32)` to `(35, 33)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[08]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(34, 34)` to `(35, 35)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[09]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(34, 37)` to `(35, 38)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[10]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(24, 20)` to `(25, 21)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[11]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(34, 39)` to `(35, 40)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[12]` (Object 65043)**: Positioned at tile `(32, 25)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[13]` (Object 65105)**: Positioned at tile `(30, 41)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.


#### Complete Bytecode Script Catalog (40 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #110 AND Player X within Range [255..254] | Make obj[0] Hidden (disp = 0); Reset Camera Tracking (47) |
| `ev[01]` | `128 (Loop)` | Story Flag 143 (bit 64) SET AND Inventory Holds Item #1 [Medicine] | Clear Story Milestone Flag 37 (mask 8); Engine Action #240; Engine Action #240; Open Dialogue Message Window; Screen Fade Transition (2, 0, 0); Toggle Random Encounters (1) |
| `ev[02]` | `128 (Loop)` | Story Flag 143 (bit 64) CLEAR AND Story Flag 143 (bit 32) SET AND Inventory Holds Item #1 [Medicine] | Clear Story Milestone Flag 37 (mask 8); Engine Action #240; Engine Action #240; Open Dialogue Message Window; Engine Action #9; Warp Town -> Area 0 Map 0 Submap 37 at (1,255) |
| `ev[03]` | `128 (Loop)` | Story Flag 143 (bit 64) CLEAR AND Story Flag 143 (bit 32) CLEAR AND Story Flag 143 (bit 16) SET AND Inventory Holds Item #1 [Medicine] | Clear Story Milestone Flag 37 (mask 8); Engine Action #240; Engine Action #240; Open Dialogue Message Window; Reset Camera Tracking (2); Open Dialogue Message Window; Open Dialogue Message Window; Toggle Random Encounters (1) |
| `ev[04]` | `128 (Loop)` | Story Flag 143 (bit 64) CLEAR AND Story Flag 143 (bit 32) CLEAR AND Story Flag 143 (bit 16) CLEAR AND Story Flag 143 (bit 8) SET AND Inventory Holds Item #1 [Medicine] | Clear Story Milestone Flag 37 (mask 8); Engine Action #240; Engine Action #240; Open Dialogue Message Window; Pan Camera (2, 0, 0); Toggle Random Encounters (1) |
| `ev[05]` | `128 (Loop)` | Story Flag 143 (bit 64) CLEAR AND Story Flag 143 (bit 32) CLEAR AND Story Flag 143 (bit 16) CLEAR AND Story Flag 143 (bit 8) CLEAR AND Inventory Holds Item #1 [Medicine] | Clear Story Milestone Flag 37 (mask 8); Engine Action #240; Engine Action #240; Open Dialogue Message Window; Close Dialogue Window; Warp Town -> Area 0 Map 0 Submap 37 at (1,255) |
| `ev[06]` | `1 (Action / Talk)` | Condition Check #26 AND Always Passes (Unconditional) AND Always Passes (Unconditional) AND Condition Check #50 AND Player within Box [0..23, 110..1] AND Target Inspected is obj[8] | Engine Action #99; Change Portrait Expression (4); Engine Action #9; Engine Action #143; Animate Doorway State (126, 0); Walk obj[126] to (0,49); Engine Action #126; Open Dialogue Message Window; Turn obj[126] facing South (Down); Teleport obj[36] to (1,54); Open Dialogue Message Window; Warp Room -> Submap 17 at (4,255) facing 254 |
| `ev[07]` | `1 (Action / Talk)` | Condition Check #26 AND Always Passes (Unconditional) AND Always Passes (Unconditional) AND Condition Check #49 AND Player within Box [0..23, 110..1] AND Target Inspected is obj[8] | Engine Action #99; Change Portrait Expression (4); Engine Action #9; Engine Action #143; Warp Map Transition (126, 0, 49, 126, 0); Turn obj[126] facing South (Down); Teleport obj[36] to (1,54); Open Dialogue Message Window; Warp Room -> Submap 17 at (4,255) facing 254 |
| `ev[08]` | `1 (Action / Talk)` | Condition Check #26 AND Always Passes (Unconditional) AND Always Passes (Unconditional) AND Condition Check #48 AND Player within Box [0..23, 110..1] AND Target Inspected is obj[8] | Engine Action #99; Change Portrait Expression (4); Engine Action #9; Engine Action #143; Dismiss Dialogue Portrait; Engine Action #126; Open Dialogue Message Window; Turn obj[126] facing South (Down); Teleport obj[36] to (1,54); Open Dialogue Message Window; Warp Room -> Submap 17 at (4,255) facing 254 |
| `ev[09]` | `1 (Action / Talk)` | Condition Check #26 AND Always Passes (Unconditional) AND Always Passes (Unconditional) AND Condition Check #47 AND Player within Box [0..23, 110..1] AND Target Inspected is obj[8] | Engine Action #99; Change Portrait Expression (4); Engine Action #9; Engine Action #143; Reset Camera Tracking (126); Open Dialogue Message Window; Teleport obj[36] to (1,54); Open Dialogue Message Window; Warp Room -> Submap 17 at (4,255) facing 254 |
| `ev[10]` | `1 (Action / Talk)` | Condition Check #26 AND Player within Box [0..50, 0..0] AND Condition Check #26 AND Player within Box [0..49, 0..0] AND Condition Check #26 AND Player within Box [0..48, 0..0] AND Condition Check #26 AND Player within Box [0..47, 0..0] AND Condition Check #23 AND Condition Check #110 AND Player within Box [5..8, 255..254] | Engine Action #99; Change Portrait Expression (4); Launch Tactical War Battle (1); Engine Action #54; Open Dialogue Message Window; Warp Room -> Submap 17 at (4,255) facing 254 |
| `ev[11]` | `128 (Loop)` | Player within Box [23..28, 2..21] AND Condition Check #43 AND Condition Check #30 AND Star of Destiny #4 Not Yet Recruited AND Story Flag 144 (bit 32) CLEAR | Warp Room -> Submap 0 at (10,0) |
| `ev[12]` | `128 (Loop)` | Player within Box [23..28, 2..21] AND Condition Check #43 AND Condition Check #30 AND Star of Destiny #4 Not Yet Recruited AND Story Flag 144 (bit 32) SET | Warp Room -> Submap 0 at (10,33) |
| `ev[13]` | `128 (Loop)` | Player within Box [29..49, 2..41] AND Condition Check #46 AND Condition Check #30 AND Star of Destiny #4 Not Yet Recruited AND Condition Check #33 AND Always Passes (Unconditional) AND Player within Box [4..144, 32..255] | Warp Room -> Submap 0 at (10,0) |
| `ev[14]` | `128 (Loop)` | Player within Box [29..49, 2..41] AND Condition Check #46 AND Condition Check #30 AND Star of Destiny #4 Not Yet Recruited AND Condition Check #33 AND Always Passes (Unconditional) AND Player within Box [3..144, 32..255] | Warp Room -> Submap 0 at (10,33) |
| `ev[15]` | `1 (Action / Talk)` | Player within Box [21..22, 2..28] AND Condition Check #38 AND Story Flag 2 (mask 255) SET | Engine Action #111; Award Potch Loot (+1,280 Potch); Warp Room -> Submap 3 at (4,255) facing South (Down); Warp Room -> Submap 3 at (2,91) facing 27; Warp Town -> Area 32 Map 3 Submap 1 at (91,27); Warp to Castle HQ (255, 4, 32); Warp to Castle HQ (0, 91, 27) |
| `ev[16]` | `1 (Action / Talk)` | Player within Box [36..42, 2..46] AND Condition Check #47 AND Story Flag 0 (mask 33) SET AND Player within Box [2..23, 111..2] | Display Dialogue Box [Bank: 9, MsgID: 44]; Fade In from Black (255) |
| `ev[17]` | `1 (Action / Talk)` | Player within Box [36..42, 2..46] AND Condition Check #47 AND Story Flag 0 (mask 33) SET AND Player within Box [2..24, 111..2] | Display Dialogue Box [Bank: 10, MsgID: 110]; Fade In from Black (255) |
| `ev[18]` | `1 (Action / Talk)` | Player within Box [36..42, 2..46] AND Condition Check #47 AND Story Flag 0 (mask 33) SET AND Always Passes (Unconditional) AND Player X within Range [255..254] | Warp Map Transition (3, 2, 100, 40, 255) |
| `ev[19]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [4..255] | Open Dialogue Message Window; Branch on Choice (255, 254) |
| `ev[20]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [2..255] | Open Dialogue Message Window; Execute Choice Result (255) |
| `ev[21]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[20] | Close Dialogue Sub-Window (20); Engine Action #9; Close Dialogue Window |
| `ev[22]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[20] | Close Dialogue Sub-Window (20); Screen Fade Transition (11, 255, 254) |
| `ev[23]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[20] | Close Dialogue Sub-Window (20); Close Dialogue Window; Close Dialogue Window |
| `ev[24]` | `1 (Action / Talk)` | Target Inspected is obj[20] | Close Dialogue Sub-Window (20); Warp to Castle HQ (11, 255, 254) |
| `ev[25]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[21] | Close Dialogue Sub-Window (21); Engine Action #9; Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[26]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[21] | Close Dialogue Sub-Window (21); Screen Fade Transition (12, 255, 254) |
| `ev[27]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[21] | Close Dialogue Sub-Window (21); Close Dialogue Window; Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[28]` | `1 (Action / Talk)` | Target Inspected is obj[21] | Close Dialogue Sub-Window (21); Warp to Castle HQ (12, 255, 254) |
| `ev[29]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Open Dialogue Sub-Window (1); Open Save Crystal Menu (MSaveInit) |
| `ev[30]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Open Dialogue Sub-Window (1); Engine Action #39 |
| `ev[31]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Open Dialogue Sub-Window (1); Engine Action #40 |
| `ev[32]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Open Dialogue Sub-Window (1); Award Potch Loot (+65,534 Potch) |
| `ev[33]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Open Dialogue Sub-Window (1); Remove Item from Inventory (255, 254) |
| `ev[34]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Open Dialogue Sub-Window (1); Open Shop Menu #254 (Type: 255) |
| `ev[35]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Open Dialogue Sub-Window (1); Engine Action #44 |
| `ev[36]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Open Dialogue Sub-Window (1); Make obj[255] Visible (disp = 1) |
| `ev[37]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Open Dialogue Sub-Window (1); Make obj[255] Hidden (disp = 0) |
| `ev[38]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Open Dialogue Sub-Window (1); Teleport obj[255] to (254,204) |
| `ev[39]` | `1 (Action / Talk)` | Target Inspected is obj[19] | Open Dialogue Sub-Window (1); Turn obj[255] facing 254 |

---

### Submap Layer `vk02_08` (Index 8)

- **Map Number (`mapno`)**: `4`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `13` Objects | **Script Count (`evkaz`)**: `27` Scripts

#### Complete Physical Entity Inventory (13 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | Trigger / Hitbox | **Hitbox Zone (5x2)** | `0` | `(38, 20)` | `4x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[01]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(42, 20)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | Trigger / Hitbox | **Hitbox Zone (4x3)** | `0` | `(33, 20)` | `3x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(27, 20)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | Trigger / Hitbox | **Hitbox Zone (4x4)** | `0` | `(26, 26)` | `3x3` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(34, 29)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(34, 32)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(34, 34)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(34, 37)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(24, 20)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(34, 39)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | NPC / Actor | **Actor ID 65043** | `65043` | `(86, 32)` | `4x2` | Up (North) | Dormant / Hidden (0) | Special (3) | 2 | 128 | 0 |
| `obj[12]` | NPC / Actor | **Actor ID 65105** | `65105` | `(101, 24)` | `0x0` | Up (North) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `2` tiles high from `(38, 20)` to `(42, 21)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[01]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(42, 20)` to `(43, 21)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[02]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `3` tiles high from `(33, 20)` to `(36, 22)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[03]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(27, 20)` to `(29, 22)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[04]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `4` tiles high from `(26, 26)` to `(29, 29)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[05]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(34, 29)` to `(35, 30)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[06]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(34, 32)` to `(35, 33)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[07]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(34, 34)` to `(35, 35)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[08]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(34, 37)` to `(35, 38)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[09]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(24, 20)` to `(25, 21)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[10]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(34, 39)` to `(35, 40)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[11]` (Object 65043)**: Positioned at tile `(86, 32)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[12]` (Object 65105)**: Positioned at tile `(101, 24)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.


#### Complete Bytecode Script Catalog (27 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `128 (Loop)` | Player within Box [79..105, 2..21] AND Condition Check #43 AND Story Flag 144 (bit 32) CLEAR | Warp Room -> Submap 0 at (10,0) |
| `ev[01]` | `128 (Loop)` | Player within Box [79..105, 2..21] AND Condition Check #43 AND Story Flag 144 (bit 32) SET | Warp Room -> Submap 0 at (10,33) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [76..78, 2..28] AND Condition Check #38 AND Story Flag 2 (mask 255) SET | Engine Action #111; Award Potch Loot (+1,280 Potch); Warp Room -> Submap 3 at (4,255) facing South (Down); Warp Room -> Submap 3 at (2,91) facing 27; Warp Town -> Area 32 Map 3 Submap 1 at (91,27); Warp to Castle HQ (255, 4, 32); Warp to Castle HQ (0, 91, 27) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [92..98, 2..46] AND Condition Check #47 AND Story Flag 0 (mask 33) SET AND Player within Box [2..23, 111..2] | Display Dialogue Box [Bank: 9, MsgID: 44]; Fade In from Black (255) |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [92..98, 2..46] AND Condition Check #47 AND Story Flag 0 (mask 33) SET AND Player within Box [2..24, 111..2] | Display Dialogue Box [Bank: 10, MsgID: 110]; Fade In from Black (255) |
| `ev[05]` | `1 (Action / Talk)` | Player within Box [92..98, 2..46] AND Condition Check #47 AND Story Flag 0 (mask 33) SET AND Always Passes (Unconditional) AND Player X within Range [255..254] | Warp Map Transition (3, 2, 100, 40, 255) |
| `ev[06]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [4..255] | Open Dialogue Message Window; Display Choice Selection (255, 254) |
| `ev[07]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [2..255] | Open Dialogue Message Window; Branch on Choice (255, 254) |
| `ev[08]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[19] | Close Dialogue Sub-Window (19); Engine Action #9; Place Scenery Structure (255) |
| `ev[09]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[19] | Close Dialogue Sub-Window (19); Screen Fade Transition (13, 255, 254) |
| `ev[10]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[19] | Close Dialogue Sub-Window (19); Close Dialogue Window; Place Scenery Structure (255) |
| `ev[11]` | `1 (Action / Talk)` | Target Inspected is obj[19] | Close Dialogue Sub-Window (19); Warp to Castle HQ (13, 255, 254) |
| `ev[12]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[20] | Close Dialogue Sub-Window (20); Engine Action #9; Animate Door Open |
| `ev[13]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[20] | Close Dialogue Sub-Window (20); Screen Fade Transition (14, 255, 254) |
| `ev[14]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[20] | Close Dialogue Sub-Window (20); Close Dialogue Window; Animate Door Open |
| `ev[15]` | `1 (Action / Talk)` | Target Inspected is obj[20] | Close Dialogue Sub-Window (20); Warp to Castle HQ (14, 255, 254) |
| `ev[16]` | `1 (Action / Talk)` | Target Inspected is obj[8] | Open Dialogue Sub-Window (1); Set Entity Movement Speed (255, 254) |
| `ev[17]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Open Dialogue Sub-Window (1); Walk obj[255] to (254,204) |
| `ev[18]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Open Dialogue Sub-Window (1); Engine Action #51 |
| `ev[19]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Open Dialogue Sub-Window (1); Engine Action #52 |
| `ev[20]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Open Dialogue Sub-Window (1); Engine Action #53 |
| `ev[21]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Open Dialogue Sub-Window (1); Engine Action #54 |
| `ev[22]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Open Dialogue Sub-Window (1); Set Render Priority (pri) (255, 254) |
| `ev[23]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Open Dialogue Sub-Window (1); Set Animation Pose (255, 254) |
| `ev[24]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Open Dialogue Sub-Window (1); Recruit Character into Active Party (255, 254) |
| `ev[25]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Open Dialogue Sub-Window (1); Engine Action #58 |
| `ev[26]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Open Dialogue Sub-Window (1); Set obj[255] Collision to Passable |

---

### Submap Layer `vk02_09` (Index 9)

- **Map Number (`mapno`)**: `5`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `19` Objects | **Script Count (`evkaz`)**: `60` Scripts

#### Complete Physical Entity Inventory (19 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(32, 28)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[01]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(58, 27)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(58, 29)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(25, 37)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(33, 37)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | Trigger / Hitbox | **Hitbox Zone (4x4)** | `0` | `(30, 42)` | `3x3` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | Trigger / Hitbox | **Hitbox Zone (5x2)** | `0` | `(40, 37)` | `4x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(47, 36)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(50, 36)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(25, 83)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(28, 83)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Trigger / Hitbox | **Hitbox Zone (4x4)** | `0` | `(32, 94)` | `3x3` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | NPC / Actor | **Elza** | `111` | `(45, 41)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[13]` | Trigger / Hitbox | **Hitbox Zone (5x2)** | `0` | `(43, 43)` | `4x1` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | NPC / Actor | **Flik** | `5` | `(43, 45)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[15]` | NPC / Actor | **Storage Sack / Flour Bag** | `65079` | `(29, 44)` | `0x0` | East (Right) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[16]` | NPC / Actor | **Actor ID 65098** | `65098` | `(54, 48)` | `3x0` | Up (North) | Dormant / Hidden (0) | Special (3) | 1 | 128 | 0 |
| `obj[17]` | NPC / Actor | **Actor ID 65105** | `65105` | `(31, 33)` | `0x0` | East (Right) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[18]` | NPC / Actor | **Actor ID 65037** | `65037` | `(49, 93)` | `5x3` | Up (North) | Dormant / Hidden (0) | Special (3) | 2 | 128 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(32, 28)` to `(34, 30)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[01]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(58, 27)` to `(60, 29)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[02]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(58, 29)` to `(60, 31)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[03]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(25, 37)` to `(27, 39)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[04]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(33, 37)` to `(35, 39)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[05]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `4` tiles high from `(30, 42)` to `(33, 45)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[06]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `2` tiles high from `(40, 37)` to `(44, 38)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[07]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(47, 36)` to `(48, 37)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[08]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(50, 36)` to `(53, 37)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[09]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(25, 83)` to `(27, 84)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[10]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(28, 83)` to `(31, 84)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[11]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `4` tiles high from `(32, 94)` to `(35, 97)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[12]` (Elza)**: Positioned at tile `(45, 41)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[13]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `2` tiles high from `(43, 43)` to `(47, 44)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[14]` (Flik)**: Positioned at tile `(43, 45)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[15]` (Storage Sack / Flour Bag)**: Positioned at tile `(29, 44)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[16]` (Object 65098)**: Positioned at tile `(54, 48)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[17]` (Object 65105)**: Positioned at tile `(31, 33)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[18]` (Object 65037)**: Positioned at tile `(49, 93)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.


#### Complete Bytecode Script Catalog (60 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Condition Check #23 AND Target Inspected is obj[1] AND Condition Check #34 AND Player Y within Range [2..255] | Make obj[0] Hidden (disp = 0); Set Story Flag (47, 255) |
| `ev[01]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[22] | Open Dialogue Sub-Window (5); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[02]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #111 AND Player Y within Range [23..116] AND Player Y within Range [5..22] | Open Dialogue Sub-Window (6); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[03]` | `1 (Action / Talk)` | Condition Check #24 AND Condition Check #111 AND Player Y within Range [23..116] AND Player Y within Range [5..22] | Open Dialogue Sub-Window (7); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[04]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #111 AND Player Y within Range [24..116] AND Player Y within Range [5..22] | Open Dialogue Sub-Window (8); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[05]` | `1 (Action / Talk)` | Condition Check #24 AND Condition Check #111 AND Player Y within Range [24..116] AND Player Y within Range [5..22] | Open Dialogue Sub-Window (0); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[06]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #111 AND Player X within Range [255..254] | Make obj[0] Hidden (disp = 0); Branch on Choice (47, 255) |
| `ev[07]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #111 AND Player X within Range [255..254] | Open Dialogue Message Window; Execute Choice Result (255) |
| `ev[08]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Condition Check #23 AND Condition Check #111 AND Player within Box [5..20, 255..254] | Clear Story Milestone Flag 36 (mask 20); Engine Action #240; Engine Action #240; Exit to World Map (13, 2, 0); Open Dialogue Message Window |
| `ev[09]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Condition Check #23 AND Condition Check #111 AND Player within Box [5..21, 255..254] | Warp to Castle HQ (20, 0, 96); Launch Tactical War Battle (20); Engine Action #240; Engine Action #240; Exit to World Map (13, 2, 0); Open Dialogue Message Window |
| `ev[10]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Condition Check #23 AND Condition Check #111 AND Player within Box [5..20, 255..254] | Clear Story Milestone Flag 36 (mask 20); Engine Action #240; Engine Action #240; Engine Action #5; Place Scenery Structure (2); Open Dialogue Message Window; Open Dialogue Message Window |
| `ev[11]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Condition Check #23 AND Condition Check #111 AND Player within Box [5..21, 255..254] | Warp to Castle HQ (20, 0, 96); Launch Tactical War Battle (20); Engine Action #240; Engine Action #240; Engine Action #5; Place Scenery Structure (2); Open Dialogue Message Window; Open Dialogue Message Window |
| `ev[12]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Condition Check #23 AND Condition Check #111 AND Player within Box [5..20, 255..254] | Clear Story Milestone Flag 36 (mask 20); Engine Action #240; Engine Action #240; Engine Action #6; Place Scenery Structure (2); Open Dialogue Message Window; Open Dialogue Message Window |
| `ev[13]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Condition Check #23 AND Condition Check #111 AND Player within Box [5..21, 255..254] | Warp to Castle HQ (20, 0, 96); Launch Tactical War Battle (20); Engine Action #240; Engine Action #240; Engine Action #6; Place Scenery Structure (2); Open Dialogue Message Window; Open Dialogue Message Window |
| `ev[14]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Condition Check #23 AND Condition Check #111 AND Player within Box [5..20, 255..254] | Clear Story Milestone Flag 36 (mask 20); Engine Action #240; Engine Action #240; Pan Camera (13, 2, 0); Open Dialogue Message Window |
| `ev[15]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Condition Check #23 AND Condition Check #111 AND Player within Box [5..21, 255..254] | Warp to Castle HQ (20, 0, 96); Launch Tactical War Battle (20); Engine Action #240; Engine Action #240; Pan Camera (13, 2, 0); Open Dialogue Message Window |
| `ev[16]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Condition Check #23 AND Condition Check #111 AND Player within Box [5..20, 255..254] | Clear Story Milestone Flag 36 (mask 20); Engine Action #240; Engine Action #240; Reset Camera Tracking (13); Warp Town -> Area 0 Map 0 Submap 255 at (254,204) |
| `ev[17]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Condition Check #23 AND Condition Check #111 AND Player within Box [5..21, 255..254] | Warp to Castle HQ (20, 0, 96); Launch Tactical War Battle (20); Engine Action #240; Engine Action #240; Reset Camera Tracking (13); Warp Town -> Area 0 Map 0 Submap 255 at (254,204) |
| `ev[18]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #111 AND Player within Box [5..20, 255..254] | Clear Story Milestone Flag 36 (mask 20); Engine Action #240; Engine Action #240; Open Dialogue Message Window; Place Scenery Structure (2); Open Dialogue Message Window; Open Dialogue Message Window |
| `ev[19]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #111 AND Player within Box [5..21, 255..254] | Warp to Castle HQ (20, 0, 96); Launch Tactical War Battle (20); Engine Action #240; Engine Action #240; Open Dialogue Message Window; Place Scenery Structure (2); Open Dialogue Message Window; Open Dialogue Message Window |
| `ev[20]` | `128 (Loop)` | Player within Box [25..41, 2..31] AND Condition Check #52 AND Story Flag 144 (bit 32) CLEAR | Warp Room -> Submap 0 at (10,0) |
| `ev[21]` | `128 (Loop)` | Player within Box [25..41, 2..31] AND Condition Check #52 AND Story Flag 144 (bit 32) SET | Warp Room -> Submap 0 at (10,33) |
| `ev[22]` | `1 (Action / Talk)` | Player within Box [23..24, 2..38] AND Condition Check #48 AND Story Flag 2 (mask 255) SET | Engine Action #111; Award Potch Loot (+1,280 Potch); Warp Room -> Submap 3 at (4,255) facing South (Down); Warp Room -> Submap 3 at (2,87) facing 57; Warp Town -> Area 32 Map 3 Submap 1 at (87,57); Warp to Castle HQ (255, 4, 32); Warp to Castle HQ (0, 87, 57) |
| `ev[23]` | `1 (Action / Talk)` | Player within Box [42..46, 2..23] AND Condition Check #24 AND Story Flag 1 (mask 23) SET AND Condition Check #110 AND Player Y within Range [255..254] | Display Dialogue Box [Bank: 7, MsgID: 39]; Open Shop Menu #254 (Type: 255) |
| `ev[24]` | `1 (Action / Talk)` | Player within Box [42..46, 2..23] AND Condition Check #24 AND Story Flag 1 (mask 24) SET AND Condition Check #110 AND Player Y within Range [255..254] | Display Dialogue Box [Bank: 8, MsgID: 95]; Open Shop Menu #254 (Type: 255) |
| `ev[25]` | `1 (Action / Talk)` | Player within Box [32..38, 2..52] AND Condition Check #53 AND Story Flag 0 (mask 33) SET AND Player within Box [3..23, 106..2] | Display Dialogue Box [Bank: 11, MsgID: 24]; Return to Previous Memory Map (255) |
| `ev[26]` | `1 (Action / Talk)` | Player within Box [32..38, 2..52] AND Condition Check #53 AND Story Flag 0 (mask 33) SET AND Player within Box [3..24, 106..2] | Display Dialogue Box [Bank: 12, MsgID: 84]; Return to Previous Memory Map (255) |
| `ev[27]` | `1 (Action / Talk)` | Player within Box [32..38, 2..52] AND Condition Check #53 AND Story Flag 0 (mask 33) SET AND Always Passes (Unconditional) AND Player Y within Range [255..254] | Warp Map Transition (3, 1, 94, 63, 255) |
| `ev[28]` | `1 (Action / Talk)` | Player within Box [30..31, 2..23] AND Treasure Byte 9 Bit 3 LOOTED | Display Dialogue Box [Bank: 9, MsgID: 42]; Animate Door obj[255] (State: 254) |
| `ev[29]` | `1 (Action / Talk)` | Player within Box [37..39, 2..84] AND Condition Check #87 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 9, MsgID: 27]; Display Chapter Text (255) |
| `ev[30]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [2..255] | Open Dialogue Message Window; Open Dialogue Sub-Window (255) |
| `ev[31]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [3..255] | Open Dialogue Message Window; Close Dialogue Sub-Window (255) |
| `ev[32]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [4..255] | Open Dialogue Message Window; Clear Dialogue Sub-Window |
| `ev[33]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [4..255] | Open Dialogue Message Window; Fade In from Black (255) |
| `ev[34]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[23] | Close Dialogue Sub-Window (23); Engine Action #9; Show Dialogue Portrait (255, 254, 204) |
| `ev[35]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[23] | Close Dialogue Sub-Window (23); Screen Fade Transition (15, 255, 254) |
| `ev[36]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[23] | Close Dialogue Sub-Window (23); Close Dialogue Window; Show Dialogue Portrait (255, 254, 204) |
| `ev[37]` | `1 (Action / Talk)` | Target Inspected is obj[23] | Close Dialogue Sub-Window (23); Warp to Castle HQ (15, 255, 254) |
| `ev[38]` | `1 (Action / Talk)` | Condition Check #24 AND Condition Check #116 AND Player Y within Range [5..24] | Close Dialogue Sub-Window (24); Warp to Castle HQ (16, 255, 254) |
| `ev[39]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #116 AND Player Y within Range [5..24] | Close Dialogue Sub-Window (24); Close Dialogue Window; Dismiss Dialogue Portrait |
| `ev[40]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[25] | Close Dialogue Sub-Window (25); Engine Action #9; Change Portrait Expression (255) |
| `ev[41]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[25] | Close Dialogue Sub-Window (25); Screen Fade Transition (17, 255, 254) |
| `ev[42]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[25] | Close Dialogue Sub-Window (25); Close Dialogue Window; Change Portrait Expression (255) |
| `ev[43]` | `1 (Action / Talk)` | Target Inspected is obj[25] | Close Dialogue Sub-Window (25); Warp to Castle HQ (17, 255, 254) |
| `ev[44]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[26] | Close Dialogue Sub-Window (26); Engine Action #9; Display Speaker Name Box (255) |
| `ev[45]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[26] | Close Dialogue Sub-Window (26); Screen Fade Transition (18, 255, 254) |
| `ev[46]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[26] | Close Dialogue Sub-Window (26); Close Dialogue Window; Display Speaker Name Box (255) |
| `ev[47]` | `1 (Action / Talk)` | Target Inspected is obj[26] | Close Dialogue Sub-Window (26); Warp to Castle HQ (18, 255, 254) |
| `ev[48]` | `1 (Action / Talk)` | Target Inspected is obj[8] | Open Dialogue Sub-Window (1); Trigger Character Emotion Effect (255, 254) |
| `ev[49]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Open Dialogue Sub-Window (1); Engine Action #61 |
| `ev[50]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Open Dialogue Sub-Window (1); Engine Action #62 |
| `ev[51]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Open Dialogue Sub-Window (1); Engine Action #63 |
| `ev[52]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Open Dialogue Sub-Window (1); Animate Doorway State (255, 254) |
| `ev[53]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Open Dialogue Sub-Window (1); Play Sound Effect (SE) (255) |
| `ev[54]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Open Dialogue Sub-Window (1); Engine Action #66 |
| `ev[55]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Open Dialogue Sub-Window (1); Open Shop Interface #255 |
| `ev[56]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Open Dialogue Sub-Window (1); Play CD / Ambient BGM Track (255) |
| `ev[57]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Open Dialogue Sub-Window (1); Wait for Audio / Window Sync (255) |
| `ev[58]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Open Dialogue Sub-Window (1); Recruit Hero #255 into Battle Slot 254 |
| `ev[59]` | `1 (Action / Talk)` | Target Inspected is obj[19] | Open Dialogue Sub-Window (1); Remove Character from Active Party (255) |

---

### Submap Layer `vk02_10` (Index 10)

- **Map Number (`mapno`)**: `5`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `19` Objects | **Script Count (`evkaz`)**: `50` Scripts

#### Complete Physical Entity Inventory (19 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(32, 28)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[01]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(58, 27)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(58, 29)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(25, 37)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(33, 37)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | Trigger / Hitbox | **Hitbox Zone (4x4)** | `0` | `(30, 42)` | `3x3` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | Trigger / Hitbox | **Hitbox Zone (5x2)** | `0` | `(40, 37)` | `4x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(47, 36)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(50, 36)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(25, 83)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(28, 83)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Trigger / Hitbox | **Hitbox Zone (4x4)** | `0` | `(32, 94)` | `3x3` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | NPC / Actor | **Flik** | `5` | `(43, 45)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[13]` | NPC / Actor | **Actor ID 65076** | `65076` | `(100, 34)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[14]` | NPC / Actor | **Actor ID 65094** | `65094` | `(98, 42)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[15]` | NPC / Actor | **Spice Stall & Jars** | `65223` | `(102, 42)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[16]` | NPC / Actor | **Actor ID 65151** | `65151` | `(100, 45)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[17]` | NPC / Actor | **Actor ID 65042** | `65042` | `(103, 45)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[18]` | NPC / Actor | **Actor ID 65161** | `65161` | `(97, 45)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(32, 28)` to `(34, 30)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[01]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(58, 27)` to `(60, 29)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[02]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(58, 29)` to `(60, 31)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[03]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(25, 37)` to `(27, 39)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[04]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(33, 37)` to `(35, 39)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[05]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `4` tiles high from `(30, 42)` to `(33, 45)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[06]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `2` tiles high from `(40, 37)` to `(44, 38)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[07]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(47, 36)` to `(48, 37)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[08]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(50, 36)` to `(53, 37)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[09]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(25, 83)` to `(27, 84)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[10]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(28, 83)` to `(31, 84)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[11]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `4` tiles high from `(32, 94)` to `(35, 97)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[12]` (Flik)**: Positioned at tile `(43, 45)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[13]` (Object 65076)**: Positioned at tile `(100, 34)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[14]` (Object 65094)**: Positioned at tile `(98, 42)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[15]` (Spice Stall & Jars)**: Positioned at tile `(102, 42)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[16]` (Object 65151)**: Positioned at tile `(100, 45)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[17]` (Object 65042)**: Positioned at tile `(103, 45)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[18]` (Object 65161)**: Positioned at tile `(97, 45)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.


#### Complete Bytecode Script Catalog (50 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `128 (Loop)` | Player within Box [91..125, 2..31] AND Condition Check #49 AND Story Flag 144 (bit 32) CLEAR | Warp Room -> Submap 0 at (10,0) |
| `ev[01]` | `128 (Loop)` | Player within Box [91..125, 2..31] AND Condition Check #49 AND Story Flag 144 (bit 32) SET | Warp Room -> Submap 0 at (10,33) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [89..90, 2..38] AND Condition Check #48 AND Story Flag 2 (mask 255) SET | Engine Action #111; Award Potch Loot (+1,280 Potch); Warp Room -> Submap 3 at (4,255) facing South (Down); Warp Room -> Submap 3 at (2,87) facing 57; Warp Town -> Area 32 Map 3 Submap 1 at (87,57); Warp to Castle HQ (255, 4, 32); Warp to Castle HQ (0, 87, 57) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [108..112, 2..23] AND Condition Check #24 AND Story Flag 1 (mask 23) SET AND Condition Check #110 AND Player Y within Range [255..254] | Display Dialogue Box [Bank: 7, MsgID: 39]; Open Shop Menu #254 (Type: 255) |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [108..112, 2..23] AND Condition Check #24 AND Story Flag 1 (mask 24) SET AND Condition Check #110 AND Player Y within Range [255..254] | Display Dialogue Box [Bank: 8, MsgID: 95]; Open Shop Menu #254 (Type: 255) |
| `ev[05]` | `1 (Action / Talk)` | Player within Box [98..104, 2..52] AND Condition Check #53 AND Story Flag 0 (mask 33) SET AND Player within Box [3..23, 106..2] | Display Dialogue Box [Bank: 11, MsgID: 24]; Return to Previous Memory Map (255) |
| `ev[06]` | `1 (Action / Talk)` | Player within Box [98..104, 2..52] AND Condition Check #53 AND Story Flag 0 (mask 33) SET AND Player within Box [3..24, 106..2] | Display Dialogue Box [Bank: 12, MsgID: 84]; Return to Previous Memory Map (255) |
| `ev[07]` | `1 (Action / Talk)` | Player within Box [98..104, 2..52] AND Condition Check #53 AND Story Flag 0 (mask 33) SET AND Always Passes (Unconditional) AND Player Y within Range [255..254] | Warp Map Transition (3, 1, 94, 63, 255) |
| `ev[08]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [2..255] | Open Dialogue Message Window; Execute Choice Result (255) |
| `ev[09]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [2..255] | Open Dialogue Message Window; Set Story Flag (255, 254) |
| `ev[10]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [2..255] | Open Dialogue Message Window; Open Dialogue Sub-Window (255) |
| `ev[11]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [3..255] | Open Dialogue Message Window; Close Dialogue Sub-Window (255) |
| `ev[12]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [3..255] | Open Dialogue Message Window; Clear Dialogue Sub-Window |
| `ev[13]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [4..255] | Open Dialogue Message Window; Fade In from Black (255) |
| `ev[14]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[21] | Close Dialogue Sub-Window (21); Engine Action #9; Display Choice Selection (255, 254) |
| `ev[15]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[21] | Close Dialogue Sub-Window (21); Screen Fade Transition (19, 255, 254) |
| `ev[16]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[21] | Close Dialogue Sub-Window (21); Close Dialogue Window; Display Choice Selection (255, 254) |
| `ev[17]` | `1 (Action / Talk)` | Target Inspected is obj[21] | Close Dialogue Sub-Window (21); Warp to Castle HQ (19, 255, 254) |
| `ev[18]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[22] | Close Dialogue Sub-Window (22); Engine Action #9; Branch on Choice (255, 254) |
| `ev[19]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[22] | Close Dialogue Sub-Window (22); Screen Fade Transition (20, 255, 254) |
| `ev[20]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[22] | Close Dialogue Sub-Window (22); Close Dialogue Window; Branch on Choice (255, 254) |
| `ev[21]` | `1 (Action / Talk)` | Target Inspected is obj[22] | Close Dialogue Sub-Window (22); Warp to Castle HQ (20, 255, 254) |
| `ev[22]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[23] | Close Dialogue Sub-Window (23); Engine Action #9; Execute Choice Result (255) |
| `ev[23]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[23] | Close Dialogue Sub-Window (23); Screen Fade Transition (21, 255, 254) |
| `ev[24]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[23] | Close Dialogue Sub-Window (23); Close Dialogue Window; Execute Choice Result (255) |
| `ev[25]` | `1 (Action / Talk)` | Target Inspected is obj[23] | Close Dialogue Sub-Window (23); Warp to Castle HQ (21, 255, 254) |
| `ev[26]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[24] | Close Dialogue Sub-Window (24); Engine Action #9; Set Story Flag (255, 254) |
| `ev[27]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[24] | Close Dialogue Sub-Window (24); Screen Fade Transition (22, 255, 254) |
| `ev[28]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[24] | Close Dialogue Sub-Window (24); Close Dialogue Window; Set Story Flag (255, 254) |
| `ev[29]` | `1 (Action / Talk)` | Target Inspected is obj[24] | Close Dialogue Sub-Window (24); Warp to Castle HQ (22, 255, 254) |
| `ev[30]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[25] | Close Dialogue Sub-Window (25); Engine Action #9; Open Dialogue Sub-Window (255) |
| `ev[31]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[25] | Close Dialogue Sub-Window (25); Screen Fade Transition (23, 255, 254) |
| `ev[32]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[25] | Close Dialogue Sub-Window (25); Close Dialogue Window; Open Dialogue Sub-Window (255) |
| `ev[33]` | `1 (Action / Talk)` | Target Inspected is obj[25] | Close Dialogue Sub-Window (25); Warp to Castle HQ (23, 255, 254) |
| `ev[34]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[26] | Close Dialogue Sub-Window (26); Engine Action #9; Close Dialogue Sub-Window (255) |
| `ev[35]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[26] | Close Dialogue Sub-Window (26); Screen Fade Transition (24, 255, 254) |
| `ev[36]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[26] | Close Dialogue Sub-Window (26); Close Dialogue Window; Close Dialogue Sub-Window (255) |
| `ev[37]` | `1 (Action / Talk)` | Target Inspected is obj[26] | Close Dialogue Sub-Window (26); Warp to Castle HQ (24, 255, 254) |
| `ev[38]` | `1 (Action / Talk)` | Target Inspected is obj[8] | Open Dialogue Sub-Window (1); Load Sound Bank into Memory (255, 254) |
| `ev[39]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Open Dialogue Sub-Window (1); Set Combat Battle BGM (255) |
| `ev[40]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Open Dialogue Sub-Window (1); Set Special Scene BGM (255) |
| `ev[41]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Open Dialogue Sub-Window (1); Full Rest & Healing (Restore HP/MP) |
| `ev[42]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Open Dialogue Sub-Window (1); Full Rest & Healing (Restore HP/MP) |
| `ev[43]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Open Dialogue Sub-Window (1); Award Potch Currency (255,254) |
| `ev[44]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Open Dialogue Sub-Window (1); Engine Action #78 |
| `ev[45]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Open Dialogue Sub-Window (1); Bytecode Subroutine Return |
| `ev[46]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Open Dialogue Sub-Window (1); Engine Action #80 |
| `ev[47]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Open Dialogue Sub-Window (1); Engine Action #81 |
| `ev[48]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Open Dialogue Sub-Window (1); Remove Item from Inventory (255, 254) |
| `ev[49]` | `1 (Action / Talk)` | Target Inspected is obj[19] | Open Dialogue Sub-Window (1); Engine Action #83 |

---

### Submap Layer `vk02_11` (Index 11)

- **Map Number (`mapno`)**: `6`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `18` Objects | **Script Count (`evkaz`)**: `78` Scripts

#### Complete Physical Entity Inventory (18 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(30, 34)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[01]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(30, 32)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(35, 41)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(35, 47)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | NPC / Actor | **Hix** | `106` | `(42, 32)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[05]` | Trigger / Hitbox | **Hitbox Zone (5x3)** | `0` | `(40, 32)` | `4x2` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | NPC / Actor | **Actor ID 65224** | `65224` | `(49, 39)` | `2x3` | South (Down) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[07]` | NPC / Actor | **Actor ID 65186** | `65186` | `(25, 43)` | `3x3` | Up (North) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[08]` | NPC / Actor | **Actor ID 65035** | `65035` | `(48, 38)` | `3x3` | Up (North) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[09]` | NPC / Actor | **Actor ID 65115** | `65115` | `(49, 51)` | `3x3` | Up (North) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[10]` | NPC / Actor | **Actor ID 65213** | `65213` | `(28, 56)` | `3x3` | Up (North) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[11]` | NPC / Actor | **Actor ID 64929** | `64929` | `(37, 35)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[12]` | NPC / Actor | **Actor ID 64546** | `64546` | `(46, 49)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[13]` | NPC / Actor | **Actor ID 64929** | `64929` | `(40, 55)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[14]` | NPC / Actor | **Actor ID 64932** | `64932` | `(46, 44)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[15]` | NPC / Actor | **Actor ID 64545** | `64545` | `(40, 50)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[16]` | NPC / Actor | **Wooden Water Bucket** | `64548` | `(43, 47)` | `0x0` | East (Right) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[17]` | NPC / Actor | **Wooden Water Bucket** | `64548` | `(45, 59)` | `0x0` | East (Right) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(30, 34)` to `(32, 36)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[01]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(30, 32)` to `(32, 34)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[02]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(35, 41)` to `(36, 42)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[03]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(35, 47)` to `(36, 48)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[04]` (Hix)**: Positioned at tile `(42, 32)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `3` tiles high from `(40, 32)` to `(44, 34)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[06]` (Object 65224)**: Positioned at tile `(49, 39)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[07]` (Object 65186)**: Positioned at tile `(25, 43)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[08]` (Object 65035)**: Positioned at tile `(48, 38)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[09]` (Object 65115)**: Positioned at tile `(49, 51)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[10]` (Object 65213)**: Positioned at tile `(28, 56)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[11]` (Object 64929)**: Positioned at tile `(37, 35)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[12]` (Object 64546)**: Positioned at tile `(46, 49)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[13]` (Object 64929)**: Positioned at tile `(40, 55)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[14]` (Object 64932)**: Positioned at tile `(46, 44)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[15]` (Object 64545)**: Positioned at tile `(40, 50)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[16]` (Wooden Water Bucket)**: Positioned at tile `(43, 47)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[17]` (Wooden Water Bucket)**: Positioned at tile `(45, 59)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.


#### Complete Bytecode Script Catalog (78 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #106 AND Player X within Range [255..254] | Make obj[0] Hidden (disp = 0); Display Dialogue Box [Bank: 47, MsgID: 255] |
| `ev[01]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #106 AND Player X within Range [255..254] | Open Dialogue Message Window; Place Scenery Structure (255) |
| `ev[02]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Condition Check #23 AND Condition Check #106 AND Player within Box [5..12, 255..254] | Clear Story Milestone Flag 31 (mask 12); Engine Action #240; Engine Action #240; Exit to World Map (14, 2, 11); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[03]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Condition Check #23 AND Condition Check #106 AND Player within Box [5..13, 255..254] | Warp to Castle HQ (12, 0, 96); Warp Room -> Submap 12 at (240,240); Exit to World Map (14, 2, 11); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[04]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Condition Check #23 AND Condition Check #106 AND Player within Box [5..12, 255..254] | Clear Story Milestone Flag 31 (mask 12); Engine Action #240; Engine Action #240; Engine Action #5; Animate Door Open; Warp Town -> Area 11 Map 1 Submap 255 at (254,204) |
| `ev[05]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Condition Check #23 AND Condition Check #106 AND Player within Box [5..13, 255..254] | Warp to Castle HQ (12, 0, 96); Warp Room -> Submap 12 at (240,240); Engine Action #5; Animate Door Open; Warp Town -> Area 11 Map 1 Submap 255 at (254,204) |
| `ev[06]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Condition Check #23 AND Condition Check #106 AND Player within Box [5..12, 255..254] | Clear Story Milestone Flag 31 (mask 12); Engine Action #240; Engine Action #240; Engine Action #6; Animate Door Open; Warp Town -> Area 11 Map 1 Submap 255 at (254,204) |
| `ev[07]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Condition Check #23 AND Condition Check #106 AND Player within Box [5..13, 255..254] | Warp to Castle HQ (12, 0, 96); Warp Room -> Submap 12 at (240,240); Engine Action #6; Animate Door Open; Warp Town -> Area 11 Map 1 Submap 255 at (254,204) |
| `ev[08]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Condition Check #23 AND Condition Check #106 AND Player within Box [5..12, 255..254] | Clear Story Milestone Flag 31 (mask 12); Engine Action #240; Engine Action #240; Pan Camera (14, 2, 11); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[09]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Condition Check #23 AND Condition Check #106 AND Player within Box [5..13, 255..254] | Warp to Castle HQ (12, 0, 96); Warp Room -> Submap 12 at (240,240); Pan Camera (14, 2, 11); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[10]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Condition Check #23 AND Condition Check #106 AND Player within Box [5..12, 255..254] | Clear Story Milestone Flag 31 (mask 12); Engine Action #240; Engine Action #240; Reset Camera Tracking (14); Warp Town -> Area 11 Map 1 Submap 255 at (254,204) |
| `ev[11]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Condition Check #23 AND Condition Check #106 AND Player within Box [5..13, 255..254] | Warp to Castle HQ (12, 0, 96); Warp Room -> Submap 12 at (240,240); Reset Camera Tracking (14); Warp Town -> Area 11 Map 1 Submap 255 at (254,204) |
| `ev[12]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #106 AND Player within Box [5..12, 255..254] | Clear Story Milestone Flag 31 (mask 12); Engine Action #240; Engine Action #240; Open Dialogue Message Window; Animate Door Open; Warp Town -> Area 11 Map 1 Submap 255 at (254,204) |
| `ev[13]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #106 AND Player within Box [5..13, 255..254] | Warp to Castle HQ (12, 0, 96); Warp Room -> Submap 12 at (240,240); Open Dialogue Message Window; Animate Door Open; Warp Town -> Area 11 Map 1 Submap 255 at (254,204) |
| `ev[14]` | `128 (Loop)` | Player within Box [20..39, 2..34] AND Condition Check #63 AND Story Flag 144 (bit 32) CLEAR | Warp Room -> Submap 0 at (10,0) |
| `ev[15]` | `128 (Loop)` | Player within Box [20..39, 2..34] AND Condition Check #63 AND Story Flag 144 (bit 32) SET | Warp Room -> Submap 0 at (10,33) |
| `ev[16]` | `1 (Action / Talk)` | Player within Box [24..30, 2..66] AND Condition Check #67 AND Story Flag 0 (mask 255) SET | Engine Action #111; Award Potch Loot (+1,280 Potch); Warp Room -> Submap 3 at (4,255) facing South (Down); Warp Room -> Submap 3 at (2,96) facing 83; Warp Town -> Area 32 Map 3 Submap 1 at (96,83); Warp to Castle HQ (255, 4, 32); Warp to Castle HQ (0, 96, 83) |
| `ev[17]` | `1 (Action / Talk)` | Player within Box [22..26, 2..30] AND Condition Check #31 AND Story Flag 1 (mask 23) SET AND Condition Check #111 AND Player Y within Range [255..254] | Display Dialogue Box [Bank: 9, MsgID: 35]; Set Entity Movement Speed (255, 254) |
| `ev[18]` | `1 (Action / Talk)` | Player within Box [22..26, 2..30] AND Condition Check #31 AND Story Flag 1 (mask 24) SET AND Condition Check #111 AND Player Y within Range [255..254] | Display Dialogue Box [Bank: 10, MsgID: 101]; Set Entity Movement Speed (255, 254) |
| `ev[19]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [3..255] | Open Dialogue Message Window; Show Dialogue Portrait (255, 254, 204) |
| `ev[20]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #23 AND Condition Check #30 AND Player Y within Range [255..254] | Open Dialogue Message Window; Dismiss Dialogue Portrait |
| `ev[21]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [3..255] | Open Dialogue Message Window; Change Portrait Expression (255) |
| `ev[22]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [4..255] | Open Dialogue Message Window; Display Speaker Name Box (255) |
| `ev[23]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #23 AND Condition Check #48 AND Player Y within Range [255..254] | Open Dialogue Message Window; Display Choice Selection (255, 254) |
| `ev[24]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #23 AND Condition Check #92 AND Player Y within Range [255..254] | Open Dialogue Message Window; Branch on Choice (255, 254) |
| `ev[25]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [4..255] | Open Dialogue Message Window; Execute Choice Result (255) |
| `ev[26]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [3..255] | Open Dialogue Message Window; Set Story Flag (255, 254) |
| `ev[27]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #23 AND Condition Check #100 AND Player Y within Range [255..254] | Open Dialogue Message Window; Open Dialogue Sub-Window (255) |
| `ev[28]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #23 AND Condition Check #115 AND Player Y within Range [255..254] | Open Dialogue Message Window; Close Dialogue Sub-Window (255) |
| `ev[29]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [4..255] | Open Dialogue Message Window; Clear Dialogue Sub-Window |
| `ev[30]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[15] | Close Dialogue Sub-Window (15); Engine Action #9; Clear Dialogue Sub-Window |
| `ev[31]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[15] | Close Dialogue Sub-Window (15); Screen Fade Transition (25, 255, 254) |
| `ev[32]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[15] | Close Dialogue Sub-Window (15); Close Dialogue Window; Clear Dialogue Sub-Window |
| `ev[33]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Close Dialogue Sub-Window (15); Warp to Castle HQ (25, 255, 254) |
| `ev[34]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[16] | Close Dialogue Sub-Window (16); Engine Action #9; Fade In from Black (255) |
| `ev[35]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[16] | Close Dialogue Sub-Window (16); Screen Fade Transition (26, 255, 254) |
| `ev[36]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[16] | Close Dialogue Sub-Window (16); Close Dialogue Window; Fade In from Black (255) |
| `ev[37]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Close Dialogue Sub-Window (16); Warp to Castle HQ (26, 255, 254) |
| `ev[38]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[17] | Close Dialogue Sub-Window (17); Engine Action #9; Fade Out to Black (255) |
| `ev[39]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[17] | Close Dialogue Sub-Window (17); Screen Fade Transition (27, 255, 254) |
| `ev[40]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[17] | Close Dialogue Sub-Window (17); Close Dialogue Window; Fade Out to Black (255) |
| `ev[41]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Close Dialogue Sub-Window (17); Warp to Castle HQ (27, 255, 254) |
| `ev[42]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[18] | Close Dialogue Sub-Window (18); Engine Action #9; Display Chapter Text (255) |
| `ev[43]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[18] | Close Dialogue Sub-Window (18); Screen Fade Transition (28, 255, 254) |
| `ev[44]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[18] | Close Dialogue Sub-Window (18); Close Dialogue Window; Display Chapter Text (255) |
| `ev[45]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Close Dialogue Sub-Window (18); Warp to Castle HQ (28, 255, 254) |
| `ev[46]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[19] | Close Dialogue Sub-Window (19); Engine Action #9; Display Emotion Bubble (3, 19); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[47]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[19] | Close Dialogue Sub-Window (19); Screen Fade Transition (29, 3, 19); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[48]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[19] | Close Dialogue Sub-Window (19); Close Dialogue Window; Display Emotion Bubble (3, 19); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[49]` | `1 (Action / Talk)` | Target Inspected is obj[19] | Close Dialogue Sub-Window (19); Warp to Castle HQ (29, 3, 19); Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[50]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[20] | Close Dialogue Sub-Window (20); Engine Action #9; Dismiss Emotion Bubble (3); Branch on Choice (1, 255) |
| `ev[51]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[20] | Close Dialogue Sub-Window (20); Screen Fade Transition (30, 3, 20); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[52]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[20] | Close Dialogue Sub-Window (20); Close Dialogue Window; Dismiss Emotion Bubble (3); Branch on Choice (1, 255) |
| `ev[53]` | `1 (Action / Talk)` | Target Inspected is obj[20] | Close Dialogue Sub-Window (20); Warp to Castle HQ (30, 3, 20); Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[54]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[21] | Close Dialogue Sub-Window (21); Engine Action #9; Warp Room -> Submap 3 at (21,1) |
| `ev[55]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[21] | Close Dialogue Sub-Window (21); Screen Fade Transition (31, 3, 21); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[56]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[21] | Close Dialogue Sub-Window (21); Close Dialogue Window; Warp Room -> Submap 3 at (21,1) |
| `ev[57]` | `1 (Action / Talk)` | Target Inspected is obj[21] | Close Dialogue Sub-Window (21); Warp to Castle HQ (31, 3, 21); Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[58]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[22] | Close Dialogue Sub-Window (22); Engine Action #9; Warp Map Transition (3, 22, 0, 255, 254) |
| `ev[59]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[22] | Close Dialogue Sub-Window (22); Screen Fade Transition (32, 3, 22); Open Dialogue Message Window |
| `ev[60]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[22] | Close Dialogue Sub-Window (22); Close Dialogue Window; Warp Map Transition (3, 22, 0, 255, 254) |
| `ev[61]` | `1 (Action / Talk)` | Target Inspected is obj[22] | Close Dialogue Sub-Window (22); Warp to Castle HQ (32, 3, 22); Open Dialogue Message Window |
| `ev[62]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[23] | Close Dialogue Sub-Window (23); Engine Action #9; Return to Previous Memory Map (3); Open Dialogue Sub-Window (0) |
| `ev[63]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[23] | Close Dialogue Sub-Window (23); Screen Fade Transition (33, 3, 23); Open Dialogue Message Window |
| `ev[64]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[23] | Close Dialogue Sub-Window (23); Close Dialogue Window; Return to Previous Memory Map (3); Open Dialogue Sub-Window (0) |
| `ev[65]` | `1 (Action / Talk)` | Target Inspected is obj[23] | Close Dialogue Sub-Window (23); Warp to Castle HQ (33, 3, 23); Open Dialogue Message Window |
| `ev[66]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[24] | Close Dialogue Sub-Window (24); Engine Action #9; Return Warp to Castle Base (3, 24); Warp to Castle HQ (255, 254, 204) |
| `ev[67]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[24] | Close Dialogue Sub-Window (24); Screen Fade Transition (34, 3, 24); Warp to Castle HQ (255, 254, 204) |
| `ev[68]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[24] | Close Dialogue Sub-Window (24); Close Dialogue Window; Return Warp to Castle Base (3, 24); Warp to Castle HQ (255, 254, 204) |
| `ev[69]` | `1 (Action / Talk)` | Target Inspected is obj[24] | Close Dialogue Sub-Window (24); Warp to Castle HQ (34, 3, 24); Warp to Castle HQ (255, 254, 255) |
| `ev[70]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[25] | Close Dialogue Sub-Window (25); Engine Action #9; Start Boss Battle #3 (BGM: 25); Warp to Castle HQ (255, 254, 204) |
| `ev[71]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[25] | Close Dialogue Sub-Window (25); Screen Fade Transition (35, 3, 25); Warp to Castle HQ (255, 254, 204) |
| `ev[72]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[25] | Close Dialogue Sub-Window (25); Close Dialogue Window; Start Boss Battle #3 (BGM: 25); Warp to Castle HQ (255, 254, 204) |
| `ev[73]` | `1 (Action / Talk)` | Target Inspected is obj[25] | Close Dialogue Sub-Window (25); Warp to Castle HQ (35, 3, 25); Warp to Castle HQ (255, 254, 255) |
| `ev[74]` | `1 (Action / Talk)` | Target Inspected is obj[8] | Open Dialogue Sub-Window (1); Dismiss Character to Castle Base (255) |
| `ev[75]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Open Dialogue Sub-Window (1); Engine Action #85 |
| `ev[76]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Open Dialogue Sub-Window (1); Animate Door obj[255] (State: 254) |
| `ev[77]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Open Dialogue Sub-Window (1); Engine Action #87 |

---

### Submap Layer `vk02_12` (Index 12)

- **Map Number (`mapno`)**: `6`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `8` Objects | **Script Count (`evkaz`)**: `17` Scripts

#### Complete Physical Entity Inventory (8 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(30, 34)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[01]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(30, 32)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(35, 41)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(35, 47)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(37, 33)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(41, 33)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(44, 33)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | NPC / Actor | **Actor ID 65213** | `65213` | `(88, 47)` | `3x7` | Up (North) | Dormant / Hidden (0) | Special (3) | 1 | 128 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(30, 34)` to `(32, 36)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[01]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(30, 32)` to `(32, 34)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[02]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(35, 41)` to `(36, 42)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[03]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(35, 47)` to `(36, 48)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[04]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(37, 33)` to `(38, 34)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[05]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(41, 33)` to `(42, 34)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[06]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(44, 33)` to `(45, 34)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[07]` (Object 65213)**: Positioned at tile `(88, 47)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.


#### Complete Bytecode Script Catalog (17 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `128 (Loop)` | Player within Box [81..111, 2..34] AND Condition Check #63 AND Story Flag 144 (bit 32) CLEAR | Warp Room -> Submap 0 at (10,0) |
| `ev[01]` | `128 (Loop)` | Player within Box [81..111, 2..34] AND Condition Check #63 AND Story Flag 144 (bit 32) SET | Warp Room -> Submap 0 at (10,33) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [84..90, 2..66] AND Condition Check #67 AND Story Flag 0 (mask 255) SET | Engine Action #111; Award Potch Loot (+1,280 Potch); Warp Room -> Submap 3 at (4,255) facing South (Down); Warp Room -> Submap 3 at (2,96) facing 83; Warp Town -> Area 32 Map 3 Submap 1 at (96,83); Warp to Castle HQ (255, 4, 32); Warp to Castle HQ (0, 96, 83) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [82..86, 2..30] AND Condition Check #31 AND Story Flag 1 (mask 23) SET AND Condition Check #111 AND Player Y within Range [255..254] | Display Dialogue Box [Bank: 9, MsgID: 35]; Set Entity Movement Speed (255, 254) |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [82..86, 2..30] AND Condition Check #31 AND Story Flag 1 (mask 24) SET AND Condition Check #111 AND Player Y within Range [255..254] | Display Dialogue Box [Bank: 10, MsgID: 101]; Set Entity Movement Speed (255, 254) |
| `ev[05]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [3..255] | Open Dialogue Message Window; Show Dialogue Portrait (255, 254, 204) |
| `ev[06]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[15] | Close Dialogue Sub-Window (15); Engine Action #9; Launch Tactical War Battle (255) |
| `ev[07]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[15] | Close Dialogue Sub-Window (15); Screen Fade Transition (36, 255, 254) |
| `ev[08]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[15] | Close Dialogue Sub-Window (15); Close Dialogue Window; Launch Tactical War Battle (255) |
| `ev[09]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Close Dialogue Sub-Window (15); Warp to Castle HQ (36, 255, 254) |
| `ev[10]` | `1 (Action / Talk)` | Target Inspected is obj[8] | Open Dialogue Sub-Window (1); Engine Action #88 |
| `ev[11]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Open Dialogue Sub-Window (1); Engine Action #89 |
| `ev[12]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Open Dialogue Sub-Window (1); Engine Action #90 |
| `ev[13]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Open Dialogue Sub-Window (1); Make Object Visible (disp = 1) (255) |
| `ev[14]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Open Dialogue Sub-Window (1); Make Object Hidden (disp = 0) (255) |
| `ev[15]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Open Dialogue Sub-Window (1); Engine Action #93 |
| `ev[16]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Open Dialogue Sub-Window (1); Engine Action #94 |

---


