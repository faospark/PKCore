import json

with open('D:/Modding/suikodum/Mobobehaviour/vk05.json', 'r', encoding='utf-8') as f:
    data = json.load(f)

for s_idx, sub in enumerate(data['eventdata']['mapeventdat']):
    print(f'=== vk05 Submap {s_idx} ===')
    for o_idx, obj in enumerate(sub.get('eventobj', [])):
        print(f'  Obj {o_idx}: fpno={obj.get("fpno")}, otyp={obj.get("otyp")}, (x={obj.get("x")}, y={obj.get("y")})')
    for e_idx, edat in enumerate(sub.get('eventdat', [])):
        form = edat.get('eventForm', [])
        com = edat.get('eventCom', [])
        if any(b in [71, 72, 148, 152, 153] for b in form + com):
            print(f'  ev[{e_idx}] Form: {form}')
            print(f'  ev[{e_idx}] Com: {com[:40]}')
