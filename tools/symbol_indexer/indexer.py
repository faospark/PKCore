#!/usr/bin/env python3
"""
High-Speed Decompiled Symbol Indexer for PKCore / Suikoden Remaster
Indexes C# decompiled sources (GSD1, GSD2, GSDShare) and native symbols (symbols.txt)
into a high-performance SQLite database.
"""

import os
import sys
import re
import time
import sqlite3
from typing import List, Tuple, Dict, Any, Optional

WORKSPACE_ROOTS = [
    ("GSD1", r"d:\Appz\Suisource\GSD1"),
    ("GSD2", r"d:\Appz\Suisource\GSD2\GSD2"),
    ("GSDShare", r"d:\Appz\Suisource\GSDShare"),
]

NATIVE_SYMBOLS_PATH = r"d:\Appz\Suisource\GSD2\GSD2\symbols.txt"
DEFAULT_DB_PATH = os.path.join(os.path.dirname(os.path.abspath(__file__)), "symbols.db")

# Regex patterns for C# parsing
RE_NAMESPACE = re.compile(r'^\s*namespace\s+([A-Za-z0-9_.]+)')
RE_TOKEN = re.compile(r'^\s*//\s*Token:\s*(0x[0-9A-Fa-f]+)')
RE_TYPE = re.compile(r'^\s*(?:\[[^\]]*\]\s*)*(?:public|private|protected|internal)?\s*(?:(?:static|abstract|sealed|partial)\s+)*(class|struct|interface|enum)\s+([A-Za-z0-9_`]+)')
RE_METHOD = re.compile(r'^\s*(?:\[[^\]]*\]\s*)*(public|private|protected|internal)\s+(?:(?:static|virtual|override|abstract|sealed|unsafe|async|extern)\s+)*([A-Za-z0-9_<>\[\]?:,\.\s]+?)\s+([A-Za-z0-9_]+)\s*\((.*?)\)')
RE_PROP = re.compile(r'^\s*(?:\[[^\]]*\]\s*)*(public|private|protected|internal)\s+(?:(?:static|virtual|override|abstract|sealed|unsafe|readonly|const)\s+)*([A-Za-z0-9_<>\[\]?:,\.\s]+?)\s+([A-Za-z0-9_]+)\s*$')
RE_PROP_ONELINE = re.compile(r'^\s*(?:\[[^\]]*\]\s*)*(public|private|protected|internal)\s+(?:(?:static|virtual|override|abstract|sealed|unsafe|readonly|const)\s+)*([A-Za-z0-9_<>\[\]?:,\.\s]+?)\s+([A-Za-z0-9_]+)\s*\{\s*(?:get|set)')
RE_FIELD = re.compile(r'^\s*(?:\[[^\]]*\]\s*)*(public|private|protected|internal)\s+(?:(?:static|virtual|override|abstract|sealed|unsafe|readonly|const|volatile)\s+)*([A-Za-z0-9_<>\[\]?:,\.\s]+?)\s+([A-Za-z0-9_]+)\s*;')

KEYWORDS_IGNORE = {'if', 'while', 'for', 'foreach', 'switch', 'catch', 'lock', 'using', 'return', 'throw', 'new', 'sizeof', 'typeof', 'default'}

