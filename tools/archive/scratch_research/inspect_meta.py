import json

with open(r'D:\Appz\Suisource\Il2CppDump\script.json', 'r', encoding='utf-8') as f:
    data = json.load(f)

for m in data.get('ScriptMetadataMethod', []):
    if m.get('MethodAddress') == 34802016 or m.get('Address') == 34802016:
        print(m)

for m in data.get('ScriptMetadata', []):
    if m.get('Address') in [0x18386e600, 0x386e600, 34802016]:
        print(m)
