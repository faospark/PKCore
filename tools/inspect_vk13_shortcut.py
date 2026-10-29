import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vk13.json', 'r', encoding='utf-8') as f:
    d = json.load(f)

print("map count:", len(d.get('map', [])))
for i, m in enumerate(d.get('map', [])):
    print(f"map[{i}] keys: {list(m.keys())}")

med = d['eventdata'].get('mapeventdat', [])
print("mapeventdat count:", len(med))
for i, sub in enumerate(med):
    evs = sub.get('eventdat', [])
    print(f"=== Submap {i}: event count {len(evs)} ===")
    for j, ev in enumerate(evs):
        com = ev.get('eventCom', [])
        form = ev.get('eventForm', [])
        pos = ev.get('pos', {})
        etyp = ev.get('etyp')
        has_trans = any(x in [31, 32] for x in com)
        if has_trans or j in [12, 13]:
            print(f"  ev[{j}] etyp={etyp} pos=({pos.get('x1')},{pos.get('y1')})-({pos.get('x2')},{pos.get('y2')}) form={form} com={com}")
