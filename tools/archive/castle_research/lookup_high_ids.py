import sqlite3

conn = sqlite3.connect(r'd:\Appz\PKCore\tools\symbol_indexer\symbols.db')
c = conn.cursor()

ids = [83, 84, 87, 88, 92, 93, 94, 95, 96, 97, 98, 99, 100, 102, 103, 104, 105, 110, 120, 146, 157, 166, 168, 170, 176, 189, 198, 216, 219, 226, 233, 240]

for it_id in ids:
    c.execute("SELECT entity_id, name, category, description FROM game_entities WHERE entity_id = ?;", (it_id,))
    matches = c.fetchall()
    print(f"\n--- Entity ID {it_id} ---")
    for m in matches:
        print(f"  [{m[2]}] {m[1]} ({m[3]})")