def init_db(db_path: str) -> sqlite3.Connection:
    if os.path.exists(db_path):
        try:
            os.remove(db_path)
        except Exception as e:
            print(f"Warning: could not remove existing db ({e}), overwriting...")
    
    conn = sqlite3.connect(db_path)
    cur = conn.cursor()
    cur.execute("PRAGMA synchronous = OFF;")
    cur.execute("PRAGMA journal_mode = MEMORY;")
    cur.execute("PRAGMA cache_size = -128000;")  # 128MB cache

    cur.execute("""
    CREATE TABLE types (
        id INTEGER PRIMARY KEY,
        game TEXT NOT NULL,
        namespace TEXT,
        name TEXT NOT NULL,
        full_name TEXT NOT NULL,
        kind TEXT NOT NULL,
        file_path TEXT NOT NULL,
        line_number INTEGER NOT NULL,
        token TEXT
    );
    """)

    cur.execute("""
    CREATE TABLE members (
        id INTEGER PRIMARY KEY,
        type_id INTEGER,
        game TEXT NOT NULL,
        type_name TEXT NOT NULL,
        name TEXT NOT NULL,
        kind TEXT NOT NULL,
        visibility TEXT,
        signature TEXT,
        file_path TEXT NOT NULL,
        line_number INTEGER NOT NULL,
        FOREIGN KEY(type_id) REFERENCES types(id)
    );
    """)

    cur.execute("""
    CREATE TABLE native_symbols (
        id INTEGER PRIMARY KEY,
        address TEXT NOT NULL,
        address_int INTEGER NOT NULL,
        type_name TEXT,
        member_name TEXT,
        full_symbol TEXT NOT NULL
    );
    """)

    cur.execute("""
    CREATE TABLE maps (
        id INTEGER PRIMARY KEY,
        game TEXT NOT NULL,
        map_id TEXT NOT NULL,
        name TEXT NOT NULL,
        region TEXT NOT NULL,
        handler_class TEXT NOT NULL,
        handler_location TEXT NOT NULL,
        doc_path TEXT NOT NULL,
        description TEXT NOT NULL
    );
    """)

    cur.execute("""
    CREATE TABLE game_entities (
        id INTEGER PRIMARY KEY,
        game TEXT NOT NULL,
        category TEXT NOT NULL,
        entity_id INTEGER NOT NULL,
        name TEXT NOT NULL,
        attrs TEXT,
        internal_symbol TEXT,
        description TEXT
    );
    """)

    conn.commit()
    return conn

def create_indexes(conn: sqlite3.Connection):
    cur = conn.cursor()
    print("Creating B-Tree indexes...")
    cur.execute("CREATE INDEX idx_types_name ON types(name COLLATE NOCASE);")
    cur.execute("CREATE INDEX idx_types_fullname ON types(full_name COLLATE NOCASE);")
    cur.execute("CREATE INDEX idx_types_game ON types(game);")

    cur.execute("CREATE INDEX idx_members_name ON members(name COLLATE NOCASE);")
    cur.execute("CREATE INDEX idx_members_type ON members(type_name COLLATE NOCASE);")
    cur.execute("CREATE INDEX idx_members_type_member ON members(type_name COLLATE NOCASE, name COLLATE NOCASE);")
    cur.execute("CREATE INDEX idx_members_game ON members(game);")

    cur.execute("CREATE INDEX idx_native_addr ON native_symbols(address COLLATE NOCASE);")
    cur.execute("CREATE INDEX idx_native_addr_int ON native_symbols(address_int);")
    cur.execute("CREATE INDEX idx_native_name ON native_symbols(member_name COLLATE NOCASE);")
    cur.execute("CREATE INDEX idx_native_type ON native_symbols(type_name COLLATE NOCASE);")
    cur.execute("CREATE INDEX idx_native_sym ON native_symbols(full_symbol COLLATE NOCASE);")

    cur.execute("CREATE INDEX idx_maps_map_id ON maps(map_id COLLATE NOCASE);")
    cur.execute("CREATE INDEX idx_maps_name ON maps(name COLLATE NOCASE);")
    cur.execute("CREATE INDEX idx_maps_game ON maps(game);")
    cur.execute("CREATE INDEX idx_maps_region ON maps(region COLLATE NOCASE);")

    cur.execute("CREATE INDEX idx_entities_name ON game_entities(name COLLATE NOCASE);")
    cur.execute("CREATE INDEX idx_entities_cat_id ON game_entities(category, entity_id);")
    cur.execute("CREATE INDEX idx_entities_symbol ON game_entities(internal_symbol COLLATE NOCASE);")
    cur.execute("CREATE INDEX idx_entities_id ON game_entities(entity_id);")
    cur.execute("CREATE INDEX idx_entities_game ON game_entities(game);")

    print("Creating Full-Text Search (FTS5) index...")
    cur.execute("""
    CREATE VIRTUAL TABLE fts_symbols USING fts5(
        name,
        parent,
        kind,
        detail,
        game,
        target_id UNINDEXED,
        target_table UNINDEXED,
        tokenize = 'unicode61 remove_diacritics 0'
    );
    """)

    print("Populating FTS index...")
    # Types
    cur.execute("""
    INSERT INTO fts_symbols(name, parent, kind, detail, game, target_id, target_table)
    SELECT name, namespace, kind, full_name, game, id, 'types' FROM types;
    """)
    # Members
    cur.execute("""
    INSERT INTO fts_symbols(name, parent, kind, detail, game, target_id, target_table)
    SELECT name, type_name, kind, coalesce(signature, name), game, id, 'members' FROM members;
    """)
    # Native symbols
    cur.execute("""
    INSERT INTO fts_symbols(name, parent, kind, detail, game, target_id, target_table)
    SELECT coalesce(member_name, full_symbol), coalesce(type_name, ''), 'native', address, 'GSD2', id, 'native_symbols'
    FROM native_symbols;
    """)
    # Maps
    cur.execute("""
    INSERT INTO fts_symbols(name, parent, kind, detail, game, target_id, target_table)
    SELECT map_id, name, 'map', description, game, id, 'maps' FROM maps;
    """)
    # Game Entities
    cur.execute("""
    INSERT INTO fts_symbols(name, parent, kind, detail, game, target_id, target_table)
    SELECT name, category || ' #' || entity_id, 'entity', coalesce(attrs, '') || ' ' || coalesce(internal_symbol, '') || ' ' || coalesce(description, ''), game, id, 'game_entities'
    FROM game_entities;
    """)

    conn.commit()

