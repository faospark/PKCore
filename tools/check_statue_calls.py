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

calls = []
for ins in md.disasm(code, va_start):
    if "call" in ins.mnemonic and "0x180324380" in ins.op_str:
        calls.append(hex(ins.address))

print(f"Total calls: {len(calls)}")
print("First 5 calls:", calls[:5])
print("Last 5 calls:", calls[-5:])
