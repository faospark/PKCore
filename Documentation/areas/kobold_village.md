# Suikoden II Geographic Area Catalog: Kobold Village Settlement

**Geographic Scope & Role**: Southern canine tribal village; rustic huts, village elder's council hall, Yuzu's sheep pen, and trade depot.

**Regional Category**: Region `VH` | **Master Maps Included**: `vh03`, `vh07`, `vh09`

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

## Location Map: `vh03`

- **Master Map Container**: `vh03.json`
- **Submap Layer Files**: vh03_02.json, vh03_03.json, vh03_05.json, vh03_06.json, vh03_07.json, vh03_08.json, vh03_10.json, vh03_11.json, vh03_12.json, vh03_13.json, vh03_14.json, vh03_15.json, vh03_16.json, vh03_17.json, vh03_20.json, vh03_21.json, vh03_22.json, vh03_23.json, vh03_24.json
- **Collision Grid Files**: vh03_map_00.json, vh03_map_01.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 8

### Submap Layer `vh03_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `39` Objects | **Script Count (`evkaz`)**: `88` Scripts

#### Complete Physical Entity Inventory (39 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Nanami** | `7` | `(48, 114)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Apple** | `8` | `(46, 104)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Actor ID 102** | `102` | `(48, 61)` | `10x5` | East (Right) | Dormant / Hidden (0) | Special (3) | 4 | 255 | 0 |
| `obj[03]` | NPC / Actor | **Actor ID 102** | `102` | `(52, 65)` | `0x0` | East (Right) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 1 | 0 |
| `obj[04]` | NPC / Actor | **Actor ID 64787** | `64787` | `(50, 58)` | `3x3` | South (Down) | Dormant / Hidden (0) | Special (3) | 2 | 128 | 0 |
| `obj[05]` | NPC / Actor | **Actor ID 64788** | `64788` | `(55, 55)` | `3x3` | South (Down) | Dormant / Hidden (0) | Special (3) | 2 | 128 | 0 |
| `obj[06]` | NPC / Actor | **Actor ID 64789** | `64789` | `(54, 62)` | `3x3` | South (Down) | Dormant / Hidden (0) | Special (3) | 2 | 128 | 0 |
| `obj[07]` | Rest Device / Fire | **Inn Bed / Recovery Device** | `0` | `(64, 36)` | `0x0` | Frame 12 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[08]` | World Device | **Mechanism (ano 4)** | `0` | `(48, 42)` | `0x0` | Frame 4 | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[09]` | World Device | **Mechanism (ano 4)** | `0` | `(64, 60)` | `0x0` | Frame 4 | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[10]` | World Device | **Mechanism (ano 8)** | `0` | `(44, 68)` | `0x0` | Frame 8 | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[11]` | World Device | **Mechanism (ano 6)** | `0` | `(56, 78)` | `0x0` | Frame 6 | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[12]` | World Device | **Mechanism (ano 4)** | `0` | `(66, 84)` | `0x0` | Frame 4 | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[13]` | World Device | **Mechanism (ano 6)** | `0` | `(68, 104)` | `0x0` | Frame 6 | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[14]` | World Device | **Mechanism (ano 4)** | `0` | `(38, 98)` | `0x0` | Frame 4 | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[15]` | World Device | **Mechanism (ano 5)** | `0` | `(48, 42)` | `0x0` | Frame 5 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[16]` | World Device | **Mechanism (ano 5)** | `0` | `(64, 60)` | `0x0` | Frame 5 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[17]` | World Device | **Mechanism (ano 9)** | `0` | `(44, 68)` | `0x0` | Frame 9 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[18]` | World Device | **Mechanism (ano 7)** | `0` | `(56, 78)` | `0x0` | Frame 7 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[19]` | World Device | **Mechanism (ano 5)** | `0` | `(66, 84)` | `0x0` | Frame 5 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[20]` | World Device | **Mechanism (ano 7)** | `0` | `(68, 104)` | `0x0` | Frame 7 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[21]` | World Device | **Mechanism (ano 5)** | `0` | `(38, 98)` | `0x0` | Frame 5 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[22]` | NPC / Actor | **Actor ID 65107** | `65107` | `(63, 35)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[23]` | NPC / Actor | **Actor ID 65160** | `65160` | `(42, 122)` | `5x3` | South (Down) | Visible (1) | Special (3) | 4 | 128 | 0 |
| `obj[24]` | NPC / Actor | **Actor ID 65162** | `65162` | `(40, 105)` | `5x5` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[25]` | NPC / Actor | **Actor ID 65103** | `65103` | `(48, 99)` | `10x5` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[26]` | NPC / Actor | **Actor ID 64857** | `64857` | `(62, 105)` | `5x3` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[27]` | NPC / Actor | **Actor ID 65161** | `65161` | `(65, 89)` | `5x5` | South (Down) | Visible (1) | Special (3) | 4 | 128 | 0 |
| `obj[28]` | NPC / Actor | **Actor ID 65103** | `65103` | `(58, 87)` | `10x10` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[29]` | NPC / Actor | **Actor ID 65148** | `65148` | `(46, 73)` | `5x10` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[30]` | NPC / Actor | **Actor ID 65159** | `65159` | `(56, 67)` | `10x5` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[31]` | NPC / Actor | **Actor ID 65156** | `65156` | `(45, 49)` | `10x10` | South (Down) | Visible (1) | Special (3) | 4 | 128 | 0 |
| `obj[32]` | NPC / Actor | **Actor ID 64864** | `64864` | `(57, 41)` | `3x5` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[33]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(71, 84)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[34]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(61, 79)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[35]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(59, 57)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[36]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(57, 52)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[37]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(44, 41)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[38]` | Trigger / Hitbox | **Hitbox Zone (3x5)** | `0` | `(56, 34)` | `2x4` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Nanami)**: Positioned at tile `(48, 114)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Apple)**: Positioned at tile `(46, 104)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Object 102)**: Positioned at tile `(48, 61)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Object 102)**: Positioned at tile `(52, 65)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Object 64787)**: Positioned at tile `(50, 58)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Object 64788)**: Positioned at tile `(55, 55)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[06]` (Object 64789)**: Positioned at tile `(54, 62)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[07]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(64, 36)` with state parameter `12`.
- **`obj[08]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(48, 42)` with state parameter `4`.
- **`obj[09]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(64, 60)` with state parameter `4`.
- **`obj[10]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(44, 68)` with state parameter `8`.
- **`obj[11]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(56, 78)` with state parameter `6`.
- **`obj[12]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(66, 84)` with state parameter `4`.
- **`obj[13]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(68, 104)` with state parameter `6`.
- **`obj[14]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(38, 98)` with state parameter `4`.
- **`obj[15]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(48, 42)` with state parameter `5`.
- **`obj[16]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(64, 60)` with state parameter `5`.
- **`obj[17]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(44, 68)` with state parameter `9`.
- **`obj[18]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(56, 78)` with state parameter `7`.
- **`obj[19]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(66, 84)` with state parameter `5`.
- **`obj[20]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(68, 104)` with state parameter `7`.
- **`obj[21]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(38, 98)` with state parameter `5`.
- **`obj[22]` (Object 65107)**: Positioned at tile `(63, 35)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[23]` (Object 65160)**: Positioned at tile `(42, 122)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[24]` (Object 65162)**: Positioned at tile `(40, 105)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[25]` (Object 65103)**: Positioned at tile `(48, 99)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[26]` (Object 64857)**: Positioned at tile `(62, 105)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[27]` (Object 65161)**: Positioned at tile `(65, 89)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[28]` (Object 65103)**: Positioned at tile `(58, 87)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[29]` (Object 65148)**: Positioned at tile `(46, 73)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[30]` (Object 65159)**: Positioned at tile `(56, 67)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[31]` (Object 65156)**: Positioned at tile `(45, 49)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[32]` (Object 64864)**: Positioned at tile `(57, 41)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[33]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(71, 84)` to `(72, 85)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[34]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(61, 79)` to `(62, 80)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[35]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(59, 57)` to `(60, 58)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[36]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(57, 52)` to `(58, 53)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[37]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(44, 41)` to `(45, 42)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[38]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `5` tiles high from `(56, 34)` to `(58, 38)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (88 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Target Inspected is obj[30] AND Condition Check #24 AND Temp Event Flag #2 SET AND Condition Check #24 AND Temp Event Flag #2 CLEAR AND Story Flag 67 (bit 4) CLEAR | Open Dialogue Sub-Window (9); Open Dialogue Message Window |
| `ev[01]` | `1 (Action / Talk)` | Target Inspected is obj[30] AND Condition Check #24 AND Temp Event Flag #2 SET AND Condition Check #24 AND Temp Event Flag #2 CLEAR AND Story Flag 67 (bit 4) SET | Open Dialogue Sub-Window (9); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[02]` | `1 (Action / Talk)` | Target Inspected is obj[30] AND Condition Check #23 AND Temp Event Flag #2 SET AND Condition Check #23 AND Temp Event Flag #2 CLEAR | Open Dialogue Sub-Window (9); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[03]` | `1 (Action / Talk)` | Target Inspected is obj[31] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Formation Check | Open Dialogue Sub-Window (10); Open Dialogue Message Window |
| `ev[04]` | `1 (Action / Talk)` | Target Inspected is obj[31] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Member Count == 255 | Open Dialogue Sub-Window (12); Open Dialogue Message Window |
| `ev[05]` | `1 (Action / Talk)` | Target Inspected is obj[31] AND Story Flag 143 (bit 2) CLEAR | Open Dialogue Sub-Window (7); Open Dialogue Message Window |
| `ev[06]` | `1 (Action / Talk)` | Target Inspected is obj[31] AND Story Flag 143 (bit 2) SET AND Story Flag 134 (bit 1) CLEAR | Open Dialogue Sub-Window (11); Open Dialogue Message Window |
| `ev[07]` | `1 (Action / Talk)` | Target Inspected is obj[31] AND Story Flag 134 (bit 1) SET | Open Dialogue Sub-Window (13); Open Dialogue Message Window |
| `ev[08]` | `1 (Action / Talk)` | Target Inspected is obj[32] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Formation Check | Open Dialogue Sub-Window (10); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[09]` | `1 (Action / Talk)` | Target Inspected is obj[32] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Member Count == 255 | Open Dialogue Sub-Window (12); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[10]` | `1 (Action / Talk)` | Target Inspected is obj[32] AND Story Flag 143 (bit 2) CLEAR | Open Dialogue Sub-Window (7); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[11]` | `1 (Action / Talk)` | Target Inspected is obj[32] AND Story Flag 143 (bit 2) SET AND Story Flag 134 (bit 1) CLEAR | Open Dialogue Sub-Window (11); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[12]` | `1 (Action / Talk)` | Target Inspected is obj[32] AND Story Flag 134 (bit 1) SET | Open Dialogue Sub-Window (13); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[13]` | `1 (Action / Talk)` | Target Inspected is obj[33] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Formation Check | Open Dialogue Sub-Window (10); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[14]` | `1 (Action / Talk)` | Target Inspected is obj[33] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Member Count == 255 | Open Dialogue Sub-Window (12); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[15]` | `1 (Action / Talk)` | Target Inspected is obj[33] AND Story Flag 143 (bit 2) CLEAR | Open Dialogue Sub-Window (7); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[16]` | `1 (Action / Talk)` | Target Inspected is obj[33] AND Story Flag 143 (bit 2) SET AND Story Flag 134 (bit 1) CLEAR | Open Dialogue Sub-Window (11); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[17]` | `1 (Action / Talk)` | Target Inspected is obj[33] AND Story Flag 134 (bit 1) SET | Open Dialogue Sub-Window (13); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[18]` | `1 (Action / Talk)` | Target Inspected is obj[34] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Formation Check | Open Dialogue Sub-Window (10); Warp to Castle HQ (255, 254, 204) |
| `ev[19]` | `1 (Action / Talk)` | Target Inspected is obj[34] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Member Count == 255 | Open Dialogue Sub-Window (12); Warp to Castle HQ (255, 254, 204) |
| `ev[20]` | `1 (Action / Talk)` | Target Inspected is obj[34] AND Story Flag 143 (bit 2) CLEAR | Open Dialogue Sub-Window (7); Warp to Castle HQ (255, 254, 204) |
| `ev[21]` | `1 (Action / Talk)` | Target Inspected is obj[34] AND Story Flag 143 (bit 2) SET AND Story Flag 134 (bit 1) CLEAR | Open Dialogue Sub-Window (11); Warp to Castle HQ (255, 254, 204) |
| `ev[22]` | `1 (Action / Talk)` | Target Inspected is obj[34] AND Story Flag 134 (bit 1) SET | Open Dialogue Sub-Window (13); Warp to Castle HQ (255, 254, 204) |
| `ev[23]` | `1 (Action / Talk)` | Target Inspected is obj[35] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Formation Check | Open Dialogue Sub-Window (10); Exit to World Map (255, 254, 204) |
| `ev[24]` | `1 (Action / Talk)` | Target Inspected is obj[35] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Member Count == 255 | Open Dialogue Sub-Window (12); Exit to World Map (255, 254, 204) |
| `ev[25]` | `1 (Action / Talk)` | Target Inspected is obj[35] AND Story Flag 143 (bit 2) CLEAR | Open Dialogue Sub-Window (7); Exit to World Map (255, 254, 204) |
| `ev[26]` | `1 (Action / Talk)` | Target Inspected is obj[35] AND Story Flag 143 (bit 2) SET AND Story Flag 134 (bit 1) CLEAR | Open Dialogue Sub-Window (11); Exit to World Map (255, 254, 204) |
| `ev[27]` | `1 (Action / Talk)` | Target Inspected is obj[35] AND Story Flag 134 (bit 1) SET | Open Dialogue Sub-Window (13); Exit to World Map (255, 254, 204) |
| `ev[28]` | `1 (Action / Talk)` | Target Inspected is obj[36] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Formation Check | Open Dialogue Sub-Window (10); Engine Action #5 |
| `ev[29]` | `1 (Action / Talk)` | Target Inspected is obj[36] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Member Count == 255 | Open Dialogue Sub-Window (12); Engine Action #5 |
| `ev[30]` | `1 (Action / Talk)` | Target Inspected is obj[36] AND Story Flag 143 (bit 2) CLEAR | Open Dialogue Sub-Window (7); Engine Action #5 |
| `ev[31]` | `1 (Action / Talk)` | Target Inspected is obj[36] AND Story Flag 143 (bit 2) SET AND Story Flag 134 (bit 1) CLEAR | Open Dialogue Sub-Window (11); Engine Action #5 |
| `ev[32]` | `1 (Action / Talk)` | Target Inspected is obj[36] AND Story Flag 134 (bit 1) SET | Open Dialogue Sub-Window (13); Engine Action #5 |
| `ev[33]` | `1 (Action / Talk)` | Target Inspected is obj[37] AND Condition Check #23 AND Temp Event Flag #2 SET AND Condition Check #23 AND Temp Event Flag #2 CLEAR AND Condition Check #24 AND Condition Check #102 AND Player Y within Range [255..254] | Open Dialogue Sub-Window (10); Engine Action #6 |
| `ev[34]` | `1 (Action / Talk)` | Target Inspected is obj[37] AND Condition Check #24 AND Temp Event Flag #2 SET AND Condition Check #24 AND Temp Event Flag #2 CLEAR | Open Dialogue Sub-Window (7); Engine Action #6 |
| `ev[35]` | `1 (Action / Talk)` | Target Inspected is obj[37] AND Condition Check #23 AND Condition Check #102 AND Player Y within Range [255..254] | Open Dialogue Sub-Window (11); Engine Action #6 |
| `ev[36]` | `1 (Action / Talk)` | Target Inspected is obj[38] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Formation Check | Open Dialogue Sub-Window (10); Pan Camera (255, 254, 204) |
| `ev[37]` | `1 (Action / Talk)` | Target Inspected is obj[38] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Member Count == 255 | Open Dialogue Sub-Window (12); Pan Camera (255, 254, 204) |
| `ev[38]` | `1 (Action / Talk)` | Target Inspected is obj[38] AND Story Flag 143 (bit 2) CLEAR | Open Dialogue Sub-Window (7); Pan Camera (255, 254, 204) |
| `ev[39]` | `1 (Action / Talk)` | Target Inspected is obj[38] AND Story Flag 143 (bit 2) SET AND Story Flag 134 (bit 1) CLEAR | Open Dialogue Sub-Window (11); Pan Camera (255, 254, 204) |
| `ev[40]` | `1 (Action / Talk)` | Target Inspected is obj[38] AND Story Flag 134 (bit 1) SET | Open Dialogue Sub-Window (13); Pan Camera (255, 254, 204) |
| `ev[41]` | `1 (Action / Talk)` | Target Inspected is obj[39] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Formation Check | Open Dialogue Sub-Window (10); Reset Camera Tracking (255) |
| `ev[42]` | `1 (Action / Talk)` | Target Inspected is obj[39] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Member Count == 255 | Open Dialogue Sub-Window (12); Reset Camera Tracking (255) |
| `ev[43]` | `1 (Action / Talk)` | Target Inspected is obj[39] AND Story Flag 143 (bit 2) CLEAR | Open Dialogue Sub-Window (7); Reset Camera Tracking (255) |
| `ev[44]` | `1 (Action / Talk)` | Target Inspected is obj[39] AND Story Flag 143 (bit 2) SET AND Story Flag 134 (bit 1) CLEAR | Open Dialogue Sub-Window (11); Reset Camera Tracking (255) |
| `ev[45]` | `1 (Action / Talk)` | Target Inspected is obj[39] AND Story Flag 134 (bit 1) SET | Open Dialogue Sub-Window (13); Reset Camera Tracking (255) |
| `ev[46]` | `1 (Action / Talk)` | Target Inspected is obj[40] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Formation Check | Open Dialogue Sub-Window (10); Engine Action #9 |
| `ev[47]` | `1 (Action / Talk)` | Target Inspected is obj[40] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Member Count == 255 | Open Dialogue Sub-Window (12); Engine Action #9 |
| `ev[48]` | `1 (Action / Talk)` | Target Inspected is obj[40] AND Story Flag 143 (bit 2) CLEAR | Open Dialogue Sub-Window (7); Engine Action #9 |
| `ev[49]` | `1 (Action / Talk)` | Target Inspected is obj[40] AND Story Flag 143 (bit 2) SET AND Story Flag 134 (bit 1) CLEAR | Open Dialogue Sub-Window (11); Engine Action #9 |
| `ev[50]` | `1 (Action / Talk)` | Target Inspected is obj[40] AND Story Flag 134 (bit 1) SET | Open Dialogue Sub-Window (13); Engine Action #9 |
| `ev[51]` | `1 (Action / Talk)` | Target Inspected is obj[41] | Open Dialogue Sub-Window (8); Open Dialogue Message Window |
| `ev[52]` | `1 (Action / Talk)` | Target Inspected is obj[42] | Open Dialogue Sub-Window (8); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[53]` | `1 (Action / Talk)` | Target Inspected is obj[43] | Open Dialogue Sub-Window (8); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[54]` | `1 (Action / Talk)` | Target Inspected is obj[44] | Open Dialogue Sub-Window (8); Warp to Castle HQ (255, 254, 204) |
| `ev[55]` | `1 (Action / Talk)` | Target Inspected is obj[45] AND Story Flag 50 (bit 4) CLEAR | Open Dialogue Sub-Window (8); Exit to World Map (101, 4, 7); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (3); Exit to World Map (0, 103, 32); Open Dialogue Message Window; Award Potch Loot (+514 Potch); Warp to Castle HQ (255, 2, 9); Walk obj[4] to (255,254); Warp to Castle HQ (255, 254, 255) |
| `ev[56]` | `1 (Action / Talk)` | Target Inspected is obj[45] AND Story Flag 50 (bit 4) SET | Open Dialogue Sub-Window (8); Clear Dialogue Sub-Window |
| `ev[57]` | `1 (Action / Talk)` | Target Inspected is obj[46] | Open Dialogue Sub-Window (8); Engine Action #5 |
| `ev[58]` | `128 (Loop)` | Inventory Holds Item #1 [Medicine] | Warp Room -> Submap 2 at (13,28); Toggle Random Encounters (1); Launch Tactical War Battle (2) |
| `ev[59]` | `128 (Loop)` | Player within Box [39..49, 11..112] | Engine Action #110; Warp Room -> Submap 2 at (12,7) |
| `ev[60]` | `128 (Loop)` | Player within Box [62..73, 13..22] | Warp Room -> Submap 1 at (7,9) |
| `ev[61]` | `1 (Action / Talk)` | Player within Box [35..51, 11..129] AND Story Flag 0 (mask 255) SET | Make obj[100] Hidden (disp = 0); Warp Room -> Submap 100 at (1,2) facing 47; Jump to Bytecode Offset (9, 8); Warp Map Transition (0, 0, 173, 147, 255) |
| `ev[62]` | `1 (Action / Talk)` | Player within Box [49..51, 2..42] AND Condition Check #43 AND Story Flag 1 (mask 255) SET | Make obj[1] Hidden (disp = 0); Dismiss Dialogue Portrait; Open Dialogue Message Window; Open Dialogue Sub-Window (100); Warp Room -> Submap 100 at (1,2) facing 47; Jump to Bytecode Offset (0, 185); Set Combat Battle BGM (15); Display Dialogue Box [Bank: 1, MsgID: 130]; Engine Action #208 |
| `ev[63]` | `1 (Action / Talk)` | Player within Box [67..68, 2..102] AND Condition Check #103 | Make obj[1] Hidden (disp = 0); Execute Choice Result (0); Display Chapter Text (100); Warp Room -> Submap 100 at (1,2) facing 47; Jump to Bytecode Offset (0, 185); Set Combat Battle BGM (15); Display Dialogue Box [Bank: 2, MsgID: 38]; Engine Action #145 |
| `ev[64]` | `1 (Action / Talk)` | Player within Box [55..59, 2..76] AND Condition Check #78 | Make obj[1] Hidden (disp = 0); Display Choice Selection (0, 26); Mark NPC Talk Interaction Complete (Flag #1); Warp Room -> Submap 1 at (2,47) facing 101; Open Dialogue Message Window; Engine Action #185; Set Combat Battle BGM (15); Display Dialogue Box [Bank: 3, MsgID: 104]; Engine Action #145 |
| `ev[65]` | `1 (Action / Talk)` | Player within Box [43..47, 2..64] AND Condition Check #68 | Make obj[1] Hidden (disp = 0); Display Speaker Name Box (0); Clear Dialogue Sub-Window; Mark NPC Talk Interaction Complete (Flag #1); Warp Room -> Submap 1 at (2,47) facing 101; Open Dialogue Message Window; Engine Action #185; Set Combat Battle BGM (15); Display Dialogue Box [Bank: 4, MsgID: 58]; Engine Action #200 |
| `ev[66]` | `1 (Action / Talk)` | Player within Box [66..69, 2..84] AND Condition Check #85 AND Story Flag 1 (mask 255) SET | Make obj[1] Hidden (disp = 0); Branch on Choice (0, 27); Mark NPC Talk Interaction Complete (Flag #1); Warp Room -> Submap 1 at (2,47) facing 101; Open Dialogue Message Window; Engine Action #185; Set Combat Battle BGM (15); Display Dialogue Box [Bank: 5, MsgID: 48]; Engine Action #94 |
| `ev[67]` | `1 (Action / Talk)` | Player within Box [39..41, 2..97] AND Condition Check #99 AND Story Flag 1 (mask 255) SET | Make obj[1] Hidden (disp = 0); Set Story Flag (0, 29); Mark NPC Talk Interaction Complete (Flag #1); Warp Room -> Submap 1 at (2,47) facing 101; Open Dialogue Message Window; Engine Action #185; Set Combat Battle BGM (15); Display Dialogue Box [Bank: 6, MsgID: 118]; Load Sound Bank into Memory (255, 254) |
| `ev[68]` | `1 (Action / Talk)` | Player within Box [65..67, 2..60] AND Condition Check #61 AND Story Flag 1 (mask 255) SET | Make obj[1] Hidden (disp = 0); Change Portrait Expression (0); Close Dialogue Sub-Window (100); Warp Room -> Submap 100 at (1,2) facing 47; Jump to Bytecode Offset (0, 185); Set Combat Battle BGM (15); Display Dialogue Box [Bank: 7, MsgID: 210]; Clear Story Milestone Flag 255 (mask 254) |
| `ev[69]` | `1 (Action / Talk)` | Player within Box [63..73, 2..5] AND Inventory Holds Item #9 [Kindness Drops] AND Player X within Range [255..254] | Make obj[100] Hidden (disp = 0); Warp Room -> Submap 100 at (1,2) facing 47; Jump to Bytecode Offset (9, 8); Warp Map Transition (2, 0, 31, 58, 255) |
| `ev[70]` | `2 (Map Init)` | Story Flag 67 (bit 4) CLEAR | Open Dialogue Message Window; Show Dialogue Portrait (255, 254, 204) |
| `ev[71]` | `2 (Map Init)` | Story Flag 66 (bit 1) SET AND Story Flag 66 (bit 2) CLEAR AND Story Flag 151 (bit 64) CLEAR AND Player within Box [44..44, 2..128] AND Condition Check #128 | Make obj[99] Hidden (disp = 0); Warp Room -> Submap 0 at (8,0) facing 9; Warp Room -> Submap 1 at (32,1) facing 33; Teleport obj[255] to (254,204) |
| `ev[72]` | `2 (Map Init)` | Story Flag 66 (bit 2) SET AND Story Flag 66 (bit 4) CLEAR AND Player X in Range [59..255] | Make obj[99] Hidden (disp = 0); Warp Room -> Submap 0 at (8,0) facing 9; Warp Town -> Area 9 Map 50 Submap 46 at (2,8); Engine Action #52; Turn obj[47] facing 255 |
| `ev[73]` | `2 (Map Init)` | Story Flag 66 (bit 16) SET AND Story Flag 67 (bit 32) CLEAR AND Star of Destiny #0 Recruited AND Temp Event Flag #255 SET | Make obj[2] Hidden (disp = 0); Reset Camera Tracking (44); Engine Action #44; Open Dialogue Message Window; Reset Camera Tracking (3); Reset Camera Tracking (0); Teleport obj[255] to (254,204) |
| `ev[74]` | `2 (Map Init)` | Story Flag 68 (bit 128) CLEAR AND Story Flag 186 (bit 4) SET AND Story Flag 151 (bit 64) CLEAR AND Condition Check #24 AND Condition Check #102 AND Player Y within Range [23..8] AND Player Y within Range [23..7] AND Player Y within Range [255..254] | Open Dialogue Message Window; Screen Fade Transition (255, 254, 204) |
| `ev[75]` | `2 (Map Init)` | Story Flag 68 (bit 128) SET AND Story Flag 186 (bit 4) SET AND Story Flag 151 (bit 64) CLEAR AND Story Flag 70 (bit 1) CLEAR AND Condition Check #24 AND Condition Check #102 AND Player Y within Range [23..8] AND Player Y within Range [23..7] AND Player Y within Range [255..254] | Make obj[3] Hidden (disp = 0); Close Dialogue Window; Warp to Castle HQ (0, 11, 3); Open Dialogue Message Window; Warp Town -> Area 0 Map 12 Submap 0 at (13,0); Animate Door Open; Teleport obj[255] to (254,204) |
| `ev[76]` | `2 (Map Init)` | Story Flag 70 (bit 1) SET AND Condition Check #24 AND Condition Check #102 AND Player Y within Range [23..8] AND Player Y within Range [23..7] AND Player Y within Range [255..254] | Make obj[0] Hidden (disp = 0); Close Dialogue Window; Open Dialogue Message Window; Display Dialogue Box [Bank: 0, MsgID: 13]; Open Dialogue Message Window; Animate Door Open; Teleport obj[255] to (254,204) |
| `ev[77]` | `1 (Action / Talk)` | Condition Check #29 AND Player X within Range [1..255] | Recruit Character into Active Party (49 [Abizboah], 2); Display Chapter Text (1); Screen Fade Transition (4, 73, 30); Warp to Castle HQ (9, 3, 73); Screen Fade Transition (3, 9, 0); Engine Action #5; Reset Camera Tracking (4); Warp to Castle HQ (1, 8, 30); Walk obj[84] to (7,30); Dismiss Character to Castle Base (8 [Tengaar]); Dismiss Emotion Bubble (24); Engine Action #9; Open Dialogue Message Window; Open Dialogue Message Window; Set Combat Battle BGM (30); Close Dialogue Sub-Window (8); Open Dialogue Message Window; Warp Room -> Submap 20 at (77,9) facing 6; Warp Room -> Submap 24 at (9,0) facing Up (North); Set Combat Battle BGM (20); Award Potch Currency (8,7); Warp Room -> Submap 73 at (40,24) facing 8; Open Dialogue Message Window; Warp to Castle HQ (73, 20, 24); Engine Action #9; Open Dialogue Message Window; Exit to World Map (73, 30, 5); Engine Action #9; Exit to World Map (5, 3, 15); Warp Room -> Submap 30 at (2,9) facing 50; Make obj[3] Hidden (disp = 0); Engine Action #9; Warp Room -> Submap 8 at (0,5) facing 49; Warp Town -> Area 5 Map 8 Submap 4 at (4,1); Warp to Castle HQ (3, 12, 1); Screen Fade Transition (30, 2, 8); Engine Action #52; Turn obj[3] facing 8; Warp Room -> Submap 254 at (29,4) facing 255; Walk obj[9] to (66,2); Mark NPC Talk Interaction Complete (Flag #1); Warp Room -> Submap 1 at (2,29) facing 4; Engine Action #58 |
| `ev[78]` | `1 (Action / Talk)` | Condition Check #29 AND Player within Box [2..2, 57..59] | Display Chapter Text (1); Display Dialogue Box [Bank: 4, MsgID: 73]; Dismiss Emotion Bubble (24); Engine Action #9; Open Dialogue Message Window; Engine Action #6; Set Combat Battle BGM (20); Award Potch Currency (8,7); Warp Town -> Area 30 Map 73 Submap 40 at (24,8); Open Dialogue Message Window; Pan Camera (3, 9, 0); Close Dialogue Sub-Window (9); Open Dialogue Message Window; Reset Camera Tracking (46); Warp Room -> Submap 0 at (23,47) facing 101; Open Dialogue Message Window; Engine Action #185; Set Entity Movement Speed (2, 5); Engine Action #9; Exit to World Map (4, 1, 3); Dismiss Emotion Bubble (94); Warp Room -> Submap 9 at (30,255) facing 254; Engine Action #5; Reset Camera Tracking (4); Exit to World Map (2, 2, 1); Pan Camera (30, 94, 1); Warp Room -> Submap 30 at (1,8) facing 255; Walk obj[73] to (45,46); Open Dialogue Message Window; Dismiss Dialogue Portrait; Warp Room -> Submap 47 at (101,0) facing 185; Display Emotion Bubble (4, 9); Engine Action #66; Exit to World Map (100, 1, 1); Mark NPC Talk Interaction Complete (Flag #1); Warp Town -> Area 58 Map 255 Submap 254 at (255,254) |
| `ev[79]` | `1 (Action / Talk)` | Story Flag 67 (bit 4) SET AND Story Flag 67 (bit 8) CLEAR AND Player within Box [63..73, 2..12] AND Party Holds At Least 1,600 Potch AND Player X within Range [7..255] | Recruit Character into Active Party (33 [Camus], 1); Pan Camera (43, 1, 4); Engine Action #52; Warp Room -> Submap 0 at (1,4) facing 8; Warp to Castle HQ (1, 0, 24); Warp Room -> Submap 78 at (73,20) facing 48; Warp Room -> Submap 3 at (0,0) facing South (Down); Reset Camera Tracking (1); Warp Room -> Submap 67 at (8,58) facing 255 |
| `ev[80]` | `1 (Action / Talk)` | Story Flag 66 (bit 16) SET AND Story Flag 66 (bit 64) CLEAR AND Star of Destiny #0 Recruited AND Temp Event Flag #5 SET AND Temp Event Flag #255 CLEAR | Recruit Character into Active Party (24 [Milie], 8); Open Dialogue Message Window; Set Entity Movement Speed (73, 20); Set Combat Battle BGM (20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 0 Map 50 Submap 0 at (51,73); Branch on Choice (41, 2); Animate Door Open; Show Dialogue Portrait (255, 14, 36); Warp Room -> Submap 8 at (0,52) facing 73; Branch on Choice (54, 1); Warp Town -> Area 112 Map 4 Submap 1 at (1,7); Warp Room -> Submap 2 at (0,48) facing 8; Open Dialogue Message Window; Warp to Castle HQ (0, 0, 0); Reset Camera Tracking (1); Reset Camera Tracking (58); Show Dialogue Portrait (24, 8, 0); Engine Action #53; Set Combat Battle BGM (20); Engine Action #58 |
| `ev[81]` | `1 (Action / Talk)` | Story Flag 66 (bit 64) SET AND Story Flag 67 (bit 1) CLEAR AND Star of Destiny #0 Recruited AND Temp Event Flag #5 SET AND Temp Event Flag #255 CLEAR | Recruit Character into Active Party (24 [Milie], 8); Warp Room -> Submap 73 at (20,73) facing 20; Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 0 Map 50 Submap 0 at (51,73); Branch on Choice (41, 2); Animate Door Open; Show Dialogue Portrait (255, 14, 36); Warp Room -> Submap 8 at (0,52) facing 73; Branch on Choice (54, 1); Warp Town -> Area 112 Map 4 Submap 1 at (1,7); Warp Room -> Submap 2 at (0,48) facing 8; Open Dialogue Message Window; Warp to Castle HQ (0, 0, 0); Reset Camera Tracking (1); Reset Camera Tracking (58); Show Dialogue Portrait (24, 8, 0); Engine Action #53; Set Combat Battle BGM (20); Engine Action #58 |
| `ev[82]` | `1 (Action / Talk)` | Story Flag 67 (bit 1) SET AND Story Flag 67 (bit 4) CLEAR AND Star of Destiny #0 Recruited AND Temp Event Flag #5 SET AND Temp Event Flag #255 CLEAR | Recruit Character into Active Party (24 [Milie], 8); Warp Room -> Submap 73 at (20,73) facing 20; Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 0 Map 50 Submap 0 at (51,73); Branch on Choice (41, 2); Animate Door Open; Show Dialogue Portrait (255, 14, 36); Warp Room -> Submap 8 at (0,52) facing 73; Branch on Choice (54, 1); Warp Town -> Area 112 Map 4 Submap 1 at (1,7); Warp Room -> Submap 2 at (0,48) facing 8; Open Dialogue Message Window; Warp to Castle HQ (0, 0, 0); Reset Camera Tracking (1); Reset Camera Tracking (58); Show Dialogue Portrait (24, 8, 0); Engine Action #53; Set Combat Battle BGM (20); Engine Action #58 |
| `ev[83]` | `1 (Action / Talk)` | Story Flag 67 (bit 4) SET AND Story Flag 67 (bit 32) CLEAR AND Star of Destiny #0 Recruited AND Temp Event Flag #5 SET AND Temp Event Flag #255 CLEAR | Recruit Character into Active Party (24 [Milie], 8); Warp Room -> Submap 73 at (20,73) facing 20; Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 0 Map 50 Submap 0 at (51,73); Branch on Choice (41, 2); Animate Door Open; Show Dialogue Portrait (255, 14, 36); Warp Room -> Submap 8 at (0,52) facing 73; Branch on Choice (54, 1); Warp Town -> Area 112 Map 4 Submap 1 at (1,7); Warp Room -> Submap 2 at (0,48) facing 8; Open Dialogue Message Window; Warp to Castle HQ (0, 0, 0); Reset Camera Tracking (1); Reset Camera Tracking (58); Show Dialogue Portrait (24, 8, 0); Engine Action #53; Set Combat Battle BGM (20); Engine Action #58 |
| `ev[84]` | `1 (Action / Talk)` | Target Inspected is obj[10] AND Condition Check #33 AND Player Y within Range [1..24] AND Condition Check #102 AND Player Y within Range [255..254] | Dismiss Character to Castle Base (102 [Yuzu]); Dismiss Emotion Bubble (23); Engine Action #5; Set Story Flag (255, 254) |
| `ev[85]` | `1 (Action / Talk)` | Target Inspected is obj[10] AND Story Flag 70 (bit 1) CLEAR AND Condition Check #33 AND Player within Box [2..24, 102..2] | Dismiss Character to Castle Base (102 [Yuzu]); Dismiss Emotion Bubble (23); Engine Action #5; Open Dialogue Sub-Window (73); Branch on Choice (40, 0); Open Dialogue Message Window; Warp Town -> Area 5 Map 24 Submap 5 at (25,73); Branch on Choice (41, 2); Dismiss Dialogue Portrait; Change Portrait Expression (255); Dismiss Dialogue Portrait; Close Dialogue Sub-Window (10); Engine Action #5; Fade Out to Black (73); Branch on Choice (40, 0); Open Dialogue Message Window; Warp Town -> Area 5 Map 28 Submap 5 at (29,73); Branch on Choice (41, 2); Display Speaker Name Box (19); Display Speaker Name Box (24); Screen Fade Transition (5, 31, 73); Branch on Choice (9, 68); Dismiss Dialogue Portrait; Jump to Bytecode Offset (9, 8); Place Scenery Structure (5); Pan Camera (9, 6, 64); Engine Action #90; Engine Action #58; Display Choice Selection (24, 10); Engine Action #5; Dismiss Emotion Bubble (73); Branch on Choice (58, 255); Change Portrait Expression (24); Screen Fade Transition (5, 26, 73); Branch on Choice (58, 255) |
| `ev[86]` | `1 (Action / Talk)` | Target Inspected is obj[11] AND Story Flag 70 (bit 1) SET AND Condition Check #24 AND Condition Check #102 AND Player Y within Range [255..254] | Open Dialogue Sub-Window (5); Make obj[73] Hidden (disp = 0); Branch on Choice (73, 20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 5 Map 41 Submap 5 at (42,73); Branch on Choice (41, 2); Display Dialogue Box [Bank: 13, MsgID: 255] |
| `ev[87]` | `1 (Action / Talk)` | Story Flag 68 (bit 128) SET AND Story Flag 70 (bit 1) CLEAR AND Condition Check #24 AND Condition Check #102 AND Player Y within Range [255..254] | Recruit Character into Active Party (24 [Milie], 11); Engine Action #5; Open Save Crystal Menu (MSaveInit); Set Combat Battle BGM (120); Close Dialogue Sub-Window (11); Engine Action #5; Engine Action #39; Set Combat Battle BGM (150); Close Dialogue Sub-Window (11); Engine Action #5; Engine Action #40; Set Combat Battle BGM (20); Set Combat Battle BGM (20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 5 Map 41 Submap 5 at (42,73); Branch on Choice (41, 2); Display Dialogue Box [Bank: 13, MsgID: 255]; Display Dialogue Box [Bank: 72, MsgID: 1]; Close Dialogue Window; Warp Town -> Area 24 Map 11 Submap 5 at (43,72); Open Dialogue Message Window; Close Dialogue Window; Dismiss Character to Castle Base (102 [Yuzu]); Warp Room -> Submap 131 at (31,16); Engine Action #131; Warp Map Transition (4, 30, 2, 0, 73); Branch on Choice (5, 0); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 101, 4); Engine Action #6; Engine Action #5; Open Dialogue Message Window; Warp Town -> Area 0 Map 5 Submap 3 at (1,0); Engine Action #5; Warp to Castle HQ (3, 0, 5); Warp to Castle HQ (0, 0, 5); Warp to Castle HQ (30, 89, 0); Warp Town -> Area 8 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Engine Action #89; Open Dialogue Message Window; Warp Town -> Area 9 Map 5 Submap 0 at (6,2); Dismiss Emotion Bubble (89); Open Dialogue Message Window; Warp Town -> Area 10 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Dismiss Emotion Bubble (1); Warp Room -> Submap 5 at (0,0) facing South (Down); Engine Action #5; Show Dialogue Portrait (2, 0, 30); Set Combat Battle BGM (60); Close Dialogue Sub-Window (11); Engine Action #5; Engine Action #44; Set Combat Battle BGM (20); Make obj[43] Hidden (disp = 0); Display Dialogue Box [Bank: 4, MsgID: 43]; Place Scenery Structure (4); Open Shop Menu #4 (Type: 14); Teleport obj[49] to (4,55); Close Dialogue Window; Engine Action #52; Remove Item from Inventory (8, 1); Close Dialogue Window; Set Render Priority (pri) (12, 50); Dismiss Character to Castle Base (8 [Tengaar]); Warp Room -> Submap 255 at (254,55) facing 13; Engine Action #52; Dismiss Character to Castle Base (8 [Tengaar]); Warp Room -> Submap 255 at (254,55) facing 14; Engine Action #54; Dismiss Character to Castle Base (8 [Tengaar]); Warp Room -> Submap 255 at (254,50) facing 9; Recruit Riou (Hero) into Battle Slot 58; Place Scenery Structure (24); Close Dialogue Window; Engine Action #5; Make obj[9] Visible (disp = 1); Recruit Riou (Hero) into Battle Slot 58 |

