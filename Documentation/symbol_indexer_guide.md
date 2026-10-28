# High-Speed Decompiled Symbol Indexer Guide

## Overview

The **High-Speed Decompiled Symbol Indexer** provides sub-millisecond (<1ms to 5ms) lookup capabilities across all decompiled C# sources and native IL2CPP symbol tables for **Suikoden I & II HD Remaster**.

Built on a memory-mapped SQLite database (`symbols.db`) with Full-Text Search (FTS5) and indexed B-Trees, this developer tool eliminates slow directory greps and enables instantaneous symbol discovery, type inspection, and native-to-decompiled address mapping.

---

## Indexed Repositories & Data Sources

| Source | Path | Description | Entries Indexed |
| :--- | :--- | :--- | :--- |
| **GSD1** | `d:\Appz\Suisource\GSD1` | Suikoden 1 Decompiled C# Sources | 445 files |
| **GSD2** | `d:\Appz\Suisource\GSD2\GSD2` | Suikoden 2 Decompiled C# Sources | 1,483 files |
| **GSDShare** | `d:\Appz\Suisource\GSDShare` | Shared Remaster Engine & Framework Sources | 354 files |
| **Native Symbols** | `d:\Appz\Suisource\GSD2\GSD2\symbols.txt` | Native IL2CPP Address-to-Symbol Map | 189,523 symbols |

**Total Database Inventory**:
- **6,147 Types** (classes, structs, interfaces, enums)
- **259,139 Members** (methods, properties, fields)
- **189,523 Native Symbols** mapped with virtual memory addresses
- **361 Map Assets & Areas** across Suikoden I & II linked to documentation
- **802 Verified Game Entities** (Characters, Items, Runes, Gear, Food Recipes) mapped to native symbols

---

## Quick Start & Invocation

From the root PKCore workspace (`d:\Appz\PKCore`), you can execute queries via the batch wrapper:

```cmd
tools\sym.bat <query> [options]
```

Or invoke the Python script directly:

```cmd
python tools\symbol_indexer\sym.py <query> [options]
```

---

## Common Query Patterns

### 1. General Symbol / Method Search
Search by symbol name with instant matching across types, members, and native tables:
```cmd
tools\sym.bat EventInit
```

Output:
```text
[Search: 'EventInit'] Found 5 result(s) in 55.0ms
================================================================================

--- MEMBERS (2) ---
[GSD2] public EVENTCON EventInit() [Native: 0x1818bb190]
  Type: MACHICON | Kind: method
  Location: file:///d:/Appz/Suisource/GSD2/GSD2/MACHICON.cs#L947
[GSD2] public bool eventInitState
  Type: EVENTCON | Kind: property
  Location: file:///d:/Appz/Suisource/GSD2/GSD2/EVENTCON.cs#L6792

--- NATIVE / IL2CPP SYMBOLS (3) ---
0x1818bb190  MACHICON$$EventInit
0x182173be0  EVENTCON$$WindowEventInit
0x181f89da0  EventOverlayClass.Overlay_addeven$$OverlayAddEventInit
```

### 2. Type-Scoped Member Query (`Type.Member`)
Pinpoint a specific member in a type in ~0.5ms:
```cmd
tools\sym.bat MACHICON.mstep
```

Output:
```text
[Search: 'MACHICON.mstep'] Found 5 result(s) in 0.5ms
================================================================================

--- MEMBERS (5) ---
[GSD2] public int mstep
  Type: MACHICON | Kind: property
  Location: file:///d:/Appz/Suisource/GSD2/GSD2/MACHICON.cs#L17
[GSD2] public int _mstep
  Type: MACHICON | Kind: property
  Location: file:///d:/Appz/Suisource/GSD2/GSD2/MACHICON.cs#L1467
[GSD2] private global::System.IntPtr NativeFieldInfoPtr__mstep
  Type: MACHICON | Kind: field
  Location: file:///d:/Appz/Suisource/GSD2/GSD2/MACHICON.cs#L2641
[GSD2] private global::System.IntPtr NativeMethodInfoPtr_get_mstep_Public_get_Int32_0
  Type: MACHICON | Kind: field
  Location: file:///d:/Appz/Suisource/GSD2/GSD2/MACHICON.cs#L2848
[GSD2] private global::System.IntPtr NativeMethodInfoPtr_set_mstep_Public_set_Void_Int32_0
  Type: MACHICON | Kind: field
  Location: file:///d:/Appz/Suisource/GSD2/GSD2/MACHICON.cs#L2851
```

