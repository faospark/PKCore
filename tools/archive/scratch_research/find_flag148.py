import os, glob, json

for fpath in glob.glob('D:/Modding/suikodum/Mobobehaviour/*.json'):
    mname = os.path.basename(fpath).replace('.json', '')
    try:
        with open(fpath, 'r', encoding='utf-8') as f:
            data = json.load(f)
    except:
        continue
    found = []
    for s_idx, sub in enumerate(data.get('eventdata', {}).get('mapeventdat', [])):
        for e_idx, edat in enumerate(sub.get('eventdat', [])):
            form = edat.get('eventForm', [])
            com = edat.get('eventCom', [])
            for i in range(len(form)-2):
                if form[i] in [1, 2, 3, 4] and form[i+1] == 148 and form[i+2] == 2:
                    found.append(f'Submap {s_idx} ev[{e_idx}] Form: {form[i:i+3]}')
            for i in range(len(com)-2):
                if com[i] in [1, 2, 9, 10] and com[i+1] == 148 and com[i+2] == 2:
                    found.append(f'Submap {s_idx} ev[{e_idx}] Com: {com[i:i+3]}')
    if found:
        print(f'=== Map {mname} ===')
        for item in found:
            print(f'  {item}')
