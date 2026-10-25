# Nexus Mods Description Format (BBCode Template)

Whenever asked to write or generate a Nexus Mods description for any mod, ALWAYS follow this exact BBCode template, layout, color palette, and structure.

## Template:

```bbcode
[quote][b][color=#e67e22][size=3]📢 A Quick Personal Note & Support Campaign:[/size][/color][/b]
If you enjoy my mods and community restorations, please consider checking out my [url=https://denoffao.me/index.html#donate][b]Personal Update & Support Page[/b][/url]. [/quote]

[b][color=#336699][size=4]<MOD_NAME> (<SUBTITLE_OR_SUMMARY>)[/size][/color][/b]
[i][size=3]A BepInEx 6 (IL2CPP) mod for Suikoden I & II HD Remaster (Steam)[/size][/i]

[b]Download & GitHub Source:[/b] [url=<GITHUB_URL>]<GITHUB_URL>[/url]

--------------------------------------------------------------------------------

[b][size=4]Overview & Background[/size][/b]
<Background, original game context / bug / missing feature, how this mod fixes it in-memory without modifying game files>

--------------------------------------------------------------------------------

[b][size=4]Features[/size][/b]
[list]
[*][b]<Feature Name>:[/b] <Description>[/*]
[*][b]Zero Archive Modding:[/b] Patches directly in memory at runtime. No need to extract, modify, or repack game archives.[/*]
[*][b]Save-Game Safe:[/b] Completely safe to add or remove at any point in an existing save file.[/*]
[/list]

--------------------------------------------------------------------------------

[b][size=130]Requirements[/size][/b]
[list=1]
[*][b]Suikoden I & II HD Remaster[/b] (Steam, 64-bit Windows)[/*]
[*][b]BepInEx 6.0 Unity IL2CPP (x64)[/b]: [url=https://github.com/BepInEx/BepInEx/releases/download/v6.0.0-pre.2/BepInEx-Unity.IL2CPP-win-x64-6.0.0-pre.2.zip]BepInEx-Unity.IL2CPP-win-x64-6.0.0-pre.2.zip[/url][/*]
[/list]

--------------------------------------------------------------------------------

[b][size=130]Installation[/size][/b]

[b]1. Install BepInEx 6 (if you don't already have it):[/b]
[list]
[*]Extract the contents of the BepInEx zip directly into your game's root directory:
[font=Courier New]...\steamapps\common\Suikoden I and II HD Remaster\[/font][/*]
[*]Launch the game once via Steam and quit to desktop (this generates the initial IL2CPP interop files).[/*]
[/list]

[b]2. Install <MOD_NAME>:[/b]
[list]
[*]Download the release zip from GitHub.[/*]
[*]Drag and drop the [font=Courier New]BepInEx[/font] folder directly into your game root directory:[/*]
[/list]
[code]
Suikoden I and II HD Remaster/
├── BepInEx/
│   ├── config/
│   │   └── <config_filename>.cfg (created automatically on first run)
│   └── plugins/
│       └── <PluginDllName>.dll
├── doorstop_config.ini
└── Suikoden I and II HD Remaster.exe[/code]

--------------------------------------------------------------------------------

[b][size=4]Configuration[/size][/b]
After running the game once, you can edit [font=Courier New]BepInEx/config/<config_filename>.cfg[/font]:

[code]
<sample configuration content>[/code]

--------------------------------------------------------------------------------

[b][size=4]Credits[/size][/b]
[list]
[*][b]<Contributor / Original Researcher>:[/b] <Details>[/*]
[*][b]faospark:[/b] Porting to the HD Remaster, IL2CPP in-memory byte patching, and safeguards.[/*]
[*][b]Moogles & Mods Community:[/b] For research, discussions, and keeping Suikoden modding alive![/*]
[/list]
```

