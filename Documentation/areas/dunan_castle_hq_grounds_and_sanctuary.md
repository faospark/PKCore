# Suikoden II Geographic Area Catalog: Castle HQ: Grounds, Gardens & Animal Sanctuary

**Geographic Scope & Role**: Outer fortress courtyard and nature haven; Badeaux's wild animal habitats, courtyard garden paths, laundry lines, and shade trees.

**Regional Category**: Region `VK` | **Master Maps Included**: `vk11`, `vk18`

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

## Location Map: `vk11`

- **Master Map Container**: `vk11.json`
- **Submap Layer Files**: vk11_12.json, vk11_17.json
- **Collision Grid Files**: vk11_map_00.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 5

### Submap Layer `vk11_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `34` Objects | **Script Count (`evkaz`)**: `57` Scripts

#### Complete Physical Entity Inventory (34 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Bob** | `75` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Tetsu (Bathhouse)** | `76` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Hai Yo (Cook)** | `77` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | NPC / Actor | **Actor ID 78** | `78` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[04]` | NPC / Actor | **Actor ID 78** | `78` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[05]` | NPC / Actor | **Ayda** | `43` | `(33, 144)` | `5x5` | South (Down) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[06]` | NPC / Actor | **Badeaux** | `51` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[07]` | Prop / Scenery | **Prop ID 72** | `72` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Trigger / Hitbox | **Hitbox Zone (7x3)** | `0` | `(17, 33)` | `6x2` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(61, 135)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(59, 129)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(61, 125)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(43, 122)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(55, 122)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(25, 116)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[15]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(25, 106)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[16]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(25, 96)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[17]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(9, 96)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[18]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(9, 106)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[19]` | NPC / Actor | **Actor ID 65105** | `65105` | `(6, 25)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[20]` | NPC / Actor | **Actor ID 65199** | `65199` | `(19, 80)` | `7x5` | South (Down) | Dormant / Hidden (0) | Special (3) | 1 | 128 | 0 |
| `obj[21]` | NPC / Actor | **Actor ID 65086** | `65086` | `(19, 143)` | `10x10` | South (Down) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[22]` | NPC / Actor | **Actor ID 65042** | `65042` | `(48, 30)` | `0x0` | Up (North) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[23]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(47, 29)` | `2x1` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[24]` | NPC / Actor | **Actor ID 65184** | `65184` | `(13, 60)` | `10x10` | South (Down) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[25]` | NPC / Actor | **Actor ID 64786** | `64786` | `(36, 26)` | `7x4` | East (Right) | Dormant / Hidden (0) | Special (3) | 1 | 128 | 0 |
| `obj[26]` | NPC / Actor | **Actor ID 65164** | `65164` | `(32, 159)` | `4x7` | East (Right) | Dormant / Hidden (0) | Special (3) | 2 | 128 | 0 |
| `obj[27]` | NPC / Actor | **Actor ID 65107** | `65107` | `(45, 144)` | `7x4` | East (Right) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[28]` | NPC / Actor | **Market Vegetable Basket** | `65217` | `(48, 32)` | `0x0` | Up (North) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[29]` | NPC / Actor | **Actor ID 65208** | `65208` | `(8, 41)` | `7x4` | East (Right) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[30]` | NPC / Actor | **Actor ID 64961** | `64961` | `(38, 27)` | `7x4` | East (Right) | Dormant / Hidden (0) | Special (3) | 1 | 128 | 0 |
| `obj[31]` | NPC / Actor | **Actor ID 64961** | `64961` | `(35, 28)` | `7x4` | East (Right) | Dormant / Hidden (0) | Special (3) | 1 | 128 | 0 |
| `obj[32]` | NPC / Actor | **Actor ID 65011** | `65011` | `(43, 109)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[33]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(9, 116)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Bob)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Tetsu (Bathhouse))**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Hai Yo (Cook))**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Object 78)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Object 78)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Ayda)**: Positioned at tile `(33, 144)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[06]` (Badeaux)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[07]` (Prop: Object 72)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[08]` (Hitbox Zone)**: Bounding trigger area covering `7` tiles wide by `3` tiles high from `(17, 33)` to `(23, 35)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[09]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(61, 135)` to `(63, 137)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[10]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(59, 129)` to `(61, 131)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[11]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(61, 125)` to `(63, 127)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[12]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(43, 122)` to `(45, 124)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[13]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(55, 122)` to `(57, 124)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[14]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(25, 116)` to `(27, 118)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[15]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(25, 106)` to `(27, 108)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[16]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(25, 96)` to `(27, 98)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[17]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(9, 96)` to `(11, 98)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[18]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(9, 106)` to `(11, 108)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[19]` (Object 65105)**: Positioned at tile `(6, 25)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[20]` (Object 65199)**: Positioned at tile `(19, 80)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[21]` (Object 65086)**: Positioned at tile `(19, 143)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[22]` (Object 65042)**: Positioned at tile `(48, 30)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[23]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(47, 29)` to `(49, 30)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[24]` (Object 65184)**: Positioned at tile `(13, 60)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[25]` (Object 64786)**: Positioned at tile `(36, 26)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[26]` (Object 65164)**: Positioned at tile `(32, 159)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[27]` (Object 65107)**: Positioned at tile `(45, 144)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[28]` (Market Vegetable Basket)**: Positioned at tile `(48, 32)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[29]` (Object 65208)**: Positioned at tile `(8, 41)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[30]` (Object 64961)**: Positioned at tile `(38, 27)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[31]` (Object 64961)**: Positioned at tile `(35, 28)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[32]` (Object 65011)**: Positioned at tile `(43, 109)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[33]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(9, 116)` to `(11, 118)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (57 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #43 AND Player within Box [33..1, 3..35] AND Inventory Lacks Item #1 | Make obj[0] Hidden (disp = 0); Place Scenery Structure (47) |
| `ev[01]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Dismiss Emotion Bubble (0); Warp Room -> Submap 23 at (0,0) facing 255 |
| `ev[02]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #51 AND Player within Box [33..1, 3..255] | Make obj[0] Hidden (disp = 0); Animate Door Open; Warp Town -> Area 14 Map 19 Submap 39 at (3,14); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[03]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Dismiss Emotion Bubble (0); Warp Room -> Submap 23 at (0,1) facing 255 |
| `ev[04]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #72 AND Player within Box [33..1, 3..255] | Make obj[89] Hidden (disp = 0); Show Dialogue Portrait (2, 2, 2); Show Dialogue Portrait (15, 35, 0); Show Dialogue Portrait (0, 16, 47) |
| `ev[05]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Dismiss Emotion Bubble (0); Warp Room -> Submap 24 at (15,0) facing Up (North) |
| `ev[06]` | `128 (Loop)` | Player within Box [56..62, 2..113] AND Condition Check #176 AND Story Flag 144 (bit 32) CLEAR | Warp Room -> Submap 0 at (10,0) |
| `ev[07]` | `128 (Loop)` | Player within Box [56..62, 2..113] AND Condition Check #176 AND Story Flag 144 (bit 32) SET | Warp Room -> Submap 0 at (10,33) |
| `ev[08]` | `128 (Loop)` | Player within Box [30..53, 2..109] AND Condition Check #139 | Warp Room -> Submap 0 at (10,11) |
| `ev[09]` | `128 (Loop)` | Player within Box [22..53, 2..156] AND Condition Check #176 | Warp Room -> Submap 0 at (10,20) |
| `ev[10]` | `128 (Loop)` | Player within Box [2..36, 2..25] AND Condition Check #60 AND Story Flag 144 (bit 64) CLEAR | Engine Action #109; Screen Fade Transition (3, 255, 254) |
| `ev[11]` | `128 (Loop)` | Player within Box [2..36, 2..25] AND Condition Check #60 AND Story Flag 144 (bit 64) SET | Engine Action #109; Screen Fade Transition (4, 255, 254) |
| `ev[12]` | `1 (Action / Talk)` | Player within Box [64..66, 2..113] AND Condition Check #175 AND Story Flag 3 (mask 255) SET | Engine Action #111; Award Potch Loot (+1,280 Potch); Warp Room -> Submap 3 at (4,255) facing South (Down); Warp Room -> Submap 2 at (32,3) facing West (Left); Warp to Castle HQ (129, 255, 254); Warp to Castle HQ (255, 4, 32); Warp to Castle HQ (0, 3, 129) |
| `ev[13]` | `1 (Action / Talk)` | Player within Box [48..52, 2..107] AND Condition Check #108 AND Story Flag 1 (mask 255) SET | Warp Map Transition (3, 0, 62, 135, 255) |
| `ev[14]` | `1 (Action / Talk)` | Player within Box [8..12, 2..20] AND Inventory Holds Item #9 [Kindness Drops] AND Player within Box [4..144, 64..255] | Place Scenery Structure (5); Screen Fade Transition (3, 0, 32); Load Sound Bank into Memory (255, 254) |
| `ev[15]` | `1 (Action / Talk)` | Player within Box [8..12, 2..20] AND Inventory Holds Item #9 [Kindness Drops] AND Player within Box [3..144, 64..255] | Place Scenery Structure (5); Screen Fade Transition (4, 0, 32); Load Sound Bank into Memory (255, 254) |
| `ev[16]` | `1 (Action / Talk)` | Player within Box [36..44, 2..170] AND Condition Check #176 | Warp Map Transition (3, 0, 20, 47, 255) |
| `ev[17]` | `1 (Action / Talk)` | Player within Box [0..1, 2..22] AND Condition Check #53 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 36]; Return Warp to Castle Base (255, 254) |
| `ev[18]` | `2 (Map Init)` | Condition Check #33 AND Player X within Range [2..255] | Open Dialogue Message Window; Fade Out to Black (255) |
| `ev[19]` | `2 (Map Init)` | Condition Check #33 AND Player within Box [2..3, 112..64] | Open Dialogue Message Window; Display Chapter Text (255) |
| `ev[20]` | `2 (Map Init)` | Condition Check #33 AND Player within Box [2..3, 112..64] | Open Dialogue Message Window; Display Emotion Bubble (255, 254) |
| `ev[21]` | `2 (Map Init)` | Condition Check #33 AND Player within Box [2..3, 112..64] | Make obj[0] Hidden (disp = 0); Dismiss Emotion Bubble (0); Warp Room -> Submap 47 at (255,254) |
| `ev[22]` | `2 (Map Init)` | Story Flag 134 (bit 1) SET AND Story Flag 112 (bit 64) SET | Warp to Castle HQ (30, 0, 255) |
| `ev[23]` | `2 (Map Init)` | Condition Check #33 AND Player within Box [2..3, 112..64] | Open Dialogue Message Window; Warp Map Transition (255, 254, 204, 204, 204) |
| `ev[24]` | `2 (Map Init)` | Condition Check #33 AND Player X within Range [2..255] | Open Dialogue Message Window; Return to Previous Memory Map (255) |
| `ev[25]` | `2 (Map Init)` | Condition Check #33 AND Player within Box [3..3, 112..64] | Open Dialogue Message Window; Return Warp to Castle Base (255, 254) |
| `ev[26]` | `2 (Map Init)` | Condition Check #33 AND Player within Box [3..3, 112..64] | Open Dialogue Message Window; Start Boss Battle #255 (BGM: 254) |
| `ev[27]` | `2 (Map Init)` | Condition Check #33 AND Player within Box [3..3, 112..64] | Open Dialogue Message Window; Launch Tactical War Battle (255) |
| `ev[28]` | `2 (Map Init)` | Story Flag 134 (bit 1) SET AND Story Flag 112 (bit 64) SET | Warp to Castle HQ (36, 1, 255) |
| `ev[29]` | `2 (Map Init)` | Condition Check #33 AND Player within Box [4..3, 112..64] | Open Dialogue Message Window; Toggle Random Encounters (255) |
| `ev[30]` | `2 (Map Init)` | Condition Check #33 AND Player X within Range [3..255] | Open Dialogue Message Window; Open Save Crystal Menu (MSaveInit) |
| `ev[31]` | `2 (Map Init)` | Condition Check #33 AND Player X within Range [4..255] | Open Dialogue Message Window; Engine Action #39 |
| `ev[32]` | `2 (Map Init)` | Condition Check #33 AND Player X within Range [4..255] | Open Dialogue Message Window; Engine Action #40 |
| `ev[33]` | `1 (Action / Talk)` | Target Inspected is obj[27] | Dismiss Emotion Bubble (1); Warp Room -> Submap 23 at (2,0) facing 255 |
| `ev[34]` | `1 (Action / Talk)` | Target Inspected is obj[28] | Dismiss Emotion Bubble (1); Warp Room -> Submap 23 at (2,1) facing 255 |
| `ev[35]` | `1 (Action / Talk)` | Target Inspected is obj[29] | Dismiss Emotion Bubble (1); Warp Room -> Submap 23 at (2,2) facing 255 |
| `ev[36]` | `1 (Action / Talk)` | Target Inspected is obj[31] | Dismiss Emotion Bubble (1); Warp Room -> Submap 23 at (2,3) facing 255 |
| `ev[37]` | `1 (Action / Talk)` | Target Inspected is obj[32] | Dismiss Emotion Bubble (1); Warp Room -> Submap 23 at (2,4) facing 255 |
| `ev[38]` | `1 (Action / Talk)` | Target Inspected is obj[33] | Dismiss Emotion Bubble (1); Warp Room -> Submap 23 at (2,5) facing 255 |
| `ev[39]` | `1 (Action / Talk)` | Target Inspected is obj[34] | Dismiss Emotion Bubble (1); Warp Room -> Submap 23 at (2,6) facing 255 |
| `ev[40]` | `1 (Action / Talk)` | Target Inspected is obj[35] | Dismiss Emotion Bubble (1); Warp Room -> Submap 23 at (2,7) facing 255 |
| `ev[41]` | `1 (Action / Talk)` | Target Inspected is obj[36] | Dismiss Emotion Bubble (1); Warp Room -> Submap 23 at (2,8) facing 255 |
| `ev[42]` | `1 (Action / Talk)` | Target Inspected is obj[37] | Dismiss Emotion Bubble (1); Warp Room -> Submap 23 at (2,9) facing 255 |
| `ev[43]` | `1 (Action / Talk)` | Target Inspected is obj[38] | Dismiss Emotion Bubble (1); Warp Room -> Submap 23 at (2,10) facing 255 |
| `ev[44]` | `1 (Action / Talk)` | Target Inspected is obj[39] | Dismiss Emotion Bubble (1); Warp Room -> Submap 23 at (2,11) facing 255 |
| `ev[45]` | `1 (Action / Talk)` | Target Inspected is obj[40] | Dismiss Emotion Bubble (1); Warp Room -> Submap 23 at (2,12) facing 255 |
| `ev[46]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Close Dialogue Sub-Window (17); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[47]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Close Dialogue Sub-Window (18); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[48]` | `1 (Action / Talk)` | Target Inspected is obj[19] | Close Dialogue Sub-Window (19); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[49]` | `1 (Action / Talk)` | Target Inspected is obj[20] | Close Dialogue Sub-Window (20); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[50]` | `1 (Action / Talk)` | Target Inspected is obj[21] | Close Dialogue Sub-Window (21); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[51]` | `1 (Action / Talk)` | Target Inspected is obj[22] | Close Dialogue Sub-Window (22); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[52]` | `1 (Action / Talk)` | Target Inspected is obj[23] | Close Dialogue Sub-Window (23); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[53]` | `1 (Action / Talk)` | Target Inspected is obj[24] | Close Dialogue Sub-Window (24); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[54]` | `1 (Action / Talk)` | Target Inspected is obj[25] | Close Dialogue Sub-Window (25); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[55]` | `1 (Action / Talk)` | Target Inspected is obj[26] | Close Dialogue Sub-Window (26); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[56]` | `1 (Action / Talk)` | Target Inspected is obj[41] | Close Dialogue Sub-Window (41); Warp Room -> Submap 255 at (254,204) facing 204 |

---

### Submap Layer `vk11_01` (Index 1)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `8` Objects | **Script Count (`evkaz`)**: `14` Scripts

#### Complete Physical Entity Inventory (8 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(13, 15)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[01]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(19, 31)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(23, 21)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(23, 15)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(13, 21)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | NPC / Actor | **Actor ID 65008** | `65008` | `(24, 10)` | `0x0` | Up (North) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[06]` | NPC / Actor | **Actor ID 65153** | `65153` | `(29, 21)` | `4x2` | South (Down) | Dormant / Hidden (0) | Special (3) | 1 | 128 | 0 |
| `obj[07]` | NPC / Actor | **Actor ID 65047** | `65047` | `(17, 26)` | `7x5` | South (Down) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(13, 15)` to `(15, 17)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[01]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(19, 31)` to `(21, 33)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[02]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(23, 21)` to `(25, 23)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[03]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(23, 15)` to `(25, 17)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[04]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(13, 21)` to `(15, 23)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[05]` (Object 65008)**: Positioned at tile `(24, 10)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[06]` (Object 65153)**: Positioned at tile `(29, 21)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[07]` (Object 65047)**: Positioned at tile `(17, 26)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.