---

### Submap Layer `vh03_01` (Index 1)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `11` Objects | **Script Count (`evkaz`)**: `54` Scripts

#### Complete Physical Entity Inventory (11 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Nanami** | `7` | `(133, 203)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Apple** | `8` | `(129, 203)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Actor ID 65149** | `65149` | `(131, 200)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[03]` | NPC / Actor | **Actor ID 65107** | `65107` | `(135, 194)` | `3x5` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[04]` | NPC / Actor | **Actor ID 65148** | `65148` | `(143, 194)` | `0x0` | Up (North) | Visible (1) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[05]` | NPC / Actor | **Actor ID 65162** | `65162` | `(121, 189)` | `3x5` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[06]` | NPC / Actor | **Actor ID 65157** | `65157` | `(124, 192)` | `3x5` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[07]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(140, 189)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(109, 185)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Trigger / Hitbox | **Hitbox Zone (6x2)** | `0` | `(99, 199)` | `5x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(105, 199)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Nanami)**: Positioned at tile `(133, 203)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Apple)**: Positioned at tile `(129, 203)`, facing West (Left). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Object 65149)**: Positioned at tile `(131, 200)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Object 65107)**: Positioned at tile `(135, 194)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Object 65148)**: Positioned at tile `(143, 194)`, facing Up (North). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Object 65162)**: Positioned at tile `(121, 189)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[06]` (Object 65157)**: Positioned at tile `(124, 192)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[07]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(140, 189)` to `(141, 190)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[08]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(109, 185)` to `(112, 186)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[09]` (Hitbox Zone)**: Bounding trigger area covering `6` tiles wide by `2` tiles high from `(99, 199)` to `(104, 200)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[10]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(105, 199)` to `(108, 200)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (54 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Target Inspected is obj[11] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Formation Check | Open Dialogue Sub-Window (10); Screen Fade Transition (255, 254, 204) |
| `ev[01]` | `1 (Action / Talk)` | Target Inspected is obj[11] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Member Count == 255 | Open Dialogue Sub-Window (12); Screen Fade Transition (255, 254, 204) |
| `ev[02]` | `1 (Action / Talk)` | Target Inspected is obj[11] AND Story Flag 143 (bit 2) CLEAR | Open Dialogue Sub-Window (7); Screen Fade Transition (255, 254, 204) |
| `ev[03]` | `1 (Action / Talk)` | Target Inspected is obj[11] AND Story Flag 143 (bit 2) SET AND Story Flag 134 (bit 1) CLEAR | Open Dialogue Sub-Window (11); Screen Fade Transition (255, 254, 204) |
| `ev[04]` | `1 (Action / Talk)` | Target Inspected is obj[11] AND Story Flag 134 (bit 1) SET | Open Dialogue Sub-Window (13); Screen Fade Transition (255, 254, 204) |
| `ev[05]` | `1 (Action / Talk)` | Target Inspected is obj[12] AND Story Flag 50 (bit 8) CLEAR | Open Dialogue Sub-Window (7); Close Dialogue Window; Jump to Bytecode Offset (4, 7); Jump to Bytecode Offset (4, 7); Dismiss Emotion Bubble (3); Exit to World Map (0, 55, 80); Open Dialogue Message Window; Award Potch Loot (+514 Potch); Warp to Castle HQ (255, 2, 9); Walk obj[8] to (255,254); Warp to Castle HQ (255, 254, 255) |
| `ev[06]` | `1 (Action / Talk)` | Target Inspected is obj[12] AND Story Flag 50 (bit 8) SET | Open Dialogue Sub-Window (7); Open Save Crystal Menu (MSaveInit) |
| `ev[07]` | `1 (Action / Talk)` | Target Inspected is obj[13] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Formation Check | Open Dialogue Sub-Window (10); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[08]` | `1 (Action / Talk)` | Target Inspected is obj[13] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Member Count == 255 | Open Dialogue Sub-Window (12); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[09]` | `1 (Action / Talk)` | Target Inspected is obj[13] AND Story Flag 143 (bit 2) CLEAR | Open Dialogue Sub-Window (7); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[10]` | `1 (Action / Talk)` | Target Inspected is obj[13] AND Story Flag 143 (bit 2) SET AND Story Flag 134 (bit 1) CLEAR | Open Dialogue Sub-Window (11); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[11]` | `1 (Action / Talk)` | Target Inspected is obj[13] AND Story Flag 134 (bit 1) SET | Open Dialogue Sub-Window (13); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[12]` | `1 (Action / Talk)` | Target Inspected is obj[14] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Formation Check | Open Dialogue Sub-Window (10); Place Scenery Structure (255) |
| `ev[13]` | `1 (Action / Talk)` | Target Inspected is obj[14] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Member Count == 255 | Open Dialogue Sub-Window (12); Place Scenery Structure (255) |
| `ev[14]` | `1 (Action / Talk)` | Target Inspected is obj[14] AND Story Flag 143 (bit 2) CLEAR | Open Dialogue Sub-Window (7); Place Scenery Structure (255) |
| `ev[15]` | `1 (Action / Talk)` | Target Inspected is obj[14] AND Story Flag 143 (bit 2) SET AND Story Flag 134 (bit 1) CLEAR | Open Dialogue Sub-Window (11); Place Scenery Structure (255) |
| `ev[16]` | `1 (Action / Talk)` | Target Inspected is obj[14] AND Story Flag 134 (bit 1) SET | Open Dialogue Sub-Window (13); Place Scenery Structure (255) |
| `ev[17]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Open Dialogue Sub-Window (8); Engine Action #6 |
| `ev[18]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Open Dialogue Sub-Window (8); Reset Camera Tracking (255) |
| `ev[19]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Open Dialogue Sub-Window (8); Engine Action #9 |
| `ev[20]` | `128 (Loop)` | Inventory Holds Item #4 [Throat Drops] | Warp Room -> Submap 2 at (13,28); Toggle Random Encounters (4); Launch Tactical War Battle (8) |
| `ev[21]` | `1 (Action / Talk)` | Player within Box [128..132, 2..211] AND Condition Check #213 AND Story Flag 0 (mask 29) SET AND Always Passes (Unconditional) AND Story Flag 255 (bit 254) CLEAR | Engine Action #102; Open Dialogue Message Window; Jump to Bytecode Offset (7, 4); Jump to Bytecode Offset (1, 0); Mark NPC Talk Interaction Complete (Flag #0); Exit to World Map (12, 0, 50); Engine Action #44 |
| `ev[22]` | `1 (Action / Talk)` | Player within Box [128..132, 2..211] AND Condition Check #213 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 50]; Engine Action #44 |
| `ev[23]` | `2 (Map Init)` | Story Flag 66 (bit 8) SET AND Story Flag 66 (bit 16) CLEAR AND Player within Box [131..131, 2..190] AND Condition Check #190 AND Condition Check #29 AND Always Passes (Unconditional) AND Story Flag 255 (bit 254) CLEAR | Make obj[101] Hidden (disp = 0); Pan Camera (0, 101, 2); Exit to World Map (47, 255, 254) |
| `ev[24]` | `2 (Map Init)` | Story Flag 66 (bit 4) SET AND Story Flag 66 (bit 8) CLEAR | Make obj[0] Hidden (disp = 0); Reset Camera Tracking (0); Engine Action #9; Open Dialogue Message Window; Screen Fade Transition (47, 255, 254) |
| `ev[25]` | `2 (Map Init)` | Story Flag 66 (bit 8) SET AND Story Flag 66 (bit 16) CLEAR | Make obj[2] Hidden (disp = 0); Reset Camera Tracking (103); Engine Action #188; Open Dialogue Message Window; Reset Camera Tracking (3); Reset Camera Tracking (3); Warp Town -> Area 9 Map 106 Submap 188 at (0,9); Warp to Castle HQ (9, 3, 2); Screen Fade Transition (110, 192, 0); Screen Fade Transition (3, 10, 2); Warp Room -> Submap 1 at (12,1) facing 13; Warp Room -> Submap 47 at (255,254) facing 204 |
| `ev[26]` | `2 (Map Init)` | Story Flag 66 (bit 16) SET AND Story Flag 66 (bit 32) CLEAR | Make obj[2] Hidden (disp = 0); Engine Action #9; Set Character Quest Milestone (188, 0); Engine Action #9; Warp to Castle HQ (9, 3, 2); Screen Fade Transition (110, 192, 0); Screen Fade Transition (3, 10, 2); Teleport obj[255] to (254,204) |
| `ev[27]` | `2 (Map Init)` | Story Flag 66 (bit 32) SET AND Story Flag 66 (bit 64) CLEAR | Make obj[2] Hidden (disp = 0); Engine Action #9; Set Character Quest Milestone (188, 0); Engine Action #9; Warp to Castle HQ (9, 3, 2); Screen Fade Transition (109, 188, 0); Screen Fade Transition (3, 10, 2); Teleport obj[255] to (254,204) |
| `ev[28]` | `2 (Map Init)` | Story Flag 66 (bit 64) SET AND Story Flag 66 (bit 128) CLEAR | Make obj[2] Hidden (disp = 0); Engine Action #9; Set Character Quest Milestone (188, 0); Engine Action #9; Warp to Castle HQ (9, 3, 2); Screen Fade Transition (109, 187, 0); Screen Fade Transition (3, 10, 2); Teleport obj[255] to (254,204) |
| `ev[29]` | `2 (Map Init)` | Story Flag 66 (bit 128) SET AND Story Flag 67 (bit 1) CLEAR | Make obj[2] Hidden (disp = 0); Engine Action #9; Engine Action #131; Engine Action #190; Open Dialogue Message Window; Engine Action #9; Warp to Castle HQ (9, 0, 2); Screen Fade Transition (135, 198, 3); Screen Fade Transition (1, 0, 10); Warp Room -> Submap 47 at (255,254) facing 204 |
| `ev[30]` | `2 (Map Init)` | Story Flag 67 (bit 1) SET AND Story Flag 67 (bit 2) CLEAR | Make obj[2] Hidden (disp = 0); Engine Action #9; Set Character Quest Milestone (188, 0); Engine Action #9; Warp to Castle HQ (9, 3, 2); Screen Fade Transition (109, 187, 0); Screen Fade Transition (3, 10, 2); Teleport obj[255] to (254,204) |
| `ev[31]` | `2 (Map Init)` | Story Flag 67 (bit 2) SET AND Story Flag 67 (bit 4) CLEAR | Make obj[2] Hidden (disp = 0); Screen Fade Transition (131, 199, 0); Screen Fade Transition (3, 10, 0); Teleport obj[255] to (254,204) |
| `ev[32]` | `2 (Map Init)` | Story Flag 67 (bit 4) SET AND Story Flag 67 (bit 16) CLEAR | Make obj[2] Hidden (disp = 0); Screen Fade Transition (131, 199, 0); Screen Fade Transition (3, 10, 0); Teleport obj[255] to (254,204) |
| `ev[33]` | `2 (Map Init)` | Story Flag 67 (bit 16) SET AND Story Flag 67 (bit 32) CLEAR | Make obj[63] Hidden (disp = 0); Warp Room -> Submap 2 at (1,107) facing 202; Open Dialogue Message Window; Warp Room -> Submap 1 at (0,2) facing 9; Engine Action #110; Engine Action #202; Open Dialogue Message Window; Engine Action #9; Warp to Castle HQ (9, 0, 2); Screen Fade Transition (108, 208, 0); Screen Fade Transition (3, 10, 1); Warp to Castle HQ (0, 3, 47) |
| `ev[34]` | `2 (Map Init)` | Story Flag 66 (bit 16) SET AND Story Flag 67 (bit 16) CLEAR AND Condition Check #24 AND Temp Event Flag #2 SET AND Condition Check #24 AND Temp Event Flag #2 CLEAR AND Star of Destiny #0 Recruited AND Temp Event Flag #255 SET | Make obj[2] Hidden (disp = 0); Engine Action #9; Set Character Quest Milestone (188, 0); Engine Action #9; Warp to Castle HQ (9, 3, 2); Screen Fade Transition (109, 188, 0); Screen Fade Transition (3, 10, 2); Teleport obj[255] to (254,204) |
| `ev[35]` | `128 (Loop)` | Story Flag 66 (bit 4) SET AND Story Flag 66 (bit 8) CLEAR | Warp Room -> Submap 1 at (7,8) |
| `ev[36]` | `1 (Action / Talk)` | Story Flag 66 (bit 4) SET AND Story Flag 66 (bit 8) CLEAR | Close Dialogue Sub-Window (9); Open Dialogue Message Window; Engine Action #9; Set Combat Battle BGM (60); Close Dialogue Sub-Window (10); Open Dialogue Message Window; Screen Fade Transition (73, 90, 3); Reset Camera Tracking (2); Close Dialogue Sub-Window (8); Open Dialogue Message Window; Close Dialogue Window; Set Combat Battle BGM (20); Award Potch Currency (9,6); Warp Room -> Submap 73 at (20,3) facing 9; Warp to Castle HQ (73, 20, 24); Engine Action #9; Open Dialogue Message Window; Display Dialogue Box [Bank: 73, MsgID: 60]; Close Dialogue Sub-Window (10); Open Dialogue Message Window; Place Scenery Structure (73); Branch on Choice (3, 9); Warp Room -> Submap 20 at (24,9) facing South (Down); Animate Door Open; Set Combat Battle BGM (20); Warp to Castle HQ (8, 1, 73); Mark NPC Talk Interaction Complete (Flag #24); Screen Fade Transition (0, 15, 73); Dismiss Emotion Bubble (72); Warp Room -> Submap 0 at (3,9) facing South (Down); Warp to Castle HQ (8, 0, 72); Open Dialogue Message Window; Engine Action #9; Set Combat Battle BGM (30); Load Sound Bank into Memory (1, 0); Warp to Castle HQ (73, 60, 72); Open Dialogue Message Window; Open Dialogue Message Window; Close Dialogue Sub-Window (9); Open Dialogue Message Window; Dismiss Dialogue Portrait; Close Dialogue Sub-Window (8); Open Dialogue Message Window; Change Portrait Expression (77); Engine Action #9; Engine Action #6; Warp Room -> Submap 2 at (30,3) facing 8; Warp Town -> Area 24 Map 9 Submap 0 at (18,3); Engine Action #9; Warp Town -> Area 73 Map 20 Submap 3 at (8,0); Load Sound Bank into Memory (1, 10); Open Dialogue Message Window; Set Combat Battle BGM (20); Award Potch Currency (10,0); Warp Room -> Submap 72 at (0,10) facing 24; Screen Fade Transition (0, 19, 73); Engine Action #90; Engine Action #9; Engine Action #66; Reset Camera Tracking (69); Warp to Castle HQ (101, 9, 8); Close Dialogue Window; Warp Town -> Area 2 Map 120 Submap 101 at (9,14); Warp Map Transition (2, 0, 42, 48, 58) |
| `ev[37]` | `1 (Action / Talk)` | Condition Check #29 AND Always Passes (Unconditional) AND Player Y within Range [255..254] | Recruit Character into Active Party (11 [Georg], 1); Warp Town -> Area 120 Map 100 Submap 0 at (2,58) |
| `ev[38]` | `1 (Action / Talk)` | Story Flag 66 (bit 8) SET AND Story Flag 66 (bit 16) CLEAR AND Player within Box [119..121, 2..187] AND Condition Check #200 | Load Sound Bank into Memory (1, 8); Engine Action #9; Turn obj[0] facing 10; Warp to Castle HQ (4, 0, 0); Engine Action #9; Engine Action #102; Open Dialogue Message Window; Jump to Bytecode Offset (9, 9); Jump to Bytecode Offset (1, 0); Display Chapter Text (2); Engine Action #6; Exit to World Map (77, 8, 6); Warp Room -> Submap 77 at (8,6) facing West (Left); Dismiss Emotion Bubble (24); Reset Camera Tracking (0); Fade In from Black (77); Reset Camera Tracking (6); Warp Room -> Submap 73 at (20,40) facing South (Down); Open Dialogue Message Window; Warp Town -> Area 0 Map 27 Submap 0 at (28,73); Dismiss Emotion Bubble (3); Screen Fade Transition (3, 73, 30); Award Potch Loot (+515 Potch); Exit to World Map (255, 3, 24); Screen Fade Transition (0, 29, 51); Engine Action #5; Exit to World Map (24, 10, 0); Dismiss Emotion Bubble (77); Reset Camera Tracking (6); Warp Room -> Submap 24 at (8,0) facing 31; Warp to Castle HQ (10, 2, 73); Trigger Character Emotion Effect (24, 10); Open Dialogue Message Window; Warp Map Transition (255, 5, 73, 120, 24); Engine Action #9; Open Dialogue Message Window; Return to Previous Memory Map (73); Branch on Choice (77, 10); Engine Action #6; Warp Room -> Submap 72 at (1,10) facing South (Down); Set Combat Battle BGM (60); Load Sound Bank into Memory (0, 10); Close Dialogue Sub-Window (10); Open Dialogue Message Window; Return Warp to Castle Base (43, 8); Engine Action #6; Load Sound Bank into Memory (0, 8); Turn obj[8] facing 10; Warp Town -> Area 5 Map 0 Submap 0 at (9,24); Reset Camera Tracking (0); Start Boss Battle #73 (BGM: 20); Warp to Castle HQ (10, 2, 73); Dismiss Emotion Bubble (77); Screen Fade Transition (2, 1, 30); Close Dialogue Sub-Window (10); Open Dialogue Message Window; Launch Tactical War Battle (72); Warp Room -> Submap 6 at (77,8) facing 6; Warp Town -> Area 30 Map 73 Submap 30 at (72,0); Reset Camera Tracking (24); Reset Camera Tracking (0); Toggle Random Encounters (73); Engine Action #90; Close Dialogue Sub-Window (10); Open Dialogue Message Window; Open Save Crystal Menu (MSaveInit); Set Combat Battle BGM (20); Turn obj[10] facing 9; Warp to Castle HQ (3, 1, 1); Reset Camera Tracking (3); Screen Fade Transition (2, 73, 120); Turn obj[10] facing 8; Warp to Castle HQ (4, 0, 0); Reset Camera Tracking (73); Dismiss Emotion Bubble (3); Screen Fade Transition (2, 73, 30); Close Dialogue Sub-Window (10); Open Dialogue Message Window; Engine Action #39; Award Potch Currency (8,3); Warp Room -> Submap 24 at (8,0) facing 40; Load Sound Bank into Memory (1, 10); Open Dialogue Message Window; Set Combat Battle BGM (60); Load Sound Bank into Memory (0, 10); Close Dialogue Sub-Window (10); Open Dialogue Message Window; Award Potch Loot (+6,152 Potch); Open Dialogue Message Window; Remove Item from Inventory (43, 8); Exit to World Map (73, 20, 40); Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 0 Map 43 Submap 0 at (44,36); Exit to World Map (41, 2, 6); Pan Camera (255, 6, 24); Reset Camera Tracking (0); Make obj[73] Visible (disp = 1); Branch on Choice (77, 8); Open Dialogue Message Window; Warp Room -> Submap 48 at (8,0) facing East (Right); Open Dialogue Message Window; Open Dialogue Message Window; Open Dialogue Message Window; Reset Camera Tracking (1); Reset Camera Tracking (29); Exit to World Map (115, 7, 27); Engine Action #54; Warp Room -> Submap 112 at (4,1) facing West (Left); Pan Camera (1, 70, 2); Open Dialogue Message Window; Engine Action #9; Engine Action #66; Dismiss Dialogue Portrait; Engine Action #58; Pan Camera (73, 30, 3); Screen Fade Transition (3, 24, 10); Open Dialogue Message Window; Make obj[24] Hidden (disp = 0); Reset Camera Tracking (0); Teleport obj[29] to (4,56); Reset Camera Tracking (0); Warp to Castle HQ (2, 0, 0); Engine Action #9; Set Entity Movement Speed (2, 77); Reset Camera Tracking (3); Reset Camera Tracking (0); Screen Fade Transition (3, 5, 0); Screen Fade Transition (30, 1, 8); Award Potch Currency (0,4); Warp to Castle HQ (7, 10, 1); Open Dialogue Message Window; Pan Camera (10, 2, 0); Pan Camera (5, 1, 0); Pan Camera (10, 30, 255); Walk obj[115] to (7,27); Engine Action #54; Warp Room -> Submap 112 at (4,1) facing West (Left); Pan Camera (1, 70, 2); Open Dialogue Message Window; Engine Action #9; Engine Action #66; Dismiss Dialogue Portrait; Display Dialogue Box [Bank: 0, MsgID: 50]; Engine Action #44; Engine Action #58 |
| `ev[39]` | `1 (Action / Talk)` | Story Flag 66 (bit 32) SET AND Story Flag 66 (bit 64) CLEAR AND Star of Destiny #1 Recruited AND Temp Event Flag #5 SET AND Story Flag 255 (mask 254) CLEAR | Recruit Character into Active Party (33 [Camus], 1); Pan Camera (48, 0, 10); Warp to Castle HQ (0, 0, 2); Engine Action #9; Warp to Castle HQ (0, 1, 52); Warp Room -> Submap 2 at (0,0) facing 8; Warp to Castle HQ (1, 1, 3); Screen Fade Transition (0, 24, 1); Open Dialogue Message Window; Engine Action #54; Set Combat Battle BGM (20); Set Combat Battle BGM (60); Close Dialogue Sub-Window (10); Open Dialogue Message Window; Set Render Priority (pri) (73, 120); Close Dialogue Sub-Window (9); Open Dialogue Message Window; Set Animation Pose (73, 20); Award Potch Currency (10,6); Warp Room -> Submap 72 at (1,10) facing South (Down); Set Combat Battle BGM (60); Load Sound Bank into Memory (0, 10); Close Dialogue Sub-Window (10); Open Dialogue Message Window; Recruit Character into Active Party (24 [Milie], 1); Open Dialogue Message Window; Engine Action #58; Set Combat Battle BGM (20); Set Combat Battle BGM (20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 0 Map 59 Submap 0 at (60,41); Warp Town -> Area 8 Map 9 Submap 255 at (8,3); Warp Room -> Submap 24 at (1,0) facing 61; Set Combat Battle BGM (20); Turn obj[1] facing South (Down); Warp to Castle HQ (0, 0, 0); Reset Camera Tracking (1); Warp Room -> Submap 66 at (64,58) facing 255; Engine Action #9; Close Dialogue Sub-Window (1); Open Dialogue Message Window; Engine Action #62; Set Combat Battle BGM (20); Turn obj[1] facing South (Down); Warp to Castle HQ (0, 0, 2); Engine Action #9; Set Entity Movement Speed (2, 77); Warp Room -> Submap 2 at (3,18) facing South (Down); Screen Fade Transition (3, 3, 0); Screen Fade Transition (30, 1, 1); Award Potch Currency (0,4); Warp to Castle HQ (7, 4, 2); Open Dialogue Message Window; Pan Camera (18, 1, 0); Pan Camera (10, 2, 0); Pan Camera (3, 1, 0); Pan Camera (10, 30, 255); Walk obj[9] to (66,64); Display Dialogue Box [Bank: 0, MsgID: 50]; Engine Action #44; Engine Action #58 |
| `ev[40]` | `1 (Action / Talk)` | Story Flag 66 (bit 128) SET AND Story Flag 67 (bit 1) CLEAR AND Star of Destiny #1 Recruited AND Temp Event Flag #255 SET | Return to Previous Memory Map (1); Pan Camera (28, 1, 14); Engine Action #5; Load Sound Bank into Memory (1, 9); Warp Town -> Area 73 Map 30 Submap 72 at (0,9); Open Shop Menu #7 (Type: 9); Award Potch Currency (9,2); Place Scenery Structure (0); Warp Town -> Area 2 Map 10 Submap 1 at (4,2); Warp Town -> Area 3 Map 0 Submap 30 at (43,9); Exit to World Map (48, 0, 10); Warp to Castle HQ (0, 0, 4); Reset Camera Tracking (3); Open Dialogue Message Window; Warp Room -> Submap 1 at (3,3) facing South (Down); Open Dialogue Message Window; Reset Camera Tracking (3); Warp Room -> Submap 3 at (10,0) facing 72; Warp Room -> Submap 0 at (29,4) facing 73; Dismiss Emotion Bubble (72); Open Dialogue Message Window; Screen Fade Transition (24, 1, 0); Engine Action #63; Set Combat Battle BGM (20); Close Dialogue Sub-Window (10); Open Dialogue Message Window; Animate Doorway State (24, 1); Open Dialogue Message Window; Play Sound Effect (SE) (73); Engine Action #40; Close Dialogue Sub-Window (10); Open Dialogue Message Window; Engine Action #66; Close Dialogue Sub-Window (1); Open Dialogue Message Window; Open Shop Interface #73; Trigger Character Emotion Effect (73, 20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 0 Map 68 Submap 0 at (69,3); Warp Room -> Submap 41 at (2,10) facing 11; Screen Fade Transition (24, 1, 0); Recruit Hero #73 into Battle Slot 20; Turn obj[1] facing South (Down); Warp to Castle HQ (0, 0, 0); Reset Camera Tracking (1); Warp Room -> Submap 67 at (1,58) facing 255; Close Dialogue Window; Close Dialogue Sub-Window (1); Open Dialogue Message Window; Remove Character from Active Party (73); Branch on Choice (48, 1); Open Dialogue Message Window; Warp to Castle HQ (0, 0, 2); Engine Action #9; Set Entity Movement Speed (2, 77); Warp Room -> Submap 2 at (2,3) facing South (Down); Engine Action #6; Dismiss Emotion Bubble (1); Warp Room -> Submap 254 at (77,0) facing 4; Warp to Castle HQ (7, 4, 3); Open Dialogue Message Window; Pan Camera (3, 1, 0); Pan Camera (6, 30, 255); Walk obj[9] to (67,1); Display Dialogue Box [Bank: 0, MsgID: 50]; Engine Action #44; Engine Action #58 |
| `ev[41]` | `1 (Action / Talk)` | Story Flag 67 (bit 2) SET AND Story Flag 67 (bit 4) CLEAR AND Star of Destiny #1 Recruited AND Temp Event Flag #255 SET | Recruit Character into Active Party (33 [Camus], 1); Pan Camera (48, 0, 10); Warp to Castle HQ (0, 0, 4); Reset Camera Tracking (3); Open Dialogue Message Window; Warp Room -> Submap 1 at (3,3) facing South (Down); Open Dialogue Message Window; Reset Camera Tracking (3); Warp Room -> Submap 24 at (1,0) facing 72; Award Potch Currency (1,2); Open Dialogue Message Window; Engine Action #5; Reset Camera Tracking (3); Open Dialogue Message Window; Engine Action #5; Reset Camera Tracking (2); Open Dialogue Message Window; Engine Action #5; Reset Camera Tracking (3); Open Dialogue Message Window; Engine Action #5; Reset Camera Tracking (2); Open Dialogue Message Window; Engine Action #5; Reset Camera Tracking (3); Open Dialogue Message Window; Engine Action #5; Reset Camera Tracking (2); Open Dialogue Message Window; Engine Action #5; Reset Camera Tracking (3); Open Dialogue Message Window; Engine Action #5; Reset Camera Tracking (1); Open Dialogue Message Window; Dismiss Emotion Bubble (73); Branch on Choice (24, 10); Open Dialogue Message Window; Set Combat Battle BGM (72); Warp Room -> Submap 6 at (77,1) facing 6; Warp Town -> Area 30 Map 73 Submap 60 at (72,0); Warp Room -> Submap 1 at (0,74) facing 73; Dismiss Emotion Bubble (24); Screen Fade Transition (0, 75, 73); Dismiss Emotion Bubble (24); Warp Room -> Submap 76 at (73,60) facing 24; Screen Fade Transition (0, 77, 73); Branch on Choice (48, 1); Open Dialogue Message Window; Warp to Castle HQ (0, 0, 0); Reset Camera Tracking (1); Warp Room -> Submap 67 at (4,58) facing 255 |
| `ev[42]` | `1 (Action / Talk)` | Story Flag 67 (bit 16) SET AND Story Flag 67 (bit 32) CLEAR | Recruit Character into Active Party (73 [Kasumi], 90); Close Dialogue Sub-Window (9); Open Dialogue Message Window; Engine Action #104; Set Combat Battle BGM (30); Close Dialogue Sub-Window (10); Open Dialogue Message Window; Set Object Direction (73, 60); Warp to Castle HQ (9, 2, 73); Dismiss Emotion Bubble (24); Engine Action #9; Open Dialogue Message Window; Set Character Quest Milestone (73, 20); Warp to Castle HQ (1, 3, 73); Dismiss Emotion Bubble (24); Warp Room -> Submap 107 at (73,20) facing 24; Engine Action #9; Open Dialogue Message Window; Engine Action #108; Set Combat Battle BGM (20); Close Dialogue Sub-Window (1); Open Dialogue Message Window; Engine Action #109; Set Combat Battle BGM (20); Turn obj[9] facing South (Down); Warp to Castle HQ (3, 0, 0); Engine Action #9; Warp to Castle HQ (1, 0, 24); Engine Action #9; Open Dialogue Message Window; Engine Action #110; Set Combat Battle BGM (20); Set Combat Battle BGM (20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 0 Map 111 Submap 0 at (112,73); Branch on Choice (41, 2); Open Dialogue Sub-Window (24); Open Dialogue Sub-Window (77); Warp Room -> Submap 1 at (30,24) facing West (Left); Open Dialogue Message Window; Engine Action #113; Set Combat Battle BGM (20); Warp to Castle HQ (9, 1, 73); Dismiss Emotion Bubble (51); Clear Dialogue Sub-Window; Close Dialogue Sub-Window (3); Engine Action #9; Warp Room -> Submap 30 at (24,9) facing South (Down); Engine Action #115; Set Combat Battle BGM (30); Close Dialogue Sub-Window (1); Open Dialogue Message Window; Engine Action #116; Clear Dialogue Sub-Window; Close Dialogue Sub-Window (9); Open Dialogue Message Window; Engine Action #114; Set Combat Battle BGM (30); Set Entity Movement Speed (2, 48); Engine Action #9; Open Dialogue Message Window; Warp to Castle HQ (3, 0, 1); Engine Action #9; Warp to Castle HQ (9, 2, 255); Turn obj[1] facing South (Down); Warp to Castle HQ (3, 1, 1); Engine Action #9; Warp to Castle HQ (1, 2, 255); Walk obj[73] to (30,24); Engine Action #9; Open Dialogue Message Window; Engine Action #118; Set Combat Battle BGM (20); Close Dialogue Sub-Window (1); Open Dialogue Message Window; Engine Action #119; Award Potch Currency (9,2); Warp Room -> Submap 24 at (9,0) facing 120; Set Combat Battle BGM (20); Award Potch Currency (9,3); Display Dialogue Box [Bank: 1, MsgID: 6]; Warp to Castle HQ (13, 0, 15); Dismiss Emotion Bubble (1); Engine Action #9; Warp to Castle HQ (1, 3, 77); Warp Room -> Submap 1 at (30,24) facing West (Left); Open Dialogue Message Window; Engine Action #121; Set Combat Battle BGM (20); Open Shop Menu #6 (Type: 1); Award Potch Currency (1,3); Close Dialogue Window; Warp Room -> Submap 3 at (13,0) facing 15; Dismiss Emotion Bubble (43); Warp Room -> Submap 1 at (1,84) facing 7; Warp Room -> Submap 84 at (8,31); Engine Action #115; Reset Camera Tracking (27); Set Combat Battle BGM (20); Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 101, 4); Engine Action #6; Engine Action #5; Open Dialogue Message Window; Warp Town -> Area 0 Map 5 Submap 3 at (1,0); Engine Action #5; Warp to Castle HQ (3, 0, 5); Warp to Castle HQ (0, 0, 5); Warp to Castle HQ (30, 89, 0); Warp Town -> Area 8 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Engine Action #89; Open Dialogue Message Window; Warp Town -> Area 9 Map 5 Submap 0 at (6,2); Dismiss Emotion Bubble (89); Open Dialogue Message Window; Warp Town -> Area 10 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Dismiss Emotion Bubble (1); Warp Room -> Submap 5 at (0,0) facing South (Down); Engine Action #5; Show Dialogue Portrait (3, 0, 30); Set Combat Battle BGM (20); Engine Action #5; Open Dialogue Message Window; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 101, 4); Engine Action #6; Engine Action #5; Open Dialogue Message Window; Warp Town -> Area 0 Map 5 Submap 3 at (1,0); Engine Action #5; Warp to Castle HQ (3, 0, 5); Warp to Castle HQ (0, 0, 5); Warp to Castle HQ (30, 89, 0); Warp Town -> Area 8 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Engine Action #89; Open Dialogue Message Window; Warp Town -> Area 9 Map 5 Submap 0 at (6,2); Dismiss Emotion Bubble (89); Open Dialogue Message Window; Warp Town -> Area 10 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Dismiss Emotion Bubble (1); Warp Room -> Submap 5 at (0,0) facing South (Down); Engine Action #5; Show Dialogue Portrait (3, 0, 30); Engine Action #62; Open Dialogue Message Window; Pan Camera (9, 67, 32); Engine Action #58 |
| `ev[43]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Close Dialogue Sub-Window (9); Open Dialogue Message Window; Turn obj[73] facing 20; Warp to Castle HQ (9, 3, 255) |
| `ev[44]` | `1 (Action / Talk)` | Story Flag 66 (bit 16) SET AND Story Flag 66 (bit 32) CLEAR AND Target Inspected is obj[10] | Open Dialogue Sub-Window (1); Engine Action #5 |
| `ev[45]` | `1 (Action / Talk)` | Story Flag 66 (bit 64) SET AND Story Flag 66 (bit 128) CLEAR AND Target Inspected is obj[10] | Open Dialogue Sub-Window (1); Engine Action #6 |
| `ev[46]` | `1 (Action / Talk)` | Story Flag 67 (bit 1) SET AND Story Flag 67 (bit 2) CLEAR AND Target Inspected is obj[10] | Open Dialogue Sub-Window (1); Pan Camera (255, 254, 204) |
| `ev[47]` | `1 (Action / Talk)` | Story Flag 67 (bit 4) SET AND Story Flag 67 (bit 32) CLEAR AND Target Inspected is obj[10] | Open Dialogue Sub-Window (1); Reset Camera Tracking (255) |
| `ev[48]` | `1 (Action / Talk)` | Target Inspected is obj[10] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Formation Check | Open Dialogue Sub-Window (10); Engine Action #39 |
| `ev[49]` | `1 (Action / Talk)` | Target Inspected is obj[10] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Member Count == 255 | Open Dialogue Sub-Window (12); Engine Action #39 |
| `ev[50]` | `1 (Action / Talk)` | Target Inspected is obj[10] AND Story Flag 143 (bit 2) CLEAR | Open Dialogue Sub-Window (7); Engine Action #39 |
| `ev[51]` | `1 (Action / Talk)` | Target Inspected is obj[10] AND Story Flag 143 (bit 2) SET AND Story Flag 134 (bit 1) CLEAR | Open Dialogue Sub-Window (11); Engine Action #39 |
| `ev[52]` | `1 (Action / Talk)` | Target Inspected is obj[10] AND Story Flag 134 (bit 1) SET | Open Dialogue Sub-Window (13); Engine Action #39 |
| `ev[53]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Open Dialogue Sub-Window (8); Pan Camera (255, 254, 204) |

