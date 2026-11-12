# Suikoden I & II HD Remaster — Complete Battle Skills, Runes, Unites, Enemy Abilities & Animations Catalog

This document captures the verified reverse-engineering findings for **Suikoden II (`GSD2`)** and **Suikoden I (`GSD1`)** battle systems in `GameAssembly.dll` (`Il2CppDump/dump.cs`) and runtime game data (`text_gsd1_en`, `text_gsd2_en`, `Suisource/GSD1`, `Suisource/GSD2`), plus the architecture used by **PKDev Battle Skill & Anim Lab** (`PKDev/Patches/BattleLabPatch.cs`).

---

## 1. Suikoden II (`GSD2`) Battle Skill, Magic, Unite & VFX Systems

### 1.1 `b_read` Overlay Loader (`b_read.g_data_table[0..259]`)

Every spell, command-rune attack, unite attack, and monster/boss visual effect in GSD2 loads through `b_read` (`Singleton<b_read>`), whose `g_data_table` holds `Func<IBattleManager, B_FUNC_DATA>[]` across **260 slots** (**214 populated entries**).

| Slot Range | `b_read_h` Constant | Namespace / Class Prefix | Count | Purpose |
| --- | --- | --- | --- | --- |
| `1..72, 79..98, 106..107` | `MAGIC_BASE = 0` (`MAGIC_COUNT = 107`) | `Magic.*` (`MagicBase : IOverFunc`) | 94 | Standard Rune Spells, Command Runes, & Special Cast Overlays (`106=Magic.Winr`, `107=Magic.Burn`) |
| `73..78`, `99..105` | — | `null` | 13 | Empty / unused `magi_data_table` & `b_read` slots |
| `109..113` | `B_SECOND_FUNC..B_AFTER_FUNC` | Internal helpers | — | Pre/post turn helper constants (`B_READ_UNI_OFFSET = 113`, `B_READ_ITEM_OFFSET = 144`) |
| `114..163` | `UNITE_BASE = 113` (`UNITE_COUNT = 50`) | `Unite.Unite01..Unite50` (`UniteBase : IOverFunc`) | 50 | All 50 Party Unite Attacks (`Unite01..Unite50`, plus base `UniteBase`, `UniteData`) |
| `175..254` | `M_EFF_BASE = 174` (`MF_COC_0..MF_FIR_5`) | `M_Effect.mf_*` (`M_EffectBase : IOverFunc`) | 70 | Boss & Enemy Battle Effect Overlays (slots `188, 200, 231..234, 249..252` skipped in `g_data_table`) |

#### `B_FUNC_DATA` Struct (`TypeDefIndex: 452`)

```csharp
public class B_FUNC_DATA
{
    public BattleOverlayDelegate init_func; // 0x10 - int Invoke(BATTLE_WORK)
    public BattleOverlayDelegate main_func; // 0x18 - int Invoke(BATTLE_WORK)
    public BattleOverlayDelegate end_func;  // 0x20 - int Invoke(BATTLE_WORK)
    public BATTLE_EFFECT_DATA data;         // 0x28
    public IOverFunc overlay_func;          // 0x30 - MagicBase / UniteBase / M_EffectBase
}
```

#### `IOverFunc.Invoke()` Execution Contract (Verified via `GameAssembly.dll` Disassembly)
- `b_read.SetBRead(int data_no)` queues `data_no` into `BATTLE_WORK.b_read_work`.
- `b_read.DoBRead()` advances loading (`active_buff_status` -> `2`), populates `BATTLE_WORK.b_func_data`, and calls `b_func_data.init_func?.Invoke(battle_work)`.
- During `BattleManager.battle_turn_magic01()` (`0x1814635F2..0x181463617`), `magic_func.Invoke()` (`IOverFunc`) returns **`0`** (or non-`0xFF`) while active and **`(sbyte)-1` (`0xFF`)** on completion (`cmp al, 0xff; je ...`).

---

### 1.2 All 94 `Magic.*` Classes & `magi_data_table` / `EMBL_DATA` Reference

