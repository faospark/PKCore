import json
import os

maps_to_audit = [
    "vc18", "vd02", "vd06", "vg15",
    "vk02", "vk03", "vk04", "vk08", "vk09",
    "vk11", "vk12", "vk13", "vk14", "vk16"
]

mobs_dir = r"D:\Modding\suikodum\Mobobehaviour"

# Load character dictionary
# We can load g2_name_h from GSD2 symbol index or a map
chars = {
    1: "Riou", 2: "Nanami", 3: "Viktor", 4: "Flik", 5: "Rina", 6: "Eilie", 7: "Bolgan",
    8: "Tai Ho", 9: "Yam Koo", 10: "Luc", 11: "Shu", 12: "Apple", 13: "Klaus", 14: "Kiba",
    18: "Flik", 19: "Hoi", 24: "Freed Y", 25: "Karen", 35: "Tsai", 36: "Taki", 40: "Teresa",
    52: "Freed Y (alt)", 54: "Apple (alt)", 55: "Nina", 88: "Fitcher", 108: "Karen (alt)",
    112: "Annallee", 113: "Pico", 114: "Alberto"
}

print(f"{'Map':<6} | {'Sub':<3} | {'Objects':<7} | {'Scripts':<7} | {'Identified Characters & Key Objects'}")
print("-" * 80)

for m in maps_to_audit:
    p = os.path.join(mobs_dir, f"{m}.json")
    if not os.path.exists(p):
        print(f"{m:<6} | NOT FOUND")
        continue
    with open(p, 'r', encoding='utf-8') as f:
        d = json.load(f)
    
    submaps = d.get('eventdata', {}).get('mapeventdat', [])
    for s_idx, sm in enumerate(submaps):
        okaz = sm.get('okaz', 0)
        evkaz = sm.get('evkaz', 0)
        found_chars = []
        for o in sm.get('eventobj', []):
            fp = o.get('fpno', 0)
            if fp in chars:
                if chars[fp] not in found_chars:
                    found_chars.append(chars[fp])
            elif fp > 0 and fp < 150:
                # possible character ID
                found_chars.append(f"Chara#{fp}")
        
        char_str = ", ".join(found_chars[:6]) if found_chars else "Props / Generic NPCs / Warps"
        print(f"{m:<6} | {s_idx:<3} | {okaz:<7} | {evkaz:<7} | {char_str}")
