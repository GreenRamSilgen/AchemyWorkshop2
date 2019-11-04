using System.Collections;
using System.Collections.Generic;

public static class PlayerData
{
    public static int day = 0;
    public static int gold = 0;
    public static Dictionary<int, int> inventory = new Dictionary<int, int>();
    public static List<Recipe> recipes = new List<Recipe>();
}
