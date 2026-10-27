# Suikoden II Geographic Area Documentation: Comprehensive Correction & Grounding Audit Report

**Audit Timestamp**: 2026-10-28 00:59:46
**Target Directory**: `Documentation/areas/`
**Total Area Files Inspected**: 62
**Files Corrected & Enriched**: 61
**Total Corrections & Grounded Annotations Applied**: 3,390

---

## 1. Executive Summary of Corrections

### A. Fixed Misattributed Entities (fpno 83: 'Luca Blight' -> 'Bonaparte')
In the original area catalog generation, sprite pattern `fpno 83` was mistakenly identified as **Luca Blight** across multiple maps:
- **Ryube Village** (`ryube_village.md`): Millie's pet Bonaparte was erroneously listed as Luca Blight (3 table entries and 3 object descriptions).
- **Swallow Pass / Ryube Forest** (`swallow_pass_ryube_forest.md`): The wild pet encounter sprite `obj[04]` was misidentified as Luca Blight instead of Bonaparte.
- **Dunan Castle HQ Bathhouse** (`dunan_castle_hq_bathhouse.md`): `obj[25]` in the bathhouse was erroneously labeled Luca Blight instead of Bonaparte.
- **HQ Living Quarters** (`dunan_castle_hq_living_quarters_and_corridors.md`): `obj[02]` was mislabeled Luca Blight instead of Bonaparte.
- **HQ Memorial Graveyard** (`dunan_castle_hq_memorial_graveyard.md`): `obj[04]` was mislabeled Luca Blight instead of Bonaparte.
- **North Window Ruins** (`north_window_ruins.md`): Event bytecode action decoded as `Recruit Luca Blight into Battle Slot 1` corrected to `Recruit Milie Sans Bonapart into Battle Slot 1` (Character ID 83).

### B. Grounded Bytecode Character Recruitment Annotations (`Recruit Character into Active Party`)
Resolved 889 cryptic party recruitment calls across all 62 area maps. Instead of ungrounded raw numeric IDs (e.g. `(24, 8)` or `(84, 62)`), every call now explicitly identifies the character name from the verified engine database (e.g. `(24 [Milie], 8)` and `(84 [Bonaparte], 62)`).

### C. Grounded Character Dismissal Annotations (`Dismiss Character to Castle Base`)
Resolved 820 raw character dismissal bytecodes across castle and story maps with exact character names (e.g. `Dismiss Character to Castle Base (36 [Kahn])`, `(110 [Tessai])`, `(18 [Nanami])`).

### D. Grounded Inventory Item Check Annotations (`Inventory Holds Item #`)
Resolved 1,913 condition checks where story scripts inspected the party's bag for quest items by raw number (e.g. `#1 [Medicine]`, `#8 [Fire Wall]`, `#29 [Blinking Mirror]`, `#30 [Sacrifical Jizo]`, `#44 [Reference Letter]`).

---

## 2. Per-File Detailed Audit Log

### `banner_village.md` (56 changes)

**Critical Entity Fixes**:
- Annotated recruit action: ID 84 -> [Bonaparte]
- Annotated recruit action: ID 84 -> [Bonaparte]
- Annotated recruit action: ID 84 -> [Bonaparte]
- Annotated recruit action: ID 84 -> [Bonaparte]

**Party Recruitment Annotations** (40):
- Annotated recruit action: ID 24 -> [Milie]
- Annotated recruit action: ID 84 -> [Bonaparte]
- Annotated recruit action: ID 23 -> [Hanna]
- Annotated recruit action: ID 73 -> [Kasumi]
- Annotated recruit action: ID 33 -> [Camus]
- Annotated recruit action: ID 37 -> [Amada]
- Annotated recruit action: ID 24 -> [Milie]
- Annotated recruit action: ID 33 -> [Camus]
- Annotated recruit action: ID 33 -> [Camus]
- Annotated recruit action: ID 84 -> [Bonaparte]
- *... and 30 more recruitment annotations*

**Character Dismissal Annotations** (7):
- Annotated dismiss action: ID 82 -> [McDohl]
- Annotated dismiss action: ID 82 -> [McDohl]
- Annotated dismiss action: ID 82 -> [McDohl]
- Annotated dismiss action: ID 82 -> [McDohl]
- Annotated dismiss action: ID 8 -> [Tengaar]
- Annotated dismiss action: ID 8 -> [Tengaar]
- Annotated dismiss action: ID 8 -> [Tengaar]

**Inventory Item Check Annotations** (9):
- Annotated inventory check: Item #9 -> [Kindness Drops]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #32 -> [Drinking Set]
- Annotated inventory check: Item #9 -> [Kindness Drops]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #16 -> [Revenge Earth]
- Annotated inventory check: Item #32 -> [Drinking Set]
- Annotated inventory check: Item #64 -> [Recipe #33]
- Annotated inventory check: Item #4 -> [Throat Drops]


### `cave_of_the_wind.md` (17 changes)

**Party Recruitment Annotations** (5):
- Annotated recruit action: ID 26 -> [Shiro]
- Annotated recruit action: ID 26 -> [Shiro]
- Annotated recruit action: ID 26 -> [Shiro]
- Annotated recruit action: ID 26 -> [Shiro]
- Annotated recruit action: ID 24 -> [Milie]

**Character Dismissal Annotations** (3):
- Annotated dismiss action: ID 36 -> [Kahn]
- Annotated dismiss action: ID 36 -> [Kahn]
- Annotated dismiss action: ID 13 -> [Pesmerga]

**Inventory Item Check Annotations** (9):
- Annotated inventory check: Item #64 -> [Recipe #33]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #8 -> [Fire Wall]
- Annotated inventory check: Item #9 -> [Kindness Drops]


### `coronet_town_and_port.md` (20 changes)

**Party Recruitment Annotations** (12):
- Annotated recruit action: ID 43 -> [Ayda]
- Annotated recruit action: ID 43 -> [Ayda]
- Annotated recruit action: ID 58 -> [Gijimu]
- Annotated recruit action: ID 58 -> [Gijimu]
- Annotated recruit action: ID 43 -> [Ayda]
- Annotated recruit action: ID 58 -> [Gijimu]
- Annotated recruit action: ID 58 -> [Gijimu]
- Annotated recruit action: ID 43 -> [Ayda]
- Annotated recruit action: ID 43 -> [Ayda]
- Annotated recruit action: ID 72 -> [Siegfried]
- *... and 2 more recruitment annotations*

**Character Dismissal Annotations** (3):
- Annotated dismiss action: ID 47 -> [Genshu]
- Annotated dismiss action: ID 47 -> [Genshu]
- Annotated dismiss action: ID 47 -> [Genshu]

**Inventory Item Check Annotations** (5):
- Annotated inventory check: Item #9 -> [Kindness Drops]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #4 -> [Throat Drops]


### `crom_village.md` (56 changes)

**Party Recruitment Annotations** (1):
- Annotated recruit action: ID 2 -> [Flik]

**Character Dismissal Annotations** (33):
- Annotated dismiss action: ID 114 -> [Alberto]
- Annotated dismiss action: ID 114 -> [Alberto]
- Annotated dismiss action: ID 114 -> [Alberto]
- Annotated dismiss action: ID 93 -> [Jess]
- Annotated dismiss action: ID 18 -> [Nanami]
- Annotated dismiss action: ID 3 -> [Viktor]
- Annotated dismiss action: ID 3 -> [Viktor]
- Annotated dismiss action: ID 18 -> [Nanami]
- Annotated dismiss action: ID 18 -> [Nanami]
- Annotated dismiss action: ID 3 -> [Viktor]
- *... and 23 more dismissal annotations*

**Inventory Item Check Annotations** (22):
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #8 -> [Fire Wall]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #16 -> [Revenge Earth]
- Annotated inventory check: Item #32 -> [Drinking Set]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #16 -> [Revenge Earth]
- Annotated inventory check: Item #4 -> [Throat Drops]
- *... and 12 more item check annotations*


### `tigermouth_village.md` (formerly `drakemouth_village.md`) (5 changes)

**Character Dismissal Annotations** (2):
- Annotated dismiss action: ID 117 -> [Ridley]
- Annotated dismiss action: ID 2 -> [Flik]

**Inventory Item Check Annotations** (3):
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #1 -> [Medicine]


### `dunan_castle_hq_bathhouse.md` (4 changes)

**Critical Entity Fixes**:
- Fixed `obj[25]` (fpno 83): misidentified as 'Luca Blight' -> corrected to '**Bonaparte**'
- Fixed bullet description for `obj[25]`: '(Luca Blight)' -> '(Bonaparte)'

**Inventory Item Check Annotations** (2):
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]


### `dunan_castle_hq_cartography_room.md` (2 changes)

**Inventory Item Check Annotations** (2):
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]


