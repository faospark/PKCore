with open(r'd:\Appz\Suisource\GSD2\GSD2\EventOverlayClass\Overlay_rbattle.cs', 'r', encoding='utf-8') as f:
    lines = f.readlines()

print(f"Total lines in Overlay_rbattle.cs: {len(lines)}")
for i in range(min(80, len(lines))):
    print(lines[i].rstrip())
