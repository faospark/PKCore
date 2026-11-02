import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vh06.json', 'r', encoding='utf-8') as f:
    d = json.load(f)

sub0 = d['eventdata']['mapeventdat'][0]
for idx, ev in enumerate(sub0['eventdat']):
    form = ev.get('eventForm', [])
    if 41 in form or 71 in form or any(x in form for x in [36, 37, 38, 39, 40, 41, 42, 43]):
        print(f"sub[0] ev[{idx}]: form={form}")
        print(f"  com={ev.get('eventCom')}")
