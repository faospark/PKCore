# Suikoden II: Complete Treasure Chest Directory & In-Memory Byte-Patch Guide
This document contains the complete, reverse-engineered master inventory of all **171 treasure chests** across *Suikoden II* (and *Suikoden I & II HD Remaster*), along with memory flag addresses, tile grid coordinates, reward items, and full instructions for modifying chest contents at runtime using PKCore's in-memory byte patch architecture.
## 📦 In-Memory Byte-Patching Mechanism (`MACHICON.EventInit`)
Every chest reward in Suikoden II is executed through an action script event (`etyp = 1`) inside the map asset's `eventdat` array.
When a chest is opened, the engine executes opcode sequence:
```text
30, [OverlayNo], 4, 0, [ITEM_ID], [ITEM_KIND], 0, 41, 2, 0, 1, 255, 0, 97, [FLAG_BYTE], [FLAG_BIT]
```
- `[ITEM_ID]`: 1-byte item identifier within its category.
- `[ITEM_KIND]`: Category mask (`Kind >> 4`):
  - `0` (`0x00`): Usable Consumables & Magic Scrolls (`dogu_data`)
  - `16` (`0x10`): Equipment, Helmets, Armor, Shields & Accessories (`bogu_data`)
  - `32` (`0x20`): Magic Runes & Rune Orbs (`embl_data`)
  - `48` (`0x30`): Antiques, Appraised Art, Statues & Urns (`trade_data`)
  - `80` (`0x50`): Rare Valuables, Old Books, Window/Sound Sets & Plans (`ex_it_data`)
- `97, [FLAG_BYTE], [FLAG_BIT]`: Invokes `ECWkEvFlgSet(byte, bit)` to record the chest as opened in `GAME_WORK.t_box_flag`.

By attaching a postfix hook to `MACHICON.EventInit`, you can directly alter `eventCom[offset]` and `eventCom[offset + 1]` in memory to substitute any item you wish without modifying bundle files on disk.

---

## 🗺️ Master Treasure Chest Directory

### 📍 Region: vb (Act 1A: Mercenary Fort / Ryube)

#### 🏛️ Mt. Tigerwolf & Tsai's Hermit Hut (7 Chests)

| Map ID | Submap | Event | Coords (X, Y) | Save Flag (`Byte, Bit`) | Default Reward | Type / Category | Byte Offset |
|:---:|:---:|:---:|:---:|:---:|:---|:---:|:---:|
| `vb21` | 1 | 4 | (23, 16) | Byte 17, Bit 8 | **Fire Wall (Scroll)** | Consumable | `eventCom[13]` |
| `vb21` | 2 | 4 | (106, 66) | Byte 17, Bit 2 | **Brass Armor (Guard Robe)** | Armor/Accessory | `eventCom[13]` |
| `vb21` | 2 | 5 | (106, 66) | Byte 17, Bit 4 | **Gauntlets** | Armor/Accessory | `eventCom[13]` |
| `vb21` | 4 | 4 | (26, 52) | Byte 17, Bit 16 | **Antitoxin** | Consumable | `eventCom[13]` |
| `vb21` | 4 | 5 | (26, 52) | Byte 17, Bit 32 | **Fire Orb** | Rune Orb | `eventCom[13]` |
| `vb21` | 6 | 4 | (64, 12) | Byte 17, Bit 64 | **Leather Armor** | Armor/Accessory | `eventCom[13]` |
| `vb21` | 6 | 5 | (64, 12) | Byte 17, Bit 128 | **Toe Shoes** | Armor/Accessory | `eventCom[13]` |

#### 🏛️ Swallow Pass & Highland Border Gate (10 Chests)

| Map ID | Submap | Event | Coords (X, Y) | Save Flag (`Byte, Bit`) | Default Reward | Type / Category | Byte Offset |
|:---:|:---:|:---:|:---:|:---:|:---|:---:|:---:|
| `vb07` | 3 | 5 | (30, 30) | Byte 17, Bit 16 | **Toe Shoes** | Armor/Accessory | `eventCom[16]` |
| `vb07` | 3 | 6 | (30, 30) | Byte 17, Bit 32 | **Gauntlets** | Armor/Accessory | `eventCom[16]` |
| `vb08` | 1 | 4 | (23, 16) | Byte 17, Bit 8 | **Fire Wall (Scroll)** | Consumable | `eventCom[16]` |
| `vb08` | 2 | 3 | (105, 68) | Byte 17, Bit 1 | **Escape Talisman** | Consumable | `eventCom[16]` |
| `vb08` | 3 | 3 | (90, 86) | Byte 17, Bit 2 | **Brass Armor (Guard Robe)** | Armor/Accessory | `eventCom[16]` |
| `vb08` | 6 | 3 | (61, 13) | Byte 17, Bit 4 | **Feather Hat (Wind Feather)** | Armor/Accessory | `eventCom[16]` |
| `vb17` | 1 | 5 | (23, 16) | Byte 17, Bit 8 | **Fire Wall (Scroll)** | Consumable | `eventCom[16]` |
| `vb17` | 2 | 4 | (105, 68) | Byte 17, Bit 1 | **Escape Talisman** | Consumable | `eventCom[16]` |
| `vb17` | 3 | 4 | (90, 86) | Byte 17, Bit 2 | **Brass Armor (Guard Robe)** | Armor/Accessory | `eventCom[16]` |
| `vb17` | 6 | 4 | (61, 13) | Byte 17, Bit 4 | **Feather Hat (Wind Feather)** | Armor/Accessory | `eventCom[16]` |

