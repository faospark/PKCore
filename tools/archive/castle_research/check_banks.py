import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vh06.json', 'r', encoding='utf-8') as f:
    d = json.load(f)

for b in [6, 7, 10, 11]:
    bank = d['eventdata']['sce_msg'][b]
    print(f"bank {b} indices:", bank['msg_index'][:15])
