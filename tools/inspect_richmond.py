import os

base_dir = r"d:\Appz\Suisource\GSD2\GSD2\EventOverlayClass"
files = ["tantei.cs", "tantei_h.cs", "TANTEI_WORK.cs", "t_phase.cs", "t_main.cs"]

for fname in files:
    fpath = os.path.join(base_dir, fname)
    if os.path.exists(fpath):
        print(f"\n=================== {fname} ===================")
        with open(fpath, "r", encoding="utf-8") as f:
            lines = f.readlines()
        print(f"Total lines: {len(lines)}")
        for line in lines:
            if "public unsafe" in line or "class" in line or "enum" in line:
                if any(k in line.lower() for k in ["coin", "money", "cost", "tantei", "invest", "fail", "win", "rand"]):
                    print("  ", line.strip())
