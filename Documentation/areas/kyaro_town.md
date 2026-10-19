# Suikoden II Geographic Area Catalog: Kyaro Town (Plaza, Homes & Execution Grounds)

**Geographic Scope & Role**: Riou's home town; town square cobblestones, flower shop, Genkaku's shrine and backyard tree (Mukumuku), Jowy's noble Atreides estate, town inn, blacksmith forge, and the execution grounds.

**Regional Category**: Region `VA` | **Master Maps Included**: `va08`, `va09`, `va10`, `va11`, `va12`, `va13`, `va14`, `va15`, `va16`, `va17`, `va18`, `va19`, `va20`, `va21`, `va22`, `va23`, `va25`, `va26`

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

## Location Map: `va08`

- **Master Map Container**: `va08.json`
- **Submap Layer Files**: va08_01.json, va08_02.json, va08_05.json, va08_06.json
- **Collision Grid Files**: va08_map_00.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 1

### Submap Layer `va08_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `24` Objects | **Script Count (`evkaz`)**: `12` Scripts

#### Complete Physical Entity Inventory (24 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Highland Patrol Soldier** | `80` | `(56, 27)` | `0x0` | Up (North) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Youth Brigade Recruit** | `3` | `(13, 28)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Jowy Atreides** | `2` | `(13, 30)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | NPC / Actor | **Jeane (Rune Sage)** | `145` | `(48, 32)` | `0x0` | East (Right) | Dormant / Hidden (0) | Passable (0) | 4 | 0 | 0 |
| `obj[04]` | NPC / Actor | **Actor ID 65104** | `65104` | `(45, 30)` | `0x0` | Up (North) | Dormant / Hidden (0) | Passable (0) | 4 | 0 | 0 |
| `obj[05]` | NPC / Actor | **Actor ID 65104** | `65104` | `(45, 35)` | `0x0` | Up (North) | Dormant / Hidden (0) | Passable (0) | 4 | 0 | 0 |
| `obj[06]` | NPC / Actor | **Actor ID 65104** | `65104` | `(45, 35)` | `0x0` | Up (North) | Dormant / Hidden (0) | Passable (0) | 4 | 0 | 0 |
| `obj[07]` | NPC / Actor | **Actor ID 65104** | `65104` | `(45, 35)` | `0x0` | Up (North) | Dormant / Hidden (0) | Passable (0) | 4 | 0 | 0 |
| `obj[08]` | NPC / Actor | **Actor ID 65104** | `65104` | `(45, 35)` | `0x0` | Up (North) | Dormant / Hidden (0) | Passable (0) | 4 | 0 | 0 |
| `obj[09]` | NPC / Actor | **Actor ID 65104** | `65104` | `(45, 35)` | `0x0` | Up (North) | Dormant / Hidden (0) | Passable (0) | 4 | 0 | 0 |
| `obj[10]` | NPC / Actor | **Actor ID 65104** | `65104` | `(45, 35)` | `0x0` | Up (North) | Dormant / Hidden (0) | Passable (0) | 4 | 0 | 0 |
| `obj[11]` | NPC / Actor | **Actor ID 65104** | `65104` | `(45, 35)` | `0x0` | Up (North) | Dormant / Hidden (0) | Passable (0) | 4 | 0 | 0 |
| `obj[12]` | Prop / Scenery | **Prop ID 33538** | `33538` | `(20, 20)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 3 | 55 | 0 |
| `obj[13]` | Prop / Scenery | **Prop ID 33282** | `33282` | `(20, 20)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 3 | 55 | 0 |
| `obj[14]` | Prop / Scenery | **Prop ID 33282** | `33282` | `(20, 20)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 3 | 55 | 0 |
| `obj[15]` | Prop / Scenery | **Prop ID 33282** | `33282` | `(20, 20)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 3 | 55 | 0 |
| `obj[16]` | Prop / Scenery | **Prop ID 33538** | `33538` | `(20, 20)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 3 | 55 | 0 |
| `obj[17]` | Prop / Scenery | **Prop ID 64960** | `64960` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 55 | 0 |
| `obj[18]` | Prop / Scenery | **Prop ID 64960** | `64960` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 55 | 0 |
| `obj[19]` | Prop / Scenery | **Prop ID 64960** | `64960` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 55 | 0 |
| `obj[20]` | Prop / Scenery | **Prop ID 64960** | `64960` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 55 | 0 |
| `obj[21]` | Prop / Scenery | **Prop ID 64960** | `64960` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 55 | 0 |
| `obj[22]` | Prop / Scenery | **Prop ID 64960** | `64960` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 55 | 0 |
| `obj[23]` | Prop / Scenery | **Prop ID 64960** | `64960` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 55 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Highland Patrol Soldier)**: Positioned at tile `(56, 27)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Youth Brigade Recruit)**: Positioned at tile `(13, 28)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Jowy Atreides)**: Positioned at tile `(13, 30)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Jeane (Rune Sage))**: Positioned at tile `(48, 32)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Object 65104)**: Positioned at tile `(45, 30)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Object 65104)**: Positioned at tile `(45, 35)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[06]` (Object 65104)**: Positioned at tile `(45, 35)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[07]` (Object 65104)**: Positioned at tile `(45, 35)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[08]` (Object 65104)**: Positioned at tile `(45, 35)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[09]` (Object 65104)**: Positioned at tile `(45, 35)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[10]` (Object 65104)**: Positioned at tile `(45, 35)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[11]` (Object 65104)**: Positioned at tile `(45, 35)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[12]` (Prop: Object 33538)**: Environmental world dressing prop placed at tile `(20, 20)`. Solid collision is set to `0`.
- **`obj[13]` (Prop: Object 33282)**: Environmental world dressing prop placed at tile `(20, 20)`. Solid collision is set to `0`.
- **`obj[14]` (Prop: Object 33282)**: Environmental world dressing prop placed at tile `(20, 20)`. Solid collision is set to `0`.
- **`obj[15]` (Prop: Object 33282)**: Environmental world dressing prop placed at tile `(20, 20)`. Solid collision is set to `0`.
- **`obj[16]` (Prop: Object 33538)**: Environmental world dressing prop placed at tile `(20, 20)`. Solid collision is set to `0`.
- **`obj[17]` (Prop: Object 64960)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[18]` (Prop: Object 64960)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[19]` (Prop: Object 64960)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[20]` (Prop: Object 64960)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[21]` (Prop: Object 64960)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[22]` (Prop: Object 64960)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[23]` (Prop: Object 64960)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.


#### Complete Bytecode Script Catalog (12 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Always Passes (Unconditional) | Make obj[2] Hidden (disp = 0); Branch on Choice (56, 42); Engine Action #89; Branch on Choice (2, 0); Open Dialogue Message Window; Branch on Choice (2, 21); Engine Action #58; Engine Action #44; Engine Action #89; Execute Choice Result (2); Open Dialogue Message Window; Open Dialogue Message Window; Execute Choice Result (2); Reset Camera Tracking (58); Engine Action #44; Engine Action #89; Reset Camera Tracking (2); Open Dialogue Message Window; Warp Room -> Submap 2 at (11,40) facing 47; Open Dialogue Message Window; Close Dialogue Window; Warp to Castle HQ (11, 3, 2); Animate Door Open; Toggle Random Encounters (45); Open Dialogue Message Window; Animate Door Open; Warp to Castle HQ (14, 3, 2); Show Dialogue Portrait (38, 49, 0); Show Dialogue Portrait (3, 15, 3); Warp Town -> Area 16 Map 34 Submap 45 at (0,16); Warp to Castle HQ (16, 3, 2); Change Portrait Expression (35); Set Entity Movement Speed (0, 17); Warp to Castle HQ (17, 3, 2); Display Speaker Name Box (31); Make obj[0] Visible (disp = 1); Display Speaker Name Box (3); Display Speaker Name Box (3); Warp Town -> Area 19 Map 32 Submap 49 at (0,19); Warp to Castle HQ (19, 3, 47) |
| `ev[01]` | `1 (Action / Talk)` | Story Flag 4 (bit 64) SET AND Story Flag 4 (bit 128) CLEAR | Recruit Character into Active Party (43, 0); Pan Camera (4, 0, 56); Display Speaker Name Box (8); Make obj[1] Hidden (disp = 0); Open Dialogue Message Window; Warp Town -> Area 22 Map 59 Submap 42 at (89,22); Warp Town -> Area 7 Map 0 Submap 22 at (47,73); Engine Action #6; Make obj[2] Hidden (disp = 0); Open Dialogue Sub-Window (61); Engine Action #44; Engine Action #89; Open Dialogue Sub-Window (2); Pan Camera (0, 23, 47); Launch Tactical War Battle (8); Launch Tactical War Battle (1); Set Entity Movement Speed (2, 5); Open Dialogue Message Window; Exit to World Map (3, 0, 24); Dismiss Emotion Bubble (255); Engine Action #5; Close Dialogue Window; Exit to World Map (3, 5, 240); Warp to Castle HQ (7, 30, 255); Walk obj[37] to (1,73); Show Dialogue Portrait (24, 11, 0); Load Sound Bank into Memory (73, 15); Engine Action #54; Open Dialogue Message Window; Warp Town -> Area 54 Map 0 Submap 4 at (89,20); Warp Town -> Area 2 Map 73 Submap 20 at (40,0); Open Dialogue Message Window; Warp Town -> Area 0 Map 73 Submap 0 at (74,73); Show Dialogue Portrait (89, 21, 2); Warp Town -> Area 24 Map 8 Submap 0 at (75,73); Show Dialogue Portrait (24, 11, 1); Pan Camera (73, 15, 101); Engine Action #9; Engine Action #6; Full Rest & Healing (Restore HP/MP); Warp Room -> Submap 2 at (30,4) facing 46; Warp Room -> Submap 1 at (15,1) facing 16; Warp Room -> Submap 1 at (18,1) facing 19; Warp Town -> Area 9 Map 8 Submap 47 at (1,9); Warp to Castle HQ (9, 3, 2); Screen Fade Transition (63, 43, 0); Screen Fade Transition (3, 10, 2); Warp Town -> Area 25 Map 60 Submap 42 at (89,25); Warp Town -> Area 2 Map 0 Submap 25 at (2,26); Play Sound Effect (SE) (45); Engine Action #89; Fade In from Black (2); Warp to Castle HQ (0, 26, 2); Fade Out to Black (31); Make obj[89] Hidden (disp = 0); Fade Out to Black (2); Exit to World Map (0, 27, 2); Display Chapter Text (33); Set Entity Movement Speed (89, 28); Warp Town -> Area 7 Map 0 Submap 28 at (2,29); Start Boss Battle #44 (BGM: 89); Display Emotion Bubble (2, 8); Open Dialogue Message Window; Display Emotion Bubble (2, 30); Engine Action #39; Turn obj[89] facing 30; Warp Town -> Area 9 Map 0 Submap 30 at (2,31); Launch Tactical War Battle (52); Engine Action #89; Warp Room -> Submap 2 at (2,0); Warp Room -> Submap 47 at (73,60); Engine Action #5; Close Dialogue Window; Exit to World Map (6, 3, 2); Dismiss Emotion Bubble (101); Pan Camera (1, 36, 16); Close Dialogue Sub-Window (11); Warp Room -> Submap 73 at (10,81) facing South (Down); Reset Camera Tracking (81); Open Dialogue Message Window; Reset Camera Tracking (54); Open Dialogue Message Window; Dismiss Dialogue Portrait; Full Rest & Healing (Restore HP/MP); Open Dialogue Message Window; Open Dialogue Sub-Window (3); Dismiss Emotion Bubble (6); Jump to Bytecode Offset (1, 0); Engine Action #5; Close Dialogue Window; Engine Action #5; Show Dialogue Portrait (3, 0, 5); Show Dialogue Portrait (0, 0, 5); Engine Action #5; Warp Town -> Area 0 Map 5 Submap 15 at (0,0); Engine Action #5; Engine Action #5; Warp to Castle HQ (0, 30, 89); Execute Choice Result (2); Warp Room -> Submap 5 at (89,20) facing Up (North); Warp Room -> Submap 10 at (0,78) facing 5; Screen Fade Transition (4, 5, 5); Show Dialogue Portrait (2, 3, 30); Make obj[2] Hidden (disp = 0); Close Dialogue Sub-Window (60); Open Shop Menu #4 (Type: 101); Fade Out to Black (89); Close Dialogue Sub-Window (2); Pan Camera (0, 24, 1); Screen Fade Transition (47, 73, 10); Engine Action #89; Branch on Choice (2, 3); Jump to Bytecode Offset (4, 26); Set Combat Battle BGM (3); Engine Action #89; Execute Choice Result (2); Warp to Castle HQ (101, 4, 26); Engine Action #89; Close Dialogue Sub-Window (5); Engine Action #89; Close Dialogue Sub-Window (5); Set Combat Battle BGM (30); Engine Action #89; Close Dialogue Sub-Window (2); Reset Camera Tracking (101); Exit to World Map (27, 73, 7); Engine Action #89; Execute Choice Result (2); Exit to World Map (101, 4, 26); Set Combat Battle BGM (3); Engine Action #89; Branch on Choice (2, 4); Jump to Bytecode Offset (4, 26); Engine Action #89; Branch on Choice (5, 89); Branch on Choice (5, 73); Show Dialogue Portrait (89, 20, 2); Engine Action #5; Set Combat Battle BGM (4); Engine Action #89; Execute Choice Result (2); Engine Action #5; Engine Action #89; Execute Choice Result (5); Engine Action #89; Execute Choice Result (5); Make obj[3] Hidden (disp = 0); Screen Fade Transition (2, 0, 10); Warp Room -> Submap 3 at (0,0) facing South (Down); Open Dialogue Message Window; Warp to Castle HQ (8, 0, 0); Reset Camera Tracking (89); Branch on Choice (2, 6); Engine Action #89; Execute Choice Result (2); Engine Action #6; Teleport obj[5] to (8,5); Engine Action #5; Warp Town -> Area 0 Map 30 Submap 5 at (0,5); Engine Action #5; Warp Town -> Area 0 Map 5 Submap 5 at (30,24); Close Dialogue Window; Open Dialogue Message Window; Bytecode Subroutine Return; Set Combat Battle BGM (10); Warp to Castle HQ (0, 2, 73); Pan Camera (3, 8, 2); Launch Tactical War Battle (32); Close Dialogue Sub-Window (9); Open Dialogue Message Window; Engine Action #80; Engine Action #54; Open Dialogue Message Window; Warp Map Transition (73, 15, 24, 8, 0); Engine Action #81; Engine Action #5; Close Dialogue Window; Engine Action #5; Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp to Castle HQ (0, 5, 10); Dismiss Emotion Bubble (24); Engine Action #9; Open Dialogue Message Window; Remove Item from Inventory (5, 11); Engine Action #5; Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp Town -> Area 0 Map 5 Submap 10 at (30,24); Screen Fade Transition (0, 83, 5); Close Dialogue Window; Engine Action #5; Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp to Castle HQ (0, 4, 3); Pan Camera (1, 5, 5); Dismiss Emotion Bubble (24); Engine Action #9; Open Dialogue Message Window; Dismiss Character to Castle Base (49); Engine Action #5; Engine Action #5; Close Dialogue Window; Exit to World Map (6, 0, 13); Dismiss Emotion Bubble (1); Close Dialogue Window; Engine Action #5; Open Dialogue Message Window; Engine Action #5; Clear Dialogue Sub-Window; Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Reset Camera Tracking (5); Show Dialogue Portrait (0, 0, 30); Engine Action #5; Screen Fade Transition (5, 5, 0); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Engine Action #9; Engine Action #5; Dismiss Emotion Bubble (0); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Walk obj[36] to (64,24); Engine Action #9; Warp Room -> Submap 54 at (0,64) facing 24; Engine Action #9; Warp Room -> Submap 73 at (15,24) facing 8; Open Dialogue Message Window; Animate Door obj[5] (State: 8); Engine Action #5; Screen Fade Transition (1, 0, 5); Screen Fade Transition (30, 73, 20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 0 Map 87 Submap 0 at (91,41); Warp Town -> Area 0 Map 1 Submap 255 at (0,5); Reset Camera Tracking (5); Reset Camera Tracking (1); Open Dialogue Message Window; Engine Action #5; Reset Camera Tracking (30); Close Dialogue Sub-Window (8); Open Dialogue Message Window; Engine Action #88; Set Combat Battle BGM (15); Close Dialogue Sub-Window (9); Open Dialogue Message Window; Engine Action #89; Set Combat Battle BGM (15); Close Dialogue Sub-Window (10); Open Dialogue Message Window; Engine Action #90; Set Combat Battle BGM (30); Make obj[115] Hidden (disp = 0); Warp Town -> Area 20 Map 115 Submap 3 at (20,47); Engine Action #85; Warp Room -> Submap 8 at (0,3) facing 80; Warp Room -> Submap 1 at (2,1) facing 73; Show Dialogue Portrait (11, 2, 2); Engine Action #120; Wait for Audio / Window Sync (1); Make obj[3] Hidden (disp = 0); Open Dialogue Message Window; Warp Room -> Submap 4 at (128,10) facing South (Down); Screen Fade Transition (1, 254, 10); Warp Town -> Area 254 Map 10 Submap 3 at (254,47); Engine Action #102; Warp Room -> Submap 5 at (0,5) facing South (Down); Set Animation Pose (26, 58); Warp Room -> Submap 8 at (5,8) facing West (Left); Open Dialogue Message Window; Engine Action #5; Reset Camera Tracking (30); Close Dialogue Sub-Window (8); Open Dialogue Message Window; Make Object Hidden (disp = 0) (73); Show Dialogue Portrait (73, 20, 40); Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 0 Map 87 Submap 0 at (91,41); Warp Town -> Area 0 Map 3 Submap 255 at (3,73); Show Dialogue Portrait (24, 8, 0); Engine Action #93; Set Combat Battle BGM (15); Set Combat Battle BGM (20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 0 Map 87 Submap 0 at (91,41); Warp Town -> Area 0 Map 4 Submap 255 at (4,73); Show Dialogue Portrait (24, 8, 0); Engine Action #94; Set Combat Battle BGM (15); Make obj[115] Hidden (disp = 0); Warp Town -> Area 20 Map 115 Submap 3 at (20,47); Engine Action #85; Warp Room -> Submap 8 at (0,3) facing 80; Warp Room -> Submap 1 at (2,1) facing 73; Show Dialogue Portrait (11, 2, 2); Engine Action #120; Wait for Audio / Window Sync (3); Make obj[3] Hidden (disp = 0); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #9; Exit to World Map (128, 10, 0); Screen Fade Transition (1, 254, 10); Warp Town -> Area 254 Map 10 Submap 3 at (254,47); Engine Action #102; Warp Room -> Submap 5 at (0,2) facing South (Down); Warp Room -> Submap 109 at (58,255) |
| `ev[02]` | `128 (Loop)` | Story Flag 4 (bit 64) SET AND Story Flag 4 (bit 128) CLEAR AND Story Flag 0 (bit 1) CLEAR AND Inventory Holds Item #1 AND Temp Event Flag #2 SET | Launch Tactical War Battle (2); Engine Action #89; Set Story Flag (2, 8); Set Combat Battle BGM (24); Engine Action #89; Branch on Choice (2, 9); Jump to Bytecode Offset (4, 23); Engine Action #89; Branch on Choice (5, 89); Branch on Choice (5, 89); Branch on Choice (2, 0); Engine Action #89; Set Story Flag (5, 89); Set Story Flag (5, 73); Screen Fade Transition (89, 22, 2); Engine Action #9; Set Combat Battle BGM (24); Engine Action #89; Branch on Choice (2, 9); Jump to Bytecode Offset (4, 23); Engine Action #89; Branch on Choice (5, 89); Branch on Choice (5, 89); Branch on Choice (2, 0); Engine Action #89; Set Story Flag (5, 89); Set Story Flag (5, 89); Set Story Flag (2, 7); Set Combat Battle BGM (50); Toggle Random Encounters (2) |
| `ev[03]` | `128 (Loop)` | Story Flag 4 (bit 64) SET AND Story Flag 4 (bit 128) CLEAR AND Story Flag 0 (bit 1) CLEAR AND Inventory Holds Item #1 AND Temp Event Flag #4 SET | Launch Tactical War Battle (4); Set Combat Battle BGM (15); Engine Action #89; Open Dialogue Sub-Window (2); Reset Camera Tracking (73); Close Dialogue Sub-Window (89); Execute Choice Result (2); Screen Fade Transition (101, 4, 23); Engine Action #89; Execute Choice Result (5); Engine Action #89; Execute Choice Result (5); Engine Action #89; Execute Choice Result (2); Open Dialogue Message Window; Engine Action #89; Open Dialogue Sub-Window (5); Engine Action #89; Open Dialogue Sub-Window (5); Set Combat Battle BGM (10); Engine Action #89; Open Dialogue Sub-Window (2); Engine Action #9; Set Combat Battle BGM (24); Engine Action #89; Execute Choice Result (2); Screen Fade Transition (101, 4, 23); Engine Action #89; Execute Choice Result (5); Engine Action #89; Execute Choice Result (5); Engine Action #89; Execute Choice Result (2); Open Dialogue Message Window; Engine Action #89; Open Dialogue Sub-Window (5); Engine Action #89; Open Dialogue Sub-Window (5); Engine Action #89; Open Dialogue Sub-Window (2); Pan Camera (73, 38, 37); Exit to World Map (255, 254, 255) |
| `ev[04]` | `128 (Loop)` | Story Flag 4 (bit 64) SET AND Story Flag 4 (bit 128) CLEAR AND Story Flag 0 (bit 1) CLEAR AND Inventory Holds Item #8 | Close Dialogue Window; Warp Room -> Submap 150 at (37,8) facing 255 |
| `ev[05]` | `128 (Loop)` | Story Flag 4 (bit 64) SET AND Story Flag 4 (bit 128) CLEAR AND Character #1 Level >= 255 | Launch Tactical War Battle (1); Engine Action #5; Close Dialogue Window; Warp Room -> Submap 30 at (80,1) facing 255 |
| `ev[06]` | `128 (Loop)` | Story Flag 4 (bit 64) SET AND Story Flag 4 (bit 128) CLEAR AND Story Flag 0 (bit 1) CLEAR AND Inventory Holds Item #32 | Open Dialogue Message Window; Engine Action #9; Set Entity Movement Speed (2, 5); Engine Action #9; Exit to World Map (4, 3, 36); Dismiss Emotion Bubble (255); Engine Action #5; Close Dialogue Window; Engine Action #5; Trigger Character Emotion Effect (0, 0); Engine Action #5; Engine Action #5; Warp Town -> Area 0 Map 4 Submap 3 at (7,1); Engine Action #5; Engine Action #5; Dismiss Emotion Bubble (255); Walk obj[37] to (32,255) |
| `ev[07]` | `128 (Loop)` | Story Flag 4 (bit 64) SET AND Story Flag 4 (bit 128) CLEAR AND Story Flag 0 (bit 1) CLEAR AND Inventory Holds Item #64 | Engine Action #5; Engine Action #9; Exit to World Map (6, 5, 10); Warp to Castle HQ (2, 0, 13); Engine Action #5; Trigger Character Emotion Effect (3, 3); Dismiss Emotion Bubble (49); Warp to Castle HQ (5, 9, 4); Exit to World Map (1, 13, 3); Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 255, 254); Engine Action #5; Reset Camera Tracking (5); Mark NPC Talk Interaction Complete (Flag #2); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Screen Fade Transition (5, 80, 2); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Walk obj[37] to (64,255) |
| `ev[08]` | `128 (Loop)` | Story Flag 4 (bit 64) SET AND Story Flag 4 (bit 128) CLEAR AND Character #2 Level >= 255 | Make obj[37] Hidden (disp = 0); Warp Room -> Submap 22 at (1,23) facing 47; Set Combat Battle BGM (10); Jump to Bytecode Offset (4, 22); Set Combat Battle BGM (15); Jump to Bytecode Offset (4, 24); Set Combat Battle BGM (25); Jump to Bytecode Offset (4, 22); Set Combat Battle BGM (10); Jump to Bytecode Offset (4, 24); Set Combat Battle BGM (20); Jump to Bytecode Offset (4, 22); Set Combat Battle BGM (15); Jump to Bytecode Offset (4, 24); Set Combat Battle BGM (20); Jump to Bytecode Offset (4, 24); Engine Action #80; Warp Town -> Area 255 Map 254 Submap 255 at (254,204) |
| `ev[09]` | `128 (Loop)` | Story Flag 4 (bit 64) SET AND Story Flag 4 (bit 128) CLEAR AND Story Flag 0 (bit 1) CLEAR AND Inventory Holds Item #16 | Set Object Direction (2, 10); Open Dialogue Message Window; Toggle Random Encounters (16) |
| `ev[10]` | `128 (Loop)` | Story Flag 4 (bit 64) SET AND Story Flag 4 (bit 128) CLEAR AND Character #4 Level >= 255 | Set Combat Battle BGM (15); Jump to Bytecode Offset (4, 22); Set Combat Battle BGM (25); Jump to Bytecode Offset (4, 24); Set Combat Battle BGM (30); Jump to Bytecode Offset (4, 22); Set Combat Battle BGM (15); Jump to Bytecode Offset (4, 24); Set Combat Battle BGM (25); Jump to Bytecode Offset (4, 24); Set Combat Battle BGM (10); Jump to Bytecode Offset (4, 22); Set Combat Battle BGM (15); Jump to Bytecode Offset (4, 24); Engine Action #80; Exit to World Map (255, 254, 255) |
| `ev[11]` | `128 (Loop)` | Story Flag 4 (bit 64) SET AND Story Flag 4 (bit 128) CLEAR AND Character #8 Level >= 255 | Set Combat Battle BGM (10); Jump to Bytecode Offset (4, 22); Set Combat Battle BGM (5); Jump to Bytecode Offset (4, 24); Set Combat Battle BGM (10); Jump to Bytecode Offset (4, 24); Set Combat Battle BGM (15); Jump to Bytecode Offset (4, 22); Set Combat Battle BGM (5); Jump to Bytecode Offset (4, 22); Set Combat Battle BGM (10); Jump to Bytecode Offset (4, 24); Set Combat Battle BGM (5); Jump to Bytecode Offset (4, 24); Set Combat Battle BGM (15); Jump to Bytecode Offset (4, 22); Set Combat Battle BGM (5); Jump to Bytecode Offset (4, 22); Set Combat Battle BGM (10); Jump to Bytecode Offset (4, 24); Set Combat Battle BGM (5); Jump to Bytecode Offset (4, 22); Engine Action #80; Reset Camera Tracking (255) |

---



## Location Map: `va09`

- **Master Map Container**: `va09.json`
- **Submap Layer Files**: va09_00.json, va09_07.json
- **Collision Grid Files**: va09_map_00.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 1

### Submap Layer `va09_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `14` Objects | **Script Count (`evkaz`)**: `36` Scripts

#### Complete Physical Entity Inventory (14 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Jeane (Rune Sage)** | `145` | `(48, 92)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Highland Patrol Soldier** | `80` | `(34, 31)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Jude (Sculptor)** | `140` | `(55, 74)` | `0x0` | East (Right) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[03]` | NPC / Actor | **Actor ID 65104** | `65104` | `(16, 16)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 3 | 255 | 0 |
| `obj[04]` | NPC / Actor | **Actor ID 65104** | `65104` | `(16, 16)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 3 | 255 | 0 |
| `obj[05]` | NPC / Actor | **Actor ID 65104** | `65104` | `(16, 16)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 3 | 255 | 0 |
| `obj[06]` | NPC / Actor | **Actor ID 65104** | `65104` | `(16, 16)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 3 | 255 | 0 |
| `obj[07]` | Prop / Scenery | **Prop ID 37200** | `37200` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 55 | 0 |
| `obj[08]` | Prop / Scenery | **Prop ID 33872** | `33872` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 55 | 0 |
| `obj[09]` | Prop / Scenery | **Prop ID 34049** | `34049` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 55 | 0 |
| `obj[10]` | Prop / Scenery | **Prop ID 34128** | `34128` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 55 | 0 |
| `obj[11]` | Prop / Scenery | **Prop ID 34128** | `34128` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 55 | 0 |
| `obj[12]` | World Device | **Mechanism (ano 4)** | `0` | `(0, 0)` | `0x0` | Frame 4 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 1 | 480 |
| `obj[13]` | World Device | **Mechanism (ano 5)** | `0` | `(0, 0)` | `0x0` | Frame 5 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 1 | 480 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Jeane (Rune Sage))**: Positioned at tile `(48, 92)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Highland Patrol Soldier)**: Positioned at tile `(34, 31)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Jude (Sculptor))**: Positioned at tile `(55, 74)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Object 65104)**: Positioned at tile `(16, 16)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Object 65104)**: Positioned at tile `(16, 16)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Object 65104)**: Positioned at tile `(16, 16)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[06]` (Object 65104)**: Positioned at tile `(16, 16)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[07]` (Prop: Object 37200)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `0`.
- **`obj[08]` (Prop: Object 33872)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `0`.
- **`obj[09]` (Prop: Object 34049)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `0`.
- **`obj[10]` (Prop: Object 34128)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `0`.
- **`obj[11]` (Prop: Object 34128)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `32`.
- **`obj[12]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(0, 0)` with state parameter `4`.
- **`obj[13]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(0, 0)` with state parameter `5`.


