with open(r'd:\Modding\suikodum\TextAsset\text_gsd2_en', 'r', encoding='utf-8', errors='ignore') as f:
    text = f.read()

# Base ID for vh06:
# Let's find IDs around 1008060252 or similar
for prefix in [1008060000, 1008010000, 1008000000]:
    for idx in range(252, 265):
        tid = prefix + idx
        s = f'"{tid}":'
        p = text.find(str(tid))
        if p != -1:
            print(f"{tid}: {text[p:p+100]}")
            break
