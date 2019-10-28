using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NEED TO ADD USING:
using System.IO;
using System.Linq;
public class KiranTest : MonoBehaviour
{
    public struct Items
        {
            public int itemID;
            public string itemName;
            public int[] Aspect;
            public Items(int itemID, string itemName, int[] Aspect)
            {
                this.itemID = itemID;
                this.itemName = itemName;
                this.Aspect = Aspect;
            }
        }
    // Start is called before the first frame update
    void Start()
    {
        //ASPECT AMOUNT INCREASE OR DECREASE BASED ON DESIGN
        //IF CHANGED ADD MORE OR LESS CASE x: INT LOOP BELOW
        int aspectAmount = 6;

        //READ FROM FILE AND STORE EVERY LINE in "lines" list
        string filePath = @"..\AchemyWorkshop2\Assets\csvExperiment\ItemList.txt";
        List<string> lines = File.ReadAllLines(filePath).ToList();
        
        //CREATE AN ARRAY OF ITEMS WHEN SCENE STARTS
        //TESTING VERSION ONLY SO CANNOT REALLY ACCESS THIS ON OTHER SCRIPTS i think...
        Items[] allItem = new Items[lines.Count];
        
        int itemInitCounter = 0; //HELPS LOOP THROUGH ALL ITEMS TO BE CREATED (increases with text document size);
        
        //GO through ALL LINES AND INITIALIZE allItem[itemInitCounter] with id, name and aspects
        foreach(string line in lines)
        {
            string[] item = line.Split(',');
            allItem[itemInitCounter].Aspect = new int[aspectAmount];
            for(int i = 0; i < item.Length; i++)
            {
                int converted;
                switch(i)
                {
                    case 0:
                    int.TryParse(item[i], out converted);
                    allItem[itemInitCounter].itemID = converted;
                        break;
                    case 1:
                    allItem[itemInitCounter].itemName = item[i];
                        break;
                    case 2:
                    int.TryParse(item[i], out converted);
                    allItem[itemInitCounter].Aspect[i-2] = converted;
                        break;
                    case 3:
                    int.TryParse(item[i], out converted);
                    allItem[itemInitCounter].Aspect[i-2] = converted;
                        break;
                    case 4:
                    int.TryParse(item[i], out converted);
                    allItem[itemInitCounter].Aspect[i-2] = converted;
                        break;
                    case 5:
                    int.TryParse(item[i], out converted);
                    allItem[itemInitCounter].Aspect[i-2] = converted;
                        break;
                    case 6:
                    int.TryParse(item[i], out converted);
                    allItem[itemInitCounter].Aspect[i-2] = converted;
                        break;
                    case 7:
                    int.TryParse(item[i], out converted);
                    allItem[itemInitCounter].Aspect[i-2] = converted;
                        break;
                    default:
                    break;

                }
            }
            Debug.Log("ITEM ID= " + allItem[itemInitCounter].itemID);
            
            Debug.Log("ITEM Name= " + allItem[itemInitCounter].itemName);
            for(int i = 0; i < aspectAmount; i++)
            {
            Debug.Log("ITEM Aspects= " + allItem[itemInitCounter].Aspect[i]);
            }
            itemInitCounter++;
        }
    }
}