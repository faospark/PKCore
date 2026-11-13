import json

data = json.load(open('D:/Modding/suikodum/Mobobehaviour/vk08.json', 'r', encoding='utf-8'))
for sm_idx, sm in enumerate(data['eventdata']['mapeventdat']):
    print(f"\n=================== SUBMAP {sm_idx} (Total events: {len(sm['eventdat'])}) ===================")
    for i, ev in enumerate(sm['eventdat']):
        ef = ev.get('eventForm', [])
        ea = ev.get('eventAction', [])
        flags_checked = []
        idx = 0
        while idx < len(ef):
            op = ef[idx]
            if op in [1, 2, 3, 4, 5, 6, 7, 8]:
                if idx + 2 < len(ef):
                    fno = ef[idx+1]
                    fbit = ef[idx+2]
                    flags_checked.append((op, fno, fbit))
                    idx += 3
                    continue
            idx += 1
        actions = []
        for a in ea:
            c = a.get('code')
            d = a.get('data')
            actions.append((c, d))
        # Filter for interesting events (those with flag checks, overlays, dialogue)
        has_overlay = any(c == 23 for c, d in actions)
        has_serifu = any(c == 24 for c, d in actions)
        has_flags = len(flags_checked) > 0
        if has_overlay or has_serifu or any(f[1] in [143, 144, 112, 115, 134, 46] for f in flags_checked):
            print(f"ev[{i:02d}] etyp={ev.get('etyp')} form={ef}")
            print(f"       Flags: {flags_checked}")
            print(f"       Actions: {actions}")
