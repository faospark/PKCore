import json, glob, os

# Look for any [30, slot, 1, char_id] across all maps
results = []
for p in glob.glob('D:/Modding/suikodum/Mobobehaviour/*.json'):
    try:
        d = json.load(open(p))
        ov = d.get('overlay_func', [])
        for si, sub in enumerate(d.get('eventdata', {}).get('mapeventdat', [])):
            for ei, ev in enumerate(sub.get('eventdat', [])):
                c = ev.get('eventCom', [])
                for i in range(len(c)-3):
                    # opcode 30, slot, 1, char_id
                    if c[i] == 30 and 0 <= c[i+1] < len(ov) and c[i+2] == 1 and 1 <= c[i+3] <= 108:
                        slot = c[i+1]
                        func_idx = ov[slot]
                        results.append((os.path.basename(p), si, ei, i, slot, func_idx, c[i+3], c[max(0, i-25):i+25]))
    except:
        pass

print(f"Found {len(results)} recruitment calls:")
for r in results[:15]:
    p, si, ei, i, slot, func_idx, ch, snippet = r
    print(f"\n{p} sub[{si}] ev[{ei}] char={ch} (func_idx={func_idx}):")
    print(snippet)
