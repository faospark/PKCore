import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vk03.json', 'r', encoding='utf-8') as f:
    d = json.load(f)

med = d['eventdata']['mapeventdat']
print(f"vk03 has {len(med)} submaps")
for i, sub in enumerate(med):
    print(f"=== vk03 Submap {i} (mapno={sub.get('mapno')}) ===")
    for j, ev in enumerate(sub.get('eventdat', [])):
        com = ev.get('eventCom', [])
        form = ev.get('eventForm', [])
        for k in range(len(com)):
            if com[k] == 32 and k + 4 < len(com):
                print(f"  ev[{j}] etyp={ev.get('etyp')} form={form} -> ECMapChenge map={com[k+1]} sub={com[k+2]} at ({com[k+3]}, {com[k+4]})")
            elif com[k] == 31 and k + 3 < len(com):
                print(f"  ev[{j}] etyp={ev.get('etyp')} form={form} -> ECSMapChenge sub={com[k+1]} at ({com[k+2]}, {com[k+3]})")
