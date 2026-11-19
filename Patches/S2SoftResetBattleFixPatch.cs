extern alias GSD2;

using System;
using HarmonyLib;
using UnityEngine;

namespace PKCore.Patches;

/// <summary>
/// Fixes a NullReferenceException in GSD2::BATTLE_WORK.PreRelease() when entering a Suikoden II
/// battle after performing a soft reset (such as Suikoden Fix's ResetGamePatch).
///
/// Root Cause:
/// During a soft reset, the Unity scene is torn down (destroying BATTLE_WORK.ui_effect_parent),
/// while Singleton&lt;BATTLE_WORK&gt; remains instantiated in memory. On the next battle,
/// BattleManager.Create() calls BATTLE_WORK.Instance.PreRelease() before ReleaseInstance(),
/// which unconditionally dereferences ui_effect_parent.transform.parent.gameObject.
/// </summary>
[HarmonyPatch(typeof(GSD2::BATTLE_WORK), nameof(GSD2::BATTLE_WORK.PreRelease))]
public static class S2SoftResetBattleFixPatch
{
    [HarmonyPrefix]
    public static bool Prefix(GSD2::BATTLE_WORK __instance)
    {
        try
        {
            if (__instance == null)
                return false;

            var uiEffectParent = __instance.ui_effect_parent;
            if (uiEffectParent == null)
            {
                if (Plugin.Config != null && Plugin.Config.DetailedLogs.Value)
                    Plugin.Log.LogInfo("[S2SoftResetBattleFix] Skipped BATTLE_WORK.PreRelease on destroyed/null ui_effect_parent after soft reset.");
                return false;
            }

            var tr = uiEffectParent.transform;
            var parent = tr != null ? tr.parent : null;
            var parentGo = parent != null ? parent.gameObject : null;
            if (parentGo == null)
            {
                UnityEngine.Object.Destroy(uiEffectParent);
                if (Plugin.Config != null && Plugin.Config.DetailedLogs.Value)
                    Plugin.Log.LogInfo("[S2SoftResetBattleFix] Destroyed orphaned ui_effect_parent without parent transform after soft reset.");
                return false;
            }

            return true;
        }
        catch (Exception ex)
        {
            Plugin.Log.LogWarning($"[S2SoftResetBattleFix] Suppressed exception during BATTLE_WORK.PreRelease: {ex.Message}");
            return false;
        }
    }
}
