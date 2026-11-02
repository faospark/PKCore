import re

with open(r'd:\Appz\Suisource\GSD2\GSD2\EventOverlayClass\rbattle_h.cs', 'r', encoding='utf-8') as f:
    text = f.read()

# Find FAVORITE class definition
start = text.find('class FAVORITE')
end = text.find('class RB_DATA')
print(text[start:end])
