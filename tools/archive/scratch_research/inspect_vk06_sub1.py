import json

with open('D:/Modding/suikodum/Mobobehaviour/vk06.json', 'r', encoding='utf-8') as f:
    data = json.load(f)

for s_idx in [1, 2]:
    sub = data['eventdata']['mapeventdat'][s_idx]
    for e_idx in [55, 56, 57, 58, 59, 60, 6, 7, 8]:
        if e_idx < len(sub.get('eventdat', [])):
            edat = sub['eventdat'][e_idx]
            print(f'=== vk06 Submap {s_idx} ev[{e_idx}] ===')
            print('Form:', edat.get('eventForm', []))
            print('Com:', edat.get('eventCom', [])[:40])
