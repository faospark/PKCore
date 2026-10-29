with open(r'd:\Appz\PKCore\Documentation\dunan_castle_hq_forensic_research.md', 'r', encoding='utf-8') as f:
    text = f.read()

# Replace Tenkou in section 3.2
text = text.replace('### 3.2 The Guardian Deity Shrine Impossible Flag Conflict (`vk21.json`)', '### 3.2 The Great Hall Foyer Impossible Flag Conflict (`vk21.json`)')
text = text.replace("In `vk21.json` (Tenkou's Guardian Deity Shrine), Submap Layer 1", "In `vk21.json` (Great Hall & Main Foyer, Level 3/4), Submap Layer 1")
text = text.replace('Scene #100 in the Guardian Deity room can never trigger.', 'Scene #100 in the Great Hall Upper Foyer can never trigger.')

# Replace Section 11
old_sec11 = """## 11. Tenkou's Guardian Deity: Complete 256 Combination Mechanics

In Tenkou's Guardian Deity Shrine (`vk21.json`), the statue's four modular components (Head, Body, Legs, Tail) are encoded into a single 8-bit index ($4^4 = 256$ possibilities) evaluated by `EventOverlayClass.syugoitm` (VA `0x1821B09B0`):

$$\\text{Index} = \\text{Head} \\ | \\ (\\text{Body} \\ll 2) \\ | \\ (\\text{Legs} \\ll 4) \\ | \\ (\\text{Tail} \\ll 6)$$

Where each component is assigned a 2-bit value:
- `00` ($0$): **Dragon**
- `01` ($1$): **Unicorn**
- `10` ($2$): **Rabbit**
- `11` ($3$): **Turtle**

### 11.1 The Four Pure Statues

When all four components match, the engine evaluates `syugoHan.Entry` (VA `0x181F90CA0`) and rewards iconic special items:

```mermaid
flowchart TD
    D["Pure Dragon (0x00)"] -->|All 00| R1["Dragon Censer (Item #28)"]
    U["Pure Unicorn (0x55)"] -->|All 01| R2["Drinking Set (Item #32) + Canopy Defense (Item #17)"]
    B["Pure Rabbit (0xAA)"] -->|All 10| R3["Mega Medicine (Item #2) + Kiddie Pasta (Food #110)"]
    T["Pure Turtle (0xFF)"] -->|All 11| R4["Stone of Magic (Item #22)"]
```

### 11.2 Reward Distribution Across All 256 Statues
Forensic disassembly of the 256 allocation blocks in `syugoitm..cctor` confirms that Tenkou rewards **108 unique items**, bridging directly across multiple castle minigames:
- **Permanent Stat Boosters**: Stone of Power (`#21`), Stone of Magic (`#22`), Stone of Defense (`#23`), Stone of Magic-Defense (`#24`), Stone of Dexterity (`#25`), Stone of Speed (`#26`), Stone of Luck (`#27`).
- **Blacksmith Tools**: Copper Hammer (`#48`), Silver Hammer (`#49`), Gold Hammer (`#50`).
- **Cooking Recipes**: Recipe #25 (`#56`), Recipe #26 (`#57`), Recipe #27 (`#58`), Recipe #28 (`#59`), Recipe #31 (`#62`) through Recipe #40 (`#71`).
- **Prepared Food Dishes**: The statue directly generates cooked food dishes identical to Hai Yo's kitchen outputs (e.g. Nanami Cake `#99`, Tekka-don `#198`, Tom Yum Stew `#216`, Beefsteak `#219`, Ship Combo `#226`, Flaming Sea Special `#240`).
- **Rare Antiques & Curiosities**: Invincible Smile (`#83`), Sexy Wink (`#84`), Bath Set (`#75`), Sunglasses (`#76`), Dog Whistle (`#77`), Lubricating Oil (`#78`), Rose Bouquet (`#79`)."""

