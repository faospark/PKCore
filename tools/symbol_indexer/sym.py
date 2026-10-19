#!/usr/bin/env python3
"""
High-Speed Decompiled Symbol Query CLI for PKCore / Suikoden Remaster
Provides instant (<5ms) lookups for C# types, members, and native IL2CPP symbols.
"""

import os
import sys
import argparse
import sqlite3
import json
import time
from typing import List, Dict, Any, Optional

DEFAULT_DB_PATH = os.path.join(os.path.dirname(os.path.abspath(__file__)), "symbols.db")

def get_connection(db_path: str) -> sqlite3.Connection:
    if not os.path.isfile(db_path):
        print(f"Error: Symbol database not found at {db_path}", file=sys.stderr)
        print("Please run `python indexer.py` first to generate the index.", file=sys.stderr)
        sys.exit(1)
        
    conn = sqlite3.connect(db_path)
    conn.row_factory = sqlite3.Row
    cur = conn.cursor()
    cur.execute("PRAGMA mmap_size = 268435456;")  # 256MB memory map
    cur.execute("PRAGMA query_only = ON;")
    return conn

def format_location(file_path: str, line_number: int, as_link: bool = True) -> str:
    norm_path = file_path.replace('\\', '/')
    if as_link:
        return f"file:///{norm_path}#L{line_number}"
    return f"{file_path}:{line_number}"

def query_by_address(conn: sqlite3.Connection, addr_str: str, limit: int = 20) -> List[Dict[str, Any]]:
    clean_addr = addr_str.strip().lower()
    if clean_addr.startswith('0x'):
        hex_val = clean_addr
    else:
        hex_val = '0x' + clean_addr
        
    try:
        addr_int = int(hex_val, 16)
    except ValueError:
        return []

    cur = conn.cursor()
    results = []
    
    # Query native symbols
    cur.execute("""
    SELECT address, type_name, member_name, full_symbol 
    FROM native_symbols 
    WHERE address_int = ? OR address = ? COLLATE NOCASE
    LIMIT ?;
    """, (addr_int, hex_val, limit))
    
    rows = cur.fetchall()
    for row in rows:
        item = {
            "source": "native",
            "address": row["address"],
            "type_name": row["type_name"],
            "member_name": row["member_name"],
            "symbol": row["full_symbol"],
            "cs_match": None
        }
        
        # Try to locate corresponding C# member
        if row["type_name"] and row["member_name"]:
            # Clean up member_name if it has ctor or special syntax
            mname = row["member_name"]
            if mname == '.ctor' or mname == '.cctor':
                mname = row["type_name"]
            
            cur2 = conn.cursor()
            cur2.execute("""
            SELECT game, type_name, name, kind, signature, file_path, line_number
            FROM members
            WHERE type_name = ? COLLATE NOCASE AND name = ? COLLATE NOCASE
            LIMIT 1;
            """, (row["type_name"], mname))
            cs_row = cur2.fetchone()
            if cs_row:
                item["cs_match"] = {
                    "game": cs_row["game"],
                    "signature": cs_row["signature"],
                    "location": format_location(cs_row["file_path"], cs_row["line_number"])
                }
        results.append(item)
        
    return results

def query_type_members(conn: sqlite3.Connection, type_name: str, kind_filter: Optional[str] = None, game_filter: Optional[str] = None, limit: int = 100) -> List[Dict[str, Any]]:
    cur = conn.cursor()
    params = [type_name]
    sql = """
    SELECT m.game, m.type_name, m.name, m.kind, m.visibility, m.signature, m.file_path, m.line_number, n.address
    FROM members m
    LEFT JOIN native_symbols n ON n.type_name = m.type_name COLLATE NOCASE AND n.member_name = m.name COLLATE NOCASE
    WHERE m.type_name = ? COLLATE NOCASE
    """
    if kind_filter:
        sql += " AND m.kind = ?"
        params.append(kind_filter)
    if game_filter:
        sql += " AND m.game = ?"
        params.append(game_filter)
        
    sql += " ORDER BY m.kind, m.line_number LIMIT ?"
    params.append(limit)
    
    cur.execute(sql, params)
    rows = cur.fetchall()
    
    results = []
    for r in rows:
        results.append({
            "game": r["game"],
            "type_name": r["type_name"],
            "name": r["name"],
            "kind": r["kind"],
            "signature": r["signature"],
            "address": r["address"],
            "location": format_location(r["file_path"], r["line_number"])
        })
    return results

