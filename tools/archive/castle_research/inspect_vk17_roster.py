import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vk17.json', 'r', encoding='utf-8') as f:
    vk17 = json.load(f)

with open(r'd:\Modding\suikodum\TextAsset\text_gsd2_en', 'r', encoding='utf-8') as f:
    text_data = json.load(f)
text_map = {it['id']: it.get('text', '') for it in text_data['textList']}

print("Checking character checks (opcode 23) in vk17:")
recruited_chars = set()
for s_idx, sm in enumerate(vk17['eventdata']['mapeventdat']):
    for ev in sm.get('eventdat', []):
        form = ev.get('eventForm', [])
        for i in range(len(form)-2):
            if form[i] == 23 and form[i+2] == 1:
                recruited_chars.add(form[i+1])

print(f"Recruited character IDs checked in vk17: {sorted(recruited_chars)}")

# Check all eventobj in all 5 submaps:
for s_idx, sm in enumerate(vk17['eventdata']['mapeventdat']):
    print(f"\n--- Submap {s_idx} Objects ---")
    for o_idx, o in enumerate(sm.get('eventobj', [])):
        print(f"  obj[{o_idx}]: otyp={o.get('otyp')}, fpno={o.get('fpno')}, pos=({o.get('x')}, {o.get('y')}), ano={o.get('ano')}, disp={o.get('disp')}, ozok={o.get('ozok')}")

# Check dialogue text for vk17
for it in text_data['textList']:
    if 1011170000 <= it['id'] <= 1011170200:
        print(f"ID {it['id']}: {repr(it.get('text', ''))}")
