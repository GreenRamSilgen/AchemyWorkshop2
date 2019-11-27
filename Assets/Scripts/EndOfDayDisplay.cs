using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EndOfDayDisplay : MonoBehaviour
{
    //MATERIALS
    private MaterialList MaterialList = new MaterialList(); //Create ItemList object
    GameObject materialsGetter; //create gameobject

    //EOD
    public Ledger ledger;
    public UMaterials uMaterials;
    public PotionsCreated potions;

    private int hireCost = 0;
    private int total = 0;
    private int startGold = 0;
    // Use this for initialization
    void Start()
    {
        //MATERIAL 
        materialsGetter = GameObject.FindGameObjectWithTag("Resourcer"); //Assign ResourceLoader gameobject to "resourceGetter"
        MaterialList = materialsGetter.GetComponent<MaterialLoader>().getMaterialList(); //Call getResourceList from ResourceLoader Script in ResourceHolder


        //BLANK template
        ledger.cost.text = "";
        uMaterials.matUsed.text = "";
        potions.potText.text = "";

        //Ledger calc
        hireCost = calcHireCost();
        total = Global.moneyMade - 50 - hireCost;
        if(total > 0 )
        {
            startGold = Global.gold + total + 50;
        }
        else if(total < 0)
        {
            startGold = Global.gold - total - 50;
        }
        //SET Text
        updateLedger(hireCost, total);
        matUsed();
        updatePotions();
    }

    // Update is called once per frame
    void Update()
    {
    }

    int calcHireCost() // calculate the hiring costs based on that day
    {
        IDictionaryEnumerator myEnum = Global.gatherers.GetEnumerator();
        int count = 0;
        while(myEnum.MoveNext())
        {
            count += Global.gathererCost[myEnum.Key.ToString()] * System.Convert.ToInt32(myEnum.Value.ToString());
        }

        return count;
    }

    void updateLedger(int hireCost, int total)
    {
        ledger.cost.text = "Start Gold:" + startGold + "\nHiring Cost \n-" + hireCost + "\n" + "Rent\n-50 \n" + "Potions Profit\n+" + Global.moneyMade + "\nNet Gain: " + total + "\nTotal Gold: " + Global.gold;
    }

    void matUsed()
    {
        for (int i = 0; i < Global.materialsUsed.Count; i++)
        {
            uMaterials.matUsed.text += MaterialList.Materials[Global.materialsUsed[i]].materialName + "\n";
        }
    }

    void updatePotions()
    {
        for (int i = 0; i < Global.recipeHistory.Count; i++)
        {
            RecipeInfo rec = Global.recipeHistory[i];
            // uMaterials.matUsed.text += MaterialList.Materials[Global.materialsUsed[i]].materialName + "\n";
            potions.potText.text += rec.recipeName + "\n";//RecipeList.Recipes[].recipeName;
        }
    }
}
