import json

data = json.load(open(r'd:\Appz\PKCore\tools\castle_all_anomalies.json'))

print("=== 1. CONTRADICTORY PRECONDITIONS (MATHEMATICALLY DEAD CODE) ===")
for x in data['contradictory_preconditions']:
    print(f"Map {x['map']} Submap {x['submap']} Script ev[{x['script']}]: Flag byte #{x['fno']} requires SET (mask {x['set_mask']}) AND CLEAR (mask {x['clear_mask']}) -> Overlapping mask {x['overlap_mask']}")

print("\n=== 2. ZERO BITMASKS (ALWAYS-FALSE CHECKS) ===")
for x in data['zero_bitmasks']:
    print(f"Map {x['map']} Submap {x['submap']} Script ev[{x['script']}]: Flag byte #{x['fno']} checked against mask 0 ({x['type']})")

print("\n=== 3. CASTLE LEVEL OUT-OF-RANGE CHECKS (base_lv) ===")
lv_counts = {}
for x in data['invalid_castle_levels']:
    v = x.get('val')
    lv_counts[v] = lv_counts.get(v, 0) + 1
print("base_lv checked value distribution:", lv_counts)
print("Sample of base_lv == 4 checks (Level 5 check where max is 3):")
for x in [item for item in data['invalid_castle_levels'] if item['val'] == 4][:8]:
    print(f"  Map {x['map']} Submap {x['submap']} ev[{x['script']}]: raw={x['raw']} (op={x['op']}, val={x['val']})")

print(f"\n=== 4. DORMANCY ANOMALIES (Total: {len(data['never_spawned_dormant_npcs'])} NPCs) ===")
print("NPCs marked disp=0 (dormant/hidden) that NO SCRIPT in their room ever enables (disp=1) or teleports:")
dormant_by_map = {}
for x in data['never_spawned_dormant_npcs']:
    m = x['map']
    dormant_by_map[m] = dormant_by_map.get(m, 0) + 1
for m, cnt in sorted(dormant_by_map.items()):
    print(f"  {m}: {cnt} orphaned dormant NPCs")

print(f"\n=== 5. ORIGIN STRANDED ACTORS (Total: {len(data['npcs_at_origin_0_0'])} NPCs at (0,0)) ===")
stranded_unmanipulated = [x for x in data['npcs_at_origin_0_0'] if not x['manipulated']]
print(f"Of {len(data['npcs_at_origin_0_0'])} NPCs initialized at coordinate (0,0), {len(stranded_unmanipulated)} are NEVER manipulated by ANY script in their room (dead entity entries)!")
origin_by_map = {}
for x in stranded_unmanipulated:
    m = x['map']
    origin_by_map[m] = origin_by_map.get(m, 0) + 1
for m, cnt in sorted(origin_by_map.items()):
    print(f"  {m}: {cnt} stranded (0,0) dead actors")

