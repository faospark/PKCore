import json, glob, os

for p in ['vb03.json', 'vb04.json', 've07.json', 'vd19.json', 'vd05.json', 've04.json']:
    path = os.path.join('D:/Modding/suikodum/Mobobehaviour', p)
    if not os.path.exists(path): continue
    d = json.load(open(path))
    ov = d.get('overlay_func', [])
    for si, sub in enumerate(d.get('eventdata', {}).get('mapeventdat', [])):
        for ei, ev in enumerate(sub.get('eventdat', [])):
            c = ev.get('eventCom', [])
            # Search for [30, slot, 1, ...]
            for i in range(len(c)-3):
                if c[i] == 30 and 0 <= c[i+1] < len(ov) and c[i+2] == 1 and 1 <= c[i+3] <= 108:
                    print(f"=== {p} sub[{si}] ev[{ei}] char={c[i+3]} ===")
                    start = max(0, i - 60)
                    end = min(len(c), i + 40)
                    print("Context:", c[start:end])
                    # Check for 72, 73, 74, etc.
                    for j in range(start, end):
                        if c[j] in [71, 72, 73, 74]:
                            print(f"  Sound opcode {c[j]} at offset {j-i}: {[c[k] for k in range(j, min(len(c), j+6))]}")
