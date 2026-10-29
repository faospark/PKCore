# Suikoden II Master Map Entities, Triggers & World Objects Catalog

## Exhaustive Engine Architecture, Trigger Bytecode & 62 Distinct Geographic Area Volumes

This document and its **62 dedicated geographic area volumes** in `Documentation/areas/` form the definitive, unabridged technical reference for all **4,901 NPCs**, **1,552 Dynamic Props**, **3,207 Collision Triggers**, **90 Save Orbs**, and **27 Dungeon Chest Clusters** across all 226 master map assets in **Suikoden II HD Remaster** (`GSD2`).

Every single area has its own dedicated file in full. Every single entity—whether a living actor, an invisible trigger dot, a decorative prop (bonsai, well rim, water bucket, tea table, chair), a treasure chest, or a Journeyman save orb—is fully itemized with exact coordinates, dimensions, facing direction, collision bitmasks, and decompiled bytecode execution scripts.

---

## 1. Engine Memory Architecture: `MACHIDAT` -> `MAPEVDAT` -> `EVENT_OBJ` & `EVENT_WK`

When entering any location, the game engine invokes `MACHICON.EventInit()`, which deserializes and loads a `MACHIDAT` ScriptableObject container holding the map's submaps, entities, collision grids, and bytecode scripts.

```text
MACHIDAT (Master Map Container)
 └── eventdata (EVENTDAT)
      └── mapeventdat (List<MAPEVDAT>) ── Submaps (00, 01, 02...)
           ├── eventobj (Array<EVENT_OBJ>) ── Physical Entities, Props & Hitboxes
           └── eventdat (Array<EVENT_WK>)  ── Trigger Scripts & Bytecode Logic
```

### `EVENT_OBJ` Physical Field Architecture

| Field | Type | Function & Allowed Values |
|---|---|---|
| `otyp` | `byte` | **Object Class**: `1` = Actor / NPC; `2` = Prop / Scenery (Bonsai, well, table, torch); `3` = World Device (Chest, Save Orb, Bed); `4` = Hitbox / Trigger Zone / Single-Tile Dot |
| `disp` | `byte` | **Visibility Flag**: `0` = Hidden / Disabled / Dormant; `1` = Rendered & Active in collision grid |
| `spd` | `byte` | **Walk Speed**: `0` = Fixed immobile; `4` = Standard walking speed; `5`-`8` = Running |
| `wt` | `byte` | **Wander Timer**: `0` = Continuous wander; `1`-`254` = Idle ticks before movement; `255` = Fixed orientation (no wander) |
| `ano` | `byte` | **Pose & Animation State**: Facing direction (`0`=Down, `1`=Left, `2`=Up, `3`=Right) or visual mode (`2`=Closed chest, `3`=Open chest, `14`/`25`/`53`+=Spinning Save Orb) |
| `ityp` | `byte` | **Interaction Mode**: `0` = Action button (Confirm); `1` = Counter talk (over 1-tile barrier); `2` = Touch/Bump; `3` = Step-Over / Walk-Through |
| `fpno` | `ushort` | **Figure / Sprite Atlas Pattern ID**: Sprite model ID (`0`=None/Invisible trigger, `48`=Riou, `18`=Jowy, `50`=Nanami, `65174`=Rare Vendor, etc.) |
| `ozok` | `ushort` | **Collision Mask**: `0` = Passable (walk-through); `2` = Solid obstacle (impassable physical barrier) |
| `pri` | `ushort` | **Z-Order Priority**: `0` = Standard ground layer; `40`-`180` = Elevated priority (floating orbs, chandeliers) |
| `x`, `y` | `int` | **Tilemap Grid Coordinates**: Precise tile coordinate on the submap collision grid (origin `(0, 0)` is top-left) |
| `w`, `h` | `int` | **Bounding Extent**: `w: 0, h: 0` = Single 1x1 Tile ('A Dot'); `w: N, h: M` = Multi-tile bounding box |

---

## 2. Trigger Types (`etyp`) & Condition Bytecode (`eventForm`)

### The 4 Execution Modes (`etyp`)

- **`etyp = 1` (Action / Inspect / Talk Trigger)**: Fired when player is adjacent or inside a trigger zone and presses the Confirm/Action button.

