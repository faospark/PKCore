import json

with open('D:/Modding/suikodum/Mobobehaviour/vk06.json', 'r') as f:
    data = json.load(f)

sub = data['eventdata']['mapeventdat'][1]
for i in range(13, min(20, len(sub['eventdat']))):
    edat = sub['eventdat'][i]
    print(f'=== Match schedule {i} ===')
    print('Form:', edat.get('eventForm', []))
    print('Com:', edat.get('eventCom', []))
