# Suikoden II Geographic Area Catalog: Mt. Rakutei Dragon Cliffs & Peak

**Geographic Scope & Role**: Perilous dragon roost mountain; vertical cliff ledges, misty high-altitude chasms, Harpy boss nest, and the sacred Dragon Egg hatching peak.

**Regional Category**: Region `VI` | **Master Maps Included**: `vi08`, `vi09`, `vi13`, `vi15`

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

## Location Map: `vi08`

- **Master Map Container**: `vi08.json`
- **Submap Layer Files**: vi08_00.json, vi08_01.json, vi08_02.json
- **Collision Grid Files**: vi08_map_00.json
- **Sprite Animation Bundles**: vi08_00_obj.json, vi08_01_obj.json
- **Submap Room Count**: 2

### Submap Layer `vi08_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `15`, Rate: `8`)
- **Entity Count (`okaz`)**: `8` Objects | **Script Count (`evkaz`)**: `23` Scripts

#### Complete Physical Entity Inventory (8 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 65139** | `65139` | `(37, 87)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Actor ID 65139** | `65139` | `(39, 85)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | World Device | **Mechanism (ano 7)** | `0` | `(110, 95)` | `0x0` | Frame 7 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | World Device | **Mechanism (ano 6)** | `0` | `(110, 95)` | `0x0` | Frame 6 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[04]` | World Device | **Mechanism (ano 7)** | `0` | `(76, 86)` | `0x0` | Frame 7 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[05]` | World Device | **Mechanism (ano 6)** | `0` | `(76, 86)` | `0x0` | Frame 6 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[06]` | World Device | **Mechanism (ano 7)** | `0` | `(59, 47)` | `0x0` | Frame 7 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | World Device | **Mechanism (ano 6)** | `0` | `(59, 47)` | `0x0` | Frame 6 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 65139)**: Positioned at tile `(37, 87)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Object 65139)**: Positioned at tile `(39, 85)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(110, 95)` with state parameter `7`.
- **`obj[03]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(110, 95)` with state parameter `6`.
- **`obj[04]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(76, 86)` with state parameter `7`.
- **`obj[05]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(76, 86)` with state parameter `6`.
- **`obj[06]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(59, 47)` with state parameter `7`.
- **`obj[07]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(59, 47)` with state parameter `6`.


#### Complete Bytecode Script Catalog (23 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 20 (bit 2) SET | Open Choice Selection Menu (1, 255) |
| `ev[01]` | `2 (Map Init)` | Treasure Byte 4 Bit 64 FRESH (Unopened) | Open Dialogue Message Window; Screen Fade Transition (255, 254, 255) |
| `ev[02]` | `2 (Map Init)` | Treasure Byte 4 Bit 64 LOOTED | Open Dialogue Message Window; Close Dialogue Window |
| `ev[03]` | `2 (Map Init)` | Treasure Byte 4 Bit 128 FRESH (Unopened) | Open Dialogue Message Window; Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[04]` | `2 (Map Init)` | Treasure Byte 4 Bit 128 LOOTED | Open Dialogue Message Window; Place Scenery Structure (255) |
| `ev[05]` | `2 (Map Init)` | Treasure Byte 5 Bit 8 FRESH (Unopened) | Open Dialogue Message Window; Animate Door Open |
| `ev[06]` | `2 (Map Init)` | Treasure Byte 5 Bit 8 LOOTED | Open Dialogue Message Window; Show Dialogue Portrait (255, 254, 255) |
| `ev[07]` | `128 (Loop)` | Temp Event Flag #4 SET AND Player within Box [107..109, 2..107] AND Condition Check #120 | Make obj[121] Hidden (disp = 0); Warp Town -> Area 36 Map 4 Submap 37 at (8,46) |
| `ev[08]` | `128 (Loop)` | Temp Event Flag #8 SET AND Player within Box [110..112, 2..109] AND Condition Check #120 | Make obj[121] Hidden (disp = 0); Warp Room -> Submap 8 at (37,4) facing 46 |
| `ev[09]` | `128 (Loop)` | Temp Event Flag #4 SET AND Player within Box [97..99, 2..71] AND Condition Check #72 | Make obj[121] Hidden (disp = 0); Warp Town -> Area 36 Map 4 Submap 37 at (8,46) |
| `ev[10]` | `128 (Loop)` | Temp Event Flag #8 SET AND Player within Box [96..100, 2..69] AND Condition Check #70 | Make obj[121] Hidden (disp = 0); Warp Room -> Submap 8 at (37,4) facing 46 |
| `ev[11]` | `128 (Loop)` | Temp Event Flag #4 SET AND Player within Box [63..65, 2..71] AND Condition Check #72 | Make obj[121] Hidden (disp = 0); Warp Town -> Area 36 Map 4 Submap 37 at (8,46) |
| `ev[12]` | `128 (Loop)` | Temp Event Flag #8 SET AND Player within Box [62..66, 2..69] AND Condition Check #70 | Make obj[121] Hidden (disp = 0); Warp Room -> Submap 8 at (37,4) facing 46 |
| `ev[13]` | `128 (Loop)` | Temp Event Flag #4 SET AND Player within Box [31..45, 2..61] AND Condition Check #63 | Make obj[121] Hidden (disp = 0); Warp Town -> Area 36 Map 4 Submap 37 at (8,46) |
| `ev[14]` | `1 (Action / Talk)` | Player within Box [30..38, 2..56] AND Condition Check #57 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 38]; Remove Item from Inventory (255, 254) |
| `ev[15]` | `1 (Action / Talk)` | Player within Box [126..134, 2..143] AND Condition Check #144 AND Story Flag 0 (mask 255) SET | Warp Room -> Submap 0 at (8,2); Set Special Scene BGM (1); Warp Map Transition (3, 0, 60, 59, 255) |
| `ev[16]` | `1 (Action / Talk)` | Treasure Byte 4 Bit 64 FRESH (Unopened) AND Target Inspected is obj[10] | Recruit Character into Active Party (46, 0); Close Dialogue Window; Warp Room -> Submap 47 at (101,4) facing 7; Dismiss Emotion Bubble (0); Exit to World Map (0, 2, 0); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,4) facing 64; Engine Action #51; Warp Town -> Area 255 Map 1 Submap 46 at (0,10); Warp Room -> Submap 47 at (255,2) facing 58 |
| `ev[17]` | `1 (Action / Talk)` | Treasure Byte 4 Bit 128 FRESH (Unopened) AND Target Inspected is obj[12] | Recruit Character into Active Party (46, 0); Place Scenery Structure (1); Display Dialogue Box [Bank: 47, MsgID: 101]; Exit to World Map (7, 30, 0); Exit to World Map (0, 63, 16); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,4) facing 128; Engine Action #51; Warp Town -> Area 255 Map 1 Submap 46 at (0,12); Warp Room -> Submap 47 at (255,2) facing 58 |
| `ev[18]` | `1 (Action / Talk)` | Treasure Byte 5 Bit 8 FRESH (Unopened) AND Target Inspected is obj[14] | Recruit Character into Active Party (46, 0); Show Dialogue Portrait (1, 14, 47); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (0); Exit to World Map (0, 11, 16); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,5) facing 8; Engine Action #51; Warp Town -> Area 255 Map 1 Submap 46 at (0,14); Warp Room -> Submap 47 at (255,2) facing 58 |
| `ev[19]` | `1 (Action / Talk)` | Story Flag 38 (bit 2) CLEAR AND Player within Box [32..44, 2..105] AND Condition Check #107 AND Story Flag 1 (mask 255) SET | Recruit Character into Active Party (46, 2); Reset Camera Tracking (37); Engine Action #87; Open Dialogue Message Window; Reset Camera Tracking (2); Engine Action #9; Engine Action #39; Animate Door obj[0] (State: 9); Launch Tactical War Battle (1); Teleport obj[43] to (0,4); Set Render Priority (pri) (0, 38); Teleport Object to Coordinates (8, 54, 0); Warp Room -> Submap 1 at (3,46) facing West (Left); Reset Camera Tracking (1); Engine Action #9; Teleport obj[9] to (38,2); Engine Action #58 |
| `ev[20]` | `128 (Loop)` | Story Flag 38 (bit 2) CLEAR AND Inventory Holds Item #1 | Set Entity Movement Speed (2, 5); Reset Camera Tracking (5); Dismiss Emotion Bubble (4); Engine Action #6; Open Dialogue Message Window; Show Dialogue Portrait (30, 255, 254); Engine Action #5; Engine Action #9; Engine Action #5; Start Boss Battle #4 (BGM: 6); Open Dialogue Message Window; Dismiss Dialogue Portrait; Dismiss Emotion Bubble (255); Walk obj[37] to (1,255) |
| `ev[21]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) CLEAR AND Story Flag 38 (bit 4) CLEAR AND Player within Box [97..99, 2..100] AND Condition Check #102 AND Story Flag 1 (mask 255) SET | Recruit Character into Active Party (46, 2); Reset Camera Tracking (97); Engine Action #80; Open Dialogue Message Window; Reset Camera Tracking (2); Engine Action #9; Engine Action #99; Bytecode Subroutine Return; Open Dialogue Message Window; Engine Action #9; Launch Tactical War Battle (2); Teleport obj[43] to (0,4); Set Render Priority (pri) (0, 98); Clear Story Milestone Flag 8 (mask 54); Open Dialogue Message Window; Warp Town -> Area 83 Map 1 Submap 3 at (46,1); Reset Camera Tracking (1); Engine Action #9; Teleport obj[9] to (38,4); Engine Action #58 |
| `ev[22]` | `128 (Loop)` | Story Flag 20 (bit 128) CLEAR AND Story Flag 38 (bit 4) CLEAR AND Inventory Holds Item #2 | Set Entity Movement Speed (2, 5); Reset Camera Tracking (5); Dismiss Emotion Bubble (4); Engine Action #6; Open Dialogue Message Window; Show Dialogue Portrait (30, 255, 254); Engine Action #5; Engine Action #9; Engine Action #5; Start Boss Battle #4 (BGM: 6); Open Dialogue Message Window; Dismiss Dialogue Portrait; Dismiss Emotion Bubble (255); Walk obj[37] to (2,255) |

---

### Submap Layer `vi08_01` (Index 1)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `2` (Timer: `15`, Rate: `8`)
- **Entity Count (`okaz`)**: `12` Objects | **Script Count (`evkaz`)**: `36` Scripts

