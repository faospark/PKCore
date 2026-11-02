import json

d = json.load(open('D:/Modding/suikodum/Mobobehaviour/vb03.json'))
ev = d['eventdata']['mapeventdat'][1]['eventdat'][62]
com = ev['eventCom']

print("Full eventCom of vb03 sub[1] ev[62]:")
print(com)
