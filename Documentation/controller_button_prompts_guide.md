# Controller Button Prompts Reference — PKCore

> Originally documented in the standalone `PKButtonPrompts` plugin, now built directly into **PKCore** (`PKCore.Patches.GlobalControllerPromptPatch`).

PKCore overrides controller button prompt icons globally across menus, dialogue boxes, tutorials, and minigames in **Suikoden I & II HD Remaster**, including restoring distinct 4-button prompts in minigames like Hai Yo's Cook-Off (where Xbox defaults to a single generic sprite `UI_MiniGame_Icon05_001_00`).

---

## Configuration (`BepInEx/config/faospark.pkcore.cfg`)

```ini
[02 User Interface]
EnableButtonPrompts = true           # Enable controller button prompt overrides across the game
ControllerPromptType = PlayStation   # PlayStation | PlayStation 5 | Xbox | Switch | Custom | Generic
```

---

## Supported Controller Layouts

| Profile Name | Suffix | Supported Hardware / Style | Description |
| :--- | :---: | :--- | :--- |
| **`PlayStation`** | `_01` | DualShock 4, DualShock 3 | Classic colored Square, Triangle, Circle, Cross icons. |
| **`PlayStation 5`** | `_02` | DualSense, DualSense Edge | Modern monochrome PS5 button icons. |
| **`Xbox`** | `_03` | Xbox Series X\|S, Xbox One, Xbox 360 | Standard green A, red B, blue X, yellow Y icons. |
| **`Switch`** | `_04` | Switch Pro Controller, Joy-Cons | Nintendo button layout with swapped confirm/cancel placement. |
| **`Custom`** | `_05` | Custom community texture packs | Dedicated custom prompt slot for user-designed HUD themes. |
| **`Generic`** | `_00` | PC / Keyboard / Default | Default game prompts without modification. |

---

## Texture Resolution & Directory Hierarchy

`GlobalControllerPromptPatch` (`Patches/GlobalControllerPromptPatch.cs`) hooks Unity UI `Image.sprite` setter calls, checks internal Unity `Resources` first, and recursively indexes `.png` files across the following directories in priority order:

1. `<AssemblyLocation>/Textures/` *(local to `PKCore.dll`)*
2. `BepInEx/plugins/PKButtonPrompts/Textures/` *(legacy standalone fallback)*
3. `BepInEx/plugins/PKButtonPrompts/` *(legacy standalone fallback)*
4. `<GameRoot>/PKButtonPrompts/Textures/` *(legacy standalone fallback)*
5. `<GameRoot>/PKCore/Textures/buttons/` *(Project Kyaro pack path)*
6. `<GameRoot>/PKCore/Textures/` *(Project Kyaro root fallback)*

### Bundled Asset Organization

```text
Textures/
└── buttons/
    ├── switch/  (15 PNGs: button2_icon_e/f/g_04, UI_MiniGame_Icon05-17_04, UI_Tips_Icon01-04_04)
    └── xbox/    (15 PNGs: button2_icon_e/f/g_03, UI_MiniGame_Icon05-17_03, UI_Tips_Icon01-04_03)
```

Any subfolder organization within these directories is indexed automatically by filename (without extension).
