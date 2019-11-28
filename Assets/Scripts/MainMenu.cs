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
        Global.materials[0] = 2;
        Global.materials[1] = 1;
        Global.materials[2] = 1;
        for(int i = 3; i < Global.materials.Count; i++)
        {
            Global.materials[i] = 0;
        }

        //Danger
        Global.FoundMaterials.Clear();
        Global.FoundMaterials.Add(0);
        Global.FoundMaterials.Add(1);
        Global.FoundMaterials.Add(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
