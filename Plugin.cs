using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using PKCore.Patches;
using UnityEngine;

namespace PKCore;

[BepInPlugin("faospark.pkcore", "PKCore", "2026.03.01")]
[BepInDependency("d3xMachina.suikoden_fix", BepInDependency.DependencyFlags.SoftDependency)]
[BepInDependency("faospark.SquidFam", BepInDependency.DependencyFlags.SoftDependency)]
[BepInDependency("iDeathHD.DearImGuiInjection", BepInDependency.DependencyFlags.SoftDependency)]
public class Plugin : BasePlugin
{
    public static Plugin Instance { get; private set; }
    public static new ManualLogSource Log;
    public static new ModConfiguration Config;
    public static int MainThreadId { get; private set; }
    public static bool IsMainThread => System.Threading.Thread.CurrentThread.ManagedThreadId == MainThreadId;

    public override void Load()
    {
        MainThreadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
        Instance = this;
        Log = base.Log;

        Log.LogInfo("Loading PKCore...");

        Config = new ModConfiguration(base.Config);
        Config.Init();

        AssetLoader.Initialize();

        // Force immediate exit on quit to prevent Alt+F4 hangs (Unity 2022/BepInEx 6 issue)
        Application.SetStackTraceLogType(LogType.Error, StackTraceLogType.None);
        Application.quitting += (System.Action)(() =>
        {
            Log.LogInfo("Shutting down... forcing process exit.");
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        });

        // Register custom MonoBehaviours for IL2CPP
        try
        {
            Il2CppInterop.Runtime.Injection.ClassInjector.RegisterTypeInIl2Cpp<SavePointSpriteMonitor>();
            Il2CppInterop.Runtime.Injection.ClassInjector.RegisterTypeInIl2Cpp<S2CookOffPortraitMonitor>();
            Il2CppInterop.Runtime.Injection.ClassInjector.RegisterTypeInIl2Cpp<CovertMissionPortraitMonitor>();
            Il2CppInterop.Runtime.Injection.ClassInjector.RegisterTypeInIl2Cpp<WarRoomBGPatch>();
            Il2CppInterop.Runtime.Injection.ClassInjector.RegisterTypeInIl2Cpp<SaveSlotPartyPortraitPatch.SaveSlotPortraitMonitor>();


        }
        catch (System.Exception ex)
        {
            Log.LogError($"Failed to register custom monitors: {ex.Message}");
        }

        // Create a MonoBehaviour to handle the Update loop (since BasePlugin doesn't have Update)
        // Initialize early so patches can use it
        try
        {
            Il2CppInterop.Runtime.Injection.ClassInjector.RegisterTypeInIl2Cpp<PkCoreMainLoop>();

            var obj = new GameObject("PkCoreMainLoop");
            GameObject.DontDestroyOnLoad(obj);
            var component = obj.AddComponent<PkCoreMainLoop>();
            obj.hideFlags = HideFlags.HideAndDontSave;

            PkCoreMainLoop.Instance = component;

            Log.LogInfo("Initialized PkCoreMainLoop for Update events.");
        }
        catch (System.Exception ex)
        {
            Log.LogError($"Failed to register PkCoreMainLoop: {ex.Message}");
        }

        ApplyPatches();

        Log.LogInfo("PKCore loaded successfully!");
    }

    public void Update()
    {
        Patches.GameDetection.Update();
        if (Config.PSPLauncher.Value)
            Patches.PSPLauncherPatch.Update();
        if (Config.EnhancedGallery.Value)
            Patches.PSPGalleryEnhanced.Update();
        if (Config.EnableCharacterRangeOverrides.Value)
            Patches.CharacterRangePatch.Update();
        if (Config.EnableRuneUnbalanceRemoval.Value)
            Patches.RuneUnbalancePatch.Update();
        if (Config.EnableUnlimitedCommandRunes.Value)
            Patches.CommandRuneUnlimitedPatch.Update();
        if (Config.EnableRoomItemRestoration.Value)
            Patches.RoomItemPatch.Update();
        Patches.MenuScalePatch.ApplyLauncherConfigScaling();
        Patches.EncounterNonePatch.UpdateInput();
        Patches.S1QuickStoragePatch.Update();
        Patches.S1QuickRunePatch.Update();
        Patches.ImGuiOverlayUI.Update();
        AssetLoader.Update();
    }

