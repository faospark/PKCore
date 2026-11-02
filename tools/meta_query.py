#!/usr/bin/env python3
"""
meta_query.py - Universal IL2CPP Metadata & String Literal Query Tool
Part of Suikoden Remaster Modding Tool Suite.

Queries Il2CppDumper output files: stringliteral.json, script.json, and dump.cs.

Usage:
  python meta_query.py --string "Hai Yo"
  python meta_query.py --string-addr 0x37F7200
  python meta_query.py --method "EventInit"
  python meta_query.py --method-addr 0x1818bb190
"""

import os
import sys
import json
import argparse

DEFAULT_DUMP_DIR = r"D:\Appz\Suisource\Il2CppDump"

def query_string_literal(dump_dir, query=None, addr=None, limit=50):
    path = os.path.join(dump_dir, "stringliteral.json")
    if not os.path.exists(path):
        print(f"File not found: {path}")
        return

    with open(path, "r", encoding="utf-8") as f:
        data = json.load(f)

    print(f"Loaded {len(data)} string literals from stringliteral.json")
    matches = []

    if addr:
        addr_clean = addr.lower().replace("0x", "").lstrip("0")
        for item in data:
            item_addr = item.get("address", "").lower().replace("0x", "").lstrip("0")
            if item_addr == addr_clean:
                matches.append(item)
    elif query:
        q_lower = query.lower()
        for item in data:
            if q_lower in item.get("value", "").lower():
                matches.append(item)
                if len(matches) >= limit:
                    break

    print(f"Found {len(matches)} matching string literals:")
    for m in matches:
        print(f"  [{m.get('address')}]: \"{m.get('value')}\"")

def query_methods(dump_dir, query=None, addr=None, limit=50):
    path = os.path.join(dump_dir, "script.json")
    if not os.path.exists(path):
        print(f"File not found: {path}")
        return

    with open(path, "r", encoding="utf-8") as f:
        data = json.load(f)

    methods = data.get("ScriptMethod", [])
    print(f"Loaded {len(methods)} methods from script.json")
    matches = []

    target_rva = None
    if addr:
        raw_val = int(addr, 16) if addr.lower().startswith("0x") else int(addr)
        if raw_val >= 0x180000000:
            target_rva = raw_val - 0x180000000
        else:
            target_rva = raw_val

    if target_rva is not None:
        for m in methods:
            if m.get("Address") == target_rva:
                matches.append(m)
    elif query:
        q_clean = query.lower().replace(".", "$$")
        q_raw = query.lower()
        for m in methods:
            name_lower = m.get("Name", "").lower()
            if q_clean in name_lower or q_raw in name_lower:
                matches.append(m)
                if len(matches) >= limit:
                    break

    print(f"Found {len(matches)} matching methods:")
    for m in matches:
        rva = m.get("Address", 0)
        va = 0x180000000 + rva
        print(f"  VA: 0x{va:09X} (RVA: 0x{rva:08X}) | {m.get('Name')}")
        sig = m.get("Signature")
        if sig:
            print(f"      Sig: {sig}")

def main():
    parser = argparse.ArgumentParser(description="Universal IL2CPP Metadata & String Literal Query Tool")
    parser.add_argument("--dir", default=DEFAULT_DUMP_DIR, help="Path to Il2CppDump directory")
    parser.add_argument("--string", default=None, help="Search string literal text")
    parser.add_argument("--string-addr", default=None, help="Lookup string literal by address (e.g. 0x37F7200)")
    parser.add_argument("--method", default=None, help="Search method by name")
    parser.add_argument("--method-addr", default=None, help="Lookup method by VA (0x18...) or RVA (0x...)")
    parser.add_argument("--limit", type=int, default=50, help="Max results to display")

    args = parser.parse_args()

    if args.string or args.string_addr:
        query_string_literal(args.dir, query=args.string, addr=args.string_addr, limit=args.limit)
    elif args.method or args.method_addr:
        query_methods(args.dir, query=args.method, addr=args.method_addr, limit=args.limit)
    else:
        parser.print_help()

if __name__ == "__main__":
    main()
