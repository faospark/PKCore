#nullable enable
extern alias GSD2;

using System;
using System.Collections.Generic;

namespace PKCore.Patches;

/// <summary>
/// Core scoring and recommendation engine for Suikoden 2's Cook-Off Side Quest (Chef Hai Yo).
/// Models taste preferences, course categories, dish variations, and judge point scoring matrices.
/// </summary>
public static class CookOffScoreEngine
{
    public enum Taste
    {
        Plain = 0,
        Sweet = 1,
        Spicy = 2,
        Meat = 3,
        Fish = 4,
        Vegetables = 5,
        Japanese = 6,
        Western = 7,
        Chinese = 8,
        Everything = 9,
        Nothing = 10,
        Strange = 11
    }

    public static readonly string[] TasteNames = {
        "Plain", "Sweet", "Spicy", "Meat", "Fish", "Vegetables",
        "Japanese", "Western", "Chinese", "Everything", "Nothing", "Strange"
    };

    public enum Course
    {
        Appetizer = 0,
        Main = 1,
        Dessert = 2
    }

    public static readonly string[] CourseNames = { "Appetizer", "Main Course", "Dessert" };

    public static readonly string[] SpiceNames = {
        "no spice", "Sugar", "Salt", "Soy Sauce", "Mayonnaise", "Red Pepper"
    };

    public class Dish
    {
        public string Name { get; set; } = "";
        public Course Course { get; set; }
        public string RecipeName { get; set; } = "";
        public int RecipeNumber { get; set; } // 1..40
        public string Spice { get; set; } = "no spice";
        public byte[] Scores { get; set; } = Array.Empty<byte>(); // 12 elements
    }

    public class DishRecommendation
    {
        public Dish Dish = new();
        public int TotalScore;
        public int[] IndividualScores = new int[4];
    }

    public static readonly Dictionary<string, int> RecipeNumbers = new(StringComparer.OrdinalIgnoreCase)
    {
        { "Rolled Omelet", 1 },
        { "Tomato Soup", 2 },
        { "Ohitashi", 3 },
        { "Salad", 4 },
        { "Gyoza", 5 },
        { "Chowder", 6 },
        { "BBQ Meat Bun", 7 },
        { "Buttered Clams", 8 },
        { "Fish Fry", 9 },
        { "Ice Cream", 10 },
        { "Quiche", 11 },
        { "Sandwich", 12 },
        { "Meat Pie", 13 },
        { "Simmered Fish", 14 },
        { "Fritters", 15 },
        { "Sunomono", 16 },
        { "Cake", 17 },
        { "Croquettes", 18 },
        { "Pasta", 19 },
        { "Tempura", 20 },
        { "Grilled Fish", 21 },
        { "Gratin", 22 },
        { "Rice Omelet", 23 },
        { "Fried Rice", 24 },
        { "Pizza", 25 },
        { "Teriyaki", 26 },
        { "Fried Pork Cutlets", 27 },
        { "Curry", 28 },
        { "Grilled Beef", 29 },
        { "Ramen", 30 },
        { "Hamburger", 31 },
        { "Obento", 32 },
        { "Sushi", 33 },
        { "Japanese Stew", 34 },
        { "Full Course", 35 },
        { "Jingisukan", 36 },
        { "Steak", 37 },
        { "Sashimi Platter", 38 },
        { "Special Stew", 39 },
        { "Chinese Banquet", 40 }
    };

    public static readonly Dictionary<int, string> RecipeNamesByNumber = new()
    {
        { 1, "Rolled Omelet" },
        { 2, "Tomato Soup" },
        { 3, "Ohitashi" },
        { 4, "Salad" },
        { 5, "Gyoza" },
        { 6, "Chowder" },
        { 7, "BBQ Meat Bun" },
        { 8, "Buttered Clams" },
        { 9, "Fish Fry" },
        { 10, "Ice Cream" },
        { 11, "Quiche" },
        { 12, "Sandwich" },
        { 13, "Meat Pie" },
        { 14, "Simmered Fish" },
        { 15, "Fritters" },
        { 16, "Sunomono" },
        { 17, "Cake" },
        { 18, "Croquettes" },
        { 19, "Pasta" },
        { 20, "Tempura" },
        { 21, "Grilled Fish" },
        { 22, "Gratin" },
        { 23, "Rice Omelet" },
        { 24, "Fried Rice" },
        { 25, "Pizza" },
        { 26, "Teriyaki" },
        { 27, "Fried Pork Cutlets" },
        { 28, "Curry" },
        { 29, "Grilled Beef" },
        { 30, "Ramen" },
        { 31, "Hamburger" },
        { 32, "Obento" },
        { 33, "Sushi" },
        { 34, "Japanese Stew" },
        { 35, "Full Course" },
        { 36, "Jingisukan" },
        { 37, "Steak" },
        { 38, "Sashimi Platter" },
        { 39, "Special Stew" },
        { 40, "Chinese Banquet" }
    };

    public static string GetRecipeNameByNumber(int recipeNum)
    {
        if (RecipeNamesByNumber.TryGetValue(recipeNum, out string? name))
            return name;
        return $"Recipe #{recipeNum}";
    }

