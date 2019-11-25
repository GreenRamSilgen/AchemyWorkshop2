using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLog : MonoBehaviour
{
    public Residual viewPortPrefab;
    public int[] inputValues;

    List<Residual> residuals = new List<Residual>();
    // Start is called before the first frame update
    void Start()
    {
        MakeResiduals(inputValues);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            //SetText();
        }
    }
    public void SetText(SortedDictionary<string, int> totalAspects)
    {
        IDictionaryEnumerator myEnumerator = totalAspects.GetEnumerator();
        int i = 0;
        while (myEnumerator.MoveNext())
        {
            string txt = myEnumerator.Key + " : " + myEnumerator.Value;
            residuals[i].residual.text = txt;
            i++;
        }

        if(i != 4)
        {
            while(i < 4)
            {
                residuals[i].residual.text = "NA : 0";
                i++;
            }
        }
    }
    void MakeResiduals(int[] values)
    {
        for (int i = 0; i < values.Length; i++) //instantiate bar per input value
        {
            Residual newResidual = Instantiate<Residual>(viewPortPrefab, transform);
            newResidual.transform.SetParent(transform);
            //Makes height change based on value
            RectTransform rt = newResidual.content.GetComponent<RectTransform>();

            //set Color of this ONE BAR.
            //newBar.bar.color = colors[i % colors.Length];
            newResidual.residual.text = "NA : 0";
            residuals.Add(newResidual);
        }
    }
}
