#nullable enable
extern alias GSD2;

using System;
using System.Collections.Generic;
using HarmonyLib;
using UnityEngine;
using TMPro;

namespace PKCore.Patches;

/// <summary>
/// Live in-game scoring assistant for Suikoden 2's Cook-Off minigame (Chef Hai Yo).
/// Directly modifies native in-game menu TextMeshProUGUI elements:
/// - In the Course menu: colors "Appetizer", "Main Course", and "Dessert" with their signature colors
///   and shows the recommended best recipe:
///     - Appetizer:   #66CCFF (Sky Blue)
///     - Main Course: #FFAA33 (Warm Amber)
///     - Dessert:     #FF77A9 (Sweet Pink)
/// - In the Recipe selection menu: each recipe is dynamically color-coded by the Course
///   where it achieves its highest possible score with the current judges!
///   Shows its max predicted score and optimal seasoning (e.g. "Cake [17:Sugar]").
/// - In the Seasoning selection menu: seasonings show their exact score (e.g. "Sugar [17]").
/// Title headers and dialogue prompts are left untouched.
/// </summary>
public static class S2CookOffScorePatch
{
    // Public telemetry state accessible by PKDev or external monitors
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
    private static float _lastActiveTime = 0f;
    private const float INACTIVE_TIMEOUT_SECONDS = 0.5f;
    private static int _lastSelectedRecipeNum = 0;

    // Course Signature Colors
    public const string COLOR_APPETIZER = "#66CCFF"; // Sky Blue
    public const string COLOR_MAIN = "#FFAA33";      // Warm Amber
    public const string COLOR_DESSERT = "#FF77A9";   // Sweet Pink

    public static string GetCourseColor(CookOffScoreEngine.Course course) => course switch
    {
        CookOffScoreEngine.Course.Appetizer => COLOR_APPETIZER,
        CookOffScoreEngine.Course.Main => COLOR_MAIN,
        CookOffScoreEngine.Course.Dessert => COLOR_DESSERT,
        _ => "#FFFFFF"
    };

    private static readonly Dictionary<string, string> SpiceAliases = new(StringComparer.OrdinalIgnoreCase)
    {
        { "Sugar", "Sugar" },
        { "Salt", "Salt" },
        { "Soy Sauce", "Soy Sauce" },
        { "Mayonnaise", "Mayonnaise" },
        { "Red Pepper", "Red Pepper" },
        { "Do not use", "no spice" },
        { "Don't use", "no spice" },
        { "Not use", "no spice" },
        { "None", "no spice" },
        { "No spice", "no spice" },
        { "No seasoning", "no spice" },
        { "Plain", "no spice" },
        { "Nothing", "no spice" }
    };

