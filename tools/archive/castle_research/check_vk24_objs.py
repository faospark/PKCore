import json

with open(r'D:\Modding\suikodum\Mobobehaviour\vk24.json', 'r', encoding='utf-8') as f:
    data = json.load(f)

objs = data['eventdata']['mapeventdat'][0]['eventobj']
print(f"Total objects in vk24 Sub 0: {len(objs)}")
for idx in [10, 22]:
    if idx < len(objs):
        o = objs[idx]
        print(f"obj[{idx:02d}]: fpno={o.get('fpno')} at ({o.get('x')}, {o.get('y')}) disp={o.get('disp')} otyp={o.get('otyp')}")
