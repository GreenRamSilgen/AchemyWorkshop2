using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Global.day = 1;
        Global.gold = 300;
        for(int i = 0; i < Global.materials.Count; i++)
        {
            Global.materials[i] = 0;
        }
        Global.materials[1] = 1;
        Global.materials[9] = 1;
        Global.materials[12] = 1;

        //Danger
        Global.FoundMaterials.Clear();
        Global.FoundMaterials.Add(1);
        Global.FoundMaterials.Add(9);
        Global.FoundMaterials.Add(12);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
