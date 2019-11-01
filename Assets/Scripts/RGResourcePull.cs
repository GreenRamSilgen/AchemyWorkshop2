using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RGResourcePull : MonoBehaviour
{
    private ItemList ItemList = new ItemList(); //Create ItemList object
    GameObject resourceGetter; //create gameobject

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
        resourceGetter = GameObject.FindGameObjectWithTag("Resourcer"); //Assign ResourceLoader gameobject to "resourceGetter"
        ItemList = resourceGetter.GetComponent<ResourceLoader>().getResourceList(); //Call getResourceList from ResourceLoader Script in ResourceHolder

        foreach (Item it in ItemList.Items) //LOOP THROUGH ALL RESOURCES. 
        {
            switch (it.itemLoc)
            {
                case "Dungeon":
                    switch (it.itemTier) {
                        case 1:
                            if(Global.FoundItems.Contains(it.itemID)) {
                                DungeonTier1.text += it.itemName;
                            } else {
                                DungeonTier1.text += "???";
                            }
                            DungeonTier1.text += "\n";
                            break;
                        case 2:
                            if (Global.FoundItems.Contains(it.itemID))
                            {
                                DungeonTier2.text += it.itemName;
                            }
                            else
                            {
                                DungeonTier2.text += "???";
                            }
                            DungeonTier2.text += "\n";
                            break;
                        case 3:
                            if (Global.FoundItems.Contains(it.itemID))
                            {
                                DungeonTier3.text += it.itemName;
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
                    switch (it.itemTier)
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
                    switch (it.itemTier)
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
