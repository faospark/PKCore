using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PKCore.Patches;

public static class PSPLauncherPatch
{
    private static bool _bgCreated = false;
    private static bool _soundsBgCreated = false;
    private static string _currentMoviesBgName = null;

    // How long (seconds) it takes the overlay to travel across the screen
    private const float OverlayScrollDuration = 12f;

    public static void Update()
    {
        if (SceneManager.GetActiveScene().name != "Main")
        {
            _bgCreated = false;
            _soundsBgCreated = false;
            _currentMoviesBgName = null;
            return;
        }

        var waterObject = GameObject.Find("Launcher_Root_Variant(Clone)/Launcher_Root_3d_bg/model_water");
        if (waterObject != null && waterObject.activeSelf)
        {
            waterObject.SetActive(false);
            Plugin.Log.LogInfo("[PSPLauncherPatch] Successfully disabled model_water on Launcher.");
        }

        if (!_bgCreated)
        {
            var launcherUI = GameObject.Find("Launcher_Root_Variant(Clone)/Launcher_Root_UI/UI_Canvas");
            if (launcherUI != null)
                TryInsertBackground(launcherUI);
        }

        if (!_soundsBgCreated)
        {
            var soundList = GameObject.Find("UI_Root/UI_Canvas_Root/GalleryParent/UI_SoundList_01(Clone)/Window01");
            if (soundList != null)
                TryInsertGalleryBg(soundList, "PSPGallerySoundsBg", ref _soundsBgCreated, new Vector2(1920, 1080));
        }

        {
            var galleryMovies = GameObject.Find("UI_Root/UI_Canvas_Root/GalleryParent/UI_Gallery_01(Clone)/Window01");
            if (galleryMovies != null)
            {
                var imgSelectMovies = GameObject.Find("UI_Root/UI_Canvas_Root/GalleryParent/UI_Gallery_Top01(Clone)/Scroll View/Viewport/Content/UI_Gallery_Button_Set (1)/Img_Select");
                var imgSelectEvents = GameObject.Find("UI_Root/UI_Canvas_Root/GalleryParent/UI_Gallery_Top01(Clone)/Scroll View/Viewport/Content/UI_Gallery_Button_Set (2)/Img_Select");

                string desired = null;
                if (imgSelectMovies != null && imgSelectMovies.activeSelf)
                    desired = "PSPGalleryMoviesBg";
                else if (imgSelectEvents != null && imgSelectEvents.activeSelf)
                    desired = "PSPGalleryEventsBg";

                if (desired != null && desired != _currentMoviesBgName)
                {
                    if (_currentMoviesBgName != null)
                    {
                        var old = galleryMovies.transform.Find(_currentMoviesBgName);
                        if (old != null) UnityEngine.Object.Destroy(old.gameObject);
                    }
                    bool dummy = false;
                    TryInsertGalleryBg(galleryMovies, desired, ref dummy, new Vector2(1920, 1080));
                    _currentMoviesBgName = desired;
                }
            }
        }
    }

    private static void TryInsertBackground(GameObject launcherRoot)
    {
        if (launcherRoot.transform.Find("PSPBg") != null)
        {
            _bgCreated = true;
            return;
        }

        Texture2D tex = CustomTexturePatch.LoadCustomTexture("PSPLauncherbg");
        if (tex == null)
        {
            Plugin.Log.LogWarning("[PSPLauncherPatch] PSPLauncherbg texture not found. Place PSPLauncherbg.png in PKCore/Textures/.");
            _bgCreated = true;
            return;
        }

        // --- Background (index 0, behind everything) ---
        GameObject bgGO = new GameObject("PSPBg");
        bgGO.transform.SetParent(launcherRoot.transform, false);
        bgGO.transform.SetSiblingIndex(0);

        RectTransform bgRt = bgGO.AddComponent<RectTransform>();
        bgRt.anchorMin = Vector2.zero;
        bgRt.anchorMax = Vector2.one;
        bgRt.offsetMin = Vector2.zero;
        bgRt.offsetMax = Vector2.zero;

        Image bgImg = bgGO.AddComponent<Image>();
        bgImg.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100f);
        bgImg.color = Color.white;
        bgImg.raycastTarget = false;

        Plugin.Log.LogInfo("[PSPLauncherPatch] PSPBg fullscreen background inserted.");

