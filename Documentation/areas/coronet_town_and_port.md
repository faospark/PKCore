# Suikoden II Geographic Area Catalog: Coronet Town & Harbor Docks

**Geographic Scope & Role**: Riverside port town; wooden pier docks, Tai Ho & Yam Koo's moored boat, tavern, and fisherman cottages.

**Regional Category**: Region `VC` | **Master Maps Included**: `vc17`, `vc18`, `vc19`

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

## Location Map: `vc17`

- **Master Map Container**: `vc17.json`
- **Submap Layer Files**: vc17_00.json, vc17_04.json, vc17_05.json
- **Collision Grid Files**: vc17_map_00.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 1

### Submap Layer `vc17_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `37` Objects | **Script Count (`evkaz`)**: `47` Scripts

#### Complete Physical Entity Inventory (37 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Actor ID 65179** | `65179` | `(48, 27)` | `3x3` | South (Down) | Visible (1) | Special (3) | 3 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Actor ID 65180** | `65180` | `(46, 49)` | `3x3` | South (Down) | Visible (1) | Special (3) | 3 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Village Direction Signpost** | `65009` | `(26, 29)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | NPC / Actor | **Actor ID 65011** | `65011` | `(24, 29)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[04]` | NPC / Actor | **Actor ID 64785** | `64785` | `(15, 52)` | `10x5` | South (Down) | Visible (1) | Passable (0) | 3 | 255 | 0 |
| `obj[05]` | NPC / Actor | **Actor ID 64958** | `64958` | `(17, 54)` | `7x3` | South (Down) | Visible (1) | Passable (0) | 3 | 255 | 0 |
| `obj[06]` | NPC / Actor | **Actor ID 64958** | `64958` | `(22, 54)` | `4x3` | South (Down) | Visible (1) | Passable (0) | 3 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Hitbox Zone (4x3)** | `0` | `(48, 57)` | `3x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(48, 56)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(49, 52)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(50, 44)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Trigger / Hitbox | **Hitbox Zone (4x2)** | `0` | `(47, 42)` | `3x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(37, 32)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[13]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(39, 32)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[14]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(38, 30)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[15]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(38, 28)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[16]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(38, 26)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[17]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(50, 26)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[18]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(50, 25)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[19]` | Trigger / Hitbox | **Hitbox Zone (6x3)** | `0` | `(47, 22)` | `5x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[20]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(37, 20)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[21]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(37, 17)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[22]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(37, 15)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[23]` | Trigger / Hitbox | **Hitbox Zone (3x3)** | `0` | `(37, 13)` | `2x2` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[24]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(46, 18)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[25]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(46, 16)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[26]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(46, 14)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[27]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(0, 0)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[28]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[29]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[30]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[31]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[32]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[33]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[34]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[35]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[36]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Object 65179)**: Positioned at tile `(48, 27)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Object 65180)**: Positioned at tile `(46, 49)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Village Direction Signpost)**: Positioned at tile `(26, 29)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Object 65011)**: Positioned at tile `(24, 29)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (Object 64785)**: Positioned at tile `(15, 52)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[05]` (Object 64958)**: Positioned at tile `(17, 54)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[06]` (Object 64958)**: Positioned at tile `(22, 54)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[07]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `3` tiles high from `(48, 57)` to `(51, 59)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[08]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(48, 56)` to `(51, 57)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[09]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(49, 52)` to `(52, 53)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[10]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(50, 44)` to `(51, 45)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[11]` (Hitbox Zone)**: Bounding trigger area covering `4` tiles wide by `2` tiles high from `(47, 42)` to `(50, 43)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[12]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(37, 32)` to `(38, 32)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[13]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(39, 32)` to `(40, 32)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[14]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(38, 30)` to `(39, 31)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[15]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(38, 28)` to `(39, 29)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[16]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(38, 26)` to `(40, 27)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[17]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(50, 26)` to `(51, 27)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[18]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(50, 25)` to `(51, 26)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[19]` (Hitbox Zone)**: Bounding trigger area covering `6` tiles wide by `3` tiles high from `(47, 22)` to `(52, 24)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[20]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(37, 20)` to `(39, 22)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[21]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(37, 17)` to `(39, 19)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[22]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(37, 15)` to `(39, 17)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[23]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `3` tiles high from `(37, 13)` to `(39, 15)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[24]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(46, 18)` to `(47, 19)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[25]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(46, 16)` to `(47, 17)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[26]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(46, 14)` to `(47, 15)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[27]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(0, 0)` to `(1, 1)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[28]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[29]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[30]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[31]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[32]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[33]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[34]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[35]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[36]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.


#### Complete Bytecode Script Catalog (47 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Always Passes (Unconditional) | Make obj[89] Hidden (disp = 0); Screen Fade Transition (2, 4, 89); Close Dialogue Window; Warp Town -> Area 4 Map 47 Submap 255 at (254,255) |
| `ev[01]` | `128 (Loop)` | Player within Box [34..52, 2..37] AND Condition Check #40 AND Story Flag 1 (mask 255) SET | Warp Room -> Submap 0 at (2,5) |
| `ev[02]` | `1 (Action / Talk)` | Player within Box [36..52, 2..4] AND Target Inspected is obj[9] AND Player X within Range [255..254] | Warp Room -> Submap 0 at (2,5); Set Special Scene BGM (1); Warp Map Transition (3, 0, 66, 104, 255) |
| `ev[03]` | `128 (Loop)` | Player within Box [37..43, 2..43] AND Condition Check #44 AND Story Flag 0 (mask 255) SET | Warp Room -> Submap 0 at (2,17) |
| `ev[04]` | `1 (Action / Talk)` | Player within Box [35..48, 2..61] AND Condition Check #62 AND Story Flag 0 (mask 255) SET | Warp Room -> Submap 0 at (2,17); Set Special Scene BGM (1); Warp Map Transition (3, 250, 0, 0, 255) |
| `ev[05]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) CLEAR AND Target Inspected is obj[8] | Open Dialogue Sub-Window (0); Dismiss Emotion Bubble (255) |
| `ev[06]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) SET AND Story Flag 17 (bit 16) CLEAR AND Target Inspected is obj[8] | Open Dialogue Sub-Window (2); Dismiss Emotion Bubble (255) |
| `ev[07]` | `1 (Action / Talk)` | Story Flag 17 (bit 16) SET AND Story Flag 124 (bit 16) CLEAR AND Target Inspected is obj[8] | Open Dialogue Sub-Window (3); Dismiss Emotion Bubble (255) |
| `ev[08]` | `1 (Action / Talk)` | Story Flag 124 (bit 16) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[8] | Open Dialogue Sub-Window (4); Dismiss Emotion Bubble (255) |
| `ev[09]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[8] | Open Dialogue Sub-Window (5); Dismiss Emotion Bubble (255) |
| `ev[10]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[8] | Open Dialogue Sub-Window (6); Dismiss Emotion Bubble (255) |
| `ev[11]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) CLEAR AND Target Inspected is obj[9] | Open Dialogue Sub-Window (0); Warp Room -> Submap 255 at (254,255) |
| `ev[12]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) SET AND Story Flag 17 (bit 16) CLEAR AND Target Inspected is obj[9] | Open Dialogue Sub-Window (2); Warp Room -> Submap 255 at (254,255) |
| `ev[13]` | `1 (Action / Talk)` | Story Flag 17 (bit 16) SET AND Story Flag 124 (bit 16) CLEAR AND Target Inspected is obj[9] | Open Dialogue Sub-Window (3); Warp Room -> Submap 255 at (254,255) |
| `ev[14]` | `1 (Action / Talk)` | Story Flag 124 (bit 16) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[9] | Open Dialogue Sub-Window (4); Warp Room -> Submap 255 at (254,255) |
| `ev[15]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[9] | Open Dialogue Sub-Window (5); Warp Room -> Submap 255 at (254,255) |
| `ev[16]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[9] | Open Dialogue Sub-Window (6); Warp Room -> Submap 255 at (254,255) |
| `ev[17]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Open Dialogue Sub-Window (1); Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[18]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Open Dialogue Sub-Window (1); Warp Town -> Area 255 Map 254 Submap 255 at (254,204) |
| `ev[19]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Open Dialogue Sub-Window (1); Warp to Castle HQ (255, 254, 255) |
| `ev[20]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Open Dialogue Sub-Window (1); Exit to World Map (255, 254, 255) |
| `ev[21]` | `1 (Action / Talk)` | Target Inspected is obj[19] | Open Dialogue Sub-Window (1); Engine Action #5 |
| `ev[22]` | `1 (Action / Talk)` | Target Inspected is obj[20] | Open Dialogue Sub-Window (1); Engine Action #6 |
| `ev[23]` | `1 (Action / Talk)` | Target Inspected is obj[21] | Open Dialogue Sub-Window (1); Pan Camera (255, 254, 255) |
| `ev[24]` | `1 (Action / Talk)` | Target Inspected is obj[22] | Open Dialogue Sub-Window (1); Reset Camera Tracking (255) |
| `ev[25]` | `1 (Action / Talk)` | Target Inspected is obj[23] | Open Dialogue Sub-Window (1); Engine Action #9 |
| `ev[26]` | `1 (Action / Talk)` | Target Inspected is obj[24] | Open Dialogue Sub-Window (1); Screen Fade Transition (255, 254, 255) |
| `ev[27]` | `1 (Action / Talk)` | Target Inspected is obj[25] | Open Dialogue Sub-Window (1); Close Dialogue Window |
| `ev[28]` | `1 (Action / Talk)` | Target Inspected is obj[26] | Open Dialogue Sub-Window (1); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[29]` | `1 (Action / Talk)` | Target Inspected is obj[27] | Open Dialogue Sub-Window (1); Place Scenery Structure (255) |
| `ev[30]` | `1 (Action / Talk)` | Target Inspected is obj[28] | Open Dialogue Sub-Window (1); Animate Door Open |
| `ev[31]` | `1 (Action / Talk)` | Target Inspected is obj[29] | Open Dialogue Sub-Window (1); Show Dialogue Portrait (255, 254, 255) |
| `ev[32]` | `1 (Action / Talk)` | Target Inspected is obj[30] | Open Dialogue Sub-Window (1); Dismiss Dialogue Portrait |
| `ev[33]` | `1 (Action / Talk)` | Target Inspected is obj[31] | Open Dialogue Sub-Window (1); Change Portrait Expression (255) |
| `ev[34]` | `1 (Action / Talk)` | Target Inspected is obj[32] | Open Dialogue Sub-Window (1); Display Speaker Name Box (255) |
| `ev[35]` | `1 (Action / Talk)` | Target Inspected is obj[33] | Open Dialogue Sub-Window (1); Display Choice Selection (255, 254) |
| `ev[36]` | `1 (Action / Talk)` | Target Inspected is obj[34] | Open Dialogue Sub-Window (1); Branch on Choice (255, 254) |
| `ev[37]` | `1 (Action / Talk)` | Target Inspected is obj[35] | Open Dialogue Sub-Window (1); Execute Choice Result (255) |
| `ev[38]` | `1 (Action / Talk)` | Target Inspected is obj[36] | Open Dialogue Sub-Window (1); Set Story Flag (255, 254) |
| `ev[39]` | `1 (Action / Talk)` | Target Inspected is obj[37] | Open Dialogue Sub-Window (1); Open Dialogue Sub-Window (255) |
| `ev[40]` | `1 (Action / Talk)` | Target Inspected is obj[38] | Open Dialogue Sub-Window (1); Close Dialogue Sub-Window (255) |
| `ev[41]` | `1 (Action / Talk)` | Target Inspected is obj[39] | Open Dialogue Sub-Window (1); Clear Dialogue Sub-Window |
| `ev[42]` | `1 (Action / Talk)` | Target Inspected is obj[40] | Open Dialogue Sub-Window (1); Fade In from Black (255) |
| `ev[43]` | `1 (Action / Talk)` | Target Inspected is obj[41] | Open Dialogue Sub-Window (1); Fade Out to Black (255) |
| `ev[44]` | `1 (Action / Talk)` | Target Inspected is obj[42] | Open Dialogue Sub-Window (1); Display Chapter Text (255) |
| `ev[45]` | `1 (Action / Talk)` | Target Inspected is obj[43] | Open Dialogue Sub-Window (1); Display Emotion Bubble (255, 254) |
| `ev[46]` | `1 (Action / Talk)` | Target Inspected is obj[44] | Open Dialogue Sub-Window (1); Dismiss Emotion Bubble (255) |

