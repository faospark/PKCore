with open(r'd:\Appz\PKCore\Documentation\areas\dunan_castle_hq_living_quarters_and_corridors.md', 'r', encoding='utf-8') as f:
    text = f.read()

import re
matches = [m.start() for m in re.finditer(r'Submap Layer `vk13_04`', text)]
for idx in matches:
    print(text[idx+9000:idx+13000])
