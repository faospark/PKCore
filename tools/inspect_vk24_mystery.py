import json

with open(r'D:\Modding\suikodum\Mobobehaviour\vk24.json', 'r', encoding='utf-8') as f:
    data = json.load(f)

events = data['eventdata']['mapeventdat'][0]['eventdat']

for ev_idx in range(128, min(142, len(events))):
    ev = events[ev_idx]
    print(f"\n--- vk24 Sub 0 ev[{ev_idx}] (etyp: {ev.get('etyp')}) ---")
    print("  eventForm:", ev.get('eventForm'))
    print("  eventCom: ", ev.get('eventCom')[:15])
