import json
import subprocess

with open(r'D:\Modding\suikodum\Mobobehaviour\vk22.json', 'r', encoding='utf-8') as f:
    d = json.load(f)

submaps = d['eventdata']['mapeventdat']
print(f"Total Submaps in vk22: {len(submaps)}")

for s_idx, m in enumerate(submaps):
    objs = m.get('eventobj', [])
    fpnos = set(o.get('fpno') for o in objs if o.get('fpno', 0) > 0 and o.get('fpno', 0) < 150)
    print(f"\n--- Submap {s_idx} (okaz={m.get('okaz')}, evkaz={m.get('evkaz')}) ---")
    for fp in sorted(list(fpnos)):
        out = subprocess.check_output(f'd:\\Appz\\sym.bat {fp}', shell=True).decode('utf-8', errors='ignore')
        cname = "Unknown"
        for line in out.splitlines():
            if 'CHARACTER #' in line:
                cname = line.strip()
                break
        print(f"  fpno {fp}: {cname}")
