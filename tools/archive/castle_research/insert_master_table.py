import os, re
from collections import Counter

dir_path = r"D:\Modding\suikodum\Mobobehaviour"
doc_path = r"d:\Appz\PKCore\Documentation\mobobehaviour_catalog.md"

files = sorted(os.listdir(dir_path))

cats = Counter()
game_cats = {'S1': Counter(), 'S2': Counter(), 'Shared': Counter(), 'Launcher': Counter()}

s1_pats = ['pan_teo', 'war_teo', 'war_kita', 'g1_', 'gs1', 'gsd1', 'HDCREDITS_GSD1', 'CREDITS_GSD1']

for f in files:
    stem = os.path.splitext(f)[0]
    fl = f.lower()
    
    # 1. Launcher
    if 'launcher' in fl:
        c = 'Top-Level Launcher Hub'
        g = 'Launcher'
    # 2. Suikoden 1
    elif any(p in fl for p in s1_pats) or (fl.startswith('war_') and not fl.startswith('warhd') and not fl.startswith('warui')):
        g = 'S1'
        if fl.startswith('war_') or 'war_teo' in fl or 'war_kita' in fl:
            if 'postprocess' in fl:
                c = 'War Battle Post-Processing Profiles'
            else:
                c = 'Tactical War Battles'
        elif 'pan_teo' in fl:
            c = 'One-on-One Duels (Pahn vs. Teo)'
        else:
            c = 'Core Engine, Foliage & Credits'
    # 3. Shared
    elif fl.endswith('sdf.json'):
        c = 'TextMeshPro Font SDF Assets'
        g = 'Shared'
    elif fl.startswith('cri'):
        c = 'CRIWARE Audio Middleware'
        g = 'Shared'
    elif fl.startswith('postprocess') or fl == 'colorgrading.json':
        c = 'Post-Processing Stack Profiles'
        g = 'Shared'
    elif fl in ['dotweenanimation.json', 'dotweenvisualmanager.json']:
        c = 'DOTween Procedural Tweens'
        g = 'Shared'
    elif fl in ['button.json', 'image.json', 'text.json', 'textmeshpro.json', 'textmeshprougui.json', 'scrollrect.json', 'scrollbar.json', 'slider.json', 'toggle.json', 'togglegroup.json', 'contentsizefitter.json', 'gridlayoutgroup.json', 'horizontallayoutgroup.json', 'verticallayoutgroup.json', 'outline.json', 'shadow.json', 'mask.json', 'rawimage.json', 'rectmask2d.json']:
        c = 'Standard Unity UI Engine Components'
        g = 'Shared'
    # 4. Suikoden 2
    else:
        g = 'S2'
        if fl.startswith('boss_'):
            if '_obj' in fl:
                c = 'Boss Arena 3D Props & Geometry'
            elif '_res_' in fl:
                c = 'Boss Signature VFX & Resources'
            else:
                c = 'Boss Entities & Combat AI'
        elif re.match(r'^[a-z]_data', fl):
            if 'party' in fl:
                c = 'Monster Party Formations (6-Slot Grids)'
            elif 'monster_data' in fl:
                c = 'Monster Stats, Drop Rates & AI'
            else:
                c = 'Battle Region Encounter Tables'
        elif fl.startswith('eb_'):
            c = 'Story Event Battles'
        elif fl.startswith('hp_furo') or fl.startswith('hdbath'):
            c = 'HQ Bathhouse Scene Configurations'
        elif fl.startswith('hp_chin') or fl == 'coinpanel.json':
            c = 'HQ Chinchirorin Dice Minigame'
        elif fl.startswith('hp_fish'):
            c = 'HQ Hai Yo Fishing Pond Minigame'
        elif fl.startswith('hp_kikori'):
            c = 'HQ Wood Chopping Minigame'
        elif fl.startswith('hp_book'):
            c = 'HQ Library Readable Old Books'
        elif fl.startswith('hp_hsound'):
            c = 'HQ Castle Jukebox Playlists'
        elif fl.startswith('hp_hmap'):
            c = 'HQ Detective Investigation Maps'
        elif fl.startswith('player_'):
            c = 'Playable Combat Hero Packages'
        elif '_field_' in fl:
            c = 'Overworld Field NPC Sprites & Triggers'
        elif fl.startswith('fe_dat'):
            c = 'Field Event Bytecode & Scenarios'
        elif fl.startswith('unite'):
            c = 'Tactical Unite Attack Choreography'
        elif re.match(r'^[v|w][a-z][0-9]{2}', fl):
            if len(stem) == 4 or (len(stem) > 4 and stem[4] in ['b', 'c']):
                c = 'Map Core Data (MACHIDAT Bytecode)'
            else:
                c = 'Map 3D HD Sub-Layers & Lighting Props'
        elif fl.startswith('uibattle'):
            c = 'Combat Battle HUD Subsystems'
        elif fl.startswith('uimain'):
            c = 'Main Menu & Party Management'
        elif fl.startswith('uisaveload'):
            c = 'Save/Load Memory Card Subsystems'
        elif fl.startswith('uiconfig'):
            c = 'Options & Configuration UI'
        elif fl.startswith('uigallery'):
            c = 'Bonus Gallery & Sound Player UI'
        elif fl.startswith('backlog'):
            c = 'Dialogue Backlog History Buffer'
        elif fl.startswith('map'):
            c = 'HD Map Engine Utilities & Shaders'
        elif 'timeline' in fl or 'track' in fl or fl.startswith('eff_') or fl.startswith('em2_') or fl.startswith('tl_') or fl in ['action.json', 'effect.json', 'cursor.json']:
            c = 'Cinematic & Skill Timelines'
        else:
            c = 'General Game Engine & Character Data'

    cats[c] += 1
    game_cats[g][c] += 1