#### Complete Bytecode Script Catalog (36 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Always Passes (Unconditional) | Make obj[68] Hidden (disp = 0); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #90; Engine Action #90; Engine Action #90; Play CD / Ambient BGM Track (9); Open Dialogue Message Window; Engine Action #90; Engine Action #90; Engine Action #90; Play CD / Ambient BGM Track (8); Open Dialogue Message Window; Engine Action #90; Engine Action #90; Engine Action #90; Play CD / Ambient BGM Track (10); Open Dialogue Message Window; Engine Action #90; Engine Action #90; Engine Action #90; Play CD / Ambient BGM Track (11); Open Dialogue Message Window; Engine Action #90; Engine Action #90; Engine Action #90; Play CD / Ambient BGM Track (12); Open Dialogue Message Window; Engine Action #90; Engine Action #90; Engine Action #90; Play CD / Ambient BGM Track (13); Open Dialogue Message Window; Engine Action #90; Engine Action #90; Engine Action #90; Play CD / Ambient BGM Track (14); Open Dialogue Message Window; Engine Action #90; Engine Action #90; Engine Action #90; Play CD / Ambient BGM Track (16); Open Dialogue Message Window; Engine Action #90; Engine Action #90; Engine Action #90; Play CD / Ambient BGM Track (17); Open Dialogue Message Window; Engine Action #90; Engine Action #90; Engine Action #90; Play CD / Ambient BGM Track (18); Open Dialogue Message Window; Engine Action #90; Engine Action #90; Engine Action #90; Play CD / Ambient BGM Track (19); Open Dialogue Message Window; Engine Action #90; Engine Action #90; Engine Action #90; Teleport obj[255] to (254,255) |
| `ev[01]` | `2 (Map Init)` | Always Passes (Unconditional) | Jump to Bytecode Offset (5, 52) |
| `ev[02]` | `2 (Map Init)` | Story Flag 0 (bit 128) CLEAR | Jump to Bytecode Offset (0, 55) |
| `ev[03]` | `2 (Map Init)` | Story Flag 0 (bit 128) CLEAR | Dismiss Emotion Bubble (0); Open Dialogue Message Window |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [114..115, 2..116] AND Condition Check #125 AND Story Flag 3 (mask 255) SET | Warp Room -> Submap 0 at (0,0); Set Special Scene BGM (1); Warp Map Transition (3, 0, 3, 21, 255) |
| `ev[05]` | `1 (Action / Talk)` | Player within Box [116..116, 2..121] AND Condition Check #121 AND Story Flag 2 (mask 3) SET AND Player Y within Range [4..4] AND Player Y within Range [8..255] | Recruit Character into Active Party (36, 128); Engine Action #61; Warp Room -> Submap 5 at (0,4) facing 5; Warp Town -> Area 12 Map 30 Submap 61 at (0,2); Engine Action #54; Open Dialogue Message Window; Engine Action #128; Engine Action #58 |
| `ev[06]` | `128 (Loop)` | Story Flag 2 (bit 4) SET AND Story Flag 2 (bit 8) CLEAR AND Inventory Holds Item #128 | Close Dialogue Window; Warp Room -> Submap 40 at (37,128) facing 255 |
| `ev[07]` | `1 (Action / Talk)` | Player within Box [108..109, 2..114] AND Condition Check #127 AND Story Flag 3 (mask 3) SET AND Player Y within Range [4..4] AND Player Y within Range [8..255] | Recruit Character into Active Party (33, 1); Engine Action #80; Make obj[68] Hidden (disp = 0); Warp Room -> Submap 90 at (90,90) facing South (Down); Warp Room -> Submap 5 at (1,4) facing 5; Warp to Castle HQ (3, 0, 0); Engine Action #5; Engine Action #5; Warp Town -> Area 0 Map 30 Submap 24 at (1,1); Branch on Choice (49, 2); Engine Action #5; Open Dialogue Message Window; Exit to World Map (4, 5, 8); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Exit to World Map (2, 2, 30); Engine Action #5; Warp Room -> Submap 5 at (2,2) facing 30; Warp Room -> Submap 255 at (254,50) facing 34; Engine Action #58 |
| `ev[08]` | `1 (Action / Talk)` | Player within Box [36..62, 2..28] AND Condition Check #30 AND Story Flag 0 (bit 128) SET AND Story Flag 2 (bit 1) CLEAR AND Story Flag 2 (bit 8) CLEAR | Recruit Character into Active Party (43, 0); Exit to World Map (55, 0, 47); Fade Out to Black (8); Return to Previous Memory Map (1); Engine Action #80; Make obj[68] Hidden (disp = 0); Warp Room -> Submap 90 at (90,90) facing South (Down); Warp Room -> Submap 5 at (1,4) facing 5; Warp Room -> Submap 2 at (2,1) facing South (Down); Engine Action #5; Dismiss Emotion Bubble (30); Engine Action #102; Open Dialogue Message Window; Make obj[2] Hidden (disp = 0); Show Dialogue Portrait (45, 26, 89); Show Dialogue Portrait (2, 2, 68); Show Dialogue Portrait (0, 90, 90); Engine Action #90; Open Dialogue Message Window; Show Dialogue Portrait (1, 1, 2); Reset Camera Tracking (47); Turn obj[3] facing 8; Warp Room -> Submap 8 at (0,30) facing 30; Dismiss Emotion Bubble (0); Reset Camera Tracking (2); Close Dialogue Window; Make obj[49] Visible (disp = 1); Warp to Castle HQ (11, 1, 68); Close Dialogue Window; Open Dialogue Message Window; Dismiss Emotion Bubble (30); Dismiss Emotion Bubble (0); Close Dialogue Window; Warp Town -> Area 12 Map 49 Submap 49 at (3,12); Warp Room -> Submap 12 at (0,30) facing 30; Dismiss Emotion Bubble (0); Display Dialogue Box [Bank: 2, MsgID: 13]; Make obj[52] Visible (disp = 1); Warp to Castle HQ (13, 1, 68); Place Scenery Structure (0); Dismiss Emotion Bubble (30); Dismiss Emotion Bubble (0); Place Scenery Structure (2); Animate Door Open; Set Entity Movement Speed (52, 3); Animate Door Open; Warp Room -> Submap 14 at (0,30) facing 30; Dismiss Emotion Bubble (0); Animate Door Open; Warp Town -> Area 10 Map 47 Submap 48 at (3,10); Warp Room -> Submap 10 at (0,30) facing 30; Dismiss Emotion Bubble (0); Screen Fade Transition (47, 89, 15); Engine Action #5; Engine Action #89; Show Dialogue Portrait (5, 73, 30); Load Sound Bank into Memory (1, 15); Engine Action #9; Set Combat Battle BGM (60); Load Sound Bank into Memory (0, 15); Set Combat Battle BGM (15); Engine Action #89; Show Dialogue Portrait (2, 3, 89); Show Dialogue Portrait (5, 89, 15); Engine Action #5; Engine Action #89; Show Dialogue Portrait (2, 4, 89); Show Dialogue Portrait (5, 89, 15); Engine Action #5; Make obj[0] Hidden (disp = 0); Warp Room -> Submap 15 at (47,101) facing 9; Reset Camera Tracking (5); Warp Room -> Submap 5 at (3,0) facing 5; Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 24, 1); Warp Room -> Submap 73 at (30,24) facing 8; Open Dialogue Message Window; Recruit Character into Active Party (101, 7); Warp Room -> Submap 4 at (49,7) facing 5; Open Dialogue Message Window; Engine Action #5; Walk obj[2] to (0,5); Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Warp Room -> Submap 30 at (4,3) facing South (Down); Warp Room -> Submap 255 at (254,5) facing 8; Exit to World Map (4, 1, 10); Dismiss Emotion Bubble (255); Engine Action #5; Close Dialogue Window; Engine Action #5; Dismiss Emotion Bubble (4); Exit to World Map (1, 10, 30); Engine Action #5; Display Dialogue Box [Bank: 5, MsgID: 35]; Exit to World Map (4, 1, 10); Dismiss Emotion Bubble (255); Engine Action #5; Place Scenery Structure (5); Engine Action #40; Exit to World Map (4, 1, 10); Dismiss Emotion Bubble (255); Engine Action #5; Animate Door Open; Engine Action #5; Make obj[4] Visible (disp = 1); Exit to World Map (1, 10, 30); Walk obj[24] to (1,0); Engine Action #58; Set Combat Battle BGM (15); Jump to Bytecode Offset (1, 0); Make Object Hidden (disp = 0) (1); Warp Town -> Area 10 Map 0 Submap 59 at (5,8); Engine Action #6; Warp Room -> Submap 5 at (2,0) facing 5; Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Screen Fade Transition (30, 24, 8); Open Dialogue Message Window; Trigger Character Emotion Effect (49, 4); Engine Action #5; Close Dialogue Window; Engine Action #5; Screen Fade Transition (3, 0, 5); Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Display Dialogue Box [Bank: 5, MsgID: 15]; Warp Town -> Area 0 Map 5 Submap 5 at (0,0); Dismiss Emotion Bubble (255); Engine Action #5; Place Scenery Structure (5); Branch on Choice (3, 0); Engine Action #5; Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Animate Door Open; Engine Action #5; Engine Action #5; Warp Town -> Area 0 Map 5 Submap 5 at (0,0); Dismiss Emotion Bubble (255); Walk obj[36] to (1,36); Reset Camera Tracking (49); Engine Action #6; Engine Action #5; Screen Fade Transition (4, 3, 1); Display Dialogue Box [Bank: 30, MsgID: 255]; Engine Action #5; Reset Camera Tracking (4); Exit to World Map (5, 60, 2); Open Dialogue Message Window; Pan Camera (3, 30, 255); Engine Action #5; Close Dialogue Window; Exit to World Map (5, 3, 0); Engine Action #5; Show Dialogue Portrait (7, 2, 5); Make obj[1] Visible (disp = 1); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Display Dialogue Box [Bank: 4, MsgID: 5]; Warp Town -> Area 0 Map 5 Submap 15 at (7,2); Engine Action #5; Make obj[1] Visible (disp = 1); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Place Scenery Structure (4); Engine Action #5; Warp to Castle HQ (0, 5, 15); Pan Camera (2, 5, 45); Warp Room -> Submap 30 at (255,254) facing 5; Animate Door Open; Exit to World Map (5, 2, 0); Engine Action #5; Show Dialogue Portrait (7, 2, 5); Make obj[1] Visible (disp = 1); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Walk obj[24] to (1,0); Engine Action #61; Set Combat Battle BGM (15); Close Dialogue Sub-Window (10); Open Dialogue Message Window; Engine Action #62; Load Sound Bank into Memory (1, 8); Engine Action #9; Close Dialogue Sub-Window (8); Open Dialogue Message Window; Engine Action #63; Load Sound Bank into Memory (0, 8); Set Combat Battle BGM (20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 0 Map 64 Submap 0 at (65,5); Reset Camera Tracking (5); Show Dialogue Portrait (1, 0, 5); Screen Fade Transition (30, 41, 2); Open Dialogue Message Window; Warp Room -> Submap 0 at (24,8) facing South (Down); Engine Action #66; Engine Action #51; Warp Town -> Area 255 Map 1 Submap 24 at (10,0); Open Shop Interface #73; Show Dialogue Portrait (24, 8, 0); Play CD / Ambient BGM Track (255); Warp Town -> Area 73 Map 30 Submap 24 at (1,0); Wait for Audio / Window Sync (73); Show Dialogue Portrait (24, 8, 0); Recruit Kahn Marley into Battle Slot 2; Engine Action #44; Set Entity Movement Speed (7, 5); Open Dialogue Message Window; Engine Action #5; Dismiss Emotion Bubble (6); Warp Room -> Submap 255 at (254,5) facing West (Left); Engine Action #5; Dismiss Emotion Bubble (6); Warp Room -> Submap 255 at (254,5) facing 8; Engine Action #5; Dismiss Emotion Bubble (4); Engine Action #5; Warp Town -> Area 0 Map 7 Submap 4 at (5,20); Warp Room -> Submap 30 at (255,254) facing 5; Close Dialogue Window; Engine Action #5; Make obj[4] Visible (disp = 1); Engine Action #6; Warp Room -> Submap 3 at (0,30) facing 255; Engine Action #5; Display Dialogue Box [Bank: 5, MsgID: 48]; Exit to World Map (6, 1, 5); Warp Town -> Area 1 Map 1 Submap 7 at (2,1); Dismiss Emotion Bubble (255); Engine Action #5; Place Scenery Structure (5); Make obj[4] Hidden (disp = 0); Engine Action #6; Warp Room -> Submap 3 at (2,1) facing 7; Dismiss Emotion Bubble (255); Engine Action #5; Animate Door Open; Engine Action #5; Teleport obj[4] to (6,1); Pan Camera (2, 4, 1); Pan Camera (30, 255, 254); Walk obj[69] to (2,102); Warp Room -> Submap 37 at (254,9) facing Up (North); Reset Camera Tracking (47); Engine Action #83; Warp Room -> Submap 102 at (0,101) facing West (Left); Open Dialogue Message Window; Return Warp to Castle Base (29, 7); Set Entity Movement Speed (2, 5); Open Dialogue Message Window; Exit to World Map (7, 0, 4); Warp Town -> Area 10 Map 3 Submap 0 at (30,255); Engine Action #5; Reset Camera Tracking (4); Pan Camera (1, 5, 2); Warp to Castle HQ (30, 255, 254); Walk obj[46] to (1,10); Warp Room -> Submap 1 at (12,1) facing 13; Warp Room -> Submap 2 at (9,34) facing 31; Warp to Castle HQ (9, 3, 0); Engine Action #9; Teleport obj[11] to (1,2); Trigger Character Emotion Effect (58, 255) |
| `ev[09]` | `128 (Loop)` | Story Flag 0 (bit 128) SET AND Story Flag 2 (bit 1) CLEAR AND Story Flag 2 (bit 8) CLEAR AND Inventory Holds Item #1 | Engine Action #44; Display Chapter Text (0); Pan Camera (4, 37, 1) |
| `ev[10]` | `128 (Loop)` | Story Flag 0 (bit 128) SET AND Story Flag 2 (bit 1) CLEAR AND Story Flag 2 (bit 8) CLEAR AND Inventory Holds Item #2 | Engine Action #5; Screen Fade Transition (4, 3, 3); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Open Dialogue Message Window; Pan Camera (30, 37, 2) |
| `ev[11]` | `128 (Loop)` | Story Flag 0 (bit 128) SET AND Story Flag 2 (bit 1) CLEAR AND Story Flag 2 (bit 8) CLEAR AND Inventory Holds Item #4 | Set Combat Battle BGM (60); Play CD / Ambient BGM Track (8); Mark NPC Talk Interaction Complete (Flag #90); Engine Action #90; Engine Action #90; Toggle Random Encounters (4) |
| `ev[12]` | `128 (Loop)` | Story Flag 0 (bit 128) SET AND Story Flag 2 (bit 1) CLEAR AND Story Flag 2 (bit 8) CLEAR AND Inventory Holds Item #4 | Set Combat Battle BGM (80); Play CD / Ambient BGM Track (11); Mark NPC Talk Interaction Complete (Flag #90); Engine Action #90; Engine Action #90; Toggle Random Encounters (4) |
| `ev[13]` | `128 (Loop)` | Story Flag 0 (bit 128) SET AND Story Flag 2 (bit 1) CLEAR AND Story Flag 2 (bit 8) CLEAR AND Inventory Holds Item #4 | Set Combat Battle BGM (80); Play CD / Ambient BGM Track (12); Mark NPC Talk Interaction Complete (Flag #90); Engine Action #90; Engine Action #90; Toggle Random Encounters (4) |
| `ev[14]` | `128 (Loop)` | Story Flag 0 (bit 128) SET AND Story Flag 2 (bit 1) CLEAR AND Story Flag 2 (bit 8) CLEAR AND Inventory Holds Item #4 | Set Combat Battle BGM (80); Play CD / Ambient BGM Track (13); Mark NPC Talk Interaction Complete (Flag #90); Engine Action #90; Engine Action #90; Toggle Random Encounters (4) |
| `ev[15]` | `128 (Loop)` | Story Flag 0 (bit 128) SET AND Story Flag 2 (bit 1) CLEAR AND Story Flag 2 (bit 8) CLEAR AND Inventory Holds Item #4 | Set Combat Battle BGM (80); Play CD / Ambient BGM Track (14); Mark NPC Talk Interaction Complete (Flag #90); Engine Action #90; Engine Action #90; Toggle Random Encounters (4) |
| `ev[16]` | `128 (Loop)` | Story Flag 0 (bit 128) SET AND Story Flag 2 (bit 1) CLEAR AND Story Flag 2 (bit 8) CLEAR AND Inventory Holds Item #8 | Set Combat Battle BGM (100); Play CD / Ambient BGM Track (10); Mark NPC Talk Interaction Complete (Flag #90); Engine Action #90; Engine Action #90; Toggle Random Encounters (8) |
| `ev[17]` | `1 (Action / Talk)` | Player within Box [33..37, 2..28] AND Condition Check #37 AND Story Flag 2 (bit 1) SET AND Story Flag 2 (bit 8) CLEAR | Recruit Character into Active Party (43, 0); Exit to World Map (55, 0, 39); Warp Room -> Submap 9 at (5,0); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Engine Action #5; Dismiss Emotion Bubble (33); Warp Room -> Submap 46 at (68,1) facing South (Down); Engine Action #90; Engine Action #90; Engine Action #90; Open Dialogue Message Window; Warp Room -> Submap 49 at (2,5) facing South (Down); Warp Town -> Area 0 Map 30 Submap 255 at (254,5); Warp Room -> Submap 5 at (2,3) facing South (Down); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp to Castle HQ (0, 5, 10); Dismiss Emotion Bubble (255); Walk obj[46] to (2,8); Engine Action #51; Engine Action #54; Warp to Castle HQ (8, 1, 0); Reset Camera Tracking (2); Close Dialogue Window; Engine Action #52; Engine Action #53; Warp to Castle HQ (11, 1, 0); Close Dialogue Window; Warp Town -> Area 12 Map 53 Submap 55 at (3,12); Warp Room -> Submap 12 at (2,13) facing 54; Engine Action #53; Warp to Castle HQ (13, 1, 0); Place Scenery Structure (2); Animate Door Open; Set Render Priority (pri) (55, 3); Animate Door Open; Warp Room -> Submap 14 at (47,24) facing West (Left); Open Dialogue Message Window; Launch Tactical War Battle (73); Show Dialogue Portrait (36, 1, 24); Reset Camera Tracking (0); Toggle Random Encounters (54); Open Dialogue Message Window; Warp Room -> Submap 6 at (5,0) facing 5; Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp to Castle HQ (0, 30, 255); Engine Action #5; Reset Camera Tracking (4); Exit to World Map (1, 23, 5); Engine Action #5; Warp Town -> Area 1 Map 30 Submap 255 at (254,5); Close Dialogue Window; Engine Action #5; Dismiss Emotion Bubble (4); Exit to World Map (1, 23, 2); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Display Dialogue Box [Bank: 5, MsgID: 40]; Exit to World Map (4, 1, 23); Warp Town -> Area 0 Map 30 Submap 255 at (254,5); Place Scenery Structure (5); Dismiss Emotion Bubble (4); Exit to World Map (1, 23, 2); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Animate Door Open; Engine Action #5; Engine Action #40; Exit to World Map (4, 1, 23); Warp Town -> Area 0 Map 30 Submap 255 at (254,50); Engine Action #5; Warp Room -> Submap 2 at (7,1) facing 30; Close Dialogue Sub-Window (1); Open Dialogue Message Window; Open Save Crystal Menu (MSaveInit); Set Combat Battle BGM (15); Close Dialogue Sub-Window (8); Open Dialogue Message Window; Engine Action #39; Set Combat Battle BGM (10); Set Entity Movement Speed (5, 5); Close Dialogue Window; Exit to World Map (6, 2, 16); Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Display Dialogue Box [Bank: 4, MsgID: 6]; Warp Town -> Area 17 Map 1 Submap 0 at (30,255); Engine Action #5; Place Scenery Structure (4); Engine Action #6; Engine Action #5; Engine Action #5; Warp Town -> Area 16 Map 0 Submap 0 at (30,255); Engine Action #5; Animate Door Open; Exit to World Map (6, 5, 5); Warp Town -> Area 17 Map 1 Submap 0 at (30,255); Engine Action #5; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (4, 5, 7); Warp Town -> Area 30 Map 255 Submap 254 at (50,102); Warp Room -> Submap 9 at (2,8) facing 37; Teleport obj[83] to (1,2); Return Warp to Castle Base (43, 0); Pan Camera (4, 0, 37); Warp Room -> Submap 9 at (46,102); Open Dialogue Message Window; Jump to Bytecode Offset (1, 0); Warp to Castle HQ (0, 3, 2); Engine Action #9; Return Warp to Castle Base (31, 3); Engine Action #9; Warp to Castle HQ (0, 9, 2); Reset Camera Tracking (51); Warp Room -> Submap 3 at (8,2); Open Dialogue Message Window; Reset Camera Tracking (1); Close Dialogue Window; Warp Room -> Submap 1 at (13,1) facing 14; Teleport obj[11] to (1,2); Trigger Character Emotion Effect (58, 255) |
| `ev[18]` | `128 (Loop)` | Story Flag 2 (bit 1) SET AND Story Flag 2 (bit 8) CLEAR AND Inventory Holds Item #1 | Make obj[72] Hidden (disp = 0); Warp Room -> Submap 6 at (72,1) facing West (Left); Engine Action #6; Teleport obj[44] to (49,2); Engine Action #5; Open Dialogue Message Window; Engine Action #6; Warp Room -> Submap 255 at (254,5) facing West (Left); Engine Action #6; Warp Room -> Submap 255 at (254,50) facing 45; Make obj[72] Hidden (disp = 0); Open Dialogue Message Window; Open Dialogue Message Window; Load Sound Bank into Memory (0, 1); Teleport obj[37] to (1,255) |
| `ev[19]` | `1 (Action / Talk)` | Player within Box [37..37, 2..31] AND Condition Check #31 AND Story Flag 3 (mask 3) SET AND Player Y within Range [8..4] AND Player Y within Range [16..255] | Recruit Character into Active Party (5, 8); Exit to World Map (4, 2, 2); Engine Action #5; Engine Action #5; Dismiss Emotion Bubble (24); Reset Camera Tracking (0); Engine Action #40; Engine Action #5; Reset Camera Tracking (5); Show Dialogue Portrait (0, 0, 5); Engine Action #5; Exit to World Map (6, 0, 23); Engine Action #5; Show Dialogue Portrait (30, 1, 8); Launch Tactical War Battle (4); Close Dialogue Sub-Window (9); Warp Room -> Submap 54 at (0,4) facing 5; Engine Action #9; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp to Castle HQ (0, 5, 10); Dismiss Emotion Bubble (73); Branch on Choice (40, 0); Open Dialogue Message Window; Warp Town -> Area 0 Map 42 Submap 0 at (47,73); Show Dialogue Portrait (41, 2, 0); Exit to World Map (255, 0, 24); Engine Action #9; Open Dialogue Message Window; Open Shop Menu #15 (Type: 73); Set Combat Battle BGM (20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 0 Map 42 Submap 0 at (47,73); Show Dialogue Portrait (41, 2, 1); Exit to World Map (255, 1, 24); Engine Action #9; Open Dialogue Message Window; Engine Action #44; Set Combat Battle BGM (15); Set Combat Battle BGM (20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 0 Map 42 Submap 0 at (47,73); Show Dialogue Portrait (41, 2, 2); Exit to World Map (255, 2, 24); Engine Action #9; Open Dialogue Message Window; Make obj[73] Visible (disp = 1); Show Dialogue Portrait (73, 20, 40); Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 0 Map 47 Submap 0 at (42,73); Show Dialogue Portrait (41, 2, 4); Warp to Castle HQ (255, 3, 36); Warp Room -> Submap 8 at (5,8) facing 4; Engine Action #6; Warp Room -> Submap 5 at (5,4) facing 4; Warp Town -> Area 1 Map 5 Submap 5 at (30,5); Open Dialogue Message Window; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp to Castle HQ (0, 30, 54); Warp Room -> Submap 24 at (8,0) facing 46; Set Entity Movement Speed (5, 5); Open Dialogue Message Window; Exit to World Map (5, 7, 2); Dismiss Emotion Bubble (255); Engine Action #5; Close Dialogue Window; Exit to World Map (6, 5, 15); Warp Town -> Area 13 Map 0 Submap 1 at (2,0); Dismiss Emotion Bubble (255); Engine Action #5; Display Dialogue Box [Bank: 4, MsgID: 6]; Engine Action #5; Screen Fade Transition (2, 17, 1); Warp Room -> Submap 255 at (254,5) facing 13; Exit to World Map (6, 5, 10); Warp Town -> Area 10 Map 0 Submap 2 at (2,6); Dismiss Emotion Bubble (255); Engine Action #5; Animate Door Open; Exit to World Map (6, 5, 5); Warp Town -> Area 18 Map 1 Submap 1 at (30,255); Walk obj[69] to (2,102); Warp Room -> Submap 2 at (64,83) facing West (Left); Warp Town -> Area 5 Map 0 Submap 4 at (7,3); Warp Town -> Area 30 Map 46 Submap 102 at (0,101); Warp Room -> Submap 1 at (11,1) facing 12; Warp Room -> Submap 1 at (14,2) facing 9; Return Warp to Castle Base (31, 3); Engine Action #9; Warp to Castle HQ (0, 9, 2); Reset Camera Tracking (51); Warp Room -> Submap 3 at (8,2); Open Dialogue Message Window; Reset Camera Tracking (3); Open Dialogue Message Window; Warp to Castle HQ (37, 254, 47); Close Dialogue Window; Warp Room -> Submap 60 at (255,254) facing 255; Exit to World Map (24, 9, 0); Turn obj[5] facing 9; Engine Action #5; Show Dialogue Portrait (4, 4, 3); Warp Room -> Submap 0 at (30,37) facing 254; Engine Action #80; Engine Action #9; Warp Town -> Area 16 Map 255 Submap 254 at (255,254) |
| `ev[20]` | `128 (Loop)` | Story Flag 2 (bit 8) SET AND Story Flag 2 (bit 16) CLEAR AND Inventory Holds Item #1 AND Temp Event Flag #2 SET | Make obj[2] Hidden (disp = 0); Close Dialogue Window; Walk obj[52] to (3,11); Warp Room -> Submap 11 at (2,12) facing 50; Set Animation Pose (3, 12); Warp Room -> Submap 12 at (2,13) facing 53; Engine Action #52; Warp to Castle HQ (13, 1, 0); Place Scenery Structure (2); Animate Door Open; Engine Action #53; Set Animation Pose (3, 14); Warp Room -> Submap 14 at (47,49) facing 4; Engine Action #5; Close Dialogue Window; Exit to World Map (5, 5, 5); Warp Room -> Submap 5 at (5,2) facing South (Down); Dismiss Emotion Bubble (255); Engine Action #5; Display Dialogue Box [Bank: 4, MsgID: 5]; Engine Action #5; Show Dialogue Portrait (1, 23, 5); Engine Action #5; Warp Town -> Area 0 Map 30 Submap 255 at (254,5); Place Scenery Structure (4); Engine Action #5; Engine Action #5; Engine Action #5; Warp Room -> Submap 5 at (5,2) facing South (Down); Dismiss Emotion Bubble (255); Engine Action #5; Animate Door Open; Exit to World Map (5, 5, 15); Warp Room -> Submap 5 at (5,2) facing South (Down); Dismiss Emotion Bubble (255); Walk obj[36] to (2,255) |
| `ev[21]` | `128 (Loop)` | Story Flag 2 (bit 8) SET AND Story Flag 2 (bit 16) CLEAR AND Inventory Holds Item #4 | Engine Action #5; Engine Action #9; Exit to World Map (3, 3, 0); Pan Camera (1, 30, 5); Open Dialogue Message Window; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp Town -> Area 0 Map 30 Submap 81 at (1,1); Engine Action #5; Engine Action #9; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp Town -> Area 0 Map 30 Submap 37 at (4,255) |
| `ev[22]` | `1 (Action / Talk)` | Player within Box [37..37, 2..31] AND Condition Check #31 AND Story Flag 2 (mask 3) SET AND Player Y within Range [16..4] AND Player Y within Range [32..255] | Recruit Character into Active Party (36, 1); Set Combat Battle BGM (30); Make obj[2] Hidden (disp = 0); Dismiss Dialogue Portrait; Return Warp to Castle Base (31, 89); Dismiss Dialogue Portrait; Warp Town -> Area 0 Map 0 Submap 16 at (1,9); Teleport obj[36] to (4,89); Dismiss Dialogue Portrait; Engine Action #5; Engine Action #89; Dismiss Dialogue Portrait; Engine Action #5; Make obj[2] Hidden (disp = 0); Branch on Choice (32, 28); Open Dialogue Message Window; Branch on Choice (0, 9); Warp Room -> Submap 47 at (5,9) facing 5; Dismiss Emotion Bubble (3); Open Dialogue Message Window; Exit to World Map (4, 7, 2); Engine Action #5; Show Dialogue Portrait (30, 24, 9); Open Dialogue Message Window; Set Entity Movement Speed (73, 20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 0 Map 50 Submap 0 at (52,41); Warp Town -> Area 0 Map 1 Submap 255 at (0,9); Engine Action #5; Engine Action #128; Set Entity Movement Speed (2, 5); Open Dialogue Message Window; Exit to World Map (4, 5, 6); Warp Town -> Area 3 Map 1 Submap 0 at (5,30); Dismiss Emotion Bubble (255); Engine Action #5; Engine Action #9; Exit to World Map (4, 7, 1); Dismiss Emotion Bubble (255); Walk obj[46] to (2,17); Return Warp to Castle Base (31, 89); Change Portrait Expression (2); Open Dialogue Message Window; Open Dialogue Message Window; Change Portrait Expression (1); Open Dialogue Message Window; Teleport obj[36] to (16,89); Change Portrait Expression (5); Engine Action #89; Change Portrait Expression (5); Make obj[1] Hidden (disp = 0); Branch on Choice (2, 21); Warp Map Transition (28, 0, 21, 0, 0); Warp Room -> Submap 47 at (5,0) facing 5; Dismiss Emotion Bubble (2); Open Dialogue Message Window; Exit to World Map (4, 7, 2); Engine Action #5; Show Dialogue Portrait (30, 24, 9); Open Dialogue Message Window; Engine Action #51; Engine Action #5; Engine Action #9; Engine Action #5; Show Dialogue Portrait (0, 0, 5); Engine Action #5; Warp Town -> Area 0 Map 30 Submap 49 at (2,5); Open Dialogue Message Window; Exit to World Map (4, 2, 11); Open Dialogue Message Window; Warp to Castle HQ (2, 3, 30); Engine Action #5; Engine Action #9; Exit to World Map (4, 2, 8); Open Dialogue Message Window; Warp Town -> Area 2 Map 2 Submap 30 at (255,254); Walk obj[51] to (2,255); Warp Room -> Submap 9 at (0,53) facing 5; Engine Action #9; Engine Action #5; Show Dialogue Portrait (4, 4, 3); Warp Town -> Area 1 Map 0 Submap 5 at (30,30); Make obj[2] Hidden (disp = 0); Dismiss Dialogue Portrait; Return Warp to Castle Base (31, 89); Dismiss Dialogue Portrait; Warp Town -> Area 1 Map 0 Submap 16 at (1,9); Teleport obj[36] to (16,89); Dismiss Dialogue Portrait; Engine Action #5; Engine Action #89; Dismiss Dialogue Portrait; Engine Action #5; Make obj[1] Hidden (disp = 0); Branch on Choice (2, 21); Warp Map Transition (28, 0, 21, 0, 9); Warp Room -> Submap 47 at (5,9) facing 5; Dismiss Emotion Bubble (3); Open Dialogue Message Window; Engine Action #5; Dismiss Emotion Bubble (0); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp Town -> Area 0 Map 5 Submap 15 at (30,49); Warp Town -> Area 5 Map 0 Submap 4 at (4,2); Display Dialogue Box [Bank: 0, MsgID: 3]; Warp Town -> Area 3 Map 30 Submap 255 at (254,5); Engine Action #9; Exit to World Map (4, 2, 11); Open Dialogue Message Window; Warp Town -> Area 2 Map 2 Submap 30 at (255,254); Walk obj[255] to (2,46); Warp Town -> Area 18 Map 21 Submap 33 at (89,18); Warp Town -> Area 0 Map 0 Submap 18 at (1,9); Warp Room -> Submap 47 at (89,18) facing 5; Engine Action #89; Display Speaker Name Box (5); Jump to Bytecode Offset (9, 8); Engine Action #89; Display Speaker Name Box (2); Warp Room -> Submap 18 at (5,89) facing 18; Engine Action #5; Jump to Bytecode Offset (0, 50); Make obj[2] Hidden (disp = 0); Display Choice Selection (21, 33); Open Dialogue Message Window; Display Choice Selection (1, 18); Engine Action #89; Display Choice Selection (2, 2); Teleport obj[90] to (19,4); Exit to World Map (11, 2, 30); Engine Action #89; Display Choice Selection (2, 3); Launch Tactical War Battle (64); Engine Action #90; Display Choice Selection (4, 4); Show Dialogue Portrait (3, 30, 44); Engine Action #54; Warp Room -> Submap 54 at (1,2) facing 101; Open Dialogue Message Window; Set Entity Movement Speed (73, 150); Engine Action #117; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #80; Set Special Scene BGM (1); Wait for Audio / Window Sync (3); Engine Action #9; Warp Town -> Area 32 Map 13 Submap 7 at (0,3); Engine Action #250; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #58 |
| `ev[23]` | `128 (Loop)` | Story Flag 2 (bit 16) SET AND Story Flag 2 (bit 32) CLEAR AND Inventory Holds Item #1 AND Temp Event Flag #2 SET | Warp Room -> Submap 0 at (0,12); Launch Tactical War Battle (2) |
| `ev[24]` | `128 (Loop)` | Story Flag 2 (bit 16) SET AND Story Flag 2 (bit 32) CLEAR AND Inventory Holds Item #4 AND Temp Event Flag #8 SET | Set Combat Battle BGM (36); Jump to Bytecode Offset (0, 51); Launch Tactical War Battle (8) |
| `ev[25]` | `128 (Loop)` | Story Flag 2 (bit 16) SET AND Story Flag 2 (bit 32) CLEAR AND Inventory Holds Item #16 AND Temp Event Flag #32 SET | Set Combat Battle BGM (38); Jump to Bytecode Offset (0, 51); Launch Tactical War Battle (32) |
| `ev[26]` | `128 (Loop)` | Inventory Holds Item #64 AND Temp Event Flag #128 SET | Set Combat Battle BGM (30); Engine Action #44; Display Chapter Text (0); Branch on Choice (5, 255) |
| `ev[27]` | `128 (Loop)` | Inventory Holds Item #64 AND Temp Event Flag #128 SET | Set Combat Battle BGM (50); Close Dialogue Window; Warp Town -> Area 2 Map 100 Submap 36 at (128,255) |
| `ev[28]` | `128 (Loop)` | Story Flag 2 (bit 64) SET AND Story Flag 2 (bit 128) CLEAR AND Condition Check #30 AND Always Passes (Unconditional) AND Player X within Range [255..254] | Screen Fade Transition (2, 64, 99); Open Dialogue Message Window; Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[29]` | `128 (Loop)` | Story Flag 2 (bit 64) SET AND Story Flag 2 (bit 128) CLEAR AND Condition Check #29 AND Always Passes (Unconditional) AND Player within Box [30..0, 2..255] | Screen Fade Transition (2, 64, 46); Mark NPC Talk Interaction Complete (Flag #0); Warp Room -> Submap 0 at (2,47) facing 255 |
| `ev[30]` | `128 (Loop)` | Story Flag 2 (bit 64) SET AND Story Flag 2 (bit 128) CLEAR AND Condition Check #29 AND Always Passes (Unconditional) AND Player within Box [29..0, 2..30] AND Always Passes (Unconditional) AND Story Flag 255 (bit 254) CLEAR | Screen Fade Transition (2, 64, 46); Mark NPC Talk Interaction Complete (Flag #0); Warp Room -> Submap 0 at (2,99) facing South (Down); Exit to World Map (47, 255, 254) |
| `ev[31]` | `128 (Loop)` | Story Flag 2 (bit 64) SET AND Story Flag 2 (bit 128) CLEAR AND Condition Check #29 AND Always Passes (Unconditional) AND Player within Box [29..0, 2..29] AND Always Passes (Unconditional) AND Story Flag 30 (bit 0) CLEAR AND Temp Event Flag #255 CLEAR | Screen Fade Transition (2, 64, 46); Mark NPC Talk Interaction Complete (Flag #0); Warp Room -> Submap 0 at (2,100) facing South (Down); Exit to World Map (99, 0, 8); Teleport obj[255] to (254,255) |
| `ev[32]` | `128 (Loop)` | Story Flag 2 (bit 64) SET AND Story Flag 2 (bit 128) CLEAR AND Condition Check #29 AND Always Passes (Unconditional) AND Player within Box [29..0, 2..29] AND Always Passes (Unconditional) AND Story Flag 29 (bit 0) CLEAR AND Temp Event Flag #30 CLEAR AND Always Passes (Unconditional) AND Star of Destiny #255 Recruited | Screen Fade Transition (2, 64, 46); Mark NPC Talk Interaction Complete (Flag #0); Warp Room -> Submap 0 at (2,100) facing South (Down); Exit to World Map (100, 0, 8); Engine Action #99; Open Dialogue Message Window; Dismiss Dialogue Portrait; Teleport obj[255] to (254,255) |
| `ev[33]` | `128 (Loop)` | Story Flag 2 (bit 64) SET AND Story Flag 2 (bit 128) CLEAR AND Condition Check #29 AND Always Passes (Unconditional) AND Player within Box [29..0, 2..29] AND Always Passes (Unconditional) AND Story Flag 29 (bit 0) CLEAR AND Temp Event Flag #29 CLEAR AND Always Passes (Unconditional) AND Star of Destiny #30 Recruited AND Always Passes (Unconditional) AND Condition Check #32 | Screen Fade Transition (2, 64, 46); Mark NPC Talk Interaction Complete (Flag #0); Warp Room -> Submap 0 at (2,100) facing South (Down); Exit to World Map (100, 0, 8); Mark NPC Talk Interaction Complete (Flag #0); Dismiss Dialogue Portrait; Engine Action #99; Open Dialogue Message Window; Warp Map Transition (47, 255, 254, 255, 254) |
| `ev[34]` | `128 (Loop)` | Story Flag 2 (bit 64) SET AND Story Flag 2 (bit 128) CLEAR AND Condition Check #29 AND Always Passes (Unconditional) AND Player within Box [29..0, 2..29] AND Always Passes (Unconditional) AND Story Flag 29 (bit 0) CLEAR AND Temp Event Flag #29 CLEAR AND Always Passes (Unconditional) AND Star of Destiny #29 Recruited AND Always Passes (Unconditional) AND Condition Check #32 AND Condition Check #30 AND Always Passes (Unconditional) AND Condition Check #64 | Screen Fade Transition (2, 64, 46); Mark NPC Talk Interaction Complete (Flag #0); Warp Room -> Submap 0 at (2,100) facing South (Down); Exit to World Map (100, 0, 8); Mark NPC Talk Interaction Complete (Flag #0); Dismiss Dialogue Portrait; Mark NPC Talk Interaction Complete (Flag #0); Warp Map Transition (99, 0, 64, 47, 255) |
| `ev[35]` | `128 (Loop)` | Story Flag 2 (bit 128) CLEAR AND Condition Check #29 AND Always Passes (Unconditional) AND Condition Check #64 AND Condition Check #29 AND Always Passes (Unconditional) AND Condition Check #32 AND Condition Check #30 AND Always Passes (Unconditional) AND Star of Destiny #29 Recruited AND Always Passes (Unconditional) AND Temp Event Flag #29 CLEAR AND Always Passes (Unconditional) AND Story Flag 30 (bit 0) CLEAR AND Player Y within Range [30..0] AND Player X within Range [255..254] | Engine Action #9; Warp Town -> Area 128 Map 255 Submap 254 at (255,254) |

