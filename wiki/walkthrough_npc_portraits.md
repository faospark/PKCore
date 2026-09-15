# NPC Portrait System - Full Documentation

## Overview

The NPC Portrait System allows custom portrait injection for NPCs that don't have portraits in the base game, as well as expression switching for existing characters. It features a flexible directory search system, character name mapping, expression variants, DDS (BC1/BC3/BC7) texture acceleration, and automatic game-specific detection.

**Note:** Full support is active for both **Suikoden I** and **Suikoden II**.

---

## Architecture

### Core Components

**1. PortraitVariants.cs** - Portrait discovery and variant management
- Recursively searches ALL folders under `PKCore/Textures/` and `PKCore/00-Mods/`
- Searches both `Portraits/` and `NPCPortraits/` subdirectories
- Handles character name → portrait filename mappings
- Manages expression variants (angry, sad, happy, etc.)
- Supports both `.png` and high-performance pre-compressed `.dds` formats (BC1/BC3/BC7)
- Provides unified API for portrait path resolution

**2. PortraitSystemPatch.cs** - Portrait injection and rendering
- Patches dialogue and message window systems for Suikoden I and Suikoden II
- Loads textures via `AssetLoader` with DDS BC7/BC3/BC1 support
- Creates sprites on-demand with clean aspect ratios
- Handles dialog text replacement and speaker name injection
- Preserves native in-game portraits for Event Viewer and cutscenes: missing custom emotion variants gracefully fall back to original dialogue portraits rather than forcing question mark (`fp_219`) placeholders

---

## Directory Structure & Search Priority

### How It Works

The system searches **recursively** through folders with the following priority:

**Priority Order:**
1. **00-Mods Packages** (highest priority) - `PKCore/00-Mods/<ModName>/Textures/`
2. **GSD1 folders** (medium-high priority) - All folders under `Textures/GSD1/` (Suikoden 1)
3. **GSD2 folders** (medium priority) - All folders under `Textures/GSD2/` (Suikoden 2)
4. **Root folders** (lowest priority) - All folders directly under `Textures/`

### Example Layouts

**Recommended Directory Layout:**
```
PKCore/Textures/
├── GSD1/
│   └── NPCPortraits/          ← Suikoden I portraits (PNG / DDS)
│       ├── Grady.dds
│       ├── Iga.png
│       ├── Rosh.dds
│       └── Durin.png
├── GSD2/
│   └── NPCPortraits/          ← Suikoden II portraits (PNG / DDS)
│       ├── fp_140.dds         ← Luca Blight base portrait (DDS BC7)
│       ├── fp_140_laugh1.dds  ← Luca laughing
│       ├── fp_140_shout.dds   ← Luca shouting
│       ├── fp_140_blood.dds   ← Luca bloodied
│       └── Bonaparte.png
└── NPCPortraits/              ← Shared/fallback portraits
    └── fp_219.png             ← Generic "?" fallback
```

**Key Points:**
- ✅ Supports both `.dds` (BC1, BC3, BC7) and `.png` formats
- ✅ If both `.dds` and `.png` exist for the same name, **DDS takes priority**
- ✅ Nest folders as deep as you want (e.g. `Textures/GSD2/Portraits/Villagers/`)
- ✅ Game-specific isolation is managed via `GSD1/` and `GSD2/` directories

---

## Character Name Mapping

### Purpose
Map character names to portrait filenames, enabling:
- Use of game asset IDs (e.g., `fp_053` for Luc, `fp_140` for Luca)
- Consistent naming across different character references
- Support for characters with multiple names/aliases

### Configuration: `PKCore/Config/PortraitMappings.json`

**Example:**
```json
{
  "Luca": "fp_140",
  "Grady": "fp_grady",
  "Durin": "fp_durin"
}
```

### How It Works

- **Without mapping:** `"Bonaparte"` → searches for `bonaparte.dds` / `bonaparte.png`
- **With mapping:** `"Luca"` → maps to `fp_140` → searches for `fp_140.dds` / `fp_140.png`

---

## Expression Variants

