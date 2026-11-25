using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using PKCore.Patches;
using UnityEngine;

namespace PKCore;

[BepInPlugin("faospark.pkcore", "PKCore", "2026.11.20")]
[BepInDependency("d3xMachina.suikoden_fix", BepInDependency.DependencyFlags.SoftDependency)]
[BepInDependency("faospark.SquidFam", BepInDependency.DependencyFlags.SoftDependency)]
public class Plugin : BasePlugin
{
    public static Plugin Instance { get; private set; }
    public static new ManualLogSource Log;
    public static new ModConfiguration Config;
    public static int MainThreadId { get; private set; }
    public static bool IsMainThread => System.Threading.Thread.CurrentThread.ManagedThreadId == MainThreadId;
    public static bool HasExternalBattlePatch { get; private set; }
    public static bool HasExternalButtonPrompts { get; private set; }
    public static bool HasExternalReplayPlus { get; private set; }

    public override void Load()
    {
        MainThreadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
        Instance = this;
        Log = base.Log;

        Log.LogInfo("Loading PKCore...");

        Config = new ModConfiguration(base.Config);
        Config.Init();

        DetectLegacyStandalonePlugins();

        AssetLoader.Initialize();
        GameDetection.Initialize();

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

            if (Config.DetailedLogs.Value)
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
        Patches.MenuScalePatch.ApplyLauncherConfigScaling();
        Patches.S2CookOffLoopPatch.Update();
        Patches.S2CookOffScorePatch.Update();
        // Patches.S2WarReplayMenu.Update();
        if (!HasExternalBattlePatch)
        {
            if (Config.EnableCharacterRangeOverrides.Value)
                Patches.CharacterRangePatch.Update();
            if (Config.RemoveCommandRuneSelfUnbalance.Value)
                Patches.CommandRuneSelfUnbalancePatch.Update();
            if (Config.RemoveCommandRuneUseLimit.Value)
                Patches.CommandRuneReusePatch.Update();
        }
        AssetLoader.Update();
    }

    private void DetectLegacyStandalonePlugins()
    {
        try
        {
            var plugins = IL2CPPChainloader.Instance?.Plugins;
            if (plugins == null) return;

            if (plugins.ContainsKey("faospark.pkbattlepatch"))
            {
                HasExternalBattlePatch = true;
                Log.LogWarning("[PKCore] Detected legacy standalone 'PKBattlePatch.dll'. PKBattlePatch is now built into PKCore — skipping built-in battle patches to avoid duplicates. Please remove PKBattlePatch.dll from BepInEx/plugins/.");
            }

            if (plugins.ContainsKey("faospark.pkbuttonprompts"))
            {
                HasExternalButtonPrompts = true;
                Log.LogWarning("[PKCore] Detected legacy standalone 'PKButtonPrompts.dll'. PKButtonPrompts is now built into PKCore — skipping built-in button prompt patch to avoid duplicates. Please remove PKButtonPrompts.dll from BepInEx/plugins/.");
            }

            if (plugins.ContainsKey("faospark.pkreplayplus"))
            {
                HasExternalReplayPlus = true;
                Log.LogWarning("[PKCore] Detected legacy standalone 'PKReplayPlus.dll'. PKReplayPlus is now built into PKCore — skipping built-in replay/epilogue patches to avoid duplicates. Please remove PKReplayPlus.dll from BepInEx/plugins/.");
            }
        }
        catch (System.Exception ex)
        {
            Log.LogWarning($"[PKCore] Could not check for legacy standalone plugins: {ex.Message}");
        }
    }

    public void LateUpdate()
    {
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
            Log.LogInfo("Patching TextureMemoryCachePatch...");
            harmony.PatchAll(typeof(TextureMemoryCachePatch));
            TextureMemoryCachePatch.Initialize();
        }

