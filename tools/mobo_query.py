#!/usr/bin/env python3
"""
mobo_query.py - Universal Mobobehaviour Map & Event Bytecode Query Tool
Part of Suikoden Remaster Modding Tool Suite.

Usage:
  python mobo_query.py --flag 61
  python mobo_query.py --op 30 --map "vk*"
  python mobo_query.py --map vk30 --summary
  python mobo_query.py --map vk30 --events
  python mobo_query.py --map vk30 --mobj
  python mobo_query.py --text "Hai Yo"
"""

import os
import sys
import json
import glob
import argparse
import fnmatch

DEFAULT_MOBO_DIR = r"D:\Modding\suikodum\Mobobehaviour"
DEFAULT_TEXT_FILE = r"D:\Modding\suikodum\TextAsset\text_gsd2_en"

# Common EventControll (eventCom) opcode names
OPCODE_NAMES = {
    0: "NOP", 1: "ECMapCut", 2: "ECMapDouki", 3: "ECKeyCut", 4: "ECKeyRet",
    5: "ECTimWait", 6: "ECRenzokOn", 7: "ECRenzokOff", 8: "ECVramPosSet",
    9: "ECDmSrnMake", 10: "ECEvFlgSet", 11: "ECEvFlgOff", 12: "ECTkFlgSet",
    13: "ECTkFlgOff", 14: "ECTwFlgSet", 15: "ECTwFlgOff", 16: "ECTwFlgWait",
    17: "ECTwGFlgSet", 18: "ECTwGFlgOff", 19: "ECHonFlgSet", 20: "ECHonFlgOff",
    21: "ECEvFlgWait", 22: "ECWkEvFlgSet", 23: "ECWkEvFlgOff", 24: "ECWkEvFlgWait",
    25: "ECWinEvFlgSet", 26: "ECWinEvFlgOff", 27: "ECWinEvFlgWait", 28: "ECCharEvFlgSet",
    29: "ECSrnBWIO", 30: "ECFIOControll", 31: "ECMachiStControll", 32: "ECSMapChenge",
    33: "ECMapChenge", 34: "ECMemMapChenge", 35: "ECMachiChenge", 36: "ECMachiChengeM",
    37: "ECWarEventGo", 38: "ECEventBattleGo", 39: "ECRndBatCut", 40: "ECSaveGo",
    46: "ECOverlayPset2", 47: "ECOverlayPset", 48: "ECOverlayGo", 49: "ECYMOverlayGo",
    50: "ECBGfreeOverlayGo", 51: "ECMfreeOverlayGo", 52: "ECMfree640Go",
    56: "ECPartySet", 57: "ECLPartySet", 58: "ECInitPartySet", 59: "ECPartyClear",
    130: "MsgCall", 131: "MsgWait", 148: "ECSpecial148"
}

FLAG_FORM_OPS = {1: "FlgOn", 2: "FlgOff", 3: "FlgOnAnd", 4: "FlgOffAnd", 9: "FlgChk", 10: "FlgChkAlt"}
FLAG_COM_OPS = {10: "ECEvFlgSet", 11: "ECEvFlgOff", 21: "ECEvFlgWait"}

def load_text_cache(text_path):
    if not os.path.exists(text_path):
        return {}
    try:
        with open(text_path, "r", encoding="utf-8") as f:
            data = json.load(f)
        cache = {}
        for item in data.get("textList", []):
            tid = item.get("id")
            txt = item.get("text", "")
            if tid and txt:
                cache[tid] = txt
        return cache
    except Exception:
        return {}

def search_text_assets(text_cache, query, limit=50):
    query_lower = query.lower()
    matches = []
    for tid, txt in text_cache.items():
        if query_lower in txt.lower():
            matches.append((tid, txt))
            if len(matches) >= limit:
                break
    return matches

def get_map_files(mobo_dir, pattern):
    if not os.path.isdir(mobo_dir):
        return []
    if not pattern.endswith(".json"):
        pattern_file = f"{pattern}.json"
    else:
        pattern_file = pattern
    all_files = glob.glob(os.path.join(mobo_dir, "*.json"))
    matched = [f for f in all_files if fnmatch.fnmatch(os.path.basename(f).lower(), pattern_file.lower())]
    return sorted(matched)

