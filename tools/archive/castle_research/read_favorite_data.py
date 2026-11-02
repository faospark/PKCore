with open(r'd:\Appz\Suisource\GSD2\GSD2\EventOverlayClass\rb_dat.cs', 'r', encoding='utf-8') as f:
    lines = f.readlines()

print(f"Total lines in rb_dat.cs: {len(lines)}")
# Find where favorite or other data tables are declared
for i, line in enumerate(lines):
    if "favorite" in line or "shinsa" in line.lower() or "point" in line.lower() or "table" in line.lower():
        print(f"L{i}: {line.strip()[:100]}")
