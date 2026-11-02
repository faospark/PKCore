import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vh06.json', 'r', encoding='utf-8') as f:
    d = json.load(f)

for s_idx, sub in enumerate(d['eventdata']['mapeventdat']):
    for ev_idx, ev in enumerate(sub.get('eventdat', [])):
        form = ev.get('eventForm', [])
        # check if pos (36..38, 73..75) is in form
        found = False
        for i in range(len(form)-4):
            if form[i] in (36, 37, 38) and form[i+1] in (36, 37, 38) and form[i+3] in (73, 74, 75):
                found = True
                break
        if found or 23 in form or 28 in form:
            print(f"sub[{s_idx}] ev[{ev_idx}]: form={form[:15]}")
            print(f"  com={ev.get('eventCom')[:20]}")
