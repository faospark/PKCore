# Suikoden II Geographic Area Catalog: Swallow Pass & Highland Border Gate

**Geographic Scope & Role**: The forest path between Ryube and Toto; bird nests (Shiro and Kinnison), heavy forest thickets, and the fortified Highland border gate.

**Regional Category**: Region `VB` | **Master Maps Included**: `vb07`, `vb08`, `vb17`

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

## Location Map: `vb07`

- **Master Map Container**: `vb07.json`
- **Submap Layer Files**: vb07_00.json, vb07_01.json, vb07_02.json, vb07_04.json, vb07_05.json
- **Collision Grid Files**: vb07_map_00.json
- **Sprite Animation Bundles**: vb07_00_obj.json
- **Submap Room Count**: 6

### Submap Layer `vb07_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `50`, Rate: `4`)
- **Entity Count (`okaz`)**: `12` Objects | **Script Count (`evkaz`)**: `36` Scripts

#### Complete Physical Entity Inventory (12 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Mukumuku** | `30` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Shiro** | `26` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | Prop / Scenery | **Shiro** | `26` | `(0, 0)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | Prop / Scenery | **Prop ID 33050** | `33050` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[04]` | NPC / Actor | **Luca Blight** | `83` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[05]` | World Device | **Mechanism (ano 21)** | `0` | `(39, 13)` | `0x0` | Frame 21 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[06]` | World Device | **Mechanism (ano 22)** | `0` | `(39, 23)` | `0x0` | Frame 22 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[07]` | World Device | **Mechanism (ano 23)** | `0` | `(40, 23)` | `0x0` | Frame 23 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[08]` | Prop / Scenery | **Prop ID 39937** | `39937` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Trigger / Hitbox | **Hitbox Zone (3x4)** | `0` | `(40, 20)` | `2x3` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Trigger / Hitbox | **Hitbox Zone (7x2)** | `0` | `(41, 24)` | `6x1` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Trigger / Hitbox | **Hitbox Zone (3x5)** | `0` | `(43, 20)` | `2x4` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Mukumuku)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Shiro)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Prop: Shiro)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[03]` (Prop: Object 33050)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `2`.
- **`obj[04]` (Luca Blight)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(39, 13)` with state parameter `21`.
- **`obj[06]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(39, 23)` with state parameter `22`.
- **`obj[07]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(40, 23)` with state parameter `23`.
- **`obj[08]` (Prop: Object 39937)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[09]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `4` tiles high from `(40, 20)` to `(42, 23)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[10]` (Hitbox Zone)**: Bounding trigger area covering `7` tiles wide by `2` tiles high from `(41, 24)` to `(47, 25)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[11]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `5` tiles high from `(43, 20)` to `(45, 24)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (36 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Player within Box [36..36, 2..105] AND Condition Check #105 | Make obj[86] Hidden (disp = 0); Warp Room -> Submap 0 at (48,83) facing 47 |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [28..28, 2..8] AND Temp Event Flag #7 CLEAR AND Player Y within Range [255..254] | Engine Action #54; Open Dialogue Message Window; Warp Town -> Area 11 Map 1 Submap 2 at (40,255) |
| `ev[02]` | `128 (Loop)` | Temp Event Flag #2 SET | Engine Action #93; Open Dialogue Message Window; Place Scenery Structure (30); Launch Tactical War Battle (2) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [30..50, 2..106] AND Condition Check #107 AND Story Flag 0 (mask 255) SET | Warp Map Transition (3, 0, 115, 9, 255) |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [97..99, 2..25] AND Condition Check #38 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 3]; Clear Dialogue Sub-Window |
| `ev[05]` | `1 (Action / Talk)` | Player within Box [20..40, 2..4] AND Inventory Holds Item #9 AND Player X within Range [255..254] | Display Dialogue Box [Bank: 3, MsgID: 66]; Set Special Scene BGM (255) |
| `ev[06]` | `128 (Loop)` | Story Flag 167 (bit 128) CLEAR AND Player within Box [76..78, 2..59] AND Condition Check #60 AND Story Flag 0 (mask 255) SET | Warp Room -> Submap 0 at (1,4) |
| `ev[07]` | `128 (Loop)` | Story Flag 167 (bit 128) CLEAR AND Player Y within Range [99..102] AND Story Flag 0 (mask 255) SET | Warp Room -> Submap 0 at (1,4) |
| `ev[08]` | `128 (Loop)` | Story Flag 167 (bit 128) SET AND Story Flag 168 (bit 2) CLEAR AND Player within Box [76..78, 2..59] AND Condition Check #60 AND Story Flag 0 (mask 255) SET | Warp Room -> Submap 0 at (1,15) |
| `ev[09]` | `128 (Loop)` | Story Flag 167 (bit 128) SET AND Story Flag 168 (bit 2) CLEAR AND Player Y within Range [99..102] AND Story Flag 0 (mask 255) SET | Warp Room -> Submap 0 at (1,15) |
| `ev[10]` | `128 (Loop)` | Story Flag 168 (bit 2) SET AND Player within Box [76..78, 2..59] AND Condition Check #60 AND Story Flag 0 (mask 255) SET | Warp Room -> Submap 0 at (1,5) |
| `ev[11]` | `128 (Loop)` | Story Flag 168 (bit 2) SET AND Player Y within Range [99..102] AND Story Flag 0 (mask 255) SET | Warp Room -> Submap 0 at (1,5) |
| `ev[12]` | `1 (Action / Talk)` | Story Flag 167 (bit 128) SET AND Story Flag 168 (bit 2) CLEAR AND Player within Box [47..48, 2..75] AND Condition Check #96 AND Story Flag 2 (mask 255) SET | Set Render Priority (pri) (0, 38); Make Object Hidden (disp = 0) (9); Warp to Castle HQ (0, 0, 72); Warp Room -> Submap 0 at (5,0) facing 6; Warp Room -> Submap 72 at (0,0) facing 11; Warp Town -> Area 2 Map 90 Submap 69 at (3,32); Warp to Castle HQ (0, 115, 9) |
| `ev[13]` | `2 (Map Init)` | Story Flag 165 (bit 64) SET AND Story Flag 160 (bit 4) CLEAR AND Player within Box [36..36, 2..93] AND Condition Check #93 | Make obj[3] Hidden (disp = 0); Open Dialogue Message Window; Warp to Castle HQ (36, 1, 47) |
| `ev[14]` | `1 (Action / Talk)` | Story Flag 165 (bit 64) SET AND Story Flag 160 (bit 4) CLEAR AND Inventory Holds Item #1 AND Player within Box [36..36, 2..93] AND Condition Check #93 | Set Character Quest Milestone (0, 12); Open Dialogue Message Window; Display Dialogue Box [Bank: 5, MsgID: 12]; Warp to Castle HQ (3, 1, 0); Dismiss Emotion Bubble (24); Display Dialogue Box [Bank: 0, MsgID: 52]; Engine Action #5; Display Dialogue Box [Bank: 2, MsgID: 3]; Dismiss Emotion Bubble (84); Engine Action #83; Toggle Random Encounters (1); Display Dialogue Box [Bank: 37, MsgID: 1] |
| `ev[15]` | `2 (Map Init)` | Story Flag 207 (bit 16) CLEAR | Make obj[0] Hidden (disp = 0); Animate Door Open; Open Dialogue Message Window; Show Dialogue Portrait (0, 17, 47) |
| `ev[16]` | `2 (Map Init)` | Story Flag 207 (bit 16) SET | Open Dialogue Message Window; Place Scenery Structure (255) |
| `ev[17]` | `1 (Action / Talk)` | Story Flag 207 (bit 16) CLEAR AND Target Inspected is obj[17] AND Story Flag 0 (mask 255) SET | Exit to World Map (0, 42, 20); Reset Camera Tracking (3); Open Dialogue Message Window; Open Dialogue Message Window; Set Combat Battle BGM (20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 1 Map 13 Submap 1 at (14,41); Warp Town -> Area 0 Map 1 Submap 255 at (0,5); Open Dialogue Message Window; Open Dialogue Message Window; Warp Room -> Submap 46 at (2,16) facing 42; Execute Choice Result (89); Dismiss Dialogue Portrait; Warp Town -> Area 0 Map 1 Submap 0 at (0,16); Teleport obj[73] to (20,11); Warp Town -> Area 2 Map 90 Submap 89 at (16,5); Engine Action #89; Dismiss Dialogue Portrait; Engine Action #5; Set Combat Battle BGM (30); Warp Room -> Submap 0 at (0,1) facing 14; Warp Room -> Submap 1 at (17,0) facing 13; Close Dialogue Window; Warp Room -> Submap 40 at (123,0) facing South (Down); Engine Action #9; Engine Action #207; Dismiss Dialogue Portrait; Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[18]` | `1 (Action / Talk)` | Story Flag 207 (bit 16) CLEAR AND Target Inspected is obj[17] AND Story Flag 1 (mask 255) SET | Exit to World Map (0, 40, 24); Reset Camera Tracking (3); Open Dialogue Message Window; Warp Room -> Submap 20 at (40,0) facing South (Down); Warp Town -> Area 1 Map 13 Submap 1 at (14,41); Warp Town -> Area 0 Map 1 Submap 255 at (0,46); Warp Town -> Area 16 Map 40 Submap 24 at (89,16); Warp Town -> Area 2 Map 1 Submap 0 at (0,16); Teleport obj[73] to (20,11); Warp Town -> Area 2 Map 90 Submap 89 at (16,5); Engine Action #89; Dismiss Dialogue Portrait; Engine Action #5; Set Combat Battle BGM (30); Warp Room -> Submap 0 at (0,1) facing 14; Warp Room -> Submap 1 at (17,0) facing 13; Close Dialogue Window; Warp Room -> Submap 40 at (123,0) facing South (Down); Engine Action #9; Engine Action #207; Dismiss Dialogue Portrait; Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[19]` | `1 (Action / Talk)` | Story Flag 207 (bit 16) CLEAR AND Target Inspected is obj[17] AND Story Flag 2 (mask 255) SET | Exit to World Map (0, 43, 22); Reset Camera Tracking (3); Open Dialogue Message Window; Warp Town -> Area 73 Map 20 Submap 40 at (0,0); Warp Town -> Area 1 Map 13 Submap 1 at (14,41); Warp Town -> Area 0 Map 1 Submap 255 at (0,46); Warp Town -> Area 16 Map 43 Submap 22 at (89,16); Warp Town -> Area 4 Map 1 Submap 0 at (0,16); Teleport obj[73] to (20,11); Warp Town -> Area 2 Map 90 Submap 89 at (16,5); Engine Action #89; Dismiss Dialogue Portrait; Engine Action #5; Set Combat Battle BGM (30); Warp Room -> Submap 0 at (0,1) facing 14; Warp Room -> Submap 1 at (17,0) facing 13; Close Dialogue Window; Warp Room -> Submap 40 at (123,0) facing South (Down); Engine Action #9; Engine Action #207; Dismiss Dialogue Portrait; Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[20]` | `1 (Action / Talk)` | Story Flag 207 (bit 16) CLEAR AND Target Inspected is obj[17] AND Story Flag 3 (mask 255) SET | Exit to World Map (0, 39, 23); Reset Camera Tracking (3); Open Dialogue Message Window; Warp to Castle HQ (73, 20, 40); Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 1 Map 13 Submap 1 at (14,41); Warp Town -> Area 0 Map 1 Submap 255 at (0,46); Warp Town -> Area 16 Map 39 Submap 23 at (89,16); Warp Town -> Area 6 Map 1 Submap 0 at (0,16); Teleport obj[73] to (20,11); Warp Town -> Area 2 Map 90 Submap 89 at (16,5); Engine Action #89; Dismiss Dialogue Portrait; Engine Action #5; Set Combat Battle BGM (30); Warp Room -> Submap 0 at (0,1) facing 14; Warp Room -> Submap 1 at (17,0) facing 13; Close Dialogue Window; Warp Room -> Submap 40 at (123,0) facing South (Down); Engine Action #9; Engine Action #207; Dismiss Dialogue Portrait; Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[21]` | `2 (Map Init)` | Story Flag 207 (bit 16) SET AND Story Flag 207 (bit 64) CLEAR AND Story Flag 207 (bit 128) CLEAR AND Story Flag 151 (bit 64) CLEAR AND Condition Check #37 AND Always Passes (Unconditional) AND Always Passes (Unconditional) AND Always Passes (Unconditional) AND Target Inspected is obj[0] | Make obj[2] Hidden (disp = 0); Reset Camera Tracking (41); Open Dialogue Sub-Window (2); Engine Action #9; Engine Action #44; Clear Dialogue Sub-Window; Warp to Castle HQ (8, 1, 3); Engine Action #9; Warp Room -> Submap 8 at (0,9) facing South (Down); Display Choice Selection (36, 32); Teleport obj[255] to (254,204) |
| `ev[22]` | `1 (Action / Talk)` | Story Flag 207 (bit 16) SET AND Story Flag 207 (bit 32) CLEAR AND Story Flag 207 (bit 64) CLEAR AND Story Flag 207 (bit 128) CLEAR AND Story Flag 151 (bit 64) CLEAR AND Inventory Holds Item #32 AND Player within Box [31..45, 2..23] AND Condition Check #29 | Dismiss Character to Castle Base (26); Dismiss Emotion Bubble (84); Dismiss Emotion Bubble (30); Launch Tactical War Battle (4); Warp to Castle HQ (9, 2, 73); Show Dialogue Portrait (4, 0, 35); Fade In from Black (8); Make obj[106] Hidden (disp = 0); Engine Action #9; Close Dialogue Window; Warp Room -> Submap 1 at (19,0) facing 11; Engine Action #89; Close Dialogue Window; Warp Town -> Area 0 Map 3 Submap 0 at (3,47); Engine Action #89; Close Dialogue Window; Warp Town -> Area 1 Map 101 Submap 4 at (129,73); Trigger Character Emotion Effect (89, 11); Warp Town -> Area 2 Map 24 Submap 9 at (1,15); Engine Action #89; Close Dialogue Window; Engine Action #5; Engine Action #89; Close Dialogue Window; Engine Action #5; Load Sound Bank into Memory (1, 8); Warp to Castle HQ (5, 8, 3); Open Dialogue Message Window; Engine Action #5; Engine Action #6; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 72, 0); Reset Camera Tracking (73); Branch on Choice (5, 8); Warp Town -> Area 1 Map 0 Submap 3 at (2,0); Dismiss Emotion Bubble (24); Reset Camera Tracking (1); Change Portrait Expression (73); Branch on Choice (40, 0); Open Dialogue Message Window; Warp Town -> Area 1 Map 18 Submap 1 at (19,41); Warp Town -> Area 0 Map 1 Submap 255 at (0,24); Reset Camera Tracking (1); Clear Dialogue Sub-Window; Engine Action #89; Close Dialogue Window; Warp Town -> Area 1 Map 101 Submap 4 at (129,73); Display Dialogue Box [Bank: 89, MsgID: 11]; Warp Town -> Area 2 Map 24 Submap 9 at (1,26); Engine Action #89; Close Dialogue Window; Engine Action #5; Engine Action #89; Close Dialogue Window; Engine Action #5; Engine Action #5; Reset Camera Tracking (1); Open Dialogue Message Window; Engine Action #5; Screen Fade Transition (2, 0, 30); Close Dialogue Sub-Window (8); Warp Room -> Submap 73 at (20,40) facing South (Down); Open Dialogue Message Window; Warp Town -> Area 1 Map 28 Submap 1 at (29,41); Warp Town -> Area 2 Map 3 Submap 255 at (2,24); Reset Camera Tracking (1); Toggle Random Encounters (3); Reset Camera Tracking (1); Set Combat Battle BGM (15); Engine Action #89; Close Dialogue Window; Warp Town -> Area 1 Map 101 Submap 4 at (129,73); Make obj[89] Visible (disp = 1); Close Dialogue Window; Warp Town -> Area 2 Map 24 Submap 9 at (1,38); Engine Action #89; Close Dialogue Window; Engine Action #5; Engine Action #89; Close Dialogue Window; Engine Action #5; Close Dialogue Sub-Window (8); Warp Room -> Submap 46 at (3,8) facing Up (North); Warp to Castle HQ (9, 2, 47); Set Combat Battle BGM (20); Close Dialogue Sub-Window (8); Warp Room -> Submap 89 at (11,2) facing West (Left); Jump to Bytecode Offset (4, 129); Set Combat Battle BGM (45); Engine Action #89; Close Dialogue Window; Warp Town -> Area 2 Map 24 Submap 9 at (1,41); Engine Action #89; Close Dialogue Window; Engine Action #5; Engine Action #89; Close Dialogue Window; Engine Action #5; Engine Action #123; Warp Town -> Area 3 Map 5 Submap 115 at (30,6); Engine Action #115; Fade In from Black (5); Dismiss Character to Castle Base (30); Warp Room -> Submap 84 at (26,31); Engine Action #44; Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 101, 4); Engine Action #6; Engine Action #5; Open Dialogue Message Window; Warp Town -> Area 0 Map 5 Submap 3 at (1,0); Engine Action #5; Warp to Castle HQ (3, 0, 5); Warp to Castle HQ (0, 0, 5); Warp to Castle HQ (30, 89, 0); Warp Town -> Area 8 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Engine Action #89; Open Dialogue Message Window; Warp Town -> Area 9 Map 5 Submap 0 at (6,2); Dismiss Emotion Bubble (89); Open Dialogue Message Window; Warp Town -> Area 10 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Dismiss Emotion Bubble (0); Warp Room -> Submap 5 at (0,0) facing South (Down); Engine Action #5; Show Dialogue Portrait (3, 0, 30); Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 101, 4); Engine Action #6; Engine Action #5; Open Dialogue Message Window; Warp Town -> Area 0 Map 5 Submap 3 at (1,0); Engine Action #5; Warp to Castle HQ (3, 0, 5); Warp to Castle HQ (0, 0, 5); Warp to Castle HQ (30, 89, 0); Warp Town -> Area 8 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Engine Action #89; Open Dialogue Message Window; Warp Town -> Area 9 Map 5 Submap 0 at (6,2); Dismiss Emotion Bubble (89); Open Dialogue Message Window; Warp Town -> Area 10 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Dismiss Emotion Bubble (0); Warp Room -> Submap 5 at (0,0) facing South (Down); Engine Action #5; Show Dialogue Portrait (3, 0, 30); Make obj[73] Visible (disp = 1); Branch on Choice (24, 8); Warp Room -> Submap 46 at (43,8) facing 5; Open Shop Menu #5 (Type: 9); Teleport obj[73] to (20,40); Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 1 Map 43 Submap 1 at (44,41); Warp Town -> Area 4 Map 5 Submap 255 at (4,46); Warp Room -> Submap 1 at (19,1) facing 11; Open Dialogue Message Window; Engine Action #9; Teleport obj[49] to (2,48); Reset Camera Tracking (0); Warp to Castle HQ (0, 1, 0); Reset Camera Tracking (1); Reset Camera Tracking (255); Turn obj[9] facing South (Down); Warp to Castle HQ (0, 1, 0); Reset Camera Tracking (1); Engine Action #9; Walk obj[54] to (0,4); Pathfind and Walk to Coordinates (6, 1, 2); Dismiss Emotion Bubble (1); Fade In from Black (1); Recruit Invisible / Hitbox Trigger into Battle Slot 0; Engine Action #9; Engine Action #207; Engine Action #128; Engine Action #5; Close Dialogue Sub-Window (8); Warp Room -> Submap 3 at (8,1) facing 89; Close Dialogue Window; Warp Town -> Area 1 Map 101 Submap 4 at (129,73); Trigger Character Emotion Effect (89, 11); Warp Town -> Area 2 Map 24 Submap 9 at (1,46); Engine Action #89; Close Dialogue Window; Engine Action #5; Engine Action #89; Close Dialogue Window; Engine Action #5; Make obj[1] Hidden (disp = 0); Close Dialogue Window; Open Dialogue Message Window; Engine Action #9; Teleport obj[3] to (0,0); Exit to World Map (8, 35, 29); Engine Action #9; Warp to Castle HQ (8, 1, 4); Engine Action #9; Open Save Crystal Menu (MSaveInit); Display Chapter Text (9); Set Entity Movement Speed (2, 5); Reset Camera Tracking (0); Engine Action #9; Warp to Castle HQ (34, 30, 1); Reset Camera Tracking (255); Engine Action #5; Engine Action #9; Engine Action #5; Show Dialogue Portrait (2, 3, 0); Display Dialogue Box [Bank: 3, MsgID: 34]; Dismiss Emotion Bubble (1); Engine Action #9; Walk obj[46] to (9,207); Engine Action #128; Warp Room -> Submap 1 at (19,47) facing 255; Warp to Castle HQ (24, 8, 1); Dismiss Emotion Bubble (3); Reset Camera Tracking (1); Engine Action #89; Close Dialogue Window; Warp Town -> Area 1 Map 101 Submap 4 at (129,73); Dismiss Emotion Bubble (89); Close Dialogue Window; Warp Town -> Area 2 Map 24 Submap 9 at (1,31); Engine Action #89; Close Dialogue Window; Engine Action #5; Engine Action #89; Close Dialogue Window; Engine Action #5; Make obj[1] Hidden (disp = 0); Display Choice Selection (1, 18); Warp Room -> Submap 0 at (9,47) facing 49; Warp to Castle HQ (5, 8, 0); Warp Town -> Area 2 Map 8 Submap 1 at (20,30); Warp Room -> Submap 255 at (254,5) facing 9; Engine Action #5; Dismiss Emotion Bubble (2); Warp Town -> Area 0 Map 3 Submap 2 at (10,1); Branch on Choice (30, 1); Engine Action #9; Engine Action #5; Open Dialogue Message Window; Engine Action #5; Dismiss Emotion Bubble (0); Open Dialogue Message Window; Engine Action #5; Dismiss Emotion Bubble (2); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Walk obj[9] to (207,64); Engine Action #123; Open Dialogue Message Window; Open Dialogue Message Window; Warp Room -> Submap 8 at (1,0) facing 5; Engine Action #6; Warp to Castle HQ (0, 30, 24); Reset Camera Tracking (1); Branch on Choice (0, 18); Warp Room -> Submap 9 at (207,32) facing 255 |
| `ev[23]` | `1 (Action / Talk)` | Story Flag 207 (bit 32) SET AND Story Flag 207 (bit 64) CLEAR AND Story Flag 207 (bit 128) CLEAR AND Story Flag 151 (bit 64) CLEAR AND Inventory Holds Item #32 AND Temp Event Flag #8 SET AND Story Flag 2 (mask 5) SET AND Temp Event Flag #255 CLEAR | Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 30 Map 3 Submap 8 at (2,4); Open Dialogue Message Window; Start Boss Battle #26 (BGM: 8); Make obj[3] Hidden (disp = 0); Reset Camera Tracking (2); Warp to Castle HQ (0, 3, 47); Launch Tactical War Battle (8) |
| `ev[24]` | `1 (Action / Talk)` | Story Flag 207 (bit 32) SET AND Story Flag 207 (bit 64) CLEAR AND Story Flag 207 (bit 128) CLEAR AND Story Flag 151 (bit 64) CLEAR AND Inventory Holds Item #32 AND Temp Event Flag #8 SET AND Story Flag 3 (mask 5) SET AND Temp Event Flag #255 CLEAR | Exit to World Map (0, 35, 26); Reset Camera Tracking (46); Warp to Castle HQ (8, 2, 3); Open Dialogue Message Window; Warp to Castle HQ (47, 36, 8) |
| `ev[25]` | `1 (Action / Talk)` | Story Flag 207 (bit 32) SET AND Story Flag 207 (bit 64) CLEAR AND Story Flag 207 (bit 128) CLEAR AND Story Flag 151 (bit 64) CLEAR AND Inventory Holds Item #32 AND Temp Event Flag #8 SET AND Story Flag 1 (mask 5) SET AND Temp Event Flag #255 CLEAR | Exit to World Map (0, 35, 26); Reset Camera Tracking (46); Warp to Castle HQ (8, 2, 3); Open Dialogue Message Window; Warp to Castle HQ (47, 36, 8) |
| `ev[26]` | `1 (Action / Talk)` | Story Flag 207 (bit 32) SET AND Story Flag 207 (bit 64) CLEAR AND Story Flag 207 (bit 128) CLEAR AND Story Flag 151 (bit 64) CLEAR AND Inventory Holds Item #32 AND Temp Event Flag #8 SET AND Story Flag 0 (mask 5) SET AND Temp Event Flag #255 CLEAR | Exit to World Map (0, 35, 26); Reset Camera Tracking (46); Warp to Castle HQ (8, 2, 3); Open Dialogue Message Window; Warp to Castle HQ (47, 36, 8) |
| `ev[27]` | `1 (Action / Talk)` | Story Flag 207 (bit 32) SET AND Story Flag 207 (bit 64) CLEAR AND Story Flag 207 (bit 128) CLEAR AND Story Flag 151 (bit 64) CLEAR AND Inventory Holds Item #32 AND Inventory Holds Item #8 | Launch Tactical War Battle (4); Close Dialogue Sub-Window (8); Warp Room -> Submap 73 at (20,40) facing South (Down); Open Dialogue Message Window; Warp Town -> Area 1 Map 22 Submap 1 at (23,41); Warp Town -> Area 0 Map 1 Submap 255 at (0,24); Reset Camera Tracking (1); Clear Dialogue Sub-Window; Make obj[106] Hidden (disp = 0); Engine Action #9; Close Dialogue Window; Warp Room -> Submap 0 at (11,89) facing 11; Warp Town -> Area 1 Map 47 Submap 73 at (12,89); Close Dialogue Window; Warp Town -> Area 2 Map 101 Submap 4 at (129,24); Engine Action #9; Warp Room -> Submap 5 at (8,1) facing South (Down); Engine Action #5; Screen Fade Transition (2, 0, 30); Close Dialogue Sub-Window (8); Warp Room -> Submap 73 at (20,40) facing South (Down); Open Dialogue Message Window; Warp Town -> Area 1 Map 28 Submap 1 at (29,41); Warp Town -> Area 2 Map 3 Submap 255 at (2,24); Reset Camera Tracking (1); Toggle Random Encounters (3); Reset Camera Tracking (1); Set Combat Battle BGM (15); Engine Action #89; Close Dialogue Window; Warp Town -> Area 1 Map 101 Submap 4 at (129,73); Make obj[89] Visible (disp = 1); Close Dialogue Window; Warp Town -> Area 2 Map 24 Submap 9 at (1,38); Engine Action #89; Close Dialogue Window; Engine Action #5; Engine Action #89; Close Dialogue Window; Engine Action #5; Close Dialogue Sub-Window (8); Warp Room -> Submap 46 at (3,8) facing Up (North); Warp to Castle HQ (9, 2, 47); Close Dialogue Sub-Window (8); Warp Room -> Submap 89 at (11,2) facing West (Left); Jump to Bytecode Offset (4, 129); Set Combat Battle BGM (40); Engine Action #89; Close Dialogue Window; Warp Town -> Area 2 Map 24 Submap 9 at (1,41); Engine Action #89; Close Dialogue Window; Engine Action #5; Engine Action #89; Close Dialogue Window; Engine Action #5; Engine Action #123; Warp Town -> Area 3 Map 5 Submap 115 at (30,6); Engine Action #115; Fade In from Black (5); Dismiss Character to Castle Base (30); Warp Room -> Submap 84 at (26,31); Engine Action #44; Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 101, 4); Engine Action #6; Engine Action #5; Open Dialogue Message Window; Warp Town -> Area 0 Map 5 Submap 3 at (1,0); Engine Action #5; Warp to Castle HQ (3, 0, 5); Warp to Castle HQ (0, 0, 5); Warp to Castle HQ (30, 89, 0); Warp Town -> Area 8 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Engine Action #89; Open Dialogue Message Window; Warp Town -> Area 9 Map 5 Submap 0 at (6,2); Dismiss Emotion Bubble (89); Open Dialogue Message Window; Warp Town -> Area 10 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Dismiss Emotion Bubble (0); Warp Room -> Submap 5 at (0,0) facing South (Down); Engine Action #5; Show Dialogue Portrait (3, 0, 30); Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 101, 4); Engine Action #6; Engine Action #5; Open Dialogue Message Window; Warp Town -> Area 0 Map 5 Submap 3 at (1,0); Engine Action #5; Warp to Castle HQ (3, 0, 5); Warp to Castle HQ (0, 0, 5); Warp to Castle HQ (30, 89, 0); Warp Town -> Area 8 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Engine Action #89; Open Dialogue Message Window; Warp Town -> Area 9 Map 5 Submap 0 at (6,2); Dismiss Emotion Bubble (89); Open Dialogue Message Window; Warp Town -> Area 10 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Dismiss Emotion Bubble (0); Warp Room -> Submap 5 at (0,0) facing South (Down); Engine Action #5; Show Dialogue Portrait (3, 0, 30); Make obj[73] Visible (disp = 1); Branch on Choice (24, 8); Warp Room -> Submap 46 at (43,8) facing 5; Open Shop Menu #5 (Type: 9); Teleport obj[73] to (20,40); Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 1 Map 43 Submap 1 at (44,41); Warp Town -> Area 4 Map 5 Submap 255 at (4,46); Warp Room -> Submap 0 at (9,47) facing 49; Warp Town -> Area 48 Map 8 Submap 0 at (3,0); Warp Room -> Submap 8 at (1,8) facing 255; Turn obj[9] facing South (Down); Warp to Castle HQ (0, 1, 0); Reset Camera Tracking (1); Engine Action #9; Walk obj[54] to (0,4); Pathfind and Walk to Coordinates (6, 1, 2); Dismiss Emotion Bubble (1); Fade In from Black (1); Recruit Invisible / Hitbox Trigger into Battle Slot 0; Engine Action #9; Engine Action #207; Engine Action #128; Warp Room -> Submap 255 at (254,255) facing 5; Close Dialogue Sub-Window (8); Warp Room -> Submap 3 at (8,1) facing 89; Close Dialogue Window; Warp Town -> Area 1 Map 101 Submap 4 at (129,73); Trigger Character Emotion Effect (89, 11); Warp Town -> Area 2 Map 24 Submap 9 at (1,46); Engine Action #89; Close Dialogue Window; Engine Action #5; Engine Action #89; Close Dialogue Window; Engine Action #5; Warp to Castle HQ (0, 0, 4); Reset Camera Tracking (35); Display Emotion Bubble (9, 3); Reset Camera Tracking (1); Make obj[1] Hidden (disp = 0); Close Dialogue Window; Open Dialogue Message Window; Engine Action #9; Teleport obj[4] to (9,38); Display Chapter Text (9); Set Entity Movement Speed (2, 5); Reset Camera Tracking (0); Engine Action #9; Warp to Castle HQ (34, 30, 1); Reset Camera Tracking (255); Engine Action #5; Engine Action #9; Engine Action #5; Show Dialogue Portrait (2, 3, 0); Display Dialogue Box [Bank: 3, MsgID: 34]; Dismiss Emotion Bubble (1); Engine Action #9; Walk obj[9] to (207,128); Warp Room -> Submap 255 at (254,255) facing East (Right); Close Dialogue Sub-Window (8); Warp Room -> Submap 3 at (8,1) facing 89; Close Dialogue Window; Warp Town -> Area 1 Map 101 Submap 4 at (129,73); Make obj[89] Visible (disp = 1); Close Dialogue Window; Warp Town -> Area 2 Map 24 Submap 9 at (1,31); Engine Action #89; Close Dialogue Window; Engine Action #5; Engine Action #89; Close Dialogue Window; Engine Action #5; Make obj[1] Hidden (disp = 0); Close Dialogue Window; Open Dialogue Message Window; Engine Action #9; Teleport obj[49] to (3,5); Reset Camera Tracking (1); Warp Town -> Area 2 Map 8 Submap 1 at (20,30); Warp Room -> Submap 255 at (254,5) facing 9; Engine Action #5; Dismiss Emotion Bubble (2); Display Dialogue Box [Bank: 1, MsgID: 20]; Dismiss Emotion Bubble (1); Engine Action #9; Engine Action #5; Open Dialogue Message Window; Engine Action #5; Dismiss Emotion Bubble (0); Open Dialogue Message Window; Engine Action #5; Dismiss Emotion Bubble (2); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Walk obj[1] to (18,123); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #9; Engine Action #207; Animate Doorway State (255, 254); Warp Room -> Submap 8 at (1,24) facing 37; Reset Camera Tracking (255) |
| `ev[28]` | `1 (Action / Talk)` | Story Flag 207 (bit 32) SET AND Story Flag 207 (bit 64) CLEAR AND Story Flag 207 (bit 128) CLEAR AND Story Flag 151 (bit 64) CLEAR AND Inventory Holds Item #32 AND Temp Event Flag #8 SET AND Story Flag 0 (mask 5) SET AND Party Member Count == 255 | Warp Town -> Area 11 Map 44 Submap 25 at (0,11); Warp Room -> Submap 89 at (11,2) facing West (Left); Jump to Bytecode Offset (4, 129); Set Combat Battle BGM (30); Engine Action #89; Close Dialogue Window; Warp Town -> Area 2 Map 24 Submap 9 at (2,0); Engine Action #89; Close Dialogue Window; Engine Action #5; Engine Action #89; Close Dialogue Window; Engine Action #5; Set Combat Battle BGM (10); Warp to Castle HQ (8, 1, 24); Reset Camera Tracking (2); Warp Room -> Submap 10 at (3,8) facing East (Right); Engine Action #89; Close Dialogue Window; Warp Town -> Area 1 Map 101 Submap 4 at (129,73); Make obj[89] Visible (disp = 1); Close Dialogue Window; Warp Town -> Area 2 Map 24 Submap 9 at (2,2); Engine Action #89; Close Dialogue Window; Engine Action #5; Engine Action #89; Close Dialogue Window; Engine Action #5 |
| `ev[29]` | `1 (Action / Talk)` | Story Flag 207 (bit 32) SET AND Story Flag 207 (bit 64) CLEAR AND Story Flag 207 (bit 128) CLEAR AND Story Flag 151 (bit 64) CLEAR AND Inventory Holds Item #32 AND Temp Event Flag #8 SET AND Story Flag 1 (mask 5) SET AND Party Member Count == 255 | Warp Town -> Area 11 Map 44 Submap 25 at (0,11); Warp Room -> Submap 89 at (11,2) facing West (Left); Jump to Bytecode Offset (4, 129); Set Combat Battle BGM (15); Engine Action #89; Close Dialogue Window; Warp Town -> Area 2 Map 24 Submap 9 at (2,3); Engine Action #89; Close Dialogue Window; Engine Action #5; Engine Action #89; Close Dialogue Window; Engine Action #5; Set Combat Battle BGM (10); Warp to Castle HQ (8, 3, 24); Reset Camera Tracking (2); Exit to World Map (73, 10, 3); Reset Camera Tracking (3); Engine Action #89; Close Dialogue Window; Warp Town -> Area 1 Map 101 Submap 4 at (129,73); Make obj[89] Visible (disp = 1); Close Dialogue Window; Warp Town -> Area 2 Map 24 Submap 9 at (2,5); Engine Action #89; Close Dialogue Window; Warp Town -> Area 2 Map 89 Submap 11 at (5,255) |
| `ev[30]` | `1 (Action / Talk)` | Story Flag 207 (bit 32) SET AND Story Flag 207 (bit 64) CLEAR AND Story Flag 207 (bit 128) CLEAR AND Story Flag 151 (bit 64) CLEAR AND Temp Event Flag #32 SET AND Player within Box [31..45, 2..23] AND Condition Check #29 | Launch Tactical War Battle (4); Exit to World Map (0, 35, 26); Reset Camera Tracking (5); Reset Camera Tracking (2); Warp Room -> Submap 3 at (2,0) facing 30; Make obj[3] Hidden (disp = 0); Reset Camera Tracking (2); Warp to Castle HQ (0, 3, 47); Close Dialogue Sub-Window (8); Warp Room -> Submap 73 at (20,40) facing South (Down); Open Dialogue Message Window; Warp Town -> Area 1 Map 22 Submap 1 at (23,41); Warp Town -> Area 0 Map 1 Submap 255 at (0,24); Reset Camera Tracking (1); Clear Dialogue Sub-Window; Make obj[106] Hidden (disp = 0); Engine Action #9; Close Dialogue Window; Warp Room -> Submap 0 at (11,89) facing 11; Warp Town -> Area 1 Map 47 Submap 73 at (12,89); Close Dialogue Window; Warp Town -> Area 2 Map 101 Submap 4 at (129,24); Engine Action #9; Warp Room -> Submap 5 at (8,1) facing South (Down); Engine Action #5; Screen Fade Transition (2, 0, 30); Close Dialogue Sub-Window (8); Warp Room -> Submap 73 at (20,40) facing South (Down); Open Dialogue Message Window; Warp Town -> Area 1 Map 28 Submap 1 at (29,41); Warp Town -> Area 2 Map 3 Submap 255 at (2,24); Reset Camera Tracking (1); Toggle Random Encounters (3); Reset Camera Tracking (1); Set Combat Battle BGM (15); Engine Action #89; Close Dialogue Window; Warp Town -> Area 1 Map 101 Submap 4 at (129,73); Make obj[89] Visible (disp = 1); Close Dialogue Window; Warp Town -> Area 2 Map 24 Submap 9 at (1,38); Engine Action #89; Close Dialogue Window; Engine Action #5; Engine Action #89; Close Dialogue Window; Engine Action #5; Close Dialogue Sub-Window (8); Warp Room -> Submap 46 at (3,8) facing Up (North); Warp to Castle HQ (9, 2, 47); Close Dialogue Sub-Window (8); Warp Room -> Submap 89 at (11,2) facing West (Left); Jump to Bytecode Offset (4, 129); Close Dialogue Sub-Window (9); Warp Room -> Submap 73 at (40,89) facing 11; Warp Town -> Area 2 Map 89 Submap 11 at (5,89); Close Dialogue Window; Engine Action #5; Engine Action #123; Warp Town -> Area 3 Map 5 Submap 115 at (30,6); Engine Action #115; Fade In from Black (5); Dismiss Character to Castle Base (30); Warp Room -> Submap 84 at (26,31); Engine Action #44; Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 101, 4); Engine Action #6; Engine Action #5; Open Dialogue Message Window; Warp Town -> Area 0 Map 5 Submap 3 at (1,0); Engine Action #5; Warp to Castle HQ (3, 0, 5); Warp to Castle HQ (0, 0, 5); Warp to Castle HQ (30, 89, 0); Warp Town -> Area 8 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Engine Action #89; Open Dialogue Message Window; Warp Town -> Area 9 Map 5 Submap 0 at (6,2); Dismiss Emotion Bubble (89); Open Dialogue Message Window; Warp Town -> Area 10 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Dismiss Emotion Bubble (0); Warp Room -> Submap 5 at (0,0) facing South (Down); Engine Action #5; Show Dialogue Portrait (3, 0, 30); Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 101, 4); Engine Action #6; Engine Action #5; Open Dialogue Message Window; Warp Town -> Area 0 Map 5 Submap 3 at (1,0); Engine Action #5; Warp to Castle HQ (3, 0, 5); Warp to Castle HQ (0, 0, 5); Warp to Castle HQ (30, 89, 0); Warp Town -> Area 8 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Engine Action #89; Open Dialogue Message Window; Warp Town -> Area 9 Map 5 Submap 0 at (6,2); Dismiss Emotion Bubble (89); Open Dialogue Message Window; Warp Town -> Area 10 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Dismiss Emotion Bubble (0); Warp Room -> Submap 5 at (0,0) facing South (Down); Engine Action #5; Show Dialogue Portrait (3, 0, 30); Make obj[73] Visible (disp = 1); Branch on Choice (24, 8); Warp Room -> Submap 46 at (43,8) facing 5; Open Shop Menu #5 (Type: 9); Teleport obj[73] to (20,40); Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 1 Map 43 Submap 1 at (44,41); Warp Town -> Area 4 Map 5 Submap 255 at (4,46); Warp Room -> Submap 0 at (9,47) facing 49; Warp Town -> Area 48 Map 8 Submap 0 at (3,0); Warp Room -> Submap 8 at (1,8) facing 255; Turn obj[9] facing South (Down); Warp to Castle HQ (0, 1, 0); Reset Camera Tracking (1); Engine Action #9; Walk obj[54] to (0,4); Pathfind and Walk to Coordinates (6, 1, 2); Dismiss Emotion Bubble (1); Fade In from Black (1); Recruit Invisible / Hitbox Trigger into Battle Slot 0; Engine Action #9; Engine Action #207; Engine Action #128; Warp Room -> Submap 255 at (254,255) facing 5; Close Dialogue Sub-Window (8); Warp Room -> Submap 3 at (8,1) facing 89; Close Dialogue Window; Warp Town -> Area 1 Map 101 Submap 4 at (129,73); Trigger Character Emotion Effect (89, 11); Warp Town -> Area 2 Map 24 Submap 9 at (1,46); Engine Action #89; Close Dialogue Window; Engine Action #5; Engine Action #89; Close Dialogue Window; Engine Action #5; Warp to Castle HQ (0, 0, 4); Reset Camera Tracking (35); Display Emotion Bubble (9, 3); Reset Camera Tracking (1); Make obj[1] Hidden (disp = 0); Close Dialogue Window; Open Dialogue Message Window; Engine Action #9; Teleport obj[4] to (9,38); Display Chapter Text (9); Set Entity Movement Speed (2, 5); Reset Camera Tracking (0); Engine Action #9; Warp to Castle HQ (34, 30, 1); Reset Camera Tracking (255); Engine Action #5; Engine Action #9; Engine Action #5; Show Dialogue Portrait (2, 3, 0); Display Dialogue Box [Bank: 3, MsgID: 34]; Dismiss Emotion Bubble (1); Engine Action #9; Walk obj[9] to (207,128); Warp Room -> Submap 255 at (254,255) facing East (Right); Close Dialogue Sub-Window (8); Warp Room -> Submap 3 at (8,1) facing 89; Close Dialogue Window; Warp Town -> Area 1 Map 101 Submap 4 at (129,73); Make obj[89] Visible (disp = 1); Close Dialogue Window; Warp Town -> Area 2 Map 24 Submap 9 at (1,31); Engine Action #89; Close Dialogue Window; Engine Action #5; Engine Action #89; Close Dialogue Window; Engine Action #5; Make obj[1] Hidden (disp = 0); Close Dialogue Window; Open Dialogue Message Window; Engine Action #9; Teleport obj[49] to (3,5); Reset Camera Tracking (0); Warp Town -> Area 2 Map 8 Submap 1 at (20,30); Warp Room -> Submap 255 at (254,5) facing 9; Engine Action #5; Dismiss Emotion Bubble (2); Display Dialogue Box [Bank: 1, MsgID: 20]; Dismiss Emotion Bubble (1); Engine Action #9; Engine Action #5; Open Dialogue Message Window; Engine Action #5; Dismiss Emotion Bubble (0); Open Dialogue Message Window; Engine Action #5; Dismiss Emotion Bubble (2); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Walk obj[1] to (18,123); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #9; Engine Action #207; Animate Doorway State (255, 254); Warp Room -> Submap 8 at (1,24) facing 37; Reset Camera Tracking (255) |
| `ev[31]` | `2 (Map Init)` | Story Flag 207 (bit 64) SET AND Story Flag 207 (bit 128) CLEAR AND Story Flag 151 (bit 64) CLEAR AND Condition Check #37 AND Always Passes (Unconditional) AND Always Passes (Unconditional) AND Always Passes (Unconditional) AND Target Inspected is obj[0] | Make obj[2] Hidden (disp = 0); Reset Camera Tracking (41); Open Dialogue Sub-Window (2); Engine Action #9; Engine Action #44; Clear Dialogue Sub-Window; Warp to Castle HQ (8, 1, 3); Engine Action #9; Warp Room -> Submap 8 at (0,9) facing South (Down); Display Choice Selection (36, 16); Teleport obj[255] to (254,204) |
| `ev[32]` | `1 (Action / Talk)` | Story Flag 207 (bit 64) SET AND Story Flag 207 (bit 128) CLEAR AND Inventory Holds Item #16 AND Story Flag 151 (bit 64) CLEAR AND Condition Check #37 AND Always Passes (Unconditional) AND Always Passes (Unconditional) AND Always Passes (Unconditional) AND Target Inspected is obj[0] AND Player within Box [31..45, 2..23] AND Condition Check #29 | Toggle Random Encounters (16); Exit to World Map (0, 35, 26); Reset Camera Tracking (3); Engine Action #9; Warp Town -> Area 73 Map 15 Submap 46 at (106,9); Close Dialogue Window; Warp Room -> Submap 1 at (19,0) facing 18; Open Dialogue Message Window; Close Dialogue Window; Engine Action #89; Close Dialogue Window; Warp Town -> Area 0 Map 3 Submap 0 at (3,47); Engine Action #89; Close Dialogue Window; Warp Town -> Area 1 Map 101 Submap 4 at (129,73); Trigger Character Emotion Effect (89, 11); Warp Town -> Area 2 Map 24 Submap 9 at (1,15); Engine Action #89; Close Dialogue Window; Engine Action #5; Engine Action #89; Close Dialogue Window; Engine Action #5; Engine Action #5; Reset Camera Tracking (3); Open Dialogue Message Window; Engine Action #5; Engine Action #6; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 5, 8); Warp Town -> Area 1 Map 0 Submap 3 at (2,0); Dismiss Emotion Bubble (24); Reset Camera Tracking (1); Warp Map Transition (73, 20, 40, 0, 0); Warp Town -> Area 1 Map 33 Submap 1 at (34,41); Warp Town -> Area 0 Map 1 Submap 255 at (1,24); Reset Camera Tracking (1); Start Boss Battle #46 (BGM: 106); Engine Action #9; Close Dialogue Window; Warp Room -> Submap 0 at (11,89) facing 11; Warp Town -> Area 1 Map 47 Submap 101 at (4,129); Set Combat Battle BGM (30); Engine Action #89; Close Dialogue Window; Warp Town -> Area 2 Map 24 Submap 9 at (1,36); Engine Action #89; Close Dialogue Window; Engine Action #5; Engine Action #89; Close Dialogue Window; Engine Action #5; Make obj[1] Hidden (disp = 0); Close Dialogue Window; Open Dialogue Message Window; Engine Action #9; Teleport obj[49] to (3,5); Reset Camera Tracking (1); Warp Town -> Area 2 Map 8 Submap 1 at (20,30); Warp Room -> Submap 255 at (254,5) facing 9; Engine Action #5; Dismiss Emotion Bubble (2); Display Dialogue Box [Bank: 1, MsgID: 20]; Dismiss Emotion Bubble (1); Engine Action #9; Engine Action #5; Open Dialogue Message Window; Engine Action #5; Dismiss Emotion Bubble (1); Open Dialogue Message Window; Engine Action #5; Dismiss Emotion Bubble (30); Walk obj[1] to (19,123); Open Dialogue Message Window; Open Dialogue Message Window; Open Dialogue Message Window; Launch Tactical War Battle (4); Close Dialogue Sub-Window (8); Warp Room -> Submap 3 at (8,1) facing 73; Show Dialogue Portrait (3, 9, 2); Make obj[106] Hidden (disp = 0); Engine Action #9; Close Dialogue Window; Warp Room -> Submap 0 at (11,89) facing 11; Warp Town -> Area 1 Map 47 Submap 101 at (4,129); Set Combat Battle BGM (45); Engine Action #89; Close Dialogue Window; Warp Town -> Area 2 Map 24 Submap 9 at (1,38); Engine Action #89; Close Dialogue Window; Engine Action #5; Engine Action #89; Close Dialogue Window; Engine Action #5; Close Dialogue Sub-Window (8); Warp Room -> Submap 46 at (3,8) facing Up (North); Warp to Castle HQ (9, 2, 47); Set Combat Battle BGM (20); Close Dialogue Sub-Window (8); Warp Room -> Submap 89 at (11,2) facing West (Left); Jump to Bytecode Offset (4, 129); Set Combat Battle BGM (30); Engine Action #89; Close Dialogue Window; Warp Town -> Area 2 Map 24 Submap 9 at (1,41); Engine Action #89; Close Dialogue Window; Engine Action #5; Engine Action #89; Close Dialogue Window; Engine Action #5; Engine Action #123; Warp Town -> Area 3 Map 5 Submap 115 at (30,6); Engine Action #115; Fade In from Black (5); Dismiss Character to Castle Base (30); Warp Room -> Submap 84 at (26,31); Engine Action #44; Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 101, 4); Engine Action #6; Engine Action #5; Open Dialogue Message Window; Warp Town -> Area 0 Map 5 Submap 3 at (1,0); Engine Action #5; Warp to Castle HQ (3, 0, 5); Warp to Castle HQ (0, 0, 5); Warp to Castle HQ (30, 89, 0); Warp Town -> Area 8 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Engine Action #89; Open Dialogue Message Window; Warp Town -> Area 9 Map 5 Submap 0 at (6,2); Dismiss Emotion Bubble (89); Open Dialogue Message Window; Warp Town -> Area 10 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Dismiss Emotion Bubble (0); Warp Room -> Submap 5 at (0,0) facing South (Down); Engine Action #5; Show Dialogue Portrait (3, 0, 30); Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 101, 4); Engine Action #6; Engine Action #5; Open Dialogue Message Window; Warp Town -> Area 0 Map 5 Submap 3 at (1,0); Engine Action #5; Warp to Castle HQ (3, 0, 5); Warp to Castle HQ (0, 0, 5); Warp to Castle HQ (30, 89, 0); Warp Town -> Area 8 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Engine Action #89; Open Dialogue Message Window; Warp Town -> Area 9 Map 5 Submap 0 at (6,2); Dismiss Emotion Bubble (89); Open Dialogue Message Window; Warp Town -> Area 10 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Dismiss Emotion Bubble (0); Warp Room -> Submap 5 at (0,0) facing South (Down); Engine Action #5; Show Dialogue Portrait (3, 0, 30); Make obj[73] Visible (disp = 1); Branch on Choice (24, 8); Warp Room -> Submap 46 at (43,8) facing 5; Open Shop Menu #5 (Type: 9); Teleport obj[73] to (20,40); Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 1 Map 43 Submap 1 at (44,41); Warp Town -> Area 2 Map 3 Submap 255 at (2,46); Warp Room -> Submap 0 at (9,47) facing 49; Warp Town -> Area 48 Map 8 Submap 0 at (3,0); Warp Room -> Submap 8 at (1,8) facing 255; Turn obj[9] facing South (Down); Warp to Castle HQ (0, 1, 0); Reset Camera Tracking (1); Engine Action #9; Walk obj[54] to (0,4); Pathfind and Walk to Coordinates (6, 1, 2); Dismiss Emotion Bubble (1); Fade In from Black (1); Recruit Invisible / Hitbox Trigger into Battle Slot 0; Engine Action #9; Engine Action #207; Engine Action #128; Warp Room -> Submap 255 at (254,255) facing East (Right); Close Dialogue Sub-Window (8); Warp Room -> Submap 3 at (8,1) facing 89; Close Dialogue Window; Warp Town -> Area 1 Map 101 Submap 4 at (129,73); Make obj[89] Visible (disp = 1); Close Dialogue Window; Warp Town -> Area 2 Map 24 Submap 9 at (1,46); Engine Action #89; Close Dialogue Window; Engine Action #5; Engine Action #89; Close Dialogue Window; Engine Action #5; Warp to Castle HQ (0, 0, 4); Reset Camera Tracking (35); Display Emotion Bubble (9, 3); Reset Camera Tracking (1); Make obj[1] Hidden (disp = 0); Close Dialogue Window; Open Dialogue Message Window; Engine Action #9; Teleport obj[4] to (9,38); Display Chapter Text (9); Set Entity Movement Speed (2, 5); Reset Camera Tracking (0); Engine Action #9; Warp to Castle HQ (34, 30, 1); Reset Camera Tracking (255); Engine Action #5; Engine Action #9; Engine Action #5; Show Dialogue Portrait (2, 3, 0); Display Dialogue Box [Bank: 3, MsgID: 34]; Dismiss Emotion Bubble (1); Engine Action #9; Walk obj[9] to (207,128); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[33]` | `128 (Loop)` | Story Flag 207 (bit 16) SET AND Story Flag 207 (bit 64) CLEAR AND Story Flag 207 (bit 128) CLEAR AND Story Flag 151 (bit 64) CLEAR AND Inventory Holds Item #4 | Warp Room -> Submap 0 at (13,27); Toggle Random Encounters (4) |
| `ev[34]` | `128 (Loop)` | Story Flag 207 (bit 64) SET AND Story Flag 207 (bit 128) CLEAR AND Story Flag 151 (bit 64) CLEAR AND Inventory Holds Item #4 | Warp Room -> Submap 0 at (13,27); Toggle Random Encounters (4) |
| `ev[35]` | `2 (Map Init)` | Story Flag 207 (bit 32) SET AND Story Flag 207 (bit 64) CLEAR AND Story Flag 207 (bit 128) CLEAR AND Story Flag 151 (bit 64) CLEAR AND Condition Check #37 AND Always Passes (Unconditional) AND Always Passes (Unconditional) AND Always Passes (Unconditional) AND Target Inspected is obj[0] | Make obj[2] Hidden (disp = 0); Reset Camera Tracking (40); Fade In from Black (2); Engine Action #9; Engine Action #44; Clear Dialogue Sub-Window; Warp to Castle HQ (8, 1, 3); Engine Action #9; Warp Town -> Area 0 Map 8 Submap 0 at (9,0); Display Speaker Name Box (1); Display Choice Selection (36, 32); Teleport obj[255] to (254,204) |

