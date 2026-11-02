import struct

GAME_ASSEMBLY_PATH = r"D:\SteamLibrary\steamapps\common\Suikoden I and II HD Remaster\GameAssembly.dll"
def va_to_offset(va):
    return (va - 0x180000000) - 0x003af000 + 0x003adc00

with open(GAME_ASSEMBLY_PATH, "rb") as f:
    dll = f.read()

target_va = 0x18386ae90
off = va_to_offset(target_va)
val = struct.unpack_from("<Q", dll, off)[0]
print(f"Target VA 0x{target_va:X} (offset 0x{off:X}): 0x{val:X}")

