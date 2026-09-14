# PKCore Workspace Instructions

## Environment & Build
- **Symlink Setup**: The build output directory is symlinked directly to the game's BepInEx plugins directory (`d:\SteamLibrary\steamapps\common\Suikoden I and II HD Remaster\BepInEx\plugins\`).
- **NEVER** run manual `Copy-Item` or file copy commands to the game folder. Running `dotnet build` is sufficient.

## Grounding
- Always ground game mechanics, methods, fields, and data in the local decompiled source code at `d:\Appz\Suisource\GSD2\GSD2`.
