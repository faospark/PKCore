with open(r'd:\Appz\PKCore\Documentation\areas\dunan_castle_hq_memorial_graveyard.md', 'r', encoding='utf-8') as f:
    text = f.read()

target = """# Suikoden II Geographic Area Catalog: Castle HQ: Memorial Graveyard

**Geographic Scope & Role**: Sacred lakeside bluff; memorial headstones dedicated to fallen comrades and deceased heroes of the unification war.

**Regional Category**: Region `VK` | **Master Maps Included**: `vk23`"""

replacement = """# Suikoden II Geographic Area Catalog: Castle HQ: Memorial Graveyard

**Geographic Scope & Role**: Sacred lakeside cemetery & memorial bluff; features 25+ individual interactive headstones, wooden crosses, and crypt coffins (`t_vk23_00_objact_tomb_01..03_`, `cross_02`, `coffin_01..02_`, `roadlamp_02`) with named epitaphs (Joe's Grave, Kyu's Grave, Joanne's Grave, Nora's Grave, Daisy's Grave, Spooky Grave, Moving Coffin). Serves as a mourning site for the Youth Brigade recruit (`fpno 3` mourning fallen comrades, Text ID `1011230049`), resting haunt for vampire progenitor Sierra Mikain (`fpno 45`), and wandering spot for Millie & Bonaparte (`fpno 83`), Tuta (`fpno 71`), and Adlai (`fpno 56`).

**Regional Category**: Region `VK` | **Master Maps Included**: `vk23`"""

if target in text:
    text = text.replace(target, replacement)
    with open(r'd:\Appz\PKCore\Documentation\areas\dunan_castle_hq_memorial_graveyard.md', 'w', encoding='utf-8', newline='\r\n') as f:
        f.write(text)
    print("Successfully replaced header")
else:
    print("Target not found")
