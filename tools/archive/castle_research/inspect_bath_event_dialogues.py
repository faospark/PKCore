import capstone

GAME_ASSEMBLY_PATH = r"D:\SteamLibrary\steamapps\common\Suikoden I and II HD Remaster\GameAssembly.dll"
md = capstone.Cs(capstone.CS_ARCH_X86, capstone.CS_MODE_64)

funcs = [
    ("FE00_Func01", 0x1820027f0),
    ("FE01_Func01", 0x1820029b0),
    ("FE02_Func01", 0x182002c00),
    ("FE03_Func01", 0x182002dd0),
    ("FE04_Func01", 0x182002fa0),
    ("FE05_Func01", 0x182003180),
    ("FE06_Func01", 0x1820033c0)
]

with open(GAME_ASSEMBLY_PATH, 'rb') as f:
    for name, va in funcs:
        file_offset = (va - 0x180000000) - 0x1400
        f.seek(file_offset)
        code = f.read(120)
        print(f"\n--- {name} (VA 0x{va:X}) ---")
        for ins in md.disasm(code, va):
            # Print calls or mov into ecx/edx (msg IDs)
            if ins.mnemonic in ['mov', 'call', 'lea'] and any(r in ins.op_str for r in ['ecx', 'edx', 'r8d', '0x18']):
                print(f"  0x{ins.address:x}: {ins.mnemonic:8s} {ins.op_str}")
