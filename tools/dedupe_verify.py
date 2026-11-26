#!/usr/bin/env python3
"""
dedupe_verify.py - Byte-Verified Duplicate Content Analyzer & Safe Deduplicator

Never relies on hashes alone:
  1. Pre-filters by exact file size.
  2. Groups by streaming SHA-256 hash.
  3. Performs mandatory byte-for-byte comparison on every candidate pair
     before confirming a duplicate.
  4. Runs in read-only dry-run mode by default.

Usage:
  python dedupe_verify.py "D:\\Modding\\suikodum\\Mobobehaviour\\Suikoden1"
  python dedupe_verify.py "D:\\Modding\\suikodum\\Mobobehaviour" -r --report dupes_report.txt
  python dedupe_verify.py "D:\\Modding\\suikodum\\Mobobehaviour\\Suikoden2" --quarantine "D:\\Modding\\suikodum\\dupes"
  python dedupe_verify.py "D:\\Modding\\suikodum\\Mobobehaviour\\Suikoden1" --json-semantic
"""

import argparse
import hashlib
import json
import os
import re
import shutil
import sys
from collections import defaultdict

CHUNK_SIZE = 65536
UNITY_HEADER_KEYS = {"m_GameObject", "m_Enabled", "m_Script", "m_Name"}


def iter_files(root_dir, recursive=False, extensions=None):
    """Yield file paths under root_dir matching optional extension filter."""
    if recursive:
        for dirpath, _, filenames in os.walk(root_dir):
            for name in filenames:
                if extensions and os.path.splitext(name)[1].lower() not in extensions:
                    continue
                yield os.path.join(dirpath, name)
    else:
        for name in os.listdir(root_dir):
            fpath = os.path.join(root_dir, name)
            if not os.path.isfile(fpath):
                continue
            if extensions and os.path.splitext(name)[1].lower() not in extensions:
                continue
            yield fpath


def sha256_file(path):
    """Compute SHA-256 hex digest in streaming chunks."""
    h = hashlib.sha256()
    with open(path, "rb") as f:
        while True:
            chunk = f.read(CHUNK_SIZE)
            if not chunk:
                break
            h.update(chunk)
    return h.hexdigest()


def files_byte_equal(path_a, path_b):
    """Verify two files are 100% identical byte-for-byte."""
    if os.path.getsize(path_a) != os.path.getsize(path_b):
        return False
    with open(path_a, "rb") as fa, open(path_b, "rb") as fb:
        while True:
            ba = fa.read(CHUNK_SIZE)
            bb = fb.read(CHUNK_SIZE)
            if ba != bb:
                return False
            if not ba:
                return True


def canonical_sort_key(path):
    """Prefer clean filenames without Unity ' #12345' suffixes, then shortest name."""
    name = os.path.basename(path)
    has_hash_suffix = 1 if re.search(r" #\d+\.", name) else 0
    return (has_hash_suffix, len(name), name.lower(), path.lower())


def find_exact_duplicates(files, include_empty=False):
    """Return verified byte-identical duplicate groups: list of [canonical, dup1, ...]."""
    by_size = defaultdict(list)
    for path in files:
        try:
            sz = os.path.getsize(path)
        except OSError:
            continue
        if sz == 0 and not include_empty:
            continue
        by_size[sz].append(path)

    by_hash = defaultdict(list)
    for sz, group in by_size.items():
        if len(group) < 2:
            continue
        for path in group:
            try:
                digest = sha256_file(path)
                by_hash[(sz, digest)].append(path)
            except OSError:
                continue

    verified_groups = []
    for (_, _), candidates in by_hash.items():
        if len(candidates) < 2:
            continue
        candidates.sort(key=canonical_sort_key)
        # Partition into genuinely byte-identical subgroups (guards against hash collisions)
        subgroups = []
        for cand in candidates:
            placed = False
            for sg in subgroups:
                if files_byte_equal(sg[0], cand):
                    sg.append(cand)
                    placed = True
                    break
            if not placed:
                subgroups.append([cand])
        for sg in subgroups:
            if len(sg) >= 2:
                verified_groups.append(sg)

    return verified_groups


def find_json_semantic_duplicates(files):
    """Report JSON files with identical payload excluding Unity header fields (read-only)."""
    by_payload = defaultdict(list)
    for path in files:
        if not path.lower().endswith(".json"):
            continue
        try:
            with open(path, "r", encoding="utf-8-sig") as f:
                data = json.load(f)
            if not isinstance(data, dict):
                continue
            payload = {k: v for k, v in data.items() if k not in UNITY_HEADER_KEYS}
            if not payload:
                continue
            serialized = json.dumps(payload, sort_keys=True, ensure_ascii=False)
            by_payload[serialized].append(path)
        except Exception:
            continue

    groups = []
    for paths in by_payload.values():
        if len(paths) >= 2:
            paths.sort(key=canonical_sort_key)
            groups.append(paths)
    return groups


