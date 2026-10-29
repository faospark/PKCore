import json

MOB_DIR = r"D:\Modding\suikodum\Mobobehaviour"
with open(f"{MOB_DIR}\\vk16.json", 'r', encoding='utf-8', errors='ignore') as f:
    m = json.load(f)

sub = m['eventdata']['mapeventdat'][0]
events = sub['eventdat']
objs = sub['eventobj']
texts = m.get('textdata', [])

print(f"Total objects in vk16 sub[0]: {len(objs)}")
print(f"Total events in vk16 sub[0]: {len(events)}")
print(f"Total text messages in vk16: {len(texts)}")

# Print all objects
for i, o in enumerate(objs):
    print(f"Obj[{i:02d}]: otyp={o.get('otyp')} disp={o.get('disp')} fpno={o.get('fpno')} pos=({o.get('x')},{o.get('y')}) w={o.get('w')} h={o.get('h')}")

# Print text messages
print("\n=== Text Messages in vk16 ===")
for i, t in enumerate(texts[:20]):
    print(f"Msg[{i}]: {t}")

