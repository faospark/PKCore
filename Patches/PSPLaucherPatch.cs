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

    // How long (seconds) it takes the overlay to travel across the screen
    private const float OverlayScrollDuration = 12f;

    public static void Update()
    {
        if (SceneManager.GetActiveScene().name != "Main")
        {
            _bgCreated = false;
            return;
        }

        var waterObject = GameObject.Find("Launcher_Root_Variant(Clone)/Launcher_Root_3d_bg/model_water");
        if (waterObject != null && waterObject.activeSelf)
        {
            waterObject.SetActive(false);
        }

        if (!_bgCreated)
        {
            var launcherUI = GameObject.Find("Launcher_Root_Variant(Clone)/Launcher_Root_UI/UI_Canvas");
            if (launcherUI != null)
                TryInsertBackground(launcherUI);
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

        // Disable screen_gradation overlay
        Transform screenGradation = launcherRoot.transform.Find("screen/screen_gradation");
        if (screenGradation != null)
        {
            screenGradation.gameObject.SetActive(false);
        }

        // Disable screen/frame
        Transform screenFrame = launcherRoot.transform.Find("screen/frame");
        if (screenFrame != null)
        {
            screenFrame.gameObject.SetActive(false);
        }

        // Disable screen/title
        Transform screenTitle = launcherRoot.transform.Find("screen/title");
        if (screenTitle != null)
        {
            screenTitle.gameObject.SetActive(false);
        }

        // Insert new UI_Top_Title02_003
        Transform screenGroup = launcherRoot.transform.Find("screen");
        if (screenGroup != null && screenGroup.Find("UI_Top_Title02_003") == null)
        {
            Texture2D titleTex = CustomTexturePatch.LoadCustomTexture("UI_Top_Title02_003");
            if (titleTex != null)
            {
                GameObject titleGO = new GameObject("UI_Top_Title02_003");
                titleGO.transform.SetParent(screenGroup, false);

                RectTransform titleRt = titleGO.AddComponent<RectTransform>();
                titleRt.anchorMin = new Vector2(0.5f, 0.5f);
                titleRt.anchorMax = new Vector2(0.5f, 0.5f);
                titleRt.pivot     = new Vector2(0.5f, 0.5f);
                titleRt.sizeDelta = new Vector2(titleTex.width, titleTex.height);
                
                // Start with the same location/scale as the original title override
                titleRt.localScale = new Vector3(0.55f, 0.55f, 1f);
                titleRt.localPosition = new Vector3(0, 354.713f, 0f);

                Image titleImg = titleGO.AddComponent<Image>();
                titleImg.sprite = Sprite.Create(titleTex, new Rect(0, 0, titleTex.width, titleTex.height), new Vector2(0.5f, 0.5f), 100f);
                titleImg.color = Color.white;
                titleImg.raycastTarget = false;
            }
            else
            {
                Plugin.Log.LogWarning("[PSPLauncherPatch] UI_Top_Title02_003 texture not found. Place UI_Top_Title02_003.png in PKCore/Textures/.");
            }
        }

        // Disable header_nuetral
        Transform headerNeutral = launcherRoot.transform.Find("header_group/header_nuetral");
        if (headerNeutral != null)
        {
            headerNeutral.gameObject.SetActive(false);
        }

        Transform headerGs1 = launcherRoot.transform.Find("header_group/header_gs1");
        if (headerGs1 != null)
        {
            headerGs1.gameObject.SetActive(false);
        }

        Transform headerGs2 = launcherRoot.transform.Find("header_group/header_gs2");
        if (headerGs2 != null)
        {
            headerGs2.gameObject.SetActive(false);
        }

        // --- Scrolling overlay (index 1, just above bg) ---
        Texture2D overlayTex = CustomTexturePatch.LoadCustomTexture("PSPLauncherOverlay");
        if (overlayTex != null)
        {
            CreateScrollingOverlay(launcherRoot, overlayTex);
        }


        // Reposition menu_gs1/all and disable its reflect child
        Transform gs1All = launcherRoot.transform.Find("menu_group/menu_title/menu_gs1/all");
        if (gs1All != null)
        {
            gs1All.localPosition = new Vector3(-0.0004f, -73.1621f, 0f);

            Transform gs1Reflect = gs1All.Find("reflect");
            if (gs1Reflect != null)
            {
                gs1Reflect.gameObject.SetActive(false);
            }

            Transform gs1Body = gs1All.Find("body");
            if (gs1Body != null)
            {
                Transform gs1Title = gs1Body.Find("title");
                if (gs1Title != null)
                {
                    gs1Title.gameObject.SetActive(false);
                }

                Transform gs1Pic = gs1Body.Find("pic");
                if (gs1Pic != null)
                {
                    gs1Pic.gameObject.SetActive(false);
                }

                if (gs1Body.Find("UI_Top_Title_BG_GSD1") == null)
                {
                    Texture2D bgTex1 = CustomTexturePatch.LoadCustomTexture("UI_Top_Title_BG_GSD1");
                    if (bgTex1 != null)
                    {
                        GameObject bgGO1 = new GameObject("UI_Top_Title_BG_GSD1");
                        bgGO1.transform.SetParent(gs1Body, false);
                        
                        Transform efc1 = gs1Body.Find("efc_active");
                        if (efc1 != null)
                            bgGO1.transform.SetSiblingIndex(efc1.GetSiblingIndex() + 1);
                        else
                            bgGO1.transform.SetAsFirstSibling();

                        RectTransform bgRt1 = bgGO1.AddComponent<RectTransform>();
                        bgRt1.anchorMin = new Vector2(0.5f, 0.5f);
                        bgRt1.anchorMax = new Vector2(0.5f, 0.5f);
                        bgRt1.pivot = new Vector2(0.5f, 0.5f);
                        bgRt1.sizeDelta = new Vector2(bgTex1.width, bgTex1.height);
                        bgRt1.localPosition = new Vector3(-11f, 256.5577f, 0f);
                        bgRt1.localScale = new Vector3(0.9f, 0.9f, 1f);

                        Image bgImg1 = bgGO1.AddComponent<Image>();
                        bgImg1.sprite = Sprite.Create(bgTex1, new Rect(0, 0, bgTex1.width, bgTex1.height), new Vector2(0.5f, 0.5f), 100f);
                        bgImg1.color = Color.white;
                        bgImg1.raycastTarget = false;
                    }
                    else
                    {
                        Plugin.Log.LogWarning("[PSPLauncherPatch] UI_Top_Title_BG_GSD1 texture not found. Place UI_Top_Title_BG_GSD1.png in PKCore/Textures/.");
                    }
                }

                if (gs1Body.Find("PSPSuikoden1Logo") == null)
                {
                    Texture2D logoTex = CustomTexturePatch.LoadCustomTexture("PSPSuikoden1Logo");
                    if (logoTex != null)
                    {
                        GameObject logoGO = new GameObject("PSPSuikoden1Logo");
                        logoGO.transform.SetParent(gs1Body, false);

                        RectTransform logoRt = logoGO.AddComponent<RectTransform>();
                        logoRt.anchorMin = new Vector2(0.5f, 0.5f);
                        logoRt.anchorMax = new Vector2(0.5f, 0.5f);
                        logoRt.pivot     = new Vector2(0.5f, 0.5f);
                        logoRt.sizeDelta = new Vector2(logoTex.width, logoTex.height);
                        logoRt.localScale = new Vector3(0.18f, 0.18f, 1f);
                        logoGO.transform.localPosition = new Vector3(2.6419f, 437.0217f, 0f);

                        Image logoImg = logoGO.AddComponent<Image>();
                        logoImg.sprite = Sprite.Create(logoTex, new Rect(0, 0, logoTex.width, logoTex.height), new Vector2(0.5f, 0.5f), 100f);
                        logoImg.color = Color.white;
                        logoImg.raycastTarget = false;
                    }
                    else
                    {
                        Plugin.Log.LogWarning("[PSPLauncherPatch] PSPSuikoden1Logo texture not found. Place PSPSuikoden1Logo.png in PKCore/Textures/.");
                    }
                }
            }
        }

        // Reposition menu_gs2/all and disable its reflect child
        Transform gs2All = launcherRoot.transform.Find("menu_group/menu_title/menu_gs2/all");
        if (gs2All != null)
        {
            gs2All.localPosition = new Vector3(0.0004f, -78.1504f, 0f);

            Transform gs2Reflect = gs2All.Find("reflect");
            if (gs2Reflect != null)
            {
                gs2Reflect.gameObject.SetActive(false);
            }

            Transform gs2Body = gs2All.Find("body");
            if (gs2Body != null)
            {
                Transform gs2Title = gs2Body.Find("title");
                if (gs2Title != null)
                {
                    gs2Title.gameObject.SetActive(false);
                }

                Transform gs2Pic = gs2Body.Find("pic");
                if (gs2Pic != null)
                {
                    gs2Pic.gameObject.SetActive(false);
                }

                if (gs2Body.Find("UI_Top_Title_BG_GSD2") == null)
                {
                    Texture2D bgTex2 = CustomTexturePatch.LoadCustomTexture("UI_Top_Title_BG_GSD2");
                    if (bgTex2 != null)
                    {
                        GameObject bgGO2 = new GameObject("UI_Top_Title_BG_GSD2");
                        bgGO2.transform.SetParent(gs2Body, false);
                        
                        Transform efc2 = gs2Body.Find("efc_active");
                        if (efc2 != null)
                            bgGO2.transform.SetSiblingIndex(efc2.GetSiblingIndex() + 1);
                        else
                            bgGO2.transform.SetAsFirstSibling();

                        RectTransform bgRt2 = bgGO2.AddComponent<RectTransform>();
                        bgRt2.anchorMin = new Vector2(0.5f, 0.5f);
                        bgRt2.anchorMax = new Vector2(0.5f, 0.5f);
                        bgRt2.pivot = new Vector2(0.5f, 0.5f);
                        bgRt2.sizeDelta = new Vector2(bgTex2.width, bgTex2.height);
                        bgRt2.localPosition = new Vector3(-3.9999f, 236.2321f, 0f);
                        bgRt2.localScale = new Vector3(0.9f, 0.9f, 1f);

                        Image bgImg2 = bgGO2.AddComponent<Image>();
                        bgImg2.sprite = Sprite.Create(bgTex2, new Rect(0, 0, bgTex2.width, bgTex2.height), new Vector2(0.5f, 0.5f), 100f);
                        bgImg2.color = Color.white;
                        bgImg2.raycastTarget = false;
                    }
                    else
                    {
                        Plugin.Log.LogWarning("[PSPLauncherPatch] UI_Top_Title_BG_GSD2 texture not found. Place UI_Top_Title_BG_GSD2.png in PKCore/Textures/.");
                    }
                }

                if (gs2Body.Find("PSPSuikoden2Logo") == null)
                {
                    Texture2D logo2Tex = CustomTexturePatch.LoadCustomTexture("PSPSuikoden2Logo");
                    if (logo2Tex != null)
                    {
                        GameObject logo2GO = new GameObject("PSPSuikoden2Logo");
                        logo2GO.transform.SetParent(gs2Body, false);

                        RectTransform logo2Rt = logo2GO.AddComponent<RectTransform>();
                        logo2Rt.anchorMin = new Vector2(0.5f, 0.5f);
                        logo2Rt.anchorMax = new Vector2(0.5f, 0.5f);
                        logo2Rt.pivot     = new Vector2(0.5f, 0.5f);
                        logo2Rt.sizeDelta = new Vector2(logo2Tex.width, logo2Tex.height);
                        logo2Rt.localScale = new Vector3(0.3f, 0.3f, 1f);
                        logo2GO.transform.localPosition = new Vector3(-5.1141f, 393.6655f, 0f);

                        Image logo2Img = logo2GO.AddComponent<Image>();
                        logo2Img.sprite = Sprite.Create(logo2Tex, new Rect(0, 0, logo2Tex.width, logo2Tex.height), new Vector2(0.5f, 0.5f), 100f);
                        logo2Img.color = Color.white;
                        logo2Img.raycastTarget = false;
                    }
                    else
                    {
                        Plugin.Log.LogWarning("[PSPLauncherPatch] PSPSuikoden2Logo texture not found. Place PSPSuikoden2Logo.png in PKCore/Textures/.");
                    }
                }
            }
        }

        _bgCreated = true;
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

    }
}

