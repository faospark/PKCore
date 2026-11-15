#nullable enable
extern alias GSD2;

using System;
using HarmonyLib;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Share.UI.Window;
using UnityEngine;

namespace PKCore.Patches;

/// <summary>
/// Hooks speaking to Klaus in Dunan Castle's War Strategy Room (vk07) to offer a
/// sandboxed War Battle Replay ("Tactical Simulation") sidequest across all 16 battles while
/// keeping story flags, army rosters, and unit life/death state intact.
/// </summary>
public static class S2WarReplayPatch
{
    private enum ReplayHubPhase
    {
        Inactive,
        InCustomMenu
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
    private static bool _pendingKlausReplay;
    private static UIMessageWindow? _klausMessageWindow;

    private static bool IsEnabled => Plugin.Config?.EnableWarReplaySidequest?.Value == true;

    private static bool IsKlausWarRoomContext(GSD2::MACHICON? mcon)
    {
        var activeMcon = mcon ?? MACHICON_OnMapInitPatch.CurrentMachicon;
        string name = activeMcon?.GetMapName() ?? "";
        if (!string.IsNullOrEmpty(name))
        {
            return name.Contains("vk07", StringComparison.OrdinalIgnoreCase);
        }
        return MACHICON_OnMapInitPatch.CurrentMapId.StartsWith("vk07", StringComparison.OrdinalIgnoreCase);
    }

    private static void LogDebug(string msg)
    {
        if (Plugin.Config?.DetailedLogs?.Value == true)
            Plugin.Log?.LogInfo($"[S2WarReplay] {msg}");
    }

    private static void ArmKlausReplayLaunch(int warNo)
    {
        var gw = GSD2::OldSrcBase.game_work;
        if (_pendingSnapshot != null)
        {
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

        Plugin.Log?.LogInfo($"[S2WarReplay] Armed simulation launch for war_no={warNo} from Klaus.");
    }

    private static void CancelFromKlausMenu()
    {
        if (_pendingSnapshot != null)
        {
            _pendingSnapshot.Restore(GSD2::OldSrcBase.game_work);
            _pendingSnapshot = null;
        }

        _phase = ReplayHubPhase.Inactive;
        LogDebug("Cancelled Klaus War Replay menu and restored pre-entry state.");
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

    [HarmonyPatch(typeof(UIMessageWindow), nameof(UIMessageWindow.OpenMessageWindow))]
    [HarmonyPatch(new[] { typeof(Sprite), typeof(string), typeof(string), typeof(Vector3), typeof(bool) })]
    [HarmonyPostfix]
    private static void OpenMessageWindow_Postfix(UIMessageWindow __instance, string name)
    {
        if (!IsEnabled || _isReplayActive || S2WarReplayMenu.IsOpen)
            return;

        if (!IsKlausWarRoomContext(null))
            return;

        if (!string.Equals(name?.Trim(), "Klaus", StringComparison.OrdinalIgnoreCase))
            return;

        if (!_pendingKlausReplay)
            Plugin.Log?.LogInfo("[S2WarReplay] Detected Klaus dialogue in vk07; queuing War Battle Replay menu.");

        _pendingKlausReplay = true;
        _klausMessageWindow = __instance;
    }

    [HarmonyPatch(typeof(GSD2::MACHICON), nameof(GSD2::MACHICON.MachiMain))]
    [HarmonyPrefix]
    private static bool MACHICON_MachiMain_Prefix(GSD2::MACHICON __instance)
    {
        if (_phase == ReplayHubPhase.InCustomMenu)
        {
            if (!S2WarReplayMenu.IsOpen)
            {
                if (_pendingSnapshot != null)
                    _pendingSnapshot.Restore(GSD2::OldSrcBase.game_work);
                _pendingSnapshot = null;
                _phase = ReplayHubPhase.Inactive;
                return true;
            }

            return false;
        }

        if (_pendingKlausReplay && __instance.ol_func == null)
        {
            bool dialogStillOpen = _klausMessageWindow != null && _klausMessageWindow.IsOpen;
            if (!dialogStillOpen)
            {
                _pendingKlausReplay = false;
                _klausMessageWindow = null;

                if (IsEnabled && !_isReplayActive && IsKlausWarRoomContext(__instance))
                {
                    _pendingSnapshot = GameWorkSnapshot.Capture(GSD2::OldSrcBase.game_work);
                    _phase = ReplayHubPhase.InCustomMenu;
                    S2WarReplayMenu.OpenSelectorDirect(
                        onReplayBattle: ArmKlausReplayLaunch,
                        onCancel: CancelFromKlausMenu
                    );
                    return false;
                }
            }
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

            // Preserve Klaus War Room coordinates; fallback only if unset
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
