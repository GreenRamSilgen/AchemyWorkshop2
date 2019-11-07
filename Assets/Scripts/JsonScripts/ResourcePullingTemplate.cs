using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ResourcePullingTemplate : MonoBehaviour
{
    private MaterialList MaterialList = new MaterialList(); //Create MaterialList object
    GameObject resourceGetter; //create gameobject
    void Start()
    {
         resourceGetter = GameObject.FindGameObjectWithTag("Resourcer"); //Assign ResourceLoader gameobject to "resourceGetter"
         MaterialList = resourceGetter.GetComponent<ResourceLoader>().getResourceList(); //Call getResourceList from ResourceLoader Script in ResourceHolder
         
         foreach(Materials it in MaterialList.Materials) //LOOP THROUGH ALL RESOURCES. 
         {
             Debug.Log("hippity hoppity");
         }
    }
}