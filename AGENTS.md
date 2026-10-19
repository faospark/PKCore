# PKCore Workspace Instructions

## Primary Project
- **PKCore (`d:\Appz\PKCore`) is the main project of this workspace.** All code changes, new files, builds, and fixes target PKCore unless the user explicitly says otherwise.
- The other workspace folders are **read-only references**:
  - `d:\Appz\Suisource\GSD1`, `GSD2`, `GSDShare` — decompiled game source, used only for grounding.
  - `d:\Appz\Suisource\Ideas` — notes/ideas, read for context only.
  - `...\Suikoden I and II HD Remaster\BepInEx` and `...\PKCore` — game install / runtime output (logs, configs, textures). Do not write project code there.
- Never edit decompiled source files; implement behavior changes as Harmony patches in PKCore instead.

## Environment & Build
- **Symlink Setup**: The build output directory is symlinked directly to the game's BepInEx plugins directory (`d:\SteamLibrary\steamapps\common\Suikoden I and II HD Remaster\BepInEx\plugins\`).
- **NEVER** run manual `Copy-Item` or file copy commands to the game folder. Running `dotnet build` is sufficient.

## Grounding & High-Speed Symbol Search Tool
- Always ground game mechanics, methods, fields, and data in the local decompiled source code across the following workspaces:
  - **Suikoden I**: `d:\Appz\Suisource\GSD1` (`d:\Appz\Suisource\GSD1\GSD1`)
  - **Suikoden II**: `d:\Appz\Suisource\GSD2` (`d:\Appz\Suisource\GSD2\GSD2`)
  - **Shared / Engine Core**: `d:\Appz\Suisource\GSDShare` (`d:\Appz\Suisource\GSDShare\GSDShare`)