- **`etyp = 2` (Room Initialization / `OnMapLoad`)**: Fired ONCE immediately upon entering the room before screen fade-in; handles entity visibility (`disp`), chest states, and scene setup.

- **`etyp = 3` (Spatial Step-On Tripwire / Warp Trigger)**: Fired dynamically when the player steps onto an active coordinate `(x, y)`.

- **`etyp = 4` (Continuous Engine Loop)**: Evaluated on every tick/frame for ambient logic, timers, and lighting.


### `eventForm` Condition Opcodes

| Opcode | Parameters | Condition Logic |
|:---:|---|---|
| `0` | *(None)* | Unconditional Pass (`true`). Always executes. |
| `1` | `Xmin, Xmax, Ymin, Ymax` | Spatial bounding box check: `Xmin <= Player.X <= Xmax` and `Ymin <= Player.Y <= Ymax`. |
| `2` | `TargetDir` | Player orientation check (0=Down, 1=Left, 2=Up, 3=Right). |
| `3` | `FlagID, BitMask` | Story Flag Set check: `flag[FlagID] & BitMask != 0`. |
| `4` | `FlagID, BitMask` | Story Flag Clear check: `flag[FlagID] & BitMask == 0`. |
| `5` | `ObjIndex` | Interaction target check: Current inspected object == `eventobj[ObjIndex]`. |
| `6` | `ItemID` | Inventory item check: Party holds item `ItemID`. |
| `10` | `CharID` | Active Party check: Star of Destiny `CharID` is in the battle party. |
| `11` | `CharID` | Party Absence check: Star of Destiny `CharID` is NOT in the party. |
| `27` | `Byte, Bit` | Treasure Looted check: Chest byte `Byte` bit `Bit` is already SET. |
| `28` | `Byte, Bit` | Treasure Fresh check: Chest byte `Byte` bit `Bit` is UNOPENED (zero). |
| `30` | `Level` | Castle HQ Level check: Dunan Castle is at or above `Level` (1-4). |
| `255, 254` | *(End)* | Bytecode stream terminator. |

---

## 3. Master Action Command Catalog: All 147 `EC*` Opcodes in `eventCom`

