#!/usr/bin/env python3
"""
save_inspector.py - Universal Decrypted Save File Inspector & Diff Tool
Part of Suikoden Remaster Modding Tool Suite.

Inspects decrypted Suikoden I and II save files produced by SuikodenFix.

Usage:
  python save_inspector.py --list
  python save_inspector.py --game s2 --flags 61 71 72 148
  python save_inspector.py --save Data155.json --active-flags
  python save_inspector.py --diff Data154.json Data155.json
  python save_inspector.py --summary
"""

import os
import sys
import json
import glob
import argparse

DEFAULT_DECRYPTED_BASE = r"D:\SteamLibrary\steamapps\common\Suikoden I and II HD Remaster\SuikodenFix\Decrypted"

def get_save_dir(game="s2"):
    sub = "gsd2" if game.lower() in ["s2", "gsd2", "2"] else "gsd1"
    return os.path.join(DEFAULT_DECRYPTED_BASE, sub)

def resolve_save_file(specifier, game="s2"):
    if not specifier:
        # Pick newest save in folder
        sdir = get_save_dir(game)
        files = glob.glob(os.path.join(sdir, "*.json"))
        if not files:
            return None
        return max(files, key=os.path.getmtime)

    # Check if absolute or relative file exists
    if os.path.exists(specifier):
        return specifier

    sdir = get_save_dir(game)
    # Check if number like "155" or "0"
    if specifier.isdigit():
        target = os.path.join(sdir, f"Data{specifier}.json")
        if os.path.exists(target):
            return target
    # Check if basename like "Data155.json"
    target = os.path.join(sdir, specifier)
    if os.path.exists(target):
        return target
    if not target.endswith(".json"):
        target += ".json"
        if os.path.exists(target):
            return target

    return None

def load_save(filepath):
    try:
        with open(filepath, "r", encoding="utf-8-sig") as f:
            return json.load(f)
    except Exception as e:
        print(f"Error loading '{filepath}': {e}")
        return None

def list_saves(game="s2", count=15):
    sdir = get_save_dir(game)
    if not os.path.exists(sdir):
        print(f"Save directory not found: {sdir}")
        return
    files = glob.glob(os.path.join(sdir, "*.json"))
    files = sorted(files, key=os.path.getmtime, reverse=True)
    print(f"\nRecent {game.upper()} Decrypted Saves in {sdir}:")
    for f in files[:count]:
        mtime = os.path.getmtime(f)
        import time
        time_str = time.strftime("%Y-%m-%d %H:%M:%S", time.localtime(mtime))
        size_kb = os.path.getsize(f) / 1024
        print(f"  {os.path.basename(f):18} | {size_kb:6.1f} KB | Modified: {time_str}")

def dump_summary(filepath, data):
    print(f"\n=======================================================")
    print(f"Save: {os.path.basename(filepath)}")
    gd = data.get("game_data", {})
    if gd:
        hero = gd.get("bozu_name", "Unknown")
        castle = gd.get("base_name", "Unknown")
        base_lv = gd.get("base_lv", "N/A")
        print(f"  Hero Name   : {hero}")
        print(f"  Castle Name : {castle} (Level: {base_lv})")
        print(f"  Play Time   : {gd.get('hon_time', 'N/A')} frames")
        if "potch" in gd or "money" in gd:
            print(f"  Potch       : {gd.get('potch', gd.get('money', 'N/A'))}")
    ef = data.get("event_flag", [])
    cf = data.get("chara_flag", [])
    print(f"  Flags Array : event_flag len={len(ef)}, chara_flag len={len(cf)}")
    print("=======================================================")

def inspect_flags(data, flag_indices):
    ef = data.get("event_flag", [])
    if not ef:
        print("No event_flag array found in save.")
        return
    print("\nEvent Flag Inspection:")
    for idx in flag_indices:
        if 0 <= idx < len(ef):
            val = ef[idx]
            bits = f"{val:08b}"
            print(f"  Flag [{idx:3d}]: Val = {val:3d} (0x{val:02X}) | Bits: [{bits}]")
        else:
            print(f"  Flag [{idx:3d}]: Out of bounds (len={len(ef)})")

