import json

with open('D:/Modding/suikodum/Mobobehaviour/vk30.json', 'r', encoding='utf-8') as f:
    data = json.load(f)

sub = data['eventdata']['mapeventdat'][0]
for e_idx in range(12, 62):
    form = sub['eventdat'][e_idx]['eventForm']
    com = sub['eventdat'][e_idx]['eventCom']
    # Check what flags are tested
    print(f'ev[{e_idx}] Form: {form}')
    # Check what overlay is called or what messages are displayed
    msgs = []
    for i in range(len(com)-2):
        if com[i] == 24: # DispMsg
            msgs.append(f'DispMsg(obj={com[i+1]}, msg={com[i+3]})')
        if com[i] == 69: # Overlay
            msgs.append(f'Overlay(func={com[i+1]})')
    print(f'         Com: {msgs}')
