import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vk03.json', 'r', encoding='utf-8') as f:
    d = json.load(f)

med = d['eventdata']['mapeventdat']
print("Searching vk03 events near (50, 23)...")
for i, sub in enumerate(med):
    for j, ev in enumerate(sub.get('eventdat', [])):
        form = ev.get('eventForm', [])
        com = ev.get('eventCom', [])
        # Check if form has range checking coords around 50, 23
        # In eventForm, token 1 is X range [x1, x2], token 2 is Y range [y1, y2]
        # or pos
        etyp = ev.get('etyp')
        has_pos = False
        for k in range(len(form)):
            if form[k] in [1, 2] and k + 2 < len(form):
                v1, v2 = form[k+1], form[k+2]
                if (form[k] == 1 and v1 <= 50 <= v2) or (form[k] == 2 and v1 <= 23 <= v2):
                    has_pos = True
        if has_pos or j in [96, 97, 122, 123, 124, 125, 126, 127, 128, 129]:
            print(f"ev[{j}] etyp={etyp} form={form} com={com}")
