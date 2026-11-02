# Check addresses from symbols.db
# [0x1820023c0] EventOverlayClass.ff_event.CheckFuroEvent00
# [0x182002410] EventOverlayClass.ff_event.CheckFuroEvent01
# [0x182002520] EventOverlayClass.ff_event.CheckFuroEvent02
# [0x182002590] EventOverlayClass.ff_event.CheckFuroEvent03
# [0x182002600] EventOverlayClass.ff_event.CheckFuroEvent04
# [0x182002690] EventOverlayClass.ff_event.CheckFuroEvent05
# [0x182002700] EventOverlayClass.ff_event.CheckFuroEvent06

import capstone, json

GAME_ASSEMBLY_PATH = r"D:\SteamLibrary\steamapps\common\Suikoden I and II HD Remaster\GameAssembly.dll"
md = capstone.Cs(capstone.CS_ARCH_X86, capstone.CS_MODE_64)

events = [
    ("CheckFuroEvent00", 0x1820023c0, 0x50),
    ("CheckFuroEvent01", 0x182002410, 0x110),
    ("CheckFuroEvent02", 0x182002520, 0x70),
    ("CheckFuroEvent03", 0x182002590, 0x70),
    ("CheckFuroEvent04", 0x182002600, 0x90),
    ("CheckFuroEvent05", 0x182002690, 0x70),
    ("CheckFuroEvent06", 0x182002700, 0x70)
]

with open(GAME_ASSEMBLY_PATH, 'rb') as f:
    for name, va, sz in events:
        file_offset = (va - 0x180000000) - 0x1400
        f.seek(file_offset)
        code = f.read(sz)
        print(f"\n=================== {name} (VA 0x{va:X}) ===================")
        for ins in md.disasm(code, va):
            print(f"  0x{ins.address:x}: {ins.mnemonic:8s} {ins.op_str}")
