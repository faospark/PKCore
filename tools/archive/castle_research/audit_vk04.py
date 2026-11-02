import json

MOB_DIR = r"D:\Modding\suikodum\Mobobehaviour"
with open(f"{MOB_DIR}\\vk04.json", 'r', encoding='utf-8', errors='ignore') as f:
    m = json.load(f)

sub = m['eventdata']['mapeventdat'][0]
objs = sub.get('eventobj', [])
events = sub['eventdat']
print(f"Total objs in vk04 sub[0]: {len(objs)}")
for ev_idx in [22, 23]:
    ev = events[ev_idx]
    print(f"ev[{ev_idx}] (etyp={ev.get('etyp')}):")
    print(f"  Form: {ev.get('eventForm')}")
    print(f"  Com : {ev.get('eventCom')}")

