extern alias GSD1;
extern alias GSD2;

using System;
using HarmonyLib;
using UnityEngine;

namespace PKCore.Patches;

/// <summary>
/// Zooms out the battle camera in Suikoden I (GSD1) and Suikoden II (GSD2) when in battle,
/// controlled by separate percentage settings (S1BattleCameraFovPercent and S2BattleCameraFovPercent).
/// 
/// - Suikoden I (GSD1):
///   Default vanilla camera distance on GSD1::BattleBase.cameraDefPos is (0f, 0f, -1100.0f).
///   At default 125% (1.25x zoom-out), cameraDefPos.z is scaled to -1375.0f, which BattleBase.BattleUpdate
///   applies to classicCamera (and bound groundCamera/battleBGCamera/fieldFrontCamera/skyCamera).
/// 
/// - Suikoden II (GSD2):
///   Default vanilla values on GSD2::Field are:
///     DEFAULT_CAMERA_FOV_SIZE   = 15.0f
///     DEFAULT_CAMERA_ORTHO_SIZE = 1.2f
///   At default 125% (1.25x zoom-out), FOV is scaled to 18.75f and OrthoSize to 1.5f.
/// </summary>
public static class BattleCameraZoomPatch
{
    public const float S1VanillaCameraDefZ = -1100.0f;
    public const float S2VanillaFovSize = 15.0f;
    public const float S2VanillaOrthoSize = 1.2f;

    public static void Initialize(Harmony harmony)
    {
        try
        {
            // Suikoden 1 hooks
            harmony.PatchAll(typeof(S1BattleUpdateInitPatch));
            harmony.PatchAll(typeof(S1BattleUpdatePatch));
            harmony.PatchAll(typeof(S1BattleChapterOnDestroyPatch));

            // Suikoden 2 hooks
            harmony.PatchAll(typeof(S2FieldSetupPatch));
            harmony.PatchAll(typeof(S2FieldUpdateViewPatch));
            harmony.PatchAll(typeof(S2BattleChapterOnDestroyPatch));

            if (Plugin.Config.DetailedLogs.Value)
                Plugin.Log.LogInfo("[BattleCameraZoomPatch] Registered Suikoden 1 & 2 battle camera FOV/zoom hooks.");
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[BattleCameraZoomPatch] Failed to register hooks: {ex}");
        }
    }

    // ========================================================================
    // Suikoden 1 (GSD1) Helpers & Hooks
    // ========================================================================

    public static bool IsInBattleS1()
    {
        try
        {
            return GSD1::BattleBase.battle_work != null && GSD1::BattleChapter.classicCamera != null;
        }
        catch
        {
            return false;
        }
    }

    public static float GetS1ZoomMultiplier()
    {
        if (Plugin.Config == null || !Plugin.Config.EnableBattleCameraZoom.Value)
            return 1.0f;

        float percent = Plugin.Config.S1BattleCameraFovPercent.Value;
        if (percent <= 10f)
            return 1.0f;

        return percent / 100.0f;
    }

    public static void ApplyS1CameraZoom(bool updateTransformImmediately = false, bool logChange = false)
    {
        try
        {
            float mult = GetS1ZoomMultiplier();
            float targetZ = S1VanillaCameraDefZ * mult;

            Vector3 defPos = GSD1::BattleBase.cameraDefPos;
            defPos.z = targetZ;
            GSD1::BattleBase.cameraDefPos = defPos;

            if (updateTransformImmediately)
            {
                var classicCam = GSD1::BattleChapter.classicCamera;
                if (classicCam != null && classicCam.transform != null)
                {
                    classicCam.transform.localPosition = defPos;
                }
            }

            if (logChange && Plugin.Config != null && Plugin.Config.DetailedLogs.Value)
            {
                Plugin.Log.LogInfo($"[BattleCameraZoomPatch] Applied S1 battle zoom ({mult * 100f:F0}%): cameraDefPos.z={targetZ:F1} (vanilla {S1VanillaCameraDefZ:F1})");
            }
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[BattleCameraZoomPatch] Error applying S1 camera zoom: {ex.Message}");
        }
    }

    public static void RestoreS1VanillaCameraDefaults()
    {
        try
        {
            Vector3 defPos = GSD1::BattleBase.cameraDefPos;
            defPos.z = S1VanillaCameraDefZ;
            GSD1::BattleBase.cameraDefPos = defPos;
        }
        catch { }
    }

    /// <summary>
    /// Hooks GSD1::BattleBase.BattleUpdateInit() which runs when BattleChapter initializes
    /// its cameras and records BattleBase.cameraDefPos from BattleChapter.classicCamera.
    /// </summary>
    [HarmonyPatch(typeof(GSD1::BattleBase), nameof(GSD1::BattleBase.BattleUpdateInit))]
    public static class S1BattleUpdateInitPatch
    {
        [HarmonyPostfix]
        public static void Postfix()
        {
            if (Plugin.Config == null || !Plugin.Config.EnableBattleCameraZoom.Value)
            {
                RestoreS1VanillaCameraDefaults();
                return;
            }

            ApplyS1CameraZoom(updateTransformImmediately: true, logChange: true);
        }
    }

