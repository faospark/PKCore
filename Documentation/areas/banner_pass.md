# Suikoden II Geographic Area Catalog: Banner Pass (Toran Mountain Trail)

**Geographic Scope & Role**: High mountain pass connecting Banner Village (Dunan) to Gregminster (Toran Republic); steep cliff ascents, rickety suspension bridges, poisonous insect swarms, Giant Worm boss encounter, and hidden mountain path to Rokkaku Hamlet (Mondo & Sasuke recruitment). *Note: Formerly misidentified as Mt. Ryukan, which is a Suikoden I Toran mountain (`bg_vc0`).*

**Regional Category**: Region `VF` | **Master Maps Included**: `vf03`

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

## Location Map: `vf03`

- **Master Map Container**: `vf03.json`
- **Submap Layer Files**: vf03_00.json, vf03_03.json, vf03_04.json, vf03_11.json, vf03_14.json, vf03_15.json, vf03_22.json, vf03_30.json
- **Collision Grid Files**: vf03_map_00.json, vf03_map_01.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 14

### Submap Layer `vf03_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `20` Objects | **Script Count (`evkaz`)**: `38` Scripts

#### Complete Physical Entity Inventory (20 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Jill Blight** | `125` | `(72, 29)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Actor ID 164** | `164` | `(50, 71)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Actor ID 164** | `164` | `(29, 30)` | `6x6` | South (Down) | Dormant / Hidden (0) | Special (3) | 4 | 128 | 0 |
| `obj[03]` | NPC / Actor | **Killey** | `165` | `(45, 32)` | `6x6` | South (Down) | Dormant / Hidden (0) | Special (3) | 4 | 128 | 0 |
| `obj[04]` | World Device | **Mechanism (ano 81)** | `0` | `(67, 21)` | `0x0` | Frame 81 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(71, 28)` | `1x1` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(35, 63)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(31, 27)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(41, 27)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(67, 27)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(71, 26)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(35, 27)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(78, 65)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(63, 64)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(63, 69)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[15]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(59, 31)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[16]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(63, 31)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[17]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(75, 28)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[18]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(77, 28)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[19]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(75, 48)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Jill Blight)**: Positioned at tile `(72, 29)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Object 164)**: Positioned at tile `(50, 71)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Object 164)**: Positioned at tile `(29, 30)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Killey)**: Positioned at tile `(45, 32)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(67, 21)` with state parameter `81`.
- **`obj[05]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(71, 28)` to `(72, 29)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[06]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(35, 63)` to `(38, 64)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[07]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(31, 27)` to `(34, 28)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[08]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(41, 27)` to `(44, 28)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[09]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(67, 27)` to `(68, 28)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[10]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(71, 26)` to `(74, 27)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[11]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(35, 27)` to `(38, 28)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[12]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(78, 65)` to `(79, 66)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[13]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(63, 64)` to `(66, 65)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[14]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(63, 69)` to `(66, 70)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[15]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(59, 31)` to `(62, 32)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[16]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(63, 31)` to `(64, 32)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[17]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(75, 28)` to `(76, 29)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[18]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(77, 28)` to `(78, 29)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[19]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(75, 48)` to `(76, 49)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (38 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 64 (bit 16) SET AND Story Flag 150 (bit 2) SET AND Story Flag 150 (bit 4) CLEAR AND Player within Box [50..50, 2..71] AND Condition Check #71 | Launch Tactical War Battle (16) |
| `ev[01]` | `128 (Loop)` | Inventory Holds Item #16 [Revenge Earth] | Recruit Character into Active Party (37 [Amada], 16); Jump to Bytecode Offset (5, 0); Set Object Direction (0, 0); Play CD / Ambient BGM Track (101); Warp Room -> Submap 102 at (1,73) facing 60; Close Dialogue Window; Warp Room -> Submap 40 at (58,255) facing 254 |
| `ev[02]` | `2 (Map Init)` | Story Flag 64 (bit 16) CLEAR | Open Dialogue Message Window; Screen Fade Transition (255, 254, 204) |
| `ev[03]` | `2 (Map Init)` | Story Flag 65 (bit 16) SET | Make obj[0] Hidden (disp = 0); Screen Fade Transition (0, 11, 2); Engine Action #9; Warp Map Transition (32, 47, 255, 254, 255) |
| `ev[04]` | `1 (Action / Talk)` | Target Inspected is obj[10] AND Story Flag 64 (bit 16) CLEAR | Open Dialogue Sub-Window (5); Return to Previous Memory Map (255) |
| `ev[05]` | `1 (Action / Talk)` | Target Inspected is obj[10] AND Story Flag 65 (bit 16) SET | Open Dialogue Sub-Window (5); Warp Room -> Submap 255 at (254,204) |
| `ev[06]` | `1 (Action / Talk)` | Target Inspected is obj[11] AND Story Flag 65 (bit 16) SET | Open Dialogue Sub-Window (5); Warp Map Transition (255, 254, 204, 204, 204) |
| `ev[07]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Open Dialogue Sub-Window (6); Open Dialogue Message Window |
| `ev[08]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Open Dialogue Sub-Window (6); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[09]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Open Dialogue Sub-Window (6); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[10]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Open Dialogue Sub-Window (6); Warp to Castle HQ (255, 254, 204) |
| `ev[11]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Open Dialogue Sub-Window (6); Exit to World Map (255, 254, 204) |
| `ev[12]` | `1 (Action / Talk)` | Target Inspected is obj[19] | Open Dialogue Sub-Window (6); Walk obj[255] to (254,204) |
| `ev[13]` | `1 (Action / Talk)` | Target Inspected is obj[20] | Open Dialogue Sub-Window (6); Engine Action #51 |
| `ev[14]` | `1 (Action / Talk)` | Target Inspected is obj[21] | Open Dialogue Sub-Window (6); Engine Action #52 |
| `ev[15]` | `1 (Action / Talk)` | Target Inspected is obj[22] | Open Dialogue Sub-Window (6); Engine Action #53 |
| `ev[16]` | `1 (Action / Talk)` | Target Inspected is obj[23] | Open Dialogue Sub-Window (6); Engine Action #54 |
| `ev[17]` | `1 (Action / Talk)` | Target Inspected is obj[24] | Open Dialogue Sub-Window (6); Set Render Priority (pri) (255, 254) |
| `ev[18]` | `1 (Action / Talk)` | Target Inspected is obj[25] | Open Dialogue Sub-Window (6); Set Animation Pose (255, 254) |
| `ev[19]` | `1 (Action / Talk)` | Target Inspected is obj[26] | Open Dialogue Sub-Window (6); Recruit Character into Active Party (255, 254) |
| `ev[20]` | `1 (Action / Talk)` | Target Inspected is obj[27] | Open Dialogue Sub-Window (6); Engine Action #58 |
| `ev[21]` | `128 (Loop)` | Player within Box [41..59, 2..62] AND Condition Check #74 | Warp Room -> Submap 0 at (5,1) |
| `ev[22]` | `2 (Map Init)` | Story Flag 65 (bit 128) SET | Make obj[0] Hidden (disp = 0); Place Scenery Structure (0); Reset Camera Tracking (47) |
| `ev[23]` | `2 (Map Init)` | Story Flag 150 (bit 4) SET | Open Dialogue Message Window; Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[24]` | `2 (Map Init)` | Story Flag 64 (bit 64) SET AND Story Flag 64 (bit 128) CLEAR AND Story Flag 0 (mask 255) SET | Make obj[0] Hidden (disp = 0); Engine Action #9; Teleport obj[255] to (254,255) |
| `ev[25]` | `2 (Map Init)` | Story Flag 64 (bit 128) SET AND Story Flag 65 (bit 1) CLEAR AND Story Flag 150 (bit 4) CLEAR AND Star of Destiny #1 Recruited AND Condition Check #82 AND Star of Destiny #1 Recruited AND Condition Check #125 | Make obj[63] Hidden (disp = 0); Warp Town -> Area 82 Map 125 Submap 2 at (1,48); Recruit Invisible / Hitbox Trigger into Battle Slot 1; Warp to Castle HQ (1, 1, 2); Warp Town -> Area 52 Map 70 Submap 0 at (2,3); Warp Town -> Area 1 Map 47 Submap 255 at (254,255) |
| `ev[26]` | `2 (Map Init)` | Story Flag 64 (bit 128) SET AND Story Flag 65 (bit 1) CLEAR AND Story Flag 150 (bit 4) SET AND Star of Destiny #1 Recruited AND Condition Check #82 AND Star of Destiny #1 Recruited AND Condition Check #172 | Make obj[63] Hidden (disp = 0); Warp Town -> Area 82 Map 172 Submap 2 at (1,48); Recruit Invisible / Hitbox Trigger into Battle Slot 1; Warp to Castle HQ (1, 1, 2); Warp Town -> Area 52 Map 70 Submap 0 at (2,3); Warp Town -> Area 1 Map 47 Submap 255 at (254,255) |
| `ev[27]` | `1 (Action / Talk)` | Player within Box [49..51, 2..74] AND Condition Check #76 AND Story Flag 64 (bit 16) SET AND Story Flag 150 (bit 2) SET AND Story Flag 150 (bit 4) CLEAR AND Story Flag 0 (mask 255) SET | Jump to Bytecode Offset (9, 8); Engine Action #102; Open Dialogue Message Window; Wait for Audio / Window Sync (3); Close Dialogue Window; Warp Town -> Area 2 Map 40 Submap 32 at (3,0); Engine Action #170; Trigger Character Emotion Effect (255, 254) |
| `ev[28]` | `1 (Action / Talk)` | Player within Box [49..51, 2..74] AND Condition Check #76 AND Story Flag 0 (mask 255) SET | Engine Action #102; Open Dialogue Message Window; Warp Map Transition (3, 0, 170, 60, 255) |
| `ev[29]` | `1 (Action / Talk)` | Player within Box [41..43, 2..59] AND Condition Check #60 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 143]; Engine Action #66 |
| `ev[30]` | `1 (Action / Talk)` | Player within Box [57..59, 2..58] AND Condition Check #59 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 157]; Engine Action #66 |
| `ev[31]` | `1 (Action / Talk)` | Story Flag 64 (bit 64) SET AND Story Flag 64 (bit 128) CLEAR AND Star of Destiny #1 Recruited AND Condition Check #73 | Recruit Character into Active Party (48 [Mukumuku], 0); Engine Action #9; Warp to Castle HQ (0, 1, 2); Engine Action #9; Warp to Castle HQ (0, 0, 73); Trigger Character Emotion Effect (3, 9); Warp to Castle HQ (73, 10, 3); Engine Action #9; Warp Room -> Submap 9 at (0,19) facing 73; Branch on Choice (40, 0); Open Dialogue Message Window; Warp to Castle HQ (0, 20, 0); Execute Choice Result (0); Set Story Flag (41, 3); Open Dialogue Message Window; Warp Room -> Submap 255 at (0,24) facing 9; Open Dialogue Message Window; Open Dialogue Sub-Window (73); Engine Action #120; Close Dialogue Sub-Window (9); Open Dialogue Message Window; Close Dialogue Sub-Window (51); Warp to Castle HQ (255, 1, 24); Engine Action #9; Open Dialogue Message Window; Clear Dialogue Sub-Window; Set Combat Battle BGM (120); Close Dialogue Sub-Window (9); Open Dialogue Message Window; Fade In from Black (255); Warp to Castle HQ (73, 20, 40); Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 0 Map 27 Submap 0 at (28,73); Trigger Character Emotion Effect (41, 2); Exit to World Map (5, 255, 4); Close Dialogue Sub-Window (9); Open Dialogue Message Window; Display Emotion Bubble (51, 6); Engine Action #5; Close Dialogue Sub-Window (9); Open Dialogue Message Window; Dismiss Emotion Bubble (51); Engine Action #6; Warp Town -> Area 24 Map 9 Submap 0 at (31,255); Engine Action #6; Set Combat Battle BGM (20); Award Potch Currency (9,0); Engine Action #5; Dismiss Emotion Bubble (69); Warp to Castle HQ (11, 2, 2); Engine Action #90; Set Combat Battle BGM (30); Display Dialogue Box [Bank: 2, MsgID: 130]; Set Combat Battle BGM (58) |
| `ev[32]` | `1 (Action / Talk)` | Story Flag 64 (bit 64) SET AND Story Flag 64 (bit 128) CLEAR AND Star of Destiny #0 Recruited AND Condition Check #73 | Recruit Character into Active Party (48 [Mukumuku], 0); Engine Action #9; Warp to Castle HQ (0, 1, 2); Engine Action #9; Warp to Castle HQ (0, 0, 73); Trigger Character Emotion Effect (3, 9); Warp to Castle HQ (73, 10, 3); Engine Action #9; Warp Room -> Submap 9 at (0,19) facing 73; Branch on Choice (40, 0); Open Dialogue Message Window; Warp to Castle HQ (0, 20, 0); Execute Choice Result (0); Set Story Flag (41, 3); Open Dialogue Message Window; Warp Room -> Submap 255 at (0,24) facing 9; Open Dialogue Message Window; Open Dialogue Sub-Window (73); Engine Action #120; Close Dialogue Sub-Window (9); Open Dialogue Message Window; Close Dialogue Sub-Window (51); Warp to Castle HQ (255, 1, 24); Engine Action #9; Open Dialogue Message Window; Clear Dialogue Sub-Window; Set Combat Battle BGM (120); Close Dialogue Sub-Window (9); Open Dialogue Message Window; Fade In from Black (255); Warp to Castle HQ (73, 20, 40); Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 0 Map 27 Submap 0 at (28,73); Trigger Character Emotion Effect (41, 2); Exit to World Map (5, 255, 4); Close Dialogue Sub-Window (9); Open Dialogue Message Window; Display Emotion Bubble (51, 6); Engine Action #5; Close Dialogue Sub-Window (9); Open Dialogue Message Window; Dismiss Emotion Bubble (51); Engine Action #6; Warp Town -> Area 24 Map 9 Submap 0 at (31,255); Engine Action #6; Set Combat Battle BGM (20); Award Potch Currency (9,0); Engine Action #5; Dismiss Emotion Bubble (69); Warp to Castle HQ (11, 2, 2); Engine Action #90; Set Combat Battle BGM (30); Display Dialogue Box [Bank: 2, MsgID: 54]; Dismiss Emotion Bubble (58) |
| `ev[33]` | `1 (Action / Talk)` | Story Flag 64 (bit 128) SET AND Story Flag 65 (bit 1) CLEAR AND Story Flag 150 (bit 4) CLEAR | Recruit Character into Active Party (11 [Georg], 1); Warp Town -> Area 90 Map 24 Submap 2 at (0,42); Set Entity Movement Speed (2, 48); Warp Room -> Submap 3 at (0,0) facing South (Down); Engine Action #9; Warp Room -> Submap 255 at (254,48) facing Up (North); Open Dialogue Message Window; Warp to Castle HQ (0, 0, 0); Engine Action #9; Warp Room -> Submap 255 at (254,50) facing 9; Play Sound Effect (SE) (1); Screen Fade Transition (64, 32, 58) |
| `ev[34]` | `1 (Action / Talk)` | Story Flag 64 (bit 128) SET AND Story Flag 65 (bit 1) CLEAR AND Story Flag 150 (bit 4) SET | Recruit Character into Active Party (11 [Georg], 1); Warp Town -> Area 90 Map 24 Submap 2 at (0,43); Set Entity Movement Speed (2, 48); Warp Room -> Submap 3 at (0,0) facing South (Down); Engine Action #9; Warp Room -> Submap 255 at (254,48) facing Up (North); Open Dialogue Message Window; Warp to Castle HQ (0, 0, 0); Engine Action #9; Warp Room -> Submap 255 at (254,50) facing 9; Play Sound Effect (SE) (1); Screen Fade Transition (64, 32, 58) |
| `ev[35]` | `1 (Action / Talk)` | Story Flag 65 (bit 128) SET AND Temp Event Flag #32 SET AND Target Inspected is obj[13] | Recruit Character into Active Party (3 [Viktor], 8); Warp Room -> Submap 0 at (72,31) facing 9; Warp to Castle HQ (0, 1, 24); Reset Camera Tracking (7); Open Dialogue Message Window; Set Combat Battle BGM (60); Set Combat Battle BGM (20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp to Castle HQ (7, 1, 7); Warp Town -> Area 7 Map 3 Submap 73 at (20,41); Warp to Castle HQ (0, 1, 2); Open Dialogue Message Window; Load Sound Bank into Memory (1, 8); Engine Action #9; Jump to Bytecode Offset (0, 177); Close Dialogue Sub-Window (8); Pan Camera (4, 73, 20); Load Sound Bank into Memory (0, 8); Engine Action #51; Warp to Castle HQ (255, 1, 72); Warp Room -> Submap 9 at (101,0) facing 177; Close Dialogue Sub-Window (8); Pan Camera (5, 73, 20); Load Sound Bank into Memory (0, 8); Engine Action #51; Warp to Castle HQ (255, 2, 24); Reset Camera Tracking (7); Engine Action #6; Set Combat Battle BGM (20); Engine Action #51; Warp to Castle HQ (255, 3, 3); Reset Camera Tracking (3); Set Combat Battle BGM (10); Warp to Castle HQ (8, 0, 73); Trigger Character Emotion Effect (24, 8); Pan Camera (7, 73, 20); Warp to Castle HQ (8, 2, 73); Screen Fade Transition (3, 8, 1); Launch Tactical War Battle (32); Engine Action #58 |
| `ev[36]` | `1 (Action / Talk)` | Story Flag 65 (bit 128) CLEAR AND Temp Event Flag #32 SET AND Target Inspected is obj[13] | Recruit Character into Active Party (3 [Viktor], 8); Warp Room -> Submap 0 at (72,31) facing 9; Warp to Castle HQ (0, 1, 24); Reset Camera Tracking (7); Open Dialogue Message Window; Set Combat Battle BGM (60); Set Combat Battle BGM (20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp to Castle HQ (7, 1, 7); Warp Town -> Area 7 Map 3 Submap 73 at (20,41); Warp to Castle HQ (0, 1, 2); Open Dialogue Message Window; Load Sound Bank into Memory (1, 8); Engine Action #9; Jump to Bytecode Offset (0, 177); Close Dialogue Sub-Window (8); Pan Camera (4, 73, 20); Load Sound Bank into Memory (0, 8); Engine Action #51; Warp to Castle HQ (255, 1, 72); Warp Room -> Submap 9 at (101,0) facing 177; Close Dialogue Sub-Window (8); Pan Camera (5, 73, 20); Load Sound Bank into Memory (0, 8); Engine Action #51; Warp to Castle HQ (255, 2, 24); Reset Camera Tracking (7); Engine Action #6; Set Combat Battle BGM (20); Engine Action #51; Warp to Castle HQ (255, 3, 3); Reset Camera Tracking (3); Set Combat Battle BGM (10); Warp to Castle HQ (8, 0, 73); Trigger Character Emotion Effect (24, 8); Pan Camera (7, 73, 20); Warp to Castle HQ (8, 2, 73); Screen Fade Transition (3, 8, 1); Engine Action #58 |
| `ev[37]` | `1 (Action / Talk)` | Inventory Holds Item #32 [Drinking Set] AND Target Inspected is obj[8] | Open Dialogue Sub-Window (7); Reset Camera Tracking (73); Branch on Choice (101, 4); Pan Camera (101, 4, 7); Dismiss Emotion Bubble (2); Exit to World Map (0, 70, 0); Open Dialogue Message Window; Set Combat Battle BGM (20); Close Dialogue Sub-Window (8); Pan Camera (10, 73, 20); Warp to Castle HQ (8, 2, 73); Screen Fade Transition (3, 8, 1); Award Potch Loot (+514 Potch); Warp to Castle HQ (255, 2, 37); Warp Map Transition (10, 65, 128, 58, 255); Warp to Castle HQ (58, 255, 254) |

---

### Submap Layer `vf03_01` (Index 1)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `23` Objects | **Script Count (`evkaz`)**: `26` Scripts

#### Complete Physical Entity Inventory (23 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 82** | `82` | `(127, 67)` | `4x6` | South (Down) | Dormant / Hidden (0) | Special (3) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Jill Blight** | `125` | `(133, 65)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Killey** | `165` | `(147, 39)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | NPC / Actor | **Actor ID 164** | `164` | `(143, 39)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[04]` | Prop / Scenery | **Prop ID 53586** | `53586` | `(145, 32)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | Prop / Scenery | **Prop ID 53586** | `53586` | `(149, 32)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | Prop / Scenery | **Prop ID 53586** | `53586` | `(143, 40)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Prop / Scenery | **Prop ID 53586** | `53586` | `(147, 40)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Prop / Scenery | **Prop ID 53586** | `53586` | `(151, 40)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | World Device | **Mechanism (ano 5)** | `0` | `(139, 38)` | `0x0` | Frame 5 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(145, 30)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(149, 30)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(135, 63)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(166, 71)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(150, 51)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[15]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(174, 63)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[16]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(175, 65)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[17]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(171, 27)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[18]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(162, 27)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[19]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(138, 27)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[20]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(127, 27)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[21]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(124, 27)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[22]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(176, 27)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 82)**: Positioned at tile `(127, 67)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Jill Blight)**: Positioned at tile `(133, 65)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Killey)**: Positioned at tile `(147, 39)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Object 164)**: Positioned at tile `(143, 39)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Prop: Object 53586)**: Environmental world dressing prop placed at tile `(145, 32)`. Solid collision is set to `0`.
- **`obj[05]` (Prop: Object 53586)**: Environmental world dressing prop placed at tile `(149, 32)`. Solid collision is set to `0`.
- **`obj[06]` (Prop: Object 53586)**: Environmental world dressing prop placed at tile `(143, 40)`. Solid collision is set to `0`.
- **`obj[07]` (Prop: Object 53586)**: Environmental world dressing prop placed at tile `(147, 40)`. Solid collision is set to `0`.
- **`obj[08]` (Prop: Object 53586)**: Environmental world dressing prop placed at tile `(151, 40)`. Solid collision is set to `0`.
- **`obj[09]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(139, 38)` with state parameter `5`.
- **`obj[10]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(145, 30)` to `(146, 31)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[11]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(149, 30)` to `(150, 31)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[12]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(135, 63)` to `(138, 64)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[13]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(166, 71)` to `(167, 72)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[14]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(150, 51)` to `(151, 52)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[15]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(174, 63)` to `(175, 64)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[16]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(175, 65)` to `(176, 66)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[17]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(171, 27)` to `(174, 28)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[18]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(162, 27)` to `(163, 28)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[19]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(138, 27)` to `(139, 28)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[20]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(127, 27)` to `(130, 28)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[21]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(124, 27)` to `(125, 28)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[22]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(176, 27)` to `(177, 28)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (26 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Target Inspected is obj[20] | Open Dialogue Sub-Window (6); Engine Action #5 |
| `ev[01]` | `1 (Action / Talk)` | Target Inspected is obj[21] | Open Dialogue Sub-Window (6); Engine Action #6 |
| `ev[02]` | `1 (Action / Talk)` | Target Inspected is obj[22] | Open Dialogue Sub-Window (6); Set obj[255] Collision to Passable |
| `ev[03]` | `1 (Action / Talk)` | Target Inspected is obj[23] | Open Dialogue Sub-Window (6); Trigger Character Emotion Effect (255, 254) |
| `ev[04]` | `1 (Action / Talk)` | Target Inspected is obj[24] | Open Dialogue Sub-Window (6); Engine Action #61 |
| `ev[05]` | `1 (Action / Talk)` | Target Inspected is obj[25] | Open Dialogue Sub-Window (6); Engine Action #62 |
| `ev[06]` | `1 (Action / Talk)` | Target Inspected is obj[26] | Open Dialogue Sub-Window (6); Engine Action #63 |
| `ev[07]` | `1 (Action / Talk)` | Target Inspected is obj[27] | Open Dialogue Sub-Window (6); Animate Doorway State (255, 254) |
| `ev[08]` | `1 (Action / Talk)` | Target Inspected is obj[28] | Open Dialogue Sub-Window (6); Play Sound Effect (SE) (255) |
| `ev[09]` | `1 (Action / Talk)` | Target Inspected is obj[29] | Open Dialogue Sub-Window (6); Engine Action #66 |
| `ev[10]` | `1 (Action / Talk)` | Target Inspected is obj[30] | Open Dialogue Sub-Window (6); Open Shop Interface #255 |
| `ev[11]` | `2 (Map Init)` | Story Flag 65 (bit 16) SET AND Star of Destiny #0 Recruited AND Condition Check #82 | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[12]` | `2 (Map Init)` | Story Flag 65 (bit 16) SET AND Story Flag 65 (bit 128) CLEAR AND Story Flag 150 (bit 4) CLEAR | Open Dialogue Message Window; Engine Action #9 |
| `ev[13]` | `2 (Map Init)` | Player within Box [145..145, 2..31] AND Condition Check #31 AND Story Flag 64 (bit 32) SET AND Story Flag 0 (mask 16) SET AND Player within Box [82..16, 1..125] | Make obj[36] Hidden (disp = 0); Reset Camera Tracking (63); Warp Town -> Area 82 Map 125 Submap 89 at (12,2); Open Dialogue Message Window; Engine Action #89; Place Scenery Structure (2); Warp Town -> Area 89 Map 14 Submap 2 at (8,89); Show Dialogue Portrait (2, 10, 89); Dismiss Dialogue Portrait; Warp Town -> Area 4 Map 0 Submap 12 at (0,13); Open Dialogue Message Window; Animate Door Open; Open Dialogue Message Window; Show Dialogue Portrait (0, 16, 0); Change Portrait Expression (1); Open Dialogue Message Window; Teleport obj[255] to (254,255) |
| `ev[14]` | `2 (Map Init)` | Player within Box [145..145, 2..31] AND Condition Check #31 AND Story Flag 64 (bit 32) SET AND Story Flag 0 (mask 16) SET AND Player within Box [82..16, 1..172] | Make obj[36] Hidden (disp = 0); Reset Camera Tracking (63); Warp Town -> Area 82 Map 172 Submap 89 at (12,2); Open Dialogue Message Window; Engine Action #89; Place Scenery Structure (2); Warp Town -> Area 89 Map 14 Submap 2 at (8,89); Show Dialogue Portrait (2, 10, 89); Dismiss Dialogue Portrait; Warp Town -> Area 6 Map 0 Submap 12 at (0,13); Open Dialogue Message Window; Animate Door Open; Open Dialogue Message Window; Show Dialogue Portrait (0, 16, 0); Change Portrait Expression (1); Open Dialogue Message Window; Teleport obj[255] to (254,255) |
| `ev[15]` | `128 (Loop)` | Inventory Holds Item #8 [Fire Wall] AND Star of Destiny #1 Recruited AND Condition Check #125 | Toggle Random Encounters (8); Jump to Bytecode Offset (5, 0); Set Object Direction (0, 0); Play CD / Ambient BGM Track (101); Warp Room -> Submap 102 at (1,255) facing 254 |
| `ev[16]` | `128 (Loop)` | Inventory Holds Item #128 | Warp Room -> Submap 0 at (13,27); Toggle Random Encounters (128); Launch Tactical War Battle (64) |
| `ev[17]` | `1 (Action / Talk)` | Target Inspected is obj[8] AND Story Flag 150 (bit 4) CLEAR AND Story Flag 65 (bit 128) CLEAR | Recruit Character into Active Party (73 [Kasumi], 20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 0 Map 55 Submap 0 at (56,73); Trigger Character Emotion Effect (41, 2); Open Dialogue Message Window; Warp Room -> Submap 0 at (36,128) facing East (Right); Engine Action #9; Open Dialogue Message Window; Warp to Castle HQ (0, 1, 3); Reset Camera Tracking (1); Close Dialogue Sub-Window (9); Open Dialogue Message Window; Recruit Character into Active Party (48 [Mukumuku], 8); Open Dialogue Message Window; Warp to Castle HQ (0, 0, 0); Reset Camera Tracking (1); Reset Camera Tracking (34); Engine Action #54; Warp Room -> Submap 112 at (4,0) facing West (Left); Remove Item from Inventory (1, 70); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #58; Warp Room -> Submap 9 at (0,3) facing South (Down); Warp Room -> Submap 8 at (1,24) facing 9; Open Dialogue Message Window; Engine Action #58; Engine Action #58 |
| `ev[18]` | `1 (Action / Talk)` | Target Inspected is obj[8] AND Story Flag 150 (bit 4) CLEAR AND Story Flag 65 (bit 128) SET | Recruit Character into Active Party (73 [Kasumi], 20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 0 Map 55 Submap 0 at (56,73); Trigger Character Emotion Effect (41, 2); Open Dialogue Message Window; Warp Room -> Submap 0 at (36,128) facing 48; Reset Camera Tracking (0); Warp to Castle HQ (0, 0, 0); Reset Camera Tracking (1); Reset Camera Tracking (34); Engine Action #54; Warp Room -> Submap 112 at (4,0) facing West (Left); Remove Item from Inventory (1, 70); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #58; Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[19]` | `1 (Action / Talk)` | Target Inspected is obj[8] AND Story Flag 150 (bit 4) SET | Recruit Character into Active Party (73 [Kasumi], 20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 0 Map 55 Submap 0 at (56,73); Trigger Character Emotion Effect (41, 2); Open Dialogue Message Window; Warp Room -> Submap 0 at (36,128) facing 48; Reset Camera Tracking (0); Warp to Castle HQ (0, 0, 0); Reset Camera Tracking (1); Reset Camera Tracking (34); Engine Action #54; Warp Room -> Submap 112 at (4,0) facing West (Left); Remove Item from Inventory (1, 70); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #58; Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[20]` | `1 (Action / Talk)` | Target Inspected is obj[9] AND Condition Check #30 AND Always Passes (Unconditional) AND Player X within Range [255..254] | Engine Action #99; Open Dialogue Message Window; Warp Room -> Submap 0 at (53,255) facing 254 |
| `ev[21]` | `1 (Action / Talk)` | Target Inspected is obj[9] AND Condition Check #29 AND Always Passes (Unconditional) AND Player X within Range [255..254] | Open Dialogue Sub-Window (0); Engine Action #54 |
| `ev[22]` | `1 (Action / Talk)` | Player within Box [141..145, 2..69] AND Condition Check #70 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 42]; Engine Action #66 |
| `ev[23]` | `1 (Action / Talk)` | Player within Box [155..159, 2..69] AND Condition Check #70 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 58]; Engine Action #66 |
| `ev[24]` | `1 (Action / Talk)` | Story Flag 64 (bit 32) SET AND Story Flag 64 (bit 64) CLEAR AND Story Flag 150 (bit 4) CLEAR AND Player within Box [145..145, 2..31] AND Condition Check #31 AND Story Flag 0 (mask 255) SET | Recruit Character into Active Party (73 [Kasumi], 120); Engine Action #89; Place Scenery Structure (2); Warp to Castle HQ (73, 30, 46); Engine Action #89; Display Dialogue Box [Bank: 2, MsgID: 1]; Engine Action #89; Animate Door Open; Warp Town -> Area 9 Map 89 Submap 15 at (2,11); Engine Action #89; Dismiss Dialogue Portrait; Warp Town -> Area 5 Map 47 Submap 73 at (120,11); Warp Town -> Area 2 Map 180 Submap 73 at (30,46); Warp Room -> Submap 1 at (13,1) facing 14; Warp Room -> Submap 1 at (16,1) facing 17; Open Dialogue Message Window; Open Dialogue Message Window; Teleport Object to Coordinates (47, 77, 0); Warp Town -> Area 2 Map 30 Submap 3 at (0,0); Engine Action #9; Animate Doorway State (64, 11); Warp Room -> Submap 180 at (58,255) facing 254 |
| `ev[25]` | `1 (Action / Talk)` | Story Flag 64 (bit 32) SET AND Story Flag 64 (bit 64) CLEAR AND Story Flag 150 (bit 4) SET AND Player within Box [145..145, 2..31] AND Condition Check #31 AND Story Flag 0 (mask 255) SET | Recruit Character into Active Party (73 [Kasumi], 120); Engine Action #89; Place Scenery Structure (2); Warp to Castle HQ (73, 30, 46); Engine Action #89; Display Dialogue Box [Bank: 2, MsgID: 1]; Engine Action #89; Animate Door Open; Warp Town -> Area 9 Map 89 Submap 15 at (2,11); Engine Action #89; Dismiss Dialogue Portrait; Warp Town -> Area 7 Map 47 Submap 73 at (120,11); Warp Town -> Area 2 Map 180 Submap 73 at (30,46); Warp Room -> Submap 1 at (13,1) facing 14; Warp Room -> Submap 1 at (16,1) facing 17; Open Dialogue Message Window; Open Dialogue Message Window; Teleport Object to Coordinates (47, 77, 0); Warp Town -> Area 2 Map 30 Submap 3 at (0,0); Engine Action #9; Animate Doorway State (64, 11); Warp Room -> Submap 180 at (58,255) facing 254 |

---

### Submap Layer `vf03_02` (Index 2)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `24` Objects | **Script Count (`evkaz`)**: `30` Scripts

#### Complete Physical Entity Inventory (24 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Killey** | `165` | `(147, 39)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Actor ID 65072** | `65072` | `(53, 148)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | Trigger / Hitbox | **Hitbox Zone (9x2)** | `0` | `(49, 152)` | `8x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | Trigger / Hitbox | **Hitbox Zone (2x3)** | `0` | `(60, 146)` | `1x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | NPC / Actor | **Actor ID 166** | `166` | `(31, 158)` | `5x5` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[05]` | NPC / Actor | **Actor ID 65103** | `65103` | `(31, 135)` | `5x10` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[06]` | NPC / Actor | **Actor ID 65075** | `65075` | `(34, 127)` | `5x5` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[07]` | NPC / Actor | **Actor ID 65177** | `65177` | `(28, 125)` | `5x5` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[08]` | NPC / Actor | **Actor ID 64934** | `64934` | `(37, 120)` | `0x0` | Up (North) | Visible (1) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[09]` | NPC / Actor | **Actor ID 65072** | `65072` | `(64, 123)` | `5x5` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[10]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(66, 119)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(70, 161)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(72, 163)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(74, 161)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(76, 163)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[15]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(78, 161)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[16]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(75, 157)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[17]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(45, 145)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[18]` | Trigger / Hitbox | **Hitbox Zone (6x2)** | `0` | `(59, 119)` | `5x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[19]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(69, 119)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[20]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(73, 119)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[21]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(77, 120)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[22]` | Trigger / Hitbox | **Hitbox Zone (6x2)** | `0` | `(57, 129)` | `5x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[23]` | World Device | **Mechanism (ano 81)** | `0` | `(67, 21)` | `0x0` | Frame 81 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Killey)**: Positioned at tile `(147, 39)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Object 65072)**: Positioned at tile `(53, 148)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Hitbox Zone)**: Bounding trigger area covering `9` tiles wide by `2` tiles high from `(49, 152)` to `(57, 153)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[03]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `3` tiles high from `(60, 146)` to `(61, 148)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[04]` (Object 166)**: Positioned at tile `(31, 158)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Object 65103)**: Positioned at tile `(31, 135)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[06]` (Object 65075)**: Positioned at tile `(34, 127)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[07]` (Object 65177)**: Positioned at tile `(28, 125)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[08]` (Object 64934)**: Positioned at tile `(37, 120)`, facing Up (North). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[09]` (Object 65072)**: Positioned at tile `(64, 123)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[10]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(66, 119)` to `(67, 120)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[11]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(70, 161)` to `(71, 162)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[12]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(72, 163)` to `(73, 164)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[13]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(74, 161)` to `(75, 162)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[14]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(76, 163)` to `(77, 164)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[15]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(78, 161)` to `(79, 162)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[16]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(75, 157)` to `(76, 158)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[17]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(45, 145)` to `(46, 146)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[18]` (Hitbox Zone)**: Bounding trigger area covering `6` tiles wide by `2` tiles high from `(59, 119)` to `(64, 120)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[19]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(69, 119)` to `(72, 120)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[20]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(73, 119)` to `(76, 120)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[21]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(77, 120)` to `(78, 121)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[22]` (Hitbox Zone)**: Bounding trigger area covering `6` tiles wide by `2` tiles high from `(57, 129)` to `(62, 130)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[23]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(67, 21)` with state parameter `81`.


#### Complete Bytecode Script Catalog (30 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Open Dialogue Sub-Window (5); Open Dialogue Message Window |
| `ev[01]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Open Dialogue Sub-Window (5); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[02]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Open Dialogue Sub-Window (5); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[03]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Open Dialogue Sub-Window (5); Warp to Castle HQ (255, 254, 204) |
| `ev[04]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Open Dialogue Sub-Window (5); Exit to World Map (3, 16, 2) |
| `ev[05]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Open Dialogue Sub-Window (5); Engine Action #5 |
| `ev[06]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Open Dialogue Sub-Window (6); Pan Camera (255, 254, 204) |
| `ev[07]` | `1 (Action / Talk)` | Target Inspected is obj[19] | Open Dialogue Sub-Window (6); Play CD / Ambient BGM Track (255) |
| `ev[08]` | `1 (Action / Talk)` | Target Inspected is obj[20] | Open Dialogue Sub-Window (6); Wait for Audio / Window Sync (255) |
| `ev[09]` | `1 (Action / Talk)` | Target Inspected is obj[21] | Open Dialogue Sub-Window (6); Recruit Hero #255 into Battle Slot 254 |
| `ev[10]` | `1 (Action / Talk)` | Target Inspected is obj[22] | Open Dialogue Sub-Window (6); Remove Character from Active Party (255) |
| `ev[11]` | `1 (Action / Talk)` | Target Inspected is obj[23] | Open Dialogue Sub-Window (6); Load Sound Bank into Memory (255, 254) |
| `ev[12]` | `1 (Action / Talk)` | Target Inspected is obj[24] | Open Dialogue Sub-Window (6); Set Combat Battle BGM (255) |
| `ev[13]` | `1 (Action / Talk)` | Target Inspected is obj[25] | Open Dialogue Sub-Window (6); Set Special Scene BGM (255) |
| `ev[14]` | `1 (Action / Talk)` | Target Inspected is obj[26] | Open Dialogue Sub-Window (6); Full Rest & Healing (Restore HP/MP) |
| `ev[15]` | `1 (Action / Talk)` | Target Inspected is obj[27] | Open Dialogue Sub-Window (6); Full Rest & Healing (Restore HP/MP) |
| `ev[16]` | `1 (Action / Talk)` | Target Inspected is obj[28] | Open Dialogue Sub-Window (6); Award Potch Currency (255,254) |
| `ev[17]` | `1 (Action / Talk)` | Target Inspected is obj[29] | Open Dialogue Sub-Window (6); Engine Action #78 |
| `ev[18]` | `1 (Action / Talk)` | Target Inspected is obj[30] | Open Dialogue Sub-Window (6); Bytecode Subroutine Return |
| `ev[19]` | `128 (Loop)` | Player within Box [39..65, 2..157] AND Condition Check #166 | Warp Room -> Submap 0 at (5,1) |
| `ev[20]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Clear Story Milestone Flag 15 (mask 9); Warp Room -> Submap 5 at (45,2) facing 11; Open Dialogue Message Window |
| `ev[21]` | `1 (Action / Talk)` | Story Flag 1 (mask 5) SET AND Story Flag 255 (mask 254) CLEAR | Turn obj[9] facing South (Down); Warp to Castle HQ (0, 1, 6); Reset Camera Tracking (3); Engine Action #9; Open Dialogue Message Window; Clear Story Milestone Flag 15 (mask 9); Warp Room -> Submap 5 at (45,2) facing 11; Open Dialogue Message Window |
| `ev[22]` | `1 (Action / Talk)` | Story Flag 2 (mask 5) SET AND Player X in Range [255..254] | Turn obj[9] facing South (Down); Warp Town -> Area 6 Map 1 Submap 0 at (9,3); Engine Action #9; Warp to Castle HQ (96, 15, 9); Warp Room -> Submap 5 at (45,2) facing 11; Open Dialogue Message Window |
| `ev[23]` | `2 (Map Init)` | Story Flag 64 (bit 64) SET AND Player within Box [130..130, 2..73] AND Condition Check #73 AND Star of Destiny #1 Recruited AND Condition Check #73 | Make obj[63] Hidden (disp = 0); Warp Town -> Area 82 Map 73 Submap 2 at (1,130); Set Combat Battle BGM (0); Warp Room -> Submap 1 at (0,2) facing Up (North); Open Choice Selection Menu (70, 0); Warp Town -> Area 3 Map 2 Submap 0 at (1,0); Teleport obj[255] to (254,255) |
| `ev[24]` | `2 (Map Init)` | Story Flag 64 (bit 64) SET AND Player within Box [54..54, 2..30] AND Condition Check #30 | Make obj[2] Hidden (disp = 0); Reset Camera Tracking (54); Warp Room -> Submap 0 at (8,3); Reset Camera Tracking (3); Warp Room -> Submap 47 at (255,254) facing 255 |
| `ev[25]` | `1 (Action / Talk)` | Player within Box [49..51, 2..166] AND Condition Check #168 AND Story Flag 0 (mask 255) SET | Warp Map Transition (3, 0, 106, 131, 255) |
| `ev[26]` | `1 (Action / Talk)` | Player within Box [65..69, 2..130] AND Condition Check #131 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 3, MsgID: 177]; Show Character Dialogue Portrait (255, 254, 204) |
| `ev[27]` | `1 (Action / Talk)` | Story Flag 64 (bit 64) SET AND Player within Box [130..130, 2..73] AND Condition Check #73 AND Star of Destiny #1 Recruited AND Condition Check #73 | Recruit Character into Active Party (11 [Georg], 1); Warp Town -> Area 90 Map 73 Submap 120 at (24,2); Open Dialogue Message Window; Warp Map Transition (73, 120, 24, 2, 0); Return to Previous Memory Map (73); Engine Action #250; Close Dialogue Sub-Window (2); Open Dialogue Message Window; Return Warp to Castle Base (73, 250); Close Dialogue Sub-Window (2); Open Dialogue Message Window; Start Boss Battle #73 (BGM: 30); Award Potch Currency (2,7); Exit to World Map (30, 73, 90); Close Dialogue Sub-Window (2); Open Dialogue Message Window; Launch Tactical War Battle (73); Trigger Character Emotion Effect (43, 2); Engine Action #6; Set Render Priority (pri) (2, 130); Engine Action #51; Engine Action #9; Open Shop Menu #4 (Type: 2); Set Combat Battle BGM (60); Wait for Audio / Window Sync (3); Close Dialogue Window; Warp Town -> Area 2 Map 90 Submap 73 at (30,12); Warp Town -> Area 54 Map 30 Submap 58 at (255,254) |
| `ev[28]` | `1 (Action / Talk)` | Story Flag 64 (bit 64) SET AND Player within Box [54..54, 2..30] AND Condition Check #30 | Recruit Character into Active Party (11 [Georg], 1); Warp Town -> Area 90 Map 73 Submap 20 at (24,8); Open Dialogue Message Window; Toggle Random Encounters (3); Reset Camera Tracking (0); Set Combat Battle BGM (10); Warp to Castle HQ (8, 2, 69); Warp to Castle HQ (11, 2, 2); Engine Action #90; Set Combat Battle BGM (30); Display Dialogue Box [Bank: 3, MsgID: 71]; Return Warp to Castle Base (58, 255) |
| `ev[29]` | `2 (Map Init)` | Story Flag 150 (bit 4) SET | Open Dialogue Message Window; Warp Room -> Submap 255 at (254,204) |

---

### Submap Layer `vf03_03` (Index 3)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `12` Objects | **Script Count (`evkaz`)**: `20` Scripts

#### Complete Physical Entity Inventory (12 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 81)** | `0` | `(67, 21)` | `0x0` | Frame 81 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Actor ID 65196** | `65196` | `(150, 158)` | `5x5` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[02]` | NPC / Actor | **Actor ID 167** | `167` | `(152, 124)` | `5x5` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[03]` | NPC / Actor | **Actor ID 65176** | `65176` | `(168, 158)` | `5x5` | South (Down) | Visible (1) | Special (3) | 2 | 128 | 0 |
| `obj[04]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(173, 119)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(163, 155)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(141, 155)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(145, 119)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(145, 119)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(129, 119)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(135, 119)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(124, 157)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(67, 21)` with state parameter `81`.
- **`obj[01]` (Object 65196)**: Positioned at tile `(150, 158)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Object 167)**: Positioned at tile `(152, 124)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Object 65176)**: Positioned at tile `(168, 158)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(173, 119)` to `(176, 120)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[05]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(163, 155)` to `(164, 156)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[06]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(141, 155)` to `(144, 156)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[07]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(145, 119)` to `(148, 120)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[08]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(145, 119)` to `(148, 120)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[09]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(129, 119)` to `(132, 120)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[10]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(135, 119)` to `(138, 120)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[11]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(124, 157)` to `(125, 158)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (20 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Open Dialogue Sub-Window (5); Engine Action #6 |
| `ev[01]` | `1 (Action / Talk)` | Target Inspected is obj[10] AND Story Flag 49 (bit 64) CLEAR AND Temp Event Flag #1 SET | Open Dialogue Sub-Window (5); Pan Camera (101, 4, 7); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (2); Exit to World Map (0, 6, 32); Open Dialogue Message Window; Award Potch Loot (+514 Potch); Warp to Castle HQ (255, 2, 9); Set Entity Movement Speed (64, 255); Warp to Castle HQ (36, 1, 255) |
| `ev[02]` | `1 (Action / Talk)` | Target Inspected is obj[10] AND Story Flag 49 (bit 64) CLEAR AND Inventory Holds Item #1 [Medicine] | Open Dialogue Sub-Window (5); Start Boss Battle #101 (BGM: 4); Pan Camera (101, 4, 7); Dismiss Emotion Bubble (2); Exit to World Map (0, 6, 32); Open Dialogue Message Window; Award Potch Loot (+514 Potch); Warp to Castle HQ (255, 2, 9); Set Entity Movement Speed (64, 255); Warp to Castle HQ (36, 1, 255) |
| `ev[03]` | `1 (Action / Talk)` | Target Inspected is obj[10] AND Story Flag 49 (bit 64) SET | Open Dialogue Sub-Window (5); Launch Tactical War Battle (255) |
| `ev[04]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Open Dialogue Sub-Window (5); Reset Camera Tracking (255) |
| `ev[05]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Open Dialogue Sub-Window (6); Engine Action #80 |
| `ev[06]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Open Dialogue Sub-Window (6); Engine Action #81 |
| `ev[07]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Open Dialogue Sub-Window (6); Remove Item from Inventory (255, 254) |
| `ev[08]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Open Dialogue Sub-Window (6); Engine Action #83 |
| `ev[09]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Open Dialogue Sub-Window (6); Dismiss Character to Castle Base (255) |
| `ev[10]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Open Dialogue Sub-Window (6); Engine Action #85 |
| `ev[11]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Open Dialogue Sub-Window (6); Animate Door obj[255] (State: 254) |
| `ev[12]` | `1 (Action / Talk)` | Target Inspected is obj[19] | Open Dialogue Sub-Window (6); Engine Action #87 |
| `ev[13]` | `2 (Map Init)` | Story Flag 150 (bit 4) SET | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[14]` | `2 (Map Init)` | Story Flag 64 (bit 64) SET AND Story Flag 150 (bit 4) CLEAR AND Player within Box [71..71, 2..34] AND Condition Check #34 AND Star of Destiny #1 Recruited AND Condition Check #82 AND Star of Destiny #1 Recruited AND Condition Check #125 | Make obj[63] Hidden (disp = 0); Warp Town -> Area 82 Map 125 Submap 2 at (1,71); Return to Previous Memory Map (0); Warp Room -> Submap 1 at (1,2) facing Up (North); Load Sound Bank into Memory (29, 0); Warp Town -> Area 3 Map 2 Submap 1 at (1,0); Teleport obj[255] to (254,255) |
| `ev[15]` | `2 (Map Init)` | Story Flag 64 (bit 64) SET AND Story Flag 150 (bit 4) SET AND Player within Box [71..71, 2..34] AND Condition Check #34 AND Star of Destiny #1 Recruited AND Condition Check #82 AND Star of Destiny #1 Recruited AND Condition Check #172 | Make obj[63] Hidden (disp = 0); Warp Town -> Area 82 Map 172 Submap 2 at (1,71); Return to Previous Memory Map (0); Warp Room -> Submap 1 at (1,2) facing Up (North); Play CD / Ambient BGM Track (30); Open Dialogue Message Window; Warp Town -> Area 3 Map 2 Submap 1 at (1,0); Teleport obj[255] to (254,255) |
| `ev[16]` | `1 (Action / Talk)` | Player within Box [175..179, 2..128] AND Condition Check #130 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 67]; Engine Action #140 |
| `ev[17]` | `1 (Action / Talk)` | Player within Box [125..129, 2..147] AND Condition Check #148 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 4, MsgID: 23]; Engine Action #220 |
| `ev[18]` | `1 (Action / Talk)` | Story Flag 64 (bit 64) SET AND Story Flag 150 (bit 4) CLEAR AND Player within Box [71..71, 2..34] AND Condition Check #34 | Recruit Character into Active Party (11 [Georg], 1); Warp Town -> Area 90 Map 73 Submap 90 at (3,2); Warp Town -> Area 73 Map 10 Submap 3 at (2,0); Close Dialogue Sub-Window (2); Open Dialogue Message Window; Open Save Crystal Menu (MSaveInit); Set Combat Battle BGM (180); Engine Action #9; Animate Doorway State (128, 69); Warp to Castle HQ (11, 2, 2); Engine Action #90; Set Combat Battle BGM (30); Display Dialogue Box [Bank: 0, MsgID: 50]; Engine Action #66; Engine Action #58 |
| `ev[19]` | `1 (Action / Talk)` | Story Flag 64 (bit 64) SET AND Story Flag 150 (bit 4) SET AND Player within Box [71..71, 2..34] AND Condition Check #34 | Recruit Character into Active Party (11 [Georg], 1); Warp Town -> Area 90 Map 73 Submap 90 at (3,2); Warp to Castle HQ (73, 10, 3); Warp Town -> Area 0 Map 73 Submap 30 at (48,2); Warp Room -> Submap 0 at (1,2) facing 9; Warp to Castle HQ (2, 0, 73); Trigger Character Emotion Effect (24, 2); Open Dialogue Message Window; Engine Action #39; Set Combat Battle BGM (120); Turn obj[2] facing West (Left); Warp Town -> Area 0 Map 1 Submap 1 at (9,73); Trigger Character Emotion Effect (24, 2); Open Dialogue Message Window; Engine Action #40; Set Combat Battle BGM (60); Close Dialogue Sub-Window (2); Open Dialogue Message Window; Award Potch Loot (+18,778 Potch); Engine Action #9; Animate Doorway State (128, 69); Warp to Castle HQ (11, 2, 2); Engine Action #90; Set Combat Battle BGM (30); Display Dialogue Box [Bank: 0, MsgID: 50]; Engine Action #66; Engine Action #58 |

---

### Submap Layer `vf03_04` (Index 4)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `4` Objects | **Script Count (`evkaz`)**: `5` Scripts

#### Complete Physical Entity Inventory (4 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(32, 223)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[01]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(35, 223)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(43, 215)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(43, 219)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(32, 223)` to `(33, 224)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[01]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(35, 223)` to `(36, 224)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[02]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(43, 215)` to `(44, 216)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[03]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(43, 219)` to `(44, 220)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (5 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Target Inspected is obj[8] | Open Dialogue Sub-Window (6); Reset Camera Tracking (255) |
| `ev[01]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Open Dialogue Sub-Window (6); Engine Action #88 |
| `ev[02]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Open Dialogue Sub-Window (6); Engine Action #89 |
| `ev[03]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Open Dialogue Sub-Window (6); Engine Action #90 |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [21..25, 2..223] AND Condition Check #224 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 3, MsgID: 127]; Engine Action #156 |

---

### Submap Layer `vf03_05` (Index 5)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `4` Objects | **Script Count (`evkaz`)**: `5` Scripts

#### Complete Physical Entity Inventory (4 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 64984** | `64984` | `(107, 217)` | `2x5` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[01]` | NPC / Actor | **Actor ID 64772** | `64772` | `(100, 220)` | `5x3` | South (Down) | Visible (1) | Special (3) | 4 | 128 | 0 |
| `obj[02]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(103, 209)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(107, 209)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 64984)**: Positioned at tile `(107, 217)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Object 64772)**: Positioned at tile `(100, 220)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(103, 209)` to `(106, 210)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[03]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(107, 209)` to `(110, 210)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (5 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Target Inspected is obj[8] | Open Dialogue Sub-Window (5); Engine Action #9 |
| `ev[01]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Open Dialogue Sub-Window (5); Toggle Random Encounters (255) |
| `ev[02]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Open Dialogue Sub-Window (6); Make Object Visible (disp = 1) (255) |
| `ev[03]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Open Dialogue Sub-Window (6); Make Object Hidden (disp = 0) (255) |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [101..103, 2..228] AND Condition Check #229 AND Story Flag 0 (mask 255) SET | Warp Map Transition (3, 0, 156, 24, 255) |

---

### Submap Layer `vf03_06` (Index 6)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `8` Objects | **Script Count (`evkaz`)**: `9` Scripts

#### Complete Physical Entity Inventory (8 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 65088** | `65088` | `(169, 214)` | `15x15` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[01]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(160, 215)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(164, 213)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(172, 209)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(177, 213)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(164, 219)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(168, 219)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(172, 219)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 65088)**: Positioned at tile `(169, 214)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(160, 215)` to `(161, 216)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[02]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(164, 213)` to `(165, 214)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[03]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(172, 209)` to `(173, 210)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[04]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(177, 213)` to `(178, 214)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[05]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(164, 219)` to `(165, 220)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[06]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(168, 219)` to `(169, 220)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[07]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(172, 219)` to `(173, 220)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (9 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Target Inspected is obj[8] | Open Dialogue Sub-Window (5); Screen Fade Transition (255, 254, 204) |
| `ev[01]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Open Dialogue Sub-Window (6); Engine Action #9 |
| `ev[02]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Open Dialogue Sub-Window (6); Screen Fade Transition (255, 254, 204) |
| `ev[03]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Open Dialogue Sub-Window (6); Close Dialogue Window |
| `ev[04]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Open Dialogue Sub-Window (6); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[05]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Open Dialogue Sub-Window (6); Place Scenery Structure (255) |
| `ev[06]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Open Dialogue Sub-Window (6); Animate Door Open |
| `ev[07]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Open Dialogue Sub-Window (6); Show Dialogue Portrait (255, 254, 204) |
| `ev[08]` | `1 (Action / Talk)` | Player within Box [167..169, 2..228] AND Condition Check #229 AND Story Flag 0 (mask 255) SET | Warp Map Transition (3, 0, 28, 122, 255) |

---

### Submap Layer `vf03_07` (Index 7)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `15` Objects | **Script Count (`evkaz`)**: `16` Scripts

#### Complete Physical Entity Inventory (15 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 65027** | `65027` | `(39, 29)` | `5x5` | South (Down) | Visible (1) | Special (3) | 2 | 128 | 0 |
| `obj[01]` | NPC / Actor | **Actor ID 65037** | `65037` | `(25, 48)` | `10x10` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[02]` | NPC / Actor | **Actor ID 65210** | `65210` | `(39, 32)` | `5x10` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[03]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(34, 25)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(55, 25)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(25, 25)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | Trigger / Hitbox | **Hitbox Zone (6x2)** | `0` | `(37, 25)` | `5x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(45, 25)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(59, 24)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(72, 31)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(37, 45)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(37, 51)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(25, 50)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(35, 50)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(51, 25)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 65027)**: Positioned at tile `(39, 29)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Object 65037)**: Positioned at tile `(25, 48)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Object 65210)**: Positioned at tile `(39, 32)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(34, 25)` to `(35, 26)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[04]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(55, 25)` to `(58, 26)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[05]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(25, 25)` to `(26, 26)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[06]` (Hitbox Zone)**: Bounding trigger area covering `6` tiles wide by `2` tiles high from `(37, 25)` to `(42, 26)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[07]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(45, 25)` to `(48, 26)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[08]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(59, 24)` to `(61, 25)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[09]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(72, 31)` to `(73, 32)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[10]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(37, 45)` to `(40, 46)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[11]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(37, 51)` to `(40, 52)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[12]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(25, 50)` to `(26, 51)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[13]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(35, 50)` to `(36, 51)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[14]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(51, 25)` to `(54, 26)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (16 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Target Inspected is obj[8] | Open Dialogue Sub-Window (5); Close Dialogue Window |
| `ev[01]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Open Dialogue Sub-Window (5); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[02]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Open Dialogue Sub-Window (5); Place Scenery Structure (255) |
| `ev[03]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Open Dialogue Sub-Window (6); Dismiss Dialogue Portrait |
| `ev[04]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Open Dialogue Sub-Window (6); Change Portrait Expression (255) |
| `ev[05]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Open Dialogue Sub-Window (6); Engine Action #93 |
| `ev[06]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Open Dialogue Sub-Window (6); Engine Action #94 |
| `ev[07]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Open Dialogue Sub-Window (6); Set Story Milestone Flag 255 (mask 254) |
| `ev[08]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Open Dialogue Sub-Window (6); Clear Story Milestone Flag 255 (mask 254) |
| `ev[09]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Open Dialogue Sub-Window (6); Mark Chest Looted (Byte 255, Bit 254) |
| `ev[10]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Open Dialogue Sub-Window (6); Clear Chest Looted Flag (255, 254) |
| `ev[11]` | `1 (Action / Talk)` | Target Inspected is obj[19] | Open Dialogue Sub-Window (6); Engine Action #99 |
| `ev[12]` | `1 (Action / Talk)` | Target Inspected is obj[20] | Open Dialogue Sub-Window (6); Mark NPC Talk Interaction Complete (Flag #255) |
| `ev[13]` | `1 (Action / Talk)` | Target Inspected is obj[21] | Open Dialogue Sub-Window (6); Jump to Bytecode Offset (255, 254) |
| `ev[14]` | `1 (Action / Talk)` | Target Inspected is obj[22] | Open Dialogue Sub-Window (6); Engine Action #102 |
| `ev[15]` | `1 (Action / Talk)` | Player within Box [28..31, 2..61] AND Condition Check #62 AND Story Flag 0 (mask 255) SET | Warp Map Transition (3, 0, 198, 43, 255) |

---

### Submap Layer `vf03_08` (Index 8)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `9` Objects | **Script Count (`evkaz`)**: `10` Scripts

#### Complete Physical Entity Inventory (9 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 65086** | `65086` | `(132, 29)` | `3x8` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[01]` | NPC / Actor | **Actor ID 65069** | `65069` | `(123, 49)` | `10x10` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[02]` | NPC / Actor | **Actor ID 65071** | `65071` | `(150, 30)` | `20x20` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[03]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(160, 25)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(143, 27)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(139, 29)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(133, 25)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(115, 39)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(115, 53)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 65086)**: Positioned at tile `(132, 29)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Object 65069)**: Positioned at tile `(123, 49)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Object 65071)**: Positioned at tile `(150, 30)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(160, 25)` to `(161, 26)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[04]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(143, 27)` to `(146, 28)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[05]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(139, 29)` to `(142, 30)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[06]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(133, 25)` to `(134, 26)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[07]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(115, 39)` to `(118, 40)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[08]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(115, 53)` to `(118, 54)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (10 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Target Inspected is obj[8] | Open Dialogue Sub-Window (5); Animate Door Open |
| `ev[01]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Open Dialogue Sub-Window (5); Show Dialogue Portrait (255, 254, 204) |
| `ev[02]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Open Dialogue Sub-Window (5); Dismiss Dialogue Portrait |
| `ev[03]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Open Dialogue Sub-Window (6); Display Speaker Name Box (255) |
| `ev[04]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Open Dialogue Sub-Window (6); Display Choice Selection (255, 254) |
| `ev[05]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Open Dialogue Sub-Window (6); Teleport Object to Coordinates (255, 254, 204) |
| `ev[06]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Open Dialogue Sub-Window (6); Engine Action #104 |
| `ev[07]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Open Dialogue Sub-Window (6); Set Object Direction (255, 254) |
| `ev[08]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Open Dialogue Sub-Window (6); Set Character Quest Milestone (255, 254) |
| `ev[09]` | `1 (Action / Talk)` | Player within Box [155..157, 2..45] AND Condition Check #46 AND Story Flag 0 (mask 255) SET | Warp Map Transition (3, 0, 114, 54, 255) |

---

### Submap Layer `vf03_09` (Index 9)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `12` Objects | **Script Count (`evkaz`)**: `15` Scripts

#### Complete Physical Entity Inventory (12 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 65072** | `65072` | `(29, 100)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Actor ID 65060** | `65060` | `(62, 100)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | Trigger / Hitbox | **Hitbox Zone (19x2)** | `0` | `(21, 105)` | `18x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | Trigger / Hitbox | **Hitbox Zone (19x2)** | `0` | `(55, 105)` | `18x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | NPC / Actor | **Actor ID 65074** | `65074` | `(46, 101)` | `3x10` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[05]` | NPC / Actor | **Actor ID 65226** | `65226` | `(58, 109)` | `5x5` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[06]` | Trigger / Hitbox | **Hitbox Zone (8x2)** | `0` | `(25, 97)` | `7x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Hitbox Zone (2x6)** | `0` | `(33, 95)` | `1x5` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(48, 99)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(56, 97)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(63, 97)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(68, 97)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 65072)**: Positioned at tile `(29, 100)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Object 65060)**: Positioned at tile `(62, 100)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Hitbox Zone)**: Bounding trigger area covering `19` tiles wide by `2` tiles high from `(21, 105)` to `(39, 106)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[03]` (Hitbox Zone)**: Bounding trigger area covering `19` tiles wide by `2` tiles high from `(55, 105)` to `(73, 106)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[04]` (Object 65074)**: Positioned at tile `(46, 101)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Object 65226)**: Positioned at tile `(58, 109)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[06]` (Hitbox Zone)**: Bounding trigger area covering `8` tiles wide by `2` tiles high from `(25, 97)` to `(32, 98)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[07]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `6` tiles high from `(33, 95)` to `(34, 100)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[08]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(48, 99)` to `(49, 100)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[09]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(56, 97)` to `(57, 98)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[10]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(63, 97)` to `(66, 98)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[11]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(68, 97)` to `(69, 98)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (15 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Open Dialogue Sub-Window (5); Change Portrait Expression (255) |
| `ev[01]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Open Dialogue Sub-Window (5); Display Speaker Name Box (255) |
| `ev[02]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Open Dialogue Sub-Window (6); Engine Action #107 |
| `ev[03]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Open Dialogue Sub-Window (6); Engine Action #108 |
| `ev[04]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Open Dialogue Sub-Window (6); Engine Action #109 |
| `ev[05]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Open Dialogue Sub-Window (6); Engine Action #110 |
| `ev[06]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Open Dialogue Sub-Window (6); Engine Action #111 |
| `ev[07]` | `1 (Action / Talk)` | Target Inspected is obj[19] | Open Dialogue Sub-Window (6); Pathfind and Walk to Coordinates (255, 254, 204) |
| `ev[08]` | `128 (Loop)` | Player within Box [21..73, 2..109] AND Condition Check #116 | Warp Room -> Submap 0 at (5,1) |
| `ev[09]` | `1 (Action / Talk)` | Target Inspected is obj[10] AND Story Flag 1 (mask 255) SET | Turn obj[8] facing South (Down); Warp to Castle HQ (0, 1, 6); Reset Camera Tracking (3); Reset Camera Tracking (0); Clear Story Milestone Flag 7 (mask 8); Warp Room -> Submap 5 at (42,3) facing South (Down); Screen Fade Transition (21, 255, 254) |
| `ev[10]` | `1 (Action / Talk)` | Target Inspected is obj[8] | Clear Story Milestone Flag 7 (mask 8); Warp Room -> Submap 5 at (42,3) facing South (Down); Screen Fade Transition (21, 255, 254) |
| `ev[11]` | `1 (Action / Talk)` | Target Inspected is obj[11] AND Story Flag 1 (mask 255) SET | Turn obj[9] facing South (Down); Warp to Castle HQ (0, 1, 6); Reset Camera Tracking (3); Engine Action #9; Open Dialogue Message Window; Clear Story Milestone Flag 7 (mask 9); Warp Room -> Submap 5 at (43,3) facing West (Left); Place Scenery Structure (7) |
| `ev[12]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Clear Story Milestone Flag 7 (mask 9); Warp Room -> Submap 5 at (43,3) facing West (Left); Place Scenery Structure (7) |
| `ev[13]` | `1 (Action / Talk)` | Player within Box [29..31, 2..117] AND Condition Check #118 AND Story Flag 0 (mask 255) SET | Warp Map Transition (3, 0, 156, 131, 255) |
| `ev[14]` | `1 (Action / Talk)` | Player within Box [63..65, 2..117] AND Condition Check #118 AND Story Flag 0 (mask 255) SET | Warp Map Transition (3, 0, 172, 131, 255) |

---

### Submap Layer `vf03_10` (Index 10)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `10` Objects | **Script Count (`evkaz`)**: `12` Scripts

#### Complete Physical Entity Inventory (10 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 65082** | `65082` | `(161, 108)` | `5x5` | South (Down) | Visible (1) | Special (3) | 4 | 128 | 0 |
| `obj[01]` | NPC / Actor | **Actor ID 65176** | `65176` | `(139, 102)` | `5x5` | South (Down) | Visible (1) | Special (3) | 2 | 128 | 0 |
| `obj[02]` | NPC / Actor | **Actor ID 65211** | `65211` | `(125, 102)` | `3x3` | South (Down) | Visible (1) | Special (3) | 2 | 128 | 0 |
| `obj[03]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(139, 99)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(117, 99)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(119, 97)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | Trigger / Hitbox | **Hitbox Zone (6x2)** | `0` | `(123, 97)` | `5x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(153, 97)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(155, 97)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(159, 97)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 65082)**: Positioned at tile `(161, 108)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Object 65176)**: Positioned at tile `(139, 102)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Object 65211)**: Positioned at tile `(125, 102)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(139, 99)` to `(142, 100)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[04]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(117, 99)` to `(118, 100)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[05]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(119, 97)` to `(122, 98)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[06]` (Hitbox Zone)**: Bounding trigger area covering `6` tiles wide by `2` tiles high from `(123, 97)` to `(128, 98)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[07]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(153, 97)` to `(154, 98)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[08]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(155, 97)` to `(158, 98)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[09]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(159, 97)` to `(162, 98)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (12 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Target Inspected is obj[8] | Open Dialogue Sub-Window (5); Display Choice Selection (255, 254) |
| `ev[01]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Open Dialogue Sub-Window (5); Branch on Choice (255, 254) |
| `ev[02]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Open Dialogue Sub-Window (5); Execute Choice Result (255) |
| `ev[03]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Open Dialogue Sub-Window (6); Branch on Choice (255, 254) |
| `ev[04]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Open Dialogue Sub-Window (6); Engine Action #113 |
| `ev[05]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Open Dialogue Sub-Window (6); Engine Action #114 |
| `ev[06]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Open Dialogue Sub-Window (6); Engine Action #115 |
| `ev[07]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Open Dialogue Sub-Window (6); Engine Action #116 |
| `ev[08]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Open Dialogue Sub-Window (6); Engine Action #117 |
| `ev[09]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Open Dialogue Sub-Window (6); Engine Action #118 |
| `ev[10]` | `1 (Action / Talk)` | Player within Box [123..125, 2..117] AND Condition Check #118 AND Story Flag 0 (mask 255) SET | Warp Map Transition (3, 0, 84, 95, 255) |
| `ev[11]` | `1 (Action / Talk)` | Player within Box [157..159, 2..117] AND Condition Check #118 AND Story Flag 0 (mask 255) SET | Warp Map Transition (3, 0, 98, 95, 255) |

---

### Submap Layer `vf03_11` (Index 11)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `8` Objects | **Script Count (`evkaz`)**: `10` Scripts

#### Complete Physical Entity Inventory (8 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Rare Items Dealer** | `65174` | `(32, 156)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | Trigger / Hitbox | **Hitbox Zone (19x2)** | `0` | `(21, 160)` | `18x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Actor ID 65072** | `65072` | `(55, 161)` | `10x10` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[03]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(29, 153)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(31, 153)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(37, 153)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(61, 153)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(65, 153)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Rare Items Dealer)**: Positioned at tile `(32, 156)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Hitbox Zone)**: Bounding trigger area covering `19` tiles wide by `2` tiles high from `(21, 160)` to `(39, 161)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[02]` (Object 65072)**: Positioned at tile `(55, 161)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(29, 153)` to `(30, 154)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[04]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(31, 153)` to `(34, 154)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[05]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(37, 153)` to `(40, 154)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[06]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(61, 153)` to `(64, 154)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[07]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(65, 153)` to `(68, 154)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (10 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Open Dialogue Sub-Window (5); Set Story Flag (255, 254) |
| `ev[01]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Open Dialogue Sub-Window (6); Engine Action #119 |
| `ev[02]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Open Dialogue Sub-Window (6); Engine Action #120 |
| `ev[03]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Open Dialogue Sub-Window (6); Engine Action #121 |
| `ev[04]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Open Dialogue Sub-Window (6); Engine Action #122 |
| `ev[05]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Open Dialogue Sub-Window (6); Engine Action #123 |
| `ev[06]` | `128 (Loop)` | Player within Box [21..50, 2..165] AND Condition Check #172 | Warp Room -> Submap 0 at (5,1) |
| `ev[07]` | `1 (Action / Talk)` | Player within Box [29..31, 2..173] AND Condition Check #174 AND Story Flag 0 (mask 255) SET | Warp Map Transition (3, 0, 190, 130, 255) |
| `ev[08]` | `1 (Action / Talk)` | Target Inspected is obj[9] AND Story Flag 1 (mask 255) SET | Turn obj[8] facing South (Down); Warp to Castle HQ (0, 1, 6); Reset Camera Tracking (3); Reset Camera Tracking (0); Clear Story Milestone Flag 13 (mask 8); Warp Room -> Submap 5 at (44,2) facing 12; Place Scenery Structure (255) |
| `ev[09]` | `1 (Action / Talk)` | Target Inspected is obj[8] | Clear Story Milestone Flag 13 (mask 8); Warp Room -> Submap 5 at (44,2) facing 12; Open Dialogue Message Window |

