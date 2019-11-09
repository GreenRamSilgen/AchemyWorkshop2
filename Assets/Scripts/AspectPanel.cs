using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspectPanel : MonoBehaviour
{
    public const int ASPECT_MAX = 25;
    public GameObject AspectBarTemplate;
    public Transform AspectPanelTransform;
    public List<GameObject> AspectBars = new List<GameObject>();

    public void AddAspect(Materials material)
    {
        if (!material.A1Name.Equals("NA"))
        {
            bool barExists = false;
            for (int i = 0; i < AspectBars.Count; i++)
            {
                if (material.A1Name.Equals(AspectBars[i]))
                {
                    AspectBars[i].GetComponent<AspectBar>().UpdateValue(material.A1Amt);
                    barExists = true;
                }
            }
            if (!barExists)
            {
                AspectBars.Add(Instantiate(AspectBarTemplate, AspectPanelTransform));
                AspectBars[AspectBars.Count - 1].GetComponent<AspectBar>().UpdateValue(material.A1Amt);
            }
        }
        if (!material.A2Name.Equals("NA"))
        {
            bool barExists = false;
            for (int i = 0; i < AspectBars.Count; i++)
            {
                if (material.A2Name.Equals(AspectBars[i]))
                {
                    AspectBars[i].GetComponent<AspectBar>().UpdateValue(material.A2Amt);
                    barExists = true;
                }
            }
            if (!barExists)
            {
                AspectBars.Add(Instantiate(AspectBarTemplate, AspectPanelTransform));
                AspectBars[AspectBars.Count - 1].GetComponent<AspectBar>().UpdateValue(material.A2Amt);
            }
        }
        if (!material.A3Name.Equals("NA"))
        {
            bool barExists = false;
            for (int i = 0; i < AspectBars.Count; i++)
            {
                if (material.A3Name.Equals(AspectBars[i]))
                {
                    AspectBars[i].GetComponent<AspectBar>().UpdateValue(material.A3Amt);
                    barExists = true;
                }
            }
            if (!barExists)
            {
                AspectBars.Add(Instantiate(AspectBarTemplate, AspectPanelTransform));
                AspectBars[AspectBars.Count - 1].GetComponent<AspectBar>().UpdateValue(material.A3Amt);
            }
        }
    }
    public void RemoveAspect(Materials material)
    {

        if(!material.A1Name.Equals("NA"))
        {
            for (int i = 0; i < AspectBars.Count; i++)
            {
                if (material.A1Name.Equals(AspectBars[i]))
                {
                    AspectBars[i].GetComponent<AspectBar>().UpdateValue(-material.A1Amt);
                }
            }
        }
        if (!material.A2Name.Equals("NA"))
        {
            for (int i = 0; i < AspectBars.Count; i++)
            {
                if (material.A2Name.Equals(AspectBars[i]))
                {
                    AspectBars[i].GetComponent<AspectBar>().UpdateValue(-material.A2Amt);
                }
            }
        }
        if (!material.A3Name.Equals("NA"))
        {
            for (int i = 0; i < AspectBars.Count; i++)
            {
                if (material.A3Name.Equals(AspectBars[i]))
                {
                    AspectBars[i].GetComponent<AspectBar>().UpdateValue(-material.A3Amt);
                }
            }
        }
    }
    public void ResetAspects()
    {
        AspectBars = new List<GameObject>();
    }
}