def main():
    parser = argparse.ArgumentParser(
        description="Byte-verified duplicate content analyzer and safe deduplicator."
    )
    parser.add_argument("target_dir", help="Directory to scan for duplicate files.")
    parser.add_argument("-r", "--recursive", action="store_true", help="Scan subdirectories recursively.")
    parser.add_argument("--ext", default="", help="Comma-separated extensions to include (e.g. .json,.txt).")
    parser.add_argument("--include-empty", action="store_true", help="Include 0-byte files.")
    parser.add_argument(
        "--json-semantic",
        action="store_true",
        help="Also report JSON files with identical content ignoring Unity headers (report-only).",
    )
    parser.add_argument(
        "--quarantine",
        default="",
        help="Move verified byte-identical duplicates to this directory instead of deleting.",
    )
    parser.add_argument(
        "--delete",
        action="store_true",
        help="Permanently delete verified byte-identical duplicates (keeps 1 canonical copy per group).",
    )
    parser.add_argument("--report", default="", help="Write full duplicate report to this file.")
    args = parser.parse_args()

    if args.delete and args.quarantine:
        print("Error: Cannot use --delete and --quarantine together.", file=sys.stderr)
        return 1

    target_dir = os.path.abspath(args.target_dir)
    if not os.path.isdir(target_dir):
        print(f"Error: Directory not found: {target_dir}", file=sys.stderr)
        return 1

    extensions = None
    if args.ext.strip():
        extensions = {
            e.strip().lower() if e.strip().startswith(".") else f".{e.strip().lower()}"
            for e in args.ext.split(",")
            if e.strip()
        }

    files = list(iter_files(target_dir, recursive=args.recursive, extensions=extensions))
    print(f"Scanning {len(files)} files in: {target_dir}")

    exact_groups = find_exact_duplicates(files, include_empty=args.include_empty)
    total_dups = sum(len(g) - 1 for g in exact_groups)
    reclaimable_bytes = sum(os.path.getsize(p) for g in exact_groups for p in g[1:])

    lines = [
        f"Exact Byte-Verified Duplicate Groups: {len(exact_groups)}",
        f"Duplicate Files: {total_dups} ({reclaimable_bytes:,} bytes)",
        "",
    ]
    for idx, group in enumerate(exact_groups, 1):
        sz = os.path.getsize(group[0])
        lines.append(f"[Group {idx}] ({len(group)} files, {sz:,} bytes each)")
        lines.append(f"  KEEP: {group[0]}")
        for dup in group[1:]:
            lines.append(f"  DUP : {dup}")

    if args.json_semantic:
        sem_groups = find_json_semantic_duplicates(files)
        exact_sets = {frozenset(g) for g in exact_groups}
        sem_only = [g for g in sem_groups if frozenset(g) not in exact_sets]
        lines.append("")
        lines.append(f"JSON Semantic-Only Duplicate Groups (report-only, headers differ): {len(sem_only)}")
        for idx, group in enumerate(sem_only, 1):
            lines.append(f"[Semantic Group {idx}] ({len(group)} files)")
            for p in group:
                lines.append(f"  FILE: {p}")

    summary = "\n".join(lines[:3])
    print(summary)
    if exact_groups:
        preview_limit = 40
        for line in lines[3:3 + preview_limit]:
            print(line)
        if len(lines) > 3 + preview_limit:
            print(f"... ({len(lines) - 3 - preview_limit} more lines; use --report to save full output)")

    if args.report:
        with open(args.report, "w", encoding="utf-8") as rf:
            rf.write("\n".join(lines) + "\n")
        print(f"Report written to: {args.report}")

    if args.quarantine and total_dups > 0:
        qroot = os.path.abspath(args.quarantine)
        moved = 0
        for group in exact_groups:
            for dup in group[1:]:
                rel = os.path.relpath(dup, target_dir)
                dest = os.path.join(qroot, rel)
                os.makedirs(os.path.dirname(dest), exist_ok=True)
                shutil.move(dup, dest)
                moved += 1
        print(f"Quarantined {moved} verified duplicate files to: {qroot}")
    elif args.delete and total_dups > 0:
        deleted = 0
        for group in exact_groups:
            for dup in group[1:]:
                os.remove(dup)
                deleted += 1
        print(f"Deleted {deleted} verified duplicate files.")
    elif total_dups > 0:
        print("Dry-run mode: no files were modified. Pass --quarantine <dir> or --delete to act.")

    return 0


if __name__ == "__main__":
    sys.exit(main())
