import json

save_path = r'd:\SteamLibrary\steamapps\common\Suikoden I and II HD Remaster\SuikodenFix\Decrypted\gsd2\Data94.json'
with open(save_path, 'r', encoding='utf-8-sig') as f:
    d = json.load(f)

print("Active party (party_cha_no):", d['party_data']['party_cha_no'])
print("Castle base_lv:", d['game_data']['base_lv'])
print("event_flag[151]:", d['event_flag'][151])
print("event_flag[217]:", d['event_flag'][217])
print("Gengen chara_flag[16]:", d['chara_flag'][16])
print("Gabocha chara_flag[29]:", d['chara_flag'][29])
print("Current area_no:", d['game_data']['area_no'], "town_no:", d['game_data']['town_no'], "map_no:", d['game_data']['map_no'])
