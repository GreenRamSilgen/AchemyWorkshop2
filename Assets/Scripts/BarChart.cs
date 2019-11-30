using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class BarChart : MonoBehaviour
{
    /*CUSTOMIZE BARS HERE*/
    private readonly int maxValue = 25;
    /*CUSTOMIZE BARS HERE*/


    //Material Pulling
    private MaterialList MaterialList = new MaterialList(); //Create ItemList object
    GameObject materialsGetter; //create gameobject
    private SortedDictionary<string, int> totalAspects = new SortedDictionary<string, int>();
    private SortedDictionary<string, int> topFiveAspects = new SortedDictionary<string, int>();
    private Dictionary<string, int> colorWheel = new Dictionary<string, int>();
    //Bar 
    public Bar barPreFab;
    public int[] inputValues;
    public string[] labels;
    public Color[] colors;
    public TextLog TextLog;
    List<Bar> bars = new List<Bar>();

    float chartHeight;
    void Start()
    {
        //Material Pulling
        materialsGetter = GameObject.FindGameObjectWithTag("Resourcer"); //Assign ResourceLoader gameobject to "resourceGetter"
        MaterialList = materialsGetter.GetComponent<MaterialLoader>().getMaterialList(); //Call getResourceList from ResourceLoader Script in ResourceHolder


        //Bar
        chartHeight = Screen.height - GetComponent<RectTransform>().sizeDelta.y;
        MakeBars(inputValues);
        colorWheelSetup();
    }

    void Update()
    {
        
    }

    public void updateBarGraph(int m1ID, int m2ID, int m3ID)
    {
        calculateAspects(m1ID, m2ID, m3ID);
        if (totalAspects.Count == 1 && totalAspects.ContainsKey("NA"))
        {
            blankGraph();
            TextLog.emptyResiduals();
        }
        else
        {
            updateTopFive();
            updateAllBars();
        }
    }

    void calculateAspects(int m1ID, int m2ID, int m3ID) //MIGHT GET ERROR FOR MULTIPLE NA ITEM???
    {
        resetAspects();

        //Material 1
        if (m1ID == -1)
        {
            if (!totalAspects.ContainsKey("NA"))
            {
                totalAspects.Add("NA", 0);
            }
            else
            {
                totalAspects["NA"] += 0;
            }
        }
        else
        {
            safeAdd(m1ID);
        }

        //Material 2
        if (m2ID == -1)
        {
            if (!totalAspects.ContainsKey("NA"))
            {
                totalAspects.Add("NA", 0);
            }
            else
            {
                totalAspects["NA"] += 0;
            }
        }
        else
        {
            safeAdd(m2ID);
        }

        //Material 3
        if (m3ID == -1)
        {
            if (!totalAspects.ContainsKey("NA"))
            {
                totalAspects.Add("NA", 0);
            }
            else
            {
                totalAspects["NA"] += 0;
            }
        }
        else
        {
            safeAdd(m3ID);
        }
    }

    void safeAdd(int m1ID)
    {
        if (!totalAspects.ContainsKey(MaterialList.Materials[m1ID].A1Name))
        {
            totalAspects.Add(MaterialList.Materials[m1ID].A1Name, MaterialList.Materials[m1ID].A1Amt);
        }
        else
        {
            totalAspects[MaterialList.Materials[m1ID].A1Name] += MaterialList.Materials[m1ID].A1Amt;
        }
        //ASPECT 2
        if (!totalAspects.ContainsKey(MaterialList.Materials[m1ID].A2Name))
        {
            totalAspects.Add(MaterialList.Materials[m1ID].A2Name, MaterialList.Materials[m1ID].A2Amt);
        }
        else
        {
            totalAspects[MaterialList.Materials[m1ID].A2Name] += MaterialList.Materials[m1ID].A2Amt;
        }
        //ASPECT 3
        if (!totalAspects.ContainsKey(MaterialList.Materials[m1ID].A3Name))
        {
            totalAspects.Add(MaterialList.Materials[m1ID].A3Name, MaterialList.Materials[m1ID].A3Amt);
        }
        else
        {
            totalAspects[MaterialList.Materials[m1ID].A3Name] += MaterialList.Materials[m1ID].A3Amt;
        }
    }

    void updateTopFive()
    {
        resetTopFiveAspects();
        int i = 0;
        while (i < 5 && totalAspects.Count != 0)
        {
            if (!topFiveAspects.ContainsKey(totalAspects.Aggregate((x, y) => x.Value > y.Value ? x : y).Key))
            {
                topFiveAspects.Add(totalAspects.Aggregate((x, y) => x.Value > y.Value ? x : y).Key, totalAspects.Values.Max());
                totalAspects.Remove(totalAspects.Aggregate((x, y) => x.Value > y.Value ? x : y).Key);
                i++;
            }
            else
            {
                totalAspects.Remove(totalAspects.Aggregate((x, y) => x.Value > y.Value ? x : y).Key);
            }
        }

        if(i == 5 && totalAspects.Count != 0)
        {
            TextLog.SetText(totalAspects);
        }
    }

    void updateAllBars()
    {
        IDictionaryEnumerator myEnumerator = topFiveAspects.GetEnumerator();
        int i = 0;
        while(myEnumerator.MoveNext())
        {
            //Change the bar height HERERERE
            RectTransform rt = bars[i].bar.GetComponent<RectTransform>();
            float normalizedValue = (float)System.Convert.ToInt32(myEnumerator.Value.ToString())/ (float)25;
            rt.sizeDelta = new Vector2(rt.sizeDelta.x, (chartHeight / 7) * normalizedValue);

            //Change the bar label HEREREE.
            bars[i].label.text = myEnumerator.Key.ToString();
            
            //Change the bar Value
            bars[i].barValue.text = myEnumerator.Value.ToString();
            //Change the bar Color
            Debug.Log(myEnumerator.Key.ToString());
            Debug.Log(colorWheel[myEnumerator.Key.ToString()]);
            bars[i].bar.color = colors[colorWheel[myEnumerator.Key.ToString()]];
            bars[i].label.color = colors[colorWheel[myEnumerator.Key.ToString()]];
            
            i++;
        }
    }

    public void blankGraph() //call this upon "CRAFT"
    {
        for(int i = 0; i < 5;i++)
        {
            RectTransform rt = bars[i].bar.GetComponent<RectTransform>();
            float normalizedValue = (float)0/ (float)25;
            rt.sizeDelta = new Vector2(rt.sizeDelta.x, (chartHeight / 7) * normalizedValue);

            //Change the bar label HEREREE.
            bars[i].label.text = "NA";
            //Change bar label color back to white.
            bars[i].label.color = colors[colorWheel["NA"]];
            //Change the bar Value
            bars[i].barValue.text = "0";
        }
    }

    void MakeBars(int[] values)
    {
        //int maxValue = 25;
        //values.Max();//Maybe change max value to 25 for consistent graph all the time

        for (int i = 0; i < values.Length; i++) //instantiate bar per input value
        {
            Bar newBar = Instantiate<Bar>(barPreFab, transform);
            newBar.transform.SetParent(transform);
            //Makes height change based on value
            RectTransform rt = newBar.bar.GetComponent<RectTransform>();

            //Normalize the input values based on max.
            float normalizedValue = (float)values[i] / (float)maxValue;

            //set Height of the Bar.
            rt.sizeDelta = new Vector2(rt.sizeDelta.x, (chartHeight/7) * normalizedValue);

            //set Color of this ONE BAR.
            //newBar.bar.color = colors[i % colors.Length];



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


    void resetAspects()
    {
        totalAspects.Clear();
    }
    void resetTopFiveAspects()
    {
        topFiveAspects.Clear();
    }

    void colorWheelSetup()
    {
        colorWheel.Add("Aqua", 0);
        colorWheel.Add("Arbor", 1);
        colorWheel.Add("Bestia", 2);
        colorWheel.Add("Examinus", 3);
        colorWheel.Add("Fames", 4);
        colorWheel.Add("Gelum", 5);
        colorWheel.Add("Herba", 6);
        colorWheel.Add("Ignis", 7);
        colorWheel.Add("Instramentum", 8);
        colorWheel.Add("Lucrum", 9);
        colorWheel.Add("Lux", 10);
        colorWheel.Add("Mortuus", 11);
        colorWheel.Add("Potentia", 12);
        colorWheel.Add("Praecantatio", 13);
        colorWheel.Add("Telum", 14);
        colorWheel.Add("Tenebrae", 15);
        colorWheel.Add("Terra", 16);
        colorWheel.Add("Tutamen", 17);
        colorWheel.Add("Venenum", 18);
        colorWheel.Add("Victus", 19);
        colorWheel.Add("Vinculum", 20);
        colorWheel.Add("Vitreus", 21);
        colorWheel.Add("Voltus", 22);
        colorWheel.Add("NA", 23);
        colorWheel.Add("na", 23);
    }
}

