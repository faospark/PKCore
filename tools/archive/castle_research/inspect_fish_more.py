import re

for fname in ["fish_con.cs", "Overlay_fishing.cs"]:
    with open(rf'd:\Appz\Suisource\GSD2\GSD2\EventOverlayClass\{fname}', 'r', encoding='utf-8') as f:
        text = f.read()
    fields = re.findall(rf'{fname[:-3]}\.NativeFieldInfoPtr_(\w+)\s*=', text)
    methods = re.findall(r'public unsafe\s+([\w<>]+)\s+(\w+)\s*\(', text)
    print(f"\n{fname}: {len(fields)} fields, {len(methods)} methods")
    for ret, name in methods:
        print(f"  {ret} {name}()")