### `dunan_castle_hq_commanders_quarters.md` (267 changes)

**Party Recruitment Annotations** (2):
- Annotated recruit action: ID 24 -> [Milie]
- Annotated recruit action: ID 9 -> [Futch]

**Character Dismissal Annotations** (155):
- Annotated dismiss action: ID 3 -> [Viktor]
- Annotated dismiss action: ID 88 -> [Fitcher]
- Annotated dismiss action: ID 88 -> [Fitcher]
- Annotated dismiss action: ID 2 -> [Flik]
- Annotated dismiss action: ID 3 -> [Viktor]
- Annotated dismiss action: ID 18 -> [Nanami]
- Annotated dismiss action: ID 88 -> [Fitcher]
- Annotated dismiss action: ID 4 -> [Viki]
- Annotated dismiss action: ID 6 -> [Clive]
- Annotated dismiss action: ID 10 -> [Humphrey]
- *... and 145 more dismissal annotations*

**Inventory Item Check Annotations** (110):
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #8 -> [Fire Wall]
- Annotated inventory check: Item #8 -> [Fire Wall]
- *... and 100 more item check annotations*


### `dunan_castle_hq_concert_stage.md` (17 changes)

**Party Recruitment Annotations** (16):
- Annotated recruit action: ID 24 -> [Milie]
- Annotated recruit action: ID 46 -> [Oulan]
- Annotated recruit action: ID 46 -> [Oulan]
- Annotated recruit action: ID 46 -> [Oulan]
- Annotated recruit action: ID 46 -> [Oulan]
- Annotated recruit action: ID 46 -> [Oulan]
- Annotated recruit action: ID 46 -> [Oulan]
- Annotated recruit action: ID 46 -> [Oulan]
- Annotated recruit action: ID 24 -> [Milie]
- Annotated recruit action: ID 46 -> [Oulan]
- *... and 6 more recruitment annotations*

**Inventory Item Check Annotations** (1):
- Annotated inventory check: Item #1 -> [Medicine]


### `dunan_castle_hq_docks_and_fishing.md` (12 changes)

**Party Recruitment Annotations** (1):
- Annotated recruit action: ID 3 -> [Viktor]

**Character Dismissal Annotations** (2):
- Annotated dismiss action: ID 5 -> [Sheena]
- Annotated dismiss action: ID 79 -> [Chuchara]

**Inventory Item Check Annotations** (9):
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #8 -> [Fire Wall]
- Annotated inventory check: Item #16 -> [Revenge Earth]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #16 -> [Revenge Earth]
- Annotated inventory check: Item #1 -> [Medicine]


### `dunan_castle_hq_farm_and_pastures.md` (3 changes)

**Party Recruitment Annotations** (1):
- Annotated recruit action: ID 46 -> [Oulan]

**Inventory Item Check Annotations** (2):
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]


### `dunan_castle_hq_great_hall_and_entry.md` (169 changes)

**Party Recruitment Annotations** (2):
- Annotated recruit action: ID 101 -> [Teresa]
- Annotated recruit action: ID 101 -> [Teresa]

**Character Dismissal Annotations** (23):
- Annotated dismiss action: ID 5 -> [Sheena]
- Annotated dismiss action: ID 35 -> [Freed Y]
- Annotated dismiss action: ID 5 -> [Sheena]
- Annotated dismiss action: ID 5 -> [Sheena]
- Annotated dismiss action: ID 154 -> [Lilly]
- Annotated dismiss action: ID 3 -> [Viktor]
- Annotated dismiss action: ID 35 -> [Freed Y]
- Annotated dismiss action: ID 5 -> [Sheena]
- Annotated dismiss action: ID 5 -> [Sheena]
- Annotated dismiss action: ID 154 -> [Lilly]
- *... and 13 more dismissal annotations*

**Inventory Item Check Annotations** (144):
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- *... and 134 more item check annotations*


### `dunan_castle_hq_grounds_and_sanctuary.md` (8 changes)

**Inventory Item Check Annotations** (8):
- Annotated inventory check: Item #9 -> [Kindness Drops]
- Annotated inventory check: Item #9 -> [Kindness Drops]
- Annotated inventory check: Item #9 -> [Kindness Drops]
- Annotated inventory check: Item #9 -> [Kindness Drops]
- Annotated inventory check: Item #9 -> [Kindness Drops]
- Annotated inventory check: Item #9 -> [Kindness Drops]
- Annotated inventory check: Item #9 -> [Kindness Drops]
- Annotated inventory check: Item #9 -> [Kindness Drops]


### `dunan_castle_hq_guardian_deity_shrine.md` (7 changes)

**Party Recruitment Annotations** (2):
- Annotated recruit action: ID 3 -> [Viktor]
- Annotated recruit action: ID 3 -> [Viktor]

**Inventory Item Check Annotations** (5):
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #8 -> [Fire Wall]
- Annotated inventory check: Item #8 -> [Fire Wall]
- Annotated inventory check: Item #8 -> [Fire Wall]


### `dunan_castle_hq_infirmary_and_clinic.md` (18 changes)

**Character Dismissal Annotations** (6):
- Annotated dismiss action: ID 85 -> [Apple]
- Annotated dismiss action: ID 34 -> [Hauser]
- Annotated dismiss action: ID 85 -> [Apple]
- Annotated dismiss action: ID 18 -> [Nanami]
- Annotated dismiss action: ID 85 -> [Apple]
- Annotated dismiss action: ID 18 -> [Nanami]

**Inventory Item Check Annotations** (12):
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #8 -> [Fire Wall]
- Annotated inventory check: Item #32 -> [Drinking Set]
- Annotated inventory check: Item #32 -> [Drinking Set]
- Annotated inventory check: Item #16 -> [Revenge Earth]
- Annotated inventory check: Item #4 -> [Throat Drops]
- *... and 2 more item check annotations*


### `dunan_castle_hq_inn_and_lodging.md` (17 changes)

**Character Dismissal Annotations** (2):
- Annotated dismiss action: ID 49 -> [Abizboah]
- Annotated dismiss action: ID 3 -> [Viktor]

**Inventory Item Check Annotations** (15):
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #8 -> [Fire Wall]
- Annotated inventory check: Item #16 -> [Revenge Earth]
- Annotated inventory check: Item #32 -> [Drinking Set]
- Annotated inventory check: Item #9 -> [Kindness Drops]
- *... and 5 more item check annotations*


### `dunan_castle_hq_living_quarters_and_corridors.md` (262 changes)

**Critical Entity Fixes**:
- Fixed `obj[02]` (fpno 83): misidentified as 'Luca Blight' -> corrected to '**Bonaparte**'
- Fixed bullet description for `obj[02]`: '(Luca Blight)' -> '(Bonaparte)'
- Annotated recruit action: ID 84 -> [Bonaparte]
- Annotated recruit action: ID 84 -> [Bonaparte]
- Annotated recruit action: ID 84 -> [Bonaparte]
- Annotated recruit action: ID 84 -> [Bonaparte]
- Annotated recruit action: ID 84 -> [Bonaparte]
- Annotated recruit action: ID 84 -> [Bonaparte]
- Annotated recruit action: ID 84 -> [Bonaparte]
- Annotated recruit action: ID 84 -> [Bonaparte]
- Annotated recruit action: ID 84 -> [Bonaparte]
- Annotated recruit action: ID 84 -> [Bonaparte]
- Annotated recruit action: ID 84 -> [Bonaparte]

**Party Recruitment Annotations** (69):
- Annotated recruit action: ID 4 -> [Viki]
- Annotated recruit action: ID 1 -> [Riou]
- Annotated recruit action: ID 73 -> [Kasumi]
- Annotated recruit action: ID 73 -> [Kasumi]
- Annotated recruit action: ID 6 -> [Clive]
- Annotated recruit action: ID 73 -> [Kasumi]
- Annotated recruit action: ID 3 -> [Viktor]
- Annotated recruit action: ID 3 -> [Viktor]
- Annotated recruit action: ID 3 -> [Viktor]
- Annotated recruit action: ID 3 -> [Viktor]
- *... and 59 more recruitment annotations*

**Character Dismissal Annotations** (79):
- Annotated dismiss action: ID 18 -> [Nanami]
- Annotated dismiss action: ID 18 -> [Nanami]
- Annotated dismiss action: ID 1 -> [Riou]
- Annotated dismiss action: ID 3 -> [Viktor]
- Annotated dismiss action: ID 3 -> [Viktor]
- Annotated dismiss action: ID 18 -> [Nanami]
- Annotated dismiss action: ID 18 -> [Nanami]
- Annotated dismiss action: ID 36 -> [Kahn]
- Annotated dismiss action: ID 36 -> [Kahn]
- Annotated dismiss action: ID 45 -> [Sierra]
- *... and 69 more dismissal annotations*