---

### Submap Layer `vb07_01` (Index 1)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `2` (Timer: `50`, Rate: `4`)
- **Entity Count (`okaz`)**: `2` Objects | **Script Count (`evkaz`)**: `3` Scripts

#### Complete Physical Entity Inventory (2 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 33304** | `33304` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | Prop / Scenery | **Prop ID 33304** | `33304` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 33304)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Prop: Object 33304)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `2`.


#### Complete Bytecode Script Catalog (3 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [1..2, 2..15] AND Condition Check #35 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 96]; Return to Previous Memory Map (255) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [77..79, 2..32] AND Condition Check #48 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 3]; Start Boss Battle #255 (BGM: 254) |
| `ev[02]` | `1 (Action / Talk)` | Story Flag 165 (bit 64) SET AND Story Flag 160 (bit 4) CLEAR AND Story Flag 160 (bit 8) CLEAR AND Player within Box [6..7, 2..19] AND Condition Check #30 AND Star of Destiny #1 Recruited AND Condition Check #83 AND Story Flag 3 (mask 255) SET | Make obj[2] Hidden (disp = 0); Engine Action #9; Engine Action #62; Launch Tactical War Battle (89); Engine Action #9; Warp Town -> Area 6 Map 0 Submap 9 at (47,33); Warp Room -> Submap 46 at (0,1) facing 47; Engine Action #5; Warp Room -> Submap 5 at (3,4) facing 6; Warp Town -> Area 30 Map 24 Submap 1 at (1,0); Full Rest & Healing (Restore HP/MP); Warp to Castle HQ (40, 0, 10); Engine Action #6; Set Combat Battle BGM (20); Load Sound Bank into Memory (1, 9); Open Dialogue Message Window; Jump to Bytecode Offset (4, 130); Make obj[72] Hidden (disp = 0); Open Dialogue Message Window; Engine Action #9; Set Character Quest Milestone (9, 8); Warp Room -> Submap 0 at (8,47) facing 72; Warp Room -> Submap 9 at (5,8) facing 4; Engine Action #5; Open Dialogue Message Window; Warp Town -> Area 3 Map 24 Submap 30 at (72,0); Reset Camera Tracking (24); Warp Room -> Submap 1 at (3,1) facing Up (North); Set Combat Battle BGM (20); Set Entity Movement Speed (2, 76); Warp Town -> Area 40 Map 1 Submap 10 at (6,255); Engine Action #5; Warp Room -> Submap 40 at (6,1) facing 6; Warp Room -> Submap 2 at (30,255) facing 254; Walk obj[39] to (34,45); Engine Action #9; Engine Action #160; Exit to World Map (255, 254, 204) |

