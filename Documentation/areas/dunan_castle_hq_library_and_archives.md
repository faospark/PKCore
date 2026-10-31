# Suikoden II Geographic Area Catalog: Castle HQ: Cartography Room

**Geographic Scope & Role**: Templeton's map studio; massive interactive floor table displaying the complete rendered world map of Dunan and Toran.

**Regional Category**: Region `VK` | **Master Maps Included**: `vk12`

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

## Location Map: `vk12`

- **Master Map Container**: `vk12.json`
- **Submap Layer Files**: Embedded in master
- **Collision Grid Files**: vk12_map_00.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 2

### Submap Layer `vk12_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `40` Objects | **Script Count (`evkaz`)**: `59` Scripts

#### Complete Physical Entity Inventory (40 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Kahn Marley** | `36` | `(54, 119)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Bolgan** | `21` | `(70, 109)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Actor ID 120** | `120` | `(41, 110)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | NPC / Actor | **Marlowe** | `59` | `(43, 113)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[04]` | NPC / Actor | **Actor ID 61** | `61` | `(81, 100)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[05]` | Trigger / Hitbox | **Hitbox Zone (5x1)** | `0` | `(41, 122)` | `4x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | Trigger / Hitbox | **Hitbox Zone (5x1)** | `0` | `(79, 122)` | `4x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(50, 111)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(50, 108)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(55, 111)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(73, 108)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(50, 118)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(74, 118)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(54, 121)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(70, 121)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[15]` | Trigger / Hitbox | **Hitbox Zone (2x5)** | `0` | `(44, 128)` | `1x4` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[16]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(49, 131)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[17]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(47, 128)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[18]` | Trigger / Hitbox | **Hitbox Zone (2x3)** | `0` | `(83, 98)` | `1x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[19]` | Trigger / Hitbox | **Hitbox Zone (2x3)** | `0` | `(83, 80)` | `1x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[20]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(43, 99)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[21]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(41, 107)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[22]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(41, 97)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[23]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(81, 97)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[24]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(81, 107)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[25]` | Trigger / Hitbox | **Hitbox Zone (5x2)** | `0` | `(47, 87)` | `4x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[26]` | Trigger / Hitbox | **Hitbox Zone (5x2)** | `0` | `(73, 87)` | `4x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[27]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(77, 126)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[28]` | Trigger / Hitbox | **Hitbox Zone (1x9)** | `0` | `(71, 129)` | `0x8` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[29]` | NPC / Actor | **Actor ID 65075** | `65075` | `(79, 129)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[30]` | NPC / Actor | **Actor ID 65074** | `65074` | `(73, 132)` | `0x0` | Up (North) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[31]` | NPC / Actor | **Actor ID 65178** | `65178` | `(41, 100)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[32]` | NPC / Actor | **Actor ID 65028** | `65028` | `(80, 77)` | `4x6` | South (Down) | Dormant / Hidden (0) | Special (3) | 2 | 128 | 0 |
| `obj[33]` | NPC / Actor | **Actor ID 65035** | `65035` | `(82, 110)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[34]` | NPC / Actor | **Actor ID 65176** | `65176` | `(44, 76)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[35]` | NPC / Actor | **Actor ID 65115** | `65115` | `(61, 113)` | `4x6` | Up (North) | Dormant / Hidden (0) | Special (3) | 2 | 128 | 0 |
| `obj[36]` | NPC / Actor | **Actor ID 65103** | `65103` | `(82, 92)` | `4x4` | East (Right) | Dormant / Hidden (0) | Special (3) | 2 | 128 | 0 |
| `obj[37]` | NPC / Actor | **Actor ID 65167** | `65167` | `(54, 128)` | `4x6` | Up (North) | Dormant / Hidden (0) | Special (3) | 2 | 128 | 0 |
| `obj[38]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `65167` | `(53, 117)` | `2x2` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[39]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `65167` | `(69, 107)` | `2x2` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Kahn Marley)**: Positioned at tile `(54, 119)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Bolgan)**: Positioned at tile `(70, 109)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Object 120)**: Positioned at tile `(41, 110)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Marlowe)**: Positioned at tile `(43, 113)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Object 61)**: Positioned at tile `(81, 100)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `1` tiles high from `(41, 122)` to `(45, 122)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[06]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `1` tiles high from `(79, 122)` to `(83, 122)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[07]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(50, 111)` to `(51, 112)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[08]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(50, 108)` to `(51, 109)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[09]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(55, 111)` to `(56, 112)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[10]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(73, 108)` to `(74, 109)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[11]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(50, 118)` to `(51, 119)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[12]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(74, 118)` to `(75, 119)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[13]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(54, 121)` to `(55, 122)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[14]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(70, 121)` to `(71, 122)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[15]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `5` tiles high from `(44, 128)` to `(45, 132)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[16]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(49, 131)` to `(50, 132)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[17]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(47, 128)` to `(48, 129)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[18]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `3` tiles high from `(83, 98)` to `(84, 100)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[19]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `3` tiles high from `(83, 80)` to `(84, 82)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[20]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(43, 99)` to `(44, 100)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[21]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(41, 107)` to `(43, 108)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[22]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(41, 97)` to `(43, 98)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[23]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(81, 97)` to `(83, 98)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[24]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(81, 107)` to `(83, 108)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[25]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `2` tiles high from `(47, 87)` to `(51, 88)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[26]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `2` tiles high from `(73, 87)` to `(77, 88)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[27]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(77, 126)` to `(80, 127)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[28]` (Hitbox Zone)**: Bounding trigger area covering `1` tiles wide by `9` tiles high from `(71, 129)` to `(71, 137)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[29]` (Object 65075)**: Positioned at tile `(79, 129)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[30]` (Object 65074)**: Positioned at tile `(73, 132)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[31]` (Object 65178)**: Positioned at tile `(41, 100)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[32]` (Object 65028)**: Positioned at tile `(80, 77)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[33]` (Object 65035)**: Positioned at tile `(82, 110)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[34]` (Object 65176)**: Positioned at tile `(44, 76)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[35]` (Object 65115)**: Positioned at tile `(61, 113)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[36]` (Object 65103)**: Positioned at tile `(82, 92)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[37]` (Object 65167)**: Positioned at tile `(54, 128)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[38]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(53, 117)` to `(55, 119)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[39]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(69, 107)` to `(71, 109)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (59 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #36 AND Player within Box [33..1, 2..255] | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[01]` | `1 (Action / Talk)` | Target Inspected is obj[46] | Dismiss Emotion Bubble (0); Warp Room -> Submap 24 at (8,0) facing West (Left); Warp to Castle HQ (8, 0, 255) |
| `ev[02]` | `2 (Map Init)` | Story Flag 45 (bit 128) CLEAR AND Condition Check #23 AND Inventory Holds Item #1 [Medicine] AND Condition Check #34 AND Temp Event Flag #16 SET AND Condition Check #33 AND Player X within Range [2..255] | Open Dialogue Message Window; Engine Action #9 |
| `ev[03]` | `1 (Action / Talk)` | Target Inspected is obj[47] | Dismiss Emotion Bubble (0); Warp Room -> Submap 24 at (9,0) facing Up (North); Warp to Castle HQ (9, 0, 255) |
| `ev[04]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #120 AND Player within Box [33..1, 2..255] | Open Dialogue Message Window; Screen Fade Transition (255, 254, 204) |
| `ev[05]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Dismiss Emotion Bubble (0); Warp Room -> Submap 23 at (0,3) facing East (Right); Screen Fade Transition (1, 255, 254) |
| `ev[06]` | `2 (Map Init)` | Story Flag 48 (bit 2) CLEAR AND Condition Check #23 AND Condition Check #59 AND Player within Box [33..1, 2..34] AND Story Flag 32 (bit 255) SET | Open Dialogue Message Window; Close Dialogue Window |
| `ev[07]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Dismiss Emotion Bubble (0); Warp Room -> Submap 23 at (0,4) facing 255 |
| `ev[08]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #61 AND Player within Box [33..1, 3..255] | Open Dialogue Message Window; Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[09]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Dismiss Emotion Bubble (0); Warp Room -> Submap 23 at (0,5) facing East (Right); Display Dialogue Box [Bank: 1, MsgID: 255] |
| `ev[10]` | `128 (Loop)` | Player within Box [38..85, 2..103] AND Condition Check #135 | Warp Room -> Submap 1 at (10,10) |
| `ev[11]` | `1 (Action / Talk)` | Player within Box [58..66, 2..138] AND Condition Check #139 AND Story Flag 0 (mask 33) SET AND Player Y within Range [2..255] | Warp Map Transition (2, 4, 50, 109, 255) |
| `ev[12]` | `1 (Action / Talk)` | Player within Box [58..66, 2..138] AND Condition Check #139 AND Story Flag 0 (mask 33) SET AND Player X within Range [3..255] | Warp Map Transition (2, 0, 50, 109, 255) |
| `ev[13]` | `1 (Action / Talk)` | Player within Box [60..64, 2..86] AND Condition Check #87 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 62]; Start Boss Battle #255 (BGM: 254) |
| `ev[14]` | `2 (Map Init)` | Condition Check #33 AND Player within Box [2..3, 112..64] | Open Dialogue Message Window; Toggle Random Encounters (255) |
| `ev[15]` | `2 (Map Init)` | Condition Check #33 AND Player within Box [4..3, 112..64] | Open Dialogue Message Window; Open Save Crystal Menu (MSaveInit) |
| `ev[16]` | `2 (Map Init)` | Condition Check #33 AND Player within Box [2..3, 112..64] | Open Dialogue Message Window; Engine Action #39 |
| `ev[17]` | `2 (Map Init)` | Condition Check #33 AND Player within Box [3..3, 112..64] | Open Dialogue Message Window; Engine Action #40 |
| `ev[18]` | `2 (Map Init)` | Condition Check #33 AND Player within Box [4..3, 112..64] | Open Dialogue Message Window; Award Potch Loot (+65,534 Potch) |
| `ev[19]` | `2 (Map Init)` | Condition Check #33 AND Player within Box [3..3, 112..64] | Open Dialogue Message Window; Remove Item from Inventory (255, 254) |
| `ev[20]` | `2 (Map Init)` | Condition Check #33 AND Player within Box [2..3, 112..64] | Open Dialogue Message Window; Open Shop Menu #254 (Type: 255) |
| `ev[21]` | `2 (Map Init)` | Condition Check #33 AND Player within Box [3..3, 112..64] | Open Dialogue Message Window; Engine Action #44 |
| `ev[22]` | `2 (Map Init)` | Condition Check #33 AND Player within Box [3..3, 112..64] | Open Dialogue Message Window; Make obj[255] Visible (disp = 1) |
| `ev[23]` | `1 (Action / Talk)` | Target Inspected is obj[37] | Dismiss Emotion Bubble (1); Warp Room -> Submap 23 at (2,0) facing East (Right); Toggle Random Encounters (1) |
| `ev[24]` | `1 (Action / Talk)` | Target Inspected is obj[38] | Dismiss Emotion Bubble (1); Warp Room -> Submap 23 at (2,1) facing East (Right); Open Save Crystal Menu (MSaveInit); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[25]` | `1 (Action / Talk)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player within Box [4..5, 36..9] AND Story Flag 255 (bit 254) SET | Set Animation Pose (38, 0); Warp to Castle HQ (4, 1, 0); Engine Action #9; Warp to Castle HQ (38, 2, 30); Warp Room -> Submap 4 at (23,2) facing West (Left) |
| `ev[26]` | `1 (Action / Talk)` | Target Inspected is obj[39] | Dismiss Emotion Bubble (1); Warp Room -> Submap 23 at (2,2) facing East (Right); Engine Action #39; Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[27]` | `1 (Action / Talk)` | Target Inspected is obj[40] | Dismiss Emotion Bubble (1); Warp Room -> Submap 23 at (2,3) facing 255 |
| `ev[28]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #96 AND Player within Box [5..41, 255..254] | Open Dialogue Sub-Window (2); Exit to World Map (3, 41, 1) |
| `ev[29]` | `1 (Action / Talk)` | Condition Check #24 AND Condition Check #96 AND Player within Box [5..41, 255..254] | Open Dialogue Sub-Window (8); Exit to World Map (3, 41, 1) |
| `ev[30]` | `1 (Action / Talk)` | Target Inspected is obj[42] | Dismiss Emotion Bubble (1); Warp Room -> Submap 23 at (2,5) facing East (Right); Remove Item from Inventory (0, 255) |
| `ev[31]` | `1 (Action / Talk)` | Target Inspected is obj[43] | Dismiss Emotion Bubble (1); Warp Room -> Submap 23 at (2,6) facing 255 |
| `ev[32]` | `1 (Action / Talk)` | Target Inspected is obj[44] | Dismiss Emotion Bubble (1); Warp Room -> Submap 23 at (2,7) facing 255 |
| `ev[33]` | `1 (Action / Talk)` | Target Inspected is obj[45] | Dismiss Emotion Bubble (1); Warp Room -> Submap 23 at (2,8) facing 255 |
| `ev[34]` | `1 (Action / Talk)` | Target Inspected is obj[13] AND Story Flag 1 (mask 255) SET | Close Dialogue Sub-Window (13); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[35]` | `1 (Action / Talk)` | Target Inspected is obj[14] AND Story Flag 1 (mask 255) SET | Close Dialogue Sub-Window (14); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[36]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Close Dialogue Sub-Window (15); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[37]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Close Dialogue Sub-Window (16); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[38]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Close Dialogue Sub-Window (17); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[39]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Close Dialogue Sub-Window (18); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[40]` | `1 (Action / Talk)` | Target Inspected is obj[19] | Close Dialogue Sub-Window (19); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[41]` | `1 (Action / Talk)` | Target Inspected is obj[20] | Close Dialogue Sub-Window (20); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[42]` | `1 (Action / Talk)` | Target Inspected is obj[21] | Close Dialogue Sub-Window (21); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[43]` | `1 (Action / Talk)` | Target Inspected is obj[22] | Close Dialogue Sub-Window (22); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[44]` | `1 (Action / Talk)` | Target Inspected is obj[23] | Close Dialogue Sub-Window (23); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[45]` | `1 (Action / Talk)` | Target Inspected is obj[24] | Close Dialogue Sub-Window (24); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[46]` | `1 (Action / Talk)` | Target Inspected is obj[25] | Close Dialogue Sub-Window (25); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[47]` | `1 (Action / Talk)` | Target Inspected is obj[26] | Close Dialogue Sub-Window (26); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[48]` | `1 (Action / Talk)` | Target Inspected is obj[27] | Close Dialogue Sub-Window (27); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[49]` | `1 (Action / Talk)` | Target Inspected is obj[28] | Close Dialogue Sub-Window (28); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[50]` | `1 (Action / Talk)` | Target Inspected is obj[29] AND Story Flag 1 (mask 255) SET | Close Dialogue Sub-Window (29); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[51]` | `1 (Action / Talk)` | Target Inspected is obj[30] AND Story Flag 1 (mask 255) SET | Close Dialogue Sub-Window (30); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[52]` | `1 (Action / Talk)` | Target Inspected is obj[31] AND Story Flag 1 (mask 255) SET | Close Dialogue Sub-Window (31); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[53]` | `1 (Action / Talk)` | Target Inspected is obj[32] AND Story Flag 1 (mask 255) SET | Close Dialogue Sub-Window (32); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[54]` | `1 (Action / Talk)` | Target Inspected is obj[33] AND Story Flag 1 (mask 255) SET | Close Dialogue Sub-Window (33); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[55]` | `1 (Action / Talk)` | Target Inspected is obj[34] AND Story Flag 1 (mask 255) SET | Close Dialogue Sub-Window (34); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[56]` | `1 (Action / Talk)` | Target Inspected is obj[35] AND Story Flag 1 (mask 255) SET | Close Dialogue Sub-Window (35); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[57]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #36 AND Player within Box [33..1, 2..255] | Open Dialogue Message Window; Make obj[255] Hidden (disp = 0) |
| `ev[58]` | `2 (Map Init)` | Story Flag 45 (bit 128) CLEAR AND Condition Check #23 AND Inventory Holds Item #1 [Medicine] AND Condition Check #34 AND Temp Event Flag #16 SET AND Condition Check #33 AND Player X within Range [2..255] | Open Dialogue Message Window; Teleport obj[255] to (254,204) |

---

### Submap Layer `vk12_01` (Index 1)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `11` Objects | **Script Count (`evkaz`)**: `19` Scripts

#### Complete Physical Entity Inventory (11 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 86** | `86` | `(76, 29)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Freed Y** | `96` | `(62, 28)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Flik** | `5` | `(67, 28)` | `0x0` | Up (North) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | Trigger / Hitbox | **Hitbox Zone (5x2)** | `0` | `(49, 22)` | `4x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(55, 22)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(73, 23)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(75, 32)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(59, 22)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(49, 27)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(77, 26)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | NPC / Actor | **Actor ID 65226** | `65226` | `(51, 25)` | `4x3` | West (Left) | Dormant / Hidden (0) | Special (3) | 2 | 128 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 86)**: Positioned at tile `(76, 29)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Freed Y)**: Positioned at tile `(62, 28)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Flik)**: Positioned at tile `(67, 28)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `2` tiles high from `(49, 22)` to `(53, 23)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[04]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(55, 22)` to `(57, 23)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[05]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(73, 23)` to `(74, 24)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[06]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(75, 32)` to `(76, 33)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[07]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(59, 22)` to `(60, 23)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[08]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(49, 27)` to `(50, 28)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[09]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(77, 26)` to `(78, 27)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[10]` (Object 65226)**: Positioned at tile `(51, 25)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.