---

### Submap Layer `vh03_02` (Index 2)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `9` Objects | **Script Count (`evkaz`)**: `30` Scripts

#### Complete Physical Entity Inventory (9 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 64541** | `64541` | `(47, 130)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Actor ID 64864** | `64864` | `(51, 134)` | `2x2` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[02]` | NPC / Actor | **Actor ID 65103** | `65103` | `(58, 135)` | `1x3` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[03]` | NPC / Actor | **Actor ID 65161** | `65161` | `(52, 143)` | `3x4` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[04]` | NPC / Actor | **Actor ID 65159** | `65159` | `(56, 147)` | `0x0` | East (Right) | Visible (1) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[05]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(36, 141)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | Trigger / Hitbox | **Hitbox Zone (2x3)** | `0` | `(49, 126)` | `1x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(52, 127)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Trigger / Hitbox | **Hitbox Zone (3x6)** | `0` | `(55, 145)` | `2x5` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 64541)**: Positioned at tile `(47, 130)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Object 64864)**: Positioned at tile `(51, 134)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Object 65103)**: Positioned at tile `(58, 135)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Object 65161)**: Positioned at tile `(52, 143)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Object 65159)**: Positioned at tile `(56, 147)`, facing East (Right). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(36, 141)` to `(37, 142)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[06]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `3` tiles high from `(49, 126)` to `(50, 128)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[07]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(52, 127)` to `(53, 128)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[08]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `6` tiles high from `(55, 145)` to `(57, 150)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (30 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Target Inspected is obj[8] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Formation Check | Open Dialogue Sub-Window (10); Animate Door Open; Set Combat Battle BGM (20); Warp to Castle HQ (8, 0, 255) |
| `ev[01]` | `1 (Action / Talk)` | Target Inspected is obj[8] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Member Count == 255 | Open Dialogue Sub-Window (12); Animate Door Open; Set Combat Battle BGM (20); Warp to Castle HQ (8, 0, 255) |
| `ev[02]` | `1 (Action / Talk)` | Target Inspected is obj[8] AND Story Flag 143 (bit 2) CLEAR | Open Dialogue Sub-Window (7); Animate Door Open; Set Combat Battle BGM (20); Warp to Castle HQ (8, 0, 255) |
| `ev[03]` | `1 (Action / Talk)` | Target Inspected is obj[8] AND Story Flag 143 (bit 2) SET AND Story Flag 134 (bit 1) CLEAR | Open Dialogue Sub-Window (11); Animate Door Open; Set Combat Battle BGM (20); Warp to Castle HQ (8, 0, 255) |
| `ev[04]` | `1 (Action / Talk)` | Target Inspected is obj[8] AND Story Flag 134 (bit 1) SET | Open Dialogue Sub-Window (13); Animate Door Open; Set Combat Battle BGM (20); Warp to Castle HQ (8, 0, 255) |
| `ev[05]` | `1 (Action / Talk)` | Target Inspected is obj[9] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Formation Check | Open Dialogue Sub-Window (10); Show Dialogue Portrait (255, 254, 204) |
| `ev[06]` | `1 (Action / Talk)` | Target Inspected is obj[9] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Member Count == 255 | Open Dialogue Sub-Window (12); Show Dialogue Portrait (255, 254, 204) |
| `ev[07]` | `1 (Action / Talk)` | Target Inspected is obj[9] AND Story Flag 143 (bit 2) CLEAR | Open Dialogue Sub-Window (7); Show Dialogue Portrait (255, 254, 204) |
| `ev[08]` | `1 (Action / Talk)` | Target Inspected is obj[9] AND Story Flag 143 (bit 2) SET AND Story Flag 134 (bit 1) CLEAR | Open Dialogue Sub-Window (11); Show Dialogue Portrait (255, 254, 204) |
| `ev[09]` | `1 (Action / Talk)` | Target Inspected is obj[9] AND Story Flag 134 (bit 1) SET | Open Dialogue Sub-Window (13); Show Dialogue Portrait (255, 254, 204) |
| `ev[10]` | `1 (Action / Talk)` | Target Inspected is obj[10] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Formation Check | Open Dialogue Sub-Window (10); Dismiss Dialogue Portrait |
| `ev[11]` | `1 (Action / Talk)` | Target Inspected is obj[10] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Member Count == 255 | Open Dialogue Sub-Window (12); Dismiss Dialogue Portrait |
| `ev[12]` | `1 (Action / Talk)` | Target Inspected is obj[10] AND Story Flag 143 (bit 2) CLEAR | Open Dialogue Sub-Window (7); Dismiss Dialogue Portrait |
| `ev[13]` | `1 (Action / Talk)` | Target Inspected is obj[10] AND Story Flag 143 (bit 2) SET AND Story Flag 134 (bit 1) CLEAR | Open Dialogue Sub-Window (11); Dismiss Dialogue Portrait |
| `ev[14]` | `1 (Action / Talk)` | Target Inspected is obj[10] AND Story Flag 134 (bit 1) SET | Open Dialogue Sub-Window (13); Dismiss Dialogue Portrait |
| `ev[15]` | `1 (Action / Talk)` | Target Inspected is obj[11] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Formation Check | Open Dialogue Sub-Window (10); Change Portrait Expression (255) |
| `ev[16]` | `1 (Action / Talk)` | Target Inspected is obj[11] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Member Count == 255 | Open Dialogue Sub-Window (12); Change Portrait Expression (255) |
| `ev[17]` | `1 (Action / Talk)` | Target Inspected is obj[11] AND Story Flag 143 (bit 2) CLEAR | Open Dialogue Sub-Window (7); Change Portrait Expression (255) |
| `ev[18]` | `1 (Action / Talk)` | Target Inspected is obj[11] AND Story Flag 143 (bit 2) SET AND Story Flag 134 (bit 1) CLEAR | Open Dialogue Sub-Window (11); Change Portrait Expression (255) |
| `ev[19]` | `1 (Action / Talk)` | Target Inspected is obj[11] AND Story Flag 134 (bit 1) SET | Open Dialogue Sub-Window (13); Change Portrait Expression (255) |
| `ev[20]` | `1 (Action / Talk)` | Target Inspected is obj[12] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Formation Check | Open Dialogue Sub-Window (10); Display Speaker Name Box (73); Branch on Choice (3, 12); Warp to Castle HQ (255, 254, 204) |
| `ev[21]` | `1 (Action / Talk)` | Target Inspected is obj[12] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Member Count == 255 | Open Dialogue Sub-Window (12); Display Speaker Name Box (73); Branch on Choice (3, 12); Warp to Castle HQ (255, 254, 204) |
| `ev[22]` | `1 (Action / Talk)` | Target Inspected is obj[12] AND Story Flag 143 (bit 2) CLEAR | Open Dialogue Sub-Window (7); Display Speaker Name Box (73); Branch on Choice (3, 12); Warp to Castle HQ (255, 254, 204) |
| `ev[23]` | `1 (Action / Talk)` | Target Inspected is obj[12] AND Story Flag 143 (bit 2) SET AND Story Flag 134 (bit 1) CLEAR | Open Dialogue Sub-Window (11); Display Speaker Name Box (73); Branch on Choice (3, 12); Warp to Castle HQ (255, 254, 204) |
| `ev[24]` | `1 (Action / Talk)` | Target Inspected is obj[12] AND Story Flag 134 (bit 1) SET | Open Dialogue Sub-Window (13); Display Speaker Name Box (73); Branch on Choice (3, 12); Warp to Castle HQ (255, 254, 204) |
| `ev[25]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Open Dialogue Sub-Window (8); Screen Fade Transition (255, 254, 204) |
| `ev[26]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Open Dialogue Sub-Window (8); Close Dialogue Window |
| `ev[27]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Open Dialogue Sub-Window (8); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[28]` | `1 (Action / Talk)` | Player within Box [33..36, 2..146] AND Condition Check #148 | Display Dialogue Box [Bank: 0, MsgID: 66]; Teleport Object to Coordinates (255, 254, 204) |
| `ev[29]` | `1 (Action / Talk)` | Player within Box [35..38, 2..148] AND Condition Check #155 | Display Dialogue Box [Bank: 0, MsgID: 66]; Teleport Object to Coordinates (255, 254, 204) |