**Inventory Item Check Annotations** (112):
- Annotated inventory check: Item #32 -> [Drinking Set]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #8 -> [Fire Wall]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- *... and 102 more item check annotations*


### `dunan_castle_hq_memorial_graveyard.md` (2 changes)

**Critical Entity Fixes**:
- Fixed `obj[04]` (fpno 83): misidentified as 'Luca Blight' -> corrected to '**Bonaparte**'
- Fixed bullet description for `obj[04]`: '(Luca Blight)' -> '(Bonaparte)'


### `dunan_castle_hq_restaurant_and_kitchen.md` (3 changes)

**Character Dismissal Annotations** (1):
- Annotated dismiss action: ID 66 -> [Hai Yo]

**Inventory Item Check Annotations** (2):
- Annotated inventory check: Item #32 -> [Drinking Set]
- Annotated inventory check: Item #32 -> [Drinking Set]


### `dunan_castle_hq_tavern_and_dice.md` (4 changes)

**Inventory Item Check Annotations** (4):
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #32 -> [Drinking Set]


### `dunan_castle_hq_teleport_and_elevator.md` (18 changes)

**Party Recruitment Annotations** (2):
- Annotated recruit action: ID 3 -> [Viktor]
- Annotated recruit action: ID 3 -> [Viktor]

**Character Dismissal Annotations** (7):
- Annotated dismiss action: ID 5 -> [Sheena]
- Annotated dismiss action: ID 117 -> [Ridley]
- Annotated dismiss action: ID 18 -> [Nanami]
- Annotated dismiss action: ID 18 -> [Nanami]
- Annotated dismiss action: ID 2 -> [Flik]
- Annotated dismiss action: ID 15 -> [Shin]
- Annotated dismiss action: ID 5 -> [Sheena]

**Inventory Item Check Annotations** (9):
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]


### `dunan_castle_hq_vault_and_detective.md` (6 changes)

**Inventory Item Check Annotations** (6):
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]


### `dunan_castle_hq_war_strategy_room.md` (37 changes)

**Party Recruitment Annotations** (2):
- Annotated recruit action: ID 49 -> [Abizboah]
- Annotated recruit action: ID 101 -> [Teresa]

**Character Dismissal Annotations** (19):
- Annotated dismiss action: ID 18 -> [Nanami]
- Annotated dismiss action: ID 18 -> [Nanami]
- Annotated dismiss action: ID 18 -> [Nanami]
- Annotated dismiss action: ID 18 -> [Nanami]
- Annotated dismiss action: ID 18 -> [Nanami]
- Annotated dismiss action: ID 18 -> [Nanami]
- Annotated dismiss action: ID 18 -> [Nanami]
- Annotated dismiss action: ID 1 -> [Riou]
- Annotated dismiss action: ID 3 -> [Viktor]
- Annotated dismiss action: ID 3 -> [Viktor]
- *... and 9 more dismissal annotations*

**Inventory Item Check Annotations** (16):
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- *... and 6 more item check annotations*


### `dunan_castle_hq_watchtower_and_roof.md` (8 changes)

**Party Recruitment Annotations** (1):
- Annotated recruit action: ID 89 -> [Shu]

**Inventory Item Check Annotations** (7):
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #16 -> [Revenge Earth]
- Annotated inventory check: Item #32 -> [Drinking Set]
- Annotated inventory check: Item #64 -> [Recipe #33]


### `dunan_castle_hq_workshop_and_library.md` (7 changes)

**Inventory Item Check Annotations** (7):
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #9 -> [Kindness Drops]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]


### `forest_village.md` (30 changes)

**Character Dismissal Annotations** (10):
- Annotated dismiss action: ID 86 -> [Templton]
- Annotated dismiss action: ID 68 -> [Wakaba]
- Annotated dismiss action: ID 68 -> [Wakaba]
- Annotated dismiss action: ID 68 -> [Wakaba]
- Annotated dismiss action: ID 68 -> [Wakaba]
- Annotated dismiss action: ID 108 -> [Connell]
- Annotated dismiss action: ID 108 -> [Connell]
- Annotated dismiss action: ID 104 -> [Tony]
- Annotated dismiss action: ID 104 -> [Tony]
- Annotated dismiss action: ID 113 -> [Pico]

**Inventory Item Check Annotations** (20):
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #32 -> [Drinking Set]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #3 -> [Antitoxin]
- Annotated inventory check: Item #3 -> [Antitoxin]
- Annotated inventory check: Item #3 -> [Antitoxin]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #3 -> [Antitoxin]
- *... and 10 more item check annotations*


### `greenhill_city.md` (79 changes)

**Party Recruitment Annotations** (7):
- Annotated recruit action: ID 3 -> [Viktor]
- Annotated recruit action: ID 24 -> [Milie]
- Annotated recruit action: ID 25 -> [Karen]
- Annotated recruit action: ID 73 -> [Kasumi]
- Annotated recruit action: ID 102 -> [Yuzu]
- Annotated recruit action: ID 73 -> [Kasumi]
- Annotated recruit action: ID 4 -> [Viki]

**Character Dismissal Annotations** (16):
- Annotated dismiss action: ID 55 -> [Nina]
- Annotated dismiss action: ID 67 -> [Stallion]
- Annotated dismiss action: ID 67 -> [Stallion]
- Annotated dismiss action: ID 67 -> [Stallion]
- Annotated dismiss action: ID 67 -> [Stallion]
- Annotated dismiss action: ID 67 -> [Stallion]
- Annotated dismiss action: ID 85 -> [Apple]
- Annotated dismiss action: ID 101 -> [Teresa]
- Annotated dismiss action: ID 101 -> [Teresa]
- Annotated dismiss action: ID 101 -> [Teresa]
- *... and 6 more dismissal annotations*

**Inventory Item Check Annotations** (56):
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #9 -> [Kindness Drops]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #9 -> [Kindness Drops]
- Annotated inventory check: Item #9 -> [Kindness Drops]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- *... and 46 more item check annotations*


### `greenhill_matilda_path_and_border.md` (23 changes)

**Party Recruitment Annotations** (2):
- Annotated recruit action: ID 8 -> [Tengaar]
- Annotated recruit action: ID 102 -> [Yuzu]

**Character Dismissal Annotations** (9):
- Annotated dismiss action: ID 51 -> [Badeaux]
- Annotated dismiss action: ID 4 -> [Viki]
- Annotated dismiss action: ID 4 -> [Viki]
- Annotated dismiss action: ID 41 -> [Meg]
- Annotated dismiss action: ID 41 -> [Meg]
- Annotated dismiss action: ID 41 -> [Meg]
- Annotated dismiss action: ID 41 -> [Meg]
- Annotated dismiss action: ID 41 -> [Meg]
- Annotated dismiss action: ID 41 -> [Meg]

**Inventory Item Check Annotations** (12):
- Annotated inventory check: Item #9 -> [Kindness Drops]
- Annotated inventory check: Item #9 -> [Kindness Drops]
- Annotated inventory check: Item #9 -> [Kindness Drops]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #8 -> [Fire Wall]
- Annotated inventory check: Item #8 -> [Fire Wall]
- Annotated inventory check: Item #16 -> [Revenge Earth]
- Annotated inventory check: Item #9 -> [Kindness Drops]
- Annotated inventory check: Item #9 -> [Kindness Drops]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- *... and 2 more item check annotations*


### `gregminster_capital.md` (12 changes)

**Party Recruitment Annotations** (8):
- Annotated recruit action: ID 87 -> [Kiba]
- Annotated recruit action: ID 33 -> [Camus]
- Annotated recruit action: ID 3 -> [Viktor]
- Annotated recruit action: ID 5 -> [Sheena]
- Annotated recruit action: ID 5 -> [Sheena]
- Annotated recruit action: ID 4 -> [Viki]
- Annotated recruit action: ID 4 -> [Viki]
- Annotated recruit action: ID 23 -> [Hanna]

**Character Dismissal Annotations** (2):
- Annotated dismiss action: ID 73 -> [Kasumi]
- Annotated dismiss action: ID 5 -> [Sheena]

**Inventory Item Check Annotations** (2):
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]


### `highland_recon_camp_muse.md` (60 changes)

**Party Recruitment Annotations** (30):
- Annotated recruit action: ID 36 -> [Kahn]
- Annotated recruit action: ID 31 -> [Shilo]
- Annotated recruit action: ID 33 -> [Camus]
- Annotated recruit action: ID 43 -> [Ayda]
- Annotated recruit action: ID 73 -> [Kasumi]
- Annotated recruit action: ID 33 -> [Camus]
- Annotated recruit action: ID 46 -> [Oulan]
- Annotated recruit action: ID 33 -> [Camus]
- Annotated recruit action: ID 5 -> [Sheena]
- Annotated recruit action: ID 46 -> [Oulan]
- *... and 20 more recruitment annotations*

