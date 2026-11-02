import glob, os, json

for fpath in glob.glob('D:/Modding/suikodum/Mobobehaviour/vk*.json'):
    mname = os.path.basename(fpath).replace('.json', '')
    try:
        with open(fpath, 'r', encoding='utf-8') as f:
            data = json.load(f)
    except:
        continue
    for s_idx, sub in enumerate(data.get('eventdata', {}).get('mapeventdat', [])):
        for e_idx, edat in enumerate(sub.get('eventdat', [])):
            com = edat.get('eventCom', [])
            for i in range(len(com)-2):
                if com[i] in [2, 10] and com[i+1] == 61 and com[i+2] == 64:
                    print(f'{mname} Submap {s_idx} ev[{e_idx}] Clears (61, 64)')
                if com[i] in [1, 9] and com[i+1] == 61 and com[i+2] == 64:
                    print(f'{mname} Submap {s_idx} ev[{e_idx}] Sets (61, 64)')