---



## Location Map: `va10`

- **Master Map Container**: `va10.json`
- **Submap Layer Files**: Embedded in master
- **Collision Grid Files**: va10_map_00.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 1

### Submap Layer `va10_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `1` Objects | **Script Count (`evkaz`)**: `1` Scripts

#### Complete Physical Entity Inventory (1 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Highland Patrol Soldier** | `80` | `(34, 31)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Highland Patrol Soldier)**: Positioned at tile `(34, 31)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.


#### Complete Bytecode Script Catalog (1 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [114..115, 2..116] AND Condition Check #125 AND Story Flag 3 (mask 255) SET | Warp Room -> Submap 1 at (0,22); Set Special Scene BGM (1); Warp Map Transition (2, 3, 3, 21, 255) |

---



## Location Map: `va11`

- **Master Map Container**: `va11.json`
- **Submap Layer Files**: va11_00.json
- **Collision Grid Files**: va11_map_00.json
- **Sprite Animation Bundles**: va11_00_obj.json
- **Submap Room Count**: 6

### Submap Layer `va11_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `2` Objects | **Script Count (`evkaz`)**: `6` Scripts

#### Complete Physical Entity Inventory (2 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 65104** | `65104` | `(16, 16)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Actor ID 65104** | `65104` | `(16, 16)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 65104)**: Positioned at tile `(16, 16)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Object 65104)**: Positioned at tile `(16, 16)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.


#### Complete Bytecode Script Catalog (6 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 22 (bit 2) CLEAR | Make obj[2] Hidden (disp = 0); Reset Camera Tracking (6); Open Dialogue Sub-Window (3); Reset Camera Tracking (3); Open Dialogue Message Window; Reset Camera Tracking (2); Engine Action #9; Engine Action #6; Fade Out to Black (3); Engine Action #9; Warp to Castle HQ (0, 9, 47) |
| `ev[01]` | `128 (Loop)` | Player within Box [4..5, 2..20] AND Condition Check #30 AND Story Flag 3 (mask 255) SET | Warp Room -> Submap 2 at (12,0) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [0..1, 2..19] AND Condition Check #30 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 116]; Full Rest & Healing (Restore HP/MP) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [60..96, 2..65] AND Condition Check #66 AND Story Flag 0 (mask 255) SET | Warp Room -> Submap 2 at (12,0); Engine Action #9; Open Dialogue Message Window; Warp Room -> Submap 0 at (0,49) facing 47 |
| `ev[04]` | `1 (Action / Talk)` | Story Flag 22 (bit 2) CLEAR AND Player within Box [14..16, 2..20] AND Condition Check #30 AND Story Flag 2 (mask 255) SET | Recruit Character into Active Party (44, 36); Warp Room -> Submap 8 at (1,8) facing South (Down); Open Dialogue Message Window; Engine Action #54; Open Dialogue Message Window; Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[05]` | `128 (Loop)` | Story Flag 22 (bit 2) CLEAR AND Inventory Holds Item #1 | Engine Action #5; Open Dialogue Message Window; Engine Action #5; Engine Action #5; Engine Action #6; Warp Room -> Submap 5 at (30,45) facing 5; Open Dialogue Message Window; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Engine Action #5; Exit to World Map (4, 3, 4); Dismiss Emotion Bubble (37); Warp Room -> Submap 254 at (255,254) facing 204 |

---

### Submap Layer `va11_01` (Index 1)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `30`, Rate: `8`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `2` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (2 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [118..119, 2..67] AND Condition Check #82 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 3]; Clear Dialogue Sub-Window |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [0..1, 2..23] AND Condition Check #38 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 80]; Engine Action #131 |

---

### Submap Layer `va11_02` (Index 2)

