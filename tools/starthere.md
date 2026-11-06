# Suikoden Remaster Tool Suite: Agent & Developer Quickstart (`starthere.md`)

> [!IMPORTANT]
> **MANDATORY FOR ALL AGENTS & DEVELOPERS**:
> **DO NOT write ad-hoc Python scripts** (e.g. `check_vk*.py`, `find_flag*.py`, `inspect_save*.py`) in workspace roots or scratch folders.
> The workspace maintains a centralized, high-performance CLI tool suite in `tools/` that covers virtually all reverse-engineering, map inspection, flag auditing, save diffing, symbol lookup, and disassembly needs.
> **Check this document first and use the existing tools.**

---

## 1. Quick Decision Matrix ("What tool do I use?")

| Objective | Recommended Tool | Example Command |
| :--- | :--- | :--- |
| Find a class, method, or native address | `sym.bat` | `sym.bat MACHICON.EventInit` |
| Disassemble native x86_64 instructions | `disasm.bat` | `disasm.bat 0x1818bb190 64` |
| Search map for an event flag (on/off/wait) | `mobo_query.bat` | `mobo_query.bat --flag 61 --map "vk*"` |
| Search map for a bytecode opcode | `mobo_query.bat` | `mobo_query.bat --op 30 --map "v*"` |
| Inspect map submaps, objects, or events | `mobo_query.bat` | `mobo_query.bat --map vk30 --summary` |
| Search English dialogue / system strings | `mobo_query.bat` | `mobo_query.bat --text "Hai Yo"` |
| Check event flags in a decrypted save file | `save_inspector.bat` | `save_inspector.bat --save Data0.json --flags 61 71 148` |
| Compare two save files to see what changed | `save_inspector.bat` | `save_inspector.bat --diff Data147.json Data0.json` |
| List recent decrypted saves | `save_inspector.bat` | `save_inspector.bat --list` |
| Search IL2CPP method signatures / RVAs | `meta_query.bat` | `meta_query.bat --method "MACHICON.EventInit"` |
| Search string literals from memory dumps | `meta_query.bat` | `meta_query.bat --string "Hai Yo"` |
| Find which functions call a native VA | `binary_scanner.bat` | `binary_scanner.bat --calls-to 0x181a46050` |
| Search raw byte patterns in `GameAssembly` | `binary_scanner.bat` | `binary_scanner.bat --hex "48 83 EC 28 E8"` |
| Tail live game BepInEx log output | `tail_log.bat` | `tail_log.bat` |

---

## 2. Tool Reference & Syntax Guide

