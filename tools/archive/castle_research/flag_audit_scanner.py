import os
import json
import re

MOBO_DIR = r"D:\Modding\suikodum\Mobobehaviour"
TEXT_PATH = r"D:\Modding\suikodum\TextAsset\text_gsd2_en"

print("Loading text asset...")
with open(TEXT_PATH, "r", encoding="utf-8") as f:
    text_data = json.load(f)

# Index text by ID
text_by_id = {item["id"]: item["text"] for item in text_data.get("textList", []) if "id" in item and "text" in item}
print(f"Loaded {len(text_by_id)} dialogue strings.")

# Map prefixes: e.g. "ve04" -> 5, 4
AREA_PREFIX_MAP = {
    'va': 1, 'vb': 2, 'vc': 3, 'vd': 4, 've': 5,
    'vf': 6, 'vg': 7, 'vh': 8, 'vi': 9, 'vj': 10,
    'vk': 11, 'vl': 12, 'vm': 13, 'vn': 14, 'vo': 15,
    'vp': 16, 'vq': 17, 'vr': 18, 'vs': 19, 'vt': 20,
    'vu': 21, 'vv': 22, 'vw': 23, 'vx': 24, 'vy': 25, 'vz': 26,
    'wg': 27, 'wf': 28
}

def parse_map_digits(map_name):
    # e.g. "ve04" -> area=5, room=4
    m = re.match(r'^([a-z]{2})(\d+)', map_name.lower())
    if m:
        prefix, room_str = m.groups()
        area_code = AREA_PREFIX_MAP.get(prefix, 0)
        room_code = int(room_str)
        return area_code, room_code
    return 0, 0

# Results by flag index (0..255)
# flag -> { 'sets': [], 'checks': [], 'maps': set(), 'texts': [] }
flag_intel = {i: {'sets': [], 'checks': [], 'maps': set(), 'dialogue': []} for i in range(256)}

# Scan map files
files = [f for f in os.listdir(MOBO_DIR) if f.endswith(".json") and not "_" in f[:-5]]
print(f"Scanning {len(files)} primary map files...")

for fname in sorted(files):
    fpath = os.path.join(MOBO_DIR, fname)
    map_base = fname[:-5]
    area_code, room_code = parse_map_digits(map_base)
    text_prefix_base = 1000000000 + (area_code * 1000000) + (room_code * 10000)

    try:
        with open(fpath, "r", encoding="utf-8") as f:
            data = json.load(f)
    except Exception as e:
        continue

    eventdata = data.get("eventdata", {})
    mapeventdat = eventdata.get("mapeventdat", [])

    for room_idx, med in enumerate(mapeventdat):
        eventdat_list = med.get("eventdat", [])
        eventobj_list = med.get("eventobj", [])

        for ev_idx, ed in enumerate(eventdat_list):
            if not ed:
                continue

            form = ed.get("eventForm", [])
            com = ed.get("eventCom", [])

            # 1. Parse eventForm conditions: [3, flag, mask] (On), [4, flag, mask] (Off)
            i = 0
            while i < len(form):
                op = form[i]
                if op in (3, 4) and i + 2 < len(form):
                    flg = form[i + 1]
                    mask = form[i + 2]
                    if 0 <= flg < 256 and mask in (1, 2, 4, 8, 16, 32, 64, 128):
                        flag_intel[flg]['checks'].append({
                            'map': f"{map_base}[{room_idx}]",
                            'ev_idx': ev_idx,
                            'type': 'REQUIRE_ON' if op == 3 else 'REQUIRE_OFF',
                            'mask': mask
                        })
                        flag_intel[flg]['maps'].add(map_base)
                    i += 3
                elif op in (23, 24) and i + 2 < len(form): # Chara recruitment checks
                    i += 3
                elif op == 33 and i + 2 < len(form): # Base level
                    i += 3
                elif op == 255 or op == 254:
                    i += 1
                else:
                    i += 1

            # 2. Parse eventCom execution: [9, flag, mask] (Set), [10, flag, mask] (Clear)
            # Also extract nearby dialogue IDs
            i = 0
            found_sets = []
            found_msgs = []

            while i < len(com):
                op = com[i]
                if op == 9 and i + 2 < len(com):
                    flg = com[i + 1]
                    mask = com[i + 2]
                    if 0 <= flg < 256:
                        found_sets.append((flg, mask, 'SET'))
                    i += 3
                elif op == 10 and i + 2 < len(com):
                    flg = com[i + 1]
                    mask = com[i + 2]
                    if 0 <= flg < 256:
                        found_sets.append((flg, mask, 'CLEAR'))
                    i += 3
                elif op in (127, 128) and i + 1 < len(com):
                    msg_idx = com[i + 1]
                    # Potential text IDs: text_prefix_base + msg_idx
                    # or room variations
                    for pot_id in (text_prefix_base + msg_idx, text_prefix_base + (room_idx * 1000) + msg_idx):
                        if pot_id in text_by_id:
                            clean_text = text_by_id[pot_id].replace("∠", " ").replace("∨", " ").replace("♂㈱", "Riou").replace("♂①", "HQ").strip()
                            if clean_text and clean_text not in found_msgs:
                                found_msgs.append(clean_text[:90])
                    i += 2
                else:
                    i += 1

            # Associate sets with dialogue found in the same script
            for flg, mask, action in found_sets:
                flag_intel[flg]['sets'].append({
                    'map': f"{map_base}[{room_idx}]",
                    'ev_idx': ev_idx,
                    'action': action,
                    'mask': mask,
                    'dialogue': found_msgs[:2]
                })
                flag_intel[flg]['maps'].add(map_base)
                for txt in found_msgs[:2]:
                    if txt not in flag_intel[flg]['dialogue']:
                        flag_intel[flg]['dialogue'].append(txt)

# Print Summary of flags with verified sets & dialogue
print("\n" + "="*80)
print("VERIFIED FLAG AUDIT SUMMARY")
print("="*80)

verified_count = 0
for flg in range(256):
    info = flag_intel[flg]
    if info['sets'] or info['dialogue']:
        verified_count += 1
        maps_str = ", ".join(sorted(list(info['maps'])))
        set_masks = set(s['mask'] for s in info['sets'])
        print(f"\n[Flag {flg:3d}] Maps: {maps_str} | Active Masks: {sorted(list(set_masks))}")
        if info['dialogue']:
            for d in info['dialogue'][:2]:
                print(f"   💬 \"{d}\"")

print(f"\nTotal flags with verified occurrences: {verified_count} / 256")

# Export to structured JSON ledger
export_data = {}
for flg in range(256):
    info = flag_intel[flg]
    if info['sets'] or info['dialogue'] or info['checks']:
        export_data[flg] = {
            'maps': sorted(list(info['maps'])),
            'set_masks': sorted(list(set(s['mask'] for s in info['sets']))),
            'check_masks': sorted(list(set(c['mask'] for c in info['checks']))),
            'dialogue_samples': info['dialogue'][:4]
        }

ledger_path = r"d:\Appz\PKCore\tools\verified_flags_ledger.json"
with open(ledger_path, "w", encoding="utf-8") as f:
    json.dump(export_data, f, indent=2, ensure_ascii=False)

print(f"Exported {len(export_data)} verified flags to {ledger_path}")