- **Map Number (`mapno`)**: `2`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `30`, Rate: `8`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `4` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (4 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `128 (Loop)` | Player within Box [64..65, 2..125] AND Condition Check #137 AND Story Flag 2 (mask 255) SET | Warp Room -> Submap 1 at (0,22) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [82..83, 2..123] AND Condition Check #138 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 3]; Warp Room -> Submap 255 at (254,204) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [0..1, 2..20] AND Condition Check #38 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 3, MsgID: 162]; Set Render Priority (pri) (255, 254) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [0..1, 2..87] AND Condition Check #101 AND Story Flag 2 (mask 255) SET | Warp Room -> Submap 1 at (0,22); Set Special Scene BGM (1); Warp Map Transition (2, 0, 108, 27, 255) |

---

### Submap Layer `va11_03` (Index 3)

- **Map Number (`mapno`)**: `3`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `4` Objects | **Script Count (`evkaz`)**: `7` Scripts

#### Complete Physical Entity Inventory (4 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 61520** | `61520` | `(60, 39)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Actor ID 61776** | `61776` | `(60, 39)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Actor ID 61458** | `61458` | `(31, 63)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | NPC / Actor | **Actor ID 61441** | `61441` | `(31, 63)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 61520)**: Positioned at tile `(60, 39)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Object 61776)**: Positioned at tile `(60, 39)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Object 61458)**: Positioned at tile `(31, 63)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Object 61441)**: Positioned at tile `(31, 63)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.


#### Complete Bytecode Script Catalog (7 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [164..165, 2..50] AND Condition Check #61 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 3]; Display Emotion Bubble (255, 254) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [0..1, 2..36] AND Condition Check #50 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 4, MsgID: 96]; Display Chapter Text (255) |
| `ev[02]` | `1 (Action / Talk)` | Story Flag 40 (bit 16) SET AND Story Flag 40 (bit 32) CLEAR | Recruit Character into Active Party (43, 0); Pan Camera (4, 0, 59); Display Chapter Text (9); Engine Action #44; Engine Action #5; Open Dialogue Message Window; Exit to World Map (7, 2, 10); Dismiss Emotion Bubble (46); Warp Town -> Area 11 Map 49 Submap 28 at (0,11); Warp Town -> Area 9 Map 47 Submap 29 at (1,9); Warp Town -> Area 10 Map 51 Submap 29 at (0,10); Teleport obj[36] to (8,36); Dismiss Dialogue Portrait; Close Dialogue Window; Warp Room -> Submap 120 at (36,4) facing 28; Warp to Castle HQ (50, 4, 54); Open Dialogue Message Window; Exit to World Map (54, 0, 8); Engine Action #54; Open Dialogue Message Window; Dismiss Dialogue Portrait; Engine Action #54; Open Dialogue Message Window; Warp Room -> Submap 0 at (10,102) facing South (Down); Set Object Direction (0, 1); Engine Action #157; Warp Room -> Submap 1 at (13,33); Wait for Audio / Window Sync (1); Engine Action #9; Engine Action #40; Dismiss Dialogue Portrait; Recruit Riou (Hero) into Battle Slot 1 |
| `ev[03]` | `128 (Loop)` | Story Flag 40 (bit 16) SET AND Story Flag 40 (bit 32) CLEAR AND Inventory Holds Item #4 | Set Combat Battle BGM (240); Jump to Bytecode Offset (9, 8); Close Dialogue Window; Warp Town -> Area 2 Map 120 Submap 37 at (4,255) |
| `ev[04]` | `128 (Loop)` | Story Flag 40 (bit 16) SET AND Story Flag 40 (bit 32) CLEAR AND Inventory Holds Item #8 | Launch Tactical War Battle (1); Set Entity Movement Speed (3, 5); Open Dialogue Message Window; Exit to World Map (4, 5, 2); Warp to Castle HQ (60, 30, 255); Engine Action #5; Close Dialogue Window; Exit to World Map (4, 5, 2); Warp to Castle HQ (60, 30, 255); Engine Action #5; Screen Fade Transition (4, 4, 3); Trigger Character Emotion Effect (30, 255); Walk obj[37] to (8,255) |
| `ev[05]` | `128 (Loop)` | Story Flag 40 (bit 16) SET AND Story Flag 40 (bit 32) CLEAR AND Inventory Holds Item #16 | Set Combat Battle BGM (250); Set Combat Battle BGM (15); Open Dialogue Message Window; Engine Action #9; Engine Action #5; Engine Action #9; Exit to World Map (5, 3, 60); Dismiss Emotion Bubble (37); Dismiss Dialogue Portrait |
| `ev[06]` | `128 (Loop)` | Story Flag 40 (bit 16) SET AND Story Flag 40 (bit 32) CLEAR AND Inventory Holds Item #1 | Load Sound Bank into Memory (1, 10); Engine Action #5; Toggle Random Encounters (1) |

---

### Submap Layer `va11_04` (Index 4)

- **Map Number (`mapno`)**: `4`
- **Battle Encounter Zone (`batlno`)**: `1` (Timer: `30`, Rate: `8`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `2` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (2 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [98..99, 2..20] AND Condition Check #34 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 3, MsgID: 3]; Open Shop Menu #254 (Type: 255) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [0..1, 2..67] AND Condition Check #90 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 5, MsgID: 80]; Display Emotion Bubble (255, 254) |

---

### Submap Layer `va11_05` (Index 5)

- **Map Number (`mapno`)**: `5`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `2` Objects | **Script Count (`evkaz`)**: `6` Scripts

#### Complete Physical Entity Inventory (2 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 65104** | `65104` | `(16, 16)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Actor ID 65104** | `65104` | `(16, 16)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 65104)**: Positioned at tile `(16, 16)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Object 65104)**: Positioned at tile `(16, 16)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.


#### Complete Bytecode Script Catalog (6 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 22 (bit 2) CLEAR | Make obj[2] Hidden (disp = 0); Reset Camera Tracking (19); Wait for Audio / Window Sync (3); Reset Camera Tracking (2); Open Dialogue Message Window; Reset Camera Tracking (2); Engine Action #9; Display Choice Selection (76, 3); Engine Action #9; Warp Town -> Area 0 Map 9 Submap 47 at (255,254) |
| `ev[01]` | `128 (Loop)` | Player within Box [79..80, 2..23] AND Condition Check #35 AND Story Flag 2 (mask 255) SET | Warp Room -> Submap 2 at (12,9) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [82..83, 2..22] AND Condition Check #40 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 4, MsgID: 3]; Award Potch Currency (255,254) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [0..1, 2..67] AND Condition Check #83 AND Story Flag 2 (mask 255) SET | Close Dialogue Window; Warp Town -> Area 2 Map 40 Submap 31 at (2,12); Engine Action #9; Warp to Castle HQ (0, 1, 32); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #234; Engine Action #191 |
| `ev[04]` | `1 (Action / Talk)` | Story Flag 22 (bit 2) CLEAR AND Player within Box [9..11, 2..67] AND Condition Check #82 AND Story Flag 3 (mask 255) SET | Recruit Character into Active Party (44, 36); Warp Room -> Submap 8 at (1,8) facing South (Down); Open Dialogue Message Window; Engine Action #54; Open Dialogue Message Window; Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[05]` | `128 (Loop)` | Story Flag 22 (bit 2) CLEAR AND Inventory Holds Item #1 | Engine Action #5; Open Dialogue Message Window; Engine Action #5; Engine Action #5; Engine Action #6; Warp Room -> Submap 5 at (30,45) facing 5; Open Dialogue Message Window; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Engine Action #5; Exit to World Map (4, 2, 4); Dismiss Emotion Bubble (37); Warp Room -> Submap 254 at (255,254) facing 204 |

---



## Location Map: `va12`

- **Master Map Container**: `va12.json`
- **Submap Layer Files**: Embedded in master
- **Collision Grid Files**: va12_map_00.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 1

### Submap Layer `va12_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `35` Objects | **Script Count (`evkaz`)**: `44` Scripts

#### Complete Physical Entity Inventory (35 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | World Device | **Mechanism (ano 27)** | `0` | `(66, 34)` | `0x0` | Frame 27 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 1 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 4)** | `0` | `(65, 34)` | `0x0` | Frame 4 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 1 | 0 |
| `obj[02]` | World Device | **Mechanism (ano 5)** | `0` | `(64, 34)` | `0x0` | Frame 5 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 1 | 0 |
| `obj[03]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(65, 35)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | Trigger / Hitbox | **Hitbox Zone (3x1)** | `0` | `(35, 49)` | `2x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | Trigger / Hitbox | **Hitbox Zone (1x2)** | `0` | `(41, 21)` | `0x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | Trigger / Hitbox | **Hitbox Zone (1x2)** | `0` | `(45, 20)` | `0x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Hitbox Zone (1x2)** | `0` | `(51, 21)` | `0x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Trigger / Hitbox | **Hitbox Zone (1x2)** | `0` | `(53, 21)` | `0x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(59, 21)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Trigger / Hitbox | **Hitbox Zone (1x2)** | `0` | `(64, 21)` | `0x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Trigger / Hitbox | **Hitbox Zone (1x2)** | `0` | `(67, 20)` | `0x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(69, 21)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | Trigger / Hitbox | **Hitbox Zone (1x2)** | `0` | `(79, 21)` | `0x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | Trigger / Hitbox | **Hitbox Zone (1x2)** | `0` | `(49, 34)` | `0x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[15]` | Trigger / Hitbox | **Hitbox Zone (1x2)** | `0` | `(51, 34)` | `0x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[16]` | Trigger / Hitbox | **Hitbox Zone (1x2)** | `0` | `(61, 35)` | `0x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[17]` | Trigger / Hitbox | **Hitbox Zone (1x2)** | `0` | `(32, 54)` | `0x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[18]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(63, 35)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[19]` | Trigger / Hitbox | **Hitbox Zone (1x2)** | `0` | `(67, 35)` | `0x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[20]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(69, 35)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[21]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(44, 58)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[22]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(48, 59)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[23]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(46, 62)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[24]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(42, 63)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[25]` | Trigger / Hitbox | **Hitbox Zone (1x2)** | `0` | `(27, 48)` | `0x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[26]` | Trigger / Hitbox | **Hitbox Zone (1x2)** | `0` | `(37, 56)` | `0x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[27]` | Trigger / Hitbox | **Hitbox Zone (1x2)** | `0` | `(36, 33)` | `0x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[28]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(32, 33)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[29]` | Trigger / Hitbox | **Hitbox Zone (1x2)** | `0` | `(25, 36)` | `0x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[30]` | Trigger / Hitbox | **Hitbox Zone (1x2)** | `0` | `(29, 32)` | `0x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[31]` | Trigger / Hitbox | **Hitbox Zone (1x2)** | `0` | `(25, 25)` | `0x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[32]` | Trigger / Hitbox | **Hitbox Zone (3x6)** | `0` | `(35, 24)` | `2x5` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[33]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(21, 28)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[34]` | Trigger / Hitbox | **Hitbox Zone (3x6)** | `0` | `(21, 48)` | `2x5` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(66, 34)` with state parameter `27`.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(65, 34)` with state parameter `4`.
- **`obj[02]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(64, 34)` with state parameter `5`.
- **`obj[03]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(65, 35)` to `(67, 36)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[04]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `1` tiles high from `(35, 49)` to `(37, 49)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[05]` (Hitbox Zone)**: Bounding trigger area covering `1` tiles wide by `2` tiles high from `(41, 21)` to `(41, 22)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[06]` (Hitbox Zone)**: Bounding trigger area covering `1` tiles wide by `2` tiles high from `(45, 20)` to `(45, 21)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[07]` (Hitbox Zone)**: Bounding trigger area covering `1` tiles wide by `2` tiles high from `(51, 21)` to `(51, 22)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[08]` (Hitbox Zone)**: Bounding trigger area covering `1` tiles wide by `2` tiles high from `(53, 21)` to `(53, 22)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[09]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(59, 21)` to `(60, 22)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[10]` (Hitbox Zone)**: Bounding trigger area covering `1` tiles wide by `2` tiles high from `(64, 21)` to `(64, 22)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[11]` (Hitbox Zone)**: Bounding trigger area covering `1` tiles wide by `2` tiles high from `(67, 20)` to `(67, 21)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[12]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(69, 21)` to `(70, 22)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[13]` (Hitbox Zone)**: Bounding trigger area covering `1` tiles wide by `2` tiles high from `(79, 21)` to `(79, 22)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[14]` (Hitbox Zone)**: Bounding trigger area covering `1` tiles wide by `2` tiles high from `(49, 34)` to `(49, 35)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[15]` (Hitbox Zone)**: Bounding trigger area covering `1` tiles wide by `2` tiles high from `(51, 34)` to `(51, 35)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[16]` (Hitbox Zone)**: Bounding trigger area covering `1` tiles wide by `2` tiles high from `(61, 35)` to `(61, 36)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[17]` (Hitbox Zone)**: Bounding trigger area covering `1` tiles wide by `2` tiles high from `(32, 54)` to `(32, 55)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[18]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(63, 35)` to `(64, 36)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[19]` (Hitbox Zone)**: Bounding trigger area covering `1` tiles wide by `2` tiles high from `(67, 35)` to `(67, 36)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[20]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(69, 35)` to `(71, 36)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[21]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(44, 58)` to `(46, 59)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[22]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(48, 59)` to `(50, 60)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[23]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(46, 62)` to `(48, 63)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[24]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(42, 63)` to `(44, 64)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[25]` (Hitbox Zone)**: Bounding trigger area covering `1` tiles wide by `2` tiles high from `(27, 48)` to `(27, 49)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[26]` (Hitbox Zone)**: Bounding trigger area covering `1` tiles wide by `2` tiles high from `(37, 56)` to `(37, 57)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[27]` (Hitbox Zone)**: Bounding trigger area covering `1` tiles wide by `2` tiles high from `(36, 33)` to `(36, 34)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[28]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(32, 33)` to `(33, 34)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[29]` (Hitbox Zone)**: Bounding trigger area covering `1` tiles wide by `2` tiles high from `(25, 36)` to `(25, 37)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[30]` (Hitbox Zone)**: Bounding trigger area covering `1` tiles wide by `2` tiles high from `(29, 32)` to `(29, 33)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[31]` (Hitbox Zone)**: Bounding trigger area covering `1` tiles wide by `2` tiles high from `(25, 25)` to `(25, 26)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[32]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `6` tiles high from `(35, 24)` to `(37, 29)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[33]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(21, 28)` to `(23, 29)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[34]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `6` tiles high from `(21, 48)` to `(23, 53)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (44 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 35 (bit 1) CLEAR | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[01]` | `2 (Map Init)` | Story Flag 35 (bit 2) CLEAR | Open Dialogue Message Window; Engine Action #9 |
| `ev[02]` | `2 (Map Init)` | Story Flag 35 (bit 4) CLEAR | Open Dialogue Message Window; Screen Fade Transition (255, 254, 255) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [56..64, 2..59] AND Condition Check #60 AND Story Flag 0 (mask 255) SET | Screen Fade Transition (0, 4, 31); Warp Room -> Submap 4 at (32,2) facing South (Down); Turn obj[92] facing 255 |
| `ev[04]` | `1 (Action / Talk)` | Story Flag 4 (bit 1) SET AND Story Flag 4 (bit 2) CLEAR AND Story Flag 0 (bit 8) CLEAR AND Player within Box [74..78, 2..19] AND Castle HQ Tier >= Level 9 AND Player X within Range [255..254] | Warp Room -> Submap 1 at (0,4); Jump to Bytecode Offset (9, 9); Close Dialogue Window; Warp Town -> Area 2 Map 110 Submap 101 at (7,0); Wait for Audio / Window Sync (3); Engine Action #9; Open Dialogue Message Window; Exit to World Map (32, 2, 0); Set Render Priority (pri) (68, 255) |
| `ev[05]` | `1 (Action / Talk)` | Story Flag 4 (bit 1) SET AND Story Flag 4 (bit 2) CLEAR AND Story Flag 0 (bit 8) SET AND Player within Box [74..78, 2..19] AND Castle HQ Tier >= Level 9 AND Player X within Range [255..254] | Warp Room -> Submap 1 at (0,4); Warp Map Transition (2, 0, 55, 62, 255) |
| `ev[06]` | `1 (Action / Talk)` | Story Flag 4 (bit 2) SET AND Player within Box [74..78, 2..19] AND Castle HQ Tier >= Level 9 AND Player X within Range [255..254] | Warp Room -> Submap 1 at (0,4); Warp Map Transition (2, 0, 55, 62, 255) |
| `ev[07]` | `1 (Action / Talk)` | Story Flag 4 (bit 1) SET AND Story Flag 4 (bit 2) CLEAR AND Star of Destiny #0 Recruited AND Party Member Count == 5 AND Player X in Range [255..254] | Open Dialogue Sub-Window (1); Return Warp to Castle Base (255, 254) |
| `ev[08]` | `1 (Action / Talk)` | Story Flag 4 (bit 1) SET AND Story Flag 35 (bit 8) CLEAR AND Star of Destiny #1 Recruited AND Party Member Count == 5 AND Player X in Range [255..254] | Recruit Character into Active Party (43, 0); Exit to World Map (55, 0, 65); Engine Action #39; Reset Camera Tracking (3); Open Dialogue Message Window; Warp to Castle HQ (33, 1, 18); Make obj[0] Hidden (disp = 0); Warp Room -> Submap 2 at (47,49) facing Up (North); Engine Action #5; Warp Room -> Submap 5 at (3,3) facing West (Left); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp Town -> Area 0 Map 5 Submap 15 at (30,255); Engine Action #5; Warp Town -> Area 4 Map 5 Submap 2 at (2,0); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp to Castle HQ (0, 30, 255); Walk obj[36] to (1,24); Warp Room -> Submap 119 at (73,15) facing 73; Branch on Choice (40, 0); Open Dialogue Message Window; Warp to Castle HQ (0, 120, 0); Engine Action #121; Open Dialogue Message Window; Engine Action #122; Engine Action #5; Warp Room -> Submap 10 at (1,0) facing 5; Show Dialogue Portrait (30, 41, 3); Open Dialogue Message Window; Warp to Castle HQ (6, 255, 0); Jump to Bytecode Offset (4, 6); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (0); Exit to World Map (0, 49, 64); Warp Room -> Submap 2 at (1,2) facing 255; Warp Room -> Submap 35 at (2,1) facing 9; Engine Action #51; Engine Action #9; Warp Town -> Area 24 Map 1 Submap 1 at (35,51); Screen Fade Transition (255, 3, 101); Exit to World Map (6, 101, 4); Pan Camera (30, 0, 4); Open Dialogue Message Window; Walk obj[64] to (1,41); Warp Town -> Area 4 Map 5 Submap 255 at (4,9); Start Boss Battle #4 (BGM: 1); Screen Fade Transition (51, 9, 255); Engine Action #5; Close Dialogue Sub-Window (1); Warp Room -> Submap 51 at (10,255) facing 6; Jump to Bytecode Offset (4, 6); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (0); Exit to World Map (0, 48, 64); Warp Room -> Submap 2 at (7,8) facing 255; Pan Camera (9, 35, 1); Warp Room -> Submap 51 at (9,255) facing 8; Close Dialogue Sub-Window (1); Warp Room -> Submap 51 at (10,255) facing 9; Engine Action #5; Warp Room -> Submap 15 at (2,0) facing 5; Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Screen Fade Transition (30, 24, 1); Open Dialogue Message Window; Engine Action #126; Engine Action #9; Start Boss Battle #8 (BGM: 255); Screen Fade Transition (73, 15, 39); Return Warp to Castle Base (5, 0); Warp to Castle HQ (0, 5, 5); Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (58) |
| `ev[09]` | `128 (Loop)` | Story Flag 4 (bit 1) SET AND Story Flag 35 (bit 8) CLEAR AND Star of Destiny #1 Recruited AND Party Member Count == 6 AND Player X within Range [255..254] | Load Sound Bank into Memory (1, 1); Open Dialogue Message Window; Set Combat Battle BGM (6); Load Sound Bank into Memory (0, 1); Set Entity Movement Speed (3, 5); Warp Room -> Submap 15 at (4,3) facing West (Left); Warp Room -> Submap 2 at (1,1) facing Up (North); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Open Dialogue Message Window; Engine Action #5; Dismiss Emotion Bubble (1); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Warp Town -> Area 5 Map 45 Submap 1 at (0,30); Walk obj[37] to (1,255) |
| `ev[10]` | `1 (Action / Talk)` | Story Flag 35 (bit 8) SET AND Target Inspected is obj[11] | Open Dialogue Sub-Window (1); Toggle Random Encounters (255) |
| `ev[11]` | `1 (Action / Talk)` | Story Flag 4 (bit 2) SET AND Story Flag 35 (bit 8) CLEAR AND Star of Destiny #0 Recruited AND Party Member Count == 5 AND Player X in Range [255..254] | Open Dialogue Sub-Window (1); Remove Item from Inventory (255, 254) |
| `ev[12]` | `1 (Action / Talk)` | Story Flag 35 (bit 16) CLEAR AND Target Inspected is obj[12] | Jump to Bytecode Offset (4, 6); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (0); Exit to World Map (0, 1, 80); Warp Room -> Submap 2 at (0,1) facing 255; Open Dialogue Message Window; Engine Action #9; Start Boss Battle #16 (BGM: 255); Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[13]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Open Dialogue Sub-Window (2); Open Dialogue Message Window |
| `ev[14]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Open Dialogue Sub-Window (2); Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[15]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Open Dialogue Sub-Window (2); Warp Town -> Area 255 Map 254 Submap 255 at (254,204) |
| `ev[16]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Open Dialogue Sub-Window (2); Warp to Castle HQ (255, 254, 255) |
| `ev[17]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Open Dialogue Sub-Window (2); Exit to World Map (255, 254, 255) |
| `ev[18]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Open Dialogue Sub-Window (2); Engine Action #5 |
| `ev[19]` | `1 (Action / Talk)` | Story Flag 60 (bit 4) SET AND Target Inspected is obj[19] | Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (0); Exit to World Map (0, 13, 32); Open Dialogue Message Window; Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (0); Exit to World Map (0, 14, 32); Open Dialogue Message Window; Screen Fade Transition (171, 16, 30); Warp Room -> Submap 9 at (171,16) facing 10; Trigger Character Emotion Effect (4, 255) |
| `ev[20]` | `1 (Action / Talk)` | Story Flag 60 (bit 4) CLEAR AND Target Inspected is obj[19] | Open Dialogue Sub-Window (2); Engine Action #6 |
| `ev[21]` | `1 (Action / Talk)` | Target Inspected is obj[20] | Open Dialogue Sub-Window (2); Pan Camera (255, 254, 255) |
| `ev[22]` | `1 (Action / Talk)` | Target Inspected is obj[21] | Open Dialogue Sub-Window (2); Reset Camera Tracking (255) |
| `ev[23]` | `1 (Action / Talk)` | Target Inspected is obj[22] | Open Dialogue Sub-Window (2); Engine Action #9 |
| `ev[24]` | `1 (Action / Talk)` | Target Inspected is obj[23] | Open Dialogue Sub-Window (2); Screen Fade Transition (255, 254, 255) |
| `ev[25]` | `1 (Action / Talk)` | Target Inspected is obj[24] | Open Dialogue Sub-Window (2); Close Dialogue Window |
| `ev[26]` | `1 (Action / Talk)` | Target Inspected is obj[25] | Open Dialogue Sub-Window (2); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[27]` | `1 (Action / Talk)` | Target Inspected is obj[26] | Open Dialogue Sub-Window (2); Place Scenery Structure (255) |
| `ev[28]` | `1 (Action / Talk)` | Target Inspected is obj[27] | Open Dialogue Sub-Window (2); Animate Door Open |
| `ev[29]` | `1 (Action / Talk)` | Target Inspected is obj[28] | Open Dialogue Sub-Window (2); Show Dialogue Portrait (255, 254, 255) |
| `ev[30]` | `1 (Action / Talk)` | Target Inspected is obj[29] | Open Dialogue Sub-Window (2); Dismiss Dialogue Portrait |
| `ev[31]` | `1 (Action / Talk)` | Target Inspected is obj[30] | Open Dialogue Sub-Window (2); Change Portrait Expression (255) |
| `ev[32]` | `1 (Action / Talk)` | Target Inspected is obj[31] | Open Dialogue Sub-Window (2); Display Speaker Name Box (255) |
| `ev[33]` | `1 (Action / Talk)` | Target Inspected is obj[32] | Open Dialogue Sub-Window (2); Display Choice Selection (255, 254) |
| `ev[34]` | `1 (Action / Talk)` | Target Inspected is obj[33] | Open Dialogue Sub-Window (2); Branch on Choice (255, 254) |
| `ev[35]` | `1 (Action / Talk)` | Target Inspected is obj[34] | Open Dialogue Sub-Window (2); Execute Choice Result (255) |
| `ev[36]` | `1 (Action / Talk)` | Target Inspected is obj[35] | Open Dialogue Sub-Window (2); Set Story Flag (255, 254) |
| `ev[37]` | `1 (Action / Talk)` | Target Inspected is obj[36] | Open Dialogue Sub-Window (2); Open Dialogue Sub-Window (255) |
| `ev[38]` | `1 (Action / Talk)` | Target Inspected is obj[37] | Open Dialogue Sub-Window (2); Close Dialogue Sub-Window (255) |
| `ev[39]` | `1 (Action / Talk)` | Target Inspected is obj[38] | Open Dialogue Sub-Window (2); Clear Dialogue Sub-Window |
| `ev[40]` | `1 (Action / Talk)` | Target Inspected is obj[39] | Open Dialogue Sub-Window (2); Fade In from Black (255) |
| `ev[41]` | `1 (Action / Talk)` | Target Inspected is obj[40] | Open Dialogue Sub-Window (2); Fade Out to Black (255) |
| `ev[42]` | `1 (Action / Talk)` | Target Inspected is obj[41] | Open Dialogue Sub-Window (2); Display Chapter Text (255) |
| `ev[43]` | `1 (Action / Talk)` | Target Inspected is obj[42] | Open Dialogue Sub-Window (2); Display Emotion Bubble (255, 254) |

---



## Location Map: `va13`

- **Master Map Container**: `va13.json`
- **Submap Layer Files**: va13_01.json, va13_02.json
- **Collision Grid Files**: va13_map_00.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 1

### Submap Layer `va13_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `4` Objects | **Script Count (`evkaz`)**: `10` Scripts

#### Complete Physical Entity Inventory (4 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | Prop / Scenery | **Prop ID 64913** | `64913` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 3 | 55 | 180 |
| `obj[01]` | Prop / Scenery | **Prop ID 64913** | `64913` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 3 | 55 | 180 |
| `obj[02]` | Prop / Scenery | **Prop ID 38401** | `38401` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 55 | 0 |
| `obj[03]` | Prop / Scenery | **Prop ID 38913** | `38913` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 55 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Prop: Object 64913)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `34`.
- **`obj[01]` (Prop: Object 64913)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `34`.
- **`obj[02]` (Prop: Object 38401)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[03]` (Prop: Object 38913)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.


#### Complete Bytecode Script Catalog (10 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Temp Event Flag #1 SET | Make obj[2] Hidden (disp = 0); Open Dialogue Message Window; Warp Map Transition (16, 1, 0, 47, 255) |
| `ev[01]` | `2 (Map Init)` | Story Flag 3 (bit 1) SET AND Story Flag 4 (bit 1) CLEAR AND Temp Event Flag #1 SET | Make obj[2] Hidden (disp = 0); Screen Fade Transition (46, 22, 89); Screen Fade Transition (2, 0, 0); Screen Fade Transition (2, 8, 26); Clear Dialogue Sub-Window; Engine Action #89; Reset Camera Tracking (2); Warp Town -> Area 1 Map 8 Submap 2 at (9,51); Clear Dialogue Sub-Window; Engine Action #89; Engine Action #9; Warp Town -> Area 10 Map 1 Submap 9 at (47,255) |
| `ev[02]` | `2 (Map Init)` | Story Flag 143 (bit 1) SET | Make obj[2] Hidden (disp = 0); Close Dialogue Window; Make obj[22] Hidden (disp = 0); Engine Action #89; Close Dialogue Window; Warp Town -> Area 0 Map 0 Submap 11 at (47,255) |
| `ev[03]` | `128 (Loop)` | Story Flag 2 (bit 128) CLEAR AND Story Flag 4 (bit 1) CLEAR AND Story Flag 143 (bit 1) CLEAR AND Castle HQ Tier >= Level 1 | Dismiss Emotion Bubble (0); Exit to World Map (1, 2, 0); Warp Room -> Submap 1 at (255,254) facing 255 |
| `ev[04]` | `1 (Action / Talk)` | Story Flag 3 (bit 1) SET AND Temp Event Flag #1 SET | Recruit Character into Active Party (73, 60); Engine Action #44; Display Chapter Text (3); Reset Camera Tracking (1); Engine Action #54; Warp Room -> Submap 9 at (3,2) facing 69; Warp to Castle HQ (74, 1, 32); Warp Town -> Area 0 Map 12 Submap 76 at (58,255) |
| `ev[05]` | `128 (Loop)` | Story Flag 3 (bit 1) SET AND Inventory Holds Item #2 AND Temp Event Flag #4 SET | Set Entity Movement Speed (2, 90); Reset Camera Tracking (4); Warp Room -> Submap 7 at (30,255) facing 254; Engine Action #90; Engine Action #9; Exit to World Map (1, 18, 7); Dismiss Emotion Bubble (255); Walk obj[255] to (254,255) |
| `ev[06]` | `128 (Loop)` | Temp Event Flag #1 SET | Launch Tactical War Battle (2); Set Combat Battle BGM (60); Close Dialogue Window; Warp Room -> Submap 90 at (73,240) facing 73; Engine Action #120; Close Dialogue Window; Warp Town -> Area 2 Map 90 Submap 36 at (1,255) |
| `ev[07]` | `128 (Loop)` | Story Flag 3 (bit 1) SET AND Inventory Holds Item #2 AND Temp Event Flag #4 SET | Set Combat Battle BGM (150); Engine Action #94; Warp Town -> Area 1 Map 8 Submap 200 at (73,100); Engine Action #94; Warp Room -> Submap 8 at (120,255) facing 254 |
| `ev[08]` | `128 (Loop)` | Story Flag 3 (bit 1) SET AND Inventory Holds Item #2 AND Temp Event Flag #4 SET | Set Combat Battle BGM (150); Engine Action #94; Warp Town -> Area 1 Map 9 Submap 200 at (73,100); Engine Action #94; Warp Room -> Submap 9 at (120,255) facing 254 |
| `ev[09]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Temp Event Flag #1 SET | Recruit Character into Active Party (44, 28); Warp to Castle HQ (8, 1, 73); Engine Action #120; Set Special Scene BGM (1); Place Scenery Structure (5); Open Dialogue Message Window; Exit to World Map (0, 65, 32) |

---



## Location Map: `va14`

- **Master Map Container**: `va14.json`
- **Submap Layer Files**: va14_00.json, va14_01.json, va14_02.json, va14_04.json
- **Collision Grid Files**: None
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 1

### Submap Layer `va14_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `7` Objects | **Script Count (`evkaz`)**: `9` Scripts

#### Complete Physical Entity Inventory (7 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | Prop / Scenery | **Prop ID 64915** | `64915` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 55 | 180 |
| `obj[01]` | NPC / Actor | **Actor ID 153** | `153` | `(17, 33)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 3 | 55 | 0 |
| `obj[02]` | NPC / Actor | **Yoshino** | `155` | `(17, 33)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 3 | 55 | 0 |
| `obj[03]` | NPC / Actor | **Actor ID 65104** | `65104` | `(55, 33)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | Prop / Scenery | **Prop ID 33180** | `33180` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 55 | 0 |
| `obj[05]` | Prop / Scenery | **Prop ID 33180** | `33180` | `(17, 33)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 55 | 180 |
| `obj[06]` | Prop / Scenery | **Prop ID 33180** | `33180` | `(17, 33)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 55 | 180 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Prop: Object 64915)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `50`.
- **`obj[01]` (Object 153)**: Positioned at tile `(17, 33)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Yoshino)**: Positioned at tile `(17, 33)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Object 65104)**: Positioned at tile `(55, 33)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Prop: Object 33180)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `18`.
- **`obj[05]` (Prop: Object 33180)**: Environmental world dressing prop placed at tile `(17, 33)`. Solid collision is set to `18`.
- **`obj[06]` (Prop: Object 33180)**: Environmental world dressing prop placed at tile `(17, 33)`. Solid collision is set to `18`.


#### Complete Bytecode Script Catalog (9 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Always Passes (Unconditional) | Recruit Character into Active Party (36, 1); Launch Tactical War Battle (16); Engine Action #54; Open Dialogue Message Window; Warp Room -> Submap 0 at (7,4) facing South (Down); Open Shop Menu #9 (Type: 95); Make obj[1] Hidden (disp = 0); Close Dialogue Window; Warp Town -> Area 11 Map 43 Submap 34 at (0,11); Warp Town -> Area 9 Map 37 Submap 34 at (1,9); Warp Town -> Area 10 Map 37 Submap 34 at (1,10); Warp Town -> Area 12 Map 70 Submap 51 at (89,12); Warp Town -> Area 1 Map 0 Submap 12 at (2,13); Recruit Badeaux into Battle Slot 2; Animate Door Open; Warp Room -> Submap 0 at (14,89) facing 14; Warp Town -> Area 0 Map 1 Submap 0 at (47,36); Warp Map Transition (46, 0, 9, 0, 10); Teleport obj[36] to (2,49); Warp to Castle HQ (5, 0, 4); Exit to World Map (1, 64, 30); Engine Action #5; Engine Action #9; Engine Action #5; Engine Action #250; Engine Action #5; Engine Action #250; Exit to World Map (5, 3, 5); Warp Room -> Submap 5 at (30,2) facing South (Down); Engine Action #5; Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Dismiss Emotion Bubble (6); Warp Room -> Submap 20 at (2,0) facing 30; Engine Action #5; Screen Fade Transition (5, 250, 5); Engine Action #250; Engine Action #5; Screen Fade Transition (4, 5, 3); Warp Town -> Area 5 Map 5 Submap 1 at (0,5); Engine Action #40; Warp to Castle HQ (0, 5, 5); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (3, 0, 30); Walk obj[5] to (9,5); Show Dialogue Portrait (0, 0, 5); Engine Action #5; Warp to Castle HQ (0, 30, 0); Place Scenery Structure (89); Place Scenery Structure (2); Warp Town -> Area 49 Map 3 Submap 5 at (0,4); Engine Action #6; Warp to Castle HQ (34, 30, 255); Engine Action #5; Engine Action #9; Exit to World Map (6, 3, 34); Warp Room -> Submap 0 at (0,30) facing 255; Engine Action #5; Screen Fade Transition (4, 6, 3); Return Warp to Castle Base (1, 1); Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (255); Walk obj[73] to (60,5); Engine Action #9; Engine Action #6; Warp Town -> Area 30 Map 5 Submap 10 at (6,2); Dismiss Emotion Bubble (73); Dismiss Emotion Bubble (49); Warp Town -> Area 5 Map 9 Submap 6 at (2,30); Engine Action #5; Screen Fade Transition (5, 10, 6); Warp Town -> Area 30 Map 255 Submap 254 at (50,73); Dismiss Emotion Bubble (49); Warp Town -> Area 5 Map 9 Submap 6 at (2,5); Dismiss Emotion Bubble (4); Exit to World Map (1, 7, 2); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Screen Fade Transition (6, 2, 5); Make obj[4] Visible (disp = 1); Warp to Castle HQ (1, 3, 30); Walk obj[73] to (30,49); Warp Town -> Area 5 Map 9 Submap 4 at (6,0); Pan Camera (6, 3, 30); Engine Action #5; Screen Fade Transition (5, 5, 3); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (255); Walk obj[73] to (60,49); Warp Town -> Area 5 Map 9 Submap 4 at (4,1); Warp to Castle HQ (2, 0, 5); Show Dialogue Portrait (6, 1, 6); Warp Room -> Submap 255 at (254,5) facing 10; Engine Action #5; Screen Fade Transition (3, 0, 30); Walk obj[73] to (15,49); Warp Town -> Area 5 Map 9 Submap 4 at (4,0); Warp to Castle HQ (30, 255, 254); Engine Action #5; Screen Fade Transition (4, 4, 5); Show Dialogue Portrait (0, 3, 30); Walk obj[73] to (120,5); Engine Action #9; Exit to World Map (5, 2, 1); Open Dialogue Message Window; Open Dialogue Message Window; Pan Camera (1, 4, 4); Pan Camera (1, 30, 5); Screen Fade Transition (4, 5, 0); Warp Room -> Submap 2 at (30,73) facing 50; Close Dialogue Sub-Window (10); Open Dialogue Message Window; Set Story Flag (73, 15); Load Sound Bank into Memory (1, 9); Engine Action #9; Close Dialogue Sub-Window (9); Open Dialogue Message Window; Open Dialogue Sub-Window (72); Open Dialogue Message Window; Engine Action #9; Set Combat Battle BGM (15); Close Dialogue Sub-Window (10); Open Dialogue Message Window; Close Dialogue Sub-Window (73); Show Dialogue Portrait (72, 1, 9); Engine Action #9; Close Dialogue Sub-Window (9); Open Dialogue Message Window; Clear Dialogue Sub-Window; Load Sound Bank into Memory (0, 9); Set Combat Battle BGM (15); Launch Tactical War Battle (64); Close Dialogue Sub-Window (10); Open Dialogue Message Window; Fade In from Black (73); Show Dialogue Portrait (72, 1, 9); Engine Action #9; Close Dialogue Sub-Window (9); Open Dialogue Message Window; Fade Out to Black (72); Open Dialogue Message Window; Engine Action #9; Display Chapter Text (0); Branch on Choice (4, 73); Trigger Character Emotion Effect (89, 13); Warp Town -> Area 3 Map 89 Submap 13 at (5,89); Place Scenery Structure (5); Engine Action #89; Place Scenery Structure (2); Exit to World Map (73, 60, 89); Display Dialogue Box [Bank: 2, MsgID: 11]; Engine Action #89; Display Dialogue Box [Bank: 5, MsgID: 89]; Display Dialogue Box [Bank: 5, MsgID: 89]; Place Scenery Structure (2); Engine Action #5; Engine Action #89; Place Scenery Structure (5); Engine Action #89; Place Scenery Structure (5); Engine Action #89; Display Dialogue Box [Bank: 2, MsgID: 12]; Engine Action #89; Place Scenery Structure (2); Engine Action #6; Set Combat Battle BGM (100); Engine Action #89; Display Dialogue Box [Bank: 2, MsgID: 13]; Engine Action #89; Display Dialogue Box [Bank: 5, MsgID: 89]; Display Dialogue Box [Bank: 5, MsgID: 89]; Display Dialogue Box [Bank: 2, MsgID: 1]; Set Combat Battle BGM (60); Make obj[89] Hidden (disp = 0); Place Scenery Structure (2); Pan Camera (1, 12, 47); Engine Action #89; Place Scenery Structure (5); Engine Action #89; Place Scenery Structure (5); Engine Action #89; Place Scenery Structure (2); Reset Camera Tracking (73); Engine Action #90; Engine Action #89; Place Scenery Structure (2); Engine Action #9; Set Combat Battle BGM (90); Display Emotion Bubble (5, 46); Warp Room -> Submap 2 at (11,72) facing 9; Open Dialogue Message Window; Close Dialogue Window; Teleport obj[5] to (11,4); Engine Action #5; Open Dialogue Message Window; Display Dialogue Box [Bank: 5, MsgID: 15]; Dismiss Emotion Bubble (24); Close Dialogue Window; Open Dialogue Message Window; Display Chapter Text (36); Exit to World Map (73, 3, 5); Engine Action #9; Engine Action #6; Warp Town -> Area 4 Map 6 Submap 0 at (2,30); Set Entity Movement Speed (2, 5); Engine Action #9; Exit to World Map (5, 3, 1); Warp Room -> Submap 30 at (255,254) facing 5; Screen Fade Transition (4, 5, 2); Warp Town -> Area 1 Map 3 Submap 30 at (255,254); Walk obj[73] to (15,46); Load Sound Bank into Memory (1, 9); Engine Action #9; Load Sound Bank into Memory (1, 10); Engine Action #9; Teleport obj[24] to (10,0); Display Emotion Bubble (46, 72); Open Dialogue Message Window; Engine Action #9; Load Sound Bank into Memory (0, 10); Teleport obj[49] to (3,5); Close Dialogue Window; Engine Action #5; Show Dialogue Portrait (2, 0, 30); Engine Action #5; Engine Action #9; Exit to World Map (6, 2, 10); Dismiss Emotion Bubble (255); Engine Action #5; Screen Fade Transition (4, 6, 2); Screen Fade Transition (30, 255, 254); Walk obj[11] to (4,23); Engine Action #150; Open Shop Menu #7 (Type: 0); Exit to World Map (0, 22, 63); Engine Action #9; Make obj[2] Hidden (disp = 0); Reset Camera Tracking (17); Engine Action #61; Engine Action #89; Reset Camera Tracking (2); Exit to World Map (93, 0, 8); Warp to Castle HQ (1, 8, 47); Launch Tactical War Battle (8); Engine Action #90; Reset Camera Tracking (4); Warp to Castle HQ (18, 10, 30); Engine Action #54; Open Dialogue Message Window; Reset Camera Tracking (73); Trigger Character Emotion Effect (94, 3); Warp Town -> Area 8 Map 120 Submap 1 at (8,69); Warp to Castle HQ (32, 3, 250); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #58 |
| `ev[01]` | `128 (Loop)` | Inventory Holds Item #1 | Dismiss Emotion Bubble (0); Warp to Castle HQ (1, 1, 0); Toggle Random Encounters (1) |
| `ev[02]` | `128 (Loop)` | Inventory Holds Item #2 | Engine Action #5; Close Dialogue Window; Exit to World Map (2, 5, 240); Engine Action #5; Trigger Character Emotion Effect (1, 12); Engine Action #5; Show Dialogue Portrait (2, 0, 5); Dismiss Emotion Bubble (1); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp to Castle HQ (0, 30, 37); Warp Town -> Area 255 Map 254 Submap 255 at (254,204) |
| `ev[03]` | `128 (Loop)` | Inventory Holds Item #2 | Engine Action #90; Animate Door Open; Exit to World Map (5, 5, 240); Display Choice Selection (55, 30); Warp Room -> Submap 37 at (2,255) facing 254 |
| `ev[04]` | `128 (Loop)` | Inventory Holds Item #4 | Load Sound Bank into Memory (1, 9); Engine Action #6; Set Combat Battle BGM (15); Load Sound Bank into Memory (0, 9); Toggle Random Encounters (4) |
| `ev[05]` | `128 (Loop)` | Inventory Holds Item #8 | Engine Action #94; Warp Town -> Area 2 Map 8 Submap 180 at (37,8) |
| `ev[06]` | `128 (Loop)` | Inventory Holds Item #16 | Warp Room -> Submap 0 at (0,18); Toggle Random Encounters (16) |
| `ev[07]` | `128 (Loop)` | Inventory Holds Item #32 | Set Combat Battle BGM (60); Close Dialogue Window; Warp to Castle HQ (2, 150, 37); Warp Map Transition (255, 254, 255, 254, 204) |
| `ev[08]` | `128 (Loop)` | Inventory Holds Item #64 | Engine Action #5; Engine Action #9; Engine Action #5; Engine Action #5; Engine Action #6; Warp Room -> Submap 5 at (6,1) facing 30; Toggle Random Encounters (64) |

---



## Location Map: `va15`

- **Master Map Container**: `va15.json`
- **Submap Layer Files**: va15_01.json, va15_02.json, va15_04.json, va15_05.json, va15_06.json, va15_07.json, va15_08.json, va15_09.json, va15_10.json
- **Collision Grid Files**: va15_map_00.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 1

### Submap Layer `va15_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `44` Objects | **Script Count (`evkaz`)**: `4` Scripts

#### Complete Physical Entity Inventory (44 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Youth Brigade Recruit** | `3` | `(20, 20)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Actor ID 33430** | `33430` | `(20, 20)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Actor ID 33173** | `33173` | `(20, 20)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | NPC / Actor | **Actor ID 65104** | `65104` | `(55, 33)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | NPC / Actor | **Actor ID 65104** | `65104` | `(65, 33)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | NPC / Actor | **Actor ID 65104** | `65104` | `(56, 41)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | NPC / Actor | **Actor ID 65104** | `65104` | `(56, 41)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | NPC / Actor | **Actor ID 65104** | `65104` | `(56, 41)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | NPC / Actor | **Actor ID 65104** | `65104` | `(56, 41)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | NPC / Actor | **Actor ID 65104** | `65104` | `(56, 41)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | NPC / Actor | **Actor ID 65104** | `65104` | `(56, 41)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | NPC / Actor | **Actor ID 65104** | `65104` | `(56, 41)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | NPC / Actor | **Actor ID 65104** | `65104` | `(56, 41)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | NPC / Actor | **Actor ID 65104** | `65104` | `(56, 41)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | NPC / Actor | **Actor ID 65104** | `65104` | `(56, 41)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[15]` | NPC / Actor | **Matilda Knight Guard** | `65106` | `(56, 41)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[16]` | NPC / Actor | **Matilda Knight Guard** | `65106` | `(56, 41)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[17]` | NPC / Actor | **Matilda Knight Guard** | `65106` | `(56, 41)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[18]` | NPC / Actor | **Matilda Knight Guard** | `65106` | `(56, 41)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[19]` | NPC / Actor | **Matilda Knight Guard** | `65106` | `(56, 41)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[20]` | NPC / Actor | **Matilda Knight Guard** | `65106` | `(56, 41)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[21]` | NPC / Actor | **Matilda Knight Guard** | `65106` | `(56, 41)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[22]` | NPC / Actor | **Matilda Knight Guard** | `65106` | `(56, 41)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[23]` | NPC / Actor | **Matilda Knight Guard** | `65106` | `(56, 41)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[24]` | NPC / Actor | **Matilda Knight Guard** | `65106` | `(56, 41)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[25]` | Prop / Scenery | **Prop ID 33685** | `33685` | `(37, 15)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 55 | 0 |
| `obj[26]` | Prop / Scenery | **Prop ID 33685** | `33685` | `(41, 15)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 55 | 0 |
| `obj[27]` | Prop / Scenery | **Prop ID 33685** | `33685` | `(39, 17)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 55 | 0 |
| `obj[28]` | Prop / Scenery | **Prop ID 33685** | `33685` | `(42, 16)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 55 | 0 |
| `obj[29]` | NPC / Actor | **Actor ID 64987** | `64987` | `(56, 17)` | `0x0` | Up (North) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[30]` | NPC / Actor | **Actor ID 64987** | `64987` | `(58, 13)` | `0x0` | Up (North) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[31]` | NPC / Actor | **Actor ID 64987** | `64987` | `(59, 22)` | `0x0` | Up (North) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[32]` | Prop / Scenery | **Prop ID 64986** | `64986` | `(42, 20)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[33]` | Prop / Scenery | **Prop ID 64986** | `64986` | `(44, 14)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[34]` | Prop / Scenery | **Prop ID 64990** | `64990` | `(47, 16)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[35]` | Prop / Scenery | **Prop ID 64990** | `64990` | `(50, 14)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[36]` | Prop / Scenery | **Prop ID 64990** | `64990` | `(52, 19)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[37]` | Prop / Scenery | **Prop ID 64998** | `64998` | `(31, 16)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[38]` | Prop / Scenery | **Prop ID 64998** | `64998` | `(23, 18)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[39]` | Prop / Scenery | **Prop ID 64998** | `64998` | `(36, 20)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[40]` | Prop / Scenery | **Prop ID 64999** | `64999` | `(39, 12)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[41]` | Prop / Scenery | **Prop ID 64999** | `64999` | `(29, 17)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[42]` | Prop / Scenery | **Prop ID 64999** | `64999` | `(34, 11)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[43]` | Prop / Scenery | **Prop ID 64999** | `64999` | `(28, 14)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Youth Brigade Recruit)**: Positioned at tile `(20, 20)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Object 33430)**: Positioned at tile `(20, 20)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Object 33173)**: Positioned at tile `(20, 20)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Object 65104)**: Positioned at tile `(55, 33)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Object 65104)**: Positioned at tile `(65, 33)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Object 65104)**: Positioned at tile `(56, 41)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[06]` (Object 65104)**: Positioned at tile `(56, 41)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[07]` (Object 65104)**: Positioned at tile `(56, 41)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[08]` (Object 65104)**: Positioned at tile `(56, 41)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[09]` (Object 65104)**: Positioned at tile `(56, 41)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[10]` (Object 65104)**: Positioned at tile `(56, 41)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[11]` (Object 65104)**: Positioned at tile `(56, 41)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[12]` (Object 65104)**: Positioned at tile `(56, 41)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[13]` (Object 65104)**: Positioned at tile `(56, 41)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[14]` (Object 65104)**: Positioned at tile `(56, 41)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[15]` (Matilda Knight Guard)**: Positioned at tile `(56, 41)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[16]` (Matilda Knight Guard)**: Positioned at tile `(56, 41)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[17]` (Matilda Knight Guard)**: Positioned at tile `(56, 41)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[18]` (Matilda Knight Guard)**: Positioned at tile `(56, 41)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[19]` (Matilda Knight Guard)**: Positioned at tile `(56, 41)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[20]` (Matilda Knight Guard)**: Positioned at tile `(56, 41)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[21]` (Matilda Knight Guard)**: Positioned at tile `(56, 41)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[22]` (Matilda Knight Guard)**: Positioned at tile `(56, 41)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[23]` (Matilda Knight Guard)**: Positioned at tile `(56, 41)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[24]` (Matilda Knight Guard)**: Positioned at tile `(56, 41)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[25]` (Prop: Object 33685)**: Environmental world dressing prop placed at tile `(37, 15)`. Solid collision is set to `2`.
- **`obj[26]` (Prop: Object 33685)**: Environmental world dressing prop placed at tile `(41, 15)`. Solid collision is set to `2`.
- **`obj[27]` (Prop: Object 33685)**: Environmental world dressing prop placed at tile `(39, 17)`. Solid collision is set to `2`.
- **`obj[28]` (Prop: Object 33685)**: Environmental world dressing prop placed at tile `(42, 16)`. Solid collision is set to `2`.
- **`obj[29]` (Object 64987)**: Positioned at tile `(56, 17)`, facing Up (North). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[30]` (Object 64987)**: Positioned at tile `(58, 13)`, facing Up (North). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[31]` (Object 64987)**: Positioned at tile `(59, 22)`, facing Up (North). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[32]` (Prop: Object 64986)**: Environmental world dressing prop placed at tile `(42, 20)`. Solid collision is set to `2`.
- **`obj[33]` (Prop: Object 64986)**: Environmental world dressing prop placed at tile `(44, 14)`. Solid collision is set to `2`.
- **`obj[34]` (Prop: Object 64990)**: Environmental world dressing prop placed at tile `(47, 16)`. Solid collision is set to `2`.
- **`obj[35]` (Prop: Object 64990)**: Environmental world dressing prop placed at tile `(50, 14)`. Solid collision is set to `2`.
- **`obj[36]` (Prop: Object 64990)**: Environmental world dressing prop placed at tile `(52, 19)`. Solid collision is set to `2`.
- **`obj[37]` (Prop: Object 64998)**: Environmental world dressing prop placed at tile `(31, 16)`. Solid collision is set to `2`.
- **`obj[38]` (Prop: Object 64998)**: Environmental world dressing prop placed at tile `(23, 18)`. Solid collision is set to `2`.
- **`obj[39]` (Prop: Object 64998)**: Environmental world dressing prop placed at tile `(36, 20)`. Solid collision is set to `2`.
- **`obj[40]` (Prop: Object 64999)**: Environmental world dressing prop placed at tile `(39, 12)`. Solid collision is set to `2`.
- **`obj[41]` (Prop: Object 64999)**: Environmental world dressing prop placed at tile `(29, 17)`. Solid collision is set to `2`.
- **`obj[42]` (Prop: Object 64999)**: Environmental world dressing prop placed at tile `(34, 11)`. Solid collision is set to `2`.
- **`obj[43]` (Prop: Object 64999)**: Environmental world dressing prop placed at tile `(28, 14)`. Solid collision is set to `2`.


#### Complete Bytecode Script Catalog (4 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Story Flag 24 (bit 16) CLEAR | Recruit Character into Active Party (36, 1); Open Shop Menu #7 (Type: 0); Exit to World Map (0, 40, 16); Engine Action #9; Warp Room -> Submap 46 at (36,2) facing Up (North); Reset Camera Tracking (40); Fade In from Black (1); Reset Camera Tracking (89); Remove Item from Inventory (2, 11); Engine Action #89; Open Shop Menu #9 (Type: 2); Engine Action #89; Engine Action #44; Warp Town -> Area 9 Map 89 Submap 40 at (2,2); Engine Action #89; Award Potch Loot (+512 Potch); Engine Action #89; Make obj[2] Visible (disp = 1); Screen Fade Transition (89, 46, 2); Engine Action #6; Engine Action #89; Teleport obj[2] to (3,89); Turn obj[2] facing East (Right); Engine Action #89; Set Entity Movement Speed (2, 11); Engine Action #89; Walk obj[2] to (9,89); Engine Action #51; Warp Town -> Area 2 Map 47 Submap 54 at (0,1); Set Combat Battle BGM (40); Close Dialogue Window; Warp Room -> Submap 120 at (73,60) facing 24; Reset Camera Tracking (0); Warp Town -> Area 73 Map 15 Submap 11 at (2,30); Engine Action #120; Make obj[1] Hidden (disp = 0); Toggle Random Encounters (1); Open Save Crystal Menu (MSaveInit); Warp Room -> Submap 1 at (40,1) facing 41; Warp Room -> Submap 1 at (43,1) facing 44; Warp Room -> Submap 1 at (46,1) facing 47; Warp Room -> Submap 1 at (49,1) facing 50; Warp Room -> Submap 2 at (11,49) facing 14; Warp to Castle HQ (11, 2, 0); Close Dialogue Window; Warp Town -> Area 12 Map 49 Submap 17 at (3,12); Warp Town -> Area 0 Map 12 Submap 2 at (13,49); Branch on Choice (3, 13); Warp Town -> Area 0 Map 13 Submap 2 at (14,52); Show Dialogue Portrait (3, 14, 2); Open Dialogue Message Window; Animate Door Open; Warp Town -> Area 15 Map 52 Submap 19 at (3,15); Warp Town -> Area 0 Map 15 Submap 2 at (16,55); Animate Door Open; Warp to Castle HQ (16, 2, 0); Dismiss Dialogue Portrait; Warp Town -> Area 17 Map 55 Submap 17 at (3,17); Warp Town -> Area 0 Map 17 Submap 2 at (18,55); Branch on Choice (3, 18); Warp Town -> Area 0 Map 18 Submap 2 at (19,58); Show Dialogue Portrait (3, 19, 2); Open Dialogue Message Window; Display Choice Selection (2, 20); Engine Action #58; Display Choice Selection (3, 20); Warp Town -> Area 0 Map 20 Submap 2 at (21,58); Display Dialogue Box [Bank: 3, MsgID: 21]; Warp Town -> Area 0 Map 21 Submap 2 at (22,58); Set Story Flag (3, 22); Warp Town -> Area 0 Map 22 Submap 2 at (23,30); Show Dialogue Portrait (3, 23, 3); Open Dialogue Message Window; Open Dialogue Sub-Window (2); Close Dialogue Sub-Window (30); Display Choice Selection (3, 24); Warp to Castle HQ (0, 24, 2); Clear Dialogue Sub-Window; Fade In from Black (15); Warp to Castle HQ (25, 3, 0); Clear Dialogue Sub-Window; Warp Town -> Area 26 Map 26 Submap 19 at (3,26); Warp to Castle HQ (0, 26, 2); Fade Out to Black (22); Show Dialogue Portrait (3, 27, 3); Open Dialogue Message Window; Fade Out to Black (2); Display Chapter Text (22); Display Choice Selection (3, 28); Warp to Castle HQ (0, 28, 89); Return to Previous Memory Map (2); Open Dialogue Message Window; Open Dialogue Message Window; Return to Previous Memory Map (89); Return Warp to Castle Base (2, 3); Open Dialogue Message Window; Return Warp to Castle Base (89, 35); Warp Town -> Area 6 Map 0 Submap 35 at (89,36); Warp Town -> Area 7 Map 0 Submap 36 at (47,73); Engine Action #120; Close Dialogue Sub-Window (8); Open Dialogue Message Window; Warp to Castle HQ (73, 60, 11); Warp Room -> Submap 150 at (73,30) facing 36; Exit to World Map (24, 8, 0); Exit to World Map (73, 30, 54); Open Dialogue Message Window; Exit to World Map (11, 2, 30); Engine Action #150; Set Combat Battle BGM (60); Close Dialogue Sub-Window (8); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (15); Engine Action #9; Close Dialogue Sub-Window (16); Wait for Audio / Window Sync (2); Set Special Scene BGM (1); Place Scenery Structure (5); Warp Town -> Area 9 Map 0 Submap 31 at (52,58) |
| `ev[01]` | `128 (Loop)` | Inventory Holds Item #1 | Dismiss Emotion Bubble (0); Warp Town -> Area 1 Map 0 Submap 37 at (1,255) |
| `ev[02]` | `128 (Loop)` | Inventory Holds Item #2 | Engine Action #109; Warp Town -> Area 9 Map 37 Submap 2 at (255,254) |
| `ev[03]` | `128 (Loop)` | Inventory Holds Item #4 | Make obj[89] Hidden (disp = 0); Return to Previous Memory Map (2); Warp Room -> Submap 34 at (2,4) facing 47; Engine Action #89; Return to Previous Memory Map (5); Engine Action #89; Return to Previous Memory Map (5); Make obj[89] Hidden (disp = 0); Return to Previous Memory Map (2); Open Dialogue Message Window; Engine Action #89; Return Warp to Castle Base (2, 3); Teleport obj[73] to (60,46); Engine Action #89; Return to Previous Memory Map (2); Warp Town -> Area 89 Map 34 Submap 2 at (5,47); Toggle Random Encounters (4) |

---



## Location Map: `va16`

- **Master Map Container**: `va16.json`
- **Submap Layer Files**: va16_01.json, va16_03.json, va16_04.json, va16_05.json, va16_06.json, va16_07.json, va16_08.json, va16_09.json, va16_10.json, va16_11.json, va16_12.json, va16_14.json, va16_17.json, va16_18.json, va16_22.json, va16_23.json, va16_24.json, va16_25.json
- **Collision Grid Files**: None
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 1

### Submap Layer `va16_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `47` Objects | **Script Count (`evkaz`)**: `8` Scripts

