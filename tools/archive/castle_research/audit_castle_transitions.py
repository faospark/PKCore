import json
import glob
import os

files = glob.glob(r'D:\Modding\suikodum\Mobobehaviour\vk*.json')
files.sort()

# Also let's load all vk*.json to know their submap counts and dimensions
map_info = {}
for f in files:
    name = os.path.basename(f)
    with open(f, 'r', encoding='utf-8') as fp:
        data = json.load(fp)
    mdat = data.get('mdat', {})
    submaps = mdat.get('submap', [])
    cl_list = mdat.get('cl', [])
    map_info[name] = {
        'num_submaps': len(submaps),
        'submaps': [{'chip_w': sm.get('chip_w', 0), 'chip_h': sm.get('chip_h', 0), 'clno': sm.get('clno', -1)} for sm in submaps],
        'cl': [{'w': c.get('w', 0), 'h': c.get('h', 0)} for c in cl_list]
    }

print(f"Loaded info for {len(map_info)} castle maps.")

# Now scan all scripts in all vk*.json
transitions = []
anomalies = []

for f in files:
    name = os.path.basename(f)
    with open(f, 'r', encoding='utf-8') as fp:
        data = json.load(fp)
    mdat = data.get('mdat', {})
    edat_list = mdat.get('eventdat', [])
    num_submaps = map_info[name]['num_submaps']
    
    for sm_idx, edat in enumerate(edat_list):
        scripts = edat.get('scripts', [])
        for s_idx, sc in enumerate(scripts):
            ecom = sc.get('eventCom', [])
            eform = sc.get('eventForm', [])
            etyp = sc.get('etyp', 0)
            
            # Scan ecom for opcodes 31, 32, 35
            i = 0
            while i < len(ecom):
                op = ecom[i]
                if op == 254 or op == 255:
                    i += 1
                    continue
                if op == 31: # ECSMapChenge(submap, x, y)
                    if i + 3 < len(ecom):
                        target_sm = ecom[i+1]
                        tx = ecom[i+2]
                        ty = ecom[i+3]
                        transitions.append({
                            'map': name, 'src_sm': sm_idx, 'script': s_idx, 'op': 31,
                            'target_sm': target_sm, 'tx': tx, 'ty': ty, 'etyp': etyp,
                            'eform': eform
                        })
                        # Check validity
                        if target_sm >= num_submaps:
                            anomalies.append({
                                'type': 'INVALID_SUBMAP_TARGET',
                                'map': name, 'src_sm': sm_idx, 'script': s_idx,
                                'detail': f"Target submap {target_sm} >= available submaps ({num_submaps}) in {name}",
                                'tx': tx, 'ty': ty
                            })
                        else:
                            # Check coordinates vs submap bounds
                            sm_meta = map_info[name]['submaps'][target_sm]
                            cw = sm_meta['chip_w']
                            ch = sm_meta['chip_h']
                            if tx >= cw or ty >= ch:
                                anomalies.append({
                                    'type': 'OUT_OF_BOUNDS_TARGET_COORDS',
                                    'map': name, 'src_sm': sm_idx, 'script': s_idx,
                                    'detail': f"Target coords ({tx}, {ty}) exceed submap {target_sm} size ({cw}x{ch}) in {name}"
                                })
                        i += 4
                    else:
                        i += 1
                elif op == 32: # ECMapChenge
                    # Let's record the bytes following op 32
                    rest = ecom[i+1:i+6]
                    transitions.append({
                        'map': name, 'src_sm': sm_idx, 'script': s_idx, 'op': 32,
                        'args': rest, 'etyp': etyp, 'eform': eform
                    })
                    i += 1
                elif op == 35: # ECMachiChengeM
                    rest = ecom[i+1:i+6]
                    transitions.append({
                        'map': name, 'src_sm': sm_idx, 'script': s_idx, 'op': 35,
                        'args': rest, 'etyp': etyp, 'eform': eform
                    })
                    i += 1
                else:
                    i += 1

print(f"Total Opcode 31 calls: {len([t for t in transitions if t['op'] == 31])}")
print(f"Total Opcode 32 calls: {len([t for t in transitions if t['op'] == 32])}")
print(f"Total Opcode 35 calls: {len([t for t in transitions if t['op'] == 35])}")
print(f"Anomalies found: {len(anomalies)}")
for a in anomalies:
    print(a)

with open(r'd:\Appz\PKCore\tools\transitions_summary.json', 'w') as out:
    json.dump({'anomalies': anomalies, 'sample_32': [t for t in transitions if t['op'] == 32], 'sample_35': [t for t in transitions if t['op'] == 35]}, out, indent=2)