#### `Magic.*` Namespace Classes (94 Verified in `dump.cs`)
- **Fire / Rage (`Fire1..5`)**: Fire Wall (`1870`), Dancing Flames (`1872`), Explosion (`1874`), Final Flame (`1876`)
- **Water / Flowing (`Wat1..5`)**: Drops of Kindness (`1878`), Protection Mist (`1880`), Rain of Kindness (`1882`), Silent Lake (`1884`), Mother Ocean (`1886`)
- **Wind / Cyclone (`Win1..5`, `Winr`)**: Wind of Sleep (`1888`), Healing Wind (`1890`), Shredding Wind (`1891`), Storm Warning (`1893`), Shining Wind (`1895`), plus `Winr` (`slot 106`, `PlayerCalcWindReMag`)
- **Earth / Mother Earth (`Eat1..5`)**: Clay Guardian (`1897`), Revenge Earth (`1899`), Canopy Defense (`1900`), Earthquake (`1902`), Guardian Earth (`1904`)
- **Lightning / Thunder (`Thu1..5`)**: Angry Blow (`1906`), Thunder Runner (`1908`), Bolt of Wrath (`1910`), Lightning Ball (`1912`), Thunder Storm (`1914`)
- **Soul Eater / Dark (`Dark1..6`)**: Finger of Death (`1916`), Black Shadow (`1918`), Hell (`1920`), Judgment (`1922`), plus extended dark variants
- **Resurrection (`Hol1..4`)**: Scolding (`1924`), Yell (`1926`), Exorcism (`1928`), Scream (`1930`)
- **Bright Shield (`Shi1..4`)**: Great Blessing (`1931`), Shining Light (`1933`), Battle Oath (`1935`), Forgiver's Seal (`1936`)
- **Black Sword (`Swo1..4`)**: Flash Judgment (`1938`), Twinkling Blade (`1940`), Piercing One (`1942`), Hungry Friend (`1943`)
- **Blinking (`Bli1..3`)**: Ready! (`1944`), Set! (`1946`), Go! (`1948`)
- **Blue Moon / Darkness (`Mil`, `Sin`)**: Stealer of Souls (`1950`), Final Bell (`1952`)
- **Pale Gate (`Gate1..4`)**: Open Gate (`1954`), Kings Road (`1956`), Pale Palace (`1958`), Empty World (`1959`)
- **Unicorn / White Saint (`Uni1..3`)**: Shining Pupil (`1961`), Moonlit Forest (`1962`), White Priestess (`1964`)
- **Combo / True Rune Unites (`Comb1..5`)**: Scorched Earth (`1966`), Storm Fang (`1968`), Water Dragon (`1970`), Thunder God (`1972`), Blazing Camp (`1974`, `slot 58`)
- **Weapon / Support Command Runes (`Spc1..Spc14`, slots `59..71`)**:
  - `59`: Titan (`1976`), `60`: Viper (`1978`), `61`: Great Hawk (`1980`), `62`: Lion (`1982`), `63`: Kite (`1984`), `64`: Unicorn (`1986`), `65`: Minotaur (`1988`), `66`: Pixie [Staff 1/5 MAG, `1991` / `2578`], `67`: Banshee (`1992`), `68`: Sylph (`1994`), `69`: Chimera (`1996`), `70`: Nymph (`1998`), `71`: Dryad (`2000`)
- **Character / Monster Special Command Runes (`slots 79..98`)**:
  - `Kal` (`79`): Gadget (`2004`)
  - `Klk1..3` (`80..82`): Shrike (`2006`), Falcon (`2008`), Mayfly (`2010`)
  - `Kks` (`83`): Swallow (`2012`)
  - `Bor` (`84`): Fire Breath (`2014`)
  - `Mdo` (`85`): Groundhog (`2016`)
  - `Fire4`/`Comb` variant (`86`): Fire Dragon (`2018`)
  - `Gri1..3` (`87..89`): Shining Wind (Griffin x3, `2020..2023`)
  - `Klk`/Kraken (`Ora` / `90..92`): Blue Drop (Kraken x3, `2024..2027`)
  - `Zam` (`93`): White Tiger (`2028`)
  - `Wol` (`94`): Howling (`2030`)
  - `Ksm` (`95`): Spider Slay (`2032`)
  - `Ora` (`96`): Angry Dragon (`2034`)
  - `Sen` (`97`): Twin Ring (`2036`)
  - `Msm` (`98`): Rabid Fang (`2037`)
  - `Burn` (`107`): Burn overlay (`b_read_h.MF_MAG_BURN`)
  - `Lfi`: Life / Special helper class (`Magic.Lfi`)

