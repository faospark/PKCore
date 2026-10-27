# Suikoden II: `t_box_flag` (`byte[32]`) Architecture & Patching Guide

This technical specification documents the internal architecture, memory layout, bytecode opcodes, and Harmony patching patterns for `t_box_flag` (`byte[32]`) in *Suikoden II* (`GSD2`).

> **Companion Reference**: For the complete geographic directory of all 171 treasure chests, their coordinates, and default item IDs, see [treasure_chests_catalog.md](treasure_chests_catalog.md).

---

## 1. Engine Memory & Save Data Architecture

In Suikoden II, `t_box_flag` is a **32-byte bitfield array** (`32 × 8 = 256` individual bitflags) that tracks opened treasure chests and one-time searchable objects (bookshelves, pots, crates) across all world maps.

### C# / IL2CPP Type Definitions
| Class | Property / Constant | Native Offset / Value | Source Reference |
|:---|:---|:---:|:---|
| `g2_main_h` | `public int T_BOX_MAX` | `32` (`0x20`) | `GSD2/g2_main_h.cs` |
| `GAME_WORK` | `public Il2CppStructArray<byte> t_box_flag` | `+0x98` | `GSD2/GAME_WORK.cs` |
| `GSD2SaveData.TmpSave` | `public Il2CppStructArray<byte> t_box_flag` | Serialized array | `GSD2/GSD2SaveData.cs` |

### Runtime Access in C# (PKCore)
At runtime, the active `GAME_WORK` singleton is accessed via `OldSrcBase.game_work`:
```csharp
var tBoxFlags = GSD2.OldSrcBase.game_work?.t_box_flag;
if (tBoxFlags != null && tBoxFlags.Length == 32)
{
    // Check if Byte 12, Bit 32 (0x20) is opened:
    bool isLooted = (tBoxFlags[12] & 32) != 0;
}
```

### Bitmask Addressing Formula
Unlike sequential 0–255 index systems, Suikoden II scripts address `t_box_flag` directly using a **2-byte pair**: `(ByteIndex, BitMask)`:
- **`ByteIndex`**: `0` through `31` (selects the element in `t_box_flag[ByteIndex]`).
- **`BitMask`**: Power-of-two bitmask (`1`, `2`, `4`, `8`, `16`, `32`, `64`, `128`, i.e., `1 << bitPos`).
- **Linear Bit Index (0–255)**:
  $$\text{BitIndex} = (\text{ByteIndex} \times 8) + \log_2(\text{BitMask})$$

---

## 2. Native Event Engine & Bytecode Mechanics

Every treasure chest or searchable shelf on a map is controlled by two bytecode arrays inside `MACHIDAT.eventdata.mapeventdat[submap].eventdat[event]`:
1. **`eventForm` (`byte[]`)**: Evaluated by `EVENTCON.EventFormTbl` (`0x1821532e0`) on map load and during trigger checks to determine whether the event/object is active.
2. **`eventCom` (`byte[]`)**: Executed by `EVENTCON`'s command dispatcher (`AssignCmdFunction` at `0x1821316f0`) when the player interacts with the chest.

### A. Precondition Check Opcodes in `eventForm` (`EVENTCON.EventFormTbl`)
`EventFormTbl` uses two switch cases (`0x1B` and `0x1C`) to inspect `game_work.t_box_flag`:

| `eventForm` Opcode | Hex | Format | Engine Evaluation Logic | Used By |
|:---:|:---:|:---|:---|:---|
| **`27`** | `0x1B` | `27, [ByteIndex], [BitMask]` | Passes if `(t_box_flag[ByteIndex] & BitMask) != 0` (**Already Opened**) | **Open Chest Lid Object** (`ano = 19, 20`) — spawns the empty open chest sprite only after the flag is set. |
| **`28`** | `0x1C` | `28, [ByteIndex], [BitMask]` | Passes if `(t_box_flag[ByteIndex] & BitMask) == 0` (**Unopened / Fresh**) | **Closed Chest Object** (`ano = 7, 8`) & **Loot Event Script** — allows interaction only while the flag is `0`. |

