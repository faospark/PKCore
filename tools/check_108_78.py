import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vh06.json', 'r', encoding='utf-8') as f:
    d = json.load(f)

sub0 = d['eventdata']['mapeventdat'][0]
for idx, obj in enumerate(sub0['eventobj']):
    x, y = obj.get('x'), obj.get('y')
    if x is not None and abs(x - 108) < 15 and abs(y - 78) < 15:
        print(f"sub[0] obj[{idx}]: fpno={obj['fpno']} pos=({x}, {y}) disp={obj['disp']} otyp={obj['otyp']}")

for idx, ev in enumerate(sub0['eventdat']):
    form = ev.get('eventForm', [])
    if any(abs(b - 108) < 5 for b in form) or any(abs(b - 78) < 5 for b in form):
        print(f"sub[0] ev[{idx}]: form={form} com={ev.get('eventCom')[:20]}")
