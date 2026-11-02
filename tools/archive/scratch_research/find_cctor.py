with open(r'D:\SteamLibrary\steamapps\common\Suikoden I and II HD Remaster\GameAssembly.dll', 'rb') as f:
    # .cctor is at VA 0x18212F590, File Offset 0x212E190
    f.seek(0x212E190)
    data = f.read(0x1000)

for i in range(len(data)-3):
    # mov [rax + 0x68], ...
    if data[i] == 0x48 and data[i+1] == 0x89 and data[i+3] == 0x68:
        va = 0x18212F590 + i
        print(f'Found mov [rax + 0x68] at VA 0x{va:X}')
