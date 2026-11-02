import os, glob, json

MOB_DIR = r"D:\Modding\suikodum\Mobobehaviour"
vk_files = sorted([f for f in glob.glob(os.path.join(MOB_DIR, "vk*.json")) 
                   if not ('_map_' in os.path.basename(f) or len(os.path.basename(f).split('.')[0].split('_')) > 1)])

results = []

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
            i = 0
            while i < len(form):
                op = form[i]
                if op == 254:
                    break
                if op == 33 and i + 2 < len(form):
                    cmp_op = form[i+1]
                    val = form[i+2]
                    if val not in [0, 1, 2, 3, 4]:
                        results.append({
                            'map': map_name,
                            'submap': sub_idx,
                            'script': ev_idx,
                            'cmp_op': cmp_op,
                            'val': val,
                            'raw_form': form,
                            'raw_com': ev.get('eventCom', [])
                        })
                    i += 3
                    continue
                # Handle bounding box or flag skips if known
                if op == 1 and i + 4 < len(form):
                    i += 5
                    continue
                if op in [9, 10] and i + 2 < len(form):
                    i += 3
                    continue
                i += 1

print(f"Found {len(results)} weird base_lv checks!")
for r in results[:20]:
    print(f"Map {r['map']} Sub {r['submap']} ev[{r['script']}]: cmp_op={r['cmp_op']}, val={r['val']}")
    print(f"   Form: {r['raw_form']}")
    print(f"   Com:  {r['raw_com'][:10]}")
