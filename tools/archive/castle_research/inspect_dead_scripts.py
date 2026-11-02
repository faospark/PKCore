import json

MOB_DIR = r"D:\Modding\suikodum\Mobobehaviour"

for map_file, sub_idx, sc_idx in [("vk14.json", 1, 23), ("vk21.json", 1, 33)]:
    with open(f"{MOB_DIR}\\{map_file}", 'r', encoding='utf-8', errors='ignore') as f:
        m = json.load(f)
    sub = m['eventdata']['mapeventdat'][sub_idx]
    ev = sub['eventdat'][sc_idx]
    print(f"\n[{map_file} Submap {sub_idx} ev[{sc_idx}]] etyp={ev['etyp']}:")
    print("  eventForm:", ev['eventForm'])
    print("  eventCom :", ev['eventCom'])

