import struct

GAME_ASSEMBLY_PATH = r"D:\SteamLibrary\steamapps\common\Suikoden I and II HD Remaster\GameAssembly.dll"
va_table = 0x182156b74
file_offset = (va_table - 0x180000000) - 0x1400

with open(GAME_ASSEMBLY_PATH, 'rb') as f:
    f.seek(file_offset)
    data = f.read(42 * 4)

offsets = struct.unpack('<42i', data)
for i, off in enumerate(offsets):
    target_va = 0x180000000 + off
    print(f"Opcode {i:2d} (0x{i:02x}): Target VA 0x{target_va:x}")
