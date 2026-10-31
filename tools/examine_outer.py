import json
import subprocess

mobs = ["vc18", "vd02", "vd06", "vg15"]

for m in mobs:
    p = f"D:\\Modding\\suikodum\\Mobobehaviour\\{m}.json"
    with open(p, 'r', encoding='utf-8') as f:
        d = json.load(f)
    print(f"\n==========================================")
    print(f"=== MAP {m} (Total Submaps: {len(d['eventdata']['mapeventdat'])}) ===")
    print(f"==========================================")
    for s_idx, sm in enumerate(d['eventdata']['mapeventdat']):
        objs = sm.get('eventobj', [])
        fpnos = set(o.get('fpno') for o in objs if o.get('fpno', 0) > 0 and o.get('fpno', 0) < 150)
        char_list = []
        for fp in sorted(list(fpnos)):
            out = subprocess.check_output(f'd:\\Appz\\sym.bat {fp}', shell=True).decode('utf-8', errors='ignore')
            for line in out.splitlines():
                if 'CHARACTER #' in line:
                    char_list.append(line.strip())
                    break
        print(f"Submap {s_idx} (okaz={sm.get('okaz')}, evkaz={sm.get('evkaz')}):")
        for c in char_list[:8]:
            print("   ", c)
