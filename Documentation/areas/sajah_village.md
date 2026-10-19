# Suikoden II Geographic Area Catalog: Sajah Frontier Village

**Geographic Scope & Role**: Remote northern border village; rare magic rune sage shop, Level 16 ultimate blacksmith forge, and quiet frontier cabins.

**Regional Category**: Region `VJ` | **Master Maps Included**: `vj17`

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

## Location Map: `vj17`

- **Master Map Container**: `vj17.json`
- **Submap Layer Files**: vj17_01.json, vj17_02.json, vj17_03.json, vj17_09.json, vj17_15.json
- **Collision Grid Files**: vj17_map_00.json, vj17_map_01.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 2

### Submap Layer `vj17_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `36` Objects | **Script Count (`evkaz`)**: `51` Scripts

#### Complete Physical Entity Inventory (36 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(76, 25)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[01]` | World Device | **Mechanism (ano 16)** | `0` | `(74, 26)` | `0x0` | Frame 16 | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Actor ID 171** | `171` | `(99, 53)` | `0x0` | East (Right) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | Prop / Scenery | **Prop ID 33963** | `33963` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | Prop / Scenery | **Prop ID 34219** | `34219` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | Prop / Scenery | **Prop ID 34475** | `34475` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | Prop / Scenery | **Prop ID 33963** | `33963` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Prop / Scenery | **Prop ID 34219** | `34219` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Prop / Scenery | **Prop ID 34475** | `34475` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Prop / Scenery | **Prop ID 33963** | `33963` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Prop / Scenery | **Prop ID 34475** | `34475` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Prop / Scenery | **Prop ID 33963** | `33963` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | NPC / Actor | **Actor ID 65039** | `65039` | `(138, 54)` | `1x1` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[13]` | NPC / Actor | **Actor ID 65035** | `65035` | `(81, 51)` | `1x1` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[14]` | NPC / Actor | **Actor ID 65074** | `65074` | `(46, 49)` | `1x1` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[15]` | NPC / Actor | **Actor ID 65040** | `65040` | `(49, 53)` | `1x1` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[16]` | NPC / Actor | **Actor ID 65031** | `65031` | `(78, 30)` | `1x1` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[17]` | NPC / Actor | **Actor ID 64783** | `64783` | `(89, 26)` | `2x2` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[18]` | NPC / Actor | **Actor ID 64957** | `64957` | `(86, 27)` | `1x1` | West (Left) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[19]` | NPC / Actor | **Actor ID 64957** | `64957` | `(88, 29)` | `1x1` | Up (North) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[20]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(142, 47)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[21]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(137, 46)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[22]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(120, 47)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[23]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(122, 47)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[24]` | Trigger / Hitbox | **Hitbox Zone (3x1)** | `0` | `(110, 47)` | `2x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[25]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(107, 45)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[26]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(105, 45)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[27]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(95, 44)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[28]` | Trigger / Hitbox | **Hitbox Zone (5x3)** | `0` | `(70, 49)` | `4x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[29]` | Trigger / Hitbox | **Hitbox Zone (5x3)** | `0` | `(51, 54)` | `4x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[30]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(74, 48)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[31]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(54, 50)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[32]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(69, 48)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[33]` | Trigger / Hitbox | **Hitbox Zone (5x2)** | `0` | `(64, 49)` | `4x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[34]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(49, 45)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[35]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(49, 43)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(76, 25)` to `(79, 26)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[01]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(74, 26)` with state parameter `16`.
- **`obj[02]` (Object 171)**: Positioned at tile `(99, 53)`, facing East (Right). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Prop: Object 33963)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[04]` (Prop: Object 34219)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[05]` (Prop: Object 34475)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[06]` (Prop: Object 33963)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[07]` (Prop: Object 34219)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[08]` (Prop: Object 34475)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[09]` (Prop: Object 33963)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[10]` (Prop: Object 34475)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[11]` (Prop: Object 33963)**: Environmental world dressing prop placed at tile `(0, 0)`. Solid collision is set to `0`.
- **`obj[12]` (Object 65039)**: Positioned at tile `(138, 54)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[13]` (Object 65035)**: Positioned at tile `(81, 51)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[14]` (Object 65074)**: Positioned at tile `(46, 49)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[15]` (Object 65040)**: Positioned at tile `(49, 53)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[16]` (Object 65031)**: Positioned at tile `(78, 30)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[17]` (Object 64783)**: Positioned at tile `(89, 26)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[18]` (Object 64957)**: Positioned at tile `(86, 27)`, facing West (Left). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[19]` (Object 64957)**: Positioned at tile `(88, 29)`, facing Up (North). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[20]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(142, 47)`. Evaluates player step-on or Confirm button inputs.
- **`obj[21]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(137, 46)` to `(138, 47)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[22]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(120, 47)` to `(121, 47)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[23]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(122, 47)` to `(123, 47)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[24]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `1` tiles high from `(110, 47)` to `(112, 47)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[25]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(107, 45)`. Evaluates player step-on or Confirm button inputs.
- **`obj[26]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(105, 45)`. Evaluates player step-on or Confirm button inputs.
- **`obj[27]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(95, 44)` to `(97, 45)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[28]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `3` tiles high from `(70, 49)` to `(74, 51)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[29]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `3` tiles high from `(51, 54)` to `(55, 56)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[30]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(74, 48)` to `(75, 49)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[31]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(54, 50)` to `(56, 51)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[32]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(69, 48)`. Evaluates player step-on or Confirm button inputs.
- **`obj[33]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `2` tiles high from `(64, 49)` to `(68, 50)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[34]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(49, 45)` to `(50, 46)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[35]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(49, 43)` to `(50, 44)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (51 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `128 (Loop)` | Player within Box [135..158, 2..49] AND Condition Check #62 | Warp Room -> Submap 2 at (12,9) |
| `ev[01]` | `1 (Action / Talk)` | Player within Box [158..160, 2..36] AND Condition Check #62 AND Story Flag 3 (mask 255) SET | Warp Map Transition (0, 0, 68, 23, 255) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [129..131, 2..46] AND Condition Check #47 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 49]; Engine Action #107 |
| `ev[03]` | `1 (Action / Talk)` | Player within Box [101..103, 2..42] AND Condition Check #43 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 97]; Engine Action #53 |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [61..63, 2..46] AND Condition Check #47 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 47]; Toggle Random Encounters (255) |
| `ev[05]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[20] | Open Dialogue Sub-Window (3); Open Dialogue Message Window |
| `ev[06]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[21] | Open Dialogue Sub-Window (3); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[07]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[22] | Open Dialogue Sub-Window (3); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[08]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[23] | Open Dialogue Sub-Window (3); Warp to Castle HQ (255, 254, 204) |
| `ev[09]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[24] | Open Dialogue Sub-Window (3); Exit to World Map (255, 254, 204) |
| `ev[10]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[25] | Open Dialogue Sub-Window (3); Screen Fade Transition (255, 254, 204) |
| `ev[11]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[26] | Open Dialogue Sub-Window (3); Close Dialogue Window |
| `ev[12]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[27] | Open Dialogue Sub-Window (3); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[13]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[20] | Open Dialogue Sub-Window (5); Open Dialogue Message Window |
| `ev[14]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[21] | Open Dialogue Sub-Window (5); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[15]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[22] | Open Dialogue Sub-Window (5); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[16]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[23] | Open Dialogue Sub-Window (5); Warp to Castle HQ (255, 254, 204) |
| `ev[17]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[24] | Open Dialogue Sub-Window (5); Exit to World Map (255, 254, 204) |
| `ev[18]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[25] | Open Dialogue Sub-Window (5); Screen Fade Transition (255, 254, 204) |
| `ev[19]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[26] | Open Dialogue Sub-Window (5); Close Dialogue Window |
| `ev[20]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[27] | Open Dialogue Sub-Window (5); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[21]` | `1 (Action / Talk)` | Target Inspected is obj[28] | Open Dialogue Sub-Window (2); Open Dialogue Message Window |
| `ev[22]` | `1 (Action / Talk)` | Target Inspected is obj[29] | Open Dialogue Sub-Window (2); Warp Room -> Submap 254 at (204,204) facing 204 |
| `ev[23]` | `1 (Action / Talk)` | Target Inspected is obj[33] | Open Dialogue Sub-Window (2); Warp Town -> Area 255 Map 254 Submap 204 at (204,204) |
| `ev[24]` | `1 (Action / Talk)` | Target Inspected is obj[34] | Open Dialogue Sub-Window (2); Warp to Castle HQ (255, 254, 204) |
| `ev[25]` | `1 (Action / Talk)` | Target Inspected is obj[30] | Open Dialogue Sub-Window (2); Exit to World Map (255, 254, 204) |
| `ev[26]` | `1 (Action / Talk)` | Target Inspected is obj[31] | Open Dialogue Sub-Window (2); Engine Action #5 |
| `ev[27]` | `1 (Action / Talk)` | Target Inspected is obj[32] | Open Dialogue Sub-Window (2); Engine Action #6 |
| `ev[28]` | `1 (Action / Talk)` | Target Inspected is obj[36] | Open Dialogue Sub-Window (2); Pan Camera (255, 254, 204) |
| `ev[29]` | `1 (Action / Talk)` | Target Inspected is obj[37] | Open Dialogue Sub-Window (2); Reset Camera Tracking (255) |
| `ev[30]` | `1 (Action / Talk)` | Target Inspected is obj[38] | Open Dialogue Sub-Window (2); Engine Action #9 |
| `ev[31]` | `1 (Action / Talk)` | Target Inspected is obj[39] | Open Dialogue Sub-Window (2); Screen Fade Transition (255, 254, 204) |
| `ev[32]` | `1 (Action / Talk)` | Target Inspected is obj[40] | Open Dialogue Sub-Window (2); Close Dialogue Window |
| `ev[33]` | `1 (Action / Talk)` | Target Inspected is obj[41] | Open Dialogue Sub-Window (2); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[34]` | `1 (Action / Talk)` | Target Inspected is obj[35] | Open Dialogue Sub-Window (2); Place Scenery Structure (255) |
| `ev[35]` | `1 (Action / Talk)` | Target Inspected is obj[43] | Open Dialogue Sub-Window (2); Show Dialogue Portrait (255, 254, 204) |
| `ev[36]` | `1 (Action / Talk)` | Target Inspected is obj[42] | Open Dialogue Sub-Window (2); Animate Door Open |
| `ev[37]` | `2 (Map Init)` | Story Flag 94 (bit 64) SET AND Story Flag 94 (bit 128) CLEAR AND Story Flag 89 (bit 128) CLEAR | Dismiss Emotion Bubble (1); Warp Town -> Area 20 Map 0 Submap 41 at (2,0); Warp Room -> Submap 0 at (9,89) facing 128; Warp Room -> Submap 10 at (255,254) facing 255 |
| `ev[38]` | `1 (Action / Talk)` | Story Flag 94 (bit 64) SET AND Story Flag 94 (bit 128) CLEAR AND Story Flag 89 (bit 128) CLEAR AND Star of Destiny #0 Recruited AND Inventory Holds Item #5 AND Story Flag 255 (mask 254) CLEAR | Close Dialogue Sub-Window (10); Exit to World Map (0, 255, 254) |
| `ev[39]` | `1 (Action / Talk)` | Story Flag 94 (bit 64) SET AND Story Flag 94 (bit 128) CLEAR AND Story Flag 89 (bit 128) CLEAR AND Star of Destiny #1 Recruited AND Inventory Holds Item #255 | Launch Tactical War Battle (32); Turn obj[0] facing 10; Warp to Castle HQ (6, 1, 2); Reset Camera Tracking (3); Open Dialogue Message Window; Warp Town -> Area 33 Map 1 Submap 6 at (0,1); Engine Action #5; Warp Room -> Submap 4 at (2,0) facing 30; Set Combat Battle BGM (30); Close Dialogue Sub-Window (10); Exit to World Map (1, 24, 1); Exit to World Map (2, 24, 10); Exit to World Map (3, 24, 1); Exit to World Map (4, 46, 106); Warp Room -> Submap 89 at (17,2) facing South (Down); Open Dialogue Message Window; Change Portrait Expression (1); Warp Room -> Submap 73 at (60,101) facing South (Down); Engine Action #180; Set Combat Battle BGM (50); Jump to Bytecode Offset (0, 181); Engine Action #89; Change Portrait Expression (5); Engine Action #89; Change Portrait Expression (5); Make obj[106] Hidden (disp = 0); Warp Room -> Submap 106 at (1,14) facing 89; Display Choice Selection (2, 2); Open Dialogue Message Window; Display Choice Selection (89, 14); Warp Town -> Area 1 Map 0 Submap 14 at (1,17); Teleport obj[89] to (14,5); Engine Action #89; Animate Door Open; Engine Action #5; Make obj[0] Hidden (disp = 0); Warp Room -> Submap 14 at (47,5) facing West (Left); Warp Room -> Submap 2 at (0,30) facing 24; Screen Fade Transition (4, 5, 56); Screen Fade Transition (1, 2, 4); Warp Room -> Submap 8 at (46,106) facing 10; Close Dialogue Window; Engine Action #89; Close Dialogue Window; Warp Town -> Area 3 Map 0 Submap 11 at (1,10); Teleport obj[89] to (11,5); Engine Action #89; Close Dialogue Window; Engine Action #5; Engine Action #89; Close Dialogue Window; Warp Town -> Area 4 Map 24 Submap 10 at (4,6); Set Combat Battle BGM (60); Make obj[89] Hidden (disp = 0); Close Dialogue Window; Warp Town -> Area 5 Map 1 Submap 1 at (47,89); Close Dialogue Window; Engine Action #5; Engine Action #89; Close Dialogue Window; Engine Action #5; Make obj[89] Hidden (disp = 0); Close Dialogue Window; Warp Town -> Area 6 Map 0 Submap 1 at (47,24); Screen Fade Transition (4, 7, 89); Close Dialogue Window; Warp Town -> Area 7 Map 49 Submap 3 at (28,3); Warp to Castle HQ (3, 255, 254); Engine Action #5; Warp Room -> Submap 4 at (3,14) facing Up (North); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Open Dialogue Message Window; Exit to World Map (3, 1, 2); Warp to Castle HQ (5, 0, 0); Dismiss Emotion Bubble (255); Walk obj[24] to (1,4); Reset Camera Tracking (46); Set Character Quest Milestone (11, 12); Engine Action #89; Display Dialogue Box [Bank: 2, MsgID: 0]; Warp Room -> Submap 0 at (12,47) facing 101; Open Dialogue Message Window; Engine Action #179; Close Dialogue Sub-Window (10); Exit to World Map (9, 46, 106); Warp Room -> Submap 89 at (15,2) facing 17; Warp Room -> Submap 0 at (15,47) facing 101; Open Dialogue Message Window; Engine Action #179; Close Dialogue Sub-Window (1); Exit to World Map (10, 73, 60); Make obj[89] Hidden (disp = 0); Display Dialogue Box [Bank: 2, MsgID: 1]; Engine Action #89; Show Dialogue Portrait (2, 18, 47); Engine Action #89; Display Dialogue Box [Bank: 5, MsgID: 89]; Display Dialogue Box [Bank: 5, MsgID: 89]; Show Dialogue Portrait (5, 89, 15); Engine Action #5; Make obj[89] Hidden (disp = 0); Display Dialogue Box [Bank: 2, MsgID: 2]; Engine Action #89; Show Dialogue Portrait (2, 19, 47); Engine Action #89; Display Dialogue Box [Bank: 5, MsgID: 89]; Display Dialogue Box [Bank: 5, MsgID: 89]; Show Dialogue Portrait (5, 89, 15); Engine Action #5; Close Dialogue Sub-Window (10); Exit to World Map (11, 46, 89); Display Dialogue Box [Bank: 2, MsgID: 3]; Engine Action #89; Show Dialogue Portrait (2, 20, 47); Engine Action #89; Display Dialogue Box [Bank: 5, MsgID: 89]; Display Dialogue Box [Bank: 5, MsgID: 89]; Show Dialogue Portrait (5, 89, 15); Engine Action #5; Make obj[89] Hidden (disp = 0); Display Dialogue Box [Bank: 2, MsgID: 4]; Engine Action #89; Show Dialogue Portrait (2, 21, 47); Engine Action #89; Display Dialogue Box [Bank: 5, MsgID: 89]; Display Dialogue Box [Bank: 5, MsgID: 89]; Show Dialogue Portrait (5, 89, 15); Engine Action #5; Close Dialogue Sub-Window (1); Exit to World Map (12, 46, 89); Display Dialogue Box [Bank: 2, MsgID: 5]; Engine Action #89; Show Dialogue Portrait (2, 22, 47); Engine Action #89; Display Dialogue Box [Bank: 5, MsgID: 89]; Display Dialogue Box [Bank: 5, MsgID: 89]; Show Dialogue Portrait (5, 89, 15); Engine Action #5; Make obj[89] Hidden (disp = 0); Display Dialogue Box [Bank: 2, MsgID: 6]; Engine Action #89; Show Dialogue Portrait (2, 23, 47); Engine Action #89; Display Dialogue Box [Bank: 5, MsgID: 89]; Display Dialogue Box [Bank: 5, MsgID: 89]; Show Dialogue Portrait (5, 89, 15); Engine Action #5; Close Dialogue Sub-Window (10); Exit to World Map (13, 46, 89); Display Dialogue Box [Bank: 2, MsgID: 7]; Engine Action #89; Show Dialogue Portrait (2, 24, 47); Engine Action #89; Display Dialogue Box [Bank: 5, MsgID: 89]; Display Dialogue Box [Bank: 5, MsgID: 89]; Show Dialogue Portrait (5, 89, 15); Engine Action #5; Make obj[89] Hidden (disp = 0); Display Dialogue Box [Bank: 2, MsgID: 8]; Engine Action #89; Show Dialogue Portrait (2, 25, 47); Engine Action #89; Display Dialogue Box [Bank: 5, MsgID: 89]; Display Dialogue Box [Bank: 5, MsgID: 89]; Show Dialogue Portrait (5, 89, 15); Engine Action #5; Close Dialogue Sub-Window (1); Exit to World Map (14, 46, 89); Display Dialogue Box [Bank: 2, MsgID: 9]; Engine Action #89; Show Dialogue Portrait (2, 26, 47); Engine Action #89; Display Dialogue Box [Bank: 5, MsgID: 89]; Display Dialogue Box [Bank: 5, MsgID: 89]; Show Dialogue Portrait (5, 89, 15); Engine Action #5; Make obj[89] Hidden (disp = 0); Display Dialogue Box [Bank: 2, MsgID: 10]; Engine Action #89; Show Dialogue Portrait (2, 27, 47); Engine Action #89; Display Dialogue Box [Bank: 5, MsgID: 89]; Display Dialogue Box [Bank: 5, MsgID: 89]; Show Dialogue Portrait (5, 89, 15); Engine Action #5; Close Dialogue Sub-Window (10); Exit to World Map (15, 46, 89); Display Dialogue Box [Bank: 2, MsgID: 11]; Engine Action #89; Show Dialogue Portrait (2, 28, 47); Engine Action #89; Display Dialogue Box [Bank: 5, MsgID: 89]; Display Dialogue Box [Bank: 5, MsgID: 89]; Show Dialogue Portrait (5, 89, 15); Engine Action #5; Close Dialogue Sub-Window (1); Exit to World Map (16, 46, 89); Display Dialogue Box [Bank: 2, MsgID: 12]; Engine Action #89; Show Dialogue Portrait (2, 29, 47); Engine Action #89; Display Dialogue Box [Bank: 5, MsgID: 89]; Display Dialogue Box [Bank: 5, MsgID: 89]; Show Dialogue Portrait (5, 89, 15); Engine Action #5; Close Dialogue Sub-Window (10); Exit to World Map (17, 46, 89); Display Dialogue Box [Bank: 2, MsgID: 13]; Engine Action #89; Show Dialogue Portrait (2, 30, 47); Engine Action #89; Display Dialogue Box [Bank: 5, MsgID: 89]; Display Dialogue Box [Bank: 5, MsgID: 89]; Show Dialogue Portrait (5, 89, 15); Engine Action #5; Close Dialogue Sub-Window (1); Exit to World Map (18, 73, 60); Make obj[89] Hidden (disp = 0); Display Dialogue Box [Bank: 2, MsgID: 14]; Engine Action #89; Show Dialogue Portrait (2, 31, 47); Engine Action #89; Display Dialogue Box [Bank: 5, MsgID: 89]; Display Dialogue Box [Bank: 5, MsgID: 89]; Show Dialogue Portrait (5, 89, 15); Engine Action #5; Dismiss Emotion Bubble (2); Exit to World Map (10, 4, 19); Engine Action #6; Dismiss Emotion Bubble (2); Exit to World Map (1, 4, 20); Engine Action #6; Set Combat Battle BGM (10); Make obj[89] Hidden (disp = 0); Show Dialogue Portrait (2, 32, 89); Display Dialogue Box [Bank: 2, MsgID: 15]; Warp to Castle HQ (0, 2, 47); Jump to Bytecode Offset (4, 20); Set Combat Battle BGM (20); Jump to Bytecode Offset (0, 209); Launch Tactical War Battle (128); Engine Action #89; Display Dialogue Box [Bank: 5, MsgID: 89]; Display Dialogue Box [Bank: 5, MsgID: 89]; Show Dialogue Portrait (5, 89, 15); Engine Action #5; Make obj[89] Hidden (disp = 0); Show Dialogue Portrait (2, 33, 89); Display Dialogue Box [Bank: 2, MsgID: 16]; Teleport obj[54] to (0,128); Make obj[89] Hidden (disp = 0); Place Scenery Structure (2); Warp Room -> Submap 12 at (13,2) facing 10; Clear Story Milestone Flag 55 (mask 0); Place Scenery Structure (1); Display Dialogue Box [Bank: 47, MsgID: 24]; Screen Fade Transition (4, 21, 89); Show Dialogue Portrait (2, 34, 89); Show Dialogue Portrait (5, 89, 15); Engine Action #5; Make obj[0] Hidden (disp = 0); Warp Room -> Submap 15 at (47,24) facing West (Left); Exit to World Map (22, 89, 13); Warp Town -> Area 2 Map 89 Submap 13 at (5,89); Place Scenery Structure (5); Engine Action #89; Place Scenery Structure (2); Warp to Castle HQ (24, 10, 4); Open Dialogue Sub-Window (73); Screen Fade Transition (89, 13, 2); Exit to World Map (89, 13, 5); Engine Action #89; Place Scenery Structure (5); Engine Action #89; Place Scenery Structure (2); Engine Action #5; Close Dialogue Sub-Window (10); Exit to World Map (24, 24, 1); Exit to World Map (25, 89, 13); Warp Town -> Area 3 Map 24 Submap 10 at (4,26); Engine Action #5; Warp Room -> Submap 1 at (30,24) facing West (Left); Exit to World Map (27, 89, 13); Warp Town -> Area 4 Map 89 Submap 13 at (5,89); Place Scenery Structure (5); Engine Action #89; Place Scenery Structure (2); Engine Action #5; Close Dialogue Sub-Window (10); Exit to World Map (28, 24, 1); Exit to World Map (29, 36, 16); Close Dialogue Sub-Window (10); Exit to World Map (30, 56, 1); Display Choice Selection (2, 1); Open Dialogue Message Window; Warp Room -> Submap 46 at (106,19) facing 18; Engine Action #89; Display Speaker Name Box (2); Close Dialogue Sub-Window (0); Display Speaker Name Box (1); Warp Room -> Submap 19 at (47,89) facing 18; Engine Action #5; Engine Action #89; Display Speaker Name Box (5); Make obj[106] Hidden (disp = 0); Display Choice Selection (16, 89); Dismiss Dialogue Portrait; Warp Town -> Area 25 Map 106 Submap 1 at (16,1); Display Speaker Name Box (0); Dismiss Dialogue Portrait; Teleport obj[73] to (10,89); Dismiss Dialogue Portrait; Warp Town -> Area 26 Map 90 Submap 16 at (18,6); Dismiss Emotion Bubble (46); Engine Action #89; Place Scenery Structure (2); Reset Camera Tracking (89); Dismiss Dialogue Portrait; Warp Town -> Area 30 Map 47 Submap 89 at (13,5); Engine Action #89; Place Scenery Structure (5); Make obj[89] Hidden (disp = 0); Place Scenery Structure (2); Engine Action #9; Engine Action #89; Dismiss Dialogue Portrait; Warp Town -> Area 21 Map 47 Submap 90 at (16,4); Warp to Castle HQ (16, 2, 30); Make obj[106] Hidden (disp = 0); Dismiss Dialogue Portrait; Warp Room -> Submap 1 at (1,0) facing West (Left); Warp Room -> Submap 47 at (24,10) facing 4; Warp Room -> Submap 24 at (1,4); Warp Map Transition (89, 13, 2, 10, 24); Screen Fade Transition (4, 33, 24); Warp Room -> Submap 34 at (36,1) facing 24; Screen Fade Transition (4, 35, 24); Warp Room -> Submap 36 at (73,90) facing 89; Place Scenery Structure (2); Place Scenery Structure (36); Warp Town -> Area 24 Map 10 Submap 4 at (37,24); Warp Room -> Submap 38 at (89,13) facing Up (North); Animate Door Open; Engine Action #89; Place Scenery Structure (5); Engine Action #89; Place Scenery Structure (5); Engine Action #89; Place Scenery Structure (2); Show Dialogue Portrait (101, 4, 20); Engine Action #89; Place Scenery Structure (5); Engine Action #89; Place Scenery Structure (5); Engine Action #89; Place Scenery Structure (2); Dismiss Dialogue Portrait; Set Combat Battle BGM (30); Engine Action #89; Place Scenery Structure (2); Change Portrait Expression (89); Place Scenery Structure (5); Engine Action #89; Place Scenery Structure (5); Engine Action #89; Place Scenery Structure (2); Display Dialogue Box [Bank: 24, MsgID: 10]; Exit to World Map (39, 46, 89); Dismiss Dialogue Portrait; Warp Town -> Area 21 Map 0 Submap 16 at (1,1); Teleport obj[90] to (16,4); Exit to World Map (17, 2, 30); Make obj[106] Hidden (disp = 0); Dismiss Dialogue Portrait; Warp Room -> Submap 1 at (1,16) facing 47; Close Dialogue Sub-Window (10); Exit to World Map (40, 46, 89); Dismiss Dialogue Portrait; Warp Town -> Area 28 Map 0 Submap 16 at (1,1); Teleport obj[36] to (4,24); Warp Room -> Submap 41 at (89,13) facing Up (North); Place Scenery Structure (36); Reset Camera Tracking (24); Screen Fade Transition (4, 42, 11); Warp Town -> Area 2 Map 120 Submap 73 at (60,46); Warp Town -> Area 0 Map 106 Submap 53 at (2,1); Mark NPC Talk Interaction Complete (Flag #53); Warp to Castle HQ (1, 2, 1); Dismiss Dialogue Portrait; Warp Room -> Submap 0 at (1,47) facing 11; Warp Room -> Submap 120 at (24,1) facing 4; Open Shop Menu #1 (Type: 69); Launch Tactical War Battle (64); Close Dialogue Window; Warp Town -> Area 2 Map 120 Submap 46 at (3,0); Warp Town -> Area 1 Map 1 Submap 34 at (45,47); Engine Action #9; Engine Action #89; Engine Action #128; Engine Action #9; Engine Action #94; Engine Action #128; Display Dialogue Box [Bank: 0, MsgID: 157]; Set Render Priority (pri) (255, 254) |
| `ev[40]` | `128 (Loop)` | Story Flag 94 (bit 64) SET AND Story Flag 94 (bit 128) CLEAR AND Story Flag 89 (bit 128) CLEAR AND Inventory Holds Item #1 | Engine Action #53; Warp Room -> Submap 1 at (89,13) facing Up (North); Close Dialogue Window; Engine Action #89; Place Scenery Structure (5); Engine Action #89; Place Scenery Structure (5); Engine Action #53; Warp Room -> Submap 2 at (89,13) facing Up (North); Display Dialogue Box [Bank: 89, MsgID: 13]; Engine Action #5; Engine Action #89; Place Scenery Structure (5); Make obj[37] Hidden (disp = 0); Warp Room -> Submap 255 at (1,10) facing 255; Warp Town -> Area 47 Map 255 Submap 254 at (204,204) |
| `ev[41]` | `128 (Loop)` | Story Flag 94 (bit 64) SET AND Story Flag 94 (bit 128) CLEAR AND Story Flag 89 (bit 128) CLEAR AND Inventory Holds Item #2 | Engine Action #53; Warp Room -> Submap 4 at (89,13) facing Up (North); Display Dialogue Box [Bank: 89, MsgID: 13]; Engine Action #5; Engine Action #89; Place Scenery Structure (5); Make obj[37] Hidden (disp = 0); Warp Town -> Area 10 Map 255 Submap 4 at (47,255) |
| `ev[42]` | `128 (Loop)` | Story Flag 94 (bit 64) SET AND Story Flag 94 (bit 128) CLEAR AND Story Flag 89 (bit 128) CLEAR AND Inventory Holds Item #4 | Engine Action #53; Warp Room -> Submap 8 at (89,16) facing Up (North); Display Emotion Bubble (89, 16); Engine Action #5; Engine Action #89; Dismiss Dialogue Portrait; Engine Action #5; Make obj[37] Hidden (disp = 0); Exit to World Map (10, 255, 8); Teleport obj[255] to (254,204) |
| `ev[43]` | `128 (Loop)` | Story Flag 94 (bit 64) SET AND Story Flag 94 (bit 128) CLEAR AND Story Flag 89 (bit 128) CLEAR AND Inventory Holds Item #8 | Engine Action #53; Warp Room -> Submap 16 at (89,13) facing Up (North); Display Speaker Name Box (89); Place Scenery Structure (5); Engine Action #89; Place Scenery Structure (5); Engine Action #89; Place Scenery Structure (2); Display Choice Selection (46, 37); Reset Camera Tracking (10); Dismiss Dialogue Portrait; Teleport obj[255] to (254,204) |
| `ev[44]` | `128 (Loop)` | Story Flag 94 (bit 64) SET AND Story Flag 94 (bit 128) CLEAR AND Story Flag 89 (bit 128) CLEAR AND Inventory Holds Item #16 | Engine Action #53; Warp Room -> Submap 32 at (89,13) facing Up (North); Engine Action #6; Engine Action #89; Place Scenery Structure (5); Engine Action #89; Place Scenery Structure (5); Engine Action #89; Place Scenery Structure (2); Pan Camera (46, 37, 16); Screen Fade Transition (255, 32, 47) |
| `ev[45]` | `128 (Loop)` | Story Flag 94 (bit 64) SET AND Story Flag 94 (bit 128) CLEAR AND Story Flag 89 (bit 128) CLEAR AND Inventory Holds Item #128 | Full Rest & Healing (Restore HP/MP); Warp Town -> Area 8 Map 0 Submap 5 at (6,37); Engine Action #128 |
| `ev[46]` | `128 (Loop)` | Story Flag 94 (bit 64) SET AND Story Flag 94 (bit 128) CLEAR AND Story Flag 89 (bit 128) CLEAR AND Inventory Holds Item #32 | Jump to Bytecode Offset (9, 8); Set Combat Battle BGM (60); Jump to Bytecode Offset (1, 2); Toggle Random Encounters (32) |
| `ev[47]` | `128 (Loop)` | Story Flag 94 (bit 64) SET AND Story Flag 94 (bit 128) CLEAR AND Story Flag 89 (bit 128) CLEAR AND Inventory Holds Item #128 | Jump to Bytecode Offset (9, 14); Set Object Direction (0, 1); Teleport Object to Coordinates (101, 1, 7) |
| `ev[48]` | `128 (Loop)` | Story Flag 94 (bit 64) SET AND Story Flag 94 (bit 128) CLEAR AND Story Flag 89 (bit 128) CLEAR AND Inventory Holds Item #64 | Jump to Bytecode Offset (9, 8); Set Combat Battle BGM (60); Set Object Direction (0, 1); Engine Action #150; Jump to Bytecode Offset (1, 0); Toggle Random Encounters (64) |
| `ev[49]` | `2 (Map Init)` | Story Flag 94 (bit 64) SET AND Story Flag 94 (bit 128) CLEAR AND Story Flag 89 (bit 128) CLEAR AND Star of Destiny #1 Recruited AND Inventory Holds Item #255 | Make obj[1] Hidden (disp = 0); Branch on Choice (1, 21); Warp Room (Submap); Close Dialogue Sub-Window (47) |
| `ev[50]` | `2 (Map Init)` | Story Flag 94 (bit 64) SET AND Story Flag 94 (bit 128) CLEAR AND Story Flag 89 (bit 128) CLEAR AND Star of Destiny #1 Recruited AND Temp Event Flag #255 CLEAR | Make obj[2] Hidden (disp = 0); Open Dialogue Message Window; Engine Action #154; Engine Action #54; Warp to Castle HQ (0, 2, 47) |

