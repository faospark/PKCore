using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

namespace PKCore.Patches
{
    /// <summary>
    /// Displays mini party member portraits in Suikoden 1 & 2 save/load slot windows.
    /// Uses an ultra-fast, high-performance in-memory portrait cache.
    /// Prioritizes crisp modded custom textures from PKCore/Textures/ over native sprites.
    /// Works seamlessly on both Title Screen and Hotel/Inn save points in-game.
    /// </summary>
    [HarmonyPatch]
    public class SaveSlotPartyPortraitPatch
    {
        private static Dictionary<UISaveLoadSlot, GameObject> slotPortraitContainers = new Dictionary<UISaveLoadSlot, GameObject>();
        private static bool _monitorRegistered = false;

        // Optimized static portrait cache keyed by "{game}_{charId}" to ensure 0ms lookup after initial load
        private static Dictionary<string, Sprite> portraitCache = new Dictionary<string, Sprite>(StringComparer.OrdinalIgnoreCase);
        private static HashSet<string> pendingLoadIds = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        private static List<UnityEngine.Object> gcRoots = new List<UnityEngine.Object>();

        /// <summary>
        /// Hook into UISaveLoad1.Init to attach our monitor component
        /// </summary>
        [HarmonyPatch(typeof(UISaveLoad1), nameof(UISaveLoad1.Init))]
        [HarmonyPostfix]
        public static void Init_GSD1_Postfix(UISaveLoad1 __instance)
        {
            if (__instance == null || !Plugin.Config.ShowSaveSlotPartyPortraits.Value || !GameDetection.IsGSD1())
                return;

            AttachMonitor(__instance.gameObject);
        }

        /// <summary>
        /// Hook into UISaveLoad2.Init to attach our monitor component
        /// </summary>
        [HarmonyPatch(typeof(UISaveLoad2), nameof(UISaveLoad2.Init))]
        [HarmonyPostfix]
        public static void Init_GSD2_Postfix(UISaveLoad2 __instance)
        {
            if (__instance == null || !Plugin.Config.ShowSaveSlotPartyPortraits.Value || !GameDetection.IsGSD2())
                return;

            AttachMonitor(__instance.gameObject);
        }

        private static void AttachMonitor(GameObject go)
        {
            if (!_monitorRegistered)
            {
                Il2CppInterop.Runtime.Injection.ClassInjector.RegisterTypeInIl2Cpp<SaveSlotPortraitMonitor>();
                _monitorRegistered = true;
            }

            var monitor = go.GetComponent<SaveSlotPortraitMonitor>();
            if (monitor == null)
            {
                monitor = go.AddComponent<SaveSlotPortraitMonitor>();
            }
        }

        /// <summary>
        /// Monitor component running on UISaveLoad GameObject to keep slot containers updated & active
        /// </summary>
        public class SaveSlotPortraitMonitor : MonoBehaviour
        {
            public static SaveSlotPortraitMonitor Instance { get; private set; }

            private float _timer = 0f;
            private const float UPDATE_INTERVAL = 0.5f;

            public SaveSlotPortraitMonitor(IntPtr ptr) : base(ptr)
            {
                Instance = this;
            }

            private void Awake()
            {
                Instance = this;
            }

            private void Update()
            {
                _timer += Time.deltaTime;
                if (_timer >= UPDATE_INTERVAL)
                {
                    _timer = 0f;
                    CheckAndRefreshSlots();
                }
            }

