import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vh06.json', 'r', encoding='utf-8') as f:
    d = json.load(f)

for s_idx, sub in enumerate(d['eventdata']['mapeventdat']):
    print(f"--- SUBMAP {s_idx} (mapno={sub.get('mapno')}) ---")
    objs = sub.get('eventobj', [])
    if objs:
        print("keys:", list(objs[0].keys()))
    for o_idx, obj in enumerate(objs):
        fpno = obj.get('fpno')
        x = obj.get('x') or obj.get('gx') or obj.get('posx')
        y = obj.get('y') or obj.get('gy') or obj.get('posy')
        if fpno == 29 or fpno == 28 or (x is not None and abs(x - 37) < 20 and abs(y - 74) < 20):
            print(f"  obj[{o_idx}]: fpno={fpno}, pos=({x}, {y}), disp={obj.get('disp')}, otyp={obj.get('otyp')}")
