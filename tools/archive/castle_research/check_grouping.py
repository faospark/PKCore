import json

with open(r'd:\Appz\PKCore\tools\decoded_50_scripts.json') as f:
    scripts = json.load(f)

# Group by map
grouped = {}
for s in scripts:
    m = s['map']
    if m not in grouped:
        grouped[m] = []
    grouped[m].append(s)

print(f"Grouped into {len(grouped)} maps:")
for m, lst in grouped.items():
    print(f"  {m}: {len(lst)} scripts")