#### Complete Physical Entity Inventory (47 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 65104** | `65104` | `(55, 33)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 50 |
| `obj[01]` | NPC / Actor | **Actor ID 65104** | `65104` | `(65, 33)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 45 |
| `obj[02]` | NPC / Actor | **Actor ID 65104** | `65104` | `(56, 41)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 44 |
| `obj[03]` | NPC / Actor | **Lebrante (Appraiser)** | `141` | `(20, 20)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | NPC / Actor | **Highland Patrol Soldier** | `80` | `(20, 20)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | NPC / Actor | **Actor ID 65176** | `65176` | `(56, 41)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | Prop / Scenery | **Prop ID 64918** | `64918` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 3 | 55 | 100 |
| `obj[07]` | Prop / Scenery | **Prop ID 64919** | `64919` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 55 | 50 |
| `obj[08]` | Prop / Scenery | **Prop ID 33165** | `33165` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 55 | 50 |
| `obj[09]` | Prop / Scenery | **Prop ID 39169** | `39169` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 55 | 45 |
| `obj[10]` | Prop / Scenery | **Prop ID 37456** | `37456` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 55 | 50 |
| `obj[11]` | NPC / Actor | **Actor ID 65176** | `65176` | `(185, 98)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 0 | 0 |
| `obj[12]` | NPC / Actor | **Actor ID 65176** | `65176` | `(127, 117)` | `0x0` | East (Right) | Visible (1) | Solid (Obstacle) | 4 | 0 | 0 |
| `obj[13]` | NPC / Actor | **Actor ID 65088** | `65088` | `(181, 99)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 0 | 0 |
| `obj[14]` | NPC / Actor | **Actor ID 65088** | `65088` | `(123, 118)` | `0x0` | East (Right) | Visible (1) | Solid (Obstacle) | 4 | 0 | 0 |
| `obj[15]` | NPC / Actor | **Actor ID 65226** | `65226` | `(177, 98)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 0 | 0 |
| `obj[16]` | NPC / Actor | **Actor ID 65226** | `65226` | `(119, 116)` | `0x0` | East (Right) | Visible (1) | Solid (Obstacle) | 4 | 0 | 0 |
| `obj[17]` | NPC / Actor | **Actor ID 65089** | `65089` | `(172, 97)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 0 | 0 |
| `obj[18]` | NPC / Actor | **Actor ID 65089** | `65089` | `(115, 117)` | `0x0` | East (Right) | Visible (1) | Solid (Obstacle) | 4 | 0 | 0 |
| `obj[19]` | NPC / Actor | **Actor ID 65042** | `65042` | `(168, 98)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 0 | 0 |
| `obj[20]` | NPC / Actor | **Actor ID 65042** | `65042` | `(113, 119)` | `0x0` | East (Right) | Visible (1) | Solid (Obstacle) | 4 | 0 | 0 |
| `obj[21]` | NPC / Actor | **Actor ID 65192** | `65192` | `(164, 99)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 0 | 0 |
| `obj[22]` | NPC / Actor | **Actor ID 65192** | `65192` | `(109, 117)` | `0x0` | East (Right) | Visible (1) | Solid (Obstacle) | 4 | 0 | 0 |
| `obj[23]` | NPC / Actor | **Actor ID 65040** | `65040` | `(161, 99)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 0 | 0 |
| `obj[24]` | NPC / Actor | **Actor ID 65040** | `65040` | `(106, 119)` | `0x0` | East (Right) | Visible (1) | Solid (Obstacle) | 4 | 0 | 0 |
| `obj[25]` | NPC / Actor | **Actor ID 65031** | `65031` | `(159, 100)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 0 | 0 |
| `obj[26]` | NPC / Actor | **Actor ID 65031** | `65031` | `(102, 116)` | `0x0` | East (Right) | Visible (1) | Solid (Obstacle) | 4 | 0 | 0 |
| `obj[27]` | NPC / Actor | **Actor ID 65068** | `65068` | `(151, 99)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 0 | 0 |
| `obj[28]` | NPC / Actor | **Actor ID 65068** | `65068` | `(98, 117)` | `0x0` | East (Right) | Visible (1) | Solid (Obstacle) | 4 | 0 | 0 |
| `obj[29]` | NPC / Actor | **Actor ID 65115** | `65115` | `(147, 100)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 0 | 0 |
| `obj[30]` | NPC / Actor | **Actor ID 65115** | `65115` | `(182, 109)` | `0x0` | West (Left) | Visible (1) | Solid (Obstacle) | 4 | 0 | 40 |
| `obj[31]` | NPC / Actor | **Actor ID 65028** | `65028` | `(144, 100)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 0 | 0 |
| `obj[32]` | NPC / Actor | **Actor ID 65028** | `65028` | `(178, 108)` | `0x0` | West (Left) | Visible (1) | Solid (Obstacle) | 4 | 0 | 40 |
| `obj[33]` | NPC / Actor | **Actor ID 65033** | `65033` | `(140, 101)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 0 | 0 |
| `obj[34]` | NPC / Actor | **Actor ID 65033** | `65033` | `(175, 109)` | `0x0` | West (Left) | Visible (1) | Solid (Obstacle) | 4 | 0 | 40 |
| `obj[35]` | NPC / Actor | **Actor ID 65087** | `65087` | `(125, 100)` | `0x0` | East (Right) | Visible (1) | Solid (Obstacle) | 4 | 0 | 0 |
| `obj[36]` | NPC / Actor | **Actor ID 65087** | `65087` | `(171, 108)` | `0x0` | West (Left) | Visible (1) | Solid (Obstacle) | 4 | 0 | 40 |
| `obj[37]` | NPC / Actor | **Actor ID 65096** | `65096` | `(121, 97)` | `0x0` | East (Right) | Visible (1) | Solid (Obstacle) | 4 | 0 | 0 |
| `obj[38]` | NPC / Actor | **Actor ID 65096** | `65096` | `(167, 109)` | `0x0` | West (Left) | Visible (1) | Solid (Obstacle) | 4 | 0 | 40 |
| `obj[39]` | NPC / Actor | **Actor ID 65210** | `65210` | `(116, 97)` | `0x0` | East (Right) | Visible (1) | Solid (Obstacle) | 4 | 0 | 0 |
| `obj[40]` | NPC / Actor | **Actor ID 65210** | `65210` | `(162, 109)` | `0x0` | West (Left) | Visible (1) | Solid (Obstacle) | 4 | 0 | 40 |
| `obj[41]` | NPC / Actor | **Actor ID 65062** | `65062` | `(111, 98)` | `0x0` | East (Right) | Visible (1) | Solid (Obstacle) | 4 | 0 | 0 |
| `obj[42]` | NPC / Actor | **Actor ID 65062** | `65062` | `(158, 109)` | `0x0` | West (Left) | Visible (1) | Solid (Obstacle) | 4 | 0 | 40 |
| `obj[43]` | NPC / Actor | **Actor ID 65067** | `65067` | `(106, 97)` | `0x0` | East (Right) | Visible (1) | Solid (Obstacle) | 4 | 0 | 0 |
| `obj[44]` | NPC / Actor | **Actor ID 65067** | `65067` | `(154, 109)` | `0x0` | West (Left) | Visible (1) | Solid (Obstacle) | 4 | 0 | 40 |
| `obj[45]` | NPC / Actor | **Actor ID 65072** | `65072` | `(102, 100)` | `0x0` | East (Right) | Visible (1) | Solid (Obstacle) | 4 | 0 | 0 |
| `obj[46]` | NPC / Actor | **Actor ID 65072** | `65072` | `(149, 111)` | `0x0` | West (Left) | Visible (1) | Solid (Obstacle) | 4 | 0 | 40 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 65104)**: Positioned at tile `(55, 33)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Object 65104)**: Positioned at tile `(65, 33)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Object 65104)**: Positioned at tile `(56, 41)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Lebrante (Appraiser))**: Positioned at tile `(20, 20)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Highland Patrol Soldier)**: Positioned at tile `(20, 20)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Object 65176)**: Positioned at tile `(56, 41)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[06]` (Prop: Object 64918)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `18`.
- **`obj[07]` (Prop: Object 64919)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[08]` (Prop: Object 33165)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[09]` (Prop: Object 39169)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[10]` (Prop: Object 37456)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[11]` (Object 65176)**: Positioned at tile `(185, 98)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[12]` (Object 65176)**: Positioned at tile `(127, 117)`, facing East (Right). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[13]` (Object 65088)**: Positioned at tile `(181, 99)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[14]` (Object 65088)**: Positioned at tile `(123, 118)`, facing East (Right). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[15]` (Object 65226)**: Positioned at tile `(177, 98)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[16]` (Object 65226)**: Positioned at tile `(119, 116)`, facing East (Right). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[17]` (Object 65089)**: Positioned at tile `(172, 97)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[18]` (Object 65089)**: Positioned at tile `(115, 117)`, facing East (Right). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[19]` (Object 65042)**: Positioned at tile `(168, 98)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[20]` (Object 65042)**: Positioned at tile `(113, 119)`, facing East (Right). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[21]` (Object 65192)**: Positioned at tile `(164, 99)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[22]` (Object 65192)**: Positioned at tile `(109, 117)`, facing East (Right). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[23]` (Object 65040)**: Positioned at tile `(161, 99)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[24]` (Object 65040)**: Positioned at tile `(106, 119)`, facing East (Right). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[25]` (Object 65031)**: Positioned at tile `(159, 100)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[26]` (Object 65031)**: Positioned at tile `(102, 116)`, facing East (Right). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[27]` (Object 65068)**: Positioned at tile `(151, 99)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[28]` (Object 65068)**: Positioned at tile `(98, 117)`, facing East (Right). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[29]` (Object 65115)**: Positioned at tile `(147, 100)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[30]` (Object 65115)**: Positioned at tile `(182, 109)`, facing West (Left). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[31]` (Object 65028)**: Positioned at tile `(144, 100)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[32]` (Object 65028)**: Positioned at tile `(178, 108)`, facing West (Left). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[33]` (Object 65033)**: Positioned at tile `(140, 101)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[34]` (Object 65033)**: Positioned at tile `(175, 109)`, facing West (Left). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[35]` (Object 65087)**: Positioned at tile `(125, 100)`, facing East (Right). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[36]` (Object 65087)**: Positioned at tile `(171, 108)`, facing West (Left). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[37]` (Object 65096)**: Positioned at tile `(121, 97)`, facing East (Right). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[38]` (Object 65096)**: Positioned at tile `(167, 109)`, facing West (Left). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[39]` (Object 65210)**: Positioned at tile `(116, 97)`, facing East (Right). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[40]` (Object 65210)**: Positioned at tile `(162, 109)`, facing West (Left). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[41]` (Object 65062)**: Positioned at tile `(111, 98)`, facing East (Right). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[42]` (Object 65062)**: Positioned at tile `(158, 109)`, facing West (Left). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[43]` (Object 65067)**: Positioned at tile `(106, 97)`, facing East (Right). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[44]` (Object 65067)**: Positioned at tile `(154, 109)`, facing West (Left). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[45]` (Object 65072)**: Positioned at tile `(102, 100)`, facing East (Right). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[46]` (Object 65072)**: Positioned at tile `(149, 111)`, facing West (Left). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.


#### Complete Bytecode Script Catalog (8 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Story Flag 4 (bit 32) SET AND Story Flag 4 (bit 64) CLEAR | Recruit Character into Active Party (43, 0); Pan Camera (4, 0, 177); Engine Action #107; Reset Camera Tracking (46); Warp Town -> Area 14 Map 88 Submap 105 at (89,14); Warp Town -> Area 0 Map 0 Submap 14 at (1,0); Warp Town -> Area 17 Map 177 Submap 105 at (89,17); Warp Town -> Area 0 Map 0 Submap 17 at (2,18); Engine Action #176; Teleport Object to Coordinates (89, 18, 2); Open Dialogue Message Window; Open Dialogue Message Window; Display Speaker Name Box (2); Screen Fade Transition (172, 104, 0); Screen Fade Transition (3, 10, 2); Warp Town -> Area 8 Map 183 Submap 103 at (0,8); Warp to Castle HQ (8, 2, 2); Engine Action #9; Engine Action #184; Set Object Direction (0, 9); Warp to Castle HQ (9, 2, 47); Jump to Bytecode Offset (1, 1); Launch Tactical War Battle (1); Set Entity Movement Speed (6, 5); Open Dialogue Message Window; Exit to World Map (3, 2, 26); Dismiss Emotion Bubble (255); Engine Action #90; Change Portrait Expression (4); Warp to Castle HQ (18, 26, 4); Pan Camera (16, 4, 30); Engine Action #90; Display Speaker Name Box (4); Warp to Castle HQ (18, 26, 4); Pan Camera (16, 4, 30); Engine Action #5; Screen Fade Transition (4, 3, 2); Fade In from Black (4); Pan Camera (0, 4, 30); Engine Action #5; Reset Camera Tracking (4); Warp to Castle HQ (2, 26, 4); Pan Camera (0, 4, 30); Engine Action #5; Engine Action #9; Exit to World Map (3, 2, 26); Exit to World Map (7, 0, 4); Dismiss Emotion Bubble (255); Walk obj[54] to (1,4); Set Entity Movement Speed (6, 5); Open Dialogue Message Window; Exit to World Map (3, 2, 40); Dismiss Emotion Bubble (255); Engine Action #90; Change Portrait Expression (4); Warp to Castle HQ (18, 40, 30); Engine Action #90; Display Speaker Name Box (4); Warp to Castle HQ (18, 40, 30); Engine Action #5; Screen Fade Transition (4, 3, 2); Engine Action #40; Dismiss Emotion Bubble (255); Engine Action #5; Reset Camera Tracking (4); Warp to Castle HQ (2, 40, 30); Engine Action #5; Engine Action #9; Exit to World Map (3, 2, 40); Dismiss Emotion Bubble (255); Walk obj[46] to (89,17); Warp Town -> Area 1 Map 89 Submap 18 at (2,1); Teleport obj[5] to (10,5); Engine Action #5; Warp Room -> Submap 30 at (89,17) facing 5; Engine Action #89; Change Portrait Expression (5); Set Combat Battle BGM (15); Engine Action #89; Dismiss Dialogue Portrait; Warp Town -> Area 3 Map 89 Submap 16 at (5,89); Dismiss Dialogue Portrait; Engine Action #5; Clear Dialogue Sub-Window; Dismiss Dialogue Portrait; Engine Action #141; Open Dialogue Message Window; Trigger Character Emotion Effect (73, 15); Set Combat Battle BGM (20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 0 Map 61 Submap 0 at (65,73); Show Dialogue Portrait (41, 2, 0); Warp Room -> Submap 0 at (89,15) facing Up (North); Warp Room -> Submap 15 at (5,89) facing 15; Engine Action #5; Engine Action #89; Show Dialogue Portrait (2, 2, 24); Place Scenery Structure (0); Engine Action #62; Engine Action #89; Show Dialogue Portrait (5, 89, 15); Engine Action #5; Set Combat Battle BGM (15); Engine Action #89; Dismiss Dialogue Portrait; Warp Town -> Area 4 Map 25 Submap 16 at (141,0); Engine Action #63; Set Combat Battle BGM (15); Engine Action #89; Show Dialogue Portrait (2, 3, 24); Place Scenery Structure (0); Animate Doorway State (51, 2); Engine Action #89; Show Dialogue Portrait (5, 89, 15); Engine Action #5; Warp Room -> Submap 18 at (80,0) facing 66; Engine Action #89; Show Dialogue Portrait (2, 2, 24); Place Scenery Structure (0); Open Shop Interface #89; Show Dialogue Portrait (5, 89, 15); Engine Action #5; Set Combat Battle BGM (15); Engine Action #89; Dismiss Dialogue Portrait; Warp Town -> Area 4 Map 25 Submap 16 at (141,0); Play CD / Ambient BGM Track (73); Show Dialogue Portrait (89, 15, 2); Warp to Castle HQ (89, 15, 5); Engine Action #89; Show Dialogue Portrait (5, 255, 2); Set Combat Battle BGM (15); Engine Action #89; Dismiss Dialogue Portrait; Warp Town -> Area 5 Map 73 Submap 15 at (25,18); Engine Action #80; Open Dialogue Message Window; Wait for Audio / Window Sync (89); Dismiss Dialogue Portrait; Engine Action #5; Engine Action #89; Dismiss Dialogue Portrait; Engine Action #5; Set Combat Battle BGM (15); Engine Action #89; Show Dialogue Portrait (2, 2, 24); Place Scenery Structure (0); Recruit Hero #89 into Battle Slot 16; Warp Town -> Area 6 Map 73 Submap 15 at (25,16); Engine Action #141; Open Dialogue Message Window; Remove Character from Active Party (89); Show Dialogue Portrait (2, 3, 89); Dismiss Dialogue Portrait; Warp Town -> Area 7 Map 89 Submap 16 at (5,89); Dismiss Dialogue Portrait; Engine Action #5; Set Combat Battle BGM (15); Engine Action #89; Show Dialogue Portrait (2, 4, 73); Launch Tactical War Battle (101); Exit to World Map (28, 89, 15); Engine Action #5; Engine Action #89; Show Dialogue Portrait (5, 46, 89); Animate Door Open; Warp Town -> Area 1 Map 1 Submap 16 at (1,15); Teleport obj[36] to (64,73); Dismiss Emotion Bubble (46); Engine Action #89; Change Portrait Expression (2); Warp Town -> Area 89 Map 18 Submap 2 at (2,47); Set Combat Battle BGM (60); Make obj[89] Hidden (disp = 0); Change Portrait Expression (2); Warp to Castle HQ (89, 18, 2); Warp to Castle HQ (47, 89, 17); Engine Action #5; Engine Action #89; Change Portrait Expression (5); Make obj[89] Hidden (disp = 0); Change Portrait Expression (2); Open Dialogue Message Window; Engine Action #89; Display Speaker Name Box (2); Open Dialogue Message Window; Teleport obj[49] to (6,5); Open Dialogue Message Window; Exit to World Map (3, 2, 25); Dismiss Emotion Bubble (255); Engine Action #90; Change Portrait Expression (4); Warp to Castle HQ (18, 25, 30); Engine Action #90; Display Speaker Name Box (4); Warp to Castle HQ (18, 25, 30); Engine Action #5; Screen Fade Transition (4, 3, 2); Clear Dialogue Sub-Window; Dismiss Emotion Bubble (255); Engine Action #5; Reset Camera Tracking (4); Warp to Castle HQ (2, 25, 30); Engine Action #5; Engine Action #9; Exit to World Map (3, 2, 25); Dismiss Emotion Bubble (255); Walk obj[3] to (0,0); Warp Room -> Submap 1 at (0,7); Engine Action #54; Warp Room -> Submap 101 at (5,176) facing 9; Exit to World Map (64, 10, 0); Wait for Audio / Window Sync (3); Set Special Scene BGM (1); Warp Map Transition (2, 0, 56, 18, 58) |
| `ev[01]` | `128 (Loop)` | Story Flag 4 (bit 32) SET AND Story Flag 4 (bit 64) CLEAR AND Story Flag 0 (bit 1) CLEAR AND Inventory Holds Item #1 AND Temp Event Flag #2 SET | Close Dialogue Window; Warp Room -> Submap 150 at (36,2) facing 255 |
| `ev[02]` | `128 (Loop)` | Story Flag 4 (bit 32) SET AND Story Flag 4 (bit 64) CLEAR AND Player within Box [160..160, 2..90] AND Condition Check #107 AND Story Flag 2 (mask 255) SET | Engine Action #44; Launch Tactical War Battle (8); Display Chapter Text (2); Make obj[6] Hidden (disp = 0); Engine Action #54; Warp Room -> Submap 89 at (16,2) facing West (Left); Engine Action #89; Dismiss Dialogue Portrait; Engine Action #5; Engine Action #89; Dismiss Dialogue Portrait; Engine Action #5; Clear Dialogue Sub-Window; Dismiss Dialogue Portrait; Engine Action #141; Open Dialogue Message Window; Recruit Character into Active Party (89, 15); Warp Town -> Area 1 Map 89 Submap 15 at (5,89); Show Dialogue Portrait (5, 73, 15); Close Dialogue Sub-Window (13); Open Dialogue Message Window; Engine Action #58; Clear Dialogue Sub-Window; Dismiss Dialogue Portrait; Engine Action #141; Open Dialogue Message Window; Set obj[36] Collision to Passable; Engine Action #89; Show Dialogue Portrait (2, 0, 255) |
| `ev[03]` | `128 (Loop)` | Story Flag 4 (bit 32) SET AND Story Flag 4 (bit 64) CLEAR AND Story Flag 0 (bit 1) CLEAR AND Inventory Holds Item #8 AND Temp Event Flag #16 SET | Jump to Bytecode Offset (0, 176); Engine Action #90; Animate Door Open; Exit to World Map (4, 19, 21); Dismiss Emotion Bubble (89); Animate Door Open; Warp Town -> Area 1 Map 101 Submap 0 at (179,90); Animate Door Open; Exit to World Map (4, 19, 1); Dismiss Emotion Bubble (89); Animate Door Open; Engine Action #5; Engine Action #89; Animate Door Open; Engine Action #5; Jump to Bytecode Offset (5, 176); Make obj[89] Hidden (disp = 0); Animate Door Open; Warp Town -> Area 2 Map 2 Submap 15 at (110,105); Engine Action #89; Show Dialogue Portrait (2, 0, 0); Show Dialogue Portrait (2, 16, 110); Set Object Direction (89, 16); Warp Town -> Area 0 Map 0 Submap 16 at (2,13); Engine Action #113; Mark NPC Talk Interaction Complete (Flag #1); Place Scenery Structure (47); Set Combat Battle BGM (30); Launch Tactical War Battle (16); Engine Action #54; Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[04]` | `128 (Loop)` | Story Flag 4 (bit 32) SET AND Story Flag 4 (bit 64) CLEAR AND Story Flag 0 (bit 1) CLEAR AND Inventory Holds Item #4 AND Temp Event Flag #32 SET | Set Combat Battle BGM (240); Set Combat Battle BGM (160); Engine Action #89; Show Dialogue Portrait (2, 1, 73); Engine Action #40; Engine Action #89; Dismiss Dialogue Portrait; Warp Town -> Area 2 Map 36 Submap 32 at (255,254) |
| `ev[05]` | `128 (Loop)` | Story Flag 4 (bit 32) SET AND Story Flag 4 (bit 64) CLEAR AND Story Flag 0 (bit 1) CLEAR AND Inventory Holds Item #64 AND Temp Event Flag #128 SET | Engine Action #89; Animate Door Open; Warp Town -> Area 0 Map 101 Submap 0 at (176,90); Animate Door Open; Exit to World Map (3, 19, 30); Dismiss Emotion Bubble (36); Engine Action #128 |
| `ev[06]` | `128 (Loop)` | Story Flag 4 (bit 32) SET AND Story Flag 4 (bit 64) CLEAR AND Story Flag 0 (bit 1) CLEAR AND Inventory Holds Item #64 AND Temp Event Flag #128 SET | Set Combat Battle BGM (200); Close Dialogue Window; Warp Town -> Area 2 Map 200 Submap 36 at (128,255) |
| `ev[07]` | `128 (Loop)` | Story Flag 4 (bit 32) SET AND Story Flag 4 (bit 64) CLEAR AND Story Flag 0 (bit 1) CLEAR AND Inventory Holds Item #4 AND Temp Event Flag #32 SET | Set Combat Battle BGM (130); Warp to Castle HQ (20, 1, 73); Pan Camera (3, 43, 0); Set Combat Battle BGM (10); Warp to Castle HQ (22, 1, 73); Pan Camera (3, 24, 1); Set Combat Battle BGM (10); Warp to Castle HQ (45, 0, 73); Pan Camera (3, 26, 1); Set Combat Battle BGM (10); Warp to Castle HQ (47, 0, 73); Pan Camera (3, 28, 1); Set Combat Battle BGM (10); Warp to Castle HQ (30, 1, 73); Pan Camera (3, 49, 0); Set Combat Battle BGM (10); Warp to Castle HQ (32, 1, 73); Pan Camera (3, 51, 0); Set Combat Battle BGM (10); Warp to Castle HQ (34, 1, 73); Pan Camera (3, 36, 1); Set Combat Battle BGM (10); Warp to Castle HQ (53, 0, 255) |

