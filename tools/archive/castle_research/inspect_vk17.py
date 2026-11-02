import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vk17.json', 'r', encoding='utf-8') as f:
    vk17 = json.load(f)

# Warps in vk17
print("--- Warps in vk17 ---")
for s_idx, s in enumerate(vk17['eventdata']['mapeventdat']):
    for e_idx, ev in enumerate(s.get('eventdat', [])):
        com = ev.get('eventCom', [])
        for i in range(len(com)-3):
            if com[i] == 31:
                print(f"Sub {s_idx} ev[{e_idx}]: Warp -> {com[i:i+6]}")
