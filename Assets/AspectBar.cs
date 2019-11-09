using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspectBar : MonoBehaviour
{
    public const int ASPECT_MAX = 25;
    public string aspectName;
    public float value;
    public float startTime;
    public void Start()
    {
        value = 0.0f;
    }
    public void UpdateValue(int newValue)
    {
        value = value + newValue;
    }
    public void Update()
    {
        transform.localScale = new Vector2(0,1) * Mathf.Lerp(0, value/ASPECT_MAX*10, Time.deltaTime*50);
    }
}