    /// <summary>
    /// Hooks GSD1::BattleBase.BattleUpdate() every battle frame so cameraDefPos.z stays scaled
    /// and classicCamera.transform.localPosition.z reflects the zoomed-out distance even when
    /// battle_work.scale[0] is 0 or reset.
    /// </summary>
    [HarmonyPatch(typeof(GSD1::BattleBase), nameof(GSD1::BattleBase.BattleUpdate))]
    public static class S1BattleUpdatePatch
    {
        [HarmonyPrefix]
        public static void Prefix()
        {
            if (Plugin.Config == null || !Plugin.Config.EnableBattleCameraZoom.Value)
            {
                RestoreS1VanillaCameraDefaults();
                return;
            }

            if (IsInBattleS1())
            {
                ApplyS1CameraZoom(updateTransformImmediately: false, logChange: false);
            }
        }

        [HarmonyPostfix]
        public static void Postfix()
        {
            if (Plugin.Config == null || !Plugin.Config.EnableBattleCameraZoom.Value)
                return;

            try
            {
                var bw = GSD1::BattleBase.battle_work;
                var classicCam = GSD1::BattleChapter.classicCamera;
                if (bw == null || classicCam == null || classicCam.transform == null)
                    return;

                // When m_scale[0] <= 0, BattleBase.BattleUpdate skips updating classicCamera.transform.localPosition.
                // Ensure the zoomed-out cameraDefPos is still enforced on the camera transform.
                var scaleArr = bw.m_scale;
                if (scaleArr == null || scaleArr.Length == 0 || scaleArr[0] <= 0)
                {
                    classicCam.transform.localPosition = GSD1::BattleBase.cameraDefPos;
                }
            }
            catch { }
        }
    }

    [HarmonyPatch(typeof(GSD1::BattleChapter), nameof(GSD1::BattleChapter.OnDestroy))]
    public static class S1BattleChapterOnDestroyPatch
    {
        [HarmonyPostfix]
        public static void Postfix()
        {
            RestoreS1VanillaCameraDefaults();
        }
    }

    // ========================================================================
    // Suikoden 2 (GSD2) Helpers & Hooks
    // ========================================================================

    /// <summary>
    /// Checks if Suikoden 2 is currently in an active battle.
    /// </summary>
    public static bool IsInBattleS2()
    {
        try
        {
            if (GSD2::BattleManager.IsInstance)
                return true;

            var mgr = GSD2::GRChapterManager.GRInstance;
            if (mgr != null)
            {
                if (mgr.IsBattleInitEnd())
                    return true;

                if (mgr.sys_work != null && mgr.sys_work.g_bInBattle)
                    return true;
            }
        }
        catch { }

        return false;
    }

    public static float GetS2ZoomMultiplier()
    {
        if (Plugin.Config == null || !Plugin.Config.EnableBattleCameraZoom.Value)
            return 1.0f;

        float percent = Plugin.Config.S2BattleCameraFovPercent.Value;
        if (percent <= 10f)
            return 1.0f;

        return percent / 100.0f;
    }

    public static void SyncS2BoundBattleCameras(GSD2::Field fieldInstance)
    {
        if (fieldInstance == null)
            return;

        try
        {
            BindCamera.ForceDetailSync = true;

            var fieldCam = fieldInstance.FieldCamera;
            if (fieldCam == null)
                return;

            var groundCam = fieldInstance.GroundCamera;
            if (groundCam != null)
            {
                groundCam.fieldOfView = fieldCam.fieldOfView;
                groundCam.orthographicSize = fieldCam.orthographicSize;
            }

            // FieldFrontCamera renders front-layer combat effects and character status auras
            // (such as BATTLE_CHARA.AuraAnimeDisp for the red Fury status afterimage).
            // Vanilla Field.SetupFrontCamera only copies near/far clip planes and leaves
            // FieldFrontCamera.fieldOfView at 15.0f, causing Fury auras to misalign when zoomed!
            var frontCam = fieldInstance.FieldFrontCamera;
            if (frontCam != null)
            {
                frontCam.fieldOfView = fieldCam.fieldOfView;
                frontCam.orthographicSize = fieldCam.orthographicSize;
            }

            if (fieldInstance.bindCamera != null)
                fieldInstance.bindCamera.Sync(true);
            if (fieldInstance.bindCamera2 != null)
                fieldInstance.bindCamera2.Sync(true);
        }
        catch { }
    }