---

### Submap Layer `vh03_03` (Index 3)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `6` Objects | **Script Count (`evkaz`)**: `20` Scripts

#### Complete Physical Entity Inventory (6 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 64542** | `64542` | `(115, 140)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Actor ID 65103** | `65103` | `(118, 145)` | `2x5` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[02]` | NPC / Actor | **Actor ID 65148** | `65148` | `(111, 144)` | `5x5` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[03]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(111, 127)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(125, 131)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(126, 141)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 64542)**: Positioned at tile `(115, 140)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Object 65103)**: Positioned at tile `(118, 145)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Object 65148)**: Positioned at tile `(111, 144)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(111, 127)` to `(112, 128)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[04]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(125, 131)` to `(126, 132)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[05]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(126, 141)` to `(127, 142)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (20 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Target Inspected is obj[8] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Formation Check | Open Dialogue Sub-Window (10); Display Choice Selection (73, 20); Warp to Castle HQ (8, 0, 255) |
| `ev[01]` | `1 (Action / Talk)` | Target Inspected is obj[8] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Member Count == 255 | Open Dialogue Sub-Window (12); Display Choice Selection (73, 20); Warp to Castle HQ (8, 0, 255) |
| `ev[02]` | `1 (Action / Talk)` | Target Inspected is obj[8] AND Story Flag 143 (bit 2) CLEAR | Open Dialogue Sub-Window (7); Display Choice Selection (73, 20); Warp to Castle HQ (8, 0, 255) |
| `ev[03]` | `1 (Action / Talk)` | Target Inspected is obj[8] AND Story Flag 143 (bit 2) SET AND Story Flag 134 (bit 1) CLEAR | Open Dialogue Sub-Window (11); Display Choice Selection (73, 20); Warp to Castle HQ (8, 0, 255) |
| `ev[04]` | `1 (Action / Talk)` | Target Inspected is obj[8] AND Story Flag 134 (bit 1) SET | Open Dialogue Sub-Window (13); Display Choice Selection (73, 20); Warp to Castle HQ (8, 0, 255) |
| `ev[05]` | `1 (Action / Talk)` | Target Inspected is obj[9] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Formation Check | Open Dialogue Sub-Window (10); Branch on Choice (255, 254) |
| `ev[06]` | `1 (Action / Talk)` | Target Inspected is obj[9] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Member Count == 255 | Open Dialogue Sub-Window (12); Branch on Choice (255, 254) |
| `ev[07]` | `1 (Action / Talk)` | Target Inspected is obj[9] AND Story Flag 143 (bit 2) CLEAR | Open Dialogue Sub-Window (7); Branch on Choice (255, 254) |
| `ev[08]` | `1 (Action / Talk)` | Target Inspected is obj[9] AND Story Flag 143 (bit 2) SET AND Story Flag 134 (bit 1) CLEAR | Open Dialogue Sub-Window (11); Branch on Choice (255, 254) |
| `ev[09]` | `1 (Action / Talk)` | Target Inspected is obj[9] AND Story Flag 134 (bit 1) SET | Open Dialogue Sub-Window (13); Branch on Choice (255, 254) |
| `ev[10]` | `1 (Action / Talk)` | Target Inspected is obj[10] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Formation Check | Open Dialogue Sub-Window (10); Execute Choice Result (255) |
| `ev[11]` | `1 (Action / Talk)` | Target Inspected is obj[10] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Member Count == 255 | Open Dialogue Sub-Window (12); Execute Choice Result (255) |
| `ev[12]` | `1 (Action / Talk)` | Target Inspected is obj[10] AND Story Flag 143 (bit 2) CLEAR | Open Dialogue Sub-Window (7); Execute Choice Result (255) |
| `ev[13]` | `1 (Action / Talk)` | Target Inspected is obj[10] AND Story Flag 143 (bit 2) SET AND Story Flag 134 (bit 1) CLEAR | Open Dialogue Sub-Window (11); Execute Choice Result (255) |
| `ev[14]` | `1 (Action / Talk)` | Target Inspected is obj[10] AND Story Flag 134 (bit 1) SET | Open Dialogue Sub-Window (13); Execute Choice Result (255) |
| `ev[15]` | `1 (Action / Talk)` | Target Inspected is obj[11] | Open Dialogue Sub-Window (8); Place Scenery Structure (255) |
| `ev[16]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Open Dialogue Sub-Window (8); Animate Door Open |
| `ev[17]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Open Dialogue Sub-Window (8); Show Dialogue Portrait (255, 254, 204) |
| `ev[18]` | `1 (Action / Talk)` | Player within Box [100..103, 2..146] AND Condition Check #148 | Display Dialogue Box [Bank: 0, MsgID: 53]; Award Potch Currency (255,254) |
| `ev[19]` | `1 (Action / Talk)` | Player within Box [102..104, 2..148] AND Condition Check #155 | Display Dialogue Box [Bank: 0, MsgID: 53]; Award Potch Currency (255,254) |