def index_native_symbols(conn: sqlite3.Connection, path: str) -> int:
    if not os.path.isfile(path):
        print(f"Native symbols file not found: {path}")
        return 0
    
    t0 = time.time()
    cur = conn.cursor()
    batch = []
    count = 0
    
    with open(path, 'r', encoding='utf-8', errors='ignore') as f:
        for line in f:
            line = line.strip()
            if not line:
                continue
            parts = line.split(' ', 1)
            if len(parts) != 2:
                continue
            addr_str, sym = parts[0], parts[1]
            try:
                addr_int = int(addr_str, 16)
            except ValueError:
                continue
            
            type_name = None
            member_name = None
            if '$$' in sym:
                sym_parts = sym.split('$$', 1)
                type_name = sym_parts[0]
                member_name = sym_parts[1]
            elif '.' in sym:
                sym_parts = sym.rsplit('.', 1)
                type_name = sym_parts[0]
                member_name = sym_parts[1]
            else:
                member_name = sym
            
            batch.append((addr_str, addr_int, type_name, member_name, sym))
            count += 1
            if len(batch) >= 10000:
                cur.executemany(
                    "INSERT INTO native_symbols (address, address_int, type_name, member_name, full_symbol) VALUES (?, ?, ?, ?, ?)",
                    batch
                )
                batch = []
                
        if batch:
            cur.executemany(
                "INSERT INTO native_symbols (address, address_int, type_name, member_name, full_symbol) VALUES (?, ?, ?, ?, ?)",
                batch
            )
            
    conn.commit()
    t1 = time.time()
    print(f"Indexed {count:,} native symbols in {t1 - t0:.2f}s")
    return count

