extern alias GSD2;

using System;
using HarmonyLib;

namespace PKCore.Patches;

/// <summary>
/// Restores Leona and Tavern Party Change in Dunan Castle Tavern (vk08) during the post-final-boss epilogue
/// via clean memory byte patching of story/epilogue flags (Flag 143, Flag 134, Flag 144) on vk08 entry,
/// restoring the original flag bytes upon leaving vk08 or saving.
/// </summary>
public static class s2EpilogueLeona
{
    public static bool IsEnabled => Plugin.Config?.EnableLeonaPostFinalBoss?.Value == true;

    public const int FLAG_143 = 143; // Bit 0x01: Beast Rune defeated
    public const int FLAG_134 = 134; // Bits 0x1B: Ending / Great Hall celebration gate
    public const int FLAG_144 = 144; // Bits 0x14: Leona absence / party lock

    private static bool _isSpoofed = false;
    private static byte _orig143;
    private static byte _orig134;
    private static byte _orig144;

    /// <summary>
    /// Applies or restores the memory byte patch based on whether the current map is vk08.
    /// </summary>
    public static void ApplyForMap(string mapId)
    {
        if (!GameDetection.IsGSD2() || string.IsNullOrEmpty(mapId))
            return;

        var gw = GSD2::OldSrcBase.game_work;
        if (gw == null || gw.event_flag == null || gw.event_flag.Length <= FLAG_144)
            return;

        bool isTavern = mapId.StartsWith("vk08", StringComparison.OrdinalIgnoreCase);

        if (isTavern && IsEnabled)
        {
            if (!_isSpoofed)
            {
                _orig143 = gw.event_flag[FLAG_143];
                _orig134 = gw.event_flag[FLAG_134];
                _orig144 = gw.event_flag[FLAG_144];
                _isSpoofed = true;
            }

            // Fool vk08 into thinking the final boss / ending celebration / absence flags are off
            gw.event_flag[FLAG_143] = (byte)(_orig143 & ~0x01);
            gw.event_flag[FLAG_134] = (byte)(_orig134 & ~0x1B);
            gw.event_flag[FLAG_144] = (byte)(_orig144 & ~0x14);

            Plugin.Log.LogInfo($"[s2EpilogueLeona] Memory byte patch applied on {mapId}: [143] 0x{_orig143:X2}->0x{gw.event_flag[FLAG_143]:X2}, [134] 0x{_orig134:X2}->0x{gw.event_flag[FLAG_134]:X2}, [144] 0x{_orig144:X2}->0x{gw.event_flag[FLAG_144]:X2}");
        }
        else if (_isSpoofed)
        {
            RestoreFlags();
        }
    }

    public static void RestoreFlags()
    {
        if (!_isSpoofed) return;

        var gw = GSD2::OldSrcBase.game_work;
        if (gw != null && gw.event_flag != null && gw.event_flag.Length > FLAG_144)
        {
            gw.event_flag[FLAG_143] = _orig143;
            gw.event_flag[FLAG_134] = _orig134;
            gw.event_flag[FLAG_144] = _orig144;
            Plugin.Log.LogInfo($"[s2EpilogueLeona] Restored original flag bytes: [143]=0x{_orig143:X2}, [134]=0x{_orig134:X2}, [144]=0x{_orig144:X2}");
        }
        _isSpoofed = false;
    }
}

/// <summary>
/// Hooks MACHICON.OnMapInit Prefix so the flag bytes are patched BEFORE the map initializes or spawns entities.
/// </summary>
[HarmonyPatch(typeof(MACHICON), nameof(MACHICON.OnMapInit))]
public static class S2LeonaOnMapInitPrefixPatch
{
    [HarmonyPrefix]
    public static void Prefix(MACHICON __instance)
    {
        if (__instance == null) return;
        try
        {
            string machiName = __instance.GetMapName();
            string mapId = MACHICON_OnMapInitPatch.ParseMapIdFromMachiName(machiName) ?? machiName;
            s2EpilogueLeona.ApplyForMap(mapId);
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[s2EpilogueLeona] Error in OnMapInit Prefix: {ex}");
        }
    }
}

/// <summary>
/// Restores original flag bytes before opening the save menu so the save file keeps its true post-game state.
/// </summary>
[HarmonyPatch(typeof(UISaveLoad2), nameof(UISaveLoad2.Init))]
public static class S2LeonaSaveMenuInitPrefixPatch
{
    [HarmonyPrefix]
    public static void Prefix()
    {
        s2EpilogueLeona.RestoreFlags();
    }
}
