using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonTesting : MonoBehaviour
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
            }
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
}