    public static readonly Dictionary<string, int> CharacterTastes = new(StringComparer.OrdinalIgnoreCase)
    {
        // Plain/Normal (0)
        { "Barbara", 0 }, { "Flik", 0 }, { "Futch", 0 }, { "Hanna", 0 }, { "Hilda", 0 },
        { "Hix", 0 }, { "Hoi", 0 }, { "Jude", 0 }, { "Kahn", 0 }, { "Marley", 0 },
        { "Lebrante", 0 }, { "Raura", 0 },
        // Sweet (1)
        { "Boris", 1 }, { "Emilia", 1 }, { "Fitcher", 1 }, { "Georg", 1 }, { "Millie", 1 },
        { "Nina", 1 }, { "Sasuke", 1 }, { "Tomo", 1 },
        // Spicy (2)
        { "Gordon", 2 }, { "Leona", 2 }, { "Meg", 2 }, { "Ridley", 2 }, { "Tenkou", 2 },
        { "Tessai", 2 }, { "Tsai", 2 },
        // Meat (3)
        { "Alex", 3 }, { "Bob", 3 }, { "Connell", 3 }, { "Gijimu", 3 }, { "Kiba", 3 },
        { "Windamier", 3 }, { "Koyu", 3 }, { "Maximillian", 3 }, { "Miklotov", 3 },
        { "Pico", 3 }, { "Shiro", 3 }, { "Yuzu", 3 },
        // Fish (4)
        { "Amada", 4 }, { "Annallee", 4 }, { "Chaco", 4 }, { "Gilbert", 4 }, { "Hans", 4 },
        { "Jess", 4 }, { "Killey", 4 }, { "Kinnison", 4 }, { "Marlowe", 4 }, { "Cody", 4 },
        { "Mondo", 4 }, { "Richmond", 4 }, { "Taki", 4 }, { "Tengaar", 4 },
        // Vegetables (5)
        { "Adlai", 5 }, { "Ayda", 5 }, { "Badeaux", 5 }, { "Sierra", 5 }, { "Simone", 5 },
        { "Verdricci", 5 }, { "Templeton", 5 }, { "Tony", 5 }, { "Wakaba", 5 }, { "Zamza", 5 },
        // Japanese (6)
        { "Eilie", 6 }, { "Gantetsu", 6 }, { "Genshu", 6 }, { "Kasumi", 6 }, { "Shilo", 6 },
        { "Tai Ho", 6 }, { "Tetsu", 6 }, { "Yam Koo", 6 }, { "Yoshino", 6 },
        // Western (7)
        { "Anita", 7 }, { "Apple", 7 }, { "Camus", 7 }, { "Humphrey", 7 }, { "Mintz", 7 },
        { "Jeane", 7 }, { "Karen", 7 }, { "Lorelai", 7 }, { "Shin", 7 }, { "Teresa", 7 },
        { "Valeria", 7 }, { "Vincent", 7 },
        // Chinese (8)
        { "Hauser", 8 }, { "Huan", 8 }, { "Klaus", 8 }, { "Long Chan-Chan", 8 }, { "Lo Wen", 8 },
        { "Oulan", 8 }, { "Rina", 8 }, { "Shu", 8 }, { "Tuta", 8 },
        // Everything (9)
        { "Alberto", 9 }, { "Bolgan", 9 }, { "Freed Y", 9 }, { "Mukumuku", 9 },
        { "Rikimaru", 9 }, { "Stallion", 9 }, { "Viktor", 9 },
        // Nothing (10)
        { "Clive", 10 }, { "Luc", 10 }, { "Mazus", 10 }, { "Pesmerga", 10 }, { "Sheena", 10 },
        // Strange (11)
        { "Gabocha", 11 }, { "Gadget", 11 }, { "Gengen", 11 }, { "Nanami", 11 },
        { "Sid", 11 }, { "Viki", 11 }
    };

    public static readonly List<Dish> AllDishes = new();
    public static readonly List<Dish> Appetizers = new();
    public static readonly List<Dish> Mains = new();
    public static readonly List<Dish> Desserts = new();

    static CookOffScoreEngine()
    {
        InitializeDishes();
    }

    private static void AddApp(string name, string recipe, string spice, params byte[] scores)
    {
        int num = RecipeNumbers.TryGetValue(recipe, out int n) ? n : 0;
        var d = new Dish { Name = name, Course = Course.Appetizer, RecipeName = recipe, RecipeNumber = num, Spice = spice, Scores = scores };
        AllDishes.Add(d);
        Appetizers.Add(d);
    }

    private static void AddMain(string name, string recipe, string spice, params byte[] scores)
    {
        int num = RecipeNumbers.TryGetValue(recipe, out int n) ? n : 0;
        var d = new Dish { Name = name, Course = Course.Main, RecipeName = recipe, RecipeNumber = num, Spice = spice, Scores = scores };
        AllDishes.Add(d);
        Mains.Add(d);
    }

    private static void AddDess(string name, string recipe, string spice, params byte[] scores)
    {
        int num = RecipeNumbers.TryGetValue(recipe, out int n) ? n : 0;
        var d = new Dish { Name = name, Course = Course.Dessert, RecipeName = recipe, RecipeNumber = num, Spice = spice, Scores = scores };
        AllDishes.Add(d);
        Desserts.Add(d);
    }

