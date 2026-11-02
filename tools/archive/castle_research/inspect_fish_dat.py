import re

with open(r'd:\Appz\Suisource\GSD2\GSD2\EventOverlayClass\fish_dat.cs', 'r', encoding='utf-8') as f:
    text = f.read()

# Print fields in fish_dat
fields = re.findall(r'fish_dat\.NativeFieldInfoPtr_(\w+)\s*=', text)
print(f"Total fields in fish_dat: {len(fields)}")
for fld in fields:
    print(" ", fld)
