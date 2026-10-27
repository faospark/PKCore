# Suikoden II Geographic Area Catalog: Cave of the Wind Caverns

**Geographic Scope & Role**: Subterranean howling caverns; wind-blower puzzle machinery, narrow cliff bridges, and the Star Dragon Sword sacred sanctuary chamber.

**Regional Category**: Region `VD` | **Master Maps Included**: `vd06`, `vd13`

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

## Location Map: `vd06`

- **Master Map Container**: `vd06.json`
- **Submap Layer Files**: vd06_00.json, vd06_01.json, vd06_04.json
- **Collision Grid Files**: vd06_map_00.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 19

### Submap Layer `vd06_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `4` Objects | **Script Count (`evkaz`)**: `15` Scripts

#### Complete Physical Entity Inventory (4 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 65152** | `65152` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(25, 18)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | World Device | **Mechanism (ano 35)** | `0` | `(16, 16)` | `0x0` | Frame 35 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | World Device | **Mechanism (ano 36)** | `0` | `(9, 24)` | `0x0` | Frame 36 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 480 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 65152)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(25, 18)` to `(27, 20)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[02]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(16, 16)` with state parameter `35`.
- **`obj[03]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(9, 24)` with state parameter `36`.


#### Complete Bytecode Script Catalog (15 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 85 (bit 1) CLEAR | Make obj[0] Hidden (disp = 0); Screen Fade Transition (36, 32, 36); Animate Doorway State (47, 255) |
| `ev[01]` | `2 (Map Init)` | Story Flag 85 (bit 1) SET | Make obj[0] Hidden (disp = 0); Close Dialogue Window; Launch Tactical War Battle (32); Launch Tactical War Battle (64); Teleport obj[255] to (254,204) |
| `ev[02]` | `128 (Loop)` | Inventory Holds Item #64 [Recipe #33] | Jump to Bytecode Offset (9, 9); Engine Action #117; Open Dialogue Message Window; Open Dialogue Message Window; Jump to Bytecode Offset (1, 1); Toggle Random Encounters (64) |
| `ev[03]` | `1 (Action / Talk)` | Story Flag 86 (bit 8) SET AND Story Flag 85 (bit 1) CLEAR AND Player within Box [10..30, 2..30] AND Condition Check #40 | Set Render Priority (pri) (0, 20); Clear Dialogue Sub-Window; Reset Camera Tracking (3); Open Dialogue Message Window; Warp Room -> Submap 3 at (3,35) facing 19; Make obj[0] Hidden (disp = 0); Warp Room -> Submap 2 at (0,3) facing South (Down); Exit to World Map (0, 6, 0); Engine Action #5; Teleport obj[49] to (6,5); Warp Room -> Submap 5 at (3,2) facing West (Left); Exit to World Map (30, 255, 254); Engine Action #5; Warp Town -> Area 4 Map 5 Submap 3 at (3,1); Warp Room -> Submap 255 at (254,5) facing East (Right); Exit to World Map (5, 2, 3); Warp Room -> Submap 30 at (255,254) facing 5; Exit to World Map (4, 5, 2); Warp to Castle HQ (1, 0, 30); Engine Action #5; Engine Action #6; Exit to World Map (5, 0, 3); Warp to Castle HQ (1, 1, 0); Dismiss Emotion Bubble (255); Engine Action #5; Engine Action #5; Exit to World Map (5, 0, 3); Warp Town -> Area 2 Map 1 Submap 0 at (30,255); Walk obj[24] to (1,0); Open Dialogue Message Window; Engine Action #5; Warp Town -> Area 4 Map 4 Submap 1 at (1,30); Close Dialogue Window; Warp Town -> Area 2 Map 40 Submap 73 at (45,101); Exit to World Map (17, 73, 5); Jump to Bytecode Offset (4, 23); Set Combat Battle BGM (10); Jump to Bytecode Offset (4, 18); Set Combat Battle BGM (7); Jump to Bytecode Offset (4, 23); Set Combat Battle BGM (5); Jump to Bytecode Offset (4, 24); Set Combat Battle BGM (5); Jump to Bytecode Offset (4, 33); Set Combat Battle BGM (5); Jump to Bytecode Offset (4, 66); Set Combat Battle BGM (30); Jump to Bytecode Offset (6, 66); Set Combat Battle BGM (45); Warp Room -> Submap 0 at (11,11) facing West (Left); Warp Town -> Area 40 Map 24 Submap 2 at (0,1); Warp to Castle HQ (1, 0, 72); Warp Room -> Submap 4 at (24,1) facing South (Down); Warp Town -> Area 72 Map 0 Submap 1 at (3,3); Warp to Castle HQ (24, 3, 0); Warp to Castle HQ (39, 34, 9); Engine Action #85; Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[04]` | `1 (Action / Talk)` | Story Flag 66 (bit 64) SET AND Story Flag 146 (bit 8) CLEAR AND Star of Destiny #1 Recruited AND Temp Event Flag #1 SET AND Story Flag 30 (mask 2) CLEAR AND Condition Check #30 AND Condition Check #40 | Set Render Priority (pri) (0, 20); Clear Dialogue Sub-Window; Reset Camera Tracking (3); Open Dialogue Message Window; Warp Room -> Submap 1 at (7,46) facing South (Down); Warp Room -> Submap 8 at (20,13) facing East (Right); Reset Camera Tracking (1); Open Dialogue Message Window; Reset Camera Tracking (47); Engine Action #5; Warp Room -> Submap 5 at (3,3) facing West (Left); Open Dialogue Message Window; Dismiss Emotion Bubble (5); Reset Camera Tracking (4); Warp to Castle HQ (7, 5, 0); Open Dialogue Message Window; Dismiss Emotion Bubble (72); Warp Room -> Submap 2 at (5,8) facing 4; Exit to World Map (6, 2, 30); Load Sound Bank into Memory (0, 8); Launch Tactical War Battle (1); Set Combat Battle BGM (150); Warp to Castle HQ (0, 2, 3); Warp Room -> Submap 73 at (120,3) facing South (Down); Open Dialogue Message Window; Warp to Castle HQ (1, 0, 54); Open Dialogue Message Window; Warp Room -> Submap 120 at (3,0) facing East (Right); Warp to Castle HQ (1, 2, 72); Warp Room -> Submap 3 at (72,1) facing West (Left); Warp to Castle HQ (73, 60, 72); Open Dialogue Message Window; Open Dialogue Message Window; Load Sound Bank into Memory (0, 1); Turn obj[1] facing South (Down); Warp Town -> Area 0 Map 1 Submap 0 at (9,1); Warp Room -> Submap 9 at (146,8) facing 255 |
| `ev[05]` | `128 (Loop)` | Story Flag 66 (bit 64) SET AND Story Flag 146 (bit 8) CLEAR AND Star of Destiny #1 Recruited AND Temp Event Flag #6 SET AND Player X within Range [255..254] | Set Combat Battle BGM (30); Open Shop Menu #3 (Type: 8); Load Sound Bank into Memory (1, 8); Exit to World Map (4, 8, 15); Branch on Choice (9, 5); Reset Camera Tracking (0); Pan Camera (30, 72, 0); Reset Camera Tracking (72); Warp Room -> Submap 9 at (5,8) facing 4; Engine Action #6; Open Dialogue Message Window; Place Scenery Structure (30); Load Sound Bank into Memory (0, 8); Warp Room -> Submap 37 at (1,255) facing 254 |
| `ev[06]` | `128 (Loop)` | Player within Box [1..38, 2..5] AND Condition Check #37 AND Condition Check #30 AND Always Passes (Unconditional) AND Player Y within Range [255..254] | Warp Room -> Submap 2 at (12,3) |
| `ev[07]` | `1 (Action / Talk)` | Player within Box [17..23, 2..13] AND Active Party Has Character #9 AND Player X within Range [255..254] | Jump to Bytecode Offset (9, 9); Close Dialogue Window; Warp Town -> Area 2 Map 40 Submap 73 at (30,101); Warp Room -> Submap 12 at (1,40) facing 115 |
| `ev[08]` | `2 (Map Init)` | Player within Box [20..20, 2..16] AND Star of Destiny #9 Recruited AND Always Passes (Unconditional) | Close Dialogue Window; Warp Room -> Submap 40 at (255,254) facing 204 |
| `ev[09]` | `1 (Action / Talk)` | Player within Box [1..49, 2..36] AND Condition Check #37 AND Story Flag 0 (mask 255) SET | Jump to Bytecode Offset (9, 9); Warp Map Transition (0, 0, 117, 98, 255) |
| `ev[10]` | `1 (Action / Talk)` | Player within Box [1..2, 2..22] AND Condition Check #37 AND Story Flag 2 (mask 255) SET | Jump to Bytecode Offset (9, 9); Warp Map Transition (0, 0, 117, 98, 255) |
| `ev[11]` | `1 (Action / Talk)` | Player within Box [48..49, 2..13] AND Condition Check #37 AND Story Flag 3 (mask 255) SET | Engine Action #117; Open Dialogue Message Window; Open Dialogue Message Window; Warp Map Transition (0, 0, 117, 98, 255) |
| `ev[12]` | `2 (Map Init)` | Always Passes (Unconditional) | Make obj[86] Hidden (disp = 0); Warp to Castle HQ (5, 0, 20); Open Dialogue Sub-Window (47) |
| `ev[13]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Engine Action #99; Open Dialogue Message Window; Warp Town -> Area 99 Map 0 Submap 1 at (26,4); Exit to World Map (73, 20, 40); Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 4 Map 2 Submap 4 at (3,73); Branch on Choice (41, 2); Open Dialogue Message Window; Warp Room -> Submap 0 at (127,0) facing South (Down); Warp Room -> Submap 1 at (1,100) facing South (Down); Warp Town -> Area 255 Map 254 Submap 255 at (1,100); Open Dialogue Message Window; Warp Town -> Area 255 Map 254 Submap 255 at (254,204) |
| `ev[14]` | `128 (Loop)` | Condition Check #29 AND Always Passes (Unconditional) AND Player X within Range [255..254] | Warp Room -> Submap 1 at (13,45); Mark NPC Talk Interaction Complete (Flag #0); Warp Room -> Submap 254 at (204,204) facing 204 |

---

### Submap Layer `vd06_01` (Index 1)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `80`, Rate: `5`)
- **Entity Count (`okaz`)**: `1` Objects | **Script Count (`evkaz`)**: `6` Scripts

#### Complete Physical Entity Inventory (1 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 33)** | `0` | `(38, 87)` | `0x0` | Frame 33 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(38, 87)` with state parameter `33`.


#### Complete Bytecode Script Catalog (6 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 146 (bit 8) SET AND Story Flag 146 (bit 16) CLEAR AND Star of Destiny #1 Recruited AND Temp Event Flag #255 SET | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[01]` | `1 (Action / Talk)` | Story Flag 146 (bit 8) SET AND Story Flag 146 (bit 16) CLEAR AND Star of Destiny #1 Recruited AND Temp Event Flag #1 SET AND Condition Check #30 AND Condition Check #46 AND Player Y within Range [97..99] | Set Render Priority (pri) (0, 39); Engine Action #93; Reset Camera Tracking (3); Open Dialogue Message Window; Warp Room -> Submap 1 at (7,46) facing South (Down); Warp Room -> Submap 5 at (1,4) facing 5; Warp to Castle HQ (3, 1, 2); Dismiss Emotion Bubble (72); Warp Room -> Submap 2 at (73,60) facing 72; Open Dialogue Message Window; Warp Room -> Submap 1 at (0,24) facing West (Left); Warp Town -> Area 0 Map 73 Submap 20 at (40,0); Open Dialogue Message Window; Warp Town -> Area 2 Map 1 Submap 2 at (2,4); Warp Room -> Submap 89 at (9,3) facing West (Left); Warp Room -> Submap 60 at (1,8) facing East (Right); Warp Room -> Submap 24 at (1,2) facing East (Right); Turn obj[1] facing South (Down); Warp Town -> Area 0 Map 1 Submap 0 at (9,1); Warp Room -> Submap 9 at (66,128) facing 9; Engine Action #146; Dismiss Dialogue Portrait |
| `ev[02]` | `2 (Map Init)` | Always Passes (Unconditional) | Make obj[86] Hidden (disp = 0); Warp to Castle HQ (5, 0, 20); Open Dialogue Sub-Window (47) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [35..45, 2..117] AND Condition Check #118 AND Story Flag 0 (mask 255) SET | Jump to Bytecode Offset (9, 9); Close Dialogue Window; Warp Town -> Area 2 Map 40 Submap 73 at (30,12); Open Dialogue Message Window; Branch on Choice (16, 255) |
| `ev[04]` | `2 (Map Init)` | Player within Box [40..40, 2..115] AND Condition Check #115 AND Story Flag 1 (mask 255) SET | Close Dialogue Window; Warp Room -> Submap 40 at (255,254) facing 204 |
| `ev[05]` | `1 (Action / Talk)` | Player within Box [142..143, 2..27] AND Condition Check #37 | Display Dialogue Box [Bank: 2, MsgID: 27]; Engine Action #87 |

---

### Submap Layer `vd06_02` (Index 2)

- **Map Number (`mapno`)**: `2`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `80`, Rate: `5`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `2` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (2 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [25..26, 2..85] AND Condition Check #92 | Display Dialogue Box [Bank: 1, MsgID: 141]; Warp Room -> Submap 255 at (254,204) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [137..143, 2..18] AND Character #9 Level >= 1 | Display Dialogue Box [Bank: 3, MsgID: 30]; Engine Action #134 |

---

### Submap Layer `vd06_03` (Index 3)

- **Map Number (`mapno`)**: `3`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `80`, Rate: `5`)
- **Entity Count (`okaz`)**: `2` Objects | **Script Count (`evkaz`)**: `10` Scripts

#### Complete Physical Entity Inventory (2 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 8)** | `0` | `(102, 50)` | `0x0` | Frame 8 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 7)** | `0` | `(102, 50)` | `0x0` | Frame 7 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(102, 50)` with state parameter `8`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(102, 50)` with state parameter `7`.


#### Complete Bytecode Script Catalog (10 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Treasure Byte 12 Bit 1 FRESH (Unopened) | Make obj[0] Hidden (disp = 0); Reset Camera Tracking (47) |
| `ev[01]` | `2 (Map Init)` | Treasure Byte 12 Bit 1 LOOTED | Make obj[0] Hidden (disp = 0); Engine Action #9; Teleport obj[255] to (254,204) |
| `ev[02]` | `1 (Action / Talk)` | Treasure Byte 12 Bit 1 FRESH (Unopened) AND Target Inspected is obj[8] | Make obj[1] Hidden (disp = 0); Reset Camera Tracking (0); Engine Action #9; Teleport obj[101] to (4,7); Dismiss Emotion Bubble (2); Exit to World Map (0, 73, 16); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,12) facing West (Left); Warp Room -> Submap 0 at (8,1) facing 9; Teleport obj[255] to (254,255) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [25..35, 2..135] AND Condition Check #136 | Display Dialogue Box [Bank: 2, MsgID: 140]; Execute Choice Result (255) |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [129..130, 2..93] AND Condition Check #100 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 4, MsgID: 25]; Set Combat Battle BGM (255) |
| `ev[05]` | `1 (Action / Talk)` | Player within Box [130..131, 2..69] AND Condition Check #76 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 4, MsgID: 25]; Walk obj[255] to (254,204) |
| `ev[06]` | `1 (Action / Talk)` | Player within Box [130..131, 2..46] AND Condition Check #53 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 4, MsgID: 40]; Clear Dialogue Sub-Window |
| `ev[07]` | `1 (Action / Talk)` | Player within Box [21..22, 2..44] AND Condition Check #52 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 5, MsgID: 119]; Play CD / Ambient BGM Track (255) |
| `ev[08]` | `1 (Action / Talk)` | Player within Box [21..22, 2..69] AND Condition Check #76 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 5, MsgID: 119]; Make Object Hidden (disp = 0) (255) |
| `ev[09]` | `1 (Action / Talk)` | Player within Box [99..105, 2..19] AND Castle HQ Tier >= Level 9 AND Player X within Range [255..254] | Display Dialogue Box [Bank: 6, MsgID: 68]; Show Character Dialogue Portrait (255, 254, 204) |

