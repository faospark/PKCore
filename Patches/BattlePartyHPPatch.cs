using HarmonyLib;
using ShareUI.Battle;
using System;
using TMPro;
using UnityEngine;

namespace PKCore.Patches
{
    /// <summary>
    /// Displays both Current and Max HP (e.g. 587/587) in the Battle Party Window for Suikoden 1 & 2.
    /// By default, the game only displays current HP (587).
    /// </summary>
    [HarmonyPatch]
    public static class BattlePartyHPPatch
    {
        [HarmonyPatch(typeof(UIBattlePlayerStatus), nameof(UIBattlePlayerStatus.SetPlayerStatus))]
        [HarmonyPostfix]
        public static void SetPlayerStatus_Postfix(UIBattlePlayerStatus __instance, Sprite face, string name, int hpNow, int hpMax, bool isDead)
        {
            ApplyMaxHPText(__instance, hpNow, hpMax);
        }

        [HarmonyPatch(typeof(UIBattlePlayerStatus), nameof(UIBattlePlayerStatus.SetHP))]
        [HarmonyPostfix]
        public static void SetHP_Postfix(UIBattlePlayerStatus __instance, int hpNow, int hpMax)
        {
            ApplyMaxHPText(__instance, hpNow, hpMax);
        }

        private static void ApplyMaxHPText(UIBattlePlayerStatus status, int hpNow, int hpMax)
        {
            try
            {
                if (status == null || !Plugin.Config.ShowBattleMaxHP.Value)
                    return;

                var text = status.m_hpText;
                if (text == null)
                    return;

                // Enable auto-sizing to cleanly fit 6-7 characters ("999/999") without overflow or clipping
                text.enableAutoSizing = true;
                text.fontSizeMin = 18f;
                text.fontSizeMax = 28f;
                text.text = $"{hpNow}/{hpMax}";
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"[BattlePartyHPPatch] Error formatting HP text: {ex.Message}");
            }
        }
    }
}
