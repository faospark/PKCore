# Suikoden II Character Attributes: Gender, Beast Classification & Bath Mechanics

This document provides a technical breakdown of how **Suikoden II** (and the HD Remaster engine `GameAssembly.dll` / `GSD2`) manages character classifications—specifically **gender (male vs. female)**, **beast and monster traits**, **equipment permissions**, and **castle bathhouse separation**.

---

## 1. Static Character Data: `C_KOTEI_DAT` and `ckd_info`

Character fixed attributes in Suikoden II are initialized from the static dataset `ckd_info` (originally from `CKD.BIN` in the PS1/PC versions). In the HD Remaster C# decompilation, this is maintained in `CHARA_DATA.cs` and parsed into objects of type `C_KOTEI_DAT` (`C_KOTEI_DAT.cs`).

### Key Fields in `C_KOTEI_DAT`:

| Field Name | Type | Purpose & Behavior |
| :--- | :--- | :--- |
| `soubi_henkou` | `byte` | **Equipment Changeable Flag**.<br>• `1` = Standard humanoid characters (can change equipment in menus).<br>• `0` = Beasts, monsters, and animals (equipment swapping is disabled). |
| `soubi_kanou` | `byte` | **Equippable Type Mask**.<br>Governs allowable equipment classes (Robes, Leather/Light, Heavy Plate, Shields), and enforces **female-exclusive** armor and accessory requirements. |
| `monsyo_seigen` | `byte[]` | Rune restrictions (which rune classes or head/hand slots are forbidden). |
| `mon_kosu_type` | `byte[]` | Rune slot progression and capacity per character. |
| `mon_zoku_aisyo` | `byte[]` | Elemental affinity scalars (Fire, Water, Wind, Earth, Lightning, etc.). |
| `seicyo_type` | `byte[]` | Stat growth curve archetypes (Early, Linear, Late bloomer). |
| `okori_panic` | `byte` | Character behavior when subjected to Berserk (`Okori`) or Panic states. |

> **Note regarding Suikoden 1 vs Suikoden 2**:
> In *Suikoden 1*, character data had an explicit `public byte sex` field directly on `PLAYER_DATA` (`0 = Male`, `1 = Female`). In *Suikoden 2*, gender is not a standalone top-level C# property; instead, it is encoded through the `soubi_kanou` bitmask and hardcoded character ID lookup tables.

---

## 2. Character ID Range & Species Classification (`chara_id`)

Suikoden II references all recruits via a 1-byte character ID (`chara_id`, ranging from `0` to `122+`). The engine uses specific ID ranges and lists to branch game mechanics:

### A. Large Beasts & Monsters (`ID 74 – 84` / `0x4A – 0x54`)
The engine frequently applies the formula `(10 < id - 0x4aU)` in routines such as `SyukuseiChk` and `Mem108Chk` (`_108check.cs`) to isolate non-humanoid monsters:

* `74`: **Abizboah** (Giant Kraken)
* `75`: **Rulodia** (Female Kraken)
* `76`: **Chuchara** (Baby Kraken)
* `77`: **Feather** (Griffin)
* `78`: **Siegfried** (Unicorn)
* `79 – 84`: Other monster / Listening Crystal recruit variants.

**Monster Rules**:
1. **Party Size**: Large monsters consume **2 party slots**.
2. **Locked Equipment**: `soubi_henkou = 0` (cannot equip armor or accessories).
3. **Blacksmith Exemption**: No upgradeable weapon levels in `ARMS_DATA`.
4. **Tablet of Stars Exemption**: By default, monster recruits do not count as standard Stars of Destiny.

### B. Small Animals & Companions
* **Shiro** (Wolf) and **Mukumuku** (Flying Squirrel):
  * Occupy **1 party slot** like human characters.
  * Have `soubi_henkou = 0` (cannot change armor).
  * Use custom monster attack actions and unique battle animations rather than weapon-based sprite sequences.

---

## 3. Castle Bath Mechanics (`furo_h.cs`, `f_main.cs`, `f_phase.cs`)

The headquarters bathhouse (managed by Tetsu) divides characters into gendered bathing areas and handles special interactions:

### A. Gender Partition & Tub Slot Architecture (`GetFuroPos` at `0x18201a7d0`)
* The bath is structurally split into two sections separated by a wooden wall: the **Men's side** and the **Women's side**, with a maximum room capacity of **12 positions** (`0..11`) managed in `FURO_WORK.furo_chara`:
  * **Positions `0 .. 5`**: Main Men's Tub (Right side, Positive X: `+32, +69, +106`, where Riou bathes).
  * **Positions `6 .. 11`**: Women's Tub (Left side, Negative X: `-32, -69, -106`, behind the partition).
