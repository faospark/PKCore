# Dunan Castle Tavern (vk08): Full Disassembly & Architectural Analysis

**Source File**: `D:\Modding\suikodum\Mobobehaviour\vk08.json`

## Overview
- **Master Map**: `vk08` (Dunan Castle Tavern, Kitchen, and Waterfront Landing)
- **Submap Layers**: 3
- **Total EPERSONDAT Graphics Records**: 48
  - `ep[12]`: `fp_no = 65085` (Substitute Maid)
  - `ep[17]`: `fp_no = 91` (**Leona** - Official Tavern Mistress)

## Submap 0 (`vk08_00`): Dunan Castle HQ 1F Tavern & Bar Counter
- **Entity Count (`okaz`)**: 25
- **Event Count (`evkaz`)**: 55

### Physical Object Registry (`eventobj`)

| Slot | Character / Sprite (`fpno`) | Tile Coords `(x, y)` | Facing (`ano`) | State (`disp`) | Obstacle (`ozok`) | Speed (`spd`) | Priority (`pri`) |
|:---:|:---|:---:|:---:|:---:|:---:|:---:|:---:|
| `obj[00]` | `fpno: 98` | `(32, 38)` | East | 0 | 2 | 4 | 0 |
| `obj[01]` | *Invisible Trigger/Collision* | `(33, 52)` | 25 | 0 | 2 | 4 | 0 |
| `obj[02]` | `fpno: 41` | `(40, 42)` | East | 0 | 3 | 3 | 0 |
| `obj[03]` | `fpno: 120` | `(50, 62)` | East | 0 | 3 | 3 | 0 |
| `obj[04]` | `fpno: 22` | `(65, 61)` | South | 0 | 2 | 4 | 0 |
| `obj[05]` | `fpno: 92` | `(64, 58)` | South | 0 | 2 | 4 | 0 |
| `obj[06]` | `fpno: 99` | `(52, 54)` | East | 0 | 2 | 4 | 0 |
| `obj[07]` | `fpno: 33379` | `(52, 54)` | South | 0 | 0 | 4 | 0 |
| `obj[08]` | `fpno: 103` | `(63, 37)` | East | 0 | 3 | 2 | 0 |
| `obj[09]` | `fpno: 88` | `(63, 73)` | East | 0 | 3 | 3 | 0 |
| `obj[10]` | `fpno: 121` | `(50, 28)` | East | 0 | 2 | 4 | 0 |
| `obj[11]` | `fpno: 57` | `(42, 38)` | South | 0 | 2 | 4 | 0 |
| `obj[12]` | `fpno: 65105` | `(0, 0)` | South | 0 | 2 | 4 | 0 |
| `obj[13]` | *Invisible Trigger/Collision* | `(76, 26)` | South | 1 | 0 | 4 | 0 |
| `obj[14]` | *Invisible Trigger/Collision* | `(30, 30)` | South | 1 | 0 | 4 | 0 |
| `obj[15]` | *Invisible Trigger/Collision* | `(34, 30)` | South | 1 | 0 | 4 | 0 |
| `obj[16]` | *Invisible Trigger/Collision* | `(38, 30)` | South | 1 | 0 | 4 | 0 |
| `obj[17]` | *Invisible Trigger/Collision* | `(28, 52)` | South | 1 | 0 | 4 | 0 |
| `obj[18]` | *Invisible Trigger/Collision* | `(32, 54)` | South | 1 | 0 | 4 | 0 |
| `obj[19]` | *Invisible Trigger/Collision* | `(24, 56)` | South | 1 | 0 | 4 | 0 |
| `obj[20]` | **Substitute Maid** (`fpno: 65085`) | `(37, 51)` | East | 0 | 2 | 4 | 0 |
| `obj[21]` | `fpno: 65048` | `(55, 32)` | South | 0 | 3 | 3 | 0 |
| `obj[22]` | `fpno: 65178` | `(54, 74)` | South | 0 | 3 | 3 | 0 |
| `obj[23]` | `fpno: 65205` | `(39, 45)` | South | 0 | 3 | 3 | 0 |
| `obj[24]` | `fpno: 65163` | `(58, 45)` | South | 0 | 3 | 3 | 0 |

### Bytecode Scripts Registry (`eventdat`)

