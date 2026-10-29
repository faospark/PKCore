## 5. The 50 Cut "Castle Level 5" Scripts (`base_lv >= 4`)
### 5.1 The Internal 0-Indexed Castle Progression Architecture
In `GSD2.GAME_DATA`, the castle headquarters progression level is tracked by the single-byte field `byte base_lv` (located at offset `0x2C`):

- `base_lv == 0`: **Tier 1** (Mercenary Fort / Early North Window Ruins)
- `base_lv == 1`: **Tier 2** (North Window Castle established with initial recruits)
- `base_lv == 2`: **Tier 3** (Mid-game expansion after Two River / Greenhill campaigns)
- `base_lv == 3`: **Tier 4** (The Grand Fortress — **The Hard Retail Cap**)
- `base_lv == 4`: **Tier 5** (**The Cut 5th Expansion Tier**)

In the retail game release, `base_lv` reaches a mathematical ceiling of `3`. It is never incremented to `4` under any story milestone, recruit count, or progression trigger. Consequently, exactly **50 distinct event scripts** distributed across 10 castle maps are stranded in the compiled binary as unreachable dead code.

### 5.2 Precondition & Command Bytecode Anatomy
The 50 scripts evaluate castle tier via **Opcode 33** inside their `eventForm` precondition bytecode array:

$$\text{Condition: } [33, \text{cmp\_op}, \text{threshold}]$$

- `[33, 1, 4]`: Evaluates `base_lv >= 4` (Tier 5 or higher)
- `[33, 0, 4]`: Evaluates `base_lv == 4` (Strict Tier 5 equality)

Trigger mechanisms (`etyp`) across the 50 scripts:
- **40 scripts with `etyp = 2`** (Map Initialization / Autorun): Execute immediately when the submap loads into memory to spawn props, NPCs, or apply tile overlays.
- **8 scripts with `etyp = 1`** (Interactive Action / Inspect): Triggered when the player stands facing the coordinate or object and presses the Action button.
- **2 scripts with `etyp = 128`** (Trigger / Zone Step-On): Triggered when the player's bounding box steps onto the tile coordinate (used for doorways and map transitions).

--- 

### 5.3 Granular Facility-by-Facility Forensic Breakdown of All 50 Scripts

#### 5.3.1 VK02: HQ Lower Floors (Vault, Richmond Detective Agency & Corridors) (9 Scripts)

Contains 9 cut scripts across 6 submaps. In Tier 5, Konami planned a major expansion of the Castle Vault (Submap 1), Richmond's Detective Agency (Submap 7), the B1 Storage Hallway (Submap 8), the East Wing Corridor (Submap 9), the West Wing Corridor (Submap 10), and the Library Archive Hallway (Submap 11). In retail, all target object indices (Objects 18, 19, 20, 21, 25, 26) were trimmed from the ends of their respective `eventobj` arrays, leaving behind ghost spawn scripts.

