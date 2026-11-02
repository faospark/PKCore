import re

with open(r'd:\Appz\Suisource\GSD2\GSD2\EVENTCON.cs', encoding='utf-8', errors='ignore') as f:
    text = f.read()

start = text.find('EventFormTbl')
print(text[start:start+1200])