> **Important Note on Catalog Notation**: In some event scripts, `eventForm` preconditions are chained without a delimiter, causing `27` (`0x1B`) or `28` (`0x1C`) to appear right before the byte/bit arguments. Always verify whether the byte is the opcode (`27`/`28`) or the `ByteIndex` parameter!

### B. Execution Opcodes in `eventCom` (`EVENTCON` Command Table)
When a player opens a chest, the `eventCom` script executes the following sequence of opcodes:

| `eventCom` Opcode | Hex | Native Handler (`VA`) | Bytecode Signature | Behavior |
|:---:|:---:|:---|:---|:---|
| **`30`** | `0x1E` | `ECOverlayGo` (`0x1821417d0`) | `30, [Win], 4, 0, [ItemID], [ItemKind]` | Displays the *"Found [Item]!"* message window and stages the item reward. |
| **`41`** | `0x29` | `ECMachiChenge` / Item Commit | `41, 2, 0, 1, 255, 0` | Commits the staged item into the party's inventory bag (or prompts to discard if full). |
| **`96`** | `0x60` | `ECTkFlgSet` (`0x1821473b0`) | `96, [ByteIndex], [BitMask]` | **Sets the chest flag**: executes `game_work.t_box_flag[ByteIndex] \|= BitMask`. |
| **`97`** | `0x61` | `ECTkFlgOff` (`0x1821472c0`) | `97, [ByteIndex], [BitMask]` | **Clears the chest flag**: calls `G2_SYS.BIT_OFF(ref t_box_flag[ByteIndex], BitMask)`. |
| **`106`** | `0x6A` | `ECPartyMoney` | `106, ...` / `107, 0, 30, 27, [Lo], [Hi]` | Awards direct Potch currency. |

#### Native Disassembly Verification (`ECTkFlgSet` @ `0x1821473b0`)
1. Calls `COMMAND_LINE.Advance()` (`0x181a447a0`) to read `ByteIndex` into `esi`.
2. Calls `COMMAND_LINE.Advance()` (`0x181a447a0`) to read `BitMask` into `ebx`.
3. Calls `OldSrcBase.get_game_work()` (`0x181ac0270`) and loads `t_box_flag` at offset `+0x98`.
4. Executes `or byte ptr [rsi + rax + 0x20], bl` (`t_box_flag[ByteIndex] |= BitMask`).

---

## 3. Complete 32-Byte Allocation Map (`t_box_flag[0..31]`)

Across all 47 map assets in Suikoden II, **22 of the 32 bytes** are actively used by the base game, leaving **10 completely unused bytes (80 free bitflags)** that modders can safely use for custom chests, custom NPCs, or persistent mod state!

