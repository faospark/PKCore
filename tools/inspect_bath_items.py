import sqlite3

conn = sqlite3.connect(r'd:\Appz\PKCore\tools\symbol_indexer\symbols.db')
c = conn.cursor()
c.execute("SELECT entity_id, name, category, description FROM game_entities WHERE name LIKE '%bath%' OR description LIKE '%bath%' OR description LIKE '%FURO%' OR name LIKE '%pot%' OR name LIKE '%doll%' OR name LIKE '%vase%' OR name LIKE '%urn%';")
for r in c.fetchall():
    print(f"[{r[2]}] #{r[0]}: {r[1]} - {r[3]}")

# Let's also search g2_data_h for bath item constants
c.execute("SELECT name, signature FROM members WHERE type_name = 'g2_data_h' AND (name LIKE '%FURO%' OR name LIKE '%BATH%' OR name LIKE '%OKI%');")
print("\ng2_data_h constants:")
for r in c.fetchall():
    print(" ", r)
