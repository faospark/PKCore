import json

with open(r'd:\Appz\PKCore\tools\statues_full_table.json', 'r', encoding='utf-8') as f:
    data = json.load(f)

print(f"Total entries: {len(data)}")

# Categorize
stat_stones = {21: "Power", 22: "Magic", 23: "Defense", 24: "Magic-Defense", 25: "Dexterity", 26: "Speed", 27: "Luck"}
recipes = {}
hammers = {48: "Copper", 49: "Silver", 50: "Gold"}
story_items = {29: "Blinking Mirror", 35: "Suiko Map", 42: "Wooden Amulet", 45: "Highland Uniform", 55: "Listening Crystal", 73: "Leon's Letter", 74: "Entry Permit", 80: "Secret Writings"}
bath_items = {31: "Chick (Bath Set)", 75: "Bath Set"}
pure_statues = []
empty_statues = []
stone_statues = []
recipe_statues = []
hammer_statues = []
story_statues = []

for s in data:
    idx = s['index']
    hex_str = s['hex']
    combo = s['combo']
    itms = s['item_ids']
    names = s['item_names']
    
    if s['head'] == s['body'] == s['legs'] == s['tail']:
        pure_statues.append(s)
    
    if not itms:
        empty_statues.append(s)
        
    for it in itms:
        if it in stat_stones:
            stone_statues.append((s, stat_stones[it]))
        if 56 <= it <= 71:
            recipe_statues.append((s, it))
        if it in hammers:
            hammer_statues.append((s, hammers[it]))
        if it in story_items:
            story_statues.append((s, story_items[it]))

print(f"Pure statues: {len(pure_statues)}")
print(f"Empty duds: {len(empty_statues)}")
print(f"Stat stone combos: {len(stone_statues)}")
print(f"Recipe combos: {len(recipe_statues)}")
print(f"Hammer combos: {len(hammer_statues)}")
print(f"Story item combos: {len(story_statues)}")

# Let's inspect hammers
print("\n--- HAMMER COMBOS ---")
for s, h in hammer_statues:
    print(f"[{s['hex']}] {s['combo']} -> {h} Hammer ({s['item_names']})")

print("\n--- STORY ITEM COMBOS ---")
for s, st in story_statues:
    print(f"[{s['hex']}] {s['combo']} -> {st} ({s['item_names']})")

print("\n--- STAT STONE COMBOS ---")
for s, st in stone_statues:
    print(f"[{s['hex']}] {s['combo']} -> Stone of {st} ({s['item_names']})")
import json

with open(r'd:\Appz\PKCore\tools\statues_full_table.json', 'r', encoding='utf-8') as f:
    data = json.load(f)

print("=== 19 EMPTY STATUE DUDS ===")
for s in data:
    if not s['item_ids']:
        print(f"[{s['hex']}] {s['combo']}")

print("\n=== RECIPE STATUES ===")
for s in data:
    for it in s['item_ids']:
        if 56 <= it <= 71:
            print(f"[{s['hex']}] {s['combo']} -> {s['item_names']}")

