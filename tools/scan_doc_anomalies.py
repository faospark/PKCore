import glob, os, re

DOC_DIR = r"D:\Appz\PKCore\Documentation\areas"
hq_files = sorted(glob.glob(os.path.join(DOC_DIR, "dunan_castle_hq_*.md")))

findings = []

for fpath in hq_files:
    fname = os.path.basename(fpath)
    with open(fpath, 'r', encoding='utf-8', errors='ignore') as f:
        text = f.read()
    
    # 1. Search for boss battles triggered inside castle
    bosses = re.findall(r'Start Boss Battle #(\d+)', text)
    if bosses:
        findings.append(f"[{fname}] Boss Battle calls: {set(bosses)}")
    
    # 2. Search for tactical war battles in castle
    wars = re.findall(r'Launch Tactical War Battle \((\d+)\)', text)
    if wars:
        findings.append(f"[{fname}] Tactical War Battle calls: {set(wars)}")
    
    # 3. Search for Potch awards / currency manipulation
    potch = re.findall(r'Award Potch [^\);]+', text)
    if potch:
        findings.append(f"[{fname}] Potch events: {len(potch)} instances (samples: {set(potch[:3])})")
        
    # 4. Search for Shop calls in weird rooms
    shops = re.findall(r'Open Shop Menu #\d+ \(Type: \d+\)', text)
    if shops:
        findings.append(f"[{fname}] Shop calls: {set(shops)}")
        
    # 5. Search for Castle level >= 255 (corrupted/dummy level checks)
    dummy_lv = re.findall(r'Castle HQ Tier >= Level \d+', text)
    if dummy_lv:
        findings.append(f"[{fname}] Castle Tier checks: {set(dummy_lv)}")

with open(r"d:\Appz\PKCore\tools\castle_doc_findings.txt", "w", encoding="utf-8") as out:
    for line in findings:
        out.write(line + "\n")
        print(line)