---

### Submap Layer `vh03_04` (Index 4)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `3` Objects | **Script Count (`evkaz`)**: `9` Scripts

#### Complete Physical Entity Inventory (3 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 64598** | `64598` | `(45, 194)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[01]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(60, 187)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(47, 181)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 64598)**: Positioned at tile `(45, 194)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(60, 187)` to `(61, 188)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[02]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(47, 181)` to `(50, 182)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (9 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Target Inspected is obj[8] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Formation Check | Open Dialogue Sub-Window (10); Set Story Flag (73, 20); Warp to Castle HQ (8, 0, 255) |
| `ev[01]` | `1 (Action / Talk)` | Target Inspected is obj[8] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Member Count == 255 | Open Dialogue Sub-Window (12); Set Story Flag (73, 20); Warp to Castle HQ (8, 0, 255) |
| `ev[02]` | `1 (Action / Talk)` | Target Inspected is obj[8] AND Story Flag 143 (bit 2) CLEAR | Open Dialogue Sub-Window (7); Set Story Flag (73, 20); Warp to Castle HQ (8, 0, 255) |
| `ev[03]` | `1 (Action / Talk)` | Target Inspected is obj[8] AND Story Flag 143 (bit 2) SET AND Story Flag 134 (bit 1) CLEAR | Open Dialogue Sub-Window (11); Set Story Flag (73, 20); Warp to Castle HQ (8, 0, 255) |
| `ev[04]` | `1 (Action / Talk)` | Target Inspected is obj[8] AND Story Flag 134 (bit 1) SET | Open Dialogue Sub-Window (13); Set Story Flag (73, 20); Warp to Castle HQ (8, 0, 255) |
| `ev[05]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Open Dialogue Sub-Window (8); Dismiss Dialogue Portrait |
| `ev[06]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Open Dialogue Sub-Window (8); Change Portrait Expression (255) |
| `ev[07]` | `1 (Action / Talk)` | Player within Box [60..63, 2..199] AND Condition Check #201 | Display Dialogue Box [Bank: 0, MsgID: 48]; Play CD / Ambient BGM Track (255) |
| `ev[08]` | `1 (Action / Talk)` | Player within Box [58..60, 2..201] AND Condition Check #212 | Display Dialogue Box [Bank: 0, MsgID: 48]; Play CD / Ambient BGM Track (255) |

