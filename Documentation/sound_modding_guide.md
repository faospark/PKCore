# Sound Modding Guide

## Overview

PKCore intercepts CriWare's ACB/AWB file loading at runtime and redirects it to your override files before the game ever reads from `StreamingAssets`. This means you can replace any BGM track, sound effect, or ambient loop without modifying any original game file.

---

## Sound File Location (Original Game)

```
<Game Root>\Suikoden I and II HD Remaster_Data\StreamingAssets\Sound\
```

CriWare uses two paired files for every audio asset:

| Extension | Role |
|-----------|------|
| `.acb` | Cue sheet — contains metadata, cue names, and (for small sounds) embedded audio |
| `.awb` | Wave bank — contains the raw audio data for larger/streamed sounds |

Both files share the same base name and must always be replaced together. Replacing only one will cause the game to crash or play silence.

---

## Override Folder Structure

PKCore resolves sound overrides in priority order:

| Priority | Location | Typical use |
|----------|----------|-------------|
| **1 (Lowest)** | `StreamingAssets/Sound/` | Original game files (fallback) |
| **2** | `PKCore/Sound/` | Low-priority base overrides |
| **3 (Highest)** | `PKCore/00-Mods/<ModName>/Sound/` | Packaged mod overrides |

Your override folder must **mirror the original `Sound/` folder structure exactly**, including any subfolders such as `BGM2/` or `SEHD1/`.

```
PKCore/
├── Sound/                         ← Base overrides (low priority)
│   ├── BGM2/
│   │   └── BATTLE1.acb / .awb
│   └── SEHD1/
│       └── SE1.acb
└── 00-Mods/                       ← Packaged mods (highest priority)
    └── My-Sound-Mod/
        └── Sound/
            └── BGM2/
                └── BATTLE1.acb / .awb
```

---

## How to Find the Right File Names

Browse the original game `Sound/` folder to find the track you want to replace:

```
StreamingAssets\Sound\
├── BGM1\        ← Suikoden 1 BGM tracks
├── BGM2\        ← Suikoden 2 BGM tracks
├── SEHD1\       ← Suikoden 1 sound effects
├── SEHD2\       ← Suikoden 2 sound effects
├── GAME_START_ENV.acb
├── GAME_START_ENV.awb
└── ...
```

Use a tool like **Foobar2000 + VGMStream** or **CriAtomCraft** to preview ACB/AWB files before committing to a swap.

---

## Step-by-Step: Replacing a Sound

### 1. Identify source and target

Decide which file you want to **use as audio** (source) and which in-game file you want to **replace** (target).

**Example — replacing the Launcher ambient music with Suikoden 2's Adventure Start BGM:**

| Role | Path | Description |
|------|------|-------------|
| Source audio | `Sound\BGM2\XA_00.acb` / `.awb` | Suikoden 2 — Adventure Start / Character Naming BGM |
| Target (to replace) | `Sound\GAME_START_ENV.acb` / `.awb` | Launcher ambient music |

### 2. Copy and rename the source files

Copy `XA_00.acb` and `XA_00.awb` from the BGM2 folder, then rename both copies to match the target name:

```
XA_00.acb  →  GAME_START_ENV.acb
XA_00.awb  →  GAME_START_ENV.awb
```

> The base name must match exactly (case-insensitive). The `.acb` and `.awb` must always be renamed together.

### 3. Place the renamed files in the override folder

For a **base override** (no mod packaging):

```
PKCore\Sound\GAME_START_ENV.acb
PKCore\Sound\GAME_START_ENV.awb
```

For a **packaged mod** (recommended — see next section):

```
PKCore\00-Mods\Better-Launcher-BGM-Mod\Sound\GAME_START_ENV.acb
PKCore\00-Mods\Better-Launcher-BGM-Mod\Sound\GAME_START_ENV.awb
```

### 4. Launch the game

PKCore will log a confirmation at startup:

```
[SoundRedirect] Mod 'Better-Launcher-BGM-Mod': 1 .acb file(s).
```

And when the track is loaded at runtime:

```
[SoundRedirect] → 'GAME_START_ENV.acb' overridden
```

---

## Packaging as a Mod

Packaging sound replacements inside `00-Mods/` has several advantages:

- Keeps your changes isolated from the base `PKCore/Sound/` folder
- Multiple mods can coexist without conflict
- Mods can be toggled on/off just by renaming or removing the subfolder
- Some mod folders (like `Better-Launcher-BGM-Mod`) have a dedicated PKCore config toggle

### Example: Better-Launcher-BGM-Mod

This sample mod ships the Suikoden 2 opening BGM as a replacement for the Launcher's ambient music.

**Folder layout:**

```
PKCore\
└── 00-Mods\
    └── Better-Launcher-BGM-Mod\
        └── Sound\
            ├── GAME_START_ENV.acb
            └── GAME_START_ENV.awb
```

**PKCore config toggle (`BepInEx\config\PKCore.cfg`):**

```ini
[Sound]
## Replace the Launcher ambient music with the Suikoden 2 Adventure Start BGM.
# Setting type: Boolean
# Default value: true
BetterLauncherBGM = true
```

Setting `BetterLauncherBGM = false` makes PKCore skip this mod folder entirely, falling back to the original Launcher music — no file deletion required.

---

## Tips and Caveats

- **ACB + AWB must always be replaced as a pair.** Mismatched or missing pairs will cause silent playback or a crash.
- **File names are case-insensitive** on Windows, but use the exact original casing to stay cross-platform safe.
- **Subfolder structure matters.** A file at `Sound\BATTLE1.acb` is different from `Sound\BGM2\BATTLE1.acb`.
- **Alphabetically last mod wins** when two mods override the same file. Prefix your personal folder with `zz_` to guarantee it takes priority over everything else.
- **Only `.acb`/`.awb` files are redirected** by this system. Loose `.wav`/`.ogg` files are not supported.
- **Source audio format must be compatible** with CriWare. Re-encoding to HCA or ADX inside a properly structured ACB/AWB is required if you are authoring from scratch. Swapping same-format files (as in the example above) always works.
