# Suikoden II Character Battle Ranges Reference & Modding Guide

In **Suikoden II**, every combat-capable character usable in regular 6-person party battles is assigned an attack range based on their weapon and combat style. This determines their positioning requirements and valid target rows during combat.

---

## ⚔️ Combat Range Mechanics

| Range | In-Game Notation | Positioning Rule | Target Rule |
| :--- | :---: | :--- | :--- |
| **Short** | **S** | Must be placed in the **Front Row** to perform regular physical attacks. Cannot attack from the back row. | Can only target enemies in the **Front Row**. |
| **Medium** | **M** | Can attack from **either Front Row or Back Row**. | Can only target enemies in the **Front Row**. |
| **Long** | **L** | Can attack from **any row** (Front or Back Row). | Can target **any enemy row** (Front or Back Row). |

---

## 🛠️ Technical Modding / Patching Reference

* **Engine Hook:** `G2_SYS.G2_arms_range(int chano)` in `GSD2.dll` returns the integer range code for any character:
  * `0x00` (`0`) = **Short (S)**
  * `0x01` (`1`) = **Medium (M)**
  * `0x02` (`2`) = **Long (L)**
* **Mechanics Impact:** Modifying this return value or character weapon data dynamically affects:
  1. Attack availability checks when placing units in battle formations.
  2. Targeting algorithms for AI / Auto-battle commands.
  3. Animation range triggers during physical attack sequences.
  4. Range display text in the Status Window UI.

---

## 📋 Master Playable Combat Roster (70 Battle Characters Total)

### 🔴 Short Range (S) — Front Row Only (34 Characters)

| # | Character | Weapon / Combat Style | Notes / Recruit Details |
| :-: | :--- | :--- | :--- |
| 1 | **Anita** | Falcon Rapier | Falcon Rune swordswoman |
| 2 | **Badeaux** | Beast Whip | Animal listener / trainer |
| 3 | **Bob** | Werewolf Claws / Fists | Rabble werewolf brawler (Rabid Rune) |
| 4 | **Bolgan** | Fire Breath / Fists | Circus fire brawler |
| 5 | **Camus** | Rage Sword | Matilda Knights Commander |
| 6 | **Flik** | Odessa (Sword) | Blue Lightning |
| 7 | **Freed Y** | Broadsword | South Window officer |
| 8 | **Gadget** | Mechanical Punches | Meg's barrel robot |
| 9 | **Gantetsu** | Iron Beads / Fists | Strength monk |
| 10 | **Gengen** | Longsword | Kobold Captain |
| 11 | **Georg Prime** | Katana / Zanbato | High-crit wandering swordsman |
| 12 | **Hai Yo** | Cleaver / Wok Ladle | Castle Chef |
| 13 | **Hanna** | Heavy Greatsword | Two-handed blade defender |
| 14 | **Hix** | Penal Sword | Warrior's Village youth |
| 15 | **Humphrey Mintz** | Dragon Sword | Heavy armor defender |
| 16 | **Kahn Marley** | Longsword | Vampire hunter |
| 17 | **Kasumi** | Ninja Kunai / Claws | Ninja recruit (Mutually exclusive with Valeria) |
| 18 | **L.C. Chan (Long Chan Chan)** | Drunken Kung-Fu | Martial arts master |
| 19 | **Luc** | Wind Rod | True Wind Rune bearer / Mage |
| 20 | **Mazus** | Magician's Staff | Late-game archmage |
| 21 | **Miklotov** | Knight Estoc / Lance | Matilda Knights Captain |
| 22 | **Oulan** | Bodyguard Fists | Martial artist |
| 23 | **Pesmerga** | Crimson Greatsword | Dark knight |
| 24 | **Rikimaru** | Zanbato / Greatsword | Wandering mercenary |
| 25 | **Sheena** | Rook Rapier | Lepant's son |
| 26 | **Shin** | Spider Katana / Two-handed Sword | Teresa's bodyguard |
| 27 | **Shiro** | Fangs & Claws / Bite | Kinnison's wolf companion (Front Row melee) |
| 28 | **Sierra Mikain** | Darkness Claws / Melee | Vampire progenitor |
| 29 | **Valeria** | Seven Star Sword | Toran general (Mutually exclusive with Kasumi) |
| 30 | **Viki** | Sneeze Wand | Teleportation mage |
| 31 | **Viktor** | Star Dragon Sword | Two-handed greatsword wielder |
| 32 | **Vincent de Boule** | L'Epee (Rapier) | Flamboyant nobleman swordsman |
| 33 | **Wakaba** | Martial Arts | Monk apprentice |
| 34 | **Zamza** | Fire Knuckles | Fire magic brawler |

