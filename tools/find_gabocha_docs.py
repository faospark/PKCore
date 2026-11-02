with open(r'd:\Appz\PKCore\Documentation\areas\two_river_city.md', 'r', encoding='utf-8') as f:
    text = f.read()

for query in ['Gabocha', 'Kobold', 'round']:
    idx = 0
    cnt = 0
    while True:
        idx = text.find(query, idx)
        if idx == -1: break
        cnt += 1
        print(f"Match for {query} at {idx}:")
        print(text[max(0, idx-100):min(len(text), idx+300)])
        idx += len(query)
        if cnt >= 3: break
