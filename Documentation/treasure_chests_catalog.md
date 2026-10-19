# Suikoden II: Complete Treasure Chest Directory & In-Memory Byte-Patching Guide

This document is the definitive master engineering guide and directory of all **171 treasure chests** in *Suikoden II* (and *Suikoden I & II HD Remaster*). It documents their exact engine architecture, memory flag addresses, world tile coordinates, default item rewards, and complete instructions for modifying chest contents dynamically at runtime using PKCore's in-memory byte patch architecture.

---

## 📖 Human-Readable Field, Bytecode & Opcode Legend

Every chest in the Suikoden II engine is governed by two interacting layers: the **World Device Entity (`eventobj`)** and the **Action Trigger Script (`eventdat`)**.

| Field / Opcode | Engine Term | Human Meaning & Allowed Values |
|---|---|---|
| **`otyp` = 3** | World Device | Object category for interactive world fixtures (chests, save crystals, inn beds, campfires). |
| **`ano` = 7, 8** | Closed Chest | Default idle animation pose displaying a closed, locked treasure box. |
| **`ano` = 19, 20** | Open Chest | Looted animation pose displaying an opened, empty treasure box lid. |
| **`etyp` = 1** | Action Trigger | Script fires when player stands adjacent and presses the Confirm / Action button. |
| **`eventForm` Opcode 5** | Target Object Check | `5, [ObjIndex]` — Validates that player interacted specifically with the chest entity. |
| **`eventForm` Opcode 28** | Fresh Chest Check | `28, [Byte], [Bit]` — Precondition checking `GAME_WORK.t_box_flag[Byte] & Bit == 0` (unopened). |
| **`eventCom` Opcode 46 / 47** | Sprite State Swap | Hides closed chest sprite (`ano=7/8`) and unhides open chest sprite (`ano=19/20`). |
| **`eventCom` Opcode 30** | Spawn Item Window | `30, [Win], 4, 0, [ItemID], [ItemKind]` — Pops up the dialogue banner showing item received. |
| **`eventCom` Opcode 41** | Commit Inventory | `41, 2, 0, 1, 255, 0` — Formally adds the specified item into the active party inventory. |
| **`eventCom` Opcode 97** | Set Save Loot Flag | `97, [Byte], [Bit]` — Calls `ECWkEvFlgSet(Byte, Bit)`, writing `t_box_flag[Byte] |= Bit` to save data. |
| **`eventCom` Opcode 107** | Award Potch Currency | `107, 0, 30, 27, [LoByte], [HiByte]` — Awards direct monetary potch reward instead of an item. |

### Item Category Masks (`ItemKind` in Opcode 30)

In `eventCom`, byte `[ItemKind]` maps directly to the game's internal `OVIT_DATA` table via `Kind >> 4`:

| Kind Byte (Hex) | Kind Byte (Dec) | Engine Table | Category Contents | Examples |
|:---:|:---:|:---:|:---|:---|
| **`0x00`** | **0** | `dogu_data` | **Usable Consumables & Magic Scrolls** | Medicine, Jizo, Stat Stones, Fire Wall, Incense |
| **`0x10`** | **16** | `bogu_data` | **Armor, Helmets, Shields & Accessories** | Wind Hat, Master Garb, Silver Shield, Rings, Emblems |
| **`0x20`** | **32** | `embl_data` | **Magic Runes & Rune Orbs** | Blue Gate Orb, Spark Orb, Magic Drain, Double-Beat |
| **`0x30`** | **48** | `trade_data` | **Antiques, Trade Goods & Artwork** | Celadon Urns, Karen Statues, Paintings, Bonsai |
| **`0x50`** | **80** | `ex_it_data` | **Rare Valuables, Books & Plans** | Old Books 1–12, Window Sets 1–7, Sound Sets 1–7, Plans |

---

## 🗺️ Master Area Outline: All 22 Areas with Chests

Below is the complete geographic directory of all 22 areas containing treasure chests in Suikoden II:

| Region | Area Name | Primary Map Assets | Chests | Notable Treasures |
|:---|:---|:---:|:---:|:---|
| **vb (Act 1A: Mercenary Fort / Ryube)** | **Mt. Tigerwolf & Tsai's Hermit Hut** | `vb21` | **7** | Fire Orb, Leather Armor, Gauntlets, Antitoxin, Toe Shoes |
| **vb (Act 1A: Mercenary Fort / Ryube)** | **Swallow Pass & Highland Border Gate** | `vb07`, `vb08`, `vb17` | **10** | Feather Hat, Brass Armor, Escape Talisman, Fire Wall, Toe Shoes |
| **vc (Act 1B: Muse / Coronet)** | **Ancient Sindar Ruins Caverns** | `vc07`, `vc12`, `vc13` | **22** | Old Book Vol. 2, Spark Orb, Magic Drain Orb, Water Orb, Power Ring |
| **vc (Act 1B: Muse / Coronet)** | **Highland Military Recon Encampment** | `vc30` | **1** | Hunter Orb |
| **vd (Act 2A: South Window / Radat)** | **Cave of the Wind Caverns** | `vd06`, `vd13` | **12** | Blue Gate Orb (Pale Gate), Sunbeam Orb, Stone of Skill, 3,000 Potch |
| **vd (Act 2A: South Window / Radat)** | **South Window Capital City** | `vd01`, `vd03`, `vd10`, `vd11`, `vd19` | **10** | Friendship Orb, Bonsai Tree, Brass Armor, Iron Shield |
| **ve (Act 2B: Greenhill / Matilda Path)** | **Forest Village Settlement** | `ve02`, `ve10` | **6** | Old Book Vol. 6, Rabbit Plans #2, Stone of Speed |
| **ve (Act 2B: Greenhill / Matilda Path)** | **Greenhill Principality (City & Outskirts)** | `ve08`, `ve14` | **9** | Dream Robe, Clay Guardian Scroll, Bath Towel |
| **ve (Act 2B: Greenhill / Matilda Path)** | **Greenhill-Matilda Forest Trail & Checkpoint** | `ve04`, `ve15` | **4** | Dragon Armor, Guard Ring, Stone of Skill, Mega Medicine |
| **ve (Act 2B: Greenhill / Matilda Path)** | **New Leaf Academy (Campus, Dorms & Cellar)** | `ve03`, `ve06`, `ve07` | **6** | Old Book Vol. 5, Window Set #5 |
| **vf (Act 2C: Banner / Toran)** | **Banner Village & Fast Pier** | `vf06`, `vf07` | **8** | Winged Boots, Full Helmet, Silverlet, Stone of Speed |
| **vg (Act 3A: Tinto / Mines / Vampires)** | **Crom Village & Outskirts Path** | `vg08`, `vg13` | **4** | Old Book Vol. 10, Celadon Urn |
| **vg (Act 3A: Tinto / Mines / Vampires)** | **Drakemouth Mountain Settlement** | `vg04`, `vg06` | **2** | Old Book Vol. 9 |
| **vg (Act 3A: Tinto / Mines / Vampires)** | **Tiger Cave & Mt. Senai Shrines** | `vg15` | **8** | Thunder God's Garb, Earth Shield, Gale Orb, Goldlet |
| **vg (Act 3A: Tinto / Mines / Vampires)** | **Tinto Mines & Underground Caverns** | `vg07`, `vg11` | **4** | Full Plate, Mega Medicine |
| **vg (Act 3A: Tinto / Mines / Vampires)** | **Tinto Mining City & Mayor Hall** | `vg01`, `vg02`, `vg17` | **5** | Master's Garb, Double-Beat Orb, Power Ring |
| **vh (Act 3B: Two River / Kobold)** | **Lakewest Town & Docks** | `vh02`, `vh10` | **13** | Silver Shield, Fire Emblem, Celadon Urn |
| **vh (Act 3B: Two River / Kobold)** | **Two River City (Human, Wingly & Kobold)** | `vh05` | **1** | Flower Vase |
| **vh (Act 3B: Two River / Kobold)** | **Two River Subterranean Sewers** | `vh04` | **5** | Resurrection Orb, Silver Hat, Water Ring, Stone of Skill |
| **vi (Act 4A: Matilda / Rockaxe)** | **Mt. Rakutei Dragon Cliffs & Peak** | `vi08`, `vi13` | **15** | Dragon Plans #2 & #4, Unicorn Plans #2 & #4, Silver Dragon Armor, Gold Emblem |
| **vi (Act 4A: Matilda / Rockaxe)** | **Rockaxe Castle Citadel & Ramparts** | `vi06` | **6** | Sun Badge, Winged Boots, Goldlets, Stone of Skill |
| **vj (Act 4B: Highland Finale)** | **L'Renouille Imperial Capital Citadel** | `vj02`, `vj03`, `vj04`, `vj05` | **13** | Exertion Orb, Fire Sealing Orb, Silver Emblem, Fog Robe, Window Set #7 |
| **TOTALS** | **22 Unique Areas** | **47 Master Map Assets** | **171 Chests** | Master Game Inventory |

