import json

MOB_DIR = r"D:\Modding\suikodum\Mobobehaviour"
with open(f"{MOB_DIR}\\vk12.json", 'r', encoding='utf-8', errors='ignore') as f:
    m = json.load(f)

sub = m['eventdata']['mapeventdat'][0]
events = sub['eventdat']
objs = sub['eventobj']

print(f"Total objects in vk12 sub[0]: {len(objs)}")
print(f"Total events in vk12 sub[0]: {len(events)}")

# Inspect ev[25]
ev25 = events[25]
print("ev[25]:")
print("  etyp:", ev25.get('etyp'))
print("  form:", ev25.get('eventForm'))
print("  com :", ev25.get('eventCom'))

# Also check ev[15] and ev[18]
print("ev[15]:", events[15].get('eventForm'), events[15].get('eventCom'))
print("ev[18]:", events[18].get('eventForm'), events[18].get('eventCom'))

# Check scripts 20..30 to compare with ev[25]
for i in range(20, min(30, len(events))):
    print(f"ev[{i}]: etyp={events[i].get('etyp')} form={events[i].get('eventForm')} com={events[i].get('eventCom')}")