---



## Location Map: `va17`

- **Master Map Container**: `va17.json`
- **Submap Layer Files**: va17_03.json, va17_04.json
- **Collision Grid Files**: None
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 1

### Submap Layer `va17_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `10` Objects | **Script Count (`evkaz`)**: `11` Scripts

#### Complete Physical Entity Inventory (10 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | Prop / Scenery | **Prop ID 64915** | `64915` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 3 | 55 | 180 |
| `obj[01]` | Prop / Scenery | **Prop ID 64915** | `64915` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 3 | 55 | 180 |
| `obj[02]` | NPC / Actor | **Actor ID 153** | `153` | `(17, 33)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 55 | 0 |
| `obj[03]` | NPC / Actor | **Yoshino** | `155` | `(17, 33)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 55 | 0 |
| `obj[04]` | NPC / Actor | **Actor ID 154** | `154` | `(17, 33)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 55 | 0 |
| `obj[05]` | Prop / Scenery | **Prop ID 33686** | `33686` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 55 | 0 |
| `obj[06]` | Prop / Scenery | **Prop ID 33686** | `33686` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 55 | 0 |
| `obj[07]` | Prop / Scenery | **Prop ID 33686** | `33686` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 55 | 0 |
| `obj[08]` | Prop / Scenery | **Prop ID 33686** | `33686` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 55 | 0 |
| `obj[09]` | NPC / Actor | **Youth Brigade Recruit** | `3` | `(22, 16)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Prop: Object 64915)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `50`.
- **`obj[01]` (Prop: Object 64915)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `50`.
- **`obj[02]` (Object 153)**: Positioned at tile `(17, 33)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Yoshino)**: Positioned at tile `(17, 33)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Object 154)**: Positioned at tile `(17, 33)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Prop: Object 33686)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[06]` (Prop: Object 33686)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[07]` (Prop: Object 33686)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[08]` (Prop: Object 33686)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[09]` (Youth Brigade Recruit)**: Positioned at tile `(22, 16)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.


#### Complete Bytecode Script Catalog (11 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Story Flag 27 (bit 1) CLEAR | Recruit Character into Active Party (36, 1); Engine Action #54; Open Dialogue Message Window; Warp Room -> Submap 0 at (7,4) facing South (Down); Walk obj[99] to (9,46); Warp Room -> Submap 2 at (8,28) facing 95; Engine Action #89; Reset Camera Tracking (2); Open Dialogue Message Window; Engine Action #93; Open Dialogue Message Window; Reset Camera Tracking (3); Warp Room -> Submap 2 at (9,35) facing 107; Engine Action #89; Engine Action #9; Warp Town -> Area 1 Map 93 Submap 0 at (9,3); Warp Room -> Submap 2 at (10,50) facing 105; Warp to Castle HQ (10, 3, 1); Screen Fade Transition (2, 13, 50); Set Object Direction (89, 13); Warp Town -> Area 4 Map 0 Submap 13 at (2,12); Make obj[105] Visible (disp = 1); Warp to Castle HQ (12, 3, 1); Display Dialogue Box [Bank: 2, MsgID: 14]; Make obj[105] Visible (disp = 1); Engine Action #89; Animate Door Open; Warp Town -> Area 2 Map 0 Submap 14 at (2,11); Engine Action #53; Engine Action #117; Warp to Castle HQ (11, 1, 1); Close Dialogue Window; Warp Town -> Area 15 Map 53 Submap 117 at (89,15); Warp Town -> Area 6 Map 0 Submap 15 at (2,16); Teleport obj[102] to (89,16); Warp Town -> Area 0 Map 0 Submap 16 at (47,36); Warp Town -> Area 90 Map 8 Submap 4 at (3,19); Pan Camera (30, 73, 60); Launch Tactical War Battle (4); Engine Action #90; Engine Action #9; Exit to World Map (3, 17, 8); Dismiss Emotion Bubble (54); Open Dialogue Message Window; Exit to World Map (73, 60, 36); Reset Camera Tracking (36); Dismiss Dialogue Portrait; Engine Action #54; Open Dialogue Message Window; Reset Camera Tracking (54); Open Dialogue Message Window; Dismiss Dialogue Portrait; Launch Tactical War Battle (32); Launch Tactical War Battle (64); Engine Action #54; Open Dialogue Message Window; Warp Map Transition (73, 120, 89, 13, 2); Engine Action #5; Engine Action #89; Place Scenery Structure (5); Engine Action #89; Place Scenery Structure (5); Make obj[0] Hidden (disp = 0); Screen Fade Transition (1, 13, 47); Set Combat Battle BGM (5); Set Entity Movement Speed (2, 5); Open Dialogue Message Window; Exit to World Map (4, 0, 16); Dismiss Emotion Bubble (255); Engine Action #5; Screen Fade Transition (4, 3, 0); Exit to World Map (30, 255, 254); Walk obj[89] to (16,2); Warp Room -> Submap 14 at (2,3) facing 89; Show Dialogue Portrait (2, 7, 89); Show Dialogue Portrait (5, 89, 15); Engine Action #5; Make obj[0] Hidden (disp = 0); Close Dialogue Window; Warp Room -> Submap 0 at (12,1) facing 14; Teleport obj[5] to (12,5); Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 24, 10); Open Dialogue Message Window; Place Scenery Structure (73); Dismiss Emotion Bubble (72); Warp Room -> Submap 9 at (24,11) facing South (Down); Animate Door Open; Load Sound Bank into Memory (0, 11); Close Dialogue Window; Exit to World Map (23, 150, 46); Warp Town -> Area 8 Map 43 Submap 113 at (89,8); Warp Town -> Area 2 Map 93 Submap 0 at (8,3); Warp Room -> Submap 47 at (36,2) facing 90; Reset Camera Tracking (4); Warp to Castle HQ (18, 10, 30); Engine Action #54; Open Dialogue Message Window; Warp Town -> Area 73 Map 60 Submap 36 at (8,54); Open Dialogue Message Window; Reset Camera Tracking (69); Warp to Castle HQ (13, 5, 0); Change Portrait Expression (250); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #58 |
| `ev[01]` | `128 (Loop)` | Story Flag 27 (bit 1) CLEAR AND Inventory Holds Item #1 | Dismiss Emotion Bubble (0); Exit to World Map (1, 2, 0); Warp Room -> Submap 1 at (255,254) facing 255 |
| `ev[02]` | `128 (Loop)` | Story Flag 27 (bit 1) CLEAR AND Inventory Holds Item #2 | Engine Action #94; Warp Town -> Area 2 Map 8 Submap 180 at (37,2) |
| `ev[03]` | `128 (Loop)` | Story Flag 27 (bit 1) CLEAR AND Inventory Holds Item #4 | Engine Action #94; Warp Town -> Area 2 Map 9 Submap 180 at (37,4) |
| `ev[04]` | `128 (Loop)` | Story Flag 27 (bit 1) CLEAR AND Inventory Holds Item #8 | Engine Action #94; Warp to Castle HQ (2, 8, 120); Warp Room -> Submap 37 at (8,255) facing 254 |
| `ev[05]` | `128 (Loop)` | Story Flag 27 (bit 1) CLEAR AND Inventory Holds Item #16 | Engine Action #94; Warp to Castle HQ (2, 9, 120); Warp Room -> Submap 37 at (16,255) facing 254 |
| `ev[06]` | `128 (Loop)` | Story Flag 27 (bit 1) CLEAR AND Inventory Holds Item #32 | Close Dialogue Window; Warp to Castle HQ (2, 150, 37); Warp Map Transition (255, 254, 255, 254, 204) |
| `ev[07]` | `128 (Loop)` | Story Flag 27 (bit 1) CLEAR AND Inventory Holds Item #64 | Engine Action #109; Open Dialogue Message Window; Change Portrait Expression (37); Animate Doorway State (255, 254) |
| `ev[08]` | `1 (Action / Talk)` | Story Flag 27 (bit 1) SET AND Story Flag 27 (bit 2) CLEAR AND Player within Box [48..48, 2..100] AND Condition Check #100 | Recruit Character into Active Party (46, 2); Dismiss Dialogue Portrait; Turn obj[100] facing 89; Dismiss Dialogue Portrait; Warp Town -> Area 0 Map 0 Submap 16 at (2,13); Walk obj[105] to (89,13); Warp Town -> Area 4 Map 0 Submap 13 at (2,14); Make obj[105] Hidden (disp = 0); Engine Action #89; Animate Door Open; Warp Town -> Area 2 Map 0 Submap 14 at (2,17); Turn obj[110] facing West (Left); Change Portrait Expression (1); Open Dialogue Message Window; Teleport obj[36] to (1,54); Open Dialogue Message Window; Warp Room -> Submap 2 at (5,0) facing 5; Dismiss Emotion Bubble (4); Warp to Castle HQ (0, 5, 30); Set Combat Battle BGM (30); Close Dialogue Sub-Window (17); Warp Room -> Submap 73 at (15,11) facing Up (North); Warp Town -> Area 150 Map 9 Submap 27 at (2,9); Pathfind and Walk to Coordinates (8, 69, 3); Place Scenery Structure (5); Screen Fade Transition (7, 1, 120); Set Entity Movement Speed (58, 255) |
| `ev[09]` | `128 (Loop)` | Story Flag 27 (bit 1) SET AND Story Flag 27 (bit 2) CLEAR AND Inventory Holds Item #1 | Dismiss Emotion Bubble (0); Warp Town -> Area 1 Map 0 Submap 37 at (1,255) |
| `ev[10]` | `128 (Loop)` | Story Flag 27 (bit 1) SET AND Story Flag 27 (bit 2) CLEAR AND Inventory Holds Item #2 | Close Dialogue Window; Warp Room -> Submap 150 at (37,2) facing 255 |

---



## Location Map: `va18`

- **Master Map Container**: `va18.json`
- **Submap Layer Files**: va18_04.json, va18_12.json
- **Collision Grid Files**: None
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 1

### Submap Layer `va18_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `15` Objects | **Script Count (`evkaz`)**: `19` Scripts

#### Complete Physical Entity Inventory (15 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | Prop / Scenery | **Prop ID 64915** | `64915` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 3 | 55 | 180 |
| `obj[01]` | NPC / Actor | **Actor ID 153** | `153` | `(17, 33)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 55 | 0 |
| `obj[02]` | NPC / Actor | **Yoshino** | `155` | `(17, 33)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 55 | 0 |
| `obj[03]` | NPC / Actor | **Actor ID 154** | `154` | `(17, 33)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 55 | 0 |
| `obj[04]` | NPC / Actor | **Actor ID 65070** | `65070` | `(17, 33)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 55 | 0 |
| `obj[05]` | NPC / Actor | **Actor ID 65076** | `65076` | `(17, 33)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 55 | 0 |
| `obj[06]` | NPC / Actor | **Actor ID 65096** | `65096` | `(17, 33)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 55 | 0 |
| `obj[07]` | NPC / Actor | **Highland Patrol Soldier** | `80` | `(60, 39)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | NPC / Actor | **Jowy (Camp/Prologue)** | `18` | `(60, 39)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | NPC / Actor | **Youth Brigade Recruit** | `3` | `(60, 39)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | NPC / Actor | **Jowy Atreides** | `2` | `(60, 39)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | NPC / Actor | **Riou (Casual/Prologue)** | `48` | `(60, 39)` | `0x0` | West (Left) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | Prop / Scenery | **Prop ID 34198** | `34198` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 55 | 0 |
| `obj[13]` | Prop / Scenery | **Prop ID 34198** | `34198` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 55 | 0 |
| `obj[14]` | Prop / Scenery | **Prop ID 34198** | `34198` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 55 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Prop: Object 64915)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `50`.
- **`obj[01]` (Object 153)**: Positioned at tile `(17, 33)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Yoshino)**: Positioned at tile `(17, 33)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Object 154)**: Positioned at tile `(17, 33)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Object 65070)**: Positioned at tile `(17, 33)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Object 65076)**: Positioned at tile `(17, 33)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[06]` (Object 65096)**: Positioned at tile `(17, 33)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[07]` (Highland Patrol Soldier)**: Positioned at tile `(60, 39)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[08]` (Jowy (Camp/Prologue))**: Positioned at tile `(60, 39)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[09]` (Youth Brigade Recruit)**: Positioned at tile `(60, 39)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[10]` (Jowy Atreides)**: Positioned at tile `(60, 39)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[11]` (Riou (Casual/Prologue))**: Positioned at tile `(60, 39)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[12]` (Prop: Object 34198)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[13]` (Prop: Object 34198)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[14]` (Prop: Object 34198)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.