    private static void InitializeDishes()
    {
        // ── Appetizers (16) ──────────────────────────────────────────────────────────
        AddApp("Fried Egg", "Rolled Omelet", "Soy Sauce", 2,2,3,2,2,2,4,2,2,5,1,4);
        AddApp("Tomato Soup", "Tomato Soup", "no spice", 2,2,1,1,2,3,2,3,2,5,1,1);
        AddApp("Tomato Juice", "Tomato Soup", "Sugar", 1,1,2,1,1,4,1,2,1,4,1,3);
        AddApp("Tomato Miso Soup", "Tomato Soup", "Soy Sauce", 1,1,2,1,1,3,1,1,1,5,1,2);
        AddApp("Tomato Salad", "Tomato Soup", "Mayonnaise", 3,3,3,2,3,4,3,3,2,5,1,1);
        AddApp("Ohitashi", "Ohitashi", "no spice", 1,1,3,1,1,3,3,1,1,5,1,4);
        AddApp("Spinach Juice", "Ohitashi", "Salt", 1,1,1,1,1,2,1,1,1,3,1,5);
        AddApp("Spinach Salad", "Ohitashi", "Mayonnaise", 2,3,2,1,2,4,2,2,2,4,1,3);
        AddApp("Salad", "Salad", "no spice", 2,2,2,1,2,4,2,3,2,5,1,4);
        AddApp("Sweet Salad", "Salad", "Sugar", 1,4,1,1,1,3,1,2,1,4,1,3);
        AddApp("Pickled Cabbage", "Salad", "Salt", 2,2,3,1,2,2,4,1,1,5,2,4);
        AddApp("Island Nation Salad", "Salad", "Soy Sauce", 3,3,2,2,3,4,3,3,3,5,1,2);
        AddApp("Green Salad", "Salad", "Mayonnaise", 2,2,2,1,2,5,2,2,2,4,1,3);
        AddApp("Meat Salad", "Grilled Beef", "Mayonnaise", 3,3,3,4,2,2,3,3,2,5,1,5);
        AddApp("Salad Combo", "Sashimi Platter", "Mayonnaise", 4,5,3,2,4,5,3,3,2,5,1,3);
        AddApp("Special Salad", "Chinese Banquet", "Mayonnaise", 3,4,2,2,3,5,3,4,3,5,1,3);

        // ── Main Courses (66) ────────────────────────────────────────────────────────
        AddMain("Rolled Omelet", "Rolled Omelet", "no spice", 2,2,2,2,2,2,2,2,3,5,2,3);
        AddMain("Large Fried Egg", "Rolled Omelet", "Salt", 3,2,4,3,3,3,3,2,2,5,1,1);
        AddMain("Egg Mayo Roll", "Rolled Omelet", "Mayonnaise", 2,1,2,3,2,1,2,2,3,5,1,5);
        AddMain("Eggsplosive", "Rolled Omelet", "Red Pepper", 1,1,3,1,1,1,1,1,2,4,1,2);
        AddMain("Red Hot Tomatoes", "Tomato Soup", "Red Pepper", 4,3,4,2,4,5,4,3,2,5,1,3);
        AddMain("Spinach Saute", "Ohitashi", "Soy Sauce", 2,2,3,1,2,3,2,3,2,5,1,5);
        AddMain("Spicy Stir Fry", "Ohitashi", "Red Pepper", 3,2,4,2,3,3,3,2,4,5,1,2);
        AddMain("Veggie Stir Fry", "Salad", "Red Pepper", 2,2,3,1,2,4,2,2,3,5,1,5);
        AddMain("Gyoza", "Gyoza", "no spice", 2,1,4,3,2,2,1,1,4,4,1,2);
        AddMain("Steamed Gyoza", "Gyoza", "Salt", 3,2,3,3,3,3,2,2,5,5,1,1);
        AddMain("Fried Gyoza", "Gyoza", "Soy Sauce", 2,1,4,3,2,2,1,1,4,5,1,4);
        AddMain("Deep-Fried Gyoza", "Gyoza", "Mayonnaise", 2,1,4,3,2,1,1,1,4,4,1,1);
        AddMain("Szechuan Gyoza", "Gyoza", "Red Pepper", 4,1,5,3,3,2,2,2,5,5,1,1);
        AddMain("Chowder", "Chowder", "no spice", 2,2,2,1,2,3,2,3,2,5,1,5);
        AddMain("Vichyssoise", "Chowder", "Salt", 2,2,2,1,2,3,2,3,2,4,1,4);
        AddMain("Dark Chowder", "Chowder", "Soy Sauce", 1,1,2,1,1,1,1,2,1,5,1,3);
        AddMain("Egg Soup", "Chowder", "Mayonnaise", 2,2,2,1,2,2,2,3,2,4,1,4);
        AddMain("Gumbo", "Chowder", "Red Pepper", 1,1,4,1,1,1,1,2,1,5,1,3);
        AddMain("BBQ Meat Bun", "BBQ Meat Bun", "no spice", 2,2,2,4,2,2,2,2,3,5,1,4);
        AddMain("Sweet Bean Bun", "BBQ Meat Bun", "Sugar", 2,4,1,1,2,2,4,2,2,5,1,3);
        AddMain("Ginger Beef Bun", "BBQ Meat Bun", "Salt", 2,1,3,3,2,2,2,1,3,5,1,2);
        AddMain("Ma Bo Bun", "BBQ Meat Bun", "Soy Sauce", 1,1,4,3,2,1,1,1,4,5,1,5);
        AddMain("Pirate's Bun", "BBQ Meat Bun", "Mayonnaise", 3,3,2,1,4,2,1,2,3,4,1,3);
        AddMain("Pizza Bun", "BBQ Meat Bun", "Red Pepper", 2,2,3,2,2,2,1,3,2,4,1,1);
        AddMain("Buttered Clams", "Buttered Clams", "no spice", 3,3,2,2,3,3,2,3,3,5,1,4);
        AddMain("Clam Pudding", "Buttered Clams", "Sugar", 2,3,2,1,3,2,1,4,2,4,1,5);
        AddMain("Grilled Scallops", "Buttered Clams", "Salt", 2,2,2,1,3,2,3,2,2,5,1,1);
        AddMain("Steamed Abalone", "Buttered Clams", "Soy Sauce", 4,2,5,2,4,3,5,2,3,4,1,1);
        AddMain("Clam Mayonnaise", "Buttered Clams", "Mayonnaise", 2,1,2,1,2,2,1,3,2,5,1,4);
        AddMain("Mai Mai???", "Buttered Clams", "Red Pepper", 1,1,1,1,2,1,1,3,1,4,1,5);
        AddMain("Fish Fry", "Fish Fry", "no spice", 3,3,3,2,4,3,3,3,3,5,1,2);
        AddMain("Deep-Fried Fish", "Fish Fry", "Salt", 3,3,3,1,4,3,3,3,3,5,1,1);
        AddMain("Tatsuta Deep Fry", "Fish Fry", "Soy Sauce", 3,3,3,2,4,3,3,3,3,5,1,3);
        AddMain("French Fries", "Fish Fry", "Mayonnaise", 2,2,3,1,3,2,2,3,2,5,1,2);
        AddMain("Fried Tacos", "Fish Fry", "Red Pepper", 2,1,3,1,3,2,2,3,2,5,1,5);
        AddMain("Quiche", "Quiche", "no spice", 3,3,3,3,3,3,3,4,3,4,1,3);
        AddMain("Pineapple Rice", "Quiche", "Sugar", 1,3,1,1,1,2,1,2,1,5,1,1);
        AddMain("Egg Porridge", "Quiche", "Salt", 3,3,3,2,3,3,4,3,3,5,1,5);
        AddMain("Baked Mochi", "Quiche", "Soy Sauce", 2,2,2,2,2,2,2,2,2,5,1,5);
        AddMain("Cream Quiche", "Quiche", "Mayonnaise", 2,1,2,3,2,1,2,3,2,5,1,2);
        AddMain("Lasagna", "Quiche", "Red Pepper", 3,3,3,3,3,3,2,4,2,5,1,4);
        AddMain("Sandwich", "Sandwich", "no spice", 2,2,2,2,2,3,2,3,2,4,1,1);
        AddMain("French Toast", "Sandwich", "Sugar", 3,2,3,3,3,3,3,4,3,5,1,2);
        AddMain("Steak Sandwich", "Sandwich", "Salt", 1,1,1,4,1,1,1,2,1,5,1,4);
        AddMain("Teri-Sand", "Sandwich", "Soy Sauce", 2,2,2,4,1,2,3,2,2,5,1,1);
        AddMain("Veggie Sandwich", "Sandwich", "Mayonnaise", 2,3,1,1,2,4,2,3,2,5,1,3);
        AddMain("Spicy Sandwich", "Sandwich", "Red Pepper", 3,3,3,3,3,3,3,3,3,5,1,4);
        AddMain("Meat Pie", "Meat Pie", "no spice", 2,2,2,4,2,2,2,4,2,5,1,1);
        AddMain("Meringue Pie", "Meat Pie", "Salt", 1,1,1,2,1,1,1,1,1,3,1,4);
        AddMain("Kobold Pie", "Meat Pie", "Soy Sauce", 2,2,1,2,2,1,2,2,1,4,1,5);
        AddMain("Mayonnaise Pie", "Meat Pie", "Mayonnaise", 1,1,1,3,1,1,1,1,1,5,1,3);
        AddMain("Chili Pie", "Meat Pie", "Red Pepper", 3,1,4,3,3,2,3,2,3,5,1,1);
        AddMain("Simmered Fish", "Simmered Fish", "no spice", 2,2,2,1,4,2,4,1,3,5,1,3);
        AddMain("Simmered Carp", "Simmered Fish", "Sugar", 3,3,3,2,5,3,5,2,4,5,1,1);
        AddMain("Sea Bream Hot Pot", "Simmered Fish", "Salt", 2,1,4,1,4,2,2,1,3,5,1,4);
        AddMain("Sole", "Simmered Fish", "Soy Sauce", 3,3,3,2,5,3,5,2,2,5,1,2);
        AddMain("Fish with Tarter Sauce", "Simmered Fish", "Mayonnaise", 2,2,2,1,4,2,2,3,2,5,1,3);
        AddMain("Blackened Sole", "Simmered Fish", "Red Pepper", 3,1,4,2,4,3,3,3,3,5,1,5);
        AddMain("Fritters", "Fritters", "no spice", 2,2,2,5,1,2,3,2,4,5,1,2);
        AddMain("Sweet & Sour Broth", "Fritters", "Sugar", 3,3,2,5,2,2,4,3,3,5,1,4);
        AddMain("Salty Fritters", "Fritters", "Salt", 3,3,3,5,2,3,3,3,4,5,2,3);
        AddMain("Steamed Bun", "Fritters", "Soy Sauce", 2,2,2,5,1,2,3,2,3,5,1,1);
        AddMain("Greasy Fritters", "Fritters", "Mayonnaise", 2,2,2,5,1,1,1,2,2,5,1,4);
        AddMain("Firey Fritters", "Fritters", "Red Pepper", 3,2,4,5,2,2,2,2,2,4,1,2);
        AddMain("Sunomono", "Sunomono", "no spice", 1,1,2,1,2,2,4,1,2,5,2,3);
        AddMain("Shrimp Sunomono", "Sunomono", "Sugar", 2,2,3,1,3,3,5,1,2,5,1,5);
        AddMain("Tippler's Sunomono", "Sunomono", "Salt", 2,2,4,1,4,3,5,1,1,5,1,3);
        AddMain("Gourmet Sunomono", "Sunomono", "Soy Sauce", 3,3,4,1,3,4,5,1,2,5,1,4);
        AddMain("Weird Sunomono", "Sunomono", "Mayonnaise", 1,1,3,1,2,3,4,1,1,5,1,2);
        AddMain("Cajun Shrimp", "Sunomono", "Red Pepper", 2,1,5,1,2,2,3,1,2,5,1,3);
        AddMain("Nanami Cake", "Cake", "Salt", 1,2,1,1,1,1,1,1,1,1,1,5);
        AddMain("Black Cake", "Cake", "Soy Sauce", 1,1,1,1,1,1,1,1,1,3,1,3);
        AddMain("Croquettes", "Croquettes", "no spice", 2,3,2,3,2,2,2,3,2,5,1,2);
        AddMain("Sweet Croquettes", "Croquettes", "Sugar", 2,4,1,1,2,2,2,3,2,5,1,3);
        AddMain("Eilie Croquettes", "Croquettes", "Salt", 4,4,3,4,4,5,3,5,2,5,3,1);
        AddMain("Black Croquettes", "Croquettes", "Soy Sauce", 1,1,2,1,1,1,1,2,1,4,1,4);
        AddMain("Cream Croquettes", "Croquettes", "Mayonnaise", 3,4,3,3,3,3,3,4,3,5,1,3);
        AddMain("Hot Croquettes", "Croquettes", "Red Pepper", 1,1,2,2,1,2,1,1,1,4,1,3);
        AddMain("Pasta", "Pasta", "no spice", 2,2,2,2,3,3,2,3,2,5,1,4);
        AddMain("Kiddie Pasta", "Pasta", "Sugar", 2,4,1,1,2,2,1,3,2,5,1,2);
        AddMain("Pasta Parmesan", "Pasta", "Salt", 4,3,4,3,5,3,4,4,3,5,1,3);
        AddMain("Downtown Pasta", "Pasta", "Soy Sauce", 3,3,3,3,4,4,4,4,3,5,1,4);
        AddMain("Pasta Salad", "Pasta", "Mayonnaise", 2,1,2,4,1,1,2,3,2,5,1,5);
        AddMain("Chili Pasta", "Pasta", "Red Pepper", 2,1,3,3,2,2,2,4,2,5,1,1);
        AddMain("Tempura", "Tempura", "no spice", 2,2,2,3,3,2,3,2,3,5,1,3);
        AddMain("Snack Tempura", "Tempura", "Sugar", 1,3,1,1,2,2,2,1,1,4,1,4);
        AddMain("Real Tempura", "Tempura", "Salt", 4,3,4,4,4,3,5,3,3,5,1,2);
        AddMain("Tempura-Don", "Tempura", "Soy Sauce", 3,2,3,3,4,2,4,3,3,5,1,1);
        AddMain("Amazing Tempura", "Tempura", "Mayonnaise", 2,1,3,2,2,1,3,2,2,5,1,4);
        AddMain("Spicy Tempura", "Tempura", "Red Pepper", 2,2,3,2,3,2,3,2,2,5,1,3);
        AddMain("Grilled Fish", "Grilled Fish", "no spice", 2,2,3,1,5,2,4,2,3,5,1,5);
        AddMain("Broiled Eel", "Grilled Fish", "Sugar", 2,3,2,1,5,2,4,1,2,5,1,2);
        AddMain("Salted Fish", "Grilled Fish", "Salt", 1,1,4,1,3,1,5,1,1,3,1,2);
        AddMain("Dried Fish", "Grilled Fish", "Soy Sauce", 3,3,3,2,5,3,4,2,2,5,1,3);
        AddMain("Salmon Meuniere", "Grilled Fish", "Mayonnaise", 2,2,2,2,4,3,2,4,3,5,1,4);
        AddMain("Grilled Red Fish", "Grilled Fish", "Red Pepper", 2,1,3,1,4,1,2,3,3,5,1,5);
        AddMain("Gratin", "Gratin", "no spice", 2,3,2,2,2,2,2,3,2,5,1,2);
        AddMain("Apple Gratin", "Gratin", "Sugar", 1,3,1,1,1,3,1,2,1,5,1,3);
        AddMain("Salty Gratin", "Gratin", "Salt", 1,1,2,1,1,2,1,3,1,5,1,1);
        AddMain("Crispy Gratin", "Gratin", "Soy Sauce", 3,2,3,3,3,3,3,4,2,5,1,4);
        AddMain("Creamy Gratin", "Gratin", "Mayonnaise", 4,5,3,4,3,3,3,5,3,5,1,3);
        AddMain("Chili Gratin", "Gratin", "Red Pepper", 3,3,3,3,3,3,3,4,3,5,1,5);
        AddMain("Rice Omelet", "Rice Omelet", "no spice", 3,3,3,3,3,3,3,4,3,5,1,2);
        AddMain("Kid's Lunch", "Rice Omelet", "Sugar", 2,3,1,2,2,2,2,5,2,5,1,3);
        AddMain("Salty Rice Omelet", "Rice Omelet", "Salt", 1,1,2,1,1,1,4,2,1,5,2,3);
        AddMain("Soy Rice Omelet", "Rice Omelet", "Soy Sauce", 1,1,4,1,1,1,4,1,2,5,1,5);
        AddMain("Mayo Rice Omelet", "Rice Omelet", "Mayonnaise", 2,1,2,4,1,1,1,3,3,4,1,2);
        AddMain("Red Pepper Rice", "Rice Omelet", "Red Pepper", 2,1,4,2,2,1,3,1,2,5,1,3);
        AddMain("Fried Rice", "Fried Rice", "no spice", 2,2,2,3,3,2,2,2,4,5,1,4);
        AddMain("Shrimp Pilaf", "Fried Rice", "Sugar", 3,3,2,2,4,3,3,4,3,5,1,3);
        AddMain("Salty Fried Rice", "Fried Rice", "Salt", 1,1,3,1,1,1,4,1,2,5,1,4);
        AddMain("Gunpowder Rice", "Fried Rice", "Soy Sauce", 3,3,3,3,3,4,5,2,3,5,1,2);
        AddMain("Heavy Pilaf", "Fried Rice", "Mayonnaise", 2,2,2,4,2,1,2,3,3,5,1,1);
        AddMain("Spicy Pilaf", "Fried Rice", "Red Pepper", 2,1,3,2,2,2,1,3,3,5,1,3);
        AddMain("Pizza", "Pizza", "no spice", 2,2,3,3,2,2,1,3,2,5,1,2);
        AddMain("Anchovy Pizza", "Pizza", "Salt", 2,1,4,2,3,2,2,3,2,5,1,3);
        AddMain("Okonomiyaki", "Pizza", "Mayonnaise", 3,3,3,4,3,3,4,2,2,5,1,3);
        AddMain("Spicy Pizza", "Pizza", "Red Pepper", 2,2,3,3,2,2,2,3,2,5,1,4);
        AddMain("Teriyaki", "Teriyaki", "no spice", 2,2,2,5,1,1,3,3,2,5,1,3);
        AddMain("Sweet Teriyaki", "Teriyaki", "Sugar", 2,3,1,5,1,1,3,2,3,5,1,5);
        AddMain("Hot Spareribs", "Teriyaki", "Salt", 3,3,3,5,2,1,2,4,3,5,1,3);
        AddMain("Mild Teriyaki", "Teriyaki", "Soy Sauce", 2,2,2,5,1,3,2,2,2,5,1,4);
        AddMain("Teri-Mayo", "Teriyaki", "Mayonnaise", 2,2,1,5,1,1,2,2,2,5,1,2);
        AddMain("BBQ Bomb", "Teriyaki", "Red Pepper", 1,1,3,3,1,2,1,1,1,5,1,1);
        AddMain("Fried Pork Cutlets", "Fried Pork Cutlets", "no spice", 3,3,3,5,2,2,3,4,3,5,1,1);
        AddMain("Meat & Potatoes", "Fried Pork Cutlets", "Sugar", 2,2,2,3,1,4,4,2,2,5,1,4);
        AddMain("Ginger Pork", "Fried Pork Cutlets", "Salt", 3,3,3,5,2,2,4,3,2,5,1,3);
        AddMain("Soy Sauce Cutlets", "Fried Pork Cutlets", "Soy Sauce", 2,2,2,5,1,1,2,3,1,5,1,2);
        AddMain("Cream Cutlets", "Fried Pork Cutlets", "Mayonnaise", 1,1,1,5,1,1,1,2,1,4,1,5);
        AddMain("Spicy Cutlets", "Fried Pork Cutlets", "Red Pepper", 3,1,4,5,2,2,3,3,3,5,1,4);
        AddMain("Curry Rice", "Curry", "no spice", 4,3,5,4,4,3,4,3,3,5,1,1);
        AddMain("Kiddie Curry", "Curry", "Sugar", 3,4,2,2,3,3,3,3,2,4,1,3);
        AddMain("Salty Curry", "Curry", "Salt", 2,1,4,2,2,1,2,2,2,5,1,4);
        AddMain("Japanese Curry", "Curry", "Soy Sauce", 3,4,5,3,3,4,3,3,3,5,1,2);
        AddMain("Mayo Curry", "Curry", "Mayonnaise", 3,2,5,4,2,2,3,3,2,5,1,3);
        AddMain("Red Curry", "Curry", "Red Pepper", 4,1,5,4,3,3,3,3,2,5,1,1);
        AddMain("Grilled Beef", "Grilled Beef", "no spice", 3,3,3,5,2,2,3,3,3,5,1,4);
        AddMain("Sukiyaki", "Grilled Beef", "Sugar", 3,3,3,5,2,1,4,4,2,5,1,2);
        AddMain("Grilled Tongue", "Grilled Beef", "Salt", 4,4,3,5,2,3,3,4,3,5,1,3);
        AddMain("Beef Rice Bowl", "Grilled Beef", "Soy Sauce", 3,3,3,5,1,1,3,1,3,5,1,1);
        AddMain("Chige Nabe", "Grilled Beef", "Red Pepper", 3,2,4,3,2,3,3,2,3,5,1,3);
        AddMain("Ramen", "Ramen", "no spice", 3,3,3,3,3,3,3,2,4,5,1,2);
        AddMain("Chinese Noodles", "Ramen", "Sugar", 2,3,2,2,3,4,2,2,4,5,1,1);
        AddMain("Salty Ramen", "Ramen", "Salt", 3,3,3,3,3,3,3,2,5,5,1,3);
        AddMain("Soy Sauce Ramen", "Ramen", "Soy Sauce", 3,3,3,3,3,3,3,2,4,5,1,1);
        AddMain("Gourmet Ramen", "Ramen", "Mayonnaise", 4,4,3,3,3,3,3,2,5,5,1,2);
        AddMain("Red Hot Ramen", "Ramen", "Red Pepper", 2,1,5,2,3,2,2,1,3,5,1,4);
        AddMain("Hamburger", "Hamburger", "no spice", 3,3,3,5,2,3,3,4,3,5,1,2);
        AddMain("Sugar-Cured Meat", "Hamburger", "Sugar", 1,3,1,4,1,1,1,1,1,4,1,5);
        AddMain("Kobold Burger", "Hamburger", "Salt", 2,3,1,4,1,2,2,2,2,5,1,2);
        AddMain("Japan Burger", "Hamburger", "Soy Sauce", 3,3,2,5,2,4,4,3,3,5,1,1);
        AddMain("Tinto Burger", "Hamburger", "Mayonnaise", 4,3,5,5,3,2,3,4,3,5,1,3);
        AddMain("Surprise Burger", "Hamburger", "Red Pepper", 2,1,3,5,1,2,2,2,2,4,1,4);
        AddMain("Obento", "Obento", "no spice", 2,2,2,2,3,3,2,2,2,5,1,2);
        AddMain("Ladies Lunch", "Obento", "Sugar", 3,4,2,1,3,4,3,3,3,5,1,3);
        AddMain("Rising Sun Bento", "Obento", "Salt", 1,1,1,1,2,3,3,1,1,4,2,4);
        AddMain("Sashimi Bento", "Obento", "Soy Sauce", 3,3,3,2,5,3,4,1,2,5,1,2);
        AddMain("Diet Lunch", "Obento", "Mayonnaise", 2,3,1,1,3,3,2,2,1,3,1,3);
        AddMain("Chili Shrimp Bento", "Obento", "Red Pepper", 3,1,4,3,4,3,2,3,4,5,1,1);
        AddMain("Sushi", "Sushi", "no spice", 4,4,3,3,5,3,5,3,3,5,1,3);
        AddMain("Chirashi Sushi", "Sushi", "Sugar", 3,4,2,2,5,3,4,2,2,5,1,4);
        AddMain("Salty Rice Ball", "Sushi", "Salt", 4,3,4,2,5,2,4,2,3,5,1,4);
        AddMain("Fancy Rice Ball", "Sushi", "Soy Sauce", 5,3,5,3,5,3,5,3,3,5,1,2);
        AddMain("French Roll", "Sushi", "Mayonnaise", 3,3,2,2,4,2,4,2,3,5,1,4);
        AddMain("Tekka-Don", "Sushi", "Red Pepper", 4,3,4,3,5,3,5,2,3,5,1,5);
        AddMain("Japanese Stew", "Japanese Stew", "no spice", 3,3,3,4,4,3,4,3,4,5,1,2);
        AddMain("Bouillabaise", "Japanese Stew", "Salt", 3,3,3,5,3,3,3,3,3,5,1,1);
        AddMain("Shabu Shabu", "Japanese Stew", "Soy Sauce", 5,4,5,5,3,3,4,3,3,5,1,2);
        AddMain("Dark Stew", "Japanese Stew", "Mayonnaise", 2,1,3,4,2,3,3,2,2,5,2,3);
        AddMain("Spicy Stew", "Japanese Stew", "Red Pepper", 4,3,4,5,3,2,4,3,3,5,1,4);
        AddMain("Full Course", "Full Course", "no spice", 4,4,4,4,4,3,3,5,3,5,1,1);
        AddMain("Elf Course", "Full Course", "Sugar", 5,5,4,3,4,5,4,4,3,5,1,2);
        AddMain("Kobold Course", "Full Course", "Salt", 3,3,3,3,4,3,3,2,4,5,1,3);
        AddMain("Rokkaku Course", "Full Course", "Soy Sauce", 4,4,4,3,5,4,5,3,3,5,1,1);
        AddMain("Matilda Course", "Full Course", "Mayonnaise", 4,4,4,5,3,2,3,5,4,5,1,3);
        AddMain("Tinto Specialty", "Full Course", "Red Pepper", 5,3,5,5,4,3,4,4,4,5,1,2);
        AddMain("Jingisukan", "Jingisukan", "no spice", 3,3,3,5,2,3,3,3,3,5,1,3);
        AddMain("Fa Chu Chin", "Jingisukan", "Sugar", 4,4,4,4,3,3,3,3,5,5,1,1);
        AddMain("Kubba", "Jingisukan", "Salt", 3,2,5,3,2,3,3,2,3,5,1,3);
        AddMain("Genghis Stew", "Jingisukan", "Soy Sauce", 3,3,3,5,2,3,3,3,3,5,1,2);
        AddMain("Cream Stew", "Jingisukan", "Mayonnaise", 4,5,3,4,3,4,3,5,3,5,1,2);
        AddMain("Tom Yum Soup", "Jingisukan", "Red Pepper", 5,1,5,3,3,5,4,3,4,5,1,1);
        AddMain("Steak", "Steak", "no spice", 4,4,4,5,2,3,3,4,3,5,1,3);
        AddMain("Sweet Steak", "Steak", "Sugar", 2,3,1,5,1,1,1,2,1,4,1,5);
        AddMain("Beefsteak", "Steak", "Salt", 4,3,4,5,2,3,3,5,3,5,1,2);
        AddMain("Japanese Steak", "Steak", "Soy Sauce", 4,5,2,5,3,4,4,4,3,5,1,3);
        AddMain("Piccata", "Steak", "Mayonnaise", 3,3,3,4,2,2,2,3,3,5,1,1);
        AddMain("Pepper Steak", "Steak", "Red Pepper", 5,3,5,5,2,3,3,5,3,5,1,4);
        AddMain("Sashimi Platter", "Sashimi Platter", "no spice", 5,4,5,3,5,4,5,3,3,5,1,2);
        AddMain("Queen of the Sea", "Sashimi Platter", "Sugar", 4,3,4,2,5,3,4,2,2,5,1,5);
        AddMain("Sea Treasure", "Sashimi Platter", "Salt", 3,2,1,1,4,2,3,1,2,3,1,3);
        AddMain("Ship Combo", "Sashimi Platter", "Soy Sauce", 5,4,5,3,5,4,5,2,3,5,1,2);
        AddMain("Spicy Sashimi", "Sashimi Platter", "Red Pepper", 3,1,5,2,4,3,3,2,3,5,1,1);
        AddMain("Special Stew", "Special Stew", "no spice", 4,4,4,3,4,4,3,5,3,5,1,4);
        AddMain("Large Stew", "Special Stew", "Salt", 4,3,5,3,4,4,4,5,3,5,1,3);
        AddMain("Clear Soup", "Special Stew", "Soy Sauce", 3,3,2,1,4,4,5,2,2,5,1,1);
        AddMain("Mellow Stew", "Special Stew", "Mayonnaise", 5,5,4,3,3,5,3,5,2,5,1,3);
        AddMain("Spicy Stew", "Special Stew", "Red Pepper", 4,2,5,3,2,3,3,3,4,5,1,2);
        AddMain("Chinese Banquet", "Chinese Banquet", "no spice", 5,4,4,4,4,4,3,3,5,5,1,3);
        AddMain("Salt House", "Chinese Banquet", "Salt", 1,1,3,2,2,1,2,1,2,5,1,4);
        AddMain("Japanese Banquet", "Chinese Banquet", "Soy Sauce", 4,4,3,1,5,4,5,3,3,5,1,2);
        AddMain("Flaming Sea", "Chinese Banquet", "Red Pepper", 3,2,5,2,2,1,2,1,2,5,1,3);

        // ── Desserts (22) ────────────────────────────────────────────────────────────
        AddDess("Sweet Omelet", "Rolled Omelet", "Sugar", 2,4,1,2,2,2,2,4,2,5,1,2);
        AddDess("Raw Tomato", "Tomato Soup", "Salt", 3,3,3,2,3,5,4,3,2,5,2,5);
        AddDess("Spinach Cake", "Ohitashi", "Sugar", 1,3,1,1,1,2,1,1,1,5,1,2);
        AddDess("Fruit Gyoza", "Gyoza", "Sugar", 1,4,1,1,1,2,1,1,3,5,1,4);
        AddDess("Potato Pudding", "Chowder", "Sugar", 1,3,1,1,1,2,1,2,1,5,1,5);
        AddDess("Fish Donuts", "Fish Fry", "Sugar", 1,2,1,1,3,1,2,1,1,4,1,4);
        AddDess("Ice Cream", "Ice Cream", "no spice", 2,5,1,2,2,2,2,3,3,5,2,3);
        AddDess("Pudding", "Ice Cream", "Sugar", 3,5,1,3,2,3,3,4,2,5,1,1);
        AddDess("Nanami Ice Cream", "Ice Cream", "Salt", 1,3,2,1,1,1,1,1,1,2,1,5);
        AddDess("Baked Ice Cream", "Ice Cream", "Soy Sauce", 3,4,2,3,3,3,3,3,3,5,1,3);
        AddDess("Fried Ice Cream", "Ice Cream", "Mayonnaise", 2,4,1,2,2,2,2,2,3,5,1,4);
        AddDess("Red Pepper Ice Cream", "Ice Cream", "Red Pepper", 2,1,3,2,2,2,2,2,2,5,1,2);
        AddDess("Cream Pie", "Meat Pie", "Sugar", 3,5,2,2,2,3,3,3,2,5,1,2);
        AddDess("Cake", "Cake", "no spice", 3,5,2,3,3,3,3,4,2,5,1,1);
        AddDess("Shortcake", "Cake", "Sugar", 3,5,1,3,3,3,3,4,2,5,1,3);
        AddDess("Cheesecake", "Cake", "Mayonnaise", 4,5,1,4,3,3,3,5,1,5,1,2);
        AddDess("Fire Cake", "Cake", "Red Pepper", 2,3,2,2,2,2,2,3,3,4,1,3);
        AddDess("Pancakes", "Pizza", "Sugar", 3,4,1,3,3,3,4,4,3,5,1,4);
        AddDess("Senbei", "Pizza", "Soy Sauce", 2,1,4,2,2,2,4,2,3,5,1,1);
        AddDess("Sweet Tofu", "Japanese Stew", "Sugar", 3,5,1,2,3,3,2,2,5,5,1,3);
        AddDess("Sweet Syrup", "Special Stew", "Sugar", 3,4,1,2,3,3,2,3,2,5,1,2);
        AddDess("Candy House", "Chinese Banquet", "Sugar", 4,5,1,3,3,3,3,4,3,5,1,2);
    }

