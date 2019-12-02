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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