All tools can be executed directly from `d:\Appz\` root, `PKCore\tools\`, or `d:\Appz\tools\` using `.bat` wrappers or `python <tool>.py`.

### 2.1 `sym.bat` (Local Symbol Indexer)
- **Path**: `tools/sym.bat` or `tools/symbol_indexer/sym.py`
- **Purpose**: Ultra-fast (<3ms) local SQLite index of all decompiled Suisource C# symbols, types, methods, fields, and native memory addresses.
- **Syntax & Examples**:
  ```cmd
  sym.bat EventInit               :: Search all symbols matching 'EventInit'
  sym.bat MACHICON.mstep          :: Search member 'mstep' in class 'MACHICON'
  sym.bat MACHICON -m --methods   :: Dump all methods of class 'MACHICON'
  sym.bat 0x1818bb190             :: Reverse-resolve native VA to symbol & source file
  ```

### 2.2 `disasm.bat` (Fast Native Disassembly)
- **Path**: `tools/disasm.bat` or `tools/disasm.py`
- **Purpose**: Disassembles `GameAssembly.dll` native x86_64 instructions in <100ms using Capstone.
- **Syntax & Examples**:
  ```cmd
  disasm.bat <0xAddress> [num_bytes]
  disasm.bat 0x1818bb190 64
  ```

### 2.3 `mobo_query.bat` (Universal Map & Event Bytecode Engine)
- **Path**: `tools/mobo_query.bat` or `tools/mobo_query.py`
- **Purpose**: Deep queries across Unity `Mobobehaviour/<map>.json` files. Analyzes `mapeventdat`, `eventForm`, `eventCom`, `eventobj`, and localized text assets without loading huge JSON files manually.
- **Parameters**:
  - `--map <pattern>`: Filter map names (e.g. `vk30`, `"vk*"`, `"*"`, `"vh06"`). Default: `*`.
  - `--flag <int>`: Search for flag checks (`eventForm` opcodes 1, 2, 3, 4, 9, 10) or sets/waits (`eventCom` opcodes 10, 11, 21).
  - `--op <int>`: Search for a specific `eventCom` opcode across all maps.
  - `--text "<query>"`: Search dialogue text across all 23,000+ strings in `text_gsd2_en`.
  - `--summary`: Display submap counts, object counts, event counts, and battle settings.
  - `--mobj`: Dump map object placements (ID, animation, coordinates, display conditions).
  - `--events`: Dump event triggers and metadata.
  - `--bytecode`: Include raw bytecode hex dumps for events.
- **Examples**:
  ```cmd
  mobo_query.bat --flag 61 --map "vk*"
  mobo_query.bat --op 30 --map "v*"
  mobo_query.bat --text "Hai Yo"
  mobo_query.bat --map vk30 --summary
  mobo_query.bat --map vk30 --mobj
  mobo_query.bat --map vk30 --events --bytecode
  ```

### 2.4 `save_inspector.bat` (Universal Decrypted Save Examiner & Diff)
- **Path**: `tools/save_inspector.bat` or `tools/save_inspector.py`
- **Purpose**: Parses decrypted SuikodenFix save files (`SuikodenFix/Decrypted/gsd2/Data*.json`).
- **Parameters**:
  - `--list`: List recently modified saves with timestamps and sizes.
  - `--game <s1|s2>`: Select Suikoden 1 or 2 (default: `s2`).
  - `--save <path|slot>`: Select save file (e.g. `Data0.json`, `155`, or omit for newest save).
  - `--flags <ids...>`: Inspect specific event flag bytes (displays value, hex, and full 8-bit binary).
  - `--active-flags`: Dump all non-zero flags in the save.
  - `--diff <save1> <save2>`: Deep diff of two saves showing every changed flag (with bit transitions) and scalar game data fields (`base_lv`, `potch`, timers, etc.).
  - `--summary`: Hero name, castle name, play time, and flag counts.
- **Examples**:
  ```cmd
  save_inspector.bat --list
  save_inspector.bat --save Data0.json --flags 61 71 72 148
  save_inspector.bat --save Data0.json --active-flags
  save_inspector.bat --diff Data147.json Data0.json
  ```

### 2.5 `meta_query.bat` (IL2CPP Metadata & String Literal Search)
- **Path**: `tools/meta_query.bat` or `tools/meta_query.py`
- **Purpose**: Searches `Il2CppDump/stringliteral.json` and `Il2CppDump/script.json`.
- **Parameters**:
  - `--string "<query>"`: Search string literal values.
  - `--string-addr <0xAddr>`: Reverse lookup string literal by pointer.
  - `--method "<name>"`: Search method names, signatures, and RVAs/VAs (e.g. `MACHICON.EventInit`).
  - `--method-addr <0xAddr>`: Reverse lookup method by VA (0x18...) or RVA.
- **Examples**:
  ```cmd
  meta_query.bat --method "MACHICON.EventInit"
  meta_query.bat --method-addr 0x1818bb190
  meta_query.bat --string "IsIPAExtensions"
  ```

### 2.6 `binary_scanner.bat` (Native Pattern & Relative Call Scanner)
- **Path**: `tools/binary_scanner.bat` or `tools/binary_scanner.py`
- **Purpose**: Scans `GameAssembly.dll` executable sections (`il2cpp`, `.text`) directly.
- **Parameters**:
  - `--calls-to <0xAddr>`: Find all `0xE8` relative call sites calling this address, with caller symbol resolution.
  - `--hex "<pattern>"`: Scan for raw machine code hex sequences.
- **Examples**:
  ```cmd
  binary_scanner.bat --calls-to 0x181a46050
  binary_scanner.bat --hex "48 83 EC 28 E8"
  ```

---

## 3. Historical Archives (`tools/archive/`)

Prior one-off research scripts have been preserved and categorized under `tools/archive/`:
- `tools/archive/recruitment/`: Analysis scripts used during `PKRecruitmentPatch` reverse-engineering (`find_all_recruits.py`, `inspect_sound_opcodes.py`, etc.).
- `tools/archive/castle_research/`: Forensic scripts used to decode HQ maps and statues (`audit_vk*.py`, `check_vk*.py`, `statues_accurate_table.json`, etc.).
- `tools/archive/scratch_research/`: Specialized scripts from earlier investigation tasks.

If you believe a task requires custom inspection logic, check `tools/archive/` first to see if an earlier script already solved that domain problem.
