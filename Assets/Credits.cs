using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public StageCycle StageCycle;
    public void BackToMenu()
    {
        StageCycle.FadeToStage(0);
    }
}