def query_symbols(conn: sqlite3.Connection, query: str, game_filter: Optional[str] = None, kind_filter: Optional[str] = None, limit: int = 50) -> Dict[str, List[Dict[str, Any]]]:
    cur = conn.cursor()
    results = {"types": [], "members": [], "native": [], "maps": []}
    
    # 1. Exact / Type.Member matching
    if '.' in query:
        parts = query.split('.', 1)
        t_name, m_name = parts[0], parts[1]
        
        m_params = [t_name, m_name]
        m_sql = """
        SELECT m.game, m.type_name, m.name, m.kind, m.signature, m.file_path, m.line_number, n.address
        FROM members m
        LEFT JOIN native_symbols n ON n.type_name = m.type_name COLLATE NOCASE AND n.member_name = m.name COLLATE NOCASE
        WHERE m.type_name = ? COLLATE NOCASE AND m.name LIKE ?
        """
        if game_filter:
            m_sql += " AND m.game = ?"
            m_params.append(game_filter)
        m_sql += " LIMIT ?"
        m_params.append(limit)
        
        cur.execute(m_sql, [t_name, f"%{m_name}%", *(m_params[2:])])
        for r in cur.fetchall():
            results["members"].append({
                "game": r["game"],
                "type_name": r["type_name"],
                "name": r["name"],
                "kind": r["kind"],
                "signature": r["signature"],
                "address": r["address"],
                "location": format_location(r["file_path"], r["line_number"])
            })
        return results

    # 2. General Query
    # Search Types
    if not kind_filter or kind_filter in ('class', 'struct', 'interface', 'enum', 'type'):
        t_params = [query, f"{query}%"]
        t_sql = """
        SELECT game, namespace, name, full_name, kind, file_path, line_number, token
        FROM types
        WHERE name = ? COLLATE NOCASE OR name LIKE ?
        """
        if game_filter:
            t_sql += " AND game = ?"
            t_params.append(game_filter)
        t_sql += " ORDER BY CASE WHEN name = ? COLLATE NOCASE THEN 0 ELSE 1 END, name LIMIT ?"
        t_params.append(query)
        t_params.append(limit)
        
        cur.execute(t_sql, t_params)
        for r in cur.fetchall():
            results["types"].append({
                "game": r["game"],
                "namespace": r["namespace"],
                "name": r["name"],
                "full_name": r["full_name"],
                "kind": r["kind"],
                "token": r["token"],
                "location": format_location(r["file_path"], r["line_number"])
            })

    # Search Members
    if not kind_filter or kind_filter in ('method', 'property', 'field'):
        m_params = [query, f"{query}%"]
        m_sql = """
        SELECT m.game, m.type_name, m.name, m.kind, m.signature, m.file_path, m.line_number, n.address
        FROM members m
        LEFT JOIN native_symbols n ON n.type_name = m.type_name COLLATE NOCASE AND n.member_name = m.name COLLATE NOCASE
        WHERE m.name = ? COLLATE NOCASE OR m.name LIKE ?
        """
        if kind_filter:
            m_sql += " AND m.kind = ?"
            m_params.append(kind_filter)
        if game_filter:
            m_sql += " AND m.game = ?"
            m_params.append(game_filter)
            
        m_sql += " ORDER BY CASE WHEN m.name = ? COLLATE NOCASE THEN 0 ELSE 1 END, m.name LIMIT ?"
        m_params.append(query)
        m_params.append(limit)
        
        cur.execute(m_sql, m_params)
        for r in cur.fetchall():
            results["members"].append({
                "game": r["game"],
                "type_name": r["type_name"],
                "name": r["name"],
                "kind": r["kind"],
                "signature": r["signature"],
                "address": r["address"],
                "location": format_location(r["file_path"], r["line_number"])
            })

    # Search Native Symbols (only if not restricted to GSD1 or GSDShare, unless specifically requested)
    if (not game_filter or game_filter == 'GSD2') and (not kind_filter or kind_filter == 'native'):
        n_params = [query, f"{query}%", f"%{query}%"]
        n_sql = """
        SELECT address, type_name, member_name, full_symbol
        FROM native_symbols
        WHERE member_name = ? COLLATE NOCASE 
           OR member_name LIKE ? 
           OR full_symbol LIKE ?
        ORDER BY CASE WHEN member_name = ? COLLATE NOCASE THEN 0 ELSE 1 END
        LIMIT ?
        """
        n_params.append(query)
        n_params.append(limit)
        
        cur.execute(n_sql, n_params)
        for r in cur.fetchall():
            results["native"].append({
                "address": r["address"],
                "type_name": r["type_name"],
                "member_name": r["member_name"],
                "symbol": r["full_symbol"]
            })

    # Search Maps & World Environments
    if not kind_filter or kind_filter == 'map':
        map_params = [f"%{query}%", f"%{query}%", f"%{query}%", f"%{query}%"]
        map_sql = """
        SELECT game, map_id, name, region, handler_class, handler_location, doc_path, description
        FROM maps
        WHERE map_id LIKE ? 
           OR name LIKE ? 
           OR region LIKE ?
           OR description LIKE ?
        """
        if game_filter:
            map_sql += " AND game = ?"
            map_params.append(game_filter)
        map_sql += " ORDER BY CASE WHEN map_id = ? COLLATE NOCASE THEN 0 WHEN name LIKE ? THEN 1 ELSE 2 END LIMIT ?"
        map_params.append(query)
        map_params.append(f"{query}%")
        map_params.append(limit)

        cur.execute(map_sql, map_params)
        for r in cur.fetchall():
            results["maps"].append({
                "game": r["game"],
                "map_id": r["map_id"],
                "name": r["name"],
                "region": r["region"],
                "handler_class": r["handler_class"],
                "handler_location": r["handler_location"],
                "doc_path": r["doc_path"],
                "description": r["description"]
            })

    return results

