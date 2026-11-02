with open(r'D:\Appz\Suisource\Il2CppDump\dump.cs', 'r', encoding='utf-8', errors='ignore') as f:
    capture = False
    count = 0
    for line in f:
        if 'public class EVENTCON : OldSrcMap' in line:
            capture = True
        if capture:
            if '(' in line and ')' in line and ';' in line and not line.strip().startswith('//'):
                print(' ', line.strip())
                count += 1
                if count > 40:
                    break
