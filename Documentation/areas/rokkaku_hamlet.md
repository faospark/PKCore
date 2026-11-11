# Suikoden II Geographic Area Catalog: Rokkaku Hamlet

**Geographic Scope & Role**: Secret ninja sanctuary hidden deep within Banner Pass; traditional Japanese houses with irori hearths, training grounds, Lord Hanzo's residence, and recruitment grounds for Mondo and Sasuke.

**Regional Category**: Region `VF` | **Master Maps Included**: `vf01`

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

## Location Map: `vf01`

- **Master Map Container**: `vf01.json`
- **Submap Layer Files**: vf01_00.json, vf01_01.json, vf01_02.json, vf01_03.json, vf01_04.json, vf01_05.json, vf01_06.json, vf01_07.json, vf01_08.json, vf01_09.json, vf01_10.json, vf01_11.json, vf01_12.json, vf01_13.json, vf01_14.json
- **Collision Grid Files**: vf01_map_00.json, vf01_map_02.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 6

### Submap Layer `vf01_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `11` Objects | **Script Count (`evkaz`)**: `27` Scripts

#### Complete Physical Entity Inventory (11 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Sasuke** | `62` | `(17, 15)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 128 | 0 |
| `obj[01]` | Prop / Scenery | **Prop ID 64515** | `64515` | `(89, 12)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 3 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Actor ID 64806** | `64806` | `(76, 25)` | `15x5` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[03]` | NPC / Actor | **Actor ID 64802** | `64802` | `(125, 20)` | `5x2` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[04]` | NPC / Actor | **Actor ID 64801** | `64801` | `(29, 23)` | `3x3` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[05]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(29, 18)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(31, 20)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(50, 22)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(53, 16)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(55, 16)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(71, 19)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Sasuke)**: Positioned at tile `(17, 15)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Prop: Object 64515)**: Environmental world dressing prop placed at tile `(89, 12)`. Solid collision is set to `0`.
- **`obj[02]` (Object 64806)**: Positioned at tile `(76, 25)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Object 64802)**: Positioned at tile `(125, 20)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Object 64801)**: Positioned at tile `(29, 23)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(29, 18)` to `(30, 19)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[06]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(31, 20)` to `(32, 21)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[07]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(50, 22)` to `(51, 23)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[08]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(53, 16)` to `(54, 17)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[09]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(55, 16)` to `(56, 17)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[10]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(71, 19)` to `(74, 20)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (27 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Open Dialogue Sub-Window (3); Open Dialogue Message Window |
| `ev[01]` | `1 (Action / Talk)` | Target Inspected is obj[11] AND Story Flag 49 (bit 4) CLEAR | Open Dialogue Sub-Window (3); Warp Room -> Submap 4 at (7,101) facing 4; Pan Camera (30, 2, 4); Open Dialogue Message Window; Show Dialogue Portrait (32, 0, 41); Warp Town -> Area 2 Map 3 Submap 255 at (2,9); Set Entity Movement Speed (4, 255); Warp to Castle HQ (255, 254, 255) |
| `ev[02]` | `1 (Action / Talk)` | Target Inspected is obj[11] AND Story Flag 49 (bit 4) SET | Open Dialogue Sub-Window (3); Engine Action #5 |
| `ev[03]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Open Dialogue Sub-Window (3); Engine Action #9 |
| `ev[04]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Open Dialogue Sub-Window (4); Open Dialogue Message Window |
| `ev[05]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Open Dialogue Sub-Window (4); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[06]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Open Dialogue Sub-Window (4); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[07]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Open Dialogue Sub-Window (4); Warp to Castle HQ (255, 254, 204) |
| `ev[08]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Open Dialogue Sub-Window (4); Exit to World Map (255, 254, 204) |
| `ev[09]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Open Dialogue Sub-Window (4); Engine Action #5 |
| `ev[10]` | `2 (Map Init)` | Story Flag 68 (bit 4) SET AND Condition Check #24 AND Condition Check #62 AND Player Y within Range [255..254] | Make obj[2] Hidden (disp = 0); Reset Camera Tracking (58); Display Choice Selection (0, 8); Teleport obj[255] to (254,255) |
| `ev[11]` | `128 (Loop)` | Player within Box [8..18, 2..3] AND Active Party Has Character #255 | Warp Room -> Submap 1 at (5,5) |
| `ev[12]` | `1 (Action / Talk)` | Player within Box [8..18, 2..5] AND Inventory Holds Item #9 [Kindness Drops] AND Player X within Range [255..254] | Warp Map Transition (2, 4, 45, 118, 255) |
| `ev[13]` | `1 (Action / Talk)` | Player within Box [113..119, 2..9] AND Story Flag 9 (mask 1) CLEAR | Jump to Bytecode Offset (21, 5); Display Dialogue Box [Bank: 1, MsgID: 20]; Close Dialogue Sub-Window (255) |
| `ev[14]` | `1 (Action / Talk)` | Player within Box [45..47, 2..22] AND Condition Check #23 AND Story Flag 1 (mask 255) SET | Jump to Bytecode Offset (21, 5); Engine Action #5; Open Dialogue Message Window; Warp Room -> Submap 30 at (12,2) facing 48; Engine Action #44 |
| `ev[15]` | `1 (Action / Talk)` | Player within Box [61..63, 2..18] AND Character #9 Level >= 1 | Jump to Bytecode Offset (21, 5); Engine Action #5; Open Dialogue Message Window; Warp Room -> Submap 30 at (12,3) facing 84; Make obj[255] Hidden (disp = 0) |
| `ev[16]` | `1 (Action / Talk)` | Story Flag 68 (bit 4) CLEAR AND Condition Check #24 AND Condition Check #63 AND Player Y within Range [24..62] AND Player Y within Range [3..151] AND Condition Check #64 | Recruit Character into Active Party (24 [Milie], 8); Open Dialogue Message Window; Open Dialogue Message Window; Set Combat Battle BGM (20); Wait for Audio / Window Sync (3); Close Dialogue Window; Exit to World Map (2, 60, 101); Open Dialogue Message Window; Engine Action #177; Warp Map Transition (2, 3, 105, 37, 255) |
| `ev[17]` | `1 (Action / Talk)` | Story Flag 68 (bit 4) CLEAR AND Condition Check #24 AND Condition Check #63 AND Player Y within Range [24..62] AND Player Y within Range [4..151] AND Condition Check #64 | Recruit Character into Active Party (84 [Bonaparte], 62); Dismiss Emotion Bubble (84); Engine Action #63; Dismiss Emotion Bubble (24); Reset Camera Tracking (0); Open Dialogue Message Window; Set Combat Battle BGM (20); Wait for Audio / Window Sync (3); Close Dialogue Window; Exit to World Map (2, 60, 101); Open Dialogue Message Window; Engine Action #177; Display Dialogue Box [Bank: 5, MsgID: 40]; Engine Action #88 |
| `ev[18]` | `1 (Action / Talk)` | Story Flag 68 (bit 4) SET AND Star of Destiny #0 Recruited AND Condition Check #73 AND Condition Check #24 AND Condition Check #62 AND Player Y within Range [5..8] | Open Dialogue Sub-Window (0); Fade Out to Black (255) |
| `ev[19]` | `1 (Action / Talk)` | Story Flag 68 (bit 4) SET AND Star of Destiny #1 Recruited AND Condition Check #73 AND Condition Check #24 AND Condition Check #62 AND Player Y within Range [5..8] | Recruit Character into Active Party (23 [Hanna], 0); Display Chapter Text (48); Open Dialogue Message Window; Reset Camera Tracking (3); Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 9 Map 33 Submap 1 at (73,0); Warp Room -> Submap 0 at (1,48) facing West (Left); Reset Camera Tracking (3); Warp Town -> Area 1 Map 0 Submap 8 at (3,1); Warp Town -> Area 3 Map 8 Submap 3 at (24,1); Open Dialogue Message Window; Display Emotion Bubble (73, 20); Warp to Castle HQ (8, 2, 24); Reset Camera Tracking (0); Dismiss Emotion Bubble (73); Branch on Choice (24, 1); Open Dialogue Message Window; Warp Room -> Submap 73 at (50,3); Reset Camera Tracking (0); Set Combat Battle BGM (10); Warp to Castle HQ (8, 3, 73); Dismiss Emotion Bubble (24); Reset Camera Tracking (0); Warp Map Transition (24, 1, 0, 33, 73); Branch on Choice (84, 62); Warp Room -> Submap 115 at (62,38); Set Combat Battle BGM (20); Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 101, 4); Engine Action #6; Engine Action #5; Open Dialogue Message Window; Warp Town -> Area 0 Map 5 Submap 3 at (1,0); Engine Action #5; Warp to Castle HQ (3, 0, 5); Warp to Castle HQ (0, 0, 5); Warp to Castle HQ (30, 89, 0); Warp Town -> Area 8 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Engine Action #89; Open Dialogue Message Window; Warp Town -> Area 9 Map 5 Submap 0 at (6,2); Dismiss Emotion Bubble (89); Open Dialogue Message Window; Warp Town -> Area 10 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Dismiss Emotion Bubble (1); Warp Room -> Submap 5 at (0,0) facing South (Down); Engine Action #5; Show Dialogue Portrait (1, 0, 30); Close Dialogue Sub-Window (8); Open Dialogue Message Window; Return Warp to Castle Base (73, 20); Set Entity Movement Speed (2, 101); Open Dialogue Message Window; Engine Action #176; Engine Action #94; Warp Room -> Submap 8 at (20,255) facing 254; Walk obj[1] to (8,73); Trigger Character Emotion Effect (24, 1); Open Dialogue Message Window; Start Boss Battle #48 (BGM: 1); Open Dialogue Message Window; Warp to Castle HQ (0, 1, 0); Engine Action #9; Warp Room -> Submap 58 at (255,254) facing 255 |
| `ev[20]` | `1 (Action / Talk)` | Player within Box [44..44, 2..22] AND Condition Check #23 AND Story Flag 1 (mask 255) SET | Engine Action #5; Open Dialogue Message Window; Warp to Castle HQ (1, 30, 101); Execute Choice Result (5); Engine Action #5; Open Dialogue Message Window; Warp Room -> Submap 30 at (12,2) facing 48; Engine Action #44 |
| `ev[21]` | `1 (Action / Talk)` | Player within Box [44..44, 2..22] AND Condition Check #23 AND Story Flag 3 (mask 255) SET | Engine Action #5; Open Dialogue Message Window; Warp to Castle HQ (1, 30, 101); Execute Choice Result (5); Engine Action #5; Open Dialogue Message Window; Warp Room -> Submap 30 at (12,2) facing 48; Engine Action #44 |
| `ev[22]` | `1 (Action / Talk)` | Player within Box [48..48, 2..22] AND Condition Check #23 AND Story Flag 1 (mask 255) SET | Engine Action #5; Open Dialogue Message Window; Warp Town -> Area 1 Map 30 Submap 101 at (21,5); Engine Action #5; Open Dialogue Message Window; Warp Room -> Submap 30 at (12,2) facing 48; Engine Action #44 |
| `ev[23]` | `1 (Action / Talk)` | Player within Box [60..60, 2..18] AND Character #9 Level >= 1 | Engine Action #5; Open Dialogue Message Window; Warp to Castle HQ (1, 30, 101); Execute Choice Result (5); Engine Action #5; Open Dialogue Message Window; Warp Room -> Submap 30 at (12,3) facing 84; Make obj[255] Hidden (disp = 0) |
| `ev[24]` | `1 (Action / Talk)` | Player within Box [60..60, 2..18] AND Character #9 Level >= 3 | Engine Action #5; Open Dialogue Message Window; Warp to Castle HQ (1, 30, 101); Execute Choice Result (5); Engine Action #5; Open Dialogue Message Window; Warp Room -> Submap 30 at (12,3) facing 84; Make obj[255] Hidden (disp = 0) |
| `ev[25]` | `1 (Action / Talk)` | Player within Box [64..64, 2..18] AND Character #9 Level >= 1 | Engine Action #5; Open Dialogue Message Window; Warp Town -> Area 1 Map 30 Submap 101 at (21,5); Engine Action #5; Open Dialogue Message Window; Warp Room -> Submap 30 at (12,3) facing 84; Make obj[255] Hidden (disp = 0) |
| `ev[26]` | `1 (Action / Talk)` | Player within Box [64..64, 2..18] AND Character #9 Level >= 2 | Engine Action #5; Open Dialogue Message Window; Warp Town -> Area 1 Map 30 Submap 101 at (21,5); Engine Action #5; Open Dialogue Message Window; Warp Room -> Submap 30 at (12,3) facing 84; Make obj[255] Hidden (disp = 0) |

