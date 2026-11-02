#!/usr/bin/env python3
"""
binary_scanner.py - Native GameAssembly.dll Pattern & Relative Call Scanner
Part of Suikoden Remaster Modding Tool Suite.

Usage:
  python binary_scanner.py --calls-to 0x1818bb190
  python binary_scanner.py --hex "48 83 EC 28 E8"
  python binary_scanner.py --va 0x1818bb190
"""

import os
import sys
import struct
import argparse
import sqlite3

DEFAULT_GAME_ASSEMBLY = r"D:\SteamLibrary\steamapps\common\Suikoden I and II HD Remaster\GameAssembly.dll"
DEFAULT_SYMBOLS_DB = r"D:\Appz\PKCore\tools\symbol_indexer\symbols.db"

def resolve_symbol(va, db_path=DEFAULT_SYMBOLS_DB):
    if not os.path.exists(db_path):
        return None
    try:
        conn = sqlite3.connect(db_path)
        c = conn.cursor()
        hex_addr = f"0x{va:x}"
        c.execute("SELECT full_symbol FROM native_symbols WHERE address = ?", (hex_addr,))
        row = c.fetchone()
        if row:
            conn.close()
            return row[0]
        # Look for containing procedure
        c.execute("SELECT address, full_symbol FROM native_symbols WHERE address <= ? ORDER BY address DESC LIMIT 1", (hex_addr,))
        row = c.fetchone()
        conn.close()
        if row:
            base_va = int(row[0], 16)
            offset = va - base_va
            if 0 < offset < 0x2000:
                return f"{row[1]}+0x{offset:X}"
    except Exception:
        pass
    return None

def get_executable_sections(dll_path):
    sections = []
    with open(dll_path, "rb") as f:
        f.seek(0x3C)
        pe_off = struct.unpack('<I', f.read(4))[0]
        f.seek(pe_off + 4 + 16)
        opt_size = struct.unpack('<H', f.read(2))[0]
        f.seek(pe_off + 4 + 20 + opt_size)
        while True:
            sec_header = f.read(40)
            if not sec_header or sec_header[0] == 0:
                break
            name = sec_header[:8].decode('latin1', errors='ignore').strip('\x00')
            virt_size, virt_addr, raw_size, raw_ptr = struct.unpack('<IIII', sec_header[8:24])
            characteristics = struct.unpack('<I', sec_header[36:40])[0]
            # IMAGE_SCN_MEM_EXECUTE = 0x20000000
            if characteristics & 0x20000000:
                sections.append((name, virt_addr, virt_size, raw_ptr, raw_size))
    return sections

def find_relative_calls(dll_path, target_va, limit=50):
    if not os.path.exists(dll_path):
        print(f"GameAssembly.dll not found: {dll_path}")
        return

    sym = resolve_symbol(target_va)
    sym_desc = f" ({sym})" if sym else ""
    print(f"\nScanning GameAssembly.dll for calls to 0x{target_va:09X}{sym_desc}...")

    sections = get_executable_sections(dll_path)
    count = 0

    with open(dll_path, "rb") as f:
        for name, virt_addr, virt_size, raw_ptr, raw_size in sections:
            f.seek(raw_ptr)
            data = f.read(raw_size)
            sec_base_va = 0x180000000 + virt_addr
            for i in range(len(data) - 5):
                if data[i] == 0xE8:
                    rel = struct.unpack("<i", data[i+1:i+5])[0]
                    call_site_va = sec_base_va + i
                    dest_va = call_site_va + 5 + rel
                    if dest_va == target_va:
                        caller_sym = resolve_symbol(call_site_va)
                        caller_desc = f" [{caller_sym}]" if caller_sym else ""
                        print(f"  Call from VA: 0x{call_site_va:09X} (sec {name} +0x{i:06X}){caller_desc}")
                        count += 1
                        if count >= limit:
                            break
            if count >= limit:
                break

    if count == 0:
        print("  No relative calls found.")
    else:
        print(f"Found {count} call sites.")

def search_hex(dll_path, pattern_str, limit=50):
    if not os.path.exists(dll_path):
        print(f"GameAssembly.dll not found: {dll_path}")
        return

    tokens = pattern_str.strip().split()
    pattern_bytes = bytes([int(t, 16) for t in tokens if t != "??"])
    print(f"\nSearching GameAssembly.dll for pattern: {pattern_str}...")

    with open(dll_path, "rb") as f:
        data = f.read()

    pos = 0
    count = 0
    while True:
        idx = data.find(pattern_bytes, pos)
        if idx == -1:
            break
        va = 0x180000000 + idx
        sym = resolve_symbol(va)
        sym_desc = f" ({sym})" if sym else ""
        print(f"  Found at offset 0x{idx:08X} (approx VA 0x{va:09X}){sym_desc}")
        count += 1
        pos = idx + 1
        if count >= limit:
            break

    if count == 0:
        print("  Pattern not found.")
    else:
        print(f"Found {count} occurrences.")

def main():
    parser = argparse.ArgumentParser(description="Native GameAssembly.dll Scanner")
    parser.add_argument("--dll", default=DEFAULT_GAME_ASSEMBLY, help="Path to GameAssembly.dll")
    parser.add_argument("--calls-to", default=None, help="Target VA to find calls to (e.g. 0x1818bb190)")
    parser.add_argument("--hex", default=None, help="Hex byte pattern to search (e.g. '48 83 EC 28')")
    parser.add_argument("--limit", type=int, default=50, help="Max results")

    args = parser.parse_args()

    if args.calls_to:
        target_va = int(args.calls_to, 16) if args.calls_to.lower().startswith("0x") else int(args.calls_to)
        find_relative_calls(args.dll, target_va, limit=args.limit)
    elif args.hex:
        search_hex(args.dll, args.hex, limit=args.limit)
    else:
        parser.print_help()

if __name__ == "__main__":
    main()
