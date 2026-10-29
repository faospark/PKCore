using HarmonyLib;
using System;

namespace PKCore.Patches;

/// <summary>
/// Tracks the active map identifier whenever MACHICON initializes or changes maps.
/// Shared across map-specific patches (Sajah Shop, Tenzan Chimera, Muse Ruins, Room Items, etc.).
/// </summary>
[HarmonyPatch(typeof(MACHICON), "OnMapInit")]
public static class MACHICON_OnMapInitPatch
{
    public static string CurrentMapId = "";

    public static MACHICON CurrentMachicon;

    [HarmonyPostfix]
    public static void Postfix(MACHICON __instance)
    {
        if (__instance == null) return;

        CurrentMachicon = __instance;
        string machiName = __instance.GetMapName();
        CurrentMapId = ParseMapIdFromMachiName(machiName);

        Plugin.Log.LogInfo($"[Map Tracking] MACHICON MapID resolved to: {CurrentMapId ?? "null"} (Raw: {machiName})");
    }

    public static int PlayerX => CurrentMachicon != null ? CurrentMachicon.px : 0;
    public static int PlayerY => CurrentMachicon != null ? CurrentMachicon.py : 0;

    public static void SetPlayerPos(int x, int y)
    {
        if (CurrentMachicon != null)
        {
            CurrentMachicon.px = x;
            CurrentMachicon.py = y;
            CurrentMachicon.mx = x * 16;
            CurrentMachicon.my = y * 16;
        }
    }

    public static int CurrentSubmapIndex
    {
        get
        {
            if (CurrentMachicon != null)
            {
                try
                {
                    string machiName = CurrentMachicon.GetMapName();
                    if (!string.IsNullOrEmpty(machiName))
                    {
                        var parts = machiName.Split(' ');
                        foreach (var part in parts)
                        {
                            if (part.StartsWith("mno:") && int.TryParse(part.Substring(4), out int mno))
                                return mno;
                        }
                    }
                }
                catch { }
            }
            return 0;
        }
    }

    public static string ParseMapIdFromMachiName(string machiName)
    {
        // Example: "vk07 mno:1 evmno:3" -> Output: "vk07_01"
        if (string.IsNullOrEmpty(machiName)) return null;

        var parts = machiName.Split(' ');
        if (parts.Length >= 2)
        {
            string basePrefix = parts[0];

            for (int i = 1; i < parts.Length; i++)
            {
                if (parts[i].StartsWith("mno:"))
                {
                    if (int.TryParse(parts[i].Substring(4), out int mno))
                    {
                        return $"{basePrefix}_{mno:D2}";
                    }
                }
            }
            return basePrefix;
        }
        return machiName;
    }
}

/// <summary>
/// Intercepts MACHICON.EventInit to capture the deserialized MACHIDAT (mdat) object.
/// Optionally activates dormant castle entities before EventInit constructs the scene.
/// </summary>
[HarmonyPatch(typeof(MACHICON), "EventInit")]
public static class MachiLoader_Load_Patch
{
    public static MACHIDAT LastLoadedMachiDat;
    public static EVENTCON LastLoadedEventcon;

    [HarmonyPrefix]
    public static void Prefix(MACHICON __instance)
    {
        if (__instance == null) return;
        try
        {
            string mapName = __instance.GetMapName();
            if (string.IsNullOrEmpty(mapName) || !mapName.StartsWith("vk"))
                return;

            ApplyDormantCastleRestorations(__instance, mapName);
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[MapTrackingPatch] Error during EventInit prefix: {ex}");
        }
    }

    /// <summary>
    /// Safely restores verified dormant castle features in memory without altering JSON files on disk.
    /// Preserves strict byte lengths by using NOP padding [0, 0, 0].
    /// </summary>
    private static void ApplyDormantCastleRestorations(MACHICON machicon, string mapName)
    {
        if (Plugin.Config?.RestoreDormantCastleFeatures?.Value != true)
            return;

        var mdat = machicon?.mdat;
        var ed = mdat?.eventdata;
        if (ed?.mapeventdat == null)
            return;

        // 1. vk13 Submap 4: The Secret Pasture Shortcut Door
        // ev[12] (Step-on zone) and ev[13] (Action door)
        if (mapName.StartsWith("vk13") && ed.mapeventdat.Count > 4)
        {
            var sub4 = ed.mapeventdat[4];
            if (sub4?.eventdat != null)
            {
                // ev[12]: [33, 0, 4, 1, 28, 46, 2, 133, 146, 255, 254]
                if (sub4.eventdat.Count > 12 && sub4.eventdat[12]?.eventForm != null)
                {
                    var form12 = sub4.eventdat[12].eventForm;
                    if (form12.Length >= 3 && form12[0] == 33 && form12[1] == 0 && form12[2] == 4)
                    {
                        form12[0] = 0; // NOP
                        form12[1] = 0; // NOP
                        form12[2] = 0; // NOP
                        Plugin.Log.LogInfo("[DormantCastle] Restored vk13 Sub 4 ev[12] Pasture Step-On shortcut zone.");
                    }
                }

                // ev[13]: [33, 0, 4, 1, 23, 24, 2, 135, 148, 9, 2, 255, 254]
                if (sub4.eventdat.Count > 13 && sub4.eventdat[13]?.eventForm != null)
                {
                    var form13 = sub4.eventdat[13].eventForm;
                    if (form13.Length >= 3 && form13[0] == 33 && form13[1] == 0 && form13[2] == 4)
                    {
                        form13[0] = 0; // NOP
                        form13[1] = 0; // NOP
                        form13[2] = 0; // NOP
                        Plugin.Log.LogInfo("[DormantCastle] Restored vk13 Sub 4 ev[13] Pasture Action shortcut door.");
                    }
                }
            }
        }

        // 2. vk19 Submap 0: Karen & Stage Dancers Cut Choreography
        // ev[62..65]: [5, 9, 26, 0, 48, <seq>, 1, 1, 255, 254]
        if (mapName.StartsWith("vk19") && ed.mapeventdat.Count > 0)
        {
            var sub0 = ed.mapeventdat[0];
            if (sub0?.eventdat != null)
            {
                int choreoCount = 0;
                for (int evIdx = 62; evIdx <= 65; evIdx++)
                {
                    if (sub0.eventdat.Count > evIdx && sub0.eventdat[evIdx]?.eventForm != null)
                    {
                        var form = sub0.eventdat[evIdx].eventForm;
                        // Search for the broken [9, 26, 0] token (Opcode 9 = flag check, flag 26, mask 0x00)
                        for (int i = 0; i <= form.Length - 3; i++)
                        {
                            if (form[i] == 9 && form[i + 1] == 26 && form[i + 2] == 0)
                            {
                                form[i] = 0;     // NOP
                                form[i + 1] = 0; // NOP
                                form[i + 2] = 0; // NOP
                                choreoCount++;
                                break;
                            }
                        }
                    }
                }
                if (choreoCount > 0)
                {
                    Plugin.Log.LogInfo($"[DormantCastle] Restored {choreoCount} cut dance choreography routines (ev[62..65]) on vk19 stage.");
                }
            }
        }
    }

    [HarmonyPostfix]
    public static void Postfix(MACHICON __instance, EVENTCON __result)
    {
        if (__instance != null)
        {
            MACHICON_OnMapInitPatch.CurrentMachicon = __instance;
        }
        if (__result != null)
        {
            LastLoadedEventcon = __result;
            LastLoadedMachiDat = __result.mdat;
        }
        ImGuiOverlayUI.OnMapChanged();
    }
}
