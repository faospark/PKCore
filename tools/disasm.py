import sys
import os
import capstone

GAME_ASSEMBLY_PATH = r"D:\SteamLibrary\steamapps\common\Suikoden I and II HD Remaster\GameAssembly.dll"

def disassemble_va(va_str, num_bytes=256):
    try:
        va = int(va_str, 16) if va_str.startswith(("0x", "0X")) else int(va_str, 10)
    except ValueError:
        print(f"Error: Invalid address '{va_str}'. Use hex format (e.g. 0x18123c300).")
        return 1

    # VA to file offset formula for GameAssembly.dll
    file_offset = (va - 0x180000000) - 0x003af000 + 0x003adc00

    if not os.path.exists(GAME_ASSEMBLY_PATH):
        print(f"Error: GameAssembly.dll not found at '{GAME_ASSEMBLY_PATH}'.")
        return 1

    file_size = os.path.getsize(GAME_ASSEMBLY_PATH)
    if file_offset < 0 or file_offset >= file_size:
        print(f"Error: Computed file offset 0x{file_offset:X} is out of file bounds (size: 0x{file_size:X}).")
        return 1

    md = capstone.Cs(capstone.CS_ARCH_X86, capstone.CS_MODE_64)
    with open(GAME_ASSEMBLY_PATH, "rb") as f:
        f.seek(file_offset)
        code = f.read(num_bytes)

    print(f"Disassembly at VA 0x{va:X} (File Offset 0x{file_offset:X}):")
    print("-" * 60)
    for insn in md.disasm(code, va):
        print(f"0x{insn.address:09x}: {insn.mnemonic:<10} {insn.op_str}")

    return 0

if __name__ == "__main__":
    if len(sys.argv) < 2:
        print("Usage: disasm.bat <0xAddress> [num_bytes]")
        sys.exit(1)
    
    bytes_count = int(sys.argv[2]) if len(sys.argv) > 2 else 256
    sys.exit(disassemble_va(sys.argv[1], bytes_count))

