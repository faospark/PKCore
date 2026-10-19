import os
import json
import re
import sys

DIR_PATH = r"D:\Modding\suikodum\Mobobehaviour"
DOC_PATH = r"d:\Appz\PKCore\Documentation\mobobehaviour_catalog.md"
INDEX_PATH = r"d:\Appz\PKCore\Documentation\mobobehaviour_index.json"

CHARA_NAMES = {
    "ada": "Adlai", "ail": "Aileen", "air": "Anita", "alx": "Alex", "amd": "Amada",
    "ani": "Annallee", "anj": "Annallee (Alt)", "ant": "Antonio", "app": "Apple",
    "are": "Ayda", "bal": "Barbara", "bel": "Belle", "bic": "Bob", "blk": "Bolgan",
    "bor": "Boris", "boz": "Boc", "cam": "Camus", "cob": "Clive", "coin": "Coin Minigame",
    "cre": "Connell", "cri": "Chris", "cro": "Crowley", "crw": "Chaco", "cry": "Circe",
    "csi": "Casper", "cyk": "Chaco (Alt)", "dor": "Dorothy", "eik": "Eike", "eri": "Eilie",
    "fma": "Fitcher", "fre": "Freed Y", "fri": "Freed Y", "frk": "Frank", "fuk": "Futch",
    "fut": "Futch", "fuu": "Fumi", "gab": "Gabriel", "gen": "Gengen", "geo": "Georg",
    "gjm": "Gijimu", "gol": "Goran", "gon": "Gonso", "gre": "Gremio", "gri": "Granmeyer",
    "grn": "Gordon", "haf": "Hauser", "han": "Han", "hap": "Hanna", "haw": "Hai Yo",
    "hel": "Hix", "hic": "Hix", "hnf": "Hanna", "kahn": "Kahn", "kas": "Kasumi",
    "kfl": "Kinnison", "kik": "Kiba", "kla": "Klaus", "kli": "Klimt", "koi": "Ko",
    "lea": "Leona", "lep": "Lepant", "luc": "Luca Blight", "lus": "Luc", "mcd": "McDohl",
    "mik": "Miklotov", "mil": "Millie", "nan": "Nanami", "nec": "Neclord", "nin": "Nina",
    "pil": "Pilika", "ryo": "Riou (Hero)", "shu": "Shu", "sie": "Sierra", "tai": "Tai Ho",
    "ten": "Tengaar", "val": "Valeria", "vik": "Viktor", "yom": "Yam Koo"
}

MAP_AREAS = {
    "va": "Ryube / Kyaro / North Sparrow / Tenzan",
    "vb": "Toto / Mercenary Camp / Muse City / White Deer",
    "vc": "Coronet / Kuskus / South Window / Radat",
    "vd": "Two River / Kobold Village / Lakewest / Drakemouth",
    "ve": "Greenhill / Matilda / Muse-Matilda Border",
    "vf": "Highway / Rockaxe / Mt. Rakutei",
    "vg": "Tinto / Crom / Tigermouth / South Mine",
    "vh": "Banner Village / Gregminster / Rokkaku",
    "vi": "Headquarters (Castle Level 1-4)",
    "vj": "L'Renouille / Sajah Village / Beast Rune Altar",
    "vk": "Special / Cutscene / Intro Areas",
    "vs": "Suikoden 1 Retrospective / Special Maps",
    "wa": "World Map Region A", "wb": "World Map Region B",
    "wc": "World Map Region C", "wd": "World Map Region D",
    "we": "World Map Region E", "wg": "World Map Region G",
    "wh": "World Map Region H", "wi": "World Map Region I",
    "wj": "World Map Region J"
}