---



## Location Map: `vc18`

- **Master Map Container**: `vc18.json`
- **Submap Layer Files**: vc18_00.json, vc18_08.json, vc18_09.json
- **Collision Grid Files**: vc18_map_00.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 1

### Submap Layer `vc18_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `43` Objects | **Script Count (`evkaz`)**: `121` Scripts

#### Complete Physical Entity Inventory (43 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Genshu** | `47` | `(100, 58)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Actor ID 65104** | `65104` | `(39, 65)` | `0x0` | Up (North) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Actor ID 65104** | `65104` | `(39, 65)` | `0x0` | Up (North) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[03]` | NPC / Actor | **Actor ID 65104** | `65104` | `(39, 65)` | `0x0` | Up (North) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[04]` | World Device | **Mechanism (ano 15)** | `0` | `(46, 82)` | `0x0` | Frame 15 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[05]` | NPC / Actor | **Actor ID 65035** | `65035` | `(102, 26)` | `3x3` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[06]` | NPC / Actor | **Actor ID 65180** | `65180` | `(101, 45)` | `3x3` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[07]` | NPC / Actor | **Actor ID 65179** | `65179` | `(128, 56)` | `3x3` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[08]` | NPC / Actor | **Actor ID 65176** | `65176` | `(153, 29)` | `3x3` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[09]` | NPC / Actor | **Actor ID 65228** | `65228` | `(68, 29)` | `3x3` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[10]` | NPC / Actor | **Actor ID 65040** | `65040` | `(21, 47)` | `3x3` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[11]` | NPC / Actor | **Actor ID 65179** | `65179` | `(33, 47)` | `4x3` | South (Down) | Visible (1) | Special (3) | 3 | 128 | 0 |
| `obj[12]` | NPC / Actor | **Actor ID 64569** | `64569` | `(33, 41)` | `3x3` | South (Down) | Visible (1) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[13]` | NPC / Actor | **Actor ID 64844** | `64844` | `(72, 22)` | `0x0` | South (Down) | Visible (1) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[14]` | Trigger / Hitbox | **Hitbox Zone (1x2)** | `0` | `(33, 43)` | `0x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[15]` | NPC / Actor | **Actor ID 65104** | `65104` | `(113, 37)` | `4x5` | South (Down) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[16]` | NPC / Actor | **Actor ID 65104** | `65104` | `(84, 24)` | `7x7` | South (Down) | Dormant / Hidden (0) | Special (3) | 3 | 128 | 0 |
| `obj[17]` | Trigger / Hitbox | **Hitbox Zone (3x1)** | `0` | `(11, 69)` | `2x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[18]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(15, 69)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[19]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(17, 69)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[20]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(24, 69)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[21]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(38, 43)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[22]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(40, 43)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[23]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(49, 49)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[24]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(51, 49)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[25]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(53, 49)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[26]` | Trigger / Hitbox | **Hitbox Zone (3x1)** | `0` | `(61, 25)` | `2x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[27]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(63, 27)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[28]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(64, 25)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[29]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(64, 23)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[30]` | Trigger / Hitbox | **Hitbox Zone (5x1)** | `0` | `(77, 21)` | `4x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[31]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(121, 20)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[32]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(121, 17)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[33]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(129, 27)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[34]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(131, 29)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[35]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(143, 27)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[36]` | Trigger / Hitbox | **Hitbox Zone (5x1)** | `0` | `(145, 27)` | `4x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[37]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(151, 27)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[38]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(153, 33)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[39]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(155, 33)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[40]` | Trigger / Hitbox | **Hitbox Zone (2x1)** | `0` | `(157, 33)` | `1x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[41]` | Trigger / Hitbox | **Single-Tile Trigger Dot** | `0` | `(0, 0)` | `0x0` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[42]` | Trigger / Hitbox | **Hitbox Zone (3x2)** | `0` | `(100, 41)` | `2x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Genshu)**: Positioned at tile `(100, 58)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Object 65104)**: Positioned at tile `(39, 65)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Object 65104)**: Positioned at tile `(39, 65)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (Object 65104)**: Positioned at tile `(39, 65)`, facing Up (North). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[04]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(46, 82)` with state parameter `15`.
- **`obj[05]` (Object 65035)**: Positioned at tile `(102, 26)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[06]` (Object 65180)**: Positioned at tile `(101, 45)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[07]` (Object 65179)**: Positioned at tile `(128, 56)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[08]` (Object 65176)**: Positioned at tile `(153, 29)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[09]` (Object 65228)**: Positioned at tile `(68, 29)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[10]` (Object 65040)**: Positioned at tile `(21, 47)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[11]` (Object 65179)**: Positioned at tile `(33, 47)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[12]` (Object 64569)**: Positioned at tile `(33, 41)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[13]` (Object 64844)**: Positioned at tile `(72, 22)`, facing South (Down). Rendered and active by default. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[14]` (Hitbox Zone)**: Bounding trigger area covering `1` tiles wide by `2` tiles high from `(33, 43)` to `(33, 44)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[15]` (Object 65104)**: Positioned at tile `(113, 37)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[16]` (Object 65104)**: Positioned at tile `(84, 24)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[17]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `1` tiles high from `(11, 69)` to `(13, 69)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[18]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(15, 69)` to `(16, 69)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[19]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(17, 69)` to `(18, 70)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[20]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(24, 69)` to `(26, 70)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[21]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(38, 43)` to `(39, 43)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[22]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(40, 43)` to `(41, 44)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[23]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(49, 49)` to `(50, 49)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[24]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(51, 49)` to `(52, 49)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[25]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(53, 49)` to `(54, 49)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[26]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `1` tiles high from `(61, 25)` to `(63, 25)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[27]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(63, 27)` to `(64, 28)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[28]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(64, 25)` to `(65, 26)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[29]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(64, 23)` to `(66, 24)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[30]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `1` tiles high from `(77, 21)` to `(81, 21)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[31]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(121, 20)` to `(123, 21)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[32]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(121, 17)` to `(123, 18)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[33]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(129, 27)` to `(131, 28)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[34]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(131, 29)` to `(132, 30)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[35]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(143, 27)` to `(144, 28)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[36]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `1` tiles high from `(145, 27)` to `(149, 27)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[37]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(151, 27)` to `(153, 28)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[38]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(153, 33)` to `(154, 33)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[39]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(155, 33)` to `(156, 33)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[40]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `1` tiles high from `(157, 33)` to `(158, 33)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[41]` (Single-Tile Trigger Dot)**: Invisible trigger volume constrained to exactly 1 tile at `(0, 0)`. Evaluates player step-on or Confirm button inputs.
- **`obj[42]` (Hitbox Zone)**: Bounding trigger area covering `3` tiles wide by `2` tiles high from `(100, 41)` to `(102, 42)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (121 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 59 (bit 32) SET | Make obj[3] Hidden (disp = 0); Open Dialogue Message Window; Warp Town -> Area 10 Map 59 Submap 32 at (47,255) |
| `ev[01]` | `2 (Map Init)` | Story Flag 14 (bit 128) SET | Make obj[2] Hidden (disp = 0); Display Dialogue Box [Bank: 46, MsgID: 82]; Open Dialogue Message Window; Display Dialogue Box [Bank: 47, MsgID: 255] |
| `ev[02]` | `2 (Map Init)` | Story Flag 14 (bit 128) SET AND Story Flag 21 (bit 4) CLEAR | Make obj[2] Hidden (disp = 0); Engine Action #9; Engine Action #39; Open Shop Interface #3; Engine Action #9; Warp Town -> Area 0 Map 9 Submap 47 at (255,254) |
| `ev[03]` | `2 (Map Init)` | Story Flag 21 (bit 4) SET AND Story Flag 20 (bit 128) CLEAR | Make obj[2] Hidden (disp = 0); Engine Action #9; Return Warp to Castle Base (63, 3); Engine Action #9; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #9; Warp Town -> Area 10 Map 38 Submap 63 at (3,10); Open Dialogue Message Window; Open Dialogue Message Window; Screen Fade Transition (2, 11, 36); Trigger Character Emotion Effect (3, 11); Warp Room -> Submap 11 at (47,255) facing 254 |
| `ev[04]` | `2 (Map Init)` | Story Flag 23 (bit 1) SET AND Story Flag 23 (bit 128) CLEAR | Make obj[2] Hidden (disp = 0); Engine Action #9; Return to Previous Memory Map (63); Warp to Castle HQ (9, 3, 0); Engine Action #9; Warp Town -> Area 10 Map 39 Submap 63 at (3,10); Warp Town -> Area 0 Map 10 Submap 1 at (11,47) |
| `ev[05]` | `2 (Map Init)` | Story Flag 20 (bit 128) SET | Make obj[1] Hidden (disp = 0); Engine Action #9; Warp Room -> Submap 1 at (11,47) facing 255 |
| `ev[06]` | `2 (Map Init)` | Story Flag 14 (bit 128) SET AND Condition Check #24 AND Condition Check #47 AND Player Y within Range [255..254] | Make obj[2] Hidden (disp = 0); Reset Camera Tracking (23); Set Special Scene BGM (3); Reset Camera Tracking (0); Open Dialogue Message Window; Reset Camera Tracking (47) |
| `ev[07]` | `2 (Map Init)` | Story Flag 14 (bit 128) SET AND Story Flag 20 (bit 128) CLEAR | Make obj[0] Hidden (disp = 0); Open Dialogue Sub-Window (0); Close Dialogue Sub-Window (47) |
| `ev[08]` | `2 (Map Init)` | Story Flag 23 (bit 1) SET AND Story Flag 23 (bit 128) CLEAR | Make obj[1] Hidden (disp = 0); Open Dialogue Sub-Window (1); Close Dialogue Sub-Window (47) |
| `ev[09]` | `128 (Loop)` | Player within Box [104..125, 2..19] AND Inventory Holds Item #9 [Kindness Drops] AND Player X within Range [255..254] | Warp Room -> Submap 1 at (2,16) |
| `ev[10]` | `1 (Action / Talk)` | Player within Box [107..124, 2..4] AND Target Inspected is obj[9] AND Player X within Range [255..254] | Warp Room -> Submap 1 at (2,16); Set Special Scene BGM (1); Warp Map Transition (2, 0, 42, 58, 255) |
| `ev[11]` | `128 (Loop)` | Player within Box [139..142, 2..24] AND Condition Check #35 AND Story Flag 3 (mask 255) SET | Engine Action #109; Warp Town -> Area 18 Map 255 Submap 254 at (204,204) |
| `ev[12]` | `1 (Action / Talk)` | Story Flag 21 (bit 2) SET AND Story Flag 21 (bit 4) CLEAR AND Player within Box [162..163, 2..21] AND Condition Check #35 AND Story Flag 3 (mask 255) SET | Engine Action #9; Set obj[16] Collision to Passable; Warp Room -> Submap 2 at (13,5) facing Up (North); Display Speaker Name Box (0); Open Dialogue Message Window; Display Emotion Bubble (255, 254) |
| `ev[13]` | `1 (Action / Talk)` | Player within Box [162..163, 2..21] AND Condition Check #35 AND Story Flag 3 (mask 255) SET | Engine Action #9; Set obj[16] Collision to Passable; Warp Room -> Submap 5 at (2,18) facing 250; Open Dialogue Message Window; Open Dialogue Message Window |
| `ev[14]` | `1 (Action / Talk)` | Story Flag 21 (bit 4) SET AND Story Flag 20 (bit 128) CLEAR AND Player within Box [59..61, 2..74] AND Condition Check #74 | Warp to Castle HQ (0, 0, 31); Warp Town -> Area 12 Map 10 Submap 122 at (1,32); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #172; Set Render Priority (pri) (255, 254) |
| `ev[15]` | `1 (Action / Talk)` | Story Flag 15 (bit 1) SET AND Story Flag 15 (bit 2) CLEAR AND Player within Box [33..39, 2..61] AND Condition Check #62 AND Story Flag 0 (mask 255) SET | Recruit Character into Active Party (43 [Ayda], 0); Exit to World Map (55, 0, 36); Animate Doorway State (8, 33); Warp Town -> Area 18 Map 124 Submap 46 at (0,1); Open Dialogue Message Window; Warp Town -> Area 47 Map 49 Submap 2 at (5,1); Exit to World Map (5, 3, 2); Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Warp Town -> Area 4 Map 5 Submap 2 at (2,0); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Walk obj[43] to (9,5); Set Render Priority (pri) (9, 36); Open Shop Interface #8; Warp to Castle HQ (9, 1, 73); Screen Fade Transition (118, 9, 11); Reset Camera Tracking (0); Warp to Castle HQ (73, 15, 72); Warp Room -> Submap 9 at (24,1) facing South (Down); Exit to World Map (72, 0, 1); Set Combat Battle BGM (15); Engine Action #118; Engine Action #9; Close Dialogue Window; Reset Camera Tracking (0); Engine Action #5; Set Combat Battle BGM (15); Load Sound Bank into Memory (1, 1); Exit to World Map (24, 1, 0); Engine Action #6; Load Sound Bank into Memory (0, 1); Engine Action #5; Warp Room -> Submap 15 at (2,0) facing 5; Reset Camera Tracking (30); Engine Action #5; Open Dialogue Message Window; Warp to Castle HQ (0, 5, 30); Dismiss Emotion Bubble (39); Return Warp to Castle Base (49, 2); Engine Action #5; Open Dialogue Message Window; Exit to World Map (4, 1, 4); Dismiss Emotion Bubble (255); Engine Action #5; Engine Action #9; Exit to World Map (4, 3, 3); Warp Room -> Submap 5 at (5,2) facing South (Down); Dismiss Emotion Bubble (255); Walk obj[9] to (15,2); Engine Action #58 |
| `ev[16]` | `1 (Action / Talk)` | Story Flag 15 (bit 2) SET AND Story Flag 21 (bit 4) CLEAR AND Player within Box [33..39, 2..62] AND Condition Check #63 AND Story Flag 0 (mask 255) SET | Recruit Character into Active Party (43 [Ayda], 0); Exit to World Map (55, 0, 36); Animate Doorway State (8, 43); Engine Action #9; Engine Action #5; Set Render Priority (pri) (9, 36); Open Shop Interface #8; Warp to Castle HQ (9, 1, 5); Engine Action #9; Engine Action #6; Warp Room -> Submap 72 at (1,0) facing 9; Engine Action #5; Open Dialogue Message Window; Warp Town -> Area 0 Map 5 Submap 5 at (4,4); Warp Room -> Submap 30 at (72,0) facing South (Down); Engine Action #5; Engine Action #9; Exit to World Map (4, 3, 3); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp Town -> Area 0 Map 30 Submap 58 at (255,254) |
| `ev[17]` | `1 (Action / Talk)` | Story Flag 21 (bit 4) SET AND Story Flag 124 (bit 16) CLEAR AND Player within Box [32..40, 2..67] AND Condition Check #68 AND Story Flag 1 (mask 255) SET | Recruit Character into Active Party (58 [Gijimu], 118); Engine Action #9; Close Dialogue Window; Reset Camera Tracking (5); Open Dialogue Message Window; Engine Action #5; Open Dialogue Message Window; Exit to World Map (4, 5, 15); Warp to Castle HQ (0, 5, 5); Open Dialogue Message Window; Warp to Castle HQ (30, 58, 255) |
| `ev[18]` | `1 (Action / Talk)` | Story Flag 21 (bit 4) SET AND Story Flag 124 (bit 16) CLEAR AND Player within Box [33..39, 2..54] AND Condition Check #55 AND Story Flag 0 (mask 255) SET | Recruit Character into Active Party (58 [Gijimu], 118); Close Dialogue Window; Close Dialogue Window; Reset Camera Tracking (5); Open Dialogue Message Window; Engine Action #5; Open Dialogue Message Window; Exit to World Map (4, 5, 15); Warp Town -> Area 0 Map 5 Submap 5 at (1,3); Dismiss Emotion Bubble (58) |
| `ev[19]` | `1 (Action / Talk)` | Story Flag 124 (bit 16) SET AND Story Flag 23 (bit 1) CLEAR AND Player within Box [32..40, 2..67] AND Condition Check #68 AND Story Flag 1 (mask 255) SET | Recruit Character into Active Party (43 [Ayda], 0); Exit to World Map (55, 0, 35); Engine Action #66; Reset Camera Tracking (33); Warp Room -> Submap 0 at (1,5) facing West (Left); Exit to World Map (4, 3, 2); Warp Room -> Submap 5 at (15,30) facing 118; Engine Action #9; Close Dialogue Window; Reset Camera Tracking (2); Open Dialogue Message Window; Set Combat Battle BGM (15); Close Dialogue Sub-Window (1); Warp Town -> Area 1 Map 73 Submap 15 at (49,4); Engine Action #5; Engine Action #9; Exit to World Map (3, 3, 0); Pan Camera (1, 30, 255); Engine Action #5; Screen Fade Transition (4, 3, 2); Open Dialogue Message Window; Pan Camera (1, 30, 255); Engine Action #5; Close Dialogue Window; Exit to World Map (4, 1, 15); Dismiss Emotion Bubble (1); Close Dialogue Window; Engine Action #5; Warp Room -> Submap 4 at (5,30) facing Up (North); Warp Town -> Area 30 Map 1 Submap 1 at (255,254); Walk obj[34] to (9,23); Warp Room -> Submap 255 at (254,255) facing 254 |
| `ev[20]` | `1 (Action / Talk)` | Story Flag 23 (bit 1) SET AND Story Flag 23 (bit 128) CLEAR AND Target Inspected is obj[9] | Engine Action #119; Close Dialogue Window; Reset Camera Tracking (5); Engine Action #6; Warp to Castle HQ (9, 3, 255) |
| `ev[21]` | `1 (Action / Talk)` | Story Flag 23 (bit 1) SET AND Story Flag 23 (bit 128) CLEAR AND Target Inspected is obj[10] | Engine Action #119; Close Dialogue Window; Reset Camera Tracking (5); Engine Action #6; Warp to Castle HQ (10, 2, 255) |
| `ev[22]` | `1 (Action / Talk)` | Story Flag 23 (bit 128) SET AND Story Flag 20 (bit 128) CLEAR AND Player within Box [32..40, 2..67] AND Condition Check #68 AND Story Flag 1 (mask 255) SET | Recruit Character into Active Party (58 [Gijimu], 118); Engine Action #9; Close Dialogue Window; Reset Camera Tracking (5); Open Dialogue Message Window; Engine Action #5; Open Dialogue Message Window; Exit to World Map (4, 5, 15); Warp to Castle HQ (0, 5, 5); Open Dialogue Message Window; Warp to Castle HQ (30, 58, 255) |
| `ev[23]` | `1 (Action / Talk)` | Story Flag 23 (bit 128) SET AND Story Flag 20 (bit 128) CLEAR AND Player within Box [33..39, 2..54] AND Condition Check #55 AND Story Flag 0 (mask 255) SET | Recruit Character into Active Party (58 [Gijimu], 118); Close Dialogue Window; Close Dialogue Window; Reset Camera Tracking (5); Open Dialogue Message Window; Engine Action #5; Open Dialogue Message Window; Exit to World Map (4, 5, 15); Warp Town -> Area 0 Map 5 Submap 5 at (1,3); Dismiss Emotion Bubble (58) |
| `ev[24]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Player within Box [59..61, 2..74] AND Condition Check #74 | Launch Tactical War Battle (1); Warp Room -> Submap 2 at (12,10); Engine Action #54; Open Dialogue Message Window; Warp Room -> Submap 1 at (3,0) facing South (Down); Engine Action #122; Warp Room -> Submap 0 at (0,172) facing 55 |
| `ev[25]` | `128 (Loop)` | Story Flag 20 (bit 128) SET AND Inventory Holds Item #1 [Medicine] | Close Dialogue Window; Warp Town -> Area 2 Map 90 Submap 37 at (1,255) |
| `ev[26]` | `1 (Action / Talk)` | Condition Check #33 AND Player Y within Range [3..5] AND Temp Event Flag #255 CLEAR | Dismiss Character to Castle Base (47 [Genshu]); Dismiss Emotion Bubble (24); Reset Camera Tracking (1); Place Scenery Structure (5); Reset Camera Tracking (5); Show Dialogue Portrait (0, 0, 30) |
| `ev[27]` | `1 (Action / Talk)` | Condition Check #33 AND Player within Box [4..4, 23..8] AND Target Inspected is obj[8] | Recruit Character into Active Party (43 [Ayda], 0); Exit to World Map (55, 0, 27); Set Special Scene BGM (8); Warp to Castle HQ (0, 2, 3); Reset Camera Tracking (3); Dismiss Character to Castle Base (47 [Genshu]); Dismiss Emotion Bubble (73); Show Dialogue Portrait (24, 8, 1); Open Dialogue Message Window; Set Combat Battle BGM (15); Set Combat Battle BGM (20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 1 Map 1 Submap 1 at (2,73); Show Dialogue Portrait (41, 2, 0); Warp Room -> Submap 0 at (24,8) facing West (Left); Exit to World Map (73, 15, 73); Branch on Choice (40, 0); Open Dialogue Message Window; Warp Town -> Area 1 Map 6 Submap 1 at (5,73); Show Dialogue Portrait (41, 2, 3); Exit to World Map (255, 3, 24); Reset Camera Tracking (1); Pan Camera (5, 8, 5); Show Dialogue Portrait (0, 0, 30); Engine Action #51; Warp Town -> Area 255 Map 4 Submap 24 at (8,1); Reset Camera Tracking (73); Trigger Character Emotion Effect (30, 0); Open Dialogue Message Window; Award Potch Loot (+517 Potch); Engine Action #6; Engine Action #5; Close Dialogue Sub-Window (8); Warp Room -> Submap 73 at (15,46) facing 115; Teleport obj[49] to (84,47); Dismiss Emotion Bubble (84); Teleport obj[31] to (47,5); Open Dialogue Message Window; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 101, 4); Engine Action #6; Engine Action #5; Open Dialogue Message Window; Warp Town -> Area 0 Map 5 Submap 3 at (1,0); Engine Action #5; Warp to Castle HQ (3, 0, 5); Warp to Castle HQ (0, 0, 5); Warp to Castle HQ (30, 89, 0); Warp Town -> Area 8 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Engine Action #89; Open Dialogue Message Window; Warp Town -> Area 9 Map 5 Submap 0 at (6,2); Dismiss Emotion Bubble (89); Open Dialogue Message Window; Warp Town -> Area 10 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Dismiss Emotion Bubble (1); Warp Room -> Submap 5 at (0,0) facing South (Down); Engine Action #5; Show Dialogue Portrait (2, 0, 30); Set Combat Battle BGM (15); Close Dialogue Sub-Window (8); Warp Room -> Submap 73 at (15,11) facing Up (North); Warp Town -> Area 40 Map 1 Submap 8 at (3,0); Open Dialogue Message Window; Close Dialogue Window; Warp Room -> Submap 40 at (51,2) facing 255; Engine Action #6; Close Dialogue Sub-Window (8); Warp Room -> Submap 5 at (8,5) facing 15; Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (51); Warp Town -> Area 58 Map 255 Submap 254 at (255,1); Close Dialogue Sub-Window (8); Warp Room -> Submap 5 at (8,5) facing 15; Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (255); Warp Town -> Area 9 Map 23 Submap 8 at (58,255) |
| `ev[28]` | `1 (Action / Talk)` | Condition Check #33 AND Player within Box [4..3, 23..8] AND Target Inspected is obj[8] | Recruit Character into Active Party (43 [Ayda], 0); Exit to World Map (55, 0, 27); Set Special Scene BGM (8); Warp to Castle HQ (0, 2, 3); Reset Camera Tracking (3); Dismiss Character to Castle Base (47 [Genshu]); Dismiss Emotion Bubble (73); Show Dialogue Portrait (24, 8, 1); Display Dialogue Box [Bank: 73, MsgID: 15]; Set Combat Battle BGM (20); Engine Action #40; Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 1 Map 1 Submap 1 at (2,73); Show Dialogue Portrait (41, 2, 0); Warp Room -> Submap 0 at (24,8) facing West (Left); Exit to World Map (73, 15, 73); Branch on Choice (40, 0); Open Dialogue Message Window; Warp Town -> Area 1 Map 6 Submap 1 at (5,73); Show Dialogue Portrait (41, 2, 3); Exit to World Map (255, 3, 24); Reset Camera Tracking (1); Pan Camera (5, 8, 5); Show Dialogue Portrait (0, 0, 30); Engine Action #51; Warp Town -> Area 255 Map 4 Submap 24 at (8,1); Reset Camera Tracking (73); Trigger Character Emotion Effect (30, 0); Open Dialogue Message Window; Award Potch Loot (+517 Potch); Engine Action #6; Engine Action #5; Close Dialogue Sub-Window (8); Warp Room -> Submap 73 at (15,46) facing 115; Teleport obj[49] to (84,47); Dismiss Emotion Bubble (84); Teleport obj[31] to (47,5); Open Dialogue Message Window; Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 101, 4); Engine Action #6; Engine Action #5; Open Dialogue Message Window; Warp Town -> Area 0 Map 5 Submap 3 at (1,0); Engine Action #5; Warp to Castle HQ (3, 0, 5); Warp to Castle HQ (0, 0, 5); Warp to Castle HQ (30, 89, 0); Warp Town -> Area 8 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Engine Action #89; Open Dialogue Message Window; Warp Town -> Area 9 Map 5 Submap 0 at (6,2); Dismiss Emotion Bubble (89); Open Dialogue Message Window; Warp Town -> Area 10 Map 89 Submap 0 at (5,89); Open Dialogue Message Window; Engine Action #5; Set Combat Battle BGM (10); Dismiss Emotion Bubble (1); Warp Room -> Submap 5 at (0,0) facing South (Down); Engine Action #5; Show Dialogue Portrait (2, 0, 30); Set Combat Battle BGM (15); Close Dialogue Sub-Window (8); Warp Room -> Submap 73 at (15,11) facing Up (North); Warp Town -> Area 40 Map 1 Submap 8 at (3,0); Open Dialogue Message Window; Close Dialogue Window; Warp Room -> Submap 40 at (51,2) facing 255; Engine Action #6; Close Dialogue Sub-Window (8); Warp Room -> Submap 5 at (8,5) facing 15; Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (51); Warp Town -> Area 58 Map 255 Submap 254 at (255,1); Close Dialogue Sub-Window (8); Warp Room -> Submap 5 at (8,5) facing 15; Open Dialogue Message Window; Open Dialogue Message Window; Dismiss Emotion Bubble (255); Warp Town -> Area 58 Map 255 Submap 254 at (255,254) |
| `ev[29]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) CLEAR AND Target Inspected is obj[13] | Open Dialogue Sub-Window (3); Engine Action #40 |
| `ev[30]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) SET AND Story Flag 17 (bit 16) CLEAR AND Target Inspected is obj[13] | Open Dialogue Sub-Window (6); Engine Action #40 |
| `ev[31]` | `1 (Action / Talk)` | Story Flag 17 (bit 16) SET AND Story Flag 124 (bit 16) CLEAR AND Target Inspected is obj[13] | Open Dialogue Sub-Window (7); Engine Action #40 |
| `ev[32]` | `1 (Action / Talk)` | Story Flag 124 (bit 16) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[13] | Open Dialogue Sub-Window (8); Engine Action #40 |
| `ev[33]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[13] | Open Dialogue Sub-Window (9); Engine Action #40 |
| `ev[34]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[13] | Open Dialogue Sub-Window (10); Engine Action #40 |
| `ev[35]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) CLEAR AND Target Inspected is obj[14] | Open Dialogue Sub-Window (3); Award Potch Loot (+65,534 Potch) |
| `ev[36]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) SET AND Story Flag 17 (bit 16) CLEAR AND Target Inspected is obj[14] | Open Dialogue Sub-Window (6); Award Potch Loot (+65,534 Potch) |
| `ev[37]` | `1 (Action / Talk)` | Story Flag 17 (bit 16) SET AND Story Flag 124 (bit 16) CLEAR AND Target Inspected is obj[14] | Open Dialogue Sub-Window (7); Award Potch Loot (+65,534 Potch) |
| `ev[38]` | `1 (Action / Talk)` | Story Flag 124 (bit 16) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[14] | Open Dialogue Sub-Window (8); Award Potch Loot (+65,534 Potch) |
| `ev[39]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[14] | Open Dialogue Sub-Window (9); Award Potch Loot (+65,534 Potch) |
| `ev[40]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[14] | Open Dialogue Sub-Window (10); Award Potch Loot (+65,534 Potch) |
| `ev[41]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) CLEAR AND Target Inspected is obj[15] | Open Dialogue Sub-Window (3); Remove Item from Inventory (255, 254) |
| `ev[42]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) SET AND Story Flag 17 (bit 16) CLEAR AND Target Inspected is obj[15] | Open Dialogue Sub-Window (6); Remove Item from Inventory (255, 254) |
| `ev[43]` | `1 (Action / Talk)` | Story Flag 17 (bit 16) SET AND Story Flag 124 (bit 16) CLEAR AND Target Inspected is obj[15] | Open Dialogue Sub-Window (7); Remove Item from Inventory (255, 254) |
| `ev[44]` | `1 (Action / Talk)` | Story Flag 124 (bit 16) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[15] | Open Dialogue Sub-Window (8); Remove Item from Inventory (255, 254) |
| `ev[45]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[15] | Open Dialogue Sub-Window (9); Remove Item from Inventory (255, 254) |
| `ev[46]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[15] | Open Dialogue Sub-Window (10); Remove Item from Inventory (255, 254) |
| `ev[47]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) CLEAR AND Target Inspected is obj[16] | Open Dialogue Sub-Window (3); Open Shop Menu #254 (Type: 255) |
| `ev[48]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) SET AND Story Flag 17 (bit 16) CLEAR AND Target Inspected is obj[16] | Open Dialogue Sub-Window (6); Open Shop Menu #254 (Type: 255) |
| `ev[49]` | `1 (Action / Talk)` | Story Flag 17 (bit 16) SET AND Story Flag 124 (bit 16) CLEAR AND Target Inspected is obj[16] | Open Dialogue Sub-Window (7); Open Shop Menu #254 (Type: 255) |
| `ev[50]` | `1 (Action / Talk)` | Story Flag 124 (bit 16) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[16] | Open Dialogue Sub-Window (8); Open Shop Menu #254 (Type: 255) |
| `ev[51]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[16] | Open Dialogue Sub-Window (9); Open Shop Menu #254 (Type: 255) |
| `ev[52]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[16] | Open Dialogue Sub-Window (10); Open Shop Menu #254 (Type: 255) |
| `ev[53]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) CLEAR AND Target Inspected is obj[17] | Open Dialogue Sub-Window (3); Engine Action #44 |
| `ev[54]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) SET AND Story Flag 17 (bit 16) CLEAR AND Target Inspected is obj[17] | Open Dialogue Sub-Window (6); Engine Action #44 |
| `ev[55]` | `1 (Action / Talk)` | Story Flag 17 (bit 16) SET AND Story Flag 124 (bit 16) CLEAR AND Target Inspected is obj[17] | Open Dialogue Sub-Window (7); Engine Action #44 |
| `ev[56]` | `1 (Action / Talk)` | Story Flag 124 (bit 16) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[17] | Open Dialogue Sub-Window (8); Engine Action #44 |
| `ev[57]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[17] | Open Dialogue Sub-Window (9); Engine Action #44 |
| `ev[58]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[17] | Open Dialogue Sub-Window (10); Engine Action #44 |
| `ev[59]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) CLEAR AND Target Inspected is obj[18] | Open Dialogue Sub-Window (3); Make obj[255] Visible (disp = 1) |
| `ev[60]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) SET AND Story Flag 17 (bit 16) CLEAR AND Target Inspected is obj[18] | Open Dialogue Sub-Window (6); Make obj[255] Visible (disp = 1) |
| `ev[61]` | `1 (Action / Talk)` | Story Flag 17 (bit 16) SET AND Story Flag 124 (bit 16) CLEAR AND Target Inspected is obj[18] | Open Dialogue Sub-Window (7); Make obj[255] Visible (disp = 1) |
| `ev[62]` | `1 (Action / Talk)` | Story Flag 124 (bit 16) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[18] | Open Dialogue Sub-Window (8); Make obj[255] Visible (disp = 1) |
| `ev[63]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[18] | Open Dialogue Sub-Window (9); Make obj[255] Visible (disp = 1) |
| `ev[64]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[18] | Open Dialogue Sub-Window (10); Make obj[255] Visible (disp = 1) |
| `ev[65]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) CLEAR AND Target Inspected is obj[19] | Open Dialogue Sub-Window (3); Make obj[255] Hidden (disp = 0) |
| `ev[66]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) SET AND Story Flag 17 (bit 16) CLEAR AND Target Inspected is obj[19] | Open Dialogue Sub-Window (6); Make obj[255] Hidden (disp = 0) |
| `ev[67]` | `1 (Action / Talk)` | Story Flag 17 (bit 16) SET AND Story Flag 124 (bit 16) CLEAR AND Target Inspected is obj[19] | Open Dialogue Sub-Window (7); Make obj[255] Hidden (disp = 0) |
| `ev[68]` | `1 (Action / Talk)` | Story Flag 124 (bit 16) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[19] | Open Dialogue Sub-Window (8); Make obj[255] Hidden (disp = 0) |
| `ev[69]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[19] | Open Dialogue Sub-Window (9); Make obj[255] Hidden (disp = 0) |
| `ev[70]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[19] | Open Dialogue Sub-Window (10); Make obj[255] Hidden (disp = 0) |
| `ev[71]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) CLEAR AND Target Inspected is obj[20] | Open Dialogue Sub-Window (3); Teleport obj[3] to (20,0) |
| `ev[72]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) CLEAR AND Target Inspected is obj[22] | Open Dialogue Sub-Window (3); Teleport obj[255] to (254,255) |
| `ev[73]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) SET AND Story Flag 17 (bit 16) CLEAR AND Target Inspected is obj[20] | Open Dialogue Sub-Window (6); Teleport obj[3] to (20,0) |
| `ev[74]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) SET AND Story Flag 17 (bit 16) CLEAR AND Target Inspected is obj[22] | Open Dialogue Sub-Window (6); Teleport obj[255] to (254,255) |
| `ev[75]` | `1 (Action / Talk)` | Story Flag 17 (bit 16) SET AND Story Flag 124 (bit 16) CLEAR AND Target Inspected is obj[20] | Open Dialogue Sub-Window (7); Teleport obj[3] to (20,0) |
| `ev[76]` | `1 (Action / Talk)` | Story Flag 17 (bit 16) SET AND Story Flag 124 (bit 16) CLEAR AND Target Inspected is obj[22] | Open Dialogue Sub-Window (7); Teleport obj[255] to (254,255) |
| `ev[77]` | `1 (Action / Talk)` | Story Flag 124 (bit 16) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[20] | Open Dialogue Sub-Window (8); Teleport obj[3] to (20,0) |
| `ev[78]` | `1 (Action / Talk)` | Story Flag 124 (bit 16) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[22] | Open Dialogue Sub-Window (8); Teleport obj[255] to (254,255) |
| `ev[79]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[20] | Open Dialogue Sub-Window (9); Teleport obj[3] to (20,0) |
| `ev[80]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[22] | Open Dialogue Sub-Window (9); Teleport obj[255] to (254,255) |
| `ev[81]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[20] | Open Dialogue Sub-Window (10); Teleport obj[3] to (20,0) |
| `ev[82]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[22] | Open Dialogue Sub-Window (10); Teleport obj[255] to (254,255) |
| `ev[83]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) CLEAR AND Target Inspected is obj[21] | Open Dialogue Sub-Window (3); Turn obj[3] facing 21; Open Dialogue Message Window |
| `ev[84]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) SET AND Story Flag 17 (bit 16) CLEAR AND Target Inspected is obj[21] | Open Dialogue Sub-Window (6); Turn obj[3] facing 21; Open Dialogue Message Window |
| `ev[85]` | `1 (Action / Talk)` | Story Flag 17 (bit 16) SET AND Story Flag 124 (bit 16) CLEAR AND Target Inspected is obj[21] | Open Dialogue Sub-Window (7); Turn obj[3] facing 21; Open Dialogue Message Window |
| `ev[86]` | `1 (Action / Talk)` | Story Flag 124 (bit 16) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[21] | Open Dialogue Sub-Window (8); Turn obj[3] facing 21; Open Dialogue Message Window |
| `ev[87]` | `1 (Action / Talk)` | Story Flag 20 (bit 128) SET AND Story Flag 143 (bit 1) CLEAR AND Target Inspected is obj[21] | Open Dialogue Sub-Window (9); Turn obj[3] facing 21; Open Dialogue Message Window |
| `ev[88]` | `1 (Action / Talk)` | Story Flag 143 (bit 1) SET AND Target Inspected is obj[21] | Open Dialogue Sub-Window (10); Turn obj[3] facing 21; Open Dialogue Message Window |
| `ev[89]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) SET AND Story Flag 17 (bit 16) CLEAR AND Target Inspected is obj[23] | Engine Action #119; Close Dialogue Window; Reset Camera Tracking (6); Engine Action #53 |
| `ev[90]` | `1 (Action / Talk)` | Story Flag 17 (bit 16) SET AND Story Flag 124 (bit 16) CLEAR AND Target Inspected is obj[23] | Engine Action #119; Close Dialogue Window; Reset Camera Tracking (7); Engine Action #53 |
| `ev[91]` | `1 (Action / Talk)` | Story Flag 124 (bit 16) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[23] | Engine Action #119; Close Dialogue Window; Reset Camera Tracking (8); Engine Action #53 |
| `ev[92]` | `1 (Action / Talk)` | Story Flag 14 (bit 128) SET AND Story Flag 17 (bit 16) CLEAR AND Target Inspected is obj[24] | Engine Action #119; Close Dialogue Window; Reset Camera Tracking (6); Engine Action #54 |
| `ev[93]` | `1 (Action / Talk)` | Story Flag 17 (bit 16) SET AND Story Flag 124 (bit 16) CLEAR AND Target Inspected is obj[24] | Engine Action #119; Close Dialogue Window; Reset Camera Tracking (7); Engine Action #54 |
| `ev[94]` | `1 (Action / Talk)` | Story Flag 124 (bit 16) SET AND Story Flag 20 (bit 128) CLEAR AND Target Inspected is obj[24] | Engine Action #119; Close Dialogue Window; Reset Camera Tracking (8); Engine Action #54 |
| `ev[95]` | `1 (Action / Talk)` | Target Inspected is obj[25] | Open Dialogue Sub-Window (4); Warp Room -> Submap 254 at (255,254) facing 204 |
| `ev[96]` | `1 (Action / Talk)` | Target Inspected is obj[26] | Open Dialogue Sub-Window (4); Warp Town -> Area 255 Map 254 Submap 255 at (254,204) |
| `ev[97]` | `1 (Action / Talk)` | Target Inspected is obj[27] | Open Dialogue Sub-Window (4); Warp to Castle HQ (255, 254, 255) |
| `ev[98]` | `1 (Action / Talk)` | Target Inspected is obj[28] | Open Dialogue Sub-Window (4); Exit to World Map (255, 254, 255) |
| `ev[99]` | `1 (Action / Talk)` | Target Inspected is obj[29] | Open Dialogue Sub-Window (4); Engine Action #5 |
| `ev[100]` | `1 (Action / Talk)` | Target Inspected is obj[30] | Open Dialogue Sub-Window (4); Engine Action #6 |
| `ev[101]` | `1 (Action / Talk)` | Target Inspected is obj[31] | Open Dialogue Sub-Window (4); Pan Camera (255, 254, 255) |
| `ev[102]` | `1 (Action / Talk)` | Target Inspected is obj[32] | Open Dialogue Sub-Window (4); Reset Camera Tracking (255) |
| `ev[103]` | `1 (Action / Talk)` | Target Inspected is obj[33] | Open Dialogue Sub-Window (4); Engine Action #9 |
| `ev[104]` | `1 (Action / Talk)` | Target Inspected is obj[34] | Open Dialogue Sub-Window (4); Screen Fade Transition (255, 254, 255) |
| `ev[105]` | `1 (Action / Talk)` | Target Inspected is obj[35] | Open Dialogue Sub-Window (4); Close Dialogue Window |
| `ev[106]` | `1 (Action / Talk)` | Target Inspected is obj[36] | Open Dialogue Sub-Window (4); Display Dialogue Box [Bank: 255, MsgID: 254] |
| `ev[107]` | `1 (Action / Talk)` | Target Inspected is obj[37] | Open Dialogue Sub-Window (4); Place Scenery Structure (255) |
| `ev[108]` | `1 (Action / Talk)` | Target Inspected is obj[38] | Open Dialogue Sub-Window (4); Animate Door Open |
| `ev[109]` | `1 (Action / Talk)` | Target Inspected is obj[39] | Open Dialogue Sub-Window (4); Show Dialogue Portrait (255, 254, 255) |
| `ev[110]` | `1 (Action / Talk)` | Target Inspected is obj[40] | Open Dialogue Sub-Window (4); Dismiss Dialogue Portrait |
| `ev[111]` | `1 (Action / Talk)` | Target Inspected is obj[41] | Open Dialogue Sub-Window (4); Change Portrait Expression (255) |
| `ev[112]` | `1 (Action / Talk)` | Target Inspected is obj[42] | Open Dialogue Sub-Window (4); Display Speaker Name Box (255) |
| `ev[113]` | `1 (Action / Talk)` | Target Inspected is obj[43] | Open Dialogue Sub-Window (4); Display Choice Selection (255, 254) |
| `ev[114]` | `1 (Action / Talk)` | Target Inspected is obj[44] | Open Dialogue Sub-Window (4); Branch on Choice (255, 254) |
| `ev[115]` | `1 (Action / Talk)` | Target Inspected is obj[45] | Open Dialogue Sub-Window (4); Execute Choice Result (255) |
| `ev[116]` | `1 (Action / Talk)` | Target Inspected is obj[46] | Open Dialogue Sub-Window (4); Set Story Flag (255, 254) |
| `ev[117]` | `1 (Action / Talk)` | Target Inspected is obj[47] | Open Dialogue Sub-Window (4); Open Dialogue Sub-Window (255) |
| `ev[118]` | `1 (Action / Talk)` | Target Inspected is obj[48] | Open Dialogue Sub-Window (4); Close Dialogue Sub-Window (255) |
| `ev[119]` | `1 (Action / Talk)` | Target Inspected is obj[49] | Open Dialogue Sub-Window (4); Clear Dialogue Sub-Window |
| `ev[120]` | `1 (Action / Talk)` | Target Inspected is obj[50] | Open Dialogue Sub-Window (4); Fade In from Black (255) |

