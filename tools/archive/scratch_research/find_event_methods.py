with open(r'D:\Appz\Suisource\Il2CppDump\dump.cs', 'r', encoding='utf-8', errors='ignore') as f:
    for line in f:
        if 'EVENTCON' in line and ('EventExec' in line or 'EventCom' in line or 'EventForm' in line or 'Command' in line or 'Opcode' in line):
            print(line.strip())