---

### 🟡 Medium Range (M) — Front or Back Row (16 Characters)

| # | Character | Weapon / Combat Style | Notes / Recruit Details |
| :-: | :--- | :--- | :--- |
| 1 | **Hero (Riou)** | Twin Tonfas | Main Protagonist / Bright Shield Rune |
| 2 | **Jowy Atreides** | Silver Staff | Main Story / Early Game playable |
| 3 | **Tir McDohl** | Heavenly Fang Staff | S1 Hero (Secret Toran Republic transfer recruit) |
| 4 | **Abizboah** | Kraken Tentacles | Large monster (Consumes 2 party slots) |
| 5 | **Amada** | Oar | Fisherman / Radat navigator |
| 6 | **Chaco** | Dagger & Flying Kicks | Winghorde thief (Flies across rows) |
| 7 | **Chuchura** | Kraken Tentacles | Small Kraken monster (Baby) |
| 8 | **Futch** | Dragon Cavalry Spear | Former dragon knight |
| 9 | **Hoi (Hwai-Po)** | Quarterstaff | Hero impersonator |
| 10 | **Karen** | Dance & Castanets / Claws | Castle dancer |
| 11 | **Nanami** | Flower Rod / Nunchaku | Hero's adoptive sister |
| 12 | **Nina** | Acrobat Whip | Greenhill Academy student |
| 13 | **Rulodia** | Kraken Tentacles | Kraken mother (Consumes 2 party slots) |
| 14 | **Sid** | Wing Sickles | Winghorde rogue |
| 15 | **Tai Ho** | Trident Spear | Fisherman & boatman |
| 16 | **Yoshino Yamamoto** | Naginata (Polearm) | Freed's wife |

---

### 🟢 Long Range (L) — Attack Anywhere (20 Characters)

| # | Character | Weapon / Combat Style | Notes / Recruit Details |
| :-: | :--- | :--- | :--- |
| 1 | **Ayda** | Longbow | Forest guardian |
| 2 | **Clive** | Sniper Gun (Storm) | Howling Voice Guild gunner |
| 3 | **Eilie** | Throwing Knives | Circus knife thrower |
| 4 | **Feather** | Griffon Swoop / Barrage | Large monster (Consumes 2 party slots) |
| 5 | **Gabocha** | Slingshot | Gengen's Kobold admirer |
| 6 | **Kinnison** | Hunter's Bow | Forest hunter |
| 7 | **Makumaku** | Squirrel Cape Gliding | Green flying squirrel |
| 8 | **Meg** | Trick Gadget Gun | Juppo trickster inventor |
| 9 | **Mekumeku** | Squirrel Cape Gliding | Yellow flying squirrel |
| 10 | **Mikumiku** | Squirrel Cape Gliding | Pink flying squirrel |
| 11 | **Millie** | Bonaparte Slingshot | Ground monster sling |
| 12 | **Mokumoku** | Squirrel Cape Gliding | Purple flying squirrel |
| 13 | **Mukumuku** | Squirrel Cape Gliding | Brown flying squirrel |
| 14 | **Rina** | Throwing Tarot Cards | Circus card mage |
| 15 | **Shilo** | Gambling Dice Throw | Street gambler |
| 16 | **Sigfried** | Unicorn Horn Ray | Mythical beast (Consumes 2 party slots) |
| 17 | **Simone Verdicci** | Rose Throw / Rapier | Flamboyant nobleman |
| 18 | **Stallion** | Elven Bow | True Holy Rune bearer |
| 19 | **Tengaar** | Throwing Rings / Chakram | Hix's companion |
| 20 | **Tuta** | Medicine Bag Pebbles | Dr. Huan's apprentice |