#### Complete Physical Entity Inventory (12 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 65140** | `65140` | `(116, 182)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Actor ID 65139** | `65139` | `(208, 134)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Actor ID 65139** | `65139` | `(139, 103)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | NPC / Actor | **Actor ID 65139** | `65139` | `(141, 104)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[04]` | World Device | **Mechanism (ano 7)** | `0` | `(120, 81)` | `0x0` | Frame 7 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[05]` | World Device | **Mechanism (ano 6)** | `0` | `(120, 81)` | `0x0` | Frame 6 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[06]` | World Device | **Mechanism (ano 7)** | `0` | `(125, 81)` | `0x0` | Frame 7 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[07]` | World Device | **Mechanism (ano 6)** | `0` | `(125, 81)` | `0x0` | Frame 6 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[08]` | World Device | **Mechanism (ano 7)** | `0` | `(180, 201)` | `0x0` | Frame 7 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[09]` | World Device | **Mechanism (ano 6)** | `0` | `(180, 201)` | `0x0` | Frame 6 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[10]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(194, 35)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Trigger / Hitbox | **Hitbox Zone (5x2)** | `0` | `(185, 201)` | `4x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 65140)**: Positioned at tile `(116, 182)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Object 65139)**: Positioned at tile `(208, 134)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Object 65139)**: Positioned at tile `(139, 103)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Object 65139)**: Positioned at tile `(141, 104)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(120, 81)` with state parameter `7`.
- **`obj[05]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(120, 81)` with state parameter `6`.
- **`obj[06]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(125, 81)` with state parameter `7`.
- **`obj[07]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(125, 81)` with state parameter `6`.
- **`obj[08]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(180, 201)` with state parameter `7`.
- **`obj[09]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(180, 201)` with state parameter `6`.
- **`obj[10]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(194, 35)` to `(196, 36)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[11]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `2` tiles high from `(185, 201)` to `(189, 202)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (36 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Treasure Byte 5 Bit 1 FRESH (Unopened) | Open Dialogue Message Window; Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[01]` | `2 (Map Init)` | Treasure Byte 5 Bit 1 LOOTED | Open Dialogue Message Window; Place Scenery Structure (255) |
| `ev[02]` | `2 (Map Init)` | Treasure Byte 5 Bit 2 FRESH (Unopened) | Open Dialogue Message Window; Animate Door Open |
| `ev[03]` | `2 (Map Init)` | Treasure Byte 5 Bit 2 LOOTED | Open Dialogue Message Window; Show Dialogue Portrait (255, 254, 255) |
| `ev[04]` | `2 (Map Init)` | Treasure Byte 5 Bit 4 FRESH (Unopened) | Open Dialogue Message Window; Dismiss Dialogue Portrait |
| `ev[05]` | `2 (Map Init)` | Treasure Byte 5 Bit 4 LOOTED | Open Dialogue Message Window; Change Portrait Expression (255) |
| `ev[06]` | `1 (Action / Talk)` | Player within Box [40..44, 2..97] AND Condition Check #98 AND Story Flag 0 (mask 255) SET | Warp Room -> Submap 0 at (8,2); Set Special Scene BGM (1); Warp Map Transition (3, 0, 28, 44, 255) |
| `ev[07]` | `1 (Action / Talk)` | Player within Box [34..41, 2..49] AND Condition Check #50 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 34]; Engine Action #62 |
| `ev[08]` | `1 (Action / Talk)` | Player within Box [140..148, 2..56] AND Condition Check #57 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 208]; Engine Action #39 |
| `ev[09]` | `1 (Action / Talk)` | Player within Box [205..211, 2..47] AND Condition Check #48 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 144]; Engine Action #62 |
| `ev[10]` | `1 (Action / Talk)` | Player within Box [194..198, 2..61] AND Condition Check #62 AND Story Flag 0 (mask 255) SET | Warp Room -> Submap 0 at (8,2); Set Special Scene BGM (1); Warp Map Transition (3, 0, 80, 28, 255) |
| `ev[11]` | `1 (Action / Talk)` | Player within Box [206..210, 2..131] AND Condition Check #132 AND Story Flag 0 (mask 255) SET | Warp Room -> Submap 0 at (8,2); Set Special Scene BGM (1); Warp Map Transition (3, 0, 40, 34, 255) |
| `ev[12]` | `1 (Action / Talk)` | Temp Event Flag #32 SET AND Player within Box [189..195, 2..112] AND Condition Check #113 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 36]; Engine Action #164 |
| `ev[13]` | `1 (Action / Talk)` | Player within Box [33..39, 2..171] AND Condition Check #172 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 192]; Engine Action #118 |
| `ev[14]` | `1 (Action / Talk)` | Story Flag 20 (bit 2) CLEAR AND Player within Box [41..47, 2..154] AND Condition Check #155 AND Story Flag 1 (mask 255) SET | Warp Room -> Submap 0 at (8,9); Close Dialogue Window; Warp Town -> Area 2 Map 40 Submap 3 at (0,3); Wait for Audio / Window Sync (3); Warp Map Transition (3, 0, 20, 19, 255) |
| `ev[15]` | `1 (Action / Talk)` | Story Flag 20 (bit 2) SET AND Player within Box [41..47, 2..154] AND Condition Check #155 AND Story Flag 1 (mask 255) SET | Warp Room -> Submap 0 at (8,8); Close Dialogue Window; Warp Town -> Area 2 Map 40 Submap 3 at (0,3); Wait for Audio / Window Sync (1); Warp Map Transition (3, 0, 3, 25, 255) |
| `ev[16]` | `1 (Action / Talk)` | Player within Box [122..126, 2..154] AND Condition Check #155 AND Story Flag 1 (mask 255) SET | Warp Room -> Submap 0 at (8,8); Close Dialogue Window; Warp Town -> Area 2 Map 40 Submap 3 at (0,2); Wait for Audio / Window Sync (1); Warp Map Transition (3, 0, 116, 26, 255) |
| `ev[17]` | `1 (Action / Talk)` | Player within Box [107..113, 2..176] AND Condition Check #177 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 202]; Engine Action #166 |
| `ev[18]` | `1 (Action / Talk)` | Player within Box [196..203, 2..173] AND Condition Check #174 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 110]; Engine Action #182 |
| `ev[19]` | `1 (Action / Talk)` | Treasure Byte 5 Bit 1 FRESH (Unopened) AND Target Inspected is obj[12] | Recruit Character into Active Party (46, 0); Place Scenery Structure (1); Display Dialogue Box [Bank: 47, MsgID: 101]; Exit to World Map (7, 30, 0); Exit to World Map (0, 30, 80); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,5) facing West (Left); Engine Action #51; Warp Town -> Area 255 Map 1 Submap 46 at (0,12); Warp Room -> Submap 47 at (255,2) facing 58 |
| `ev[20]` | `1 (Action / Talk)` | Treasure Byte 5 Bit 2 FRESH (Unopened) AND Target Inspected is obj[14] | Recruit Character into Active Party (46, 0); Show Dialogue Portrait (1, 14, 47); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (0); Exit to World Map (0, 34, 80); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,5) facing Up (North); Engine Action #51; Warp Town -> Area 255 Map 1 Submap 46 at (0,14); Warp Room -> Submap 47 at (255,2) facing 58 |
| `ev[21]` | `1 (Action / Talk)` | Treasure Byte 5 Bit 4 FRESH (Unopened) AND Target Inspected is obj[16] | Recruit Character into Active Party (46, 0); Change Portrait Expression (1); Dismiss Dialogue Portrait; Teleport obj[101] to (4,7); Dismiss Emotion Bubble (0); Exit to World Map (0, 32, 16); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,5) facing 4; Engine Action #51; Warp Town -> Area 255 Map 1 Submap 46 at (0,16); Warp Room -> Submap 47 at (255,2) facing 58 |
| `ev[22]` | `1 (Action / Talk)` | Story Flag 38 (bit 8) CLEAR AND Player within Box [136..144, 2..83] AND Condition Check #85 AND Story Flag 0 (mask 255) SET | Recruit Character into Active Party (46, 0); Screen Fade Transition (0, 11, 36); Engine Action #128; Teleport obj[43] to (0,4); Exit to World Map (0, 140, 86); Reset Camera Tracking (54); Open Dialogue Message Window; Engine Action #128; Engine Action #83; Warp Room -> Submap 46 at (1,10) facing West (Left); Close Dialogue Window; Teleport obj[9] to (38,8); Engine Action #58 |
| `ev[23]` | `128 (Loop)` | Story Flag 38 (bit 8) CLEAR AND Inventory Holds Item #128 | Set Entity Movement Speed (2, 5); Screen Fade Transition (4, 6, 1); Show Dialogue Portrait (30, 255, 254); Engine Action #5; Close Dialogue Window; Exit to World Map (6, 1, 16); Dismiss Emotion Bubble (255); Walk obj[37] to (128,255) |
| `ev[24]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Launch Tactical War Battle (64); Fade In from Black (1); Exit to World Map (73, 20, 40); Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 1 Map 2 Submap 1 at (3,73); Branch on Choice (41, 2); Open Dialogue Message Window; Warp Room -> Submap 0 at (54,0) facing 64; Recruit Invisible / Hitbox Trigger into Battle Slot 1; Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[25]` | `128 (Loop)` | Inventory Holds Item #64 | Warp Room -> Submap 0 at (13,44); Toggle Random Encounters (64) |
| `ev[26]` | `1 (Action / Talk)` | Story Flag 36 (bit 8) CLEAR AND Target Inspected is obj[19] | Jump to Bytecode Offset (4, 6); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (0); Exit to World Map (0, 68, 0); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (9,36) facing 8; Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[27]` | `1 (Action / Talk)` | Story Flag 36 (bit 4) CLEAR AND Target Inspected is obj[8] | Open Dialogue Sub-Window (2); Close Dialogue Window; Set Combat Battle BGM (15); Jump to Bytecode Offset (4, 6); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (0); Exit to World Map (0, 10, 32); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (9,36) facing 4; Warp Room -> Submap 8 at (5,10) facing South (Down); Open Dialogue Message Window; Dismiss Emotion Bubble (255) |
| `ev[28]` | `1 (Action / Talk)` | Story Flag 36 (bit 4) SET AND Target Inspected is obj[8] | Open Dialogue Sub-Window (2); Screen Fade Transition (5, 8, 5); Screen Fade Transition (0, 0, 30) |
| `ev[29]` | `1 (Action / Talk)` | Story Flag 20 (bit 2) CLEAR AND Story Flag 19 (bit 64) CLEAR AND Temp Event Flag #128 SET AND Player within Box [198..200, 2..117] AND Condition Check #131 AND Story Flag 2 (mask 255) SET | Recruit Character into Active Party (30, 2); Open Dialogue Message Window; Award Potch Loot (+2,048 Potch); Open Dialogue Message Window; Warp Room -> Submap 1 at (1,1) facing West (Left); Warp Room -> Submap 0 at (4,4) facing South (Down); Engine Action #192; Engine Action #119; Engine Action #9; Return to Previous Memory Map (1); Display Speaker Name Box (46); Open Dialogue Message Window; Warp Room -> Submap 2 at (0,3) facing South (Down); Exit to World Map (0, 5, 47); Set Entity Movement Speed (6, 5); Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (1, 0, 5); Engine Action #5; Warp to Castle HQ (0, 30, 255); Engine Action #5; Warp Room -> Submap 5 at (0,2) facing East (Right); Warp Room -> Submap 255 at (254,5) facing Up (North); Exit to World Map (5, 3, 5); Open Dialogue Message Window; Warp Room -> Submap 5 at (2,0) facing 30; Engine Action #5; Warp to Castle HQ (4, 5, 3); Reset Camera Tracking (0); Warp Town -> Area 5 Map 5 Submap 2 at (0,30); Engine Action #5; Exit to World Map (4, 5, 3); Reset Camera Tracking (1); Warp Room -> Submap 5 at (2,0) facing 30; Engine Action #5; Engine Action #5; Exit to World Map (5, 3, 11); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp Town -> Area 0 Map 30 Submap 255 at (254,50); Launch Tactical War Battle (16); Engine Action #120; Warp Town -> Area 4 Map 0 Submap 10 at (73,30); Launch Tactical War Battle (1); Close Dialogue Sub-Window (9); Warp to Castle HQ (65, 73, 10); Set Entity Movement Speed (6, 5); Open Dialogue Message Window; Engine Action #5; Engine Action #6; Warp to Castle HQ (0, 30, 255); Engine Action #5; Warp Room -> Submap 9 at (3,0) facing 30; Engine Action #5; Warp Town -> Area 5 Map 3 Submap 2 at (0,30); Engine Action #5; Warp to Castle HQ (5, 12, 2); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Exit to World Map (5, 18, 2); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Engine Action #5; Engine Action #5; Show Dialogue Portrait (2, 0, 30); Walk obj[73] to (10,30); Warp Town -> Area 0 Map 41 Submap 8 at (0,0); Warp Town -> Area 3 Map 3 Submap 3 at (3,3); Warp Town -> Area 120 Map 2 Submap 5 at (0,10); Set Combat Battle BGM (30); Close Dialogue Sub-Window (1); Warp to Castle HQ (71, 51, 4); Warp to Castle HQ (120, 3, 5); Open Dialogue Message Window; Screen Fade Transition (73, 30, 24); Warp Room -> Submap 67 at (255,4) facing 73; Dismiss Emotion Bubble (30); Warp Town -> Area 0 Map 41 Submap 8 at (0,0); Engine Action #5; Engine Action #6; Pan Camera (7, 7, 7); Engine Action #5; Engine Action #120; Warp Town -> Area 6 Map 0 Submap 10 at (51,8); Engine Action #6; Engine Action #120; Warp to Castle HQ (6, 0, 10); Engine Action #51; Reset Camera Tracking (255); Pan Camera (120, 4, 6); Open Dialogue Message Window; Screen Fade Transition (255, 8, 44); Launch Tactical War Battle (2); Launch Tactical War Battle (32); Set Combat Battle BGM (15); Set Entity Movement Speed (6, 5); Open Dialogue Message Window; Exit to World Map (5, 1, 11); Dismiss Emotion Bubble (255); Engine Action #5; Warp Room -> Submap 5 at (5,5) facing West (Left); Place Scenery Structure (30); Engine Action #5; Warp Town -> Area 4 Map 5 Submap 5 at (15,0); Engine Action #5; Warp to Castle HQ (8, 0, 1); Dismiss Emotion Bubble (255); Engine Action #5; Warp to Castle HQ (4, 5, 5); Branch on Choice (0, 2); Warp to Castle HQ (8, 0, 3); Dismiss Emotion Bubble (255); Engine Action #5; Exit to World Map (4, 5, 5); Dismiss Emotion Bubble (0); Exit to World Map (3, 8, 0); Warp Town -> Area 30 Map 255 Submap 254 at (5,5); Exit to World Map (5, 5, 25); Warp to Castle HQ (8, 0, 7); Dismiss Emotion Bubble (255); Walk obj[54] to (0,2); Open Shop Menu #7 (Type: 0); Launch Tactical War Battle (8); Exit to World Map (0, 34, 173); Engine Action #9; Return Warp to Castle Base (30, 1); Warp to Castle HQ (2, 1, 18); Return to Previous Memory Map (1); Display Speaker Name Box (0); Warp Room -> Submap 1 at (4,7) facing East (Right); Warp to Castle HQ (1, 1, 30); Launch Tactical War Battle (4); Set Entity Movement Speed (2, 5); Open Dialogue Message Window; Exit to World Map (4, 5, 5); Warp Room -> Submap 3 at (0,30) facing 255; Engine Action #5; Warp Room -> Submap 4 at (1,11) facing East (Right); Open Dialogue Message Window; Engine Action #5; Trigger Character Emotion Effect (1, 0); Engine Action #5; Engine Action #5; Warp Town -> Area 0 Map 5 Submap 15 at (30,255); Walk obj[24] to (1,3); Wait for Audio / Window Sync (5); Warp Room -> Submap 5 at (2,3) facing 30; Warp Room -> Submap 5 at (0,0) facing South (Down); Dismiss Emotion Bubble (34); Engine Action #54; Open Dialogue Message Window; Dismiss Dialogue Portrait; Engine Action #9; Display Choice Selection (64, 255); Open Dialogue Message Window; Launch Tactical War Battle (128); Engine Action #58 |
| `ev[30]` | `128 (Loop)` | Story Flag 20 (bit 2) CLEAR AND Inventory Holds Item #1 | Set Entity Movement Speed (6, 5); Open Dialogue Message Window; Engine Action #5; Engine Action #6; Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Warp Room -> Submap 9 at (0,0) facing 30; Engine Action #5; Warp Town -> Area 5 Map 3 Submap 0 at (0,30); Engine Action #5; Warp to Castle HQ (5, 12, 0); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Exit to World Map (5, 18, 0); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Engine Action #5; Engine Action #5; Show Dialogue Portrait (0, 0, 30); Walk obj[37] to (1,255) |
| `ev[31]` | `128 (Loop)` | Story Flag 20 (bit 2) CLEAR AND Inventory Holds Item #2 | Close Dialogue Window; Warp Town -> Area 2 Map 120 Submap 37 at (2,255) |
| `ev[32]` | `128 (Loop)` | Story Flag 20 (bit 2) CLEAR AND Inventory Holds Item #4 | Close Dialogue Window; Warp Room -> Submap 80 at (37,4) facing 255 |
| `ev[33]` | `128 (Loop)` | Story Flag 20 (bit 2) CLEAR AND Inventory Holds Item #8 | Display Emotion Bubble (7, 37); Reset Camera Tracking (255) |
| `ev[34]` | `128 (Loop)` | Story Flag 20 (bit 2) CLEAR AND Inventory Holds Item #16 | Warp Room -> Submap 0 at (8,9); Toggle Random Encounters (16) |
| `ev[35]` | `1 (Action / Talk)` | Story Flag 20 (bit 2) CLEAR AND Story Flag 19 (bit 64) SET AND Player within Box [32..39, 2..165] AND Condition Check #167 AND Story Flag 0 (mask 255) SET | Recruit Character into Active Party (33, 1); Display Speaker Name Box (0); Warp Room -> Submap 2 at (5,0) facing 5; Screen Fade Transition (2, 0, 5); Engine Action #5; Warp Room -> Submap 30 at (255,254) facing 5; Warp Room -> Submap 5 at (1,3) facing East (Right); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Screen Fade Transition (30, 255, 254); Walk obj[24] to (1,3); Recruit Flik into Battle Slot 0; Exit to World Map (5, 5, 15); Warp Room -> Submap 30 at (1,1) facing 34; Engine Action #58 |

---



## Location Map: `vi09`

- **Master Map Container**: `vi09.json`
- **Submap Layer Files**: Embedded in master
- **Collision Grid Files**: None
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 1

### Submap Layer `vi09_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `1` Objects | **Script Count (`evkaz`)**: `2` Scripts

#### Complete Physical Entity Inventory (1 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | Trigger / Hitbox | **Hitbox Zone (121x2)** | `0` | `(0, 29)` | `120x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Hitbox Zone)**: Bounding trigger area covering `121` tiles wide by `2` tiles high from `(0, 29)` to `(120, 30)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (2 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [0..1, 2..22] AND Condition Check #35 AND Story Flag 2 (mask 255) SET | Warp Room -> Submap 1 at (8,7); Close Dialogue Window; Warp Town -> Area 2 Map 40 Submap 3 at (0,0); Wait for Audio / Window Sync (1); Warp Map Transition (2, 1, 44, 158, 255) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [118..119, 2..22] AND Condition Check #35 AND Story Flag 3 (mask 255) SET | Warp Room -> Submap 1 at (8,7); Close Dialogue Window; Warp Town -> Area 2 Map 40 Submap 3 at (0,0); Wait for Audio / Window Sync (1); Warp Map Transition (2, 1, 124, 158, 255) |

---



## Location Map: `vi13`

- **Master Map Container**: `vi13.json`
- **Submap Layer Files**: vi13_00.json, vi13_01.json
- **Collision Grid Files**: vi13_map_00.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 9

### Submap Layer `vi13_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `4` Objects | **Script Count (`evkaz`)**: `30` Scripts

#### Complete Physical Entity Inventory (4 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Shu** | `9` | `(30, 76)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Luc** | `10` | `(34, 76)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(33, 75)` | `2x1` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | NPC / Actor | **Actor ID 65166** | `65166` | `(56, 29)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Shu)**: Positioned at tile `(30, 76)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Luc)**: Positioned at tile `(34, 76)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(33, 75)` to `(35, 76)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[03]` (Object 65166)**: Positioned at tile `(56, 29)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.


#### Complete Bytecode Script Catalog (30 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Always Passes (Unconditional) | Animate Door obj[8] (State: 12); Open Dialogue Message Window; Return to Previous Memory Map (88) |
| `ev[01]` | `2 (Map Init)` | Story Flag 33 (bit 4) CLEAR | Engine Action #88 |
| `ev[02]` | `2 (Map Init)` | Story Flag 33 (bit 4) SET AND Story Flag 34 (bit 2) CLEAR AND Story Flag 19 (bit 128) CLEAR AND Star of Destiny #0 Recruited AND Story Flag 255 (mask 254) CLEAR | Engine Action #88 |
| `ev[03]` | `2 (Map Init)` | Story Flag 33 (bit 4) SET AND Story Flag 34 (bit 2) CLEAR AND Story Flag 19 (bit 128) CLEAR AND Star of Destiny #0 Recruited AND Story Flag 255 (mask 254) SET | Engine Action #88 |
| `ev[04]` | `2 (Map Init)` | Story Flag 33 (bit 1) SET AND Story Flag 33 (bit 2) CLEAR AND Story Flag 19 (bit 128) CLEAR | Make obj[0] Hidden (disp = 0); Engine Action #9; Open Dialogue Message Window; Screen Fade Transition (0, 8, 47) |
| `ev[05]` | `2 (Map Init)` | Story Flag 33 (bit 2) SET AND Story Flag 33 (bit 128) CLEAR AND Story Flag 19 (bit 128) CLEAR AND Star of Destiny #0 Recruited AND Story Flag 255 (mask 254) CLEAR | Make obj[0] Hidden (disp = 0); Engine Action #9; Open Dialogue Message Window; Screen Fade Transition (47, 255, 254) |
| `ev[06]` | `2 (Map Init)` | Story Flag 33 (bit 2) SET AND Story Flag 33 (bit 128) CLEAR AND Story Flag 19 (bit 128) CLEAR AND Star of Destiny #0 Recruited AND Story Flag 255 (mask 254) SET | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[07]` | `1 (Action / Talk)` | Player within Box [32..51, 2..6] AND Temp Event Flag #9 SET AND Player X within Range [255..254] | Display Dialogue Box [Bank: 1, MsgID: 26]; Engine Action #88 |
| `ev[08]` | `1 (Action / Talk)` | Player within Box [19..46, 2..90] AND Condition Check #91 AND Story Flag 0 (mask 255) SET | Warp Room -> Submap 2 at (12,8); Warp Map Transition (0, 0, 91, 21, 255) |
| `ev[09]` | `128 (Loop)` | Story Flag 33 (bit 8) CLEAR AND Condition Check #30 AND Always Passes (Unconditional) AND Player X within Range [255..254] | Jump to Bytecode Offset (1, 0); Engine Action #99; Open Dialogue Message Window; Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[10]` | `1 (Action / Talk)` | Story Flag 34 (bit 2) CLEAR AND Star of Destiny #0 Recruited AND Story Flag 16 (mask 0) CLEAR AND Story Flag 1 (mask 35) SET AND Condition Check #55 AND Player Y within Range [26..28] AND Story Flag 1 (mask 255) SET | Recruit Character into Active Party (11, 4); Warp Town -> Area 90 Map 43 Submap 0 at (7,4); Open Dialogue Message Window; Warp Map Transition (87, 8, 3, 0, 0); Close Dialogue Window; Warp to Castle HQ (2, 100, 72); Warp Room -> Submap 3 at (5,0) facing 5; Show Dialogue Portrait (2, 0, 5); Dismiss Emotion Bubble (0); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp to Castle HQ (0, 5, 30); Warp Room -> Submap 30 at (72,0) facing South (Down); Engine Action #58 |
| `ev[11]` | `1 (Action / Talk)` | Star of Destiny #1 Recruited AND Story Flag 16 (mask 0) CLEAR AND Story Flag 1 (mask 35) SET AND Condition Check #55 AND Player Y within Range [26..28] AND Story Flag 1 (mask 255) SET | Recruit Character into Active Party (11, 4); Warp Town -> Area 90 Map 43 Submap 0 at (7,4); Open Dialogue Message Window; Warp Map Transition (87, 8, 3, 0, 0); Close Dialogue Window; Warp to Castle HQ (2, 100, 72); Warp Room -> Submap 3 at (5,0) facing 5; Show Dialogue Portrait (2, 0, 5); Dismiss Emotion Bubble (0); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp to Castle HQ (0, 5, 30); Warp Room -> Submap 30 at (72,0) facing South (Down); Engine Action #58 |
| `ev[12]` | `1 (Action / Talk)` | Star of Destiny #1 Recruited AND Story Flag 16 (mask 0) SET AND Story Flag 1 (mask 35) CLEAR AND Condition Check #55 AND Player Y within Range [26..28] AND Story Flag 1 (mask 255) SET | Recruit Character into Active Party (11, 4); Warp Town -> Area 90 Map 43 Submap 0 at (7,4); Open Dialogue Message Window; Warp Map Transition (87, 8, 3, 0, 0); Close Dialogue Window; Warp to Castle HQ (2, 100, 72); Warp Room -> Submap 3 at (5,0) facing 5; Show Dialogue Portrait (2, 0, 5); Dismiss Emotion Bubble (0); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp to Castle HQ (0, 5, 30); Warp Room -> Submap 30 at (72,0) facing South (Down); Engine Action #58 |
| `ev[13]` | `1 (Action / Talk)` | Story Flag 33 (bit 2) CLEAR AND Target Inspected is obj[10] | Close Dialogue Sub-Window (9); Open Dialogue Message Window; Open Dialogue Message Window |
| `ev[14]` | `1 (Action / Talk)` | Story Flag 33 (bit 2) CLEAR AND Target Inspected is obj[8] | Recruit Character into Active Party (36, 1); Open Shop Menu #4 (Type: 0); Set Render Priority (pri) (0, 32); Bytecode Subroutine Return; Engine Action #9; Warp to Castle HQ (0, 1, 5); Reset Camera Tracking (5); Screen Fade Transition (0, 0, 5); Show Dialogue Portrait (30, 24, 8); Open Dialogue Message Window; Warp Room -> Submap 9 at (5,10) facing Up (North); Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 24, 9); Open Dialogue Message Window; Warp Town -> Area 73 Map 15 Submap 73 at (20,40); Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 0 Map 4 Submap 0 at (3,73); Show Dialogue Portrait (41, 2, 0); Warp Room -> Submap 0 at (5,9) facing West (Left); Open Dialogue Message Window; Dismiss Emotion Bubble (5); Reset Camera Tracking (5); Screen Fade Transition (3, 0, 5); Engine Action #5; Warp Room -> Submap 30 at (51,2) facing 255; Warp Room -> Submap 9 at (0,0) facing 5; Show Dialogue Portrait (30, 24, 9); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Reset Camera Tracking (5); Screen Fade Transition (3, 0, 5); Screen Fade Transition (30, 24, 8); Open Dialogue Message Window; Engine Action #6; Set Combat Battle BGM (15); Engine Action #54; Open Dialogue Message Window; Warp Room -> Submap 2 at (73,10) facing 49; Warp Town -> Area 5 Map 8 Submap 4 at (4,0); Warp to Castle HQ (3, 2, 30); Warp Room -> Submap 255 at (254,5) facing 9; Exit to World Map (4, 0, 3); Warp Town -> Area 2 Map 30 Submap 1 at (9,255); Walk obj[1] to (10,54); Open Dialogue Message Window; Warp Town -> Area 9 Map 33 Submap 2 at (255,2); Engine Action #58 |
| `ev[15]` | `128 (Loop)` | Story Flag 33 (bit 2) CLEAR AND Inventory Holds Item #1 | Warp Room -> Submap 2 at (13,28); Toggle Random Encounters (1) |
| `ev[16]` | `128 (Loop)` | Story Flag 33 (bit 2) CLEAR AND Inventory Holds Item #2 | Dismiss Emotion Bubble (1); Warp Town -> Area 20 Map 7 Submap 41 at (2,0); Warp Room -> Submap 0 at (115,10) facing 51; Engine Action #115; Engine Action #9; Engine Action #51; Engine Action #51; Warp Town -> Area 255 Map 1 Submap 115 at (10,34); Engine Action #115; Engine Action #9; Return Warp to Castle Base (255, 2); Pathfind and Walk to Coordinates (6, 0, 2); Screen Fade Transition (1, 9, 1); Recruit Jowy Atreides into Battle Slot 0; Toggle Random Encounters (2) |
| `ev[17]` | `1 (Action / Talk)` | Story Flag 33 (bit 2) SET AND Story Flag 33 (bit 128) CLEAR AND Star of Destiny #1 Recruited AND Story Flag 5 (mask 10) SET | Recruit Character into Active Party (36, 1); Close Dialogue Sub-Window (9); Open Dialogue Message Window; Screen Fade Transition (73, 15, 73); Branch on Choice (40, 0); Open Dialogue Message Window; Warp Town -> Area 0 Map 11 Submap 0 at (12,73); Show Dialogue Portrait (41, 2, 0); Warp Room -> Submap 0 at (43,0) facing 4; Set Render Priority (pri) (0, 31); Full Rest & Healing (Restore HP/MP); Reset Camera Tracking (3); Open Dialogue Message Window; Warp to Castle HQ (5, 9, 5); Engine Action #5; Warp Town -> Area 0 Map 30 Submap 54 at (0,1); Launch Tactical War Battle (2); Engine Action #5; Engine Action #9; Engine Action #5; Screen Fade Transition (4, 5, 2); Warp to Castle HQ (30, 1, 9); Warp Room -> Submap 54 at (0,2) facing 255; Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[18]` | `1 (Action / Talk)` | Story Flag 33 (bit 2) SET AND Story Flag 33 (bit 128) CLEAR AND Star of Destiny #1 Recruited AND Story Flag 5 (mask 8) CLEAR | Recruit Character into Active Party (36, 1); Close Dialogue Sub-Window (8); Open Dialogue Message Window; Pan Camera (73, 15, 73); Branch on Choice (40, 0); Open Dialogue Message Window; Warp Town -> Area 0 Map 8 Submap 0 at (9,73); Show Dialogue Portrait (41, 2, 0); Warp Room -> Submap 0 at (43,0) facing 4; Set Render Priority (pri) (0, 33); Full Rest & Healing (Restore HP/MP); Reset Camera Tracking (3); Open Dialogue Message Window; Warp Town -> Area 5 Map 8 Submap 5 at (5,3); Open Dialogue Message Window; Dismiss Emotion Bubble (54); Open Dialogue Message Window; Warp Room -> Submap 4 at (5,8) facing 5; Screen Fade Transition (4, 5, 3); Warp to Castle HQ (30, 1, 8); Engine Action #54; Open Dialogue Message Window; Exit to World Map (51, 2, 255); Warp Room -> Submap 8 at (3,0) facing 5; Engine Action #5; Warp Room -> Submap 30 at (255,2) facing 58 |
| `ev[19]` | `1 (Action / Talk)` | Story Flag 33 (bit 2) SET AND Story Flag 33 (bit 128) CLEAR AND Star of Destiny #0 Recruited AND Story Flag 16 (mask 0) CLEAR AND Story Flag 5 (mask 8) SET | Recruit Character into Active Party (36, 1); Open Shop Menu #4 (Type: 0); Set Render Priority (pri) (0, 32); Bytecode Subroutine Return; Engine Action #9; Warp to Castle HQ (0, 1, 5); Reset Camera Tracking (5); Screen Fade Transition (0, 0, 5); Show Dialogue Portrait (30, 24, 8); Open Dialogue Message Window; Place Scenery Structure (5); Engine Action #9; Engine Action #5; Screen Fade Transition (2, 0, 5); Screen Fade Transition (30, 73, 20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 0 Map 14 Submap 0 at (15,73); Show Dialogue Portrait (41, 2, 0); Warp Room -> Submap 0 at (54,0) facing West (Left); Launch Tactical War Battle (8); Set Combat Battle BGM (10); Set Entity Movement Speed (2, 5); Reset Camera Tracking (4); Exit to World Map (0, 3, 3); Warp Town -> Area 30 Map 1 Submap 8 at (255,254); Engine Action #5; Engine Action #9; Exit to World Map (4, 0, 3); Warp Town -> Area 2 Map 30 Submap 1 at (9,255); Walk obj[1] to (10,54); Open Dialogue Message Window; Reset Camera Tracking (51); Warp Town -> Area 255 Map 1 Submap 5 at (8,3); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp Room -> Submap 30 at (5,9) facing West (Left); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Warp Town -> Area 58 Map 255 Submap 254 at (255,254) |
| `ev[20]` | `1 (Action / Talk)` | Story Flag 33 (bit 2) SET AND Story Flag 33 (bit 128) CLEAR AND Star of Destiny #0 Recruited AND Story Flag 16 (mask 0) CLEAR AND Story Flag 5 (mask 10) SET | Recruit Character into Active Party (36, 1); Open Shop Menu #4 (Type: 0); Set Render Priority (pri) (0, 32); Bytecode Subroutine Return; Engine Action #9; Warp to Castle HQ (0, 1, 5); Reset Camera Tracking (5); Screen Fade Transition (0, 0, 5); Show Dialogue Portrait (30, 24, 8); Open Dialogue Message Window; Place Scenery Structure (5); Engine Action #9; Engine Action #5; Screen Fade Transition (2, 0, 5); Screen Fade Transition (30, 73, 20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 0 Map 14 Submap 0 at (15,73); Show Dialogue Portrait (41, 2, 0); Warp Room -> Submap 0 at (54,0) facing West (Left); Launch Tactical War Battle (8); Set Combat Battle BGM (10); Set Entity Movement Speed (2, 5); Reset Camera Tracking (4); Exit to World Map (0, 3, 3); Warp Town -> Area 30 Map 1 Submap 8 at (255,254); Engine Action #5; Engine Action #9; Exit to World Map (4, 0, 3); Warp Town -> Area 2 Map 30 Submap 1 at (9,255); Walk obj[1] to (10,54); Open Dialogue Message Window; Reset Camera Tracking (51); Warp Town -> Area 255 Map 1 Submap 5 at (8,3); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp Room -> Submap 30 at (5,9) facing West (Left); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Warp Town -> Area 58 Map 255 Submap 254 at (255,254) |
| `ev[21]` | `128 (Loop)` | Story Flag 33 (bit 2) SET AND Story Flag 33 (bit 128) CLEAR AND Inventory Holds Item #1 | Warp Room -> Submap 2 at (13,28); Toggle Random Encounters (1) |
| `ev[22]` | `128 (Loop)` | Story Flag 33 (bit 2) SET AND Story Flag 33 (bit 128) CLEAR AND Inventory Holds Item #2 | Dismiss Emotion Bubble (1); Warp Town -> Area 20 Map 7 Submap 41 at (2,0); Warp Room -> Submap 0 at (115,10) facing 51; Engine Action #51; Warp Town -> Area 255 Map 1 Submap 115 at (10,34); Warp Town -> Area 112 Map 4 Submap 0 at (1,10); Warp Room -> Submap 2 at (0,46) facing 10; Return to Previous Memory Map (4); Screen Fade Transition (33, 8, 37); Warp Town -> Area 47 Map 255 Submap 254 at (255,254) |
| `ev[23]` | `128 (Loop)` | Story Flag 33 (bit 2) SET AND Story Flag 33 (bit 128) CLEAR AND Inventory Holds Item #4 | Dismiss Emotion Bubble (1); Warp Town -> Area 20 Map 7 Submap 41 at (2,0); Warp Room -> Submap 0 at (115,9) facing 51; Engine Action #51; Warp Town -> Area 255 Map 1 Submap 115 at (9,34); Warp Town -> Area 112 Map 4 Submap 0 at (1,9); Warp Room -> Submap 2 at (0,46) facing 10; Return to Previous Memory Map (4); Screen Fade Transition (33, 8, 37); Exit to World Map (47, 255, 254) |
| `ev[24]` | `128 (Loop)` | Story Flag 33 (bit 2) SET AND Story Flag 33 (bit 128) CLEAR AND Inventory Holds Item #8 | Dismiss Emotion Bubble (1); Warp Town -> Area 20 Map 7 Submap 41 at (2,0); Warp Room -> Submap 0 at (115,10) facing 51; Engine Action #115; Engine Action #9; Engine Action #51; Engine Action #51; Warp Town -> Area 255 Map 1 Submap 115 at (10,34); Engine Action #115; Engine Action #9; Return Warp to Castle Base (255, 2); Pathfind and Walk to Coordinates (6, 0, 2); Screen Fade Transition (1, 9, 1); Recruit Jowy Atreides into Battle Slot 0; Make obj[10] Hidden (disp = 0); Return to Previous Memory Map (4); Screen Fade Transition (33, 8, 37); Reset Camera Tracking (47) |
| `ev[25]` | `1 (Action / Talk)` | Story Flag 33 (bit 4) CLEAR AND Star of Destiny #1 Recruited AND Story Flag 16 (mask 1) CLEAR AND Story Flag 1 (mask 35) SET AND Condition Check #55 AND Player Y within Range [26..28] AND Story Flag 1 (mask 255) SET | Recruit Character into Active Party (36, 64); Open Shop Menu #4 (Type: 0); Exit to World Map (0, 42, 24); Reset Camera Tracking (33); Warp Town -> Area 10 Map 9 Submap 46 at (3,0); Warp Room -> Submap 1 at (0,2) facing 47; Set Entity Movement Speed (2, 5); Warp Room -> Submap 5 at (3,1) facing West (Left); Warp to Castle HQ (30, 255, 254); Engine Action #5; Warp Town -> Area 4 Map 5 Submap 2 at (2,1); Warp Town -> Area 30 Map 255 Submap 254 at (50,73); Show Dialogue Portrait (24, 1, 0); Dismiss Dialogue Portrait; Set Combat Battle BGM (15); Close Dialogue Sub-Window (2); Open Dialogue Message Window; Change Portrait Expression (73); Show Dialogue Portrait (11, 4, 2); Engine Action #90; Wait for Audio / Window Sync (3); Open Shop Menu #7 (Type: 0); Exit to World Map (0, 32, 80); Reset Camera Tracking (46); Warp to Castle HQ (0, 1, 2); Warp Room -> Submap 77 at (3,1) facing West (Left); Open Dialogue Message Window; Warp Room -> Submap 2 at (30,78) facing East (Right); Warp Town -> Area 1 Map 0 Submap 2 at (47,11); Warp to Castle HQ (2, 100, 5); Warp Room -> Submap 0 at (5,30) facing West (Left); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp Town -> Area 0 Map 5 Submap 30 at (0,0); Engine Action #5; Show Dialogue Portrait (30, 24, 1); Open Dialogue Message Window; Display Speaker Name Box (5); Warp Town -> Area 5 Map 15 Submap 3 at (0,5); Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 24, 2); Open Dialogue Message Window; Display Choice Selection (5, 1); Engine Action #5; Screen Fade Transition (4, 3, 0); Warp Room -> Submap 0 at (5,10) facing 30; Close Dialogue Sub-Window (1); Open Dialogue Message Window; Branch on Choice (5, 2); Engine Action #5; Screen Fade Transition (3, 0, 5); Screen Fade Transition (30, 24, 2); Open Dialogue Message Window; Execute Choice Result (73); Dismiss Emotion Bubble (24); Warp Town -> Area 0 Map 22 Submap 73 at (100,54); Open Dialogue Message Window; Animate Doorway State (36, 128); Set Combat Battle BGM (110); Close Dialogue Window; Exit to World Map (2, 80, 54); Open Dialogue Message Window; Engine Action #128; Wait for Audio / Window Sync (3); Engine Action #9; Return to Previous Memory Map (4); Display Dialogue Box [Bank: 0, MsgID: 32]; Engine Action #80 |
| `ev[26]` | `128 (Loop)` | Story Flag 33 (bit 4) CLEAR AND Star of Destiny #1 Recruited AND Story Flag 16 (mask 1) CLEAR AND Story Flag 6 (mask 64) SET | Warp Room -> Submap 1 at (13,59); Toggle Random Encounters (64) |
| `ev[27]` | `128 (Loop)` | Story Flag 33 (bit 4) CLEAR AND Star of Destiny #1 Recruited AND Story Flag 16 (mask 1) CLEAR AND Story Flag 6 (mask 128) SET | Engine Action #128; Warp Room -> Submap 0 at (226,0) facing 37; Engine Action #128 |
| `ev[28]` | `1 (Action / Talk)` | Story Flag 33 (bit 4) SET AND Story Flag 33 (bit 8) CLEAR AND Player within Box [32..32, 2..80] AND Condition Check #80 | Recruit Character into Active Party (33, 2); Screen Fade Transition (9, 46, 3); Open Dialogue Message Window; Warp Room -> Submap 1 at (0,2) facing Up (North); Warp Room -> Submap 78 at (3,1) facing Up (North); Open Dialogue Message Window; Warp Room -> Submap 2 at (30,78) facing East (Right); Warp Town -> Area 3 Map 0 Submap 2 at (47,101); Engine Action #9; Reset Camera Tracking (11); Warp to Castle HQ (2, 90, 5); Warp Town -> Area 5 Map 15 Submap 1 at (0,5); Dismiss Emotion Bubble (2); Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (1, 0, 5); Engine Action #5; Warp to Castle HQ (0, 5, 5); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 101, 1); Warp Room -> Submap 2 at (0,23) facing 5; Warp Room -> Submap 10 at (0,0) facing 5; Screen Fade Transition (30, 24, 1); Open Dialogue Message Window; Close Dialogue Sub-Window (73); Show Dialogue Portrait (49, 2, 5); Warp Room -> Submap 5 at (0,2) facing Up (North); Warp Room -> Submap 1 at (1,255) facing 254; Engine Action #5; Warp Town -> Area 4 Map 5 Submap 0 at (2,3); Warp Town -> Area 30 Map 1 Submap 2 at (255,254); Walk obj[9] to (33,8); Engine Action #58 |
| `ev[29]` | `1 (Action / Talk)` | Story Flag 34 (bit 1) SET AND Story Flag 34 (bit 2) CLEAR AND Player within Box [33..33, 2..77] AND Condition Check #77 | Recruit Character into Active Party (33, 2); Screen Fade Transition (9, 46, 3); Open Dialogue Message Window; Open Dialogue Message Window; Open Dialogue Message Window; Warp Room -> Submap 2 at (2,1) facing 36; Engine Action #81; Warp to Castle HQ (1, 1, 0); Warp Room -> Submap 2 at (32,81) facing East (Right); Warp Town -> Area 1 Map 0 Submap 2 at (2,11); Display Emotion Bubble (82, 3); Close Dialogue Window; Warp Room -> Submap 11 at (47,11) facing West (Left); Warp Town -> Area 150 Map 73 Submap 15 at (24,1); Open Dialogue Message Window; Dismiss Character to Castle Base (73); Show Dialogue Portrait (73, 20, 40); Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 0 Map 85 Submap 0 at (86,73); Show Dialogue Portrait (41, 2, 0); Warp Room -> Submap 0 at (24,1) facing South (Down); Engine Action #87; Set Combat Battle BGM (15); Close Dialogue Sub-Window (2); Open Dialogue Message Window; Engine Action #88; Set Combat Battle BGM (15); Close Dialogue Window; Warp Town -> Area 2 Map 150 Submap 34 at (62,0); Screen Fade Transition (62, 0, 9); Wait for Audio / Window Sync (3); Set Special Scene BGM (1); Engine Action #9; Return Warp to Castle Base (2, 9); Return Warp to Castle Base (4, 13); Engine Action #5; Reset Camera Tracking (11); Open Dialogue Message Window; Make Object Hidden (disp = 0) (77); Warp Room -> Submap 1 at (0,89) facing 73; Show Dialogue Portrait (24, 2, 0); Engine Action #90; Set Combat Battle BGM (15); Jump to Bytecode Offset (9, 8); Set Entity Movement Speed (3, 5); Warp Room -> Submap 4 at (5,5) facing Up (North); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Open Dialogue Message Window; Show Dialogue Portrait (30, 1, 1); Engine Action #5; Warp Town -> Area 4 Map 4 Submap 5 at (15,3); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Open Dialogue Message Window; Show Dialogue Portrait (30, 1, 2); Engine Action #5; Close Dialogue Window; Exit to World Map (4, 5, 10); Warp to Castle HQ (0, 5, 5); Open Dialogue Message Window; Show Dialogue Portrait (30, 1, 11); Walk obj[34] to (62,0); Screen Fade Transition (62, 0, 9); Engine Action #102; Open Dialogue Message Window; Set Object Direction (0, 1); Engine Action #146; Jump to Bytecode Offset (1, 0); Engine Action #9; Return Warp to Castle Base (2, 58) |

---

### Submap Layer `vi13_01` (Index 1)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `4`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `3` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (3 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 20 (bit 1) SET | Engine Action #121; Warp Town -> Area 255 Map 254 Submap 255 at (254,204) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [14..34, 2..90] AND Condition Check #91 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 39]; Engine Action #9 |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [14..33, 2..4] AND Temp Event Flag #9 SET AND Player X within Range [255..254] | Display Dialogue Box [Bank: 2, MsgID: 43]; Engine Action #88 |

---

### Submap Layer `vi13_02` (Index 2)

- **Map Number (`mapno`)**: `2`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `4`)
- **Entity Count (`okaz`)**: `4` Objects | **Script Count (`evkaz`)**: `7` Scripts