| Byte Index | Bits Used | Bitmasks Used | Assigned Regions & Map IDs | Notes & Quirk Warnings |
|:---:|:---:|:---|:---|:---|
| **Byte 0** | 8 / 8 | `1, 2, 4, 8, 16, 32, 64, 128` | **Sindar Ruins** (`vc12`, `vc13`) | Shared between `vc12` and `vc13` (seasonal/story variants of Sindar Ruins). |
| **Byte 1** | 5 / 8 | `1, 2, 32, 64, 128` | **Sindar Ruins & Recon Camp** (`vc07`, `vc12`, `vc13`, `vc30`) | Bits `4, 8, 16` are **FREE**. |
| **Byte 2** | 8 / 8 | `1, 2, 4, 8, 16, 32, 64, 128` | **Mt. Rakutei** (`vi13`) | Fully occupied (8 chests). |
| **Byte 3** | 1 / 8 | `1` | **Mt. Rakutei** (`vi13`) | Bits `2, 4, 8, 16, 32, 64, 128` (7 bits) are **FREE**. |
| **Byte 4** | 8 / 8 | `1, 2, 4, 8, 16, 32, 64, 128` | **Rockaxe Castle & Mt. Rakutei** (`vi06`, `vi08`) | Fully occupied. |
| **Byte 5** | 4 / 8 | `1, 2, 4, 8` | **Mt. Rakutei** (`vi08`) | Bits `16, 32, 64, 128` (4 bits) are **FREE**. |
| **Byte 6** | 6 / 8 | `1, 2, 4, 8, 16, 32` | **Lakewest Docks / Shilo's Shed** (`vh10`) | Bits `64, 128` (2 bits) are **FREE**. |
| **Byte 7** | 8 / 8 | `1, 2, 4, 8, 16, 32, 64, 128` | **Banner Pass** (`vf06`, `vf07`) | Fully occupied (8 chests). |
| **Byte 8** | 8 / 8 | `1, 2, 4, 8, 16, 32, 64, 128` | **L'Renouille Palace** (`vj02`, `vj03`, `vj05`) | Fully occupied. |
| **Byte 9** | 5 / 8 | `1, 2, 4, 8, 16` | **L'Renouille Palace** (`vj02`, `vj04`, `vj05`) | Bits `32, 64, 128` (3 bits) are **FREE**. |
| **Byte 10** | 8 / 8 | `1, 2, 4, 8, 16, 32, 64, 128` | **South Window & Cave of Wind** (`vd01`, `vd10`, `vd11`, `vd13`, `vd19`) | Fully occupied. |
| **Byte 11** | **0 / 8** | *None* | **COMPLETELY UNUSED** | **8 Free Modder Bits** (`1..128`). |
| **Byte 12** | 8 / 8 | `1, 2, 4, 8, 16, 32, 64, 128` | **Cave of the Wind** (`vd06`) | Fully occupied (8 chests). |
| **Byte 13** | **0 / 8** | *None* | **COMPLETELY UNUSED** | **8 Free Modder Bits** (`1..128`). |
| **Byte 14** | **0 / 8** | *None* | **COMPLETELY UNUSED** | **8 Free Modder Bits** (`1..128`). |
| **Byte 15** | **0 / 8** | *None* | **COMPLETELY UNUSED** | **8 Free Modder Bits** (`1..128`). |
| **Byte 16** | 6 / 8 | `4, 8, 16, 32, 64, 128` | **South Window & Forest Village** (`vd03`, `ve02`) | Bits `1, 2` are **FREE**. |
| **Byte 17** | 8 / 8 | `1, 2, 4, 8, 16, 32, 64, 128` | **Ryube Forest, Swallow Pass, Two River Sewers** (`vb07`, `vb08`, `vb17`, `vb21`, `vh04`) | `vb08`, `vb17`, and `vb21` are story variants of Mt. Tigerwolf. |
| **Byte 18** | 8 / 8 | `1, 2, 4, 8, 16, 32, 64, 128` | **Two River Sewers, Tinto Mines, Tiger Cave** (`vh04`, `vg11`, `vg15`) | Fully occupied. |
| **Byte 19** | 8 / 8 | `1, 2, 4, 8, 16, 32, 64, 128` | **Tiger Cave, Tinto, Greenhill Trail** (`ve03`, `ve15`, `vg02`, `vg15`) | Fully occupied. |
| **Byte 20** | 7 / 8 | `1, 2, 4, 8, 16, 32, 64` | **Greenhill & Drakemouth** (`ve04`, `ve08`, `ve14`, `vg04`) | Bit `128` is **FREE**. (`ve08`/`ve14` are story variants). |
| **Byte 21** | 3 / 8 | `1, 2, 4` | **Greenhill** (`ve08`) | Bits `8, 16, 32, 64, 128` (5 bits) are **FREE**. |
| **Byte 22** | 6 / 8 | `1, 2, 4, 8, 16, 32` | **New Leaf Academy, Lakewest, Two River** (`ve07`, `vh02`, `vh05`) | Bits `64, 128` (2 bits) are **FREE**. |
| **Byte 23** | 7 / 8 | `1, 2, 4, 8, 16, 64, 128` | **Academy, Forest Village, Tinto, Crom** (`ve06`, `ve10`, `vg01`, `vg08`, `vg13`, `vg17`) | Bit `32` is **FREE** (Bit `1` is used by `vg08` Ev 98). |
| **Byte 24** | 7 / 8 | `2, 4, 8, 16, 32, 64, 128` | **Academy, Drakemouth, Tinto Mines** (`ve07`, `vg06`, `vg07`) | Bit `1` is **FREE**. |
| **Byte 25** | **0 / 8** | *None* | **COMPLETELY UNUSED** | **8 Free Modder Bits** (`1..128`). |
| **Byte 26** | 5 / 8 | `1, 2, 4, 8, 16` | **North Sparrow Pass** (`vd19`) | Bits `32, 64, 128` (3 bits) are **FREE**. |
| **Byte 27–31**| **0 / 40**| *None* | **COMPLETELY UNUSED (5 Bytes)** | **40 Free Modder Bits** (Bytes `27, 28, 29, 30, 31`). |

