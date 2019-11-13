using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscScript : MonoBehaviour
{
    public static bool Pause = false;
    public GameObject escMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Pause)
            {
                CloseMenu();
            }
            else
            {
                OpenMenu();
            }
        }
    }
    
    public void CloseMenu()
    {
        Pause = false;
        escMenu.SetActive(false);
    }

    public void OpenMenu()
    {
        Pause = true;
        escMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Bid you farewell!");
        Application.Quit();
    }
}
