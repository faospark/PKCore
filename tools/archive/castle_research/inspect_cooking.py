import os

base_dir = r"d:\Appz\Suisource\GSD2\GSD2\EventOverlayClass"
files = ["rbattle_h.cs", "ryo_an.cs", "rb_dat.cs", "Resipi.cs", "RBResipi.cs", "Runch.cs"]

for fname in files:
    fpath = os.path.join(base_dir, fname)
    if os.path.exists(fpath):
        print(f"\n=================== {fname} ===================")
        with open(fpath, "r", encoding="utf-8") as f:
            lines = f.readlines()
        print(f"Total lines: {len(lines)}")
        for line in lines:
            if "public unsafe" in line or "class" in line or "enum" in line or "struct" in line:
                if any(k in line for k in ["Score", "Judge", "Shinsa", "Point", "Cook", "Resipi", "Menu", "Winner", "RB_", "FAVORITE"]):
                    print("  ", line.strip())