---

### Submap Layer `vf01_01` (Index 1)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `1` Objects | **Script Count (`evkaz`)**: `3` Scripts

#### Complete Physical Entity Inventory (1 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 64798** | `64798` | `(11, 20)` | `8x0` | East (Right) | Visible (1) | Special (3) | 2 | 128 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 64798)**: Positioned at tile `(11, 20)`, facing East (Right). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.


#### Complete Bytecode Script Catalog (3 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Target Inspected is obj[8] | Open Dialogue Sub-Window (3); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [17..23, 2..27] AND Condition Check #30 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 116]; Place Scenery Structure (255) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [17..23, 2..12] AND Party Holds At Least 900 Potch AND Player X within Range [255..254] | Display Dialogue Box [Bank: 5, MsgID: 40]; Engine Action #120 |

---

### Submap Layer `vf01_02` (Index 2)

- **Map Number (`mapno`)**: `2`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `3` Objects | **Script Count (`evkaz`)**: `3` Scripts

#### Complete Physical Entity Inventory (3 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | Prop / Scenery | **Prop ID 64514** | `64514` | `(51, 30)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 3 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Actor ID 64519** | `64519` | `(42, 39)` | `0x0` | Up (North) | Visible (1) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Actor ID 64805** | `64805` | `(36, 33)` | `0x0` | West (Left) | Visible (1) | Solid (Obstacle) | 3 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Prop: Object 64514)**: Environmental world dressing prop placed at tile `(51, 30)`. Solid collision is set to `0`.
- **`obj[01]` (Object 64519)**: Positioned at tile `(42, 39)`, facing Up (North). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Object 64805)**: Positioned at tile `(36, 33)`, facing West (Left). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.


