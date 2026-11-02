import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vk33.json', 'r', encoding='utf-8') as f:
    vk33 = json.load(f)

print("vk33 keys:", list(vk33.keys()))
ed = vk33['eventdata']
med = ed.get('mapeventdat', [])
print(f"mapeventdat count: {len(med)}")
for idx, m in enumerate(med):
    print(f"  submap {idx}: mapno={m.get('mapno')}, okaz={m.get('okaz')}, evkaz={m.get('evkaz')}")

for i, o in enumerate(med[0]['eventobj']):
    print(f"obj[{i}]: fpno={o['fpno']}, otyp={o['otyp']}, pos=({o['x']}, {o['y']}), ano={o['ano']}, disp={o['disp']}")

# Check warps in vk33
for s_idx, s in enumerate(med):
    for e_idx, ev in enumerate(s.get('eventdat', [])):
        com = ev.get('eventCom', [])
        for i in range(len(com)-3):
            if com[i] == 31:
                print(f"Sub {s_idx} ev[{e_idx}]: Warp -> {com[i:i+6]}")
