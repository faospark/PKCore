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

for op_idx, target_va in enumerate(targets):
    fo = (target_va - 0x180000000) - 0x1400
    with open(GAME_ASSEMBLY_PATH, 'rb') as f:
        f.seek(fo)
        code = f.read(250)
    
    # Check what functions this handler calls
    calls = []
    for ins in md.disasm(code, target_va):
        if "call" in ins.mnemonic and ins.op_str not in ["0x181a45050", "0x181a45080", "0x1802ff790", "0x180324ee0", "0x180d2a920", "0x1803250f0", "0x1803250e0"]:
            calls.append((hex(ins.address), ins.op_str))
    if calls:
        print(f"Opcode {op_idx:2d} (0x{op_idx:02X}): VA 0x{target_va:X} calls -> {calls}")
