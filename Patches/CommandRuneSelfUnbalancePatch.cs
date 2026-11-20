extern alias GSD2;

using System;
using System.Collections.Generic;
using HarmonyLib;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PKCore.Patches;

/// <summary>
/// Disables the Unbalance (botch) status effect penalty when using ability command runes in Suikoden 2 (GSD2).
/// Target runes include: Swallow, Fire Breath, Mayfly, White Tiger, Blue Drop, Twin Ring, Gozu, Trick.
/// Fully configurable via BepInEx config (faospark.pkbattlepatch.cfg).
/// </summary>
public static class CommandRuneSelfUnbalancePatch
{
    private static readonly Dictionary<int, ushort> OriginalBotchValues = new();
    private static readonly HashSet<string> TargetRuneKeywords = new(StringComparer.OrdinalIgnoreCase);
    // Fixed database rune IDs for all 8 self-unbalancing physical command runes in Suikoden 2
    private static readonly HashSet<int> TargetRuneIds = new()
    {
        25, // Gozu / Minotaur (Axes: Lorelai, Gijimu, Koyu)
        39, // Trick / Gadget (Meg & Gadget)
        42, // Mayfly (Mondo)
        43, // Swallow (Genshu)
        44, // Fire Breath (Bolgan)
        48, // Blue Drop (Abizboah & Rulodia)
        49, // White Tiger (Wakaba, Long Chan-Chan)
        53  // Twin Ring (Karen)
    };





    // Known alias dictionary to support matching English, Japanese, and romanized rune names
    private static readonly Dictionary<string, string[]> KnownRuneAliases = new(StringComparer.OrdinalIgnoreCase)
    {
        { "titan", new[] { "titan", "タイタン" } },
        { "falcon", new[] { "falcon", "はやぶさ", "hayabusa" } },
        { "viper", new[] { "viper", "バイパー" } },
        { "shrike", new[] { "shrike", "しぎ", "moorgate" } },
        { "swallow", new[] { "swallow", "golondrina", "つばめ" } },
        { "trick", new[] { "trick", "gadget", "artilugio", "truco", "からくり" } },
        { "fire breath", new[] { "fire breath", "firebreath", "aliento de fuego", "aliento fuego", "火炎", "火吹き" } },
        { "mayfly", new[] { "mayfly", "efimera", "かげろう" } },
        { "lion", new[] { "lion", "しし", "獅子" } },
        { "unicorn", new[] { "unicorn", "ユニコーン" } },
        { "pixie", new[] { "pixie", "ピクシー", "妖精" } },
        { "great hawk", new[] { "great hawk", "greathawk", "hawk", "大鷹", "とび", "kite" } },
        { "blue drop", new[] { "blue drop", "bluedrop", "blue_drop", "gota azul", "gota_azul", "gota", "goutte bleue", "青雫", "青いしずく", "あおしずく", "drop", "shizuku" } },
        { "white tiger", new[] { "white tiger", "whitetiger", "tigre blanco", "白虎", "びゃっこ", "tiger" } },
        { "twin ring", new[] { "twin ring", "twinring", "twin_ring", "anillo gemelo", "anillos gemelos", "双輪", "そうりん", "karen" } },
        { "gozu", new[] { "gozu", "minotaur", "minotauro", "牛頭", "ごず", "ox" } },
        { "nymph", new[] { "nymph", "ニンフ" } },
        { "sylph", new[] { "sylph", "シルフ" } }
    };

    public static bool IsLoaded { get; private set; }
    private static float _lastSyncTime = 0f;
    private static bool _loggedInitialPatch = false;

    public static void Initialize(Harmony harmony)
    {
        try
        {
            LoadConfiguration();

            if (Plugin.Config != null)
            {
                Plugin.Config.RemoveCommandRuneSelfUnbalance.SettingChanged += (_, _) =>
                {
                    LoadConfiguration();
                    ApplyRuneOverrides();
                };
            }

            harmony.PatchAll(typeof(CommandRuneSelfUnbalancePatch));

            SceneManager.sceneLoaded += (UnityEngine.Events.UnityAction<Scene, LoadSceneMode>)OnSceneLoaded;

            ApplyRuneOverrides();

            if (Plugin.Config.DetailedLogs.Value)
                Plugin.Log.LogInfo("[CommandRuneSelfUnbalancePatch] Initialized rune unbalance removal system successfully with all runtime hooks.");
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[CommandRuneSelfUnbalancePatch] Failed to initialize: {ex}");
        }
    }

