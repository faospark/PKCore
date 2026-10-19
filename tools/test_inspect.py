import os
import json

dir_path = r'D:\Modding\suikodum\Mobobehaviour'
test_files = ['va01.json', 'va01_00.json', 'player.json', 'player_00.json', 'unite_00.json', 'idat_00.json', 'm001.json', 'vb01.json', 'vj17.json']

for tf in test_files:
    fp = os.path.join(dir_path, tf)
    if os.path.exists(fp):
        with open(fp, 'r', encoding='utf-8') as f:
            d = json.load(f)
        keys = list(d.keys())
        name = d.get('m_Name', '')
        print(f"{tf:15s} | m_Name: '{name:15s}' | keys: {keys[:6]}")
    else:
        print(f"{tf:15s} | NOT FOUND")