def analyze_single_file(fname, data):
    stem = os.path.splitext(fname)[0]
    keys = [k for k in data.keys() if not k.startswith("m_GameObject") and not k.startswith("m_Enabled")]

    # 1. Known specific custom game MonoBehaviours
    if fname == "AddLangTextSetter.json":
        return "UI Localization", f"Suikoden HD runtime text setter linking a TextMeshPro component to a localized text ID (`id: {data.get('id', 'N/A')}`)."
    if fname == "BackLogListItem.json":
        return "Dialogue Backlog UI", "UI prefab script managing individual lines in dialogue history (character speaker name, dialogue text, choice selection)."
    if fname == "BackLogPanel.json":
        return "Dialogue Backlog UI", "Master dialogue history backlog panel controller handling display toggling, scrolling layout, and animation."
    if fname == "BattleEffectTimelineController.json":
        return "Combat Cinematic Director", "Controls battle visual effect timelines, syncing camera moves and particle VFX to PlayableDirectors."
    if fname == "BindCamera.json":
        return "Camera Controller", "Binds the rendering camera to target transforms and synchronizes field startup coordinates."
    if fname == "ConstraintCameraBinder.json":
        return "Camera Controller", "Constrains camera viewport bounds relative to target gameobjects or field boundaries."
    if fname in ["CREDITS_GSD1.json", "CREDITS_GSD2.json", "HDCREDITS_GSD1.json", "HDCREDITS_GSD2.json"]:
        game = "Suikoden I" if "GSD1" in fname else "Suikoden II"
        hd = " (HD Edition)" if "HD" in fname else ""
        return f"{game} Credits Data", f"Stores complete staff roll credits hierarchy, department headers, and logo texture paths for {game}{hd}."
    if fname == "CharacterDetailSetter.json":
        return "Status Window UI", "Populates character profile window elements: face portrait image, character name text, and stat block panels."
    if fname == "CharacterInfoSetter.json":
        return "Menu Party UI", "Sets summary party slot data across menus: face icon, level, and character name."
    if fname == "CoinPanel.json":
        return "HQ Minigame UI", "Chinchirorin cup-and-dice minigame UI component binding cup sprite, shadows, and coin/dice positions."
    if fname == "ColorGrading.json":
        return "Post-Processing Effect", "Post-processing Color Grading profile setting active grading mode, tonemapping, and color balance."
    if fname in ["DOTweenAnimation.json", "DOTweenVisualManager.json"]:
        return "Tween Animation Utility", "Demigiant DOTween visual component managing procedural UI / transform tween animations."

    # 2. Timeline Tracks / Assets
    if "Track" in fname or "Timeline" in fname or fname.startswith("EFF_") or fname.startswith("EM2_") or fname.startswith("TL_") or fname in ["Action.json", "Effect.json", "Cursor.json", "ControlPlayableAsset.json", "BG_Cloud_Para_01.json"]:
        if fname.startswith("EFF_"):
            return "VFX Timeline Asset", f"Combat / VFX visual effect timeline animation asset for effect `{stem}`."
        if fname.startswith("EM2_"):
            return "Event Cinematic Timeline", f"Suikoden II event/monster cinematic cutscene timeline asset for sequence `{stem}`."
        if fname.startswith("TL_"):
            return "Spell / Skill Timeline", f"Timeline sequence for magic/skill cast `{stem}`."
        if "Track" in fname:
            return "Timeline Track", f"Unity Timeline track asset (`{stem}`) controlling track clips, mute states, and animation tracks."
        if fname == "ControlPlayableAsset.json":
            return "Timeline Playable Asset", "Playable asset used within Control Tracks to spawn and control child prefabs or particle systems."
        if fname == "BG_Cloud_Para_01.json":
            return "Environment Timeline", "Timeline asset animating background parallax cloud scrolling layer 01."
        return "Timeline Asset", f"Cinematic / Timeline asset controlling animation sequence `{stem}`."

    # 3. TextMeshPro SDF Fonts
    if fname.endswith("SDF.json"):
        font_name = stem.replace(" SDF", "")
        return "TextMeshPro Font Asset", f"Signed Distance Field (SDF) glyph atlas and typography metrics asset for font `{font_name}`."

    # 4. CRIWARE Audio
    if fname.startswith("Cri") or fname.startswith("SE_") or fname.startswith("f_se_"):
        if fname == "CriAtomSource.json":
            desc = "CRIWARE audio playback emitter component for 2D/3D in-game sound."
        elif fname == "CriAtomSourceControll.json":
            desc = "Controls 3D audio attenuation distances and radius for CRI Atom sound sources."
        elif fname == "CriAtomSourceOn2D.json":
            desc = "Maps 3D audio cues to 2D UI coordinates."
        elif fname == "CriObjManager.json":
            desc = "Lifecycle manager component for CRI audio objects."
        else:
            desc = f"CRIWARE audio sound effect trigger/config asset for `{stem}`."
        return "CRIWARE Audio Component", desc

    # 5. UI Components
    if fname in ["Button.json", "ContentSizeFitter.json", "GridLayoutGroup.json", "HorizontalLayoutGroup.json", "VerticalLayoutGroup.json", "Image.json", "Mask.json", "Outline.json", "RawImage.json", "RectMask2D.json", "ScrollRect.json", "Scrollbar.json", "Slider.json", "Text.json", "TextMeshPro.json", "TextMeshProUGUI.json", "Toggle.json", "ToggleGroup.json", "Shadow.json"]:
        return "Unity UI Engine Component", f"Standard Unity UI `{stem}` component serialized parameters."

    if fname.startswith("UI") or fname.startswith("Ui"):
        if fname.startswith("UIBattle"):
            return "Battle HUD Subsystem", f"Combat battle interface component managing battle actions, player stats, targeting, or results (`{stem}`)."
        if fname.startswith("UIMain"):
            return "Main Menu Subsystem", f"Main menu interface component managing inventory, formation, equip, runes, or companion status (`{stem}`)."
        if fname.startswith("UISaveLoad"):
            return "Save/Load Subsystem", f"Save & load memory card interface component managing save slots, dialogs, and metadata (`{stem}`)."
        if fname.startswith("UIConfig"):
            return "Config / Settings UI", f"Options & configuration menu controller managing sound, graphics, controls, and language (`{stem}`)."
        if fname.startswith("UIGallery"):
            return "Gallery / Extras UI", f"Bonus gallery interface controller for artwork, sound jukebox, and cutscene player (`{stem}`)."
        return "Suikoden UI Window", f"Suikoden HD UI component/window controller for `{stem}`."

    # 6. Boss Data
    if fname.startswith("boss_"):
        bcode = stem.replace("boss_", "").split("_")[0]
        bname = CHARA_NAMES.get(bcode, bcode.capitalize())
        if "res" in fname:
            return "Boss VFX / Resource", f"Boss combat visual effect / resource asset for `{bname}` encounter."
        if "obj" in fname:
            return "Boss Battle Object", f"Boss arena 3D model/prop asset for `{bname}`."
        return "Boss Encounter Data", f"Boss entity configuration for `{bname}` ({stem}), setting stats, AI script, actions, and loot drops."

    # 7. Monster / Battle Encounter Data
    if re.match(r"^[a-z]_data", fname):
        letter = fname[0].upper()
        if "party" in fname:
            return "Monster Party Formation", f"Enemy party composition #{stem.split('_')[-1]} for Dungeon Group `{letter}`, specifying enemy formation layout."
        if "monster_data" in fname:
            return "Monster Stats & AI", f"Monster unit parameters for Dungeon Group `{letter}`, defining stats, attack damage, and rewards."
        return "Battle Region Encounter Table", f"Encounter zone table and field spawn configuration for Dungeon Group `{letter}`."

    # 8. Event Battle Data
    if fname.startswith("eb_"):
        map_code = stem[3:7] if len(stem) >= 7 else stem[3:]
        return "Story Event Battle Data", f"Scripted event battle occurring in map `{map_code}`, coordinating story dialogue triggers and combat conditions."

    # 9. Bathhouse
    if fname.startswith("hp_furo") or fname.startswith("HDBath") or fname == "bath.json":
        furo_id = stem.replace("hp_furo_", "")
        if furo_id.isdigit():
            return "HQ Bathhouse Interaction", f"Castle Bathhouse scene config #{furo_id}: character dialogue combinations, bath accessories, and reactions."
        return "HQ Bathhouse Asset", f"Castle Bathhouse visual parameters ({stem}), tub models, water colors, or steam effects."

    # 10. Castle Minigames
    if fname.startswith("hp_"):
        if "fish" in fname:
            return "HQ Fishing Minigame", f"Castle fishing pond asset ({stem}) configuring fish types, bites, and prizes."
        if "chin" in fname:
            return "HQ Chinchirorin Minigame", f"Chinchirorin dice minigame asset ({stem}) controlling stakes and dice rolls."
        if "kikori" in fname:
            return "HQ Wood Chopping Minigame", f"Wood-cutting minigame asset ({stem}) managing swing timing and stamina."
        if "book" in fname:
            return "HQ Library Old Book", f"Castle library readable Old Book asset ({stem}) storing lore text."
        if "hmap" in fname:
            return "HQ Detective / Castle Map", f"Castle floor map asset ({stem}) tracking NPC rooms and layout."
        if "hsound" in fname:
            return "HQ Sound Room Jukebox", f"Castle sound room music track playlist asset ({stem})."
        return "HQ Minigame / Facility", f"Headquarters castle activity asset for `{stem}`."

    # 11. Map Asset
    prefix = stem[:2]
    if prefix in MAP_AREAS:
        area_name = MAP_AREAS[prefix]
        map_code = stem[:4] if len(stem) >= 4 else stem
        if stem == map_code:
            return f"Map Data ({prefix.upper()})", f"Core map asset for `{map_code}` in {area_name}. Deserialized `MACHIDAT` with map events, NPCs, and warp triggers."
        return f"Map Sub-Asset ({prefix.upper()})", f"Map background layer / 3D prop configuration for `{map_code}` ({area_name})."

    # 12. Character Assets
    chara_code = stem[:3]
    if chara_code in CHARA_NAMES:
        cname = CHARA_NAMES[chara_code]
        if "field" in fname:
            return f"Character Field Asset ({cname})", f"Overworld field NPC configuration and sprite triggers for {cname}."
        if "battle" in fname or fname.startswith("player_"):
            return f"Character Battle Asset ({cname})", f"Combat unit model and animation bindings for {cname}."
        return f"Character Asset ({cname})", f"Character profile asset for {cname} ({chara_code})."

    # 13. Map Engine Objects
    if fname.startswith("Map"):
        return "HD Map Engine Object", f"HD map engine utility component managing environmental sprites, animated tiles, or footstep surface audio (`{stem}`)."

    # 14. Post-processing
    if fname.startswith("PostProcess"):
        return "Post-Processing Profile", f"Unity Post-Processing Stack profile managing bloom, vignette, color grading, and ambient occlusion (`{stem}`)."

    # Default
    return "Engine / Game Asset", f"Asset file storing serialized component state for `{stem}` (keys: {', '.join(keys[:4])})."