- **MANDATORY Grounding Tool - High-Speed Symbol Search (`tools\sym.bat`)**:
  - **Always query the local symbol index before doing broad grep searches across Suisource.** Broad greps across 2,282 files are slow and frequently hit limits. The SQLite symbol index contains all 6,147 types, 259,139 members, and 189,523 native IL2CPP addresses and responds in <1ms to 3ms.
  - **Usage**:
    - **Method / Symbol Search**: `tools\sym.bat <SymbolName>` (e.g. `tools\sym.bat EventInit`)
    - **Type-Scoped Member Search**: `tools\sym.bat <TypeName>.<MemberName>` (e.g. `tools\sym.bat MACHICON.mstep`)
    - **Full Class Member Dump**: `tools\sym.bat <TypeName> -m` (e.g. `tools\sym.bat MACHICON -m --methods`)
    - **Native IL2CPP Address Resolution**: `tools\sym.bat <0xAddress>` (e.g. `tools\sym.bat 0x1818bb190` -> resolves native symbol & points directly to C# file and line)
    - **Game Scoping**: `tools\sym.bat --gsd1 <query>`, `tools\sym.bat --gsd2 <query>`, `tools\sym.bat --share <query>`
    - **Structured JSON Mode**: `tools\sym.bat <query> --json`
  - If decompiled sources or `symbols.txt` are updated, rebuild the database with `python tools\symbol_indexer\indexer.py` (~11s build time).

## Synergy with REA (Reverse Engineer Anything)
- **The Symbol Indexer and REA must be used hand-in-hand**:
  - **Phase 1: Fast Anchor & Mapping (Symbol Indexer)**:
    - Begin by querying `tools\sym.bat <query>` to locate target C# classes, methods, fields, and their native IL2CPP addresses in <1ms.
    - When investigating crashes, logs, or native addresses, pass `tools\sym.bat <0xAddress>` to instantly obtain the exact symbol signature and C# decompiled source file and line number.
  - **Phase 2: Deep Binary & Flow Analysis (REA)**:
    - Pass the resolved virtual memory address or symbol into REA disassembler and binary tools (`goto_address`, `procedure_pseudo_code`, `procedure_assembly`, `procedure_callers`, `procedure_callees`, `xrefs`, `inspect_managed_native_boundaries`).
    - Use REA to decompile low-level native logic, analyze control flow, verify calling conventions, and inspect runtime targets.
  - **Phase 3: Cross-Correlation & Cycle Back (REA -> Symbol Indexer)**:
    - When REA disassembly reveals sub-procedure calls, data offsets, or unlabelled jump targets, feed those addresses back into `tools\sym.bat <address>` to instantly map them back to decompiled C# types and members.
  - **Phase 4: Harmony Patch Implementation**:
    - With both high-level C# decompilation and low-level native flow confirmed, implement the final, robust Harmony hook or patch in PKCore.

## Logging & Diagnostics
- **Game & BepInEx Logs**: The active log file is located at `d:\SteamLibrary\steamapps\common\Suikoden I and II HD Remaster\BepInEx\LogOutput.log`. Check this log directly for runtime diagnostics, text message IDs, character slot IDs, and errors.

## Map & Asset Patching Pattern (`MACHICON.EventInit`)
- **Standard Pattern for Map / `<map>.json` Asset Modifications**: Follow the proven pattern established in `SajahShopUnlockPatch.cs` (and `TenzanPassEncounterPatch.cs`).
  - Hook `[HarmonyPatch(typeof(MACHICON), "EventInit")]` as a `[HarmonyPostfix]`.
  - Upon map transition, `EVENTCON __result` holds `__result.mdat` (`MACHIDAT`), which is the deserialized object of the map asset (e.g., `vj17.json`, `va11.json`).
  - Modify `__result.mdat` directly in memory (e.g., `eventdata.mapeventdat`, `eventobj`, `eventdat.eventForm` script byte arrays, `battle_dat`, `monster_party`, etc.).
  - This acts as an in-memory **byte-patching** mechanism for map asset JSON files, eliminating the need for manual UABEA bundle extraction/repacking and making changes immune to official game updates.

## Feature Documentation & Updates (Changelog & README)
- **Always Document Features**: Whenever a new feature is added, or an existing feature/patch is updated or modified:
  - **`CHANGELOG.md`**: Add an entry documenting the addition or update with clear technical details, affected patches, and configuration settings (under the latest/current date section).
  - **`README.md`**: Update the feature list under the appropriate category (e.g., `[Can Be Toggled]`, `[Performance Features]`, `[Baked In]`, or `[Utility]`) to reflect the new or modified functionality.
- **Never Use `file:///` URLs in Markdown (`.md`) Files**:
  - Do not write absolute `file:///` hyperlinks in documentation or changelogs (`CHANGELOG.md`, `README.md`, `Documentation/*.md`).
  - These break in web browsers, GitHub, and markdown viewers.
  - Use relative markdown links (e.g. `[MemoryAutoBattlePatch.cs](Patches/MemoryAutoBattlePatch.cs)`) or plain inline code (e.g. `MemoryAutoBattlePatch.cs`).

## Strict Scope Discipline & Zero Hallucinated Features (Anti-Overengineering)
- **Zero Unilateral Feature Splitting or Scope Creep**:
  - Never invent, split, decouple, or add extra configuration options or architecture variations that the user did not explicitly request (e.g., splitting a unified auto-battle feature into separate memory and persistence toggles).
  - One requested feature must remain **ONE single, unified implementation**.
  - Do not fantasize edge cases or unilaterally create secondary toggles/flags that undermine or reset the feature's expected baseline behavior (e.g., adding an unasked-for `PlayerInit` wipe hook).
- **Immediate Accountability & No Evasion**:
  - If the user questions a decision, catches a regression, or calls out unrequested changes, **STOP all background tool executions immediately**.
  - Never fire off silent background searches, log inspections, or evasive tool calls to cover tracks or stall.
  - Directly, plainly, and immediately acknowledge what was done, own the mistake, and apply the exact fix requested without further debate or side-tangents.