### 3. Hex Address Resolution (`0x...`)
Paste any native crash or IL2CPP address to resolve its symbol and immediately link to the decompiled C# source line:
```cmd
tools\sym.bat 0x1818bb190
```

Output:
```text
[Address: 0x1818bb190] Found 1 result(s) in 1.0ms
================================================================================
Address: 0x1818bb190 -> MACHICON$$EventInit
  C# Match: [GSD2] public EVENTCON EventInit()
  Location: d:/Appz/Suisource/GSD2/GSD2/MACHICON.cs:947
```

### 4. Full Class Inspection (`-m` / `--members`)
Inspect all fields, properties, and methods of a class with line numbers and signatures:
```cmd
tools\sym.bat MACHICON -m --methods -n 20
```

### 5. Game-Scoped Filtering
Restrict searches to a single game assembly:
- `--gsd1`: Suikoden 1 decompiled source only.
- `--gsd2`: Suikoden 2 decompiled source & native symbols only.
- `--share`: Shared engine and runtime source only.

```cmd
tools\sym.bat --gsd1 Player_h
```

### 6. Machine Output (`--json`)
Format results as structured JSON for automation, scripts, or editor extensions:
```cmd
tools\sym.bat MACHICON.EventInit --json
```

---

## Hand-in-Hand Workflow with REA (Reverse Engineer Anything)

The **Symbol Indexer** and **REA** complement each other directly to form a unified reverse engineering pipeline:

```text
┌─────────────────────────────────┐       ┌─────────────────────────────────┐
│     Symbol Indexer (Instant)     │       │     REA (Deep Binary Analysis)  │
│  - Instant type/member search   │       │  - Binary disassembler/Ghidra   │
│  - Decompiled C# source line    │  ───> │  - Assembly & Pseudocode        │
│  - Native IL2CPP address        │       │  - Cross-references & Callers   │
│  - Fast high-level navigation   │       │  - Register & control flow      │
└─────────────────────────────────┘       └─────────────────────────────────┘
                 ▲                                         │
                 │                                         │
                 └────── Resolves Subroutine Calls ────────┘
```

### 1. Step 1: Fast Anchor & Address Lookup (Symbol Indexer)
- When starting an investigation or analyzing a feature, query `tools\sym.bat <query>` to locate the high-level C# class, method signature, and virtual IL2CPP address in `<1ms`.
- When debugging a crash log, callstack, or hook failure containing a hex address, resolve it immediately:
  ```cmd
  tools\sym.bat 0x1818bb190
  ```

### 2. Step 2: Binary Disassembly & Pseudocode (REA)
- Pass the resolved virtual address directly into REA disassembler tools:
  - `goto_address(address="0x1818bb190")`
  - `procedure_pseudo_code(address="0x1818bb190")`
  - `procedure_assembly(address="0x1818bb190")`
  - `procedure_callers(address="0x1818bb190")` or `procedure_callees(address="0x1818bb190")`
  - `inspect_managed_native_boundaries(...)`
- Inspect raw registers, stack frames, compiler optimizations, and inlined logic that may not be apparent in decompiled C# sources alone.

### 3. Step 3: Resolve Discovered Subroutines (REA -> Symbol Indexer)
- While analyzing native disassembly in REA, you will frequently encounter indirect jumps, function calls, or field pointers (e.g. `CALL 0x1818beb40`).
- Pipe those addresses back into `tools\sym.bat <address>` to identify the C# method in <1ms without having to manually hunt through Ghidra symbols.

### 4. Step 4: Write & Ground Harmony Patches in PKCore
- With both the decompiled C# representation and the native execution flow confirmed, implement the Harmony patch in `Patches/` with exact confidence in parameter types, timing, and side effects.

---

## Rebuilding the Index

If decompiled source files or `symbols.txt` are updated, re-run `indexer.py`:

```cmd
python tools\symbol_indexer\indexer.py
```

Indexing takes ~11 seconds total to parse all 2,282 files, index 189k native symbols, build FTS5 tables, and commit SQLite indexes.

---

## Tool Architecture

```text
tools/
├── sym.bat                               # Windows CMD/PowerShell convenience wrapper
└── symbol_indexer/
    ├── indexer.py                        # Stream parser, schema builder & index generator
    ├── sym.py                            # Fast CLI query engine with FTS & SQLite MMAP
    └── symbols.db                        # SQLite database (indexed B-Trees + FTS5)
```

