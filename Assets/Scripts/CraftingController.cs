using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class CraftingController : MonoBehaviour
{
    public MaterialList MaterialList = new MaterialList();
    public IDictionary<int, int> materials = new Dictionary<int, int>();
    public RecipeList RecipeList = new RecipeList();
    public IDictionary<int, GameObject> MaterialObjects = new Dictionary<int, GameObject>();
    public IDictionary<int, GameObject> RecipeObjects = new Dictionary<int, GameObject>();
    public GameObject template;
    public Transform MaterialPanelTransform;
    
    public int materialSelected = -1;
    public Slot slot1;
    public Slot slot2;
    public Slot slot3;
    public IDictionary<int, Slot> Slots = new Dictionary<int, Slot>();
    public AspectPanel AspectPanel;
    public IDictionary<string, int> Aspects = new Dictionary<string, int>();
    public GameObject recipeTemplate;
    public Transform RecipePanelTransform;
    public int crafts = 0;
    public const int NUM_OF_CRAFTS_PER_DAY = 5;
    public StageCycle StageCycle;
    public BarChart BarChart;
    public const int END_RECIPE_ID = 3;
    public Object[] sprites;
    /*    private string recipesFileName = "Data/Recipes.json";
    */    // Start is called before the first frame update
    void Start()
    {
        materials = Global.materials;
        Global.recipeHistory = new List<RecipeInfo>();
        Global.materialsUsed = new List<int>();
        Global.moneyMade = 0;
        TextAsset asset = Resources.Load("Materials") as TextAsset;
        sprites = Resources.LoadAll("Sprites/Materials");
        if (asset != null)
        {
            //Debug.Log(jsonString);
            MaterialList = JsonUtility.FromJson<MaterialList>(asset.text);
            foreach(int id in materials.Keys)
            {
                if(materials[id] > 0)
                {
                    MaterialObjects.Add(id, Instantiate(template, MaterialPanelTransform));
                    MaterialObjects[id].GetComponent<ClickAction>().materialID = id;
                    MaterialObjects[id].GetComponentInChildren<Text>().text = materials[id].ToString();
                }
                
            }
            /*for (int i = 0; i < MaterialList.Materials.Count; i++)
            {
                MaterialObjects.Add(Instantiate(template, MaterialPanelTransform));
                MaterialObjects[i].GetComponent<ClickAction>().materialID = i;
            }*/
            /*RectTransform CanvasRectTransform = gameObject.transform as RectTransform;
            for (int i = 0; i < MaterialObjects.Count; i++)
            {
                MaterialObjects[i].transform.position = new Vector2((32 + 64 + i * 64 % 256) * gameObject.transform.localScale.x, (CanvasRectTransform.rect.height - 32 - (i / 4 * 64)) * gameObject.transform.localScale.y);
            }*/
            foreach(RecipeInfo recipe in Global.recipes)
            {
                AddRecipeObject(recipe);
            }
        }
        else
        {
            print("Asset is null");
        }
        TextAsset asset2 = Resources.Load("Recipes") as TextAsset;
        if(asset != null)
        {
            RecipeList = JsonUtility.FromJson<RecipeList>(asset2.text);
        }
        else
        {
            print("Asset is null");
        }
        Slots.Add(0, slot1);
        slot1.id = 0;
        Slots.Add(1, slot2);
        slot2.id = 1;
        Slots.Add(2, slot3);
        slot3.id = 2;

        BarChart.updateBarGraph(Slots[0].materialID, Slots[1].materialID, Slots[2].materialID);
        List<int> materialIDs = new List<int>();
        materialIDs.Add(6);
        materialIDs.Add(15);
        materialIDs.Add(26);
        RecipeInfo endRecipe = new RecipeInfo(0, END_RECIPE_ID, RecipeList.Recipes[END_RECIPE_ID].recipeName, RecipeList.Recipes[END_RECIPE_ID].recipeValue, materialIDs);
        AddRecipe(END_RECIPE_ID, endRecipe);

    }

    void Update()
    {
        int myID = Slots[0].materialID;
        BarChart.updateBarGraph(Slots[0].materialID, Slots[1].materialID, Slots[2].materialID);

    }
    public int GetMaterial()
    {
        return (materialSelected);
    }
    public void SelectMaterial(int materialID)
    {
        materialSelected = materialID;
    }
    public void DeselectMaterial()
    {
        materialSelected = -1;
    }
    public void AddMaterial(int materialID)
    {
        if (materialID > -1)
        {
            if (materials[materialID] < 1)
            {
                if (!MaterialObjects.ContainsKey(materialID))
                {
                    MaterialObjects.Add(materialID, Instantiate(template, MaterialPanelTransform));
                    MaterialObjects[materialID].GetComponent<ClickAction>().materialID = materialID;
                    MaterialObjects[materialID].GetComponentInChildren<Text>().text = "1";

                }
                else
                {
                    MaterialObjects[materialID].GetComponentInChildren<Text>().text = "1";
                }
            }
            else
            {
                MaterialObjects[materialID].GetComponentInChildren<Text>().text = (materials[materialID]+1).ToString();
            }
            materials[materialID] += 1;
        }
        BarChart.updateBarGraph(slot1.materialID, slot2.materialID, slot3.materialID);
    }
    public void RemoveMaterial(int materialID)
    {
        if (materialID > -1)
        {
            materials[materialID] -= 1;
            if (materials[materialID] < 1)
            {
                if (MaterialObjects.ContainsKey(materialID))
                {
                    Object.Destroy(MaterialObjects[materialID]);
                    MaterialObjects.Remove(materialID);
                }
            }
            else
            {
                if (MaterialObjects.ContainsKey(materialID))
                {
                    MaterialObjects[materialID].GetComponentInChildren<Text>().text = materials[materialID].ToString();
                }
            }
        }
        BarChart.updateBarGraph(slot1.materialID, slot2.materialID, slot3.materialID);
    }
    public void SlotMaterial(int newID, int oldID)
    {
        AddMaterial(oldID);
        RemoveAspect(oldID);
        RemoveMaterial(newID);
        AddAspect(newID);
        FindObjectOfType<AudioManager>().Play(Global.rand.Next(2, 7));

    }
    public void AddAspect(int materialID)
    {
        if(materialID > -1)
        {
            Materials material = MaterialList.Materials[materialID];
            if (material.A1Name != "NA")
            {
                if (Aspects.ContainsKey(material.A1Name))
                {
                    Aspects[material.A1Name] += material.A1Amt;
                }
                else
                {
                    Aspects.Add(material.A1Name, material.A1Amt);
                }
            }
            if (material.A2Name != "NA")
            {
                if (Aspects.ContainsKey(material.A2Name))
                {
                    Aspects[material.A2Name] += material.A2Amt;
                }
                else
                {
                    Aspects.Add(material.A2Name, material.A2Amt);
                }
            }
            if (material.A3Name != "NA")
            {
                if (Aspects.ContainsKey(material.A3Name))
                {
                    Aspects[material.A3Name] += material.A3Amt;
                }
                else
                {
                    Aspects.Add(material.A3Name, material.A3Amt);
                }
            }
        }
        
        Debug.Log(Aspects.Count);
    }
    
    public void RemoveAspect(int materialID)
    {
        if(materialID > -1)
        {
            Materials material = MaterialList.Materials[materialID];
            if (material.A1Name != "NA")
            {
                if (Aspects.ContainsKey(material.A1Name))
                {
                    Aspects[material.A1Name] -= material.A1Amt;
                    if (Aspects[material.A1Name] == 0)
                    {
                        Aspects.Remove(material.A1Name);
                    }
                }

            }
            if (material.A2Name != "NA")
            {
                if (Aspects.ContainsKey(material.A2Name))
                {
                    Aspects[material.A2Name] -= material.A2Amt;
                    if (Aspects[material.A2Name] == 0)
                    {
                        Aspects.Remove(material.A2Name);
                    }
                }
            }
            if (material.A3Name != "NA")
            {
                if (Aspects.ContainsKey(material.A3Name))
                {
                    Aspects[material.A3Name] -= material.A3Amt;
                    if (Aspects[material.A3Name] == 0)
                    {
                        Aspects.Remove(material.A3Name);
                    }
                }
            }
        }
        
    }
    public void CraftPotion()
    {
        if (slot1.materialID > -1 || slot2.materialID > -1 || slot3.materialID > -1)
        {
            //get the aspects from the aspect panel, or store them in this crafting controller
            //then look through recipe list to see if any recipes match up
            //craft if so, otherwise...get small amount of money?
            bool craftedPotion = false;
            string mainAspect = "";
            int highest = 0;
            foreach (string aspect in Aspects.Keys)
            {
                if(Aspects[aspect] > highest)
                {
                    mainAspect = aspect;
                }
            }
            for(int i = 0; i < RecipeList.Recipes.Count; i++)
            {
                if (mainAspect.Equals(RecipeList.Recipes[i].mainAspectName) && Aspects.ContainsKey(RecipeList.Recipes[i].subAspect1Name) && Aspects.ContainsKey(RecipeList.Recipes[i].subAspect2Name))
                {
                    if(Aspects[RecipeList.Recipes[i].subAspect1Name] >= RecipeList.Recipes[i].subAspect1Min
                        && Aspects[RecipeList.Recipes[i].subAspect1Name] <= RecipeList.Recipes[i].subAspect1Max
                        && Aspects[RecipeList.Recipes[i].subAspect2Name] >= RecipeList.Recipes[i].subAspect2Min
                        && Aspects[RecipeList.Recipes[i].subAspect2Name] <= RecipeList.Recipes[i].subAspect2Max)
                    {
                        if(i == END_RECIPE_ID)
                        {
                            StageCycle.FadeToStage(5);//WIN
                        }
                        //we crafted the potion woohoo!!!!
                        craftedPotion = true;
                        Global.moneyMade += RecipeList.Recipes[i].recipeValue;
                        Global.gold += RecipeList.Recipes[i].recipeValue;
                        List<int> materialIDs = new List<int>();
                        materialIDs.Add(slot1.materialID);
                        materialIDs.Add(slot2.materialID);
                        materialIDs.Add(slot3.materialID);
                        RecipeInfo recipe = new RecipeInfo(Global.recipes.Count, i, RecipeList.Recipes[i].recipeName, RecipeList.Recipes[i].recipeValue, materialIDs);
                        Global.recipeHistory.Add(recipe);
                        for(int j = 0; j < materialIDs.Count; j++)
                        {
                            if(materialIDs[j] > -1)
                            {
                                Global.materialsUsed.Add(materialIDs[j]);
                                Debug.Log("Global.materialsUsed[0] =  " + Global.materialsUsed[0]);
                                Debug.Log("materialIDs[j]= "+ materialIDs[j]);
                                Debug.Log("j = " + j);
                            }
                        }

                        AddRecipe(i, recipe);
                        crafts += 1;
                        if(crafts >= NUM_OF_CRAFTS_PER_DAY){
                            StageCycle.FadeToStage(4);//TO END DAY
                        }
                    }
                }
            }
            EmptySlots();
            if (!craftedPotion)
            {
                FindObjectOfType<AudioManager>().Play(0);
            }
            else
            {
                FindObjectOfType<AudioManager>().Play(1);

            }
        }
        else
        {
            Debug.Log("Place a material!");
        }
    }
    public void AddRecipe(int resultID, RecipeInfo recipe)
    {
        bool duplicate = false;
        for (int i = 0; i < Global.recipes.Count; i++)
        {
            if (Global.recipes[i].materialIDs.Contains(recipe.materialIDs[0]) && Global.recipes[i].materialIDs.Contains(recipe.materialIDs[1]) && Global.recipes[i].materialIDs.Contains(recipe.materialIDs[2]))
            {
                duplicate = true;
            }
        }
        if (!duplicate)
        {
            
            Global.recipes.Add(recipe);
            AddRecipeObject(recipe);
        }
    }
    public void AddRecipeObject(RecipeInfo recipe)
    {
        RecipeObjects.Add(recipe.recipeID, Instantiate(recipeTemplate, RecipePanelTransform));
        RecipeObjects[RecipeObjects.Count - 1].GetComponent<RecipeObject>().Initialize(recipe);
        
    }
    public void SlotMaterials(List<int> materialIDs)
    {
        
        for (int i = 0; i < materialIDs.Count; i++)
        {
            if (materialIDs[i] != Slots[i].materialID && materialIDs[i] > -1 && materials[materialIDs[i]] > 0)
            {
                Slots[i].AddMaterial(materialIDs[i]);
            }
            else
            {
                AddMaterial(Slots[i].materialID);
                Slots[i].ResetSlot();
            }
        }
        BarChart.updateBarGraph(slot1.materialID, slot2.materialID, slot3.materialID);
    }
    public void EmptySlots()
    {
        slot1.ResetSlot();
        slot2.ResetSlot();
        slot3.ResetSlot();
        AspectPanel.ResetAspects();
        Aspects = new Dictionary<string, int>();
    }
    public void ResetSlots()
    {
        AddMaterial(slot1.materialID);
        AddMaterial(slot2.materialID);
        AddMaterial(slot3.materialID);
        slot1.ResetSlot();
        slot2.ResetSlot();
        slot3.ResetSlot();
        AspectPanel.ResetAspects();
        Aspects = new Dictionary<string, int>();
        BarChart.updateBarGraph(slot1.materialID, slot2.materialID, slot3.materialID);
    }
    public Sprite GetImage(int materialID)
    {
        if(materialID == -1)
        {
            return Resources.Load<Sprite>("Art/NA");
        }
        /*Debug.Log("Art/" + MaterialList.Materials[materialID].imageName);
        Debug.Log(Resources.Load<Sprite>("Sprites/" + MaterialList.Materials[materialID].imageName));
        return Resources.Load<Sprite>("Sprites/" + MaterialList.Materials[materialID].imageName);
        */
        /*Debug.Log(sprites.Length);*/
        return (Sprite) sprites[materialID+1];
    }
}
