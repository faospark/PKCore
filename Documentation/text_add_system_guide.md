# `text_add_<lang>` Text System & Modding Guide

## Overview

`text_add_<lang>` is an **HD Remaster-exclusive** localization system shared across the collection launcher, *Suikoden I*, and *Suikoden II* (`GSDShare.dll` / `ShareUI.dll`). It does not come from the PS1 originals.

While the ported games keep their own per-game string tables, `text_add_<lang>` acts as a separate addition layer for Remaster-only UI and system strings (launcher menus, Event Viewer / Endings / Credits gallery, Achievements/Trophies, Hard difficulty prompts, event-timer settings, PS4 save-transfer notices, and shared battle/menu shorthand).

### System Comparison

| Layer | `TextAsset` Name | Code Entrypoint | ID Constants | UI Binder Component |
| :--- | :--- | :--- | :--- | :--- |
| **Remaster Shared** | `text_add_<lang>` | [`add_string_h.SID_TEXT(int)`](file:///D:/Appz/SuikodenModding/Suisource/GSDShare/GSDShare/add_string_h.cs#L14) | [`add_string_id_h`](file:///D:/Appz/SuikodenModding/Suisource/GSDShare/GSDShare/add_string_id_h.cs) | [`AddLangTextSetter`](file:///D:/Appz/SuikodenModding/Suisource/ShareUI/ShareUI/Component/AddLangTextSetter.cs) (`ShareUI.dll`) |
| **Suikoden I** | `text_gsd1_<lang>` | [`G1_string_id_h`](file:///D:/Appz/SuikodenModding/Suisource/GSD1/GSD1/G1_string_id_h.cs) | [`G1_string_id_h`](file:///D:/Appz/SuikodenModding/Suisource/GSD1/GSD1/G1_string_id_h.cs) | [`GSD1LangTextSetter`](file:///D:/Appz/SuikodenModding/Suisource/GSD1/GSD1/UI/Component/GSD1LangTextSetter.cs) (`GSD1.dll`) |
| **Suikoden II** | `text_gsd2_<lang>` | [`string_h`](file:///D:/Appz/SuikodenModding/Suisource/GSD2/GSD2/string_h.cs) | `string_h` | [`GSD2LangTextSetter`](file:///D:/Appz/SuikodenModding/Suisource/GSD2/GSD2/UI/Component/GSD2LangTextSetter.cs) (`GSD2.dll`) |

---

## Asset Format & Existing IDs

The Remaster ships 8 localized `TextAsset` files matching [`TextMasterData.Lang`](file:///D:/Appz/SuikodenModding/Suisource/GSDShare/GSDShare/TextMasterData.cs#L1178-L1198):

* `text_add_ja` (`Japanese`)
* `text_add_en` (`English`)
* `text_add_fr` (`French`)
* `text_add_it` (`Italian`)
* `text_add_de` (`German`)
* `text_add_es` (`Spanish`)
* `text_add_zh-hant` (`ChineseZhHant`)
* `text_add_zh-hans` (`ChineseZhHans`)

Each file is UTF-8 JSON matching [`TextMasterData.TextMasterObject`](file:///D:/Appz/SuikodenModding/Suisource/GSDShare/GSDShare/TextMasterData.cs#L855-L911):

```json
{
  "textList": [
    { "id": 1, "text": "Power?" },
    { "id": 2, "text": "Is it power that we seek?" }
  ]
}
```

In `text_add_en`:
* Total entries: **1,425**
* ID range: **`1` through `1430`** (contiguous except unused IDs `97`, `126`, `129`, `155`, and `201`)

---

## End-to-End Architecture

### 1. Loading ([`TextMasterData`](file:///D:/Appz/SuikodenModding/Suisource/GSDShare/GSDShare/TextMasterData.cs))

1. Callers invoke [`TextMasterData.LoadSystemTextAsync(string id)`](file:///D:/Appz/SuikodenModding/Suisource/GSDShare/GSDShare/TextMasterData.cs#L179):
   * **Collection Launcher (`GSDTitleSelect`):** calls `TextMasterData.Clear()` then `TextMasterData.LoadSystemTextAsync(null)`, loading **only** `text_add_<lang>`.
   * **In-Game (`TextBinaryManager`):** passes `"MAIN"`, loading the game's system text and `text_add_<lang>`.
2. Inside the `LoadSystemTextAsync` coroutine (`TextMasterData_<>d__26__MoveNext`):
   * If `id != null` and not already in [`TextMasterData.stayTextSet`](file:///D:/Appz/SuikodenModding/Suisource/GSDShare/GSDShare/TextMasterData.cs#L665), it loads the game asset via `_LoadTextAssetASync`.
   * It then **unconditionally checks** if [`add_string_h.SIT_MAIN`](file:///D:/Appz/SuikodenModding/Suisource/GSDShare/GSDShare/add_string_h.cs#L44) is missing from `stayTextSet`.
   * If missing, it creates a new [`TextMasterData.TextSet`](file:///D:/Appz/SuikodenModding/Suisource/GSDShare/GSDShare/TextMasterData.cs#L1530) under `stayTextSet[SIT_MAIN]` and runs [`_LoadAddTextAssetASync`](file:///D:/Appz/SuikodenModding/Suisource/GSDShare/GSDShare/TextMasterData.cs#L848).
3. `_LoadAddTextAssetASync` (`TextMasterData_<>d__42__MoveNext`):
   * Combines the shared text path with `TextMasterData.TextPath` and builds `"text_add_" + TextMasterData.GetExt(CurrentLanguage)`.
   * Loads the `TextAsset` via [`ResourceLoader.LoadAssetFile`](file:///D:/Appz/SuikodenModding/Suisource/GSDShare/GSDShare/ResourceLoader.cs#L308).
   * Parses the JSON with `UnityEngine.JsonUtility.FromJson`, populates the dictionary via [`TextSet.ReadFromJson`](file:///D:/Appz/SuikodenModding/Suisource/GSDShare/GSDShare/TextMasterData.cs#L1611), and calls `ResourceLoader.Unload`.

### 2. Code Lookup ([`add_string_h`](file:///D:/Appz/SuikodenModding/Suisource/GSDShare/GSDShare/add_string_h.cs))

* [`add_string_h.SID_TEXT(int idx)`](file:///D:/Appz/SuikodenModding/Suisource/GSDShare/GSDShare/add_string_h.cs#L14) forwards directly to [`TextMasterData.GetSystemText(add_string_h.SIT_MAIN, idx)`](file:///D:/Appz/SuikodenModding/Suisource/GSDShare/GSDShare/TextMasterData.cs#L264).
* `TextMasterData.GetSystemText` compares the requested `id` against `add_string_h.SIT_MAIN`:
  * For game tables (`id != SIT_MAIN`), it remaps `index` through `TextMasterData.dupTable` first.
  * For `add_string_h.SIT_MAIN`, it **bypasses `dupTable`** and queries [`TextSet.GetText(index)`](file:///D:/Appz/SuikodenModding/Suisource/GSDShare/GSDShare/TextMasterData.cs#L1594) directly from `stayTextSet[SIT_MAIN]`.

### 3. Declarative UI Binding ([`AddLangTextSetter`](file:///D:/Appz/SuikodenModding/Suisource/ShareUI/ShareUI/Component/AddLangTextSetter.cs))

* Shared UI prefabs attach `ShareUI.Component.AddLangTextSetter` (`MonoBehaviour`) with fields `id`, `textMP` (`TextMeshPro`), and `color`.
* [`SetText(bool isForce = false)`](file:///D:/Appz/SuikodenModding/Suisource/ShareUI/ShareUI/Component/AddLangTextSetter.cs#L113) checks [`TextMasterData.IsLoaded(add_string_h.SIT_MAIN)`](file:///D:/Appz/SuikodenModding/Suisource/GSDShare/GSDShare/TextMasterData.cs#L232), reads `add_string_h.SID_TEXT(id)`, updates `textMP` and `UIColorSettings`, and tracks `beforeLang`.
* Active instances register in `m_actives`, allowing [`AddLangTextSetter.UpdateAllText()`](file:///D:/Appz/SuikodenModding/Suisource/ShareUI/ShareUI/Component/AddLangTextSetter.cs#L66) to re-render all visible UI text immediately when the language setting changes.

---

## How to Add or Override Text (Modding Guide)

### Approach 1: Inject Runtime Entries via `TextMasterData.WriteSystemText` (Recommended for New Custom IDs)

[`TextMasterData.WriteSystemText(string id, int index, string str)`](file:///D:/Appz/SuikodenModding/Suisource/GSDShare/GSDShare/TextMasterData.cs#L301) calls `Dictionary.set_Item` (`dict[index] = str`) on `stayTextSet[id]`. That means it can **both add new IDs and overwrite existing IDs** in `text_add_<lang>` once `SIT_MAIN` is loaded.

```csharp
// Pick a high ID well above vanilla's 1430 max (e.g. 50000+)
const int MyCustomTextId = 50001;

if (TextMasterData.IsLoaded(add_string_h.SIT_MAIN))
{
    TextMasterData.WriteSystemText(add_string_h.SIT_MAIN, MyCustomTextId, "Custom Remaster String");
}
```

Once written:
* `add_string_h.SID_TEXT(50001)` returns `"Custom Remaster String"`.
* Any `AddLangTextSetter` with `id = 50001` displays it automatically.

**Important caveats:**
1. **`TextMasterData.Clear()` wipes `stayTextSet`** (for example, on launcher return or language switching). Re-apply custom `WriteSystemText` registrations after `LoadSystemTextAsync` finishes or hook `TextMasterData.IsLoaded` / `AddLangTextSetter` / scene load so entries persist across language changes.
2. **Choose localized text dynamically** by checking `TextMasterData.CurrentLanguage` when writing the string if you support multiple languages.

---

### Approach 2: Intercept Lookups via Harmony (`GetSystemText` Prefix)

If you want data-driven overrides without worrying about `stayTextSet` being cleared, patch `TextMasterData.GetSystemText(string id, int index)` with a Harmony `[HarmonyPrefix]`, just as [`TextDatabasePatch`](file:///d:/Appz/SuikodenModding/PKCore/Patches/TextDatabasePatch.cs#L119-L145) does:

```csharp
[HarmonyPatch(typeof(TextMasterData), nameof(TextMasterData.GetSystemText))]
[HarmonyPrefix]
public static bool GetSystemText_Prefix(string id, int index, ref string __result)
{
    if (id == add_string_h.SIT_MAIN && CustomAddTexts.TryGetValue(index, out var customText))
    {
        __result = customText;
        return false;
    }
    return true;
}
```

Note: This works cleanly for `add_string_h.SID_TEXT(...)` and `AddLangTextSetter` because both route through `TextMasterData.GetSystemText(add_string_h.SIT_MAIN, index)`.

---

### Approach 3: Edit `text_add_<lang>` `TextAsset` Bundles Directly

If modifying the shipped Unity asset bundles / Addressables instead of using code hooks:
1. Edit the JSON `"textList"` array in every target `text_add_<lang>` file (`text_add_en`, `text_add_ja`, etc.).
2. Append entries using **unique IDs above `1430`** (e.g., `10000+`):
   ```json
   { "id": 10001, "text": "Your New UI Label" }
   ```
3. **Never duplicate an `id`** inside the same `text_add_<lang>` file — [`TextSet.ReadFromJson`](file:///D:/Appz/SuikodenModding/Suisource/GSDShare/GSDShare/TextMasterData.cs#L1611) inserts entries with `Dictionary.Add`, which throws an exception on duplicate keys.
4. Keep UTF-8 encoding and valid JSON escaping (notice `JsonUtility.FromJson` parses `textList` at runtime).
