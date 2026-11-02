import sqlite3

conn = sqlite3.connect(r'd:\Appz\PKCore\tools\symbol_indexer\symbols.db')
c = conn.cursor()
c.execute("SELECT entity_id, name, description FROM game_entities WHERE category='character' AND entity_id IN (49, 74);")
for r in c.fetchall():
    print(r)

# Check what 0x18201c6d0 is
c.execute("SELECT address, full_symbol FROM native_symbols WHERE address_int = 0x18201c6d0 OR full_symbol LIKE '%0x18201c6d0%';")
print("Native symbol for 0x18201c6d0:", c.fetchall())

# Check all symbols around 0x18201c6d0
c.execute("SELECT address, full_symbol FROM native_symbols WHERE address BETWEEN '0x18201c600' AND '0x18201c900';")
print("Nearby symbols:")
for r in c.fetchall():
    print(" ", r)
