import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vk13.json', 'r', encoding='utf-8') as f:
    d = json.load(f)

med = d['eventdata']['mapeventdat']
sub3 = med[3]
print("sub3 ev[8]:", sub3['eventdat'][8])
print("sub3 ev[9]:", sub3['eventdat'][9])
print("sub3 ev[10]:", sub3['eventdat'][10])
print("sub3 ev[11]:", sub3['eventdat'][11])