---

## 🚫 Non-Party / War Battle Only Recruits

The following characters are Stars of Destiny or allies who **cannot** be placed in the 6-person party battle roster:

| Character | Role | Notes |
| :--- | :--- | :--- |
| **Ridley Wizen** | War Battle Unit Commander | Tenko Star. Two River Kobold General (Major Tactical Battles only). |
| **Boris Wizen** | War Battle Unit Commander | Replaces Ridley on Tablet of Promise & War Battles if Ridley dies in Tinto. |
| **Kiba Windamier** | War Battle Unit Commander | Army General (War battles only). |
| **Klaus Windamier** | War Battle Strategist | Strategist (War battles only). |
| **Hauser** | War Battle Unit Commander | Army General (War battles only). |
| **Jess** | War Battle Support | War battle support (Evade). |
| **Gilbert** | War Battle Unit Commander | Mercenary unit leader (War battles only). |
| **Maximillian** | War Battle Unit Commander | Knight of Maximillian (War battles only). |
| **Teresa Wisemail** | Convoy / War Battle | Mayor of Greenhill. |
| **Shu** | Chief Military Strategist | Tenki Star. Devises high-level army strategies and commands units in War Battles. |
| **Castle Facility NPCs** | Castle Facility Staff | Barbara, Richmond, Lebrante, Alex, Hilda, Adlai, Emilia, Hans, Jeane, Raura, Templeton, Connell, Tetsu, Tony, Yuzu, Pico, Alberto, Jude, Tess, Gordon, Taki, Huan, Marlow, Fitcher, etc. |

---

## ⚙️ PKCore Character Battle Ranges Patch

PKCore includes a dedicated feature for customizing and modifying any character's battle range in **Suikoden II (HD Remaster)** via `PKCore.Patches.CharacterRangePatch`.

### 🎯 Default Range Enhancements
By default, the patch changes 4 key magic and agile combatants from **Short Range (S)** to **Medium Range (M)** so they can attack directly from the back row:
* **Kasumi** (`S` ➔ `M`) — Fast ninja wielder who can now strike from the back row without penalty.
* **Luc** (`S` ➔ `M`) — True Wind Rune mage now able to execute physical staff attacks from the rear row.
* **Mazus** (`S` ➔ `M`) — High-tier archmage equipped with medium-range staff reach.
* **Viki** (`S` ➔ `M`) — Teleportation mage who can now assist in physical attacks from the back formation.

### 📝 Configuration (`PKCore/Config/S2CharacterRanges.json`)
Ranges can be customized at any time using `S2CharacterRanges.json`. You can reference characters by English name, short internal name, or numeric ID:

```json
{
  "_description": "Configure battle range for Suikoden 2 characters. Options: 'S' (Short), 'M' (Medium), 'L' (Long).",
  "Kasumi": "M",
  "Luc": "M",
  "Mazus": "M",
  "Viki": "M"
}
```

* **Valid Range Values**: `"S"` (Short), `"M"` (Medium), `"L"` (Long).

### 🔧 Technical Implementation
The patch synchronizes across both engine code and native memory structures:
1. **Engine Range Evaluator**: Hooks `G2_SYS.G2_arms_range(int chano)` in `GSD2.dll` to return the modified range integer (`0`=S, `1`=M, `2`=L).
2. **UI & Formation Synchronization**:
   * Updates `fcommand.range` (Field & Castle Tavern party formation screen `yomipartykin`, removing the red `S` / `[X]` balloon warning on back row slots 4, 5, 6).
   * Updates `s_phase.arms_range` (Tablet of Stars / Status menus).
   * Injects into `BootProgram.arms_data`, `G2_SYS.G2_arms_data`, and `game_work.arms_data`.
   * Hooks `UIStatusWindow.UpdateStatusData` to display `"M"` in the character status screen.
3. **Dual ID Mapping**: Maps both catalog master IDs and active party/battle IDs (e.g. Kasumi: `72/73`, Luc: `53/139`, Mazus: `50/61`, Viki: `4/55`) ensuring consistency across all game states.