| # | Script ID | Type (`etyp`) | Decoded Precondition (`eventForm`) | Decoded Commands (`eventCom`) | Target Object & Status |
|---|---|---|---|---|---|
| 01 | `sub[1] ev[36]` | MapInit (Autorun On Load) | `FlagIsSet(112, bit 0x40) AND CastleTier >= 4` | `[0, 20, 255, 254, 204, 204, 204, 204]` | Obj[20] (**Truncated**, max=19) |
| 02 | `sub[7] ev[19]` | MapInit (Autorun On Load) | `FlagIsSet(112, bit 0x40) AND CastleTier >= 4` | `[0, 20, 255, 254, 204, 204, 204, 204]` | Obj[20] (**Truncated**, max=13) |
| 03 | `sub[8] ev[6]` | MapInit (Autorun On Load) | `FlagIsSet(112, bit 0x40) AND CastleTier >= 4` | `[0, 19, 255, 254, 204, 204, 204, 204]` | Obj[19] (**Truncated**, max=12) |
| 04 | `sub[9] ev[32]` | MapInit (Autorun On Load) | `FlagIsSet(112, bit 0x40) AND CastleTier >= 4` | `[0, 25, 255, 254, 204, 204, 204, 204]` | Obj[25] (**Truncated**, max=18) |
| 05 | `sub[9] ev[33]` | MapInit (Autorun On Load) | `FlagIsSet(112, bit 0x40) AND CastleTier >= 4` | `[0, 26, 255, 254, 204, 204, 204, 204]` | Obj[26] (**Truncated**, max=18) |
| 06 | `sub[10] ev[13]` | MapInit (Autorun On Load) | `FlagIsSet(112, bit 0x40) AND CastleTier >= 4` | `[0, 26, 255, 254, 204, 204, 204, 204]` | Obj[26] (**Truncated**, max=18) |
| 07 | `sub[11] ev[22]` | MapInit (Autorun On Load) | `FlagIsSet(112, bit 0x40) AND CastleTier >= 4` | `[0, 18, 255, 254, 204, 204, 204, 204]` | Obj[18] (**Truncated**, max=17) |
| 08 | `sub[11] ev[25]` | MapInit (Autorun On Load) | `FlagIsSet(112, bit 0x40) AND CastleTier >= 4` | `[0, 21, 255, 254, 204, 204, 204, 204]` | Obj[21] (**Truncated**, max=17) |
| 09 | `sub[11] ev[29]` | MapInit (Autorun On Load) | `FlagIsSet(112, bit 0x40) AND CastleTier >= 4` | `[0, 25, 255, 254, 204, 204, 204, 204]` | Obj[25] (**Truncated**, max=17) |

#### 5.3.2 VK03: HQ Farm & Pasture Enclosure (Yuzu's Animal Sanctuary) (7 Scripts)

Contains 7 cut scripts in Submap 0. In Tier 5, Yuzu's animal farm received four extra grazing livestock animals (Objects 41, 42, 43, 44) placed via Opcode 46 (`ECOverlayPset`) and three additional enclosure fence props (Objects 38, 39, 40). Unlike other maps, Objects 38, 39, and 40 still exist in the `eventobj` array at coordinates (66,20), (68,20), and (70,20) with `disp: 0` (hidden), permanently awaiting a Tier 5 activation trigger that never fires.

| # | Script ID | Type (`etyp`) | Decoded Precondition (`eventForm`) | Decoded Commands (`eventCom`) | Target Object & Status |
|---|---|---|---|---|---|
| 10 | `sub[0] ev[107]` | MapInit (Autorun On Load) | `FlagIsSet(112, bit 0x40) AND CastleTier >= 4` | `[0, 38, 255, 254, 204, 204, 204, 204]` | Obj[38] (Exists, `disp: 0`) |
| 11 | `sub[0] ev[108]` | MapInit (Autorun On Load) | `FlagIsSet(112, bit 0x40) AND CastleTier >= 4` | `[0, 39, 255, 254, 204, 204, 204, 204]` | Obj[39] (Exists, `disp: 0`) |
| 12 | `sub[0] ev[109]` | MapInit (Autorun On Load) | `FlagIsSet(112, bit 0x40) AND CastleTier >= 4` | `[0, 40, 255, 254, 204, 204, 204, 204]` | Obj[40] (Exists, `disp: 0`) |
| 13 | `sub[0] ev[110]` | MapInit (Autorun On Load) | `FlagIsSet(112, bit 0x40) AND ObjPosCheck(val1=26, val2=16) AND Op25 AND Op25 AND CastleTier >= 4` | `[46, 0, 41, 0, 45, 47, 255, 254, 204, 204, 204, 204]` | Tile Overlay on Obj[41] (**Truncated**, max=40) |
| 14 | `sub[0] ev[111]` | MapInit (Autorun On Load) | `FlagIsSet(112, bit 0x40) AND ObjPosCheck(val1=26, val2=16) AND Op25 AND Op25 AND CastleTier >= 4` | `[46, 0, 42, 0, 46, 47, 255, 254, 204, 204, 204, 204]` | Tile Overlay on Obj[42] (**Truncated**, max=40) |
| 15 | `sub[0] ev[112]` | MapInit (Autorun On Load) | `FlagIsSet(112, bit 0x40) AND ObjPosCheck(val1=26, val2=16) AND Op25 AND Op25 AND CastleTier >= 4` | `[46, 0, 43, 0, 47, 47, 255, 254, 204, 204, 204, 204]` | Tile Overlay on Obj[43] (**Truncated**, max=40) |
| 16 | `sub[0] ev[113]` | MapInit (Autorun On Load) | `FlagIsSet(112, bit 0x40) AND ObjPosCheck(val1=26, val2=16) AND Op25 AND Op25 AND CastleTier >= 4` | `[46, 0, 44, 0, 48, 47, 255, 254, 204, 204, 204, 204]` | Tile Overlay on Obj[44] (**Truncated**, max=40) |

