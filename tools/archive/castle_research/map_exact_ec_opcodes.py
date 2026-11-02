import capstone, struct

GAME_ASSEMBLY_PATH = r"D:\SteamLibrary\steamapps\common\Suikoden I and II HD Remaster\GameAssembly.dll"
def va_to_offset(va):
    return (va - 0x180000000) - 0x003af000 + 0x003adc00

md = capstone.Cs(capstone.CS_ARCH_X86, capstone.CS_MODE_64)
with open(GAME_ASSEMBLY_PATH, "rb") as f:
    dll = f.read()

start_va = 0x182131d8e
end_va = 0x182134c80
code = dll[va_to_offset(start_va) : va_to_offset(end_va)]

with open(r'd:\Appz\Suisource\GSD2\GSD2\EVENTCON.cs', encoding='utf-8', errors='ignore') as f:
    cs_text = f.read()

import re
methods = re.findall(r'public unsafe void (EC[A-Za-z0-9_]+)\(sbyte cno\)', cs_text)

delegates = []
last_r8_val = None

for insn in md.disasm(code, start_va):
    if insn.mnemonic == 'mov' and insn.op_str.startswith('r8, qword ptr [rip + '):
        disp = int(insn.op_str.split('[rip + ')[1].rstrip(']'), 16)
        target = insn.address + insn.size + disp
        off = va_to_offset(target)
        if 0 <= off < len(dll) - 8:
            val = struct.unpack_from('<Q', dll, off)[0]
            last_r8_val = (insn.address, target, val)
    elif insn.mnemonic == 'call' and '0x180771a30' in insn.op_str:
        delegates.append(last_r8_val)

with open(r'd:\Appz\PKCore\tools\ec_opcodes_dump.txt', 'w') as out:
    out.write(f"Total delegates: {len(delegates)}\n")
    for i, d in enumerate(delegates):
        m_name = methods[i] if i < len(methods) else "UNKNOWN"
        out.write(f"[{i:03d}]: {m_name}\n")

print("Dumped to ec_opcodes_dump.txt")

