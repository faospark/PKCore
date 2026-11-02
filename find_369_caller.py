import glob, json

for p in glob.glob(r'd:\Modding\suikodum\Mobobehaviour\vh*.json'):
    with open(p, 'r', encoding='utf-8') as f:
        d = json.load(f)
    ed = d['eventdata']
    for b_idx, bank in enumerate(ed.get('sce_msg', [])):
        if 369 in bank.get('msg_index', []):
            print(f"{p} bank[{b_idx}] has 369 at index {bank['msg_index'].index(369)}")
    for s_idx, sub in enumerate(ed.get('mapeventdat', [])):
        for ev_idx, ev in enumerate(sub.get('eventdat', [])):
            com = ev.get('eventCom', [])
            for i in range(len(com)-2):
                if com[i] == 24 and com[i+3] == 12: # index 12 in bank 7
                    print(f"{p} sub[{s_idx}] ev[{ev_idx}] byte[{i}]: {com[i:i+4]}")
