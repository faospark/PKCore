import subprocess

cmd = 'd:\\Appz\\disasm.bat 0x181f835e0 1000'
res = subprocess.run(cmd, capture_output=True, text=True, shell=True).stdout

calls = []
for line in res.splitlines():
    if 'call' in line or 'jmp' in line:
        calls.append(line.strip())

print(f"Found {len(calls)} calls in S108InMain:")
for c in calls:
    print(" ", c)
