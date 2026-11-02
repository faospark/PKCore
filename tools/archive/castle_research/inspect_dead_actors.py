import json, sqlite3

data = json.load(open(r'd:\Appz\PKCore\tools\castle_all_anomalies.json'))
conn = sqlite3.connect(r'd:\Appz\PKCore\tools\symbol_indexer\symbols.db')
c = conn.cursor()

entities_dict = {}
for row in c.execute("SELECT id, name, category, internal_symbol FROM game_entities WHERE category='character'").fetchall():
    entities_dict[row[0]] = (row[1], row[3])

print("=== INSPECTING STRANDED (0,0) DEAD ACTORS (103 ACTORS) ===")
stranded_unmanipulated = [x for x in data['npcs_at_origin_0_0'] if not x['manipulated']]

seen_actors = {}
for x in stranded_unmanipulated:
    fp = x['fpno']
    name = entities_dict.get(fp, (f"Sprite Pattern #{fp}", "UNKNOWN"))[0]
    seen_actors[fp] = seen_actors.get(fp, 0) + 1

for fp, cnt in sorted(seen_actors.items(), key=lambda item: -item[1])[:20]:
    char_info = entities_dict.get(fp, (f"Sprite #{fp}", "UNKNOWN"))
    print(f"  fpno {fp:3d} ({char_info[0]} / {char_info[1]}): {cnt} stranded instances at (0,0)")

print("\n=== SAMPLE OF DEAD ACTOR RECORDS ===")
for x in stranded_unmanipulated[:10]:
    char_info = entities_dict.get(x['fpno'], (f"Sprite #{x['fpno']}", "UNKNOWN"))
    print(f"  Map {x['map']} Submap {x['submap']} Slot obj[{x['slot']:02d}]: {char_info[0]} (fpno={x['fpno']}, ozok={x['ozok']}, disp={x['disp']})")