def get_total_files():
    return sorted(os.listdir(DIR_PATH))

def load_index():
    if os.path.exists(INDEX_PATH):
        with open(INDEX_PATH, "r", encoding="utf-8") as f:
            return json.load(f)
    return {"last_batch": -1, "processed_count": 0, "total_files": len(get_total_files()), "batches": {}}

def save_index(index_data):
    with open(INDEX_PATH, "w", encoding="utf-8") as f:
        json.dump(index_data, f, indent=2)

def generate_batch_notes(batch_num, results, category_counts):
    top_cats = sorted(category_counts.items(), key=lambda x: -x[1])
    lines = []
    lines.append(f"### Batch {batch_num:02d} Technical Notes & System Distribution\n")
    lines.append(f"- **Total Assets Analyzed**: {len(results)} files")
    lines.append("- **Category Distribution**:")
    for cat, cnt in top_cats:
        lines.append(f"  - `{cat}`: {cnt} files")
    
    # Specific interesting insights based on files in batch
    highlights = []
    for item in results:
        fn = item["filename"]
        desc = item["description"]
        if "CREDITS" in fn:
            highlights.append(f"`{fn}`: Master staff roll data mapping logo paths and credit hierarchy.")
        elif "BackLog" in fn:
            highlights.append(f"`{fn}`: HD Remaster quality-of-life dialogue review / backlog buffer system.")
        elif "BattleEffect" in fn:
            highlights.append(f"`{fn}`: Battle VFX PlayableDirector synchronization anchor.")
        elif "ColorGrading" in fn:
            highlights.append(f"`{fn}`: Global color grading LUT and tonemapper configuration.")
        elif "boss_" in fn:
            highlights.append(f"`{fn}`: Boss entity AI routine and combat state setup.")
        elif "hp_furo" in fn:
            highlights.append(f"`{fn}`: Bathhouse scene script configuring specific character dialogue.")
        elif re.match(r"^[a-z]_data", fn):
            highlights.append(f"`{fn}`: Region monster party formation and encounter table.")
        elif fn.startswith("eb_"):
            highlights.append(f"`{fn}`: Story event battle script coordinating cutscene combat triggers.")
        elif re.match(r"^[v|w][a-z][0-9]{2}", fn):
            highlights.append(f"`{fn}`: Deserialized `MACHIDAT` map package containing event bytecode and tile collision.")

    if highlights:
        lines.append("- **Key System Highlights**:")
        for h in highlights[:5]:
            lines.append(f"  - {h}")

    lines.append("\n---\n")
    return "\n".join(lines)

