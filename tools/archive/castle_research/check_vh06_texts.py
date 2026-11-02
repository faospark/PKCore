import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vh06.json', 'r', encoding='utf-8') as f:
    d = json.load(f)

ed = d['eventdata']
print("sce_msg count:", len(ed.get('sce_msg', [])))
for b_idx, bank in enumerate(ed.get('sce_msg', [])):
    indices = bank.get('msg_index', [])
    print(f"bank[{b_idx}] index count:", len(indices))
