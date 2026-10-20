# Suikoden I: Quality of Life & Recruitment Enhancement Proposals

This document compiles proposals and architectural designs for Quality of Life (QoL) improvements and recruitment mechanics enhancements for **Suikoden I** within the **PKCore** mod framework.

---

## 1. Executive Overview

While Suikoden I established the foundational charm of the series, modern playthroughs suffer from classic 1995 RPG friction points:
1. **Excessive backtracking** to Toran Castle for routine maintenance (blacksmithing, rune swapping, party changing).
2. **Fragile recruitment conditions**, where simple dialogue choices, invisible stat checks, or narrow story cutoff windows can permanently lock players out of the 108 Stars of Destiny and the True Ending.
3. **Severe inventory limits**, where gear and consumable items share a tiny 8–9 slot personal pouch.
4. **Party-locking requirements**, forcing sub-optimal or under-leveled characters into the active battle lineup just to trigger recruit dialogue.

Below are structured technical proposals to address these pain points using Harmony hooks into the game's decompiled C# and native IL2CPP logic.

---

## 2. Castle Services On-Demand (Expanding on Rock's Vault)

Building upon the successful architecture of `S1QuickStoragePatch` (which binds Rock's Toran Castle Vault to `R3` / `V`), the following castle services can be invoked from anywhere in the field:

### 2.1 Remote Blacksmith (Weapon Sharpening)
* **Problem**: Every time new characters join, you must travel to Toran Castle or specific towns (Maas, Meese, Mose, Moose) to sharpen weapons individually across all party members from Level 1 to 16.
* **Proposal**:
  * Invoke the blacksmith sharpening screen directly via an ImGui overlay button or hotkey shortcut.
  * Allow upgrading equipped weapons directly from the field using the party's current potch, capped by the highest blacksmith tier currently recruited.

### 2.2 Remote Rune Master (Jeane)
* **Problem**: Attaching, detaching, or shifting runes between party members requires physically visiting Jeane at Toran Castle or an established town rune shop.
* **Proposal**:
  * Expose Jeane's rune affiliation menu through a field shortcut once she is recruited to Toran Castle.
  * Remove the penalty/inconvenience of having to plan rune setups hours in advance.

### 2.3 Remote Party Formation (Sanchez)
* **Problem**: Changing party composition requires climbing to the 4th floor of Toran Castle to speak with Sanchez.
* **Proposal**:
  * Allow invoking Sanchez's member swap interface while at save points, inns, or on the world map.
  * Protect mandatory story locks while granting total freedom during exploration phases.

---

## 3. Recruitment Mechanics & 108 Stars Overhaul

### 3.1 Removing Active Party Roster Lockouts
Several recruits require specific characters to occupy active battle party slots rather than merely belonging to the Toran Liberation Army:
* **Mace (The 4 Blacksmiths)**:
  * *Vanilla*: Requires Maas, Meese, Mose, and Moose all in the active 6-person party at Seek Valley, leaving only 2 combat slots to survive high-level enemies.
  * *Patch*: Check whether all four blacksmiths exist in the Castle roster (`dat.sdata`) rather than the active battle party.
* **Meg (Needs Juppo)** & **Gon (Needs Kuromimi)**:
  * *Vanilla*: Will not join unless Juppo / Kuromimi is physically in the party.
  * *Patch*: Satisfy the check if Juppo / Kuromimi has been recruited to Toran Castle.

### 3.2 Permanent Missables & Execution Safety Guards
* **Kwanda Rosman & Milich Oppenheimer Execution Safeguards**:
  * *Vanilla*: Defeating these imperial generals presents post-battle dialogue trees with irreversible execution options (*"Off with his head!"* vs *"I want you to join us"*). Choosing the wrong response permanently kills them and locks out the 108 Stars ending.
  * *Patch*: Add a confirmation prompt or highlight the peaceful recruitment option to prevent accidental misclicks.
* **Leon Silverberg Cutoff Protection**:
  * *Vanilla*: Requires speaking to Leon at Kalekka, retrieving a letter from Mathiu at Toran Castle, and returning to Leon **strictly before** the Shasarazade assault begins. Missing this window permanently locks him out.
  * *Patch*: Prevent the Shasarazade story flags from invalidating Mathiu's letter event, allowing Leon to be recruited up until the final castle gathering.
* **Sonya Eren Prison Dialogue Safety**:
  * *Vanilla*: After defeating and capturing Sonya, you must visit her in the basement prison and select the exact sequence (*"I want you to join"* $\rightarrow$ *"I don't mind"*). Refusing or selecting wrong dialogue leaves her imprisoned permanently.
  * *Patch*: Ensure her recruitment dialog remains repeatable if initially refused.
* **Pahn Duel Survival Advisor / Safety**:
  * *Vanilla*: During the 1-on-1 duel between Pahn and Teo, if Pahn's level, weapon, and armor are under-developed, he dies permanently.
  * *Patch*: 
    * Display an ImGui indicator before the duel warning whether Pahn's stats are sufficient to survive Teo's damage output.
    * Optional safety toggle: Prevent fatal lethal blows during the duel so Pahn survives at 1 HP.

### 3.3 Streamlining Tedious Fetch Quests
* **Sarah's Kirov Errand Chain**:
  * *Vanilla*: Requires running between 5 NPCs across Kirov (Sarah $\rightarrow$ Laundry Lady $\rightarrow$ Merchant $\rightarrow$ Cook $\rightarrow$ Merchant $\rightarrow$ Appraiser) to retrieve soap.
  * *Patch*: Allow skipping the relay chain if the player already holds the required items, or auto-complete the errand upon talking to Sarah.
* **Lester's Stew Tasting (Kirov)**:
  * *Vanilla*: Lester will not speak to the player in the Mayor's estate until the player visits 3 separate residential houses and interacts with stew pots.
  * *Patch*: Auto-flag the stew tastings upon entering Kirov or highlight the relevant houses.
* **Fu Su Lu's Tavern Tab**:
  * *Vanilla*: Demands 10,000 potch to pay off his bill in Great Forest.
  * *Patch*: Offer to draw payment directly from Castle funds if pocket cash is low.

### 3.4 Stat Check & Level Transparency
* **Eikei (Level 40 Check in Teien)**:
  * *Vanilla*: Refuses to join with vague dialogue unless Tir is Level 40+.
  * *Patch*: Explicitly display Tir's current level vs the requirement (*"You are Level 36 / 40"*).
* **Quincy (80+ Recruits Check in Garan)**:
  * *Vanilla*: Refuses to join without stating how many more recruits are needed.
  * *Patch*: Display exact star count in dialog (*"You have recruited 74 / 80 required stars"*).
* **Clive Spawn Guarantee**:
  * *Vanilla*: Has a randomized spawn chance in Rikon inn, and only after Toran Castle reaches Level 4.
  * *Patch*: Guarantee Clive's spawn at 100% once Castle Level 4 is reached.

---

## 4. In-Game "Recruitment Radar" (Detective Tab in ImGui)

Suikoden II introduced **Richmond the Detective** to investigate recruit clues. Suikoden I has no such system.

### Proposed ImGui "Recruitment Radar" Window:
1. **Available Now**: Dynamically queries the current story flag (`event_flag`) and lists all characters whose prerequisites are satisfied, along with their town/dungeon location.
2. **Expiring Soon**: Flags characters with impending point-of-no-return cutoffs (e.g. Leon Silverberg, Clive, Lester).
3. **Hidden / Secret Area Radar**: Shows a radar notification if an unrecruited star is in the active map (e.g., **Crowley** behind the secret wall in Qlon Cave, or **Pesmerga** on the roof of Neclord's Castle).
4. **Force Recruit / Fallback Override**: A debug/accessibility toggle allowing missed stars to be added back to the roster to prevent ruined 50-hour save files.

---

## 5. Travel & Dungeon Mobility

* **Enhanced Blinking Mirror / Portable Viki Teleport**:
  * *Vanilla*: Blinking Mirror only works outdoors on the world map and exclusively warps back to Toran Castle. Escaping dungeons requires using an Escape Talisman.
  * *Patch*:
    * Allow Blinking Mirror inside dungeons to act as an Escape Talisman (evacuate to world map).
    * When on the world map, allow opening Viki's fast-travel destination menu directly without walking back inside the castle.
* **100% Escape / Fodder Auto-Let Go**:
  * *Vanilla*: Fleeing or letting go of trivial low-level enemies can randomly fail.
  * *Patch*: Guarantee 100% success rate when average party level exceeds enemy encounter level by 5+.

---

## 6. Inventory & Item Quality of Life

* **Shared Consumables / Auto-Restock**:
  * *Vanilla*: Characters hold small 8–9 slot personal bags shared between gear and consumables.
  * *Patch*:
    * Automatically restock common medicines (Medicinal Herbs, Mega Medicines) from Rock's Castle Vault into empty party inventory slots upon resting at an inn.
    * Dedicated "Sort Party Inventory" command to eliminate back-and-forth item trading.
* **Virtual Equipment Bags**:
  * Prevent equipped armor, helmets, shields, and accessories from consuming personal item slots.

---

## 7. Economy & Minigames

* **Gaspar Chinchirorin (Dice Game) Uncapped Bets & Fast Rolls**:
  * *Vanilla*: Bet limit is capped at 10,000 potch per roll, requiring dozens of repetitive games to finance weapon sharpening and armor upgrades.
  * *Patch*: Increase max bet to 100,000 or 1,000,000 potch, with fast-forward dice animations.
* **Recruit Catch-up EXP Scaling**:
  * *Vanilla*: Newly recruited combatants join at low levels and frequently get knocked out in a single turn before they can take an action.
  * *Patch*: Set a minimum recruit baseline level (e.g. `HeroLevel - 5`) or grant a portion of battle EXP to non-active castle reserves.

---

## 8. War Battles & Duels

* **Casual War Mode (No Permadeath)**:
  * *Vanilla*: Major war battles use rock-paper-scissors logic with random death rolls that permanently kill Stars of Destiny.
  * *Patch*: Generals and unit leaders retreat with injuries instead of suffering permanent death.
* **War Battle Enemy Move Prediction / Scout Report**:
  * *Vanilla*: Players must guess whether the enemy commander will use Charge, Bow, or Magic.
  * *Patch*: Calculate and display the enemy's move weightings or spy intelligence on the HUD before locking in the player's order.
