using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WinningStage : MonoBehaviour
{
    public Text message;
    void Start()
    {
        message.text = "Congratulations!\n You crafted\n The Philosopher's Stone\n after " + Global.day + " days.";
    }

}
