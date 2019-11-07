/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NEED TO ADD USING:
using System.IO;
using System.Linq;
public class KiranTest : MonoBehaviour
{
    private ItemList ItemList = new ItemList(); //Create ItemList object
    GameObject resourceGetter; //create gameobject
    void Start()
    {
         resourceGetter = GameObject.FindGameObjectWithTag("Resourcer"); //Assign ResourceLoader gameobject to "resourceGetter"
         ItemList = resourceGetter.GetComponent<ResourceLoader>().getResourceList(); //Call getResourceList from ResourceLoader Script in ResourceHolder
         
         foreach(Item it in ItemList.Items) //LOOP THROUGH ALL RESOURCES. 
         {
             Debug.Log("hippity hoppity");
         }
    }
}*/