---

### Submap Layer `vh03_05` (Index 5)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `7` Objects | **Script Count (`evkaz`)**: `9` Scripts

#### Complete Physical Entity Inventory (7 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 65103** | `65103` | `(46, 81)` | `0x0` | West (Left) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | Trigger / Hitbox | **Hitbox Zone (2x3)** | `0` | `(43, 82)` | `1x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | Trigger / Hitbox | **Hitbox Zone (2x3)** | `0` | `(53, 82)` | `1x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | Trigger / Hitbox | **Hitbox Zone (7x2)** | `0` | `(45, 85)` | `6x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | NPC / Actor | **Actor ID 65103** | `65103` | `(50, 90)` | `5x5` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[05]` | NPC / Actor | **Actor ID 65157** | `65157` | `(51, 78)` | `3x3` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[06]` | NPC / Actor | **Actor ID 64857** | `64857` | `(53, 80)` | `3x3` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 65103)**: Positioned at tile `(46, 81)`, facing West (Left). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `3` tiles high from `(43, 82)` to `(44, 84)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[02]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `3` tiles high from `(53, 82)` to `(54, 84)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[03]` (Hitbox Zone)**: Bounding trigger area covering `7` tiles wide by `2` tiles high from `(45, 85)` to `(51, 86)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[04]` (Object 65103)**: Positioned at tile `(50, 90)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Object 65157)**: Positioned at tile `(51, 78)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[06]` (Object 64857)**: Positioned at tile `(53, 80)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.


#### Complete Bytecode Script Catalog (9 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Target Inspected is obj[12] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Formation Check | Open Dialogue Sub-Window (10); Toggle Random Encounters (255) |
| `ev[01]` | `1 (Action / Talk)` | Target Inspected is obj[12] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Member Count == 255 | Open Dialogue Sub-Window (12); Toggle Random Encounters (255) |
| `ev[02]` | `1 (Action / Talk)` | Target Inspected is obj[12] AND Story Flag 143 (bit 2) CLEAR | Open Dialogue Sub-Window (7); Toggle Random Encounters (255) |
| `ev[03]` | `1 (Action / Talk)` | Target Inspected is obj[12] AND Story Flag 143 (bit 2) SET AND Story Flag 134 (bit 1) CLEAR | Open Dialogue Sub-Window (11); Toggle Random Encounters (255) |
| `ev[04]` | `1 (Action / Talk)` | Target Inspected is obj[12] AND Story Flag 134 (bit 1) SET | Open Dialogue Sub-Window (13); Toggle Random Encounters (255) |
| `ev[05]` | `1 (Action / Talk)` | Target Inspected is obj[9] AND Story Flag 3 (mask 255) SET | Turn obj[8] facing South (Down); Warp to Castle HQ (4, 1, 0); Engine Action #9; Warp to Castle HQ (8, 2, 96); Pan Camera (8, 2, 0); Pan Camera (41, 3, 0); Screen Fade Transition (14, 255, 254) |
| `ev[06]` | `1 (Action / Talk)` | Target Inspected is obj[10] AND Story Flag 2 (mask 255) SET | Turn obj[8] facing South (Down); Warp Town -> Area 4 Map 1 Submap 0 at (9,3); Reset Camera Tracking (3); Clear Story Milestone Flag 7 (mask 8); Warp Town -> Area 0 Map 7 Submap 41 at (3,0); Screen Fade Transition (14, 255, 254) |
| `ev[07]` | `1 (Action / Talk)` | Target Inspected is obj[11] AND Story Flag 1 (mask 255) SET | Turn obj[8] facing South (Down); Warp Town -> Area 0 Map 1 Submap 4 at (9,3); Reset Camera Tracking (0); Clear Story Milestone Flag 7 (mask 8); Warp Town -> Area 0 Map 7 Submap 41 at (3,0); Screen Fade Transition (14, 255, 254) |
| `ev[08]` | `1 (Action / Talk)` | Player within Box [46..50, 2..97] AND Condition Check #103 | Display Dialogue Box [Bank: 0, MsgID: 68]; Animate Door obj[255] (State: 254) |

---

### Submap Layer `vh03_06` (Index 6)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `11` Objects | **Script Count (`evkaz`)**: `31` Scripts

