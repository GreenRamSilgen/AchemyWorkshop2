using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class CraftingController : MonoBehaviour
{
    private string resourcesFileName = "Data/Resources.json";
    public MaterialList MaterialList = new MaterialList();
    public List<GameObject> MaterialObjects = new List<GameObject>();
    public GameObject template;
    public Transform MaterialPanelTransform;
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
            RectTransform CanvasRectTransform = gameObject.transform as RectTransform;
            for (int i = 0; i < MaterialObjects.Count; i++)
            {
                MaterialObjects[i].transform.position = new Vector2((32 + 64 + i * 64 % 256) * gameObject.transform.localScale.x, (CanvasRectTransform.rect.height - 32 - (i / 4 * 64)) * gameObject.transform.localScale.y);
            }

            /*var obj = new GameObject();
            Image NewImage = obj.AddComponent<Image>();
            NewImage.sprite = Resources.Load<Sprite>(a + "/" + obj.name) as Sprite;
            obj.SetActive(true);
            obj.AddComponent<ClickAction>();*/


            /*foreach (Item item in ItemList.Items)
            {
                Debug.Log(item.itemID);
                Debug.Log(item.itemLoc);
                Debug.Log(item.itemName);
                Debug.Log(item.itemTier);
                Debug.Log(item.A1Name);
                Debug.Log(item.A1Amt);
                Debug.Log(item.A2Name);
                Debug.Log(item.A2Amt);
                Debug.Log(item.A3Name);
                Debug.Log(item.A3Amt);
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
        for (int i = 0; i < MaterialObjects.Count; i++)
        {
            MaterialObjects[i].GetComponent<ClickAction>().DeselectMaterial();
        }
    }
    public Sprite GetImage(int materialID)
    {
        return Resources.Load<Sprite>("Art/" + MaterialList.Materials[materialID].imageName);
    }
}