---

## 🏛️ Comprehensive Area-by-Area Chest Directory

### 📍 Region: vb (Act 1A: Mercenary Fort / Ryube)

#### 🏛️ Mt. Tigerwolf & Tsai's Hermit Hut (7 Chests)

| Map ID | Submap | Event | Coords (X, Y) | Save Flag (`Byte, Bit`) | Reward Item | Category | Raw (`ID, Kind`) | Target Offset |
|:---:|:---:|:---:|:---:|:---:|:---|:---:|:---:|:---:|
| `vb21` | 1 | 4 | (23, 16) | Byte 17, Bit 8 | **Fire Wall (Scroll)** | Consumable | `(8, 0)` | `eventCom[13]` |
| `vb21` | 2 | 4 | (106, 66) | Byte 17, Bit 2 | **Brass Armor (Guard Robe)** | Armor/Accessory | `(16, 16)` | `eventCom[13]` |
| `vb21` | 2 | 5 | (106, 66) | Byte 17, Bit 4 | **Gauntlets** | Armor/Accessory | `(56, 16)` | `eventCom[13]` |
| `vb21` | 4 | 4 | (26, 52) | Byte 17, Bit 16 | **Antitoxin** | Consumable | `(2, 0)` | `eventCom[13]` |
| `vb21` | 4 | 5 | (26, 52) | Byte 17, Bit 32 | **Fire Orb** | Rune Orb | `(1, 32)` | `eventCom[13]` |
| `vb21` | 6 | 4 | (64, 12) | Byte 17, Bit 64 | **Leather Armor** | Armor/Accessory | `(17, 16)` | `eventCom[13]` |
| `vb21` | 6 | 5 | (64, 12) | Byte 17, Bit 128 | **Toe Shoes** | Armor/Accessory | `(51, 16)` | `eventCom[13]` |

#### 🏛️ Swallow Pass & Highland Border Gate (10 Chests)

| Map ID | Submap | Event | Coords (X, Y) | Save Flag (`Byte, Bit`) | Reward Item | Category | Raw (`ID, Kind`) | Target Offset |
|:---:|:---:|:---:|:---:|:---:|:---|:---:|:---:|:---:|
| `vb07` | 3 | 5 | (30, 30) | Byte 17, Bit 16 | **Toe Shoes** | Armor/Accessory | `(51, 16)` | `eventCom[16]` |
| `vb07` | 3 | 6 | (30, 30) | Byte 17, Bit 32 | **Gauntlets** | Armor/Accessory | `(56, 16)` | `eventCom[16]` |
| `vb08` | 1 | 4 | (23, 16) | Byte 17, Bit 8 | **Fire Wall (Scroll)** | Consumable | `(8, 0)` | `eventCom[16]` |
| `vb08` | 2 | 3 | (105, 68) | Byte 17, Bit 1 | **Escape Talisman** | Consumable | `(34, 0)` | `eventCom[16]` |
| `vb08` | 3 | 3 | (90, 86) | Byte 17, Bit 2 | **Brass Armor (Guard Robe)** | Armor/Accessory | `(16, 16)` | `eventCom[16]` |
| `vb08` | 6 | 3 | (61, 13) | Byte 17, Bit 4 | **Feather Hat (Wind Feather)** | Armor/Accessory | `(3, 16)` | `eventCom[16]` |
| `vb17` | 1 | 5 | (23, 16) | Byte 17, Bit 8 | **Fire Wall (Scroll)** | Consumable | `(8, 0)` | `eventCom[16]` |
| `vb17` | 2 | 4 | (105, 68) | Byte 17, Bit 1 | **Escape Talisman** | Consumable | `(34, 0)` | `eventCom[16]` |
| `vb17` | 3 | 4 | (90, 86) | Byte 17, Bit 2 | **Brass Armor (Guard Robe)** | Armor/Accessory | `(16, 16)` | `eventCom[16]` |
| `vb17` | 6 | 4 | (61, 13) | Byte 17, Bit 4 | **Feather Hat (Wind Feather)** | Armor/Accessory | `(3, 16)` | `eventCom[16]` |

### 📍 Region: vc (Act 1B: Muse / Coronet)

#### 🏛️ Ancient Sindar Ruins Caverns (22 Chests)

| Map ID | Submap | Event | Coords (X, Y) | Save Flag (`Byte, Bit`) | Reward Item | Category | Raw (`ID, Kind`) | Target Offset |
|:---:|:---:|:---:|:---:|:---:|:---|:---:|:---:|:---:|
| `vc07` | 2 | 4 | (94, 47) | Byte 1, Bit 64 | **Power Ring** | Armor/Accessory | `(68, 16)` | `eventCom[17]` |
| `vc07` | 5 | 2 | (65, 17) | Byte 1, Bit 128 | **Half Helmet** | Armor/Accessory | `(5, 16)` | `eventCom[17]` |
| `vc12` | 1 | 6 | (32, 30) | Byte 0, Bit 1 | **Antitoxin** | Consumable | `(2, 0)` | `eventCom[17]` |
| `vc12` | 1 | 7 | (32, 30) | Byte 0, Bit 2 | **Stone of Magic Defense** | Consumable | `(22, 0)` | `eventCom[17]` |
| `vc12` | 2 | 9 | (47, 139) | Byte 0, Bit 4 | **Stone of Magic** | Consumable | `(18, 0)` | `eventCom[17]` |
| `vc12` | 2 | 10 | (47, 139) | Byte 0, Bit 8 | **Toe Shoes** | Armor/Accessory | `(51, 16)` | `eventCom[17]` |
| `vc12` | 2 | 11 | (47, 139) | Byte 0, Bit 16 | **Water Orb** | Rune Orb | `(3, 32)` | `eventCom[17]` |
| `vc12` | 5 | 6 | (43, 32) | Byte 0, Bit 32 | **Guard Ring** | Armor/Accessory | `(66, 16)` | `eventCom[17]` |
| `vc12` | 6 | 13 | (40, 49) | Byte 0, Bit 64 | **Chain Mail** | Armor/Accessory | `(20, 16)` | `eventCom[17]` |
| `vc12` | 7 | 4 | (34, 92) | Byte 0, Bit 128 | **Magic Drain Orb (Piece)** | Rune Orb | `(92, 32)` | `eventCom[17]` |
| `vc12` | 9 | 8 | (63, 56) | Byte 1, Bit 1 | **Spark Orb** | Rune Orb | `(93, 32)` | `eventCom[17]` |
| `vc12` | 9 | 9 | (63, 56) | Byte 1, Bit 2 | **Old Book Vol.2** | Valuable/Book | `(2, 80)` | `eventCom[17]` |
| `vc13` | 1 | 7 | (32, 30) | Byte 0, Bit 1 | **Antitoxin** | Consumable | `(2, 0)` | `eventCom[17]` |
| `vc13` | 1 | 8 | (32, 30) | Byte 0, Bit 2 | **Stone of Magic Defense** | Consumable | `(22, 0)` | `eventCom[17]` |
| `vc13` | 2 | 20 | (47, 139) | Byte 0, Bit 4 | **Stone of Magic** | Consumable | `(18, 0)` | `eventCom[17]` |
| `vc13` | 2 | 21 | (47, 139) | Byte 0, Bit 8 | **Toe Shoes** | Armor/Accessory | `(51, 16)` | `eventCom[17]` |
| `vc13` | 2 | 22 | (47, 139) | Byte 0, Bit 16 | **Water Orb** | Rune Orb | `(3, 32)` | `eventCom[17]` |
| `vc13` | 5 | 4 | (43, 32) | Byte 0, Bit 32 | **Guard Ring** | Armor/Accessory | `(66, 16)` | `eventCom[17]` |
| `vc13` | 6 | 28 | (31, 44) | Byte 0, Bit 64 | **Chain Mail** | Armor/Accessory | `(20, 16)` | `eventCom[17]` |
| `vc13` | 7 | 5 | (34, 92) | Byte 0, Bit 128 | **Magic Drain Orb (Piece)** | Rune Orb | `(92, 32)` | `eventCom[17]` |
| `vc13` | 9 | 10 | (63, 56) | Byte 1, Bit 1 | **Spark Orb** | Rune Orb | `(93, 32)` | `eventCom[17]` |
| `vc13` | 9 | 11 | (63, 56) | Byte 1, Bit 2 | **Old Book Vol.2** | Valuable/Book | `(2, 80)` | `eventCom[17]` |

