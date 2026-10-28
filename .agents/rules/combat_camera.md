---
description: Suikoden I & II combat detection, battle cameras, FOV calculations, BindCamera synchronization, and status aura alignment grounding.
---

# Suikoden I & II Battle Detection & Combat Camera Grounding

## Suikoden II (`GSD2`) Battle Detection (Zero-Hook / Per-Frame)
- **Standard Party Battle (Initialized)**:
  `GSD2::GRChapterManager.GRInstance != null && GSD2::GRChapterManager.GRInstance.IsBattleInitEnd()` (`0x181f25eb0`, checks active `BattleChapter` and `BattleChapter.isInit == true`).
- **BattleManager Singleton Check (Party Battle & 1v1 Duel)**:
  `GSD2::BattleManager.IsInstance` (`0x18146bde0`) or `GSD2::BattleManager.Instance != null` (destroyed via `BattleManager.Release()` on battle exit).
- **Distinguishing Combat Modes (`GRChapterManager.GetActiveChapterType()` / `SYS_WORK`)**:
  - `MapChapter` (`sys_work.game_mode == 1`): Town / Dungeon / World Map exploration.
  - `BattleChapter` (`sys_work.game_mode == 2`, `sys_work.g_bInBattle == true`): Turn-based party battle.
  - `IkkiChapter` (`sys_work.game_mode == 4`, `BattleManager.Instance.ikki_work != null`): 1v1 Duel (Ikki-uchi).
  - `WarChapter` (`sys_work.game_mode == 5`): Tactical Army War Battle.

## Suikoden II (`GSD2`) Event-Driven Battle Hooks
- **Battle Start**: Hook `BattleChapter.Start` or `Field.Setup(BATTLE_WORK)` (`0x181c78430`).
- **Battle End**: Hook `BattleChapter.OnDestroy` (`0x181f20b60`) or `BattleManager.Release` (`0x18143d4a0`).

## Suikoden II (`GSD2`) Battle Camera & FOV Architecture (`GSD2::Field`)
- In `GSD2::Field..cctor` (`0x181c79280`), default static values are:
  - `Field.CAMERA_DISTANCE = 1024f`
  - `Field.DEFAULT_CAMERA_ORTHO_SIZE = 1.2f`
  - `Field.DEFAULT_CAMERA_FOV_SIZE = 15.0f`
- Every frame in `Field.UpdateView` (`0x181c78d70`) $\rightarrow$ `Field.SetData(Vector3 position, Vector3 angle, float scale)` (`0x181c77440`), the battle camera computes:
  - `normScale = scale / 4096f`
  - `FieldCamera.orthographicSize = Field.DEFAULT_CAMERA_ORTHO_SIZE / normScale`
  - `FieldCamera.fieldOfView = Field.DEFAULT_CAMERA_FOV_SIZE / normScale`
- `BindCamera.Sync` (`0x182242350`) and `Field.SetupGroundCamera` (`0x181c781e0`) synchronize `orthographicSize` and `fieldOfView` from `FieldCamera` to `GroundCamera`.
- **FieldFrontCamera & Status Aura Alignment**:
  - `Field.FieldFrontCamera` (`+0x88`, bound via `Field.bindCamera` at `+0x30`) renders front-layer combat effects and character status auras (`GSD2::BATTLE_CHARA.AuraAnimeDisp` at `0x181401f80`, such as the red Fury status afterimage).
  - Vanilla `Field.SetupFrontCamera` (`0x181c78160`) only copies `nearClipPlane` and `farClipPlane` and has `detailSyncStartupOnly = true`, leaving `FieldFrontCamera.fieldOfView` at `15.0f` unless explicitly synced:
    - `FieldFrontCamera.fieldOfView = FieldCamera.fieldOfView`
    - `BindCamera.ForceDetailSync = true`
    - `bindCamera.Sync(true)`

## Suikoden I (`GSD1`) Battle Detection & Combat Camera Architecture (`GSD1::BattleBase` / `GSD1::BattleChapter`)
- **Battle Detection**: `GSD1::BattleBase.battle_work != null` and `GSD1::BattleChapter.classicCamera != null`.
- **Event-Driven Battle Hooks**:
  - **Battle Start**: `GSD1::BattleBase.BattleUpdateInit` (`0x180fd7a30`).
  - **Per-Frame Update**: `GSD1::BattleBase.BattleUpdate` (`0x180fd7c90`).
  - **Battle End**: `GSD1::BattleChapter.OnDestroy` (`0x1811cabb0`) or `GSD1::BattleChapter.BattleEndInternal` (`0x1811ca300`).
- **Battle Camera Zoom (`GSD1::BattleBase.cameraDefPos`)**:
  - In `GSD1::BattleChapter..ctor` (`0x1811cb7a0`), `cameraDefaultPosition` is `(0f, 0f, -1100f)`.
  - `BattleBase.BattleUpdateInit` (`0x180fd7a30`) copies this into `GSD1::BattleBase.cameraDefPos` (`+0x18` on `BattleBase_StaticFields`).
  - Every frame in `GSD1::BattleBase.BattleUpdate` (`0x180fd7c90`), HD mode computes:
    - `normScale = battle_work.m_scale[0] / 4096f`
    - `BattleChapter.classicCamera.transform.localPosition = new Vector3(cameraDefPos.x, cameraDefPos.y, cameraDefPos.z / normScale)`
  - Bound cameras (`groundCamera`, `battleBGCamera`, `fieldFrontCamera`, `skyCamera`) sync world transform to `classicCamera` via `BindCamera.LateUpdate` (`0x182242090`).

