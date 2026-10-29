import sqlite3

conn = sqlite3.connect(r'd:\Appz\PKCore\tools\symbol_indexer\symbols.db')
c = conn.cursor()

def search(term):
    print(f"\n=== SEARCH: {term} ===")
    c.execute("SELECT address, type_name, member_name, full_symbol FROM native_symbols WHERE full_symbol LIKE ? LIMIT 25;", (f"%{term}%",))
    for r in c.fetchall():
        print(f"  [{r[0]}] {r[1]}.{r[2]} ({r[3]})")

search("furo")
search("bath")
search("peeping")
search("tantei")
search("cook")
search("food")
search("meyasu")
search("parts")
search("tsuri")
search("mogu")
search("ero_lv")
