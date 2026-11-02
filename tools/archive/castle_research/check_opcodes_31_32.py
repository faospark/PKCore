with open(r'd:\Appz\PKCore\tools\ec_opcode_specs.txt', 'r', encoding='utf-8') as f:
    text = f.read()

for line in text.splitlines():
    for op in range(28, 36):
        if f'[{op:03d}]' in line:
            print(line)
