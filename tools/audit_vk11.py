import json

MOB_DIR = r"D:\Modding\suikodum\Mobobehaviour"
with open(f"{MOB_DIR}\\vk11.json", 'r', encoding='utf-8', errors='ignore') as f:
    m = json.load(f)

for sub_idx, ev_list in [(0, [29, 31, 32]), (1, [5]), (2, [26, 28])]:
    sub = m['eventdata']['mapeventdat'][sub_idx]
    objs = sub.get('eventobj', [])
    events = sub['eventdat']
    print(f"\n=== vk11 submap [{sub_idx}] (total objs: {len(objs)}) ===")
    for ev_idx in ev_list:
        ev = events[ev_idx]
        print(f"ev[{ev_idx}] (etyp={ev.get('etyp')}):")
        print(f"  Form: {ev.get('eventForm')}")
        print(f"  Com : {ev.get('eventCom')}")

