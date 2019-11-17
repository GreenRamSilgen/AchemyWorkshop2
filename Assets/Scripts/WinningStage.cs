using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WinningStage : MonoBehaviour
{
    public Text message;
    void Start()
    {
        message.text = "Congratulations you have crafted the \nUltimate Potion after " + Global.day + " days";
    }

    // Update is called once per frame
    void Update()
    {
 
    }
}
