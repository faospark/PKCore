extern alias GSD2;

using System;
using HarmonyLib;
using Il2CppInterop.Runtime.InteropTypes.Arrays;

namespace PKCore.Patches;

/// <summary>
/// Restores re-entry into Muse City Hall (vc09_00 / vc27_00) where Mayor Annabelle's office,
/// the high council chamber, and the 2nd-floor library archive (Old Book Vol. 4) are located.
/// 
/// Supports re-entry across all storyline phases:
/// 1. Ruined Muse City streets (vc26_01) post-fall (entrance at X: 101..107, Y: 18..19).
/// 2. Liberated Muse City streets (vc25_01 / vc25_02) post-liberation (entrance at X: 101..107, Y: 18..19).
/// 3. Jowston Hill State Council Hall Courtyard (vc31_00) (entrance at X: 23..32, Y: 35..36).
/// 4. Early-game / Active Muse City streets (vc01_01) (entrance at X: 101..107, Y: 18..19).
/// 
/// Inside City Hall (vc09_00 / vc27_00), configures the south lobby exit double doors
/// at (X: 161..165, Y: 111..112) to return Riou to the appropriate exterior map (vc26, vc25, vc31, or vc01).
/// </summary>
[HarmonyPatch(typeof(MACHICON), "EventInit")]
public static class LiberatedMuseCityHallPatch
{
    private static bool _loggedVc01 = false;
    private static bool _loggedVc26 = false;
    private static bool _loggedVc25 = false;
    private static bool _loggedVc31 = false;
    private static bool _loggedVc09 = false;
    private static bool _loggedVc27 = false;

    /// <summary>
    /// Tracks which exterior map Riou entered City Hall from ("vc26", "vc25", "vc31", or "vc01")
    /// so the lobby exit doorway returns Riou to the appropriate map.
    /// </summary>
    public static string LastExteriorMap { get; set; } = "vc26";

