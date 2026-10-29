import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vk13.json', 'r', encoding='utf-8') as f:
    d = json.load(f)

med = d['eventdata']['mapeventdat']
print(f"Total submaps in vk13 mapeventdat: {len(med)}")
for i, sub in enumerate(med):
    evs = sub.get('eventdat', [])
    print(f"Submap {i}: event count = {len(evs)}")
    if i == 4:
        for j, ev in enumerate(evs):
            print(f"  sub4 ev[{j}]: keys={list(ev.keys())}")
            print(f"    etyp={ev.get('etyp')}, form={ev.get('eventForm')}, com={ev.get('eventCom')}")
            for k in ev:
                if k not in ['eventForm', 'eventCom', 'etyp']:
                    print(f"    {k}: {ev[k]}")
