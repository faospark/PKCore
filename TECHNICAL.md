# Technical Reference — PKCore

## Texture Replacement Guide

Place custom `PNG`, `JPG`, `TGA`, or `DDS` files in `BepInEx/plugins/PKCore/Textures/`:
- **Mod Priority**: Use the `00-Mods/` subfolder for highest-priority custom overrides.
- **Performance Optimization**: DDS format supports pre-compressed **BC1**, **BC3**, and **BC7** (with DX10 headers) for reduced VRAM usage and faster loading.

---

## Built-In Systems

- **Battle & Combat Patches (S1 & S2)**: Battle HUD (Max HP, Enemy Level/HP), Memory Auto-Battle, Smart After-Battle Healing, Battle Position Spacing, Battle Camera Zoom-Out, Command Rune reuse/unbalance fixes, Bright Shield Rune enhancements, and Character Range overrides. See [Battle & Combat Patches Reference](Documentation/battle_and_combat_patches.md) and [Suikoden II Character Battle Ranges](Documentation/suikoden_2_character_battle_ranges.md).
- **Controller Button Prompts (S1 & S2)**: Runtime `Image.sprite` override supporting PlayStation (DS4), PlayStation 5 (DualSense), Xbox, Switch, Custom, and Generic layouts with bundled & custom PNG fallback paths. See [Controller Button Prompts Reference](Documentation/controller_button_prompts_guide.md).
- **Infinite Cook-Off Minigame Loop & Cooldown Reduction (S2)**: Restarts Hai Yo's cook-off battles from Chef Antonio (Match 1) after defeating final chef Jinkai and viewing the garden cutscene, preserving all recipes, seasonings, and bonuses. `ReduceCookOffCooldown` bypasses the vanilla 30–60 minute active movement cooldown between matches.
- **War Battle Modding & Formation Menu Synchronization (S2)**: Customize character stats, tactical abilities, and subunit bonuses via `PKCore/Config/S2WarAbilities.json`, synchronized live into active combat and Apple's squad formation roster (`w_dat_butai.chara_butai`). See [War Battle Modding Guide](Documentation/war_battle_modding.md).
- **Floating Borderless Window Mode (`EnableBorderlessWindow`)**: Strips Win32 window chrome (`WS_CAPTION`, `WS_THICKFRAME`, `WS_SYSMENU`, `WS_MINIMIZEBOX`, `WS_MAXIMIZEBOX`) via `SetWindowLong` / `SetWindowPos` while staying in `FullScreenMode.Windowed` for custom smaller borderless windows. For fullscreen borderless at native desktop resolution, use Unity's `-popupwindow` launch option.
- **NPC Portraits & Placeholder Text Replacement**: Inject custom high-resolution portraits with variant support and automatic replacement of protagonist and HQ name placeholders. See [Dialog Text Placeholders Guide](Documentation/dialog_text_placeholders.md).
- **High-Speed Decompiled Symbol & Map Indexer**: Sub-millisecond lookup tool for C# classes, methods, fields, native IL2CPP memory addresses, and all 360 maps (`tools\sym.bat <Query>`, `tools\sym.bat --maps <MapID>`). See [Symbol Indexer Guide](Documentation/symbol_indexer_guide.md).

---

## Reference Guides & Catalogs

- **Suikoden I Map Identifiers & Regional Breakdown**: All 12 regional sectors (`area_a`–`area_k`, `area_z`), 85 background map assets (`bg_va1`–`bg_vz5`), decompiled handlers, and 70+ `EVENT_COMMAND` opcodes. See [Suikoden 1 Map Guide](Documentation/suikoden_1_map_ids_and_areas_breakdown.md).
- **Suikoden II Map Identifiers & Geographic Areas**: Exhaustive breakdown of all 4-character map IDs (`va01`–`vk37`), story chapters, text keys, and patches. See [Map Identifiers Guide](Documentation/suikoden_2_map_ids_and_areas_breakdown.md).
- **Suikoden II Master Map Entities, Triggers & World Objects Catalog**: Census across all 226 master map assets (4,901 NPCs, 1,552 dynamic props, 3,207 triggers, 90 save points, 27 chest clusters, and 147 `EC*` opcodes). See [Master Map Entities Guide](Documentation/suikoden_2_master_map_entities_and_triggers_catalog.md).
- **Individual Geographic Area Volumes (62 Areas)**: Standalone documentation files in `Documentation/areas/` with human-readable field legends and decoded event actions.
- **Historical Companion Deep Dives**:
  - [Sajah Village Rare Shop & Rune Sage Unlock](Documentation/sajah_village_rare_shop_vj17.md) (`PKRuneSagePlus`)
  - [Character Attributes, Gender, and Bathhouse Mechanics](Documentation/suikoden_2_character_attributes_gender_and_baths.md) (`PKS2BathNPCPatch`)

---

## Migration Guide (PKextended → PKCore)

If upgrading from **PKextended.dll** or older versions of Project Kyaro:
1. Delete `PKextended.dll` from `BepInEx/plugins/`.
2. Delete legacy `BepInEx/config/faospark.pkextended.cfg`.
3. Delete older Special K files (`dxgi.dll`, `d3d11.dll`, `SK_Res/`), as Special K is no longer used or supported.
4. Launch the game once to generate `BepInEx/config/faospark.pkcore.cfg`, and install any decoupled companion plugins (`PKRuneSagePlus`, `PKRecruitmentPatch`, `PKOpenPaths`, `PKS1CastleStorageAnywhere`, `PKMatildaGlitchRestoration`, `PKS2BathNPCPatch`, `PKTenzanPassPatch`) as needed. Remove legacy standalone `PKReplayPlus.dll`, `PKBattlePatch.dll`, and `PKButtonPrompts.dll` if present, as their features are now built into `PKCore`.
