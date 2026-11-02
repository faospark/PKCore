import re

with open(r'd:\Appz\Suisource\GSD2\GSD2\EventOverlayClass\fish_cal.cs', 'r', encoding='utf-8') as f:
    text = f.read()

methods = re.findall(r'public unsafe\s+([\w<>]+)\s+(\w+)\s*\(', text)
print(f"Total methods in fish_cal: {len(methods)}")
for ret, name in methods:
    print(f"  {ret} {name}()")
