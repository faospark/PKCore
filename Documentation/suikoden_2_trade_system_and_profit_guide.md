# Suikoden II Trade System (`koueki`) — Complete Engine Analysis & Profit Guide

## Overview

Suikoden II features a full dynamic commodity trading system (`koueki`) spanning **9 active Trading Posts** (plus 1 unused/dummy Trading Post table in Tinto City `vg03`), **52 defined `TRADE_DATA` entries** (antiques, seasonings, specialties, and rare goods), **24 scripted market events (`KEVE_DATA`)**, real-time stock decay/recovery timers, supply-and-demand price elasticity, and weighted-average cost tracking.

This guide documents every verified formula, table, constraint, and optimal profit strategy extracted directly from `GSD2.dll`, `Mobobehaviour/Shared/gamedata.json`, `Mobobehaviour/Suikoden2/*.json`, and `TextAsset/text_gsd2_en`.

---

## 1. Engine Architecture & Data Structures

| Class / Struct | Source / Location | Role |
|---|---|---|
| `koueki` | `GSD2.dll` (`OverlayClassBase`) | Main Trading Post UI, transaction, stock, and price controller |
| `KOUEKICON` | `GSD2.dll` | Runtime session state (`miseno`, `hin[]`, `kdat`, `gdat`, `sagaku`, `kintmp`, `kinbak`) |
| `SHOP_KOUEKI` | `ETC_SHOP_KOUEKI` in map JSONs | Per-town store config (`koukaz` item count, `shstim` update interval, `SK_KOUE[] hin`, `int[] d_msg`) |
| `SK_KOUE` | `SHOP_KOUEKI.hin[i]` | Per-item slot config (`sno`, `dno`, `typ`, `kihkaz`, `zaihab`, `zaiftim`, `kihkak`) |
| `KOUEKI_DATA` | Save / `GAME_DATA` | Persistent per-town state: `ushort kouek_stim` (last update timestamp) and `byte[] zai` (current stock) |
| `TRADE_DATA` | `OVIT_DATA.trade_data[52]` (`gamedata.json`) | Global trade/antique item definitions (`name`, `text`, `info`, `botch`) |
| `KEVE_DATA` | `koueki.keve_data[24]` | Market surge/crash event definitions (`ano`, `vno`, `ktyp`, `sno`, `dno`, `hekaz`, `bai`) |

---

## 2. All Factors Affecting Stock & Prices (`koueki.SKZaikoCheck`)

When you open a Trading Post, `koueki.SKZaikoCheck` (`0x181D9A210`) computes the current stock and price for every item slot `i` (`0 .. koukaz - 1`).

### A. Real-Time Update Interval (`shstim` & `kouek_stim`)
1. The engine reads the current play time in minutes via `MACHICON.MachiPlayMin` (`0x1818C36A0`).
2. It computes elapsed minutes since the town's last market update (`kdat.kouek_stim`, wrapping cleanly at `0x10000`):
   $$\Delta t = (\text{now\_min} - \text{kouek\_stim}) \bmod 65536$$
3. **If $\Delta t \le \text{shop\_koueki.shstim}$:**
   - **No restock and no price recalculation occur.**
   - The shop reuses its saved stock `kdat.zai[dno]` and saved price `game_data.koueki_ave[miseno][dno]`.
4. **If $\Delta t > \text{shop\_koueki.shstim}$:**
   - Stock and prices are recalculated using the formulas below.
   - Because each town has its own `shstim` (ranging from **3 minutes** in Highway Village to **8 minutes** in Gregminster), visiting at least every few minutes of real play time triggers fresh market ticks.

### B. Stock Recovery, Decay & Random Variance (`kihkaz`, `zaiftim`, `zaihab`)
For each slot `i` with base equilibrium stock `kihkaz`, recovery period `zaiftim` (minutes), and variance `zaihab`:

1. **Time-Based Drift Toward Equilibrium (`kihkaz`):**
   If $\Delta t > \text{zaiftim}$:
   $$\text{steps} = \left\lfloor \frac{\Delta t}{\text{zaiftim}} \right\rfloor$$
   - If current stock `zai >= kihkaz` (player oversupplied the shop):
     $$\text{zai} \leftarrow \text{zai} - \text{steps}$$
   - If current stock `zai < kihkaz` (player bought out the shop):
     $$\text{zai} \leftarrow \min(\text{zai} + \text{steps},\ \text{kihkaz})$$
   - *Practical takeaway:* Buying out a high-margin item (`zaiftim = 15..40` min) means it only recovers **1 unit per `zaiftim` minutes**. Conversely, dumping dozens of units into a shop takes `zaiftim` minutes per unit to decay back down.

2. **Random Stock Jitter (`zaihab`):**
   Using `OldSrcBase.get_rand_maxlimit(1)` (`r` in `{0, 1}`):
   $$\text{zai} \leftarrow \text{zai} + (r \cdot \text{zaihab}) - \left\lfloor \frac{\text{zaihab}}{2} \right\rfloor$$
   - Even if `kihkaz == 0` (normally out of stock), a positive `zaihab` allows 1–2 units to occasionally appear.
   - If `kihkaz == -1`, the slot is a **demand/sell-only slot** (stock stays 0; the player cannot buy it here, only sell it here if they bring it from elsewhere or monster drops).

