import json, glob, os

mobo_dir = r"d:\Modding\suikodum\Mobobehaviour"
print("Finding all transitions into vk13 across ALL maps:")
for path in glob.glob(os.path.join(mobo_dir, "vk*.json")):
    map_name = os.path.basename(path).replace(".json", "")
    with open(path, 'r', encoding='utf-8') as f:
        d = json.load(f)
    med = d.get('eventdata', {}).get('mapeventdat', [])
    for sub_idx, sub in enumerate(med):
        for ev_idx, ev in enumerate(sub.get('eventdat', [])):
            com = ev.get('eventCom', [])
            form = ev.get('eventForm', [])
            for k in range(len(com)):
                if com[k] == 32 and k + 4 < len(com) and com[k+1] == 13:
                    tgt_sub = com[k+2]
                    tgt_x = com[k+3]
                    tgt_y = com[k+4]
                    print(f"{map_name} sub{sub_idx} ev[{ev_idx}] -> vk13 sub{tgt_sub} at ({tgt_x}, {tgt_y}) | form={form}")
