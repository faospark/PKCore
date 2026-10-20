extern alias GSD2;

using System;
using HarmonyLib;
using Il2CppInterop.Runtime.InteropTypes.Arrays;

namespace PKCore.Patches;

/// <summary>
/// Restores re-entry into Muse City Hall (vc02) from Liberated Muse City (vc25).
/// 
/// Background:
/// In vanilla Suikoden II, after the liberation celebration cutscene finishes, Story Flag 22 (bit 4)
/// is permanently set. However, Konami omitted an entrance trigger for this completed state,
/// permanently locking the player out of City Hall. This prevented collecting missable valuables
/// such as Old Book Vol. 4 from bookshelf obj[25] in vc02_01.
/// 
/// This patch updates the doorway event (ev[03]) at coordinates (101..107, 18..19) in vc25
/// (Submaps 1 &amp; 2) so Riou can re-enter City Hall post-liberation.
/// </summary>
[HarmonyPatch(typeof(MACHICON), "EventInit")]
public static class LiberatedMuseCityHallPatch
{
    private static bool _loggedUnlock = false;

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

        bool isVc25 = (!string.IsNullOrEmpty(mapId) && mapId.StartsWith("vc25", StringComparison.OrdinalIgnoreCase))
            || string.Equals(__result.mdat.name, "vc25", StringComparison.OrdinalIgnoreCase);

        if (!isVc25) return;

        try
        {
            var mapeventdat = __result.mdat.eventdata.mapeventdat;
            bool patchedAny = false;

            // Submaps 1 and 2 in vc25 represent the main streets and city square
            for (int sIdx = 1; sIdx <= 2 && sIdx < mapeventdat.Count; sIdx++)
            {
                var submap = mapeventdat[sIdx];
                if (submap?.eventdat == null || submap.eventdat.Length <= 3) continue;

                var ev3 = submap.eventdat[3];
                if (ev3 == null || ev3.eventCom == null) continue;

                // Verify ev[03] is the City Hall door warp (opcode 32 -> map 2, sub 0 at 163, 112)
                bool isCityHallWarp = false;
                for (int i = 0; i < ev3.eventCom.Length - 5; i++)
                {
                    if (ev3.eventCom[i] == 32 && ev3.eventCom[i + 1] == 2 && ev3.eventCom[i + 2] == 0)
                    {
                        isCityHallWarp = true;
                        break;
                    }
                }

                if (isCityHallWarp)
                {
                    // In vanilla, form was: [3, 22, 1, 4, 22, 2, 3, 0, 2, 1, 101, 107, 2, 18, 19, 9, 1, 255, 254]
                    // We update it so that when player is in front of the door facing Up (North), it triggers:
                    // [1, 101, 107, 2, 18, 19, 9, 1, 255, 254]
                    ev3.eventForm = new byte[] { 1, 101, 107, 2, 18, 19, 9, 1, 255, 254 };
                    patchedAny = true;
                }
            }

            if (patchedAny && !_loggedUnlock)
            {
                _loggedUnlock = true;
                Plugin.Log.LogInfo("[PKCore] Liberated Muse City Hall (vc25 -> vc02) re-entry doorway unlocked successfully!");
            }
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[PKCore] Error in LiberatedMuseCityHallPatch: {ex}");
        }
    }
}
