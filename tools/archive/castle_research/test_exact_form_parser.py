import os, glob, json

OP_LENGTHS = {
    0: 1, 1: 2, 2: 2, 3: 2, 4: 2, 5: 1, 6: 1, 7: 1, 8: 1, 9: 1,
    10: 1, 11: 1, 12: 1, 13: 1, 14: 1, 15: 1, 16: 2, 17: 0, 18: 2, 19: 1,
    20: 1, 21: 1, 22: 1, 23: 2, 24: 2, 25: 1, 26: 5, 27: 2, 28: 2, 29: 2,
    30: 2, 31: 2, 32: 2, 33: 2, 34: 2, 35: 2, 36: 2, 37: 5, 38: 2, 39: 2,
    40: 2, 41: 0
}

MOB_DIR = r"D:\Modding\suikodum\Mobobehaviour"
vk_files = sorted([f for f in glob.glob(os.path.join(MOB_DIR, "vk*.json")) 
                   if not ('_map_' in os.path.basename(f) or len(os.path.basename(f).split('.')[0].split('_')) > 1)])

parse_errors = []
total_parsed = 0

for map_path in vk_files:
    map_name = os.path.basename(map_path)
    with open(map_path, 'r', encoding='utf-8', errors='ignore') as f:
        data = json.load(f)
    ed = data.get("eventdata", {})
    submaps = ed.get("mapeventdat", [])
    
    for sub_idx, sub in enumerate(submaps):
        events = sub.get("eventdat", [])
        for ev_idx, ev in enumerate(events):
            form = ev.get("eventForm", [])
            total_parsed += 1
            i = 0
            while i < len(form):
                b = form[i]
                if b == 254: # Terminator
                    break
                if b == 255:
                    i += 1
                    continue
                if b not in OP_LENGTHS:
                    parse_errors.append({
                        'map': map_name, 'sub': sub_idx, 'ev': ev_idx,
                        'pos': i, 'unknown_op': b, 'form': form
                    })
                    break
                i += 1 + OP_LENGTHS[b]

print(f"Total eventForm scripts scanned: {total_parsed}")
print(f"Parse errors: {len(parse_errors)}")
if parse_errors:
    print("Errors:", parse_errors)
