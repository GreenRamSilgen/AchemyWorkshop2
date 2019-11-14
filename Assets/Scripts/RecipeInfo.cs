using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class RecipeInfo
{
    public int recipeID;
    public int resultID;
    public string recipeName;
    public int recipeValue;
    public List<int> materialIDs = new List<int>();
    public RecipeInfo(int recipeID, int resultID, string recipeName, int recipeValue, List<int> materialIDs)
    {
        this.recipeID = recipeID;
        this.resultID = resultID;
        this.recipeName = recipeName;
        this.recipeValue = recipeValue;
        this.materialIDs = materialIDs;
        
    }
}
