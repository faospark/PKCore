extern alias GSD2;

using System;
using System.Collections.Generic;
using HarmonyLib;
using UnityEngine.SceneManagement;

namespace PKCore.Patches;

/// <summary>
/// Memory Auto-Battle patch for Suikoden 2 (GSD2):
/// 1. Remembers the last action chosen by the player per character (Attack, Defend, or Magic/Rune).
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
        public sbyte Koudou;  // 0 = Attack, 1 = Defend, 2 = Magic/Rune
        public sbyte Item;    // Magic ID / Spell level (0..3) or command rune sub-ID
        public sbyte Monsyo;  // Emblem / Rune slot (0..2)
    }

    private static readonly Dictionary<int, RememberedAction> _rememberedActions = new();
    private static bool _isAutoBattle;
    private static bool _isReplayingOmakase;
    private static bool _turnRecorded;

    private static int GetCharacterId(GSD2::PM_DATA charData)
    {
        if (charData == null)
            return -1;

        if (charData.chara_id > 0)
            return charData.chara_id;

        if (charData.chara_no >= 0)
        {
            try
            {
                int id = GSD2::G2_SYS.G2_p_chano_get(charData.chara_no);
                if (id > 0)
                    return id;
            }
            catch { }
        }

        return -1;
    }

    private static int FindLivingEnemyTarget(GSD2::BattleManager manager, GSD2::BattleParty playerParty)
    {
        int playerCount = playerParty != null ? playerParty.Count : 0;

        // First check if vanilla omakase_window already assigned a valid enemy target to another party member
        if (playerParty != null)
        {
            for (int i = 0; i < playerCount; i++)
            {
                var member = playerParty[i];
                if (member != null && member.c_mokuhyo >= playerCount)
                    return member.c_mokuhyo;
            }
        }

        // Otherwise scan EnemyParty for the first living targetable monster
        var enemyParty = manager?.EnemyParty;
        if (enemyParty != null)
        {
            for (int i = 0; i < enemyParty.Count; i++)
            {
                var enemy = enemyParty[i];
                if (enemy != null && enemy.dead_flg == 0 && enemy.hp > 0 && enemy.chara_no >= playerCount)
                    return enemy.chara_no;
            }

            for (int i = 0; i < enemyParty.Count; i++)
            {
                var enemy = enemyParty[i];
                if (enemy != null && enemy.chara_no >= playerCount)
                    return enemy.chara_no;
            }
        }

        return -1;
    }

    public static void Initialize(Harmony harmony)
    {
        try
        {
            if (Plugin.Config.DetailedLogs.Value)
                Plugin.Log.LogInfo("[MemoryAutoBattlePatch] Initializing Memory Auto-Battle for Suikoden 2...");
            harmony.PatchAll(typeof(MemoryAutoBattlePatch));
            SceneManager.sceneLoaded += (UnityEngine.Events.UnityAction<Scene, LoadSceneMode>)OnSceneLoaded;
            IsLoaded = true;
            if (Plugin.Config.DetailedLogs.Value)
                Plugin.Log.LogInfo("[MemoryAutoBattlePatch] Initialized Memory Auto-Battle successfully.");
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[MemoryAutoBattlePatch] Failed to initialize: {ex}");
        }
    }

    private static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Title" || scene.name == "MainMenu")
        {
            _rememberedActions.Clear();
            _isAutoBattle = false;
            _isReplayingOmakase = false;
            _turnRecorded = false;
        }
    }

    public static void ResetMemory()
    {
        _rememberedActions.Clear();
        _isAutoBattle = false;
        _isReplayingOmakase = false;
        _turnRecorded = false;
    }

    /// <summary>
    /// When character selects a magic/rune command programmatically, track it immediately.
    /// </summary>
    [HarmonyPatch(typeof(GSD2::BattlePlayerCharacter), nameof(GSD2::BattlePlayerCharacter.SetUseMagicIDs))]
    [HarmonyPostfix]
    public static void BattlePlayerCharacter_SetUseMagicIDs_Postfix(GSD2::BattlePlayerCharacter __instance, int magicID, int emblemID)
    {
        try
        {
            if (_isReplayingOmakase)
                return;

            if (Plugin.Config == null || !Plugin.Config.EnableMemoryAutoBattle.Value)
                return;

            if (__instance == null)
                return;

            int charaId = GetCharacterId(__instance);
            if (charaId <= 0)
                return;

            _rememberedActions[charaId] = new RememberedAction
            {
                Koudou = 2,
                Item = (sbyte)magicID,
                Monsyo = (sbyte)emblemID
            };

            if (Plugin.Config.DetailedLogs.Value)
                Plugin.Log.LogInfo($"[MemoryAutoBattle] Remembered Rune/Magic for charaId {charaId} (slot {__instance.chara_no}): emblem={emblemID}, magic={magicID}");
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[MemoryAutoBattle:SetUseMagicIDs] Error: {ex}");
        }
    }

    /// <summary>
    /// When the player finishes selecting a Rune/Magic command in the battle UI, remember it immediately.
    /// </summary>
    [HarmonyPatch(typeof(GSD2::BattleManager), "command_magic99")]
    [HarmonyPrefix]
    public static void BattleManager_command_magic99_Prefix(GSD2::BattleManager __instance)
    {
        try
        {
            if (Plugin.Config == null || !Plugin.Config.EnableMemoryAutoBattle.Value)
                return;

            var party = __instance?.PlayerParty;
            if (party == null)
                return;

            var bw = GSD2::BATTLE_WORK.instance;
            if (bw?.window_work == null)
                return;

            int idx = bw.window_work.selected_player;
            if (idx >= 0 && idx < party.Count)
            {
                var charData = party[idx];
                int charaId = GetCharacterId(charData);
                if (charData != null && charaId > 0 && charData.c_koudou == 2)
                {
                    _rememberedActions[charaId] = new RememberedAction
                    {
                        Koudou = 2,
                        Item = charData.c_item,
                        Monsyo = charData.c_monsyo
                    };

                    if (Plugin.Config.DetailedLogs.Value)
                        Plugin.Log.LogInfo($"[MemoryAutoBattle] Remembered Rune/Magic for charaId {charaId} (slot {charData.chara_no}): emblem={charData.c_monsyo}, magic={charData.c_item}");
                }
            }
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[MemoryAutoBattle:command_magic99] Error: {ex}");
        }
    }

    /// <summary>
    /// When the player chooses Defend (Guard) for a character, remember it immediately.
    /// </summary>
    [HarmonyPatch(typeof(GSD2::BattleManager), "command_guard")]
    [HarmonyPostfix]
    public static void BattleManager_command_guard_Postfix(GSD2::BattleManager __instance)
    {
        try
        {
            if (Plugin.Config == null || !Plugin.Config.EnableMemoryAutoBattle.Value)
                return;

            if (__instance == null)
                return;

            var party = __instance.PlayerParty;
            if (party == null)
                return;

            var bw = GSD2::BATTLE_WORK.instance;
            if (bw != null && bw.window_work != null)
            {
                int idx = bw.window_work.selected_player;
                if (idx >= 0 && idx < party.Count)
                {
                    var charData = party[idx];
                    int charaId = GetCharacterId(charData);
                    if (charData != null && charaId > 0 && charData.c_koudou == 1)
                    {
                        _rememberedActions[charaId] = new RememberedAction
                        {
                            Koudou = 1,
                            Item = 0,
                            Monsyo = 0
                        };

                        if (Plugin.Config.DetailedLogs.Value)
                            Plugin.Log.LogInfo($"[MemoryAutoBattle] Remembered Defend for charaId {charaId} (slot {charData.chara_no})");
                        return;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[MemoryAutoBattle:command_guard] Error: {ex}");
        }
    }

    /// <summary>
    /// When command entry begins for a new turn, reset auto-battle flags.
    /// </summary>
    [HarmonyPatch(typeof(GSD2::BattleManager), "init_player_command")]
    [HarmonyPrefix]
    public static void BattleManager_init_player_command_Prefix()
    {
        _isAutoBattle = false;
        _turnRecorded = false;
    }

    /// <summary>
    /// Flag auto-battle when Omakase is triggered.
    /// </summary>
    [HarmonyPatch(typeof(GSD2::BattleManager), "omakase_window")]
    [HarmonyPrefix]
    public static void BattleManager_omakase_window_Prefix()
    {
        _isAutoBattle = true;
    }

    /// <summary>
    /// When a manual turn begins execution, record all characters' submitted actions.
    /// </summary>
    [HarmonyPatch(typeof(GSD2::BattleManager), "battle_turn")]
    [HarmonyPrefix]
    public static void BattleManager_battle_turn_Prefix(GSD2::BattleManager __instance)
    {
        try
        {
            if (_turnRecorded)
                return;

            _turnRecorded = true;

            if (Plugin.Config == null || !Plugin.Config.EnableMemoryAutoBattle.Value)
                return;

            if (__instance == null)
                return;

            // If auto-battle is active for this turn, do not overwrite manual memory with auto-battle actions.
            // Checking __instance.IsAuto ensures that if the player selected Auto and then pressed Cancel on the
            // confirmation window (which resets IsAuto = false), their subsequent manual commands ARE recorded.
            if (__instance.IsAuto && _isAutoBattle)
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

                int charaId = GetCharacterId(charData);
                if (charaId <= 0)
                    continue;

                // 0 = Attack, 1 = Defend, 2 = Magic/Rune
                if (charData.c_koudou == 0)
                {
                    _rememberedActions[charaId] = new RememberedAction
                    {
                        Koudou = 0,
                        Item = 0,
                        Monsyo = 0
                    };
                }
                else if (charData.c_koudou == 1)
                {
                    _rememberedActions[charaId] = new RememberedAction
                    {
                        Koudou = 1,
                        Item = 0,
                        Monsyo = 0
                    };
                }
                else if (charData.c_koudou == 2)
                {
                    _rememberedActions[charaId] = new RememberedAction
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
            Plugin.Log.LogError($"[MemoryAutoBattle:battle_turn] Error: {ex}");
        }
    }

    /// <summary>
    /// When Auto-Battle (Omakase) is selected, replay remembered actions.
    /// Vanilla omakase_window has already set c_koudou = 0 (or 1 if out of attack range) and selected enemy targets.
    /// </summary>
    [HarmonyPatch(typeof(GSD2::BattleManager), "omakase_window")]
    [HarmonyPostfix]
    public static void BattleManager_omakase_window_Postfix(GSD2::BattleManager __instance)
    {
        try
        {
            if (Plugin.Config == null || !Plugin.Config.EnableMemoryAutoBattle.Value)
                return;

            if (__instance == null)
                return;

            var party = __instance.PlayerParty;
            if (party == null)
                return;

            int count = party.Count;
            for (int i = 0; i < count; i++)
            {
                try
                {
                    var charData = party[i];
                    if (charData == null)
                        continue;

                    int charaId = GetCharacterId(charData);
                    if (charaId <= 0)
                        continue;

                    if (!_rememberedActions.TryGetValue(charaId, out var action))
                        continue;

                    // If remembered action is Rune / Magic
                    if (action.Koudou == 2)
                    {
                        var bpc = charData.TryCast<GSD2::BattlePlayerCharacter>();
                        if (bpc == null)
                            continue;

                        var varia = bpc.c_varia_dat ?? GSD2::G2_SYS.G2_varia_dat(charaId);
                        if (varia == null || varia.mon_eqp == null || action.Monsyo < 0 || action.Monsyo >= varia.mon_eqp.Length)
                            continue;

                        byte runeId = varia.mon_eqp[action.Monsyo];
                        if (runeId == 0)
                        {
                            if (Plugin.Config.DetailedLogs.Value)
                                Plugin.Log.LogInfo($"[MemoryAutoBattle] CharaId {charaId} (slot {charData.chara_no}) has no rune in slot {action.Monsyo}, falling back.");
                            continue;
                        }

                        var ovit = GSD2::G2_SYS.Get_ovit_data();
                        var emblData = (ovit?.embl_data != null && runeId < ovit.embl_data.Length) ? ovit.embl_data[runeId] : null;
                        bool isCommandRune = emblData?.info != null && emblData.info.Length > 1 && (emblData.info[1] & 2) != 0;

                        if (isCommandRune)
                        {
                            if (!charData.SpecialCanCheck() || __instance.GetEmblMagicNum(charData.chara_no, runeId) <= 0)
                            {
                                if (Plugin.Config.DetailedLogs.Value)
                                    Plugin.Log.LogInfo($"[MemoryAutoBattle] CharaId {charaId} (slot {charData.chara_no}) cannot use command rune #{runeId}, falling back.");
                                continue;
                            }
                        }
                        else
                        {
                            // Check if character can cast magic (not dead, sleeping, panic, silenced, etc.)
                            if (!charData.MagicCanCheck())
                            {
                                if (Plugin.Config.DetailedLogs.Value)
                                    Plugin.Log.LogInfo($"[MemoryAutoBattle] CharaId {charaId} (slot {charData.chara_no}) cannot cast magic (status), falling back.");
                                continue;
                            }

                            // In GSD2 C_VARIA_DAT.mp[0..3], upper nibble ((mp >> 4) & 0x0F) is Current MP and lower nibble (mp & 0x0F) is Max MP
                            if (action.Item >= 0 && action.Item < 4 && varia.mp != null && action.Item < varia.mp.Length)
                            {
                                int curMp = (varia.mp[action.Item] >> 4) & 0x0F;
                                if (curMp <= 0)
                                {
                                    if (Plugin.Config.DetailedLogs.Value)
                                        Plugin.Log.LogInfo($"[MemoryAutoBattle] CharaId {charaId} (slot {charData.chara_no}) out of MP for spell level {action.Item + 1}, falling back.");
                                    continue;
                                }
                            }
                        }

                        // Resolve spell target flags so we guarantee a valid c_mokuhyo before calling SetUseMagicIDs
                        byte magicNo = 0;
                        if (action.Item >= 0 && action.Item < 4 && emblData?.magic_no != null && action.Item < emblData.magic_no.Length)
                            magicNo = emblData.magic_no[action.Item];
                        else if (action.Item >= 4)
                            magicNo = (byte)action.Item;

                        var magiData = magicNo > 0 ? GSD2::G2_SYS.G2_magi_data(magicNo) : null;
                        byte targetFlags = (magiData?.status != null && magiData.status.Length > 1) ? magiData.status[1] : (byte)0;
                        bool isAllyTarget = (targetFlags & 0x30) == 0x10;

                        if (isAllyTarget)
                        {
                            bpc.c_mokuhyo = (sbyte)bpc.chara_no;
                        }
                        else if (bpc.c_mokuhyo < count)
                        {
                            // Character had no valid enemy target (e.g. Short-range mage in back row set to Defend by vanilla omakase_window)
                            int enemyTarget = FindLivingEnemyTarget(__instance, party);
                            if (enemyTarget < 0)
                                continue;

                            bpc.c_mokuhyo = (sbyte)enemyTarget;
                        }

                        _isReplayingOmakase = true;
                        try
                        {
                            bpc.SetUseMagicIDs(action.Item, action.Monsyo, true);
                        }
                        finally
                        {
                            _isReplayingOmakase = false;
                        }

                        bpc.c_koudou = 2;
                        if (Plugin.Config.DetailedLogs.Value)
                            Plugin.Log.LogInfo($"[MemoryAutoBattle] Replaying Rune/Magic for charaId {charaId} (slot {charData.chara_no}): emblem={action.Monsyo}, magic={action.Item}, target={bpc.c_mokuhyo}");
                    }
                    else if (action.Koudou == 1)
                    {
                        if (charData.ActionCanCheck())
                        {
                            charData.c_koudou = 1;
                            charData.c_item = 0;
                            charData.c_monsyo = 0;
                            charData.c_mokuhyo = -1;

                            if (Plugin.Config.DetailedLogs.Value)
                                Plugin.Log.LogInfo($"[MemoryAutoBattle] Replaying Defend for charaId {charaId} (slot {charData.chara_no})");
                        }
                    }
                }
                catch (Exception charEx)
                {
                    Plugin.Log.LogError($"[MemoryAutoBattle:omakase_window] Error processing party slot {i}: {charEx}");
                }
            }
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[MemoryAutoBattle:omakase_window] Error: {ex}");
        }
    }
}
