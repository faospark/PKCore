# Suikoden II War Battle Engine & Modding Comprehensive Guide

## Executive Summary

Suikoden II's tactical army battles are governed by a dedicated military subsystem within the GSD2 engine (`GameAssembly.dll`). While regular combat is party-based turn combat, war battles operate as a tile-based tactical simulation on custom grid maps (`w_data`). Units represent military squads comprising a Commander (Leader) and up to two Adjutants (Subunits), with combat determined by mathematical hit rolls, class advantages, unit compositions, and special tactical abilities (`tagSPECIAL_ABILITY`).

PKCore provides an integration layer that intercepts the engine's character initialization routines (`w_chara.charaInit` and `w_dat_butai`), unlocking customized statistics, composition bonuses, and expanded ability slots via JSON configuration.

---

## 1. Engine Architecture & Memory Model

The war battle engine is partitioned into distinct managed structures and native runtime tables:

```
w_battle (Combat & State Machine)
├── w_unit (Squad State & Spatial Grid)
│   └── unit[force][unit_index] (UNIT_TYPE)
│       ├── x, y               ← Tile coordinates on map grid
│       ├── chara[3]           ← [0]=Leader, [1]=Subunit 1, [2]=Subunit 2
│       ├── damage             ← 0 = Full HP, 1 = Wounded (Sword), 2 = Defeated
│       ├── yoyaku_damage      ← Pending damage before animation resolves
│       ├── flag               ← Unit flags (ON_STAGE, DESTROY, WAIT)
│       ├── manuved_flag       ← Turn action status (0 = Ready, 1 = Acted)
│       └── tactics            ← AI script instructions (TACTICS_TYPE)
│
├── w_chara (Character Roster & Abilities)
│   ├── chara_butai[]          ← 108 Character definitions (WAR_CHARA_TYPE)
│   │   ├── attack             ← Base Leader Attack Power
│   │   ├── assist_attack      ← Subunit Assist Attack Bonus
│   │   ├── defense            ← Base Leader Toughness
│   │   ├── assist_defense     ← Subunit Assist Defense Bonus
│   │   ├── nouryoku[3]        ← Assigned Special Abilities (tagSPECIAL_ABILITY)
│   │   ├── kaisu[3]           ← Remaining ability uses for the battle
│   │   ├── kaisu_max[3]       ← Maximum ability charges (default 9)
│   │   ├── status_flag        ← Immunity flags (DEAD_POSSIBLE vs DEAD_UNPOSSIBLE)
│   │   └── name               ← Text message ID (e.g. 3347 = Riou)
│   │
│   └── tokusyu[]              ← Global Ability Definition Table (tagTokusyuNouryoku)
│       ├── name               ← Text display ID
│       ├── select_type        ← Targeting scheme (0 = Self/Passive, 1 = Area/Enemy)
│       ├── init_func          ← Execution initializer delegate
│       ├── act_func           ← Action execution delegate
│       ├── check_func         ← Validation delegate
│       ├── finish_func        ← Turn cleanup delegate
│       └── select_func        ← Tile reticle targeting delegate
│
└── w_data (Tactical Map & Terrain Costs)
    ├── field_data_X           ← Map tile properties (Plain, Forest, Mountain, Road)
    ├── field_move_cost        ← Standard movement penalties per tile
    └── nukemiti_move_cost     ← Secret shortcut terrain traversal costs
```

---

## 2. Combat Resolution & Mathematical Formulas

Combat in Suikoden II war battles is calculated in `w_kekka` and `w_battle` through a sequence of deterministic multipliers and random rolls.

### 2.1 Unit Statistic Composition

Each unit on the battlefield derives its stats from its Leader and attached Subunits:

```text
Total Attack Power = Leader Attack + Subunit 1 Assist Attack + Subunit 2 Assist Attack
```

```text
Total Toughness (Defense) = Leader Defense + Subunit 1 Assist Defense + Subunit 2 Assist Defense
```

* **Leader**: Uses `attack` and `defense` fields.
* **Subunits**: Use `assist_attack` and `assist_defense` fields.

### 2.2 Class Advantage Multipliers (`CulcAttackPowerTyoku`)

When a unit initiates melee attack, its base attack power is modified according to troop branch (`force_type`):

| Attacker Branch | Target Branch | Base Attack Modifier | Engine Assembly Logic |
| :--- | :--- | :---: | :--- |
| **Infantry** | Infantry | **±0%** (1.0x) | Baseline standard damage |
| **Infantry** | Archer | **+25%** (1.25x) | `sar eax, 2` → add to base attack |
| **Infantry** | Magician | **+50%** (1.50x) | `sar eax, 1` → add to base attack |
| **Archer** | Any in Melee | **-25%** (0.75x) | `sar eax, 2; neg eax` → penalty in close combat |
| **Magician** | Any in Melee | **Nullified** (0.0x) | `xor ebx, ebx` → 0 melee combat power |

> [!NOTE]
> If an attacking unit possesses the **`SP_CONFUSED_FIGHT`** (Melee) ability, any attack made against a ranged unit (Archer or Magician) has its final attack power multiplied by **1.5x (150%)** via `lea eax, [rax + rax*2]; sar eax, 1`.

---

### 2.3 The Ground-Truth Hit Rate Formula (`CalcAttackHitRate`)

