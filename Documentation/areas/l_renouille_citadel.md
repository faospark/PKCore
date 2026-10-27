# Suikoden II Geographic Area Catalog: L'Renouille Imperial Capital Citadel

**Geographic Scope & Role**: Final Highland royal fortress; massive outer gates, defensive trenches, armory halls, royal throne room of the Blight Kings, and the Beast Rune Sanctum.

**Regional Category**: Region `VJ` | **Master Maps Included**: `vj01`, `vj02`, `vj03`, `vj04`, `vj05`, `vj06`, `vj07`, `vj08`, `vj09`, `vj10`, `vj11`, `vj12`, `vj13`, `vj14`, `vj15`, `vj16`, `vj18`, `vj19`, `vj20`, `vj21`, `vj22`, `vj23`, `vj24`

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

## Location Map: `vj01`

- **Master Map Container**: `vj01.json`
- **Submap Layer Files**: Embedded in master
- **Collision Grid Files**: vj01_map_00.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 1

### Submap Layer `vj01_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `22` Objects | **Script Count (`evkaz`)**: `128` Scripts

#### Complete Physical Entity Inventory (22 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Rowd** | `85` | `(37, 85)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Youth Brigade Recruit** | `3` | `(43, 84)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Jowy Atreides** | `2` | `(42, 87)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | NPC / Actor | **Gorudo** | `34` | `(36, 89)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[04]` | NPC / Actor | **Actor ID 117** | `117` | `(37, 92)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[05]` | NPC / Actor | **Actor ID 122** | `122` | `(37, 92)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[06]` | NPC / Actor | **Chaco** | `54` | `(35, 81)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[07]` | NPC / Actor | **Futch** | `101` | `(40, 91)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[08]` | NPC / Actor | **Fitcher** | `15` | `(42, 90)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[09]` | NPC / Actor | **Seed** | `88` | `(0, 0)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 5 | 255 | 0 |
| `obj[10]` | NPC / Actor | **Klaus** | `91` | `(0, 0)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 5 | 255 | 0 |
| `obj[11]` | NPC / Actor | **Actor ID 118** | `118` | `(0, 0)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 5 | 255 | 0 |
| `obj[12]` | NPC / Actor | **Tsai** | `52` | `(0, 0)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 5 | 255 | 0 |
| `obj[13]` | NPC / Actor | **Pilika** | `4` | `(0, 0)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 5 | 255 | 0 |
| `obj[14]` | NPC / Actor | **Simone Verdicci** | `37` | `(0, 0)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 5 | 255 | 0 |
| `obj[15]` | NPC / Actor | **Actor ID 41** | `41` | `(0, 0)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 5 | 255 | 0 |
| `obj[16]` | NPC / Actor | **Actor ID 42** | `42` | `(0, 0)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 5 | 255 | 0 |
| `obj[17]` | NPC / Actor | **Eilie** | `19` | `(0, 0)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 5 | 255 | 0 |
| `obj[18]` | NPC / Actor | **Rina** | `20` | `(0, 0)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 5 | 255 | 0 |
| `obj[19]` | NPC / Actor | **Bolgan** | `21` | `(0, 0)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 5 | 255 | 0 |
| `obj[20]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(60, 92)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[21]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(58, 92)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Rowd)**: Positioned at tile `(37, 85)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Youth Brigade Recruit)**: Positioned at tile `(43, 84)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Jowy Atreides)**: Positioned at tile `(42, 87)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Gorudo)**: Positioned at tile `(36, 89)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Object 117)**: Positioned at tile `(37, 92)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Object 122)**: Positioned at tile `(37, 92)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[06]` (Chaco)**: Positioned at tile `(35, 81)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[07]` (Futch)**: Positioned at tile `(40, 91)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[08]` (Fitcher)**: Positioned at tile `(42, 90)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[09]` (Seed)**: Positioned at tile `(0, 0)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[10]` (Klaus)**: Positioned at tile `(0, 0)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[11]` (Object 118)**: Positioned at tile `(0, 0)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[12]` (Tsai)**: Positioned at tile `(0, 0)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[13]` (Pilika)**: Positioned at tile `(0, 0)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[14]` (Simone Verdicci)**: Positioned at tile `(0, 0)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[15]` (Object 41)**: Positioned at tile `(0, 0)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[16]` (Object 42)**: Positioned at tile `(0, 0)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[17]` (Eilie)**: Positioned at tile `(0, 0)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[18]` (Rina)**: Positioned at tile `(0, 0)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[19]` (Bolgan)**: Positioned at tile `(0, 0)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[20]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(60, 92)` to `(62, 94)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[21]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(58, 92)` to `(60, 94)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (128 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 98 (bit 128) SET AND Story Flag 95 (bit 128) CLEAR | Make obj[0] Hidden (disp = 0); Reset Camera Tracking (0); Engine Action #9; Open Dialogue Message Window; Screen Fade Transition (0, 11, 0); Animate Door Open; Open Dialogue Message Window; Show Dialogue Portrait (0, 16, 2); Open Dialogue Message Window; Engine Action #40; Dismiss Character to Castle Base (3 [Viktor]); Open Dialogue Message Window; Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[01]` | `2 (Map Init)` | Story Flag 98 (bit 128) SET AND Story Flag 95 (bit 128) CLEAR AND Condition Check #24 AND Condition Check #117 AND Temp Event Flag #255 SET | Make obj[0] Hidden (disp = 0); Display Dialogue Box [Bank: 1, MsgID: 13]; Teleport obj[255] to (254,204) |
| `ev[02]` | `2 (Map Init)` | Story Flag 98 (bit 128) SET AND Story Flag 95 (bit 128) CLEAR AND Condition Check #23 AND Condition Check #117 AND Temp Event Flag #255 SET | Make obj[0] Hidden (disp = 0); Place Scenery Structure (1); Display Dialogue Box [Bank: 47, MsgID: 255] |
| `ev[03]` | `1 (Action / Talk)` | Story Flag 98 (bit 128) SET AND Story Flag 95 (bit 128) CLEAR | Dismiss Character Dialogue Portrait; Warp Room -> Submap 125 at (40,64) facing East (Right); Reset Camera Tracking (3); Warp to Castle HQ (0, 2, 24); Reset Camera Tracking (0); Open Dialogue Message Window; Warp to Castle HQ (9, 2, 3); Open Dialogue Message Window; Warp to Castle HQ (24, 9, 0); Warp Room -> Submap 1 at (2,84) facing East (Right); Warp Room -> Submap 84 at (2,31); Dismiss Character to Castle Base (34 [Hauser]); Warp Room -> Submap 84 at (54,31); Dismiss Character to Castle Base (15 [Shin]); Warp Room -> Submap 84 at (3,40); Dismiss Character to Castle Base (2 [Flik]); Engine Action #40; Set Combat Battle BGM (20); Recruit Riou (Hero) into Battle Slot 0; Launch Tactical War Battle (128); Engine Action #54; Warp Room -> Submap 54 at (1,8) facing 54; Warp Room -> Submap 54 at (1,32) facing 54; Warp Room -> Submap 3 at (8,3) facing East (Right); Open Dialogue Message Window; Warp Town -> Area 24 Map 8 Submap 0 at (2,103); Engine Action #9; Set Story Milestone Flag 128 (mask 255) |
| `ev[04]` | `128 (Loop)` | Story Flag 98 (bit 128) SET AND Story Flag 95 (bit 128) CLEAR AND Temp Event Flag #1 SET | Warp Room -> Submap 1 at (13,5); Launch Tactical War Battle (1); Launch Tactical War Battle (2) |
| `ev[05]` | `128 (Loop)` | Story Flag 98 (bit 128) SET AND Story Flag 95 (bit 128) CLEAR AND Inventory Holds Item #128 AND Star of Destiny #1 Recruited AND Story Flag 7 (bit 4) SET | Open Shop Menu #5 (Type: 9); Turn obj[9] facing South (Down); Warp Town -> Area 0 Map 1 Submap 0 at (8,1); Engine Action #9; Launch Tactical War Battle (4) |
| `ev[06]` | `128 (Loop)` | Story Flag 98 (bit 128) SET AND Story Flag 95 (bit 128) CLEAR AND Inventory Holds Item #128 AND Star of Destiny #0 Recruited AND Story Flag 7 (bit 4) SET | Launch Tactical War Battle (4) |
| `ev[07]` | `128 (Loop)` | Story Flag 98 (bit 128) SET AND Story Flag 95 (bit 128) CLEAR AND Inventory Holds Item #128 AND Star of Destiny #1 Recruited AND Player Y within Range [7..8] | Open Shop Menu #5 (Type: 10); Turn obj[10] facing South (Down); Warp Town -> Area 0 Map 1 Submap 0 at (8,1); Screen Fade Transition (36, 8, 255) |
| `ev[08]` | `128 (Loop)` | Story Flag 98 (bit 128) SET AND Story Flag 95 (bit 128) CLEAR AND Inventory Holds Item #128 AND Star of Destiny #0 Recruited AND Player Y within Range [7..8] | Launch Tactical War Battle (8) |
| `ev[09]` | `128 (Loop)` | Story Flag 98 (bit 128) SET AND Story Flag 95 (bit 128) CLEAR AND Inventory Holds Item #128 AND Star of Destiny #1 Recruited AND Condition Check #34 AND Temp Event Flag #16 SET | Open Shop Menu #5 (Type: 11); Turn obj[11] facing South (Down); Warp Town -> Area 0 Map 1 Submap 0 at (8,1); Close Dialogue Window; Launch Tactical War Battle (16) |
| `ev[10]` | `128 (Loop)` | Story Flag 98 (bit 128) SET AND Story Flag 95 (bit 128) CLEAR AND Inventory Holds Item #128 AND Star of Destiny #0 Recruited AND Condition Check #34 AND Temp Event Flag #16 SET | Launch Tactical War Battle (16) |
| `ev[11]` | `128 (Loop)` | Story Flag 98 (bit 128) SET AND Story Flag 95 (bit 128) CLEAR AND Inventory Holds Item #128 AND Star of Destiny #1 Recruited AND Condition Check #54 AND Temp Event Flag #32 SET | Open Shop Menu #5 (Type: 14); Turn obj[14] facing South (Down); Warp Town -> Area 0 Map 1 Submap 0 at (8,1); Animate Door Open; Launch Tactical War Battle (32) |
| `ev[12]` | `128 (Loop)` | Story Flag 98 (bit 128) SET AND Story Flag 95 (bit 128) CLEAR AND Inventory Holds Item #128 AND Star of Destiny #0 Recruited AND Condition Check #54 AND Temp Event Flag #32 SET | Launch Tactical War Battle (32) |
| `ev[13]` | `128 (Loop)` | Story Flag 98 (bit 128) SET AND Story Flag 95 (bit 128) CLEAR AND Inventory Holds Item #128 AND Star of Destiny #1 Recruited AND Party Formation Check AND Temp Event Flag #64 SET | Open Shop Menu #5 (Type: 16); Turn obj[16] facing South (Down); Warp Town -> Area 0 Map 1 Submap 0 at (8,1); Dismiss Dialogue Portrait; Launch Tactical War Battle (64) |
| `ev[14]` | `128 (Loop)` | Story Flag 98 (bit 128) SET AND Story Flag 95 (bit 128) CLEAR AND Inventory Holds Item #128 AND Star of Destiny #0 Recruited AND Party Formation Check AND Temp Event Flag #64 SET | Launch Tactical War Battle (64) |
| `ev[15]` | `128 (Loop)` | Player within Box [31..49, 2..20] AND Condition Check #44 AND Story Flag 1 (mask 255) SET | Warp Room -> Submap 1 at (9,1) |
| `ev[16]` | `128 (Loop)` | Player within Box [19..61, 2..70] AND Condition Check #97 AND Story Flag 95 (bit 128) SET AND Story Flag 220 (bit 1) CLEAR | Warp Room -> Submap 2 at (12,9) |
| `ev[17]` | `128 (Loop)` | Player within Box [19..61, 2..70] AND Condition Check #97 AND Story Flag 143 (bit 1) SET | Warp Room -> Submap 2 at (12,9) |
| `ev[18]` | `1 (Action / Talk)` | Player within Box [37..43, 2..19] AND Castle HQ Tier >= Level 9 AND Player X within Range [255..254] | Warp Map Transition (2, 0, 116, 105, 255) |
| `ev[19]` | `1 (Action / Talk)` | Player within Box [19..61, 11..98] AND Story Flag 0 (mask 255) SET | Warp Map Transition (0, 0, 157, 87, 255) |
| `ev[20]` | `2 (Map Init)` | Story Flag 98 (bit 128) SET AND Story Flag 95 (bit 128) SET AND Story Flag 220 (bit 1) CLEAR | Make obj[0] Hidden (disp = 0); Reset Camera Tracking (1); Engine Action #9; Warp Room -> Submap 1 at (11,1) facing 14; Warp Room -> Submap 47 at (255,254) facing 204 |
| `ev[21]` | `2 (Map Init)` | Story Flag 98 (bit 128) SET AND Story Flag 95 (bit 128) SET AND Story Flag 96 (bit 1) CLEAR AND Story Flag 96 (bit 2) CLEAR AND Story Flag 220 (bit 1) CLEAR | Open Dialogue Message Window; Show Dialogue Portrait (255, 254, 204) |
| `ev[22]` | `2 (Map Init)` | Story Flag 98 (bit 128) SET AND Story Flag 95 (bit 128) SET AND Story Flag 96 (bit 1) SET AND Story Flag 96 (bit 2) SET AND Story Flag 220 (bit 1) CLEAR | Open Dialogue Message Window; Show Dialogue Portrait (255, 254, 204) |
| `ev[23]` | `2 (Map Init)` | Story Flag 98 (bit 128) SET AND Story Flag 95 (bit 128) SET AND Story Flag 220 (bit 1) CLEAR AND Condition Check #24 AND Condition Check #117 AND Temp Event Flag #255 SET | Make obj[0] Hidden (disp = 0); Display Dialogue Box [Bank: 1, MsgID: 13]; Teleport obj[255] to (254,204) |
| `ev[24]` | `2 (Map Init)` | Story Flag 98 (bit 128) SET AND Story Flag 95 (bit 128) SET AND Story Flag 220 (bit 1) CLEAR AND Condition Check #23 AND Condition Check #117 AND Temp Event Flag #255 SET | Make obj[1] Hidden (disp = 0); Display Dialogue Box [Bank: 0, MsgID: 13]; Teleport obj[255] to (254,204) |
| `ev[25]` | `2 (Map Init)` | Story Flag 98 (bit 128) SET AND Story Flag 95 (bit 128) SET AND Story Flag 220 (bit 1) CLEAR AND Star of Destiny #0 Recruited AND Story Flag 255 (bit 254) SET | Open Dialogue Message Window; Engine Action #9 |
| `ev[26]` | `2 (Map Init)` | Story Flag 98 (bit 128) SET AND Story Flag 95 (bit 128) SET AND Story Flag 220 (bit 1) CLEAR AND Star of Destiny #0 Recruited AND Player Y within Range [255..254] | Open Dialogue Message Window; Screen Fade Transition (255, 254, 204) |
| `ev[27]` | `2 (Map Init)` | Story Flag 98 (bit 128) SET AND Story Flag 95 (bit 128) SET AND Story Flag 220 (bit 1) CLEAR AND Star of Destiny #0 Recruited AND Condition Check #34 | Open Dialogue Message Window; Close Dialogue Window |
| `ev[28]` | `2 (Map Init)` | Story Flag 98 (bit 128) SET AND Story Flag 95 (bit 128) SET AND Story Flag 220 (bit 1) CLEAR AND Star of Destiny #0 Recruited AND Condition Check #54 | Open Dialogue Message Window; Animate Door Open |
| `ev[29]` | `2 (Map Init)` | Story Flag 98 (bit 128) SET AND Story Flag 95 (bit 128) SET AND Story Flag 96 (bit 1) CLEAR AND Story Flag 96 (bit 2) CLEAR AND Story Flag 220 (bit 1) CLEAR AND Star of Destiny #0 Recruited AND Party Formation Check | Open Dialogue Message Window; Dismiss Dialogue Portrait |
| `ev[30]` | `2 (Map Init)` | Story Flag 98 (bit 128) SET AND Story Flag 95 (bit 128) SET AND Story Flag 96 (bit 1) SET AND Story Flag 96 (bit 2) SET AND Story Flag 220 (bit 1) CLEAR AND Star of Destiny #0 Recruited AND Party Formation Check | Open Dialogue Message Window; Dismiss Dialogue Portrait |
| `ev[31]` | `1 (Action / Talk)` | Story Flag 98 (bit 128) SET AND Story Flag 95 (bit 128) SET AND Story Flag 220 (bit 1) CLEAR AND Target Inspected is obj[8] | Close Dialogue Sub-Window (8); Warp to Castle HQ (0, 255, 254) |
| `ev[32]` | `1 (Action / Talk)` | Story Flag 98 (bit 128) SET AND Story Flag 95 (bit 128) SET AND Story Flag 220 (bit 1) CLEAR AND Target Inspected is obj[9] | Close Dialogue Sub-Window (9); Warp to Castle HQ (1, 255, 254) |
| `ev[33]` | `1 (Action / Talk)` | Story Flag 98 (bit 128) SET AND Story Flag 95 (bit 128) SET AND Story Flag 220 (bit 1) CLEAR AND Target Inspected is obj[10] | Close Dialogue Sub-Window (10); Warp to Castle HQ (2, 255, 254) |
| `ev[34]` | `1 (Action / Talk)` | Story Flag 98 (bit 128) SET AND Story Flag 95 (bit 128) SET AND Story Flag 220 (bit 1) CLEAR AND Target Inspected is obj[11] | Close Dialogue Sub-Window (11); Warp to Castle HQ (3, 255, 254) |
| `ev[35]` | `1 (Action / Talk)` | Story Flag 98 (bit 128) SET AND Story Flag 95 (bit 128) SET AND Story Flag 220 (bit 1) CLEAR AND Condition Check #24 AND Condition Check #117 AND Temp Event Flag #5 SET AND Player Y in Range [255..254] | Close Dialogue Sub-Window (12); Warp to Castle HQ (4, 255, 254) |
| `ev[36]` | `1 (Action / Talk)` | Story Flag 98 (bit 128) SET AND Story Flag 95 (bit 128) SET AND Story Flag 220 (bit 1) CLEAR AND Condition Check #23 AND Condition Check #117 AND Temp Event Flag #5 SET AND Party Holds At Least 25,500 Potch | Close Dialogue Sub-Window (13); Warp to Castle HQ (5, 255, 254) |
| `ev[37]` | `1 (Action / Talk)` | Story Flag 98 (bit 128) SET AND Story Flag 95 (bit 128) SET AND Story Flag 220 (bit 1) CLEAR AND Target Inspected is obj[14] | Close Dialogue Sub-Window (14); Warp to Castle HQ (6, 255, 254) |
| `ev[38]` | `1 (Action / Talk)` | Story Flag 98 (bit 128) SET AND Story Flag 95 (bit 128) SET AND Story Flag 220 (bit 1) CLEAR AND Target Inspected is obj[15] | Close Dialogue Sub-Window (15); Warp to Castle HQ (7, 255, 254) |
| `ev[39]` | `1 (Action / Talk)` | Story Flag 98 (bit 128) SET AND Story Flag 95 (bit 128) SET AND Story Flag 220 (bit 1) CLEAR AND Target Inspected is obj[16] | Close Dialogue Sub-Window (16); Warp to Castle HQ (8, 255, 254) |
| `ev[40]` | `2 (Map Init)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR | Make obj[2] Hidden (disp = 0); Open Dialogue Message Window; Start Boss Battle #86 (BGM: 1); Open Dialogue Message Window; Warp Town -> Area 17 Map 30 Submap 84 at (0,17); Warp Town -> Area 18 Map 33 Submap 84 at (0,18); Warp Town -> Area 15 Map 31 Submap 88 at (43,15); Engine Action #5; Open Dialogue Message Window; Show Dialogue Portrait (2, 16, 29); Engine Action #90; Open Shop Menu #5 (Type: 16); Warp Room -> Submap 2 at (12,38) facing 79; Open Shop Menu #5 (Type: 12); Open Dialogue Message Window; Display Dialogue Box [Bank: 2, MsgID: 13]; Open Save Crystal Menu (MSaveInit); Bytecode Subroutine Return; Open Shop Menu #5 (Type: 13); Warp Room -> Submap 2 at (19,35) facing 81; Open Dialogue Message Window; Display Choice Selection (2, 8); Toggle Random Encounters (85); Open Shop Menu #5 (Type: 8); Open Dialogue Message Window; Reset Camera Tracking (2); Animate Door Open; Launch Tactical War Battle (93); Open Shop Menu #5 (Type: 14); Warp Room -> Submap 2 at (20,24) facing 85; Warp Room -> Submap 2 at (22,23) facing 90; Warp Room -> Submap 2 at (25,40) facing 92; Warp Room -> Submap 2 at (26,44) facing 92; Warp Room -> Submap 2 at (27,42) facing 95; Warp Room -> Submap 2 at (9,45) facing 84; Open Shop Menu #5 (Type: 9); Warp Room -> Submap 2 at (10,44) facing 87; Open Shop Menu #5 (Type: 10); Warp Room -> Submap 2 at (23,28) facing 94; Warp Room -> Submap 2 at (24,26) facing 94; Warp Room -> Submap 2 at (21,32) facing 96; Warp Room -> Submap 37 at (254,47) facing 255 |
| `ev[41]` | `1 (Action / Talk)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR | Close Dialogue Window; Warp to Castle HQ (2, 40, 73); Trigger Character Emotion Effect (24, 17); Warp Room -> Submap 73 at (30,3) facing 18; Warp Town -> Area 3 Map 17 Submap 3 at (72,1); Change Portrait Expression (9); Engine Action #5; Change Portrait Expression (4); Engine Action #5; Pan Camera (1, 30, 24); Display Speaker Name Box (1); Screen Fade Transition (72, 0, 17); Set Combat Battle BGM (30); Engine Action #5; Show Dialogue Portrait (1, 1, 30); Make obj[3] Hidden (disp = 0); Change Portrait Expression (0); Warp to Castle HQ (18, 0, 47); Close Dialogue Sub-Window (15); Warp Room -> Submap 73 at (60,36) facing Up (North); Engine Action #54; Open Dialogue Message Window; Warp Town -> Area 46 Map 3 Submap 18 at (1,3); Change Portrait Expression (1); Teleport obj[101] to (9,15); Set Object Direction (0, 1); Engine Action #120; Full Rest & Healing (Restore HP/MP); Warp Room -> Submap 3 at (5,7) facing 46; Warp Town -> Area 0 Map 40 Submap 12 at (0,0); Make obj[47] Visible (disp = 1); Jump to Bytecode Offset (1, 0); Engine Action #61; Warp Room -> Submap 5 at (0,4) facing 5; Open Dialogue Message Window; Full Rest & Healing (Restore HP/MP); Dismiss Emotion Bubble (61); Open Dialogue Message Window; Open Dialogue Message Window; Launch Tactical War Battle (1); Set Entity Movement Speed (5, 56); Display Choice Selection (0, 2); Warp Town -> Area 1 Map 6 Submap 8 at (255,254); Set Animation Pose (8, 0); Warp Town -> Area 2 Map 1 Submap 2 at (8,255); Set Animation Pose (18, 0); Warp Town -> Area 1 Map 1 Submap 4 at (8,255); Set Animation Pose (17, 0); Warp Town -> Area 3 Map 1 Submap 4 at (8,255); Set Animation Pose (15, 0); Warp Town -> Area 3 Map 1 Submap 0 at (9,255); Walk obj[46] to (3,17); Open Dialogue Message Window; Warp to Castle HQ (18, 0, 47); Set Combat Battle BGM (60); Toggle Random Encounters (1); Engine Action #9; Engine Action #222; Warp Room -> Submap 0 at (222,1) facing 9; Engine Action #222; Warp Town -> Area 53 Map 0 Submap 222 at (2,9); Engine Action #222; Exit to World Map (53, 0, 222); Exit to World Map (9, 222, 8); Engine Action #53; Open Dialogue Message Window; Engine Action #222; Reset Camera Tracking (9); Engine Action #222; Dismiss Dialogue Portrait; Engine Action #53; Open Dialogue Message Window; Engine Action #222; Dismiss Dialogue Portrait; Engine Action #9; Engine Action #222; Warp Map Transition (53, 0, 222, 32, 9); Engine Action #222; Animate Doorway State (53, 0); Engine Action #222; Animate Doorway State (9, 222); Engine Action #128; Engine Action #53; Open Dialogue Message Window; Engine Action #222; Engine Action #128; Engine Action #9; Engine Action #223; Warp Room -> Submap 0 at (223,1) facing 36; Exit to World Map (69, 3, 101); Engine Action #9; Pan Camera (11, 4, 2); Engine Action #250; Teleport Object to Coordinates (113, 101, 9); Animate Door Open; Engine Action #102; Open Dialogue Message Window; Engine Action #117; Warp Room -> Submap 73 at (240,46) facing 10; Make obj[254] Visible (disp = 1); Screen Fade Transition (46, 254, 10); Teleport obj[254] to (10,48); Teleport obj[46] to (9,45); Warp Town -> Area 9 Map 45 Submap 1 at (9,46); Warp Room -> Submap 46 at (8,9) facing 46; Animate Doorway State (9, 46); Engine Action #128; Engine Action #9; Teleport obj[1] to (9,47); Warp Town -> Area 9 Map 47 Submap 4 at (9,47); Warp Map Transition (9, 48, 8, 9, 48); Dismiss Dialogue Portrait; Engine Action #9; Turn obj[32] facing 47; Engine Action #9; Engine Action #143; Warp Room -> Submap 1 at (111,41) facing 5; Engine Action #6; Pan Camera (8, 9, 10); Engine Action #6; Pan Camera (13, 5, 10); Engine Action #6; Warp to Castle HQ (52, 52, 255); Reset Camera Tracking (13); Engine Action #5; Screen Fade Transition (12, 0, 50); Walk obj[255] to (9,13); Engine Action #5; Screen Fade Transition (12, 7, 56); Full Rest & Healing (Restore HP/MP); Screen Fade Transition (13, 5, 10); Show Dialogue Portrait (0, 40, 20) |
| `ev[42]` | `2 (Map Init)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Star of Destiny #0 Recruited AND Player Y within Range [255..254] | Open Dialogue Message Window; Screen Fade Transition (255, 254, 204) |
| `ev[43]` | `2 (Map Init)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Star of Destiny #0 Recruited AND Story Flag 255 (bit 254) SET | Open Dialogue Message Window; Engine Action #9 |
| `ev[44]` | `2 (Map Init)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Star of Destiny #0 Recruited AND Story Flag 23 (bit 4) CLEAR AND Player Y within Range [255..254] | Open Dialogue Message Window; Execute Choice Result (255) |
| `ev[45]` | `2 (Map Init)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Star of Destiny #0 Recruited AND Condition Check #52 | Open Dialogue Message Window; Branch on Choice (255, 254) |
| `ev[46]` | `2 (Map Init)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Star of Destiny #0 Recruited AND Condition Check #54 | Open Dialogue Message Window; Animate Door Open |
| `ev[47]` | `2 (Map Init)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Star of Destiny #0 Recruited AND Condition Check #37 AND Condition Check #23 AND Condition Check #37 AND Player Y within Range [255..254] | Open Dialogue Message Window; Set Story Flag (255, 254) |
| `ev[48]` | `2 (Map Init)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Star of Destiny #0 Recruited AND Condition Check #41 AND Condition Check #23 AND Condition Check #41 AND Player Y within Range [255..254] | Open Dialogue Message Window; Open Dialogue Sub-Window (255) |
| `ev[49]` | `2 (Map Init)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Star of Destiny #0 Recruited AND Character #255 Level >= 254 | Open Dialogue Message Window; Clear Dialogue Sub-Window |
| `ev[50]` | `2 (Map Init)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Star of Destiny #0 Recruited AND Castle HQ Tier >= Level 255 | Open Dialogue Message Window; Fade In from Black (255) |
| `ev[51]` | `2 (Map Init)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Star of Destiny #0 Recruited AND Inventory Holds Item #255 | Open Dialogue Message Window; Fade Out to Black (255) |
| `ev[52]` | `2 (Map Init)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Star of Destiny #0 Recruited AND Condition Check #42 AND Condition Check #23 AND Condition Check #42 AND Player Y within Range [255..254] | Open Dialogue Message Window; Close Dialogue Sub-Window (255) |
| `ev[53]` | `2 (Map Init)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Star of Destiny #0 Recruited AND Party Formation Check | Open Dialogue Message Window; Dismiss Dialogue Portrait |
| `ev[54]` | `2 (Map Init)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Condition Check #23 AND Condition Check #117 AND Temp Event Flag #255 SET | Make obj[1] Hidden (disp = 0); Display Dialogue Box [Bank: 0, MsgID: 13]; Teleport obj[255] to (254,204) |
| `ev[55]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Star of Destiny #0 Recruited AND Story Flag 6 (bit 1) SET | Set Animation Pose (9, 0); Warp to Castle HQ (2, 1, 3); Engine Action #9; Warp to Castle HQ (9, 0, 255) |
| `ev[56]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Star of Destiny #0 Recruited AND Player Y within Range [6..1] | Set Animation Pose (10, 0); Warp to Castle HQ (4, 0, 0); Engine Action #9; Warp to Castle HQ (10, 2, 255) |
| `ev[57]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Star of Destiny #0 Recruited AND Condition Check #52 AND Inventory Holds Item #1 [Medicine] | Set Animation Pose (20, 0); Warp Town -> Area 6 Map 1 Submap 3 at (9,255) |
| `ev[58]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Star of Destiny #0 Recruited AND Condition Check #54 AND Inventory Holds Item #1 [Medicine] | Set Animation Pose (14, 0); Warp Town -> Area 3 Map 0 Submap 3 at (9,3); Animate Door Open; Warp to Castle HQ (255, 254, 204) |
| `ev[59]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Star of Destiny #0 Recruited AND Condition Check #37 AND Condition Check #23 AND Condition Check #37 AND Player Y within Range [6..1] | Set Animation Pose (22, 0); Warp Town -> Area 8 Map 0 Submap 0 at (9,255) |
| `ev[60]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Star of Destiny #0 Recruited AND Condition Check #41 AND Condition Check #23 AND Condition Check #41 AND Player Y within Range [6..1] | Set Animation Pose (23, 0); Warp Town -> Area 8 Map 0 Submap 3 at (9,255) |
| `ev[61]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Star of Destiny #0 Recruited AND Condition Check #42 AND Condition Check #23 AND Condition Check #41 AND Player Y within Range [6..1] | Set Animation Pose (24, 0); Warp Town -> Area 10 Map 0 Submap 3 at (9,255) |
| `ev[62]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Star of Destiny #0 Recruited AND Story Flag 23 (bit 4) CLEAR AND Player Y within Range [6..1] | Set Animation Pose (21, 0); Warp Town -> Area 1 Map 0 Submap 5 at (8,255) |
| `ev[63]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Star of Destiny #0 Recruited AND Character #6 Level >= 1 | Set Animation Pose (25, 0); Warp to Castle HQ (0, 0, 3); Reset Camera Tracking (255) |
| `ev[64]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Star of Destiny #0 Recruited AND Castle HQ Tier >= Level 6 AND Player X within Range [255..254] | Set Animation Pose (26, 0); Warp to Castle HQ (3, 0, 3); Reset Camera Tracking (255) |
| `ev[65]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Star of Destiny #0 Recruited AND Inventory Holds Item #6 [Flaming Arrows] AND Player X within Range [255..254] | Set Animation Pose (27, 0); Warp to Castle HQ (2, 0, 5); Reset Camera Tracking (255) |
| `ev[66]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Star of Destiny #0 Recruited AND Party Formation Check AND Inventory Holds Item #1 [Medicine] | Set Animation Pose (16, 0); Warp Town -> Area 5 Map 0 Submap 1 at (9,255) |
| `ev[67]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Condition Check #23 AND Condition Check #117 AND Temp Event Flag #6 SET AND Player X within Range [255..254] | Set Animation Pose (13, 0); Warp to Castle HQ (1, 1, 6); Reset Camera Tracking (255) |
| `ev[68]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Condition Check #24 AND Condition Check #117 AND Temp Event Flag #6 SET AND Player X within Range [255..254] | Set Animation Pose (12, 0); Warp to Castle HQ (1, 1, 6); Reset Camera Tracking (255) |
| `ev[69]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Player Y within Range [84..85] | Make obj[3] Hidden (disp = 0); Reset Camera Tracking (3); Warp to Castle HQ (18, 3, 3); Change Portrait Expression (3); Warp to Castle HQ (15, 3, 47) |
| `ev[70]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Condition Check #24 AND Condition Check #117 AND Temp Event Flag #2 SET AND Condition Check #79 AND Condition Check #80 | Warp to Castle HQ (12, 3, 255) |
| `ev[71]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Condition Check #23 AND Condition Check #117 AND Temp Event Flag #2 SET AND Condition Check #79 AND Condition Check #80 | Warp to Castle HQ (13, 3, 255) |
| `ev[72]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Player Y within Range [79..80] | Warp to Castle HQ (19, 3, 255) |
| `ev[73]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Star of Destiny #0 Recruited AND Story Flag 2 (bit 84) SET AND Condition Check #85 | Warp to Castle HQ (9, 2, 255) |
| `ev[74]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Star of Destiny #0 Recruited AND Player Y within Range [2..84] AND Condition Check #85 | Warp to Castle HQ (10, 2, 255) |
| `ev[75]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Star of Destiny #0 Recruited AND Party Formation Check AND Player Y within Range [84..85] | Warp to Castle HQ (16, 3, 255) |
| `ev[76]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Star of Destiny #0 Recruited AND Condition Check #52 AND Player Y within Range [84..85] | Warp to Castle HQ (20, 3, 255) |
| `ev[77]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Star of Destiny #0 Recruited AND Condition Check #37 AND Condition Check #23 AND Condition Check #37 AND Player Y within Range [2..84] AND Condition Check #85 | Warp to Castle HQ (22, 3, 255) |
| `ev[78]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Condition Check #24 AND Condition Check #117 AND Temp Event Flag #6 SET AND Player Y within Range [255..254] | Load Sound Bank into Memory (1, 12); Warp Town -> Area 73 Map 30 Submap 72 at (0,12); Engine Action #5; Display Dialogue Box [Bank: 4, MsgID: 6]; Engine Action #6; Warp Town -> Area 30 Map 24 Submap 12 at (1,12); Toggle Random Encounters (2) |
| `ev[79]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Condition Check #23 AND Condition Check #117 AND Temp Event Flag #6 SET AND Player Y within Range [255..254] | Load Sound Bank into Memory (1, 13); Warp Town -> Area 73 Map 30 Submap 72 at (0,13); Engine Action #5; Place Scenery Structure (4); Engine Action #6; Engine Action #6; Warp Town -> Area 30 Map 24 Submap 13 at (1,12); Toggle Random Encounters (2) |
| `ev[80]` | `128 (Loop)` | Star of Destiny #0 Recruited AND Story Flag 3 (bit 220) SET AND Player within Box [4..143, 1..3] AND Condition Check #222 AND Player X within Range [255..254] | Launch Tactical War Battle (128); Close Dialogue Sub-Window (9); Warp Room -> Submap 73 at (20,54) facing South (Down); Engine Action #128; Screen Fade Transition (222, 1, 255) |
| `ev[81]` | `128 (Loop)` | Star of Destiny #0 Recruited AND Story Flag 3 (bit 220) SET AND Player within Box [4..143, 1..3] AND Condition Check #222 AND Player within Box [6..128, 255..254] | Engine Action #5; Engine Action #9; Open Dialogue Message Window; Warp Room -> Submap 37 at (128,255) facing 254 |
| `ev[82]` | `128 (Loop)` | Star of Destiny #1 Recruited AND Story Flag 3 (bit 220) SET AND Player within Box [4..143, 1..3] AND Condition Check #222 AND Player X within Range [255..254] | Screen Fade Transition (222, 1, 255) |
| `ev[83]` | `128 (Loop)` | Star of Destiny #0 Recruited AND Player Y within Range [3..220] AND Player within Box [4..143, 1..3] AND Condition Check #222 AND Player Y within Range [255..254] | Launch Tactical War Battle (128); Close Dialogue Sub-Window (10); Warp Room -> Submap 73 at (20,10) facing 222; Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[84]` | `128 (Loop)` | Star of Destiny #0 Recruited AND Player Y within Range [3..220] AND Player within Box [4..143, 1..3] AND Condition Check #222 AND Player Y within Range [6..128] | Engine Action #5; Screen Fade Transition (2, 1, 30); Toggle Random Encounters (128) |
| `ev[85]` | `128 (Loop)` | Star of Destiny #1 Recruited AND Player Y within Range [3..220] AND Player within Box [4..143, 1..3] AND Condition Check #222 AND Player Y within Range [255..254] | Screen Fade Transition (222, 2, 255) |
| `ev[86]` | `128 (Loop)` | Condition Check #23 AND Story Flag 2 (bit 16) CLEAR AND Always Passes (Unconditional) AND Story Flag 3 (bit 220) CLEAR AND Player within Box [4..143, 1..3] AND Condition Check #222 AND Story Flag 255 (bit 254) CLEAR | Launch Tactical War Battle (128); Load Sound Bank into Memory (1, 21); Engine Action #9; Close Dialogue Sub-Window (21); Warp Room -> Submap 73 at (20,54) facing South (Down); Engine Action #128; Load Sound Bank into Memory (0, 21); Screen Fade Transition (222, 4, 255) |
| `ev[87]` | `128 (Loop)` | Condition Check #23 AND Story Flag 2 (bit 16) CLEAR AND Always Passes (Unconditional) AND Story Flag 3 (bit 220) CLEAR AND Player within Box [4..143, 1..3] AND Condition Check #222 AND Story Flag 6 (bit 128) CLEAR | Engine Action #5; Execute Choice Result (2); Warp Room -> Submap 5 at (1,0) facing 5; Engine Action #5; Warp to Castle HQ (1, 5, 5); Warp Room -> Submap 30 at (5,21) facing Up (North); Warp Room -> Submap 5 at (1,0) facing 5; Engine Action #5; Warp to Castle HQ (1, 5, 5); Warp Room -> Submap 30 at (5,21) facing 6; Warp Room -> Submap 1 at (30,37) facing 128 |
| `ev[88]` | `128 (Loop)` | Star of Destiny #1 Recruited AND Story Flag 3 (bit 220) CLEAR AND Player within Box [4..143, 1..3] AND Condition Check #222 AND Story Flag 255 (bit 254) CLEAR | Screen Fade Transition (222, 4, 255) |
| `ev[89]` | `128 (Loop)` | Condition Check #24 AND Story Flag 2 (bit 3) CLEAR AND Condition Check #220 AND Player within Box [4..143, 1..3] AND Condition Check #222 AND Story Flag 255 (bit 254) CLEAR | Screen Fade Transition (222, 4, 255) |
| `ev[90]` | `128 (Loop)` | Condition Check #23 AND Condition Check #37 AND Player Y within Range [16..0] AND Condition Check #37 AND Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Story Flag 222 (bit 8) SET | Launch Tactical War Battle (128); Close Dialogue Sub-Window (22); Warp Room -> Submap 73 at (20,54) facing South (Down); Engine Action #128; Screen Fade Transition (222, 8, 255) |
| `ev[91]` | `128 (Loop)` | Star of Destiny #0 Recruited AND Condition Check #37 AND Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Story Flag 222 (bit 8) SET AND Inventory Holds Item #128 | Engine Action #5; Set Story Flag (3, 1); Dismiss Emotion Bubble (37); Engine Action #128 |
| `ev[92]` | `128 (Loop)` | Star of Destiny #1 Recruited AND Condition Check #37 AND Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Story Flag 222 (bit 8) SET | Screen Fade Transition (222, 8, 255) |
| `ev[93]` | `128 (Loop)` | Condition Check #24 AND Condition Check #37 AND Player Y within Range [3..220] AND Player within Box [4..143, 1..3] AND Condition Check #222 AND Temp Event Flag #255 CLEAR | Screen Fade Transition (222, 8, 255) |
| `ev[94]` | `128 (Loop)` | Condition Check #23 AND Condition Check #41 AND Player Y within Range [16..0] AND Condition Check #41 AND Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Story Flag 222 (bit 16) SET | Launch Tactical War Battle (128); Close Dialogue Sub-Window (23); Warp Room -> Submap 73 at (20,54) facing South (Down); Engine Action #128; Screen Fade Transition (222, 16, 255) |
| `ev[95]` | `128 (Loop)` | Condition Check #23 AND Condition Check #41 AND Player Y within Range [16..0] AND Condition Check #41 AND Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Story Flag 222 (bit 16) SET AND Inventory Holds Item #128 | Engine Action #5; Open Dialogue Sub-Window (3); Warp Room -> Submap 36 at (64,37) facing 128 |
| `ev[96]` | `128 (Loop)` | Condition Check #23 AND Condition Check #41 AND Player Y within Range [16..0] AND Condition Check #41 AND Star of Destiny #0 Recruited AND Condition Check #42 AND Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Story Flag 222 (bit 16) SET AND Inventory Holds Item #64 [Recipe #33] | Engine Action #5; Close Dialogue Sub-Window (3); Warp Room -> Submap 37 at (64,255) facing 254 |
| `ev[97]` | `128 (Loop)` | Star of Destiny #1 Recruited AND Condition Check #41 AND Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Story Flag 222 (bit 16) SET | Screen Fade Transition (222, 16, 255) |
| `ev[98]` | `128 (Loop)` | Condition Check #24 AND Condition Check #41 AND Player Y within Range [3..220] AND Player within Box [4..143, 1..3] AND Condition Check #222 AND Star of Destiny #255 Recruited | Screen Fade Transition (222, 16, 255) |
| `ev[99]` | `128 (Loop)` | Star of Destiny #0 Recruited AND Condition Check #54 AND Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Story Flag 222 (bit 32) SET | Launch Tactical War Battle (128); Close Dialogue Sub-Window (14); Warp Room -> Submap 73 at (20,54) facing South (Down); Engine Action #128; Screen Fade Transition (222, 32, 255) |
| `ev[100]` | `128 (Loop)` | Star of Destiny #0 Recruited AND Condition Check #54 AND Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Story Flag 222 (bit 32) SET AND Inventory Holds Item #128 | Engine Action #5; Animate Door Open; Engine Action #6; Warp to Castle HQ (6, 3, 30); Toggle Random Encounters (128) |
| `ev[101]` | `128 (Loop)` | Star of Destiny #1 Recruited AND Condition Check #54 AND Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Story Flag 222 (bit 32) SET | Screen Fade Transition (222, 32, 255) |
| `ev[102]` | `128 (Loop)` | Star of Destiny #0 Recruited AND Character #3 Level >= 220 AND Player within Box [4..143, 1..3] AND Condition Check #222 AND Condition Check #64 | Engine Action #5; Clear Dialogue Sub-Window; Engine Action #6; Warp Room -> Submap 1 at (30,24) facing 25; Warp Room -> Submap 73 at (20,10) facing 222; Animate Doorway State (255, 254) |
| `ev[103]` | `128 (Loop)` | Star of Destiny #1 Recruited AND Character #3 Level >= 220 AND Player within Box [4..143, 1..3] AND Condition Check #222 AND Condition Check #64 | Screen Fade Transition (222, 64, 255) |
| `ev[104]` | `128 (Loop)` | Star of Destiny #0 Recruited AND Castle HQ Tier >= Level 3 AND Condition Check #220 AND Player within Box [4..143, 1..3] AND Condition Check #222 AND Condition Check #128 | Close Dialogue Sub-Window (26); Warp Room -> Submap 73 at (20,10) facing 222; Engine Action #128 |
| `ev[105]` | `128 (Loop)` | Star of Destiny #1 Recruited AND Castle HQ Tier >= Level 3 AND Condition Check #220 AND Player within Box [4..143, 1..3] AND Condition Check #222 AND Condition Check #128 | Screen Fade Transition (222, 128, 255) |
| `ev[106]` | `128 (Loop)` | Star of Destiny #0 Recruited AND Inventory Holds Item #3 [Antitoxin] AND Condition Check #220 AND Player within Box [4..143, 1..3] AND Condition Check #223 AND Player X within Range [255..254] | Launch Tactical War Battle (128); Close Dialogue Sub-Window (27); Warp Room -> Submap 73 at (20,54) facing South (Down); Engine Action #128; Screen Fade Transition (223, 1, 255) |
| `ev[107]` | `128 (Loop)` | Star of Destiny #0 Recruited AND Inventory Holds Item #3 [Antitoxin] AND Condition Check #220 AND Player within Box [4..143, 1..3] AND Condition Check #223 AND Player within Box [6..128, 255..254] | Engine Action #5; Fade Out to Black (6); Warp Town -> Area 30 Map 37 Submap 128 at (255,254) |
| `ev[108]` | `128 (Loop)` | Star of Destiny #1 Recruited AND Inventory Holds Item #3 [Antitoxin] AND Condition Check #220 AND Player within Box [4..143, 1..3] AND Condition Check #223 AND Player X within Range [255..254] | Screen Fade Transition (223, 1, 255) |
| `ev[109]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Inventory Holds Item #4 [Throat Drops] | Load Sound Bank into Memory (1, 17); Execute Choice Result (5); Change Portrait Expression (3); Open Dialogue Message Window; Engine Action #5; Branch on Choice (0, 0); Engine Action #5; Branch on Choice (30, 5); Change Portrait Expression (3); Open Dialogue Message Window; Engine Action #5; Branch on Choice (0, 0); Engine Action #5; Branch on Choice (30, 5); Change Portrait Expression (6); Warp Town -> Area 5 Map 5 Submap 6 at (2,30); Set Combat Battle BGM (20); Load Sound Bank into Memory (0, 17) |
| `ev[110]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Inventory Holds Item #4 [Throat Drops] | Engine Action #5; Display Speaker Name Box (4); Engine Action #5; Warp to Castle HQ (2, 1, 0); Engine Action #5; Branch on Choice (2, 2); Dismiss Emotion Bubble (73); Branch on Choice (255, 254) |
| `ev[111]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Inventory Holds Item #4 [Throat Drops] | Engine Action #5; Show Dialogue Portrait (3, 0, 5); Engine Action #40; Warp Room -> Submap 5 at (30,2) facing South (Down); Engine Action #5; Engine Action #40; Warp Room -> Submap 5 at (30,30) facing 255 |
| `ev[112]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Inventory Holds Item #4 [Throat Drops] AND Condition Check #24 AND Condition Check #117 AND Temp Event Flag #255 SET | Load Sound Bank into Memory (1, 12); Execute Choice Result (5); Display Dialogue Box [Bank: 2, MsgID: 0]; Engine Action #5; Branch on Choice (0, 0); Engine Action #5; Branch on Choice (30, 72); Open Dialogue Message Window; Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[113]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Inventory Holds Item #4 [Throat Drops] AND Condition Check #23 AND Condition Check #117 AND Temp Event Flag #255 SET | Load Sound Bank into Memory (1, 13); Execute Choice Result (5); Place Scenery Structure (2); Open Dialogue Message Window; Engine Action #5; Dismiss Emotion Bubble (0); Open Dialogue Message Window; Engine Action #5; Dismiss Emotion Bubble (30); Load Sound Bank into Memory (0, 13) |
| `ev[114]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Inventory Holds Item #4 [Throat Drops] | Engine Action #5; Display Choice Selection (3, 0); Engine Action #5; Dismiss Emotion Bubble (0); Open Dialogue Message Window; Engine Action #5; Dismiss Emotion Bubble (30) |
| `ev[115]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Inventory Holds Item #4 [Throat Drops] | Engine Action #5; Reset Camera Tracking (3); Open Dialogue Message Window; Engine Action #5; Trigger Character Emotion Effect (0, 0); Dismiss Emotion Bubble (5); Reset Camera Tracking (5); Recruit Riou (Hero) into Battle Slot 0; Engine Action #5; Walk obj[30] to (5,8); Warp to Castle HQ (0, 5, 70); Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (5); Reset Camera Tracking (5); Walk obj[1] to (0,5); Trigger Character Emotion Effect (30, 255) |
| `ev[116]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Inventory Holds Item #4 [Throat Drops] AND Star of Destiny #0 Recruited AND Condition Check #54 | Engine Action #5; Animate Door Open; Exit to World Map (5, 0, 2); Warp Town -> Area 2 Map 1 Submap 2 at (3,2); Dismiss Emotion Bubble (5); Animate Door Open; Engine Action #6; Warp to Castle HQ (5, 5, 6); Warp to Castle HQ (5, 5, 30) |
| `ev[117]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Inventory Holds Item #4 [Throat Drops] AND Star of Destiny #0 Recruited AND Condition Check #52 | Engine Action #5; Branch on Choice (0, 0); Engine Action #5; Dismiss Emotion Bubble (3); Open Dialogue Message Window; Engine Action #5; Dismiss Emotion Bubble (30) |
| `ev[118]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Inventory Holds Item #4 [Throat Drops] AND Star of Destiny #0 Recruited AND Condition Check #37 AND Condition Check #23 AND Condition Check #37 AND Player Y within Range [255..254] | Engine Action #5; Set Story Flag (6, 2); Engine Action #5; Branch on Choice (1, 0); Engine Action #5; Branch on Choice (3, 0); Dismiss Emotion Bubble (73); Branch on Choice (255, 254) |
| `ev[119]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Inventory Holds Item #4 [Throat Drops] AND Star of Destiny #0 Recruited AND Character #16 Level >= 0 AND Castle HQ Tier >= Level 255 | Make obj[72] Hidden (disp = 0); Warp Room -> Submap 21 at (72,1) facing 26; Execute Choice Result (47); Set Entity Movement Speed (2, 5); Clear Dialogue Sub-Window; Warp to Castle HQ (0, 5, 30); Warp Room -> Submap 5 at (30,30) facing 255; Engine Action #5; Fade In from Black (5); Dismiss Emotion Bubble (2); Open Dialogue Message Window; Engine Action #5; Dismiss Emotion Bubble (1); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Walk obj[46] to (72,0); Clear Dialogue Sub-Window; Load Sound Bank into Memory (0, 26); Teleport obj[255] to (254,204) |
| `ev[120]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Inventory Holds Item #4 [Throat Drops] AND Star of Destiny #0 Recruited AND Inventory Holds Item #255 | Engine Action #5; Fade Out to Black (6); Warp Town -> Area 5 Map 10 Submap 6 at (2,5); Dismiss Emotion Bubble (30); Engine Action #5; Fade Out to Black (2); Open Dialogue Message Window; Engine Action #5; Screen Fade Transition (1, 0, 5); Screen Fade Transition (3, 0, 5); Screen Fade Transition (1, 0, 5); Screen Fade Transition (30, 255, 254) |
| `ev[121]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Inventory Holds Item #4 [Throat Drops] AND Star of Destiny #0 Recruited AND Story Flag 255 (bit 254) SET | Load Sound Bank into Memory (1, 9); Execute Choice Result (5); Engine Action #9; Warp Town -> Area 0 Map 5 Submap 30 at (0,0); Engine Action #5; Dismiss Emotion Bubble (30); Load Sound Bank into Memory (0, 9) |
| `ev[122]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Inventory Holds Item #4 [Throat Drops] AND Star of Destiny #0 Recruited AND Player Y within Range [255..254] | Set Combat Battle BGM (20); Load Sound Bank into Memory (1, 10); Execute Choice Result (5); Screen Fade Transition (2, 0, 5); Branch on Choice (1, 0); Engine Action #5; Branch on Choice (2, 0); Engine Action #5; Branch on Choice (0, 0); Engine Action #5; Branch on Choice (30, 72); Open Dialogue Message Window; Screen Fade Transition (255, 254, 204) |
| `ev[123]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Inventory Holds Item #4 [Throat Drops] AND Star of Destiny #0 Recruited AND Condition Check #41 AND Condition Check #23 AND Condition Check #41 AND Player Y within Range [255..254] | Engine Action #5; Open Dialogue Sub-Window (6); Warp Town -> Area 5 Map 30 Submap 30 at (5,23); Engine Action #6; Warp Town -> Area 5 Map 30 Submap 30 at (255,254) |
| `ev[124]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Inventory Holds Item #4 [Throat Drops] AND Star of Destiny #0 Recruited AND Condition Check #42 AND Condition Check #23 AND Condition Check #42 AND Player Y within Range [255..254] | Engine Action #5; Close Dialogue Sub-Window (5); Screen Fade Transition (6, 1, 6); Warp Room -> Submap 5 at (24,5) facing 10; Engine Action #6; Warp Room -> Submap 1 at (30,255) facing 254 |
| `ev[125]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Inventory Holds Item #4 [Throat Drops] AND Star of Destiny #0 Recruited AND Story Flag 23 (bit 4) CLEAR AND Player Y within Range [255..254] | Load Sound Bank into Memory (1, 21); Engine Action #9; Engine Action #5; Execute Choice Result (2); Warp Room -> Submap 10 at (1,0) facing 5; Screen Fade Transition (30, 5, 21); Warp Town -> Area 0 Map 5 Submap 10 at (1,0); Engine Action #5; Screen Fade Transition (30, 5, 21); Warp to Castle HQ (2, 5, 10); Warp Room -> Submap 5 at (10,30) facing 5; Execute Choice Result (3); Open Dialogue Message Window; Engine Action #5; Screen Fade Transition (1, 0, 5); Screen Fade Transition (30, 5, 21); Warp Town -> Area 1 Map 5 Submap 10 at (1,0); Engine Action #5; Screen Fade Transition (30, 72, 0); Execute Choice Result (255) |
| `ev[126]` | `1 (Action / Talk)` | Target Inspected is obj[28] | Open Dialogue Sub-Window (2); Open Dialogue Message Window |
| `ev[127]` | `1 (Action / Talk)` | Target Inspected is obj[29] | Open Dialogue Sub-Window (2); Warp Room -> Submap 254 at (204,204) facing 204 |

---



## Location Map: `vj02`

- **Master Map Container**: `vj02.json`
- **Submap Layer Files**: vj02_00.json, vj02_01.json, vj02_02.json, vj02_03.json, vj02_04.json, vj02_05.json, vj02_06.json, vj02_07.json, vj02_08.json
- **Collision Grid Files**: vj02_map_00.json
- **Sprite Animation Bundles**: vj02_00_obj.json
- **Submap Room Count**: 3

### Submap Layer `vj02_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `5`)
- **Entity Count (`okaz`)**: `33` Objects | **Script Count (`evkaz`)**: `68` Scripts

#### Complete Physical Entity Inventory (33 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 159** | `159` | `(116, 83)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | Prop / Scenery | **Prop ID 33183** | `33183` | `(116, 83)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | Prop / Scenery | **Prop ID 33183** | `33183` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | NPC / Actor | **Futch** | `101` | `(116, 108)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[04]` | Prop / Scenery | **Prop ID 33183** | `33183` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | NPC / Actor | **Fitcher** | `15` | `(116, 111)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[06]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(105, 54)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(125, 54)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Trigger / Hitbox | **Hitbox Zone (4x3)** | `0` | `(160, 140)` | `3x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Trigger / Hitbox | **Hitbox Zone (4x3)** | `0` | `(163, 140)` | `3x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Trigger / Hitbox | **Hitbox Zone (4x3)** | `0` | `(158, 138)` | `3x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Trigger / Hitbox | **Hitbox Zone (4x3)** | `0` | `(58, 196)` | `3x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | Trigger / Hitbox | **Hitbox Zone (4x3)** | `0` | `(61, 196)` | `3x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | Trigger / Hitbox | **Hitbox Zone (4x3)** | `0` | `(48, 194)` | `3x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | Trigger / Hitbox | **Hitbox Zone (4x3)** | `0` | `(51, 194)` | `3x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[15]` | Trigger / Hitbox | **Hitbox Zone (4x3)** | `0` | `(46, 196)` | `3x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[16]` | Trigger / Hitbox | **Hitbox Zone (4x3)** | `0` | `(49, 196)` | `3x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[17]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(78, 195)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[18]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(80, 195)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[19]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(132, 139)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[20]` | Trigger / Hitbox | **Hitbox Zone (9x2)** | `0` | `(112, 53)` | `8x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[21]` | NPC / Actor | **Actor ID 64615** | `64615` | `(36, 67)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[22]` | NPC / Actor | **Actor ID 64615** | `64615` | `(33, 69)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[23]` | NPC / Actor | **Actor ID 64615** | `64615` | `(39, 69)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[24]` | Prop / Scenery | **Prop ID 64613** | `64613` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[25]` | Prop / Scenery | **Prop ID 64613** | `64613` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[26]` | Prop / Scenery | **Prop ID 64613** | `64613` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[27]` | Prop / Scenery | **Prop ID 64616** | `64616` | `(32, 64)` | `0x0` | Frame 17 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[28]` | Prop / Scenery | **Prop ID 64616** | `64616` | `(39, 68)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[29]` | Prop / Scenery | **Prop ID 64616** | `64616` | `(38, 61)` | `0x0` | Frame 10 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[30]` | Trigger / Hitbox | **Hitbox Zone (3x5)** | `0` | `(31, 61)` | `2x4` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[31]` | Trigger / Hitbox | **Hitbox Zone (6x3)** | `0` | `(38, 67)` | `5x2` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[32]` | Trigger / Hitbox | **Hitbox Zone (6x2)** | `0` | `(37, 60)` | `5x1` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 159)**: Positioned at tile `(116, 83)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Prop: Object 33183)**: Environmental world dressing prop placed at tile `(116, 83)`. Solid collision is set to `0`.
- **`obj[02]` (Prop: Object 33183)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[03]` (Futch)**: Positioned at tile `(116, 108)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Prop: Object 33183)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[05]` (Fitcher)**: Positioned at tile `(116, 111)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[06]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(105, 54)` to `(107, 56)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[07]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(125, 54)` to `(127, 56)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[08]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `3` tiles high from `(160, 140)` to `(163, 142)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[09]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `3` tiles high from `(163, 140)` to `(166, 142)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[10]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `3` tiles high from `(158, 138)` to `(161, 140)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[11]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `3` tiles high from `(58, 196)` to `(61, 198)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[12]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `3` tiles high from `(61, 196)` to `(64, 198)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[13]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `3` tiles high from `(48, 194)` to `(51, 196)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[14]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `3` tiles high from `(51, 194)` to `(54, 196)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[15]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `3` tiles high from `(46, 196)` to `(49, 198)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[16]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `3` tiles high from `(49, 196)` to `(52, 198)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[17]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(78, 195)` to `(80, 196)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[18]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(80, 195)` to `(82, 196)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[19]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(132, 139)` to `(134, 140)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[20]` (Hitbox Zone)**: Bounding trigger area covering `9` tiles wide by `2` tiles high from `(112, 53)` to `(120, 54)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[21]` (Object 64615)**: Positioned at tile `(36, 67)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[22]` (Object 64615)**: Positioned at tile `(33, 69)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[23]` (Object 64615)**: Positioned at tile `(39, 69)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[24]` (Prop: Object 64613)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[25]` (Prop: Object 64613)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[26]` (Prop: Object 64613)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[27]` (Prop: Object 64616)**: Environmental world dressing prop placed at tile `(32, 64)`. Solid collision is set to `128`.
- **`obj[28]` (Prop: Object 64616)**: Environmental world dressing prop placed at tile `(39, 68)`. Solid collision is set to `128`.
- **`obj[29]` (Prop: Object 64616)**: Environmental world dressing prop placed at tile `(38, 61)`. Solid collision is set to `128`.
- **`obj[30]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `5` tiles high from `(31, 61)` to `(33, 65)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[31]` (Hitbox Zone)**: Bounding trigger area covering `6` tiles wide by `3` tiles high from `(38, 67)` to `(43, 69)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[32]` (Hitbox Zone)**: Bounding trigger area covering `6` tiles wide by `2` tiles high from `(37, 60)` to `(42, 61)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (68 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Always Passes (Unconditional) | Animate Door obj[9] (State: 1); Open Dialogue Message Window; Engine Action #116; Teleport Object to Coordinates (255, 254, 204) |
| `ev[01]` | `2 (Map Init)` | Story Flag 95 (bit 128) SET AND Story Flag 96 (bit 1) CLEAR AND Temp Event Flag #1 SET | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[02]` | `2 (Map Init)` | Story Flag 95 (bit 128) SET AND Story Flag 96 (bit 1) CLEAR AND Inventory Holds Item #4 [Throat Drops] AND Temp Event Flag #8 SET | Make obj[89] Hidden (disp = 0); Engine Action #9; Warp Town -> Area 0 Map 0 Submap 9 at (1,8); Teleport obj[255] to (254,204) |
| `ev[03]` | `128 (Loop)` | Story Flag 95 (bit 128) SET AND Story Flag 96 (bit 1) CLEAR AND Inventory Holds Item #1 [Medicine] AND Temp Event Flag #2 SET AND Inventory Holds Item #128 | Warp Room -> Submap 0 at (15,21); Toggle Random Encounters (128) |
| `ev[04]` | `1 (Action / Talk)` | Story Flag 95 (bit 128) SET AND Story Flag 96 (bit 1) CLEAR AND Player within Box [104..127, 2..90] AND Condition Check #100 AND Temp Event Flag #1 SET | Set Render Priority (pri) (0, 116); Make Object Hidden (disp = 0) (8); Warp to Castle HQ (0, 1, 36); Warp Room -> Submap 128 at (255,254) facing 204 |
| `ev[05]` | `1 (Action / Talk)` | Story Flag 95 (bit 128) SET AND Story Flag 96 (bit 1) CLEAR AND Inventory Holds Item #1 [Medicine] AND Temp Event Flag #2 SET AND Star of Destiny #1 Recruited AND Party Formation Check | Return to Previous Memory Map (1); Show Dialogue Portrait (36, 2, 255) |
| `ev[06]` | `1 (Action / Talk)` | Story Flag 95 (bit 128) SET AND Story Flag 96 (bit 1) CLEAR AND Inventory Holds Item #1 [Medicine] AND Temp Event Flag #2 SET AND Star of Destiny #0 Recruited AND Party Formation Check | Return to Previous Memory Map (0); Launch Tactical War Battle (2) |
| `ev[07]` | `1 (Action / Talk)` | Story Flag 95 (bit 128) SET AND Story Flag 96 (bit 1) CLEAR AND Inventory Holds Item #2 [Mega Medicine] AND Temp Event Flag #4 SET | Make obj[0] Hidden (disp = 0); Warp Room -> Submap 2 at (0,3) facing South (Down); Exit to World Map (0, 6, 0); Engine Action #5; Teleport obj[49] to (6,5); Warp Room -> Submap 5 at (3,3) facing West (Left); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Warp Town -> Area 4 Map 5 Submap 0 at (2,3); Exit to World Map (1, 0, 30); Engine Action #5; Warp to Castle HQ (4, 5, 2); Exit to World Map (1, 0, 30); Engine Action #5; Exit to World Map (4, 5, 0); Warp Town -> Area 2 Map 3 Submap 1 at (0,30); Engine Action #5; Engine Action #6; Exit to World Map (5, 0, 4); Warp to Castle HQ (2, 1, 0); Dismiss Emotion Bubble (255); Engine Action #5; Engine Action #5; Exit to World Map (5, 0, 4); Warp Town -> Area 2 Map 1 Submap 0 at (30,255); Walk obj[24] to (8,0); Warp to Castle HQ (101, 9, 9); Set Combat Battle BGM (60); Engine Action #54; Open Dialogue Message Window; Engine Action #128; Launch Tactical War Battle (4); Jump to Bytecode Offset (9, 14); Engine Action #83; Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[08]` | `1 (Action / Talk)` | Story Flag 95 (bit 128) SET AND Story Flag 96 (bit 1) CLEAR AND Inventory Holds Item #4 [Throat Drops] AND Temp Event Flag #8 SET | Set Combat Battle BGM (10); Close Dialogue Sub-Window (8); Open Dialogue Message Window; Exit to World Map (101, 9, 9); Set Combat Battle BGM (30); Set Object Direction (0, 0); Teleport Object to Coordinates (73, 30, 89); Engine Action #9; Warp Town -> Area 1 Map 36 Submap 8 at (255,254) |
| `ev[09]` | `1 (Action / Talk)` | Story Flag 95 (bit 128) SET AND Story Flag 96 (bit 1) CLEAR AND Inventory Holds Item #8 [Fire Wall] AND Temp Event Flag #16 SET AND Star of Destiny #1 Recruited AND Party Formation Check | Jump to Bytecode Offset (1, 0); Open Dialogue Message Window; Close Dialogue Window; Set Render Priority (pri) (11, 116); Engine Action #88; Reset Camera Tracking (43); Warp Room -> Submap 55 at (1,118) facing 91; Reset Camera Tracking (3); Warp Room -> Submap 36 at (16,255) facing 254 |
| `ev[10]` | `1 (Action / Talk)` | Story Flag 95 (bit 128) SET AND Story Flag 96 (bit 1) CLEAR AND Inventory Holds Item #8 [Fire Wall] AND Temp Event Flag #16 SET AND Star of Destiny #0 Recruited AND Party Formation Check | Jump to Bytecode Offset (1, 0); Open Dialogue Message Window; Close Dialogue Window; Open Dialogue Message Window; Place Scenery Structure (49); Warp Town -> Area 55 Map 11 Submap 116 at (88,8); Set Render Priority (pri) (13, 118); Make Object Visible (disp = 1) (9); Walk obj[3] to (13,1); Launch Tactical War Battle (16) |
| `ev[11]` | `128 (Loop)` | Story Flag 95 (bit 128) SET AND Story Flag 96 (bit 1) CLEAR AND Inventory Holds Item #8 [Fire Wall] AND Temp Event Flag #64 SET | Engine Action #44; Warp to Castle HQ (0, 0, 73); Trigger Character Emotion Effect (5, 0); Exit to World Map (4, 2, 2); Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (36); Animate Doorway State (255, 254) |
| `ev[12]` | `1 (Action / Talk)` | Story Flag 95 (bit 128) SET AND Story Flag 96 (bit 1) CLEAR AND Inventory Holds Item #16 [Revenge Earth] AND Temp Event Flag #32 SET | Engine Action #5; Open Dialogue Message Window; Warp to Castle HQ (2, 1, 0); Dismiss Emotion Bubble (45); Close Dialogue Sub-Window (11); Open Dialogue Message Window; Engine Action #5; Engine Action #89; Engine Action #9; Warp Town -> Area 2 Map 73 Submap 60 at (89,9); Warp Town -> Area 3 Map 24 Submap 8 at (0,6); Close Dialogue Sub-Window (11); Open Dialogue Message Window; Pan Camera (89, 9, 2); Exit to World Map (24, 8, 0); Reset Camera Tracking (89); Engine Action #9; Warp Town -> Area 3 Map 73 Submap 60 at (24,11); Open Dialogue Message Window; Engine Action #9; Make obj[89] Hidden (disp = 0); Display Dialogue Box [Bank: 2, MsgID: 15]; Set Character Quest Milestone (11, 12); Warp Room -> Submap 0 at (12,47) facing 73; Trigger Character Emotion Effect (89, 12); Warp Town -> Area 16 Map 24 Submap 8 at (0,10); Engine Action #89; Engine Action #9; Warp Town -> Area 5 Map 73 Submap 40 at (101,0); Engine Action #177; Set Combat Battle BGM (40); Engine Action #89; Engine Action #9; Warp Town -> Area 6 Map 90 Submap 9 at (4,5); Dismiss Dialogue Portrait; Warp Town -> Area 4 Map 4 Submap 16 at (1,30); Engine Action #89; Engine Action #9; Warp Town -> Area 7 Map 36 Submap 32 at (54,1); Engine Action #128; Close Dialogue Sub-Window (11); Open Dialogue Message Window; Display Dialogue Box [Bank: 89, MsgID: 9]; Warp Town -> Area 8 Map 106 Submap 9 at (8,24); Reset Camera Tracking (0); Place Scenery Structure (73); Branch on Choice (89, 12); Warp Town -> Area 17 Map 24 Submap 11 at (0,14); Set Combat Battle BGM (60); Make obj[3] Hidden (disp = 0); Close Dialogue Window; Open Dialogue Message Window; Open Dialogue Message Window; Close Dialogue Window; Warp Room -> Submap 47 at (89,9) facing Up (North); Engine Action #9; Close Dialogue Sub-Window (8); Open Dialogue Message Window; Show Dialogue Portrait (5, 11, 2); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp Room -> Submap 5 at (5,30) facing 24; Close Dialogue Window; Open Dialogue Message Window; Dismiss Dialogue Portrait; Set Combat Battle BGM (120); Engine Action #89; Engine Action #9; Warp Town -> Area 10 Map 73 Submap 60 at (89,9); Warp Town -> Area 11 Map 90 Submap 9 at (4,3); Change Portrait Expression (3); Dismiss Emotion Bubble (89); Engine Action #9; Warp Town -> Area 12 Map 73 Submap 30 at (101,0); Engine Action #180; Set Combat Battle BGM (30); Engine Action #89; Engine Action #9; Warp Town -> Area 13 Map 106 Submap 9 at (8,24); Reset Camera Tracking (0); Change Portrait Expression (46); Engine Action #89; Screen Fade Transition (2, 14, 106); Reset Camera Tracking (10); Warp Room -> Submap 0 at (8,0) facing 10; Teleport obj[101] to (9,9); Set Combat Battle BGM (30); Engine Action #39; Return Warp to Castle Base (9, 96); Warp Room -> Submap 0 at (0,101) facing 101; Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[13]` | `128 (Loop)` | Story Flag 95 (bit 128) SET AND Story Flag 96 (bit 1) CLEAR AND Inventory Holds Item #32 [Drinking Set] AND Temp Event Flag #128 SET AND Star of Destiny #1 Recruited AND Party Formation Check | Engine Action #5; Warp Room -> Submap 7 at (1,1) facing 30; Close Dialogue Sub-Window (1); Open Dialogue Message Window; Close Dialogue Window; Launch Tactical War Battle (128) |
| `ev[14]` | `128 (Loop)` | Story Flag 95 (bit 128) SET AND Story Flag 96 (bit 1) CLEAR AND Inventory Holds Item #32 [Drinking Set] AND Temp Event Flag #128 SET AND Star of Destiny #0 Recruited AND Party Formation Check | Engine Action #5; Place Scenery Structure (4); Pan Camera (1, 1, 30); Close Dialogue Sub-Window (13); Open Dialogue Message Window; Close Dialogue Window; Launch Tactical War Battle (128) |
| `ev[15]` | `1 (Action / Talk)` | Story Flag 96 (bit 1) SET AND Target Inspected is obj[8] | Close Dialogue Sub-Window (8); Warp Town -> Area 0 Map 255 Submap 254 at (204,204) |
| `ev[16]` | `1 (Action / Talk)` | Story Flag 96 (bit 1) SET AND Target Inspected is obj[11] | Close Dialogue Sub-Window (11); Warp Town -> Area 1 Map 255 Submap 254 at (204,204) |
| `ev[17]` | `1 (Action / Talk)` | Story Flag 96 (bit 1) SET AND Target Inspected is obj[13] | Close Dialogue Sub-Window (13); Warp Town -> Area 2 Map 255 Submap 254 at (204,204) |
| `ev[18]` | `128 (Loop)` | Player within Box [104..128, 2..85] AND Condition Check #106 AND Story Flag 0 (mask 255) SET | Warp Room -> Submap 0 at (9,0) |
| `ev[19]` | `1 (Action / Talk)` | Player within Box [112..120, 2..107] AND Condition Check #108 AND Story Flag 0 (mask 255) SET | Warp Map Transition (3, 0, 40, 25, 255) |
| `ev[20]` | `1 (Action / Talk)` | Player within Box [79..80, 2..81] AND Condition Check #86 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 213]; Engine Action #162 |
| `ev[21]` | `1 (Action / Talk)` | Player within Box [215..217, 2..158] AND Condition Check #167 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 81]; Remove Item from Inventory (255, 254) |
| `ev[22]` | `1 (Action / Talk)` | Player within Box [96..97, 2..155] AND Condition Check #164 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 63]; Engine Action #164 |
| `ev[23]` | `1 (Action / Talk)` | Player within Box [65..66, 2..160] AND Condition Check #168 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 99]; Engine Action #160 |
| `ev[24]` | `1 (Action / Talk)` | Player within Box [34..38, 2..142] AND Condition Check #143 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 36]; Engine Action #113 |
| `ev[25]` | `1 (Action / Talk)` | Player within Box [34..38, 2..116] AND Condition Check #117 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 36]; Engine Action #145 |
| `ev[26]` | `1 (Action / Talk)` | Player within Box [34..38, 2..22] AND Condition Check #23 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 38]; Engine Action #199 |
| `ev[27]` | `1 (Action / Talk)` | Player within Box [153..154, 2..81] AND Condition Check #86 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 29]; Engine Action #218 |
| `ev[28]` | `1 (Action / Talk)` | Player within Box [25..27, 2..214] AND Condition Check #223 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 151]; Remove Item from Inventory (255, 254) |
| `ev[29]` | `1 (Action / Talk)` | Player within Box [145..146, 2..212] AND Condition Check #220 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 179]; Engine Action #216 |
| `ev[30]` | `1 (Action / Talk)` | Player within Box [175..177, 2..212] AND Condition Check #220 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 143]; Engine Action #216 |
| `ev[31]` | `1 (Action / Talk)` | Player within Box [204..208, 2..194] AND Condition Check #195 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 212]; Engine Action #113 |
| `ev[32]` | `1 (Action / Talk)` | Player within Box [210..214, 2..116] AND Condition Check #117 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 206]; Engine Action #197 |
| `ev[33]` | `1 (Action / Talk)` | Player within Box [210..214, 2..22] AND Condition Check #23 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 208]; Engine Action #201 |
| `ev[34]` | `2 (Map Init)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 220 (bit 128) CLEAR | Make obj[0] Hidden (disp = 0); Display Emotion Bubble (0, 30); Open Dialogue Message Window; Warp Room -> Submap 43 at (29,6); Open Shop Menu #6 (Type: 30); Open Shop Menu #6 (Type: 31); Teleport obj[255] to (254,204) |
| `ev[35]` | `2 (Map Init)` | Story Flag 220 (bit 1) SET | Make obj[1] Hidden (disp = 0); Display Emotion Bubble (1, 30); Warp Room -> Submap 1 at (35,1) facing 36; Warp Room -> Submap 1 at (38,1) facing 39; Warp Room -> Submap 47 at (255,254) facing 204 |
| `ev[36]` | `2 (Map Init)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 220 (bit 128) SET | Make obj[1] Hidden (disp = 0); Warp Map Transition (1, 33, 1, 34, 0); Start Boss Battle #0 (BGM: 36); Open Dialogue Message Window; Toggle Random Encounters (0); Open Save Crystal Menu (MSaveInit); Open Dialogue Message Window; Engine Action #39; Open Dialogue Message Window; Engine Action #40; Teleport obj[255] to (254,204) |
| `ev[37]` | `1 (Action / Talk)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 220 (bit 128) CLEAR AND Player within Box [31..41, 2..80] AND Condition Check #81 AND Story Flag 1 (mask 255) SET | Set Render Priority (pri) (0, 36); Set Special Scene BGM (9); Warp to Castle HQ (0, 1, 73); Branch on Choice (72, 1); Display Emotion Bubble (2, 73); Dismiss Emotion Bubble (72); Open Dialogue Message Window; Display Emotion Bubble (49, 3); Set Animation Pose (29, 0); Warp Town -> Area 0 Map 1 Submap 3 at (9,255); Set Animation Pose (30, 0); Warp Town -> Area 3 Map 1 Submap 2 at (9,255); Set Animation Pose (31, 0); Warp to Castle HQ (3, 1, 2); Engine Action #9; Walk obj[46] to (106,29); Warp Map Transition (106, 30, 33, 106, 31); Return Warp to Castle Base (89, 32); Warp Town -> Area 0 Map 89 Submap 33 at (2,0); Engine Action #89; Return Warp to Castle Base (2, 0); Warp Room -> Submap 1 at (30,1) facing 31; Open Dialogue Message Window; Warp Map Transition (0, 33, 0, 34, 47); Engine Action #89; Warp Map Transition (5, 89, 32, 5, 9); Engine Action #220; Engine Action #128; Engine Action #83; Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[38]` | `1 (Action / Talk)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 220 (bit 128) CLEAR AND Player within Box [31..41, 2..50] AND Condition Check #51 AND Story Flag 0 (mask 255) SET | Make obj[3] Hidden (disp = 0); Display Emotion Bubble (1, 3); Dismiss Emotion Bubble (1); Warp to Castle HQ (31, 1, 47); Set Render Priority (pri) (0, 36); Engine Action #58; Engine Action #9; Warp to Castle HQ (0, 0, 73); Branch on Choice (72, 1); Display Emotion Bubble (2, 73); Dismiss Emotion Bubble (72); Open Dialogue Message Window; Display Emotion Bubble (49, 3); Set Animation Pose (29, 0); Warp Town -> Area 0 Map 0 Submap 3 at (9,255); Set Animation Pose (30, 0); Warp Town -> Area 3 Map 0 Submap 2 at (9,255); Set Animation Pose (31, 0); Warp to Castle HQ (3, 0, 2); Engine Action #9; Walk obj[46] to (106,29); Warp Map Transition (106, 30, 33, 106, 31); Return Warp to Castle Base (89, 32); Warp Town -> Area 1 Map 89 Submap 33 at (2,1); Engine Action #89; Return Warp to Castle Base (2, 1); Warp Room -> Submap 1 at (30,1) facing 31; Open Dialogue Message Window; Warp Map Transition (0, 33, 0, 34, 47); Engine Action #89; Warp Map Transition (5, 89, 32, 5, 9); Engine Action #220; Engine Action #128; Engine Action #83; Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[39]` | `128 (Loop)` | Player within Box [79..80, 2..81] AND Condition Check #86 AND Story Flag 2 (mask 255) SET | Engine Action #121; Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[40]` | `128 (Loop)` | Player within Box [215..217, 2..158] AND Condition Check #167 AND Story Flag 3 (mask 255) SET | Engine Action #121; Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[41]` | `128 (Loop)` | Player within Box [96..97, 2..155] AND Condition Check #164 AND Story Flag 2 (mask 255) SET | Engine Action #121; Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[42]` | `128 (Loop)` | Player within Box [65..66, 2..160] AND Condition Check #168 AND Story Flag 3 (mask 255) SET | Engine Action #121; Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[43]` | `128 (Loop)` | Player within Box [34..38, 2..142] AND Condition Check #143 AND Story Flag 1 (mask 255) SET | Engine Action #121; Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[44]` | `128 (Loop)` | Player within Box [34..38, 2..116] AND Condition Check #117 AND Story Flag 0 (mask 255) SET | Engine Action #121; Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[45]` | `128 (Loop)` | Player within Box [34..38, 2..22] AND Condition Check #23 AND Story Flag 1 (mask 255) SET | Engine Action #121; Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[46]` | `128 (Loop)` | Player within Box [153..154, 2..81] AND Condition Check #86 AND Story Flag 3 (mask 255) SET | Engine Action #121; Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[47]` | `128 (Loop)` | Player within Box [25..27, 2..214] AND Condition Check #223 AND Story Flag 2 (mask 255) SET | Engine Action #121; Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[48]` | `128 (Loop)` | Player within Box [145..146, 2..212] AND Condition Check #220 AND Story Flag 3 (mask 255) SET | Engine Action #121; Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[49]` | `128 (Loop)` | Player within Box [175..177, 2..212] AND Condition Check #220 AND Story Flag 2 (mask 255) SET | Engine Action #121; Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[50]` | `128 (Loop)` | Player within Box [204..208, 2..194] AND Condition Check #195 AND Story Flag 1 (mask 255) SET | Engine Action #121; Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[51]` | `128 (Loop)` | Player within Box [210..214, 2..116] AND Condition Check #117 AND Story Flag 0 (mask 255) SET | Engine Action #121; Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[52]` | `128 (Loop)` | Player within Box [210..214, 2..22] AND Condition Check #23 AND Story Flag 1 (mask 255) SET | Engine Action #121; Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[53]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Open Dialogue Sub-Window (1); Open Dialogue Message Window |
| `ev[54]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Open Dialogue Sub-Window (1); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[55]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Open Dialogue Sub-Window (1); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[56]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Open Dialogue Sub-Window (1); Warp to Castle HQ (255, 254, 204) |
| `ev[57]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Open Dialogue Sub-Window (1); Exit to World Map (255, 254, 204) |
| `ev[58]` | `1 (Action / Talk)` | Target Inspected is obj[19] | Open Dialogue Sub-Window (1); Engine Action #5 |
| `ev[59]` | `1 (Action / Talk)` | Target Inspected is obj[20] | Open Dialogue Sub-Window (1); Engine Action #6 |
| `ev[60]` | `1 (Action / Talk)` | Target Inspected is obj[21] | Open Dialogue Sub-Window (1); Pan Camera (255, 254, 204) |
| `ev[61]` | `1 (Action / Talk)` | Target Inspected is obj[22] | Open Dialogue Sub-Window (1); Reset Camera Tracking (255) |
| `ev[62]` | `1 (Action / Talk)` | Target Inspected is obj[23] | Open Dialogue Sub-Window (1); Engine Action #9 |
| `ev[63]` | `1 (Action / Talk)` | Target Inspected is obj[24] | Open Dialogue Sub-Window (1); Screen Fade Transition (255, 254, 204) |
| `ev[64]` | `1 (Action / Talk)` | Target Inspected is obj[25] | Open Dialogue Sub-Window (1); Close Dialogue Window |
| `ev[65]` | `1 (Action / Talk)` | Target Inspected is obj[26] | Open Dialogue Sub-Window (1); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[66]` | `1 (Action / Talk)` | Target Inspected is obj[27] | Open Dialogue Sub-Window (1); Place Scenery Structure (255) |
| `ev[67]` | `1 (Action / Talk)` | Target Inspected is obj[28] | Open Dialogue Sub-Window (1); Animate Door Open |

---

### Submap Layer `vj02_01` (Index 1)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `2` (Timer: `70`, Rate: `5`)
- **Entity Count (`okaz`)**: `38` Objects | **Script Count (`evkaz`)**: `38` Scripts

#### Complete Physical Entity Inventory (38 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | Rest Device / Fire | **Inn Bed / Recovery Device** | `0` | `(124, 96)` | `0x0` | Frame 12 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | Rest Device / Fire | **Inn Bed / Recovery Device** | `0` | `(124, 96)` | `0x0` | Frame 13 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Actor ID 64615** | `64615` | `(197, 192)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | NPC / Actor | **Actor ID 64615** | `64615` | `(194, 194)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | NPC / Actor | **Actor ID 64615** | `64615` | `(197, 196)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | Prop / Scenery | **Prop ID 64613** | `64613` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | Prop / Scenery | **Prop ID 64613** | `64613` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Prop / Scenery | **Prop ID 64613** | `64613` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Prop / Scenery | **Prop ID 64616** | `64616` | `(201, 190)` | `0x0` | Frame 8 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Prop / Scenery | **Prop ID 64616** | `64616` | `(211, 195)` | `0x0` | Frame 9 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Prop / Scenery | **Prop ID 64616** | `64616` | `(214, 188)` | `0x0` | Frame 17 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Trigger / Hitbox | **Hitbox Zone (6x3)** | `0` | `(197, 189)` | `5x2` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | Trigger / Hitbox | **Hitbox Zone (6x3)** | `0` | `(210, 194)` | `5x2` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | Trigger / Hitbox | **Hitbox Zone (3x5)** | `0` | `(213, 185)` | `2x4` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | NPC / Actor | **Actor ID 64615** | `64615` | `(188, 41)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[15]` | NPC / Actor | **Actor ID 64615** | `64615` | `(185, 43)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[16]` | NPC / Actor | **Actor ID 64615** | `64615` | `(191, 43)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[17]` | Prop / Scenery | **Prop ID 64613** | `64613` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[18]` | Prop / Scenery | **Prop ID 64613** | `64613` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[19]` | Prop / Scenery | **Prop ID 64613** | `64613` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[20]` | Prop / Scenery | **Prop ID 64616** | `64616` | `(186, 39)` | `0x0` | Frame 16 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[21]` | Prop / Scenery | **Prop ID 64616** | `64616` | `(194, 44)` | `0x0` | Frame 10 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[22]` | Prop / Scenery | **Prop ID 64616** | `64616` | `(179, 47)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[23]` | Trigger / Hitbox | **Hitbox Zone (3x5)** | `0` | `(185, 38)` | `2x4` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[24]` | Trigger / Hitbox | **Hitbox Zone (6x2)** | `0` | `(192, 43)` | `5x1` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[25]` | Trigger / Hitbox | **Hitbox Zone (5x4)** | `0` | `(177, 46)` | `4x3` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[26]` | NPC / Actor | **Actor ID 64615** | `64615` | `(118, 101)` | `0x0` | Up (North) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[27]` | NPC / Actor | **Actor ID 64615** | `64615` | `(116, 99)` | `0x0` | Up (North) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[28]` | NPC / Actor | **Actor ID 64615** | `64615` | `(116, 103)` | `0x0` | Up (North) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[29]` | Prop / Scenery | **Prop ID 64613** | `64613` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[30]` | Prop / Scenery | **Prop ID 64613** | `64613` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[31]` | Prop / Scenery | **Prop ID 64613** | `64613` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[32]` | Prop / Scenery | **Prop ID 64616** | `64616` | `(99, 102)` | `0x0` | Frame 17 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[33]` | Prop / Scenery | **Prop ID 64616** | `64616` | `(107, 96)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[34]` | Prop / Scenery | **Prop ID 64616** | `64616` | `(106, 102)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[35]` | Trigger / Hitbox | **Hitbox Zone (3x5)** | `0` | `(98, 99)` | `2x4` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[36]` | Trigger / Hitbox | **Hitbox Zone (6x3)** | `0` | `(103, 95)` | `5x2` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[37]` | Trigger / Hitbox | **Hitbox Zone (6x3)** | `0` | `(105, 101)` | `5x2` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(124, 96)` with state parameter `12`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(124, 96)` with state parameter `13`.
- **`obj[02]` (Object 64615)**: Positioned at tile `(197, 192)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Object 64615)**: Positioned at tile `(194, 194)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Object 64615)**: Positioned at tile `(197, 196)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Prop: Object 64613)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[06]` (Prop: Object 64613)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[07]` (Prop: Object 64613)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[08]` (Prop: Object 64616)**: Environmental world dressing prop placed at tile `(201, 190)`. Solid collision is set to `128`.
- **`obj[09]` (Prop: Object 64616)**: Environmental world dressing prop placed at tile `(211, 195)`. Solid collision is set to `128`.
- **`obj[10]` (Prop: Object 64616)**: Environmental world dressing prop placed at tile `(214, 188)`. Solid collision is set to `128`.
- **`obj[11]` (Hitbox Zone)**: Bounding trigger area covering `6` tiles wide by `3` tiles high from `(197, 189)` to `(202, 191)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[12]` (Hitbox Zone)**: Bounding trigger area covering `6` tiles wide by `3` tiles high from `(210, 194)` to `(215, 196)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[13]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `5` tiles high from `(213, 185)` to `(215, 189)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[14]` (Object 64615)**: Positioned at tile `(188, 41)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[15]` (Object 64615)**: Positioned at tile `(185, 43)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[16]` (Object 64615)**: Positioned at tile `(191, 43)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[17]` (Prop: Object 64613)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[18]` (Prop: Object 64613)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[19]` (Prop: Object 64613)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[20]` (Prop: Object 64616)**: Environmental world dressing prop placed at tile `(186, 39)`. Solid collision is set to `128`.
- **`obj[21]` (Prop: Object 64616)**: Environmental world dressing prop placed at tile `(194, 44)`. Solid collision is set to `128`.
- **`obj[22]` (Prop: Object 64616)**: Environmental world dressing prop placed at tile `(179, 47)`. Solid collision is set to `128`.
- **`obj[23]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `5` tiles high from `(185, 38)` to `(187, 42)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[24]` (Hitbox Zone)**: Bounding trigger area covering `6` tiles wide by `2` tiles high from `(192, 43)` to `(197, 44)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[25]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `4` tiles high from `(177, 46)` to `(181, 49)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[26]` (Object 64615)**: Positioned at tile `(118, 101)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[27]` (Object 64615)**: Positioned at tile `(116, 99)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[28]` (Object 64615)**: Positioned at tile `(116, 103)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[29]` (Prop: Object 64613)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[30]` (Prop: Object 64613)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[31]` (Prop: Object 64613)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[32]` (Prop: Object 64616)**: Environmental world dressing prop placed at tile `(99, 102)`. Solid collision is set to `128`.
- **`obj[33]` (Prop: Object 64616)**: Environmental world dressing prop placed at tile `(107, 96)`. Solid collision is set to `128`.
- **`obj[34]` (Prop: Object 64616)**: Environmental world dressing prop placed at tile `(106, 102)`. Solid collision is set to `128`.
- **`obj[35]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `5` tiles high from `(98, 99)` to `(100, 103)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[36]` (Hitbox Zone)**: Bounding trigger area covering `6` tiles wide by `3` tiles high from `(103, 95)` to `(108, 97)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[37]` (Hitbox Zone)**: Bounding trigger area covering `6` tiles wide by `3` tiles high from `(105, 101)` to `(110, 103)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (38 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [30..34, 2..54] AND Condition Check #55 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 36]; Engine Action #89 |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [206..210, 2..204] AND Condition Check #206 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 212]; Clear Dialogue Sub-Window |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [206..210, 2..182] AND Condition Check #183 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 202]; Engine Action #143 |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [200..204, 2..147] AND Condition Check #148 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 208]; Engine Action #185 |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [200..204, 2..84] AND Condition Check #85 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 206]; Engine Action #51 |
| `ev[05]` | `1 (Action / Talk)` | Player within Box [204..208, 2..54] AND Condition Check #55 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 202]; Engine Action #87 |
| `ev[06]` | `1 (Action / Talk)` | Player within Box [180..184, 2..54] AND Condition Check #55 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 170]; Open Dialogue Sub-Window (255) |
| `ev[07]` | `1 (Action / Talk)` | Player within Box [186..187, 2..190] AND Condition Check #198 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 215]; Engine Action #110 |
| `ev[08]` | `1 (Action / Talk)` | Player within Box [157..158, 2..164] AND Condition Check #170 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 89]; Engine Action #192 |
| `ev[09]` | `1 (Action / Talk)` | Player within Box [134..138, 2..58] AND Condition Check #59 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 56]; Engine Action #51 |
| `ev[10]` | `1 (Action / Talk)` | Player within Box [54..58, 2..54] AND Condition Check #55 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 136]; Engine Action #61 |
| `ev[11]` | `1 (Action / Talk)` | Player within Box [36..40, 2..202] AND Condition Check #203 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 36]; Clear Dialogue Sub-Window |
| `ev[12]` | `1 (Action / Talk)` | Player within Box [59..60, 2..188] AND Condition Check #196 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 91]; Engine Action #148 |
| `ev[13]` | `1 (Action / Talk)` | Player within Box [87..89, 2..144] AND Condition Check #154 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 57]; Engine Action #192 |
| `ev[14]` | `1 (Action / Talk)` | Player within Box [36..40, 2..180] AND Condition Check #181 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 36]; Engine Action #145 |
| `ev[15]` | `1 (Action / Talk)` | Player within Box [34..38, 2..148] AND Condition Check #149 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 38]; Engine Action #183 |
| `ev[16]` | `1 (Action / Talk)` | Player within Box [34..38, 2..84] AND Condition Check #87 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 32]; Engine Action #51 |
| `ev[17]` | `2 (Map Init)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 220 (bit 8) CLEAR | Make obj[0] Hidden (disp = 0); Screen Fade Transition (0, 11, 0); Display Dialogue Box [Bank: 43, MsgID: 10]; Engine Action #6; Open Shop Menu #6 (Type: 11); Open Shop Menu #6 (Type: 12); Teleport obj[255] to (254,204) |
| `ev[18]` | `2 (Map Init)` | Story Flag 220 (bit 1) SET | Make obj[1] Hidden (disp = 0); Screen Fade Transition (1, 11, 1); Display Dialogue Box [Bank: 1, MsgID: 13]; Warp Room -> Submap 1 at (15,1) facing 16; Warp Room -> Submap 1 at (18,1) facing 19; Warp Room -> Submap 1 at (21,47) facing 255 |
| `ev[19]` | `2 (Map Init)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 220 (bit 8) SET | Make obj[1] Hidden (disp = 0); Screen Fade Transition (1, 11, 1); Display Dialogue Box [Bank: 1, MsgID: 13]; Warp Room -> Submap 1 at (15,0) facing 16; Open Dialogue Message Window; Change Portrait Expression (0); Display Speaker Name Box (0); Display Choice Selection (0, 20); Open Dialogue Message Window; Execute Choice Result (47) |
| `ev[20]` | `1 (Action / Talk)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 220 (bit 8) CLEAR AND Player within Box [204..212, 2..184] AND Condition Check #186 | Set Combat Battle BGM (30); Make obj[3] Hidden (disp = 0); Screen Fade Transition (3, 3, 12); Warp to Castle HQ (47, 72, 1); Screen Fade Transition (2, 73, 30); Load Sound Bank into Memory (0, 10); Set Entity Movement Speed (3, 56); Screen Fade Transition (0, 2, 3); Open Dialogue Message Window; Warp to Castle HQ (8, 255, 254); Set Animation Pose (11, 0); Warp Town -> Area 0 Map 0 Submap 5 at (8,255); Set Animation Pose (12, 0); Warp to Castle HQ (3, 0, 3); Reset Camera Tracking (255); Walk obj[46] to (106,10); Place Scenery Structure (106); Close Dialogue Window; Animate Door Open; Set Character Quest Milestone (12, 15); Engine Action #89; Place Scenery Structure (2); Warp Room -> Submap 14 at (2,1) facing 89; Show Dialogue Portrait (2, 1, 1); Screen Fade Transition (1, 11, 1); Display Dialogue Box [Bank: 0, MsgID: 13]; Open Dialogue Message Window; Animate Door Open; Open Dialogue Message Window; Show Dialogue Portrait (47, 89, 13); Engine Action #5; Engine Action #89; Place Scenery Structure (5); Engine Action #9; Engine Action #220; Reset Camera Tracking (83); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[21]` | `1 (Action / Talk)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 220 (bit 8) CLEAR AND Player within Box [204..212, 2..200] AND Condition Check #202 | Set Combat Battle BGM (30); Make obj[3] Hidden (disp = 0); Screen Fade Transition (3, 3, 12); Warp to Castle HQ (47, 72, 1); Display Dialogue Box [Bank: 2, MsgID: 73]; Dismiss Emotion Bubble (72); Open Dialogue Message Window; Display Dialogue Box [Bank: 49, MsgID: 3]; Set Animation Pose (10, 0); Warp to Castle HQ (3, 1, 3); Reset Camera Tracking (255); Set Animation Pose (11, 0); Warp to Castle HQ (0, 1, 5); Reset Camera Tracking (255); Set Animation Pose (12, 0); Warp Town -> Area 3 Map 1 Submap 3 at (8,255); Walk obj[46] to (106,10); Place Scenery Structure (106); Close Dialogue Window; Animate Door Open; Set Character Quest Milestone (12, 15); Engine Action #89; Place Scenery Structure (2); Open Dialogue Message Window; Engine Action #89; Animate Door Open; Warp Town -> Area 0 Map 89 Submap 15 at (2,0); Warp Room -> Submap 1 at (11,1) facing 12; Open Dialogue Message Window; Place Scenery Structure (0); Animate Door Open; Open Dialogue Message Window; Show Dialogue Portrait (47, 89, 13); Engine Action #5; Engine Action #89; Place Scenery Structure (5); Engine Action #9; Engine Action #220; Reset Camera Tracking (83); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[22]` | `2 (Map Init)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 220 (bit 16) CLEAR AND Player within Box [203..211, 255..254] | Make obj[0] Hidden (disp = 0); Set Story Flag (0, 23); Open Dialogue Message Window; Close Dialogue Sub-Window (3); Set Story Flag (1, 3); Open Dialogue Sub-Window (1); Warp to Castle HQ (24, 1, 43); Set Story Flag (6, 43); Open Dialogue Sub-Window (6); Open Shop Menu #6 (Type: 24); Teleport obj[255] to (254,204) |
| `ev[23]` | `2 (Map Init)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 220 (bit 16) CLEAR AND Player within Box [180..184, 255..254] | Make obj[0] Hidden (disp = 0); Set Story Flag (0, 23); Open Dialogue Message Window; Close Dialogue Sub-Window (43); Set Story Flag (6, 43); Open Dialogue Sub-Window (6); Open Shop Menu #6 (Type: 24); Teleport obj[255] to (254,204) |
| `ev[24]` | `2 (Map Init)` | Story Flag 220 (bit 1) SET | Make obj[1] Hidden (disp = 0); Set Story Flag (1, 23); Warp Room -> Submap 1 at (28,1) facing 29; Warp Room -> Submap 1 at (25,1) facing 26; Warp Room -> Submap 1 at (31,1) facing 32; Warp Room -> Submap 47 at (255,254) facing 204 |
| `ev[25]` | `2 (Map Init)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 220 (bit 16) SET | Make obj[1] Hidden (disp = 0); Set Story Flag (1, 23); Warp Room -> Submap 1 at (25,1) facing 26; Warp Room -> Submap 0 at (28,0) facing 29; Open Dialogue Message Window; Dismiss Emotion Bubble (0); Warp Room -> Submap 0 at (32,0); Return to Previous Memory Map (47) |
| `ev[26]` | `1 (Action / Talk)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 220 (bit 16) CLEAR AND Player within Box [201..202, 2..33] AND Condition Check #37 | Set Render Priority (pri) (0, 188); Return Warp to Castle Base (9, 3); Open Dialogue Message Window; Open Dialogue Message Window; Load Sound Bank into Memory (1, 22); Warp Town -> Area 73 Map 20 Submap 72 at (0,22); Set Combat Battle BGM (20); Set Entity Movement Speed (3, 56); Set Story Flag (0, 2); Open Dialogue Message Window; Open Dialogue Message Window; Warp to Castle HQ (9, 255, 254); Set Animation Pose (23, 0); Warp Town -> Area 3 Map 0 Submap 3 at (9,255); Set Animation Pose (24, 0); Warp to Castle HQ (3, 0, 3); Engine Action #9; Walk obj[46] to (106,22); Clear Dialogue Sub-Window; Set Character Quest Milestone (23, 26); Set Character Quest Milestone (24, 27); Engine Action #89; Clear Dialogue Sub-Window; Warp Town -> Area 1 Map 89 Submap 26 at (2,1); Engine Action #89; Fade Out to Black (2); Warp Room -> Submap 22 at (1,23) facing West (Left); Close Dialogue Sub-Window (0); Clear Dialogue Sub-Window; Open Dialogue Message Window; Fade In from Black (0); Fade Out to Black (47); Engine Action #89; Clear Dialogue Sub-Window; Engine Action #5; Engine Action #89; Clear Dialogue Sub-Window; Engine Action #5; Engine Action #9; Engine Action #220; Dismiss Dialogue Portrait; Engine Action #83; Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[27]` | `1 (Action / Talk)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 220 (bit 16) CLEAR AND Player within Box [180..184, 2..50] AND Condition Check #52 | Set Render Priority (pri) (0, 188); Teleport obj[9] to (3,0); Warp Room -> Submap 1 at (22,2) facing 73; Dismiss Emotion Bubble (72); Open Dialogue Message Window; Set Story Flag (73, 30); Set Entity Movement Speed (3, 56); Set Story Flag (0, 3); Open Dialogue Message Window; Warp Room -> Submap 8 at (255,254) facing 56; Open Dialogue Sub-Window (0); Warp Town -> Area 3 Map 1 Submap 1 at (8,255); Set Animation Pose (24, 0); Warp to Castle HQ (3, 1, 1); Reset Camera Tracking (255); Walk obj[46] to (106,22); Clear Dialogue Sub-Window; Set Character Quest Milestone (23, 26); Set Character Quest Milestone (24, 27); Engine Action #89; Clear Dialogue Sub-Window; Warp Town -> Area 0 Map 89 Submap 26 at (2,0); Engine Action #89; Fade Out to Black (2); Open Dialogue Message Window; Warp Room -> Submap 1 at (23,1) facing 24; Open Dialogue Message Window; Clear Dialogue Sub-Window; Open Dialogue Message Window; Fade In from Black (0); Fade Out to Black (47); Engine Action #89; Clear Dialogue Sub-Window; Engine Action #5; Engine Action #89; Clear Dialogue Sub-Window; Engine Action #5; Engine Action #9; Engine Action #220; Dismiss Dialogue Portrait; Engine Action #83; Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[28]` | `2 (Map Init)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 220 (bit 64) CLEAR | Make obj[0] Hidden (disp = 0); Return Warp to Castle Base (0, 35); Open Dialogue Message Window; Launch Tactical War Battle (43); Return Warp to Castle Base (6, 43); Start Boss Battle #6 (BGM: 43); Launch Tactical War Battle (6); Teleport obj[255] to (254,204) |
| `ev[29]` | `2 (Map Init)` | Story Flag 220 (bit 1) SET | Make obj[1] Hidden (disp = 0); Return Warp to Castle Base (1, 35); Warp Room -> Submap 1 at (40,1) facing 41; Warp Room -> Submap 1 at (43,1) facing 44; Warp Room -> Submap 47 at (255,254) facing 204 |
| `ev[30]` | `2 (Map Init)` | Story Flag 220 (bit 64) SET AND Story Flag 220 (bit 1) CLEAR | Make obj[1] Hidden (disp = 0); Return Warp to Castle Base (1, 35); Warp Room -> Submap 1 at (37,1) facing 38; Warp Room -> Submap 0 at (40,0) facing 41; Open Dialogue Message Window; Remove Item from Inventory (0, 43); Open Dialogue Message Window; Engine Action #44; Open Dialogue Message Window; Make obj[47] Visible (disp = 1) |
| `ev[31]` | `1 (Action / Talk)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 220 (bit 64) CLEAR AND Player within Box [99..109, 2..110] AND Condition Check #111 | Set Render Priority (pri) (0, 104); Set Character Quest Milestone (8, 3); Open Dialogue Message Window; Warp Room -> Submap 20 at (72,1) facing 34; Warp Town -> Area 73 Map 30 Submap 72 at (0,34); Set Entity Movement Speed (3, 56); Return Warp to Castle Base (0, 2); Open Dialogue Message Window; Warp Room -> Submap 8 at (255,254) facing 56; Start Boss Battle #0 (BGM: 2); Warp to Castle HQ (1, 2, 8); Set Animation Pose (36, 0); Warp to Castle HQ (3, 1, 2); Reset Camera Tracking (255); Walk obj[46] to (106,34); Toggle Random Encounters (106); Start Boss Battle #38 (BGM: 106); Launch Tactical War Battle (39); Engine Action #89; Toggle Random Encounters (2); Open Dialogue Message Window; Engine Action #89; Open Save Crystal Menu (MSaveInit); Warp Town -> Area 0 Map 89 Submap 39 at (2,0); Warp Room -> Submap 1 at (35,1) facing 36; Open Dialogue Message Window; Toggle Random Encounters (0); Open Save Crystal Menu (MSaveInit); Open Dialogue Message Window; Engine Action #39; Teleport obj[89] to (37,5); Engine Action #89; Toggle Random Encounters (5); Engine Action #9; Engine Action #220; Animate Doorway State (83, 1); Exit to World Map (255, 254, 204) |
| `ev[32]` | `128 (Loop)` | Player within Box [180..184, 2..54] AND Condition Check #55 AND Story Flag 0 (mask 255) SET | Engine Action #121; Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[33]` | `128 (Loop)` | Player within Box [186..187, 2..190] AND Condition Check #198 AND Story Flag 2 (mask 255) SET | Engine Action #121; Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[34]` | `128 (Loop)` | Player within Box [157..158, 2..164] AND Condition Check #170 AND Story Flag 3 (mask 255) SET | Engine Action #121; Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[35]` | `2 (Map Init)` | Treasure Byte 8 Bit 4 FRESH (Unopened) | Make obj[0] Hidden (disp = 0); Reset Camera Tracking (47) |
| `ev[36]` | `2 (Map Init)` | Treasure Byte 8 Bit 4 LOOTED | Make obj[0] Hidden (disp = 0); Engine Action #9; Teleport obj[255] to (254,204) |
| `ev[37]` | `1 (Action / Talk)` | Treasure Byte 8 Bit 4 FRESH (Unopened) AND Target Inspected is obj[8] | Make obj[1] Hidden (disp = 0); Reset Camera Tracking (0); Engine Action #9; Teleport obj[101] to (4,7); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (1); Exit to World Map (0, 87, 32); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,8) facing 4; Warp Room -> Submap 1 at (9,0) facing 8; Teleport obj[255] to (254,255) |

---

### Submap Layer `vj02_02` (Index 2)

- **Map Number (`mapno`)**: `2`
- **Battle Encounter Zone (`batlno`)**: `2` (Timer: `70`, Rate: `5`)
- **Entity Count (`okaz`)**: `27` Objects | **Script Count (`evkaz`)**: `52` Scripts

#### Complete Physical Entity Inventory (27 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 149** | `149` | `(44, 130)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | Prop / Scenery | **Prop ID 33429** | `33429` | `(44, 130)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | Rest Device / Fire | **Inn Bed / Recovery Device** | `0` | `(185, 27)` | `0x0` | Frame 12 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | Rest Device / Fire | **Inn Bed / Recovery Device** | `0` | `(185, 27)` | `0x0` | Frame 13 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[04]` | Rest Device / Fire | **Inn Bed / Recovery Device** | `0` | `(179, 118)` | `0x0` | Frame 12 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[05]` | Rest Device / Fire | **Inn Bed / Recovery Device** | `0` | `(179, 118)` | `0x0` | Frame 13 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[06]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(107, 176)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(131, 176)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(184, 83)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Trigger / Hitbox | **Hitbox Zone (4x3)** | `0` | `(180, 28)` | `3x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Trigger / Hitbox | **Hitbox Zone (4x3)** | `0` | `(178, 32)` | `3x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Trigger / Hitbox | **Hitbox Zone (4x3)** | `0` | `(178, 34)` | `3x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | Trigger / Hitbox | **Hitbox Zone (9x2)** | `0` | `(116, 202)` | `8x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | NPC / Actor | **Actor ID 64615** | `64615` | `(120, 184)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | NPC / Actor | **Actor ID 64615** | `64615` | `(116, 187)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[15]` | NPC / Actor | **Actor ID 64615** | `64615` | `(124, 187)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[16]` | Prop / Scenery | **Prop ID 64613** | `64613` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[17]` | Prop / Scenery | **Prop ID 64613** | `64613` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[18]` | Prop / Scenery | **Prop ID 64613** | `64613` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[19]` | Prop / Scenery | **Prop ID 64616** | `64616` | `(116, 186)` | `0x0` | Frame 16 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[20]` | Prop / Scenery | **Prop ID 64616** | `64616` | `(123, 186)` | `0x0` | Frame 10 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[21]` | Prop / Scenery | **Prop ID 64616** | `64616` | `(125, 189)` | `0x0` | Frame 11 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[22]` | Trigger / Hitbox | **Hitbox Zone (3x5)** | `0` | `(115, 185)` | `2x4` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[23]` | Trigger / Hitbox | **Hitbox Zone (6x2)** | `0` | `(122, 185)` | `5x1` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[24]` | Trigger / Hitbox | **Hitbox Zone (5x4)** | `0` | `(123, 188)` | `4x3` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[25]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(105, 45)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[26]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(114, 45)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 149)**: Positioned at tile `(44, 130)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Prop: Object 33429)**: Environmental world dressing prop placed at tile `(44, 130)`. Solid collision is set to `0`.
- **`obj[02]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(185, 27)` with state parameter `12`.
- **`obj[03]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(185, 27)` with state parameter `13`.
- **`obj[04]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(179, 118)` with state parameter `12`.
- **`obj[05]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(179, 118)` with state parameter `13`.
- **`obj[06]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(107, 176)` to `(109, 178)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[07]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(131, 176)` to `(133, 178)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[08]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(184, 83)` to `(186, 84)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[09]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `3` tiles high from `(180, 28)` to `(183, 30)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[10]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `3` tiles high from `(178, 32)` to `(181, 34)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[11]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `3` tiles high from `(178, 34)` to `(181, 36)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[12]` (Hitbox Zone)**: Bounding trigger area covering `9` tiles wide by `2` tiles high from `(116, 202)` to `(124, 203)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[13]` (Object 64615)**: Positioned at tile `(120, 184)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[14]` (Object 64615)**: Positioned at tile `(116, 187)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[15]` (Object 64615)**: Positioned at tile `(124, 187)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[16]` (Prop: Object 64613)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[17]` (Prop: Object 64613)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[18]` (Prop: Object 64613)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[19]` (Prop: Object 64616)**: Environmental world dressing prop placed at tile `(116, 186)`. Solid collision is set to `128`.
- **`obj[20]` (Prop: Object 64616)**: Environmental world dressing prop placed at tile `(123, 186)`. Solid collision is set to `128`.
- **`obj[21]` (Prop: Object 64616)**: Environmental world dressing prop placed at tile `(125, 189)`. Solid collision is set to `128`.
- **`obj[22]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `5` tiles high from `(115, 185)` to `(117, 189)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[23]` (Hitbox Zone)**: Bounding trigger area covering `6` tiles wide by `2` tiles high from `(122, 185)` to `(127, 186)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[24]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `4` tiles high from `(123, 188)` to `(127, 191)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[25]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(105, 45)` to `(106, 46)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[26]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(114, 45)` to `(115, 46)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (52 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 96 (bit 1) SET AND Story Flag 96 (bit 2) CLEAR AND Temp Event Flag #1 SET | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[01]` | `2 (Map Init)` | Story Flag 96 (bit 1) SET AND Story Flag 96 (bit 2) CLEAR AND Inventory Holds Item #1 [Medicine] | Engine Action #89; Engine Action #9; Warp Town -> Area 2 Map 0 Submap 9 at (255,254) |
| `ev[02]` | `128 (Loop)` | Story Flag 96 (bit 1) SET AND Story Flag 96 (bit 2) CLEAR AND Inventory Holds Item #4 [Throat Drops] | Set Object Direction (0, 0); Set Object Direction (101, 1); Open Dialogue Message Window; Warp Room -> Submap 0 at (15,33); Toggle Random Encounters (4) |
| `ev[03]` | `1 (Action / Talk)` | Story Flag 96 (bit 1) SET AND Story Flag 96 (bit 2) CLEAR AND Player within Box [35..53, 2..145] AND Condition Check #148 AND Temp Event Flag #1 SET | Jump to Bytecode Offset (9, 9); Set Combat Battle BGM (30); Launch Tactical War Battle (4); Set Render Priority (pri) (0, 44); Engine Action #137; Reset Camera Tracking (3); Open Dialogue Message Window; Warp Room -> Submap 0 at (46,0) facing West (Left); Open Dialogue Message Window; Warp Town -> Area 0 Map 3 Submap 0 at (4,0); Engine Action #6; Open Dialogue Message Window; Engine Action #5; Teleport obj[49] to (5,5); Warp Room -> Submap 5 at (3,3) facing West (Left); Warp Town -> Area 30 Map 255 Submap 254 at (5,2); Exit to World Map (5, 3, 4); Warp Room -> Submap 30 at (255,254) facing 5; Warp to Castle HQ (4, 5, 2); Exit to World Map (1, 1, 30); Engine Action #5; Exit to World Map (4, 5, 2); Warp to Castle HQ (1, 0, 30); Engine Action #5; Engine Action #5; Exit to World Map (5, 0, 2); Warp to Castle HQ (2, 1, 0); Dismiss Emotion Bubble (255); Walk obj[46] to (89,9); Warp Town -> Area 0 Map 1 Submap 8 at (0,9); Teleport obj[24] to (8,0); Display Speaker Name Box (73); Branch on Choice (40, 0); Open Dialogue Message Window; Warp Town -> Area 0 Map 19 Submap 0 at (20,41); Warp Town -> Area 0 Map 1 Submap 255 at (0,5); Open Dialogue Message Window; Exit to World Map (4, 1, 1); Dismiss Emotion Bubble (89); Engine Action #9; Warp Town -> Area 0 Map 24 Submap 8 at (0,21); Engine Action #51; Warp Town -> Area 255 Map 1 Submap 89 at (9,2); Open Dialogue Message Window; Close Dialogue Sub-Window (8); Open Dialogue Message Window; Set Story Flag (255, 2); Set Combat Battle BGM (90); Engine Action #89; Engine Action #9; Warp Town -> Area 1 Map 24 Submap 8 at (0,23); Engine Action #54; Open Dialogue Message Window; Exit to World Map (73, 30, 101); Engine Action #9; Engine Action #9; Close Dialogue Window; Warp Town -> Area 2 Map 60 Submap 102 at (1,36); Warp Room -> Submap 9 at (14,83) facing Up (North); Warp to Castle HQ (255, 254, 204) |
| `ev[04]` | `1 (Action / Talk)` | Story Flag 96 (bit 1) SET AND Story Flag 96 (bit 2) CLEAR AND Inventory Holds Item #1 [Medicine] AND Temp Event Flag #2 SET | Engine Action #102; Open Dialogue Message Window; Warp Room -> Submap 2 at (8,44) facing 132; Set Object Direction (0, 0); Engine Action #104; Jump to Bytecode Offset (1, 0); Close Dialogue Sub-Window (8); Open Dialogue Message Window; Close Dialogue Sub-Window (73); Branch on Choice (40, 0); Open Dialogue Message Window; Warp Town -> Area 0 Map 25 Submap 0 at (26,41); Warp Town -> Area 0 Map 1 Submap 255 at (0,24); Reset Camera Tracking (0); Fade Out to Black (89); Engine Action #9; Warp Town -> Area 3 Map 73 Submap 140 at (101,0); Engine Action #208; Set Combat Battle BGM (10); Jump to Bytecode Offset (0, 183); Set Combat Battle BGM (60); Engine Action #89; Engine Action #9; Warp Town -> Area 4 Map 24 Submap 8 at (0,28); Engine Action #51; Warp Town -> Area 255 Map 1 Submap 24 at (8,0); Display Emotion Bubble (89, 9); Warp Town -> Area 3 Map 73 Submap 140 at (101,0); Engine Action #208; Set Combat Battle BGM (10); Jump to Bytecode Offset (0, 183); Set Combat Battle BGM (60); Engine Action #89; Engine Action #9; Warp Town -> Area 4 Map 24 Submap 8 at (0,30); Warp Town -> Area 73 Map 90 Submap 24 at (8,0); Warp Room -> Submap 39 at (34,44); Set Animation Pose (0, 8); Warp to Castle HQ (3, 1, 0); Reset Camera Tracking (3); Open Dialogue Message Window; Warp Town -> Area 73 Map 90 Submap 5 at (0,1); Engine Action #5; Warp Town -> Area 3 Map 1 Submap 10 at (30,1); Open Dialogue Message Window; Set Combat Battle BGM (60); Close Dialogue Sub-Window (8); Open Dialogue Message Window; Warp Map Transition (73, 30, 69, 1, 101); Engine Action #9; Pan Camera (11, 2, 2); Engine Action #180; Engine Action #9; Clear Story Milestone Flag 2 (mask 101); Pan Camera (0, 105, 0); Open Dialogue Message Window; Jump to Bytecode Offset (101, 1); Open Dialogue Message Window; Engine Action #117; Open Dialogue Message Window; Open Dialogue Message Window; Display Dialogue Box [Bank: 2, MsgID: 110]; Remove Character from Active Party (255) |
| `ev[05]` | `128 (Loop)` | Player within Box [95..102, 2..47] AND Condition Check #67 AND Story Flag 0 (mask 255) SET | Warp Room -> Submap 0 at (9,2) |
| `ev[06]` | `128 (Loop)` | Player within Box [118..124, 2..47] AND Condition Check #67 AND Story Flag 0 (mask 255) SET | Warp Room -> Submap 0 at (9,2) |
| `ev[07]` | `1 (Action / Talk)` | Player within Box [168..172, 2..20] AND Inventory Holds Item #9 [Kindness Drops] AND Player X within Range [255..254] | Display Dialogue Box [Bank: 1, MsgID: 182]; Engine Action #51 |
| `ev[08]` | `1 (Action / Talk)` | Player within Box [217..218, 2..106] AND Condition Check #115 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 189]; Engine Action #194 |
| `ev[09]` | `1 (Action / Talk)` | Player within Box [148..149, 2..126] AND Condition Check #134 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 151]; Engine Action #192 |
| `ev[10]` | `1 (Action / Talk)` | Player within Box [153..154, 2..188] AND Condition Check #198 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 151]; Display Dialogue Message (255, 254) |
| `ev[11]` | `1 (Action / Talk)` | Player within Box [86..87, 2..188] AND Condition Check #198 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 155]; Engine Action #166 |
| `ev[12]` | `1 (Action / Talk)` | Player within Box [117..123, 2..174] AND Condition Check #175 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 44]; Engine Action #201 |
| `ev[13]` | `1 (Action / Talk)` | Player within Box [40..48, 2..204] AND Condition Check #205 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 120]; Engine Action #177 |
| `ev[14]` | `1 (Action / Talk)` | Story Flag 96 (bit 2) SET AND Player within Box [40..48, 2..121] AND Condition Check #122 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 110]; Remove Character from Active Party (255) |
| `ev[15]` | `1 (Action / Talk)` | Player within Box [106..114, 2..74] AND Condition Check #75 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 44]; Engine Action #127 |
| `ev[16]` | `1 (Action / Talk)` | Player within Box [96..100, 2..74] AND Condition Check #75 AND Story Flag 0 (mask 255) SET | Warp Map Transition (3, 0, 106, 28, 255) |
| `ev[17]` | `1 (Action / Talk)` | Player within Box [120..124, 2..74] AND Condition Check #75 AND Story Flag 0 (mask 255) SET | Warp Map Transition (3, 0, 130, 28, 255) |
| `ev[18]` | `128 (Loop)` | Player within Box [168..172, 2..20] AND Inventory Holds Item #9 [Kindness Drops] AND Player X within Range [255..254] | Engine Action #121; Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[19]` | `128 (Loop)` | Player within Box [217..218, 2..106] AND Condition Check #115 AND Story Flag 3 (mask 255) SET | Engine Action #121; Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[20]` | `128 (Loop)` | Player within Box [148..149, 2..126] AND Condition Check #134 AND Story Flag 2 (mask 255) SET | Engine Action #121; Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[21]` | `128 (Loop)` | Player within Box [153..154, 2..188] AND Condition Check #198 AND Story Flag 3 (mask 255) SET | Engine Action #121; Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[22]` | `128 (Loop)` | Player within Box [86..87, 2..188] AND Condition Check #198 AND Story Flag 2 (mask 255) SET | Engine Action #121; Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[23]` | `128 (Loop)` | Player within Box [117..123, 2..174] AND Condition Check #175 AND Story Flag 1 (mask 255) SET | Engine Action #121; Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[24]` | `128 (Loop)` | Player within Box [40..48, 2..204] AND Condition Check #205 AND Story Flag 0 (mask 255) SET | Engine Action #121; Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[25]` | `128 (Loop)` | Player within Box [40..48, 2..121] AND Condition Check #122 AND Story Flag 1 (mask 255) SET | Engine Action #121; Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[26]` | `128 (Loop)` | Player within Box [106..114, 2..74] AND Condition Check #75 AND Story Flag 0 (mask 255) SET | Engine Action #121; Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[27]` | `2 (Map Init)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 220 (bit 32) CLEAR | Make obj[0] Hidden (disp = 0); Execute Choice Result (0); Set Story Flag (0, 23); Open Shop Menu #6 (Type: 21); Open Shop Menu #6 (Type: 22); Open Shop Menu #6 (Type: 23); Teleport obj[255] to (254,204) |
| `ev[28]` | `2 (Map Init)` | Story Flag 220 (bit 1) SET | Make obj[1] Hidden (disp = 0); Execute Choice Result (1); Set Story Flag (1, 23); Warp Room -> Submap 1 at (28,1) facing 29; Warp Room -> Submap 1 at (31,1) facing 32; Teleport obj[255] to (254,204) |
| `ev[29]` | `2 (Map Init)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 220 (bit 32) SET | Make obj[1] Hidden (disp = 0); Close Dialogue Sub-Window (1); Clear Dialogue Sub-Window; Warp Room -> Submap 0 at (27,0) facing 28; Open Dialogue Message Window; Display Emotion Bubble (0, 30); Open Dialogue Message Window; Warp Room -> Submap 0 at (32,47) |
| `ev[30]` | `1 (Action / Talk)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 220 (bit 32) CLEAR AND Player within Box [136..137, 2..189] AND Condition Check #198 | Set Render Priority (pri) (0, 120); Engine Action #189; Reset Camera Tracking (3); Open Dialogue Message Window; Warp Room -> Submap 20 at (72,1) facing 21; Warp Town -> Area 73 Map 30 Submap 72 at (0,21); Set Entity Movement Speed (3, 56); Execute Choice Result (0); Warp Town -> Area 0 Map 1 Submap 4 at (8,255); Set Animation Pose (22, 0); Warp Town -> Area 4 Map 1 Submap 0 at (9,255); Set Animation Pose (23, 0); Warp to Castle HQ (4, 1, 0); Engine Action #9; Walk obj[46] to (106,21); Close Dialogue Sub-Window (106); Set Story Flag (25, 106); Open Dialogue Sub-Window (26); Engine Action #89; Close Dialogue Sub-Window (2); Open Dialogue Message Window; Engine Action #89; Clear Dialogue Sub-Window; Warp Town -> Area 3 Map 89 Submap 26 at (2,2); Warp Room -> Submap 1 at (22,1) facing 23; Open Dialogue Message Window; Close Dialogue Sub-Window (0); Clear Dialogue Sub-Window; Open Dialogue Message Window; Fade In from Black (47); Engine Action #89; Close Dialogue Sub-Window (5); Engine Action #89; Close Dialogue Sub-Window (5); Engine Action #9; Engine Action #220; Warp Map Transition (83, 1, 3, 255, 254) |
| `ev[31]` | `1 (Action / Talk)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 220 (bit 32) CLEAR AND Player within Box [103..104, 2..189] AND Condition Check #198 | Set Render Priority (pri) (0, 120); Engine Action #189; Reset Camera Tracking (3); Open Dialogue Message Window; Warp Room -> Submap 20 at (72,1) facing 21; Warp Town -> Area 73 Map 30 Submap 72 at (0,21); Set Entity Movement Speed (3, 56); Execute Choice Result (0); Warp Town -> Area 0 Map 1 Submap 3 at (8,255); Set Animation Pose (22, 0); Warp Town -> Area 3 Map 1 Submap 0 at (9,255); Set Animation Pose (23, 0); Warp to Castle HQ (3, 1, 0); Engine Action #9; Walk obj[46] to (106,21); Close Dialogue Sub-Window (106); Set Story Flag (25, 106); Open Dialogue Sub-Window (26); Engine Action #89; Close Dialogue Sub-Window (2); Open Dialogue Message Window; Engine Action #89; Clear Dialogue Sub-Window; Warp Town -> Area 3 Map 89 Submap 26 at (2,2); Warp Room -> Submap 1 at (22,1) facing 23; Open Dialogue Message Window; Close Dialogue Sub-Window (0); Clear Dialogue Sub-Window; Open Dialogue Message Window; Fade In from Black (47); Engine Action #89; Close Dialogue Sub-Window (5); Engine Action #89; Close Dialogue Sub-Window (5); Engine Action #9; Engine Action #220; Warp Map Transition (83, 1, 3, 255, 254) |
| `ev[32]` | `2 (Map Init)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR | Dismiss Emotion Bubble (2); Open Dialogue Message Window |
| `ev[33]` | `1 (Action / Talk)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR | Open Choice Selection Menu (1, 43); Open Dialogue Message Window; Engine Action #5; Launch Tactical War Battle (1); Engine Action #61; Warp Room -> Submap 5 at (0,1) facing 40; Dismiss Emotion Bubble (36); Warp Town -> Area 61 Map 1 Submap 3 at (5,0); Warp to Castle HQ (12, 30, 61); Warp Room -> Submap 5 at (0,0) facing 40; Dismiss Emotion Bubble (101); Engine Action #6; Engine Action #66; Place Scenery Structure (5); Engine Action #9; Open Dialogue Message Window; Open Dialogue Message Window; Start Boss Battle #86 (BGM: 255) |
| `ev[34]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Inventory Holds Item #1 [Medicine] | Close Dialogue Window; Warp to Castle HQ (2, 40, 37); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[35]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Inventory Holds Item #2 [Mega Medicine] AND Player Y within Range [59..61] | Wait for Audio / Window Sync (3); Close Dialogue Window; Exit to World Map (2, 40, 37); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[36]` | `2 (Map Init)` | Treasure Byte 8 Bit 2 FRESH (Unopened) | Make obj[0] Hidden (disp = 0); Screen Fade Transition (47, 255, 254) |
| `ev[37]` | `2 (Map Init)` | Treasure Byte 8 Bit 2 LOOTED | Make obj[0] Hidden (disp = 0); Close Dialogue Window; Teleport obj[255] to (254,204) |
| `ev[38]` | `1 (Action / Talk)` | Treasure Byte 8 Bit 2 FRESH (Unopened) AND Target Inspected is obj[10] | Make obj[1] Hidden (disp = 0); Screen Fade Transition (0, 11, 47); Jump to Bytecode Offset (4, 7); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (1); Exit to World Map (0, 20, 0); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,8) facing Up (North); Warp Room -> Submap 1 at (11,0) facing 10; Teleport obj[255] to (254,255) |
| `ev[39]` | `2 (Map Init)` | Treasure Byte 8 Bit 1 FRESH (Unopened) | Make obj[0] Hidden (disp = 0); Display Dialogue Box [Bank: 47, MsgID: 255] |
| `ev[40]` | `2 (Map Init)` | Treasure Byte 8 Bit 1 LOOTED | Make obj[0] Hidden (disp = 0); Place Scenery Structure (47) |
| `ev[41]` | `1 (Action / Talk)` | Treasure Byte 8 Bit 1 FRESH (Unopened) AND Target Inspected is obj[12] | Make obj[1] Hidden (disp = 0); Display Dialogue Box [Bank: 0, MsgID: 13]; Teleport obj[101] to (4,7); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (1); Exit to World Map (0, 31, 16); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,8) facing West (Left); Warp Room -> Submap 1 at (13,0) facing 12; Teleport obj[255] to (254,255) |
| `ev[42]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Open Dialogue Sub-Window (1); Show Dialogue Portrait (255, 254, 204) |
| `ev[43]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Open Dialogue Sub-Window (1); Dismiss Dialogue Portrait |
| `ev[44]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Open Dialogue Sub-Window (1); Change Portrait Expression (255) |
| `ev[45]` | `1 (Action / Talk)` | Treasure Byte 9 Bit 4 FRESH (Unopened) AND Target Inspected is obj[17] | Open Dialogue Sub-Window (1); Display Speaker Name Box (101); Exit to World Map (7, 101, 4); Pan Camera (30, 1, 4); Open Dialogue Message Window; Warp Room -> Submap 0 at (41,2) facing South (Down); Warp Room -> Submap 0 at (97,9) facing 4; Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[46]` | `1 (Action / Talk)` | Treasure Byte 9 Bit 4 LOOTED AND Target Inspected is obj[17] | Open Dialogue Sub-Window (1); Execute Choice Result (255) |
| `ev[47]` | `1 (Action / Talk)` | Treasure Byte 9 Bit 8 FRESH (Unopened) AND Target Inspected is obj[18] | Open Dialogue Sub-Window (1); Display Choice Selection (101, 4); Pan Camera (101, 4, 7); Dismiss Emotion Bubble (1); Exit to World Map (0, 1, 0); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,9) facing 8; Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[48]` | `1 (Action / Talk)` | Treasure Byte 9 Bit 8 LOOTED AND Target Inspected is obj[18] | Open Dialogue Sub-Window (1); Execute Choice Result (255) |
| `ev[49]` | `1 (Action / Talk)` | Treasure Byte 9 Bit 16 FRESH (Unopened) AND Target Inspected is obj[19] | Open Dialogue Sub-Window (1); Branch on Choice (101, 4); Pan Camera (101, 4, 7); Dismiss Emotion Bubble (1); Exit to World Map (0, 2, 0); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,9) facing 16; Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[50]` | `1 (Action / Talk)` | Treasure Byte 9 Bit 16 LOOTED AND Target Inspected is obj[19] | Open Dialogue Sub-Window (1); Execute Choice Result (255) |
| `ev[51]` | `1 (Action / Talk)` | Target Inspected is obj[20] | Open Dialogue Sub-Window (1); Animate Door Open |

---



## Location Map: `vj03`

- **Master Map Container**: `vj03.json`
- **Submap Layer Files**: vj03_00.json, vj03_01.json
- **Collision Grid Files**: None
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 3

### Submap Layer `vj03_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `5`)
- **Entity Count (`okaz`)**: `15` Objects | **Script Count (`evkaz`)**: `23` Scripts

#### Complete Physical Entity Inventory (15 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(51, 43)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[01]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(51, 50)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Actor ID 64615** | `64615` | `(204, 55)` | `0x0` | Up (North) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | NPC / Actor | **Actor ID 64615** | `64615` | `(206, 58)` | `0x0` | Up (North) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | NPC / Actor | **Actor ID 64615** | `64615` | `(204, 61)` | `0x0` | Up (North) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | Prop / Scenery | **Prop ID 64613** | `64613` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | Prop / Scenery | **Prop ID 64613** | `64613` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Prop / Scenery | **Prop ID 64613** | `64613` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Prop / Scenery | **Prop ID 64616** | `64616` | `(204, 55)` | `0x0` | Frame 17 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Prop / Scenery | **Prop ID 64616** | `64616` | `(209, 58)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Prop / Scenery | **Prop ID 64616** | `64616` | `(205, 60)` | `0x0` | Frame 11 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Trigger / Hitbox | **Hitbox Zone (3x5)** | `0` | `(203, 52)` | `2x4` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | Trigger / Hitbox | **Hitbox Zone (6x3)** | `0` | `(208, 57)` | `5x2` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(203, 59)` | `2x2` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | Trigger / Hitbox | **Hitbox Zone (4x3)** | `0` | `(204, 60)` | `3x2` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(51, 43)` to `(54, 44)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[01]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(51, 50)` to `(54, 51)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[02]` (Object 64615)**: Positioned at tile `(204, 55)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Object 64615)**: Positioned at tile `(206, 58)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Object 64615)**: Positioned at tile `(204, 61)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Prop: Object 64613)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[06]` (Prop: Object 64613)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[07]` (Prop: Object 64613)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[08]` (Prop: Object 64616)**: Environmental world dressing prop placed at tile `(204, 55)`. Solid collision is set to `128`.
- **`obj[09]` (Prop: Object 64616)**: Environmental world dressing prop placed at tile `(209, 58)`. Solid collision is set to `128`.
- **`obj[10]` (Prop: Object 64616)**: Environmental world dressing prop placed at tile `(205, 60)`. Solid collision is set to `128`.
- **`obj[11]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `5` tiles high from `(203, 52)` to `(205, 56)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[12]` (Hitbox Zone)**: Bounding trigger area covering `6` tiles wide by `3` tiles high from `(208, 57)` to `(213, 59)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[13]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(203, 59)` to `(205, 61)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[14]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `3` tiles high from `(204, 60)` to `(207, 62)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (23 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `128 (Loop)` | Player within Box [103..133, 2..28] AND Condition Check #37 | Warp Room -> Submap 1 at (9,1) |
| `ev[01]` | `128 (Loop)` | Player within Box [25..59, 2..54] AND Condition Check #64 | Warp Room -> Submap 1 at (9,10) |
| `ev[02]` | `128 (Loop)` | Player within Box [186..222, 2..54] AND Condition Check #64 | Warp Room -> Submap 1 at (9,10) |
| `ev[03]` | `128 (Loop)` | Player within Box [110..126, 2..125] AND Condition Check #156 AND Story Flag 0 (mask 255) SET | Warp Room -> Submap 1 at (9,10) |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [104..108, 2..25] AND Condition Check #26 AND Story Flag 1 (mask 255) SET | Warp Map Transition (2, 2, 98, 71, 255) |
| `ev[05]` | `1 (Action / Talk)` | Player within Box [128..132, 2..25] AND Condition Check #26 AND Story Flag 1 (mask 255) SET | Warp Map Transition (2, 2, 122, 71, 255) |
| `ev[06]` | `1 (Action / Talk)` | Player within Box [114..122, 2..38] AND Condition Check #39 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 118]; Award Potch Currency (255,254) |
| `ev[07]` | `1 (Action / Talk)` | Player within Box [114..122, 2..74] AND Condition Check #75 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 118]; Start Boss Battle #255 (BGM: 254) |
| `ev[08]` | `1 (Action / Talk)` | Player within Box [88..89, 2..111] AND Condition Check #120 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 71]; Warp Map Transition (255, 254, 204, 204, 204) |
| `ev[09]` | `1 (Action / Talk)` | Player within Box [73..74, 2..28] AND Condition Check #34 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 91]; Engine Action #116 |
| `ev[10]` | `1 (Action / Talk)` | Player within Box [30..34, 2..49] AND Condition Check #50 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 54]; Engine Action #209 |
| `ev[11]` | `1 (Action / Talk)` | Player within Box [40..44, 2..68] AND Condition Check #69 AND Story Flag 0 (mask 255) SET | Warp Map Transition (2, 0, 48, 117, 255) |
| `ev[12]` | `1 (Action / Talk)` | Player within Box [202..206, 2..68] AND Condition Check #69 AND Story Flag 0 (mask 255) SET | Warp Map Transition (2, 0, 192, 107, 255) |
| `ev[13]` | `1 (Action / Talk)` | Player within Box [114..122, 2..160] AND Condition Check #161 AND Story Flag 0 (mask 255) SET | Warp Map Transition (2, 0, 118, 193, 255) |
| `ev[14]` | `1 (Action / Talk)` | Player within Box [212..216, 2..49] AND Condition Check #50 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 190]; Engine Action #209 |
| `ev[15]` | `1 (Action / Talk)` | Player within Box [172..173, 2..26] AND Condition Check #34 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 145]; Engine Action #116 |
| `ev[16]` | `1 (Action / Talk)` | Player within Box [147..148, 2..115] AND Condition Check #120 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 175]; Warp Room -> Submap 255 at (254,204) |
| `ev[17]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Open Dialogue Sub-Window (0); Open Dialogue Message Window |
| `ev[18]` | `1 (Action / Talk)` | Target Inspected is obj[8] | Open Dialogue Sub-Window (0); Open Dialogue Message Window |
| `ev[19]` | `2 (Map Init)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 221 (bit 32) CLEAR | Make obj[0] Hidden (disp = 0); Screen Fade Transition (0, 11, 0); Display Dialogue Box [Bank: 43, MsgID: 10]; Engine Action #6; Open Shop Menu #6 (Type: 11); Open Shop Menu #6 (Type: 12); Teleport obj[255] to (254,204) |
| `ev[20]` | `2 (Map Init)` | Story Flag 220 (bit 1) SET | Make obj[1] Hidden (disp = 0); Screen Fade Transition (1, 11, 1); Display Dialogue Box [Bank: 1, MsgID: 16]; Warp Room -> Submap 1 at (18,1) facing 19; Warp Room -> Submap 1 at (21,1) facing 22; Teleport obj[255] to (254,204) |
| `ev[21]` | `2 (Map Init)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 221 (bit 32) SET | Make obj[1] Hidden (disp = 0); Screen Fade Transition (1, 11, 1); Display Dialogue Box [Bank: 1, MsgID: 13]; Warp Room -> Submap 1 at (15,0) facing 16; Open Dialogue Message Window; Change Portrait Expression (0); Display Speaker Name Box (0); Display Choice Selection (0, 20); Open Dialogue Message Window; Execute Choice Result (0); Set Story Flag (47, 255) |
| `ev[22]` | `1 (Action / Talk)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 221 (bit 32) CLEAR AND Player within Box [192..196, 2..45] AND Condition Check #46 | Set Render Priority (pri) (0, 197); Engine Action #58; Engine Action #9; Load Sound Bank into Memory (1, 11); Warp Town -> Area 73 Map 20 Submap 72 at (0,11); Set Entity Movement Speed (3, 56); Screen Fade Transition (0, 3, 2); Warp Room -> Submap 9 at (255,254) facing 56; Close Dialogue Window; Open Dialogue Message Window; Warp to Castle HQ (4, 0, 0); Engine Action #9; Set Animation Pose (12, 0); Warp to Castle HQ (2, 0, 3); Engine Action #9; Walk obj[46] to (106,10); Place Scenery Structure (106); Close Dialogue Window; Animate Door Open; Set Character Quest Milestone (12, 15); Engine Action #89; Place Scenery Structure (2); Warp Town -> Area 89 Map 14 Submap 2 at (2,89); Show Dialogue Portrait (2, 2, 1); Screen Fade Transition (1, 11, 1); Display Dialogue Box [Bank: 0, MsgID: 13]; Open Dialogue Message Window; Animate Door Open; Open Dialogue Message Window; Show Dialogue Portrait (47, 89, 13); Engine Action #5; Engine Action #89; Place Scenery Structure (5); Engine Action #9; Engine Action #221; Warp Map Transition (83, 1, 2, 255, 254) |

---

### Submap Layer `vj03_01` (Index 1)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `5`)
- **Entity Count (`okaz`)**: `25` Objects | **Script Count (`evkaz`)**: `18` Scripts

#### Complete Physical Entity Inventory (25 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 64615** | `64615` | `(169, 53)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Actor ID 64615** | `64615` | `(172, 51)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Actor ID 64615** | `64615` | `(172, 55)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | Prop / Scenery | **Prop ID 64613** | `64613` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | Prop / Scenery | **Prop ID 64613** | `64613` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | Prop / Scenery | **Prop ID 64613** | `64613` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | Prop / Scenery | **Prop ID 64616** | `64616` | `(176, 50)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Prop / Scenery | **Prop ID 64616** | `64616` | `(180, 54)` | `0x0` | Frame 8 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Prop / Scenery | **Prop ID 64616** | `64616` | `(168, 53)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Trigger / Hitbox | **Hitbox Zone (6x3)** | `0` | `(172, 49)` | `5x2` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Trigger / Hitbox | **Hitbox Zone (6x3)** | `0` | `(176, 53)` | `5x2` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Trigger / Hitbox | **Hitbox Zone (4x3)** | `0` | `(166, 53)` | `3x2` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(168, 52)` | `2x2` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | NPC / Actor | **Actor ID 64615** | `64615` | `(54, 169)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | NPC / Actor | **Actor ID 64615** | `64615` | `(51, 171)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[15]` | NPC / Actor | **Actor ID 64615** | `64615` | `(57, 171)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[16]` | Prop / Scenery | **Prop ID 64613** | `64613` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[17]` | Prop / Scenery | **Prop ID 64613** | `64613` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[18]` | Prop / Scenery | **Prop ID 64613** | `64613` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[19]` | Prop / Scenery | **Prop ID 64616** | `64616` | `(51, 170)` | `0x0` | Frame 17 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[20]` | Prop / Scenery | **Prop ID 64616** | `64616` | `(48, 176)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[21]` | Prop / Scenery | **Prop ID 64616** | `64616` | `(59, 174)` | `0x0` | Frame 10 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[22]` | Trigger / Hitbox | **Hitbox Zone (3x5)** | `0` | `(50, 167)` | `2x4` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[23]` | Trigger / Hitbox | **Hitbox Zone (6x3)** | `0` | `(44, 175)` | `5x2` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[24]` | Trigger / Hitbox | **Hitbox Zone (6x2)** | `0` | `(58, 173)` | `5x1` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 64615)**: Positioned at tile `(169, 53)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Object 64615)**: Positioned at tile `(172, 51)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Object 64615)**: Positioned at tile `(172, 55)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Prop: Object 64613)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[04]` (Prop: Object 64613)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[05]` (Prop: Object 64613)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[06]` (Prop: Object 64616)**: Environmental world dressing prop placed at tile `(176, 50)`. Solid collision is set to `128`.
- **`obj[07]` (Prop: Object 64616)**: Environmental world dressing prop placed at tile `(180, 54)`. Solid collision is set to `128`.
- **`obj[08]` (Prop: Object 64616)**: Environmental world dressing prop placed at tile `(168, 53)`. Solid collision is set to `128`.
- **`obj[09]` (Hitbox Zone)**: Bounding trigger area covering `6` tiles wide by `3` tiles high from `(172, 49)` to `(177, 51)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[10]` (Hitbox Zone)**: Bounding trigger area covering `6` tiles wide by `3` tiles high from `(176, 53)` to `(181, 55)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[11]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `3` tiles high from `(166, 53)` to `(169, 55)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[12]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(168, 52)` to `(170, 54)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[13]` (Object 64615)**: Positioned at tile `(54, 169)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[14]` (Object 64615)**: Positioned at tile `(51, 171)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[15]` (Object 64615)**: Positioned at tile `(57, 171)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[16]` (Prop: Object 64613)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[17]` (Prop: Object 64613)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[18]` (Prop: Object 64613)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[19]` (Prop: Object 64616)**: Environmental world dressing prop placed at tile `(51, 170)`. Solid collision is set to `128`.
- **`obj[20]` (Prop: Object 64616)**: Environmental world dressing prop placed at tile `(48, 176)`. Solid collision is set to `128`.
- **`obj[21]` (Prop: Object 64616)**: Environmental world dressing prop placed at tile `(59, 174)`. Solid collision is set to `128`.
- **`obj[22]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `5` tiles high from `(50, 167)` to `(52, 171)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[23]` (Hitbox Zone)**: Bounding trigger area covering `6` tiles wide by `3` tiles high from `(44, 175)` to `(49, 177)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[24]` (Hitbox Zone)**: Bounding trigger area covering `6` tiles wide by `2` tiles high from `(58, 173)` to `(63, 174)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (18 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [52..56, 2..212] AND Condition Check #213 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 32]; Engine Action #53 |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [188..192, 2..212] AND Condition Check #213 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 214]; Engine Action #53 |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [188..192, 2..111] AND Condition Check #112 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 202]; Engine Action #81 |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [200..204, 2..84] AND Condition Check #85 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 190]; Engine Action #115 |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [200..204, 2..22] AND Condition Check #23 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 142]; Set Combat Battle BGM (255) |
| `ev[05]` | `1 (Action / Talk)` | Player within Box [40..44, 2..22] AND Condition Check #23 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 48]; Set Combat Battle BGM (255) |
| `ev[06]` | `1 (Action / Talk)` | Player within Box [40..44, 2..84] AND Condition Check #85 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 54]; Engine Action #115 |
| `ev[07]` | `1 (Action / Talk)` | Player within Box [52..56, 2..111] AND Condition Check #112 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 42]; Engine Action #81 |
| `ev[08]` | `1 (Action / Talk)` | Player within Box [93..94, 2..51] AND Condition Check #56 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 71]; Engine Action #199 |
| `ev[09]` | `1 (Action / Talk)` | Player within Box [150..151, 2..51] AND Condition Check #56 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 121]; Engine Action #199 |
| `ev[10]` | `2 (Map Init)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 221 (bit 64) CLEAR | Make obj[0] Hidden (disp = 0); Reset Camera Tracking (0); Engine Action #9; Open Dialogue Message Window; Screen Fade Transition (43, 8, 6); Open Shop Menu #6 (Type: 9); Open Shop Menu #6 (Type: 10); Teleport obj[255] to (254,204) |
| `ev[11]` | `2 (Map Init)` | Story Flag 220 (bit 1) SET | Make obj[1] Hidden (disp = 0); Reset Camera Tracking (1); Engine Action #9; Warp Room -> Submap 1 at (14,1) facing 15; Warp Room -> Submap 1 at (17,1) facing 18; Warp Room -> Submap 1 at (20,47) facing 255 |
| `ev[12]` | `2 (Map Init)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 221 (bit 64) SET | Make obj[1] Hidden (disp = 0); Close Dialogue Window; Warp Room -> Submap 1 at (13,0) facing 14; Open Dialogue Message Window; Show Dialogue Portrait (0, 16, 0); Change Portrait Expression (0); Display Speaker Name Box (0); Display Choice Selection (0, 20); Teleport obj[255] to (254,204) |
| `ev[13]` | `1 (Action / Talk)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 221 (bit 64) CLEAR AND Player within Box [193..194, 2..49] AND Condition Check #58 | Set Render Priority (pri) (0, 182); Engine Action #53; Engine Action #9; Load Sound Bank into Memory (1, 8); Warp Town -> Area 73 Map 20 Submap 72 at (0,8); Set Entity Movement Speed (3, 56); Reset Camera Tracking (0); Warp Town -> Area 4 Map 1 Submap 0 at (9,255); Set Animation Pose (9, 0); Warp Town -> Area 2 Map 1 Submap 2 at (9,255); Set Animation Pose (10, 0); Warp Town -> Area 2 Map 0 Submap 2 at (9,255); Walk obj[46] to (106,8); Close Dialogue Window; Set Character Quest Milestone (9, 12); Set Character Quest Milestone (10, 13); Engine Action #89; Close Dialogue Window; Warp Town -> Area 3 Map 89 Submap 12 at (2,3); Engine Action #89; Place Scenery Structure (2); Warp to Castle HQ (1, 8, 1); Engine Action #9; Warp Room -> Submap 0 at (11,0) facing 12; Open Dialogue Message Window; Place Scenery Structure (47); Engine Action #89; Close Dialogue Window; Engine Action #5; Engine Action #89; Close Dialogue Window; Engine Action #5; Engine Action #9; Engine Action #221; Animate Doorway State (83, 1); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[14]` | `2 (Map Init)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 221 (bit 128) CLEAR | Make obj[0] Hidden (disp = 0); Execute Choice Result (0); Set Story Flag (0, 23); Open Shop Menu #6 (Type: 21); Open Shop Menu #6 (Type: 22); Open Shop Menu #6 (Type: 23); Teleport obj[255] to (254,204) |
| `ev[15]` | `2 (Map Init)` | Story Flag 220 (bit 1) SET | Make obj[1] Hidden (disp = 0); Execute Choice Result (1); Set Story Flag (1, 23); Warp Room -> Submap 1 at (28,1) facing 29; Warp Room -> Submap 1 at (31,1) facing 32; Teleport obj[255] to (254,204) |
| `ev[16]` | `2 (Map Init)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 221 (bit 128) SET | Make obj[1] Hidden (disp = 0); Close Dialogue Sub-Window (1); Clear Dialogue Sub-Window; Warp Room -> Submap 0 at (27,0) facing 28; Open Dialogue Message Window; Display Emotion Bubble (0, 30); Open Dialogue Message Window; Warp Room -> Submap 0 at (32,47) |
| `ev[17]` | `1 (Action / Talk)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 221 (bit 128) CLEAR AND Player within Box [52..56, 2..185] AND Condition Check #186 | Set Render Priority (pri) (0, 54); Engine Action #177; Reset Camera Tracking (72); Warp Room -> Submap 2 at (73,20) facing 72; Open Dialogue Message Window; Execute Choice Result (49); Warp to Castle HQ (56, 21, 0); Warp Town -> Area 0 Map 1 Submap 4 at (9,255); Set Animation Pose (22, 0); Warp Town -> Area 3 Map 1 Submap 2 at (9,255); Set Animation Pose (23, 0); Warp to Castle HQ (3, 1, 2); Engine Action #9; Walk obj[46] to (106,21); Close Dialogue Sub-Window (106); Set Story Flag (25, 106); Open Dialogue Sub-Window (26); Engine Action #89; Close Dialogue Sub-Window (2); Open Dialogue Message Window; Engine Action #89; Clear Dialogue Sub-Window; Warp Town -> Area 0 Map 89 Submap 26 at (2,0); Warp Room -> Submap 1 at (22,1) facing 23; Open Dialogue Message Window; Close Dialogue Sub-Window (0); Clear Dialogue Sub-Window; Open Dialogue Message Window; Fade In from Black (47); Engine Action #89; Close Dialogue Sub-Window (5); Engine Action #89; Close Dialogue Sub-Window (5); Engine Action #9; Engine Action #221; Engine Action #128; Engine Action #83; Warp Room -> Submap 255 at (254,204) facing 204 |

---

### Submap Layer `vj03_02` (Index 2)

- **Map Number (`mapno`)**: `2`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `5`)
- **Entity Count (`okaz`)**: `6` Objects | **Script Count (`evkaz`)**: `17` Scripts

#### Complete Physical Entity Inventory (6 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(83, 181)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[01]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(83, 188)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | Rest Device / Fire | **Inn Bed / Recovery Device** | `0` | `(84, 160)` | `0x0` | Frame 12 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | Rest Device / Fire | **Inn Bed / Recovery Device** | `0` | `(84, 160)` | `0x0` | Frame 13 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[04]` | Rest Device / Fire | **Inn Bed / Recovery Device** | `0` | `(84, 164)` | `0x0` | Frame 12 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[05]` | Rest Device / Fire | **Inn Bed / Recovery Device** | `0` | `(84, 164)` | `0x0` | Frame 13 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(83, 181)` to `(86, 182)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[01]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(83, 188)` to `(86, 189)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[02]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(84, 160)` with state parameter `12`.
- **`obj[03]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(84, 160)` with state parameter `13`.
- **`obj[04]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(84, 164)` with state parameter `12`.
- **`obj[05]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(84, 164)` with state parameter `13`.


#### Complete Bytecode Script Catalog (17 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `128 (Loop)` | Player within Box [42..54, 2..33] AND Condition Check #71 AND Story Flag 1 (mask 255) SET | Warp Room -> Submap 1 at (9,4) |
| `ev[01]` | `128 (Loop)` | Player within Box [136..148, 2..33] AND Condition Check #71 AND Story Flag 1 (mask 255) SET | Warp Room -> Submap 1 at (9,4) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [140..144, 2..76] AND Condition Check #77 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 202]; Fade In from Black (255) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [46..50, 2..76] AND Condition Check #77 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 42]; Fade In from Black (255) |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [68..69, 2..197] AND Condition Check #202 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 93]; Engine Action #53 |
| `ev[05]` | `1 (Action / Talk)` | Player within Box [123..124, 2..197] AND Condition Check #202 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 151]; Engine Action #53 |
| `ev[06]` | `1 (Action / Talk)` | Player within Box [153..154, 2..25] AND Condition Check #33 AND Story Flag 3 (mask 255) SET | Warp Map Transition (2, 0, 33, 195, 255) |
| `ev[07]` | `1 (Action / Talk)` | Player within Box [36..37, 2..25] AND Condition Check #33 AND Story Flag 2 (mask 255) SET | Warp Map Transition (2, 0, 151, 150, 255) |
| `ev[08]` | `1 (Action / Talk)` | Player within Box [93..99, 2..124] AND Condition Check #129 AND Story Flag 1 (mask 255) SET | Place Scenery Structure (5); Engine Action #9; Engine Action #9; Open Dialogue Message Window; Branch on Choice (49, 255) |
| `ev[09]` | `2 (Map Init)` | Treasure Byte 8 Bit 8 FRESH (Unopened) | Make obj[0] Hidden (disp = 0); Screen Fade Transition (47, 255, 254) |
| `ev[10]` | `2 (Map Init)` | Treasure Byte 8 Bit 8 LOOTED | Make obj[0] Hidden (disp = 0); Close Dialogue Window; Teleport obj[255] to (254,204) |
| `ev[11]` | `1 (Action / Talk)` | Treasure Byte 8 Bit 8 FRESH (Unopened) AND Target Inspected is obj[10] | Make obj[1] Hidden (disp = 0); Screen Fade Transition (0, 11, 47); Jump to Bytecode Offset (4, 7); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (1); Exit to World Map (0, 64, 32); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,8) facing 8; Warp Room -> Submap 1 at (11,0) facing 10; Teleport obj[255] to (254,255) |
| `ev[12]` | `2 (Map Init)` | Treasure Byte 8 Bit 16 FRESH (Unopened) | Make obj[0] Hidden (disp = 0); Display Dialogue Box [Bank: 47, MsgID: 255] |
| `ev[13]` | `2 (Map Init)` | Treasure Byte 8 Bit 16 LOOTED | Make obj[0] Hidden (disp = 0); Place Scenery Structure (47) |
| `ev[14]` | `1 (Action / Talk)` | Treasure Byte 8 Bit 16 FRESH (Unopened) AND Target Inspected is obj[12] | Make obj[1] Hidden (disp = 0); Display Dialogue Box [Bank: 0, MsgID: 13]; Teleport obj[101] to (4,7); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (1); Exit to World Map (0, 78, 16); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,8) facing 16; Warp Room -> Submap 1 at (13,0) facing 12; Teleport obj[255] to (254,255) |
| `ev[15]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Open Dialogue Sub-Window (0); Open Dialogue Message Window |
| `ev[16]` | `1 (Action / Talk)` | Target Inspected is obj[8] | Open Dialogue Sub-Window (0); Open Dialogue Message Window |

---



## Location Map: `vj04`

- **Master Map Container**: `vj04.json`
- **Submap Layer Files**: vj04_00.json, vj04_01.json
- **Collision Grid Files**: vj04_map_00.json
- **Sprite Animation Bundles**: vj04_00_obj.json
- **Submap Room Count**: 1

### Submap Layer `vj04_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `5`)
- **Entity Count (`okaz`)**: `37` Objects | **Script Count (`evkaz`)**: `33` Scripts

#### Complete Physical Entity Inventory (37 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 0)** | `0` | `(157, 83)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 1)** | `0` | `(157, 83)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(155, 62)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | NPC / Actor | **Actor ID 64615** | `64615` | `(142, 129)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | NPC / Actor | **Actor ID 64615** | `64615` | `(146, 129)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | NPC / Actor | **Actor ID 64615** | `64615` | `(139, 131)` | `0x0` | Up (North) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | NPC / Actor | **Actor ID 64615** | `64615` | `(139, 135)` | `0x0` | Up (North) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Prop / Scenery | **Prop ID 64613** | `64613` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Prop / Scenery | **Prop ID 64613** | `64613` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Prop / Scenery | **Prop ID 64613** | `64613` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Prop / Scenery | **Prop ID 64613** | `64613` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Prop / Scenery | **Prop ID 64616** | `64616` | `(139, 129)` | `0x0` | Frame 17 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | Prop / Scenery | **Prop ID 64616** | `64616` | `(139, 132)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | Prop / Scenery | **Prop ID 64616** | `64616` | `(145, 129)` | `0x0` | Frame 10 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | Prop / Scenery | **Prop ID 64616** | `64616` | `(147, 132)` | `0x0` | Frame 11 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[15]` | Trigger / Hitbox | **Hitbox Zone (3x5)** | `0` | `(138, 126)` | `2x4` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[16]` | Trigger / Hitbox | **Hitbox Zone (5x4)** | `0` | `(137, 131)` | `4x3` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[17]` | Trigger / Hitbox | **Hitbox Zone (6x2)** | `0` | `(144, 128)` | `5x1` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[18]` | Trigger / Hitbox | **Hitbox Zone (5x4)** | `0` | `(145, 131)` | `4x3` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[19]` | NPC / Actor | **Actor ID 64615** | `64615` | `(14, 44)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[20]` | NPC / Actor | **Actor ID 64615** | `64615` | `(18, 44)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[21]` | NPC / Actor | **Actor ID 64615** | `64615` | `(11, 42)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[22]` | NPC / Actor | **Actor ID 64615** | `64615` | `(21, 42)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[23]` | Prop / Scenery | **Prop ID 64613** | `64613` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[24]` | Prop / Scenery | **Prop ID 64613** | `64613` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[25]` | Prop / Scenery | **Prop ID 64613** | `64613` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[26]` | Prop / Scenery | **Prop ID 64613** | `64613` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[27]` | Prop / Scenery | **Prop ID 64616** | `64616` | `(14, 38)` | `0x0` | Frame 16 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[28]` | Prop / Scenery | **Prop ID 64616** | `64616` | `(11, 36)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[29]` | Prop / Scenery | **Prop ID 64616** | `64616` | `(21, 37)` | `0x0` | Frame 11 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[30]` | Prop / Scenery | **Prop ID 64616** | `64616` | `(21, 33)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[31]` | Trigger / Hitbox | **Hitbox Zone (3x5)** | `0` | `(13, 37)` | `2x4` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[32]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(11, 35)` | `2x2` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[33]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(9, 36)` | `2x2` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[34]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(19, 36)` | `2x2` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[35]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(21, 37)` | `2x2` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[36]` | Trigger / Hitbox | **Hitbox Zone (6x4)** | `0` | `(20, 31)` | `5x3` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(157, 83)` with state parameter `0`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(157, 83)` with state parameter `1`.
- **`obj[02]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(155, 62)` to `(158, 63)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[03]` (Object 64615)**: Positioned at tile `(142, 129)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Object 64615)**: Positioned at tile `(146, 129)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Object 64615)**: Positioned at tile `(139, 131)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[06]` (Object 64615)**: Positioned at tile `(139, 135)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[07]` (Prop: Object 64613)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[08]` (Prop: Object 64613)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[09]` (Prop: Object 64613)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[10]` (Prop: Object 64613)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[11]` (Prop: Object 64616)**: Environmental world dressing prop placed at tile `(139, 129)`. Solid collision is set to `128`.
- **`obj[12]` (Prop: Object 64616)**: Environmental world dressing prop placed at tile `(139, 132)`. Solid collision is set to `128`.
- **`obj[13]` (Prop: Object 64616)**: Environmental world dressing prop placed at tile `(145, 129)`. Solid collision is set to `128`.
- **`obj[14]` (Prop: Object 64616)**: Environmental world dressing prop placed at tile `(147, 132)`. Solid collision is set to `128`.
- **`obj[15]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `5` tiles high from `(138, 126)` to `(140, 130)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[16]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `4` tiles high from `(137, 131)` to `(141, 134)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[17]` (Hitbox Zone)**: Bounding trigger area covering `6` tiles wide by `2` tiles high from `(144, 128)` to `(149, 129)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[18]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `4` tiles high from `(145, 131)` to `(149, 134)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[19]` (Object 64615)**: Positioned at tile `(14, 44)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[20]` (Object 64615)**: Positioned at tile `(18, 44)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[21]` (Object 64615)**: Positioned at tile `(11, 42)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[22]` (Object 64615)**: Positioned at tile `(21, 42)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[23]` (Prop: Object 64613)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[24]` (Prop: Object 64613)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[25]` (Prop: Object 64613)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[26]` (Prop: Object 64613)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[27]` (Prop: Object 64616)**: Environmental world dressing prop placed at tile `(14, 38)`. Solid collision is set to `128`.
- **`obj[28]` (Prop: Object 64616)**: Environmental world dressing prop placed at tile `(11, 36)`. Solid collision is set to `128`.
- **`obj[29]` (Prop: Object 64616)**: Environmental world dressing prop placed at tile `(21, 37)`. Solid collision is set to `128`.
- **`obj[30]` (Prop: Object 64616)**: Environmental world dressing prop placed at tile `(21, 33)`. Solid collision is set to `128`.
- **`obj[31]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `5` tiles high from `(13, 37)` to `(15, 41)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[32]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(11, 35)` to `(13, 37)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[33]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(9, 36)` to `(11, 38)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[34]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(19, 36)` to `(21, 38)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[35]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(21, 37)` to `(23, 39)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[36]` (Hitbox Zone)**: Bounding trigger area covering `6` tiles wide by `4` tiles high from `(20, 31)` to `(25, 34)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (33 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `128 (Loop)` | Player within Box [80..104, 2..109] AND Condition Check #127 | Warp Room -> Submap 1 at (9,10) |
| `ev[01]` | `128 (Loop)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 223 (bit 2) SET AND Player within Box [133..160, 2..109] AND Condition Check #122 | Warp Room -> Submap 1 at (9,10) |
| `ev[02]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 223 (bit 2) SET AND Player within Box [133..160, 2..109] AND Condition Check #141 | Warp Room -> Submap 1 at (9,10) |
| `ev[03]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 223 (bit 2) CLEAR AND Player within Box [133..160, 2..109] AND Condition Check #141 | Warp Room -> Submap 1 at (9,10) |
| `ev[04]` | `128 (Loop)` | Player within Box [1..30, 2..16] AND Condition Check #37 AND Story Flag 143 (bit 1) CLEAR AND Story Flag 220 (bit 1) CLEAR | Warp Room -> Submap 1 at (9,4) |
| `ev[05]` | `128 (Loop)` | Player within Box [1..30, 2..16] AND Condition Check #37 AND Story Flag 143 (bit 1) SET AND Story Flag 220 (bit 1) SET | Warp Room -> Submap 1 at (9,4) |
| `ev[06]` | `128 (Loop)` | Player within Box [60..93, 2..65] AND Condition Check #90 AND Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) SET | Warp Room -> Submap 1 at (9,4) |
| `ev[07]` | `128 (Loop)` | Player within Box [60..93, 2..65] AND Condition Check #90 AND Story Flag 143 (bit 1) CLEAR AND Story Flag 220 (bit 1) CLEAR | Warp Room -> Submap 1 at (9,4) |
| `ev[08]` | `128 (Loop)` | Player within Box [201..238, 2..16] AND Condition Check #60 | Warp Room -> Submap 1 at (9,4) |
| `ev[09]` | `1 (Action / Talk)` | Player within Box [94..98, 2..105] AND Condition Check #107 AND Story Flag 1 (mask 255) SET | Warp Map Transition (2, 0, 42, 215, 255) |
| `ev[10]` | `1 (Action / Talk)` | Player within Box [142..146, 2..105] AND Condition Check #107 AND Story Flag 1 (mask 255) SET | Warp Map Transition (2, 0, 198, 215, 255) |
| `ev[11]` | `1 (Action / Talk)` | Player within Box [14..18, 2..13] AND Party Formation Check AND Story Flag 1 (mask 255) SET | Warp Map Transition (2, 0, 33, 89, 255) |
| `ev[12]` | `1 (Action / Talk)` | Player within Box [82..86, 2..61] AND Condition Check #63 AND Story Flag 1 (mask 255) SET | Warp Map Transition (2, 1, 60, 113, 255) |
| `ev[13]` | `1 (Action / Talk)` | Player within Box [117..123, 2..42] AND Condition Check #43 AND Story Flag 1 (mask 255) SET | Warp Map Transition (2, 2, 188, 141, 255) |
| `ev[14]` | `1 (Action / Talk)` | Player within Box [222..226, 2..12] AND Party Formation Check AND Story Flag 1 (mask 255) SET | Warp Map Transition (2, 1, 188, 221, 255) |
| `ev[15]` | `2 (Map Init)` | Treasure Byte 9 Bit 1 FRESH (Unopened) | Make obj[0] Hidden (disp = 0); Reset Camera Tracking (47) |
| `ev[16]` | `2 (Map Init)` | Treasure Byte 9 Bit 1 LOOTED | Make obj[0] Hidden (disp = 0); Engine Action #9; Teleport obj[255] to (254,204) |
| `ev[17]` | `1 (Action / Talk)` | Treasure Byte 9 Bit 1 FRESH (Unopened) AND Target Inspected is obj[8] | Make obj[1] Hidden (disp = 0); Reset Camera Tracking (0); Engine Action #9; Teleport obj[101] to (4,7); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (1); Exit to World Map (0, 54, 16); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,9) facing West (Left); Warp Room -> Submap 1 at (9,0) facing 8; Teleport obj[255] to (254,255) |
| `ev[18]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Open Dialogue Sub-Window (0); Open Dialogue Message Window |
| `ev[19]` | `2 (Map Init)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR | Dismiss Emotion Bubble (2); Open Dialogue Message Window |
| `ev[20]` | `1 (Action / Talk)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR | Open Choice Selection Menu (1, 43); Open Dialogue Message Window; Engine Action #5; Launch Tactical War Battle (1); Engine Action #61; Warp Room -> Submap 5 at (0,0) facing 8; Dismiss Emotion Bubble (61); Warp Room -> Submap 5 at (0,2) facing 44; Dismiss Emotion Bubble (61); Warp Room -> Submap 5 at (0,1) facing 21; Dismiss Emotion Bubble (61); Warp Room -> Submap 5 at (0,2) facing 24; Dismiss Emotion Bubble (61); Warp Room -> Submap 5 at (0,1) facing 37; Dismiss Emotion Bubble (13); Engine Action #5; Engine Action #9; Warp Room -> Submap 98 at (70,255) facing 254 |
| `ev[21]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Inventory Holds Item #1 [Medicine] | Close Dialogue Window; Warp to Castle HQ (2, 40, 37); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[22]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Player Y within Range [39..40] | Wait for Audio / Window Sync (3); Close Dialogue Window; Exit to World Map (2, 40, 255) |
| `ev[23]` | `2 (Map Init)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 223 (bit 2) CLEAR | Make obj[0] Hidden (disp = 0); Close Dialogue Window; Open Dialogue Message Window; Display Dialogue Box [Bank: 0, MsgID: 13]; Open Dialogue Message Window; Animate Door Open; Open Shop Menu #6 (Type: 11); Open Shop Menu #6 (Type: 12); Open Shop Menu #6 (Type: 13); Open Shop Menu #6 (Type: 14); Teleport obj[255] to (254,204) |
| `ev[24]` | `2 (Map Init)` | Story Flag 220 (bit 1) SET | Make obj[1] Hidden (disp = 0); Close Dialogue Window; Warp Room -> Submap 1 at (13,1) facing 14; Warp Room -> Submap 1 at (20,1) facing 21; Warp Room -> Submap 1 at (23,1) facing 24; Warp Room -> Submap 1 at (26,47) facing 255 |
| `ev[25]` | `2 (Map Init)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 223 (bit 2) SET | Make obj[1] Hidden (disp = 0); Show Dialogue Portrait (1, 16, 1); Change Portrait Expression (1); Display Speaker Name Box (0); Display Choice Selection (0, 20); Open Dialogue Message Window; Execute Choice Result (0); Set Story Flag (0, 23); Open Dialogue Message Window; Close Dialogue Sub-Window (0); Clear Dialogue Sub-Window; Open Dialogue Message Window; Fade In from Black (47) |
| `ev[26]` | `1 (Action / Talk)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 223 (bit 2) CLEAR AND Player within Box [141..157, 2..115] AND Condition Check #116 | Launch Tactical War Battle (1); Set Render Priority (pri) (0, 144); Show Character Dialogue Portrait (8, 46, 3); Place Scenery Structure (1); Warp to Castle HQ (14, 1, 47); Load Sound Bank into Memory (1, 12); Warp Town -> Area 73 Map 20 Submap 72 at (0,12); Set Entity Movement Speed (4, 56); Close Dialogue Window; Open Dialogue Message Window; Warp Town -> Area 2 Map 0 Submap 2 at (9,255); Set Animation Pose (12, 0); Warp to Castle HQ (2, 0, 2); Engine Action #9; Set Animation Pose (13, 0); Warp Town -> Area 2 Map 0 Submap 5 at (8,255); Set Animation Pose (14, 0); Warp to Castle HQ (2, 0, 5); Reset Camera Tracking (255); Walk obj[54] to (0,1); Make obj[106] Hidden (disp = 0); Close Dialogue Window; Show Dialogue Portrait (106, 12, 16); Set Character Quest Milestone (13, 17); Set Character Quest Milestone (14, 18); Engine Action #89; Show Dialogue Portrait (2, 1, 89); Dismiss Dialogue Portrait; Warp Town -> Area 1 Map 89 Submap 17 at (2,1); Engine Action #89; Display Speaker Name Box (2); Warp Room -> Submap 11 at (1,12) facing West (Left); Place Scenery Structure (1); Animate Door Open; Open Dialogue Message Window; Show Dialogue Portrait (0, 16, 0); Change Portrait Expression (0); Display Speaker Name Box (47); Engine Action #89; Show Dialogue Portrait (5, 89, 15); Engine Action #5; Engine Action #9; Engine Action #223; Warp Town -> Area 83 Map 1 Submap 240 at (255,254) |
| `ev[27]` | `1 (Action / Talk)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 223 (bit 2) CLEAR AND Player within Box [107..110, 2..129] AND Condition Check #140 | Launch Tactical War Battle (1); Set Render Priority (pri) (0, 128); Open Choice Selection Menu (9, 46); Warp to Castle HQ (11, 2, 3); Display Dialogue Box [Bank: 2, MsgID: 47]; Load Sound Bank into Memory (1, 13); Warp Town -> Area 73 Map 20 Submap 72 at (0,13); Set Entity Movement Speed (4, 56); Place Scenery Structure (0); Warp to Castle HQ (3, 1, 2); Engine Action #9; Set Animation Pose (14, 0); Warp to Castle HQ (3, 0, 2); Engine Action #9; Set Animation Pose (11, 0); Warp to Castle HQ (6, 1, 2); Engine Action #9; Set Animation Pose (12, 0); Warp to Castle HQ (6, 0, 2); Engine Action #9; Walk obj[54] to (0,1); Make obj[106] Hidden (disp = 0); Close Dialogue Window; Show Dialogue Portrait (106, 12, 16); Set Character Quest Milestone (13, 17); Set Character Quest Milestone (14, 18); Engine Action #89; Show Dialogue Portrait (2, 2, 89); Dismiss Dialogue Portrait; Warp Town -> Area 2 Map 89 Submap 17 at (2,2); Engine Action #89; Display Speaker Name Box (2); Warp Town -> Area 1 Map 11 Submap 1 at (12,1); Place Scenery Structure (1); Animate Door Open; Open Dialogue Message Window; Show Dialogue Portrait (0, 16, 0); Change Portrait Expression (0); Display Speaker Name Box (47); Engine Action #89; Show Dialogue Portrait (5, 89, 15); Engine Action #5; Engine Action #9; Engine Action #223; Warp Town -> Area 83 Map 1 Submap 240 at (255,254) |
| `ev[28]` | `128 (Loop)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 223 (bit 2) CLEAR AND Inventory Holds Item #1 [Medicine] | Warp Room -> Submap 1 at (15,64); Toggle Random Encounters (1) |
| `ev[29]` | `2 (Map Init)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 223 (bit 4) CLEAR | Make obj[0] Hidden (disp = 0); Fade Out to Black (0); Display Chapter Text (0); Display Emotion Bubble (0, 30); Open Shop Menu #6 (Type: 27); Open Shop Menu #6 (Type: 28); Open Shop Menu #6 (Type: 29); Open Shop Menu #6 (Type: 30); Teleport obj[255] to (254,204) |
| `ev[30]` | `2 (Map Init)` | Story Flag 220 (bit 1) SET | Make obj[1] Hidden (disp = 0); Fade Out to Black (1); Display Chapter Text (1); Display Emotion Bubble (1, 30); Teleport obj[255] to (254,204) |
| `ev[31]` | `2 (Map Init)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 223 (bit 4) SET | Make obj[1] Hidden (disp = 0); Warp Room -> Submap 1 at (32,1); Return to Previous Memory Map (1); Return Warp to Castle Base (0, 35); Open Dialogue Message Window; Launch Tactical War Battle (0); Toggle Random Encounters (0); Open Save Crystal Menu (MSaveInit); Open Dialogue Message Window; Engine Action #39; Open Dialogue Message Window; Engine Action #40; Open Dialogue Message Window; Award Potch Loot (+42 Potch); Open Dialogue Message Window; Open Shop Menu #44 (Type: 0); Teleport obj[255] to (254,204) |
| `ev[32]` | `1 (Action / Talk)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 223 (bit 4) CLEAR AND Player within Box [3..29, 2..25] AND Condition Check #26 | Set Render Priority (pri) (0, 16); Start Boss Battle #8 (BGM: 72); Warp Room -> Submap 2 at (73,20) facing 72; Open Dialogue Message Window; Fade Out to Black (49); Exit to World Map (56, 27, 0); Warp Town -> Area 2 Map 0 Submap 4 at (9,255); Set Animation Pose (28, 0); Warp to Castle HQ (2, 0, 4); Engine Action #9; Set Animation Pose (29, 0); Warp Town -> Area 4 Map 0 Submap 0 at (9,255); Set Animation Pose (30, 0); Warp to Castle HQ (4, 0, 0); Engine Action #9; Walk obj[46] to (106,27); Warp Room -> Submap 106 at (28,32); Set Character Quest Milestone (29, 33); Set Character Quest Milestone (30, 34); Engine Action #89; Warp Room -> Submap 2 at (1,89); Warp Map Transition (2, 1, 89, 33, 2); Warp to Castle HQ (89, 34, 2); Warp Town -> Area 1 Map 27 Submap 1 at (28,1); Display Emotion Bubble (1, 30); Open Dialogue Message Window; Warp Room -> Submap 0 at (32,0); Return to Previous Memory Map (0); Return Warp to Castle Base (47, 89); Warp Room -> Submap 5 at (89,31); Engine Action #5; Engine Action #9; Engine Action #223; Exit to World Map (83, 1, 2) |

---



## Location Map: `vj05`

- **Master Map Container**: `vj05.json`
- **Submap Layer Files**: vj05_00.json, vj05_01.json
- **Collision Grid Files**: vj05_map_00.json
- **Sprite Animation Bundles**: vj05_00_obj.json
- **Submap Room Count**: 3

### Submap Layer `vj05_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `5`)
- **Entity Count (`okaz`)**: `23` Objects | **Script Count (`evkaz`)**: `34` Scripts

#### Complete Physical Entity Inventory (23 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 11)** | `0` | `(90, 203)` | `0x0` | Frame 11 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | Rest Device / Fire | **Inn Bed / Recovery Device** | `0` | `(90, 203)` | `0x0` | Frame 12 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | World Device | **Mechanism (ano 11)** | `0` | `(90, 208)` | `0x0` | Frame 11 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | Rest Device / Fire | **Inn Bed / Recovery Device** | `0` | `(90, 208)` | `0x0` | Frame 12 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[04]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(113, 207)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | Trigger / Hitbox | **Hitbox Zone (11x7)** | `0` | `(136, 36)` | `10x6` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | NPC / Actor | **Actor ID 64615** | `64615` | `(148, 85)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | NPC / Actor | **Actor ID 64615** | `64615` | `(148, 80)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | NPC / Actor | **Actor ID 64615** | `64615` | `(148, 75)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | NPC / Actor | **Actor ID 64615** | `64615` | `(148, 70)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Prop / Scenery | **Prop ID 64613** | `64613` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Prop / Scenery | **Prop ID 64613** | `64613` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | Prop / Scenery | **Prop ID 64613** | `64613` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | Prop / Scenery | **Prop ID 64613** | `64613` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | Prop / Scenery | **Prop ID 64616** | `64616` | `(142, 89)` | `0x0` | Up (North) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[15]` | Prop / Scenery | **Prop ID 64616** | `64616` | `(146, 87)` | `0x0` | Frame 16 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[16]` | Prop / Scenery | **Prop ID 64616** | `64616` | `(150, 85)` | `0x0` | Frame 17 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[17]` | Prop / Scenery | **Prop ID 64616** | `64616` | `(153, 90)` | `0x0` | Frame 11 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[18]` | Trigger / Hitbox | **Hitbox Zone (6x2)** | `0` | `(138, 88)` | `5x1` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[19]` | Trigger / Hitbox | **Hitbox Zone (3x5)** | `0` | `(145, 86)` | `2x4` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[20]` | Trigger / Hitbox | **Hitbox Zone (3x5)** | `0` | `(149, 82)` | `2x4` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[21]` | Trigger / Hitbox | **Hitbox Zone (4x3)** | `0` | `(151, 89)` | `3x2` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[22]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(153, 90)` | `2x2` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(90, 203)` with state parameter `11`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(90, 203)` with state parameter `12`.
- **`obj[02]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(90, 208)` with state parameter `11`.
- **`obj[03]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(90, 208)` with state parameter `12`.
- **`obj[04]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(113, 207)` to `(115, 209)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[05]` (Hitbox Zone)**: Bounding trigger area covering `11` tiles wide by `7` tiles high from `(136, 36)` to `(146, 42)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[06]` (Object 64615)**: Positioned at tile `(148, 85)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[07]` (Object 64615)**: Positioned at tile `(148, 80)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[08]` (Object 64615)**: Positioned at tile `(148, 75)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[09]` (Object 64615)**: Positioned at tile `(148, 70)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[10]` (Prop: Object 64613)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[11]` (Prop: Object 64613)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[12]` (Prop: Object 64613)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[13]` (Prop: Object 64613)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[14]` (Prop: Object 64616)**: Environmental world dressing prop placed at tile `(142, 89)`. Solid collision is set to `128`.
- **`obj[15]` (Prop: Object 64616)**: Environmental world dressing prop placed at tile `(146, 87)`. Solid collision is set to `128`.
- **`obj[16]` (Prop: Object 64616)**: Environmental world dressing prop placed at tile `(150, 85)`. Solid collision is set to `128`.
- **`obj[17]` (Prop: Object 64616)**: Environmental world dressing prop placed at tile `(153, 90)`. Solid collision is set to `128`.
- **`obj[18]` (Hitbox Zone)**: Bounding trigger area covering `6` tiles wide by `2` tiles high from `(138, 88)` to `(143, 89)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[19]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `5` tiles high from `(145, 86)` to `(147, 90)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[20]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `5` tiles high from `(149, 82)` to `(151, 86)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[21]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `3` tiles high from `(151, 89)` to `(154, 91)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[22]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(153, 90)` to `(155, 92)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (34 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `128 (Loop)` | Player within Box [25..37, 2..68] AND Condition Check #84 AND Story Flag 0 (mask 255) SET | Warp Room -> Submap 0 at (9,3) |
| `ev[01]` | `128 (Loop)` | Player within Box [32..48, 2..185] AND Condition Check #200 | Warp Room -> Submap 0 at (9,2) |
| `ev[02]` | `128 (Loop)` | Player within Box [136..152, 2..142] AND Condition Check #156 | Warp Room -> Submap 0 at (9,2) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [29..30, 2..190] AND Condition Check #201 AND Story Flag 2 (mask 255) SET | Warp Map Transition (3, 2, 145, 33, 255) |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [156..157, 2..147] AND Condition Check #160 AND Story Flag 3 (mask 255) SET | Warp Map Transition (3, 2, 45, 33, 255) |
| `ev[05]` | `1 (Action / Talk)` | Player within Box [31..35, 2..92] AND Condition Check #93 AND Story Flag 0 (mask 255) SET | Warp Map Transition (3, 0, 16, 17, 255) |
| `ev[06]` | `1 (Action / Talk)` | Player within Box [142..146, 2..160] AND Condition Check #161 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 36]; Clear Dialogue Sub-Window |
| `ev[07]` | `1 (Action / Talk)` | Player within Box [38..42, 2..204] AND Condition Check #205 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 158]; Clear Dialogue Sub-Window |
| `ev[08]` | `1 (Action / Talk)` | Player within Box [78..82, 2..80] AND Condition Check #81 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 76]; Engine Action #121 |
| `ev[09]` | `1 (Action / Talk)` | Player within Box [74..78, 2..118] AND Condition Check #119 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 80]; Award Potch Currency (255,254) |
| `ev[10]` | `1 (Action / Talk)` | Player within Box [100..101, 2..146] AND Condition Check #154 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 122]; Make Object Visible (disp = 1) (255) |
| `ev[11]` | `1 (Action / Talk)` | Player within Box [118..119, 2..89] AND Condition Check #98 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 98]; Engine Action #150 |
| `ev[12]` | `1 (Action / Talk)` | Player within Box [145..151, 2..76] AND Condition Check #77 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 149]; Set Entity Movement Speed (255, 254) |
| `ev[13]` | `1 (Action / Talk)` | Player within Box [146..152, 2..52] AND Condition Check #53 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 148]; Engine Action #80 |
| `ev[14]` | `1 (Action / Talk)` | Player within Box [146..150, 2..116] AND Condition Check #117 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 144]; Engine Action #141 |
| `ev[15]` | `1 (Action / Talk)` | Player within Box [142..146, 2..138] AND Condition Check #139 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 148]; Engine Action #113 |
| `ev[16]` | `1 (Action / Talk)` | Player within Box [38..42, 2..182] AND Condition Check #183 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 126]; Engine Action #223 |
| `ev[17]` | `1 (Action / Talk)` | Player within Box [124..128, 2..226] AND Condition Check #227 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 40]; Engine Action #185 |
| `ev[18]` | `2 (Map Init)` | Treasure Byte 8 Bit 32 FRESH (Unopened) | Make obj[0] Hidden (disp = 0); Reset Camera Tracking (47) |
| `ev[19]` | `2 (Map Init)` | Treasure Byte 8 Bit 32 LOOTED | Make obj[0] Hidden (disp = 0); Engine Action #9; Teleport obj[255] to (254,204) |
| `ev[20]` | `1 (Action / Talk)` | Treasure Byte 8 Bit 32 FRESH (Unopened) AND Target Inspected is obj[8] | Make obj[1] Hidden (disp = 0); Reset Camera Tracking (0); Engine Action #9; Teleport obj[101] to (4,7); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (1); Exit to World Map (0, 21, 0); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,8) facing 32; Warp Room -> Submap 1 at (9,0) facing 8; Teleport obj[255] to (254,255) |
| `ev[21]` | `2 (Map Init)` | Treasure Byte 8 Bit 64 FRESH (Unopened) | Make obj[0] Hidden (disp = 0); Screen Fade Transition (47, 255, 254) |
| `ev[22]` | `2 (Map Init)` | Treasure Byte 8 Bit 64 LOOTED | Make obj[0] Hidden (disp = 0); Close Dialogue Window; Teleport obj[255] to (254,204) |
| `ev[23]` | `1 (Action / Talk)` | Treasure Byte 8 Bit 64 FRESH (Unopened) AND Target Inspected is obj[10] | Make obj[1] Hidden (disp = 0); Screen Fade Transition (0, 11, 47); Jump to Bytecode Offset (4, 7); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (1); Exit to World Map (0, 23, 0); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,8) facing 64; Warp Room -> Submap 1 at (11,0) facing 10; Teleport obj[255] to (254,255) |
| `ev[24]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Open Dialogue Sub-Window (0); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[25]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Open Dialogue Sub-Window (0); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[26]` | `2 (Map Init)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 223 (bit 32) CLEAR | Make obj[0] Hidden (disp = 0); Animate Door Open; Open Dialogue Message Window; Show Dialogue Portrait (0, 16, 0); Change Portrait Expression (43); Animate Door Open; Engine Action #6; Open Shop Menu #6 (Type: 15); Open Shop Menu #6 (Type: 16); Open Shop Menu #6 (Type: 17); Teleport obj[255] to (254,204) |
| `ev[27]` | `2 (Map Init)` | Story Flag 220 (bit 1) SET | Make obj[1] Hidden (disp = 0); Animate Door Open; Warp Room -> Submap 1 at (16,1) facing 17; Teleport obj[255] to (254,204) |
| `ev[28]` | `2 (Map Init)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 223 (bit 32) SET | Make obj[1] Hidden (disp = 0); Display Speaker Name Box (1); Display Choice Selection (1, 20); Warp Room -> Submap 0 at (22,0) facing 23; Open Dialogue Message Window; Close Dialogue Sub-Window (0); Clear Dialogue Sub-Window; Open Dialogue Message Window; Fade In from Black (0); Fade Out to Black (0); Display Chapter Text (0); Display Emotion Bubble (0, 30); Teleport obj[255] to (254,204) |
| `ev[29]` | `1 (Action / Talk)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 223 (bit 32) CLEAR AND Player within Box [145..151, 2..105] AND Condition Check #106 | Set Render Priority (pri) (0, 148); Make Object Hidden (disp = 0) (8); Warp to Castle HQ (0, 1, 72); Warp Room -> Submap 2 at (73,20) facing 72; Open Dialogue Message Window; Animate Door Open; Set Combat Battle BGM (20); Make obj[36] Hidden (disp = 0); Exit to World Map (36, 8, 36); Dismiss Dialogue Portrait; Launch Tactical War Battle (32); Teleport obj[54] to (0,4); Engine Action #54; Open Dialogue Message Window; Reset Camera Tracking (54); Open Dialogue Message Window; Dismiss Dialogue Portrait; Engine Action #54; Open Dialogue Message Window; Warp Map Transition (9, 223, 32, 83, 1); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[30]` | `128 (Loop)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 223 (bit 32) CLEAR AND Inventory Holds Item #4 [Throat Drops] | Set Animation Pose (14, 0); Warp Town -> Area 4 Map 1 Submap 2 at (9,46); Set Character Quest Milestone (14, 18); Engine Action #89; Display Speaker Name Box (2); Open Dialogue Message Window; Warp Room -> Submap 0 at (18,47) facing 89; Display Speaker Name Box (5); Engine Action #89; Display Speaker Name Box (5); Toggle Random Encounters (4) |
| `ev[31]` | `128 (Loop)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 223 (bit 32) CLEAR AND Inventory Holds Item #8 [Fire Wall] | Set Animation Pose (15, 0); Warp Town -> Area 2 Map 1 Submap 4 at (9,46); Set Character Quest Milestone (15, 19); Engine Action #89; Display Choice Selection (2, 0); Warp Room -> Submap 0 at (19,47) facing 89; Display Choice Selection (5, 89); Display Choice Selection (5, 37); Reset Camera Tracking (255) |
| `ev[32]` | `128 (Loop)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 223 (bit 32) CLEAR AND Inventory Holds Item #16 [Revenge Earth] | Set Animation Pose (16, 0); Warp to Castle HQ (4, 1, 2); Engine Action #9; Make obj[106] Hidden (disp = 0); Dismiss Dialogue Portrait; Branch on Choice (89, 20); Warp Town -> Area 0 Map 1 Submap 16 at (0,20); Teleport obj[89] to (20,5); Engine Action #89; Branch on Choice (5, 37); Dismiss Dialogue Portrait |
| `ev[33]` | `128 (Loop)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 223 (bit 32) CLEAR AND Inventory Holds Item #32 [Drinking Set] | Set Animation Pose (17, 0); Warp to Castle HQ (2, 1, 4); Engine Action #9; Make obj[106] Hidden (disp = 0); Change Portrait Expression (21); Engine Action #89; Execute Choice Result (2); Open Dialogue Message Window; Warp Room -> Submap 0 at (21,47) facing 89; Execute Choice Result (5); Engine Action #89; Execute Choice Result (5); Toggle Random Encounters (32) |

---

### Submap Layer `vj05_01` (Index 1)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `5`)
- **Entity Count (`okaz`)**: `45` Objects | **Script Count (`evkaz`)**: `33` Scripts

#### Complete Physical Entity Inventory (45 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 11)** | `0` | `(113, 149)` | `0x0` | Frame 11 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | Rest Device / Fire | **Inn Bed / Recovery Device** | `0` | `(113, 149)` | `0x0` | Frame 12 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | Trigger / Hitbox | **Hitbox Zone (5x2)** | `0` | `(131, 116)` | `4x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(59, 100)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(59, 93)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | Trigger / Hitbox | **Hitbox Zone (5x2)** | `0` | `(156, 40)` | `4x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(157, 33)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(155, 33)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(159, 33)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(92, 157)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(24, 149)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(58, 157)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | NPC / Actor | **Actor ID 64615** | `64615` | `(116, 105)` | `0x0` | Up (North) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | NPC / Actor | **Actor ID 64615** | `64615` | `(119, 106)` | `0x0` | Up (North) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | NPC / Actor | **Actor ID 64615** | `64615` | `(119, 110)` | `0x0` | Up (North) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[15]` | NPC / Actor | **Actor ID 64615** | `64615` | `(116, 111)` | `0x0` | Up (North) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[16]` | Prop / Scenery | **Prop ID 64613** | `64613` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[17]` | Prop / Scenery | **Prop ID 64613** | `64613` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[18]` | Prop / Scenery | **Prop ID 64613** | `64613` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[19]` | Prop / Scenery | **Prop ID 64613** | `64613` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[20]` | Prop / Scenery | **Prop ID 64616** | `64616` | `(109, 104)` | `0x0` | Frame 17 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[21]` | Prop / Scenery | **Prop ID 64616** | `64616` | `(113, 104)` | `0x0` | Frame 9 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[22]` | Prop / Scenery | **Prop ID 64616** | `64616` | `(114, 109)` | `0x0` | Frame 11 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[23]` | Prop / Scenery | **Prop ID 64616** | `64616` | `(110, 110)` | `0x0` | Frame 16 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[24]` | Trigger / Hitbox | **Hitbox Zone (3x5)** | `0` | `(108, 101)` | `2x4` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[25]` | Trigger / Hitbox | **Hitbox Zone (6x3)** | `0` | `(112, 103)` | `5x2` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[26]` | Trigger / Hitbox | **Hitbox Zone (4x3)** | `0` | `(112, 108)` | `3x2` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[27]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(114, 109)` | `2x2` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[28]` | Trigger / Hitbox | **Hitbox Zone (3x5)** | `0` | `(109, 109)` | `2x4` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[29]` | NPC / Actor | **Actor ID 64615** | `64615` | `(200, 130)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[30]` | NPC / Actor | **Actor ID 64615** | `64615` | `(202, 127)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[31]` | NPC / Actor | **Actor ID 64615** | `64615` | `(206, 127)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[32]` | NPC / Actor | **Actor ID 64615** | `64615` | `(208, 130)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[33]` | Prop / Scenery | **Prop ID 64613** | `64613` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[34]` | Prop / Scenery | **Prop ID 64613** | `64613` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[35]` | Prop / Scenery | **Prop ID 64613** | `64613` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[36]` | Prop / Scenery | **Prop ID 64613** | `64613` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[37]` | Prop / Scenery | **Prop ID 64616** | `64616` | `(201, 134)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[38]` | Prop / Scenery | **Prop ID 64616** | `64616` | `(200, 130)` | `0x0` | Frame 17 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[39]` | Prop / Scenery | **Prop ID 64616** | `64616` | `(207, 129)` | `0x0` | Frame 10 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[40]` | Prop / Scenery | **Prop ID 64616** | `64616` | `(208, 133)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[41]` | Trigger / Hitbox | **Hitbox Zone (6x3)** | `0` | `(197, 133)` | `5x2` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[42]` | Trigger / Hitbox | **Hitbox Zone (3x4)** | `0` | `(199, 128)` | `2x3` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[43]` | Trigger / Hitbox | **Hitbox Zone (6x2)** | `0` | `(206, 128)` | `5x1` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[44]` | Trigger / Hitbox | **Hitbox Zone (6x3)** | `0` | `(207, 132)` | `5x2` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(113, 149)` with state parameter `11`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(113, 149)` with state parameter `12`.
- **`obj[02]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `2` tiles high from `(131, 116)` to `(135, 117)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[03]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(59, 100)` to `(61, 101)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[04]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(59, 93)` to `(61, 94)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[05]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `2` tiles high from `(156, 40)` to `(160, 41)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[06]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(157, 33)` to `(159, 34)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[07]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(155, 33)` to `(157, 34)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[08]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(159, 33)` to `(161, 34)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[09]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(92, 157)` to `(94, 159)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[10]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(24, 149)` to `(26, 151)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[11]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(58, 157)` to `(60, 159)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[12]` (Object 64615)**: Positioned at tile `(116, 105)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[13]` (Object 64615)**: Positioned at tile `(119, 106)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[14]` (Object 64615)**: Positioned at tile `(119, 110)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[15]` (Object 64615)**: Positioned at tile `(116, 111)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[16]` (Prop: Object 64613)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[17]` (Prop: Object 64613)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[18]` (Prop: Object 64613)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[19]` (Prop: Object 64613)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[20]` (Prop: Object 64616)**: Environmental world dressing prop placed at tile `(109, 104)`. Solid collision is set to `128`.
- **`obj[21]` (Prop: Object 64616)**: Environmental world dressing prop placed at tile `(113, 104)`. Solid collision is set to `128`.
- **`obj[22]` (Prop: Object 64616)**: Environmental world dressing prop placed at tile `(114, 109)`. Solid collision is set to `128`.
- **`obj[23]` (Prop: Object 64616)**: Environmental world dressing prop placed at tile `(110, 110)`. Solid collision is set to `128`.
- **`obj[24]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `5` tiles high from `(108, 101)` to `(110, 105)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[25]` (Hitbox Zone)**: Bounding trigger area covering `6` tiles wide by `3` tiles high from `(112, 103)` to `(117, 105)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[26]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `3` tiles high from `(112, 108)` to `(115, 110)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[27]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(114, 109)` to `(116, 111)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[28]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `5` tiles high from `(109, 109)` to `(111, 113)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[29]` (Object 64615)**: Positioned at tile `(200, 130)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[30]` (Object 64615)**: Positioned at tile `(202, 127)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[31]` (Object 64615)**: Positioned at tile `(206, 127)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[32]` (Object 64615)**: Positioned at tile `(208, 130)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[33]` (Prop: Object 64613)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[34]` (Prop: Object 64613)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[35]` (Prop: Object 64613)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[36]` (Prop: Object 64613)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[37]` (Prop: Object 64616)**: Environmental world dressing prop placed at tile `(201, 134)`. Solid collision is set to `128`.
- **`obj[38]` (Prop: Object 64616)**: Environmental world dressing prop placed at tile `(200, 130)`. Solid collision is set to `128`.
- **`obj[39]` (Prop: Object 64616)**: Environmental world dressing prop placed at tile `(207, 129)`. Solid collision is set to `128`.
- **`obj[40]` (Prop: Object 64616)**: Environmental world dressing prop placed at tile `(208, 133)`. Solid collision is set to `128`.
- **`obj[41]` (Hitbox Zone)**: Bounding trigger area covering `6` tiles wide by `3` tiles high from `(197, 133)` to `(202, 135)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[42]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `4` tiles high from `(199, 128)` to `(201, 131)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[43]` (Hitbox Zone)**: Bounding trigger area covering `6` tiles wide by `2` tiles high from `(206, 128)` to `(211, 129)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[44]` (Hitbox Zone)**: Bounding trigger area covering `6` tiles wide by `3` tiles high from `(207, 132)` to `(212, 134)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (33 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `128 (Loop)` | Player within Box [49..98, 2..82] AND Condition Check #114 | Warp Room -> Submap 0 at (9,3) |
| `ev[01]` | `128 (Loop)` | Player within Box [177..199, 2..202] AND Condition Check #223 | Warp Room -> Submap 0 at (9,3) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [56..64, 2..116] AND Condition Check #122 AND Story Flag 0 (mask 255) SET | Warp Map Transition (3, 0, 84, 65, 255) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [184..192, 2..224] AND Condition Check #225 AND Story Flag 0 (mask 255) SET | Warp Map Transition (3, 0, 224, 17, 255) |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [194..198, 2..198] AND Condition Check #199 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 124]; Engine Action #217 |
| `ev[05]` | `1 (Action / Talk)` | Player within Box [122..126, 2..220] AND Condition Check #221 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 196]; Engine Action #201 |
| `ev[06]` | `1 (Action / Talk)` | Player within Box [120..128, 2..145] AND Condition Check #146 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 190]; Close Dialogue Sub-Window (255) |
| `ev[07]` | `1 (Action / Talk)` | Player within Box [52..56, 2..212] AND Condition Check #213 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 204]; Engine Action #99 |
| `ev[08]` | `1 (Action / Talk)` | Player within Box [202..206, 2..96] AND Condition Check #97 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 54]; Engine Action #209 |
| `ev[09]` | `1 (Action / Talk)` | Player within Box [175..176, 2..168] AND Condition Check #173 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 184]; Turn obj[255] facing 254 |
| `ev[10]` | `1 (Action / Talk)` | Player within Box [186..187, 2..44] AND Condition Check #53 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 177]; Engine Action #168 |
| `ev[11]` | `1 (Action / Talk)` | Player within Box [156..160, 2..22] AND Condition Check #23 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 40]; Engine Action #201 |
| `ev[12]` | `1 (Action / Talk)` | Player within Box [34..38, 2..22] AND Condition Check #23 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 144]; Engine Action #157 |
| `ev[13]` | `2 (Map Init)` | Treasure Byte 8 Bit 128 FRESH (Unopened) | Make obj[0] Hidden (disp = 0); Reset Camera Tracking (47) |
| `ev[14]` | `2 (Map Init)` | Treasure Byte 8 Bit 128 LOOTED | Make obj[0] Hidden (disp = 0); Engine Action #9; Teleport obj[255] to (254,204) |
| `ev[15]` | `1 (Action / Talk)` | Treasure Byte 8 Bit 128 FRESH (Unopened) AND Target Inspected is obj[8] | Make obj[1] Hidden (disp = 0); Reset Camera Tracking (0); Engine Action #9; Teleport obj[101] to (4,7); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (1); Exit to World Map (0, 34, 0); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,8) facing 128; Warp Room -> Submap 1 at (9,0) facing 8; Teleport obj[255] to (254,255) |
| `ev[16]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Open Dialogue Sub-Window (0); Open Dialogue Message Window |
| `ev[17]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Open Dialogue Sub-Window (0); Open Dialogue Message Window |
| `ev[18]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Open Dialogue Sub-Window (0); Open Dialogue Message Window |
| `ev[19]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Open Dialogue Sub-Window (0); Open Dialogue Message Window |
| `ev[20]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Open Dialogue Sub-Window (0); Open Dialogue Message Window |
| `ev[21]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Open Dialogue Sub-Window (0); Warp to Castle HQ (255, 254, 204) |
| `ev[22]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Open Dialogue Sub-Window (0); Exit to World Map (255, 254, 204) |
| `ev[23]` | `1 (Action / Talk)` | Target Inspected is obj[19] | Launch Tactical War Battle (1); Fade In from Black (1); Exit to World Map (73, 20, 40); Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 1 Map 2 Submap 1 at (3,73); Branch on Choice (41, 2); Open Dialogue Message Window; Warp Room -> Submap 0 at (54,0) facing West (Left); Recruit Invisible / Hitbox Trigger into Battle Slot 1; Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[24]` | `128 (Loop)` | Inventory Holds Item #1 [Medicine] | Warp Room -> Submap 0 at (13,44); Toggle Random Encounters (1) |
| `ev[25]` | `2 (Map Init)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 223 (bit 8) CLEAR | Make obj[0] Hidden (disp = 0); Branch on Choice (0, 21); Open Dialogue Message Window; Set Story Flag (0, 23); Open Shop Menu #6 (Type: 20); Open Shop Menu #6 (Type: 21); Open Shop Menu #6 (Type: 22); Open Shop Menu #6 (Type: 23); Teleport obj[255] to (254,204) |
| `ev[26]` | `2 (Map Init)` | Story Flag 220 (bit 1) SET | Make obj[1] Hidden (disp = 0); Branch on Choice (1, 21); Warp Room -> Submap 1 at (23,47) facing 255 |
| `ev[27]` | `2 (Map Init)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 223 (bit 8) SET | Make obj[1] Hidden (disp = 0); Close Dialogue Sub-Window (1); Clear Dialogue Sub-Window; Warp Room -> Submap 1 at (27,0) facing 28; Open Dialogue Message Window; Display Emotion Bubble (0, 30); Open Dialogue Message Window; Warp Room -> Submap 0 at (32,0); Return to Previous Memory Map (0); Return Warp to Castle Base (0, 35); Open Dialogue Message Window; Launch Tactical War Battle (47) |
| `ev[28]` | `1 (Action / Talk)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 223 (bit 8) CLEAR AND Player within Box [98..99, 2..101] AND Condition Check #116 | Set Render Priority (pri) (0, 105); Engine Action #108; Engine Action #9; Warp to Castle HQ (0, 3, 72); Warp Room -> Submap 2 at (73,20) facing 72; Open Dialogue Message Window; Execute Choice Result (49); Exit to World Map (56, 20, 0); Warp to Castle HQ (0, 1, 3); Engine Action #9; Set Animation Pose (21, 0); Warp to Castle HQ (4, 1, 2); Engine Action #9; Set Animation Pose (22, 0); Warp to Castle HQ (4, 0, 2); Engine Action #9; Set Animation Pose (23, 0); Warp to Castle HQ (0, 0, 3); Engine Action #9; Walk obj[46] to (106,20); Close Dialogue Sub-Window (106); Execute Choice Result (25); Set Character Quest Milestone (22, 26); Set Character Quest Milestone (23, 27); Engine Action #89; Close Dialogue Sub-Window (2); Open Dialogue Message Window; Engine Action #89; Clear Dialogue Sub-Window; Warp Town -> Area 2 Map 89 Submap 26 at (2,2); Engine Action #89; Fade Out to Black (2); Warp Room -> Submap 20 at (1,21) facing West (Left); Set Story Flag (1, 23); Open Dialogue Message Window; Close Dialogue Sub-Window (0); Clear Dialogue Sub-Window; Open Dialogue Message Window; Fade In from Black (0); Fade Out to Black (47); Engine Action #89; Close Dialogue Sub-Window (5); Engine Action #89; Close Dialogue Sub-Window (5); Engine Action #9; Engine Action #223; Reset Camera Tracking (83); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[29]` | `2 (Map Init)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 223 (bit 16) CLEAR | Make obj[0] Hidden (disp = 0); Toggle Random Encounters (0); Open Save Crystal Menu (MSaveInit); Open Dialogue Message Window; Engine Action #39; Open Dialogue Message Window; Engine Action #40; Open Shop Menu #6 (Type: 37); Open Shop Menu #6 (Type: 38); Open Shop Menu #6 (Type: 39); Open Shop Menu #6 (Type: 40); Teleport obj[255] to (254,204) |
| `ev[30]` | `2 (Map Init)` | Story Flag 220 (bit 1) SET | Make obj[1] Hidden (disp = 0); Toggle Random Encounters (1); Open Save Crystal Menu (MSaveInit); Warp Room -> Submap 1 at (40,47) facing 255 |
| `ev[31]` | `2 (Map Init)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 223 (bit 16) SET | Make obj[1] Hidden (disp = 0); Award Potch Loot (+298 Potch); Warp Room -> Submap 1 at (44,0) facing 45; Open Dialogue Message Window; Make obj[0] Hidden (disp = 0); Teleport obj[0] to (48,0); Set Entity Movement Speed (0, 50); Open Dialogue Message Window; Engine Action #51; Open Dialogue Message Window; Engine Action #52; Teleport obj[255] to (254,204) |
| `ev[32]` | `1 (Action / Talk)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 223 (bit 16) CLEAR AND Player within Box [200..208, 2..141] AND Condition Check #143 | Set Render Priority (pri) (0, 204); Engine Action #135; Reset Camera Tracking (3); Open Dialogue Message Window; Warp Room -> Submap 1 at (38,2) facing 73; Branch on Choice (72, 0); Open Save Crystal Menu (MSaveInit); Set Combat Battle BGM (20); Set Entity Movement Speed (4, 56); Toggle Random Encounters (0); Warp Town -> Area 4 Map 1 Submap 0 at (9,255); Set Animation Pose (38, 0); Warp Town -> Area 2 Map 1 Submap 4 at (9,255); Set Animation Pose (39, 0); Warp to Castle HQ (2, 1, 4); Engine Action #9; Set Animation Pose (40, 0); Warp to Castle HQ (4, 1, 0); Engine Action #9; Walk obj[46] to (106,37); Award Potch Loot (+27,174 Potch); Remove Item from Inventory (106, 39); Open Shop Menu #40 (Type: 106); Engine Action #44; Engine Action #89; Award Potch Loot (+515 Potch); Engine Action #89; Remove Item from Inventory (2, 0); Engine Action #89; Open Shop Menu #0 (Type: 2); Engine Action #89; Engine Action #44; Warp Town -> Area 2 Map 1 Submap 37 at (1,38); Warp Room -> Submap 1 at (40,0) facing 41; Open Dialogue Message Window; Remove Item from Inventory (0, 43); Open Dialogue Message Window; Engine Action #44; Teleport obj[89] to (41,5); Engine Action #89; Award Potch Loot (+1,289 Potch); Engine Action #223; Dismiss Dialogue Portrait; Engine Action #83; Warp Room -> Submap 255 at (254,204) facing 204 |

---

### Submap Layer `vj05_02` (Index 2)

- **Map Number (`mapno`)**: `2`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `5`)
- **Entity Count (`okaz`)**: `2` Objects | **Script Count (`evkaz`)**: `22` Scripts

#### Complete Physical Entity Inventory (2 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 11)** | `0` | `(192, 78)` | `0x0` | Frame 11 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | Rest Device / Fire | **Inn Bed / Recovery Device** | `0` | `(192, 78)` | `0x0` | Frame 12 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(192, 78)` with state parameter `11`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(192, 78)` with state parameter `12`.


#### Complete Bytecode Script Catalog (22 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `128 (Loop)` | Player within Box [177..199, 2..120] AND Condition Check #140 AND Story Flag 0 (mask 255) SET | Warp Room -> Submap 0 at (9,3) |
| `ev[01]` | `128 (Loop)` | Player within Box [32..40, 2..51] AND Condition Check #71 AND Story Flag 0 (mask 255) SET | Warp Room -> Submap 0 at (9,6) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [186..190, 2..144] AND Condition Check #145 AND Story Flag 0 (mask 255) SET | Warp Map Transition (3, 0, 120, 45, 255) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [186..194, 2..27] AND Treasure Byte 9 Bit 0 FRESH (Unopened) | Display Dialogue Box [Bank: 1, MsgID: 124]; Engine Action #149 |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [167..171, 2..84] AND Condition Check #85 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 60]; Engine Action #113 |
| `ev[05]` | `1 (Action / Talk)` | Player within Box [58..62, 2..110] AND Condition Check #111 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 169]; Engine Action #81 |
| `ev[06]` | `1 (Action / Talk)` | Player within Box [23..24, 2..135] AND Condition Check #144 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 134]; Engine Action #140 |
| `ev[07]` | `1 (Action / Talk)` | Player within Box [136..137, 2..135] AND Condition Check #144 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 26]; Engine Action #140 |
| `ev[08]` | `1 (Action / Talk)` | Player within Box [106..110, 2..146] AND Condition Check #147 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 188]; Engine Action #121 |
| `ev[09]` | `1 (Action / Talk)` | Player within Box [186..190, 2..118] AND Condition Check #119 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 108]; Engine Action #143 |
| `ev[10]` | `1 (Action / Talk)` | Player within Box [106..110, 2..110] AND Condition Check #111 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 108]; Engine Action #81 |
| `ev[11]` | `1 (Action / Talk)` | Player within Box [106..110, 2..84] AND Condition Check #85 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 108]; Engine Action #113 |
| `ev[12]` | `1 (Action / Talk)` | Player within Box [48..49, 2..26] AND Condition Check #36 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 90]; Warp Map Transition (255, 254, 204, 204, 204) |
| `ev[13]` | `1 (Action / Talk)` | Player within Box [87..88, 2..26] AND Condition Check #36 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 46]; Warp Map Transition (255, 254, 204, 204, 204) |
| `ev[14]` | `1 (Action / Talk)` | Player within Box [33..39, 2..76] AND Condition Check #77 AND Story Flag 1 (mask 255) SET | Warp Map Transition (3, 0, 20, 148, 255) |
| `ev[15]` | `2 (Map Init)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR | Dismiss Emotion Bubble (2); Open Dialogue Message Window |
| `ev[16]` | `1 (Action / Talk)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR | Open Choice Selection Menu (1, 43); Open Dialogue Message Window; Engine Action #5; Launch Tactical War Battle (2); Engine Action #61; Warp Room -> Submap 5 at (0,0) facing 6; Dismiss Emotion Bubble (61); Warp Room -> Submap 5 at (0,2) facing 8; Dismiss Emotion Bubble (61); Warp Room -> Submap 5 at (0,1) facing 18; Dismiss Emotion Bubble (61); Warp Room -> Submap 5 at (0,3) facing 8; Dismiss Emotion Bubble (61); Warp Room -> Submap 5 at (0,1) facing 37; Dismiss Emotion Bubble (61); Warp Room -> Submap 5 at (0,3) facing 11; Dismiss Emotion Bubble (13); Engine Action #5; Engine Action #9; Warp to Castle HQ (0, 84, 66) |
| `ev[17]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Inventory Holds Item #2 [Mega Medicine] | Close Dialogue Window; Warp to Castle HQ (2, 40, 37); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[18]` | `128 (Loop)` | Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) CLEAR AND Player Y within Range [39..40] | Wait for Audio / Window Sync (3); Close Dialogue Window; Exit to World Map (2, 40, 255) |
| `ev[19]` | `2 (Map Init)` | Treasure Byte 9 Bit 2 FRESH (Unopened) | Make obj[0] Hidden (disp = 0); Reset Camera Tracking (47) |
| `ev[20]` | `2 (Map Init)` | Treasure Byte 9 Bit 2 LOOTED | Make obj[0] Hidden (disp = 0); Engine Action #9; Teleport obj[255] to (254,204) |
| `ev[21]` | `1 (Action / Talk)` | Treasure Byte 9 Bit 2 FRESH (Unopened) AND Target Inspected is obj[8] | Make obj[1] Hidden (disp = 0); Reset Camera Tracking (0); Engine Action #9; Teleport obj[101] to (4,7); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (1); Exit to World Map (0, 19, 80); Open Dialogue Message Window; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (97,9) facing Up (North); Warp Room -> Submap 1 at (9,0) facing 8; Teleport obj[255] to (254,255) |

---



## Location Map: `vj06`

- **Master Map Container**: `vj06.json`
- **Submap Layer Files**: vj06_00.json
- **Collision Grid Files**: None
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 1

### Submap Layer `vj06_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `50`, Rate: `7`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `7` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (7 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `128 (Loop)` | Player within Box [6..38, 2..20] AND Condition Check #30 AND Story Flag 2 (mask 255) SET | Warp Room -> Submap 1 at (9,4) |
| `ev[01]` | `128 (Loop)` | Player within Box [120..158, 2..20] AND Condition Check #30 AND Story Flag 3 (mask 255) SET | Warp Room -> Submap 1 at (9,4) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [4..5, 2..20] AND Condition Check #30 AND Story Flag 2 (mask 255) SET | Warp Map Transition (2, 2, 46, 32, 255) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [159..160, 2..20] AND Condition Check #30 AND Story Flag 3 (mask 255) SET | Warp Map Transition (2, 2, 90, 32, 255) |
| `ev[04]` | `1 (Action / Talk)` | Story Flag 220 (bit 1) SET | Warp to Castle HQ (0, 3, 61); Warp Room -> Submap 5 at (0,4) facing 6; Warp to Castle HQ (150, 30, 13); Engine Action #5; Engine Action #9; Warp Town -> Area 1 Map 190 Submap 115 at (255,254) |
| `ev[05]` | `128 (Loop)` | Player within Box [7..8, 3..220] AND Player within Box [9..3, 255..254] | Close Dialogue Window; Warp to Castle HQ (2, 40, 255) |
| `ev[06]` | `128 (Loop)` | Player within Box [140..141, 3..220] AND Player within Box [9..3, 255..254] | Wait for Audio / Window Sync (3); Close Dialogue Window; Exit to World Map (2, 40, 255) |

---



## Location Map: `vj07`

- **Master Map Container**: `vj07.json`
- **Submap Layer Files**: vj07_01.json, vj07_03.json
- **Collision Grid Files**: vj07_map_00.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 1

### Submap Layer `vj07_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `5` Objects | **Script Count (`evkaz`)**: `17` Scripts

#### Complete Physical Entity Inventory (5 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 144** | `144` | `(18, 67)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | Prop / Scenery | **Prop ID 33168** | `33168` | `(18, 67)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Actor ID 143** | `143` | `(22, 67)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | Prop / Scenery | **Prop ID 33167** | `33167` | `(22, 67)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(5, 90)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 144)**: Positioned at tile `(18, 67)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Prop: Object 33168)**: Environmental world dressing prop placed at tile `(18, 67)`. Solid collision is set to `0`.
- **`obj[02]` (Object 143)**: Positioned at tile `(22, 67)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Prop: Object 33167)**: Environmental world dressing prop placed at tile `(22, 67)`. Solid collision is set to `0`.
- **`obj[04]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(5, 90)` to `(7, 92)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (17 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 96 (bit 2) SET AND Story Flag 96 (bit 4) CLEAR AND Temp Event Flag #1 SET | Make obj[0] Hidden (disp = 0); Reset Camera Tracking (0); Screen Fade Transition (47, 255, 254) |
| `ev[01]` | `2 (Map Init)` | Story Flag 96 (bit 2) SET AND Story Flag 96 (bit 4) CLEAR AND Inventory Holds Item #1 [Medicine] | Make obj[89] Hidden (disp = 0); Close Dialogue Window; Warp Town -> Area 2 Map 89 Submap 9 at (2,2); Open Dialogue Message Window; Engine Action #9; Open Dialogue Message Window; Close Dialogue Window; Teleport obj[255] to (254,204) |
| `ev[02]` | `128 (Loop)` | Story Flag 96 (bit 2) SET AND Story Flag 96 (bit 4) CLEAR AND Inventory Holds Item #128 | Jump to Bytecode Offset (9, 9); Set Combat Battle BGM (30); Set Object Direction (0, 1); Set Object Direction (101, 1); Open Dialogue Message Window; Warp Room -> Submap 1 at (15,25); Toggle Random Encounters (128) |
| `ev[03]` | `1 (Action / Talk)` | Story Flag 96 (bit 2) SET AND Story Flag 96 (bit 4) CLEAR AND Player within Box [11..29, 2..80] AND Condition Check #86 AND Temp Event Flag #1 SET | Launch Tactical War Battle (128); Set Render Priority (pri) (0, 20); Set Special Scene BGM (8); Warp to Castle HQ (0, 1, 33); Open Dialogue Message Window; Make obj[0] Hidden (disp = 0); Warp Room -> Submap 2 at (0,3) facing South (Down); Exit to World Map (0, 5, 47); Set Entity Movement Speed (5, 5); Warp Room -> Submap 5 at (3,3) facing West (Left); Warp Town -> Area 30 Map 255 Submap 254 at (5,2); Exit to World Map (5, 3, 4); Warp Room -> Submap 30 at (255,254) facing 5; Warp to Castle HQ (4, 5, 2); Warp to Castle HQ (1, 2, 30); Engine Action #5; Exit to World Map (4, 5, 2); Exit to World Map (1, 0, 30); Engine Action #5; Engine Action #5; Exit to World Map (5, 0, 3); Warp Room -> Submap 30 at (255,254) facing 50; Engine Action #5; Screen Fade Transition (4, 2, 0); Warp Town -> Area 30 Map 24 Submap 10 at (0,33); Engine Action #5; Reset Camera Tracking (4); Engine Action #5; Open Dialogue Message Window; Warp Town -> Area 30 Map 24 Submap 8 at (0,34); Set Combat Battle BGM (20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 0 Map 35 Submap 0 at (36,41); Warp Town -> Area 0 Map 1 Submap 255 at (0,24); Reset Camera Tracking (0); Toggle Random Encounters (24); Screen Fade Transition (0, 38, 9); Engine Action #225; Warp Room -> Submap 2 at (255,1) facing 24; Reset Camera Tracking (0); Engine Action #39; Set Combat Battle BGM (20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 0 Map 35 Submap 0 at (36,41); Warp Town -> Area 3 Map 4 Submap 255 at (3,24); Reset Camera Tracking (0); Toggle Random Encounters (24); Screen Fade Transition (0, 38, 9); Engine Action #225; Warp Room -> Submap 2 at (255,4) facing 24; Screen Fade Transition (0, 40, 73); Branch on Choice (40, 0); Open Dialogue Message Window; Warp Town -> Area 0 Map 35 Submap 0 at (36,41); Warp Town -> Area 5 Map 6 Submap 255 at (5,24); Reset Camera Tracking (0); Toggle Random Encounters (24); Screen Fade Transition (0, 38, 9); Engine Action #225; Warp Room -> Submap 2 at (255,6) facing 24; Reset Camera Tracking (0); Award Potch Loot (+6,154 Potch); Open Dialogue Message Window; Remove Item from Inventory (10, 225); Warp Room -> Submap 2 at (36,1) facing 101; Engine Action #9; Engine Action #9; Engine Action #102; Warp Room -> Submap 2 at (54,1) facing 8; Engine Action #54; Warp Room -> Submap 54 at (0,128) facing 101; Engine Action #9; Animate Door Open; Set Combat Battle BGM (10); Engine Action #83; Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[04]` | `128 (Loop)` | Story Flag 96 (bit 2) SET AND Story Flag 96 (bit 4) CLEAR AND Inventory Holds Item #1 [Medicine] AND Temp Event Flag #8 SET | Make obj[89] Hidden (disp = 0); Close Dialogue Window; Warp Town -> Area 0 Map 106 Submap 10 at (11,0); Close Dialogue Window; Warp Room -> Submap 47 at (73,30) facing 101; Open Dialogue Message Window; Engine Action #179; Set Combat Battle BGM (30); Engine Action #89; Close Dialogue Window; Warp Town -> Area 1 Map 36 Submap 8 at (255,254) |
| `ev[05]` | `128 (Loop)` | Story Flag 96 (bit 2) SET AND Story Flag 96 (bit 4) CLEAR AND Inventory Holds Item #1 [Medicine] AND Temp Event Flag #4 SET | Set Combat Battle BGM (10); Make obj[89] Hidden (disp = 0); Engine Action #9; Warp Town -> Area 0 Map 106 Submap 8 at (9,0); Engine Action #9; Warp Room -> Submap 47 at (73,30) facing 101; Open Dialogue Message Window; Engine Action #178; Set Combat Battle BGM (30); Engine Action #89; Engine Action #9; Warp Town -> Area 1 Map 36 Submap 4 at (255,254) |
| `ev[06]` | `1 (Action / Talk)` | Story Flag 96 (bit 2) SET AND Story Flag 96 (bit 4) CLEAR AND Inventory Holds Item #4 [Throat Drops] AND Inventory Holds Item #8 [Fire Wall] | Launch Tactical War Battle (16); Set Combat Battle BGM (5); Launch Tactical War Battle (32); Launch Tactical War Battle (64); Set Object Direction (0, 1); Engine Action #104; Engine Action #54; Open Dialogue Message Window; Warp Map Transition (54, 0, 64, 73, 20); Make obj[89] Hidden (disp = 0); Close Dialogue Window; Warp Town -> Area 4 Map 89 Submap 9 at (2,4); Set Character Quest Milestone (11, 10); Set Character Quest Milestone (9, 8); Teleport obj[101] to (1,0); Set Combat Battle BGM (20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 0 Map 43 Submap 0 at (44,89); Engine Action #9; Warp Town -> Area 5 Map 73 Submap 60 at (89,9); Warp Town -> Area 6 Map 24 Submap 8 at (0,45); Engine Action #89; Close Dialogue Window; Warp Town -> Area 5 Map 73 Submap 60 at (89,11); Warp Town -> Area 6 Map 24 Submap 10 at (0,46); Close Dialogue Sub-Window (8); Open Dialogue Message Window; Teleport obj[39] to (34,44); Engine Action #5; Open Dialogue Message Window; Warp to Castle HQ (5, 1, 12); Warp Town -> Area 5 Map 1 Submap 0 at (30,73); Trigger Character Emotion Effect (5, 0); Warp Room -> Submap 30 at (1,0) facing 73; Engine Action #90; Close Dialogue Sub-Window (8); Open Dialogue Message Window; Turn obj[89] facing 9; Warp Town -> Area 7 Map 73 Submap 60 at (89,9); Warp Town -> Area 8 Map 73 Submap 60 at (24,10); Open Dialogue Message Window; Set Entity Movement Speed (89, 11); Warp Town -> Area 7 Map 73 Submap 60 at (89,11); Warp Town -> Area 8 Map 73 Submap 60 at (9,96); Exit to World Map (69, 3, 101); Engine Action #9; Pan Camera (11, 2, 2); Engine Action #120; Engine Action #102; Open Dialogue Message Window; Jump to Bytecode Offset (7, 0); Place Scenery Structure (5); Engine Action #9; Reset Camera Tracking (0); Clear Dialogue Sub-Window; Branch on Choice (255, 254) |
| `ev[07]` | `128 (Loop)` | Story Flag 96 (bit 2) SET AND Story Flag 96 (bit 4) CLEAR AND Inventory Holds Item #32 [Drinking Set] | Engine Action #90; Close Dialogue Window; Exit to World Map (6, 17, 2); Exit to World Map (5, 17, 1); Dismiss Emotion Bubble (101); Open Dialogue Message Window; Engine Action #209; Engine Action #89; Close Dialogue Window; Warp Town -> Area 3 Map 73 Submap 15 at (101,0); Engine Action #182; Toggle Random Encounters (32) |
| `ev[08]` | `128 (Loop)` | Story Flag 96 (bit 2) SET AND Story Flag 96 (bit 4) CLEAR AND Inventory Holds Item #64 [Recipe #33] | Engine Action #90; Engine Action #9; Exit to World Map (6, 17, 1); Exit to World Map (5, 17, 1); Dismiss Emotion Bubble (101); Open Dialogue Message Window; Engine Action #209; Engine Action #89; Engine Action #9; Warp Town -> Area 3 Map 73 Submap 10 at (101,0); Engine Action #181; Toggle Random Encounters (64) |
| `ev[09]` | `128 (Loop)` | Story Flag 96 (bit 2) SET AND Story Flag 96 (bit 4) CLEAR AND Inventory Holds Item #16 [Revenge Earth] | Close Dialogue Window; Warp Room -> Submap 10 at (37,16) facing 255 |
| `ev[10]` | `2 (Map Init)` | Story Flag 96 (bit 4) SET AND Player within Box [35..36, 2..29] AND Condition Check #30 | Warp to Castle HQ (0, 2, 255) |
| `ev[11]` | `128 (Loop)` | Player within Box [8..32, 2..106] AND Condition Check #152 | Warp Room -> Submap 1 at (9,4) |
| `ev[12]` | `128 (Loop)` | Player within Box [8..32, 2..3] AND Condition Check #48 | Warp Room -> Submap 1 at (9,7) |
| `ev[13]` | `1 (Action / Talk)` | Player within Box [17..23, 2..149] AND Condition Check #150 AND Story Flag 0 (mask 255) SET | Warp Map Transition (2, 2, 36, 77, 255) |
| `ev[14]` | `1 (Action / Talk)` | Player within Box [38..43, 2..24] AND Condition Check #33 AND Story Flag 3 (mask 255) SET | Warp Map Transition (2, 0, 20, 105, 255) |
| `ev[15]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Launch Tactical War Battle (2); Open Dialogue Sub-Window (2); Open Dialogue Message Window; Jump to Bytecode Offset (4, 65); Close Dialogue Window; Exit to World Map (2, 40, 101); Engine Action #6; Play Sound Effect (SE) (11); Warp to Castle HQ (2, 40, 103); Fade In from Black (1); Exit to World Map (73, 20, 40); Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 1 Map 2 Submap 1 at (3,73); Branch on Choice (41, 2); Open Dialogue Message Window; Warp Room -> Submap 0 at (54,0) facing Up (North); Recruit Riou (Hero) into Battle Slot 1; Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[16]` | `128 (Loop)` | Inventory Holds Item #2 [Mega Medicine] | Warp Room -> Submap 1 at (13,45); Toggle Random Encounters (2) |

---



## Location Map: `vj08`

- **Master Map Container**: `vj08.json`
- **Submap Layer Files**: vj08_01.json, vj08_02.json, vj08_03.json, vj08_04.json, vj08_06.json
- **Collision Grid Files**: vj08_map_00.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 2

### Submap Layer `vj08_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `10` Objects | **Script Count (`evkaz`)**: `14` Scripts

#### Complete Physical Entity Inventory (10 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Raura (Scroll Keeper)** | `148` | `(20, 18)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[01]` | Prop / Scenery | **Prop ID 33172** | `33172` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | Prop / Scenery | **Prop ID 33172** | `33172` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | World Device | **Mechanism (ano 0)** | `0` | `(12, 32)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | World Device | **Mechanism (ano 0)** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | World Device | **Mechanism (ano 0)** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | World Device | **Mechanism (ano 0)** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | World Device | **Mechanism (ano 0)** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | World Device | **Mechanism (ano 0)** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | World Device | **Mechanism (ano 0)** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Raura (Scroll Keeper))**: Positioned at tile `(20, 18)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Prop: Object 33172)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `0`.
- **`obj[02]` (Prop: Object 33172)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `0`.
- **`obj[03]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(12, 32)` with state parameter `0`.
- **`obj[04]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(0, 0)` with state parameter `0`.
- **`obj[05]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(0, 0)` with state parameter `0`.
- **`obj[06]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(0, 0)` with state parameter `0`.
- **`obj[07]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(0, 0)` with state parameter `0`.
- **`obj[08]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(0, 0)` with state parameter `0`.
- **`obj[09]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(0, 0)` with state parameter `0`.


#### Complete Bytecode Script Catalog (14 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Player Y within Range [100..108] | Warp to Castle HQ (0, 1, 255) |
| `ev[01]` | `2 (Map Init)` | Player Y within Range [8..20] | Warp to Castle HQ (0, 0, 255) |
| `ev[02]` | `128 (Loop)` | Story Flag 96 (bit 8) SET AND Story Flag 98 (bit 1) CLEAR AND Inventory Holds Item #128 | Set Object Direction (0, 0); Set Object Direction (101, 1); Open Dialogue Message Window; Warp Room -> Submap 0 at (15,52); Toggle Random Encounters (128) |
| `ev[03]` | `1 (Action / Talk)` | Story Flag 96 (bit 8) SET AND Story Flag 98 (bit 1) CLEAR AND Party Holds At Least 3,600 Potch AND Story Flag 1 (mask 255) SET | Launch Tactical War Battle (128); Launch Tactical War Battle (1); Engine Action #54; Open Dialogue Message Window; Warp Room -> Submap 0 at (38,28) facing West (Left); Screen Fade Transition (4, 73, 60); Close Dialogue Sub-Window (8); Warp Room -> Submap 5 at (8,0) facing 4; Dismiss Emotion Bubble (46); Engine Action #89; Engine Action #9; Warp Town -> Area 0 Map 106 Submap 8 at (9,1); Reset Camera Tracking (0); Engine Action #9; Teleport obj[73] to (30,89); Engine Action #9; Warp Town -> Area 1 Map 73 Submap 30 at (89,9); Warp Town -> Area 2 Map 73 Submap 30 at (101,0); Engine Action #176; Set Combat Battle BGM (20); Jump to Bytecode Offset (0, 176); Set Combat Battle BGM (20); Jump to Bytecode Offset (0, 176); Set Combat Battle BGM (20); Jump to Bytecode Offset (0, 176); Make obj[89] Hidden (disp = 0); Screen Fade Transition (2, 3, 106); Reset Camera Tracking (10); Open Dialogue Message Window; Screen Fade Transition (47, 73, 60); Engine Action #89; Engine Action #9; Warp Town -> Area 4 Map 73 Submap 60 at (101,9); Pan Camera (89, 9, 2); Engine Action #5; Set Entity Movement Speed (7, 90); Engine Action #9; Change Portrait Expression (5); Dismiss Emotion Bubble (255); Engine Action #5; Open Dialogue Message Window; Pan Camera (3, 30, 255); Engine Action #5; Warp Room -> Submap 3 at (30,255) facing 254; Engine Action #5; Warp Town -> Area 7 Map 3 Submap 30 at (255,254); Engine Action #5; Warp to Castle HQ (7, 3, 30); Engine Action #5; Exit to World Map (7, 3, 30); Engine Action #5; Engine Action #5; Pan Camera (3, 30, 255); Walk obj[46] to (1,9); Set Character Quest Milestone (9, 8); Open Dialogue Message Window; Reset Camera Tracking (47); Engine Action #54; Open Dialogue Message Window; Engine Action #128; Wait for Audio / Window Sync (3); Launch Tactical War Battle (8); Launch Tactical War Battle (4); Engine Action #54; Open Dialogue Message Window; Exit to World Map (54, 0, 8); Set Combat Battle BGM (40); Engine Action #9; Clear Chest Looted Flag (1, 10); Engine Action #225; Warp Town -> Area 30 Map 1 Submap 3 at (2,1); Warp Room -> Submap 12 at (1,13) facing West (Left); Animate Door Open; Warp Room -> Submap 1 at (16,1) facing 17; Set Object Direction (2, 10); Open Dialogue Message Window; Engine Action #83; Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[04]` | `128 (Loop)` | Story Flag 96 (bit 8) SET AND Story Flag 98 (bit 1) CLEAR AND Inventory Holds Item #1 [Medicine] | Exit to World Map (0, 20, 35); Reset Camera Tracking (3); Open Dialogue Message Window; Warp Room -> Submap 1 at (255,254) facing 204 |
| `ev[05]` | `128 (Loop)` | Story Flag 96 (bit 8) SET AND Story Flag 98 (bit 1) CLEAR AND Inventory Holds Item #2 [Mega Medicine] | Set Combat Battle BGM (20); Jump to Bytecode Offset (4, 48); Toggle Random Encounters (2) |
| `ev[06]` | `128 (Loop)` | Story Flag 96 (bit 8) SET AND Story Flag 98 (bit 1) CLEAR AND Inventory Holds Item #4 [Throat Drops] | Make obj[93] Hidden (disp = 0); Open Dialogue Message Window; Close Dialogue Window; Engine Action #39; Open Dialogue Message Window; Close Dialogue Window; Launch Tactical War Battle (2); Teleport obj[73] to (10,94); Warp Room -> Submap 11 at (40,37) facing 4 |
| `ev[07]` | `128 (Loop)` | Story Flag 96 (bit 8) SET AND Story Flag 98 (bit 1) CLEAR AND Inventory Holds Item #8 [Fire Wall] | Close Dialogue Window; Warp Town -> Area 40 Map 40 Submap 37 at (8,255) |
| `ev[08]` | `2 (Map Init)` | Story Flag 96 (bit 8) SET AND Story Flag 98 (bit 1) SET | Make obj[1] Hidden (disp = 0); Reset Camera Tracking (1); Engine Action #9; Warp Room -> Submap 1 at (11,47) facing 255 |
| `ev[09]` | `1 (Action / Talk)` | Story Flag 96 (bit 8) SET AND Story Flag 98 (bit 1) SET AND Story Flag 220 (bit 2) CLEAR | Set Combat Battle BGM (120); Engine Action #39; Return Warp to Castle Base (73, 30); Exit to World Map (0, 20, 0); Reset Camera Tracking (9); Engine Action #220; Warp Town -> Area 13 Map 5 Submap 9 at (15,0); Open Dialogue Message Window; Engine Action #240 |
| `ev[10]` | `128 (Loop)` | Player within Box [7..32, 2..77] AND Condition Check #106 | Warp Room -> Submap 0 at (9,6) |
| `ev[11]` | `128 (Loop)` | Story Flag 143 (bit 1) SET AND Player Y within Range [8..20] | Warp Room -> Submap 0 at (9,15) |
| `ev[12]` | `1 (Action / Talk)` | Player within Box [7..32, 2..108] AND Condition Check #110 AND Story Flag 0 (mask 255) SET | Warp Map Transition (3, 0, 36, 30, 255) |
| `ev[13]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Player within Box [18..22, 2..8] AND Story Flag 9 (mask 1) SET | Warp Map Transition (3, 0, 20, 57, 255) |

---

### Submap Layer `vj08_01` (Index 1)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `47` Objects | **Script Count (`evkaz`)**: `4` Scripts

#### Complete Physical Entity Inventory (47 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 174** | `174` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Gordon (Trader)** | `175` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Actor ID 65117** | `65117` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | NPC / Actor | **Actor ID 65104** | `65104` | `(10, 22)` | `0x0` | East (Right) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | NPC / Actor | **Actor ID 65104** | `65104` | `(30, 22)` | `0x0` | Up (North) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | NPC / Actor | **Actor ID 65104** | `65104` | `(10, 25)` | `0x0` | East (Right) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | NPC / Actor | **Actor ID 65104** | `65104` | `(30, 25)` | `0x0` | Up (North) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | NPC / Actor | **Actor ID 65104** | `65104` | `(10, 28)` | `0x0` | East (Right) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | NPC / Actor | **Actor ID 65104** | `65104` | `(30, 28)` | `0x0` | Up (North) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | NPC / Actor | **Actor ID 65104** | `65104` | `(10, 31)` | `0x0` | East (Right) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | NPC / Actor | **Actor ID 65104** | `65104` | `(30, 31)` | `0x0` | Up (North) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | NPC / Actor | **Actor ID 65104** | `65104` | `(10, 34)` | `0x0` | East (Right) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | NPC / Actor | **Actor ID 65104** | `65104` | `(30, 34)` | `0x0` | Up (North) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | NPC / Actor | **Actor ID 65104** | `65104` | `(10, 37)` | `0x0` | East (Right) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | NPC / Actor | **Actor ID 65104** | `65104` | `(30, 37)` | `0x0` | Up (North) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[15]` | NPC / Actor | **Actor ID 65104** | `65104` | `(10, 40)` | `0x0` | East (Right) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[16]` | NPC / Actor | **Actor ID 65104** | `65104` | `(30, 40)` | `0x0` | Up (North) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[17]` | NPC / Actor | **Actor ID 65104** | `65104` | `(10, 43)` | `0x0` | East (Right) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[18]` | NPC / Actor | **Actor ID 65104** | `65104` | `(30, 43)` | `0x0` | Up (North) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[19]` | NPC / Actor | **Actor ID 65104** | `65104` | `(10, 46)` | `0x0` | East (Right) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[20]` | NPC / Actor | **Actor ID 65104** | `65104` | `(30, 46)` | `0x0` | Up (North) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[21]` | NPC / Actor | **Actor ID 65104** | `65104` | `(10, 49)` | `0x0` | East (Right) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[22]` | NPC / Actor | **Actor ID 65104** | `65104` | `(30, 49)` | `0x0` | Up (North) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[23]` | NPC / Actor | **Actor ID 65104** | `65104` | `(10, 52)` | `0x0` | East (Right) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[24]` | NPC / Actor | **Actor ID 65104** | `65104` | `(30, 52)` | `0x0` | Up (North) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[25]` | Prop / Scenery | **Prop ID 64978** | `64978` | `(10, 22)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[26]` | Prop / Scenery | **Prop ID 64978** | `64978` | `(30, 22)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[27]` | Prop / Scenery | **Prop ID 64978** | `64978` | `(10, 25)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[28]` | Prop / Scenery | **Prop ID 64978** | `64978` | `(30, 25)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[29]` | Prop / Scenery | **Prop ID 64978** | `64978` | `(10, 28)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[30]` | Prop / Scenery | **Prop ID 64978** | `64978` | `(30, 28)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[31]` | Prop / Scenery | **Prop ID 64978** | `64978` | `(10, 31)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[32]` | Prop / Scenery | **Prop ID 64978** | `64978` | `(30, 31)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[33]` | Prop / Scenery | **Prop ID 64978** | `64978` | `(10, 34)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[34]` | Prop / Scenery | **Prop ID 64978** | `64978` | `(30, 34)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[35]` | Prop / Scenery | **Prop ID 64978** | `64978` | `(10, 37)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[36]` | Prop / Scenery | **Prop ID 64978** | `64978` | `(30, 37)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[37]` | Prop / Scenery | **Prop ID 64978** | `64978` | `(10, 40)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[38]` | Prop / Scenery | **Prop ID 64978** | `64978` | `(30, 40)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[39]` | Prop / Scenery | **Prop ID 64978** | `64978` | `(10, 43)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[40]` | Prop / Scenery | **Prop ID 64978** | `64978` | `(30, 43)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[41]` | Prop / Scenery | **Prop ID 64978** | `64978` | `(10, 46)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[42]` | Prop / Scenery | **Prop ID 64978** | `64978` | `(30, 46)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[43]` | Prop / Scenery | **Prop ID 64978** | `64978` | `(10, 49)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[44]` | Prop / Scenery | **Prop ID 64978** | `64978` | `(30, 49)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[45]` | Prop / Scenery | **Prop ID 64978** | `64978` | `(10, 52)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[46]` | Prop / Scenery | **Prop ID 64978** | `64978` | `(30, 52)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 174)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Gordon (Trader))**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Object 65117)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Object 65104)**: Positioned at tile `(10, 22)`, facing East (Right). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Object 65104)**: Positioned at tile `(30, 22)`, facing Up (North). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Object 65104)**: Positioned at tile `(10, 25)`, facing East (Right). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[06]` (Object 65104)**: Positioned at tile `(30, 25)`, facing Up (North). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[07]` (Object 65104)**: Positioned at tile `(10, 28)`, facing East (Right). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[08]` (Object 65104)**: Positioned at tile `(30, 28)`, facing Up (North). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[09]` (Object 65104)**: Positioned at tile `(10, 31)`, facing East (Right). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[10]` (Object 65104)**: Positioned at tile `(30, 31)`, facing Up (North). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[11]` (Object 65104)**: Positioned at tile `(10, 34)`, facing East (Right). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[12]` (Object 65104)**: Positioned at tile `(30, 34)`, facing Up (North). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[13]` (Object 65104)**: Positioned at tile `(10, 37)`, facing East (Right). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[14]` (Object 65104)**: Positioned at tile `(30, 37)`, facing Up (North). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[15]` (Object 65104)**: Positioned at tile `(10, 40)`, facing East (Right). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[16]` (Object 65104)**: Positioned at tile `(30, 40)`, facing Up (North). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[17]` (Object 65104)**: Positioned at tile `(10, 43)`, facing East (Right). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[18]` (Object 65104)**: Positioned at tile `(30, 43)`, facing Up (North). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[19]` (Object 65104)**: Positioned at tile `(10, 46)`, facing East (Right). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[20]` (Object 65104)**: Positioned at tile `(30, 46)`, facing Up (North). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[21]` (Object 65104)**: Positioned at tile `(10, 49)`, facing East (Right). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[22]` (Object 65104)**: Positioned at tile `(30, 49)`, facing Up (North). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[23]` (Object 65104)**: Positioned at tile `(10, 52)`, facing East (Right). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[24]` (Object 65104)**: Positioned at tile `(30, 52)`, facing Up (North). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[25]` (Prop: Object 64978)**: Environmental world dressing prop placed at tile `(10, 22)`. Solid collision is set to `0`.
- **`obj[26]` (Prop: Object 64978)**: Environmental world dressing prop placed at tile `(30, 22)`. Solid collision is set to `0`.
- **`obj[27]` (Prop: Object 64978)**: Environmental world dressing prop placed at tile `(10, 25)`. Solid collision is set to `0`.
- **`obj[28]` (Prop: Object 64978)**: Environmental world dressing prop placed at tile `(30, 25)`. Solid collision is set to `0`.
- **`obj[29]` (Prop: Object 64978)**: Environmental world dressing prop placed at tile `(10, 28)`. Solid collision is set to `0`.
- **`obj[30]` (Prop: Object 64978)**: Environmental world dressing prop placed at tile `(30, 28)`. Solid collision is set to `0`.
- **`obj[31]` (Prop: Object 64978)**: Environmental world dressing prop placed at tile `(10, 31)`. Solid collision is set to `0`.
- **`obj[32]` (Prop: Object 64978)**: Environmental world dressing prop placed at tile `(30, 31)`. Solid collision is set to `0`.
- **`obj[33]` (Prop: Object 64978)**: Environmental world dressing prop placed at tile `(10, 34)`. Solid collision is set to `0`.
- **`obj[34]` (Prop: Object 64978)**: Environmental world dressing prop placed at tile `(30, 34)`. Solid collision is set to `0`.
- **`obj[35]` (Prop: Object 64978)**: Environmental world dressing prop placed at tile `(10, 37)`. Solid collision is set to `0`.
- **`obj[36]` (Prop: Object 64978)**: Environmental world dressing prop placed at tile `(30, 37)`. Solid collision is set to `0`.
- **`obj[37]` (Prop: Object 64978)**: Environmental world dressing prop placed at tile `(10, 40)`. Solid collision is set to `0`.
- **`obj[38]` (Prop: Object 64978)**: Environmental world dressing prop placed at tile `(30, 40)`. Solid collision is set to `0`.
- **`obj[39]` (Prop: Object 64978)**: Environmental world dressing prop placed at tile `(10, 43)`. Solid collision is set to `0`.
- **`obj[40]` (Prop: Object 64978)**: Environmental world dressing prop placed at tile `(30, 43)`. Solid collision is set to `0`.
- **`obj[41]` (Prop: Object 64978)**: Environmental world dressing prop placed at tile `(10, 46)`. Solid collision is set to `0`.
- **`obj[42]` (Prop: Object 64978)**: Environmental world dressing prop placed at tile `(30, 46)`. Solid collision is set to `0`.
- **`obj[43]` (Prop: Object 64978)**: Environmental world dressing prop placed at tile `(10, 49)`. Solid collision is set to `0`.
- **`obj[44]` (Prop: Object 64978)**: Environmental world dressing prop placed at tile `(30, 49)`. Solid collision is set to `0`.
- **`obj[45]` (Prop: Object 64978)**: Environmental world dressing prop placed at tile `(10, 52)`. Solid collision is set to `0`.
- **`obj[46]` (Prop: Object 64978)**: Environmental world dressing prop placed at tile `(30, 52)`. Solid collision is set to `0`.


#### Complete Bytecode Script Catalog (4 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 122 (bit 16) SET AND Story Flag 122 (bit 32) CLEAR | Make obj[2] Hidden (disp = 0); Screen Fade Transition (20, 17, 3); Screen Fade Transition (0, 0, 10); Warp Town -> Area 8 Map 18 Submap 21 at (3,8); Warp Room -> Submap 8 at (2,9) facing 22; Execute Choice Result (3); Engine Action #9; Warp Room -> Submap 9 at (2,0) facing 20; Engine Action #93; Warp Room -> Submap 44 at (37,254) facing 47 |
| `ev[01]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 122 (bit 32) CLEAR | Jump to Bytecode Offset (7, 0); Set Object Direction (0, 0); Engine Action #107; Jump to Bytecode Offset (1, 0); Display Chapter Text (1); Remove Character from Active Party (4); Set Combat Battle BGM (120); Close Dialogue Sub-Window (10); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Reset Camera Tracking (1); Warp Town -> Area 30 Map 24 Submap 8 at (0,1); Engine Action #5; Reset Camera Tracking (7); Warp Town -> Area 30 Map 73 Submap 60 at (24,9); Open Dialogue Message Window; Warp Town -> Area 24 Map 10 Submap 0 at (3,73); Trigger Character Emotion Effect (5, 9); Warp Room -> Submap 30 at (24,9) facing South (Down); Exit to World Map (5, 9, 7); Warp Town -> Area 30 Map 73 Submap 60 at (24,10); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (30); Launch Tactical War Battle (2); Engine Action #54; Open Dialogue Message Window; Warp Town -> Area 73 Map 60 Submap 49 at (2,5); Reset Camera Tracking (3); Open Dialogue Message Window; Engine Action #5; Screen Fade Transition (0, 0, 30); Engine Action #5; Engine Action #9; Engine Action #5; Screen Fade Transition (3, 0, 5); Screen Fade Transition (0, 0, 30); Walk obj[49] to (2,5); Reset Camera Tracking (0); Screen Fade Transition (30, 255, 254); Engine Action #5; Engine Action #9; Engine Action #5; Dismiss Emotion Bubble (0); Engine Action #9; Dismiss Emotion Bubble (255); Walk obj[73] to (30,24); Reset Camera Tracking (0); Engine Action #6; Launch Tactical War Battle (1); Wait for Audio / Window Sync (1); Jump to Bytecode Offset (9, 7); Close Dialogue Window; Warp Town -> Area 2 Map 200 Submap 54 at (0,1); Engine Action #9; Engine Action #122; Warp Map Transition (117, 1, 132, 111, 41); Engine Action #5; Engine Action #6; Pan Camera (8, 9, 10); Engine Action #111; Award Potch Loot (+1,286 Potch); Pan Camera (8, 9, 10); Engine Action #6; Pan Camera (13, 5, 10); Engine Action #6; Warp to Castle HQ (52, 52, 255); Reset Camera Tracking (13); Engine Action #5; Screen Fade Transition (12, 0, 50); Walk obj[255] to (9,255); Screen Fade Transition (13, 5, 10); Display Dialogue Box [Bank: 7, MsgID: 56]; Full Rest & Healing (Restore HP/MP) |
| `ev[02]` | `128 (Loop)` | Story Flag 122 (bit 16) SET AND Story Flag 122 (bit 32) CLEAR AND Inventory Holds Item #1 [Medicine] | Set Entity Movement Speed (2, 5); Reset Camera Tracking (0); Branch on Choice (30, 255); Engine Action #5; Engine Action #9; Engine Action #5; Dismiss Emotion Bubble (0); Branch on Choice (30, 255); Walk obj[37] to (1,255) |
| `ev[03]` | `128 (Loop)` | Story Flag 122 (bit 16) SET AND Story Flag 122 (bit 32) CLEAR AND Inventory Holds Item #2 [Mega Medicine] | Make obj[89] Hidden (disp = 0); Return to Previous Memory Map (2); Engine Action #6; Engine Action #89; Start Boss Battle #2 (BGM: 6); Engine Action #89; Toggle Random Encounters (2); Engine Action #6; Engine Action #89; Engine Action #39; Warp Town -> Area 6 Map 89 Submap 41 at (2,6); Engine Action #89; Open Shop Menu #6 (Type: 2); Engine Action #89; Make obj[2] Visible (disp = 1); Engine Action #6; Engine Action #89; Teleport obj[2] to (6,89); Set Entity Movement Speed (2, 6); Engine Action #89; Engine Action #51; Warp Town -> Area 6 Map 89 Submap 53 at (2,6); Engine Action #89; Return Warp to Castle Base (2, 0); Engine Action #89; Launch Tactical War Battle (2); Open Dialogue Message Window; Engine Action #89; Open Save Crystal Menu (MSaveInit); Warp Town -> Area 0 Map 89 Submap 40 at (2,0); Engine Action #89; Remove Item from Inventory (2, 0); Engine Action #89; Engine Action #44; Warp Town -> Area 0 Map 89 Submap 46 at (2,0); Engine Action #89; Turn obj[2] facing South (Down); Engine Action #89; Walk obj[2] to (0,89); Engine Action #52; Warp Town -> Area 0 Map 89 Submap 54 at (2,0); Warp Room -> Submap 1 at (12,1) facing 13; Warp Room -> Submap 1 at (15,1) facing 16; Warp Room -> Submap 1 at (18,1) facing 19; Warp Room -> Submap 1 at (21,1) facing 22; Warp Room -> Submap 1 at (24,1) facing 25; Warp Room -> Submap 1 at (27,1) facing 28; Warp Room -> Submap 1 at (30,1) facing 31; Warp Room -> Submap 0 at (33,0) facing 34; Open Dialogue Message Window; Start Boss Battle #0 (BGM: 36); Open Dialogue Message Window; Toggle Random Encounters (0); Open Save Crystal Menu (MSaveInit); Open Dialogue Message Window; Engine Action #39; Open Dialogue Message Window; Engine Action #40; Open Dialogue Message Window; Award Potch Loot (+42 Potch); Open Dialogue Message Window; Open Shop Menu #44 (Type: 0); Open Dialogue Message Window; Make obj[0] Visible (disp = 1); Make obj[0] Hidden (disp = 0); Teleport obj[0] to (48,0); Set Entity Movement Speed (0, 50); Open Dialogue Message Window; Engine Action #51; Open Dialogue Message Window; Engine Action #52; Open Dialogue Message Window; Engine Action #53; Open Dialogue Message Window; Engine Action #54; Teleport obj[101] to (0,177); Set Combat Battle BGM (40); Make obj[89] Hidden (disp = 0); Return to Previous Memory Map (2); Pan Camera (89, 35, 2); Pan Camera (89, 37, 2); Pan Camera (89, 39, 2); Pan Camera (89, 41, 2); Pan Camera (89, 43, 2); Pan Camera (89, 45, 2); Pan Camera (89, 47, 2); Pan Camera (89, 49, 2); Pan Camera (89, 51, 2); Pan Camera (89, 53, 2); Pan Camera (89, 34, 2); Warp Room -> Submap 36 at (2,1) facing 89; Open Save Crystal Menu (MSaveInit); Warp Town -> Area 1 Map 89 Submap 40 at (2,1); Engine Action #89; Remove Item from Inventory (2, 1); Engine Action #89; Engine Action #44; Warp Town -> Area 1 Map 89 Submap 46 at (2,1); Engine Action #89; Turn obj[2] facing West (Left); Engine Action #89; Walk obj[2] to (1,89); Engine Action #52; Warp Town -> Area 1 Map 89 Submap 54 at (2,1); Teleport obj[73] to (30,101); Open Dialogue Message Window; Engine Action #178; Launch Tactical War Battle (4); Make obj[89] Hidden (disp = 0); Return to Previous Memory Map (2); Reset Camera Tracking (89); Start Boss Battle #2 (BGM: 8); Engine Action #89; Toggle Random Encounters (2); Reset Camera Tracking (89); Engine Action #39; Warp Town -> Area 8 Map 89 Submap 41 at (2,8); Engine Action #89; Open Shop Menu #8 (Type: 2); Engine Action #89; Make obj[2] Visible (disp = 1); Reset Camera Tracking (89); Teleport obj[2] to (8,89); Set Entity Movement Speed (2, 8); Engine Action #89; Engine Action #51; Warp Town -> Area 8 Map 89 Submap 53 at (2,8); Engine Action #89; Return Warp to Castle Base (2, 2); Engine Action #89; Launch Tactical War Battle (2); Warp Town -> Area 89 Map 38 Submap 2 at (2,89); Engine Action #40; Warp Town -> Area 2 Map 89 Submap 42 at (2,2); Engine Action #89; Engine Action #44; Warp Town -> Area 2 Map 89 Submap 46 at (2,2); Engine Action #89; Turn obj[2] facing Up (North); Engine Action #89; Walk obj[2] to (2,89); Engine Action #52; Warp Town -> Area 2 Map 89 Submap 54 at (2,2); Teleport obj[73] to (30,46); Engine Action #89; Return to Previous Memory Map (2); Engine Action #9; Engine Action #89; Start Boss Battle #2 (BGM: 9); Engine Action #89; Toggle Random Encounters (2); Engine Action #9; Engine Action #89; Engine Action #39; Warp Town -> Area 9 Map 89 Submap 41 at (2,9); Engine Action #89; Open Shop Menu #9 (Type: 2); Engine Action #89; Make obj[2] Visible (disp = 1); Engine Action #9; Engine Action #89; Teleport obj[2] to (9,89); Set Entity Movement Speed (2, 9); Engine Action #89; Engine Action #51; Warp Town -> Area 9 Map 89 Submap 53 at (2,9); Engine Action #89; Return Warp to Castle Base (2, 3); Engine Action #89; Launch Tactical War Battle (2); Warp to Castle HQ (89, 38, 2); Warp to Castle HQ (89, 40, 2); Warp to Castle HQ (89, 42, 2); Warp to Castle HQ (89, 44, 2); Warp to Castle HQ (89, 46, 2); Warp to Castle HQ (89, 48, 2); Warp to Castle HQ (89, 50, 2); Warp to Castle HQ (89, 52, 2); Warp to Castle HQ (89, 54, 2); Warp to Castle HQ (47, 73, 20); Make obj[89] Hidden (disp = 0); Return to Previous Memory Map (2); Screen Fade Transition (89, 35, 2); Screen Fade Transition (89, 37, 2); Screen Fade Transition (89, 39, 2); Screen Fade Transition (89, 41, 2); Screen Fade Transition (89, 43, 2); Screen Fade Transition (89, 45, 2); Screen Fade Transition (89, 47, 2); Screen Fade Transition (89, 49, 2); Screen Fade Transition (89, 51, 2); Screen Fade Transition (89, 53, 2); Screen Fade Transition (89, 34, 2); Exit to World Map (89, 36, 2); Exit to World Map (89, 38, 2); Exit to World Map (89, 40, 2); Exit to World Map (89, 42, 2); Exit to World Map (89, 44, 2); Exit to World Map (89, 46, 2); Exit to World Map (89, 48, 2); Exit to World Map (89, 50, 2); Exit to World Map (89, 52, 2); Exit to World Map (89, 54, 2); Exit to World Map (47, 73, 30); Make obj[89] Hidden (disp = 0); Return to Previous Memory Map (2); Close Dialogue Window; Engine Action #89; Start Boss Battle #2 (BGM: 11); Engine Action #89; Toggle Random Encounters (2); Close Dialogue Window; Engine Action #89; Engine Action #39; Warp Town -> Area 11 Map 89 Submap 41 at (2,11); Engine Action #89; Open Shop Menu #11 (Type: 2); Engine Action #89; Make obj[2] Visible (disp = 1); Close Dialogue Window; Engine Action #89; Teleport obj[2] to (11,89); Set Entity Movement Speed (2, 11); Engine Action #89; Engine Action #51; Warp Town -> Area 11 Map 89 Submap 53 at (2,11); Engine Action #89; Return Warp to Castle Base (2, 5); Engine Action #89; Launch Tactical War Battle (2); Engine Action #5; Engine Action #89; Open Save Crystal Menu (MSaveInit); Warp Town -> Area 5 Map 89 Submap 40 at (2,5); Engine Action #89; Remove Item from Inventory (2, 5); Engine Action #89; Engine Action #44; Warp Town -> Area 5 Map 89 Submap 46 at (2,5); Engine Action #89; Turn obj[2] facing 5; Engine Action #89; Walk obj[2] to (5,89); Engine Action #52; Warp Town -> Area 5 Map 89 Submap 54 at (2,5); Teleport obj[37] to (2,255) |

---



## Location Map: `vj09`

- **Master Map Container**: `vj09.json`
- **Submap Layer Files**: vj09_03.json
- **Collision Grid Files**: None
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 1

### Submap Layer `vj09_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `6` Objects | **Script Count (`evkaz`)**: `7` Scripts

#### Complete Physical Entity Inventory (6 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Highland Officer** | `81` | `(26, 20)` | `0x0` | Up (North) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Lebrante (Appraiser)** | `141` | `(4, 20)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Actor ID 176** | `176` | `(31, 20)` | `0x0` | Up (North) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | Prop / Scenery | **Prop ID 33200** | `33200` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | Prop / Scenery | **Prop ID 33200** | `33200` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | Prop / Scenery | **Prop ID 33200** | `33200` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Highland Officer)**: Positioned at tile `(26, 20)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Lebrante (Appraiser))**: Positioned at tile `(4, 20)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Object 176)**: Positioned at tile `(31, 20)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Prop: Object 33200)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[04]` (Prop: Object 33200)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[05]` (Prop: Object 33200)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.


#### Complete Bytecode Script Catalog (7 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 96 (bit 4) SET AND Story Flag 96 (bit 8) CLEAR | Make obj[2] Hidden (disp = 0); Open Dialogue Message Window; Clear Dialogue Sub-Window; Branch on Choice (1, 0); Open Dialogue Message Window; Reset Camera Tracking (0); Screen Fade Transition (47, 255, 254) |
| `ev[01]` | `1 (Action / Talk)` | Story Flag 96 (bit 4) SET AND Story Flag 96 (bit 8) CLEAR | Launch Tactical War Battle (16); Close Dialogue Window; Warp Room -> Submap 200 at (73,60) facing 5; Screen Fade Transition (4, 4, 2); Warp to Castle HQ (30, 24, 10); Open Dialogue Message Window; Open Dialogue Message Window; Close Dialogue Sub-Window (8); Open Dialogue Message Window; Warp Room -> Submap 9 at (9,5) facing 8; Exit to World Map (4, 3, 3); Dismiss Emotion Bubble (36); Engine Action #128; Make obj[89] Hidden (disp = 0); Display Dialogue Box [Bank: 2, MsgID: 0]; Set Character Quest Milestone (10, 12); Warp Room -> Submap 0 at (12,47) facing 73; Screen Fade Transition (89, 12, 2); Warp Room -> Submap 20 at (89,12) facing Up (North); Warp Town -> Area 46 Map 89 Submap 11 at (2,4); Set Character Quest Milestone (8, 11); Warp Room -> Submap 0 at (11,47) facing 73; Branch on Choice (54, 0); Engine Action #128; Jump to Bytecode Offset (1, 0); Engine Action #89; Close Dialogue Window; Warp Town -> Area 5 Map 24 Submap 8 at (0,2); Engine Action #89; Close Dialogue Window; Warp Town -> Area 6 Map 89 Submap 12 at (2,7); Close Dialogue Sub-Window (10); Open Dialogue Message Window; Warp to Castle HQ (89, 12, 2); Reset Camera Tracking (73); Engine Action #90; Engine Action #89; Display Dialogue Box [Bank: 2, MsgID: 9]; Close Dialogue Sub-Window (10); Open Dialogue Message Window; Exit to World Map (73, 60, 24); Reset Camera Tracking (0); Engine Action #5; Close Dialogue Sub-Window (10); Open Dialogue Message Window; Engine Action #6; Set Combat Battle BGM (90); Engine Action #89; Display Dialogue Box [Bank: 2, MsgID: 1]; Close Dialogue Sub-Window (10); Open Dialogue Message Window; Pan Camera (89, 12, 2); Warp Town -> Area 73 Map 90 Submap 89 at (12,2); Warp Room -> Submap 10 at (0,8) facing 89; Display Dialogue Box [Bank: 2, MsgID: 2]; Close Dialogue Sub-Window (8); Open Dialogue Message Window; Engine Action #9; Set Combat Battle BGM (30); Engine Action #89; Display Dialogue Box [Bank: 2, MsgID: 7]; Set Combat Battle BGM (60); Engine Action #89; Display Dialogue Box [Bank: 2, MsgID: 8]; Close Dialogue Sub-Window (10); Open Dialogue Message Window; Screen Fade Transition (73, 90, 24); Screen Fade Transition (0, 11, 73); Engine Action #90; Close Dialogue Sub-Window (8); Open Dialogue Message Window; Display Dialogue Box [Bank: 73, MsgID: 90]; Engine Action #89; Display Dialogue Box [Bank: 2, MsgID: 9]; Close Dialogue Sub-Window (10); Open Dialogue Message Window; Place Scenery Structure (24); Reset Camera Tracking (0); Animate Door Open; Set Combat Battle BGM (10); Engine Action #89; Display Dialogue Box [Bank: 2, MsgID: 1]; Close Dialogue Sub-Window (10); Open Dialogue Message Window; Show Dialogue Portrait (89, 12, 2); Warp Town -> Area 73 Map 60 Submap 24 at (8,0); Dismiss Dialogue Portrait; Engine Action #89; Close Dialogue Window; Warp Town -> Area 10 Map 73 Submap 20 at (46,89); Close Dialogue Window; Warp Town -> Area 11 Map 1 Submap 12 at (47,73); Trigger Character Emotion Effect (89, 11); Warp Town -> Area 12 Map 89 Submap 11 at (2,13); Close Dialogue Sub-Window (10); Open Dialogue Message Window; Change Portrait Expression (24); Reset Camera Tracking (0); Display Speaker Name Box (73); Branch on Choice (89, 11); Warp Town -> Area 14 Map 73 Submap 60 at (73,60); Open Dialogue Message Window; Engine Action #9; Close Dialogue Sub-Window (9); Open Dialogue Message Window; Display Choice Selection (89, 11); Warp Town -> Area 16 Map 73 Submap 120 at (46,1); Display Dialogue Box [Bank: 0, MsgID: 10]; Teleport obj[89] to (11,2); Change Portrait Expression (24); Reset Camera Tracking (0); Branch on Choice (46, 1); Close Dialogue Window; Open Dialogue Message Window; Reset Camera Tracking (47); Engine Action #5; Engine Action #9; Exit to World Map (3, 3, 18); Dismiss Emotion Bubble (3); Reset Camera Tracking (2); Close Dialogue Sub-Window (8); Open Dialogue Message Window; Execute Choice Result (24); Engine Action #9; Open Dialogue Message Window; Set Story Flag (24, 8); Open Dialogue Message Window; Open Dialogue Sub-Window (73); Trigger Character Emotion Effect (3, 8); Warp to Castle HQ (73, 90, 24); Engine Action #9; Open Dialogue Message Window; Close Dialogue Sub-Window (24); Reset Camera Tracking (0); Clear Dialogue Sub-Window; Close Dialogue Sub-Window (9); Open Dialogue Message Window; Fade In from Black (5); Screen Fade Transition (4, 4, 0); Warp Town -> Area 30 Map 48 Submap 10 at (9,2); Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 9 Map 73 Submap 60 at (36,1); Engine Action #5; Engine Action #9; Exit to World Map (3, 2, 3); Dismiss Emotion Bubble (24); Reset Camera Tracking (0); Fade Out to Black (3); Engine Action #9; Warp to Castle HQ (24, 9, 0); Display Chapter Text (3); Reset Camera Tracking (2); Close Dialogue Sub-Window (8); Open Dialogue Message Window; Display Emotion Bubble (24, 9); Open Dialogue Message Window; Dismiss Emotion Bubble (24); Reset Camera Tracking (0); Warp Room -> Submap 5 at (9,4); Warp to Castle HQ (2, 3, 30); Set Combat Battle BGM (120); Close Dialogue Sub-Window (9); Open Dialogue Message Window; Warp Map Transition (73, 90, 3, 8, 3); Set Combat Battle BGM (60); Close Dialogue Sub-Window (8); Open Dialogue Message Window; Return to Previous Memory Map (5); Engine Action #9; Exit to World Map (2, 2, 2); Dismiss Emotion Bubble (73); Dismiss Emotion Bubble (46); Engine Action #89; Place Scenery Structure (2); Display Speaker Name Box (106); Engine Action #9; Place Scenery Structure (1); Engine Action #9; Open Dialogue Message Window; Place Scenery Structure (47); Set Combat Battle BGM (70); Set Character Quest Milestone (8, 9); Launch Tactical War Battle (4); Jump to Bytecode Offset (9, 7); Close Dialogue Window; Warp Town -> Area 23 Map 40 Submap 24 at (9,0); Return Warp to Castle Base (24, 8); Open Dialogue Message Window; Start Boss Battle #24 (BGM: 9); Open Dialogue Message Window; Launch Tactical War Battle (24); Reset Camera Tracking (0); Toggle Random Encounters (69); Warp Room -> Submap 96 at (8,101) facing 7; Open Dialogue Message Window; Place Scenery Structure (5); Engine Action #9; Pan Camera (0, 20, 106) |
| `ev[02]` | `128 (Loop)` | Story Flag 96 (bit 4) SET AND Story Flag 96 (bit 8) CLEAR AND Inventory Holds Item #128 | Set Object Direction (0, 0); Teleport Object to Coordinates (37, 128, 255) |
| `ev[03]` | `128 (Loop)` | Story Flag 96 (bit 4) SET AND Story Flag 96 (bit 8) CLEAR AND Inventory Holds Item #1 [Medicine] AND Temp Event Flag #2 SET | Engine Action #5; Screen Fade Transition (4, 5, 2); Branch on Choice (30, 36); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[04]` | `128 (Loop)` | Story Flag 96 (bit 4) SET AND Story Flag 96 (bit 8) CLEAR AND Inventory Holds Item #4 [Throat Drops] AND Temp Event Flag #8 SET | Engine Action #89; Place Scenery Structure (2); Display Choice Selection (90, 13); Exit to World Map (5, 19, 10); Dismiss Emotion Bubble (36); Reset Camera Tracking (255) |
| `ev[05]` | `128 (Loop)` | Story Flag 96 (bit 4) SET AND Story Flag 96 (bit 8) CLEAR AND Inventory Holds Item #16 [Revenge Earth] AND Temp Event Flag #32 SET | Set Combat Battle BGM (45); Engine Action #5; Reset Camera Tracking (4); Warp to Castle HQ (2, 3, 30); Launch Tactical War Battle (32) |
| `ev[06]` | `128 (Loop)` | Story Flag 96 (bit 4) SET AND Story Flag 96 (bit 8) CLEAR AND Inventory Holds Item #64 [Recipe #33] | Toggle Random Encounters (64) |

---



## Location Map: `vj10`

- **Master Map Container**: `vj10.json`
- **Submap Layer Files**: vj10_01.json, vj10_03.json, vj10_05.json, vj10_06.json, vj10_08.json, vj10_10.json
- **Collision Grid Files**: vj10_map_00.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 1

### Submap Layer `vj10_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `13` Objects | **Script Count (`evkaz`)**: `12` Scripts

#### Complete Physical Entity Inventory (13 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Jude (Sculptor)** | `140` | `(20, 21)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | Prop / Scenery | **Prop ID 33676** | `33676` | `(20, 21)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Highland Officer** | `81` | `(20, 28)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | Prop / Scenery | **Prop ID 33361** | `33361` | `(20, 28)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | Prop / Scenery | **Prop ID 33361** | `33361` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | NPC / Actor | **Raura (Scroll Keeper)** | `148` | `(20, 50)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[06]` | NPC / Actor | **Actor ID 147** | `147` | `(20, 27)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[07]` | Prop / Scenery | **Prop ID 33171** | `33171` | `(20, 27)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | NPC / Actor | **Lebrante (Appraiser)** | `141` | `(18, 31)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[09]` | Prop / Scenery | **Prop ID 33677** | `33677` | `(18, 31)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | NPC / Actor | **Actor ID 65114** | `65114` | `(18, 31)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[11]` | NPC / Actor | **Actor ID 65113** | `65113` | `(18, 31)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[12]` | Prop / Scenery | **Prop ID 33676** | `33676` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Jude (Sculptor))**: Positioned at tile `(20, 21)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Prop: Object 33676)**: Environmental world dressing prop placed at tile `(20, 21)`. Solid collision is set to `0`.
- **`obj[02]` (Highland Officer)**: Positioned at tile `(20, 28)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Prop: Object 33361)**: Environmental world dressing prop placed at tile `(20, 28)`. Solid collision is set to `0`.
- **`obj[04]` (Prop: Object 33361)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `32`.
- **`obj[05]` (Raura (Scroll Keeper))**: Positioned at tile `(20, 50)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[06]` (Object 147)**: Positioned at tile `(20, 27)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[07]` (Prop: Object 33171)**: Environmental world dressing prop placed at tile `(20, 27)`. Solid collision is set to `32`.
- **`obj[08]` (Lebrante (Appraiser))**: Positioned at tile `(18, 31)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[09]` (Prop: Object 33677)**: Environmental world dressing prop placed at tile `(18, 31)`. Solid collision is set to `0`.
- **`obj[10]` (Object 65114)**: Positioned at tile `(18, 31)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[11]` (Object 65113)**: Positioned at tile `(18, 31)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[12]` (Prop: Object 33676)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.


#### Complete Bytecode Script Catalog (12 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 115 (bit 2) SET AND Story Flag 95 (bit 1) CLEAR | Make obj[0] Hidden (disp = 0); Reset Camera Tracking (0); Screen Fade Transition (2, 13, 20); Engine Action #52; Open Dialogue Message Window; Place Scenery Structure (2); Open Dialogue Message Window; Branch on Choice (30, 1); Open Dialogue Message Window; Teleport obj[255] to (254,204) |
| `ev[01]` | `128 (Loop)` | Story Flag 115 (bit 2) SET AND Story Flag 95 (bit 1) CLEAR AND Inventory Holds Item #2 [Mega Medicine] | Set Object Direction (0, 1); Clear Chest Looted Flag (37, 2) |
| `ev[02]` | `1 (Action / Talk)` | Story Flag 115 (bit 2) SET AND Story Flag 95 (bit 1) CLEAR | Engine Action #117; Open Dialogue Message Window; Open Dialogue Message Window; Show Character Dialogue Portrait (40, 64, 36); Warp Town -> Area 54 Map 0 Submap 2 at (101,1); Open Dialogue Message Window; Close Dialogue Sub-Window (8); Open Dialogue Message Window; Pan Camera (24, 10, 0); Reset Camera Tracking (24); Reset Camera Tracking (0); Engine Action #9; Engine Action #5; Screen Fade Transition (4, 4, 3); Warp to Castle HQ (0, 0, 30); Engine Action #5; Place Scenery Structure (4); Exit to World Map (1, 21, 30); Warp to Castle HQ (10, 2, 5); Place Scenery Structure (1); Warp to Castle HQ (30, 3, 10); Warp Room -> Submap 10 at (24,13) facing South (Down); Screen Fade Transition (24, 8, 0); Close Dialogue Window; Close Dialogue Sub-Window (13); Open Dialogue Message Window; Display Dialogue Box [Bank: 24, MsgID: 8]; Open Dialogue Message Window; Place Scenery Structure (36); Warp Room -> Submap 10 at (0,14) facing 9; Set Story Milestone Flag 1 (mask 101); Engine Action #9; Pan Camera (11, 2, 2); Mark NPC Talk Interaction Complete (Flag #69); Warp Room -> Submap 45 at (1,9) facing 45; Warp Town -> Area 9 Map 46 Submap 64 at (9,46); Engine Action #128; Engine Action #9; Make obj[8] Hidden (disp = 0); Engine Action #9; Make obj[1] Hidden (disp = 0); Dismiss Character to Castle Base (18 [Nanami]); Start Boss Battle #111 (BGM: 41); Engine Action #5; Open Dialogue Message Window; Warp Room -> Submap 3 at (4,255) facing South (Down); Warp Room -> Submap 5 at (10,6) facing East (Right); Make obj[48] Hidden (disp = 0); Warp Town -> Area 255 Map 3 Submap 255 at (4,13); Engine Action #5; Screen Fade Transition (12, 0, 45); Walk obj[255] to (254,204) |
| `ev[03]` | `128 (Loop)` | Story Flag 115 (bit 2) SET AND Story Flag 95 (bit 1) CLEAR AND Inventory Holds Item #1 [Medicine] | Engine Action #5; Reset Camera Tracking (4); Exit to World Map (2, 3, 0); Start Boss Battle #30 (BGM: 255) |
| `ev[04]` | `2 (Map Init)` | Story Flag 148 (bit 64) SET AND Story Flag 95 (bit 2) CLEAR | Make obj[2] Hidden (disp = 0); Open Dialogue Message Window; Branch on Choice (25, 1); Open Dialogue Message Window; Warp Town -> Area 8 Map 24 Submap 23 at (3,8); Open Dialogue Message Window; Open Dialogue Message Window; Reset Camera Tracking (2); Animate Door Open; Branch on Choice (20, 3); Animate Door Open; Open Dialogue Message Window; Open Dialogue Message Window; Animate Door Open; Warp Town -> Area 16 Map 18 Submap 29 at (3,16); Warp Room -> Submap 16 at (2,10) facing 22; Fade In from Black (3); Screen Fade Transition (1, 0, 10); Warp Town -> Area 18 Map 16 Submap 32 at (3,18); Warp Room -> Submap 18 at (2,19) facing 29; Open Dialogue Sub-Window (3); Display Choice Selection (0, 0); Display Choice Selection (69, 2); Toggle Random Encounters (254); Teleport obj[255] to (254,204) |
| `ev[05]` | `1 (Action / Talk)` | Story Flag 148 (bit 64) SET AND Story Flag 95 (bit 2) CLEAR | Engine Action #117; Open Dialogue Message Window; Open Dialogue Message Window; Set Object Direction (0, 1); Mark Chest Looted (Byte 101, Bit 1); Warp Room -> Submap 1 at (11,1) facing Up (North); Engine Action #180; Engine Action #54; Warp Room -> Submap 24 at (14,1) facing South (Down); Close Dialogue Sub-Window (16); Warp Room -> Submap 24 at (14,1) facing Up (North); Set Combat Battle BGM (10); Engine Action #5; Dismiss Dialogue Portrait; Exit to World Map (3, 7, 5); Dismiss Emotion Bubble (73); Screen Fade Transition (43, 18, 3); Turn obj[18] facing 16; Warp to Castle HQ (0, 0, 3); Reset Camera Tracking (3); Display Speaker Name Box (1); Close Dialogue Sub-Window (18); Warp Room -> Submap 24 at (16,1) facing 4; Launch Tactical War Battle (4); Set Combat Battle BGM (10); Close Dialogue Sub-Window (8); Warp Room -> Submap 54 at (1,8) facing 24; Animate Door Open; Warp Room -> Submap 5 at (10,4) facing East (Right); Warp Town -> Area 2 Map 1 Submap 0 at (30,24); Screen Fade Transition (1, 7, 46); Engine Action #89; Branch on Choice (2, 0); Set Character Quest Milestone (19, 20); Warp Room -> Submap 0 at (20,47) facing 90; Branch on Choice (18, 2); Dismiss Emotion Bubble (46); Engine Action #89; Branch on Choice (2, 1); Engine Action #89; Engine Action #9; Warp Town -> Area 5 Map 106 Submap 8 at (9,1); Reset Camera Tracking (0); Engine Action #9; Teleport obj[73] to (60,89); Branch on Choice (2, 2); Engine Action #89; Engine Action #9; Warp Town -> Area 6 Map 24 Submap 8 at (1,8); Engine Action #89; Engine Action #9; Warp Town -> Area 7 Map 73 Submap 90 at (24,8); Warp Room -> Submap 89 at (9,2) facing 8; Set Combat Battle BGM (60); Engine Action #89; Engine Action #9; Warp Town -> Area 12 Map 90 Submap 9 at (16,6); Dismiss Emotion Bubble (89); Engine Action #9; Warp Town -> Area 9 Map 90 Submap 9 at (18,1); Dismiss Emotion Bubble (89); Engine Action #9; Warp Town -> Area 10 Map 73 Submap 30 at (3,10); Warp to Castle HQ (46, 106, 10); Close Dialogue Window; Engine Action #89; Close Dialogue Window; Warp Town -> Area 0 Map 1 Submap 10 at (0,11); Teleport obj[73] to (180,89); Close Dialogue Window; Warp Town -> Area 2 Map 73 Submap 30 at (24,10); Warp Room -> Submap 46 at (89,11) facing Up (North); Warp to Castle HQ (89, 9, 2); Close Dialogue Window; Teleport obj[73] to (140,89); Close Dialogue Window; Warp Town -> Area 4 Map 3 Submap 10 at (1,73); Screen Fade Transition (89, 11, 2); Engine Action #5; Engine Action #90; Close Dialogue Window; Change Portrait Expression (7); Dismiss Emotion Bubble (46); Set Character Quest Milestone (9, 8); Warp to Castle HQ (8, 1, 0); Reset Camera Tracking (1); Engine Action #9; Teleport obj[89] to (11,2); Exit to World Map (73, 10, 89); Close Dialogue Window; Warp Town -> Area 6 Map 46 Submap 89 at (15,2); Open Dialogue Message Window; Set Character Quest Milestone (14, 15); Warp Room -> Submap 0 at (15,47) facing 73; Trigger Character Emotion Effect (89, 15); Warp Town -> Area 1 Map 89 Submap 11 at (2,6); Set Combat Battle BGM (20); Make obj[106] Hidden (disp = 0); Close Dialogue Window; Screen Fade Transition (1, 11, 0); Screen Fade Transition (47, 5, 10); Pan Camera (7, 30, 73); Trigger Character Emotion Effect (24, 14); Warp Room -> Submap 89 at (15,2) facing Up (North); Close Dialogue Sub-Window (14); Warp Room -> Submap 36 at (16,89) facing 15; Warp Town -> Area 3 Map 2 Submap 14 at (20,23); Set Combat Battle BGM (240); Make obj[3] Hidden (disp = 0); Display Choice Selection (2, 106); Branch on Choice (19, 1); Branch on Choice (0, 19); Teleport obj[5] to (19,4); Engine Action #5; Engine Action #6; Warp Room -> Submap 43 at (19,6) facing 48; Display Choice Selection (14, 3); Warp to Castle HQ (1, 1, 9); Make obj[89] Hidden (disp = 0); Branch on Choice (2, 3); Set Character Quest Milestone (19, 20); Warp Room -> Submap 0 at (20,47) facing 24; Display Choice Selection (1, 13); Engine Action #89; Show Dialogue Portrait (2, 4, 24); Animate Door Open; Warp Room -> Submap 24 at (19,1) facing 15; Make obj[106] Hidden (disp = 0); Branch on Choice (19, 1); Branch on Choice (0, 19); Teleport obj[55] to (19,27); Display Emotion Bubble (8, 55); Display Choice Selection (22, 50); Reset Camera Tracking (24); Reset Camera Tracking (1); Dismiss Dialogue Portrait; Close Dialogue Sub-Window (14); Warp Room -> Submap 24 at (8,1) facing 18; Close Dialogue Sub-Window (14); Warp Room -> Submap 24 at (8,1) facing 20; Turn obj[8] facing 14; Warp to Castle HQ (3, 1, 1); Engine Action #9; Warp to Castle HQ (8, 2, 24); Reset Camera Tracking (1); Execute Choice Result (24); Animate Door Open; Warp Room -> Submap 24 at (8,1) facing 23; Set Combat Battle BGM (80); Warp to Castle HQ (8, 3, 24); Reset Camera Tracking (1); Close Dialogue Sub-Window (24); Animate Door Open; Warp Room -> Submap 3 at (8,2) facing 24; Reset Camera Tracking (1); Fade In from Black (89); Show Dialogue Portrait (2, 5, 73); Trigger Character Emotion Effect (3, 8); Open Dialogue Message Window; Close Dialogue Sub-Window (8); Warp Room -> Submap 46 at (89,12) facing Up (North); Reset Camera Tracking (106); Screen Fade Transition (12, 0, 12); Warp Room -> Submap 47 at (73,30) facing 101; Exit to World Map (58, 73, 30); Jump to Bytecode Offset (0, 208); Close Dialogue Sub-Window (10); Warp Room -> Submap 24 at (8,1) facing 29; Make obj[0] Hidden (disp = 0); Dismiss Dialogue Portrait; Warp Town -> Area 16 Map 17 Submap 49 at (43,16); Engine Action #5; Teleport obj[48] to (16,14); Warp Town -> Area 1 Map 0 Submap 1 at (9,46); Engine Action #89; Change Portrait Expression (2); Open Dialogue Message Window; Set Character Quest Milestone (16, 17); Warp Room -> Submap 0 at (17,47) facing 24; Dismiss Dialogue Portrait; Warp Room -> Submap 3 at (8,2) facing 89; Change Portrait Expression (2); Warp Room -> Submap 8 at (1,31) facing 89; Change Portrait Expression (2); Warp Town -> Area 24 Map 16 Submap 1 at (32,89); Change Portrait Expression (2); Warp to Castle HQ (48, 8, 16); Warp to Castle HQ (2, 0, 0); Engine Action #9; Warp to Castle HQ (8, 2, 24); Reset Camera Tracking (1); Return to Previous Memory Map (89); Change Portrait Expression (2); Exit to World Map (24, 16, 1); Return Warp to Castle Base (102, 0); Engine Action #117; Warp Room -> Submap 9 at (95,2) facing 84; Display Choice Selection (40, 10); Make obj[32] Visible (disp = 1); Close Dialogue Window; Warp Town -> Area 2 Map 180 Submap 69 at (3,111); Award Potch Loot (+1,280 Potch); Warp Room -> Submap 3 at (4,255) facing South (Down); Warp Room -> Submap 5 at (10,6) facing East (Right); Engine Action #52; Engine Action #52; Warp Town -> Area 255 Map 3 Submap 255 at (4,13); Engine Action #5; Screen Fade Transition (12, 0, 50); Walk obj[255] to (254,204) |
| `ev[06]` | `128 (Loop)` | Story Flag 148 (bit 64) SET AND Story Flag 95 (bit 2) CLEAR AND Inventory Holds Item #64 [Recipe #33] | Toggle Random Encounters (64) |
| `ev[07]` | `128 (Loop)` | Story Flag 148 (bit 64) SET AND Story Flag 95 (bit 2) CLEAR AND Inventory Holds Item #16 [Revenge Earth] | Jump to Bytecode Offset (7, 1); Set Combat Battle BGM (120); Jump to Bytecode Offset (4, 58); Set Combat Battle BGM (120); Jump to Bytecode Offset (0, 208); Set Combat Battle BGM (10); Jump to Bytecode Offset (0, 176); Set Combat Battle BGM (10); Jump to Bytecode Offset (1, 0); Toggle Random Encounters (16) |
| `ev[08]` | `128 (Loop)` | Story Flag 148 (bit 64) SET AND Story Flag 95 (bit 2) CLEAR AND Inventory Holds Item #1 [Medicine] | Engine Action #5; Screen Fade Transition (4, 3, 7); Warp to Castle HQ (30, 73, 20); Engine Action #5; Dismiss Dialogue Portrait; Exit to World Map (3, 1, 5); Dismiss Emotion Bubble (37); Warp Room -> Submap 2 at (255,254) facing 204 |
| `ev[09]` | `128 (Loop)` | Story Flag 148 (bit 64) SET AND Story Flag 95 (bit 2) CLEAR AND Inventory Holds Item #4 [Throat Drops] | Set Entity Movement Speed (2, 5); Dismiss Dialogue Portrait; Exit to World Map (3, 0, 20); Dismiss Emotion Bubble (255); Engine Action #5; Display Speaker Name Box (4); Warp to Castle HQ (0, 20, 30); Walk obj[1] to (18,1); Dismiss Dialogue Portrait; Toggle Random Encounters (4); Launch Tactical War Battle (8) |
| `ev[10]` | `2 (Map Init)` | Always Passes (Unconditional) | Warp to Castle HQ (0, 1, 255) |
| `ev[11]` | `1 (Action / Talk)` | Player within Box [17..23, 2..51] AND Condition Check #52 AND Story Flag 0 (mask 255) SET | Place Scenery Structure (5); Engine Action #9; Warp Town -> Area 2 Map 96 Submap 132 at (255,254) |

---



## Location Map: `vj11`

- **Master Map Container**: `vj11.json`
- **Submap Layer Files**: vj11_00.json, vj11_01.json, vj11_02.json
- **Collision Grid Files**: vj11_map_00.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 1

### Submap Layer `vj11_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `5`)
- **Entity Count (`okaz`)**: `17` Objects | **Script Count (`evkaz`)**: `23` Scripts

#### Complete Physical Entity Inventory (17 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | Trigger / Hitbox | **Hitbox Zone (7x2)** | `0` | `(189, 160)` | `6x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[01]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(197, 194)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Actor ID 64615** | `64615` | `(118, 199)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | NPC / Actor | **Actor ID 64615** | `64615` | `(113, 194)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | NPC / Actor | **Actor ID 64615** | `64615` | `(123, 194)` | `0x0` | Up (North) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | Prop / Scenery | **Prop ID 64613** | `64613` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | Prop / Scenery | **Prop ID 64613** | `64613` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Prop / Scenery | **Prop ID 64613** | `64613` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Prop / Scenery | **Prop ID 64614** | `64614` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Prop / Scenery | **Prop ID 64614** | `64614` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Prop / Scenery | **Prop ID 64614** | `64614` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Prop / Scenery | **Prop ID 64616** | `64616` | `(118, 196)` | `0x0` | Frame 16 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | Prop / Scenery | **Prop ID 64616** | `64616` | `(113, 194)` | `0x0` | Up (North) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | Prop / Scenery | **Prop ID 64616** | `64616` | `(123, 194)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | Trigger / Hitbox | **Hitbox Zone (3x5)** | `0` | `(117, 195)` | `2x4` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[15]` | Trigger / Hitbox | **Hitbox Zone (6x2)** | `0` | `(110, 193)` | `5x1` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[16]` | Trigger / Hitbox | **Hitbox Zone (6x3)** | `0` | `(122, 193)` | `5x2` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Hitbox Zone)**: Bounding trigger area covering `7` tiles wide by `2` tiles high from `(189, 160)` to `(195, 161)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[01]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(197, 194)` to `(200, 195)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[02]` (Object 64615)**: Positioned at tile `(118, 199)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Object 64615)**: Positioned at tile `(113, 194)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Object 64615)**: Positioned at tile `(123, 194)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Prop: Object 64613)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[06]` (Prop: Object 64613)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[07]` (Prop: Object 64613)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[08]` (Prop: Object 64614)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[09]` (Prop: Object 64614)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[10]` (Prop: Object 64614)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[11]` (Prop: Object 64616)**: Environmental world dressing prop placed at tile `(118, 196)`. Solid collision is set to `128`.
- **`obj[12]` (Prop: Object 64616)**: Environmental world dressing prop placed at tile `(113, 194)`. Solid collision is set to `128`.
- **`obj[13]` (Prop: Object 64616)**: Environmental world dressing prop placed at tile `(123, 194)`. Solid collision is set to `128`.
- **`obj[14]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `5` tiles high from `(117, 195)` to `(119, 199)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[15]` (Hitbox Zone)**: Bounding trigger area covering `6` tiles wide by `2` tiles high from `(110, 193)` to `(115, 194)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[16]` (Hitbox Zone)**: Bounding trigger area covering `6` tiles wide by `3` tiles high from `(122, 193)` to `(127, 195)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (23 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `128 (Loop)` | Player within Box [184..200, 2..107] AND Condition Check #156 AND Story Flag 1 (mask 255) SET | Warp Room -> Submap 0 at (9,2) |
| `ev[01]` | `128 (Loop)` | Player within Box [40..56, 2..107] AND Condition Check #156 AND Story Flag 1 (mask 255) SET | Warp Room -> Submap 0 at (9,2) |
| `ev[02]` | `128 (Loop)` | Player within Box [99..138, 2..191] AND Condition Check #203 | Warp Room -> Submap 0 at (9,2) |
| `ev[03]` | `128 (Loop)` | Player within Box [35..57, 2..200] AND Condition Check #215 | Warp Room -> Submap 0 at (9,3) |
| `ev[04]` | `128 (Loop)` | Player within Box [182..205, 2..200] AND Condition Check #215 | Warp Room -> Submap 0 at (9,3) |
| `ev[05]` | `1 (Action / Talk)` | Player within Box [46..50, 2..113] AND Condition Check #114 AND Story Flag 1 (mask 255) SET | Warp Map Transition (3, 0, 42, 65, 255) |
| `ev[06]` | `1 (Action / Talk)` | Player within Box [46..50, 2..170] AND Condition Check #171 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 42]; Engine Action #199 |
| `ev[07]` | `1 (Action / Talk)` | Player within Box [40..44, 2..195] AND Condition Check #196 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 48]; Engine Action #167 |
| `ev[08]` | `1 (Action / Talk)` | Player within Box [67..68, 2..203] AND Condition Check #210 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 97]; Engine Action #196 |
| `ev[09]` | `1 (Action / Talk)` | Player within Box [94..95, 2..192] AND Condition Check #200 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 65]; Engine Action #207 |
| `ev[10]` | `1 (Action / Talk)` | Player within Box [141..142, 2..192] AND Condition Check #200 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 175]; Engine Action #207 |
| `ev[11]` | `1 (Action / Talk)` | Player within Box [172..173, 2..200] AND Condition Check #210 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 139]; Engine Action #196 |
| `ev[12]` | `1 (Action / Talk)` | Player within Box [196..200, 2..193] AND Condition Check #194 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 192]; Engine Action #157 |
| `ev[13]` | `1 (Action / Talk)` | Player within Box [190..194, 2..103] AND Condition Check #104 AND Story Flag 1 (mask 255) SET | Warp Map Transition (3, 0, 204, 65, 255) |
| `ev[14]` | `1 (Action / Talk)` | Player within Box [114..122, 2..190] AND Condition Check #191 AND Story Flag 1 (mask 255) SET | Warp Map Transition (3, 0, 118, 157, 255) |
| `ev[15]` | `1 (Action / Talk)` | Player within Box [40..44, 2..218] AND Condition Check #219 AND Story Flag 0 (mask 255) SET | Warp Map Transition (3, 0, 96, 109, 255) |
| `ev[16]` | `1 (Action / Talk)` | Player within Box [196..200, 2..218] AND Condition Check #219 AND Story Flag 0 (mask 255) SET | Warp Map Transition (3, 0, 144, 109, 255) |
| `ev[17]` | `1 (Action / Talk)` | Target Inspected is obj[8] | Open Dialogue Sub-Window (0); Open Dialogue Message Window |
| `ev[18]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Open Dialogue Sub-Window (0); Open Dialogue Message Window |
| `ev[19]` | `2 (Map Init)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 221 (bit 16) CLEAR | Make obj[0] Hidden (disp = 0); Screen Fade Transition (0, 11, 0); Display Dialogue Box [Bank: 43, MsgID: 10]; Engine Action #6; Open Shop Menu #6 (Type: 11); Open Shop Menu #6 (Type: 12); Teleport obj[255] to (254,204) |
| `ev[20]` | `2 (Map Init)` | Story Flag 220 (bit 1) SET | Make obj[1] Hidden (disp = 0); Screen Fade Transition (1, 11, 1); Display Dialogue Box [Bank: 1, MsgID: 19]; Warp Room -> Submap 1 at (21,1) facing 22; Warp Room -> Submap 1 at (24,47) facing 255 |
| `ev[21]` | `2 (Map Init)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 221 (bit 16) SET | Make obj[1] Hidden (disp = 0); Dismiss Dialogue Portrait; Warp Room -> Submap 1 at (18,0) facing 19; Open Dialogue Message Window; Branch on Choice (0, 21); Open Dialogue Message Window; Set Story Flag (0, 23); Open Dialogue Message Window; Close Dialogue Sub-Window (47) |
| `ev[22]` | `1 (Action / Talk)` | Story Flag 220 (bit 1) CLEAR AND Story Flag 221 (bit 16) CLEAR AND Player within Box [114..122, 2..192] AND Condition Check #194 | Make obj[72] Hidden (disp = 0); Warp Room -> Submap 2 at (72,1) facing 11; Warp Town -> Area 72 Map 1 Submap 12 at (2,47); Set Combat Battle BGM (20); Make obj[72] Hidden (disp = 0); Open Dialogue Message Window; Screen Fade Transition (72, 0, 11); Load Sound Bank into Memory (0, 12); Teleport obj[46] to (106,10); Place Scenery Structure (106); Close Dialogue Window; Animate Door Open; Set Character Quest Milestone (12, 15); Engine Action #89; Place Scenery Structure (2); Warp Room -> Submap 14 at (2,3) facing 89; Show Dialogue Portrait (2, 2, 1); Screen Fade Transition (1, 11, 1); Display Dialogue Box [Bank: 0, MsgID: 13]; Open Dialogue Message Window; Animate Door Open; Open Dialogue Message Window; Show Dialogue Portrait (47, 89, 13); Engine Action #5; Engine Action #89; Place Scenery Structure (5); Make obj[106] Hidden (disp = 0); Place Scenery Structure (16); Set Character Quest Milestone (14, 17); Set Character Quest Milestone (15, 18); Engine Action #89; Dismiss Dialogue Portrait; Warp Town -> Area 1 Map 89 Submap 17 at (2,3); Engine Action #89; Display Speaker Name Box (2); Warp Town -> Area 1 Map 13 Submap 1 at (14,1); Show Dialogue Portrait (0, 16, 0); Change Portrait Expression (0); Display Speaker Name Box (47); Set Entity Movement Speed (3, 90); Dismiss Dialogue Portrait; Exit to World Map (6, 17, 2); Dismiss Emotion Bubble (255); Engine Action #90; Change Portrait Expression (4); Engine Action #6; Display Choice Selection (2, 30); Engine Action #90; Display Speaker Name Box (4); Engine Action #6; Display Speaker Name Box (2); Dismiss Emotion Bubble (255); Walk obj[9] to (221,16); Engine Action #83; Warp Room -> Submap 255 at (254,204) facing 204 |

---



## Location Map: `vj12`

- **Master Map Container**: `vj12.json`
- **Submap Layer Files**: Embedded in master
- **Collision Grid Files**: vj12_map_00.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 1

### Submap Layer `vj12_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `3` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (3 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `128 (Loop)` | Player within Box [173..174, 2..85] AND Condition Check #115 AND Story Flag 3 (mask 255) SET | Warp Room -> Submap 1 at (3,1) |
| `ev[01]` | `128 (Loop)` | Player within Box [145..146, 2..85] AND Condition Check #115 AND Story Flag 2 (mask 255) SET | Warp Room -> Submap 2 at (12,3) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [49..51, 2..34] AND Condition Check #35 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 43]; Engine Action #44 |

---



## Location Map: `vj13`

- **Master Map Container**: `vj13.json`
- **Submap Layer Files**: vj13_01.json, vj13_06.json, vj13_11.json
- **Collision Grid Files**: vj13_map_00.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 1

### Submap Layer `vj13_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `19` Objects | **Script Count (`evkaz`)**: `12` Scripts

#### Complete Physical Entity Inventory (19 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Jude (Sculptor)** | `140` | `(20, 21)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | Prop / Scenery | **Prop ID 33932** | `33932` | `(20, 21)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Highland Officer** | `81` | `(20, 28)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | NPC / Actor | **Raura (Scroll Keeper)** | `148` | `(20, 50)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[04]` | NPC / Actor | **Actor ID 144** | `144` | `(20, 50)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[05]` | NPC / Actor | **Actor ID 143** | `143` | `(20, 50)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[06]` | NPC / Actor | **Actor ID 151** | `151` | `(20, 50)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[07]` | NPC / Actor | **Actor ID 65104** | `65104` | `(20, 50)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[08]` | NPC / Actor | **Actor ID 65104** | `65104` | `(20, 50)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[09]` | NPC / Actor | **Actor ID 65104** | `65104` | `(20, 50)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[10]` | NPC / Actor | **Actor ID 65104** | `65104` | `(20, 50)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[11]` | NPC / Actor | **Culgan** | `87` | `(20, 50)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[12]` | NPC / Actor | **Actor ID 118** | `118` | `(20, 50)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[13]` | NPC / Actor | **Actor ID 117** | `117` | `(20, 50)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[14]` | NPC / Actor | **Actor ID 142** | `142` | `(20, 20)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[15]` | NPC / Actor | **Jeane (Rune Sage)** | `145` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[16]` | NPC / Actor | **Actor ID 65113** | `65113` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[17]` | NPC / Actor | **Actor ID 65114** | `65114` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[18]` | NPC / Actor | **Actor ID 65114** | `65114` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Jude (Sculptor))**: Positioned at tile `(20, 21)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Prop: Object 33932)**: Environmental world dressing prop placed at tile `(20, 21)`. Solid collision is set to `0`.
- **`obj[02]` (Highland Officer)**: Positioned at tile `(20, 28)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Raura (Scroll Keeper))**: Positioned at tile `(20, 50)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Object 144)**: Positioned at tile `(20, 50)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Object 143)**: Positioned at tile `(20, 50)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[06]` (Object 151)**: Positioned at tile `(20, 50)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[07]` (Object 65104)**: Positioned at tile `(20, 50)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[08]` (Object 65104)**: Positioned at tile `(20, 50)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[09]` (Object 65104)**: Positioned at tile `(20, 50)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[10]` (Object 65104)**: Positioned at tile `(20, 50)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[11]` (Culgan)**: Positioned at tile `(20, 50)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[12]` (Object 118)**: Positioned at tile `(20, 50)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[13]` (Object 117)**: Positioned at tile `(20, 50)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[14]` (Object 142)**: Positioned at tile `(20, 20)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[15]` (Jeane (Rune Sage))**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[16]` (Object 65113)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[17]` (Object 65114)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[18]` (Object 65114)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.


#### Complete Bytecode Script Catalog (12 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 114 (bit 16) SET AND Story Flag 95 (bit 8) CLEAR | Make obj[2] Hidden (disp = 0); Reset Camera Tracking (20); Place Scenery Structure (3); Reset Camera Tracking (0); Open Dialogue Message Window; Reset Camera Tracking (2); Screen Fade Transition (20, 19, 3); Screen Fade Transition (1, 0, 10); Warp Town -> Area 19 Map 16 Submap 15 at (3,19); Open Dialogue Message Window; Open Dialogue Message Window; Display Choice Selection (2, 20); Place Scenery Structure (14); Warp to Castle HQ (20, 0, 0); Branch on Choice (2, 12); Close Dialogue Sub-Window (14); Warp to Castle HQ (12, 0, 0); Display Dialogue Box [Bank: 2, MsgID: 13]; Fade Out to Black (15); Warp to Castle HQ (13, 0, 0); Place Scenery Structure (2); Show Dialogue Portrait (26, 19, 3); Show Dialogue Portrait (2, 0, 15); Warp Town -> Area 16 Map 26 Submap 24 at (3,16); Warp Town -> Area 0 Map 16 Submap 2 at (17,14); Display Choice Selection (3, 17); Warp to Castle HQ (0, 17, 2); Display Speaker Name Box (14); Close Dialogue Sub-Window (3); Display Speaker Name Box (3); Open Dialogue Message Window; Display Speaker Name Box (2); Open Dialogue Message Window; Branch on Choice (20, 1); Open Dialogue Message Window; Toggle Random Encounters (254); Teleport obj[255] to (254,204) |
| `ev[01]` | `1 (Action / Talk)` | Story Flag 114 (bit 16) SET AND Story Flag 95 (bit 8) CLEAR | Jump to Bytecode Offset (1, 0); Engine Action #111; Award Potch Loot (+1,280 Potch); Warp Room -> Submap 3 at (4,255) facing South (Down); Warp Room -> Submap 10 at (6,51) facing 5; Warp Town -> Area 255 Map 3 Submap 255 at (4,109); Screen Fade Transition (12, 255, 5); Close Dialogue Sub-Window (8); Warp Room -> Submap 24 at (10,1) facing West (Left); Close Dialogue Sub-Window (8); Warp Room -> Submap 5 at (10,4) facing 4; Warp Room -> Submap 30 at (24,10) facing West (Left); Warp to Castle HQ (3, 12, 3); Warp to Castle HQ (13, 2, 5); Branch on Choice (4, 4); Open Dialogue Message Window; Warp Room -> Submap 73 at (100,3) facing 12; Open Dialogue Message Window; Warp to Castle HQ (13, 0, 5); Reset Camera Tracking (4); Warp to Castle HQ (0, 2, 30); Make obj[1] Hidden (disp = 0); Reset Camera Tracking (2); Engine Action #9; Branch on Choice (15, 0); Engine Action #9; Teleport obj[24] to (8,1); Exit to World Map (89, 9, 2); Warp Room -> Submap 10 at (101,0) facing 176; Set Combat Battle BGM (20); Close Dialogue Sub-Window (10); Warp Room -> Submap 89 at (9,2) facing Up (North); Set Combat Battle BGM (30); Jump to Bytecode Offset (0, 210); Set Combat Battle BGM (30); Jump to Bytecode Offset (0, 178); Close Dialogue Sub-Window (8); Warp Room -> Submap 24 at (10,1) facing 7; Engine Action #89; Engine Action #9; Warp Town -> Area 3 Map 24 Submap 8 at (1,8); Engine Action #89; Engine Action #9; Warp Town -> Area 4 Map 73 Submap 15 at (101,0); Engine Action #177; Close Dialogue Sub-Window (10); Warp Room -> Submap 46 at (1,9) facing South (Down); Reset Camera Tracking (47); Launch Tactical War Battle (1); Jump to Bytecode Offset (9, 7); Close Dialogue Window; Warp Town -> Area 2 Map 200 Submap 69 at (1,101); Engine Action #9; Show Dialogue Portrait (102, 0, 117); Warp Room -> Submap 9 at (95,8) facing 74; Warp Room -> Submap 45 at (1,9) facing 45; Warp Town -> Area 9 Map 46 Submap 1 at (9,46); Reset Camera Tracking (9); Make obj[64] Hidden (disp = 0); Engine Action #9; Make obj[128] Hidden (disp = 0); Dismiss Character to Castle Base (3 [Viktor]); Engine Action #39; Dismiss Character to Castle Base (2 [Flik]); Engine Action #39; Engine Action #111; Award Potch Loot (+1,286 Potch); Pan Camera (8, 9, 10); Engine Action #6; Pan Camera (13, 5, 10); Engine Action #6; Warp to Castle HQ (52, 52, 255); Reset Camera Tracking (255); Engine Action #9; Screen Fade Transition (13, 5, 10); Display Dialogue Box [Bank: 0, MsgID: 50]; Walk obj[255] to (254,204) |
| `ev[02]` | `128 (Loop)` | Story Flag 114 (bit 16) SET AND Story Flag 95 (bit 8) CLEAR AND Inventory Holds Item #1 [Medicine] | Exit to World Map (10, 20, 24); Engine Action #9; Set Entity Movement Speed (2, 4); Screen Fade Transition (28, 36, 8); Engine Action #5; Dismiss Dialogue Portrait; Pan Camera (4, 30, 255); Walk obj[37] to (1,255) |
| `ev[03]` | `2 (Map Init)` | Story Flag 119 (bit 1) SET AND Story Flag 95 (bit 4) CLEAR | Make obj[2] Hidden (disp = 0); Reset Camera Tracking (20); Place Scenery Structure (3); Reset Camera Tracking (0); Open Dialogue Message Window; Reset Camera Tracking (2); Screen Fade Transition (16, 15, 3); Screen Fade Transition (3, 0, 10); Warp Town -> Area 11 Map 24 Submap 15 at (3,11); Warp Town -> Area 0 Map 11 Submap 2 at (12,16); Display Choice Selection (3, 12); Warp to Castle HQ (0, 12, 2); Place Scenery Structure (24); Display Choice Selection (3, 13); Warp Town -> Area 0 Map 13 Submap 2 at (14,20); Set Story Flag (3, 14); Warp Room -> Submap 14 at (2,15) facing 15; Display Dialogue Box [Bank: 3, MsgID: 15]; Open Dialogue Message Window; Open Dialogue Message Window; Show Dialogue Portrait (2, 16, 25); Display Dialogue Box [Bank: 3, MsgID: 16]; Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Dialogue Portrait; Warp Town -> Area 17 Map 16 Submap 24 at (3,17); Warp Room -> Submap 17 at (2,18) facing 24; Close Dialogue Sub-Window (3); Display Speaker Name Box (1); Open Dialogue Message Window; Display Speaker Name Box (2); Open Dialogue Message Window; Branch on Choice (20, 1); Open Dialogue Message Window; Teleport obj[255] to (254,204) |
| `ev[04]` | `1 (Action / Talk)` | Story Flag 119 (bit 1) SET AND Story Flag 95 (bit 4) CLEAR | Jump to Bytecode Offset (1, 0); Engine Action #5; Close Dialogue Window; Exit to World Map (4, 2, 1); Dismiss Emotion Bubble (24); Close Dialogue Window; Open Dialogue Message Window; Open Dialogue Message Window; Close Dialogue Sub-Window (8); Open Dialogue Message Window; Warp Room -> Submap 11 at (1,24) facing 11; Open Dialogue Message Window; Warp Town -> Area 5 Map 10 Submap 4 at (4,3); Warp Room -> Submap 24 at (10,0) facing East (Right); Close Dialogue Sub-Window (8); Open Dialogue Message Window; Exit to World Map (5, 14, 4); Warp to Castle HQ (1, 3, 30); Close Dialogue Sub-Window (14); Open Dialogue Message Window; Engine Action #5; Jump to Bytecode Offset (9, 8); Wait for Audio / Window Sync (1); Close Dialogue Window; Warp Town -> Area 2 Map 200 Submap 73 at (20,9); Set Story Milestone Flag 4 (mask 117); Warp Room -> Submap 9 at (47,1) facing 9; Teleport obj[16] to (9,47); Warp Map Transition (9, 46, 128, 9, 45); Warp Room -> Submap 45 at (2,9) facing 46; Warp Room -> Submap 46 at (2,9) facing 46; Reset Camera Tracking (74); Warp Room -> Submap 41 at (5,6) facing 7; Reset Camera Tracking (9); Screen Fade Transition (255, 6, 255); Pan Camera (13, 5, 10); Engine Action #6; Warp to Castle HQ (52, 52, 255); Reset Camera Tracking (13); Engine Action #5; Screen Fade Transition (12, 0, 50); Walk obj[255] to (9,255); Screen Fade Transition (13, 5, 10); Display Dialogue Box [Bank: 7, MsgID: 56]; Full Rest & Healing (Restore HP/MP) |
| `ev[05]` | `2 (Map Init)` | Story Flag 119 (bit 128) SET AND Story Flag 119 (bit 32) SET AND Story Flag 95 (bit 16) CLEAR | Make obj[2] Hidden (disp = 0); Execute Choice Result (20); Display Choice Selection (3, 21); Warp Room -> Submap 21 at (2,17) facing 18; Display Choice Selection (3, 17); Warp Room -> Submap 17 at (2,18) facing 22; Display Choice Selection (3, 18); Warp Room -> Submap 18 at (47,255) facing 254 |
| `ev[06]` | `2 (Map Init)` | Story Flag 119 (bit 128) SET AND Story Flag 95 (bit 16) CLEAR | Make obj[2] Hidden (disp = 0); Reset Camera Tracking (20); Place Scenery Structure (3); Reset Camera Tracking (0); Open Dialogue Message Window; Reset Camera Tracking (2); Screen Fade Transition (15, 15, 3); Screen Fade Transition (3, 0, 10); Warp Town -> Area 11 Map 25 Submap 15 at (3,11); Warp Town -> Area 0 Map 11 Submap 2 at (12,15); Display Choice Selection (3, 12); Warp to Castle HQ (0, 12, 2); Place Scenery Structure (25); Display Choice Selection (3, 13); Warp Town -> Area 0 Map 13 Submap 2 at (14,25); Set Story Flag (3, 14); Warp Town -> Area 0 Map 14 Submap 2 at (16,26); Display Dialogue Box [Bank: 3, MsgID: 16]; Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Dialogue Portrait; Warp Town -> Area 15 Map 14 Submap 12 at (3,15); Open Dialogue Message Window; Open Dialogue Message Window; Show Dialogue Portrait (2, 0, 20); Branch on Choice (1, 0); Teleport obj[255] to (254,204) |
| `ev[07]` | `1 (Action / Talk)` | Story Flag 119 (bit 128) SET AND Story Flag 119 (bit 32) SET AND Story Flag 95 (bit 16) CLEAR | Jump to Bytecode Offset (1, 0); Engine Action #5; Reset Camera Tracking (4); Warp Town -> Area 0 Map 2 Submap 30 at (24,8); Open Dialogue Message Window; Engine Action #6; Close Dialogue Sub-Window (21); Open Dialogue Message Window; Pan Camera (5, 8, 4); Warp Town -> Area 1 Map 2 Submap 0 at (0,30); Set Combat Battle BGM (40); Close Dialogue Sub-Window (8); Open Dialogue Message Window; Reset Camera Tracking (24); Execute Choice Result (0); Engine Action #9; Close Dialogue Sub-Window (8); Open Dialogue Message Window; Screen Fade Transition (49, 3, 5); Execute Choice Result (4); Exit to World Map (0, 5, 2); Screen Fade Transition (0, 16, 30); Engine Action #5; Change Portrait Expression (4); Exit to World Map (0, 5, 2); Screen Fade Transition (0, 16, 30); Engine Action #5; Display Speaker Name Box (4); Exit to World Map (0, 5, 2); Screen Fade Transition (0, 16, 30); Walk obj[24] to (8,0); Close Dialogue Window; Engine Action #9; Set Story Milestone Flag 16 (mask 255) |
| `ev[08]` | `1 (Action / Talk)` | Story Flag 119 (bit 128) SET AND Story Flag 119 (bit 32) CLEAR AND Story Flag 95 (bit 16) CLEAR | Jump to Bytecode Offset (1, 0); Engine Action #5; Reset Camera Tracking (4); Exit to World Map (0, 1, 30); Close Dialogue Sub-Window (8); Open Dialogue Message Window; Display Dialogue Box [Bank: 24, MsgID: 10]; Open Dialogue Message Window; Place Scenery Structure (24); Reset Camera Tracking (0); Animate Door Open; Engine Action #9; Set Story Milestone Flag 16 (mask 255) |
| `ev[09]` | `1 (Action / Talk)` | Story Flag 119 (bit 128) SET AND Story Flag 95 (bit 16) SET AND Story Flag 95 (bit 32) CLEAR | Engine Action #5; Close Dialogue Window; Exit to World Map (4, 2, 1); Dismiss Emotion Bubble (24); Close Dialogue Window; Open Dialogue Message Window; Show Dialogue Portrait (24, 8, 0); Dismiss Dialogue Portrait; Close Dialogue Sub-Window (11); Open Dialogue Message Window; Change Portrait Expression (5); Reset Camera Tracking (4); Warp to Castle HQ (0, 3, 30); Set Combat Battle BGM (60); Close Dialogue Sub-Window (8); Open Dialogue Message Window; Display Speaker Name Box (101); Engine Action #9; Reset Camera Tracking (73); Branch on Choice (46, 9); Set Story Milestone Flag 32 (mask 9); Make obj[1] Visible (disp = 1); Engine Action #9; Make obj[2] Visible (disp = 1); Engine Action #9; Make obj[1] Hidden (disp = 0); Engine Action #9; Make obj[8] Hidden (disp = 0); Engine Action #9; Make obj[128] Hidden (disp = 0); Engine Action #9; Teleport obj[1] to (9,47); Dismiss Dialogue Portrait; Engine Action #9; Teleport obj[32] to (9,47); Animate Doorway State (9, 47); Engine Action #128; Engine Action #9; Turn obj[1] facing 47; Wait for Audio / Window Sync (3); Close Dialogue Window; Warp Town -> Area 2 Map 200 Submap 117 at (1,254); Engine Action #102; Open Dialogue Message Window; Set Special Scene BGM (1); Engine Action #111; Award Potch Loot (+1,286 Potch); Pan Camera (8, 9, 10); Engine Action #6; Pan Camera (13, 5, 10); Engine Action #6; Warp to Castle HQ (52, 52, 255); Reset Camera Tracking (13); Engine Action #5; Screen Fade Transition (12, 0, 50); Walk obj[255] to (9,255); Screen Fade Transition (13, 5, 10); Display Dialogue Box [Bank: 7, MsgID: 56]; Full Rest & Healing (Restore HP/MP) |
| `ev[10]` | `2 (Map Init)` | Story Flag 220 (bit 4) SET | Make obj[0] Hidden (disp = 0); Set Story Flag (2, 8); Branch on Choice (13, 3); Reset Camera Tracking (0); Open Dialogue Message Window; Reset Camera Tracking (2); Place Scenery Structure (16); Show Dialogue Portrait (3, 13, 0); Open Dialogue Message Window; Place Scenery Structure (2); Display Dialogue Box [Bank: 24, MsgID: 15]; Warp to Castle HQ (12, 0, 0); Display Dialogue Box [Bank: 2, MsgID: 10]; Display Chapter Text (17); Warp to Castle HQ (10, 0, 0); Screen Fade Transition (2, 23, 12); Change Portrait Expression (3); Open Dialogue Sub-Window (0); Open Dialogue Message Window; Open Dialogue Sub-Window (2); Close Dialogue Sub-Window (23); Close Dialogue Window; Warp to Castle HQ (24, 0, 0); Close Dialogue Sub-Window (2); Clear Dialogue Sub-Window; Fade In from Black (11); Warp to Castle HQ (25, 0, 0); Clear Dialogue Sub-Window; Warp Town -> Area 26 Map 29 Submap 11 at (3,26); Open Dialogue Message Window; Open Dialogue Message Window; Fade In from Black (2); Show Dialogue Portrait (26, 20, 3); Show Dialogue Portrait (2, 0, 15); Warp Town -> Area 16 Map 26 Submap 24 at (3,16); Warp Town -> Area 0 Map 16 Submap 2 at (17,14); Branch on Choice (3, 17); Warp to Castle HQ (0, 17, 2); Display Speaker Name Box (14); Close Dialogue Sub-Window (3); Display Speaker Name Box (3); Open Dialogue Message Window; Display Speaker Name Box (2); Open Dialogue Message Window; Branch on Choice (20, 1); Open Dialogue Message Window; Teleport obj[255] to (254,204) |
| `ev[11]` | `1 (Action / Talk)` | Story Flag 220 (bit 4) SET | Jump to Bytecode Offset (1, 0); Close Dialogue Window; Warp Room -> Submap 90 at (73,30) facing 5; Set Story Flag (1, 1); Dismiss Emotion Bubble (24); Set Story Flag (2, 0); Engine Action #5; Reset Camera Tracking (0); Warp Room -> Submap 24 at (8,2) facing West (Left); Engine Action #5; Set Story Flag (4, 3); Pan Camera (1, 30, 24); Set Story Flag (2, 2); Close Dialogue Sub-Window (8); Warp Town -> Area 3 Map 24 Submap 22 at (2,4); Warp to Castle HQ (8, 3, 73); Engine Action #5; Warp to Castle HQ (8, 1, 24); Reset Camera Tracking (2); Engine Action #5; Set Entity Movement Speed (2, 56); Show Dialogue Portrait (22, 3, 2); Warp Room -> Submap 9 at (255,254) facing 56; Change Portrait Expression (22); Warp Town -> Area 2 Map 1 Submap 0 at (9,255); Walk obj[24] to (22,2); Engine Action #6; Close Dialogue Sub-Window (12); Warp Town -> Area 7 Map 24 Submap 13 at (2,8); Make obj[3] Hidden (disp = 0); Set Story Flag (2, 43); Set Story Flag (4, 3); Show Dialogue Portrait (2, 3, 17); Warp Town -> Area 47 Map 73 Submap 30 at (49,3); Engine Action #5; Set Story Flag (2, 10); Open Dialogue Message Window; Display Speaker Name Box (30); Engine Action #5; Show Dialogue Portrait (2, 10, 0); Display Speaker Name Box (30); Engine Action #5; Change Portrait Expression (2); Screen Fade Transition (0, 18, 30); Walk obj[46] to (1,22); Warp Room -> Submap 1 at (17,47) facing 73; Trigger Character Emotion Effect (5, 8); Warp Room -> Submap 30 at (73,10) facing East (Right); Reset Camera Tracking (3); Set Combat Battle BGM (5); Warp to Castle HQ (8, 0, 24); Reset Camera Tracking (2); Engine Action #9; Set Combat Battle BGM (120); Close Dialogue Sub-Window (8); Warp Town -> Area 10 Map 73 Submap 120 at (56,10); Reset Camera Tracking (3); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Engine Action #9; Warp to Castle HQ (10, 1, 24); Screen Fade Transition (2, 11, 24); Reset Camera Tracking (2); Display Dialogue Box [Bank: 24, MsgID: 10]; Warp Town -> Area 13 Map 73 Submap 30 at (24,8); Warp Town -> Area 14 Map 24 Submap 10 at (2,15); Set Combat Battle BGM (60); Jump to Bytecode Offset (9, 8); Close Dialogue Window; Warp Town -> Area 2 Map 90 Submap 10 at (220,4); Place Scenery Structure (5); Pan Camera (10, 0, 64); Dismiss Character to Castle Base (255) |

---



## Location Map: `vj14`

- **Master Map Container**: `vj14.json`
- **Submap Layer Files**: Embedded in master
- **Collision Grid Files**: vj14_map_00.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 1

### Submap Layer `vj14_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `34` Objects | **Script Count (`evkaz`)**: `2` Scripts

#### Complete Physical Entity Inventory (34 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 143** | `143` | `(-3, 9)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Actor ID 89** | `89` | `(-17, 16)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Rowd** | `85` | `(-10, 16)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | NPC / Actor | **Youth Brigade Recruit** | `3` | `(-10, 20)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | NPC / Actor | **Gorudo** | `34` | `(-17, 20)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | NPC / Actor | **Actor ID 144** | `144` | `(0, 0)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | NPC / Actor | **Raura (Scroll Keeper)** | `148` | `(0, 0)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | NPC / Actor | **Actor ID 65105** | `65105` | `(-3, 18)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | NPC / Actor | **Actor ID 65105** | `65105` | `(-6, 17)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | NPC / Actor | **Actor ID 65105** | `65105` | `(-6, 19)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | NPC / Actor | **Actor ID 65105** | `65105` | `(-13, 15)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | NPC / Actor | **Actor ID 65105** | `65105` | `(-13, 17)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | NPC / Actor | **Actor ID 65105** | `65105` | `(-13, 19)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | NPC / Actor | **Actor ID 65105** | `65105` | `(-13, 21)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | NPC / Actor | **Actor ID 65105** | `65105` | `(-20, 15)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[15]` | NPC / Actor | **Actor ID 65105** | `65105` | `(-20, 17)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[16]` | NPC / Actor | **Actor ID 65105** | `65105` | `(-20, 19)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[17]` | NPC / Actor | **Actor ID 65105** | `65105` | `(-20, 21)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[18]` | NPC / Actor | **Actor ID 65105** | `65105` | `(0, 0)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[19]` | NPC / Actor | **Actor ID 65105** | `65105` | `(0, 0)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[20]` | NPC / Actor | **Actor ID 65105** | `65105` | `(0, 0)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[21]` | NPC / Actor | **Actor ID 65104** | `65104` | `(0, 0)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[22]` | NPC / Actor | **Actor ID 65104** | `65104` | `(0, 0)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[23]` | NPC / Actor | **Actor ID 65104** | `65104` | `(0, 0)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[24]` | NPC / Actor | **Actor ID 65104** | `65104` | `(0, 0)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[25]` | NPC / Actor | **Actor ID 65104** | `65104` | `(0, 0)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[26]` | NPC / Actor | **Actor ID 65104** | `65104` | `(0, 0)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[27]` | NPC / Actor | **Actor ID 65104** | `65104` | `(0, 0)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[28]` | NPC / Actor | **Actor ID 65104** | `65104` | `(0, 0)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[29]` | NPC / Actor | **Actor ID 65104** | `65104` | `(0, 0)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[30]` | NPC / Actor | **Actor ID 65104** | `65104` | `(0, 0)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[31]` | NPC / Actor | **Actor ID 65104** | `65104` | `(0, 0)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[32]` | NPC / Actor | **Actor ID 65104** | `65104` | `(0, 0)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[33]` | NPC / Actor | **Actor ID 65104** | `65104` | `(0, 0)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 143)**: Positioned at tile `(-3, 9)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Object 89)**: Positioned at tile `(-17, 16)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Rowd)**: Positioned at tile `(-10, 16)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Youth Brigade Recruit)**: Positioned at tile `(-10, 20)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Gorudo)**: Positioned at tile `(-17, 20)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Object 144)**: Positioned at tile `(0, 0)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[06]` (Raura (Scroll Keeper))**: Positioned at tile `(0, 0)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[07]` (Object 65105)**: Positioned at tile `(-3, 18)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[08]` (Object 65105)**: Positioned at tile `(-6, 17)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[09]` (Object 65105)**: Positioned at tile `(-6, 19)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[10]` (Object 65105)**: Positioned at tile `(-13, 15)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[11]` (Object 65105)**: Positioned at tile `(-13, 17)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[12]` (Object 65105)**: Positioned at tile `(-13, 19)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[13]` (Object 65105)**: Positioned at tile `(-13, 21)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[14]` (Object 65105)**: Positioned at tile `(-20, 15)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[15]` (Object 65105)**: Positioned at tile `(-20, 17)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[16]` (Object 65105)**: Positioned at tile `(-20, 19)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[17]` (Object 65105)**: Positioned at tile `(-20, 21)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[18]` (Object 65105)**: Positioned at tile `(0, 0)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[19]` (Object 65105)**: Positioned at tile `(0, 0)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[20]` (Object 65105)**: Positioned at tile `(0, 0)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[21]` (Object 65104)**: Positioned at tile `(0, 0)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[22]` (Object 65104)**: Positioned at tile `(0, 0)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[23]` (Object 65104)**: Positioned at tile `(0, 0)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[24]` (Object 65104)**: Positioned at tile `(0, 0)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[25]` (Object 65104)**: Positioned at tile `(0, 0)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[26]` (Object 65104)**: Positioned at tile `(0, 0)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[27]` (Object 65104)**: Positioned at tile `(0, 0)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[28]` (Object 65104)**: Positioned at tile `(0, 0)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[29]` (Object 65104)**: Positioned at tile `(0, 0)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[30]` (Object 65104)**: Positioned at tile `(0, 0)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[31]` (Object 65104)**: Positioned at tile `(0, 0)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[32]` (Object 65104)**: Positioned at tile `(0, 0)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[33]` (Object 65104)**: Positioned at tile `(0, 0)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.


#### Complete Bytecode Script Catalog (2 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 90 (bit 1) SET AND Story Flag 90 (bit 2) CLEAR | Make obj[3] Hidden (disp = 0); Open Dialogue Message Window; Warp to Castle HQ (1, 0, 3); Screen Fade Transition (3, 1, 10); Warp to Castle HQ (9, 3, 1); Engine Action #9; Warp to Castle HQ (11, 3, 1); Close Dialogue Window; Warp to Castle HQ (12, 3, 1); Display Dialogue Box [Bank: 3, MsgID: 16]; Warp to Castle HQ (1, 16, 3); Change Portrait Expression (3); Warp Room -> Submap 3 at (18,3) facing West (Left); Display Speaker Name Box (3); Display Choice Selection (3, 1); Display Choice Selection (3, 20); Warp to Castle HQ (1, 20, 3); Execute Choice Result (3); Warp Room -> Submap 3 at (22,3) facing West (Left); Set Story Flag (3, 23); Warp to Castle HQ (1, 23, 3); Close Dialogue Sub-Window (3); Warp Room -> Submap 3 at (25,3) facing West (Left); Clear Dialogue Sub-Window; Warp Town -> Area 26 Map 0 Submap 22 at (3,26); Warp to Castle HQ (1, 26, 2); Fade Out to Black (0); Branch on Choice (3, 27); Warp to Castle HQ (1, 27, 2); Display Chapter Text (0); Close Dialogue Sub-Window (3); Display Chapter Text (3); Warp Room -> Submap 3 at (15,3) facing West (Left); Show Dialogue Portrait (47, 255, 254) |
| `ev[01]` | `1 (Action / Talk)` | Story Flag 90 (bit 1) SET AND Story Flag 90 (bit 2) CLEAR AND Player Y within Range [14..22] | Engine Action #44; Make obj[0] Hidden (disp = 0); Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Dialogue Portrait; Open Dialogue Message Window; Change Portrait Expression (0); Screen Fade Transition (0, 11, 0); Display Speaker Name Box (0); Display Choice Selection (0, 20); Open Dialogue Message Window; Execute Choice Result (0); Display Dialogue Box [Bank: 0, MsgID: 9]; Open Dialogue Message Window; Set Story Flag (0, 23); Open Dialogue Message Window; Close Dialogue Sub-Window (0); Clear Dialogue Sub-Window; Teleport obj[49] to (15,5); Open Dialogue Message Window; Exit to World Map (3, 3, 30); Dismiss Emotion Bubble (255); Engine Action #5; Screen Fade Transition (4, 3, 3); Dismiss Emotion Bubble (30); Engine Action #5; Close Dialogue Window; Exit to World Map (3, 3, 30); Dismiss Emotion Bubble (255); Engine Action #5; Display Dialogue Box [Bank: 4, MsgID: 3]; Warp to Castle HQ (30, 30, 255); Engine Action #5; Engine Action #9; Exit to World Map (3, 3, 30); Dismiss Emotion Bubble (255); Engine Action #5; Dismiss Dialogue Portrait; Exit to World Map (3, 3, 30); Dismiss Emotion Bubble (255); Engine Action #5; Change Portrait Expression (4); Warp to Castle HQ (3, 30, 30); Engine Action #5; Display Speaker Name Box (4); Warp to Castle HQ (3, 30, 30); Engine Action #5; Display Choice Selection (4, 3); Warp to Castle HQ (30, 30, 255); Engine Action #5; Branch on Choice (4, 3); Warp to Castle HQ (30, 30, 255); Engine Action #5; Execute Choice Result (4); Warp to Castle HQ (3, 30, 30); Engine Action #5; Set Story Flag (4, 3); Warp to Castle HQ (30, 30, 255); Engine Action #5; Open Dialogue Sub-Window (4); Warp to Castle HQ (3, 30, 30); Engine Action #5; Close Dialogue Sub-Window (4); Warp to Castle HQ (3, 30, 30); Engine Action #5; Clear Dialogue Sub-Window; Exit to World Map (3, 3, 30); Dismiss Emotion Bubble (255); Walk obj[5] to (15,5); Engine Action #5; Dismiss Emotion Bubble (0); Show Dialogue Portrait (5, 15, 4); Engine Action #5; Warp to Castle HQ (10, 30, 49); Warp Town -> Area 5 Map 23 Submap 4 at (1,2); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Close Dialogue Sub-Window (4); Warp Room -> Submap 0 at (30,255) facing 254; Walk obj[5] to (23,4); Warp to Castle HQ (2, 1, 30); Set Combat Battle BGM (30); Engine Action #5; Open Dialogue Sub-Window (4); Warp to Castle HQ (3, 2, 30); Set Combat Battle BGM (30); Set Entity Movement Speed (3, 5); Display Dialogue Box [Bank: 4, MsgID: 2]; Warp Room -> Submap 30 at (255,254) facing 5; Engine Action #9; Exit to World Map (3, 2, 0); Dismiss Emotion Bubble (255); Engine Action #5; Close Dialogue Sub-Window (4); Warp to Castle HQ (3, 0, 30); Walk obj[73] to (10,49); Warp Town -> Area 5 Map 12 Submap 4 at (2,1); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Engine Action #9; Exit to World Map (3, 3, 1); Dismiss Emotion Bubble (255); Walk obj[73] to (10,5); Open Dialogue Message Window; Exit to World Map (2, 2, 0); Dismiss Emotion Bubble (73); Dismiss Emotion Bubble (49); Show Dialogue Portrait (5, 0, 4); Warp to Castle HQ (2, 4, 30); Engine Action #5; Screen Fade Transition (4, 2, 2); Open Dialogue Message Window; Warp Room -> Submap 0 at (0,30) facing 255; Engine Action #5; Close Dialogue Window; Exit to World Map (2, 2, 0); Open Dialogue Message Window; Warp Room -> Submap 0 at (30,255) facing 254; Engine Action #5; Display Dialogue Box [Bank: 4, MsgID: 2]; Warp Town -> Area 0 Map 0 Submap 1 at (1,0); Dismiss Emotion Bubble (255); Engine Action #5; Engine Action #9; Exit to World Map (2, 2, 0); Warp Room -> Submap 0 at (0,30) facing 255; Engine Action #5; Dismiss Dialogue Portrait; Exit to World Map (3, 2, 0); Warp Room -> Submap 0 at (0,30) facing 255; Engine Action #5; Change Portrait Expression (4); Warp to Castle HQ (2, 0, 0); Warp Town -> Area 1 Map 0 Submap 30 at (255,254); Engine Action #5; Display Speaker Name Box (4); Warp to Castle HQ (2, 0, 1); Warp to Castle HQ (0, 0, 30); Engine Action #5; Display Choice Selection (4, 3); Warp Town -> Area 0 Map 1 Submap 3 at (0,0); Dismiss Emotion Bubble (255); Engine Action #5; Branch on Choice (4, 3); Warp Town -> Area 0 Map 0 Submap 3 at (1,0); Dismiss Emotion Bubble (255); Engine Action #5; Execute Choice Result (4); Warp to Castle HQ (2, 0, 0); Warp to Castle HQ (1, 0, 30); Engine Action #5; Set Story Flag (4, 3); Warp Town -> Area 0 Map 1 Submap 3 at (0,0); Dismiss Emotion Bubble (255); Engine Action #5; Open Dialogue Sub-Window (4); Warp to Castle HQ (2, 0, 1); Warp to Castle HQ (0, 0, 30); Engine Action #5; Close Dialogue Sub-Window (4); Warp to Castle HQ (2, 0, 0); Warp to Castle HQ (1, 0, 30); Engine Action #5; Clear Dialogue Sub-Window; Exit to World Map (3, 2, 0); Open Dialogue Message Window; Warp to Castle HQ (1, 0, 30); Walk obj[5] to (15,4); Exit to World Map (3, 9, 30); Close Dialogue Sub-Window (15); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Engine Action #9; Exit to World Map (1, 0, 1); Dismiss Emotion Bubble (24); Engine Action #9; Open Dialogue Message Window; Warp Room -> Submap 10 at (4,2) facing South (Down); Warp Room -> Submap 0 at (30,24) facing 10; Open Dialogue Message Window; Warp Town -> Area 5 Map 9 Submap 4 at (1,3); Open Dialogue Message Window; Dismiss Emotion Bubble (24); Engine Action #9; Open Dialogue Message Window; Warp to Castle HQ (73, 45, 24); Screen Fade Transition (0, 4, 49); Engine Action #6; Engine Action #5; Open Dialogue Message Window; Exit to World Map (4, 3, 4); Dismiss Emotion Bubble (255); Engine Action #5; Dismiss Dialogue Portrait; Exit to World Map (4, 0, 2); Dismiss Emotion Bubble (255); Engine Action #5; Change Portrait Expression (4); Exit to World Map (1, 2, 30); Engine Action #5; Display Dialogue Box [Bank: 4, MsgID: 4]; Warp Town -> Area 6 Map 30 Submap 255 at (254,5); Close Dialogue Sub-Window (4); Exit to World Map (1, 2, 30); Engine Action #5; Clear Dialogue Sub-Window; Exit to World Map (4, 1, 2); Dismiss Emotion Bubble (255); Walk obj[5] to (15,4); Engine Action #5; Warp Town -> Area 20 Map 30 Submap 1 at (15,49); Engine Action #6; Engine Action #5; Open Dialogue Message Window; Exit to World Map (5, 3, 40); Dismiss Emotion Bubble (255); Engine Action #5; Dismiss Dialogue Portrait; Exit to World Map (5, 3, 40); Dismiss Emotion Bubble (255); Engine Action #5; Change Portrait Expression (4); Engine Action #5; Warp to Castle HQ (40, 30, 255); Engine Action #5; Display Dialogue Box [Bank: 4, MsgID: 5]; Warp Town -> Area 15 Map 30 Submap 255 at (254,5); Close Dialogue Sub-Window (4); Engine Action #5; Warp Town -> Area 15 Map 30 Submap 255 at (254,5); Clear Dialogue Sub-Window; Exit to World Map (5, 2, 15); Dismiss Emotion Bubble (255); Walk obj[46] to (1,0); Warp Room -> Submap 1 at (17,1) facing 12; Warp Room -> Submap 1 at (25,47) facing 49; Engine Action #6; Engine Action #5; Display Speaker Name Box (4); Exit to World Map (0, 3, 30); Engine Action #5; Display Choice Selection (4, 4); Open Dialogue Message Window; Warp to Castle HQ (30, 255, 254); Engine Action #5; Branch on Choice (4, 3); Warp Town -> Area 3 Map 1 Submap 1 at (30,255); Engine Action #5; Execute Choice Result (4); Warp to Castle HQ (1, 1, 3); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Set Story Flag (4, 3); Open Dialogue Message Window; Warp Town -> Area 3 Map 0 Submap 30 at (255,254); Engine Action #5; Open Dialogue Sub-Window (4); Warp to Castle HQ (0, 3, 3); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Walk obj[5] to (10,4); Exit to World Map (3, 2, 5); Make obj[0] Visible (disp = 1); Open Dialogue Message Window; Engine Action #5; Trigger Character Emotion Effect (2, 0); Dismiss Emotion Bubble (49); Exit to World Map (5, 10, 5); Engine Action #6; Exit to World Map (5, 3, 45); Dismiss Emotion Bubble (255); Engine Action #5; Display Speaker Name Box (4); Engine Action #5; Warp to Castle HQ (45, 30, 255); Engine Action #5; Display Choice Selection (4, 5); Warp to Castle HQ (45, 30, 255); Engine Action #5; Close Dialogue Window; Exit to World Map (2, 3, 0); Dismiss Emotion Bubble (255); Walk obj[5] to (9,4); Warp Town -> Area 3 Map 3 Submap 30 at (46,1); Screen Fade Transition (1, 18, 1); Display Choice Selection (47, 73); Full Rest & Healing (Restore HP/MP); Engine Action #5; Engine Action #9; Exit to World Map (2, 0, 2); Dismiss Emotion Bubble (73); Dismiss Emotion Bubble (24); Engine Action #9; Open Dialogue Message Window; Engine Action #5; Engine Action #5; Close Dialogue Window; Exit to World Map (1, 3, 1); Dismiss Emotion Bubble (24); Close Dialogue Window; Open Dialogue Message Window; Engine Action #6; Engine Action #5; Engine Action #9; Exit to World Map (1, 3, 0); Dismiss Emotion Bubble (73); Show Dialogue Portrait (24, 9, 0); Pan Camera (5, 9, 4); Warp Town -> Area 0 Map 0 Submap 30 at (73,60); Engine Action #5; Close Dialogue Window; Exit to World Map (1, 2, 1); Warp Room -> Submap 30 at (24,11) facing South (Down); Reset Camera Tracking (49); Warp Town -> Area 5 Map 20 Submap 4 at (3,1); Warp Town -> Area 3 Map 0 Submap 30 at (255,254); Engine Action #5; Execute Choice Result (4); Warp to Castle HQ (3, 0, 30); Walk obj[73] to (30,5); Engine Action #9; Exit to World Map (2, 2, 0); Dismiss Emotion Bubble (49); Engine Action #5; Engine Action #5; Close Dialogue Window; Exit to World Map (3, 2, 35); Dismiss Emotion Bubble (255); Engine Action #5; Branch on Choice (5, 125); Exit to World Map (3, 2, 25); Dismiss Emotion Bubble (255); Engine Action #5; Execute Choice Result (5); Dismiss Character Dialogue Portrait; Exit to World Map (3, 2, 25); Dismiss Emotion Bubble (255); Engine Action #5; Set Story Flag (5, 85); Exit to World Map (3, 0, 0); Engine Action #5; Engine Action #85; Warp Town -> Area 0 Map 30 Submap 255 at (254,5); Open Dialogue Sub-Window (5); Engine Action #85; Exit to World Map (3, 0, 0); Engine Action #5; Engine Action #85; Warp Town -> Area 0 Map 30 Submap 255 at (254,50); Make obj[1] Hidden (disp = 0); Close Dialogue Window; Warp Room -> Submap 1 at (21,47) facing South (Down); Fade In from Black (5); Fade In from Black (4); Exit to World Map (3, 3, 30); Make obj[0] Hidden (disp = 0); Fade Out to Black (0); Display Chapter Text (47); Set Entity Movement Speed (3, 5); Fade In from Black (4); Exit to World Map (3, 7, 30); Engine Action #5; Fade Out to Black (4); Exit to World Map (3, 7, 30); Engine Action #5; Display Chapter Text (4); Exit to World Map (3, 7, 30); Walk obj[49] to (3,5); Engine Action #9; Exit to World Map (1, 0, 2); Dismiss Emotion Bubble (255); Engine Action #5; Set Story Flag (4, 1); Warp to Castle HQ (0, 30, 255); Engine Action #5; Open Dialogue Sub-Window (4); Warp Room -> Submap 0 at (30,255) facing 254; Walk obj[73] to (60,24); Engine Action #9; Open Dialogue Message Window; Engine Action #9; Set Entity Movement Speed (6, 5); Engine Action #9; Exit to World Map (3, 2, 1); Warp Room -> Submap 2 at (0,30) facing 255; Engine Action #5; Set Story Flag (4, 4); Open Dialogue Message Window; Warp Room -> Submap 255 at (254,5) facing 23; Exit to World Map (4, 3, 2); Dismiss Emotion Bubble (255); Engine Action #5; Fade In from Black (4); Exit to World Map (1, 2, 3); Warp to Castle HQ (30, 255, 254); Engine Action #5; Fade Out to Black (4); Exit to World Map (1, 1, 3); Warp to Castle HQ (30, 255, 254); Engine Action #5; Display Chapter Text (4); Exit to World Map (1, 3, 3); Warp to Castle HQ (30, 255, 254); Walk obj[73] to (60,49); Engine Action #6; Engine Action #5; Engine Action #9; Exit to World Map (5, 3, 50); Dismiss Emotion Bubble (255); Engine Action #5; Set Story Flag (4, 5); Warp to Castle HQ (55, 30, 255); Engine Action #5; Open Dialogue Sub-Window (4); Engine Action #5; Warp to Castle HQ (55, 30, 255); Engine Action #5; Fade In from Black (4); Engine Action #5; Warp to Castle HQ (55, 30, 255); Engine Action #5; Fade Out to Black (4); Engine Action #5; Warp to Castle HQ (55, 30, 255); Engine Action #5; Display Chapter Text (4); Engine Action #5; Warp to Castle HQ (55, 30, 255); Walk obj[5] to (9,4); Warp Room -> Submap 0 at (30,9) facing 90; Exit to World Map (42, 15, 9); Animate Door Open; Open Dialogue Message Window; Branch on Choice (42, 255) |

---



## Location Map: `vj15`

- **Master Map Container**: `vj15.json`
- **Submap Layer Files**: Embedded in master
- **Collision Grid Files**: vj15_map_00.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 1

### Submap Layer `vj15_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `24` Objects | **Script Count (`evkaz`)**: `6` Scripts

#### Complete Physical Entity Inventory (24 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 89** | `89` | `(0, 0)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Rowd** | `85` | `(0, 0)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Youth Brigade Recruit** | `3` | `(0, 0)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | NPC / Actor | **Jowy Atreides** | `2` | `(0, 0)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | NPC / Actor | **Raura (Scroll Keeper)** | `148` | `(0, 0)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | NPC / Actor | **Actor ID 65105** | `65105` | `(0, 0)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | NPC / Actor | **Actor ID 65105** | `65105` | `(0, 0)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | NPC / Actor | **Actor ID 65105** | `65105` | `(0, 0)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | NPC / Actor | **Actor ID 65105** | `65105` | `(0, 0)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | NPC / Actor | **Actor ID 65105** | `65105` | `(0, 0)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | NPC / Actor | **Actor ID 65105** | `65105` | `(0, 0)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | NPC / Actor | **Actor ID 65105** | `65105` | `(0, 0)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | NPC / Actor | **Actor ID 65105** | `65105` | `(0, 0)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | World Device | **Mechanism (ano 5)** | `0` | `(14, 36)` | `0x0` | Frame 5 | Visible (1) | Solid (Obstacle) | 4 | 1 | 180 |
| `obj[14]` | World Device | **Mechanism (ano 6)** | `0` | `(14, 36)` | `0x0` | Frame 6 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 1 | 180 |
| `obj[15]` | Prop / Scenery | **Prop ID 64985** | `64985` | `(6, 44)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[16]` | Prop / Scenery | **Prop ID 64985** | `64985` | `(35, 37)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[17]` | Prop / Scenery | **Prop ID 64985** | `64985` | `(15, 13)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[18]` | Prop / Scenery | **Prop ID 64985** | `64985` | `(12, 37)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[19]` | Prop / Scenery | **Prop ID 64985** | `64985` | `(30, 41)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[20]` | Prop / Scenery | **Prop ID 64985** | `64985` | `(27, 14)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[21]` | Prop / Scenery | **Prop ID 64985** | `64985` | `(12, 27)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[22]` | Prop / Scenery | **Prop ID 64985** | `64985` | `(16, 19)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[23]` | Prop / Scenery | **Prop ID 64985** | `64985` | `(32, 24)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 89)**: Positioned at tile `(0, 0)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Rowd)**: Positioned at tile `(0, 0)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Youth Brigade Recruit)**: Positioned at tile `(0, 0)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Jowy Atreides)**: Positioned at tile `(0, 0)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Raura (Scroll Keeper))**: Positioned at tile `(0, 0)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Object 65105)**: Positioned at tile `(0, 0)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[06]` (Object 65105)**: Positioned at tile `(0, 0)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[07]` (Object 65105)**: Positioned at tile `(0, 0)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[08]` (Object 65105)**: Positioned at tile `(0, 0)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[09]` (Object 65105)**: Positioned at tile `(0, 0)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[10]` (Object 65105)**: Positioned at tile `(0, 0)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[11]` (Object 65105)**: Positioned at tile `(0, 0)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[12]` (Object 65105)**: Positioned at tile `(0, 0)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[13]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(14, 36)` with state parameter `5`.
- **`obj[14]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(14, 36)` with state parameter `6`.
- **`obj[15]` (Prop: Object 64985)**: Environmental world dressing prop placed at tile `(6, 44)`. Solid collision is set to `2`.
- **`obj[16]` (Prop: Object 64985)**: Environmental world dressing prop placed at tile `(35, 37)`. Solid collision is set to `2`.
- **`obj[17]` (Prop: Object 64985)**: Environmental world dressing prop placed at tile `(15, 13)`. Solid collision is set to `2`.
- **`obj[18]` (Prop: Object 64985)**: Environmental world dressing prop placed at tile `(12, 37)`. Solid collision is set to `2`.
- **`obj[19]` (Prop: Object 64985)**: Environmental world dressing prop placed at tile `(30, 41)`. Solid collision is set to `2`.
- **`obj[20]` (Prop: Object 64985)**: Environmental world dressing prop placed at tile `(27, 14)`. Solid collision is set to `2`.
- **`obj[21]` (Prop: Object 64985)**: Environmental world dressing prop placed at tile `(12, 27)`. Solid collision is set to `2`.
- **`obj[22]` (Prop: Object 64985)**: Environmental world dressing prop placed at tile `(16, 19)`. Solid collision is set to `2`.
- **`obj[23]` (Prop: Object 64985)**: Environmental world dressing prop placed at tile `(32, 24)`. Solid collision is set to `2`.


#### Complete Bytecode Script Catalog (6 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 90 (bit 4) SET AND Story Flag 90 (bit 8) CLEAR | Make obj[2] Hidden (disp = 0); Open Dialogue Message Window; Branch on Choice (42, 3); Open Dialogue Message Window; Warp Room -> Submap 0 at (2,8) facing 18; Set Entity Movement Speed (3, 8); Warp Room -> Submap 8 at (2,12) facing 22; Branch on Choice (3, 12); Open Dialogue Message Window; Warp Room -> Submap 89 at (23,2) facing 18; Engine Action #89; Close Dialogue Sub-Window (2); Display Choice Selection (89, 25); Warp Town -> Area 20 Map 89 Submap 26 at (2,21); Engine Action #89; Fade Out to Black (2); Set Story Flag (89, 28); Warp Town -> Area 23 Map 89 Submap 29 at (2,24); Engine Action #89; Dismiss Emotion Bubble (2); Clear Dialogue Sub-Window; Engine Action #89; Warp Room -> Submap 2 at (26,0); Open Dialogue Sub-Window (0); Close Dialogue Sub-Window (0); Clear Dialogue Sub-Window; Open Dialogue Message Window; Fade In from Black (0); Fade Out to Black (0); Display Chapter Text (0); Display Emotion Bubble (0, 30); Open Dialogue Message Window; Warp Room -> Submap 36 at (128,47) |
| `ev[01]` | `128 (Loop)` | Inventory Holds Item #128 | Toggle Random Encounters (128); Set Object Direction (0, 1); Engine Action #99; Launch Tactical War Battle (64) |
| `ev[02]` | `1 (Action / Talk)` | Story Flag 90 (bit 4) SET AND Story Flag 90 (bit 8) CLEAR AND Player within Box [20..20, 2..42] AND Condition Check #42 | Engine Action #54; Warp Room -> Submap 101 at (0,176) facing South (Down); Reset Camera Tracking (0); Display Dialogue Box [Bank: 5, MsgID: 8]; Exit to World Map (3, 1, 10); Dismiss Emotion Bubble (73); Trigger Character Emotion Effect (24, 8); Open Dialogue Message Window; Screen Fade Transition (73, 60, 28); Warp Room -> Submap 4 at (73,60) facing 5; Display Dialogue Box [Bank: 4, MsgID: 3]; Open Dialogue Message Window; Reset Camera Tracking (30); Display Chapter Text (0); Engine Action #5; Warp Town -> Area 24 Map 12 Submap 0 at (11,73); Dismiss Emotion Bubble (24); Reset Camera Tracking (0); Display Dialogue Box [Bank: 73, MsgID: 60]; Engine Action #5; Display Dialogue Box [Bank: 4, MsgID: 2]; Warp Town -> Area 3 Map 30 Submap 24 at (12,0); Place Scenery Structure (73); Dismiss Emotion Bubble (24); Reset Camera Tracking (0); Animate Door Open; Set Combat Battle BGM (30); Engine Action #5; Display Dialogue Box [Bank: 4, MsgID: 2]; Open Dialogue Message Window; Warp Room -> Submap 73 at (90,24) facing 12; Open Dialogue Message Window; Show Dialogue Portrait (73, 30, 5); Reset Camera Tracking (4); Warp to Castle HQ (3, 4, 30); Set Combat Battle BGM (30); Close Dialogue Sub-Window (8); Open Dialogue Message Window; Dismiss Dialogue Portrait; Set Combat Battle BGM (60); Engine Action #5; Display Dialogue Box [Bank: 4, MsgID: 1]; Warp Town -> Area 0 Map 30 Submap 73 at (60,24); Display Dialogue Box [Bank: 0, MsgID: 17]; Set Combat Battle BGM (90); Engine Action #5; Display Dialogue Box [Bank: 4, MsgID: 1]; Warp Room -> Submap 30 at (73,30) facing 5; Reset Camera Tracking (4); Engine Action #5; Warp Room -> Submap 30 at (24,8) facing South (Down); Display Speaker Name Box (73); Dismiss Emotion Bubble (5); Display Dialogue Box [Bank: 4, MsgID: 3]; Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (24); Display Dialogue Box [Bank: 0, MsgID: 19]; Set Combat Battle BGM (30); Engine Action #5; Reset Camera Tracking (4); Engine Action #6; Warp Room -> Submap 30 at (24,8) facing South (Down); Branch on Choice (36, 32); Set Combat Battle BGM (60); Jump to Bytecode Offset (0, 178); Engine Action #5; Reset Camera Tracking (4); Engine Action #6; Warp to Castle HQ (0, 30, 73); Trigger Character Emotion Effect (101, 0); Engine Action #179; Engine Action #5; Reset Camera Tracking (4); Engine Action #6; Open Dialogue Message Window; Exit to World Map (1, 0, 30); Jump to Bytecode Offset (0, 180); Warp Room -> Submap 0 at (22,73) facing 60; Jump to Bytecode Offset (0, 177); Set Combat Battle BGM (120); Set Combat Battle BGM (120); Engine Action #9; Engine Action #90; Reset Camera Tracking (11); Warp Town -> Area 2 Map 40 Submap 101 at (5,176); Jump to Bytecode Offset (9, 8); Set Combat Battle BGM (60); Wait for Audio / Window Sync (2); Display Dialogue Box [Bank: 0, MsgID: 24]; Walk obj[37] to (128,255) |
| `ev[03]` | `128 (Loop)` | Story Flag 90 (bit 4) SET AND Story Flag 90 (bit 8) CLEAR AND Inventory Holds Item #32 [Drinking Set] | Toggle Random Encounters (32); Dismiss Emotion Bubble (0); Engine Action #5; Warp Room -> Submap 60 at (5,0) facing 255 |
| `ev[04]` | `2 (Map Init)` | Story Flag 90 (bit 8) SET AND Story Flag 90 (bit 16) CLEAR | Make obj[2] Hidden (disp = 0); Open Dialogue Message Window; Close Dialogue Sub-Window (50); Warp to Castle HQ (0, 1, 0); Open Dialogue Message Window; Warp Town -> Area 9 Map 18 Submap 54 at (3,9); Warp Room -> Submap 9 at (2,8) facing South (Down); Display Chapter Text (3); Reset Camera Tracking (3); Warp Room -> Submap 2 at (10,0) facing 26; Warp to Castle HQ (10, 3, 1); Screen Fade Transition (2, 11, 21); Set Entity Movement Speed (3, 11); Warp Room -> Submap 11 at (2,13) facing 29; Make obj[3] Hidden (disp = 0); Place Scenery Structure (1); Open Dialogue Message Window; Place Scenery Structure (2); Animate Door Open; Close Dialogue Sub-Window (58); Warp to Castle HQ (14, 1, 0); Animate Door Open; Warp Town -> Area 15 Map 20 Submap 59 at (3,15); Warp Room -> Submap 15 at (2,16) facing 15; Engine Action #53; Warp to Castle HQ (16, 1, 0); Dismiss Dialogue Portrait; Warp Town -> Area 17 Map 27 Submap 52 at (3,17); Warp Room -> Submap 17 at (47,255) facing 254 |
| `ev[05]` | `1 (Action / Talk)` | Story Flag 90 (bit 8) SET AND Story Flag 90 (bit 16) CLEAR AND Player within Box [24..24, 2..50] AND Condition Check #50 | Close Dialogue Window; Warp Room -> Submap 40 at (101,1) facing West (Left); Engine Action #5; Open Dialogue Message Window; Exit to World Map (2, 1, 5); Dismiss Emotion Bubble (73); Trigger Character Emotion Effect (28, 0); Engine Action #6; Warp Town -> Area 73 Map 60 Submap 5 at (9,4); Warp Room -> Submap 2 at (30,24) facing 9; Open Dialogue Message Window; Execute Choice Result (73); Trigger Character Emotion Effect (49, 5); Engine Action #5; Open Dialogue Message Window; Exit to World Map (2, 0, 0); Dismiss Emotion Bubble (255); Engine Action #5; Close Dialogue Window; Exit to World Map (2, 0, 0); Dismiss Emotion Bubble (255); Engine Action #5; Place Scenery Structure (4); Warp Town -> Area 2 Map 0 Submap 30 at (255,254); Engine Action #5; Dismiss Dialogue Portrait; Exit to World Map (2, 3, 0); Dismiss Emotion Bubble (255); Engine Action #5; Change Portrait Expression (4); Warp Town -> Area 2 Map 0 Submap 30 at (255,254); Walk obj[73] to (60,5); Close Dialogue Window; Exit to World Map (2, 0, 3); Warp Town -> Area 0 Map 30 Submap 24 at (11,0); Set Story Flag (73, 90); Engine Action #5; Engine Action #9; Exit to World Map (1, 1, 1); Dismiss Emotion Bubble (24); Engine Action #9; Open Dialogue Message Window; Open Dialogue Sub-Window (28); Warp Room -> Submap 4 at (49,2) facing 5; Engine Action #9; Exit to World Map (5, 1, 4); Dismiss Emotion Bubble (255); Engine Action #5; Close Dialogue Window; Warp Room -> Submap 5 at (15,4) facing 6; Warp Room -> Submap 2 at (2,0) facing South (Down); Dismiss Emotion Bubble (255); Walk obj[49] to (4,5); Open Dialogue Message Window; Exit to World Map (2, 2, 0); Dismiss Emotion Bubble (255); Engine Action #5; Place Scenery Structure (4); Warp Town -> Area 1 Map 0 Submap 30 at (255,254); Engine Action #5; Dismiss Dialogue Portrait; Exit to World Map (2, 1, 0); Dismiss Emotion Bubble (255); Engine Action #5; Change Portrait Expression (4); Warp Town -> Area 1 Map 0 Submap 30 at (255,254); Walk obj[24] to (11,0); Close Dialogue Sub-Window (5); Engine Action #9; Exit to World Map (5, 1, 1); Dismiss Emotion Bubble (24); Engine Action #9; Open Dialogue Message Window; Clear Dialogue Sub-Window; Jump to Bytecode Offset (9, 8); Set Combat Battle BGM (120); Close Dialogue Sub-Window (8); Open Dialogue Message Window; Fade In from Black (49); Pan Camera (5, 9, 4); Warp Town -> Area 2 Map 0 Submap 30 at (255,254); Engine Action #5; Close Dialogue Window; Exit to World Map (2, 2, 0); Dismiss Emotion Bubble (255); Engine Action #5; Place Scenery Structure (4); Warp Town -> Area 2 Map 0 Submap 30 at (255,254); Engine Action #5; Animate Door Open; Exit to World Map (2, 2, 0); Dismiss Emotion Bubble (255); Engine Action #5; Show Dialogue Portrait (4, 2, 2); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Dismiss Dialogue Portrait; Exit to World Map (2, 2, 0); Dismiss Emotion Bubble (255); Engine Action #5; Change Portrait Expression (4); Warp Town -> Area 2 Map 0 Submap 30 at (255,254); Walk obj[24] to (9,0); Fade Out to Black (101); Pan Camera (1, 105, 2); Screen Fade Transition (0, 73, 120); Jump to Bytecode Offset (1, 32); Open Dialogue Message Window; Reset Camera Tracking (0); Screen Fade Transition (49, 2, 5); Reset Camera Tracking (4); Exit to World Map (0, 20, 3); Place Scenery Structure (30); Engine Action #5; Screen Fade Transition (4, 4, 0); Branch on Choice (3, 12); Dismiss Emotion Bubble (255); Walk obj[5] to (16,4); Exit to World Map (1, 0, 30); Close Dialogue Sub-Window (9); Open Dialogue Message Window; Display Chapter Text (5); Engine Action #9; Exit to World Map (5, 0, 2); Warp Town -> Area 1 Map 30 Submap 49 at (3,5); Close Dialogue Window; Exit to World Map (4, 0, 0); Dismiss Emotion Bubble (255); Engine Action #5; Animate Door Open; Exit to World Map (4, 1, 7); Warp Town -> Area 0 Map 30 Submap 255 at (254,5); Show Dialogue Portrait (4, 4, 1); Engine Action #6; Dismiss Emotion Bubble (255); Walk obj[24] to (8,0); Display Emotion Bubble (5, 10); Exit to World Map (2, 0, 0); Dismiss Emotion Bubble (24); Screen Fade Transition (0, 30, 5); Reset Camera Tracking (4); Warp Town -> Area 3 Map 1 Submap 30 at (5,10); Exit to World Map (2, 3, 0); Dismiss Emotion Bubble (24); Reset Camera Tracking (0); Warp Room -> Submap 24 at (9,0); Warp Map Transition (49, 2, 5, 0, 4); Warp Town -> Area 2 Map 1 Submap 30 at (255,254); Engine Action #5; Engine Action #9; Exit to World Map (3, 3, 3); Open Dialogue Message Window; Warp to Castle HQ (30, 255, 254); Walk obj[73] to (60,49); Warp Town -> Area 5 Map 9 Submap 4 at (3,1); Warp to Castle HQ (2, 3, 30); Engine Action #5; Show Dialogue Portrait (4, 5, 0); Branch on Choice (30, 255); Walk obj[24] to (8,0); Return to Previous Memory Map (9); Engine Action #90; Dismiss Dialogue Portrait; Set Combat Battle BGM (120); Wait for Audio / Window Sync (2); Jump to Bytecode Offset (9, 9); Engine Action #117; Open Dialogue Message Window; Open Dialogue Message Window; Place Scenery Structure (5); Warp Town -> Area 21 Map 0 Submap 18 at (48,255) |

---



## Location Map: `vj16`

- **Master Map Container**: `vj16.json`
- **Submap Layer Files**: vj16_00.json
- **Collision Grid Files**: vj16_map_00.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 1

### Submap Layer `vj16_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `2` Objects | **Script Count (`evkaz`)**: `5` Scripts

#### Complete Physical Entity Inventory (2 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | Prop / Scenery | **Prop ID 42497** | `42497` | `(20, 19)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[01]` | Prop / Scenery | **Prop ID 42497** | `42497` | `(20, 19)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Prop: Object 42497)**: Environmental world dressing prop placed at tile `(20, 19)`. Solid collision is set to `0`.
- **`obj[01]` (Prop: Object 42497)**: Environmental world dressing prop placed at tile `(20, 19)`. Solid collision is set to `0`.


#### Complete Bytecode Script Catalog (5 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 220 (bit 2) SET AND Story Flag 220 (bit 1) CLEAR | Make obj[2] Hidden (disp = 0); Open Dialogue Message Window; Branch on Choice (63, 3); Open Dialogue Message Window; Warp Room -> Submap 8 at (2,0) facing South (Down); Reset Camera Tracking (47) |
| `ev[01]` | `1 (Action / Talk)` | Story Flag 220 (bit 2) SET AND Story Flag 220 (bit 1) CLEAR | Recruit Character into Active Party (55 [Nina], 0); Branch on Choice (19, 9); Dismiss Emotion Bubble (2); Open Dialogue Message Window; Award Potch Loot (+2,048 Potch); Warp Room -> Submap 3 at (4,5) facing 6; Pan Camera (255, 0, 46); Engine Action #89; Engine Action #9; Warp Town -> Area 1 Map 0 Submap 9 at (1,0); Warp Room -> Submap 47 at (73,60) facing 89; Engine Action #9; Warp Town -> Area 2 Map 73 Submap 120 at (36,2); Jump to Bytecode Offset (4, 66); Set Combat Battle BGM (20); Load Sound Bank into Memory (1, 9); Warp Town -> Area 73 Map 20 Submap 72 at (0,9); Engine Action #89; Engine Action #9; Warp Town -> Area 3 Map 73 Submap 60 at (89,9); Warp Town -> Area 4 Map 73 Submap 30 at (89,9); Warp Town -> Area 5 Map 73 Submap 80 at (46,3); Open Dialogue Message Window; Open Dialogue Message Window; Open Dialogue Message Window; Open Dialogue Message Window; Warp Room -> Submap 47 at (36,1) facing 43; Open Dialogue Message Window; Engine Action #5; Engine Action #61; Warp Room -> Submap 55 at (0,20) facing 65; Engine Action #9; Wait for Audio / Window Sync (3); Close Dialogue Window; Exit to World Map (2, 40, 10); Engine Action #225; Exit to World Map (9, 220, 1); Engine Action #102; Warp Room -> Submap 5 at (9,4) facing Up (North); Launch Tactical War Battle (81); Warp Room -> Submap 0 at (38,46) facing 89; Engine Action #9; Warp Town -> Area 1 Map 0 Submap 9 at (1,0); Warp Room -> Submap 47 at (73,60) facing 89; Engine Action #9; Warp Town -> Area 2 Map 73 Submap 120 at (36,2); Jump to Bytecode Offset (4, 66); Set Combat Battle BGM (20); Load Sound Bank into Memory (1, 9); Warp Town -> Area 73 Map 20 Submap 72 at (0,9); Engine Action #89; Engine Action #9; Warp Town -> Area 3 Map 73 Submap 60 at (89,9); Warp Town -> Area 4 Map 5 Submap 1 at (3,0); Engine Action #5; Branch on Choice (2, 0); Engine Action #5; Branch on Choice (3, 0); Engine Action #5; Branch on Choice (0, 0); Engine Action #5; Branch on Choice (3, 0); Dismiss Emotion Bubble (120); Warp Room -> Submap 0 at (10,73) facing 20; Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 0 Map 5 Submap 0 at (6,41); Warp Town -> Area 8 Map 9 Submap 255 at (8,89); Engine Action #9; Warp Town -> Area 5 Map 73 Submap 80 at (46,3); Open Dialogue Message Window; Open Dialogue Message Window; Open Dialogue Message Window; Open Dialogue Message Window; Warp Room -> Submap 47 at (120,1) facing East (Right); Open Dialogue Message Window; Screen Fade Transition (73, 30, 39); Return Warp to Castle Base (36, 1); Open Shop Menu #5 (Type: 0); Engine Action #61; Warp Room -> Submap 55 at (0,20) facing 65; Engine Action #9; Wait for Audio / Window Sync (3); Close Dialogue Window; Exit to World Map (2, 40, 9); Engine Action #220; Warp Room -> Submap 225 at (4,102) facing West (Left); Place Scenery Structure (5); Engine Action #9; Exit to World Map (2, 36, 81); Engine Action #9; Engine Action #89; Engine Action #9; Warp Town -> Area 5 Map 73 Submap 80 at (46,3); Open Dialogue Message Window; Open Dialogue Message Window; Open Dialogue Message Window; Open Dialogue Message Window; Warp Room -> Submap 47 at (5,1) facing 4; Engine Action #5; Warp to Castle HQ (1, 30, 120); Warp Room -> Submap 1 at (10,36) facing West (Left); Set Combat Battle BGM (30); Set Entity Movement Speed (2, 5); Warp Room -> Submap 5 at (3,1) facing South (Down); Warp Room -> Submap 0 at (4,6) facing 7; Warp to Castle HQ (5, 30, 4); Engine Action #5; Open Dialogue Message Window; Open Shop Menu #255 (Type: 30); Engine Action #5; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (4, 6, 0); Warp to Castle HQ (5, 25, 0); Open Dialogue Message Window; Exit to World Map (5, 0, 43); Dismiss Emotion Bubble (255); Walk obj[69] to (3,11); Exit to World Map (2, 40, 9); Engine Action #220; Warp Room -> Submap 225 at (4,102) facing West (Left); Place Scenery Structure (5); Engine Action #9; Exit to World Map (2, 36, 81); Warp Town -> Area 255 Map 3 Submap 255 at (4,255); Engine Action #5; Engine Action #6; Pan Camera (33, 0, 38); Make obj[89] Hidden (disp = 0); Engine Action #9; Warp Town -> Area 1 Map 0 Submap 9 at (1,0); Warp Room -> Submap 47 at (73,60) facing 89; Engine Action #9; Warp Town -> Area 2 Map 73 Submap 30 at (120,5); Warp Room -> Submap 10 at (73,20) facing 120; Exit to World Map (1, 1, 10); Set Combat Battle BGM (90); Launch Tactical War Battle (2); Jump to Bytecode Offset (4, 66); Set Combat Battle BGM (20); Load Sound Bank into Memory (1, 9); Warp Town -> Area 73 Map 20 Submap 72 at (0,9); Engine Action #89; Engine Action #9; Warp Town -> Area 3 Map 73 Submap 60 at (89,9); Warp Town -> Area 4 Map 5 Submap 3 at (3,0); Engine Action #5; Screen Fade Transition (2, 0, 5); Screen Fade Transition (3, 0, 5); Screen Fade Transition (0, 0, 30); Engine Action #120; Warp to Castle HQ (2, 0, 10); Set Combat Battle BGM (20); Warp to Castle HQ (2, 2, 120); Warp Town -> Area 2 Map 1 Submap 10 at (73,20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 0 Map 5 Submap 0 at (6,41); Warp Town -> Area 10 Map 11 Submap 255 at (10,89); Engine Action #9; Warp Town -> Area 5 Map 73 Submap 80 at (46,3); Open Dialogue Message Window; Open Dialogue Message Window; Open Dialogue Message Window; Open Dialogue Message Window; Warp Room -> Submap 47 at (3,1) facing East (Right); Engine Action #120; Warp Room -> Submap 0 at (10,73) facing 30; Engine Action #39; Return Warp to Castle Base (36, 1); Open Shop Menu #5 (Type: 0); Engine Action #61; Warp Room -> Submap 55 at (0,20) facing 65; Engine Action #9; Wait for Audio / Window Sync (3); Close Dialogue Window; Exit to World Map (2, 40, 9); Engine Action #220; Warp Room -> Submap 225 at (4,102) facing West (Left); Place Scenery Structure (5); Engine Action #9; Exit to World Map (2, 36, 81); Close Dialogue Window; Engine Action #89; Engine Action #9; Warp Town -> Area 5 Map 73 Submap 80 at (46,3); Open Dialogue Message Window; Open Dialogue Message Window; Open Dialogue Message Window; Open Dialogue Message Window; Warp Room -> Submap 3 at (1,3) facing 47; Engine Action #5; Warp Room -> Submap 5 at (3,1) facing 30; Engine Action #120; Warp Room -> Submap 1 at (10,36) facing West (Left); Set Combat Battle BGM (30); Set Entity Movement Speed (6, 5); Warp Town -> Area 4 Map 6 Submap 0 at (50,30); Engine Action #5; Warp to Castle HQ (4, 7, 0); Walk obj[30] to (255,254); Engine Action #5; Exit to World Map (4, 5, 0); Walk obj[30] to (255,254); Engine Action #5; Engine Action #5; Exit to World Map (6, 0, 50); Dismiss Emotion Bubble (255); Engine Action #5; Warp Room -> Submap 5 at (3,1) facing South (Down); Warp Room -> Submap 0 at (4,6) facing 7; Warp to Castle HQ (5, 30, 4); Engine Action #5; Open Dialogue Message Window; Open Shop Menu #255 (Type: 30); Engine Action #5; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (4, 6, 0); Warp to Castle HQ (5, 25, 0); Open Dialogue Message Window; Exit to World Map (5, 0, 43); Dismiss Emotion Bubble (255); Walk obj[69] to (3,11); Exit to World Map (2, 40, 9); Engine Action #220; Warp Room -> Submap 225 at (4,102) facing West (Left); Place Scenery Structure (5); Engine Action #9; Exit to World Map (2, 36, 81) |
| `ev[02]` | `128 (Loop)` | Story Flag 220 (bit 2) SET AND Story Flag 220 (bit 1) CLEAR AND Inventory Holds Item #2 [Mega Medicine] | Dismiss Emotion Bubble (1); Open Dialogue Message Window; Toggle Random Encounters (2) |
| `ev[03]` | `128 (Loop)` | Story Flag 220 (bit 2) SET AND Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) SET AND Player Y within Range [48..60] | Warp Room -> Submap 1 at (9,7) |
| `ev[04]` | `1 (Action / Talk)` | Story Flag 220 (bit 2) SET AND Story Flag 220 (bit 1) SET AND Story Flag 143 (bit 1) SET AND Player within Box [16..24, 2..59] AND Condition Check #60 | Warp Map Transition (2, 0, 20, 14, 255) |

---



## Location Map: `vj18`

- **Master Map Container**: `vj18.json`
- **Submap Layer Files**: vj18_00.json
- **Collision Grid Files**: vj18_map_00.json, vj18_map_01.json, vj18_map_02.json, vj18_map_03.json
- **Sprite Animation Bundles**: vj18_00_obj.json
- **Submap Room Count**: 6

### Submap Layer `vj18_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `3`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `5` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (5 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Player within Box [47..48, 2..57] AND Condition Check #58 | Launch Tactical War Battle (1) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [47..48, 2..57] AND Condition Check #58 AND Inventory Holds Item #1 [Medicine] | Close Dialogue Window; Warp to Castle HQ (2, 120, 37); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [47..49, 2..28] AND Condition Check #29 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 48]; Dismiss Emotion Bubble (255) |
| `ev[03]` | `128 (Loop)` | Player within Box [39..57, 2..27] AND Condition Check #40 | Warp Room -> Submap 0 at (9,16) |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [46..50, 2..61] AND Condition Check #65 | Wait for Audio / Window Sync (3); Close Dialogue Window; Exit to World Map (2, 120, 32); Warp to Castle HQ (0, 78, 28) |

---

### Submap Layer `vj18_01` (Index 1)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `3`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `2` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (2 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [47..49, 2..33] AND Condition Check #34 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 48]; Warp Map Transition (255, 254, 204, 204, 204) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [47..49, 2..72] AND Condition Check #73 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 48]; Recruit Hero #255 into Battle Slot 254 |

---

### Submap Layer `vj18_02` (Index 2)

- **Map Number (`mapno`)**: `2`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `3`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `2` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (2 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [47..49, 2..73] AND Condition Check #74 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 48]; Full Rest & Healing (Restore HP/MP) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [47..49, 2..28] AND Condition Check #29 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 3, MsgID: 48]; Dismiss Emotion Bubble (255) |

---

### Submap Layer `vj18_03` (Index 3)

- **Map Number (`mapno`)**: `3`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `3`)
- **Entity Count (`okaz`)**: `2` Objects | **Script Count (`evkaz`)**: `6` Scripts

#### Complete Physical Entity Inventory (2 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 23)** | `0` | `(67, 29)` | `0x0` | Frame 23 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 24)** | `0` | `(67, 29)` | `0x0` | Frame 24 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(67, 29)` with state parameter `23`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(67, 29)` with state parameter `24`.


#### Complete Bytecode Script Catalog (6 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [47..49, 2..33] AND Condition Check #34 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 48]; Fade Out to Black (255) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [31..33, 2..72] AND Condition Check #73 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 4, MsgID: 32]; Recruit Hero #255 into Battle Slot 254 |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [63..65, 2..72] AND Condition Check #73 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 4, MsgID: 64]; Recruit Hero #255 into Battle Slot 254 |
| `ev[03]` | `2 (Map Init)` | Story Flag 224 (bit 1) CLEAR | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[04]` | `2 (Map Init)` | Story Flag 224 (bit 1) SET | Open Dialogue Message Window; Engine Action #9 |
| `ev[05]` | `1 (Action / Talk)` | Story Flag 224 (bit 1) CLEAR AND Target Inspected is obj[8] | Jump to Bytecode Offset (4, 7); Make obj[0] Hidden (disp = 0); Engine Action #9; Warp Room -> Submap 9 at (224,1) facing 47 |

---

### Submap Layer `vj18_04` (Index 4)

- **Map Number (`mapno`)**: `4`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `3`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `3` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (3 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [31..33, 2..73] AND Condition Check #74 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 3, MsgID: 32]; Full Rest & Healing (Restore HP/MP) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [63..65, 2..73] AND Condition Check #74 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 3, MsgID: 64]; Full Rest & Healing (Restore HP/MP) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [47..49, 2..72] AND Condition Check #73 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 5, MsgID: 48]; Recruit Hero #255 into Battle Slot 254 |

---

### Submap Layer `vj18_05` (Index 5)

- **Map Number (`mapno`)**: `5`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `3`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `6` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (6 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [47..49, 2..73] AND Condition Check #74 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 4, MsgID: 48]; Full Rest & Healing (Restore HP/MP) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [47..49, 2..28] AND Condition Check #29 AND Story Flag 221 (bit 1) SET AND Story Flag 1 (mask 255) SET | Warp Map Transition (3, 0, 48, 30, 255) |
| `ev[02]` | `128 (Loop)` | Player within Box [43..59, 2..26] AND Condition Check #48 AND Story Flag 221 (bit 1) SET | Warp Room -> Submap 0 at (9,19) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [43..59, 2..26] AND Condition Check #48 AND Story Flag 221 (bit 1) CLEAR | Launch Tactical War Battle (1); Set Render Priority (pri) (0, 48); Start Boss Battle #9 (BGM: 3); Open Dialogue Message Window; Warp Room -> Submap 10 at (54,0) facing West (Left); Engine Action #83; Warp Room -> Submap 36 at (2,54) facing South (Down); Warp Town -> Area 9 Map 221 Submap 1 at (55,0); Turn obj[29] facing 9; Warp Map Transition (3, 0, 48, 30, 255) |
| `ev[04]` | `128 (Loop)` | Story Flag 221 (bit 1) CLEAR AND Inventory Holds Item #1 [Medicine] | Warp Room -> Submap 0 at (15,66); Toggle Random Encounters (1) |
| `ev[05]` | `128 (Loop)` | Story Flag 221 (bit 1) CLEAR AND Inventory Holds Item #2 [Mega Medicine] | Warp Room -> Submap 0 at (9,19); Toggle Random Encounters (2) |

---



## Location Map: `vj19`

- **Master Map Container**: `vj19.json`
- **Submap Layer Files**: vj19_01.json, vj19_05.json, vj19_07.json
- **Collision Grid Files**: None
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 1

### Submap Layer `vj19_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `64` Objects | **Script Count (`evkaz`)**: `5` Scripts

#### Complete Physical Entity Inventory (64 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Highland Officer** | `81` | `(120, 47)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | Prop / Scenery | **Prop ID 33617** | `33617` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 180 |
| `obj[02]` | Prop / Scenery | **Prop ID 33617** | `33617` | `(120, 51)` | `0x0` | West (Left) | Visible (1) | Passable (0) | 4 | 255 | 180 |
| `obj[03]` | NPC / Actor | **Raura (Scroll Keeper)** | `148` | `(124, 45)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[04]` | NPC / Actor | **Actor ID 144** | `144` | `(126, 54)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[05]` | NPC / Actor | **Actor ID 143** | `143` | `(114, 54)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[06]` | NPC / Actor | **Actor ID 65232** | `65232` | `(125, 50)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[07]` | NPC / Actor | **Actor ID 65232** | `65232` | `(115, 50)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[08]` | NPC / Actor | **Actor ID 65104** | `65104` | `(108, 70)` | `0x0` | West (Left) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Prop / Scenery | **Prop ID 64980** | `64980` | `(108, 70)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Prop / Scenery | **Prop ID 64980** | `64980` | `(111, 70)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | NPC / Actor | **Actor ID 65104** | `65104` | `(114, 70)` | `0x0` | West (Left) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | Prop / Scenery | **Prop ID 64980** | `64980` | `(114, 70)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | NPC / Actor | **Actor ID 65104** | `65104` | `(117, 70)` | `0x0` | West (Left) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | Prop / Scenery | **Prop ID 64980** | `64980` | `(117, 70)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[15]` | Prop / Scenery | **Prop ID 64980** | `64980` | `(120, 70)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[16]` | NPC / Actor | **Actor ID 65104** | `65104` | `(123, 70)` | `0x0` | West (Left) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[17]` | Prop / Scenery | **Prop ID 64980** | `64980` | `(123, 70)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[18]` | NPC / Actor | **Actor ID 65104** | `65104` | `(126, 70)` | `0x0` | West (Left) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[19]` | Prop / Scenery | **Prop ID 64980** | `64980` | `(126, 70)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[20]` | Prop / Scenery | **Prop ID 64980** | `64980` | `(129, 70)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[21]` | NPC / Actor | **Actor ID 65104** | `65104` | `(132, 70)` | `0x0` | West (Left) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[22]` | Prop / Scenery | **Prop ID 64980** | `64980` | `(132, 70)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[23]` | Prop / Scenery | **Prop ID 64980** | `64980` | `(108, 74)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[24]` | Prop / Scenery | **Prop ID 64980** | `64980` | `(111, 74)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[25]` | NPC / Actor | **Actor ID 65104** | `65104` | `(114, 74)` | `0x0` | West (Left) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[26]` | Prop / Scenery | **Prop ID 64980** | `64980` | `(114, 74)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[27]` | NPC / Actor | **Actor ID 65104** | `65104` | `(117, 74)` | `0x0` | West (Left) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[28]` | Prop / Scenery | **Prop ID 64980** | `64980` | `(117, 74)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[29]` | NPC / Actor | **Actor ID 65104** | `65104` | `(120, 74)` | `0x0` | West (Left) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[30]` | Prop / Scenery | **Prop ID 64980** | `64980` | `(120, 74)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[31]` | Prop / Scenery | **Prop ID 64980** | `64980` | `(123, 74)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[32]` | NPC / Actor | **Actor ID 65104** | `65104` | `(126, 74)` | `0x0` | West (Left) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[33]` | Prop / Scenery | **Prop ID 64980** | `64980` | `(126, 74)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[34]` | Prop / Scenery | **Prop ID 64980** | `64980` | `(129, 74)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[35]` | NPC / Actor | **Actor ID 65104** | `65104` | `(132, 74)` | `0x0` | West (Left) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[36]` | Prop / Scenery | **Prop ID 64980** | `64980` | `(132, 74)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[37]` | NPC / Actor | **Actor ID 65104** | `65104` | `(108, 78)` | `0x0` | West (Left) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[38]` | Prop / Scenery | **Prop ID 64980** | `64980` | `(108, 78)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[39]` | Prop / Scenery | **Prop ID 64980** | `64980` | `(111, 78)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[40]` | Prop / Scenery | **Prop ID 64980** | `64980` | `(114, 78)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[41]` | Prop / Scenery | **Prop ID 64980** | `64980` | `(117, 78)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[42]` | NPC / Actor | **Actor ID 65104** | `65104` | `(120, 78)` | `0x0` | West (Left) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[43]` | Prop / Scenery | **Prop ID 64980** | `64980` | `(120, 78)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[44]` | NPC / Actor | **Actor ID 65104** | `65104` | `(123, 78)` | `0x0` | West (Left) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[45]` | Prop / Scenery | **Prop ID 64980** | `64980` | `(123, 78)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[46]` | Prop / Scenery | **Prop ID 64980** | `64980` | `(126, 78)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[47]` | NPC / Actor | **Actor ID 65104** | `65104` | `(129, 78)` | `0x0` | West (Left) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[48]` | Prop / Scenery | **Prop ID 64980** | `64980` | `(129, 78)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[49]` | Prop / Scenery | **Prop ID 64980** | `64980` | `(132, 78)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[50]` | NPC / Actor | **Actor ID 65104** | `65104` | `(108, 82)` | `0x0` | West (Left) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[51]` | Prop / Scenery | **Prop ID 64980** | `64980` | `(108, 82)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[52]` | NPC / Actor | **Actor ID 65104** | `65104` | `(111, 82)` | `0x0` | West (Left) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[53]` | Prop / Scenery | **Prop ID 64980** | `64980` | `(111, 82)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[54]` | Prop / Scenery | **Prop ID 64980** | `64980` | `(114, 82)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[55]` | Prop / Scenery | **Prop ID 64980** | `64980` | `(117, 82)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[56]` | NPC / Actor | **Actor ID 65104** | `65104` | `(120, 82)` | `0x0` | West (Left) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[57]` | Prop / Scenery | **Prop ID 64980** | `64980` | `(120, 82)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[58]` | Prop / Scenery | **Prop ID 64980** | `64980` | `(123, 82)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[59]` | NPC / Actor | **Actor ID 65104** | `65104` | `(126, 82)` | `0x0` | West (Left) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[60]` | Prop / Scenery | **Prop ID 64980** | `64980` | `(126, 82)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[61]` | NPC / Actor | **Actor ID 65104** | `65104` | `(129, 82)` | `0x0` | West (Left) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[62]` | Prop / Scenery | **Prop ID 64980** | `64980` | `(129, 82)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[63]` | Prop / Scenery | **Prop ID 64980** | `64980` | `(132, 82)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Highland Officer)**: Positioned at tile `(120, 47)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Prop: Object 33617)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[02]` (Prop: Object 33617)**: Environmental world dressing prop placed at tile `(120, 51)`. Solid collision is set to `128`.
- **`obj[03]` (Raura (Scroll Keeper))**: Positioned at tile `(124, 45)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Object 144)**: Positioned at tile `(126, 54)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Object 143)**: Positioned at tile `(114, 54)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[06]` (Object 65232)**: Positioned at tile `(125, 50)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[07]` (Object 65232)**: Positioned at tile `(115, 50)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[08]` (Object 65104)**: Positioned at tile `(108, 70)`, facing West (Left). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[09]` (Prop: Object 64980)**: Environmental world dressing prop placed at tile `(108, 70)`. Solid collision is set to `0`.
- **`obj[10]` (Prop: Object 64980)**: Environmental world dressing prop placed at tile `(111, 70)`. Solid collision is set to `0`.
- **`obj[11]` (Object 65104)**: Positioned at tile `(114, 70)`, facing West (Left). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[12]` (Prop: Object 64980)**: Environmental world dressing prop placed at tile `(114, 70)`. Solid collision is set to `0`.
- **`obj[13]` (Object 65104)**: Positioned at tile `(117, 70)`, facing West (Left). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[14]` (Prop: Object 64980)**: Environmental world dressing prop placed at tile `(117, 70)`. Solid collision is set to `0`.
- **`obj[15]` (Prop: Object 64980)**: Environmental world dressing prop placed at tile `(120, 70)`. Solid collision is set to `0`.
- **`obj[16]` (Object 65104)**: Positioned at tile `(123, 70)`, facing West (Left). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[17]` (Prop: Object 64980)**: Environmental world dressing prop placed at tile `(123, 70)`. Solid collision is set to `0`.
- **`obj[18]` (Object 65104)**: Positioned at tile `(126, 70)`, facing West (Left). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[19]` (Prop: Object 64980)**: Environmental world dressing prop placed at tile `(126, 70)`. Solid collision is set to `0`.
- **`obj[20]` (Prop: Object 64980)**: Environmental world dressing prop placed at tile `(129, 70)`. Solid collision is set to `0`.
- **`obj[21]` (Object 65104)**: Positioned at tile `(132, 70)`, facing West (Left). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[22]` (Prop: Object 64980)**: Environmental world dressing prop placed at tile `(132, 70)`. Solid collision is set to `0`.
- **`obj[23]` (Prop: Object 64980)**: Environmental world dressing prop placed at tile `(108, 74)`. Solid collision is set to `0`.
- **`obj[24]` (Prop: Object 64980)**: Environmental world dressing prop placed at tile `(111, 74)`. Solid collision is set to `0`.
- **`obj[25]` (Object 65104)**: Positioned at tile `(114, 74)`, facing West (Left). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[26]` (Prop: Object 64980)**: Environmental world dressing prop placed at tile `(114, 74)`. Solid collision is set to `0`.
- **`obj[27]` (Object 65104)**: Positioned at tile `(117, 74)`, facing West (Left). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[28]` (Prop: Object 64980)**: Environmental world dressing prop placed at tile `(117, 74)`. Solid collision is set to `0`.
- **`obj[29]` (Object 65104)**: Positioned at tile `(120, 74)`, facing West (Left). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[30]` (Prop: Object 64980)**: Environmental world dressing prop placed at tile `(120, 74)`. Solid collision is set to `0`.
- **`obj[31]` (Prop: Object 64980)**: Environmental world dressing prop placed at tile `(123, 74)`. Solid collision is set to `0`.
- **`obj[32]` (Object 65104)**: Positioned at tile `(126, 74)`, facing West (Left). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[33]` (Prop: Object 64980)**: Environmental world dressing prop placed at tile `(126, 74)`. Solid collision is set to `0`.
- **`obj[34]` (Prop: Object 64980)**: Environmental world dressing prop placed at tile `(129, 74)`. Solid collision is set to `0`.
- **`obj[35]` (Object 65104)**: Positioned at tile `(132, 74)`, facing West (Left). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[36]` (Prop: Object 64980)**: Environmental world dressing prop placed at tile `(132, 74)`. Solid collision is set to `0`.
- **`obj[37]` (Object 65104)**: Positioned at tile `(108, 78)`, facing West (Left). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[38]` (Prop: Object 64980)**: Environmental world dressing prop placed at tile `(108, 78)`. Solid collision is set to `0`.
- **`obj[39]` (Prop: Object 64980)**: Environmental world dressing prop placed at tile `(111, 78)`. Solid collision is set to `0`.
- **`obj[40]` (Prop: Object 64980)**: Environmental world dressing prop placed at tile `(114, 78)`. Solid collision is set to `0`.
- **`obj[41]` (Prop: Object 64980)**: Environmental world dressing prop placed at tile `(117, 78)`. Solid collision is set to `0`.
- **`obj[42]` (Object 65104)**: Positioned at tile `(120, 78)`, facing West (Left). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[43]` (Prop: Object 64980)**: Environmental world dressing prop placed at tile `(120, 78)`. Solid collision is set to `0`.
- **`obj[44]` (Object 65104)**: Positioned at tile `(123, 78)`, facing West (Left). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[45]` (Prop: Object 64980)**: Environmental world dressing prop placed at tile `(123, 78)`. Solid collision is set to `0`.
- **`obj[46]` (Prop: Object 64980)**: Environmental world dressing prop placed at tile `(126, 78)`. Solid collision is set to `0`.
- **`obj[47]` (Object 65104)**: Positioned at tile `(129, 78)`, facing West (Left). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[48]` (Prop: Object 64980)**: Environmental world dressing prop placed at tile `(129, 78)`. Solid collision is set to `0`.
- **`obj[49]` (Prop: Object 64980)**: Environmental world dressing prop placed at tile `(132, 78)`. Solid collision is set to `0`.
- **`obj[50]` (Object 65104)**: Positioned at tile `(108, 82)`, facing West (Left). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[51]` (Prop: Object 64980)**: Environmental world dressing prop placed at tile `(108, 82)`. Solid collision is set to `0`.
- **`obj[52]` (Object 65104)**: Positioned at tile `(111, 82)`, facing West (Left). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[53]` (Prop: Object 64980)**: Environmental world dressing prop placed at tile `(111, 82)`. Solid collision is set to `0`.
- **`obj[54]` (Prop: Object 64980)**: Environmental world dressing prop placed at tile `(114, 82)`. Solid collision is set to `0`.
- **`obj[55]` (Prop: Object 64980)**: Environmental world dressing prop placed at tile `(117, 82)`. Solid collision is set to `0`.
- **`obj[56]` (Object 65104)**: Positioned at tile `(120, 82)`, facing West (Left). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[57]` (Prop: Object 64980)**: Environmental world dressing prop placed at tile `(120, 82)`. Solid collision is set to `0`.
- **`obj[58]` (Prop: Object 64980)**: Environmental world dressing prop placed at tile `(123, 82)`. Solid collision is set to `0`.
- **`obj[59]` (Object 65104)**: Positioned at tile `(126, 82)`, facing West (Left). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[60]` (Prop: Object 64980)**: Environmental world dressing prop placed at tile `(126, 82)`. Solid collision is set to `0`.
- **`obj[61]` (Object 65104)**: Positioned at tile `(129, 82)`, facing West (Left). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[62]` (Prop: Object 64980)**: Environmental world dressing prop placed at tile `(129, 82)`. Solid collision is set to `0`.
- **`obj[63]` (Prop: Object 64980)**: Environmental world dressing prop placed at tile `(132, 82)`. Solid collision is set to `0`.


#### Complete Bytecode Script Catalog (5 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 132 (bit 4) SET AND Story Flag 95 (bit 64) CLEAR | Make obj[2] Hidden (disp = 0); Open Dialogue Message Window; Engine Action #120; Engine Action #78; Warp Room -> Submap 37 at (254,47) facing 255 |
| `ev[01]` | `1 (Action / Talk)` | Story Flag 132 (bit 4) SET AND Story Flag 95 (bit 64) CLEAR | Display Chapter Text (1); Open Dialogue Sub-Window (3); Engine Action #5; Place Scenery Structure (4); Exit to World Map (0, 1, 30); Close Dialogue Sub-Window (13); Open Dialogue Message Window; Open Dialogue Message Window; Display Chapter Text (0); Screen Fade Transition (4, 36, 1); Engine Action #54; Open Dialogue Message Window; Warp Room -> Submap 1 at (10,4) facing 5; Display Dialogue Box [Bank: 4, MsgID: 4]; Open Dialogue Message Window; Warp Room -> Submap 24 at (12,0) facing West (Left); Display Chapter Text (0); Screen Fade Transition (4, 36, 1); Engine Action #54; Open Dialogue Message Window; Warp Room -> Submap 1 at (10,4) facing 73; Trigger Character Emotion Effect (49, 2); Engine Action #5; Show Dialogue Portrait (4, 3, 3); Exit to World Map (1, 0, 30); Engine Action #5; Animate Door Open; Exit to World Map (3, 2, 4); Warp Room -> Submap 30 at (255,254) facing 50; Close Dialogue Sub-Window (14); Open Dialogue Message Window; Warp Town -> Area 49 Map 2 Submap 5 at (15,3); Open Dialogue Message Window; Pan Camera (3, 30, 255); Engine Action #5; Animate Door Open; Warp Town -> Area 0 Map 7 Submap 3 at (30,255); Walk obj[5] to (8,4); Warp to Castle HQ (0, 4, 30); Warp to Castle HQ (15, 0, 3); Animate Door Open; Open Dialogue Message Window; Close Dialogue Sub-Window (8); Open Dialogue Message Window; Warp to Castle HQ (46, 89, 9); Warp Town -> Area 2 Map 106 Submap 8 at (9,0); Engine Action #9; Warp Room -> Submap 1 at (10,36) facing Up (North); Teleport obj[73] to (200,89); Engine Action #9; Warp Town -> Area 3 Map 5 Submap 13 at (3,2); Open Dialogue Message Window; Warp Room -> Submap 24 at (13,0) facing 4; Engine Action #5; Display Dialogue Box [Bank: 2, MsgID: 2]; Open Dialogue Message Window; Warp Room -> Submap 36 at (4,24) facing 12; Open Dialogue Message Window; Engine Action #5; Display Chapter Text (0); Screen Fade Transition (4, 36, 1); Engine Action #54; Open Dialogue Message Window; Warp Room -> Submap 1 at (20,4) facing 73; Branch on Choice (46, 1); Engine Action #9; Open Dialogue Message Window; Reset Camera Tracking (47); Open Shop Menu #3 (Type: 8); Engine Action #5; Reset Camera Tracking (7); Warp Town -> Area 5 Map 10 Submap 2 at (0,5); Engine Action #5; Warp Room -> Submap 5 at (10,1) facing East (Right); Dismiss Emotion Bubble (24); Reset Camera Tracking (0); Engine Action #6; Close Dialogue Sub-Window (11); Open Dialogue Message Window; Pan Camera (24, 8, 0); Reset Camera Tracking (5); Reset Camera Tracking (1); Warp Room -> Submap 73 at (30,46) facing 89; Engine Action #9; Warp Town -> Area 5 Map 106 Submap 8 at (9,0); Engine Action #9; Warp Room -> Submap 47 at (73,60) facing 89; Engine Action #9; Warp Town -> Area 6 Map 5 Submap 11 at (4,6); Warp Town -> Area 2 Map 30 Submap 9 at (95,64); Wait for Audio / Window Sync (3); Jump to Bytecode Offset (9, 7); Close Dialogue Window; Warp Town -> Area 2 Map 120 Submap 9 at (144,4); Jump to Bytecode Offset (9, 14); Engine Action #117; Warp Room -> Submap 111 at (41,5) facing 6; Pan Camera (8, 9, 10); Engine Action #6; Pan Camera (13, 5, 10); Engine Action #6; Warp to Castle HQ (52, 52, 255); Reset Camera Tracking (13); Engine Action #5; Screen Fade Transition (12, 0, 50); Walk obj[255] to (9,13); Engine Action #5; Screen Fade Transition (12, 7, 56); Full Rest & Healing (Restore HP/MP); Screen Fade Transition (13, 5, 10); Show Dialogue Portrait (0, 40, 20) |
| `ev[02]` | `128 (Loop)` | Story Flag 132 (bit 4) SET AND Story Flag 95 (bit 64) CLEAR AND Inventory Holds Item #1 [Medicine] | Make obj[1] Hidden (disp = 0); Dismiss Dialogue Portrait; Warp Room -> Submap 1 at (21,1) facing 24; Warp Room -> Submap 1 at (29,1) facing 33; Warp Room -> Submap 1 at (37,1) facing 40; Warp Room -> Submap 1 at (45,1) facing 50; Warp Room -> Submap 1 at (55,1) facing 58; Warp Room -> Submap 1 at (64,1) facing 67; Warp Room -> Submap 0 at (17,0) facing 20; Open Dialogue Message Window; Set Story Flag (0, 25); Open Dialogue Message Window; Fade Out to Black (0); Dismiss Emotion Bubble (0); Return Warp to Castle Base (0, 36); Open Dialogue Message Window; Open Save Crystal Menu (MSaveInit); Open Dialogue Message Window; Award Potch Loot (+44 Potch); Open Dialogue Message Window; Make obj[0] Hidden (disp = 0); Engine Action #51; Open Dialogue Message Window; Engine Action #53; Open Dialogue Message Window; Set Animation Pose (0, 59); Open Dialogue Message Window; Engine Action #61; Open Dialogue Message Window; Play Sound Effect (SE) (0); Play CD / Ambient BGM Track (0); Recruit Genshu into Battle Slot 46; Engine Action #89; Change Portrait Expression (2); Warp Room -> Submap 18 at (2,2) facing 89; Branch on Choice (2, 2); Engine Action #89; Set Story Flag (2, 5); Engine Action #89; Open Dialogue Sub-Window (2); Warp Town -> Area 89 Map 25 Submap 2 at (5,89); Fade Out to Black (2); Exit to World Map (89, 28, 2); Warp Town -> Area 89 Map 30 Submap 2 at (5,89); Warp Room -> Submap 2 at (2,89); Warp Map Transition (2, 5, 89, 34, 2); Warp Town -> Area 89 Map 36 Submap 2 at (5,89); Open Save Crystal Menu (MSaveInit); Warp Town -> Area 4 Map 89 Submap 39 at (2,1); Engine Action #89; Award Potch Loot (+517 Potch); Engine Action #89; Remove Item from Inventory (2, 2); Engine Action #89; Engine Action #44; Warp Town -> Area 2 Map 89 Submap 46 at (2,4); Engine Action #89; Teleport obj[2] to (1,89); Turn obj[2] facing 5; Engine Action #89; Set Entity Movement Speed (2, 2); Engine Action #89; Engine Action #51; Warp Town -> Area 2 Map 89 Submap 53 at (2,2); Engine Action #89; Engine Action #54; Warp Town -> Area 1 Map 89 Submap 56 at (2,5); Engine Action #89; Recruit Character into Active Party (2 [Flik], 2); Engine Action #89; Set obj[2] Collision to Passable; Engine Action #89; Engine Action #61; Warp Town -> Area 4 Map 89 Submap 62 at (2,5); Engine Action #89; Engine Action #63; Warp Town -> Area 4 Map 89 Submap 65 at (2,2); Engine Action #89; Engine Action #66; Warp Town -> Area 2 Map 89 Submap 68 at (2,1); Engine Action #89; Recruit Jowy Atreides into Battle Slot 2; Engine Action #89; Remove Character from Active Party (2); Engine Action #5; Teleport obj[101] to (0,177); Set Combat Battle BGM (120); Make obj[89] Hidden (disp = 0); Change Portrait Expression (2); Open Dialogue Message Window; Engine Action #89; Display Speaker Name Box (2); Open Dialogue Message Window; Engine Action #89; Branch on Choice (2, 0); Engine Action #89; Set Story Flag (2, 0); Engine Action #89; Open Dialogue Sub-Window (2); Open Dialogue Message Window; Engine Action #89; Clear Dialogue Sub-Window; Warp Town -> Area 0 Map 89 Submap 27 at (2,0); Engine Action #89; Display Chapter Text (2); Open Dialogue Message Window; Engine Action #89; Dismiss Emotion Bubble (2); Open Dialogue Message Window; Engine Action #89; Warp Room -> Submap 2 at (0,89); Warp Map Transition (2, 0, 89, 34, 2); Open Dialogue Message Window; Engine Action #89; Launch Tactical War Battle (2); Open Dialogue Message Window; Engine Action #89; Open Save Crystal Menu (MSaveInit); Warp Town -> Area 0 Map 89 Submap 39 at (2,0); Engine Action #89; Award Potch Loot (+512 Potch); Engine Action #89; Remove Item from Inventory (2, 0); Engine Action #89; Engine Action #44; Warp Town -> Area 0 Map 89 Submap 46 at (2,0); Engine Action #89; Teleport obj[2] to (0,89); Turn obj[2] facing South (Down); Engine Action #89; Set Entity Movement Speed (2, 0); Engine Action #89; Engine Action #51; Warp Town -> Area 0 Map 89 Submap 53 at (2,0); Engine Action #89; Engine Action #54; Warp Town -> Area 0 Map 89 Submap 56 at (2,0); Engine Action #89; Recruit Character into Active Party (2 [Flik], 0); Engine Action #89; Set obj[2] Collision to Passable; Engine Action #89; Engine Action #61; Warp Town -> Area 0 Map 89 Submap 62 at (2,0); Engine Action #89; Engine Action #63; Warp Town -> Area 0 Map 89 Submap 65 at (2,0); Engine Action #89; Engine Action #66; Warp Town -> Area 0 Map 89 Submap 68 at (2,0); Engine Action #89; Recruit Jowy Atreides into Battle Slot 0; Engine Action #89; Remove Character from Active Party (2); Open Dialogue Message Window; Teleport obj[46] to (0,16); Open Dialogue Message Window; Display Choice Selection (0, 21); Open Dialogue Message Window; Close Dialogue Sub-Window (0); Fade In from Black (0); Display Emotion Bubble (0, 33); Open Dialogue Message Window; Start Boss Battle #0 (BGM: 37); Open Dialogue Message Window; Engine Action #40; Open Dialogue Message Window; Open Shop Menu #45 (Type: 0); Open Dialogue Message Window; Walk obj[0] to (52,0); Set Render Priority (pri) (0, 58); Open Dialogue Message Window; Trigger Character Emotion Effect (0, 64); Open Dialogue Message Window; Open Shop Interface #0; Wait for Audio / Window Sync (1); Change Portrait Expression (1); Branch on Choice (1, 22); Warp Room -> Submap 1 at (27,1) facing 30; Warp Room -> Submap 1 at (36,1) facing 38; Warp Room -> Submap 1 at (44,1) facing 46; Warp Room -> Submap 1 at (53,1) facing 56; Warp Room -> Submap 1 at (61,1) facing 65; Warp Room -> Submap 1 at (70,47) facing 37; Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[03]` | `128 (Loop)` | Story Flag 132 (bit 4) SET AND Story Flag 95 (bit 64) CLEAR AND Inventory Holds Item #2 [Mega Medicine] | Set Combat Battle BGM (170); Jump to Bytecode Offset (0, 176); Toggle Random Encounters (2) |
| `ev[04]` | `128 (Loop)` | Story Flag 132 (bit 4) SET AND Story Flag 95 (bit 64) CLEAR AND Inventory Holds Item #4 [Throat Drops] | Set Combat Battle BGM (60); Engine Action #89; Engine Action #9; Warp Town -> Area 4 Map 73 Submap 60 at (46,89); Engine Action #9; Warp Town -> Area 0 Map 0 Submap 10 at (47,37); Exit to World Map (255, 254, 204) |

---



## Location Map: `vj20`

- **Master Map Container**: `vj20.json`
- **Submap Layer Files**: vj20_00.json
- **Collision Grid Files**: None
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 5

### Submap Layer `vj20_00` (Index 0)

- **Map Number (`mapno`)**: `6`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `3`)
- **Entity Count (`okaz`)**: `2` Objects | **Script Count (`evkaz`)**: `8` Scripts

#### Complete Physical Entity Inventory (2 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 23)** | `0` | `(47, 65)` | `0x0` | Frame 23 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 24)** | `0` | `(47, 65)` | `0x0` | Frame 24 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(47, 65)` with state parameter `23`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(47, 65)` with state parameter `24`.


#### Complete Bytecode Script Catalog (8 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `128 (Loop)` | Player within Box [43..53, 2..27] AND Condition Check #42 | Warp Room -> Submap 1 at (9,17) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [47..49, 2..33] AND Condition Check #34 AND Story Flag 0 (mask 255) SET | Warp Map Transition (2, 5, 48, 32, 255) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [23..25, 2..24] AND Condition Check #25 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 24]; Fade In from Black (255) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [27..29, 2..72] AND Condition Check #73 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 28]; Recruit Hero #255 into Battle Slot 254 |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [67..69, 2..72] AND Condition Check #73 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 68]; Recruit Hero #255 into Battle Slot 254 |
| `ev[05]` | `2 (Map Init)` | Story Flag 224 (bit 2) CLEAR | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[06]` | `2 (Map Init)` | Story Flag 224 (bit 2) SET | Open Dialogue Message Window; Engine Action #9 |
| `ev[07]` | `1 (Action / Talk)` | Story Flag 224 (bit 2) CLEAR AND Target Inspected is obj[8] | Jump to Bytecode Offset (4, 7); Make obj[0] Hidden (disp = 0); Engine Action #9; Warp Room -> Submap 9 at (224,2) facing 47 |

---

### Submap Layer `vj20_01` (Index 1)

- **Map Number (`mapno`)**: `7`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `3`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `4` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (4 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [23..25, 2..29] AND Condition Check #30 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 24]; Display Chapter Text (255) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [27..29, 2..73] AND Condition Check #74 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 28]; Full Rest & Healing (Restore HP/MP) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [67..69, 2..73] AND Condition Check #74 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 68]; Full Rest & Healing (Restore HP/MP) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [27..29, 2..44] AND Condition Check #45 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 28]; Remove Item from Inventory (255, 254) |

---

### Submap Layer `vj20_02` (Index 2)

- **Map Number (`mapno`)**: `8`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `3`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `3` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (3 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [27..29, 2..45] AND Condition Check #46 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 28]; Turn obj[255] facing 254 |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [43..45, 2..56] AND Condition Check #57 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 3, MsgID: 44]; Engine Action #54 |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [51..53, 2..56] AND Condition Check #57 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 3, MsgID: 52]; Engine Action #54 |

---

### Submap Layer `vj20_03` (Index 3)

- **Map Number (`mapno`)**: `9`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `3`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `3` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (3 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [43..45, 2..57] AND Condition Check #58 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 44]; Trigger Character Emotion Effect (255, 254) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [51..53, 2..57] AND Condition Check #58 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 52]; Trigger Character Emotion Effect (255, 254) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [71..73, 2..28] AND Condition Check #29 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 4, MsgID: 72]; Dismiss Emotion Bubble (255) |

---

### Submap Layer `vj20_04` (Index 4)

- **Map Number (`mapno`)**: `12`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `3`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `6` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (6 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [71..73, 2..33] AND Condition Check #34 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 3, MsgID: 72]; Warp Map Transition (255, 254, 204, 204, 204) |
| `ev[01]` | `128 (Loop)` | Player within Box [43..53, 2..31] AND Condition Check #54 AND Story Flag 221 (bit 2) SET | Warp Room -> Submap 1 at (9,20) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [47..49, 2..28] AND Condition Check #29 AND Story Flag 221 (bit 2) SET AND Story Flag 1 (mask 255) SET | Warp Map Transition (2, 0, 48, 30, 255) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [43..53, 2..31] AND Condition Check #54 AND Story Flag 221 (bit 2) CLEAR | Launch Tactical War Battle (1); Set Render Priority (pri) (0, 48); Start Boss Battle #9 (BGM: 3); Open Dialogue Message Window; Warp Room -> Submap 10 at (54,0) facing West (Left); Engine Action #83; Warp Room -> Submap 36 at (2,54) facing South (Down); Warp Town -> Area 9 Map 221 Submap 2 at (55,0); Turn obj[29] facing 9; Warp Map Transition (2, 0, 48, 30, 255) |
| `ev[04]` | `128 (Loop)` | Story Flag 221 (bit 2) CLEAR AND Inventory Holds Item #1 [Medicine] | Warp Room -> Submap 1 at (15,67); Toggle Random Encounters (1) |
| `ev[05]` | `128 (Loop)` | Story Flag 221 (bit 2) CLEAR AND Inventory Holds Item #2 [Mega Medicine] | Warp Room -> Submap 1 at (9,20); Toggle Random Encounters (2) |

---



## Location Map: `vj21`

- **Master Map Container**: `vj21.json`
- **Submap Layer Files**: vj21_00.json
- **Collision Grid Files**: None
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 5

### Submap Layer `vj21_00` (Index 0)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `3`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `3` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (3 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `128 (Loop)` | Player within Box [27..53, 2..26] AND Condition Check #38 | Warp Room -> Submap 0 at (9,19) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [47..49, 2..33] AND Condition Check #34 AND Story Flag 0 (mask 255) SET | Warp Map Transition (3, 4, 48, 32, 255) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [47..49, 2..72] AND Condition Check #73 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 48]; Recruit Hero #255 into Battle Slot 254 |

---

### Submap Layer `vj21_01` (Index 1)

- **Map Number (`mapno`)**: `2`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `3`)
- **Entity Count (`okaz`)**: `2` Objects | **Script Count (`evkaz`)**: `5` Scripts

#### Complete Physical Entity Inventory (2 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 23)** | `0` | `(63, 33)` | `0x0` | Frame 23 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 24)** | `0` | `(63, 33)` | `0x0` | Frame 24 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(63, 33)` with state parameter `23`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(63, 33)` with state parameter `24`.


#### Complete Bytecode Script Catalog (5 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [47..49, 2..73] AND Condition Check #74 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 48]; Full Rest & Healing (Restore HP/MP) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [47..49, 2..28] AND Condition Check #29 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 48]; Dismiss Emotion Bubble (255) |
| `ev[02]` | `2 (Map Init)` | Story Flag 224 (bit 4) CLEAR | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[03]` | `2 (Map Init)` | Story Flag 224 (bit 4) SET | Open Dialogue Message Window; Engine Action #9 |
| `ev[04]` | `1 (Action / Talk)` | Story Flag 224 (bit 4) CLEAR AND Target Inspected is obj[8] | Jump to Bytecode Offset (4, 7); Make obj[0] Hidden (disp = 0); Engine Action #9; Warp Room -> Submap 9 at (224,4) facing 47 |

---

### Submap Layer `vj21_02` (Index 2)

- **Map Number (`mapno`)**: `3`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `3`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `3` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (3 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [47..49, 2..33] AND Condition Check #34 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 48]; Warp Map Transition (255, 254, 204, 204, 204) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [31..33, 2..72] AND Condition Check #73 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 3, MsgID: 32]; Recruit Hero #255 into Battle Slot 254 |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [63..65, 2..72] AND Condition Check #73 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 3, MsgID: 64]; Recruit Hero #255 into Battle Slot 254 |

---

### Submap Layer `vj21_03` (Index 3)

- **Map Number (`mapno`)**: `4`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `3`)
- **Entity Count (`okaz`)**: `2` Objects | **Script Count (`evkaz`)**: `6` Scripts

#### Complete Physical Entity Inventory (2 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 23)** | `0` | `(67, 29)` | `0x0` | Frame 23 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 24)** | `0` | `(67, 29)` | `0x0` | Frame 24 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(67, 29)` with state parameter `23`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(67, 29)` with state parameter `24`.


#### Complete Bytecode Script Catalog (6 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [31..33, 2..73] AND Condition Check #74 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 32]; Full Rest & Healing (Restore HP/MP) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [63..65, 2..73] AND Condition Check #74 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 64]; Full Rest & Healing (Restore HP/MP) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [47..49, 2..72] AND Condition Check #73 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 4, MsgID: 48]; Recruit Hero #255 into Battle Slot 254 |
| `ev[03]` | `2 (Map Init)` | Story Flag 224 (bit 8) CLEAR | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[04]` | `2 (Map Init)` | Story Flag 224 (bit 8) SET | Open Dialogue Message Window; Engine Action #9 |
| `ev[05]` | `1 (Action / Talk)` | Story Flag 224 (bit 8) CLEAR AND Target Inspected is obj[8] | Jump to Bytecode Offset (4, 7); Make obj[0] Hidden (disp = 0); Engine Action #9; Warp Room -> Submap 9 at (224,8) facing 47 |

---

### Submap Layer `vj21_04` (Index 4)

- **Map Number (`mapno`)**: `5`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `3`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `6` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (6 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [47..49, 2..73] AND Condition Check #74 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 3, MsgID: 48]; Full Rest & Healing (Restore HP/MP) |
| `ev[01]` | `128 (Loop)` | Player within Box [43..59, 2..26] AND Condition Check #48 AND Story Flag 221 (bit 4) SET | Warp Room -> Submap 0 at (9,21) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [47..49, 2..28] AND Condition Check #29 AND Story Flag 1 (mask 255) SET | Warp Map Transition (3, 0, 48, 30, 255) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [43..59, 2..26] AND Condition Check #48 AND Story Flag 221 (bit 4) CLEAR | Launch Tactical War Battle (1); Set Render Priority (pri) (0, 48); Start Boss Battle #9 (BGM: 3); Open Dialogue Message Window; Warp Room -> Submap 10 at (54,0) facing West (Left); Engine Action #83; Warp Room -> Submap 36 at (2,54) facing South (Down); Warp Town -> Area 9 Map 221 Submap 4 at (55,0); Turn obj[29] facing 9; Warp Map Transition (3, 0, 48, 30, 255) |
| `ev[04]` | `128 (Loop)` | Story Flag 221 (bit 4) CLEAR AND Inventory Holds Item #1 [Medicine] | Warp Room -> Submap 0 at (15,68); Toggle Random Encounters (1) |
| `ev[05]` | `128 (Loop)` | Story Flag 221 (bit 4) CLEAR AND Inventory Holds Item #2 [Mega Medicine] | Warp Room -> Submap 0 at (9,21); Toggle Random Encounters (2) |

---



## Location Map: `vj22`

- **Master Map Container**: `vj22.json`
- **Submap Layer Files**: vj22_00.json
- **Collision Grid Files**: None
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 5

### Submap Layer `vj22_00` (Index 0)

- **Map Number (`mapno`)**: `6`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `3`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `5` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (5 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `128 (Loop)` | Player within Box [43..53, 2..27] AND Condition Check #42 | Warp Room -> Submap 1 at (9,20) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [47..49, 2..33] AND Condition Check #34 AND Story Flag 0 (mask 255) SET | Warp Map Transition (2, 4, 48, 32, 255) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [23..25, 2..24] AND Condition Check #25 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 24]; Fade In from Black (255) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [27..29, 2..72] AND Condition Check #73 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 28]; Recruit Hero #255 into Battle Slot 254 |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [67..69, 2..72] AND Condition Check #73 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 68]; Recruit Hero #255 into Battle Slot 254 |

---

### Submap Layer `vj22_01` (Index 1)

- **Map Number (`mapno`)**: `7`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `3`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `4` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (4 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [23..25, 2..29] AND Condition Check #30 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 24]; Display Chapter Text (255) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [27..29, 2..73] AND Condition Check #74 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 28]; Full Rest & Healing (Restore HP/MP) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [67..69, 2..73] AND Condition Check #74 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 68]; Full Rest & Healing (Restore HP/MP) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [27..29, 2..44] AND Condition Check #45 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 28]; Remove Item from Inventory (255, 254) |

---

### Submap Layer `vj22_02` (Index 2)

- **Map Number (`mapno`)**: `8`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `3`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `3` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (3 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [27..29, 2..45] AND Condition Check #46 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 28]; Turn obj[255] facing 254 |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [43..45, 2..56] AND Condition Check #57 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 3, MsgID: 44]; Engine Action #54 |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [51..53, 2..56] AND Condition Check #57 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 3, MsgID: 52]; Engine Action #54 |

---

### Submap Layer `vj22_03` (Index 3)

- **Map Number (`mapno`)**: `9`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `3`)
- **Entity Count (`okaz`)**: `2` Objects | **Script Count (`evkaz`)**: `6` Scripts

#### Complete Physical Entity Inventory (2 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 23)** | `0` | `(27, 53)` | `0x0` | Frame 23 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 24)** | `0` | `(27, 53)` | `0x0` | Frame 24 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(27, 53)` with state parameter `23`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(27, 53)` with state parameter `24`.


#### Complete Bytecode Script Catalog (6 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [43..45, 2..57] AND Condition Check #58 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 44]; Trigger Character Emotion Effect (255, 254) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [51..53, 2..57] AND Condition Check #58 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 52]; Trigger Character Emotion Effect (255, 254) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [71..73, 2..28] AND Condition Check #29 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 4, MsgID: 72]; Dismiss Emotion Bubble (255) |
| `ev[03]` | `2 (Map Init)` | Story Flag 224 (bit 16) CLEAR | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[04]` | `2 (Map Init)` | Story Flag 224 (bit 16) SET | Open Dialogue Message Window; Engine Action #9 |
| `ev[05]` | `1 (Action / Talk)` | Story Flag 224 (bit 16) CLEAR AND Target Inspected is obj[8] | Jump to Bytecode Offset (4, 7); Make obj[0] Hidden (disp = 0); Engine Action #9; Warp Room -> Submap 9 at (224,16) facing 47 |

---

### Submap Layer `vj22_04` (Index 4)

- **Map Number (`mapno`)**: `12`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `3`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `6` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (6 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [71..73, 2..33] AND Condition Check #34 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 3, MsgID: 72]; Warp Map Transition (255, 254, 204, 204, 204) |
| `ev[01]` | `128 (Loop)` | Player within Box [43..53, 2..31] AND Condition Check #54 AND Story Flag 221 (bit 8) SET | Warp Room -> Submap 1 at (9,22) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [47..49, 2..28] AND Condition Check #29 AND Story Flag 1 (mask 255) SET | Warp Map Transition (2, 0, 48, 30, 255) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [43..53, 2..31] AND Condition Check #54 AND Story Flag 221 (bit 8) CLEAR | Launch Tactical War Battle (1); Set Render Priority (pri) (0, 48); Start Boss Battle #9 (BGM: 3); Open Dialogue Message Window; Warp Room -> Submap 10 at (54,0) facing West (Left); Engine Action #83; Warp Room -> Submap 36 at (2,54) facing South (Down); Warp Town -> Area 9 Map 221 Submap 8 at (55,0); Turn obj[29] facing 9; Warp Map Transition (2, 0, 48, 30, 255) |
| `ev[04]` | `128 (Loop)` | Story Flag 221 (bit 8) CLEAR AND Inventory Holds Item #1 [Medicine] | Warp Room -> Submap 1 at (15,69); Toggle Random Encounters (1) |
| `ev[05]` | `128 (Loop)` | Story Flag 221 (bit 8) CLEAR AND Inventory Holds Item #2 [Mega Medicine] | Warp Room -> Submap 1 at (9,22); Toggle Random Encounters (2) |

---



## Location Map: `vj23`

- **Master Map Container**: `vj23.json`
- **Submap Layer Files**: vj23_00.json
- **Collision Grid Files**: None
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 5

### Submap Layer `vj23_00` (Index 0)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `3`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `3` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (3 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `128 (Loop)` | Player within Box [27..53, 2..26] AND Condition Check #38 | Warp Room -> Submap 0 at (9,21) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [47..49, 2..33] AND Condition Check #34 AND Story Flag 0 (mask 255) SET | Warp Map Transition (3, 4, 48, 32, 255) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [47..49, 2..72] AND Condition Check #73 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 48]; Recruit Hero #255 into Battle Slot 254 |

---

### Submap Layer `vj23_01` (Index 1)

- **Map Number (`mapno`)**: `2`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `3`)
- **Entity Count (`okaz`)**: `2` Objects | **Script Count (`evkaz`)**: `5` Scripts

#### Complete Physical Entity Inventory (2 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 23)** | `0` | `(63, 73)` | `0x0` | Frame 23 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 24)** | `0` | `(63, 73)` | `0x0` | Frame 24 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(63, 73)` with state parameter `23`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(63, 73)` with state parameter `24`.


#### Complete Bytecode Script Catalog (5 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [47..49, 2..73] AND Condition Check #74 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 48]; Full Rest & Healing (Restore HP/MP) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [47..49, 2..28] AND Condition Check #29 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 48]; Dismiss Emotion Bubble (255) |
| `ev[02]` | `2 (Map Init)` | Story Flag 224 (bit 32) CLEAR | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[03]` | `2 (Map Init)` | Story Flag 224 (bit 32) SET | Open Dialogue Message Window; Engine Action #9 |
| `ev[04]` | `1 (Action / Talk)` | Story Flag 224 (bit 32) CLEAR AND Target Inspected is obj[8] | Jump to Bytecode Offset (4, 7); Make obj[0] Hidden (disp = 0); Engine Action #9; Warp Room -> Submap 9 at (224,32) facing 47 |

---

### Submap Layer `vj23_02` (Index 2)

- **Map Number (`mapno`)**: `3`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `3`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `3` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (3 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [47..49, 2..33] AND Condition Check #34 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 48]; Fade Out to Black (255) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [31..33, 2..72] AND Condition Check #73 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 3, MsgID: 32]; Recruit Hero #255 into Battle Slot 254 |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [63..65, 2..72] AND Condition Check #73 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 3, MsgID: 64]; Recruit Hero #255 into Battle Slot 254 |

---

### Submap Layer `vj23_03` (Index 3)

- **Map Number (`mapno`)**: `4`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `3`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `3` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (3 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [31..33, 2..73] AND Condition Check #74 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 32]; Full Rest & Healing (Restore HP/MP) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [63..65, 2..73] AND Condition Check #74 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 64]; Full Rest & Healing (Restore HP/MP) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [47..49, 2..72] AND Condition Check #73 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 4, MsgID: 48]; Recruit Hero #255 into Battle Slot 254 |

---

### Submap Layer `vj23_04` (Index 4)

- **Map Number (`mapno`)**: `5`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `3`)
- **Entity Count (`okaz`)**: `2` Objects | **Script Count (`evkaz`)**: `9` Scripts

#### Complete Physical Entity Inventory (2 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 23)** | `0` | `(27, 33)` | `0x0` | Frame 23 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 24)** | `0` | `(27, 33)` | `0x0` | Frame 24 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(27, 33)` with state parameter `23`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(27, 33)` with state parameter `24`.


#### Complete Bytecode Script Catalog (9 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [47..49, 2..73] AND Condition Check #74 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 3, MsgID: 48]; Full Rest & Healing (Restore HP/MP) |
| `ev[01]` | `128 (Loop)` | Player within Box [43..59, 2..26] AND Condition Check #48 AND Story Flag 223 (bit 64) SET | Warp Room -> Submap 0 at (9,23) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [47..49, 2..28] AND Condition Check #29 AND Story Flag 1 (mask 255) SET | Warp Map Transition (3, 0, 48, 30, 255) |
| `ev[03]` | `2 (Map Init)` | Story Flag 224 (bit 64) CLEAR | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[04]` | `2 (Map Init)` | Story Flag 224 (bit 64) SET | Open Dialogue Message Window; Engine Action #9 |
| `ev[05]` | `1 (Action / Talk)` | Story Flag 224 (bit 64) CLEAR AND Target Inspected is obj[8] | Jump to Bytecode Offset (4, 7); Make obj[0] Hidden (disp = 0); Engine Action #9; Warp Room -> Submap 9 at (224,64) facing 47 |
| `ev[06]` | `1 (Action / Talk)` | Player within Box [43..59, 2..26] AND Condition Check #48 AND Story Flag 223 (bit 64) CLEAR | Launch Tactical War Battle (1); Set Render Priority (pri) (0, 48); Start Boss Battle #9 (BGM: 3); Open Dialogue Message Window; Warp Room -> Submap 10 at (54,0) facing West (Left); Engine Action #83; Warp Room -> Submap 36 at (2,54) facing South (Down); Warp Town -> Area 9 Map 223 Submap 64 at (55,0); Turn obj[29] facing 9; Warp Map Transition (3, 0, 48, 30, 255) |
| `ev[07]` | `128 (Loop)` | Story Flag 223 (bit 64) CLEAR AND Inventory Holds Item #1 [Medicine] | Warp Room -> Submap 0 at (15,70); Toggle Random Encounters (1) |
| `ev[08]` | `128 (Loop)` | Story Flag 223 (bit 64) CLEAR AND Inventory Holds Item #2 [Mega Medicine] | Warp Room -> Submap 0 at (9,23); Toggle Random Encounters (2) |

---



## Location Map: `vj24`

- **Master Map Container**: `vj24.json`
- **Submap Layer Files**: vj24_00.json
- **Collision Grid Files**: None
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 6

### Submap Layer `vj24_00` (Index 0)

- **Map Number (`mapno`)**: `6`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `3`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `5` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (5 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `128 (Loop)` | Player within Box [43..53, 2..27] AND Condition Check #42 | Warp Room -> Submap 1 at (9,22) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [47..49, 2..33] AND Condition Check #34 AND Story Flag 0 (mask 255) SET | Warp Map Transition (2, 4, 48, 32, 255) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [23..25, 2..24] AND Condition Check #25 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 24]; Fade In from Black (255) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [27..29, 2..72] AND Condition Check #73 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 28]; Recruit Hero #255 into Battle Slot 254 |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [67..69, 2..72] AND Condition Check #73 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 68]; Recruit Hero #255 into Battle Slot 254 |

---

### Submap Layer `vj24_01` (Index 1)

- **Map Number (`mapno`)**: `7`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `3`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `4` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (4 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [23..25, 2..29] AND Condition Check #30 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 24]; Display Chapter Text (255) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [27..29, 2..73] AND Condition Check #74 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 28]; Full Rest & Healing (Restore HP/MP) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [67..69, 2..73] AND Condition Check #74 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 68]; Full Rest & Healing (Restore HP/MP) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [27..29, 2..44] AND Condition Check #45 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 28]; Remove Item from Inventory (255, 254) |

---

### Submap Layer `vj24_02` (Index 2)

- **Map Number (`mapno`)**: `8`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `3`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `3` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (3 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [27..29, 2..45] AND Condition Check #46 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 28]; Turn obj[255] facing 254 |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [43..45, 2..56] AND Condition Check #57 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 3, MsgID: 44]; Engine Action #54 |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [51..53, 2..56] AND Condition Check #57 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 3, MsgID: 52]; Engine Action #54 |

---

### Submap Layer `vj24_03` (Index 3)

- **Map Number (`mapno`)**: `9`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `3`)
- **Entity Count (`okaz`)**: `2` Objects | **Script Count (`evkaz`)**: `6` Scripts

#### Complete Physical Entity Inventory (2 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 23)** | `0` | `(27, 53)` | `0x0` | Frame 23 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 24)** | `0` | `(27, 53)` | `0x0` | Frame 24 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(27, 53)` with state parameter `23`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(27, 53)` with state parameter `24`.


#### Complete Bytecode Script Catalog (6 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [43..45, 2..57] AND Condition Check #58 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 44]; Trigger Character Emotion Effect (255, 254) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [51..53, 2..57] AND Condition Check #58 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 52]; Trigger Character Emotion Effect (255, 254) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [71..73, 2..28] AND Condition Check #29 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 4, MsgID: 72]; Dismiss Emotion Bubble (255) |
| `ev[03]` | `2 (Map Init)` | Story Flag 224 (bit 128) CLEAR | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[04]` | `2 (Map Init)` | Story Flag 224 (bit 128) SET | Open Dialogue Message Window; Engine Action #9 |
| `ev[05]` | `1 (Action / Talk)` | Story Flag 224 (bit 128) CLEAR AND Target Inspected is obj[8] | Jump to Bytecode Offset (4, 7); Make obj[0] Hidden (disp = 0); Engine Action #9; Warp Room -> Submap 9 at (224,128) facing 47 |

---

### Submap Layer `vj24_04` (Index 4)

- **Map Number (`mapno`)**: `10`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `70`, Rate: `3`)
- **Entity Count (`okaz`)**: `10` Objects | **Script Count (`evkaz`)**: `16` Scripts

#### Complete Physical Entity Inventory (10 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 15)** | `0` | `(44, 74)` | `0x0` | Frame 15 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 16)** | `0` | `(44, 74)` | `0x0` | Frame 16 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | World Device | **Mechanism (ano 17)** | `0` | `(44, 74)` | `0x0` | Frame 17 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | World Device | **Mechanism (ano 18)** | `0` | `(44, 74)` | `0x0` | Frame 18 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | World Device | **Mechanism (ano 19)** | `0` | `(48, 74)` | `0x0` | Frame 19 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | World Device | **Mechanism (ano 20)** | `0` | `(48, 74)` | `0x0` | Frame 20 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | World Device | **Mechanism (ano 21)** | `0` | `(48, 74)` | `0x0` | Frame 21 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | World Device | **Mechanism (ano 22)** | `0` | `(48, 74)` | `0x0` | Frame 22 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Rest Device / Fire | **Inn Bed / Recovery Device** | `0` | `(44, 74)` | `0x0` | Frame 13 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[09]` | Save Point | **Journeyman Save Orb** | `0` | `(48, 74)` | `0x0` | Frame 14 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(44, 74)` with state parameter `15`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(44, 74)` with state parameter `16`.
- **`obj[02]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(44, 74)` with state parameter `17`.
- **`obj[03]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(44, 74)` with state parameter `18`.
- **`obj[04]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(48, 74)` with state parameter `19`.
- **`obj[05]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(48, 74)` with state parameter `20`.
- **`obj[06]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(48, 74)` with state parameter `21`.
- **`obj[07]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(48, 74)` with state parameter `22`.
- **`obj[08]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(44, 74)` with state parameter `13`.
- **`obj[09]` (Journeyman Save Crystal)**: Floating save station orb at tile `(48, 74)`, priority `0`. Triggers `MSaveInit` save system dialog.


#### Complete Bytecode Script Catalog (16 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [71..73, 2..33] AND Condition Check #34 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 3, MsgID: 72]; Warp Map Transition (255, 254, 204, 204, 204) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [47..49, 2..72] AND Condition Check #73 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 5, MsgID: 48]; Recruit Hero #255 into Battle Slot 254 |
| `ev[02]` | `2 (Map Init)` | Story Flag 223 (bit 128) CLEAR | Make obj[0] Hidden (disp = 0); Dismiss Dialogue Portrait; Open Dialogue Message Window; Change Portrait Expression (47) |
| `ev[03]` | `2 (Map Init)` | Story Flag 223 (bit 128) SET | Make obj[2] Hidden (disp = 0); Dismiss Dialogue Portrait; Remove Item from Inventory (74, 0); Dismiss Dialogue Portrait; Warp Town -> Area 17 Map 50 Submap 74 at (0,17); Teleport obj[255] to (254,204) |
| `ev[04]` | `2 (Map Init)` | Story Flag 224 (bit 1) CLEAR | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[05]` | `2 (Map Init)` | Story Flag 224 (bit 2) CLEAR | Open Dialogue Message Window; Engine Action #9 |
| `ev[06]` | `2 (Map Init)` | Story Flag 224 (bit 4) CLEAR | Open Dialogue Message Window; Screen Fade Transition (255, 254, 204) |
| `ev[07]` | `2 (Map Init)` | Story Flag 224 (bit 8) CLEAR | Open Dialogue Message Window; Close Dialogue Window |
| `ev[08]` | `2 (Map Init)` | Story Flag 224 (bit 16) CLEAR | Open Dialogue Message Window; Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[09]` | `2 (Map Init)` | Story Flag 224 (bit 32) CLEAR | Open Dialogue Message Window; Place Scenery Structure (255) |
| `ev[10]` | `2 (Map Init)` | Story Flag 224 (bit 64) CLEAR | Open Dialogue Message Window; Animate Door Open |
| `ev[11]` | `2 (Map Init)` | Story Flag 224 (bit 128) CLEAR | Open Dialogue Message Window; Show Dialogue Portrait (255, 254, 204) |
| `ev[12]` | `1 (Action / Talk)` | Story Flag 223 (bit 128) CLEAR AND Story Flag 224 (bit 1) SET AND Story Flag 224 (bit 2) SET AND Story Flag 224 (bit 4) SET AND Story Flag 224 (bit 8) SET AND Story Flag 224 (bit 16) SET AND Story Flag 224 (bit 32) SET AND Story Flag 224 (bit 64) SET AND Story Flag 224 (bit 128) SET AND Player within Box [25..27, 2..74] AND Condition Check #75 | Launch Tactical War Battle (4); Set Render Priority (pri) (0, 48); Award Potch Currency (9,3); Open Dialogue Message Window; Warp Room -> Submap 60 at (101,4) facing 66; Launch Tactical War Battle (1); Launch Tactical War Battle (2); Engine Action #54; Open Dialogue Message Window; Warp Room -> Submap 0 at (2,101) facing 6; Engine Action #66; Engine Action #54; Open Dialogue Message Window; Exit to World Map (73, 10, 83); Warp Room -> Submap 73 at (30,5) facing South (Down); Warp Room -> Submap 30 at (37,4) facing 9; Engine Action #223; Engine Action #128 |
| `ev[13]` | `128 (Loop)` | Story Flag 223 (bit 128) CLEAR AND Inventory Holds Item #1 [Medicine] | Engine Action #90; Dismiss Dialogue Portrait; Exit to World Map (3, 18, 2); Dismiss Emotion Bubble (73); Dismiss Emotion Bubble (37); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[14]` | `128 (Loop)` | Story Flag 223 (bit 128) CLEAR AND Inventory Holds Item #2 [Mega Medicine] | Engine Action #90; Change Portrait Expression (4); Warp to Castle HQ (19, 2, 30); Set Combat Battle BGM (30); Toggle Random Encounters (2) |
| `ev[15]` | `128 (Loop)` | Story Flag 223 (bit 128) CLEAR AND Inventory Holds Item #4 [Throat Drops] | Warp Room -> Submap 1 at (15,71); Toggle Random Encounters (4) |

---

### Submap Layer `vj24_05` (Index 5)

- **Map Number (`mapno`)**: `11`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `1` Objects | **Script Count (`evkaz`)**: `4` Scripts

#### Complete Physical Entity Inventory (1 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | Save Point | **Journeyman Save Orb** | `0` | `(47, 34)` | `0x0` | Frame 25 | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Journeyman Save Crystal)**: Floating save station orb at tile `(47, 34)`, priority `0`. Triggers `MSaveInit` save system dialog.


#### Complete Bytecode Script Catalog (4 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [47..49, 2..72] AND Condition Check #73 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 4, MsgID: 48]; Full Rest & Healing (Restore HP/MP) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [40..56, 2..30] AND Condition Check #46 | Set Render Priority (pri) (0, 48); Open Save Crystal Menu (MSaveInit); Reset Camera Tracking (3); Open Dialogue Message Window; Warp Room -> Submap 1 at (54,0) facing West (Left); Reset Camera Tracking (73); Branch on Choice (40, 0); Open Dialogue Message Window; Warp to Castle HQ (0, 2, 0); Warp to Castle HQ (0, 4, 41); Warp to Castle HQ (0, 1, 2); Open Dialogue Message Window; Close Dialogue Sub-Window (8); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp to Castle HQ (0, 6, 0); Pan Camera (0, 8, 41); Warp to Castle HQ (3, 4, 2); Warp to Castle HQ (24, 8, 0); Engine Action #9; Set Combat Battle BGM (20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp to Castle HQ (0, 10, 0); Close Dialogue Window; Open Dialogue Message Window; Display Dialogue Box [Bank: 41, MsgID: 3]; Engine Action #5; Exit to World Map (2, 255, 5); Close Dialogue Sub-Window (8); Open Dialogue Message Window; Place Scenery Structure (73); Show Dialogue Portrait (69, 2, 11); Warp Town -> Area 2 Map 180 Submap 30 at (2,0); Jump to Bytecode Offset (9, 15); Place Scenery Structure (5); Open Dialogue Message Window; Open Dialogue Message Window; Open Dialogue Message Window; Set Entity Movement Speed (38, 255); Exit to World Map (24, 8, 0); Animate Door Open; Engine Action #5; Open Dialogue Message Window; Exit to World Map (3, 7, 5); Dismiss Emotion Bubble (9); Engine Action #223; Animate Doorway State (255, 254); Warp Room -> Submap 8 at (0,18) facing 73; Branch on Choice (40, 0); Open Dialogue Message Window; Warp Town -> Area 0 Map 19 Submap 0 at (20,41); Warp Town -> Area 6 Map 7 Submap 255 at (6,24); Reset Camera Tracking (0); Execute Choice Result (73); Show Dialogue Portrait (69, 3, 11); Exit to World Map (2, 120, 13); Engine Action #5; Engine Action #9; Dismiss Dialogue Portrait; Open Dialogue Message Window; Engine Action #78; Display Chapter Text (255); Pan Camera (24, 8, 0); Set Story Flag (73, 15); Engine Action #5; Open Dialogue Message Window; Exit to World Map (3, 7, 5); Dismiss Emotion Bubble (9); Engine Action #223; Animate Doorway State (255, 254); Warp Town -> Area 24 Map 8 Submap 0 at (15,51); Reset Camera Tracking (255) |
| `ev[02]` | `128 (Loop)` | Story Flag 223 (bit 64) CLEAR AND Inventory Holds Item #1 [Medicine] | Close Dialogue Sub-Window (8); Open Dialogue Message Window; Warp Room -> Submap 1 at (255,254) facing 204 |
| `ev[03]` | `128 (Loop)` | Story Flag 223 (bit 64) SET AND Inventory Holds Item #1 [Medicine] | Close Dialogue Sub-Window (8); Open Dialogue Message Window; Close Dialogue Sub-Window (37); Warp Room -> Submap 254 at (204,204) facing 204 |

---


