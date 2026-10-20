extern alias GSD2;

using System;
using HarmonyLib;
using Il2CppInterop.Runtime.InteropTypes.Arrays;

namespace PKCore.Patches;

/// <summary>
/// Restores interaction triggers and dialogues for all survivors in Muse Ruins (vc26).
/// 
/// 1. Dormant Actors Restoration:
/// In vanilla vc26_01, obj[02] through obj[09] were placed as NPC sprites, but had no interaction triggers
/// because the developers incorrectly indexed the corresponding interaction scripts (ev[62] to ev[77]) to
/// non-existent objects obj[35] through obj[42]. This patch re-targets those 16 scripts to obj[02]..obj[09],
/// making all 8 silent survivors fully interactive with their authored dialogues (Bank 1, Msgs 26-33 and 76-83).
///
/// 2. 108 Stars Spiritual Reward:
/// When all 108 Stars of Destiny are gathered (G2_SYS.Mem108Chk(0) >= 108) or the Beast Rune is vanquished,
/// the souls in Muse Ruins are cleansed and put at peace. The patch switches all 33 survivors (obj[02]..obj[34])
/// to their hidden, peaceful survivor dialogues (Bank 1, Msgs 51-83).
/// </summary>
[HarmonyPatch(typeof(MACHICON), "EventInit")]
public static class MuseRuinsSurvivorsPatch
{
    private static bool _loggedRestoration = false;

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

        bool isVc26 = (!string.IsNullOrEmpty(mapId) && mapId.StartsWith("vc26", StringComparison.OrdinalIgnoreCase))
            || string.Equals(__result.mdat.name, "vc26", StringComparison.OrdinalIgnoreCase);

        if (!isVc26) return;
        if (__result.mdat.eventdata.mapeventdat.Count <= 1) return;

        var submap = __result.mdat.eventdata.mapeventdat[1]; // vc26_01
        if (submap?.eventdat == null || submap.eventobj == null) return;

        try
        {
            // Check if all 108 Stars of Destiny are united
            int starsCount = 0;
            try
            {
                starsCount = GSD2::G2_SYS.Mem108Chk(0);
            }
            catch { }

            bool has108Stars = starsCount >= 108;

            // 1. Re-target orphan scripts ev[62]..ev[77] to dormant actors obj[02]..obj[09]
            // ev[62], ev[63] -> obj[02]
            // ev[64], ev[65] -> obj[03]
            // ...
            // ev[76], ev[77] -> obj[09]
            for (int i = 0; i < 8; i++)
            {
                byte targetObj = (byte)(2 + i);
                int scriptDistressedIdx = 62 + (i * 2);     // ev[62], ev[64], ...
                int scriptPeacefulIdx   = 62 + (i * 2) + 1; // ev[63], ev[65], ...

                if (scriptDistressedIdx < submap.eventdat.Length && submap.eventdat[scriptDistressedIdx] != null)
                {
                    var ev = submap.eventdat[scriptDistressedIdx];
                    if (has108Stars)
                    {
                        // If 108 stars gathered, disable distressed script using impossible coordinate condition
                        // (Never target non-existent obj indices like 255 with opcode 5, as EventFormTbl does eventobj[idx])
                        ev.eventForm = new byte[] { 1, 250, 10, 255, 254 };
                    }
                    else
                    {
                        // Target obj[targetObj], standard talk trigger
                        ev.eventForm = new byte[] { 3, 20, 128, 4, 143, 1, 5, targetObj, 255, 254 };
                    }
                }

                if (scriptPeacefulIdx < submap.eventdat.Length && submap.eventdat[scriptPeacefulIdx] != null)
                {
                    var ev = submap.eventdat[scriptPeacefulIdx];
                    if (has108Stars)
                    {
                        // If 108 stars gathered, activate peaceful dialogue
                        ev.eventForm = new byte[] { 5, targetObj, 255, 254 };
                    }
                    else
                    {
                        // Keep original flag 143 check, targeting obj[targetObj]
                        ev.eventForm = new byte[] { 3, 143, 1, 5, targetObj, 255, 254 };
                    }
                }
            }

            // 2. If 108 Stars are united, activate peaceful dialogues for all existing actors obj[10]..obj[34]
            // In vanilla:
            // ev[12 + (j * 2)]     = distressed script for obj[10 + j]
            // ev[12 + (j * 2) + 1] = peaceful script for obj[10 + j]
            if (has108Stars)
            {
                for (int j = 0; j < 25; j++)
                {
                    byte targetObj = (byte)(10 + j);
                    int scriptDistressedIdx = 12 + (j * 2);
                    int scriptPeacefulIdx   = 12 + (j * 2) + 1;

                    if (scriptDistressedIdx < submap.eventdat.Length && submap.eventdat[scriptDistressedIdx] != null)
                    {
                        // Disable distressed script using impossible coordinate condition
                        submap.eventdat[scriptDistressedIdx].eventForm = new byte[] { 1, 250, 10, 255, 254 };
                    }

                    if (scriptPeacefulIdx < submap.eventdat.Length && submap.eventdat[scriptPeacefulIdx] != null)
                    {
                        // Unconditionally enable peaceful dialogue when talking to targetObj
                        submap.eventdat[scriptPeacefulIdx].eventForm = new byte[] { 5, targetObj, 255, 254 };
                    }
                }
            }

            if (!_loggedRestoration)
            {
                _loggedRestoration = true;
                Plugin.Log.LogInfo($"[PKCore] Muse Ruins (vc26) survivors restored! (108 Stars united: {has108Stars}, Stars Count: {starsCount})");
            }
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[PKCore] Error in MuseRuinsSurvivorsPatch: {ex}");
        }
    }
}