#### Complete Bytecode Script Catalog (3 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Open Dialogue Sub-Window (3); Warp Town -> Area 73 Map 20 Submap 3 at (9,2) |
| `ev[01]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Open Dialogue Sub-Window (3); Reset Camera Tracking (73); Branch on Choice (3, 10); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [46..50, 2..48] AND Condition Check #49 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 46]; Close Dialogue Sub-Window (255) |

---

### Submap Layer `vf01_03` (Index 3)

- **Map Number (`mapno`)**: `2`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `2` Objects | **Script Count (`evkaz`)**: `4` Scripts

#### Complete Physical Entity Inventory (2 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 64518** | `64518` | `(94, 39)` | `0x0` | East (Right) | Visible (1) | Solid (Obstacle) | 2 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Actor ID 64519** | `64519` | `(102, 39)` | `0x0` | Up (North) | Visible (1) | Solid (Obstacle) | 2 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 64518)**: Positioned at tile `(94, 39)`, facing East (Right). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Object 64519)**: Positioned at tile `(102, 39)`, facing Up (North). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.


#### Complete Bytecode Script Catalog (4 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Target Inspected is obj[8] | Open Dialogue Sub-Window (3); Screen Fade Transition (73, 20, 3); Reset Camera Tracking (3) |
| `ev[01]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Open Dialogue Sub-Window (3); Close Dialogue Window; Set Combat Battle BGM (20); Warp to Castle HQ (9, 2, 255) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [82..86, 2..50] AND Condition Check #51 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 62]; Branch on Choice (255, 254) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [81..83, 2..39] AND Condition Check #40 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 4, MsgID: 82]; Engine Action #88 |

