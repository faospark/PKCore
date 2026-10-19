# Suikoden II Geographic Area Catalog: Castle HQ: Hai Yo's Restaurant & Kitchen

**Geographic Scope & Role**: Culinary arena; Hai Yo's Iron Chef cook-off dueling stadium, dining tables, food storage, and menu recipe book shelves.

**Regional Category**: Region `VK` | **Master Maps Included**: `vk20`

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

## Location Map: `vk20`

- **Master Map Container**: `vk20.json`
- **Submap Layer Files**: Embedded in master
- **Collision Grid Files**: vk20_map_00.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 2

### Submap Layer `vk20_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `22` Objects | **Script Count (`evkaz`)**: `116` Scripts

#### Complete Physical Entity Inventory (22 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Tony** | `70` | `(51, 17)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(50, 14)` | `2x2` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Miklotov** | `33` | `(21, 21)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(20, 18)` | `2x2` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | NPC / Actor | **Kinnison** | `27` | `(31, 17)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[05]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(30, 14)` | `2x2` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | NPC / Actor | **Ayda** | `43` | `(41, 21)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(40, 18)` | `2x2` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | NPC / Actor | **Chaco** | `54` | `(55, 23)` | `4x4` | South (Down) | Dormant / Hidden (0) | Special (3) | 3 | 255 | 0 |
| `obj[09]` | NPC / Actor | **Riou (Casual/Prologue)** | `48` | `(32, 28)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[10]` | NPC / Actor | **Sierra Mikain** | `44` | `(62, 14)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[11]` | NPC / Actor | **Karen** | `14` | `(60, 23)` | `0x0` | Up (North) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[12]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(12, 11)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(24, 11)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(48, 11)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[15]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(60, 11)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[16]` | NPC / Actor | **Actor ID 64541** | `64541` | `(21, 20)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[17]` | NPC / Actor | **Actor ID 64550** | `64550` | `(31, 21)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[18]` | NPC / Actor | **Actor ID 64538** | `64538` | `(51, 21)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[19]` | NPC / Actor | **Village Water Well Stone Rim** | `65202` | `(7, 20)` | `6x6` | West (Left) | Dormant / Hidden (0) | Special (3) | 2 | 255 | 0 |
| `obj[20]` | NPC / Actor | **Actor ID 64826** | `64826` | `(38, 16)` | `6x6` | West (Left) | Dormant / Hidden (0) | Special (3) | 4 | 255 | 0 |
| `obj[21]` | NPC / Actor | **Actor ID 64826** | `64826` | `(14, 15)` | `6x6` | East (Right) | Dormant / Hidden (0) | Special (3) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Tony)**: Positioned at tile `(51, 17)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(50, 14)` to `(52, 16)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[02]` (Miklotov)**: Positioned at tile `(21, 21)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(20, 18)` to `(22, 20)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[04]` (Kinnison)**: Positioned at tile `(31, 17)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(30, 14)` to `(32, 16)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[06]` (Ayda)**: Positioned at tile `(41, 21)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[07]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(40, 18)` to `(42, 20)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[08]` (Chaco)**: Positioned at tile `(55, 23)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[09]` (Riou (Casual/Prologue))**: Positioned at tile `(32, 28)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[10]` (Sierra Mikain)**: Positioned at tile `(62, 14)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[11]` (Karen)**: Positioned at tile `(60, 23)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[12]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(12, 11)` to `(13, 12)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[13]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(24, 11)` to `(25, 12)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[14]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(48, 11)` to `(49, 12)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[15]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(60, 11)` to `(61, 12)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[16]` (Object 64541)**: Positioned at tile `(21, 20)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[17]` (Object 64550)**: Positioned at tile `(31, 21)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[18]` (Object 64538)**: Positioned at tile `(51, 21)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[19]` (Village Water Well Stone Rim)**: Positioned at tile `(7, 20)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[20]` (Object 64826)**: Positioned at tile `(38, 16)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[21]` (Object 64826)**: Positioned at tile `(14, 15)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.


