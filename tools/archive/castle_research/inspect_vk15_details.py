import json

with open(r'd:\Modding\suikodum\TextAsset\text_gsd2_en', 'r', encoding='utf-8') as f:
    text_data = json.load(f)

for it in text_data['textList']:
    if 1007080135 <= it['id'] <= 1007080155:
        print(f"ID {it['id']}: {it.get('text', '')}")
