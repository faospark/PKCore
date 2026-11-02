import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vh06.json', 'r', encoding='utf-8') as f:
    d = json.load(f)

sub1 = d['eventdata']['mapeventdat'][1]
for i in [2, 3, 23, 24, 25, 26, 27, 28, 29, 30]:
    if i < len(sub1['eventobj']):
        o = sub1['eventobj'][i]
        print(f"obj[{i}]: fpno={o['fpno']} pos=({o['x']}, {o['y']}) disp={o['disp']} otyp={o['otyp']}")