---

### Submap Layer `vb07_02` (Index 2)

- **Map Number (`mapno`)**: `2`
- **Battle Encounter Zone (`batlno`)**: `3` (Timer: `40`, Rate: `5`)
- **Entity Count (`okaz`)**: `3` Objects | **Script Count (`evkaz`)**: `4` Scripts

#### Complete Physical Entity Inventory (3 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Millie** | `24` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Actor ID 33304** | `33304` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | Prop / Scenery | **Prop ID 33304** | `33304` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Millie)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Object 33304)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Prop: Object 33304)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `2`.


#### Complete Bytecode Script Catalog (4 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [1..2, 2..24] AND Condition Check #42 | Display Dialogue Box [Bank: 1, MsgID: 76]; Open Save Crystal Menu (MSaveInit) |
| `ev[01]` | `2 (Map Init)` | Story Flag 165 (bit 64) SET AND Story Flag 160 (bit 4) SET AND Story Flag 160 (bit 8) CLEAR AND Star of Destiny #1 Recruited AND Condition Check #83 | Make obj[2] Hidden (disp = 0); Screen Fade Transition (72, 23, 89); Screen Fade Transition (2, 8, 0); Screen Fade Transition (47, 255, 254) |
| `ev[02]` | `128 (Loop)` | Story Flag 165 (bit 64) SET AND Story Flag 160 (bit 4) SET AND Story Flag 160 (bit 8) CLEAR AND Inventory Holds Item #1 | Warp Room -> Submap 0 at (15,48); Toggle Random Encounters (1) |
| `ev[03]` | `1 (Action / Talk)` | Story Flag 165 (bit 64) SET AND Story Flag 160 (bit 4) SET AND Story Flag 160 (bit 8) CLEAR AND Star of Destiny #1 Recruited AND Condition Check #83 AND Player within Box [58..60, 9..3] | Launch Tactical War Battle (1); Exit to World Map (0, 62, 23); Engine Action #9; Warp to Castle HQ (0, 3, 33); Warp Room -> Submap 46 at (0,1) facing 47; Engine Action #5; Warp Room -> Submap 4 at (3,4) facing 30; Close Dialogue Sub-Window (1); Warp Room -> Submap 5 at (1,4) facing Up (North); Warp to Castle HQ (3, 30, 72); Warp Room -> Submap 0 at (5,1) facing 6; Warp Room -> Submap 72 at (0,1) facing 89; Screen Fade Transition (2, 9, 89); Screen Fade Transition (5, 89, 10); Engine Action #5; Engine Action #5; Warp Room -> Submap 5 at (3,0) facing 7; Warp Room -> Submap 89 at (10,2) facing 10; Jump to Bytecode Offset (0, 178); Close Dialogue Sub-Window (1); Warp Room -> Submap 101 at (9,9) facing 73; Branch on Choice (54, 0); Warp Room -> Submap 1 at (240,89) facing 10; Warp Town -> Area 6 Map 73 Submap 60 at (24,1); Warp Room -> Submap 46 at (106,10) facing 9; Warp Room -> Submap 0 at (9,3) facing 9; Warp Town -> Area 47 Map 24 Submap 1 at (1,5); Engine Action #5; Engine Action #9; Warp Town -> Area 1 Map 30 Submap 73 at (45,5); Warp Room -> Submap 0 at (5,5) facing Up (North); Open Dialogue Message Window; Dismiss Emotion Bubble (24); Warp Room -> Submap 7 at (73,20) facing 40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 1 Map 8 Submap 1 at (9,41); Warp Town -> Area 0 Map 1 Submap 255 at (0,24); Warp Room -> Submap 10 at (51,2) facing 255; Warp Room -> Submap 1 at (1,11) facing 255; Warp Town -> Area 5 Map 1 Submap 0 at (0,5); Engine Action #5; Warp to Castle HQ (0, 6, 1); Engine Action #6; Warp Room -> Submap 49 at (2,5) facing West (Left); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Exit to World Map (4, 4, 2); Warp Room -> Submap 255 at (254,5) facing 9; Engine Action #5; Dismiss Emotion Bubble (4); Exit to World Map (2, 1, 30); Walk obj[24] to (1,1); Display Dialogue Box [Bank: 73, MsgID: 20]; Dismiss Character to Castle Base (24); Warp Room -> Submap 44 at (5,0); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 101, 4); Engine Action #6; Engine Action #5; Open Dialogue Message Window; Warp Town -> Area 0 Map 5 Submap 3 at (1,0); Engine Action #5; Warp to Castle HQ (3, 0, 5); Warp to Castle HQ (0, 0, 5); Warp to Castle HQ (30, 89, 0); Warp Town -> Area 8 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Engine Action #89; Open Dialogue Message Window; Warp Town -> Area 9 Map 5 Submap 0 at (6,2); Dismiss Emotion Bubble (89); Open Dialogue Message Window; Warp Town -> Area 10 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Dismiss Emotion Bubble (0); Warp Room -> Submap 5 at (0,0) facing South (Down); Engine Action #5; Show Dialogue Portrait (3, 0, 30); Make obj[46] Visible (disp = 1); Open Shop Menu #5 (Type: 1); Open Shop Menu #5 (Type: 9); Teleport obj[49] to (2,48); Warp Room -> Submap 3 at (0,1) facing South (Down); Engine Action #9; Warp Room -> Submap 255 at (254,48) facing 9; Open Dialogue Message Window; Warp to Castle HQ (0, 1, 0); Engine Action #9; Warp Room -> Submap 255 at (254,50) facing 34; Dismiss Character to Castle Base (83); Open Save Crystal Menu (MSaveInit); Dismiss Character to Castle Base (83); Open Save Crystal Menu (MSaveInit); Engine Action #123; Warp Town -> Area 3 Map 5 Submap 30 at (3,0); Dismiss Emotion Bubble (2); Open Dialogue Message Window; Engine Action #9; Engine Action #160; Reset Camera Tracking (255) |

