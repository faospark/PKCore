#nullable enable
extern alias GSD2;

using System;
using HarmonyLib;
using Il2CppInterop.Runtime.InteropTypes.Arrays;

namespace PKCore.Patches;

/// <summary>
/// Intercepts Apple's War Strategy Room (vk07 evmno:3) team organization overlay to offer a
/// sandboxed War Battle Replay ("Tactical Simulation") sidequest across all 16 battles while
/// keeping story flags, army rosters, and unit life/death state intact.
/// </summary>
public static class S2WarReplayPatch
{
    private enum ReplayHubPhase
    {
        Inactive,
        WaitingForMenuReady,
        InCustomMenu,
        PassthroughOrganize
    }

    private sealed class GameWorkSnapshot
    {
        public byte[]? CharaFlag { get; init; }
        public byte[]? EventFlag { get; init; }
        public byte[]? LeaderNo { get; init; }
        public byte[]? SubNo { get; init; }
        public sbyte[]? SubToLeader { get; init; }

        public static GameWorkSnapshot? Capture(GSD2::GAME_WORK? gw)
        {
            if (gw == null) return null;
            return new GameWorkSnapshot
            {
                CharaFlag = CopyBytes(gw.chara_flag),
                EventFlag = CopyBytes(gw.event_flag),
                LeaderNo = CopyBytes(gw.war_data?.leader_no),
                SubNo = CopyBytes(gw.war_data?.sub_no),
                SubToLeader = CopySBytes(gw.war_data?.sub_to_leader)
            };
        }

        public void Restore(GSD2::GAME_WORK? gw)
        {
            if (gw == null) return;
            RestoreBytes(CharaFlag, gw.chara_flag);
            RestoreBytes(EventFlag, gw.event_flag);
            if (gw.war_data != null)
            {
                RestoreBytes(LeaderNo, gw.war_data.leader_no);
                RestoreBytes(SubNo, gw.war_data.sub_no);
                RestoreSBytes(SubToLeader, gw.war_data.sub_to_leader);
            }
        }

        private static byte[]? CopyBytes(Il2CppStructArray<byte>? src)
        {
            if (src == null) return null;
            var dst = new byte[src.Length];
            for (int i = 0; i < dst.Length; i++)
                dst[i] = src[i];
            return dst;
        }

        private static sbyte[]? CopySBytes(Il2CppStructArray<sbyte>? src)
        {
            if (src == null) return null;
            var dst = new sbyte[src.Length];
            for (int i = 0; i < dst.Length; i++)
                dst[i] = src[i];
            return dst;
        }

        private static void RestoreBytes(byte[]? src, Il2CppStructArray<byte>? dst)
        {
            if (src == null || dst == null) return;
            int count = Math.Min(src.Length, dst.Length);
            for (int i = 0; i < count; i++)
                dst[i] = src[i];
        }

        private static void RestoreSBytes(sbyte[]? src, Il2CppStructArray<sbyte>? dst)
        {
            if (src == null || dst == null) return;
            int count = Math.Min(src.Length, dst.Length);
            for (int i = 0; i < count; i++)
                dst[i] = src[i];
        }
    }

    private static ReplayHubPhase _phase = ReplayHubPhase.Inactive;
    private static GameWorkSnapshot? _pendingSnapshot;
    private static GameWorkSnapshot? _replaySnapshot;
    private static bool _isReplayActive;
    private static int _pendingLaunchWarNo;

    private static bool IsEnabled => Plugin.Config?.EnableWarReplaySidequest?.Value == true;

    private static bool IsAppleWarRoomContext(GSD2::MACHICON? mcon)
    {
        if (mcon == null) return false;
        string name = mcon.GetMapName() ?? "";
        return name.Contains("vk07", StringComparison.OrdinalIgnoreCase)
               && name.Contains("evmno:3", StringComparison.OrdinalIgnoreCase);
    }

    private static void LogDebug(string msg)
    {
        if (Plugin.Config?.DetailedLogs?.Value == true)
            Plugin.Log?.LogInfo($"[S2WarReplay] {msg}");
    }

