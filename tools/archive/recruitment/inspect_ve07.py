import json

d = json.load(open('D:/Modding/suikodum/Mobobehaviour/ve07.json'))
ev = d['eventdata']['mapeventdat'][0]['eventdat'][85]
com = ev['eventCom']

idx = 104
print("Context around recruitment in ve07:")
print("Before:", com[idx-25:idx])
print("Recruit:", com[idx:idx+25])
