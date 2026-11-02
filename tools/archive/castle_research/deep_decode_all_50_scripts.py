import json, os

MOB_DIR = r"D:\Modding\suikodum\Mobobehaviour"
data = json.load(open(r'd:\Appz\PKCore\tools\castle_all_anomalies.json'))
lv4 = [x for x in data['invalid_castle_levels'] if x.get('val') == 4]

# Opcode name dictionary
with open(r'd:\Appz\PKCore\tools\ec_opcodes_dump.txt') as f:
    op_names = {}
    for line in f:
        if line.startswith('['):
            parts = line.split(': ')
            idx = int(parts[0].strip('[]'))
            op_names[idx] = parts[1].strip()

# Map human names
MAP_NAMES = {
    "vk02.json": "HQ 1F/B1: Vault, Richmond Detective Agency & Library Hallways",
    "vk03.json": "HQ Grounds: Yuzu's Farm & Pasture Enclosure",
    "vk04.json": "HQ 2F: Tavern, Bar & Kitchen Facility",
    "vk08.json": "HQ Docks: Waterfront Harbour & Boat Landing",
    "vk09.json": "HQ Central Courtyard: Main Castle Entrance & Exterior Grounds",
    "vk11.json": "HQ 3F: Guest Quarters & Living Accommodations",
    "vk12.json": "HQ 1F: Huan's Clinic & Medical Infirmary",
    "vk13.json": "HQ Interior: Private Residences & Personal Quarters",
    "vk14.json": "HQ Rooftop: Parapet Observation Platform & Watchtower",
    "vk16.json": "HQ Memorial: Castle Graveyard & Hero Memorial Grounds"
}

def decode_eventform(form):
    i = 0
    conds = []
    while i < len(form):
        b = form[i]
        if b == 254:
            conds.append("END")
            break
        elif b == 255:
            conds.append("SEP")
            i += 1
        elif b == 1:
            conds.append(f"X_Range({form[i+1]}..{form[i+2]})")
            i += 3
        elif b == 2:
            conds.append(f"Y_Range({form[i+1]}..{form[i+2]})")
            i += 3
        elif b == 3:
            conds.append(f"FlagIsSet({form[i+1]}, bit 0x{form[i+2]:02X})")
            i += 3
        elif b == 4:
            conds.append(f"FlagNotSet({form[i+1]}, bit 0x{form[i+2]:02X})")
            i += 3
        elif b == 5:
            conds.append(f"FacingDir({form[i+1]}..{form[i+2]})")
            i += 3
        elif b == 6:
            conds.append(f"MoveMode({form[i+1]})")
            i += 2
        elif b == 9:
            conds.append(f"ButtonPress(0x{form[i+1]:02X})")
            i += 2
        elif b == 23:
            conds.append(f"WkFlagIsSet({form[i+1]}, bit 0x{form[i+2]:02X})")
            i += 3
        elif b == 24:
            conds.append(f"WkFlagNotSet({form[i+1]}, bit 0x{form[i+2]:02X})")
            i += 3
        elif b == 33:
            cmp_types = {0: "==", 1: ">=", 2: "<="}
            cmp_str = cmp_types.get(form[i+1], f"cmp{form[i+1]}")
            conds.append(f"CastleTier {cmp_str} {form[i+2]}")
            i += 3
        elif b == 34:
            conds.append(f"ObjPosCheck(val1={form[i+1]}, val2={form[i+2]})")
            i += 3
        elif b == 35:
            conds.append(f"ObjStateCheck(val1={form[i+1]}, val2={form[i+2]})")
            i += 3
        elif b == 36:
            conds.append(f"Check36({form[i+1]}, {form[i+2]})")
            i += 3
        elif b == 37:
            conds.append(f"Check37({form[i+1:i+6]})")
            i += 6
        else:
            conds.append(f"Op{b}")
            i += 1
    return " AND ".join([c for c in conds if c not in ("SEP", "END")])

print(f"Total scripts to decode: {len(lv4)}")

decoded_scripts = []
for idx, item in enumerate(lv4):
    map_file = item['map']
    sub_idx = item['submap']
    sc_idx = item['script']
    
    with open(f"{MOB_DIR}\\{map_file}", 'r', encoding='utf-8', errors='ignore') as f:
        m = json.load(f)
    sub = m['eventdata']['mapeventdat'][sub_idx]
    ev = sub['eventdat'][sc_idx]
    objs = sub.get('eventobj', [])
    
    etyp_name = {1: "Action (Talk/Inspect)", 2: "MapInit (Autorun On Load)", 128: "TriggerZone (Step-On)"}.get(ev.get('etyp'), f"Type_{ev.get('etyp')}")
    
    form_str = decode_eventform(ev.get('eventForm', []))
    
    decoded_scripts.append({
        'index': idx + 1,
        'map': map_file,
        'map_title': MAP_NAMES.get(map_file, map_file),
        'submap': sub_idx,
        'script': sc_idx,
        'etyp': ev.get('etyp'),
        'etyp_name': etyp_name,
        'form_raw': ev.get('eventForm', []),
        'form_decoded': form_str,
        'com_raw': ev.get('eventCom', []),
        'total_objs': len(objs)
    })

with open(r'd:\Appz\PKCore\tools\decoded_50_scripts.json', 'w') as out:
    json.dump(decoded_scripts, out, indent=2)

print("Saved decoded_50_scripts.json successfully!")

