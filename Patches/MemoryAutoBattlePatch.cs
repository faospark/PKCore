extern alias GSD2;

using System;
using System.Collections.Generic;
using HarmonyLib;
using UnityEngine.SceneManagement;

namespace PKCore.Patches;

/// <summary>
/// Memory Auto-Battle patch for Suikoden 2 (GSD2):
/// 1. Remembers the last action chosen by the player per character (Attack vs Magic/Rune).
/// 2. In Auto-Battle (Omakase), replays the remembered action instead of forcing basic Attack.
/// 3. If MP for that spell level is depleted or the character cannot use magic (e.g. silenced),
///    falls back cleanly to basic Attack.
/// 4. Optionally persists or clears across battles based on user config.
/// </summary>
public static class MemoryAutoBattlePatch
{
    public static bool IsLoaded { get; private set; }

    public struct RememberedAction
    {
        public sbyte Koudou;  // 0 = Attack, 2 = Magic/Rune
        public sbyte Item;    // Magic ID / Spell level (0..3) or command rune sub-ID
        public sbyte Monsyo;  // Emblem / Rune slot (0..2)
    }

    private static readonly Dictionary<int, RememberedAction> _rememberedActions = new();

    public static void Initialize(Harmony harmony)
    {
        try
        {
            Plugin.Log.LogInfo("[MemoryAutoBattlePatch] Initializing Memory Auto-Battle for Suikoden 2...");
            harmony.PatchAll(typeof(MemoryAutoBattlePatch));
            SceneManager.sceneLoaded += (UnityEngine.Events.UnityAction<Scene, LoadSceneMode>)OnSceneLoaded;
            IsLoaded = true;
            Plugin.Log.LogInfo("[MemoryAutoBattlePatch] Initialized Memory Auto-Battle successfully.");
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[MemoryAutoBattlePatch] Failed to initialize: {ex}");
        }
    }

    private static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (!GameDetection.IsGSD2())
            return;