#### 5.3.3 VK04: HQ 2F: Tavern, Bar & Kitchen Facility (2 Scripts)

Contains 2 cut scripts in Submap 0 (`ev[22]` and `ev[23]`). In Tier 5, the tavern received two additional patrons/tables (Objects 47 and 48). The `eventobj` array in retail terminates at 41 objects (indices 0..40), confirming that Objects 47 and 48 were severed during final asset compilation.

| # | Script ID | Type (`etyp`) | Decoded Precondition (`eventForm`) | Decoded Commands (`eventCom`) | Target Object & Status |
|---|---|---|---|---|---|
| 17 | `sub[0] ev[22]` | MapInit (Autorun On Load) | `FlagIsSet(112, bit 0x40) AND CastleTier >= 4` | `[0, 47, 255, 254, 204, 204, 204, 204]` | Obj[47] (**Truncated**, max=40) |
| 18 | `sub[0] ev[23]` | MapInit (Autorun On Load) | `FlagIsSet(112, bit 0x40) AND CastleTier >= 4` | `[0, 48, 255, 254, 204, 204, 204, 204]` | Obj[48] (**Truncated**, max=40) |

#### 5.3.4 VK08: HQ Waterfront Docks & Boat Landing (1 Scripts)

Contains 1 cut script in Submap 0 (`ev[42]`). In Tier 5, an additional harbour cargo prop or dockworker NPC (Object 32) was scheduled to spawn. The retail `eventobj` array holds 25 objects (indices 0..24), leaving Object 32 orphaned.

| # | Script ID | Type (`etyp`) | Decoded Precondition (`eventForm`) | Decoded Commands (`eventCom`) | Target Object & Status |
|---|---|---|---|---|---|
| 19 | `sub[0] ev[42]` | MapInit (Autorun On Load) | `FlagNotSet(144, bit 0x04) AND CastleTier >= 4 AND FlagIsSet(112, bit 0x40)` | `[0, 32, 255, 254, 204, 204, 204, 204]` | Obj[32] (**Truncated**, max=24) |

#### 5.3.5 VK09: HQ Central Courtyard: Main Entrance, Gates & Outer Grounds (5 Scripts)

Contains 5 cut scripts in Submap 0 (`ev[62..65, 67]`). In Tier 5, the castle entrance and garden perimeter were upgraded with two new decorative tile banners/shrines (Objects 37 and 38) placed via Opcode 46 (`ECOverlayPset`), along with an extra castle perimeter sentry guard (Object 40). The retail `eventobj` array stops at 36 objects (indices 0..35).

