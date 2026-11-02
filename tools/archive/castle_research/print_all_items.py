import sqlite3

conn = sqlite3.connect(r'd:\Appz\PKCore\tools\symbol_indexer\symbols.db')
c = conn.cursor()

c.execute("SELECT entity_id, name, category, description FROM game_entities WHERE category='item' AND entity_id BETWEEN 20 AND 40 ORDER BY entity_id;")
for r in c.fetchall():
    print(f"[{r[2]}] #{r[0]}: {r[1]} ({r[3]})")