#### Complete Bytecode Script Catalog (14 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `128 (Loop)` | Player within Box [5..36, 2..10] AND Condition Check #41 | Warp Room -> Submap 0 at (10,2) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [16..22, 2..6] AND Temp Event Flag #9 SET AND Player X within Range [255..254] | Warp Map Transition (3, 0, 50, 47, 255) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [38..39, 2..10] AND Condition Check #41 AND Story Flag 3 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 3]; Teleport obj[255] to (254,204) |
| `ev[03]` | `2 (Map Init)` | Condition Check #33 AND Player X within Range [3..255] | Open Dialogue Message Window; Place Scenery Structure (255) |
| `ev[04]` | `2 (Map Init)` | Condition Check #33 AND Player within Box [3..3, 112..64] | Open Dialogue Message Window; Animate Door Open |
| `ev[05]` | `2 (Map Init)` | Condition Check #33 AND Player within Box [4..3, 112..64] | Open Dialogue Message Window; Show Dialogue Portrait (255, 254, 204) |
| `ev[06]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Dismiss Emotion Bubble (1); Warp Room -> Submap 23 at (2,13) facing 255 |
| `ev[07]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Dismiss Emotion Bubble (1); Warp Room -> Submap 23 at (2,14) facing 255 |
| `ev[08]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Dismiss Emotion Bubble (1); Warp Room -> Submap 23 at (2,15) facing 255 |
| `ev[09]` | `1 (Action / Talk)` | Target Inspected is obj[8] | Close Dialogue Sub-Window (8); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[10]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Close Dialogue Sub-Window (9); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[11]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Close Dialogue Sub-Window (10); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[12]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Close Dialogue Sub-Window (11); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[13]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Close Dialogue Sub-Window (12); Warp Room -> Submap 255 at (254,204) facing 204 |

---

### Submap Layer `vk11_02` (Index 2)

- **Map Number (`mapno`)**: `2`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `31` Objects | **Script Count (`evkaz`)**: `50` Scripts

#### Complete Physical Entity Inventory (31 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Bob** | `75` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Tetsu (Bathhouse)** | `76` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Hai Yo (Cook)** | `77` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | NPC / Actor | **Actor ID 78** | `78` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[04]` | NPC / Actor | **Actor ID 78** | `78` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[05]` | NPC / Actor | **Ayda** | `43` | `(33, 144)` | `5x5` | South (Down) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[06]` | NPC / Actor | **Badeaux** | `51` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[07]` | Prop / Scenery | **Prop ID 72** | `72` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Trigger / Hitbox | **Hitbox Zone (7x3)** | `0` | `(17, 33)` | `6x2` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(61, 135)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(59, 129)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(61, 125)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(25, 116)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(25, 106)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(25, 96)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[15]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(9, 96)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[16]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(9, 106)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[17]` | NPC / Actor | **Actor ID 65105** | `65105` | `(6, 25)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[18]` | NPC / Actor | **Actor ID 65199** | `65199` | `(19, 80)` | `7x5` | South (Down) | Dormant / Hidden (0) | Special (3) | 1 | 128 | 0 |
| `obj[19]` | NPC / Actor | **Actor ID 65086** | `65086` | `(19, 143)` | `10x10` | South (Down) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[20]` | NPC / Actor | **Actor ID 65042** | `65042` | `(48, 30)` | `0x0` | Up (North) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[21]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(47, 29)` | `2x1` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[22]` | NPC / Actor | **Actor ID 65184** | `65184` | `(13, 60)` | `10x10` | South (Down) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[23]` | NPC / Actor | **Actor ID 64786** | `64786` | `(36, 26)` | `7x4` | East (Right) | Dormant / Hidden (0) | Special (3) | 1 | 128 | 0 |
| `obj[24]` | NPC / Actor | **Actor ID 65164** | `65164` | `(32, 159)` | `4x7` | East (Right) | Dormant / Hidden (0) | Special (3) | 2 | 128 | 0 |
| `obj[25]` | NPC / Actor | **Actor ID 65107** | `65107` | `(45, 144)` | `7x4` | East (Right) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[26]` | NPC / Actor | **Market Vegetable Basket** | `65217` | `(48, 32)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[27]` | NPC / Actor | **Actor ID 65208** | `65208` | `(8, 41)` | `7x4` | East (Right) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[28]` | NPC / Actor | **Actor ID 64961** | `64961` | `(38, 27)` | `7x4` | East (Right) | Dormant / Hidden (0) | Special (3) | 1 | 128 | 0 |
| `obj[29]` | NPC / Actor | **Actor ID 64961** | `64961` | `(35, 28)` | `7x4` | East (Right) | Dormant / Hidden (0) | Special (3) | 1 | 128 | 0 |
| `obj[30]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(9, 116)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Bob)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Tetsu (Bathhouse))**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Hai Yo (Cook))**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Object 78)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Object 78)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Ayda)**: Positioned at tile `(33, 144)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[06]` (Badeaux)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[07]` (Prop: Object 72)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[08]` (Hitbox Zone)**: Bounding trigger area covering `7` tiles wide by `3` tiles high from `(17, 33)` to `(23, 35)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[09]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(61, 135)` to `(63, 137)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[10]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(59, 129)` to `(61, 131)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[11]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(61, 125)` to `(63, 127)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[12]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(25, 116)` to `(27, 118)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[13]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(25, 106)` to `(27, 108)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[14]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(25, 96)` to `(27, 98)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[15]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(9, 96)` to `(11, 98)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[16]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(9, 106)` to `(11, 108)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[17]` (Object 65105)**: Positioned at tile `(6, 25)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[18]` (Object 65199)**: Positioned at tile `(19, 80)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[19]` (Object 65086)**: Positioned at tile `(19, 143)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[20]` (Object 65042)**: Positioned at tile `(48, 30)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[21]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(47, 29)` to `(49, 30)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[22]` (Object 65184)**: Positioned at tile `(13, 60)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[23]` (Object 64786)**: Positioned at tile `(36, 26)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[24]` (Object 65164)**: Positioned at tile `(32, 159)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[25]` (Object 65107)**: Positioned at tile `(45, 144)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[26]` (Market Vegetable Basket)**: Positioned at tile `(48, 32)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[27]` (Object 65208)**: Positioned at tile `(8, 41)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[28]` (Object 64961)**: Positioned at tile `(38, 27)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[29]` (Object 64961)**: Positioned at tile `(35, 28)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[30]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(9, 116)` to `(11, 118)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (50 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #43 AND Player within Box [33..1, 3..35] AND Inventory Lacks Item #1 | Make obj[0] Hidden (disp = 0); Place Scenery Structure (47) |
| `ev[01]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Dismiss Emotion Bubble (0); Warp Room -> Submap 23 at (0,3) facing 255 |
| `ev[02]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #51 AND Player within Box [33..1, 3..255] | Make obj[2] Hidden (disp = 0); Animate Door Open; Display Choice Selection (39, 3); Animate Door Open; Warp Room -> Submap 14 at (47,255) facing 254 |
| `ev[03]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Dismiss Emotion Bubble (0); Warp Room -> Submap 23 at (0,4) facing 255 |
| `ev[04]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #72 AND Player within Box [33..1, 3..255] | Make obj[89] Hidden (disp = 0); Show Dialogue Portrait (2, 2, 2); Show Dialogue Portrait (15, 35, 0); Show Dialogue Portrait (0, 16, 47) |
| `ev[05]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Dismiss Emotion Bubble (0); Warp Room -> Submap 24 at (15,0) facing 5 |
| `ev[06]` | `128 (Loop)` | Player within Box [56..62, 2..113] AND Condition Check #176 AND Story Flag 144 (bit 32) CLEAR | Warp Room -> Submap 0 at (10,0) |
| `ev[07]` | `128 (Loop)` | Player within Box [56..62, 2..113] AND Condition Check #176 AND Story Flag 144 (bit 32) SET | Warp Room -> Submap 0 at (10,33) |
| `ev[08]` | `128 (Loop)` | Player within Box [33..53, 2..140] AND Condition Check #176 | Warp Room -> Submap 0 at (10,20) |
| `ev[09]` | `128 (Loop)` | Player within Box [2..36, 2..25] AND Condition Check #60 AND Story Flag 144 (bit 64) CLEAR | Engine Action #109; Screen Fade Transition (3, 255, 254) |
| `ev[10]` | `128 (Loop)` | Player within Box [2..36, 2..25] AND Condition Check #60 AND Story Flag 144 (bit 64) SET | Engine Action #109; Screen Fade Transition (4, 255, 254) |
| `ev[11]` | `1 (Action / Talk)` | Player within Box [64..65, 2..113] AND Condition Check #175 AND Story Flag 3 (mask 255) SET | Engine Action #111; Award Potch Loot (+1,280 Potch); Warp Room -> Submap 3 at (4,255) facing South (Down); Warp Room -> Submap 2 at (32,3) facing West (Left); Warp to Castle HQ (129, 255, 254); Warp to Castle HQ (255, 4, 32); Warp to Castle HQ (0, 3, 129) |
| `ev[12]` | `1 (Action / Talk)` | Player within Box [8..12, 2..20] AND Inventory Holds Item #9 [Kindness Drops] AND Player within Box [4..144, 64..255] | Place Scenery Structure (5); Screen Fade Transition (3, 0, 32); Load Sound Bank into Memory (255, 254) |
| `ev[13]` | `1 (Action / Talk)` | Player within Box [8..12, 2..20] AND Inventory Holds Item #9 [Kindness Drops] AND Player within Box [3..144, 64..255] | Place Scenery Structure (5); Screen Fade Transition (4, 0, 32); Load Sound Bank into Memory (255, 254) |
| `ev[14]` | `1 (Action / Talk)` | Player within Box [36..44, 2..170] AND Condition Check #176 | Warp Map Transition (3, 0, 20, 47, 255) |
| `ev[15]` | `1 (Action / Talk)` | Player within Box [0..1, 2..22] AND Condition Check #53 AND Story Flag 2 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 36]; Return Warp to Castle Base (255, 254) |
| `ev[16]` | `2 (Map Init)` | Condition Check #33 AND Player X within Range [2..255] | Open Dialogue Message Window; Clear Dialogue Sub-Window |
| `ev[17]` | `2 (Map Init)` | Condition Check #33 AND Player within Box [2..3, 112..64] | Open Dialogue Message Window; Fade In from Black (255) |
| `ev[18]` | `2 (Map Init)` | Condition Check #33 AND Player within Box [2..3, 112..64] | Open Dialogue Message Window; Fade Out to Black (255) |
| `ev[19]` | `2 (Map Init)` | Condition Check #33 AND Player within Box [2..3, 112..64] | Make obj[0] Hidden (disp = 0); Display Chapter Text (0); Display Emotion Bubble (47, 255) |
| `ev[20]` | `2 (Map Init)` | Story Flag 134 (bit 1) SET AND Story Flag 112 (bit 64) SET | Warp to Castle HQ (28, 0, 255) |
| `ev[21]` | `2 (Map Init)` | Condition Check #33 AND Player within Box [2..3, 112..64] | Open Dialogue Message Window; Dismiss Emotion Bubble (255) |
| `ev[22]` | `2 (Map Init)` | Condition Check #33 AND Player X within Range [3..255] | Open Dialogue Message Window; Warp Room -> Submap 255 at (254,204) |
| `ev[23]` | `2 (Map Init)` | Condition Check #33 AND Player within Box [3..3, 112..64] | Open Dialogue Message Window; Warp Map Transition (255, 254, 204, 204, 204) |
| `ev[24]` | `2 (Map Init)` | Condition Check #33 AND Player within Box [3..3, 112..64] | Open Dialogue Message Window; Return to Previous Memory Map (255) |
| `ev[25]` | `2 (Map Init)` | Condition Check #33 AND Player within Box [3..3, 112..64] | Open Dialogue Message Window; Return Warp to Castle Base (255, 254) |
| `ev[26]` | `2 (Map Init)` | Condition Check #33 AND Player within Box [4..3, 112..64] | Open Dialogue Message Window; Start Boss Battle #255 (BGM: 254) |
| `ev[27]` | `2 (Map Init)` | Condition Check #33 AND Player X within Range [3..255] | Open Dialogue Message Window; Launch Tactical War Battle (255) |
| `ev[28]` | `2 (Map Init)` | Condition Check #33 AND Player X within Range [4..255] | Open Dialogue Message Window; Toggle Random Encounters (255) |
| `ev[29]` | `1 (Action / Talk)` | Target Inspected is obj[25] | Dismiss Emotion Bubble (1); Warp Room -> Submap 23 at (2,16) facing 255 |
| `ev[30]` | `1 (Action / Talk)` | Target Inspected is obj[26] | Dismiss Emotion Bubble (1); Warp Room -> Submap 23 at (2,17) facing 255 |
| `ev[31]` | `1 (Action / Talk)` | Target Inspected is obj[27] | Dismiss Emotion Bubble (1); Warp Room -> Submap 23 at (2,18) facing 255 |
| `ev[32]` | `1 (Action / Talk)` | Target Inspected is obj[29] | Dismiss Emotion Bubble (1); Warp Room -> Submap 23 at (2,19) facing 255 |
| `ev[33]` | `1 (Action / Talk)` | Target Inspected is obj[30] | Dismiss Emotion Bubble (1); Warp Room -> Submap 23 at (2,20) facing 255 |
| `ev[34]` | `1 (Action / Talk)` | Target Inspected is obj[31] | Dismiss Emotion Bubble (1); Warp Room -> Submap 23 at (2,21) facing 255 |
| `ev[35]` | `1 (Action / Talk)` | Target Inspected is obj[32] | Dismiss Emotion Bubble (1); Warp Room -> Submap 23 at (2,22) facing 255 |
| `ev[36]` | `1 (Action / Talk)` | Target Inspected is obj[33] | Dismiss Emotion Bubble (1); Warp Room -> Submap 23 at (2,23) facing 255 |
| `ev[37]` | `1 (Action / Talk)` | Target Inspected is obj[34] | Dismiss Emotion Bubble (1); Warp Room -> Submap 23 at (2,24) facing 255 |
| `ev[38]` | `1 (Action / Talk)` | Target Inspected is obj[35] | Dismiss Emotion Bubble (1); Warp Room -> Submap 23 at (2,25) facing 255 |
| `ev[39]` | `1 (Action / Talk)` | Target Inspected is obj[36] | Dismiss Emotion Bubble (1); Warp Room -> Submap 23 at (2,26) facing 255 |
| `ev[40]` | `1 (Action / Talk)` | Target Inspected is obj[37] | Dismiss Emotion Bubble (1); Warp Room -> Submap 23 at (2,27) facing 255 |
| `ev[41]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Close Dialogue Sub-Window (17); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[42]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Close Dialogue Sub-Window (18); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[43]` | `1 (Action / Talk)` | Target Inspected is obj[19] | Close Dialogue Sub-Window (19); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[44]` | `1 (Action / Talk)` | Target Inspected is obj[20] | Close Dialogue Sub-Window (20); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[45]` | `1 (Action / Talk)` | Target Inspected is obj[21] | Close Dialogue Sub-Window (21); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[46]` | `1 (Action / Talk)` | Target Inspected is obj[22] | Close Dialogue Sub-Window (22); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[47]` | `1 (Action / Talk)` | Target Inspected is obj[23] | Close Dialogue Sub-Window (23); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[48]` | `1 (Action / Talk)` | Target Inspected is obj[24] | Close Dialogue Sub-Window (24); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[49]` | `1 (Action / Talk)` | Target Inspected is obj[38] | Close Dialogue Sub-Window (38); Warp Room -> Submap 255 at (254,204) facing 204 |

---

### Submap Layer `vk11_03` (Index 3)

- **Map Number (`mapno`)**: `3`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `28` Objects | **Script Count (`evkaz`)**: `38` Scripts

#### Complete Physical Entity Inventory (28 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Bob** | `75` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Tetsu (Bathhouse)** | `76` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Hai Yo (Cook)** | `77` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | NPC / Actor | **Actor ID 78** | `78` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[04]` | NPC / Actor | **Actor ID 78** | `78` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[05]` | NPC / Actor | **Ayda** | `43` | `(33, 144)` | `5x5` | South (Down) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[06]` | NPC / Actor | **Actor ID 73** | `73` | `(34, 56)` | `5x5` | South (Down) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[07]` | NPC / Actor | **Wakaba** | `68` | `(13, 101)` | `5x5` | South (Down) | Dormant / Hidden (0) | Special (3) | 3 | 255 | 0 |
| `obj[08]` | Prop / Scenery | **Prop ID 72** | `72` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Trigger / Hitbox | **Hitbox Zone (7x3)** | `0` | `(17, 33)` | `6x2` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(25, 116)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(25, 106)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(25, 96)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(9, 96)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(9, 106)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[15]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(55, 136)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[16]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(43, 136)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[17]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(61, 135)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[18]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(59, 129)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[19]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(61, 125)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[20]` | NPC / Actor | **Actor ID 65105** | `65105` | `(6, 25)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[21]` | NPC / Actor | **Actor ID 65199** | `65199` | `(19, 80)` | `7x5` | South (Down) | Dormant / Hidden (0) | Special (3) | 1 | 128 | 0 |
| `obj[22]` | NPC / Actor | **Actor ID 65086** | `65086` | `(19, 143)` | `10x10` | South (Down) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[23]` | NPC / Actor | **Actor ID 65042** | `65042` | `(48, 30)` | `0x0` | Up (North) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[24]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(47, 29)` | `2x1` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[25]` | NPC / Actor | **Actor ID 65184** | `65184` | `(13, 60)` | `10x10` | South (Down) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[26]` | NPC / Actor | **Actor ID 64786** | `64786` | `(36, 26)` | `7x4` | East (Right) | Dormant / Hidden (0) | Special (3) | 1 | 128 | 0 |
| `obj[27]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(9, 116)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Bob)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Tetsu (Bathhouse))**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Hai Yo (Cook))**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Object 78)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Object 78)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Ayda)**: Positioned at tile `(33, 144)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[06]` (Object 73)**: Positioned at tile `(34, 56)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[07]` (Wakaba)**: Positioned at tile `(13, 101)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[08]` (Prop: Object 72)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[09]` (Hitbox Zone)**: Bounding trigger area covering `7` tiles wide by `3` tiles high from `(17, 33)` to `(23, 35)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[10]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(25, 116)` to `(27, 118)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[11]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(25, 106)` to `(27, 108)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[12]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(25, 96)` to `(27, 98)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[13]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(9, 96)` to `(11, 98)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[14]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(9, 106)` to `(11, 108)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[15]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(55, 136)` to `(57, 138)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[16]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(43, 136)` to `(45, 138)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[17]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(61, 135)` to `(63, 137)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[18]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(59, 129)` to `(61, 131)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[19]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(61, 125)` to `(63, 127)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[20]` (Object 65105)**: Positioned at tile `(6, 25)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[21]` (Object 65199)**: Positioned at tile `(19, 80)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[22]` (Object 65086)**: Positioned at tile `(19, 143)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[23]` (Object 65042)**: Positioned at tile `(48, 30)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[24]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(47, 29)` to `(49, 30)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[25]` (Object 65184)**: Positioned at tile `(13, 60)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[26]` (Object 64786)**: Positioned at tile `(36, 26)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[27]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(9, 116)` to `(11, 118)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (38 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #43 AND Player within Box [33..0, 2..35] AND Inventory Lacks Item #1 | Make obj[0] Hidden (disp = 0); Place Scenery Structure (47) |
| `ev[01]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Dismiss Emotion Bubble (0); Warp Room -> Submap 23 at (0,6) facing 255 |
| `ev[02]` | `2 (Map Init)` | Story Flag 47 (bit 128) CLEAR AND Condition Check #23 AND Condition Check #73 AND Player within Box [33..0, 2..35] AND Condition Check #25 AND Condition Check #64 | Make obj[0] Hidden (disp = 0); Animate Door Open; Teleport obj[255] to (254,204) |
| `ev[03]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Dismiss Emotion Bubble (0); Warp Room -> Submap 23 at (0,7) facing 255 |
| `ev[04]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #68 AND Player within Box [33..0, 2..35] AND Condition Check #23 AND Story Flag 255 (bit 254) CLEAR | Make obj[0] Hidden (disp = 0); Show Dialogue Portrait (47, 255, 254) |
| `ev[05]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Dismiss Emotion Bubble (0); Warp Room -> Submap 23 at (0,8) facing 255 |
| `ev[06]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #72 AND Player within Box [33..0, 2..255] | Make obj[89] Hidden (disp = 0); Dismiss Dialogue Portrait; Warp Town -> Area 2 Map 2 Submap 16 at (15,35); Open Dialogue Message Window; Dismiss Dialogue Portrait; Open Dialogue Message Window; Change Portrait Expression (47) |
| `ev[07]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Dismiss Emotion Bubble (0); Warp Room -> Submap 24 at (16,0) facing 9 |
| `ev[08]` | `128 (Loop)` | Player within Box [56..62, 2..113] AND Condition Check #176 AND Story Flag 144 (bit 32) CLEAR | Warp Room -> Submap 0 at (10,0) |
| `ev[09]` | `128 (Loop)` | Player within Box [56..62, 2..113] AND Condition Check #176 AND Story Flag 144 (bit 32) SET | Warp Room -> Submap 0 at (10,33) |
| `ev[10]` | `128 (Loop)` | Player within Box [2..36, 2..25] AND Condition Check #60 AND Story Flag 144 (bit 64) CLEAR | Engine Action #109; Screen Fade Transition (3, 255, 254) |
| `ev[11]` | `128 (Loop)` | Player within Box [2..36, 2..25] AND Condition Check #60 AND Story Flag 144 (bit 64) SET | Engine Action #109; Screen Fade Transition (4, 255, 254) |
| `ev[12]` | `1 (Action / Talk)` | Player within Box [64..65, 2..113] AND Condition Check #175 AND Story Flag 3 (mask 255) SET | Engine Action #111; Award Potch Loot (+1,280 Potch); Warp Room -> Submap 3 at (4,255) facing South (Down); Warp Room -> Submap 2 at (32,3) facing West (Left); Warp to Castle HQ (129, 255, 254); Warp to Castle HQ (255, 4, 32); Warp to Castle HQ (0, 3, 129) |
| `ev[13]` | `1 (Action / Talk)` | Player within Box [8..12, 2..20] AND Inventory Holds Item #9 [Kindness Drops] AND Player within Box [4..144, 64..255] | Place Scenery Structure (5); Screen Fade Transition (3, 0, 32); Load Sound Bank into Memory (255, 254) |
| `ev[14]` | `1 (Action / Talk)` | Player within Box [8..12, 2..20] AND Inventory Holds Item #9 [Kindness Drops] AND Player within Box [3..144, 64..255] | Place Scenery Structure (5); Screen Fade Transition (4, 0, 32); Load Sound Bank into Memory (255, 254) |
| `ev[15]` | `2 (Map Init)` | Condition Check #33 AND Player X within Range [2..255] | Open Dialogue Message Window; Display Chapter Text (255) |
| `ev[16]` | `2 (Map Init)` | Condition Check #33 AND Player within Box [2..3, 112..64] | Open Dialogue Message Window; Display Emotion Bubble (255, 254) |
| `ev[17]` | `2 (Map Init)` | Condition Check #33 AND Player within Box [2..3, 112..64] | Open Dialogue Message Window; Dismiss Emotion Bubble (255) |
| `ev[18]` | `2 (Map Init)` | Condition Check #33 AND Player within Box [2..3, 112..64] | Make obj[0] Hidden (disp = 0); Warp Room -> Submap 0 at (32,47) |
| `ev[19]` | `2 (Map Init)` | Condition Check #33 AND Player within Box [2..3, 112..64] | Open Dialogue Message Window; Return to Previous Memory Map (255) |
| `ev[20]` | `2 (Map Init)` | Condition Check #33 AND Player X within Range [2..255] | Open Dialogue Message Window; Return Warp to Castle Base (255, 254) |
| `ev[21]` | `1 (Action / Talk)` | Target Inspected is obj[28] | Dismiss Emotion Bubble (1); Warp Room -> Submap 23 at (2,28) facing 255 |
| `ev[22]` | `1 (Action / Talk)` | Target Inspected is obj[29] | Dismiss Emotion Bubble (1); Warp Room -> Submap 23 at (2,29) facing 255 |
| `ev[23]` | `1 (Action / Talk)` | Target Inspected is obj[30] | Dismiss Emotion Bubble (1); Warp Room -> Submap 23 at (2,30) facing 255 |
| `ev[24]` | `1 (Action / Talk)` | Target Inspected is obj[32] | Dismiss Emotion Bubble (1); Warp Room -> Submap 23 at (2,31) facing 255 |
| `ev[25]` | `1 (Action / Talk)` | Target Inspected is obj[33] | Dismiss Emotion Bubble (1); Warp Room -> Submap 23 at (2,32) facing 255 |
| `ev[26]` | `1 (Action / Talk)` | Target Inspected is obj[34] | Dismiss Emotion Bubble (1); Warp Room -> Submap 23 at (2,33) facing 255 |
| `ev[27]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Close Dialogue Sub-Window (18); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[28]` | `1 (Action / Talk)` | Target Inspected is obj[19] | Close Dialogue Sub-Window (19); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[29]` | `1 (Action / Talk)` | Target Inspected is obj[20] | Close Dialogue Sub-Window (20); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[30]` | `1 (Action / Talk)` | Target Inspected is obj[21] | Close Dialogue Sub-Window (21); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[31]` | `1 (Action / Talk)` | Target Inspected is obj[22] | Close Dialogue Sub-Window (22); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[32]` | `1 (Action / Talk)` | Target Inspected is obj[23] | Close Dialogue Sub-Window (23); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[33]` | `1 (Action / Talk)` | Target Inspected is obj[24] | Close Dialogue Sub-Window (24); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[34]` | `1 (Action / Talk)` | Target Inspected is obj[25] | Close Dialogue Sub-Window (25); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[35]` | `1 (Action / Talk)` | Target Inspected is obj[26] | Close Dialogue Sub-Window (26); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[36]` | `1 (Action / Talk)` | Target Inspected is obj[27] | Close Dialogue Sub-Window (27); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[37]` | `1 (Action / Talk)` | Target Inspected is obj[35] | Close Dialogue Sub-Window (35); Warp Room -> Submap 255 at (254,204) facing 204 |

---

### Submap Layer `vk11_04` (Index 4)

- **Map Number (`mapno`)**: `4`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `29` Objects | **Script Count (`evkaz`)**: `41` Scripts

#### Complete Physical Entity Inventory (29 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Bob** | `75` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Tetsu (Bathhouse)** | `76` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Hai Yo (Cook)** | `77` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | NPC / Actor | **Actor ID 78** | `78` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[04]` | NPC / Actor | **Actor ID 78** | `78` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[05]` | NPC / Actor | **Ayda** | `43` | `(33, 144)` | `5x5` | South (Down) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[06]` | NPC / Actor | **Actor ID 73** | `73` | `(34, 56)` | `5x5` | South (Down) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[07]` | NPC / Actor | **Wakaba** | `68` | `(13, 101)` | `5x5` | South (Down) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[08]` | Prop / Scenery | **Prop ID 72** | `72` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Trigger / Hitbox | **Hitbox Zone (7x3)** | `0` | `(17, 33)` | `6x2` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(25, 116)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(25, 106)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(25, 96)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(9, 96)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(9, 106)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[15]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(55, 136)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[16]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(43, 136)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[17]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(43, 122)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[18]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(61, 135)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[19]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(61, 125)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[20]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(59, 129)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[21]` | NPC / Actor | **Actor ID 65105** | `65105` | `(6, 25)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[22]` | NPC / Actor | **Actor ID 65199** | `65199` | `(19, 80)` | `7x5` | South (Down) | Dormant / Hidden (0) | Special (3) | 1 | 255 | 0 |
| `obj[23]` | NPC / Actor | **Actor ID 65086** | `65086` | `(19, 143)` | `10x10` | South (Down) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[24]` | NPC / Actor | **Actor ID 65042** | `65042` | `(48, 30)` | `0x0` | Up (North) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[25]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(47, 29)` | `2x1` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[26]` | NPC / Actor | **Actor ID 65184** | `65184` | `(13, 60)` | `10x10` | South (Down) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[27]` | NPC / Actor | **Actor ID 64786** | `64786` | `(36, 26)` | `7x4` | East (Right) | Dormant / Hidden (0) | Special (3) | 1 | 128 | 0 |
| `obj[28]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(9, 116)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Bob)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Tetsu (Bathhouse))**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Hai Yo (Cook))**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Object 78)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Object 78)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Ayda)**: Positioned at tile `(33, 144)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[06]` (Object 73)**: Positioned at tile `(34, 56)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[07]` (Wakaba)**: Positioned at tile `(13, 101)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[08]` (Prop: Object 72)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[09]` (Hitbox Zone)**: Bounding trigger area covering `7` tiles wide by `3` tiles high from `(17, 33)` to `(23, 35)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[10]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(25, 116)` to `(27, 118)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[11]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(25, 106)` to `(27, 108)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[12]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(25, 96)` to `(27, 98)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[13]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(9, 96)` to `(11, 98)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[14]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(9, 106)` to `(11, 108)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[15]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(55, 136)` to `(57, 138)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[16]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(43, 136)` to `(45, 138)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[17]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(43, 122)` to `(45, 124)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[18]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(61, 135)` to `(63, 137)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[19]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(61, 125)` to `(63, 127)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[20]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(59, 129)` to `(61, 131)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[21]` (Object 65105)**: Positioned at tile `(6, 25)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[22]` (Object 65199)**: Positioned at tile `(19, 80)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[23]` (Object 65086)**: Positioned at tile `(19, 143)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[24]` (Object 65042)**: Positioned at tile `(48, 30)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[25]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(47, 29)` to `(49, 30)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[26]` (Object 65184)**: Positioned at tile `(13, 60)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[27]` (Object 64786)**: Positioned at tile `(36, 26)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[28]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(9, 116)` to `(11, 118)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (41 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #43 AND Player within Box [33..0, 2..35] AND Inventory Lacks Item #1 | Make obj[0] Hidden (disp = 0); Place Scenery Structure (47) |
| `ev[01]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Dismiss Emotion Bubble (0); Warp Room -> Submap 23 at (0,10) facing 255 |
| `ev[02]` | `2 (Map Init)` | Story Flag 47 (bit 128) CLEAR AND Condition Check #23 AND Condition Check #73 AND Player within Box [33..0, 2..35] AND Condition Check #25 AND Condition Check #64 | Make obj[0] Hidden (disp = 0); Animate Door Open; Teleport obj[255] to (254,204) |
| `ev[03]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Dismiss Emotion Bubble (0); Warp Room -> Submap 23 at (0,11) facing 255 |
| `ev[04]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #68 AND Player within Box [33..0, 2..35] AND Condition Check #23 AND Story Flag 255 (bit 254) CLEAR | Make obj[0] Hidden (disp = 0); Show Dialogue Portrait (47, 255, 254) |
| `ev[05]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Dismiss Emotion Bubble (0); Warp Room -> Submap 23 at (0,12) facing 255 |
| `ev[06]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #72 AND Player within Box [33..0, 2..255] | Make obj[89] Hidden (disp = 0); Dismiss Dialogue Portrait; Warp Town -> Area 2 Map 2 Submap 16 at (15,35); Open Dialogue Message Window; Dismiss Dialogue Portrait; Open Dialogue Message Window; Change Portrait Expression (47) |
| `ev[07]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Dismiss Emotion Bubble (0); Warp Room -> Submap 24 at (16,0) facing 13 |
| `ev[08]` | `128 (Loop)` | Player within Box [56..62, 2..113] AND Condition Check #176 AND Story Flag 144 (bit 32) CLEAR | Warp Room -> Submap 0 at (10,0) |
| `ev[09]` | `128 (Loop)` | Player within Box [56..62, 2..113] AND Condition Check #176 AND Story Flag 144 (bit 32) SET | Warp Room -> Submap 0 at (10,33) |
| `ev[10]` | `128 (Loop)` | Player within Box [30..53, 2..109] AND Condition Check #139 | Warp Room -> Submap 0 at (10,11) |
| `ev[11]` | `128 (Loop)` | Player within Box [2..36, 2..25] AND Condition Check #60 AND Story Flag 144 (bit 64) CLEAR | Engine Action #109; Screen Fade Transition (3, 255, 254) |
| `ev[12]` | `128 (Loop)` | Player within Box [2..36, 2..25] AND Condition Check #60 AND Story Flag 144 (bit 64) SET | Engine Action #109; Screen Fade Transition (4, 255, 254) |
| `ev[13]` | `1 (Action / Talk)` | Player within Box [64..66, 2..113] AND Condition Check #175 AND Story Flag 3 (mask 255) SET | Engine Action #111; Award Potch Loot (+1,280 Potch); Warp Room -> Submap 3 at (4,255) facing South (Down); Warp Room -> Submap 2 at (32,3) facing West (Left); Warp to Castle HQ (129, 255, 254); Warp to Castle HQ (255, 4, 32); Warp to Castle HQ (0, 3, 129) |
| `ev[14]` | `1 (Action / Talk)` | Player within Box [48..52, 2..107] AND Condition Check #108 AND Story Flag 1 (mask 255) SET | Warp Map Transition (3, 0, 62, 135, 255) |
| `ev[15]` | `1 (Action / Talk)` | Player within Box [8..12, 2..20] AND Inventory Holds Item #9 [Kindness Drops] AND Player within Box [4..144, 64..255] | Place Scenery Structure (5); Screen Fade Transition (3, 0, 32); Load Sound Bank into Memory (255, 254) |
| `ev[16]` | `1 (Action / Talk)` | Player within Box [8..12, 2..20] AND Inventory Holds Item #9 [Kindness Drops] AND Player within Box [3..144, 64..255] | Place Scenery Structure (5); Screen Fade Transition (4, 0, 32); Load Sound Bank into Memory (255, 254) |
| `ev[17]` | `2 (Map Init)` | Condition Check #33 AND Player X within Range [2..255] | Open Dialogue Message Window; Display Emotion Bubble (255, 254) |
| `ev[18]` | `2 (Map Init)` | Condition Check #33 AND Player within Box [2..3, 112..64] | Open Dialogue Message Window; Dismiss Emotion Bubble (255) |
| `ev[19]` | `2 (Map Init)` | Condition Check #33 AND Player within Box [2..3, 112..64] | Open Dialogue Message Window; Warp Room -> Submap 255 at (254,204) |
| `ev[20]` | `2 (Map Init)` | Condition Check #33 AND Player within Box [2..3, 112..64] | Make obj[0] Hidden (disp = 0); Warp Map Transition (0, 33, 47, 255, 254) |
| `ev[21]` | `2 (Map Init)` | Condition Check #33 AND Player within Box [2..3, 112..64] | Open Dialogue Message Window; Return Warp to Castle Base (255, 254) |
| `ev[22]` | `2 (Map Init)` | Condition Check #33 AND Player X within Range [2..255] | Open Dialogue Message Window; Start Boss Battle #255 (BGM: 254) |
| `ev[23]` | `1 (Action / Talk)` | Target Inspected is obj[29] | Dismiss Emotion Bubble (1); Warp Room -> Submap 23 at (2,34) facing 255 |
| `ev[24]` | `1 (Action / Talk)` | Target Inspected is obj[30] | Dismiss Emotion Bubble (1); Warp Room -> Submap 23 at (2,35) facing 255 |
| `ev[25]` | `1 (Action / Talk)` | Target Inspected is obj[31] | Dismiss Emotion Bubble (1); Warp Room -> Submap 23 at (2,36) facing 255 |
| `ev[26]` | `1 (Action / Talk)` | Target Inspected is obj[33] | Dismiss Emotion Bubble (1); Warp Room -> Submap 23 at (2,37) facing 255 |
| `ev[27]` | `1 (Action / Talk)` | Target Inspected is obj[34] | Dismiss Emotion Bubble (1); Warp Room -> Submap 23 at (2,38) facing 255 |
| `ev[28]` | `1 (Action / Talk)` | Target Inspected is obj[35] | Dismiss Emotion Bubble (1); Warp Room -> Submap 23 at (2,39) facing 255 |
| `ev[29]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Close Dialogue Sub-Window (18); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[30]` | `1 (Action / Talk)` | Target Inspected is obj[19] | Close Dialogue Sub-Window (19); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[31]` | `1 (Action / Talk)` | Target Inspected is obj[20] | Close Dialogue Sub-Window (20); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[32]` | `1 (Action / Talk)` | Target Inspected is obj[21] | Close Dialogue Sub-Window (21); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[33]` | `1 (Action / Talk)` | Target Inspected is obj[22] | Close Dialogue Sub-Window (22); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[34]` | `1 (Action / Talk)` | Target Inspected is obj[23] | Close Dialogue Sub-Window (23); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[35]` | `1 (Action / Talk)` | Target Inspected is obj[24] | Close Dialogue Sub-Window (24); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[36]` | `1 (Action / Talk)` | Target Inspected is obj[25] | Close Dialogue Sub-Window (25); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[37]` | `1 (Action / Talk)` | Target Inspected is obj[26] | Close Dialogue Sub-Window (26); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[38]` | `1 (Action / Talk)` | Target Inspected is obj[27] | Close Dialogue Sub-Window (27); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[39]` | `1 (Action / Talk)` | Target Inspected is obj[28] | Close Dialogue Sub-Window (28); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[40]` | `1 (Action / Talk)` | Target Inspected is obj[36] | Close Dialogue Sub-Window (36); Warp Room -> Submap 255 at (254,204) facing 204 |

---



## Location Map: `vk18`

- **Master Map Container**: `vk18.json`
- **Submap Layer Files**: vk18_09.json
- **Collision Grid Files**: vk18_map_00.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 2

### Submap Layer `vk18_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `23` Objects | **Script Count (`evkaz`)**: `79` Scripts

#### Complete Physical Entity Inventory (23 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Millie** | `24` | `(30, 22)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(29, 21)` | `2x1` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Flik** | `5` | `(25, 38)` | `0x0` | East (Right) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | NPC / Actor | **Actor ID 41** | `41` | `(22, 32)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[04]` | NPC / Actor | **Actor ID 42** | `42` | `(21, 34)` | `3x1` | West (Left) | Dormant / Hidden (0) | Special (3) | 4 | 128 | 0 |
| `obj[05]` | NPC / Actor | **Pohl** | `28` | `(37, 32)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[06]` | NPC / Actor | **Barbara** | `29` | `(43, 32)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[07]` | NPC / Actor | **Actor ID 62** | `62` | `(32, 32)` | `0x0` | Up (North) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[08]` | NPC / Actor | **Actor ID 65105** | `65105` | `(26, 23)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[09]` | NPC / Actor | **Tomo** | `57` | `(29, 38)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[10]` | Prop / Scenery | **Prop ID 33081** | `33081` | `(29, 38)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[11]` | Trigger / Hitbox | **Hitbox Zone (5x3)** | `0` | `(27, 36)` | `4x2` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | Prop / Scenery | **Prop ID 33081** | `33081` | `(37, 38)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(37, 36)` | `1x1` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | Prop / Scenery | **Prop ID 33081** | `33081` | `(42, 38)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[15]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(42, 36)` | `1x1` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[16]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(20, 42)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[17]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(33, 36)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[18]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(32, 30)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[19]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(20, 29)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[20]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(13, 24)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[21]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(37, 25)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[22]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(16, 22)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Millie)**: Positioned at tile `(30, 22)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(29, 21)` to `(31, 22)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[02]` (Flik)**: Positioned at tile `(25, 38)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Object 41)**: Positioned at tile `(22, 32)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Object 42)**: Positioned at tile `(21, 34)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Pohl)**: Positioned at tile `(37, 32)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[06]` (Barbara)**: Positioned at tile `(43, 32)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[07]` (Object 62)**: Positioned at tile `(32, 32)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[08]` (Object 65105)**: Positioned at tile `(26, 23)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[09]` (Tomo)**: Positioned at tile `(29, 38)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[10]` (Prop: Object 33081)**: Environmental world dressing prop placed at tile `(29, 38)`. Solid collision is set to `2`.
- **`obj[11]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `3` tiles high from `(27, 36)` to `(31, 38)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[12]` (Prop: Object 33081)**: Environmental world dressing prop placed at tile `(37, 38)`. Solid collision is set to `0`.
- **`obj[13]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(37, 36)` to `(38, 37)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[14]` (Prop: Object 33081)**: Environmental world dressing prop placed at tile `(42, 38)`. Solid collision is set to `0`.
- **`obj[15]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(42, 36)` to `(43, 37)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[16]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(20, 42)` to `(21, 42)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[17]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(33, 36)` to `(34, 36)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[18]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(32, 30)` to `(33, 30)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[19]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(20, 29)` to `(21, 29)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[20]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(13, 24)` to `(14, 24)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[21]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(37, 25)` to `(38, 25)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[22]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(16, 22)` to `(17, 22)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (79 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #57 AND Player within Box [35..4, 1..255] | Make obj[0] Hidden (disp = 0); Display Speaker Name Box (0); Display Choice Selection (89, 18); Warp Town -> Area 0 Map 47 Submap 255 at (254,204) |
| `ev[01]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #57 AND Player within Box [23..28, 1..34] AND Active Party Has Character #1 AND Condition Check #33 AND Player within Box [2..30, 14..64] | Make obj[2] Hidden (disp = 0); Place Scenery Structure (29); Open Save Crystal Menu (MSaveInit); Open Dialogue Message Window; Display Speaker Name Box (0); Display Choice Selection (89, 18); Warp Town -> Area 1 Map 99 Submap 13 at (1,47) |
| `ev[02]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #57 AND Player within Box [23..29, 1..33] AND Player within Box [2..35, 14..1] AND Condition Check #34 AND Active Party Has Character #16 AND Condition Check #30 AND Active Party Has Character #128 | Make obj[2] Hidden (disp = 0); Animate Door Open; Display Emotion Bubble (38, 0); Display Speaker Name Box (0); Display Choice Selection (99, 13); Warp Town -> Area 89 Map 18 Submap 2 at (2,47) |
| `ev[03]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #57 AND Player within Box [23..29, 1..33] AND Player within Box [2..34, 14..1] AND Condition Check #34 AND Active Party Has Character #16 AND Condition Check #30 AND Active Party Has Character #128 AND Condition Check #29 AND Active Party Has Character #64 | Make obj[2] Hidden (disp = 0); Animate Door Open; Display Emotion Bubble (38, 0); Display Speaker Name Box (0); Display Choice Selection (99, 13); Warp Town -> Area 89 Map 18 Submap 2 at (2,47) |
| `ev[04]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #57 AND Player within Box [23..28, 1..34] AND Active Party Has Character #1 AND Condition Check #29 AND Active Party Has Character #64 | Make obj[2] Hidden (disp = 0); Place Scenery Structure (37); Open Save Crystal Menu (MSaveInit); Open Dialogue Message Window; Branch on Choice (0, 21); Engine Action #89; Branch on Choice (2, 15); Teleport obj[255] to (254,204) |
| `ev[05]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #57 AND Player within Box [23..29, 1..34] AND Active Party Has Character #16 AND Condition Check #29 AND Active Party Has Character #128 | Make obj[2] Hidden (disp = 0); Animate Door Open; Remove Item from Inventory (38, 0); Set Story Flag (0, 23); Engine Action #89; Set Story Flag (2, 16); Teleport obj[255] to (254,204) |
| `ev[06]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #23 AND Condition Check #24 AND Player within Box [34..8, 8..255] | Make obj[0] Hidden (disp = 0); Engine Action #9; Open Dialogue Message Window; Reset Camera Tracking (47) |
| `ev[07]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #57 AND Player within Box [23..5, 1..34] AND Player Y within Range [4..255] | Make obj[0] Hidden (disp = 0); Screen Fade Transition (47, 255, 254) |
| `ev[08]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #41 AND Player within Box [35..15, 1..35] AND Party Formation Check AND Player Y within Range [33..1] AND Player Y within Range [255..254] | Make obj[0] Hidden (disp = 0); Close Dialogue Window; Teleport obj[255] to (254,204) |
| `ev[09]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #42 AND Player within Box [35..15, 8..35] AND Party Formation Check AND Star of Destiny #33 Recruited AND Player X within Range [2..255] | Make obj[0] Hidden (disp = 0); Display Dialogue Box [Bank: 47, MsgID: 255] |
| `ev[10]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #62 AND Player within Box [34..20, 1..33] AND Player X within Range [3..255] | Make obj[0] Hidden (disp = 0); Show Dialogue Portrait (47, 255, 254) |
| `ev[11]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET | Open Dialogue Message Window; Dismiss Dialogue Portrait |
| `ev[12]` | `1 (Action / Talk)` | Story Flag 87 (bit 32) SET | Engine Action #5; Open Dialogue Message Window; Warp to Castle HQ (0, 5, 20); Warp Room -> Submap 5 at (20,2) facing South (Down); Engine Action #5; Branch on Choice (0, 0); Engine Action #5; Branch on Choice (6, 1); Dismiss Emotion Bubble (32); Warp to Castle HQ (0, 0, 0) |
| `ev[13]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #57 AND Player within Box [23..28, 1..34] AND Active Party Has Character #1 AND Condition Check #30 AND Active Party Has Character #64 AND Player within Box [25..26, 33..1] AND Player Y within Range [5..19] | Engine Action #89; Display Speaker Name Box (2); Reset Camera Tracking (24); Change Portrait Expression (1); Warp Town -> Area 24 Map 13 Submap 1 at (4,89); Display Speaker Name Box (2); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[14]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #57 AND Player within Box [23..28, 1..34] AND Active Party Has Character #1 AND Condition Check #30 AND Active Party Has Character #64 AND Player within Box [32..33, 33..1] AND Player Y within Range [5..19] | Engine Action #89; Display Speaker Name Box (2); Screen Fade Transition (24, 17, 1); Warp Town -> Area 24 Map 13 Submap 1 at (4,89); Display Speaker Name Box (2); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[15]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #57 AND Player within Box [23..28, 1..34] AND Active Party Has Character #1 AND Condition Check #30 AND Active Party Has Character #64 AND Player Y within Range [35..36] AND Condition Check #33 AND Player within Box [2..5, 19..255] | Engine Action #89; Display Speaker Name Box (2); Pan Camera (24, 17, 1); Warp Town -> Area 24 Map 13 Submap 1 at (4,89); Display Speaker Name Box (2); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[16]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #57 AND Player within Box [23..28, 1..34] AND Active Party Has Character #1 AND Condition Check #30 AND Active Party Has Character #64 AND Player Y within Range [39..40] AND Condition Check #33 AND Player within Box [2..5, 19..255] | Engine Action #89; Display Speaker Name Box (2); Engine Action #9; Close Dialogue Sub-Window (17); Warp Room -> Submap 24 at (13,1) facing 4; Engine Action #89; Display Speaker Name Box (2); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[17]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #57 AND Player within Box [23..29, 1..34] AND Active Party Has Character #16 AND Condition Check #30 AND Active Party Has Character #128 AND Player within Box [25..26, 33..1] AND Player Y within Range [5..19] | Engine Action #89; Display Speaker Name Box (2); Display Dialogue Box [Bank: 24, MsgID: 17]; Warp Room -> Submap 24 at (14,1) facing East (Right); Engine Action #89; Display Speaker Name Box (2); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[18]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #57 AND Player within Box [23..29, 1..34] AND Active Party Has Character #16 AND Condition Check #30 AND Active Party Has Character #128 AND Player within Box [32..33, 33..1] AND Player Y within Range [5..19] | Engine Action #89; Display Speaker Name Box (2); Animate Door Open; Close Dialogue Sub-Window (17); Warp Room -> Submap 24 at (14,1) facing East (Right); Engine Action #89; Display Speaker Name Box (2); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[19]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #57 AND Player within Box [23..29, 1..34] AND Active Party Has Character #16 AND Condition Check #30 AND Active Party Has Character #128 AND Player Y within Range [35..36] AND Condition Check #33 AND Player within Box [2..5, 19..255] | Engine Action #89; Display Speaker Name Box (2); Close Dialogue Window; Close Dialogue Sub-Window (17); Warp Room -> Submap 24 at (14,1) facing East (Right); Engine Action #89; Display Speaker Name Box (2); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[20]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #57 AND Player within Box [23..29, 1..34] AND Active Party Has Character #16 AND Condition Check #30 AND Active Party Has Character #128 AND Player Y within Range [39..40] AND Condition Check #33 AND Player within Box [2..5, 19..255] | Engine Action #89; Display Speaker Name Box (2); Place Scenery Structure (24); Change Portrait Expression (1); Warp Room -> Submap 14 at (1,3) facing 89; Display Speaker Name Box (2); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[21]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #57 AND Player within Box [1..25, 26..5] AND Character #255 Level >= 254 | Engine Action #89; Display Speaker Name Box (2); Exit to World Map (24, 17, 1); Open Dialogue Message Window; Engine Action #89; Display Speaker Name Box (2); Open Dialogue Message Window |
| `ev[22]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #57 AND Player within Box [1..32, 33..5] AND Character #255 Level >= 254 | Engine Action #89; Display Speaker Name Box (2); Engine Action #6; Close Dialogue Sub-Window (17); Warp Room -> Submap 89 at (18,2) facing South (Down) |
| `ev[23]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #57 AND Player within Box [2..35, 36..5] AND Character #255 Level >= 254 | Engine Action #89; Display Speaker Name Box (2); Warp to Castle HQ (24, 17, 1); Open Dialogue Message Window; Engine Action #89; Display Speaker Name Box (2); Open Dialogue Message Window |
| `ev[24]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #57 AND Player within Box [2..39, 40..5] AND Character #255 Level >= 254 | Engine Action #89; Display Speaker Name Box (2); Engine Action #5; Close Dialogue Sub-Window (17); Warp Room -> Submap 89 at (18,2) facing South (Down) |
| `ev[25]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #57 AND Player within Box [23..28, 1..34] AND Active Party Has Character #1 AND Condition Check #29 AND Active Party Has Character #64 AND Target Inspected is obj[21] | Close Dialogue Sub-Window (13); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[26]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #57 AND Player within Box [23..29, 1..34] AND Active Party Has Character #16 AND Condition Check #29 AND Active Party Has Character #128 AND Target Inspected is obj[23] | Close Dialogue Sub-Window (14); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[27]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[10] | Open Dialogue Sub-Window (4); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[28]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #73 AND Player Y within Range [23..39] AND Player Y within Range [23..12] AND Player Y within Range [23..41] AND Player Y within Range [5..10] | Dismiss Emotion Bubble (0); Warp Room -> Submap 41 at (4,0) facing West (Left); Warp Town -> Area 3 Map 255 Submap 0 at (23,5); Warp Room -> Submap 254 at (255,1) facing 23; Engine Action #6; Warp Room -> Submap 254 at (255,2) facing 23; Pan Camera (1, 255, 254); Warp to Castle HQ (23, 3, 1) |
| `ev[29]` | `1 (Action / Talk)` | Condition Check #24 AND Condition Check #73 AND Player Y within Range [23..39] AND Player Y within Range [23..12] AND Player Y within Range [23..41] AND Player Y within Range [5..10] | Dismiss Emotion Bubble (0); Warp Room -> Submap 41 at (3,0) facing West (Left); Warp Town -> Area 255 Map 0 Submap 23 at (5,1); Warp Room -> Submap 6 at (1,255) facing 254; Warp Town -> Area 23 Map 7 Submap 1 at (255,254) |
| `ev[30]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #73 AND Player Y within Range [23..39] AND Player Y within Range [24..12] AND Player Y within Range [23..41] AND Player Y within Range [5..10] | Dismiss Emotion Bubble (0); Warp Room -> Submap 41 at (3,0) facing West (Left); Warp Town -> Area 255 Map 0 Submap 23 at (5,1); Warp Room -> Submap 3 at (1,255) facing 254; Warp Town -> Area 23 Map 7 Submap 1 at (255,254) |
| `ev[31]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #73 AND Player Y within Range [23..39] AND Player Y within Range [24..12] AND Player Y within Range [24..41] AND Player Y within Range [5..10] | Dismiss Emotion Bubble (0); Warp Room -> Submap 41 at (2,0) facing West (Left); Open Dialogue Message Window; Open Dialogue Sub-Window (5); Warp Room -> Submap 254 at (255,1) facing 23; Warp to Castle HQ (1, 255, 254) |
| `ev[32]` | `1 (Action / Talk)` | Condition Check #24 AND Condition Check #73 AND Player Y within Range [23..39] AND Player Y within Range [23..12] AND Player Y within Range [24..41] AND Player Y within Range [5..10] | Dismiss Emotion Bubble (0); Warp Room -> Submap 41 at (2,0) facing West (Left); Open Dialogue Message Window; Open Dialogue Sub-Window (6); Warp Room -> Submap 254 at (255,1) facing 23; Engine Action #5; Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[33]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #73 AND Player Y within Range [24..39] AND Player Y within Range [24..12] AND Player Y within Range [23..41] AND Player Y within Range [5..10] | Dismiss Emotion Bubble (0); Warp Room -> Submap 41 at (2,0) facing West (Left); Open Dialogue Message Window; Open Dialogue Sub-Window (7); Warp Room -> Submap 254 at (255,1) facing 23; Warp to Castle HQ (1, 255, 254) |
| `ev[34]` | `1 (Action / Talk)` | Condition Check #24 AND Condition Check #73 AND Player Y within Range [23..39] AND Player Y within Range [24..12] AND Player Y within Range [23..41] AND Player Y within Range [5..10] | Dismiss Emotion Bubble (0); Warp Room -> Submap 41 at (2,0) facing West (Left); Open Dialogue Message Window; Open Dialogue Sub-Window (7); Warp Room -> Submap 254 at (255,1) facing 23; Engine Action #5; Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[35]` | `1 (Action / Talk)` | Condition Check #24 AND Condition Check #73 AND Player Y within Range [24..39] AND Player Y within Range [23..12] AND Player Y within Range [23..41] AND Player Y within Range [5..10] | Dismiss Emotion Bubble (0); Warp Room -> Submap 41 at (2,0) facing West (Left); Open Dialogue Message Window; Open Dialogue Sub-Window (7); Warp Room -> Submap 254 at (255,1) facing 23; Engine Action #6; Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[36]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #73 AND Player Y within Range [24..39] AND Player Y within Range [24..12] AND Player Y within Range [24..41] AND Player Y within Range [5..10] | Open Dialogue Sub-Window (3); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[37]` | `1 (Action / Talk)` | Condition Check #24 AND Condition Check #73 AND Player Y within Range [23..39] AND Player Y within Range [24..12] AND Player Y within Range [24..41] AND Player Y within Range [5..10] | Open Dialogue Sub-Window (5); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[38]` | `1 (Action / Talk)` | Condition Check #24 AND Condition Check #73 AND Player Y within Range [24..39] AND Player Y within Range [23..12] AND Player Y within Range [24..41] AND Player Y within Range [5..10] | Open Dialogue Sub-Window (6); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[39]` | `1 (Action / Talk)` | Condition Check #24 AND Condition Check #73 AND Player Y within Range [24..39] AND Player Y within Range [24..12] AND Player Y within Range [23..41] AND Player Y within Range [5..10] | Open Dialogue Sub-Window (7); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[40]` | `1 (Action / Talk)` | Condition Check #24 AND Condition Check #73 AND Player Y within Range [24..39] AND Player Y within Range [24..12] AND Player Y within Range [24..41] AND Player Y within Range [5..10] | Open Dialogue Sub-Window (0); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[41]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[9] | Close Dialogue Sub-Window (8); Warp to Castle HQ (0, 255, 254) |
| `ev[42]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[11] | Open Dialogue Sub-Window (3); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[43]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[12] | Open Dialogue Sub-Window (3); Warp to Castle HQ (255, 254, 204) |
| `ev[44]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[15] | Open Dialogue Sub-Window (3); Exit to World Map (255, 254, 204) |
| `ev[45]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[9] | Close Dialogue Sub-Window (8); Exit to World Map (0, 255, 254) |
| `ev[46]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[11] | Open Dialogue Sub-Window (4); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[47]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[12] | Open Dialogue Sub-Window (4); Warp to Castle HQ (255, 254, 204) |
| `ev[48]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[15] | Open Dialogue Sub-Window (4); Exit to World Map (255, 254, 204) |
| `ev[49]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[9] | Close Dialogue Sub-Window (8); Engine Action #5; Open Dialogue Message Window |
| `ev[50]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[11] | Open Dialogue Sub-Window (5); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[51]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[12] | Open Dialogue Sub-Window (5); Warp to Castle HQ (255, 254, 204) |
| `ev[52]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[15] | Open Dialogue Sub-Window (5); Exit to World Map (255, 254, 204) |
| `ev[53]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[9] | Close Dialogue Sub-Window (8); Engine Action #6; Open Dialogue Message Window |
| `ev[54]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[11] | Open Dialogue Sub-Window (6); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[55]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[12] | Open Dialogue Sub-Window (6); Warp to Castle HQ (255, 254, 204) |
| `ev[56]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[15] | Open Dialogue Sub-Window (6); Exit to World Map (255, 254, 204) |
| `ev[57]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[9] | Close Dialogue Sub-Window (8); Pan Camera (0, 255, 254) |
| `ev[58]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[11] | Open Dialogue Sub-Window (7); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[59]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[12] | Open Dialogue Sub-Window (7); Warp to Castle HQ (255, 254, 204) |
| `ev[60]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[15] | Open Dialogue Sub-Window (7); Exit to World Map (255, 254, 204) |
| `ev[61]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Close Dialogue Sub-Window (8); Open Dialogue Message Window; Open Dialogue Message Window |
| `ev[62]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Open Dialogue Sub-Window (0); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[63]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Open Dialogue Sub-Window (0); Warp to Castle HQ (255, 254, 204) |
| `ev[64]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Open Dialogue Sub-Window (0); Exit to World Map (255, 254, 204) |
| `ev[65]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[16] | Open Dialogue Sub-Window (8); Exit to World Map (255, 254, 204) |
| `ev[66]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Engine Action #99; Show Dialogue Portrait (4, 23, 1); Pan Camera (73, 20, 127); Open Dialogue Message Window; Show Dialogue Portrait (4, 70, 0); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[67]` | `128 (Loop)` | Condition Check #29 AND Party Formation Check AND Story Flag 255 (bit 254) CLEAR | Warp Room -> Submap 0 at (13,48); Mark NPC Talk Interaction Complete (Flag #15); Exit to World Map (255, 254, 204) |
| `ev[68]` | `128 (Loop)` | Player within Box [2..50, 2..26] AND Condition Check #45 | Warp Room -> Submap 0 at (10,5) |
| `ev[69]` | `1 (Action / Talk)` | Player within Box [21..31, 2..48] AND Condition Check #49 AND Story Flag 0 (mask 255) SET | Warp Map Transition (3, 1, 118, 25, 255) |
| `ev[70]` | `1 (Action / Talk)` | Player within Box [2..20, 2..48] AND Condition Check #49 AND Story Flag 0 (mask 255) SET | Warp Map Transition (3, 1, 108, 25, 255) |
| `ev[71]` | `1 (Action / Talk)` | Player within Box [32..50, 2..48] AND Condition Check #49 AND Story Flag 0 (mask 255) SET | Warp Map Transition (3, 1, 128, 25, 255) |
| `ev[72]` | `1 (Action / Talk)` | Target Inspected is obj[24] | Open Dialogue Sub-Window (2); Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[73]` | `1 (Action / Talk)` | Target Inspected is obj[25] | Open Dialogue Sub-Window (2); Warp Town -> Area 255 Map 254 Submap 255 at (254,204) |
| `ev[74]` | `1 (Action / Talk)` | Target Inspected is obj[26] | Open Dialogue Sub-Window (2); Warp to Castle HQ (255, 254, 255) |
| `ev[75]` | `1 (Action / Talk)` | Target Inspected is obj[27] | Open Dialogue Sub-Window (2); Exit to World Map (255, 254, 255) |
| `ev[76]` | `1 (Action / Talk)` | Target Inspected is obj[28] | Open Dialogue Sub-Window (2); Engine Action #5 |
| `ev[77]` | `1 (Action / Talk)` | Target Inspected is obj[29] | Open Dialogue Sub-Window (2); Engine Action #6 |
| `ev[78]` | `1 (Action / Talk)` | Target Inspected is obj[30] | Open Dialogue Sub-Window (2); Pan Camera (255, 254, 255) |

---

### Submap Layer `vk18_01` (Index 1)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `6` Objects | **Script Count (`evkaz`)**: `37` Scripts

#### Complete Physical Entity Inventory (6 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Millie** | `24` | `(30, 22)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(29, 21)` | `2x1` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Actor ID 41** | `41` | `(22, 32)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | NPC / Actor | **Actor ID 42** | `42` | `(21, 34)` | `3x1` | West (Left) | Dormant / Hidden (0) | Special (3) | 4 | 255 | 0 |
| `obj[04]` | NPC / Actor | **Actor ID 62** | `62` | `(32, 32)` | `0x0` | Up (North) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[05]` | NPC / Actor | **Actor ID 65105** | `65105` | `(26, 23)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Millie)**: Positioned at tile `(30, 22)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(29, 21)` to `(31, 22)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[02]` (Object 41)**: Positioned at tile `(22, 32)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Object 42)**: Positioned at tile `(21, 34)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Object 62)**: Positioned at tile `(32, 32)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Object 65105)**: Positioned at tile `(26, 23)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.


