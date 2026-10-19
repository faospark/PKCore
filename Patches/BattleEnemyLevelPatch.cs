extern alias GSD1;
extern alias GSD2;

using HarmonyLib;
using ShareUI;
using ShareUI.Battle;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PKCore.Patches
{
    /// <summary>
    /// Displays enemy levels and HP in the battle target selection window for Suikoden 1 and Suikoden 2,
    /// and widens the container of the monster names to accommodate long names and multi-line stats.
    /// </summary>
    [HarmonyPatch]
    public static class BattleEnemyLevelPatch
    {
        private static readonly Dictionary<int, int> _slotLevels = new();
        private static readonly Dictionary<int, (int curHp, int maxHp)> _slotHps = new();
        private static readonly HashSet<int> _widenedInstanceIds = new();

        [HarmonyPatch(typeof(UIBattleWindowMonster), nameof(UIBattleWindowMonster.BattleInitialize))]
        [HarmonyPostfix]
        public static void BattleInitialize_Postfix(UIBattleWindowMonster __instance)
        {
            try
            {
                _slotLevels.Clear();
                _slotHps.Clear();

                if (__instance != null)
                {
                    float widthScale = Plugin.Config.MonsterWindowWidthScale.Value;
                    if (widthScale > 1.0f)
                    {
                        WidenMonsterWindow(__instance, widthScale);
                    }
                }
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"[BattleEnemyLevelPatch] BattleInitialize_Postfix error: {ex}");
            }
        }

        [HarmonyPatch(typeof(UIBattleWindowMonster), nameof(UIBattleWindowMonster.SetMonsterName))]
        [HarmonyPrefix]
        public static void SetMonsterName_Prefix(UIBattleWindowMonster __instance, int index, ref string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                    return;

                float widthScale = Plugin.Config.MonsterWindowWidthScale.Value;
                if (widthScale > 1.0f && __instance != null)
                {
                    WidenMonsterWindow(__instance, widthScale);
                }

                if (Plugin.Config.ShowEnemyLevelInBattle.Value)
                {
                    int level = GetEnemyLevel(index);
                    if (level > 0 && !name.Contains("Lv."))
                    {
                        name = $"{name} Lv.{level}";
                    }
                }

                if (Plugin.Config.ShowEnemyHpInBattle.Value)
                {
                    var (curHp, maxHp) = GetEnemyHp(index);
                    if (maxHp > 0 && !name.Contains("HP"))
                    {
                        name = $"{name}\nHP {curHp}/{maxHp}";
                    }
                }

                // Adjust text component to avoid clipping long names
                if (__instance != null && __instance.m_monsterList != null && index >= 0 && index < __instance.m_monsterList.Count)
                {
                    var cell = __instance.m_monsterList[index];
                    if (cell != null && cell.leftText != null)
                    {
                        var text = cell.leftText;
                        text.enableWordWrapping = false;
                        text.enableAutoSizing = true;
                        text.fontSizeMin = 10f;
                        text.fontSizeMax = 18f;
                        text.overflowMode = TextOverflowModes.Overflow;
                    }
                }
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"[BattleEnemyLevelPatch] SetMonsterName_Prefix error: {ex}");
            }
        }

        #region Suikoden 1 Hooks

        [HarmonyPatch(typeof(GSD1::UIBattleManager), nameof(GSD1::UIBattleManager.UpdateEnemyWindowUI))]
        [HarmonyPrefix]
        public static void GSD1_UpdateEnemyWindowUI_Prefix(GSD1::UIBattleManager __instance, int index, ref string name, bool enable)
        {
            try
            {
                if (Plugin.Config.ShowEnemyLevelInBattle.Value)
                {
                    int level = GetGSD1EnemyLevel(index);
                    if (level > 0)
                    {
                        _slotLevels[index] = level;
                    }
                }

                if (Plugin.Config.ShowEnemyHpInBattle.Value)
                {
                    var hp = GetGSD1EnemyHp(index);
                    if (hp.maxHp > 0)
                    {
                        _slotHps[index] = hp;
                    }
                }
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"[BattleEnemyLevelPatch] GSD1_UpdateEnemyWindowUI_Prefix error: {ex}");
            }
        }

        private static int GetGSD1EnemyLevel(int slotIndex)
        {
            try
            {
                var bw = GSD1::BattleBase.battle_work;
                var ww = GSD1::BattleBase.window_work;
                if (bw == null || ww == null || bw.monster_data_table == null || ww.monster_window_data == null || ww.monster_position_data == null)
                    return 0;

                for (int i = 0; i < bw.monster_kazu; i++)
                {
                    if (i < ww.monster_position_data.Length && (ww.monster_position_data[i] - 1) == slotIndex)
                    {
                        int monsterIdx = ww.monster_window_data[i];
                        if (monsterIdx >= 0 && monsterIdx < bw.monster_data_table.Length)
                        {
                            var monster = bw.monster_data_table[monsterIdx];
                            if (monster != null)
                                return monster.level;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"[BattleEnemyLevelPatch] GetGSD1EnemyLevel error: {ex}");
            }
            return 0;
        }

        private static (int curHp, int maxHp) GetGSD1EnemyHp(int slotIndex)
        {
            try
            {
                var bw = GSD1::BattleBase.battle_work;
                var ww = GSD1::BattleBase.window_work;
                if (bw == null || ww == null || bw.monster_data_table == null || ww.monster_window_data == null || ww.monster_position_data == null)
                    return (0, 0);

                for (int i = 0; i < bw.monster_kazu; i++)
                {
                    if (i < ww.monster_position_data.Length && (ww.monster_position_data[i] - 1) == slotIndex)
                    {
                        int monsterIdx = ww.monster_window_data[i];
                        int maxHp = 0;
                        int curHp = 0;

                        if (monsterIdx >= 0 && monsterIdx < bw.monster_data_table.Length)
                        {
                            var monster = bw.monster_data_table[monsterIdx];
                            if (monster != null)
                            {
                                maxHp = monster.hp;
                                curHp = monster.hp;
                            }
                        }

                        // Try to read live combatant HP from pm_data
                        if (bw.pm_data != null)
                        {
                            int pmIndex = bw.player_kazu + 1 + i;
                            if (pmIndex >= 0 && pmIndex < bw.pm_data.Length && bw.pm_data[pmIndex] != null)
                            {
                                var pm = bw.pm_data[pmIndex];
                                curHp = Math.Max(0, (int)pm.hp);
                                if (pm.max_hp > 0)
                                    maxHp = pm.max_hp;
                            }
                            else
                            {
                                int altIndex = bw.player_kazu + i;
                                if (altIndex >= 0 && altIndex < bw.pm_data.Length && bw.pm_data[altIndex] != null)
                                {
                                    var pm = bw.pm_data[altIndex];
                                    curHp = Math.Max(0, (int)pm.hp);
                                    if (pm.max_hp > 0)
                                        maxHp = pm.max_hp;
                                }
                            }
                        }

                        if (maxHp > 0)
                            return (curHp, maxHp);
                    }
                }
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"[BattleEnemyLevelPatch] GetGSD1EnemyHp error: {ex}");
            }
            return (0, 0);
        }

        #endregion

        #region Suikoden 2 Hooks

        [HarmonyPatch(typeof(GSD2::UIBattleManager), nameof(GSD2::UIBattleManager.UpdateUnitWindow))]
        [HarmonyPrefix]
        public static void GSD2_UpdateUnitWindow_Prefix(
            GSD2::UIBattleManager __instance,
            Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppStructArray<byte> numList,
            GSD2::BattleParty playerParty,
            GSD2::BattleParty enemyParty)
        {
            try
            {
                if (!Plugin.Config.ShowEnemyLevelInBattle.Value && !Plugin.Config.ShowEnemyHpInBattle.Value)
                    return;

                // Read enemy levels directly from battle_work.pm_data.
                // This avoids invoking BattleParty[index] (which calls System.Linq.Enumerable.ElementAt
                // and throws ArgumentOutOfRangeException if dead/sparse monsters change the collection count).
                var bm = GSD2::BattleManager.Instance;
                var pmData = bm?.battle_work?.pm_data;
                if (pmData != null)
                {
                    for (int i = 0; i < pmData.Length; i++)
                    {
                        var pm = pmData[i];
                        if (pm == null || pm.IsDead || pm.IsPlayer)
                            continue;

                        int pos = pm.GetPosition(true);
                        int slotIndex = pos - 1;
                        if (pm.CheckRowFormation(2))
                        {
                            slotIndex = pos + 2;
                        }

                        if (pm.monster_data != null)
                        {
                            _slotLevels[slotIndex] = pm.monster_data.level;
                            int curHp = Math.Max(0, (int)pm.hp);
                            int maxHp = pm.max_hp > 0 ? (int)pm.max_hp : (int)pm.monster_data.hp;
                            _slotHps[slotIndex] = (curHp, maxHp);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"[BattleEnemyLevelPatch] GSD2_UpdateUnitWindow_Prefix error: {ex}");
            }
        }

        private static int GetGSD2EnemyLevel(int slotIndex)
        {
            try
            {
                var bm = GSD2::BattleManager.Instance;
                if (bm != null && bm.battle_work != null && bm.battle_work.pm_data != null)
                {
                    for (int i = 0; i < bm.battle_work.pm_data.Length; i++)
                    {
                        var pm = bm.battle_work.pm_data[i];
                        if (pm == null || pm.IsDead || pm.IsPlayer)
                            continue;

                        int pos = pm.GetPosition(true);
                        int slot = pos - 1;
                        if (pm.CheckRowFormation(2))
                            slot = pos + 2;

                        if (slot == slotIndex && pm.monster_data != null)
                            return pm.monster_data.level;
                    }
                }
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"[BattleEnemyLevelPatch] GetGSD2EnemyLevel error: {ex}");
            }
            return 0;
        }

        private static (int curHp, int maxHp) GetGSD2EnemyHp(int slotIndex)
        {
            try
            {
                var bm = GSD2::BattleManager.Instance;
                if (bm != null && bm.battle_work != null && bm.battle_work.pm_data != null)
                {
                    for (int i = 0; i < bm.battle_work.pm_data.Length; i++)
                    {
                        var pm = bm.battle_work.pm_data[i];
                        if (pm == null || pm.IsDead || pm.IsPlayer)
                            continue;

                        int pos = pm.GetPosition(true);
                        int slot = pos - 1;
                        if (pm.CheckRowFormation(2))
                            slot = pos + 2;

                        if (slot == slotIndex)
                        {
                            int curHp = Math.Max(0, (int)pm.hp);
                            int maxHp = pm.max_hp > 0 ? (int)pm.max_hp : (pm.monster_data != null ? (int)pm.monster_data.hp : curHp);
                            return (curHp, maxHp);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"[BattleEnemyLevelPatch] GetGSD2EnemyHp error: {ex}");
            }
            return (0, 0);
        }

        #endregion

        #region Helper Methods

        private static int GetEnemyLevel(int slotIndex)
        {
            if (_slotLevels.TryGetValue(slotIndex, out int cachedLevel) && cachedLevel > 0)
                return cachedLevel;

            if (GameDetection.IsGSD1())
            {
                int lvl = GetGSD1EnemyLevel(slotIndex);
                if (lvl > 0)
                {
                    _slotLevels[slotIndex] = lvl;
                    return lvl;
                }
            }
            else if (GameDetection.IsGSD2())
            {
                int lvl = GetGSD2EnemyLevel(slotIndex);
                if (lvl > 0)
                {
                    _slotLevels[slotIndex] = lvl;
                    return lvl;
                }
            }

            return 0;
        }

        private static (int curHp, int maxHp) GetEnemyHp(int slotIndex)
        {
            if (GameDetection.IsGSD1())
            {
                var hp = GetGSD1EnemyHp(slotIndex);
                if (hp.maxHp > 0)
                {
                    _slotHps[slotIndex] = hp;
                    return hp;
                }
            }
            else if (GameDetection.IsGSD2())
            {
                var hp = GetGSD2EnemyHp(slotIndex);
                if (hp.maxHp > 0)
                {
                    _slotHps[slotIndex] = hp;
                    return hp;
                }
            }

            if (_slotHps.TryGetValue(slotIndex, out var cached) && cached.maxHp > 0)
                return cached;

            return (0, 0);
        }

        private static void WidenMonsterWindow(UIBattleWindowMonster window, float widthScale)
        {
            try
            {
                if (window == null)
                    return;

                int instanceId = window.GetInstanceID();
                if (!_widenedInstanceIds.Add(instanceId))
                    return;

                Plugin.Log.LogInfo($"[BattleEnemyLevelPatch] Widening monster selection window by {widthScale:0.##}x (Instance ID: {instanceId})");

                // 1. Widen root window RectTransform
                var rootRt = window.GetComponent<RectTransform>();
                if (rootRt != null && rootRt.sizeDelta.x > 0f)
                {
                    rootRt.sizeDelta = new Vector2(rootRt.sizeDelta.x * widthScale, rootRt.sizeDelta.y);
                }

                // 2. Widen game-specific layout containers and backgrounds
                if (window.m_GS1Layout != null)
                {
                    WidenLayoutAndChildren(window.m_GS1Layout, widthScale);
                }
                if (window.m_GS2Layout != null)
                {
                    WidenLayoutAndChildren(window.m_GS2Layout, widthScale);
                }
                if (window.m_GS2BackLayout != null)
                {
                    WidenLayoutAndChildren(window.m_GS2BackLayout, widthScale);
                }

                // 3. Widen cells
                var cells = window.m_monsterList;
                if (cells == null || cells.Count == 0)
                    cells = GameDetection.IsGSD1() ? window.m_monsterListGS1 : window.m_monsterListGS2;

                if (cells != null && cells.Count > 0)
                {
                    WidenCells(cells, widthScale);
                }
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"[BattleEnemyLevelPatch] WidenMonsterWindow error: {ex}");
            }
        }

        private static void WidenLayoutAndChildren(GameObject layoutObj, float widthScale)
        {
            if (layoutObj == null)
                return;

            var rt = layoutObj.GetComponent<RectTransform>();
            if (rt != null && rt.sizeDelta.x > 0f)
            {
                rt.sizeDelta = new Vector2(rt.sizeDelta.x * widthScale, rt.sizeDelta.y);
            }

            var grid = layoutObj.GetComponent<GridLayoutGroup>();
            if (grid != null)
            {
                grid.cellSize = new Vector2(grid.cellSize.x * widthScale, grid.cellSize.y);
                grid.spacing = new Vector2(grid.spacing.x * widthScale, grid.spacing.y);
            }

            var horizontal = layoutObj.GetComponent<HorizontalLayoutGroup>();
            if (horizontal != null)
            {
                horizontal.spacing *= widthScale;
            }

            // Widen direct child background frames / graphics (that are not cells themselves)
            for (int i = 0; i < layoutObj.transform.childCount; i++)
            {
                var child = layoutObj.transform.GetChild(i);
                if (child.GetComponent<UIWindowListCell>() == null)
                {
                    var childRt = child.TryCast<RectTransform>();
                    if (childRt != null && childRt.sizeDelta.x > 0f)
                    {
                        childRt.sizeDelta = new Vector2(childRt.sizeDelta.x * widthScale, childRt.sizeDelta.y);
                    }
                }
            }
        }

        private static void WidenCells(Il2CppSystem.Collections.Generic.List<UIWindowListCell> cells, float widthScale)
        {
            var cellRts = new List<RectTransform>();

            for (int i = 0; i < cells.Count; i++)
            {
                var cell = cells[i];
                if (cell == null)
                    continue;

                var cellRt = cell.rectTransform ?? cell.GetComponent<RectTransform>();
                if (cellRt != null)
                {
                    cellRts.Add(cellRt);
                    if (cellRt.sizeDelta.x > 0f)
                    {
                        cellRt.sizeDelta = new Vector2(cellRt.sizeDelta.x * widthScale, cellRt.sizeDelta.y);
                    }
                }

                if (cell.leftText != null)
                {
                    var textRt = cell.leftText.rectTransform;
                    if (textRt != null && textRt.sizeDelta.x > 0f)
                    {
                        textRt.sizeDelta = new Vector2(textRt.sizeDelta.x * widthScale, textRt.sizeDelta.y);
                    }
                }

                if (cell.rightText != null)
                {
                    var rightRt = cell.rightText.rectTransform;
                    if (rightRt != null && rightRt.sizeDelta.x > 0f)
                    {
                        rightRt.sizeDelta = new Vector2(rightRt.sizeDelta.x * widthScale, rightRt.sizeDelta.y);
                    }
                }
            }

            // Adjust horizontal cell positions if cells are placed in multiple columns without an auto-layout group
            if (cellRts.Count >= 2)
            {
                var parent = cellRts[0].parent;
                bool hasAutoLayout = parent != null && (parent.GetComponent<LayoutGroup>() != null);
                if (!hasAutoLayout)
                {
                    float minX = float.MaxValue;
                    float maxX = float.MinValue;
                    for (int i = 0; i < cellRts.Count; i++)
                    {
                        float x = cellRts[i].anchoredPosition.x;
                        if (x < minX) minX = x;
                        if (x > maxX) maxX = x;
                    }

                    // Only adjust if there are distinct columns (horizontal spread > 5)
                    if (maxX - minX > 5f)
                    {
                        if (minX < -5f && maxX > 5f)
                        {
                            // Center-anchored columns
                            for (int i = 0; i < cellRts.Count; i++)
                            {
                                var pos = cellRts[i].anchoredPosition;
                                cellRts[i].anchoredPosition = new Vector2(pos.x * widthScale, pos.y);
                            }
                        }
                        else
                        {
                            // Left- or offset-anchored columns
                            for (int i = 0; i < cellRts.Count; i++)
                            {
                                var pos = cellRts[i].anchoredPosition;
                                float offsetX = pos.x - minX;
                                cellRts[i].anchoredPosition = new Vector2(minX + (offsetX * widthScale), pos.y);
                            }
                        }
                    }
                }
            }
        }

        #endregion
    }
}
