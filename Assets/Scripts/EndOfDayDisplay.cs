using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EndOfDayDisplay : MonoBehaviour
{
    public Text ledger;
    public Text day;

    // Use this for initialization
    void Start()
    {
        ledger.text = "LEDGER";
        day.text = "End of Day ";

    }

    // Update is called once per frame
    void Update()
    {
        ledger.text = "       LEDGER:\n\nHiring Cost:  - " + calcHireCost() + "\n\n" + "Rent:            - 50\n\n" + "Potions:       + "
                        +"---------------------\nTotal:          ";
        day.text = "End of Day " + Global.day;

    }

    int calcHireCost()
    {
        int count = 0;
        foreach (KeyValuePair<string, int> kv in Global.gatherers)
        {
            count += Global.gathererCost[kv.Key] * kv.Value;

        }

        return count;
    }
}
