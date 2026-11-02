import json

with open(r'D:\Modding\suikodum\Mobobehaviour\vk08.json', 'r', encoding='utf-8') as f:
    data = json.load(f)

events = data['eventdata']['mapeventdat'][0]['eventdat']
ev = events[33]
print("vk08 Sub 0 ev[33]:")
print("  etyp:", ev.get('etyp'))
print("  eventForm:", ev.get('eventForm'))
print("  eventCom:", ev.get('eventCom'))