#### Complete Physical Entity Inventory (4 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 18)** | `0` | `(29, 13)` | `0x0` | Frame 18 | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 19)** | `0` | `(29, 13)` | `0x0` | Frame 19 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | World Device | **Mechanism (ano 18)** | `0` | `(128, 16)` | `0x0` | Frame 18 | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | World Device | **Mechanism (ano 19)** | `0` | `(128, 16)` | `0x0` | Frame 19 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(29, 13)` with state parameter `18`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(29, 13)` with state parameter `19`.
- **`obj[02]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(128, 16)` with state parameter `18`.
- **`obj[03]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(128, 16)` with state parameter `19`.


#### Complete Bytecode Script Catalog (7 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Treasure Byte 2 Bit 1 LOOTED | Make obj[1] Hidden (disp = 0); Reset Camera Tracking (0); Engine Action #9; Teleport obj[255] to (254,255) |
| `ev[01]` | `2 (Map Init)` | Treasure Byte 2 Bit 2 LOOTED | Make obj[1] Hidden (disp = 0); Screen Fade Transition (0, 11, 47) |
| `ev[02]` | `2 (Map Init)` | Story Flag 20 (bit 1) SET | Engine Action #121; Warp Town -> Area 255 Map 254 Submap 255 at (254,204) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [36..50, 2..90] AND Condition Check #91 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 25]; Engine Action #9 |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [86..100, 2..6] AND Temp Event Flag #9 SET AND Player X within Range [255..254] | Display Dialogue Box [Bank: 3, MsgID: 39]; Engine Action #88 |
| `ev[05]` | `1 (Action / Talk)` | Treasure Byte 2 Bit 1 FRESH (Unopened) AND Target Inspected is obj[8] | Recruit Character into Active Party (46, 0); Engine Action #9; Warp Room -> Submap 47 at (101,4) facing 7; Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (0); Exit to World Map (0, 57, 16); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,2) facing West (Left); Engine Action #51; Warp Town -> Area 255 Map 1 Submap 46 at (0,8); Warp Room -> Submap 47 at (255,2) facing 58 |
| `ev[06]` | `1 (Action / Talk)` | Treasure Byte 2 Bit 2 FRESH (Unopened) AND Target Inspected is obj[10] | Recruit Character into Active Party (46, 0); Close Dialogue Window; Warp Room -> Submap 47 at (101,4) facing 7; Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (0); Exit to World Map (0, 19, 0); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,2) facing Up (North); Engine Action #51; Warp Town -> Area 255 Map 1 Submap 46 at (0,10); Warp Room -> Submap 47 at (255,2) facing 58 |