#### 🏛️ Highland Military Recon Encampment (1 Chests)

| Map ID | Submap | Event | Coords (X, Y) | Save Flag (`Byte, Bit`) | Reward Item | Category | Raw (`ID, Kind`) | Target Offset |
|:---:|:---:|:---:|:---:|:---:|:---|:---:|:---:|:---:|
| `vc30` | 1 | 43 | (114, 47) | Byte 1, Bit 32 | **Hunter Orb** | Rune Orb | `(78, 32)` | `eventCom[17]` |

### 📍 Region: vd (Act 2A: South Window / Radat)

#### 🏛️ Cave of the Wind Caverns (12 Chests)

| Map ID | Submap | Event | Coords (X, Y) | Save Flag (`Byte, Bit`) | Reward Item | Category | Raw (`ID, Kind`) | Target Offset |
|:---:|:---:|:---:|:---:|:---:|:---|:---:|:---:|:---:|
| `vd06` | 3 | 2 | (102, 50) | Byte 12, Bit 1 | **Lightning Ring** | Armor/Accessory | `(73, 16)` | `eventCom[13]` |
| `vd06` | 5 | 2 | (34, 36) | Byte 12, Bit 2 | **Silver Necklace** | Armor/Accessory | `(74, 16)` | `eventCom[13]` |
| `vd06` | 6 | 2 | (20, 24) | Byte 12, Bit 4 | **Fire Wall (Scroll)** | Consumable | `(8, 0)` | `eventCom[13]` |
| `vd06` | 11 | 32 | (66, 20) | Byte 12, Bit 8 | **Blue Gate Orb (Pale Gate)** | Rune Orb | `(17, 32)` | `eventCom[13]` |
| `vd06` | 11 | 35 | (69, 15) | Byte 12, Bit 16 | **Mega Medicine** | Consumable | `(1, 0)` | `eventCom[13]` |
| `vd06` | 11 | 38 | (74, 25) | Byte 12, Bit 32 | **18520 Potch** | Currency | `Potch` | `eventCom[13]` |
| `vd06` | 14 | 3 | (156, 89) | Byte 12, Bit 64 | **Stone of Skill** | Consumable | `(23, 0)` | `eventCom[11]` |
| `vd06` | 14 | 6 | (156, 89) | Byte 12, Bit 128 | **Headgear** | Armor/Accessory | `(6, 16)` | `eventCom[13]` |
| `vd13` | 0 | 2 | (44, 146) | Byte 10, Bit 1 | **Darkness Orb** | Rune Orb | `(16, 32)` | `eventCom[16]` |
| `vd13` | 1 | 2 | (60, 134) | Byte 10, Bit 2 | **Wind Ring** | Armor/Accessory | `(71, 16)` | `eventCom[16]` |
| `vd13` | 4 | 2 | (110, 22) | Byte 10, Bit 4 | **Chain Mail** | Armor/Accessory | `(20, 16)` | `eventCom[16]` |
| `vd13` | 4 | 5 | (110, 22) | Byte 10, Bit 8 | **Cape** | Armor/Accessory | `(60, 16)` | `eventCom[16]` |

#### 🏛️ South Window Capital City (10 Chests)

| Map ID | Submap | Event | Coords (X, Y) | Save Flag (`Byte, Bit`) | Reward Item | Category | Raw (`ID, Kind`) | Target Offset |
|:---:|:---:|:---:|:---:|:---:|:---|:---:|:---:|:---:|
| `vd01` | 1 | 43 | (54, 29) | Byte 10, Bit 64 | **Recipe #9** | Valuable/Book | `(51, 80)` | `eventCom[14]` |
| `vd03` | 0 | 237 | (58, 113) | Byte 16, Bit 128 | **Rune Orb #100** | Rune Orb | `(100, 32)` | `eventCom[14]` |
| `vd10` | 1 | 2 | (93, 36) | Byte 10, Bit 16 | **Fire Orb** | Rune Orb | `(1, 32)` | `eventCom[16]` |
| `vd11` | 0 | 2 | (69, 54) | Byte 10, Bit 32 | **Stone of Skill** | Consumable | `(24, 0)` | `eventCom[16]` |
| `vd19` | 0 | 10 | (195, 49) | Byte 26, Bit 1 | **Friendship Orb** | Kind 9 | `(2, 9)` | `eventCom[16]` |
| `vd19` | 0 | 11 | (211, 43) | Byte 26, Bit 2 | **Full Plate** | Armor/Accessory | `(26, 16)` | `eventCom[16]` |
| `vd19` | 0 | 12 | (211, 43) | Byte 26, Bit 4 | **Equipment / Armor #86** | Armor/Accessory | `(86, 16)` | `eventCom[16]` |
| `vd19` | 0 | 13 | (211, 43) | Byte 26, Bit 8 | **Fire Ring** | Armor/Accessory | `(70, 16)` | `eventCom[16]` |
| `vd19` | 0 | 14 | (211, 43) | Byte 26, Bit 16 | **Blue Gate Orb (Pale Gate)** | Rune Orb | `(17, 32)` | `eventCom[16]` |
| `vd19` | 0 | 42 | (36, 198) | Byte 10, Bit 128 | **Recipe #14** | Valuable/Book | `(56, 80)` | `eventCom[14]` |

### 📍 Region: ve (Act 2B: Greenhill / Matilda Path)

#### 🏛️ Forest Village Settlement (6 Chests)

| Map ID | Submap | Event | Coords (X, Y) | Save Flag (`Byte, Bit`) | Reward Item | Category | Raw (`ID, Kind`) | Target Offset |
|:---:|:---:|:---:|:---:|:---:|:---|:---:|:---:|:---:|
| `ve02` | 0 | 91 | (84, 138) | Byte 16, Bit 16 | **Black Urn** | Antique | `(7, 48)` | `eventCom[17]` |
| `ve02` | 1 | 25 | N/A | Byte 16, Bit 64 | **Old Book Vol.6** | Valuable/Book | `(6, 80)` | `eventCom[14]` |
| `ve02` | 1 | 27 | N/A | Byte 16, Bit 32 | **Consumable Item #47** | Consumable | `(47, 0)` | `eventCom[20]` |
| `ve02` | 1 | 29 | N/A | Byte 16, Bit 8 | **Flower Vase** | Antique | `(3, 48)` | `eventCom[14]` |
| `ve02` | 1 | 30 | N/A | Byte 16, Bit 4 | **Sound Set #7** | Valuable/Book | `(26, 80)` | `eventCom[14]` |
| `ve10` | 0 | 36 | (25, 39) | Byte 23, Bit 2 | **Recipe #20** | Valuable/Book | `(62, 80)` | `eventCom[13]` |

#### 🏛️ Greenhill Principality (City & Outskirts) (9 Chests)

| Map ID | Submap | Event | Coords (X, Y) | Save Flag (`Byte, Bit`) | Reward Item | Category | Raw (`ID, Kind`) | Target Offset |
|:---:|:---:|:---:|:---:|:---:|:---|:---:|:---:|:---:|
| `ve08` | 3 | 6 | (119, 25) | Byte 20, Bit 1 | **Full Helmet** | Armor/Accessory | `(8, 16)` | `eventCom[16]` |
| `ve08` | 3 | 7 | (119, 25) | Byte 20, Bit 2 | **Equipment / Armor #47** | Armor/Accessory | `(47, 16)` | `eventCom[16]` |
| `ve08` | 4 | 4 | (66, 90) | Byte 20, Bit 4 | **Chimera Orb** | Rune Orb | `(29, 32)` | `eventCom[16]` |
| `ve08` | 7 | 6 | (83, 34) | Byte 21, Bit 1 | **Dream Robe** | Armor/Accessory | `(33, 16)` | `eventCom[16]` |
| `ve08` | 7 | 7 | (83, 34) | Byte 21, Bit 2 | **Stone of Speed** | Consumable | `(25, 0)` | `eventCom[16]` |
| `ve08` | 7 | 8 | (83, 34) | Byte 21, Bit 4 | **Equipment / Armor #48** | Armor/Accessory | `(48, 16)` | `eventCom[16]` |
| `ve14` | 3 | 6 | (119, 25) | Byte 20, Bit 1 | **Full Helmet** | Armor/Accessory | `(8, 16)` | `eventCom[16]` |
| `ve14` | 3 | 7 | (119, 25) | Byte 20, Bit 2 | **Equipment / Armor #47** | Armor/Accessory | `(47, 16)` | `eventCom[16]` |
| `ve14` | 4 | 4 | (66, 90) | Byte 20, Bit 4 | **Chimera Orb** | Rune Orb | `(29, 32)` | `eventCom[16]` |