* Position assignment is executed by `EventOverlayClass.f_main$$GetFuroPos` via jump table branching on `f_main.GetSeibetu(chara_id)`:
  * **Case 0 (`0x18201aa27`, Male)**: Loops through positions `0 .. 5` to locate the first free slot in the men's tub.
  * **Case 1 (`0x18201a9ec`, Female)**: Loops through positions `6 .. 11` to locate the first free slot in the women's tub.
  * **Case 2 (`0x18201a861`, Special / Unisex - Simone & Vincent)**: Evaluates whether women are present in the bath:
    * If **no female bathers** are present (`female_count == 0`), routes them to **Positions `6 .. 11`** (allowing Simone and Vincent to soak alone on the women's side of the bath).
    * If **female bathers are present**, routes them back to **Positions `0 .. 5`** (men's tub).
  * **Fallback Trap at `0x18201a98e` (`xor eax, eax; ret`)**: If an invalid index or overflow occurs, vanilla returns Position 0.
* **`GetFuroWomanNum` (`0x18201aaa0`)**: Scans all bathers and tallies every character where `GetSeibetu == 1` or `4`, driving conditional logic for bath dialogues and event triggers.

### B. Peeping / Wall Interaction (`FuroPhaseLookEvent` at `0x18201f180`)
* When Riou approaches the dividing wall and peeks over (`FuroPhaseLookEvent`), the engine evaluates which female character IDs are present in the active party.
* Custom dialog boxes and startled animations are triggered depending on who is on the other side (e.g., Nanami scolding Riou, Nina screaming, or unique reactions from adult female characters).

### C. Secret Bath Vignettes (`fc_event.cs` / `CheckCharaEvent00` to `04`)
In `EventOverlayClass/fc_event.cs`, specific combinations of character IDs trigger exclusive cutscenes and illustrated snapshots:
* **The Bickering Comrades (`CheckCharaEvent00` & `04`)**: Flik (2) and Viktor (3) with Riou (strictly asserts `G2_pamem_num(0) == 3`).
* **The Knights of Matilda (`CheckCharaEvent01`)**: Camus (33), Miklotov (32), and Freed Y (35) with Riou (strictly asserts `G2_pamem_num(0) == 4`).
* **The Martial Artists (`CheckCharaEvent02`)**: Wakaba (68) and L.C. Chan (69).
* **The Ninja Squad (`CheckCharaEvent03`)**: Kasumi (41 / 73) and Mondo (63).
* **Vignette Protection in PKCore**: Because routines like `CheckCharaEvent00` and `CheckCharaEvent01` strictly compare `G2_pamem_num(0)` against exact party counts (`eax == 3`, `eax == 4`), injecting NPC visitors would cause `eax == 8`, causing all special vignettes to fail their condition checks! PKCore implements `IsSpecialBathEventParty` to automatically detect when a special vignette composition enters the bath, instantly disabling visitor injection and `G2_pamem_num` overrides so the pure vanilla event plays uninterrupted.

### D. Native Implementation of Beasts & Monsters in the Bath
All recruited beasts and monsters possess native bathhouse implementations with authentic sprite atlases in `hp_furo` and dedicated routing:
* **Large Beasts & Monsters (IDs 74 .. 78)**:
  * **Native Gender Jump Table (`0x18201ac84`)**: Directly integrated into `EventOverlayClass.f_main$$GetSeibetu`:
    * **Abizboah** (Kraken, ID 74) & **Chuchara** (Baby Kraken, ID 76): Native gender classification.
    * **Rulodia** (Female Kraken, ID 75): Evaluates to Female (`1`), bathing on the women's side (slots 6..11).
    * **Feather** (Griffin, ID 77) & **Siegfried** (Unicorn, ID 78): Evaluates to Male (`0`), bathing on the men's side (slots 0..5).
  * **Aquatic Animations & Urns**: Decorating the bathhouse with items like the **6 Octopus Urns** when Abizboah and Rulodia are recruited triggers special kraken bath animations.
* **Small Companion Animals**:
  * **Shiro** (Canine, ID 48): Hardcoded check at `0x18201abfa` (`lea eax, [rbx - 0x30]; cmp eax, 2; jbe 0x18201ac25`) returning `0` (Male), placing him in the men's bath with custom sitting sprites on the wooden deck.
  * **Mukumuku & Squirrel Companions** (IDs 81, 83): Authentic soaking sprites and playful splash sequences.

### E. Native Implementation of Gadget (ID 26)
* **Meg's Barrel Robot**: Hardcoded natively at `0x18201ac20` in `EventOverlayClass.f_main$$GetSeibetu`:
  ```assembly
  0x18201ac20: cmp ebx, 0x1a   ; chara_id == 26 (Gadget)
  0x18201ac23: jne 0x18201ac2d
  0x18201ac25: xor eax, eax    ; returns 0 (Male -> Men's Bath)
  ```
* Gadget possesses dedicated barrel-tub soaking graphics in Atlas 5 (`hp_furo_26_atlas`), sitting contentedly in the men's tub alongside Riou and male companions.

---

## 4. Other Gender-Locked & Identity-Based Mechanics

### A. Siegfried's "Pure Maiden" Check
To recruit **Siegfried** in the Kobold Forest using the Listening Crystal, the conversation script validates that a young maiden is present in the current combat party. The engine checks the party against a hardcoded list of maiden character IDs:
* **Eligible**: Nanami, Wakaba, Viki, Nina, Sierra, Meg, Millie, Karen, Tomo, Kasumi, Tengaar.

### B. Cooperative Unite Attacks (`UNITE_DATA.cs`)
Gender- and archetype-based unite attacks define explicit member lists in `UNITE_DATA.player_id`:
* **Maiden Attack (乙女攻撃)**: Nanami, Millie, Tengaar, Meg.
* **Pure Maiden Attack**: Viki and companion maidens.
* **Pretty Boy Attack (美青年攻撃)**: Flik, Luc, Camus.
* **Kobold Attack**: Gengen and Gabocha.

### C. Female-Exclusive Equipment
Enforced through `soubi_kanou` in `C_KOTEI_DAT`:
* **Rose Brooch** (薔薇のブローチ)
* **Silver Hat** (銀の帽子)
* **Wind Hat** (風の帽子)
* **Tai Chi Wear / Karate Uniform** (道着)
* **Mangosh** (マンゴーシュ)
* **Guard Ring** (ガードリング)

---

## 5. Master Character Classification & Bath Placement Tables (Separated by Species & Gender)

Below, all Suikoden II combatants, beasts, non-human races, and key allies are organized into distinct tables categorized by **Species** and **Gender**.

---

### A. Humans — Male (Playable Combatants & Major Allies)

| Character | Species | Battle Slots | Equipment Swapping (`soubi_henkou`) | Castle Bathhouse Placement | Engine Archetype / Special Notes |
| :--- | :--- | :---: | :---: | :--- | :--- |
| **Hero (Riou)** | Human | 1 Slot | Yes (`1`) | Men's Bath (Active tub) | Main Protagonist; Bright Shield Rune; triggers peeping interactions. |
| **Jowy Atreides** | Human | 1 Slot | Yes (`1`) | Men's Bath | Black Sword Rune wielder (Early game). |
| **Flik** | Human | 1 Slot | Yes (`1`) | Men's Bath | Pretty Boy Attack; Flik & Viktor bath vignette. |
| **Viktor** | Human | 1 Slot | Yes (`1`) | Men's Bath | Star Dragon Sword wielder; Flik & Viktor bath vignette. |
| **Freed Y** | Human | 1 Slot | Yes (`1`) | Men's Bath | Knights of Matilda bath vignette. |
| **Camus** | Human | 1 Slot | Yes (`1`) | Men's Bath | Pretty Boy Attack; Knights of Matilda bath vignette. |
| **Miklotov** | Human | 1 Slot | Yes (`1`) | Men's Bath | Knights of Matilda bath vignette. |
| **Shin** | Human | 1 Slot | Yes (`1`) | Men's Bath | Bodyguard swordsman for Teresa. |
| **Kahn Marley** | Human | 1 Slot | Yes (`1`) | Men's Bath | Vampire Hunter (Resurrection Rune). |
| **Luc** | Human | 1 Slot | Yes (`1`) | Men's Bath | Pretty Boy Attack; True Wind Rune bearer. |
| **Mazus** | Human | 1 Slot | Yes (`1`) | Men's Bath | High Magician. |
| **Pesmerga** | Human / Unknown | 1 Slot | Yes (`1`) | Men's Bath | Crimson plate armor wielder. |
| **Georg Prime** | Human | 1 Slot | Yes (`1`) | Men's Bath | High-crit wandering swordsman. |
| **Humphrey Mintz** | Human | 1 Slot | Yes (`1`) | Men's Bath | Heavy plate warrior defender. |
| **Futch** | Human | 1 Slot | Yes (`1`) | Men's Bath | Dragon cavalry knight. |
| **Sheena** | Human | 1 Slot | Yes (`1`) | Men's Bath | Swordsman / Toran ambassador. |
| **Clive** | Human | 1 Slot | Yes (`1`) | Men's Bath | Howling Voice Guild gunner (Elza chase timer). |
| **Kinnison** | Human | 1 Slot | Yes (`1`) | Men's Bath | Forest hunter (Recruited with Shiro). |
| **Hix** | Human | 1 Slot | Yes (`1`) | Men's Bath | Warrior's Village youth; Lovers Attack w/ Tengaar. |
| **Zamza** | Human | 1 Slot | Yes (`1`) | Men's Bath | Fire brawler (Fire Dragon Rune). |
| **Bolgan** | Human | 1 Slot | Yes (`1`) | Men's Bath | Circus strongman; Circus Attack w/ Rina & Eilie. |
| **Rikimaru** | Human | 1 Slot | Yes (`1`) | Men's Bath | Zanbato mercenary. |
| **Amada** | Human | 1 Slot | Yes (`1`) | Men's Bath | Radat fisherman navigator. |
| **Tai Ho** | Human | 1 Slot | Yes (`1`) | Men's Bath | Fisherman boatman. |
| **L.C. Chan** | Human | 1 Slot | Yes (`1`) | Men's Bath | Martial arts master; Martial Arts Attack w/ Wakaba. |
| **Gantetsu** | Human | 1 Slot | Yes (`1`) | Men's Bath | Strength monk. |
| **Hai Yo** | Human | 1 Slot | Yes (`1`) | Men's Bath | Castle chef (Cook-off minigame quest). |
| **Shilo** | Human | 1 Slot | Yes (`1`) | Men's Bath | Street gambler (Chinchirorin). |
| **Hoi** | Human | 1 Slot | Yes (`1`) | Men's Bath | Hero impersonator. |
| **Tuta** | Human | 1 Slot | Yes (`1`) | Men's Bath | Young medical assistant. |
| **Tsai** | Human | 1 Slot | Yes (`1`) | Men's Bath | Fire spear technician; Father/Daughter Attack w/ Tomo. |
| **Vincent de Boule** | Human | 1 Slot | Yes (`1`) | Men's Bath | Flamboyant nobleman. |
| **Simone Verdricci** | Human | 1 Slot | Yes (`1`) | **Men's Bath** | Flamboyant aesthetic often mistaken for female; canonical bath confirms male status. |
| **Badeaux** | Human | 1 Slot | Yes (`1`) | Men's Bath | Animal trainer / Beast Listener (Listening Crystals). |
| **Mondo** | Human | 1 Slot | Yes (`1`) | Men's Bath | Rokkaku ninja; Ninja Squad bath vignette. |
| **Kage** | Human | Support / NPC | Yes (`1`) | Men's Bath | Mercenary ninja; Ninja Squad bath vignette. |
| **Tir McDohl** | Human | 1 Slot | Yes (`1`) | Men's Bath | Suikoden 1 Protagonist (Soul Eater). |
| **Shu** | Human | War Battle | Yes (`1`) | Non-combatant | Chief Military Strategist (Tenki Star). |
| **Kiba Windamier** | Human | War Battle | Yes (`1`) | Non-combatant | Highland defector army general. |
| **Klaus Windamier** | Human | War Battle | Yes (`1`) | Non-combatant | Military tactician. |
| **Hauser** | Human | War Battle | Yes (`1`) | Non-combatant | City-State infantry general. |
| **Jess** | Human | War Battle | Yes (`1`) | Non-combatant | South Window administrator. |
| **Gilbert** | Human | War Battle | Yes (`1`) | Non-combatant | Mercenary commander. |
| **Maximillian** | Human | War Battle | Yes (`1`) | Non-combatant | Maximillian Knight captain. |

---

### B. Humans — Female (Playable Combatants & Major Allies)

| Character | Species | Battle Slots | Equipment Swapping (`soubi_henkou`) | Castle Bathhouse Placement | Engine Archetype / Special Notes |
| :--- | :--- | :---: | :---: | :--- | :--- |
| **Nanami** | Human | 1 Slot | Yes (`1`) | Women's Bath (Behind wall) | Pure Maiden; Family Attack; scolds Riou if peeping over wall. |
| **Eilie** | Human | 1 Slot | Yes (`1`) | Women's Bath | Pure Maiden; Circus Attack; Beautiful Women bath vignette. |
| **Rina** | Human | 1 Slot | Yes (`1`) | Women's Bath | Adult circus tarot card mage; Circus Attack. |
| **Nina** | Human | 1 Slot | Yes (`1`) | Women's Bath | Pure Maiden; Beautiful Women bath vignette; screams at peeping. |
| **Karen** | Human | 1 Slot | Yes (`1`) | Women's Bath | Pure Maiden; Beautiful Women bath vignette; castle dancer. |
| **Viki** | Human | 1 Slot | Yes (`1`) | Women's Bath | Pure Maiden Attack; Blinking Rune teleportation mage. |
| **Millie** | Human | 1 Slot | Yes (`1`) | Women's Bath | Pure Maiden; Maiden Attack w/ Bonaparte pet. |
| **Meg** | Human | 1 Slot | Yes (`1`) | Women's Bath | Pure Maiden; Maiden Attack w/ Gadget machine. |
| **Tengaar** | Human | 1 Slot | Yes (`1`) | Women's Bath | Pure Maiden; Maiden Attack; Lovers Attack w/ Hix. |
| **Wakaba** | Human | 1 Slot | Yes (`1`) | Women's Bath | Pure Maiden; Martial Arts Attack w/ L.C. Chan. |
| **Kasumi** | Human | 1 Slot | Yes (`1`) | Women's Bath | Pure Maiden; Ninja Squad bath vignette (Mutually exclusive w/ Valeria). |
| **Tomo** | Human | 1 Slot | Yes (`1`) | Women's Bath | Pure Maiden; Father/Daughter Attack w/ Tsai. |
| **Anita** | Human | 1 Slot | Yes (`1`) | Women's Bath | Falcon Rune swordswoman. |
| **Valeria** | Human | 1 Slot | Yes (`1`) | Women's Bath | Toran Army general (Mutually exclusive w/ Kasumi). |
| **Hanna** | Human | 1 Slot | Yes (`1`) | Women's Bath | Heavy greatsword brawler. |
| **Oulan** | Human | 1 Slot | Yes (`1`) | Women's Bath | Martial artist bodyguard. |
| **Ayda** | Human | 1 Slot | Yes (`1`) | Women's Bath | Forest Village archer guardian. |
| **Yoshino Yamamoto** | Human | 1 Slot | Yes (`1`) | Women's Bath | Naginata polearm wielder; Freed Y's wife. |
| **Apple** | Human | War / Convoy | Yes (`1`) | Women's Bath (NPC) | Strategist; Mathiu Silverberg's student. |
| **Teresa Wisemail** | Human | War / Convoy | Yes (`1`) | Women's Bath (NPC) | Mayor of Greenhill. |
| **Pilika** | Human | Story NPC | N/A | Women's Bath (Special event)| Jowy / Riou companion child. |
| **Leona** | Human | Facility (Tavern)| Yes (`1`) | Women's Bath (NPC) | Castle tavern manager. |
| **Barbara** | Human | Facility (Vault) | Yes (`1`) | Women's Bath (NPC) | Castle storage manager. |
| **Jeane** | Human | Facility (Rune)  | Yes (`1`) | Women's Bath (NPC) | Master rune sage. |
| **Raura** | Human | Facility (Scroll)| Yes (`1`) | Women's Bath (NPC) | Scroll maker (Jeane's friend). |
| **Emilia** | Human | Facility (Library)| Yes (`1`)| Women's Bath (NPC) | Greenhill academy librarian. |
| **Taki** | Human | Facility (Gossip)| Yes (`1`) | Women's Bath (NPC) | Story gossip grandmother. |
| **Yuzu** | Human | Facility (Farm)  | Yes (`1`) | Women's Bath (NPC) | Castle pasture keeper. |

---

### C. Demi-Humans & Non-Human Humanoids (Kobolds, Winghorde, Elves, Vampires, Werewolves)

| Character | Gender | Species / Race | Battle Slots | Equipment Swapping (`soubi_henkou`) | Castle Bathhouse Placement | Engine Archetype / Special Notes |
| :--- | :--- | :--- | :---: | :---: | :--- | :--- |
| **Gengen** | Male | Kobold | 1 Slot | Yes (`1`) | Men's Bath | Kobold Captain; Kobold Attack w/ Gabocha. |
| **Gabocha** | Male | Kobold | 1 Slot | Yes (`1`) | Men's Bath | Kobold admirer; Kobold Attack w/ Gengen. |
| **Ridley Wizen** | Male | Kobold | War Battle | Yes (`1`) | Men's Bath | Two River Kobold army general (Tenko Star). |
| **Boris Wizen** | Male | Kobold | War Battle | Yes (`1`) | Men's Bath | Ridley's son; replaces Ridley if killed in Tinto. |
| **Chaco** | Male | Winghorde | 1 Slot | Yes (`1`) | Men's Bath | Flying Winghorde thief. |
| **Sid** | Male | Winghorde | 1 Slot | Yes (`1`) | Men's Bath | Rebellious Winghorde fighter. |
| **Stallion** | Male | Elf | 1 Slot | Yes (`1`) | Men's Bath | Fleet-footed runner; True Holy Rune bearer. |
| **Bob** | Male | Werewolf / Human | 1 Slot | Yes (`1`) | Men's Bath | Two River Rabid Rune shapeshifter. |
| **Sierra Mikain** | Female | Vampire | 1 Slot | Yes (`1`) | Women's Bath | Progenitor of vampires; Blue Moon Rune; Pure Maiden check. |

---

### D. Beasts, Animals & Monsters

| Character | Gender / Type | Species / Family | Battle Slots | Equipment Swapping (`soubi_henkou`) | Castle Bathhouse Placement | Engine Archetype / Special Notes |
| :--- | :--- | :--- | :---: | :---: | :--- | :--- |
| **Shiro** | Male | Wolf / Canine | 1 Slot | **No (`0`)** | Men's Bath (Deck / Edge) | 1-slot companion beast; locked gear; native check at `0x18201abfa` routes to Men's Bath. |
| **Mukumuku** | Male | Flying Squirrel | 1 Slot | **No (`0`)** | Men's Bath (Tub / Edge) | 1-slot beast; Squirrel 5 Attack; native splashing bath sprite. |
| **Makumaku** | Male | Flying Squirrel | 1 Slot | **No (`0`)** | Men's Bath (Tub / Edge) | Green flying squirrel; Squirrel 5 Attack. |
| **Mikumiku** | Female | Flying Squirrel | 1 Slot | **No (`0`)** | Women's Bath | Pink flying squirrel; Squirrel 5 Attack; routes to women's tub. |
| **Mekumeku** | Male | Flying Squirrel | 1 Slot | **No (`0`)** | Men's Bath (Tub / Edge) | Yellow flying squirrel; Squirrel 5 Attack. |
| **Mokumoku** | Male | Flying Squirrel | 1 Slot | **No (`0`)** | Men's Bath (Tub / Edge) | Purple flying squirrel; Squirrel 5 Attack. |
| **Abizboah** | Male | Giant Kraken / Monster | **2 Slots** | **No (`0`)** | Men's Bath (Tub) | `ID 74` (`0x4A`); 2 slots; native routing at `0x18201ac84`; Octopus Urns animation. |
| **Rulodia** | Female | Giant Kraken / Monster | **2 Slots** | **No (`0`)** | Women's Bath (Tub) | `ID 75` (`0x4B`); 2 slots; native jump table routes to Women's Tub (slots 6..11). |
| **Chuchara** | Neutral / Young | Baby Kraken / Monster | 1 Slot | **No (`0`)** | Men's Bath (Tub) | `ID 76` (`0x4C`); 1 slot baby kraken; native bath sprite. |
| **Feather** | Male / Neutral | Griffin / Beast | **2 Slots** | **No (`0`)** | Men's Bath (Tub) | `ID 77` (`0x4D`); 2 slots; Shining Bird; native jump table routes to Men's Tub (slots 0..5). |
| **Siegfried** | Male | Unicorn / Holy Beast | **2 Slots** | **No (`0`)** | Men's Bath (Tub) | `ID 78` (`0x4E`); 2 slots; native jump table routes to Men's Tub (slots 0..5). |

---

### E. Constructs & Mechanical Units

| Character | Gender / Type | Species / Construction | Battle Slots | Equipment Swapping (`soubi_henkou`) | Castle Bathhouse Placement | Engine Archetype / Special Notes |
| :--- | :--- | :--- | :---: | :---: | :--- | :--- |
| **Gadget** | Male (Hardcoded `0`) | Mechanical Barrel Robot | 1 Slot | **No (`0`)** | Men's Bath (Tub) | Hardcoded at `0x18201ac20` in `GetSeibetu` (`cmp ebx, 0x1a -> 0`); dedicated `hp_furo_26` barrel tub sprites. |

---

## 6. Blocked NPC Bath Sprites & The Engine Crash Mechanism

Although vanilla *Suikoden II* never allows non-combatant recruits or castle facility NPCs to bathe, **Konami's artists drew bathhouse sprites for virtually every recruit in the game**, including characters who can never be placed into the active combat party.

### A. Asset Atlas Structure (`hp_furo_XX_atlas`)
Bathhouse character sprites are stored in modular 5-character texture atlas sheets:
* **Atlas Index Formula**: `atlas_group = (chara_id - 1) / 5`
* **Sub-slot in Atlas**: `slot_index = (chara_id - 1) % 5`
* Texture assets span from `hp_furo_00_atlas` up to `hp_furo_37_atlas` (covering character IDs through 185+).
* Extracted texture dumps verify that sprites exist for non-combatants including:
  * **Strategists & Generals**: Shu, Apple, Kiba, Klaus, Hauser, Jess, Gilbert.
  * **Castle Facilities**: Leona (Tavern), Barbara (Vault), Jeane (Rune Shop), Raura (Scrolls), Emilia (Library), Taki (Gossip), Yuzu (Farm), Hai Yo (Kitchen), Richmond (Investigations).
  * **Story NPCs & Non-Combatants**: Pilika, Teresa Wisemail, Marlowe, Templeton, Alex, Hilda, Adlai, Sansuke, Tetsu.

### B. The Engine Crash Trap in `CreateFuroChara` (`0x182015de0`)
Historically, players attempting to view these sprites by using save editors or cheat codes (forcing NPC IDs into the active combat party or convoy) encountered an immediate game freeze/crash upon entering the bath.

Low-level binary disassembly of `EventOverlayClass.f_main$$CreateFuroChara` reveals the exact cause:

```x86asm
; --- Loop iterating through party members (ebp = 0..party_count-1) ---
0x18201604e: movzx   esi, byte ptr [rax + rcx + 0x20] ; esi = chara_id
0x182016053: mov     ecx, ebp                         ; ecx = party slot index
0x182016059: call    0x181a2f1f0                      ; G2_SYS$$G2_gra_dat (returns P_GRAPH_DATA)
0x18201605e: test    rax, rax
0x182016061: je      0x182016725                      ; Crash if P_GRAPH_DATA is null
0x182016067: cmp     qword ptr [rax + 0x28], 0        ; [rax + 0x28] = P_GRAPH_DATA.field_data
0x18201606c: je      0x182016725                      ; CRASH: NullReferenceException!
0x182016072: cmp     qword ptr [rax + 0x20], 0        ; [rax + 0x20] = P_GRAPH_DATA.battle_data
0x182016077: je      0x182016725                      ; CRASH: NullReferenceException!
```

* **The Trap**: `P_GRAPH_DATA` (`P_GRAPH_DATA.cs`) only instantiates `field_data` and `battle_data` for combat-ready party members. Non-combatants and convoy members have `null` pointers in these fields.
* **The Irony**: The engine **never reads or uses** `field_data` or `battle_data` anywhere in the bathhouse logic. Right after these checks, `CreateFuroChara` calculates the atlas index (`(chara_id - 1) / 5`) and calls `CreateFuroAnime` (`0x181ff6590`) to render the sprite directly from `hp_furo_XX_atlas`. The crash is purely an unnecessary precondition check.

### C. The Equipment Scan Bounds Trap (`CheckfuroItemEquip` / `G2_varia_dat`)
Immediately after `CreateFuroChara`, `f_main.FuroInit` calls `CreateFuroEquipAnime` (`0x182016750`) to check whether bathers have bath accessories (towels, shampoo, soaps) equipped.
* It calls `f_main.CheckfuroItemEquip(chara_no, item_no)`, which internally calls `G2_SYS.G2_varia_dat(chano)`.
* In Suikoden II, variable player stats (`c_varia_dat`) are only allocated for combat characters (`ID 0..82`).
* When an NPC (`ID >= 84`) is queried, `G2_SYS.G2_varia_dat` performs `cmp ebx, [rcx + 0x18]` against the array length and immediately throws `System.IndexOutOfRangeException: Index was outside the bounds of the array`.
* **The Solution**: Prefixing `G2_varia_dat` and `CheckfuroItemEquip` to return `null` / `0` for any character `ID >= 83` cleanly bypasses this check, as NPCs do not have equipment inventory arrays.

### D. The Gender Resolution Traps & Vanilla Data Bugs (`f_main.GetSeibetu` at `0x18201ab90`)
Investigation of bathhouse gender separation revealed two major systemic flaws in vanilla Suikoden II:
* Binary disassembly of `EventOverlayClass.f_main$$GetSeibetu` reveals how vanilla resolves character gender:
  ```x86asm
  0x18201ac08: ja        0x18201ac3d                      ; Jump if chara_id > 79
  0x18201ac3d: test      rdx, rdx
  0x18201ac42: mov       rcx, qword ptr [rdx + 0x18]      ; ckd_info list
  0x18201ac52: mov       edx, ebx                         ; chara_id
  0x18201ac54: call      List<List<byte>>$$get_Item       ; rax = ckd_info[chara_id]
  0x18201ac65: mov       edx, 1
  0x18201ac6a: mov       rcx, rax
  0x18201ac6d: call      List<byte>$$get_Item             ; rax = ckd_info[chara_id][1]
  0x18201ac72: and       eax, 0xf                         ; return (ckd_info[chara_id][1] & 0xf)
  0x18201ac7a: ret
  ```
* **Flaw 1: NPC Gender Zeroing**: For any character `ID > 79`, `GetSeibetu` computes gender by reading the bitmask `ckd_info[chara_id][1] & 0xf`. Because non-combatant castle NPCs cannot equip battle armor, their attribute records are zeroed.
  * **Consequence**: `GetSeibetu` evaluated to `0` (Male) for **every single non-combatant NPC**, incorrectly sending female companions (Apple, Leona, Barbara, Teresa, Pilika, Jeane, Taki, Yuzu, etc.) to Case 0 (`0x18201aa27`, Men's Tub) and leaving the women's tub empty.
* **Flaw 2: Vanilla Male Character Misclassifications (Bob, Chaco, Kiba, Alex)**: In vanilla Konami game data, several male characters were assigned female attribute values in `ckd_info[chara_id][1] & 0xf`:
  * **Bob** (`player_bic`, ID 4): Byte 1 is `0x21` (`val = 1`). Vanilla evaluates Bob as **Female**, causing `GetFuroPos` to jump to Case 1 and place Bob inside the **women's tub behind the partition**!
  * **Chaco** (`player_zko`, ID 17): Byte 1 is `0x34` (`val = 4`). Vanilla evaluates Chaco as **Female**, placing the young Winghorde boy into the women's tub!
  * **General Kiba** (ID 86): Byte 1 is `0x21` (`val = 1`).
  * **Alex** (ID 103): Byte 1 is `0x21` (`val = 1`).

---

## 7. Restoration Architecture in PKCore

Restoring NPC bath sprites requires eliminating all engine traps, correctly routing gender separation, and providing a clean gameplay mechanism for castle companions to join the bath.

### Step 1: Engine Traps & Gender Flaw Elimination
1. **Safe Null Bypass (`G2_SYS.G2_gra_dat`)**:
   * If a party member has no combat `P_GRAPH_DATA` (or has null `field_data`/`battle_data`), supply a harmless dummy `P_GRAPH_DATA` object via `ScriptableObject.CreateInstance` rather than null.
   * Completely prevents the `NullReferenceException` at `0x182016725`.
2. **Variable Data Bounds Guard (`G2_SYS.G2_varia_dat` & `CheckfuroItemEquip`)**:
   * Preemptively intercept calls for `chano >= 83`, returning `null` (and `0` for item equip checks).
   * Completely eliminates the `System.IndexOutOfRangeException` in `CreateFuroEquipAnime`.
3. **Gender Resolution Hook (`f_main.GetSeibetu`)**:
   * Harmony prefix on `EventOverlayClass.f_main$$GetSeibetu` using verified ground-truth GSD2 character IDs (`player_*.json`).
   * Explicitly maps all canonical female characters (Nanami [18], Eilie [19], Rina [20], Nina [55], Tengaar [8], Millie [24], Meg [25], Karen [14], Kasumi [41/73], Valeria [12], Anita [39], Ayda [43], Sierra [42/45], Oulan [46], Tomo [57], Viki [60], Wakaba [68], Hanna [23], Mikumiku [83], Rulodia [71], Apple [84/85], Teresa Wisemail [95/102], Barbara [96], Yuzu [98], Pilika [100/124], Emilia [102], Raura [104], Elza [172]) to `1` (Female).
   * Strictly classifies all other characters (including **Bob [4]**, **Chaco [17]**, **Kiba [86/87]**, **Marlowe [91/120]**, **Richmond [86/93]**, **Tenkou [99]**, **Templeton [97/101]**, **Adlai [101/105]**, and **Alex [103]**) as `0` (Male).
   * **Root Cause of Tenkou in Women's Tub**: Character ID 99 was previously labeled as "Taki" and placed in female pools. 2D image cross-correlation of `hp_furo_19_atlas` slot 3 confirmed ID 99 is Tenkou (bearded man with gold headband). Reclassified ID 99 to `MaleCastleNPCs` and `PermanentCastleMales`, ensuring he routes strictly to the men's tub.
   * **Root Cause of Teresa in Men's Tub**: Character ID 95 in `hp_furo_18_atlas` slot 4 contains the dark green haired female sprite (Teresa Wisemail), which was previously miscataloged under `MaleCastleNPCs` as Alex, while ID 91 (bare-chested young man) was miscataloged under female pools as Teresa. Reclassified ID 95 and ID 102 to `FemaleCharaIds` and `FemaleCastleNPCs`, guaranteeing Teresa routes strictly to the women's tub.

### Step 2: NPC Bath Delivery Mechanisms

#### 1. Convoy Support (Save Editor & Story Compatible)
* By default, vanilla only iterates through party slots `0..5`.
* By extending the character loading routine to include the convoy slot (`party_data.party_cha_no[6]`), characters placed in the convoy (either through story progression or save editors) will automatically bathe alongside Riou without crashing.

#### 2. Castle NPC Visitor Pool (Segregated Pools & Guaranteed Female Representation)
* In vanilla, the bathhouse has empty tub spots if your combat party has fewer than 6 members, or if few women are in your party.
* Whenever Riou enters the bath, any unoccupied spots are populated from the pool of currently recruited castle NPCs:
  * **Candidate Segregation**: Recruits are divided into `FemaleCastleNPCs` and `MaleCastleNPCs`.
    * **Men's side**: Richmond / Hauser [86], Kiba [87], Fitcher [88], Jess [89], Gilbert [90], Marlowe / Young man [91], Marlowe [92], Richmond [93], Spiky hair man [94], Templeton / Green hat boy [97], Tenkou [99], Adlai / Kiba [101], Alex [103], Adlai [105], Sansuke [107/108], Tetsu [109], Maximillian [110], Ridley [118/121], Marlowe [120], Boris [123], Grenmeyer [125], Klaus [143].
    * **Women's side**: Apple [84/85], Teresa Wisemail [95], Barbara [96], Yuzu [98], Pilika [100], Emilia / Teresa [102], Raura [104], Elza [172].
  * **Guaranteed Facility Inclusion**: Core castle facility residents (**Apple, Teresa, Barbara, Pilika, Emilia** for women; **Hauser, Richmond, Tenkou** for men) are guaranteed in the candidate pool without depending on standard Star recruitment flags.
  * **Balanced Tub Distribution**: If multiple vacancies exist, the selection alternates between female and male recruits, filling both the men's tub (right) and women's tub (left) simultaneously.
  * **Zero Save-Data Footprint**: Slot substitutions occur strictly in memory during `f_main.FuroInit` and are completely restored to the player's exact party configuration upon bath exit (`f_main.FuroEnd`).

#### 3. Full 8-Character Bathhouse Expansion (+2 Convoy & Castle Visitor Slots)
* **Architectural Discovery**: Disassembly of `EventOverlayClass.f_main$$CreateFuroChara`, `GetFuroPos`, and `furo_h.FURO_WORK$$ctor` (`0x181ff5cf0`) revealed that the entire Suikoden II bathhouse engine was architecturally designed for **8 actors**:
  * `furo_pos_data`, `furo_chara_id`, `furo_chara_info`, `furo_chara_palette`, `chara_status`, and the `FuroInit` loop (`0x182019956`) are all arrays of length **8**.
  * The tub array `furo_chara` contains **12** physical tub spots (`0..5` in the men's tub, `6..11` in the women's tub).
  * Vanilla game party data (`PARTY_DATA.party_cha_no`) contains **8** character slots (`0..5` for battle members, `6..7` for convoy members).
* **The Vanilla 6-Character Bottleneck**:
  * In vanilla code, `CreateFuroChara` (`0x182015f7e`) and `GetFuroPos` (`0x18201a8a0`) both call `G2_SYS.G2_pamem_num(0)`.
  * In vanilla, `G2_pamem_num(0)` counts **only** combat slots (`0..5`), returning a maximum of 6 and completely ignoring convoy slots (`6..7`).
  * As a result, vanilla only ever instantiated up to 6 bathers, leaving the two remaining internal actor slots completely unused.
* **The PKCore Resolution**:
  * **`G2_SYS.G2_pamem_num` Harmony Prefix**: When `IsInsideBath` is true, intercepts `G2_pamem_num` to count all active characters across all 8 slots (`party_cha_no[0..7]`), returning up to 8.
  * **`PrepareBathParty` 8-Slot Scanning**: Now evaluates and fills all 8 slots (`0..7`).
    * If the player enters with a full 6-character battle party, slots 6 and 7 (+2 over the party count) are populated with recruited castle companions or convoy members, allowing **8 companions to soak together**.
    * If the player enters with a partial battle party (e.g. Riou alone or 3-4 members), all empty slots across `1..7` are populated with castle recruits, balanced between male and female visitors up to 8 bathers total.
    * Both tubs (men's tub 0..5 and women's tub 6..11) are populated simultaneously, creating a bustling, lively castle bathhouse.
  * **Memory Isolation**: Upon bath exit (`f_main.FuroEnd`), all 8 slots of `party_cha_no` are restored back to the player's exact prior party configuration.

#### 4. Tetsu Bathhouse Menu (Interactive Selection Option)
* When speaking to Tetsu, the standard dialogue presents:
  1. *Take a bath* (入る)
  2. *Change bath style* (風呂を変える)
  3. *Never mind* (やめる)
* Implementation Approaches:
  * **Approach A (Automated / Zero-Friction — Implemented)**: The Visitor Pool approach above requires no UI hacking; speaking to Tetsu to bathe automatically fills spare spots with castle recruits.
  * **Approach B (Submenu Injection)**: Adding an "Invite Guests" option into Tetsu's dialogue tree or intercepting the selection window (`MakeSelectWindow` at `0x182021660` / `f_phase.MakeSelectWindow`) to open a character selection roster before bath entry.