def index_csharp_files(conn: sqlite3.Connection) -> Tuple[int, int, int]:
    t0 = time.time()
    cur = conn.cursor()

    type_batch = []
    member_batch = []
    
    total_files = 0
    total_types = 0
    total_members = 0

    current_type_id = 0

    for game, root_dir in WORKSPACE_ROOTS:
        if not os.path.isdir(root_dir):
            print(f"Directory not found: {root_dir}")
            continue
            
        print(f"Scanning C# sources in {game} ({root_dir})...")
        cs_files = []
        for r, dirs, files in os.walk(root_dir):
            for f in files:
                if f.endswith('.cs'):
                    cs_files.append(os.path.join(r, f))
                    
        print(f"Found {len(cs_files)} files in {game}. Parsing...")
        
        for file_path in cs_files:
            total_files += 1
            namespace = ""
            current_type_name = os.path.splitext(os.path.basename(file_path))[0]
            current_type_fk = None
            last_token = None
            
            with open(file_path, 'r', encoding='utf-8', errors='ignore') as fp:
                lines = fp.readlines()
                
            num_lines = len(lines)
            i = 0
            while i < num_lines:
                line = lines[i]
                i += 1
                sline = line.strip()
                if not sline or sline.startswith('using ') or sline.startswith('#'):
                    continue
                    
                if sline.startswith('//'):
                    tm = RE_TOKEN.match(line)
                    if tm:
                        last_token = tm.group(1)
                    continue

                # Check namespace
                ns_m = RE_NAMESPACE.match(line)
                if ns_m:
                    namespace = ns_m.group(1)
                    continue

                # Check type
                if 'class ' in line or 'struct ' in line or 'interface ' in line or 'enum ' in line:
                    type_m = RE_TYPE.match(line)
                    if type_m:
                        kind = type_m.group(1)
                        name = type_m.group(2)
                        current_type_id += 1
                        current_type_fk = current_type_id
                        current_type_name = name
                        full_name = f"{namespace}.{name}" if namespace else name
                        
                        type_batch.append((
                            current_type_id, game, namespace, name, full_name,
                            kind, file_path, i, last_token
                        ))
                        last_token = None
                        total_types += 1
                        continue

                # Check method
                if '(' in line and ')' in line:
                    meth_m = RE_METHOD.match(line)
                    if meth_m:
                        m_vis = meth_m.group(1)
                        m_ret = meth_m.group(2).strip()
                        m_name = meth_m.group(3)
                        m_params = meth_m.group(4).strip()
                        if m_name not in KEYWORDS_IGNORE:
                            sig = f"{m_vis} {m_ret} {m_name}({m_params})"
                            member_batch.append((
                                current_type_fk, game, current_type_name, m_name,
                                'method', m_vis, sig, file_path, i
                            ))
                            total_members += 1
                            continue

                # Check property (multiline or oneline)
                prop_oneline = RE_PROP_ONELINE.match(line)
                if prop_oneline:
                    p_vis = prop_oneline.group(1)
                    p_type = prop_oneline.group(2).strip()
                    p_name = prop_oneline.group(3)
                    sig = f"{p_vis} {p_type} {p_name} {{ get; set; }}"
                    member_batch.append((
                        current_type_fk, game, current_type_name, p_name,
                        'property', p_vis, sig, file_path, i
                    ))
                    total_members += 1
                    continue

                # Check if next line is '{' for multiline property
                if i < num_lines and lines[i].strip().startswith('{'):
                    prop_m = RE_PROP.match(line)
                    if prop_m:
                        p_vis = prop_m.group(1)
                        p_type = prop_m.group(2).strip()
                        p_name = prop_m.group(3)
                        if p_name not in KEYWORDS_IGNORE:
                            sig = f"{p_vis} {p_type} {p_name}"
                            member_batch.append((
                                current_type_fk, game, current_type_name, p_name,
                                'property', p_vis, sig, file_path, i
                            ))
                            total_members += 1
                            continue

                # Check field
                if ';' in line:
                    field_m = RE_FIELD.match(line)
                    if field_m:
                        f_vis = field_m.group(1)
                        f_type = field_m.group(2).strip()
                        f_name = field_m.group(3)
                        if f_name not in KEYWORDS_IGNORE:
                            sig = f"{f_vis} {f_type} {f_name}"
                            member_batch.append((
                                current_type_fk, game, current_type_name, f_name,
                                'field', f_vis, sig, file_path, i
                            ))
                            total_members += 1
                            continue

            # Batch flush
            if len(type_batch) >= 5000:
                cur.executemany(
                    "INSERT INTO types VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)",
                    type_batch
                )
                type_batch = []
            if len(member_batch) >= 10000:
                cur.executemany(
                    "INSERT INTO members (type_id, game, type_name, name, kind, visibility, signature, file_path, line_number) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)",
                    member_batch
                )
                member_batch = []

    if type_batch:
        cur.executemany(
            "INSERT INTO types VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)",
            type_batch
        )
    if member_batch:
        cur.executemany(
            "INSERT INTO members (type_id, game, type_name, name, kind, visibility, signature, file_path, line_number) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)",
            member_batch
        )

    conn.commit()
    t1 = time.time()
    print(f"Parsed {total_files} C# files in {t1 - t0:.2f}s:")
    print(f"  Types indexed:   {total_types:,}")
    print(f"  Members indexed: {total_members:,}")
    return total_files, total_types, total_members