#### Complete Physical Entity Inventory (11 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 65103** | `65103` | `(118, 54)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | Trigger / Hitbox | **Hitbox Zone (11x2)** | `0` | `(115, 55)` | `10x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | Trigger / Hitbox | **Hitbox Zone (2x4)** | `0` | `(111, 51)` | `1x3` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[03]` | NPC / Actor | **Actor ID 65162** | `65162` | `(111, 63)` | `10x10` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[04]` | NPC / Actor | **Actor ID 65160** | `65160` | `(126, 66)` | `5x5` | South (Down) | Visible (1) | Special (3) | 4 | 128 | 0 |
| `obj[05]` | NPC / Actor | **Actor ID 64600** | `64600` | `(139, 69)` | `0x0` | Up (North) | Visible (1) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[06]` | NPC / Actor | **Actor ID 64599** | `64599` | `(147, 68)` | `0x0` | West (Left) | Visible (1) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[07]` | NPC / Actor | **Actor ID 65148** | `65148` | `(143, 66)` | `3x5` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[08]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(104, 62)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(107, 59)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(138, 49)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 65103)**: Positioned at tile `(118, 54)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Hitbox Zone)**: Bounding trigger area covering `11` tiles wide by `2` tiles high from `(115, 55)` to `(125, 56)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[02]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `4` tiles high from `(111, 51)` to `(112, 54)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[03]` (Object 65162)**: Positioned at tile `(111, 63)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Object 65160)**: Positioned at tile `(126, 66)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Object 64600)**: Positioned at tile `(139, 69)`, facing Up (North). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[06]` (Object 64599)**: Positioned at tile `(147, 68)`, facing West (Left). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[07]` (Object 65148)**: Positioned at tile `(143, 66)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[08]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(104, 62)` to `(105, 63)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[09]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(107, 59)` to `(108, 60)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[10]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(138, 49)` to `(140, 50)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (31 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Target Inspected is obj[11] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Formation Check | Open Dialogue Sub-Window (10); Fade In from Black (255) |
| `ev[01]` | `1 (Action / Talk)` | Target Inspected is obj[11] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Member Count == 255 | Open Dialogue Sub-Window (12); Fade In from Black (255) |
| `ev[02]` | `1 (Action / Talk)` | Target Inspected is obj[11] AND Story Flag 143 (bit 2) CLEAR | Open Dialogue Sub-Window (7); Fade In from Black (255) |
| `ev[03]` | `1 (Action / Talk)` | Target Inspected is obj[11] AND Story Flag 143 (bit 2) SET AND Story Flag 134 (bit 1) CLEAR | Open Dialogue Sub-Window (11); Fade In from Black (255) |
| `ev[04]` | `1 (Action / Talk)` | Target Inspected is obj[11] AND Story Flag 134 (bit 1) SET | Open Dialogue Sub-Window (13); Fade In from Black (255) |
| `ev[05]` | `1 (Action / Talk)` | Target Inspected is obj[12] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Formation Check | Open Dialogue Sub-Window (10); Fade Out to Black (255) |
| `ev[06]` | `1 (Action / Talk)` | Target Inspected is obj[12] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Member Count == 255 | Open Dialogue Sub-Window (12); Fade Out to Black (255) |
| `ev[07]` | `1 (Action / Talk)` | Target Inspected is obj[12] AND Story Flag 143 (bit 2) CLEAR | Open Dialogue Sub-Window (7); Fade Out to Black (255) |
| `ev[08]` | `1 (Action / Talk)` | Target Inspected is obj[12] AND Story Flag 143 (bit 2) SET AND Story Flag 134 (bit 1) CLEAR | Open Dialogue Sub-Window (11); Fade Out to Black (255) |
| `ev[09]` | `1 (Action / Talk)` | Target Inspected is obj[12] AND Story Flag 134 (bit 1) SET | Open Dialogue Sub-Window (13); Fade Out to Black (255) |
| `ev[10]` | `1 (Action / Talk)` | Target Inspected is obj[13] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Formation Check | Open Dialogue Sub-Window (10); Display Chapter Text (73); Branch on Choice (3, 13); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[11]` | `1 (Action / Talk)` | Target Inspected is obj[13] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Member Count == 255 | Open Dialogue Sub-Window (12); Display Chapter Text (73); Branch on Choice (3, 13); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[12]` | `1 (Action / Talk)` | Target Inspected is obj[13] AND Story Flag 143 (bit 2) CLEAR | Open Dialogue Sub-Window (7); Display Chapter Text (73); Branch on Choice (3, 13); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[13]` | `1 (Action / Talk)` | Target Inspected is obj[13] AND Story Flag 143 (bit 2) SET AND Story Flag 134 (bit 1) CLEAR | Open Dialogue Sub-Window (11); Display Chapter Text (73); Branch on Choice (3, 13); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[14]` | `1 (Action / Talk)` | Target Inspected is obj[13] AND Story Flag 134 (bit 1) SET | Open Dialogue Sub-Window (13); Display Chapter Text (73); Branch on Choice (3, 13); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[15]` | `1 (Action / Talk)` | Target Inspected is obj[14] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Formation Check | Open Dialogue Sub-Window (10); Display Emotion Bubble (73, 20); Warp to Castle HQ (14, 1, 255) |
| `ev[16]` | `1 (Action / Talk)` | Target Inspected is obj[14] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Member Count == 255 | Open Dialogue Sub-Window (12); Display Emotion Bubble (73, 20); Warp to Castle HQ (14, 1, 255) |
| `ev[17]` | `1 (Action / Talk)` | Target Inspected is obj[14] AND Story Flag 143 (bit 2) CLEAR | Open Dialogue Sub-Window (7); Display Emotion Bubble (73, 20); Warp to Castle HQ (14, 1, 255) |
| `ev[18]` | `1 (Action / Talk)` | Target Inspected is obj[14] AND Story Flag 143 (bit 2) SET AND Story Flag 134 (bit 1) CLEAR | Open Dialogue Sub-Window (11); Display Emotion Bubble (73, 20); Warp to Castle HQ (14, 1, 255) |
| `ev[19]` | `1 (Action / Talk)` | Target Inspected is obj[14] AND Story Flag 134 (bit 1) SET | Open Dialogue Sub-Window (13); Display Emotion Bubble (73, 20); Warp to Castle HQ (14, 1, 255) |
| `ev[20]` | `1 (Action / Talk)` | Target Inspected is obj[15] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Formation Check | Open Dialogue Sub-Window (10); Dismiss Emotion Bubble (255) |
| `ev[21]` | `1 (Action / Talk)` | Target Inspected is obj[15] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Member Count == 255 | Open Dialogue Sub-Window (12); Dismiss Emotion Bubble (255) |
| `ev[22]` | `1 (Action / Talk)` | Target Inspected is obj[15] AND Story Flag 143 (bit 2) CLEAR | Open Dialogue Sub-Window (7); Dismiss Emotion Bubble (255) |
| `ev[23]` | `1 (Action / Talk)` | Target Inspected is obj[15] AND Story Flag 143 (bit 2) SET AND Story Flag 134 (bit 1) CLEAR | Open Dialogue Sub-Window (11); Dismiss Emotion Bubble (255) |
| `ev[24]` | `1 (Action / Talk)` | Target Inspected is obj[15] AND Story Flag 134 (bit 1) SET | Open Dialogue Sub-Window (13); Dismiss Emotion Bubble (255) |
| `ev[25]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Open Dialogue Sub-Window (8); Display Speaker Name Box (255) |
| `ev[26]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Open Dialogue Sub-Window (8); Display Choice Selection (255, 254) |
| `ev[27]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Open Dialogue Sub-Window (8); Branch on Choice (255, 254) |
| `ev[28]` | `1 (Action / Talk)` | Player within Box [116..120, 2..74] AND Condition Check #78 | Display Dialogue Box [Bank: 0, MsgID: 40]; Mark NPC Talk Interaction Complete (Flag #255) |
| `ev[29]` | `1 (Action / Talk)` | Story Flag 1 (mask 5) SET AND Story Flag 255 (mask 254) SET | Turn obj[8] facing South (Down); Warp Town -> Area 0 Map 1 Submap 3 at (8,3); Reset Camera Tracking (0); Clear Story Milestone Flag 15 (mask 8); Warp Town -> Area 2 Map 7 Submap 40 at (2,11); Open Dialogue Message Window |
| `ev[30]` | `1 (Action / Talk)` | Party Holds At Least 100 Potch AND Story Flag 2 (mask 5) SET AND Story Flag 255 (mask 254) CLEAR | Turn obj[8] facing South (Down); Warp Town -> Area 3 Map 1 Submap 0 at (9,3); Reset Camera Tracking (3); Clear Story Milestone Flag 15 (mask 8); Warp Town -> Area 2 Map 7 Submap 40 at (2,11); Open Dialogue Message Window |

---

### Submap Layer `vh03_07` (Index 7)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `12` Objects | **Script Count (`evkaz`)**: `36` Scripts

#### Complete Physical Entity Inventory (12 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 65103** | `65103` | `(210, 60)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | Trigger / Hitbox | **Hitbox Zone (8x2)** | `0` | `(208, 61)` | `7x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Actor ID 65159** | `65159` | `(206, 64)` | `1x1` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[03]` | NPC / Actor | **Actor ID 64543** | `64543` | `(213, 72)` | `0x0` | West (Left) | Visible (1) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[04]` | NPC / Actor | **Actor ID 64857** | `64857` | `(201, 70)` | `1x1` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[05]` | NPC / Actor | **Actor ID 65148** | `65148` | `(200, 87)` | `1x1` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[06]` | NPC / Actor | **Actor ID 64864** | `64864` | `(217, 92)` | `1x1` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[07]` | NPC / Actor | **Actor ID 64544** | `64544` | `(217, 72)` | `0x0` | West (Left) | Visible (1) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[08]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(197, 59)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(200, 61)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(219, 61)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(221, 59)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 65103)**: Positioned at tile `(210, 60)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Hitbox Zone)**: Bounding trigger area covering `8` tiles wide by `2` tiles high from `(208, 61)` to `(215, 62)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[02]` (Object 65159)**: Positioned at tile `(206, 64)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Object 64543)**: Positioned at tile `(213, 72)`, facing West (Left). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Object 64857)**: Positioned at tile `(201, 70)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Object 65148)**: Positioned at tile `(200, 87)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[06]` (Object 64864)**: Positioned at tile `(217, 92)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[07]` (Object 64544)**: Positioned at tile `(217, 72)`, facing West (Left). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[08]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(197, 59)` to `(198, 60)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[09]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(200, 61)` to `(201, 62)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[10]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(219, 61)` to `(220, 62)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[11]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(221, 59)` to `(222, 60)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (36 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `1 (Action / Talk)` | Target Inspected is obj[10] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Formation Check | Open Dialogue Sub-Window (10); Warp Room -> Submap 255 at (254,204) |
| `ev[01]` | `1 (Action / Talk)` | Target Inspected is obj[10] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Member Count == 255 | Open Dialogue Sub-Window (12); Warp Room -> Submap 255 at (254,204) |
| `ev[02]` | `1 (Action / Talk)` | Target Inspected is obj[10] AND Story Flag 143 (bit 2) CLEAR | Open Dialogue Sub-Window (7); Warp Room -> Submap 255 at (254,204) |
| `ev[03]` | `1 (Action / Talk)` | Target Inspected is obj[10] AND Story Flag 143 (bit 2) SET AND Story Flag 134 (bit 1) CLEAR | Open Dialogue Sub-Window (11); Warp Room -> Submap 255 at (254,204) |
| `ev[04]` | `1 (Action / Talk)` | Target Inspected is obj[10] AND Story Flag 134 (bit 1) SET | Open Dialogue Sub-Window (13); Warp Room -> Submap 255 at (254,204) |
| `ev[05]` | `1 (Action / Talk)` | Target Inspected is obj[11] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Formation Check | Open Dialogue Sub-Window (10); Warp Map Transition (73, 20, 3, 11, 1) |
| `ev[06]` | `1 (Action / Talk)` | Target Inspected is obj[11] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Member Count == 255 | Open Dialogue Sub-Window (12); Warp Map Transition (73, 20, 3, 11, 1) |
| `ev[07]` | `1 (Action / Talk)` | Target Inspected is obj[11] AND Story Flag 143 (bit 2) CLEAR | Open Dialogue Sub-Window (7); Warp Map Transition (73, 20, 3, 11, 1) |
| `ev[08]` | `1 (Action / Talk)` | Target Inspected is obj[11] AND Story Flag 143 (bit 2) SET AND Story Flag 134 (bit 1) CLEAR | Open Dialogue Sub-Window (11); Warp Map Transition (73, 20, 3, 11, 1) |
| `ev[09]` | `1 (Action / Talk)` | Target Inspected is obj[11] AND Story Flag 134 (bit 1) SET | Open Dialogue Sub-Window (13); Warp Map Transition (73, 20, 3, 11, 1) |
| `ev[10]` | `1 (Action / Talk)` | Target Inspected is obj[12] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Formation Check | Open Dialogue Sub-Window (10); Return to Previous Memory Map (255) |
| `ev[11]` | `1 (Action / Talk)` | Target Inspected is obj[12] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Member Count == 255 | Open Dialogue Sub-Window (12); Return to Previous Memory Map (255) |
| `ev[12]` | `1 (Action / Talk)` | Target Inspected is obj[12] AND Story Flag 143 (bit 2) CLEAR | Open Dialogue Sub-Window (7); Return to Previous Memory Map (255) |
| `ev[13]` | `1 (Action / Talk)` | Target Inspected is obj[12] AND Story Flag 143 (bit 2) SET AND Story Flag 134 (bit 1) CLEAR | Open Dialogue Sub-Window (11); Return to Previous Memory Map (255) |
| `ev[14]` | `1 (Action / Talk)` | Target Inspected is obj[12] AND Story Flag 134 (bit 1) SET | Open Dialogue Sub-Window (13); Return to Previous Memory Map (255) |
| `ev[15]` | `1 (Action / Talk)` | Target Inspected is obj[13] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Formation Check | Open Dialogue Sub-Window (10); Return Warp to Castle Base (255, 254) |
| `ev[16]` | `1 (Action / Talk)` | Target Inspected is obj[13] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Member Count == 255 | Open Dialogue Sub-Window (12); Return Warp to Castle Base (255, 254) |
| `ev[17]` | `1 (Action / Talk)` | Target Inspected is obj[13] AND Story Flag 143 (bit 2) CLEAR | Open Dialogue Sub-Window (7); Return Warp to Castle Base (255, 254) |
| `ev[18]` | `1 (Action / Talk)` | Target Inspected is obj[13] AND Story Flag 143 (bit 2) SET AND Story Flag 134 (bit 1) CLEAR | Open Dialogue Sub-Window (11); Return Warp to Castle Base (255, 254) |
| `ev[19]` | `1 (Action / Talk)` | Target Inspected is obj[13] AND Story Flag 134 (bit 1) SET | Open Dialogue Sub-Window (13); Return Warp to Castle Base (255, 254) |
| `ev[20]` | `1 (Action / Talk)` | Target Inspected is obj[14] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Formation Check | Open Dialogue Sub-Window (10); Start Boss Battle #255 (BGM: 254) |
| `ev[21]` | `1 (Action / Talk)` | Target Inspected is obj[14] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Member Count == 255 | Open Dialogue Sub-Window (12); Start Boss Battle #255 (BGM: 254) |
| `ev[22]` | `1 (Action / Talk)` | Target Inspected is obj[14] AND Story Flag 143 (bit 2) CLEAR | Open Dialogue Sub-Window (7); Start Boss Battle #255 (BGM: 254) |
| `ev[23]` | `1 (Action / Talk)` | Target Inspected is obj[14] AND Story Flag 143 (bit 2) SET AND Story Flag 134 (bit 1) CLEAR | Open Dialogue Sub-Window (11); Start Boss Battle #255 (BGM: 254) |
| `ev[24]` | `1 (Action / Talk)` | Target Inspected is obj[14] AND Story Flag 134 (bit 1) SET | Open Dialogue Sub-Window (13); Start Boss Battle #255 (BGM: 254) |
| `ev[25]` | `1 (Action / Talk)` | Target Inspected is obj[15] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Formation Check | Open Dialogue Sub-Window (10); Launch Tactical War Battle (73); Branch on Choice (3, 15); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[26]` | `1 (Action / Talk)` | Target Inspected is obj[15] AND Condition Check #40 AND Always Passes (Unconditional) AND Party Member Count == 255 | Open Dialogue Sub-Window (12); Launch Tactical War Battle (73); Branch on Choice (3, 15); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[27]` | `1 (Action / Talk)` | Target Inspected is obj[15] AND Story Flag 143 (bit 2) CLEAR | Open Dialogue Sub-Window (7); Launch Tactical War Battle (73); Branch on Choice (3, 15); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[28]` | `1 (Action / Talk)` | Target Inspected is obj[15] AND Story Flag 143 (bit 2) SET AND Story Flag 134 (bit 1) CLEAR | Open Dialogue Sub-Window (11); Launch Tactical War Battle (73); Branch on Choice (3, 15); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[29]` | `1 (Action / Talk)` | Target Inspected is obj[15] AND Story Flag 134 (bit 1) SET | Open Dialogue Sub-Window (13); Launch Tactical War Battle (73); Branch on Choice (3, 15); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[30]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Open Dialogue Sub-Window (8); Execute Choice Result (255) |
| `ev[31]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Open Dialogue Sub-Window (8); Set Story Flag (255, 254) |
| `ev[32]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Open Dialogue Sub-Window (8); Open Dialogue Sub-Window (255) |
| `ev[33]` | `1 (Action / Talk)` | Target Inspected is obj[19] | Open Dialogue Sub-Window (8); Close Dialogue Sub-Window (255) |
| `ev[34]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Turn obj[8] facing South (Down); Warp Town -> Area 0 Map 1 Submap 3 at (8,3); Reset Camera Tracking (0); Clear Story Milestone Flag 31 (mask 8); Warp Town -> Area 6 Map 7 Submap 42 at (2,12); Engine Action #6 |
| `ev[35]` | `1 (Action / Talk)` | Player within Box [208..212, 2..99] AND Condition Check #105 | Display Dialogue Box [Bank: 0, MsgID: 66]; Engine Action #62 |

---



## Location Map: `vh07`

- **Master Map Container**: `vh07.json`
- **Submap Layer Files**: Embedded in master
- **Collision Grid Files**: None
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 1

### Submap Layer `vh07_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `28` Objects | **Script Count (`evkaz`)**: `11` Scripts

