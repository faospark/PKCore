import json

data = json.load(open(r'd:\Appz\PKCore\tools\castle_all_anomalies.json'))
lv4 = [x for x in data['invalid_castle_levels'] if x.get('val') == 4]

MOB_DIR = r"D:\Modding\suikodum\Mobobehaviour"

print(f"=== ANALYZING CUT 'CASTLE LEVEL 5' (base_lv >= 4) SCRIPTS ({len(lv4)} scripts) ===")

for item in lv4[:15]:
    map_file = item['map']
    sub_idx = item['submap']
    sc_idx = item['script']
    
    with open(f"{MOB_DIR}\\{map_file}", 'r', encoding='utf-8', errors='ignore') as f:
        m = json.load(f)
    
    sub = m['eventdata']['mapeventdat'][sub_idx]
    ev = sub['eventdat'][sc_idx]
    form = ev['eventForm']
    com = ev['eventCom']
    etyp = ev['etyp']
    
    print(f"\n[{map_file} Submap {sub_idx} ev[{sc_idx}]] (etyp={etyp}):")
    print(f"  eventForm: {form}")
    print(f"  eventCom : {com[:20]} ... (len={len(com)})")

