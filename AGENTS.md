# PKCore Workspace Instructions

## Environment & Build
- **Symlink Setup**: The build output directory is symlinked directly to the game's BepInEx plugins directory (`d:\SteamLibrary\steamapps\common\Suikoden I and II HD Remaster\BepInEx\plugins\`).
- **NEVER** run manual `Copy-Item` or file copy commands to the game folder. Running `dotnet build` is sufficient.

## Grounding
- Always ground game mechanics, methods, fields, and data in the local decompiled source code across the following workspaces:
  - **Suikoden I**: `d:\Appz\Suisource\GSD1` (`d:\Appz\Suisource\GSD1\GSD1`)
  - **Suikoden II**: `d:\Appz\Suisource\GSD2` (`d:\Appz\Suisource\GSD2\GSD2`)
  - **Shared / Engine Core**: `d:\Appz\Suisource\GSDShare` (`d:\Appz\Suisource\GSDShare\GSDShare`)

## Logging & Diagnostics
- **Game & BepInEx Logs**: The active log file is located at `d:\SteamLibrary\steamapps\common\Suikoden I and II HD Remaster\BepInEx\LogOutput.log`. Check this log directly for runtime diagnostics, text message IDs, character slot IDs, and errors.
