# Suikoden 2 Dialog Text Placeholders Guide

This document serves as a reference for the special text placeholders and formatting characters used natively in Suikoden 2's dialog files.

## Support Placeholders

### Character and Location Name Placeholders

These special string sequences are used in the game's text to dynamically insert names based on the player's current save data.

| Placeholder | Replaced With | Example |
|-------------|---------------|---------|
| `♂㈱` | Suikoden 2 protagonist name | "Riou" |
| `♂⑩` | Suikoden 1 protagonist name (save transfer) | "Tir" |
| `♂①` | Suikoden 2 HQ name | "Dunan" |
| `♂②` | Suikoden 2 HQ name (alternate) | "Dunan" |
| `♂■` | Suikoden 1 HQ name (save transfer) | "Rocklake" |

### Native Text Formatting

The game uses several special characters to format how dialog text is displayed on screen:

| Character | Function | Usage |
|-----------|----------|-------|
| `∠` | Line break | Forces text to continue on the next line within the dialog box |
| `∨` | Page break | Pauses text rendering and waits for player input before continuing |
| `◎` | Choice line | Marks a line where a user input/choice is presented |

## Examples of Usage

### Basic Name Replacement

**Original dialog text:**
```text
"Welcome to ♂①, ♂㈱!"
```

**In-game Result:**
```text
"Welcome to Dunan, Riou!"
```

### With Line Breaks

**Original dialog text:**
```text
"♂㈱, welcome to ♂①!∠Your journey begins here."
```

**In-game Result:**
```text
Riou, welcome to Dunan!
Your journey begins here.
```

### With Page Break

**Original dialog text:**
```text
"The result is ∨5 points."
```

**In-game Result:**
```text
The result is [Player presses button]
5 points.
```

### With Choice Lines

**Original dialog text:**
```text
"What will you do?◎ Attack◎ Defend◎ Run"
```

**In-game Result:**
```text
What will you do?
 > Attack
   Defend
   Run
```

> **Note:** These formatting characters are part of the original game's native text format and are handled automatically by the Suikoden 2 engine when rendering dialog boxes.
