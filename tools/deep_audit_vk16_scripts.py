import json

MOB_DIR = r"D:\Modding\suikodum\Mobobehaviour"
with open(f"{MOB_DIR}\\vk16.json", 'r', encoding='utf-8', errors='ignore') as f:
    m = json.load(f)

sub = m['eventdata']['mapeventdat'][0]
events = sub['eventdat']
objs = sub['eventobj']

with open(r'd:\Appz\PKCore\tools\ec_opcodes_dump.txt') as f:
    op_names = {}
    for line in f:
        if line.startswith('['):
            parts = line.split(': ')
            idx = int(parts[0].strip('[]'))
            op_names[idx] = parts[1].strip()

# Print detailed analysis of ev[2], ev[5], ev[6], ev[7], ev[8], ev[9], ev[10], ev[11], ev[14]
for ev_idx in [2, 5, 6, 7, 8, 9, 10, 11, 14]:
    ev = events[ev_idx]
    form = ev['eventForm']
    com = ev['eventCom']
    print(f"\n=======================================================")
    print(f"vk16 sub[0] ev[{ev_idx}] (etyp={ev.get('etyp')}):")
    print(f"  Form: {form}")
    print(f"  Com ({len(com)} bytes): {com}")

