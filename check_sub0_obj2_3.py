import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vh06.json', 'r', encoding='utf-8') as f:
    d = json.load(f)

sub0 = d['eventdata']['mapeventdat'][0]
for idx in [2, 3]:
    o = sub0['eventobj'][idx]
    print(f"sub[0] obj[{idx}]: {o}")