---

### Submap Layer `vf03_12` (Index 12)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `15` Objects | **Script Count (`evkaz`)**: `16` Scripts

#### Complete Physical Entity Inventory (15 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 65037** | `65037` | `(161, 184)` | `5x5` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[01]` | NPC / Actor | **Actor ID 65177** | `65177` | `(158, 157)` | `10x10` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[02]` | NPC / Actor | **Actor ID 65226** | `65226` | `(143, 156)` | `10x10` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[03]` | NPC / Actor | **Actor ID 65042** | `65042` | `(125, 166)` | `5x5` | South (Down) | Visible (1) | Special (3) | 4 | 128 | 0 |
| `obj[04]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(163, 155)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(119, 153)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(168, 155)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(167, 158)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Trigger / Hitbox | **Hitbox Zone (6x2)** | `0` | `(157, 153)` | `5x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(149, 153)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(145, 153)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(141, 153)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(115, 183)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(115, 189)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(131, 153)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 65037)**: Positioned at tile `(161, 184)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Object 65177)**: Positioned at tile `(158, 157)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Object 65226)**: Positioned at tile `(143, 156)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Object 65042)**: Positioned at tile `(125, 166)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(163, 155)` to `(166, 156)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[05]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(119, 153)` to `(122, 154)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[06]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(168, 155)` to `(169, 156)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[07]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(167, 158)` to `(168, 159)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[08]` (Hitbox Zone)**: Bounding trigger area covering `6` tiles wide by `2` tiles high from `(157, 153)` to `(162, 154)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[09]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(149, 153)` to `(152, 154)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[10]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(145, 153)` to `(148, 154)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[11]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(141, 153)` to `(144, 154)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[12]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(115, 183)` to `(118, 184)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[13]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(115, 189)` to `(118, 190)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[14]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(131, 153)` to `(134, 154)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (16 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Target Inspected is obj[8] | Open Dialogue Sub-Window (5); Open Dialogue Sub-Window (255) |
| `ev[01]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Open Dialogue Sub-Window (5); Close Dialogue Sub-Window (255) |
| `ev[02]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Open Dialogue Sub-Window (5); Clear Dialogue Sub-Window |
| `ev[03]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Open Dialogue Sub-Window (5); Fade In from Black (255) |
| `ev[04]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Open Dialogue Sub-Window (6); Execute Choice Result (255) |
| `ev[05]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Open Dialogue Sub-Window (6); Set Story Flag (255, 254) |
| `ev[06]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Open Dialogue Sub-Window (6); Show Character Dialogue Portrait (255, 254, 204) |
| `ev[07]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Open Dialogue Sub-Window (6); Dismiss Character Dialogue Portrait |
| `ev[08]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Open Dialogue Sub-Window (6); Engine Action #126 |
| `ev[09]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Open Dialogue Sub-Window (6); Engine Action #127 |
| `ev[10]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Open Dialogue Sub-Window (6); Engine Action #128 |
| `ev[11]` | `1 (Action / Talk)` | Target Inspected is obj[19] | Open Dialogue Sub-Window (6); Display Dialogue Message (255, 254) |
| `ev[12]` | `1 (Action / Talk)` | Target Inspected is obj[20] | Open Dialogue Sub-Window (6); Display Dialogue with Speaker Name (255, 254, 204) |
| `ev[13]` | `1 (Action / Talk)` | Target Inspected is obj[21] | Open Dialogue Sub-Window (6); Engine Action #131 |
| `ev[14]` | `1 (Action / Talk)` | Target Inspected is obj[22] | Open Dialogue Sub-Window (6); Engine Action #132 |
| `ev[15]` | `1 (Action / Talk)` | Player within Box [141..143, 2..167] AND Condition Check #168 AND Story Flag 0 (mask 255) SET | Warp Map Transition (3, 0, 78, 47, 255) |

---

### Submap Layer `vf03_13` (Index 13)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `14` Objects | **Script Count (`evkaz`)**: `21` Scripts

#### Complete Physical Entity Inventory (14 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Hix** | `106` | `(46, 213)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Actor ID 65089** | `65089` | `(46, 213)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Actor ID 65090** | `65090` | `(61, 214)` | `5x5` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[03]` | NPC / Actor | **Actor ID 65072** | `65072` | `(64, 210)` | `4x4` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[04]` | NPC / Actor | **Actor ID 65088** | `65088` | `(23, 220)` | `5x5` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[05]` | NPC / Actor | **Actor ID 65226** | `65226` | `(59, 216)` | `5x5` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[06]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(28, 219)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(72, 211)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(70, 207)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(29, 210)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(29, 213)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(31, 220)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(21, 213)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | Trigger / Hitbox | **Hitbox Zone (6x2)** | `0` | `(21, 209)` | `5x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Hix)**: Positioned at tile `(46, 213)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Object 65089)**: Positioned at tile `(46, 213)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Object 65090)**: Positioned at tile `(61, 214)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Object 65072)**: Positioned at tile `(64, 210)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Object 65088)**: Positioned at tile `(23, 220)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Object 65226)**: Positioned at tile `(59, 216)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[06]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(28, 219)` to `(29, 220)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[07]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(72, 211)` to `(73, 212)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[08]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(70, 207)` to `(71, 208)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[09]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(29, 210)` to `(31, 212)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[10]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(29, 213)` to `(31, 215)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[11]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(31, 220)` to `(33, 222)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[12]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(21, 213)` to `(24, 214)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[13]` (Hitbox Zone)**: Bounding trigger area covering `6` tiles wide by `2` tiles high from `(21, 209)` to `(26, 210)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (21 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Open Dialogue Sub-Window (5); Fade Out to Black (255) |
| `ev[01]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Open Dialogue Sub-Window (5); Display Chapter Text (255) |
| `ev[02]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Open Dialogue Sub-Window (5); Display Emotion Bubble (255, 254) |
| `ev[03]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Open Dialogue Sub-Window (5); Dismiss Emotion Bubble (255) |
| `ev[04]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Open Dialogue Sub-Window (6); Open Dialogue Sub-Window (255) |
| `ev[05]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Open Dialogue Sub-Window (6); Close Dialogue Sub-Window (255) |
| `ev[06]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Open Dialogue Sub-Window (6); Clear Dialogue Sub-Window |
| `ev[07]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Open Dialogue Sub-Window (6); Fade In from Black (255) |
| `ev[08]` | `1 (Action / Talk)` | Target Inspected is obj[18] AND Condition Check #40 AND Always Passes (Unconditional) AND Player Y in Range [255..254] | Open Dialogue Sub-Window (6); Engine Action #40 |
| `ev[09]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Open Dialogue Sub-Window (6); Fade Out to Black (255) |
| `ev[10]` | `1 (Action / Talk)` | Target Inspected is obj[19] | Open Dialogue Sub-Window (6); Display Chapter Text (255) |
| `ev[11]` | `1 (Action / Talk)` | Target Inspected is obj[20] | Open Dialogue Sub-Window (6); Open Choice Selection Menu (255, 254) |
| `ev[12]` | `1 (Action / Talk)` | Target Inspected is obj[21] | Open Dialogue Sub-Window (6); Engine Action #134 |
| `ev[13]` | `128 (Loop)` | Player within Box [37..55, 2..216] AND Condition Check #226 | Warp Room -> Submap 0 at (5,1) |
| `ev[14]` | `2 (Map Init)` | Condition Check #24 AND Condition Check #106 AND Player Y within Range [255..254] | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[15]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #106 AND Player Y within Range [255..254] | Open Dialogue Message Window; Engine Action #9 |
| `ev[16]` | `1 (Action / Talk)` | Story Flag 68 (bit 2) CLEAR AND Condition Check #24 AND Condition Check #106 AND Player Y within Range [5..8] | Recruit Character into Active Party (84 [Bonaparte], 106); Dismiss Emotion Bubble (111); Award Potch Loot (+1,287 Potch); Pan Camera (7, 8, 8); Pan Camera (96, 31, 8); Warp Room -> Submap 3 at (26,2) facing 14; Warp to Castle HQ (58, 255, 254); Reset Camera Tracking (23); Warp to Castle HQ (27, 73, 20); Set Combat Battle BGM (20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 3 Map 28 Submap 3 at (29,73); Branch on Choice (41, 2); Engine Action #9; Screen Fade Transition (255, 9, 96); Warp Room -> Submap 8 at (240,240); Warp to Castle HQ (30, 2, 14); Warp to Castle HQ (58, 255, 254); Screen Fade Transition (24, 8, 3); Warp Room -> Submap 73 at (20,11); Warp Town -> Area 2 Map 90 Submap 43 at (0,7); Exit to World Map (0, 75, 215); Reset Camera Tracking (46); Warp Town -> Area 8 Map 71 Submap 215 at (3,8); Warp to Castle HQ (43, 0, 4); Warp to Castle HQ (0, 2, 47); Set Combat Battle BGM (30); Close Dialogue Window; Warp Room -> Submap 90 at (24,8) facing East (Right); Warp Map Transition (73, 20, 11, 2, 2); Engine Action #90; Open Shop Menu #7 (Type: 0); Exit to World Map (0, 46, 215); Reset Camera Tracking (46); Warp Town -> Area 8 Map 46 Submap 213 at (3,8); Open Dialogue Message Window; Open Shop Menu #4 (Type: 0); Warp to Castle HQ (0, 1, 47); Set Combat Battle BGM (30); Close Dialogue Window; Warp Room -> Submap 90 at (9,68) facing Up (North); Engine Action #58 |
| `ev[17]` | `1 (Action / Talk)` | Story Flag 68 (bit 2) SET AND Condition Check #24 AND Condition Check #106 AND Player Y within Range [37..1] AND Story Flag 13 (mask 53) SET AND Character #5 Level >= 8 | Recruit Character into Active Party (30 [Kinnison], 1); Open Dialogue Message Window; Clear Story Milestone Flag 31 (mask 8); Engine Action #240; Engine Action #240; Warp to Castle HQ (33, 2, 14); Warp to Castle HQ (58, 255, 254) |
| `ev[18]` | `1 (Action / Talk)` | Story Flag 68 (bit 2) SET AND Condition Check #24 AND Condition Check #106 AND Player Y within Range [37..0] AND Story Flag 13 (mask 53) SET AND Character #5 Level >= 8 | Recruit Character into Active Party (23 [Hanna], 3); Return Warp to Castle Base (84, 106); Warp Room -> Submap 73 at (60,73); Screen Fade Transition (24, 8, 3); Start Boss Battle #46 (BGM: 2); Engine Action #9; Make obj[230] Hidden (disp = 0); Warp to Castle HQ (9, 1, 0); Engine Action #9; Teleport obj[73] to (30,24); Engine Action #9; Warp to Castle HQ (36, 5, 9); Warp Room -> Submap 3 at (4,1) facing East (Right); Warp Town -> Area 0 Map 30 Submap 48 at (0,8); Warp to Castle HQ (0, 0, 2); Engine Action #9; Warp to Castle HQ (0, 3, 3); Reset Camera Tracking (3); Close Dialogue Sub-Window (8); Warp to Castle HQ (37, 24, 9); Warp to Castle HQ (38, 73, 20); Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 101, 4); Engine Action #6; Engine Action #5; Open Dialogue Message Window; Warp Town -> Area 0 Map 5 Submap 3 at (1,0); Engine Action #5; Warp to Castle HQ (3, 0, 5); Warp to Castle HQ (0, 0, 5); Warp to Castle HQ (30, 89, 0); Warp Town -> Area 8 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Engine Action #89; Open Dialogue Message Window; Warp Town -> Area 9 Map 5 Submap 0 at (6,2); Dismiss Emotion Bubble (89); Open Dialogue Message Window; Warp Town -> Area 10 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Dismiss Emotion Bubble (0); Warp Room -> Submap 5 at (0,0) facing South (Down); Engine Action #5; Show Dialogue Portrait (3, 0, 30); Set Combat Battle BGM (30); Warp to Castle HQ (8, 0, 73); Engine Action #6; Warp to Castle HQ (0, 1, 24); Reset Camera Tracking (3); Engine Action #39; Close Dialogue Window; Warp Town -> Area 2 Map 150 Submap 2 at (9,46); Engine Action #213; Warp to Castle HQ (9, 0, 1); Reset Camera Tracking (73); Dismiss Emotion Bubble (11); Warp Room -> Submap 150 at (58,255) facing 254 |
| `ev[19]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Clear Story Milestone Flag 31 (mask 9); Engine Action #240; Engine Action #240; Warp to Castle HQ (40, 2, 14); Warp to Castle HQ (255, 254, 204) |
| `ev[20]` | `1 (Action / Talk)` | Player within Box [45..47, 2..227] AND Condition Check #228 AND Story Flag 0 (mask 255) SET | Warp Map Transition (3, 0, 58, 130, 255) |

---