def dump_summary(map_path, data):
    mname = os.path.splitext(os.path.basename(map_path))[0]
    ed = data.get("eventdata", {})
    submaps = ed.get("mapeventdat", [])
    msgs = ed.get("sce_msg", [])
    print(f"\n=======================================================")
    print(f"Map: {mname.upper()} ({os.path.basename(map_path)})")
    print(f"Submaps: {len(submaps)} | Message Banks: {len(msgs)}")
    for s_idx, sub in enumerate(submaps):
        objs = sub.get("eventobj", [])
        events = sub.get("eventdat", [])
        print(f"  [Submap {s_idx}] mapno={sub.get('mapno')}, okaz={sub.get('okaz')} (objs: {len(objs)}), evkaz={sub.get('evkaz')} (events: {len(events)}), batlno={sub.get('batlno')}")
    print("=======================================================")

def dump_mobj(map_path, data, limit=100):
    mname = os.path.splitext(os.path.basename(map_path))[0]
    submaps = data.get("eventdata", {}).get("mapeventdat", [])
    for s_idx, sub in enumerate(submaps):
        objs = sub.get("eventobj", [])
        print(f"\n--- {mname} Submap {s_idx} Objects ({len(objs)} total) ---")
        for o_idx, o in enumerate(objs[:limit]):
            print(f"  Obj [{o_idx:2d}]: otyp={o.get('otyp')} ano={o.get('ano')} fpno={o.get('fpno')} pos=({o.get('x')}, {o.get('y')}) disp={o.get('disp')} spd={o.get('spd')} wt={o.get('wt')}")

def dump_events(map_path, data, show_bytecode=False, limit=50):
    mname = os.path.splitext(os.path.basename(map_path))[0]
    submaps = data.get("eventdata", {}).get("mapeventdat", [])
    for s_idx, sub in enumerate(submaps):
        events = sub.get("eventdat", [])
        print(f"\n--- {mname} Submap {s_idx} Events ({len(events)} total) ---")
        for e_idx, ev in enumerate(events[:limit]):
            etyp = ev.get("etyp")
            form = ev.get("eventForm", [])
            com = ev.get("eventCom", [])
            print(f"  Ev [{e_idx:2d}]: etyp={etyp} | eventForm len={len(form)} | eventCom len={len(com)}")
            if show_bytecode:
                if form:
                    form_str = " ".join(f"{b:02X}" for b in form[:32])
                    if len(form) > 32: form_str += " ..."
                    print(f"       eventForm: [{form_str}]")
                if com:
                    com_str = " ".join(f"{b:02X}" for b in com[:32])
                    if len(com) > 32: com_str += " ..."
                    print(f"       eventCom : [{com_str}]")

def search_flags(map_files, target_flag, limit=100):
    count = 0
    print(f"\nSearching for Flag Byte {target_flag} (0x{target_flag:02X}) across {len(map_files)} maps...")
    for mf in map_files:
        mname = os.path.splitext(os.path.basename(mf))[0]
        try:
            with open(mf, "r", encoding="utf-8") as f:
                data = json.load(f)
        except Exception:
            continue
        submaps = data.get("eventdata", {}).get("mapeventdat", [])
        for s_idx, sub in enumerate(submaps):
            for e_idx, ev in enumerate(sub.get("eventdat", [])):
                # 1. Search in eventForm
                form = ev.get("eventForm", [])
                for i in range(len(form) - 2):
                    op = form[i]
                    if op in FLAG_FORM_OPS:
                        b = form[i + 1]
                        bit = form[i + 2]
                        if b == target_flag:
                            op_name = FLAG_FORM_OPS[op]
                            print(f"  [{mname}] Sub {s_idx} Ev {e_idx} Form (offset {i}): {op_name}(flag={b}, bit={bit}/0x{bit:02X})")
                            count += 1
                            if count >= limit: return
                # 2. Search in eventCom
                com = ev.get("eventCom", [])
                for i in range(len(com) - 2):
                    op = com[i]
                    if op in FLAG_COM_OPS:
                        b = com[i + 1]
                        bit = com[i + 2]
                        if b == target_flag:
                            op_name = FLAG_COM_OPS[op]
                            print(f"  [{mname}] Sub {s_idx} Ev {e_idx} Com  (offset {i}): {op_name}(flag={b}, bit={bit}/0x{bit:02X})")
                            count += 1
                            if count >= limit: return
    if count == 0:
        print("  No matches found.")
    else:
        print(f"Found {count} occurrences.")

