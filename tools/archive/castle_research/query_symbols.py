import sqlite3

conn = sqlite3.connect(r'd:\Appz\PKCore\tools\symbol_indexer\symbols.db')
c = conn.cursor()
c.execute("SELECT name FROM sqlite_master WHERE type='table';")
tables = c.fetchall()
print("Tables:", tables)

for t in tables:
    tname = t[0]
    c.execute(f"PRAGMA table_info({tname});")
    cols = [col[1] for col in c.fetchall()]
    print(f"Table {tname} cols: {cols}")
    c.execute(f"SELECT COUNT(*) FROM {tname};")
    print(f"  Count: {c.fetchone()[0]}")