        // Disable screen_gradation overlay
        Transform screenGradation = launcherRoot.transform.Find("screen/screen_gradation");
        if (screenGradation != null)
        {
            screenGradation.gameObject.SetActive(false);
            Plugin.Log.LogInfo("[PSPLauncherPatch] Disabled screen_gradation.");
        }

        // Disable screen/frame
        Transform screenFrame = launcherRoot.transform.Find("screen/frame");
        if (screenFrame != null)
        {
            screenFrame.gameObject.SetActive(false);
            Plugin.Log.LogInfo("[PSPLauncherPatch] Disabled screen/frame.");
        }

        // Reposition and scale screen/title
        Transform screenTitle = launcherRoot.transform.Find("screen/title");
        if (screenTitle != null)
        {
            screenTitle.localScale = new Vector3(2f, 2f, 1f);
            screenTitle.localPosition = new Vector3(35.0683f, 354.713f, 0f);
            Plugin.Log.LogInfo("[PSPLauncherPatch] Applied scale/position to screen/title.");
        }

        // Disable header_nuetral
        Transform headerNeutral = launcherRoot.transform.Find("header_group/header_nuetral");
        if (headerNeutral != null)
        {
            headerNeutral.gameObject.SetActive(false);
            Plugin.Log.LogInfo("[PSPLauncherPatch] Disabled header_nuetral.");
        }

        // --- Scrolling overlay (index 1, just above bg) ---
        Texture2D overlayTex = CustomTexturePatch.LoadCustomTexture("PSPLauncherOverlay");
        if (overlayTex != null)
        {
            CreateScrollingOverlay(launcherRoot, overlayTex);
        }
        else
        {
            Plugin.Log.LogInfo("[PSPLauncherPatch] No PSPLauncherOverlay texture found — skipping overlay.");
        }

        // Reposition menu_gs1/all and disable its reflect child
        Transform gs1All = launcherRoot.transform.Find("menu_group/menu_title/menu_gs1/all");
        if (gs1All != null)
        {
            gs1All.localPosition = new Vector3(-0.0004f, -73.1621f, 0f);
            Plugin.Log.LogInfo("[PSPLauncherPatch] Applied position to menu_gs1/all.");

            Transform gs1Reflect = gs1All.Find("reflect");
            if (gs1Reflect != null)
            {
                gs1Reflect.gameObject.SetActive(false);
                Plugin.Log.LogInfo("[PSPLauncherPatch] Disabled reflect on menu_gs1/all.");
            }
        }

        // Reposition menu_gs2/all and disable its reflect child
        Transform gs2All = launcherRoot.transform.Find("menu_group/menu_title/menu_gs2/all");
        if (gs2All != null)
        {
            gs2All.localPosition = new Vector3(0.0004f, -78.1504f, 0f);
            Plugin.Log.LogInfo("[PSPLauncherPatch] Applied position to menu_gs2/all.");

            Transform gs2Reflect = gs2All.Find("reflect");
            if (gs2Reflect != null)
            {
                gs2Reflect.gameObject.SetActive(false);
                Plugin.Log.LogInfo("[PSPLauncherPatch] Disabled reflect on menu_gs2/all.");
            }
        }

        // UI_Bg_02(Clone): disable Line and bg_gradation, recolor bg
        GameObject uiBg02 = GameObject.Find("UI_Root/UI_Canvas_Root/UI_Bg_02(Clone)");
        if (uiBg02 != null)
        {
            Transform line = uiBg02.transform.Find("Line");
            if (line != null)
            {
                line.gameObject.SetActive(false);
                Plugin.Log.LogInfo("[PSPLauncherPatch] Disabled Line on UI_Bg_02(Clone).");
            }

            Transform bgGradation = uiBg02.transform.Find("bg_gradation");
            if (bgGradation != null)
            {
                bgGradation.gameObject.SetActive(false);
                Plugin.Log.LogInfo("[PSPLauncherPatch] Disabled bg_gradation on UI_Bg_02(Clone).");
            }

            Transform bg = uiBg02.transform.Find("bg");
            if (bg != null)
            {
                Image bgImage = bg.GetComponent<Image>();
                if (bgImage != null)
                {
                    bgImage.color = new Color(0.1f, 0.345f, 0.922f, 1f);
                    Plugin.Log.LogInfo("[PSPLauncherPatch] Set bg color on UI_Bg_02(Clone)/bg.");
                }
            }
        }