def search_opcodes(map_files, target_op, limit=100):
    op_name = OPCODE_NAMES.get(target_op, f"Opcode_{target_op}")
    count = 0
    print(f"\nSearching for Opcode {target_op} ({op_name}) across {len(map_files)} maps...")
    for mf in map_files:
        mname = os.path.splitext(os.path.basename(mf))[0]
        try:
            with open(mf, "r", encoding="utf-8") as f:
                data = json.load(f)
        except Exception:
            continue
        submaps = data.get("eventdata", {}).get("mapeventdat", [])
        for s_idx, sub in enumerate(submaps):
            for e_idx, ev in enumerate(sub.get("eventdat", [])):
                com = ev.get("eventCom", [])
                for i in range(len(com)):
                    if com[i] == target_op:
                        ctx = com[i:i+6]
                        ctx_str = " ".join(f"{x}" for x in ctx)
                        print(f"  [{mname}] Sub {s_idx} Ev {e_idx} Com offset {i:3d}: [{ctx_str}]")
                        count += 1
                        if count >= limit: return
    if count == 0:
        print("  No matches found.")
    else:
        print(f"Found {count} occurrences.")

def main():
    parser = argparse.ArgumentParser(description="Mobobehaviour Map & Event Bytecode Query Tool")
    parser.add_argument("--map", default="*", help="Map name or glob pattern (e.g. vk30, 'vk*', '*')")
    parser.add_argument("--dir", default=DEFAULT_MOBO_DIR, help="Mobobehaviour directory path")
    parser.add_argument("--text-file", default=DEFAULT_TEXT_FILE, help="Path to text_gsd2_en")
    parser.add_argument("--flag", type=int, default=None, help="Search for flag byte index (e.g. 61, 148)")
    parser.add_argument("--op", type=int, default=None, help="Search for bytecode opcode in eventCom")
    parser.add_argument("--text", default=None, help="Search text in dialogue assets")
    parser.add_argument("--summary", action="store_true", help="Print summary of matched map(s)")
    parser.add_argument("--mobj", action="store_true", help="Dump map objects for matched map(s)")
    parser.add_argument("--events", action="store_true", help="Dump event metadata for matched map(s)")
    parser.add_argument("--bytecode", action="store_true", help="Include raw bytecode when dumping events")
    parser.add_argument("--limit", type=int, default=100, help="Max results to print")

    args = parser.parse_args()

    # Text search
    if args.text:
        text_cache = load_text_cache(args.text_file)
        print(f"Searching text for: '{args.text}' (Loaded {len(text_cache)} strings)")
        matches = search_text_assets(text_cache, args.text, limit=args.limit)
        for tid, txt in matches:
            print(f"  [ID {tid}]: {txt}")
        print(f"Found {len(matches)} matching strings.")
        return

    map_files = get_map_files(args.dir, args.map)
    if not map_files:
        print(f"No map files found matching '{args.map}' in '{args.dir}'")
        sys.exit(1)

    # Flag search
    if args.flag is not None:
        search_flags(map_files, args.flag, limit=args.limit)
        return

    # Opcode search
    if args.op is not None:
        search_opcodes(map_files, args.op, limit=args.limit)
        return

    # Map inspections
    for mf in map_files[:10]:
        try:
            with open(mf, "r", encoding="utf-8") as f:
                data = json.load(f)
        except Exception as e:
            print(f"Error reading {mf}: {e}")
            continue

        if args.summary or (not args.mobj and not args.events):
            dump_summary(mf, data)
        if args.mobj:
            dump_mobj(mf, data, limit=args.limit)
        if args.events:
            dump_events(mf, data, show_bytecode=args.bytecode, limit=args.limit)

if __name__ == "__main__":
    main()
