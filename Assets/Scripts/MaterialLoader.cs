using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MaterialLoader : MonoBehaviour
{
    //START COPY HERE
    public MaterialList MaterialList = new MaterialList();
    void Start()
    {
        TextAsset asset = Resources.Load("Material") as TextAsset;
        if (asset != null)
        {
            //Debug.Log(jsonString);
            MaterialList = JsonUtility.FromJson<MaterialList>(asset.text);

            foreach (Material material in MaterialList.Materials)
            {
                Debug.Log(material.materialID);
                Debug.Log(material.materialLocation);
                Debug.Log(material.materialName);
                Debug.Log(material.materialTier);
                Debug.Log(material.A1Name);
                Debug.Log(material.A1Amt);
                Debug.Log(material.A2Name);
                Debug.Log(material.A2Amt);
                Debug.Log(material.A3Name);
                Debug.Log(material.A3Amt);
            }
        }
        else
        {
            print("Asset is null");
        }

        
    }

    public MaterialList getMaterialList()
    {
        return MaterialList;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