---

### Submap Layer `vi13_03` (Index 3)

- **Map Number (`mapno`)**: `3`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `4`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `4` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (4 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 20 (bit 1) SET | Engine Action #121; Warp Town -> Area 255 Map 254 Submap 255 at (254,204) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [33..45, 2..90] AND Condition Check #91 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 90]; Engine Action #9 |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [98..99, 2..4] AND Party Formation Check AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 4, MsgID: 3]; Set Story Flag (255, 254) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [5..17, 2..6] AND Temp Event Flag #9 SET AND Player X within Range [255..254] | Display Dialogue Box [Bank: 5, MsgID: 40]; Engine Action #88 |

---

### Submap Layer `vi13_04` (Index 4)

- **Map Number (`mapno`)**: `4`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `4`)
- **Entity Count (`okaz`)**: `2` Objects | **Script Count (`evkaz`)**: `4` Scripts

#### Complete Physical Entity Inventory (2 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 18)** | `0` | `(66, 8)` | `0x0` | Frame 18 | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 19)** | `0` | `(66, 8)` | `0x0` | Frame 19 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(66, 8)` with state parameter `18`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(66, 8)` with state parameter `19`.


#### Complete Bytecode Script Catalog (4 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Treasure Byte 2 Bit 4 LOOTED | Make obj[1] Hidden (disp = 0); Reset Camera Tracking (0); Engine Action #9; Teleport obj[255] to (254,255) |
| `ev[01]` | `2 (Map Init)` | Story Flag 20 (bit 1) SET | Engine Action #121; Warp Town -> Area 255 Map 254 Submap 255 at (254,204) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [0..1, 2..15] AND Treasure Byte 9 Bit 2 LOOTED | Display Dialogue Box [Bank: 3, MsgID: 97]; Screen Fade Transition (255, 254, 204) |
| `ev[03]` | `1 (Action / Talk)` | Treasure Byte 2 Bit 4 FRESH (Unopened) AND Target Inspected is obj[8] | Recruit Character into Active Party (46, 0); Engine Action #9; Warp Room -> Submap 47 at (101,4) facing 7; Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (0); Exit to World Map (0, 77, 16); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,2) facing 4; Engine Action #51; Warp Town -> Area 255 Map 1 Submap 46 at (0,8); Warp Room -> Submap 47 at (255,2) facing 58 |

