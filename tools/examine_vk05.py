import json

with open(r'D:\Modding\suikodum\Mobobehaviour\vk05.json', 'r', encoding='utf-8') as f:
    d = json.load(f)

submaps = d['eventdata']['mapeventdat']
print(f"Total Submaps in vk05: {len(submaps)}")

for s_idx, m in enumerate(submaps):
    objs = m.get('eventobj', [])
    fpnos = [o.get('fpno') for o in objs]
    print(f"Submap {s_idx} (okaz={m.get('okaz')}, evkaz={m.get('evkaz')}): fpnos={fpnos[:15]}")
