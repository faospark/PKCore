with open(r'd:\Appz\Suisource\GSD2\GSD2\EVENTCON.cs', 'r') as f:
    text = f.read()

# Let's find fields of EVENTCON
idx = text.find('// Token: 0x0400')
lines = text[idx:idx+4000].splitlines()
for line in lines[:60]:
    print(line.strip())
