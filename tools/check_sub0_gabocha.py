import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vh06.json', 'r', encoding='utf-8') as f:
    d = json.load(f)

sub0 = d['eventdata']['mapeventdat'][0]
for idx in [54, 55, 56, 57, 58, 91, 92]:
    ev = sub0['eventdat'][idx]
    print(f"sub[0] ev[{idx}]: form={ev['eventForm']}")
    print(f"  com={ev['eventCom']}")
