import struct

with open(r'D:\SteamLibrary\steamapps\common\Suikoden I and II HD Remaster\GameAssembly.dll', 'rb') as f:
    # 0x18212fca0 to 0x18212fe50
    start_va = 0x18212FCA0
    end_va = 0x18212FE50
    start_off = start_va - 0x180001400
    f.seek(start_off)
    code = f.read(end_va - start_va)

# Look for mov rdx, qword ptr [rip + offset] (48 8B 15 xx xx xx xx)
for i in range(len(code)-7):
    if code[i] == 0x48 and code[i+1] == 0x8B and (code[i+2] & 0xC7) == 0x05: # mov reg, [rip + disp]
        disp = struct.unpack('<i', code[i+3:i+7])[0]
        cur_va = start_va + i
        target_va = cur_va + 7 + disp
        print(f'VA 0x{cur_va:X}: mov rdx, [0x{target_va:X}]')