    private static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        var ovit = GSD2::G2_SYS.Get_ovit_data();
        if (ovit == null || ovit.embl_data == null)
            return;

        ApplyRuneOverrides();
    }

    public static void Update()
    {
        if (Plugin.Config != null && !Plugin.Config.RemoveCommandRuneSelfUnbalance.Value)
            return;

        var ovit = GSD2::G2_SYS.Get_ovit_data();
        if (ovit == null || ovit.embl_data == null)
            return;

        // Periodic sync to keep in-memory botch overrides intact across save loads or asset reloads
        if (Time.time - _lastSyncTime > 3.0f)
        {
            _lastSyncTime = Time.time;
            ApplyRuneOverrides();
        }
    }

    private static void LoadConfiguration()
    {
        TargetRuneKeywords.Clear();

        try
        {
            foreach (var pair in KnownRuneAliases)
            {
                TargetRuneKeywords.Add(pair.Key);
                foreach (var alias in pair.Value)
                {
                    TargetRuneKeywords.Add(alias);
                }
            }

            IsLoaded = true;
            if (Plugin.Config.DetailedLogs.Value)
                Plugin.Log.LogInfo($"[CommandRuneSelfUnbalancePatch] Loaded {TargetRuneIds.Count} target rune IDs and {TargetRuneKeywords.Count} keyword aliases.");
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[CommandRuneSelfUnbalancePatch] Error loading configuration: {ex}");
        }
    }

    public static void ApplyRuneOverrides()
    {
        bool isEnabled = Plugin.Config == null || Plugin.Config.RemoveCommandRuneSelfUnbalance.Value;

        try
        {
            var ovit = GSD2::G2_SYS.Get_ovit_data();
            if (ovit == null || ovit.embl_data == null)
                return;

            var emblArray = ovit.embl_data;
            int count = emblArray.Length;
            int patchedCount = 0;

            for (int i = 0; i < count; i++)
            {
                var embl = emblArray[i];
                if (embl == null)
                    continue;

                // Restore original Potch price if previously zeroed
                if (OriginalBotchValues.TryGetValue(i, out ushort originalPrice) && originalPrice > 0 && embl.botch == 0)
                {
                    embl.botch = originalPrice;
                }
                else if (!OriginalBotchValues.ContainsKey(i) && embl.botch > 0)
                {
                    OriginalBotchValues[i] = embl.botch;
                }

                if (!isEnabled)
                {
                    continue;
                }

                string runeName = string.Empty;
                try
                {
                    runeName = GSD2::G2_SYS.G2_item_name(ovit, 2, i);
                }
                catch
                {
                    // Fallback
                }

                bool shouldDisable = ShouldDisableUnbalanceForRune(i, runeName);

                if (shouldDisable)
                {
                    bool hadUnbalance = false;

                    // Clear unbalance status bytes in the associated MAGI_DATA spell table
                    try
                    {
                        if (embl.magic_no != null)
                        {
                            for (int m = 0; m < embl.magic_no.Length; m++)
                            {
                                byte magiNo = embl.magic_no[m];
                                if (magiNo > 0)
                                {
                                    var magi = GSD2::G2_SYS.G2_magi_data(magiNo);
                                    if (magi != null && magi.status != null)
                                    {
                                        for (int s = 0; s < magi.status.Length; s++)
                                        {
                                            if (magi.status[s] == 2 || magi.status[s] == 1)
                                            {
                                                magi.status[s] = 0;
                                                hadUnbalance = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch
                    {
                        // Ignore
                    }

                    if (hadUnbalance || (!string.IsNullOrEmpty(runeName) && ShouldDisableUnbalanceForRune(i, runeName)))
                    {
                        patchedCount++;

                        if (!_loggedInitialPatch)
                        {
                            // Per-rune status cleared; summary logged below
                        }
                    }
                }
            }

            if (patchedCount > 0 && !_loggedInitialPatch)
            {
                _loggedInitialPatch = true;
                if (Plugin.Config.DetailedLogs.Value)
                    Plugin.Log.LogInfo($"[CommandRuneSelfUnbalancePatch] Successfully patched {patchedCount} ability runes to remove unbalance.");
            }
        }
        catch (Exception ex)
        {
            Plugin.Log.LogWarning($"[CommandRuneSelfUnbalancePatch] Error during rune unbalance override sync: {ex.Message}");
        }
    }

    private static bool ShouldDisableUnbalanceForRune(int runeId, string runeName)
    {
        if (TargetRuneIds.Contains(runeId))
            return true;

        if (string.IsNullOrWhiteSpace(runeName))
            return false;

        string cleanName = runeName.Trim().ToLowerInvariant();

        foreach (var keyword in TargetRuneKeywords)
        {
            if (cleanName.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                return true;
        }

        return false;
    }


    private static bool IsCharacterExecutingWhitelistedRune(GSD2::PM_DATA pm)
    {
        if (pm == null || pm.chara_no >= 6)
            return false;

        if (pm.c_koudou == 4)
            return false;

        try
        {
            var ovit = GSD2::G2_SYS.Get_ovit_data();
            int charaNo = pm.chara_no;
            int actualChano = GSD2::G2_SYS.G2_p_chano_get(charaNo);
            if (actualChano <= 0)
                actualChano = pm.chara_id;

            var bpc = pm.TryCast<GSD2::BattlePlayerCharacter>();
            var varia = bpc?.c_varia_dat ?? (actualChano > 0 ? GSD2::G2_SYS.G2_varia_dat(actualChano) : null);
            if (varia != null && varia.mon_eqp != null)
            {
                int slot = pm.c_monsyo;
                if (slot >= 0 && slot < varia.mon_eqp.Length)
                {
                    byte runeId = varia.mon_eqp[slot];
                    if (runeId > 0)
                    {
                        string name = ovit != null ? GSD2::G2_SYS.G2_item_name(ovit, 2, runeId) : string.Empty;
                        if (ShouldDisableUnbalanceForRune(runeId, name))
                            return true;
                    }
                }

                for (int s = 0; s < varia.mon_eqp.Length; s++)
                {
                    byte runeId = varia.mon_eqp[s];
                    if (runeId > 0)
                    {
                        string name = ovit != null ? GSD2::G2_SYS.G2_item_name(ovit, 2, runeId) : string.Empty;
                        if (ShouldDisableUnbalanceForRune(runeId, name))
                            return true;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Plugin.Log.LogWarning($"[CommandRuneSelfUnbalancePatch] Error evaluating rune unbalance check: {ex.Message}");
        }

        return false;
    }

    [HarmonyPatch(typeof(GSD2::PM_DATA), nameof(GSD2::PM_DATA.StatusSet))]
    [HarmonyPrefix]
    public static bool PM_DATA_StatusSet_Prefix(GSD2::PM_DATA __instance, int status_id)
    {
        if (Plugin.Config != null && !Plugin.Config.RemoveCommandRuneSelfUnbalance.Value)
            return true;

        if (status_id == 2 || status_id == GSD2::battle_h.SC_UNVALA)
        {
            if (IsCharacterExecutingWhitelistedRune(__instance))
            {
                if (__instance != null)
                {
                    __instance.unbalance_cnt = 0;
                    __instance.unbalance_flg = 0;
                    __instance.status &= ~2u;
                }

                if (Plugin.Config.DetailedLogs.Value)
                    Plugin.Log.LogInfo($"[CommandRuneSelfUnbalancePatch] Blocked Unbalance penalty for character #{__instance?.chara_no} (whitelisted rune action).");
                return false;
            }
        }

        return true;
    }

    [HarmonyPatch(typeof(GSD2::BattlePlayerCharacter), nameof(GSD2::BattlePlayerCharacter.PlayerStatusSet))]
    [HarmonyPrefix]
    public static bool BattlePlayerCharacter_PlayerStatusSet_Prefix(GSD2::BattlePlayerCharacter __instance, ref ushort status)
    {
        if (Plugin.Config != null && !Plugin.Config.RemoveCommandRuneSelfUnbalance.Value)
            return true;

        if ((status & 0x02) != 0)
        {
            if (IsCharacterExecutingWhitelistedRune(__instance))
            {
                status = (ushort)(status & ~0x02);
                if (Plugin.Config.DetailedLogs.Value)
                    Plugin.Log.LogInfo($"[CommandRuneSelfUnbalancePatch] Stripped Unbalance bit (0x02) for player character #{__instance?.chara_no} (whitelisted rune action).");

                if (status == 0)
                {
                    return false;
                }
            }
        }

        return true;
    }
}