### 📍 Region: vc (Act 1B: Muse / Coronet)

#### 🏛️ Ancient Sindar Ruins Caverns (22 Chests)

| Map ID | Submap | Event | Coords (X, Y) | Save Flag (`Byte, Bit`) | Default Reward | Type / Category | Byte Offset |
|:---:|:---:|:---:|:---:|:---:|:---|:---:|:---:|
| `vc07` | 2 | 4 | (94, 47) | Byte 1, Bit 64 | **Power Ring** | Armor/Accessory | `eventCom[17]` |
| `vc07` | 5 | 2 | (65, 17) | Byte 1, Bit 128 | **Half Helmet** | Armor/Accessory | `eventCom[17]` |
| `vc12` | 1 | 6 | (32, 30) | Byte 0, Bit 1 | **Antitoxin** | Consumable | `eventCom[17]` |
| `vc12` | 1 | 7 | (32, 30) | Byte 0, Bit 2 | **Stone of Magic Defense** | Consumable | `eventCom[17]` |
| `vc12` | 2 | 9 | (47, 139) | Byte 0, Bit 4 | **Stone of Magic** | Consumable | `eventCom[17]` |
| `vc12` | 2 | 10 | (47, 139) | Byte 0, Bit 8 | **Toe Shoes** | Armor/Accessory | `eventCom[17]` |
| `vc12` | 2 | 11 | (47, 139) | Byte 0, Bit 16 | **Water Orb** | Rune Orb | `eventCom[17]` |
| `vc12` | 5 | 6 | (43, 32) | Byte 0, Bit 32 | **Guard Ring** | Armor/Accessory | `eventCom[17]` |
| `vc12` | 6 | 13 | (40, 49) | Byte 0, Bit 64 | **Chain Mail** | Armor/Accessory | `eventCom[17]` |
| `vc12` | 7 | 4 | (34, 92) | Byte 0, Bit 128 | **Magic Drain Orb (Piece)** | Rune Orb | `eventCom[17]` |
| `vc12` | 9 | 8 | (63, 56) | Byte 1, Bit 1 | **Spark Orb** | Rune Orb | `eventCom[17]` |
| `vc12` | 9 | 9 | (63, 56) | Byte 1, Bit 2 | **Old Book Vol.2** | Valuable/Book | `eventCom[17]` |
| `vc13` | 1 | 7 | (32, 30) | Byte 0, Bit 1 | **Antitoxin** | Consumable | `eventCom[17]` |
| `vc13` | 1 | 8 | (32, 30) | Byte 0, Bit 2 | **Stone of Magic Defense** | Consumable | `eventCom[17]` |
| `vc13` | 2 | 20 | (47, 139) | Byte 0, Bit 4 | **Stone of Magic** | Consumable | `eventCom[17]` |
| `vc13` | 2 | 21 | (47, 139) | Byte 0, Bit 8 | **Toe Shoes** | Armor/Accessory | `eventCom[17]` |
| `vc13` | 2 | 22 | (47, 139) | Byte 0, Bit 16 | **Water Orb** | Rune Orb | `eventCom[17]` |
| `vc13` | 5 | 4 | (43, 32) | Byte 0, Bit 32 | **Guard Ring** | Armor/Accessory | `eventCom[17]` |
| `vc13` | 6 | 28 | (31, 44) | Byte 0, Bit 64 | **Chain Mail** | Armor/Accessory | `eventCom[17]` |
| `vc13` | 7 | 5 | (34, 92) | Byte 0, Bit 128 | **Magic Drain Orb (Piece)** | Rune Orb | `eventCom[17]` |
| `vc13` | 9 | 10 | (63, 56) | Byte 1, Bit 1 | **Spark Orb** | Rune Orb | `eventCom[17]` |
| `vc13` | 9 | 11 | (63, 56) | Byte 1, Bit 2 | **Old Book Vol.2** | Valuable/Book | `eventCom[17]` |

