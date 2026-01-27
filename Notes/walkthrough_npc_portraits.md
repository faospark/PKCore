# NPCPortraits Folder Structure Update

## Summary

Restructured the NPCPortraits folder system to match the existing `CustomTexturePatch` pattern, making it consistent with the rest of the texture system.

---

## ❌ Old Structure (Inconsistent)

```
PKCore/Textures/
├── GSD1/                    ← Game-specific textures
│   └── (other textures)
├── GSD2/                    ← Game-specific textures
│   └── (other textures)
└── NPCPortraits/            ← Portraits had their own structure
    ├── GSD1/                ← INCONSISTENT!
    │   └── viktor.png
    └── GSD2/
        └── nanami.png
```

**Problem:** NPCPortraits used a different folder hierarchy than the main texture system.

---

## ✅ New Structure (Consistent)

```
PKCore/Textures/
├── GSD1/
│   ├── NPCPortraits/        ← S1 portraits here
│   │   ├── viktor.png
│   │   └── shu.png
│   └── (other S1 textures)
│
├── GSD2/
│   ├── NPCPortraits/        ← S2 portraits here
│   │   ├── viktor.png
│   │   └── nanami.png
│   └── (other S2 textures)
│
└── NPCPortraits/            ← Shared portraits (fallback)
    └── flik.png
```

**Benefits:**

- ✅ Matches `CustomTexturePatch` structure
- ✅ Intuitive - all GSD1 content in one place
- ✅ Easy to manage - game-specific folders are self-contained

---

## How It Works

### Priority System

When loading a portrait, the system checks in this order:

1. **Game-specific folder** (highest priority)
   - Suikoden 1: `PKCore/Textures/GSD1/NPCPortraits/shu.png`
   - Suikoden 2: `PKCore/Textures/GSD2/NPCPortraits/nanami.png`

2. **Shared folder** (fallback)
   - Both games: `PKCore/Textures/NPCPortraits/flik.png`

### Examples

**Example 1: Game-specific portraits**

```
GSD1/NPCPortraits/viktor.png  ← Young Viktor (S1)
GSD2/NPCPortraits/viktor.png  ← Older Viktor (S2)
```

Result: Each game gets its own version

**Example 2: Shared portrait**

```
NPCPortraits/flik.png  ← Same in both games
```

Result: Both games use the same portrait

**Example 3: Mixed**

```
GSD1/NPCPortraits/shu.png     ← Only in S1
GSD2/NPCPortraits/nanami.png  ← Only in S2
NPCPortraits/flik.png         ← Shared
```

---

## Files Changed

### [NPCPortraitPatch.cs](file:///d:/Appz/PKCore/Patches/NPCPortraitPatch.cs)

**1. Initialize() - Creates consistent folder structure**

```csharp
// Old: PKCore/Textures/NPCPortraits/GSD1/
// New: PKCore/Textures/GSD1/NPCPortraits/

string gsd1PortraitsPath = Path.Combine(texturesPath, "GSD1", "NPCPortraits");
string gsd2PortraitsPath = Path.Combine(texturesPath, "GSD2", "NPCPortraits");
```

**2. PreloadPortraits() - Scans game-specific folders first**

```csharp
// 1. Scan GSD1/NPCPortraits/ or GSD2/NPCPortraits/ (priority)
// 2. Scan NPCPortraits/ (fallback)
```

**3. LoadPortraitTexture() - Checks game-specific paths**

```csharp
// Try: GSD1/NPCPortraits/shu.png
// Fallback: NPCPortraits/shu.png
```

---

## Migration Guide

If you have existing portraits, move them:

**From:**

```
PKCore/Textures/NPCPortraits/GSD1/shu.png
PKCore/Textures/NPCPortraits/GSD2/nanami.png
```

**To:**

```
PKCore/Textures/GSD1/NPCPortraits/shu.png
PKCore/Textures/GSD2/NPCPortraits/nanami.png
```

The system will automatically create the new folders on first run.

---

## Testing

1. Place a portrait in `GSD1/NPCPortraits/shu.png`
2. Launch Suikoden 1
3. Check logs for: `"Using GSD1 portrait: shu"`
4. Verify portrait appears in-game

Build successful - ready to test!
