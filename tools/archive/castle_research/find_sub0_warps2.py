import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vh06.json', 'r', encoding='utf-8') as f:
    d = json.load(f)

sub0 = d['eventdata']['mapeventdat'][0]
for ev_idx, ev in enumerate(sub0.get('eventdat', [])):
    com = ev.get('eventCom', [])
    form = ev.get('eventForm', [])
    if 12 in com:
        print(f"sub[0] ev[{ev_idx}]: form={form} com={com}")
