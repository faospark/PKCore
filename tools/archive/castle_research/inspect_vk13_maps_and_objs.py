import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vk13.json', 'r', encoding='utf-8') as f:
    d = json.load(f)

for i, m in enumerate(d.get('map', [])):
    print(f"map[{i}]: maxw={m.get('maxw')}, maxh={m.get('maxh')}, ID={m.get('ID')}, typ={m.get('typ')}")

# Also let's check what submaps are in vk13:
med = d['eventdata']['mapeventdat']
for i, sub in enumerate(med):
    print(f"submap[{i}]: mapno={sub.get('mapno')}, okaz={sub.get('okaz')}, evkaz={sub.get('evkaz')}")
    # print all objects in this submap
    objs = sub.get('eventobj', [])
    print(f"  objects count: {len(objs)}")
    for j, obj in enumerate(objs):
        print(f"    obj[{j}]: otyp={obj.get('otyp')}, fpno={obj.get('fpno')}, pos=({obj.get('x')}, {obj.get('y')}), disp={obj.get('disp')}")