out = []
out.append("---")
out.append("")
out.append("## Master Collated System Distribution Table (Global 4,733 Assets)")
out.append("")
out.append("A complete, unified system-level distribution table across all 4,733 serialized MonoBehaviour assets, collating their category, exact file count, primary game scope, and percentage share.")
out.append("")
out.append("| System / Component Category | Exact Count | Game Scope | % Share | Functional Description |")
out.append("|---|---|---|---|---|")

cat_desc = {
    'General Game Engine & Character Data': 'Core character profiles, entity parameters, and auxiliary game data.',
    'Map 3D HD Sub-Layers & Lighting Props': 'Modern 3D HD environmental meshes, camera boundaries, dynamic lighting, and particle anchors.',
    'Map Core Data (MACHIDAT Bytecode)': 'Legacy PS1 logical map event data, NPC spawn coordinates, walkability collision grids, and warps.',
    'Overworld Field NPC Sprites & Triggers': '4-directional overworld character sprites, walk cycles, speech bubble anchors, and interaction boundaries.',
    'Story Event Battles': 'Scripted narrative combat encounters with custom win/loss conditions, turn limits, and story interventions.',
    'Playable Combat Hero Packages': '3D combat meshes, battle action tables, weapon sockets, and special critical proc animations.',
    'Boss Entities & Combat AI': 'Boss parameter profiles, multi-target body structures, HP threshold phase changes, and combat scripts.',
    'Tactical Unite Attack Choreography': 'Multi-character combination attacks, weapon animations, damage coefficients, and VFX synchronization.',
    'Monster Party Formations (6-Slot Grids)': 'Tactical enemy deployment formations (Front/Back row slots) and encounter condition flags.',
    'Monster Stats, Drop Rates & AI': 'Enemy unit combat parameters (HP, MP, STR, DEF, elemental affinities, potch, item drop rates).',
    'Tactical War Battles': 'Full army war battles (numbered 01-16 and fortress campaigns) with casualty formulas and commander triggers.',
    'HQ Bathhouse Scene Configurations': '44 Castle Bathhouse party-combination conditions, bathing animations, dialogue triggers, and water colors.',
    'Battle Region Encounter Tables': 'Dungeon and road encounter rate formulas, ambient arena environments, and battle background effects.',
    'Cinematic & Skill Timelines': 'Unity PlayableDirector timelines synchronizing magic spell particles, camera moves, and cutscenes.',
    'Boss Signature VFX & Resources': 'Special boss spell particle effects, dark rune summoning sequences, and unique combat animations.',
    'Field Event Bytecode & Scenarios': 'Scripted map cutscenes, environmental triggers, and story progression milestone events.',
    'Post-Processing Stack Profiles': 'Color grading LUTs, tonemapping curves, bloom, vignette, and ambient occlusion per map.',
    'Standard Unity UI Engine Components': 'Unity UI components: LayoutGroups, Button, ScrollRect, Slider, Toggle, Mask, Outline, Shadow, Text.',
    'HD Map Engine Utilities & Shaders': 'Parallax scrolling, animated map tiles, water reflection planes, and footstep sound surfaces.',
    'Boss Arena 3D Props & Geometry': 'Boss arena 3D collision geometry, background environment models, and arena props.',
    'Combat Battle HUD Subsystems': 'Battle combat menu (Fight, Auto, Run, Bribe, Magic, Unite, Item) and player status gauges.',
    'Main Menu & Party Management': 'Party formation rearrangement, equipment equipping, rune attunement, and stat inspections.',
    'Core Engine, Foliage & Credits': 'S1 master palette indexing table, tree wind shaders, system flags, and staff roll credits.',
    'HQ Castle Jukebox Playlists': 'Castle sound room music player track playlists and sound room dialogue data.',
    'HQ Detective Investigation Maps': 'Castle floor maps tracking recruit locations, detective clues, and character background dossiers.',
    'Top-Level Launcher Hub': 'Game selection hub carousel timeline, 3D animated background, options, and gallery timelines.',
    'CRIWARE Audio Middleware': 'CRI Atom sound emitters, 3D spatial attenuation distance curves, and audio listener mappers.',
    'HQ Hai Yo Fishing Pond Minigame': 'Fishing pond mechanics, fish species tables, bite timers, line tension, and prize drops.',
    'HQ Wood Chopping Minigame': 'Wood chopping timing accuracy windows, stamina gauge decay rates, and timber delivery quotas.',
    'Options & Configuration UI': 'Sound volume sliders, graphics settings, button remapping, and language localization toggles.',
    'Bonus Gallery & Sound Player UI': 'Artwork gallery viewers, sound tests, and character model viewers in the bonus menu.',
    'One-on-One Duels (Pahn vs. Teo)': 'Pahn vs. Teo duel animation tables, arena staging camera anchors, and field render assets.',
    'TextMeshPro Font SDF Assets': 'Signed Distance Field (SDF) glyph atlas files, font metrics, and kerning pairs (CJK & Western).',
    'HQ Library Readable Old Books': 'Serialized reader volumes storing lore and chapter text for the 12 collectible Old Books.',
    'Save/Load Memory Card Subsystems': 'Save slot metadata serialization, playtime counters, hero portraits, and confirmation dialogs.',
    'Dialogue Backlog History Buffer': 'Modern HD Remaster dialogue review buffer caching recent conversations with instant scrollback.',
    'HQ Chinchirorin Dice Minigame': 'Dice physics, betting thresholds, payout multipliers, and opponent reaction portraits.',
    'DOTween Procedural Tweens': 'Demigiant DOTween visual animation controllers for smooth UI window transitions.',
    'War Battle Post-Processing Profiles': 'Specialized post-processing color grading profiles for S1 Northern Checkpoint and Teo war battles.'
}

