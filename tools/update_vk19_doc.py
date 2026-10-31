with open(r'd:\Appz\PKCore\Documentation\areas\dunan_castle_hq_farm_and_pastures.md', 'r', encoding='utf-8') as f:
    text = f.read()

target = """# Suikoden II Geographic Area Catalog: Castle HQ: Tony's Farm & Pastures

**Geographic Scope & Role**: Agricultural sector; Tony's vegetable garden beds, seed planting plots, and Yuzu's animal breeding pens for sheep, cows, and pigs.

**Regional Category**: Region `VK` | **Master Maps Included**: `vk19`"""

replacement = """# Suikoden II Geographic Area Catalog: Castle HQ: Tony's Farm & Pastures

**Geographic Scope & Role**: Agricultural & pastoral sector; powered natively by `EventOverlayClass.FarmBase$$Farm` / `Farm108` (`0x181f809e0`), `FarmMain` (`0x181f7ff40`), and `Runch` / `Runch108` (`0x181f82360` ranch livestock system). Contains Tony's 12 crop plot planting beds (`obj[33]–obj[44]` at columns `x=6, 14, 22, 26`) for growing vegetables from collected seeds/seedlings (Cabbage, Spinach, Tomato, Potato) used in Hai Yo's kitchen recipes, and Yuzu's animal pens (`obj[15]–obj[26]`) breeding pigs, sheep, cows, and chickens behind fenced gates (`t_vk19_00_obj_fence01..fence07`).

**Regional Category**: Region `VK` | **Master Maps Included**: `vk19`"""

if target in text:
    text = text.replace(target, replacement)
    with open(r'd:\Appz\PKCore\Documentation\areas\dunan_castle_hq_farm_and_pastures.md', 'w', encoding='utf-8', newline='\r\n') as f:
        f.write(text)
    print("Successfully replaced header")
else:
    print("Target not found")
