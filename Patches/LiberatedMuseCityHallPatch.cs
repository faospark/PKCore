extern alias GSD2;

using System;
using HarmonyLib;
using Il2CppInterop.Runtime.InteropTypes.Arrays;

namespace PKCore.Patches;

/// <summary>
/// Restores re-entry into Muse City Hall (vc02) where Mayor Annabelle's office and
/// the 2nd-floor library archive (Old Book Vol. 4 at bookshelf obj[25]) are located.
/// 
/// Supports:
/// 1. Ruined Muse City streets (vc26) post-fall (central municipal building entrance at X: 101..107, Y: 18..19).
/// 2. Liberated Muse City streets (vc25) post-liberation.
/// 3. Jowston Hill State Council Hall Courtyard (vc31).
/// 
/// Configures City Hall lobby (vc02_01) south exit double doors (X: 99..109, Y: 153..154)
/// to return Riou to the appropriate exterior map (vc26, vc25, or vc31).
/// </summary>
[HarmonyPatch(typeof(MACHICON), "EventInit")]
public static class LiberatedMuseCityHallPatch
{
    private static bool _loggedVc26 = false;
    private static bool _loggedVc25 = false;
    private static bool _loggedVc31 = false;
    private static bool _loggedVc02 = false;

    /// <summary>
    /// Tracks which exterior map Riou entered City Hall from ("vc26", "vc25", or "vc31")
    /// so the lobby exit doorway returns Riou to the appropriate map.
    /// </summary>
    public static string LastExteriorMap { get; set; } = "vc26";

