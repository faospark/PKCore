with open(r'd:\Appz\PKCore\Documentation\areas\dunan_castle_hq_living_quarters_and_corridors.md', 'r', encoding='utf-8') as f:
    text = f.read()

old_vk24 = """## Location Map: `vk24`

- **Master Map Container**: `vk24.json`
- **Submap Layer Files**: Embedded in master
- **Collision Grid Files**: None
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 1"""

new_vk24 = """## Location Map: `vk24` — Castle HQ: Tier 1 Assembly / Early Council (Pre-Restoration North Window)

- **Facility Role & Identity**: Early Tier 1 campaign staging state of the castle interior immediately following the liberation of North Window ruins, before the fortress is rebuilt into full Dunan Castle HQ. Viktor ponders their survival in a "busted-up old castle" (*"Which means... it's only a matter of time before the Highland Army comes sniffin' around here. Still... I don't much like our chances with only a few people and a busted-up old castle..."* Text ID `1011240053`). Staging roster includes Viktor (`fpno 91`), Flik (`fpno 5`), Apple (`fpno 53`), Klaus (`fpno 98`), Kiba (`fpno 88`), Shu (`fpno 89`), Tsai (`fpno 52`), Pilika (`fpno 124`), traveling circus trio (`fpno 19–21`), and early war council allies.
- **Master Map Container**: `vk24.json`
- **Submap Layer Files**: Embedded in master
- **Collision Grid Files**: None
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 1"""

if old_vk24 in text:
    text = text.replace(old_vk24, new_vk24)
    with open(r'd:\Appz\PKCore\Documentation\areas\dunan_castle_hq_living_quarters_and_corridors.md', 'w', encoding='utf-8', newline='\r\n') as f:
        f.write(text)
    print("Successfully updated vk24 header in living_quarters_and_corridors.md")
else:
    print("Target not found")
