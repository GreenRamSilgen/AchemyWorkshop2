using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class EndOfDayDisplay : MonoBehaviour
{
    public Text ledger;
    public Text day;

    // Use this for initialization
    void Start()
    {
        day.text = "End of Day " + Global.day;
        ledger.text = "       LEDGER:\n\nHiring Cost:  - " + calcHireCost() + "\n\n" + "Rent:            - 50\n\n" + "Potions:       + "
                        +"---------------------\nTotal:          ";
        

    }

    // Update is called once per frame
    void Update()
    {
        

    }

    int calcHireCost() // calculate the hiring costs based on that day
    {
        int count = 0;
        foreach (KeyValuePair<string, int> kv in Global.gathererCost)
        {
           
            count += Global.gatherers[kv.Key] * kv.Value;
          

        }

        return count;
    }
    void printDict()//used for debugging
    {
        foreach(KeyValuePair<string, int> kv in Global.gatherers)
        {
            print("key: " + kv.Key + "   value: " + kv.Value);
            print(Global.gatherers.ContainsKey(kv.Key));
            print(Global.gathererCost.ContainsKey(kv.Key));
            print("=======================");
        }
    }
}
