using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PKCore.Patches;

/// <summary>
/// Enhances the launcher gallery screens (Movies, Events, Sounds) with custom backgrounds.
/// Controlled by the EnhancedGallery config option (independent of PSPLauncher).
/// </summary>
public static class PSPGalleryEnhanced
{
    private static bool _soundsBgCreated = false;
    private static string _currentMoviesBgName = null;
    private static Texture2D _moviesBgTex = null;
    private static Texture2D _eventsBgTex = null;

    public static void Update()
    {
        if (SceneManager.GetActiveScene().name != "Main")
        {
            _soundsBgCreated = false;
            _currentMoviesBgName = null;
            _moviesBgTex = null;
            _eventsBgTex = null;
            return;
        }

        // UI_Bg_02(Clone): disable Line and bg_gradation, recolor bg
        GameObject uiBg02 = GameObject.Find("UI_Root/UI_Canvas_Root/UI_Bg_02(Clone)");
        if (uiBg02 != null)
        {
            Transform line = uiBg02.transform.Find("Line");
            if (line != null)
            {
                line.gameObject.SetActive(false);
            }

            Transform bgGradation = uiBg02.transform.Find("bg_gradation");
            if (bgGradation != null)
            {
                bgGradation.gameObject.SetActive(false);
            }

            Transform bg = uiBg02.transform.Find("bg");
            if (bg != null)
            {
                Image bgImage = bg.GetComponent<Image>();
                if (bgImage != null)
                {
                    bgImage.color = new Color(0.1f, 0.345f, 0.922f, 1f);
                }
            }
        }

        // Handle UI_Com_Footer
        GameObject uiFooter = GameObject.Find("UI_Root/UI_Canvas_Root/UI_Com_Footer(Clone)");
        if (uiFooter != null)
        {
            Transform imgBg = uiFooter.transform.Find("Img_Bg");
            if (imgBg != null)
            {
                // Disable the original Img_Bg Image component but keep the GameObject active for hierarchy
                Image originalBgImg = imgBg.GetComponent<Image>();
                if (originalBgImg != null && originalBgImg.enabled)
                {
                    originalBgImg.enabled = false;
                }

                // Disable child Img_Bg object inside Img_Bg
                Transform nestedImgBg = imgBg.Find("Img_Bg");
                if (nestedImgBg != null && nestedImgBg.gameObject.activeSelf)
                {
                    nestedImgBg.gameObject.SetActive(false);
                }

                if (imgBg.Find("footerbg") == null)
                {
                    GameObject footerBgGO = new GameObject("footerbg");
                    footerBgGO.transform.SetParent(imgBg, false);
                    footerBgGO.transform.SetSiblingIndex(0); // Put it behind everything

                    RectTransform footerBgRt = footerBgGO.AddComponent<RectTransform>();
                    footerBgRt.anchorMin = new Vector2(0f, 0f);
                    footerBgRt.anchorMax = new Vector2(1f, 0f); // Stretch horizontally, pivot to bottom vertical
                    footerBgRt.pivot = new Vector2(0.5f, 0f);
                    footerBgRt.sizeDelta = new Vector2(0f, 105f); // 150f is the height. Change this number to adjust height!
                    footerBgRt.anchoredPosition = Vector2.zero;

                    Image footerBgImg = footerBgGO.AddComponent<Image>();
                    footerBgImg.color = new Color(0f, 0f, 0f, 0.7f); // Black with 50% alpha
                    footerBgImg.raycastTarget = false;
                }
            }
        }

        // ── Sound gallery background ───────────────────────────────────────────
        if (!_soundsBgCreated)
        {
            var soundList = GameObject.Find("UI_Root/UI_Canvas_Root/GalleryParent/UI_SoundList_01(Clone)/Window01");
            if (soundList != null)
            {
                TryInsertGalleryBg(soundList, "PSPGallerySoundsBg", ref _soundsBgCreated, new Vector2(1920, 1080), new Vector2(0, 54));

                var titleArea = soundList.transform.Find("Title_Area");
                if (titleArea != null)
                {
                    var fontBehavior = titleArea.Find("Font_Behavior");
                    if (fontBehavior != null) fontBehavior.gameObject.SetActive(true);

                    var title1 = titleArea.Find("Text_Title (1)");
                    if (title1 != null)
                    {
                        var tmp1 = title1.GetComponent<TMPro.TextMeshProUGUI>();
                        if (tmp1 != null) tmp1.color = new Color(1f, 1f, 1f, 1f);
                    }

                    var title2 = titleArea.Find("Text_Title (2)");
                    if (title2 != null)
                    {
                        var tmp2 = title2.GetComponent<TMPro.TextMeshProUGUI>();
                        if (tmp2 != null) tmp2.color = new Color(1f, 1f, 1f, 1f);
                    }
                }
            }
        }

        // ── Movies / Events gallery background (tab-switching, runs every frame) ──
        {
            var galleryMovies = GameObject.Find("UI_Root/UI_Canvas_Root/GalleryParent/UI_Gallery_01(Clone)/Window01");
            if (galleryMovies != null)
            {
                var imgSelectMovies = GameObject.Find("UI_Root/UI_Canvas_Root/GalleryParent/UI_Gallery_Top01(Clone)/Scroll View/Viewport/Content/UI_Gallery_Button_Set (1)/Img_Select");
                var imgSelectEvents = GameObject.Find("UI_Root/UI_Canvas_Root/GalleryParent/UI_Gallery_Top01(Clone)/Scroll View/Viewport/Content/UI_Gallery_Button_Set (2)/Img_Select");

                string desired = null;
                Texture2D desiredTex = null;

                if (imgSelectMovies != null && imgSelectMovies.activeSelf)
                {
                    desired = "PSPGalleryMoviesBg";
                    if (_moviesBgTex == null) _moviesBgTex = CustomTexturePatch.LoadCustomTexture(desired);
                    desiredTex = _moviesBgTex;
                }
                else if (imgSelectEvents != null && imgSelectEvents.activeSelf)
                {
                    desired = "PSPGalleryEventsBg";
                    if (_eventsBgTex == null) _eventsBgTex = CustomTexturePatch.LoadCustomTexture(desired);
                    desiredTex = _eventsBgTex;
                }

                if (desired != null && desired != _currentMoviesBgName)
                {
                    if (_currentMoviesBgName != null)
                    {
                        var old = galleryMovies.transform.Find(_currentMoviesBgName);
                        if (old != null) UnityEngine.Object.Destroy(old.gameObject);
                    }
                    bool dummy = false;
                    TryInsertGalleryBg(galleryMovies, desired, ref dummy, new Vector2(1920, 1080), new Vector2(0, 12f), desiredTex);
                    _currentMoviesBgName = desired;
                }

                var imgBg = galleryMovies.transform.Find("Img_bg");
                if (imgBg != null) imgBg.localScale = new Vector3(0.89f, 0.8f, 1f);

                var imgFlame = galleryMovies.transform.Find("Img_Flame");
                if (imgFlame != null) imgFlame.localScale = new Vector3(0.89f, 0.8f, 1f);

                var scrollView = galleryMovies.transform.Find("Scroll View");
                if (scrollView != null) scrollView.localScale = new Vector3(0.8f, 0.8f, 1f);
            }
        }
    }

    private static void TryInsertGalleryBg(GameObject parent, string textureName, ref bool createdFlag, Vector2 fixedSize = default, Vector2 anchoredPos = default, Texture2D preloadedTex = null)
    {
        if (parent.transform.Find(textureName) != null)
        {
            createdFlag = true;
            return;
        }

        Texture2D tex = preloadedTex != null ? preloadedTex : CustomTexturePatch.LoadCustomTexture(textureName);
        if (tex == null)
        {
            Plugin.Log.LogWarning($"[PSPGalleryEnhanced] {textureName} texture not found. Place {textureName}.png in PKCore/Textures/.");
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
            bgRt.anchoredPosition = anchoredPos;
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

        createdFlag = true;
    }
}