            private void CheckAndRefreshSlots()
            {
                var slots = GetComponentsInChildren<UISaveLoadSlot>(false);
                for (int i = 0; i < slots.Count; i++)
                {
                    var slot = slots[i];
                    if (slot == null) continue;

                    if (slotPortraitContainers.TryGetValue(slot, out GameObject container) && container != null)
                    {
                        if (container.layer != slot.gameObject.layer)
                        {
                            container.layer = slot.gameObject.layer;
                            foreach (Transform child in container.transform)
                            {
                                if (child != null) child.gameObject.layer = container.layer;
                            }
                        }

                        if (!container.activeSelf && slot.gameObject.activeInHierarchy)
                        {
                            container.SetActive(true);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Hook into UISaveLoadSlot.UpdateItem to catch when each slot is populated
        /// </summary>
        [HarmonyPatch(typeof(UISaveLoadSlot), nameof(UISaveLoadSlot.UpdateItem))]
        [HarmonyPostfix]
        public static void UpdateItem_Postfix(UISaveLoadSlot __instance, int index, SaveDataSlotInfo info)
        {
            if (!Plugin.Config.ShowSaveSlotPartyPortraits.Value || (!GameDetection.IsGSD1() && !GameDetection.IsGSD2()) || __instance == null)
                return;

            try
            {
                GameObject set01 = __instance.objSet01;
                GameObject targetUI = set01 != null ? set01 : __instance.gameObject;
                ProcessSaveSlot(__instance, index, targetUI);
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"[SaveSlotPortrait] Error in UpdateItem_Postfix for slot {index}: {ex.Message}");
            }
        }

        /// <summary>
        /// Hook into UISaveLoadBase.OnUpdateItem to handle virtualization during scrolling
        /// </summary>
        [HarmonyPatch(typeof(UISaveLoadBase), nameof(UISaveLoadBase.OnUpdateItem))]
        [HarmonyPostfix]
        public static void OnUpdateItem_Postfix(UISaveLoadBase __instance, int itemCount, SaveDataSlotInfo info, GameObject obj)
        {
            if (!Plugin.Config.ShowSaveSlotPartyPortraits.Value || (!GameDetection.IsGSD1() && !GameDetection.IsGSD2()) || obj == null)
                return;

            try
            {
                UISaveLoadSlot slotInstance = obj.GetComponent<UISaveLoadSlot>();
                if (slotInstance == null) return;

                GameObject set01 = slotInstance.objSet01;
                GameObject targetUI = set01 != null ? set01 : slotInstance.gameObject;

                ProcessSaveSlot(slotInstance, itemCount, targetUI);
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"[SaveSlotPortrait] Error in OnUpdateItem_Postfix for slot {itemCount}: {ex.Message}");
            }
        }

        private static void ProcessSaveSlot(UISaveLoadSlot slotInstance, int slotNo, GameObject slotUI)
        {
            try
            {
                int[] characterIds = GetPartyCharacterIds(slotNo);
                if (characterIds == null || characterIds.Length == 0)
                {
                    if (slotPortraitContainers.TryGetValue(slotInstance, out GameObject oldContainer) && oldContainer != null)
                    {
                        UnityEngine.Object.Destroy(oldContainer);
                        slotPortraitContainers.Remove(slotInstance);
                    }
                    return;
                }

                CreateOrUpdatePortraits(slotInstance, slotNo, slotUI, characterIds);
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"[SaveSlotPortrait] Error processing slot {slotNo}: {ex.Message}");
            }
        }

        /// <summary>
        /// Multi-stage party character ID resolver (In-Memory -> Native Save Path -> Decrypted File Fallback)
        /// </summary>
        private static int[] GetPartyCharacterIds(int slotNo)
        {
            try
            {
                if (GameDetection.IsGSD1())
                {
                    // Stage 1: In-Memory lookup from UISaveLoad1.Inst.saveDataList
                    if (UISaveLoad1.Inst != null && UISaveLoad1.Inst.saveDataList != null)
                    {
                        if (UISaveLoad1.Inst.saveDataList.TryGetValue(slotNo, out var slotInfo) && slotInfo != null)
                        {
                            var tmpSave = slotInfo.data;
                            if (tmpSave != null && tmpSave.party_data != null && tmpSave.party_data.chara_code != null)
                            {
                                var chaNoArray = tmpSave.party_data.chara_code;
                                int count = chaNoArray.Length;
                                List<int> ids = new List<int>();
                                for (int i = 0; i < count && i < 8; i++)
                                {
                                    int charId = chaNoArray[i];
                                    if (charId > 0 && charId < 255)
                                    {
                                        ids.Add(charId);
                                    }
                                }
                                if (ids.Count > 0)
                                {
                                    return ids.ToArray();
                                }
                            }
                        }
                    }

                    // Stage 2: Native save file path via SaveDataManager.TmpSavePath
                    try
                    {
                        string nativePath = SaveDataManager.TmpSavePath(slotNo);
                        if (!string.IsNullOrEmpty(nativePath) && File.Exists(nativePath))
                        {
                            int[] ids = ParseSaveFilePartyData(nativePath);
                            if (ids != null && ids.Length > 0)
                                return ids;
                        }
                    }
                    catch { }

                    // Stage 3: Decrypted SuikodenFix JSON path fallback
                    try
                    {
                        string gameDir = Path.GetDirectoryName(Application.dataPath);
                        string fixPath = Path.Combine(gameDir, "SuikodenFix", "Decrypted", "gsd1", $"Data{slotNo}.json");
                        if (File.Exists(fixPath))
                        {
                            int[] ids = ParseSaveFilePartyData(fixPath);
                            if (ids != null && ids.Length > 0)
                                return ids;
                        }
                    }
                    catch { }
                }
                else if (GameDetection.IsGSD2())
                {
                    // Stage 1: Primary In-Memory lookup from UISaveLoad2.Inst.saveDataList
                    if (UISaveLoad2.Inst != null && UISaveLoad2.Inst.saveDataList != null)
                    {
                        if (UISaveLoad2.Inst.saveDataList.TryGetValue(slotNo, out var slotInfo) && slotInfo != null)
                        {
                            var tmpSave = slotInfo.data2;
                            if (tmpSave != null && tmpSave.party_data != null && tmpSave.party_data.party_cha_no != null)
                            {
                                var chaNoArray = tmpSave.party_data.party_cha_no;
                                int count = chaNoArray.Length;
                                List<int> ids = new List<int>();
                                for (int i = 0; i < count && i < 8; i++)
                                {
                                    int charId = chaNoArray[i];
                                    if (charId > 0 && charId < 255)
                                    {
                                        ids.Add(charId);
                                    }
                                }
                                if (ids.Count > 0)
                                {
                                    return ids.ToArray();
                                }
                            }
                        }
                    }

                    // Stage 2: Try native save file path via GSD2SaveData.TmpSavePath
                    try
                    {
                        string nativePath = GSD2SaveData.TmpSavePath(slotNo);
                        if (!string.IsNullOrEmpty(nativePath) && File.Exists(nativePath))
                        {
                            int[] ids = ParseSaveFilePartyData(nativePath);
                            if (ids != null && ids.Length > 0)
                                return ids;
                        }
                    }
                    catch { }

                    // Stage 3: Decrypted SuikodenFix JSON path fallback
                    try
                    {
                        string gameDir = Path.GetDirectoryName(Application.dataPath);
                        string fixPath = Path.Combine(gameDir, "SuikodenFix", "Decrypted", "gsd2", $"Data{slotNo}.json");
                        if (File.Exists(fixPath))
                        {
                            int[] ids = ParseSaveFilePartyData(fixPath);
                            if (ids != null && ids.Length > 0)
                                return ids;
                        }
                    }
                    catch { }
                }
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"[SaveSlotPortrait] Error fetching party IDs for slot {slotNo}: {ex.Message}");
            }

            return null;
        }

