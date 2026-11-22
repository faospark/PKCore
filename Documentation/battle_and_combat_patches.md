# Battle & Combat Patches Reference — PKCore

> Originally documented in the standalone `PKBattlePatch` plugin, now built directly into **PKCore** under `[06 Battle & Combat]`.

---

## Patches Overview

| Patch | Scope | Notes |
| :--- | :---: | :--- |
| `BattleEnemyLevelPatch.cs` | S1 + S2 | Formats enemy level and secondary HP line in the battle target selection window. |
| `BattlePartyHPPatch.cs` | S1 + S2 | Expands party status HP display to `Current/Max` with adjusted bounds. |
| `MemoryAutoBattlePatch.cs` | S2 | Records manual combat commands (Attack, Defend, Runes) and replays them during Auto-Battle (Omakase), falling back to Attack if MP is depleted or silenced. |
| `SmartHealingPatch.cs` | S2 | Post-battle triage (Sacrificial Jizo → Antitoxin → Kindness Rain / Healing Wind → Medicine / Mega Medicine / Kindness Drops), drawing from the Party Bag. |
| `BattlePositionPatch.cs` | S2 | Adjusts 6-character formation offsets (`default`, `wide`, `widest`) so back-row sprites do not obscure front-row characters. |
| `BattleCameraZoomPatch.cs` | S1 + S2 | Scales S1 `BattleBase.cameraDefPos.z` (`-1100.0` baseline) and S2 `Field.DEFAULT_CAMERA_FOV_SIZE` (`15.0` baseline) according to `S1BattleCameraFovPercent` / `S2BattleCameraFovPercent` (default `125%`). |
| `CommandRuneReusePatch.cs` | S2 | Removes the 1-use-per-battle limit on character command runes (Meg Trick, Millie Groundhog, Shin Spider Slay, Oulan Angry Dragon) and optionally allows Angry Dragon without taking damage / losing Fury. |
| `CommandRuneSelfUnbalancePatch.cs` | S2 | Inspects equipped runes (`G2_varia_dat.mon_eqp`) and cancels self-unbalance strictly for the 8 authentic self-unbalancing physical command runes (Swallow, Fire Breath, Mayfly, White Tiger, Blue Drop, Twin Ring, Gozu, Trick), preserving enemy & Unite attack unbalance (`c_koudou == 4`). |
| `CharacterRangePatch.cs` | S2 | Applies per-character weapon range overrides (`S`/`M`/`L`). See [Suikoden II Character Battle Ranges](suikoden_2_character_battle_ranges.md). |
| `S2BrightShieldEnhancementPatch.cs` | S2 | Enhances the Bright Shield Rune: Great Blessing also applies Clay Guardian (1.5x DEF), Shining Light adds current recruit count to damage, and Battle Oath has a 50% chance to apply Awakened alongside Anger. |
| `S2SoftResetBattleFixPatch.cs` | S2 | Guards `BATTLE_WORK.PreRelease` against a `NullReferenceException` when soft-resetting during battle. |
| `BattleUnitWindowDiagnostics.cs` | S1 + S2 | Optional battle party window hierarchy/layout diagnostics (`LogBattleUnitWindow`). |

---

## Configuration Reference (`BepInEx/config/faospark.pkcore.cfg`)

```ini
[06 Battle & Combat]
ShowBattleMaxHP = true                  # Show Current/Max HP in party status window (S1 & S2)
ShowEnemyLevelInBattle = true           # Show enemy level in target selection window (S1 & S2)
ShowEnemyHpInBattle = true              # Show enemy HP Current/Max line in target selection window (S1 & S2)
EnableMemoryAutoBattle = true           # Repeat last manual command during Auto-Battle (S2)
EnableSmartHealing = true               # Auto-revive, cure Poison, and heal wounds after battle (S2)
EnableBattlePositionAdjustments = true  # Adjust 6-character formation spacing (S2)
S2BattlePositionPreset = wide           # Formation preset: default, wide, or widest
EnableBattleCameraZoom = true           # Enable wider battle camera FOV (S1 & S2)
S1BattleCameraFovPercent = 125          # S1 battle camera zoom % (100 = vanilla -1100.0)
S2BattleCameraFovPercent = 125          # S2 battle camera zoom % (100 = vanilla 15.0 FOV)
RemoveCommandRuneUseLimit = true        # Remove 1-use-per-battle limit on character command runes (S2)
AlwaysAvailableAngryDragon = true       # Angry Dragon Rune always usable without damage/Fury loss (Oulan)
RemoveCommandRuneSelfUnbalance = true   # Remove self-unbalance penalty on whitelisted ability runes (S2)
EnableCharacterRangeOverrides = true    # Enable per-character weapon range overrides (S2)
S2CharacterRangeOverrides = Kasumi:M, Luc:M, Mazus:M, Viki:M, Gantetsu:M, Badeaux:M, Sierra:M, Freed Y:M, Chuchara:M
EnhanceBrightShieldRune = true          # Enhance Bright Shield Rune spells (Great Blessing, Shining Light, Battle Oath)

[zz - Diagnostics]
LogBattlePositions = false              # Log party formation coordinates on battle start
LogBattleUnitWindow = false             # Log battle party window layout once per slot per battle
```