| # | Script ID | Type (`etyp`) | Decoded Precondition (`eventForm`) | Decoded Commands (`eventCom`) | Target Object & Status |
|---|---|---|---|---|---|
| 20 | `sub[0] ev[62]` | MapInit (Autorun On Load) | `CastleTier >= 4 AND FlagIsSet(112, bit 0x40) AND ObjStateCheck(val1=27, val2=8)` | `[46, 0, 37, 47, 255, 254, 204, 204, 204, 204]` | Tile Overlay on Obj[37] (**Truncated**, max=35) |
| 21 | `sub[0] ev[63]` | MapInit (Autorun On Load) | `CastleTier >= 4 AND FlagIsSet(112, bit 0x40) AND ObjPosCheck(val1=27, val2=8)` | `[0, 37, 255, 254, 204, 204, 204, 204]` | Obj[37] (**Truncated**, max=35) |
| 22 | `sub[0] ev[64]` | MapInit (Autorun On Load) | `CastleTier >= 4 AND FlagIsSet(112, bit 0x40) AND ObjStateCheck(val1=27, val2=8)` | `[46, 0, 38, 47, 255, 254, 204, 204, 204, 204]` | Tile Overlay on Obj[38] (**Truncated**, max=35) |
| 23 | `sub[0] ev[65]` | MapInit (Autorun On Load) | `CastleTier >= 4 AND FlagIsSet(112, bit 0x40) AND ObjPosCheck(val1=27, val2=8)` | `[0, 38, 255, 254, 204, 204, 204, 204]` | Obj[38] (**Truncated**, max=35) |
| 24 | `sub[0] ev[67]` | MapInit (Autorun On Load) | `CastleTier >= 4 AND FlagIsSet(112, bit 0x40)` | `[0, 40, 255, 254, 204, 204, 204, 204]` | Obj[40] (**Truncated**, max=35) |

#### 5.3.6 VK11: HQ 3F: Guest Quarters & Living Accommodations (6 Scripts)

Contains 6 cut scripts across 3 submaps (Submap 0: Guest Wing; Submap 1: Guest Corridor; Submap 2: VIP Quarters). In Tier 5, the upper residential floor unlocked three extra guest rooms and VIP suites (Objects 37, 39, 40 in Sub 0; Object 15 in Sub 1; Objects 35, 37 in Sub 2). All target object indices exceed the retail array bounds, showing that the physical bed and table assets were purged.

| # | Script ID | Type (`etyp`) | Decoded Precondition (`eventForm`) | Decoded Commands (`eventCom`) | Target Object & Status |
|---|---|---|---|---|---|
| 25 | `sub[0] ev[29]` | MapInit (Autorun On Load) | `CastleTier >= 4 AND FlagIsSet(112, bit 0x40)` | `[0, 37, 255, 254, 204, 204, 204, 204]` | Obj[37] (**Truncated**, max=33) |
| 26 | `sub[0] ev[31]` | MapInit (Autorun On Load) | `CastleTier >= 4` | `[0, 39, 255, 254, 204, 204, 204, 204]` | Obj[39] (**Truncated**, max=33) |
| 27 | `sub[0] ev[32]` | MapInit (Autorun On Load) | `CastleTier >= 4` | `[0, 40, 255, 254, 204, 204, 204, 204]` | Obj[40] (**Truncated**, max=33) |
| 28 | `sub[1] ev[5]` | MapInit (Autorun On Load) | `CastleTier >= 4 AND FlagIsSet(112, bit 0x40)` | `[0, 15, 255, 254, 204, 204, 204, 204]` | Obj[15] (**Truncated**, max=7) |
| 29 | `sub[2] ev[26]` | MapInit (Autorun On Load) | `CastleTier >= 4 AND FlagIsSet(112, bit 0x40)` | `[0, 35, 255, 254, 204, 204, 204, 204]` | Obj[35] (**Truncated**, max=30) |
| 30 | `sub[2] ev[28]` | MapInit (Autorun On Load) | `CastleTier >= 4` | `[0, 37, 255, 254, 204, 204, 204, 204]` | Obj[37] (**Truncated**, max=30) |

#### 5.3.7 VK12: HQ 1F: Huan's Clinic & Medical Infirmary (3 Scripts)