---

### Submap Layer `vb07_03` (Index 3)

- **Map Number (`mapno`)**: `3`
- **Battle Encounter Zone (`batlno`)**: `3` (Timer: `40`, Rate: `5`)
- **Entity Count (`okaz`)**: `4` Objects | **Script Count (`evkaz`)**: `9` Scripts

#### Complete Physical Entity Inventory (4 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 19)** | `0` | `(30, 30)` | `0x0` | Frame 19 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 20)** | `0` | `(30, 30)` | `0x0` | Frame 20 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | World Device | **Mechanism (ano 19)** | `0` | `(30, 34)` | `0x0` | Frame 19 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | World Device | **Mechanism (ano 20)** | `0` | `(30, 34)` | `0x0` | Frame 20 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(30, 30)` with state parameter `19`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(30, 30)` with state parameter `20`.
- **`obj[02]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(30, 34)` with state parameter `19`.
- **`obj[03]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(30, 34)` with state parameter `20`.


#### Complete Bytecode Script Catalog (9 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Always Passes (Unconditional) | Make obj[68] Hidden (disp = 0); Reset Camera Tracking (0); Clear Story Milestone Flag 96 (mask 96); Play CD / Ambient BGM Track (10); Open Dialogue Message Window; Clear Story Milestone Flag 96 (mask 96); Play CD / Ambient BGM Track (9); Open Dialogue Message Window; Clear Story Milestone Flag 96 (mask 96); Play CD / Ambient BGM Track (11); Open Dialogue Message Window; Clear Story Milestone Flag 96 (mask 96); Teleport obj[255] to (254,204) |
| `ev[01]` | `2 (Map Init)` | Treasure Byte 17 Bit 16 FRESH (Unopened) | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[02]` | `2 (Map Init)` | Treasure Byte 17 Bit 32 FRESH (Unopened) | Open Dialogue Message Window; Screen Fade Transition (255, 254, 204) |
| `ev[03]` | `2 (Map Init)` | Treasure Byte 17 Bit 16 LOOTED | Open Dialogue Message Window; Engine Action #9 |
| `ev[04]` | `2 (Map Init)` | Treasure Byte 17 Bit 32 LOOTED | Open Dialogue Message Window; Close Dialogue Window |
| `ev[05]` | `1 (Action / Talk)` | Treasure Byte 17 Bit 16 FRESH (Unopened) AND Target Inspected is obj[8] | Make obj[1] Hidden (disp = 0); Reset Camera Tracking (0); Engine Action #9; Teleport obj[101] to (4,7); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (1); Exit to World Map (0, 51, 16); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,17) facing 16; Warp Room -> Submap 1 at (9,0) facing 8; Teleport obj[255] to (254,255) |
| `ev[06]` | `1 (Action / Talk)` | Treasure Byte 17 Bit 32 FRESH (Unopened) AND Target Inspected is obj[10] | Make obj[1] Hidden (disp = 0); Screen Fade Transition (0, 11, 47); Jump to Bytecode Offset (4, 7); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (1); Exit to World Map (0, 56, 16); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,17) facing 32; Warp Room -> Submap 1 at (11,0) facing 10; Teleport obj[255] to (254,255) |
| `ev[07]` | `1 (Action / Talk)` | Player within Box [58..76, 2..76] AND Condition Check #77 AND Story Flag 0 (mask 255) SET | Wait for Audio / Window Sync (2); Display Dialogue Box [Bank: 0, MsgID: 28]; Reset Camera Tracking (255) |
| `ev[08]` | `1 (Action / Talk)` | Player within Box [131..133, 2..30] AND Condition Check #38 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 4, MsgID: 3]; Return to Previous Memory Map (255) |

---

### Submap Layer `vb07_04` (Index 4)

- **Map Number (`mapno`)**: `4`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `2` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (2 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [0..1, 2..20] AND Condition Check #45 | Display Dialogue Box [Bank: 3, MsgID: 130]; Return Warp to Castle Base (255, 254) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [58..60, 2..20] AND Condition Check #45 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 5, MsgID: 3]; Mark Chest Looted (Byte 255, Bit 254) |

---

### Submap Layer `vb07_05` (Index 5)

- **Map Number (`mapno`)**: `5`
- **Battle Encounter Zone (`batlno`)**: `3` (Timer: `40`, Rate: `5`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `3` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (3 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `128 (Loop)` | Player within Box [32..34, 2..48] AND Condition Check #50 AND Story Flag 1 (mask 255) SET | Warp Room -> Submap 0 at (1,8) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [0..1, 2..89] AND Condition Check #106 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 4, MsgID: 56]; Return Warp to Castle Base (255, 254) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [118..120, 2..25] AND Condition Check #45 AND Story Flag 3 (mask 255) SET | Warp Map Transition (3, 250, 0, 0, 255) |

---



## Location Map: `vb08`

- **Master Map Container**: `vb08.json`
- **Submap Layer Files**: vb08_00.json
- **Collision Grid Files**: vb08_map_00.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 8

### Submap Layer `vb08_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `2` Objects | **Script Count (`evkaz`)**: `22` Scripts

#### Complete Physical Entity Inventory (2 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Matilda Knight Guard** | `65106` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Matilda Knight Guard** | `65106` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Matilda Knight Guard)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Matilda Knight Guard)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.


