import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vk33.json', 'r', encoding='utf-8') as f:
    vk33 = json.load(f)

print("vk33 keys:", list(vk33.keys()))
ed = vk33['eventdata']
print("sce_msg:", ed.get('sce_msg'))

with open(r'd:\Modding\suikodum\TextAsset\text_gsd2_en', 'r', encoding='utf-8') as f:
    text_data = json.load(f)
text_map = {it['id']: it.get('text', '') for it in text_data['textList']}

# Print all dialogue lines in textList around 1011330001
print("\n--- Dialogue in vk33 (Text range 1011330001..1011330055) ---")
for it in text_data['textList']:
    if 1011330001 <= it['id'] <= 1011330055:
        print(f"ID {it['id']}: {it.get('text', '')}")