#### `BattlePlayerCharacter._magic_func_table[0..105]` Special Handlers
Verified non-default magic calculation handlers:
`NormalMagicKaifukuFunc`, `MagicEnchantFunc`, `DeadMagicDamageFunc`, `CombMagicDamageFunc`, `SpcDamageFunc`, `MissMagicDamageFunc`, `WindDamageFunc05`, `MagicShieldFunc04`, `MagicWater4Func`, `SoulMagicDamageFunc05`, `MajinMagicDamageFunc`, `KaenjinDamageFunc`, `NinfuAttackFunc`, `WolfChangeFunc`.

#### `EMBL_DATA` Orb Range (`text_gsd2_en` `2535..2655`)
Fire (`2535`), Rage (`2537`), Water (`2539`), Flowing (`2541`), Wind (`2543`), Cyclone (`2545`), Earth (`2547`), Mother Earth (`2549`), Lightning (`2551`), Thunder (`2553`), Soul Eater (`2555`), Resurrection (`2557`), Bright Shield (`2559`), Dark Sword (`2561`), Blinking (`2562`), Darkness (`2564`), Pale Gate (`2566`), White Saint (`2568`), Titan..Dryad (`2570..2584`), Gadget..Rabid Fang (`2588..2606`), Passive Orbs: Fortune (`2609`), Prosperity (`2611`), Champion's (`2613`), Double-Beat (`2615`), Killer (`2617`), Counter (`2619`), Spark (`2621`), Gale (`2623`), Sunbeam (`2625`), Phero (`2627`), Knight (`2629`), Wall (`2631`), Haziness (`2633`), Drain (`2635`), Barrier (`2637`), Balance (`2639`), Fire Sealing (`2641`), Skunk (`2643`), Firefly (`2645`), Medicine (`2647`), Double-Edged (`2649`), Wizard (`2651`), Warrior (`2653`), Waking (`2655`).

---

### 1.3 All 50 GSD2 Unite Attacks (`b_read` `114..163`, `Unite.Unite01..50`)

Loaded from `bc_udat.json` (`unite_data_table[1..50]`) via `BATTLE_WORK.GetUniteData(int unite_id)`.
`text_gsd2_en` verified Unite titles (`1261..1303`):
- Twin Fighter Attack (`1261`), Buddy Attack (`1263`), Ninja Attack (`1265`), Husband & Wife Attack (`1266`), Double Kraken Attack (`1268`), Swordsman Attack (`1269`), Copycat Attack (`1271`), Double Leader Attack (`1273`), Circus Attack (`1275`), Flash Attack (`1277`), Beauty Attack (`1279`), Warriors' Village Attack (`1281`), Groupie Attack (`1283`), Tackle Attack (`1285`), Family Attack (`1287`), Pretty Boy Attack (`1289`), Pretty Girl Attack (`1291`), 100 Kobolds Attack (`1292`), Fancy Lad Attack (`1293`), Bandit Attack (`1295`), Underling Attack (`1296`), True Beauty Attack (`1298`), Five Squirrel Attack (`1300`), Beastmaster Attack (`1302`), plus all 50 `Unite01..Unite50` binary slots in `b_read` (`114..163`).

---

### 1.4 All 70 `M_Effect.mf_*` Enemy / Boss VFX (`b_read` `175..254`)

