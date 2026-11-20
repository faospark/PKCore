extern alias GSD2;

using System;
using HarmonyLib;

namespace PKCore.Patches;

/// <summary>
/// Restores Dunan Castle minigames (vk18 Laundry & Gardens) during the post-final-boss epilogue
/// via clean memory byte patching of epilogue flags on map entry, restoring original bytes on exit or save.
/// </summary>
public static class s2EpilogueMinigame
{
    public static bool IsEnabled => Plugin.Config?.EnableCastleMinigamesPostFinalBoss?.Value == true;

    public const int FLAG_20  = 20;  // Bit 0x80: Rockaxe / Nanami event dialogue override on vk18
    public const int FLAG_132 = 132; // Bit 0x40: L'Renouille endgame dialogue override on vk18
    public const int FLAG_143 = 143; // Bit 0x01: Beast Rune defeated
    public const int FLAG_134 = 134; // Bits 0x1B: Ending / Great Hall celebration gate
    public const int FLAG_144 = 144; // Bits 0x14: Epilogue absence / lock

    private static bool _isSpoofed = false;
    private static byte _orig20;
    private static byte _orig132;
    private static byte _orig143;
    private static byte _orig134;
    private static byte _orig144;

    public static void ApplyForMap(string mapId)
    {
        if (!GameDetection.IsGSD2() || string.IsNullOrEmpty(mapId))
            return;

        var gw = GSD2::OldSrcBase.game_work;
        if (gw == null || gw.event_flag == null || gw.event_flag.Length <= FLAG_144)
            return;

        bool isMinigameMap = mapId.StartsWith("vk18", StringComparison.OrdinalIgnoreCase);

        if (isMinigameMap && IsEnabled)
        {
            if (!_isSpoofed)
            {
                _orig20  = gw.event_flag[FLAG_20];
                _orig132 = gw.event_flag[FLAG_132];
                _orig143 = gw.event_flag[FLAG_143];
                _orig134 = gw.event_flag[FLAG_134];
                _orig144 = gw.event_flag[FLAG_144];
                _isSpoofed = true;
            }

            gw.event_flag[FLAG_20]  = (byte)(_orig20  & ~0x80);
            gw.event_flag[FLAG_132] = (byte)(_orig132 & ~0x40);
            gw.event_flag[FLAG_143] = (byte)(_orig143 & ~0x01);
            gw.event_flag[FLAG_134] = (byte)(_orig134 & ~0x1B);
            gw.event_flag[FLAG_144] = (byte)(_orig144 & ~0x14);

            Plugin.Log.LogInfo($"[s2EpilogueMinigame] Memory byte patch applied on {mapId}: [20] 0x{_orig20:X2}->0x{gw.event_flag[FLAG_20]:X2}, [132] 0x{_orig132:X2}->0x{gw.event_flag[FLAG_132]:X2}, [143] 0x{_orig143:X2}->0x{gw.event_flag[FLAG_143]:X2}, [134] 0x{_orig134:X2}->0x{gw.event_flag[FLAG_134]:X2}, [144] 0x{_orig144:X2}->0x{gw.event_flag[FLAG_144]:X2}");
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
            gw.event_flag[FLAG_20]  = _orig20;
            gw.event_flag[FLAG_132] = _orig132;
            gw.event_flag[FLAG_143] = _orig143;
            gw.event_flag[FLAG_134] = _orig134;
            gw.event_flag[FLAG_144] = _orig144;
            Plugin.Log.LogInfo($"[s2EpilogueMinigame] Restored original flag bytes: [20]=0x{_orig20:X2}, [132]=0x{_orig132:X2}, [143]=0x{_orig143:X2}, [134]=0x{_orig134:X2}, [144]=0x{_orig144:X2}");
        }
        _isSpoofed = false;
    }
}

[HarmonyPatch(typeof(MACHICON), nameof(MACHICON.OnMapInit))]
public static class S2MinigameOnMapInitPrefixPatch
{
    [HarmonyPrefix]
    public static void Prefix(MACHICON __instance)
    {
        if (__instance == null) return;
        try
        {
            string machiName = __instance.GetMapName();
            string mapId = MACHICON_OnMapInitPatch.ParseMapIdFromMachiName(machiName) ?? machiName;
            s2EpilogueMinigame.ApplyForMap(mapId);
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[s2EpilogueMinigame] Error in OnMapInit Prefix: {ex}");
        }
    }
}

[HarmonyPatch(typeof(UISaveLoad2), nameof(UISaveLoad2.Init))]
public static class S2MinigameSaveMenuInitPrefixPatch
{
    [HarmonyPrefix]
    public static void Prefix()
    {
        s2EpilogueMinigame.RestoreFlags();
    }
}
