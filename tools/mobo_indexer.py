import os
import json
import sys

DIR_PATH = r"D:\Modding\suikodum\Mobobehaviour"

def inspect_range(start=0, count=50):
    files = sorted(os.listdir(DIR_PATH))
    total = len(files)
    print(f"Total files: {total}, inspecting {start} to {min(start+count, total)}")
    
    for i in range(start, min(start+count, total)):
        fname = files[i]
        fpath = os.path.join(DIR_PATH, fname)
        try:
            with open(fpath, "r", encoding="utf-8") as f:
                data = json.load(f)
            keys = [k for k in data.keys() if not k.startswith("m_GameObject") and not k.startswith("m_Enabled")]
            name = data.get("m_Name", "")
            script = data.get("m_Script", {})
            print(f"[{i:4d}] {fname} | Name: '{name}' | Keys: {keys[:5]} | TotalKeys: {len(data)}")
        except Exception as e:
            print(f"[{i:4d}] {fname} | ERROR: {e}")

if __name__ == "__main__":
    start = int(sys.argv[1]) if len(sys.argv) > 1 else 0
    count = int(sys.argv[2]) if len(sys.argv) > 2 else 50
    inspect_range(start, count)
