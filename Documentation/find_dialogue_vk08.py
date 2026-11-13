import json

data = json.load(open('D:/Modding/suikodum/Mobobehaviour/vk08.json', 'r', encoding='utf-8'))
for sm_idx, sm in enumerate(data['eventdata']['mapeventdat']):
    for e_idx, ev in enumerate(sm.get('eventdat', [])):
        for a in ev.get('eventAction', []):
            if a.get('code') in [23, 24]:
                print(f"Submap {sm_idx} ev[{e_idx}] etyp={ev.get('etyp')} code={a.get('code')} data={a.get('data')}")
                print(f"   Form: {ev.get('eventForm')}")