        // Apply Sprite Filtering patch independently
        if (Config.SpriteFilteringEnabled.Value)
        {
            Log.LogInfo("Patching SpriteFilteringPatch...");
            harmony.PatchAll(typeof(SpriteFilteringPatch));
            SpriteFilteringPatch.Initialize();
        }

        // Mouse Cursor Visibility (for debugging)
        if (Config.ShowMouseCursor.Value)
        {
            Log.LogInfo("Patching MouseCursorPatch...");
            MouseCursorPatch.Initialize(true);
            harmony.PatchAll(typeof(MouseCursorPatch));
        }

        // Borderless Window Mode (Strips borders in windowed mode for custom compact sizes)
        if (Config.EnableBorderlessWindow.Value)
        {
            Log.LogInfo("Patching BorderlessWindowPatch...");
            harmony.PatchAll(typeof(BorderlessWindowPatch));
            BorderlessWindowPatch.Initialize();
        }

        // Custom Texture Replacement
        if (Config.EnableCustomTextures.Value || Config.LogReplaceableTextures.Value)
        {
            Log.LogInfo(Config.EnableCustomTextures.Value
                ? "Patching CustomTexturePatch..."
                : "Patching CustomTexturePatch (logging only)...");

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

            Log.LogInfo("Patching MapTexturePatch...");
            harmony.PatchAll(typeof(MapTexturePatch));


            // GameObject activation patches are part of CustomTexturePatch (already applied above)
            // This handles Dragon, Cow, and Suikozu monitor attachment
        }

        // Resolution patch
        if (Config.ResolutionScale.Value != 1.0f)
        {
            Log.LogInfo($"Patching ResolutionPatch (scale: {Config.ResolutionScale.Value})...");
            harmony.PatchAll(typeof(ResolutionPatch));
            ResolutionPatch.Initialize();
        }

        // Sync Settings UI with PKCore display mode / resolution overrides
        if (Config.ResolutionScale.Value != 1.0f || Config.EnableBorderlessWindow.Value)
        {
            Log.LogInfo("Patching DisplaySettingsUiPatch...");
            harmony.PatchAll(typeof(Patches.DisplaySettingsUiPatch));
        }

        // World Map Effects patch
        if (Config.DisableWorldMapClouds.Value)
        {
            Log.LogInfo("Patching WorldMapEffectsPatch...");
            harmony.PatchAll(typeof(WorldMapEffectsPatch));
        }

        // Sprite Post-Processing patch
        if (Config.DisableSpritePostProcessing.Value)
        {
            Log.LogInfo("Patching DisableSpritePostProcessingPatch...");
            harmony.PatchAll(typeof(DisableSpritePostProcessingPatch));
            DisableSpritePostProcessingPatch.Initialize();
        }

        // NPC Portrait Injection
        if (Config.EnablePortraitSystem.Value)
        {
            Log.LogInfo("Patching PortraitSystemPatch...");
            harmony.PatchAll(typeof(PortraitSystemPatch));
            PortraitSystemPatch.Initialize();
        }

        // Dialog Text ID interceptor and placeholder replacement (independent of NPC portraits)
        if (Config.EnableDialogOverrides.Value || Config.LogTextIDs.Value || Config.DumpTextDatabase.Value)
        {
            Log.LogInfo("Patching TextDatabasePatch & SaveDataProcessor...");
            harmony.PatchAll(typeof(TextDatabasePatch));
            TextDatabasePatch.Initialize();

            // Ensure dialog override files are loaded even when EnablePortraitSystem is false
            if (Config.EnableDialogOverrides.Value)
                PortraitSystemPatch.LoadDialogOverrides();

            // Apply SaveDataProcessor for protagonist/HQ name placeholder replacement
            harmony.PatchAll(typeof(SaveDataProcessor));
        }


        if (Config.EnableCustomTextures.Value)
        {
            Log.LogInfo("Patching AnimatedTexturePatch...");
            AnimatedTexturePatch.Initialize();
        }

