import json

def check_map(map_name):
    path = f'D:/Modding/suikodum/Mobobehaviour/{map_name}.json'
    try:
        with open(path, 'r') as f:
            data = json.load(f)
    except Exception as e:
        print(f'Failed to open {map_name}: {e}')
        return

    print(f'=== MAP {map_name} ===')
    for s_idx, sub in enumerate(data.get('eventdata', {}).get('mapeventdat', [])):
        for d_idx, edat in enumerate(sub.get('eventdat', [])):
            ef = edat.get('eventForm', [])
            ec = edat.get('eventCom', [])
            # Search both ef and ec
            for name, code in [('Form', ef), ('Com', ec)]:
                matches = []
                for i in range(len(code)-2):
                    if code[i] in [1, 2, 3, 4] and code[i+1] in [61, 71, 72, 132, 148, 152, 153]:
                        op_str = {1: 'Set', 2: 'Clear', 3: 'If', 4: 'IfNot'}.get(code[i], str(code[i]))
                        matches.append(f'{op_str}(flag[{code[i+1]}], bit={code[i+2]})')
                if matches:
                    print(f'Submap {s_idx} ev[{d_idx}] {name} (len={len(code)}): {", ".join(matches)}')

check_map('vk06')
check_map('vk05')
check_map('vk30')
