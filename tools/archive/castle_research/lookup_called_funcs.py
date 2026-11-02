import sqlite3

conn = sqlite3.connect(r'd:\Appz\PKCore\tools\symbol_indexer\symbols.db')
c = conn.cursor()

addrs = [
    '0x181a34d80', '0x181a367f0', '0x181a29990', '0x181a35f00',
    '0x181a2adc0', '0x181abddd0', '0x181ac0270', '0x181ac02e0',
    '0x181ac02b0'
]

for a in addrs:
    c.execute("SELECT address, full_symbol FROM native_symbols WHERE address = ?;", (a,))
    res = c.fetchall()
    print(f"[{a}] -> {res}")
