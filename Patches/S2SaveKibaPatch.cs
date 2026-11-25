extern alias GSD2;

using System;
using System.Collections.Generic;
using HarmonyLib;
using UnityEngine;

namespace PKCore.Patches;

/// <summary>
/// Allows saving General Kiba (charaId = 87 / 0x57) in Suikoden II when all 108 Stars of Destiny
/// have been recruited (unlocking Leknaat's Forgiver Sign / Sign of Forgiveness):
/// 1. Prevents Kiba's scripted death in Mercenary Fortress Ruins (vb10, Sub 0, Ev [17]) by NOPing
///    the 3-byte ECCharaStatus kill opcode [0x54, 0x57, 0x21] -> [0x00, 0x00, 0x00] (preserving
///    exact byte length) and guarding G2_SYS.G2_cha_flag(33, 87).
/// 2. Restores Kiba to Dunan Castle HQ (vk07 War Room, vk06, vk13 Bathhouse/Terrace) after vb10
///    by clearing his Matilda departure flag (event_flag[47] &= ~0x10) and NOPing the post-Matilda
///    hide checks in those HQ rooms. Tablet of Stars, Cook-Off, and Richmond stay alive automatically.
/// 3. Overrides Kiba's ending epilogue card (3001000213) and key post-Rockaxe dialogue lines
///    (1009010114, 1011050014) when he survives.
/// 4. Deploys Kiba as a standalone player-controlled general unit in War Battle 16
///    ("The Conquest of L'Renouille", war_no == 16), compatible with WarAbilityPatch.
/// </summary>
public static class S2SaveKibaPatch
{
    private const int KibaCharaId = 87;          // 0x57 (G2_cha_flag / fpno)
    private const int KibaWarNameId = 88;        // Text ID 88 ("Kiba") used in WAR_CHARA_TYPE.name
    private const int ModeCheckRecruited = 2;    // G2_cha_flag mode 2: recruited
    private const int ModeCheckDead = 7;         // G2_cha_flag mode 7: dead
    private const int ModeSetDead = 33;          // 0x21: G2_cha_flag mode 33: mark dead
    private const int WarNoLRenouille = 16;      // The Conquest of L'Renouille

    private const int FlagMatildaStory = 20;     // 0x14: bit 0x01 = Rockaxe liberated
    private const int FlagKibaAway = 47;         // 0x2F: bit 0x10 = Kiba departed for Mercenary Fort
    private const int FlagVb10Scene = 171;       // 0xAB: bit 0x40 = vb10 Kiba scene completed