The exact hit rate percentage displayed on screen (unlocked by Emilia's `SP_INVESTIGATION`) and used in combat resolution is calculated in native routine `0x181EED820`:

```text
Hit Rate (%) = ((Attacker Modified Power - Defender Toughness + 4) * 5)%
```

#### Constraints & Bounds Clamping:
* **Clamped Range**: `[5%, 95%]`

```asm
0x181eed953: sub bx, cx        ; bx = Attacker Power, cx = Defender Toughness
0x181eed956: add bx, 4         ; diff = (Power - Toughness + 4)
0x181eed95a: movzx eax, bx
0x181eed95d: shl ax, 2         ; diff * 4
0x181eed961: add bx, ax        ; diff * 5 (i.e. percentage)
0x181eed964: cmp bx, 5         ; Clamp lower bound
0x181eed96a: mov ebx, 5
0x181eed971: cmp bx, 0x5f      ; Clamp upper bound (0x5F = 95%)
0x181eed977: mov ebx, 0x5f
```

* **Minimum Hit Rate**: Even an overwhelming defensive disadvantage preserves a **5% hit chance**.
* **Maximum Hit Rate**: A hit chance can **never exceed 95%** (a 5% critical miss chance is hardcoded).

---

### 2.4 Combat Outcome & Critical Hit Roll (`CulcKekka`)

When resolving combat damage in `0x181EEDAA0`, the engine executes an integer roll:

```text
Roll = get_rand_maxlimit(19)    // integer roll from 0 to 19
```

1. **Auto-Miss**: If `Roll == 0`, the attack is a guaranteed miss (returns `-1`).
2. **Auto-Hit / Critical**: If `Roll == 19`, the attack is a guaranteed hit regardless of defense (returns `0`).
3. **Threshold Check**: If `Roll < (Attacker Power - Defender Toughness + 4)`, the attack hits; otherwise, it misses.

---

### 2.5 Unit Health & Heavy Armor Mechanics (`GetUnitHP`)

Unlike turn-based RPG battles where HP is counted in hundreds, war units operate on discrete hit counts:

```text
Unit Max HP = 2 + (Count of squad members with SP_HP_PLUS)
```

* **Base Health**: All units start with **2 HP**.
  * **Hit 1**: Unit receives damage flag (`damage = 1`). A crossed-swords icon appears over the sprite; unit is wounded and retreats if pressured.
  * **Hit 2**: Unit is destroyed (`damage = 2`, `UNIT_FLAG_DESTROY`). Unit is removed from the stage.
* **Heavy Armor (`SP_HP_PLUS`)**: Each character in the squad possessing `SP_HP_PLUS` adds **+1 Max HP**. A squad with Humphrey and Heavy Armor subunits can reach **3 or 4 HP**, requiring multiple successful attacks to rout.

> [!IMPORTANT]
> Vanilla documentation previously mislabeled `SP_HP_PLUS` as "Defense plus 1". Direct disassembly of `0x181F56370` (`w_unit.GetUnitHP`) verifies that it directly increments unit health capacity, not defensive toughness.

---

### 2.6 Casualty & Death Resolution (`CheckDead`)

When a unit is destroyed (`damage >= Max HP`), the engine invokes `w_dead.CheckDead` (`0x181EDB150`) to evaluate casualty severity:

1. **Initial Wound Check**: Rolls `rand(10)`. If the result is `< 3` (~27% probability), casualty evaluation begins.
2. **Target Selection**: The engine randomly chooses one of the squad members: `slot = rand(2)`.
3. **Story Immunity Verification**: The character's `status_flag` is verified:
   * If `status_flag` has `DEAD_UNPOSSIBLE` or `ANNIHILATION_UNPOSSIBLE` (e.g. Riou, Flik, Viktor, Shu), permanent death is rejected.
4. **Fatal Roll**: If the character has `DEAD_POSSIBLE`, a second roll is conducted: `rand(10) < 3`.
   * If both rolls pass (~7.3% net chance), the character suffers **permanent death** (`sibou`), triggering their death quote (`sibou_serifu`) and removing them from the Stars of Destiny tablet.
   * If either roll fails, the character is merely **wounded / retreats** (`yarare`), surviving with their retreat quote (`yarare_serifu`).

---

## 3. Movement, Terrain & Class Mobility

Movement is resolved per turn based on the leader's branch, cavalry mounts, flying beasts, and terrain navigation traits:

### 3.1 Movement Points (`GetUnitMove`)

```text
Total Movement = Base Branch Move + (2 if SP_MOUNT) + (2 if SP_FLYING)
```

* **Infantry**: 2 tiles base.
* **Archer**: 2 tiles base.
* **Magician**: 2 tiles base.
* **Cavalry (`SP_MOUNT`)**: **+2 Move** (Total 4 tiles).
* **Flying (`SP_FLYING` / Chaco)**: **+2 Move** (Total 4 tiles).
* **Mounted Aviator**: If a unit is assigned both `SP_MOUNT` and `SP_FLYING`, the bonuses stack for **+4 Movement** (Total 6 tiles).

### 3.2 Terrain Costs & Special Traversals (`w_data.GetMoveCost`)

Each map tile has an intrinsic traversal cost defined in `field_move_cost`:

| Terrain Type | Standard Infantry | Cavalry (`SP_MOUNT`) | Forest Walker (`SP_FOREST_WALK`) | Shortcut (`SP_THROUGH_ROAD`) |
| :--- | :---: | :---: | :---: | :---: |
| **Plains / Road** | 1 | 1 | 1 | 1 |
| **Forest** (Tile 1) | 2 | **5** (Severe Drag) | **1** (Reduced to minimal) | 1 |
| **Mountain Pass** | 3 | Impassable | 3 | **1** (Via Nukemiti) |
| **Water / River** | Impassable | Impassable | Impassable | Impassable (Flying only) |

* **Forest Walk (`SP_FOREST_WALK` - Ayda)**: Cancels the cavalry movement penalty in woodland tiles, reducing traversal cost to 1.
* **Shortcut / Secret Path (`SP_THROUGH_ROAD` - Templeton)**: The Japanese engine term is 抜け道 (*nukemichi*). The engine redirects movement cost calculations from `field_move_cost` to `nukemiti_move_cost`, permitting units to bypass mountain barriers and difficult terrain.

---

## 4. Complete Special Ability Catalog (`tagSPECIAL_ABILITY`)

The engine indexes 26 special ability slots (`0` to `25`).

| Code | In-Game Name | Japanese Identifier | Type | Range / Area | Uses | Tactical Effect |
| :--- | :--- | :--- | :---: | :---: | :---: | :--- |
| `SP_NONE` | None | なし | - | - | - | Empty ability slot. |
| `SP_MOUNT` | Cavalry | 騎兵 | Passive | Self | ∞ | **+2 Movement points**. Forest traversal cost increased to 5 unless paired with `SP_FOREST_WALK`. |
| `SP_CHARGE` | Charge ⚠️ | 突撃 | Cut | - | - | **Cut Content**. No active handler attached. |
| `SP_AIMING` | Aiming | 狙い撃ち | Active | 5 Tiles | 1-9 | Long-range archer snipe. Attacks target without receiving counter-attack. |
| `SP_FLAME_SPEAR` | Fire Spear | 火槍 | Active | 3 Tiles | 1-9 | Tsai's mechanized flame lance; penetrates defenses at range. |
| `SP_SHINING_SHIELD` | Bright Shield | 輝く盾 | Active | 2 Tiles AOE | 1-9 | Riou's Bright Shield Rune; restores 1 damage point to all allied units in 2-tile radius. |
| `SP_HP_PLUS` | Heavy Armor | 重装備 | Passive | Self | ∞ | **Increases unit Max HP by +1** (allows unit to take 3 hits instead of 2). |
| `SP_CRITICAL` | Critical | 会心 | Passive | Self | ∞ | Shifts roll table threshold, doubling probability of landing decisive critical hits. |
| `SP_FORCE_MOVE` | Force Move ⚠️ | 強制移動 | Cut | - | - | **Cut Content**. Incomplete enemy displacement skill. |
| `SP_SCOUT` | Scout | 偵察 | Active | Map | 1-9 | Kasumi's reconnaissance; reveals fog of war / hidden enemy reinforcements. |
| `SP_FOREST_WALK` | Forest Walk | 森林移動 | Passive | Self | ∞ | Reduces woodland tile traversal cost to **1**, neutralizing forest cavalry penalties. |
| `SP_MAGIC_WIND1` | Wind Magic | 風魔法 | Active | 3 Tiles | 1-9 | Luc's Wind Rune attack; strikes target with magical air gale. |
| `SP_MAGIC_FIRE1` | Fire Magic | 火魔法 | Active | 3 Tiles | 1-9 | Mazus's Fire Rune attack; explosive fire damage at range. |
| `SP_MAGIC_THUNDER1`| Thunder Magic | 雷魔法 | Active | 4 Tiles | 1-9 | Jeane's Lightning Rune attack; high-accuracy long-range bolt. |
| `SP_MAGIC_WIND2` | Wind Magic Lv2 ⚠️| 風魔法2 | Broken | - | - | **Non-Functional**. Stubbed in engine; lacks action delegates. Automatically ignored by PKCore. |
| `SP_SEE_THROUGH` | See Through | 見切り | Passive | Self | ∞ | Shu / Klaus intuition; detects enemy ambushes, traps, and nullifies surprise tactics. |
| `SP_KIN_SLAYER` | Kin Slayer ⚠️ | 同族殺し | Crash | - | - | **Crash Bug**. Missing `select_func` causes an immediate `NullReferenceException` in `0x181E3481E`. Blocklisted by PKCore. |
| `SP_MEDICAL1` | First Aid | 手当て | Active | 1 Tile | 1-9 | Restores 1 damage point to self or adjacent allied unit (Nanami, Tuta). |
| `SP_MEDICAL2` | Heal | 治療 | Active | 3 Tiles | 1-9 | High-grade medicine; restores 1 damage point to ally within 3 tiles (Dr. Huan). |
| `SP_THROUGH_ROAD` | Shortcut | 抜け道 | Passive | Self | ∞ | Templeton's map mastery; activates `nukemiti_move_cost` to bypass terrain roadblocks. |
| `SP_BODY_GUARD` | Bodyguard | 身代わり | Passive | Self | ∞ | Oulan's protector trait; intercepts fatal casualty rolls for the squad leader. |
| `SP_CHEAR_UP` | Cheer Up | 応援 | Active | 1 Tile | 1-9 | Annallee's song; resets an acted unit's `manuved_flag` to 0, granting an **extra turn**. |
| `SP_INVESTIGATION` | Investigation | 調査 | Passive | Self | ∞ | Emilia's scouting; unlocks the on-screen **combat hit percentage prediction HUD**. |
| `SP_INVENTION` | Invention | 発明 | Active | 1 Tile AOE | 1-9 | Adlai's bomb device; damages all adjacent squads (including allies if caught in blast). |
| `SP_CONFUSED_FIGHT`| Melee | 乱戦 | Passive | Self | ∞ | **+50% Attack Power (1.5x)** when attacking ranged units (Archers and Magicians). |
| `SP_FLYING` | Flying | 飛行 | Passive | Self | ∞ | **+2 Movement points** and ignores all ground terrain obstacles (Chaco). |

---

## 5. Technical Autopsy: Why `SP_KIN_SLAYER` Crashes

In `w_battle`, when a player clicks a special ability in the tactical UI, the engine invokes:

```c
wBattleTokusyuSelectDelegate selectFunc = w_chara.GetTokusyuSelectFunc(tokusyu_num);
```

In the assembly at `0x181E3476C`:
```asm
0x181e3476a: mov ecx, ebx              ; ebx = Ability ID (16 = SP_KIN_SLAYER)
0x181e3476c: call w_chara.GetTokusyuSelectFunc
0x181e347ba: test rax, rax             ; Verify if delegate is registered
0x181e347bd: je 0x181e3481e            ; If null, jump to panic handler!
...
0x181e3481e: call 0x1803250f0          ; IL2CPP NullReferenceException Thrower
0x181e34823: int3                      ; Hard engine crash breakpoint
```

Because Konami never implemented targeting logic for `SP_KIN_SLAYER`, its `select_func` table entry is zeroed. Selecting it triggers an unhandled `NullReferenceException` and immediately crashes the game process. PKCore blocklists this ability to safeguard stability.

---

## 6. The 16 War Battles of Suikoden II: Complete Tactical Dossier

Suikoden II contains 16 distinct military engagements, each managed by its own game data file (`w_dat_1` through `w_dat_16`). Below is the complete tactical breakdown of every engagement, including deployed allied squads, enemy command units, map configurations, and mission-critical triggers.

---

### War 1: Defense of the Mercenary Fort (`w_dat_1`)
* **Map Configuration**: `field_data_1` (Fort perimeter & clearing)
* **Engine Milestone**: `Flag 0xA9, Bit 0x40`
* **Strategic Context**: Introductory tactical skirmish. Highland launches an unprovoked assault on Viktor's Mercenary Fort.
* **Allied Order of Battle**:
  * **Viktor's Squad** (Leader: Viktor `ID 4`, ATK 8, DEF 7)
  * **Flik's Squad** (Leader: Flik `ID 3`, ATK 7, DEF 7, `SP_MOUNT`)
  * **Riou & Jowy's Unit** (Guest: Riou `ID 3347`, ATK 3, DEF 5, `SP_FLAME_SPEAR`; Jowy `ID 81`, Assist +2 ATK / +2 DEF, `SP_CRITICAL`)
  * **Mercenary Fort Defense Volunteers** (ID `3352`, ATK 6, DEF 4)
* **Highland Imperial Order of Battle**:
  * **Solon Jhee's Command** (Leader: Solon Jhee `ID 3369`, ATK 7, DEF 4)
  * **Rowd's Vanguard** (Leader: Rowd `ID 145`, ATK 8, DEF 8, `SP_MOUNT`)
  * **Highland Cavalry Squadrons** (ID `3369`, ATK 8, DEF 5, `SP_MOUNT`)
  * **Highland Archer Squadrons** (ID `3369`, ATK 7, DEF 4, `SP_AIMING`)
* **Tactical Conditions**: Scripted battle. Player holds the line for 3 turns until Solon Jhee orders a tactical withdrawal to bring up heavy siege engines.

---

### War 2: Defense of Radat - Shu's River Ambush (`w_dat_2`)
* **Map Configuration**: `field_data_2` (Radat eastern bridge & riverside)
* **Engine Milestone**: `Flag 0xAA, Bit 0x02`
* **Strategic Context**: Solon Jhee attempts a blitzkrieg march through Radat. Strategist Shu designs a trap using the river's sluice gates.
* **Allied Order of Battle**:
  * **Riou's Vanguard** (Leader: Riou `ID 3347`, ATK 8, DEF 9, `SP_SHINING_SHIELD`; Shu `ID 90`, Assist +3 ATK / +1 DEF, `SP_CRITICAL`)
  * **Flik's Cavalry** (Leader: Flik `ID 3`, ATK 7, DEF 7, `SP_MOUNT`)
  * **Viktor's Heavy Infantry** (Leader: Viktor `ID 4`, ATK 8, DEF 7)
  * **Freed Y's Radat Guard** (Leader: Freed Y `ID 3348`, ATK 6, DEF 7)
  * **Apple's Support Unit** (Subunit: Apple `ID 86`, Assist +1 ATK / +2 DEF, `SP_SEE_THROUGH`)
* **Highland Imperial Order of Battle**:
  * **General Solon Jhee** (Leader: Solon Jhee `ID 3369`, ATK 7, DEF 4)
  * **Highland Vanguard Assault** (ID `3369`, ATK 9, DEF 3, `SP_MOUNT`)
  * **Highland Line Infantry** (ID `3369`, ATK 7, DEF 4)
* **Tactical Conditions**: Allied units lure Solon Jhee across the central bridge. Once past tile X:12, Shu triggers the water flood event, severing the enemy's rear retreat route and forcing Solon Jhee's route.

---

### War 3: Defense of Two River City (`w_dat_3`)
* **Map Configuration**: `field_data_3` (Two River urban perimeter & waterways)
* **Engine Milestone**: `Flag 0x0C, Bit 0x80`
* **Strategic Context**: General Kiba advances on Two River. Humans, Kobolds, and Winged Horde must overcome racial discord to form a unified defense.
* **Allied Order of Battle**:
  * **Riou's Command Squad** (Leader: Riou `ID 3347`, ATK 8, DEF 9, `SP_SHINING_SHIELD`)
  * **Ridley's Kobold Shock Force** (Leader: Ridley `ID 118`, ATK 10, DEF 7, `SP_CRITICAL`)
  * **Two River Kobold Militia** (ID `3351`, ATK 1, DEF 0)
  * **Chaco's Winged Scouts** (Leader: Chaco `ID 55`, ATK 7, DEF 2, `SP_FLYING`, `SP_MOUNT`)
  * **Fitcher & City Guardians** (Two River Support)
* **Highland Imperial Order of Battle**:
  * **General Kiba's 1st Division** (Leader: Kiba `ID 88`, ATK 7, DEF 13, `SP_HP_PLUS` [3 HP])
  * **Klaus's Tactical Command** (Subunit: Klaus `ID 119`, Assist +3 DEF, `SP_SEE_THROUGH`)
  * **Highland Armored Shock Troops** (ID `3369`, ATK 8, DEF 5, `SP_MOUNT`)
  * **Highland Bowmen** (ID `3369`, ATK 7, DEF 4, `SP_AIMING`)
* **Tactical Conditions**: Chaco's aerial division harasses Kiba's flank; Ridley holds the central causeway until Highland vanguard retreats.

---

### War 4: Lake Castle Perimeter Skirmish (`w_dat_4`)
* **Map Configuration**: `field_data_4` (North Window shore & marsh)
* **Engine Milestone**: `Flag 0x0F, Bit 0x10`
* **Strategic Context**: Highland exploratory detachment probes the perimeter of Dunan's newly established Lake Castle HQ.
* **Allied Order of Battle**:
  * **Riou's Squad** (Leader: Riou `ID 3347`)
  * **Viktor's Squad** (Leader: Viktor `ID 4`)
  * **Flik's Squad** (Leader: Flik `ID 3`)
* **Highland Imperial Order of Battle**:
  * **Imperial Recon Detachment** (Leader: Highland Captain `ID 3369`, ATK 7, DEF 4)
  * **Advance Light Cavalry** (ID `3369`, ATK 8, DEF 5)
* **Tactical Conditions**: Low-intensity perimeter rout; clears outer patrol grounds before full castle fortification.

---

### War 5: Major Defense of Dunan HQ (`w_dat_5`)
* **Map Configuration**: `field_data_5` (South plains of Dunan Lake Castle)
* **Engine Milestone**: `Flag 0x10, Bit 0x80`
* **Strategic Context**: General Kiba marches full Highland legion on Dunan HQ. The climax of the Toran Republic diplomatic pact and Kiba's eventual defection.
* **Allied Order of Battle**:
  * **Dunan Grand Army**: Full player-customized roster available at Apple's War Room (Riou, Viktor, Flik, Ridley, Tsai, Humphrey, etc.)
  * **Toran Reinforcements** (Valeria `ID 13` or Kasumi `ID 74` depending on recruitment choice)
* **Highland Imperial Order of Battle**:
  * **Supreme Commander Kiba** (Leader: Kiba `ID 88`, ATK 7, DEF 13, `SP_HP_PLUS` [3 Max HP])
  * **Chief Strategist Klaus** (Subunit: Klaus `ID 119`, Assist +3 DEF, `SP_SEE_THROUGH`)
  * **Highland Iron Vanguard** (ID `3369`, ATK 9, DEF 3, `SP_MOUNT`)
  * **Highland Heavy Crossbowmen** (ID `3369`, ATK 7, DEF 4, `SP_AIMING`)
* **Tactical Conditions**: Defeat Kiba's central unit. Triggers Kiba & Klaus surrender, recruiting both into the Dunan Alliance as permanent officers.

---

### War 6: Luca Blight Night Ambush (`w_dat_6`)
* **Map Configuration**: `field_data_6` (Woodland crossroads at dusk)
* **Engine Milestone**: `Flag 0x74, Bit 0x20`
* **Strategic Context**: Shu's three-stage nocturnal trap to assassinate the mad Highland King Luca Blight.
* **Allied Order of Battle**:
  * **Riou's Ambush Force** (Riou `ID 3347`, Luc `ID 54`, Shu `ID 90`)
  * **Flik's Ambush Force** (Flik `ID 3`, Ayda `ID 44`, Camus `ID 34`)
  * **Viktor's Ambush Force** (Viktor `ID 4`, Humphrey `ID 11`, Miklotov `ID 33`)
* **Highland Imperial Order of Battle**:
  * **King Luca Blight** (Boss: Luca Blight `ID 3361`, **ATK 18, DEF 17**, `SP_MOUNT`, **3 Max HP**)
  * **White Wolf Royal Guards** (ID `3369`, ATK 9, DEF 5, `SP_MOUNT`)
* **Tactical Conditions**: Luca Blight cannot be conventionally routed. Dealing 2 hits triggers the sequence where his squad scatters into the woods, leading to the legendary 3-party combat duel.

---

### War 7: Liberation of Greenhill City (`w_dat_7`)
* **Map Configuration**: `field_data_7` (Greenhill outer gates and academy lawns)
* **Engine Milestone**: `Flag 0x75, Bit 0x08`
* **Strategic Context**: Joint offensive alongside Mayor Teresa Wisemail to liberate Greenhill from Karaya and Nether Gate occupiers.
* **Allied Order of Battle**:
  * **Teresa's Snipers** (Leader: Teresa `ID 102`, ATK 5, DEF 6, `SP_AIMING`; Shin `ID 16`, Assist +1 ATK, `SP_CRITICAL`)
  * **Dunan Core Division** (Riou, Flik, Viktor, Hauser)
* **Highland & Karaya Order of Battle**:
  * **Yuber's Chaos Unit** (Leader: Yuber `ID 152`, **ATK 14, DEF 6**, `SP_MOUNT`)
  * **Lucia's Karaya Shock Clan** (Leader: Lucia `ID 146`, ATK 8, DEF 7, `SP_FOREST_WALK`)
  * **Highland Occupying Garrison** (ID `3369`)
* **Tactical Conditions**: Eliminate Yuber or breach inner gate. Yuber vanishes when pressured, causing remaining Karaya troops to withdraw into the grasslands.

---

### War 8: Matilda Border Campaign (`w_dat_8`)
* **Map Configuration**: `field_data_8` (Matilda forest borders & highway)
* **Engine Milestone**: `Flag 0x77, Bit 0x10/0x20`
* **Strategic Context**: Dunan moves north to liberate the Knights of Matilda from Highland vassalage under Commander Gorudo.
* **Allied Order of Battle**:
  * **Dunan Main Army** (Riou, Kiba, Klaus, Ridley, Hauser)
  * **Matilda Defectors (Mid-Battle Reinforcement)**: Camus (`ID 34`, ATK 9, DEF 8) & Miklotov (`ID 33`, ATK 11, DEF 6)
* **Opposing Coalition**:
  * **Commander Gorudo's Matilda Guard** (Gorudo `ID 121`, ATK 9, DEF 9)
  * **Matilda Heavy Knights** (ID `3350`, ATK 5, DEF 4, `SP_MOUNT`)
  * **Highland Liaison Officers** (ID `3369`)
* **Tactical Conditions**: On Turn 3, Miklotov and Camus renounce Gorudo's cowardice, turning their units green (Allied) and collapsing Gorudo's frontline.

---

### War 9: Liberation of Muse City (`w_dat_9`)
* **Map Configuration**: `field_data_9` (Muse fortress ramparts & eastern plains)
* **Engine Milestone**: `Flag 0x78, Bit 0x10/0x20`
* **Strategic Context**: Dunan launches a full frontal assault to recapture Muse City from King Jowy Atreides.
* **Allied Order of Battle**:
  * **Dunan Liberation Army**: Full player tactical roster.
* **Highland Imperial Order of Battle**:
  * **King Jowy Atreides** (Leader: Jowy `ID 81`, **ATK 13, DEF 11**, `SP_MOUNT`)
  * **Strategist Culgan** (Leader: Culgan `ID 143`, ATK 9, DEF 10, `SP_MOUNT`)
  * **Iron Shield Seed** (Leader: Seed `ID 144`, ATK 7, DEF 9, `SP_MOUNT`)
  * **Golden Wolf Legionnaires** (ID `3369`, ATK 8, DEF 5, `SP_MOUNT`)
* **Tactical Conditions**: Breach Muse gate perimeter. Jowy executes a calculated retreat back into Highland heartland, setting the stage for the capital campaign.

---

### War 10: Tinto Mountain Defense (`w_dat_10`)
* **Map Configuration**: `field_data_10` (Rugged rocky plateaus of Tinto)
* **Engine Milestone**: `Flag 0x7A, Bit 0x04`
* **Strategic Context**: Fighting off Neclord's supernatural undead horde in steep crags.
* **Allied Order of Battle**:
  * **Riou & Gustav's Garrison**
  * **Hauser's Mountain Division** (Hauser `ID 35`, ATK 9, DEF 7)
  * **Tinto Bandit Strike Force** (Gijimu `ID 59`, Koyu `ID 60`, Lowen `ID 61` - `SP_CONFUSED_FIGHT`)
* **Zombie / Vampire Legion**:
  * **Neclord's Vanguard** (Undead shock battalions)
  * **Zombie Swarm** (High numbers, low mobility, high attrition)
* **Tactical Conditions**: Heavy mountain tiles (Movement cost 3). Templeton's `SP_THROUGH_ROAD` or Chaco's `SP_FLYING` are required for fast flanking.

---

### War 11: South Window Border Defense (`w_dat_11`)
* **Map Configuration**: `field_data_11` (South Window river boundary)
* **Strategic Context**: Countering secondary Highland reconnaissance and incursions along the southern frontier.
* **Allied Order of Battle**: Freed Y, Viktor, Flik, local border guard.
* **Highland Forces**: Highland Border Patrol (ID `3369`).
* **Tactical Conditions**: Repel enemy squads before they cross the river boundary.

---

### War 12: Radat Retake Campaign (`w_dat_12`)
* **Map Configuration**: `field_data_2` (Radat town crossing)
* **Strategic Context**: Offensive naval/land combined operation to eliminate Highland occupiers holding the eastern shipping corridor.
* **Allied Order of Battle**: Riou, Shu, Tai Ho, Yam Koo, Amada (marine coordination).
* **Highland Forces**: Highland Occupation Force (ID `3369`).
* **Tactical Conditions**: Clear the bridgeheads and liberate Radat municipal center.

---

### War 13: Rockaxe Castle Outer Gates (`w_dat_13`)
* **Map Configuration**: `field_data_8` (Rockaxe mountain approach)
* **Strategic Context**: Storming the fortress of Rockaxe to depose Gorudo and sever Highland's western support.
* **Allied Order of Battle**: Dunan Army spearheaded by Camus, Miklotov, and Humphrey.
* **Highland & White Knight Forces**: Gorudo's remaining loyalists & Highland rear-guard.
* **Tactical Conditions**: Breach the citadel outer walls; leads directly into the Rockaxe interior assault.

---

### War 14: L'Renouille Frontier Assault (`w_dat_14`)
* **Map Configuration**: `field_data_1` (Highland border plains)
* **Engine Milestone**: `Flag 0x82, Bit 0x01`
* **Strategic Context**: The breakthrough into Highland proper. Allied forces face veteran general Han Cunningham.
* **Allied Order of Battle**: Dunan Grand Army.
* **Highland Imperial Order of Battle**:
  * **General Han Cunningham** (Leader: Han `ID 149`, **ATK 11, DEF 12**, `SP_MOUNT`)
  * **Highland Veteran Cavalry** (ID `3369`, ATK 8, DEF 5, `SP_MOUNT`)
  * **Highland Elite Archers** (ID `3369`, ATK 7, DEF 4, `SP_AIMING`)
* **Tactical Conditions**: Defeat General Han. Triggers Han's honorable duel with Riou and opens the road to the capital.

---

### War 15: Capital Siege: L'Renouille Gates (`w_dat_15`)
* **Map Configuration**: `field_data_1` (Capital palace exterior)
* **Engine Milestone**: `Flag 0x84, Bit 0x02`
* **Strategic Context**: The final tactical war battle of Suikoden II. Allied army besieges the imperial palace of Highland.
* **Allied Order of Battle**: Dunan Alliance Grand Army (All 108 Stars assembled).
* **Highland Imperial Elite**:
  * **General Culgan** (Leader: Culgan `ID 143`, **ATK 9, DEF 10**, `SP_MOUNT`)
  * **General Seed** (Leader: Seed `ID 144`, **ATK 7, DEF 9**, `SP_MOUNT`)
  * **Imperial Royal Guard Battalions** (ID `3369`, ATK 9, DEF 5, `SP_MOUNT`)
* **Tactical Conditions**: Rout both Culgan and Seed to breach the palace gate and initiate the final castle infiltration.

---

### War 16: Fallback Defense Skirmish (`w_dat_16`)
* **Map Configuration**: `field_data_5` (HQ perimeter fallback)
* **Strategic Context**: Emergency tactical fail-safe map in the engine, programmed for scripted defensive counter-attacks.
* **Forces**: Scaled dynamically based on story progression flags.

---

## 7. Formation Roster UI & Engine Synchronization (`Butai.cs`)

### Why Custom Stats Originally Only Appeared in War Battles
In vanilla gameplay, Apple's unit organization screen at Castle HQ (`vk07`) is managed by `Butai.cs`, whereas active war encounters run inside `WarChapter.cs`.

```
Castle HQ Room (vk07)                Active War Battle Map
[Talk to Apple]                      [War Chapter Begins]
       │                                      │
       ▼                                      ▼
 Butai.InitButai()                     w_chara.charaInit()
       │                                      │
       ▼                                      ▼
Reads w_dat_butai.chara_butai          Reads w_dat_butai.chara_butai
(Shows Vanilla Stats in UI)            (PKCore Applies Custom JSON)
```

1. **`w_chara.charaInit`**: Only invoked when loading into an actual war map (`WarChapter`).
2. **`Butai.InitButai`**: Instantiated separately whenever the player talks to Apple in the strategy room. `Butai` reads the static array `w_dat_butai.chara_butai`.

Because `PKCore` patches `w_chara.charaInit` and `w_dat_butai` at the start of battle, custom configurations take full mathematical effect during combat encounters, while Apple's unit management UI displays base engine figures unless `Butai.InitButai` is synchronized.

---

## 8. PKCore War Modding Configuration Guide

### 8.1 File Placement & Activation

1. Enable the mod in `BepInEx/config/faospark.pkcore.cfg`:
   ```ini
   [05 Game : Suikoden 2]
   EnableWarAbilityMod = true
   ```
2. Configuration file path:
   ```
   <Game Root>/PKCore/Config/S2WarAbilities.json
   ```

### 8.2 JSON Schema & Fields

```json
{
  "globalAbilities": ["SP_MOUNT"],
  "characterAbilities": {
    "3347": {
      "name": "Riou",
      "abilities": ["SP_SHINING_SHIELD", "SP_MOUNT", "SP_CRITICAL"],
      "attack": 12,
      "defense": 12,
      "bonusAttack": 3,
      "bonusDefense": 2
    }
  }
}
```

* **`globalAbilities`**: Array of ability strings granted to **all units**.
* **`abilities`**: Array of up to **3 abilities** (unlocking the hidden 3rd slot!).
* **`attack`**: Overrides base Leader Attack Power (used when character leads a squad).
* **`defense`**: Overrides base Leader Toughness (used when character leads a squad).
* **`bonusAttack`**: Overrides Assist Attack bonus (`assist_attack`), granted to the squad when this character is assigned as a Subunit.
* **`bonusDefense`**: Overrides Assist Defense bonus (`assist_defense`), granted to the squad when this character is assigned as a Subunit.
* **`name`**: Descriptive label for readability (not processed by engine).

---

### 8.3 Verified Character ID Reference Tables

> [!NOTE]
> Character keys in JSON represent the character's internal engine text name index. Riou is `3347` and Freed Y is `3348` due to player-naming string allocation tables. All other characters use their fixed engine narrative IDs.

#### 1. Playable Squad Leaders (Commanding Officers)

| Character ID | Name | Base ATK | Base DEF | Default Abilities | Strategic Classification & Role |
| :---: | :--- | :---: | :---: | :--- | :--- |
| **`3347`** | Riou | 8 | 9 | `SP_SHINING_SHIELD` | Supreme Commander; 2-tile radius area heal anchor. |
| **`4`** | Viktor | 8 | 7 | None | Heavy infantry offensive frontline commander. |
| **`3`** | Flik | 7 | 7 | `SP_MOUNT` | Fast cavalry spearhead commander. |
| **`118`** | Ridley | 10 | 7 | `SP_CRITICAL` | High-damage critical shock striker (Kobold Corps). |
| **`13`** | Valeria | 8 | 8 | `SP_MOUNT` | High-mobility shock cavalry vanguard. |
| **`88`** | Kiba | 7 | 12 | `SP_HP_PLUS`, `SP_MOUNT` | Super-heavy **3 Max HP** cavalry fortress. |
| **`35`** | Hauser | 9 | 7 | `SP_MOUNT` | Heavy armored cavalry general. |
| **`12`** | Georg | 11 | 8 | `SP_CRITICAL` | Elite critical combat champion. |
| **`120`** | Maximillian | 6 | 7 | `SP_MOUNT` | Veteran knight frontline commander. |
| **`122`** | Gilbert | 7 | 8 | None | Defected Highland heavy infantry officer. |
| **`102`** | Teresa | 5 | 6 | `SP_AIMING` | 5-tile sniper archer squad. |
| **`44`** | Ayda | 6 | 5 | `SP_MEDICAL1`, `SP_FOREST_WALK` | Forest woodland scout & field medic. |
| **`74`** | Kasumi | 6 | 6 | `SP_SCOUT` | Ninja scout; reveals enemy ambushes. |
| **`123`** | Boris | 9 | 8 | `SP_SEE_THROUGH` | Ridley's successor; tactical defense specialist. |
| **`54`** | Luc | 10 | 4 | `SP_MAGIC_WIND1` | High-damage 3-tile wind magic bombardier. |
| **`62`** | Mazus | 9 | 6 | `SP_MAGIC_FIRE1` | High-damage 3-tile explosive fire mage. |
| **`34`** | Camus | 9 | 8 | `SP_MOUNT` | Matilda Knight leader; balanced cavalry officer. |
| **`33`** | Miklotov | 11 | 6 | `SP_MOUNT` | Matilda Knight leader; offensive spearhead commander. |
| **`3348`** | Freed Y | 6 | 7 | None | Radat municipal infantry commander. |

---

#### 2. Subunit Specialists & Support Officers (Adjutants)

| Character ID | Name | Assist ATK | Assist DEF | Assigned Abilities | Adjutant Specialty & Engine Effect |
| :---: | :--- | :---: | :---: | :--- | :--- |
| **`90`** | Shu | 3 | 1 | `SP_CRITICAL`, `SP_SEE_THROUGH` | Chief Strategist; critical boost + ambush nullification. |
| **`86`** | Apple | 1 | 2 | `SP_SEE_THROUGH` | Tactical adviser; defensive boost + ambush counter. |
| **`119`** | Klaus | 0 | 3 | `SP_SEE_THROUGH`, `SP_MOUNT` | High defensive tactics (+3 DEF) + cavalry mobility. |
| **`19`** | Nanami | 1 | 1 | `SP_MEDICAL1` | Emergency field dressing; restores 1 damage point. |
| **`53`** | Tsai | 1 | 0 | `SP_FLAME_SPEAR` | Grants 3-tile Fire Spear ranged artillery attack. |
| **`16`** | Shin | 1 | 0 | `SP_CRITICAL` | Increases squad critical strike threshold. |
| **`15`** | Shin (Subunit) | 0 | 2 | None | Teresa's dedicated defensive protector (+2 DEF). |
| **`94`** | Jess | 2 | 0 | `SP_SEE_THROUGH` | Strategic advisor; defensive detection. |
| **`93`** | Huan | 0 | 0 | `SP_MEDICAL2` | Dr. Huan's advanced clinic; 3-tile range heal. |
| **`23`** | Tuta | 0 | 0 | `SP_MEDICAL1` | Apprentice medic; restores 1 damage point to adjacent unit. |
| **`11`** | Humphrey | 0 | 2 | `SP_HP_PLUS` | **Heavy Armor**: Grants **+1 Max HP** (3 hits) +2 DEF. |
| **`87`** | Templeton | 0 | 1 | `SP_THROUGH_ROAD` | **Nukemiti Shortcut**: Ignores mountains & rough terrain. |
| **`117`** | Jeane | 0 | 0 | `SP_MAGIC_THUNDER1` | 4-tile long-range lightning spell bombardment. |
| **`39`** | Anita | 2 | 1 | None | Aggressive swordswoman (+2 ATK, +1 DEF). |
| **`101`** | Teresa (Subunit)| 1 | 1 | None | Greenhill mayoral support (+1 ATK, +1 DEF). |
| **`47`** | Oulan | 0 | 0 | `SP_BODY_GUARD` | **Bodyguard**: Intercepts fatal casualty rolls for commander. |
| **`113`** | Annallee | 0 | 0 | `SP_CHEAR_UP` | **Cheer Up**: Grants an acted unit an **extra turn**. |
| **`14`** | Pesmerga | 3 | 0 | `SP_MOUNT` | Heavy dark knight (+3 ATK) + cavalry mobility. |
| **`97`** | Emilia | 0 | 0 | `SP_INVESTIGATION` | **Investigation**: Unlocks combat hit % prediction HUD. |
| **`106`** | Adlai | 0 | 0 | `SP_INVENTION` | **Invention**: 1-tile AOE explosive bomb device. |
| **`24`** | Millie | 2 | 0 | None | Pet ground strike (+2 ATK bonus). |
| **`55`** | Chaco | 0 | 1 | `SP_FLYING` | **Flying**: Grants aerial flight (+2 Move, bypasses terrain). |
| **`59`** | Gijimu | 2 | 0 | `SP_CONFUSED_FIGHT` | Tinto bandit; **+50% damage vs Archers and Magicians**. |
| **`60`** | Koyu | 1 | 0 | `SP_MEDICAL1` | Tinto scout; field first aid. |
| **`61`** | Lowen | 2 | 0 | `SP_CONFUSED_FIGHT` | Tinto fighter; **+50% damage vs Archers and Magicians**. |
| **`81`** | Jowy (Guest) | 2 | 2 | `SP_CRITICAL` | Early game guest ally; strong dual bonus (+2 ATK, +2 DEF). |

---

#### 3. Regional Auxiliaries, Militia & Allied Guest Units

| Character ID | Name / Unit Type | Base ATK | Base DEF | Unit Branch | Role & Strategic Context |
| :---: | :--- | :---: | :---: | :---: | :--- |
| **`3352`** | Mercenary Fort Captain | 6 | 4 | Infantry | Viktor's garrison regulars during War 1 & early defense. |
| **`3350`** | Matilda Cavalry Captain | 5 | 4 | Cavalry (`SP_MOUNT`) | Allied Matilda Knight shock units during War 8. |
| **`3351`** | Two River Kobold Militia | 1 | 0 | Infantry | Kobold urban defensive militia during War 3. |

---

#### 4. Enemy Imperial Commanders, Bosses & Highland Squads

| Character ID | Name / Unit Title | Base ATK | Base DEF | Special Traits | Strategic Profile & Threat Level |
| :---: | :--- | :---: | :---: | :--- | :--- |
| **`3361`** | **Luca Blight** | **18** | **17** | `SP_MOUNT`, **3 Max HP** | **Supreme Boss**: Unstoppable juggernaut during War 6. Highest base stats in engine. |
| **`149`** | **Han Cunningham** | **11** | **12** | `SP_MOUNT` | Veteran Imperial General (War 14). High defense cavalry wall. |
| **`81`** | **Jowy Atreides (King)**| **13** | **11** | `SP_MOUNT` | Highland Supreme Commander during War 9 & 13. |
| **`152`** | **Yuber** | **14** | **6** | `SP_MOUNT` | Chaos Knight (War 7 Greenhill). Lethal strike power; withdraws when wounded. |
| **`143`** | **Culgan** | **9** | **10** | `SP_MOUNT` | Imperial Chief of Staff (War 15 L'Renouille Gates). Balanced cavalry commander. |
| **`144`** | **Seed** | **7** | **9** | `SP_MOUNT` | Imperial General (War 15 L'Renouille Gates). Defensive vanguard anchor. |
| **`145`** | **Rowd** | **8** | **8** | `SP_MOUNT` | Highland Vanguard Enforcer during War 1. Fast offensive cavalry. |
| **`88`** | **Kiba (Highland Force)**| **7** | **13** | `SP_HP_PLUS`, `SP_MOUNT` | Imperial 1st Division Commander (War 3 & 5). **3 Max HP** heavy fortress. |
| **`119`** | **Klaus (Highland Force)**| 0 | **+3** | `SP_SEE_THROUGH`, `SP_MOUNT` | Imperial Tactical Advisor (War 3 & 5). Unbreakable defensive tactics. |
| **`3369`** | **Solon Jhee** | 7 | 4 | Infantry | Highland Frontier General (War 1 & 2). Aggressive frontline commander. |
| **`3369`** | Highland Cavalry Captain | 8 | 5 | `SP_MOUNT` | Standard Imperial Cavalry Squad. 4 movement tiles. |
| **`3369`** | Highland Archer Captain | 7 | 4 | `SP_AIMING` | Standard Imperial Archer Squad. 5-tile ranged snipe. |
| **`3369`** | Highland Vanguard Captain| 9 | 3 | `SP_MOUNT` | Aggressive Imperial Vanguard Shock Squad. |
| **`121`** | **Gorudo** | 9 | 9 | `SP_MOUNT` | Matilda Knight Commander (War 8 & 13). Armored cavalry traitor. |
| **`146`** | **Lucia** | 8 | 7 | `SP_FOREST_WALK` | Karaya Clan Leader (War 7). High forest mobility shock unit. |
| **`148`** | **Neclord** | 8 | 8 | Undead Horde | Undead Commander (War 10). Controls infinite zombie legions. |

---

## 9. Recommended Tactical Builds

### 9.1 The Unstoppable Siege Tank
Combines maximum health pools, terrain disregard, and self-restoration:
```json
"3347": {
  "name": "Riou",
  "abilities": ["SP_SHINING_SHIELD", "SP_HP_PLUS", "SP_THROUGH_ROAD"],
  "attack": 12,
  "defense": 14
}
```
* **Engine Result**: 3 Max HP, area healing radius of 2 tiles, and complete terrain freedom through Templeton's shortcut routine.

### 9.2 The Blitzkrieg Aviator
Combines mounted speed with aerial mobility to produce 6 tiles of unrestricted movement:
```json
"13": {
  "name": "Valeria",
  "abilities": ["SP_MOUNT", "SP_FLYING", "SP_CRITICAL"],
  "attack": 14,
  "defense": 10
}
```
* **Engine Result**: Base move 2 + Mount 2 + Flying 2 = **6 movement tiles**, bypassing rivers and mountains to assassinate enemy mages.

### 9.3 The Anti-Ranged Hunter
Optimized to punish archers and magical bombardiers:
```json
"4": {
  "name": "Viktor",
  "abilities": ["SP_CONFUSED_FIGHT", "SP_MOUNT", "SP_CRITICAL"],
  "attack": 15,
  "defense": 10
}
```
* **Engine Result**: 4 movement tiles; inflicts **1.5x damage** against any ranged unit, turning Luca Blight or Yuber squads into quick routs.
