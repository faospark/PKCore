import json

with open(r'D:\Modding\suikodum\Mobobehaviour\vk09.json', 'r', encoding='utf-8') as f:
    d = json.load(f)

# Load full g2_name_h characters if possible or common map
chars = {
    1: "Riou", 2: "Nanami", 3: "Viktor", 4: "Flik",
    88: "Fitcher", 108: "Karen", 112: "Annallee", 113: "Pico", 114: "Alberto"
}

for s_idx, m in enumerate(d['eventdata']['mapeventdat']):
    print(f"\n==========================================")
    print(f"=== SUBMAP {s_idx} (Total Objects: {m['okaz']}) ===")
    print(f"==========================================")
    for o_idx, o in enumerate(m['eventobj']):
        fpno = o.get('fpno')
        otyp = o.get('otyp')
        cname = chars.get(fpno, "")
        x = o.get('x')
        y = o.get('y')
        disp = o.get('disp')
        ozok = o.get('ozok')
        print(f"obj[{o_idx:02d}]: fpno={fpno:<5} {cname:<12} | otyp={otyp} ozok={ozok} disp={disp} | pos=({x}, {y})")
