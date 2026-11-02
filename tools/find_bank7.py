import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vh06.json', 'r', encoding='utf-8') as f:
    d = json.load(f)

for s_idx, sub in enumerate(d['eventdata']['mapeventdat']):
    for ev_idx, ev in enumerate(sub.get('eventdat', [])):
        com = ev.get('eventCom', [])
        # Look for [24, bank_no, ...] or bank 7
        for i in range(len(com)-2):
            if com[i] == 24 and com[i+2] == 7:
                print(f"sub[{s_idx}] ev[{ev_idx}] uses bank 7: {com[i:i+6]}")
