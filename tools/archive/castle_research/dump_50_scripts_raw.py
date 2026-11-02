import json

data = json.load(open(r'd:\Appz\PKCore\tools\castle_all_anomalies.json'))
lv4 = [x for x in data['invalid_castle_levels'] if x.get('val') == 4]
MOB_DIR = r"D:\Modding\suikodum\Mobobehaviour"

print(f"Total lv4 scripts: {len(lv4)}")

for i, item in enumerate(lv4):
    map_file = item['map']
    sub_idx = item['submap']
    sc_idx = item['script']
    with open(f"{MOB_DIR}\\{map_file}", 'r', encoding='utf-8', errors='ignore') as f:
        m = json.load(f)
    sub = m['eventdata']['mapeventdat'][sub_idx]
    ev = sub['eventdat'][sc_idx]
    print(f"#{i+1:02d}: {map_file} sub[{sub_idx}] ev[{sc_idx}] etyp={ev.get('etyp')}")
    print(f"    form={ev.get('eventForm')}")
    print(f"    com={ev.get('eventCom')}")