    /// <summary>
    /// Calculates the total score and individual breakdown for a given dish across 4 judges.
    /// </summary>
    public static int CalculateDishScore(Dish dish, int[] judgeTastes, int[]? judgeScoresOut = null)
    {
        if (dish == null || dish.Scores == null || judgeTastes == null) return 0;
        int total = 0;
        for (int i = 0; i < 4 && i < judgeTastes.Length; i++)
        {
            int t = judgeTastes[i];
            if (t < 0 || t >= 12) t = 0;
            int pts = dish.Scores[t];
            if (judgeScoresOut != null && i < judgeScoresOut.Length)
                judgeScoresOut[i] = pts;
            total += pts;
        }
        return total;
    }

    /// <summary>
    /// Finds the highest scoring dish for a course given 4 judge tastes and an unlock filter.
    /// </summary>
    public static DishRecommendation? FindBestDish(Course course, int[] judgeTastes, Func<int, bool>? isRecipeUnlocked = null)
    {
        List<Dish> list = course switch
        {
            Course.Appetizer => Appetizers,
            Course.Main => Mains,
            Course.Dessert => Desserts,
            _ => Mains
        };

        DishRecommendation? best = null;
        int highest = -1;
        int[] tempScores = new int[4];

        foreach (var d in list)
        {
            if (isRecipeUnlocked != null && !isRecipeUnlocked(d.RecipeNumber))
                continue;

            int score = CalculateDishScore(d, judgeTastes, tempScores);
            if (score > highest)
            {
                highest = score;
                best = new DishRecommendation
                {
                    Dish = d,
                    TotalScore = score,
                    IndividualScores = (int[])tempScores.Clone()
                };
            }
        }

        return best;
    }

