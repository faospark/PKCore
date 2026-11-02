import subprocess

# Let's run sym.bat on GAME_DATA.ero_lv
res = subprocess.run([r'd:\Appz\sym.bat', 'GAME_DATA.ero_lv'], capture_output=True, text=True)
print(res.stdout)
