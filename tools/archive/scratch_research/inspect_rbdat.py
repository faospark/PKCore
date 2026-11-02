with open(r'D:\Appz\Suisource\Il2CppDump\dump.cs', 'r', encoding='utf-8', errors='ignore') as f:
    capture = False
    count = 0
    for line in f:
        if 'class rb_dat' in line:
            capture = True
        if capture:
            if 'challenger' in line:
                print(line.strip())
                count += 1
                if count > 25:
                    break