#### Complete Bytecode Script Catalog (19 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Story Flag 0 (bit 1) CLEAR | Recruit Character into Active Party (36, 1); Engine Action #54; Open Dialogue Message Window; Warp Room -> Submap 0 at (7,4) facing South (Down); Jump to Bytecode Offset (100, 9); Make obj[1] Hidden (disp = 0); Open Dialogue Message Window; Warp Town -> Area 9 Map 117 Submap 95 at (0,9); Warp to Castle HQ (9, 0, 2); Screen Fade Transition (114, 95, 0); Screen Fade Transition (3, 10, 0); Warp Town -> Area 22 Map 80 Submap 103 at (89,22); Warp Town -> Area 0 Map 1 Submap 22 at (2,12); Engine Action #117; Mark NPC Talk Interaction Complete (Flag #0); Display Dialogue Box [Bank: 3, MsgID: 12]; Warp Room -> Submap 13 at (115,102) facing South (Down); Place Scenery Structure (3); Place Scenery Structure (1); Warp Town -> Area 14 Map 119 Submap 102 at (0,14); Warp to Castle HQ (14, 1, 47); Launch Tactical War Battle (4); Engine Action #5; Open Dialogue Message Window; Exit to World Map (3, 3, 15); Dismiss Emotion Bubble (36); Reset Camera Tracking (54); Open Dialogue Message Window; Exit to World Map (36, 32, 24); Display Dialogue Box [Bank: 0, MsgID: 15]; Engine Action #54; Open Dialogue Message Window; Warp Map Transition (73, 15, 36, 64, 24); Place Scenery Structure (0); Dismiss Dialogue Portrait; Engine Action #54; Open Dialogue Message Window; Animate Doorway State (46, 2); Branch on Choice (117, 95); Engine Action #89; Branch on Choice (2, 1); Open Dialogue Message Window; Branch on Choice (1, 9); Teleport obj[73] to (30,24); Engine Action #9; Open Dialogue Message Window; Change Portrait Expression (46); Warp Town -> Area 21 Map 114 Submap 95 at (89,21); Warp Town -> Area 2 Map 0 Submap 21 at (1,10); Teleport obj[73] to (60,24); Screen Fade Transition (0, 18, 73); Show Dialogue Portrait (11, 4, 2); Engine Action #40; Set Combat Battle BGM (60); Make obj[1] Hidden (disp = 0); Branch on Choice (1, 21); Warp Town -> Area 20 Map 119 Submap 94 at (89,20); Warp Town -> Area 7 Map 2 Submap 21 at (114,94); Engine Action #89; Execute Choice Result (2); Warp to Castle HQ (0, 20, 0); Execute Choice Result (47); Set Entity Movement Speed (2, 5); Place Scenery Structure (4); Pan Camera (1, 3, 30); Engine Action #5; Animate Door Open; Exit to World Map (7, 1, 3); Dismiss Emotion Bubble (255); Walk obj[11] to (3,2); Engine Action #40; Set Combat Battle BGM (15); Close Dialogue Sub-Window (12); Open Dialogue Message Window; Display Choice Selection (73, 15); Launch Tactical War Battle (128); Set Entity Movement Speed (3, 5); Display Dialogue Box [Bank: 4, MsgID: 3]; Engine Action #5; Screen Fade Transition (3, 0, 5); Engine Action #5; Open Dialogue Message Window; Engine Action #5; Warp to Castle HQ (13, 0, 0); Engine Action #5; Engine Action #5; Warp Town -> Area 0 Map 30 Submap 255 at (254,5); Place Scenery Structure (4); Warp to Castle HQ (5, 15, 3); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Open Dialogue Message Window; Engine Action #5; Warp to Castle HQ (13, 0, 0); Engine Action #5; Engine Action #5; Warp Town -> Area 0 Map 30 Submap 255 at (254,5); Animate Door Open; Exit to World Map (3, 5, 20); Warp to Castle HQ (0, 5, 5); Open Dialogue Message Window; Exit to World Map (3, 13, 0); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp Town -> Area 0 Map 30 Submap 255 at (254,50); Make obj[72] Hidden (disp = 0); Warp Room -> Submap 6 at (72,1) facing 13; Engine Action #6; Load Sound Bank into Memory (1, 14); Engine Action #6; Teleport obj[49] to (3,5); Display Dialogue Box [Bank: 6, MsgID: 2]; Dismiss Emotion Bubble (255); Engine Action #5; Place Scenery Structure (6); Warp Town -> Area 30 Map 255 Submap 254 at (5,14); Engine Action #6; Warp Town -> Area 30 Map 255 Submap 254 at (50,46); Load Sound Bank into Memory (0, 12); Load Sound Bank into Memory (0, 13); Load Sound Bank into Memory (0, 14); Teleport obj[73] to (15,49); Warp to Castle HQ (5, 12, 4); Engine Action #6; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp to Castle HQ (20, 30, 255); Engine Action #5; Place Scenery Structure (4); Engine Action #6; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp to Castle HQ (20, 30, 255); Engine Action #5; Animate Door Open; Exit to World Map (6, 0, 0); Engine Action #5; Engine Action #5; Warp to Castle HQ (20, 30, 255); Walk obj[54] to (0,128); Engine Action #9; Warp Room -> Submap 24 at (11,0) facing 20; Engine Action #53; Open Dialogue Message Window; Warp Room -> Submap 73 at (15,89) facing 21; Warp Town -> Area 4 Map 73 Submap 15 at (24,10); Open Dialogue Message Window; Execute Choice Result (89); Execute Choice Result (5); Engine Action #89; Execute Choice Result (5); Set Combat Battle BGM (15); Engine Action #89; Branch on Choice (2, 8); Engine Action #89; Execute Choice Result (2); Engine Action #5; Engine Action #89; Branch on Choice (5, 89); Branch on Choice (5, 89); Branch on Choice (2, 9); Engine Action #89; Execute Choice Result (5); Engine Action #89; Execute Choice Result (5); Engine Action #89; Execute Choice Result (2); Engine Action #6; Engine Action #89; Branch on Choice (5, 89); Branch on Choice (5, 89); Branch on Choice (2, 10); Engine Action #89; Branch on Choice (5, 89); Branch on Choice (5, 73); Show Dialogue Portrait (11, 4, 23); Engine Action #150; Make obj[2] Hidden (disp = 0); Reset Camera Tracking (99); Engine Action #87; Engine Action #89; Reset Camera Tracking (2); Warp to Castle HQ (93, 0, 8); Warp to Castle HQ (1, 8, 47); Launch Tactical War Battle (16); Engine Action #90; Reset Camera Tracking (4); Warp to Castle HQ (16, 10, 30); Engine Action #54; Open Dialogue Message Window; Dismiss Dialogue Portrait; Set Combat Battle BGM (60); Engine Action #94; Warp to Castle HQ (2, 8, 120); Warp Room -> Submap 69 at (3,32) facing Up (North); Engine Action #250; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #58 |
| `ev[01]` | `128 (Loop)` | Story Flag 0 (bit 1) CLEAR AND Inventory Holds Item #1 | Dismiss Emotion Bubble (0); Warp to Castle HQ (1, 1, 0); Toggle Random Encounters (1) |
| `ev[02]` | `128 (Loop)` | Story Flag 0 (bit 1) CLEAR AND Inventory Holds Item #4 | Close Dialogue Window; Warp to Castle HQ (2, 150, 37); Exit to World Map (255, 254, 255) |
| `ev[03]` | `128 (Loop)` | Story Flag 0 (bit 1) CLEAR AND Inventory Holds Item #8 | Warp Room -> Submap 1 at (0,13); Toggle Random Encounters (8) |
| `ev[04]` | `128 (Loop)` | Story Flag 0 (bit 1) CLEAR AND Inventory Holds Item #16 | Engine Action #94; Warp Town -> Area 2 Map 8 Submap 180 at (37,16) |
| `ev[05]` | `128 (Loop)` | Story Flag 0 (bit 1) CLEAR AND Inventory Holds Item #32 | Engine Action #5; Display Dialogue Box [Bank: 6, MsgID: 1]; Engine Action #5; Warp Town -> Area 6 Map 1 Submap 30 at (5,13); Engine Action #6; Warp Town -> Area 30 Map 5 Submap 12 at (6,1); Dismiss Emotion Bubble (5); Animate Door Open; Engine Action #6; Warp Room -> Submap 5 at (12,6) facing West (Left); Engine Action #5; Warp Town -> Area 6 Map 1 Submap 30 at (37,32) |
| `ev[06]` | `128 (Loop)` | Story Flag 0 (bit 1) CLEAR AND Inventory Holds Item #64 | Engine Action #5; Place Scenery Structure (6); Warp Room -> Submap 1 at (6,2) facing 30; Engine Action #5; Display Dialogue Box [Bank: 6, MsgID: 2]; Dismiss Emotion Bubble (5); Animate Door Open; Engine Action #6; Warp Room -> Submap 37 at (64,255) facing 254 |
| `ev[07]` | `128 (Loop)` | Story Flag 0 (bit 1) CLEAR AND Inventory Holds Item #128 | Open Dialogue Message Window; Set Story Flag (90, 22); Engine Action #5; Engine Action #220; Exit to World Map (6, 19, 37); Dismiss Emotion Bubble (46); Warp Town -> Area 11 Map 117 Submap 103 at (3,11); Warp to Castle HQ (1, 22, 0); Close Dialogue Window; Load Sound Bank into Memory (1, 11); Pan Camera (47, 37, 128) |
| `ev[08]` | `128 (Loop)` | Story Flag 0 (bit 1) CLEAR AND Story Flag 1 (bit 1) SET | Make obj[2] Hidden (disp = 0); Set Story Flag (117, 103); Engine Action #89; Set Story Flag (2, 0); Open Dialogue Message Window; Set Story Flag (72, 0); Close Dialogue Window; Warp Room -> Submap 47 at (90,22) facing 4; Engine Action #6; Display Choice Selection (32, 30); Screen Fade Transition (1, 1, 255) |
| `ev[09]` | `1 (Action / Talk)` | Story Flag 0 (bit 1) SET AND Story Flag 0 (bit 2) CLEAR AND Story Flag 5 (bit 1) SET | Recruit Character into Active Party (36, 1); Launch Tactical War Battle (2); Engine Action #54; Open Dialogue Message Window; Warp Room -> Submap 0 at (7,4) facing South (Down); Close Dialogue Sub-Window (142); Engine Action #9; Warp to Castle HQ (0, 1, 46); Warp Town -> Area 8 Map 11 Submap 141 at (89,8); Warp Town -> Area 8 Map 93 Submap 0 at (8,3); Warp Room -> Submap 47 at (36,8) facing 90; Reset Camera Tracking (4); Warp to Castle HQ (18, 5, 30); Engine Action #54; Open Dialogue Message Window; Reset Camera Tracking (73); Engine Action #240; Engine Action #94; Warp to Castle HQ (2, 8, 120); Warp Room -> Submap 44 at (76,3) facing 30; Warp Room -> Submap 7 at (46,2) facing 16; Close Dialogue Sub-Window (138); Open Dialogue Message Window; Dismiss Dialogue Portrait; Warp to Castle HQ (16, 1, 2); Show Dialogue Portrait (21, 142, 0); Show Dialogue Portrait (3, 15, 1); Warp Town -> Area 18 Map 23 Submap 144 at (0,18); Warp to Castle HQ (18, 1, 2); Change Portrait Expression (26); Engine Action #144; Open Dialogue Message Window; Change Portrait Expression (3); Change Portrait Expression (1); Teleport obj[30] to (1,2); Trigger Character Emotion Effect (3, 41); Warp Town -> Area 3 Map 4 Submap 255 at (3,2); Display Choice Selection (27, 142); Open Dialogue Message Window; Display Choice Selection (3, 19); Warp Room -> Submap 4 at (36,4) facing 76; Warp Town -> Area 30 Map 0 Submap 30 at (5,73); Screen Fade Transition (24, 16, 1); Engine Action #107; Set Combat Battle BGM (30); Close Dialogue Sub-Window (15); Warp Room -> Submap 73 at (45,30) facing West (Left); Warp Town -> Area 5 Map 6 Submap 41 at (2,0); Warp Room -> Submap 0 at (24,0) facing West (Left); Engine Action #109; Engine Action #51; Warp Town -> Area 255 Map 1 Submap 24 at (0,1); Engine Action #111; Warp Town -> Area 11 Map 4 Submap 23 at (150,9); Open Dialogue Message Window; Warp Town -> Area 58 Map 255 Submap 254 at (255,254) |
| `ev[10]` | `128 (Loop)` | Story Flag 0 (bit 1) SET AND Story Flag 0 (bit 2) CLEAR AND Story Flag 5 (bit 1) SET AND Inventory Holds Item #1 | Dismiss Emotion Bubble (0); Warp to Castle HQ (1, 1, 0); Toggle Random Encounters (1) |
| `ev[11]` | `128 (Loop)` | Story Flag 0 (bit 1) SET AND Story Flag 0 (bit 2) CLEAR AND Story Flag 5 (bit 1) SET AND Inventory Holds Item #2 | Toggle Random Encounters (2) |
| `ev[12]` | `128 (Loop)` | Story Flag 0 (bit 1) SET AND Story Flag 0 (bit 2) CLEAR AND Story Flag 5 (bit 1) SET AND Inventory Holds Item #4 | Close Dialogue Window; Warp to Castle HQ (2, 150, 37); Exit to World Map (255, 254, 255) |
| `ev[13]` | `128 (Loop)` | Story Flag 0 (bit 1) SET AND Story Flag 0 (bit 2) CLEAR AND Story Flag 5 (bit 1) SET AND Inventory Holds Item #8 | Engine Action #94; Warp Town -> Area 2 Map 8 Submap 180 at (37,8) |
| `ev[14]` | `1 (Action / Talk)` | Story Flag 0 (bit 1) SET AND Story Flag 0 (bit 2) CLEAR AND Story Flag 5 (bit 1) CLEAR AND Story Flag 0 (bit 2) CLEAR | Launch Tactical War Battle (1); Open Shop Menu #7 (Type: 0); Exit to World Map (0, 24, 142); Engine Action #9; Make obj[2] Hidden (disp = 0); Reset Camera Tracking (11); Engine Action #141; Engine Action #89; Reset Camera Tracking (2); Reset Camera Tracking (93); Open Dialogue Message Window; Reset Camera Tracking (3); Warp Room -> Submap 47 at (36,2) facing 90; Reset Camera Tracking (4); Warp to Castle HQ (18, 5, 30); Engine Action #54; Open Dialogue Message Window; Warp Town -> Area 73 Map 240 Submap 94 at (3,2); Reset Camera Tracking (120); Warp Room -> Submap 73 at (120,9) facing South (Down); Warp Town -> Area 255 Map 254 Submap 255 at (254,204) |
| `ev[15]` | `128 (Loop)` | Story Flag 0 (bit 1) SET AND Story Flag 0 (bit 2) CLEAR AND Story Flag 5 (bit 1) CLEAR AND Inventory Holds Item #1 | Dismiss Emotion Bubble (0); Warp to Castle HQ (1, 1, 0); Toggle Random Encounters (1) |
| `ev[16]` | `128 (Loop)` | Story Flag 0 (bit 1) SET AND Story Flag 0 (bit 2) CLEAR AND Story Flag 5 (bit 1) CLEAR AND Inventory Holds Item #2 | Engine Action #94; Warp Town -> Area 2 Map 8 Submap 180 at (37,2) |
| `ev[17]` | `1 (Action / Talk)` | Story Flag 0 (bit 1) SET AND Story Flag 0 (bit 2) SET | Make obj[2] Hidden (disp = 0); Reset Camera Tracking (6); Engine Action #149; Engine Action #89; Reset Camera Tracking (2); Engine Action #9; Engine Action #93; Open Dialogue Message Window; Reset Camera Tracking (3); Warp Room -> Submap 47 at (36,64) facing 90; Reset Camera Tracking (4); Warp to Castle HQ (17, 8, 30); Engine Action #54; Open Dialogue Message Window; Animate Doorway State (73, 240); Engine Action #94; Warp to Castle HQ (2, 8, 120); Warp Room -> Submap 69 at (3,13) facing 5; Warp Room -> Submap 2 at (44,48) facing 58 |
| `ev[18]` | `128 (Loop)` | Story Flag 0 (bit 1) SET AND Story Flag 0 (bit 2) SET AND Inventory Holds Item #64 | Engine Action #94; Warp Town -> Area 2 Map 8 Submap 180 at (37,64) |

---



## Location Map: `va19`

- **Master Map Container**: `va19.json`
- **Submap Layer Files**: va19_04.json
- **Collision Grid Files**: None
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 1

### Submap Layer `va19_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `7` Objects | **Script Count (`evkaz`)**: `8` Scripts

#### Complete Physical Entity Inventory (7 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | Prop / Scenery | **Prop ID 64915** | `64915` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 3 | 55 | 180 |
| `obj[01]` | NPC / Actor | **Actor ID 153** | `153` | `(17, 33)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 55 | 0 |
| `obj[02]` | NPC / Actor | **Yoshino** | `155` | `(17, 33)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 55 | 0 |
| `obj[03]` | NPC / Actor | **Actor ID 154** | `154` | `(17, 33)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 55 | 0 |
| `obj[04]` | Prop / Scenery | **Prop ID 33942** | `33942` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 55 | 0 |
| `obj[05]` | Prop / Scenery | **Prop ID 33942** | `33942` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 55 | 0 |
| `obj[06]` | Prop / Scenery | **Prop ID 33942** | `33942` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 55 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Prop: Object 64915)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `34`.
- **`obj[01]` (Object 153)**: Positioned at tile `(17, 33)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Yoshino)**: Positioned at tile `(17, 33)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Object 154)**: Positioned at tile `(17, 33)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Prop: Object 33942)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[05]` (Prop: Object 33942)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[06]` (Prop: Object 33942)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.


#### Complete Bytecode Script Catalog (8 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Always Passes (Unconditional) | Recruit Character into Active Party (36, 1); Launch Tactical War Battle (128); Engine Action #54; Open Dialogue Message Window; Warp Room -> Submap 0 at (7,4) facing South (Down); Animate Doorway State (17, 9); Make obj[1] Hidden (disp = 0); Open Dialogue Message Window; Warp Town -> Area 9 Map 65 Submap 30 at (1,9); Warp to Castle HQ (9, 2, 2); Screen Fade Transition (62, 30, 1); Screen Fade Transition (3, 10, 3); Warp Town -> Area 13 Map 62 Submap 30 at (89,13); Warp Town -> Area 0 Map 0 Submap 13 at (2,11); Full Rest & Healing (Restore HP/MP); Walk obj[0] to (11,3); Close Dialogue Window; Warp Room -> Submap 73 at (3,46) facing Up (North); Display Dialogue Box [Bank: 65, MsgID: 30]; Engine Action #89; Display Dialogue Box [Bank: 2, MsgID: 2]; Open Dialogue Message Window; Display Dialogue Box [Bank: 47, MsgID: 36]; Warp Town -> Area 5 Map 0 Submap 4 at (3,0); Display Dialogue Box [Bank: 5, MsgID: 30]; Dismiss Emotion Bubble (89); Place Scenery Structure (2); Warp Room -> Submap 30 at (89,12) facing Up (North); Warp to Castle HQ (73, 10, 89); Display Dialogue Box [Bank: 2, MsgID: 4]; Engine Action #89; Display Dialogue Box [Bank: 5, MsgID: 89]; Display Dialogue Box [Bank: 5, MsgID: 46]; Open Dialogue Message Window; Engine Action #9; Open Dialogue Message Window; Screen Fade Transition (1, 12, 1); Place Scenery Structure (47); Set Combat Battle BGM (30); Set Entity Movement Speed (2, 5); Engine Action #9; Exit to World Map (3, 5, 10); Open Dialogue Message Window; Warp Town -> Area 2 Map 0 Submap 30 at (255,254); Engine Action #5; Screen Fade Transition (4, 3, 0); Warp Town -> Area 3 Map 0 Submap 30 at (255,254); Walk obj[73] to (15,24); Screen Fade Transition (0, 31, 5); Screen Fade Transition (5, 10, 3); Open Dialogue Message Window; Engine Action #5; Screen Fade Transition (30, 24, 9); Open Dialogue Message Window; Warp Map Transition (5, 11, 4, 6, 1); Display Speaker Name Box (2); Engine Action #9; Engine Action #5; Warp Room -> Submap 5 at (9,5) facing 15; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Engine Action #5; Dismiss Emotion Bubble (46); Warp Town -> Area 14 Map 67 Submap 32 at (89,14); Warp Town -> Area 5 Map 0 Submap 14 at (1,9); Warp Room -> Submap 47 at (89,14) facing 5; Engine Action #89; Animate Door Open; Engine Action #5; Engine Action #89; Animate Door Open; Warp Town -> Area 6 Map 24 Submap 11 at (0,33); Engine Action #89; Animate Door Open; Warp Town -> Area 7 Map 73 Submap 15 at (24,9); Open Dialogue Message Window; Return Warp to Castle Base (5, 10); Engine Action #6; Warp Room -> Submap 89 at (14,2) facing 8; Close Dialogue Sub-Window (10); Open Dialogue Message Window; Start Boss Battle #89 (BGM: 14); Engine Action #5; Engine Action #89; Animate Door Open; Engine Action #5; Set Combat Battle BGM (15); Engine Action #89; Animate Door Open; Warp Town -> Area 9 Map 24 Submap 11 at (0,36); Engine Action #89; Animate Door Open; Engine Action #5; Engine Action #89; Animate Door Open; Engine Action #5; Engine Action #5; Screen Fade Transition (6, 1, 30); Engine Action #89; Animate Door Open; Warp Town -> Area 8 Map 24 Submap 10 at (0,37); Engine Action #89; Animate Door Open; Engine Action #5; Engine Action #89; Animate Door Open; Engine Action #5; Engine Action #89; Animate Door Open; Warp Town -> Area 9 Map 73 Submap 10 at (89,14); Warp Town -> Area 10 Map 73 Submap 37 at (46,2); Display Dialogue Box [Bank: 64, MsgID: 32]; Engine Action #89; Display Dialogue Box [Bank: 2, MsgID: 12]; Open Dialogue Message Window; Display Dialogue Box [Bank: 47, MsgID: 49]; Warp Town -> Area 90 Map 12 Submap 4 at (6,18); Warp Room -> Submap 255 at (254,5) facing 10; Exit to World Map (6, 5, 2); Pan Camera (1, 30, 255); Walk obj[89] to (14,5); Engine Action #89; Animate Door Open; Engine Action #5; Engine Action #89; Animate Door Open; Warp Town -> Area 11 Map 73 Submap 10 at (89,12); Warp Town -> Area 13 Map 73 Submap 30 at (24,11); Open Dialogue Message Window; Open Save Crystal Menu (MSaveInit); Engine Action #89; Animate Door Open; Engine Action #5; Engine Action #89; Animate Door Open; Engine Action #5; Engine Action #89; Display Dialogue Box [Bank: 5, MsgID: 89]; Display Dialogue Box [Bank: 5, MsgID: 73]; Show Dialogue Portrait (11, 4, 23); Engine Action #150; Make obj[2] Hidden (disp = 0); Reset Camera Tracking (44); Toggle Random Encounters (89); Reset Camera Tracking (2); Engine Action #5; Engine Action #93; Open Dialogue Message Window; Reset Camera Tracking (3); Warp Room -> Submap 47 at (36,64) facing 90; Reset Camera Tracking (4); Warp to Castle HQ (17, 10, 30); Engine Action #54; Open Dialogue Message Window; Animate Doorway State (73, 60); Engine Action #94; Warp to Castle HQ (2, 8, 120); Warp Room -> Submap 69 at (3,32) facing Up (North); Engine Action #250; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #58 |
| `ev[01]` | `128 (Loop)` | Inventory Holds Item #1 | Dismiss Emotion Bubble (0); Warp to Castle HQ (1, 1, 0); Toggle Random Encounters (1) |
| `ev[02]` | `128 (Loop)` | Inventory Holds Item #2 | Close Dialogue Window; Warp to Castle HQ (2, 150, 37); Warp Town -> Area 255 Map 254 Submap 255 at (254,204) |
| `ev[03]` | `128 (Loop)` | Inventory Holds Item #4 AND Temp Event Flag #8 SET | Toggle Random Encounters (4); Engine Action #5; Close Dialogue Window; Engine Action #6; Warp Room -> Submap 36 at (4,255) facing 254 |
| `ev[04]` | `128 (Loop)` | Inventory Holds Item #16 | Engine Action #5; Engine Action #9; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp Town -> Area 0 Map 30 Submap 37 at (16,255) |
| `ev[05]` | `128 (Loop)` | Inventory Holds Item #32 | Engine Action #5; Engine Action #9; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp to Castle HQ (0, 30, 37); Warp Map Transition (255, 254, 255, 254, 204) |
| `ev[06]` | `128 (Loop)` | Inventory Holds Item #64 | Engine Action #94; Warp Town -> Area 2 Map 8 Submap 180 at (37,64) |
| `ev[07]` | `128 (Loop)` | Inventory Holds Item #128 | Warp Room -> Submap 1 at (0,19); Toggle Random Encounters (128) |

---



## Location Map: `va20`

- **Master Map Container**: `va20.json`
- **Submap Layer Files**: va20_05.json
- **Collision Grid Files**: None
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 1

### Submap Layer `va20_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `12` Objects | **Script Count (`evkaz`)**: `7` Scripts

#### Complete Physical Entity Inventory (12 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | Prop / Scenery | **Prop ID 64915** | `64915` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 3 | 55 | 180 |
| `obj[01]` | NPC / Actor | **Actor ID 34561** | `34561` | `(16, 16)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Actor ID 34384** | `34384` | `(16, 16)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[03]` | NPC / Actor | **Jeane (Rune Sage)** | `145` | `(17, 33)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 55 | 0 |
| `obj[04]` | NPC / Actor | **Actor ID 65121** | `65121` | `(16, 16)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[05]` | NPC / Actor | **Actor ID 65121** | `65121` | `(16, 16)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[06]` | NPC / Actor | **Actor ID 65121** | `65121` | `(16, 16)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[07]` | NPC / Actor | **Actor ID 65121** | `65121` | `(16, 16)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 3 | 255 | 0 |
| `obj[08]` | NPC / Actor | **Actor ID 65121** | `65121` | `(16, 16)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 3 | 255 | 0 |
| `obj[09]` | NPC / Actor | **Actor ID 65121** | `65121` | `(16, 16)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[10]` | NPC / Actor | **Actor ID 65121** | `65121` | `(16, 16)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[11]` | Prop / Scenery | **Prop ID 34834** | `34834` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 55 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Prop: Object 64915)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `34`.
- **`obj[01]` (Object 34561)**: Positioned at tile `(16, 16)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Object 34384)**: Positioned at tile `(16, 16)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Jeane (Rune Sage))**: Positioned at tile `(17, 33)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Object 65121)**: Positioned at tile `(16, 16)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Object 65121)**: Positioned at tile `(16, 16)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[06]` (Object 65121)**: Positioned at tile `(16, 16)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[07]` (Object 65121)**: Positioned at tile `(16, 16)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[08]` (Object 65121)**: Positioned at tile `(16, 16)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[09]` (Object 65121)**: Positioned at tile `(16, 16)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[10]` (Object 65121)**: Positioned at tile `(16, 16)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[11]` (Prop: Object 34834)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.


#### Complete Bytecode Script Catalog (7 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Temp Event Flag #128 SET | Recruit Character into Active Party (36, 1); Launch Tactical War Battle (128); Engine Action #54; Open Dialogue Message Window; Warp Room -> Submap 0 at (7,4) facing South (Down); Set Animation Pose (17, 9); Make obj[1] Hidden (disp = 0); Open Dialogue Message Window; Warp Town -> Area 11 Map 56 Submap 17 at (3,11); Open Dialogue Message Window; Open Dialogue Message Window; Close Dialogue Window; Warp Town -> Area 9 Map 53 Submap 21 at (3,9); Warp Room -> Submap 9 at (2,12) facing 56; Execute Choice Result (3); Display Dialogue Box [Bank: 1, MsgID: 0]; Display Dialogue Box [Bank: 2, MsgID: 10]; Set obj[21] Collision to Passable; Screen Fade Transition (1, 0, 10); Warp Town -> Area 13 Map 53 Submap 24 at (3,13); Warp Room -> Submap 13 at (2,14) facing 56; Close Dialogue Sub-Window (3); Animate Door Open; Warp Room -> Submap 14 at (2,15) facing 59; Close Dialogue Sub-Window (3); Show Dialogue Portrait (1, 0, 15); Warp Town -> Area 16 Map 53 Submap 27 at (3,16); Warp Room -> Submap 16 at (2,17) facing 56; Fade Out to Black (3); Change Portrait Expression (1); Open Dialogue Message Window; Change Portrait Expression (2); Display Speaker Name Box (59); Fade Out to Black (3); Display Speaker Name Box (1); Open Dialogue Message Window; Display Speaker Name Box (2); Display Choice Selection (20, 21); Engine Action #89; Display Choice Selection (2, 1); Open Dialogue Message Window; Display Choice Selection (47, 36); Warp Town -> Area 36 Map 16 Submap 54 at (0,2); Close Dialogue Sub-Window (11); Open Dialogue Message Window; Engine Action #39; Launch Tactical War Battle (32); Engine Action #89; Display Choice Selection (2, 0); Engine Action #89; Display Choice Selection (5, 89); Display Choice Selection (5, 89); Display Choice Selection (2, 1); Engine Action #89; Display Choice Selection (5, 89); Display Choice Selection (5, 89); Display Choice Selection (2, 2); Engine Action #54; Open Dialogue Message Window; Dismiss Dialogue Portrait; Launch Tactical War Battle (4); Engine Action #89; Display Choice Selection (5, 89); Display Choice Selection (5, 54); Open Dialogue Message Window; Exit to World Map (46, 2, 8); Show Dialogue Portrait (20, 89, 8); Warp Town -> Area 6 Map 93 Submap 0 at (8,3); Warp Room -> Submap 47 at (36,8) facing 90; Reset Camera Tracking (4); Warp to Castle HQ (19, 10, 30); Engine Action #54; Open Dialogue Message Window; Reset Camera Tracking (73); Trigger Character Emotion Effect (94, 3); Warp Town -> Area 8 Map 120 Submap 1 at (8,69); Warp to Castle HQ (32, 3, 250); Open Dialogue Message Window; Open Dialogue Message Window; Launch Tactical War Battle (128); Engine Action #58 |
| `ev[01]` | `128 (Loop)` | Inventory Holds Item #1 | Dismiss Emotion Bubble (0); Warp to Castle HQ (1, 1, 0); Toggle Random Encounters (1) |
| `ev[02]` | `128 (Loop)` | Inventory Holds Item #2 | Close Dialogue Window; Warp to Castle HQ (2, 150, 37); Warp Town -> Area 255 Map 254 Submap 255 at (254,204) |
| `ev[03]` | `128 (Loop)` | Inventory Holds Item #4 | Close Dialogue Window; Exit to World Map (23, 150, 37); Exit to World Map (255, 254, 255) |
| `ev[04]` | `128 (Loop)` | Inventory Holds Item #8 | Engine Action #94; Warp Town -> Area 2 Map 8 Submap 180 at (37,8) |
| `ev[05]` | `128 (Loop)` | Inventory Holds Item #16 | Engine Action #5; Open Dialogue Message Window; Exit to World Map (3, 0, 6); Engine Action #5; Dismiss Emotion Bubble (4); Warp to Castle HQ (2, 15, 30); Engine Action #54; Warp Room -> Submap 5 at (0,2) facing East (Right); Dismiss Emotion Bubble (37); Dismiss Dialogue Portrait |
| `ev[06]` | `128 (Loop)` | Inventory Holds Item #128 | Warp Room -> Submap 0 at (0,20); Toggle Random Encounters (128) |

---



## Location Map: `va21`

- **Master Map Container**: `va21.json`
- **Submap Layer Files**: Embedded in master
- **Collision Grid Files**: None
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 1

### Submap Layer `va21_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `8` Objects | **Script Count (`evkaz`)**: `9` Scripts

#### Complete Physical Entity Inventory (8 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | Prop / Scenery | **Prop ID 64915** | `64915` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 3 | 55 | 180 |
| `obj[01]` | NPC / Actor | **Highland Patrol Soldier** | `80` | `(16, 16)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[02]` | Prop / Scenery | **Prop ID 33872** | `33872` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 55 | 0 |
| `obj[03]` | Prop / Scenery | **Prop ID 34049** | `34049` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 55 | 0 |
| `obj[04]` | Prop / Scenery | **Prop ID 34128** | `34128` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 55 | 0 |
| `obj[05]` | Prop / Scenery | **Prop ID 34128** | `34128` | `(20, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 3 | 55 | 0 |
| `obj[06]` | World Device | **Mechanism (ano 4)** | `0` | `(0, 0)` | `0x0` | Frame 4 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 1 | 480 |
| `obj[07]` | World Device | **Mechanism (ano 5)** | `0` | `(0, 0)` | `0x0` | Frame 5 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 1 | 480 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Prop: Object 64915)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `34`.
- **`obj[01]` (Highland Patrol Soldier)**: Positioned at tile `(16, 16)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Prop: Object 33872)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[03]` (Prop: Object 34049)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[04]` (Prop: Object 34128)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `2`.
- **`obj[05]` (Prop: Object 34128)**: Environmental world dressing prop placed at tile `(20, 18)`. Solid collision is set to `34`.
- **`obj[06]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(0, 0)` with state parameter `4`.
- **`obj[07]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(0, 0)` with state parameter `5`.