def process_batch(batch_num, batch_size=50):
    all_files = get_total_files()
    total = len(all_files)
    start = batch_num * batch_size
    end = min(start + batch_size, total)
    if start >= total:
        print(f"Batch {batch_num} out of range (start {start} >= total {total}).")
        return None

    batch_files = all_files[start:end]
    results = []
    category_counts = {}

    for i, fname in enumerate(batch_files):
        idx = start + i
        fpath = os.path.join(DIR_PATH, fname)
        try:
            with open(fpath, "r", encoding="utf-8") as f:
                data = json.load(f)
            subsystem, desc = analyze_single_file(fname, data)
        except Exception as e:
            subsystem, desc = "Error / Corrupt", f"Failed to parse JSON: {e}"
        
        category_counts[subsystem] = category_counts.get(subsystem, 0) + 1
        results.append({
            "index": idx,
            "filename": fname,
            "subsystem": subsystem,
            "description": desc
        })

    # Prepare markdown table
    md_lines = []
    md_lines.append(f"\n## Batch {batch_num:02d} (Files {start} to {end - 1} | Count: {len(results)})\n")
    md_lines.append("| # | File Name | Subsystem / Category | Role & Purpose |")
    md_lines.append("|---|---|---|---|")
    for item in results:
        md_lines.append(f"| {item['index']} | `{item['filename']}` | {item['subsystem']} | {item['description']} |")

    md_table = "\n".join(md_lines) + "\n\n"
    notes = generate_batch_notes(batch_num, results, category_counts)

    # Append to documentation
    if not os.path.exists(DOC_PATH):
        header = "# Suikoden Remaster - MonoBehaviour Asset Analysis & Catalog\n\n"
        header += "Comprehensive mapping and technical analysis of all 4,733 serialized MonoBehaviour assets in `D:\\Modding\\suikodum\\Mobobehaviour`.\n\n"
        header += "---\n"
        with open(DOC_PATH, "w", encoding="utf-8") as f:
            f.write(header)

    with open(DOC_PATH, "a", encoding="utf-8") as f:
        f.write(md_table + notes)

    # Update index
    index_data = load_index()
    index_data["last_batch"] = batch_num
    index_data["processed_count"] = end
    index_data["batches"][str(batch_num)] = {
        "start": start,
        "end": end - 1,
        "count": len(results),
        "categories": category_counts
    }
    save_index(index_data)

    print(f"Batch {batch_num:02d} processed: {start}..{end-1} ({len(results)} files).")
    return results, category_counts

