import capstone

GAME_ASSEMBLY_PATH = r"D:\SteamLibrary\steamapps\common\Suikoden I and II HD Remaster\GameAssembly.dll"
va_start = 0x1821b09b0
va_end = 0x1821bba18
length = va_end - va_start

file_offset = (va_start - 0x180000000) - 0x1400

with open(GAME_ASSEMBLY_PATH, 'rb') as f:
    f.seek(file_offset)
    code = f.read(length)

md = capstone.Cs(capstone.CS_ARCH_X86, capstone.CS_MODE_64)

stores = []
for ins in md.disasm(code, va_start):
    if "mov" in ins.mnemonic and ("rdi" in ins.op_str or "rsi" in ins.op_str) and "qword ptr" in ins.op_str:
        if any(reg in ins.op_str.split(',')[1] for reg in ['rbx', 'rax', 'rdx', 'rcx']):
            stores.append((hex(ins.address), ins.mnemonic, ins.op_str))

print(f"Total store instructions: {len(stores)}")
for s in stores[:20]:
    print(s)
if len(stores) > 20:
    print("...")
    for s in stores[-10:]:
        print(s)