---

## 4. Shared Flags Across Map State Variants

Several dungeons and towns have multiple map asset files representing different story phases or seasonal states. Chests in these paired maps **intentionally share the same `(ByteIndex, BitMask)`** so a chest looted in one story state stays looted in later story states:
- **Sindar Ruins (`vc12` & `vc13`)**: Share all 10 chest flags across `Byte 0` and `Byte 1`.
- **Ryube Forest & Swallow Pass (`vb08`, `vb17` & `vb21`)**: Story state variants that share the same submap layouts, coordinates (`(23, 16)`, `(105, 68)`, `(90, 86)`, `(61, 13)`), and chest flags in `Byte 17`.
- **Greenhill (`ve08` & `ve14`)**: Share flags in `Byte 20` (`Bits 1, 2, 4`).
- **Tinto City (`vg01` & `vg17`)**: Share `Byte 23, Bit 64` (Earth Emblem).
- **Greenhill-Matilda Trail (`ve03` & `ve15`)**: Share `Byte 19, Bit 128`.

> **Patching Rule**: If you patch a chest's item reward or flag in one map variant (e.g., `vc12` or `vb08`), **always apply the same patch to its counterpart variants (`vc13`, `vb17`, `vb21`)** so the chest behavior stays synchronized across acts!

---

## 5. Ready-to-Use C# Patch Templates for PKCore

Below are three modular ways we can patch chests and `t_box_flag` in PKCore depending on your goal.

### Pattern A: Remapping Chest Flags or Rewards in `MACHICON.EventInit`
When adding new chests or reassigning a chest's flag to one of the **10 unused `t_box_flag` bytes** (such as `Byte 11`, `Byte 13–15`, `Byte 25`, or `Byte 27–31`), hook `MACHICON.EventInit` (`[HarmonyPostfix]`) and update:
1. The closed & open chest object preconditions in `submap.eventobj[i].eventForm` (Opcodes `27` and `28`).
2. The chest interaction script precondition in `submap.eventdat[e].eventForm` (Opcode `28`).
3. The chest loot flag setter in `submap.eventdat[e].eventCom` (Opcode `96` / `ECTkFlgSet`).