#### Complete Bytecode Script Catalog (22 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [1..2, 2..76] AND Condition Check #88 AND Story Flag 2 (mask 255) SET | Jump to Bytecode Offset (9, 9); Warp Room -> Submap 2 at (12,1); Engine Action #117; Open Dialogue Message Window; Open Dialogue Message Window; Warp Map Transition (0, 0, 165, 64, 255) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [2..45, 2..88] AND Condition Check #89 AND Story Flag 0 (mask 255) SET | Jump to Bytecode Offset (9, 9); Warp Room -> Submap 2 at (12,1); Engine Action #117; Open Dialogue Message Window; Open Dialogue Message Window; Warp Map Transition (0, 0, 165, 64, 255) |
| `ev[02]` | `128 (Loop)` | Player within Box [4..40, 2..80] AND Condition Check #85 | Warp Room -> Submap 2 at (12,1) |
| `ev[03]` | `2 (Map Init)` | Always Passes (Unconditional) | Make obj[88] Hidden (disp = 0); Teleport obj[255] to (254,204) |
| `ev[04]` | `128 (Loop)` | Temp Event Flag #4 SET | Jump to Bytecode Offset (1, 1); Launch Tactical War Battle (4) |
| `ev[05]` | `2 (Map Init)` | Player within Box [6..6, 2..87] AND Condition Check #87 | Make obj[86] Hidden (disp = 0); Warp Room -> Submap 0 at (23,85) facing 47 |
| `ev[06]` | `1 (Action / Talk)` | Player within Box [3..18, 2..3] AND Target Inspected is obj[9] AND Player X within Range [255..254] | Engine Action #117; Open Dialogue Message Window; Open Dialogue Message Window; Jump to Bytecode Offset (9, 9); Close Dialogue Window; Warp Town -> Area 2 Map 40 Submap 69 at (1,101); Warp Room -> Submap 12 at (1,35) facing 118 |
| `ev[07]` | `2 (Map Init)` | Story Flag 164 (bit 128) CLEAR | Make obj[2] Hidden (disp = 0); Reset Camera Tracking (46); Remove Character from Active Party (2); Engine Action #9; Teleport obj[76] to (3,8); Warp Town -> Area 3 Map 9 Submap 2 at (0,8); Open Dialogue Message Window; Engine Action #9; Teleport obj[255] to (254,204) |
| `ev[08]` | `1 (Action / Talk)` | Story Flag 163 (bit 128) CLEAR AND Player within Box [42..44, 2..66] AND Condition Check #73 AND Story Flag 3 (mask 255) SET | Warp to Castle HQ (8, 2, 4); Open Dialogue Message Window; Open Shop Menu #9 (Type: 71); Warp to Castle HQ (0, 3, 3); Engine Action #9; Warp Room -> Submap 8 at (0,27) facing 5; Open Dialogue Message Window; Pan Camera (3, 0, 0); Engine Action #5; Exit to World Map (2, 0, 30); Warp to Castle HQ (9, 2, 255) |
| `ev[09]` | `1 (Action / Talk)` | Story Flag 163 (bit 128) CLEAR AND Player within Box [42..44, 2..74] AND Condition Check #82 AND Story Flag 3 (mask 255) SET | Warp to Castle HQ (9, 2, 4); Open Dialogue Message Window; Engine Action #44; Full Rest & Healing (Restore HP/MP); Engine Action #9; Warp to Castle HQ (0, 3, 3); Reset Camera Tracking (0); Close Dialogue Sub-Window (9); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Open Dialogue Message Window; Pan Camera (3, 0, 0); Engine Action #5; Exit to World Map (2, 0, 30); Warp to Castle HQ (8, 2, 255) |
| `ev[10]` | `1 (Action / Talk)` | Story Flag 164 (bit 4) CLEAR AND Story Flag 163 (bit 128) SET AND Player within Box [42..44, 2..66] AND Condition Check #73 AND Story Flag 3 (mask 255) SET | Warp to Castle HQ (8, 2, 4); Open Dialogue Message Window; Open Shop Menu #9 (Type: 71); Warp to Castle HQ (0, 3, 3); Engine Action #9; Warp Room -> Submap 8 at (0,27) facing 5; Open Dialogue Message Window; Pan Camera (3, 0, 0); Engine Action #5; Exit to World Map (2, 0, 30); Warp to Castle HQ (9, 2, 255) |
| `ev[11]` | `1 (Action / Talk)` | Story Flag 164 (bit 4) CLEAR AND Story Flag 163 (bit 128) SET AND Player within Box [42..44, 2..74] AND Condition Check #82 AND Story Flag 3 (mask 255) SET | Warp to Castle HQ (9, 2, 4); Open Dialogue Message Window; Engine Action #44; Full Rest & Healing (Restore HP/MP); Engine Action #9; Warp to Castle HQ (0, 3, 3); Reset Camera Tracking (0); Close Dialogue Sub-Window (9); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Open Dialogue Message Window; Pan Camera (3, 0, 0); Engine Action #5; Exit to World Map (2, 0, 30); Warp to Castle HQ (8, 2, 255) |
| `ev[12]` | `128 (Loop)` | Story Flag 164 (bit 4) SET AND Story Flag 164 (bit 8) CLEAR AND Story Flag 236 (bit 1) SET | Set Object Direction (0, 1); Engine Action #6; Jump to Bytecode Offset (1, 0); Screen Fade Transition (236, 1, 255) |
| `ev[13]` | `128 (Loop)` | Story Flag 164 (bit 4) SET AND Story Flag 164 (bit 8) CLEAR AND Story Flag 236 (bit 2) SET | Jump to Bytecode Offset (9, 9); Set Object Direction (0, 1); Open Choice Selection Menu (101, 1); Warp Room -> Submap 236 at (2,255) facing 254 |
| `ev[14]` | `1 (Action / Talk)` | Story Flag 164 (bit 4) SET AND Story Flag 164 (bit 8) CLEAR AND Player within Box [40..42, 2..66] AND Condition Check #82 AND Story Flag 3 (mask 16) SET AND Player within Box [20..16, 1..80] AND Star of Destiny #1 Recruited AND Character #16 Level >= 1 AND Inventory Holds Item #255 | Recruit Character into Active Party (48, 0); Reset Camera Tracking (2); Warp to Castle HQ (0, 0, 8); Warp to Castle HQ (0, 3, 3); Engine Action #9; Warp Town -> Area 33 Map 4 Submap 20 at (80,19); Execute Choice Result (46); Open Dialogue Message Window; Warp Room -> Submap 2 at (0,3) facing South (Down); Exit to World Map (47, 49, 4); Engine Action #5; Warp Room -> Submap 5 at (2,3) facing South (Down); Warp Room -> Submap 0 at (4,4) facing 30; Engine Action #5; Warp Town -> Area 4 Map 5 Submap 0 at (2,3); Open Dialogue Message Window; Exit to World Map (4, 30, 255); Engine Action #5; Warp to Castle HQ (4, 5, 0); Exit to World Map (3, 0, 4); Exit to World Map (30, 255, 254); Engine Action #5; Exit to World Map (4, 5, 2); Warp to Castle HQ (0, 3, 3); Open Dialogue Message Window; Exit to World Map (4, 30, 255); Walk obj[24] to (8,0); Warp Room -> Submap 2 at (3,3) facing South (Down); Warp Room -> Submap 3 at (8,0) facing East (Right); Engine Action #9; Warp Room -> Submap 2 at (0,2) facing 49; Warp Town -> Area 5 Map 2 Submap 5 at (15,3); Open Dialogue Message Window; Pan Camera (1, 30, 255); Engine Action #5; Engine Action #9; Warp to Castle HQ (1, 1, 2); Warp Town -> Area 0 Map 30 Submap 255 at (254,50); Warp to Castle HQ (2, 3, 24); Engine Action #9; Open Dialogue Message Window; Warp to Castle HQ (5, 3, 0); Warp Room -> Submap 5 at (1,0) facing 30; Warp to Castle HQ (9, 0, 24); Warp to Castle HQ (0, 4, 72); Warp Room -> Submap 9 at (5,9) facing 4; Warp Room -> Submap 0 at (7,1) facing 30; Load Sound Bank into Memory (0, 9); Close Dialogue Sub-Window (9); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Exit to World Map (4, 2, 3); Warp Town -> Area 6 Map 1 Submap 6 at (2,6); Warp Town -> Area 4 Map 4 Submap 30 at (24,4); Open Dialogue Message Window; Engine Action #6; Warp to Castle HQ (9, 2, 73); Clear Dialogue Sub-Window; Close Dialogue Sub-Window (9); Open Dialogue Message Window; Pan Camera (73, 120, 101); Engine Action #9; Animate Door Open; Engine Action #9; Engine Action #236; Warp Room -> Submap 1 at (4,2) facing West (Left); Warp to Castle HQ (3, 7, 0); Warp Room -> Submap 24 at (1,0) facing 8; Engine Action #5; Reset Camera Tracking (2); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp Room -> Submap 30 at (72,1) facing 8; Warp to Castle HQ (3, 9, 1); Close Dialogue Sub-Window (8); Open Dialogue Message Window; Engine Action #9; Load Sound Bank into Memory (0, 8); Engine Action #5; Warp Room -> Submap 1 at (0,0) facing 30; Warp to Castle HQ (2, 1, 24); Warp Room -> Submap 10 at (3,4) facing West (Left); Set Entity Movement Speed (2, 5); Warp Room -> Submap 3 at (3,14) facing West (Left); Set Story Flag (4, 4); Dismiss Emotion Bubble (255); Engine Action #5; Reset Camera Tracking (5); Dismiss Emotion Bubble (4); Warp to Castle HQ (3, 14, 5); Engine Action #5; Warp Room -> Submap 4 at (4,30) facing 255; Walk obj[11] to (2,2); Engine Action #40; Set Combat Battle BGM (120); Close Dialogue Window; Warp Room -> Submap 40 at (36,1) facing 73; Make obj[24] Visible (disp = 1); Reset Camera Tracking (0); Close Dialogue Window; Engine Action #54; Open Dialogue Message Window; Warp Room -> Submap 2 at (3,0) facing 5; Show Dialogue Portrait (0, 0, 5); Show Dialogue Portrait (3, 0, 5); Engine Action #5; Warp Room -> Submap 5 at (15,30) facing 24; Warp Town -> Area 0 Map 12 Submap 24 at (1,0); Place Scenery Structure (5); Warp to Castle HQ (4, 2, 2); Warp Town -> Area 1 Map 1 Submap 30 at (24,3); Open Dialogue Message Window; Animate Door Open; Warp to Castle HQ (1, 0, 24); Warp Room -> Submap 15 at (49,2) facing 5; Exit to World Map (3, 0, 6); Warp Town -> Area 6 Map 2 Submap 30 at (255,254); Engine Action #5; Warp Town -> Area 2 Map 0 Submap 5 at (45,0); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Walk obj[24] to (2,0); Dismiss Dialogue Portrait; Engine Action #5; Engine Action #9; Warp Town -> Area 0 Map 30 Submap 49 at (5,5); Warp Room -> Submap 4 at (1,2) facing East (Right); Screen Fade Transition (0, 0, 5); Engine Action #5; Warp Town -> Area 0 Map 30 Submap 255 at (254,5); Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (4, 4, 1); Exit to World Map (3, 13, 0); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Warp Town -> Area 4 Map 4 Submap 5 at (25,3); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp Room -> Submap 5 at (3,3) facing 8; Dismiss Emotion Bubble (255); Engine Action #5; Exit to World Map (4, 4, 5); Start Boss Battle #1 (BGM: 7); Warp to Castle HQ (8, 30, 255); Engine Action #5; Warp to Castle HQ (4, 4, 5); Walk obj[1] to (5,3); Engine Action #6; Dismiss Emotion Bubble (255); Walk obj[24] to (2,0); Change Portrait Expression (24); Warp Room -> Submap 18 at (9,236) facing Up (North); Set Combat Battle BGM (5); Engine Action #39; Return Warp to Castle Base (58, 9); Engine Action #164; Reset Camera Tracking (255) |
| `ev[15]` | `128 (Loop)` | Story Flag 164 (bit 4) SET AND Story Flag 164 (bit 8) CLEAR AND Inventory Holds Item #1 | Set Entity Movement Speed (2, 5); Warp Room -> Submap 23 at (2,16) facing South (Down); Open Dialogue Message Window; Engine Action #5; Exit to World Map (3, 0, 30); Engine Action #5; Reset Camera Tracking (5); Engine Action #120; Open Dialogue Message Window; Open Dialogue Sub-Window (2); Close Dialogue Window; Dismiss Emotion Bubble (255); Walk obj[37] to (1,255) |
| `ev[16]` | `1 (Action / Talk)` | Story Flag 164 (bit 8) SET AND Story Flag 165 (bit 1) CLEAR AND Target Inspected is obj[8] | Close Dialogue Sub-Window (8); Open Dialogue Message Window; Display Chapter Text (3); Reset Camera Tracking (2) |
| `ev[17]` | `1 (Action / Talk)` | Story Flag 164 (bit 8) SET AND Story Flag 165 (bit 1) CLEAR AND Target Inspected is obj[9] | Close Dialogue Sub-Window (9); Open Dialogue Message Window; Display Emotion Bubble (3, 9); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[18]` | `2 (Map Init)` | Story Flag 4 (bit 128) SET AND Player within Box [6..6, 2..87] AND Condition Check #87 | Make obj[36] Hidden (disp = 0); Warp Town -> Area 2 Map 8 Submap 46 at (71,2); Engine Action #9; Teleport obj[76] to (3,8); Warp Town -> Area 3 Map 9 Submap 2 at (0,8); Open Dialogue Message Window; Engine Action #9; Teleport obj[255] to (254,204) |
| `ev[19]` | `1 (Action / Talk)` | Story Flag 4 (bit 128) SET AND Story Flag 164 (bit 8) SET AND Inventory Holds Item #2 AND Player within Box [42..44, 2..66] AND Condition Check #82 AND Story Flag 3 (mask 16) SET AND Always Passes (Unconditional) AND Party Member Count == 255 | Warp to Castle HQ (9, 2, 4); Open Dialogue Message Window; Engine Action #44; Full Rest & Healing (Restore HP/MP); Engine Action #9; Warp to Castle HQ (0, 3, 3); Reset Camera Tracking (0); Close Dialogue Sub-Window (9); Warp Town -> Area 0 Map 5 Submap 0 at (7,3); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Exit to World Map (2, 0, 30); Warp to Castle HQ (8, 2, 255) |
| `ev[20]` | `1 (Action / Talk)` | Story Flag 4 (bit 128) SET AND Story Flag 164 (bit 8) SET AND Story Flag 165 (bit 1) CLEAR AND Inventory Holds Item #2 AND Player within Box [40..42, 2..66] AND Condition Check #82 AND Story Flag 3 (mask 16) SET AND Player within Box [80..16, 1..18] | Turn obj[0] facing 8; Warp Town -> Area 3 Map 0 Submap 0 at (8,3); Open Dialogue Message Window; Warp to Castle HQ (3, 9, 2); Return to Previous Memory Map (2); Display Speaker Name Box (80); Make obj[0] Hidden (disp = 0); Warp Room -> Submap 2 at (0,3) facing South (Down); Exit to World Map (0, 5, 0); Engine Action #6; Open Dialogue Message Window; Pan Camera (47, 49, 7); Engine Action #5; Warp Room -> Submap 5 at (2,3) facing West (Left); Warp Room -> Submap 0 at (30,255) facing 254; Engine Action #5; Warp Town -> Area 4 Map 5 Submap 0 at (3,3); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Warp to Castle HQ (4, 5, 0); Engine Action #6; Warp to Castle HQ (0, 30, 255); Engine Action #5; Exit to World Map (4, 5, 2); Warp to Castle HQ (0, 2, 3); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Engine Action #5; Exit to World Map (5, 2, 3); Open Dialogue Message Window; Engine Action #5; Warp to Castle HQ (0, 30, 255); Engine Action #5; Engine Action #6; Exit to World Map (5, 2, 6); Open Dialogue Message Window; Warp Room -> Submap 0 at (30,255) facing 254; Engine Action #5; Pan Camera (4, 5, 2); Engine Action #6; Open Dialogue Message Window; Exit to World Map (3, 0, 30); Walk obj[24] to (8,2); Open Dialogue Message Window; Set Combat Battle BGM (24); Engine Action #9; Engine Action #236; Exit to World Map (5, 1, 4); Warp Town -> Area 1 Map 1 Submap 3 at (7,0); Warp Room -> Submap 24 at (1,2) facing West (Left); Warp to Castle HQ (8, 1, 72); Warp Room -> Submap 3 at (3,9) facing West (Left); Close Dialogue Sub-Window (8); Warp Town -> Area 2 Map 72 Submap 0 at (8,3); Warp Town -> Area 1 Map 3 Submap 3 at (1,24); Warp Room -> Submap 3 at (49,2) facing 5; Warp Room -> Submap 3 at (3,14) facing West (Left); Set Story Flag (30, 255); Engine Action #5; Reset Camera Tracking (5); Dismiss Emotion Bubble (4); Warp to Castle HQ (3, 14, 5); Engine Action #5; Warp Room -> Submap 30 at (255,254) facing 50; Close Dialogue Window; Warp Town -> Area 2 Map 40 Submap 9 at (236,8); Set Combat Battle BGM (60); Jump to Bytecode Offset (4, 18); Set Combat Battle BGM (12); Jump to Bytecode Offset (4, 23); Set Combat Battle BGM (3); Jump to Bytecode Offset (4, 24); Set Combat Battle BGM (2); Jump to Bytecode Offset (4, 23); Set Combat Battle BGM (6); Jump to Bytecode Offset (4, 22); Jump to Bytecode Offset (4, 16); Set Combat Battle BGM (3); Jump to Bytecode Offset (4, 24); Set Combat Battle BGM (2); Jump to Bytecode Offset (4, 23); Set Combat Battle BGM (12); Jump to Bytecode Offset (4, 18); Set Combat Battle BGM (3); Jump to Bytecode Offset (4, 18); Set Combat Battle BGM (12); Jump to Bytecode Offset (4, 23); Set Combat Battle BGM (3); Jump to Bytecode Offset (4, 24); Set Combat Battle BGM (2); Jump to Bytecode Offset (4, 23); Set Combat Battle BGM (6); Jump to Bytecode Offset (4, 22); Jump to Bytecode Offset (4, 24); Set Combat Battle BGM (2); Jump to Bytecode Offset (4, 23); Set Combat Battle BGM (6); Jump to Bytecode Offset (4, 22); Engine Action #9; Engine Action #236; Dismiss Dialogue Portrait; Warp Town -> Area 8 Map 60 Submap 44 at (2,1); Set obj[43] Collision to Passable; Warp Room -> Submap 9 at (72,1) facing 8; Close Dialogue Window; Close Dialogue Window; Warp Room -> Submap 40 at (49,2) facing 5; Reset Camera Tracking (0); Fade Out to Black (2); Animate Door Open; Dismiss Emotion Bubble (255); Engine Action #5; Warp Room -> Submap 0 at (7,27) facing 5; Close Dialogue Sub-Window (3); Open Dialogue Message Window; Pan Camera (13, 4, 6); Pan Camera (6, 4, 5); Open Dialogue Message Window; Warp Room -> Submap 0 at (30,255) facing 254; Walk obj[3] to (0,2); Warp to Castle HQ (3, 1, 72); Open Dialogue Message Window; Warp Room -> Submap 8 at (2,4) facing 72; Open Dialogue Message Window; Reset Camera Tracking (24); Warp Room -> Submap 5 at (39,34) facing 9; Engine Action #165; Warp Room -> Submap 0 at (0,0) facing 5; Engine Action #5; Warp Town -> Area 3 Map 30 Submap 255 at (254,204) |
| `ev[21]` | `1 (Action / Talk)` | Story Flag 4 (bit 128) SET AND Story Flag 165 (bit 1) SET AND Inventory Holds Item #2 AND Player within Box [40..42, 2..66] AND Condition Check #82 AND Story Flag 3 (mask 16) SET AND Player within Box [80..16, 1..18] | Turn obj[0] facing 8; Warp Town -> Area 3 Map 0 Submap 0 at (8,3); Open Dialogue Message Window; Warp to Castle HQ (3, 9, 2); Close Dialogue Sub-Window (8); Warp Town -> Area 6 Map 72 Submap 1 at (0,9); Engine Action #5; Open Dialogue Message Window; Exit to World Map (5, 0, 0); Engine Action #5; Exit to World Map (2, 5, 4); Exit to World Map (30, 72, 0); Open Dialogue Message Window |

---

### Submap Layer `vb08_01` (Index 1)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `50`, Rate: `7`)
- **Entity Count (`okaz`)**: `3` Objects | **Script Count (`evkaz`)**: `7` Scripts

#### Complete Physical Entity Inventory (3 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 11)** | `0` | `(23, 16)` | `0x0` | Frame 11 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | Rest Device / Fire | **Inn Bed / Recovery Device** | `0` | `(23, 16)` | `0x0` | Frame 12 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | Trigger / Hitbox | **Hitbox Zone (6x6)** | `0` | `(12, 15)` | `5x5` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(23, 16)` with state parameter `11`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(23, 16)` with state parameter `12`.
- **`obj[02]` (Hitbox Zone)**: Bounding trigger area covering `6` tiles wide by `6` tiles high from `(12, 15)` to `(17, 20)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (7 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Always Passes (Unconditional) | Make obj[88] Hidden (disp = 0); Teleport obj[255] to (254,204) |
| `ev[01]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Engine Action #44; Load Sound Bank into Memory (1, 0); Open Dialogue Message Window; Engine Action #5; Open Dialogue Message Window; Exit to World Map (5, 6, 1); Exit to World Map (4, 30, 72); Open Dialogue Message Window; Open Dialogue Message Window; Make obj[101] Visible (disp = 1); Exit to World Map (49, 103, 26); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[02]` | `2 (Map Init)` | Treasure Byte 17 Bit 8 FRESH (Unopened) | Make obj[0] Hidden (disp = 0); Reset Camera Tracking (47) |
| `ev[03]` | `2 (Map Init)` | Treasure Byte 17 Bit 8 LOOTED | Make obj[0] Hidden (disp = 0); Engine Action #9; Teleport obj[255] to (254,204) |
| `ev[04]` | `1 (Action / Talk)` | Treasure Byte 17 Bit 8 FRESH (Unopened) AND Target Inspected is obj[8] | Make obj[1] Hidden (disp = 0); Reset Camera Tracking (0); Engine Action #9; Teleport obj[101] to (4,7); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (1); Exit to World Map (0, 8, 0); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,17) facing 8; Warp Room -> Submap 1 at (9,0) facing 8; Teleport obj[255] to (254,255) |
| `ev[05]` | `1 (Action / Talk)` | Player within Box [16..44, 2..121] AND Condition Check #123 AND Story Flag 0 (mask 255) SET | Jump to Bytecode Offset (9, 9); Close Dialogue Window; Warp Town -> Area 2 Map 40 Submap 69 at (1,101); Warp Room -> Submap 12 at (0,12) facing 8 |
| `ev[06]` | `1 (Action / Talk)` | Player within Box [96..115, 2..4] AND Inventory Holds Item #9 AND Player X within Range [255..254] | Display Dialogue Box [Bank: 2, MsgID: 43]; Engine Action #118 |

---

### Submap Layer `vb08_02` (Index 2)

- **Map Number (`mapno`)**: `2`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `50`, Rate: `7`)
- **Entity Count (`okaz`)**: `2` Objects | **Script Count (`evkaz`)**: `6` Scripts