for c, cnt in cats.most_common():
    pct = (cnt / 4733) * 100
    # Determine primary game scope
    if c in game_cats['S1'] and game_cats['S1'][c] == cnt:
        scope = "Suikoden I"
    elif c in game_cats['Launcher']:
        scope = "Launcher"
    elif c in game_cats['Shared']:
        scope = "Shared Engine"
    elif c in ['Tactical War Battles', 'One-on-One Duels (Pahn vs. Teo)', 'Core Engine, Foliage & Credits', 'War Battle Post-Processing Profiles']:
        scope = "Suikoden I"
    else:
        scope = "Suikoden II"
    desc = cat_desc.get(c, "Serialized game component.")
    out.append(f"| **{c}** | **{cnt:,} files** | {scope} | {pct:.2f}% | {desc} |")

out.append("")
out.append("---")
out.append("")
out.append("### Collated System Distribution Lists (Exact Requested Format)")
out.append("")
out.append("#### 1. Suikoden II System Distribution (4,613 Files)")
out.append("")
for c, cnt in game_cats['S2'].most_common():
    out.append(f"- **{c}**: {cnt} files")

out.append("")
out.append("#### 2. Suikoden I System Distribution (69 Files)")
out.append("")
for c, cnt in game_cats['S1'].most_common():
    out.append(f"- **{c}**: {cnt} files")

out.append("")
out.append("#### 3. Top-Level Launcher Hub System Distribution (8 Files)")
out.append("")
for c, cnt in game_cats['Launcher'].most_common():
    out.append(f"- **{c}**: {cnt} files")

out.append("")
out.append("#### 4. Shared Engine & Framework System Distribution (43 Files)")
out.append("")
for c, cnt in game_cats['Shared'].most_common():
    out.append(f"- **{c}**: {cnt} files")

out.append("")

collated_text = "\n".join(out)

# Read current catalog
with open(doc_path, "r", encoding="utf-8") as f:
    current_doc = f.read()

# Insert right after ## Master Technical Notes & System Distribution (Collated Cross-Game Analysis)
target_header = "## Master Technical Notes & System Distribution (Collated Cross-Game Analysis)"
idx = current_doc.find(target_header)
if idx != -1:
    end_of_header = current_doc.find("---", idx)
    # Find next section: Part A
    part_a_idx = current_doc.find("### Part A: Suikoden I", idx)
    if part_a_idx != -1:
        new_doc = current_doc[:part_a_idx] + collated_text + "\n" + current_doc[part_a_idx:]
        with open(doc_path, "w", encoding="utf-8") as f:
            f.write(new_doc)
        print("Master table and list successfully inserted!")
    else:
        print("Part A header not found")
else:
    print("Target header not found")