#### Complete Physical Entity Inventory (28 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 117** | `117` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Actor ID 122** | `122` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | World Device | **Mechanism (ano 28)** | `0` | `(90, 26)` | `0x0` | Frame 28 | Visible (1) | Passable (0) | 4 | 255 | 180 |
| `obj[03]` | NPC / Actor | **Actor ID 65107** | `65107` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[04]` | NPC / Actor | **Actor ID 65107** | `65107` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[05]` | NPC / Actor | **Actor ID 65107** | `65107` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[06]` | NPC / Actor | **Actor ID 65107** | `65107` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[07]` | NPC / Actor | **Actor ID 65107** | `65107` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[08]` | NPC / Actor | **Actor ID 65107** | `65107` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[09]` | NPC / Actor | **Actor ID 65107** | `65107` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[10]` | NPC / Actor | **Actor ID 65107** | `65107` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[11]` | NPC / Actor | **Actor ID 65107** | `65107` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[12]` | NPC / Actor | **Actor ID 65107** | `65107` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[13]` | NPC / Actor | **Actor ID 65147** | `65147` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[14]` | NPC / Actor | **Actor ID 65148** | `65148` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[15]` | World Device | **Mechanism (ano 1)** | `0` | `(58, 40)` | `0x0` | West (Left) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[16]` | Treasure Chest | **Closed Chest (Unopened)** | `0` | `(58, 40)` | `0x0` | Up (North) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[17]` | World Device | **Mechanism (ano 1)** | `0` | `(70, 78)` | `0x0` | West (Left) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[18]` | Treasure Chest | **Closed Chest (Unopened)** | `0` | `(70, 78)` | `0x0` | Up (North) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[19]` | World Device | **Mechanism (ano 1)** | `0` | `(98, 72)` | `0x0` | West (Left) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[20]` | Treasure Chest | **Closed Chest (Unopened)** | `0` | `(98, 72)` | `0x0` | Up (North) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[21]` | World Device | **Mechanism (ano 4)** | `0` | `(86, 75)` | `0x0` | Frame 4 | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[22]` | World Device | **Mechanism (ano 4)** | `0` | `(86, 75)` | `0x0` | Frame 4 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[23]` | World Device | **Mechanism (ano 7)** | `0` | `(54, 67)` | `0x0` | Frame 7 | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[24]` | World Device | **Mechanism (ano 8)** | `0` | `(54, 67)` | `0x0` | Frame 8 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[25]` | World Device | **Mechanism (ano 7)** | `0` | `(110, 77)` | `0x0` | Frame 7 | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[26]` | World Device | **Mechanism (ano 8)** | `0` | `(110, 77)` | `0x0` | Frame 8 | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[27]` | Rest Device / Fire | **Inn Bed / Recovery Device** | `0` | `(90, 30)` | `0x0` | Frame 29 | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 117)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Object 122)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(90, 26)` with state parameter `28`.
- **`obj[03]` (Object 65107)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Object 65107)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Object 65107)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[06]` (Object 65107)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[07]` (Object 65107)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[08]` (Object 65107)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[09]` (Object 65107)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[10]` (Object 65107)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[11]` (Object 65107)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[12]` (Object 65107)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[13]` (Object 65147)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[14]` (Object 65148)**: Positioned at tile `(0, 0)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[15]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(58, 40)` with state parameter `1`.
- **`obj[16]` (Treasure Chest)**: Placed at tile `(58, 40)`. Initial state is Closed (Unopened). Controlled by map loot bitflags.
- **`obj[17]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(70, 78)` with state parameter `1`.
- **`obj[18]` (Treasure Chest)**: Placed at tile `(70, 78)`. Initial state is Closed (Unopened). Controlled by map loot bitflags.
- **`obj[19]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(98, 72)` with state parameter `1`.
- **`obj[20]` (Treasure Chest)**: Placed at tile `(98, 72)`. Initial state is Closed (Unopened). Controlled by map loot bitflags.
- **`obj[21]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(86, 75)` with state parameter `4`.
- **`obj[22]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(86, 75)` with state parameter `4`.
- **`obj[23]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(54, 67)` with state parameter `7`.
- **`obj[24]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(54, 67)` with state parameter `8`.
- **`obj[25]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(110, 77)` with state parameter `7`.
- **`obj[26]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(110, 77)` with state parameter `8`.
- **`obj[27]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(90, 30)` with state parameter `29`.


#### Complete Bytecode Script Catalog (11 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 179 (bit 4) SET AND Story Flag 179 (bit 16) CLEAR | Make obj[3] Hidden (disp = 0); Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 10 Map 90 Submap 27 at (2,8); Open Shop Interface #30; Open Dialogue Message Window; Reset Camera Tracking (47) |
| `ev[01]` | `1 (Action / Talk)` | Story Flag 179 (bit 4) SET AND Story Flag 179 (bit 16) CLEAR | Jump to Bytecode Offset (2, 4); Return to Previous Memory Map (1); Engine Action #88; Engine Action #52; Warp Room -> Submap 4 at (1,0) facing 8; Set Entity Movement Speed (2, 5); Open Dialogue Message Window; Warp Room -> Submap 5 at (3,2) facing South (Down); Engine Action #5; Engine Action #6; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Engine Action #6; Warp to Castle HQ (0, 5, 6); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Engine Action #6; Warp Town -> Area 0 Map 5 Submap 6 at (0,0); Dismiss Emotion Bubble (255); Engine Action #5; Warp Room -> Submap 0 at (5,6) facing Up (North); Open Dialogue Message Window; Engine Action #5; Engine Action #6; Warp to Castle HQ (0, 5, 6); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Engine Action #6; Warp Town -> Area 0 Map 5 Submap 6 at (0,0); Engine Action #5; Engine Action #6; Warp Room -> Submap 30 at (255,254) facing 50; Make obj[3] Hidden (disp = 0); Warp Room -> Submap 3 at (0,2) facing 47; Close Dialogue Sub-Window (1); Open Dialogue Message Window; Animate Door Open; Jump to Bytecode Offset (7, 4); Set Combat Battle BGM (45); Set Object Direction (2, 10); Open Dialogue Message Window; Close Dialogue Sub-Window (8); Open Dialogue Message Window; Show Dialogue Portrait (101, 1, 33); Launch Tactical War Battle (1); Warp to Castle HQ (1, 2, 43); Reset Camera Tracking (6); Load Sound Bank into Memory (1, 1); Engine Action #9; Set Entity Movement Speed (3, 5); Warp Room -> Submap 15 at (0,0) facing 5; Dismiss Emotion Bubble (7); Warp Room -> Submap 255 at (254,5) facing South (Down); Warp Town -> Area 0 Map 5 Submap 15 at (0,0); Dismiss Emotion Bubble (255); Set Render Priority (pri) (8, 87); Fade In from Black (8); Walk obj[3] to (8,1); Open Shop Menu #4 (Type: 8); Close Dialogue Sub-Window (8); Open Dialogue Message Window; Dismiss Dialogue Portrait; Set Combat Battle BGM (20); Close Dialogue Sub-Window (1); Open Dialogue Message Window; Change Portrait Expression (5); Warp Room -> Submap 0 at (5,24) facing South (Down); Open Dialogue Message Window; Dismiss Emotion Bubble (73); Branch on Choice (40, 0); Open Dialogue Message Window; Warp Town -> Area 0 Map 18 Submap 0 at (19,72); Open Dialogue Message Window; Warp Room -> Submap 1 at (1,0) facing 5; Warp Room -> Submap 0 at (6,2) facing South (Down); Open Dialogue Message Window; Dismiss Emotion Bubble (72); Open Dialogue Message Window; Warp Room -> Submap 1 at (0,20) facing 5; Warp Room -> Submap 0 at (6,1) facing 7; Warp Room -> Submap 24 at (1,0) facing 21; Engine Action #5; Warp Room -> Submap 1 at (0,0) facing 30; Close Dialogue Sub-Window (8); Open Dialogue Message Window; Set Story Flag (3, 8); Open Dialogue Message Window; Set Combat Battle BGM (120); Engine Action #5; Reset Camera Tracking (3); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp Room -> Submap 30 at (24,8) facing South (Down); Open Dialogue Sub-Window (5); Warp Room -> Submap 1 at (30,24) facing West (Left); Open Dialogue Message Window; Close Dialogue Sub-Window (24); Reset Camera Tracking (0); Clear Dialogue Sub-Window; Load Sound Bank into Memory (1, 1); Warp to Castle HQ (73, 15, 24); Warp Room -> Submap 26 at (72,0) facing West (Left); Set Combat Battle BGM (20); Close Dialogue Sub-Window (8); Open Dialogue Message Window; Fade Out to Black (72); Warp Room -> Submap 1 at (5,1) facing 6; Warp Room -> Submap 72 at (0,1) facing 24; Warp Room -> Submap 28 at (72,1) facing 8; Pan Camera (5, 8, 4); Engine Action #6; Engine Action #6; Warp Room -> Submap 3 at (30,24) facing 8; Open Dialogue Message Window; Display Emotion Bubble (72, 1); Warp Room -> Submap 5 at (1,6) facing West (Left); Dismiss Emotion Bubble (24); Warp Room -> Submap 30 at (72,0) facing West (Left); Engine Action #5; Reset Camera Tracking (3); Warp Room -> Submap 4 at (30,72) facing South (Down); Reset Camera Tracking (24); Reset Camera Tracking (0); Warp Room -> Submap 73 at (20,40); Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 0 Map 32 Submap 0 at (33,41); Warp Town -> Area 0 Map 1 Submap 255 at (0,3); Warp Room -> Submap 24 at (1,0) facing 34; Engine Action #51; Warp Town -> Area 255 Map 1 Submap 24 at (8,0); Start Boss Battle #3 (BGM: 1); Warp to Castle HQ (24, 1, 0); Launch Tactical War Battle (255); Warp Town -> Area 39 Map 34 Submap 9 at (179,16); Set Special Scene BGM (1); Warp Map Transition (3, 0, 104, 100, 255) |
| `ev[02]` | `128 (Loop)` | Story Flag 179 (bit 4) SET AND Story Flag 179 (bit 16) CLEAR AND Inventory Holds Item #1 [Medicine] | Warp Room -> Submap 0 at (7,5); Toggle Random Encounters (1) |
| `ev[03]` | `2 (Map Init)` | Story Flag 39 (bit 2) SET | Make obj[2] Hidden (disp = 0); Place Scenery Structure (88); Return Warp to Castle Base (2, 14); Engine Action #87; Toggle Random Encounters (2); Show Dialogue Portrait (89, 37, 2); Dismiss Dialogue Portrait; Award Potch Currency (38,2); Change Portrait Expression (79); Open Save Crystal Menu (MSaveInit); Warp Town -> Area 18 Map 78 Submap 41 at (2,19); Engine Action #93; Toggle Random Encounters (2); Branch on Choice (73, 27); Warp Town -> Area 21 Map 67 Submap 37 at (2,22); Open Shop Interface #41; Warp to Castle HQ (13, 1, 3); Animate Door Open; Warp Room -> Submap 15 at (1,3) facing 16; Warp Room -> Submap 17 at (1,3) facing 18; Warp Room -> Submap 19 at (3,3) facing 20; Open Dialogue Message Window; Warp to Castle HQ (21, 3, 3); Set Story Flag (3, 0); Place Scenery Structure (0); Animate Door Open; Open Dialogue Message Window; Show Dialogue Portrait (0, 16, 0); Change Portrait Expression (0); Display Speaker Name Box (0); Display Choice Selection (0, 20); Open Dialogue Message Window; Execute Choice Result (0); Set Story Flag (1, 0); Teleport obj[255] to (254,204) |
| `ev[04]` | `2 (Map Init)` | Story Flag 39 (bit 2) SET AND Condition Check #24 AND Condition Check #117 AND Temp Event Flag #255 SET | Make obj[2] Hidden (disp = 0); Reset Camera Tracking (82); Fade In from Black (3); Reset Camera Tracking (0); Open Dialogue Message Window; Reset Camera Tracking (47) |
| `ev[05]` | `2 (Map Init)` | Story Flag 39 (bit 2) SET AND Condition Check #23 AND Condition Check #117 AND Temp Event Flag #255 SET | Make obj[2] Hidden (disp = 0); Engine Action #9; Remove Item from Inventory (26, 3); Engine Action #9; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #9; Teleport obj[255] to (254,204) |
| `ev[06]` | `128 (Loop)` | Story Flag 39 (bit 2) SET AND Temp Event Flag #1 SET | Engine Action #93; Open Dialogue Message Window; Reset Camera Tracking (30); Engine Action #93; Open Dialogue Message Window; Engine Action #9; Dismiss Emotion Bubble (36); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[07]` | `1 (Action / Talk)` | Story Flag 39 (bit 2) SET | Set Combat Battle BGM (20); Close Dialogue Window; Warp Room -> Submap 120 at (73,240) facing 11; Warp Town -> Area 2 Map 120 Submap 69 at (3,13); Engine Action #5; Exit to World Map (5, 0, 96); Engine Action #94 |
| `ev[08]` | `128 (Loop)` | Story Flag 39 (bit 2) SET | Set Combat Battle BGM (50); Engine Action #5; Place Scenery Structure (4); Engine Action #5; Warp Room -> Submap 5 at (3,7) facing Up (North); Dismiss Emotion Bubble (73); Engine Action #240; Engine Action #5; Place Scenery Structure (4); Engine Action #5; Warp Room -> Submap 5 at (1,7) facing Up (North); Dismiss Emotion Bubble (73); Make obj[255] Visible (disp = 1) |
| `ev[09]` | `128 (Loop)` | Story Flag 39 (bit 2) SET | Set Combat Battle BGM (20); Engine Action #5; Dismiss Dialogue Portrait; Exit to World Map (5, 1, 2); Exit to World Map (4, 7, 2); Dismiss Emotion Bubble (73); Engine Action #220; Engine Action #5; Dismiss Dialogue Portrait; Exit to World Map (5, 1, 2); Engine Action #5; Engine Action #5; Pan Camera (2, 30, 73); Make obj[255] Visible (disp = 1) |
| `ev[10]` | `128 (Loop)` | Story Flag 39 (bit 2) SET | Set Combat Battle BGM (24); Engine Action #5; Change Portrait Expression (4); Engine Action #5; Warp Room -> Submap 7 at (2,30) facing 73; Engine Action #225; Engine Action #5; Change Portrait Expression (4); Engine Action #5; Warp Room -> Submap 4 at (4,7) facing Up (North); Dismiss Emotion Bubble (73); Set Render Priority (pri) (255, 254) |

---



## Location Map: `vh09`

- **Master Map Container**: `vh09.json`
- **Submap Layer Files**: Embedded in master
- **Collision Grid Files**: vh09_map_00.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 1

### Submap Layer `vh09_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `1` Objects | **Script Count (`evkaz`)**: `5` Scripts

#### Complete Physical Entity Inventory (1 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Nanami** | `7` | `(38, 48)` | `0x0` | East (Right) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Nanami)**: Positioned at tile `(38, 48)`, facing East (Right). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.


#### Complete Bytecode Script Catalog (5 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Always Passes (Unconditional) | Warp to Castle HQ (0, 2, 255) |
| `ev[01]` | `128 (Loop)` | Inventory Holds Item #16 [Revenge Earth] | Set Object Direction (0, 0); Full Rest & Healing (Restore HP/MP); Jump to Bytecode Offset (1, 0); Toggle Random Encounters (16) |
| `ev[02]` | `128 (Loop)` | Inventory Holds Item #32 [Drinking Set] | Set Object Direction (0, 0); Engine Action #137; Toggle Random Encounters (32) |
| `ev[03]` | `128 (Loop)` | Inventory Holds Item #64 [Recipe #33] | Warp Room -> Submap 0 at (7,2); Toggle Random Encounters (64) |
| `ev[04]` | `1 (Action / Talk)` | Always Passes (Unconditional) | Set Combat Battle BGM (30); Close Dialogue Window; Warp Room -> Submap 120 at (73,90) facing 24; Reset Camera Tracking (0); Branch on Choice (73, 20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 0 Map 21 Submap 0 at (22,101); Engine Action #9; Reset Camera Tracking (36); Dismiss Dialogue Portrait; Award Potch Loot (+512 Potch); Warp Room -> Submap 0 at (24,8) facing South (Down); Open Dialogue Sub-Window (51); Warp Town -> Area 255 Map 1 Submap 24 at (8,0); Close Dialogue Sub-Window (255); Warp Town -> Area 73 Map 150 Submap 77 at (8,2); Warp to Castle HQ (30, 73, 30); Close Dialogue Sub-Window (8); Open Dialogue Message Window; Clear Dialogue Sub-Window; Jump to Bytecode Offset (9, 8); Set Combat Battle BGM (60); Wait for Audio / Window Sync (3); Launch Tactical War Battle (32); Close Dialogue Window; Warp Town -> Area 2 Map 120 Submap 36 at (64,73); Dismiss Emotion Bubble (3); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #99; Open Dialogue Message Window; Warp Town -> Area 99 Map 0 Submap 4 at (102,1); Warp Map Transition (3, 1, 131, 190, 58) |

---