#### 🏛️ Highland Military Recon Encampment (1 Chests)

| Map ID | Submap | Event | Coords (X, Y) | Save Flag (`Byte, Bit`) | Default Reward | Type / Category | Byte Offset |
|:---:|:---:|:---:|:---:|:---:|:---|:---:|:---:|
| `vc30` | 1 | 43 | (114, 47) | Byte 1, Bit 32 | **Hunter Orb** | Rune Orb | `eventCom[17]` |

### 📍 Region: vd (Act 2A: South Window / Radat)

#### 🏛️ Cave of the Wind Caverns (12 Chests)

| Map ID | Submap | Event | Coords (X, Y) | Save Flag (`Byte, Bit`) | Default Reward | Type / Category | Byte Offset |
|:---:|:---:|:---:|:---:|:---:|:---|:---:|:---:|
| `vd06` | 3 | 2 | (102, 50) | Byte 12, Bit 1 | **Lightning Ring** | Armor/Accessory | `eventCom[13]` |
| `vd06` | 5 | 2 | (34, 36) | Byte 12, Bit 2 | **Silver Necklace** | Armor/Accessory | `eventCom[13]` |
| `vd06` | 6 | 2 | (20, 24) | Byte 12, Bit 4 | **Fire Wall (Scroll)** | Consumable | `eventCom[13]` |
| `vd06` | 11 | 32 | (66, 20) | Byte 12, Bit 8 | **Blue Gate Orb (Pale Gate)** | Rune Orb | `eventCom[13]` |
| `vd06` | 11 | 35 | (69, 15) | Byte 12, Bit 16 | **Mega Medicine** | Consumable | `eventCom[13]` |
| `vd06` | 11 | 38 | (74, 25) | Byte 12, Bit 32 | **18520 Potch** | Currency | `eventCom[13]` |
| `vd06` | 14 | 3 | (156, 89) | Byte 12, Bit 64 | **Stone of Skill** | Consumable | `eventCom[11]` |
| `vd06` | 14 | 6 | (156, 89) | Byte 12, Bit 128 | **Headgear** | Armor/Accessory | `eventCom[13]` |
| `vd13` | 0 | 2 | (44, 146) | Byte 10, Bit 1 | **Darkness Orb** | Rune Orb | `eventCom[16]` |
| `vd13` | 1 | 2 | (60, 134) | Byte 10, Bit 2 | **Wind Ring** | Armor/Accessory | `eventCom[16]` |
| `vd13` | 4 | 2 | (110, 22) | Byte 10, Bit 4 | **Chain Mail** | Armor/Accessory | `eventCom[16]` |
| `vd13` | 4 | 5 | (110, 22) | Byte 10, Bit 8 | **Cape** | Armor/Accessory | `eventCom[16]` |

#### 🏛️ South Window Capital City (10 Chests)

| Map ID | Submap | Event | Coords (X, Y) | Save Flag (`Byte, Bit`) | Default Reward | Type / Category | Byte Offset |
|:---:|:---:|:---:|:---:|:---:|:---|:---:|:---:|
| `vd01` | 1 | 43 | (54, 29) | Byte 10, Bit 64 | **Recipe #9** | Valuable/Book | `eventCom[14]` |
| `vd03` | 0 | 237 | (58, 113) | Byte 16, Bit 128 | **Rune Orb #100** | Rune Orb | `eventCom[14]` |
| `vd10` | 1 | 2 | (93, 36) | Byte 10, Bit 16 | **Fire Orb** | Rune Orb | `eventCom[16]` |
| `vd11` | 0 | 2 | (69, 54) | Byte 10, Bit 32 | **Stone of Skill** | Consumable | `eventCom[16]` |
| `vd19` | 0 | 10 | (195, 49) | Byte 26, Bit 1 | **Friendship Orb** | Kind 9 | `eventCom[16]` |
| `vd19` | 0 | 11 | (211, 43) | Byte 26, Bit 2 | **Full Plate** | Armor/Accessory | `eventCom[16]` |
| `vd19` | 0 | 12 | (211, 43) | Byte 26, Bit 4 | **Equipment / Armor #86** | Armor/Accessory | `eventCom[16]` |
| `vd19` | 0 | 13 | (211, 43) | Byte 26, Bit 8 | **Fire Ring** | Armor/Accessory | `eventCom[16]` |
| `vd19` | 0 | 14 | (211, 43) | Byte 26, Bit 16 | **Blue Gate Orb (Pale Gate)** | Rune Orb | `eventCom[16]` |
| `vd19` | 0 | 42 | (36, 198) | Byte 10, Bit 128 | **Recipe #14** | Valuable/Book | `eventCom[14]` |