        // Disable CustomPostEffect for colored intro/flashbacks (Suikoden 2)
        if (Config.ColoredIntroAndFlashbacks.Value)
        {
            Log.LogInfo("Patching ColoredIntroAndFlashbacksPatch...");
            DisableCustomPostEffectPatch.Initialize(harmony);
        }

        // Suikoden 2 Custom Object Insertion
        if (Config.EnableS2CustomObjectInsertion.Value)
        {
            Log.LogInfo("Patching S2CustomObjectInsertionPatch...");
            S2CustomObjectInsertionPatch.Initialize(Config.EnableS2CustomObjectInsertion.Value, harmony);
        }

        // Apply Dialog Patch (Dialog Box Scaling)
        if (Config.ScaleDownDialogBox.Value)
        {
            Log.LogInfo("Patching DialogBoxScalePatch...");
            harmony.PatchAll(typeof(DialogBoxScalePatch));
        }

        // Apply Suikoden 1 World Map Scale Patch
        if (Config.S1ScaledDownWorldMap.Value)
        {
            Log.LogInfo("Patching S1WorldMapScaleUIPatch...");
            S1WorldMapScaleUIPatch.Initialize();
            harmony.PatchAll(typeof(S1WorldMapScaleUIPatch));
        }

        // Disable specific va4_04 map objects (Suikoden 1) - always active
        harmony.PatchAll(typeof(S1DisableObjectsPatch));

        // Disable UITips (UI_Root/UI_Canvas_Root/UITips)
        if (Config.DisableUITips.Value)
        {
            Log.LogInfo("Patching DisableUITipsPatch...");
            DisableUITipsPatch.Initialize(harmony);
        }

        // Language selection detection patch (TitlePanel)
        Log.LogInfo("Patching LanguageSelectionPatch...");
        harmony.PatchAll(typeof(LanguageSelectionPatch));

        // Apply Menu Scale Patch (Menu Scaling)
        if (Config.ScaledDownMenu.Value.Equals("true", System.StringComparison.OrdinalIgnoreCase))
        {
            Log.LogInfo("Patching MenuScalePatch...");
            harmony.PatchAll(typeof(MenuScalePatch));
        }

