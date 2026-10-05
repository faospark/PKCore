using HarmonyLib;
using ShareUI.Battle;
using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PKCore.Patches
{
    /// <summary>
    /// DIAGNOSTIC: Inspects the live battle party window used by BOTH games.
    /// NOTE: The Share.Battle.UI.UIBattleWindowUnit classes in GSDShare are NOT used at runtime;
    /// GSD1/GSD2 UIBattleManager creates ShareUI.Battle.UIBattleMain, whose party window is
    /// UIBattleWindowParty -> List&lt;UIBattlePlayerStatus&gt; (one per slot).
    /// UIBattlePlayerStatus has a single m_hpText (+ m_hpGauge slider) and stores m_hpMax.
    /// Logs once per slot instance (no per-frame spam).
    /// Enabled via [zz - Diagnostics] LogBattleUnitWindow.
    /// </summary>
    [HarmonyPatch]
    public static class BattleUnitWindowDiagnostics
    {
        private const string Tag = "[BattleUnitDiag]";
        private static readonly HashSet<IntPtr> _loggedSlots = new HashSet<IntPtr>();

        [HarmonyPatch(typeof(UIBattleWindowParty), nameof(UIBattleWindowParty.BattleInitialize))]
        [HarmonyPostfix]
        public static void BattleInitialize_Postfix(UIBattleWindowParty __instance)
        {
            try
            {
                _loggedSlots.Clear();
                var list = __instance.m_playrStatusList;
                Plugin.Log.LogInfo($"{Tag} UIBattleWindowParty.BattleInitialize | game={GameDetection.GetCurrentGame()} | slots={(list != null ? list.Count : -1)} | path='{GetPath(__instance.transform)}'");
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"{Tag} BattleInitialize_Postfix error: {ex}");
            }
        }

        [HarmonyPatch(typeof(UIBattleWindowParty), nameof(UIBattleWindowParty.SetPlayerStatus))]
        [HarmonyPostfix]
        public static void Party_SetPlayerStatus_Postfix(UIBattleWindowParty __instance, int index, Sprite face, string name, int hpNow, int hpMax, bool isDead)
        {
            try
            {
                Plugin.Log.LogInfo($"{Tag} Party.SetPlayerStatus[{index}] name='{name}' HP={hpNow}/{hpMax} dead={isDead}");
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"{Tag} Party_SetPlayerStatus_Postfix error: {ex}");
            }
        }

        [HarmonyPatch(typeof(UIBattlePlayerStatus), nameof(UIBattlePlayerStatus.SetPlayerStatus))]
        [HarmonyPostfix]
        public static void SetPlayerStatus_Postfix(UIBattlePlayerStatus __instance, Sprite face, string name, int hpNow, int hpMax, bool isDead)
        {
            try
            {
                if (__instance == null) return;
                if (!_loggedSlots.Add(__instance.Pointer)) return;

                var sb = new StringBuilder();
                sb.AppendLine($"{Tag} ===== game={GameDetection.GetCurrentGame()} slot='{__instance.gameObject.name}' name='{name}' HP={hpNow}/{hpMax} (stored m_hpMax={__instance.m_hpMax}) =====");
                sb.AppendLine($"{Tag}   m_hpText  : {DescribeText(__instance.m_hpText)}");
                sb.AppendLine($"{Tag}   m_nameText: {DescribeText(__instance.m_nameText)}");

                var gauge = __instance.m_hpGauge;
                if (gauge != null)
                    sb.AppendLine($"{Tag}   m_hpGauge : value={gauge.value:0.###} min={gauge.minValue} max={gauge.maxValue} wholeNumbers={gauge.wholeNumbers}");
                else
                    sb.AppendLine($"{Tag}   m_hpGauge : <null>");

                sb.AppendLine($"{Tag}   m_hpIcon  : {DescribeImage(__instance.m_hpIcon)}");
                sb.AppendLine($"{Tag}   --- slot hierarchy ---");
                DumpHierarchy(__instance.transform, sb, 0, 8);

                Plugin.Log.LogInfo(sb.ToString());
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"{Tag} SetPlayerStatus_Postfix error: {ex}");
            }
        }

        private static string DescribeText(TextMeshProUGUI t)
        {
            if (t == null) return "<null>";
            var go = t.gameObject;
            var rt = t.rectTransform;
            return $"go='{go.name}' activeInHierarchy={go.activeInHierarchy} enabled={t.enabled} " +
                   $"text='{t.text}' alpha={t.alpha:0.##} fontSize={t.fontSize} autoSize={t.enableAutoSizing} " +
                   $"align={t.alignment} overflow={t.overflowMode} size={rt.sizeDelta} anchoredPos={rt.anchoredPosition} " +
                   $"path='{GetPath(t.transform)}'";
        }

        private static string DescribeImage(Image img)
        {
            if (img == null) return "<null>";
            var go = img.gameObject;
            return $"go='{go.name}' activeInHierarchy={go.activeInHierarchy} enabled={img.enabled} " +
                   $"sprite='{(img.sprite != null ? img.sprite.name : "null")}' color={img.color}";
        }

        private static void DumpHierarchy(Transform t, StringBuilder sb, int depth, int maxDepth)
        {
            if (t == null || depth > maxDepth) return;

            string indent = new string(' ', 4 + depth * 2);
            var go = t.gameObject;
            var line = new StringBuilder();
            line.Append($"{Tag}{indent}- {go.name} [self={(go.activeSelf ? "on" : "OFF")}, hier={(go.activeInHierarchy ? "on" : "OFF")}]");

            var tmp = go.GetComponent<TextMeshProUGUI>();
            if (tmp != null)
                line.Append($" TMP(enabled={tmp.enabled}, text='{tmp.text}', alpha={tmp.alpha:0.##}, fontSize={tmp.fontSize})");

            var img = go.GetComponent<Image>();
            if (img != null)
                line.Append($" IMG(enabled={img.enabled}, sprite='{(img.sprite != null ? img.sprite.name : "null")}', a={img.color.a:0.##})");

            var rt = t.TryCast<RectTransform>();
            if (rt != null)
                line.Append($" size={rt.sizeDelta} pos={rt.anchoredPosition}");

            sb.AppendLine(line.ToString());

            for (int i = 0; i < t.childCount; i++)
                DumpHierarchy(t.GetChild(i), sb, depth + 1, maxDepth);
        }

        private static string GetPath(Transform t)
        {
            if (t == null) return "";
            var parts = new List<string>();
            int guard = 0;
            while (t != null && guard++ < 12)
            {
                parts.Insert(0, t.name);
                t = t.parent;
            }
            return string.Join("/", parts);
        }
    }
}
