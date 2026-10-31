import json

with open(r'd:\Modding\suikodum\TextAsset\text_gsd2_en', 'r', encoding='utf-8') as f:
    text_data = json.load(f)

for it in text_data['textList']:
    t = it.get('text', '')
    if 'peace agreement' in t.lower() or 'treaty' in t.lower() or 'armistice' in t.lower():
        print(f"ID {it['id']}: {t}")
