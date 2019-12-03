using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EndOfDayDisplay : MonoBehaviour
{
    //LOOT DROP CHANCES
    private int[] fail = { 0, 0, 0 };
    private int[] tier1Chance = { 80, 20, 0 };// roll <= 80 tier1MAT, roll > 80 tier2MAT
    private int[] tier2Chance = { 45, 40, 15 };// roll <=45 tier1MAT, roll >45 && roll <= 85 tier2MAT, roll >85 tier3MAT
    private int[] tier3Chance = { 50, 25, 25 };// if roll <= 50 get tier2MAT, roll > 50 && roll <=75 tier1MAT, roll>75 tier3MAT  
    private int[] matGrabChance = { 50, 40, 10 }; // <50 3 item < 40 2 item, <10 5 item.
    //LOOT DROP CHANCES


    //MATERIALS
    private MaterialList MaterialList = new MaterialList(); //Create ItemList object
    GameObject materialsGetter; //create gameobject

    //EOD
    public Ledger ledger;
    public UMaterials uMaterials;
    public PotionsCreated potions;

    private int hireCost = 0;
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
        startGold = Global.startGold;
        hireCost = calcHireCost();
        int netGain = Global.moneyMade - 50 - hireCost;
        Global.gold = startGold + Global.moneyMade - 50 - hireCost;
        //SET Text
        updateLedger(hireCost, netGain);
        matUsed();
        updatePotions();
        materialGain();

        //update Day
        Global.day += 1;
    }

    // Update is called once per frame
    void Update()
    {
    }

    int calcHireCost() // calculate the hiring costs based on that day
    {
        IDictionaryEnumerator myEnum = Global.gatherers.GetEnumerator();
        int count = 0;
        while (myEnum.MoveNext())
        {
            count += Global.gathererCost[myEnum.Key.ToString()] * System.Convert.ToInt32(myEnum.Value.ToString());
        }

        return count;
    }

    void updateLedger(int hireCost, int netGain)
    {
        ledger.cost.text = "Start Gold:" + startGold + "\nHiring Cost \n-" + hireCost + "\n" + "Rent\n-50 \n" + "Potions Profit\n+" + Global.moneyMade + "\nNet Gain: " + netGain + "\nTotal Gold: " + Global.gold;
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

    void materialGain()
    {
        int location = 0;
        IDictionaryEnumerator myEnum = Global.gatherers.GetEnumerator();
        while (myEnum.MoveNext())
        {
            calcMatGain(myEnum.Key.ToString(), location, System.Convert.ToInt32(myEnum.Value.ToString()));
            location++;
        }
    }

    void calcMatGain(string workerType, int location, int workerAmt)
    {
        int matID = -1;
        int grabbedMatTier = 0;
        int grabbedMatAmt = 0;
        string loc = setLocation(location);
        int workerTier = getWorkerTier(workerType);
        int[] chance;

        //Load which loot % to use based on worker tier.
        if (workerTier == 1)
        {
            chance = tier1Chance;
        }
        else if (workerTier == 2)
        {
            chance = tier2Chance;
        }
        else if (workerTier == 3)
        {
            chance = tier3Chance;
        }
        else
        {
            chance = fail;
        }
        //Load which loot % to use based on worker tier.

        //Each worker rolls for matTier they will grab and how many they will grab
        for (int i = 0; i < workerAmt; i++)
        {
            int roll = Roll();
            int matGrabAmtRoll = Roll();

            //How many to grab
            if (matGrabAmtRoll <= matGrabChance[0])
            {
                grabbedMatAmt = 6;
            }
            else if (matGrabAmtRoll - matGrabChance[0] <= matGrabChance[1])
            {
                grabbedMatAmt = 5;
            }
            else
            {
                grabbedMatAmt = 7;
            }
            //How many to grab

            for(int i2 = 0; i2 < grabbedMatAmt; i2++) {
                //What tier item to grab
                if (workerTier == 3)
                {
                    if (roll <= chance[0])
                    {
                        grabbedMatTier = 2;
                    }
                    else if (roll - chance[0] <= chance[1])
                    {
                        grabbedMatTier = 1;
                    }
                    else
                    {
                        grabbedMatTier = 3;
                    }
                }
                else
                {
                    if (roll <= chance[0])
                    {
                        grabbedMatTier = 1;
                    }
                    else if (roll - chance[0] <= chance[1])
                    {
                        grabbedMatTier = 2;
                    }
                    else
                    {
                        grabbedMatTier = 3;
                    }
                }
                //What tier item to grab



                //grabbedMatTier and grabbedMatAmt are set
                //NOW actually "grab" the materials
                if (loc.Equals("City"))
                {
                    if(grabbedMatTier == 1)
                    {
                        matID = Random.Range(0, 4);
                        Global.materials[matID] += 1;
                    }
                    else if(grabbedMatTier ==2)
                    {
                        matID = Random.Range(4, 7);
                        Global.materials[matID] += 1;
                    }
                    else
                    {
                        matID = Random.Range(7, 9);
                        Global.materials[matID] += 1;
                    }
                }
                else if(loc.Equals("Wilds"))
                {
                    if (grabbedMatTier == 1)
                    {
                        matID = Random.Range(9, 13);
                        Global.materials[matID] += 1;
                    }
                    else if (grabbedMatTier == 2)
                    {
                        matID = Random.Range(13, 16);
                        Global.materials[matID] += 1;
                    }
                    else
                    {
                        matID = Random.Range(16, 18);
                        Global.materials[matID] += 1;
                    }
                }
                else if (loc.Equals("Dungeon"))
                {
                    if (grabbedMatTier == 1)
                    {
                        matID = Random.Range(18, 22);
                        Global.materials[matID] += 1;
                    }
                    else if (grabbedMatTier == 2)
                    {
                        matID = Random.Range(22,25);
                        Global.materials[matID] += 1;
                    }
                    else
                    {
                        matID = Random.Range(25, 27);
                        Global.materials[matID] += 1;
                    }
                }

                if(!Global.FoundMaterials.Contains(matID))
                {
                    Global.FoundMaterials.Add(matID);
                }
            }
        }

    }

    int Roll()
    {
        return Random.Range(0, 100);
    }
    int getWorkerTier(string workerType)
    {
        if(workerType.Equals("Adventurer") || workerType.Equals("Explorer") || workerType.Equals("Trader"))
        {
            return 1;
        }
        else if(workerType.Equals("Veteran") || workerType.Equals("Ranger") || workerType.Equals("Merchant"))
        {
            return 2;
        }
        else if(workerType.Equals("Hero") || workerType.Equals("Beast Hunter") || workerType.Equals("Black Marketeer"))
        {
            return 3;
        }
        else { return -1; }
    }
    string setLocation(int location)
    {
        string loc;
        if (location <= 2)
        {
            loc = "Dungeon";
        }
        else if (location > 2 && location <= 5)
        {
            loc = "Wilds";
        }
        else
        {
            loc = "City";
        }
        return loc;
    }
}
