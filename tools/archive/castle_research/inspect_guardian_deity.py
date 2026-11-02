import os, re

base_dir = r"d:\Appz\Suisource\GSD2\GSD2\EventOverlayClass"
files = ["syugoitm.cs", "syugoHan.cs", "syugoSet.cs", "h_shugo.cs", "SekizouCheck.cs"]

for fname in files:
    fpath = os.path.join(base_dir, fname)
    if os.path.exists(fpath):
        print(f"\n=================== {fname} ===================")
        with open(fpath, "r", encoding="utf-8") as f:
            lines = f.readlines()
        print(f"Total lines: {len(lines)}")
        # Print class definitions and methods
        for line in lines:
            if "public unsafe" in line or "class" in line or "enum" in line or "struct" in line:
                print("  ", line.strip())
