with open(r'D:\SteamLibrary\steamapps\common\Suikoden I and II HD Remaster\GameAssembly.dll', 'rb') as f:
    f.seek(0x1400)
    data = f.read(0x2800000)

# Search for instructions accessing +0x5a and +0x5b
# e.g. [rcx + 0x5a], [rax + 0x5a], [rbx + 0x5a], [rdi + 0x5a], [rsi + 0x5a]
# In x86_64: 8A 4x 5a, 88 4x 5a, 0F B6 4x 5a, etc.
import re
print('Searching for 0x5a and 0x5b accesses near Overlay_rbattle (0x182110000 - 0x182180000)...')
start_va = 0x182110000
end_va = 0x182185000
start_off = start_va - 0x180001400
end_off = end_va - 0x180001400

for i in range(start_off, end_off):
    if data[i] == 0x5a or data[i] == 0x5b:
        # Check if preceding bytes look like mov [reg+0x5a] or movzx reg, [reg+0x5a]
        # 0x0F 0xB6 ... 0x5a
        if i >= 3 and data[i-3] == 0x0F and data[i-2] == 0xB6:
            va = 0x180001400 + i - 3
            print(f'VA 0x{va:X}: movzx ..., [reg + 0x{data[i]:02x}] (modrm={data[i-1]:02X})')
        # 0x8A ... 0x5a
        elif i >= 2 and data[i-2] == 0x8A:
            va = 0x180001400 + i - 2
            print(f'VA 0x{va:X}: mov reg, [reg + 0x{data[i]:02x}] (modrm={data[i-1]:02X})')
        # 0x88 ... 0x5a
        elif i >= 2 and data[i-2] == 0x88:
            va = 0x180001400 + i - 2
            print(f'VA 0x{va:X}: mov [reg + 0x{data[i]:02x}], reg (modrm={data[i-1]:02X})')
        # 0xC6 ... 0x5a
        elif i >= 2 and data[i-2] == 0xC6:
            va = 0x180001400 + i - 2
            print(f'VA 0x{va:X}: mov byte ptr [reg + 0x{data[i]:02x}], imm')
        # 0xFE ... 0x5a (inc/dec)
        elif i >= 2 and data[i-2] == 0xFE:
            va = 0x180001400 + i - 2
            print(f'VA 0x{va:X}: inc/dec byte ptr [reg + 0x{data[i]:02x}]')
