import struct

GAME_ASSEMBLY_PATH = r"D:\SteamLibrary\steamapps\common\Suikoden I and II HD Remaster\GameAssembly.dll"
def va_to_offset(va):
    return (va - 0x180000000) - 0x003af000 + 0x003adc00

import capstone
md = capstone.Cs(capstone.CS_ARCH_X86, capstone.CS_MODE_64)
with open(GAME_ASSEMBLY_PATH, "rb") as f:
    dll = f.read()

start_va = 0x182131d8e
end_va = 0x182134c80
code = dll[va_to_offset(start_va) : va_to_offset(end_va)]

delegates = []
last_r8_val = None

for insn in md.disasm(code, start_va):
    if insn.mnemonic == 'mov' and insn.op_str.startswith('r8, qword ptr [rip + '):
        disp = int(insn.op_str.split('[rip + ')[1].rstrip(']'), 16)
        target = insn.address + insn.size + disp
        off = va_to_offset(target)
        if 0 <= off < len(dll) - 8:
            val = struct.unpack_from('<Q', dll, off)[0]
            last_r8_val = val
    elif insn.mnemonic == 'call' and '0x180771a30' in insn.op_str:
        delegates.append(last_r8_val)

for idx in [0, 1, 2, 3, 4, 5, 12, 31, 32, 33]:
    if idx < len(delegates):
        print(f"Opcode [{idx}]: fn_ptr = 0x{delegates[idx]:x}")
