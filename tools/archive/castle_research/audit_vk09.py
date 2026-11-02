import json

MOB_DIR = r"D:\Modding\suikodum\Mobobehaviour"
with open(f"{MOB_DIR}\\vk09.json", 'r', encoding='utf-8', errors='ignore') as f:
    m = json.load(f)

sub = m['eventdata']['mapeventdat'][0]
events = sub['eventdat']
objs = sub['eventobj']

print(f"Total objects in vk09 sub[0]: {len(objs)}")
for ev_idx in [62, 63, 64, 65, 67]:
    ev = events[ev_idx]
    print(f"\nvk09 sub[0] ev[{ev_idx}] (etyp={ev.get('etyp')}):")
    print(f"  Form: {ev.get('eventForm')}")
    print(f"  Com : {ev.get('eventCom')}")