def index_maps(conn: sqlite3.Connection):
    t0 = time.time()
    cur = conn.cursor()
    from map_data import S2_AREAS, S1_REGIONS, S1_MAP_DETAILS
    
    rows = []
    
    # 1. Index S2 Geographic Areas and their individual map asset IDs
    for slug, name, region, maps, desc in S2_AREAS:
        doc_rel = f"Documentation/areas/{slug}.md"
        maps_str = ", ".join(maps)
        # Entry for the area itself
        rows.append((
            "GSD2",
            maps_str,
            name,
            region,
            "MACHICON / EVENTCON",
            "d:/Appz/Suisource/GSD2/GSD2/MACHICON.cs",
            doc_rel,
            desc
        ))
        # Entry for each submap ID (e.g. vc18, va01)
        for m in maps:
            rows.append((
                "GSD2",
                m,
                f"{name} ({m})",
                region,
                "MACHICON.EventInit",
                "d:/Appz/Suisource/GSD2/GSD2/MACHICON.cs",
                doc_rel,
                f"Submap {m} of {name}. JSON: {m}.json, Submaps: mapeventdat, Entities: eventobj, Script bytecodes: eventdat. {desc}"
            ))
            
    # 2. Index S1 Regional Sectors and Background Map Assets
    for reg_id, reg_name, field_name, map_list, reg_desc in S1_REGIONS:
        s1_doc = "Documentation/suikoden_1_map_ids_and_areas_breakdown.md"
        maps_str = ", ".join(map_list)
        # Entry for regional sector
        rows.append((
            "GSD1",
            reg_id,
            reg_name,
            reg_id,
            f"G1_fdata_c.{field_name} / VillageManager",
            "d:/Appz/Suisource/GSD1/GSD1/VillageManager.cs",
            s1_doc,
            f"{reg_desc} Registered in G1_fdata_c.{field_name}. Background maps: {maps_str}."
        ))
        # Entry for each individual background map
        for bg in map_list:
            detail_title, detail_desc = S1_MAP_DETAILS.get(bg, (f"{reg_name} ({bg})", reg_desc))
            rows.append((
                "GSD1",
                bg,
                f"{detail_title} ({bg})",
                reg_id,
                "VillageManager.GetVillageInfo",
                "d:/Appz/Suisource/GSD1/GSD1/VillageManager.cs",
                s1_doc,
                f"{detail_desc} Handled by VillageManager / Village_c. Event script bytecode executed via Event_c.eventCommandFunction."
            ))
            
    cur.executemany("""
    INSERT INTO maps (game, map_id, name, region, handler_class, handler_location, doc_path, description)
    VALUES (?, ?, ?, ?, ?, ?, ?, ?)
    """, rows)
    conn.commit()
    print(f"Indexed {len(rows)} map and area entries (GSD1 + GSD2) in {time.time() - t0:.2f}s")
    return len(rows)