---

### Submap Layer `vd06_04` (Index 4)

- **Map Number (`mapno`)**: `4`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `80`, Rate: `5`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `3` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (3 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [22..24, 2..71] AND Condition Check #79 | Display Dialogue Box [Bank: 3, MsgID: 129]; Clear Story Milestone Flag 255 (mask 254) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [22..24, 2..47] AND Condition Check #54 | Display Dialogue Box [Bank: 3, MsgID: 129]; Remove Character from Active Party (255) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [35..37, 2..22] AND Condition Check #29 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 3, MsgID: 129]; Teleport obj[255] to (254,204) |

---

### Submap Layer `vd06_05` (Index 5)

- **Map Number (`mapno`)**: `5`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `80`, Rate: `5`)
- **Entity Count (`okaz`)**: `2` Objects | **Script Count (`evkaz`)**: `5` Scripts

#### Complete Physical Entity Inventory (2 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 8)** | `0` | `(34, 36)` | `0x0` | Frame 8 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 7)** | `0` | `(34, 36)` | `0x0` | Frame 7 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(34, 36)` with state parameter `8`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(34, 36)` with state parameter `7`.


#### Complete Bytecode Script Catalog (5 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Treasure Byte 12 Bit 2 FRESH (Unopened) | Make obj[0] Hidden (disp = 0); Reset Camera Tracking (47) |
| `ev[01]` | `2 (Map Init)` | Treasure Byte 12 Bit 2 LOOTED | Make obj[0] Hidden (disp = 0); Engine Action #9; Teleport obj[255] to (254,204) |
| `ev[02]` | `1 (Action / Talk)` | Treasure Byte 12 Bit 2 FRESH (Unopened) AND Target Inspected is obj[8] | Make obj[1] Hidden (disp = 0); Reset Camera Tracking (0); Engine Action #9; Teleport obj[101] to (4,7); Dismiss Emotion Bubble (2); Exit to World Map (0, 74, 16); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,12) facing Up (North); Warp Room -> Submap 0 at (8,1) facing 9; Teleport obj[255] to (254,255) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [120..121, 2..65] AND Condition Check #72 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 3, MsgID: 23]; Teleport obj[255] to (254,204) |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [120..121, 2..89] AND Condition Check #96 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 3, MsgID: 23]; Load Sound Bank into Memory (255, 254) |

---

### Submap Layer `vd06_06` (Index 6)

- **Map Number (`mapno`)**: `6`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `80`, Rate: `5`)
- **Entity Count (`okaz`)**: `3` Objects | **Script Count (`evkaz`)**: `5` Scripts

#### Complete Physical Entity Inventory (3 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 6)** | `0` | `(20, 24)` | `0x0` | Frame 6 | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 8)** | `0` | `(48, 95)` | `0x0` | Frame 8 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | World Device | **Mechanism (ano 7)** | `0` | `(48, 95)` | `0x0` | Frame 7 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(20, 24)` with state parameter `6`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(48, 95)` with state parameter `8`.
- **`obj[02]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(48, 95)` with state parameter `7`.


#### Complete Bytecode Script Catalog (5 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Treasure Byte 12 Bit 4 FRESH (Unopened) | Make obj[0] Hidden (disp = 0); Engine Action #9; Teleport obj[255] to (254,204) |
| `ev[01]` | `2 (Map Init)` | Treasure Byte 12 Bit 4 LOOTED | Make obj[0] Hidden (disp = 0); Screen Fade Transition (47, 255, 254) |
| `ev[02]` | `1 (Action / Talk)` | Treasure Byte 12 Bit 4 FRESH (Unopened) AND Target Inspected is obj[9] | Make obj[1] Hidden (disp = 0); Engine Action #9; Open Dialogue Message Window; Screen Fade Transition (47, 101, 4); Pan Camera (30, 2, 4); Open Dialogue Message Window; Reset Camera Tracking (0); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,12) facing 4; Warp Room -> Submap 0 at (9,1) facing 10; Teleport obj[255] to (254,255) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [65..71, 2..126] AND Condition Check #128 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 3, MsgID: 102]; Open Dialogue Sub-Window (255) |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [153..159, 2..24] AND Condition Check #25 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 7, MsgID: 56]; Engine Action #88 |

---

### Submap Layer `vd06_07` (Index 7)

- **Map Number (`mapno`)**: `7`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `80`, Rate: `5`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `2` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (2 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [53..59, 2..90] AND Condition Check #92 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 6, MsgID: 156]; Display Chapter Text (255) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [26..27, 2..22] AND Condition Check #30 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 8, MsgID: 37]; Clear Dialogue Sub-Window |

---

### Submap Layer `vd06_08` (Index 8)

- **Map Number (`mapno`)**: `8`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `80`, Rate: `5`)
- **Entity Count (`okaz`)**: `7` Objects | **Script Count (`evkaz`)**: `5` Scripts

#### Complete Physical Entity Inventory (7 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 6)** | `0` | `(20, 23)` | `0x0` | Frame 6 | Visible (1) | Solid (Obstacle) | 4 | 100 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 6)** | `0` | `(22, 25)` | `0x0` | Frame 6 | Visible (1) | Solid (Obstacle) | 4 | 100 | 0 |
| `obj[02]` | World Device | **Mechanism (ano 6)** | `0` | `(18, 27)` | `0x0` | Frame 6 | Visible (1) | Solid (Obstacle) | 4 | 100 | 0 |
| `obj[03]` | World Device | **Mechanism (ano 6)** | `0` | `(23, 29)` | `0x0` | Frame 6 | Visible (1) | Solid (Obstacle) | 4 | 100 | 0 |
| `obj[04]` | World Device | **Mechanism (ano 6)** | `0` | `(20, 31)` | `0x0` | Frame 6 | Visible (1) | Solid (Obstacle) | 4 | 100 | 0 |
| `obj[05]` | World Device | **Mechanism (ano 6)** | `0` | `(22, 33)` | `0x0` | Frame 6 | Visible (1) | Solid (Obstacle) | 4 | 100 | 0 |
| `obj[06]` | World Device | **Mechanism (ano 6)** | `0` | `(18, 34)` | `0x0` | Frame 6 | Visible (1) | Solid (Obstacle) | 4 | 100 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(20, 23)` with state parameter `6`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(22, 25)` with state parameter `6`.
- **`obj[02]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(18, 27)` with state parameter `6`.
- **`obj[03]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(23, 29)` with state parameter `6`.
- **`obj[04]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(20, 31)` with state parameter `6`.
- **`obj[05]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(22, 33)` with state parameter `6`.
- **`obj[06]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(18, 34)` with state parameter `6`.


#### Complete Bytecode Script Catalog (5 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Always Passes (Unconditional) | Dismiss Emotion Bubble (5); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [38..40, 2..20] AND Condition Check #31 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 7, MsgID: 28]; Fade In from Black (255) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [0..1, 2..24] AND Condition Check #31 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 9, MsgID: 37]; Fade In from Black (255) |
| `ev[03]` | `128 (Loop)` | Condition Check #41 AND Story Flag 35 (mask 15) CLEAR AND Condition Check #40 AND Condition Check #60 AND Player X within Range [255..254] | Recruit Character into Active Party (26 [Shiro], 6); Open Dialogue Message Window; Set Combat Battle BGM (20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 4 Map 2 Submap 4 at (3,73); Branch on Choice (41, 2); Open Dialogue Message Window; Warp Room -> Submap 0 at (58,137) facing 12; Reset Camera Tracking (37); Clear Dialogue Sub-Window; Warp Room (Submap); Engine Action #58; Engine Action #137 |
| `ev[04]` | `2 (Map Init)` | Player within Box [36..38, 2..24] AND Condition Check #26 | Warp to Castle HQ (0, 2, 255) |

---

### Submap Layer `vd06_09` (Index 9)

- **Map Number (`mapno`)**: `9`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `9` Objects | **Script Count (`evkaz`)**: `26` Scripts

#### Complete Physical Entity Inventory (9 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Kahn Marley** | `36` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 6)** | `0` | `(21, 24)` | `0x0` | Frame 6 | Visible (1) | Solid (Obstacle) | 4 | 100 | 0 |
| `obj[02]` | World Device | **Mechanism (ano 37)** | `0` | `(16, 8)` | `0x0` | Frame 37 | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | World Device | **Mechanism (ano 38)** | `0` | `(17, 15)` | `0x0` | Frame 38 | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | World Device | **Mechanism (ano 37)** | `0` | `(15, 20)` | `0x0` | Frame 37 | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | World Device | **Mechanism (ano 38)** | `0` | `(16, 25)` | `0x0` | Frame 38 | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | World Device | **Mechanism (ano 38)** | `0` | `(33, 33)` | `0x0` | Frame 38 | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | World Device | **Mechanism (ano 37)** | `0` | `(34, 34)` | `0x0` | Frame 37 | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | World Device | **Mechanism (ano 38)** | `0` | `(35, 35)` | `0x0` | Frame 38 | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Kahn Marley)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(21, 24)` with state parameter `6`.
- **`obj[02]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(16, 8)` with state parameter `37`.
- **`obj[03]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(17, 15)` with state parameter `38`.
- **`obj[04]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(15, 20)` with state parameter `37`.
- **`obj[05]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(16, 25)` with state parameter `38`.
- **`obj[06]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(33, 33)` with state parameter `38`.
- **`obj[07]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(34, 34)` with state parameter `37`.
- **`obj[08]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(35, 35)` with state parameter `38`.


#### Complete Bytecode Script Catalog (26 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Always Passes (Unconditional) | Dismiss Emotion Bubble (5); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[01]` | `2 (Map Init)` | Always Passes (Unconditional) | Make obj[104] Hidden (disp = 0); Open Dialogue Message Window; Screen Fade Transition (1, 104, 0); Close Dialogue Window; Warp Room -> Submap 0 at (12,1) facing 104; Open Dialogue Message Window; Place Scenery Structure (1); Engine Action #104; Open Dialogue Message Window; Animate Door Open; Warp Room -> Submap 0 at (15,1) facing 104; Open Dialogue Message Window; Dismiss Dialogue Portrait; Warp Room -> Submap 1 at (1,100) facing West (Left); Warp Town -> Area 100 Map 1 Submap 4 at (100,1); Reset Camera Tracking (100); Warp Room -> Submap 100 at (1,32) facing 100; Warp Room -> Submap 47 at (255,254) facing 204 |
| `ev[02]` | `128 (Loop)` | Always Passes (Unconditional) | Engine Action #99; Warp Room -> Submap 90 at (10,4) facing 6; Dismiss Dialogue Portrait; Start Boss Battle #30 (BGM: 127); Open Dialogue Message Window; Warp Room -> Submap 2 at (10,16) facing 8; Engine Action #94; Warp Town -> Area 1 Map 10 Submap 10 at (255,254) |
| `ev[03]` | `128 (Loop)` | Condition Check #29 AND Player X within Range [1..255] | Mark NPC Talk Interaction Complete (Flag #1); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[04]` | `128 (Loop)` | Always Passes (Unconditional) | Engine Action #99; Warp Room -> Submap 90 at (11,4) facing 7; Dismiss Dialogue Portrait; Toggle Random Encounters (30); Engine Action #127; Open Dialogue Message Window; Warp Room -> Submap 2 at (11,17) facing 9; Engine Action #94; Warp Town -> Area 1 Map 11 Submap 10 at (255,254) |
| `ev[05]` | `128 (Loop)` | Condition Check #29 AND Player X within Range [2..255] | Mark NPC Talk Interaction Complete (Flag #1); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[06]` | `128 (Loop)` | Always Passes (Unconditional) | Engine Action #99; Warp Room -> Submap 90 at (12,4) facing 6; Dismiss Dialogue Portrait; Engine Action #39; Dismiss Emotion Bubble (127); Open Dialogue Message Window; Warp Room -> Submap 2 at (12,15) facing 5; Engine Action #94; Warp Town -> Area 1 Map 12 Submap 10 at (255,254) |
| `ev[07]` | `128 (Loop)` | Condition Check #29 AND Player X within Range [4..255] | Mark NPC Talk Interaction Complete (Flag #1); Exit to World Map (255, 254, 204) |
| `ev[08]` | `128 (Loop)` | Always Passes (Unconditional) | Engine Action #99; Warp Room -> Submap 90 at (13,4) facing 5; Dismiss Dialogue Portrait; Remove Item from Inventory (30, 127); Open Dialogue Message Window; Warp Room -> Submap 2 at (13,16) facing 6; Engine Action #94; Warp Town -> Area 1 Map 13 Submap 10 at (255,254) |
| `ev[09]` | `128 (Loop)` | Condition Check #29 AND Player X within Range [8..255] | Mark NPC Talk Interaction Complete (Flag #1); Reset Camera Tracking (255) |
| `ev[10]` | `128 (Loop)` | Always Passes (Unconditional) | Engine Action #99; Warp Room -> Submap 90 at (14,4) facing 5; Change Portrait Expression (22); Dismiss Emotion Bubble (127); Open Dialogue Message Window; Warp Room -> Submap 2 at (14,32) facing 40; Engine Action #94; Warp Town -> Area 1 Map 14 Submap 10 at (255,254) |
| `ev[11]` | `128 (Loop)` | Condition Check #29 AND Player X within Range [16..255] | Mark NPC Talk Interaction Complete (Flag #1); Dismiss Dialogue Portrait |
| `ev[12]` | `128 (Loop)` | Always Passes (Unconditional) | Engine Action #99; Warp Room -> Submap 90 at (15,4) facing 6; Change Portrait Expression (30); Dismiss Emotion Bubble (127); Open Dialogue Message Window; Warp Room -> Submap 2 at (15,30) facing 44; Engine Action #94; Warp Town -> Area 1 Map 15 Submap 10 at (255,254) |
| `ev[13]` | `128 (Loop)` | Condition Check #29 AND Player X within Range [32..255] | Mark NPC Talk Interaction Complete (Flag #1); Warp Map Transition (255, 254, 204, 204, 204) |
| `ev[14]` | `128 (Loop)` | Always Passes (Unconditional) | Engine Action #99; Warp Room -> Submap 90 at (16,4) facing 7; Change Portrait Expression (35); Dismiss Emotion Bubble (127); Open Dialogue Message Window; Warp Room -> Submap 2 at (16,33) facing 45; Engine Action #94; Warp Town -> Area 1 Map 16 Submap 10 at (255,254) |
| `ev[15]` | `128 (Loop)` | Condition Check #29 AND Player X within Range [64..255] | Mark NPC Talk Interaction Complete (Flag #1); Animate Doorway State (255, 254) |
| `ev[16]` | `2 (Map Init)` | Always Passes (Unconditional) | Make obj[10] Hidden (disp = 0); Engine Action #146; Warp Town -> Area 10 Map 146 Submap 4 at (47,255) |
| `ev[17]` | `128 (Loop)` | Story Flag 146 (bit 4) CLEAR | Dismiss Emotion Bubble (3); Exit to World Map (17, 16, 1); Engine Action #9 |
| `ev[18]` | `1 (Action / Talk)` | Story Flag 146 (bit 2) SET AND Story Flag 146 (bit 4) CLEAR | Engine Action #111 |
| `ev[19]` | `128 (Loop)` | Player within Box [12..24, 2..54] AND Condition Check #55 | Engine Action #9; Engine Action #146; Exit to World Map (255, 254, 204) |
| `ev[20]` | `1 (Action / Talk)` | Player within Box [12..24, 2..54] AND Condition Check #55 | Engine Action #5; Open Dialogue Message Window; Exit to World Map (5, 0, 3); Dismiss Emotion Bubble (72); Warp Room -> Submap 2 at (73,30) facing 44; Display Dialogue with Speaker Name (1, 0, 101); Engine Action #5; Engine Action #181; Jump to Bytecode Offset (0, 182); Engine Action #5; Open Dialogue Message Window; Exit to World Map (7, 0, 15); Dismiss Emotion Bubble (72); Open Dialogue Message Window; Open Dialogue Message Window; Display Dialogue Box [Bank: 9, MsgID: 34]; Warp Map Transition (255, 254, 204, 204, 204) |
| `ev[21]` | `1 (Action / Talk)` | Player within Box [33..35, 2..35] AND Condition Check #36 | Fade In from Black (1); Warp Town -> Area 3 Map 0 Submap 0 at (5,0); Exit to World Map (5, 7, 3); Dismiss Emotion Bubble (255) |
| `ev[22]` | `1 (Action / Talk)` | Player within Box [38..40, 2..21] AND Condition Check #30 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 8, MsgID: 2]; Fade In from Black (255) |
| `ev[23]` | `1 (Action / Talk)` | Player within Box [1..2, 2..21] AND Condition Check #30 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 10, MsgID: 39]; Display Chapter Text (255) |
| `ev[24]` | `128 (Loop)` | Condition Check #41 AND Active Party Has Character #22 AND Party Member Count == 36 AND Condition Check #60 AND Player X within Range [255..254] | Recruit Character into Active Party (26 [Shiro], 6); Open Dialogue Message Window; Set Combat Battle BGM (20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 4 Map 2 Submap 4 at (3,73); Branch on Choice (41, 2); Open Dialogue Message Window; Warp Room -> Submap 0 at (58,137) facing 12; Engine Action #9; Toggle Random Encounters (26); Warp Room (Submap); Engine Action #58; Engine Action #137 |
| `ev[25]` | `2 (Map Init)` | Player within Box [36..38, 2..25] AND Treasure Byte 255 Bit 254 LOOTED | Warp to Castle HQ (0, 2, 255) |

