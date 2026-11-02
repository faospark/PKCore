import os

base_dir = r"d:\Appz\Suisource\GSD2\GSD2\EventOverlayClass"
files = ["ff_event.cs", "f_phase.cs", "furo_h.cs", "r_action_h.cs", "peeping.cs"]

for fname in files:
    fpath = os.path.join(base_dir, fname)
    if os.path.exists(fpath):
        print(f"\n=================== {fname} ===================")
        with open(fpath, "r", encoding="utf-8") as f:
            lines = f.readlines()
        print(f"Total lines: {len(lines)}")
        for line in lines:
            if "public unsafe" in line or "class" in line or "enum" in line or "CheckFuro" in line:
                print("  ", line.strip())
