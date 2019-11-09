using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class CraftingController : MonoBehaviour
{
    public MaterialList MaterialList = new MaterialList();
    public RecipeList RecipeList = new RecipeList();
    public List<GameObject> MaterialObjects = new List<GameObject>();
    public GameObject template;
    public Transform MaterialPanelTransform;
    
    public int materialSelected = -1;
    public Slot slot1;
    public Slot slot2;
    public Slot slot3;
    public Dictionary<int, Slot> Slots = new Dictionary<int, Slot>();
    public AspectPanel AspectPanel;
    
    /*    private string recipesFileName = "Data/Recipes.json";
    */    // Start is called before the first frame update
    void Start()
    {
        TextAsset asset = Resources.Load("Materials") as TextAsset;
        if (asset != null)
        {
            //Debug.Log(jsonString);
            MaterialList = JsonUtility.FromJson<MaterialList>(asset.text);
            for (int i = 0; i < MaterialList.Materials.Count; i++)
            {
                MaterialObjects.Add(Instantiate(template, MaterialPanelTransform));
            }
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
        }
        AspectPanel.AddAspect(MaterialList.Materials[materialID]);

        //calculate aspects and update aspects panel
    }
    
    public void CraftPotion()
    {
        if(slot1.materialID > -1 && slot2.materialID > -1 && slot3.materialID > -1)
        {
            //get the aspects from the aspect panel, or store them in this crafting controller
            //then look through recipe list to see if any recipes match up
            //craft if so, otherwise...get small amount of money?
            bool craftedPotion = false;
            for(int i = 0; i < RecipeList.Recipes.Count; i++)
            {
                
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
    }
    public Sprite GetImage(int materialID)
    {
        return Resources.Load<Sprite>("Art/" + MaterialList.Materials[materialID].imageName);
    }
}