---

### Submap Layer `vd06_10` (Index 10)

- **Map Number (`mapno`)**: `10`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `13` Objects | **Script Count (`evkaz`)**: `32` Scripts

#### Complete Physical Entity Inventory (13 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Kahn Marley** | `36` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 6)** | `0` | `(26, 24)` | `0x0` | Frame 6 | Visible (1) | Solid (Obstacle) | 4 | 100 | 0 |
| `obj[02]` | World Device | **Mechanism (ano 6)** | `0` | `(26, 31)` | `0x0` | Frame 6 | Visible (1) | Solid (Obstacle) | 4 | 100 | 0 |
| `obj[03]` | World Device | **Mechanism (ano 37)** | `0` | `(16, 8)` | `0x0` | Frame 37 | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | World Device | **Mechanism (ano 38)** | `0` | `(17, 15)` | `0x0` | Frame 38 | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | World Device | **Mechanism (ano 37)** | `0` | `(15, 20)` | `0x0` | Frame 37 | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | World Device | **Mechanism (ano 38)** | `0` | `(16, 25)` | `0x0` | Frame 38 | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | World Device | **Mechanism (ano 38)** | `0` | `(36, 33)` | `0x0` | Frame 38 | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | World Device | **Mechanism (ano 37)** | `0` | `(34, 34)` | `0x0` | Frame 37 | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | World Device | **Mechanism (ano 38)** | `0` | `(37, 35)` | `0x0` | Frame 38 | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | World Device | **Mechanism (ano 38)** | `0` | `(19, 15)` | `0x0` | Frame 38 | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | World Device | **Mechanism (ano 37)** | `0` | `(20, 20)` | `0x0` | Frame 37 | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | World Device | **Mechanism (ano 38)** | `0` | `(22, 25)` | `0x0` | Frame 38 | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Kahn Marley)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(26, 24)` with state parameter `6`.
- **`obj[02]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(26, 31)` with state parameter `6`.
- **`obj[03]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(16, 8)` with state parameter `37`.
- **`obj[04]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(17, 15)` with state parameter `38`.
- **`obj[05]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(15, 20)` with state parameter `37`.
- **`obj[06]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(16, 25)` with state parameter `38`.
- **`obj[07]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(36, 33)` with state parameter `38`.
- **`obj[08]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(34, 34)` with state parameter `37`.
- **`obj[09]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(37, 35)` with state parameter `38`.
- **`obj[10]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(19, 15)` with state parameter `38`.
- **`obj[11]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(20, 20)` with state parameter `37`.
- **`obj[12]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(22, 25)` with state parameter `38`.


#### Complete Bytecode Script Catalog (32 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Always Passes (Unconditional) | Dismiss Emotion Bubble (5); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[01]` | `2 (Map Init)` | Always Passes (Unconditional) | Make obj[104] Hidden (disp = 0); Open Dialogue Message Window; Close Dialogue Window; Warp Room -> Submap 0 at (12,1) facing 104; Open Dialogue Message Window; Place Scenery Structure (1); Engine Action #104; Open Dialogue Message Window; Animate Door Open; Warp Room -> Submap 0 at (15,1) facing 104; Open Dialogue Message Window; Dismiss Dialogue Portrait; Warp Room -> Submap 0 at (17,1) facing 104; Open Dialogue Message Window; Display Speaker Name Box (1); Engine Action #104; Open Dialogue Message Window; Display Choice Selection (1, 104); Open Dialogue Message Window; Branch on Choice (1, 100); Warp Room -> Submap 100 at (1,2) facing 100; Warp Room -> Submap 100 at (1,8) facing 100; Warp Room -> Submap 100 at (1,32) facing 100; Warp Room -> Submap 100 at (2,1) facing 100; Warp Town -> Area 2 Map 100 Submap 2 at (4,47) |
| `ev[02]` | `128 (Loop)` | Always Passes (Unconditional) | Engine Action #99; Warp Room -> Submap 90 at (11,4) facing 6; Dismiss Dialogue Portrait; Start Boss Battle #30 (BGM: 127); Open Dialogue Message Window; Warp Room -> Submap 2 at (11,16) facing 8; Engine Action #94; Warp Town -> Area 1 Map 11 Submap 10 at (255,254) |
| `ev[03]` | `128 (Loop)` | Condition Check #29 AND Player X within Range [1..255] | Mark NPC Talk Interaction Complete (Flag #1); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[04]` | `128 (Loop)` | Always Passes (Unconditional) | Engine Action #99; Warp Room -> Submap 90 at (12,4) facing 7; Dismiss Dialogue Portrait; Toggle Random Encounters (30); Engine Action #127; Open Dialogue Message Window; Warp Room -> Submap 2 at (12,17) facing 9; Engine Action #94; Warp Town -> Area 1 Map 12 Submap 10 at (255,254) |
| `ev[05]` | `128 (Loop)` | Condition Check #29 AND Player X within Range [2..255] | Mark NPC Talk Interaction Complete (Flag #1); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[06]` | `128 (Loop)` | Always Passes (Unconditional) | Engine Action #99; Warp Room -> Submap 90 at (13,4) facing 6; Dismiss Dialogue Portrait; Engine Action #39; Dismiss Emotion Bubble (127); Open Dialogue Message Window; Warp Room -> Submap 2 at (13,15) facing 5; Engine Action #94; Warp Town -> Area 1 Map 13 Submap 10 at (255,254) |
| `ev[07]` | `128 (Loop)` | Condition Check #29 AND Player X within Range [4..255] | Mark NPC Talk Interaction Complete (Flag #1); Exit to World Map (255, 254, 204) |
| `ev[08]` | `128 (Loop)` | Always Passes (Unconditional) | Engine Action #99; Warp Room -> Submap 90 at (14,4) facing 5; Dismiss Dialogue Portrait; Remove Item from Inventory (30, 127); Open Dialogue Message Window; Warp Room -> Submap 2 at (14,16) facing 6; Engine Action #94; Warp Town -> Area 1 Map 14 Submap 10 at (255,254) |
| `ev[09]` | `128 (Loop)` | Condition Check #29 AND Player X within Range [8..255] | Mark NPC Talk Interaction Complete (Flag #1); Reset Camera Tracking (255) |
| `ev[10]` | `128 (Loop)` | Always Passes (Unconditional) | Engine Action #99; Warp Room -> Submap 90 at (15,4) facing 5; Change Portrait Expression (22); Dismiss Emotion Bubble (127); Open Dialogue Message Window; Warp Room -> Submap 2 at (15,36) facing 40; Engine Action #94; Warp Town -> Area 1 Map 15 Submap 10 at (255,254) |
| `ev[11]` | `128 (Loop)` | Condition Check #29 AND Player X within Range [16..255] | Mark NPC Talk Interaction Complete (Flag #1); Dismiss Dialogue Portrait |
| `ev[12]` | `128 (Loop)` | Always Passes (Unconditional) | Engine Action #99; Warp Room -> Submap 90 at (16,4) facing 6; Change Portrait Expression (30); Dismiss Emotion Bubble (127); Open Dialogue Message Window; Warp Room -> Submap 2 at (16,34) facing 44; Engine Action #94; Warp Town -> Area 1 Map 16 Submap 10 at (255,254) |
| `ev[13]` | `128 (Loop)` | Condition Check #29 AND Player X within Range [32..255] | Mark NPC Talk Interaction Complete (Flag #1); Warp Map Transition (255, 254, 204, 204, 204) |
| `ev[14]` | `128 (Loop)` | Always Passes (Unconditional) | Engine Action #99; Warp Room -> Submap 90 at (17,4) facing 7; Change Portrait Expression (35); Dismiss Emotion Bubble (127); Open Dialogue Message Window; Warp Room -> Submap 2 at (17,37) facing 45; Engine Action #94; Warp Town -> Area 1 Map 17 Submap 10 at (255,254) |
| `ev[15]` | `128 (Loop)` | Condition Check #29 AND Player X within Range [64..255] | Mark NPC Talk Interaction Complete (Flag #1); Animate Doorway State (255, 254) |
| `ev[16]` | `128 (Loop)` | Always Passes (Unconditional) | Engine Action #99; Warp Town -> Area 1 Map 90 Submap 18 at (4,6); Dismiss Dialogue Portrait; Make obj[30] Visible (disp = 1); Engine Action #127; Open Dialogue Message Window; Warp Town -> Area 1 Map 2 Submap 18 at (19,8); Engine Action #94; Warp Town -> Area 1 Map 18 Submap 10 at (255,254) |
| `ev[17]` | `128 (Loop)` | Condition Check #29 AND Player Y within Range [1..255] | Mark NPC Talk Interaction Complete (Flag #2); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[18]` | `128 (Loop)` | Always Passes (Unconditional) | Engine Action #99; Warp Town -> Area 2 Map 90 Submap 19 at (4,7); Dismiss Dialogue Portrait; Engine Action #39; Dismiss Emotion Bubble (127); Open Dialogue Message Window; Warp Town -> Area 2 Map 2 Submap 19 at (20,8); Engine Action #94; Warp Town -> Area 1 Map 19 Submap 10 at (255,254) |
| `ev[19]` | `128 (Loop)` | Condition Check #29 AND Player Y within Range [2..255] | Mark NPC Talk Interaction Complete (Flag #2); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[20]` | `128 (Loop)` | Always Passes (Unconditional) | Engine Action #99; Warp Town -> Area 4 Map 90 Submap 20 at (4,6); Dismiss Dialogue Portrait; Make obj[30] Visible (disp = 1); Engine Action #127; Open Dialogue Message Window; Warp Town -> Area 4 Map 2 Submap 20 at (22,5); Engine Action #94; Warp Town -> Area 1 Map 20 Submap 10 at (255,254) |
| `ev[21]` | `128 (Loop)` | Condition Check #29 AND Player Y within Range [4..255] | Mark NPC Talk Interaction Complete (Flag #2); Exit to World Map (255, 254, 204) |
| `ev[22]` | `2 (Map Init)` | Always Passes (Unconditional) | Make obj[10] Hidden (disp = 0); Engine Action #146; Warp Town -> Area 10 Map 146 Submap 4 at (47,255) |
| `ev[23]` | `128 (Loop)` | Story Flag 146 (bit 4) CLEAR | Dismiss Emotion Bubble (3); Engine Action #5; Dismiss Dialogue Portrait; Set Animation Pose (2, 9); Screen Fade Transition (255, 254, 204) |
| `ev[24]` | `1 (Action / Talk)` | Story Flag 146 (bit 2) SET AND Story Flag 146 (bit 4) CLEAR | Engine Action #111 |
| `ev[25]` | `128 (Loop)` | Player within Box [13..27, 2..58] AND Condition Check #59 | Engine Action #9; Engine Action #146; Exit to World Map (255, 254, 204) |
| `ev[26]` | `1 (Action / Talk)` | Player within Box [13..27, 2..58] AND Condition Check #59 | Engine Action #5; Open Dialogue Message Window; Exit to World Map (5, 0, 3); Dismiss Emotion Bubble (72); Warp Room -> Submap 2 at (73,30) facing 44; Display Dialogue with Speaker Name (1, 0, 101); Engine Action #5; Engine Action #181; Jump to Bytecode Offset (0, 182); Engine Action #5; Open Dialogue Message Window; Exit to World Map (7, 0, 15); Dismiss Emotion Bubble (72); Open Dialogue Message Window; Open Dialogue Message Window; Display Dialogue Box [Bank: 10, MsgID: 38]; Launch Tactical War Battle (255) |
| `ev[27]` | `1 (Action / Talk)` | Player within Box [37..39, 2..39] AND Condition Check #40 | Fade In from Black (1); Warp Town -> Area 3 Map 0 Submap 0 at (5,0); Exit to World Map (5, 7, 3); Dismiss Emotion Bubble (255) |
| `ev[28]` | `1 (Action / Talk)` | Player within Box [41..43, 2..20] AND Condition Check #36 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 9, MsgID: 3]; Fade In from Black (255) |
| `ev[29]` | `1 (Action / Talk)` | Player within Box [1..2, 2..20] AND Condition Check #36 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 11, MsgID: 94]; Dismiss Emotion Bubble (255) |
| `ev[30]` | `128 (Loop)` | Condition Check #41 AND Player Y in Range [26..16] AND Condition Check #57 AND Condition Check #60 AND Player X within Range [255..254] | Recruit Character into Active Party (26 [Shiro], 6); Open Dialogue Message Window; Set Combat Battle BGM (20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 4 Map 2 Submap 4 at (3,73); Branch on Choice (41, 2); Open Dialogue Message Window; Warp Room -> Submap 0 at (58,137) facing 12; Screen Fade Transition (39, 28, 255); Warp Room (Submap); Engine Action #58; Engine Action #137 |
| `ev[31]` | `2 (Map Init)` | Player within Box [38..40, 2..27] AND Condition Check #29 | Warp to Castle HQ (0, 2, 255) |

---

### Submap Layer `vd06_11` (Index 11)

