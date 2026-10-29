import json

data = json.load(open(r'd:\Appz\PKCore\tools\castle_all_anomalies.json'))
for item in data.get('invalid_castle_levels', []):
    if 'vk13' in item.get('map', ''):
        print(item)
