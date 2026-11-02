import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vh06.json', 'r', encoding='utf-8') as f:
    d = json.load(f)

for s_idx, sub in enumerate(d['eventdata']['mapeventdat']):
    for ev_idx, ev in enumerate(sub.get('eventdat', [])):
        com = ev.get('eventCom', [])
        form = ev.get('eventForm', [])
        # Check if ev controls obj 2 or obj 3 (disp)
        if any(b in (2, 3) for b in com) and 23 in com:
            print(f"sub[{s_idx}] ev[{ev_idx}]: form={form} com={com}")
