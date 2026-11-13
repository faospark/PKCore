# Suikoden II — L'Renouille Final Boss Gauntlet Replay

## 1. Overview

In vanilla **Suikoden II HD Remaster**, the final invasion of L'Renouille Castle is a one-time climactic gauntlet culminating in the defeat of the Silver Beast Rune (tracked globally by **Story Flag `143` bit `0x01`**). Once completed, the game progresses into the castle collapse, Tenzan Pass finale, and epilogue sequences, permanently closing the doors to the gauntlet battles.

The **L'Renouille Final Boss Gauntlet Replay Patch** (`S2FinalBossReplayPatch.cs`) adds seamless, non-destructive replayability for the complete sequence:

```
[Keep 2F: vj02]     ──> [Outer Gates: vj01]  ──> [Sanctum Hall: vj07] ──> [Sanctum: vj08]
 Lucia Vanguard          Han Cunningham Duel      Seed & Culgan 2v6        Silver Beast Rune
```

Whenever the player enters the outer fortress gates of L'Renouille (`vj01`) with the final boss completed, or toggles on-demand replay via configuration, `PKCore` automatically primes all 4 stages without corrupting character data, inventory, party composition, or other story flags.

In addition, the patch restores **Leona** to the Dunan Castle Tavern (`vk08`), replacing the substitute maid (*"Leona went to one of the towns nearby to restock on spirits."*) and re-enabling full party customization throughout post-game free roam!

---

## 2. Gauntlet Stages & Flag Architecture

### Stage 1: Lucia & Karaya Vanguard Battle (`vj02`)
- **Map**: `vj02_01` (Main Keep 2F)
- **Hitbox / Trigger**: `submap 1` `eventdat[31]` at `X: 99..109, Y: 110..111`
- **Required Conditions**:
  - `event_flag[220] & 0x40 == 0` (Lucia NOT defeated)
  - `event_flag[220] & 0x01 == 0` (Pre-Han assault stage)
- **Encounter**: 6v6 boss battle against Lucia (`fpno=64616`) and Karaya warriors (`Battle ID 106`, opcode `106`).
- **Post-Battle Script Sets**:
  - `event_flag[220] |= 0x40` (Lucia vanguard cleared)
  - Opens passage deeper into L'Renouille (`vj03`–`vj06`).