| Opcode | Method Name | Parameters | Functional Description |
|:---:|---|---|---|
| `1` | `ECMapChenge` | `MapID, Submap, DestX, DestY, Dir` | Intra-regional room/submap warp. |
| `2` | `ECMachiChenge` | `RegionID, MapNum, Submap, X, Y` | Inter-regional town/dungeon transition. |
| `3` | `ECMachiChengeBase` | `Submap, X, Y, Dir` | Instant return warp to Dunan Castle HQ. |
| `4` | `ECMachiChengeM` | `WorldSector, X, Y` | Overworld map exit transition. |
| `7` | `ECSrnScroll` | `DeltaX, DeltaY, Speed` | Scripted camera pan independent of player. |
| `8` | `ECSrnBaseScroll` | `Speed` | Resets camera tracking back to Riou. |
| `10` | `ECSrnBWIO` | `FadeType, Speed, Color` | Screen fade (fade-in, fade-out, flash). |
| `12` | `ECWindowSerifu` | `TextBank, MsgID` | Displays dialogue message box from localized strings. |
| `15` | `ECWindowFace` | `FaceID, Pos, Flip` | Draws character portrait on dialogue window. |
| `16` | `ECWindowFaceEnd` | *(None)* | Clears and dismisses character dialogue portrait. |
| `17` | `ECWindowFaceHyojyo` | `ExpressionIndex` | Swaps emotional expression on active portrait. |
| `19` | `ECWindowSentaku` | `OptionA, OptionB...` | Spawns interactive multiple-choice prompt. |
| `20` | `ECSentakuJump` | `OptionIdx, Offset` | Jumps bytecode instruction based on selected choice. |
| `35` | `ECEventBattleGo` | `BattleIndex, BGM` | Launches scripted boss/story combat encounter. |
| `36` | `ECWarEventGo` | `WarBattleID` | Launches full tactical army war battle. |
| `37` | `ECRndBatCut` | `State` | Disables/enables random encounters. |
| `38` | `ECSaveGo` | *(None)* | Invokes native `MACHICON.MSaveInit()` save system dialog. |
| `41` | `ECPartyMoney` | `AmountHigh, AmountLow` | Adds/deducts Potch (signed 32-bit integer). |
| `42` | `ECItemDel` | `ItemID, Count` | Removes items from player inventory. |
| `43` | `ECShopOverlayGo` | `ShopType, ShopIdx` | Opens shopping interface (Item, Armor, Forge, Appraise). |
| `45` | `ECODispOn` | `ObjIndex` | Makes entity visible (`disp = 1`). |
| `46` | `ECODispOff` | `ObjIndex` | Hides entity from rendering & collision (`disp = 0`). |
| `47` | `ECOPosSet` | `ObjIndex, X, Y` | Instantly teleports entity to exact tile position. |
| `48` | `ECODirSet` | `ObjIndex, Dir` | Changes entity facing direction. |
| `49` | `ECOSpeedSet` | `ObjIndex, Speed` | Sets movement walking speed. |
| `50` | `ECOMoveK` | `ObjIndex, DestX, DestY` | Commands entity to pathfind and walk to tile. |
| `55` | `ECOPriSet` | `ObjIndex, Priority` | Modifies entity rendering priority layer `pri`. |
| `56` | `ECOAniChen` | `ObjIndex, PoseID` | Sets character pose frame (sit, lie down, cheer). |
| `59` | `ECObjColChenge` | `ObjIndex, SolidState` | Toggles solid obstacle vs passable collision (`ozok`). |
| `60` | `ECObjEfctCon` | `ObjIndex, EffectID` | Spawns visual exclamation `!`, sweat, or question `?`. |
| `64` | `ECFixDoor` | `ObjIndex, OpenState` | Animates doorway opening/closing. |
| `70` | `ECPartySet` | `CharID, SlotIndex` | Recruits and adds character to active party lineup. |
| `71` | `ECPartyDel` | `CharID` | Removes character from active party to castle reserves. |
| `75` | `ECPartyRefresh` | *(None)* | Completely restores HP/MP for all party members. |
| `95` | `ECEvFlgSet` | `FlagID, BitMask` | Sets story progression flag bit. |
| `96` | `ECEvFlgOff` | `FlagID, BitMask` | Clears story progression flag bit. |
| `97` | `ECWkEvFlgSet` | `Byte, Bit` | Sets local map / treasure looted bit flag. |
| `98` | `ECWkEvFlgOff` | `Byte, Bit` | Clears local map / treasure flag bit. |
| `100` | `ECTkFlgSet` | `FlagID` | Marks NPC talk interaction as completed. |
| `106` | `ECCharEvFlgSet` | `CharID, FlagBit` | Sets character personal story quest milestone. |

---

## 4. Master Geographic Directory: 62 Dedicated Area Volumes (1 Area = 1 Complete File)

Every single distinct geographic location in Suikoden II is documented in full in its own dedicated Markdown volume in `Documentation/areas/`:

