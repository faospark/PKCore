import re

with open(r'd:\Appz\Suisource\GSD2\GSD2\EVENTCON.cs', encoding='utf-8', errors='ignore') as f:
    text = f.read()

ec_methods = re.findall(r'public unsafe void (EC[a-zA-Z0-9_]+)\(sbyte cno\)', text)
print(f"Total EC opcode handlers in EVENTCON: {len(ec_methods)}")
for idx, m in enumerate(ec_methods):
    print(f"  Opcode [{idx:02d}]: {m}")

