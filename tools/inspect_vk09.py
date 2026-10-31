import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vk09.json', 'r', encoding='utf-8') as f:
    vk09 = json.load(f)

# Let's inspect Map 1 and Map 2 in vk09.md to see what is currently written
with open(r'd:\Appz\PKCore\Documentation\areas\dunan_castle_hq_concert_stage.md', 'r', encoding='utf-8') as f:
    md_lines = f.readlines()

print("Total lines in md:", len(md_lines))
for i, line in enumerate(md_lines):
    if "### Submap Layer `vk09_01`" in line or "### Submap Layer `vk09_02`" in line:
        print(f"Line {i}: {line.strip()}")
