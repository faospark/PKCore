import json

with open(r'D:\Modding\suikodum\Mobobehaviour\vk02.json', 'r', encoding='utf-8') as f:
    d = json.load(f)

print(f"Total Submaps in vk02: {len(d['eventdata']['mapeventdat'])}")

# Check each submap objects
for s_idx, m in enumerate(d['eventdata']['mapeventdat']):
    objs = m.get('eventobj', [])
    obj_info = []
    for o in objs:
        fp = o.get('fpno')
        otyp = o.get('otyp')
        pos = f"({o.get('x')}, {o.get('y')})"
        obj_info.append(f"fpno={fp} otyp={otyp} @ {pos}")
    print(f"\n--- Submap {s_idx} (okaz={m.get('okaz')}, evkaz={m.get('evkaz')}) ---")
    for line in obj_info[:15]:
        print("  ", line)
    if len(obj_info) > 15:
        print(f"   ... (+{len(obj_info)-15} more objects)")
