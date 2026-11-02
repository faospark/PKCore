import json

MOB_DIR = r"D:\Modding\suikodum\Mobobehaviour"
with open(f"{MOB_DIR}\\vk03.json", 'r', encoding='utf-8', errors='ignore') as f:
    m = json.load(f)

sub = m['eventdata']['mapeventdat'][0]
events = sub['eventdat']
objs = sub['eventobj']

print("=== All scripts checking base_lv in vk03 sub[0] ===")
for i, ev in enumerate(events):
    form = ev.get('eventForm', [])
    for j in range(len(form)-2):
        if form[j] == 33: # base_lv check
            cmp_op = form[j+1]
            val = form[j+2]
            print(f"ev[{i:03d}]: etyp={ev.get('etyp')} base_lv (cmp={cmp_op}, val={val}) form={form} com={ev.get('eventCom')}")