    private static void ArmReplayLaunch(GSD2::Overlay_teamchg overlay, int warNo)
    {
        var gw = GSD2::OldSrcBase.game_work;
        if (_pendingSnapshot != null)
        {
            // Undo ActSetDefaultTeam() side-effects made during teamchg_init before snapshotting/launching
            _pendingSnapshot.Restore(gw);
            _replaySnapshot = _pendingSnapshot;
            _pendingSnapshot = null;
        }
        else
        {
            _replaySnapshot = GameWorkSnapshot.Capture(gw);
        }

        _isReplayActive = true;
        _pendingLaunchWarNo = warNo;
        _phase = ReplayHubPhase.Inactive;

        if (overlay.dw != null)
            overlay.dw.step = 4;

        LogDebug($"Armed simulation launch for war_no={warNo}.");
    }

    private static void CancelFromCustomMenu(GSD2::Overlay_teamchg overlay)
    {
        if (_pendingSnapshot != null)
        {
            _pendingSnapshot.Restore(GSD2::OldSrcBase.game_work);
            _pendingSnapshot = null;
        }

        _phase = ReplayHubPhase.Inactive;
        if (overlay.dw != null)
            overlay.dw.step = 4;

        LogDebug("Cancelled War Room menu and restored pre-entry state.");
    }

    private static void CompleteReplayCleanup(bool showToast, bool wasDefeat)
    {
        try
        {
            GSD2::war_sys.game_over_flag = 0;
            if (_replaySnapshot != null)
            {
                _replaySnapshot.Restore(GSD2::OldSrcBase.game_work);
                _replaySnapshot = null;
            }
        }
        catch (Exception ex)
        {
            Plugin.Log?.LogError($"[S2WarReplay] Failed to restore snapshot: {ex}");
        }
        finally
        {
            _isReplayActive = false;
            _pendingLaunchWarNo = 0;
        }

        if (showToast)
        {
            string msg = wasDefeat
                ? "Simulation ended in defeat \u2014 all units and story flags restored."
                : "Simulation complete \u2014 all units and story flags restored.";
            S2WarReplayMenu.ShowToast(msg);
        }

        LogDebug($"Replay ended (wasDefeat={wasDefeat}); GAME_WORK restored.");
    }

    [HarmonyPatch(typeof(GSD2::Overlay_teamchg), "Entry")]
    [HarmonyPrefix]
    private static void OverlayTeamChg_Entry_Prefix(GSD2::Overlay_teamchg __instance)
    {
        _phase = ReplayHubPhase.Inactive;
        _pendingSnapshot = null;

        if (!IsEnabled || _isReplayActive) return;
        if (!IsAppleWarRoomContext(__instance.mcon)) return;

        // Capture GAME_WORK before teamchg_init() invokes Defc_set.ActSetDefaultTeam()
        _pendingSnapshot = GameWorkSnapshot.Capture(GSD2::OldSrcBase.game_work);
        _phase = ReplayHubPhase.WaitingForMenuReady;
        LogDebug($"Intercepted Apple War Room overlay ({__instance.mcon?.GetMapName()}).");
    }

    [HarmonyPatch(typeof(GSD2::Overlay_teamchg), "TeamChgMain")]
    [HarmonyPrefix]
    private static bool OverlayTeamChg_TeamChgMain_Prefix(GSD2::Overlay_teamchg __instance, ref int __result)
    {
        if (_phase == ReplayHubPhase.Inactive || _phase == ReplayHubPhase.PassthroughOrganize)
            return true;

        var dw = __instance.dw;
        if (dw == null)
        {
            _phase = ReplayHubPhase.Inactive;
            return true;
        }

        if (_phase == ReplayHubPhase.WaitingForMenuReady)
        {
            // step 0 loads Tc_main resources and advances to step 1 prior to FilterBlackIn fade
            if (dw.step == 0)
                return true;

            if (dw.step != 1)
            {
                _phase = ReplayHubPhase.Inactive;
                _pendingSnapshot = null;
                return true;
            }

            _phase = ReplayHubPhase.InCustomMenu;
            S2WarReplayMenu.OpenHub(
                onOrganize: () =>
                {
                    _pendingSnapshot = null;
                    _phase = ReplayHubPhase.PassthroughOrganize;
                    LogDebug("Passing through to native Army Organize screen.");
                },
                onReplayBattle: warNo => ArmReplayLaunch(__instance, warNo),
                onCancel: () => CancelFromCustomMenu(__instance)
            );

            __result = 0;
            return false;
        }

        if (_phase == ReplayHubPhase.InCustomMenu)
        {
            if (!S2WarReplayMenu.IsOpen)
            {
                CancelFromCustomMenu(__instance);
                return true;
            }

            __result = 0;
            return false;
        }

        return true;
    }

