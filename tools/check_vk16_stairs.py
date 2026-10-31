import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vk24.json', 'r', encoding='utf-8') as f:
    vk24 = json.load(f)

print("vk24 ev[2]:", vk24['eventdata']['mapeventdat'][0]['eventdat'][2])
print("vk24 ev[23]:", vk24['eventdata']['mapeventdat'][0]['eventdat'][23])