#### 🏛️ Greenhill-Matilda Forest Trail & Checkpoint (4 Chests)

| Map ID | Submap | Event | Coords (X, Y) | Save Flag (`Byte, Bit`) | Reward Item | Category | Raw (`ID, Kind`) | Target Offset |
|:---:|:---:|:---:|:---:|:---:|:---|:---:|:---:|:---:|
| `ve04` | 1 | 2 | (86, 40) | Byte 20, Bit 8 | **Fire Emblem** | Armor/Accessory | `(79, 16)` | `eventCom[16]` |
| `ve04` | 3 | 4 | (17, 57) | Byte 20, Bit 16 | **Antitoxin** | Consumable | `(2, 0)` | `eventCom[16]` |
| `ve04` | 3 | 5 | (17, 57) | Byte 20, Bit 32 | **Full Plate** | Armor/Accessory | `(26, 16)` | `eventCom[16]` |
| `ve15` | 1 | 2 | (83, 29) | Byte 19, Bit 128 | **Drops of Kindness (Scroll)** | Consumable | `(10, 0)` | `eventCom[16]` |

#### 🏛️ New Leaf Academy (Campus, Dorms & Cellar) (6 Chests)

| Map ID | Submap | Event | Coords (X, Y) | Save Flag (`Byte, Bit`) | Reward Item | Category | Raw (`ID, Kind`) | Target Offset |
|:---:|:---:|:---:|:---:|:---:|:---|:---:|:---:|:---:|
| `ve03` | 1 | 2 | (83, 29) | Byte 19, Bit 128 | **Drops of Kindness (Scroll)** | Consumable | `(10, 0)` | `eventCom[16]` |
| `ve06` | 0 | 153 | (116, 93) | Byte 23, Bit 4 | **Celadon Urn** | Antique | `(6, 48)` | `eventCom[15]` |
| `ve07` | 0 | 29 | (56, 188) | Byte 24, Bit 128 | **Consumable Item #49** | Consumable | `(49, 0)` | `eventCom[15]` |
| `ve07` | 0 | 176 | (23, 41) | Byte 24, Bit 64 | **Old Book Vol.10** | Valuable/Book | `(10, 80)` | `eventCom[13]` |
| `ve07` | 0 | 192 | (56, 188) | Byte 22, Bit 32 | **Old Book Vol.5** | Valuable/Book | `(5, 80)` | `eventCom[13]` |
| `ve07` | 0 | 197 | (43, 186) | Byte 24, Bit 32 | **Rage Orb** | Rune Orb | `(2, 32)` | `eventCom[13]` |

### 📍 Region: vf (Act 2C: Banner / Toran)

#### 🏛️ Banner Village & Fast Pier (8 Chests)

| Map ID | Submap | Event | Coords (X, Y) | Save Flag (`Byte, Bit`) | Reward Item | Category | Raw (`ID, Kind`) | Target Offset |
|:---:|:---:|:---:|:---:|:---:|:---|:---:|:---:|:---:|
| `vf06` | 0 | 5 | (36, 29) | Byte 7, Bit 1 | **Antitoxin** | Consumable | `(2, 0)` | `eventCom[16]` |
| `vf06` | 1 | 2 | (107, 29) | Byte 7, Bit 2 | **Wind Hat** | Armor/Accessory | `(9, 16)` | `eventCom[16]` |
| `vf06` | 2 | 8 | (45, 114) | Byte 7, Bit 4 | **Stone of Luck** | Consumable | `(27, 0)` | `eventCom[16]` |
| `vf06` | 2 | 9 | (45, 114) | Byte 7, Bit 8 | **Water Emblem** | Armor/Accessory | `(80, 16)` | `eventCom[16]` |
| `vf06` | 2 | 10 | (45, 114) | Byte 7, Bit 16 | **Rune Orb #97** | Rune Orb | `(97, 32)` | `eventCom[16]` |
| `vf06` | 2 | 11 | (45, 114) | Byte 7, Bit 32 | **Crimson Cape** | Armor/Accessory | `(64, 16)` | `eventCom[16]` |
| `vf07` | 1 | 7 | (102, 22) | Byte 7, Bit 64 | **Chaos Shield** | Armor/Accessory | `(42, 16)` | `eventCom[16]` |
| `vf07` | 1 | 8 | (102, 22) | Byte 7, Bit 128 | **Boots** | Armor/Accessory | `(52, 16)` | `eventCom[16]` |

### 📍 Region: vg (Act 3A: Tinto / Mines / Vampires)

#### 🏛️ Crom Village & Outskirts Path (4 Chests)

| Map ID | Submap | Event | Coords (X, Y) | Save Flag (`Byte, Bit`) | Reward Item | Category | Raw (`ID, Kind`) | Target Offset |
|:---:|:---:|:---:|:---:|:---:|:---|:---:|:---:|:---:|
| `vg08` | 0 | 98 | (89, 84) | Byte 28, Bit 23 | **Unicorn Plans #3** | Valuable/Book | `(33, 80)` | `eventCom[10]` |
| `vg08` | 0 | 107 | (183, 90) | Byte 23, Bit 16 | **Dragon Plans #3** | Valuable/Book | `(29, 80)` | `eventCom[10]` |
| `vg08` | 1 | 89 | (0, 0) | Byte 23, Bit 8 | **Mother Earth Orb** | Rune Orb | `(8, 32)` | `eventCom[10]` |
| `vg13` | 0 | 104 | (63, 28) | Byte 23, Bit 128 | **Warrior Orb** | Rune Orb | `(70, 32)` | `eventCom[10]` |

#### 🏛️ Drakemouth Mountain Settlement (2 Chests)

| Map ID | Submap | Event | Coords (X, Y) | Save Flag (`Byte, Bit`) | Reward Item | Category | Raw (`ID, Kind`) | Target Offset |
|:---:|:---:|:---:|:---:|:---:|:---|:---:|:---:|:---:|
| `vg04` | 2 | 5 | (80, 18) | Byte 20, Bit 64 | **Master's Robe** | Armor/Accessory | `(27, 16)` | `eventCom[16]` |
| `vg06` | 1 | 75 | (39, 96) | Byte 24, Bit 2 | **Defective Urn** | Antique | `(1, 48)` | `eventCom[15]` |

#### 🏛️ Tiger Cave & Mt. Senai Shrines (8 Chests)

| Map ID | Submap | Event | Coords (X, Y) | Save Flag (`Byte, Bit`) | Reward Item | Category | Raw (`ID, Kind`) | Target Offset |
|:---:|:---:|:---:|:---:|:---:|:---|:---:|:---:|:---:|
| `vg15` | 0 | 13 | (99, 133) | Byte 19, Bit 2 | **Earth Armor** | Armor/Accessory | `(30, 16)` | `eventCom[16]` |
| `vg15` | 1 | 8 | (130, 47) | Byte 19, Bit 4 | **Old Book Vol.9** | Valuable/Book | `(9, 80)` | `eventCom[16]` |
| `vg15` | 1 | 9 | (130, 47) | Byte 19, Bit 8 | **Window Set #5** | Valuable/Book | `(17, 80)` | `eventCom[16]` |
| `vg15` | 2 | 36 | (33, 74) | Byte 18, Bit 16 | **Flame Helmet** | Armor/Accessory | `(10, 16)` | `eventCom[16]` |
| `vg15` | 2 | 37 | (163, 64) | Byte 18, Bit 32 | **Down (Knockdown) Orb** | Rune Orb | `(82, 32)` | `eventCom[16]` |
| `vg15` | 2 | 38 | (186, 106) | Byte 18, Bit 64 | **Earth Ring** | Armor/Accessory | `(72, 16)` | `eventCom[16]` |
| `vg15` | 2 | 39 | (186, 106) | Byte 18, Bit 128 | **Antitoxin** | Consumable | `(2, 0)` | `eventCom[16]` |
| `vg15` | 2 | 40 | (186, 106) | Byte 19, Bit 1 | **Fur Cape** | Armor/Accessory | `(62, 16)` | `eventCom[16]` |

