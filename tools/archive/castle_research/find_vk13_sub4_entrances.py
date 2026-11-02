import json, glob, os

mobo_dir = r"d:\Modding\suikodum\Mobobehaviour"

print("Searching transitions leading into vk13 Submap 4...")
for path in glob.glob(os.path.join(mobo_dir, "vk*.json")):
    map_name = os.path.basename(path).replace(".json", "")
    with open(path, 'r', encoding='utf-8') as f:
        d = json.load(f)
    med = d.get('eventdata', {}).get('mapeventdat', [])
    for sub_idx, sub in enumerate(med):
        for ev_idx, ev in enumerate(sub.get('eventdat', [])):
            com = ev.get('eventCom', [])
            # opcode 31 is ECSMapChenge(submap, x, y) - within same map
            # opcode 32 is ECMapChenge(map_id, submap, x, y) - cross map
            for k in range(len(com)):
                if com[k] == 31 and k + 3 < len(com):
                    tgt_sub = com[k+1]
                    tgt_x = com[k+2]
                    tgt_y = com[k+3]
                    if map_name == "vk13" and tgt_sub == 4:
                        print(f"{map_name} sub{sub_idx} ev[{ev_idx}] internal ECSMapChenge -> vk13 sub4 at ({tgt_x}, {tgt_y})")
                elif com[k] == 32 and k + 4 < len(com):
                    tgt_map = com[k+1]
                    tgt_sub = com[k+2]
                    tgt_x = com[k+3]
                    tgt_y = com[k+4]
                    if tgt_map == 13 and tgt_sub == 4:
                        print(f"{map_name} sub{sub_idx} ev[{ev_idx}] ECMapChenge -> vk13 sub4 at ({tgt_x}, {tgt_y})")
                    elif tgt_map == 3:
                        pass
