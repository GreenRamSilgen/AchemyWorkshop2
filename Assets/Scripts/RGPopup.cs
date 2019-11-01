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

    private int Unit1;
    private int Unit2;
    private int Unit3;

    // Start is called before the first frame update
    void Start()
    {
        Unit1 = 0;
        Unit2 = 0;
        Unit3 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GoldText.text = "Gold : " + Global.gold;

        UnitCount1.text = Unit1.ToString();
        UnitCount2.text = Unit2.ToString();
        UnitCount3.text = Unit3.ToString();
    }

    public void Add(int unit)
    {
        if(unit == 1 && Global.gold >= 10) {
            Unit1++;
            Global.gold -= 10;
        }
        else if(unit == 2 && Global.gold >= 100) {
            Unit2++;
            Global.gold -= 100;
        }
        else if(unit == 3 && Global.gold >= 500) {
            Unit3++;
            Global.gold -= 500;
        }
    }

    public void Subtract(int unit)
    {
        if (unit == 1 && Unit1 > 0)
        {
            Unit1--;
            Global.gold += 10;
        }
        else if (unit == 2 && Unit2 > 0)
        {
            Unit2--;
            Global.gold += 100;
        }
        else if (unit == 3 && Unit3 > 0)
        {
            Unit3--;
            Global.gold += 500;
        }
    }
}
