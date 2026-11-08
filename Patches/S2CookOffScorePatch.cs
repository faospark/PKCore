#nullable enable
extern alias GSD2;

using System;
using System.Text;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;

namespace PKCore.Patches;

/// <summary>
/// Live in-game scoring assistant for Suikoden 2's Cook-Off minigame (Chef Hai Yo).
/// Hooks into Overlay_rbattle to read the 4 seated judges and the currently highlighted recipe/spice,
/// calculating real-time predicted scores and displaying an on-screen recommendation card.
/// </summary>
public static class S2CookOffScorePatch
{
    // Public telemetry state accessible by PKDev ImGuiOverlayUI
    public static bool IsBattleActive { get; private set; }
    public static int[] ActiveJudgeTastes { get; } = new int[4];
    public static string[] ActiveJudgeNames { get; } = new string[4];
    public static byte CurrentCourse { get; private set; }
    public static CookOffScoreEngine.DishRecommendation? BestAppetizer { get; private set; }
    public static CookOffScoreEngine.DishRecommendation? BestMain { get; private set; }
    public static CookOffScoreEngine.DishRecommendation? BestDessert { get; private set; }
    public static CookOffScoreEngine.Dish? HighlightedDish { get; private set; }
    public static int HighlightedScore { get; private set; }
    public static int[] HighlightedJudgeScores { get; } = new int[4];

    private static GameObject? _hudRoot;
    private static Text? _hudText;
    private static Image? _hudBackground;
    private static float _lastActiveTime = 0f;
    private const float INACTIVE_TIMEOUT_SECONDS = 0.5f;

    /// <summary>
    /// Periodic tick to hide the HUD once the minigame or dish selection window is closed.
    /// </summary>
    public static void Update()
    {
        if (!IsBattleActive) return;

        if (Time.unscaledTime - _lastActiveTime > INACTIVE_TIMEOUT_SECONDS)
        {
            IsBattleActive = false;
            HideHUD();
        }
    }

    /// <summary>
    /// Harmony hook on Overlay_rbattle.RbattleFunc01 (active during menu/dish selection).
    /// </summary>
    [HarmonyPatch(typeof(GSD2::EventOverlayClass.Overlay_rbattle), nameof(GSD2::EventOverlayClass.Overlay_rbattle.RbattleFunc01))]
    [HarmonyPostfix]
    public static void RbattleFunc01_Postfix(GSD2::EventOverlayClass.Overlay_rbattle __instance, GSD2::EventOverlayClass.rbattle_h.RB_WORK rb_work)
    {
        if (!GameDetection.IsGSD2()) return;
        if (Plugin.Config?.ShowCookOffScoreHelper?.Value == false)
        {
            HideHUD();
            return;
        }

        if (rb_work == null || rb_work.exam_num == null || rb_work.exam_num.Length < 4)
            return;

        _lastActiveTime = Time.unscaledTime;
        IsBattleActive = true;

        // 1. Resolve Active Judges
        for (int i = 0; i < 4; i++)
        {
            byte charaId = rb_work.exam_num[i];
            ActiveJudgeTastes[i] = CookOffScoreEngine.GetJudgeTaste(charaId);
            ActiveJudgeNames[i] = CookOffScoreEngine.GetJudgeName(charaId);
        }

        // 2. Resolve Best Dishes for All Courses
        Func<int, bool> isUnlocked = CookOffScoreEngine.IsRecipeUnlocked;
        BestAppetizer = CookOffScoreEngine.FindBestDish(CookOffScoreEngine.Course.Appetizer, ActiveJudgeTastes, isUnlocked);
        BestMain = CookOffScoreEngine.FindBestDish(CookOffScoreEngine.Course.Main, ActiveJudgeTastes, isUnlocked);
        BestDessert = CookOffScoreEngine.FindBestDish(CookOffScoreEngine.Course.Dessert, ActiveJudgeTastes, isUnlocked);

        // 3. Resolve Current Selection & Potential Score
        CurrentCourse = rb_work.ychoice;
        int courseIdx = Math.Clamp((int)CurrentCourse, 0, 2);
        CookOffScoreEngine.Course activeCourse = (CookOffScoreEngine.Course)courseIdx;

        // Spices: 0=no spice, 1=Sugar, 2=Salt, 3=Soy Sauce, 4=Mayonnaise, 5=Red Pepper
        int spiceIdx = Math.Clamp((int)rb_work.pchoice, 0, CookOffScoreEngine.SpiceNames.Length - 1);
        string currentSpice = CookOffScoreEngine.SpiceNames[spiceIdx];

        // Resolve recipe from active rsp_table or rchoice
        int currentRecipeNum = 0;
        try
        {
            if (rb_work.rsp_table != null && rb_work.rchoice < rb_work.rsp_table.Length)
            {
                currentRecipeNum = rb_work.rsp_table[rb_work.rchoice];
            }
        }
        catch { }

        if (currentRecipeNum <= 0)
        {
            currentRecipeNum = rb_work.rchoice + 1;
        }

        HighlightedDish = CookOffScoreEngine.FindDish(currentRecipeNum, activeCourse, currentSpice);
        if (HighlightedDish != null)
        {
            HighlightedScore = CookOffScoreEngine.CalculateDishScore(HighlightedDish, ActiveJudgeTastes, HighlightedJudgeScores);
        }
        else
        {
            HighlightedScore = 0;
            Array.Clear(HighlightedJudgeScores, 0, 4);
        }

        // 4. Update On-Screen HUD Overlay
        UpdateHUD(activeCourse, currentSpice);
    }

