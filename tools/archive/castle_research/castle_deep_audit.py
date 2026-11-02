import os, glob, json

MOB_DIR = r"D:\Modding\suikodum\Mobobehaviour"
vk_files = sorted([f for f in glob.glob(os.path.join(MOB_DIR, "vk*.json")) 
                   if not ('_map_' in os.path.basename(f) or len(os.path.basename(f).split('.')[0].split('_')) > 1)])

anomalies = {
    "contradictory_preconditions": [],
    "inverted_bounding_boxes": [],
    "zero_bitmasks": [],
    "out_of_bounds_flags": [],
    "invalid_castle_levels": [],
    "never_spawned_dormant_npcs": [],
    "npcs_at_origin_0_0": [],
    "invalid_warps": [],
    "boss_battles_in_castle": [],
    "tactical_war_battles_in_castle": [],
    "jump_out_of_bounds": [],
    "item_anomalies": []
}

total_scripts = 0
total_objects = 0

for map_path in vk_files:
    map_name = os.path.basename(map_path)
    with open(map_path, 'r', encoding='utf-8', errors='ignore') as f:
        data = json.load(f)
    
    ed = data.get("eventdata", {})
    submaps = ed.get("mapeventdat", [])
    
    for sub_idx, sub in enumerate(submaps):
        objs = sub.get("eventobj", [])
        events = sub.get("eventdat", [])
        
        total_objects += len(objs)
        total_scripts += len(events)
        
        # Track which obj indices are ever manipulated by eventCom
        manipulated_objs = set()
        
        # First scan all eventCom to find object references
        for ev_idx, ev in enumerate(events):
            com = ev.get("eventCom", [])
            i = 0
            while i < len(com):
                b = com[i]
                if b == 254:
                    break
                # Opcode 1: Set Object Display [1, obj_idx, disp_val]
                if b == 1 and i + 2 < len(com):
                    manipulated_objs.add(com[i+1])
                    i += 3
                    continue
                # Opcode 6: Teleport Object [6, obj_idx, x, y]
                if b == 6 and i + 3 < len(com):
                    manipulated_objs.add(com[i+1])
                    i += 4
                    continue
                # Opcode 2: Turn Object [2, obj_idx, dir]
                if b == 2 and i + 2 < len(com):
                    manipulated_objs.add(com[i+1])
                    i += 3
                    continue
                # Opcode 4: Move Object [4, obj_idx, ...]
                if b == 4 and i + 1 < len(com):
                    manipulated_objs.add(com[i+1])
                # Check for Boss Battle in Castle: Opcode 45 or start battle [45, bno, bgm] or similar
                # Check for Tactical War Battle in Castle: Opcode 58 or similar
                # Check for warps: Opcode 8 [8, map, sub, x, y] or 9
                i += 1
        
        # Check objects
        for o_idx, obj in enumerate(objs):
            fpno = obj.get("fpno", 0)
            x = obj.get("x", 0)
            y = obj.get("y", 0)
            disp = obj.get("disp", 0)
            otyp = obj.get("otyp", 0)
            ozok = obj.get("ozok", 0)
            
            # Origin (0,0) NPCs
            if x == 0 and y == 0 and otyp == 1:
                anomalies["npcs_at_origin_0_0"].append({
                    "map": map_name, "submap": sub_idx, "slot": o_idx,
                    "fpno": fpno, "disp": disp, "ozok": ozok,
                    "manipulated": (o_idx in manipulated_objs)
                })
            
            # Dormant NPCs (disp == 0) that are NEVER manipulated by any script in this room!
            if disp == 0 and otyp == 1 and (o_idx not in manipulated_objs):
                anomalies["never_spawned_dormant_npcs"].append({
                    "map": map_name, "submap": sub_idx, "slot": o_idx,
                    "fpno": fpno, "x": x, "y": y, "ozok": ozok
                })
        
        # Check eventForm and eventCom
        for ev_idx, ev in enumerate(events):
            etyp = ev.get("etyp", 0)
            form = ev.get("eventForm", [])
            com = ev.get("eventCom", [])
            
            # 1. Parse eventForm
            i = 0
            flags_set = {}
            flags_clear = {}
            
            while i < len(form):
                op = form[i]
                if op == 254:
                    break
                
                # Opcode 1: Box check [1, x1, x2, y1, y2]
                if op == 1 and i + 4 < len(form):
                    x1, x2, y1, y2 = form[i+1], form[i+2], form[i+3], form[i+4]
                    if x1 > x2 or y1 > y2:
                        anomalies["inverted_bounding_boxes"].append({
                            "map": map_name, "submap": sub_idx, "script": ev_idx,
                            "box": [x1, x2, y1, y2], "raw": form[i:i+5]
                        })
                    i += 5
                    continue
                
                # Opcode 9: eventFlgCHK SET [9, fno, mask]
                if op == 9 and i + 2 < len(form):
                    fno = form[i+1]
                    mask = form[i+2]
                    if fno > 511:
                        anomalies["out_of_bounds_flags"].append({
                            "map": map_name, "submap": sub_idx, "script": ev_idx, "fno": fno, "mask": mask
                        })
                    if mask == 0:
                        anomalies["zero_bitmasks"].append({
                            "map": map_name, "submap": sub_idx, "script": ev_idx, "fno": fno, "type": "SET_CHECK"
                        })
                    flags_set[fno] = flags_set.get(fno, 0) | mask
                    i += 3
                    continue
                
                # Opcode 10: eventFlgCHK CLEAR [10, fno, mask]
                if op == 10 and i + 2 < len(form):
                    fno = form[i+1]
                    mask = form[i+2]
                    if fno > 511:
                        anomalies["out_of_bounds_flags"].append({
                            "map": map_name, "submap": sub_idx, "script": ev_idx, "fno": fno, "mask": mask
                        })
                    if mask == 0:
                        anomalies["zero_bitmasks"].append({
                            "map": map_name, "submap": sub_idx, "script": ev_idx, "fno": fno, "type": "CLEAR_CHECK"
                        })
                    flags_clear[fno] = flags_clear.get(fno, 0) | mask
                    i += 3
                    continue
                
                # Opcode 33: base_lv check [33, op, val]
                if op == 33 and i + 2 < len(form):
                    cmp_op = form[i+1]
                    val = form[i+2]
                    if val > 3 or val < 0:
                        anomalies["invalid_castle_levels"].append({
                            "map": map_name, "submap": sub_idx, "script": ev_idx,
                            "op": cmp_op, "val": val, "raw": form[i:i+3]
                        })
                    i += 3
                    continue
                
                i += 1
            
            # Check for direct flag contradictions in eventForm
            for fno, s_mask in flags_set.items():
                if fno in flags_clear:
                    c_mask = flags_clear[fno]
                    overlap = s_mask & c_mask
                    if overlap != 0:
                        anomalies["contradictory_preconditions"].append({
                            "map": map_name, "submap": sub_idx, "script": ev_idx,
                            "fno": fno, "overlap_mask": overlap,
                            "set_mask": s_mask, "clear_mask": c_mask
                        })
            
            # 2. Parse eventCom
            j = 0
            while j < len(com):
                op = com[j]
                if op == 254:
                    break
                
                # Jump opcode: Opcode 30 [30, offset_lo, offset_hi] or [30, target]
                if op == 30 and j + 1 < len(com):
                    target = com[j+1]
                    if target >= len(com):
                        anomalies["jump_out_of_bounds"].append({
                            "map": map_name, "submap": sub_idx, "script": ev_idx,
                            "target": target, "com_len": len(com)
                        })
                
                j += 1

with open(r"d:\Appz\PKCore\tools\castle_all_anomalies.json", "w", encoding="utf-8") as out:
    json.dump(anomalies, out, indent=2)

print(f"Total Objects in Castle: {total_objects}")
print(f"Total Scripts in Castle: {total_scripts}")
print(f"Contradictory Preconditions (Dead Code): {len(anomalies['contradictory_preconditions'])}")
print(f"Inverted Bounding Boxes (Un-triggerable): {len(anomalies['inverted_bounding_boxes'])}")
print(f"Zero Bitmasks (Buggy Declarations): {len(anomalies['zero_bitmasks'])}")
print(f"Out of Bounds Flags (> 511): {len(anomalies['out_of_bounds_flags'])}")
print(f"Invalid Castle Levels (base_lv > 3): {len(anomalies['invalid_castle_levels'])}")
print(f"Dormant NPCs Never Spawned by Map: {len(anomalies['never_spawned_dormant_npcs'])}")
print(f"NPCs Stranded at Origin (0,0): {len(anomalies['npcs_at_origin_0_0'])}")
print(f"Jumps Out of Bounds: {len(anomalies['jump_out_of_bounds'])}")

