import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vk13.json', 'r', encoding='utf-8') as f:
    d = json.load(f)

msgs = d.get('eventdata', {}).get('sce_msg', [])
for i, m in enumerate(msgs):
    # m can be a list of strings
    if isinstance(m, list):
        for j, text in enumerate(m):
            if text.strip():
                print(f"[{i}][{j}]: {text}")
    elif isinstance(m, str) and m.strip():
        print(f"[{i}]: {m}")