        // Apply SMAA patches
        if (!Config.SMAAQuality.Value.Equals("Off", System.StringComparison.OrdinalIgnoreCase))
        {
            Log.LogInfo($"Patching SMAAPatch (quality: {Config.SMAAQuality.Value})...");
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

        Log.LogInfo("Patching DisablePortraitDialogMask...");
        DisablePortraitDialogMask.Initialize(excludedMasks);
        harmony.PatchAll(typeof(DisablePortraitDialogMask));
        // Enable DebugMenu2 (Experimental)
        if (Config.EnableDebugMenu2.Value)
        {
            Log.LogInfo("Patching EnableDebugMenu2...");
            EnableDebugMenu2.Initialize();
        }

        // Sound File Redirect
        if (Config.EnableSoundRedirect.Value)
        {
            Log.LogInfo("Patching SoundRedirectPatch...");
            SoundRedirectPatch.Initialize();
            harmony.PatchAll(typeof(SoundRedirectPatch));
        }

        // War Ability Modification (Experimental)
        if (Config.EnableWarAbilityMod.Value)
        {
            Log.LogInfo("Patching WarAbilityPatch...");
            WarAbilityPatch.Initialize(Log);
        }

        // Map ID Tracking (shared by Map Object & S2 patches)
        harmony.PatchAll(typeof(MACHICON_OnMapInitPatch));
        harmony.PatchAll(typeof(MachiLoader_Load_Patch));

        // Dunan Castle Tavern (vk08) Forensic Diagnostics Tracker (dormant unless enabled in config)
        if (Config.EnableTavernDiagnostics.Value)
        {
            Log.LogInfo("Patching S2TavernDiagnosticTracker...");
            harmony.PatchAll(typeof(S2TavernMapInitTracker));
            harmony.PatchAll(typeof(S2TavernEventInitTracker));
            harmony.PatchAll(typeof(S2TavernEventFlgCHKTracker));
            harmony.PatchAll(typeof(S2TavernEventFlgCHK2Tracker));
            harmony.PatchAll(typeof(S2TavernMessageWindowTracker));
            harmony.PatchAll(typeof(S2TavernSelectTSREntryTracker));
            harmony.PatchAll(typeof(S2TavernSelectTsrSerifuTracker));
            harmony.PatchAll(typeof(S2TavernPartyInTracker));
        }


        // Reaction Monitor (MapChara/r_action trigger)
        S2CookOffPortraitMonitor.Initialize();

        // Covert Mission Portrait Monitor
        harmony.PatchAll(typeof(CovertMissionPortraitMonitor));
        CovertMissionPortraitMonitor.Initialize();

        // War Room BG Patch
        Log.LogInfo("Patching WarRoomBGPatch...");
        harmony.PatchAll(typeof(WarRoomBGPatch));


        // Save Slot Party Portrait Patch
        if (Config.ShowSaveSlotPartyPortraits.Value)
        {
            Log.LogInfo("Patching SaveSlotPartyPortraitPatch...");
            harmony.PatchAll(typeof(SaveSlotPartyPortraitPatch));
        }


        // Suikoden 2 Cook-off battle synchronization & live scoring assistant
        Log.LogInfo("Patching S2CookOffLoopPatch & S2CookOffScorePatch...");
        harmony.PatchAll(typeof(Patches.S2CookOffLoopPatch.OverlayRbattleInitPatch));
        harmony.PatchAll(typeof(Patches.S2CookOffScorePatch));
        MACHICON_OnMapInitPatch.OnMapChangedEvent += () => Patches.S2CookOffLoopPatch.CheckAndResetCookOffs(MACHICON_OnMapInitPatch.CurrentMapId);

        // Suikoden 2 Soft Reset Battle PreRelease NullRef Guard
        Log.LogInfo("Patching S2SoftResetBattleFixPatch...");
        harmony.PatchAll(typeof(Patches.S2SoftResetBattleFixPatch));

        // Controller Button Prompt Overrides (reabsorbed from PKButtonPrompts)
        if (!HasExternalButtonPrompts && Config.EnableButtonPrompts.Value)
        {
            Log.LogInfo($"Patching GlobalControllerPromptPatch (type: {Config.ControllerPromptType.Value})...");
            harmony.PatchAll(typeof(GlobalControllerPromptPatch));
        }

        // Suikoden 2 Replay, Epilogue & Guardian Blessing Patches (reabsorbed from PKReplayPlus)
        if (!HasExternalReplayPlus)
        {
            if (Config.LoopCliveQuest.Value)
                Log.LogInfo("Patching S2CliveQuestReplayPatch...");
            if (Config.LoopFinalBossGauntlet.Value || Config.ResetGauntletOnNextEntry.Value)
                Log.LogInfo("Patching S2FinalBossReplayPatch...");
            if (Config.EnableLeonaPostFinalBoss.Value)
                Log.LogInfo("Patching S2EpilogueLeonaPatch...");
            if (Config.EnableCastleMinigamesPostFinalBoss.Value)
                Log.LogInfo("Patching S2EpilogueMinigamePatch...");
            if (Config.EnableRepeatStatueRewards.Value || Config.AlwaysKeepStatueAssembled.Value)
                Log.LogInfo("Patching GuardianDeityRepeatRewardsPatch...");

            harmony.PatchAll(typeof(S2LeonaOnMapInitPrefixPatch));
            harmony.PatchAll(typeof(S2LeonaSaveMenuInitPrefixPatch));
            harmony.PatchAll(typeof(S2MinigameOnMapInitPrefixPatch));
            harmony.PatchAll(typeof(S2MinigameSaveMenuInitPrefixPatch));
            harmony.PatchAll(typeof(GuardianDeityRepeatRewardsPatch));
        }

        // Combat, Battle HUD & Balance Patches (reabsorbed from PKBattlePatch)
        if (!HasExternalBattlePatch)
        {
            if (Config.ShowEnemyLevelInBattle.Value || Config.ShowEnemyHpInBattle.Value)
            {
                Log.LogInfo("Patching BattleEnemyLevelPatch...");
                harmony.PatchAll(typeof(BattleEnemyLevelPatch));
            }

            if (Config.ShowBattleMaxHP.Value)
            {
                Log.LogInfo("Patching BattlePartyHPPatch...");
                harmony.PatchAll(typeof(BattlePartyHPPatch));
            }

            if (Config.LogBattleUnitWindow.Value)
            {
                Log.LogInfo("Patching BattleUnitWindowDiagnostics...");
                harmony.PatchAll(typeof(BattleUnitWindowDiagnostics));
            }

            if (Config.EnableBattlePositionAdjustments.Value || Config.LogBattlePositions.Value)
            {
                Log.LogInfo($"Patching BattlePositionPatch (preset: {Config.S2BattlePositionPreset.Value})...");
                BattlePositionPatch.Initialize(harmony);
            }

            if (Config.EnableBattleCameraZoom.Value)
            {
                Log.LogInfo($"Patching BattleCameraZoomPatch (S1: {Config.S1BattleCameraFovPercent.Value}%, S2: {Config.S2BattleCameraFovPercent.Value}%)...");
                BattleCameraZoomPatch.Initialize(harmony);
            }

            if (Config.EnableMemoryAutoBattle.Value)
            {
                Log.LogInfo("Patching MemoryAutoBattlePatch...");
                MemoryAutoBattlePatch.Initialize(harmony);
            }

            if (Config.EnableSmartHealing.Value)
            {
                Log.LogInfo("Patching SmartHealingPatch...");
                SmartHealingPatch.Initialize(harmony);
            }

            if (Config.EnableCharacterRangeOverrides.Value)
            {
                Log.LogInfo("Patching CharacterRangePatch...");
                CharacterRangePatch.Initialize(harmony);
            }

            if (Config.RemoveCommandRuneSelfUnbalance.Value)
            {
                Log.LogInfo("Patching CommandRuneSelfUnbalancePatch...");
                CommandRuneSelfUnbalancePatch.Initialize(harmony);
            }

            if (Config.RemoveCommandRuneUseLimit.Value)
            {
                Log.LogInfo("Patching CommandRuneReusePatch...");
                CommandRuneReusePatch.Initialize(harmony);
            }

            if (Config.EnhanceBrightShieldRune.Value)
            {
                Log.LogInfo("Patching S2BrightShieldEnhancementPatch...");
                S2BrightShieldEnhancementPatch.Initialize(harmony);
            }
        }

        if (Config.EnableSaveKiba.Value)
        {
            Log.LogInfo("Patching S2SaveKibaPatch...");
            S2SaveKibaPatch.Initialize(harmony);
        }

        if (Config.PSPLauncher.Value)
            Log.LogInfo("Patching PSPLauncherPatch...");
        if (Config.EnhancedGallery.Value)
            Log.LogInfo("Patching PSPGalleryEnhanced...");

        Log.LogInfo("Patches applied!");

        // Suikoden 2 War Battle Replay Sidequest (Archived in forlater/WarBattleReplay)
        // harmony.PatchAll(typeof(Patches.S2WarReplayPatch));


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

    public void LateUpdate()
    {
        if (Plugin.Instance != null)
        {
            Plugin.Instance.LateUpdate();
        }
    }

    public void ApplyBorderlessStyle()
    {
        PKCore.Patches.BorderlessWindowPatch.ApplyBorderlessStyle();
    }
}
