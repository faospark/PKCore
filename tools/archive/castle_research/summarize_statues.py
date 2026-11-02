import json
data = json.load(open(r'd:\Appz\PKCore\tools\statues_accurate_table.json', encoding='utf-8'))

print("=== 4 PURE STATUES ===")
for d in data:
    if d['head'] == d['body'] == d['legs'] == d['tail']:
        print(f"[{d['hex']}] {d['combo']}: {d['rewards']}")

print("\n=== HAMMER COMBOS ===")
for d in data:
    for r in d['rewards']:
        if 'hammer' in r.lower():
            print(f"[{d['hex']}] {d['combo']}: {d['rewards']}")

print("\n=== STAT STONE COMBOS ===")
for d in data:
    for r in d['rewards']:
        if 'stone of' in r.lower():
            print(f"[{d['hex']}] {d['combo']}: {d['rewards']}")

print("\n=== RECIPE COMBOS ===")
for d in data:
    for r in d['rewards']:
        if 'recipe' in r.lower():
            print(f"[{d['hex']}] {d['combo']}: {d['rewards']}")

print("\n=== TOP POTCH COMBOS ===")
potch_combos = []
for d in data:
    for r in d['rewards']:
        if 'potch' in r.lower():
            val = int(r.split(' ')[0].replace(',', ''))
            potch_combos.append((val, d['hex'], d['combo'], r))
for val, h, combo, r in sorted(potch_combos, reverse=True)[:10]:
    print(f"[{h}] {combo}: {r}")

print("\n=== 19 EMPTY DUDS ===")
for d in data:
    if not d['rewards']:
        print(f"[{d['hex']}] {d['combo']}")