#### Complete Bytecode Script Catalog (116 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #23 AND Treasure Byte 1 Bit 255 LOOTED | Make obj[0] Hidden (disp = 0); Display Dialogue Box [Bank: 0, MsgID: 13]; Teleport obj[255] to (254,204) |
| `ev[01]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #70 AND Player within Box [33..1, 2..34] AND Castle HQ Tier >= Level 4 | Make obj[0] Hidden (disp = 0); Reset Camera Tracking (0); Engine Action #9; Teleport obj[255] to (254,204) |
| `ev[02]` | `2 (Map Init)` | Story Flag 47 (bit 4) CLEAR AND Condition Check #23 AND Condition Check #33 AND Player within Box [33..1, 2..34] AND Inventory Holds Item #32 | Make obj[0] Hidden (disp = 0); Screen Fade Transition (0, 11, 47) |
| `ev[03]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #43 AND Player within Box [33..1, 2..34] AND Inventory Lacks Item #1 | Make obj[0] Hidden (disp = 0); Animate Door Open; Open Dialogue Message Window; Show Dialogue Portrait (47, 255, 254) |
| `ev[04]` | `2 (Map Init)` | Story Flag 47 (bit 8) CLEAR AND Condition Check #23 AND Condition Check #54 AND Player within Box [33..1, 2..34] AND Inventory Lacks Item #4 | Open Dialogue Message Window; Dismiss Dialogue Portrait |
| `ev[05]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #44 AND Player within Box [33..1, 3..255] | Open Dialogue Message Window; Display Speaker Name Box (255) |
| `ev[06]` | `2 (Map Init)` | Condition Check #23 AND Active Party Has Character #1 AND Condition Check #33 AND Player X within Range [3..255] | Open Dialogue Message Window; Display Choice Selection (255, 254) |
| `ev[07]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[8] | Open Dialogue Sub-Window (4); Engine Action #9; Warp to Castle HQ (8, 0, 255) |
| `ev[08]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Story Flag 0 (mask 5) SET AND Story Flag 255 (mask 254) SET | Warp to Castle HQ (8, 1, 24); Reset Camera Tracking (4); Engine Action #9; Warp to Castle HQ (8, 0, 255) |
| `ev[09]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[10] | Open Dialogue Sub-Window (4); Warp Room -> Submap 10 at (0,255) facing 254 |
| `ev[10]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Story Flag 0 (mask 5) SET AND Player X in Range [255..254] | Warp to Castle HQ (10, 1, 24); Screen Fade Transition (4, 1, 3); Screen Fade Transition (0, 255, 254) |
| `ev[11]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[12] | Open Dialogue Sub-Window (4); Open Dialogue Message Window; Warp to Castle HQ (12, 0, 255) |
| `ev[12]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Story Flag 0 (mask 5) SET AND Party Holds At Least 25,500 Potch | Warp to Castle HQ (12, 1, 24); Display Dialogue Box [Bank: 4, MsgID: 0]; Warp to Castle HQ (12, 0, 255) |
| `ev[13]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[14] | Open Dialogue Sub-Window (4); Warp Town -> Area 3 Map 14 Submap 0 at (255,254) |
| `ev[14]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Story Flag 0 (mask 5) SET AND Party Formation Check | Warp to Castle HQ (14, 1, 24); Animate Door Open; Exit to World Map (2, 3, 14); Open Dialogue Message Window |
| `ev[15]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[16] | Open Dialogue Sub-Window (4); Warp to Castle HQ (255, 254, 204) |
| `ev[16]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[18] | Open Dialogue Sub-Window (4); Exit to World Map (3, 18, 0) |
| `ev[17]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[19] | Open Dialogue Sub-Window (4); Engine Action #5; Warp to Castle HQ (19, 2, 255) |
| `ev[18]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[8] | Open Dialogue Sub-Window (5); Engine Action #9; Warp to Castle HQ (8, 0, 255) |
| `ev[19]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Story Flag 0 (mask 5) SET AND Story Flag 255 (mask 254) SET | Warp to Castle HQ (8, 1, 24); Reset Camera Tracking (5); Engine Action #9; Warp to Castle HQ (8, 0, 255) |
| `ev[20]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[10] | Open Dialogue Sub-Window (5); Warp Room -> Submap 10 at (0,255) facing 254 |
| `ev[21]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Story Flag 0 (mask 5) SET AND Player X in Range [255..254] | Warp to Castle HQ (10, 1, 24); Screen Fade Transition (5, 1, 3); Screen Fade Transition (0, 255, 254) |
| `ev[22]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[12] | Open Dialogue Sub-Window (5); Open Dialogue Message Window; Warp to Castle HQ (12, 0, 255) |
| `ev[23]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Story Flag 0 (mask 5) SET AND Party Holds At Least 25,500 Potch | Warp to Castle HQ (12, 1, 24); Display Dialogue Box [Bank: 5, MsgID: 0]; Warp to Castle HQ (12, 0, 255) |
| `ev[24]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[14] | Open Dialogue Sub-Window (5); Warp Town -> Area 3 Map 14 Submap 0 at (255,254) |
| `ev[25]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Story Flag 0 (mask 5) SET AND Party Formation Check | Warp to Castle HQ (14, 1, 24); Animate Door Open; Engine Action #5; Warp Town -> Area 3 Map 14 Submap 0 at (255,254) |
| `ev[26]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[16] | Open Dialogue Sub-Window (5); Warp to Castle HQ (255, 254, 204) |
| `ev[27]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[18] | Open Dialogue Sub-Window (5); Exit to World Map (3, 18, 0) |
| `ev[28]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[19] | Open Dialogue Sub-Window (5); Engine Action #5; Warp to Castle HQ (19, 2, 255) |
| `ev[29]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[8] | Open Dialogue Sub-Window (6); Engine Action #9; Warp to Castle HQ (8, 0, 255) |
| `ev[30]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Story Flag 0 (mask 5) SET AND Story Flag 255 (mask 254) SET | Warp to Castle HQ (8, 1, 24); Reset Camera Tracking (6); Engine Action #9; Warp to Castle HQ (8, 0, 255) |
| `ev[31]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[10] | Open Dialogue Sub-Window (6); Warp Room -> Submap 10 at (0,255) facing 254 |
| `ev[32]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Story Flag 0 (mask 5) SET AND Player X in Range [255..254] | Warp to Castle HQ (10, 1, 24); Screen Fade Transition (6, 1, 3); Screen Fade Transition (0, 255, 254) |
| `ev[33]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[12] | Open Dialogue Sub-Window (6); Open Dialogue Message Window; Warp to Castle HQ (12, 0, 255) |
| `ev[34]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Story Flag 0 (mask 5) SET AND Party Holds At Least 25,500 Potch | Warp to Castle HQ (12, 1, 24); Display Dialogue Box [Bank: 6, MsgID: 0]; Warp to Castle HQ (12, 0, 255) |
| `ev[35]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[14] | Open Dialogue Sub-Window (6); Warp Town -> Area 3 Map 14 Submap 0 at (255,254) |
| `ev[36]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Story Flag 0 (mask 5) SET AND Party Formation Check | Warp to Castle HQ (14, 1, 24); Animate Door Open; Engine Action #6; Warp Town -> Area 3 Map 14 Submap 0 at (255,254) |
| `ev[37]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[16] | Open Dialogue Sub-Window (6); Warp to Castle HQ (255, 254, 204) |
| `ev[38]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[18] | Open Dialogue Sub-Window (6); Exit to World Map (3, 18, 0) |
| `ev[39]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[19] | Open Dialogue Sub-Window (6); Engine Action #5; Warp to Castle HQ (19, 2, 255) |
| `ev[40]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[8] | Open Dialogue Sub-Window (7); Engine Action #9; Warp to Castle HQ (8, 0, 255) |
| `ev[41]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Story Flag 0 (mask 5) SET AND Story Flag 255 (mask 254) SET | Warp to Castle HQ (8, 1, 24); Reset Camera Tracking (7); Engine Action #9; Warp to Castle HQ (8, 0, 255) |
| `ev[42]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[10] | Open Dialogue Sub-Window (7); Warp Room -> Submap 10 at (0,255) facing 254 |
| `ev[43]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Story Flag 0 (mask 5) SET AND Player X in Range [255..254] | Warp to Castle HQ (10, 1, 24); Screen Fade Transition (7, 1, 3); Screen Fade Transition (0, 255, 254) |
| `ev[44]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[12] | Open Dialogue Sub-Window (7); Open Dialogue Message Window; Warp to Castle HQ (12, 0, 255) |
| `ev[45]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Story Flag 0 (mask 5) SET AND Party Holds At Least 25,500 Potch | Warp to Castle HQ (12, 1, 24); Display Dialogue Box [Bank: 7, MsgID: 0]; Warp to Castle HQ (12, 0, 255) |
| `ev[46]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[14] | Open Dialogue Sub-Window (7); Warp Town -> Area 3 Map 14 Submap 0 at (255,254) |
| `ev[47]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Story Flag 0 (mask 5) SET AND Party Formation Check | Warp to Castle HQ (14, 1, 24); Animate Door Open; Pan Camera (2, 3, 14); Open Dialogue Message Window |
| `ev[48]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[16] | Open Dialogue Sub-Window (7); Warp to Castle HQ (255, 254, 204) |
| `ev[49]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[18] | Open Dialogue Sub-Window (7); Exit to World Map (3, 18, 0) |
| `ev[50]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[19] | Open Dialogue Sub-Window (7); Engine Action #5; Warp to Castle HQ (19, 2, 255) |
| `ev[51]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[8] | Open Dialogue Sub-Window (8); Engine Action #9; Warp to Castle HQ (8, 0, 255) |
| `ev[52]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Story Flag 0 (mask 5) SET AND Story Flag 255 (mask 254) SET | Warp to Castle HQ (8, 1, 24); Reset Camera Tracking (8); Engine Action #9; Warp to Castle HQ (8, 0, 255) |
| `ev[53]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[10] | Open Dialogue Sub-Window (8); Warp Room -> Submap 10 at (0,255) facing 254 |
| `ev[54]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Story Flag 0 (mask 5) SET AND Player X in Range [255..254] | Warp to Castle HQ (10, 1, 24); Screen Fade Transition (8, 1, 3); Screen Fade Transition (0, 255, 254) |
| `ev[55]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[12] | Open Dialogue Sub-Window (8); Open Dialogue Message Window; Warp to Castle HQ (12, 0, 255) |
| `ev[56]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Story Flag 0 (mask 5) SET AND Party Holds At Least 25,500 Potch | Warp to Castle HQ (12, 1, 24); Display Dialogue Box [Bank: 8, MsgID: 0]; Warp to Castle HQ (12, 0, 255) |
| `ev[57]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[14] | Open Dialogue Sub-Window (8); Warp Town -> Area 3 Map 14 Submap 0 at (255,254) |
| `ev[58]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Story Flag 0 (mask 5) SET AND Party Formation Check | Warp to Castle HQ (14, 1, 24); Animate Door Open; Reset Camera Tracking (2); Warp to Castle HQ (14, 0, 255) |
| `ev[59]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[16] | Open Dialogue Sub-Window (8); Warp to Castle HQ (255, 254, 204) |
| `ev[60]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[18] | Open Dialogue Sub-Window (8); Exit to World Map (3, 18, 0) |
| `ev[61]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[19] | Open Dialogue Sub-Window (8); Engine Action #5; Warp to Castle HQ (19, 2, 255) |
| `ev[62]` | `1 (Action / Talk)` | Target Inspected is obj[8] | Open Dialogue Sub-Window (1); Engine Action #9; Warp to Castle HQ (8, 0, 255) |
| `ev[63]` | `1 (Action / Talk)` | Story Flag 0 (mask 5) SET AND Story Flag 255 (mask 254) SET | Warp to Castle HQ (8, 1, 24); Reset Camera Tracking (1); Engine Action #9; Warp to Castle HQ (8, 0, 255) |
| `ev[64]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Open Dialogue Sub-Window (1); Warp Room -> Submap 10 at (0,255) facing 254 |
| `ev[65]` | `1 (Action / Talk)` | Story Flag 0 (mask 5) SET AND Player X in Range [255..254] | Warp to Castle HQ (10, 1, 24); Screen Fade Transition (1, 1, 3); Screen Fade Transition (0, 255, 254) |
| `ev[66]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Open Dialogue Sub-Window (1); Open Dialogue Message Window; Warp to Castle HQ (12, 0, 255) |
| `ev[67]` | `1 (Action / Talk)` | Story Flag 0 (mask 5) SET AND Party Holds At Least 25,500 Potch | Warp to Castle HQ (12, 1, 24); Display Dialogue Box [Bank: 1, MsgID: 0]; Warp to Castle HQ (12, 0, 255) |
| `ev[68]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Open Dialogue Sub-Window (1); Warp Town -> Area 3 Map 14 Submap 0 at (255,254) |
| `ev[69]` | `1 (Action / Talk)` | Story Flag 0 (mask 5) SET AND Party Formation Check | Warp to Castle HQ (14, 1, 24); Animate Door Open; Warp Room -> Submap 3 at (14,0) facing 255 |
| `ev[70]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Open Dialogue Sub-Window (1); Warp to Castle HQ (255, 254, 204) |
| `ev[71]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Open Dialogue Sub-Window (1); Exit to World Map (3, 18, 0) |
| `ev[72]` | `1 (Action / Talk)` | Target Inspected is obj[19] | Open Dialogue Sub-Window (1); Engine Action #5; Warp to Castle HQ (19, 2, 255) |
| `ev[73]` | `128 (Loop)` | Player within Box [6..63, 2..12] AND Condition Check #30 | Warp Room -> Submap 0 at (10,5) |
| `ev[74]` | `1 (Action / Talk)` | Player within Box [14..22, 2..7] AND Temp Event Flag #9 CLEAR AND Player within Box [23..66, 2..255] | Warp Map Transition (3, 2, 30, 65, 255) |
| `ev[75]` | `1 (Action / Talk)` | Player within Box [26..34, 2..7] AND Temp Event Flag #9 CLEAR AND Player within Box [23..66, 2..255] | Warp Map Transition (3, 2, 42, 65, 255) |
| `ev[76]` | `1 (Action / Talk)` | Player within Box [38..46, 2..7] AND Temp Event Flag #9 CLEAR AND Player within Box [23..66, 2..255] | Warp Map Transition (3, 2, 54, 65, 255) |
| `ev[77]` | `1 (Action / Talk)` | Player within Box [50..58, 2..7] AND Temp Event Flag #9 CLEAR AND Player within Box [23..66, 2..255] | Warp Map Transition (3, 2, 66, 65, 255) |
| `ev[78]` | `1 (Action / Talk)` | Player within Box [14..22, 2..7] AND Temp Event Flag #9 CLEAR AND Player within Box [24..66, 2..255] | Warp Map Transition (3, 3, 30, 137, 255) |
| `ev[79]` | `1 (Action / Talk)` | Player within Box [26..34, 2..7] AND Temp Event Flag #9 CLEAR AND Player within Box [24..66, 2..255] | Warp Map Transition (3, 3, 42, 137, 255) |
| `ev[80]` | `1 (Action / Talk)` | Player within Box [38..46, 2..7] AND Temp Event Flag #9 CLEAR AND Player within Box [24..66, 2..255] | Warp Map Transition (3, 3, 54, 137, 255) |
| `ev[81]` | `1 (Action / Talk)` | Player within Box [50..58, 2..7] AND Temp Event Flag #9 CLEAR AND Player within Box [24..66, 2..255] | Warp Map Transition (3, 3, 66, 137, 255) |
| `ev[82]` | `2 (Map Init)` | Condition Check #33 AND Player within Box [2..35, 21..32] | Open Dialogue Message Window; Close Dialogue Sub-Window (255) |
| `ev[83]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [1..255] | Open Dialogue Message Window; Clear Dialogue Sub-Window |
| `ev[84]` | `2 (Map Init)` | Condition Check #33 AND Player X within Range [3..255] | Open Dialogue Message Window; Fade In from Black (255) |
| `ev[85]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [2..255] | Open Dialogue Message Window; Fade Out to Black (255) |
| `ev[86]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [1..255] | Open Dialogue Message Window; Display Chapter Text (255) |
| `ev[87]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [3..255] | Open Dialogue Message Window; Display Emotion Bubble (255, 254) |
| `ev[88]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[24] | Close Dialogue Sub-Window (24); Engine Action #9; Open Dialogue Message Window; Warp to Castle HQ (24, 0, 255) |
| `ev[89]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[25] | Close Dialogue Sub-Window (25); Engine Action #9; Warp Room -> Submap 25 at (1,255) facing 254 |
| `ev[90]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[26] | Close Dialogue Sub-Window (26); Engine Action #9; Warp Town -> Area 3 Map 26 Submap 1 at (255,254) |
| `ev[91]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[27] | Close Dialogue Sub-Window (27); Engine Action #9; Warp to Castle HQ (3, 27, 1) |
| `ev[92]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[28] | Close Dialogue Sub-Window (28); Engine Action #9; Exit to World Map (255, 254, 255) |
| `ev[93]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[29] | Close Dialogue Sub-Window (29); Engine Action #9; Engine Action #5 |
| `ev[94]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[24] | Close Dialogue Sub-Window (24); Screen Fade Transition (0, 3, 24); Open Dialogue Message Window |
| `ev[95]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[25] | Close Dialogue Sub-Window (25); Screen Fade Transition (1, 3, 25); Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[96]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[26] | Close Dialogue Sub-Window (26); Screen Fade Transition (2, 3, 26); Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[97]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[27] | Close Dialogue Sub-Window (27); Screen Fade Transition (3, 3, 27); Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[98]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[28] | Close Dialogue Sub-Window (28); Screen Fade Transition (4, 255, 254) |
| `ev[99]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[29] | Close Dialogue Sub-Window (29); Screen Fade Transition (5, 255, 254) |
| `ev[100]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[24] | Close Dialogue Sub-Window (24); Close Dialogue Window; Open Dialogue Message Window; Warp to Castle HQ (24, 0, 255) |
| `ev[101]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[25] | Close Dialogue Sub-Window (25); Close Dialogue Window; Warp Room -> Submap 25 at (1,255) facing 254 |
| `ev[102]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[26] | Close Dialogue Sub-Window (26); Close Dialogue Window; Warp Town -> Area 3 Map 26 Submap 1 at (255,254) |
| `ev[103]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[27] | Close Dialogue Sub-Window (27); Close Dialogue Window; Warp to Castle HQ (3, 27, 1) |
| `ev[104]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[28] | Close Dialogue Sub-Window (28); Close Dialogue Window; Exit to World Map (255, 254, 255) |
| `ev[105]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[29] | Close Dialogue Sub-Window (29); Close Dialogue Window; Engine Action #5 |
| `ev[106]` | `1 (Action / Talk)` | Target Inspected is obj[24] | Close Dialogue Sub-Window (24); Warp Town -> Area 0 Map 3 Submap 24 at (0,255) |
| `ev[107]` | `1 (Action / Talk)` | Target Inspected is obj[25] | Close Dialogue Sub-Window (25); Warp Town -> Area 1 Map 3 Submap 25 at (1,255) |
| `ev[108]` | `1 (Action / Talk)` | Target Inspected is obj[26] | Close Dialogue Sub-Window (26); Warp Town -> Area 2 Map 3 Submap 26 at (1,255) |
| `ev[109]` | `1 (Action / Talk)` | Target Inspected is obj[27] | Close Dialogue Sub-Window (27); Warp Town -> Area 3 Map 3 Submap 27 at (1,255) |
| `ev[110]` | `1 (Action / Talk)` | Target Inspected is obj[28] | Close Dialogue Sub-Window (28); Warp Town -> Area 4 Map 255 Submap 254 at (255,254) |
| `ev[111]` | `1 (Action / Talk)` | Target Inspected is obj[29] | Close Dialogue Sub-Window (29); Warp Town -> Area 5 Map 255 Submap 254 at (255,254) |
| `ev[112]` | `1 (Action / Talk)` | Target Inspected is obj[20] | Close Dialogue Sub-Window (20); Warp to Castle HQ (0, 255, 254) |
| `ev[113]` | `1 (Action / Talk)` | Target Inspected is obj[21] | Close Dialogue Sub-Window (21); Warp to Castle HQ (1, 255, 254) |
| `ev[114]` | `1 (Action / Talk)` | Target Inspected is obj[22] | Close Dialogue Sub-Window (22); Warp to Castle HQ (2, 255, 254) |
| `ev[115]` | `1 (Action / Talk)` | Target Inspected is obj[23] | Close Dialogue Sub-Window (23); Warp to Castle HQ (3, 255, 254) |

