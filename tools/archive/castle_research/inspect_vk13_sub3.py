import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vk13.json', 'r', encoding='utf-8') as f:
    d = json.load(f)

med = d['eventdata']['mapeventdat']
sub3 = med[3]
print("=== Submap 3 of vk13 ===")
print("mapno:", sub3.get('mapno'))
print("okaz:", sub3.get('okaz'))
print("evkaz:", sub3.get('evkaz'))
print("Objects:")
for j, obj in enumerate(sub3.get('eventobj', [])):
    print(f"  obj[{j}]: otyp={obj.get('otyp')}, fpno={obj.get('fpno')}, pos=({obj.get('x')}, {obj.get('y')}), disp={obj.get('disp')}")

print("\nEvents:")
for j, ev in enumerate(sub3.get('eventdat', [])):
    print(f"  ev[{j}]: etyp={ev.get('etyp')}, form={ev.get('eventForm')}, com={ev.get('eventCom')}")