#### Complete Physical Entity Inventory (2 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 11)** | `0` | `(105, 68)` | `0x0` | Frame 11 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | Rest Device / Fire | **Inn Bed / Recovery Device** | `0` | `(105, 68)` | `0x0` | Frame 12 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(105, 68)` with state parameter `11`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(105, 68)` with state parameter `12`.


#### Complete Bytecode Script Catalog (6 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Always Passes (Unconditional) | Make obj[88] Hidden (disp = 0); Teleport obj[255] to (254,204) |
| `ev[01]` | `2 (Map Init)` | Treasure Byte 17 Bit 1 FRESH (Unopened) | Make obj[0] Hidden (disp = 0); Reset Camera Tracking (47) |
| `ev[02]` | `2 (Map Init)` | Treasure Byte 17 Bit 1 LOOTED | Make obj[0] Hidden (disp = 0); Engine Action #9; Teleport obj[255] to (254,204) |
| `ev[03]` | `1 (Action / Talk)` | Treasure Byte 17 Bit 1 FRESH (Unopened) AND Target Inspected is obj[8] | Make obj[1] Hidden (disp = 0); Reset Camera Tracking (0); Engine Action #9; Teleport obj[101] to (4,7); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (1); Exit to World Map (0, 34, 0); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,17) facing West (Left); Warp Room -> Submap 1 at (9,0) facing 8; Teleport obj[255] to (254,255) |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [24..54, 2..121] AND Condition Check #124 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 103]; Reset Camera Tracking (255) |
| `ev[05]` | `1 (Action / Talk)` | Player within Box [42..60, 2..4] AND Inventory Holds Item #9 AND Player X within Range [255..254] | Display Dialogue Box [Bank: 3, MsgID: 85]; Engine Action #174 |

---

### Submap Layer `vb08_03` (Index 3)

- **Map Number (`mapno`)**: `3`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `50`, Rate: `7`)
- **Entity Count (`okaz`)**: `2` Objects | **Script Count (`evkaz`)**: `6` Scripts

#### Complete Physical Entity Inventory (2 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | Rest Device / Fire | **Inn Bed / Recovery Device** | `0` | `(90, 86)` | `0x0` | Frame 12 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 11)** | `0` | `(90, 86)` | `0x0` | Frame 11 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(90, 86)` with state parameter `12`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(90, 86)` with state parameter `11`.


#### Complete Bytecode Script Catalog (6 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Always Passes (Unconditional) | Make obj[88] Hidden (disp = 0); Teleport obj[255] to (254,204) |
| `ev[01]` | `2 (Map Init)` | Treasure Byte 17 Bit 2 FRESH (Unopened) | Make obj[0] Hidden (disp = 0); Engine Action #9; Teleport obj[255] to (254,204) |
| `ev[02]` | `2 (Map Init)` | Treasure Byte 17 Bit 2 LOOTED | Make obj[0] Hidden (disp = 0); Reset Camera Tracking (47) |
| `ev[03]` | `1 (Action / Talk)` | Treasure Byte 17 Bit 2 FRESH (Unopened) AND Target Inspected is obj[9] | Make obj[1] Hidden (disp = 0); Engine Action #9; Open Dialogue Message Window; Reset Camera Tracking (47); Jump to Bytecode Offset (4, 7); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (1); Exit to World Map (0, 16, 16); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,17) facing Up (North); Warp Room -> Submap 1 at (8,0) facing 9; Teleport obj[255] to (254,255) |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [76..98, 2..176] AND Condition Check #179 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 50]; Reset Camera Tracking (255) |
| `ev[05]` | `1 (Action / Talk)` | Player within Box [29..56, 2..4] AND Inventory Holds Item #9 AND Player X within Range [255..254] | Display Dialogue Box [Bank: 4, MsgID: 12]; Engine Action #110 |

---

### Submap Layer `vb08_04` (Index 4)

- **Map Number (`mapno`)**: `4`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `50`, Rate: `7`)
- **Entity Count (`okaz`)**: `1` Objects | **Script Count (`evkaz`)**: `9` Scripts

#### Complete Physical Entity Inventory (1 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | Rest Device / Fire | **Inn Bed / Recovery Device** | `0` | `(63, 94)` | `0x0` | Frame 13 | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(63, 94)` with state parameter `13`.


#### Complete Bytecode Script Catalog (9 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Target Inspected is obj[8] | Launch Tactical War Battle (4); Fade In from Black (3); Exit to World Map (73, 20, 40); Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 3 Map 2 Submap 3 at (3,73); Branch on Choice (41, 2); Open Dialogue Message Window; Warp Room -> Submap 0 at (54,0) facing 4; Recruit Riou (Hero) into Battle Slot 1; Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[01]` | `128 (Loop)` | Inventory Holds Item #4 | Warp Room -> Submap 1 at (13,45); Toggle Random Encounters (4) |
| `ev[02]` | `2 (Map Init)` | Always Passes (Unconditional) | Make obj[88] Hidden (disp = 0); Teleport obj[255] to (254,204) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [0..20, 2..113] AND Condition Check #120 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 3, MsgID: 42]; Reset Camera Tracking (255) |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [1..2, 2..109] AND Condition Check #115 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 3, MsgID: 42]; Reset Camera Tracking (255) |
| `ev[05]` | `1 (Action / Talk)` | Player within Box [60..74, 2..4] AND Inventory Holds Item #9 AND Player X within Range [255..254] | Display Dialogue Box [Bank: 5, MsgID: 11]; Engine Action #88 |
| `ev[06]` | `128 (Loop)` | Story Flag 164 (bit 8) SET AND Story Flag 164 (bit 16) CLEAR AND Story Flag 236 (bit 1) SET | Warp Room -> Submap 1 at (15,0); Screen Fade Transition (236, 1, 255) |
| `ev[07]` | `1 (Action / Talk)` | Story Flag 164 (bit 8) SET AND Story Flag 164 (bit 16) CLEAR AND Player within Box [36..52, 2..72] AND Condition Check #73 AND Star of Destiny #1 Recruited AND Castle HQ Tier >= Level 16 AND Player within Box [80..16, 1..19] AND Star of Destiny #1 Recruited AND Inventory Holds Item #9 AND Player X within Range [255..254] | Engine Action #9; Engine Action #236; Warp Room -> Submap 4 at (0,45) facing 60; Reset Camera Tracking (33); Exit to World Map (80, 19, 20); Execute Choice Result (46); Open Dialogue Message Window; Warp Room -> Submap 2 at (0,3) facing South (Down); Exit to World Map (47, 49, 4); Engine Action #5; Warp Room -> Submap 5 at (3,3) facing West (Left); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Exit to World Map (4, 30, 255); Engine Action #5; Warp Town -> Area 4 Map 5 Submap 2 at (3,1); Open Dialogue Message Window; Exit to World Map (4, 30, 255); Engine Action #5; Warp to Castle HQ (4, 5, 0); Warp to Castle HQ (3, 2, 1); Open Dialogue Message Window; Exit to World Map (4, 30, 255); Engine Action #5; Exit to World Map (4, 5, 0); Warp to Castle HQ (2, 2, 1); Open Dialogue Message Window; Exit to World Map (4, 30, 255); Walk obj[24] to (2,0); Display Choice Selection (3, 1); Warp Town -> Area 24 Map 1 Submap 0 at (20,58); Jump to Bytecode Offset (9, 9); Set Combat Battle BGM (30); Wait for Audio / Window Sync (2); Engine Action #53; Open Dialogue Message Window; Engine Action #236; Warp Room -> Submap 1 at (240,74) facing West (Left); Wait for Audio / Window Sync (3); Place Scenery Structure (5); Warp Room -> Submap 4 at (45,60) facing 255 |
| `ev[08]` | `1 (Action / Talk)` | Story Flag 164 (bit 16) SET AND Story Flag 164 (bit 32) CLEAR | Close Dialogue Sub-Window (2); Open Dialogue Message Window; Execute Choice Result (24); Warp Room -> Submap 22 at (5,4) facing 6; Warp to Castle HQ (6, 3, 6); Warp to Castle HQ (30, 49, 2); Engine Action #5; Warp Town -> Area 3 Map 0 Submap 5 at (5,0); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Warp to Castle HQ (2, 0, 30); Walk obj[24] to (4,0); Open Dialogue Sub-Window (5); Exit to World Map (6, 2, 6); Warp Town -> Area 6 Map 2 Submap 30 at (24,3); Open Dialogue Message Window; Close Dialogue Sub-Window (39); Return Warp to Castle Base (9, 164); Warp Map Transition (255, 254, 204, 204, 204) |

---

### Submap Layer `vb08_05` (Index 5)

- **Map Number (`mapno`)**: `5`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `50`, Rate: `7`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `4` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (4 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Always Passes (Unconditional) | Make obj[88] Hidden (disp = 0); Teleport obj[255] to (254,204) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [2..20, 2..90] AND Condition Check #92 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 4, MsgID: 67]; Reset Camera Tracking (255) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [125..129, 2..18] AND Condition Check #34 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 6, MsgID: 4]; Place Scenery Structure (255) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [56..74, 2..4] AND Inventory Holds Item #9 AND Player X within Range [255..254] | Display Dialogue Box [Bank: 7, MsgID: 15]; Engine Action #58 |

---

### Submap Layer `vb08_06` (Index 6)

- **Map Number (`mapno`)**: `6`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `50`, Rate: `7`)
- **Entity Count (`okaz`)**: `2` Objects | **Script Count (`evkaz`)**: `5` Scripts

#### Complete Physical Entity Inventory (2 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 11)** | `0` | `(61, 13)` | `0x0` | Frame 11 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | Rest Device / Fire | **Inn Bed / Recovery Device** | `0` | `(61, 13)` | `0x0` | Frame 12 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(61, 13)` with state parameter `11`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(61, 13)` with state parameter `12`.


#### Complete Bytecode Script Catalog (5 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Always Passes (Unconditional) | Make obj[88] Hidden (disp = 0); Teleport obj[255] to (254,204) |
| `ev[01]` | `2 (Map Init)` | Treasure Byte 17 Bit 4 FRESH (Unopened) | Make obj[0] Hidden (disp = 0); Reset Camera Tracking (47) |
| `ev[02]` | `2 (Map Init)` | Treasure Byte 17 Bit 4 LOOTED | Make obj[0] Hidden (disp = 0); Engine Action #9; Teleport obj[255] to (254,204) |
| `ev[03]` | `1 (Action / Talk)` | Treasure Byte 17 Bit 4 FRESH (Unopened) AND Target Inspected is obj[8] | Make obj[1] Hidden (disp = 0); Reset Camera Tracking (0); Engine Action #9; Teleport obj[101] to (4,7); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (1); Exit to World Map (0, 3, 16); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,17) facing 4; Warp Room -> Submap 1 at (9,0) facing 8; Teleport obj[255] to (254,255) |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [1..2, 2..6] AND Castle HQ Tier >= Level 9 AND Player Y within Range [255..254] | Display Dialogue Box [Bank: 5, MsgID: 122]; Fade Out to Black (255) |

---

### Submap Layer `vb08_07` (Index 7)