    private void ApplyPatches()
    {
        var harmony = new Harmony("faospark.pkcore");

        // Note: Log suppression via Application.logMessageReceived doesn't actually prevent logs
        // since the event fires AFTER logging. Disabled for now due to IL2CPP Debug method patching issues.
        // SuppressLogs.Initialize();

        // Initialize core texture system first (indexes all custom files)
        if (Config.EnableCustomTextures.Value || Config.LogReplaceableTextures.Value)
        {
            CustomTexturePatch.Initialize();
            CustomTexturePersist.Initialize();
        }

        // Initialize memory caching system for smart texture cleanup
        if (Config.EnableMemoryCaching.Value)
        {
            Log.LogInfo("Initializing Texture Memory Caching System...");
            harmony.PatchAll(typeof(TextureMemoryCachePatch));
            TextureMemoryCachePatch.Initialize();
        }

        // Apply Sprite Filtering patch independently
        if (Config.SpriteFilteringEnabled.Value)
        {
            Log.LogInfo($"Applying Sprite Filtering patch (Enabled: {Config.SpriteFilteringEnabled.Value})...");
            harmony.PatchAll(typeof(SpriteFilteringPatch));
            SpriteFilteringPatch.Initialize();
        }

        // Mouse Cursor Visibility (for debugging)
        if (Config.ShowMouseCursor.Value)
        {
            MouseCursorPatch.Initialize(true);
            harmony.PatchAll(typeof(MouseCursorPatch));
        }

        // Encounter None (F4 Hotkey)
        EncounterNonePatch.Initialize();
        harmony.PatchAll(typeof(EncounterNonePatch));

        // Dear ImGui Overlay (F10 Hotkey, DirectX Present Hook via DearImGuiInjection)
        Patches.ImGuiOverlayUI.Initialize();

        // Controller Prompt Override
        if (Config.ForceControllerPrompts.Value)
        {
            Log.LogInfo($"Applying Controller Prompt patch (type: {Config.ControllerPromptType.Value})...");
            harmony.PatchAll(typeof(GlobalControllerPromptPatch));
        }

        // Custom Texture Replacement
        if (Config.EnableCustomTextures.Value || Config.LogReplaceableTextures.Value)
        {
            if (Config.EnableCustomTextures.Value)
            {
                Log.LogInfo("Applying Custom Texture patch...");
            }
            else
            {
                Log.LogInfo("Applying Custom Texture patch (logging only)...");
            }

            harmony.PatchAll(typeof(CustomTexturePatch));

            // Patch for Save Window custom background
            harmony.PatchAll(typeof(SaveWindowPatch));

            // Apply GRSpriteRenderer patches for better sprite interception
            harmony.PatchAll(typeof(GRSpriteRendererPatch));
            GRSpriteRendererPatch.Initialize();

            // Apply Unity SpriteRenderer patches for standard Unity sprites
            harmony.PatchAll(typeof(UnitySpriteRendererPatch));
            UnitySpriteRendererPatch.Initialize();



            // Suikozu reactive patch (GSD2 world map)
            // IL2CPP registration is now lazy-loaded when first map is opened
            harmony.PatchAll(typeof(SuikozuPatch));

            // NOTE: BGManagerHD_Load_Patch is part of BathTexturePatch in this version
            // Log.LogInfo("Applying BGManagerHD.Load patch ...");
            // CustomTexturePatch.BGManagerHD_Load_Patch.Initialize(harmony);

            if (Config.DetailedLogs.Value)
            {
                Log.LogInfo("Applying Native Map Texture patch...");
            }
            harmony.PatchAll(typeof(MapTexturePatch));


            // GameObject activation patches are part of CustomTexturePatch (already applied above)
            // This handles Dragon, Cow, and Suikozu monitor attachment
        }

        // Resolution patch
        if (Config.EnableResolutionScaling.Value && Config.ResolutionScale.Value != 1.0f)
        {
            Log.LogInfo("Applying Resolution patch...");
            harmony.PatchAll(typeof(ResolutionPatch));
            ResolutionPatch.Initialize();
        }

        // World Map Effects patch
        if (Config.DisableWorldMapClouds.Value)
        {
            Log.LogInfo("Applying WorldMapEffects Patch (Disable Clouds)...");
            harmony.PatchAll(typeof(WorldMapEffectsPatch));
        }

        // Sprite Post-Processing patch
        if (Config.DisableSpritePostProcessing.Value)
        {
            Log.LogInfo("Applying DisableSpritePostProcessing Patch");
            harmony.PatchAll(typeof(DisableSpritePostProcessingPatch));
            DisableSpritePostProcessingPatch.Initialize();
        }

        // NPC Portrait Injection
        if (Config.EnablePortraitSystem.Value)
        {
            Log.LogInfo("Applying PortraitSystem Patch...");
            harmony.PatchAll(typeof(PortraitSystemPatch));
            PortraitSystemPatch.Initialize();
        }

        // Dialog Text ID interceptor and placeholder replacement (independent of NPC portraits)
        if (Config.EnableDialogOverrides.Value || Config.LogTextIDs.Value || Config.DumpTextDatabase.Value)
        {
            Log.LogInfo("Applying TextDatabase patch...");
            harmony.PatchAll(typeof(TextDatabasePatch));
            TextDatabasePatch.Initialize();

            // Ensure dialog override files are loaded even when EnablePortraitSystem is false
            if (Config.EnableDialogOverrides.Value)
                PortraitSystemPatch.LoadDialogOverrides();

            // Apply SaveDataProcessor for protagonist/HQ name placeholder replacement
            Log.LogInfo("Applying SaveDataProcessor patch...");
            harmony.PatchAll(typeof(SaveDataProcessor));
        }


        // ARCHIVED: MapBGManagerHD Object Diagnostics (moved to ObjectReserve folder)
        // if (Config.EnableObjectDiagnostics.Value)
        // {
        //     Log.LogInfo("Applying MapBGManagerHD diagnostic patches...");
        //     MapBGManagerHDDiagnostics.Initialize(Config.EnableObjectDiagnostics.Value, harmony);
        // }



        if (Config.EnableCustomTextures.Value)
        {
            if (Config.DetailedLogs.Value)
            {
                Log.LogInfo("Applying Animated Texture patch...");
            }
            AnimatedTexturePatch.Initialize();
        }

        // Disable CustomPostEffect for colored intro/flashbacks (Suikoden 2)
        if (Config.ColoredIntroAndFlashbacks.Value)
        {
            DisableCustomPostEffectPatch.Initialize(harmony);
        }

        // Apply Dialog Patch (Dialog Box Scaling)
        if (Config.ScaleDownDialogBox.Value)
        {
            Log.LogInfo("Applying DialogBoxScale patch ...");
            harmony.PatchAll(typeof(DialogBoxScalePatch));
        }

        // Apply Suikoden 1 World Map Scale Patch
        if (Config.S1ScaledDownWorldMap.Value)
        {
            Log.LogInfo("Applying S1WorldMapScaleUI patch...");
            S1WorldMapScaleUIPatch.Initialize();
            harmony.PatchAll(typeof(S1WorldMapScaleUIPatch));
        }

        // Disable specific va4_04 map objects (Suikoden 1) - always active
        harmony.PatchAll(typeof(S1DisableObjectsPatch));

        // Disable UITips (UI_Root/UI_Canvas_Root/UITips)
        if (Config.DisableUITips.Value)
        {
            Log.LogInfo("Applying DisableUITips patch...");
            DisableUITipsPatch.Initialize(harmony);
        }

        // Language selection detection patch (TitlePanel)
        Log.LogInfo("Applying LanguageSelection patch...");
        harmony.PatchAll(typeof(LanguageSelectionPatch));

        // Apply Voice Acting Patch (Text-to-Speech)


        // Apply Menu Scale Patch (Menu Scaling)
        if (Config.ScaledDownMenu.Value.Equals("true", System.StringComparison.OrdinalIgnoreCase))
        {
            Log.LogInfo($"Applying MenuScale patch (mode: {Config.ScaledDownMenu.Value})...");
            harmony.PatchAll(typeof(MenuScalePatch));
        }

        // Apply SMAA patches
        if (!Config.SMAAQuality.Value.Equals("Off", System.StringComparison.OrdinalIgnoreCase))
        {
            Log.LogInfo($"Applying SMAA patch (quality: {Config.SMAAQuality.Value})...");
            harmony.PatchAll(typeof(SMAAPatch));
        }

        // Mask Replacement System (Always Active)
        // Replaces _Mask_Map textures with corresponding files from PKCore/Textures
        // Build exclusion list based on config
        var excludedMasks = new System.Collections.Generic.HashSet<string>();

        if (!Config.DisablePortraitDialogMask.Value)
        {
            // If DisablePortraitDialogMask is OFF, exclude Face_Mask_01
            excludedMasks.Add("Face_Mask_01");
        }

        if (Config.DetailedLogs.Value)
        {
            Log.LogInfo("Applying Mask Replacement System...");
        }
        DisablePortraitDialogMask.Initialize(excludedMasks);
        harmony.PatchAll(typeof(DisablePortraitDialogMask));
        // Enable DebugMenu2 (Experimental)
        if (Config.EnableDebugMenu2.Value)
        {
            Log.LogInfo("Initializing EnableDebugMenu2...");
            EnableDebugMenu2.Initialize();
        }

        // Sound File Redirect
        if (Config.EnableSoundRedirect.Value)
        {
            Log.LogInfo("Applying Sound Redirect patch...");
            SoundRedirectPatch.Initialize();
            harmony.PatchAll(typeof(SoundRedirectPatch));
        }

        // War Ability Modification (Experimental)
        if (Config.EnableWarAbilityMod.Value)
        {
            if (Config.DetailedLogs.Value)
                Log.LogInfo("Initializing War Ability Modification...");
            WarAbilityPatch.Initialize(Log);
        }

        // Battle Position Adjustment Patch (Suikoden 2)
        if (Config.EnableBattlePositionAdjustments.Value)
        {
            Log.LogInfo("Applying Battle Position Adjustment patch...");
            BattlePositionPatch.Initialize(harmony);
        }

        // Tenzan Pass Chimera Encounters Restoration Patch (Suikoden 2)
        if (Config.EnableTenzanChimeraFix.Value)
        {
            Log.LogInfo("Applying Tenzan Pass Chimera Encounters Restoration patch...");
            TenzanPassEncounterPatch.Initialize(harmony);
        }

        // Character Battle Range Patch (Suikoden 2)
        if (Config.EnableCharacterRangeOverrides.Value)
        {
            Log.LogInfo("Applying Character Range Overrides patch...");
            CharacterRangePatch.Initialize(harmony);
        }

        // Rune Unbalance Removal Patch (Suikoden 2)
        if (Config.EnableRuneUnbalanceRemoval.Value)
        {
            Log.LogInfo("Applying Rune Unbalance Removal patch...");
            RuneUnbalancePatch.Initialize(harmony);
        }

        // Unlimited Command Runes Patch (Suikoden 2)
        if (Config.EnableUnlimitedCommandRunes.Value)
        {
            Log.LogInfo("Applying Unlimited Command Runes patch...");
            CommandRuneUnlimitedPatch.Initialize(harmony);
        }

        // Memory Auto-Battle Patch (Suikoden 2)
        if (Config.EnableMemoryAutoBattle.Value)
        {
            Log.LogInfo("Applying Memory Auto-Battle patch...");
            MemoryAutoBattlePatch.Initialize(harmony);
        }

        // Smart After-Battle Healing Patch (Suikoden 2)
        if (Config.EnableSmartHealing.Value)
        {
            Log.LogInfo("Applying Smart After-Battle Healing patch...");
            SmartHealingPatch.Initialize(harmony);
        }

        // Map ID Tracking (shared by Map Object & S2 patches)
        harmony.PatchAll(typeof(MACHICON_OnMapInitPatch));

        // Sajah Village Rare Shop Unlock Patch (Suikoden 2)
        if (Config.UnlockSajahRareShopEarly.Value)
        {
            Log.LogInfo("Applying Sajah Village Rare Shop Unlock patch...");
            harmony.PatchAll(typeof(SajahShopUnlockPatch));
        }

        // Liberated Muse City Hall Re-entry Patch (Suikoden 2)
        if (Config.UnlockLiberatedMuseCityHall.Value)
        {
            Log.LogInfo("Applying Liberated Muse City Hall Re-entry patch...");
            harmony.PatchAll(typeof(LiberatedMuseCityHallPatch));
        }

        // Muse Ruins Survivors & 108 Stars Restoration Patch (Suikoden 2)
        if (Config.EnableMuseRuinsSurvivorsRestoration.Value)
        {
            Log.LogInfo("Applying Muse Ruins Survivors & 108 Stars Restoration patch...");
            harmony.PatchAll(typeof(MuseRuinsSurvivorsPatch));
        }

        // Battle Unit Window Diagnostics (both games)
        if (Config.LogBattleUnitWindow.Value)
        {
            Log.LogInfo("Applying Battle Unit Window diagnostics...");
            harmony.PatchAll(typeof(BattleUnitWindowDiagnostics));
        }

        // Reaction Monitor (MapChara/r_action trigger)
        S2CookOffPortraitMonitor.Initialize();

        // Covert Mission Portrait Monitor
        harmony.PatchAll(typeof(CovertMissionPortraitMonitor));
        CovertMissionPortraitMonitor.Initialize();

        // War Room BG Patch
        WarRoomBGPatch.Initialize();

        // Suikoden 2 NPC Bathhouse Sprites & Castle Visitors Restoration
        if (Config.EnableNPCBathVisitors.Value)
        {
            Log.LogInfo("Applying Suikoden 2 NPC Bathhouse Sprites & Castle Visitors patch...");
            NPCBathVisitorPatch.Initialize(harmony);
        }

        // Save Slot Party Portrait Patch
        if (Config.ShowSaveSlotPartyPortraits.Value)
        {
            Log.LogInfo("Applying Save Slot Party Portrait patch...");
            harmony.PatchAll(typeof(SaveSlotPartyPortraitPatch));
        }

        // Battle Party Max HP Display (Suikoden 1 & 2)
        if (Config.ShowBattleMaxHP.Value)
        {
            Log.LogInfo("Applying Battle Party Max HP patch...");
            harmony.PatchAll(typeof(BattlePartyHPPatch));
        }

        // Battle Enemy Level & HP Display (Suikoden 1 & 2)
        if (Config.ShowEnemyLevelInBattle.Value || Config.ShowEnemyHpInBattle.Value)
        {
            Log.LogInfo("Applying Battle Enemy Level & HP patch...");
            harmony.PatchAll(typeof(BattleEnemyLevelPatch));
        }

        // Suikoden 1 Castle Vault (Quick Storage)
        if (Config.EnableS1QuickStorage.Value)
        {
            Log.LogInfo("Applying Suikoden 1 Quick Storage patch...");
            harmony.PatchAll(typeof(Patches.S1QuickStoragePatch));
        }

        // Suikoden 1 Castle Rune Master (Quick Rune)
        if (Config.EnableS1QuickRuneMaster.Value)
        {
            Log.LogInfo("Applying Suikoden 1 Quick Rune Master patch...");
            harmony.PatchAll(typeof(Patches.S1QuickRunePatch));
        }

        // PSP Launcher Patch
        // Now handled by Update loop instead of Harmony postfix
    }
}

/// <summary>
/// Helper MonoBehaviour to drive the Update loop for the plugin
/// </summary>
public class PkCoreMainLoop : MonoBehaviour
{
    public static PkCoreMainLoop Instance { get; set; }

    public void Update()
    {
        if (Plugin.Instance != null)
        {
            Plugin.Instance.Update();
        }
    }

    public void OnGUI()
    {
        if (Plugin.Instance != null && Plugin.Config.EnableRoomItemRestoration.Value)
        {
            RoomItemUI.OnGUI();
        }
    }
}
