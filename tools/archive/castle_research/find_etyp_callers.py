import capstone

GAME_ASSEMBLY_PATH = r"D:\SteamLibrary\steamapps\common\Suikoden I and II HD Remaster\GameAssembly.dll"

def va_to_offset(va):
    return (va - 0x180000000) - 0x003af000 + 0x003adc00

md = capstone.Cs(capstone.CS_ARCH_X86, capstone.CS_MODE_64)

with open(GAME_ASSEMBLY_PATH, "rb") as f:
    dll = f.read()

# Search for CALL instructions targeting 0x182176340
# In x86_64, call rel32 is E8 xx xx xx xx
target_va = 0x182176340

# Search in the code section (roughly 0x180001000 to 0x182500000)
# Let's search byte pattern
import struct

print("Searching callers...")
for va in range(0x182100000, 0x182200000, 1):
    off = va_to_offset(va)
    if off < 0 or off >= len(dll) - 5: continue
    if dll[off] == 0xE8:
        rel = struct.unpack_from("<i", dll, off + 1)[0]
        if va + 5 + rel == target_va:
            print(f"Call at VA 0x{va:X}")