def print_table(results: Dict[str, List[Dict[str, Any]]], query: str, elapsed_ms: float, brief: bool = False):
    total = len(results["types"]) + len(results["members"]) + len(results["native"]) + len(results["maps"])
    print(f"\n[Search: '{query}'] Found {total} result(s) in {elapsed_ms:.1f}ms\n" + "=" * 80)
    
    if results["types"]:
        print(f"\n--- TYPES ({len(results['types'])}) ---")
        for t in results["types"]:
            token_str = f" [Token: {t['token']}]" if t['token'] else ""
            if brief:
                print(f"[{t['game']}] {t['kind']} {t['full_name']}{token_str} -> {t['location']}")
            else:
                print(f"[{t['game']}] {t['kind']} {t['full_name']}{token_str}")
                print(f"  Location: {t['location']}")
                
    if results["members"]:
        print(f"\n--- MEMBERS ({len(results['members'])}) ---")
        for m in results["members"]:
            addr_str = f" [Native: {m['address']}]" if m['address'] else ""
            if brief:
                print(f"[{m['game']}] {m['type_name']}.{m['name']} ({m['kind']}){addr_str} -> {m['location']}")
            else:
                print(f"[{m['game']}] {m['signature']}{addr_str}")
                print(f"  Type: {m['type_name']} | Kind: {m['kind']}")
                print(f"  Location: {m['location']}")
                
    if results["native"]:
        print(f"\n--- NATIVE / IL2CPP SYMBOLS ({len(results['native'])}) ---")
        for n in results["native"]:
            if brief:
                print(f"{n['address']} -> {n['symbol']}")
            else:
                print(f"{n['address']}  {n['symbol']}")

    if results["maps"]:
        print(f"\n--- MAPS & WORLD ENVIRONMENTS ({len(results['maps'])}) ---")
        for mp in results["maps"]:
            if brief:
                print(f"[{mp['game']}] {mp['map_id']:8} - {mp['name']} ({mp['region']}) -> {mp['doc_path']}")
            else:
                print(f"[{mp['game']}] {mp['map_id']} - {mp['name']} [Region: {mp['region']}]")
                print(f"  Handler: {mp['handler_class']} ({mp['handler_location']})")
                print(f"  Doc: {mp['doc_path']}")
                print(f"  Details: {mp['description']}")