Contains 3 cut scripts in Submap 0 (`ev[15]`, `ev[18]`, and `ev[25]`). In Tier 5, the clinic expanded to accommodate more wounded soldiers, adding Object 38 (a medicine cabinet prop at X=53, Y=117), Object 41 (a cut nurse or extra bed), and script `ev[25]`, an interactive examination dialogue (`etyp = 1`) for bed patient Object 36.

| # | Script ID | Type (`etyp`) | Decoded Precondition (`eventForm`) | Decoded Commands (`eventCom`) | Target Object & Status |
|---|---|---|---|---|---|
| 31 | `sub[0] ev[15]` | MapInit (Autorun On Load) | `CastleTier >= 4 AND FlagIsSet(112, bit 0x40)` | `[0, 38, 255, 254, 204, 204, 204, 204]` | Obj[38] (Exists, `disp: 0`) |
| 32 | `sub[0] ev[18]` | MapInit (Autorun On Load) | `CastleTier >= 4 AND FlagIsSet(112, bit 0x40)` | `[0, 41, 255, 254, 204, 204, 204, 204]` | Obj[41] (**Truncated**, max=39) |
| 33 | `sub[0] ev[25]` | Action (Talk/Inspect) | `FlagIsSet(112, bit 0x40) AND CastleTier >= 4 AND FacingDir(36..9) AND FlagIsSet(255, bit 0xFE)` | `[56, 38, 0, 3, 4, 1, 0, 9, 3, 38, 2, 30, 1, 1, 4, 23]...` | Custom Cutscene Sequence |

#### 5.3.8 VK13: HQ Interior: Private Residences & Secret Pasture Passage (5 Scripts)

Contains 5 cut scripts across Submaps 2 and 4. Most critically, Submap 4 contains scripts `ev[12]` (Step-on Zone, `etyp=128`) and `ev[13]` (Action/Inspect Door, `etyp=1`), which establish a direct shortcut passage connecting the Castle Living Quarters (X=23..24, Y=135..148) directly to the outer Farm and Pasture (`vk03` Submap 0 at X=50, Y=23 via `ECMapChenge`). In Tier 5, players could bypass the entire lower castle and step straight into the farm from the residential wing.

| # | Script ID | Type (`etyp`) | Decoded Precondition (`eventForm`) | Decoded Commands (`eventCom`) | Target Object & Status |
|---|---|---|---|---|---|
| 34 | `sub[2] ev[37]` | MapInit (Autorun On Load) | `CastleTier >= 4` | `[0, 23, 255, 254, 204, 204, 204, 204]` | Obj[23] (**Truncated**, max=15) |
| 35 | `sub[4] ev[12]` | TriggerZone (Step-On) | `CastleTier == 4 AND X_Range(28..46) AND Y_Range(133..146)` | `[31, 0, 10, 15, 255, 254, 204, 204, 204, 204]` | Transition `vk13` sub[0] to (10,15) |
| 36 | `sub[4] ev[13]` | Action (Talk/Inspect) | `CastleTier == 4 AND X_Range(23..24) AND Y_Range(135..148) AND ButtonPress(0x02)` | `[32, 3, 0, 50, 23, 255, 254, 204, 204, 204, 204]` | Map Transition to `vk03` sub[0] at (50,23) |
| 37 | `sub[4] ev[15]` | MapInit (Autorun On Load) | `FlagIsSet(126, bit 0x40) AND CastleTier == 4` | `[0, 18, 255, 254, 204, 204, 204, 204]` | Obj[18] (**Truncated**, max=11) |
| 38 | `sub[4] ev[16]` | MapInit (Autorun On Load) | `FlagIsSet(126, bit 0x40) AND CastleTier == 4` | `[0, 19, 255, 254, 204, 204, 204, 204]` | Obj[19] (**Truncated**, max=11) |

