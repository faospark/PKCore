import json

MOB_DIR = r"D:\Modding\suikodum\Mobobehaviour"
with open(f"{MOB_DIR}\\vk19.json", 'r', encoding='utf-8', errors='ignore') as f:
    m = json.load(f)

sub = m['eventdata']['mapeventdat'][0]
for idx in [62, 63, 64, 65]:
    ev = sub['eventdat'][idx]
    print(f"\n[vk19.json Submap 0 ev[{idx}]] etyp={ev['etyp']}:")
    print("  eventForm:", ev['eventForm'])
    print("  eventCom :", ev['eventCom'])

