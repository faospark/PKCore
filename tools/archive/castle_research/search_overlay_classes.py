import sqlite3

conn = sqlite3.connect(r'd:\Appz\PKCore\tools\symbol_indexer\symbols.db')
c = conn.cursor()

c.execute("SELECT DISTINCT type_name FROM native_symbols WHERE type_name LIKE 'EventOverlayClass%' ORDER BY type_name;")
rows = c.fetchall()
print(f"Total EventOverlayClass types: {len(rows)}")
for r in rows:
    print(" ", r[0])
