import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vk20.json', 'r', encoding='utf-8') as f:
    vk20 = json.load(f)

with open(r'd:\Modding\suikodum\TextAsset\text_gsd2_en', 'r', encoding='utf-8') as f:
    text_data = json.load(f)

# Search text_data for Hai Yo, cook-off, judge, recipe, black dragon
for it in text_data['textList']:
    t = it.get('text', '')
    if 'iron chef' in t.lower() or 'cook-off' in t.lower() or 'cooking contest' in t.lower() or 'cooking duel' in t.lower():
        print(f"ID {it['id']}: {t[:100]}")
    if 'black dragon' in t.lower() and ('chef' in t.lower() or 'cook' in t.lower() or 'recipe' in t.lower() or 'hai yo' in t.lower()):
        print(f"ID {it['id']}: {t[:100]}")
    if 'moon screen' in t.lower() or 'dragon spoon' in t.lower():
        print(f"ID {it['id']}: {t[:100]}")
