using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipesController : MonoBehaviour
{
    public Animator animator;
    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetRecipesMenuTrigger()
    {
        animator.SetTrigger("RecipesMenu");
    }
}
