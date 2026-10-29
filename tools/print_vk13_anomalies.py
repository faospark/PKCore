import json

data = json.load(open(r'd:\Appz\PKCore\tools\castle_all_anomalies.json'))
for cat in data:
    for item in data[cat]:
        if isinstance(item, dict) and 'vk13' in item.get('map', ''):
            print(cat, item)
