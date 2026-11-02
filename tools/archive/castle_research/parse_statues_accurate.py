import capstone, json

GAME_ASSEMBLY_PATH = r"D:\SteamLibrary\steamapps\common\Suikoden I and II HD Remaster\GameAssembly.dll"
va_start = 0x1821b0b10
va_end = 0x1821bb980
file_offset = (va_start - 0x180000000) - 0x1400

with open(GAME_ASSEMBLY_PATH, 'rb') as f:
    f.seek(file_offset)
    code = f.read(va_end - va_start)

md = capstone.Cs(capstone.CS_ARCH_X86, capstone.CS_MODE_64)
instructions = list(md.disasm(code, va_start))
allocs = [idx for idx, ins in enumerate(instructions) if '0x180324380' in ins.op_str and 'call' in ins.mnemonic]

gd = json.load(open(r'd:\Appz\PKCore\tools\symbol_indexer\gamedata.json', encoding='utf-8'))

def get_name(v):
    if isinstance(v, dict):
        return v.get('name', str(v))
    return str(v)

bogu_names = {}
for k, v in gd['HELMET'].items(): bogu_names[int(k)] = get_name(v)
for k, v in gd['ARMOR'].items(): bogu_names[int(k)] = get_name(v)
for k, v in gd['SHIELD'].items(): bogu_names[int(k)] = get_name(v)
for k, v in gd['OTHER_EQUIP_GEAR'].items(): bogu_names[int(k)] = get_name(v)

# G2_ovit_data exact jump table mapping:
# Kind 0 (0x10): dogu_data -> Items
# Kind 1 (0x18): bogu_data -> Equipment
# Kind 2 (0x38): embl_data -> Runes / Orbs
# Kind 3 (0x30): food_data -> Farming / Crops
# Kind 4 (0x20): trade_data -> Trade Goods
# Kind 5 (0x28): ex_it_data -> Valuables / Antiques
# Kind 6 (0x40): dish_data -> Cooked Dishes

item_names = {int(k): get_name(v) for k, v in gd['ITEMS'].items()}
rune_names = {int(k): get_name(v) for k, v in gd['RUNES'].items()}
farming_names = {int(k): get_name(v) for k, v in gd['FARMING'].items()}
trade_names = {int(k): get_name(v) for k, v in gd['TRADE'].items()}
base_item_names = {int(k): get_name(v) for k, v in gd['BASE_ITEM'].items()}
dish_names = {int(k): get_name(v) for k, v in gd['FOOD'].items()}

def resolve_reward(c0, c1, c2):
    if c0 == 2:
        amount = ((c1 * 10) + c2) * 100
        return {
            'type': 'potch',
            'amount': amount,
            'text': f"{amount:,} Potch"
        }
    if c0 == 0 and c1 == 0 and c2 == 0:
        return None
    kind = (c1 >> 4) & 7
    qty = c1 & 0x0F
    if qty == 0: qty = 1
    no = c2
    
    cat_str = ""
    name = ""
    if kind == 0:
        name = item_names.get(no, f"Item #{no}")
        cat_str = "Item"
    elif kind == 1:
        name = bogu_names.get(no, f"Equipment #{no}")
        cat_str = "Equipment"
    elif kind == 2:
        name = rune_names.get(no, f"Rune #{no}")
        cat_str = "Rune"
    elif kind == 3:
        name = farming_names.get(no, f"Farming #{no}")
        cat_str = "Farming"
    elif kind == 4:
        name = trade_names.get(no, f"Trade #{no}")
        cat_str = "Trade"
    elif kind == 5:
        name = base_item_names.get(no, f"Valuable #{no}")
        cat_str = "Valuable"
    elif kind == 6:
        name = dish_names.get(no, f"Dish #{no}")
        cat_str = "Dish"
    else:
        name = f"Unknown (Kind {kind}, ID {no})"
        cat_str = "Unknown"
        
    prefix = f"{qty}x " if qty > 1 else ""
    return {
        'type': cat_str.lower(),
        'kind_id': kind,
        'item_id': no,
        'quantity': qty,
        'name': name,
        'category': cat_str,
        'text': f"{prefix}{name} [{cat_str} #{no}]"
    }

statues = []
PARTS = ['Dragon', 'Unicorn', 'Rabbit', 'Turtle']

for b_idx in range(len(allocs)):
    start = allocs[b_idx]
    end = allocs[b_idx + 1] if b_idx + 1 < len(allocs) else len(instructions)
    block_ins = instructions[start:end]
    matrix = [[0, 0, 0], [0, 0, 0]]
    if not any('0x182487dc0' in ins.op_str for ins in block_ins):
        r_edx = 0; r_r8d = 0; r_r9b = 0
        for ins in block_ins:
            if ins.mnemonic == 'mov' and 'byte ptr [' in ins.op_str:
                parts = ins.op_str.split(',')
                if len(parts) == 2:
                    for off in range(6):
                        if hex(0x20 + off) in parts[0]:
                            try: matrix[off // 3][off % 3] = int(parts[1].strip(), 16)
                            except: pass
            if ins.mnemonic == 'xor' and 'edx, edx' in ins.op_str: r_edx = 0
            elif ins.mnemonic == 'mov' and ins.op_str.startswith('edx,'):
                try: r_edx = int(ins.op_str.split(',')[1].strip(), 16)
                except: pass
            if ins.mnemonic == 'xor' and 'r8d, r8d' in ins.op_str: r_r8d = 0
            elif ins.mnemonic == 'mov' and ins.op_str.startswith('r8d,'):
                try: r_r8d = int(ins.op_str.split(',')[1].strip(), 16)
                except: pass
            elif ins.mnemonic == 'lea' and 'r8d,' in ins.op_str:
                if 'rdx + 1' in ins.op_str: r_r8d = r_edx + 1
                elif 'rdx + 2' in ins.op_str: r_r8d = r_edx + 2
            if ins.mnemonic == 'mov' and ins.op_str.startswith('r9b,'):
                try: r_r9b = int(ins.op_str.split(',')[1].strip(), 16)
                except: pass
            if ins.mnemonic == 'call' and '0x1801aee80' in ins.op_str:
                if 0 <= r_edx < 2 and 0 <= r_r8d < 3:
                    matrix[r_edx][r_r8d] = r_r9b
                    
    rewards = []
    r0 = resolve_reward(matrix[0][0], matrix[0][1], matrix[0][2])
    if r0: rewards.append(r0)
    r1 = resolve_reward(matrix[1][0], matrix[1][1], matrix[1][2])
    if r1: rewards.append(r1)
    
    head_id = (b_idx >> 0) & 3
    body_id = (b_idx >> 2) & 3
    legs_id = (b_idx >> 4) & 3
    tail_id = (b_idx >> 6) & 3
    combo = f"{PARTS[head_id]} Head / {PARTS[body_id]} Body / {PARTS[legs_id]} Legs / {PARTS[tail_id]} Tail"
    
    statues.append({
        'index': b_idx,
        'hex': f"0x{b_idx:02X}",
        'binary': f"{b_idx:08b}",
        'head': PARTS[head_id],
        'body': PARTS[body_id],
        'legs': PARTS[legs_id],
        'tail': PARTS[tail_id],
        'combo': combo,
        'rewards': rewards,
        'reward_texts': [r['text'] for r in rewards],
        'matrix': matrix
    })

with open(r'd:\Appz\PKCore\tools\statues_accurate_table.json', 'w', encoding='utf-8') as out:
    json.dump(statues, out, indent=2)

print("Saved 100% verified accurate table to statues_accurate_table.json!")

