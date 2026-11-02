import json, sqlite3

conn = sqlite3.connect(r'd:\Appz\PKCore\tools\symbol_indexer\symbols.db')
c = conn.cursor()
entities_dict = {}
for row in c.execute("SELECT id, name, category, internal_symbol FROM game_entities WHERE category='character'").fetchall():
    entities_dict[row[0]] = (row[1], row[3])

MOB_DIR = r"D:\Modding\suikodum\Mobobehaviour"

sheena_spots = [
    ("vk28.json", 0, 9, 77, 125, "Castle Entrance / Outer Walkway"),
    ("vk26.json", 0, 24, 22, 32, "Living Quarters Balcony / Garden"),
    ("vk18.json", 0, 2, 25, 38, "Dojo & Training Grounds"),
    ("vk12.json", 1, 2, 67, 28, "Infirmary / Clinic"),
    ("vk07.json", 3, 14, 67, 47, "Workshop / Library"),
    ("vk02.json", 9, 14, 43, 45, "Vault / Detective"),
    ("vk09.json", 1, 3, 47, 26, "Sanctuary / Castle Grounds"),
    ("vk01.json", 0, 7, 55, 124, "Great Hall / War Room (Tier 2)"),
    ("vk01.json", 1, 7, 55, 124, "Great Hall / War Room (Tier 3)"),
    ("vk01.json", 2, 5, 55, 124, "Great Hall / War Room (Tier 4)")
]

print("=== FORENSIC ANALYSIS OF SHEENA'S CASTLE SPOTS & ADJACENT NPCS ===")

for map_file, sub_idx, s_slot, sx, sy, desc in sheena_spots:
    with open(f"{MOB_DIR}\\{map_file}", 'r', encoding='utf-8', errors='ignore') as f:
        m = json.load(f)
    sub = m['eventdata']['mapeventdat'][sub_idx]
    objs = sub['eventobj']
    
    # Find all objects within distance <= 10 tiles of Sheena
    nearby = []
    for idx, o in enumerate(objs):
        if idx == s_slot: continue
        ox, oy = o.get('x', 0), o.get('y', 0)
        dist = abs(ox - sx) + abs(oy - sy)
        if dist <= 12 and o.get('otyp', 0) == 1: # NPC
            char_info = entities_dict.get(o.get('fpno', 0), (f"Sprite #{o.get('fpno', 0)}", "UNKNOWN"))
            nearby.append((idx, char_info[0], o.get('fpno', 0), ox, oy, dist))
    
    print(f"\n[{map_file} Sub {sub_idx}] {desc} (Sheena at {sx},{sy}):")
    if nearby:
        for idx, name, fp, ox, oy, dist in sorted(nearby, key=lambda x: x[5]):
            print(f"  Adjacent NPC: obj[{idx:02d}] {name} (fpno={fp}) at ({ox},{oy}) [dist={dist} tiles]")
    else:
        print("  No adjacent NPCs within 12 tiles.")