---

### Submap Layer `vi13_05` (Index 5)

- **Map Number (`mapno`)**: `5`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `4`)
- **Entity Count (`okaz`)**: `2` Objects | **Script Count (`evkaz`)**: `5` Scripts

#### Complete Physical Entity Inventory (2 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 18)** | `0` | `(10, 30)` | `0x0` | Frame 18 | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 19)** | `0` | `(10, 30)` | `0x0` | Frame 19 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(10, 30)` with state parameter `18`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(10, 30)` with state parameter `19`.


#### Complete Bytecode Script Catalog (5 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Treasure Byte 2 Bit 8 LOOTED | Make obj[1] Hidden (disp = 0); Reset Camera Tracking (0); Engine Action #9; Teleport obj[255] to (254,255) |
| `ev[01]` | `2 (Map Init)` | Story Flag 20 (bit 1) SET | Engine Action #121; Warp Town -> Area 255 Map 254 Submap 255 at (254,204) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [33..45, 2..90] AND Condition Check #91 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 3, MsgID: 11]; Engine Action #9 |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [60..85, 2..6] AND Temp Event Flag #9 SET AND Player X within Range [255..254] | Display Dialogue Box [Bank: 6, MsgID: 3]; Engine Action #108 |
| `ev[04]` | `1 (Action / Talk)` | Treasure Byte 2 Bit 8 FRESH (Unopened) AND Target Inspected is obj[8] | Recruit Character into Active Party (46, 0); Engine Action #9; Warp Room -> Submap 47 at (101,4) facing 7; Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (0); Exit to World Map (0, 21, 0); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,2) facing 8; Engine Action #51; Warp Town -> Area 255 Map 1 Submap 46 at (0,8); Warp Room -> Submap 47 at (255,2) facing 58 |

---

### Submap Layer `vi13_06` (Index 6)

- **Map Number (`mapno`)**: `6`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `4`)
- **Entity Count (`okaz`)**: `8` Objects | **Script Count (`evkaz`)**: `12` Scripts