### 📍 Region: ve (Act 2B: Greenhill / Matilda Path)

#### 🏛️ Forest Village Settlement (6 Chests)

| Map ID | Submap | Event | Coords (X, Y) | Save Flag (`Byte, Bit`) | Default Reward | Type / Category | Byte Offset |
|:---:|:---:|:---:|:---:|:---:|:---|:---:|:---:|
| `ve02` | 0 | 91 | (84, 138) | Byte 16, Bit 16 | **Black Urn** | Antique | `eventCom[17]` |
| `ve02` | 1 | 25 | N/A | Byte 16, Bit 64 | **Old Book Vol.6** | Valuable/Book | `eventCom[14]` |
| `ve02` | 1 | 27 | N/A | Byte 16, Bit 32 | **Consumable Item #47** | Consumable | `eventCom[20]` |
| `ve02` | 1 | 29 | N/A | Byte 16, Bit 8 | **Flower Vase** | Antique | `eventCom[14]` |
| `ve02` | 1 | 30 | N/A | Byte 16, Bit 4 | **Sound Set #7** | Valuable/Book | `eventCom[14]` |
| `ve10` | 0 | 36 | (25, 39) | Byte 23, Bit 2 | **Recipe #20** | Valuable/Book | `eventCom[13]` |

#### 🏛️ Greenhill Principality (City & Outskirts) (9 Chests)

| Map ID | Submap | Event | Coords (X, Y) | Save Flag (`Byte, Bit`) | Default Reward | Type / Category | Byte Offset |
|:---:|:---:|:---:|:---:|:---:|:---|:---:|:---:|
| `ve08` | 3 | 6 | (119, 25) | Byte 20, Bit 1 | **Full Helmet** | Armor/Accessory | `eventCom[16]` |
| `ve08` | 3 | 7 | (119, 25) | Byte 20, Bit 2 | **Equipment / Armor #47** | Armor/Accessory | `eventCom[16]` |
| `ve08` | 4 | 4 | (66, 90) | Byte 20, Bit 4 | **Chimera Orb** | Rune Orb | `eventCom[16]` |
| `ve08` | 7 | 6 | (83, 34) | Byte 21, Bit 1 | **Dream Robe** | Armor/Accessory | `eventCom[16]` |
| `ve08` | 7 | 7 | (83, 34) | Byte 21, Bit 2 | **Stone of Speed** | Consumable | `eventCom[16]` |
| `ve08` | 7 | 8 | (83, 34) | Byte 21, Bit 4 | **Equipment / Armor #48** | Armor/Accessory | `eventCom[16]` |
| `ve14` | 3 | 6 | (119, 25) | Byte 20, Bit 1 | **Full Helmet** | Armor/Accessory | `eventCom[16]` |
| `ve14` | 3 | 7 | (119, 25) | Byte 20, Bit 2 | **Equipment / Armor #47** | Armor/Accessory | `eventCom[16]` |
| `ve14` | 4 | 4 | (66, 90) | Byte 20, Bit 4 | **Chimera Orb** | Rune Orb | `eventCom[16]` |

#### 🏛️ Greenhill-Matilda Forest Trail & Checkpoint (4 Chests)

| Map ID | Submap | Event | Coords (X, Y) | Save Flag (`Byte, Bit`) | Default Reward | Type / Category | Byte Offset |
|:---:|:---:|:---:|:---:|:---:|:---|:---:|:---:|
| `ve04` | 1 | 2 | (86, 40) | Byte 20, Bit 8 | **Fire Emblem** | Armor/Accessory | `eventCom[16]` |
| `ve04` | 3 | 4 | (17, 57) | Byte 20, Bit 16 | **Antitoxin** | Consumable | `eventCom[16]` |
| `ve04` | 3 | 5 | (17, 57) | Byte 20, Bit 32 | **Full Plate** | Armor/Accessory | `eventCom[16]` |
| `ve15` | 1 | 2 | (83, 29) | Byte 19, Bit 128 | **Drops of Kindness (Scroll)** | Consumable | `eventCom[16]` |

#### 🏛️ New Leaf Academy (Campus, Dorms & Cellar) (6 Chests)

