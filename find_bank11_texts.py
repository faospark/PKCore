with open(r'd:\Modding\suikodum\TextAsset\text_gsd2_en', 'r', encoding='utf-8', errors='ignore') as f:
    text = f.read()

for tid in [1008010555, 1008010556, 1008010252, 1008010253, 1008010254, 1008010255]:
    idx = text.find(str(tid))
    if idx != -1:
        print(f"--- {tid} ---")
        print(text[idx:idx+200])
