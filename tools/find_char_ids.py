import os, re

for root, dirs, files in os.walk(r'd:\Appz\Suisource\GSD2'):
    for f in files:
        if any(k in f.lower() for k in ['chara', 'name', 'hero', 'party', 'const', 'face']):
            p = os.path.join(root, f)
            with open(p, 'r', encoding='utf-8', errors='ignore') as fp:
                t = fp.read()
            if 'Viktor' in t or 'Flik' in t or 'Shu' in t:
                print(f"Found character references in {f}")

