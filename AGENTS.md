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
- **Pre-Extracted Symbols & IL2CPP Metadata Storage**:
  - The repository has already dumped and collated all IL2CPP symbols and metadata:
    - `d:\Appz\Suisource\Il2CppDump\symbols.txt` (and `GSD2\GSD2\symbols.txt`): 189,523 native function addresses with exact signatures.
    - `d:\Appz\Suisource\Il2CppDump\script.json`: Complete metadata dump (types, methods, strings, RVAs).
    - `d:\Appz\Suisource\Il2CppDump\il2cpp.h`: 42 MB of C headers defining all structs, classes, and native layout offsets.
    - `tools\symbol_indexer\symbols.db`: SQLite database indexing all 189k symbols, 6,147 types, and 259,139 members for sub-millisecond retrieval.
  - **NEVER attempt full Ghidra decompiler runs on `GameAssembly.dll`**: Full headless decompile times out and hangs because the 63 MB binary is too massive. All symbols and addresses are ALREADY known and indexed!
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

## Canonical Map & Entity Grounding Reference
- **Raw Dumped Map Assets**: `D:\Modding\suikodum\Mobobehaviour` contains the dumped JSON for EVERY location in the game (e.g., `vd17.json`, `vd17_map_00.json`, `vg13.json`, etc.). Always refer here for raw map JSONs.
- **Dedicated Area Catalogs**: `PKCore\Documentation\areas\` contains 62 dedicated geographic area breakdown documents cataloging all 4,901 NPCs, props, coordinates, `otyp`, `fpno`, and trigger bytecodes (e.g. `Documentation\areas\south_window_city.md`, `crom_village.md`, etc.). Always consult these first for exact object slots, coordinates, and sprite IDs!

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

## Codebase Knowledge Graph (Graphify)
- **PKCore Knowledge Graph (`graphify-out/`)**:
  - The workspace codebase and documentation are indexed into a local knowledge graph in `graphify-out/` using `graphify`.
  - **How to Use It**:
    - **Explain a class/component**:
      ```powershell
      graphify explain "plugin_pkcore_plugin"
      ```
    - **Find relationships & paths between systems**:
      ```powershell
      graphify path "ModConfiguration" "Plugin"
      ```
    - **Query the graph**:
      ```powershell
      graphify query "<question>"
      ```
    - **Keep it updated**:
      After modifying code in the workspace, run `graphify update .` to sync the graph with AST changes.

## Game Architecture & Direct Reference Blueprints
- **Suikoden I (GSD1) & Suikoden II (GSD2) Discrepancies**:
  - Always check game-specific namespaces and aliases:
    - `GSD1` uses `extern alias GSD1;` (types under `GSD1::` like `h_monsyo_c`, `h_omise_c`, `Village_c`, `Event_c`, `D_azukar_c`, `OldSrcBase`).
    - `GSD2` uses `extern alias GSD2;` (types under `GSD2::` like `MACHICON`, `G2_SYS`, `G2_PAD`, `s_phase`).
  - **Game Detection**: Use `Plugin.CurrentGame` or `GameDetection.CurrentGame` (`GameType.Suikoden1` vs `GameType.Suikoden2`) to guard patches when a hook applies universally or dynamically.

## Direct Fast-Disassembly (Zero Slow Decompilers)
- **Do NOT run heavy headless Ghidra runs or wait on multi-minute REA decompiler timeouts**:
  - Full decompilation of 63 MB `GameAssembly.dll` times out.
  - To inspect native assembly logic for ANY function in <100ms:
    1. Resolve the address with `tools\sym.bat <Symbol>` (e.g. `0x18123c300`).
    2. Convert Virtual Address (VA) to file offset:
       `FileOffset = (VA - 0x180000000) - 0x003af000 + 0x003adc00`.
    3. Use Python + Capstone (installed in the environment) to instantly disassemble the exact instructions:
       ```powershell
       python -c "import capstone; md=capstone.Cs(capstone.CS_ARCH_X86,capstone.CS_MODE_64); f=open(r'D:\SteamLibrary\steamapps\common\Suikoden I and II HD Remaster\GameAssembly.dll','rb'); f.seek(file_offset); print('\n'.join(f'0x{i.address:x}: {i.mnemonic} {i.op_str}' for i in md.disasm(f.read(256), va)))"
       ```
    4. Pass any sub-procedure call addresses back into `tools\sym.bat <0xAddress>` for instantaneous symbol naming.

## Standard Harmony Patch Lifecycle & Patterns
1. **Map Change Hooking**:
   - S1: Hook `MACHICON_OnMapInitPatch.CurrentMapId` or `G1_fdata_c` / map load events. Avoid hooking per-frame step routines like `Village_c.village_main` for map transitions!
   - S2: Hook `MACHICON.EventInit` (`[HarmonyPostfix]`) to intercept map load, or inspect `MACHICON_OnMapInitPatch.CurrentMapId`.
2. **Menu & Window Expansion**:
   - Menu message arrays in IL2CPP must be instantiated as `new Il2CppStructArray<int>(count)` or `Il2CppReferenceArray`.
   - Cursor boundaries: Native scroll handlers clamp to `max`. Prefix the cursor function (`window_cursor_updown`) to expand `ref int max` to match the new choice count.
   - Input polling: Poll native pad with `Pad.PadRRead()` (S1) or `G2_PAD.PadRRead()` (S2) checking `P1_OK` / `P1_CANCEL`.
3. **Execution & Build Discipline**:
   - Modify the patch in `PKCore/Patches/`.
   - Run `dotnet build -c Release` (or `dotnet build`).
   - Check `d:\SteamLibrary\steamapps\common\Suikoden I and II HD Remaster\BepInEx\LogOutput.log` for runtime output.
   - Update `CHANGELOG.md` and `README.md`.

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

## Nexus Mods Description Template (BBCode)
- Whenever requested to write a Nexus Mods description, always use the standardized BBCode pattern documented in `.agents/rules/nexusmods_template.md`:
  - Support Campaign banner header (`[quote][b][color=#e67e22][size=3]📢 A Quick Personal Note & Support Campaign:[/size][/color][/b]...[/quote]`).
  - Title colored with `[b][color=#336699][size=4]...[/size][/color][/b]`, subtitle in `[i][size=3]...[/size][/i]`, and GitHub link.
  - Divider lines: `--------------------------------------------------------------------------------`.
  - Sections: `Overview & Background`, `Features`, `Requirements` (`[size=130]`), `Installation` (`[size=130]`), `Configuration`, and `Credits`.
  - BBCode tags (`[list]`, `[*]...[/*]`, `[font=Courier New]`, `[code]...[/code]`).
  - Standard credits acknowledging original researchers, `faospark`, and the `Moogles & Mods Community`.

## Strict Scope Discipline & Zero Hallucinated Features (Anti-Overengineering)
- **Zero Unilateral Feature Splitting or Scope Creep**:
  - Never invent, split, decouple, or add extra configuration options or architecture variations that the user did not explicitly request (e.g., splitting a unified auto-battle feature into separate memory and persistence toggles).
  - One requested feature must remain **ONE single, unified implementation**.
  - Do not fantasize edge cases or unilaterally create secondary toggles/flags that undermine or reset the feature's expected baseline behavior (e.g., adding an unasked-for `PlayerInit` wipe hook).
- **Strict File & Subsystem Boundaries (Zero Unrelated File Edits)**:
  - When implementing or updating a feature for a specific subsystem (e.g., the Dear ImGui overlay in `ImGuiOverlayUI.cs`), do **NOT** modify or add fields to unrelated files or systems (such as `CustomObjectInsertion.cs`, map object injection, or entity loaders).
  - Use existing cached data and properties (`MACHICON_OnMapInitPatch.CurrentMapId`, etc.) and keep all UI, caching, and input handling localized strictly within the component itself.
- **Zero Over-Research on Straightforward Features**:
  - When a task requests a routine, well-understood edit in our own project files (such as adding a HUD widget, a menu toggle, or a config entry), do **NOT** launch exploratory greps, multi-slice file reads, or treat it as an unknown binary mystery.
  - Target the exact known file and function immediately, apply the edit cleanly, and run `dotnet build`.
- **Immediate Accountability & No Evasion**:
  - If the user questions a decision, catches a regression, or calls out unrequested changes, **STOP all background tool executions immediately**.
  - Never fire off silent background searches, log inspections, or evasive tool calls to cover tracks or stall.
  - Directly, plainly, and immediately acknowledge what was done, own the mistake, and apply the exact fix requested without further debate or side-tangents.

## Planning & User Alignment
- **Course of Action & User Approval**:
  - Always outline a clear plan / course of action before starting work on complex tasks, refactors, or new features.
  - Present the proposed steps directly to the user and ask how they would like to proceed before modifying code or executing changes.