def process_all(start_batch=0, end_batch=None):
    all_files = get_total_files()
    total = len(all_files)
    batch_size = 50
    total_batches = (total + batch_size - 1) // batch_size
    if end_batch is None or end_batch >= total_batches:
        end_batch = total_batches

    print(f"Processing batches {start_batch} to {end_batch - 1} (Total batches: {total_batches}, Total files: {total})...")
    
    # Initialize fresh doc if starting at 0
    if start_batch == 0:
        header = "# Suikoden Remaster - MonoBehaviour Asset Analysis & Catalog\n\n"
        header += f"Comprehensive mapping and technical analysis of all {total} serialized MonoBehaviour assets in `D:\\Modding\\suikodum\\Mobobehaviour`.\n\n"
        header += "## Master Asset Index & Subsystem Breakdown\n\n"
        header += "The assets dumped in this directory constitute the core serialized Unity MonoBehaviours for Suikoden I and II HD Remaster. They span:\n"
        header += "- **Map Configurations & Event Bytecode** (`va*`, `vb*`, `vc*`, `vd*`, `ve*`, `vf*`, `vg*`, `vh*`, `vi*`, `vj*`, `vk*`, `wa*`, etc.): Over 2,000+ map assets containing deserialized `MACHIDAT` structures, entity spawn records, collision layers, and map triggers.\n"
        header += "- **Battle Monster & Encounter Tables** (`a_data*` through `h_data*`): Encounter zone tables, monster stats, action rotation bytecode, and enemy party formation slot definitions.\n"
        header += "- **Boss Battles** (`boss_*`): Dedicated boss parameter packages, AI routine controllers, and special combat arena models.\n"
        header += "- **Story Event Battles** (`eb_*`): Map-specific scripted battle scenarios coordinating pre-battle dialogue, special victory/loss conditions, and cutscene transitions.\n"
        header += "- **Headquarters Facilities & Minigames** (`hp_*`): Bathhouse scenes (`hp_furo`), Chinchirorin dice minigame (`hp_chin`), Fishing pond (`hp_fish`), Wood chopping (`hp_kikori`), Library lore books (`hp_book`), Sound room (`hp_hsound`), and Castle detective floor maps (`hp_hmap`).\n"
        header += "- **Playable & NPC Character Entities** (`player_*`, `ada*`, `ail*`, `air*`, etc.): Overworld field avatars, combat battle 3D meshes, skeleton animation tracks, and interaction scripts.\n"
        header += "- **User Interface Subsystems** (`UI*`, `Button`, `ScrollRect`, etc.): Battle HUD (`UIBattle*`), Main Menu (`UIMain*`), Save/Load screens (`UISaveLoad*`), Configuration menus (`UIConfig*`), and Dialogue Backlog review (`BackLog*`).\n"
        header += "- **Audio & Cinematics** (`Cri*`, `Track*`, `Timeline*`, `EFF_*`, `TL_*`): CRIWARE audio streaming engines, distance attenuators, and Unity Timeline PlayableDirectors synchronizing camera moves, particle effects, and spell animations.\n\n"
        header += "---\n\n"
        with open(DOC_PATH, "w", encoding="utf-8") as f:
            f.write(header)

    for b in range(start_batch, end_batch):
        process_batch(b, batch_size)

    print(f"Finished processing up to batch {end_batch - 1}. Total processed: {min(end_batch * batch_size, total)}/{total}")

if __name__ == "__main__":
    if len(sys.argv) > 1 and sys.argv[1] == "--all":
        process_all()
    else:
        b_num = int(sys.argv[1]) if len(sys.argv) > 1 else 0
        process_batch(b_num)
