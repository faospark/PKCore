import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vh06.json', 'r', encoding='utf-8') as f:
    d = json.load(f)

sub1 = d['eventdata']['mapeventdat'][1]
for i, ev in enumerate(sub1['eventdat']):
    etyp = ev.get('etyp')
    if etyp != 1:
        print(f"sub[1] ev[{i}]: etyp={etyp}, form={ev.get('eventForm')}")
        print(f"  com={ev.get('eventCom')[:20]}")
