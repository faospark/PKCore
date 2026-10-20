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

    [HarmonyPostfix]
    public static void Postfix(MACHICON __instance)
    {
        if (__instance == null) return;

        string machiName = __instance.GetMapName();
        CurrentMapId = ParseMapIdFromMachiName(machiName);

        Plugin.Log.LogInfo($"[Map Tracking] MACHICON MapID resolved to: {CurrentMapId ?? "null"} (Raw: {machiName})");
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
/// </summary>
[HarmonyPatch(typeof(MACHICON), "EventInit")]
public static class MachiLoader_Load_Patch
{
    public static MACHIDAT LastLoadedMachiDat;

    [HarmonyPostfix]
    public static void Postfix(MACHICON __instance, EVENTCON __result)
    {
        if (__result != null)
        {
            LastLoadedMachiDat = __result.mdat;
        }
    }
}
