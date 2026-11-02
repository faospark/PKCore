import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vh06.json', 'r', encoding='utf-8') as f:
    d = json.load(f)

for s_idx, sub in enumerate(d['eventdata']['mapeventdat']):
    for ev_idx, ev in enumerate(sub.get('eventdat', [])):
        form = ev.get('eventForm', [])
        com = ev.get('eventCom', [])
        if 29 in form or 29 in com:
            print(f"sub[{s_idx}] ev[{ev_idx}]: form={form}")
            print(f"  com={com}")
