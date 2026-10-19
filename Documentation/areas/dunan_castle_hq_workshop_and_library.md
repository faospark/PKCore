# Suikoden II Geographic Area Catalog: Castle HQ: Workshop & Library Archives

**Geographic Scope & Role**: Invention and lore center; Meg and Gadget's tech gear assembly bench, and Emilia's book archives housing the 12 collectible Old Books.

**Regional Category**: Region `VK` | **Master Maps Included**: `vk08`

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

## Location Map: `vk08`

- **Master Map Container**: `vk08.json`
- **Submap Layer Files**: vk08_13.json, vk08_16.json, vk08_19.json, vk08_20.json, vk08_22.json, vk08_25.json, vk08_28.json, vk08_30.json, vk08_33.json, vk08_35.json, vk08_37.json, vk08_39.json
- **Collision Grid Files**: vk08_map_00.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 3

### Submap Layer `vk08_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `25` Objects | **Script Count (`evkaz`)**: `55` Scripts

#### Complete Physical Entity Inventory (25 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 98** | `98` | `(32, 38)` | `0x0` | East (Right) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | Save Point | **Journeyman Save Orb** | `0` | `(33, 52)` | `0x0` | Frame 25 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Actor ID 41** | `41` | `(40, 42)` | `5x5` | East (Right) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[03]` | NPC / Actor | **Actor ID 120** | `120` | `(50, 62)` | `5x5` | East (Right) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[04]` | NPC / Actor | **Tai Ho** | `22` | `(65, 61)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[05]` | NPC / Actor | **Actor ID 92** | `92` | `(64, 58)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[06]` | NPC / Actor | **Templeton (Cartographer)** | `99` | `(52, 54)` | `0x0` | East (Right) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[07]` | Prop / Scenery | **Prop ID 33379** | `33379` | `(52, 54)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | NPC / Actor | **Actor ID 103** | `103` | `(63, 37)` | `4x4` | East (Right) | Dormant / Hidden (0) | Special (3) | 2 | 128 | 0 |
| `obj[09]` | NPC / Actor | **Seed** | `88` | `(63, 73)` | `4x4` | East (Right) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[10]` | NPC / Actor | **Ridley (General)** | `121` | `(50, 28)` | `0x0` | East (Right) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[11]` | NPC / Actor | **Tomo** | `57` | `(42, 38)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[12]` | NPC / Actor | **Actor ID 65105** | `65105` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[13]` | Trigger / Hitbox | **Hitbox Zone (5x3)** | `0` | `(76, 26)` | `4x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(30, 30)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[15]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(34, 30)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[16]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(38, 30)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[17]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(28, 52)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[18]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(32, 54)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[19]` | Trigger / Hitbox | **Hitbox Zone (7x3)** | `0` | `(24, 56)` | `6x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[20]` | NPC / Actor | **Actor ID 65085** | `65085` | `(37, 51)` | `0x0` | East (Right) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[21]` | NPC / Actor | **Actor ID 65048** | `65048` | `(55, 32)` | `7x7` | South (Down) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[22]` | NPC / Actor | **Actor ID 65178** | `65178` | `(54, 74)` | `7x7` | South (Down) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[23]` | NPC / Actor | **Actor ID 65205** | `65205` | `(39, 45)` | `7x7` | South (Down) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[24]` | NPC / Actor | **Actor ID 65163** | `65163` | `(58, 45)` | `7x7` | South (Down) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 98)**: Positioned at tile `(32, 38)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Journeyman Save Crystal)**: Floating save station orb at tile `(33, 52)`, priority `0`. Triggers `MSaveInit` save system dialog.
- **`obj[02]` (Object 41)**: Positioned at tile `(40, 42)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Object 120)**: Positioned at tile `(50, 62)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Tai Ho)**: Positioned at tile `(65, 61)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Object 92)**: Positioned at tile `(64, 58)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[06]` (Templeton (Cartographer))**: Positioned at tile `(52, 54)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[07]` (Prop: Object 33379)**: Environmental world dressing prop placed at tile `(52, 54)`. Solid collision is set to `0`.
- **`obj[08]` (Object 103)**: Positioned at tile `(63, 37)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[09]` (Seed)**: Positioned at tile `(63, 73)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[10]` (Ridley (General))**: Positioned at tile `(50, 28)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[11]` (Tomo)**: Positioned at tile `(42, 38)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[12]` (Object 65105)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[13]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `3` tiles high from `(76, 26)` to `(80, 28)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[14]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(30, 30)` to `(32, 32)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[15]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(34, 30)` to `(36, 32)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[16]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(38, 30)` to `(40, 32)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[17]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(28, 52)` to `(30, 54)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[18]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(32, 54)` to `(34, 56)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[19]` (Hitbox Zone)**: Bounding trigger area covering `7` tiles wide by `3` tiles high from `(24, 56)` to `(30, 58)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[20]` (Object 65085)**: Positioned at tile `(37, 51)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[21]` (Object 65048)**: Positioned at tile `(55, 32)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[22]` (Object 65178)**: Positioned at tile `(54, 74)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[23]` (Object 65205)**: Positioned at tile `(39, 45)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[24]` (Object 65163)**: Positioned at tile `(58, 45)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.