- **Map Number (`mapno`)**: `11`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `22` Objects | **Script Count (`evkaz`)**: `43` Scripts

#### Complete Physical Entity Inventory (22 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Kahn Marley** | `36` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 6)** | `0` | `(72, 23)` | `0x0` | Frame 6 | Visible (1) | Solid (Obstacle) | 4 | 100 | 0 |
| `obj[02]` | World Device | **Mechanism (ano 6)** | `0` | `(76, 27)` | `0x0` | Frame 6 | Visible (1) | Solid (Obstacle) | 4 | 100 | 0 |
| `obj[03]` | World Device | **Mechanism (ano 6)** | `0` | `(68, 27)` | `0x0` | Frame 6 | Visible (1) | Solid (Obstacle) | 4 | 100 | 0 |
| `obj[04]` | World Device | **Mechanism (ano 6)** | `0` | `(71, 32)` | `0x0` | Frame 6 | Visible (1) | Solid (Obstacle) | 4 | 100 | 0 |
| `obj[05]` | World Device | **Mechanism (ano 8)** | `0` | `(22, 27)` | `0x0` | Frame 8 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[06]` | World Device | **Mechanism (ano 7)** | `0` | `(22, 27)` | `0x0` | Frame 7 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[07]` | World Device | **Mechanism (ano 8)** | `0` | `(22, 31)` | `0x0` | Frame 8 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[08]` | World Device | **Mechanism (ano 7)** | `0` | `(22, 31)` | `0x0` | Frame 7 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[09]` | World Device | **Mechanism (ano 8)** | `0` | `(27, 29)` | `0x0` | Frame 8 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[10]` | World Device | **Mechanism (ano 7)** | `0` | `(27, 29)` | `0x0` | Frame 7 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[11]` | World Device | **Mechanism (ano 37)** | `0` | `(59, 8)` | `0x0` | Frame 37 | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | World Device | **Mechanism (ano 38)** | `0` | `(62, 15)` | `0x0` | Frame 38 | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | World Device | **Mechanism (ano 37)** | `0` | `(66, 20)` | `0x0` | Frame 37 | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | World Device | **Mechanism (ano 38)** | `0` | `(68, 25)` | `0x0` | Frame 38 | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[15]` | World Device | **Mechanism (ano 38)** | `0` | `(69, 15)` | `0x0` | Frame 38 | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[16]` | World Device | **Mechanism (ano 37)** | `0` | `(72, 20)` | `0x0` | Frame 37 | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[17]` | World Device | **Mechanism (ano 38)** | `0` | `(74, 25)` | `0x0` | Frame 38 | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[18]` | World Device | **Mechanism (ano 38)** | `0` | `(84, 33)` | `0x0` | Frame 38 | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[19]` | World Device | **Mechanism (ano 37)** | `0` | `(82, 34)` | `0x0` | Frame 37 | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[20]` | World Device | **Mechanism (ano 38)** | `0` | `(85, 35)` | `0x0` | Frame 38 | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[21]` | NPC / Actor | **Actor ID 65050** | `65050` | `(26, 22)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Kahn Marley)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(72, 23)` with state parameter `6`.
- **`obj[02]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(76, 27)` with state parameter `6`.
- **`obj[03]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(68, 27)` with state parameter `6`.
- **`obj[04]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(71, 32)` with state parameter `6`.
- **`obj[05]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(22, 27)` with state parameter `8`.
- **`obj[06]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(22, 27)` with state parameter `7`.
- **`obj[07]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(22, 31)` with state parameter `8`.
- **`obj[08]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(22, 31)` with state parameter `7`.
- **`obj[09]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(27, 29)` with state parameter `8`.
- **`obj[10]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(27, 29)` with state parameter `7`.
- **`obj[11]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(59, 8)` with state parameter `37`.
- **`obj[12]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(62, 15)` with state parameter `38`.
- **`obj[13]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(66, 20)` with state parameter `37`.
- **`obj[14]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(68, 25)` with state parameter `38`.
- **`obj[15]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(69, 15)` with state parameter `38`.
- **`obj[16]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(72, 20)` with state parameter `37`.
- **`obj[17]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(74, 25)` with state parameter `38`.
- **`obj[18]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(84, 33)` with state parameter `38`.
- **`obj[19]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(82, 34)` with state parameter `37`.
- **`obj[20]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(85, 35)` with state parameter `38`.
- **`obj[21]` (Object 65050)**: Positioned at tile `(26, 22)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.


#### Complete Bytecode Script Catalog (43 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Always Passes (Unconditional) | Dismiss Emotion Bubble (5); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[01]` | `2 (Map Init)` | Always Passes (Unconditional) | Make obj[10] Hidden (disp = 0); Engine Action #146; Warp Town -> Area 10 Map 146 Submap 4 at (47,255) |
| `ev[02]` | `128 (Loop)` | Story Flag 146 (bit 4) CLEAR | Dismiss Emotion Bubble (3); Pan Camera (60, 112, 4); Engine Action #9; Screen Fade Transition (11, 12, 255) |
| `ev[03]` | `1 (Action / Talk)` | Story Flag 146 (bit 2) SET AND Story Flag 146 (bit 4) CLEAR | Engine Action #111 |
| `ev[04]` | `1 (Action / Talk)` | Story Flag 149 (bit 2) SET | Screen Fade Transition (149, 2, 9); Engine Action #146; Exit to World Map (101, 0, 181); Load Sound Bank into Memory (1, 0); Warp Town -> Area 5 Map 0 Submap 4 at (7,1); Engine Action #40; Dismiss Emotion Bubble (72); Open Dialogue Message Window; Open Dialogue Message Window; Display Dialogue Box [Bank: 11, MsgID: 86]; Launch Tactical War Battle (255) |
| `ev[05]` | `128 (Loop)` | Player within Box [61..75, 2..68] AND Condition Check #69 | Engine Action #9; Engine Action #146; Exit to World Map (255, 254, 204) |
| `ev[06]` | `1 (Action / Talk)` | Player within Box [61..75, 2..68] AND Condition Check #69 | Engine Action #5; Open Dialogue Message Window; Exit to World Map (5, 0, 3); Dismiss Emotion Bubble (72); Warp Room -> Submap 2 at (73,30) facing 44; Display Dialogue with Speaker Name (1, 0, 101); Engine Action #5; Engine Action #181; Jump to Bytecode Offset (0, 182); Engine Action #5; Open Dialogue Message Window; Exit to World Map (7, 0, 17); Dismiss Emotion Bubble (72); Open Dialogue Message Window; Open Dialogue Message Window; Display Dialogue Box [Bank: 11, MsgID: 86]; Launch Tactical War Battle (255) |
| `ev[07]` | `1 (Action / Talk)` | Player within Box [85..87, 2..41] AND Condition Check #43 | Fade In from Black (1); Warp Town -> Area 3 Map 0 Submap 0 at (5,0); Exit to World Map (5, 7, 3); Dismiss Emotion Bubble (255) |
| `ev[08]` | `2 (Map Init)` | Always Passes (Unconditional) | Make obj[104] Hidden (disp = 0); Open Dialogue Message Window; Display Choice Selection (1, 104); Open Dialogue Message Window; Branch on Choice (1, 104); Open Dialogue Message Window; Execute Choice Result (1); Engine Action #104; Open Dialogue Message Window; Set Story Flag (1, 104); Open Dialogue Message Window; Fade In from Black (1); Engine Action #104; Open Dialogue Message Window; Fade Out to Black (1); Engine Action #104; Open Dialogue Message Window; Display Chapter Text (1); Engine Action #104; Open Dialogue Message Window; Open Dialogue Sub-Window (1); Engine Action #104; Open Dialogue Message Window; Close Dialogue Sub-Window (1); Engine Action #104; Open Dialogue Message Window; Clear Dialogue Sub-Window; Warp Room -> Submap 1 at (1,100) facing West (Left); Warp Town -> Area 100 Map 1 Submap 4 at (100,1); Reset Camera Tracking (100); Warp Room -> Submap 100 at (1,32) facing 100; Warp Room -> Submap 100 at (2,1) facing 100; Warp Town -> Area 2 Map 100 Submap 2 at (4,47) |
| `ev[09]` | `128 (Loop)` | Always Passes (Unconditional) | Engine Action #99; Warp Room -> Submap 90 at (19,4) facing 6; Dismiss Dialogue Portrait; Make obj[30] Visible (disp = 1); Engine Action #127; Open Dialogue Message Window; Warp Room -> Submap 2 at (19,59) facing 8; Engine Action #94; Warp Town -> Area 1 Map 19 Submap 10 at (255,254) |
| `ev[10]` | `128 (Loop)` | Condition Check #29 AND Player X within Range [1..255] | Mark NPC Talk Interaction Complete (Flag #1); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[11]` | `128 (Loop)` | Always Passes (Unconditional) | Engine Action #99; Warp Room -> Submap 90 at (20,4) facing 7; Dismiss Dialogue Portrait; Teleport obj[30] to (127,0); Warp Room -> Submap 2 at (20,62) facing 9; Engine Action #94; Warp Town -> Area 1 Map 20 Submap 10 at (255,254) |
| `ev[12]` | `128 (Loop)` | Condition Check #29 AND Player X within Range [2..255] | Mark NPC Talk Interaction Complete (Flag #1); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[13]` | `128 (Loop)` | Always Passes (Unconditional) | Engine Action #99; Warp Room -> Submap 90 at (21,4) facing 6; Dismiss Dialogue Portrait; Set Entity Movement Speed (30, 127); Open Dialogue Message Window; Warp Room -> Submap 2 at (21,66) facing 5; Engine Action #94; Warp Town -> Area 1 Map 21 Submap 10 at (255,254) |
| `ev[14]` | `128 (Loop)` | Condition Check #29 AND Player X within Range [4..255] | Mark NPC Talk Interaction Complete (Flag #1); Exit to World Map (255, 254, 204) |
| `ev[15]` | `128 (Loop)` | Always Passes (Unconditional) | Engine Action #99; Warp Room -> Submap 90 at (22,4) facing 5; Dismiss Dialogue Portrait; Engine Action #52; Dismiss Emotion Bubble (127); Open Dialogue Message Window; Warp Room -> Submap 2 at (22,68) facing 6; Engine Action #94; Warp Town -> Area 1 Map 22 Submap 10 at (255,254) |
| `ev[16]` | `128 (Loop)` | Condition Check #29 AND Player X within Range [8..255] | Mark NPC Talk Interaction Complete (Flag #1); Reset Camera Tracking (255) |
| `ev[17]` | `128 (Loop)` | Always Passes (Unconditional) | Engine Action #99; Warp Town -> Area 1 Map 90 Submap 23 at (4,6); Dismiss Dialogue Portrait; Set Render Priority (pri) (30, 127); Open Dialogue Message Window; Warp Town -> Area 1 Map 2 Submap 23 at (69,8); Engine Action #94; Warp Town -> Area 1 Map 23 Submap 10 at (255,254) |
| `ev[18]` | `128 (Loop)` | Condition Check #29 AND Player Y within Range [1..255] | Mark NPC Talk Interaction Complete (Flag #2); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[19]` | `128 (Loop)` | Always Passes (Unconditional) | Engine Action #99; Warp Town -> Area 2 Map 90 Submap 24 at (4,7); Dismiss Dialogue Portrait; Set Entity Movement Speed (30, 127); Open Dialogue Message Window; Warp Town -> Area 2 Map 2 Submap 24 at (72,8); Engine Action #94; Warp Town -> Area 1 Map 24 Submap 10 at (255,254) |
| `ev[20]` | `128 (Loop)` | Condition Check #29 AND Player Y within Range [2..255] | Mark NPC Talk Interaction Complete (Flag #2); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[21]` | `128 (Loop)` | Always Passes (Unconditional) | Engine Action #99; Warp Town -> Area 4 Map 90 Submap 25 at (4,6); Dismiss Dialogue Portrait; Set Render Priority (pri) (30, 127); Open Dialogue Message Window; Warp Town -> Area 4 Map 2 Submap 25 at (74,5); Engine Action #94; Warp Town -> Area 1 Map 25 Submap 10 at (255,254) |
| `ev[22]` | `128 (Loop)` | Condition Check #29 AND Player Y within Range [4..255] | Mark NPC Talk Interaction Complete (Flag #2); Exit to World Map (255, 254, 204) |
| `ev[23]` | `128 (Loop)` | Always Passes (Unconditional) | Engine Action #99; Warp Room -> Submap 90 at (26,4) facing 5; Change Portrait Expression (22); Dismiss Emotion Bubble (127); Open Dialogue Message Window; Warp Room -> Submap 2 at (26,84) facing 40; Engine Action #94; Warp Town -> Area 1 Map 26 Submap 10 at (255,254) |
| `ev[24]` | `128 (Loop)` | Condition Check #29 AND Player X within Range [16..255] | Mark NPC Talk Interaction Complete (Flag #1); Dismiss Dialogue Portrait |
| `ev[25]` | `128 (Loop)` | Always Passes (Unconditional) | Engine Action #99; Warp Room -> Submap 90 at (27,4) facing 6; Change Portrait Expression (30); Dismiss Emotion Bubble (127); Open Dialogue Message Window; Warp Room -> Submap 2 at (27,82) facing 44; Engine Action #94; Warp Town -> Area 1 Map 27 Submap 10 at (255,254) |
| `ev[26]` | `128 (Loop)` | Condition Check #29 AND Player X within Range [32..255] | Mark NPC Talk Interaction Complete (Flag #1); Warp Map Transition (255, 254, 204, 204, 204) |
| `ev[27]` | `128 (Loop)` | Always Passes (Unconditional) | Engine Action #99; Warp Room -> Submap 90 at (28,4) facing 7; Change Portrait Expression (35); Dismiss Emotion Bubble (127); Open Dialogue Message Window; Warp Room -> Submap 2 at (28,85) facing 45; Engine Action #94; Warp Town -> Area 1 Map 28 Submap 10 at (255,254) |
| `ev[28]` | `128 (Loop)` | Condition Check #29 AND Player X within Range [64..255] | Mark NPC Talk Interaction Complete (Flag #1); Animate Doorway State (255, 254) |
| `ev[29]` | `1 (Action / Talk)` | Target Inspected is obj[29] | Engine Action #118; Display Emotion Bubble (5, 0); Engine Action #5; Warp Room -> Submap 20 at (40,0) facing South (Down); Warp Town -> Area 5 Map 2 Submap 5 at (3,41); Warp Town -> Area 0 Map 1 Submap 255 at (0,118); Display Emotion Bubble (5, 0); Engine Action #5; Exit to World Map (73, 20, 3); Open Dialogue Message Window; Open Dialogue Message Window; Load Sound Bank into Memory (1, 0); Warp Town -> Area 73 Map 45 Submap 72 at (0,0); Engine Action #89; Open Dialogue Message Window; Warp Town -> Area 9 Map 130 Submap 1 at (0,44); Engine Action #93; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 101 Map 4 Submap 8 at (5,0); Exit to World Map (7, 1, 25); Dismiss Emotion Bubble (12); Open Dialogue Message Window; Branch on Choice (21, 255); Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[30]` | `2 (Map Init)` | Treasure Byte 12 Bit 8 FRESH (Unopened) | Make obj[0] Hidden (disp = 0); Place Scenery Structure (47) |
| `ev[31]` | `2 (Map Init)` | Treasure Byte 12 Bit 8 LOOTED | Make obj[0] Hidden (disp = 0); Animate Door Open; Teleport obj[255] to (254,204) |
| `ev[32]` | `1 (Action / Talk)` | Treasure Byte 12 Bit 8 FRESH (Unopened) AND Target Inspected is obj[13] | Make obj[1] Hidden (disp = 0); Place Scenery Structure (0); Animate Door Open; Teleport obj[101] to (4,7); Dismiss Emotion Bubble (2); Exit to World Map (0, 17, 32); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,12) facing 8; Warp Room -> Submap 0 at (13,1) facing 14; Teleport obj[255] to (254,255) |
| `ev[33]` | `2 (Map Init)` | Treasure Byte 12 Bit 16 FRESH (Unopened) | Make obj[0] Hidden (disp = 0); Show Dialogue Portrait (47, 255, 254) |
| `ev[34]` | `2 (Map Init)` | Treasure Byte 12 Bit 16 LOOTED | Make obj[0] Hidden (disp = 0); Dismiss Dialogue Portrait; Teleport obj[255] to (254,204) |
| `ev[35]` | `1 (Action / Talk)` | Treasure Byte 12 Bit 16 FRESH (Unopened) AND Target Inspected is obj[15] | Make obj[1] Hidden (disp = 0); Show Dialogue Portrait (0, 16, 47); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (2); Exit to World Map (0, 1, 0); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,12) facing 16; Warp Room -> Submap 0 at (15,1) facing 16; Teleport obj[255] to (254,255) |
| `ev[36]` | `2 (Map Init)` | Treasure Byte 12 Bit 32 FRESH (Unopened) | Make obj[0] Hidden (disp = 0); Change Portrait Expression (47) |
| `ev[37]` | `2 (Map Init)` | Treasure Byte 12 Bit 32 LOOTED | Make obj[0] Hidden (disp = 0); Display Speaker Name Box (47) |
| `ev[38]` | `1 (Action / Talk)` | Treasure Byte 12 Bit 32 FRESH (Unopened) AND Target Inspected is obj[17] | Jump to Bytecode Offset (4, 7); Make obj[1] Hidden (disp = 0); Change Portrait Expression (0); Display Speaker Name Box (47); Engine Action #107; Open Dialogue Message Window; Dismiss Emotion Bubble (27); Engine Action #88; Load Sound Bank into Memory (12, 1); Warp Room -> Submap 97 at (12,32) facing 101; Exit to World Map (2, 255, 254) |
| `ev[39]` | `1 (Action / Talk)` | Player within Box [95..96, 2..20] AND Condition Check #40 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 10, MsgID: 3]; Fade Out to Black (255) |
| `ev[40]` | `1 (Action / Talk)` | Player within Box [15..16, 2..49] AND Condition Check #57 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 12, MsgID: 53]; Engine Action #58 |
| `ev[41]` | `128 (Loop)` | Condition Check #41 AND Condition Check #58 AND Condition Check #80 AND Castle HQ Tier >= Level 67 AND Condition Check #60 AND Player X within Range [255..254] | Recruit Character into Active Party (26 [Shiro], 6); Open Dialogue Message Window; Set Combat Battle BGM (20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 4 Map 2 Submap 4 at (3,73); Branch on Choice (41, 2); Open Dialogue Message Window; Warp Room -> Submap 0 at (58,137) facing 12; Close Dialogue Window; Engine Action #94; Dismiss Emotion Bubble (255); Warp Room (Submap); Engine Action #58; Engine Action #137 |
| `ev[42]` | `2 (Map Init)` | Player within Box [93..95, 2..29] AND Condition Check #31 | Warp to Castle HQ (0, 2, 255) |