| Map ID | Submap | Event | Coords (X, Y) | Save Flag (`Byte, Bit`) | Default Reward | Type / Category | Byte Offset |
|:---:|:---:|:---:|:---:|:---:|:---|:---:|:---:|
| `ve03` | 1 | 2 | (83, 29) | Byte 19, Bit 128 | **Drops of Kindness (Scroll)** | Consumable | `eventCom[16]` |
| `ve06` | 0 | 153 | (116, 93) | Byte 23, Bit 4 | **Celadon Urn** | Antique | `eventCom[15]` |
| `ve07` | 0 | 29 | (56, 188) | Byte 24, Bit 128 | **Consumable Item #49** | Consumable | `eventCom[15]` |
| `ve07` | 0 | 176 | (23, 41) | Byte 24, Bit 64 | **Old Book Vol.10** | Valuable/Book | `eventCom[13]` |
| `ve07` | 0 | 192 | (56, 188) | Byte 22, Bit 32 | **Old Book Vol.5** | Valuable/Book | `eventCom[13]` |
| `ve07` | 0 | 197 | (43, 186) | Byte 24, Bit 32 | **Rage Orb** | Rune Orb | `eventCom[13]` |

### 📍 Region: vf (Act 2C: Banner / Toran)

#### 🏛️ Banner Village & Fast Pier (8 Chests)

| Map ID | Submap | Event | Coords (X, Y) | Save Flag (`Byte, Bit`) | Default Reward | Type / Category | Byte Offset |
|:---:|:---:|:---:|:---:|:---:|:---|:---:|:---:|
| `vf06` | 0 | 5 | (36, 29) | Byte 7, Bit 1 | **Antitoxin** | Consumable | `eventCom[16]` |
| `vf06` | 1 | 2 | (107, 29) | Byte 7, Bit 2 | **Wind Hat** | Armor/Accessory | `eventCom[16]` |
| `vf06` | 2 | 8 | (45, 114) | Byte 7, Bit 4 | **Stone of Luck** | Consumable | `eventCom[16]` |
| `vf06` | 2 | 9 | (45, 114) | Byte 7, Bit 8 | **Water Emblem** | Armor/Accessory | `eventCom[16]` |
| `vf06` | 2 | 10 | (45, 114) | Byte 7, Bit 16 | **Rune Orb #97** | Rune Orb | `eventCom[16]` |
| `vf06` | 2 | 11 | (45, 114) | Byte 7, Bit 32 | **Crimson Cape** | Armor/Accessory | `eventCom[16]` |
| `vf07` | 1 | 7 | (102, 22) | Byte 7, Bit 64 | **Chaos Shield** | Armor/Accessory | `eventCom[16]` |
| `vf07` | 1 | 8 | (102, 22) | Byte 7, Bit 128 | **Boots** | Armor/Accessory | `eventCom[16]` |

### 📍 Region: vg (Act 3A: Tinto / Mines / Vampires)

#### 🏛️ Crom Village & Outskirts Path (4 Chests)

| Map ID | Submap | Event | Coords (X, Y) | Save Flag (`Byte, Bit`) | Default Reward | Type / Category | Byte Offset |
|:---:|:---:|:---:|:---:|:---:|:---|:---:|:---:|
| `vg08` | 0 | 98 | (89, 84) | Byte 28, Bit 23 | **Unicorn Plans #3** | Valuable/Book | `eventCom[10]` |
| `vg08` | 0 | 107 | (183, 90) | Byte 23, Bit 16 | **Dragon Plans #3** | Valuable/Book | `eventCom[10]` |
| `vg08` | 1 | 89 | (0, 0) | Byte 23, Bit 8 | **Mother Earth Orb** | Rune Orb | `eventCom[10]` |
| `vg13` | 0 | 104 | (63, 28) | Byte 23, Bit 128 | **Warrior Orb** | Rune Orb | `eventCom[10]` |

#### 🏛️ Drakemouth Mountain Settlement (2 Chests)

| Map ID | Submap | Event | Coords (X, Y) | Save Flag (`Byte, Bit`) | Default Reward | Type / Category | Byte Offset |
|:---:|:---:|:---:|:---:|:---:|:---|:---:|:---:|
| `vg04` | 2 | 5 | (80, 18) | Byte 20, Bit 64 | **Master's Robe** | Armor/Accessory | `eventCom[16]` |
| `vg06` | 1 | 75 | (39, 96) | Byte 24, Bit 2 | **Defective Urn** | Antique | `eventCom[15]` |

#### 🏛️ Tiger Cave & Mt. Senai Shrines (8 Chests)