    private static void UpdateHUD(CookOffScoreEngine.Course activeCourse, string currentSpice)
    {
        EnsureHUDCreated();
        if (_hudRoot == null || _hudText == null) return;

        _hudRoot.SetActive(true);

        var sb = new StringBuilder();
        sb.AppendLine("<color=#FFD700><b>★ COOK-OFF SCORING ASSISTANT ★</b></color>");

        // Judges Line
        sb.Append("<color=#A0E0FF>Judges:</color> ");
        for (int i = 0; i < 4; i++)
        {
            string tName = CookOffScoreEngine.TasteNames[ActiveJudgeTastes[i]];
            sb.Append($"<b>{ActiveJudgeNames[i]}</b> ({tName})");
            if (i < 3) sb.Append(" | ");
        }
        sb.AppendLine();

        // Highlighted Dish & Score
        if (HighlightedDish != null)
        {
            string scoreColor = HighlightedScore >= 16 ? "#00FF66" : (HighlightedScore >= 12 ? "#FFFF33" : "#FF6666");
            sb.AppendLine($"<color=#FFFFFF>Current Selection:</color> <b>{HighlightedDish.Name}</b> [Recipe #{HighlightedDish.RecipeNumber} + {HighlightedDish.Spice}]");
            sb.AppendLine($"<color=#FFFFFF>Potential Score:</color> <color={scoreColor}><b>{HighlightedScore} / 20 pts</b></color>  (Breakdown: {HighlightedJudgeScores[0]}+{HighlightedJudgeScores[1]}+{HighlightedJudgeScores[2]}+{HighlightedJudgeScores[3]})");
        }
        else
        {
            sb.AppendLine($"<color=#CCCCCC>Highlighting:</color> Course: {activeCourse} | Spice: {currentSpice}");
        }

        sb.AppendLine("<color=#777777>──────────────────────────────────────────────────────</color>");

        // Recommended Optimal Choices
        if (BestAppetizer != null)
        {
            string mark = activeCourse == CookOffScoreEngine.Course.Appetizer ? " <color=#00FFFF>◀</color>" : "";
            sb.AppendLine($"<color=#FFAA33>Best Appetizer:</color> {BestAppetizer.Dish.Name} ({BestAppetizer.Dish.Spice}) -> <b>{BestAppetizer.TotalScore}/20</b>{mark}");
        }
        if (BestMain != null)
        {
            string mark = activeCourse == CookOffScoreEngine.Course.Main ? " <color=#00FFFF>◀</color>" : "";
            sb.AppendLine($"<color=#FFAA33>Best Main:</color> {BestMain.Dish.Name} ({BestMain.Dish.Spice}) -> <b>{BestMain.TotalScore}/20</b>{mark}");
        }
        if (BestDessert != null)
        {
            string mark = activeCourse == CookOffScoreEngine.Course.Dessert ? " <color=#00FFFF>◀</color>" : "";
            sb.AppendLine($"<color=#FFAA33>Best Dessert:</color> {BestDessert.Dish.Name} ({BestDessert.Dish.Spice}) -> <b>{BestDessert.TotalScore}/20</b>{mark}");
        }

        _hudText.text = sb.ToString();
    }

    private static void HideHUD()
    {
        if (_hudRoot != null)
        {
            _hudRoot.SetActive(false);
        }
    }

    private static void EnsureHUDCreated()
    {
        if (_hudRoot != null) return;

        try
        {
            GameObject canvasRoot = GameObject.Find("UI_Root/UI_Canvas_Root");
            if (canvasRoot == null) return;

            _hudRoot = new GameObject("PKCore_CookOffScoreHUD");
            _hudRoot.transform.SetParent(canvasRoot.transform, false);

            RectTransform rect = _hudRoot.AddComponent<RectTransform>();
            rect.anchorMin = new Vector2(1f, 1f);
            rect.anchorMax = new Vector2(1f, 1f);
            rect.pivot = new Vector2(1f, 1f);
            rect.sizeDelta = new Vector2(490f, 185f);
            rect.anchoredPosition = new Vector2(-25f, -25f);

            // Dark translucent panel background
            _hudBackground = _hudRoot.AddComponent<Image>();
            _hudBackground.color = new Color(0.04f, 0.07f, 0.12f, 0.88f);
            _hudBackground.raycastTarget = false;

            // Text Label
            GameObject textObj = new GameObject("ScoreText");
            textObj.transform.SetParent(_hudRoot.transform, false);

            RectTransform textRect = textObj.AddComponent<RectTransform>();
            textRect.anchorMin = Vector2.zero;
            textRect.anchorMax = Vector2.one;
            textRect.offsetMin = new Vector2(14f, 10f);
            textRect.offsetMax = new Vector2(-14f, -10f);

            _hudText = textObj.AddComponent<Text>();
            _hudText.supportRichText = true;
            _hudText.fontSize = 15;
            _hudText.lineSpacing = 1.15f;
            _hudText.alignment = TextAnchor.UpperLeft;
            _hudText.raycastTarget = false;

            // Borrow font from existing canvas texts if possible
            Text existingText = canvasRoot.GetComponentInChildren<Text>();
            if (existingText != null && existingText.font != null)
            {
                _hudText.font = existingText.font;
            }
            else
            {
                _hudText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            }
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[CookOffScoreHUD] Failed to create HUD: {ex.Message}");
        }
    }
}