---

### Submap Layer `vf01_04` (Index 4)

- **Map Number (`mapno`)**: `2`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `3` Objects | **Script Count (`evkaz`)**: `8` Scripts

#### Complete Physical Entity Inventory (3 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 64517** | `64517` | `(98, 84)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Actor ID 64803** | `64803` | `(107, 93)` | `3x3` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[02]` | NPC / Actor | **Actor ID 64521** | `64521` | `(107, 89)` | `0x0` | Up (North) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 64517)**: Positioned at tile `(98, 84)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Object 64803)**: Positioned at tile `(107, 93)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Object 64521)**: Positioned at tile `(107, 89)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.


#### Complete Bytecode Script Catalog (8 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #102 AND Player Y within Range [255..254] | Open Dialogue Message Window; Screen Fade Transition (255, 254, 204) |
| `ev[01]` | `1 (Action / Talk)` | Target Inspected is obj[9] AND Story Flag 49 (bit 8) CLEAR | Open Dialogue Sub-Window (3); Warp to Castle HQ (101, 4, 7); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (2); Exit to World Map (0, 25, 80); Open Dialogue Message Window; Award Potch Loot (+514 Potch); Warp to Castle HQ (255, 2, 9); Set Entity Movement Speed (8, 255); Warp to Castle HQ (255, 254, 255) |
| `ev[02]` | `1 (Action / Talk)` | Target Inspected is obj[9] AND Story Flag 49 (bit 8) SET | Open Dialogue Sub-Window (3); Engine Action #6 |
| `ev[03]` | `1 (Action / Talk)` | Target Inspected is obj[10] AND Story Flag 49 (bit 16) CLEAR AND Party Member Count == 1 AND Condition Check #30 | Open Dialogue Sub-Window (3); Exit to World Map (73, 20, 40); Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 3 Map 13 Submap 3 at (14,41); Warp Town -> Area 0 Map 1 Submap 255 at (0,24); Screen Fade Transition (3, 15, 101); Exit to World Map (7, 101, 4); Pan Camera (30, 2, 4); Open Dialogue Message Window; Engine Action #6; Turn obj[0] facing 41; Warp Town -> Area 2 Map 3 Submap 255 at (2,9); Set Entity Movement Speed (16, 255); Warp to Castle HQ (255, 254, 107); Warp Room -> Submap 3 at (10,2) facing 255; Warp Room -> Submap 10 at (3,16) facing East (Right); Screen Fade Transition (2, 255, 254) |
| `ev[04]` | `1 (Action / Talk)` | Target Inspected is obj[10] AND Story Flag 49 (bit 16) CLEAR AND Party Member Count == 0 AND Condition Check #30 | Open Dialogue Sub-Window (3); Exit to World Map (73, 20, 40); Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 3 Map 13 Submap 3 at (14,41); Warp Town -> Area 0 Map 1 Submap 255 at (0,24); Screen Fade Transition (3, 21, 3); Screen Fade Transition (2, 255, 254); Warp Room -> Submap 10 at (3,16) facing East (Right); Screen Fade Transition (2, 255, 254) |
| `ev[05]` | `1 (Action / Talk)` | Target Inspected is obj[10] AND Story Flag 49 (bit 16) SET | Open Dialogue Sub-Window (3); Pan Camera (3, 10, 2) |
| `ev[06]` | `1 (Action / Talk)` | Target Inspected is obj[8] | Clear Story Milestone Flag 31 (mask 8); Warp Room -> Submap 3 at (20,2) facing 12; Exit to World Map (255, 254, 204) |
| `ev[07]` | `1 (Action / Talk)` | Player within Box [81..83, 2..83] AND Condition Check #84 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 3, MsgID: 82]; Start Boss Battle #255 (BGM: 254) |