    [HarmonyPostfix]
    public static void Postfix(MACHICON __instance, EVENTCON __result)
    {
        if (__result == null || __result.mdat?.eventdata?.mapeventdat == null) return;

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
            // Case 1: Ruined Muse City Streets (vc26) - Central Town City Hall
            // -------------------------------------------------------------
            bool isVc26 = (!string.IsNullOrEmpty(mapId) && mapId.StartsWith("vc26", StringComparison.OrdinalIgnoreCase))
                || string.Equals(__result.mdat.name, "vc26", StringComparison.OrdinalIgnoreCase);

            if (isVc26 && mapeventdat.Count > 1)
            {
                LastExteriorMap = "vc26";
                var sub1 = mapeventdat[1];
                if (sub1?.eventdat != null)
                {
                    bool doorPatched = false;

                    // 1. Check for existing doorway or orphaned slot at (99..109, 153..154)
                    for (int i = 0; i < sub1.eventdat.Length; i++)
                    {
                        var ev = sub1.eventdat[i];
                        if (ev?.eventForm == null) continue;
                        var f = ev.eventForm;

                        for (int k = 0; k < f.Length - 5; k++)
                        {
                            // Match either the front doors coords or orphaned coords
                            if (f[k] == 1 && (
                                (f[k + 1] == 101 && f[k + 2] == 107 && f[k + 4] == 18 && f[k + 5] == 19) ||
                                (f[k + 1] == 99 && f[k + 2] == 109 && f[k + 4] == 153 && f[k + 5] == 154)))
                            {
                                ev.eventForm = new byte[] { 1, 101, 107, 2, 18, 19, 9, 1, 255, 254 };
                                ev.eventCom = new byte[] { 31, 1, 2, 8, 32, 2, 1, 104, 148, 255, 254 };
                                doorPatched = true;
                                break;
                            }
                        }
                        if (doorPatched) break;
                    }

                    // Fallback to slot 4 if not matched by coordinates
                    if (!doorPatched && sub1.eventdat.Length > 4 && sub1.eventdat[4] != null)
                    {
                        sub1.eventdat[4].eventForm = new byte[] { 1, 101, 107, 2, 18, 19, 9, 1, 255, 254 };
                        sub1.eventdat[4].eventCom = new byte[] { 31, 1, 2, 8, 32, 2, 1, 104, 148, 255, 254 };
                        doorPatched = true;
                    }

                    if (doorPatched && !_loggedVc26)
                    {
                        _loggedVc26 = true;
                        Plugin.Log.LogInfo("[PKCore] Ruined Muse City Hall (vc26 -> vc02) central town doorway unlocked successfully!");
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
                                ev.eventCom = new byte[] { 31, 1, 2, 8, 32, 2, 1, 104, 148, 255, 254 };
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

                    // Fallback to index 3 if not matched by coordinates
                    if (!patchedAny && submap.eventdat.Length > 3 && submap.eventdat[3] != null)
                    {
                        submap.eventdat[3].eventForm = new byte[] { 1, 101, 107, 2, 18, 19, 9, 1, 255, 254 };
                        submap.eventdat[3].eventCom = new byte[] { 31, 1, 2, 8, 32, 2, 1, 104, 148, 255, 254 };
                        patchedAny = true;
                    }
                }

                if (patchedAny && !_loggedVc25)
                {
                    _loggedVc25 = true;
                    Plugin.Log.LogInfo("[PKCore] Liberated Muse City Hall (vc25 -> vc02) central town doorway unlocked successfully!");
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
                    bool doorFound = false;
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
                                ev.eventCom = new byte[] { 31, 0, 2, 25, 32, 2, 1, 104, 148, 255, 254 };
                                doorFound = true;
                                break;
                            }
                        }
                    }

                    if (!doorFound && sub0.eventdat.Length > 4 && sub0.eventdat[4] != null)
                    {
                        sub0.eventdat[4].eventForm = new byte[] { 1, 23, 32, 2, 35, 36, 9, 1, 255, 254 };
                        sub0.eventdat[4].eventCom = new byte[] { 31, 0, 2, 25, 32, 2, 1, 104, 148, 255, 254 };
                    }

                    // Remove repair workers pushback at X: 90..92, Y: 24..36
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
                        Plugin.Log.LogInfo("[PKCore] Jowston Hill Courtyard (vc31 -> vc02) doorway unlocked and guard pushback removed!");
                    }
                }
                return;
            }

            // -------------------------------------------------------------
            // Case 4: Inside City Hall (vc02) - Configure Lobby Exit Doorway
            // -------------------------------------------------------------
            bool isVc02 = (!string.IsNullOrEmpty(mapId) && mapId.StartsWith("vc02", StringComparison.OrdinalIgnoreCase))
                || string.Equals(__result.mdat.name, "vc02", StringComparison.OrdinalIgnoreCase);

            if (isVc02 && mapeventdat.Count > 1)
            {
                // Submap 1 (Grand Hall Lobby)
                var sub1 = mapeventdat[1];
                if (sub1?.eventdat != null)
                {
                    foreach (var ev in sub1.eventdat)
                    {
                        if (ev?.eventForm == null) continue;
                        var f = ev.eventForm;

                        // Match exit double-doors coordinates: X: 99..109, Y: 153..154 facing South (0)
                        bool isExit = false;
                        for (int i = 0; i < f.Length - 5; i++)
                        {
                            if (f[i] == 1 && f[i + 1] == 99 && f[i + 2] == 109 && f[i + 4] == 153 && f[i + 5] == 154)
                            {
                                isExit = true;
                                break;
                            }
                        }

                        if (isExit)
                        {
                            if (string.Equals(LastExteriorMap, "vc25", StringComparison.OrdinalIgnoreCase))
                            {
                                // Return to Liberated Muse City (vc25_01) outside City Hall doors at (104, 22)
                                ev.eventCom = new byte[] { 31, 1, 2, 8, 32, 25, 1, 104, 22, 255, 254 };
                            }
                            else if (string.Equals(LastExteriorMap, "vc31", StringComparison.OrdinalIgnoreCase))
                            {
                                // Return to Jowston Hill Courtyard (vc31_00) at (28, 40)
                                ev.eventCom = new byte[] { 31, 0, 2, 25, 32, 31, 0, 28, 40, 255, 254 };
                            }
                            else
                            {
                                // Default: Return to Ruined Muse City (vc26_01) outside City Hall doors at (104, 22)
                                ev.eventCom = new byte[] { 31, 1, 2, 8, 32, 26, 1, 104, 22, 255, 254 };
                            }
                        }
                    }
                }

                if (!_loggedVc02)
                {
                    _loggedVc02 = true;
                    Plugin.Log.LogInfo($"[PKCore] Muse City Hall (vc02) lobby exit doorway configured to return to {LastExteriorMap}!");
                }
            }
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[PKCore] Error in LiberatedMuseCityHallPatch: {ex}");
        }
    }
}