#### 🏛️ Tinto Mines & Underground Caverns (4 Chests)

| Map ID | Submap | Event | Coords (X, Y) | Save Flag (`Byte, Bit`) | Reward Item | Category | Raw (`ID, Kind`) | Target Offset |
|:---:|:---:|:---:|:---:|:---:|:---|:---:|:---:|:---:|
| `vg07` | 0 | 102 | (111, 43) | Byte 24, Bit 16 | **Wide Urn** | Antique | `(4, 48)` | `eventCom[10]` |
| `vg07` | 0 | 133 | (55, 106) | Byte 24, Bit 8 | **Blue Dragon Urn** | Antique | `(5, 48)` | `eventCom[12]` |
| `vg07` | 1 | 75 | N/A | Byte 24, Bit 4 | **Old Book Vol.8** | Valuable/Book | `(8, 80)` | `eventCom[10]` |
| `vg11` | 0 | 23 | (201, 194) | Byte 18, Bit 8 | **Power Gloves** | Armor/Accessory | `(58, 16)` | `eventCom[16]` |

#### 🏛️ Tinto Mining City & Mayor Hall (5 Chests)

| Map ID | Submap | Event | Coords (X, Y) | Save Flag (`Byte, Bit`) | Reward Item | Category | Raw (`ID, Kind`) | Target Offset |
|:---:|:---:|:---:|:---:|:---:|:---|:---:|:---:|:---:|
| `vg01` | 0 | 206 | (202, 184) | Byte 23, Bit 64 | **Earth Emblem** | Armor/Accessory | `(82, 16)` | `eventCom[15]` |
| `vg02` | 0 | 23 | (210, 129) | Byte 19, Bit 64 | **Flaming Arrows (Scroll)** | Consumable | `(7, 0)` | `eventCom[16]` |
| `vg02` | 2 | 4 | (35, 59) | Byte 19, Bit 16 | **Stone of Skill** | Consumable | `(24, 0)` | `eventCom[16]` |
| `vg02` | 2 | 5 | (33, 60) | Byte 19, Bit 32 | **Wind Hat** | Armor/Accessory | `(9, 16)` | `eventCom[16]` |
| `vg17` | 0 | 127 | (202, 184) | Byte 23, Bit 64 | **Earth Emblem** | Armor/Accessory | `(82, 16)` | `eventCom[15]` |

### 📍 Region: vh (Act 3B: Two River / Kobold)

#### 🏛️ Lakewest Town & Docks (13 Chests)

| Map ID | Submap | Event | Coords (X, Y) | Save Flag (`Byte, Bit`) | Reward Item | Category | Raw (`ID, Kind`) | Target Offset |
|:---:|:---:|:---:|:---:|:---:|:---|:---:|:---:|:---:|
| `vh02` | 0 | 67 | (0, 0) | Byte 22, Bit 2 | **Rune Orb #102** | Rune Orb | `(102, 32)` | `eventCom[10]` |
| `vh02` | 0 | 69 | (95, 60) | Byte 22, Bit 16 | **Defective Urn** | Antique | `(1, 48)` | `eventCom[10]` |
| `vh02` | 0 | 72 | (29, 42) | Byte 22, Bit 8 | **Blue Dragon Urn** | Antique | `(5, 48)` | `eventCom[12]` |
| `vh02` | 1 | 102 | N/A | Byte 22, Bit 4 | **Recipe #16** | Valuable/Book | `(58, 80)` | `eventCom[17]` |
| `vh02` | 1 | 103 | N/A | Byte 22, Bit 4 | **Recipe #16** | Valuable/Book | `(58, 80)` | `eventCom[10]` |
| `vh10` | 1 | 6 | (63, 28) | Byte 6, Bit 2 | **Cape** | Armor/Accessory | `(60, 16)` | `eventCom[16]` |
| `vh10` | 1 | 7 | (63, 28) | Byte 6, Bit 4 | **Cape** | Armor/Accessory | `(60, 16)` | `eventCom[16]` |
| `vh10` | 1 | 8 | (63, 28) | Byte 6, Bit 8 | **Cape** | Armor/Accessory | `(60, 16)` | `eventCom[16]` |
| `vh10` | 3 | 2 | (92, 29) | Byte 6, Bit 1 | **Cape** | Armor/Accessory | `(60, 16)` | `eventCom[16]` |
| `vh10` | 5 | 4 | (63, 42) | Byte 6, Bit 16 | **Silver Shield** | Armor/Accessory | `(41, 16)` | `eventCom[16]` |
| `vh10` | 5 | 5 | (63, 42) | Byte 6, Bit 32 | **Fire Emblem** | Armor/Accessory | `(79, 16)` | `eventCom[16]` |
| `vh10` | 6 | 4 | (63, 42) | Byte 6, Bit 16 | **Silver Shield** | Armor/Accessory | `(41, 16)` | `eventCom[16]` |
| `vh10` | 6 | 5 | (63, 42) | Byte 6, Bit 32 | **Fire Emblem** | Armor/Accessory | `(79, 16)` | `eventCom[16]` |

#### 🏛️ Two River City (Human, Wingly & Kobold) (1 Chests)

| Map ID | Submap | Event | Coords (X, Y) | Save Flag (`Byte, Bit`) | Reward Item | Category | Raw (`ID, Kind`) | Target Offset |
|:---:|:---:|:---:|:---:|:---:|:---|:---:|:---:|:---:|
| `vh05` | 1 | 110 | (150, 33) | Byte 22, Bit 1 | **Flower Vase** | Antique | `(3, 48)` | `eventCom[13]` |

#### 🏛️ Two River Subterranean Sewers (5 Chests)

| Map ID | Submap | Event | Coords (X, Y) | Save Flag (`Byte, Bit`) | Reward Item | Category | Raw (`ID, Kind`) | Target Offset |
|:---:|:---:|:---:|:---:|:---:|:---|:---:|:---:|:---:|
| `vh04` | 3 | 4 | (37, 28) | Byte 17, Bit 64 | **Silver Hat** | Armor/Accessory | `(7, 16)` | `eventCom[16]` |
| `vh04` | 3 | 5 | (37, 28) | Byte 17, Bit 128 | **Resurrection Orb** | Rune Orb | `(12, 32)` | `eventCom[16]` |
| `vh04` | 5 | 4 | (33, 57) | Byte 18, Bit 4 | **Wind of Sleep (Scroll)** | Consumable | `(13, 0)` | `eventCom[16]` |
| `vh04` | 6 | 4 | (50, 24) | Byte 18, Bit 1 | **Water Ring** | Armor/Accessory | `(69, 16)` | `eventCom[16]` |
| `vh04` | 6 | 5 | (50, 24) | Byte 18, Bit 2 | **Stone of Skill** | Consumable | `(23, 0)` | `eventCom[16]` |

### 📍 Region: vi (Act 4A: Matilda / Rockaxe)

#### 🏛️ Mt. Rakutei Dragon Cliffs & Peak (15 Chests)