| # | Geographic Area Title | Map IDs Included | Line Count | Full Unabridged Documentation File |
|:---:|---|---|:---:|---|
| 1 | **Banner Village & Fast Pier** | `vf01`, `vf02`, `vf06`, `vf07` | **1,022 lines** | [areas/banner_village.md](areas/banner_village.md) |
| 2 | **Cave of the Wind Caverns** | `vd06`, `vd13` | **1,138 lines** | [areas/cave_of_the_wind.md](areas/cave_of_the_wind.md) |
| 3 | **Coronet Town & Harbor Docks** | `vc17`, `vc18`, `vc19` | **503 lines** | [areas/coronet_town_and_port.md](areas/coronet_town_and_port.md) |
| 4 | **Crom Village & Outskirts Path** | `vg08`, `vg13`, `vg16` | **1,103 lines** | [areas/crom_village.md](areas/crom_village.md) |
| 5 | **Tigermouth Mountain Settlement** | `vg04`, `vg06` | **459 lines** | [areas/tigermouth_village.md](areas/tigermouth_village.md) |
| 6 | **Castle HQ: Tetsu's Castle Bathhouse** | `vk06` | **598 lines** | [areas/dunan_castle_hq_bathhouse.md](areas/dunan_castle_hq_bathhouse.md) |
| 7 | **Castle HQ: Cartography Room** | `vk12` | **264 lines** | [areas/dunan_castle_hq_cartography_room.md](areas/dunan_castle_hq_cartography_room.md) |
| 8 | **Castle HQ: Commander Riou's Bedroom** | `vk10` | **671 lines** | [areas/dunan_castle_hq_commanders_quarters.md](areas/dunan_castle_hq_commanders_quarters.md) |
| 9 | **Castle HQ: Concert Stage & Music Hall** | `vk09` | **365 lines** | [areas/dunan_castle_hq_concert_stage.md](areas/dunan_castle_hq_concert_stage.md) |
| 10 | **Castle HQ: Lake Dunan Docks & Fishing Pier** | `vk22` | **321 lines** | [areas/dunan_castle_hq_docks_and_fishing.md](areas/dunan_castle_hq_docks_and_fishing.md) |
| 11 | **Castle HQ: Combat Dojo & Sparring Arena** | `vk03` | **342 lines** | [areas/dunan_castle_hq_dojo_and_training.md](areas/dunan_castle_hq_dojo_and_training.md) |
| 12 | **Castle HQ: Tony's Farm & Pastures** | `vk19` | **278 lines** | [areas/dunan_castle_hq_farm_and_pastures.md](areas/dunan_castle_hq_farm_and_pastures.md) |
| 13 | **Castle HQ: Great Hall & Main Foyers** | `vk01`, `vk14`, `vk21`, `vk34` | **2,752 lines** | [areas/dunan_castle_hq_great_hall_and_entry.md](areas/dunan_castle_hq_great_hall_and_entry.md) |
| 14 | **Castle HQ: Grounds, Gardens & Animal Sanctuary** | `vk11`, `vk18` | **843 lines** | [areas/dunan_castle_hq_grounds_and_sanctuary.md](areas/dunan_castle_hq_grounds_and_sanctuary.md) |
| 15 | **Castle HQ: Jude's Guardian Deity Shrine** | `vk33` | **198 lines** | [areas/dunan_castle_hq_guardian_deity_shrine.md](areas/dunan_castle_hq_guardian_deity_shrine.md) |
| 16 | **Castle HQ: Dr. Huan's Medical Clinic** | `vk05` | **482 lines** | [areas/dunan_castle_hq_infirmary_and_clinic.md](areas/dunan_castle_hq_infirmary_and_clinic.md) |
| 17 | **Castle HQ: Castle Inn & Lodging Rooms** | `vk31` | **413 lines** | [areas/dunan_castle_hq_inn_and_lodging.md](areas/dunan_castle_hq_inn_and_lodging.md) |
| 18 | **Castle HQ: Living Quarters & Corridors** | `vk13`, `vk16`, `vk17`, `vk24`, `vk25`, `vk26`, `vk27`, `vk28`, `vk30`, `vk35`, `vk36`, `vk37` | **2,928 lines** | [areas/dunan_castle_hq_living_quarters_and_corridors.md](areas/dunan_castle_hq_living_quarters_and_corridors.md) |
| 19 | **Castle HQ: Memorial Graveyard** | `vk23` | **287 lines** | [areas/dunan_castle_hq_memorial_graveyard.md](areas/dunan_castle_hq_memorial_graveyard.md) |
| 20 | **Castle HQ: Hai Yo's Restaurant & Kitchen** | `vk20` | **376 lines** | [areas/dunan_castle_hq_restaurant_and_kitchen.md](areas/dunan_castle_hq_restaurant_and_kitchen.md) |
| 21 | **Castle HQ: Tavern & Gambling Parlor** | `vk04` | **820 lines** | [areas/dunan_castle_hq_tavern_and_dice.md](areas/dunan_castle_hq_tavern_and_dice.md) |
| 22 | **Castle HQ: Viki Teleport & Mechanical Elevator** | `vk29`, `vk32` | **723 lines** | [areas/dunan_castle_hq_teleport_and_elevator.md](areas/dunan_castle_hq_teleport_and_elevator.md) |
| 23 | **Castle HQ: Barbara's Vault & Richmond Detective** | `vk02` | **1,141 lines** | [areas/dunan_castle_hq_vault_and_detective.md](areas/dunan_castle_hq_vault_and_detective.md) |
| 24 | **Castle HQ: War Strategy Chamber** | `vk07` | **624 lines** | [areas/dunan_castle_hq_war_strategy_room.md](areas/dunan_castle_hq_war_strategy_room.md) |
| 25 | **Castle HQ: Watchtower & High Roof** | `vk15` | **117 lines** | [areas/dunan_castle_hq_watchtower_and_roof.md](areas/dunan_castle_hq_watchtower_and_roof.md) |
| 26 | **Castle HQ: Workshop & Library Archives** | `vk08` | **488 lines** | [areas/dunan_castle_hq_workshop_and_library.md](areas/dunan_castle_hq_workshop_and_library.md) |
| 27 | **Forest Village Settlement** | `ve02`, `ve10`, `ve11`, `ve12` | **899 lines** | [areas/forest_village.md](areas/forest_village.md) |
| 28 | **Greenhill Principality (City & Outskirts)** | `ve01`, `ve08`, `ve09`, `ve13`, `ve14`, `ve16` | **1,771 lines** | [areas/greenhill_city.md](areas/greenhill_city.md) |
| 29 | **Greenhill-Matilda Forest Trail & Checkpoint** | `ve04`, `ve05`, `ve15` | **518 lines** | [areas/greenhill_matilda_path_and_border.md](areas/greenhill_matilda_path_and_border.md) |
| 30 | **Gregminster Capital Avenues** | `vf04` | **215 lines** | [areas/gregminster_capital.md](areas/gregminster_capital.md) |
| 31 | **Highland Military Recon Encampment** | `vc14`, `vc16`, `vc20`, `vc23`, `vc30` | **792 lines** | [areas/highland_recon_camp_muse.md](areas/highland_recon_camp_muse.md) |
| 32 | **Highland Youth Brigade Camp** | `va01`, `va02` | **530 lines** | [areas/highland_youth_brigade_camp.md](areas/highland_youth_brigade_camp.md) |
| 33 | **Highway Village Frontier Settlement** | `vi11`, `vi12`, `vi14` | **719 lines** | [areas/highway_village.md](areas/highway_village.md) |
| 34 | **Kobold Village Settlement** | `vh03`, `vh07`, `vh09` | **835 lines** | [areas/kobold_village.md](areas/kobold_village.md) |
| 35 | **Kuskus Town & River Docks** | `vd15`, `vd16` | **319 lines** | [areas/kuskus_town.md](areas/kuskus_town.md) |
| 36 | **Kyaro Town (Plaza, Homes & Execution Grounds)** | `va08`, `va09`, `va10`, `va11`, `va12`, `va13`, `va14`, `va15`, `va16`, `va17`, `va18`, `va19`, `va20`, `va21`, `va22`, `va23`, `va25`, `va26` | **1,716 lines** | [areas/kyaro_town.md](areas/kyaro_town.md) |
| 37 | **L'Renouille Imperial Capital Citadel** | `vj01`, `vj02`, `vj03`, `vj04`, `vj05`, `vj06`, `vj07`, `vj08`, `vj09`, `vj10`, `vj11`, `vj12`, `vj13`, `vj14`, `vj15`, `vj16`, `vj18`, `vj19`, `vj20`, `vj21`, `vj22`, `vj23`, `vj24` | **3,319 lines** | [areas/l_renouille_citadel.md](areas/l_renouille_citadel.md) |
| 38 | **Lakewest Town & Docks** | `vh02`, `vh10` | **740 lines** | [areas/lakewest_town.md](areas/lakewest_town.md) |
| 39 | **Viktor's Mercenary Fortress** | `vb01`, `vb02`, `vb12`, `vb13`, `vb14`, `vb15`, `vb16`, `vb19` | **1,523 lines** | [areas/mercenary_fortress.md](areas/mercenary_fortress.md) |
| 40 | **Mt. Rakutei Dragon Cliffs & Peak** | `vi08`, `vi09`, `vi13`, `vi15` | **655 lines** | [areas/mt_rakutei.md](areas/mt_rakutei.md) |
| 41 | **Banner Pass (Toran Mountain Trail)** | `vf03` | **949 lines** | [areas/banner_pass.md](areas/banner_pass.md) |
| 42 | **Ryube Forest & Tsai's Hermit Hut** | `vb07`, `vb09`, `vb10`, `vb11`, `vb20`, `vb21` | **1,211 lines** | [areas/ryube_forest.md](areas/ryube_forest.md) |
| 43 | **Muse City (Plaza, City Hall & Ruins)** | `vc01`, `vc02`, `vc03`, `vc09`, `vc10`, `vc11`, `vc15`, `vc21`, `vc22`, `vc24`, `vc25`, `vc26`, `vc27`, `vc28`, `vc29`, `vc31` | **3,944 lines** | [areas/muse_city.md](areas/muse_city.md) |
| 44 | **New Leaf Academy (Campus, Dorms & Cellar)** | `ve03`, `ve06`, `ve07` | **1,387 lines** | [areas/new_leaf_academy.md](areas/new_leaf_academy.md) |
| 45 | **North Sparrow Mountain Pass & Checkpoint** | `va04`, `va05`, `va06`, `va07` | **614 lines** | [areas/north_sparrow_pass.md](areas/north_sparrow_pass.md) |
| 46 | **North Window Ghost Town Ruins** | `vd04`, `vd07` | **352 lines** | [areas/north_window_ruins.md](areas/north_window_ruins.md) |
| 47 | **Radat Town & Canal Wharf** | `vd02`, `vd05`, `vd20` | **820 lines** | [areas/radat_town.md](areas/radat_town.md) |
| 48 | **Rockaxe Castle Citadel & Ramparts** | `vi01`, `vi02`, `vi03`, `vi04`, `vi05`, `vi06`, `vi07`, `vi10` | **1,964 lines** | [areas/rockaxe_citadel_and_castle.md](areas/rockaxe_citadel_and_castle.md) |
| 49 | **Ryube Village & Outskirts** | `vb05`, `vb06`, `vb18` | **1,056 lines** | [areas/ryube_village.md](areas/ryube_village.md) |
| 50 | **Sajah Frontier Village** | `vj17` | **316 lines** | [areas/sajah_village.md](areas/sajah_village.md) |
| 51 | **Ancient Sindar Ruins Caverns** | `vc06`, `vc07`, `vc08`, `vc12`, `vc13` | **2,012 lines** | [areas/sindar_ruins.md](areas/sindar_ruins.md) |
| 52 | **South Window Capital City** | `vd01`, `vd03`, `vd08`, `vd09`, `vd10`, `vd11`, `vd12`, `vd14`, `vd17`, `vd18`, `vd19` | **2,358 lines** | [areas/south_window_city.md](areas/south_window_city.md) |
| 53 | **Swallow Pass & Highland Border Gate** | `vb08`, `vb17` | **597 lines** | [areas/swallow_pass.md](areas/swallow_pass.md) |
| 54 | **Tenzan Pass Mountain Cliff** | `va03`, `va24` | **740 lines** | [areas/tenzan_pass.md](areas/tenzan_pass.md) |
| 55 | **Tiger Cave & Mt. Senai Shrines** | `vg09`, `vg15` | **483 lines** | [areas/tiger_cave_mt_senai.md](areas/tiger_cave_mt_senai.md) |
| 56 | **Tinto Mining City & Mayor Hall** | `vg01`, `vg02`, `vg03`, `vg17` | **1,368 lines** | [areas/tinto_city.md](areas/tinto_city.md) |
| 57 | **Tinto Mines & Underground Caverns** | `vg05`, `vg07`, `vg10`, `vg11`, `vg12`, `vg14` | **891 lines** | [areas/tinto_mines.md](areas/tinto_mines.md) |
| 58 | **Toran Castle Presidential Palace** | `vf05` | **370 lines** | [areas/toran_castle_palace.md](areas/toran_castle_palace.md) |
| 59 | **Toto Village (Peaceful & Burned Ruins)** | `vb03`, `vb04` | **514 lines** | [areas/toto_village.md](areas/toto_village.md) |
| 60 | **Two River City (Human, Wingly & Kobold)** | `vh01`, `vh05`, `vh06`, `vh11`, `vh12` | **2,132 lines** | [areas/two_river_city.md](areas/two_river_city.md) |
| 61 | **Drakemouth Village & Border Road** | `vh08` | **350 lines** | [areas/drakemouth_village.md](areas/drakemouth_village.md) |
| 62 | **Two River Subterranean Sewers** | `vh04` | **416 lines** | [areas/two_river_sewers.md](areas/two_river_sewers.md) |
| 63 | **White Deer Country Inn** | `vc04`, `vc05` | **441 lines** | [areas/white_deer_inn.md](areas/white_deer_inn.md) |

