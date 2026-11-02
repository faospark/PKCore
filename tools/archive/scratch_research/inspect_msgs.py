import json

def dump_msgs(map_name):
    with open(f'D:/Modding/suikodum/Mobobehaviour/{map_name}.json', 'r', encoding='utf-8') as f:
        data = json.load(f)
    print(f'=== {map_name} sce_msg ===')
    msgs = data.get('eventdata', {}).get('sce_msg', [])
    for i, m in enumerate(msgs):
        if any(w in str(m) for w in ['Antonio', 'Ky Yun', 'Goetsu', 'Shinki', 'Ryuki', 'Bashok', 'Ryuko', 'Gyokuran', 'Retso', 'Lester', 'Jinkai', 'Chef', 'Hai Yo', 'cook']):
            print(f'  [{i}]: {m}')

dump_msgs('vk30')
dump_msgs('vk05')