---

### Submap Layer `vf01_05` (Index 5)

- **Map Number (`mapno`)**: `2`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `4` Objects | **Script Count (`evkaz`)**: `7` Scripts

#### Complete Physical Entity Inventory (4 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 64983** | `64983` | `(40, 83)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Mondo** | `63` | `(43, 81)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 5 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Sasuke** | `62` | `(37, 81)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 5 | 255 | 0 |
| `obj[03]` | Trigger / Hitbox | **Hitbox Zone (2x3)** | `0` | `(40, 83)` | `1x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 64983)**: Positioned at tile `(40, 83)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Mondo)**: Positioned at tile `(43, 81)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Sasuke)**: Positioned at tile `(37, 81)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `3` tiles high from `(40, 83)` to `(41, 85)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (7 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Condition Check #24 AND Condition Check #63 AND Player Y within Range [24..62] AND Player Y within Range [255..254] | Make obj[0] Hidden (disp = 0); Engine Action #9; Open Dialogue Message Window; Screen Fade Transition (3, 0, 1); Teleport obj[255] to (254,255) |
| `ev[01]` | `128 (Loop)` | Inventory Holds Item #1 [Medicine] | Close Dialogue Window; Exit to World Map (2, 60, 37); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[02]` | `1 (Action / Talk)` | Story Flag 68 (bit 4) CLEAR AND Star of Destiny #0 Recruited AND Condition Check #73 AND Condition Check #24 AND Condition Check #63 AND Player Y within Range [24..62] AND Player Y within Range [255..254] | Recruit Character into Active Party (73 [Kasumi], 30); Close Dialogue Window; Warp to Castle HQ (2, 60, 24); Reset Camera Tracking (0); Warp Room -> Submap 20 at (111,41) facing 5; Open Dialogue Message Window; Open Dialogue Message Window; Open Dialogue Message Window; Open Dialogue Message Window; Warp Room -> Submap 0 at (5,8) facing 4; Exit to World Map (0, 2, 30); Close Dialogue Sub-Window (8); Open Dialogue Message Window; Warp Town -> Area 73 Map 20 Submap 24 at (9,0); Warp to Castle HQ (73, 20, 48); Engine Action #9; Open Dialogue Message Window; Warp to Castle HQ (0, 1, 2); Engine Action #9; Warp to Castle HQ (9, 0, 69); Warp to Castle HQ (36, 1, 73); Dismiss Emotion Bubble (101); Open Dialogue Message Window; Engine Action #177; Set Combat Battle BGM (80); Engine Action #54; Open Dialogue Message Window; Warp Room -> Submap 70 at (2,32) facing Up (North); Warp to Castle HQ (105, 37, 58); Warp Room -> Submap 8 at (4,4) facing South (Down); Warp Town -> Area 30 Map 24 Submap 8 at (0,36); Set Combat Battle BGM (60); Set Combat Battle BGM (20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 0 Map 37 Submap 0 at (38,73); Branch on Choice (41, 2); Warp Town -> Area 3 Map 255 Submap 2 at (24,8); Open Dialogue Message Window; Award Potch Loot (+18,708 Potch); Turn obj[8] facing South (Down); Warp Town -> Area 0 Map 1 Submap 2 at (8,3); Reset Camera Tracking (0); Set Combat Battle BGM (6); Warp to Castle HQ (0, 1, 73); Dismiss Emotion Bubble (48); Reset Camera Tracking (0); Warp Town -> Area 3 Map 1 Submap 0 at (8,3); Reset Camera Tracking (3); Set Combat Battle BGM (6); Warp to Castle HQ (0, 2, 73); Dismiss Emotion Bubble (24); Reset Camera Tracking (0); Engine Action #44; Set Combat Battle BGM (20); Warp to Castle HQ (0, 1, 24); Engine Action #9; Open Dialogue Message Window; Make obj[84] Visible (disp = 1); Engine Action #63; Warp Room -> Submap 115 at (63,38); Set Combat Battle BGM (20); Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 101, 4); Engine Action #6; Engine Action #5; Open Dialogue Message Window; Warp Town -> Area 0 Map 5 Submap 3 at (1,0); Engine Action #5; Warp to Castle HQ (3, 0, 5); Warp to Castle HQ (0, 0, 5); Warp to Castle HQ (30, 89, 0); Warp Town -> Area 8 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Engine Action #89; Open Dialogue Message Window; Warp Town -> Area 9 Map 5 Submap 0 at (6,2); Dismiss Emotion Bubble (89); Open Dialogue Message Window; Warp Town -> Area 10 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Dismiss Emotion Bubble (1); Warp Room -> Submap 5 at (0,0) facing South (Down); Engine Action #5; Show Dialogue Portrait (1, 0, 30); Close Dialogue Sub-Window (10); Open Dialogue Message Window; Make obj[84] Hidden (disp = 0); Engine Action #62; Warp Room -> Submap 115 at (62,38); Set Combat Battle BGM (20); Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 101, 4); Engine Action #6; Engine Action #5; Open Dialogue Message Window; Warp Town -> Area 0 Map 5 Submap 3 at (1,0); Engine Action #5; Warp to Castle HQ (3, 0, 5); Warp to Castle HQ (0, 0, 5); Warp to Castle HQ (30, 89, 0); Warp Town -> Area 8 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Engine Action #89; Open Dialogue Message Window; Warp Town -> Area 9 Map 5 Submap 0 at (6,2); Dismiss Emotion Bubble (89); Open Dialogue Message Window; Warp Town -> Area 10 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Dismiss Emotion Bubble (1); Warp Room -> Submap 5 at (0,0) facing South (Down); Engine Action #5; Show Dialogue Portrait (1, 0, 30); Set Combat Battle BGM (40); Close Dialogue Sub-Window (9); Open Dialogue Message Window; Teleport obj[73] to (20,49); Warp Town -> Area 94 Map 1 Submap 1 at (9,20); Warp Room -> Submap 255 at (254,101) facing South (Down); Engine Action #176; Engine Action #94; Warp Room -> Submap 10 at (20,1) facing 10; Walk obj[73] to (40,3); Open Dialogue Message Window; Warp Town -> Area 24 Map 8 Submap 0 at (48,73); Branch on Choice (58, 255); Warp to Castle HQ (24, 8, 0); Engine Action #39; Set Combat Battle BGM (20); Close Dialogue Sub-Window (9); Open Dialogue Message Window; Engine Action #40; Set Combat Battle BGM (20); Turn obj[9] facing South (Down); Warp to Castle HQ (0, 1, 2); Engine Action #9; Warp to Castle HQ (9, 0, 69); Warp to Castle HQ (36, 1, 73); Dismiss Emotion Bubble (101); Open Dialogue Message Window; Engine Action #177; Engine Action #54; Open Dialogue Message Window; Warp Room -> Submap 70 at (2,32) facing Up (North); Warp to Castle HQ (105, 37, 58) |
| `ev[03]` | `1 (Action / Talk)` | Story Flag 68 (bit 4) CLEAR AND Star of Destiny #1 Recruited AND Condition Check #73 AND Condition Check #24 AND Condition Check #63 AND Player Y within Range [24..62] AND Player Y within Range [255..254] | Recruit Character into Active Party (33 [Camus], 1); Set Combat Battle BGM (73); Dismiss Emotion Bubble (11); Warp to Castle HQ (2, 60, 24); Reset Camera Tracking (0); Warp Room -> Submap 20 at (111,41) facing 5; Exit to World Map (4, 4, 5); Engine Action #5; Exit to World Map (5, 8, 4); Exit to World Map (0, 2, 30); Close Dialogue Sub-Window (8); Open Dialogue Message Window; Warp Town -> Area 73 Map 20 Submap 24 at (9,0); Warp to Castle HQ (73, 20, 48); Engine Action #9; Open Dialogue Message Window; Warp to Castle HQ (0, 1, 2); Engine Action #9; Warp to Castle HQ (9, 0, 69); Warp to Castle HQ (73, 30, 11); Exit to World Map (2, 60, 101); Open Dialogue Message Window; Engine Action #177; Engine Action #54; Open Dialogue Message Window; Warp Room -> Submap 70 at (2,32) facing Up (North); Warp to Castle HQ (105, 37, 58); Engine Action #5; Open Dialogue Message Window; Warp Room -> Submap 1 at (0,3) facing Up (North); Warp Room -> Submap 9 at (3,1) facing West (Left); Close Dialogue Sub-Window (1); Open Dialogue Message Window; Exit to World Map (77, 10, 6); Warp Town -> Area 30 Map 24 Submap 10 at (0,5); Close Dialogue Sub-Window (8); Open Dialogue Message Window; Engine Action #6; Set Combat Battle BGM (20); Close Dialogue Sub-Window (1); Open Dialogue Message Window; Pan Camera (73, 60, 24); Reset Camera Tracking (0); Reset Camera Tracking (73); Branch on Choice (24, 1); Open Dialogue Message Window; Engine Action #9; Set Combat Battle BGM (90); Close Dialogue Sub-Window (8); Open Dialogue Message Window; Screen Fade Transition (73, 20, 24); Warp Room -> Submap 11 at (73,60) facing 24; Reset Camera Tracking (0); Display Dialogue Box [Bank: 48, MsgID: 8]; Open Dialogue Message Window; Warp Town -> Area 0 Map 1 Submap 2 at (8,1); Close Dialogue Window; Warp to Castle HQ (8, 0, 73); Engine Action #6; Warp to Castle HQ (0, 1, 73); Dismiss Emotion Bubble (48); Reset Camera Tracking (0); Warp Town -> Area 3 Map 1 Submap 0 at (8,3); Reset Camera Tracking (3); Set Combat Battle BGM (6); Warp to Castle HQ (0, 2, 3); Warp Room -> Submap 73 at (30,24) facing 8; Open Dialogue Message Window; Place Scenery Structure (73); Trigger Character Emotion Effect (3, 8); Warp Room -> Submap 30 at (3,0) facing West (Left); Warp to Castle HQ (1, 1, 24); Reset Camera Tracking (0); Animate Door Open; Set Combat Battle BGM (20); Close Dialogue Sub-Window (9); Open Dialogue Message Window; Show Dialogue Portrait (84, 63, 31); Engine Action #115; Engine Action #63; Open Save Crystal Menu (MSaveInit); Set Combat Battle BGM (20); Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 101, 4); Engine Action #6; Engine Action #5; Open Dialogue Message Window; Warp Town -> Area 0 Map 5 Submap 3 at (1,0); Engine Action #5; Warp to Castle HQ (3, 0, 5); Warp to Castle HQ (0, 0, 5); Warp to Castle HQ (30, 89, 0); Warp Town -> Area 8 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Engine Action #89; Open Dialogue Message Window; Warp Town -> Area 9 Map 5 Submap 0 at (6,2); Dismiss Emotion Bubble (89); Open Dialogue Message Window; Warp Town -> Area 10 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Dismiss Emotion Bubble (1); Warp Room -> Submap 5 at (0,0) facing South (Down); Engine Action #5; Show Dialogue Portrait (1, 0, 30); Set Combat Battle BGM (20); Warp to Castle HQ (9, 2, 24); Engine Action #9; Open Dialogue Message Window; Dismiss Dialogue Portrait; Load Sound Bank into Memory (1, 10); Engine Action #6; Award Potch Currency (10,6); Warp to Castle HQ (30, 3, 10); Warp to Castle HQ (73, 10, 72); Open Dialogue Message Window; Screen Fade Transition (24, 10, 0); Change Portrait Expression (73); Branch on Choice (49, 2); Jump to Bytecode Offset (0, 176); Engine Action #94; Warp Room -> Submap 10 at (20,255) facing 254; Walk obj[1] to (10,73); Dismiss Emotion Bubble (24); Engine Action #9; Open Dialogue Message Window; Display Speaker Name Box (73); Branch on Choice (24, 1); Open Dialogue Message Window; Display Choice Selection (73, 20); Warp to Castle HQ (9, 0, 73); Branch on Choice (24, 9); Open Dialogue Message Window; Branch on Choice (73, 30); Close Dialogue Sub-Window (8); Open Dialogue Message Window; Execute Choice Result (73); Branch on Choice (24, 9); Open Dialogue Message Window; Set Story Flag (73, 20); Set Combat Battle BGM (20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 0 Map 23 Submap 0 at (24,73); Branch on Choice (9, 68); Exit to World Map (41, 2, 6); Pan Camera (255, 6, 24); Engine Action #9; Open Dialogue Message Window; Clear Dialogue Sub-Window; Set Combat Battle BGM (20); Set Entity Movement Speed (2, 48); Warp Room -> Submap 3 at (0,1) facing South (Down); Engine Action #9; Warp Room -> Submap 255 at (254,48) facing 9; Open Dialogue Message Window; Warp to Castle HQ (0, 1, 0); Engine Action #9; Warp Room -> Submap 255 at (254,50) facing 34; Engine Action #85; Warp Room -> Submap 4 at (0,1) facing 63; Warp Room -> Submap 255 at (254,255) facing 7; Close Dialogue Sub-Window (9); Open Dialogue Message Window; Fade In from Black (73); Branch on Choice (49, 2); Jump to Bytecode Offset (0, 176); Engine Action #94; Warp Room -> Submap 9 at (20,255) facing 254; Walk obj[1] to (9,48); Warp Room -> Submap 3 at (0,1) facing South (Down); Engine Action #9; Warp Room -> Submap 58 at (255,254) facing 255 |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [36..44, 2..123] AND Condition Check #130 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 20]; Dismiss Dialogue Portrait |
| `ev[05]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Close Dialogue Sub-Window (8); Warp to Castle HQ (17, 255, 254) |
| `ev[06]` | `1 (Action / Talk)` | Target Inspected is obj[8] | Close Dialogue Sub-Window (8); Warp to Castle HQ (18, 255, 254) |

---
