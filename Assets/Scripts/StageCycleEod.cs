using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StageCycleEod : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    private int levelToLoad;
    // Update is called once per frame
    void Update()
    {
        
    }
    public void FadeToStage (int levelIndex)
        //switches to whichever scene index is defined in the button trigger
    {
        if (Global.gold < 0)
        {
            levelToLoad = 6;
        }
        else
        {
            levelToLoad = levelIndex;
        }

        animator.SetTrigger("FadeOut");
    }
    public void OnFadeComplete()
        //called at the end of the animation
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void QuitGame()
    {
        Debug.Log("Bid you farewell!");
        Application.Quit();
    }
}
