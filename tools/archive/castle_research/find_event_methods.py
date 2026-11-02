import re

with open(r'd:\Appz\Suisource\GSD2\GSD2\EVENTCON.cs', encoding='utf-8', errors='ignore') as f:
    text = f.read()

# Search for opcode handlers or methods in EVENTCON
methods = re.findall(r'public unsafe [^\(]+\s+([a-zA-Z0-9_]+)\([^\)]*\)', text)
print(f"Total methods in EVENTCON: {len(methods)}")
event_methods = [m for m in methods if 'Event' in m or 'Form' in m or 'Com' in m or 'Op' in m or 'Cmd' in m]
print("Event-related methods:", event_methods)

