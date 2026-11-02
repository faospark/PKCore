# Let's inspect where EventControll reads opcodes from eventCom!
# In EventControll:
# It calls COMMAND_LINE.Advance() to get the opcode byte!
# Then it looks up the opcode handler in a table or switch!
import subprocess

cmd = 'd:\\Appz\\disasm.bat 0x18214e660 300'
res = subprocess.run(cmd, capture_output=True, text=True, shell=True).stdout
print(res[:2000])
