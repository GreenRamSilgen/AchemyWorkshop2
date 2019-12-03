using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tutorial : MonoBehaviour
{
    public GameObject tutorialCanvas;
    // Start is called before the first frame update
    void Start()
    {
        if(Global.day == 1)
        {
            tutorialCanvas.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