- **Map Number (`mapno`)**: `7`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `50`, Rate: `7`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `6` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (6 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Always Passes (Unconditional) | Make obj[88] Hidden (disp = 0); Teleport obj[255] to (254,204) |
| `ev[01]` | `2 (Map Init)` | Player within Box [26..26, 2..9] AND Story Flag 255 (mask 254) SET | Make obj[47] Hidden (disp = 0) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [8..26, 2..60] AND Condition Check #62 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 5, MsgID: 65]; Reset Camera Tracking (255) |
| `ev[03]` | `128 (Loop)` | Player within Box [10..40, 2..8] AND Active Party Has Character #255 | Warp Room -> Submap 2 at (12,0) |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [14..36, 2..4] AND Inventory Holds Item #9 AND Player X within Range [255..254] | Jump to Bytecode Offset (9, 9); Warp Map Transition (0, 0, 57, 129, 255) |
| `ev[05]` | `1 (Action / Talk)` | Story Flag 164 (bit 32) SET AND Story Flag 164 (bit 64) CLEAR AND Player within Box [22..30, 2..21] AND Inventory Holds Item #16 AND Player within Box [20..16, 1..80] AND Star of Destiny #1 Recruited AND Character #16 Level >= 1 AND Inventory Holds Item #9 AND Player X within Range [255..254] | Recruit Character into Active Party (31, 2); Display Dialogue Box [Bank: 0, MsgID: 4]; Open Dialogue Message Window; Fade In from Black (15); Reset Camera Tracking (33); Exit to World Map (80, 19, 20); Execute Choice Result (46); Open Dialogue Message Window; Warp Room -> Submap 2 at (0,3) facing South (Down); Exit to World Map (47, 49, 4); Engine Action #5; Warp Room -> Submap 5 at (3,4) facing West (Left); Open Dialogue Message Window; Engine Action #5; Exit to World Map (2, 0, 30); Engine Action #5; Warp Town -> Area 4 Map 5 Submap 2 at (4,1); Open Dialogue Message Window; Engine Action #5; Exit to World Map (3, 0, 30); Engine Action #5; Warp to Castle HQ (4, 5, 0); Warp Town -> Area 3 Map 2 Submap 1 at (0,30); Engine Action #5; Exit to World Map (4, 5, 0); Warp to Castle HQ (2, 2, 1); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Walk obj[3] to (1,2); Warp to Castle HQ (0, 3, 24); Warp Room -> Submap 25 at (5,2) facing 4; Warp Town -> Area 3 Map 1 Submap 30 at (5,0); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp Town -> Area 0 Map 30 Submap 24 at (2,0); Fade In from Black (11); Warp Town -> Area 2 Map 240 Submap 69 at (1,58); Engine Action #9; Engine Action #164; Animate Doorway State (101, 9); Engine Action #9; Warp Map Transition (0, 0, 57, 129, 255) |

---



## Location Map: `vb17`

- **Master Map Container**: `vb17.json`
- **Submap Layer Files**: vb17_00.json, vb17_01.json
- **Collision Grid Files**: None
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 8

### Submap Layer `vb17_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `4` Objects | **Script Count (`evkaz`)**: `23` Scripts

#### Complete Physical Entity Inventory (4 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Matilda Knight Guard** | `65106` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Matilda Knight Guard** | `65106` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Actor ID 65104** | `65104` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | NPC / Actor | **Actor ID 65104** | `65104` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Matilda Knight Guard)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Matilda Knight Guard)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Object 65104)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Object 65104)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.


#### Complete Bytecode Script Catalog (23 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 4 (bit 128) SET | Engine Action #121; Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [1..2, 2..76] AND Condition Check #88 AND Story Flag 2 (mask 255) SET | Jump to Bytecode Offset (9, 9); Warp Room -> Submap 2 at (12,1); Engine Action #117; Open Dialogue Message Window; Open Dialogue Message Window; Warp Map Transition (0, 0, 165, 64, 255) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [2..45, 2..88] AND Condition Check #89 AND Story Flag 0 (mask 255) SET | Jump to Bytecode Offset (9, 9); Warp Room -> Submap 2 at (12,1); Engine Action #117; Open Dialogue Message Window; Open Dialogue Message Window; Warp Map Transition (0, 0, 165, 64, 255) |
| `ev[03]` | `128 (Loop)` | Player within Box [4..40, 2..80] AND Condition Check #85 | Warp Room -> Submap 2 at (12,1) |
| `ev[04]` | `2 (Map Init)` | Always Passes (Unconditional) | Make obj[88] Hidden (disp = 0); Teleport obj[255] to (254,204) |
| `ev[05]` | `128 (Loop)` | Temp Event Flag #4 SET | Jump to Bytecode Offset (1, 1); Launch Tactical War Battle (4) |
| `ev[06]` | `2 (Map Init)` | Player within Box [6..6, 2..87] AND Condition Check #87 | Make obj[86] Hidden (disp = 0); Warp Room -> Submap 0 at (23,85) facing 47 |
| `ev[07]` | `1 (Action / Talk)` | Player within Box [3..18, 2..3] AND Target Inspected is obj[9] AND Player X within Range [255..254] | Engine Action #117; Open Dialogue Message Window; Open Dialogue Message Window; Jump to Bytecode Offset (9, 9); Close Dialogue Window; Warp Town -> Area 2 Map 40 Submap 69 at (1,101); Warp Room -> Submap 12 at (1,35) facing 118 |
| `ev[08]` | `2 (Map Init)` | Story Flag 164 (bit 128) CLEAR AND Story Flag 171 (bit 1) CLEAR | Make obj[2] Hidden (disp = 0); Reset Camera Tracking (46); Remove Character from Active Party (2); Engine Action #9; Teleport obj[76] to (3,8); Warp Town -> Area 3 Map 9 Submap 2 at (0,8); Open Dialogue Message Window; Engine Action #9; Teleport obj[255] to (254,204) |
| `ev[09]` | `2 (Map Init)` | Story Flag 4 (bit 128) SET AND Story Flag 171 (bit 1) CLEAR AND Player within Box [6..6, 2..87] AND Condition Check #87 | Make obj[36] Hidden (disp = 0); Warp Town -> Area 2 Map 8 Submap 46 at (71,2); Engine Action #9; Teleport obj[76] to (3,8); Warp Town -> Area 3 Map 9 Submap 2 at (0,8); Open Dialogue Message Window; Engine Action #9; Teleport obj[255] to (254,204) |
| `ev[10]` | `1 (Action / Talk)` | Story Flag 166 (bit 1) SET AND Story Flag 171 (bit 1) CLEAR AND Inventory Holds Item #2 AND Player within Box [42..44, 2..66] AND Condition Check #82 AND Story Flag 3 (mask 16) SET AND Always Passes (Unconditional) AND Party Member Count == 255 | Warp to Castle HQ (9, 2, 4); Open Dialogue Message Window; Engine Action #44; Full Rest & Healing (Restore HP/MP); Engine Action #9; Warp to Castle HQ (0, 3, 3); Reset Camera Tracking (0); Close Dialogue Sub-Window (9); Warp Town -> Area 0 Map 5 Submap 0 at (7,3); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Exit to World Map (2, 0, 30); Warp to Castle HQ (8, 2, 255) |
| `ev[11]` | `1 (Action / Talk)` | Story Flag 166 (bit 1) SET AND Story Flag 165 (bit 1) CLEAR AND Story Flag 171 (bit 1) CLEAR AND Inventory Holds Item #2 AND Player within Box [40..42, 2..66] AND Condition Check #82 AND Story Flag 3 (mask 16) SET AND Player within Box [80..16, 1..18] | Turn obj[0] facing 8; Warp Town -> Area 3 Map 0 Submap 0 at (8,3); Open Dialogue Message Window; Warp to Castle HQ (3, 9, 2); Return to Previous Memory Map (2); Display Speaker Name Box (80); Make obj[0] Hidden (disp = 0); Warp Room -> Submap 2 at (0,3) facing South (Down); Exit to World Map (0, 5, 0); Engine Action #6; Open Dialogue Message Window; Pan Camera (47, 49, 7); Engine Action #5; Warp Room -> Submap 5 at (2,3) facing West (Left); Warp Room -> Submap 0 at (30,255) facing 254; Engine Action #5; Warp Town -> Area 4 Map 5 Submap 0 at (3,3); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Warp to Castle HQ (4, 5, 0); Engine Action #6; Warp to Castle HQ (0, 30, 255); Engine Action #5; Exit to World Map (4, 5, 2); Warp to Castle HQ (0, 2, 3); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Engine Action #5; Exit to World Map (5, 2, 3); Open Dialogue Message Window; Engine Action #5; Warp to Castle HQ (0, 30, 255); Engine Action #5; Engine Action #6; Exit to World Map (5, 2, 6); Open Dialogue Message Window; Warp Room -> Submap 0 at (30,255) facing 254; Engine Action #5; Pan Camera (4, 5, 2); Engine Action #6; Open Dialogue Message Window; Exit to World Map (3, 0, 30); Walk obj[24] to (8,2); Open Dialogue Message Window; Set Combat Battle BGM (24); Engine Action #9; Engine Action #236; Exit to World Map (5, 1, 4); Warp Town -> Area 1 Map 1 Submap 3 at (7,0); Warp Room -> Submap 24 at (1,2) facing West (Left); Warp to Castle HQ (8, 1, 72); Warp Room -> Submap 3 at (3,9) facing West (Left); Close Dialogue Sub-Window (8); Warp Town -> Area 2 Map 72 Submap 0 at (8,3); Warp Town -> Area 1 Map 3 Submap 3 at (1,24); Warp Room -> Submap 3 at (49,2) facing 5; Warp Room -> Submap 3 at (3,14) facing West (Left); Set Story Flag (30, 255); Engine Action #5; Reset Camera Tracking (5); Dismiss Emotion Bubble (4); Warp to Castle HQ (3, 14, 5); Engine Action #5; Warp Room -> Submap 30 at (255,254) facing 50; Close Dialogue Window; Warp Town -> Area 2 Map 40 Submap 9 at (236,8); Set Combat Battle BGM (60); Jump to Bytecode Offset (4, 18); Set Combat Battle BGM (12); Jump to Bytecode Offset (4, 23); Set Combat Battle BGM (3); Jump to Bytecode Offset (4, 24); Set Combat Battle BGM (2); Jump to Bytecode Offset (4, 23); Set Combat Battle BGM (6); Jump to Bytecode Offset (4, 22); Jump to Bytecode Offset (4, 16); Set Combat Battle BGM (3); Jump to Bytecode Offset (4, 24); Set Combat Battle BGM (2); Jump to Bytecode Offset (4, 23); Set Combat Battle BGM (12); Jump to Bytecode Offset (4, 18); Set Combat Battle BGM (3); Jump to Bytecode Offset (4, 18); Set Combat Battle BGM (12); Jump to Bytecode Offset (4, 23); Set Combat Battle BGM (3); Jump to Bytecode Offset (4, 24); Set Combat Battle BGM (2); Jump to Bytecode Offset (4, 23); Set Combat Battle BGM (6); Jump to Bytecode Offset (4, 22); Jump to Bytecode Offset (4, 24); Set Combat Battle BGM (2); Jump to Bytecode Offset (4, 23); Set Combat Battle BGM (6); Jump to Bytecode Offset (4, 22); Engine Action #9; Engine Action #236; Dismiss Dialogue Portrait; Warp Town -> Area 8 Map 60 Submap 44 at (2,1); Set obj[43] Collision to Passable; Warp Room -> Submap 9 at (72,1) facing 8; Close Dialogue Window; Close Dialogue Window; Warp Room -> Submap 40 at (49,2) facing 5; Reset Camera Tracking (0); Fade Out to Black (2); Animate Door Open; Dismiss Emotion Bubble (255); Engine Action #5; Warp Room -> Submap 0 at (7,27) facing 5; Close Dialogue Sub-Window (3); Open Dialogue Message Window; Pan Camera (13, 4, 6); Pan Camera (6, 4, 5); Open Dialogue Message Window; Warp Room -> Submap 0 at (30,255) facing 254; Walk obj[3] to (0,2); Warp to Castle HQ (3, 1, 72); Open Dialogue Message Window; Warp Room -> Submap 8 at (2,4) facing 72; Open Dialogue Message Window; Reset Camera Tracking (24); Warp Room -> Submap 5 at (39,34) facing 9; Engine Action #165; Warp Room -> Submap 1 at (5,0) facing South (Down); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp Town -> Area 3 Map 30 Submap 255 at (254,204) |
| `ev[12]` | `1 (Action / Talk)` | Story Flag 165 (bit 1) SET AND Story Flag 171 (bit 1) CLEAR AND Inventory Holds Item #2 AND Player within Box [40..42, 2..66] AND Condition Check #82 AND Story Flag 3 (mask 16) SET AND Player within Box [80..16, 1..18] | Turn obj[0] facing 8; Warp Town -> Area 3 Map 0 Submap 0 at (8,3); Open Dialogue Message Window; Warp to Castle HQ (3, 9, 2); Close Dialogue Sub-Window (8); Warp Town -> Area 6 Map 72 Submap 1 at (0,9); Engine Action #5; Open Dialogue Message Window; Exit to World Map (5, 0, 0); Engine Action #5; Exit to World Map (2, 5, 4); Exit to World Map (30, 72, 0); Open Dialogue Message Window |
| `ev[13]` | `128 (Loop)` | Story Flag 164 (bit 4) SET AND Story Flag 164 (bit 8) CLEAR AND Story Flag 171 (bit 1) CLEAR AND Story Flag 236 (bit 2) SET | Set Object Direction (0, 1); Warp Room -> Submap 1 at (1,10) facing 236; Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[14]` | `128 (Loop)` | Story Flag 165 (bit 1) CLEAR AND Story Flag 171 (bit 1) CLEAR AND Inventory Holds Item #2 AND Story Flag 236 (bit 4) SET | Set Object Direction (0, 1); Warp Room -> Submap 1 at (3,10) facing 236; Exit to World Map (255, 254, 204) |
| `ev[15]` | `128 (Loop)` | Story Flag 165 (bit 1) CLEAR AND Story Flag 171 (bit 1) CLEAR AND Inventory Holds Item #2 AND Story Flag 236 (bit 8) SET | Set Object Direction (0, 1); Warp Town -> Area 101 Map 1 Submap 2 at (10,236); Reset Camera Tracking (255) |
| `ev[16]` | `128 (Loop)` | Story Flag 165 (bit 1) CLEAR AND Story Flag 171 (bit 1) CLEAR AND Inventory Holds Item #2 AND Story Flag 236 (bit 16) SET | Set Object Direction (0, 1); Warp Room -> Submap 1 at (1,10) facing 236; Dismiss Dialogue Portrait |
| `ev[17]` | `1 (Action / Talk)` | Story Flag 79 (bit 64) CLEAR AND Story Flag 171 (bit 1) CLEAR AND Player within Box [40..80, 2..57] AND Condition Check #66 AND Star of Destiny #1 Recruited AND Player Y within Range [16..1] AND Story Flag 255 (bit 254) SET | Set Render Priority (pri) (0, 52); Remove Character from Active Party (8); Warp to Castle HQ (0, 2, 33); Warp Town -> Area 3 Map 2 Submap 52 at (5,2); Warp Town -> Area 1 Map 3 Submap 9 at (2,0); Open Dialogue Message Window; Warp Town -> Area 9 Map 3 Submap 2 at (1,2); Reset Camera Tracking (3); Exit to World Map (0, 2, 8); Warp to Castle HQ (4, 0, 5); Reset Camera Tracking (46); Warp to Castle HQ (8, 3, 3); Engine Action #9; Warp to Castle HQ (3, 1, 2); Warp to Castle HQ (2, 2, 3); Warp to Castle HQ (2, 3, 4); Warp Town -> Area 3 Map 5 Submap 2 at (47,73); Branch on Choice (24, 1); Warp Room -> Submap 72 at (1,8) facing Up (North); Set Combat Battle BGM (30); Load Sound Bank into Memory (0, 8); Close Dialogue Sub-Window (8); Warp Room -> Submap 24 at (1,1) facing East (Right); Close Dialogue Sub-Window (8); Warp Room -> Submap 5 at (2,2) facing Up (North); Dismiss Emotion Bubble (24); Warp Town -> Area 1 Map 5 Submap 72 at (1,8); Engine Action #9; Engine Action #5; Reset Camera Tracking (7); Warp to Castle HQ (30, 73, 5); Load Sound Bank into Memory (0, 8); Close Dialogue Sub-Window (8); Warp Room -> Submap 24 at (2,1) facing 7; Load Sound Bank into Memory (1, 8); Exit to World Map (73, 30, 72); Open Dialogue Message Window; Reset Camera Tracking (24); Reset Camera Tracking (1); Reset Camera Tracking (73); Dismiss Emotion Bubble (39); Return Warp to Castle Base (9, 79); Animate Doorway State (255, 254) |
| `ev[18]` | `1 (Action / Talk)` | Story Flag 171 (bit 1) CLEAR AND Target Inspected is obj[8] | Close Dialogue Sub-Window (8); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[19]` | `1 (Action / Talk)` | Story Flag 171 (bit 1) CLEAR AND Target Inspected is obj[9] | Close Dialogue Sub-Window (9); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[20]` | `2 (Map Init)` | Story Flag 171 (bit 1) SET AND Story Flag 24 (bit 4) CLEAR | Make obj[2] Hidden (disp = 0); Screen Fade Transition (46, 71, 2); Close Dialogue Window; Teleport obj[76] to (3,10); Warp Town -> Area 3 Map 11 Submap 2 at (0,10); Open Dialogue Message Window; Close Dialogue Window; Teleport obj[255] to (254,204) |
| `ev[21]` | `1 (Action / Talk)` | Story Flag 171 (bit 1) SET AND Story Flag 24 (bit 4) CLEAR AND Player within Box [42..44, 2..66] AND Condition Check #73 AND Story Flag 3 (mask 255) SET | Exit to World Map (0, 42, 71); Engine Action #9; Warp to Castle HQ (0, 3, 3); Close Dialogue Window; Warp Room -> Submap 2 at (5,0) facing East (Right); Open Dialogue Message Window; Pan Camera (1, 30, 255); Engine Action #5; Screen Fade Transition (2, 1, 30); Walk obj[24] to (10,1); Close Dialogue Window; Set Entity Movement Speed (2, 5); Open Dialogue Message Window; Warp to Castle HQ (0, 7, 3); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Exit to World Map (2, 0, 30); Engine Action #5; Screen Fade Transition (2, 0, 7); Warp Room -> Submap 255 at (254,50) facing East (Right); Close Dialogue Window; Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[22]` | `1 (Action / Talk)` | Story Flag 171 (bit 1) SET AND Story Flag 24 (bit 4) CLEAR AND Player within Box [42..44, 2..74] AND Condition Check #82 AND Story Flag 3 (mask 255) SET | Warp to Castle HQ (11, 2, 4); Open Dialogue Message Window; Open Shop Menu #9 (Type: 76); Warp to Castle HQ (0, 3, 3); Screen Fade Transition (0, 24, 11); Warp Room -> Submap 5 at (0,3) facing South (Down); Pan Camera (3, 0, 0); Engine Action #5; Exit to World Map (2, 0, 30); Warp to Castle HQ (10, 2, 255) |

---

### Submap Layer `vb17_01` (Index 1)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `50`, Rate: `7`)
- **Entity Count (`okaz`)**: `3` Objects | **Script Count (`evkaz`)**: `8` Scripts

#### Complete Physical Entity Inventory (3 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 11)** | `0` | `(23, 16)` | `0x0` | Frame 11 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | Rest Device / Fire | **Inn Bed / Recovery Device** | `0` | `(23, 16)` | `0x0` | Frame 12 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | Trigger / Hitbox | **Hitbox Zone (6x6)** | `0` | `(12, 15)` | `5x5` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(23, 16)` with state parameter `11`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(23, 16)` with state parameter `12`.
- **`obj[02]` (Hitbox Zone)**: Bounding trigger area covering `6` tiles wide by `6` tiles high from `(12, 15)` to `(17, 20)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (8 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Always Passes (Unconditional) | Make obj[88] Hidden (disp = 0); Teleport obj[255] to (254,204) |
| `ev[01]` | `2 (Map Init)` | Story Flag 4 (bit 128) SET | Engine Action #121; Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[02]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Load Sound Bank into Memory (1, 0); Open Dialogue Message Window; Engine Action #5; Open Dialogue Message Window; Exit to World Map (5, 6, 1); Exit to World Map (4, 30, 72); Open Dialogue Message Window; Open Dialogue Message Window; Jump to Bytecode Offset (4, 49); Teleport Object to Coordinates (26, 1, 0) |
| `ev[03]` | `2 (Map Init)` | Treasure Byte 17 Bit 8 FRESH (Unopened) | Make obj[0] Hidden (disp = 0); Reset Camera Tracking (47) |
| `ev[04]` | `2 (Map Init)` | Treasure Byte 17 Bit 8 LOOTED | Make obj[0] Hidden (disp = 0); Engine Action #9; Teleport obj[255] to (254,204) |
| `ev[05]` | `1 (Action / Talk)` | Treasure Byte 17 Bit 8 FRESH (Unopened) AND Target Inspected is obj[8] | Make obj[1] Hidden (disp = 0); Reset Camera Tracking (0); Engine Action #9; Teleport obj[101] to (4,7); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (1); Exit to World Map (0, 8, 0); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,17) facing 8; Warp Room -> Submap 1 at (9,0) facing 8; Teleport obj[255] to (254,255) |
| `ev[06]` | `1 (Action / Talk)` | Player within Box [16..44, 2..121] AND Condition Check #123 AND Story Flag 0 (mask 255) SET | Jump to Bytecode Offset (9, 9); Close Dialogue Window; Warp Town -> Area 2 Map 40 Submap 69 at (1,101); Warp Room -> Submap 12 at (0,12) facing 8 |
| `ev[07]` | `1 (Action / Talk)` | Player within Box [96..115, 2..4] AND Inventory Holds Item #9 AND Player X within Range [255..254] | Display Dialogue Box [Bank: 2, MsgID: 43]; Engine Action #118 |

---

### Submap Layer `vb17_02` (Index 2)

- **Map Number (`mapno`)**: `2`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `50`, Rate: `7`)
- **Entity Count (`okaz`)**: `2` Objects | **Script Count (`evkaz`)**: `7` Scripts

#### Complete Physical Entity Inventory (2 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 11)** | `0` | `(105, 68)` | `0x0` | Frame 11 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | Rest Device / Fire | **Inn Bed / Recovery Device** | `0` | `(105, 68)` | `0x0` | Frame 12 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(105, 68)` with state parameter `11`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(105, 68)` with state parameter `12`.


#### Complete Bytecode Script Catalog (7 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Always Passes (Unconditional) | Make obj[88] Hidden (disp = 0); Teleport obj[255] to (254,204) |
| `ev[01]` | `2 (Map Init)` | Story Flag 4 (bit 128) SET | Engine Action #121; Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[02]` | `2 (Map Init)` | Treasure Byte 17 Bit 1 FRESH (Unopened) | Make obj[0] Hidden (disp = 0); Reset Camera Tracking (47) |
| `ev[03]` | `2 (Map Init)` | Treasure Byte 17 Bit 1 LOOTED | Make obj[0] Hidden (disp = 0); Engine Action #9; Teleport obj[255] to (254,204) |
| `ev[04]` | `1 (Action / Talk)` | Treasure Byte 17 Bit 1 FRESH (Unopened) AND Target Inspected is obj[8] | Make obj[1] Hidden (disp = 0); Reset Camera Tracking (0); Engine Action #9; Teleport obj[101] to (4,7); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (1); Exit to World Map (0, 34, 0); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,17) facing West (Left); Warp Room -> Submap 1 at (9,0) facing 8; Teleport obj[255] to (254,255) |
| `ev[05]` | `1 (Action / Talk)` | Player within Box [24..54, 2..121] AND Condition Check #124 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 103]; Reset Camera Tracking (255) |
| `ev[06]` | `1 (Action / Talk)` | Player within Box [42..60, 2..4] AND Inventory Holds Item #9 AND Player X within Range [255..254] | Display Dialogue Box [Bank: 3, MsgID: 85]; Engine Action #174 |

---

### Submap Layer `vb17_03` (Index 3)

- **Map Number (`mapno`)**: `3`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `50`, Rate: `7`)
- **Entity Count (`okaz`)**: `2` Objects | **Script Count (`evkaz`)**: `7` Scripts