---

### Submap Layer `vk20_01` (Index 1)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `19` Objects | **Script Count (`evkaz`)**: `94` Scripts

#### Complete Physical Entity Inventory (19 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Futch** | `101` | `(17, 17)` | `5x5` | South (Down) | Dormant / Hidden (0) | Special (3) | 3 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Fitcher** | `15` | `(23, 20)` | `5x5` | South (Down) | Dormant / Hidden (0) | Special (3) | 3 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Miklotov** | `33` | `(39, 17)` | `5x5` | South (Down) | Dormant / Hidden (0) | Special (3) | 3 | 255 | 0 |
| `obj[03]` | NPC / Actor | **Kinnison** | `27` | `(50, 18)` | `5x5` | South (Down) | Dormant / Hidden (0) | Special (3) | 3 | 255 | 0 |
| `obj[04]` | NPC / Actor | **Ayda** | `43` | `(9, 14)` | `5x5` | South (Down) | Dormant / Hidden (0) | Special (3) | 3 | 255 | 0 |
| `obj[05]` | NPC / Actor | **Chaco** | `54` | `(15, 21)` | `5x5` | South (Down) | Dormant / Hidden (0) | Special (3) | 3 | 255 | 0 |
| `obj[06]` | NPC / Actor | **Riou (Casual/Prologue)** | `48` | `(32, 28)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[07]` | NPC / Actor | **Sierra Mikain** | `44` | `(62, 14)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[08]` | NPC / Actor | **Karen** | `14` | `(8, 13)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[09]` | NPC / Actor | **Actor ID 65089** | `65089` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | NPC / Actor | **Actor ID 66** | `66` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(12, 11)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(24, 11)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(35, 11)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(48, 11)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[15]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(60, 11)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[16]` | NPC / Actor | **Village Water Well Stone Rim** | `65202` | `(7, 20)` | `6x6` | East (Right) | Dormant / Hidden (0) | Special (3) | 2 | 255 | 0 |
| `obj[17]` | NPC / Actor | **Actor ID 65181** | `65181` | `(32, 19)` | `6x6` | West (Left) | Dormant / Hidden (0) | Special (3) | 3 | 255 | 0 |
| `obj[18]` | NPC / Actor | **Actor ID 65220** | `65220` | `(44, 15)` | `6x6` | South (Down) | Dormant / Hidden (0) | Special (3) | 1 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Futch)**: Positioned at tile `(17, 17)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Fitcher)**: Positioned at tile `(23, 20)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Miklotov)**: Positioned at tile `(39, 17)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Kinnison)**: Positioned at tile `(50, 18)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Ayda)**: Positioned at tile `(9, 14)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Chaco)**: Positioned at tile `(15, 21)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[06]` (Riou (Casual/Prologue))**: Positioned at tile `(32, 28)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[07]` (Sierra Mikain)**: Positioned at tile `(62, 14)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[08]` (Karen)**: Positioned at tile `(8, 13)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[09]` (Object 65089)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[10]` (Object 66)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[11]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(12, 11)` to `(13, 12)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[12]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(24, 11)` to `(25, 12)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[13]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(35, 11)` to `(36, 12)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[14]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(48, 11)` to `(49, 12)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[15]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(60, 11)` to `(61, 12)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[16]` (Village Water Well Stone Rim)**: Positioned at tile `(7, 20)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[17]` (Object 65181)**: Positioned at tile `(32, 19)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[18]` (Object 65220)**: Positioned at tile `(44, 15)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.


#### Complete Bytecode Script Catalog (94 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 46 (bit 128) CLEAR AND Condition Check #23 AND Condition Check #101 AND Player within Box [33..0, 1..255] | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[01]` | `2 (Map Init)` | Story Flag 48 (bit 4) CLEAR AND Condition Check #23 AND Party Formation Check AND Player within Box [33..0, 1..255] | Open Dialogue Message Window; Engine Action #9 |
| `ev[02]` | `2 (Map Init)` | Story Flag 47 (bit 8) CLEAR AND Condition Check #23 AND Condition Check #54 AND Player within Box [33..0, 1..255] | Open Dialogue Message Window; Place Scenery Structure (255) |
| `ev[03]` | `2 (Map Init)` | Story Flag 47 (bit 4) CLEAR AND Condition Check #23 AND Condition Check #33 AND Player within Box [33..0, 1..255] | Open Dialogue Message Window; Screen Fade Transition (255, 254, 204) |
| `ev[04]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #23 AND Treasure Byte 1 Bit 255 LOOTED | Open Dialogue Message Window; Close Dialogue Window |
| `ev[05]` | `2 (Map Init)` | Story Flag 47 (bit 4) CLEAR AND Condition Check #23 AND Condition Check #33 AND Player within Box [33..1, 2..34] AND Inventory Holds Item #32 | Open Dialogue Message Window; Screen Fade Transition (255, 254, 204) |
| `ev[06]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #43 AND Player within Box [33..1, 2..34] AND Inventory Lacks Item #1 | Open Dialogue Message Window; Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[07]` | `2 (Map Init)` | Story Flag 47 (bit 8) CLEAR AND Condition Check #23 AND Condition Check #54 AND Player within Box [33..1, 2..34] AND Inventory Lacks Item #4 | Open Dialogue Message Window; Place Scenery Structure (255) |
| `ev[08]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #44 AND Player within Box [33..1, 3..255] | Open Dialogue Message Window; Show Dialogue Portrait (255, 254, 204) |
| `ev[09]` | `2 (Map Init)` | Condition Check #23 AND Active Party Has Character #1 AND Condition Check #33 AND Player X within Range [3..255] | Open Dialogue Message Window; Dismiss Dialogue Portrait |
| `ev[10]` | `2 (Map Init)` | Story Flag 151 (bit 64) CLEAR AND Condition Check #24 AND Condition Check #66 AND Player Y within Range [4..145] AND Player within Box [33..1, 2..255] | Make obj[2] Hidden (disp = 0); Change Portrait Expression (28); Fade In from Black (3); Change Portrait Expression (3); Open Dialogue Message Window; Change Portrait Expression (2); Display Speaker Name Box (32); Fade In from Black (3); Display Speaker Name Box (2); Open Dialogue Message Window; Display Speaker Name Box (1); Reset Camera Tracking (1); Engine Action #9; Warp Room -> Submap 1 at (10,1) facing 11; Warp Room -> Submap 1 at (14,1) facing 15; Warp Room -> Submap 47 at (255,254) facing 204 |
| `ev[11]` | `1 (Action / Talk)` | Story Flag 151 (bit 64) CLEAR AND Condition Check #24 AND Condition Check #66 AND Player Y within Range [4..145] AND Player within Box [33..1, 2..255] | Dismiss Character to Castle Base (66); Dismiss Emotion Bubble (4); Open Dialogue Message Window; Dismiss Emotion Bubble (14); Engine Action #9; Warp to Castle HQ (0, 0, 24); Display Speaker Name Box (0); Open Dialogue Message Window; Display Chapter Text (0); Pan Camera (4, 5, 18); Engine Action #6; Warp Room -> Submap 10 at (6,1) facing 5; Screen Fade Transition (30, 24, 18); Open Dialogue Message Window; Warp Room -> Submap 18 at (3,0) facing 5; Branch on Choice (2, 0); Engine Action #5; Branch on Choice (1, 0); Engine Action #5; Branch on Choice (30, 72); Warp Room -> Submap 2 at (73,60) facing 72; Open Dialogue Message Window; Display Speaker Name Box (43); Display Speaker Name Box (5); Turn obj[18] facing South (Down); Warp Town -> Area 0 Map 0 Submap 3 at (8,3); Display Speaker Name Box (1); Close Dialogue Sub-Window (18); Open Dialogue Message Window; Warp Town -> Area 43 Map 17 Submap 5 at (48,17); Display Speaker Name Box (2); Warp to Castle HQ (1, 0, 8); Warp to Castle HQ (17, 3, 3); Display Speaker Name Box (2); Close Dialogue Sub-Window (17); Open Dialogue Message Window; Warp to Castle HQ (3, 18, 1); Engine Action #5; Display Speaker Name Box (6); Warp Room -> Submap 10 at (30,24) facing 18; Open Dialogue Message Window; Exit to World Map (9, 145, 1); Set Combat Battle BGM (20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 0 Map 5 Submap 0 at (6,41); Warp Town -> Area 0 Map 1 Submap 255 at (0,24); Display Speaker Name Box (0); Pan Camera (84, 66, 31); Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 101, 4); Engine Action #6; Engine Action #5; Open Dialogue Message Window; Warp Town -> Area 0 Map 5 Submap 3 at (1,0); Engine Action #5; Warp to Castle HQ (3, 0, 5); Warp to Castle HQ (0, 0, 5); Warp to Castle HQ (30, 89, 0); Warp Town -> Area 8 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Engine Action #89; Open Dialogue Message Window; Warp Town -> Area 9 Map 5 Submap 0 at (6,2); Dismiss Emotion Bubble (89); Open Dialogue Message Window; Warp Town -> Area 10 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Dismiss Emotion Bubble (0); Warp Room -> Submap 5 at (0,0) facing South (Down); Engine Action #5; Show Dialogue Portrait (0, 0, 30); Engine Action #115; Engine Action #66; Return to Previous Memory Map (30); Warp Room -> Submap 24 at (18,0) facing 8; Load Sound Bank into Memory (1, 18); Engine Action #5; Exit to World Map (18, 32, 3); Reset Camera Tracking (1); Display Speaker Name Box (72); Open Dialogue Message Window; Display Speaker Name Box (3); Change Portrait Expression (1); Close Dialogue Sub-Window (17); Open Dialogue Message Window; Engine Action #9; Close Dialogue Window; Warp Town -> Area 2 Map 120 Submap 69 at (1,123); Open Dialogue Message Window; Reset Camera Tracking (12); Open Dialogue Message Window; Warp Room -> Submap 12 at (255,254); Warp Room -> Submap 1 at (18,6) facing 24; Change Portrait Expression (0); Screen Fade Transition (72, 0, 18); Warp to Castle HQ (18, 0, 24); Display Speaker Name Box (0); Close Dialogue Window; Open Shop Menu #3 (Type: 18); Exit to World Map (18, 32, 3); Reset Camera Tracking (1); Display Speaker Name Box (123); Open Dialogue Message Window; Reset Camera Tracking (11); Warp Town -> Area 2 Map 120 Submap 29 at (5,1); Change Portrait Expression (11); Warp Room -> Submap 120 at (255,254) facing 204 |
| `ev[12]` | `2 (Map Init)` | Story Flag 151 (bit 64) CLEAR AND Condition Check #24 AND Condition Check #66 AND Player Y within Range [3..145] AND Player within Box [4..145, 8..33] AND Player within Box [2..37, 0..8] AND Always Passes (Unconditional) AND Story Flag 0 (mask 255) CLEAR | Make obj[2] Hidden (disp = 0); Change Portrait Expression (28); Fade In from Black (3); Change Portrait Expression (3); Open Dialogue Message Window; Change Portrait Expression (2); Display Speaker Name Box (32); Fade In from Black (3); Display Speaker Name Box (2); Open Dialogue Message Window; Display Speaker Name Box (1); Reset Camera Tracking (1); Engine Action #9; Warp Room -> Submap 1 at (10,1) facing 11; Warp Room -> Submap 1 at (14,1) facing 15; Warp Room -> Submap 9 at (145,16) facing 47 |
| `ev[13]` | `1 (Action / Talk)` | Story Flag 151 (bit 64) CLEAR AND Condition Check #24 AND Condition Check #66 AND Player Y within Range [3..145] AND Star of Destiny #3 Recruited AND Condition Check #145 AND Player within Box [4..145, 8..33] AND Player within Box [2..37, 0..8] AND Always Passes (Unconditional) AND Story Flag 0 (mask 255) CLEAR | Exit to World Map (0, 30, 14); Engine Action #9; Warp to Castle HQ (0, 0, 24); Change Portrait Expression (0); Display Dialogue Box [Bank: 24, MsgID: 18]; Open Dialogue Message Window; Place Scenery Structure (28); Open Dialogue Message Window; Pan Camera (4, 5, 18); Engine Action #6; Warp Room -> Submap 10 at (6,1) facing 5; Screen Fade Transition (30, 24, 18); Open Dialogue Message Window; Animate Door Open; Engine Action #5; Display Speaker Name Box (3); Open Dialogue Message Window; Engine Action #5; Branch on Choice (2, 0); Engine Action #5; Branch on Choice (1, 0); Engine Action #5; Branch on Choice (30, 72); Warp Room -> Submap 2 at (73,60) facing 72; Open Dialogue Message Window; Display Speaker Name Box (43); Display Speaker Name Box (5); Turn obj[18] facing South (Down); Warp Town -> Area 0 Map 0 Submap 3 at (8,3); Display Speaker Name Box (1); Close Dialogue Sub-Window (18); Open Dialogue Message Window; Show Dialogue Portrait (43, 17, 5); Turn obj[17] facing 18; Warp Town -> Area 3 Map 1 Submap 0 at (8,3); Change Portrait Expression (3); Warp to Castle HQ (18, 2, 24); Change Portrait Expression (0); Dismiss Dialogue Portrait; Warp to Castle HQ (18, 1, 5); Display Speaker Name Box (6); Warp Room -> Submap 10 at (30,24) facing 18; Open Dialogue Message Window; Change Portrait Expression (36); Engine Action #128; Screen Fade Transition (145, 16, 73); Branch on Choice (40, 0); Open Dialogue Message Window; Warp Town -> Area 0 Map 18 Submap 0 at (19,41); Warp Town -> Area 0 Map 1 Submap 255 at (0,24); Display Speaker Name Box (0); Branch on Choice (84, 66); Warp Room -> Submap 5 at (0,0); Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 101, 4); Engine Action #6; Engine Action #5; Open Dialogue Message Window; Warp Town -> Area 0 Map 5 Submap 3 at (1,0); Engine Action #5; Warp to Castle HQ (3, 0, 5); Warp to Castle HQ (0, 0, 5); Warp to Castle HQ (30, 89, 0); Warp Town -> Area 8 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Engine Action #89; Open Dialogue Message Window; Warp Town -> Area 9 Map 5 Submap 0 at (6,2); Dismiss Emotion Bubble (89); Open Dialogue Message Window; Warp Town -> Area 10 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Dismiss Emotion Bubble (0); Warp Room -> Submap 5 at (0,0) facing South (Down); Engine Action #5; Show Dialogue Portrait (0, 0, 30); Engine Action #115; Engine Action #66; Return to Previous Memory Map (30); Warp Room -> Submap 24 at (18,0) facing 21; Load Sound Bank into Memory (1, 18); Engine Action #5; Exit to World Map (18, 32, 3); Reset Camera Tracking (1); Display Speaker Name Box (72); Open Dialogue Message Window; Display Speaker Name Box (3); Change Portrait Expression (1); Close Dialogue Sub-Window (17); Open Dialogue Message Window; Set Story Flag (11, 2); Warp Town -> Area 120 Map 69 Submap 1 at (123,0); Reset Camera Tracking (12); Open Dialogue Message Window; Warp Room -> Submap 12 at (255,254); Warp Room -> Submap 1 at (18,6) facing 24; Change Portrait Expression (0); Open Dialogue Sub-Window (72); Open Dialogue Message Window; Display Speaker Name Box (3); Display Speaker Name Box (0); Close Dialogue Sub-Window (18); Open Dialogue Message Window; Close Dialogue Sub-Window (43); Display Speaker Name Box (3); Exit to World Map (18, 32, 3); Reset Camera Tracking (1); Display Speaker Name Box (123); Open Dialogue Message Window; Reset Camera Tracking (11); Warp Town -> Area 2 Map 120 Submap 29 at (5,1); Change Portrait Expression (11); Warp Room -> Submap 120 at (255,254) facing 204 |
| `ev[14]` | `128 (Loop)` | Story Flag 151 (bit 64) CLEAR AND Condition Check #24 AND Condition Check #66 AND Player Y within Range [3..145] AND Star of Destiny #3 Recruited AND Condition Check #145 AND Player within Box [4..145, 2..33] AND Player within Box [2..37, 0..8] AND Always Passes (Unconditional) AND Story Flag 0 (mask 6) CLEAR AND Condition Check #128 | Toggle Random Encounters (128); Engine Action #9; Engine Action #145; Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[15]` | `128 (Loop)` | Story Flag 151 (bit 64) CLEAR AND Condition Check #24 AND Condition Check #66 AND Player Y within Range [3..145] AND Star of Destiny #3 Recruited AND Condition Check #145 AND Player Y within Range [4..145] AND Story Flag 33 (bit 1) CLEAR AND Player Y within Range [37..0] AND Temp Event Flag #0 CLEAR AND Story Flag 0 (mask 6) CLEAR AND Condition Check #128 | Toggle Random Encounters (128); Engine Action #9; Engine Action #145; Exit to World Map (255, 254, 204) |
| `ev[16]` | `128 (Loop)` | Story Flag 151 (bit 64) CLEAR AND Condition Check #24 AND Condition Check #66 AND Player Y within Range [3..145] AND Star of Destiny #3 Recruited AND Condition Check #145 AND Story Flag 4 (bit 145) CLEAR AND Temp Event Flag #33 CLEAR AND Player within Box [2..37, 0..8] AND Always Passes (Unconditional) AND Story Flag 0 (mask 6) CLEAR AND Condition Check #128 | Toggle Random Encounters (128); Engine Action #9; Engine Action #145; Reset Camera Tracking (255) |
| `ev[17]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[10] | Open Dialogue Sub-Window (4); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[18]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[11] | Open Dialogue Sub-Window (4); Open Dialogue Message Window |
| `ev[19]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[12] | Open Dialogue Sub-Window (4); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[20]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[13] | Open Dialogue Sub-Window (4); Warp to Castle HQ (255, 254, 204) |
| `ev[21]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[15] | Open Dialogue Sub-Window (4); Exit to World Map (3, 15, 0) |
| `ev[22]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[16] | Open Dialogue Sub-Window (4); Engine Action #5; Warp to Castle HQ (16, 0, 255) |
| `ev[23]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[8] | Open Dialogue Sub-Window (4); Engine Action #6 |
| `ev[24]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[9] | Open Dialogue Sub-Window (4); Pan Camera (255, 254, 204) |
| `ev[25]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[10] | Open Dialogue Sub-Window (5); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[26]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[11] | Open Dialogue Sub-Window (5); Open Dialogue Message Window |
| `ev[27]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[12] | Open Dialogue Sub-Window (5); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[28]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[13] | Open Dialogue Sub-Window (5); Warp to Castle HQ (255, 254, 204) |
| `ev[29]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[15] | Open Dialogue Sub-Window (5); Exit to World Map (3, 15, 0) |
| `ev[30]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[16] | Open Dialogue Sub-Window (5); Engine Action #5; Warp to Castle HQ (16, 0, 255) |
| `ev[31]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[8] | Open Dialogue Sub-Window (5); Engine Action #6 |
| `ev[32]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[9] | Open Dialogue Sub-Window (5); Pan Camera (255, 254, 204) |
| `ev[33]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[10] | Open Dialogue Sub-Window (6); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[34]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[11] | Open Dialogue Sub-Window (6); Open Dialogue Message Window |
| `ev[35]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[12] | Open Dialogue Sub-Window (6); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[36]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[13] | Open Dialogue Sub-Window (6); Warp to Castle HQ (255, 254, 204) |
| `ev[37]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[15] | Open Dialogue Sub-Window (6); Exit to World Map (3, 15, 0) |
| `ev[38]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[16] | Open Dialogue Sub-Window (6); Engine Action #5; Warp to Castle HQ (16, 0, 255) |
| `ev[39]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[8] | Open Dialogue Sub-Window (6); Engine Action #6 |
| `ev[40]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[9] | Open Dialogue Sub-Window (6); Pan Camera (255, 254, 204) |
| `ev[41]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[10] | Open Dialogue Sub-Window (7); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[42]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[11] | Open Dialogue Sub-Window (7); Open Dialogue Message Window |
| `ev[43]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[12] | Open Dialogue Sub-Window (7); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[44]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[13] | Open Dialogue Sub-Window (7); Warp to Castle HQ (255, 254, 204) |
| `ev[45]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[15] | Open Dialogue Sub-Window (7); Exit to World Map (3, 15, 0) |
| `ev[46]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[16] | Open Dialogue Sub-Window (7); Engine Action #5; Warp to Castle HQ (16, 0, 255) |
| `ev[47]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[8] | Open Dialogue Sub-Window (7); Engine Action #6 |
| `ev[48]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[9] | Open Dialogue Sub-Window (7); Pan Camera (255, 254, 204) |
| `ev[49]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[10] | Open Dialogue Sub-Window (8); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[50]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[11] | Open Dialogue Sub-Window (8); Open Dialogue Message Window |
| `ev[51]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[12] | Open Dialogue Sub-Window (8); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[52]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[13] | Open Dialogue Sub-Window (8); Warp to Castle HQ (255, 254, 204) |
| `ev[53]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[15] | Open Dialogue Sub-Window (8); Exit to World Map (3, 15, 0) |
| `ev[54]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[16] | Open Dialogue Sub-Window (8); Engine Action #5; Warp to Castle HQ (16, 0, 255) |
| `ev[55]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[8] | Open Dialogue Sub-Window (8); Engine Action #6 |
| `ev[56]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[9] | Open Dialogue Sub-Window (8); Pan Camera (255, 254, 204) |
| `ev[57]` | `1 (Action / Talk)` | Target Inspected is obj[8] | Open Dialogue Sub-Window (1); Engine Action #6 |
| `ev[58]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Open Dialogue Sub-Window (1); Pan Camera (255, 254, 204) |
| `ev[59]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Open Dialogue Sub-Window (1); Warp to Castle HQ (255, 254, 204) |
| `ev[60]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Open Dialogue Sub-Window (1); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[61]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Open Dialogue Sub-Window (1); Open Dialogue Message Window |
| `ev[62]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Open Dialogue Sub-Window (1); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[63]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Open Dialogue Sub-Window (1); Exit to World Map (3, 15, 0) |
| `ev[64]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Open Dialogue Sub-Window (1); Engine Action #5; Warp to Castle HQ (16, 0, 255) |
| `ev[65]` | `128 (Loop)` | Player within Box [6..63, 2..12] AND Condition Check #30 | Warp Room -> Submap 0 at (10,5) |
| `ev[66]` | `1 (Action / Talk)` | Player within Box [14..22, 2..7] AND Temp Event Flag #9 CLEAR AND Player within Box [23..66, 2..255] | Warp Map Transition (3, 2, 30, 65, 255) |
| `ev[67]` | `1 (Action / Talk)` | Player within Box [26..34, 2..7] AND Temp Event Flag #9 CLEAR AND Player within Box [23..66, 2..255] | Warp Map Transition (3, 2, 42, 65, 255) |
| `ev[68]` | `1 (Action / Talk)` | Player within Box [38..46, 2..7] AND Temp Event Flag #9 CLEAR AND Player within Box [23..66, 2..255] | Warp Map Transition (3, 2, 54, 65, 255) |
| `ev[69]` | `1 (Action / Talk)` | Player within Box [50..58, 2..7] AND Temp Event Flag #9 CLEAR AND Player within Box [23..66, 2..255] | Warp Map Transition (3, 2, 66, 65, 255) |
| `ev[70]` | `1 (Action / Talk)` | Player within Box [14..22, 2..7] AND Temp Event Flag #9 CLEAR AND Player within Box [24..66, 2..255] | Warp Map Transition (3, 3, 30, 137, 255) |
| `ev[71]` | `1 (Action / Talk)` | Player within Box [26..34, 2..7] AND Temp Event Flag #9 CLEAR AND Player within Box [24..66, 2..255] | Warp Map Transition (3, 3, 42, 137, 255) |
| `ev[72]` | `1 (Action / Talk)` | Player within Box [38..46, 2..7] AND Temp Event Flag #9 CLEAR AND Player within Box [24..66, 2..255] | Warp Map Transition (3, 3, 54, 137, 255) |
| `ev[73]` | `1 (Action / Talk)` | Player within Box [50..58, 2..7] AND Temp Event Flag #9 CLEAR AND Player within Box [24..66, 2..255] | Warp Map Transition (3, 3, 66, 137, 255) |
| `ev[74]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [2..255] | Open Dialogue Message Window; Close Dialogue Sub-Window (255) |
| `ev[75]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [3..255] | Open Dialogue Message Window; Clear Dialogue Sub-Window |
| `ev[76]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [1..255] | Open Dialogue Message Window; Fade In from Black (255) |
| `ev[77]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[24] | Close Dialogue Sub-Window (24); Engine Action #9; Engine Action #6 |
| `ev[78]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[25] | Close Dialogue Sub-Window (25); Engine Action #9; Pan Camera (255, 254, 255) |
| `ev[79]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[26] | Close Dialogue Sub-Window (26); Engine Action #9; Reset Camera Tracking (255) |
| `ev[80]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[24] | Close Dialogue Sub-Window (24); Screen Fade Transition (6, 255, 254) |
| `ev[81]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[25] | Close Dialogue Sub-Window (25); Screen Fade Transition (7, 255, 254) |
| `ev[82]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[26] | Close Dialogue Sub-Window (26); Screen Fade Transition (8, 255, 254) |
| `ev[83]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[24] | Close Dialogue Sub-Window (24); Close Dialogue Window; Engine Action #6 |
| `ev[84]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[25] | Close Dialogue Sub-Window (25); Close Dialogue Window; Pan Camera (255, 254, 255) |
| `ev[85]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[26] | Close Dialogue Sub-Window (26); Close Dialogue Window; Reset Camera Tracking (255) |
| `ev[86]` | `1 (Action / Talk)` | Target Inspected is obj[24] | Close Dialogue Sub-Window (24); Warp Town -> Area 6 Map 255 Submap 254 at (255,254) |
| `ev[87]` | `1 (Action / Talk)` | Target Inspected is obj[25] | Close Dialogue Sub-Window (25); Warp Town -> Area 7 Map 255 Submap 254 at (255,254) |
| `ev[88]` | `1 (Action / Talk)` | Target Inspected is obj[26] | Close Dialogue Sub-Window (26); Warp Town -> Area 8 Map 255 Submap 254 at (255,254) |
| `ev[89]` | `1 (Action / Talk)` | Target Inspected is obj[19] | Close Dialogue Sub-Window (19); Warp to Castle HQ (4, 255, 254) |
| `ev[90]` | `1 (Action / Talk)` | Target Inspected is obj[20] | Close Dialogue Sub-Window (20); Warp to Castle HQ (5, 255, 254) |
| `ev[91]` | `1 (Action / Talk)` | Target Inspected is obj[21] | Close Dialogue Sub-Window (21); Warp to Castle HQ (6, 255, 254) |
| `ev[92]` | `1 (Action / Talk)` | Target Inspected is obj[22] | Close Dialogue Sub-Window (22); Warp to Castle HQ (7, 255, 254) |
| `ev[93]` | `1 (Action / Talk)` | Target Inspected is obj[23] | Close Dialogue Sub-Window (23); Warp to Castle HQ (8, 255, 254) |

---