#### Complete Bytecode Script Catalog (19 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #86 AND Player within Box [33..1, 2..255] | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[01]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #86 AND Player within Box [33..1, 2..5] AND Temp Event Flag #255 CLEAR | Engine Action #99; Dismiss Dialogue Portrait; Exit to World Map (30, 0, 1); Exit to World Map (23, 0, 0); Set Combat Battle BGM (20); Engine Action #127; Open Dialogue Message Window; Dismiss Dialogue Portrait; Exit to World Map (70, 1, 1) |
| `ev[02]` | `128 (Loop)` | Condition Check #23 AND Condition Check #86 AND Player within Box [33..1, 2..29] AND Star of Destiny #4 Recruited | Warp Room -> Submap 1 at (13,41); Mark NPC Talk Interaction Complete (Flag #16); Exit to World Map (255, 254, 204) |
| `ev[03]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #96 AND Player within Box [33..1, 2..255] | Make obj[0] Hidden (disp = 0); Engine Action #9; Teleport obj[255] to (254,204) |
| `ev[04]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #96 AND Player within Box [33..1, 2..5] AND Story Flag 255 (mask 254) SET | Engine Action #99; Dismiss Dialogue Portrait; Warp Room -> Submap 0 at (1,4) facing 23; Open Dialogue Message Window; Engine Action #6; Set Combat Battle BGM (20); Engine Action #127; Open Dialogue Message Window; Dismiss Dialogue Portrait; Warp Room -> Submap 1 at (1,255) facing 254 |
| `ev[05]` | `128 (Loop)` | Condition Check #23 AND Condition Check #96 AND Player within Box [33..1, 2..29] AND Star of Destiny #1 Recruited | Warp Room -> Submap 1 at (13,17); Mark NPC Talk Interaction Complete (Flag #16); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[06]` | `2 (Map Init)` | Condition Check #23 AND Target Inspected is obj[1] AND Condition Check #34 AND Player Y within Range [16..33] AND Player X within Range [2..255] | Make obj[0] Hidden (disp = 0); Screen Fade Transition (47, 255, 254) |
| `ev[07]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Dismiss Emotion Bubble (2); Open Dialogue Message Window; Open Dialogue Sub-Window (0); Pan Camera (255, 254, 204) |
| `ev[08]` | `1 (Action / Talk)` | Player within Box [60..64, 2..38] AND Condition Check #39 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 62]; Engine Action #89 |
| `ev[09]` | `2 (Map Init)` | Condition Check #33 AND Player within Box [3..3, 112..64] | Open Dialogue Message Window; Display Speaker Name Box (255) |
| `ev[10]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #96 AND Player within Box [5..18, 255..254] | Open Dialogue Sub-Window (2); Engine Action #9 |
| `ev[11]` | `1 (Action / Talk)` | Condition Check #24 AND Condition Check #96 AND Player within Box [5..18, 255..254] | Open Dialogue Sub-Window (8); Engine Action #9 |
| `ev[12]` | `1 (Action / Talk)` | Target Inspected is obj[11] AND Story Flag 1 (mask 255) SET | Close Dialogue Sub-Window (11); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[13]` | `1 (Action / Talk)` | Target Inspected is obj[12] AND Story Flag 1 (mask 255) SET | Close Dialogue Sub-Window (12); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[14]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Close Dialogue Sub-Window (13); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[15]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Close Dialogue Sub-Window (14); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[16]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Close Dialogue Sub-Window (15); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[17]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Close Dialogue Sub-Window (16); Warp Room -> Submap 255 at (254,204) facing 204 |
| `ev[18]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Close Dialogue Sub-Window (17); Warp Room -> Submap 255 at (254,204) facing 204 |

---


