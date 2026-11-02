import json

path = r'D:\SteamLibrary\steamapps\common\Suikoden I and II HD Remaster\SuikodenFix\Decrypted\gsd2\Data155.json'
with open(path, 'r', encoding='utf-8-sig') as f:
    save = json.load(f)

print('Keys in save:', list(save.keys()) if isinstance(save, dict) else len(save))
if isinstance(save, dict):
    for k in ['event_flag', 'event_time', 'food_menu', 'food_resipi', 'food_num']:
        if k in save:
            val = save[k]
            if isinstance(val, list):
                print(f'{k}: len={len(val)}')
                if k == 'event_flag':
                    print('event_flag[61]:', val[61], f'(0x{val[61]:02X})')
                    print('event_flag[71]:', val[71], f'(0x{val[71]:02X})')
                    print('event_flag[72]:', val[72], f'(0x{val[72]:02X})')
                    print('event_flag[148]:', val[148], f'(0x{val[148]:02X})')
                    print('event_flag[152]:', val[152], f'(0x{val[152]:02X})')
                    print('event_flag[153]:', val[153], f'(0x{val[153]:02X})')
        elif 'game_data' in save and k in save['game_data']:
            val = save['game_data'][k]
            print(f'game_data.{k}: len={len(val)}')
