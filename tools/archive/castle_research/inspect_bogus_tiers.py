import json

MOB_DIR = r"D:\Modding\suikodum\Mobobehaviour"

def check_raw_tier_checks(map_file):
    with open(f"{MOB_DIR}\\{map_file}", 'r', encoding='utf-8', errors='ignore') as f:
        m = json.load(f)
    for sub_idx, sub in enumerate(m['eventdata']['mapeventdat']):
        for sc_idx, ev in enumerate(sub.get('eventdat', [])):
            form = ev.get('eventForm', [])
            for i in range(len(form)-2):
                if form[i] == 33 and form[i+2] in (9, 16, 21, 128, 254, 255):
                    print(f"[{map_file} Sub {sub_idx} ev[{sc_idx}]]: opcode 33 sequence: {form[i:i+6]}")
                    print(f"  full form: {form}")
                    print(f"  full com : {ev.get('eventCom', [])[:16]}")

for mf in ["vk10.json", "vk15.json", "vk13.json"]:
    check_raw_tier_checks(mf)

