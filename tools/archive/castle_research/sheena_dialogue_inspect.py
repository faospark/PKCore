import json

MOB_DIR = r"D:\Modding\suikodum\Mobobehaviour"

sheena_targets = [
    ("vk18.json", 0, 2, "Dojo (near Yoshino)"),
    ("vk12.json", 1, 2, "Clinic (near Emilia)"),
    ("vk02.json", 9, 14, "Vault (near Raura)"),
    ("vk09.json", 1, 3, "Sanctuary (near Karen/Annallee)"),
    ("vk26.json", 0, 24, "Balcony (near Leona/Sierra)"),
    ("vk28.json", 0, 9, "Entrance Gate")
]

print("=== CHECKING DIALOGUE SCRIPTS FOR TALKING TO SHEENA ===")

for map_file, sub_idx, s_slot, desc in sheena_targets:
    with open(f"{MOB_DIR}\\{map_file}", 'r', encoding='utf-8', errors='ignore') as f:
        m = json.load(f)
    sub = m['eventdata']['mapeventdat'][sub_idx]
    events = sub['eventdat']
    
    # Check all scripts where etyp == 1 (Action/Talk) and eventForm checks target inspected == s_slot
    talk_scripts = []
    for ev_idx, ev in enumerate(events):
        form = ev.get('eventForm', [])
        # Look for op 48 (inspect target)
        for i in range(len(form)-1):
            if form[i] == 48 and form[i+1] == s_slot:
                talk_scripts.append((ev_idx, ev))
            elif form[i] == 31 and form[i+1] == s_slot: # alternate inspect op
                talk_scripts.append((ev_idx, ev))
    
    print(f"\n[{map_file} Sub {sub_idx}] {desc} (Sheena Slot obj[{s_slot:02d}]):")
    if talk_scripts:
        for ev_idx, ev in talk_scripts:
            print(f"  Script ev[{ev_idx:02d}]: form={ev['eventForm']} com={ev['eventCom']}")
    else:
        print("  No direct talk script targeting this object slot (uses standard NPC text or is inert).")