**Character Dismissal Annotations** (3):
- Annotated dismiss action: ID 9 -> [Futch]
- Annotated dismiss action: ID 80 -> [Jowy 1]
- Annotated dismiss action: ID 80 -> [Jowy 1]

**Inventory Item Check Annotations** (27):
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #4 -> [Throat Drops]
- *... and 17 more item check annotations*


### `highland_youth_brigade_camp.md` (48 changes)

**Party Recruitment Annotations** (21):
- Annotated recruit action: ID 101 -> [Teresa]
- Annotated recruit action: ID 89 -> [Shu]
- Annotated recruit action: ID 101 -> [Teresa]
- Annotated recruit action: ID 43 -> [Ayda]
- Annotated recruit action: ID 72 -> [Siegfried]
- Annotated recruit action: ID 33 -> [Camus]
- Annotated recruit action: ID 43 -> [Ayda]
- Annotated recruit action: ID 46 -> [Oulan]
- Annotated recruit action: ID 5 -> [Sheena]
- Annotated recruit action: ID 24 -> [Milie]
- *... and 11 more recruitment annotations*

**Inventory Item Check Annotations** (27):
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #16 -> [Revenge Earth]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #64 -> [Recipe #33]
- Annotated inventory check: Item #4 -> [Throat Drops]
- *... and 17 more item check annotations*


### `highway_village.md` (50 changes)

**Party Recruitment Annotations** (18):
- Annotated recruit action: ID 24 -> [Milie]
- Annotated recruit action: ID 43 -> [Ayda]
- Annotated recruit action: ID 43 -> [Ayda]
- Annotated recruit action: ID 33 -> [Camus]
- Annotated recruit action: ID 43 -> [Ayda]
- Annotated recruit action: ID 46 -> [Oulan]
- Annotated recruit action: ID 43 -> [Ayda]
- Annotated recruit action: ID 46 -> [Oulan]
- Annotated recruit action: ID 43 -> [Ayda]
- Annotated recruit action: ID 46 -> [Oulan]
- *... and 8 more recruitment annotations*

**Character Dismissal Annotations** (2):
- Annotated dismiss action: ID 10 -> [Humphrey]
- Annotated dismiss action: ID 73 -> [Kasumi]

**Inventory Item Check Annotations** (30):
- Annotated inventory check: Item #9 -> [Kindness Drops]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #8 -> [Fire Wall]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- *... and 20 more item check annotations*


### `kobold_village.md` (26 changes)

**Party Recruitment Annotations** (12):
- Annotated recruit action: ID 49 -> [Abizboah]
- Annotated recruit action: ID 33 -> [Camus]
- Annotated recruit action: ID 24 -> [Milie]
- Annotated recruit action: ID 24 -> [Milie]
- Annotated recruit action: ID 24 -> [Milie]
- Annotated recruit action: ID 24 -> [Milie]
- Annotated recruit action: ID 24 -> [Milie]
- Annotated recruit action: ID 11 -> [Georg]
- Annotated recruit action: ID 33 -> [Camus]
- Annotated recruit action: ID 24 -> [Milie]
- *... and 2 more recruitment annotations*

**Character Dismissal Annotations** (7):
- Annotated dismiss action: ID 8 -> [Tengaar]
- Annotated dismiss action: ID 102 -> [Yuzu]
- Annotated dismiss action: ID 102 -> [Yuzu]
- Annotated dismiss action: ID 102 -> [Yuzu]
- Annotated dismiss action: ID 8 -> [Tengaar]
- Annotated dismiss action: ID 8 -> [Tengaar]
- Annotated dismiss action: ID 8 -> [Tengaar]

**Inventory Item Check Annotations** (7):
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #9 -> [Kindness Drops]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #16 -> [Revenge Earth]
- Annotated inventory check: Item #32 -> [Drinking Set]
- Annotated inventory check: Item #64 -> [Recipe #33]


### `kuskus_town.md` (4 changes)

**Character Dismissal Annotations** (3):
- Annotated dismiss action: ID 38 -> [Tai Ho]
- Annotated dismiss action: ID 100 -> [Yam Koo]
- Annotated dismiss action: ID 38 -> [Tai Ho]

**Inventory Item Check Annotations** (1):
- Annotated inventory check: Item #1 -> [Medicine]


### `kyaro_town.md` (125 changes)

**Party Recruitment Annotations** (30):
- Annotated recruit action: ID 43 -> [Ayda]
- Annotated recruit action: ID 36 -> [Kahn]
- Annotated recruit action: ID 33 -> [Camus]
- Annotated recruit action: ID 43 -> [Ayda]
- Annotated recruit action: ID 101 -> [Teresa]
- Annotated recruit action: ID 43 -> [Ayda]
- Annotated recruit action: ID 5 -> [Sheena]
- Annotated recruit action: ID 36 -> [Kahn]
- Annotated recruit action: ID 44 -> [Killey]
- Annotated recruit action: ID 43 -> [Ayda]
- *... and 20 more recruitment annotations*

**Character Dismissal Annotations** (1):
- Annotated dismiss action: ID 49 -> [Abizboah]

**Inventory Item Check Annotations** (94):
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #8 -> [Fire Wall]
- Annotated inventory check: Item #32 -> [Drinking Set]
- Annotated inventory check: Item #64 -> [Recipe #33]
- Annotated inventory check: Item #16 -> [Revenge Earth]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #4 -> [Throat Drops]
- *... and 84 more item check annotations*


### `l_renouille_citadel.md` (109 changes)

**Party Recruitment Annotations** (3):
- Annotated recruit action: ID 55 -> [Nina]
- Annotated recruit action: ID 2 -> [Flik]
- Annotated recruit action: ID 2 -> [Flik]

**Character Dismissal Annotations** (7):
- Annotated dismiss action: ID 3 -> [Viktor]
- Annotated dismiss action: ID 34 -> [Hauser]
- Annotated dismiss action: ID 15 -> [Shin]
- Annotated dismiss action: ID 2 -> [Flik]
- Annotated dismiss action: ID 18 -> [Nanami]
- Annotated dismiss action: ID 3 -> [Viktor]
- Annotated dismiss action: ID 2 -> [Flik]

**Inventory Item Check Annotations** (99):
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #6 -> [Flaming Arrows]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #64 -> [Recipe #33]
- Annotated inventory check: Item #3 -> [Antitoxin]
- Annotated inventory check: Item #3 -> [Antitoxin]
- Annotated inventory check: Item #3 -> [Antitoxin]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #4 -> [Throat Drops]
- *... and 89 more item check annotations*


### `lakewest_town.md` (31 changes)

**Party Recruitment Annotations** (5):
- Annotated recruit action: ID 11 -> [Georg]
- Annotated recruit action: ID 55 -> [Nina]
- Annotated recruit action: ID 55 -> [Nina]
- Annotated recruit action: ID 33 -> [Camus]
- Annotated recruit action: ID 87 -> [Kiba]

**Character Dismissal Annotations** (11):
- Annotated dismiss action: ID 7 -> [Hix]
- Annotated dismiss action: ID 7 -> [Hix]
- Annotated dismiss action: ID 90 -> [Tetsu]
- Annotated dismiss action: ID 90 -> [Tetsu]
- Annotated dismiss action: ID 31 -> [Shilo]
- Annotated dismiss action: ID 31 -> [Shilo]
- Annotated dismiss action: ID 103 -> [Taki]
- Annotated dismiss action: ID 103 -> [Taki]
- Annotated dismiss action: ID 103 -> [Taki]
- Annotated dismiss action: ID 103 -> [Taki]
- *... and 1 more dismissal annotations*

**Inventory Item Check Annotations** (15):
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #30 -> [Sacrifical Jizo]
- Annotated inventory check: Item #9 -> [Kindness Drops]
- Annotated inventory check: Item #32 -> [Drinking Set]
- Annotated inventory check: Item #16 -> [Revenge Earth]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #4 -> [Throat Drops]
- *... and 5 more item check annotations*


### `mercenary_fortress.md` (85 changes)

**Party Recruitment Annotations** (9):
- Annotated recruit action: ID 62 -> [Sasuke]
- Annotated recruit action: ID 64 -> [Vincent]
- Annotated recruit action: ID 47 -> [Genshu]
- Annotated recruit action: ID 36 -> [Kahn]
- Annotated recruit action: ID 4 -> [Viki]
- Annotated recruit action: ID 4 -> [Viki]
- Annotated recruit action: ID 51 -> [Badeaux]
- Annotated recruit action: ID 62 -> [Sasuke]
- Annotated recruit action: ID 4 -> [Viki]

