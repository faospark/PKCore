import re

with open(r'd:\Appz\Suisource\GSD2\GSD2\GAME_DATA.cs', 'r', encoding='utf-8') as f:
    text = f.read()

# Match property names and types
props = re.findall(r'public unsafe (\S+) (\w+)\s*\{\s*get\s*\{[^}]*NativeFieldInfoPtr_(\w+)', text)
print(f"Total props found: {len(props)}")
for t, name, field in props:
    print(f"Field: {name} ({t})")
