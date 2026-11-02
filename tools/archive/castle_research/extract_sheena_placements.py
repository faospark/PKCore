import os, glob, json

MOB_DIR = r"D:\Modding\suikodum\Mobobehaviour"
vk_files = sorted([f for f in glob.glob(os.path.join(MOB_DIR, "vk*.json")) 
                   if not ('_map_' in os.path.basename(f) or len(os.path.basename(f).split('.')[0].split('_')) > 1)])

sheena_placements = []

for map_path in vk_files:
    map_name = os.path.basename(map_path)
    with open(map_path, 'r', encoding='utf-8', errors='ignore') as f:
        data = json.load(f)
    
    ed = data.get("eventdata", {})
    submaps = ed.get("mapeventdat", [])
    
    for sub_idx, sub in enumerate(submaps):
        objs = sub.get("eventobj", [])
        events = sub.get("eventdat", [])
        
        for o_idx, obj in enumerate(objs):
            fpno = obj.get("fpno", 0)
            if fpno == 5: # Sheena sprite pattern
                # Find all scripts that manipulate or interact with this specific object slot
                associated_scripts = []
                for ev_idx, ev in enumerate(events):
                    form = ev.get("eventForm", [])
                    com = ev.get("eventCom", [])
                    etyp = ev.get("etyp", 0)
                    
                    # Check if eventForm checks interaction with this object (e.g. op 31 or op 48/71)
                    # Or if eventCom manipulates this obj index (e.g. [89, o_idx], [90, o_idx], [101, o_idx])
                    manipulates = False
                    interacts = False
                    
                    # Check com
                    i = 0
                    while i < len(com):
                        op = com[i]
                        if op == 254: break
                        if op in (89, 90, 101, 103, 104, 105, 106) and i + 1 < len(com):
                            if com[i+1] == o_idx:
                                manipulates = True
                        i += 1
                    
                    # Check form
                    j = 0
                    while j < len(form):
                        op = form[j]
                        if op == 254: break
                        # Opcode for target inspected object
                        if op == 48 and j + 1 < len(form):
                            if form[j+1] == o_idx:
                                interacts = True
                        j += 1
                    
                    if manipulates or interacts:
                        associated_scripts.append({
                            "script_idx": ev_idx,
                            "etyp": etyp,
                            "manipulates": manipulates,
                            "interacts": interacts,
                            "form": form,
                            "com": com
                        })
                
                sheena_placements.append({
                    "map": map_name,
                    "submap": sub_idx,
                    "slot": o_idx,
                    "coords": (obj.get("x", 0), obj.get("y", 0)),
                    "ano": obj.get("ano", 0),
                    "disp": obj.get("disp", 0),
                    "ozok": obj.get("ozok", 0),
                    "spd": obj.get("spd", 0),
                    "wt": obj.get("wt", 0),
                    "scripts": associated_scripts
                })

with open(r"d:\Appz\PKCore\tools\sheena_forensic_results.json", "w", encoding="utf-8") as out:
    json.dump(sheena_placements, out, indent=2)

print(f"Total Sheena Entity Placements: {len(sheena_placements)}")
for p in sheena_placements:
    print(f"Map {p['map']} Sub {p['submap']} Slot obj[{p['slot']:02d}]: Coords={p['coords']} Facing={p['ano']} InitialDisp={p['disp']} ScriptsLinked={len(p['scripts'])}")
