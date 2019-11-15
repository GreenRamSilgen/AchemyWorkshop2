using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class BarChart : MonoBehaviour
{
    public Bar barPreFab;
    public int[] inputValues;
    public string[] labels;

    List<Bar> bars = new List<Bar>();

    float chartHeight;
    void Start()
    {
        chartHeight = Screen.height - GetComponent<RectTransform>().sizeDelta.y;
        float[] tesVal = { .1f, 1f, .5f };
        DisplayGraph(inputValues);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log(bars.Count);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Destroy(bars[0].bar);
            Debug.Log(bars.Count);
        }
    }

    void DisplayGraph(int[] values)
    {
        int maxValue = values.Max();//Maybe change max value to 25 for consistent graph all the time

        for (int i = 0; i < values.Length; i++) //instantiate bar per input value
        {
            Bar newBar = Instantiate<Bar>(barPreFab, transform);
            newBar.transform.SetParent(transform);
            //Makes height change based on value
            RectTransform rt = newBar.bar.GetComponent<RectTransform>();

            //Normalize the input values based on max.
            float normalizedValue = (float)values[i] / (float)maxValue;

            //set Height of the Bar.
            rt.sizeDelta = new Vector2(rt.sizeDelta.x, (chartHeight/6) * normalizedValue);

            //set Label of created Bar (aspect name)
            if(labels.Length <= i)
            {
                newBar.label.text = "UNDEFINED";
            }
            else
            {
                newBar.label.text = labels[i];
            }

            //set Value on top of bar
            newBar.barValue.text = values[i].ToString();
            
            //if bar is too small make input value display above bar.
            /*if(rt.sizeDelta.y < 10f)
            {
                newBar.barValue.rectTransform.pivot = new Vector2(0.5f, 0f);
                newBar.barValue.rectTransform.anchoredPosition = Vector2.zero;
            }
            */
            bars.Add(newBar);
        }
    }
}

