with open(r'D:\SteamLibrary\steamapps\common\Suikoden I and II HD Remaster\GameAssembly.dll', 'rb') as f:
    start_va = 0x182130960
    end_va = 0x182130E50
    f.seek(start_va - 0x180001400)
    data = f.read(end_va - start_va)

# Look for mov r14, ... or lea r14, ... or xor r14, ...
# R14 as destination:
# 49 C7 C6 ... (mov r14, imm)
# 49 89 ... (mov r14, reg)
# 4C 8B F... (mov r14, ...)
# 4D 31 F6 (xor r14, r14)
# 41 BE ... (mov r14d, imm)
for i in range(len(data)-3):
    va = start_va + i
    # mov r14d, imm32: 41 BE xx xx xx xx
    if data[i] == 0x41 and data[i+1] == 0xBE:
        import struct
        val = struct.unpack('<I', data[i+2:i+6])[0]
        print(f'VA 0x{va:X}: mov r14d, {val}')
    # mov r14, rax: 49 89 C6
    if data[i] == 0x49 and data[i+1] == 0x89 and data[i+2] == 0xC6:
        print(f'VA 0x{va:X}: mov r14, rax')
    # mov r14d, 1: 41 BE 01 00 00 00
