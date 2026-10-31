import json

with open(r'd:\Modding\suikodum\Mobobehaviour\vk13.json', 'r', encoding='utf-8') as f:
    vk13 = json.load(f)

print("vk13 overlay_func:", vk13.get('overlay_func'))

# Let's inspect submap 0, 1, 2, 3, 4, 5, 6, 7, 8 in vk13:
# Look at texture filenames used for each submap:
# MM_vk13_00 -> 00 (Riou's room / main residential hall)
# MM_vk13_01 -> 01 (corridor / guest rooms)
# MM_vk13_02 -> 02 (corridor / training room with barbells and straw dolls: t_vk13_02_obj_barbell.png, t_vk13_02_obj_Straw doll.png)
