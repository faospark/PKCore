import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vh06.json', 'r', encoding='utf-8') as f:
    d = json.load(f)

for s_idx, sub in enumerate(d['eventdata']['mapeventdat']):
    for ev_idx, ev in enumerate(sub.get('eventdat', [])):
        com = ev.get('eventCom', [])
        # Opcode 23 is ECDispSet or similar (disp on/off)
        for i in range(len(com)-2):
            if com[i] == 23 and com[i+2] in (2, 3):
                print(f"sub[{s_idx}] ev[{ev_idx}]: {com[i:i+4]}")
            # Or opcode 0, 1 (disp set)