3. **Market Event Stock Modifier (`SKKeventCheck3`):**
   If an active `KEVE_DATA` event matches the shop and item:
   $$\text{zai} \leftarrow \text{clamp}(\text{zai} + \text{keve.hekaz},\ 0,\ 255)$$

### C. Supply-and-Demand Price Formula (`kihkak`, `kihkaz`, `zai`)
Let `kihkak` be the item's base price at that specific Trading Post and `stock` be the updated `zai`:

1. **Target Price Calculation:**
   - If `kihkaz > 0`:
     $$\text{raw\_delta} = (\text{kihkaz} - \text{stock}) \times \text{kihkak}$$
   - If `kihkaz <= 0`:
     $$\text{raw\_delta} = (-\text{stock}) \times \text{kihkak}$$
   - Elasticity divisor $D = \max(\text{kihkaz},\ 3)$:
     $$\text{target\_price} = \text{kihkak} + \left\lfloor \frac{\text{raw\_delta}}{D} \right\rfloor$$
   - Clamped to $\le 65{,}000$ (`0xFDE8`).
   - *Key insight:*
     - **Buying out** a shop (`stock` drops below `kihkaz`) **raises** the price there.
     - **Selling** to a shop (`stock` rises above `kihkaz` via `SMNanyesnoOk` / `SMKaiOk`) **crashes** the price there! For every unit above `kihkaz`, the target price drops by `kihkak / max(kihkaz, 3)`.

2. **Historical Price Smoothing (Inertia):**
   Let $p = \min\left(\left\lfloor \frac{\Delta t}{\text{shstim}} \right\rfloor,\ 4\right)$ (number of `shstim` periods elapsed, capped at 4):
   $$\text{smoothed} = \text{prev\_price} + \left\lfloor \frac{(\text{target\_price} - \text{prev\_price}) \cdot p}{4} \right\rfloor$$
   - Each `shstim` interval moves the price **25%** of the way toward the new target price (100% if $\ge 4 \times \text{shstim}$ minutes have passed).

3. **Random Jitter & Hard Bounds:**
   Adds `get_rand_maxlimit(10) - 5` (a small `-5` to `+4` potch wobble), then clamps:
   $$\text{price} = \text{clamp}\left(\text{smoothed} + \text{jitter},\ \left\lfloor \frac{\text{kihkak}}{3} \right\rfloor,\ 65{,}000\right)$$
   - No matter how much you flood a shop, a Trading Post price will **never drop below `1/3` (`33.3%`) of `kihkak`**, nor exceed **65,000 potch**.

4. **Market Event Multiplier (`SKKeventCheck2`):**
   If a `KEVE_DATA` event is active for that town/item (`SHOP_DATA.event_no`), the final price is multiplied by $\text{keve.bai} / 10$:
   $$\text{final\_price} = \left\lfloor \frac{\text{price} \times \text{keve.bai}}{10} \right\rfloor$$
   - Multipliers range from **0.2x** (`bai = 2`, 80% discount!) up to **6.0x** (`bai = 60`, 600% surge!).

---

## 3. Player Inventory, Average Cost & Gordon Recruitment Mechanics

Verified directly from `koueki.SMNanyesnoOk` (`0x181DA1060`) and `koueki.SMKaiOk` (`0x181D9DAA0`):

- **Bag Capacity Limit (30 items):** When buying (`kcon+0x30 == 0`), `SMNanyesnoOk` checks `qty + fkkaz <= 30` (`0x1E`). Trade goods occupy normal Bag slots, so empty your Bag at Barbara's Warehouse before bulk runs.
- **Weighted Average Purchase Price (`koueki_ave`):** Every time you buy `qty` units at `price`, the game sums your total owned quantity across Party + Bag + Warehouse (`G2_item_num2(0..4, kind, dno)`) and updates `game_data + 0x140`:
  $$\text{new\_ave} = \frac{\text{old\_ave} \times \text{owned\_qty} + \text{price} \times \text{qty}}{\text{owned\_qty} + \text{qty}}$$
  The UI uses this stored average to display your estimated profit/loss (`sagaku`).