#### Complete Physical Entity Inventory (8 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 18)** | `0` | `(173, 105)` | `0x0` | Frame 18 | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 19)** | `0` | `(173, 105)` | `0x0` | Frame 19 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | World Device | **Mechanism (ano 18)** | `0` | `(107, 53)` | `0x0` | Frame 18 | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | World Device | **Mechanism (ano 19)** | `0` | `(107, 53)` | `0x0` | Frame 19 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[04]` | World Device | **Mechanism (ano 18)** | `0` | `(23, 15)` | `0x0` | Frame 18 | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[05]` | World Device | **Mechanism (ano 19)** | `0` | `(23, 15)` | `0x0` | Frame 19 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[06]` | World Device | **Mechanism (ano 18)** | `0` | `(169, 23)` | `0x0` | Frame 18 | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[07]` | World Device | **Mechanism (ano 19)** | `0` | `(169, 23)` | `0x0` | Frame 19 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(173, 105)` with state parameter `18`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(173, 105)` with state parameter `19`.
- **`obj[02]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(107, 53)` with state parameter `18`.
- **`obj[03]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(107, 53)` with state parameter `19`.
- **`obj[04]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(23, 15)` with state parameter `18`.
- **`obj[05]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(23, 15)` with state parameter `19`.
- **`obj[06]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(169, 23)` with state parameter `18`.
- **`obj[07]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(169, 23)` with state parameter `19`.


#### Complete Bytecode Script Catalog (12 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Treasure Byte 2 Bit 16 LOOTED | Make obj[1] Hidden (disp = 0); Reset Camera Tracking (0); Engine Action #9; Teleport obj[255] to (254,255) |
| `ev[01]` | `2 (Map Init)` | Treasure Byte 2 Bit 32 LOOTED | Make obj[1] Hidden (disp = 0); Screen Fade Transition (0, 11, 47) |
| `ev[02]` | `2 (Map Init)` | Treasure Byte 2 Bit 64 LOOTED | Make obj[1] Hidden (disp = 0); Display Dialogue Box [Bank: 0, MsgID: 13]; Teleport obj[255] to (254,255) |
| `ev[03]` | `2 (Map Init)` | Treasure Byte 2 Bit 128 LOOTED | Make obj[1] Hidden (disp = 0); Animate Door Open; Open Dialogue Message Window; Show Dialogue Portrait (47, 255, 254) |
| `ev[04]` | `2 (Map Init)` | Story Flag 20 (bit 1) SET | Engine Action #121; Warp Town -> Area 255 Map 254 Submap 255 at (254,204) |
| `ev[05]` | `1 (Action / Talk)` | Player within Box [0..1, 2..103] AND Condition Check #118 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 5, MsgID: 68]; Engine Action #9 |
| `ev[06]` | `1 (Action / Talk)` | Player within Box [198..200, 2..23] AND Condition Check #37 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 7, MsgID: 3]; Engine Action #52 |
| `ev[07]` | `1 (Action / Talk)` | Player within Box [198..200, 2..57] AND Condition Check #75 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 7, MsgID: 3]; Load Sound Bank into Memory (255, 254) |
| `ev[08]` | `1 (Action / Talk)` | Treasure Byte 2 Bit 16 FRESH (Unopened) AND Target Inspected is obj[8] | Recruit Character into Active Party (46, 0); Engine Action #9; Warp Room -> Submap 47 at (101,4) facing 7; Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (0); Exit to World Map (0, 32, 80); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,2) facing 16; Engine Action #51; Warp Town -> Area 255 Map 1 Submap 46 at (0,8); Warp Room -> Submap 47 at (255,2) facing 58 |
| `ev[09]` | `1 (Action / Talk)` | Treasure Byte 2 Bit 32 FRESH (Unopened) AND Target Inspected is obj[10] | Recruit Character into Active Party (46, 0); Close Dialogue Window; Warp Room -> Submap 47 at (101,4) facing 7; Fade Out to Black (106); Engine Action #53; Place Scenery Structure (1); Warp Room -> Submap 107 at (0,20) facing 97; Warp Town -> Area 32 Map 101 Submap 4 at (2,58) |
| `ev[10]` | `1 (Action / Talk)` | Treasure Byte 2 Bit 64 FRESH (Unopened) AND Target Inspected is obj[12] | Recruit Character into Active Party (46, 0); Place Scenery Structure (1); Display Dialogue Box [Bank: 47, MsgID: 101]; Exit to World Map (7, 101, 4); Pan Camera (30, 0, 4); Open Dialogue Message Window; Display Chapter Text (80); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,2) facing 64; Engine Action #51; Warp Town -> Area 255 Map 1 Submap 46 at (0,12); Warp Room -> Submap 47 at (255,2) facing 58 |
| `ev[11]` | `1 (Action / Talk)` | Treasure Byte 2 Bit 128 FRESH (Unopened) AND Target Inspected is obj[14] | Recruit Character into Active Party (46, 0); Show Dialogue Portrait (1, 14, 47); Jump to Bytecode Offset (4, 7); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (0); Exit to World Map (0, 81, 32); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,2) facing 128; Engine Action #51; Warp Town -> Area 255 Map 1 Submap 46 at (0,14); Warp Room -> Submap 47 at (255,2) facing 58 |

---

### Submap Layer `vi13_07` (Index 7)

- **Map Number (`mapno`)**: `7`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `4`)
- **Entity Count (`okaz`)**: `3` Objects | **Script Count (`evkaz`)**: `6` Scripts

#### Complete Physical Entity Inventory (3 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(89, 64)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 18)** | `0` | `(69, 58)` | `0x0` | Frame 18 | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | World Device | **Mechanism (ano 19)** | `0` | `(69, 58)` | `0x0` | Frame 19 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(89, 64)` to `(91, 65)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(69, 58)` with state parameter `18`.
- **`obj[02]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(69, 58)` with state parameter `19`.


#### Complete Bytecode Script Catalog (6 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Treasure Byte 3 Bit 1 LOOTED | Make obj[1] Hidden (disp = 0); Engine Action #9; Open Dialogue Message Window; Screen Fade Transition (47, 255, 254) |
| `ev[01]` | `2 (Map Init)` | Story Flag 20 (bit 1) SET | Engine Action #121; Warp Town -> Area 255 Map 254 Submap 255 at (254,204) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [0..1, 2..44] AND Condition Check #60 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 6, MsgID: 196]; Warp Room -> Submap 255 at (254,204) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [0..1, 2..67] AND Condition Check #78 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 6, MsgID: 196]; Wait for Audio / Window Sync (255) |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [40..55, 2..6] AND Temp Event Flag #9 SET AND Player X within Range [255..254] | Display Dialogue Box [Bank: 8, MsgID: 24]; Engine Action #88 |
| `ev[05]` | `1 (Action / Talk)` | Treasure Byte 3 Bit 1 FRESH (Unopened) AND Target Inspected is obj[9] | Recruit Character into Active Party (46, 0); Screen Fade Transition (1, 9, 47); Jump to Bytecode Offset (4, 7); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (0); Exit to World Map (0, 83, 16); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,3) facing West (Left); Engine Action #51; Warp Town -> Area 255 Map 1 Submap 46 at (0,9); Warp Room -> Submap 47 at (255,2) facing 58 |

---

### Submap Layer `vi13_08` (Index 8)

