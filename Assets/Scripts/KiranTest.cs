using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NEED TO ADD USING:
using System.IO;
using System.Linq;
public class KiranTest : MonoBehaviour
{
    
    private MaterialList MaterialList = new MaterialList(); //Create MaterialList object
    GameObject resourceGetter; //create gameobject
  
    void Start()
    {
        for(int i = 0; i < Global.materials.Count; i++)
        {
            int myVal = Global.materials[i];
            print(myVal);
            Global.materials[i]++;
        }
    }
}