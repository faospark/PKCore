with open(r'd:\Appz\PKCore\Documentation\areas\dunan_castle_hq_living_quarters_and_corridors.md', 'r', encoding='utf-8') as f:
    text = f.read()

# Replace vk16 section header and description
old_vk16 = """## Location Map: `vk16`

- **Master Map Container**: `vk16.json`
- **Submap Layer Files**: Embedded in master
- **Collision Grid Files**: vk16_map_00.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 1"""

new_vk16 = """## Location Map: `vk16` — Castle HQ: 5F High Lookout Quarters / Extended Suite

- **Facility Role & Identity**: The highest residential chamber on the 5th floor (`t_vk16_00_base_all` with day/night lighting variants). Furnished with high-status wooden ceiling beams (`obj_Beam.png`), privacy curtains, water jugs, and upper-tier beds. Scene location where Riou catches imposter Hoi (`fpno 71`, `obj[00]`) sneaking around the top-floor guest rooms (*"Bwa! Oh, uh, I-I was just..."* Text ID `1011161070`). Connects down via stairs to Great Hall 5F Landing 12 (`vk10`) and across to Riou's upper master residence (`vk13`).
- **Master Map Container**: `vk16.json`
- **Submap Layer Files**: Embedded in master
- **Collision Grid Files**: vk16_map_00.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 1"""

# Replace vk17 section header and description
old_vk17 = """## Location Map: `vk17`

- **Master Map Container**: `vk17.json`
- **Submap Layer Files**: Embedded in master
- **Collision Grid Files**: vk17_map_00.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 5"""

new_vk17 = """## Location Map: `vk17` — Castle HQ: Dungeons, Prison Cells & Subterranean Waterway Passage

- **Facility Role & Identity**: Subterranean level containing the castle prison, holding cells, and waterway foundation corridors (`t_vk17_00_base_water.png`) connecting the fortress interior to the lower wharves and lakeside graveyard (`vk23`). Guard dialogue confirms: *"Beyond here you'll find the wharves, a dungeon, and... a graveyard."* (Text ID `1011170104`). Features vampire hunter Kahn Marley (`fpno 36`, `obj[01]` in Submap 2) patrolling the corridors, Millie & Bonaparte (`fpno 83`), and cells holding drunk brawlers and repeat offender Hoi (`fpno 71`, `obj[03]`) locked up for dine-and-dash (*"Aw, c'mon... All this for a little dine and dash? ... Oh, h-hey there, bro, heheh... Help a guy out, huh?"* Text ID `1011170107`).
- **Master Map Container**: `vk17.json`
- **Submap Layer Files**: Embedded in master
- **Collision Grid Files**: vk17_map_00.json
- **Sprite Animation Bundles**: None
- **Submap Room Count**: 5"""

if old_vk16 in text and old_vk17 in text:
    text = text.replace(old_vk16, new_vk16).replace(old_vk17, new_vk17)
    with open(r'd:\Appz\PKCore\Documentation\areas\dunan_castle_hq_living_quarters_and_corridors.md', 'w', encoding='utf-8', newline='\r\n') as f:
        f.write(text)
    print("Successfully updated vk16 and vk17 in living_quarters_and_corridors.md")
else:
    print("Could not match exact target text")
