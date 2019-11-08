using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class CraftingController : MonoBehaviour
{
    public MaterialList MaterialList = new MaterialList();
    public List<GameObject> MaterialObjects = new List<GameObject>();
    public GameObject template;
    public Transform MaterialPanelTransform;
    public Dictionary<string, int> Aspects = new Dictionary<string, int>();
    public int materialSelected = -1;
    public Slot slot1;
    public Slot slot2;
    public Slot slot3;
    public
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
        //calculate aspects and update aspects panel
    }
    public void CraftPotion()
    {
        if(slot1.materialID > -1 && slot2.materialID > -1 && slot3.materialID > -1)
        {

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
    }
    public Sprite GetImage(int materialID)
    {
        return Resources.Load<Sprite>("Art/" + MaterialList.Materials[materialID].imageName);
    }
}