---

### Submap Layer `vd06_12` (Index 12)

- **Map Number (`mapno`)**: `12`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `80`, Rate: `5`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `2` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (2 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [54..55, 2..54] AND Condition Check #63 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 11, MsgID: 17]; Engine Action #52 |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [31..37, 2..21] AND Inventory Lacks Item #9 AND Player X within Range [255..254] | Display Dialogue Box [Bank: 13, MsgID: 48]; Warp Map Transition (255, 254, 204, 204, 204) |

---

### Submap Layer `vd06_13` (Index 13)

- **Map Number (`mapno`)**: `13`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `80`, Rate: `5`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `2` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (2 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [45..51, 2..33] AND Condition Check #34 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 12, MsgID: 34]; Fade In from Black (255) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [29..35, 2..73] AND Condition Check #74 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 14, MsgID: 176]; Return Warp to Castle Base (255, 254) |

---

### Submap Layer `vd06_14` (Index 14)

- **Map Number (`mapno`)**: `14`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `80`, Rate: `5`)
- **Entity Count (`okaz`)**: `4` Objects | **Script Count (`evkaz`)**: `9` Scripts

#### Complete Physical Entity Inventory (4 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 8)** | `0` | `(156, 89)` | `0x0` | Frame 8 | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 7)** | `0` | `(156, 89)` | `0x0` | Frame 7 | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | World Device | **Mechanism (ano 8)** | `0` | `(29, 93)` | `0x0` | Frame 8 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | World Device | **Mechanism (ano 7)** | `0` | `(29, 93)` | `0x0` | Frame 7 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(156, 89)` with state parameter `8`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(156, 89)` with state parameter `7`.
- **`obj[02]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(29, 93)` with state parameter `8`.
- **`obj[03]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(29, 93)` with state parameter `7`.


#### Complete Bytecode Script Catalog (9 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `128 (Loop)` | Temp Event Flag #1 SET | Set Entity Movement Speed (2, 90); Reset Camera Tracking (17); Screen Fade Transition (30, 255, 254); Engine Action #90; Engine Action #9; Change Portrait Expression (10); Dismiss Emotion Bubble (255); Walk obj[36] to (1,255) |
| `ev[01]` | `128 (Loop)` | Inventory Holds Item #1 [Medicine] AND Temp Event Flag #2 SET AND Treasure Byte 12 Bit 64 FRESH (Unopened) | Warp Room -> Submap 36 at (2,255) facing 254 |
| `ev[02]` | `128 (Loop)` | Inventory Holds Item #1 [Medicine] AND Temp Event Flag #2 SET AND Treasure Byte 12 Bit 64 LOOTED | Warp Room -> Submap 36 at (2,255) facing 254 |
| `ev[03]` | `1 (Action / Talk)` | Treasure Byte 12 Bit 64 FRESH (Unopened) AND Target Inspected is obj[8] | Engine Action #89; Reset Camera Tracking (2); Pan Camera (101, 4, 7); Dismiss Emotion Bubble (2); Exit to World Map (0, 23, 0); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,12) facing 64; Warp Room -> Submap 8 at (2,8) facing 255 |
| `ev[04]` | `2 (Map Init)` | Treasure Byte 12 Bit 128 FRESH (Unopened) | Make obj[0] Hidden (disp = 0); Screen Fade Transition (47, 255, 254) |
| `ev[05]` | `2 (Map Init)` | Treasure Byte 12 Bit 128 LOOTED | Make obj[0] Hidden (disp = 0); Close Dialogue Window; Teleport obj[255] to (254,204) |
| `ev[06]` | `1 (Action / Talk)` | Treasure Byte 12 Bit 128 FRESH (Unopened) AND Target Inspected is obj[10] | Make obj[1] Hidden (disp = 0); Screen Fade Transition (0, 11, 47); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (2); Exit to World Map (0, 6, 16); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,12) facing 128; Warp Room -> Submap 0 at (10,1) facing 11; Teleport obj[255] to (254,255) |
| `ev[07]` | `1 (Action / Talk)` | Player within Box [173..179, 2..30] AND Condition Check #31 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 13, MsgID: 32]; Load Sound Bank into Memory (255, 254) |
| `ev[08]` | `1 (Action / Talk)` | Player within Box [25..31, 2..22] AND Condition Check #23 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 15, MsgID: 32]; Engine Action #90 |

---

### Submap Layer `vd06_15` (Index 15)

- **Map Number (`mapno`)**: `15`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `80`, Rate: `5`)
- **Entity Count (`okaz`)**: `1` Objects | **Script Count (`evkaz`)**: `7` Scripts

#### Complete Physical Entity Inventory (1 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Kahn Marley** | `36` | `(45, 47)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Kahn Marley)**: Positioned at tile `(45, 47)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.