- **Gordon's 50,000 Potch Requirement (`AddTradeTransactionAmount`, `0x181D99D80`):**
  - Gordon (found in Gregminster `vf03_13`, Gordon's Mercantile) joins once `game_data + 0x1AC` reaches **50,000 potch** (`1006020092`).
  - **Crucial Engine Fact:** `AddTradeTransactionAmount(uint money)` is called on **BOTH buying AND selling** in `SMNanyesnoOk` with the full transaction potch (`qty * price`)! That means **total trade volume (buys + sells)** counts toward the 50,000 potch threshold, not just net profit. Buying 25,000 potch worth of goods and selling them for 25,000+ potch immediately hits 50,000+ potch.

---

## 4. All 24 Market Events (`koueki.keve_data`) & Rumors (`uwasa`)

`koueki..ctor` (`0x181DAAA60`) defines 24 `KEVE_DATA` entries (`0` = none, `1..23` = active events). Area `0xFE` affects **all** Trading Posts globally; specific `(ano, vno)` pairs affect only one town.

| ID | Scope (`ano, vno`) | Town | Item (`dno`) | Stock Mod (`hekaz`) | Price Mult (`bai / 10`) | Rumor Hint (`text_gsd2_en`) |
|---|---|---|---|---|---|---|
| `0` | — | None | — | `0` | `—` | No active event |
| `1` | Global (`0xFE`) | All | Salt (`24`) | `+2` | **0.2x** | *"Salt is super cheap right now."* (`3281`) |
| `2` | Global (`0xFE`) | All | Salt (`24`) | `-2` | **3.0x** | *"No matter where ya go, ya can't find salt anywhere."* (`3282`) |
| `3` | Global (`0xFE`) | All | Sugar (`23`) | `+2` | **0.2x** | *"Lately there's so much sugar around everywhere."* (`3283`) |
| `4` | Global (`0xFE`) | All | Sugar (`23`) | `-2` | **2.5x** | *"Everyone is going crazy trying to find sugar these days."* (`3284`) |
| `5` | Global (`0xFE`) | All | Soy Sauce (`25`) | `+2` | **0.3x** | *"The price of soy sauce has plummeted everywhere."* (`3285`) |
| `6` | Global (`0xFE`) | All | Soy Sauce (`25`) | `-2` | **3.5x** | *"It's so hard to find soy sauce right now."* (`3286`) |
| `7` | Global (`0xFE`) | All | Mayonnaise (`26`) | `-3` | **3.0x** | *"Mayonnaise seems to have just vanished off the market."* (`3287`) |
| `8` | Global (`0xFE`) | All | Red Pepper (`27`) | `-3` | **2.5x** | *"I can't find red pepper anywhere!"* (`3288`) |
| `9` | Global (`0xFE`) | All | Wine (`34`) | `0` | **1.8x** | *"There's a real wine shortage."* (`3289`) |
| `10` | `(7, 2)` | Kobold Village | Mayonnaise (`26`) | `+2` | **0.3x** | *"'Mayonnaise festival' in Kobold Village."* (`3290`) |
| `11` | `(6, 12)` | Crom Village | Book (`36`) | `-1` | **1.5x** | *"They're after all the books they can get."* (`3291`) |
| `12` | `(5, 2)` | Gregminster | Ancient Text (`40`) | `+3` | **0.5x** | *"Ancient text sale going on in the Toran Republic."* (`3292`) |
| `13` | `(3, 16)` | South Window | Candle (`28`) | `-3` | **5.0x** | *"It's tough to get candles in South Window right now."* (`3293`) |
| `14` | `(4, 1)` | Forest Village | Fur (`29`) | `-5` | **1.3x** | *"Trappers in Forest Village can't get any furs."* (`3294`) |
| `15` | `(4, 1)` | Forest Village | Flute (`30`) | `-2` | **3.0x** | *"Flutes are real popular in Forest Village now."* (`3295`) |
| `16` | `(4, 1)` | Forest Village | Wine (`34`) | `+2` | **0.7x** | *"Terrific wine harvest in Forest Village this year."* (`3296`) |
| `17` | `(7, 2)` | Kobold Village | Flute (`30`) | `-3` | **6.0x** | *"They're selling flutes like hotcakes in Kobold Village."* (`3297`) |
| `18` | `(7, 2)` | Kobold Village | Crystal Ball (`38`) | `-1` | **3.0x** | *"Crystal balls are all the rage in Kobold Village."* (`3298`) |
| `19` | `(6, 12)` | Crom Village | Gold Bar (`41`) | `+2` | **0.8x** | *"New gold vein in Tinto... lower the price of gold."* (`3299`) |
| `20` | `(3, 16)` | South Window | Persian Lamp (`9`) | `+2` | **0.5x** | *"They're selling antiques there cheap."* (`3300`) |
| `21` | Global (`0xFE`) | All | Book (`36`) | `-3` | **1.5x** | *"Since Greenhill was taken over by Highland, no books."* (`3301`) |
| `22` | Global (`0xFE`) | All | Salt (`24`) | `-3` | **4.0x** | *"Luca Blight took over, can't find salt in South Window."* (`3302`) |
| `23` | Global (`0xFE`) | All | Gold Bar (`41`) | `-1` | **2.0x** | *"They've stopped all the mining operations in Tinto!"* (`3303`) |

> [!TIP]
> **Biggest Event Exploits:**
> - **Event #17 (Kobold Flute Boom, `6.0x`):** Flutes cost **200 potch** at Castle HQ (Gordon) or **300 potch** at Rokkaku and sell for **2,400 potch** (`400 * 6.0`) in Kobold Village!
> - **Event #13 (South Window Candle Shortage, `5.0x`):** Candles cost **200 potch** at Rokkaku or **350 potch** at Highway Village and sell for **2,500 potch** (`500 * 5.0`) in South Window!
> - **Event #18 (Kobold Crystal Ball Craze, `3.0x`):** Crystal Balls (7,000 base at Kobold) surge to **21,000 potch**!
> - **Event #12 (Gregminster Ancient Text Sale, `0.5x`):** Ancient Texts drop to **11,000 potch** in Gregminster and sell for **35,000 potch** in Forest Village (**+24,000 profit/unit**)!

---

## 5. Complete `TRADE_DATA` Catalog (All 52 Entries)

`OVIT_DATA.trade_data` contains 52 slots (`0..51`). Entries `1..22` and `42..50` are **Antiques** (`botch > 0`; normal Appraisers pay `botch / 2` via `SMSitadoriFunc1`). Entries `23..41` are **Pure Trade Goods** (`botch == 0`; can only be bought/sold at Trading Posts).

| `dno` | Name | Category (`info`) | Appraiser `botch` (Sell = `botch/2`) | Description |
|---|---|---|---|---|
| `1` | Defective Urn | `10` (Urn) | `2` (`1`) | Antique, Urn |
| `2` | Octopus Pot | `10` (Urn) | `100` (`50`) | Antique, Urn |
| `3` | Flower Vase | `10` (Urn) | `500` (`250`) | Antique, Urn |
| `4` | Wide Urn | `10` (Urn) | `800` (`400`) | Antique, Urn |
| `5` | Blue Dragon Urn | `10` (Urn) | `1,600` (`800`) | Antique, Urn |
| `6` | Celadon Urn | `10` (Urn) | `2,000` (`1,000`) | Antique, Urn |
| `7` | Black Urn | `10` (Urn) | `4,000` (`2,000`) | Antique, Urn |
| `8` | Fine China | `10` (Urn) | `12,000` (`6,000`) | Antique, Urn |
| `9` | Persian Lamp | `10` (Urn) | `1,500` (`750`) | Antique, Urn |
| `10` | Hex Doll | `12` (Ornament) | `12` (`6`) | Antique, Ornament |
| `11` | Japanese Dish | `12` (Ornament) | `600` (`300`) | Antique, Ornament |
| `12` | Chinese Dish | `12` (Ornament) | `1,200` (`600`) | Antique, Ornament |
| `13` | Peeing Boy | `12` (Ornament) | `3,200` (`1,600`) | Antique, Ornament |
| `14` | Bonsai Tree | `12` (Ornament) | `5,000` (`2,500`) | Antique, Ornament |
| `15` | Knight Statue | `12` (Ornament) | `6,000` (`3,000`) | Antique, Ornament |
| `16` | Goddess Statue | `12` (Ornament) | `20,000` (`10,000`) | Antique, Ornament |
| `17` | Coral | `12` (Ornament) | `4,000` (`2,000`) | Antique, Ornament |
| `18` | Graffiti | `9` (Painting) | `20` (`10`) | Antique, Painting |
| `19` | Flower Painting | `9` (Painting) | `1,400` (`700`) | Antique, Painting |
| `20` | Lovers' Garden | `9` (Painting) | `5,800` (`2,900`) | Antique, Painting |
| `21` | Landscape Scroll | `9` (Painting) | `8,000` (`4,000`) | Antique, Painting |
| `22` | Beauties of Nature | `9` (Painting) | `40,000` (`20,000`) | Antique, Painting |
| `23` | **Sugar** | `37` (Seasoning) | `0` | Seasoning |
| `24` | **Salt** | `37` (Seasoning) | `0` | Seasoning |
| `25` | **Soy Sauce** | `37` (Seasoning) | `0` | Seasoning |
| `26` | **Mayonnaise** | `37` (Seasoning) | `0` | Seasoning |
| `27` | **Red Pepper** | `37` (Seasoning) | `0` | Seasoning |
| `28` | **Candle** | `6` (Trade Good) | `0` | Seal fat candle |
| `29` | **Fur** | `6` (Trade Good) | `0` | Pretty fur |
| `30` | **Flute** | `6` (Trade Good) | `0` | Bamboo flute |
| `31` | **Wooden Amulet** | `6` (Trade Good) | `0` | Protection amulet |
| `32` | **Traditional Clothing** | `6` (Trade Good) | `0` | Colorful folk dress |
| `33` | **Holly Berry** | `6` (Trade Good) | `0` | Living Holly Berry |
| `34` | **Wine** | `6` (Trade Good) | `0` | Produced in Kanakan |
| `35` | **Deer Antler** | `6` (Trade Good) | `0` | Medicinal ingredient |
| `36` | **Book** | `6` (Trade Good) | `0` | Transcribed by hand |
| `37` | **Musk** | `6` (Trade Good) | `0` | Perfume |
| `38` | **Crystal Ball** | `6` (Trade Good) | `0` | Shining crystal ball |
| `39` | **Pearl** | `6` (Trade Good) | `0` | Specialty of the Island Nations |
| `40` | **Ancient Text** | `6` (Trade Good) | `0` | Left by the Sindar people |
| `41` | **Gold Bar** | `6` (Trade Good) | `0` | Gold ingot |
| `42–50` | Special Antiques | `9 / 10 / 12` | `1` – `22,000` | Karen Painting A/B, Trio Painting, Karen Statue A/B/C, Nanami's Vase, Large Urn, Famous Urn |

> [!IMPORTANT]
> **Never sell Trading Post Antiques to an Appraiser (`botch / 2`)!**
> For example, **Peeing Boy** has `botch = 3,200` (Appraisers pay **1,600 potch**), while Rockaxe's Trading Post pays **43,000 potch**! **Coral** has `botch = 4,000` (Appraisers pay **2,000 potch**), while Rockaxe's Trading Post pays **55,000 potch**!

---

## 6. Complete Trading Post Store Tables (All 9 Active Towns + Unused `vg03`)

### 1. South Window (`vd17`) — `shstim = 5 min`
Area reference: [south_window_city.md](areas/south_window_city.md)

| Slot | `dno` | Item | Base Stock (`kihkaz`) | Variance (`zaihab`) | Recovery (`zaiftim`) | Base Price (`kihkak`) |
|---|---|---|---|---|---|---|
| 0 | `24` | Salt | `15` | `4` | `4 min` | `270` |
| 1 | `26` | Mayonnaise | `4` | `2` | `5 min` | `400` |
| 2 | `38` | Crystal Ball | `-1` (Sell-only) | `3` | `25 min` | `400` |
| 3 | `28` | Candle | `7` | `4` | `3 min` | `500` |
| 4 | `31` | Wooden Amulet | `2` | `4` | `3 min` | `700` |
| 5 | `29` | Fur | `3` | `0` | `3 min` | `800` |
| 6 | `32` | Traditional Clothing | `2` | `1` | `5 min` | `1,900` |
| 7 | `12` | Chinese Dish | `1` | `2` | `25 min` | `12,000` |
| 8 | `19` | Flower Painting | `1` | `0` | `18 min` | `14,000` |
| 9 | `9` | Persian Lamp | `0` | `2` | `45 min` | `15,000` |
| 10 | `5` | Blue Dragon Urn | `1` | `0` | `22 min` | `16,000` |
| 11 | `13` | Peeing Boy | `1` | `0` | `12 min` | `32,000` |
| 12 | `17` | Coral | `-1` (Sell-only) | `3` | `60 min` | `40,000` |

### 2. Forest Village (`ve02`) — `shstim = 6 min`
Area reference: [forest_village.md](areas/forest_village.md)

| Slot | `dno` | Item | Base Stock (`kihkaz`) | Variance (`zaihab`) | Recovery (`zaiftim`) | Base Price (`kihkak`) |
|---|---|---|---|---|---|---|
| 0 | `23` | Sugar | `25` | `5` | `4 min` | `150` |
| 1 | `24` | Salt | `8` | `2` | `6 min` | `550` |
| 2 | `29` | Fur | `4` | `2` | `7 min` | `400` |
| 3 | `38` | Crystal Ball | `-1` (Sell-only) | `3` | `35 min` | `500` |
| 4 | `30` | Flute | `3` | `1` | `4 min` | `550` |
| 5 | `33` | Holly Berry | `4` | `6` | `5 min` | `550` |
| 6 | `34` | Wine | `2` | `1` | `4 min` | `1,000` |
| 7 | `35` | Deer Antler | `-1` (Sell-only) | `3` | `15 min` | `1,100` |
| 8 | `32` | Traditional Clothing | `3` | `0` | `6 min` | `1,200` |
| 9 | `36` | Book | `2` | `0` | `40 min` | `3,500` |
| 10 | `40` | Ancient Text | `0` | `1` | `20 min` | `35,000` |
| 11 | `3` | Flower Vase | `3` | `2` | `20 min` | `6,700` |
| 12 | `4` | Wide Urn | `3` | `3` | `23 min` | `9,500` |

### 3. Kobold Village (`vh03`) — `shstim = 4 min`
Area reference: [kobold_village.md](areas/kobold_village.md)

| Slot | `dno` | Item | Base Stock (`kihkaz`) | Variance (`zaihab`) | Recovery (`zaiftim`) | Base Price (`kihkak`) |
|---|---|---|---|---|---|---|
| 0 | `23` | Sugar | `10` | `2` | `4 min` | `350` |
| 1 | `26` | Mayonnaise | `3` | `0` | `5 min` | `1,500` |
| 2 | `31` | Wooden Amulet | `5` | `2` | `2 min` | `350` |
| 3 | `30` | Flute | `4` | `3` | `3 min` | `400` |
| 4 | `28` | Candle | `3` | `2` | `4 min` | `600` |
| 5 | `40` | Ancient Text | `-1` (Sell-only) | `3` | `40 min` | `700` |
| 6 | `38` | Crystal Ball | `0` | `1` | `15 min` | `7,000` |
| 7 | `1` | Defective Urn | `4` | `3` | `330 min` | `330` |
| 8 | `18` | Graffiti | `3` | `4` | `850 min` | `850` |

### 4. Rokkaku Hamlet (`vf01`) — `shstim = 5 min`
Area reference: [rokkaku_hamlet.md](areas/rokkaku_hamlet.md)

| Slot | `dno` | Item | Base Stock (`kihkaz`) | Variance (`zaihab`) | Recovery (`zaiftim`) | Base Price (`kihkak`) |
|---|---|---|---|---|---|---|
| 0 | `25` | Soy Sauce | `12` | `2` | `5 min` | `300` |
| 1 | `24` | Salt | `6` | `2` | `6 min` | `700` |
| 2 | `28` | Candle | `5` | `2` | `5 min` | `200` |
| 3 | `30` | Flute | `4` | `2` | `2 min` | `300` |
| 4 | `38` | Crystal Ball | `-1` (Sell-only) | `3` | `15 min` | `400` |
| 5 | `37` | Musk | `3` | `4` | `20 min` | `7,000` |
| 6 | `41` | Gold Bar | `-1` (Sell-only) | `3` | `20 min` | `17,000` |
| 7 | `35` | Deer Antler | `2` | `2` | `15 min` | `3,500` |
| 8 | `11` | Japanese Dish | `3` | `3` | `27 min` | `8,500` |

### 5. Gregminster (`vf03`) — `shstim = 8 min`
Area reference: [gregminster_interiors.md](areas/gregminster_interiors.md) (`vf03_13`, Gordon's Mercantile)

| Slot | `dno` | Item | Base Stock (`kihkaz`) | Variance (`zaihab`) | Recovery (`zaiftim`) | Base Price (`kihkak`) |
|---|---|---|---|---|---|---|
| 0 | `25` | Soy Sauce | `5` | `1` | `3 min` | `850` |
| 1 | `31` | Wooden Amulet | `3` | `3` | `4 min` | `600` |
| 2 | `34` | Wine | `3` | `1` | `4 min` | `650` |
| 3 | `32` | Traditional Clothing | `4` | `2` | `3 min` | `800` |
| 4 | `27` | Red Pepper | `4` | `3` | `5 min` | `2,350` |
| 5 | `40` | Ancient Text | `1` | `2` | `25 min` | `22,000` |
| 6 | `39` | Pearl | `0` | `1` | `40 min` | `24,000` |
| 7 | `9` | Persian Lamp | `0` | `2` | `50 min` | `16,000` |
| 8 | `19` | Flower Painting | `3` | `2` | `28 min` | `16,000` |
| 9 | `6` | Celadon Urn | `2` | `3` | `25 min` | `23,000` |

### 6. Dunan Castle HQ (`vk02`) — `shstim = 5 min` (Requires Gordon)
Area reference: [dunan_castle_hq_shopping_area.md](areas/dunan_castle_hq_shopping_area.md)

| Slot | `dno` | Item | Base Stock (`kihkaz`) | Variance (`zaihab`) | Recovery (`zaiftim`) | Base Price (`kihkak`) |
|---|---|---|---|---|---|---|
| 0 | `25` | Soy Sauce | `5` | `1` | `4 min` | `680` |
| 1 | `30` | Flute | `5` | `2` | `2 min` | `200` |
| 2 | `29` | Fur | `3` | `2` | `6 min` | `350` |
| 3 | `33` | Holly Berry | `4` | `4` | `5 min` | `700` |
| 4 | `34` | Wine | `4` | `2` | `2 min` | `1,200` |
| 5 | `35` | Deer Antler | `3` | `2` | `15 min` | `5,500` |
| 6 | `39` | Pearl | `0` | `3` | `20 min` | `18,000` |
| 7 | `2` | Octopus Pot | `2` | `3` | `15 min` | `3,500` |
| 8 | `13` | Peeing Boy | `1` | `0` | `40 min` | `22,000` |

### 7. Highway Village (`vi12`) — `shstim = 3 min`
Area reference: [highway_village.md](areas/highway_village.md)

| Slot | `dno` | Item | Base Stock (`kihkaz`) | Variance (`zaihab`) | Recovery (`zaiftim`) | Base Price (`kihkak`) |
|---|---|---|---|---|---|---|
| 0 | `23` | Sugar | `8` | `2` | `6 min` | `550` |
| 1 | `26` | Mayonnaise | `4` | `3` | `5 min` | `2,200` |
| 2 | `28` | Candle | `4` | `3` | `2 min` | `350` |
| 3 | `32` | Traditional Clothing | `3` | `1` | `7 min` | `2,500` |
| 4 | `35` | Deer Antler | `2` | `0` | `20 min` | `4,000` |
| 5 | `36` | Book | `2` | `3` | `15 min` | `4,000` |
| 6 | `37` | Musk | `3` | `4` | `10 min` | `4,500` |
| 7 | `41` | Gold Bar | `1` | `0` | `15 min` | `40,000` |

### 8. Rockaxe (`vi02`) — `shstim = 5 min`
Area reference: [rockaxe_citadel_and_castle.md](areas/rockaxe_citadel_and_castle.md)

| Slot | `dno` | Item | Base Stock (`kihkaz`) | Variance (`zaihab`) | Recovery (`zaiftim`) | Base Price (`kihkak`) |
|---|---|---|---|---|---|---|
| 0 | `27` | Red Pepper | `3` | `3` | `5 min` | `3,200` |
| 1 | `30` | Flute | `3` | `1` | `5 min` | `700` |
| 2 | `33` | Holly Berry | `4` | `5` | `5 min` | `1,100` |
| 3 | `34` | Wine | `3` | `2` | `3 min` | `1,900` |
| 4 | `36` | Book | `1` | `2` | `20 min` | `7,300` |
| 5 | `39` | Pearl | `0` | `1` | `45 min` | `35,000` |
| 6 | `12` | Chinese Dish | `3` | `2` | `12 min` | `12,000` |
| 7 | `9` | Persian Lamp | `1` | `2` | `30 min` | `22,000` |
| 8 | `13` | Peeing Boy | `2` | `0` | `16 min` | `43,000` |
| 9 | `17` | Coral | `0` | `2` | `40 min` | `55,000` |

### 9. Crom Village (`vg13`) — `shstim = 7 min`
Area reference: [crom_village.md](areas/crom_village.md)

| Slot | `dno` | Item | Base Stock (`kihkaz`) | Variance (`zaihab`) | Recovery (`zaiftim`) | Base Price (`kihkak`) |
|---|---|---|---|---|---|---|
| 0 | `27` | Red Pepper | `4` | `0` | `6 min` | `1,200` |
| 1 | `38` | Crystal Ball | `0` | `1` | `35 min` | `300` |
| 2 | `28` | Candle | `2` | `1` | `4 min` | `750` |
| 3 | `31` | Wooden Amulet | `3` | `1` | `5 min` | `850` |
| 4 | `33` | Holly Berry | `3` | `4` | `6 min` | `900` |
| 5 | `34` | Wine | `4` | `2` | `4 min` | `1,500` |
| 6 | `36` | Book | `1` | `2` | `25 min` | `6,000` |
| 7 | `37` | Musk | `2` | `3` | `30 min` | `8,500` |
| 8 | `41` | Gold Bar | `1` | `1` | `25 min` | `30,000` |
| 9 | `4` | Wide Urn | `3` | `2` | `22 min` | `13,000` |
| 10 | `5` | Blue Dragon Urn | `2` | `2` | `32 min` | `22,000` |

### Note on Tinto City (`vg03`) — Unused / Dummy Table
`vg03.json` contains a `shop_koueki` block (`koukaz = 16`, `shstim = 1`) populated with sequential placeholder values (`dno = 1..16`, `kihkaz = 10, 20, 30...`, `kihkak = 100, 200, 300...`). Although `text_gsd2_en` ID `3550` mentions *"You can get gold bars at Tinto's trading post for a very good price"*, Tinto's Trading Post was never finished in vanilla Suikoden II (Crom Village `vg13` serves as the Tinto region's actual Trading Post).

---

## 7. Optimal Profit Routes & Strategy Guide

### Top Single-Unit Profit Spreads (Base Prices, No Events)

| Item | Buy Town | Buy Price | Stock (`zaiftim`) | Sell Town | Sell Price | Net Profit / Unit | ROI |
|---|---|---|---|---|---|---|---|
| **Peeing Boy** | Castle HQ (`vk02`) | `22,000` | `1` (`40m`) | Rockaxe (`vi02`) | `43,000` | **+21,000** | `1.95x` |
| **Ancient Text** | Gregminster (`vf03`) | `22,000` | `1` (`25m`) | Forest Village (`ve02`) | `35,000` | **+13,000** | `1.59x` |
| **Peeing Boy** | South Window (`vd17`) | `32,000` | `1` (`12m`) | Rockaxe (`vi02`) | `43,000` | **+11,000** | `1.34x` |
| **Gold Bar** | Crom Village (`vg13`) | `30,000` | `1` (`25m`) | Highway Village (`vi12`) | `40,000` | **+10,000** | `1.33x` |
| **Blue Dragon Urn** | South Window (`vd17`) | `16,000` | `1` (`22m`) | Crom Village (`vg13`) | `22,000` | **+6,000** | `1.38x` |
| **Musk** | Highway Village (`vi12`) | `4,500` | `3` (`10m`) | Crom Village (`vg13`) | `8,500` | **+4,000** | `1.89x` |
| **Book** | Forest Village (`ve02`) | `3,500` | `2` (`40m`) | Rockaxe (`vi02`) | `7,300` | **+3,800** | `2.09x` |
| **Wide Urn** | Forest Village (`ve02`) | `9,500` | `3` (`23m`) | Crom Village (`vg13`) | `13,000` | **+3,500** | `1.37x` |
| **Book** | Highway Village (`vi12`) | `4,000` | `2` (`15m`) | Rockaxe (`vi02`) | `7,300` | **+3,300** | `1.82x` |
| **Red Pepper** | Crom Village (`vg13`) | `1,200` | `4` (`6m`) | Rockaxe (`vi02`) | `3,200` | **+2,000** | `2.67x` |
| **Deer Antler** | Rokkaku (`vf01`) | `3,500` | `2` (`15m`) | Castle HQ (`vk02`) | `5,500` | **+2,000** | `1.57x` |
| **Mayonnaise** | South Window (`vd17`) | `400` | `4` (`5m`) | Highway Village (`vi12`) | `2,200` | **+1,800** | `5.50x` |
| **Traditional Clothing** | Gregminster (`vf03`) | `800` | `4` (`3m`) | Highway Village (`vi12`) | `2,500` | **+1,700** | `3.12x` |
| **Wine** | Gregminster (`vf03`) | `650` | `3` (`4m`) | Rockaxe (`vi02`) | `1,900` | **+1,250** | `2.92x` |
| **Mayonnaise** | South Window (`vd17`) | `400` | `4` (`5m`) | Kobold Village (`vh03`) | `1,500` | **+1,100** | `3.75x` |

### Recommended Loops & Tactics

1. **Early-Game 3-Town Loop (South Window ↔ Forest Village ↔ Kobold Village):**
   Even hinted at in Castle Library book `3002000042`:
   - **South Window → Forest Village:** Buy **Salt** (`270`, stk `15`) → sell at Forest (`550`, `+280/unit`). Buy **Mayonnaise** (`400`, stk `4`) → hold for Kobold Village.
   - **Forest Village → Kobold Village:** Buy **Sugar** (`150`, stk `25`) → sell at Kobold (`350`, `+200/unit`). Sell **Mayonnaise** at Kobold (`1,500`, `+1,100/unit`).
   - **Kobold Village → South Window:** Buy **Wooden Amulet** (`350`, stk `5`) → sell at South Window (`700`, `+350/unit`).

2. **Fastest Gordon Recruitment (`50,000` Potch Trade Volume):**
   Because `AddTradeTransactionAmount` counts **both** buying and selling:
   - Buy **Blue Dragon Urn** (`16,000`) or **Peeing Boy** (`32,000`) at South Window (`vd17`), or **Ancient Text** (`22,000`) at Gregminster (`vf03`), and sell it at a profit. A single **Peeing Boy** bought at South Window (`32,000`) and sold at Rockaxe (`43,000`) logs **75,000 potch** in trade volume — instantly qualifying for Gordon!
   - Alternatively, without Rockaxe: buy **Ancient Text** (`22,000`) in Gregminster and sell in Forest Village (`35,000`) -> **57,000** trade volume in 1 trip!

3. **Late-Game Teleportation Circuit (with Viki + Barbara's Warehouse):**
   - **Circuit A (High-Value Antiques & Texts):**
     1. **Castle HQ (`vk02`):** Buy **Peeing Boy** (`22,000`) & **Fur** (`350`).
     2. **Gregminster (`vf03`):** Buy **Ancient Text** (`22,000`), **Wine** (`650`), **Traditional Clothing** (`800`).
     3. **Forest Village (`ve02`):** Sell **Ancient Text** (`35,000`). Buy **Book** (`3,500`), **Wide Urn** (`9,500`).
     4. **Crom Village (`vg13`):** Sell **Wide Urn** (`13,000`). Buy **Red Pepper** (`1,200`), **Gold Bar** (`30,000`).
     5. **Highway Village (`vi12`):** Sell **Gold Bar** (`40,000`), **Traditional Clothing** (`2,500`). Buy **Musk** (`4,500`).
     6. **Rockaxe (`vi02`):** Sell **Peeing Boy** (`43,000`), **Book** (`7,300`), **Red Pepper** (`3,200`), **Wine** (`1,900`).
   - **Never Over-Flood One Shop in One Visit:** Remember that selling `N` units increases `zai` by `N` and drops the shop's price on the *next* `shstim` update (and if you sell in separate batches after `shstim` passes, the price will already be depressed). Sell in bulk in a **single visit** before `shstim` ticks, then let `zaiftim` drain the excess stock while you run other routes!

4. **Monster-Drop Goldmines (Sell at Trading Posts, NOT Appraisers):**
   - **Crystal Ball** (dropped by monsters): worth **7,000 potch** at **Kobold Village** (up to **21,000 potch** during Event #18!).
   - **Coral**: worth **55,000 potch** at **Rockaxe** (or `40,000` at South Window).
   - **Pearl**: worth **35,000 potch** at **Rockaxe** (or `24,000` at Gregminster).
   - **Persian Lamp**: worth **22,000 potch** at **Rockaxe** (`16,000` at Gregminster).

---

## 8. Modding & Harmony Hook Reference

| Method / Field | VA (`GameAssembly.dll`) | Modding Use Case |
|---|---|---|
| `koueki.SKZaikoCheck` | `0x181D9A210` | Override restock speed (`zaiftim`), price elasticity, or `65,000` potch cap |
| `koueki.SKKeventCheck2` | `0x181D99E80` | Customize market event price multipliers |
| `koueki.SMNanyesnoOk` | `0x181DA1060` | Modify 30-item bag limit (`0x1E`), stock decrement/increment, or `koueki_ave` |
| `koueki.AddTradeTransactionAmount` | `0x181D99D80` | Track or adjust Gordon's `game_data + 0x1AC` trade volume counter |
| `koueki.SMSitadoriFunc1` | `0x181DA1C80` | Appraiser antique buyback formula (`G2_item_value / 2`) |
| `MACHICON.EventInit` | — | Patch `MACHIDAT.etc_data` / `shop_koueki` (e.g., restoring Tinto's `vg03` Trading Post) |