### Purpose
Support multiple emotional expressions for the same character:
- `fp_140_angry.dds`, `fp_140_laugh1.dds`, `fp_140_blood.dds`
- Switch portraits dynamically based on dialogue context

### Configuration: `PKCore/Config/PortraitVariants.json`

**Example (Luca Blight expressions):**
```json
{
  "fp_140": {
    "neutral": "fp_140_neutral.dds",
    "laugh1": "fp_140_laugh1.dds",
    "laugh2": "fp_140_laugh2.dds",
    "troll": "fp_140_troll.dds",
    "shout": "fp_140_shout.dds",
    "blood": "fp_140_blood.dds",
    "bloodfinal": "fp_140_bloodfinal.dds",
    "mad": "fp_140_mad.dds",
    "sneaky": "fp_140_sneaky.dds",
    "disgust1": "fp_140_disgust1.dds"
  }
}
```

### Usage in Speaker Overrides

Use pipe syntax `|` to specify expressions:

**S2SpeakerOverrides.json / S1SpeakerOverrides.json:**
```json
{
  "message:1002160039": "Luca|laugh1",
  "message:1002160048": "Luca|shout",
  "message:1004090030": "Luca|blood",
  "message:1004090048": "Luca|bloodfinal",
  "message:1010100035": "Luca|troll",
  "message:1003300033": "Nash",
  "message:1002070055": "Bonaparte"
}
```

---

## Search Flow & Fallbacks

### Complete Resolution Process

**Example: Loading portrait for `"Luca|blood"`**

1. **Parse expression:** `"Luca|blood"` → character = `"Luca"`, expression = `"blood"`
2. **Map name:** `"Luca"` → `"fp_140"` (via `PortraitMappings.json`)
3. **Try variant:** `"fp_140"` + `"blood"` → `"fp_140_blood.dds"` / `fp_140_blood.png` (via `PortraitVariants.json`)
4. **Search directories (priority order):**
   - 00-Mods packages
   - GSD1 folders (for S1)
   - GSD2 folders (for S2)
   - Root `Textures/` folders
5. **If variant not found:** Fall back to default `fp_140.dds` / `fp_140.png`
6. **If default not found:** Fall back to native game portrait (preserves cutscene and Event Viewer expressions)
7. **If no native portrait:** Fall back to `fp_219.png` (question mark)

---

## Integration with Dialog System

### Speaker Overrides
Configured in `PKCore/Config/S1SpeakerOverrides.json` (Suikoden 1) and `PKCore/Config/S2SpeakerOverrides.json` (Suikoden 2):
```json
{
  "message:1002160039": "Luca|laugh1",
  "message:1004090030": "Luca|blood",
  "message:1003300033": "Nash",
  "message:1002070055": "Bonaparte"
}
```

### Dialog Text Overrides
Configured in `PKCore/Config/DialogOverrides.json`:
```json
{
  "_comment": "Dialog text replacement by ID. Enable LogTextIDs in config to discover IDs.",
  "add_message:1120": "©2026 Konami Digital Entertainment",
  "message:1002070055": "Piip!",
  "message:1002070058": "GWHAAACK!!!!"
}
```

---

## Save Slot Party Member Portraits

PKCore also extends portrait rendering to the **Save / Load screen** (`ShowSaveSlotPartyPortraits = true`):
- Displays high-resolution mini portraits next to character levels (`Txt_Lv`) in save/load slots.
- Fully integrated for both Suikoden I (`UISaveLoad1`) and Suikoden II (`UISaveLoad2`).
- Automatically resolves character IDs and Face IDs with 0ms in-memory cache lookups.

---

## Diagnostics & Troubleshooting

1. **Find Dialogue Message IDs**: Enable `LogTextIDs = true` in `BepInEx/config/faospark.pkcore.cfg`.
2. **Dump Dialogue Database**: Enable `DumpTextDatabase = true` to generate cumulative JSON dumps in `PKCore/Debug/TextDB_GSD1.json` and `TextDB_GSD2.json`.
3. **Check Console Output**:
   ```
   [PortraitSystem] Found: GSD2/NPCPortraits/fp_140_blood.dds
   [PortraitVariants] Using variant: Luca (blood) -> fp_140_blood.dds
   ```
