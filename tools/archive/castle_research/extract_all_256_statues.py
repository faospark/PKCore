import capstone, sqlite3, json

# 1. Load item names from symbols.db
conn = sqlite3.connect(r'd:\Appz\PKCore\tools\symbol_indexer\symbols.db')
c = conn.cursor()
c.execute("SELECT entity_id, name FROM game_entities WHERE category='item';")
item_names = {r[0]: r[1] for r in c.fetchall()}

# Add special known items if missing
item_names[0] = "None"

GAME_ASSEMBLY_PATH = r"D:\SteamLibrary\steamapps\common\Suikoden I and II HD Remaster\GameAssembly.dll"
va_start = 0x1821b09b0
va_end = 0x1821bba18
length = va_end - va_start

file_offset = (va_start - 0x180000000) - 0x1400

with open(GAME_ASSEMBLY_PATH, 'rb') as f:
    f.seek(file_offset)
    code = f.read(length)

md = capstone.Cs(capstone.CS_ARCH_X86, capstone.CS_MODE_64)

statues = []
current_items = []
recording = False

PARTS = ["Dragon", "Unicorn", "Rabbit", "Turtle"]

instructions = list(md.disasm(code, va_start))

i = 0
while i < len(instructions):
    ins = instructions[i]
    
    # When call 0x180324380 is reached, an item array was created
    if "call" in ins.mnemonic and "0x180324380" in ins.op_str:
        # The preceding or subsequent instructions will populate items into [rax + 0x20..]
        items_for_this = []
        # Look ahead up to 25 instructions for "mov byte ptr [rax + 0x2...], imm"
        for j in range(i + 1, min(i + 30, len(instructions))):
            next_ins = instructions[j]
            # If another call occurs or another allocation begins, break
            if "call" in next_ins.mnemonic and "0x180324380" in next_ins.op_str:
                break
            if "mov" in next_ins.mnemonic and "byte ptr [rax + 0x2" in next_ins.op_str:
                parts = next_ins.op_str.split(',')
                if len(parts) == 2:
                    try:
                        val = int(parts[1].strip(), 16)
                        items_for_this.append(val)
                    except:
                        pass
        statues.append(items_for_this)
    i += 1

print(f"Extracted {len(statues)} statue entries!")

# Skip dummy entry 0 if count is 257
if len(statues) == 257:
    statues = statues[1:] # 0 to 255

results = []
for idx, itms in enumerate(statues):
    # Decode 4 parts from idx (2 bits each: head, body, legs, tail)
    head_id = (idx >> 0) & 3
    body_id = (idx >> 2) & 3
    legs_id = (idx >> 4) & 3
    tail_id = (idx >> 6) & 3
    
    combo_name = f"{PARTS[head_id]} Head / {PARTS[body_id]} Body / {PARTS[legs_id]} Legs / {PARTS[tail_id]} Tail"
    named_items = [f"{item_names.get(it, f'Unknown Item #{it}')} (ID {it})" for it in itms]
    
    results.append({
        'index': idx,
        'hex': f"0x{idx:02X}",
        'binary': f"{idx:08b}",
        'combo': combo_name,
        'head': PARTS[head_id],
        'body': PARTS[body_id],
        'legs': PARTS[legs_id],
        'tail': PARTS[tail_id],
        'item_ids': itms,
        'item_names': named_items
    })

with open(r'd:\Appz\PKCore\tools\guardian_statues_256.json', 'w') as out:
    json.dump(results, out, indent=2)

print("Saved 256 guardian statues to guardian_statues_256.json!")

# Print pure statues
print("\n=== PURE STATUES ===")
for r in results:
    if r['head'] == r['body'] == r['legs'] == r['tail']:
        print(f"Pure {r['head']} ({r['hex']}): {r['item_names']}")

# Print statues with stat stones
stat_stones = [21, 22, 23, 24, 25, 26, 27]
print("\n=== STAT STONE REWARDS ===")
for r in results:
    stones = [it for it in r['item_ids'] if it in stat_stones]
    if stones:
        print(f"{r['combo']} ({r['hex']}): {r['item_names']}")