| `b_read` Slot | Constant (`b_read_h`) | Class (`M_Effect.*`) |
| --- | --- | --- |
| `175..176` | `MF_COC_0..1` | `mf_coc0`, `mf_coc1` |
| `177..179` | `MF_CIM_0..2` | `mf_cim0`, `mf_cim1`, `mf_cim2` |
| `180..181` | `MF_MAO_0..1` | `mf_mao0`, `mf_mao1` |
| `182` | `MF_RAU_0` | `mf_rau0` |
| `183..184` | `MF_KUL_0..1` | `mf_kul0`, `mf_kul1` |
| `185..186` | `MF_SIE_0..1` | `mf_sie0`, `mf_sie1` |
| `187` (`188` unused) | `MF_GOR_0` | `mf_gor0` |
| `189..192` | `MF_MAG_0..3` | `mf_mag0`, `mf_mag1`, `mf_mag2`, `mf_mag3` |
| `193..194` | `MF_GEK_0..1` | `mf_gek0`, `mf_gek1` |
| `195..196` | `MF_NED_0..1` | `mf_ned0`, `mf_ned1` |
| `197` | `MF_BOA_0` | `mf_boa0` |
| `198` | `MF_SIR_0` | `mf_sir0` |
| `199` (`200` unused) | `MF_MEI_0` | `mf_mei0` |
| `201..203` | `MF_DRE_0..2` | `mf_dre0`, `mf_dre1`, `mf_dre2` |
| `204` | `MF_GWO_0` | `mf_gwo0` |
| `205..206` | `MF_TAR_0..1` | `mf_tar0`, `mf_tar1` |
| `207` | `MF_UNI_0` | `mf_uni0` |
| `208..209` | `MF_COL_0..1` | `mf_col0`, `mf_col1` |
| `210..211` | `MF_FIR_1`, `MF_FIR_4` | `mf_fir1`, `mf_fir4` |
| `212..213` | `MF_WIN_1`, `MF_WIN_3` | `mf_win1_me`, `mf_win3_me` (plus helper `mf_win1`) |
| `214..220` | `MF_LAS_0..6` | `mf_las0..mf_las6` (Beast Rune / Boss final) |
| `221` | `MF_EAR_4` | `mf_ear4` |
| `222` | `MF_SID_0` | `mf_sid0` |
| `223` | `MF_LUS_0` | `mf_lus0` |
| `224..230` (`231..234` unused) | `MF_DRE_3..9` | `mf_dre3..mf_dre9` |
| `235` | `MF_LAS_7` | `mf_las7` |
| `236..237` | `MF_KI2_0..1` | `mf_ki20`, `mf_ki21` |
| `238..239` | `MF_NEC_0..1` | `mf_nec0`, `mf_nec1` (Neclord) |
| `240..241` | `MF_GOL_0..1` | `mf_gol0`, `mf_gol1` |
| `242` | `MF_SAM_0` | `mf_sam0` |
| `243` | `MF_GWO_1` | `mf_gwo1` |
| `244..245` | `MF_HAP_0..1` | `mf_hap0`, `mf_hap1` (Harpy) |
| `246..248` (`249..252` unused) | `MF_IMO_0..2` | `mf_imo0`, `mf_imo1`, `mf_imo2` |
| `253..254` | `MF_FIR_3`, `MF_FIR_5` | `mf_fir3`, `mf_fir5` |

---

### 1.5 GSD2 Character & Enemy Animation System & Monster Skills (`area_func` / `MONSTER_DATA`)

- **77 Player Battle Sprite Sheets (`<3char>_battle_00`, `ail..yam`)** driven by `BATTLE_CHARA.SetAction(int basePointIndex, ActionDataPointer _action)` and `BATTLE_CHARA.SetActionIndex(int basePositionIndex, byte actionNo)`.
- **`b_player` Shared Animation Pointers (`TypeDefIndex: 188`)**:
  `player_kireru_action`, `player_kabau_action`, `player_kabatta_action`, `player_kabaware_action`, `player_kabawareta_action`, `player_change_move_action`, `player_change_back_action`, `player_magic_action`, `player_magic_end_action`, `player_re_mag_action`, `player_re_mag_action_earth`, `player_re_mag_action_wind`, `player_blinking_action`, `player_re_mag_end_action`, `player_unite_action`, `player_special_action`, `player_item_action`, `fire_damage_action`, `thunder_damage_action`, `okane_damage_action`, `mag_sui_damage_action`, `hitokage_damage_action`, `drain_recover_action`.
