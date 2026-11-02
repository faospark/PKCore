import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vh06.json', 'r', encoding='utf-8') as f:
    d = json.load(f)

for b_idx, bank in enumerate(d['eventdata']['sce_msg']):
    for i_idx, val in enumerate(bank.get('msg_index', [])):
        if val in (1008010369, 369):
            print(f"vh06 bank[{b_idx}] index[{i_idx}] = {val}")
