import json

with open(r'd:\SteamLibrary\steamapps\common\Suikoden I and II HD Remaster\SuikodenFix\Decrypted\gsd2\Data0.json', 'r', encoding='utf-8-sig') as f:
    save = json.load(f)

gd = save['game_data']
print("game_data keys:", list(gd.keys()))
for k in ['base_lv', 'base_level', 'machi_no', 'map_no', 'pno', 'hero_name', 'castle_name']:
    if k in gd:
        print(f"  {k}: {gd[k]}")

for k in gd:
    if 'base' in k.lower() or 'lv' in k.lower():
        print(f"  {k}: {gd[k]}")