    // Localized survival overrides keyed by LanguageSelectionPatch.ActiveLanguageCode
    // Supported official Remaster languages: en, ja, fr, de, es, it, ko, zh-TW, zh-CN
    private static readonly Dictionary<string, Dictionary<uint, string>> LocalizedSurvivalTexts = new(StringComparer.OrdinalIgnoreCase)
    {
        ["en"] = new()
        {
            [1002100157u] = "Listen up, men! Stand your ground!∨Every minute we hold out brings Commander ♂㈱ ∠and the ♂② Army closer to victory!∨...Wait—what is this warm light?! The Sign of Forgiveness...∠Heh... It seems fate won't let this old soldier fall yet!",
            [1009010114u] = "...during the battle, General Kiba was wounded...∨...but he held on! Our medics say a strange light shielded him,∠and he's already been brought back to ♂① Castle to recover!",
            [1009010116u] = "Father... Thank goodness you're alive...",
            [1009140012u] = "...during the battle, General Kiba was wounded...∨...but he held on! Our medics say a strange light shielded him,∠and he's already been brought back to ♂① Castle to recover!",
            [1009140014u] = "Father... Thank goodness you're alive...",
            [1011050014u] = "I know that! I know, but still!!! It's just too unfair∠for ♂㈱...∨Damn! Not Nanami too...∨We fought so hard together! Scratched out victory together!∠And now it just ends here like this?!",
            [3001000213u] = "Survived his wounds at the Mercenary Fortress thanks to the power∠of the 108 Stars, and fought beside his son Klaus at L'Renouille."
        },
        ["ja"] = new()
        {
            [1002100157u] = "聞け、野郎ども！　一歩も引くな！∨おれたちがここで持ちこたえるほど、♂㈱隊長と∠♂②軍の勝利が近づくのだ！∨……むっ、この温かい光は！？　許しの紋章か……∠ふっ……運命は、まだこの老兵を死なせてはくれんらしいな！",
            [1009010114u] = "……戦闘中、キバ将軍が傷を負われました……∨……ですが、一命を取り留められました！　不思議な光に守られたとのことで、∠すでに♂①城へ運ばれ療養中です！",
            [1009010116u] = "父上……ご無事で本当によかった……",
            [1009140012u] = "……戦闘中、キバ将軍が傷を負われました……∨……ですが、一命を取り留められました！　不思議な光に守られたとのことで、∠すでに♂①城へ運ばれ療養中です！",
            [1009140014u] = "父上……ご無事で本当によかった……",
            [1011050014u] = "わかってるよ！　わかってるけどさ！！！　♂㈱があまりにも∠かわいそうじゃないか……∨くそっ！　ナナミまで……∨せっかくみんなで力を合わせてここまで戦ってきたのに！∠こんな結末ってあるかよ？！",
            [3001000213u] = "１０８星の力により傭兵隊の砦での傷から生還し、∠息子クラウスと共にルルノイエの決戦を戦い抜いた。"
        },
        ["fr"] = new()
        {
            [1002100157u] = "Écoutez-moi, soldats ! Tenez bon !∨Chaque minute gagnée rapproche le commandant ♂㈱ ∠et l'armée ♂② de la victoire !∨...Attendez — quelle est cette douce lumière ?! Le Signe du Pardon...∠Heh... Il semble que le destin ne veuille pas encore laisser tomber ce vieux soldat !",
            [1009010114u] = "...pendant la bataille, le général Kiba a été blessé...∨...mais il a survécu ! Nos médecins disent qu'une étrange lumière l'a protégé,∠et il a déjà été ramené au château de ♂① pour se rétablir !",
            [1009010116u] = "Père... Dieu merci, vous êtes en vie...",
            [1009140012u] = "...pendant la bataille, le général Kiba a été blessé...∨...mais il a survécu ! Nos médecins disent qu'une étrange lumière l'a protégé,∠et il a déjà été ramené au château de ♂① pour se rétablir !",
            [1009140014u] = "Père... Dieu merci, vous êtes en vie...",
            [1011050014u] = "Je le sais ! Je le sais, mais quand même !!! C'est tellement injuste∠pour ♂㈱...∨Bon sang ! Pas Nanami...∨Nous nous sommes battus si dur ensemble ! Nous avons arraché la victoire !∠Et tout se termine comme ça ?!",
            [3001000213u] = "Survécut à ses blessures à la Forteresse des Mercenaires grâce au∠pouvoir des 108 Étoiles et combattit aux côtés de Klaus à L'Renouille."
        },
        ["de"] = new()
        {
            [1002100157u] = "Hört zu, Männer! Haltet die Stellung!∨Jede Minute, die wir durchhalten, bringt Kommandant ♂㈱ ∠und die ♂②-Armee dem Sieg näher!∨...Moment — was ist dieses warme Licht?! Das Zeichen der Vergebung...∠Heh... Das Schicksal lässt diesen alten Soldaten wohl noch nicht fallen!",
            [1009010114u] = "...während der Schlacht wurde General Kiba verwundet...∨...aber er hat durchgehalten! Unsere Heiler sagen, ein seltsames Licht habe ihn beschützt,∠und er wurde bereits zur Genesung nach Schloss ♂① gebracht!",
            [1009010116u] = "Vater... Gott sei Dank lebst du...",
            [1009140012u] = "...während der Schlacht wurde General Kiba verwundet...∨...aber er hat durchgehalten! Unsere Heiler sagen, ein seltsames Licht habe ihn beschützt,∠und er wurde bereits zur Genesung nach Schloss ♂① gebracht!",
            [1009140014u] = "Vater... Gott sei Dank lebst du...",
            [1011050014u] = "Ich weiß das! Ich weiß, aber trotzdem!!! Es ist einfach zu unfair∠für ♂㈱...∨Verdammt! Nicht auch noch Nanami...∨Wir haben so hart zusammen gekämpft und uns den Sieg erkämpft!∠Und jetzt endet es einfach so?!",
            [3001000213u] = "Überlebte dank der Macht der 108 Sterne seine Verletzungen in der∠Söldnerfestung und kämpfte mit seinem Sohn Klaus bei L'Renouille."
        },
        ["es"] = new()
        {
            [1002100157u] = "¡Escuchen, hombres! ¡Mantengan sus posiciones!∨¡Cada minuto que resistamos acerca al comandante ♂㈱ ∠y al Ejército ♂② a la victoria!∨...Espera, ¿qué es esta cálida luz?! La Señal del Perdón...∠Je... ¡Parece que el destino aún no dejará caer a este viejo soldado!",
            [1009010114u] = "...durante la batalla, el general Kiba resultó herido...∨...¡pero resistió! Nuestros médicos dicen que una extraña luz lo protegió,∠¡y ya ha sido llevado al Castillo ♂① para recuperarse!",
            [1009010116u] = "Padre... Gracias al cielo que sigues con vida...",
            [1009140012u] = "...durante la batalla, el general Kiba resultó herido...∨...¡pero resistió! Nuestros médicos dicen que una extraña luz lo protegió,∠¡y ya ha sido llevado al Castillo ♂① para recuperarse!",
            [1009140014u] = "Padre... Gracias al cielo que sigues con vida...",
            [1011050014u] = "¡Lo sé! ¡Lo sé, pero aun así!!! Es demasiado injusto∠para ♂㈱...∨¡Maldición! Nanami no...∨¡Luchamos tan duro juntos! ¡Conseguimos la victoria juntos!∠¡¿Y ahora todo termina así?!",
            [3001000213u] = "Sobrevivió a sus heridas en la Fortaleza Mercenaria gracias al poder∠de las 108 Estrellas y luchó junto a su hijo Klaus en L'Renouille."
        },
        ["it"] = new()
        {
            [1002100157u] = "Ascoltate, uomini! Tenete la posizione!∨Ogni minuto di resistenza avvicina il comandante ♂㈱ ∠e l'Esercito ♂② alla vittoria!∨...Aspetta, cos'è questa luce calda?! Il Segno del Perdono...∠Eheh... Sembra che il destino non lascerà ancora cadere questo vecchio soldato!",
            [1009010114u] = "...durante la battaglia, il generale Kiba è rimasto ferito...∨...ma ha resistito! I nostri medici dicono che una strana luce lo ha protetto,∠ed è già stato riportato al Castello ♂① per riprendersi!",
            [1009010116u] = "Padre... Grazie al cielo sei vivo...",
            [1009140012u] = "...durante la battaglia, il generale Kiba è rimasto ferito...∨...ma ha resistito! I nostri medici dicono che una strana luce lo ha protetto,∠ed è già stato riportato al Castello ♂① per riprendersi!",
            [1009140014u] = "Padre... Grazie al cielo sei vivo...",
            [1011050014u] = "Lo so! Lo so, ma comunque!!! È davvero troppo ingiusto∠per ♂㈱...∨Maledizione! Non anche Nanami...∨Abbiamo lottato così duramente insieme! Abbiamo conquistato la vittoria!∠E ora finisce tutto così?!",
            [3001000213u] = "Sopravvisse alle ferite alla Fortezza dei Mercenari grazie al potere∠delle 108 Stelle e combatté al fianco del figlio Klaus a L'Renouille."
        },
        ["ko"] = new()
        {
            [1002100157u] = "들어라, 제군! 한 발짝도 물러서지 마라!∨우리가 버티는 매 순간이 ♂㈱ 대장과∠♂②군의 승리를 앞당긴다!∨...잠깐, 이 따뜻한 빛은?! 용서의 문장인가...∠허허... 운명이 아직 이 노병을 쓰러지게 두지 않으려는 모양이군!",
            [1009010114u] = "...전투 중에 키바 장군께서 부상을 입으셨습니다...∨...하지만 목숨은 건지셨습니다! 신비한 빛이 장군님을 감쌌다고 하며,∠이미 ♂①성으로 옮겨져 회복 중이십니다!",
            [1009010116u] = "아버지... 무사하셔서 정말 다행입니다...",
            [1009140012u] = "...전투 중에 키바 장군께서 부상을 입으셨습니다...∨...하지만 목숨은 건지셨습니다! 신비한 빛이 장군님을 감쌌다고 하며,∠이미 ♂①성으로 옮겨져 회복 중이십니다!",
            [1009140014u] = "아버지... 무사하셔서 정말 다행입니다...",
            [1011050014u] = "알고 있어! 알지만 그래도!!! ♂㈱에게 너무 가혹하잖아...∨젠장! 나나미까지...∨모두 함께 힘을 합쳐 여기까지 싸워 왔는데!∠이런 결말이 어디 있어?!",
            [3001000213u] = "108성의 힘으로 용병대 요새의 부상에서 살아남아∠아들 클라우스와 함께 루르노이에 결전을 싸워냈다."
        },
        ["zh-TW"] = new()
        {
            [1002100157u] = "聽好了，弟兄們！守住陣地！∨我們多撐一分鐘，♂㈱隊長與∠♂②軍就離勝利更近一步！∨……等等，這道溫暖的光芒是？！寬恕之印嗎……∠哼……看來命運還不打算讓這名老兵倒下啊！",
            [1009010114u] = "……戰鬥中，基巴將軍負傷了……∨……但他撐過來了！軍醫說有一道不可思議的光芒守護著他，∠現在已經送回♂①城休養了！",
            [1009010116u] = "父親……您還活著真是太好了……",
            [1009140012u] = "……戰鬥中，基巴將軍負傷了……∨……但他撐過來了！軍醫說有一道不可思議的光芒守護著他，∠現在已經送回♂①城休養了！",
            [1009140014u] = "父親……您還活著真是太好了……",
            [1011050014u] = "我知道！我知道，但是！！！這對♂㈱來說∠也太不公平了……∨可惡！連奈奈美也……∨我們好不容易一起拚死戰鬥到現在！∠怎麼會變成這樣？！",
            [3001000213u] = "憑藉108星之力在傭兵隊要塞的傷勢中倖存下來，∠並與兒子克勞斯並肩參加了魯魯諾伊艾決戰。"
        },
        ["zh-CN"] = new()
        {
            [1002100157u] = "听好了，弟兄们！守住阵地！∨我们多撑一分钟，♂㈱队长与∠♂②军就离胜利更近一步！∨……等等，这道温暖的光芒是？！宽恕之印吗……∠哼……看来命运还不打算让这名老兵倒下啊！",
            [1009010114u] = "……战斗中，基巴将军负伤了……∨……但他撑过来了！军医说有一道不可思议的光芒守护着他，∠现在已经送回♂①城休养了！",
            [1009010116u] = "父亲……您还活着真是太好了……",
            [1009140012u] = "……战斗中，基巴将军负伤了……∨……但他撑过来了！军医说有一道不可思议的光芒守护着他，∠现在已经送回♂①城休养了！",
            [1009140014u] = "父亲……您还活着真是太好了……",
            [1011050014u] = "我知道！我知道，但是！！！这对♂㈱来说∠也太不公平了……∨可恶！连奈奈美也……∨我们好不容易一起拼死战斗到现在！∠怎么会变成这样？！",
            [3001000213u] = "凭借108星之力在佣兵队要塞的伤势中幸存下来，∠并与儿子克劳斯并肩参加了鲁鲁诺伊艾决战。"
        }
    };