def main():
    parser = argparse.ArgumentParser(description="High-Speed Decompiled Symbol Search")
    parser.add_argument("query", help="Symbol name, Type.Member, or hex address (e.g., EventInit, MACHICON.mstep, 0x1818bb190, Banner, vc18)")
    parser.add_argument("--db", default=DEFAULT_DB_PATH, help="Path to symbols.db")
    parser.add_argument("-m", "--members", action="store_true", help="Dump all members of the specified type")
    parser.add_argument("-n", "--limit", type=int, default=50, help="Maximum number of results (default: 50)")
    parser.add_argument("--gsd1", action="store_true", help="Scope search to GSD1 only")
    parser.add_argument("--gsd2", action="store_true", help="Scope search to GSD2 only")
    parser.add_argument("--share", action="store_true", help="Scope search to GSDShare only")
    parser.add_argument("--types", action="store_true", help="Search types only")
    parser.add_argument("--methods", action="store_true", help="Search methods only")
    parser.add_argument("--fields", action="store_true", help="Search fields only")
    parser.add_argument("--props", action="store_true", help="Search properties only")
    parser.add_argument("--native", action="store_true", help="Search native IL2CPP symbols only")
    parser.add_argument("--maps", action="store_true", help="Search maps and world areas only")
    parser.add_argument("--brief", action="store_true", help="One-line brief output")
    parser.add_argument("--json", action="store_true", help="Output results in JSON format")
    
    args = parser.parse_args()

    conn = get_connection(args.db)

    # Determine game filter
    game_filter = None
    if args.gsd1:
        game_filter = "GSD1"
    elif args.gsd2:
        game_filter = "GSD2"
    elif args.share:
        game_filter = "GSDShare"

    # Determine kind filter
    kind_filter = None
    if args.types:
        kind_filter = "type"
    elif args.methods:
        kind_filter = "method"
    elif args.fields:
        kind_filter = "field"
    elif args.props:
        kind_filter = "property"
    elif args.native:
        kind_filter = "native"
    elif args.maps:
        kind_filter = "map"

    t0 = time.time()
    
    # Check if query is a hex address
    is_addr = False
    clean_q = args.query.strip().lower()
    if clean_q.startswith("0x") or (len(clean_q) >= 6 and all(c in "0123456789abcdef" for c in clean_q)):
        try:
            int(clean_q, 16)
            is_addr = True
        except ValueError:
            pass

    if is_addr:
        addr_res = query_by_address(conn, args.query, limit=args.limit)
        elapsed_ms = (time.time() - t0) * 1000
        if args.json:
            print(json.dumps({"query": args.query, "elapsed_ms": elapsed_ms, "results": addr_res}, indent=2))
        else:
            print(f"\n[Address: {args.query}] Found {len(addr_res)} result(s) in {elapsed_ms:.1f}ms\n" + "=" * 80)
            for r in addr_res:
                print(f"Address: {r['address']} -> {r['symbol']}")
                if r["cs_match"]:
                    cs = r["cs_match"]
                    print(f"  C# Match: [{cs['game']}] {cs['signature']}")
                    print(f"  Location: {cs['location']}")
        conn.close()
        return

    # Check if dumping type members
    if args.members:
        members_res = query_type_members(conn, args.query, kind_filter=kind_filter, game_filter=game_filter, limit=args.limit)
        elapsed_ms = (time.time() - t0) * 1000
        if args.json:
            print(json.dumps({"type": args.query, "elapsed_ms": elapsed_ms, "members": members_res}, indent=2))
        else:
            print(f"\n[Type Members: {args.query}] Found {len(members_res)} member(s) in {elapsed_ms:.1f}ms\n" + "=" * 80)
            for m in members_res:
                addr_str = f" [Native: {m['address']}]" if m['address'] else ""
                if args.brief:
                    print(f"[{m['game']}] {m['kind']:8} {m['name']}{addr_str} -> {m['location']}")
                else:
                    print(f"[{m['game']}] {m['signature']}{addr_str}")
                    print(f"  Location: {m['location']}")
        conn.close()
        return

    # General search
    search_res = query_symbols(conn, args.query, game_filter=game_filter, kind_filter=kind_filter, limit=args.limit)
    elapsed_ms = (time.time() - t0) * 1000

    if args.json:
        print(json.dumps({"query": args.query, "elapsed_ms": elapsed_ms, **search_res}, indent=2))
    else:
        print_table(search_res, args.query, elapsed_ms, brief=args.brief)

    conn.close()

if __name__ == "__main__":
    main()
