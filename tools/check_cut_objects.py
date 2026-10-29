import json, os

MOB_DIR = r"D:\Modding\suikodum\Mobobehaviour"

pairs = [
    ("vk02.json", 1, 20),
    ("vk02.json", 7, 20),
    ("vk02.json", 8, 19),
    ("vk02.json", 9, 25),
    ("vk02.json", 9, 26),
    ("vk02.json", 10, 26),
    ("vk02.json", 11, 18),
    ("vk02.json", 11, 21),
    ("vk02.json", 11, 25),
    ("vk03.json", 0, 38),
    ("vk03.json", 0, 39),
    ("vk03.json", 0, 40),
    ("vk04.json", 0, 47),
    ("vk04.json", 0, 48),
    ("vk08.json", 0, 32),
    ("vk09.json", 0, 37),
    ("vk09.json", 0, 38),
    ("vk09.json", 0, 40),
    ("vk11.json", 0, 37),
    ("vk11.json", 0, 39),
    ("vk11.json", 0, 40),
    ("vk11.json", 1, 15),
    ("vk11.json", 2, 35),
    ("vk11.json", 2, 37),
    ("vk12.json", 0, 38),
    ("vk12.json", 0, 41),
    ("vk13.json", 2, 23),
    ("vk13.json", 4, 18),
    ("vk13.json", 4, 19),
    ("vk14.json", 0, 49),
]

for map_file, sub_idx, obj_idx in pairs:
    with open(f"{MOB_DIR}\\{map_file}", 'r', encoding='utf-8', errors='ignore') as f:
        m = json.load(f)
    sub = m['eventdata']['mapeventdat'][sub_idx]
    objs = sub.get('eventobj', [])
    if obj_idx < len(objs):
        o = objs[obj_idx]
        print(f"{map_file} sub[{sub_idx}] obj[{obj_idx}]: chip={o.get('chip')} pos=({o.get('pos_x')},{o.get('pos_y')}) dir={o.get('dir')} draw={o.get('draw_flag')} move={o.get('move_type')}")
    else:
        print(f"{map_file} sub[{sub_idx}] obj[{obj_idx}]: OUT OF BOUNDS (len={len(objs)})")

