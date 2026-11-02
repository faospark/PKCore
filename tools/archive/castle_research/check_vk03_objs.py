import json
with open(r'd:\Modding\suikodum\Mobobehaviour\vk03.json', 'r', encoding='utf-8') as f:
    d = json.load(f)
sub0 = d['eventdata']['mapeventdat'][0]
print('vk03 objects near (50, 23):')
for i, o in enumerate(sub0['eventobj']):
    if abs(o['x'] - 50) < 15 and abs(o['y'] - 23) < 15:
        print(f"  obj[{i}] fpno={o['fpno']} pos=({o['x']}, {o['y']}) disp={o['disp']}")

print('\nvk03 events near (50, 23):')
for i, ev in enumerate(sub0['eventdat']):
    form = ev.get('eventForm', [])
    for k in range(len(form)):
        if form[k] in [1, 2] and k + 2 < len(form):
            v1, v2 = form[k+1], form[k+2]
            if (form[k] == 1 and abs(v1 - 50) < 15) or (form[k] == 2 and abs(v1 - 23) < 15):
                print(f"  ev[{i}] etyp={ev['etyp']} form={form} com={ev['eventCom']}")
                break
