import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vh06.json', 'r', encoding='utf-8') as f:
    d = json.load(f)

for s_idx, sub in enumerate(d['eventdata']['mapeventdat']):
    for ev_idx, ev in enumerate(sub.get('eventdat', [])):
        com = ev.get('eventCom', [])
        for i in range(len(com)-3):
            if com[i] == 24 and 7 in (com[i+1], com[i+2], com[i+3]):
                print(f"sub[{s_idx}] ev[{ev_idx}] at byte[{i}]: {com[i:i+6]}")
