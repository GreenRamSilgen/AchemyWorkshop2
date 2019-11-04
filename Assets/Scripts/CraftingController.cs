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
                ItemObjects[i].transform.position = new Vector2(32+i*46%184, CanvasRectTransform.rect.height/2 - (i/4 * 32));
            }
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

    // Update is called once per frame
    void Update()
    {
        
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
