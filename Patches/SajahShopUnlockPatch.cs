using HarmonyLib;
using Il2CppInterop.Runtime.InteropTypes.Arrays;

namespace PKCore.Patches;

[HarmonyPatch(typeof(MACHICON), "EventInit")]
public static class SajahShopUnlockPatch
{
    [HarmonyPostfix]
    public static void Postfix(MACHICON __instance, EVENTCON __result)
    {
        if (__result == null || __result.mdat?.eventdata?.mapeventdat == null) return;
        
        string mapId = MACHICON_OnMapInitPatch.CurrentMapId;
        if (string.IsNullOrEmpty(mapId) && __instance != null)
        {
            string raw = __instance.GetMapName();
            if (!string.IsNullOrEmpty(raw))
            {
                mapId = raw.Split(' ')[0];
            }
        }

        // Match any submap of vj17 or the underlying vj17 asset itself (vj17.json)
        bool isVj17 = (!string.IsNullOrEmpty(mapId) && mapId.StartsWith("vj17", System.StringComparison.OrdinalIgnoreCase))
            || string.Equals(__result.mdat.name, "vj17", System.StringComparison.OrdinalIgnoreCase);

        if (!isVj17) return;
        if (__result.mdat.eventdata.mapeventdat.Count <= 1) return;

        var interior = __result.mdat.eventdata.mapeventdat[1];
        if (interior == null || interior.eventobj == null || interior.eventdat == null) return;

        bool alreadyUnlocked = interior.eventobj.Length > 3 && interior.eventobj[3] != null && interior.eventobj[3].disp == 1;

        // 1. Force vendor sprite visible
        if (interior.eventobj.Length > 3 && interior.eventobj[3] != null)
            interior.eventobj[3].disp = 1;

        // 2. Force counter interaction trigger active
        if (interior.eventobj.Length > 7 && interior.eventobj[7] != null)
            interior.eventobj[7].disp = 1;

        // Neutralize room initialization hide check (prevents re-hiding if flag 143 is off)
        if (interior.eventdat.Length > 2 && interior.eventdat[2] != null)
            interior.eventdat[2].eventForm = new byte[] { 0, 255, 254 };

        // 3. Bypass flag 143 (Beast Rune defeat) in talk scripts
        if (interior.eventdat.Length > 10 && interior.eventdat[10] != null)
            interior.eventdat[10].eventForm = new byte[] { 5, 11, 255, 254 };

        if (interior.eventdat.Length > 11 && interior.eventdat[11] != null)
            interior.eventdat[11].eventForm = new byte[] { 5, 15, 255, 254 };

        if (!alreadyUnlocked)
            Plugin.Log.LogInfo("[PKCore] Sajah Village rare item vendor unlocked early in vj17!");
    }
}
