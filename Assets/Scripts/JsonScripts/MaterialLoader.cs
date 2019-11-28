using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MaterialLoader : MonoBehaviour
{
    //START COPY HERE
    public MaterialList matList = new MaterialList();
    void Start()
    {
        TextAsset asset = Resources.Load("Materials") as TextAsset;
        if (asset != null)
        {
            //Debug.Log(jsonString);
            matList = JsonUtility.FromJson<MaterialList>(asset.text);

            foreach (Materials material in matList.Materials)
            {
            }
        }
        else
        {
            print("Asset is null");
        }
    }

    public MaterialList getMaterialList()
    {
        return matList;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