#### Complete Bytecode Script Catalog (7 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Story Flag 85 (bit 1) SET AND Story Flag 85 (bit 2) CLEAR AND Player within Box [27..42, 2..68] AND Condition Check #72 | Jump to Bytecode Offset (9, 9); Launch Tactical War Battle (128); Dismiss Character to Castle Base (36 [Kahn]); Dismiss Emotion Bubble (55); Open Dialogue Message Window; Return Warp to Castle Base (70, 8); Jump to Bytecode Offset (0, 176); Warp to Castle HQ (0, 1, 72); Warp Room -> Submap 2 at (36,1) facing 76; Warp Room -> Submap 3 at (11,5) facing 54; Warp Room -> Submap 33 at (3,3) facing 35; Display Choice Selection (46, 0); Warp Room -> Submap 2 at (0,3) facing South (Down); Exit to World Map (0, 6, 0); Engine Action #5; Teleport obj[49] to (6,5); Warp Room -> Submap 5 at (3,2) facing West (Left); Warp Town -> Area 30 Map 255 Submap 254 at (5,2); Exit to World Map (5, 3, 3); Warp Room -> Submap 30 at (255,254) facing 5; Warp to Castle HQ (4, 5, 2); Warp to Castle HQ (1, 1, 30); Engine Action #5; Exit to World Map (4, 5, 0); Warp Town -> Area 2 Map 3 Submap 1 at (0,30); Engine Action #5; Engine Action #6; Exit to World Map (5, 0, 4); Warp to Castle HQ (1, 1, 0); Dismiss Emotion Bubble (255); Engine Action #5; Engine Action #5; Exit to World Map (5, 0, 4); Warp Town -> Area 2 Map 1 Submap 0 at (30,255); Walk obj[24] to (1,0); Exit to World Map (5, 8, 4); Exit to World Map (0, 2, 30); Close Dialogue Sub-Window (8); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp Room -> Submap 4 at (1,1) facing 30; Close Dialogue Sub-Window (1); Open Dialogue Message Window; Engine Action #6; Close Dialogue Sub-Window (8); Open Dialogue Message Window; Pan Camera (24, 1, 0); Reset Camera Tracking (24); Reset Camera Tracking (0); Engine Action #9; Close Dialogue Sub-Window (1); Open Dialogue Message Window; Screen Fade Transition (24, 8, 0); Close Dialogue Window; Close Dialogue Sub-Window (1); Open Dialogue Message Window; Display Dialogue Box [Bank: 24, MsgID: 8]; Open Dialogue Message Window; Place Scenery Structure (72); Warp Room -> Submap 7 at (24,1) facing South (Down); Animate Door Open; Load Sound Bank into Memory (0, 1); Close Dialogue Sub-Window (8); Open Dialogue Message Window; Show Dialogue Portrait (24, 1, 0); Dismiss Dialogue Portrait; Close Dialogue Sub-Window (8); Open Dialogue Message Window; Change Portrait Expression (5); Warp Room -> Submap 1 at (30,72) facing West (Left); Warp Room -> Submap 24 at (1,0) facing 18; Load Sound Bank into Memory (0, 1); Close Dialogue Sub-Window (8); Open Dialogue Message Window; Display Choice Selection (73, 20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 0 Map 20 Submap 0 at (21,41); Warp Town -> Area 0 Map 1 Submap 255 at (0,3); Warp Room -> Submap 24 at (1,0) facing 22; Set Combat Battle BGM (20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 0 Map 20 Submap 0 at (21,41); Warp Town -> Area 2 Map 1 Submap 255 at (2,3); Warp to Castle HQ (3, 24, 3); Open Dialogue Message Window; Open Dialogue Sub-Window (73); Branch on Choice (40, 0); Open Dialogue Message Window; Warp Town -> Area 0 Map 20 Submap 0 at (21,41); Warp Town -> Area 3 Map 1 Submap 255 at (3,3); Warp Town -> Area 2 Map 24 Submap 2 at (0,24); Set Combat Battle BGM (20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 0 Map 20 Submap 0 at (21,41); Warp Town -> Area 0 Map 1 Submap 255 at (1,24); Reset Camera Tracking (0); Clear Dialogue Sub-Window; Launch Tactical War Battle (4); Engine Action #39; Return Warp to Castle Base (54, 1); Reset Camera Tracking (9); Engine Action #85; Warp Town -> Area 115 Map 36 Submap 24 at (54,0); Engine Action #128; Pathfind and Walk to Coordinates (4, 0, 1); Launch Tactical War Battle (1); Recruit Jowy Atreides into Battle Slot 0; Dismiss Character to Castle Base (36 [Kahn]); Toggle Random Encounters (29); Engine Action #5; Engine Action #9; Engine Action #151; Animate Doorway State (101, 5); Engine Action #176; Jump to Bytecode Offset (1, 0) |
| `ev[01]` | `128 (Loop)` | Story Flag 85 (bit 1) SET AND Story Flag 85 (bit 2) CLEAR AND Inventory Holds Item #1 [Medicine] AND Temp Event Flag #2 SET | Set Combat Battle BGM (30); Load Sound Bank into Memory (0, 0); Set Render Priority (pri) (0, 41); Engine Action #63; Engine Action #9; Set Render Priority (pri) (0, 45); Engine Action #54; Engine Action #9; Warp to Castle HQ (0, 1, 36); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[02]` | `128 (Loop)` | Story Flag 85 (bit 1) SET AND Story Flag 85 (bit 2) CLEAR AND Inventory Holds Item #4 [Throat Drops] AND Temp Event Flag #8 SET | Open Shop Menu #5 (Type: 8); Turn obj[8] facing South (Down); Warp Town -> Area 0 Map 0 Submap 0 at (9,1); Reset Camera Tracking (36); Reset Camera Tracking (255) |
| `ev[03]` | `128 (Loop)` | Story Flag 85 (bit 1) SET AND Story Flag 85 (bit 2) CLEAR AND Inventory Holds Item #128 | Warp Room -> Submap 2 at (13,28); Toggle Random Encounters (128) |
| `ev[04]` | `2 (Map Init)` | Story Flag 85 (bit 1) SET AND Story Flag 85 (bit 2) CLEAR | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[05]` | `1 (Action / Talk)` | Player within Box [29..35, 2..91] AND Condition Check #92 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 14, MsgID: 28]; Display Chapter Text (255) |
| `ev[06]` | `1 (Action / Talk)` | Player within Box [29..35, 2..21] AND Inventory Lacks Item #9 AND Player X within Range [255..254] | Display Dialogue Box [Bank: 16, MsgID: 30]; Animate Doorway State (255, 254) |

---

### Submap Layer `vd06_16` (Index 16)

- **Map Number (`mapno`)**: `16`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `80`, Rate: `5`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `2` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (2 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [27..33, 2..64] AND Condition Check #65 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 15, MsgID: 32]; Close Dialogue Sub-Window (255) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [106..107, 2..32] AND Condition Check #40 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 17, MsgID: 25]; Engine Action #94 |

---

### Submap Layer `vd06_17` (Index 17)

- **Map Number (`mapno`)**: `17`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `80`, Rate: `5`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `2` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (2 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [23..24, 2..90] AND Condition Check #99 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 16, MsgID: 105]; Launch Tactical War Battle (255) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [41..47, 2..21] AND Inventory Lacks Item #9 AND Player X within Range [255..254] | Display Dialogue Box [Bank: 18, MsgID: 30]; Engine Action #58 |

---

### Submap Layer `vd06_18` (Index 18)

- **Map Number (`mapno`)**: `18`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `3` Objects | **Script Count (`evkaz`)**: `16` Scripts

#### Complete Physical Entity Inventory (3 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | Prop / Scenery | **Prop ID 157** | `157` | `(30, 24)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 32)** | `0` | `(28, 25)` | `0x0` | Frame 32 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Nina** | `13` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Prop: Object 157)**: Environmental world dressing prop placed at tile `(30, 24)`. Solid collision is set to `34`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(28, 25)` with state parameter `32`.
- **`obj[02]` (Nina)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.


#### Complete Bytecode Script Catalog (16 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 85 (bit 2) SET AND Story Flag 85 (bit 4) CLEAR | Make obj[0] Hidden (disp = 0); Reset Camera Tracking (0); Engine Action #9; Teleport obj[255] to (254,204) |
| `ev[01]` | `1 (Action / Talk)` | Story Flag 85 (bit 2) SET AND Story Flag 85 (bit 4) CLEAR AND Player within Box [25..35, 2..42] AND Condition Check #43 | Jump to Bytecode Offset (9, 9); Launch Tactical War Battle (8); Set Render Priority (pri) (0, 30); Warp Map Transition (8, 101, 7, 0, 101); Open Dialogue Message Window; Engine Action #176; Display Chapter Text (1); Engine Action #6; Exit to World Map (3, 0, 1); Return to Previous Memory Map (4); Warp to Castle HQ (19, 36, 35); Make obj[0] Hidden (disp = 0); Warp Room -> Submap 2 at (0,3) facing South (Down); Exit to World Map (0, 6, 0); Engine Action #5; Teleport obj[49] to (6,5); Warp Room -> Submap 5 at (1,2) facing 30; Engine Action #5; Warp Town -> Area 4 Map 5 Submap 3 at (3,1); Warp Town -> Area 30 Map 255 Submap 254 at (5,3); Exit to World Map (5, 2, 3); Warp Room -> Submap 30 at (255,254) facing 5; Exit to World Map (4, 5, 0); Warp Town -> Area 2 Map 3 Submap 1 at (0,30); Engine Action #5; Engine Action #6; Exit to World Map (5, 0, 4); Warp to Castle HQ (1, 1, 0); Dismiss Emotion Bubble (255); Engine Action #5; Engine Action #5; Exit to World Map (5, 0, 4); Warp Town -> Area 2 Map 1 Submap 0 at (30,255); Walk obj[5] to (2,4); Exit to World Map (1, 1, 30); Close Dialogue Sub-Window (2); Open Dialogue Message Window; Fade In from Black (5); Warp Room -> Submap 4 at (1,1) facing 30; Close Dialogue Sub-Window (1); Open Dialogue Message Window; Fade Out to Black (24); Reset Camera Tracking (0); Display Chapter Text (24); Warp Room -> Submap 0 at (3,2) facing South (Down); Close Dialogue Sub-Window (2); Open Dialogue Message Window; Dismiss Emotion Bubble (101); Open Dialogue Message Window; Engine Action #177; Close Dialogue Window; Warp to Castle HQ (2, 30, 73); Dismiss Emotion Bubble (24); Reset Camera Tracking (0); Warp Room -> Submap 72 at (1,2); Open Dialogue Message Window; Engine Action #5; Warp Town -> Area 6 Map 2 Submap 30 at (72,0); Warp Town -> Area 24 Map 2 Submap 0 at (32,3); Warp Town -> Area 1 Map 72 Submap 1 at (1,9); Close Dialogue Sub-Window (1); Open Dialogue Message Window; Return to Previous Memory Map (72); Open Dialogue Message Window; Warp Room -> Submap 1 at (24,2) facing South (Down); Return Warp to Castle Base (37, 1); Warp to Castle HQ (2, 1, 24); Reset Camera Tracking (0); Start Boss Battle #5 (BGM: 1); Exit to World Map (3, 1, 2); Dismiss Emotion Bubble (24); Warp Room -> Submap 36 at (24,8) facing South (Down); Toggle Random Encounters (24); Warp Room -> Submap 38 at (89,8) facing Up (North); Warp Town -> Area 101 Map 0 Submap 178 at (90,8); Exit to World Map (5, 17, 2); Dismiss Emotion Bubble (73); Branch on Choice (5, 1); Pan Camera (1, 30, 24); Warp Room -> Submap 39 at (89,8) facing Up (North); Warp to Castle HQ (73, 105, 101); Open Dialogue Message Window; Engine Action #179; Engine Action #89; Reset Camera Tracking (5); Engine Action #89; Reset Camera Tracking (5); Engine Action #89; Reset Camera Tracking (2); Exit to World Map (36, 4, 73); Branch on Choice (24, 1); Open Dialogue Message Window; Engine Action #40; Close Dialogue Sub-Window (8); Open Dialogue Message Window; Award Potch Loot (+25,865 Potch); Engine Action #9; Set Combat Battle BGM (20); Engine Action #54; Open Dialogue Message Window; Reset Camera Tracking (37); Exit to World Map (54, 1, 16); Engine Action #9; Engine Action #85; Exit to World Map (101, 5, 176); Engine Action #102; Warp Room -> Submap 1 at (240,102) facing South (Down); Jump to Bytecode Offset (0, 176) |
| `ev[02]` | `2 (Map Init)` | Story Flag 85 (bit 4) SET AND Story Flag 85 (bit 32) CLEAR | Make obj[2] Hidden (disp = 0); Reset Camera Tracking (30); Close Dialogue Sub-Window (36); Exit to World Map (47, 255, 254) |
| `ev[03]` | `1 (Action / Talk)` | Story Flag 85 (bit 4) SET AND Story Flag 85 (bit 8) SET AND Story Flag 85 (bit 32) CLEAR | Close Dialogue Sub-Window (1); Open Dialogue Message Window; Make obj[24] Hidden (disp = 0); Reset Camera Tracking (0); Teleport obj[9] to (85,32) |
| `ev[04]` | `1 (Action / Talk)` | Story Flag 85 (bit 4) SET AND Story Flag 85 (bit 16) SET AND Story Flag 85 (bit 32) CLEAR | Close Dialogue Sub-Window (1); Open Dialogue Message Window; Remove Item from Inventory (24, 8); Open Dialogue Message Window; Open Shop Menu #1 (Type: 72); Warp Room -> Submap 24 at (1,0) facing 44; Load Sound Bank into Memory (0, 1); Close Dialogue Sub-Window (8); Open Dialogue Message Window; Make obj[9] Visible (disp = 1); Engine Action #85; Warp Map Transition (255, 254, 204, 204, 204) |
| `ev[05]` | `1 (Action / Talk)` | Story Flag 85 (bit 32) SET AND Story Flag 85 (bit 64) CLEAR | Close Dialogue Sub-Window (1); Open Dialogue Message Window; Turn obj[24] facing 8; Open Dialogue Message Window; Set Entity Movement Speed (5, 3); Exit to World Map (4, 1, 1); Dismiss Emotion Bubble (24); Warp to Castle HQ (0, 50, 24); Reset Camera Tracking (0); Engine Action #51; Close Dialogue Sub-Window (1); Open Dialogue Message Window; Engine Action #52; Close Dialogue Sub-Window (8); Open Dialogue Message Window; Engine Action #53; Close Dialogue Sub-Window (1); Open Dialogue Message Window; Engine Action #54; Close Dialogue Sub-Window (8); Open Dialogue Message Window; Set Render Priority (pri) (37, 4); Engine Action #54; Warp Room -> Submap 5 at (1,1) facing East (Right); Dismiss Emotion Bubble (93); Warp Room -> Submap 0 at (90,8) facing 16; Warp to Castle HQ (30, 1, 8); Warp to Castle HQ (1, 0, 24); Warp Room -> Submap 56 at (24,8) facing South (Down); Recruit Character into Active Party (24 [Milie], 1); Open Dialogue Message Window; Engine Action #58; Close Dialogue Sub-Window (2); Open Dialogue Message Window; Set obj[24] Collision to Passable; Open Dialogue Message Window; Trigger Character Emotion Effect (39, 34); Dismiss Emotion Bubble (1); Open Dialogue Message Window; Exit to World Map (0, 27, 22); Reset Camera Tracking (4); Open Dialogue Message Window; Dismiss Emotion Bubble (20); Reset Camera Tracking (9); Engine Action #85; Animate Doorway State (101, 5); Engine Action #176 |
| `ev[06]` | `128 (Loop)` | Story Flag 85 (bit 2) SET AND Story Flag 85 (bit 4) CLEAR AND Character #1 Level >= 255 | Engine Action #80; Warp Room -> Submap 1 at (7,1) facing 30; Load Sound Bank into Memory (1, 1); Exit to World Map (73, 80, 82); Load Sound Bank into Memory (0, 1) |
| `ev[07]` | `128 (Loop)` | Story Flag 85 (bit 2) SET AND Story Flag 85 (bit 4) CLEAR AND Inventory Holds Item #1 [Medicine] | Award Potch Currency (2,0); Open Dialogue Message Window; Engine Action #5; Branch on Choice (1, 0); Engine Action #5; Branch on Choice (30, 255) |
| `ev[08]` | `128 (Loop)` | Story Flag 85 (bit 2) SET AND Story Flag 85 (bit 64) CLEAR AND Inventory Holds Item #4 [Throat Drops] | Toggle Random Encounters (16); Engine Action #90; Reset Camera Tracking (4); Warp Town -> Area 16 Map 1 Submap 17 at (1,30); Launch Tactical War Battle (16) |
| `ev[09]` | `128 (Loop)` | Story Flag 85 (bit 2) SET AND Story Flag 85 (bit 4) CLEAR AND Inventory Holds Item #8 [Fire Wall] | Warp Room -> Submap 1 at (15,19); Toggle Random Encounters (8) |
| `ev[10]` | `2 (Map Init)` | Story Flag 151 (bit 64) CLEAR AND Condition Check #33 AND Always Passes (Unconditional) AND Story Flag 24 (bit 13) CLEAR AND Player Y within Range [255..254] | Make obj[2] Hidden (disp = 0); Screen Fade Transition (30, 25, 3); Screen Fade Transition (1, 0, 10); Teleport obj[255] to (254,204) |
| `ev[11]` | `1 (Action / Talk)` | Condition Check #33 AND Always Passes (Unconditional) AND Story Flag 24 (bit 13) CLEAR AND Player Y within Range [4..146] AND Condition Check #32 AND Player within Box [25..35, 2..42] AND Condition Check #43 | Launch Tactical War Battle (1); Dismiss Character to Castle Base (13 [Pesmerga]); Dismiss Emotion Bubble (55); Open Dialogue Message Window; Dismiss Emotion Bubble (32); Engine Action #9; Warp to Castle HQ (0, 1, 24); Screen Fade Transition (3, 0, 5); Screen Fade Transition (0, 1, 30); Set Combat Battle BGM (60); Engine Action #5; Screen Fade Transition (0, 3, 30); Close Dialogue Sub-Window (10); Warp to Castle HQ (1, 9, 146); Warp Map Transition (73, 20, 40, 0, 0); Warp Town -> Area 3 Map 2 Submap 3 at (3,41); Warp Town -> Area 0 Map 1 Submap 255 at (0,24); Screen Fade Transition (3, 4, 84); Place Scenery Structure (31); Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 101, 4); Engine Action #6; Engine Action #5; Open Dialogue Message Window; Warp Town -> Area 0 Map 5 Submap 3 at (1,0); Engine Action #5; Warp to Castle HQ (3, 0, 5); Warp to Castle HQ (0, 0, 5); Warp to Castle HQ (30, 89, 0); Warp Town -> Area 8 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Engine Action #89; Open Dialogue Message Window; Warp Town -> Area 9 Map 5 Submap 0 at (6,2); Dismiss Emotion Bubble (89); Open Dialogue Message Window; Warp Town -> Area 10 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Dismiss Emotion Bubble (4); Warp Room -> Submap 5 at (0,0) facing South (Down); Engine Action #5; Show Dialogue Portrait (1, 0, 30); Engine Action #116; Place Scenery Structure (1); Open Dialogue Message Window; Engine Action #5; Close Dialogue Sub-Window (10); Warp to Castle HQ (5, 73, 20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 3 Map 6 Submap 3 at (7,41); Warp Town -> Area 2 Map 3 Submap 255 at (2,54); Open Dialogue Message Window; Warp Room -> Submap 10 at (3,8) facing 48; Screen Fade Transition (0, 2, 0); Warp Room -> Submap 8 at (1,10) facing 112; Exit to World Map (1, 1, 13); Warp Room -> Submap 2 at (0,255) facing 254; Warp to Castle HQ (24, 10, 3); Engine Action #9; Set Combat Battle BGM (20); Display Dialogue Box [Bank: 18, MsgID: 30]; Warp Map Transition (255, 254, 255, 1, 24); Screen Fade Transition (3, 10, 73); Branch on Choice (40, 0); Open Dialogue Message Window; Warp Town -> Area 3 Map 11 Submap 3 at (12,41); Warp Town -> Area 0 Map 5 Submap 255 at (5,24); Screen Fade Transition (3, 13, 255) |
| `ev[12]` | `1 (Action / Talk)` | Condition Check #33 AND Always Passes (Unconditional) AND Story Flag 24 (bit 13) CLEAR AND Player Y within Range [3..146] AND Condition Check #32 AND Target Inspected is obj[10] | Launch Tactical War Battle (1); Set Animation Pose (0, 10); Warp Town -> Area 0 Map 0 Submap 3 at (9,3); Screen Fade Transition (0, 3, 0); Warp Room -> Submap 10 at (3,14) facing 73; Branch on Choice (40, 0); Open Dialogue Message Window; Warp Town -> Area 3 Map 15 Submap 3 at (16,41); Warp Town -> Area 0 Map 1 Submap 255 at (0,24); Screen Fade Transition (3, 4, 84); Place Scenery Structure (31); Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 101, 4); Engine Action #6; Engine Action #5; Open Dialogue Message Window; Warp Town -> Area 0 Map 5 Submap 3 at (1,0); Engine Action #5; Warp to Castle HQ (3, 0, 5); Warp to Castle HQ (0, 0, 5); Warp to Castle HQ (30, 89, 0); Warp Town -> Area 8 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Engine Action #89; Open Dialogue Message Window; Warp Town -> Area 9 Map 5 Submap 0 at (6,2); Dismiss Emotion Bubble (89); Open Dialogue Message Window; Warp Town -> Area 10 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Dismiss Emotion Bubble (4); Warp Room -> Submap 5 at (0,0) facing South (Down); Engine Action #5; Show Dialogue Portrait (1, 0, 30); Engine Action #116; Place Scenery Structure (1); Open Dialogue Message Window; Engine Action #5; Close Dialogue Sub-Window (10); Warp to Castle HQ (5, 73, 20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 3 Map 6 Submap 3 at (7,41); Warp Town -> Area 2 Map 3 Submap 255 at (2,54); Open Dialogue Message Window; Warp Room -> Submap 10 at (3,8) facing 48; Screen Fade Transition (0, 2, 0); Warp Room -> Submap 8 at (1,10) facing 112; Exit to World Map (1, 1, 13); Warp Room -> Submap 2 at (0,255) facing 254; Warp to Castle HQ (24, 10, 3); Engine Action #9; Set Combat Battle BGM (20); Display Dialogue Box [Bank: 18, MsgID: 30]; Warp Map Transition (255, 254, 255, 1, 24); Screen Fade Transition (3, 17, 255) |
| `ev[13]` | `128 (Loop)` | Condition Check #33 AND Always Passes (Unconditional) AND Story Flag 24 (bit 13) CLEAR AND Player Y within Range [6..1] | Warp Room -> Submap 1 at (13,28); Toggle Random Encounters (1) |
| `ev[14]` | `1 (Action / Talk)` | Player within Box [27..33, 2..59] AND Condition Check #60 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 17, MsgID: 44]; Close Dialogue Sub-Window (255) |
| `ev[15]` | `1 (Action / Talk)` | Player within Box [27..33, 2..18] AND Castle HQ Tier >= Level 9 AND Player X within Range [255..254] | Display Dialogue Box [Bank: 0, MsgID: 20]; Execute Choice Result (255) |

---



## Location Map: `vd13`

- **Master Map Container**: `vd13.json`
- **Submap Layer Files**: vd13_00.json
- **Collision Grid Files**: vd13_map_00.json, vd13_map_04.json, vd13_map_06.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 7

### Submap Layer `vd13_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `4`)
- **Entity Count (`okaz`)**: `13` Objects | **Script Count (`evkaz`)**: `24` Scripts

