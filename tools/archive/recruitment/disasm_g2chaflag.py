import subprocess

cmd = 'd:\\Appz\\disasm.bat 0x181a29990 400'
res = subprocess.run(cmd, capture_output=True, text=True, shell=True).stdout

for line in res.splitlines():
    print(line)
