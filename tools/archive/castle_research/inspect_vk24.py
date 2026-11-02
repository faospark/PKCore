import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vk24.json', 'r', encoding='utf-8') as f:
    vk24 = json.load(f)

# Inspect dialogue in vk24's sce_msg:
with open(r'd:\Modding\suikodum\TextAsset\text_gsd2_en', 'r', encoding='utf-8') as f:
    text_data = json.load(f)
text_map = {it['id']: it.get('text', '') for it in text_data['textList']}

print("vk24 sce_msg count:", len(vk24['eventdata'].get('sce_msg', [])))
for g_idx, g in enumerate(vk24['eventdata'].get('sce_msg', [])):
    print(f"Group {g_idx}: len={len(g['msg_index'])}")

# Check dialogue IDs in text_data around war councils or major late game alliance meetings:
# In vk24 ev[23]: com had [24, 9, 1, 1], [24, 9, 1, 2], [24, 9, 0, 27], [24, 10, 0, 28]...
# Let's inspect where these dialogues point in textList:
# Let's search textList for Greenhill / Matilda invasion strategy, or Shu's war strategy in the assembly!
for it in text_data['textList']:
    t = it.get('text', '')
    if 'greenhill' in t.lower() and ('matilda' in t.lower() or 'highway' in t.lower()) and ('plan' in t.lower() or 'strategy' in t.lower() or 'ambush' in t.lower()):
        print(f"ID {it['id']}: {t[:100]}")
