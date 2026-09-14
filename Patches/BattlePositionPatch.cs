extern alias GSD2;

using System;
using HarmonyLib;
using UnityEngine;

namespace PKCore.Patches;

/// <summary>
/// Adjusts the 6 party character battle positions in Suikoden 2 (GSD2).
/// Widens the spacing between front and back rows and spreads the 3 slots vertically
/// so that back row characters do not visually block front row characters.
/// Also provides detailed diagnostic logging on party character positions in battle.
/// </summary>
public static class BattlePositionPatch
{
    public static void Initialize(Harmony harmony)
    {
        try
        {
            // Only hook the 3-arg Setup to prevent double-applying offsets
            harmony.PatchAll(typeof(BattleCharaSetup3ArgPatch));
            harmony.PatchAll(typeof(BattleManagerPlayerInitPatch));
            Plugin.Log.LogInfo("[BattlePositionPatch] Registered all battle position hooks successfully.");
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[BattlePositionPatch] Failed to register battle position hooks: {ex}");
        }
    }

    public static void GetOffsetsForSlot(int slot, out int offsetX, out int offsetY, out int offsetZ)
    {
        offsetX = 0;
        offsetY = 0;
        offsetZ = 0;

        string preset = Plugin.Config?.S2BattlePositionPreset?.Value?.Trim().ToLowerInvariant() ?? "wide";

        int frontX;
        int backX;
        int spreadY;
        int spreadZ;

        switch (preset)
        {
            case "widest":
                frontX = -40;
                backX = 30;
                spreadY = 25;
                spreadZ = 0;
                break;
            case "default":
            case "normal":
            case "off":
                frontX = 0;
                backX = 0;
                spreadY = 0;
                spreadZ = 0;
                break;
            case "wide":
            default:
                frontX = -25;
                backX = 20;
                spreadY = 15;
                spreadZ = 0;
                break;
        }

        // Suikoden 2 Formation Layout:
        // Slot 0: Front-Top    (Orig: X=130, Y=-50)
        // Slot 1: Front-Middle (Orig: X=130, Y=0)
        // Slot 2: Front-Bottom (Orig: X=130, Y=50)
        // Slot 3: Back-Top     (Orig: X=210, Y=-50)
        // Slot 4: Back-Middle  (Orig: X=210, Y=0)
        // Slot 5: Back-Bottom  (Orig: X=210, Y=50)
        switch (slot)
        {
            case 0: // Front Top
                offsetX = frontX;
                offsetY = -spreadY;
                offsetZ = -spreadZ;
                break;
            case 1: // Front Middle
                offsetX = frontX;
                offsetY = 0;
                offsetZ = 0;
                break;
            case 2: // Front Bottom
                offsetX = frontX;
                offsetY = spreadY;
                offsetZ = spreadZ;
                break;
            case 3: // Back Top
                offsetX = backX;
                offsetY = -spreadY;
                offsetZ = -spreadZ;
                break;
            case 4: // Back Middle
                offsetX = backX;
                offsetY = 0;
                offsetZ = 0;
                break;
            case 5: // Back Bottom
                offsetX = backX;
                offsetY = spreadY;
                offsetZ = spreadZ;
                break;
        }
    }

