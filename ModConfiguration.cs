using BepInEx.Configuration;

namespace PKCore;

public sealed class ModConfiguration
{
    private ConfigFile _config;

    // Sprite Filtering Settings
    public ConfigEntry<bool> SpriteFilteringEnabled { get; private set; }

    // Display Settings
    public ConfigEntry<float> ResolutionScale { get; private set; }

    // Visual Settings
    public ConfigEntry<bool> DisableSpritePostProcessing { get; private set; }
    public ConfigEntry<bool> DisablePortraitDialogMask { get; private set; }

    // Display Settings
    public ConfigEntry<bool> EnableBorderlessWindow { get; private set; }
    public ConfigEntry<bool> ShowMouseCursor { get; private set; }

    // Custom Texture Settings
    public HiddenConfigEntry<bool> EnableCustomTextures { get; private set; }
    public ConfigEntry<bool> DetailedLogs { get; private set; }
    public ConfigEntry<bool> LoadLauncherUITextures { get; private set; }
    public ConfigEntry<bool> EnableProjectKyaroSprites { get; private set; }
    public ConfigEntry<bool> MinimalUI { get; private set; }

    // NPC Portrait & Asset Settings
    public ConfigEntry<bool> LogTextIDs { get; private set; }
    public ConfigEntry<bool> DumpTextDatabase { get; private set; }
    public ConfigEntry<bool> DumpJsonAssets { get; private set; }
    public ConfigEntry<bool> EnableJsonOverrides { get; private set; }
    public ConfigEntry<bool> EnablePortraitSystem { get; private set; }

    // Save Point Settings
    public ConfigEntry<string> SavePointColor { get; private set; }
    public ConfigEntry<string> TirRunTexture { get; private set; }
    public ConfigEntry<bool> DisableSavePointGlow { get; private set; }

    // Suikoden 2 Classic UI Settings
    public ConfigEntry<bool> ClassicSaveWindow { get; private set; }
    public ConfigEntry<bool> ShowSaveSlotPartyPortraits { get; private set; }
    public ConfigEntry<string> MercFortFence { get; private set; }
    public ConfigEntry<bool> ColoredIntroAndFlashbacks { get; private set; }

    // War Ability Mod
    public ConfigEntry<bool> EnableWarAbilityMod { get; private set; }

    // Suikoden 2 Cook-Off Settings
    public ConfigEntry<bool> LoopCookOffMatches { get; private set; }
    public ConfigEntry<bool> ReduceCookOffCooldown { get; private set; }
    public ConfigEntry<bool> ShowCookOffScoreHelper { get; private set; }

    // Suikoden 2 Clive Quest Replay
    public ConfigEntry<bool> LoopCliveQuest { get; private set; }

    // Suikoden 2 Final Boss Gauntlet Replay
    public ConfigEntry<bool> LoopFinalBossGauntlet { get; private set; }
    public ConfigEntry<bool> ResetGauntletOnNextEntry { get; private set; }
    public ConfigEntry<bool> EnableLeonaPostFinalBoss { get; private set; }
    public ConfigEntry<bool> EnableCastleMinigamesPostFinalBoss { get; private set; }

    // Suikoden 2 War Battle Replay Sidequest
    public ConfigEntry<bool> EnableWarReplaySidequest { get; private set; }
    public ConfigEntry<bool> UnlockAllWarReplays { get; private set; }


    // World Map Settings
    public ConfigEntry<bool> DisableWorldMapClouds { get; private set; }
    public ConfigEntry<bool> DisableWorldMapSunrays { get; private set; }

    // Suikoden 1 UI Settings
    public ConfigEntry<bool> S1ScaledDownWorldMap { get; private set; }

    // UI Settings
    public ConfigEntry<bool> ScaleDownDialogBox { get; private set; }
    public ConfigEntry<string> ScaledDownMenu { get; private set; }
    public ConfigEntry<string> SMAAQuality { get; private set; }
    public ConfigEntry<bool> PSPLauncher { get; private set; }
    public ConfigEntry<bool> EnhancedGallery { get; private set; }
    public ConfigEntry<bool> DisableUITips { get; private set; }