    public static bool IsEnabled => Plugin.Config?.EnableSaveKiba?.Value == true;

    public static void Initialize(Harmony harmony)
    {
        harmony.PatchAll(typeof(EventInitPatch));
        harmony.PatchAll(typeof(OnMapInitPatch));
        harmony.PatchAll(typeof(EventMainGlowPatch));
        harmony.PatchAll(typeof(ChaFlagGuardPatch));
        harmony.PatchAll(typeof(GetSystemTextPatch));
        harmony.PatchAll(typeof(GetSystemTextExPatch));
        harmony.PatchAll(typeof(WarCharaInitPatch));
        harmony.PatchAll(typeof(WarInitUnitPatch));
    }

    private static bool HasAll108Stars()
    {
        try
        {
            return GSD2::G2_SYS.Mem108Chk(1) >= 108;
        }
        catch
        {
            return false;
        }
    }

    private static bool IsKibaRecruited()
    {
        try
        {
            return GSD2::G2_SYS.G2_cha_flag(ModeCheckRecruited, KibaCharaId) == 1;
        }
        catch
        {
            return false;
        }
    }

    private static bool IsKibaAlive()
    {
        try
        {
            return GSD2::G2_SYS.G2_cha_flag(ModeCheckRecruited, KibaCharaId) == 1
                && GSD2::G2_SYS.G2_cha_flag(ModeCheckDead, KibaCharaId) == 0;
        }
        catch
        {
            return false;
        }
    }

