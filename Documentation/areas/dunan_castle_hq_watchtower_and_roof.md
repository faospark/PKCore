# Suikoden II Geographic Area Catalog: Castle HQ: Watchtower & High Roof

**Geographic Scope & Role**: High castle battlements & rooftop watchtower; high flagpole overlook with panoramic cloud layers (`t_vk15_00_cloud`, `obj_clouds`, `obj_book1..book4`). Location of the dramatic nighttime conversation between Riou and Nanami reminiscing about childhood in Kyaro and Jowy (Text IDs `1007080135`–`1007080155`), with an apparition/flashback sprite of Jowy (`fpno 18` / `fpno 2`). Features HQ tier progression locks (`base_lv >= 2` and `base_lv >= 3`) and stairs warping back down to Great Hall interior `vk10`.

**Regional Category**: Region `VK` | **Master Maps Included**: `vk15`

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

## Location Map: `vk15`

- **Master Map Container**: `vk15.json`
- **Submap Layer Files**: Embedded in master
- **Collision Grid Files**: vk15_map_00.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 1

### Submap Layer `vk15_00` (Index 0)

- **Map Number (`mapno`)**: `0`
- **Battle Encounter Zone (`batlno`)**: `0` (Timer: `0`, Rate: `0`)
- **Entity Count (`okaz`)**: `13` Objects | **Script Count (`evkaz`)**: `30` Scripts

#### Complete Physical Entity Inventory (13 Objects)

| Slot | Class (`otyp`) | Identity / Description | Sprite Pattern (`fpno`) | Coords (`x, y`) | Size (`w, h`) | Facing (`ano`) | State (`disp`) | Collision (`ozok`) | Speed | Wait | Priority |
|:---:|---|---|:---:|:---:|:---:|---|---|---|:---:|:---:|:---:|
| `obj[00]` | Prop / Scenery | **Prop ID 64769** | `64769` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) (32) | 4 | 255 | 0 |
| `obj[01]` | Prop / Scenery | **Prop ID 64769** | `64769` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) (32) | 4 | 255 | 0 |
| `obj[02]` | Prop / Scenery | **Prop ID 64769** | `64769` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) (32) | 4 | 255 | 0 |
| `obj[03]` | Prop / Scenery | **Nanami (Home/Rooftop)** | `50` | `(40, 20)` | `0x0` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[04]` | Trigger / Hitbox | **Hitbox Zone (5x5)** | `0` | `(44, 16)` | `4x4` | South (Down) | Dormant / Hidden (0) | Passable (0) | 4 | 255 | 0 |
| `obj[05]` | NPC / Actor | **Jowy (Flashback Memory)** | `18` | `(37, 38)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[06]` | NPC / Actor | **Riou (Staged)** | `48` | `(22, 22)` | `0x0` | Up (North) | Dormant / Hidden (0) | Solid (Obstacle) (34) | 4 | 255 | 0 |
| `obj[07]` | Prop / Scenery | **Prop ID 33072** | `33072` | `(0, 0)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) (32) | 4 | 255 | 0 |
| `obj[08]` | NPC / Actor | **Jowy Atreides (Flashback)** | `2` | `(29, 30)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[09]` | NPC / Actor | **Emilia** | `55` | `(27, 24)` | `0x0` | South (Down) | Dormant / Hidden (0) | Solid (Obstacle) | 4 | 255 | 0 |
| `obj[10]` | Prop / Scenery | **Flag / Lookout Overlook Prop** | `64769` | `(36, 34)` | `2x3` | East (Right) | Dormant / Hidden (0) | Special (3) | 1 | 255 | 0 |
| `obj[11]` | Prop / Scenery | **Flag / Lookout Overlook Prop** | `64769` | `(32, 27)` | `6x3` | Up (North) | Dormant / Hidden (0) | Special (3) | 1 | 255 | 0 |
| `obj[12]` | Prop / Scenery | **Flag / Lookout Overlook Prop** | `64769` | `(41, 24)` | `6x3` | South (Down) | Dormant / Hidden (0) | Special (3) | 1 | 255 | 0 |

#### Entity Narrative Roles, Placements & Mechanics

- **`obj[00]–[02]` & `obj[07]` (Environmental Props)**: Environmental world dressing and panorama backdrop anchors placed at tile `(0, 0)`.
- **`obj[03]` (Nanami)**: Staged at tile `(40, 20)` for the night terrace conversation.
- **`obj[04]` (Hitbox Zone)**: Bounding trigger area covering `5x5` tiles from `(44, 16)` to `(48, 20)`. Handles boundary detection and scene triggering.
- **`obj[05]` & `obj[08]` (Jowy Atreides - Flashback / Cutscene Staging)**: Positioned at tiles `(37, 38)` and `(29, 30)` as memory/flashback sprites invoked during the late-night reflection scene when Nanami reminisces about Kyaro.
- **`obj[06]` (Riou)**: Staged actor representation at tile `(22, 22)`.
- **`obj[09]` (Emilia)**: Castle surveyor / records keeper staged at `(27, 24)`.
- **`obj[10]–[12]` (Overlook Railings & Flagpole Fixtures)**: Large physical bounding props at `(36, 34)`, `(32, 27)`, and `(41, 24)` representing the high battlement railings and flagpole rigging overlooking Lake Toran.

---

### Key Story Event Sequences & Dialogue Grounding

#### Night Watchtower Reminiscence Scene (`ev[04]`, `ev[08]`)
- **Preconditions**: Flags `118` bit 8 SET, `119` bit 1 CLEAR, `145` bit 32 CLEAR.
- **Narrative**: Riou visits the high castle roof at night before the major campaign against Luca Blight. Nanami joins him, opening Dialogue Sequence `1007080135`–`1007080155`:
  - Nanami asks: *"Hey, what do you think of what Jess said? Where do we belong? Everyone treated us well enough in Highland, but they were always distant somehow..."*
  - Nanami begs Riou to step down: *"Riou, let's stop this fighting... If we keep going on like this, if things keep going as they are, you and Jowy will..."*
  - Offers the option to escape together to somewhere far away, promising that *"once all this blows over... we'll bring Jowy back to join us. Just like in the old days when Grandpa was still around, and you and Jowy..."*
  - Upon Riou staying resolute, she laughs it off to cheer him up and tells him to get some rest for tomorrow's dawn assembly.
- **HQ Level Progression Checks**:
  - `ev[00]`, `ev[01]`, `ev[02]`: Require `base_lv >= 3` (`[33, 1, 3]`).
  - `ev[18]..ev[26]`: Require `base_lv >= 2` (`[33, 1, 2]`).
- **Warps & Exits**:
  - `ev[16]`: Stairs portal `(36..44, 2..30)` warps back down to Great Hall interior `vk10`.