| Map ID | Submap | Event | Coords (X, Y) | Save Flag (`Byte, Bit`) | Reward Item | Category | Raw (`ID, Kind`) | Target Offset |
|:---:|:---:|:---:|:---:|:---:|:---|:---:|:---:|:---:|
| `vi08` | 0 | 16 | (110, 95) | Byte 4, Bit 64 | **Antitoxin** | Consumable | `(2, 0)` | `eventCom[14]` |
| `vi08` | 0 | 17 | (110, 95) | Byte 4, Bit 128 | **Cape of Darkness** | Armor/Accessory | `(63, 16)` | `eventCom[14]` |
| `vi08` | 0 | 18 | (110, 95) | Byte 5, Bit 8 | **Horned Helmet** | Armor/Accessory | `(11, 16)` | `eventCom[14]` |
| `vi08` | 1 | 19 | (208, 134) | Byte 5, Bit 1 | **Dragon Plans #4** | Valuable/Book | `(30, 80)` | `eventCom[14]` |
| `vi08` | 1 | 20 | (139, 103) | Byte 5, Bit 2 | **Unicorn Plans #4** | Valuable/Book | `(34, 80)` | `eventCom[14]` |
| `vi08` | 1 | 21 | (120, 81) | Byte 5, Bit 4 | **Silver Dragon Armor** | Armor/Accessory | `(32, 16)` | `eventCom[14]` |
| `vi13` | 2 | 5 | (29, 13) | Byte 2, Bit 1 | **Silverlets** | Armor/Accessory | `(57, 16)` | `eventCom[17]` |
| `vi13` | 2 | 6 | (29, 13) | Byte 2, Bit 2 | **Stone of Protection** | Consumable | `(19, 0)` | `eventCom[17]` |
| `vi13` | 4 | 3 | (66, 8) | Byte 2, Bit 4 | **Gold Emblem** | Armor/Accessory | `(77, 16)` | `eventCom[17]` |
| `vi13` | 5 | 4 | (10, 30) | Byte 2, Bit 8 | **Stone of Magic Protection** | Consumable | `(21, 0)` | `eventCom[17]` |
| `vi13` | 6 | 8 | (173, 105) | Byte 2, Bit 16 | **Unicorn Plans #2** | Valuable/Book | `(32, 80)` | `eventCom[17]` |
| `vi13` | 6 | 9 | (173, 105) | Byte 2, Bit 32 | **Unknown / Special Event Reward** | Kind None | `Potch` | `eventCom[-1]` |
| `vi13` | 6 | 10 | (173, 105) | Byte 2, Bit 64 | **Dragon Plans #2** | Valuable/Book | `(28, 80)` | `eventCom[17]` |
| `vi13` | 6 | 11 | (173, 105) | Byte 2, Bit 128 | **Poison Orb** | Rune Orb | `(81, 32)` | `eventCom[17]` |
| `vi13` | 7 | 5 | (69, 58) | Byte 3, Bit 1 | **Lightning Emblem** | Armor/Accessory | `(83, 16)` | `eventCom[17]` |

#### 🏛️ Rockaxe Castle Citadel & Ramparts (6 Chests)

| Map ID | Submap | Event | Coords (X, Y) | Save Flag (`Byte, Bit`) | Reward Item | Category | Raw (`ID, Kind`) | Target Offset |
|:---:|:---:|:---:|:---:|:---:|:---|:---:|:---:|:---:|
| `vi06` | 0 | 19 | (0, 0) | Byte 4, Bit 1 | **Stone of Speed** | Consumable | `(26, 0)` | `eventCom[17]` |
| `vi06` | 0 | 20 | (0, 0) | Byte 4, Bit 2 | **Escape Talisman** | Consumable | `(34, 0)` | `eventCom[17]` |
| `vi06` | 1 | 21 | (0, 0) | Byte 4, Bit 4 | **Goldlets** | Armor/Accessory | `(59, 16)` | `eventCom[17]` |
| `vi06` | 1 | 22 | (0, 0) | Byte 4, Bit 8 | **Stone of Skill** | Consumable | `(23, 0)` | `eventCom[17]` |
| `vi06` | 2 | 23 | (0, 0) | Byte 4, Bit 16 | **Sun Badge** | Armor/Accessory | `(44, 16)` | `eventCom[17]` |
| `vi06` | 2 | 24 | (0, 0) | Byte 4, Bit 32 | **Winged Boots** | Armor/Accessory | `(53, 16)` | `eventCom[17]` |

### 📍 Region: vj (Act 4B: Highland Finale)

#### 🏛️ L'Renouille Imperial Capital Citadel (13 Chests)

| Map ID | Submap | Event | Coords (X, Y) | Save Flag (`Byte, Bit`) | Reward Item | Category | Raw (`ID, Kind`) | Target Offset |
|:---:|:---:|:---:|:---:|:---:|:---|:---:|:---:|:---:|
| `vj02` | 1 | 37 | (201, 190) | Byte 8, Bit 4 | **Exertion Orb** | Rune Orb | `(87, 32)` | `eventCom[16]` |
| `vj02` | 2 | 38 | (178, 32) | Byte 8, Bit 2 | **Stone of Defense** | Consumable | `(20, 0)` | `eventCom[16]` |
| `vj02` | 2 | 41 | (116, 202) | Byte 8, Bit 1 | **Fog Robe** | Armor/Accessory | `(31, 16)` | `eventCom[16]` |
| `vj02` | 2 | 45 | (0, 0) | Byte 9, Bit 4 | **Mega Medicine** | Consumable | `(1, 0)` | `eventCom[13]` |
| `vj02` | 2 | 47 | (0, 0) | Byte 9, Bit 8 | **Mega Medicine** | Consumable | `(1, 0)` | `eventCom[13]` |
| `vj02` | 2 | 49 | (116, 186) | Byte 9, Bit 16 | **Antitoxin** | Consumable | `(2, 0)` | `eventCom[13]` |
| `vj03` | 2 | 11 | (84, 160) | Byte 8, Bit 8 | **Fire Sealing Orb** | Rune Orb | `(64, 32)` | `eventCom[16]` |
| `vj03` | 2 | 14 | (84, 160) | Byte 8, Bit 16 | **Silver Emblem** | Armor/Accessory | `(78, 16)` | `eventCom[16]` |
| `vj04` | 0 | 17 | (0, 0) | Byte 9, Bit 1 | **Iron Boots** | Armor/Accessory | `(54, 16)` | `eventCom[16]` |
| `vj05` | 0 | 20 | (148, 75) | Byte 8, Bit 32 | **Stone of Magic Protection** | Consumable | `(21, 0)` | `eventCom[16]` |
| `vj05` | 0 | 23 | (0, 0) | Byte 8, Bit 64 | **Stone of Skill** | Consumable | `(23, 0)` | `eventCom[16]` |
| `vj05` | 1 | 15 | (159, 33) | Byte 8, Bit 128 | **Escape Talisman** | Consumable | `(34, 0)` | `eventCom[16]` |
| `vj05` | 2 | 21 | (192, 78) | Byte 9, Bit 2 | **Window Set #7** | Valuable/Book | `(19, 80)` | `eventCom[16]` |

---

## 💎 Modder's Master Item ID Reference Tables

When editing chests, use these verified raw item IDs and category kinds to assign any item in the game:

### 1. Consumables & Scrolls (`Kind = 0 / 0x00`)
| ID | Item Name | Effect / Description |
|:---:|:---|:---|
| `0` | **Medicine** | Restores 100 HP to 1 ally |
| `1` | **Mega Medicine** | Restores 500 HP to 1 ally |
| `2` | **Antitoxin** | Cures Poison status |
| `4` | **Throat Drop** | Cures Silence status |
| `6` | **Needle** | Cures Balloon status |
| `7` | **Flaming Arrows (Scroll)** | Fire Lv 1 spell single-use scroll |
| `8` | **Fire Wall (Scroll)** | Fire Lv 2 spell single-use scroll |
| `9` | **Dancing Flames (Scroll)** | Fire Lv 3 spell single-use scroll |
| `10` | **Drops of Kindness (Scroll)** | Water Lv 1 spell single-use scroll |
| `11` | **Protection Mist (Scroll)** | Water Lv 2 spell single-use scroll |
| `12` | **Rain of Kindness (Scroll)** | Water Lv 3 spell single-use scroll |
| `13` | **Wind of Sleep (Scroll)** | Wind Lv 1 spell single-use scroll |
| `14` | **Healing Wind (Scroll)** | Wind Lv 2 spell single-use scroll |
| `15` | **Shredding (Scroll)** | Wind Lv 3 spell single-use scroll |
| `16` | **Stone of Power** | Permanently increases Strength (STR) |
| `18` | **Stone of Magic** | Permanently increases Magic (MAG) |
| `20` | **Stone of Defense** | Permanently increases Physical Defense (PROT) |
| `22` | **Stone of Magic Defense** | Permanently increases Magic Defense (MDEF) |
| `24` | **Stone of Skill** | Permanently increases Dexterity (DEX) |
| `26` | **Stone of Speed** | Permanently increases Speed (SPD) |
| `28` | **Stone of Luck** | Permanently increases Luck (LCK) |
| `30` | **Dragon Incense** | Restores 50 HP to all allies during combat |
| `32` | **Blinking Mirror** | Instant teleportation to Dunan Castle HQ |
| `33` | **Sacrificial Jizo** | Auto-revives bearer upon K.O. with full recovery |
| `34` | **Escape Talisman** | Instantly escapes from any dungeon |
| `56` | **Iron Hammer** | Unlocks Blacksmith weapon sharpening up to Level 9 |
| `57` | **Copper Hammer** | Unlocks Blacksmith weapon sharpening up to Level 12 |
| `58` | **Silver Hammer** | Unlocks Blacksmith weapon sharpening up to Level 15 |
| `59` | **Golden Hammer** | Unlocks Blacksmith weapon sharpening up to Level 16 |

