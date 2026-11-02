with open(r'd:\Appz\PKCore\Documentation\areas\dunan_castle_hq_restaurant_and_kitchen.md', 'r', encoding='utf-8') as f:
    text = f.read()

target = """# Suikoden II Geographic Area Catalog: Castle HQ: Hai Yo's Restaurant & Kitchen

**Geographic Scope & Role**: Culinary arena; Hai Yo's Iron Chef cook-off dueling stadium, dining tables, food storage, and menu recipe book shelves.

**Regional Category**: Region `VK` | **Master Maps Included**: `vk20`"""

replacement = """# Suikoden II Geographic Area Catalog: Castle HQ: Hai Yo's Restaurant & Kitchen

**Geographic Scope & Role**: Culinary arena & dining hall; powered natively by `EventOverlayClass.h_rest` (`0x18218dba0` `restinit`, `RestMain`, `RestFirstStep`, `RestEatStep`, `RestMenuStep`, `RecipeDisplay`, `NecessaryIngredients`, `SeasoningDisplay`, `MenuDisplay`). Consists of 2 interconnected submaps: Submap 0 (`vk20_00`) housing the customer dining hall and tasting judge tables, and Submap 1 (`vk20_01`) containing Hai Yo's prep kitchen and cook-off dueling stadium for the 16-battle tournament against the Black Dragon Cooking Clan over the Moon Screen Recipe and Dragon Spoon. Accepts Recipes #1–#40 and fresh ingredients supplied from Tony's farm (`vk19`).

**Regional Category**: Region `VK` | **Master Maps Included**: `vk20`"""

if target in text:
    text = text.replace(target, replacement)
    with open(r'd:\Appz\PKCore\Documentation\areas\dunan_castle_hq_restaurant_and_kitchen.md', 'w', encoding='utf-8', newline='\r\n') as f:
        f.write(text)
    print("Successfully replaced header")
else:
    print("Target not found")
