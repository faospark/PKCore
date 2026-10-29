import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vk13.json', 'r', encoding='utf-8') as f:
    d = json.load(f)

med = d['eventdata']['mapeventdat']
for i, sub in enumerate(med):
    print(f"\n--- Submap {i} (mapno {sub.get('mapno')}) ---")
    # check objects
    objs = sub.get('okaz')
    # Let's inspect epersondat or objects
    for j, ev in enumerate(sub.get('eventdat', [])):
        com = ev.get('eventCom', [])
        # check msg
        for k in range(len(com)):
            if com[k] == 24 and k + 3 < len(com):
                print(f"  ev[{j}] msg bank={com[k+2]} msg={com[k+3]}")
