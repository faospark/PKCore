import json

with open(r'd:\Modding\suikodum\TextAsset\text_gsd2_en', 'r', encoding='utf-8') as f:
    text_data = json.load(f)

for it in text_data['textList']:
    if 1011290000 <= it['id'] <= 1011290050:
        print(f"ID {it['id']}: {repr(it.get('text', ''))}")