- **256 `MONSTER_DATA` Entries (`TypeDefIndex: 1492`)**:
  - Each `MONSTER_ATTACK_DATA` entry (`TypeDefIndex: 491`) has `attack_type`, `attack_func_index`, and `attack_disp_func_index`.
  - Resolved dynamically through `area_func` (`TypeDefIndex: 704`, **1,584** registered overlay entries in `g_area_func_name`):
    - `area_func.GetBattleOverlayFunction(int idx)` -> `BattleOverlayDelegate` (`int Invoke(BATTLE_WORK)`)
    - `area_func.GetBattleOverlayLoadFunction(int idx)` -> `BattleOverlayLoadDelegate`
    - `area_func.GetBattleCharaOverlayFunction(int idx)` -> `BattleCharaOverlayDelegate`
  - Also contains **97 `b_read.SetBRead(...)` callers** across boss/enemy AI modules (`boss_las`, `boss_mf_*`, `a_mf_*`, `c_*`, `d_*`, `e_mf_*`, `f_mf_*`, `g_*`, `h_sir_data`, `i_mf_*`, `j_mf_*`, `kks_*`).

---

## 2. Suikoden I (`GSD1`) Battle Skill, Magic, Unite & Enemy Systems

### 2.1 `BattleBase` (`TypeDefIndex: 4133`) & `G1_area_func_c` (`TypeDefIndex: 4670`)

Unlike GSD2's `b_read` dynamic loader, GSD1 compiles most player spells, runes, unites, and character specials directly onto `BattleBase`, while enemy AI & special attacks resolve through the **1,109-entry** `G1_area_func_c` table (`FUNC_CNT = 1109`):
- `G1_area_func_c.GetG1FunctionName(int idx)`
- `G1_area_func_c.g1_GetOverlayFunction(int idx, string szInfo)` -> `AREA_FUNC_DELEGATE_BT` (`int Invoke(BATTLE_WORK)`)
- All **136 `*_monster_data_XX.json`** files map `monster_function_index` (94 unique) and `action_function_index[]` (109 unique non-zero) across `G1_area_func_c` (`area_func_tbl`).

### 2.2 GSD1 Runes, Spells (`magic11..85`), Specials & Unites (`kyoryoku01..32`)

- **Runes (`text_gsd1_en` `2518..2550`)**: Soul Eater (`2518`), Fire (`2520`), Water (`2521`), Wind (`2522`), Lightning (`2523`), Earth (`2524`), Resurrection (`2525`), Boar (`2526`), Shrike (`2527`), Falcon (`2528`), Blaze (`2529`), Gadget (`2530`), Clone (`2531`), Double-Jab (`2532`), Killer (`2533`), Counter (`2534`), Spark (`2535`), Haziness (`2536`), Gale (`2537`), Sunbeam (`2538`), Speed (`2539`), High-Speed (`2540`), Fortune (`2541`), Prosperity (`2542`), Champion's (`2543`), Turtle (`2544`), Phero (`2545`), Rage (`2546`), Flowing (`2547`), Cyclone (`2548`), Mother Earth (`2549`), Thunder (`2550`).
- **Spells (`text_gsd1_en` `2778..2815`)**:
  - Fire (`magic11..15`?): Flaming Arrows (`2778`), Firestorm (`2779`), Dancing Flames (`2780`), Explosion (`2781`), Final Flame (`2782`)
  - Resurrection: Scolding (`2783`), Yell (`2784`), Scream (`2785`), Exorcism (`2786`)
  - Water/Flowing: Drops of Kindness (`2787`), Fog of Deception (`2788`), Flood of Kindness (`2789`), Rain of Kindness (`2790`), Mother Ocean (`2791`)
  - Wind/Cyclone: Wind of Sleep (`2792`), Shredding Wind (`2793`), Healing Wind (`2794`), Storm (`2795`), Shining Wind (`2796`)
  - Lightning/Thunder: Angry Blow (`2797`), Lightning Storm (`2798`), Raging Blow (`2799`), Lightning Ball (`2800`), Thunder God (`2801`)
  - Earth/Mother Earth: Clay Guardian (`2802`), Gaia's Voice (`2803`), Iron Body (`2804`), Earthquake (`2805`), Earth Guardian (`2806`)
  - Soul Eater: Finger of Death (`2807`), Black Shadow (`2808`), Hell (`2809`), Final Judgment (`2810`)
  - True Rune Combo Magics (`kmagic01..25`): Scorched Earth (`2811`), Blade Fury (`2812`), Blazing Array (`2813`), Hammer of Thor (`2814`), Water Dragon (`2815`).