| Map ID | Submap | Event | Coords (X, Y) | Save Flag (`Byte, Bit`) | Default Reward | Type / Category | Byte Offset |
|:---:|:---:|:---:|:---:|:---:|:---|:---:|:---:|
| `vg15` | 0 | 13 | (99, 133) | Byte 19, Bit 2 | **Earth Armor** | Armor/Accessory | `eventCom[16]` |
| `vg15` | 1 | 8 | (130, 47) | Byte 19, Bit 4 | **Old Book Vol.9** | Valuable/Book | `eventCom[16]` |
| `vg15` | 1 | 9 | (130, 47) | Byte 19, Bit 8 | **Window Set #5** | Valuable/Book | `eventCom[16]` |
| `vg15` | 2 | 36 | (33, 74) | Byte 18, Bit 16 | **Flame Helmet** | Armor/Accessory | `eventCom[16]` |
| `vg15` | 2 | 37 | (163, 64) | Byte 18, Bit 32 | **Down (Knockdown) Orb** | Rune Orb | `eventCom[16]` |
| `vg15` | 2 | 38 | (186, 106) | Byte 18, Bit 64 | **Earth Ring** | Armor/Accessory | `eventCom[16]` |
| `vg15` | 2 | 39 | (186, 106) | Byte 18, Bit 128 | **Antitoxin** | Consumable | `eventCom[16]` |
| `vg15` | 2 | 40 | (186, 106) | Byte 19, Bit 1 | **Fur Cape** | Armor/Accessory | `eventCom[16]` |

#### 🏛️ Tinto Mines & Underground Caverns (4 Chests)

| Map ID | Submap | Event | Coords (X, Y) | Save Flag (`Byte, Bit`) | Default Reward | Type / Category | Byte Offset |
|:---:|:---:|:---:|:---:|:---:|:---|:---:|:---:|
| `vg07` | 0 | 102 | (111, 43) | Byte 24, Bit 16 | **Wide Urn** | Antique | `eventCom[10]` |
| `vg07` | 0 | 133 | (55, 106) | Byte 24, Bit 8 | **Blue Dragon Urn** | Antique | `eventCom[12]` |
| `vg07` | 1 | 75 | N/A | Byte 24, Bit 4 | **Old Book Vol.8** | Valuable/Book | `eventCom[10]` |
| `vg11` | 0 | 23 | (201, 194) | Byte 18, Bit 8 | **Power Gloves** | Armor/Accessory | `eventCom[16]` |

#### 🏛️ Tinto Mining City & Mayor Hall (5 Chests)

| Map ID | Submap | Event | Coords (X, Y) | Save Flag (`Byte, Bit`) | Default Reward | Type / Category | Byte Offset |
|:---:|:---:|:---:|:---:|:---:|:---|:---:|:---:|
| `vg01` | 0 | 206 | (202, 184) | Byte 23, Bit 64 | **Earth Emblem** | Armor/Accessory | `eventCom[15]` |
| `vg02` | 0 | 23 | (210, 129) | Byte 19, Bit 64 | **Flaming Arrows (Scroll)** | Consumable | `eventCom[16]` |
| `vg02` | 2 | 4 | (35, 59) | Byte 19, Bit 16 | **Stone of Skill** | Consumable | `eventCom[16]` |
| `vg02` | 2 | 5 | (33, 60) | Byte 19, Bit 32 | **Wind Hat** | Armor/Accessory | `eventCom[16]` |
| `vg17` | 0 | 127 | (202, 184) | Byte 23, Bit 64 | **Earth Emblem** | Armor/Accessory | `eventCom[15]` |

### 📍 Region: vh (Act 3B: Two River / Kobold)

#### 🏛️ Lakewest Town & Docks (13 Chests)

| Map ID | Submap | Event | Coords (X, Y) | Save Flag (`Byte, Bit`) | Default Reward | Type / Category | Byte Offset |
|:---:|:---:|:---:|:---:|:---:|:---|:---:|:---:|
| `vh02` | 0 | 67 | (0, 0) | Byte 22, Bit 2 | **Rune Orb #102** | Rune Orb | `eventCom[10]` |
| `vh02` | 0 | 69 | (95, 60) | Byte 22, Bit 16 | **Defective Urn** | Antique | `eventCom[10]` |
| `vh02` | 0 | 72 | (29, 42) | Byte 22, Bit 8 | **Blue Dragon Urn** | Antique | `eventCom[12]` |
| `vh02` | 1 | 102 | N/A | Byte 22, Bit 4 | **Recipe #16** | Valuable/Book | `eventCom[17]` |
| `vh02` | 1 | 103 | N/A | Byte 22, Bit 4 | **Recipe #16** | Valuable/Book | `eventCom[10]` |
| `vh10` | 1 | 6 | (63, 28) | Byte 6, Bit 2 | **Cape** | Armor/Accessory | `eventCom[16]` |
| `vh10` | 1 | 7 | (63, 28) | Byte 6, Bit 4 | **Cape** | Armor/Accessory | `eventCom[16]` |
| `vh10` | 1 | 8 | (63, 28) | Byte 6, Bit 8 | **Cape** | Armor/Accessory | `eventCom[16]` |
| `vh10` | 3 | 2 | (92, 29) | Byte 6, Bit 1 | **Cape** | Armor/Accessory | `eventCom[16]` |
| `vh10` | 5 | 4 | (63, 42) | Byte 6, Bit 16 | **Silver Shield** | Armor/Accessory | `eventCom[16]` |
| `vh10` | 5 | 5 | (63, 42) | Byte 6, Bit 32 | **Fire Emblem** | Armor/Accessory | `eventCom[16]` |
| `vh10` | 6 | 4 | (63, 42) | Byte 6, Bit 16 | **Silver Shield** | Armor/Accessory | `eventCom[16]` |
| `vh10` | 6 | 5 | (63, 42) | Byte 6, Bit 32 | **Fire Emblem** | Armor/Accessory | `eventCom[16]` |