#### Complete Bytecode Script Catalog (55 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Story Flag 46 (bit 16) CLEAR AND Story Flag 152 (bit 8) CLEAR AND Condition Check #23 AND Condition Check #98 AND Player X within Range [255..254] | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[01]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Story Flag 46 (bit 16) CLEAR AND Story Flag 152 (bit 16) SET AND Condition Check #23 AND Condition Check #98 AND Player X within Range [255..254] | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[02]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Story Flag 46 (bit 16) CLEAR AND Story Flag 153 (bit 16) CLEAR AND Condition Check #23 AND Condition Check #98 AND Player X within Range [255..254] | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[03]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #98 AND Player within Box [5..8, 255..254] | Engine Action #99; Display Choice Selection (8, 99); Change Portrait Expression (32); Dismiss Emotion Bubble (3); Warp Room -> Submap 24 at (8,1) facing South (Down); Set Combat Battle BGM (20); Engine Action #127; Open Dialogue Message Window; Change Portrait Expression (32); Recruit Invisible / Hitbox Trigger into Battle Slot 1; Mark NPC Talk Interaction Complete (Flag #19); Reset Camera Tracking (255) |
| `ev[04]` | `128 (Loop)` | Condition Check #23 AND Condition Check #98 AND Player within Box [29..17, 32..255] | Warp Room -> Submap 0 at (13,1); Mark NPC Talk Interaction Complete (Flag #17); Warp Map Transition (255, 254, 204, 204, 204) |
| `ev[05]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #42 AND Player within Box [33..1, 2..34] AND Party Formation Check AND Temp Event Flag #255 CLEAR | Make obj[0] Hidden (disp = 0); Engine Action #9; Teleport obj[255] to (254,204) |
| `ev[06]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Dismiss Emotion Bubble (3); Warp Room -> Submap 23 at (1,1) facing 255 |
| `ev[07]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #41 AND Player within Box [33..1, 2..34] AND Party Formation Check AND Player X within Range [255..254] | Make obj[0] Hidden (disp = 0); Screen Fade Transition (47, 255, 254) |
| `ev[08]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Dismiss Emotion Bubble (3); Warp Room -> Submap 23 at (1,2) facing 255 |
| `ev[09]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #120 AND Player within Box [33..0, 1..255] | Make obj[0] Hidden (disp = 0); Close Dialogue Window; Teleport obj[255] to (254,204) |
| `ev[10]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Dismiss Emotion Bubble (3); Warp Room -> Submap 23 at (1,3) facing 255 |
| `ev[11]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Story Flag 46 (bit 32) CLEAR AND Condition Check #23 AND Inventory Lacks Item #1 AND Condition Check #33 AND Always Passes (Unconditional) AND Player X within Range [255..254] | Make obj[0] Hidden (disp = 0); Display Dialogue Box [Bank: 47, MsgID: 255] |
| `ev[12]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Dismiss Emotion Bubble (3); Warp Room -> Submap 23 at (1,4) facing 255 |
| `ev[13]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #92 AND Player within Box [33..0, 1..255] | Make obj[0] Hidden (disp = 0); Place Scenery Structure (47) |
| `ev[14]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Dismiss Emotion Bubble (3); Warp Room -> Submap 23 at (1,5) facing 255 |
| `ev[15]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #99 AND Player within Box [33..0, 1..37] AND Player within Box [11..0, 0..0] | Open Dialogue Message Window; Animate Door Open |
| `ev[16]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #99 AND Player within Box [33..0, 1..37] AND Always Passes (Unconditional) AND Player X in Range [0..10] AND Always Passes (Unconditional) | Open Dialogue Message Window; Animate Door Open |
| `ev[17]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #99 AND Player within Box [33..0, 1..5] AND Active Party Has Character #255 | Engine Action #5; Animate Door Open; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp Town -> Area 0 Map 5 Submap 5 at (30,101); Engine Action #9; Engine Action #9; Make obj[1] Hidden (disp = 0); Animate Door Open; Engine Action #89; Animate Door Open; Warp Town -> Area 0 Map 0 Submap 15 at (47,30); Warp to Castle HQ (1, 0, 23); Warp Room -> Submap 105 at (0,0) facing 48; Launch Tactical War Battle (4); Engine Action #89; Show Dialogue Portrait (2, 2, 89); Show Dialogue Portrait (5, 89, 15); Engine Action #5; Engine Action #89; Show Dialogue Portrait (2, 3, 73); Branch on Choice (100, 19); Reset Camera Tracking (100); Display Choice Selection (16, 108); Open Dialogue Sub-Window (255) |
| `ev[18]` | `128 (Loop)` | Inventory Holds Item #4 | Set Combat Battle BGM (60); Jump to Bytecode Offset (0, 182); Set Combat Battle BGM (70); Jump to Bytecode Offset (0, 187); Jump to Bytecode Offset (1, 1); Toggle Random Encounters (4) |
| `ev[19]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #103 AND Player within Box [33..0, 1..255] | Make obj[0] Hidden (disp = 0); Dismiss Dialogue Portrait; Teleport obj[255] to (254,204) |
| `ev[20]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #103 AND Player within Box [33..0, 1..5] AND Star of Destiny #255 Recruited | Engine Action #99; Display Choice Selection (8, 99); Dismiss Dialogue Portrait; Animate Doorway State (30, 3); Warp Room -> Submap 23 at (1,7) facing 73; Trigger Character Emotion Effect (127, 0); Dismiss Dialogue Portrait; Animate Doorway State (128, 0); Open Dialogue Message Window; Mark NPC Talk Interaction Complete (Flag #19); Reset Camera Tracking (255) |
| `ev[21]` | `128 (Loop)` | Condition Check #23 AND Condition Check #103 AND Player within Box [33..0, 1..29] AND Star of Destiny #64 Recruited | Warp Room -> Submap 0 at (13,30); Mark NPC Talk Interaction Complete (Flag #16); Animate Doorway State (255, 254) |
| `ev[22]` | `2 (Map Init)` | Story Flag 46 (bit 64) CLEAR AND Condition Check #23 AND Condition Check #88 AND Player within Box [33..0, 1..255] | Make obj[0] Hidden (disp = 0); Change Portrait Expression (47) |
| `ev[23]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Dismiss Emotion Bubble (3); Warp Room -> Submap 23 at (1,8) facing 255 |
| `ev[24]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #23 AND Condition Check #121 AND Player within Box [33..0, 1..255] | Make obj[0] Hidden (disp = 0); Display Speaker Name Box (47) |
| `ev[25]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Dismiss Emotion Bubble (3); Warp Room -> Submap 23 at (1,9) facing 255 |
| `ev[26]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #57 AND Player within Box [33..0, 1..34] AND Story Flag 1 (bit 255) CLEAR | Make obj[0] Hidden (disp = 0); Display Choice Selection (47, 255) |
| `ev[27]` | `1 (Action / Talk)` | Target Inspected is obj[19] | Dismiss Emotion Bubble (3); Warp Room -> Submap 23 at (1,10) facing 255 |
| `ev[28]` | `128 (Loop)` | Player within Box [48..68, 2..57] AND Condition Check #83 AND Story Flag 144 (bit 32) CLEAR AND Condition Check #30 AND Character #16 Level >= 255 | Warp Room -> Submap 0 at (10,0) |
| `ev[29]` | `128 (Loop)` | Player within Box [48..68, 2..57] AND Condition Check #83 AND Story Flag 144 (bit 32) SET AND Condition Check #30 AND Character #16 Level >= 255 | Warp Room -> Submap 0 at (10,33) |
| `ev[30]` | `128 (Loop)` | Player within Box [48..79, 2..24] AND Condition Check #48 AND Story Flag 144 (bit 16) SET AND Condition Check #30 AND Character #8 Level >= 255 | Warp Room -> Submap 0 at (10,28) |
| `ev[31]` | `128 (Loop)` | Player within Box [48..79, 2..24] AND Condition Check #48 AND Story Flag 144 (bit 16) CLEAR AND Condition Check #30 AND Character #8 Level >= 255 | Warp Room -> Submap 0 at (10,31) |
| `ev[32]` | `2 (Map Init)` | Story Flag 144 (bit 4) SET | Dismiss Emotion Bubble (1); Warp Town -> Area 16 Map 11 Submap 255 at (254,204) |
| `ev[33]` | `2 (Map Init)` | Always Passes (Unconditional) AND Story Flag 144 (bit 4) SET | Make obj[2] Hidden (disp = 0); Branch on Choice (58, 84); Warp to Castle HQ (20, 1, 0); Branch on Choice (47, 255) |
| `ev[34]` | `1 (Action / Talk)` | Story Flag 144 (bit 4) SET AND Player within Box [49..67, 2..81] AND Condition Check #82 | Warp to Castle HQ (0, 0, 43); Branch on Choice (6, 48); Branch on Choice (0, 2); Open Dialogue Message Window; Open Dialogue Message Window; Warp to Castle HQ (8, 3, 20); Warp Room -> Submap 20 at (15,4) facing 49; Warp Town -> Area 5 Map 0 Submap 1 at (3,30); Exit to World Map (20, 58, 84); Engine Action #9; Warp to Castle HQ (20, 1, 255); Walk obj[255] to (254,204) |
| `ev[35]` | `1 (Action / Talk)` | Player within Box [52..64, 2..86] AND Condition Check #87 AND Story Flag 0 (mask 255) SET | Engine Action #111; Award Potch Loot (+1,280 Potch); Warp Room -> Submap 3 at (4,255) facing South (Down); Warp Room -> Submap 3 at (2,30) facing 119; Warp Town -> Area 32 Map 3 Submap 1 at (30,119); Warp to Castle HQ (255, 4, 32); Warp to Castle HQ (0, 30, 119) |
| `ev[36]` | `1 (Action / Talk)` | Player within Box [50..66, 2..18] AND Inventory Holds Item #9 AND Player X within Range [255..254] | Warp Map Transition (3, 0, 48, 97, 255) |
| `ev[37]` | `1 (Action / Talk)` | Player within Box [74..78, 2..32] AND Condition Check #33 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 110]; Start Boss Battle #255 (BGM: 254) |
| `ev[38]` | `2 (Map Init)` | Story Flag 144 (bit 4) CLEAR AND Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [1..255] | Open Dialogue Message Window; Display Chapter Text (255) |
| `ev[39]` | `2 (Map Init)` | Story Flag 144 (bit 4) CLEAR AND Condition Check #33 AND Player within Box [1..3, 112..64] | Open Dialogue Message Window; Display Emotion Bubble (255, 254) |
| `ev[40]` | `2 (Map Init)` | Story Flag 144 (bit 4) CLEAR AND Condition Check #33 AND Player within Box [2..3, 112..64] | Open Dialogue Message Window; Dismiss Emotion Bubble (255) |
| `ev[41]` | `2 (Map Init)` | Story Flag 144 (bit 4) CLEAR AND Condition Check #33 AND Player within Box [3..3, 112..64] | Open Dialogue Message Window; Warp Room -> Submap 255 at (254,204) |
| `ev[42]` | `2 (Map Init)` | Story Flag 144 (bit 4) CLEAR AND Condition Check #33 AND Player within Box [4..3, 112..64] | Open Dialogue Message Window; Warp Map Transition (255, 254, 204, 204, 204) |
| `ev[43]` | `1 (Action / Talk)` | Target Inspected is obj[28] | Dismiss Emotion Bubble (4); Warp Room -> Submap 23 at (6,0) facing East (Right); Display Chapter Text (3) |
| `ev[44]` | `1 (Action / Talk)` | Target Inspected is obj[29] | Dismiss Emotion Bubble (4); Warp Room -> Submap 23 at (6,1) facing 255 |
| `ev[45]` | `1 (Action / Talk)` | Target Inspected is obj[30] | Dismiss Emotion Bubble (4); Warp Room -> Submap 23 at (6,2) facing 255 |
| `ev[46]` | `1 (Action / Talk)` | Target Inspected is obj[31] | Dismiss Emotion Bubble (4); Warp Room -> Submap 23 at (6,3) facing 255 |
| `ev[47]` | `1 (Action / Talk)` | Target Inspected is obj[32] | Dismiss Emotion Bubble (4); Warp Room -> Submap 23 at (6,4) facing 255 |
| `ev[48]` | `1 (Action / Talk)` | Target Inspected is obj[21] | Close Dialogue Sub-Window (21); Exit to World Map (0, 255, 254) |
| `ev[49]` | `1 (Action / Talk)` | Target Inspected is obj[22] | Close Dialogue Sub-Window (22); Exit to World Map (1, 255, 254) |
| `ev[50]` | `1 (Action / Talk)` | Target Inspected is obj[23] | Close Dialogue Sub-Window (23); Exit to World Map (2, 255, 254) |
| `ev[51]` | `1 (Action / Talk)` | Target Inspected is obj[24] | Close Dialogue Sub-Window (24); Exit to World Map (3, 255, 254) |
| `ev[52]` | `1 (Action / Talk)` | Target Inspected is obj[25] | Close Dialogue Sub-Window (25); Exit to World Map (4, 255, 254) |
| `ev[53]` | `1 (Action / Talk)` | Target Inspected is obj[26] | Close Dialogue Sub-Window (26); Exit to World Map (5, 255, 254) |
| `ev[54]` | `1 (Action / Talk)` | Target Inspected is obj[27] | Close Dialogue Sub-Window (27); Exit to World Map (6, 255, 254) |

---

### Submap Layer `vk08_01` (Index 1)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `47` Objects | **Script Count (`evkaz`)**: `91` Scripts

#### Complete Physical Entity Inventory (47 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Klaus** | `91` | `(127, 34)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | Trigger / Hitbox | **Hitbox Zone (5x4)** | `0` | `(125, 32)` | `4x3` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Actor ID 64826** | `64826` | `(127, 34)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | NPC / Actor | **Gustav** | `58` | `(137, 57)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[04]` | Prop / Scenery | **Prop ID 53306** | `53306` | `(137, 58)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | Trigger / Hitbox | **Hitbox Zone (3x4)** | `0` | `(136, 55)` | `2x3` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | NPC / Actor | **Viki** | `60` | `(131, 57)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[07]` | Prop / Scenery | **Prop ID 53308** | `53308` | `(131, 58)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Trigger / Hitbox | **Hitbox Zone (3x4)** | `0` | `(130, 55)` | `2x3` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | NPC / Actor | **Marlowe** | `59` | `(129, 53)` | `2x2` | East (Right) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[10]` | NPC / Actor | **Shin** | `12` | `(133, 37)` | `0x0` | Up (North) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[11]` | Prop / Scenery | **Prop ID 53287** | `53287` | `(130, 37)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | Trigger / Hitbox | **Hitbox Zone (3x4)** | `0` | `(129, 34)` | `2x3` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | NPC / Actor | **Anita** | `39` | `(131, 37)` | `0x0` | East (Right) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[14]` | Prop / Scenery | **Prop ID 53287** | `53287` | `(133, 37)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[15]` | Trigger / Hitbox | **Hitbox Zone (3x4)** | `0` | `(132, 34)` | `2x3` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[16]` | NPC / Actor | **Youth Brigade Recruit** | `3` | `(119, 47)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[17]` | Prop / Scenery | **Prop ID 53251** | `53251` | `(119, 48)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[18]` | Trigger / Hitbox | **Hitbox Zone (3x4)** | `0` | `(118, 45)` | `2x3` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[19]` | NPC / Actor | **Jowy Atreides** | `2` | `(125, 47)` | `0x0` | East (Right) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[20]` | Prop / Scenery | **Prop ID 53250** | `53250` | `(125, 48)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[21]` | Trigger / Hitbox | **Hitbox Zone (3x4)** | `0` | `(124, 45)` | `2x3` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[22]` | NPC / Actor | **Emilia** | `55` | `(117, 42)` | `5x2` | East (Right) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[23]` | NPC / Actor | **Rina** | `20` | `(122, 55)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[24]` | Prop / Scenery | **Prop ID 53268** | `53268` | `(122, 55)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 180 |
| `obj[25]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(121, 53)` | `2x2` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[26]` | NPC / Actor | **Simone Verdicci** | `37` | `(131, 47)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[27]` | Prop / Scenery | **Prop ID 53285** | `53285` | `(131, 48)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[28]` | Trigger / Hitbox | **Hitbox Zone (3x4)** | `0` | `(130, 45)` | `2x3` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[29]` | NPC / Actor | **Leona** | `16` | `(134, 45)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[30]` | Prop / Scenery | **Prop ID 53264** | `53264` | `(134, 45)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 180 |
| `obj[31]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(133, 43)` | `2x2` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[32]` | NPC / Actor | **Luc** | `10` | `(122, 45)` | `0x0` | Up (North) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[33]` | Prop / Scenery | **Prop ID 53268** | `53268` | `(122, 45)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 180 |
| `obj[34]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(121, 43)` | `2x2` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[35]` | NPC / Actor | **Actor ID 65105** | `65105` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[36]` | Prop / Scenery | **Prop ID 37650** | `37650` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 180 |
| `obj[37]` | Prop / Scenery | **Prop ID 37650** | `37650` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 180 |
| `obj[38]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(106, 34)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[39]` | World Device | **Mechanism (ano 35)** | `0` | `(124, 76)` | `0x0` | Frame 35 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[40]` | NPC / Actor | **Actor ID 64826** | `64826` | `(109, 39)` | `7x7` | South (Down) | Dormant / Hidden (0) | Special (3) | 4 | 128 | 0 |
| `obj[41]` | NPC / Actor | **Actor ID 64826** | `64826` | `(126, 43)` | `7x7` | South (Down) | Dormant / Hidden (0) | Special (3) | 4 | 128 | 0 |
| `obj[42]` | NPC / Actor | **Actor ID 64826** | `64826` | `(122, 37)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[43]` | NPC / Actor | **Actor ID 65085** | `65085` | `(109, 59)` | `7x7` | South (Down) | Dormant / Hidden (0) | Special (3) | 2 | 128 | 0 |
| `obj[44]` | NPC / Actor | **Actor ID 64545** | `64545` | `(122, 55)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[45]` | NPC / Actor | **Actor ID 64551** | `64551` | `(137, 47)` | `0x0` | Up (North) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[46]` | NPC / Actor | **Wooden Water Bucket** | `64548` | `(131, 47)` | `0x0` | East (Right) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Klaus)**: Positioned at tile `(127, 34)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `4` tiles high from `(125, 32)` to `(129, 35)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[02]` (Object 64826)**: Positioned at tile `(127, 34)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Gustav)**: Positioned at tile `(137, 57)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Prop: Object 53306)**: Environmental world dressing prop placed at tile `(137, 58)`. Solid collision is set to `0`.
- **`obj[05]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `4` tiles high from `(136, 55)` to `(138, 58)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[06]` (Viki)**: Positioned at tile `(131, 57)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[07]` (Prop: Object 53308)**: Environmental world dressing prop placed at tile `(131, 58)`. Solid collision is set to `0`.
- **`obj[08]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `4` tiles high from `(130, 55)` to `(132, 58)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[09]` (Marlowe)**: Positioned at tile `(129, 53)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[10]` (Shin)**: Positioned at tile `(133, 37)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[11]` (Prop: Object 53287)**: Environmental world dressing prop placed at tile `(130, 37)`. Solid collision is set to `0`.
- **`obj[12]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `4` tiles high from `(129, 34)` to `(131, 37)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[13]` (Anita)**: Positioned at tile `(131, 37)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[14]` (Prop: Object 53287)**: Environmental world dressing prop placed at tile `(133, 37)`. Solid collision is set to `0`.
- **`obj[15]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `4` tiles high from `(132, 34)` to `(134, 37)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[16]` (Youth Brigade Recruit)**: Positioned at tile `(119, 47)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[17]` (Prop: Object 53251)**: Environmental world dressing prop placed at tile `(119, 48)`. Solid collision is set to `0`.
- **`obj[18]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `4` tiles high from `(118, 45)` to `(120, 48)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[19]` (Jowy Atreides)**: Positioned at tile `(125, 47)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[20]` (Prop: Object 53250)**: Environmental world dressing prop placed at tile `(125, 48)`. Solid collision is set to `0`.
- **`obj[21]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `4` tiles high from `(124, 45)` to `(126, 48)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[22]` (Emilia)**: Positioned at tile `(117, 42)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[23]` (Rina)**: Positioned at tile `(122, 55)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[24]` (Prop: Object 53268)**: Environmental world dressing prop placed at tile `(122, 55)`. Solid collision is set to `32`.
- **`obj[25]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(121, 53)` to `(123, 55)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[26]` (Simone Verdicci)**: Positioned at tile `(131, 47)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[27]` (Prop: Object 53285)**: Environmental world dressing prop placed at tile `(131, 48)`. Solid collision is set to `0`.
- **`obj[28]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `4` tiles high from `(130, 45)` to `(132, 48)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[29]` (Leona)**: Positioned at tile `(134, 45)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[30]` (Prop: Object 53264)**: Environmental world dressing prop placed at tile `(134, 45)`. Solid collision is set to `32`.
- **`obj[31]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(133, 43)` to `(135, 45)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[32]` (Luc)**: Positioned at tile `(122, 45)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[33]` (Prop: Object 53268)**: Environmental world dressing prop placed at tile `(122, 45)`. Solid collision is set to `32`.
- **`obj[34]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(121, 43)` to `(123, 45)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[35]` (Object 65105)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[36]` (Prop: Object 37650)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[37]` (Prop: Object 37650)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[38]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(106, 34)` to `(108, 36)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[39]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(124, 76)` with state parameter `35`.
- **`obj[40]` (Object 64826)**: Positioned at tile `(109, 39)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[41]` (Object 64826)**: Positioned at tile `(126, 43)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[42]` (Object 64826)**: Positioned at tile `(122, 37)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[43]` (Object 65085)**: Positioned at tile `(109, 59)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[44]` (Object 64545)**: Positioned at tile `(122, 55)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[45]` (Object 64551)**: Positioned at tile `(137, 47)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[46]` (Wooden Water Bucket)**: Positioned at tile `(131, 47)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.


#### Complete Bytecode Script Catalog (91 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET | Open Dialogue Message Window; Engine Action #9 |
| `ev[01]` | `2 (Map Init)` | Story Flag 134 (bit 1) SET | Open Dialogue Message Window; Screen Fade Transition (255, 254, 204) |
| `ev[02]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Story Flag 45 (bit 8) CLEAR AND Condition Check #23 AND Condition Check #91 AND Player X within Range [255..254] | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[03]` | `2 (Map Init)` | Story Flag 45 (bit 8) SET | Open Dialogue Message Window; Screen Fade Transition (255, 254, 204) |
| `ev[04]` | `2 (Map Init)` | Condition Check #24 AND Condition Check #91 AND Player X within Range [255..254] | Open Dialogue Message Window; Screen Fade Transition (255, 254, 204) |
| `ev[05]` | `2 (Map Init)` | Story Flag 172 (bit 64) SET AND Story Flag 114 (bit 8) CLEAR | Make obj[1] Hidden (disp = 0); Reset Camera Tracking (0); Screen Fade Transition (47, 255, 254) |
| `ev[06]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #58 AND Player X within Range [255..254] | Make obj[0] Hidden (disp = 0); Display Dialogue Box [Bank: 89, MsgID: 12]; Warp Town -> Area 0 Map 0 Submap 13 at (47,255) |
| `ev[07]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #60 AND Player X within Range [255..254] | Make obj[0] Hidden (disp = 0); Show Dialogue Portrait (89, 15, 2); Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Dialogue Portrait; Teleport obj[255] to (254,204) |
| `ev[08]` | `2 (Map Init)` | Story Flag 48 (bit 1) CLEAR AND Condition Check #23 AND Player Y in Range [1..33] AND Player Y within Range [2..255] | Make obj[0] Hidden (disp = 0); Display Choice Selection (89, 19); Warp Town -> Area 7 Map 0 Submap 20 at (47,255) |
| `ev[09]` | `2 (Map Init)` | Story Flag 48 (bit 1) CLEAR AND Condition Check #23 AND Player Y in Range [1..33] AND Player within Box [3..35, 19..4] | Make obj[0] Hidden (disp = 0); Display Choice Selection (89, 19); Warp Town -> Area 7 Map 0 Submap 20 at (47,255) |
| `ev[10]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #23 AND Condition Check #39 AND Player within Box [33..2, 2..255] | Make obj[0] Hidden (disp = 0); Set Story Flag (89, 22); Warp Town -> Area 0 Map 0 Submap 23 at (47,255) |
| `ev[11]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #23 AND Condition Check #39 AND Player within Box [33..1, 3..35] AND Character #32 Level >= 255 | Make obj[0] Hidden (disp = 0); Set Story Flag (89, 22); Warp Town -> Area 0 Map 0 Submap 23 at (47,255) |
| `ev[12]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #59 AND Player within Box [33..0, 1..255] | Open Dialogue Message Window; Change Portrait Expression (255) |
| `ev[13]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #59 AND Player within Box [35..3, 32..255] | Open Dialogue Message Window; Change Portrait Expression (255) |
| `ev[14]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Story Flag 46 (bit 1) CLEAR AND Condition Check #23 AND Story Flag 1 (bit 34) SET AND Player X within Range [2..255] | Make obj[0] Hidden (disp = 0); Clear Dialogue Sub-Window; Engine Action #89; Clear Dialogue Sub-Window; Warp Town -> Area 0 Map 0 Submap 26 at (47,255) |
| `ev[15]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Story Flag 45 (bit 1) CLEAR AND Condition Check #23 AND Player Y within Range [1..34] AND Always Passes (Unconditional) AND Player Y within Range [255..254] | Make obj[0] Hidden (disp = 0); Display Chapter Text (89); Display Chapter Text (2); Open Dialogue Message Window; Open Dialogue Message Window; Display Emotion Bubble (47, 255) |
| `ev[16]` | `2 (Map Init)` | Story Flag 144 (bit 4) CLEAR AND Condition Check #23 AND Condition Check #55 AND Player within Box [34..5, 2..255] | Open Dialogue Message Window; Dismiss Emotion Bubble (255) |
| `ev[17]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Story Flag 45 (bit 64) CLEAR AND Condition Check #23 AND Castle HQ Tier >= Level 1 AND Condition Check #34 AND Temp Event Flag #1 SET | Make obj[0] Hidden (disp = 0); Warp Map Transition (89, 32, 2, 0, 0); Return to Previous Memory Map (47) |
| `ev[18]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #37 AND Player within Box [34..18, 2..255] | Make obj[0] Hidden (disp = 0); Start Boss Battle #89 (BGM: 35); Warp Town -> Area 0 Map 0 Submap 36 at (255,254) |
| `ev[19]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #23 AND Star of Destiny #1 Recruited AND Condition Check #34 AND Inventory Holds Item #2 | Make obj[0] Hidden (disp = 0); Open Save Crystal Menu (MSaveInit); Engine Action #89; Open Save Crystal Menu (MSaveInit); Warp Town -> Area 3 Map 0 Submap 39 at (47,255) |
| `ev[20]` | `2 (Map Init)` | Condition Check #23 AND Story Flag 1 (mask 34) CLEAR AND Star of Destiny #32 Not Yet Recruited | Make obj[0] Hidden (disp = 0); Award Potch Loot (+22,825 Potch); Warp Town -> Area 7 Map 0 Submap 42 at (47,255) |
| `ev[21]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Story Flag 144 (bit 4) CLEAR AND Condition Check #23 AND Condition Check #91 AND Player within Box [33..1, 1..255] | Open Dialogue Message Window; Turn obj[255] facing 254 |
| `ev[22]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Story Flag 144 (bit 4) CLEAR AND Condition Check #33 AND Player X within Range [2..255] | Open Dialogue Message Window; Set Entity Movement Speed (255, 254) |
| `ev[23]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Story Flag 144 (bit 4) CLEAR AND Condition Check #33 AND Player X within Range [3..255] | Open Dialogue Message Window; Walk obj[255] to (254,204) |
| `ev[24]` | `2 (Map Init)` | Story Flag 144 (bit 4) CLEAR AND Condition Check #33 AND Player within Box [2..3, 112..64] | Open Dialogue Message Window; Engine Action #51 |
| `ev[25]` | `2 (Map Init)` | Story Flag 144 (bit 4) CLEAR AND Story Flag 45 (bit 64) SET AND Condition Check #33 AND Player within Box [1..3, 112..64] | Open Dialogue Message Window; Engine Action #52 |
| `ev[26]` | `2 (Map Init)` | Story Flag 144 (bit 4) CLEAR AND Condition Check #33 AND Player within Box [3..3, 112..64] | Open Dialogue Message Window; Engine Action #53 |
| `ev[27]` | `2 (Map Init)` | Condition Check #35 AND Party Member Count == 2 AND Story Flag 144 (bit 4) CLEAR AND Condition Check #33 AND Player within Box [3..3, 112..64] | Open Dialogue Message Window; Engine Action #54 |
| `ev[28]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #94 AND Player Y within Range [255..254] | Make obj[104] Hidden (disp = 0); Open Dialogue Message Window; Teleport obj[2] to (0,47); Teleport obj[255] to (254,204) |
| `ev[29]` | `2 (Map Init)` | Story Flag 111 (bit 128) SET AND Story Flag 112 (bit 1) CLEAR | Make obj[0] Hidden (disp = 0); Clear Dialogue Sub-Window; Engine Action #89; Clear Dialogue Sub-Window; Warp Town -> Area 0 Map 0 Submap 26 at (1,12); Warp Room -> Submap 1 at (15,1) facing 16; Warp Room -> Submap 1 at (20,1) facing 22; Warp Room -> Submap 1 at (17,1) facing 28; Warp Room -> Submap 1 at (30,1) facing 32; Warp Room -> Submap 1 at (35,1) facing 36; Warp Room -> Submap 1 at (39,1) facing 41; Warp Room -> Submap 47 at (255,254) facing 204 |
| `ev[30]` | `1 (Action / Talk)` | Story Flag 111 (bit 128) SET AND Story Flag 112 (bit 1) CLEAR AND Story Flag 112 (bit 4) CLEAR AND Target Inspected is obj[26] | Set Render Priority (pri) (0, 120); Walk obj[9] to (89,25); Warp Town -> Area 3 Map 3 Submap 0 at (1,33); Warp Room -> Submap 0 at (1,5) facing West (Left); Exit to World Map (5, 2, 2); Warp Room -> Submap 30 at (24,24) facing South (Down); Open Shop Menu #1 (Type: 24); Open Dialogue Message Window; Engine Action #44; Close Dialogue Sub-Window (24); Open Dialogue Message Window; Make obj[73] Visible (disp = 1); Branch on Choice (40, 0); Open Dialogue Message Window; Warp Town -> Area 0 Map 46 Submap 0 at (47,41); Warp Town -> Area 0 Map 1 Submap 255 at (0,24); Close Dialogue Sub-Window (0); Engine Action #51; Set Combat Battle BGM (60); Engine Action #89; Clear Dialogue Sub-Window; Warp Town -> Area 1 Map 73 Submap 60 at (24,24); Warp to Castle HQ (0, 36, 1); Wait for Audio / Window Sync (1); Jump to Bytecode Offset (9, 9); Close Dialogue Window; Warp Town -> Area 23 Map 120 Submap 105 at (0,0); Engine Action #110; Jump to Bytecode Offset (1, 0); Engine Action #102; Warp Room -> Submap 24 at (3,1) facing 39; Return Warp to Castle Base (69, 2); Place Scenery Structure (5); Open Dialogue Message Window; Animate Door Open; Engine Action #250; Open Dialogue Message Window; Open Dialogue Message Window; Warp Room -> Submap 1 at (3,24) facing West (Left); Open Dialogue Message Window; Turn obj[24] facing 24; Open Dialogue Message Window; Set Entity Movement Speed (89, 25); Warp Town -> Area 0 Map 39 Submap 34 at (9,112); Exit to World Map (255, 254, 204) |
| `ev[31]` | `128 (Loop)` | Story Flag 111 (bit 128) SET AND Story Flag 112 (bit 1) CLEAR AND Story Flag 112 (bit 4) CLEAR AND Inventory Holds Item #1 | Engine Action #44; Set Entity Movement Speed (2, 4); Open Dialogue Message Window; Dismiss Character Dialogue Portrait; Set Entity Movement Speed (9, 3); Open Dialogue Message Window; Warp Town -> Area 255 Map 254 Submap 43 at (1,4); Engine Action #5; Warp Room -> Submap 1 at (30,4) facing West (Left); Engine Action #122; Engine Action #44; Engine Action #9; Warp to Castle HQ (1, 0, 255); Walk obj[37] to (1,255) |
| `ev[32]` | `1 (Action / Talk)` | Story Flag 112 (bit 4) SET AND Story Flag 112 (bit 1) CLEAR AND Target Inspected is obj[26] | Set Render Priority (pri) (0, 120); Walk obj[9] to (89,25); Warp Town -> Area 3 Map 3 Submap 0 at (1,33); Warp Room -> Submap 0 at (1,5) facing West (Left); Exit to World Map (5, 2, 2); Warp Room -> Submap 30 at (24,24) facing South (Down); Walk obj[73] to (20,40); Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 0 Map 46 Submap 0 at (47,41); Warp Town -> Area 0 Map 1 Submap 255 at (0,24); Close Dialogue Sub-Window (0); Engine Action #51; Set Combat Battle BGM (60); Engine Action #89; Clear Dialogue Sub-Window; Warp Town -> Area 1 Map 73 Submap 60 at (24,24); Warp to Castle HQ (0, 36, 1); Wait for Audio / Window Sync (1); Jump to Bytecode Offset (9, 9); Close Dialogue Window; Warp Town -> Area 23 Map 120 Submap 105 at (0,0); Engine Action #110; Jump to Bytecode Offset (1, 0); Engine Action #102; Warp Room -> Submap 24 at (3,1) facing 39; Return Warp to Castle Base (69, 2); Place Scenery Structure (5); Open Dialogue Message Window; Animate Door Open; Engine Action #250; Open Dialogue Message Window; Open Dialogue Message Window; Warp Room -> Submap 1 at (3,24) facing West (Left); Open Dialogue Message Window; Turn obj[24] facing 24; Open Dialogue Message Window; Set Entity Movement Speed (89, 25); Warp Town -> Area 0 Map 39 Submap 34 at (255,254) |
| `ev[33]` | `128 (Loop)` | Story Flag 112 (bit 4) SET AND Story Flag 112 (bit 1) CLEAR AND Inventory Holds Item #1 | Engine Action #44; Set Entity Movement Speed (2, 4); Open Dialogue Message Window; Dismiss Character Dialogue Portrait; Set Entity Movement Speed (9, 3); Open Dialogue Message Window; Warp Town -> Area 255 Map 254 Submap 43 at (1,4); Engine Action #5; Warp Room -> Submap 1 at (30,4) facing West (Left); Engine Action #122; Engine Action #44; Engine Action #9; Warp to Castle HQ (1, 0, 255); Walk obj[37] to (1,255) |
| `ev[34]` | `2 (Map Init)` | Story Flag 112 (bit 8) SET AND Story Flag 112 (bit 1) CLEAR | Make obj[63] Hidden (disp = 0); Warp Room -> Submap 2 at (1,122) facing 47; Warp to Castle HQ (1, 1, 0); Warp Room -> Submap 0 at (125,48) facing 106; Open Dialogue Message Window; Make obj[89] Visible (disp = 1); Make obj[2] Visible (disp = 1); Open Dialogue Message Window; Open Dialogue Message Window; Make obj[1] Visible (disp = 1); Open Dialogue Message Window; Warp Town -> Area 44 Map 122 Submap 45 at (89,44); Warp Town -> Area 4 Map 0 Submap 44 at (0,25); Engine Action #89; Clear Dialogue Sub-Window; Warp Town -> Area 1 Map 0 Submap 26 at (1,12); Warp Room -> Submap 1 at (15,1) facing 16; Warp Room -> Submap 1 at (20,1) facing 22; Warp Room -> Submap 1 at (17,1) facing 28; Warp Room -> Submap 1 at (30,1) facing 32; Warp Room -> Submap 1 at (35,1) facing 36; Warp Room -> Submap 1 at (39,1) facing 41; Warp Room -> Submap 47 at (255,254) facing 204 |
| `ev[35]` | `1 (Action / Talk)` | Story Flag 112 (bit 8) SET AND Story Flag 112 (bit 4) CLEAR AND Story Flag 112 (bit 1) CLEAR | Jump to Bytecode Offset (9, 9); Set Object Direction (0, 0); Engine Action #108; Jump to Bytecode Offset (1, 3); Close Dialogue Window; Warp Room -> Submap 120 at (72,1) facing West (Left); Reset Camera Tracking (24); Close Dialogue Sub-Window (0); Engine Action #52; Close Dialogue Sub-Window (1); Open Dialogue Message Window; Engine Action #53; Launch Tactical War Battle (128); Close Dialogue Sub-Window (24); Open Dialogue Message Window; Set Render Priority (pri) (54, 0); Engine Action #128; Set Combat Battle BGM (30); Engine Action #89; Clear Dialogue Sub-Window; Warp Town -> Area 0 Map 89 Submap 45 at (2,3); Close Dialogue Sub-Window (24); Open Dialogue Message Window; Set Animation Pose (73, 20); Jump to Bytecode Offset (9, 8); Close Dialogue Window; Warp Town -> Area 2 Map 120 Submap 9 at (112,1); Load Sound Bank into Memory (0, 1); Screen Fade Transition (144, 1, 10); Engine Action #144; Exit to World Map (69, 1, 13); Engine Action #5; Screen Fade Transition (6, 3, 52); Engine Action #52 |
| `ev[36]` | `1 (Action / Talk)` | Story Flag 112 (bit 8) SET AND Story Flag 112 (bit 4) SET AND Story Flag 112 (bit 1) CLEAR | Jump to Bytecode Offset (9, 9); Set Object Direction (0, 0); Engine Action #108; Jump to Bytecode Offset (1, 3); Close Dialogue Window; Warp Room -> Submap 120 at (72,1) facing West (Left); Reset Camera Tracking (24); Close Dialogue Sub-Window (0); Engine Action #52; Close Dialogue Sub-Window (1); Open Dialogue Message Window; Engine Action #53; Launch Tactical War Battle (128); Close Dialogue Sub-Window (24); Open Dialogue Message Window; Engine Action #54; Engine Action #54; Open Dialogue Message Window; Engine Action #128; Set Combat Battle BGM (30); Engine Action #89; Clear Dialogue Sub-Window; Warp Town -> Area 1 Map 24 Submap 24 at (0,56); Engine Action #89; Make obj[2] Visible (disp = 1); Warp to Castle HQ (73, 20, 101); Engine Action #9; Reset Camera Tracking (11); Warp Town -> Area 2 Map 120 Submap 72 at (0,1); Engine Action #9; Pathfind and Walk to Coordinates (1, 10, 144); Warp Room -> Submap 144 at (4,69) facing West (Left); Place Scenery Structure (5); Screen Fade Transition (6, 3, 52); Engine Action #52 |
| `ev[37]` | `128 (Loop)` | Story Flag 112 (bit 8) SET AND Story Flag 112 (bit 1) CLEAR AND Inventory Holds Item #128 | Engine Action #89; Clear Dialogue Sub-Window; Warp Town -> Area 2 Map 89 Submap 45 at (2,1); Engine Action #89; Make obj[5] Visible (disp = 1); Engine Action #89; Make obj[5] Visible (disp = 1); Engine Action #89; Make obj[2] Visible (disp = 1); Warp Town -> Area 37 Map 128 Submap 255 at (254,204) |
| `ev[38]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[9] | Close Dialogue Sub-Window (10); Show Dialogue Portrait (3, 255, 254) |
| `ev[39]` | `1 (Action / Talk)` | Story Flag 172 (bit 64) SET AND Story Flag 114 (bit 8) CLEAR AND Target Inspected is obj[9] | Close Dialogue Sub-Window (10); Show Dialogue Portrait (3, 255, 254) |
| `ev[40]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #91 AND Player within Box [5..9, 255..254] | Set Render Priority (pri) (0, 127); Toggle Random Encounters (8); Warp to Castle HQ (0, 1, 99); Dismiss Dialogue Portrait; Reset Camera Tracking (30); Warp to Castle HQ (1, 0, 24); Reset Camera Tracking (1); Close Dialogue Window; Set Combat Battle BGM (20); Engine Action #127; Open Dialogue Message Window; Dismiss Dialogue Portrait; Reset Camera Tracking (70); Open Dialogue Message Window; Open Dialogue Message Window; Wait for Audio / Window Sync (3); Close Dialogue Window; Warp Town -> Area 2 Map 60 Submap 12 at (1,127); Toggle Random Encounters (255) |
| `ev[41]` | `1 (Action / Talk)` | Condition Check #24 AND Condition Check #91 AND Player within Box [5..9, 255..254] | Set Render Priority (pri) (0, 127); Toggle Random Encounters (8); Warp to Castle HQ (0, 1, 99); Dismiss Dialogue Portrait; Reset Camera Tracking (30); Exit to World Map (1, 0, 24); Screen Fade Transition (6, 5, 73); Branch on Choice (127, 0); Dismiss Dialogue Portrait; Reset Camera Tracking (70); Open Dialogue Message Window; Open Dialogue Message Window; Wait for Audio / Window Sync (3); Close Dialogue Window; Warp Town -> Area 2 Map 60 Submap 12 at (1,127); Toggle Random Encounters (255) |
| `ev[42]` | `128 (Loop)` | Condition Check #29 AND Star of Destiny #8 Recruited | Warp Room -> Submap 0 at (13,29); Mark NPC Talk Interaction Complete (Flag #16); Reset Camera Tracking (255) |
| `ev[43]` | `2 (Map Init)` | Player within Box [127..128, 2..37] AND Condition Check #38 | Close Dialogue Window; Warp Room -> Submap 60 at (255,254) facing 204 |
| `ev[44]` | `1 (Action / Talk)` | Player within Box [138..139, 5..13] | Engine Action #89; Display Dialogue Box [Bank: 2, MsgID: 4]; Dismiss Emotion Bubble (3); Warp Room -> Submap 24 at (11,1) facing 12; Engine Action #89; Display Dialogue Box [Bank: 2, MsgID: 0] |
| `ev[45]` | `1 (Action / Talk)` | Player Y within Range [55..56] AND Target Inspected is obj[13] | Engine Action #89; Display Dialogue Box [Bank: 2, MsgID: 2]; Dismiss Emotion Bubble (3); Warp Room -> Submap 24 at (11,1) facing 12; Engine Action #89; Display Dialogue Box [Bank: 2, MsgID: 0] |
| `ev[46]` | `1 (Action / Talk)` | Player Y within Range [57..59] AND Target Inspected is obj[13] | Engine Action #89; Display Dialogue Box [Bank: 2, MsgID: 3]; Dismiss Emotion Bubble (3); Warp Room -> Submap 24 at (11,1) facing 12; Engine Action #89; Display Dialogue Box [Bank: 2, MsgID: 0] |
| `ev[47]` | `1 (Action / Talk)` | Player within Box [128..129, 5..16] | Engine Action #89; Show Dialogue Portrait (2, 5, 30); Warp to Castle HQ (1, 0, 24); Animate Door Open; Warp Room -> Submap 89 at (15,2) facing South (Down) |
| `ev[48]` | `1 (Action / Talk)` | Player Y within Range [55..56] AND Target Inspected is obj[16] | Engine Action #89; Show Dialogue Portrait (2, 3, 30); Warp to Castle HQ (1, 0, 24); Animate Door Open; Warp Room -> Submap 89 at (15,2) facing South (Down) |
| `ev[49]` | `1 (Action / Talk)` | Player Y within Range [57..59] AND Target Inspected is obj[16] | Engine Action #89; Show Dialogue Portrait (2, 4, 30); Warp to Castle HQ (1, 0, 24); Animate Door Open; Warp Room -> Submap 89 at (15,2) facing South (Down) |
| `ev[50]` | `1 (Action / Talk)` | Player within Box [127..128, 5..20] | Engine Action #89; Display Choice Selection (2, 11); Dismiss Emotion Bubble (3); Warp Room -> Submap 41 at (6,13) facing South (Down); Warp Room -> Submap 3 at (4,255) facing Up (North); Close Dialogue Sub-Window (18); Engine Action #9; Show Dialogue Portrait (51, 6, 255); Warp Room -> Submap 18 at (8,15) facing 51; Engine Action #6; Place Scenery Structure (255); Open Dialogue Message Window; Warp to Castle HQ (255, 4, 30); Engine Action #5; Warp Room -> Submap 41 at (2,7) facing 8; Pan Camera (24, 18, 11); Show Dialogue Portrait (51, 6, 255); Reset Camera Tracking (24); Display Speaker Name Box (1); Show Dialogue Portrait (255, 6, 89); Display Choice Selection (2, 7) |
| `ev[51]` | `1 (Action / Talk)` | Player Y within Range [38..39] AND Target Inspected is obj[20] | Engine Action #89; Display Choice Selection (2, 10); Dismiss Emotion Bubble (3); Warp Room -> Submap 41 at (6,13) facing South (Down); Warp Room -> Submap 3 at (4,255) facing Up (North); Close Dialogue Sub-Window (18); Engine Action #9; Show Dialogue Portrait (51, 6, 255); Warp Room -> Submap 18 at (8,15) facing 51; Engine Action #6; Place Scenery Structure (255); Open Dialogue Message Window; Warp to Castle HQ (255, 4, 30); Engine Action #5; Warp Room -> Submap 41 at (2,7) facing 8; Pan Camera (24, 18, 11); Show Dialogue Portrait (51, 6, 255); Reset Camera Tracking (24); Display Speaker Name Box (1); Show Dialogue Portrait (255, 6, 89); Display Choice Selection (2, 7) |
| `ev[52]` | `1 (Action / Talk)` | Player within Box [132..133, 5..20] | Dismiss Emotion Bubble (3); Warp Room -> Submap 41 at (6,13) facing South (Down); Warp Room -> Submap 3 at (4,255) facing Up (North); Close Dialogue Sub-Window (18); Engine Action #9; Show Dialogue Portrait (255, 254, 255); Warp Room -> Submap 18 at (8,15) facing 255; Place Scenery Structure (255); Open Dialogue Message Window; Warp to Castle HQ (255, 4, 30); Engine Action #5; Warp Room -> Submap 41 at (2,7) facing 8; Pan Camera (24, 18, 11); Show Dialogue Portrait (255, 254, 255); Reset Camera Tracking (24); Display Speaker Name Box (1); Show Dialogue Portrait (255, 254, 204) |
| `ev[53]` | `1 (Action / Talk)` | Player Y within Range [38..39] AND Target Inspected is obj[23] | Engine Action #89; Set Story Flag (2, 4); Dismiss Emotion Bubble (3); Warp Room -> Submap 41 at (6,13) facing South (Down); Warp Room -> Submap 3 at (4,255) facing Up (North); Close Dialogue Sub-Window (21); Engine Action #9; Change Portrait Expression (51); Engine Action #6; Warp Room -> Submap 21 at (8,17) facing 51; Engine Action #6; Place Scenery Structure (255); Open Dialogue Message Window; Warp to Castle HQ (255, 4, 30); Engine Action #5; Warp Room -> Submap 41 at (2,7) facing 8; Pan Camera (24, 21, 11); Change Portrait Expression (51); Engine Action #6; Reset Camera Tracking (24); Execute Choice Result (1); Change Portrait Expression (255); Engine Action #6; Engine Action #89; Set Story Flag (2, 0) |
| `ev[54]` | `1 (Action / Talk)` | Player within Box [130..132, 5..23] | Engine Action #89; Set Story Flag (2, 3); Dismiss Emotion Bubble (3); Warp Room -> Submap 41 at (6,13) facing South (Down); Warp Room -> Submap 3 at (4,255) facing Up (North); Close Dialogue Sub-Window (21); Engine Action #9; Change Portrait Expression (51); Engine Action #6; Warp Room -> Submap 21 at (8,17) facing 51; Engine Action #6; Place Scenery Structure (255); Open Dialogue Message Window; Warp to Castle HQ (255, 4, 30); Engine Action #5; Warp Room -> Submap 41 at (2,7) facing 8; Pan Camera (24, 21, 11); Change Portrait Expression (51); Engine Action #6; Reset Camera Tracking (24); Execute Choice Result (1); Change Portrait Expression (255); Engine Action #6; Engine Action #89; Set Story Flag (2, 0) |
| `ev[55]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Dismiss Emotion Bubble (3); Warp Room -> Submap 23 at (1,19) facing 255 |
| `ev[56]` | `1 (Action / Talk)` | Player within Box [115..117, 5..26] | Engine Action #89; Clear Dialogue Sub-Window; Warp Town -> Area 4 Map 30 Submap 3 at (1,0); Close Dialogue Sub-Window (24); Warp Room -> Submap 89 at (25,2) facing South (Down) |
| `ev[57]` | `1 (Action / Talk)` | Player Y within Range [43..45] AND Target Inspected is obj[26] | Engine Action #89; Clear Dialogue Sub-Window; Warp Town -> Area 2 Map 30 Submap 3 at (1,0); Close Dialogue Sub-Window (24); Warp Room -> Submap 89 at (25,2) facing South (Down) |
| `ev[58]` | `1 (Action / Talk)` | Player Y within Range [48..50] AND Target Inspected is obj[26] | Engine Action #89; Clear Dialogue Sub-Window; Warp Town -> Area 3 Map 30 Submap 3 at (1,0); Close Dialogue Sub-Window (24); Warp Room -> Submap 89 at (25,2) facing South (Down) |
| `ev[59]` | `1 (Action / Talk)` | Player within Box [127..129, 5..29] | Engine Action #89; Display Chapter Text (2); Exit to World Map (30, 3, 1); Open Dialogue Message Window; Close Dialogue Sub-Window (27); Warp Room -> Submap 89 at (28,2) facing South (Down) |
| `ev[60]` | `1 (Action / Talk)` | Player Y within Range [43..45] AND Target Inspected is obj[29] | Engine Action #89; Display Chapter Text (2); Warp Town -> Area 30 Map 3 Submap 1 at (0,24); Fade Out to Black (1); Execute Choice Result (89); Display Chapter Text (2); Open Dialogue Message Window |
| `ev[61]` | `1 (Action / Talk)` | Player Y within Range [48..50] AND Target Inspected is obj[29] | Engine Action #89; Display Chapter Text (2); Warp to Castle HQ (30, 3, 1); Open Dialogue Message Window; Close Dialogue Sub-Window (27); Warp Room -> Submap 89 at (28,2) facing South (Down) |
| `ev[62]` | `1 (Action / Talk)` | Target Inspected is obj[30] | Dismiss Emotion Bubble (3); Warp Room -> Submap 23 at (1,22) facing 255 |
| `ev[63]` | `1 (Action / Talk)` | Player within Box [120..122, 5..33] | Engine Action #89; Warp Map Transition (2, 3, 30, 3, 1); Open Dialogue Message Window; Close Dialogue Sub-Window (31); Warp Room -> Submap 89 at (32,2) facing South (Down) |
| `ev[64]` | `1 (Action / Talk)` | Player within Box [122..124, 5..33] | Engine Action #89; Warp Map Transition (2, 5, 30, 3, 1); Open Dialogue Message Window; Close Dialogue Sub-Window (31); Warp Room -> Submap 89 at (32,2) facing South (Down) |
| `ev[65]` | `1 (Action / Talk)` | Player Y within Range [55..52] AND Target Inspected is obj[33] | Engine Action #89; Warp Map Transition (2, 5, 30, 3, 1); Open Dialogue Message Window; Close Dialogue Sub-Window (31); Warp Room -> Submap 89 at (32,2) facing South (Down) |
| `ev[66]` | `1 (Action / Talk)` | Player within Box [128..129, 5..36] | Engine Action #89; Start Boss Battle #2 (BGM: 4); Dismiss Emotion Bubble (3); Warp Room -> Submap 24 at (34,1) facing 24; Engine Action #89; Start Boss Battle #2 (BGM: 0) |
| `ev[67]` | `1 (Action / Talk)` | Player Y within Range [45..46] AND Target Inspected is obj[36] | Engine Action #89; Start Boss Battle #2 (BGM: 2); Dismiss Emotion Bubble (3); Warp Room -> Submap 24 at (34,1) facing 24; Engine Action #89; Start Boss Battle #2 (BGM: 0) |
| `ev[68]` | `1 (Action / Talk)` | Player Y within Range [47..49] AND Target Inspected is obj[36] | Engine Action #89; Start Boss Battle #2 (BGM: 3); Dismiss Emotion Bubble (3); Warp Room -> Submap 24 at (34,1) facing 24; Engine Action #89; Start Boss Battle #2 (BGM: 0) |
| `ev[69]` | `1 (Action / Talk)` | Player Y within Range [45..42] AND Target Inspected is obj[39] | Engine Action #89; Open Save Crystal Menu (MSaveInit); Warp Town -> Area 1 Map 73 Submap 10 at (30,3); Warp Room -> Submap 24 at (37,1) facing 25; Engine Action #89; Open Save Crystal Menu (MSaveInit); Warp Town -> Area 3 Map 255 Submap 254 at (204,204) |
| `ev[70]` | `1 (Action / Talk)` | Player within Box [132..134, 5..39] | Engine Action #89; Open Save Crystal Menu (MSaveInit); Warp Town -> Area 4 Map 73 Submap 10 at (30,3); Warp Room -> Submap 24 at (37,1) facing 25; Engine Action #89; Open Save Crystal Menu (MSaveInit); Warp Town -> Area 3 Map 255 Submap 254 at (204,204) |
| `ev[71]` | `1 (Action / Talk)` | Player within Box [134..136, 5..39] | Engine Action #89; Open Save Crystal Menu (MSaveInit); Warp Town -> Area 6 Map 73 Submap 10 at (30,3); Warp Room -> Submap 24 at (37,1) facing 25; Engine Action #89; Open Save Crystal Menu (MSaveInit); Warp Town -> Area 3 Map 255 Submap 254 at (204,204) |
| `ev[72]` | `1 (Action / Talk)` | Player Y within Range [45..42] AND Target Inspected is obj[42] | Engine Action #89; Award Potch Loot (+521 Potch); Dismiss Emotion Bubble (3); Warp Room -> Submap 24 at (40,1) facing 26; Engine Action #89; Award Potch Loot (+519 Potch) |
| `ev[73]` | `1 (Action / Talk)` | Player within Box [120..122, 5..42] | Engine Action #89; Award Potch Loot (+522 Potch); Dismiss Emotion Bubble (3); Warp Room -> Submap 24 at (40,1) facing 26; Engine Action #89; Award Potch Loot (+519 Potch) |
| `ev[74]` | `1 (Action / Talk)` | Player within Box [122..124, 5..42] | Engine Action #89; Award Potch Loot (+523 Potch); Dismiss Emotion Bubble (3); Warp Room -> Submap 24 at (40,1) facing 26; Engine Action #89; Award Potch Loot (+519 Potch) |
| `ev[75]` | `2 (Map Init)` | Story Flag 144 (bit 4) SET | Dismiss Emotion Bubble (1); Warp Town -> Area 16 Map 11 Submap 255 at (254,204) |
| `ev[76]` | `2 (Map Init)` | Story Flag 144 (bit 4) SET | Make obj[2] Hidden (disp = 0); Open Shop Menu #84 (Type: 130); Warp to Castle HQ (43, 1, 0); Open Shop Menu #255 (Type: 47) |
| `ev[77]` | `1 (Action / Talk)` | Story Flag 144 (bit 4) SET AND Player within Box [125..135, 2..82] AND Condition Check #85 | Close Dialogue Sub-Window (43); Engine Action #5; Open Dialogue Message Window; Engine Action #5; Open Dialogue Message Window; Warp Room -> Submap 30 at (255,254) facing 204 |
| `ev[78]` | `128 (Loop)` | Player within Box [106..138, 2..56] AND Condition Check #80 AND Story Flag 144 (bit 32) SET | Warp Room -> Submap 0 at (10,33) |
| `ev[79]` | `128 (Loop)` | Player within Box [106..138, 2..56] AND Condition Check #80 AND Story Flag 144 (bit 32) CLEAR | Warp Room -> Submap 0 at (10,0) |
| `ev[80]` | `1 (Action / Talk)` | Player within Box [126..134, 2..84] AND Condition Check #85 AND Story Flag 0 (mask 255) SET | Engine Action #111; Award Potch Loot (+1,280 Potch); Warp Room -> Submap 3 at (4,255) facing South (Down); Warp Room -> Submap 3 at (2,46) facing 120; Warp Town -> Area 32 Map 3 Submap 1 at (46,120); Warp to Castle HQ (255, 4, 32); Warp to Castle HQ (0, 46, 120) |
| `ev[81]` | `1 (Action / Talk)` | Player within Box [108..112, 2..32] AND Condition Check #33 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 76]; Display Emotion Bubble (255, 254) |
| `ev[82]` | `1 (Action / Talk)` | Player within Box [126..134, 2..70] AND Condition Check #71 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 130]; Engine Action #139 |
| `ev[83]` | `1 (Action / Talk)` | Target Inspected is obj[48] | Dismiss Emotion Bubble (4); Warp Room -> Submap 23 at (6,5) facing 255 |
| `ev[84]` | `1 (Action / Talk)` | Target Inspected is obj[49] | Dismiss Emotion Bubble (4); Warp Room -> Submap 23 at (6,6) facing 255 |
| `ev[85]` | `1 (Action / Talk)` | Target Inspected is obj[50] | Dismiss Emotion Bubble (4); Warp Room -> Submap 23 at (6,7) facing East (Right); Walk obj[1] to (255,254) |
| `ev[86]` | `1 (Action / Talk)` | Target Inspected is obj[51] | Dismiss Emotion Bubble (4); Warp Room -> Submap 23 at (6,8) facing 255 |
| `ev[87]` | `1 (Action / Talk)` | Target Inspected is obj[52] | Dismiss Emotion Bubble (4); Warp Room -> Submap 23 at (6,9) facing East (Right); Engine Action #52; Open Dialogue Message Window |
| `ev[88]` | `1 (Action / Talk)` | Target Inspected is obj[53] | Dismiss Emotion Bubble (4); Warp Room -> Submap 23 at (6,10) facing East (Right); Engine Action #53; Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[89]` | `1 (Action / Talk)` | Target Inspected is obj[54] | Dismiss Emotion Bubble (4); Warp Room -> Submap 23 at (6,11) facing East (Right); Engine Action #54; Warp to Castle HQ (255, 254, 204) |
| `ev[90]` | `1 (Action / Talk)` | Target Inspected is obj[46] | Close Dialogue Sub-Window (46); Exit to World Map (7, 255, 254) |