    /// <summary>
    /// Resolves the taste category index (0..11) for a judge character ID.
    /// Uses canon CharacterTastes first with name fuzzy matching, then native game table if available.
    /// </summary>
    public static int GetJudgeTaste(byte charaId, string? fallbackName = null, byte examIdx = 0)
    {
        // 1. Check fallbackName against canon CharacterTastes dictionary first
        if (!string.IsNullOrEmpty(fallbackName))
        {
            string trimmed = fallbackName.Trim();
            if (CharacterTastes.TryGetValue(trimmed, out int taste))
            {
                return taste;
            }

            // Fuzzy match (handles "Freed·Y" vs "Freed Y", "Long Chan Chan", etc.)
            foreach (var kvp in CharacterTastes)
            {
                if (trimmed.IndexOf(kvp.Key, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    kvp.Key.IndexOf(trimmed, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return kvp.Value;
                }
            }
        }

        // 2. Try native game favorite table by charaId or examIdx
        try
        {
            var favArray = GSD2::EventOverlayClass.rb_dat.favorite;
            if (favArray != null)
            {
                if (charaId < favArray.Length && favArray[charaId] != null)
                    return favArray[charaId].table;
                if (examIdx < favArray.Length && favArray[examIdx] != null)
                    return favArray[examIdx].table;
            }
        }
        catch { }

        return (int)Taste.Plain;
    }

    /// <summary>
    /// Resolves the in-game display name for a judge from their exam index (0..108)
    /// by translating via Overlay_rbattle.exam_table to their true character ID,
    /// and looking up the localized name via G2_SYS.G2_name_get.
    /// </summary>
    public static string GetJudgeName(byte examIdx)
    {
        try
        {
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

            string name = GSD2::G2_SYS.G2_name_get(charaId);
            if (!string.IsNullOrWhiteSpace(name))
                return name.Trim();

            name = GSD2::G2_SYS.G2_name_get(examIdx);
            if (!string.IsNullOrWhiteSpace(name))
                return name.Trim();
        }
        catch { }

        return $"Judge #{examIdx}";
    }

    /// <summary>
    /// Determines whether a recipe (1..40) is currently unlocked in game_data.food_resipi.
    /// </summary>
    public static bool IsRecipeUnlocked(int recipeNumber)
    {
        if (recipeNumber <= 0 || recipeNumber > 40) return false;

        try
        {
            var gw = GSD2::OldSrcBase.game_work;
            var resipi = gw?.game_data?.food_resipi;
            if (resipi != null && resipi.Length > 0)
            {
                int index = recipeNumber - 1;
                int byteIdx = index / 8;
                int bitIdx = index % 8;
                if (byteIdx < resipi.Length)
                {
                    return (resipi[byteIdx] & (1 << bitIdx)) != 0;
                }
            }
        }
        catch { }

        // Default to true if unable to read save data so all dishes are evaluated
        return true;
    }

    /// <summary>
    /// Finds a specific dish by recipe number, course, and spice name.
    /// </summary>
    public static Dish? FindDish(int recipeNumber, Course course, string spice)
    {
        List<Dish> list = course switch
        {
            Course.Appetizer => Appetizers,
            Course.Main => Mains,
            Course.Dessert => Desserts,
            _ => Mains
        };

        foreach (var d in list)
        {
            if (d.RecipeNumber == recipeNumber && string.Equals(d.Spice, spice, StringComparison.OrdinalIgnoreCase))
                return d;
        }

        // Fallback: match by recipe number in category
        foreach (var d in list)
        {
            if (d.RecipeNumber == recipeNumber)
                return d;
        }

        return null;
    }
}
