# Adding Custom NPC Portraits

This guide explains how to add custom portraits for NPCs in dialogue windows.

## Quick Start

### 1. Folder Location
```
BepInEx/plugins/PKCore/NPCPortraits/
```
The folder is created automatically when you launch the game.

### 2. Add Portrait Files

1. **Prepare PNG images** (any size, 512x512+ recommended)
2. **Name files after NPCs** - Use the exact NPC name as shown in dialogue
   - Examples: `Viktor.png`, `Flik.png`, `Nanami.png`
   - Case-insensitive: `viktor.png` works too
3. **Place files** in the `NPCPortraits/` folder
4. **Restart the game** (portraits are loaded at startup)

### 3. Verify in Console

Check BepInEx console for:
```
[Info   : PKCore] Loaded portrait: Viktor
[Info   : PKCore] Preloaded 2 custom NPC portrait(s)
```

When NPC speaks:
```
[Info   : PKCore] Injected custom portrait for: Viktor
```

## How It Works

- **Only injects when NPC has no portrait** - Won't replace existing portraits
- **Case-insensitive matching** - `viktor.png` matches "Viktor" in dialogue
- **Preloaded at startup** - All portraits cached for performance

## Configuration

Edit `BepInEx/config/faospark.pkcore.cfg`:

```ini
[NPC Portraits]
EnableNPCPortraits = true
```

## Finding NPC Names

1. Talk to NPCs in-game
2. Check BepInEx console for speaker names
3. Name your PNG file exactly as shown (case-insensitive)

## Troubleshooting

**Portrait not showing?**
- Check file name matches NPC name exactly
- Verify PNG file is not corrupted
- Ensure feature is enabled in config
- NPC might already have a portrait (system won't override)

**Can't find NPCPortraits folder?**
- Launch game once to create it
- Check console for full path

## Example

```
NPCPortraits/
├── Viktor.png
├── Flik.png
└── Merchant.png
```

Result: These portraits appear when NPCs speak (if they don't already have portraits).
