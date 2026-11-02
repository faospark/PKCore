import sqlite3

conn = sqlite3.connect(r'd:\Appz\PKCore\tools\symbol_indexer\symbols.db')
c = conn.cursor()

c.execute("SELECT address, full_symbol FROM native_symbols WHERE full_symbol LIKE '%f_msg%' OR full_symbol LIKE '%furo_msg%';")
for r in c.fetchall():
    print(r)

# Also check string_h for furo strings
c.execute("SELECT name, signature FROM members WHERE type_name='string_h' AND (name LIKE '%FURO%' OR name LIKE '%BATH%');")
print("\nstring_h bath symbols:")
for r in c.fetchall():
    print(r)
