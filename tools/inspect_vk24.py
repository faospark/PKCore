import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vk24.json', 'r', encoding='utf-8') as f:
    vk24 = json.load(f)

print("vk24 keys:", list(vk24.keys()))
ed = vk24['eventdata']
med = ed.get('mapeventdat', [])
print(f"mapeventdat count: {len(med)}")
for idx, m in enumerate(med):
    print(f"  submap {idx}: mapno={m.get('mapno')}, okaz={m.get('okaz')}, evkaz={m.get('evkaz')}")

for i, o in enumerate(med[0]['eventobj']):
    print(f"obj[{i}]: fpno={o.get('fpno')}, otyp={o.get('otyp')}, pos=({o.get('x')}, {o.get('y')}), ano={o.get('ano')}, disp={o.get('disp')}, ozok={o.get('ozok')}")

# Check textures
import os
print("\nTextures vk24:", [f for f in os.listdir(r'd:\Modding\suikodum\Texture2D') if 'vk24' in f])

# Check warps
print("\n--- Warps in vk24 ---")
for s_idx, s in enumerate(med):
    for e_idx, ev in enumerate(s.get('eventdat', [])):
        com = ev.get('eventCom', [])
        for i in range(len(com)-3):
            if com[i] == 31:
                print(f"Sub {s_idx} ev[{e_idx}]: Warp -> {com[i:i+6]}")
