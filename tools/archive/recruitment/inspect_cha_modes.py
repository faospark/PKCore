import struct

with open('d:/SteamLibrary/steamapps/common/Suikoden I and II HD Remaster/GameAssembly.dll', 'rb') as f:
    data = f.read()

base_va = 0x180000000
table_va = 0x181a2a380
table_offset = table_va - base_va

for mode in range(12):
    disp = struct.unpack('<i', data[table_offset + mode*4 : table_offset + (mode+1)*4])[0]
    target_va = 0x181a299ea + disp
    print(f"Mode {mode}: target VA = {hex(target_va)}")
