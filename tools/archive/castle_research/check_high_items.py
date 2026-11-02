import sqlite3

conn = sqlite3.connect(r'd:\Appz\PKCore\tools\symbol_indexer\symbols.db')
c = conn.cursor()
c.execute("SELECT entity_id, name, description FROM game_entities WHERE category='item' AND entity_id >= 85 ORDER BY entity_id LIMIT 40;")
rows = c.fetchall()
print(f"Items found with entity_id >= 85: {len(rows)}")
for r in rows:
    print(f"ID {r[0]}: {r[1]} | {r[2]}")