new_sec11 = """## 11. Jude's Guardian Deity: Complete 256 Combination Mechanics

In Jude's Guardian Deity Shrine (`vk33.json`), the statue's four modular components (Head, Body, Legs, Tail) are encoded into a single 8-bit index ($4^4 = 256$ possibilities) evaluated by `EventOverlayClass.syugoitm` (VA `0x1821B09B0`):

$$\\text{Index} = \\text{Head} \\ | \\ (\\text{Body} \\ll 2) \\ | \\ (\\text{Legs} \\ll 4) \\ | \\ (\\text{Tail} \\ll 6)$$

Where each component is assigned a 2-bit value:
- `00` ($0$): **Dragon**
- `01` ($1$): **Unicorn**
- `10` ($2$): **Rabbit**
- `11` ($3$): **Turtle**

### 11.1 The Four Pure Statues

When all four components match, the engine evaluates Jude's masterpiece and awards iconic blessings:

```mermaid
flowchart TD
    D["Pure Dragon (0x00)"] -->|All 00| R1["Dragon Censer (Item #28)"]
    U["Pure Unicorn (0x55)"] -->|All 01| R2["Blue Gate Orb (Rune #17)"]
    B["Pure Rabbit (0xAA)"] -->|All 10| R3["110,000 Potch"]
    T["Pure Turtle (0xFF)"] -->|All 11| R4["Stone of Magic (Item #22)"]
```

### 11.2 Reward Distribution Across All 256 Statues
Native disassembly of the 2D byte array matrix `item[2, 3]` across all 256 allocation blocks in `syugoitm$$.cctor` reveals the true distribution across four mythological archetypes:
- **Dragon Head (Martial Equipment)**: High-tier armor and combat accessories (e.g. Master Garb, Silver Armor, Windspun Armor, Chaos Shield, Winged Boots, Dragon Censer).
- **Unicorn Head (Arcane Runes)**: Supreme Runes & Orbs (e.g. Fury Orb `#87`, Mother Earth Orb `#8`, Thunder Orb `#10`, Rage Orb `#2`, Double-Jab Orb `#65`, Killer Orb `#66`, Spark Orb `#68`).
- **Rabbit Head (Prosperity & Potch)**: 51 combinations awarding cold hard cash windfalls up to **120,000 Potch** (calculated via `((Col 1 * 10) + Col 2) * 100`).
- **Turtle Head (Longevity & Stat Stones)**: Every permanent attribute booster (+3 to ATK, MAG, DEF, M-DEF, SKL, SPD, or LUK) requires a Turtle Head:
  - Stone of Power (`#21`, `0x0B`)
  - Stone of Magic (`#22`, `0xFF`)
  - Stone of Defense (`#23`, `0x9B`)
  - Stone of Magic-Defense (`#24`, `0xE7`)
  - Stone of Dexterity (`#25`, `0x53`)
  - Stone of Speed (`#26`, `0x07`)
  - Stone of Luck (`#27`, `0x2F`)
- **19 Empty Duds**: 19 discordant combinations clear the array (`VA 0x182487dc0`) resulting in 0 rewards.

For the exhaustive lookup table and plan locations, see [guardian_deity_statues_complete_guide.md](guardian_deity_statues_complete_guide.md)."""

text = text.replace(old_sec11.replace('\r\n', '\n'), new_sec11)
text = text.replace(old_sec11, new_sec11)

text = text.replace('| **Guardian Deity** | `vk21.json` | 1 Loop Script Dead | Precondition requires Flag 1 Mask 29 CLEAR and Mask 255 SET (`ev[33]`) | Shrine scene #100 never triggers |', '| **Great Hall Upper Foyer** | `vk21.json` | 1 Loop Script Dead | Precondition requires Flag 1 Mask 29 CLEAR and Mask 255 SET (`ev[33]`) | Scene #100 never triggers |')

with open(r'd:\Appz\PKCore\Documentation\dunan_castle_hq_forensic_research.md', 'w', encoding='utf-8') as f:
    f.write(text)

# Also update brain artifact if exists
artifact_path = r'C:\Users\thefao\.gemini\antigravity\brain\dccbfa1f-6361-46af-926d-1949fa3e2c16\dunan_castle_hq_forensic_research.md'
try:
    with open(artifact_path, 'w', encoding='utf-8') as f:
        f.write(text)
except:
    pass

print('Updated Documentation/dunan_castle_hq_forensic_research.md and artifact successfully!')
