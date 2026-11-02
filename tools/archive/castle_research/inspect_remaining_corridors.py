import json, glob, os

vks = ['vk25', 'vk26', 'vk27', 'vk28', 'vk30', 'vk35', 'vk36', 'vk37']
for vk in vks:
    path = f"D:/Modding/suikodum/Mobobehaviour/{vk}.json"
    if not os.path.exists(path):
        continue
    with open(path, 'r', encoding='utf-8') as f:
        d = json.load(f)
    ed = d.get('eventdata', {})
    meds = ed.get('mapeventdat', [])
    msgs = ed.get('sce_msg', [])
    print(f"=== {vk} ===")
    print(f"  map count: {len(d.get('map', []))}, epersondat count: {len(d.get('epersondat', []))}")
    print(f"  submaps in mapeventdat: {len(meds)}, Total sce_msg: {len(msgs)}")
    for idx, sm in enumerate(meds):
        objs = sm.get('eventobj', [])
        evs = sm.get('eventForm', [])
        fpnos = [o.get('fpno') for o in objs if 'fpno' in o]
        print(f"    Submap {idx}: {len(objs)} objects (fpnos: {set(fpnos)}), {len(evs)} scripts")
