extern alias GSD2;

using System;
using HarmonyLib;

namespace PKCore.Patches;

/// <summary>
/// Enables Escape Talisman usage inside the Rockaxe Castle dungeon (vi06)
/// once the Rockaxe liberation story is completed (event_flag[20] bit 0x01),
/// and sets the escape destination to vi06_00 at (1040, 528) in front of the exit door.
/// </summary>
public static class S2RockaxeEscapeTalisman
{
    public static bool IsEnabled => Plugin.Config?.EnableRockaxeDungeonEscapeTalisman?.Value == true;

    private const int FlagMatildaStory = 20;       // Bit 0x01: Rockaxe liberated
    private const int RockaxeDungeonExitMapNo = 0; // vi06_00
    private const ushort EscapeDestX = 130;        // 130 * 8 = 1040 (P.x)
    private const ushort EscapeDestY = 66;         // 66 * 8 = 528  (P.y)

    private static bool _isPatched = false;
    private static int _rockaxeAreaNo = 8;         // vi (updated from MACHICON.ano)
    private static int _rockaxeDungeonTownNo = 6;  // vi06 (updated from MACHICON.vno)
    private static int _origSAreaNo;
    private static int _origSTownNo;
    private static int _origSMapNo;
    private static ushort _origSX;
    private static ushort _origSY;

    public static bool IsActiveForCurrentMap()
    {
        if (!GameDetection.IsGSD2() || !IsEnabled)
            return false;

        string mapId = MACHICON_OnMapInitPatch.CurrentMapId;
        if (string.IsNullOrEmpty(mapId) || !mapId.StartsWith("vi06", StringComparison.OrdinalIgnoreCase))
            return false;

        var gw = GSD2::OldSrcBase.game_work;
        if (gw == null || gw.event_flag == null || gw.event_flag.Length <= FlagMatildaStory)
            return false;

        return (gw.event_flag[FlagMatildaStory] & 0x01) != 0;
    }

    public static void ApplyForMap(string mapId, int ano, int vno)
    {
        if (!GameDetection.IsGSD2() || string.IsNullOrEmpty(mapId))
            return;

        var gw = GSD2::OldSrcBase.game_work;
        if (gw == null || gw.game_data == null || gw.event_flag == null || gw.event_flag.Length <= FlagMatildaStory)
            return;

        bool isRockaxeDungeon = mapId.StartsWith("vi06", StringComparison.OrdinalIgnoreCase);

        if (isRockaxeDungeon && IsEnabled && (gw.event_flag[FlagMatildaStory] & 0x01) != 0)
        {
            _rockaxeAreaNo = ano;
            _rockaxeDungeonTownNo = vno;

            var gd = gw.game_data;
            if (!_isPatched)
            {
                _origSAreaNo = gd.s_area_no;
                _origSTownNo = gd.s_town_no;
                _origSMapNo = gd.s_map_no;
                _origSX = gd.s_x;
                _origSY = gd.s_y;
                _isPatched = true;
            }

            SetEscapeDestination(gd);
            Plugin.Log.LogInfo($"[S2RockaxeEscapeTalisman] Escape destination patched on {mapId}: dest=vi06_00 (ano={_rockaxeAreaNo}, vno={_rockaxeDungeonTownNo}, mno={RockaxeDungeonExitMapNo}, {EscapeDestX * 8},{EscapeDestY * 8})");
        }
        else if (_isPatched)
        {
            RestoreDestination();
        }
    }

    public static void SetEscapeDestination(GSD2::GAME_DATA gd)
    {
        if (gd == null) return;
        gd.s_area_no = _rockaxeAreaNo;
        gd.s_town_no = _rockaxeDungeonTownNo;
        gd.s_map_no = RockaxeDungeonExitMapNo;
        gd.s_x = EscapeDestX;
        gd.s_y = EscapeDestY;
    }

    public static void RestoreDestination()
    {
        if (!_isPatched) return;

        var gw = GSD2::OldSrcBase.game_work;
        if (gw != null && gw.game_data != null)
        {
            var gd = gw.game_data;
            gd.s_area_no = _origSAreaNo;
            gd.s_town_no = _origSTownNo;
            gd.s_map_no = _origSMapNo;
            gd.s_x = _origSX;
            gd.s_y = _origSY;
        }
        _isPatched = false;
    }
}

[HarmonyPatch(typeof(GSD2::MACHICON), nameof(GSD2::MACHICON.OnMapInit))]
public static class S2RockaxeEscapeOnMapInitPrefixPatch
{
    [HarmonyPrefix]
    public static void Prefix(GSD2::MACHICON __instance)
    {
        if (__instance == null) return;
        try
        {
            string machiName = __instance.GetMapName();
            string mapId = MACHICON_OnMapInitPatch.ParseMapIdFromMachiName(machiName) ?? machiName;
            S2RockaxeEscapeTalisman.ApplyForMap(mapId, __instance.ano, __instance.vno);
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[S2RockaxeEscapeTalisman] Error in OnMapInit Prefix: {ex}");
        }
    }
}

[HarmonyPatch(typeof(GSD2::MACHICON), nameof(GSD2::MACHICON.ESurinukeChk))]
public static class S2RockaxeEscapeChkPostfixPatch
{
    [HarmonyPostfix]
    public static void Postfix(ref int __result)
    {
        // ESurinukeChk returns 0 = usable, 1 = disabled.
        if (__result != 0 && S2RockaxeEscapeTalisman.IsActiveForCurrentMap())
            __result = 0;
    }
}

[HarmonyPatch(typeof(GSD2::MACHICON), nameof(GSD2::MACHICON.ESurinukeGo))]
public static class S2RockaxeEscapeGoPrefixPatch
{
    [HarmonyPrefix]
    public static void Prefix()
    {
        if (!S2RockaxeEscapeTalisman.IsActiveForCurrentMap())
            return;

        var gw = GSD2::OldSrcBase.game_work;
        if (gw?.game_data != null)
            S2RockaxeEscapeTalisman.SetEscapeDestination(gw.game_data);
    }
}

[HarmonyPatch(typeof(GSD2::UISaveLoad2), nameof(GSD2::UISaveLoad2.Init))]
public static class S2RockaxeEscapeSaveMenuInitPrefixPatch
{
    [HarmonyPrefix]
    public static void Prefix()
    {
        S2RockaxeEscapeTalisman.RestoreDestination();
    }
}