#### Complete Physical Entity Inventory (13 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 16)** | `0` | `(44, 146)` | `0x0` | Frame 16 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 50 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 16)** | `0` | `(52, 146)` | `0x0` | Frame 16 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 50 | 0 |
| `obj[02]` | World Device | **Mechanism (ano 16)** | `0` | `(54, 140)` | `0x0` | Frame 16 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 50 | 0 |
| `obj[03]` | World Device | **Mechanism (ano 16)** | `0` | `(68, 146)` | `0x0` | Frame 16 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 50 | 0 |
| `obj[04]` | World Device | **Mechanism (ano 16)** | `0` | `(76, 146)` | `0x0` | Frame 16 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 50 | 0 |
| `obj[05]` | Treasure Chest | **Opened Chest** | `0` | `(60, 134)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | World Device | **Mechanism (ano 5)** | `0` | `(60, 134)` | `0x0` | Frame 5 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | World Device | **Mechanism (ano 4)** | `0` | `(60, 134)` | `0x0` | Frame 4 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Treasure Chest | **Opened Chest** | `0` | `(42, 134)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | World Device | **Mechanism (ano 5)** | `0` | `(42, 134)` | `0x0` | Frame 5 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | World Device | **Mechanism (ano 4)** | `0` | `(42, 134)` | `0x0` | Frame 4 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | World Device | **Mechanism (ano 19)** | `0` | `(70, 68)` | `0x0` | Frame 19 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[12]` | World Device | **Mechanism (ano 20)** | `0` | `(70, 68)` | `0x0` | Frame 20 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(44, 146)` with state parameter `16`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(52, 146)` with state parameter `16`.
- **`obj[02]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(54, 140)` with state parameter `16`.
- **`obj[03]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(68, 146)` with state parameter `16`.
- **`obj[04]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(76, 146)` with state parameter `16`.
- **`obj[05]` (Treasure Chest)**: Placed at tile `(60, 134)`. Initial state is Open. Controlled by map loot bitflags.
- **`obj[06]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(60, 134)` with state parameter `5`.
- **`obj[07]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(60, 134)` with state parameter `4`.
- **`obj[08]` (Treasure Chest)**: Placed at tile `(42, 134)`. Initial state is Open. Controlled by map loot bitflags.
- **`obj[09]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(42, 134)` with state parameter `5`.
- **`obj[10]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(42, 134)` with state parameter `4`.
- **`obj[11]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(70, 68)` with state parameter `19`.
- **`obj[12]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(70, 68)` with state parameter `20`.


#### Complete Bytecode Script Catalog (24 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Treasure Byte 10 Bit 1 FRESH (Unopened) | Open Dialogue Message Window; Display Choice Selection (255, 254) |
| `ev[01]` | `2 (Map Init)` | Treasure Byte 10 Bit 1 LOOTED | Open Dialogue Message Window; Branch on Choice (255, 254) |
| `ev[02]` | `1 (Action / Talk)` | Treasure Byte 10 Bit 1 FRESH (Unopened) AND Target Inspected is obj[19] | Make obj[1] Hidden (disp = 0); Display Choice Selection (0, 20); Teleport obj[101] to (4,7); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (1); Exit to World Map (0, 16, 32); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,10) facing West (Left); Warp Room -> Submap 1 at (20,0) facing 19; Teleport obj[255] to (254,255) |
| `ev[03]` | `2 (Map Init)` | Player within Box [38..86, 2..130] AND Condition Check #158 | Make obj[133] Hidden (disp = 0); Warp Room -> Submap 8 at (0,9) facing South (Down); Screen Fade Transition (0, 11, 0); Display Dialogue Box [Bank: 47, MsgID: 255] |
| `ev[04]` | `2 (Map Init)` | Condition Check #30 AND Player Y within Range [4..255] | Open Dialogue Message Window; Dismiss Dialogue Portrait |
| `ev[05]` | `2 (Map Init)` | Condition Check #29 AND Player Y within Range [4..255] | Open Dialogue Message Window; Change Portrait Expression (255) |
| `ev[06]` | `2 (Map Init)` | Condition Check #30 AND Player Y within Range [8..255] | Open Dialogue Message Window; Place Scenery Structure (255) |
| `ev[07]` | `2 (Map Init)` | Condition Check #29 AND Player Y within Range [8..255] | Open Dialogue Message Window; Animate Door Open |
| `ev[08]` | `128 (Loop)` | Always Passes (Unconditional) | Dismiss Emotion Bubble (0); Open Dialogue Message Window |
| `ev[09]` | `1 (Action / Talk)` | Condition Check #29 AND Story Flag 2 (bit 30) SET AND Player Y within Range [8..255] | Jump to Bytecode Offset (0, 178); Make obj[1] Hidden (disp = 0); Place Scenery Structure (0); Show Dialogue Portrait (47, 73, 20); Make obj[1] Hidden (disp = 0); Show Dialogue Portrait (0, 14, 47); Engine Action #99; Warp Town -> Area 8 Map 255 Submap 254 at (255,254) |
| `ev[10]` | `1 (Action / Talk)` | Condition Check #29 AND Story Flag 1 (bit 30) SET AND Player Y within Range [4..255] | Jump to Bytecode Offset (0, 178); Make obj[1] Hidden (disp = 0); Dismiss Dialogue Portrait; Open Dialogue Message Window; Display Speaker Name Box (47); Set Combat Battle BGM (20); Make obj[1] Hidden (disp = 0); Display Speaker Name Box (0); Change Portrait Expression (47); Engine Action #99; Warp Town -> Area 4 Map 255 Submap 254 at (255,254) |
| `ev[11]` | `128 (Loop)` | Player within Box [110..129, 2..15] AND Condition Check #31 | Warp Room -> Submap 0 at (3,10) |
| `ev[12]` | `1 (Action / Talk)` | Player within Box [130..131, 2..21] AND Condition Check #26 AND Story Flag 3 (mask 255) SET | Warp Map Transition (3, 2, 28, 136, 255) |
| `ev[13]` | `1 (Action / Talk)` | Player within Box [118..122, 2..32] AND Condition Check #33 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 122]; Open Shop Interface #255 |
| `ev[14]` | `1 (Action / Talk)` | Player within Box [120..124, 2..64] AND Condition Check #65 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 120]; Display Emotion Bubble (255, 254) |
| `ev[15]` | `1 (Action / Talk)` | Player within Box [120..124, 2..102] AND Condition Check #103 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 80]; Engine Action #135 |
| `ev[16]` | `1 (Action / Talk)` | Player within Box [78..82, 2..132] AND Condition Check #133 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 122]; Engine Action #99 |
| `ev[17]` | `1 (Action / Talk)` | Player within Box [60..64, 2..132] AND Condition Check #133 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 72]; Engine Action #99 |
| `ev[18]` | `1 (Action / Talk)` | Player within Box [70..74, 2..102] AND Condition Check #103 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 62]; Engine Action #135 |
| `ev[19]` | `1 (Action / Talk)` | Player within Box [42..46, 2..132] AND Condition Check #133 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 22]; Engine Action #99 |
| `ev[20]` | `1 (Action / Talk)` | Player within Box [20..24, 2..102] AND Condition Check #103 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 44]; Engine Action #135 |
| `ev[21]` | `1 (Action / Talk)` | Player within Box [20..24, 2..64] AND Condition Check #65 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 28]; Display Chapter Text (255) |
| `ev[22]` | `1 (Action / Talk)` | Player within Box [26..30, 2..30] AND Condition Check #32 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 22]; Play CD / Ambient BGM Track (255) |
| `ev[23]` | `1 (Action / Talk)` | Player within Box [23..33, 2..10] AND Player X in Range [9..1] | Display Dialogue Box [Bank: 1, MsgID: 24]; Change Portrait Expression (255) |

---

### Submap Layer `vd13_01` (Index 1)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `4`)
- **Entity Count (`okaz`)**: `28` Objects | **Script Count (`evkaz`)**: `42` Scripts

#### Complete Physical Entity Inventory (28 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | Treasure Chest | **Opened Chest** | `0` | `(60, 134)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 5)** | `0` | `(60, 134)` | `0x0` | Frame 5 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | World Device | **Mechanism (ano 4)** | `0` | `(60, 134)` | `0x0` | Frame 4 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | Treasure Chest | **Opened Chest** | `0` | `(78, 134)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | World Device | **Mechanism (ano 5)** | `0` | `(78, 134)` | `0x0` | Frame 5 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | World Device | **Mechanism (ano 4)** | `0` | `(78, 134)` | `0x0` | Frame 4 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | World Device | **Mechanism (ano 17)** | `0` | `(44, 150)` | `0x0` | Frame 17 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | World Device | **Mechanism (ano 17)** | `0` | `(52, 150)` | `0x0` | Frame 17 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | World Device | **Mechanism (ano 17)** | `0` | `(60, 150)` | `0x0` | Frame 17 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | World Device | **Mechanism (ano 17)** | `0` | `(68, 150)` | `0x0` | Frame 17 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | World Device | **Mechanism (ano 17)** | `0` | `(76, 150)` | `0x0` | Frame 17 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | World Device | **Mechanism (ano 17)** | `0` | `(44, 140)` | `0x0` | Frame 17 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | World Device | **Mechanism (ano 17)** | `0` | `(52, 140)` | `0x0` | Frame 17 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | World Device | **Mechanism (ano 17)** | `0` | `(60, 140)` | `0x0` | Frame 17 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | World Device | **Mechanism (ano 17)** | `0` | `(68, 140)` | `0x0` | Frame 17 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[15]` | World Device | **Mechanism (ano 17)** | `0` | `(76, 140)` | `0x0` | Frame 17 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[16]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(44, 149)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[17]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(52, 149)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[18]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(60, 149)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[19]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(68, 149)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[20]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(76, 149)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[21]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(44, 139)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[22]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(52, 139)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[23]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(60, 139)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[24]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(68, 139)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[25]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(76, 139)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[26]` | World Device | **Mechanism (ano 19)** | `0` | `(70, 68)` | `0x0` | Frame 19 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[27]` | World Device | **Mechanism (ano 20)** | `0` | `(70, 68)` | `0x0` | Frame 20 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Treasure Chest)**: Placed at tile `(60, 134)`. Initial state is Open. Controlled by map loot bitflags.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(60, 134)` with state parameter `5`.
- **`obj[02]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(60, 134)` with state parameter `4`.
- **`obj[03]` (Treasure Chest)**: Placed at tile `(78, 134)`. Initial state is Open. Controlled by map loot bitflags.
- **`obj[04]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(78, 134)` with state parameter `5`.
- **`obj[05]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(78, 134)` with state parameter `4`.
- **`obj[06]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(44, 150)` with state parameter `17`.
- **`obj[07]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(52, 150)` with state parameter `17`.
- **`obj[08]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(60, 150)` with state parameter `17`.
- **`obj[09]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(68, 150)` with state parameter `17`.
- **`obj[10]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(76, 150)` with state parameter `17`.
- **`obj[11]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(44, 140)` with state parameter `17`.
- **`obj[12]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(52, 140)` with state parameter `17`.
- **`obj[13]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(60, 140)` with state parameter `17`.
- **`obj[14]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(68, 140)` with state parameter `17`.
- **`obj[15]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(76, 140)` with state parameter `17`.
- **`obj[16]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(44, 149)` to `(45, 150)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[17]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(52, 149)` to `(53, 150)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[18]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(60, 149)` to `(61, 150)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[19]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(68, 149)` to `(69, 150)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[20]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(76, 149)` to `(77, 150)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[21]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(44, 139)` to `(45, 140)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[22]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(52, 139)` to `(53, 140)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[23]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(60, 139)` to `(61, 140)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[24]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(68, 139)` to `(69, 140)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[25]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(76, 139)` to `(77, 140)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[26]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(70, 68)` with state parameter `19`.
- **`obj[27]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(70, 68)` with state parameter `20`.


#### Complete Bytecode Script Catalog (42 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Treasure Byte 10 Bit 2 FRESH (Unopened) | Open Dialogue Message Window; Return Warp to Castle Base (255, 254) |
| `ev[01]` | `2 (Map Init)` | Treasure Byte 10 Bit 2 LOOTED | Open Dialogue Message Window; Start Boss Battle #255 (BGM: 254) |
| `ev[02]` | `1 (Action / Talk)` | Treasure Byte 10 Bit 2 FRESH (Unopened) AND Target Inspected is obj[34] | Make obj[1] Hidden (disp = 0); Return Warp to Castle Base (0, 35); Teleport obj[101] to (4,7); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (1); Exit to World Map (0, 71, 16); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,10) facing Up (North); Warp Room -> Submap 1 at (35,0) facing 34; Teleport obj[255] to (254,255) |
| `ev[03]` | `2 (Map Init)` | Condition Check #30 AND Player Y within Range [1..255] | Open Dialogue Message Window; Close Dialogue Window |
| `ev[04]` | `2 (Map Init)` | Condition Check #29 AND Player Y within Range [1..255] | Open Dialogue Message Window; Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[05]` | `2 (Map Init)` | Condition Check #30 AND Player Y within Range [2..255] | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[06]` | `2 (Map Init)` | Condition Check #29 AND Player Y within Range [2..255] | Open Dialogue Message Window; Engine Action #9 |
| `ev[07]` | `2 (Map Init)` | Player within Box [38..86, 2..130] AND Condition Check #158 | Make obj[133] Hidden (disp = 0); Warp Room -> Submap 0 at (14,1) facing 104; Open Dialogue Message Window; Show Dialogue Portrait (1, 104, 0); Dismiss Dialogue Portrait; Warp Room -> Submap 0 at (17,1) facing 104; Open Dialogue Message Window; Display Speaker Name Box (1); Engine Action #104; Open Dialogue Message Window; Display Choice Selection (1, 104); Open Dialogue Message Window; Branch on Choice (1, 104); Open Dialogue Message Window; Execute Choice Result (1); Engine Action #104; Open Dialogue Message Window; Set Story Flag (1, 104); Open Dialogue Message Window; Open Dialogue Sub-Window (1); Open Dialogue Message Window; Display Choice Selection (0, 20); Open Dialogue Message Window; Execute Choice Result (0); Open Dialogue Sub-Window (99); Open Dialogue Message Window; Engine Action #224; Mark NPC Talk Interaction Complete (Flag #0); Warp Room -> Submap 99 at (1,2); Mark NPC Talk Interaction Complete (Flag #1); Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[08]` | `1 (Action / Talk)` | Condition Check #29 AND Always Passes (Unconditional) AND Player within Box [29..0, 2..29] AND Always Passes (Unconditional) AND Story Flag 30 (bit 0) CLEAR AND Temp Event Flag #29 CLEAR AND Always Passes (Unconditional) AND Star of Destiny #29 Recruited AND Always Passes (Unconditional) AND Condition Check #32 AND Condition Check #29 AND Always Passes (Unconditional) AND Condition Check #64 AND Condition Check #29 AND Always Passes (Unconditional) AND Condition Check #128 AND Condition Check #30 AND Player within Box [1..29, 1..2] AND Condition Check #30 AND Player Y within Range [2..255] | Jump to Bytecode Offset (0, 178); Make obj[1] Hidden (disp = 0); Reset Camera Tracking (0); Screen Fade Transition (47, 73, 20); Make obj[1] Hidden (disp = 0); Screen Fade Transition (0, 9, 47); Engine Action #99; Warp Town -> Area 2 Map 255 Submap 254 at (255,254) |
| `ev[09]` | `1 (Action / Talk)` | Condition Check #30 AND Always Passes (Unconditional) AND Condition Check #31 AND Condition Check #29 AND Always Passes (Unconditional) AND Condition Check #32 AND Condition Check #29 AND Always Passes (Unconditional) AND Condition Check #64 AND Condition Check #29 AND Always Passes (Unconditional) AND Condition Check #128 AND Condition Check #29 AND Player within Box [1..29, 1..2] AND Condition Check #30 AND Player Y within Range [1..255] | Jump to Bytecode Offset (0, 178); Make obj[1] Hidden (disp = 0); Close Dialogue Window; Open Dialogue Message Window; Place Scenery Structure (47); Set Combat Battle BGM (20); Make obj[1] Hidden (disp = 0); Place Scenery Structure (0); Display Dialogue Box [Bank: 47, MsgID: 99]; Warp Town -> Area 1 Map 255 Submap 254 at (255,254) |
| `ev[10]` | `128 (Loop)` | Condition Check #30 AND Always Passes (Unconditional) AND Player within Box [5..24, 255..254] | Open Dialogue Message Window; Animate Door Open; Jump to Bytecode Offset (0, 181); Engine Action #99; Open Dialogue Message Window; Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[11]` | `128 (Loop)` | Condition Check #29 AND Always Passes (Unconditional) AND Player within Box [5..24, 255..254] | Warp Room -> Submap 101 at (0,182) facing 100; Open Dialogue Message Window; Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[12]` | `128 (Loop)` | Condition Check #30 AND Always Passes (Unconditional) AND Player Y within Range [5..25] | Open Dialogue Message Window; Show Dialogue Portrait (101, 0, 181); Engine Action #99; Open Dialogue Message Window; Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[13]` | `128 (Loop)` | Condition Check #29 AND Always Passes (Unconditional) AND Player Y within Range [5..25] | Warp Room -> Submap 101 at (0,182) facing 100; Open Dialogue Message Window; Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[14]` | `128 (Loop)` | Condition Check #30 AND Always Passes (Unconditional) AND Story Flag 5 (bit 26) CLEAR | Open Dialogue Message Window; Dismiss Dialogue Portrait; Jump to Bytecode Offset (0, 181); Engine Action #99; Open Dialogue Message Window; Exit to World Map (255, 254, 204) |
| `ev[15]` | `128 (Loop)` | Condition Check #29 AND Always Passes (Unconditional) AND Story Flag 5 (bit 26) CLEAR | Warp Room -> Submap 101 at (0,182) facing 100; Open Dialogue Message Window; Exit to World Map (255, 254, 204) |
| `ev[16]` | `128 (Loop)` | Condition Check #30 AND Always Passes (Unconditional) AND Temp Event Flag #5 CLEAR AND Treasure Byte 255 Bit 254 LOOTED | Open Dialogue Message Window; Change Portrait Expression (101); Open Dialogue Message Window; Engine Action #181; Engine Action #99; Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[17]` | `128 (Loop)` | Condition Check #29 AND Always Passes (Unconditional) AND Temp Event Flag #5 CLEAR AND Treasure Byte 255 Bit 254 LOOTED | Warp Room -> Submap 101 at (0,182) facing 100; Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[18]` | `128 (Loop)` | Condition Check #30 AND Always Passes (Unconditional) AND Star of Destiny #5 Recruited AND Treasure Byte 255 Bit 254 FRESH (Unopened) | Open Dialogue Message Window; Display Speaker Name Box (101); Open Dialogue Message Window; Engine Action #181; Engine Action #99; Open Dialogue Message Window; Dismiss Dialogue Portrait |
| `ev[19]` | `128 (Loop)` | Condition Check #29 AND Always Passes (Unconditional) AND Star of Destiny #5 Recruited AND Treasure Byte 255 Bit 254 FRESH (Unopened) | Warp Room -> Submap 101 at (0,182) facing 100; Open Dialogue Message Window; Dismiss Dialogue Portrait |
| `ev[20]` | `128 (Loop)` | Condition Check #30 AND Always Passes (Unconditional) AND Condition Check #32 AND Target Inspected is obj[29] | Open Dialogue Message Window; Display Choice Selection (101, 0); Engine Action #181; Engine Action #99; Open Dialogue Message Window; Warp Map Transition (255, 254, 204, 204, 204) |
| `ev[21]` | `128 (Loop)` | Condition Check #29 AND Always Passes (Unconditional) AND Condition Check #32 AND Target Inspected is obj[29] | Warp Room -> Submap 101 at (0,182) facing 100; Open Dialogue Message Window; Warp Map Transition (255, 254, 204, 204, 204) |
| `ev[22]` | `128 (Loop)` | Condition Check #30 AND Always Passes (Unconditional) AND Condition Check #64 AND Target Inspected is obj[30] | Open Dialogue Message Window; Branch on Choice (101, 0); Engine Action #181; Engine Action #99; Open Dialogue Message Window; Animate Doorway State (255, 254) |
| `ev[23]` | `128 (Loop)` | Condition Check #29 AND Always Passes (Unconditional) AND Condition Check #64 AND Target Inspected is obj[30] | Warp Room -> Submap 101 at (0,182) facing 100; Open Dialogue Message Window; Animate Doorway State (255, 254) |
| `ev[24]` | `128 (Loop)` | Condition Check #30 AND Always Passes (Unconditional) AND Condition Check #128 AND Target Inspected is obj[31] | Open Dialogue Message Window; Execute Choice Result (101); Open Dialogue Message Window; Engine Action #181; Engine Action #99; Open Dialogue Message Window; Engine Action #128 |
| `ev[25]` | `128 (Loop)` | Condition Check #29 AND Always Passes (Unconditional) AND Condition Check #128 AND Target Inspected is obj[31] | Warp Room -> Submap 101 at (0,182) facing 100; Open Dialogue Message Window; Engine Action #128 |
| `ev[26]` | `128 (Loop)` | Condition Check #30 AND Player within Box [1..5, 32..255] | Open Dialogue Message Window; Set Story Flag (101, 0); Engine Action #181; Engine Action #99; Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[27]` | `128 (Loop)` | Condition Check #29 AND Player within Box [1..5, 32..255] | Warp Room -> Submap 101 at (0,182) facing 100; Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[28]` | `128 (Loop)` | Condition Check #30 AND Player within Box [2..5, 33..255] | Open Dialogue Message Window; Open Dialogue Sub-Window (101); Open Dialogue Message Window; Engine Action #181; Engine Action #99; Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[29]` | `128 (Loop)` | Condition Check #29 AND Player within Box [2..5, 33..255] | Warp Room -> Submap 101 at (0,182) facing 100; Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[30]` | `1 (Action / Talk)` | Player within Box [21..27, 2..20] AND Inventory Holds Item #9 [Kindness Drops] AND Always Passes (Unconditional) | Display Dialogue Box [Bank: 0, MsgID: 28]; Place Scenery Structure (255) |
| `ev[31]` | `1 (Action / Talk)` | Player within Box [22..26, 2..32] AND Condition Check #33 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 22]; Open Shop Interface #255 |
| `ev[32]` | `1 (Action / Talk)` | Player within Box [20..24, 2..64] AND Condition Check #65 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 24]; Display Emotion Bubble (255, 254) |
| `ev[33]` | `1 (Action / Talk)` | Player within Box [20..26, 2..102] AND Condition Check #103 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 44]; Engine Action #135 |
| `ev[34]` | `1 (Action / Talk)` | Player within Box [42..46, 2..132] AND Condition Check #133 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 22]; Engine Action #99 |
| `ev[35]` | `1 (Action / Talk)` | Player within Box [60..64, 2..132] AND Condition Check #133 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 72]; Engine Action #99 |
| `ev[36]` | `1 (Action / Talk)` | Player within Box [70..74, 2..102] AND Condition Check #103 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 62]; Engine Action #135 |
| `ev[37]` | `1 (Action / Talk)` | Player within Box [78..82, 2..132] AND Condition Check #133 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 122]; Engine Action #99 |
| `ev[38]` | `1 (Action / Talk)` | Player within Box [120..124, 2..102] AND Condition Check #103 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 80]; Engine Action #135 |
| `ev[39]` | `1 (Action / Talk)` | Player within Box [120..124, 2..64] AND Condition Check #65 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 118]; Display Emotion Bubble (255, 254) |
| `ev[40]` | `1 (Action / Talk)` | Player within Box [116..120, 2..31] AND Condition Check #32 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 122]; Open Shop Interface #255 |
| `ev[41]` | `1 (Action / Talk)` | Player within Box [114..122, 2..12] AND Party Holds At Least 900 Potch AND Player X within Range [255..254] | Display Dialogue Box [Bank: 2, MsgID: 20]; Set Story Flag (255, 254) |