### Stage 2: General Han Cunningham Duel (`vj01`)
- **Map**: `vj01_00` (Outer Fortress & Gates)
- **Hitbox / Trigger**: `eventdat[40]` & `eventdat[41]`
- **Required Conditions**:
  - `event_flag[95] & 0x80 != 0` (L'Renouille assault underway)
  - `event_flag[98] & 0x80 != 0` (Assault active)
  - `event_flag[220] & 0x01 == 0` (Han duel NOT completed)
  - `event_flag[143] & 0x01 == 0` (Final boss NOT completed)
- **Encounter**: Riou vs. General Han Cunningham 1v1 duel (`Duel ID 76`, opcode `120`).
- **Post-Duel Script Sets**:
  - `event_flag[220] |= 0x01` (Han duel cleared)
  - `event_flag[222] = 0xFF` (Outer gate cutscene milestones 0–7 completed)
  - `event_flag[223] |= 0x01` (Outer gate passage sequence completed)
  - `event_flag[96] |= 0x03` (Castle assault stage primed)
  - Swings open the massive interior gates, enabling map transition into `vj02`.

### Stage 3: Generals Seed & Culgan 2v6 Battle (`vj07`)
- **Map**: `vj07_00` (Sanctum Hallway)
- **Hitbox / Trigger**: `submap 0` `eventdat[3]` (approach dialogue at `X: 11..29, Y: 80..86`) & `eventdat[6]` (battle trigger)
- **Required Conditions**:
  - `event_flag[96] & 0x02 != 0` (Hallway encounter primed)
  - `event_flag[96] & 0x04 == 0` (Generals NOT defeated)
- **Encounter**: Riou's 6-member party vs. Generals Seed (`fpno=144`) & Culgan (`fpno=143`) (`Battle ID 11`, opcode `106`).
- **Post-Battle Script Sets**:
  - `event_flag[96] |= 0x04` (Seed & Culgan defeat marker)
  - `event_flag[96] |= 0x08` (Beast Rune sanctum doors opened)
  - Opens the sanctum double-doors leading into `vj08`.

### Stage 4: Silver Beast Rune / Golden Hydra Final Boss (`vj08`)
- **Map**: `vj08_00` (Inner Sanctum)
- **Hitbox / Trigger**: `submap 0` `eventdat[3]` (Sanctum altar encounter)
- **Required Conditions**:
  - `event_flag[96] & 0x08 != 0` (Sanctum doors open)
  - `event_flag[98] & 0x01 == 0` (Beast Rune NOT defeated)
- **Encounter**: Riou's 6-member party vs. Silver Beast Rune / Golden Hydra (`Battle ID 8` / `28`, opcode `106`).
- **Post-Battle Script Sets**:
  - `event_flag[98] |= 0x01` (Beast Rune defeated in `vj08`)
  - `event_flag[220] |= 0x02` (Post-battle epilogue transition)
  - `event_flag[143] |= 0x01` (Global story flag: Beast Rune defeated / post-war world state)
  - Enables exit transitions `eventdat[11]` & `eventdat[13]` to royal chambers / epilogue.

---

## 3. Epilogue Leona Restoration (Decoupled Patch)

To preserve clean modular architecture, Leona's post-game tavern restoration is implemented in its own dedicated patch: [`S2EpilogueLeonaPatch.cs`](file:///d:/Appz/SuikodenModding/PKCore/Patches/S2EpilogueLeonaPatch.cs) (`s2EpilogueLeona`).

See [`suikoden_2_epilogue_leona.md`](file:///d:/Appz/SuikodenModding/PKCore/Documentation/suikoden_2_epilogue_leona.md) for full architectural documentation.

---

## 3. Replay Engine Architecture

The patch is implemented in [`S2FinalBossReplayPatch.cs`](file:///d:/Appz/SuikodenModding/PKCore/Patches/S2FinalBossReplayPatch.cs) and hooked into `MachiLoader_Load_Patch.Prefix` in [`MapTrackingPatch.cs`](file:///d:/Appz/SuikodenModding/PKCore/Patches/MapTrackingPatch.cs):

```csharp
[HarmonyPatch(typeof(MACHICON), "EventInit")]
public static class MachiLoader_Load_Patch
{
    [HarmonyPrefix]
    public static void Prefix(MACHICON __instance)
    {
        string machiName = __instance.GetMapName();
        string mapId = MACHICON_OnMapInitPatch.ParseMapIdFromMachiName(machiName) ?? machiName;
        S2CliveQuestReplayPatch.CheckAndResetCliveQuest(mapId);
        S2FinalBossReplayPatch.CheckAndResetFinalBoss(mapId);
    }
}
```

Because `EventInit` prefix executes **before** Unity / GSD2 instantiates event objects and parses hitboxes:
1. The flags are reset in memory.
2. `EventInit` parses the refreshed flags and spawns the boss objects (Han at the gate, Lucia on 2F, Seed & Culgan in the hall, and Beast Rune on the altar).
3. The player experiences the natural cutscene dialogue, battles, transitions, and gate openings without any script desync.

### Reset Operation

```csharp
public static void ResetGauntlet(GSD2::GAME_WORK gw, bool logDetails = true)
{
    // Stage 4: Reset Beast Rune
    gw.event_flag[143] &= (byte)~0x01;
    gw.event_flag[98]  &= (byte)~0x01;

    // Stage 3: Reset Generals Seed & Culgan
    gw.event_flag[96]  &= (byte)~(0x04 | 0x08);
    gw.event_flag[96]  |= 0x02; // Prime hallway encounter

    // Stage 2: Reset Lucia & Karaya Vanguard
    gw.event_flag[220] &= (byte)~0x40;

    // Stage 1: Reset General Han Cunningham and Outer Gate
    gw.event_flag[220] &= (byte)~(0x01 | 0x02);
    gw.event_flag[222] = 0x00;
    gw.event_flag[223] &= (byte)~0x01;

    // Preserve assault state
    gw.event_flag[95]  |= 0x80;
    gw.event_flag[98]  |= 0x80;
}
```

---

## 4. Configuration Settings

Controlled via BepInEx config (`BepInEx/config/faospark.pkcore.cfg`) under section `[05 Game : Suikoden 2]`:

| Setting | Type | Default | Description |
| :--- | :---: | :---: | :--- |
| `LoopFinalBossGauntlet` | `bool` | `true` | Automatically resets the complete L'Renouille gauntlet upon entering outer gates (`vj01`) when the final boss has been defeated. Allows challenging the sequence indefinitely in post-game. |
| `ResetGauntletOnNextEntry` | `bool` | `false` | When set to `true`, forces an immediate reset of all 4 stages upon entering any L'Renouille map (`vj*`), even if the final boss has not yet been defeated. Automatically resets back to `false` after executing. |
| `EnableLeonaPostFinalBoss` | `bool` | `true` | Restores Leona to the Dunan Castle Tavern (`vk08`), replacing the substitute maid (*"Leona went to restock on spirits"*) and re-enabling party changes throughout post-game exploration. |

---

## 5. Non-Destructive Integrity Guarantee

- **Story Flag `143`**: Preserves all other bits (e.g., bit `0x02` Greenhill liberation for Castle Level 3, bit `0x80`). Only bit `0x01` is modified.
- **Story Flag `96`**: Preserves bits `0x10`, `0x20`, `0x40`, `0x80`. Only bits `0x04` and `0x08` are cleared, and `0x02` is ensured.
- **Roster & Save Data**: Never touches character stats, party members, recruited stars (`nakam_1_num`), equipment, or inventory.