def index_game_entities(conn: sqlite3.Connection) -> int:
    import json
    t0 = time.time()
    cur = conn.cursor()

    json_path = os.path.join(os.path.dirname(os.path.abspath(__file__)), "gamedata.json")
    js_path = r"e:\xampp\htdocs\suisaveeditor\src\gamedata.js"

    # If gamedata.json doesn't exist or gamedata.js is newer, regenerate json via node
    if os.path.isfile(js_path):
        if not os.path.isfile(json_path) or os.path.getmtime(js_path) > os.path.getmtime(json_path):
            try:
                import subprocess
                node_script = f"""
                const fs = require('fs');
                const content = fs.readFileSync({json.dumps(js_path)}, 'utf8');
                const jsCode = content.replace('export default GameData;', 'module.exports = GameData;');
                const tmpPath = {json.dumps(json_path + '.tmp.cjs')};
                fs.writeFileSync(tmpPath, jsCode);
                const gd = require(tmpPath);
                fs.writeFileSync({json.dumps(json_path)}, JSON.stringify(gd, null, 2));
                fs.unlinkSync(tmpPath);
                """
                subprocess.run(["node", "-e", node_script], check=True, capture_output=True)
            except Exception as e:
                print(f"Warning: could not auto-refresh gamedata.json from gamedata.js: {e}")

    if not os.path.isfile(json_path):
        print(f"Game data file not found: {json_path}")
        return 0

    with open(json_path, 'r', encoding='utf-8') as f:
        gd = json.load(f)

    # Read engine symbols for cross-referencing
    char_fields = []
    g2_name_path = r"d:\Appz\Suisource\GSD2\GSD2\g2_name_h.cs"
    if os.path.isfile(g2_name_path):
        with open(g2_name_path, 'r', encoding='utf-8', errors='ignore') as f:
            char_fields = re.findall(r'NativeFieldInfoPtr_([A-Za-z0-9_]+)\s*=', f.read())

    di_fields, it_fields, tr_fields = [], [], []
    g2_data_path = r"d:\Appz\Suisource\GSD2\GSD2\g2_data_h.cs"
    if os.path.isfile(g2_data_path):
        with open(g2_data_path, 'r', encoding='utf-8', errors='ignore') as f:
            data_text = f.read()
            di_fields = re.findall(r'NativeFieldInfoPtr_(DI_[A-Za-z0-9_]+)\s*=', data_text)
            it_fields = re.findall(r'NativeFieldInfoPtr_(IT_[A-Za-z0-9_]+)\s*=', data_text)
            tr_fields = re.findall(r'NativeFieldInfoPtr_(TR_[A-Za-z0-9_]+)\s*=', data_text)

    rows = []

    # 1. Characters
    chars = gd.get("CHARACTERS", {})
    beasts_set = set(gd.get("BEASTS", []))
    for cid_str, cdata in chars.items():
        cid = int(cid_str)
        name = cdata.get("name", f"Character {cid}") if isinstance(cdata, dict) else str(cdata)
        attrs = cdata.get("attrs", []) if isinstance(cdata, dict) else []
        attrs_str = ", ".join(str(a) for a in attrs)
        sym = f"g2_name_h.{char_fields[cid-1]}" if 0 < cid <= len(char_fields) else ""
        is_beast = " (Beast/Monster)" if cid in beasts_set or "Z" in attrs else ""
        desc = f"Character #{cid}: {name}{is_beast}. Attributes: [{attrs_str}]."
        if sym:
            desc += f" Engine Symbol: {sym}."
        rows.append(("GSD2", "character", cid, name, attrs_str, sym, desc))

    # 2. Food
    foods = gd.get("FOOD", {})
    for fid_str, fdata in foods.items():
        fid = int(fid_str)
        name = fdata.get("name", f"Food {fid}") if isinstance(fdata, dict) else str(fdata)
        attrs = fdata.get("attrs", []) if isinstance(fdata, dict) else []
        attrs_str = f"use_cnt: {attrs[0]}" if attrs else "use_cnt: 101"
        sym = f"g2_data_h.{di_fields[fid-1]}" if 0 < fid <= len(di_fields) else ""
        desc = f"Food Recipe Dish #{fid}: {name}. {attrs_str}."
        if sym:
            desc += f" Engine Symbol: {sym}."
        rows.append(("GSD2", "food", fid, name, attrs_str, sym, desc))

    # 3. Items (consumables/key)
    items = gd.get("ITEMS", {})
    for iid_str, idata in items.items():
        iid = int(iid_str)
        name = idata.get("name", f"Item {iid}") if isinstance(idata, dict) else str(idata)
        attrs = idata.get("attrs", []) if isinstance(idata, dict) else []
        attrs_str = f"use_cnt: {attrs[0]}" if attrs else "use_cnt: 0"
        desc = f"Item #{iid}: {name}. {attrs_str}."
        rows.append(("GSD2", "item", iid, name, attrs_str, "", desc))

    # 4. Runes
    runes = gd.get("RUNES", {})
    for rid_str, rdata in runes.items():
        rid = int(rid_str)
        name = rdata.get("name", f"Rune {rid}") if isinstance(rdata, dict) else str(rdata)
        attrs = rdata.get("attrs", []) if isinstance(rdata, dict) else []
        attrs_str = ", ".join(str(a) for a in attrs)
        desc = f"Rune Orb #{rid}: {name}. Slots/Attrs: [{attrs_str}]."
        rows.append(("GSD2", "rune", rid, name, attrs_str, "", desc))

    # 5. Helmets
    helmets = gd.get("HELMET", {})
    for hid_str, hdata in helmets.items():
        hid = int(hid_str)
        name = hdata.get("name", f"Helmet {hid}") if isinstance(hdata, dict) else str(hdata)
        attrs = hdata.get("attrs", []) if isinstance(hdata, dict) else []
        attrs_str = f"use_cnt: 16, type: {', '.join(str(a) for a in attrs)}" if attrs else "use_cnt: 16"
        desc = f"Helmet #{hid}: {name}. [{attrs_str}]."
        rows.append(("GSD2", "helmet", hid, name, attrs_str, "", desc))

    # 6. Armor
    armors = gd.get("ARMOR", {})
    for aid_str, adata in armors.items():
        aid = int(aid_str)
        name = adata.get("name", f"Armor {aid}") if isinstance(adata, dict) else str(adata)
        attrs = adata.get("attrs", []) if isinstance(adata, dict) else []
        attrs_str = f"use_cnt: 16, type: {', '.join(str(a) for a in attrs)}" if attrs else "use_cnt: 16"
        desc = f"Armor #{aid}: {name}. [{attrs_str}]."
        rows.append(("GSD2", "armor", aid, name, attrs_str, "", desc))

    # 7. Shields
    shields = gd.get("SHIELD", {})
    for sid_str, sname in shields.items():
        sid = int(sid_str)
        name = str(sname)
        attrs_str = "use_cnt: 16, type: S"
        desc = f"Shield #{sid}: {name}. [{attrs_str}]."
        rows.append(("GSD2", "shield", sid, name, attrs_str, "", desc))

    # 8. Accessories / Gear
    accessories = gd.get("OTHER_EQUIP_GEAR", {})
    for oid_str, oname in accessories.items():
        oid = int(oid_str)
        name = str(oname)
        attrs_str = "use_cnt: 16"
        desc = f"Accessory/Gear #{oid}: {name}. [{attrs_str}]."
        rows.append(("GSD2", "accessory", oid, name, attrs_str, "", desc))

    # 9. Farming
    farming = gd.get("FARMING", {})
    for fid_str, fname in farming.items():
        fid = int(fid_str)
        name = str(fname)
        attrs_str = "use_cnt: 48"
        desc = f"Farm Seed/Animal #{fid}: {name}. [{attrs_str}]."
        rows.append(("GSD2", "farming", fid, name, attrs_str, "", desc))

    # 10. Trade
    trade = gd.get("TRADE", {})
    for tid_str, tname in trade.items():
        tid = int(tid_str)
        name = str(tname)
        attrs_str = "use_cnt: 64"
        sym = f"g2_data_h.{tr_fields[tid-1]}" if 0 < tid <= len(tr_fields) else ""
        desc = f"Trade Good #{tid}: {name}. [{attrs_str}]."
        if sym:
            desc += f" Engine Symbol: {sym}."
        rows.append(("GSD2", "trade", tid, name, attrs_str, sym, desc))

    # 11. Base items
    base_items = gd.get("BASE_ITEM", {})
    for bid_str, bname in base_items.items():
        bid = int(bid_str)
        name = str(bname)
        attrs_str = "use_cnt: 80"
        sym = f"g2_data_h.{it_fields[bid-1]}" if 0 < bid <= len(it_fields) else ""
        desc = f"Castle Item #{bid}: {name}. [{attrs_str}]."
        if sym:
            desc += f" Engine Symbol: {sym}."
        rows.append(("GSD2", "base_item", bid, name, attrs_str, sym, desc))

    cur.executemany("""
    INSERT INTO game_entities (game, category, entity_id, name, attrs, internal_symbol, description)
    VALUES (?, ?, ?, ?, ?, ?, ?)
    """, rows)
    conn.commit()
    t1 = time.time()
    print(f"Indexed {len(rows)} game entities (characters, food, runes, gear, items) in {t1 - t0:.2f}s")
    return len(rows)