#### 🏛️ Two River City (Human, Wingly & Kobold) (1 Chests)

| Map ID | Submap | Event | Coords (X, Y) | Save Flag (`Byte, Bit`) | Default Reward | Type / Category | Byte Offset |
|:---:|:---:|:---:|:---:|:---:|:---|:---:|:---:|
| `vh05` | 1 | 110 | (150, 33) | Byte 22, Bit 1 | **Flower Vase** | Antique | `eventCom[13]` |

#### 🏛️ Two River Subterranean Sewers (5 Chests)

| Map ID | Submap | Event | Coords (X, Y) | Save Flag (`Byte, Bit`) | Default Reward | Type / Category | Byte Offset |
|:---:|:---:|:---:|:---:|:---:|:---|:---:|:---:|
| `vh04` | 3 | 4 | (37, 28) | Byte 17, Bit 64 | **Silver Hat** | Armor/Accessory | `eventCom[16]` |
| `vh04` | 3 | 5 | (37, 28) | Byte 17, Bit 128 | **Resurrection Orb** | Rune Orb | `eventCom[16]` |
| `vh04` | 5 | 4 | (33, 57) | Byte 18, Bit 4 | **Wind of Sleep (Scroll)** | Consumable | `eventCom[16]` |
| `vh04` | 6 | 4 | (50, 24) | Byte 18, Bit 1 | **Water Ring** | Armor/Accessory | `eventCom[16]` |
| `vh04` | 6 | 5 | (50, 24) | Byte 18, Bit 2 | **Stone of Skill** | Consumable | `eventCom[16]` |

### 📍 Region: vi (Act 4A: Matilda / Rockaxe)

#### 🏛️ Mt. Rakutei Dragon Cliffs & Peak (15 Chests)

| Map ID | Submap | Event | Coords (X, Y) | Save Flag (`Byte, Bit`) | Default Reward | Type / Category | Byte Offset |
|:---:|:---:|:---:|:---:|:---:|:---|:---:|:---:|
| `vi08` | 0 | 16 | (110, 95) | Byte 4, Bit 64 | **Antitoxin** | Consumable | `eventCom[14]` |
| `vi08` | 0 | 17 | (110, 95) | Byte 4, Bit 128 | **Cape of Darkness** | Armor/Accessory | `eventCom[14]` |
| `vi08` | 0 | 18 | (110, 95) | Byte 5, Bit 8 | **Horned Helmet** | Armor/Accessory | `eventCom[14]` |
| `vi08` | 1 | 19 | (208, 134) | Byte 5, Bit 1 | **Dragon Plans #4** | Valuable/Book | `eventCom[14]` |
| `vi08` | 1 | 20 | (139, 103) | Byte 5, Bit 2 | **Unicorn Plans #4** | Valuable/Book | `eventCom[14]` |
| `vi08` | 1 | 21 | (120, 81) | Byte 5, Bit 4 | **Silver Dragon Armor** | Armor/Accessory | `eventCom[14]` |
| `vi13` | 2 | 5 | (29, 13) | Byte 2, Bit 1 | **Silverlets** | Armor/Accessory | `eventCom[17]` |
| `vi13` | 2 | 6 | (29, 13) | Byte 2, Bit 2 | **Stone of Protection** | Consumable | `eventCom[17]` |
| `vi13` | 4 | 3 | (66, 8) | Byte 2, Bit 4 | **Gold Emblem** | Armor/Accessory | `eventCom[17]` |
| `vi13` | 5 | 4 | (10, 30) | Byte 2, Bit 8 | **Stone of Magic Protection** | Consumable | `eventCom[17]` |
| `vi13` | 6 | 8 | (173, 105) | Byte 2, Bit 16 | **Unicorn Plans #2** | Valuable/Book | `eventCom[17]` |
| `vi13` | 6 | 9 | (173, 105) | Byte 2, Bit 32 | **Unknown / Special Event Reward** | Kind None | `eventCom[-1]` |
| `vi13` | 6 | 10 | (173, 105) | Byte 2, Bit 64 | **Dragon Plans #2** | Valuable/Book | `eventCom[17]` |
| `vi13` | 6 | 11 | (173, 105) | Byte 2, Bit 128 | **Poison Orb** | Rune Orb | `eventCom[17]` |
| `vi13` | 7 | 5 | (69, 58) | Byte 3, Bit 1 | **Lightning Emblem** | Armor/Accessory | `eventCom[17]` |

