import capstone, struct

GAME_ASSEMBLY_PATH = r"D:\SteamLibrary\steamapps\common\Suikoden I and II HD Remaster\GameAssembly.dll"
va_table = 0x182156b74
file_offset = (va_table - 0x180000000) - 0x1400

with open(GAME_ASSEMBLY_PATH, 'rb') as f:
    f.seek(file_offset)
    data = f.read(42 * 4)

offsets = struct.unpack('<42i', data)
targets = [0x180000000 + off for off in offsets]

md = capstone.Cs(capstone.CS_ARCH_X86, capstone.CS_MODE_64)

print("Mapping all 42 EventForm opcodes...")
for op_idx, target_va in enumerate(targets):
    fo = (target_va - 0x180000000) - 0x1400
    with open(GAME_ASSEMBLY_PATH, 'rb') as f:
        f.seek(fo)
        code = f.read(160)
    
    # Count how many call 0x181a45050 (Advance byte) occur before a jump or next loop
    reads = 0
    instructions = list(md.disasm(code, target_va))
    summary = []
    for ins in instructions:
        if "call" in ins.mnemonic and "0x181a45050" in ins.op_str:
            reads += 1
        # Check jumps
        if ins.mnemonic in ['jmp', 'je', 'jne', 'jg', 'jl', 'ret'] and ins.address > target_va + 10:
            if "0x1821534a" in ins.op_str or "0x182154c3a" in ins.op_str:
                break
    print(f"Opcode {op_idx:2d} (0x{op_idx:02X}): VA 0x{target_va:X} | Byte args read: {reads}")
