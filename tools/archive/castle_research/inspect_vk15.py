import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vk15.json', 'r', encoding='utf-8') as f:
    vk15 = json.load(f)

ed = vk15['eventdata']
med = ed.get('mapeventdat', [])
print(f"mapeventdat count: {len(med)}")
for m_idx, m in enumerate(med):
    print(f"--- Map {m_idx} ---")
    print(f"okaz: {m.get('okaz')}, evkaz: {m.get('evkaz')}")
    for o_idx, obj in enumerate(m.get('eventobj', [])):
        print(f"  obj[{o_idx}]: fpno={obj.get('fpno')}, pos=({obj.get('pos_x')}, {obj.get('pos_y')}), dir={obj.get('dir')}, kind={obj.get('kind')}")

print("\n--- etcdata characters ---")
for c in vk15.get('etcdata', {}).get('etc_char_data', []):
    print(c)

print("\n--- overlay_func ---")
print(vk15.get('overlay_func'))
