using System;
using HarmonyLib;
using UnityEngine;

namespace PKCore.Patches;

/// <summary>
/// Adjusts the camera Field of View (FOV) in towns and indoor maps for both Suikoden I and Suikoden II.
/// Both games use CameraManager.Type.HDMap in GSDShare for town/indoor scenes.
/// </summary>
[HarmonyPatch]
public static class TownFOVPatch
{
    public static bool IsEnabled => Plugin.Config?.EnableTownFOV?.Value ?? true;
    public static float TargetFOV => Plugin.Config?.TownFOV?.Value ?? 110.0f;

    public static void Initialize(Harmony harmony)
    {
        harmony.PatchAll(typeof(TownFOVPatch));
    }

    /// <summary>
    /// Per-frame check to ensure FOV is kept locked at target value during town exploration,
    /// interior transitions, and cutscenes without jitter.
    /// </summary>
    public static void Update()
    {
        if (!IsEnabled) return;

        try
        {
            var mgr = CameraManager.Instance;
            if (mgr == null || mgr.CurrentType != CameraManager.Type.HDMap)
                return;

            float targetFov = TargetFOV;
            var activeCam = mgr.ActiveCamera;
            if (activeCam != null && !activeCam.orthographic)
            {
                if (Mathf.Abs(activeCam.fieldOfView - targetFov) > 0.05f)
                {
                    ApplyTownFOV(activeCam, targetFov);
                    ApplyToAllTownCameras(targetFov);
                }
            }
        }
        catch { }
    }

    /// <summary>
    /// Applies target FOV to a specific perspective camera while skipping UI/font cameras.
    /// </summary>
    public static void ApplyTownFOV(UnityEngine.Camera cam, float targetFov)
    {
        if (cam == null || cam.orthographic) return;
        string name = cam.name ?? "";
        if (name.IndexOf("UI", StringComparison.OrdinalIgnoreCase) >= 0) return;
        if (name.IndexOf("Font", StringComparison.OrdinalIgnoreCase) >= 0) return;

        if (Mathf.Abs(cam.fieldOfView - targetFov) > 0.05f)
        {
            cam.fieldOfView = targetFov;
        }
    }

    /// <summary>
    /// Synchronizes target FOV across all town rendering cameras and bound cameras.
    /// </summary>
    public static void ApplyToAllTownCameras(float targetFov)
    {
        var mgr = CameraManager.Instance;
        if (mgr == null || mgr.CurrentType != CameraManager.Type.HDMap) return;

        if (mgr.ActiveCamera != null)
            ApplyTownFOV(mgr.ActiveCamera, targetFov);
        if (mgr.noFilterCamera != null)
            ApplyTownFOV(mgr.noFilterCamera, targetFov);

        var boundList = BindCamera.activeCameras;
        if (boundList != null)
        {
            for (int i = 0; i < boundList.Count; i++)
            {
                var b = boundList[i];
                if (b != null)
                {
                    if (b.bindTarget != null) ApplyTownFOV(b.bindTarget, targetFov);
                    if (b.myCamera != null) ApplyTownFOV(b.myCamera, targetFov);
                }
            }
        }
    }

    /// <summary>
    /// Immediately applies the target FOV upon synchronous camera instantiation.
    /// </summary>
    [HarmonyPatch(typeof(CameraManager), nameof(CameraManager.ChangeCameraJust))]
    [HarmonyPostfix]
    public static void OnChangeCameraJust(CameraManager.Type type, Transform par)
    {
        if (!IsEnabled) return;
        if (type == CameraManager.Type.HDMap)
        {
            ApplyToAllTownCameras(TargetFOV);
            BindCamera.ForceDetailSync = true;
        }
    }

    /// <summary>
    /// Ensures secondary cameras (depth, foreground, effects) maintain the town FOV
    /// when BindCamera synchronization occurs.
    /// </summary>
    [HarmonyPatch(typeof(BindCamera), nameof(BindCamera.Sync))]
    [HarmonyPostfix]
    public static void OnBindCameraSync(BindCamera __instance, bool isDetailCopy)
    {
        if (!IsEnabled) return;
        var mgr = CameraManager.Instance;
        if (mgr == null || mgr.CurrentType != CameraManager.Type.HDMap) return;

        if (__instance != null && __instance.myCamera != null)
        {
            ApplyTownFOV(__instance.myCamera, TargetFOV);
        }
    }
}
