using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RGPopup : MonoBehaviour
{
    public Text GoldText;

    public Text UnitCount1;
    public Text UnitCount2;
    public Text UnitCount3;

    public Text UnitCount1Main;
    public Text UnitCount2Main;
    public Text UnitCount3Main;

    private int Unit1;
    private int Unit2;
    private int Unit3;

    public string location;

    // Start is called before the first frame update
    void Start()
    {
        Unit1 = 0;
        Unit2 = 0;
        Unit3 = 0;

        UnitCount1.text = Unit1.ToString();
        UnitCount2.text = Unit2.ToString();
        UnitCount3.text = Unit3.ToString();

        UnitCount1Main.text = Unit1.ToString();
        UnitCount2Main.text = Unit2.ToString();
        UnitCount3Main.text = Unit3.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        GoldText.text = "Gold : " + Global.gold;

        UnitCount1.text = Unit1.ToString();
        UnitCount2.text = Unit2.ToString();
        UnitCount3.text = Unit3.ToString();

        UnitCount1Main.text = Unit1.ToString();
        UnitCount2Main.text = Unit2.ToString();
        UnitCount3Main.text = Unit3.ToString();
    }

    private void OnDestroy()
    {
        switch(location)
        {
            case "dungeon":
                Global.gatherers["Adventurer"] = Unit1;
                Global.gatherers["Veteran"] = Unit2;
                Global.gatherers["Hero"] = Unit3;
                Debug.Log("dungeon works");
                break;
            case "wilds":
                Global.gatherers["Explorer"] = Unit1;
                Global.gatherers["Ranger"] = Unit2;
                Global.gatherers["Beast Hunter"] = Unit3;
                Debug.Log("wilds works");
                break;
            case "city":
                Global.gatherers["Trader"] = Unit1;
                Global.gatherers["Merchant"] = Unit2;
                Global.gatherers["Black Marketeer"] = Unit3;
                Debug.Log("city works");
                break;
        }
    }

    public void Add(int unit)
    {
        if(unit == 1) {
            Unit1++;
            Global.gold -= 10;
            FindObjectOfType<AudioManager>().Play("Buy");
        }
        else if(unit == 2) {
            Unit2++;
            Global.gold -= 100;
            FindObjectOfType<AudioManager>().Play("Buy");
        }
        else if(unit == 3) {
            Unit3++;
            Global.gold -= 500;
            FindObjectOfType<AudioManager>().Play("Buy");
        }

        if(Global.gold < 0) {
            GoldText.color = Color.red;
        }
    }

    public void Subtract(int unit)
    {
        if (unit == 1 && Unit1 > 0)
        {
            Unit1--;
            Global.gold += 10;
            FindObjectOfType<AudioManager>().Play("Sell");
        }
        else if (unit == 2 && Unit2 > 0)
        {
            Unit2--;
            Global.gold += 100;
            FindObjectOfType<AudioManager>().Play("Sell");
        }
        else if (unit == 3 && Unit3 > 0)
        {
            Unit3--;
            Global.gold += 500;
            FindObjectOfType<AudioManager>().Play("Sell");
        }

        if(Global.gold >= 0) {
            GoldText.color = Color.white;
        }
    }

    public int Count(int unit)
    {
        switch(unit) {
            case 1:
                return Unit1;
            case 2:
                return Unit2;
            case 3:
                return Unit3;
        }
        return 0;

    }
}
