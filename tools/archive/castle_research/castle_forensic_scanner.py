import os, glob, json

MOB_DIR = r"D:\Modding\suikodum\Mobobehaviour"
DOC_DIR = r"D:\Appz\PKCore\Documentation\areas"

# Target character IDs:
# 5: Sheena (SEE)
# 24: Milie (MIL)
# 83: Milie Sans Bonapart (MI2)
# 84: Bonaparte (BAK2)
# fpno: 5, 24, 83

vk_files = sorted([f for f in glob.glob(os.path.join(MOB_DIR, "vk*.json")) 
                   if not ('_map_' in os.path.basename(f) or len(os.path.basename(f).split('.')[0].split('_')) > 1)])

results = {
    "sheena_entities": [],
    "millie_entities": [],
    "bonaparte_entities": [],
    "all_entities": [],
    "contradictory_flags": [],
    "out_of_bounds_flags": [],
    "invalid_bitmasks": [],
    "castle_level_checks": [],
    "sheena_scripts": [],
    "millie_scripts": [],
    "bonaparte_scripts": [],
    "total_scripts": 0,
    "total_objects": 0,
}

for map_path in vk_files:
    map_name = os.path.basename(map_path)
    with open(map_path, 'r', encoding='utf-8', errors='ignore') as f:
        data = json.load(f)
    
    ed = data.get("eventdata", {})
    submaps = ed.get("mapeventdat", [])
    
    for sub_idx, sub in enumerate(submaps):
        objs = sub.get("eventobj", [])
        forms = sub.get("eventForm", [])
        coms = sub.get("eventCom", [])
        
        results["total_objects"] += len(objs)
        results["total_scripts"] += len(forms)
        
        # 1. Entity Scan
        for o_idx, obj in enumerate(objs):
            fpno = obj.get("fpno", 0)
            otyp = obj.get("otyp", 0)
            x = obj.get("x", 0)
            y = obj.get("y", 0)
            ano = obj.get("ano", 0)
            disp = obj.get("disp", 0)
            ozok = obj.get("ozok", 0)
            spd = obj.get("spd", 0)
            wt = obj.get("wt", 0)
            
            entry = {
                "map": map_name,
                "submap": sub_idx,
                "slot": o_idx,
                "fpno": fpno,
                "otyp": otyp,
                "x": x, "y": y,
                "ano": ano,
                "disp": disp,
                "ozok": ozok,
                "spd": spd,
                "wt": wt
            }
            
            if fpno in (5,):
                results["sheena_entities"].append(entry)
            if fpno in (24, 83):
                if fpno == 24:
                    results["millie_entities"].append(entry)
                elif fpno == 83:
                    results["bonaparte_entities"].append(entry)
        
        # 2. Preconditions Scan (eventForm)
        for s_idx, form in enumerate(forms):
            # eventForm is an array of opcodes
            # Scan for opcodes:
            # Opcode 9: eventFlgCHK(fno, bno) -> [9, fno_lo, fno_hi, mask] or [9, fno, mask]
            # Opcode 10: eventFlgCLEAR(fno, mask)
            # Opcode 33: base_lv check -> [33, op, val]
            i = 0
            seen_flags_set = {}
            seen_flags_clear = {}
            
            while i < len(form):
                op = form[i]
                if op == 254: # End of script
                    break
                
                # Check for base_lv opcodes
                if op == 33 and i + 2 < len(form):
                    cmp_op = form[i+1]
                    val = form[i+2]
                    results["castle_level_checks"].append({
                        "map": map_name, "submap": sub_idx, "script": s_idx,
                        "op": cmp_op, "val": val, "raw": form[i:i+3]
                    })
                    if val > 3 or val < 0:
                        results["castle_level_checks"][-1]["anomaly"] = "Invalid base_lv value (> 3 or < 0)"
                    i += 3
                    continue
                
                # Event flag SET check (Opcode 9 / 0x09)
                if op == 9 and i + 2 < len(form):
                    fno = form[i+1]
                    mask = form[i+2]
                    if fno > 511:
                        results["out_of_bounds_flags"].append({
                            "map": map_name, "submap": sub_idx, "script": s_idx,
                            "type": "SET_CHECK", "fno": fno, "mask": mask
                        })
                    if mask == 0:
                        results["invalid_bitmasks"].append({
                            "map": map_name, "submap": sub_idx, "script": s_idx,
                            "fno": fno, "mask": mask, "type": "ZERO_MASK"
                        })
                    seen_flags_set[fno] = seen_flags_set.get(fno, 0) | mask
                    i += 3
                    continue
                
                # Event flag CLEAR check (Opcode 10 / 0x0A)
                if op == 10 and i + 2 < len(form):
                    fno = form[i+1]
                    mask = form[i+2]
                    if fno > 511:
                        results["out_of_bounds_flags"].append({
                            "map": map_name, "submap": sub_idx, "script": s_idx,
                            "type": "CLEAR_CHECK", "fno": fno, "mask": mask
                        })
                    if mask == 0:
                        results["invalid_bitmasks"].append({
                            "map": map_name, "submap": sub_idx, "script": s_idx,
                            "fno": fno, "mask": mask, "type": "ZERO_MASK"
                        })
                    seen_flags_clear[fno] = seen_flags_clear.get(fno, 0) | mask
                    i += 3
                    continue
                
                i += 1
            
            # Check for direct contradictions (SET and CLEAR for same bit in same script)
            for fno, s_mask in seen_flags_set.items():
                if fno in seen_flags_clear:
                    c_mask = seen_flags_clear[fno]
                    overlap = s_mask & c_mask
                    if overlap != 0:
                        results["contradictory_flags"].append({
                            "map": map_name, "submap": sub_idx, "script": s_idx,
                            "fno": fno, "overlap_mask": overlap,
                            "set_mask": s_mask, "clear_mask": c_mask
                        })
        
        # 3. Action Sequence Scan (eventCom)
        for s_idx, com in enumerate(coms):
            # Check if Sheena (5), Millie (24/83), or Bonaparte (84) are referenced in com
            # Opcode 39: Dismiss character -> [39, chara_id]
            # Opcode 47: Recruit party -> [47, chara_id, ...]
            # Opcode 54: Recruit character -> [54, chara_id, ...]
            # Scan array for byte sequences
            for i in range(len(com)):
                b = com[i]
                if b == 39 and i + 1 < len(com):
                    cid = com[i+1]
                    if cid == 5:
                        results["sheena_scripts"].append({"map": map_name, "submap": sub_idx, "script": s_idx, "action": "Dismiss Sheena (39, 5)", "raw": com[max(0, i-2):min(len(com), i+6)]})
                    elif cid in (24, 83):
                        results["millie_scripts"].append({"map": map_name, "submap": sub_idx, "script": s_idx, "action": f"Dismiss Millie ID {cid} (39, {cid})", "raw": com[max(0, i-2):min(len(com), i+6)]})
                    elif cid == 84:
                        results["bonaparte_scripts"].append({"map": map_name, "submap": sub_idx, "script": s_idx, "action": "Dismiss Bonaparte (39, 84)", "raw": com[max(0, i-2):min(len(com), i+6)]})
                elif b in (47, 54) and i + 1 < len(com):
                    cid = com[i+1]
                    if cid == 5:
                        results["sheena_scripts"].append({"map": map_name, "submap": sub_idx, "script": s_idx, "action": f"Recruit Sheena ({b}, 5)", "raw": com[max(0, i-2):min(len(com), i+6)]})
                    elif cid in (24, 83):
                        results["millie_scripts"].append({"map": map_name, "submap": sub_idx, "script": s_idx, "action": f"Recruit Millie ID {cid} ({b}, {cid})", "raw": com[max(0, i-2):min(len(com), i+6)]})
                    elif cid == 84:
                        results["bonaparte_scripts"].append({"map": map_name, "submap": sub_idx, "script": s_idx, "action": f"Recruit Bonaparte ({b}, 84)", "raw": com[max(0, i-2):min(len(com), i+6)]})

with open(r"d:\Appz\PKCore\tools\castle_forensic_results.json", "w", encoding="utf-8") as out:
    json.dump(results, out, indent=2)

print("Forensic scan complete!")
print(f"Total Objects Analyzed: {results['total_objects']}")
print(f"Total Scripts Analyzed: {results['total_scripts']}")
print(f"Sheena Entities Found: {len(results['sheena_entities'])}")
print(f"Millie Entities Found: {len(results['millie_entities'])}")
print(f"Bonaparte Entities Found: {len(results['bonaparte_entities'])}")
print(f"Contradictory / Dead Code Scripts: {len(results['contradictory_flags'])}")
print(f"Out of Bounds Flags (> 511): {len(results['out_of_bounds_flags'])}")
print(f"Invalid / Zero Bitmasks: {len(results['invalid_bitmasks'])}")
print(f"Castle Level (base_lv) Checks: {len(results['castle_level_checks'])}")
print(f"Sheena Action Bytecode Matches: {len(results['sheena_scripts'])}")
print(f"Millie Action Bytecode Matches: {len(results['millie_scripts'])}")
print(f"Bonaparte Action Bytecode Matches: {len(results['bonaparte_scripts'])}")

