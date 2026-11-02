import re

with open(r'd:\Appz\Suisource\GSD2\GSD2\EventOverlayClass\ryo_an.cs', 'r', encoding='utf-8') as f:
    text = f.read()

methods = re.findall(r'public unsafe\s+([\w<>]+)\s+(\w+)\s*\(', text)
print(f"Total methods in ryo_an.cs: {len(methods)}")
for ret, name in methods:
    if any(k in name.lower() for k in ["shinsa", "point", "calc", "hyoka", "judge", "score", "win", "battle"]):
        print(f"  {ret} {name}()")