    [HarmonyPatch(typeof(GSD2::MACHICON), nameof(GSD2::MACHICON.MachiMain))]
    [HarmonyPostfix]
    private static void MACHICON_MachiMain_Postfix(GSD2::MACHICON __instance)
    {
        if (_phase != ReplayHubPhase.Inactive && __instance.ol_func == null)
        {
            if (S2WarReplayMenu.IsOpen)
                S2WarReplayMenu.Close();

            if (_phase == ReplayHubPhase.InCustomMenu && _pendingSnapshot != null)
                _pendingSnapshot.Restore(GSD2::OldSrcBase.game_work);

            _pendingSnapshot = null;
            _phase = ReplayHubPhase.Inactive;
        }

        if (_pendingLaunchWarNo <= 0 || __instance.ol_func != null)
            return;

        int warNo = _pendingLaunchWarNo;
        _pendingLaunchWarNo = 0;

        try
        {
            var sys = GSD2::OldSrcBase.sys_work;
            if (sys == null)
            {
                Plugin.Log?.LogError("[S2WarReplay] sys_work is null; aborting simulation launch.");
                CompleteReplayCleanup(showToast: false, wasDefeat: false);
                return;
            }

            // Preserve Apple War Room coordinates; fallback only if unset
            if (__instance.px <= 0 && __instance.py <= 0)
            {
                __instance.px = 60 << 3;
                __instance.py = 53 << 3;
            }

            sys.war_no = (byte)warNo;
            __instance.econ?.EventGameWorkSet(__instance);
            GSD2::OldSrcBase.SD_AllBgmFadeOut(0.5f);
            __instance.mstep = 0x2d;

            LogDebug($"Started native map-to-war transition (war_no={warNo}, mstep=0x2d).");
        }
        catch (Exception ex)
        {
            Plugin.Log?.LogError($"[S2WarReplay] Failed to start war transition: {ex}");
            CompleteReplayCleanup(showToast: false, wasDefeat: false);
        }
    }

    [HarmonyPatch(typeof(GSD2::w_dead), nameof(GSD2::w_dead.CheckDead))]
    [HarmonyPrefix]
    private static bool w_dead_CheckDead_Prefix(ref int __result)
    {
        if (!_isReplayActive)
            return true;

        // Suppress permanent character death / chara_flag stripping during tactical simulations
        __result = 0;
        return false;
    }

    [HarmonyPatch(typeof(GSD2::WarChapter), nameof(GSD2::WarChapter.Update))]
    [HarmonyPostfix]
    private static void WarChapter_Update_Postfix(ref int __result)
    {
        if (!_isReplayActive || __result == 0)
            return;

        bool wasDefeat = __result == 2 || GSD2::war_sys.game_over_flag != 0;
        // Rewrite defeat (2 -> GameOverChapter) back to MapChapter return (1)
        __result = 1;
        CompleteReplayCleanup(showToast: true, wasDefeat: wasDefeat);
    }

    [HarmonyPatch(typeof(GSD2::WarChapter), nameof(GSD2::WarChapter.OnDestroy))]
    [HarmonyPostfix]
    private static void WarChapter_OnDestroy_Postfix()
    {
        if (_isReplayActive && _pendingLaunchWarNo <= 0)
        {
            CompleteReplayCleanup(showToast: false, wasDefeat: false);
        }
    }
}
