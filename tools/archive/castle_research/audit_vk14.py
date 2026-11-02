import json

MOB_DIR = r"D:\Modding\suikodum\Mobobehaviour"
with open(f"{MOB_DIR}\\vk14.json", 'r', encoding='utf-8', errors='ignore') as f:
    m = json.load(f)

sub = m['eventdata']['mapeventdat'][0]
events = sub['eventdat']
objs = sub['eventobj']

print(f"Total objects in vk14 sub[0]: {len(objs)}")
for ev_idx in [65, 66, 67]:
    ev = events[ev_idx]
    print(f"\nvk14 sub[0] ev[{ev_idx}] (etyp={ev.get('etyp')}):")
    print(f"  Form: {ev.get('eventForm')}")
    print(f"  Com : {ev.get('eventCom')}")

