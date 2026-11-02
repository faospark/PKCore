import struct

def find_calls(target_va, name):
    with open(r'D:\SteamLibrary\steamapps\common\Suikoden I and II HD Remaster\GameAssembly.dll', 'rb') as f:
        # read text section
        # text starts at 0x1400 in file, size ~0x2800000
        f.seek(0x1400)
        data = f.read(0x2800000)
        print(f'Searching calls to {name} (VA 0x{target_va:X})...')
        for i in range(len(data)-5):
            if data[i] == 0xE8:
                rel = struct.unpack('<i', data[i+1:i+5])[0]
                call_site_va = 0x180001400 + i
                dest_va = call_site_va + 5 + rel
                if dest_va == target_va:
                    print(f'  Call from VA 0x{call_site_va:X}')

find_calls(0x182124d30, 'Overlay_rbattle$$Load')
find_calls(0x182130960, 'Overlay_rbattle$$rbattleinit')
