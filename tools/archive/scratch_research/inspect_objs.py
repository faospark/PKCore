import json

with open('D:/Modding/suikodum/Mobobehaviour/vk30.json', 'r', encoding='utf-8') as f:
    data = json.load(f)

objs = data['eventdata']['mapeventdat'][0]['eventobj']
for i, obj in enumerate(objs):
    fpno = obj.get('fpno')
    otyp = obj.get('otyp')
    disp = obj.get('disp')
    x = obj.get('x')
    y = obj.get('y')
    print(f'Obj {i}: fpno={fpno}, otyp={otyp}, disp={disp}, (x={x}, y={y})')
