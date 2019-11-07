using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ResourceLoader : MonoBehaviour
{
    //START COPY HERE
    public ItemList ItemList = new ItemList();
    void Start()
    {
        TextAsset asset = Resources.Load("SimpleResources") as TextAsset;
        if (asset != null)
        {
            //Debug.Log(jsonString);
            ItemList = JsonUtility.FromJson<ItemList>(asset.text);

            foreach (Item item in ItemList.Items)
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
            }
        }
        else
        {
            print("Asset is null");
        }

        
    }

    public ItemList getResourceList()
    {
        return ItemList;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
