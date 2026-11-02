with open(r'd:\Modding\suikodum\TextAsset\text_gsd2_en', 'r', encoding='utf-8', errors='ignore') as f:
    text = f.read()

idx = 0
while True:
    idx = text.find('Gabocha', idx)
    if idx == -1: break
    print(f"--- Gabocha at {idx} ---")
    start = max(0, idx - 150)
    end = min(len(text), idx + 250)
    print(text[start:end])
    idx += 7
