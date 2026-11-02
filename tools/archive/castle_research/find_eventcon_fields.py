import re

with open(r'd:\Appz\Suisource\GSD2\GSD2\EVENTCON.cs', encoding='utf-8', errors='ignore') as f:
    text = f.read()

fields = re.findall(r'public unsafe (\w+(?:<[^>]+>)?)\s+(\w+)\s*\{', text)
for ftype, fname in fields:
    if any(k in fname.lower() for k in ['map', 'evn', 'event', 'mdat', 'obj', 'form', 'com', 'line', 'hito']):
        print(f"Field: {ftype} {fname}")

