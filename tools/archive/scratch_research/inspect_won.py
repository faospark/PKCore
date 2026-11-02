import json

with open('D:/Modding/suikodum/Mobobehaviour/vk30.json', 'r', encoding='utf-8') as f:
    data = json.load(f)

sub = data['eventdata']['mapeventdat'][0]
won_indices = [15, 19, 23, 28, 32, 35, 39, 43, 47, 53, 57, 61]
for match_num, e_idx in enumerate(won_indices, 1):
    com = sub['eventdat'][e_idx]['eventCom']
    flag_ops = []
    for i in range(len(com)-2):
        if com[i] in [9, 10]: # SetFlag / ClearFlag
            op = 'Set' if com[i] == 9 else 'Clear'
            flag_ops.append(f'{op}({com[i+1]}, {com[i+2]})')
    print(f'Match {match_num} (ev[{e_idx}]) Won: {", ".join(flag_ops)}')
