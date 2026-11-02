import sqlite3

conn = sqlite3.connect(r'd:\Appz\PKCore\tools\symbol_indexer\symbols.db')
c = conn.cursor()
c.execute("SELECT address, full_symbol FROM native_symbols WHERE type_name='EventOverlayClass.Overlay_rbattle';")
for r in c.fetchall():
    print(f"[{r[0]}] {r[1]}")