    /// <summary>
    /// Periodic tick to clear active state once the minigame or dish selection window is closed.
    /// </summary>
    public static void Update()
    {
        // If an old overlay was spawned previously, clean it up completely
        if (_hudRoot != null)
        {
            GameObject.Destroy(_hudRoot);
            _hudRoot = null;
        }

        if (!IsBattleActive) return;

        if (Time.unscaledTime - _lastActiveTime > INACTIVE_TIMEOUT_SECONDS)
        {
            IsBattleActive = false;
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
            IsBattleActive = false;
            return;
        }

        if (rb_work == null || rb_work.exam_num == null || rb_work.exam_num.Length < 4)
            return;

        _lastActiveTime = Time.unscaledTime;
        IsBattleActive = true;

        // 1. Resolve Active Judges
        for (int i = 0; i < 4; i++)
        {
            byte examIdx = rb_work.exam_num[i];
            string name = CookOffScoreEngine.GetJudgeName(examIdx);
            ActiveJudgeNames[i] = name;

            byte charaId = examIdx;
            try
            {
                var examTable = GSD2::EventOverlayClass.Overlay_rbattle.exam_table;
                if (examTable != null && examIdx < examTable.Length)
                {
                    charaId = examTable[examIdx];
                }
            }
            catch { }

            ActiveJudgeTastes[i] = CookOffScoreEngine.GetJudgeTaste(charaId, name, examIdx);
        }

        // 2. Resolve Best Dishes for All Courses (filter by currently available recipes in player's menu)
        HashSet<int>? availableRecipes = null;
        if (rb_work.rsp_table != null && rb_work.menu_num > 0)
        {
            availableRecipes = new HashSet<int>();
            for (int i = 0; i < rb_work.menu_num && i < rb_work.rsp_table.Length; i++)
            {
                int r = rb_work.rsp_table[i];
                if (r > 0) availableRecipes.Add(r);
            }
        }

        Func<int, bool> isUnlocked = r => (availableRecipes != null && availableRecipes.Count > 0)
            ? availableRecipes.Contains(r)
            : CookOffScoreEngine.IsRecipeUnlocked(r);

        BestAppetizer = CookOffScoreEngine.FindBestDish(CookOffScoreEngine.Course.Appetizer, ActiveJudgeTastes, isUnlocked);
        BestMain = CookOffScoreEngine.FindBestDish(CookOffScoreEngine.Course.Main, ActiveJudgeTastes, isUnlocked);
        BestDessert = CookOffScoreEngine.FindBestDish(CookOffScoreEngine.Course.Dessert, ActiveJudgeTastes, isUnlocked);

        // 3. Resolve Current Course & Selected Recipe
        CurrentCourse = rb_work.ychoice;
        int courseIdx = Math.Clamp((int)CurrentCourse, 0, 2);
        CookOffScoreEngine.Course activeCourse = (CookOffScoreEngine.Course)courseIdx;

        int spiceIdx = Math.Clamp((int)rb_work.pchoice, 0, CookOffScoreEngine.SpiceNames.Length - 1);
        string currentSpice = CookOffScoreEngine.SpiceNames[spiceIdx];

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

        if (currentRecipeNum > 0)
        {
            _lastSelectedRecipeNum = currentRecipeNum;
        }

        int selectedRecipeNum = _lastSelectedRecipeNum;
        try
        {
            if (rb_work.rsp_no != null && courseIdx < rb_work.rsp_no.Length && rb_work.rsp_no[courseIdx] > 0)
            {
                selectedRecipeNum = rb_work.rsp_no[courseIdx];
            }
            else if (currentRecipeNum > 0)
            {
                selectedRecipeNum = currentRecipeNum;
            }
        }
        catch { }

        // Update telemetry for highlighted dish
        HighlightedDish = CookOffScoreEngine.FindDish(selectedRecipeNum, activeCourse, currentSpice);
        if (HighlightedDish != null)
        {
            HighlightedScore = CookOffScoreEngine.CalculateDishScore(HighlightedDish, ActiveJudgeTastes, HighlightedJudgeScores);
        }
        else
        {
            HighlightedScore = 0;
            Array.Clear(HighlightedJudgeScores, 0, 4);
        }

        // 4. Inject colors & scores directly into native game menu TextMeshProUGUI elements
        if (rb_work.win != null)
        {
            for (int wIdx = 0; wIdx < rb_work.win.Length; wIdx++)
            {
                var win = rb_work.win[wIdx];
                if (win == null) continue;

                ProcessWindow(win, activeCourse, selectedRecipeNum);
            }
        }
    }