    [HarmonyPatch(typeof(GSD2::BATTLE_CHARA), "Setup", new Type[] { typeof(int), typeof(GSD2::XYZ), typeof(Transform) })]
    public static class BattleCharaSetup3ArgPatch
    {
        [HarmonyPrefix]
        public static void Prefix(GSD2::BATTLE_CHARA __instance, int charaID, GSD2::XYZ position, Transform parent)
        {
            try
            {
                if (!GameDetection.IsGSD2() || Plugin.Config == null || !Plugin.Config.EnableBattlePositionAdjustments.Value)
                    return;

                if (position == null || position.x == null || position.y == null || position.z == null)
                    return;

                int slot = __instance.chara_no;
                if (slot < 0 || slot > 5)
                    return;

                int origX = position.x.seisu;
                int origY = position.y.seisu;
                int origZ = position.z.seisu;

                GetOffsetsForSlot(slot, out int offsetX, out int offsetY, out int offsetZ);

                position.x.seisu = origX + offsetX;
                position.y.seisu = origY + offsetY;
                position.z.seisu = origZ + offsetZ;

                string preset = Plugin.Config?.S2BattlePositionPreset?.Value ?? "wide";
                Plugin.Log.LogInfo($"[BattlePositionPatch] Preset '{preset}' Slot {slot} (CharaID {charaID}): ({origX}, {origY}, {origZ}) -> ({position.x.seisu}, {position.y.seisu}, {position.z.seisu}) [Offset: ({offsetX}, {offsetY}, {offsetZ})]");
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"[BattlePositionPatch] Prefix error: {ex}");
            }
        }
    }

    [HarmonyPatch(typeof(GSD2::BattleManager), "PlayerInit")]
    public static class BattleManagerPlayerInitPatch
    {
        [HarmonyPostfix]
        public static void Postfix(GSD2::BattleManager __instance)
        {
            try
            {
                if (!GameDetection.IsGSD2())
                    return;

                var battleWork = GSD2::BATTLE_WORK.Instance;
                if (battleWork == null || battleWork.b_chara == null)
                {
                    Plugin.Log.LogWarning("[BattlePositionPatch:PlayerInit] BATTLE_WORK or b_chara array is null.");
                    return;
                }

                string preset = Plugin.Config?.S2BattlePositionPreset?.Value ?? "wide";
                bool enabled = Plugin.Config != null && Plugin.Config.EnableBattlePositionAdjustments.Value;

                Plugin.Log.LogInfo($"=================== [BATTLE POSITION REPORT (GSD2)] ===================");
                Plugin.Log.LogInfo($"Adjustment Enabled: {enabled}, Preset: '{preset}'");

                for (int i = 0; i < battleWork.b_chara.Count; i++)
                {
                    var chara = battleWork.b_chara[i];
                    if (chara == null) continue;

                    int slot = chara.chara_no;
                    if (slot < 0 || slot > 5) continue;

                    string posName = slot switch
                    {
                        0 => "Front-Top   ",
                        1 => "Front-Middle",
                        2 => "Front-Bottom",
                        3 => "Back-Top    ",
                        4 => "Back-Middle ",
                        5 => "Back-Bottom ",
                        _ => "Unknown     "
                    };

                    GetOffsetsForSlot(slot, out int offX, out int offY, out int offZ);

                    string homeStr = "N/A";
                    string cposStr = "N/A";
                    string animeStr = "N/A";

                    if (chara.action_work != null)
                    {
                        var home = chara.action_work.home;
                        if (home?.x != null && home?.y != null && home?.z != null)
                            homeStr = $"({home.x.seisu}, {home.y.seisu}, {home.z.seisu})";

                        var cpos = chara.action_work.cpos;
                        if (cpos?.x != null && cpos?.y != null && cpos?.z != null)
                            cposStr = $"({cpos.x.seisu}, {cpos.y.seisu}, {cpos.z.seisu})";
                    }

                    if (chara.anime_xyz != null)
                    {
                        var animPos = chara.anime_xyz.position;
                        animeStr = $"({animPos.vx}, {animPos.vy}, {animPos.vz})";
                    }

                    Plugin.Log.LogInfo($"[BATTLE POS] Slot {slot} [{posName}] (CharaID: {chara.chara_id}) | Home: {homeStr} | Cpos: {cposStr} | AnimeXYZ: {animeStr} | Offset: ({offX}, {offY}, {offZ})");
                }
                Plugin.Log.LogInfo($"=======================================================================");
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"[BattlePositionPatch:PlayerInit] Postfix report error: {ex}");
            }
        }
    }
}
