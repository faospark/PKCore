import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vh06.json', 'r', encoding='utf-8') as f:
    d = json.load(f)

for s_idx, sub in enumerate(d['eventdata']['mapeventdat']):
    for ev_idx, ev in enumerate(sub.get('eventdat', [])):
        form = ev.get('eventForm', [])
        com = ev.get('eventCom', [])
        # Search for 37 in form or com
        if 37 in form or 74 in form:
            print(f"sub[{s_idx}] ev[{ev_idx}] near (37, 74): form={form}")
            print(f"  com={com[:30]}")
