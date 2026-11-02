import glob, os, json

cook_maps = ['vk06', 'vk05', 'vk30', 'vk19', 'vk01']
flags = set()

for mname in cook_maps:
    fpath = f'D:/Modding/suikodum/Mobobehaviour/{mname}.json'
    try:
        with open(fpath, 'r', encoding='utf-8') as f:
            data = json.load(f)
    except:
        continue
    for s_idx, sub in enumerate(data.get('eventdata', {}).get('mapeventdat', [])):
        for e_idx, edat in enumerate(sub.get('eventdat', [])):
            for code in [edat.get('eventForm', []), edat.get('eventCom', [])]:
                for i in range(len(code)-2):
                    # Flag opcodes: 1, 2, 3, 4, 9, 10
                    if code[i] in [1, 2, 3, 4, 9, 10]:
                        b = code[i+1]
                        bit = code[i+2]
                        if b in [61, 71, 72, 131, 132, 134, 148, 150, 152, 153]:
                            flags.add((b, bit))

print('All flags referenced in cook-off maps:')
for b, bit in sorted(flags):
    print(f'  byte {b}, bit {bit} (0x{bit:02X})')
