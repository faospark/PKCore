import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vk13.json', 'r', encoding='utf-8') as f:
    d = json.load(f)

med = d['eventdata']['mapeventdat']
sub7 = med[7]
print("=== Submap 7 of vk13 ===")
print("mapno:", sub7.get('mapno'))
print("okaz:", sub7.get('okaz'))
print("evkaz:", sub7.get('evkaz'))
for j, ev in enumerate(sub7.get('eventdat', [])):
    form = ev.get('eventForm')
    com = ev.get('eventCom')
    # print transitions or doors
    if any(c in [12, 31, 32, 33] for c in com) or (form and 33 in form):
        print(f"  ev[{j}]: etyp={ev.get('etyp')}, form={form}, com={com}")
