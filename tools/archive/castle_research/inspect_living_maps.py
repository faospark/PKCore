# Check what maps exist in Mobobehaviour for Region VK corridors
import os
import json

vk_files = sorted([f for f in os.listdir(r'd:\Modding\suikodum\Mobobehaviour') if f.startswith('vk') and not '_' in f])
print("All master vk files:", vk_files)

# Let's inspect vk13, vk16, vk17, vk24, vk25, vk26, vk27, vk28, vk30, vk34, vk35, vk36, vk37
living_maps = ['vk13', 'vk16', 'vk17', 'vk24', 'vk25', 'vk26', 'vk27', 'vk28', 'vk30', 'vk34', 'vk35', 'vk36', 'vk37']
for m in living_maps:
    path = rf'd:\Modding\suikodum\Mobobehaviour\{m}.json'
    if os.path.exists(path):
        with open(path, 'r', encoding='utf-8') as f:
            d = json.load(f)
        med = d['eventdata'].get('mapeventdat', [])
        print(f"{m}: submaps={len(med)}, total_okaz={sum(sm.get('okaz',0) for sm in med)}, total_evkaz={sum(sm.get('evkaz',0) for sm in med)}")
    else:
        print(f"{m}: NOT FOUND")