#### 5.3.9 VK14: HQ Rooftop: Parapet Observation Platform & Watchtower (3 Scripts)

Contains 3 cut scripts in Submap 0 (`ev[65]`, `ev[66]`, and `ev[67]`). In Tier 5, the castle roof received reinforced parapet battlements via Opcode 46 (`ECOverlayPset`) modifying tile structures 45, 46, 47, and 48, plus a rooftop lookout sentry NPC (Object 49). The retail `eventobj` array holds 45 objects (indices 0..44).

| # | Script ID | Type (`etyp`) | Decoded Precondition (`eventForm`) | Decoded Commands (`eventCom`) | Target Object & Status |
|---|---|---|---|---|---|
| 39 | `sub[0] ev[65]` | MapInit (Autorun On Load) | `CastleTier >= 4 AND FlagIsSet(112, bit 0x40)` | `[46, 0, 45, 0, 46, 47, 255, 254, 204, 204, 204, 204]` | Tile Overlay on Obj[45] (**Truncated**, max=44) |
| 40 | `sub[0] ev[66]` | MapInit (Autorun On Load) | `CastleTier >= 4 AND FlagIsSet(112, bit 0x40)` | `[46, 0, 47, 0, 48, 47, 255, 254, 204, 204, 204, 204]` | Tile Overlay on Obj[47] (**Truncated**, max=44) |
| 41 | `sub[0] ev[67]` | MapInit (Autorun On Load) | `CastleTier >= 4 AND FlagIsSet(112, bit 0x40)` | `[0, 49, 255, 254, 204, 204, 204, 204]` | Obj[49] (**Truncated**, max=44) |

#### 5.3.10 VK16: HQ Memorial: Castle Graveyard & Hero Memorial Grounds (9 Scripts)

Contains 9 cut scripts in Submap 0 (`ev[2, 5..11, 14]`). This represents the single largest cut narrative set piece in Dunan Castle. In Tier 5, a major memorial upgrade cutscene sequence was programmed to play: Flik, Viktor, Nanami, Freed Y, Tsai, and Hoi assemble at the cemetery headstones. Scripts `ev[2]`, `ev[7]`, `ev[9]`, `ev[11]`, and `ev[14]` feature multi-camera cutscenes (up to 114 bytes of bytecode each) with facial expressions (`ECWindowFaceHyojyo`), party grouping (`ECPartyCloseN`), screen color transitions (`ECBatParChg`), and permanent tile shrine upgrades (`ECOverlayPset`).