- **Map Number (`mapno`)**: `8`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `4`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `4` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (4 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 20 (bit 1) SET | Engine Action #121; Warp Town -> Area 255 Map 254 Submap 255 at (254,204) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [17..33, 2..90] AND Condition Check #91 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 7, MsgID: 47]; Engine Action #9 |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [16..32, 2..6] AND Temp Event Flag #9 SET AND Player X within Range [255..254] | Warp Room -> Submap 1 at (8,14); Warp Map Transition (2, 250, 0, 0, 255) |
| `ev[03]` | `128 (Loop)` | Player within Box [20..30, 2..87] AND Condition Check #88 AND Story Flag 1 (mask 255) SET | Warp Room -> Submap 1 at (8,14) |

---



## Location Map: `vi15`

- **Master Map Container**: `vi15.json`
- **Submap Layer Files**: vi15_00.json, vi15_02.json, vi15_03.json, vi15_04.json
- **Collision Grid Files**: None
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 2

### Submap Layer `vi15_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `5` Objects | **Script Count (`evkaz`)**: `16` Scripts

#### Complete Physical Entity Inventory (5 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | Prop / Scenery | **Prop ID 64973** | `64973` | `(56, 5)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 180 |
| `obj[01]` | Prop / Scenery | **Prop ID 64973** | `64973` | `(56, 5)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 180 |
| `obj[02]` | NPC / Actor | **Actor ID 65166** | `65166` | `(56, 28)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | Prop / Scenery | **Prop ID 64617** | `64617` | `(56, 28)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[04]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(26, 77)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Prop: Object 64973)**: Environmental world dressing prop placed at tile `(56, 5)`. Solid collision is set to `32`.
- **`obj[01]` (Prop: Object 64973)**: Environmental world dressing prop placed at tile `(56, 5)`. Solid collision is set to `32`.
- **`obj[02]` (Object 65166)**: Positioned at tile `(56, 28)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Prop: Object 64617)**: Environmental world dressing prop placed at tile `(56, 28)`. Solid collision is set to `2`.
- **`obj[04]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(26, 77)` to `(28, 79)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (16 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Always Passes (Unconditional) | Animate Door obj[8] (State: 12); Open Dialogue Message Window; Return to Previous Memory Map (88) |
| `ev[01]` | `2 (Map Init)` | Story Flag 33 (bit 16) CLEAR | Make obj[0] Hidden (disp = 0); Close Dialogue Window; Engine Action #89; Close Dialogue Window; Warp Town -> Area 0 Map 0 Submap 8 at (89,8); Warp Town -> Area 0 Map 104 Submap 0 at (9,0); Open Dialogue Message Window; Engine Action #9; Engine Action #89; Engine Action #9; Warp Town -> Area 2 Map 47 Submap 255 at (254,255) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [45..59, 2..90] AND Condition Check #91 AND Story Flag 0 (mask 255) SET | Warp Room -> Submap 0 at (8,12); Warp Map Transition (3, 8, 24, 9, 255) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [32..46, 2..6] AND Temp Event Flag #9 SET AND Player X within Range [255..254] | Display Dialogue Box [Bank: 1, MsgID: 46]; Engine Action #88 |
| `ev[04]` | `1 (Action / Talk)` | Story Flag 33 (bit 8) SET AND Story Flag 33 (bit 16) CLEAR AND Player within Box [55..65, 2..51] AND Condition Check #52 AND Story Flag 1 (mask 255) SET | Recruit Character into Active Party (36, 2); Open Shop Menu #4 (Type: 0); Launch Tactical War Battle (4); Set Render Priority (pri) (0, 57); Teleport obj[8] to (33,2); Engine Action #9; Screen Fade Transition (46, 0, 1); Open Dialogue Message Window; Warp Town -> Area 47 Map 49 Submap 2 at (5,1); Exit to World Map (5, 2, 2); Warp Room -> Submap 30 at (255,254) facing 5; Warp Town -> Area 4 Map 5 Submap 3 at (2,1); Warp Town -> Area 30 Map 255 Submap 254 at (50,24); Warp Room -> Submap 26 at (36,8) facing 24; Warp Town -> Area 0 Map 27 Submap 101 at (0,180); Engine Action #54; Open Dialogue Message Window; Reset Camera Tracking (73); Trigger Character Emotion Effect (36, 16); Jump to Bytecode Offset (0, 181); Set Entity Movement Speed (4, 5); Warp Town -> Area 5 Map 5 Submap 1 at (0,30); Engine Action #5; Warp Room -> Submap 10 at (1,0) facing 30; Engine Action #90; Reset Camera Tracking (4); Engine Action #6; Engine Action #5; Recruit Character into Active Party (16, 29); Dismiss Emotion Bubble (255); Engine Action #90; Engine Action #9; Exit to World Map (5, 16, 29); Dismiss Emotion Bubble (255); Walk obj[101] to (5,181); Set Combat Battle BGM (15); Engine Action #54; Open Dialogue Message Window; Warp Town -> Area 69 Map 2 Submap 83 at (1,240); Engine Action #9; Return to Previous Memory Map (16) |
| `ev[05]` | `128 (Loop)` | Story Flag 33 (bit 8) SET AND Story Flag 33 (bit 16) CLEAR AND Inventory Holds Item #2 | Warp Room -> Submap 0 at (15,14); Toggle Random Encounters (2) |
| `ev[06]` | `128 (Loop)` | Story Flag 33 (bit 8) SET AND Story Flag 33 (bit 16) CLEAR AND Inventory Holds Item #4 | Display Chapter Text (1); Display Dialogue Box [Bank: 5, MsgID: 37]; Exit to World Map (255, 254, 255) |
| `ev[07]` | `128 (Loop)` | Story Flag 33 (bit 8) SET AND Story Flag 33 (bit 16) CLEAR AND Inventory Holds Item #8 | Set Entity Movement Speed (3, 5); Warp Room -> Submap 4 at (1,2) facing East (Right); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Warp Town -> Area 4 Map 6 Submap 1 at (4,2); Warp Town -> Area 30 Map 255 Submap 254 at (5,0); Exit to World Map (4, 1, 2); Dismiss Emotion Bubble (255); Walk obj[37] to (8,255) |
| `ev[08]` | `128 (Loop)` | Story Flag 33 (bit 8) SET AND Story Flag 33 (bit 16) CLEAR AND Inventory Holds Item #16 | Display Chapter Text (1); Reset Camera Tracking (5); Toggle Random Encounters (16) |
| `ev[09]` | `1 (Action / Talk)` | Story Flag 33 (bit 16) SET AND Story Flag 33 (bit 32) CLEAR AND Player within Box [57..57, 2..45] AND Condition Check #45 | Recruit Character into Active Party (5, 0); Exit to World Map (7, 1, 10); Dismiss Emotion Bubble (46); Warp to Castle HQ (0, 1, 2); Warp Room -> Submap 33 at (3,1) facing West (Left); Open Dialogue Message Window; Warp Room -> Submap 2 at (58,34) facing East (Right); Warp Town -> Area 1 Map 0 Submap 2 at (1,8); Warp Room -> Submap 89 at (11,2) facing West (Left); Teleport obj[29] to (7,36); Warp Town -> Area 5 Map 1 Submap 4 at (3,5); Trigger Character Emotion Effect (1, 1); Dismiss Emotion Bubble (73); Dismiss Emotion Bubble (24); Screen Fade Transition (0, 30, 89); Close Dialogue Window; Warp Town -> Area 2 Map 73 Submap 15 at (24,1); Open Dialogue Message Window; Warp Room -> Submap 73 at (15,89); Close Dialogue Window; Warp Town -> Area 3 Map 24 Submap 10 at (0,32); Set Combat Battle BGM (15); Close Dialogue Sub-Window (1); Open Dialogue Message Window; Return to Previous Memory Map (73); Show Dialogue Portrait (24, 10, 0); Return Warp to Castle Base (73, 15); Set Combat Battle BGM (15); Engine Action #89; Close Dialogue Window; Warp Town -> Area 4 Map 24 Submap 10 at (0,35); Engine Action #89; Close Dialogue Window; Engine Action #5; Engine Action #89; Close Dialogue Window; Engine Action #5; Make obj[0] Hidden (disp = 0); Screen Fade Transition (1, 11, 47); Set Combat Battle BGM (15); Set Combat Battle BGM (20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 0 Map 36 Submap 0 at (37,73); Show Dialogue Portrait (41, 2, 0); Warp Room -> Submap 0 at (24,10) facing South (Down); Open Save Crystal Menu (MSaveInit); Set Combat Battle BGM (15); Close Dialogue Sub-Window (1); Open Dialogue Message Window; Engine Action #39; Engine Action #51; Warp Town -> Area 255 Map 1 Submap 5 at (1,3); Open Dialogue Message Window; Engine Action #5; Screen Fade Transition (30, 24, 1); Open Dialogue Message Window; Engine Action #40; Engine Action #5; Warp Room -> Submap 0 at (30,255) facing Up (North); Set Combat Battle BGM (15); Set Entity Movement Speed (4, 5); Warp Room -> Submap 10 at (3,0) facing 5; Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Warp Town -> Area 5 Map 15 Submap 2 at (0,5); Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp to Castle HQ (0, 5, 5); Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Screen Fade Transition (5, 20, 6); Warp Town -> Area 30 Map 255 Submap 254 at (50,36); Exit to World Map (24, 10, 0); Award Potch Loot (+18,703 Potch); Close Dialogue Sub-Window (1); Open Dialogue Message Window; Remove Item from Inventory (73, 15); Close Dialogue Sub-Window (10); Open Dialogue Message Window; Open Shop Menu #15 (Type: 73); Close Dialogue Sub-Window (1); Open Dialogue Message Window; Engine Action #44; Set Combat Battle BGM (60); Close Dialogue Sub-Window (2); Open Dialogue Message Window; Make obj[5] Visible (disp = 1); Warp Room -> Submap 10 at (3,0) facing 5; Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Engine Action #5; Dismiss Emotion Bubble (5); Warp Town -> Area 2 Map 0 Submap 5 at (10,30); Close Dialogue Sub-Window (1); Open Dialogue Message Window; Make obj[73] Hidden (disp = 0); Show Dialogue Portrait (24, 10, 0); Teleport obj[101] to (9,9); Set Combat Battle BGM (15); Launch Tactical War Battle (8); Set Entity Movement Speed (2, 5); Warp Room -> Submap 4 at (0,3) facing East (Right); Warp Room -> Submap 1 at (1,255) facing 254; Engine Action #5; Warp Town -> Area 4 Map 4 Submap 0 at (1,2); Warp Room -> Submap 1 at (2,255) facing 254; Walk obj[73] to (15,34); Jump to Bytecode Offset (1, 0); Engine Action #9; Return to Previous Memory Map (32); Engine Action #58 |
| `ev[10]` | `128 (Loop)` | Story Flag 33 (bit 16) SET AND Story Flag 33 (bit 32) CLEAR AND Inventory Holds Item #2 | Close Dialogue Window; Warp Room -> Submap 100 at (37,2) facing 255 |
| `ev[11]` | `128 (Loop)` | Story Flag 33 (bit 16) SET AND Story Flag 33 (bit 32) CLEAR AND Inventory Holds Item #4 | Set Entity Movement Speed (3, 5); Warp Room -> Submap 20 at (3,0) facing 5; Engine Action #5; Warp Room -> Submap 30 at (255,254) facing 5; Warp Town -> Area 5 Map 25 Submap 2 at (0,5); Engine Action #5; Warp Room -> Submap 30 at (255,254) facing 5; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (3, 0, 5); Engine Action #5; Warp Room -> Submap 30 at (255,254) facing 50; Toggle Random Encounters (4) |
| `ev[12]` | `128 (Loop)` | Story Flag 33 (bit 16) SET AND Story Flag 33 (bit 32) CLEAR AND Inventory Holds Item #8 | Engine Action #5; Screen Fade Transition (4, 5, 1); Screen Fade Transition (2, 10, 1); Engine Action #5; Warp Town -> Area 4 Map 1 Submap 14 at (30,1); Screen Fade Transition (37, 8, 255) |
| `ev[13]` | `1 (Action / Talk)` | Story Flag 33 (bit 32) SET AND Story Flag 33 (bit 64) CLEAR AND Player within Box [43..60, 2..82] AND Condition Check #85 AND Story Flag 0 (mask 255) SET | Recruit Character into Active Party (46, 2); Screen Fade Transition (55, 58, 0); Screen Fade Transition (47, 5, 10); Exit to World Map (5, 0, 10); Dismiss Emotion Bubble (5); Open Dialogue Message Window; Warp Town -> Area 0 Map 5 Submap 5 at (1,0); Dismiss Emotion Bubble (24); Screen Fade Transition (0, 48, 73); Show Dialogue Portrait (49, 2, 5); Open Dialogue Message Window; Exit to World Map (4, 1, 2); Dismiss Emotion Bubble (255); Engine Action #5; Screen Fade Transition (4, 5, 3); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp Room -> Submap 30 at (255,254) facing 50; Warp Room -> Submap 58 at (255,254) facing 255 |
| `ev[14]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Launch Tactical War Battle (1); Fade In from Black (1); Exit to World Map (73, 20, 40); Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 1 Map 2 Submap 1 at (3,73); Branch on Choice (41, 2); Open Dialogue Message Window; Warp Room -> Submap 0 at (54,0) facing West (Left); Recruit Invisible / Hitbox Trigger into Battle Slot 1; Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[15]` | `128 (Loop)` | Inventory Holds Item #1 | Warp Room -> Submap 0 at (13,44); Toggle Random Encounters (1) |

---

### Submap Layer `vi15_01` (Index 1)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `5` Objects | **Script Count (`evkaz`)**: `11` Scripts

#### Complete Physical Entity Inventory (5 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 65166** | `65166` | `(38, 35)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | Prop / Scenery | **Prop ID 64822** | `64822` | `(38, 26)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[02]` | Prop / Scenery | **Prop ID 64822** | `64822` | `(38, 26)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[03]` | Prop / Scenery | **Prop ID 33034** | `33034` | `(31, 48)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | Prop / Scenery | **Prop ID 33034** | `33034` | `(31, 48)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 65166)**: Positioned at tile `(38, 35)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Prop: Object 64822)**: Environmental world dressing prop placed at tile `(38, 26)`. Solid collision is set to `2`.
- **`obj[02]` (Prop: Object 64822)**: Environmental world dressing prop placed at tile `(38, 26)`. Solid collision is set to `2`.
- **`obj[03]` (Prop: Object 33034)**: Environmental world dressing prop placed at tile `(31, 48)`. Solid collision is set to `0`.
- **`obj[04]` (Prop: Object 33034)**: Environmental world dressing prop placed at tile `(31, 48)`. Solid collision is set to `0`.


#### Complete Bytecode Script Catalog (11 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 33 (bit 32) SET AND Story Flag 33 (bit 64) CLEAR | Make obj[0] Hidden (disp = 0); Reset Camera Tracking (0); Engine Action #9; Warp Room -> Submap 89 at (9,2) facing South (Down); Engine Action #89; Screen Fade Transition (2, 5, 47) |
| `ev[01]` | `2 (Map Init)` | Story Flag 34 (bit 1) SET | Make obj[0] Hidden (disp = 0); Screen Fade Transition (89, 10, 2); Engine Action #5; Teleport obj[255] to (254,255) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [38..55, 2..90] AND Condition Check #91 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 39]; Engine Action #9 |
| `ev[03]` | `1 (Action / Talk)` | Story Flag 33 (bit 32) SET AND Story Flag 33 (bit 64) CLEAR AND Player within Box [25..50, 2..47] AND Condition Check #48 AND Story Flag 1 (mask 255) SET | Recruit Character into Active Party (36, 8); Jump to Bytecode Offset (9, 8); Open Shop Menu #4 (Type: 0); Set Render Priority (pri) (0, 38); Teleport obj[9] to (36,1); Set Render Priority (pri) (0, 38); Engine Action #40; Reset Camera Tracking (33); Warp Town -> Area 9 Map 10 Submap 46 at (0,1); Open Dialogue Message Window; Warp Town -> Area 47 Map 49 Submap 2 at (5,1); Exit to World Map (5, 2, 1); Warp Room -> Submap 30 at (255,254) facing 5; Warp Town -> Area 4 Map 5 Submap 3 at (2,1); Warp Room -> Submap 255 at (254,50) facing 73; Show Dialogue Portrait (24, 1, 0); Set Entity Movement Speed (54, 0); Reset Camera Tracking (101); Warp Room -> Submap 5 at (8,5) facing 10; Warp Town -> Area 0 Map 5 Submap 5 at (0,0); Engine Action #5; Screen Fade Transition (30, 24, 8); Open Dialogue Message Window; Walk obj[73] to (15,24); Warp Room -> Submap 51 at (5,8) facing 5; Screen Fade Transition (4, 4, 2); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp Room -> Submap 30 at (24,8) facing South (Down); Engine Action #52; Set Entity Movement Speed (2, 5); Warp Room -> Submap 15 at (4,3) facing West (Left); Exit to World Map (5, 10, 30); Engine Action #5; Reset Camera Tracking (5); Show Dialogue Portrait (2, 0, 7); Warp Room -> Submap 30 at (1,0) facing 30; Walk obj[24] to (1,0); Engine Action #53; Engine Action #5; Warp Town -> Area 4 Map 3 Submap 5 at (10,1); Warp Room -> Submap 1 at (1,2) facing 5; Screen Fade Transition (30, 24, 2); Open Dialogue Message Window; Engine Action #54; Launch Tactical War Battle (2); Close Dialogue Sub-Window (8); Open Dialogue Message Window; Set Render Priority (pri) (73, 15); Close Dialogue Sub-Window (1); Open Dialogue Message Window; Set Animation Pose (5, 8); Engine Action #5; Screen Fade Transition (1, 0, 5); Screen Fade Transition (30, 24, 8); Open Dialogue Message Window; Recruit Character into Active Party (36, 4); Close Dialogue Sub-Window (1); Open Dialogue Message Window; Engine Action #58; Make obj[9] Hidden (disp = 0); Return to Previous Memory Map (64); Toggle Random Encounters (254); Teleport obj[255] to (254,255) |
| `ev[04]` | `128 (Loop)` | Story Flag 33 (bit 32) SET AND Story Flag 33 (bit 64) CLEAR AND Inventory Holds Item #1 | Display Chapter Text (1); Close Dialogue Window; Exit to World Map (37, 1, 255) |
| `ev[05]` | `128 (Loop)` | Story Flag 33 (bit 32) SET AND Story Flag 33 (bit 64) CLEAR AND Inventory Holds Item #2 | Engine Action #5; Reset Camera Tracking (4); Exit to World Map (5, 15, 1); Warp Town -> Area 2 Map 0 Submap 7 at (1,6); Warp Room -> Submap 1 at (6,1) facing 30; Toggle Random Encounters (2) |
| `ev[06]` | `128 (Loop)` | Story Flag 33 (bit 32) SET AND Story Flag 33 (bit 64) CLEAR AND Inventory Holds Item #4 | Engine Action #5; Reset Camera Tracking (5); Warp to Castle HQ (6, 2, 2); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (37); Exit to World Map (255, 254, 255) |
| `ev[07]` | `128 (Loop)` | Story Flag 33 (bit 32) SET AND Story Flag 33 (bit 64) CLEAR AND Inventory Holds Item #8 | Set Object Direction (0, 0); Engine Action #161; Toggle Random Encounters (8) |
| `ev[08]` | `1 (Action / Talk)` | Story Flag 150 (bit 2) SET AND Story Flag 33 (bit 64) SET AND Story Flag 33 (bit 128) CLEAR AND Player within Box [38..38, 2..40] AND Condition Check #40 AND Story Flag 1 (mask 255) SET | Engine Action #5; Warp Room -> Submap 30 at (2,0) facing 30; Make obj[2] Hidden (disp = 0); Display Dialogue Box [Bank: 37, MsgID: 34]; Engine Action #89; Display Dialogue Box [Bank: 2, MsgID: 13]; Open Dialogue Message Window; Display Dialogue Box [Bank: 1, MsgID: 1]; Teleport obj[73] to (60,89); Display Dialogue Box [Bank: 2, MsgID: 14]; Close Dialogue Sub-Window (1); Open Dialogue Message Window; Set obj[9] Collision to Passable; Engine Action #128 |
| `ev[09]` | `1 (Action / Talk)` | Story Flag 150 (bit 2) CLEAR AND Story Flag 33 (bit 64) SET AND Story Flag 33 (bit 128) CLEAR AND Player within Box [38..38, 2..40] AND Condition Check #40 AND Story Flag 1 (mask 255) SET | Engine Action #5; Warp Room -> Submap 30 at (2,0) facing 30; Make obj[2] Hidden (disp = 0); Display Dialogue Box [Bank: 37, MsgID: 34]; Engine Action #89; Display Dialogue Box [Bank: 2, MsgID: 13]; Open Dialogue Message Window; Display Dialogue Box [Bank: 1, MsgID: 1]; Teleport obj[73] to (60,89); Display Dialogue Box [Bank: 2, MsgID: 14]; Close Dialogue Sub-Window (1); Open Dialogue Message Window; Trigger Character Emotion Effect (9, 33); Engine Action #128 |
| `ev[10]` | `1 (Action / Talk)` | Story Flag 33 (bit 128) SET AND Story Flag 34 (bit 1) CLEAR AND Player within Box [38..38, 2..40] AND Condition Check #40 AND Story Flag 1 (mask 255) SET | Recruit Character into Active Party (5, 2); Engine Action #5; Trigger Character Emotion Effect (1, 4); Warp Town -> Area 1 Map 1 Submap 1 at (2,2); Warp Room -> Submap 5 at (60,30) facing 46; Warp Town -> Area 11 Map 36 Submap 30 at (89,11); Warp Town -> Area 0 Map 0 Submap 11 at (1,2); Teleport obj[89] to (11,5); Engine Action #89; Close Dialogue Window; Engine Action #5; Engine Action #89; Close Dialogue Window; Warp Town -> Area 1 Map 24 Submap 2 at (0,61); Set Combat Battle BGM (5); Engine Action #89; Display Dialogue Box [Bank: 2, MsgID: 16]; Engine Action #5; Reset Camera Tracking (5); Engine Action #5; Engine Action #6; Warp Room -> Submap 0 at (30,89) facing 12; Engine Action #5; Engine Action #89; Display Dialogue Box [Bank: 5, MsgID: 89]; Display Dialogue Box [Bank: 2, MsgID: 20]; Set Combat Battle BGM (15); Set Combat Battle BGM (20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 0 Map 62 Submap 0 at (63,5); Reset Camera Tracking (5); Show Dialogue Portrait (6, 1, 30); Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (24,8) facing South (Down); Animate Doorway State (51, 2); Warp Room -> Submap 8 at (0,65) facing 255; Warp Town -> Area 89 Map 12 Submap 5 at (89,12); Engine Action #5; Make obj[3] Hidden (disp = 0); Warp Room -> Submap 0 at (1,1) facing 12; Teleport obj[5] to (2,5); Show Dialogue Portrait (3, 0, 5); Show Dialogue Portrait (30, 89, 11); Warp Town -> Area 2 Map 89 Submap 11 at (5,89); Close Dialogue Window; Engine Action #5; Close Dialogue Sub-Window (2); Open Dialogue Message Window; Engine Action #66; Engine Action #89; Close Dialogue Window; Warp Town -> Area 4 Map 89 Submap 11 at (5,89); Close Dialogue Window; Engine Action #5; Engine Action #89; Close Dialogue Window; Warp Town -> Area 5 Map 89 Submap 11 at (5,89); Close Dialogue Window; Engine Action #5; Engine Action #89; Close Dialogue Window; Warp Town -> Area 1 Map 73 Submap 15 at (24,8); Open Dialogue Message Window; Open Shop Interface #5; Reset Camera Tracking (0); Open Dialogue Message Window; Dismiss Emotion Bubble (73); Dismiss Emotion Bubble (24); Warp Room -> Submap 68 at (5,8) facing 4; Engine Action #5; Engine Action #5; Screen Fade Transition (2, 1, 0); Warp to Castle HQ (2, 0, 5); Screen Fade Transition (30, 24, 8); Open Dialogue Message Window; Wait for Audio / Window Sync (5); Reset Camera Tracking (5); Screen Fade Transition (0, 0, 5); Screen Fade Transition (30, 24, 8); Open Dialogue Message Window; Recruit Flik into Battle Slot 8; Engine Action #5; Screen Fade Transition (2, 0, 5); Engine Action #5; Warp Room -> Submap 30 at (5,1) facing 5; Trigger Character Emotion Effect (1, 0); Engine Action #5; Engine Action #5; Dismiss Emotion Bubble (54); Open Dialogue Message Window; Warp Room -> Submap 9 at (8,24) facing West (Left); Open Dialogue Message Window; Remove Character from Active Party (73); Screen Fade Transition (5, 1, 4); Exit to World Map (1, 2, 3); Warp Room -> Submap 1 at (30,46) facing Up (North); Display Dialogue Box [Bank: 38, MsgID: 31]; Engine Action #89; Display Dialogue Box [Bank: 2, MsgID: 17]; Open Dialogue Message Window; Display Dialogue Box [Bank: 1, MsgID: 1]; Teleport obj[89] to (12,5); Engine Action #89; Display Dialogue Box [Bank: 5, MsgID: 89]; Display Dialogue Box [Bank: 2, MsgID: 18]; Engine Action #89; Close Dialogue Window; Warp Town -> Area 6 Map 89 Submap 11 at (5,89); Close Dialogue Window; Engine Action #5; Engine Action #89; Close Dialogue Window; Warp Town -> Area 7 Map 46 Submap 3 at (2,3); Open Dialogue Message Window; Warp Town -> Area 1 Map 11 Submap 47 at (89,12); Warp Town -> Area 19 Map 89 Submap 12 at (5,89); Display Dialogue Box [Bank: 5, MsgID: 89]; Display Dialogue Box [Bank: 2, MsgID: 20]; Make obj[3] Hidden (disp = 0); Warp Room -> Submap 0 at (1,1) facing 12; Teleport obj[5] to (2,5); Screen Fade Transition (1, 0, 5); Trigger Character Emotion Effect (30, 89); Engine Action #9; Warp Town -> Area 1 Map 73 Submap 10 at (101,0); Engine Action #177; Set Combat Battle BGM (110); Jump to Bytecode Offset (0, 179); Engine Action #89; Engine Action #9; Engine Action #5; Engine Action #89; Engine Action #9; Engine Action #5; Engine Action #89; Engine Action #9; Warp Town -> Area 2 Map 73 Submap 5 at (101,0); Engine Action #176; Set Combat Battle BGM (55); Engine Action #89; Engine Action #9; Warp Town -> Area 3 Map 89 Submap 9 at (5,89); Engine Action #9; Engine Action #5; Engine Action #89; Engine Action #9; Warp Town -> Area 4 Map 89 Submap 9 at (5,89); Engine Action #9; Engine Action #5; Engine Action #5; Warp Room -> Submap 4 at (7,2) facing 30; Make obj[0] Hidden (disp = 0); Screen Fade Transition (89, 9, 2); Engine Action #6; Teleport obj[49] to (2,90); Engine Action #9; Exit to World Map (6, 16, 3); Dismiss Emotion Bubble (255); Engine Action #5; Warp Town -> Area 5 Map 5 Submap 3 at (0,7); Warp Room -> Submap 255 at (254,50) facing 46; Warp Town -> Area 11 Map 35 Submap 30 at (89,11); Warp Town -> Area 7 Map 0 Submap 11 at (1,2); Teleport obj[89] to (11,2); Reset Camera Tracking (89); Engine Action #9; Engine Action #5; Engine Action #89; Engine Action #9; Engine Action #5; Engine Action #89; Engine Action #9; Warp Town -> Area 7 Map 89 Submap 9 at (5,89); Engine Action #9; Engine Action #5; Engine Action #89; Engine Action #9; Warp Town -> Area 9 Map 89 Submap 9 at (5,89); Engine Action #9; Engine Action #5; Engine Action #89; Engine Action #9; Warp Town -> Area 10 Map 73 Submap 5 at (101,0); Engine Action #176; Set Combat Battle BGM (45); Engine Action #89; Engine Action #9; Warp Town -> Area 11 Map 89 Submap 9 at (5,89); Engine Action #9; Engine Action #5; Engine Action #89; Engine Action #9; Warp Town -> Area 12 Map 89 Submap 9 at (2,13); Jump to Bytecode Offset (1, 2); Close Dialogue Sub-Window (8); Open Dialogue Message Window; Load Sound Bank into Memory (73, 15); Close Dialogue Sub-Window (1); Open Dialogue Message Window; Set Combat Battle BGM (73); Show Dialogue Portrait (89, 9, 2); Animate Door Open; Engine Action #89; Close Dialogue Window; Warp Town -> Area 7 Map 89 Submap 11 at (2,8); Close Dialogue Sub-Window (2); Open Dialogue Message Window; Set Special Scene BGM (73); Show Dialogue Portrait (24, 8, 0); Full Rest & Healing (Restore HP/MP); Set Combat Battle BGM (15); Close Dialogue Sub-Window (1); Open Dialogue Message Window; Full Rest & Healing (Restore HP/MP); Set Combat Battle BGM (15); Engine Action #89; Close Dialogue Window; Warp Town -> Area 9 Map 24 Submap 2 at (0,77); Engine Action #89; Close Dialogue Window; Engine Action #5; Engine Action #89; Close Dialogue Window; Engine Action #5; Engine Action #89; Close Dialogue Window; Warp Town -> Area 11 Map 73 Submap 15 at (24,1); Open Dialogue Message Window; Engine Action #78; Set Combat Battle BGM (15); Close Dialogue Sub-Window (2); Open Dialogue Message Window; Bytecode Subroutine Return; Engine Action #89; Close Dialogue Window; Warp Town -> Area 12 Map 73 Submap 15 at (89,11); Engine Action #5; Engine Action #89; Close Dialogue Window; Engine Action #5; Make obj[3] Hidden (disp = 0); Warp Town -> Area 3 Map 0 Submap 2 at (1,11); Teleport obj[24] to (1,0); Engine Action #80; Set Combat Battle BGM (15); Close Dialogue Sub-Window (8); Open Dialogue Message Window; Engine Action #81; Set Combat Battle BGM (15); Engine Action #89; Engine Action #9; Warp Town -> Area 13 Map 5 Submap 1 at (4,2); Warp Room -> Submap 5 at (15,30) facing 46; Warp Town -> Area 12 Map 38 Submap 32 at (89,12); Warp Town -> Area 21 Map 0 Submap 12 at (1,1); Teleport obj[89] to (12,5); Engine Action #89; Display Dialogue Box [Bank: 5, MsgID: 24]; Warp Room -> Submap 82 at (73,15) facing 24; Warp Room -> Submap 83 at (11,2) facing Up (North); Engine Action #150; Wait for Audio / Window Sync (3); Engine Action #9; Return Warp to Castle Base (1, 31); Open Dialogue Message Window; Reset Camera Tracking (12); Engine Action #102; Warp Room -> Submap 3 at (0,33) facing 77 |

---