- **Character Special Actions (`BattleBase`)**:
  - `pan_tokusyu_func`, `wakemi_tokusyu_func`, `vre_tokusyu_func`, `bel_tokusyu_func`, `kas_tokusyu_func`, `jup_tokusyu_func`
  - `yumi_func`, `syuriken_func`, `bunshin_func`, `kas_damage_func`, `jup_karakuri_func`, `fire_palette_func`, `baloon_func`
  - War Runes (`G1_w_magic_c`): `WarMagic1..3`, `WarMagicKafun`
- **32 Unites (`BattleBase.kyoryoku01..32` / `kyoryoku_data_table`, `text_gsd1_en` `2356..2380`)**:
  Guardian (`2356`), Fisherman (`2357`), Wild Arrow (`2358`), Elf (`2359`), Pirate (`2360`), Blacksmith (`2361`), Opposites (`2362`), Fancy Lad (`2363`), Pretty Girl (`2364`), Beauty (`2365`), Flash (`2366`), Kobold (`2367`), Dragon Knight (`2368`), Stuck With You (`2369`), Trickster (`2370`), Warrior (`2371`), Couple (`2372`), Bandit (`2373`), Carpenter (`2374`), Kobolds & Pal (`2375`), Beat 'Em Up (`2376`), Ninja (`2377`), Martial Arts (`2378`), Lepant Family (`2379`), Master & Pupil (`2380`) + 7 additional internal variants (`kyoryoku20..26` share duplicate base names).
- **GSD1 Animation Controls**: `BattleBase.b_SetAction(int bc, byte kijun, short[] action_data)`, `BattleBase.g1_ActionBC(int bc_no)`, `BATTLE_CHARA.action_data_table`.

---

## 3. Sandbox Controls Architecture (Used by `PKDev` -> `BattleLabPatch`)

### 3.1 "Enemies Don't Attack"
- **GSD2**: Prefix on `BattleManager.monster_rootine()`:
  - Clears `BATTLE_WORK.Instance.monster_func = null` and `monster_func_work = null`, restores `BATTLE_WORK.Instance.turn_step` to allow clean turn advance, sets `__result = -1` (matches native exit `mov eax, 0xffffffff; ret`), and returns `false`. Also Prefix on `BattleMonsterCharacter.SelectAttackMode()` skips attack selection.
- **GSD1**: Prefix on `BattleBase.monster_rootine(int step_level)`:
  - Clears `BattleBase.battle_work.monster_func = null`, sets `__result = -1` (matches native `0x1810D44be`), and returns `false`.

### 3.2 "Enemies Infinite HP"
- **GSD2**:
  - Postfix on `BattleManager.BattlePhaseLoop()` (per-frame maintenance) + Prefix on `BattleManager.CalcDeadChara()` / `BattleManager.SetDeadCharaHpOne()` when active:
    For every enemy slot `i` (`player_kazu <= i < player_kazu + monster_kazu`) in `BATTLE_WORK.Instance.pm_data`: clamps `pm.hp` back up to `pm.max_hp` (min `1`), sets `pm.disp_hp = pm.hp`, clears `pm.dead_flg = 0`, `pm.disp_dead_flg = 0`, `pm.turn_end_dead_flg = false`, allowing floating damage numbers to still appear while keeping every enemy alive for repeated skill testing.
- **GSD1**:
  - Prefix/Postfix on `BattleBase.calc_hp()`, `BattleBase.dead_chara(int chara_no)`, `BattleBase.SetEnemyHpZero()`, and per-frame in `BattleBase.battle_main(int)`: restores every enemy slot (`player_kazu <= i < player_kazu + monster_kazu`) in `BattleBase.battle_work.pm_data` to `pm.hp = (ushort)Math.Max(1, (int)pm.max_hp)` and `pm.dead_flg = 0`.