| # | Script ID | Type (`etyp`) | Decoded Precondition (`eventForm`) | Decoded Commands (`eventCom`) | Target Object & Status |
|---|---|---|---|---|---|
| 42 | `sub[0] ev[2]` | Action (Talk/Inspect) | `FlagIsSet(130, bit 0x80) AND FlagNotSet(131, bit 0x01) AND X_Range(38..42) AND Y_Range(18..25) AND CastleTier == 4` | `[117, 0, 0, 3, 0, 2, 73, 60, 5, 9, 4, 5, 6, 1, 5, 10]...` | Custom Cutscene Sequence |
| 43 | `sub[0] ev[5]` | MapInit (Autorun On Load) | `FlagIsSet(131, bit 0x40) AND FlagNotSet(132, bit 0x02) AND CastleTier == 4` | `[105, 5, 0, 0, 255, 254, 204, 204, 204, 204]` | Custom Cutscene Sequence |
| 44 | `sub[0] ev[6]` | MapInit (Autorun On Load) | `FlagIsSet(95, bit 0x40) AND FlagNotSet(132, bit 0x08) AND CastleTier == 4` | `[46, 2, 14, 35, 19, 3, 14, 3, 0, 14, 2, 10, 35, 21, 3, 10]...` | Tile Overlay on Obj[14] (**Truncated**, max=9) |
| 45 | `sub[0] ev[7]` | Action (Talk/Inspect) | `FlagIsSet(95, bit 0x40) AND FlagNotSet(132, bit 0x08) AND CastleTier == 4` | `[117, 0, 0, 73, 250, 73, 250, 11, 1, 2, 200, 5, 14, 3, 1, 30]...` | Custom Cutscene Sequence |
| 46 | `sub[0] ev[8]` | TriggerZone (Step-On) | `FlagIsSet(95, bit 0x40) AND FlagNotSet(132, bit 0x08) AND CastleTier == 4 AND MoveMode(1)` | `[4, 14, 46, 39, 9, 1, 14, 37, 1, 255, 254, 204, 204, 204, 204]` | Custom Cutscene Sequence |
| 47 | `sub[0] ev[9]` | Action (Talk/Inspect) | `FlagIsSet(132, bit 0x10) AND FlagNotSet(146, bit 0x40) AND X_Range(43..51) AND Y_Range(19..30) AND CastleTier == 4` | `[117, 0, 0, 36, 1, 73, 120, 101, 9, 8, 11, 2, 2, 40, 54, 0]...` | Custom Cutscene Sequence |
| 48 | `sub[0] ev[10]` | MapInit (Autorun On Load) | `FlagIsSet(146, bit 0x40) AND FlagNotSet(132, bit 0x20) AND CastleTier == 4` | `[46, 2, 14, 35, 19, 3, 14, 3, 0, 14, 2, 15, 33, 21, 3, 15]...` | Tile Overlay on Obj[14] (**Truncated**, max=9) |
| 49 | `sub[0] ev[11]` | Action (Talk/Inspect) | `FlagIsSet(146, bit 0x40) AND FlagNotSet(132, bit 0x20) AND CastleTier == 4` | `[117, 0, 0, 5, 14, 3, 1, 30, 24, 14, 14, 40, 5, 16, 6, 1]...` | Custom Cutscene Sequence |
| 50 | `sub[0] ev[14]` | Action (Talk/Inspect) | `FlagIsSet(143, bit 0x01) AND FlagNotSet(134, bit 0x01) AND X_Range(38..42) AND Y_Range(18..25) AND CastleTier == 4` | `[117, 0, 0, 73, 90, 11, 3, 2, 120, 24, 14, 15, 0, 5, 0, 2]...` | Custom Cutscene Sequence |

### 5.4 Synthesis: What Castle Level 5 Looked Like Before Being Cut
By cross-referencing all 50 scripts with map coordinates and engine subsystems, the complete scope of Konami's intended Castle Level 5 design can be reconstructed:

1. **Direct Fast-Travel Architecture**: In Tier 5, a dedicated shortcut door opened in the private living quarters (`vk13` Submap 4) connecting directly to the rear animal pasture (`vk03` Submap 0). Players no longer had to traverse multiple elevator shafts, stairwells, and the central hall to access the farm.
2. **Pasture Enclosure Expansion**: Yuzu's farm gained three extra livestock pen enclosures (Objects 38, 39, 40) and four extra grazing animals (Objects 41..44) rendered via dynamic tile overlays (`ECOverlayPset`).
3. **Hospitality & Capacity Upgrade**: The 3F guest quarters (`vk11`) and tavern (`vk04`) unlocked multiple additional bedrooms, tables, and patrons, providing visual feedback that the castle had reached maximum continental alliance recruitment.
4. **Fortress Defense Hardening**: The rooftop parapet (`vk14`) and central courtyard (`vk09`) received additional battlements, perimeter banners, and lookout sentries.
5. **The Grand Fallen Heroes Memorial Sequence**: The most substantial lost content in Tier 5 resides in `vk16` (the cemetery). Rather than remaining a static screen, the Tier 5 graveyard featured a dramatic multi-character cutscene where core story actors (Flik, Viktor, Nanami, Freed Y, Tsai, Hoi) gathered around upgraded stone monuments, with custom camera choreography, screen fades, and emotional portrait expressions honoring those lost in the Dunan Unification War.
