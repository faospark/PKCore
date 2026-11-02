import capstone, sqlite3, json

conn = sqlite3.connect(r'd:\Appz\PKCore\tools\symbol_indexer\symbols.db')
c = conn.cursor()
c.execute("SELECT entity_id, name FROM game_entities WHERE category='item';")
item_names = {r[0]: r[1] for r in c.fetchall()}
item_names[0] = "None"

GAME_ASSEMBLY_PATH = r"D:\SteamLibrary\steamapps\common\Suikoden I and II HD Remaster\GameAssembly.dll"
va_start = 0x1821b09b0
va_end = 0x1821bb9b5
length = va_end - va_start
file_offset = (va_start - 0x180000000) - 0x1400

with open(GAME_ASSEMBLY_PATH, 'rb') as f:
    f.seek(file_offset)
    code = f.read(length)

md = capstone.Cs(capstone.CS_ARCH_X86, capstone.CS_MODE_64)
instructions = list(md.disasm(code, va_start))

# Find the 256 allocation points
alloc_indices = []
for idx, ins in enumerate(instructions):
    if "call" in ins.mnemonic and "0x180324380" in ins.op_str:
        alloc_indices.append(idx)
        if len(alloc_indices) == 256:
            break

print(f"Located {len(alloc_indices)} statue allocation blocks.")

PARTS = ["Dragon", "Unicorn", "Rabbit", "Turtle"]
statues = []

for block_idx in range(len(alloc_indices)):
    start_i = alloc_indices[block_idx]
    end_i = alloc_indices[block_idx + 1] if block_idx + 1 < len(alloc_indices) else len(instructions)
    
    block_ins = instructions[start_i:end_i]
    items = []
    
    for ins in block_ins:
        # Check mov byte ptr [rax/rsi/rbx + 0x2.], imm
        if "mov" in ins.mnemonic and ("rax + 0x2" in ins.op_str or "rsi + 0x2" in ins.op_str):
            parts = ins.op_str.split(',')
            if len(parts) == 2:
                try:
                    val = int(parts[1].strip(), 16)
                    items.append(val)
                except:
                    pass
        # Check mov r9b, imm
        elif "mov" in ins.mnemonic and "r9b" in ins.op_str:
            parts = ins.op_str.split(',')
            if len(parts) == 2 and parts[0].strip() == 'r9b':
                try:
                    val = int(parts[1].strip(), 16)
                    items.append(val)
                except:
                    pass

    # Deduplicate items in order
    clean_items = []
    for it in items:
        clean_items.append(it)
    
    head_id = (block_idx >> 0) & 3
    body_id = (block_idx >> 2) & 3
    legs_id = (block_idx >> 4) & 3
    tail_id = (block_idx >> 6) & 3
    
    combo_name = f"{PARTS[head_id]} Head / {PARTS[body_id]} Body / {PARTS[legs_id]} Legs / {PARTS[tail_id]} Tail"
    named_items = [f"{item_names.get(it, f'Item #{it}')} (ID {it})" for it in clean_items]
    
    statues.append({
        'index': block_idx,
        'hex': f"0x{block_idx:02X}",
        'binary': f"{block_idx:08b}",
        'combo': combo_name,
        'head': PARTS[head_id],
        'body': PARTS[body_id],
        'legs': PARTS[legs_id],
        'tail': PARTS[tail_id],
        'item_ids': clean_items,
        'item_names': named_items
    })

print("\n=== PURE STATUES ===")
for s in statues:
    if s['head'] == s['body'] == s['legs'] == s['tail']:
        print(f"Pure {s['head']} ({s['hex']}): {s['item_names']}")

# Summary of unique items offered across all 256 statues
all_reward_items = set()
for s in statues:
    for it in s['item_ids']:
        all_reward_items.add(it)

print(f"\nTotal unique items rewardable by Tenkou: {len(all_reward_items)}")
for it in sorted(all_reward_items):
    print(f"  Item #{it:2d}: {item_names.get(it, 'Unknown')}")

with open(r'd:\Appz\PKCore\tools\statues_full_table.json', 'w') as f:
    json.dump(statues, f, indent=2)
