import json
with open('D:/Modding/suikodum/Mobobehaviour/vk28.json', 'r', encoding='utf-8') as f:
    d = json.load(f)
print("mdat keys:", list(d['mdat'].keys()))
if 'mapeventdat' in d['mdat']:
    med = d['mdat']['mapeventdat']
    print("mapeventdat len:", len(med))
    if len(med) > 0:
        print("mapeventdat[0] keys:", list(med[0].keys()))
        print("mapeventdat[0]:", json.dumps(med[0], indent=2))
