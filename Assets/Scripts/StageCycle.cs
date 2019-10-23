using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StageCycle : MonoBehaviour
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
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }
    public void OnFadeComplete()
        //called at the end of the animation
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
