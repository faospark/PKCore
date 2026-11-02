with open(r'd:\Appz\PKCore\Documentation\areas\dunan_castle_hq_teleport_and_elevator.md', 'r', encoding='utf-8') as f:
    text = f.read()

target = """# Suikoden II Geographic Area Catalog: Castle HQ: Viki Teleport & Mechanical Elevator

**Geographic Scope & Role**: Fast travel center; Viki's magical Blinking teleportation circle, and Adlai's counterweighted multi-floor castle elevator.

**Regional Category**: Region `VK` | **Master Maps Included**: `vk29`, `vk32`"""

replacement = """# Suikoden II Geographic Area Catalog: Castle HQ: Viki Teleport, Mechanical Elevator & Great Concourse Hall

**Geographic Scope & Role**: Fast-travel hub, elevator concourse, and sculptor's atrium. Across Castle HQ progression tiers (`vk29` baseline/mid-tier and `vk32` fully operational elevator installation), this grand concourse hall houses Viki's magical Blinking Mirror teleportation station (`fpno 105` / `5`, `obj[02]`, Text ID `1011290001`), Adlai's counterweighted multi-floor elevator (`obj[00]`, `obj[06]–obj[09]`, and `vk32` lift logic `ev[110]..ev[115]` servicing all castle levels), and the large sculpting hall where master sculptor Jude (`fpno 116`) sets up his workshop to assemble the castle's custom Guardian Deity statue from collected Blueprint Plans (Head, Body, Legs, Tail) before the grand unveiling (`vk33` unveiling cutscene sequence `1011330001`+).

**Regional Category**: Region `VK` | **Master Maps Included**: `vk29`, `vk32`"""

if target in text:
    text = text.replace(target, replacement)
    with open(r'd:\Appz\PKCore\Documentation\areas\dunan_castle_hq_teleport_and_elevator.md', 'w', encoding='utf-8', newline='\r\n') as f:
        f.write(text)
    print("Successfully replaced header")
else:
    print("Target not found")
