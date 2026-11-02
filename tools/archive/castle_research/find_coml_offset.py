import re

with open(r'd:\Appz\Suisource\GSD2\GSD2\EVENTCON.cs', encoding='utf-8', errors='ignore') as f:
    text = f.read()

# Look for NativeFieldInfoPtr_coml assignment in static ctor
matches = re.findall(r'EVENTCON\.NativeFieldInfoPtr_coml\s*=\s*IL2CPP\.GetIl2CppField\([^,]+,\s*"coml"\);', text)
print("Matches:", len(matches))

