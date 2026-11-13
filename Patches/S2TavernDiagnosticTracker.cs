extern alias GSD2;

using System;
using System.Diagnostics;
using HarmonyLib;
using Share.UI.Window;
using UnityEngine;

namespace PKCore.Patches;

/// <summary>
/// Comprehensive Real-Time Forensic Diagnostics Tracker for Dunan Castle Tavern (vk08).
/// Logs every map load, entity placement, flag state, event execution, overlay call, and dialogue message.
/// </summary>
public static class S2TavernDiagnosticTracker
{
    public static bool IsInTavern =>
        !string.IsNullOrEmpty(MACHICON_OnMapInitPatch.CurrentMapId) &&
        MACHICON_OnMapInitPatch.CurrentMapId.StartsWith("vk08", StringComparison.OrdinalIgnoreCase);

    /// <summary>
    /// Dumps complete tavern state on map load or submap transition.
    /// </summary>
    public static void LogTavernSnapshot(string context)
    {
        if (!IsInTavern) return;

        try
        {
            var mcon = MACHICON_OnMapInitPatch.CurrentMachicon;
            var gw = GSD2::OldSrcBase.game_work;

            int px = mcon != null ? mcon.px : -1;
            int py = mcon != null ? mcon.py : -1;
            int mx = mcon != null ? mcon.mx : -1;
            int my = mcon != null ? mcon.my : -1;

            byte f143 = (gw != null && gw.event_flag != null && gw.event_flag.Length > 143) ? gw.event_flag[143] : (byte)0xFF;
            byte f144 = (gw != null && gw.event_flag != null && gw.event_flag.Length > 144) ? gw.event_flag[144] : (byte)0xFF;
            byte f134 = (gw != null && gw.event_flag != null && gw.event_flag.Length > 134) ? gw.event_flag[134] : (byte)0xFF;
            byte f112 = (gw != null && gw.event_flag != null && gw.event_flag.Length > 112) ? gw.event_flag[112] : (byte)0xFF;
            byte f115 = (gw != null && gw.event_flag != null && gw.event_flag.Length > 115) ? gw.event_flag[115] : (byte)0xFF;
            byte f46  = (gw != null && gw.event_flag != null && gw.event_flag.Length > 46)  ? gw.event_flag[46]  : (byte)0xFF;
            byte f186 = (gw != null && gw.event_flag != null && gw.event_flag.Length > 186) ? gw.event_flag[186] : (byte)0xFF;
            int baseLv = (gw != null && gw.game_data != null) ? (int)gw.game_data.base_lv : -1;

            string mapId = MACHICON_OnMapInitPatch.CurrentMapId;
            string rawName = mcon != null ? mcon.GetMapName() : "unknown";

            Plugin.Log.LogInfo("==========================================================================");
            Plugin.Log.LogInfo(string.Format("[vk08 Tracker] SNAPSHOT [{0}] -> Map: {1} (Raw: '{2}')", context, mapId, rawName));
            Plugin.Log.LogInfo(string.Format("[vk08 Tracker] BaseLv: {0} | [143]=0x{1:X2} (BeastRuneBit: {2}) | [144]=0x{3:X2} (MaidBit: {4}) | [134]=0x{5:X2} (EndGate: {6})",
                baseLv, f143, f143 & 1, f144, f144 & 4, f134, f134 & 1));
            Plugin.Log.LogInfo(string.Format("[vk08 Tracker] Other Flags: [186]=0x{0:X2}, [112]=0x{1:X2}, [115]=0x{2:X2}, [46]=0x{3:X2}", f186, f112, f115, f46));
            Plugin.Log.LogInfo(string.Format("[vk08 Tracker] Player: Tile({0}, {1}) | Pixel({2}, {3})", px, py, mx, my));

            var econ = MachiLoader_Load_Patch.LastLoadedEventcon;
            if (econ != null && econ.ehuman != null)
            {
                Plugin.Log.LogInfo(string.Format("[vk08 Tracker] Active Live Entities ({0} slots):", econ.ehuman.Count));
                for (int i = 0; i < econ.ehuman.Count; i++)
                {
                    var h = econ.ehuman[i];
                    if (h == null) continue;

                    string fpDesc = h.fpno == 91 ? " [LEONA]" : (h.fpno == 65085 ? " [MAID]" : "");
                    string dirDesc = h.ano == 0 ? "South" : (h.ano == 1 ? "West" : (h.ano == 2 ? "North" : (h.ano == 3 ? "East" : h.ano.ToString())));
                    
                    Plugin.Log.LogInfo(string.Format("   human[{0:D2}]: fpno={1,5}{2,-8} | pos=({3,3}, {4,3}) | dir={5,-5} | disp={6} | ozok={7}",
                        i, h.fpno, fpDesc, h.ex, h.ey, dirDesc, h.disp, h.ozok));
                }
            }
            Plugin.Log.LogInfo("==========================================================================");
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError(string.Format("[vk08 Tracker] Error generating tavern snapshot: {0}", ex));
        }
    }
}

/// <summary>
/// Hooks map entry and initialization events on vk08.
/// </summary>
[HarmonyPatch(typeof(MACHICON), "OnMapInit")]
public static class S2TavernMapInitTracker
{
    [HarmonyPostfix]
    public static void Postfix(MACHICON __instance)
    {
        S2TavernDiagnosticTracker.LogTavernSnapshot("MACHICON.OnMapInit Postfix");
    }
}

