using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class CraftingController : MonoBehaviour
{
    private string resourcesFileName = "Data/Resources.json";
    public ItemList ItemList = new ItemList();
    public List<GameObject> ItemObjects = new List<GameObject>();
    public GameObject template;
    public Transform ResourcePanelTransform;
    public int itemSelected = -1;
    public Slot slot1;
    public Slot slot2;
    public Slot slot3;
    /*    private string recipesFileName = "Data/Recipes.json";
    */    // Start is called before the first frame update
    void Start()
    {
        TextAsset asset = Resources.Load("SimpleResources") as TextAsset;
        if (asset != null)
        {
            //Debug.Log(jsonString);
            ItemList = JsonUtility.FromJson<ItemList>(asset.text);
            for(int i = 0; i < ItemList.Items.Count; i++)
            {
                ItemObjects.Add(Instantiate(template, ResourcePanelTransform));
            }
            RectTransform CanvasRectTransform = gameObject.transform as RectTransform;
            Debug.Log("hi " + CanvasRectTransform.rect.height);
            Debug.Log("hello " + gameObject.transform.localScale.y);
            for(int i = 0; i < ItemObjects.Count; i++)
            {
                ItemObjects[i].transform.position = new Vector2((32+64+i*64%256)*gameObject.transform.localScale.x, (CanvasRectTransform.rect.height - 32 - (i/4 * 64))*gameObject.transform.localScale.y);
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
    public int getItem()
    {
        return (itemSelected);
    }
    public void selectItem(int itemID)
    {
        itemSelected = itemID;
    }
    public void deselectItem()
    {
        itemSelected = -1;
        for(int i = 0; i < ItemObjects.Count; i++)
        {
            ItemObjects[i].GetComponent<ClickAction>().deselectItem();
        }
    }
    public Sprite GetImage(int itemID)
    {
        /*Debug.Log(ItemList.Items[itemID].imageName);*/
        Debug.Log(Resources.Load<Sprite>("Art/" + ItemList.Items[itemID].imageName));
        return Resources.Load<Sprite>("Art/" + ItemList.Items[itemID].imageName);
    }
    public void Update()
    {
        /*if (Input.GetMouseButtonUp(0)) {
            if (itemClicked > -1)
            {
                if (slot1.mouseOver)
                {
                    slot1.itemID = itemClicked;
                }
                if (slot2.mouseOver)
                {
                    slot2.itemID = itemClicked;
                }
                if (slot3.mouseOver)
                {
                    slot3.itemID = itemClicked;
                }
            }
            itemClicked = -1;
        }*/
    }
    /*void LoadData()
    {
        string filePath1 = Path.Combine(Application.streamingAssetsPath, resourcesFileName);
        string filePath2 = Path.Combine(Application.streamingAssetsPath, recipesFileName);
        if (File.Exists(filePath1) && File.Exists(filePath2))
        {
            string dataAsJson = File.ReadAllText(filePath1);
            //GameData loadedData = JsonUtility.FromJson<GameData>(dataAsJson);
            //string dataAsJson = File.ReadAllText(filePath2);
            //GameData loadedData = JsonUtility.FromJson<GameData>(dataAsJson);

        }
        else
        {
            Debug.LogError("Can't load game data!");
        }

    }*/
}
