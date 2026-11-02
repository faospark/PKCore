import sqlite3

conn = sqlite3.connect(r'd:\Appz\PKCore\tools\symbol_indexer\symbols.db')
c = conn.cursor()

c.execute("SELECT entity_id, name, description FROM game_entities WHERE category='ITEM' ORDER BY entity_id;")
items = c.fetchall()
print(f"Total items in DB: {len(items)}")
for it in items[:40]:
    print(f"Item #{it[0]:3d}: {it[1]}")