| Script | Trigger Type | Decoded Preconditions (`eventForm`) | Decoded Command Logic (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | Action / Talk (0x02) | `FLAG_IS_SET(fno=112, mask=0x40) AND FLAG_NOT_SET(fno=46, mask=0x10) AND FLAG_NOT_SET(fno=152, mask=0x08) AND STAR_RECRUITED(chara=98, mask=0x01)` | `WAIT -> RETURN_SUB` |
| `ev[01]` | Action / Talk (0x02) | `FLAG_IS_SET(fno=112, mask=0x40) AND FLAG_NOT_SET(fno=46, mask=0x10) AND FLAG_IS_SET(fno=152, mask=0x10) AND STAR_RECRUITED(chara=98, mask=0x01)` | `WAIT -> RETURN_SUB` |
| `ev[02]` | Action / Talk (0x02) | `FLAG_IS_SET(fno=112, mask=0x40) AND FLAG_NOT_SET(fno=46, mask=0x10) AND FLAG_NOT_SET(fno=153, mask=0x10) AND STAR_RECRUITED(chara=98, mask=0x01)` | `WAIT -> RETURN_SUB` |
| `ev[03]` | Touch / Step (0x01) | `STAR_RECRUITED(chara=98, mask=0x01) AND TALK_TO(obj[8])` | `DISABLE_INPUT -> HON_FLAG_OFF -> RETURN_SUB -> DISABLE_INPUT -> FADE_IN -> WARP_TOWN(30, 3) -> SLEEP -> WAIT -> SHOW_SERIFU(obj=8, msg=1, bank=0) -> WAIT(20 frames) -> Op127 -> WAIT -> FADE_IN -> WARP_TOWN(70, 0) -> SLEEP -> ENABLE_INPUT -> HON_FLAG_OFF -> RETURN_SUB` |
| `ev[04]` | MapInit (0x80) | `STAR_RECRUITED(chara=98, mask=0x01) AND HON_FLAG_SET(fno=17, mask=0x20)` | `WARP_ROOM(0, 13) -> SLEEP -> ENABLE_INPUT -> FADE_IN -> WARP_TOWN(255, 254)` |
| `ev[05]` | Action / Talk (0x02) | `STAR_RECRUITED(chara=42, mask=0x01) AND CastleLv >= 2 AND SEC_FLAG_SET(fno=15, mask=0x08)` | `OVERLAY_PSET -> WAIT -> FLAG_SET(fno=47, mask=0xFF) -> END_TOKEN_FE` |
| `ev[06]` | Touch / Step (0x01) | `TALK_TO(obj[9])` | `EXEC_SCRIPT -> MOVE_DIR -> SLEEP -> WAIT -> OVERLAY_CALL(cat=1, sub=1)` |
| `ev[07]` | Action / Talk (0x02) | `STAR_RECRUITED(chara=41, mask=0x01) AND CastleLv >= 2 AND SEC_FLAG_SET(fno=15, mask=0x01)` | `OVERLAY_PSET -> WAIT -> FLAG_OFF(fno=47, mask=0xFF) -> END_TOKEN_FE` |
| `ev[08]` | Touch / Step (0x01) | `TALK_TO(obj[10])` | `EXEC_SCRIPT -> MOVE_DIR -> SLEEP -> WAIT -> OVERLAY_CALL(cat=1, sub=2)` |
| `ev[09]` | Action / Talk (0x02) | `STAR_RECRUITED(chara=120, mask=0x01) AND CastleLv == 1` | `OVERLAY_PSET -> WAIT -> SET_POS -> OVERLAY_PEND` |
| `ev[10]` | Touch / Step (0x01) | `TALK_TO(obj[11])` | `EXEC_SCRIPT -> MOVE_DIR -> SLEEP -> WAIT -> OVERLAY_CALL(cat=1, sub=3)` |
| `ev[11]` | Action / Talk (0x02) | `FLAG_IS_SET(fno=112, mask=0x40) AND FLAG_NOT_SET(fno=46, mask=0x20) AND STAR_RECRUITED(chara=22, mask=0x01) AND CastleLv == 1` | `OVERLAY_PSET -> WAIT -> WARP_SUBMAP(sub=47, x=255, y=254)` |
| `ev[12]` | Touch / Step (0x01) | `TALK_TO(obj[12])` | `EXEC_SCRIPT -> MOVE_DIR -> SLEEP -> WAIT -> OVERLAY_CALL(cat=1, sub=4)` |
| `ev[13]` | Action / Talk (0x02) | `STAR_RECRUITED(chara=92, mask=0x01) AND CastleLv == 1` | `OVERLAY_PSET -> WAIT -> TURN_CHAR -> OVERLAY_PEND` |
| `ev[14]` | Touch / Step (0x01) | `TALK_TO(obj[13])` | `EXEC_SCRIPT -> MOVE_DIR -> SLEEP -> WAIT -> OVERLAY_CALL(cat=1, sub=5)` |
| `ev[15]` | Action / Talk (0x02) | `STAR_RECRUITED(chara=99, mask=0x01) AND CastleLv == 1 AND Playtime(1..0)` | `WAIT -> CHAR_ANIME` |
| `ev[16]` | Action / Talk (0x02) | `STAR_RECRUITED(chara=99, mask=0x01) AND CastleLv == 1 AND Playtime(0..0)` | `WAIT -> CHAR_ANIME` |
| `ev[17]` | Touch / Step (0x01) | `STAR_RECRUITED(chara=99, mask=0x01) AND CastleLv == 1 AND TALK_TO(obj[14])` | `OBJ_MOVE_TILE -> CHAR_ANIME -> WAIT -> WAIT -> OBJ_MOVE_TILE -> OBJ_MOVE_TILE -> MOVE_SPEED -> WAIT -> OBJ_MOVE_TILE -> OBJ_MOVE_TILE -> EXEC_SCRIPT -> SET_OBJ_POS(obj=9, x=9, y=46) -> SLEEP -> CHAR_ANIME -> OBJ_DISP_ON(obj=14) -> MOVE_SPEED -> WAIT -> WAIT -> CAMERA_MOVE -> OVERLAY_PEND -> EXEC_SCRIPT -> MOVE_DIR -> SLEEP -> WAIT -> OVERLAY_CALL(cat=1, sub=6) -> MOVE_OBJ_PATH -> WAIT -> WAIT -> FACE_PLAYER(obj=36) -> OBJ_FACING -> OBJ_DISP_ON(obj=15) -> MOVE_SPEED -> MOVE_SPEED -> OBJ_DISP_ON(obj=15) -> OBJ_MOVE_TILE -> OBJ_DISP_ON(obj=15) -> OBJ_MOVE_TILE -> OBJ_DISP_ON(obj=15) -> MOVE_SPEED -> MOVE_DIR -> WAIT(20 frames) -> ENABLE_INPUT -> HON_FLAG_OFF -> RETURN_SUB -> ENABLE_INPUT -> HON_FLAG_OFF -> FADE_OUT -> RESET_FLAGS -> OVERLAY_CALL(cat=255, sub=254)` |
| `ev[18]` | MapInit (0x80) | `CHAR_STATE(val=4)` | `WAIT(60 frames) -> SET_OBJ_POS(obj=0, x=182, y=73) -> Op70 -> SET_OBJ_POS(obj=0, x=187, y=101) -> SLEEP -> SLEEP -> START_BOSS_BATTLE -> OBJ_FACING` |
| `ev[19]` | Action / Talk (0x02) | `STAR_RECRUITED(chara=103, mask=0x01) AND CastleLv == 1` | `OVERLAY_PSET -> WAIT -> FADE_OUT -> OVERLAY_PEND` |
| `ev[20]` | Touch / Step (0x01) | `STAR_RECRUITED(chara=103, mask=0x01) AND CastleLv == 1 AND TALK_TO(obj[16])` | `DISABLE_INPUT -> HON_FLAG_OFF -> RETURN_SUB -> DISABLE_INPUT -> FADE_OUT -> Op64 -> EXEC_SCRIPT -> MOVE_DIR -> SLEEP -> WAIT -> OVERLAY_CALL(cat=1, sub=7) -> WAIT(60 frames) -> Op127 -> WAIT -> FADE_OUT -> Op64 -> Op128 -> WAIT -> WAIT -> ENABLE_INPUT -> HON_FLAG_OFF -> RETURN_SUB` |
| `ev[21]` | MapInit (0x80) | `STAR_RECRUITED(chara=103, mask=0x01) AND CastleLv == 1 AND HON_FLAG_SET(fno=16, mask=0x40)` | `WARP_ROOM(0, 13) -> EXEC_SCRIPT -> ENABLE_INPUT -> FADE_OUT -> Op64` |
| `ev[22]` | Action / Talk (0x02) | `FLAG_NOT_SET(fno=46, mask=0x40) AND STAR_RECRUITED(chara=88, mask=0x01) AND CastleLv == 1` | `OVERLAY_PSET -> WAIT -> FADE_IN -> OVERLAY_PEND` |
| `ev[23]` | Touch / Step (0x01) | `TALK_TO(obj[17])` | `EXEC_SCRIPT -> MOVE_DIR -> SLEEP -> WAIT -> OVERLAY_CALL(cat=1, sub=8)` |
| `ev[24]` | Action / Talk (0x02) | `FLAG_IS_SET(fno=112, mask=0x40) AND STAR_RECRUITED(chara=121, mask=0x01) AND CastleLv == 1` | `OVERLAY_PSET -> WAIT -> HON_FLAG_SET -> OVERLAY_PEND` |
| `ev[25]` | Touch / Step (0x01) | `TALK_TO(obj[18])` | `EXEC_SCRIPT -> MOVE_DIR -> SLEEP -> WAIT -> OVERLAY_CALL(cat=1, sub=9)` |
| `ev[26]` | Action / Talk (0x02) | `STAR_RECRUITED(chara=57, mask=0x01) AND CastleLv == 1 AND SEC_FLAG_SET(fno=4, mask=0x01)` | `OVERLAY_PSET -> WAIT -> HON_FLAG_OFF -> OVERLAY_PEND` |
| `ev[27]` | Touch / Step (0x01) | `TALK_TO(obj[19])` | `EXEC_SCRIPT -> MOVE_DIR -> SLEEP -> WAIT -> OVERLAY_CALL(cat=1, sub=10)` |
| `ev[28]` | MapInit (0x80) | `X_RANGE(48..68) AND Y_RANGE(57..83) AND FLAG_NOT_SET(fno=144, mask=0x20) AND HON_FLAG_CLEAR(fno=19, mask=0x10)` | `WARP_ROOM(0, 10) -> WAIT` |
| `ev[29]` | MapInit (0x80) | `X_RANGE(48..68) AND Y_RANGE(57..83) AND FLAG_IS_SET(fno=144, mask=0x20) AND HON_FLAG_CLEAR(fno=19, mask=0x10)` | `WARP_ROOM(0, 10) -> SCREEN_SHAKE` |
| `ev[30]` | MapInit (0x80) | `X_RANGE(48..79) AND Y_RANGE(24..48) AND FLAG_IS_SET(fno=144, mask=0x10) AND HON_FLAG_CLEAR(fno=19, mask=0x08)` | `WARP_ROOM(0, 10) -> PARTY_ADD` |
| `ev[31]` | MapInit (0x80) | `X_RANGE(48..79) AND Y_RANGE(24..48) AND FLAG_NOT_SET(fno=144, mask=0x10) AND HON_FLAG_CLEAR(fno=19, mask=0x08)` | `WARP_ROOM(0, 10) -> WARP_ROOM(255, 254)` |
| `ev[32]` | Action / Talk (0x02) | `FLAG_IS_SET(fno=144, mask=0x04)` | `EXEC_SCRIPT -> SLEEP -> MOVE_SPEED -> FADE_OUT -> SET_POS` |
| `ev[33]` | Action / Talk (0x02) | `NOP AND FLAG_IS_SET(fno=144, mask=0x04)` | `OVERLAY_PSET -> MOVE_SPEED -> TALK_TEXT -> Op58 -> Op84 -> MOVE_DIR -> TALK_TEXT -> SLEEP -> WAIT -> TALK_TEXT -> OVERLAY_PEND` |
| `ev[34]` | Touch / Step (0x01) | `FLAG_IS_SET(fno=144, mask=0x04) AND X_RANGE(49..67) AND Y_RANGE(81..82)` | `MOVE_DIR -> WAIT -> WAIT -> SET_WAIT_TIME -> TALK_TEXT -> OBJ_JUMP -> FACE_PLAYER(obj=20) -> WAIT -> MOVE_SPEED -> WAIT -> WAIT -> MOVE_DIR -> RETURN_SUB -> MOVE_DIR -> TALK_TEXT -> SLEEP -> SHOW_SERIFU(obj=20, msg=15, bank=4) -> LOCK_PLAYER -> MOVE_SPEED -> OBJ_MOVE_TILE -> WAIT -> SLEEP -> MOVE_DIR -> EXEC_SCRIPT` |
| `ev[35]` | Touch / Step (0x01) | `X_RANGE(52..64) AND Y_RANGE(86..87) AND PLAYER_FACING(val=0)` | `MAP_EXIT_DIR -> CHANGE_WEATHER -> OBJ_MOVE_TILE -> WAIT -> SLEEP -> MOVE_SPEED -> MOVE_DIR -> OBJ_FACING -> END_TOKEN_FF -> WAIT -> END_TOKEN_FF -> SLEEP -> WARP_TOWN(3, 2) -> EXEC_SCRIPT -> Op119` |
| `ev[36]` | Touch / Step (0x01) | `X_RANGE(50..66) AND Y_RANGE(18..21) AND PLAYER_FACING(val=1)` | `WARP_TOWN(3, 0) -> FACE_PLAYER(obj=97)` |
| `ev[37]` | Touch / Step (0x01) | `X_RANGE(74..78) AND Y_RANGE(32..33) AND PLAYER_FACING(val=0)` | `WARP_SUBMAP(sub=1, x=110, y=35)` |
| `ev[38]` | Action / Talk (0x02) | `FLAG_NOT_SET(fno=144, mask=0x04) AND FLAG_IS_SET(fno=112, mask=0x40) AND CastleLv >= 1` | `WAIT -> PARTY_ADD` |
| `ev[39]` | Action / Talk (0x02) | `FLAG_NOT_SET(fno=144, mask=0x04) AND CastleLv >= 1 AND FLAG_IS_SET(fno=112, mask=0x40)` | `WAIT -> PARTY_REMOVE` |
| `ev[40]` | Action / Talk (0x02) | `FLAG_NOT_SET(fno=144, mask=0x04) AND CastleLv >= 2 AND FLAG_IS_SET(fno=112, mask=0x40)` | `WAIT -> EXEC_SCRIPT` |
| `ev[41]` | Action / Talk (0x02) | `FLAG_NOT_SET(fno=144, mask=0x04) AND CastleLv >= 3 AND FLAG_IS_SET(fno=112, mask=0x40)` | `WAIT -> WARP_ROOM(255, 254)` |
| `ev[42]` | Action / Talk (0x02) | `FLAG_NOT_SET(fno=144, mask=0x04) AND CastleLv >= 4 AND FLAG_IS_SET(fno=112, mask=0x40)` | `WAIT -> WARP_TOWN(255, 254)` |
| `ev[43]` | Touch / Step (0x01) | `TALK_TO(obj[28])` | `EXEC_SCRIPT -> OBJ_FACING -> SLEEP -> WAIT -> OVERLAY_CALL(cat=6, sub=0) -> MOVE_DIR -> PARTY_ADD -> MOVE_DIR` |
| `ev[44]` | Touch / Step (0x01) | `TALK_TO(obj[29])` | `EXEC_SCRIPT -> OBJ_FACING -> SLEEP -> WAIT -> OVERLAY_CALL(cat=6, sub=1)` |
| `ev[45]` | Touch / Step (0x01) | `TALK_TO(obj[30])` | `EXEC_SCRIPT -> OBJ_FACING -> SLEEP -> WAIT -> OVERLAY_CALL(cat=6, sub=2)` |
| `ev[46]` | Touch / Step (0x01) | `TALK_TO(obj[31])` | `EXEC_SCRIPT -> OBJ_FACING -> SLEEP -> WAIT -> OVERLAY_CALL(cat=6, sub=3)` |
| `ev[47]` | Touch / Step (0x01) | `TALK_TO(obj[32])` | `EXEC_SCRIPT -> OBJ_FACING -> SLEEP -> WAIT -> OVERLAY_CALL(cat=6, sub=4)` |
| `ev[48]` | Touch / Step (0x01) | `TALK_TO(obj[21])` | `SHOW_SERIFU(obj=21, msg=4, bank=0)` |
| `ev[49]` | Touch / Step (0x01) | `TALK_TO(obj[22])` | `SHOW_SERIFU(obj=22, msg=4, bank=1)` |
| `ev[50]` | Touch / Step (0x01) | `TALK_TO(obj[23])` | `SHOW_SERIFU(obj=23, msg=4, bank=2)` |
| `ev[51]` | Touch / Step (0x01) | `TALK_TO(obj[24])` | `SHOW_SERIFU(obj=24, msg=4, bank=3)` |
| `ev[52]` | Touch / Step (0x01) | `TALK_TO(obj[25])` | `SHOW_SERIFU(obj=25, msg=4, bank=4)` |
| `ev[53]` | Touch / Step (0x01) | `TALK_TO(obj[26])` | `SHOW_SERIFU(obj=26, msg=4, bank=5)` |
| `ev[54]` | Touch / Step (0x01) | `TALK_TO(obj[27])` | `SHOW_SERIFU(obj=27, msg=4, bank=6)` |

---

## Submap 1 (`vk08_01`): Dunan Castle HQ 2F Tavern Room & Counter
- **Entity Count (`okaz`)**: 47
- **Event Count (`evkaz`)**: 91

### Physical Object Registry (`eventobj`)

| Slot | Character / Sprite (`fpno`) | Tile Coords `(x, y)` | Facing (`ano`) | State (`disp`) | Obstacle (`ozok`) | Speed (`spd`) | Priority (`pri`) |
|:---:|:---|:---:|:---:|:---:|:---:|:---:|:---:|
| `obj[00]` | **Leona** (`fpno: 91`) | `(127, 34)` | South | 0 | 2 | 4 | 0 |
| `obj[01]` | *Invisible Trigger/Collision* | `(125, 32)` | South | 0 | 0 | 4 | 0 |
| `obj[02]` | `fpno: 64826` | `(127, 34)` | South | 0 | 2 | 4 | 0 |
| `obj[03]` | `fpno: 58` | `(137, 57)` | West | 0 | 2 | 4 | 0 |
| `obj[04]` | `fpno: 53306` | `(137, 58)` | South | 0 | 0 | 4 | 0 |
| `obj[05]` | *Invisible Trigger/Collision* | `(136, 55)` | South | 0 | 0 | 4 | 0 |
| `obj[06]` | `fpno: 60` | `(131, 57)` | South | 0 | 2 | 4 | 0 |
| `obj[07]` | `fpno: 53308` | `(131, 58)` | South | 0 | 0 | 4 | 0 |
| `obj[08]` | *Invisible Trigger/Collision* | `(130, 55)` | South | 0 | 0 | 4 | 0 |
| `obj[09]` | `fpno: 59` | `(129, 53)` | East | 0 | 3 | 3 | 0 |
| `obj[10]` | `fpno: 12` | `(133, 37)` | North | 0 | 2 | 4 | 0 |
| `obj[11]` | `fpno: 53287` | `(130, 37)` | South | 0 | 0 | 4 | 0 |
| `obj[12]` | *Invisible Trigger/Collision* | `(129, 34)` | South | 0 | 0 | 4 | 0 |
| `obj[13]` | `fpno: 39` | `(131, 37)` | East | 0 | 2 | 4 | 0 |
| `obj[14]` | `fpno: 53287` | `(133, 37)` | South | 0 | 0 | 4 | 0 |
| `obj[15]` | *Invisible Trigger/Collision* | `(132, 34)` | South | 0 | 0 | 4 | 0 |
| `obj[16]` | `fpno: 3` | `(119, 47)` | South | 0 | 2 | 4 | 0 |
| `obj[17]` | `fpno: 53251` | `(119, 48)` | South | 0 | 0 | 4 | 0 |
| `obj[18]` | *Invisible Trigger/Collision* | `(118, 45)` | South | 0 | 0 | 4 | 0 |
| `obj[19]` | `fpno: 2` | `(125, 47)` | East | 0 | 2 | 4 | 0 |
| `obj[20]` | `fpno: 53250` | `(125, 48)` | South | 0 | 0 | 4 | 0 |
| `obj[21]` | *Invisible Trigger/Collision* | `(124, 45)` | South | 0 | 0 | 4 | 0 |
| `obj[22]` | `fpno: 55` | `(117, 42)` | East | 0 | 3 | 3 | 0 |
| `obj[23]` | `fpno: 20` | `(122, 55)` | West | 0 | 2 | 4 | 0 |
| `obj[24]` | `fpno: 53268` | `(122, 55)` | South | 0 | 32 | 4 | 180 |
| `obj[25]` | *Invisible Trigger/Collision* | `(121, 53)` | South | 0 | 0 | 4 | 0 |
| `obj[26]` | `fpno: 37` | `(131, 47)` | South | 0 | 2 | 4 | 0 |
| `obj[27]` | `fpno: 53285` | `(131, 48)` | South | 0 | 0 | 4 | 0 |
| `obj[28]` | *Invisible Trigger/Collision* | `(130, 45)` | South | 0 | 0 | 4 | 0 |
| `obj[29]` | `fpno: 16` | `(134, 45)` | South | 0 | 2 | 4 | 0 |
| `obj[30]` | `fpno: 53264` | `(134, 45)` | South | 0 | 32 | 4 | 180 |
| `obj[31]` | *Invisible Trigger/Collision* | `(133, 43)` | South | 0 | 0 | 4 | 0 |
| `obj[32]` | `fpno: 10` | `(122, 45)` | North | 0 | 2 | 4 | 0 |
| `obj[33]` | `fpno: 53268` | `(122, 45)` | South | 0 | 32 | 4 | 180 |
| `obj[34]` | *Invisible Trigger/Collision* | `(121, 43)` | South | 0 | 0 | 4 | 0 |
| `obj[35]` | `fpno: 65105` | `(0, 0)` | South | 0 | 2 | 4 | 0 |
| `obj[36]` | `fpno: 37650` | `(0, 0)` | South | 0 | 0 | 4 | 180 |
| `obj[37]` | `fpno: 37650` | `(0, 0)` | South | 0 | 0 | 4 | 180 |
| `obj[38]` | *Invisible Trigger/Collision* | `(106, 34)` | South | 1 | 0 | 4 | 0 |
| `obj[39]` | *Invisible Trigger/Collision* | `(124, 76)` | 35 | 0 | 0 | 4 | 0 |
| `obj[40]` | `fpno: 64826` | `(109, 39)` | South | 0 | 3 | 4 | 0 |
| `obj[41]` | `fpno: 64826` | `(126, 43)` | South | 0 | 3 | 4 | 0 |
| `obj[42]` | `fpno: 64826` | `(122, 37)` | West | 0 | 2 | 4 | 0 |
| `obj[43]` | **Substitute Maid** (`fpno: 65085`) | `(109, 59)` | South | 0 | 3 | 2 | 0 |
| `obj[44]` | `fpno: 64545` | `(122, 55)` | South | 0 | 2 | 4 | 0 |
| `obj[45]` | `fpno: 64551` | `(137, 47)` | North | 0 | 2 | 4 | 0 |
| `obj[46]` | `fpno: 64548` | `(131, 47)` | East | 0 | 2 | 4 | 0 |

### Bytecode Scripts Registry (`eventdat`)

| Script | Trigger Type | Decoded Preconditions (`eventForm`) | Decoded Command Logic (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | Action / Talk (0x02) | `FLAG_IS_SET(fno=112, mask=0x40)` | `WAIT -> FLAG_SET(fno=255, mask=0xFE)` |
| `ev[01]` | Action / Talk (0x02) | `FLAG_IS_SET(fno=134, mask=0x01)` | `WAIT -> FLAG_OFF(fno=255, mask=0xFE)` |
| `ev[02]` | Action / Talk (0x02) | `FLAG_IS_SET(fno=112, mask=0x40) AND FLAG_NOT_SET(fno=134, mask=0x01) AND FLAG_NOT_SET(fno=45, mask=0x08) AND STAR_RECRUITED(chara=91, mask=0x01)` | `WAIT -> RETURN_SUB` |
| `ev[03]` | Action / Talk (0x02) | `FLAG_IS_SET(fno=45, mask=0x08)` | `WAIT -> FLAG_OFF(fno=255, mask=0xFE)` |
| `ev[04]` | Action / Talk (0x02) | `STAR_UNRECRUITED(chara=91, mask=0x01)` | `WAIT -> FLAG_OFF(fno=255, mask=0xFE)` |
| `ev[05]` | Action / Talk (0x02) | `FLAG_IS_SET(fno=172, mask=0x40) AND FLAG_NOT_SET(fno=114, mask=0x08)` | `OVERLAY_PSET -> SLEEP -> RETURN_SUB -> WAIT -> FLAG_OFF(fno=47, mask=0xFF) -> END_TOKEN_FE` |
| `ev[06]` | Action / Talk (0x02) | `STAR_RECRUITED(chara=58, mask=0x01)` | `OVERLAY_PSET -> WAIT -> WARP_SUBMAP(sub=89, x=12, y=2) -> WAIT -> WAIT -> TURN_CHAR -> OVERLAY_PEND` |
| `ev[07]` | Action / Talk (0x02) | `STAR_RECRUITED(chara=60, mask=0x01)` | `OVERLAY_PSET -> WAIT -> CAMERA_MOVE -> OBJ_DISP_ON(obj=15) -> MOVE_SPEED -> WAIT -> WAIT -> FADE_OUT -> OVERLAY_PEND` |
| `ev[08]` | Action / Talk (0x02) | `FLAG_NOT_SET(fno=48, mask=0x01) AND STAR_RECRUITED(chara=12, mask=0x01) AND CastleLv <= 2` | `OVERLAY_PSET -> WAIT -> HON_FLAG_OFF -> OBJ_DISP_ON(obj=19) -> MOVE_SPEED -> CALL_SUB -> WAIT -> TALK_TEXT -> OVERLAY_PEND` |
| `ev[09]` | Action / Talk (0x02) | `FLAG_NOT_SET(fno=48, mask=0x01) AND STAR_RECRUITED(chara=12, mask=0x01) AND CastleLv >= 3 AND SEC_FLAG_CLEAR(fno=19, mask=0x04)` | `OVERLAY_PSET -> WAIT -> HON_FLAG_OFF -> OBJ_DISP_ON(obj=19) -> MOVE_SPEED -> CALL_SUB -> WAIT -> TALK_TEXT -> OVERLAY_PEND` |
| `ev[10]` | Action / Talk (0x02) | `FLAG_IS_SET(fno=112, mask=0x40) AND STAR_RECRUITED(chara=39, mask=0x01) AND CastleLv <= 2` | `OVERLAY_PSET -> WAIT -> PLAY_BGM -> OBJ_DISP_ON(obj=22) -> MOVE_SPEED -> WAIT -> WAIT -> OVERLAY_CALL(cat=47, sub=255) -> END_TOKEN_FE` |
| `ev[11]` | Action / Talk (0x02) | `FLAG_IS_SET(fno=112, mask=0x40) AND STAR_RECRUITED(chara=39, mask=0x01) AND CastleLv >= 3 AND SEC_FLAG_CLEAR(fno=19, mask=0x20)` | `OVERLAY_PSET -> WAIT -> PLAY_BGM -> OBJ_DISP_ON(obj=22) -> MOVE_SPEED -> WAIT -> WAIT -> OVERLAY_CALL(cat=47, sub=255) -> END_TOKEN_FE` |
| `ev[12]` | Action / Talk (0x02) | `STAR_RECRUITED(chara=59, mask=0x01) AND CastleLv == 1` | `WAIT -> FADE_IN` |
| `ev[13]` | Action / Talk (0x02) | `STAR_RECRUITED(chara=59, mask=0x01) AND SEC_FLAG_CLEAR(fno=3, mask=0x20)` | `WAIT -> FADE_IN` |
| `ev[14]` | Action / Talk (0x02) | `FLAG_IS_SET(fno=112, mask=0x40) AND FLAG_NOT_SET(fno=46, mask=0x01) AND STAR_RECRUITED(chara=3, mask=0x01) AND SEC_FLAG_SET(fno=1, mask=0x02)` | `OVERLAY_PSET -> WAIT -> SE_PLAY -> OBJ_DISP_ON(obj=25) -> MOVE_SPEED -> WAIT -> WAIT -> SE_STOP -> OVERLAY_PEND` |
| `ev[15]` | Action / Talk (0x02) | `FLAG_IS_SET(fno=112, mask=0x40) AND FLAG_NOT_SET(fno=45, mask=0x01) AND STAR_RECRUITED(chara=2, mask=0x01) AND SEC_FLAG_SET(fno=0, mask=0x02)` | `OVERLAY_PSET -> WAIT -> PARTY_ADD -> OBJ_DISP_ON(obj=28) -> MOVE_SPEED -> WAIT -> WAIT -> PARTY_REMOVE -> OVERLAY_PEND` |
| `ev[16]` | Action / Talk (0x02) | `FLAG_NOT_SET(fno=144, mask=0x04) AND STAR_RECRUITED(chara=55, mask=0x01) AND SEC_FLAG_SET(fno=5, mask=0x02)` | `WAIT -> EXEC_SCRIPT` |
| `ev[17]` | Action / Talk (0x02) | `FLAG_IS_SET(fno=112, mask=0x40) AND FLAG_NOT_SET(fno=45, mask=0x40) AND STAR_RECRUITED(chara=20, mask=0x01) AND SEC_FLAG_SET(fno=7, mask=0x01)` | `OVERLAY_PSET -> WAIT -> WARP_TOWN(89, 32) -> MOVE_SPEED -> WAIT -> WAIT -> SCREEN_SHAKE -> OVERLAY_PEND` |
| `ev[18]` | Action / Talk (0x02) | `STAR_RECRUITED(chara=37, mask=0x01) AND SEC_FLAG_SET(fno=18, mask=0x02)` | `OVERLAY_PSET -> WAIT -> EXIT_WORLD_MAP -> OBJ_DISP_ON(obj=35) -> MOVE_SPEED -> WAIT -> WAIT -> START_WAR_BATTLE` |
| `ev[19]` | Action / Talk (0x02) | `FLAG_IS_SET(fno=112, mask=0x40) AND STAR_RECRUITED(chara=16, mask=0x01) AND SEC_FLAG_SET(fno=6, mask=0x02)` | `OVERLAY_PSET -> WAIT -> DISABLE_RANDOM_ENC -> OBJ_DISP_ON(obj=38) -> MOVE_SPEED -> MOVE_DIR -> WAIT -> OPEN_SAVE_MENU -> OVERLAY_PEND` |
| `ev[20]` | Action / Talk (0x02) | `STAR_RECRUITED(chara=10, mask=0x01) AND SEC_FLAG_SET(fno=17, mask=0x20)` | `OVERLAY_PSET -> WAIT -> CHANGE_WEATHER -> OBJ_DISP_ON(obj=41) -> MOVE_SPEED -> CALL_SUB -> WAIT -> Op42 -> OVERLAY_PEND` |
| `ev[21]` | Action / Talk (0x02) | `FLAG_IS_SET(fno=112, mask=0x40) AND FLAG_NOT_SET(fno=144, mask=0x04) AND STAR_RECRUITED(chara=91, mask=0x01) AND CastleLv >= 1` | `WAIT -> FACE_PLAYER(obj=255) -> END_TOKEN_FE` |
| `ev[22]` | Action / Talk (0x02) | `FLAG_IS_SET(fno=112, mask=0x40) AND FLAG_NOT_SET(fno=144, mask=0x04) AND CastleLv >= 2` | `WAIT -> LOCK_PLAYER` |
| `ev[23]` | Action / Talk (0x02) | `FLAG_IS_SET(fno=112, mask=0x40) AND FLAG_NOT_SET(fno=144, mask=0x04) AND CastleLv >= 3` | `WAIT -> UNLOCK_PLAYER` |
| `ev[24]` | Action / Talk (0x02) | `FLAG_NOT_SET(fno=144, mask=0x04) AND CastleLv >= 2 AND FLAG_IS_SET(fno=112, mask=0x40)` | `WAIT -> Op51` |
| `ev[25]` | Action / Talk (0x02) | `FLAG_NOT_SET(fno=144, mask=0x04) AND FLAG_IS_SET(fno=45, mask=0x40) AND CastleLv >= 1 AND FLAG_IS_SET(fno=112, mask=0x40)` | `WAIT -> Op52` |
| `ev[26]` | Action / Talk (0x02) | `FLAG_NOT_SET(fno=144, mask=0x04) AND CastleLv >= 3 AND FLAG_IS_SET(fno=112, mask=0x40)` | `WAIT -> Op53` |
| `ev[27]` | Action / Talk (0x02) | `SEC_FLAG_CLEAR(fno=18, mask=0x02) AND FLAG_NOT_SET(fno=144, mask=0x04) AND CastleLv >= 3 AND FLAG_IS_SET(fno=112, mask=0x40)` | `WAIT -> Op54` |
| `ev[28]` | Action / Talk (0x02) | `STAR_RECRUITED(chara=94, mask=0x02)` | `OVERLAY_PSET -> SET_OBJ_SPEED -> WAIT -> OVERLAY_PEND -> MOVE_SPEED -> WAIT -> OVERLAY_PEND -> OVERLAY_PEND` |
| `ev[29]` | Action / Talk (0x02) | `FLAG_IS_SET(fno=111, mask=0x80) AND FLAG_NOT_SET(fno=112, mask=0x01)` | `OVERLAY_PSET -> WAIT -> SE_PLAY -> OBJ_DISP_ON(obj=25) -> MOVE_SPEED -> WAIT -> WAIT -> SE_STOP -> SLEEP -> WARP_SUBMAP(sub=1, x=13, y=1) -> CAMERA_MOVE -> SLEEP -> FADE_OUT -> SLEEP -> HON_FLAG_OFF -> SLEEP -> TALK_TEXT -> SLEEP -> PLAY_BGM -> SLEEP -> OVERLAY_CALL(cat=1, sub=17) -> SLEEP -> PARTY_ADD -> SLEEP -> PARTY_REMOVE -> SLEEP -> EXEC_SCRIPT -> SLEEP -> WARP_TOWN(1, 33) -> SLEEP -> EXIT_WORLD_MAP -> SLEEP -> START_WAR_BATTLE -> SLEEP -> DISABLE_RANDOM_ENC -> SLEEP -> OPEN_SAVE_MENU -> SLEEP -> CHANGE_WEATHER -> SLEEP -> Op42 -> OVERLAY_PEND` |
| `ev[30]` | Touch / Step (0x01) | `FLAG_IS_SET(fno=111, mask=0x80) AND FLAG_NOT_SET(fno=112, mask=0x01) AND FLAG_NOT_SET(fno=112, mask=0x04) AND TALK_TO(obj[26])` | `RECRUIT_CHAR -> WAIT -> Op120 -> UNLOCK_PLAYER -> FLAG_SET(fno=89, mask=0x19) -> MOVE_SPEED -> MOVE_DIR -> MOVE_DIR -> WAIT -> SLEEP -> SCREEN_SHAKE -> SLEEP -> HON_FLAG_SET -> WAIT -> SLEEP -> OBJ_MOVE_TILE -> SLEEP -> OBJ_FACING -> OBJ_MOVE_TILE -> MOVE_SPEED -> MOVE_SPEED -> SLEEP -> WAIT -> EXEC_SCRIPT -> SHOW_SERIFU(obj=24, msg=0, bank=43) -> SHOW_SERIFU(obj=1, msg=0, bank=44) -> SHOW_SERIFU(obj=24, msg=0, bank=45) -> WAIT(20 frames) -> SET_LIGHTING -> WAIT -> WAIT -> MOVE_SPEED -> WAIT -> OVERLAY_PSET -> WAIT -> OVERLAY_PEND -> CHANGE_WEATHER -> MOVE_SPEED -> WAIT -> SLEEP -> END_TOKEN_FF -> WAIT -> SHOW_SERIFU(obj=24, msg=0, bank=51) -> WAIT(60 frames) -> OBJ_DISP_ON(obj=25) -> MOVE_SPEED -> SLEEP -> WAIT(60 frames) -> SHOW_SERIFU(obj=24, msg=3, bank=0) -> START_WAR_BATTLE -> SLEEP -> Op69 -> SLEEP -> SET_OBJ_POS(obj=9, x=9, y=11) -> MOVE_SPEED -> OVERLAY_CALL(cat=120, sub=105) -> WAIT -> WAIT -> Op110 -> SET_OBJ_POS(obj=1, x=0, y=102) -> SLEEP -> SHOW_SERIFU(obj=24, msg=3, bank=1) -> OPEN_SAVE_MENU -> Op34 -> Op69 -> MOVE_SPEED -> TURN_CHAR -> OBJ_MOVE_TILE -> WAIT -> CHAR_ANIME -> Op250 -> WAIT -> WAIT` |
| `ev[31]` | MapInit (0x80) | `FLAG_IS_SET(fno=111, mask=0x80) AND FLAG_NOT_SET(fno=112, mask=0x01) AND FLAG_NOT_SET(fno=112, mask=0x04) AND CHAR_STATE(val=1)` | `Op44 -> LOCK_PLAYER -> MOVE_SPEED -> OBJ_FACING -> WAIT -> Op125 -> LOCK_PLAYER -> FLAG_SET(fno=3, mask=0x00) -> MOVE_SPEED` |
| `ev[32]` | Touch / Step (0x01) | `FLAG_IS_SET(fno=112, mask=0x04) AND FLAG_NOT_SET(fno=112, mask=0x01) AND TALK_TO(obj[26])` | `RECRUIT_CHAR -> WAIT -> Op120 -> UNLOCK_PLAYER -> FLAG_SET(fno=89, mask=0x19) -> MOVE_SPEED -> MOVE_DIR -> MOVE_DIR -> WAIT -> SLEEP -> SCREEN_SHAKE -> SLEEP -> HON_FLAG_SET -> WAIT -> SLEEP -> OBJ_MOVE_TILE -> SLEEP -> OBJ_FACING -> OBJ_MOVE_TILE -> MOVE_SPEED -> MOVE_SPEED -> SLEEP -> WAIT -> EXEC_SCRIPT -> SHOW_SERIFU(obj=24, msg=0, bank=50) -> WAIT(20 frames) -> SET_LIGHTING -> WAIT -> WAIT -> MOVE_SPEED -> WAIT -> OVERLAY_PSET -> WAIT -> OVERLAY_PEND -> CHANGE_WEATHER -> MOVE_SPEED -> WAIT -> SLEEP -> END_TOKEN_FF -> WAIT -> SHOW_SERIFU(obj=24, msg=0, bank=51) -> WAIT(60 frames) -> OBJ_DISP_ON(obj=25) -> MOVE_SPEED -> SLEEP -> WAIT(60 frames) -> SHOW_SERIFU(obj=24, msg=3, bank=0) -> START_WAR_BATTLE -> SLEEP -> Op69 -> SLEEP -> SET_OBJ_POS(obj=9, x=9, y=11) -> MOVE_SPEED -> OVERLAY_CALL(cat=120, sub=105) -> WAIT -> WAIT -> Op110 -> SET_OBJ_POS(obj=1, x=0, y=102) -> SLEEP -> SHOW_SERIFU(obj=24, msg=3, bank=1) -> OPEN_SAVE_MENU -> Op34 -> Op69 -> MOVE_SPEED -> TURN_CHAR -> OBJ_MOVE_TILE -> WAIT -> CHAR_ANIME -> Op250 -> WAIT -> WAIT` |
| `ev[33]` | MapInit (0x80) | `FLAG_IS_SET(fno=112, mask=0x04) AND FLAG_NOT_SET(fno=112, mask=0x01) AND CHAR_STATE(val=1)` | `Op44 -> LOCK_PLAYER -> MOVE_SPEED -> OBJ_FACING -> WAIT -> Op125 -> LOCK_PLAYER -> FLAG_SET(fno=3, mask=0x00) -> MOVE_SPEED` |
| `ev[34]` | Action / Talk (0x02) | `FLAG_IS_SET(fno=112, mask=0x08) AND FLAG_NOT_SET(fno=112, mask=0x01)` | `OVERLAY_PSET -> DISMISS_ALL_PARTY -> SLEEP -> HON_FLAG_SET -> MOVE_SPEED -> SLEEP -> HIDE_PORTRAIT -> OVERLAY_PEND -> MOVE_DIR -> SLEEP -> SLEEP -> WAIT -> SLEEP -> MOVE_SPEED -> WAIT -> Op125 -> FACE_PLAYER(obj=106) -> WAIT -> Op45 -> OBJ_DISP_ON(obj=45) -> MOVE_SPEED -> WAIT -> WAIT -> Op45 -> SLEEP -> WAIT -> MOVE_SPEED -> Op44 -> HIDE_PORTRAIT -> Op45 -> OBJ_DISP_ON(obj=44) -> MOVE_SPEED -> OBJ_FACING -> WAIT -> Op44 -> WAIT -> SE_PLAY -> OBJ_DISP_ON(obj=25) -> MOVE_SPEED -> SLEEP -> WAIT -> SE_STOP -> SLEEP -> WARP_SUBMAP(sub=1, x=13, y=1) -> CAMERA_MOVE -> SLEEP -> FADE_OUT -> SLEEP -> HON_FLAG_OFF -> SLEEP -> TALK_TEXT -> SLEEP -> PLAY_BGM -> SLEEP -> OVERLAY_CALL(cat=1, sub=17) -> SLEEP -> PARTY_ADD -> SLEEP -> PARTY_REMOVE -> SLEEP -> EXEC_SCRIPT -> SLEEP -> WARP_TOWN(1, 33) -> SLEEP -> EXIT_WORLD_MAP -> SLEEP -> START_WAR_BATTLE -> SLEEP -> DISABLE_RANDOM_ENC -> SLEEP -> OPEN_SAVE_MENU -> SLEEP -> CHANGE_WEATHER -> SLEEP -> Op42 -> OVERLAY_PEND` |
| `ev[35]` | Touch / Step (0x01) | `FLAG_IS_SET(fno=112, mask=0x08) AND FLAG_NOT_SET(fno=112, mask=0x04) AND FLAG_NOT_SET(fno=112, mask=0x01)` | `SET_OBJ_POS(obj=9, x=9, y=105) -> WAIT -> WAIT -> RESET_FLAGS -> SET_OBJ_POS(obj=1, x=3, y=11) -> SLEEP -> MOVE_SPEED -> Op120 -> Op72 -> SLEEP -> SLEEP -> RETURN_SUB -> SHOW_SERIFU(obj=24, msg=0, bank=52) -> SHOW_SERIFU(obj=1, msg=0, bank=53) -> START_WAR_BATTLE -> Op128 -> SHOW_SERIFU(obj=24, msg=0, bank=55) -> Op54 -> WAIT -> Op128 -> WAIT(30 frames) -> OBJ_DISP_ON(obj=25) -> MOVE_SPEED -> WAIT -> OBJ_DISP_ON(obj=45) -> MOVE_SPEED -> MOVE_DIR -> SHOW_SERIFU(obj=24, msg=0, bank=56) -> WAIT(20 frames) -> SET_OBJ_POS(obj=9, x=8, y=11) -> MOVE_SPEED -> MOVE_SPEED -> Op120 -> FLAG_SET(fno=112, mask=0x01) -> Op72 -> WAIT -> SLEEP -> FLAG_OFF(fno=144, mask=0x01) -> FLAG_OFF(fno=144, mask=0x04) -> Op69 -> SLEEP -> TURN_CHAR -> OBJ_MOVE_TILE -> FLAG_OFF(fno=6, mask=0x03) -> Op52 -> Op52` |
| `ev[36]` | Touch / Step (0x01) | `FLAG_IS_SET(fno=112, mask=0x08) AND FLAG_IS_SET(fno=112, mask=0x04) AND FLAG_NOT_SET(fno=112, mask=0x01)` | `SET_OBJ_POS(obj=9, x=9, y=105) -> WAIT -> WAIT -> RESET_FLAGS -> SET_OBJ_POS(obj=1, x=3, y=11) -> SLEEP -> MOVE_SPEED -> Op120 -> Op72 -> SLEEP -> SLEEP -> RETURN_SUB -> SHOW_SERIFU(obj=24, msg=0, bank=52) -> SHOW_SERIFU(obj=1, msg=0, bank=53) -> START_WAR_BATTLE -> Op128 -> SHOW_SERIFU(obj=24, msg=0, bank=54) -> Op54 -> WAIT -> Op128 -> WAIT(30 frames) -> OBJ_DISP_ON(obj=25) -> MOVE_SPEED -> SLEEP -> SHOW_SERIFU(obj=24, msg=0, bank=56) -> OBJ_DISP_ON(obj=45) -> MOVE_SPEED -> MOVE_DIR -> WAIT(20 frames) -> SET_OBJ_POS(obj=9, x=8, y=11) -> MOVE_SPEED -> MOVE_SPEED -> Op120 -> Op72 -> WAIT -> SLEEP -> FLAG_SET(fno=112, mask=0x01) -> FLAG_OFF(fno=144, mask=0x01) -> FLAG_OFF(fno=144, mask=0x04) -> Op69 -> SLEEP -> TURN_CHAR -> OBJ_MOVE_TILE -> FLAG_OFF(fno=6, mask=0x03) -> Op52 -> Op52` |
| `ev[37]` | MapInit (0x80) | `FLAG_IS_SET(fno=112, mask=0x08) AND FLAG_NOT_SET(fno=112, mask=0x01) AND CHAR_STATE(val=128)` | `OBJ_DISP_ON(obj=25) -> MOVE_SPEED -> MOVE_SPEED -> OBJ_DISP_ON(obj=45) -> MOVE_SPEED -> SLEEP -> OBJ_DISP_ON(obj=45) -> OBJ_MOVE_TILE -> OBJ_DISP_ON(obj=45) -> OBJ_MOVE_TILE -> OBJ_DISP_ON(obj=45) -> MOVE_SPEED -> MOVE_SPEED -> START_BOSS_BATTLE -> Op128` |
| `ev[38]` | Touch / Step (0x01) | `FLAG_IS_SET(fno=134, mask=0x01) AND TALK_TO(obj[9])` | `SHOW_SERIFU(obj=10, msg=15, bank=3)` |
| `ev[39]` | Touch / Step (0x01) | `FLAG_IS_SET(fno=172, mask=0x40) AND FLAG_NOT_SET(fno=114, mask=0x08) AND TALK_TO(obj[9])` | `SHOW_SERIFU(obj=10, msg=15, bank=3)` |
| `ev[40]` | Touch / Step (0x01) | `STAR_RECRUITED(chara=91, mask=0x01) AND TALK_TO(obj[9])` | `RECRUIT_CHAR -> WAIT -> Op127 -> START_BOSS_BATTLE -> RETURN_SUB -> MOVE_DIR -> WAIT -> SLEEP -> DISABLE_INPUT -> FADE_OUT -> RETURN_SUB -> EXEC_SCRIPT -> MOVE_DIR -> SLEEP -> WAIT -> SHOW_SERIFU(obj=8, msg=1, bank=11) -> WAIT(20 frames) -> Op127 -> WAIT -> FADE_OUT -> RETURN_SUB -> Op70 -> WAIT -> WAIT -> Op69 -> MOVE_DIR -> SET_POS -> MOVE_SPEED -> MOVE_SPEED -> Op60 -> WARP_SUBMAP(sub=1, x=127, y=37)` |
| `ev[41]` | Touch / Step (0x01) | `STAR_UNRECRUITED(chara=91, mask=0x01) AND TALK_TO(obj[9])` | `RECRUIT_CHAR -> WAIT -> Op127 -> START_BOSS_BATTLE -> RETURN_SUB -> MOVE_DIR -> WAIT -> SLEEP -> DISABLE_INPUT -> FADE_OUT -> RETURN_SUB -> EXEC_SCRIPT -> OBJ_FACING -> SLEEP -> WAIT -> SHOW_SERIFU(obj=10, msg=6, bank=5) -> WAIT(20 frames) -> Op127 -> WAIT -> FADE_OUT -> RETURN_SUB -> Op70 -> WAIT -> WAIT -> Op69 -> MOVE_DIR -> SET_POS -> MOVE_SPEED -> MOVE_SPEED -> Op60 -> WARP_SUBMAP(sub=1, x=127, y=37)` |
| `ev[42]` | MapInit (0x80) | `HON_FLAG_SET(fno=16, mask=0x08)` | `WARP_ROOM(0, 13) -> PARTY_REMOVE -> ENABLE_INPUT -> FADE_OUT -> RETURN_SUB` |
| `ev[43]` | Action / Talk (0x02) | `X_RANGE(127..128) AND Y_RANGE(37..38)` | `SET_POS -> SLEEP -> MOVE_SPEED -> Op60` |
| `ev[44]` | Touch / Step (0x01) | `X_RANGE(138..139) AND TALK_TO(obj[13])` | `OBJ_DISP_ON(obj=12) -> MOVE_SPEED -> OBJ_FACING -> EXEC_SCRIPT -> MOVE_DIR -> SLEEP -> WAIT -> SHOW_SERIFU(obj=11, msg=1, bank=12) -> OBJ_DISP_ON(obj=12) -> MOVE_SPEED -> WAIT` |
| `ev[45]` | Touch / Step (0x01) | `Y_RANGE(55..56) AND TALK_TO(obj[13])` | `OBJ_DISP_ON(obj=12) -> MOVE_SPEED -> MOVE_SPEED -> EXEC_SCRIPT -> MOVE_DIR -> SLEEP -> WAIT -> SHOW_SERIFU(obj=11, msg=1, bank=12) -> OBJ_DISP_ON(obj=12) -> MOVE_SPEED -> WAIT` |
| `ev[46]` | Touch / Step (0x01) | `Y_RANGE(57..59) AND TALK_TO(obj[13])` | `OBJ_DISP_ON(obj=12) -> MOVE_SPEED -> MOVE_DIR -> EXEC_SCRIPT -> MOVE_DIR -> SLEEP -> WAIT -> SHOW_SERIFU(obj=11, msg=1, bank=12) -> OBJ_DISP_ON(obj=12) -> MOVE_SPEED -> WAIT` |
| `ev[47]` | Touch / Step (0x01) | `X_RANGE(128..129) AND TALK_TO(obj[16])` | `OBJ_DISP_ON(obj=15) -> MOVE_SPEED -> OBJ_MOVE_TILE -> EXEC_SCRIPT -> MOVE_DIR -> SLEEP -> WAIT -> SHOW_SERIFU(obj=14, msg=1, bank=13) -> OBJ_DISP_ON(obj=15) -> MOVE_SPEED -> WAIT` |
| `ev[48]` | Touch / Step (0x01) | `Y_RANGE(55..56) AND TALK_TO(obj[16])` | `OBJ_DISP_ON(obj=15) -> MOVE_SPEED -> MOVE_DIR -> EXEC_SCRIPT -> MOVE_DIR -> SLEEP -> WAIT -> SHOW_SERIFU(obj=14, msg=1, bank=13) -> OBJ_DISP_ON(obj=15) -> MOVE_SPEED -> WAIT` |
| `ev[49]` | Touch / Step (0x01) | `Y_RANGE(57..59) AND TALK_TO(obj[16])` | `OBJ_DISP_ON(obj=15) -> MOVE_SPEED -> OBJ_FACING -> EXEC_SCRIPT -> MOVE_DIR -> SLEEP -> WAIT -> SHOW_SERIFU(obj=14, msg=1, bank=13) -> OBJ_DISP_ON(obj=15) -> MOVE_SPEED -> WAIT` |
| `ev[50]` | Touch / Step (0x01) | `X_RANGE(127..128) AND TALK_TO(obj[20])` | `OBJ_DISP_ON(obj=19) -> MOVE_SPEED -> SET_POS -> EXEC_SCRIPT -> MOVE_DIR -> SLEEP -> WAIT -> CHANGE_WEATHER -> OBJ_JUMP -> TURN_CHAR -> WAIT -> SLEEP -> MOVE_SPEED -> MOVE_DIR -> OBJ_FACING -> END_TOKEN_FF -> MOVE_SPEED -> SHOW_SERIFU(obj=18, msg=9, bank=15) -> Op51 -> OBJ_JUMP -> END_TOKEN_FF -> SLEEP -> SHOW_SERIFU(obj=18, msg=8, bank=15) -> Op51 -> OBJ_JUMP -> END_TOKEN_FF -> TURN_CHAR -> END_TOKEN_FF -> WAIT -> END_TOKEN_FF -> MOVE_DIR -> END_TOKEN_FF -> OBJ_FACING -> EXEC_SCRIPT -> OBJ_MOVE_TILE -> SLEEP -> OPEN_SAVE_MENU -> CHANGE_WEATHER -> MOVE_SPEED -> CALL_SUB -> RETURN_SUB -> END_TOKEN_FF -> CALL_SUB -> SHOW_SERIFU(obj=18, msg=11, bank=15) -> Op51 -> OBJ_JUMP -> END_TOKEN_FF -> RETURN_SUB -> SHOW_SERIFU(obj=18, msg=1, bank=15) -> END_TOKEN_FF -> OBJ_JUMP -> OBJ_DISP_ON(obj=19) -> MOVE_SPEED -> CALL_SUB` |
| `ev[51]` | Touch / Step (0x01) | `Y_RANGE(38..39) AND TALK_TO(obj[20])` | `OBJ_DISP_ON(obj=19) -> MOVE_SPEED -> FLAG_OFF(fno=30, mask=0x03) -> SLEEP -> WAIT -> CHANGE_WEATHER -> OBJ_JUMP -> TURN_CHAR -> WAIT -> SLEEP -> MOVE_SPEED -> MOVE_DIR -> OBJ_FACING -> END_TOKEN_FF -> MOVE_SPEED -> SHOW_SERIFU(obj=18, msg=9, bank=15) -> Op51 -> OBJ_JUMP -> END_TOKEN_FF -> SLEEP -> SHOW_SERIFU(obj=18, msg=8, bank=15) -> Op51 -> OBJ_JUMP -> END_TOKEN_FF -> TURN_CHAR -> END_TOKEN_FF -> WAIT -> END_TOKEN_FF -> MOVE_DIR -> END_TOKEN_FF -> OBJ_FACING -> EXEC_SCRIPT -> OBJ_MOVE_TILE -> SLEEP -> OPEN_SAVE_MENU -> CHANGE_WEATHER -> MOVE_SPEED -> CALL_SUB -> RETURN_SUB -> END_TOKEN_FF -> CALL_SUB -> SHOW_SERIFU(obj=18, msg=11, bank=15) -> Op51 -> OBJ_JUMP -> END_TOKEN_FF -> RETURN_SUB -> SHOW_SERIFU(obj=18, msg=1, bank=15) -> END_TOKEN_FF -> OBJ_JUMP -> OBJ_DISP_ON(obj=19) -> MOVE_SPEED -> CALL_SUB` |
| `ev[52]` | Touch / Step (0x01) | `X_RANGE(132..133) AND TALK_TO(obj[20])` | `EXEC_SCRIPT -> MOVE_DIR -> SLEEP -> WAIT -> CHANGE_WEATHER -> OBJ_JUMP -> TURN_CHAR -> WAIT -> SLEEP -> MOVE_SPEED -> MOVE_DIR -> OBJ_FACING -> END_TOKEN_FF -> MOVE_SPEED -> SHOW_SERIFU(obj=18, msg=9, bank=15)` |
| `ev[53]` | Touch / Step (0x01) | `Y_RANGE(38..39) AND TALK_TO(obj[23])` | `OBJ_DISP_ON(obj=22) -> MOVE_SPEED -> OBJ_FACING -> EXEC_SCRIPT -> MOVE_DIR -> SLEEP -> WAIT -> CHANGE_WEATHER -> OBJ_JUMP -> TURN_CHAR -> WAIT -> SLEEP -> MOVE_SPEED -> MOVE_DIR -> OBJ_FACING -> END_TOKEN_FF -> MOVE_SPEED -> SHOW_SERIFU(obj=21, msg=9, bank=17) -> Op51 -> OBJ_JUMP -> END_TOKEN_FF -> SLEEP -> SHOW_SERIFU(obj=21, msg=8, bank=17) -> Op51 -> OBJ_JUMP -> END_TOKEN_FF -> TURN_CHAR -> END_TOKEN_FF -> WAIT -> END_TOKEN_FF -> MOVE_DIR -> END_TOKEN_FF -> OBJ_FACING -> EXEC_SCRIPT -> OBJ_MOVE_TILE -> SLEEP -> WARP_SUBMAP(sub=41, x=2, y=7) -> RETURN_SUB -> END_TOKEN_FF -> CALL_SUB -> SHOW_SERIFU(obj=21, msg=11, bank=17) -> Op51 -> OBJ_JUMP -> END_TOKEN_FF -> RETURN_SUB -> SHOW_SERIFU(obj=21, msg=1, bank=17) -> END_TOKEN_FF -> OBJ_JUMP -> OBJ_DISP_ON(obj=22) -> MOVE_SPEED -> WAIT` |
| `ev[54]` | Touch / Step (0x01) | `X_RANGE(130..132) AND TALK_TO(obj[23])` | `OBJ_DISP_ON(obj=22) -> MOVE_SPEED -> MOVE_DIR -> EXEC_SCRIPT -> MOVE_DIR -> SLEEP -> WAIT -> CHANGE_WEATHER -> OBJ_JUMP -> TURN_CHAR -> WAIT -> SLEEP -> MOVE_SPEED -> MOVE_DIR -> OBJ_FACING -> END_TOKEN_FF -> MOVE_SPEED -> SHOW_SERIFU(obj=21, msg=9, bank=17) -> Op51 -> OBJ_JUMP -> END_TOKEN_FF -> SLEEP -> SHOW_SERIFU(obj=21, msg=8, bank=17) -> Op51 -> OBJ_JUMP -> END_TOKEN_FF -> TURN_CHAR -> END_TOKEN_FF -> WAIT -> END_TOKEN_FF -> MOVE_DIR -> END_TOKEN_FF -> OBJ_FACING -> EXEC_SCRIPT -> OBJ_MOVE_TILE -> SLEEP -> WARP_SUBMAP(sub=41, x=2, y=7) -> RETURN_SUB -> END_TOKEN_FF -> CALL_SUB -> SHOW_SERIFU(obj=21, msg=11, bank=17) -> Op51 -> OBJ_JUMP -> END_TOKEN_FF -> RETURN_SUB -> SHOW_SERIFU(obj=21, msg=1, bank=17) -> END_TOKEN_FF -> OBJ_JUMP -> OBJ_DISP_ON(obj=22) -> MOVE_SPEED -> WAIT` |
| `ev[55]` | Touch / Step (0x01) | `TALK_TO(obj[17])` | `EXEC_SCRIPT -> MOVE_DIR -> SLEEP -> WAIT -> OVERLAY_CALL(cat=1, sub=19)` |
| `ev[56]` | Touch / Step (0x01) | `X_RANGE(115..117) AND TALK_TO(obj[26])` | `OBJ_DISP_ON(obj=25) -> MOVE_SPEED -> OBJ_FACING -> EXEC_SCRIPT -> MOVE_DIR -> SLEEP -> WAIT -> SHOW_SERIFU(obj=24, msg=1, bank=20) -> OBJ_DISP_ON(obj=25) -> MOVE_SPEED -> WAIT` |
| `ev[57]` | Touch / Step (0x01) | `Y_RANGE(43..45) AND TALK_TO(obj[26])` | `OBJ_DISP_ON(obj=25) -> MOVE_SPEED -> MOVE_SPEED -> EXEC_SCRIPT -> MOVE_DIR -> SLEEP -> WAIT -> SHOW_SERIFU(obj=24, msg=1, bank=20) -> OBJ_DISP_ON(obj=25) -> MOVE_SPEED -> WAIT` |
| `ev[58]` | Touch / Step (0x01) | `Y_RANGE(48..50) AND TALK_TO(obj[26])` | `OBJ_DISP_ON(obj=25) -> MOVE_SPEED -> MOVE_DIR -> EXEC_SCRIPT -> MOVE_DIR -> SLEEP -> WAIT -> SHOW_SERIFU(obj=24, msg=1, bank=20) -> OBJ_DISP_ON(obj=25) -> MOVE_SPEED -> WAIT` |
| `ev[59]` | Touch / Step (0x01) | `X_RANGE(127..129) AND TALK_TO(obj[29])` | `OBJ_DISP_ON(obj=28) -> MOVE_SPEED -> OBJ_FACING -> EXEC_SCRIPT -> MOVE_DIR -> SLEEP -> WAIT -> SHOW_SERIFU(obj=27, msg=1, bank=21) -> OBJ_DISP_ON(obj=28) -> MOVE_SPEED -> WAIT` |
| `ev[60]` | Touch / Step (0x01) | `Y_RANGE(43..45) AND TALK_TO(obj[29])` | `OBJ_DISP_ON(obj=28) -> MOVE_SPEED -> MOVE_SPEED -> EXEC_SCRIPT -> MOVE_DIR -> SLEEP -> WAIT -> SHOW_SERIFU(obj=27, msg=1, bank=21) -> OBJ_DISP_ON(obj=28) -> MOVE_SPEED -> WAIT` |
| `ev[61]` | Touch / Step (0x01) | `Y_RANGE(48..50) AND TALK_TO(obj[29])` | `OBJ_DISP_ON(obj=28) -> MOVE_SPEED -> MOVE_DIR -> EXEC_SCRIPT -> MOVE_DIR -> SLEEP -> WAIT -> SHOW_SERIFU(obj=27, msg=1, bank=21) -> OBJ_DISP_ON(obj=28) -> MOVE_SPEED -> WAIT` |
| `ev[62]` | Touch / Step (0x01) | `TALK_TO(obj[30])` | `EXEC_SCRIPT -> MOVE_DIR -> SLEEP -> WAIT -> OVERLAY_CALL(cat=1, sub=22)` |
| `ev[63]` | Touch / Step (0x01) | `X_RANGE(120..122) AND TALK_TO(obj[33])` | `OBJ_DISP_ON(obj=32) -> MOVE_SPEED -> MOVE_DIR -> EXEC_SCRIPT -> MOVE_DIR -> SLEEP -> WAIT -> SHOW_SERIFU(obj=31, msg=1, bank=23) -> OBJ_DISP_ON(obj=32) -> MOVE_SPEED -> WAIT` |
| `ev[64]` | Touch / Step (0x01) | `X_RANGE(122..124) AND TALK_TO(obj[33])` | `OBJ_DISP_ON(obj=32) -> MOVE_SPEED -> OBJ_MOVE_TILE -> EXEC_SCRIPT -> MOVE_DIR -> SLEEP -> WAIT -> SHOW_SERIFU(obj=31, msg=1, bank=23) -> OBJ_DISP_ON(obj=32) -> MOVE_SPEED -> WAIT` |
| `ev[65]` | Touch / Step (0x01) | `Y_RANGE(55..52) AND TALK_TO(obj[33])` | `OBJ_DISP_ON(obj=32) -> MOVE_SPEED -> OBJ_MOVE_TILE -> EXEC_SCRIPT -> MOVE_DIR -> SLEEP -> WAIT -> SHOW_SERIFU(obj=31, msg=1, bank=23) -> OBJ_DISP_ON(obj=32) -> MOVE_SPEED -> WAIT` |
| `ev[66]` | Touch / Step (0x01) | `X_RANGE(128..129) AND TALK_TO(obj[36])` | `OBJ_DISP_ON(obj=35) -> MOVE_SPEED -> OBJ_FACING -> EXEC_SCRIPT -> MOVE_DIR -> SLEEP -> WAIT -> SHOW_SERIFU(obj=34, msg=1, bank=24) -> OBJ_DISP_ON(obj=35) -> MOVE_SPEED -> WAIT` |
| `ev[67]` | Touch / Step (0x01) | `Y_RANGE(45..46) AND TALK_TO(obj[36])` | `OBJ_DISP_ON(obj=35) -> MOVE_SPEED -> MOVE_SPEED -> EXEC_SCRIPT -> MOVE_DIR -> SLEEP -> WAIT -> SHOW_SERIFU(obj=34, msg=1, bank=24) -> OBJ_DISP_ON(obj=35) -> MOVE_SPEED -> WAIT` |
| `ev[68]` | Touch / Step (0x01) | `Y_RANGE(47..49) AND TALK_TO(obj[36])` | `OBJ_DISP_ON(obj=35) -> MOVE_SPEED -> MOVE_DIR -> EXEC_SCRIPT -> MOVE_DIR -> SLEEP -> WAIT -> SHOW_SERIFU(obj=34, msg=1, bank=24) -> OBJ_DISP_ON(obj=35) -> MOVE_SPEED -> WAIT` |
| `ev[69]` | Touch / Step (0x01) | `Y_RANGE(45..42) AND TALK_TO(obj[39])` | `OBJ_DISP_ON(obj=38) -> MOVE_SPEED -> SLEEP -> WAIT(10 frames) -> EXEC_SCRIPT -> MOVE_DIR -> SLEEP -> WAIT -> SHOW_SERIFU(obj=37, msg=1, bank=25) -> OBJ_DISP_ON(obj=38) -> MOVE_SPEED -> MOVE_DIR` |
| `ev[70]` | Touch / Step (0x01) | `X_RANGE(132..134) AND TALK_TO(obj[39])` | `OBJ_DISP_ON(obj=38) -> MOVE_SPEED -> OBJ_FACING -> WAIT(10 frames) -> EXEC_SCRIPT -> MOVE_DIR -> SLEEP -> WAIT -> SHOW_SERIFU(obj=37, msg=1, bank=25) -> OBJ_DISP_ON(obj=38) -> MOVE_SPEED -> MOVE_DIR` |
| `ev[71]` | Touch / Step (0x01) | `X_RANGE(134..136) AND TALK_TO(obj[39])` | `OBJ_DISP_ON(obj=38) -> MOVE_SPEED -> OBJ_JUMP -> WAIT(10 frames) -> EXEC_SCRIPT -> MOVE_DIR -> SLEEP -> WAIT -> SHOW_SERIFU(obj=37, msg=1, bank=25) -> OBJ_DISP_ON(obj=38) -> MOVE_SPEED -> MOVE_DIR` |
| `ev[72]` | Touch / Step (0x01) | `Y_RANGE(45..42) AND TALK_TO(obj[42])` | `OBJ_DISP_ON(obj=41) -> MOVE_SPEED -> FLAG_SET(fno=30, mask=0x03) -> SLEEP -> WAIT -> SHOW_SERIFU(obj=40, msg=1, bank=26) -> OBJ_DISP_ON(obj=41) -> MOVE_SPEED -> CALL_SUB` |
| `ev[73]` | Touch / Step (0x01) | `X_RANGE(120..122) AND TALK_TO(obj[42])` | `OBJ_DISP_ON(obj=41) -> MOVE_SPEED -> FLAG_OFF(fno=30, mask=0x03) -> SLEEP -> WAIT -> SHOW_SERIFU(obj=40, msg=1, bank=26) -> OBJ_DISP_ON(obj=41) -> MOVE_SPEED -> CALL_SUB` |
| `ev[74]` | Touch / Step (0x01) | `X_RANGE(122..124) AND TALK_TO(obj[42])` | `OBJ_DISP_ON(obj=41) -> MOVE_SPEED -> SET_POS -> EXEC_SCRIPT -> MOVE_DIR -> SLEEP -> WAIT -> SHOW_SERIFU(obj=40, msg=1, bank=26) -> OBJ_DISP_ON(obj=41) -> MOVE_SPEED -> CALL_SUB` |
| `ev[75]` | Action / Talk (0x02) | `FLAG_IS_SET(fno=144, mask=0x04)` | `EXEC_SCRIPT -> SLEEP -> MOVE_SPEED -> FADE_OUT -> SET_POS` |
| `ev[76]` | Action / Talk (0x02) | `FLAG_IS_SET(fno=144, mask=0x04)` | `OVERLAY_PSET -> MOVE_SPEED -> SET_WAIT_TIME -> WINDOW_CHOICE -> Op84 -> MOVE_DIR -> SET_WAIT_TIME -> SLEEP -> WAIT -> SET_WAIT_TIME -> OVERLAY_PEND` |
| `ev[77]` | Touch / Step (0x01) | `FLAG_IS_SET(fno=144, mask=0x04) AND X_RANGE(125..135) AND Y_RANGE(82..85)` | `SHOW_SERIFU(obj=43, msg=5, bank=0) -> OBJ_MOVE_TILE -> WAIT -> SLEEP -> MOVE_DIR -> EXEC_SCRIPT` |
| `ev[78]` | MapInit (0x80) | `X_RANGE(106..138) AND Y_RANGE(56..80) AND FLAG_IS_SET(fno=144, mask=0x20)` | `WARP_ROOM(0, 10) -> SCREEN_SHAKE` |
| `ev[79]` | MapInit (0x80) | `X_RANGE(106..138) AND Y_RANGE(56..80) AND FLAG_NOT_SET(fno=144, mask=0x20)` | `WARP_ROOM(0, 10) -> WAIT` |
| `ev[80]` | Touch / Step (0x01) | `X_RANGE(126..134) AND Y_RANGE(84..85) AND PLAYER_FACING(val=0)` | `MAP_EXIT_DIR -> CHANGE_WEATHER -> OBJ_MOVE_TILE -> WAIT -> SLEEP -> MOVE_SPEED -> MOVE_DIR -> OBJ_FACING -> END_TOKEN_FF -> WAIT -> END_TOKEN_FF -> SLEEP -> WARP_TOWN(3, 2) -> OVERLAY_PSET -> Op120` |
| `ev[81]` | Touch / Step (0x01) | `X_RANGE(108..112) AND Y_RANGE(32..33) AND PLAYER_FACING(val=1)` | `WARP_SUBMAP(sub=0, x=76, y=29)` |
| `ev[82]` | Touch / Step (0x01) | `X_RANGE(126..134) AND Y_RANGE(70..71) AND PLAYER_FACING(val=1)` | `WARP_SUBMAP(sub=2, x=130, y=139)` |
| `ev[83]` | Touch / Step (0x01) | `TALK_TO(obj[48])` | `EXEC_SCRIPT -> OBJ_FACING -> SLEEP -> WAIT -> OVERLAY_CALL(cat=6, sub=5)` |
| `ev[84]` | Touch / Step (0x01) | `TALK_TO(obj[49])` | `EXEC_SCRIPT -> OBJ_FACING -> SLEEP -> WAIT -> OVERLAY_CALL(cat=6, sub=6)` |
| `ev[85]` | Touch / Step (0x01) | `TALK_TO(obj[50])` | `EXEC_SCRIPT -> OBJ_FACING -> SLEEP -> WAIT -> OVERLAY_CALL(cat=6, sub=7) -> MOVE_DIR -> UNLOCK_PLAYER -> SLEEP` |
| `ev[86]` | Touch / Step (0x01) | `TALK_TO(obj[51])` | `EXEC_SCRIPT -> OBJ_FACING -> SLEEP -> WAIT -> OVERLAY_CALL(cat=6, sub=8)` |
| `ev[87]` | Touch / Step (0x01) | `TALK_TO(obj[52])` | `EXEC_SCRIPT -> OBJ_FACING -> SLEEP -> WAIT -> OVERLAY_CALL(cat=6, sub=9) -> MOVE_DIR -> Op52 -> WAIT` |
| `ev[88]` | Touch / Step (0x01) | `TALK_TO(obj[53])` | `EXEC_SCRIPT -> OBJ_FACING -> SLEEP -> WAIT -> OVERLAY_CALL(cat=6, sub=10) -> MOVE_DIR -> Op53 -> MOVE_SPEED` |
| `ev[89]` | Touch / Step (0x01) | `TALK_TO(obj[54])` | `EXEC_SCRIPT -> OBJ_FACING -> SLEEP -> WAIT -> OVERLAY_CALL(cat=6, sub=11) -> MOVE_DIR -> Op54 -> MOVE_DIR` |
| `ev[90]` | Touch / Step (0x01) | `TALK_TO(obj[46])` | `SHOW_SERIFU(obj=46, msg=4, bank=7)` |

---

## Submap 2 (`vk08_02`): Kitchen, Storage & Cellar Area
- **Entity Count (`okaz`)**: 23
- **Event Count (`evkaz`)**: 45

### Physical Object Registry (`eventobj`)

| Slot | Character / Sprite (`fpno`) | Tile Coords `(x, y)` | Facing (`ano`) | State (`disp`) | Obstacle (`ozok`) | Speed (`spd`) | Priority (`pri`) |
|:---:|:---|:---:|:---:|:---:|:---:|:---:|:---:|
| `obj[00]` | `fpno: 94` | `(131, 154)` | South | 0 | 2 | 4 | 0 |
| `obj[01]` | *Invisible Trigger/Collision* | `(129, 155)` | South | 0 | 0 | 4 | 0 |
| `obj[02]` | `fpno: 95` | `(97, 154)` | South | 0 | 2 | 4 | 0 |
| `obj[03]` | *Invisible Trigger/Collision* | `(95, 155)` | South | 0 | 0 | 4 | 0 |
| `obj[04]` | `fpno: 64815` | `(124, 117)` | South | 0 | 3 | 3 | 0 |
| `obj[05]` | `fpno: 44` | `(0, 0)` | South | 0 | 0 | 4 | 0 |
| `obj[06]` | `fpno: 64815` | `(0, 0)` | South | 0 | 0 | 4 | 0 |
| `obj[07]` | `fpno: 3` | `(0, 0)` | South | 0 | 0 | 4 | 0 |
| `obj[08]` | `fpno: 2` | `(0, 0)` | South | 0 | 0 | 4 | 0 |
| `obj[09]` | **Leona** (`fpno: 91`) | `(0, 0)` | South | 0 | 0 | 4 | 0 |
| `obj[10]` | *Invisible Trigger/Collision* | `(122, 156)` | 31 | 0 | 0 | 4 | 0 |
| `obj[11]` | *Invisible Trigger/Collision* | `(102, 156)` | 32 | 0 | 0 | 4 | 0 |
| `obj[12]` | *Invisible Trigger/Collision* | `(98, 147)` | South | 1 | 0 | 4 | 0 |
| `obj[13]` | *Invisible Trigger/Collision* | `(134, 151)` | South | 1 | 0 | 4 | 0 |
| `obj[14]` | *Invisible Trigger/Collision* | `(90, 146)` | South | 1 | 0 | 4 | 0 |
| `obj[15]` | *Invisible Trigger/Collision* | `(92, 145)` | South | 1 | 0 | 4 | 0 |
| `obj[16]` | *Invisible Trigger/Collision* | `(93, 147)` | South | 1 | 0 | 4 | 0 |
| `obj[17]` | **Substitute Maid** (`fpno: 65085`) | `(90, 150)` | North | 0 | 2 | 4 | 0 |
| `obj[18]` | `fpno: 65083` | `(133, 159)` | South | 0 | 3 | 3 | 0 |
| `obj[19]` | `fpno: 65048` | `(105, 158)` | South | 0 | 3 | 2 | 0 |
| `obj[20]` | `fpno: 65178` | `(101, 125)` | South | 0 | 3 | 3 | 0 |
| `obj[21]` | `fpno: 65048` | `(130, 115)` | South | 0 | 2 | 4 | 0 |
| `obj[22]` | `fpno: 65205` | `(81, 115)` | North | 0 | 2 | 4 | 0 |

### Bytecode Scripts Registry (`eventdat`)

| Script | Trigger Type | Decoded Preconditions (`eventForm`) | Decoded Command Logic (`eventCom`) |
|:---:|---|---|---|
| `ev[00]` | Action / Talk (0x02) | `FLAG_NOT_SET(fno=144, mask=0x04) AND STAR_RECRUITED(chara=94, mask=0x01)` | `OVERLAY_PSET -> WAIT -> RETURN_SUB -> WAIT -> FLAG_SET(fno=47, mask=0xFF) -> END_TOKEN_FE` |
| `ev[01]` | Action / Talk (0x02) | `FLAG_NOT_SET(fno=144, mask=0x04) AND STAR_RECRUITED(chara=95, mask=0x01)` | `OVERLAY_PSET -> WAIT -> FLAG_OFF(fno=0, mask=0x0B) -> OVERLAY_PEND` |
| `ev[02]` | Action / Talk (0x02) | `FLAG_NOT_SET(fno=144, mask=0x04) AND STAR_RECRUITED(chara=95, mask=0x01) AND STAR_RECRUITED(chara=94, mask=0x01)` | `OVERLAY_PSET -> WAIT -> WARP_SUBMAP(sub=47, x=255, y=254)` |
| `ev[03]` | Action / Talk (0x02) | `FLAG_NOT_SET(fno=144, mask=0x04) AND CastleLv >= 3 AND FLAG_IS_SET(fno=112, mask=0x40)` | `WAIT -> SE_PLAY` |
| `ev[04]` | Action / Talk (0x02) | `STAR_RECRUITED(chara=94, mask=0x02) AND STAR_RECRUITED(chara=95, mask=0x02) AND FLAG_NOT_SET(fno=144, mask=0x04) AND CastleLv >= 2 AND FLAG_IS_SET(fno=112, mask=0x40)` | `WAIT -> SE_STOP` |
| `ev[05]` | Action / Talk (0x02) | `FLAG_NOT_SET(fno=144, mask=0x04) AND CastleLv >= 1 AND FLAG_IS_SET(fno=112, mask=0x40)` | `WAIT -> Op27` |
| `ev[06]` | Action / Talk (0x02) | `FLAG_NOT_SET(fno=144, mask=0x04) AND CastleLv >= 3 AND FLAG_IS_SET(fno=112, mask=0x40)` | `WAIT -> PARTY_ADD` |
| `ev[07]` | Action / Talk (0x02) | `FLAG_NOT_SET(fno=144, mask=0x04) AND CastleLv >= 1 AND FLAG_IS_SET(fno=112, mask=0x40)` | `WAIT -> PARTY_REMOVE` |
| `ev[08]` | Action / Talk (0x02) | `FLAG_NOT_SET(fno=144, mask=0x04) AND CastleLv >= 2 AND FLAG_IS_SET(fno=112, mask=0x40)` | `WAIT -> EXEC_SCRIPT` |
| `ev[09]` | Action / Talk (0x02) | `STAR_RECRUITED(chara=94, mask=0x02)` | `OVERLAY_PSET -> WAIT -> HON_FLAG_SET -> WAIT -> HON_FLAG_OFF -> OVERLAY_PEND` |
| `ev[10]` | Action / Talk (0x02) | `FLAG_NOT_SET(fno=144, mask=0x04) AND FLAG_IS_SET(fno=92, mask=0x40) AND FLAG_NOT_SET(fno=93, mask=0x01)` | `OVERLAY_PSET -> MOVE_SPEED -> TURN_CHAR -> SET_OBJ_POS(obj=159, x=3, y=13) -> MOVE_SPEED -> WAIT -> TURN_CHAR -> MOVE_SPEED -> FLAG_OFF(fno=95, mask=0x9F) -> MOVE_DIR -> FLAG_OFF(fno=3, mask=0x02) -> CHAR_ANIME -> Op129 -> Op158 -> MOVE_DIR -> CHAR_ANIME -> SLEEP -> WAIT -> CHAR_ANIME -> SLEEP -> WARP_SUBMAP(sub=1, x=25, y=1) -> SE_STOP -> SLEEP -> Op27 -> SLEEP -> PARTY_ADD -> SLEEP -> PARTY_REMOVE -> SLEEP -> EXEC_SCRIPT -> OVERLAY_PEND` |
| `ev[11]` | Touch / Step (0x01) | `FLAG_NOT_SET(fno=144, mask=0x04) AND FLAG_IS_SET(fno=92, mask=0x40) AND FLAG_NOT_SET(fno=93, mask=0x01) AND X_RANGE(117..121) AND Y_RANGE(155..157)` | `SHOW_SERIFU(obj=10, msg=2, bank=0) -> OBJ_FACING -> WAIT -> Op119 -> Op159 -> RETURN_SUB -> MOVE_DIR -> WAIT -> MOVE_SPEED -> Op72 -> SLEEP -> WAIT -> MOVE_SPEED -> PARTY_ADD -> MOVE_SPEED -> WARP_ROOM(6, 72) -> WAIT -> WAIT -> OVERLAY_PSET -> MOVE_SPEED -> RETURN_SUB -> Op129 -> Op161 -> MOVE_SPEED -> CAMERA_MOVE -> SHOW_PORTRAIT -> Op157 -> WAIT -> CAMERA_MOVE -> MOVE_SPEED -> FADE_OUT -> HIDE_PORTRAIT -> Op160 -> WAIT -> FADE_OUT -> MOVE_SPEED -> FADE_IN -> Op125 -> Op159 -> WAIT -> FADE_IN -> OVERLAY_PEND -> SHOW_SERIFU(obj=13, msg=2, bank=1) -> SHOW_SERIFU(obj=10, msg=2, bank=2) -> SHOW_SERIFU(obj=13, msg=2, bank=3) -> EXEC_SCRIPT -> WAIT -> OBJ_FACING -> FLAG_OFF(fno=2, mask=0x04) -> SLEEP -> START_WAR_BATTLE -> SLEEP -> OBJ_MOVE_TILE -> TURN_CHAR -> OBJ_FACING -> CALL_SUB -> MOVE_SPEED -> OBJ_FACING -> EXEC_SCRIPT -> WINDOW_CHOICE -> SLEEP -> FLAG_OFF(fno=5, mask=0x0A) -> OBJ_FACING -> OBJ_MOVE_TILE -> CALL_SUB -> OBJ_FACING -> EXEC_SCRIPT -> WINDOW_CHOICE -> WAIT -> FLAG_OFF(fno=24, mask=0x08) -> MOVE_SPEED -> OBJ_MOVE_TILE -> SET_WAIT_TIME -> RETURN_SUB -> OBJ_MOVE_TILE -> SET_WAIT_TIME -> CHAR_ANIME -> OBJ_JUMP -> LOCK_PLAYER -> MOVE_SPEED -> FACE_PLAYER(obj=14) -> FLAG_OFF(fno=3, mask=0x02) -> SLEEP -> SLEEP -> RETURN_SUB -> MOVE_DIR -> CHAR_ANIME -> MOVE_SPEED` |
| `ev[12]` | MapInit (0x80) | `FLAG_NOT_SET(fno=144, mask=0x04) AND FLAG_IS_SET(fno=92, mask=0x40) AND FLAG_NOT_SET(fno=93, mask=0x01) AND CHAR_STATE(val=1)` | `SET_OBJ_POS(obj=4, x=23, y=11) -> OBJ_FACING -> MOVE_SPEED -> MOVE_DIR -> SET_POS -> MOVE_DIR -> MOVE_SPEED -> SET_LIGHTING -> START_BOSS_BATTLE -> SLEEP` |
| `ev[13]` | MapInit (0x80) | `FLAG_NOT_SET(fno=144, mask=0x04) AND FLAG_IS_SET(fno=92, mask=0x40) AND FLAG_NOT_SET(fno=93, mask=0x01) AND CHAR_STATE(val=2)` | `OBJ_FACING -> TURN_CHAR -> Op118 -> Op158 -> RETURN_SUB -> SLEEP -> TURN_CHAR -> START_BOSS_BATTLE -> MOVE_SPEED` |
| `ev[14]` | Touch / Step (0x01) | `STAR_RECRUITED(chara=94, mask=0x01) AND FLAG_IS_SET(fno=144, mask=0x01) AND HON_FLAG_SET(fno=14, mask=0x02) AND TALK_TO(obj[8])` | `Op96 -> CAMERA_MOVE -> RETURN_SUB -> Op240 -> Op240 -> MOVE_SPEED -> OVERLAY_CALL(cat=2, sub=10) -> SLEEP` |
| `ev[15]` | Touch / Step (0x01) | `STAR_RECRUITED(chara=94, mask=0x01) AND FLAG_IS_SET(fno=144, mask=0x01) AND HON_FLAG_SET(fno=14, mask=0x02) AND TALK_TO(obj[9])` | `MOVE_DIR -> RETURN_SUB -> WAIT -> Op96 -> CAMERA_MOVE -> RETURN_SUB -> Op240 -> Op240 -> MOVE_SPEED -> OVERLAY_CALL(cat=2, sub=10) -> SLEEP` |
| `ev[16]` | Touch / Step (0x01) | `STAR_RECRUITED(chara=94, mask=0x01) AND FLAG_NOT_SET(fno=144, mask=0x01) AND HON_FLAG_SET(fno=14, mask=0x02) AND TALK_TO(obj[8])` | `Op96 -> CAMERA_MOVE -> RETURN_SUB -> Op240 -> Op240 -> MOVE_SPEED -> OVERLAY_CALL(cat=2, sub=10) -> WAIT` |
| `ev[17]` | Touch / Step (0x01) | `STAR_RECRUITED(chara=94, mask=0x01) AND FLAG_NOT_SET(fno=144, mask=0x01) AND HON_FLAG_SET(fno=14, mask=0x02) AND TALK_TO(obj[9])` | `MOVE_DIR -> RETURN_SUB -> WAIT -> Op96 -> CAMERA_MOVE -> RETURN_SUB -> Op240 -> Op240 -> MOVE_SPEED -> OVERLAY_CALL(cat=2, sub=10) -> WAIT` |
| `ev[18]` | Touch / Step (0x01) | `STAR_RECRUITED(chara=94, mask=0x01) AND FLAG_IS_SET(fno=144, mask=0x01) AND TALK_TO(obj[8])` | `EXEC_SCRIPT -> MOVE_DIR -> SLEEP -> WAIT -> Op96 -> CAMERA_MOVE -> RETURN_SUB -> Op240 -> Op240 -> SLEEP -> Op27 -> MOVE_SPEED -> FLAG_OFF(fno=1, mask=0xFF) -> END_TOKEN_FE` |
| `ev[19]` | Touch / Step (0x01) | `STAR_RECRUITED(chara=94, mask=0x01) AND FLAG_IS_SET(fno=144, mask=0x01) AND TALK_TO(obj[9])` | `MOVE_DIR -> RETURN_SUB -> WAIT -> EXEC_SCRIPT -> MOVE_DIR -> SLEEP -> WAIT -> Op96 -> CAMERA_MOVE -> RETURN_SUB -> Op240 -> Op240 -> SLEEP -> Op27 -> MOVE_SPEED -> FLAG_OFF(fno=1, mask=0xFF) -> END_TOKEN_FE` |
| `ev[20]` | Touch / Step (0x01) | `STAR_RECRUITED(chara=94, mask=0x01) AND FLAG_NOT_SET(fno=144, mask=0x01) AND TALK_TO(obj[8])` | `EXEC_SCRIPT -> MOVE_DIR -> SLEEP -> WAIT -> Op96 -> CAMERA_MOVE -> RETURN_SUB -> Op240 -> Op240 -> SLEEP -> Op27 -> MOVE_SPEED -> FLAG_OFF(fno=0, mask=0xFF) -> END_TOKEN_FE` |
| `ev[21]` | Touch / Step (0x01) | `STAR_RECRUITED(chara=94, mask=0x01) AND FLAG_NOT_SET(fno=144, mask=0x01) AND TALK_TO(obj[9])` | `MOVE_DIR -> RETURN_SUB -> WAIT -> EXEC_SCRIPT -> MOVE_DIR -> SLEEP -> WAIT -> Op96 -> CAMERA_MOVE -> RETURN_SUB -> Op240 -> Op240 -> SLEEP -> Op27 -> MOVE_SPEED -> FLAG_OFF(fno=0, mask=0xFF) -> END_TOKEN_FE` |
| `ev[22]` | Touch / Step (0x01) | `STAR_RECRUITED(chara=95, mask=0x01) AND HON_FLAG_SET(fno=14, mask=0x02) AND TALK_TO(obj[10])` | `Op96 -> Op34 -> FLAG_OFF(fno=240, mask=0xF0) -> MOVE_SPEED -> PLAY_BGM -> MOVE_DIR -> WAIT -> WAIT -> WAIT` |
| `ev[23]` | Touch / Step (0x01) | `STAR_RECRUITED(chara=95, mask=0x01) AND HON_FLAG_SET(fno=14, mask=0x02) AND TALK_TO(obj[11])` | `MOVE_DIR -> FLAG_OFF(fno=0, mask=0x60) -> Op34 -> FLAG_OFF(fno=240, mask=0xF0) -> MOVE_SPEED -> PLAY_BGM -> MOVE_DIR -> WAIT -> WAIT -> WAIT` |
| `ev[24]` | Touch / Step (0x01) | `STAR_RECRUITED(chara=95, mask=0x01) AND TALK_TO(obj[10])` | `EXEC_SCRIPT -> MOVE_DIR -> SLEEP -> WAIT -> Op96 -> Op34 -> FLAG_OFF(fno=240, mask=0xF0) -> SLEEP -> PARTY_ADD -> MOVE_DIR -> WAIT -> WAIT -> WAIT` |
| `ev[25]` | Touch / Step (0x01) | `STAR_RECRUITED(chara=95, mask=0x01) AND TALK_TO(obj[11])` | `MOVE_DIR -> FLAG_OFF(fno=0, mask=0x1E) -> MOVE_DIR -> SLEEP -> WAIT -> Op96 -> Op34 -> FLAG_OFF(fno=240, mask=0xF0) -> SLEEP -> PARTY_ADD -> MOVE_DIR -> WAIT -> WAIT -> WAIT` |
| `ev[26]` | Touch / Step (0x01) | `TALK_TO(obj[12]) AND HON_FLAG_SET(fno=14, mask=0x02)` | `Op118 -> WARP_SUBMAP(sub=16, x=0, y=16) -> SLEEP` |
| `ev[27]` | Touch / Step (0x01) | `TALK_TO(obj[12])` | `Op118 -> WARP_SUBMAP(sub=16, x=0, y=16) -> MOVE_SPEED` |
| `ev[28]` | Action / Talk (0x02) | `FLAG_IS_SET(fno=144, mask=0x04)` | `EXEC_SCRIPT -> SLEEP -> MOVE_SPEED -> FADE_OUT -> SET_POS` |
| `ev[29]` | Touch / Step (0x01) | `X_RANGE(126..134) AND Y_RANGE(142..143) AND PLAYER_FACING(val=0)` | `ENABLE_INPUT -> CHAR_ANIME -> MOVE_SPEED -> WARP_SUBMAP(sub=1, x=130, y=77)` |
| `ev[30]` | Touch / Step (0x01) | `TALK_TO(obj[25])` | `EXEC_SCRIPT -> OBJ_FACING -> SLEEP -> WAIT -> OVERLAY_CALL(cat=6, sub=12) -> MOVE_DIR -> SE_PLAY -> MOVE_SPEED` |
| `ev[31]` | Action / Talk (0x02) | `NOP` | `ENABLE_INPUT -> SET_POS -> SLEEP` |
| `ev[32]` | Action / Talk (0x02) | `RANDOM_CHANCE(val=2)` | `OVERLAY_PSET -> MOVE_SPEED -> SE_STOP -> Op124 -> Op118 -> DISABLE_INPUT -> SET_POS -> SLEEP -> OVERLAY_PEND` |
| `ev[33]` | Touch / Step (0x01) | `HON_FLAG_CLEAR(fno=11, mask=0x01) AND TALK_TO(obj[26])` | `OVERLAY_CALL(cat=6, sub=13)` |
| `ev[34]` | Touch / Step (0x01) | `HON_FLAG_SET(fno=11, mask=0x01) AND TALK_TO(obj[26])` | `OVERLAY_CALL(cat=14, sub=13)` |
| `ev[35]` | Touch / Step (0x01) | `TALK_TO(obj[27])` | `EXEC_SCRIPT -> OBJ_FACING -> SLEEP -> WAIT -> OVERLAY_CALL(cat=6, sub=14)` |
| `ev[36]` | Touch / Step (0x01) | `TALK_TO(obj[28])` | `EXEC_SCRIPT -> OBJ_FACING -> SLEEP -> WAIT -> OVERLAY_CALL(cat=6, sub=15)` |
| `ev[37]` | Action / Talk (0x02) | `NOP` | `SLEEP -> PARTY_REMOVE` |
| `ev[38]` | Touch / Step (0x01) | `TALK_TO(obj[29])` | `EXEC_SCRIPT -> OBJ_FACING -> SLEEP -> WAIT -> OVERLAY_CALL(cat=6, sub=16) -> MOVE_DIR -> PARTY_REMOVE -> WAIT` |
| `ev[39]` | Touch / Step (0x01) | `TALK_TO(obj[30])` | `EXEC_SCRIPT -> OBJ_FACING -> SLEEP -> WAIT -> OVERLAY_CALL(cat=6, sub=17) -> MOVE_DIR -> EXEC_SCRIPT -> MOVE_SPEED` |
| `ev[40]` | Touch / Step (0x01) | `TALK_TO(obj[20])` | `OVERLAY_CALL(cat=4, sub=8)` |
| `ev[41]` | Touch / Step (0x01) | `TALK_TO(obj[21])` | `SHOW_SERIFU(obj=21, msg=4, bank=9)` |
| `ev[42]` | Touch / Step (0x01) | `TALK_TO(obj[22])` | `SHOW_SERIFU(obj=22, msg=4, bank=10)` |
| `ev[43]` | Touch / Step (0x01) | `TALK_TO(obj[23])` | `SHOW_SERIFU(obj=23, msg=4, bank=11)` |
| `ev[44]` | Touch / Step (0x01) | `TALK_TO(obj[24])` | `SHOW_SERIFU(obj=24, msg=4, bank=12)` |

---
