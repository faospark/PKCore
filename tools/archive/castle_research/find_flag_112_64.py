import os, glob, json

MOB_DIR = r"D:\Modding\suikodum\Mobobehaviour"
vk_files = glob.glob(os.path.join(MOB_DIR, "*.json"))

count = 0
examples = []

for fpath in vk_files:
    fname = os.path.basename(fpath)
    with open(fpath, 'r', encoding='utf-8', errors='ignore') as fp:
        try:
            d = json.load(fp)
        except:
            continue
    subs = d.get('eventdata', {}).get('mapeventdat', [])
    for s_idx, sub in enumerate(subs):
        for e_idx, ev in enumerate(sub.get('eventdat', [])):
            form = ev.get('eventForm', [])
            # Search for pattern 3, 112, 64
            for i in range(len(form) - 2):
                if form[i] == 3 and form[i+1] == 112 and form[i+2] == 64:
                    count += 1
                    if len(examples) < 10:
                        examples.append((fname, s_idx, e_idx, ev.get('etyp')))

print(f"Total scripts checking [3, 112, 64]: {count}")
for ex in examples:
    print(" ", ex)

