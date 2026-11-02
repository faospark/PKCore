with open(r'd:\Appz\PKCore\Documentation\areas\dunan_castle_hq_living_quarters_and_corridors.md', 'r', encoding='utf-8') as f:
    lines = f.readlines()

legend = lines[9:29] # Legend lines

# Lines 0..29 are header & scope
# Lines 29..758 are vk13
header_vk13 = [
    "# Suikoden II Geographic Area Catalog: Castle HQ: Riou's Suite & Upper Residence\n",
    "\n",
    "**Geographic Scope & Role**: Commander Riou's private suite & upper residential wing (`vk13`). Features Riou's personal bedroom with the primary Castle HQ Save Crystal Orb (`obj[14]` at `(26, 18)`) and Inn Rest Bed (`obj[15]` at `(26, 24)`), which triggers overnight story transitions and morning dialogue with Nanami (Text ID `1007080163`). Includes upper residential hallways, guest rooms (`vk13_01`), personal training quarters with sparring barbells and straw dolls (`vk13_02`), and mechanical elevator landings (`t_vk13_00_obj_liftDoor01_00..04`) connecting to Adlai's elevator shaft (`vk29`/`vk32`).\n",
    "\n",
    "**Regional Category**: Region `VK` | **Master Maps Included**: `vk13`\n",
    "\n",
    "**Grounding Reference**: Compiled from `suikoden_2_map_ids_and_areas_breakdown.md` and direct bytecode inspection of all corresponding assets in `D:\Modding\suikodum\Mobobehaviour`.\n",
    "\n",
    "---\n",
    "\n"
]

vk13_content = header_vk13 + legend + lines[29:758]

with open(r'd:\Appz\PKCore\Documentation\areas\dunan_castle_hq_riou_quarters_and_residence.md', 'w', encoding='utf-8', newline='\r\n') as f:
    f.writelines(vk13_content)

print(f"Created dunan_castle_hq_riou_quarters_and_residence.md with {len(vk13_content)} lines.")

# Now rewrite dunan_castle_hq_living_quarters_and_corridors.md without vk13
header_living = [
    "# Suikoden II Geographic Area Catalog: Castle HQ: Living Quarters & Corridors\n",
    "\n",
    "**Geographic Scope & Role**: Fortress residential hallways, officer bedrooms, secret passages, guest lounges, and connecting stairwells across the interior and lower bastions (`vk16`, `vk17`, `vk24`, `vk25`, `vk26`, `vk27`, `vk28`, `vk30`, `vk35`, `vk36`, `vk37`). Note: Commander Riou's personal suite is cataloged in `dunan_castle_hq_riou_quarters_and_residence.md` (`vk13`).\n",
    "\n",
    "**Regional Category**: Region `VK` | **Master Maps Included**: `vk16`, `vk17`, `vk24`, `vk25`, `vk26`, `vk27`, `vk28`, `vk30`, `vk35`, `vk36`, `vk37`\n",
    "\n",
    "**Grounding Reference**: Compiled from `suikoden_2_map_ids_and_areas_breakdown.md` and direct bytecode inspection of all corresponding assets in `D:\Modding\suikodum\Mobobehaviour`.\n",
    "\n",
    "---\n",
    "\n"
]

living_content = header_living + legend + lines[758:]

with open(r'd:\Appz\PKCore\Documentation\areas\dunan_castle_hq_living_quarters_and_corridors.md', 'w', encoding='utf-8', newline='\r\n') as f:
    f.writelines(living_content)

print(f"Rewrote dunan_castle_hq_living_quarters_and_corridors.md with {len(living_content)} lines.")