---

### Submap Layer `vk08_02` (Index 2)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `23` Objects | **Script Count (`evkaz`)**: `45` Scripts

#### Complete Physical Entity Inventory (23 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Alex (Innkeeper)** | `94` | `(131, 154)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | Trigger / Hitbox | **Hitbox Zone (5x2)** | `0` | `(129, 155)` | `4x1` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Hilda (Inn Hostess)** | `95` | `(97, 154)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | Trigger / Hitbox | **Hitbox Zone (5x2)** | `0` | `(95, 155)` | `4x1` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | NPC / Actor | **Fireplace Chimney / Hearth** | `64815` | `(124, 117)` | `3x3` | South (Down) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[05]` | NPC / Actor | **Sierra Mikain** | `44` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | NPC / Actor | **Fireplace Chimney / Hearth** | `64815` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | NPC / Actor | **Youth Brigade Recruit** | `3` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | NPC / Actor | **Jowy Atreides** | `2` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | NPC / Actor | **Klaus** | `91` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | World Device | **Mechanism (ano 31)** | `0` | `(122, 156)` | `0x0` | Frame 31 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | World Device | **Mechanism (ano 32)** | `0` | `(102, 156)` | `0x0` | Frame 32 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | Trigger / Hitbox | **Hitbox Zone (5x2)** | `0` | `(98, 147)` | `4x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | Trigger / Hitbox | **Hitbox Zone (5x2)** | `0` | `(134, 151)` | `4x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(90, 146)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[15]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(92, 145)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[16]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(93, 147)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[17]` | NPC / Actor | **Actor ID 65085** | `65085` | `(90, 150)` | `0x0` | Up (North) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[18]` | NPC / Actor | **Actor ID 65083** | `65083` | `(133, 159)` | `7x7` | South (Down) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[19]` | NPC / Actor | **Actor ID 65048** | `65048` | `(105, 158)` | `7x7` | South (Down) | Dormant / Hidden (0) | Special (3) | 2 | 128 | 0 |
| `obj[20]` | NPC / Actor | **Actor ID 65178** | `65178` | `(101, 125)` | `7x7` | South (Down) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[21]` | NPC / Actor | **Actor ID 65048** | `65048` | `(130, 115)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[22]` | NPC / Actor | **Actor ID 65205** | `65205` | `(81, 115)` | `0x0` | Up (North) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Alex (Innkeeper))**: Positioned at tile `(131, 154)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `2` tiles high from `(129, 155)` to `(133, 156)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[02]` (Hilda (Inn Hostess))**: Positioned at tile `(97, 154)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `2` tiles high from `(95, 155)` to `(99, 156)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[04]` (Fireplace Chimney / Hearth)**: Positioned at tile `(124, 117)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Sierra Mikain)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[06]` (Fireplace Chimney / Hearth)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[07]` (Youth Brigade Recruit)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[08]` (Jowy Atreides)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[09]` (Klaus)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[10]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(122, 156)` with state parameter `31`.
- **`obj[11]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(102, 156)` with state parameter `32`.
- **`obj[12]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `2` tiles high from `(98, 147)` to `(102, 148)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[13]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `2` tiles high from `(134, 151)` to `(138, 152)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[14]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(90, 146)` to `(92, 148)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[15]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(92, 145)` to `(94, 147)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[16]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(93, 147)` to `(95, 149)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[17]` (Object 65085)**: Positioned at tile `(90, 150)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[18]` (Object 65083)**: Positioned at tile `(133, 159)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[19]` (Object 65048)**: Positioned at tile `(105, 158)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[20]` (Object 65178)**: Positioned at tile `(101, 125)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[21]` (Object 65048)**: Positioned at tile `(130, 115)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[22]` (Object 65205)**: Positioned at tile `(81, 115)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.