**Character Dismissal Annotations** (25):
- Annotated dismiss action: ID 98 -> [Barbara]
- Annotated dismiss action: ID 28 -> [Gengen]
- Annotated dismiss action: ID 91 -> [Leona]
- Annotated dismiss action: ID 69 -> [Long Chan-Chan]
- Annotated dismiss action: ID 72 -> [Siegfried]
- Annotated dismiss action: ID 80 -> [Jowy 1]
- Annotated dismiss action: ID 80 -> [Jowy 1]
- Annotated dismiss action: ID 112 -> [Annallee]
- Annotated dismiss action: ID 81 -> [Jowy 2]
- Annotated dismiss action: ID 80 -> [Jowy 1]
- *... and 15 more dismissal annotations*

**Inventory Item Check Annotations** (51):
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #8 -> [Fire Wall]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #16 -> [Revenge Earth]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #32 -> [Drinking Set]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #32 -> [Drinking Set]
- *... and 41 more item check annotations*


### `mt_rakutei.md` (65 changes)

**Party Recruitment Annotations** (38):
- Annotated recruit action: ID 46 -> [Oulan]
- Annotated recruit action: ID 46 -> [Oulan]
- Annotated recruit action: ID 46 -> [Oulan]
- Annotated recruit action: ID 46 -> [Oulan]
- Annotated recruit action: ID 46 -> [Oulan]
- Annotated recruit action: ID 46 -> [Oulan]
- Annotated recruit action: ID 46 -> [Oulan]
- Annotated recruit action: ID 46 -> [Oulan]
- Annotated recruit action: ID 46 -> [Oulan]
- Annotated recruit action: ID 30 -> [Kinnison]
- *... and 28 more recruitment annotations*

**Character Dismissal Annotations** (1):
- Annotated dismiss action: ID 73 -> [Kasumi]

**Inventory Item Check Annotations** (26):
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #64 -> [Recipe #33]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #8 -> [Fire Wall]
- Annotated inventory check: Item #16 -> [Revenge Earth]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- *... and 16 more item check annotations*


### `banner_pass.md` (formerly `mt_ryukan_pass.md`) (24 changes)

**Critical Entity Fixes**:
- Annotated recruit action: ID 84 -> [Bonaparte]

**Party Recruitment Annotations** (20):
- Annotated recruit action: ID 37 -> [Amada]
- Annotated recruit action: ID 48 -> [Mukumuku]
- Annotated recruit action: ID 48 -> [Mukumuku]
- Annotated recruit action: ID 11 -> [Georg]
- Annotated recruit action: ID 11 -> [Georg]
- Annotated recruit action: ID 3 -> [Viktor]
- Annotated recruit action: ID 3 -> [Viktor]
- Annotated recruit action: ID 73 -> [Kasumi]
- Annotated recruit action: ID 48 -> [Mukumuku]
- Annotated recruit action: ID 73 -> [Kasumi]
- *... and 10 more recruitment annotations*

**Inventory Item Check Annotations** (4):
- Annotated inventory check: Item #16 -> [Revenge Earth]
- Annotated inventory check: Item #32 -> [Drinking Set]
- Annotated inventory check: Item #8 -> [Fire Wall]
- Annotated inventory check: Item #1 -> [Medicine]


### `ryube_forest.md` (formerly `mt_tigerwolf.md`) (108 changes)

**Party Recruitment Annotations** (14):
- Annotated recruit action: ID 24 -> [Milie]
- Annotated recruit action: ID 36 -> [Kahn]
- Annotated recruit action: ID 36 -> [Kahn]
- Annotated recruit action: ID 8 -> [Tengaar]
- Annotated recruit action: ID 36 -> [Kahn]
- Annotated recruit action: ID 4 -> [Viki]
- Annotated recruit action: ID 73 -> [Kasumi]
- Annotated recruit action: ID 4 -> [Viki]
- Annotated recruit action: ID 4 -> [Viki]
- Annotated recruit action: ID 24 -> [Milie]
- *... and 4 more recruitment annotations*

**Character Dismissal Annotations** (70):
- Annotated dismiss action: ID 52 -> [Tsai]
- Annotated dismiss action: ID 52 -> [Tsai]
- Annotated dismiss action: ID 17 -> [Tomo]
- Annotated dismiss action: ID 17 -> [Tomo]
- Annotated dismiss action: ID 86 -> [Templton]
- Annotated dismiss action: ID 2 -> [Flik]
- Annotated dismiss action: ID 86 -> [Templton]
- Annotated dismiss action: ID 86 -> [Templton]
- Annotated dismiss action: ID 2 -> [Flik]
- Annotated dismiss action: ID 50 -> [Feather]
- *... and 60 more dismissal annotations*

**Inventory Item Check Annotations** (24):
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #8 -> [Fire Wall]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- *... and 14 more item check annotations*


### `muse_city.md` (348 changes)

**Critical Entity Fixes**:
- Annotated recruit action: ID 84 -> [Bonaparte]

**Party Recruitment Annotations** (162):
- Annotated recruit action: ID 43 -> [Ayda]
- Annotated recruit action: ID 43 -> [Ayda]
- Annotated recruit action: ID 43 -> [Ayda]
- Annotated recruit action: ID 43 -> [Ayda]
- Annotated recruit action: ID 43 -> [Ayda]
- Annotated recruit action: ID 47 -> [Genshu]
- Annotated recruit action: ID 5 -> [Sheena]
- Annotated recruit action: ID 5 -> [Sheena]
- Annotated recruit action: ID 5 -> [Sheena]
- Annotated recruit action: ID 33 -> [Camus]
- *... and 152 more recruitment annotations*

**Character Dismissal Annotations** (18):
- Annotated dismiss action: ID 18 -> [Nanami]
- Annotated dismiss action: ID 48 -> [Mukumuku]
- Annotated dismiss action: ID 6 -> [Clive]
- Annotated dismiss action: ID 6 -> [Clive]
- Annotated dismiss action: ID 73 -> [Kasumi]
- Annotated dismiss action: ID 18 -> [Nanami]
- Annotated dismiss action: ID 80 -> [Jowy 1]
- Annotated dismiss action: ID 18 -> [Nanami]
- Annotated dismiss action: ID 80 -> [Jowy 1]
- Annotated dismiss action: ID 18 -> [Nanami]
- *... and 8 more dismissal annotations*

**Inventory Item Check Annotations** (168):
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #16 -> [Revenge Earth]
- Annotated inventory check: Item #8 -> [Fire Wall]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #64 -> [Recipe #33]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #64 -> [Recipe #33]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- *... and 158 more item check annotations*


### `new_leaf_academy.md` (71 changes)

**Party Recruitment Annotations** (5):
- Annotated recruit action: ID 117 -> [Ridley]
- Annotated recruit action: ID 5 -> [Sheena]
- Annotated recruit action: ID 102 -> [Yuzu]
- Annotated recruit action: ID 4 -> [Viki]
- Annotated recruit action: ID 30 -> [Kinnison]

**Character Dismissal Annotations** (19):
- Annotated dismiss action: ID 101 -> [Teresa]
- Annotated dismiss action: ID 96 -> [Emilia]
- Annotated dismiss action: ID 15 -> [Shin]
- Annotated dismiss action: ID 2 -> [Flik]
- Annotated dismiss action: ID 2 -> [Flik]
- Annotated dismiss action: ID 2 -> [Flik]
- Annotated dismiss action: ID 96 -> [Emilia]
- Annotated dismiss action: ID 115 -> [Jude]
- Annotated dismiss action: ID 115 -> [Jude]
- Annotated dismiss action: ID 115 -> [Jude]
- *... and 9 more dismissal annotations*

**Inventory Item Check Annotations** (47):
- Annotated inventory check: Item #9 -> [Kindness Drops]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #9 -> [Kindness Drops]
- Annotated inventory check: Item #9 -> [Kindness Drops]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #3 -> [Antitoxin]
- Annotated inventory check: Item #8 -> [Fire Wall]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- *... and 37 more item check annotations*


### `north_sparrow_pass.md` (65 changes)

**Party Recruitment Annotations** (19):
- Annotated recruit action: ID 81 -> [Jowy 2]
- Annotated recruit action: ID 54 -> [Chaco]
- Annotated recruit action: ID 2 -> [Flik]
- Annotated recruit action: ID 5 -> [Sheena]
- Annotated recruit action: ID 5 -> [Sheena]
- Annotated recruit action: ID 4 -> [Viki]
- Annotated recruit action: ID 105 -> [Adlai]
- Annotated recruit action: ID 36 -> [Kahn]
- Annotated recruit action: ID 36 -> [Kahn]
- Annotated recruit action: ID 33 -> [Camus]
- *... and 9 more recruitment annotations*

**Character Dismissal Annotations** (2):
- Annotated dismiss action: ID 48 -> [Mukumuku]
- Annotated dismiss action: ID 18 -> [Nanami]

