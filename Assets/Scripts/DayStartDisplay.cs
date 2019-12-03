using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DayStartDisplay : MonoBehaviour
{
    public TextMeshProUGUI dayNum;
    // Start is called before the first frame update
    void Start()
    {
        dayNum.text = Global.day.ToString();
        Global.startGold = Global.gold;

        Global.start_materials = new Dictionary<int, int>()
        {
            //City Materials
            [0] = 0,
            [1] = 0,
            [2] = 0,
            [3] = 0,
            [4] = 0,
            [5] = 0,
            [6] = 0,
            [7] = 0,
            [8] = 0,

            //Wild Materials
            [9] = 0,
            [10] = 0,
            [11] = 0,
            [12] = 0,
            [13] = 0,
            [14] = 0,
            [15] = 0,
            [16] = 0,
            [17] = 0,

            //Dungeon Materials
            [18] = 0,
            [19] = 0,
            [20] = 0,
            [21] = 0,
            [22] = 0,
            [23] = 0,
            [24] = 0,
            [25] = 0,
            [26] = 0
        }; ;
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
