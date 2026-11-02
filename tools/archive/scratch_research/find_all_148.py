import glob, os, json

for fpath in glob.glob('D:/Modding/suikodum/Mobobehaviour/v*.json'):
    mname = os.path.basename(fpath).replace('.json', '')
    try:
        with open(fpath, 'r', encoding='utf-8') as f:
            data = json.load(f)
    except:
        continue
    for s_idx, sub in enumerate(data.get('eventdata', {}).get('mapeventdat', [])):
        for e_idx, edat in enumerate(sub.get('eventdat', [])):
            for name, code in [('Form', edat.get('eventForm', [])), ('Com', edat.get('eventCom', []))]:
                for i in range(len(code)-2):
                    if code[i+1] == 148:
                        print(f'{mname} Sub {s_idx} ev[{e_idx}] {name}: op={code[i]} (148, {code[i+2]})')