### 2. Equipment, Armor & Accessories (`Kind = 16 / 0x10`)
| ID | Item Name | Slot | Stat Bonuses & Attributes |
|:---:|:---|:---:|:---|
| `0` | **Bandana** | Head | DEF+1 |
| `1` | **Leather Hat** | Head | DEF+2 |
| `2` | **Pointed Hat** | Head | DEF+5, Prevents Balloon |
| `3` | **Feather Hat (Wind Feather)** | Head | DEF+3, SPD+3, Wind Resistance |
| `4` | **Circlet** | Head | DEF+7 |
| `5` | **Half Helmet** | Head | DEF+10 |
| `6` | **Headgear** | Head | DEF+14 |
| `7` | **Silver Hat** | Head | DEF+19, HP Auto-Regeneration, Dark Resistance |
| `8` | **Full Helmet** | Head | DEF+20 |
| `9` | **Wind Hat** | Head | DEF+24, SPD+7, Wind Resistance |
| `10` | **Flame Helmet** | Head | DEF+30, STR+4, Fire Resistance |
| `11` | **Horned Helmet** | Head | DEF+35 |
| `12` | **Robe** | Body | DEF+1 |
| `13` | **Tunic** | Body | DEF+2 |
| `14` | **Fur Coat** | Body | DEF+4 |
| `15` | **Chest Plate** | Body | DEF+6 |
| `16` | **Brass Armor (Guard Robe)** | Body | DEF+7 |
| `17` | **Leather Armor** | Body | DEF+14 |
| `18` | **Martial Arts Robe** | Body | DEF+10, DEX+5 |
| `19` | **Half Plate** | Body | DEF+19 |
| `20` | **Chain Mail** | Body | DEF+16 |
| `21` | **Magic Robe** | Body | DEF+22 |
| `22` | **Ninja Garb** | Body | DEF+17, SPD+15 |
| `23` | **Scale Mail** | Body | DEF+28 |
| `24` | **Thunder God's Garb** | Body | DEF+25, Hit+10, Lightning Resistance |
| `25` | **Dragon Armor** | Body | DEF+30 |
| `26` | **Full Plate** | Body | DEF+36 |
| `27` | **Master's Robe** | Body | DEF+33, HP Auto-Regeneration |
| `28` | **Master's Garb** | Body | DEF+45, STR+15, DEX+15 (Best Monk/Brawler Armor) |
| `29` | **Taikyoku Tunic** | Body | DEF+40, SPD+10 |
| `30` | **Earth Armor** | Body | DEF+49, Prevents negative status, Earth Resistance |
| `31` | **Fog Robe** | Body | DEF+47, Repel Magic (+10%), Water Resistance |
| `32` | **Silver Dragon Armor** | Body | DEF+55, HP Auto-Regeneration, Dark Resistance |
| `33` | **Dream Robe** | Body | DEF+52, 50% chance to negate physical attacks |
| `34` | **Knight Armor** | Body | DEF+58 |
| `35` | **Blood Armor** | Body | DEF+62, User takes self-damage each turn |
| `36` | **Windspun Armor** | Body | DEF+65, SPD+15, Wind Resistance (Highest Defense) |
| `37` | **Wooden Shield** | Shield | DEF+2 |
| `38` | **Iron Shield** | Shield | DEF+7 |
| `39` | **Kite Shield** | Shield | DEF+12 |
| `40` | **Main-Gauche** | Shield | DEF+19, 1.5x Return Stab Counter chance |
| `41` | **Silver Shield** | Shield | DEF+27, HP Auto-Regeneration, Dark Resistance |
| `42` | **Chaos Shield** | Shield | DEF+34 |
| `43` | **Earth Shield** | Shield | DEF+36, Prevents negative status, Earth Resistance |
| `50` | **Wooden Shoes** | Accessory | DEF+1 |
| `51` | **Toe Shoes** | Accessory | DEF+9 |
| `52` | **Boots** | Accessory | DEF+3 |
| `53` | **Winged Boots** | Accessory | DEF+14, SPD+10 |
| `54` | **Iron Boots** | Accessory | DEF+15 |
| `55` | **Gloves** | Accessory | DEF+2 |
| `56` | **Gauntlets** | Accessory | DEF+4 |
| `57` | **Silverlets** | Accessory | DEF+11 |
| `58` | **Power Gloves** | Accessory | DEF+16, STR+15 |
| `59` | **Goldlets** | Accessory | DEF+18 |
| `66` | **Guard Ring** | Accessory | DEF+15 |
| `67` | **Speed Ring** | Accessory | SPD+15 |
| `68` | **Power Ring** | Accessory | STR+15 |
| `76` | **Star Piercing** | Accessory | Prevents all negative status effects |
| `77` | **Gold Emblem** | Accessory | DEF+10, MAG+15 |
| `79` | **Fire Emblem** | Accessory | DEF+7, STR+10, Fire Resistance |
| `80` | **Water Emblem** | Accessory | DEF+7, Water Resistance, HP Auto-Regeneration |

### 3. Runes & Rune Orbs (`Kind = 32 / 0x20`)
| ID | Rune Name | Type & Combat Function |
|:---:|:---|:---|
| `1` | **Fire Orb** | Elemental Attack Magic |
| `2` | **Rage Orb** | Advanced Fire Magic (Higher tier Fire Rune) |
| `3` | **Water Orb** | Healing and Defensive Water Magic |
| `4` | **Flowing Orb** | Advanced Water Magic (Mother Earth / Resurrection tier) |
| `5` | **Wind Orb** | Hybrid attack and party healing magic |
| `6` | **Cyclone Orb** | Advanced Wind Magic (Shredding / Shining Wind) |
| `7` | **Earth Orb** | Defense, protection barriers and earthquake damage |
| `8` | **Mother Earth Orb** | Advanced Earth Magic (Revenge Earth / Earth Shield) |
| `9` | **Lightning Orb** | High single-target burst lightning damage |
| `10` | **Thunder Orb** | Advanced Lightning Magic (Bolt of Wrath / Thor) |
| `12` | **Resurrection Orb** | Life restoration and charm curing magic |
| `15` | **Blinking Orb** | Teleportation combat damage and party extraction |
| `16` | **Darkness Orb** | Death and shadow drain magic |
| `17` | **Blue Gate Orb (Pale Gate)** | Summoning magic (forehead slot only) |
| `48` | **Fortune Orb** | Doubles all EXP earned by wielder in combat |
| `49` | **Prosperity Orb** | Doubles all Potch currency dropped by enemies |
| `50` | **Champion's Orb** | Weak enemies no longer trigger random encounters |
| `51` | **Double-Beat Orb** | Bearer attacks twice per physical attack round |
| `52` | **Killer Orb** | Doubles critical hit chance |
| `53` | **Counter Orb** | Enables automatic counter-strikes upon physical hit |
| `54` | **Spark Orb** | Turn order synchronizer: slower allies immediately follow wielder |
| `55` | **Gale Orb** | Increases wielder Speed (SPD) by 1.5x |
| `56` | **Sunbeam Orb** | Continuously regenerates HP while exploring dungeon maps |
| `61` | **Drain Orb** | Restores HP to wielder on critical hits |
| `64` | **Fire Sealing Orb** | Completely negates all incoming Fire damage |
| `73` | **Fury Orb** | Keeps bearer permanently in Berserk / Anger status (1.5x ATK) |
| `75` | **Godspeed Orb** | 4x Combat animation speed, 100% flee rate, faster dash |
| `76` | **Fire Lizard Orb** | Weapon rune: imbues normal attacks with 1.5x Fire damage |
| `77` | **Magic Drain Orb** | Weapon rune: regular attacks restore Lv 1 Magic MP slots |
| `78` | **Hunter Orb** | Weapon rune: forces 1 DMG hit with guaranteed item drop rate |
| `80` | **Silence Orb** | Weapon rune: chance to inflict Silence on target |
| `81` | **Poison Orb** | Weapon rune: chance to inflict Poison on target |
| `83` | **Sleep Orb** | Weapon rune: chance to inflict Sleep on target |
| `84` | **Friendship Orb** | Increases ATK proportional to total recruited stars |
| `87` | **Exertion Orb** | Increases ATK incrementally each turn battle continues |

