using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MaterialPullingTemplate : MonoBehaviour
{
    private MaterialList MaterialList = new MaterialList(); //Create ItemList object
    GameObject materialsGetter; //create gameobject
    void Start()
    {
         materialsGetter = GameObject.FindGameObjectWithTag("Resourcer"); //Assign ResourceLoader gameobject to "resourceGetter"
         MaterialList = materialsGetter.GetComponent<MaterialLoader>().getMaterialList(); //Call getResourceList from ResourceLoader Script in ResourceHolder
         
         foreach(Materials material in MaterialList.Materials) //LOOP THROUGH ALL RESOURCES. 
         {
         }
    }
}