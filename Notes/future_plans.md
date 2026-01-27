# PKCore - Future Plans & Enhancements

This document tracks planned features and improvements that require further investigation or implementation.

---

## 🎭 NPC Portrait System Enhancements

### Suikoden 1 NPC Portrait Support

**Status:** ⚠️ Blocked - Requires Investigation

**Problem:**

- Suikoden 1 has a very limited set of hardcoded NPC names
- Unlike Suikoden 2, S1 doesn't use `<speaker:>` tags in dialog text
- `UIMessageWindow.speakerName` is empty for NPCs without base game portraits
- Current `SpeakerOverrides.json` system doesn't work for S1

**Potential Solutions:**

1. **dnSpy Investigation** (Recommended)
   - Investigate `UIMessageWindow` class in Suikoden 1
   - Find where speaker names are set (or should be set)
   - Identify the dialog text ID → speaker name mapping
   - Patch the appropriate method to inject speaker names

2. **Dialog Text Parsing**
   - Parse the dialog text itself to extract speaker information
   - Use pattern matching or NLP to identify speakers
   - Map common phrases to character names

3. **Manual Mapping System**
   - Create `S1_DialogToSpeaker.json` mapping dialog IDs to speaker names
   - Requires manual curation of dialog entries
   - Labor-intensive but guaranteed accuracy

4. **Hybrid Approach**
   - Use `TextDatabasePatch` to track dialog IDs
   - Cross-reference with `SpeakerOverrides.json`
   - Inject speaker name into `UIMessageWindow` before portrait rendering

**Next Steps:**

- [ ] Use dnSpy to examine `UIMessageWindow` in Suikoden 1
- [ ] Identify how the game determines which portrait to show
- [ ] Find the method that sets `speakerName` field
- [ ] Implement a Harmony patch to inject custom speaker names

**Files to Investigate:**

- `ShareUI.UIMessageWindow` - Main dialog window class
- `TextMasterData.GetSystemText` - Text retrieval system
- Any classes related to dialog/message display in S1

---

## 🎨 Custom Object & NPC Insertion System

### Suikoden 2 Custom Objects

**Status:** 📋 Planned

**Goal:**
Enable insertion of custom objects and NPCs into Suikoden 2 scenes.

**Potential Features:**

1. **Custom NPC Spawning**
   - Define NPC spawn points via JSON config
   - Specify NPC model, position, rotation, scale
   - Assign custom portraits and dialog
   - Support for custom animations

2. **Custom Object Placement**
   - Place decorative objects in scenes
   - Support for custom 3D models
   - Collision detection configuration
   - Interactive objects (treasure chests, doors, etc.)

3. **Scene Modification System**
   - JSON-based scene definition files
   - Per-scene object/NPC lists
   - Position/rotation/scale overrides
   - Layer and rendering order control

**Configuration Structure (Draft):**

```json
{
  "SceneID": "map_001",
  "CustomObjects": [
    {
      "Type": "NPC",
      "ModelName": "custom_merchant",
      "Position": { "x": 10.5, "y": 0, "z": 5.2 },
      "Rotation": { "x": 0, "y": 90, "z": 0 },
      "Scale": { "x": 1, "y": 1, "z": 1 },
      "Portrait": "merchant_custom",
      "Dialog": "message:custom_001"
    },
    {
      "Type": "Object",
      "ModelName": "custom_statue",
      "Position": { "x": 15, "y": 0, "z": 10 },
      "Texture": "statue_gold.png"
    }
  ]
}
```

**Technical Requirements:**

- [ ] Scene loading hook (Harmony patch on scene load)
- [ ] GameObject instantiation system
- [ ] Custom model loading (AssetBundle or runtime mesh creation)
- [ ] NPC behavior scripting system
- [ ] Dialog integration with existing TextDatabase
- [ ] Collision and physics setup

**Challenges:**

- Finding the right scene loading hook
- Understanding the game's NPC behavior system
- Ensuring custom objects persist across scene transitions
- Performance impact of runtime object creation

**Next Steps:**

- [ ] Research scene loading in Suikoden 2
- [ ] Identify NPC spawning methods
- [ ] Create proof-of-concept for simple object placement
- [ ] Design JSON configuration format
- [ ] Implement basic object spawning system

---

## 📝 Notes

### Investigation Tools

- **dnSpy** - .NET decompiler for examining game code
- **Unity Explorer** - Runtime inspection of Unity objects
- **Harmony** - Runtime patching framework

### Related Systems

- `CustomTexturePatch` - Texture replacement system
- `NPCPortraitPatch` - Portrait injection system
- `TextDatabasePatch` - Dialog text override system

### Priority

1. **High:** Suikoden 1 NPC portraits (blocking user workflow)
2. **Medium:** Custom object insertion (enhancement)
3. **Low:** Advanced NPC behavior scripting

---

## 🔄 Update Log

- **2026-01-28:** Created future plans document
  - Added Suikoden 1 NPC portrait investigation task
  - Added custom object/NPC insertion system proposal