/// <summary>
/// Hooks EventInit to capture when event controllers bind map data.
/// </summary>
[HarmonyPatch(typeof(MACHICON), "EventInit")]
public static class S2TavernEventInitTracker
{
    [HarmonyPostfix]
    public static void Postfix(MACHICON __instance, GSD2::EVENTCON __result)
    {
        S2TavernDiagnosticTracker.LogTavernSnapshot("MACHICON.EventInit Postfix");
    }
}

/// <summary>
/// Hooks eventFlgCHK to trace every flag evaluated in vk08 with caller info.
/// </summary>
[HarmonyPatch(typeof(GSD2::GAME_WORK), nameof(GSD2::GAME_WORK.eventFlgCHK))]
public static class S2TavernEventFlgCHKTracker
{
    [HarmonyPostfix]
    public static void Postfix(int _fno, byte _bno, bool __result)
    {
        if (S2TavernDiagnosticTracker.IsInTavern)
        {
            string caller = "unknown";
            try
            {
                var frame = new StackTrace(2, false).GetFrame(0);
                if (frame != null && frame.GetMethod() != null)
                {
                    caller = frame.GetMethod().DeclaringType?.Name + "." + frame.GetMethod().Name;
                }
            }
            catch {}
            Plugin.Log.LogInfo(string.Format("[vk08 Tracker] eventFlgCHK(no={0}, bit=0x{1:X2}) => {2} [Caller: {3}]", _fno, _bno, __result, caller));
        }
    }
}

/// <summary>
/// Hooks eventFlgCHK2 to trace every secondary flag evaluated in vk08 with caller info.
/// </summary>
[HarmonyPatch(typeof(GSD2::GAME_WORK), nameof(GSD2::GAME_WORK.eventFlgCHK2))]
public static class S2TavernEventFlgCHK2Tracker
{
    [HarmonyPostfix]
    public static void Postfix(int _fno, byte _bno, bool __result)
    {
        if (S2TavernDiagnosticTracker.IsInTavern)
        {
            string caller = "unknown";
            try
            {
                var frame = new StackTrace(2, false).GetFrame(0);
                if (frame != null && frame.GetMethod() != null)
                {
                    caller = frame.GetMethod().DeclaringType?.Name + "." + frame.GetMethod().Name;
                }
            }
            catch {}
            Plugin.Log.LogInfo(string.Format("[vk08 Tracker] eventFlgCHK2(no={0}, bit=0x{1:X2}) => {2} [Caller: {3}]", _fno, _bno, __result, caller));
        }
    }
}

/// <summary>
/// Hooks UIMessageWindow.OpenMessageWindow to log exact dialogue text, speaker name, and portrait (logged once per message).
/// </summary>
[HarmonyPatch(typeof(UIMessageWindow), nameof(UIMessageWindow.OpenMessageWindow))]
[HarmonyPatch(new[] { typeof(Sprite), typeof(string), typeof(string), typeof(Vector3), typeof(bool) })]
public static class S2TavernMessageWindowTracker
{
    [HarmonyPrefix]
    public static void Prefix(Sprite faceImage, string name, string message, Vector3 pos, bool isHD)
    {
        if (S2TavernDiagnosticTracker.IsInTavern)
        {
            string portraitName = faceImage != null ? faceImage.name : "None";
            Plugin.Log.LogInfo(string.Format("[vk08 Tracker] >>> OpenMessageWindow: Speaker='{0}' | Message='{1}' | Portrait='{2}' | isHD={3}",
                name, message, portraitName, isHD));
        }
    }
}

/// <summary>
/// Hooks SelectTSR to log when Tavern Service selection overlay runs.
/// </summary>
[HarmonyPatch(typeof(GSD2::EventOverlayClass.SelectTSR), "Entry")]
public static class S2TavernSelectTSREntryTracker
{
    [HarmonyPrefix]
    public static void Prefix()
    {
        if (S2TavernDiagnosticTracker.IsInTavern)
        {
            Plugin.Log.LogInfo("[vk08 Tracker] >>> EventOverlayClass.SelectTSR.Entry() CALLED!");
        }
    }
}

/// <summary>
/// Hooks select_tsr_serifu to log dialogue selection for tavern services.
/// </summary>
[HarmonyPatch(typeof(GSD2::EventOverlayClass.select_tsr_serifu), "Entry")]
public static class S2TavernSelectTsrSerifuTracker
{
    [HarmonyPrefix]
    public static void Prefix()
    {
        if (S2TavernDiagnosticTracker.IsInTavern)
        {
            Plugin.Log.LogInfo("[vk08 Tracker] >>> EventOverlayClass.select_tsr_serifu.Entry() CALLED!");
        }
    }
}

/// <summary>
/// Hooks Overlay_partyin to log when party organization interface opens.
/// </summary>
[HarmonyPatch(typeof(GSD2::EventOverlayClass.Overlay_partyin), "Entry")]
public static class S2TavernPartyInTracker
{
    [HarmonyPrefix]
    public static void Prefix()
    {
        if (S2TavernDiagnosticTracker.IsInTavern)
        {
            Plugin.Log.LogInfo("[vk08 Tracker] >>> EventOverlayClass.Overlay_partyin.Entry() CALLED!");
        }
    }
}