    // Sound Settings
    public HiddenConfigEntry<bool> EnableSoundRedirect { get; private set; }
    public ConfigEntry<bool> BetterLauncherBGM { get; private set; }

    // Performance Settings
    public ConfigEntry<bool> EnableTextureManifestCache { get; private set; }
    public ConfigEntry<bool> EnableMemoryCaching { get; private set; }

    // EXPERIMENTAL FEATURES (at end of config file)
    public ConfigEntry<bool> EnableDebugMenu2 { get; private set; }

    // Hidden internal settings - not exposed in config file at all
    // These are hardcoded to false and cannot be changed by users
    // If you need to enable them for development, uncomment the bindings in Init()
    public class HiddenConfigEntry<T>
    {
        private T _value;
        public T Value => _value;
        public HiddenConfigEntry(T defaultValue) { _value = defaultValue; }
    }


    public HiddenConfigEntry<bool> EnableDialogOverrides { get; private set; }
    public HiddenConfigEntry<float> SpriteMipmapBias { get; private set; }
    public ConfigEntry<bool> LogReplaceableTextures { get; private set; }
    public ConfigEntry<bool> EnableTavernDiagnostics { get; private set; }


    public ModConfiguration(ConfigFile config)
    {
        _config = config;
    }

    public void Init()
    {


        EnableProjectKyaroSprites = _config.Bind(
            "01 Project Kyaro Sprites",
            "EnableProjectKyaroSprites",
            true,
            "Enable Project Kyaro sprite textures from PKS1 and PKS2 folders. Set to false to use original Pixel Based Sprites"
        );

        DisableSpritePostProcessing = _config.Bind(
            "01 Project Kyaro Sprites",
            "DisableSpritePostProcessing",
            true,
            "Prevent post-processing effects (bloom, vignette, depth of field, etc.) from affecting sprites and Prevents white outlines on edges and exposing sprite seams"
        );

        SpriteFilteringEnabled = _config.Bind(
            "01 Project Kyaro Sprites",
            "SpriteFilteringEnabled",
            true,
            "Enable texture filtering for sprites. false = to retain the Point Filtering, true = Enabled (Bilinear + 2x Aniso). Turn this off if you want to retain the original pixelated look of the game"
        );

        SMAAQuality = _config.Bind(
            "01 Project Kyaro Sprites",
            "SMAAQuality",
            "Low",
            "SMAA anti-aliasing quality for sprites. Options: Off, Low, Medium, High. NOTE: 'Low' is recommended. While this mod can be techincally under general. this feature is best used the project Kyaro sprites options. this also wont effect the game UI"
        );


        LoadLauncherUITextures = _config.Bind(
            "02 User Interface",
            "LoadLauncherUITextures",
            true,
            "Load custom textures from Textures/launcher folder. Set to false to use original launcher UI. This is based of the unused assets from the game files"
        );

        MinimalUI = _config.Bind(
            "02 User Interface",
            "MinimalUI",
            true,
            "Enable minimal UI texture variants. When false, any custom texture whose path contains 'minimal' will be skipped."
        );

        ClassicSaveWindow = _config.Bind(
            "02 User Interface",
            "ClassicSaveWindow",
            true,
            "Mimics the feel of the PSX version of Save/Load window for Both Games giving the save/load window a more nostalgic feel instead of the very generic looking window"
        );


        ShowSaveSlotPartyPortraits = _config.Bind(
            "02 User Interface",
            "ShowSaveSlotPartyPortraits",
            true,
            "Displays mini party member portraits next to save slots in the Save/Load window for Suikoden II."
        );

        DisablePortraitDialogMask = _config.Bind(
            "02 User Interface",
            "DisablePortraitDialogMask",
            false,
            "Disable the Face_Mask_01 texture overlay on character portraits in dialog windows. This removes the mask effect that appears on portrait displays during conversations."
        );

        ScaleDownDialogBox = _config.Bind(
            "02 User Interface",
            "ScaleDownDialogBox",
            true,
            "Compact dialog box. false = Normal, true = 80% size with adjusted position"
        );

        ScaledDownMenu = _config.Bind(
            "02 User Interface",
            "ScaledDownMenu",
            "true",
            "Main menu layout preset. false = Normal , true: scaled down 80% with adjusted position)."
        );

        PSPLauncher = _config.Bind(
            "02 User Interface",
            "PSPLauncher",
            false,
            "Enable the PSP inspired Launcher. Off by default."
        );

        EnhancedGallery = _config.Bind(
            "02 User Interface",
            "EnhancedGallery",
            true,
            "Enable enhanced gallery backgrounds. Replaces Movies, Events, and Sounds gallery backgrounds with custom textures Inspired by the PSP version."
        );

        DisableUITips = _config.Bind(
            "02 User Interface",
            "DisableUITips",
            false,
            "Disable the UITips UI element (control/button tips overlay at UI_Root/UI_Canvas_Root/UITips/)."
        );

        SavePointColor = _config.Bind(
            "03 General",
            "SavePointColor",
            "default",
            "Save point orb color. Options: black, blue, cyan, green, navy, pink, purple, red, white, yellow, default, random. 'random' picks a new color each room/scene entry.Note some Save Points are hardcoded by the game and will not change."
        );

        DisableSavePointGlow = _config.Bind(
            "03 General",
            "DisableSavePointGlow",
            true,
            "Disable the glow effect on save point orbs as it can actualy wash out the color of the orb. Set to false to keep the original glow."
        );

        DisableWorldMapClouds = _config.Bind(
            "03 General",
            "DisableWorldMapClouds",
            true,
            "Disable cloud effects on the world map for Suikoden 1 and 2. Set to false to keep the original cloud effects."
        );

        DisableWorldMapSunrays = _config.Bind(
            "03 General",
            "DisableWorldMapSunrays",
            true,
            "Disable sunray glow effects on the world map for Suikoden 1 and 2. Set to false to keep the original sunray glow effects."
        );
        
        BetterLauncherBGM = _config.Bind(
            "03 General",
            "BetterLauncherBGM",
            true,
            "Enable Better Launcher BGM mod. Loads sound files from PKCore/00-Mods/Better-Launcher-BGM-Mod/Sound/ to replace the launcher music. Requires EnableSoundRedirect to be true."
        );        
        
        // Game Specific
        S1ScaledDownWorldMap = _config.Bind(
            "04 Game : Suikoden 1",
            "S1ScaledDownWorldMap",
            true,
            "Scale down the Suikoden 1 world map UI to 80% with adjusted positioning for better visibility. When enabled, applies scale (0.8, 0.8, 1) and position (652.0001, -355.3, 0) to the smap element."
        );

        TirRunTexture = _config.Bind(
            "04 Game : Suikoden 1",
            "TirRunTexture",
            "default",
            "Texture variant for Tir running animation. Options: default, alt, pixel. 'alt' is for Smooth Sprite variant and looks for '..._alt.png'. 'pixel' is for Pixel Sprite variant and looks for '..._pixel.png'. Now supports with Project Kyaro Sprites off"
        );

        // Game Specific
        EnablePortraitSystem = _config.Bind(
            "05 Game : Suikoden 2",
            "EnablePortraitSystem",
            true,
            "Enable custom NPC portrait injection. Place PNG files in PKCore/Textures/NPCPortraits/ named after the NPC (e.g., Ace.png, Yuri.png). Use GSD1/ or GSD2/ subfolders for game-specific portraits. Case-insensitive. Supports both Suikoden I and II."
        );

        MercFortFence = _config.Bind(
            "05 Game : Suikoden 2",
            "MercFortFence",
            "default",
            "Mercenary Fortress Fence texture variant. Enter any suffix (e.g. 'bamboo', 'green', 'custom'). Looks for suffix '_<value>'."
        );

        ColoredIntroAndFlashbacks = _config.Bind(
            "05 Game : Suikoden 2",
            "ColoredIntroAndFlashbacks",
            true,
            "Enable colored intro and flashback sequences for Suikoden 2. When enabled, disables the CustomPostEffect component to restore color to these scenes."
        );

        EnableWarAbilityMod = _config.Bind(
            "05 Game : Suikoden 2",
            "EnableWarAbilityMod",
            true,
            "Enable war battle ability modification. Allows you to customize character abilities in Suikoden 2's war battles. Wont appear on the game menu of Apple but will have an effect on battle. Base is already boosted but can be further configures in PKCore/Config/S2WarAbilities.json"
        );

        LoopCookOffMatches = _config.Bind(
            "05 Game : Suikoden 2",
            "LoopCookOffMatches",
            true,
            "Automatically restarts cook-off battles from Chef Antonio after defeating the final chef and viewing the post-contest celebration. All recipes and seasonings are preserved."
        );

        ReduceCookOffCooldown = _config.Bind(
            "05 Game : Suikoden 2",
            "ReduceCookOffCooldown",
            true,
            "Removes the 30-60 minute active gameplay cooldown between cook-off matches, allowing consecutive battles with rival chefs to trigger immediately upon entering the restaurant or castle hall."
        );

        ShowCookOffScoreHelper = _config.Bind(
            "05 Game : Suikoden 2",
            "ShowCookOffScoreHelper",
            true,
            "Displays real-time scoring predictions and optimal menu recommendations on screen during Suikoden 2 cook-off minigame battles."
        );

        LoopCliveQuest = _config.Bind(
            "05 Game : Suikoden 2",
            "LoopCliveQuest",
            true,
            "Automatically resets Clive's pursuit quest back to Lakewest upon entering Lakewest with the Sajah Village finale completed. Allows replaying the complete questline from Lakewest to Sajah indefinitely in the late game."
        );

        LoopFinalBossGauntlet = _config.Bind(
            "05 Game : Suikoden 2",
            "LoopFinalBossGauntlet",
            true,
            "Automatically resets the entire L'Renouille final battle gauntlet (General Han Cunningham duel, Lucia & Karaya vanguard battle, Generals Seed & Culgan battle, and Silver Beast Rune final boss) upon entering L'Renouille outer gates (vj01) when the final boss has been defeated. Allows challenging the complete final sequence indefinitely."
        );

        ResetGauntletOnNextEntry = _config.Bind(
            "05 Game : Suikoden 2",
            "ResetGauntletOnNextEntry",
            false,
            "When true, forces a complete reset of the L'Renouille final battle gauntlet (Lucia, Han, Seed & Culgan, Beast Rune) the next time any L'Renouille map is entered, even if the final boss has not yet been defeated. Automatically resets back to false after performing the reset."
        );

        EnableLeonaPostFinalBoss = _config.Bind(
            "05 Game : Suikoden 2",
            "EnableLeonaPostFinalBoss",
            true,
            "Restores Leona at Dunan Castle Tavern (vk08) after the final boss battle (or whenever party changing is locked by the epilogue), replacing the substitute maid ('Leona went to restock on spirits') and fully re-enabling the party change menu."
        );

        EnableCastleMinigamesPostFinalBoss = _config.Bind(
            "05 Game : Suikoden 2",
            "EnableCastleMinigamesPostFinalBoss",
            true,
            "Restores Dunan Castle minigames (such as vk18 Laundry & Gardens) during the post-final-boss epilogue by temporarily clearing epilogue lockout flags while on the map."
        );

        EnableWarReplaySidequest = _config.Bind(
            "05 Game : Suikoden 2",
            "EnableWarReplaySidequest",
            true,
            "Adds a War Battle Replay / Tactical Simulation option when speaking to Apple in Dunan Castle's War Room. Safely snapshots and restores all characters, story flags, and unit formations."
        );

        UnlockAllWarReplays = _config.Bind(
            "05 Game : Suikoden 2",
            "UnlockAllWarReplays",
            false,
            "When true, makes all 16 War Battles selectable in Apple's War Replay menu regardless of story progress (Note: War 14 is an instant-end cutscene battle)."
        );

        // Performance section - all performance related settings
        EnableTextureManifestCache = _config.Bind(
            "Performance",
            "EnableTextureManifestCache",
            false,
            "Enable texture manifest caching for faster startup. Caches the texture index to skip re-scanning the Textures folder on every launch. Disable if you're actively adding/removing textures and want changes detected immediately."
        );

        EnableMemoryCaching = _config.Bind(
            "Performance",
            "EnableMemoryCaching",
            true,
            "Enable intelligent texture memory caching. Automatically clears textures from memory when transitioning between areas to free up RAM. Textures are rebuilt when you enter new scenes. Keeps persistent UI textures in memory. Recommended for performance optimization on lower-end systems. Never turn this off"
        );

        ResolutionScale = _config.Bind(
            "Performance",
            "ResolutionScale",
            1.0f,
            new ConfigDescription(
                "Resolution scale multiplier (0.5 to 2.0). 1.0 = off / native resolution, 0.5 = half resolution for performance, 1.5-2.0 = super-sampling for quality. Do not use if you are using the resolution changer from Suikoden Fix",
                new AcceptableValueRange<float>(0.5f, 2.0f)
            )
        );

        ShowMouseCursor = _config.Bind(
            "Utilty",
            "ShowMouseCursor",
            false,
            "Show mouse cursor when hovering over the game window. Useful for debugging with Unity Explorer or accessing overlays."
        );

        EnableBorderlessWindow = _config.Bind(
            "Utilty",
            "EnableBorderlessWindow",
            false,
            "Enable borderless floating window mode. Strips title bars and borders while remaining in windowed mode, allowing arbitrary or lower resolutions in compact borderless windows."
        );

        // Diagnostics section - all logging and debugging settings
        LogTextIDs = _config.Bind(
            "zz - Diagnostics",
            "LogTextIDs",
            false,
            "Log all text ID lookups to the console. Enable this to find the ID of dialog lines you want to replace. WARNING: Creates a lot of log output."
        );

        DumpTextDatabase = _config.Bind(
            "zz - Diagnostics",
            "DumpTextDatabase",
            false,
            "Accumulate all text IDs and content seen at runtime and save them to PKCore/Debug/TextDB_GSD1.json and TextDB_GSD2.json. Files are additive across sessions and use the same format as DialogOverrides.json."
        );

        DumpJsonAssets = _config.Bind(
            "zz - Diagnostics",
            "DumpJsonAssets",
            true,
            "Dump all loaded AssetBundle TextAsset and JSON files (e.g. vd01.json, event data, map data) to PKCore/Debug/JsonDumps/ when loaded by the game."
        );

        EnableJsonOverrides = _config.Bind(
            "zz - Diagnostics",
            "EnableJsonOverrides",
            true,
            "Enable loading custom JSON asset overrides from PKCore/JsonOverrides/. Allows custom JSON files to replace game AssetBundle TextAssets."
        );

        DetailedLogs = _config.Bind(
            "zz - Diagnostics",
            "DetailedLogs",
            false,
            "Enable detailed texture logging (replacement confirmations and full texture list on startup). Disable for silent operation (only errors will be logged)."
        );

        LogReplaceableTextures = _config.Bind(
            "zz - Diagnostics",
            "LogReplaceableTextures",
            false,
            "Log all replaceable texture names discovered during gameplay. Useful for identifying texture names to create custom replacements. Independent of DetailedLogs setting."
        );

        EnableTavernDiagnostics = _config.Bind(
            "zz - Diagnostics",
            "EnableTavernDiagnostics",
            false,
            "Enable forensic diagnostic logging for Dunan Castle Tavern (vk08) event flags, flag checks, dialogue, and party-change triggers."
        );

        // ========================================
        // EXPERIMENTAL FEATURES
        // ========================================
        // These features are work-in-progress and may not function correctly.
        // Enable at your own risk for testing purposes.

        EnableDebugMenu2 = _config.Bind(
            "zz - Experimental",
            "EnableDebugMenu2",
            false,
            "[EXPERIMENTAL] Enable the DebugMenu2 object which is normally disabled in the game. This may provide access to developer debug features."
        );

        // ========================================
        // HIDDEN SETTINGS (Internal Use Only)
        // ========================================
        // These settings are NOT written to the config file and are hardcoded to false
        // If you need to enable them for development, replace these with _config.Bind() calls
        EnableSoundRedirect = new HiddenConfigEntry<bool>(true);
        EnableDialogOverrides = new HiddenConfigEntry<bool>(true);
        SpriteMipmapBias = new HiddenConfigEntry<float>(-0.5f);
        EnableCustomTextures = new HiddenConfigEntry<bool>(true);

    }
}