---

### Submap Layer `vd13_02` (Index 2)

- **Map Number (`mapno`)**: `2`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `4`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `2` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (2 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [17..23, 2..24] AND Condition Check #25 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 118]; Show Dialogue Portrait (255, 254, 204) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [43..45, 2..23] AND Treasure Byte 9 Bit 3 FRESH (Unopened) | Display Dialogue Box [Bank: 3, MsgID: 5]; Display Choice Selection (255, 254) |

---

### Submap Layer `vd13_03` (Index 3)

- **Map Number (`mapno`)**: `3`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `2` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (2 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [1..4, 2..17] AND Inventory Lacks Item #9 AND Player Y within Range [255..254] | Display Dialogue Box [Bank: 2, MsgID: 42]; Close Dialogue Sub-Window (255) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [76..80, 2..17] AND Inventory Lacks Item #9 AND Story Flag 255 (bit 254) SET | Display Dialogue Box [Bank: 4, MsgID: 14]; Clear Dialogue Sub-Window |

---

### Submap Layer `vd13_04` (Index 4)

- **Map Number (`mapno`)**: `4`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `4`)
- **Entity Count (`okaz`)**: `4` Objects | **Script Count (`evkaz`)**: `12` Scripts

#### Complete Physical Entity Inventory (4 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 19)** | `0` | `(110, 22)` | `0x0` | Frame 19 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 20)** | `0` | `(110, 22)` | `0x0` | Frame 20 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | World Device | **Mechanism (ano 19)** | `0` | `(110, 26)` | `0x0` | Frame 19 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | World Device | **Mechanism (ano 20)** | `0` | `(110, 26)` | `0x0` | Frame 20 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(110, 22)` with state parameter `19`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(110, 22)` with state parameter `20`.
- **`obj[02]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(110, 26)` with state parameter `19`.
- **`obj[03]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(110, 26)` with state parameter `20`.


#### Complete Bytecode Script Catalog (12 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Treasure Byte 10 Bit 4 FRESH (Unopened) | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[01]` | `2 (Map Init)` | Treasure Byte 10 Bit 4 LOOTED | Open Dialogue Message Window; Engine Action #9 |
| `ev[02]` | `1 (Action / Talk)` | Treasure Byte 10 Bit 4 FRESH (Unopened) AND Target Inspected is obj[8] | Make obj[1] Hidden (disp = 0); Reset Camera Tracking (0); Engine Action #9; Teleport obj[101] to (4,7); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (1); Exit to World Map (0, 20, 16); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,10) facing 4; Warp Room -> Submap 1 at (9,0) facing 8; Teleport obj[255] to (254,255) |
| `ev[03]` | `2 (Map Init)` | Treasure Byte 10 Bit 8 FRESH (Unopened) | Open Dialogue Message Window; Screen Fade Transition (255, 254, 255) |
| `ev[04]` | `2 (Map Init)` | Treasure Byte 10 Bit 8 LOOTED | Open Dialogue Message Window; Close Dialogue Window |
| `ev[05]` | `1 (Action / Talk)` | Treasure Byte 10 Bit 8 FRESH (Unopened) AND Target Inspected is obj[10] | Make obj[1] Hidden (disp = 0); Screen Fade Transition (0, 11, 47); Jump to Bytecode Offset (4, 7); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (1); Exit to World Map (0, 60, 16); Open Dialogue Message Window; Award Potch Loot (+514 Potch); Warp to Castle HQ (255, 2, 97); Screen Fade Transition (8, 255, 254); Warp to Castle HQ (46, 1, 11); Open Dialogue Message Window; Screen Fade Transition (47, 255, 254) |
| `ev[06]` | `1 (Action / Talk)` | Player within Box [11..13, 2..89] AND Condition Check #95 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 5, MsgID: 75]; Display Choice Selection (255, 254) |
| `ev[07]` | `1 (Action / Talk)` | Player within Box [33..39, 2..90] AND Condition Check #92 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 4, MsgID: 90]; Change Portrait Expression (255) |
| `ev[08]` | `1 (Action / Talk)` | Player within Box [86..94, 2..14] AND Party Formation Check AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 4, MsgID: 36]; Engine Action #88 |
| `ev[09]` | `1 (Action / Talk)` | Player within Box [86..94, 2..24] AND Condition Check #25 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 4, MsgID: 28]; Change Portrait Expression (255) |
| `ev[10]` | `1 (Action / Talk)` | Player within Box [24..32, 2..14] AND Party Formation Check AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 4, MsgID: 90]; Set Story Flag (255, 254) |
| `ev[11]` | `1 (Action / Talk)` | Player within Box [11..13, 2..23] AND Condition Check #29 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 3, MsgID: 75]; Display Choice Selection (255, 254) |

---

### Submap Layer `vd13_05` (Index 5)

- **Map Number (`mapno`)**: `5`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `2` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (2 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [76..80, 2..17] AND Inventory Lacks Item #9 AND Story Flag 255 (bit 254) SET | Display Dialogue Box [Bank: 4, MsgID: 14]; Make Object Visible (disp = 1) (255) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [1..4, 2..17] AND Inventory Lacks Item #9 AND Player Y within Range [255..254] | Display Dialogue Box [Bank: 6, MsgID: 52]; Make obj[255] Visible (disp = 1) |

---

### Submap Layer `vd13_06` (Index 6)

- **Map Number (`mapno`)**: `6`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `4`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `4` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (4 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Story Flag 86 (bit 16) SET AND Story Flag 86 (bit 32) CLEAR AND Player within Box [26..34, 2..8] AND Story Flag 9 (mask 1) SET | Warp Map Transition (3, 0, 20, 24, 255) |
| `ev[01]` | `1 (Action / Talk)` | Story Flag 86 (bit 32) SET AND Player within Box [26..34, 2..8] AND Story Flag 9 (mask 1) SET | Warp Map Transition (3, 0, 20, 65, 255) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [53..55, 2..43] AND Condition Check #49 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 5, MsgID: 5]; Display Choice Selection (255, 254) |
| `ev[03]` | `128 (Loop)` | Player within Box [7..21, 2..31] AND Condition Check #40 | Warp Room -> Submap 0 at (3,13) |

---