def inspect_active_flags(data, limit=100):
    ef = data.get("event_flag", [])
    print(f"\nActive (Non-Zero) Event Flags ({len(ef)} total flags):")
    active = [(i, val) for i, val in enumerate(ef) if val != 0]
    for idx, val in active[:limit]:
        print(f"  Flag [{idx:3d}]: {val:3d} (0x{val:02X}) [{val:08b}]")
    print(f"Total non-zero flags: {len(active)}")

def diff_saves(save_path1, save_path2):
    s1 = load_save(save_path1)
    s2 = load_save(save_path2)
    if not s1 or not s2:
        return

    print(f"\n=======================================================")
    print(f"Diffing Saves:")
    print(f"  [A]: {os.path.basename(save_path1)}")
    print(f"  [B]: {os.path.basename(save_path2)}")
    print("=======================================================")

    # 1. Diff event flags
    ef1 = s1.get("event_flag", [])
    ef2 = s2.get("event_flag", [])
    max_len = max(len(ef1), len(ef2))
    changed_flags = []
    for i in range(max_len):
        v1 = ef1[i] if i < len(ef1) else 0
        v2 = ef2[i] if i < len(ef2) else 0
        if v1 != v2:
            changed_flags.append((i, v1, v2))

    print(f"\n--- Event Flags Changed ({len(changed_flags)} total) ---")
    for idx, v1, v2 in changed_flags[:100]:
        print(f"  Flag [{idx:3d}]: 0x{v1:02X} ({v1:3d}) -> 0x{v2:02X} ({v2:3d})  [diff: {v1:08b} -> {v2:08b}]")

    # 2. Diff game_data fields
    gd1 = s1.get("game_data", {})
    gd2 = s2.get("game_data", {})
    all_keys = sorted(set(list(gd1.keys()) + list(gd2.keys())))
    changed_gd = []
    for k in all_keys:
        v1 = gd1.get(k)
        v2 = gd2.get(k)
        if v1 != v2 and not isinstance(v1, (list, dict)):
            changed_gd.append((k, v1, v2))

    if changed_gd:
        print(f"\n--- Game Data Scalars Changed ({len(changed_gd)} fields) ---")
        for k, v1, v2 in changed_gd:
            print(f"  {k:20}: {v1} -> {v2}")

    print("\nDiff complete.")

def main():
    parser = argparse.ArgumentParser(description="Universal Decrypted Save Inspector & Diff Tool")
    parser.add_argument("--game", default="s2", choices=["s1", "s2"], help="Game edition (s1 or s2)")
    parser.add_argument("--save", default=None, help="Save file path, filename, or slot number (e.g. 155)")
    parser.add_argument("--list", action="store_true", help="List recent decrypted saves")
    parser.add_argument("--flags", type=int, nargs="+", help="Specific flag byte indices to inspect")
    parser.add_argument("--active-flags", action="store_true", help="List all non-zero flags")
    parser.add_argument("--diff", nargs=2, metavar=("SAVE1", "SAVE2"), help="Compare two save files")
    parser.add_argument("--summary", action="store_true", help="Print save file summary")

    args = parser.parse_args()

    if args.list:
        list_saves(args.game)
        return

    if args.diff:
        p1 = resolve_save_file(args.diff[0], args.game)
        p2 = resolve_save_file(args.diff[1], args.game)
        if not p1 or not os.path.exists(p1):
            print(f"Could not locate save [A]: {args.diff[0]}")
            return
        if not p2 or not os.path.exists(p2):
            print(f"Could not locate save [B]: {args.diff[1]}")
            return
        diff_saves(p1, p2)
        return

    resolved_path = resolve_save_file(args.save, args.game)
    if not resolved_path:
        print(f"No save file found for '{args.save}' in {args.game.upper()}")
        return

    data = load_save(resolved_path)
    if not data:
        return

    if args.flags:
        inspect_flags(data, args.flags)
        return

    if args.active_flags:
        inspect_active_flags(data)
        return

    # Default: summary
    dump_summary(resolved_path, data)

if __name__ == "__main__":
    main()
