import capstone, struct, re, sqlite3

GAME_ASSEMBLY_PATH = r"D:\SteamLibrary\steamapps\common\Suikoden I and II HD Remaster\GameAssembly.dll"
def va_to_offset(va):
    return (va - 0x180000000) - 0x003af000 + 0x003adc00

md = capstone.Cs(capstone.CS_ARCH_X86, capstone.CS_MODE_64)
with open(GAME_ASSEMBLY_PATH, "rb") as f:
    dll = f.read()

# Load method names
with open(r'd:\Appz\PKCore\tools\ec_opcodes_dump.txt') as f:
    op_names = [line.split(': ')[1].strip() for line in f if ': ' in line]

conn = sqlite3.connect(r'd:\Appz\PKCore\tools\symbol_indexer\symbols.db')
c = conn.cursor()

native_vas = {}
for row in c.execute("SELECT member_name, address FROM native_symbols WHERE type_name='EVENTCON' AND address IS NOT NULL"):
    name = row[0]
    addr = row[1]
    if addr and addr.startswith('0x'):
        native_vas[name] = int(addr, 16)

print(f"Found {len(native_vas)} native addresses for EVENTCON methods.")

ADVANCE_VA = 0x181a447a0

op_arg_counts = {}
for idx, name in enumerate(op_names):
    if name not in native_vas:
        op_arg_counts[idx] = (name, -1)
        continue
    va = native_vas[name]
    code = dll[va_to_offset(va) : va_to_offset(va) + 600]
    advances = 0
    for insn in md.disasm(code, va):
        if insn.mnemonic == 'ret':
            break
        if insn.mnemonic == 'call' and hex(ADVANCE_VA).lower() in insn.op_str.lower():
            advances += 1
    op_arg_counts[idx] = (name, advances)

with open(r'd:\Appz\PKCore\tools\ec_opcode_specs.txt', 'w') as out:
    for idx in sorted(op_arg_counts.keys()):
        name, adv = op_arg_counts[idx]
        out.write(f"Opcode [{idx:03d}]: {name:<22} -> Advance calls = {adv}\n")

print("Dumped to ec_opcode_specs.txt")

