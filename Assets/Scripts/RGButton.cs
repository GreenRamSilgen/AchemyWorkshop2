using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RGButton : MonoBehaviour
{
    public GameObject CaveCanvas;
    public GameObject ForestCanvas;
    public GameObject TownCanvas;
    public GameObject DimCanvas;


    // Start is called before the first frame update
    void Start()
    {
        CaveCanvas.SetActive(false);
        ForestCanvas.SetActive(false);
        TownCanvas.SetActive(false);
        DimCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
    }

    public void CloseCanvases() {
        FindObjectOfType<AudioManager>().Play(2);
        CaveCanvas.SetActive(false);
        ForestCanvas.SetActive(false);
        TownCanvas.SetActive(false);
        DimCanvas.SetActive(false);
    }

    public void CavesButton() {
        if(!CaveCanvas.activeInHierarchy && !ForestCanvas.activeInHierarchy && !TownCanvas.activeInHierarchy) {
            CaveCanvas.SetActive(true);
            DimCanvas.SetActive(true);
        }
        FindObjectOfType<AudioManager>().Play(2);

    }

    public void ForestButton()
    {
        if (!CaveCanvas.activeInHierarchy && !ForestCanvas.activeInHierarchy && !TownCanvas.activeInHierarchy)
        {
            ForestCanvas.SetActive(true);
            DimCanvas.SetActive(true);
        }
        FindObjectOfType<AudioManager>().Play(2);

    }

    public void TownButton()
    {
        if (!CaveCanvas.activeInHierarchy && !ForestCanvas.activeInHierarchy && !TownCanvas.activeInHierarchy)
        {
            TownCanvas.SetActive(true);
            DimCanvas.SetActive(true);
        }
        FindObjectOfType<AudioManager>().Play(2);

    }
}