---

### Submap Layer `vj17_01` (Index 1)

- **Map Number (`mapno`)**: `1`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `33` Objects | **Script Count (`evkaz`)**: `43` Scripts

#### Complete Physical Entity Inventory (33 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 65059** | `65059` | `(43, 94)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Actor ID 65192** | `65192` | `(47, 26)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Actor ID 65061** | `65061` | `(96, 44)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | NPC / Actor | **Rare Items Dealer** | `65174` | `(45, 26)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[04]` | Trigger / Hitbox | **Hitbox Zone (3x1)** | `0` | `(42, 96)` | `2x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | Trigger / Hitbox | **Hitbox Zone (1x4)** | `0` | `(38, 92)` | `0x3` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[06]` | Trigger / Hitbox | **Hitbox Zone (3x1)** | `0` | `(46, 28)` | `2x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Hitbox Zone (3x1)** | `0` | `(44, 28)` | `2x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Trigger / Hitbox | **Hitbox Zone (3x1)** | `0` | `(95, 46)` | `2x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | NPC / Actor | **Actor ID 64939** | `64939` | `(29, 90)` | `0x0` | East (Right) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[10]` | NPC / Actor | **Actor ID 64569** | `64569` | `(25, 95)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[11]` | NPC / Actor | **Actor ID 65030** | `65030` | `(96, 90)` | `1x1` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[12]` | NPC / Actor | **Actor ID 65175** | `65175` | `(89, 51)` | `1x1` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[13]` | Prop / Scenery | **Prop ID 65008** | `65008` | `(98, 24)` | `0x0` | Frame 4 | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | NPC / Actor | **Actor ID 65008** | `65008` | `(98, 24)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[15]` | Trigger / Hitbox | **Hitbox Zone (5x2)** | `0` | `(96, 23)` | `4x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[16]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(47, 97)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[17]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(117, 101)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[18]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(103, 101)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[19]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(84, 48)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[20]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(81, 41)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[21]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(91, 46)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[22]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(99, 46)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[23]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(101, 46)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[24]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(103, 46)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[25]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(41, 28)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[26]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(51, 28)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[27]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(53, 28)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[28]` | Trigger / Hitbox | **Hitbox Zone (4x3)** | `0` | `(26, 19)` | `3x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[29]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(38, 19)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[30]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(42, 20)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[31]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(46, 20)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[32]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(52, 20)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 65059)**: Positioned at tile `(43, 94)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Object 65192)**: Positioned at tile `(47, 26)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Object 65061)**: Positioned at tile `(96, 44)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Rare Items Dealer)**: Positioned at tile `(45, 26)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `1` tiles high from `(42, 96)` to `(44, 96)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[05]` (Hitbox Zone)**: Bounding trigger area covering `1` tiles wide by `4` tiles high from `(38, 92)` to `(38, 95)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[06]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `1` tiles high from `(46, 28)` to `(48, 28)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[07]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `1` tiles high from `(44, 28)` to `(46, 28)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[08]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `1` tiles high from `(95, 46)` to `(97, 46)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[09]` (Object 64939)**: Positioned at tile `(29, 90)`, facing East (Right). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[10]` (Object 64569)**: Positioned at tile `(25, 95)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[11]` (Object 65030)**: Positioned at tile `(96, 90)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[12]` (Object 65175)**: Positioned at tile `(89, 51)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[13]` (Prop: Object 65008)**: Environmental world dressing prop placed at tile `(98, 24)`. Solid collision is set to `128`.
- **`obj[14]` (Object 65008)**: Positioned at tile `(98, 24)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[15]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `2` tiles high from `(96, 23)` to `(100, 24)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[16]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(47, 97)`. Evaluates player step-on or Confirm button inputs.
- **`obj[17]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(117, 101)`. Evaluates player step-on or Confirm button inputs.
- **`obj[18]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(103, 101)`. Evaluates player step-on or Confirm button inputs.
- **`obj[19]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(84, 48)`. Evaluates player step-on or Confirm button inputs.
- **`obj[20]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(81, 41)` to `(83, 42)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[21]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(91, 46)`. Evaluates player step-on or Confirm button inputs.
- **`obj[22]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(99, 46)`. Evaluates player step-on or Confirm button inputs.
- **`obj[23]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(101, 46)`. Evaluates player step-on or Confirm button inputs.
- **`obj[24]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(103, 46)`. Evaluates player step-on or Confirm button inputs.
- **`obj[25]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(41, 28)`. Evaluates player step-on or Confirm button inputs.
- **`obj[26]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(51, 28)`. Evaluates player step-on or Confirm button inputs.
- **`obj[27]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(53, 28)`. Evaluates player step-on or Confirm button inputs.
- **`obj[28]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `3` tiles high from `(26, 19)` to `(29, 21)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[29]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(38, 19)` to `(40, 20)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[30]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(42, 20)` to `(44, 22)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[31]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(46, 20)` to `(48, 22)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[32]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(52, 20)` to `(54, 22)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (43 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Always Passes (Unconditional) | Make obj[0] Hidden (disp = 0); Reset Camera Tracking (0); Screen Fade Transition (47, 255, 254) |
| `ev[01]` | `2 (Map Init)` | Story Flag 143 (bit 1) CLEAR | Open Dialogue Message Window; Engine Action #9 |
| `ev[02]` | `2 (Map Init)` | Story Flag 143 (bit 1) SET | Make obj[2] Hidden (disp = 0); Engine Action #9; Set Entity Movement Speed (26, 2); Animate Door Open; Turn obj[28] facing South (Down); Engine Action #9; Open Dialogue Message Window; Close Dialogue Window; Open Dialogue Message Window; Show Dialogue Portrait (47, 255, 254) |
| `ev[03]` | `128 (Loop)` | Player within Box [51..55, 2..92] AND Condition Check #93 AND Story Flag 1 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 115]; Engine Action #90 |
| `ev[04]` | `128 (Loop)` | Player within Box [113..117, 2..93] AND Condition Check #94 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 1, MsgID: 53]; Clear Story Milestone Flag 255 (mask 254) |
| `ev[05]` | `128 (Loop)` | Player within Box [47..51, 2..110] AND Condition Check #111 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 130]; Walk obj[255] to (254,204) |
| `ev[06]` | `128 (Loop)` | Player within Box [95..99, 2..56] AND Condition Check #57 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 102]; Make obj[255] Hidden (disp = 0) |
| `ev[07]` | `128 (Loop)` | Player within Box [45..49, 2..40] AND Condition Check #41 AND Story Flag 0 (mask 255) SET | Display Dialogue Box [Bank: 0, MsgID: 62]; Walk obj[255] to (254,204) |
| `ev[08]` | `1 (Action / Talk)` | Target Inspected is obj[9] | Clear Story Milestone Flag 7 (mask 9); Open Dialogue Message Window; Open Dialogue Message Window; Warp Room -> Submap 3 at (0,12) facing 27; Warp to Castle HQ (9, 0, 255) |
| `ev[09]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Clear Story Milestone Flag 7 (mask 9); Open Dialogue Message Window; Open Dialogue Message Window; Warp Room -> Submap 3 at (0,12) facing 27 |
| `ev[10]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[11] | Clear Story Milestone Flag 13 (mask 11); Open Dialogue Message Window; Engine Action #5; Warp Room -> Submap 2 at (13,11) facing East (Right); Close Dialogue Window; Open Dialogue Message Window |
| `ev[11]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[15] | Clear Story Milestone Flag 13 (mask 11); Open Dialogue Message Window; Engine Action #5; Warp Room -> Submap 2 at (13,11) facing 255 |
| `ev[12]` | `1 (Action / Talk)` | Target Inspected is obj[12] | Warp to Castle HQ (8, 0, 96); Show Dialogue Portrait (8, 0, 2); Warp Room -> Submap 2 at (10,0) facing 255 |
| `ev[13]` | `1 (Action / Talk)` | Target Inspected is obj[13] | Warp to Castle HQ (8, 2, 96); Show Dialogue Portrait (8, 0, 2); Warp Room -> Submap 2 at (10,0) facing 255 |
| `ev[14]` | `1 (Action / Talk)` | Target Inspected is obj[10] | Clear Story Milestone Flag 11 (mask 10); Open Dialogue Message Window; Exit to World Map (1, 2, 1); Close Dialogue Window |
| `ev[15]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Warp to Castle HQ (10, 0, 96); Close Dialogue Window; Screen Fade Transition (0, 4, 1); Warp Town -> Area 1 Map 11 Submap 255 at (254,204) |
| `ev[16]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[17] | Open Dialogue Sub-Window (3); Engine Action #5; Warp to Castle HQ (17, 3, 255) |
| `ev[17]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[18] | Open Dialogue Sub-Window (3); Engine Action #6; Warp to Castle HQ (18, 0, 255) |
| `ev[18]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[19] | Open Dialogue Sub-Window (3); Pan Camera (255, 254, 204) |
| `ev[19]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[20] | Open Dialogue Sub-Window (3); Reset Camera Tracking (255) |
| `ev[20]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[17] | Open Dialogue Sub-Window (5); Engine Action #5; Warp to Castle HQ (17, 3, 255) |
| `ev[21]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[18] | Open Dialogue Sub-Window (5); Engine Action #6; Warp to Castle HQ (18, 0, 255) |
| `ev[22]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[19] | Open Dialogue Sub-Window (5); Pan Camera (255, 254, 204) |
| `ev[23]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[20] | Open Dialogue Sub-Window (5); Reset Camera Tracking (255) |
| `ev[24]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) CLEAR AND Player within Box [94..95, 5..23] | Make obj[1] Hidden (disp = 0); Execute Choice Result (0); Set Story Flag (3, 22); Warp Town -> Area 47 Map 23 Submap 3 at (9,46); Open Dialogue Message Window; Execute Choice Result (1); Set Story Flag (47, 255) |
| `ev[25]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) CLEAR AND Player Y within Range [25..26] AND Target Inspected is obj[23] | Make obj[1] Hidden (disp = 0); Execute Choice Result (0); Set Story Flag (3, 22); Open Dialogue Message Window; Teleport obj[23] to (3,9); Make obj[0] Hidden (disp = 0); Execute Choice Result (1); Set Story Flag (47, 255) |
| `ev[26]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) CLEAR AND Player Y within Range [23..24] AND Target Inspected is obj[23] | Make obj[1] Hidden (disp = 0); Execute Choice Result (0); Set Story Flag (3, 22); Warp Room -> Submap 23 at (3,9) facing 46; Open Dialogue Message Window; Execute Choice Result (1); Set Story Flag (47, 255) |
| `ev[27]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Player within Box [94..95, 5..23] | Make obj[1] Hidden (disp = 0); Execute Choice Result (0); Set Story Flag (3, 22); Warp Town -> Area 47 Map 23 Submap 5 at (9,46); Open Dialogue Message Window; Execute Choice Result (1); Set Story Flag (47, 255) |
| `ev[28]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Player Y within Range [25..26] AND Target Inspected is obj[23] | Make obj[1] Hidden (disp = 0); Execute Choice Result (0); Set Story Flag (3, 22); Open Dialogue Message Window; Teleport obj[23] to (5,9); Make obj[0] Hidden (disp = 0); Execute Choice Result (1); Set Story Flag (47, 255) |
| `ev[29]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Player Y within Range [23..24] AND Target Inspected is obj[23] | Make obj[1] Hidden (disp = 0); Execute Choice Result (0); Set Story Flag (3, 22); Warp Room -> Submap 23 at (5,9) facing 46; Open Dialogue Message Window; Execute Choice Result (1); Set Story Flag (47, 255) |
| `ev[30]` | `1 (Action / Talk)` | Target Inspected is obj[24] | Open Dialogue Sub-Window (2); Dismiss Dialogue Portrait |
| `ev[31]` | `1 (Action / Talk)` | Target Inspected is obj[25] | Open Dialogue Sub-Window (2); Change Portrait Expression (255) |
| `ev[32]` | `1 (Action / Talk)` | Target Inspected is obj[26] | Open Dialogue Sub-Window (2); Display Speaker Name Box (255) |
| `ev[33]` | `1 (Action / Talk)` | Target Inspected is obj[27] | Open Dialogue Sub-Window (2); Display Choice Selection (255, 254) |
| `ev[34]` | `1 (Action / Talk)` | Target Inspected is obj[28] | Open Dialogue Sub-Window (2); Branch on Choice (255, 254) |
| `ev[35]` | `1 (Action / Talk)` | Target Inspected is obj[29] | Open Dialogue Sub-Window (2); Execute Choice Result (255) |
| `ev[36]` | `1 (Action / Talk)` | Target Inspected is obj[30] | Open Dialogue Sub-Window (2); Set Story Flag (255, 254) |
| `ev[37]` | `1 (Action / Talk)` | Target Inspected is obj[31] | Open Dialogue Sub-Window (2); Open Dialogue Sub-Window (255) |
| `ev[38]` | `1 (Action / Talk)` | Target Inspected is obj[32] | Open Dialogue Sub-Window (2); Close Dialogue Sub-Window (255) |
| `ev[39]` | `1 (Action / Talk)` | Target Inspected is obj[33] | Open Dialogue Sub-Window (2); Clear Dialogue Sub-Window |
| `ev[40]` | `1 (Action / Talk)` | Target Inspected is obj[34] | Open Dialogue Sub-Window (2); Fade In from Black (255) |
| `ev[41]` | `1 (Action / Talk)` | Target Inspected is obj[35] | Open Dialogue Sub-Window (2); Fade Out to Black (255) |
| `ev[42]` | `1 (Action / Talk)` | Target Inspected is obj[36] | Open Dialogue Sub-Window (2); Display Chapter Text (255) |

---


