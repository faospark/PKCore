import json

with open('D:/Modding/suikodum/Mobobehaviour/vk30.json', 'r') as f:
    data = json.load(f)

med = data.get('eventdata', {}).get('mapeventdat', [])
for s_idx, sub in enumerate(med):
    print(f'Submap {s_idx}:')
    for k in sub:
        val = sub[k]
        if isinstance(val, list):
            print(f'  {k}: {len(val)} items')
            if len(val) > 0 and isinstance(val[0], dict):
                print(f'    sample {k}[0] keys: {list(val[0].keys())}')
        elif isinstance(val, dict):
            print(f'  {k}: dict keys {list(val.keys())}')
