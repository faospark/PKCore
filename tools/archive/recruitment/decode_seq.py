# Let's inspect each opcode in all_opcodes.txt
opcodes = {}
for line in open('d:/Appz/PKRecruitmentPatch/all_opcodes.txt'):
    if line.startswith('Opcode'):
        # Opcode   0 (0x00): EVENTCON$$ECEvFlgSet
        parts = line.split(':')
        op_num = int(parts[0].split()[1])
        func = parts[1].strip().replace('EVENTCON$$', '')
        opcodes[op_num] = func

seq = [101, 4, 6, 5, 0, 2, 0, 5, 3, 1, 0, 5, 3, 3, 0, 5, 3, 0, 0, 5, 3, 30, 89, 0, 2, 8, 89, 0, 5, 89, 0, 5, 73, 10, 89, 0, 2, 9, 5, 0, 6, 2, 30, 89, 0, 2, 10, 89, 0, 5, 89, 0, 5, 73, 10, 30, 3, 1, 27, 5, 0, 0, 0, 5, 15, 0, 0, 30]

print("Sequence length:", len(seq))
