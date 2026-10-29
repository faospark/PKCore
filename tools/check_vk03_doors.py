import json

with open(r'D:\Modding\suikodum\Mobobehaviour\vk03.json') as f:
    m = json.load(f)

sub0 = m['eventdata']['mapeventdat'][0]
events = sub0['eventdat']

print(f"Total events in vk03 sub0: {len(events)}")
for i, ev in enumerate(events):
    form = ev['eventForm']
    com = ev['eventCom']
    # Check if form checks coordinates near (50, 23)
    if any(form[j] == 1 and 45 <= form[j+1] <= 55 for j in range(len(form)-2)):
        print(f"Door near (50,23): ev[{i}] form={form} com={com}")

