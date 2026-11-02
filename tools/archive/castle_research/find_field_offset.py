# Let's inspect the getters in GAME_DATA.cs to see how offsets are obtained or check NativeFieldInfoPtr
import re

with open(r'd:\Appz\Suisource\GSD2\GSD2\GAME_DATA.cs', 'r', encoding='utf-8') as f:
    text = f.read()

# Let's see how GAME_DATA.NativeFieldInfoPtr_ero_lv is initialized
m = re.search(r'GAME_DATA\.NativeFieldInfoPtr_ero_lv\s*=\s*IL2CPP\.GetIl2CppField\([^,]+,\s*"([^"]+)"\);', text)
if m:
    print("Found field name:", m.group(1))

# Let's also look at all fields in the static ctor of GAME_DATA to see their order!
fields = re.findall(r'GAME_DATA\.NativeFieldInfoPtr_(\w+)\s*=\s*IL2CPP\.GetIl2CppField\([^,]+,\s*"([^"]+)"\);', text)
print(f"Total fields in static ctor: {len(fields)}")
for idx, (f_var, f_name) in enumerate(fields):
    print(f"  [{idx:2d}] {f_name}")