        if (Plugin.Config != null && !Plugin.Config.MemoryAutoBattlePersistAcrossBattles.Value)
        {
            _rememberedActions.Clear();
        }
    }

    public static void ResetMemory()
    {
        _rememberedActions.Clear();
    }

    /// <summary>
    /// When character selects a magic/rune command, track it immediately.
    /// </summary>
    [HarmonyPatch(typeof(GSD2::BattlePlayerCharacter), nameof(GSD2::BattlePlayerCharacter.SetUseMagicIDs))]
    [HarmonyPostfix]
    public static void BattlePlayerCharacter_SetUseMagicIDs_Postfix(GSD2::BattlePlayerCharacter __instance, int magicID, int emblemID)
    {
        try
        {
            if (!GameDetection.IsGSD2() || Plugin.Config == null || !Plugin.Config.EnableMemoryAutoBattle.Value)
                return;

            if (__instance == null)
                return;

            int charaNo = __instance.chara_no;
            if (charaNo <= 0)
                return;

            _rememberedActions[charaNo] = new RememberedAction
            {
                Koudou = 2,
                Item = (sbyte)magicID,
                Monsyo = (sbyte)emblemID
            };

            if (Plugin.Config.DetailedLogs.Value)
            {
                Plugin.Log.LogInfo($"[MemoryAutoBattle] Remembered Rune/Magic for chara {charaNo}: emblem={emblemID}, magic={magicID}");
            }
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[MemoryAutoBattle:SetUseMagicIDs] Error: {ex}");
        }
    }

    /// <summary>
    /// When manual turn commands are finalized and submitted, record each character's action.
    /// </summary>
    [HarmonyPatch(typeof(GSD2::BattleManager), "last_window")]
    [HarmonyPrefix]
    public static void BattleManager_last_window_Prefix(GSD2::BattleManager __instance)
    {
        try
        {
            if (!GameDetection.IsGSD2() || Plugin.Config == null || !Plugin.Config.EnableMemoryAutoBattle.Value)
                return;

            if (__instance == null)
                return;

            var party = __instance.PlayerParty;
            if (party == null)
                return;

            int count = party.Count;
            for (int i = 0; i < count; i++)
            {
                var charData = party[i];
                if (charData == null)
                    continue;

                int charaNo = charData.chara_no;
                if (charaNo <= 0)
                    continue;

                // 0 = Attack, 2 = Magic/Rune
                if (charData.c_koudou == 0)
                {
                    _rememberedActions[charaNo] = new RememberedAction
                    {
                        Koudou = 0,
                        Item = 0,
                        Monsyo = 0
                    };
                }
                else if (charData.c_koudou == 2)
                {
                    _rememberedActions[charaNo] = new RememberedAction
                    {
                        Koudou = 2,
                        Item = charData.c_item,
                        Monsyo = charData.c_monsyo
                    };
                }
            }
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[MemoryAutoBattle:last_window] Error: {ex}");
        }
    }

    /// <summary>
    /// When Auto-Battle (Omakase) is selected, replay remembered actions.
    /// Vanilla omakase_window has already set c_koudou = 0 and selected valid living enemy targets.
    /// </summary>
    [HarmonyPatch(typeof(GSD2::BattleManager), "omakase_window")]
    [HarmonyPostfix]
    public static void BattleManager_omakase_window_Postfix(GSD2::BattleManager __instance)
    {
        try
        {
            if (!GameDetection.IsGSD2() || Plugin.Config == null || !Plugin.Config.EnableMemoryAutoBattle.Value)
                return;

            if (__instance == null)
                return;

            var party = __instance.PlayerParty;
            if (party == null)
                return;

            int count = party.Count;
            for (int i = 0; i < count; i++)
            {
                var charData = party[i];
                if (charData == null)
                    continue;

                int charaNo = charData.chara_no;
                if (charaNo <= 0)
                    continue;

                if (!_rememberedActions.TryGetValue(charaNo, out var action))
                    continue;

                // If remembered action is Rune / Magic
                if (action.Koudou == 2)
                {
                    // Check if character can use magic/runes (not dead, sleeping, panic, silenced, etc.)
                    if (!charData.MagicCanCheck())
                    {
                        if (Plugin.Config.DetailedLogs.Value)
                            Plugin.Log.LogInfo($"[MemoryAutoBattle] Chara {charaNo} cannot cast magic (status), falling back to Attack.");
                        continue;
                    }

                    // Check MP for spell levels 0..3
                    if (action.Item >= 0 && action.Item < 4)
                    {
                        var varia = GSD2::G2_SYS.G2_varia_dat(charaNo);
                        if (varia != null && varia.mp != null)
                        {
                            if (action.Item < varia.mp.Length && varia.mp[action.Item] <= 0)
                            {
                                // Out of MP! Keep default Attack
                                if (Plugin.Config.DetailedLogs.Value)
                                    Plugin.Log.LogInfo($"[MemoryAutoBattle] Chara {charaNo} out of MP for spell level {action.Item}, falling back to Attack.");
                                continue;
                            }
                        }
                    }

                    // Check command rune usability if applicable
                    if (!charData.SpecialCanCheck())
                    {
                        if (Plugin.Config.DetailedLogs.Value)
                            Plugin.Log.LogInfo($"[MemoryAutoBattle] Chara {charaNo} SpecialCanCheck failed, falling back to Attack.");
                        continue;
                    }

                    // Eligible! Apply remembered magic/rune
                    var bpc = charData.TryCast<GSD2::BattlePlayerCharacter>();
                    if (bpc != null)
                    {
                        bpc.SetUseMagicIDs(action.Item, action.Monsyo, true);
                        bpc.c_koudou = 2;

                        if (Plugin.Config.DetailedLogs.Value)
                        {
                            Plugin.Log.LogInfo($"[MemoryAutoBattle] Replaying Rune/Magic for chara {charaNo}: emblem={action.Monsyo}, magic={action.Item}");
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[MemoryAutoBattle:omakase_window] Error: {ex}");
        }
    }

    /// <summary>
    /// Clear memory when battle initializes unless persistence is enabled.
    /// </summary>
    [HarmonyPatch(typeof(GSD2::BattleManager), "PlayerInit")]
    [HarmonyPostfix]
    public static void BattleManager_PlayerInit_Postfix(GSD2::BattleManager __instance)
    {
        try
        {
            if (!GameDetection.IsGSD2())
                return;

            if (Plugin.Config != null && !Plugin.Config.MemoryAutoBattlePersistAcrossBattles.Value)
            {
                _rememberedActions.Clear();
                if (Plugin.Config.DetailedLogs.Value)
                {
                    Plugin.Log.LogInfo("[MemoryAutoBattle] Cleared remembered actions on PlayerInit.");
                }
            }
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[MemoryAutoBattle:PlayerInit] Error: {ex}");
        }
    }
}
