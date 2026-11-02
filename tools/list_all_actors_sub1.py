import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vh06.json', 'r', encoding='utf-8') as f:
    d = json.load(f)

sub1 = d['eventdata']['mapeventdat'][1]
for i, o in enumerate(sub1['eventobj']):
    if o['otyp'] == 1:
        print(f"obj[{i}]: fpno={o['fpno']} pos=({o['x']}, {o['y']}) disp={o['disp']} otyp={o['otyp']}")
