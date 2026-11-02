with open(r'd:\Appz\PKCore\Documentation\areas\dunan_castle_hq_guardian_deity_shrine.md', 'r', encoding='utf-8') as f:
    text = f.read()

target = """# Suikoden II Geographic Area Catalog: Castle HQ: Jude's Guardian Deity Shrine

**Geographic Scope & Role**: Sacred sanctum; sculptor Jude's pedestal where the four-part custom guardian deity statue (Dragon, Unicorn, Rabbit, Turtle) is assembled.

**Regional Category**: Region `VK` | **Master Maps Included**: `vk33`"""

replacement = """# Suikoden II Geographic Area Catalog: Castle HQ: Guardian Deity Unveiling Hall (Concourse Alternate State)

**Geographic Scope & Role**: Alternate ceremonial state of the Viki / Adlai Grand Concourse Hall (`vk29`/`vk32`); stages the grand unveiling ceremony and party for sculptor Jude's completed Guardian Deity (`1011330001`–`1011330050`). Assembled from player-chosen Blueprint Plans (Head, Body, Legs, Tail: Dragon, Unicorn, Rabbit, Turtle), the finished statue rests on pedestal `obj[39]` (`fpno 34956`) surrounded by an assembly of castle stars (`obj[01]–obj[38]`) who react dynamically to its appearance (dignified, cute mascot, or horrifying monstrosity), after which the Guardian Deity animates to bestow special blessing items upon Riou.

**Regional Category**: Region `VK` | **Master Maps Included**: `vk33`"""

if target in text:
    text = text.replace(target, replacement)
    with open(r'd:\Appz\PKCore\Documentation\areas\dunan_castle_hq_guardian_deity_shrine.md', 'w', encoding='utf-8', newline='\r\n') as f:
        f.write(text)
    print("Successfully replaced header")
else:
    print("Target not found")
