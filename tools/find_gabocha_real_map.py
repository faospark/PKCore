import glob, json

# Search all json files in Mobobehaviour
for p in glob.glob(r'd:\Modding\suikodum\Mobobehaviour\*.json'):
    try:
        with open(p, 'r', encoding='utf-8') as f:
            d = json.load(f)
        ed = d.get('eventdata')
        if not ed: continue
        # Check all sce_msg
        for b_idx, bank in enumerate(ed.get('sce_msg', [])):
            indices = bank.get('msg_index', [])
            for val in [369, 370, 371, 372, 373, 374, 375, 376, 377]:
                if val in indices:
                    print(f"Map {p} bank {b_idx} has {val} at index {indices.index(val)}")
                    break
    except Exception as e:
        pass
