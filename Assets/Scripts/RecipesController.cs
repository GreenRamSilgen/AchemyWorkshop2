using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipesController : MonoBehaviour
{
    public Animator animator;
    public void SetRecipesMenuTrigger()
    {
        animator.SetTrigger("RecipesMenu");
    }
}
