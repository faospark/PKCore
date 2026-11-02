import json

with open('D:/Modding/suikodum/Mobobehaviour/vk30.json', 'r') as f:
    data = json.load(f)

for s_idx, sub in enumerate(data['eventdata']['mapeventdat']):
    for i, edat in enumerate(sub.get('eventdat', [])):
        form = edat.get('eventForm', [])
        com = edat.get('eventCom', [])
        # print first 15 events
        if i < 15 or any(b in [71, 72, 148, 152, 153] for b in form + com):
            print(f'=== vk30 Submap {s_idx} ev[{i}] ===')
            print('Form:', form)
            print('Com:', com[:50])
