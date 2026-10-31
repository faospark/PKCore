import json

with open(r'D:/Modding/suikodum/Mobobehaviour/vk13.json', 'r', encoding='utf-8') as fp:
    d = json.load(fp)

submaps = d.get('eventdata', {}).get('mapeventdat', [])
print(f"vk13 total submaps: {len(submaps)}")
for i, sm in enumerate(submaps):
    objs = sm.get('eventobj', [])
    fpnos = [o.get('fpno') for o in objs if o.get('fpno') != 0]
    print(f"vk13 Submap {i}: okaz={sm.get('okaz')}, evkaz={sm.get('evkaz')}, fpnos={fpnos[:10]}")