---



## Location Map: `vc19`

- **Master Map Container**: `vc19.json`
- **Submap Layer Files**: vc19_00.json, vc19_01.json, vc19_02.json
- **Collision Grid Files**: vc19_map_00.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 1

### Submap Layer `vc19_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `13` Objects | **Script Count (`evkaz`)**: `22` Scripts

#### Complete Physical Entity Inventory (13 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | NPC / Actor | **Flik** | `5` | `(33, 14)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[01]` | NPC / Actor | **Richmond** | `38` | `(33, 14)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[02]` | NPC / Actor | **Humphrey Mintz** | `100` | `(33, 14)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 3 | 255 | 0 |
| `obj[03]` | World Device | **Mechanism (ano 1)** | `0` | `(46, 30)` | `0x0` | West (Left) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[04]` | World Device | **Mechanism (ano 23)** | `0` | `(20, 48)` | `0x0` | Frame 23 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[05]` | World Device | **Mechanism (ano 22)** | `0` | `(20, 48)` | `0x0` | Frame 22 | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[06]` | Trigger / Hitbox | **Hitbox Zone (1x2)** | `0` | `(40, 29)` | `0x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[07]` | Trigger / Hitbox | **Hitbox Zone (5x2)** | `0` | `(31, 22)` | `4x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[08]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(37, 28)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[09]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(37, 26)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[10]` | Trigger / Hitbox | **Hitbox Zone (2x2)** | `0` | `(37, 24)` | `1x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[11]` | Trigger / Hitbox | **Hitbox Zone (1x2)** | `0` | `(43, 29)` | `0x1` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |
| `obj[12]` | Trigger / Hitbox | **Hitbox Zone (1x6)** | `0` | `(50, 30)` | `0x5` | South (Down) | Visible (1) | Passable (0) | 4 | 255 | 0 |


#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]` (Flik)**: Positioned at tile `(33, 14)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[01]` (Richmond)**: Positioned at tile `(33, 14)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[02]` (Humphrey Mintz)**: Positioned at tile `(33, 14)`, facing South (Down). Dormant/hidden initially; made visible dynamically by event flags. Features solid obstacle physics (`ozok: 2`), requiring the player to interact from an adjacent tile.
- **`obj[03]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(46, 30)` with state parameter `1`.
- **`obj[04]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(20, 48)` with state parameter `23`.
- **`obj[05]` (World Device: Invisible / Hitbox Trigger)**: Interactive mechanism at tile `(20, 48)` with state parameter `22`.
- **`obj[06]` (Hitbox Zone)**: Bounding trigger area covering `1` tiles wide by `2` tiles high from `(40, 29)` to `(40, 30)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[07]` (Hitbox Zone)**: Bounding trigger area covering `5` tiles wide by `2` tiles high from `(31, 22)` to `(35, 23)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[08]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(37, 28)` to `(38, 29)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[09]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(37, 26)` to `(38, 27)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[10]` (Hitbox Zone)**: Bounding trigger area covering `2` tiles wide by `2` tiles high from `(37, 24)` to `(38, 25)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[11]` (Hitbox Zone)**: Bounding trigger area covering `1` tiles wide by `2` tiles high from `(43, 29)` to `(43, 30)`. Handles doorway warps, counter interactions, and room transitions.
- **`obj[12]` (Hitbox Zone)**: Bounding trigger area covering `1` tiles wide by `6` tiles high from `(50, 30)` to `(50, 35)`. Handles doorway warps, counter interactions, and room transitions.


