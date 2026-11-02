import json

with open('D:/Modding/suikodum/Mobobehaviour/vk05.json', 'r', encoding='utf-8') as f:
    data = json.load(f)

for s_idx, sub in enumerate(data['eventdata']['mapeventdat']):
    for e_idx, edat in enumerate(sub.get('eventdat', [])):
        form = edat.get('eventForm', [])
        com = edat.get('eventCom', [])
        # Look for 148 or 152 in form or com
        for i in range(len(form)-2):
            if form[i] in [1, 2, 3, 4] and form[i+1] in [148, 152, 153]:
                print(f'Submap {s_idx} ev[{e_idx}] Form: {form}')
                print(f'Submap {s_idx} ev[{e_idx}] Com: {com[:60]}')
                break
        for i in range(len(com)-2):
            if com[i] in [1, 2, 9, 10] and com[i+1] in [148, 152, 153]:
                print(f'Submap {s_idx} ev[{e_idx}] Com has flag set/clear: {com[i:i+3]}')
                break
