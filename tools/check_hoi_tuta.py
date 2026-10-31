import json

with open(r'd:\Modding\suikodum\TextAsset\text_gsd2_en', 'r', encoding='utf-8') as f:
    text_data = json.load(f)

for it in text_data['textList']:
    t = it.get('text', '')
    if 'bwa! oh,uh, i-i was just' in t.lower() or 'oh,uh, i-i was just' in t.lower():
        print(f"ID {it['id']}: {t}")
    if 'hoi' in t.lower() and ('caught' in t.lower() or 'imposter' in t.lower() or 'pretend' in t.lower()):
        print(f"ID {it['id']}: {t}")