#### Complete Bytecode Script Catalog (22 Scripts)

| Script | Execution Mode (`etyp`) | Required Preconditions (`eventForm`) | Action Execution Sequence (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | `2 (Map Init)` | Story Flag 59 (bit 16) SET | Make obj[3] Hidden (disp = 0); Open Dialogue Message Window; Warp to Castle HQ (10, 59, 16); Teleport obj[255] to (254,255) |
| `ev[01]` | `2 (Map Init)` | Story Flag 15 (bit 4) CLEAR | Make obj[0] Hidden (disp = 0); Close Dialogue Window; Engine Action #9; Engine Action #151; Warp Map Transition (47, 255, 254, 255, 254) |
| `ev[02]` | `2 (Map Init)` | Story Flag 21 (bit 4) SET | Make obj[0] Hidden (disp = 0); Close Dialogue Window; Engine Action #9; Engine Action #151; Warp Map Transition (47, 255, 254, 255, 254) |
| `ev[03]` | `2 (Map Init)` | Story Flag 21 (bit 2) SET AND Story Flag 21 (bit 4) CLEAR | Make obj[0] Hidden (disp = 0); Display Dialogue Box [Bank: 2, MsgID: 9]; Branch on Choice (29, 0); Engine Action #9; Warp to Castle HQ (9, 0, 2); Screen Fade Transition (23, 30, 0); Screen Fade Transition (3, 10, 0); Teleport obj[255] to (254,255) |
| `ev[04]` | `128 (Loop)` | Player within Box [23..25, 2..18] AND Condition Check #36 AND Story Flag 2 (mask 255) SET | Engine Action #109; Warp Town -> Area 17 Map 255 Submap 254 at (204,204) |
| `ev[05]` | `128 (Loop)` | Player within Box [23..25, 2..18] AND Condition Check #36 AND Story Flag 3 (mask 255) SET | Warp Room -> Submap 1 at (2,22) |
| `ev[06]` | `1 (Action / Talk)` | Player within Box [0..1, 2..19] AND Condition Check #35 AND Story Flag 2 (mask 255) SET | Engine Action #9; Set obj[32] Collision to Passable; Engine Action #151; Warp Map Transition (74, 1, 13, 5, 2); Change Portrait Expression (0); Engine Action #160; Dismiss Emotion Bubble (255) |
| `ev[07]` | `1 (Action / Talk)` | Story Flag 21 (bit 1) CLEAR AND Player within Box [47..49, 2..28] AND Condition Check #29 AND Story Flag 1 (mask 255) SET | Warp Room -> Submap 1 at (2,22); Screen Fade Transition (151, 32, 69); Warp Town -> Area 32 Map 2 Submap 0 at (48,71) |
| `ev[08]` | `1 (Action / Talk)` | Story Flag 15 (bit 4) SET AND Story Flag 15 (bit 8) CLEAR AND Player within Box [32..33, 2..23] AND Condition Check #36 AND Story Flag 3 (mask 255) SET | Recruit Character into Active Party (72 [Siegfried], 1); Open Dialogue Message Window; Open Dialogue Message Window; Set Combat Battle BGM (15); Load Sound Bank into Memory (0, 0); Open Shop Menu #4 (Type: 0); Set Render Priority (pri) (0, 38); Dismiss Emotion Bubble (9); Make obj[3] Hidden (disp = 0); Open Dialogue Message Window; Open Dialogue Message Window; Warp Town -> Area 8 Map 48 Submap 24 at (0,8); Warp to Castle HQ (8, 0, 47); Engine Action #5; Reset Camera Tracking (4); Engine Action #5; Engine Action #5; Dismiss Emotion Bubble (0); Reset Camera Tracking (5); Show Dialogue Portrait (2, 0, 5); Engine Action #5; Warp Room -> Submap 5 at (15,30) facing 24; Reset Camera Tracking (0); Warp Room -> Submap 5 at (8,5); Show Dialogue Portrait (4, 6, 2); Make obj[5] Visible (disp = 1); Dismiss Emotion Bubble (30); Warp Room -> Submap 33 at (2,18) facing 124; Make obj[0] Hidden (disp = 0); Warp Room -> Submap 2 at (47,49) facing Up (North); Engine Action #5; Warp Room -> Submap 5 at (0,3) facing Up (North); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp Room -> Submap 5 at (15,30) facing 255; Engine Action #5; Warp Town -> Area 4 Map 5 Submap 2 at (2,0); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Walk obj[24] to (1,0); Warp Map Transition (73, 30, 39, 34, 9); Show Dialogue Portrait (8, 58, 255) |
| `ev[09]` | `1 (Action / Talk)` | Story Flag 21 (bit 1) SET AND Story Flag 21 (bit 4) CLEAR AND Player within Box [46..50, 2..29] AND Condition Check #30 AND Story Flag 1 (mask 255) SET | Recruit Character into Active Party (33 [Camus], 1); Display Speaker Name Box (0); Warp Room -> Submap 1 at (4,5) facing South (Down); Warp Town -> Area 30 Map 49 Submap 2 at (5,1); Warp Town -> Area 0 Map 5 Submap 5 at (1,0); Dismiss Emotion Bubble (255); Engine Action #5; Open Dialogue Message Window; Warp to Castle HQ (0, 5, 5); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Screen Fade Transition (30, 255, 254); Walk obj[24] to (1,2); Engine Action #5; Engine Action #5; Open Dialogue Message Window; Exit to World Map (4, 0, 2); Dismiss Emotion Bubble (1); Warp Room -> Submap 34 at (255,254) facing 255 |
| `ev[10]` | `1 (Action / Talk)` | Story Flag 21 (bit 2) SET AND Story Flag 21 (bit 4) CLEAR AND Player within Box [0..0, 2..29] AND Condition Check #29 | Recruit Character into Active Party (33 [Camus], 5); Display Speaker Name Box (19); Branch on Choice (21, 124); Make obj[3] Hidden (disp = 0); Open Dialogue Message Window; Warp to Castle HQ (0, 1, 0); Warp Town -> Area 0 Map 3 Submap 0 at (4,0); Engine Action #5; Teleport obj[49] to (5,5); Warp Room -> Submap 7 at (2,1) facing West (Left); Warp Room -> Submap 0 at (30,255) facing 254; Engine Action #5; Warp Town -> Area 4 Map 7 Submap 2 at (1,0); Warp Room -> Submap 0 at (30,255) facing 254; Engine Action #5; Warp to Castle HQ (4, 7, 2); Warp to Castle HQ (0, 2, 3); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Exit to World Map (4, 7, 2); Exit to World Map (1, 1, 3); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Engine Action #5; Engine Action #5; Exit to World Map (7, 2, 5); Warp to Castle HQ (0, 30, 255); Walk obj[36] to (1,49); Reset Camera Tracking (5); Open Dialogue Message Window; Exit to World Map (4, 5, 1); Warp to Castle HQ (14, 30, 255); Engine Action #5; Warp Room -> Submap 4 at (5,5) facing East (Right); Animate Door Open; Dismiss Emotion Bubble (255); Engine Action #5; Warp Town -> Area 4 Map 4 Submap 5 at (10,3); Animate Door Open; Dismiss Emotion Bubble (255); Engine Action #5; Warp to Castle HQ (4, 4, 5); Show Dialogue Portrait (3, 14, 30); Engine Action #5; Exit to World Map (4, 4, 5); Branch on Choice (3, 14); Dismiss Emotion Bubble (255); Engine Action #5; Engine Action #5; Exit to World Map (4, 5, 25); Warp to Castle HQ (14, 30, 255); Engine Action #5; Engine Action #9; Engine Action #5; Walk obj[2] to (0,30); Engine Action #5; Screen Fade Transition (5, 65, 2); Open Dialogue Message Window; Dismiss Emotion Bubble (255); Walk obj[24] to (9,0); Wait for Audio / Window Sync (73); Show Dialogue Portrait (24, 3, 0); Recruit Hero #73 into Battle Slot 15; Close Dialogue Sub-Window (9); Open Dialogue Message Window; Remove Character from Active Party (73); Show Dialogue Portrait (24, 10, 0); Load Sound Bank into Memory (73, 15); Set Entity Movement Speed (8, 5); Screen Fade Transition (4, 4, 0); Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp to Castle HQ (12, 0, 15); Dismiss Emotion Bubble (1); Screen Fade Transition (255, 254, 5); Engine Action #9; Exit to World Map (4, 5, 5); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Engine Action #5; Warp to Castle HQ (15, 0, 16); Dismiss Emotion Bubble (1); Engine Action #9; Engine Action #5; Open Dialogue Message Window; Exit to World Map (4, 5, 16); Warp to Castle HQ (21, 30, 44); Launch Tactical War Battle (4); Engine Action #5; Open Dialogue Message Window; Exit to World Map (4, 0, 16); Dismiss Emotion Bubble (1); Open Dialogue Message Window; Engine Action #5; Warp Room -> Submap 4 at (5,16) facing East (Right); Set Story Flag (0, 17); Dismiss Emotion Bubble (1); Warp Room -> Submap 254 at (5,2) facing 4; Exit to World Map (5, 1, 3); Set Story Flag (0, 15); Dismiss Emotion Bubble (1); Warp Town -> Area 255 Map 254 Submap 5 at (3,4); Exit to World Map (5, 38, 3); Close Dialogue Sub-Window (0); Animate Door Open; Dismiss Emotion Bubble (1); Warp to Castle HQ (255, 254, 5); Exit to World Map (4, 4, 5); Toggle Random Encounters (3); Clear Dialogue Sub-Window; Open Dialogue Message Window; Change Portrait Expression (30); Warp Room -> Submap 255 at (254,5) facing 5; Exit to World Map (4, 5, 30); Warp to Castle HQ (26, 0, 16); Dismiss Emotion Bubble (1); Engine Action #5; Walk obj[36] to (128,73); Dismiss Emotion Bubble (36); Warp Town -> Area 46 Map 0 Submap 13 at (1,12); Teleport obj[90] to (13,4); Warp to Castle HQ (19, 45, 30); Engine Action #54; Open Dialogue Message Window; Warp Town -> Area 10 Map 151 Submap 32 at (11,2); Warp Town -> Area 120 Map 54 Submap 0 at (128,69); Warp to Castle HQ (122, 1, 32); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #172; Engine Action #54; Engine Action #58 |
| `ev[11]` | `128 (Loop)` | Story Flag 21 (bit 2) SET AND Story Flag 21 (bit 4) CLEAR AND Inventory Holds Item #1 [Medicine] | Close Dialogue Window; Warp Room -> Submap 40 at (37,1) facing 255 |
| `ev[12]` | `128 (Loop)` | Story Flag 21 (bit 2) SET AND Story Flag 21 (bit 4) CLEAR AND Inventory Holds Item #2 [Mega Medicine] | Set Combat Battle BGM (180); Make obj[2] Hidden (disp = 0); Reset Camera Tracking (5); Start Boss Battle #0 (BGM: 8); Warp to Castle HQ (8, 3, 47); Engine Action #5; Reset Camera Tracking (4); Engine Action #5; Warp to Castle HQ (17, 30, 24); Reset Camera Tracking (0); Set Combat Battle BGM (5); Reset Camera Tracking (4); Engine Action #6; Warp to Castle HQ (26, 5, 120); Open Dialogue Message Window; Open Dialogue Message Window; Engine Action #5; Show Dialogue Portrait (30, 37, 2) |
| `ev[13]` | `128 (Loop)` | Story Flag 21 (bit 2) SET AND Story Flag 21 (bit 4) CLEAR AND Inventory Holds Item #4 [Throat Drops] | Display Chapter Text (0); Show Dialogue Portrait (4, 37, 4) |
| `ev[14]` | `128 (Loop)` | Story Flag 21 (bit 2) SET AND Story Flag 21 (bit 4) CLEAR AND Inventory Holds Item #128 | Warp Room -> Submap 2 at (12,10); Toggle Random Encounters (128) |
| `ev[15]` | `1 (Action / Talk)` | Target Inspected is obj[14] | Open Dialogue Sub-Window (1); Warp Room -> Submap 255 at (254,255) |
| `ev[16]` | `1 (Action / Talk)` | Target Inspected is obj[15] | Open Dialogue Sub-Window (1); Warp Map Transition (255, 254, 255, 254, 204) |
| `ev[17]` | `1 (Action / Talk)` | Target Inspected is obj[16] | Open Dialogue Sub-Window (1); Return to Previous Memory Map (255) |
| `ev[18]` | `1 (Action / Talk)` | Target Inspected is obj[17] | Open Dialogue Sub-Window (1); Return Warp to Castle Base (255, 254) |
| `ev[19]` | `1 (Action / Talk)` | Target Inspected is obj[18] | Open Dialogue Sub-Window (1); Start Boss Battle #255 (BGM: 254) |
| `ev[20]` | `1 (Action / Talk)` | Target Inspected is obj[19] | Open Dialogue Sub-Window (1); Launch Tactical War Battle (255) |
| `ev[21]` | `1 (Action / Talk)` | Target Inspected is obj[20] | Open Dialogue Sub-Window (1); Toggle Random Encounters (255) |

---