    private static bool ShouldSaveKiba()
    {
        return IsEnabled && GameDetection.IsGSD2() && IsKibaRecruited() && HasAll108Stars();
    }

    private static bool IsKibaSavedAndAlive()
    {
        return IsEnabled && GameDetection.IsGSD2() && IsKibaAlive() && HasAll108Stars();
    }

    private static bool IsPostMatilda(GSD2::GAME_WORK gw)
    {
        return gw?.event_flag != null
            && gw.event_flag.Length > FlagVb10Scene
            && (gw.event_flag[FlagMatildaStory] & 0x01) != 0;
    }

    private static bool ReplaceSequenceInPlace(
        Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppStructArray<byte> buf,
        byte b0, byte b1, byte b2,
        byte r0, byte r1, byte r2)
    {
        if (buf == null || buf.Length < 3) return false;
        bool replaced = false;
        for (int i = 0; i <= buf.Length - 3; i++)
        {
            if (buf[i] == b0 && buf[i + 1] == b1 && buf[i + 2] == b2)
            {
                buf[i] = r0;
                buf[i + 1] = r1;
                buf[i + 2] = r2;
                replaced = true;
            }
        }
        return replaced;
    }

    private static int FindKibaWarCharaIndex()
    {
        var table = GSD2::w_unit.war_to_main_table;
        if (table != null)
        {
            for (int i = 0; i < table.Length; i++)
            {
                if (table[i] == KibaCharaId)
                    return i;
            }
        }

        // Fallback: scan w_chara for Kiba's text name ID (88)
        for (int i = 0; i < 108; i++)
        {
            try
            {
                var c = GSD2::w_chara.chara(i);
                if (c != null && c.name == KibaWarNameId)
                    return i;
            }
            catch
            {
                break;
            }
        }
        return -1;
    }

    // =========================================================================
    // 1. Guard G2_SYS.G2_cha_flag(33, 87) so Kiba is never marked dead with 108 Stars
    // =========================================================================
    [HarmonyPatch(typeof(GSD2::G2_SYS), nameof(GSD2::G2_SYS.G2_cha_flag))]
    private static class ChaFlagGuardPatch
    {
        [HarmonyPrefix]
        public static bool Prefix(int mode, int chano, ref int __result)
        {
            if (mode == ModeSetDead && chano == KibaCharaId && ShouldSaveKiba())
            {
                Plugin.Log.LogInfo("[S2SaveKiba] Blocked G2_cha_flag(33, 87) — 108 Stars (Forgiver Sign) saved General Kiba!");
                __result = 0;
                return false;
            }
            return true;
        }
    }