#### 🏛️ Rockaxe Castle Citadel & Ramparts (6 Chests)

| Map ID | Submap | Event | Coords (X, Y) | Save Flag (`Byte, Bit`) | Default Reward | Type / Category | Byte Offset |
|:---:|:---:|:---:|:---:|:---:|:---|:---:|:---:|
| `vi06` | 0 | 19 | (0, 0) | Byte 4, Bit 1 | **Stone of Speed** | Consumable | `eventCom[17]` |
| `vi06` | 0 | 20 | (0, 0) | Byte 4, Bit 2 | **Escape Talisman** | Consumable | `eventCom[17]` |
| `vi06` | 1 | 21 | (0, 0) | Byte 4, Bit 4 | **Goldlets** | Armor/Accessory | `eventCom[17]` |
| `vi06` | 1 | 22 | (0, 0) | Byte 4, Bit 8 | **Stone of Skill** | Consumable | `eventCom[17]` |
| `vi06` | 2 | 23 | (0, 0) | Byte 4, Bit 16 | **Sun Badge** | Armor/Accessory | `eventCom[17]` |
| `vi06` | 2 | 24 | (0, 0) | Byte 4, Bit 32 | **Winged Boots** | Armor/Accessory | `eventCom[17]` |

### 📍 Region: vj (Act 4B: Highland Finale)

#### 🏛️ L'Renouille Imperial Capital Citadel (13 Chests)

| Map ID | Submap | Event | Coords (X, Y) | Save Flag (`Byte, Bit`) | Default Reward | Type / Category | Byte Offset |
|:---:|:---:|:---:|:---:|:---:|:---|:---:|:---:|
| `vj02` | 1 | 37 | (201, 190) | Byte 8, Bit 4 | **Exertion Orb** | Rune Orb | `eventCom[16]` |
| `vj02` | 2 | 38 | (178, 32) | Byte 8, Bit 2 | **Stone of Defense** | Consumable | `eventCom[16]` |
| `vj02` | 2 | 41 | (116, 202) | Byte 8, Bit 1 | **Fog Robe** | Armor/Accessory | `eventCom[16]` |
| `vj02` | 2 | 45 | (0, 0) | Byte 9, Bit 4 | **Mega Medicine** | Consumable | `eventCom[13]` |
| `vj02` | 2 | 47 | (0, 0) | Byte 9, Bit 8 | **Mega Medicine** | Consumable | `eventCom[13]` |
| `vj02` | 2 | 49 | (116, 186) | Byte 9, Bit 16 | **Antitoxin** | Consumable | `eventCom[13]` |
| `vj03` | 2 | 11 | (84, 160) | Byte 8, Bit 8 | **Fire Sealing Orb** | Rune Orb | `eventCom[16]` |
| `vj03` | 2 | 14 | (84, 160) | Byte 8, Bit 16 | **Silver Emblem** | Armor/Accessory | `eventCom[16]` |
| `vj04` | 0 | 17 | (0, 0) | Byte 9, Bit 1 | **Iron Boots** | Armor/Accessory | `eventCom[16]` |
| `vj05` | 0 | 20 | (148, 75) | Byte 8, Bit 32 | **Stone of Magic Protection** | Consumable | `eventCom[16]` |
| `vj05` | 0 | 23 | (0, 0) | Byte 8, Bit 64 | **Stone of Skill** | Consumable | `eventCom[16]` |
| `vj05` | 1 | 15 | (159, 33) | Byte 8, Bit 128 | **Escape Talisman** | Consumable | `eventCom[16]` |
| `vj05` | 2 | 21 | (192, 78) | Byte 9, Bit 2 | **Window Set #7** | Valuable/Book | `eventCom[16]` |