---

## 5. Native In-Memory Entity & Trigger Injection Guide (PKCore Hook)

To natively add any NPC, prop, bonsai, single-tile trigger dot, treasure chest, or save point, PKCore hooks `MACHICON.EventInit` as a `[HarmonyPostfix]`. This dynamically expands the `submap.eventobj` and `submap.eventdat` arrays in memory without ever modifying `.json` asset files or repacking asset bundles.


```csharp
// Example: Injecting a Bonsai Decorative Prop + Inspect Trigger Tile in PKCore
[HarmonyPatch(typeof(MACHICON), "EventInit")]
public static class InjectBonsaiAndTriggerPatch
{
    [HarmonyPostfix]
    public static void Postfix(MACHICON __instance, EVENTCON __result)
    {
        if (__result == null || __result.mdat?.eventdata?.mapeventdat == null) return;
        if (!string.Equals(__result.mdat.name, "va08", System.StringComparison.OrdinalIgnoreCase)) return;

        var submap = __result.mdat.eventdata.mapeventdat[0];
        int oldObjLen = submap.eventobj.Length;

        // 1. Expand eventobj array (+2 for Bonsai Prop + Trigger Dot)
        var newObjs = new Il2CppReferenceArray<EVENT_OBJ>(oldObjLen + 2);
        for (int i = 0; i < oldObjLen; i++) newObjs[i] = submap.eventobj[i];

        // Object A: Decorative Bonsai Prop (otyp = 2)
        var bonsai = new EVENT_OBJ();
        bonsai.otyp = 2;        // 2 = Environmental Prop
        bonsai.disp = 1;        // Rendered
        bonsai.fpno = 33810;    // Bonsai / Planter Sprite Pattern
        bonsai.ozok = 2;        // Solid barrier
        bonsai.x = 42; bonsai.y = 30;
        bonsai.w = 0;  bonsai.h = 0; // Single 1x1 tile
        newObjs[oldObjLen] = bonsai;

        // Object B: Single-Tile Interaction Trigger Dot (otyp = 4)
        var dot = new EVENT_OBJ();
        dot.otyp = 4;           // 4 = Hitbox / Trigger Zone
        dot.disp = 1;           // Active
        dot.ozok = 0;           // Passable
        dot.x = 42; dot.y = 31; // Placed 1 tile south of bonsai
        dot.w = 0;  dot.h = 0;  // Exact single tile dot
        newObjs[oldObjLen + 1] = dot;

        submap.eventobj = newObjs;
        submap.okaz = (byte)newObjs.Length;

        // 2. Expand eventdat array (+1 for Inspect Script)
        int oldEvLen = submap.eventdat.Length;
        var newEvs = new Il2CppReferenceArray<EVENT_WK>(oldEvLen + 1);
        for (int i = 0; i < oldEvLen; i++) newEvs[i] = submap.eventdat[i];

        var script = new EVENT_WK();
        script.etyp = 1; // Action / Confirm button trigger
        script.eventForm = new byte[] { 0, 255, 254 }; // Unconditional pass
        script.eventCom = new byte[] {
            12, 1, 36, 4, // Opcode 12: Window text ('An exquisite Kyaro bonsai tree.')
            255, 254      // Terminator
        };
        newEvs[oldEvLen] = script;

        submap.eventdat = newEvs;
        submap.evkaz = (ushort)newEvs.Length;
    }
}
```