```csharp
private static void RelocateChestFlag(MACHIDAT mdat, int submapIdx, byte oldByte, byte oldBit, byte newByte, byte newBit)
{
    var submap = mdat.eventdata?.mapeventdat?[submapIdx];
    if (submap == null) return;

    // 1. Patch eventForm on map objects (closed/open chest sprite visibility)
    if (submap.eventobj != null)
    {
        foreach (var obj in submap.eventobj)
        {
            PatchEventFormFlag(obj?.eventForm, oldByte, oldBit, newByte, newBit);
        }
    }

    // 2. Patch eventForm and eventCom on event scripts
    if (submap.eventdat != null)
    {
        foreach (var ev in submap.eventdat)
        {
            if (ev == null) continue;
            PatchEventFormFlag(ev.eventForm, oldByte, oldBit, newByte, newBit);
            PatchEventComFlag(ev.eventCom, oldByte, oldBit, newByte, newBit);
        }
    }
}

private static void PatchEventFormFlag(Il2CppStructArray<byte> form, byte oldByte, byte oldBit, byte newByte, byte newBit)
{
    if (form == null || form.Length < 3) return;
    for (int i = 0; i < form.Length - 2; i++)
    {
        // Opcode 27 (0x1B = TkFlg On) or Opcode 28 (0x1C = TkFlg Off)
        if ((form[i] == 27 || form[i] == 28) && form[i + 1] == oldByte && form[i + 2] == oldBit)
        {
            form[i + 1] = newByte;
            form[i + 2] = newBit;
        }
    }
}

private static void PatchEventComFlag(Il2CppStructArray<byte> com, byte oldByte, byte oldBit, byte newByte, byte newBit)
{
    if (com == null || com.Length < 3) return;
    for (int i = 0; i < com.Length - 2; i++)
    {
        // Opcode 96 (0x60 = ECTkFlgSet) or Opcode 97 (0x61 = ECTkFlgOff)
        if ((com[i] == 96 || com[i] == 97) && com[i + 1] == oldByte && com[i + 2] == oldBit)
        {
            com[i + 1] = newByte;
            com[i + 2] = newBit;
        }
    }
}
```

### Pattern B: Direct Runtime `t_box_flag` Manipulation (Helper API)
For features like **New Game+ Chest Reset**, **Respawning Dungeon Chests**, or **ImGui Debug Overlay**, we can manipulate `GAME_WORK.t_box_flag` directly in memory:

```csharp
public static class TreasureChestFlagHelper
{
    public static bool IsChestOpened(int byteIndex, byte bitMask)
    {
        var flags = GSD2.OldSrcBase.game_work?.t_box_flag;
        if (flags == null || byteIndex < 0 || byteIndex >= flags.Length)
            return false;
        return (flags[byteIndex] & bitMask) != 0;
    }

    public static void SetChestOpened(int byteIndex, byte bitMask, bool opened)
    {
        var flags = GSD2.OldSrcBase.game_work?.t_box_flag;
        if (flags == null || byteIndex < 0 || byteIndex >= flags.Length)
            return;

        if (opened)
            flags[byteIndex] |= bitMask;
        else
            flags[byteIndex] = (byte)(flags[byteIndex] & ~bitMask);
    }

    /// <summary>
    /// Resets all 256 treasure chest flags to unopened (0x00).
    /// </summary>
    public static void ResetAllChests()
    {
        var flags = GSD2.OldSrcBase.game_work?.t_box_flag;
        if (flags == null) return;
        for (int i = 0; i < flags.Length; i++)
        {
            flags[i] = 0;
        }
    }
}
```

### Pattern C: Hooking `EVENTCON.ECTkFlgSet` for Live Chest Loot Logging / Intercept
If you want to log whenever a player loots a chest in real time or trigger custom logic when a specific chest is opened:

```csharp
[HarmonyPatch(typeof(GSD2.EVENTCON), nameof(GSD2.EVENTCON.ECTkFlgSet))]
public static class EVENTCON_ECTkFlgSet_Patch
{
    [HarmonyPrefix]
    public static void Prefix(GSD2.EVENTCON __instance, sbyte cno)
    {
        var cl = __instance.EventClLine?[cno];
        if (cl?.ComTbl == null) return;

        // Peek at the next two bytes in the command stream without advancing:
        int pos = cl.compos;
        if (pos + 1 < cl.ComTbl.Length)
        {
            byte byteIndex = cl.ComTbl[pos];
            byte bitMask = cl.ComTbl[pos + 1];
            Plugin.Log.LogInfo($"[ChestOpened] Map={MACHICON_OnMapInitPatch.CurrentMapId}, t_box_flag[{byteIndex}] |= {bitMask} (0x{bitMask:X2})");
        }
    }
}
```