    // =========================================================================
    // 2. Restore Kiba's HQ visibility flag on Castle HQ entry after vb10
    // =========================================================================
    [HarmonyPatch(typeof(GSD2::MACHICON), nameof(GSD2::MACHICON.OnMapInit))]
    private static class OnMapInitPatch
    {
        [HarmonyPrefix]
        public static void Prefix(GSD2::MACHICON __instance)
        {
            if (__instance == null || !IsKibaSavedAndAlive()) return;
            try
            {
                string raw = __instance.GetMapName() ?? string.Empty;
                string mapId = MACHICON_OnMapInitPatch.ParseMapIdFromMachiName(raw) ?? raw;
                _isInVb10 = mapId.StartsWith("vb10", StringComparison.OrdinalIgnoreCase);
                CleanupVb10Glow();

                // Write localized survival dialogue directly into TextMasterData ("message" & stayTextSet)
                // as soon as 108 Stars + Kiba alive are active (before event_flag[20] bit 0x01 is set in vi14_00).
                ApplySurvivalTextTableOverrides();

                if (!mapId.StartsWith("vk", StringComparison.OrdinalIgnoreCase)) return;

                var gw = GSD2::OldSrcBase.game_work;
                if (!IsPostMatilda(gw)) return;

                // After the vb10 Mercenary Fortress scene has completed, clear the Matilda departure flag
                if ((gw.event_flag[FlagVb10Scene] & 0x40) != 0 && (gw.event_flag[FlagKibaAway] & 0x10) != 0)
                {
                    gw.event_flag[FlagKibaAway] = (byte)(gw.event_flag[FlagKibaAway] & ~0x10);
                    Plugin.Log.LogInfo($"[S2SaveKiba] Cleared event_flag[47] bit 0x10 on {mapId} so Kiba returns to Dunan Castle HQ.");
                }
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"[S2SaveKiba] Error in OnMapInit Prefix: {ex}");
            }
        }
    }

    // =========================================================================
    // 3. Patch vb10 Ev[17] death opcode & HQ post-Matilda Kiba spawn conditions
    // =========================================================================
    [HarmonyPatch(typeof(GSD2::MACHICON), nameof(GSD2::MACHICON.EventInit))]
    private static class EventInitPatch
    {
        [HarmonyPostfix]
        public static void Postfix(GSD2::MACHICON __instance, GSD2::EVENTCON __result)
        {
            if (__result?.mdat?.eventdata?.mapeventdat == null) return;
            if (!IsEnabled || !GameDetection.IsGSD2()) return;

            try
            {
                string raw = __instance?.GetMapName() ?? string.Empty;
                string mapId = MACHICON_OnMapInitPatch.ParseMapIdFromMachiName(raw) ?? raw;
                var submaps = __result.mdat.eventdata.mapeventdat;

                // Restore Kiba to his vanilla Dunan Castle HQ locations after vb10 by NOPing the
                // post-Matilda hide check [23 14 20] -> [00 00 00] in vk07 Submap 3 Ev[5] (4F War Room)
                // and vk06 Submap 1 Ev[27] (3F HQ). event_flag[47] bit 0x10 is cleared in OnMapInitPatch.
                var gw = GSD2::OldSrcBase.game_work;
                if (!IsKibaSavedAndAlive() || !IsPostMatilda(gw) || (gw.event_flag[FlagVb10Scene] & 0x40) == 0)
                    return;

                if (mapId.StartsWith("vk07", StringComparison.OrdinalIgnoreCase) && submaps.Count > 3 && submaps[3]?.eventdat != null)
                {
                    var sub3 = submaps[3];
                    if (sub3.eventdat.Count > 5 && sub3.eventdat[5]?.eventForm != null)
                    {
                        if (ReplaceSequenceInPlace(sub3.eventdat[5].eventForm, 0x23, 0x14, 0x20, 0x00, 0x00, 0x00))
                            Plugin.Log.LogInfo("[S2SaveKiba] Reactivated vanilla Kiba in vk07 Submap 3 (4F War Room).");
                    }
                }
                else if (mapId.StartsWith("vk06", StringComparison.OrdinalIgnoreCase) && submaps.Count > 1 && submaps[1]?.eventdat != null)
                {
                    var sub1 = submaps[1];
                    if (sub1.eventdat.Count > 27 && sub1.eventdat[27]?.eventForm != null)
                    {
                        if (ReplaceSequenceInPlace(sub1.eventdat[27].eventForm, 0x23, 0x14, 0x20, 0x00, 0x00, 0x00))
                            Plugin.Log.LogInfo("[S2SaveKiba] Reactivated vanilla Kiba in vk06 Submap 1 (3F HQ).");
                    }
                }
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"[S2SaveKiba] Error in EventInit Postfix: {ex}");
            }
        }
    }

    // =========================================================================
    // 4. Dialogue & Ending Epilogue Text Overrides when Kiba survives
    // =========================================================================
    private static string ResolveActiveLanguageCode()
    {
        try
        {
            return TextMasterData.CurrentLanguage switch
            {
                TextMasterData.Lang.Japanese => "ja",
                TextMasterData.Lang.French => "fr",
                TextMasterData.Lang.German => "de",
                TextMasterData.Lang.Spanish => "es",
                TextMasterData.Lang.Italian => "it",
                TextMasterData.Lang.ChineseZhHant => "zh-TW",
                TextMasterData.Lang.ChineseZhHans => "zh-CN",
                TextMasterData.Lang.English => "en",
                _ => LanguageSelectionPatch.ActiveLanguageCode
            };
        }
        catch
        {
            LanguageSelectionPatch.EnsureLanguageDetected();
            return LanguageSelectionPatch.ActiveLanguageCode;
        }
    }

    private static Dictionary<uint, string> GetActiveLanguageTable(out string langCode)
    {
        langCode = ResolveActiveLanguageCode();
        if (string.IsNullOrEmpty(langCode) || !LocalizedSurvivalTexts.TryGetValue(langCode, out var table))
        {
            langCode = "en";
            table = LocalizedSurvivalTexts["en"];
        }
        return table;
    }

    private static string _lastAppliedTextLang;

    private static void ApplySurvivalTextTableOverrides()
    {
        var table = GetActiveLanguageTable(out string langCode);
        if (string.Equals(_lastAppliedTextLang, langCode, StringComparison.OrdinalIgnoreCase))
            return;

        int updated = 0;
        foreach (var entry in table)
        {
            uint textId = entry.Key;
            string text = entry.Value;

            try
            {
                TextMasterData.WriteSystemText("message", unchecked((int)textId), text);
                updated++;
            }
            catch { }

            try
            {
                var stay = TextMasterData.stayTextSet;
                if (stay != null)
                {
                    foreach (var kvp in stay)
                    {
                        var nodes = kvp.Value?.fileNodes;
                        if (nodes != null && nodes.ContainsKey(textId))
                        {
                            nodes[textId] = text;
                        }
                    }
                }
            }
            catch { }
        }

        _lastAppliedTextLang = langCode;
        Plugin.Log.LogInfo($"[S2SaveKiba] Registered {updated} localized survival text overrides in TextMasterData (lang={langCode}).");
    }

    private static void TryOverrideText(int index, ref string result)
    {
        uint key = unchecked((uint)index);
        if (!LocalizedSurvivalTexts["en"].ContainsKey(key))
            return;

        if (!IsKibaSavedAndAlive())
            return;

        var langTable = GetActiveLanguageTable(out string lang);
        if (langTable.TryGetValue(key, out string replacement))
        {
            result = replacement;
            if (Plugin.Config?.DetailedLogs?.Value == true)
                Plugin.Log.LogInfo($"[S2SaveKiba] Applied survival text override [{key}] (lang={lang}).");
        }
    }

    // Priority.Low (200) runs AFTER SuikodenFix's text Postfix (Normal = 400) so our survival text
    // is not overwritten, while still running BEFORE TextDatabasePatch's speaker injection (Last = 0).
    [HarmonyPatch(typeof(TextMasterData), nameof(TextMasterData.GetSystemText))]
    private static class GetSystemTextPatch
    {
        [HarmonyPriority(Priority.Low)]
        [HarmonyPostfix]
        public static void Postfix(string id, int index, ref string __result)
        {
            TryOverrideText(index, ref __result);
        }
    }

    [HarmonyPatch(typeof(TextMasterData), nameof(TextMasterData.GetSystemTextEx))]
    private static class GetSystemTextExPatch
    {
        [HarmonyPriority(Priority.Low)]
        [HarmonyPostfix]
        public static void Postfix(string id, int index, int gsd, ref string __result)
        {
            TryOverrideText(index, ref __result);
        }
    }

    // =========================================================================
    // 5. L'Renouille War Battle (war_no == 16): Standalone General Kiba Unit
    // =========================================================================
    [HarmonyPatch(typeof(GSD2::w_chara), nameof(GSD2::w_chara.charaInit))]
    private static class WarCharaInitPatch
    {
        [HarmonyPostfix]
        public static void Postfix()
        {
            try
            {
                if (!IsKibaSavedAndAlive()) return;
                var sys = GSD2::OldSrcBase.sys_work;
                if (sys == null || sys.war_no != WarNoLRenouille) return;

                int kibaWarIdx = FindKibaWarCharaIndex();
                if (kibaWarIdx < 0) return;

                var kibaChara = GSD2::w_chara.chara(kibaWarIdx);
                if (kibaChara == null) return;

                // If w_dat_16 left Kiba's stats blank, hydrate them from w_dat_butai.chara_butai
                if (kibaChara.attack == 0 && kibaChara.defense == 0)
                {
                    var butai = GSD2::w_dat_butai.chara_butai;
                    if (butai != null)
                    {
                        for (int i = 0; i < butai.Length; i++)
                        {
                            var src = butai[i];
                            if (src != null && src.name == KibaWarNameId)
                            {
                                kibaChara.force_type = src.force_type;
                                kibaChara.nouryoku = src.nouryoku;
                                kibaChara.kaisu = src.kaisu;
                                kibaChara.kaisu_max = src.kaisu_max;
                                kibaChara.face_no = src.face_no;
                                kibaChara.name = src.name;
                                kibaChara.big_name = src.big_name;
                                kibaChara.attack = src.attack;
                                kibaChara.assist_attack = src.assist_attack;
                                kibaChara.defense = src.defense;
                                kibaChara.assist_defense = src.assist_defense;
                                kibaChara.magic_no = src.magic_no;
                                kibaChara.yarare_serifu = src.yarare_serifu;
                                kibaChara.sibou_serifu = src.sibou_serifu;
                                kibaChara.tokusyu_serifu1 = src.tokusyu_serifu1;
                                kibaChara.tokusyu_serifu2 = src.tokusyu_serifu2;
                                Plugin.Log.LogInfo($"[S2SaveKiba] Hydrated Kiba war stats in War 16 from chara_butai[{i}] (ATK={src.attack}, DEF={src.defense}).");
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"[S2SaveKiba] Error in WarCharaInitPatch: {ex}");
            }
        }
    }

    [HarmonyPatch(typeof(GSD2::w_unit), nameof(GSD2::w_unit.InitUnit))]
    private static class WarInitUnitPatch
    {
        [HarmonyPostfix]
        public static void Postfix()
        {
            try
            {
                if (!IsKibaSavedAndAlive()) return;
                var sys = GSD2::OldSrcBase.sys_work;
                if (sys == null || sys.war_no != WarNoLRenouille) return;

                var allUnits = GSD2::w_unit.unit;
                if (allUnits == null || allUnits.Length == 0 || allUnits[0] == null) return;
                var allies = allUnits[0];

                int kibaWarIdx = FindKibaWarCharaIndex();
                if (kibaWarIdx < 0)
                {
                    Plugin.Log.LogWarning("[S2SaveKiba] Could not resolve Kiba's war character index for L'Renouille.");
                    return;
                }

                // Avoid duplicate deployment if Kiba is already assigned to an allied unit
                if (GSD2::w_unit.SearchUnitForceByChara(kibaWarIdx) == 0)
                    return;

                // Locate reference active allied unit (Riou / slot 0) and first empty allied slot
                GSD2::UNIT_TYPE refUnit = null;
                int emptySlot = -1;
                int kibaForceType = GSD2::w_chara.GetCharaForceType(kibaWarIdx);
                byte matchedAnimeNo = 0;
                bool hasMatchedAnime = false;

                for (int i = 0; i < allies.Length; i++)
                {
                    var u = allies[i];
                    if (u == null || u.chara == null || u.chara.Length == 0) continue;

                    bool active = u.flag != 0 && u.chara[0] >= 0;
                    if (active)
                    {
                        if (refUnit == null)
                            refUnit = u;

                        if (!hasMatchedAnime && GSD2::w_chara.GetCharaForceType(u.chara[0]) == kibaForceType)
                        {
                            matchedAnimeNo = u.anime_no;
                            hasMatchedAnime = true;
                        }
                    }
                    else if (emptySlot < 0)
                    {
                        emptySlot = i;
                    }
                }

                if (refUnit == null || emptySlot < 0)
                {
                    Plugin.Log.LogWarning($"[S2SaveKiba] Unable to deploy Kiba in L'Renouille (refUnit={refUnit != null}, emptySlot={emptySlot}).");
                    return;
                }

                var targetUnit = allies[emptySlot];
                byte chosenAnimeNo = hasMatchedAnime ? matchedAnimeNo : refUnit.anime_no;

                // Find a passable, unoccupied tile near the allied deployment line
                int spawnX = refUnit.x;
                int spawnY = refUnit.y;
                if (!TryFindOpenSpawnTile(refUnit.x, refUnit.y, emptySlot, out spawnX, out spawnY))
                {
                    Plugin.Log.LogWarning("[S2SaveKiba] Could not find an open spawn tile for Kiba in L'Renouille.");
                    return;
                }

                targetUnit.chara[0] = (sbyte)kibaWarIdx;
                if (targetUnit.chara.Length > 1) targetUnit.chara[1] = -1;
                if (targetUnit.chara.Length > 2) targetUnit.chara[2] = -1;
                targetUnit.x = (sbyte)spawnX;
                targetUnit.y = (sbyte)spawnY;
                targetUnit.damage = 0;
                targetUnit.yoyaku_damage = 0;
                targetUnit.manuved_flag = 0;
                targetUnit.control = refUnit.control;
                targetUnit.flag = refUnit.flag;
                targetUnit.rgb = refUnit.rgb;
                targetUnit.anime_no = chosenAnimeNo;
                targetUnit.tactics = refUnit.tactics;
                targetUnit.tactics_no = 0;

                Plugin.Log.LogInfo($"[S2SaveKiba] Deployed standalone General Kiba unit in L'Renouille (slot={emptySlot}, warIdx={kibaWarIdx}, pos=({spawnX},{spawnY}), anime={chosenAnimeNo}).");
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"[S2SaveKiba] Error in WarInitUnitPatch: {ex}");
            }
        }

        private static bool TryFindOpenSpawnTile(int originX, int originY, int unitSlot, out int outX, out int outY)
        {
            byte refTerrain = GSD2::w_data.GetFieldData(originX, originY);

            // Pass 1: prefer identical terrain type (plains/road) near Riou's unit
            for (int radius = 1; radius <= 6; radius++)
            {
                for (int dy = -radius; dy <= radius; dy++)
                {
                    for (int dx = -radius; dx <= radius; dx++)
                    {
                        if (Math.Abs(dx) != radius && Math.Abs(dy) != radius) continue;
                        int tx = originX + dx;
                        int ty = originY + dy;
                        if (GSD2::w_data.CheckFieldOnStage(tx, ty) == 0) continue;
                        if (GSD2::w_unit.GetUnitForce(tx, ty) >= 0) continue;
                        if (GSD2::w_data.GetFieldData(tx, ty) != refTerrain) continue;

                        outX = tx;
                        outY = ty;
                        return true;
                    }
                }
            }

            // Pass 2: any passable unoccupied on-stage tile
            for (int radius = 1; radius <= 8; radius++)
            {
                for (int dy = -radius; dy <= radius; dy++)
                {
                    for (int dx = -radius; dx <= radius; dx++)
                    {
                        if (Math.Abs(dx) != radius && Math.Abs(dy) != radius) continue;
                        int tx = originX + dx;
                        int ty = originY + dy;
                        if (GSD2::w_data.CheckFieldOnStage(tx, ty) == 0) continue;
                        if (GSD2::w_unit.GetUnitForce(tx, ty) >= 0) continue;
                        if (GSD2::w_data.GetMoveCost(originX, originY, tx, ty, 0, unitSlot) >= 99) continue;

                        outX = tx;
                        outY = ty;
                        return true;
                    }
                }
            }

            outX = originX;
            outY = originY;
            return false;
        }
    }

    // =========================================================================
    // 6. Warm Golden Forgiver Sign Glow on Kiba during vb10_00
    //    Uses a Quad MeshRenderer + the game's OPDSprite.MaterialType.Add shader
    //    matching Kiba's GRSpriteRenderer layer, sortingLayer, sortingOrder, and world bounds.
    // =========================================================================
    private static bool _isInVb10;
    private static float _vb10GlowStartTime = -1f;
    private static Texture2D _radialGlowTex;
    private static Mesh _quadMesh;
    private static GameObject _kibaGlowGo;
    private static Material _kibaGlowMat;
    private static GRSpriteRenderer _kibaBaseGr;

    private static void CleanupVb10Glow()
    {
        if (_kibaGlowGo != null)
        {
            UnityEngine.Object.Destroy(_kibaGlowGo);
            _kibaGlowGo = null;
        }
        if (_kibaGlowMat != null)
        {
            UnityEngine.Object.Destroy(_kibaGlowMat);
            _kibaGlowMat = null;
        }
        _kibaBaseGr = null;
        _vb10GlowStartTime = -1f;
    }

    private static Texture2D GetOrCreateRadialGlowTexture()
    {
        if (_radialGlowTex != null) return _radialGlowTex;

        const int size = 128;
        var tex = new Texture2D(size, size, TextureFormat.RGBA32, false);
        tex.wrapMode = TextureWrapMode.Clamp;
        tex.filterMode = FilterMode.Bilinear;

        var pixels = new Color[size * size];
        float half = (size - 1) * 0.5f;
        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                float dx = (x - half) / half;
                float dy = (y - half) / half;
                float dist = Mathf.Sqrt(dx * dx + dy * dy);
                float falloff = Mathf.Clamp01(1f - dist);
                // Smooth radiant core + wide soft golden halo
                float intensity = falloff * falloff * (0.45f + 0.55f * falloff);
                float r = 1.0f * intensity;
                float g = Mathf.Lerp(0.75f, 0.96f, falloff) * intensity;
                float b = Mathf.Lerp(0.20f, 0.72f, falloff * falloff) * intensity;
                pixels[y * size + x] = new Color(r, g, b, intensity);
            }
        }

        tex.SetPixels(pixels);
        tex.Apply();
        tex.hideFlags = HideFlags.HideAndDontSave;
        _radialGlowTex = tex;
        return _radialGlowTex;
    }

    private static Mesh GetOrCreateUnitQuadMesh()
    {
        if (_quadMesh != null) return _quadMesh;

        var mesh = new Mesh();
        mesh.name = "S2SaveKibaGlowQuad";
        mesh.vertices = new[]
        {
            new Vector3(-0.5f, -0.5f, 0f),
            new Vector3( 0.5f, -0.5f, 0f),
            new Vector3(-0.5f,  0.5f, 0f),
            new Vector3( 0.5f,  0.5f, 0f)
        };
        mesh.uv = new[]
        {
            new Vector2(0f, 0f),
            new Vector2(1f, 0f),
            new Vector2(0f, 1f),
            new Vector2(1f, 1f)
        };
        mesh.colors = new[]
        {
            Color.white,
            Color.white,
            Color.white,
            Color.white
        };
        mesh.triangles = new[] { 0, 2, 1, 2, 3, 1 };
        mesh.RecalculateBounds();
        mesh.hideFlags = HideFlags.HideAndDontSave;
        _quadMesh = mesh;
        return _quadMesh;
    }

    private static Material CreateGlowMaterial(MeshRenderer fallbackMr)
    {
        Material template = null;
        try
        {
            if (OPDSprite.materialList != null)
            {
                if (OPDSprite.materialList.ContainsKey(OPDSprite.MaterialType.Add))
                    template = OPDSprite.materialList[OPDSprite.MaterialType.Add];
                else if (OPDSprite.materialList.ContainsKey(OPDSprite.MaterialType.HalfAdd))
                    template = OPDSprite.materialList[OPDSprite.MaterialType.HalfAdd];
            }
        }
        catch { }

        if (template == null && fallbackMr != null)
            template = fallbackMr.sharedMaterial;

        if (template == null)
        {
            var sh = Shader.Find("Universal Render Pipeline/Unlit") ?? Shader.Find("Sprites/Default");
            if (sh == null) return null;
            template = new Material(sh);
        }

        var mat = new Material(template);
        var tex = GetOrCreateRadialGlowTexture();
        if (mat.HasProperty("_MainTex")) mat.SetTexture("_MainTex", tex);
        if (mat.HasProperty("_BaseMap")) mat.SetTexture("_BaseMap", tex);
        mat.mainTexture = tex;
        return mat;
    }

    [HarmonyPatch(typeof(GSD2::EVENTCON), nameof(GSD2::EVENTCON.EventMain))]
    private static class EventMainGlowPatch
    {
        [HarmonyPostfix]
        public static void Postfix(GSD2::EVENTCON __instance)
        {
            if (!_isInVb10 || __instance == null || !IsKibaSavedAndAlive()) return;

            try
            {
                if (_kibaGlowGo == null || _kibaBaseGr == null)
                {
                    var humans = __instance.ehuman;
                    if (humans == null) return;

                    GSD2::EVENT_HUMAN kiba = null;
                    for (int i = 0; i < humans.Count; i++)
                    {
                        var h = humans[i];
                        if (h != null && h.fpno == KibaCharaId && h.disp != 0)
                        {
                            kiba = h;
                            break;
                        }
                    }

                    var opd = kiba?.anime?.opdSprite;
                    if (opd == null || !opd.gameObject.activeInHierarchy) return;

                    GRSpriteRenderer baseGr = null;
                    if (opd.renderers != null && opd.renderers.Count > 0)
                    {
                        for (int i = 0; i < opd.renderers.Count; i++)
                        {
                            var gr = opd.renderers[i];
                            if (gr != null && gr._meshRenderer != null && gr.gameObject.activeInHierarchy)
                            {
                                baseGr = gr;
                                break;
                            }
                        }
                    }
                    if (baseGr == null)
                        baseGr = opd.GetComponentInChildren<GRSpriteRenderer>();
                    if (baseGr == null || baseGr._meshRenderer == null) return;

                    var baseMr = baseGr._meshRenderer;
                    if (baseMr.bounds.size.sqrMagnitude < 0.0001f) return;

                    _kibaGlowMat = CreateGlowMaterial(baseMr);
                    if (_kibaGlowMat == null) return;

                    var go = new GameObject("S2SaveKibaGlow");
                    go.layer = baseGr.gameObject.layer;

                    var mf = go.AddComponent<MeshFilter>();
                    mf.sharedMesh = GetOrCreateUnitQuadMesh();

                    var mr = go.AddComponent<MeshRenderer>();
                    mr.sharedMaterial = _kibaGlowMat;
                    mr.sortingLayerID = baseMr.sortingLayerID;
                    mr.sortingOrder = baseMr.sortingOrder + 5;
                    mr.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
                    mr.receiveShadows = false;

                    _kibaBaseGr = baseGr;
                    _kibaGlowGo = go;
                    _vb10GlowStartTime = Time.unscaledTime;

                    Plugin.Log.LogInfo(
                        $"[S2SaveKiba] Created vb10 golden glow on Kiba (bounds={baseMr.bounds.size}, center={baseMr.bounds.center}, layer={go.layer}, order={mr.sortingOrder}, shader={_kibaGlowMat.shader?.name}).");
                }

                if (_kibaGlowGo != null && _kibaGlowMat != null && _kibaBaseGr != null && _kibaBaseGr._meshRenderer != null)
                {
                    var baseMr = _kibaBaseGr._meshRenderer;
                    var bounds = baseMr.bounds;
                    float refSize = Mathf.Max(bounds.size.x, bounds.size.y);
                    if (refSize < 0.05f) refSize = 1.5f;

                    float elapsed = Time.unscaledTime - _vb10GlowStartTime;
                    float fadeIn = Mathf.Clamp01(elapsed / 1.5f);
                    float pulse = 0.85f + 0.15f * Mathf.Sin(elapsed * 3.4f);

                    // Keep centered on Kiba's live world bounds, slightly in front along camera Z
                    _kibaGlowGo.transform.position = new Vector3(bounds.center.x, bounds.center.y, bounds.center.z - 0.05f);
                    float scale = refSize * 2.4f * (0.95f + 0.12f * pulse);
                    _kibaGlowGo.transform.localScale = new Vector3(scale, scale, 1f);

                    float strength = 0.90f * fadeIn * pulse;
                    var col = new Color(1.0f * strength, 0.88f * strength, 0.42f * strength, strength);
                    if (_kibaGlowMat.HasProperty("_Color")) _kibaGlowMat.SetColor("_Color", col);
                    if (_kibaGlowMat.HasProperty("_BaseColor")) _kibaGlowMat.SetColor("_BaseColor", col);
                    _kibaGlowMat.color = col;
                }
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"[S2SaveKiba] Glow error: {ex.Message}");
            }
        }
    }
}
