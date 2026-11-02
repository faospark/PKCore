import re

with open(r'd:\Appz\Suisource\GSD2\GSD2\EVENTCON.cs', encoding='utf-8', errors='ignore') as f:
    text = f.read()

# Pattern for native method ptr assignments in EVENTCON
# EVENTCON.NativeMethodInfoPtr_ECMapCut_Private_Void_SByte_0 = IL2CPP.GetIl2CppMethodByToken(..., <token>);
tokens = re.findall(r'NativeMethodInfoPtr_([A-Za-z0-9_]+)\s*=\s*IL2CPP\.GetIl2CppMethodByToken\([^,]+,\s*(\d+)\)', text)
print(f"Total method tokens found: {len(tokens)}")

# Also look for AssignCmdFunction
for name, tok in tokens:
    if 'EC' in name or 'Assign' in name or 'Event' in name or 'etyp' in name:
        print(f"Token {tok}: {name}")

