import json

MOB_DIR = r"D:\Modding\suikodum\Mobobehaviour"
with open(f"{MOB_DIR}\\vk12.json", 'r', encoding='utf-8', errors='ignore') as f:
    m = json.load(f)

objs = m['eventdata']['mapeventdat'][0]['eventobj']
for i in range(30, len(objs)):
    print(f"Obj[{i}]: {objs[i]}")

