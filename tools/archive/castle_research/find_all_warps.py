import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vh06.json', 'r', encoding='utf-8') as f:
    d = json.load(f)

for s_idx, sub in enumerate(d['eventdata']['mapeventdat']):
    for ev_idx, ev in enumerate(sub.get('eventdat', [])):
        com = ev.get('eventCom', [])
        form = ev.get('eventForm', [])
        if len(com) > 0 and com[0] == 12:
            print(f"sub[{s_idx}] ev[{ev_idx}]: form={form} com={com}")
