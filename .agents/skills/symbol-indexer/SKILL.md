---
name: symbol-indexer
description: High-speed symbol search and IL2CPP address lookup for Suikoden Remaster decompiled sources (GSD1, GSD2, GSDShare). Use when looking up game classes, methods, properties, fields, or native memory addresses.
---

# High-Speed Symbol Indexer & Query Guide

This skill provides instant (<1ms to 3ms) symbol discovery across all decompiled C# sources and native IL2CPP symbol tables for **Suikoden I & II HD Remaster**.

## When to Use

Always use this tool BEFORE performing broad ripgrep searches across `d:\Appz\Suisource`. The database indexes:
- **GSD1**: Suikoden 1 decompiled C# sources
- **GSD2**: Suikoden 2 decompiled C# sources
- **GSDShare**: Shared engine & runtime sources
- **symbols.txt**: 189,523 native IL2CPP address-to-symbol entries (from `d:\Appz\Suisource\Il2CppDump\symbols.txt`)
- **Metadata Dumps**: Also refer to `d:\Appz\Suisource\Il2CppDump\script.json` and `il2cpp.h` for complete metadata, field offsets, and struct definitions.

> **CRITICAL**: Do NOT run full headless Ghidra decompilations on `GameAssembly.dll`. The binary is 63 MB and will time out. All symbols, addresses, and C headers are ALREADY extracted in `d:\Appz\Suisource\Il2CppDump\` and queryable in `<3ms` with `sym.bat`.

Run from `d:\Appz\PKCore`:

### 1. Symbol / Method Lookup
```cmd
tools\sym.bat <SymbolName>
```
*Example:* `tools\sym.bat EventInit`

### 2. Type-Scoped Member Lookup
```cmd
tools\sym.bat <TypeName>.<MemberName>
```
*Example:* `tools\sym.bat MACHICON.mstep`

### 3. Native Address Resolution
```cmd
tools\sym.bat <HexAddress>
```
*Example:* `tools\sym.bat 0x1818bb190`
Resolves to the native symbol (`MACHICON$$EventInit`) and matches the C# declaration (`MACHICON.cs#L947`).

### 4. Dump Class Members
```cmd
tools\sym.bat <TypeName> -m [--methods|--fields|--props] [-n <limit>]
```
*Example:* `tools\sym.bat MACHICON -m --methods -n 25`

### 5. Game Scoping
```cmd
tools\sym.bat --gsd1 <query>
tools\sym.bat --gsd2 <query>
tools\sym.bat --share <query>
```

### 6. JSON Output Mode
```cmd
tools\sym.bat <query> --json
```

## Rebuilding the Index

If decompiled C# files or `symbols.txt` are modified, rebuild `symbols.db`:
```cmd
python tools\symbol_indexer\indexer.py
```
(Takes ~11s to index all 2,282 files and 189k native symbols).

## Hand-in-Hand Workflow with REA (Reverse Engineer Anything)

Use the Symbol Indexer and REA cooperatively:

1. **Locate & Anchor (Symbol Indexer)**:
   - Query `tools\sym.bat <Symbol>` or `tools\sym.bat <TypeName>.<MemberName>` to find high-level C# signatures and native IL2CPP virtual addresses in <1ms.
2. **Deep Binary & Assembly Inspection (REA)**:
   - Feed the discovered virtual address into REA tools (`open_binary`, `goto_address`, `procedure_pseudo_code`, `procedure_assembly`, `procedure_callers`, `procedure_callees`, `xrefs`).
   - Analyze native decompilation, registers, inlined instructions, and calling conventions.
3. **Resolve Subroutines Back (REA -> Symbol Indexer)**:
   - When REA disassembly reveals internal call targets or addresses, run `tools\sym.bat <0xAddress>` to immediately identify the C# method and source line.
4. **Implement Patch (PKCore)**:
   - Implement the verified Harmony patch in `d:\Appz\PKCore\Patches\`.

