with open(r'D:\Appz\Suisource\Il2CppDump\dump.cs', 'r', encoding='utf-8', errors='ignore') as f:
    capture = False
    for line in f:
        if 'class Overlay_rbattle' in line:
            capture = True
        if capture:
            if 'static' in line:
                print(line.strip())
            if 'public class' in line and 'Overlay_rbattle' not in line:
                break
