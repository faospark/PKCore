import capstone, sqlite3

conn = sqlite3.connect(r'd:\Appz\PKCore\tools\symbol_indexer\symbols.db')
c = conn.cursor()
c.execute("SELECT address, full_symbol FROM native_symbols WHERE type_name='EventOverlayClass.t_phase';")
t_phase_symbols = c.fetchall()
print("t_phase symbols:")
for s in t_phase_symbols:
    print(f"  [{s[0]}] {s[1]}")