    [HarmonyPostfix]
    public static void Postfix(MACHICON __instance, EVENTCON __result)
    {
        if (__result == null || __result.mdat?.eventdata?.mapeventdat == null) return;
        if (!Plugin.Config.UnlockLiberatedMuseCityHall.Value) return;

        string mapId = MACHICON_OnMapInitPatch.CurrentMapId;
        if (string.IsNullOrEmpty(mapId) && __instance != null)
        {
            string raw = __instance.GetMapName();
            if (!string.IsNullOrEmpty(raw))
                mapId = raw.Split(' ')[0];
        }

        try
        {
            var mapeventdat = __result.mdat.eventdata.mapeventdat;

            // -------------------------------------------------------------
            // Case 0: Normal Muse City Streets (vc01) - Track Context
            // -------------------------------------------------------------
            bool isVc01 = (!string.IsNullOrEmpty(mapId) && mapId.StartsWith("vc01", StringComparison.OrdinalIgnoreCase))
                || string.Equals(__result.mdat.name, "vc01", StringComparison.OrdinalIgnoreCase);

            if (isVc01)
            {
                LastExteriorMap = "vc01";
                if (!_loggedVc01)
                {
                    _loggedVc01 = true;
                    Plugin.Log.LogInfo("[PKCore] Muse City Plaza (vc01) context tracked for City Hall re-entry.");
                }
                return;
            }

            // -------------------------------------------------------------
            // Case 1: Ruined Muse City Streets (vc26) - Central Town City Hall
            // -------------------------------------------------------------
            bool isVc26 = (!string.IsNullOrEmpty(mapId) && mapId.StartsWith("vc26", StringComparison.OrdinalIgnoreCase))
                || string.Equals(__result.mdat.name, "vc26", StringComparison.OrdinalIgnoreCase);

            if (isVc26 && mapeventdat.Count > 1)
            {
                LastExteriorMap = "vc26";
                var sub1 = mapeventdat[1]; // vc26_01
                if (sub1?.eventdat != null)
                {
                    bool doorPatched = false;

                    // Check for existing doorway at (101..107, 18..19)
                    for (int i = 0; i < sub1.eventdat.Length; i++)
                    {
                        var ev = sub1.eventdat[i];
                        if (ev?.eventForm == null) continue;
                        var f = ev.eventForm;

                        for (int k = 0; k < f.Length - 5; k++)
                        {
                            if (f[k] == 1 && f[k + 1] == 101 && f[k + 2] == 107 && f[k + 4] == 18 && f[k + 5] == 19)
                            {
                                ev.eventForm = new byte[] { 1, 101, 107, 2, 18, 19, 9, 1, 255, 254 };
                                ev.eventCom = new byte[] { 31, 1, 2, 8, 32, 2, 0, 163, 110, 255, 254 };
                                doorPatched = true;
                                break;
                            }
                        }
                        if (doorPatched) break;
                    }

                    // If not found in existing scripts, expand eventdat array and inject the door script
                    if (!doorPatched)
                    {
                        int oldLen = sub1.eventdat.Length;
                        var newEvents = new Il2CppReferenceArray<GSD2::EVENT_WK>(oldLen + 1);
                        for (int i = 0; i < oldLen; i++)
                            newEvents[i] = sub1.eventdat[i];

                        var doorEv = new GSD2::EVENT_WK();
                        doorEv.etyp = 1; // Action/Step
                        doorEv.eventForm = new byte[] { 1, 101, 107, 2, 18, 19, 9, 1, 255, 254 };
                        doorEv.eventCom = new byte[] { 31, 1, 2, 8, 32, 2, 0, 163, 110, 255, 254 };
                        newEvents[oldLen] = doorEv;
                        sub1.eventdat = newEvents;
                        sub1.evkaz = (ushort)newEvents.Length;
                    }

                    if (!_loggedVc26)
                    {
                        _loggedVc26 = true;
                        Plugin.Log.LogInfo("[PKCore] Ruined Muse City Hall (vc26 -> vc09) central town doorway unlocked successfully!");
                    }
                }
                return;
            }

            // -------------------------------------------------------------
            // Case 2: Liberated Muse City Streets (vc25) - Central Town City Hall
            // -------------------------------------------------------------
            bool isVc25 = (!string.IsNullOrEmpty(mapId) && mapId.StartsWith("vc25", StringComparison.OrdinalIgnoreCase))
                || string.Equals(__result.mdat.name, "vc25", StringComparison.OrdinalIgnoreCase);

            if (isVc25)
            {
                LastExteriorMap = "vc25";
                bool patchedAny = false;

                // Submaps 1 and 2 in vc25 represent the main streets and town square
                for (int sIdx = 1; sIdx <= 2 && sIdx < mapeventdat.Count; sIdx++)
                {
                    var submap = mapeventdat[sIdx];
                    if (submap?.eventdat == null) continue;

                    // 1. Unlock doorway trigger at (101..107, 18..19)
                    for (int i = 0; i < submap.eventdat.Length; i++)
                    {
                        var ev = submap.eventdat[i];
                        if (ev?.eventForm == null) continue;
                        var f = ev.eventForm;

                        for (int k = 0; k < f.Length - 5; k++)
                        {
                            if (f[k] == 1 && f[k + 1] == 101 && f[k + 2] == 107 && f[k + 4] == 18 && f[k + 5] == 19)
                            {
                                ev.eventForm = new byte[] { 1, 101, 107, 2, 18, 19, 9, 1, 255, 254 };
                                ev.eventCom = new byte[] { 31, 1, 2, 26, 69, 2, 32, 2, 0, 163, 112, 255, 254 };
                                patchedAny = true;
                                break;
                            }
                        }
                    }

                    // 2. Neutralize any pushback/blocking guards near the doorway (e.g. 100..108, 18..20)
                    for (int i = 0; i < submap.eventdat.Length; i++)
                    {
                        var ev = submap.eventdat[i];
                        if (ev?.eventForm == null) continue;
                        var f = ev.eventForm;

                        for (int k = 0; k < f.Length - 5; k++)
                        {
                            if (f[k] == 1 && f[k + 1] == 100 && f[k + 2] == 108 && f[k + 4] == 18 && f[k + 5] == 20)
                            {
                                ev.eventForm = new byte[] { 1, 250, 10, 255, 254 };
                                break;
                            }
                        }
                    }
                }

                if (patchedAny && !_loggedVc25)
                {
                    _loggedVc25 = true;
                    Plugin.Log.LogInfo("[PKCore] Liberated Muse City Hall (vc25 -> vc27) central town doorway unlocked successfully!");
                }
                return;
            }

            // -------------------------------------------------------------
            // Case 3: Jowston Hill State Council Hall Courtyard (vc31)
            // -------------------------------------------------------------
            bool isVc31 = (!string.IsNullOrEmpty(mapId) && mapId.StartsWith("vc31", StringComparison.OrdinalIgnoreCase))
                || string.Equals(__result.mdat.name, "vc31", StringComparison.OrdinalIgnoreCase);

            if (isVc31 && mapeventdat.Count > 0)
            {
                LastExteriorMap = "vc31";
                var sub0 = mapeventdat[0];
                if (sub0?.eventdat != null)
                {
                    // 1. Doorway at (23..32, 35..36)
                    for (int i = 0; i < sub0.eventdat.Length; i++)
                    {
                        var ev = sub0.eventdat[i];
                        if (ev?.eventForm == null) continue;
                        var f = ev.eventForm;

                        for (int k = 0; k < f.Length - 5; k++)
                        {
                            if (f[k] == 1 && f[k + 1] == 23 && f[k + 2] == 32 && f[k + 4] == 35 && f[k + 5] == 36)
                            {
                                ev.eventForm = new byte[] { 1, 23, 32, 2, 35, 36, 9, 1, 255, 254 };
                                ev.eventCom = new byte[] { 31, 1, 2, 8, 32, 2, 0, 163, 110, 255, 254 };
                                break;
                            }
                        }
                    }

                    // 2. Remove repair workers pushback at X: 90..92, Y: 24..36
                    for (int i = 0; i < sub0.eventdat.Length; i++)
                    {
                        var ev = sub0.eventdat[i];
                        if (ev?.eventForm == null) continue;
                        var f = ev.eventForm;

                        for (int k = 0; k < f.Length - 5; k++)
                        {
                            if (f[k] == 1 && f[k + 1] == 90 && f[k + 2] == 92 && f[k + 4] == 24 && f[k + 5] == 36)
                            {
                                ev.eventForm = new byte[] { 1, 250, 10, 255, 254 };
                                break;
                            }
                        }
                    }

                    if (!_loggedVc31)
                    {
                        _loggedVc31 = true;
                        Plugin.Log.LogInfo("[PKCore] Jowston Hill Courtyard (vc31 -> vc09) doorway unlocked and guard pushback removed!");
                    }
                }
                return;
            }

            // -------------------------------------------------------------
            // Case 4: Inside City Hall (vc09 / vc27) - Configure Lobby Exit Doorway
            // -------------------------------------------------------------
            bool isVc09 = (!string.IsNullOrEmpty(mapId) && mapId.StartsWith("vc09", StringComparison.OrdinalIgnoreCase))
                || string.Equals(__result.mdat.name, "vc09", StringComparison.OrdinalIgnoreCase);

            bool isVc27 = (!string.IsNullOrEmpty(mapId) && mapId.StartsWith("vc27", StringComparison.OrdinalIgnoreCase))
                || string.Equals(__result.mdat.name, "vc27", StringComparison.OrdinalIgnoreCase);

            if ((isVc09 || isVc27) && mapeventdat.Count > 0)
            {
                var sub0 = mapeventdat[0]; // vc09_00 or vc27_00
                if (sub0?.eventdat != null)
                {
                    for (int i = 0; i < sub0.eventdat.Length; i++)
                    {
                        var ev = sub0.eventdat[i];
                        if (ev?.eventForm == null) continue;
                        var f = ev.eventForm;

                        // Match exit double-doors coordinates: X: 161..165, Y: 111..112 facing South (0)
                        bool isExit = false;
                        for (int k = 0; k < f.Length - 5; k++)
                        {
                            if (f[k] == 1 && f[k + 1] == 161 && f[k + 2] == 165 && f[k + 4] == 111 && f[k + 5] == 112)
                            {
                                isExit = true;
                                break;
                            }
                        }

                        if (isExit)
                        {
                            if (string.Equals(LastExteriorMap, "vc26", StringComparison.OrdinalIgnoreCase))
                            {
                                // Return to Ruined Muse City (vc26_01) outside City Hall doors at (104, 22)
                                ev.eventCom = new byte[] { 31, 1, 2, 25, 74, 1, 32, 3, 1, 104, 22, 255, 254 };
                            }
                            else if (string.Equals(LastExteriorMap, "vc25", StringComparison.OrdinalIgnoreCase))
                            {
                                // Return to Liberated Muse City (vc25_01) outside City Hall doors at (104, 22)
                                ev.eventCom = new byte[] { 31, 1, 2, 24, 74, 1, 32, 3, 1, 104, 22, 255, 254 };
                            }
                            else if (string.Equals(LastExteriorMap, "vc31", StringComparison.OrdinalIgnoreCase))
                            {
                                // Return to Jowston Hill Courtyard (vc31_00) at (28, 40)
                                ev.eventCom = new byte[] { 31, 0, 2, 30, 74, 1, 32, 3, 0, 28, 40, 255, 254 };
                            }
                            else
                            {
                                // Default: Return to Normal Muse City (vc01_01) outside City Hall doors at (104, 22)
                                ev.eventCom = new byte[] { 31, 0, 2, 0, 74, 1, 32, 3, 1, 104, 22, 255, 254 };
                            }
                        }
                    }
                }

                if (isVc09 && !_loggedVc09)
                {
                    _loggedVc09 = true;
                    Plugin.Log.LogInfo($"[PKCore] Muse City Hall (vc09_00) lobby exit doorway configured to return to {LastExteriorMap}!");
                }
                else if (isVc27 && !_loggedVc27)
                {
                    _loggedVc27 = true;
                    Plugin.Log.LogInfo($"[PKCore] Liberated Muse City Hall (vc27_00) lobby exit doorway configured to return to {LastExteriorMap}!");
                }
            }
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[PKCore] Error in LiberatedMuseCityHallPatch: {ex}");
        }
    }
}
