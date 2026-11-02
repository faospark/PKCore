with open(r'd:\Appz\PKCore\Documentation\areas\dunan_castle_hq_concert_stage.md', 'r', encoding='utf-8') as f:
    text = f.read()

target = """# Suikoden II Geographic Area Catalog: Castle HQ: Concert Stage & Music Hall

**Geographic Scope & Role**: Entertainment floor; Karen's dance mini-game rhythm floor, musicians sound room, and theater performance stage.

**Regional Category**: Region `VK` | **Master Maps Included**: `vk09`"""

replacement = """# Suikoden II Geographic Area Catalog: Castle HQ: Concert Stage & Music Hall

**Geographic Scope & Role**: Entertainment floor; Karen's dance mini-game rhythm floor, musicians' rehearsal hall, and acoustic sound testing chambers. Driven natively by `EventOverlayClass.Overlay_h_dance` (`0x182109730` `danceinit`, `DanceMain`, `LessonDance`, `MakeQuestion`, `InputQuestion`, `CheckTiming`). Features Karen's dance challenges (awarding Karen Statues and Karen Paintings), stage recitals by the traveling musician trio (Annallee `fpno 113`, Pico `fpno 114`, Alberto `fpno 115`), and sound room / sound test configurations (with Connell's acoustic studio and Sound Sets #1–#7).

**Regional Category**: Region `VK` | **Master Maps Included**: `vk09`"""

if target in text:
    text = text.replace(target, replacement)
    with open(r'd:\Appz\PKCore\Documentation\areas\dunan_castle_hq_concert_stage.md', 'w', encoding='utf-8', newline='\r\n') as f:
        f.write(text)
    print("Successfully replaced header")
else:
    print("Target not found")
