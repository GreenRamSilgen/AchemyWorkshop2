using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class CraftingController : MonoBehaviour
{
    private string resourcesFileName = "Data/Resources.json";
    private string recipesFileName = "Data/Recipes.json";
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadData()
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

    }
}