def main():
    import argparse
    parser = argparse.ArgumentParser(description="Build high-speed decompiled symbols database.")
    parser.add_argument("--db", default=DEFAULT_DB_PATH, help="Output SQLite database path")
    args = parser.parse_args()

    os.makedirs(os.path.dirname(os.path.abspath(args.db)), exist_ok=True)
    
    total_start = time.time()
    print(f"Initializing database at: {args.db}")
    conn = init_db(args.db)

    print("\n--- Indexing Native Symbols (symbols.txt) ---")
    index_native_symbols(conn, NATIVE_SYMBOLS_PATH)

    print("\n--- Indexing Decompiled C# Sources ---")
    index_csharp_files(conn)

    print("\n--- Indexing Maps & Areas (GSD1 & GSD2) ---")
    index_maps(conn)

    print("\n--- Indexing Game Entities (Characters, Items, Food, Gear) ---")
    index_game_entities(conn)

    print("\n--- Creating Indexes and Full-Text Search Tables ---")
    t0 = time.time()
    create_indexes(conn)
    print(f"Indexes created in {time.time() - t0:.2f}s")

    conn.close()
    db_size_mb = os.path.getsize(args.db) / (1024 * 1024)
    print(f"\n[SUCCESS] Symbol indexing complete in {time.time() - total_start:.2f}s!")
    print(f"Database size: {db_size_mb:.2f} MB")

if __name__ == "__main__":
    main()

