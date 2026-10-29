import json
d = json.load(open(r'D:\Modding\suikodum\Mobobehaviour\vk07.json', 'r', encoding='utf-8'))
for s_i, s in enumerate(d['eventdata']['mapeventdat']):
    print(f"submap {s_i}: okaz={s.get('okaz')} len(eventobj)={len(s.get('eventobj', []))}")
    if s_i == 3:
        for idx, o in enumerate(s.get('eventobj', [])):
            print(f"  [{idx:02d}] disp={o.get('disp')} otyp={o.get('otyp')} fpno={o.get('fpno')} pos=({o.get('x')},{o.get('y')}) ano={o.get('ano')} ityp={o.get('ityp')}")

