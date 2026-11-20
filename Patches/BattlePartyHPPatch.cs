using HarmonyLib;
using ShareUI.Battle;
using System;
using System.Collections.Generic;
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
        private const float FixedFontSize = 20f;
        private const float TextRightShift = 5f;
        private static readonly HashSet<int> AdjustedTextIds = new();

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

                // Permanent fixed font size without auto-resize expansion on shorter numbers
                text.enableAutoSizing = false;
                text.fontSize = FixedFontSize;

                // Adjust position & width once per text component to avoid touching the heart icon
                int textId = text.GetInstanceID();
                if (!AdjustedTextIds.Contains(textId))
                {
                    AdjustedTextIds.Add(textId);

                    var rt = text.rectTransform;
                    if (rt != null)
                    {
                        // Shift right away from heart icon and widen box for 7 characters ("999/999")
                        rt.anchoredPosition = new Vector2(rt.anchoredPosition.x + TextRightShift, rt.anchoredPosition.y);
                        rt.sizeDelta = new Vector2(rt.sizeDelta.x + 30f, rt.sizeDelta.y);
                    }
                }

                text.text = $"{hpNow}/{hpMax}";
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"[BattlePartyHPPatch] Error formatting HP text: {ex.Message}");
            }
        }
    }
}