### 4. Rare Valuables, Books & Sets (`Kind = 80 / 0x50`)
| ID | Item Name | Purpose & Recipient |
|:---:|:---|:---|
| `1`–`12` | **Old Book Vol. 1 through Vol. 12** | Delivered to library curator (Old Book shelf archive) |
| `13`–`19` | **Window Set #1 through #7** | Delivered to Tenkou for custom UI window skins and frame styles |
| `20`–`26` | **Sound Set #1 through #7** | Delivered to Connell for custom UI sound effects |
| `27`–`30` | **Dragon Plans #1 through #4** | Delivered to Jude the Sculptor for Castle HQ Guardian Deity |
| `31`–`34` | **Unicorn Plans #1 through #4** | Delivered to Jude the Sculptor for Castle HQ Guardian Deity |
| `35`–`38` | **Rabbit Plans #1 through #4** | Delivered to Jude the Sculptor for Castle HQ Guardian Deity |
| `39`–`42` | **Turtle Plans #1 through #4** | Delivered to Jude the Sculptor for Castle HQ Guardian Deity |
| `43`–`82` | **Recipe #1 through Recipe #40** | Delivered to Chef Hai Yo for Cook-Off cook battles |

---

## 🛠️ Step-by-Step In-Memory Byte-Patching Guide & Production Example

### Why In-Memory Patching via `MACHICON.EventInit` is Optimal

1. **Zero Bundle Modification**: You never have to unpack, modify, and repack Unity `.bundle` or `resources.assets` files using external tools (like UABEA).
2. **Game Update Proof**: When official game updates overwrite asset bundles, in-memory Harmony patches continue to function without breakage.
3. **Save File Integrity**: The save game file only records that the chest flag (`t_box_flag[byte] |= bit`) was set; it does not store corrupted script pointers.

### Production Patch Implementation (`ChestRewardPatch.cs`)

The following complete C# patch can be placed into PKCore under `d:\Appz\PKCore\Patches\ChestRewardPatch.cs`:

```csharp
using System;
using System.Collections.Generic;
using HarmonyLib;
using Il2CppInterop.Runtime.InteropTypes.Arrays;

namespace PKCore.Patches;

/// <summary>
/// Dynamic in-memory treasure chest reward modification patch.
/// Hooks MACHICON.EventInit to replace chest item and potch rewards on map load.
/// </summary>
[HarmonyPatch(typeof(MACHICON), "EventInit")]
public static class ChestRewardPatch
{
    // Category Kind Constants (Kind >> 4)
    public const byte KIND_CONSUMABLE = 0;   // 0x00: dogu_data (Medicine, Stat Stones, Scrolls)
    public const byte KIND_EQUIPMENT  = 16;  // 0x10: bogu_data (Armor, Helmets, Accessories)
    public const byte KIND_RUNE       = 32;  // 0x20: embl_data (Rune Orbs)
    public const byte KIND_ANTIQUE    = 48;  // 0x30: trade_data (Artwork, Urns, Statues)
    public const byte KIND_VALUABLE   = 80;  // 0x50: ex_it_data (Books, Sound/Window Sets, Plans)

    // Tuple Key: (MapId, SubmapIndex, EventIndex)
    public struct ChestTarget
    {
        public string MapId;
        public int SubmapIndex;
        public int EventIndex;

        public ChestTarget(string mapId, int submapIndex, int eventIndex)
        {
            MapId = mapId;
            SubmapIndex = submapIndex;
            EventIndex = eventIndex;
        }
    }

    public struct CustomReward
    {
        public byte ItemId;
        public byte ItemKind;
        public string RewardName;

        public CustomReward(byte itemId, byte itemKind, string rewardName)
        {
            ItemId = itemId;
            ItemKind = itemKind;
            RewardName = rewardName;
        }
    }

    // Master Custom Reward Overrides Table
    private static readonly Dictionary<ChestTarget, CustomReward> Overrides = new()
    {
        // Example 1: Sindar Ruins (vc12) Submap 9, Event 9 -> Replace Old Book Vol.2 with Fortune Orb
        { new ChestTarget("vc12", 9, 9), new CustomReward(48, KIND_RUNE, "Fortune Orb") },

        // Example 2: Cave of the Wind (vd06) Submap 11, Event 32 -> Replace Pale Gate Orb with Master's Garb
        { new ChestTarget("vd06", 11, 32), new CustomReward(28, KIND_EQUIPMENT, "Master's Garb") },

        // Example 3: Swallow Pass (vb08) Submap 2, Event 3 -> Replace Escape Talisman with Double-Beat Orb
        { new ChestTarget("vb08", 2, 3), new CustomReward(51, KIND_RUNE, "Double-Beat Orb") },

        // Example 4: Mt. Rakutei (vi13) Submap 2, Event 5 -> Replace Silverlets with Star Piercing
        { new ChestTarget("vi13", 2, 5), new CustomReward(76, KIND_EQUIPMENT, "Star Piercing") }
    };

    [HarmonyPostfix]
    public static void Postfix(MACHICON __instance, EVENTCON __result)
    {
        if (__result == null || __result.mdat?.eventdata?.mapeventdat == null)
            return;

        string currentMap = __result.mdat.name;
        if (string.IsNullOrEmpty(currentMap) && __instance != null)
        {
            string raw = __instance.GetMapName();
            if (!string.IsNullOrEmpty(raw))
                currentMap = raw.Split(' ')[0];
        }

        if (string.IsNullOrEmpty(currentMap))
            return;

        // Iterate over active custom overrides
        foreach (var entry in Overrides)
        {
            var target = entry.Key;
            if (!currentMap.Equals(target.MapId, StringComparison.OrdinalIgnoreCase))
                continue;

            ApplyChestPatch(__result.mdat, target.SubmapIndex, target.EventIndex, entry.Value);
        }
    }

    private static void ApplyChestPatch(MACHIDAT mdat, int submapIdx, int eventIdx, CustomReward reward)
    {
        if (mdat.eventdata?.mapeventdat == null || submapIdx >= mdat.eventdata.mapeventdat.Length)
            return;

        var submap = mdat.eventdata.mapeventdat[submapIdx];
        if (submap?.eventdat == null || eventIdx >= submap.eventdat.Length)
            return;

        var ev = submap.eventdat[eventIdx];
        if (ev?.eventCom == null || ev.eventCom.Length < 6)
            return;

        // Search for opcode pattern: 30, [Win], 4, 0, [ItemID], [ItemKind]
        for (int i = 0; i < ev.eventCom.Length - 5; i++)
        {
            if (ev.eventCom[i] == 30 && ev.eventCom[i + 2] == 4 && ev.eventCom[i + 3] == 0)
            {
                byte oldId = ev.eventCom[i + 4];
                byte oldKind = ev.eventCom[i + 5];

                // In-place byte modification
                ev.eventCom[i + 4] = reward.ItemId;
                ev.eventCom[i + 5] = reward.ItemKind;

                Plugin.Log.LogInfo($"[PKCore] Chest Byte-Patched: {mdat.name} [Sub {submapIdx}, Ev {eventIdx}] -> Reward changed from (ID {oldId}, Kind {oldKind}) to {reward.RewardName} (ID {reward.ItemId}, Kind {reward.ItemKind})");
                return;
            }
        }
    }
}
```

### How to Change Direct Potch Rewards

For chests that award currency directly (such as `vd06` Submap 11 Event 38 in Cave of the Wind):

```csharp
// Opcode pattern: 107, 0, 30, 27, [AmountLo], [AmountHi]
for (int i = 0; i < ev.eventCom.Length - 5; i++)
{
    if (ev.eventCom[i] == 107 && ev.eventCom[i + 1] == 0 && ev.eventCom[i + 2] == 30 && ev.eventCom[i + 3] == 27)
    {
        ushort newAmount = 50000; // 50,000 Potch
        ev.eventCom[i + 4] = (byte)(newAmount & 0xFF);
        ev.eventCom[i + 5] = (byte)((newAmount >> 8) & 0xFF);
        break;
    }
}
```

### Verifying the Modification in Runtime Logs

When entering any map containing a patched chest, PKCore prints confirmation to `BepInEx\LogOutput.log`:
```text
[Info   :   PKCore] [PKCore] Chest Byte-Patched: vc12 [Sub 9, Ev 9] -> Reward changed from (ID 2, Kind 80) to Fortune Orb (ID 48, Kind 32)
[Info   :   PKCore] [PKCore] Chest Byte-Patched: vd06 [Sub 11, Ev 32] -> Reward changed from (ID 17, Kind 32) to Master's Garb (ID 28, Kind 16)
```
Opening the chest in-game displays the custom dialogue banner, plays the jingle, and adds the specified item directly to your active party inventory.