#### Complete Physical Entity Inventory (2 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | Rest Device / Fire | **Inn Bed / Recovery Device** | `0` | `(90, 86)` | `0x0` | Frame 12 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 11)** | `0` | `(90, 86)` | `0x0` | Frame 11 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(90, 86)` with state parameter `12`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(90, 86)` with state parameter `11`.


#### Complete Bytecode Script Catalog (7 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Always Passes (Unconditional) | Make obj[88] Hidden (disp = 0); Teleport obj[255] to (254,204) |
| `ev[01]` | `2 (Map Init)` | Story Flag 4 (bit 128) SET | Engine Action #121; Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[02]` | `2 (Map Init)` | Treasure Byte 17 Bit 2 FRESH (Unopened) | Make obj[0] Hidden (disp = 0); Engine Action #9; Teleport obj[255] to (254,204) |
| `ev[03]` | `2 (Map Init)` | Treasure Byte 17 Bit 2 LOOTED | Make obj[0] Hidden (disp = 0); Reset Camera Tracking (47) |
| `ev[04]` | `1 (Action / Talk)` | Treasure Byte 17 Bit 2 FRESH (Unopened) AND Target Inspected is obj[9] | Make obj[1] Hidden (disp = 0); Engine Action #9; Open Dialogue Message Window; Reset Camera Tracking (47); Jump to Bytecode Offset (4, 7); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (1); Exit to World Map (0, 16, 16); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,17) facing Up (North); Warp Room -> Submap 1 at (8,0) facing 9; Teleport obj[255] to (254,255) |
| `ev[05]` | `1 (Action / Talk)` | Player within Box [76..98, 2..176] AND Condition Check #179 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 50]; Reset Camera Tracking (255) |
| `ev[06]` | `1 (Action / Talk)` | Player within Box [29..56, 2..4] AND Inventory Holds Item #9 AND Player X within Range [255..254] | Display Dialogue Box [Bank: 4, MsgID: 12]; Engine Action #110 |

---

### Submap Layer `vb17_04` (Index 4)

- **Map Number (`mapno`)**: `4`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `50`, Rate: `7`)
- **Entity Count (`okaz`)**: `1` Objects | **Script Count (`evkaz`)**: `9` Scripts

#### Complete Physical Entity Inventory (1 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | Rest Device / Fire | **Inn Bed / Recovery Device** | `0` | `(63, 94)` | `0x0` | Frame 13 | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(63, 94)` with state parameter `13`.


#### Complete Bytecode Script Catalog (9 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Target Inspected is obj[8] | Launch Tactical War Battle (4); Fade In from Black (3); Exit to World Map (73, 20, 40); Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 3 Map 2 Submap 3 at (3,73); Branch on Choice (41, 2); Open Dialogue Message Window; Warp Room -> Submap 0 at (54,0) facing 4; Recruit Riou (Hero) into Battle Slot 1; Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[01]` | `128 (Loop)` | Inventory Holds Item #4 | Warp Room -> Submap 1 at (13,45); Toggle Random Encounters (4) |
| `ev[02]` | `2 (Map Init)` | Always Passes (Unconditional) | Make obj[88] Hidden (disp = 0); Teleport obj[255] to (254,204) |
| `ev[03]` | `2 (Map Init)` | Story Flag 4 (bit 128) SET | Engine Action #121; Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [0..20, 2..113] AND Condition Check #120 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 3, MsgID: 42]; Reset Camera Tracking (255) |
| `ev[05]` | `1 (Action / Talk)` | Player within Box [1..2, 2..109] AND Condition Check #115 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 3, MsgID: 42]; Reset Camera Tracking (255) |
| `ev[06]` | `1 (Action / Talk)` | Player within Box [60..74, 2..4] AND Inventory Holds Item #9 AND Player X within Range [255..254] | Display Dialogue Box [Bank: 5, MsgID: 11]; Engine Action #88 |
| `ev[07]` | `2 (Map Init)` | Story Flag 164 (bit 16) SET AND Story Flag 164 (bit 32) CLEAR | Make obj[86] Hidden (disp = 0); Warp Room -> Submap 0 at (23,85) facing 63; Exit to World Map (80, 19, 20); Execute Choice Result (2); Open Dialogue Message Window; Make obj[60] Visible (disp = 1); Warp Town -> Area 1 Map 41 Submap 60 at (2,2); Award Potch Loot (+16,130 Potch); Warp to Castle HQ (45, 63, 2); Exit to World Map (43, 65, 3); Open Dialogue Message Window; Open Dialogue Message Window; Warp to Castle HQ (1, 0, 3); Warp Town -> Area 1 Map 3 Submap 3 at (1,3); Exit to World Map (1, 0, 1); Open Dialogue Message Window; Warp Town -> Area 0 Map 3 Submap 0 at (4,47) |
| `ev[08]` | `1 (Action / Talk)` | Story Flag 164 (bit 16) SET AND Story Flag 164 (bit 32) CLEAR | Close Dialogue Window; Warp Room -> Submap 40 at (73,20) facing 24; Warp Town -> Area 0 Map 21 Submap 24 at (1,0); Set Story Flag (5, 4); Engine Action #6; Warp to Castle HQ (6, 3, 6); Warp to Castle HQ (30, 49, 2); Engine Action #5; Warp Town -> Area 3 Map 0 Submap 5 at (5,0); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Warp to Castle HQ (2, 0, 30); Walk obj[24] to (4,0); Open Dialogue Sub-Window (5); Exit to World Map (6, 2, 6); Warp Town -> Area 6 Map 2 Submap 30 at (24,3); Open Dialogue Message Window; Close Dialogue Sub-Window (39); Return Warp to Castle Base (9, 164); Warp Map Transition (255, 254, 204, 204, 204) |

---

### Submap Layer `vb17_05` (Index 5)

- **Map Number (`mapno`)**: `5`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `50`, Rate: `7`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `5` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (5 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Always Passes (Unconditional) | Make obj[88] Hidden (disp = 0); Teleport obj[255] to (254,204) |
| `ev[01]` | `2 (Map Init)` | Story Flag 4 (bit 128) SET | Engine Action #121; Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [2..20, 2..90] AND Condition Check #92 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 4, MsgID: 67]; Reset Camera Tracking (255) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [125..129, 2..18] AND Condition Check #34 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 6, MsgID: 4]; Place Scenery Structure (255) |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [56..74, 2..4] AND Inventory Holds Item #9 AND Player X within Range [255..254] | Display Dialogue Box [Bank: 7, MsgID: 15]; Engine Action #58 |

---

### Submap Layer `vb17_06` (Index 6)

- **Map Number (`mapno`)**: `6`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `50`, Rate: `7`)
- **Entity Count (`okaz`)**: `2` Objects | **Script Count (`evkaz`)**: `6` Scripts

#### Complete Physical Entity Inventory (2 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 11)** | `0` | `(61, 13)` | `0x0` | Frame 11 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | Rest Device / Fire | **Inn Bed / Recovery Device** | `0` | `(61, 13)` | `0x0` | Frame 12 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(61, 13)` with state parameter `11`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(61, 13)` with state parameter `12`.


#### Complete Bytecode Script Catalog (6 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Always Passes (Unconditional) | Make obj[88] Hidden (disp = 0); Teleport obj[255] to (254,204) |
| `ev[01]` | `2 (Map Init)` | Story Flag 4 (bit 128) SET | Engine Action #121; Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[02]` | `2 (Map Init)` | Treasure Byte 17 Bit 4 FRESH (Unopened) | Make obj[0] Hidden (disp = 0); Reset Camera Tracking (47) |
| `ev[03]` | `2 (Map Init)` | Treasure Byte 17 Bit 4 LOOTED | Make obj[0] Hidden (disp = 0); Engine Action #9; Teleport obj[255] to (254,204) |
| `ev[04]` | `1 (Action / Talk)` | Treasure Byte 17 Bit 4 FRESH (Unopened) AND Target Inspected is obj[8] | Make obj[1] Hidden (disp = 0); Reset Camera Tracking (0); Engine Action #9; Teleport obj[101] to (4,7); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (1); Exit to World Map (0, 3, 16); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,17) facing 4; Warp Room -> Submap 1 at (9,0) facing 8; Teleport obj[255] to (254,255) |
| `ev[05]` | `1 (Action / Talk)` | Player within Box [1..2, 2..6] AND Castle HQ Tier >= Level 9 AND Player Y within Range [255..254] | Display Dialogue Box [Bank: 5, MsgID: 122]; Fade Out to Black (255) |

---

### Submap Layer `vb17_07` (Index 7)

- **Map Number (`mapno`)**: `7`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `50`, Rate: `7`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `7` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (7 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Always Passes (Unconditional) | Make obj[88] Hidden (disp = 0); Teleport obj[255] to (254,204) |
| `ev[01]` | `2 (Map Init)` | Player within Box [26..26, 2..9] AND Story Flag 255 (mask 254) SET | Make obj[86] Hidden (disp = 0); Warp Room -> Submap 7 at (26,12) facing 47 |
| `ev[02]` | `2 (Map Init)` | Story Flag 4 (bit 128) SET | Engine Action #121; Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [8..26, 2..60] AND Condition Check #62 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 5, MsgID: 65]; Reset Camera Tracking (255) |
| `ev[04]` | `128 (Loop)` | Player within Box [10..40, 2..8] AND Active Party Has Character #255 | Warp Room -> Submap 2 at (12,0) |
| `ev[05]` | `1 (Action / Talk)` | Player within Box [14..36, 2..4] AND Inventory Holds Item #9 AND Player X within Range [255..254] | Jump to Bytecode Offset (9, 9); Warp Map Transition (0, 0, 57, 129, 255) |
| `ev[06]` | `1 (Action / Talk)` | Story Flag 164 (bit 32) SET AND Story Flag 164 (bit 64) CLEAR AND Player within Box [22..30, 2..21] AND Inventory Holds Item #16 AND Player within Box [20..16, 1..80] AND Star of Destiny #1 Recruited AND Character #16 Level >= 1 AND Inventory Holds Item #9 AND Player X within Range [255..254] | Recruit Character into Active Party (31, 2); Display Dialogue Box [Bank: 0, MsgID: 4]; Open Dialogue Message Window; Fade In from Black (15); Reset Camera Tracking (33); Exit to World Map (80, 19, 20); Execute Choice Result (46); Open Dialogue Message Window; Warp Room -> Submap 2 at (0,3) facing South (Down); Exit to World Map (47, 49, 4); Engine Action #5; Warp Room -> Submap 5 at (3,4) facing West (Left); Open Dialogue Message Window; Engine Action #5; Exit to World Map (2, 0, 30); Engine Action #5; Warp Town -> Area 4 Map 5 Submap 2 at (4,1); Open Dialogue Message Window; Engine Action #5; Exit to World Map (3, 0, 30); Engine Action #5; Warp to Castle HQ (4, 5, 0); Warp Town -> Area 3 Map 2 Submap 1 at (0,30); Engine Action #5; Exit to World Map (4, 5, 0); Warp to Castle HQ (2, 2, 1); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Walk obj[3] to (1,2); Warp to Castle HQ (0, 3, 24); Warp Room -> Submap 25 at (5,2) facing 4; Warp Town -> Area 3 Map 1 Submap 30 at (5,0); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp Town -> Area 0 Map 30 Submap 24 at (2,0); Fade In from Black (11); Warp Town -> Area 2 Map 240 Submap 69 at (1,58); Return Warp to Castle Base (9, 164); Animate Doorway State (101, 9); Engine Action #9; Warp Map Transition (0, 0, 57, 129, 255) |

---


