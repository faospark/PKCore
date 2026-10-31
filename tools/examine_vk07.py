import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vk07.json', 'r', encoding='utf-8') as f:
    d = json.load(f)

msgs = d['eventdata'].get('sce_msg', [])
msg_indices = set()
for m in msgs:
    msg_indices.update(m.get('msg_index', []))

with open(r'd:\Modding\suikodum\TextAsset\text_gsd2_en', 'r', encoding='utf-8') as f:
    text_data = json.load(f)

matches = {it['id']: it['text'] for it in text_data.get('textList', []) if it['id'] in msg_indices}

# Look at entries with id > 120 and not memory card
story_dialogues = []
for mid in sorted(matches.keys()):
    txt = matches[mid].strip()
    if mid > 120 and len(txt) > 5 and not any(k in txt for k in ['MEMORY CARD', 'Backspace', 'Transparent']):
        story_dialogues.append((mid, txt))

print(f"Story / Tactical lines: {len(story_dialogues)}")
for mid, txt in story_dialogues:
    print(f"[{mid}]: {txt}")