#### Complete Bytecode Script Catalog (45 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 144 (bit 4) CLEAR AND Condition Check #23 AND Condition Check #94 AND Player X within Range [255..254] | Make obj[0] Hidden (disp = 0); Reset Camera Tracking (0); Engine Action #9; Teleport obj[255] to (254,204) |
| `ev[01]` | `2 (Map Init)` | Story Flag 144 (bit 4) CLEAR AND Condition Check #23 AND Condition Check #95 AND Player X within Range [255..254] | Make obj[0] Hidden (disp = 0); Screen Fade Transition (0, 11, 47) |
| `ev[02]` | `2 (Map Init)` | Story Flag 144 (bit 4) CLEAR AND Condition Check #23 AND Condition Check #95 AND Player within Box [23..94, 1..255] | Make obj[0] Hidden (disp = 0); Display Dialogue Box [Bank: 47, MsgID: 255] |
| `ev[03]` | `2 (Map Init)` | Story Flag 144 (bit 4) CLEAR AND Condition Check #33 AND Player within Box [3..3, 112..64] | Open Dialogue Message Window; Clear Dialogue Sub-Window |
| `ev[04]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #94 AND Player Y within Range [23..95] AND Player Y within Range [4..144] AND Story Flag 33 (bit 1) CLEAR AND Player Y within Range [3..112] AND Condition Check #64 | Open Dialogue Message Window; Fade In from Black (255) |
| `ev[05]` | `2 (Map Init)` | Story Flag 144 (bit 4) CLEAR AND Condition Check #33 AND Player within Box [1..3, 112..64] | Open Dialogue Message Window; Fade Out to Black (255) |
| `ev[06]` | `2 (Map Init)` | Story Flag 144 (bit 4) CLEAR AND Condition Check #33 AND Player within Box [3..3, 112..64] | Open Dialogue Message Window; Display Chapter Text (255) |
| `ev[07]` | `2 (Map Init)` | Story Flag 144 (bit 4) CLEAR AND Condition Check #33 AND Player within Box [1..3, 112..64] | Open Dialogue Message Window; Display Emotion Bubble (255, 254) |
| `ev[08]` | `2 (Map Init)` | Story Flag 144 (bit 4) CLEAR AND Condition Check #33 AND Player within Box [2..3, 112..64] | Open Dialogue Message Window; Dismiss Emotion Bubble (255) |
| `ev[09]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #94 AND Player Y within Range [255..254] | Make obj[0] Hidden (disp = 0); Display Speaker Name Box (0); Display Choice Selection (47, 255) |
| `ev[10]` | `2 (Map Init)` | Story Flag 144 (bit 4) CLEAR AND Story Flag 92 (bit 64) SET AND Story Flag 93 (bit 1) CLEAR | Make obj[2] Hidden (disp = 0); Place Scenery Structure (101); Engine Action #159; Warp to Castle HQ (13, 2, 0); Place Scenery Structure (2); Screen Fade Transition (95, 159, 3); Screen Fade Transition (3, 2, 14); Display Dialogue Message (158, 3); Animate Door Open; Warp Room -> Submap 14 at (1,12) facing West (Left); Clear Dialogue Sub-Window; Warp Room -> Submap 1 at (27,1) facing 28; Warp Room -> Submap 1 at (30,47) facing 255 |
| `ev[11]` | `1 (Action / Talk)` | Story Flag 144 (bit 4) CLEAR AND Story Flag 92 (bit 64) SET AND Story Flag 93 (bit 1) CLEAR AND Player within Box [117..121, 2..155] AND Condition Check #157 | Close Dialogue Sub-Window (10); Warp Town -> Area 0 Map 4 Submap 0 at (119,159); Reset Camera Tracking (3); Open Dialogue Message Window; Warp Town -> Area 72 Map 1 Submap 0 at (2,28); Warp Town -> Area 31 Map 6 Submap 72 at (0,0); Make obj[2] Hidden (disp = 0); Reset Camera Tracking (129); Engine Action #161; Warp Town -> Area 15 Map 121 Submap 157 at (0,15); Warp Town -> Area 16 Map 122 Submap 160 at (0,16); Warp Town -> Area 17 Map 125 Submap 159 at (0,17); Teleport obj[24] to (13,2); Warp Room -> Submap 10 at (2,2) facing 24; Place Scenery Structure (2); Warp to Castle HQ (30, 0, 4); Screen Fade Transition (2, 4, 1); Launch Tactical War Battle (1); Engine Action #5; Place Scenery Structure (4); Pan Camera (2, 4, 30); Display Dialogue with Speaker Name (1, 10, 5); Screen Fade Transition (4, 5, 7); Exit to World Map (30, 130, 0); Screen Fade Transition (24, 8, 2); Engine Action #5; Open Shop Menu #5 (Type: 8); Open Shop Menu #6 (Type: 14); Set Entity Movement Speed (2, 48); Animate Door Open; Screen Fade Transition (3, 2, 1); Warp Room -> Submap 3 at (14,2) facing 255; Turn obj[8] facing 10; Warp to Castle HQ (2, 0, 1); Reset Camera Tracking (3); Reset Camera Tracking (2); Walk obj[3] to (14,3); Close Dialogue Sub-Window (14); Warp Town -> Area 6 Map 24 Submap 13 at (2,7); Warp to Castle HQ (8, 3, 24); Reset Camera Tracking (2); Reset Camera Tracking (3); Animate Door Open; Warp Town -> Area 5 Map 14 Submap 6 at (1,30); Close Dialogue Sub-Window (14); Warp Town -> Area 9 Map 49 Submap 4 at (5,0); Exit to World Map (6, 2, 16); Dismiss Emotion Bubble (255); Engine Action #5; Dismiss Dialogue Portrait; Engine Action #5; Engine Action #5; Exit to World Map (6, 2, 16); Dismiss Emotion Bubble (255); Engine Action #5; Show Dialogue Portrait (4, 6, 5); Screen Fade Transition (2, 16, 30); Engine Action #5; Change Portrait Expression (4); Engine Action #6; Engine Action #5; Show Dialogue Portrait (2, 16, 30); Walk obj[3] to (13,3); Set Combat Battle BGM (30); Warp to Castle HQ (13, 2, 24); Place Scenery Structure (2); Screen Fade Transition (24, 10, 2); Close Dialogue Window; Close Dialogue Sub-Window (13); Warp Town -> Area 12 Map 73 Submap 20 at (40,0); Open Dialogue Message Window; Warp Town -> Area 2 Map 13 Submap 2 at (15,41); Warp Town -> Area 0 Map 1 Submap 255 at (0,49); Exit to World Map (5, 0, 4); Engine Action #6; Warp Town -> Area 3 Map 30 Submap 255 at (254,5); Dismiss Dialogue Portrait; Exit to World Map (6, 2, 4); Dismiss Emotion Bubble (255); Engine Action #5; Show Dialogue Portrait (4, 6, 2); Reset Camera Tracking (0); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Change Portrait Expression (4); Engine Action #6; Warp Town -> Area 4 Map 30 Submap 255 at (254,50); Close Dialogue Sub-Window (10); Warp Town -> Area 14 Map 73 Submap 60 at (255,1); Close Dialogue Sub-Window (10); Warp Town -> Area 16 Map 49 Submap 2 at (5,10); Exit to World Map (3, 3, 1); Dismiss Emotion Bubble (255); Engine Action #5; Animate Door Open; Exit to World Map (3, 0, 0); Pan Camera (2, 3, 0); Dismiss Emotion Bubble (255); Walk obj[73] to (60,5); Screen Fade Transition (1, 0, 5); Dismiss Emotion Bubble (0); Open Dialogue Message Window; Engine Action #5; Dismiss Emotion Bubble (3); Open Dialogue Message Window; Dismiss Emotion Bubble (24); Screen Fade Transition (2, 17, 73); Trigger Character Emotion Effect (24, 13); Warp Town -> Area 18 Map 73 Submap 90 at (24,13); Warp Town -> Area 19 Map 43 Submap 13 at (4,48); Place Scenery Structure (0); Warp Town -> Area 0 Map 0 Submap 3 at (9,3); Open Dialogue Message Window; Open Dialogue Message Window; Close Dialogue Sub-Window (13); Warp Town -> Area 20 Map 36 Submap 2 at (73,60); Close Dialogue Window; Warp Town -> Area 2 Map 40 Submap 1 at (16,1); Show Dialogue Portrait (1, 17, 1); Animate Door Open; Display Emotion Bubble (7, 2); Screen Fade Transition (97, 155, 3); Screen Fade Transition (0, 2, 8); Engine Action #131; Engine Action #155; Warp to Castle HQ (8, 0, 54); Open Dialogue Message Window; Warp Town -> Area 11 Map 1 Submap 2 at (40,99); Animate Door Open; Warp Town -> Area 9 Map 93 Submap 1 at (255,254) |
| `ev[12]` | `128 (Loop)` | Story Flag 144 (bit 4) CLEAR AND Story Flag 92 (bit 64) SET AND Story Flag 93 (bit 1) CLEAR AND Inventory Holds Item #1 | Jump to Bytecode Offset (4, 23); Close Dialogue Window; Exit to World Map (2, 3, 11); Warp to Castle HQ (2, 40, 37); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[13]` | `128 (Loop)` | Story Flag 144 (bit 4) CLEAR AND Story Flag 92 (bit 64) SET AND Story Flag 93 (bit 1) CLEAR AND Inventory Holds Item #2 | Exit to World Map (13, 118, 158); Reset Camera Tracking (1); Place Scenery Structure (37); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[14]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #94 AND Player within Box [3..144, 1..29] AND Active Party Has Character #2 AND Target Inspected is obj[8] | Clear Story Milestone Flag 15 (mask 8); Engine Action #240; Engine Action #240; Warp Town -> Area 23 Map 2 Submap 10 at (1,255) |
| `ev[15]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #94 AND Player within Box [3..144, 1..29] AND Active Party Has Character #2 AND Target Inspected is obj[9] | Warp to Castle HQ (8, 0, 96); Show Dialogue Portrait (8, 240, 240); Warp Town -> Area 23 Map 2 Submap 10 at (1,255) |
| `ev[16]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #94 AND Player within Box [4..144, 1..29] AND Active Party Has Character #2 AND Target Inspected is obj[8] | Clear Story Milestone Flag 15 (mask 8); Engine Action #240; Engine Action #240; Warp Town -> Area 23 Map 2 Submap 10 at (0,255) |
| `ev[17]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #94 AND Player within Box [4..144, 1..29] AND Active Party Has Character #2 AND Target Inspected is obj[9] | Warp to Castle HQ (8, 0, 96); Show Dialogue Portrait (8, 240, 240); Warp Town -> Area 23 Map 2 Submap 10 at (0,255) |
| `ev[18]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #94 AND Player within Box [3..144, 1..5] AND Temp Event Flag #255 CLEAR | Dismiss Emotion Bubble (3); Warp Room -> Submap 96 at (15,8) facing 240; Engine Action #240; Warp Room -> Submap 2 at (10,1) facing 255 |
| `ev[19]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #94 AND Player within Box [3..144, 1..5] AND Story Flag 255 (mask 254) SET | Warp to Castle HQ (8, 0, 30); Warp to Castle HQ (1, 0, 96); Show Dialogue Portrait (8, 240, 240); Warp Room -> Submap 2 at (10,1) facing 255 |
| `ev[20]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #94 AND Player within Box [4..144, 1..5] AND Temp Event Flag #255 CLEAR | Dismiss Emotion Bubble (3); Warp Room -> Submap 96 at (15,8) facing 240; Engine Action #240; Warp Room -> Submap 2 at (10,0) facing 255 |
| `ev[21]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #94 AND Player within Box [4..144, 1..5] AND Story Flag 255 (mask 254) SET | Warp to Castle HQ (8, 0, 30); Warp to Castle HQ (1, 0, 96); Show Dialogue Portrait (8, 240, 240); Warp Room -> Submap 2 at (10,0) facing 255 |
| `ev[22]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #95 AND Player within Box [29..14, 2..5] AND Story Flag 255 (mask 254) CLEAR | Clear Story Milestone Flag 34 (mask 10); Engine Action #240; Engine Action #240; Warp Town -> Area 22 Map 3 Submap 0 at (0,0) |
| `ev[23]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #95 AND Player within Box [29..14, 2..5] AND Player X in Range [255..254] | Warp to Castle HQ (10, 0, 96); Return Warp to Castle Base (10, 240); Engine Action #240; Warp Town -> Area 22 Map 3 Submap 0 at (0,0) |
| `ev[24]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #95 AND Player within Box [5..10, 255..254] | Dismiss Emotion Bubble (3); Warp Room -> Submap 96 at (34,10) facing 240; Engine Action #240; Warp Room -> Submap 3 at (0,0) facing South (Down) |
| `ev[25]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #95 AND Player within Box [5..11, 255..254] | Warp to Castle HQ (10, 0, 30); Warp to Castle HQ (1, 0, 96); Return Warp to Castle Base (10, 240); Engine Action #240; Warp Room -> Submap 3 at (0,0) facing South (Down) |
| `ev[26]` | `1 (Action / Talk)` | Target Inspected is obj[12] AND Condition Check #29 AND Active Party Has Character #2 | Engine Action #118; Display Dialogue Box [Bank: 16, MsgID: 0]; Dismiss Dialogue Portrait; Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[27]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Engine Action #118; Display Dialogue Box [Bank: 16, MsgID: 0]; Dismiss Dialogue Portrait; Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[28]` | `2 (Map Init)` | Story Flag 144 (bit 4) SET | Dismiss Emotion Bubble (1); Warp Town -> Area 16 Map 11 Submap 255 at (254,204) |
| `ev[29]` | `1 (Action / Talk)` | Player within Box [126..134, 2..142] AND Condition Check #143 AND Story Flag 0 (mask 255) SET | Mark NPC Talk Interaction Complete (Flag #14); Warp Town -> Area 12 Map 1 Submap 130 at (77,255) |
| `ev[30]` | `1 (Action / Talk)` | Target Inspected is obj[25] | Dismiss Emotion Bubble (4); Warp Room -> Submap 23 at (6,12) facing East (Right); Clear Dialogue Sub-Window; Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[31]` | `2 (Map Init)` | Always Passes (Unconditional) | Mark NPC Talk Interaction Complete (Flag #11); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[32]` | `2 (Map Init)` | Condition Check #25 AND Player Y within Range [255..254] | Make obj[2] Hidden (disp = 0); Fade In from Black (124); Engine Action #118; Engine Action #99; Close Dialogue Window; Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[33]` | `1 (Action / Talk)` | Condition Check #30 AND Player X in Range [1..5] AND Condition Check #26 | Open Dialogue Sub-Window (6); Place Scenery Structure (255) |
| `ev[34]` | `1 (Action / Talk)` | Condition Check #29 AND Player X in Range [1..5] AND Condition Check #26 | Open Dialogue Sub-Window (14); Place Scenery Structure (255) |
| `ev[35]` | `1 (Action / Talk)` | Target Inspected is obj[27] | Dismiss Emotion Bubble (4); Warp Room -> Submap 23 at (6,14) facing 255 |
| `ev[36]` | `1 (Action / Talk)` | Target Inspected is obj[28] | Dismiss Emotion Bubble (4); Warp Room -> Submap 23 at (6,15) facing 255 |
| `ev[37]` | `2 (Map Init)` | Always Passes (Unconditional) | Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[38]` | `1 (Action / Talk)` | Target Inspected is obj[29] | Dismiss Emotion Bubble (4); Warp Room -> Submap 23 at (6,16) facing East (Right); Display Emotion Bubble (0, 255) |
| `ev[39]` | `1 (Action / Talk)` | Target Inspected is obj[30] | Dismiss Emotion Bubble (4); Warp Room -> Submap 23 at (6,17) facing East (Right); Dismiss Emotion Bubble (2) |
| `ev[40]` | `1 (Action / Talk)` | Target Inspected is obj[20] | Open Dialogue Sub-Window (4); Reset Camera Tracking (255) |
| `ev[41]` | `1 (Action / Talk)` | Target Inspected is obj[21] | Close Dialogue Sub-Window (21); Exit to World Map (9, 255, 254) |
| `ev[42]` | `1 (Action / Talk)` | Target Inspected is obj[22] | Close Dialogue Sub-Window (22); Exit to World Map (10, 255, 254) |
| `ev[43]` | `1 (Action / Talk)` | Target Inspected is obj[23] | Close Dialogue Sub-Window (23); Exit to World Map (11, 255, 254) |
| `ev[44]` | `1 (Action / Talk)` | Target Inspected is obj[24] | Close Dialogue Sub-Window (24); Exit to World Map (12, 255, 254) |

---


