# Suikoden II Geographic Area Catalog: Castle HQ: Memorial Graveyard

**Geographic Scope & Role**: Sacred lakeside bluff; memorial headstones dedicated to fallen comrades and deceased heroes of the unification war.

**Regional Category**: Region `VK` | **Master Maps Included**: `vk23`

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

## Location Map: `vk23`

- **Master Map Container**: `vk23.json`
- **Submap Layer Files**: vk23_11.json
- **Collision Grid Files**: vk23_map_00.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 1

### Submap Layer `vk23_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `52` Objects | **Script Count (`evkaz`)**: `122` Scripts

#### Complete Physical Entity Inventory (52 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Sierra (Combat)** | `45` | `(55, 30)` | `4x3` | South (Down) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[01]` | Prop / Scenery | **Prop ID 53293** | `53293` | `(53, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 180 |
| `obj[02]` | NPC / Actor | **Tony** | `70` | `(46, 56)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | NPC / Actor | **Youth Brigade Recruit** | `3` | `(80, 24)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[04]` | NPC / Actor | **Luca Blight** | `83` | `(34, 41)` | `4x2` | West (Left) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[05]` | NPC / Actor | **Actor ID 67** | `67` | `(66, 36)` | `17x5` | West (Left) | Dormant / Hidden (0) | Special (3) | 6 | 128 | 0 |
| `obj[06]` | NPC / Actor | **Tuta** | `71` | `(68, 77)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[07]` | NPC / Actor | **Adlai** | `56` | `(66, 56)` | `8x2` | West (Left) | Dormant / Hidden (0) | Special (3) | 2 | 128 | 0 |
| `obj[08]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(28, 38)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(28, 45)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(28, 53)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(34, 54)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(34, 45)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(34, 37)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(40, 37)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[15]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(40, 46)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[16]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(40, 53)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[17]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(46, 54)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[18]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(46, 45)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[19]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(46, 37)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[20]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(51, 43)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[21]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(53, 40)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[22]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(53, 34)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[23]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(55, 37)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[24]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(57, 42)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[25]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(67, 59)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[26]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(71, 60)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[27]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(67, 45)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[28]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(71, 44)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[29]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(77, 42)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[30]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(68, 37)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[31]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(68, 30)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[32]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(68, 21)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[33]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(74, 22)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[34]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(74, 29)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[35]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(74, 37)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[36]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(80, 38)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[37]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(80, 29)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[38]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(80, 22)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[39]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(76, 29)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[40]` | Trigger / Hitbox | **Hitbox Zone (8x4)** | `0` | `(50, 63)` | `7x3` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[41]` | Trigger / Hitbox | **Hitbox Zone (8x4)** | `0` | `(81, 63)` | `7x3` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[42]` | Trigger / Hitbox | **Hitbox Zone (8x4)** | `0` | `(81, 71)` | `7x3` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[43]` | Trigger / Hitbox | **Hitbox Zone (8x4)** | `0` | `(50, 66)` | `7x3` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[44]` | NPC / Actor | **Actor ID 65105** | `65105` | `(68, 33)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[45]` | NPC / Actor | **Actor ID 65153** | `65153` | `(40, 42)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[46]` | NPC / Actor | **Actor ID 65228** | `65228` | `(28, 40)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[47]` | NPC / Actor | **Actor ID 65034** | `65034` | `(28, 49)` | `3x3` | West (Left) | Dormant / Hidden (0) | Special (3) | 1 | 128 | 0 |
| `obj[48]` | NPC / Actor | **Actor ID 65070** | `65070` | `(60, 59)` | `6x3` | West (Left) | Dormant / Hidden (0) | Special (3) | 1 | 128 | 0 |
| `obj[49]` | NPC / Actor | **Actor ID 65035** | `65035` | `(60, 78)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[50]` | Prop / Scenery | **Prop ID 65011** | `65011` | `(63, 78)` | `0x0` | Frame 4 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[51]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(62, 77)` | `2x1` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Sierra (Combat))**: Positioned at tile `(55, 30)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Prop: Object 53293)**: Environmental world dressing prop placed at tile `(53, 18)`. Solid collision is set to `0`.
- **`obj[02]` (Tony)**: Positioned at tile `(46, 56)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Youth Brigade Recruit)**: Positioned at tile `(80, 24)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Luca Blight)**: Positioned at tile `(34, 41)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Object 67)**: Positioned at tile `(66, 36)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[06]` (Tuta)**: Positioned at tile `(68, 77)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[07]` (Adlai)**: Positioned at tile `(66, 56)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[08]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(28, 38)` to `(29, 38)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[09]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(28, 45)` to `(29, 45)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[10]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(28, 53)` to `(29, 53)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[11]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(34, 54)` to `(35, 54)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[12]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(34, 45)` to `(35, 45)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[13]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(34, 37)` to `(35, 37)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[14]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(40, 37)` to `(41, 37)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[15]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(40, 46)` to `(41, 46)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[16]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(40, 53)` to `(41, 53)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[17]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(46, 54)` to `(47, 54)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[18]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(46, 45)` to `(47, 45)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[19]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(46, 37)` to `(47, 37)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[20]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(51, 43)` to `(52, 43)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[21]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(53, 40)` to `(54, 40)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[22]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(53, 34)` to `(54, 34)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[23]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(55, 37)` to `(56, 37)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[24]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(57, 42)` to `(58, 42)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[25]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(67, 59)` to `(68, 59)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[26]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(71, 60)` to `(72, 60)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[27]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(67, 45)` to `(68, 45)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[28]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(71, 44)` to `(72, 44)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[29]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(77, 42)` to `(78, 42)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[30]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(68, 37)` to `(69, 37)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[31]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(68, 30)` to `(69, 30)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[32]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(68, 21)` to `(69, 21)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[33]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(74, 22)` to `(75, 22)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[34]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(74, 29)` to `(75, 29)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[35]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(74, 37)` to `(75, 37)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[36]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(80, 38)` to `(81, 38)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[37]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(80, 29)` to `(81, 29)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[38]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(80, 22)` to `(81, 22)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[39]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(76, 29)` to `(77, 30)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[40]` (Hitbox Zone)**: Bounding trigger area covering `8` tiles wide by `4` tiles high from `(50, 63)` to `(57, 66)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[41]` (Hitbox Zone)**: Bounding trigger area covering `8` tiles wide by `4` tiles high from `(81, 63)` to `(88, 66)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[42]` (Hitbox Zone)**: Bounding trigger area covering `8` tiles wide by `4` tiles high from `(81, 71)` to `(88, 74)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[43]` (Hitbox Zone)**: Bounding trigger area covering `8` tiles wide by `4` tiles high from `(50, 66)` to `(57, 69)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[44]` (Object 65105)**: Positioned at tile `(68, 33)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[45]` (Object 65153)**: Positioned at tile `(40, 42)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[46]` (Object 65228)**: Positioned at tile `(28, 40)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[47]` (Object 65034)**: Positioned at tile `(28, 49)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[48]` (Object 65070)**: Positioned at tile `(60, 59)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[49]` (Object 65035)**: Positioned at tile `(60, 78)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[50]` (Prop: Object 65011)**: Environmental world dressing prop placed at tile `(63, 78)`. Solid collision is set to `128`.
- **`obj[51]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(62, 77)` to `(64, 78)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (122 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #45 AND Player within Box [33..0, 1..35] AND Character #2 Level >= 255 | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[01]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #45 AND Player within Box [33..0, 1..34] AND Character #2 Level >= 255 | Make obj[89] Hidden (disp = 0); Engine Action #9; Warp Town -> Area 3 Map 0 Submap 9 at (47,255) |
| `ev[02]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #45 AND Player within Box [33..1, 2..35] AND Character #1 Level >= 35 AND Character #2 Level >= 255 | Open Dialogue Message Window; Reset Camera Tracking (255) |
| `ev[03]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #45 AND Player within Box [33..1, 2..35] AND Character #1 Level >= 34 AND Character #2 Level >= 255 | Make obj[89] Hidden (disp = 0); Engine Action #9; Warp Town -> Area 3 Map 0 Submap 9 at (47,255) |
| `ev[04]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #70 AND Player within Box [33..1, 2..35] AND Castle HQ Tier >= Level 4 | Open Dialogue Message Window; Screen Fade Transition (255, 254, 204) |
| `ev[05]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #70 AND Player within Box [33..0, 1..255] | Open Dialogue Message Window; Screen Fade Transition (255, 254, 204) |
| `ev[06]` | `2 (Map Init)` | Story Flag 46 (bit 1) CLEAR AND Condition Check #23 AND Story Flag 1 (bit 34) SET AND Player X within Range [4..255] | Open Dialogue Message Window; Close Dialogue Window |
| `ev[07]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #24 AND Player within Box [34..8, 32..255] | Open Dialogue Message Window; Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[08]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #67 AND Player within Box [34..25, 8..33] AND Player X within Range [2..255] | Open Dialogue Message Window; Place Scenery Structure (255) |
| `ev[09]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #71 AND Player within Box [34..4, 4..33] AND Player X within Range [3..255] | Open Dialogue Message Window; Animate Door Open |
| `ev[10]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #56 AND Player within Box [33..0, 2..255] | Open Dialogue Message Window; Show Dialogue Portrait (255, 254, 204) |
| `ev[11]` | `1 (Action / Talk)` | Story Flag 202 (bit 4) SET AND Target Inspected is obj[11] | Open Dialogue Sub-Window (7); Warp Town -> Area 3 Map 11 Submap 1 at (255,254) |
| `ev[12]` | `1 (Action / Talk)` | Story Flag 202 (bit 4) CLEAR AND Target Inspected is obj[11] | Open Dialogue Sub-Window (0); Warp Town -> Area 3 Map 11 Submap 1 at (255,254) |
| `ev[13]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[8] | Open Dialogue Sub-Window (3); Open Dialogue Message Window |
| `ev[14]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[10] | Open Dialogue Sub-Window (3); Warp Room -> Submap 10 at (1,255) facing 254 |
| `ev[15]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[12] | Open Dialogue Sub-Window (3); Warp to Castle HQ (255, 254, 204) |
| `ev[16]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[13] | Open Dialogue Sub-Window (3); Exit to World Map (255, 254, 204) |
| `ev[17]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[14] | Open Dialogue Sub-Window (3); Engine Action #5 |
| `ev[18]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[15] | Open Dialogue Sub-Window (3); Engine Action #6 |
| `ev[19]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[8] | Open Dialogue Sub-Window (4); Open Dialogue Message Window |
| `ev[20]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[10] | Open Dialogue Sub-Window (4); Warp Room -> Submap 10 at (1,255) facing 254 |
| `ev[21]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[12] | Open Dialogue Sub-Window (4); Warp to Castle HQ (255, 254, 204) |
| `ev[22]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[13] | Open Dialogue Sub-Window (4); Exit to World Map (255, 254, 204) |
| `ev[23]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[14] | Open Dialogue Sub-Window (4); Engine Action #5 |
| `ev[24]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[15] | Open Dialogue Sub-Window (4); Engine Action #6 |
| `ev[25]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[8] | Open Dialogue Sub-Window (5); Open Dialogue Message Window |
| `ev[26]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[10] | Open Dialogue Sub-Window (5); Warp Room -> Submap 10 at (1,255) facing 254 |
| `ev[27]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[12] | Open Dialogue Sub-Window (5); Warp to Castle HQ (255, 254, 204) |
| `ev[28]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[13] | Open Dialogue Sub-Window (5); Exit to World Map (255, 254, 204) |
| `ev[29]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[14] | Open Dialogue Sub-Window (5); Engine Action #5 |
| `ev[30]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[15] | Open Dialogue Sub-Window (5); Engine Action #6 |
| `ev[31]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[8] | Open Dialogue Sub-Window (6); Open Dialogue Message Window |
| `ev[32]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[10] | Open Dialogue Sub-Window (6); Warp Room -> Submap 10 at (1,255) facing 254 |
| `ev[33]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[12] | Open Dialogue Sub-Window (6); Warp to Castle HQ (255, 254, 204) |
| `ev[34]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[13] | Open Dialogue Sub-Window (6); Exit to World Map (255, 254, 204) |
| `ev[35]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[14] | Open Dialogue Sub-Window (6); Engine Action #5 |
| `ev[36]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[15] | Open Dialogue Sub-Window (6); Engine Action #6 |
| `ev[37]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[8] | Open Dialogue Sub-Window (7); Open Dialogue Message Window |
| `ev[38]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[10] | Open Dialogue Sub-Window (7); Warp Room -> Submap 10 at (1,255) facing 254 |
| `ev[39]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[12] | Open Dialogue Sub-Window (7); Warp to Castle HQ (255, 254, 204) |
| `ev[40]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[13] | Open Dialogue Sub-Window (7); Exit to World Map (255, 254, 204) |
| `ev[41]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[14] | Open Dialogue Sub-Window (7); Engine Action #5 |
| `ev[42]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[15] | Open Dialogue Sub-Window (7); Engine Action #6 |
| `ev[43]` | `1 (Action / Talk)` | Target Inspected is obj[8] | Open Dialogue Sub-Window (0); Open Dialogue Message Window |
| `ev[44]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Open Dialogue Sub-Window (0); Warp Room -> Submap 10 at (1,255) facing 254 |
| `ev[45]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Open Dialogue Sub-Window (0); Warp to Castle HQ (255, 254, 204) |
| `ev[46]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Open Dialogue Sub-Window (0); Exit to World Map (255, 254, 204) |
| `ev[47]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Open Dialogue Sub-Window (0); Engine Action #5 |
| `ev[48]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Open Dialogue Sub-Window (0); Engine Action #6 |
| `ev[49]` | `128 (Loop)` | Player within Box [50..87, 2..71] AND Condition Check #84 | Warp Room -> Submap 1 at (10,16) |
| `ev[50]` | `1 (Action / Talk)` | Player within Box [56..62, 2..88] AND Condition Check #89 AND Story Flag 0 (mask 255) SET | Warp Map Transition (2, 0, 152, 103, 255) |
| `ev[51]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #34 AND Treasure Byte 1 Bit 33 FRESH (Unopened) AND Player X within Range [1..255] | Open Dialogue Message Window; Engine Action #52 |
| `ev[52]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #34 AND Treasure Byte 2 Bit 33 FRESH (Unopened) AND Player X within Range [3..255] | Open Dialogue Message Window; Engine Action #53 |
| `ev[53]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #34 AND Treasure Byte 4 Bit 33 FRESH (Unopened) AND Player X within Range [1..255] | Open Dialogue Message Window; Engine Action #54 |
| `ev[54]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #34 AND Treasure Byte 8 Bit 33 FRESH (Unopened) AND Player X within Range [2..255] | Open Dialogue Message Window; Set Render Priority (pri) (255, 254) |
| `ev[55]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player within Box [3..34, 28..16] | Open Dialogue Message Window; Set Animation Pose (255, 254) |
| `ev[56]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player within Box [1..34, 28..32] | Open Dialogue Message Window; Recruit Character into Active Party (255, 254) |
| `ev[57]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player within Box [2..34, 28..64] | Make obj[0] Hidden (disp = 0); Engine Action #58; Open Dialogue Message Window; Set obj[47] Collision to Passable |
| `ev[58]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[52] | Close Dialogue Sub-Window (52); Reset Camera Tracking (0); Warp to Castle HQ (52, 1, 255) |
| `ev[59]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[53] | Close Dialogue Sub-Window (53); Reset Camera Tracking (1); Warp to Castle HQ (53, 1, 255) |
| `ev[60]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[54] | Close Dialogue Sub-Window (54); Reset Camera Tracking (2); Warp to Castle HQ (54, 1, 255) |
| `ev[61]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[55] | Close Dialogue Sub-Window (55); Reset Camera Tracking (3) |
| `ev[62]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[56] | Close Dialogue Sub-Window (56); Reset Camera Tracking (4) |
| `ev[63]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[57] | Close Dialogue Sub-Window (57); Reset Camera Tracking (5) |
| `ev[64]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[59] | Open Dialogue Sub-Window (8); Engine Action #6 |
| `ev[65]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[52] | Close Dialogue Sub-Window (52); Engine Action #9; Open Dialogue Message Window; Warp to Castle HQ (52, 1, 255) |
| `ev[66]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[53] | Close Dialogue Sub-Window (53); Engine Action #9; Warp Room -> Submap 53 at (1,255) facing 254 |
| `ev[67]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[54] | Close Dialogue Sub-Window (54); Engine Action #9; Warp Town -> Area 3 Map 54 Submap 1 at (255,254) |
| `ev[68]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[55] | Close Dialogue Sub-Window (55); Engine Action #9; Warp to Castle HQ (255, 254, 255) |
| `ev[69]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[56] | Close Dialogue Sub-Window (56); Engine Action #9; Exit to World Map (255, 254, 255) |
| `ev[70]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[57] | Close Dialogue Sub-Window (57); Engine Action #9; Engine Action #5 |
| `ev[71]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[59] | Open Dialogue Sub-Window (9); Engine Action #6 |
| `ev[72]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[52] | Close Dialogue Sub-Window (52); Screen Fade Transition (0, 3, 52); Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[73]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[53] | Close Dialogue Sub-Window (53); Screen Fade Transition (1, 3, 53); Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[74]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[54] | Close Dialogue Sub-Window (54); Screen Fade Transition (2, 3, 54); Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[75]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[55] | Close Dialogue Sub-Window (55); Screen Fade Transition (3, 255, 254) |
| `ev[76]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[56] | Close Dialogue Sub-Window (56); Screen Fade Transition (4, 255, 254) |
| `ev[77]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[57] | Close Dialogue Sub-Window (57); Screen Fade Transition (5, 255, 254) |
| `ev[78]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[59] | Open Dialogue Sub-Window (10); Engine Action #6 |
| `ev[79]` | `1 (Action / Talk)` | Target Inspected is obj[52] | Close Dialogue Sub-Window (52); Warp Town -> Area 0 Map 3 Submap 52 at (1,255) |
| `ev[80]` | `1 (Action / Talk)` | Target Inspected is obj[53] | Close Dialogue Sub-Window (53); Warp Town -> Area 1 Map 3 Submap 53 at (1,255) |
| `ev[81]` | `1 (Action / Talk)` | Target Inspected is obj[54] | Close Dialogue Sub-Window (54); Warp Town -> Area 2 Map 3 Submap 54 at (1,255) |
| `ev[82]` | `1 (Action / Talk)` | Target Inspected is obj[55] | Close Dialogue Sub-Window (55); Warp Town -> Area 3 Map 255 Submap 254 at (255,254) |
| `ev[83]` | `1 (Action / Talk)` | Target Inspected is obj[56] | Close Dialogue Sub-Window (56); Warp Town -> Area 4 Map 255 Submap 254 at (255,254) |
| `ev[84]` | `1 (Action / Talk)` | Target Inspected is obj[57] | Close Dialogue Sub-Window (57); Warp Town -> Area 5 Map 255 Submap 254 at (255,254) |
| `ev[85]` | `1 (Action / Talk)` | Target Inspected is obj[59] | Open Dialogue Sub-Window (2); Engine Action #6 |
| `ev[86]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Close Dialogue Sub-Window (16); Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[87]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Close Dialogue Sub-Window (17); Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[88]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Close Dialogue Sub-Window (18); Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[89]` | `1 (Action / Talk)` | Target Inspected is obj[19] | Close Dialogue Sub-Window (19); Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[90]` | `1 (Action / Talk)` | Target Inspected is obj[20] | Close Dialogue Sub-Window (20); Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[91]` | `1 (Action / Talk)` | Target Inspected is obj[21] | Close Dialogue Sub-Window (21); Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[92]` | `1 (Action / Talk)` | Target Inspected is obj[22] | Close Dialogue Sub-Window (22); Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[93]` | `1 (Action / Talk)` | Target Inspected is obj[23] | Close Dialogue Sub-Window (23); Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[94]` | `1 (Action / Talk)` | Target Inspected is obj[24] | Close Dialogue Sub-Window (24); Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[95]` | `1 (Action / Talk)` | Target Inspected is obj[25] | Close Dialogue Sub-Window (25); Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[96]` | `1 (Action / Talk)` | Target Inspected is obj[26] | Close Dialogue Sub-Window (26); Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[97]` | `1 (Action / Talk)` | Target Inspected is obj[27] | Close Dialogue Sub-Window (27); Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[98]` | `1 (Action / Talk)` | Target Inspected is obj[28] | Close Dialogue Sub-Window (28); Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[99]` | `1 (Action / Talk)` | Target Inspected is obj[29] | Close Dialogue Sub-Window (29); Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[100]` | `1 (Action / Talk)` | Target Inspected is obj[30] | Close Dialogue Sub-Window (30); Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[101]` | `1 (Action / Talk)` | Target Inspected is obj[31] | Close Dialogue Sub-Window (31); Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[102]` | `1 (Action / Talk)` | Target Inspected is obj[32] | Close Dialogue Sub-Window (32); Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[103]` | `1 (Action / Talk)` | Target Inspected is obj[33] | Close Dialogue Sub-Window (33); Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[104]` | `1 (Action / Talk)` | Target Inspected is obj[34] | Close Dialogue Sub-Window (34); Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[105]` | `1 (Action / Talk)` | Target Inspected is obj[35] | Close Dialogue Sub-Window (35); Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[106]` | `1 (Action / Talk)` | Target Inspected is obj[36] | Close Dialogue Sub-Window (36); Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[107]` | `1 (Action / Talk)` | Target Inspected is obj[37] | Close Dialogue Sub-Window (37); Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[108]` | `1 (Action / Talk)` | Target Inspected is obj[38] | Close Dialogue Sub-Window (38); Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[109]` | `1 (Action / Talk)` | Target Inspected is obj[39] | Close Dialogue Sub-Window (39); Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[110]` | `1 (Action / Talk)` | Target Inspected is obj[40] | Close Dialogue Sub-Window (40); Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[111]` | `1 (Action / Talk)` | Target Inspected is obj[41] | Close Dialogue Sub-Window (41); Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[112]` | `1 (Action / Talk)` | Target Inspected is obj[42] | Close Dialogue Sub-Window (42); Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[113]` | `1 (Action / Talk)` | Target Inspected is obj[43] | Close Dialogue Sub-Window (43); Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[114]` | `1 (Action / Talk)` | Target Inspected is obj[44] | Close Dialogue Sub-Window (44); Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[115]` | `1 (Action / Talk)` | Target Inspected is obj[45] | Close Dialogue Sub-Window (45); Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[116]` | `1 (Action / Talk)` | Target Inspected is obj[46] | Close Dialogue Sub-Window (46); Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[117]` | `1 (Action / Talk)` | Target Inspected is obj[47] | Close Dialogue Sub-Window (47); Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[118]` | `1 (Action / Talk)` | Target Inspected is obj[48] | Close Dialogue Sub-Window (48); Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[119]` | `1 (Action / Talk)` | Target Inspected is obj[49] | Close Dialogue Sub-Window (49); Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[120]` | `1 (Action / Talk)` | Target Inspected is obj[50] | Close Dialogue Sub-Window (50); Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[121]` | `1 (Action / Talk)` | Target Inspected is obj[51] | Close Dialogue Sub-Window (51); Warp Room -> Submap 255 at (254,255) facing 254 |

---