        _bgCreated = true;
    }

    private static void TryInsertGalleryBg(GameObject parent, string textureName, ref bool createdFlag, Vector2 fixedSize = default)
    {
        if (parent.transform.Find(textureName) != null)
        {
            createdFlag = true;
            return;
        }

        Texture2D tex = CustomTexturePatch.LoadCustomTexture(textureName);
        if (tex == null)
        {
            Plugin.Log.LogWarning($"[PSPLauncherPatch] {textureName} texture not found. Place {textureName}.png in PKCore/Textures/.");
            createdFlag = true;
            return;
        }

        GameObject bgGO = new GameObject(textureName);
        bgGO.transform.SetParent(parent.transform, false);
        bgGO.transform.SetSiblingIndex(0);

        RectTransform bgRt = bgGO.AddComponent<RectTransform>();
        if (fixedSize != default)
        {
            bgRt.anchorMin = new Vector2(0.5f, 0.5f);
            bgRt.anchorMax = new Vector2(0.5f, 0.5f);
            bgRt.pivot     = new Vector2(0.5f, 0.5f);
            bgRt.sizeDelta = fixedSize;
            bgRt.anchoredPosition = Vector2.zero;
        }
        else
        {
            bgRt.anchorMin = Vector2.zero;
            bgRt.anchorMax = Vector2.one;
            bgRt.offsetMin = Vector2.zero;
            bgRt.offsetMax = Vector2.zero;
        }

        Image bgImg = bgGO.AddComponent<Image>();
        bgImg.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100f);
        bgImg.color = Color.white;
        bgImg.raycastTarget = false;

        Plugin.Log.LogInfo($"[PSPLauncherPatch] {textureName} background inserted into {parent.name}.");
        createdFlag = true;
    }

    private static void CreateScrollingOverlay(GameObject parent, Texture2D tex)
    {
        // Two-tile seamless scroll:
        // A container holding two side-by-side copies of the texture is animated
        // one tile-width to the left, then restarts. At the restart point tile B
        // is exactly where tile A started, so the loop is invisible.

        const float tileWidth = 1920f;

        // Container: left-anchored, full height, 2× tile width
        GameObject containerGO = new GameObject("PSPOverlay");
        containerGO.transform.SetParent(parent.transform, false);
        containerGO.transform.SetSiblingIndex(1); // just above PSPBg

        RectTransform containerRt = containerGO.AddComponent<RectTransform>();
        containerRt.anchorMin = new Vector2(0f, 0f);
        containerRt.anchorMax = new Vector2(0f, 1f);
        containerRt.pivot     = new Vector2(0f, 0.5f);
        containerRt.sizeDelta = new Vector2(tileWidth * 2f, 0f);
        containerRt.anchoredPosition = Vector2.zero; // flush with left edge of parent

        // Tile A (left) and Tile B (right)
        for (int i = 0; i < 2; i++)
        {
            GameObject tileGO = new GameObject($"PSPOverlayTile{i}");
            tileGO.transform.SetParent(containerGO.transform, false);

            RectTransform tileRt = tileGO.AddComponent<RectTransform>();
            tileRt.anchorMin = new Vector2(0f, 0f);
            tileRt.anchorMax = new Vector2(0f, 1f);
            tileRt.pivot     = new Vector2(0f, 0.5f);
            tileRt.sizeDelta = new Vector2(tileWidth, 0f);
            tileRt.anchoredPosition = new Vector2(tileWidth * i, 0f);

            Image img = tileGO.AddComponent<Image>();
            img.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100f);
            img.color = Color.white;
            img.raycastTarget = false;
        }

        // Animate container from x=0 → x=-tileWidth, then Restart (seamless)
        containerRt.DOAnchorPosX(-tileWidth, OverlayScrollDuration)
          .SetEase(Ease.Linear)
          .SetLoops(-1, LoopType.Restart)
          .SetUpdate(UpdateType.Normal, true);

        Plugin.Log.LogInfo($"[PSPLauncherPatch] PSPOverlay seamless scroll started ({OverlayScrollDuration}s loop).");
    }
}

