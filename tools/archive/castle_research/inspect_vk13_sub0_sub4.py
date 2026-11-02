import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vk13.json', 'r', encoding='utf-8') as f:
    d = json.load(f)

med = d['eventdata']['mapeventdat']
ev90 = med[0]['eventdat'][90]
print("vk13 sub0 ev[90]:")
print("  etyp:", ev90.get('etyp'))
print("  form:", ev90.get('eventForm'))
print("  com:", ev90.get('eventCom'))

# Also check other transitions into sub4 or out of sub4
print("\nAll transitions in vk13 sub4:")
for j, ev in enumerate(med[4]['eventdat']):
    com = ev.get('eventCom', [])
    if 31 in com or 32 in com:
        print(f"  sub4 ev[{j}]: etyp={ev.get('etyp')}, form={ev.get('eventForm')}, com={com}")

print("\nAll transitions out of sub0 to any submap:")
for j, ev in enumerate(med[0]['eventdat']):
    com = ev.get('eventCom', [])
    if 31 in com or 32 in com:
        print(f"  sub0 ev[{j}]: etyp={ev.get('etyp')}, form={ev.get('eventForm')}, com={com}")