#### Complete Bytecode Script Catalog (9 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Story Flag 5 (bit 128) SET AND Story Flag 0 (bit 1) CLEAR | Recruit Character into Active Party (36, 1); Launch Tactical War Battle (128); Engine Action #54; Open Dialogue Message Window; Warp Room -> Submap 0 at (7,4) facing South (Down); Toggle Random Encounters (31); Engine Action #9; Warp to Castle HQ (0, 2, 44); Display Chapter Text (0); Set Story Flag (7, 28); Warp Town -> Area 3 Map 7 Submap 46 at (2,9); Return Warp to Castle Base (31, 3); Engine Action #9; Warp Room -> Submap 9 at (47,36) facing Up (North); Display Chapter Text (1); Set Story Flag (4, 46); Warp Town -> Area 10 Map 34 Submap 31 at (89,10); Warp Town -> Area 0 Map 0 Submap 10 at (1,9); Teleport obj[89] to (10,5); Engine Action #89; Screen Fade Transition (5, 46, 2); Animate Door Open; Warp Map Transition (28, 0, 14, 0, 9); Warp Room -> Submap 47 at (5,9) facing 5; Dismiss Emotion Bubble (3); Open Dialogue Message Window; Exit to World Map (4, 7, 2); Engine Action #5; Show Dialogue Portrait (30, 24, 9); Open Dialogue Message Window; Set Entity Movement Speed (73, 30); Close Dialogue Sub-Window (0); Open Dialogue Message Window; Walk obj[49] to (2,5); Open Dialogue Message Window; Exit to World Map (4, 5, 6); Warp Town -> Area 3 Map 1 Submap 0 at (5,30); Dismiss Emotion Bubble (255); Engine Action #5; Engine Action #9; Exit to World Map (4, 7, 1); Dismiss Emotion Bubble (255); Walk obj[29] to (5,46); Warp Town -> Area 11 Map 34 Submap 31 at (89,11); Warp Town -> Area 0 Map 0 Submap 11 at (1,0); Teleport obj[89] to (11,5); Engine Action #89; Close Dialogue Window; Engine Action #5; Make obj[1] Hidden (disp = 0); Animate Door Open; Warp Town -> Area 15 Map 32 Submap 28 at (0,15); Open Dialogue Message Window; Open Dialogue Message Window; Warp Room -> Submap 47 at (5,0) facing 5; Dismiss Emotion Bubble (2); Open Dialogue Message Window; Exit to World Map (4, 7, 2); Engine Action #5; Show Dialogue Portrait (30, 24, 9); Open Dialogue Message Window; Engine Action #51; Engine Action #5; Engine Action #9; Engine Action #5; Show Dialogue Portrait (0, 0, 5); Engine Action #5; Warp Town -> Area 0 Map 30 Submap 49 at (2,5); Open Dialogue Message Window; Exit to World Map (4, 2, 11); Open Dialogue Message Window; Warp to Castle HQ (2, 3, 30); Engine Action #5; Engine Action #9; Exit to World Map (4, 2, 8); Open Dialogue Message Window; Warp Town -> Area 2 Map 2 Submap 30 at (255,254); Walk obj[46] to (2,12); Execute Choice Result (33); Engine Action #89; Display Dialogue Box [Bank: 2, MsgID: 0]; Open Dialogue Message Window; Display Dialogue Box [Bank: 1, MsgID: 9]; Warp Room -> Submap 47 at (89,12) facing 5; Engine Action #89; Display Dialogue Box [Bank: 5, MsgID: 89]; Display Dialogue Box [Bank: 2, MsgID: 1]; Launch Tactical War Battle (8); Engine Action #89; Display Dialogue Box [Bank: 5, MsgID: 89]; Display Dialogue Box [Bank: 5, MsgID: 46]; Warp Town -> Area 13 Map 21 Submap 33 at (0,13); Warp Room -> Submap 89 at (13,2) facing Up (North); Teleport obj[90] to (13,4); Exit to World Map (11, 2, 30); Engine Action #89; Place Scenery Structure (2); Warp to Castle HQ (36, 16, 90); Place Scenery Structure (4); Exit to World Map (15, 3, 30); Engine Action #54; Open Dialogue Message Window; Reset Camera Tracking (54); Open Dialogue Message Window; Dismiss Dialogue Portrait; Engine Action #9; Open Dialogue Message Window; Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[01]` | `1 (Action / Talk)` | Story Flag 5 (bit 128) CLEAR AND Story Flag 0 (bit 1) CLEAR | Recruit Character into Active Party (36, 1); Launch Tactical War Battle (128); Engine Action #54; Open Dialogue Message Window; Warp Room -> Submap 0 at (7,4) facing South (Down); Toggle Random Encounters (31); Engine Action #9; Warp to Castle HQ (0, 2, 44); Display Chapter Text (0); Set Story Flag (7, 46); Warp Town -> Area 9 Map 34 Submap 31 at (3,9); Warp Room -> Submap 9 at (47,36) facing Up (North); Display Chapter Text (1); Set Story Flag (4, 29); Engine Action #5; Make obj[2] Hidden (disp = 0); Screen Fade Transition (34, 31, 89); Screen Fade Transition (2, 0, 0); Screen Fade Transition (1, 9, 47); Engine Action #89; Screen Fade Transition (5, 89, 10); Engine Action #5; Make obj[2] Hidden (disp = 0); Animate Door Open; Warp Map Transition (28, 0, 14, 0, 9); Warp Room -> Submap 47 at (5,9) facing 5; Dismiss Emotion Bubble (3); Open Dialogue Message Window; Exit to World Map (4, 7, 2); Engine Action #5; Show Dialogue Portrait (30, 24, 9); Open Dialogue Message Window; Set Entity Movement Speed (73, 30); Close Dialogue Sub-Window (0); Open Dialogue Message Window; Engine Action #52; Set Combat Battle BGM (15); Close Dialogue Sub-Window (9); Open Dialogue Message Window; Engine Action #53; Engine Action #5; Engine Action #9; Engine Action #5; Show Dialogue Portrait (4, 4, 3); Warp Town -> Area 1 Map 0 Submap 5 at (30,30); Make obj[2] Hidden (disp = 0); Screen Fade Transition (34, 31, 89); Screen Fade Transition (2, 1, 0); Screen Fade Transition (1, 9, 47); Engine Action #89; Screen Fade Transition (5, 89, 10); Engine Action #5; Make obj[1] Hidden (disp = 0); Animate Door Open; Warp Town -> Area 15 Map 32 Submap 28 at (0,15); Open Dialogue Message Window; Engine Action #9; Warp Room -> Submap 47 at (5,9) facing 5; Dismiss Emotion Bubble (3); Open Dialogue Message Window; Engine Action #5; Dismiss Emotion Bubble (0); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp Town -> Area 0 Map 5 Submap 15 at (30,49); Warp Town -> Area 5 Map 0 Submap 4 at (4,2); Display Dialogue Box [Bank: 0, MsgID: 3]; Warp Town -> Area 3 Map 30 Submap 255 at (254,5); Engine Action #9; Exit to World Map (4, 2, 11); Open Dialogue Message Window; Warp Town -> Area 2 Map 2 Submap 30 at (255,254); Walk obj[46] to (2,12); Execute Choice Result (33); Engine Action #89; Display Dialogue Box [Bank: 2, MsgID: 0]; Open Dialogue Message Window; Display Dialogue Box [Bank: 1, MsgID: 9]; Warp Room -> Submap 47 at (89,12) facing 5; Engine Action #89; Display Dialogue Box [Bank: 5, MsgID: 89]; Display Dialogue Box [Bank: 2, MsgID: 1]; Launch Tactical War Battle (8); Engine Action #89; Display Dialogue Box [Bank: 5, MsgID: 89]; Display Dialogue Box [Bank: 5, MsgID: 46]; Warp Town -> Area 13 Map 21 Submap 33 at (0,13); Warp Room -> Submap 89 at (13,2) facing Up (North); Teleport obj[90] to (13,4); Exit to World Map (11, 2, 30); Engine Action #89; Place Scenery Structure (2); Warp to Castle HQ (36, 16, 90); Place Scenery Structure (4); Exit to World Map (15, 3, 30); Engine Action #54; Open Dialogue Message Window; Reset Camera Tracking (54); Open Dialogue Message Window; Dismiss Dialogue Portrait; Engine Action #9; Open Dialogue Message Window; Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[02]` | `128 (Loop)` | Inventory Holds Item #1 | Dismiss Emotion Bubble (0); Warp to Castle HQ (1, 1, 0); Toggle Random Encounters (1) |
| `ev[03]` | `128 (Loop)` | Inventory Holds Item #2 | Close Dialogue Window; Warp to Castle HQ (2, 150, 37); Warp Town -> Area 255 Map 254 Submap 255 at (254,204) |
| `ev[04]` | `128 (Loop)` | Inventory Holds Item #8 | Set Combat Battle BGM (30); Close Dialogue Window; Exit to World Map (23, 150, 37); Reset Camera Tracking (255) |
| `ev[05]` | `128 (Loop)` | Inventory Holds Item #16 | Set Combat Battle BGM (30); Engine Action #44; Display Chapter Text (0); Branch on Choice (5, 37); Dismiss Dialogue Portrait |
| `ev[06]` | `128 (Loop)` | Inventory Holds Item #128 | Warp Room -> Submap 1 at (1,10); Toggle Random Encounters (128) |
| `ev[07]` | `1 (Action / Talk)` | Story Flag 0 (bit 1) SET | Recruit Character into Active Party (43, 0); Pan Camera (4, 0, 25); Engine Action #53; Engine Action #9; Display Emotion Bubble (7, 46); Warp Town -> Area 8 Map 6 Submap 43 at (89,8); Warp Town -> Area 7 Map 93 Submap 0 at (8,3); Warp Room -> Submap 47 at (36,32) facing 90; Reset Camera Tracking (4); Warp to Castle HQ (16, 8, 30); Engine Action #54; Open Dialogue Message Window; Warp Map Transition (73, 60, 94, 3, 2); Reset Camera Tracking (120); Warp Room -> Submap 69 at (3,9) facing 171; Warp Town -> Area 9 Map 238 Submap 4 at (32,2); Warp Town -> Area 85 Map 194 Submap 58 at (255,254) |
| `ev[08]` | `128 (Loop)` | Inventory Holds Item #32 | Engine Action #94; Warp Town -> Area 2 Map 8 Submap 180 at (37,32) |

---



## Location Map: `va22`

- **Master Map Container**: `va22.json`
- **Submap Layer Files**: va22_00.json
- **Collision Grid Files**: va22_map_00.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 4

### Submap Layer `va22_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `3` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (3 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `128 (Loop)` | Player within Box [4..5, 2..15] AND Condition Check #25 AND Story Flag 3 (mask 255) SET | Warp Room -> Submap 0 at (0,24) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [110..111, 2..23] AND Condition Check #33 AND Story Flag 3 (mask 255) SET | Warp Room -> Submap 0 at (0,24); Set Special Scene BGM (1); Warp Map Transition (3, 2, 3, 94, 255) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [0..1, 2..15] AND Condition Check #25 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 76]; Return Warp to Castle Base (255, 254) |

---

### Submap Layer `va22_01` (Index 1)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `2` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (2 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [78..79, 2..30] AND Condition Check #40 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 3]; Branch on Choice (255, 254) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [0..1, 2..19] AND Condition Check #34 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 68]; Fade Out to Black (255) |

---

### Submap Layer `va22_02` (Index 2)

- **Map Number (`mapno`)**: `2`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `2` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (2 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [70..71, 2..21] AND Condition Check #32 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 3]; Fade In from Black (255) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [0..1, 2..18] AND Treasure Byte 9 Bit 2 FRESH (Unopened) | Display Dialogue Box [Bank: 3, MsgID: 116]; Engine Action #89 |

---

### Submap Layer `va22_03` (Index 3)

- **Map Number (`mapno`)**: `3`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `1` Objects | **Script Count (`evkaz`)**: `8` Scripts

#### Complete Physical Entity Inventory (1 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 89** | `89` | `(34, 31)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 89)**: Positioned at tile `(34, 31)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.


#### Complete Bytecode Script Catalog (8 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Player within Box [3..3, 2..21] AND Inventory Holds Item #255 | Warp to Castle HQ (0, 3, 255) |
| `ev[01]` | `128 (Loop)` | Player within Box [20..38, 2..55] AND Condition Check #56 AND Story Flag 1 (mask 255) SET | Engine Action #109; Open Dialogue Message Window; Open Dialogue Sub-Window (255) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [118..119, 2..85] AND Condition Check #93 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 3]; Open Dialogue Sub-Window (255) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [0..1, 2..17] AND Condition Check #24 AND Story Flag 2 (mask 255) SET | Set Special Scene BGM (1); Place Scenery Structure (5); Open Dialogue Message Window; Open Dialogue Sub-Window (0); Pathfind and Walk to Coordinates (121, 255, 254) |
| `ev[04]` | `1 (Action / Talk)` | Story Flag 25 (bit 128) SET AND Story Flag 26 (bit 1) CLEAR AND Player within Box [20..36, 2..53] AND Condition Check #54 | Recruit Character into Active Party (43, 0); Exit to World Map (55, 0, 42); Open Shop Interface #9; Return to Previous Memory Map (1); Engine Action #80; Open Dialogue Message Window; Warp Room -> Submap 1 at (4,4) facing East (Right); Warp Town -> Area 5 Map 60 Submap 0 at (2,30); Engine Action #5; Open Dialogue Message Window; Engine Action #5; Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Trigger Character Emotion Effect (30, 24); Warp Room -> Submap 53 at (46,2) facing 8; Full Rest & Healing (Restore HP/MP); Wait for Audio / Window Sync (0); Reset Camera Tracking (3); Reset Camera Tracking (2); Teleport obj[73] to (60,36); Warp Room -> Submap 8 at (0,54) facing 5; Reset Camera Tracking (4); Exit to World Map (2, 18, 5); Dismiss Emotion Bubble (30); Close Dialogue Sub-Window (8); Open Dialogue Message Window; Set Render Priority (pri) (73, 100); Close Dialogue Sub-Window (8); Open Dialogue Message Window; Set Animation Pose (11, 2); Warp Town -> Area 150 Map 34 Submap 69 at (2,74); Warp Room -> Submap 26 at (1,13) facing 5; Screen Fade Transition (4, 3, 66); Set Entity Movement Speed (255, 254) |
| `ev[05]` | `128 (Loop)` | Story Flag 25 (bit 128) SET AND Story Flag 26 (bit 1) CLEAR AND Inventory Holds Item #1 | Set Combat Battle BGM (15); Set Entity Movement Speed (2, 5); Open Dialogue Message Window; Engine Action #5; Branch on Choice (3, 0); Dismiss Emotion Bubble (255); Engine Action #5; Warp Room -> Submap 10 at (3,0) facing 30; Walk obj[37] to (1,255) |
| `ev[06]` | `1 (Action / Talk)` | Story Flag 26 (bit 2) SET AND Story Flag 26 (bit 4) CLEAR AND Player within Box [42..42, 2..67] AND Condition Check #67 | Warp to Castle HQ (0, 3, 33); Warp Room -> Submap 0 at (1,5) facing West (Left); Exit to World Map (7, 0, 2); Warp to Castle HQ (2, 30, 46); Warp Town -> Area 8 Map 57 Submap 69 at (0,8); Warp to Castle HQ (8, 2, 47); Close Dialogue Window; Warp Room -> Submap 150 at (73,60) facing 24; Reset Camera Tracking (0); Recruit Character into Active Party (73, 120); Jump to Bytecode Offset (9, 8); Launch Tactical War Battle (1); Close Dialogue Window; Exit to World Map (2, 150, 69); Warp to Castle HQ (101, 9, 14); Set Object Direction (0, 0); Set Special Scene BGM (101); Warp Room -> Submap 102 at (1,73) facing 120; Engine Action #9; Fade In from Black (4); Set Special Scene BGM (1); Place Scenery Structure (5); Open Dialogue Message Window; Warp Town -> Area 0 Map 109 Submap 11 at (255,254) |
| `ev[07]` | `128 (Loop)` | Story Flag 26 (bit 2) SET AND Story Flag 26 (bit 4) CLEAR AND Inventory Holds Item #1 | Set Combat Battle BGM (60); Set Entity Movement Speed (2, 5); Open Dialogue Message Window; Engine Action #5; Screen Fade Transition (0, 0, 30); Engine Action #5; Warp Room -> Submap 0 at (30,255) facing 254; Walk obj[37] to (1,255) |

---



## Location Map: `va23`

- **Master Map Container**: `va23.json`
- **Submap Layer Files**: Embedded in master
- **Collision Grid Files**: va23_map_00.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 4

### Submap Layer `va23_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `3` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (3 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `128 (Loop)` | Player within Box [4..5, 2..15] AND Condition Check #25 AND Story Flag 3 (mask 255) SET | Warp Room -> Submap 0 at (0,10) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [110..111, 2..23] AND Condition Check #33 AND Story Flag 3 (mask 255) SET | Warp Room -> Submap 0 at (0,10); Set Special Scene BGM (1); Warp Map Transition (3, 2, 3, 94, 255) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [0..1, 2..15] AND Condition Check #25 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 76]; Return Warp to Castle Base (255, 254) |

---

### Submap Layer `va23_01` (Index 1)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `3` Objects | **Script Count (`evkaz`)**: `2` Scripts

#### Complete Physical Entity Inventory (3 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | Trigger / Hitbox | **Hitbox Zone (5x2)** | `0` | `(36, 43)` | `4x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[01]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(52, 24)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(56, 23)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `2` tiles high from `(36, 43)` to `(40, 44)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[01]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(52, 24)` to `(55, 25)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[02]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(56, 23)` to `(57, 24)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (2 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [78..79, 2..30] AND Condition Check #40 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 3]; Branch on Choice (255, 254) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [0..1, 2..19] AND Condition Check #34 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 68]; Fade Out to Black (255) |

---

### Submap Layer `va23_02` (Index 2)

- **Map Number (`mapno`)**: `2`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `2` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (2 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [70..71, 2..21] AND Condition Check #32 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 3]; Fade In from Black (255) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [0..1, 2..18] AND Treasure Byte 9 Bit 2 FRESH (Unopened) | Display Dialogue Box [Bank: 3, MsgID: 116]; Engine Action #89 |

---

### Submap Layer `va23_03` (Index 3)

- **Map Number (`mapno`)**: `3`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `3` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (3 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `128 (Loop)` | Player within Box [20..38, 2..55] AND Condition Check #56 AND Story Flag 1 (mask 255) SET | Warp Room -> Submap 0 at (0,9) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [118..119, 2..85] AND Condition Check #93 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 3]; Open Dialogue Sub-Window (255) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [0..1, 2..17] AND Condition Check #24 AND Story Flag 2 (mask 255) SET | Warp Room -> Submap 0 at (0,9); Set Special Scene BGM (1); Warp Map Transition (3, 250, 0, 0, 255) |

---



## Location Map: `va25`

- **Master Map Container**: `va25.json`
- **Submap Layer Files**: Embedded in master
- **Collision Grid Files**: va25_map_00.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 6

### Submap Layer `va25_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `3` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (3 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `128 (Loop)` | Player within Box [4..5, 2..20] AND Condition Check #30 AND Story Flag 3 (mask 255) SET | Warp Room -> Submap 2 at (12,0) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [0..1, 2..19] AND Condition Check #30 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 116]; Full Rest & Healing (Restore HP/MP) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [60..96, 2..64] AND Condition Check #65 AND Story Flag 0 (mask 255) SET | Warp Room -> Submap 2 at (12,0); Engine Action #9; Open Dialogue Message Window; Warp Room -> Submap 0 at (0,49) facing 47 |

---

### Submap Layer `va25_01` (Index 1)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `2` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (2 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [118..119, 2..67] AND Condition Check #82 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 3]; Clear Dialogue Sub-Window |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [0..1, 2..23] AND Condition Check #38 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 80]; Engine Action #131 |

---

### Submap Layer `va25_02` (Index 2)

- **Map Number (`mapno`)**: `2`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `4` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (4 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `128 (Loop)` | Player within Box [64..65, 2..125] AND Condition Check #137 AND Story Flag 2 (mask 255) SET | Warp Room -> Submap 1 at (0,21) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [82..83, 2..123] AND Condition Check #138 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 3]; Warp Room -> Submap 255 at (254,204) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [0..1, 2..20] AND Condition Check #38 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 3, MsgID: 162]; Set Render Priority (pri) (255, 254) |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [0..1, 2..87] AND Condition Check #101 AND Story Flag 2 (mask 255) SET | Warp Room -> Submap 1 at (0,21); Set Special Scene BGM (1); Warp Map Transition (2, 0, 108, 27, 255) |

---

### Submap Layer `va25_03` (Index 3)

- **Map Number (`mapno`)**: `3`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `2` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (2 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [164..165, 2..50] AND Condition Check #61 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 2, MsgID: 3]; Display Emotion Bubble (255, 254) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [0..1, 2..36] AND Condition Check #50 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 4, MsgID: 96]; Display Chapter Text (255) |

---

### Submap Layer `va25_04` (Index 4)

- **Map Number (`mapno`)**: `4`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `2` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (2 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Player within Box [98..99, 2..20] AND Condition Check #34 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 3, MsgID: 3]; Open Shop Menu #254 (Type: 255) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [0..1, 2..67] AND Condition Check #90 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 5, MsgID: 80]; Display Emotion Bubble (255, 254) |

---

### Submap Layer `va25_05` (Index 5)

- **Map Number (`mapno`)**: `5`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `0` Objects | **Script Count (`evkaz`)**: `3` Scripts

#### Complete Physical Entity Inventory (0 Objects)

*No physical entities placed on this submap layer (visual tilemap and collision only).*

#### Entity Narrative Roles, Placements & Mechanics



#### Complete Bytecode Script Catalog (3 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `128 (Loop)` | Player within Box [79..80, 2..23] AND Condition Check #35 AND Story Flag 2 (mask 255) SET | Warp Room -> Submap 2 at (12,9) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [82..83, 2..22] AND Condition Check #40 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 4, MsgID: 3]; Award Potch Currency (255,254) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [0..1, 2..67] AND Condition Check #83 AND Story Flag 2 (mask 255) SET | Warp Room -> Submap 2 at (12,9); Close Dialogue Window; Warp Town -> Area 2 Map 40 Submap 69 at (1,3); Open Dialogue Message Window; Warp Room -> Submap 0 at (0,232) facing 188 |

---



## Location Map: `va26`

- **Master Map Container**: `va26.json`
- **Submap Layer Files**: va26_03.json, va26_04.json, va26_05.json, va26_06.json, va26_07.json, va26_08.json
- **Collision Grid Files**: None
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 1

### Submap Layer `va26_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `11` Objects | **Script Count (`evkaz`)**: `8` Scripts

#### Complete Physical Entity Inventory (11 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 61520** | `61520` | `(17, 56)` | `0x0` | West (Left) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Actor ID 61458** | `61458` | `(14, 57)` | `0x0` | West (Left) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Actor ID 61441** | `61441` | `(14, 57)` | `0x0` | West (Left) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | NPC / Actor | **Actor ID 45197** | `45197` | `(21, 16)` | `0x0` | Up (North) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[04]` | NPC / Actor | **Actor ID 176** | `176` | `(17, 16)` | `0x0` | East (Right) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[05]` | Prop / Scenery | **Prop ID 33456** | `33456` | `(17, 16)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 55 | 0 |
| `obj[06]` | Prop / Scenery | **Prop ID 33933** | `33933` | `(22, 16)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 55 | 0 |
| `obj[07]` | Prop / Scenery | **Prop ID 33456** | `33456` | `(17, 16)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 55 | 0 |
| `obj[08]` | Prop / Scenery | **Prop ID 33456** | `33456` | `(17, 16)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 55 | 0 |
| `obj[09]` | NPC / Actor | **Village Direction Signpost** | `65009` | `(20, 9)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[10]` | NPC / Actor | **Actor ID 65008** | `65008` | `(10, 25)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 61520)**: Positioned at tile `(17, 56)`, facing West (Left). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Object 61458)**: Positioned at tile `(14, 57)`, facing West (Left). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Object 61441)**: Positioned at tile `(14, 57)`, facing West (Left). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Object 45197)**: Positioned at tile `(21, 16)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Object 176)**: Positioned at tile `(17, 16)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Prop: Object 33456)**: Environmental world dressing prop placed at tile `(17, 16)`. Solid collision is set to `0`.
- **`obj[06]` (Prop: Object 33933)**: Environmental world dressing prop placed at tile `(22, 16)`. Solid collision is set to `0`.
- **`obj[07]` (Prop: Object 33456)**: Environmental world dressing prop placed at tile `(17, 16)`. Solid collision is set to `0`.
- **`obj[08]` (Prop: Object 33456)**: Environmental world dressing prop placed at tile `(17, 16)`. Solid collision is set to `32`.
- **`obj[09]` (Village Direction Signpost)**: Positioned at tile `(20, 9)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[10]` (Object 65008)**: Positioned at tile `(10, 25)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.


#### Complete Bytecode Script Catalog (8 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Always Passes (Unconditional) | Make obj[89] Hidden (disp = 0); Place Scenery Structure (2); Warp Room -> Submap 14 at (2,1) facing 89; Show Dialogue Portrait (2, 0, 89); Change Portrait Expression (2); Exit to World Map (89, 18, 2); Exit to World Map (0, 13, 0); Animate Door Open; Open Dialogue Message Window; Show Dialogue Portrait (0, 17, 0); Display Speaker Name Box (47) |
| `ev[01]` | `1 (Action / Talk)` | Story Flag 40 (bit 8) SET AND Story Flag 40 (bit 16) CLEAR | Recruit Character into Active Party (43, 0); Pan Camera (4, 0, 16); Set obj[8] Collision to Passable; Warp Room -> Submap 2 at (10,16) facing 59; Warp to Castle HQ (10, 1, 47); Display Chapter Text (1); Warp Room -> Submap 7 at (36,1); Set Combat Battle BGM (90); Launch Tactical War Battle (2); Engine Action #54; Open Dialogue Message Window; Warp Room -> Submap 0 at (2,5) facing 8; Warp to Castle HQ (0, 5, 5); Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (5); Engine Action #9; Warp to Castle HQ (0, 30, 46); Launch Tactical War Battle (4); Launch Tactical War Battle (8); Teleport obj[49] to (4,5); Open Dialogue Message Window; Engine Action #5; Change Portrait Expression (3); Open Dialogue Message Window; Pan Camera (1, 5, 30); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Walk obj[4] to (4,0); Pan Camera (30, 255, 254); Engine Action #5; Reset Camera Tracking (4); Warp to Castle HQ (0, 10, 30); Engine Action #5; Screen Fade Transition (5, 17, 3); Open Dialogue Message Window; Pan Camera (1, 5, 30); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Walk obj[4] to (4,0); Pan Camera (30, 255, 254); Engine Action #5; Engine Action #9; Engine Action #5; Warp Map Transition (0, 0, 5, 60, 3); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp Room -> Submap 5 at (45,3) facing South (Down); Engine Action #5; Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Dismiss Emotion Bubble (4); Engine Action #5; Open Dialogue Message Window; Close Dialogue Window; Dismiss Emotion Bubble (255); Walk obj[89] to (18,2); Open Dialogue Message Window; Set Combat Battle BGM (90); Engine Action #89; Place Scenery Structure (2); Warp Town -> Area 89 Map 13 Submap 5 at (89,13); Engine Action #5; Engine Action #89; Place Scenery Structure (2); Warp to Castle HQ (73, 10, 89); Animate Door Open; Warp Town -> Area 1 Map 89 Submap 13 at (5,89); Place Scenery Structure (5); Engine Action #89; Place Scenery Structure (2); Exit to World Map (73, 5, 89); Animate Door Open; Warp Town -> Area 3 Map 89 Submap 13 at (5,89); Place Scenery Structure (5); Engine Action #89; Place Scenery Structure (2); Engine Action #5; Engine Action #89; Place Scenery Structure (5); Engine Action #89; Place Scenery Structure (5); Make obj[89] Hidden (disp = 0); Dismiss Dialogue Portrait; Warp Town -> Area 6 Map 0 Submap 16 at (89,13); Warp Town -> Area 7 Map 47 Submap 89 at (13,5); Engine Action #89; Place Scenery Structure (5); Launch Tactical War Battle (16); Engine Action #89; Animate Door Open; Warp Town -> Area 8 Map 89 Submap 14 at (5,89); Animate Door Open; Engine Action #5; Engine Action #89; Animate Door Open; Warp Town -> Area 9 Map 89 Submap 14 at (5,89); Animate Door Open; Engine Action #5; Launch Tactical War Battle (32); Engine Action #89; Animate Door Open; Warp Town -> Area 10 Map 89 Submap 14 at (5,89); Animate Door Open; Engine Action #5; Engine Action #54; Open Dialogue Message Window; Warp Map Transition (73, 90, 69, 3, 74); Warp Room -> Submap 40 at (16,13) facing 5; Open Dialogue Message Window; Screen Fade Transition (3, 59, 28); Engine Action #58 |
| `ev[02]` | `128 (Loop)` | Story Flag 40 (bit 8) SET AND Story Flag 40 (bit 16) CLEAR AND Inventory Holds Item #1 | Close Dialogue Window; Warp Room -> Submap 120 at (37,1) facing 255 |
| `ev[03]` | `128 (Loop)` | Story Flag 40 (bit 8) SET AND Story Flag 40 (bit 16) CLEAR AND Inventory Holds Item #2 | Display Emotion Bubble (3, 37); Warp Town -> Area 255 Map 254 Submap 255 at (254,204) |
| `ev[04]` | `128 (Loop)` | Story Flag 40 (bit 8) SET AND Story Flag 40 (bit 16) CLEAR AND Inventory Holds Item #4 | Load Sound Bank into Memory (1, 0); Set Story Flag (73, 5); Load Sound Bank into Memory (1, 9); Set Story Flag (73, 10); Load Sound Bank into Memory (0, 0); Set Combat Battle BGM (5); Load Sound Bank into Memory (0, 9); Set Combat Battle BGM (10); Load Sound Bank into Memory (1, 9); Engine Action #9; Toggle Random Encounters (4) |
| `ev[05]` | `128 (Loop)` | Story Flag 40 (bit 8) SET AND Story Flag 40 (bit 16) CLEAR AND Inventory Holds Item #8 | Set Combat Battle BGM (175); Display Chapter Text (1); Dismiss Emotion Bubble (4); Toggle Random Encounters (8) |
| `ev[06]` | `128 (Loop)` | Story Flag 40 (bit 8) SET AND Story Flag 40 (bit 16) CLEAR AND Inventory Holds Item #16 | Engine Action #89; Place Scenery Structure (2); Reset Camera Tracking (90); Place Scenery Structure (4); Engine Action #5; Dismiss Dialogue Portrait; Fade In from Black (30); Toggle Random Encounters (16) |
| `ev[07]` | `128 (Loop)` | Story Flag 40 (bit 8) SET AND Story Flag 40 (bit 16) CLEAR AND Inventory Holds Item #32 | Set Combat Battle BGM (45); Close Dialogue Window; Warp Town -> Area 2 Map 120 Submap 37 at (32,255) |

---


