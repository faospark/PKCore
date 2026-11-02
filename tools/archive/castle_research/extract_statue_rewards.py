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

entries = {}
curr_items = []
curr_idx = None

# Let's inspect instructions
for ins in md.disasm(code, va_start):
    # Pattern: mov byte ptr [rax + 0x20..], <item_id>
    # or mov byte ptr [rax + 0x21], <item_id>
    if "mov" in ins.mnemonic and "byte ptr [rax + 0x2" in ins.op_str:
        # Extract immediate
        parts = ins.op_str.split(',')
        if len(parts) == 2:
            try:
                val = int(parts[1].strip(), 16)
                curr_items.append(val)
            except:
                pass
    # Pattern: mov qword ptr [rdi + <offset>], rbx
    if "mov" in ins.mnemonic and "qword ptr [rdi + 0x" in ins.op_str and "rbx" in ins.op_str:
        parts = ins.op_str.split(',')
        if len(parts) == 2 and "rdi" in parts[0]:
            try:
                off_str = parts[0].split('+')[1].replace(']', '').strip()
                off_val = int(off_str, 16)
                idx = (off_val - 0x20) // 8
                entries[idx] = list(curr_items)
                curr_items = []
            except Exception as e:
                pass

print(f"Parsed {len(entries)} statue reward entries!")
for i in sorted(entries.keys())[:30]:
    print(f"Index {i:3d} (0x{i:02x}): Items = {entries[i]}")