#### Complete Bytecode Script Catalog (37 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #23 AND Condition Check #24 AND Player within Box [34..8, 8..255] | Make obj[0] Hidden (disp = 0); Reset Camera Tracking (0); Engine Action #9; Teleport obj[255] to (254,204) |
| `ev[01]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #41 AND Player within Box [35..15, 1..35] AND Party Formation Check AND Player Y within Range [33..1] AND Player Y within Range [255..254] | Make obj[0] Hidden (disp = 0); Screen Fade Transition (47, 255, 254) |
| `ev[02]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #42 AND Player within Box [35..15, 8..35] AND Party Formation Check AND Star of Destiny #33 Recruited AND Player X within Range [2..255] | Make obj[0] Hidden (disp = 0); Close Dialogue Window; Teleport obj[255] to (254,204) |
| `ev[03]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #62 AND Player within Box [34..20, 1..33] AND Player X within Range [3..255] | Make obj[0] Hidden (disp = 0); Display Dialogue Box [Bank: 47, MsgID: 255] |
| `ev[04]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET | Open Dialogue Message Window; Place Scenery Structure (255) |
| `ev[05]` | `1 (Action / Talk)` | Story Flag 87 (bit 32) SET | Engine Action #5; Open Dialogue Message Window; Warp to Castle HQ (0, 5, 20); Warp Room -> Submap 5 at (20,2) facing South (Down); Engine Action #5; Branch on Choice (0, 0); Engine Action #5; Branch on Choice (6, 1); Dismiss Emotion Bubble (32); Warp to Castle HQ (0, 0, 0) |
| `ev[06]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[9] | Close Dialogue Sub-Window (8); Warp to Castle HQ (0, 255, 254) |
| `ev[07]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[10] | Open Dialogue Sub-Window (3); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[08]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[11] | Open Dialogue Sub-Window (3); Warp to Castle HQ (255, 254, 204) |
| `ev[09]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[12] | Open Dialogue Sub-Window (3); Exit to World Map (255, 254, 204) |
| `ev[10]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[9] | Close Dialogue Sub-Window (8); Exit to World Map (0, 255, 254) |
| `ev[11]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[10] | Open Dialogue Sub-Window (4); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[12]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[11] | Open Dialogue Sub-Window (4); Warp to Castle HQ (255, 254, 204) |
| `ev[13]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[12] | Open Dialogue Sub-Window (4); Exit to World Map (255, 254, 204) |
| `ev[14]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[9] | Close Dialogue Sub-Window (8); Engine Action #5; Open Dialogue Message Window |
| `ev[15]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[10] | Open Dialogue Sub-Window (5); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[16]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[11] | Open Dialogue Sub-Window (5); Warp to Castle HQ (255, 254, 204) |
| `ev[17]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[12] | Open Dialogue Sub-Window (5); Exit to World Map (255, 254, 204) |
| `ev[18]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[9] | Close Dialogue Sub-Window (8); Engine Action #6; Open Dialogue Message Window |
| `ev[19]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[10] | Open Dialogue Sub-Window (6); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[20]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[11] | Open Dialogue Sub-Window (6); Warp to Castle HQ (255, 254, 204) |
| `ev[21]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[12] | Open Dialogue Sub-Window (6); Exit to World Map (255, 254, 204) |
| `ev[22]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[9] | Close Dialogue Sub-Window (8); Pan Camera (0, 255, 254) |
| `ev[23]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[10] | Open Dialogue Sub-Window (7); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[24]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[11] | Open Dialogue Sub-Window (7); Warp to Castle HQ (255, 254, 204) |
| `ev[25]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[12] | Open Dialogue Sub-Window (7); Exit to World Map (255, 254, 204) |
| `ev[26]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Close Dialogue Sub-Window (8); Open Dialogue Message Window; Open Dialogue Message Window |
| `ev[27]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Open Dialogue Sub-Window (0); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[28]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Open Dialogue Sub-Window (0); Warp to Castle HQ (255, 254, 204) |
| `ev[29]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Open Dialogue Sub-Window (0); Exit to World Map (255, 254, 204) |
| `ev[30]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[13] | Open Dialogue Sub-Window (8); Exit to World Map (255, 254, 204) |
| `ev[31]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Engine Action #99; Show Dialogue Portrait (4, 23, 1); Pan Camera (73, 20, 127); Open Dialogue Message Window; Show Dialogue Portrait (4, 70, 0); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[32]` | `128 (Loop)` | Condition Check #29 AND Party Formation Check AND Story Flag 255 (bit 254) CLEAR | Warp Room -> Submap 0 at (13,48); Mark NPC Talk Interaction Complete (Flag #15); Exit to World Map (255, 254, 204) |
| `ev[33]` | `128 (Loop)` | Player within Box [2..50, 2..26] AND Condition Check #45 | Warp Room -> Submap 0 at (10,5) |
| `ev[34]` | `1 (Action / Talk)` | Player within Box [21..31, 2..48] AND Condition Check #49 AND Story Flag 0 (mask 255) SET | Warp Map Transition (3, 1, 118, 25, 255) |
| `ev[35]` | `1 (Action / Talk)` | Player within Box [2..20, 2..48] AND Condition Check #49 AND Story Flag 0 (mask 255) SET | Warp Map Transition (3, 1, 108, 25, 255) |
| `ev[36]` | `1 (Action / Talk)` | Player within Box [32..50, 2..48] AND Condition Check #49 AND Story Flag 0 (mask 255) SET | Warp Map Transition (3, 1, 128, 25, 255) |

---


