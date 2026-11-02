import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vk13.json', 'r', encoding='utf-8') as f:
    d = json.load(f)

med = d['eventdata']['mapeventdat']
for i, sub in enumerate(med):
    for j, ev in enumerate(sub.get('eventdat', [])):
        com = ev.get('eventCom', [])
        form = ev.get('eventForm', [])
        for k in range(len(com)):
            # opcode 12 in eventCom: ECSMapChenge or internal jump?
            # Let's check what opcode 12 is in ec_opcode_specs.txt!
            pass
