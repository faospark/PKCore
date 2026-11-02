import json, glob, os

for p in glob.glob('D:/Modding/suikodum/Mobobehaviour/*.json'):
    try:
        d = json.load(open(p))
        if 'overlay_func' in d and 465 in d['overlay_func']:
            slot = d['overlay_func'].index(465)
            for si, sub in enumerate(d.get('eventdata', {}).get('mapeventdat', [])):
                for ei, ev in enumerate(sub.get('eventdat', [])):
                    c = ev.get('eventCom', [])
                    for i in range(len(c)-3):
                        if c[i] == 30 and c[i+1] == slot and c[i+2] == 1:
                            print(f"{os.path.basename(p)} sub[{si}] ev[{ei}] at {i}:")
                            print("  Before:", c[max(0, i-20):i])
                            print("  After :", c[i:i+20])
    except:
        pass