        /// <summary>
        /// Parse party character IDs from JSON save file
        /// </summary>
        private static int[] ParseSaveFilePartyData(string filePath)
        {
            try
            {
                string jsonContent = File.ReadAllText(filePath);
                using (JsonDocument doc = JsonDocument.Parse(jsonContent))
                {
                    JsonElement root = doc.RootElement;
                    if (!root.TryGetProperty("party_data", out JsonElement partyData))
                        return null;

                    if (!partyData.TryGetProperty("party_cha_no", out JsonElement partyChaNo) &&
                        !partyData.TryGetProperty("chara_code", out partyChaNo))
                        return null;

                    List<int> characterIds = new List<int>();
                    int index = 0;
                    foreach (JsonElement element in partyChaNo.EnumerateArray())
                    {
                        if (index < 8)
                        {
                            int id = element.GetInt32();
                            if (id > 0 && id < 255)
                                characterIds.Add(id);
                            index++;
                        }
                    }
                    return characterIds.ToArray();
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Render party member mini portraits next to slot text
        /// </summary>
        private static void CreateOrUpdatePortraits(UISaveLoadSlot slotInstance, int slotNo, GameObject slotUI, int[] characterIds)
        {
            try
            {
                Transform txtLv = slotUI.transform.Find("Txt_Lv");
                RectTransform txtLvRect = txtLv != null ? txtLv.GetComponent<RectTransform>() : null;

                GameObject container;
                RectTransform containerRect;
                if (slotPortraitContainers.TryGetValue(slotInstance, out GameObject existingContainer) && existingContainer != null)
                {
                    container = existingContainer;
                    containerRect = container.GetComponent<RectTransform>();
                    for (int i = container.transform.childCount - 1; i >= 0; i--)
                    {
                        UnityEngine.Object.Destroy(container.transform.GetChild(i).gameObject);
                    }
                }
                else
                {
                    container = new GameObject("PartyPortraits");
                    container.layer = slotUI.layer;
                    container.transform.SetParent(slotUI.transform, false);

                    containerRect = container.AddComponent<RectTransform>();
                    containerRect.sizeDelta = new Vector2(320f, 36f);

                    slotPortraitContainers[slotInstance] = container;
                }

                // Align container lower to sit next to LVL text on line 2 (below Time played)
                if (containerRect != null)
                {
                    if (txtLvRect != null)
                    {
                        containerRect.anchorMin = txtLvRect.anchorMin;
                        containerRect.anchorMax = txtLvRect.anchorMax;
                        containerRect.pivot = txtLvRect.pivot;
                        containerRect.anchoredPosition = new Vector2(
                            txtLvRect.anchoredPosition.x + txtLvRect.sizeDelta.x + 15f,
                            txtLvRect.anchoredPosition.y - 8f
                        );
                    }
                    else
                    {
                        containerRect.anchorMin = new Vector2(0, 0.5f);
                        containerRect.anchorMax = new Vector2(0, 0.5f);
                        containerRect.pivot = new Vector2(0, 0.5f);
                        containerRect.anchoredPosition = new Vector2(180f, -8f);
                    }
                }

                container.transform.SetAsLastSibling();

                int createdCount = 0;
                for (int i = 0; i < characterIds.Length && i < 8; i++)
                {
                    int charId = characterIds[i];
                    if (charId <= 0 || charId >= 255)
                        continue;

                    if (CreatePortraitImage(container, createdCount, charId))
                    {
                        createdCount++;
                    }
                }
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"[SaveSlotPortrait] Error creating portraits for slot {slotNo}: {ex.Message}");
            }
        }

        private static bool CreatePortraitImage(GameObject container, int index, int characterId)
        {
            try
            {
                GameObject portraitObj = new GameObject($"Portrait_{index}_{characterId}");
                portraitObj.layer = container.layer;
                portraitObj.transform.SetParent(container.transform, false);

                RectTransform portraitRect = portraitObj.AddComponent<RectTransform>();
                portraitRect.anchorMin = new Vector2(0, 0.5f);
                portraitRect.anchorMax = new Vector2(0, 0.5f);
                portraitRect.pivot = new Vector2(0, 0.5f);

                // Compact spacing (36px width + 4px gap = 40px offset per portrait)
                portraitRect.anchoredPosition = new Vector2(index * 40f, 0);
                portraitRect.sizeDelta = new Vector2(36f, 36f);

                Image portraitImage = portraitObj.AddComponent<Image>();
                portraitImage.raycastTarget = false;

                Sprite sprite = GetOrLoadPortraitSprite(characterId, SaveSlotPortraitMonitor.Instance, portraitImage);
                if (sprite != null)
                {
                    portraitImage.sprite = sprite;
                    portraitImage.preserveAspect = true;
                }

                return true;
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"[SaveSlotPortrait] Error creating portrait image for character {characterId}: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Fast portrait loader with static caching and custom texture prioritization
        /// </summary>
        public static Sprite GetOrLoadPortraitSprite(int charId, MonoBehaviour runner, Image targetImage = null)
        {
            if (charId <= 0 || charId >= 255) return null;

            string currentGame = GameDetection.GetCurrentGame();
            string cacheKey = $"{currentGame}_{charId}";

            // 1. Instant Cache Hit (0ms)
            if (portraitCache.TryGetValue(cacheKey, out Sprite cachedSprite))
            {
                if (cachedSprite != null && cachedSprite.Pointer != IntPtr.Zero)
                    return cachedSprite;
                else
                    portraitCache.Remove(cacheKey);
            }

            // 2. Priority 1: Check Custom External Texture (PKCore/Textures/)
            Texture2D customTex = null;
            List<string> candidateNames = new List<string>();

            if (GameDetection.IsGSD1())
            {
                int faceId = -1;
                try
                {
                    faceId = Ws_face_c.CharacterIDConvertToFaceIDStatic((ushort)charId);
                }
                catch (Exception ex)
                {
                    Plugin.Log.LogWarning($"[SaveSlotPortrait] CharacterIDConvertToFaceIDStatic failed for charId {charId}: {ex.Message}");
                }

                if (faceId >= 0)
                {
                    candidateNames.Add($"fp_gsd1_{faceId:D3}");
                    candidateNames.Add($"fp_gsd1_{faceId}");
                    candidateNames.Add($"fp_{faceId:D3}");
                    candidateNames.Add($"fp_{faceId}");
                }

                candidateNames.Add($"fp_gsd1_{charId:D3}");
                candidateNames.Add($"fp_gsd1_{charId}");
                candidateNames.Add($"fp_{charId:D3}");
                candidateNames.Add($"fp_{charId}");
            }
            else
            {
                candidateNames.Add($"fp_{charId:D3}");
                candidateNames.Add($"fp_{charId}");
                candidateNames.Add($"fp_gsd2_{charId:D3}");
                candidateNames.Add($"fp_gsd2_{charId}");
            }

            foreach (var name in candidateNames)
            {
                try
                {
                    customTex = CustomTexturePatch.LoadCustomTexture(name);
                    if (customTex != null && customTex.Pointer != IntPtr.Zero)
                        break;
                }
                catch { }
            }

            if (customTex != null && customTex.Pointer != IntPtr.Zero)
            {
                Sprite customSprite = CreateSquareFaceSprite(customTex);
                if (customSprite != null && customSprite.Pointer != IntPtr.Zero)
                {
                    portraitCache[cacheKey] = customSprite;
                    return customSprite;
                }
            }

            // 3. Priority 2: Synchronous Native Face Sprite via ImageLoader.LoadImage (GSD2)
            if (GameDetection.IsGSD2())
            {
                try
                {
                    Sprite nativeSprite = ImageLoader.LoadImage(charId);
                    if (nativeSprite != null && nativeSprite.Pointer != IntPtr.Zero)
                    {
                        nativeSprite.hideFlags = HideFlags.DontUnloadUnusedAsset;
                        UnityEngine.Object.DontDestroyOnLoad(nativeSprite);
                        gcRoots.Add(nativeSprite);
                        portraitCache[cacheKey] = nativeSprite;
                        return nativeSprite;
                    }
                }
                catch { }
            }

            // 4. Priority 3: Fallback to Async Native Loader if needed (GSD2)
            if (GameDetection.IsGSD2() && runner != null && !pendingLoadIds.Contains(cacheKey))
            {
                pendingLoadIds.Add(cacheKey);
                try
                {
                    Action<Sprite> callback = (Sprite loadedSprite) =>
                    {
                        pendingLoadIds.Remove(cacheKey);
                        if (loadedSprite != null && loadedSprite.Pointer != IntPtr.Zero)
                        {
                            loadedSprite.hideFlags = HideFlags.DontUnloadUnusedAsset;
                            UnityEngine.Object.DontDestroyOnLoad(loadedSprite);
                            gcRoots.Add(loadedSprite);
                            portraitCache[cacheKey] = loadedSprite;

                            if (targetImage != null && targetImage.Pointer != IntPtr.Zero)
                            {
                                targetImage.sprite = loadedSprite;
                                targetImage.preserveAspect = true;
                                if (!targetImage.gameObject.activeSelf)
                                    targetImage.gameObject.SetActive(true);
                            }
                        }
                    };

                    var coroutine = ImageLoader.LoadAsyncImage(charId, callback);
                    if (coroutine != null)
                    {
                        runner.StartCoroutine(coroutine);
                    }
                }
                catch
                {
                    pendingLoadIds.Remove(cacheKey);
                }
            }

            return null;
        }

        /// <summary>
        /// Crop 1:1 square face region from custom texture for sharp, non-distorted rendering
        /// </summary>
        private static Sprite CreateSquareFaceSprite(Texture2D sourceTex)
        {
            if (sourceTex == null || sourceTex.Pointer == IntPtr.Zero) return null;

            int width = sourceTex.width;
            int height = sourceTex.height;
            if (width <= 0 || height <= 0) return null;

            int cropSize = Mathf.Min(width, height);
            float posX = (width - cropSize) * 0.5f;
            float posY = height > width ? (height - cropSize) : 0f; // Top square for face

            Rect cropRect = new Rect(posX, posY, cropSize, cropSize);
            Sprite sprite = Sprite.Create(
                sourceTex,
                cropRect,
                new Vector2(0.5f, 0.5f),
                100f,
                0,
                SpriteMeshType.FullRect
            );
            sprite.hideFlags = HideFlags.DontUnloadUnusedAsset;
            UnityEngine.Object.DontDestroyOnLoad(sprite);
            gcRoots.Add(sprite);
            return sprite;
        }

        /// <summary>
        /// Cleanup containers on menu close
        /// </summary>
        public static void Cleanup()
        {
            foreach (var container in slotPortraitContainers.Values)
            {
                if (container != null)
                    UnityEngine.Object.Destroy(container);
            }
            slotPortraitContainers.Clear();
        }
    }
}
