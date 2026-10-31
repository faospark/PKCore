import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vk13.json', 'r', encoding='utf-8') as f:
    vk13 = json.load(f)

print("vk13 keys:", list(vk13.keys()))
ed = vk13['eventdata']
med = ed.get('mapeventdat', [])
print(f"mapeventdat count: {len(med)}")
for idx, m in enumerate(med):
    print(f"  submap {idx}: mapno={m.get('mapno')}, okaz={m.get('okaz')}, evkaz={m.get('evkaz')}")

# Check obj[14] and obj[15] in submap 0:
# Save Orb at (26, 18), Inn Bed at (26, 24)
# That is Riou's Private Room!
print("\nSubmap 0 Save Point / Bed / Mechanisms:")
for i in [14, 15, 16]:
    o = med[0]['eventobj'][i]
    print(f"obj[{i}]: otyp={o['otyp']}, pos=({o['x']}, {o['y']}), ano={o['ano']}, disp={o['disp']}")

import os
tex = [f for f in os.listdir(r'd:\Modding\suikodum\Texture2D') if 'vk13' in f]
print("\nvk13 textures:", tex)