    /// <summary>
    /// Processes a single game window, modifying row texts only.
    /// Never touches dialogue prompts, headers, or title text.
    /// </summary>
    private static void ProcessWindow(
        GSD2::WIN w,
        CookOffScoreEngine.Course activeCourse,
        int selectedRecipeNum)
    {
        // 1. Process w.index (List of TextMeshProUGUI for rows)
        if (w.index != null && w.index.Count > 0)
        {
            for (int i = 0; i < w.index.Count; i++)
            {
                var tmp = w.index[i];
                if (tmp != null)
                {
                    ProcessRowComponent(tmp, activeCourse, selectedRecipeNum);
                }
            }
        }

        // 2. Process w.win_row_text_index (WindowRowText array)
        if (w.win_row_text_index != null && w.win_row_text_index.Length > 0)
        {
            for (int i = 0; i < w.win_row_text_index.Length; i++)
            {
                var wrt = w.win_row_text_index[i];
                if (wrt != null && wrt.TextObject != null)
                {
                    ProcessRowComponent(wrt.TextObject, activeCourse, selectedRecipeNum, wrt.master_text);
                }
            }
        }

        // 3. Check all active TextMeshProUGUIs in the window's GameObject hierarchy
        if (w.ui != null && w.ui.gameObject != null && w.ui.gameObject.activeInHierarchy)
        {
            var allTMPs = w.ui.GetComponentsInChildren<TextMeshProUGUI>(false);
            if (allTMPs != null)
            {
                for (int i = 0; i < allTMPs.Length; i++)
                {
                    var tmp = allTMPs[i];
                    if (tmp != null)
                    {
                        ProcessRowComponent(tmp, activeCourse, selectedRecipeNum);
                    }
                }
            }
        }
    }

    /// <summary>
    /// Checks and modifies a single TextMeshProUGUI component if it matches a Course, Recipe, or Seasoning row.
    /// Title headers and dialogue prompts are completely ignored.
    /// </summary>
    private static void ProcessRowComponent(
        TextMeshProUGUI tmp,
        CookOffScoreEngine.Course activeCourse,
        int selectedRecipeNum,
        string? masterText = null)
    {
        if (tmp == null) return;
        string currentText = tmp.text;
        if (string.IsNullOrWhiteSpace(currentText)) return;

        // Determine base clean text
        string clean = !string.IsNullOrWhiteSpace(masterText)
            ? StripScoreTags(masterText!)
            : StripScoreTags(currentText);

        if (string.IsNullOrWhiteSpace(clean)) return;

        // Ignore headers / instructions like "Select recipe", "Please select", etc.
        if (clean.StartsWith("Select ", StringComparison.OrdinalIgnoreCase) ||
            clean.StartsWith("Please ", StringComparison.OrdinalIgnoreCase))
        {
            return;
        }

        // Prevent unwanted word-wrapping across two lines in tight menu rows
        tmp.enableWordWrapping = false;

        // Case A: Course selection menu ("Appetizer", "Main Course", "Dessert")
        if (clean.IndexOf("Appetizer", StringComparison.OrdinalIgnoreCase) >= 0)
        {
            string bestTag = (BestAppetizer != null)
                ? $"  [Best: {BestAppetizer.Dish.RecipeName} ({BestAppetizer.TotalScore})]"
                : "";
            string newText = $"<color={COLOR_APPETIZER}>Appetizer{bestTag}</color>";
            if (tmp.text != newText) tmp.text = newText;
            return;
        }
        if (clean.IndexOf("Main", StringComparison.OrdinalIgnoreCase) >= 0)
        {
            string bestTag = (BestMain != null)
                ? $"  [Best: {BestMain.Dish.RecipeName} ({BestMain.TotalScore})]"
                : "";
            string newText = $"<color={COLOR_MAIN}>Main Course{bestTag}</color>";
            if (tmp.text != newText) tmp.text = newText;
            return;
        }
        if (clean.IndexOf("Dessert", StringComparison.OrdinalIgnoreCase) >= 0)
        {
            string bestTag = (BestDessert != null)
                ? $"  [Best: {BestDessert.Dish.RecipeName} ({BestDessert.TotalScore})]"
                : "";
            string newText = $"<color={COLOR_DESSERT}>Dessert{bestTag}</color>";
            if (tmp.text != newText) tmp.text = newText;
            return;
        }

        // Case B: Recipe selection row
        if (CookOffScoreEngine.RecipeNumbers.TryGetValue(clean, out int recipeNum))
        {
            int bestScore = -1;
            string bestSpice = "no spice";
            CookOffScoreEngine.Course dishCourse = activeCourse;
            int[] tempScores = new int[4];

            // 1. First priority: look for dishes matching the ACTIVE course being chosen
            bool hasActiveCourseDish = false;
            foreach (var dish in CookOffScoreEngine.AllDishes)
            {
                if (dish.RecipeNumber != recipeNum || dish.Course != activeCourse) continue;

                hasActiveCourseDish = true;
                int s = CookOffScoreEngine.CalculateDishScore(dish, ActiveJudgeTastes, tempScores);
                if (s > bestScore)
                {
                    bestScore = s;
                    bestSpice = dish.Spice;
                    dishCourse = dish.Course;
                }
            }

            // 2. If this recipe has NO dishes for the active course, fall back to other courses
            if (!hasActiveCourseDish)
            {
                foreach (var dish in CookOffScoreEngine.AllDishes)
                {
                    if (dish.RecipeNumber != recipeNum) continue;

                    int s = CookOffScoreEngine.CalculateDishScore(dish, ActiveJudgeTastes, tempScores);
                    if (s > bestScore)
                    {
                        bestScore = s;
                        bestSpice = dish.Spice;
                        dishCourse = dish.Course;
                    }
                }
            }

            if (bestScore >= 0)
            {
                string spiceAbbr = bestSpice switch
                {
                    "Sugar" => "Sugar",
                    "Salt" => "Salt",
                    "Soy Sauce" => "Soy",
                    "Mayonnaise" => "Mayo",
                    "Red Pepper" => "Pepper",
                    _ => "Plain"
                };

                // Color code by active course (or the fallback course if off-course)
                string courseColor = GetCourseColor(dishCourse);
                string newText = $"{clean}  <color={courseColor}>[{bestScore}:{spiceAbbr}]</color>";
                if (tmp.text != newText)
                {
                    tmp.text = newText;
                }
            }
            return;
        }

        // Leave ingredient/seasoning window completely untouched (clean vanilla)
        if (ResolveSpiceAlias(clean) != null)
        {
            if (tmp.text != clean)
            {
                tmp.text = clean;
            }
            return;
        }
    }

