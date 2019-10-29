using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonGetter : MonoBehaviour
{
    List<Item> getItems()
    {
        return (JsonUtility.FromJson<ItemList>((Resources.Load("SimpleResources") as TextAsset).text)).Items;
    }
}
