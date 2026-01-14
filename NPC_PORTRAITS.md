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

- **Only injects when NPC has no portrait** - Won't replace existing portraits (unless using Speaker Override)
- **Case-insensitive matching** - `viktor.png` matches "Viktor" in dialogue
- **Preloaded at startup** - All portraits cached for performance

## Speaker Override (Advanced)

You can force a specific portrait for any line of dialogue by adding a tag to the text.
This works even if the character already has a portrait or if the speaker name is hidden.

**Usage:** Add `<speaker:Name>` at the start of your text. The tag will be hidden in-game.

**Example:**
Text: `<speaker:Viktor>Hey, this is a custom line!`
Result: Shows **Viktor's portrait**, speaker name becomes "Viktor", and text shows "Hey, this is a custom line!"

This is useful for:
- generic NPCs (Soldier -> `<speaker:Soldier_A>`)
- changing expressions (`<speaker:Viktor_Angry>`)
- overriding existing portraits





## Dialog Text Replacement (Configuration File)

To avoid editing text in tools or hex editors, you can use the `DialogOverrides.json` file.
This allows you to replace any dialog line, either by **matching the exact text** or by **using the internal ID**.

### 1. Key Matching Options

**A. By Text (Simplest)**
Copy the exact text you see in-game. Matches case-insensitive (trimmed).
```json
"Original text in game": "<speaker:Name>New text to display"
```

**B. By ID (Most Precise & Reliable)**
Target a specific line ID. This works even for nameless NPCs or identical texts.
To find the ID, enable `LogTextIDs` in the config, run the game, and check the console.
Format: `text_id:index`
```json
"sys_01:5": "<speaker:Hero>Welcome to our base!"
```

### 2. Configuration File

### 2. Configuration File

**Location:** `PKCore/Config/DialogOverrides.json`
*The file is created automatically on first run if it doesn't exist.*

**Example:**
```json
{
  "Hello there!": "<speaker:Sephiroth>Hello there!",
  "sys_23:14": "<speaker:Viktor>This line is targeted by ID!"
}
```

### 3. Finding Text IDs

1. Open `BepInEx/config/faospark.pkcore.cfg`
2. Set `LogTextIDs = true`
3. Launch game and trigger the dialog
4. Check `BepInEx/LogOutput.log` for `[TextDebug]` entries
5. Use the ID you see (e.g. `sys_01:5`) as the key in your JSON file



## Speaker Name Injection (Advanced)

If you only want to **Add a Name** (and portrait) to a nameless NPC or line *without modifying the text itself*, use `SpeakerOverrides.json`.

**Why use this?**
- Compatible with translation mods (like SuikodenFix): it keeps their text fixes but adds your custom portrait/name.
- Easier to maintain: you don't need to copy/paste long dialog texts.

**Location:** `PKCore/Config/SpeakerOverrides.json`

**Format:** `ID:Index` -> `Speaker Name`
**Format:** `ID:Start-End` -> `Speaker Name` (Range Support)

```json
{
  "sys_01:5": "Guard",
  "sys_01:10-20": "Villager A",
  "message:100-200": "Soldier"
}
```

**Features:**
- **Single ID:** Targets one specific line.
- **Range:** Automatically expands to cover all IDs between Start and End (inclusive).
- **Limit:** Ranges are limited to 5000 IDs to prevent performance issues.

**Result:**
The game will display "Guard" as the speaker name and load `Guard.png` for the portrait. The text content remains untouched (or fixed by other mods).

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
