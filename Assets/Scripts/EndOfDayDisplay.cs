using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EndOfDayDisplay : MonoBehaviour
{

    public Ledger ledger;
    private int hireCost = 0;
    private int total = 0;
    // Use this for initialization
    void Start()
    {
        hireCost = calcHireCost();
        total = Global.moneyMade - 50 - hireCost;
        matUsed();
    }

    // Update is called once per frame
    void Update()
    {
        ledger.cost.text = "Hiring Cost \n-" + hireCost + "\n" + "Rent\n-50 \n" + "Potions Profit\n+" + Global.moneyMade + "\nNet Total: " + total;

        if (Input.GetKeyDown(KeyCode.P))
        {
            //ledger.cost.text = "YO";
            ledger.cost.text = "Hiring Cost: -" + calcHireCost() + "\n" + "Rent:- 50 \n" + "Potions Profit: +" + Global.moneyMade;
        }
    }

    int calcHireCost() // calculate the hiring costs based on that day
    {
        IDictionaryEnumerator myEnum = Global.gatherers.GetEnumerator();
        int count = 0;
        while(myEnum.MoveNext())
        {
            count += Global.gathererCost[myEnum.Key.ToString()] * System.Convert.ToInt32(myEnum.Value.ToString());
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

    void matUsed()
    {
        for (int i = 0; i < Global.materialsUsed.Count; i++)
        {
            Debug.Log(Global.materialsUsed[i]);
        }
    }
}
