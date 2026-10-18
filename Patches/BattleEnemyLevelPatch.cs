extern alias GSD1;
extern alias GSD2;

using HarmonyLib;
using ShareUI.Battle;
using System;
using System.Collections.Generic;
using TMPro;

namespace PKCore.Patches
{
    /// <summary>
    /// Displays enemy levels in the battle target selection window for Suikoden 1 and Suikoden 2 (e.g. "Bonapart Lv.25").
    /// </summary>
    [HarmonyPatch]
    public static class BattleEnemyLevelPatch
    {
        private static readonly Dictionary<int, int> _slotLevels = new();

        [HarmonyPatch(typeof(UIBattleWindowMonster), nameof(UIBattleWindowMonster.BattleInitialize))]
        [HarmonyPostfix]
        public static void BattleInitialize_Postfix(UIBattleWindowMonster __instance)
        {
            try
            {
                _slotLevels.Clear();
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
                if (!Plugin.Config.ShowEnemyLevelInBattle.Value)
                    return;

                if (string.IsNullOrEmpty(name))
                    return;

                int level = GetEnemyLevel(index);
                if (level > 0 && !name.Contains("Lv."))
                {
                    name = $"{name} Lv.{level}";
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
                        text.fontSizeMin = 13f;
                        text.fontSizeMax = 20f;
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
                if (!Plugin.Config.ShowEnemyLevelInBattle.Value)
                    return;

                int level = GetGSD1EnemyLevel(index);
                if (level > 0)
                {
                    _slotLevels[index] = level;
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
                if (!Plugin.Config.ShowEnemyLevelInBattle.Value)
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

        #endregion

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
    }
}
