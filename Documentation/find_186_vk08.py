import json

data = json.load(open('D:/Modding/suikodum/Mobobehaviour/vk08.json', 'r', encoding='utf-8'))
for sm_idx, sm in enumerate(data['eventdata']['mapeventdat']):
    for e_idx, ev in enumerate(sm.get('eventdat', [])):
        ef = ev.get('eventForm', [])
        if 186 in ef:
            print(f"Submap {sm_idx} ev[{e_idx}] etyp={ev.get('etyp')} Form={ef}")
