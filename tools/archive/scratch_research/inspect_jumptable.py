import struct

with open(r'D:\SteamLibrary\steamapps\common\Suikoden I and II HD Remaster\GameAssembly.dll', 'rb') as f:
    # SetEnemyFood is at VA 0x18212EA50, File Offset 0x212D650
    # The jump table target:
    # 0x18212ea97: mov ecx, dword ptr [rdx + rax*4 + 0x212f09c]
    # rdx = rip - 0x212ea97 = 0x18212ea97 - 0x212ea97 = 0x180000000 (ImageBase!)
    # ecx is an RVA relative to ImageBase!
    # Let's read 11 entries from RVA 0x212f09c:
    # RVA 0x212f09c is in .text!
    # In .text, FileOffset = VA - 0x180001400 = RVA - 0x1400.
    # 0x212f09c - 0x1400 = 0x212DC9C
    f.seek(0x212DC9C)
    entries = struct.unpack('<11I', f.read(44))
    for i, rva in enumerate(entries):
        va = 0x180000000 + rva
        fo = rva - 0x1400
        print(f'Case {i}: RVA 0x{rva:X} (VA 0x{va:X}, FO 0x{fo:X})')