    /// <summary>
    /// Matches seasoning names including partial/case-insensitive variants.
    /// </summary>
    private static string? ResolveSpiceAlias(string text)
    {
        if (SpiceAliases.TryGetValue(text, out string? exact))
            return exact;

        if (text.IndexOf("sugar", StringComparison.OrdinalIgnoreCase) >= 0) return "Sugar";
        if (text.IndexOf("salt", StringComparison.OrdinalIgnoreCase) >= 0) return "Salt";
        if (text.IndexOf("soy", StringComparison.OrdinalIgnoreCase) >= 0) return "Soy Sauce";
        if (text.IndexOf("mayo", StringComparison.OrdinalIgnoreCase) >= 0) return "Mayonnaise";
        if (text.IndexOf("pepper", StringComparison.OrdinalIgnoreCase) >= 0) return "Red Pepper";
        if (text.IndexOf("not use", StringComparison.OrdinalIgnoreCase) >= 0 ||
            text.IndexOf("none", StringComparison.OrdinalIgnoreCase) >= 0) return "no spice";

        return null;
    }

    /// <summary>
    /// Strips any previously appended score tags or rich text XML formatting to retrieve the raw string.
    /// </summary>
    private static string StripScoreTags(string text)
    {
        if (string.IsNullOrEmpty(text)) return text;

        // 1. Remove all XML / TMP tags like <color=...> and </color>
        while (true)
        {
            int open = text.IndexOf('<');
            if (open < 0) break;
            int close = text.IndexOf('>', open);
            if (close < 0) break;
            text = text.Remove(open, close - open + 1);
        }

        // 2. Remove bracketed score tags like [15:Mayo] or [Best: Salad (15)]
        int bracket = text.IndexOf('[');
        if (bracket >= 0)
        {
            text = text.Substring(0, bracket);
        }

        // 3. Remove newline if any
        int nl = text.IndexOf('\n');
        if (nl >= 0)
        {
            text = text.Substring(0, nl);
        }

        return text.Trim();
    }
}
