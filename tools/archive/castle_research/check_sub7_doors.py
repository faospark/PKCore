import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vk13.json', 'r', encoding='utf-8') as f:
    d = json.load(f)

med = d['eventdata']['mapeventdat']
sub7 = med[7]
print("Checking all events in Submap 7:")
for j, ev in enumerate(sub7.get('eventdat', [])):
    form = ev.get('eventForm', [])
    com = ev.get('eventCom', [])
    print(f"sub7 ev[{j}]: etyp={ev.get('etyp')} form={form}")
    if any(c in [12, 31, 32, 33] for c in com):
        print(f"  -> COM: {com}")
