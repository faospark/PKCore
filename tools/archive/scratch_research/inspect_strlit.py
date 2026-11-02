import json

with open(r'D:\Appz\Suisource\Il2CppDump\stringliteral.json', 'r', encoding='utf-8') as f:
    data = json.load(f)

targets = [
    '0x37F7200', '0x37F72C0', '0x37F7458', '0x37F7530', '0x37F75F0',
    '0x37F76C8', '0x37F7788', '0x37F7860', '0x37F7920', '0x37F79F8',
    '0x37F7398'
]

targets_lower = [t.lower() for t in targets]

for item in data:
    if item.get('address', '').lower() in targets_lower:
        print(f"{item.get('address')}: {item.get('value')}")
