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
    public GameObject template;
    public Transform MaterialPanelTransform;
    
    public int materialSelected = -1;
    public Slot slot1;
    public Slot slot2;
    public Slot slot3;
    public IDictionary<int, Slot> Slots = new Dictionary<int, Slot>();
    public AspectPanel AspectPanel;
    public IDictionary<string, int> Aspects = new Dictionary<string, int>();
    
    /*    private string recipesFileName = "Data/Recipes.json";
    */    // Start is called before the first frame update
    void Start()
    {
        materials = Global.materials;
        TextAsset asset = Resources.Load("Materials") as TextAsset;
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
    public void SlotMaterial(int materialID, int slotID)
    {
        if (Slots[slotID].filled)
        {
            AspectPanel.RemoveAspect(MaterialList.Materials[Slots[slotID].materialID]);
            RemoveAspect(materialID);
        }
        AspectPanel.AddAspect(MaterialList.Materials[materialID]);
        AddAspect(materialID);

        //calculate aspects and update aspects panel
    }
    public void AddAspect(int materialID)
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
        /*Debug.Log(Aspects.Count);*/
    }
    public void RemoveAspect(int materialID)
    {
        Materials material = MaterialList.Materials[materialID];
        if (material.A1Name != "NA")
        {
            if (Aspects.ContainsKey(material.A1Name))
            {
                Aspects[material.A1Name] -= material.A1Amt;
                if(Aspects[material.A1Name] == 0)
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
        public void CraftPotion()
    {
        if(slot1.materialID > -1 || slot2.materialID > -1 || slot3.materialID > -1)
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
                        //we crafted the potion woohoo!!!!
                        Global.gold += RecipeList.Recipes[i].recipeValue;
                    }
                }
            }
            if (slot1.materialID > -1)
            {
                materials[slot1.materialID] -= 1;
                if (materials[slot1.materialID] < 1)
                {
                    if (MaterialObjects.ContainsKey(slot1.materialID))
                    {
                        Object.Destroy(MaterialObjects[slot1.materialID]);
                    }
                }
                else
                {
                    if (MaterialObjects.ContainsKey(slot1.materialID))
                    {
                        MaterialObjects[slot1.materialID].GetComponentInChildren<Text>().text = materials[slot1.materialID].ToString();
                    }
                }
            }
            if (slot2.materialID > -1)
            {
                materials[slot2.materialID] -= 1;
                if (materials[slot2.materialID] < 1)
                {
                    if (MaterialObjects.ContainsKey(slot2.materialID))
                    {
                        Object.Destroy(MaterialObjects[slot2.materialID]);
                    }
                }
                else
                {
                    if (MaterialObjects.ContainsKey(slot2.materialID))
                    {
                        MaterialObjects[slot2.materialID].GetComponentInChildren<Text>().text = materials[slot2.materialID].ToString();
                    }
                }
            }
            if (slot3.materialID > -1)
            {
                materials[slot3.materialID] -= 1;
                if (materials[slot3.materialID] < 1)
                {
                    if (MaterialObjects.ContainsKey(slot3.materialID))
                    {
                        Object.Destroy(MaterialObjects[slot3.materialID]);
                    }
                }
                else
                {
                    if (MaterialObjects.ContainsKey(slot3.materialID))
                    {
                        MaterialObjects[slot3.materialID].GetComponentInChildren<Text>().text = materials[slot3.materialID].ToString();
                    }
                }
            }
            ResetSlots();
            //also, once inventory is implemented, remove items from the inventory
        }
        else
        {
            Debug.Log("Place a material!");
        }
    }
    public void ResetSlots()
    {
        slot1.ResetSlot();
        slot2.ResetSlot();
        slot3.ResetSlot();
        AspectPanel.ResetAspects();
        Aspects = new Dictionary<string, int>();
    }
    public Sprite GetImage(int materialID)
    {
        return Resources.Load<Sprite>("Art/" + MaterialList.Materials[materialID].imageName);
    }
}
