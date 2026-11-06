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
        private static HashSet<string> missingPortraitCache = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        private static List<UnityEngine.Object> gcRoots = new List<UnityEngine.Object>();

        /// <summary>
        /// Clears all portrait and container caches so portraits are guaranteed to reload freshly
        /// </summary>
        public static void ResetCache()
        {
            portraitCache.Clear();
            pendingLoadIds.Clear();
            missingPortraitCache.Clear();
            slotPortraitContainers.Clear();
            gcRoots.Clear();
        }

        /// <summary>
        /// Cleans up destroyed UI containers and stale sprite instances, while keeping healthy
        /// in-memory thumbnails alive across save menu visits for 0ms re-open performance.
        /// </summary>
        public static void CleanupInvalidCache()
        {
            List<string> staleKeys = null;
            foreach (var kvp in portraitCache)
            {
                if (!IsSpriteValid(kvp.Value))
                {
                    if (staleKeys == null) staleKeys = new List<string>();
                    staleKeys.Add(kvp.Key);
                }
            }
            if (staleKeys != null)
            {
                foreach (var k in staleKeys) portraitCache.Remove(k);
            }

            pendingLoadIds.Clear();
            missingPortraitCache.Clear();
            slotPortraitContainers.Clear();
        }

        private static bool IsSpriteValid(Sprite sprite)
        {
            if (sprite == null || sprite.Pointer == IntPtr.Zero)
                return false;

            try
            {
                Texture2D tex = sprite.texture;
                if (tex == null || tex.Pointer == IntPtr.Zero)
                    return false;

                return tex.width > 0 && tex.height > 0;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Hook into UISaveLoad1.Init to attach our monitor component and refresh stale caches
        /// </summary>
        [HarmonyPatch(typeof(UISaveLoad1), nameof(UISaveLoad1.Init))]
        [HarmonyPostfix]
        public static void Init_GSD1_Postfix(UISaveLoad1 __instance)
        {
            if (__instance == null || !Plugin.Config.ShowSaveSlotPartyPortraits.Value)
                return;

            CleanupInvalidCache();
            AttachMonitor(__instance.gameObject);
        }

        /// <summary>
        /// Hook into UISaveLoad2.Init to attach our monitor component and refresh stale caches
        /// </summary>
        [HarmonyPatch(typeof(UISaveLoad2), nameof(UISaveLoad2.Init))]
        [HarmonyPostfix]
        public static void Init_GSD2_Postfix(UISaveLoad2 __instance)
        {
            if (__instance == null || !Plugin.Config.ShowSaveSlotPartyPortraits.Value)
                return;

            CleanupInvalidCache();
            AttachMonitor(__instance.gameObject);
        }

        private static void AttachMonitor(GameObject go)
        {
            if (!_monitorRegistered)
            {
                Il2CppInterop.Runtime.Injection.ClassInjector.RegisterTypeInIl2Cpp<SaveSlotPortraitMonitor>();
                _monitorRegistered = true;

                // Also listen for scene transitions / soft resets to clear stale portrait textures
                UnityEngine.SceneManagement.SceneManager.sceneLoaded += (Action<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>)OnSceneLoaded;
            }

            var monitor = go.GetComponent<SaveSlotPortraitMonitor>();
            if (monitor == null)
            {
                monitor = go.AddComponent<SaveSlotPortraitMonitor>();
            }
        }

        private static void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
        {
            CleanupInvalidCache();
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

            private void OnDestroy()
            {
                if (Instance == this)
                {
                    Instance = null;
                }
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
            if (!Plugin.Config.ShowSaveSlotPartyPortraits.Value || __instance == null)
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
            if (!Plugin.Config.ShowSaveSlotPartyPortraits.Value || obj == null)
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
                bool isGSD1 = GameDetection.IsGSD1() || (UISaveLoad1.Inst != null && UISaveLoad2.Inst == null);
                bool isGSD2 = GameDetection.IsGSD2() || UISaveLoad2.Inst != null;

                if (isGSD1)
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
                else if (isGSD2)
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

                    if (CreatePortraitImage(slotInstance, container, createdCount, charId))
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

        private static bool CreatePortraitImage(UISaveLoadSlot slotInstance, GameObject container, int index, int characterId)
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

                MonoBehaviour runner = (MonoBehaviour)SaveSlotPortraitMonitor.Instance ?? slotInstance;
                Sprite sprite = GetOrLoadPortraitSprite(characterId, runner, portraitImage);
                if (IsSpriteValid(sprite))
                {
                    portraitImage.sprite = sprite;
                    portraitImage.preserveAspect = true;
                    portraitImage.color = Color.white;
                }
                else
                {
                    // Transparent while waiting for async load to avoid blank white square
                    portraitImage.color = Color.clear;
                }

                return true;
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"[SaveSlotPortrait] Error creating portrait image for character {characterId}: {ex.Message}");
                return false;
            }
        }

        private static Sprite LoadThumbnailSprite(string thumbBasePath)
        {
            try
            {
                string ddsPath = thumbBasePath + ".dds";
                string pngPath = thumbBasePath + ".png";

                string activePath = null;
                if (File.Exists(ddsPath)) activePath = ddsPath;
                else if (File.Exists(pngPath)) activePath = pngPath;

                if (activePath == null) return null;

                Texture2D thumbTex = null;
                if (activePath.EndsWith(".dds", StringComparison.OrdinalIgnoreCase))
                {
                    thumbTex = AssetLoader.LoadTextureFromFile(activePath, Path.GetFileNameWithoutExtension(activePath), "SaveSlotPartyThumbnail");
                }
                else
                {
                    byte[] pngBytes = File.ReadAllBytes(activePath);
                    if (pngBytes != null && pngBytes.Length > 0)
                    {
                        thumbTex = new Texture2D(2, 2, TextureFormat.RGBA32, false);
                        if (!ImageConversion.LoadImage(thumbTex, pngBytes))
                        {
                            UnityEngine.Object.Destroy(thumbTex);
                            thumbTex = null;
                        }
                    }
                }

                if (thumbTex != null && thumbTex.Pointer != IntPtr.Zero)
                {
                    thumbTex.filterMode = FilterMode.Bilinear;
                    thumbTex.wrapMode = TextureWrapMode.Clamp;
                    thumbTex.hideFlags = HideFlags.DontUnloadUnusedAsset;
                    UnityEngine.Object.DontDestroyOnLoad(thumbTex);
                    gcRoots.Add(thumbTex);

                    Sprite thumbSprite = Sprite.Create(
                        thumbTex,
                        new Rect(0, 0, thumbTex.width, thumbTex.height),
                        new Vector2(0.5f, 0.5f),
                        100f,
                        0,
                        SpriteMeshType.FullRect
                    );
                    thumbSprite.hideFlags = HideFlags.DontUnloadUnusedAsset;
                    UnityEngine.Object.DontDestroyOnLoad(thumbSprite);
                    gcRoots.Add(thumbSprite);

                    return thumbSprite;
                }
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"[SaveSlotPortrait] Failed to load thumbnail {thumbBasePath}: {ex.Message}");
            }
            return null;
        }

        private static Rect CalculateFaceCropRect(int width, int height)
        {
            if (width <= 0 || height <= 0) return Rect.zero;
            int cropSize = Mathf.Min(width, height);
            float posX = (width - cropSize) * 0.5f;
            float posY = height > width ? (height - cropSize) : 0f; // Top square for face
            return new Rect(posX, posY, cropSize, cropSize);
        }

        private static Rect CalculateFaceCropRect(Sprite sprite)
        {
            if (sprite == null) return Rect.zero;
            Rect r = sprite.rect;
            int cropSize = Mathf.Min((int)r.width, (int)r.height);
            float posX = r.x + (r.width - cropSize) * 0.5f;
            float posY = r.height > r.width ? (r.y + (r.height - cropSize)) : r.y;
            return new Rect(posX, posY, cropSize, cropSize);
        }

        private static byte[] CreateThumbnailPngBytes(Texture2D sourceTex, Rect cropRect, int targetSize = 64)
        {
            if (sourceTex == null || sourceTex.Pointer == IntPtr.Zero) return null;

            int cropX = Mathf.Clamp((int)cropRect.x, 0, sourceTex.width - 1);
            int cropY = Mathf.Clamp((int)cropRect.y, 0, sourceTex.height - 1);
            int cropW = Mathf.Clamp((int)cropRect.width, 1, sourceTex.width - cropX);
            int cropH = Mathf.Clamp((int)cropRect.height, 1, sourceTex.height - cropY);

            // Fast CPU path: if texture is readable
            try
            {
                Color[] rawPixels = sourceTex.GetPixels(cropX, cropY, cropW, cropH);
                if (rawPixels != null && rawPixels.Length == cropW * cropH)
                {
                    Texture2D thumb = new Texture2D(targetSize, targetSize, TextureFormat.RGBA32, false);
                    Color[] scaled = new Color[targetSize * targetSize];

                    for (int y = 0; y < targetSize; y++)
                    {
                        float v = (float)y / (targetSize - 1) * (cropH - 1);
                        int y0 = (int)v;
                        int y1 = Mathf.Min(y0 + 1, cropH - 1);
                        float dy = v - y0;

                        for (int x = 0; x < targetSize; x++)
                        {
                            float u = (float)x / (targetSize - 1) * (cropW - 1);
                            int x0 = (int)u;
                            int x1 = Mathf.Min(x0 + 1, cropW - 1);
                            float dx = u - x0;

                            Color c00 = rawPixels[y0 * cropW + x0];
                            Color c10 = rawPixels[y0 * cropW + x1];
                            Color c01 = rawPixels[y1 * cropW + x0];
                            Color c11 = rawPixels[y1 * cropW + x1];

                            Color top = Color.Lerp(c00, c10, dx);
                            Color bot = Color.Lerp(c01, c11, dx);
                            scaled[y * targetSize + x] = Color.Lerp(top, bot, dy);
                        }
                    }

                    thumb.SetPixels(scaled);
                    thumb.Apply(false, false);
                    byte[] png = ImageConversion.EncodeToPNG(thumb);
                    UnityEngine.Object.Destroy(thumb);
                    return png;
                }
            }
            catch
            {
                // Unreadable / compressed texture fallback
            }

            RenderTexture rt = null;
            RenderTexture prevRt = RenderTexture.active;
            Texture2D readTex = null;
            try
            {
                rt = RenderTexture.GetTemporary(targetSize, targetSize, 0, RenderTextureFormat.ARGB32);

                float scaleX = (float)cropW / sourceTex.width;
                float scaleY = (float)cropH / sourceTex.height;
                float offsetX = (float)cropX / sourceTex.width;
                float offsetY = (float)cropY / sourceTex.height;

                Graphics.Blit(sourceTex, rt, new Vector2(scaleX, scaleY), new Vector2(offsetX, offsetY));

                RenderTexture.active = rt;
                readTex = new Texture2D(targetSize, targetSize, TextureFormat.RGBA32, false);
                readTex.ReadPixels(new Rect(0, 0, targetSize, targetSize), 0, 0);
                readTex.Apply(false, false);

                return ImageConversion.EncodeToPNG(readTex);
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"[SaveSlotPortrait] RenderTexture blit fallback failed: {ex.Message}");
            }
            finally
            {
                RenderTexture.active = prevRt;
                if (rt != null) RenderTexture.ReleaseTemporary(rt);
                if (readTex != null) UnityEngine.Object.Destroy(readTex);
            }

            return null;
        }

        private static bool SaveThumbnail(Texture2D sourceTex, Rect cropRect, string thumbBasePath, int targetSize = 64)
        {
            if (sourceTex == null || sourceTex.Pointer == IntPtr.Zero) return false;

            try
            {
                string dir = Path.GetDirectoryName(thumbBasePath);
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                string pngPath = thumbBasePath + ".png";
                byte[] pngBytes = CreateThumbnailPngBytes(sourceTex, cropRect, targetSize);
                if (pngBytes != null && pngBytes.Length > 0)
                {
                    File.WriteAllBytes(pngPath, pngBytes);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"[SaveSlotPortrait] Failed saving thumbnail to {thumbBasePath}: {ex.Message}");
            }
            return false;
        }

        /// <summary>
        /// Fast portrait loader with persistent disk thumbnails and custom texture prioritization
        /// </summary>
        public static Sprite GetOrLoadPortraitSprite(int charId, MonoBehaviour runner, Image targetImage = null)
        {
            if (charId < 0 || charId >= 255) return null;

            bool isGSD1 = GameDetection.IsGSD1() || (UISaveLoad1.Inst != null && UISaveLoad2.Inst == null);
            bool isGSD2 = GameDetection.IsGSD2() || UISaveLoad2.Inst != null;
            string gameKey = isGSD1 ? "GSD1" : (isGSD2 ? "GSD2" : GameDetection.GetCurrentGame());
            string cacheKey = $"{gameKey}_{charId}";

            // 0. Instant Cache Hit for Known Missing Portraits (0ms)
            if (missingPortraitCache.Contains(cacheKey))
                return null;

            // 1. Instant Cache Hit in RAM (0ms)
            if (portraitCache.TryGetValue(cacheKey, out Sprite cachedSprite))
            {
                if (IsSpriteValid(cachedSprite))
                    return cachedSprite;
                else
                    portraitCache.Remove(cacheKey);
            }

            // 2. Resolve Portrait ID for this character
            string portraitId = null;
            if (isGSD1)
            {
                int faceId = -1;
                try
                {
                    faceId = Ws_face_c.CharacterIDConvertToFaceIDStatic((ushort)charId);
                }
                catch { }

                portraitId = faceId >= 0 ? $"fp_gsd1_{faceId:D3}" : $"fp_gsd1_{charId:D3}";
            }
            else
            {
                portraitId = $"fp_{charId:D3}";
            }

            string thumbDir = Path.Combine(BepInEx.Paths.GameRootPath, "PKCore", "Cache", isGSD1 ? "s1savethumb" : "s2savethumb");
            string thumbBasePath = Path.Combine(thumbDir, $"thumb_{portraitId}");

            // 3. Fast Disk Thumbnail Hit (.dds first, then .png)
            Sprite diskThumb = LoadThumbnailSprite(thumbBasePath);
            if (IsSpriteValid(diskThumb))
            {
                portraitCache[cacheKey] = diskThumb;
                return diskThumb;
            }

            // 4. Priority 1: Check Custom External Texture via CustomTexturePatch
            Texture2D customTex = CustomTexturePatch.LoadCustomTexture(portraitId);
            if (customTex == null && isGSD1)
            {
                // Try alternate unpadded or fallback naming
                customTex = CustomTexturePatch.LoadCustomTexture($"fp_gsd1_{charId}");
            }
            if (customTex == null && isGSD2)
            {
                customTex = CustomTexturePatch.LoadCustomTexture($"fp_gsd2_{charId:D3}");
            }

            if (customTex != null && customTex.Pointer != IntPtr.Zero)
            {
                Rect crop = CalculateFaceCropRect(customTex.width, customTex.height);
                SaveThumbnail(customTex, crop, thumbBasePath);

                Sprite generatedThumb = LoadThumbnailSprite(thumbBasePath);
                if (IsSpriteValid(generatedThumb))
                {
                    portraitCache[cacheKey] = generatedThumb;
                    return generatedThumb;
                }

                Sprite fallbackSprite = CreateSquareFaceSprite(customTex);
                if (IsSpriteValid(fallbackSprite))
                {
                    portraitCache[cacheKey] = fallbackSprite;
                    return fallbackSprite;
                }
            }

            // 5. Priority 2: Synchronous Native Face Sprite (GSD2)
            if (isGSD2)
            {
                try
                {
                    Sprite nativeSprite = ImageLoader.LoadImage(charId);
                    if (IsSpriteValid(nativeSprite))
                    {
                        Rect crop = CalculateFaceCropRect(nativeSprite);
                        SaveThumbnail(nativeSprite.texture, crop, thumbBasePath);

                        Sprite generatedThumb = LoadThumbnailSprite(thumbBasePath);
                        if (IsSpriteValid(generatedThumb))
                        {
                            portraitCache[cacheKey] = generatedThumb;
                            return generatedThumb;
                        }

                        nativeSprite.hideFlags = HideFlags.DontUnloadUnusedAsset;
                        UnityEngine.Object.DontDestroyOnLoad(nativeSprite);
                        gcRoots.Add(nativeSprite);
                        portraitCache[cacheKey] = nativeSprite;
                        return nativeSprite;
                    }
                }
                catch { }
            }

            // 6. Priority 3: Fallback to Async Native Loader (GSD2)
            if (isGSD2 && runner != null && !pendingLoadIds.Contains(cacheKey))
            {
                pendingLoadIds.Add(cacheKey);
                try
                {
                    Action<Sprite> callback = (Sprite loadedSprite) =>
                    {
                        pendingLoadIds.Remove(cacheKey);
                        if (IsSpriteValid(loadedSprite))
                        {
                            Rect crop = CalculateFaceCropRect(loadedSprite);
                            SaveThumbnail(loadedSprite.texture, crop, thumbBasePath);

                            Sprite generatedThumb = LoadThumbnailSprite(thumbBasePath);
                            Sprite finalSprite = IsSpriteValid(generatedThumb) ? generatedThumb : loadedSprite;

                            finalSprite.hideFlags = HideFlags.DontUnloadUnusedAsset;
                            UnityEngine.Object.DontDestroyOnLoad(finalSprite);
                            gcRoots.Add(finalSprite);
                            portraitCache[cacheKey] = finalSprite;

                            if (targetImage != null && targetImage.Pointer != IntPtr.Zero)
                            {
                                targetImage.sprite = finalSprite;
                                targetImage.preserveAspect = true;
                                targetImage.color = Color.white;
                                if (!targetImage.gameObject.activeSelf)
                                    targetImage.gameObject.SetActive(true);
                            }
                        }
                        else
                        {
                            missingPortraitCache.Add(cacheKey);
                        }
                    };

                    var coroutine = ImageLoader.LoadAsyncImage(charId, callback);
                    if (coroutine != null)
                    {
                        runner.StartCoroutine(coroutine);
                    }
                    else
                    {
                        missingPortraitCache.Add(cacheKey);
                    }
                }
                catch
                {
                    pendingLoadIds.Remove(cacheKey);
                    missingPortraitCache.Add(cacheKey);
                }
            }

            if (!isGSD2 || (runner == null && !pendingLoadIds.Contains(cacheKey)))
            {
                missingPortraitCache.Add(cacheKey);
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