**Inventory Item Check Annotations** (44):
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #8 -> [Fire Wall]
- Annotated inventory check: Item #32 -> [Drinking Set]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #16 -> [Revenge Earth]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- *... and 34 more item check annotations*


### `north_window_ruins.md` (38 changes)

**Critical Entity Fixes**:
- Corrected bytecode action: 'Recruit Luca Blight into Battle Slot 1' -> 'Recruit Milie Sans Bonapart into Battle Slot 1'

**Party Recruitment Annotations** (2):
- Corrected bytecode action: 'Recruit Luca Blight into Battle Slot 1' -> 'Recruit Milie Sans Bonapart into Battle Slot 1'
- Annotated recruit action: ID 8 -> [Tengaar]

**Character Dismissal Annotations** (11):
- Annotated dismiss action: ID 36 -> [Kahn]
- Annotated dismiss action: ID 36 -> [Kahn]
- Annotated dismiss action: ID 18 -> [Nanami]
- Annotated dismiss action: ID 18 -> [Nanami]
- Annotated dismiss action: ID 35 -> [Freed Y]
- Annotated dismiss action: ID 35 -> [Freed Y]
- Annotated dismiss action: ID 19 -> [Eilie]
- Annotated dismiss action: ID 19 -> [Eilie]
- Annotated dismiss action: ID 1 -> [Riou]
- Annotated dismiss action: ID 2 -> [Flik]
- *... and 1 more dismissal annotations*

**Inventory Item Check Annotations** (25):
- Annotated inventory check: Item #8 -> [Fire Wall]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #64 -> [Recipe #33]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #64 -> [Recipe #33]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #4 -> [Throat Drops]
- *... and 15 more item check annotations*


### `radat_town.md` (69 changes)

**Party Recruitment Annotations** (12):
- Annotated recruit action: ID 105 -> [Adlai]
- Annotated recruit action: ID 105 -> [Adlai]
- Annotated recruit action: ID 105 -> [Adlai]
- Annotated recruit action: ID 56 -> [Sid]
- Annotated recruit action: ID 31 -> [Shilo]
- Annotated recruit action: ID 31 -> [Shilo]
- Annotated recruit action: ID 31 -> [Shilo]
- Annotated recruit action: ID 121 -> [Gilbert]
- Annotated recruit action: ID 87 -> [Kiba]
- Annotated recruit action: ID 3 -> [Viktor]
- *... and 2 more recruitment annotations*

**Character Dismissal Annotations** (24):
- Annotated dismiss action: ID 37 -> [Amada]
- Annotated dismiss action: ID 4 -> [Viki]
- Annotated dismiss action: ID 30 -> [Kinnison]
- Annotated dismiss action: ID 37 -> [Amada]
- Annotated dismiss action: ID 65 -> [Simone]
- Annotated dismiss action: ID 65 -> [Simone]
- Annotated dismiss action: ID 65 -> [Simone]
- Annotated dismiss action: ID 64 -> [Vincent]
- Annotated dismiss action: ID 64 -> [Vincent]
- Annotated dismiss action: ID 99 -> [Richmond]
- *... and 14 more dismissal annotations*

**Inventory Item Check Annotations** (33):
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #8 -> [Fire Wall]
- Annotated inventory check: Item #16 -> [Revenge Earth]
- Annotated inventory check: Item #32 -> [Drinking Set]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- *... and 23 more item check annotations*


### `rockaxe_citadel_and_castle.md` (88 changes)

**Critical Entity Fixes**:
- Annotated recruit action: ID 84 -> [Bonaparte]
- Annotated recruit action: ID 84 -> [Bonaparte]
- Annotated recruit action: ID 84 -> [Bonaparte]
- Annotated recruit action: ID 84 -> [Bonaparte]

**Party Recruitment Annotations** (44):
- Annotated recruit action: ID 36 -> [Kahn]
- Annotated recruit action: ID 43 -> [Ayda]
- Annotated recruit action: ID 43 -> [Ayda]
- Annotated recruit action: ID 46 -> [Oulan]
- Annotated recruit action: ID 46 -> [Oulan]
- Annotated recruit action: ID 24 -> [Milie]
- Annotated recruit action: ID 43 -> [Ayda]
- Annotated recruit action: ID 84 -> [Bonaparte]
- Annotated recruit action: ID 84 -> [Bonaparte]
- Annotated recruit action: ID 84 -> [Bonaparte]
- *... and 34 more recruitment annotations*

**Character Dismissal Annotations** (4):
- Annotated dismiss action: ID 69 -> [Long Chan-Chan]
- Annotated dismiss action: ID 32 -> [Miklotov]
- Annotated dismiss action: ID 32 -> [Miklotov]
- Annotated dismiss action: ID 18 -> [Nanami]

**Inventory Item Check Annotations** (40):
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #8 -> [Fire Wall]
- Annotated inventory check: Item #16 -> [Revenge Earth]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- *... and 30 more item check annotations*


### `ryube_village.md` (48 changes)

**Critical Entity Fixes**:
- Fixed `obj[22]` (fpno 83): misidentified as 'Luca Blight' -> corrected to '**Bonaparte**'
- Fixed `obj[24]` (fpno 83): misidentified as 'Luca Blight' -> corrected to '**Bonaparte**'
- Fixed `obj[25]` (fpno 83): misidentified as 'Luca Blight' -> corrected to '**Bonaparte**'
- Fixed `obj[06]` (fpno 83): misidentified as 'Luca Blight' -> corrected to '**Bonaparte**'
- Fixed `obj[07]` (fpno 83): misidentified as 'Luca Blight' -> corrected to '**Bonaparte**'
- Fixed bullet description for `obj[22]`: '(Luca Blight)' -> '(Bonaparte)'
- Fixed bullet description for `obj[24]`: '(Luca Blight)' -> '(Bonaparte)'
- Fixed bullet description for `obj[25]`: '(Luca Blight)' -> '(Bonaparte)'
- Fixed bullet description for `obj[06]`: '(Luca Blight)' -> '(Bonaparte)'
- Fixed bullet description for `obj[07]`: '(Luca Blight)' -> '(Bonaparte)'

**Party Recruitment Annotations** (15):
- Annotated recruit action: ID 4 -> [Viki]
- Annotated recruit action: ID 4 -> [Viki]
- Annotated recruit action: ID 4 -> [Viki]
- Annotated recruit action: ID 4 -> [Viki]
- Annotated recruit action: ID 31 -> [Shilo]
- Annotated recruit action: ID 5 -> [Sheena]
- Annotated recruit action: ID 3 -> [Viktor]
- Annotated recruit action: ID 4 -> [Viki]
- Annotated recruit action: ID 4 -> [Viki]
- Annotated recruit action: ID 5 -> [Sheena]
- *... and 5 more recruitment annotations*

**Character Dismissal Annotations** (10):
- Annotated dismiss action: ID 42 -> [Gadget]
- Annotated dismiss action: ID 42 -> [Gadget]
- Annotated dismiss action: ID 24 -> [Milie]
- Annotated dismiss action: ID 24 -> [Milie]
- Annotated dismiss action: ID 24 -> [Milie]
- Annotated dismiss action: ID 16 -> [Rikimaru]
- Annotated dismiss action: ID 24 -> [Milie]
- Annotated dismiss action: ID 83 -> [Milie Sans Bonapart]
- Annotated dismiss action: ID 24 -> [Milie]
- Annotated dismiss action: ID 42 -> [Gadget]

**Inventory Item Check Annotations** (13):
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #8 -> [Fire Wall]
- Annotated inventory check: Item #8 -> [Fire Wall]
- Annotated inventory check: Item #8 -> [Fire Wall]
- Annotated inventory check: Item #8 -> [Fire Wall]
- Annotated inventory check: Item #8 -> [Fire Wall]
- Annotated inventory check: Item #8 -> [Fire Wall]
- Annotated inventory check: Item #8 -> [Fire Wall]
- *... and 3 more item check annotations*


### `sajah_village.md` (8 changes)

**Inventory Item Check Annotations** (8):
- Annotated inventory check: Item #5 -> [Needle]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #8 -> [Fire Wall]
- Annotated inventory check: Item #16 -> [Revenge Earth]
- Annotated inventory check: Item #32 -> [Drinking Set]
- Annotated inventory check: Item #64 -> [Recipe #33]


### `sindar_ruins.md` (128 changes)

**Critical Entity Fixes**:
- Annotated recruit action: ID 84 -> [Bonaparte]

