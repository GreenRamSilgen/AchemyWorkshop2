using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RGResourcePull : MonoBehaviour
{
    private MaterialList MaterialList = new MaterialList(); //Create MaterialList object
    GameObject materialGetter; //create gameobject

    public Text DungeonTier1;
    public Text DungeonTier2;
    public Text DungeonTier3;

    /*public Text WildsTier1;
    public Text WildsTier2;
    public Text WildsTier3;

    public Text CityTier1;
    public Text CityTier2;
    public Text CityTier3;*/
    

    void Start()
    {
        materialGetter = GameObject.FindGameObjectWithTag("Resourcer"); //Assign ResourceLoader gameobject to "materialGetter"
        MaterialList = materialGetter.GetComponent<MaterialLoader>().getMaterialList(); //Call getResourceList from ResourceLoader Script in ResourceHolder

        foreach (Materials material in MaterialList.Materials) //LOOP THROUGH ALL RESOURCES. 
        {
            switch (material.materialLocation)
            {
                case "Dungeon":
                    switch (material.materialTier) {
                        case 1:
                            if(Global.FoundMaterials.Contains(material.materialID)) {
                                DungeonTier1.text += material.materialName;
                            } else {
                                DungeonTier1.text += "???";
                            }
                            DungeonTier1.text += "\n";
                            break;
                        case 2:
                            if (Global.FoundMaterials.Contains(material.materialID))
                            {
                                DungeonTier2.text += material.materialName;
                            }
                            else
                            {
                                DungeonTier2.text += "???";
                            }
                            DungeonTier2.text += "\n";
                            break;
                        case 3:
                            if (Global.FoundMaterials.Contains(material.materialID))
                            {
                                DungeonTier3.text += material.materialName;
                            }
                            else
                            {
                                DungeonTier3.text += "???";
                            }
                            DungeonTier3.text += "\n";
                            break;
                    }
                    break;
                case "Wilds":
                    switch (material.materialTier)
                    {
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                    }
                    break;
                case "City":
                    switch (material.materialTier)
                    {
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                    }
                    break;
            }
        }
    }
}
