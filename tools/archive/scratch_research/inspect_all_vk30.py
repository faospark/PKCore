import json

with open('D:/Modding/suikodum/Mobobehaviour/vk30.json', 'r', encoding='utf-8') as f:
    data = json.load(f)

sub = data['eventdata']['mapeventdat'][0]
for e_idx, edat in enumerate(sub.get('eventdat', [])):
    form = edat.get('eventForm', [])
    com = edat.get('eventCom', [])
    # Look for overlay opcode 66, 69, 108 etc.
    # What opcodes are in com?
    print(f'ev[{e_idx}] Form: {form}')
    print(f'         Com: {com[:30]}')