**Party Recruitment Annotations** (78):
- Annotated recruit action: ID 33 -> [Camus]
- Annotated recruit action: ID 84 -> [Bonaparte]
- Annotated recruit action: ID 46 -> [Oulan]
- Annotated recruit action: ID 46 -> [Oulan]
- Annotated recruit action: ID 5 -> [Sheena]
- Annotated recruit action: ID 33 -> [Camus]
- Annotated recruit action: ID 5 -> [Sheena]
- Annotated recruit action: ID 46 -> [Oulan]
- Annotated recruit action: ID 46 -> [Oulan]
- Annotated recruit action: ID 46 -> [Oulan]
- *... and 68 more recruitment annotations*

**Character Dismissal Annotations** (11):
- Annotated dismiss action: ID 16 -> [Rikimaru]
- Annotated dismiss action: ID 16 -> [Rikimaru]
- Annotated dismiss action: ID 19 -> [Eilie]
- Annotated dismiss action: ID 21 -> [Bolgan]
- Annotated dismiss action: ID 1 -> [Riou]
- Annotated dismiss action: ID 1 -> [Riou]
- Annotated dismiss action: ID 1 -> [Riou]
- Annotated dismiss action: ID 1 -> [Riou]
- Annotated dismiss action: ID 1 -> [Riou]
- Annotated dismiss action: ID 1 -> [Riou]
- *... and 1 more dismissal annotations*

**Inventory Item Check Annotations** (39):
- Annotated inventory check: Item #9 -> [Kindness Drops]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #8 -> [Fire Wall]
- Annotated inventory check: Item #16 -> [Revenge Earth]
- Annotated inventory check: Item #32 -> [Drinking Set]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #4 -> [Throat Drops]
- *... and 29 more item check annotations*


### `south_window_city.md` (95 changes)

**Party Recruitment Annotations** (9):
- Annotated recruit action: ID 24 -> [Milie]
- Annotated recruit action: ID 2 -> [Flik]
- Annotated recruit action: ID 2 -> [Flik]
- Annotated recruit action: ID 2 -> [Flik]
- Annotated recruit action: ID 2 -> [Flik]
- Annotated recruit action: ID 2 -> [Flik]
- Annotated recruit action: ID 101 -> [Teresa]
- Annotated recruit action: ID 5 -> [Sheena]
- Annotated recruit action: ID 117 -> [Ridley]

**Character Dismissal Annotations** (52):
- Annotated dismiss action: ID 46 -> [Oulan]
- Annotated dismiss action: ID 46 -> [Oulan]
- Annotated dismiss action: ID 110 -> [Tessai]
- Annotated dismiss action: ID 110 -> [Tessai]
- Annotated dismiss action: ID 110 -> [Tessai]
- Annotated dismiss action: ID 110 -> [Tessai]
- Annotated dismiss action: ID 25 -> [Karen]
- Annotated dismiss action: ID 25 -> [Karen]
- Annotated dismiss action: ID 25 -> [Karen]
- Annotated dismiss action: ID 44 -> [Killey]
- *... and 42 more dismissal annotations*

**Inventory Item Check Annotations** (34):
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #64 -> [Recipe #33]
- Annotated inventory check: Item #32 -> [Drinking Set]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- *... and 24 more item check annotations*


### `swallow_pass.md` (formerly `swallow_pass_ryube_forest.md`) (57 changes)

**Critical Entity Fixes**:
- Fixed `obj[04]` (fpno 83): misidentified as 'Luca Blight' -> corrected to '**Bonaparte**'
- Fixed bullet description for `obj[04]`: '(Luca Blight)' -> '(Bonaparte)'

**Party Recruitment Annotations** (3):
- Annotated recruit action: ID 48 -> [Mukumuku]
- Annotated recruit action: ID 31 -> [Shilo]
- Annotated recruit action: ID 31 -> [Shilo]

**Character Dismissal Annotations** (8):
- Annotated dismiss action: ID 26 -> [Shiro]
- Annotated dismiss action: ID 30 -> [Kinnison]
- Annotated dismiss action: ID 30 -> [Kinnison]
- Annotated dismiss action: ID 30 -> [Kinnison]
- Annotated dismiss action: ID 30 -> [Kinnison]
- Annotated dismiss action: ID 24 -> [Milie]
- Annotated dismiss action: ID 83 -> [Milie Sans Bonapart]
- Annotated dismiss action: ID 83 -> [Milie Sans Bonapart]

**Inventory Item Check Annotations** (44):
- Annotated inventory check: Item #9 -> [Kindness Drops]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #32 -> [Drinking Set]
- Annotated inventory check: Item #32 -> [Drinking Set]
- Annotated inventory check: Item #32 -> [Drinking Set]
- Annotated inventory check: Item #32 -> [Drinking Set]
- Annotated inventory check: Item #32 -> [Drinking Set]
- Annotated inventory check: Item #32 -> [Drinking Set]
- Annotated inventory check: Item #8 -> [Fire Wall]
- Annotated inventory check: Item #32 -> [Drinking Set]
- *... and 34 more item check annotations*


### `tenzan_pass.md` (46 changes)

**Party Recruitment Annotations** (19):
- Annotated recruit action: ID 49 -> [Abizboah]
- Annotated recruit action: ID 49 -> [Abizboah]
- Annotated recruit action: ID 43 -> [Ayda]
- Annotated recruit action: ID 43 -> [Ayda]
- Annotated recruit action: ID 101 -> [Teresa]
- Annotated recruit action: ID 101 -> [Teresa]
- Annotated recruit action: ID 101 -> [Teresa]
- Annotated recruit action: ID 46 -> [Oulan]
- Annotated recruit action: ID 33 -> [Camus]
- Annotated recruit action: ID 33 -> [Camus]
- *... and 9 more recruitment annotations*

**Inventory Item Check Annotations** (27):
- Annotated inventory check: Item #9 -> [Kindness Drops]
- Annotated inventory check: Item #9 -> [Kindness Drops]
- Annotated inventory check: Item #9 -> [Kindness Drops]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #16 -> [Revenge Earth]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- *... and 17 more item check annotations*


### `tiger_cave_mt_senai.md` (40 changes)

**Party Recruitment Annotations** (27):
- Annotated recruit action: ID 73 -> [Kasumi]
- Annotated recruit action: ID 46 -> [Oulan]
- Annotated recruit action: ID 46 -> [Oulan]
- Annotated recruit action: ID 46 -> [Oulan]
- Annotated recruit action: ID 46 -> [Oulan]
- Annotated recruit action: ID 46 -> [Oulan]
- Annotated recruit action: ID 46 -> [Oulan]
- Annotated recruit action: ID 46 -> [Oulan]
- Annotated recruit action: ID 46 -> [Oulan]
- Annotated recruit action: ID 46 -> [Oulan]
- *... and 17 more recruitment annotations*

**Character Dismissal Annotations** (6):
- Annotated dismiss action: ID 72 -> [Siegfried]
- Annotated dismiss action: ID 61 -> [Mazus]
- Annotated dismiss action: ID 61 -> [Mazus]
- Annotated dismiss action: ID 61 -> [Mazus]
- Annotated dismiss action: ID 61 -> [Mazus]
- Annotated dismiss action: ID 3 -> [Viktor]

**Inventory Item Check Annotations** (7):
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #8 -> [Fire Wall]
- Annotated inventory check: Item #16 -> [Revenge Earth]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]


### `tinto_city.md` (80 changes)

**Party Recruitment Annotations** (4):
- Annotated recruit action: ID 4 -> [Viki]
- Annotated recruit action: ID 86 -> [Templton]
- Annotated recruit action: ID 72 -> [Siegfried]
- Annotated recruit action: ID 72 -> [Siegfried]

**Character Dismissal Annotations** (55):
- Annotated dismiss action: ID 111 -> [Raura]
- Annotated dismiss action: ID 111 -> [Raura]
- Annotated dismiss action: ID 111 -> [Raura]
- Annotated dismiss action: ID 111 -> [Raura]
- Annotated dismiss action: ID 111 -> [Raura]
- Annotated dismiss action: ID 111 -> [Raura]
- Annotated dismiss action: ID 111 -> [Raura]
- Annotated dismiss action: ID 111 -> [Raura]
- Annotated dismiss action: ID 36 -> [Kahn]
- Annotated dismiss action: ID 36 -> [Kahn]
- *... and 45 more dismissal annotations*

**Inventory Item Check Annotations** (21):
- Annotated inventory check: Item #0 -> [None]
- Annotated inventory check: Item #0 -> [None]
- Annotated inventory check: Item #0 -> [None]
- Annotated inventory check: Item #0 -> [None]
- Annotated inventory check: Item #64 -> [Recipe #33]
- Annotated inventory check: Item #16 -> [Revenge Earth]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #0 -> [None]
- Annotated inventory check: Item #9 -> [Kindness Drops]
- *... and 11 more item check annotations*


### `tinto_mines.md` (27 changes)

