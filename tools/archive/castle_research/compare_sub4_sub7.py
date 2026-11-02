import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vk13.json', 'r', encoding='utf-8') as f:
    d = json.load(f)

med = d['eventdata']['mapeventdat']
sub4 = med[4]
sub7 = med[7]

print(f"Submap 4: mapno={sub4.get('mapno')}, okaz={sub4.get('okaz')}, evkaz={sub4.get('evkaz')}")
print(f"Submap 7: mapno={sub7.get('mapno')}, okaz={sub7.get('okaz')}, evkaz={sub7.get('evkaz')}")

print("\n--- Submap 4 Objects ---")
for i, obj in enumerate(sub4.get('eventobj', [])):
    print(f"  obj[{i}]: fpno={obj.get('fpno')}, pos=({obj.get('x')}, {obj.get('y')}), disp={obj.get('disp')}")

print("\n--- Submap 7 Objects ---")
for i, obj in enumerate(sub7.get('eventobj', [])):
    print(f"  obj[{i}]: fpno={obj.get('fpno')}, pos=({obj.get('x')}, {obj.get('y')}), disp={obj.get('disp')}")
