# Suikoden II Geographic Area Catalog: Castle HQ: Combat Dojo & Sparring Arena

**Geographic Scope & Role**: Martial arts practice arena; training floor mats, weapon sparring racks, physical combat instructors, and one-on-one combat practice ring.

**Regional Category**: Region `VK` | **Master Maps Included**: `vk03`

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

## Location Map: `vk03`

- **Master Map Container**: `vk03.json`
- **Submap Layer Files**: vk03_04.json, vk03_06.json, vk03_08.json
- **Collision Grid Files**: vk03_map_00.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 1

### Submap Layer `vk03_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `41` Objects | **Script Count (`evkaz`)**: `199` Scripts

#### Complete Physical Entity Inventory (41 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(72, 18)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[01]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(60, 18)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(51, 19)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(43, 18)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(24, 18)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | NPC / Actor | **Actor ID 63** | `63` | `(50, 25)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[06]` | NPC / Actor | **Genshu** | `47` | `(55, 26)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[07]` | NPC / Actor | **Actor ID 62** | `62` | `(26, 24)` | `5x5` | South (Down) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[08]` | NPC / Actor | **Actor ID 69** | `69` | `(46, 31)` | `0x0` | Up (North) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[09]` | Prop / Scenery | **Prop ID 53317** | `53317` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Trigger / Hitbox | **Hitbox Zone (6x2)** | `0` | `(45, 30)` | `5x1` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | NPC / Actor | **Wakaba** | `68` | `(54, 31)` | `0x0` | Up (North) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[12]` | Prop / Scenery | **Prop ID 53316** | `53316` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | Trigger / Hitbox | **Hitbox Zone (5x2)** | `0` | `(51, 30)` | `4x1` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | NPC / Actor | **Actor ID 73** | `73` | `(37, 29)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[15]` | NPC / Actor | **Shin** | `12` | `(37, 29)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[16]` | NPC / Actor | **Anita** | `39` | `(65, 27)` | `0x0` | Up (North) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[17]` | NPC / Actor | **Camus** | `32` | `(28, 29)` | `0x0` | Up (North) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[18]` | NPC / Actor | **Actor ID 119** | `119` | `(43, 38)` | `13x4` | Up (North) | Dormant / Hidden (0) | Special (3) | 4 | 128 | 0 |
| `obj[19]` | NPC / Actor | **Nanami** | `7` | `(29, 41)` | `0x0` | East (Right) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[20]` | NPC / Actor | **Apple** | `8` | `(33, 41)` | `0x0` | Up (North) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[21]` | NPC / Actor | **Actor ID 65105** | `65105` | `(37, 33)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[22]` | NPC / Actor | **Actor ID 65105** | `65105` | `(34, 33)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[23]` | NPC / Actor | **Actor ID 65105** | `65105` | `(40, 33)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[24]` | NPC / Actor | **Actor ID 65105** | `65105` | `(37, 35)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[25]` | NPC / Actor | **Actor ID 65105** | `65105` | `(34, 35)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[26]` | NPC / Actor | **Actor ID 65105** | `65105` | `(40, 35)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[27]` | NPC / Actor | **Actor ID 65107** | `65107` | `(37, 37)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[28]` | NPC / Actor | **Actor ID 65107** | `65107` | `(34, 37)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[29]` | NPC / Actor | **Actor ID 65107** | `65107` | `(40, 37)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[30]` | NPC / Actor | **Actor ID 65153** | `65153` | `(36, 39)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[31]` | NPC / Actor | **Actor ID 65153** | `65153` | `(40, 40)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[32]` | NPC / Actor | **Actor ID 65153** | `65153` | `(38, 41)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[33]` | NPC / Actor | **Actor ID 64514** | `64514` | `(64, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[34]` | NPC / Actor | **Actor ID 64514** | `64514` | `(66, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[35]` | NPC / Actor | **Actor ID 64514** | `64514` | `(68, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[36]` | NPC / Actor | **Actor ID 64514** | `64514` | `(70, 18)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[37]` | Trigger / Hitbox | **Hitbox Zone (1x2)** | `0` | `(64, 20)` | `0x1` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[38]` | Trigger / Hitbox | **Hitbox Zone (1x2)** | `0` | `(66, 20)` | `0x1` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[39]` | Trigger / Hitbox | **Hitbox Zone (1x2)** | `0` | `(68, 20)` | `0x1` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[40]` | Trigger / Hitbox | **Hitbox Zone (1x2)** | `0` | `(70, 20)` | `0x1` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(72, 18)` to `(75, 19)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[01]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(60, 18)` to `(61, 19)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[02]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(51, 19)` to `(54, 20)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[03]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(43, 18)` to `(46, 19)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[04]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(24, 18)` to `(26, 19)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[05]` (Object 63)**: Positioned at tile `(50, 25)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[06]` (Genshu)**: Positioned at tile `(55, 26)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[07]` (Object 62)**: Positioned at tile `(26, 24)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[08]` (Object 69)**: Positioned at tile `(46, 31)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[09]` (Prop: Object 53317)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[10]` (Hitbox Zone)**: Bounding trigger area covering `6` tiles wide by `2` tiles high from `(45, 30)` to `(50, 31)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[11]` (Wakaba)**: Positioned at tile `(54, 31)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[12]` (Prop: Object 53316)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[13]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `2` tiles high from `(51, 30)` to `(55, 31)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[14]` (Object 73)**: Positioned at tile `(37, 29)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[15]` (Shin)**: Positioned at tile `(37, 29)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[16]` (Anita)**: Positioned at tile `(65, 27)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[17]` (Camus)**: Positioned at tile `(28, 29)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[18]` (Object 119)**: Positioned at tile `(43, 38)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[19]` (Nanami)**: Positioned at tile `(29, 41)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[20]` (Apple)**: Positioned at tile `(33, 41)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[21]` (Object 65105)**: Positioned at tile `(37, 33)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[22]` (Object 65105)**: Positioned at tile `(34, 33)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[23]` (Object 65105)**: Positioned at tile `(40, 33)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[24]` (Object 65105)**: Positioned at tile `(37, 35)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[25]` (Object 65105)**: Positioned at tile `(34, 35)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[26]` (Object 65105)**: Positioned at tile `(40, 35)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[27]` (Object 65107)**: Positioned at tile `(37, 37)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[28]` (Object 65107)**: Positioned at tile `(34, 37)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[29]` (Object 65107)**: Positioned at tile `(40, 37)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[30]` (Object 65153)**: Positioned at tile `(36, 39)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[31]` (Object 65153)**: Positioned at tile `(40, 40)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[32]` (Object 65153)**: Positioned at tile `(38, 41)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[33]` (Object 64514)**: Positioned at tile `(64, 18)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[34]` (Object 64514)**: Positioned at tile `(66, 18)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[35]` (Object 64514)**: Positioned at tile `(68, 18)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[36]` (Object 64514)**: Positioned at tile `(70, 18)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[37]` (Hitbox Zone)**: Bounding trigger area covering `1` tiles wide by `2` tiles high from `(64, 20)` to `(64, 21)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[38]` (Hitbox Zone)**: Bounding trigger area covering `1` tiles wide by `2` tiles high from `(66, 20)` to `(66, 21)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[39]` (Hitbox Zone)**: Bounding trigger area covering `1` tiles wide by `2` tiles high from `(68, 20)` to `(68, 21)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[40]` (Hitbox Zone)**: Bounding trigger area covering `1` tiles wide by `2` tiles high from `(70, 20)` to `(70, 21)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (199 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #63 AND Player within Box [33..1, 3..255] | Open Dialogue Message Window; Place Scenery Structure (255) |
| `ev[01]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[13] | Open Dialogue Sub-Window (3); Open Dialogue Message Window |
| `ev[02]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[13] | Open Dialogue Sub-Window (4); Open Dialogue Message Window |
| `ev[03]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[13] | Open Dialogue Sub-Window (5); Open Dialogue Message Window |
| `ev[04]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[13] | Open Dialogue Sub-Window (6); Open Dialogue Message Window |
| `ev[05]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[13] | Open Dialogue Sub-Window (7); Open Dialogue Message Window |
| `ev[06]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Open Dialogue Sub-Window (0); Open Dialogue Message Window |
| `ev[07]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #47 AND Player within Box [33..1, 3..255] | Open Dialogue Message Window; Animate Door Open |
| `ev[08]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[14] | Open Dialogue Sub-Window (3); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[09]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[14] | Open Dialogue Sub-Window (4); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[10]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[14] | Open Dialogue Sub-Window (5); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[11]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[14] | Open Dialogue Sub-Window (6); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[12]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[14] | Open Dialogue Sub-Window (7); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[13]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Open Dialogue Sub-Window (0); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[14]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #62 AND Player within Box [35..20, 1..33] AND Player X within Range [3..255] | Open Dialogue Message Window; Show Dialogue Portrait (255, 254, 204) |
| `ev[15]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[15] | Open Dialogue Sub-Window (3); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[16]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[15] | Open Dialogue Sub-Window (4); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[17]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[15] | Open Dialogue Sub-Window (5); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[18]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[15] | Open Dialogue Sub-Window (6); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[19]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[15] | Open Dialogue Sub-Window (7); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[20]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Open Dialogue Sub-Window (0); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[21]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #69 AND Player within Box [35..23, 4..33] AND Player X within Range [3..255] | Make obj[2] Hidden (disp = 0); Dismiss Dialogue Portrait; Make obj[31] Hidden (disp = 0); Warp Town -> Area 17 Map 46 Submap 31 at (0,17); Open Dialogue Message Window; Display Speaker Name Box (89); Change Portrait Expression (2); Open Dialogue Message Window; Teleport obj[255] to (254,204) |
| `ev[22]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[18] | Close Dialogue Sub-Window (16); Warp to Castle HQ (3, 255, 254) |
| `ev[23]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[18] | Close Dialogue Sub-Window (16); Exit to World Map (3, 255, 254) |
| `ev[24]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[18] | Close Dialogue Sub-Window (16); Engine Action #5; Warp to Castle HQ (255, 254, 204) |
| `ev[25]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[18] | Close Dialogue Sub-Window (16); Engine Action #6; Warp to Castle HQ (255, 254, 204) |
| `ev[26]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[18] | Close Dialogue Sub-Window (16); Pan Camera (3, 255, 254) |
| `ev[27]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Close Dialogue Sub-Window (16); Open Dialogue Message Window; Warp to Castle HQ (255, 254, 204) |
| `ev[28]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #68 AND Player within Box [24..69, 1..35] AND Condition Check #23 AND Story Flag 33 (bit 1) CLEAR AND Story Flag 255 (bit 254) SET | Make obj[2] Hidden (disp = 0); Display Choice Selection (54, 31); Warp to Castle HQ (19, 0, 0); Display Choice Selection (47, 255) |
| `ev[29]` | `1 (Action / Talk)` | Condition Check #24 AND Condition Check #69 AND Player within Box [3..134, 1..5] AND Character #255 Level >= 254 | Close Dialogue Sub-Window (19); Close Dialogue Window; Engine Action #5 |
| `ev[30]` | `1 (Action / Talk)` | Condition Check #24 AND Condition Check #69 AND Player within Box [3..132, 64..4] AND Condition Check #134 AND Player within Box [37..1, 10..0] AND Condition Check #30 AND Always Passes (Unconditional) AND Target Inspected is obj[19] | Close Dialogue Sub-Window (19); Close Dialogue Window; Exit to World Map (255, 254, 204) |
| `ev[31]` | `1 (Action / Talk)` | Condition Check #24 AND Condition Check #69 AND Player within Box [3..20, 128..4] AND Condition Check #132 AND Condition Check #64 AND Target Inspected is obj[19] | Close Dialogue Sub-Window (19); Close Dialogue Window; Warp to Castle HQ (255, 254, 204) |
| `ev[32]` | `1 (Action / Talk)` | Condition Check #24 AND Condition Check #69 AND Player within Box [3..122, 16..4] AND Condition Check #128 AND Player within Box [37..1, 10..0] AND Condition Check #30 AND Always Passes (Unconditional) AND Target Inspected is obj[19] | Close Dialogue Sub-Window (19); Close Dialogue Window; Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[33]` | `1 (Action / Talk)` | Condition Check #24 AND Condition Check #69 AND Player within Box [3..118, 4..4] AND Condition Check #122 AND Star of Destiny #5 Recruited AND Character #255 Level >= 254 | Close Dialogue Sub-Window (19); Close Dialogue Window; Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[34]` | `1 (Action / Talk)` | Condition Check #24 AND Condition Check #69 AND Player within Box [5..19, 255..254] | Close Dialogue Sub-Window (19); Close Dialogue Window; Open Dialogue Message Window |
| `ev[35]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #68 AND Player within Box [23..69, 1..35] AND Condition Check #23 AND Story Flag 33 (bit 1) CLEAR AND Story Flag 255 (bit 254) SET | Make obj[2] Hidden (disp = 0); Display Choice Selection (54, 31); Warp Town -> Area 20 Map 54 Submap 31 at (89,20); Warp Town -> Area 0 Map 0 Submap 20 at (0,21); Teleport obj[255] to (254,204) |
| `ev[36]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #69 AND Player within Box [3..134, 1..5] AND Inventory Holds Item #255 | Close Dialogue Sub-Window (19); Warp to Castle HQ (4, 255, 254) |
| `ev[37]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #69 AND Player within Box [3..132, 64..4] AND Condition Check #134 AND Player within Box [37..1, 10..0] AND Condition Check #30 AND Always Passes (Unconditional) AND Target Inspected is obj[21] | Close Dialogue Sub-Window (19); Exit to World Map (4, 255, 254) |
| `ev[38]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #69 AND Player within Box [3..20, 128..4] AND Condition Check #132 AND Condition Check #64 AND Target Inspected is obj[21] | Close Dialogue Sub-Window (19); Engine Action #5; Exit to World Map (255, 254, 204) |
| `ev[39]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #69 AND Player within Box [3..122, 16..4] AND Condition Check #128 AND Player within Box [37..1, 10..0] AND Condition Check #30 AND Always Passes (Unconditional) AND Target Inspected is obj[21] | Close Dialogue Sub-Window (19); Engine Action #6; Exit to World Map (255, 254, 204) |
| `ev[40]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #69 AND Player within Box [3..118, 4..4] AND Condition Check #122 AND Star of Destiny #5 Recruited AND Inventory Holds Item #255 | Close Dialogue Sub-Window (19); Pan Camera (4, 255, 254) |
| `ev[41]` | `1 (Action / Talk)` | Condition Check #23 AND Condition Check #69 AND Player within Box [5..21, 255..254] | Close Dialogue Sub-Window (19); Open Dialogue Message Window; Exit to World Map (255, 254, 204) |
| `ev[42]` | `128 (Loop)` | Condition Check #23 AND Condition Check #69 AND Player within Box [23..68, 1..35] AND Condition Check #23 AND Story Flag 33 (bit 1) CLEAR AND Story Flag 255 (bit 254) SET | Engine Action #89; Change Portrait Expression (2); Open Dialogue Message Window; Set Combat Battle BGM (10); Engine Action #89; Branch on Choice (2, 0); Set Combat Battle BGM (30); Engine Action #89; Change Portrait Expression (2); Warp Room -> Submap 20 at (2,1) facing 47; Engine Action #89; Change Portrait Expression (5); Engine Action #89; Change Portrait Expression (5); Engine Action #89; Change Portrait Expression (2); Warp Town -> Area 89 Map 20 Submap 2 at (2,47); Set Entity Movement Speed (2, 90); Change Portrait Expression (4); Pan Camera (19, 2, 30); Engine Action #90; Branch on Choice (4, 7); Display Speaker Name Box (2); Dismiss Emotion Bubble (255); Walk obj[89] to (17,5); Engine Action #89; Change Portrait Expression (5); Engine Action #89; Change Portrait Expression (2); Warp to Castle HQ (89, 20, 2); Warp to Castle HQ (47, 89, 17); Engine Action #5; Engine Action #89; Change Portrait Expression (5); Set Combat Battle BGM (20); Engine Action #89; Change Portrait Expression (2); Reset Camera Tracking (89); Branch on Choice (2, 4); Launch Tactical War Battle (1); Teleport obj[73] to (60,89); Change Portrait Expression (2); Warp to Castle HQ (89, 20, 2); Warp to Castle HQ (37, 1, 47); Engine Action #89; Change Portrait Expression (5); Engine Action #89; Change Portrait Expression (5); Set Combat Battle BGM (10); Engine Action #89; Change Portrait Expression (2); Exit to World Map (89, 20, 2); Reset Camera Tracking (36); Warp Room -> Submap 73 at (60,89) facing 17; Warp Town -> Area 3 Map 89 Submap 20 at (2,3); Toggle Random Encounters (1); Teleport obj[89] to (17,5); Engine Action #89; Change Portrait Expression (5); Set Combat Battle BGM (10); Engine Action #89; Change Portrait Expression (2); Reset Camera Tracking (89); Branch on Choice (2, 4); Launch Tactical War Battle (1); Teleport obj[73] to (60,89); Change Portrait Expression (2); Warp to Castle HQ (89, 20, 2); Warp to Castle HQ (37, 1, 47); Engine Action #89; Change Portrait Expression (5); Engine Action #89; Change Portrait Expression (5); Set Combat Battle BGM (10); Engine Action #89; Change Portrait Expression (2); Exit to World Map (89, 20, 2); Reset Camera Tracking (36); Warp Room -> Submap 73 at (60,89) facing 17; Warp Town -> Area 3 Map 89 Submap 20 at (2,3); Toggle Random Encounters (1); Teleport obj[89] to (17,5); Engine Action #89; Change Portrait Expression (5); Engine Action #89; Change Portrait Expression (2); Engine Action #5; Engine Action #89; Branch on Choice (2, 5); Teleport obj[89] to (17,5); Engine Action #89; Change Portrait Expression (5); Engine Action #89; Change Portrait Expression (2); Engine Action #6; Engine Action #89; Branch on Choice (2, 6); Teleport obj[49] to (2,90); Change Portrait Expression (4); Pan Camera (18, 2, 30); Engine Action #90; Branch on Choice (4, 7); Display Choice Selection (2, 30); Walk obj[89] to (17,5); Engine Action #89; Change Portrait Expression (5); Engine Action #89; Change Portrait Expression (2); Pan Camera (89, 20, 2); Pan Camera (47, 89, 17); Engine Action #5; Engine Action #89; Change Portrait Expression (5); Set Combat Battle BGM (60) |
| `ev[43]` | `128 (Loop)` | Condition Check #23 AND Condition Check #69 AND Player within Box [23..68, 1..35] AND Condition Check #23 AND Story Flag 33 (bit 1) CLEAR AND Story Flag 6 (bit 1) SET | Jump to Bytecode Offset (4, 45); Set Combat Battle BGM (10); Jump to Bytecode Offset (4, 45); Set Combat Battle BGM (10); Jump to Bytecode Offset (4, 45); Set Combat Battle BGM (10); Jump to Bytecode Offset (4, 45); Set Combat Battle BGM (10); Jump to Bytecode Offset (4, 45); Set Combat Battle BGM (10); Jump to Bytecode Offset (4, 45); Set Combat Battle BGM (15) |
| `ev[44]` | `2 (Map Init)` | Story Flag 47 (bit 128) CLEAR AND Condition Check #23 AND Condition Check #73 AND Player within Box [35..25, 64..33] AND Player X within Range [3..255] | Open Dialogue Message Window; Set Story Flag (255, 254) |
| `ev[45]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[22] | Open Dialogue Sub-Window (3); Engine Action #5 |
| `ev[46]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[22] | Open Dialogue Sub-Window (4); Engine Action #5 |
| `ev[47]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[22] | Open Dialogue Sub-Window (5); Engine Action #5 |
| `ev[48]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[22] | Open Dialogue Sub-Window (6); Engine Action #5 |
| `ev[49]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[22] | Open Dialogue Sub-Window (7); Engine Action #5 |
| `ev[50]` | `1 (Action / Talk)` | Target Inspected is obj[22] | Open Dialogue Sub-Window (0); Engine Action #5 |
| `ev[51]` | `2 (Map Init)` | Story Flag 48 (bit 1) CLEAR AND Condition Check #23 AND Player Y in Range [1..34] AND Character #4 Level >= 33 AND Player X within Range [3..255] | Open Dialogue Message Window; Open Dialogue Sub-Window (255) |
| `ev[52]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[23] | Open Dialogue Sub-Window (3); Engine Action #6 |
| `ev[53]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[23] | Open Dialogue Sub-Window (4); Engine Action #6 |
| `ev[54]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[23] | Open Dialogue Sub-Window (5); Engine Action #6 |
| `ev[55]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[23] | Open Dialogue Sub-Window (6); Engine Action #6 |
| `ev[56]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[23] | Open Dialogue Sub-Window (7); Engine Action #6 |
| `ev[57]` | `1 (Action / Talk)` | Target Inspected is obj[23] | Open Dialogue Sub-Window (0); Engine Action #6 |
| `ev[58]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #39 AND Player within Box [34..19, 32..33] AND Player X within Range [3..255] | Open Dialogue Message Window; Close Dialogue Sub-Window (255) |
| `ev[59]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[24] | Open Dialogue Sub-Window (3); Pan Camera (255, 254, 204) |
| `ev[60]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[24] | Open Dialogue Sub-Window (4); Pan Camera (255, 254, 204) |
| `ev[61]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[24] | Open Dialogue Sub-Window (5); Pan Camera (255, 254, 204) |
| `ev[62]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[24] | Open Dialogue Sub-Window (6); Pan Camera (255, 254, 204) |
| `ev[63]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[24] | Open Dialogue Sub-Window (7); Pan Camera (255, 254, 204) |
| `ev[64]` | `1 (Action / Talk)` | Target Inspected is obj[24] | Open Dialogue Sub-Window (0); Pan Camera (255, 254, 204) |
| `ev[65]` | `2 (Map Init)` | Story Flag 47 (bit 2) CLEAR AND Condition Check #23 AND Condition Check #32 AND Player within Box [34..21, 4..33] AND Player X within Range [3..255] | Open Dialogue Message Window; Clear Dialogue Sub-Window |
| `ev[66]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[25] | Open Dialogue Sub-Window (3); Reset Camera Tracking (255) |
| `ev[67]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[25] | Open Dialogue Sub-Window (4); Reset Camera Tracking (255) |
| `ev[68]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[25] | Open Dialogue Sub-Window (5); Reset Camera Tracking (255) |
| `ev[69]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[25] | Open Dialogue Sub-Window (6); Reset Camera Tracking (255) |
| `ev[70]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[25] | Open Dialogue Sub-Window (7); Reset Camera Tracking (255) |
| `ev[71]` | `1 (Action / Talk)` | Target Inspected is obj[25] | Open Dialogue Sub-Window (0); Reset Camera Tracking (255) |
| `ev[72]` | `2 (Map Init)` | Condition Check #23 AND Condition Check #119 AND Player within Box [34..24, 4..33] AND Player within Box [3..4, 134..1] | Open Dialogue Message Window; Fade In from Black (255) |
| `ev[73]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[26] | Open Dialogue Sub-Window (3); Engine Action #9 |
| `ev[74]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[26] | Open Dialogue Sub-Window (4); Engine Action #9 |
| `ev[75]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[26] | Open Dialogue Sub-Window (5); Engine Action #9 |
| `ev[76]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[26] | Open Dialogue Sub-Window (6); Engine Action #9 |
| `ev[77]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[26] | Open Dialogue Sub-Window (7); Engine Action #9 |
| `ev[78]` | `1 (Action / Talk)` | Target Inspected is obj[26] | Open Dialogue Sub-Window (0); Engine Action #9 |
| `ev[79]` | `2 (Map Init)` | Condition Check #23 AND Temp Event Flag #1 SET AND Condition Check #34 AND Story Flag 4 (bit 33) SET AND Player X within Range [3..255] | Open Dialogue Message Window; Fade Out to Black (255) |
| `ev[80]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[27] | Open Dialogue Sub-Window (3); Screen Fade Transition (255, 254, 204) |
| `ev[81]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[27] | Open Dialogue Sub-Window (4); Screen Fade Transition (255, 254, 204) |
| `ev[82]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[27] | Open Dialogue Sub-Window (5); Screen Fade Transition (255, 254, 204) |
| `ev[83]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[27] | Open Dialogue Sub-Window (6); Screen Fade Transition (255, 254, 204) |
| `ev[84]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[27] | Open Dialogue Sub-Window (7); Screen Fade Transition (255, 254, 204) |
| `ev[85]` | `1 (Action / Talk)` | Target Inspected is obj[27] | Open Dialogue Sub-Window (0); Screen Fade Transition (255, 254, 204) |
| `ev[86]` | `2 (Map Init)` | Condition Check #23 AND Temp Event Flag #1 CLEAR AND Condition Check #34 AND Story Flag 4 (bit 33) SET AND Player X within Range [3..255] | Open Dialogue Message Window; Display Chapter Text (255) |
| `ev[87]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[28] | Open Dialogue Sub-Window (3); Close Dialogue Window |
| `ev[88]` | `1 (Action / Talk)` | Story Flag 132 (bit 64) SET AND Story Flag 134 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[28] | Open Dialogue Sub-Window (4); Close Dialogue Window |
| `ev[89]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 132 (bit 64) CLEAR AND Target Inspected is obj[28] | Open Dialogue Sub-Window (5); Close Dialogue Window |
| `ev[90]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[28] | Open Dialogue Sub-Window (6); Close Dialogue Window |
| `ev[91]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[28] | Open Dialogue Sub-Window (7); Close Dialogue Window |
| `ev[92]` | `1 (Action / Talk)` | Target Inspected is obj[28] | Open Dialogue Sub-Window (0); Close Dialogue Window |
| `ev[93]` | `128 (Loop)` | Player within Box [65..75, 2..21] AND Condition Check #50 AND Story Flag 144 (bit 64) CLEAR | Warp Room -> Submap 1 at (10,3) |
| `ev[94]` | `128 (Loop)` | Player within Box [65..75, 2..21] AND Condition Check #50 AND Story Flag 144 (bit 64) SET | Warp Room -> Submap 1 at (10,4) |
| `ev[95]` | `128 (Loop)` | Player within Box [25..64, 2..21] AND Condition Check #50 | Warp Room -> Submap 1 at (10,10) |
| `ev[96]` | `1 (Action / Talk)` | Player within Box [46..54, 2..50] AND Condition Check #51 AND Story Flag 0 (mask 255) SET | Warp Map Transition (2, 1, 19, 12, 255) |
| `ev[97]` | `1 (Action / Talk)` | Player within Box [76..77, 2..29] AND Condition Check #40 AND Story Flag 3 (mask 255) SET | Warp Map Transition (2, 0, 14, 70, 255) |
| `ev[98]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [3..255] | Open Dialogue Message Window; Display Emotion Bubble (255, 254) |
| `ev[99]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Story Flag 122 (bit 16) CLEAR AND Condition Check #33 AND Player X within Range [3..255] | Open Dialogue Message Window; Dismiss Emotion Bubble (255) |
| `ev[100]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [3..255] | Open Dialogue Message Window; Warp Room -> Submap 255 at (254,204) |
| `ev[101]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [3..255] | Open Dialogue Message Window; Warp Map Transition (255, 254, 204, 204, 204) |
| `ev[102]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Story Flag 122 (bit 16) CLEAR AND Condition Check #33 AND Player X within Range [3..255] | Open Dialogue Message Window; Return to Previous Memory Map (255) |
| `ev[103]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [3..255] | Open Dialogue Message Window; Return Warp to Castle Base (255, 254) |
| `ev[104]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [3..255] | Open Dialogue Message Window; Start Boss Battle #255 (BGM: 254) |
| `ev[105]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [3..255] | Open Dialogue Message Window; Launch Tactical War Battle (255) |
| `ev[106]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [3..255] | Open Dialogue Message Window; Toggle Random Encounters (255) |
| `ev[107]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [4..255] | Open Dialogue Message Window; Open Save Crystal Menu (MSaveInit) |
| `ev[108]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [4..255] | Open Dialogue Message Window; Engine Action #39 |
| `ev[109]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #33 AND Player X within Range [4..255] | Open Dialogue Message Window; Engine Action #40 |
| `ev[110]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #34 AND Condition Check #26 AND Star of Destiny #25 Recruited AND Condition Check #25 AND Condition Check #33 AND Player X within Range [4..255] | Make obj[0] Hidden (disp = 0); Award Potch Loot (+45 Potch); Teleport obj[255] to (254,204) |
| `ev[111]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #34 AND Condition Check #26 AND Star of Destiny #25 Recruited AND Condition Check #25 AND Condition Check #33 AND Player X within Range [4..255] | Make obj[0] Hidden (disp = 0); Remove Item from Inventory (0, 46); Teleport obj[255] to (254,204) |
| `ev[112]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #34 AND Condition Check #26 AND Star of Destiny #25 Recruited AND Condition Check #25 AND Condition Check #33 AND Player X within Range [4..255] | Make obj[0] Hidden (disp = 0); Open Shop Menu #47 (Type: 0); Teleport obj[255] to (254,204) |
| `ev[113]` | `2 (Map Init)` | Story Flag 112 (bit 64) SET AND Condition Check #34 AND Condition Check #26 AND Star of Destiny #25 Recruited AND Condition Check #25 AND Condition Check #33 AND Player X within Range [4..255] | Make obj[0] Hidden (disp = 0); Engine Action #44; Open Dialogue Message Window; Turn obj[47] facing 255 |
| `ev[114]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[29] | Close Dialogue Sub-Window (29); Reset Camera Tracking (0); Warp to Castle HQ (29, 1, 255) |
| `ev[115]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[29] | Close Dialogue Sub-Window (29); Engine Action #9; Open Dialogue Message Window; Warp to Castle HQ (29, 1, 255) |
| `ev[116]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[29] | Close Dialogue Sub-Window (29); Screen Fade Transition (0, 3, 29); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[117]` | `1 (Action / Talk)` | Target Inspected is obj[29] | Close Dialogue Sub-Window (29); Warp Town -> Area 0 Map 3 Submap 29 at (1,255) |
| `ev[118]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[30] | Close Dialogue Sub-Window (30); Reset Camera Tracking (1); Warp to Castle HQ (30, 1, 255) |
| `ev[119]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[30] | Close Dialogue Sub-Window (30); Engine Action #9; Warp Room -> Submap 30 at (1,255) facing 254 |
| `ev[120]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[30] | Close Dialogue Sub-Window (30); Screen Fade Transition (1, 3, 30); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[121]` | `1 (Action / Talk)` | Target Inspected is obj[30] | Close Dialogue Sub-Window (30); Warp Town -> Area 1 Map 3 Submap 30 at (1,255) |
| `ev[122]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[31] | Close Dialogue Sub-Window (31); Reset Camera Tracking (2); Warp to Castle HQ (31, 1, 255) |
| `ev[123]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[31] | Close Dialogue Sub-Window (31); Engine Action #9; Warp Town -> Area 3 Map 31 Submap 1 at (255,254) |
| `ev[124]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[31] | Close Dialogue Sub-Window (31); Screen Fade Transition (2, 3, 31); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[125]` | `1 (Action / Talk)` | Target Inspected is obj[31] | Close Dialogue Sub-Window (31); Warp Town -> Area 2 Map 3 Submap 31 at (1,255) |
| `ev[126]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[32] | Close Dialogue Sub-Window (32); Reset Camera Tracking (3); Warp to Castle HQ (32, 1, 255) |
| `ev[127]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[32] | Close Dialogue Sub-Window (32); Engine Action #9; Warp to Castle HQ (3, 32, 1) |
| `ev[128]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[32] | Close Dialogue Sub-Window (32); Screen Fade Transition (3, 3, 32); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[129]` | `1 (Action / Talk)` | Target Inspected is obj[32] | Close Dialogue Sub-Window (32); Warp Town -> Area 3 Map 3 Submap 32 at (1,255) |
| `ev[130]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[33] | Close Dialogue Sub-Window (33); Reset Camera Tracking (4); Warp to Castle HQ (33, 1, 255) |
| `ev[131]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[33] | Close Dialogue Sub-Window (33); Engine Action #9; Exit to World Map (3, 33, 1) |
| `ev[132]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[33] | Close Dialogue Sub-Window (33); Screen Fade Transition (4, 3, 33); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[133]` | `1 (Action / Talk)` | Target Inspected is obj[33] | Close Dialogue Sub-Window (33); Warp Town -> Area 4 Map 3 Submap 33 at (1,255) |
| `ev[134]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[34] | Close Dialogue Sub-Window (34); Reset Camera Tracking (5); Warp to Castle HQ (34, 1, 255) |
| `ev[135]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[34] | Close Dialogue Sub-Window (34); Engine Action #9; Engine Action #5; Warp to Castle HQ (34, 1, 255) |
| `ev[136]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[34] | Close Dialogue Sub-Window (34); Screen Fade Transition (5, 3, 34); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[137]` | `1 (Action / Talk)` | Target Inspected is obj[34] | Close Dialogue Sub-Window (34); Warp Town -> Area 5 Map 3 Submap 34 at (1,255) |
| `ev[138]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[35] | Close Dialogue Sub-Window (35); Reset Camera Tracking (6); Warp to Castle HQ (35, 1, 255) |
| `ev[139]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[35] | Close Dialogue Sub-Window (35); Engine Action #9; Engine Action #6; Warp to Castle HQ (35, 1, 255) |
| `ev[140]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[35] | Close Dialogue Sub-Window (35); Screen Fade Transition (6, 3, 35); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[141]` | `1 (Action / Talk)` | Target Inspected is obj[35] | Close Dialogue Sub-Window (35); Warp Town -> Area 6 Map 3 Submap 35 at (1,255) |
| `ev[142]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[36] | Close Dialogue Sub-Window (36); Reset Camera Tracking (7); Warp to Castle HQ (36, 1, 255) |
| `ev[143]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[36] | Close Dialogue Sub-Window (36); Engine Action #9; Pan Camera (3, 36, 1) |
| `ev[144]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[36] | Close Dialogue Sub-Window (36); Screen Fade Transition (7, 3, 36); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[145]` | `1 (Action / Talk)` | Target Inspected is obj[36] | Close Dialogue Sub-Window (36); Warp Town -> Area 7 Map 3 Submap 36 at (1,255) |
| `ev[146]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[37] | Close Dialogue Sub-Window (37); Reset Camera Tracking (8); Warp to Castle HQ (37, 1, 255) |
| `ev[147]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[37] | Close Dialogue Sub-Window (37); Engine Action #9; Reset Camera Tracking (3); Toggle Random Encounters (1) |
| `ev[148]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[37] | Close Dialogue Sub-Window (37); Screen Fade Transition (8, 3, 37); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[149]` | `1 (Action / Talk)` | Target Inspected is obj[37] | Close Dialogue Sub-Window (37); Warp Town -> Area 8 Map 3 Submap 37 at (1,255) |
| `ev[150]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[38] | Close Dialogue Sub-Window (38); Reset Camera Tracking (9); Warp to Castle HQ (38, 1, 255) |
| `ev[151]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[38] | Close Dialogue Sub-Window (38); Engine Action #9; Engine Action #9; Warp to Castle HQ (38, 1, 255) |
| `ev[152]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[38] | Close Dialogue Sub-Window (38); Screen Fade Transition (9, 3, 38); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[153]` | `1 (Action / Talk)` | Target Inspected is obj[38] | Close Dialogue Sub-Window (38); Warp Town -> Area 9 Map 3 Submap 38 at (1,255) |
| `ev[154]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[39] | Close Dialogue Sub-Window (39); Reset Camera Tracking (10); Warp to Castle HQ (39, 1, 255) |
| `ev[155]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[39] | Close Dialogue Sub-Window (39); Engine Action #9; Screen Fade Transition (3, 39, 1) |
| `ev[156]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[39] | Close Dialogue Sub-Window (39); Screen Fade Transition (10, 3, 39); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[157]` | `1 (Action / Talk)` | Target Inspected is obj[39] | Close Dialogue Sub-Window (39); Warp Town -> Area 10 Map 3 Submap 39 at (1,255) |
| `ev[158]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[40] | Close Dialogue Sub-Window (40); Reset Camera Tracking (11); Warp to Castle HQ (40, 1, 255) |
| `ev[159]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[40] | Close Dialogue Sub-Window (40); Engine Action #9; Close Dialogue Window; Warp to Castle HQ (40, 1, 255) |
| `ev[160]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[40] | Close Dialogue Sub-Window (40); Screen Fade Transition (11, 3, 40); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[161]` | `1 (Action / Talk)` | Target Inspected is obj[40] | Close Dialogue Sub-Window (40); Warp Town -> Area 11 Map 3 Submap 40 at (1,255) |
| `ev[162]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[41] | Close Dialogue Sub-Window (41); Reset Camera Tracking (12) |
| `ev[163]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[41] | Close Dialogue Sub-Window (41); Engine Action #9; Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[164]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[41] | Close Dialogue Sub-Window (41); Screen Fade Transition (12, 255, 254) |
| `ev[165]` | `1 (Action / Talk)` | Target Inspected is obj[41] | Close Dialogue Sub-Window (41); Warp Town -> Area 12 Map 255 Submap 254 at (255,254) |
| `ev[166]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[45] | Close Dialogue Sub-Window (45); Reset Camera Tracking (12) |
| `ev[167]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[45] | Close Dialogue Sub-Window (45); Engine Action #9; Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[168]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[45] | Close Dialogue Sub-Window (45); Screen Fade Transition (12, 255, 254) |
| `ev[169]` | `1 (Action / Talk)` | Target Inspected is obj[45] | Close Dialogue Sub-Window (45); Warp Town -> Area 12 Map 255 Submap 254 at (255,254) |
| `ev[170]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[42] | Close Dialogue Sub-Window (42); Reset Camera Tracking (13) |
| `ev[171]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[42] | Close Dialogue Sub-Window (42); Engine Action #9; Place Scenery Structure (255) |
| `ev[172]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[42] | Close Dialogue Sub-Window (42); Screen Fade Transition (13, 255, 254) |
| `ev[173]` | `1 (Action / Talk)` | Target Inspected is obj[42] | Close Dialogue Sub-Window (42); Warp Town -> Area 13 Map 255 Submap 254 at (255,254) |
| `ev[174]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[46] | Close Dialogue Sub-Window (46); Reset Camera Tracking (13) |
| `ev[175]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[46] | Close Dialogue Sub-Window (46); Engine Action #9; Place Scenery Structure (255) |
| `ev[176]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[46] | Close Dialogue Sub-Window (46); Screen Fade Transition (13, 255, 254) |
| `ev[177]` | `1 (Action / Talk)` | Target Inspected is obj[46] | Close Dialogue Sub-Window (46); Warp Town -> Area 13 Map 255 Submap 254 at (255,254) |
| `ev[178]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[43] | Close Dialogue Sub-Window (43); Reset Camera Tracking (14) |
| `ev[179]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[43] | Close Dialogue Sub-Window (43); Engine Action #9; Animate Door Open |
| `ev[180]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[43] | Close Dialogue Sub-Window (43); Screen Fade Transition (14, 255, 254) |
| `ev[181]` | `1 (Action / Talk)` | Target Inspected is obj[43] | Close Dialogue Sub-Window (43); Warp Town -> Area 14 Map 255 Submap 254 at (255,254) |
| `ev[182]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[47] | Close Dialogue Sub-Window (47); Reset Camera Tracking (14) |
| `ev[183]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[47] | Close Dialogue Sub-Window (47); Engine Action #9; Animate Door Open |
| `ev[184]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[47] | Close Dialogue Sub-Window (47); Screen Fade Transition (14, 255, 254) |
| `ev[185]` | `1 (Action / Talk)` | Target Inspected is obj[47] | Close Dialogue Sub-Window (47); Warp Town -> Area 14 Map 255 Submap 254 at (255,254) |
| `ev[186]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[44] | Close Dialogue Sub-Window (44); Reset Camera Tracking (15) |
| `ev[187]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[44] | Close Dialogue Sub-Window (44); Engine Action #9; Show Dialogue Portrait (255, 254, 204) |
| `ev[188]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[44] | Close Dialogue Sub-Window (44); Screen Fade Transition (15, 255, 254) |
| `ev[189]` | `1 (Action / Talk)` | Target Inspected is obj[44] | Close Dialogue Sub-Window (44); Warp Town -> Area 15 Map 255 Submap 254 at (255,254) |
| `ev[190]` | `1 (Action / Talk)` | Story Flag 134 (bit 1) SET AND Target Inspected is obj[48] | Close Dialogue Sub-Window (48); Reset Camera Tracking (15) |
| `ev[191]` | `1 (Action / Talk)` | Story Flag 122 (bit 16) SET AND Story Flag 128 (bit 1) CLEAR AND Condition Check #37 AND Player within Box [10..0, 30..0] AND Target Inspected is obj[48] | Close Dialogue Sub-Window (48); Engine Action #9; Show Dialogue Portrait (255, 254, 204) |
| `ev[192]` | `1 (Action / Talk)` | Story Flag 118 (bit 4) SET AND Story Flag 122 (bit 16) CLEAR AND Target Inspected is obj[48] | Close Dialogue Sub-Window (48); Screen Fade Transition (15, 255, 254) |
| `ev[193]` | `1 (Action / Talk)` | Target Inspected is obj[48] | Close Dialogue Sub-Window (48); Warp Town -> Area 15 Map 255 Submap 254 at (255,254) |
| `ev[194]` | `1 (Action / Talk)` | Target Inspected is obj[8] | Open Dialogue Sub-Window (1); Open Dialogue Message Window |
| `ev[195]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Open Dialogue Sub-Window (1); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[196]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Open Dialogue Sub-Window (1); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[197]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Open Dialogue Sub-Window (1); Warp to Castle HQ (255, 254, 204) |
| `ev[198]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Open Dialogue Sub-Window (1); Exit to World Map (255, 254, 204) |

---