**Party Recruitment Annotations** (5):
- Annotated recruit action: ID 69 -> [Long Chan-Chan]
- Annotated recruit action: ID 75 -> [Makumaku]
- Annotated recruit action: ID 72 -> [Siegfried]
- Annotated recruit action: ID 75 -> [Makumaku]
- Annotated recruit action: ID 101 -> [Teresa]

**Character Dismissal Annotations** (1):
- Annotated dismiss action: ID 58 -> [Gijimu]

**Inventory Item Check Annotations** (21):
- Annotated inventory check: Item #64 -> [Recipe #33]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #16 -> [Revenge Earth]
- Annotated inventory check: Item #8 -> [Fire Wall]
- Annotated inventory check: Item #8 -> [Fire Wall]
- Annotated inventory check: Item #8 -> [Fire Wall]
- Annotated inventory check: Item #8 -> [Fire Wall]
- Annotated inventory check: Item #8 -> [Fire Wall]
- *... and 11 more item check annotations*


### `toran_castle_palace.md` (36 changes)

**Critical Entity Fixes**:
- Annotated recruit action: ID 84 -> [Bonaparte]

**Party Recruitment Annotations** (25):
- Annotated recruit action: ID 23 -> [Hanna]
- Annotated recruit action: ID 46 -> [Oulan]
- Annotated recruit action: ID 24 -> [Milie]
- Annotated recruit action: ID 24 -> [Milie]
- Annotated recruit action: ID 24 -> [Milie]
- Annotated recruit action: ID 24 -> [Milie]
- Annotated recruit action: ID 2 -> [Flik]
- Annotated recruit action: ID 2 -> [Flik]
- Annotated recruit action: ID 55 -> [Nina]
- Annotated recruit action: ID 55 -> [Nina]
- *... and 15 more recruitment annotations*

**Character Dismissal Annotations** (8):
- Annotated dismiss action: ID 8 -> [Tengaar]
- Annotated dismiss action: ID 9 -> [Futch]
- Annotated dismiss action: ID 9 -> [Futch]
- Annotated dismiss action: ID 9 -> [Futch]
- Annotated dismiss action: ID 9 -> [Futch]
- Annotated dismiss action: ID 9 -> [Futch]
- Annotated dismiss action: ID 9 -> [Futch]
- Annotated dismiss action: ID 39 -> [Anita]

**Inventory Item Check Annotations** (3):
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #64 -> [Recipe #33]
- Annotated inventory check: Item #1 -> [Medicine]


### `toto_village.md` (37 changes)

**Party Recruitment Annotations** (3):
- Annotated recruit action: ID 4 -> [Viki]
- Annotated recruit action: ID 55 -> [Nina]
- Annotated recruit action: ID 73 -> [Kasumi]

**Character Dismissal Annotations** (18):
- Annotated dismiss action: ID 27 -> [Zamza]
- Annotated dismiss action: ID 27 -> [Zamza]
- Annotated dismiss action: ID 27 -> [Zamza]
- Annotated dismiss action: ID 27 -> [Zamza]
- Annotated dismiss action: ID 18 -> [Nanami]
- Annotated dismiss action: ID 27 -> [Zamza]
- Annotated dismiss action: ID 23 -> [Hanna]
- Annotated dismiss action: ID 23 -> [Hanna]
- Annotated dismiss action: ID 23 -> [Hanna]
- Annotated dismiss action: ID 23 -> [Hanna]
- *... and 8 more dismissal annotations*

**Inventory Item Check Annotations** (16):
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #8 -> [Fire Wall]
- Annotated inventory check: Item #16 -> [Revenge Earth]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #4 -> [Throat Drops]
- *... and 6 more item check annotations*


### `two_river_city.md` (154 changes)

**Party Recruitment Annotations** (16):
- Annotated recruit action: ID 51 -> [Badeaux]
- Annotated recruit action: ID 46 -> [Oulan]
- Annotated recruit action: ID 2 -> [Flik]
- Annotated recruit action: ID 72 -> [Siegfried]
- Annotated recruit action: ID 24 -> [Milie]
- Annotated recruit action: ID 5 -> [Sheena]
- Annotated recruit action: ID 8 -> [Tengaar]
- Annotated recruit action: ID 2 -> [Flik]
- Annotated recruit action: ID 89 -> [Shu]
- Annotated recruit action: ID 4 -> [Viki]
- *... and 6 more recruitment annotations*

**Character Dismissal Annotations** (38):
- Annotated dismiss action: ID 54 -> [Chaco]
- Annotated dismiss action: ID 117 -> [Ridley]
- Annotated dismiss action: ID 88 -> [Fitcher]
- Annotated dismiss action: ID 88 -> [Fitcher]
- Annotated dismiss action: ID 88 -> [Fitcher]
- Annotated dismiss action: ID 88 -> [Fitcher]
- Annotated dismiss action: ID 88 -> [Fitcher]
- Annotated dismiss action: ID 2 -> [Flik]
- Annotated dismiss action: ID 40 -> [Bob]
- Annotated dismiss action: ID 5 -> [Sheena]
- *... and 28 more dismissal annotations*

**Inventory Item Check Annotations** (100):
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #8 -> [Fire Wall]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #1 -> [Medicine]
- *... and 90 more item check annotations*


### `two_river_sewers.md` (6 changes)

**Party Recruitment Annotations** (1):
- Annotated recruit action: ID 11 -> [Georg]

**Character Dismissal Annotations** (2):
- Annotated dismiss action: ID 56 -> [Sid]
- Annotated dismiss action: ID 56 -> [Sid]

**Inventory Item Check Annotations** (3):
- Annotated inventory check: Item #9 -> [Kindness Drops]
- Annotated inventory check: Item #9 -> [Kindness Drops]
- Annotated inventory check: Item #4 -> [Throat Drops]


### `white_deer_inn.md` (45 changes)

**Party Recruitment Annotations** (19):
- Annotated recruit action: ID 5 -> [Sheena]
- Annotated recruit action: ID 46 -> [Oulan]
- Annotated recruit action: ID 43 -> [Ayda]
- Annotated recruit action: ID 24 -> [Milie]
- Annotated recruit action: ID 96 -> [Emilia]
- Annotated recruit action: ID 96 -> [Emilia]
- Annotated recruit action: ID 5 -> [Sheena]
- Annotated recruit action: ID 24 -> [Milie]
- Annotated recruit action: ID 24 -> [Milie]
- Annotated recruit action: ID 24 -> [Milie]
- *... and 9 more recruitment annotations*

**Character Dismissal Annotations** (2):
- Annotated dismiss action: ID 3 -> [Viktor]
- Annotated dismiss action: ID 18 -> [Nanami]

**Inventory Item Check Annotations** (24):
- Annotated inventory check: Item #9 -> [Kindness Drops]
- Annotated inventory check: Item #9 -> [Kindness Drops]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #2 -> [Mega Medicine]
- Annotated inventory check: Item #8 -> [Fire Wall]
- Annotated inventory check: Item #32 -> [Drinking Set]
- Annotated inventory check: Item #16 -> [Revenge Earth]
- Annotated inventory check: Item #1 -> [Medicine]
- Annotated inventory check: Item #4 -> [Throat Drops]
- Annotated inventory check: Item #4 -> [Throat Drops]
- *... and 14 more item check annotations*




---

## 🧭 File Renaming & Geographic Grounding Corrections (Audit Addendum)

Following user direction to eliminate misleading names that conflated Suikoden I locations and border settlements:

1. **`mt_tigerwolf.md` -> `ryube_forest.md`**:
   - **Reason**: Mt. Tigerwolf is a Suikoden I Toran Republic mountain (`bg_va7`–`bg_vad`). The content of this document is `vb09`, `vb10`, `vb11`, `vb20`, and `vb21` — the deep woodland forest paths behind Ryube Village leading to Tsai the Fire Spear inventor's cottage (Ryube Forest / 深き森).
2. **`drakemouth_village.md` -> `tigermouth_village.md`**:
   - **Reason**: `vg04` and `vg06` belong to Region `VG` (Tinto Republic), which is **Tigermouth Village** (虎口の村). Drakemouth Village is on the opposite Two River side of the mountain pass (`vh08`).
3. **`mt_ryukan_pass.md` -> `banner_pass.md`**:
   - **Reason**: Mt. Ryukan is Doctor Ryukan's mountain hermitage in Suikoden I (`bg_vc0`). `vf03` is the mountain pass connecting Banner Village to Gregminster in Suikoden II: **Banner Pass** (バナー峠), featuring the Giant Worm boss and the hidden approach to Rokkaku Hamlet.
4. **`swallow_pass_ryube_forest.md` -> `swallow_pass.md`**:
   - **Reason**: Disambiguated `vb07`, `vb08`, `vb17` to **Swallow Pass & Highland Border Gate** (燕の峠) so it does not collide with the canonical Ryube Forest document.
