import json

with open(r'd:\Appz\PKCore\tools\ec_opcodes_dump.txt') as f:
    op_names = {}
    for line in f:
        if line.startswith('['):
            parts = line.split(': ')
            idx = int(parts[0].strip('[]'))
            op_names[idx] = parts[1].strip()

# Target complex scripts
targets = [
    ("vk12.json", 0, 25),
    ("vk13.json", 4, 12),
    ("vk13.json", 4, 13),
    ("vk16.json", 0, 2),
    ("vk16.json", 0, 5),
    ("vk16.json", 0, 6),
    ("vk16.json", 0, 7),
    ("vk16.json", 0, 8),
    ("vk16.json", 0, 9),
    ("vk16.json", 0, 10),
    ("vk16.json", 0, 11),
    ("vk16.json", 0, 14),
]

MOB_DIR = r"D:\Modding\suikodum\Mobobehaviour"

for map_file, sub_idx, ev_idx in targets:
    with open(f"{MOB_DIR}\\{map_file}", 'r', encoding='utf-8', errors='ignore') as f:
        m = json.load(f)
    sub = m['eventdata']['mapeventdat'][sub_idx]
    ev = sub['eventdat'][ev_idx]
    com = ev['eventCom']
    form = ev['eventForm']
    print(f"\n=======================================================")
    print(f"{map_file} sub[{sub_idx}] ev[{ev_idx}] (etyp={ev.get('etyp')})")
    print(f"eventForm: {form}")
    print(f"eventCom raw ({len(com)} bytes): {com}")
    
    # Let's inspect bytes
    print("Commands:")
    i = 0
    while i < len(com):
        b = com[i]
        if b == 254:
            print(f"  [{i:02d}] 254: ECommandLineEnd")
            break
        if b == 255:
            print(f"  [{i:02d}] 255: NOP/Separator")
            i += 1
            continue
        opname = op_names.get(b, f"UNKNOWN_OP_{b}")
        print(f"  [{i:02d}] Opcode {b} ({opname}): trailing bytes {com[i+1:min(len(com), i+10)]}")
        # Advance by 1 for inspection
        i += 1