    public static void ApplyS2FieldCameraZoom(GSD2::Field fieldInstance, bool logChange = false)
    {
        try
        {
            float mult = GetS2ZoomMultiplier();
            float targetFov = S2VanillaFovSize * mult;
            float targetOrtho = S2VanillaOrthoSize * mult;

            GSD2::Field.DEFAULT_CAMERA_FOV_SIZE = targetFov;
            GSD2::Field.DEFAULT_CAMERA_ORTHO_SIZE = targetOrtho;

            if (fieldInstance != null)
            {
                SyncS2BoundBattleCameras(fieldInstance);

                if (logChange && Plugin.Config != null && Plugin.Config.DetailedLogs.Value)
                {
                    Plugin.Log.LogInfo($"[BattleCameraZoomPatch] Applied S2 battle zoom ({mult * 100f:F0}%): DEFAULT_CAMERA_FOV_SIZE={targetFov:F2} (vanilla {S2VanillaFovSize}), DEFAULT_CAMERA_ORTHO_SIZE={targetOrtho:F2} (vanilla {S2VanillaOrthoSize})");
                }
            }
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[BattleCameraZoomPatch] Error applying S2 camera zoom: {ex.Message}");
        }
    }

    public static void RestoreS2VanillaCameraDefaults()
    {
        try
        {
            GSD2::Field.DEFAULT_CAMERA_FOV_SIZE = S2VanillaFovSize;
            GSD2::Field.DEFAULT_CAMERA_ORTHO_SIZE = S2VanillaOrthoSize;
            BindCamera.ForceDetailSync = false;
        }
        catch { }
    }

    /// <summary>
    /// Hooks GSD2::Field.Setup(BATTLE_WORK) at battle initialization so SetupGroundCamera
    /// and SetupFrontCamera immediately pick up the zoomed-out FOV & OrthoSize constants.
    /// </summary>
    [HarmonyPatch(typeof(GSD2::Field), nameof(GSD2::Field.Setup))]
    public static class S2FieldSetupPatch
    {
        [HarmonyPrefix]
        public static void Prefix(GSD2::Field __instance)
        {
            if (Plugin.Config == null || !Plugin.Config.EnableBattleCameraZoom.Value)
            {
                RestoreS2VanillaCameraDefaults();
                return;
            }

            float mult = GetS2ZoomMultiplier();
            GSD2::Field.DEFAULT_CAMERA_FOV_SIZE = S2VanillaFovSize * mult;
            GSD2::Field.DEFAULT_CAMERA_ORTHO_SIZE = S2VanillaOrthoSize * mult;

            if (__instance != null)
            {
                if (__instance.HDCamera != null)
                    __instance.HDCamera.fieldOfView = GSD2::Field.DEFAULT_CAMERA_FOV_SIZE;
                if (__instance.ClassicCamera != null)
                    __instance.ClassicCamera.orthographicSize = GSD2::Field.DEFAULT_CAMERA_ORTHO_SIZE;
            }
        }

        [HarmonyPostfix]
        public static void Postfix(GSD2::Field __instance)
        {
            if (Plugin.Config == null || !Plugin.Config.EnableBattleCameraZoom.Value)
                return;

            ApplyS2FieldCameraZoom(__instance, logChange: true);
        }
    }

    /// <summary>
    /// Hooks GSD2::Field.UpdateView() during active battle frames to ensure DEFAULT_CAMERA_FOV_SIZE
    /// and GroundCamera stay synchronized with the zoomed-out FieldCamera.
    /// </summary>
    [HarmonyPatch(typeof(GSD2::Field), nameof(GSD2::Field.UpdateView))]
    public static class S2FieldUpdateViewPatch
    {
        [HarmonyPrefix]
        public static void Prefix()
        {
            if (Plugin.Config == null || !Plugin.Config.EnableBattleCameraZoom.Value)
            {
                RestoreS2VanillaCameraDefaults();
                return;
            }

            if (IsInBattleS2())
            {
                float mult = GetS2ZoomMultiplier();
                GSD2::Field.DEFAULT_CAMERA_FOV_SIZE = S2VanillaFovSize * mult;
                GSD2::Field.DEFAULT_CAMERA_ORTHO_SIZE = S2VanillaOrthoSize * mult;
            }
        }

        [HarmonyPostfix]
        public static void Postfix(GSD2::Field __instance)
        {
            if (Plugin.Config == null || !Plugin.Config.EnableBattleCameraZoom.Value || __instance == null)
                return;

            SyncS2BoundBattleCameras(__instance);
        }
    }

    /// <summary>
    /// Restores vanilla camera defaults when exiting BattleChapter in Suikoden 2.
    /// </summary>
    [HarmonyPatch(typeof(GSD2::BattleChapter), nameof(GSD2::BattleChapter.OnDestroy))]
    public static class S2BattleChapterOnDestroyPatch
    {
        [HarmonyPostfix]
        public static void Postfix()
        {
            RestoreS2VanillaCameraDefaults();
        }
    }
}
