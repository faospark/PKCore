import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vk19.json', 'r', encoding='utf-8') as f:
    vk19 = json.load(f)

with open(r'd:\Modding\suikodum\TextAsset\text_gsd2_en', 'r', encoding='utf-8') as f:
    text_data = json.load(f)

for it in text_data['textList']:
    t = it.get('text', '')
    if 'vegetable' in t.lower() and ('seed' in t.lower() or 'plant' in t.lower() or 'grow' in t.lower() or 'tony' in t.lower()):
        print(f"ID {it['id']}: {t[:100]}")
    if 'yuzu' in t.lower() and ('sheep' in t.lower() or 'pig' in t.lower() or 'cow' in t.lower() or 'animal' in t.lower()):
        print(f"ID {it['id']}: {t[:100]}")
