import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vk13.json', 'r', encoding='utf-8') as f:
    d = json.load(f)

med = d['eventdata']['mapeventdat']
for i, sub in enumerate(med):
    mapno = sub.get('mapno')
    okaz = sub.get('okaz')
    evkaz = sub.get('evkaz')
    print(f"Submap {i}: mapno={mapno}, okaz={okaz}, evkaz={evkaz}")
    for j, ev in enumerate(sub.get('eventdat', [])):
        com = ev.get('eventCom', [])
        # print if transitions
        for k in range(len(com)):
            if com[k] == 31 and k + 3 < len(com):
                print(f"  ev[{j}] ECSMapChenge -> submap {com[k+1]} at ({com[k+2]}, {com[k+3]})")
            elif com[k] == 32 and k + 4 < len(com):
                print(f"  ev[{j}] ECMapChenge -> map {com[k+1]} sub {com[k+2]} at ({com[k+3]}, {com[k+4]})")
