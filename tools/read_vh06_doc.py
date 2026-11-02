with open(r'd:\Appz\PKCore\Documentation\areas\two_river_city.md', 'r', encoding='utf-8') as f:
    text = f.read()

idx = text.find('## Location Map: `vh06`')
print(text[idx:idx+3000])
