import os, struct, capstone

GAME_ASSEMBLY_PATH = r"D:\SteamLibrary\steamapps\common\Suikoden I and II HD Remaster\GameAssembly.dll"

def va_to_offset(va):
    return (va - 0x180000000) - 0x003af000 + 0x003adc00

md = capstone.Cs(capstone.CS_ARCH_X86, capstone.CS_MODE_64)

with open(GAME_ASSEMBLY_PATH, "rb") as f:
    dll = f.read()

# AssignCmdFunction starts at 0x1821316f0 and ends around 0x182134c80
start_va = 0x182131d8e
end_va = 0x182134c80
code = dll[va_to_offset(start_va) : va_to_offset(end_va)]

cmd_handlers = []
# Look for pattern: mov r8, qword ptr [rip + disp] followed by call (delegate creation)
# In x64 capstone:
for insn in md.disasm(code, start_va):
    if insn.mnemonic == 'mov' and insn.op_str.startswith('r8, qword ptr [rip + '):
        # target address = insn.address + insn.size + disp
        disp_str = insn.op_str.split('[rip + ')[1].rstrip(']')
        disp = int(disp_str, 16)
        rip_target = insn.address + insn.size + disp
        # read 8 bytes from dll at rip_target
        offset = va_to_offset(rip_target)
        if 0 <= offset < len(dll) - 8:
            fn_ptr = struct.unpack_from('<Q', dll, offset)[0]
            cmd_handlers.append((len(cmd_handlers), insn.address, rip_target, fn_ptr))

print(f"Total handlers found: {len(cmd_handlers)}")
for idx, insn_va, ptr_va, fn in cmd_handlers[:20]:
    print(f"Cmd[{idx:03d}]: Handler VA = 0x{fn:X} (loaded at 0x{insn_va:X})")

