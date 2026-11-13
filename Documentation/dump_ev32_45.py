import json

data = json.load(open('D:/Modding/suikodum/Mobobehaviour/vk08.json', 'r', encoding='utf-8'))
sub0 = data['eventdata']['mapeventdat'][0]

print("=== Submap 0 Event Objects ===")
for i, obj in enumerate(sub0.get('eventobj', [])):
    print(f"obj[{i:02d}]: {obj}")

print("\n=== Submap 0 Events 32 through 45 ===")
for i in range(32, min(46, len(sub0.get('eventdat', [])))):
    ev = sub0['eventdat'][i]
    print(f"\n--- ev[{i}] etyp={ev.get('etyp')} ---")
    print(f"  Form: {ev.get('eventForm')}")
    for a in ev.get('eventAction', []):
        print(f"  Action code={a.get('code')}: {a.get('data')}")
