using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class RecipeObject : MonoBehaviour
    , IPointerClickHandler
    , IPointerEnterHandler
    , IPointerExitHandler
{
    public int recipeID;
    public int resultID;
    public List<int> materialIDs = new List<int>();
    public Animator animator;
    public CraftingController CraftingController;
    public GameObject material1;
    public GameObject material2;
    public GameObject material3;
    /*public GameObject recipeName;*/
    public GameObject recipeValue;
    public void Initialize(RecipeInfo recipe)
    {
        recipeID = recipe.recipeID;
        resultID = recipe.resultID;
        materialIDs = recipe.materialIDs;
        material1.GetComponent<Image>().sprite = CraftingController.GetImage(materialIDs[0]);
        material2.GetComponent<Image>().sprite = CraftingController.GetImage(materialIDs[1]);
        material3.GetComponent<Image>().sprite = CraftingController.GetImage(materialIDs[2]);
        /*recipeName.GetComponent<Text>().text = recipe.recipeName;*/
        recipeValue.GetComponent<Text>().text = recipe.recipeValue.ToString();
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        animator.SetTrigger("RecipeInfo");
        FindObjectOfType<AudioManager>().Play(Global.rand.Next(7, 15));

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        animator.SetTrigger("RecipeInfo");
        FindObjectOfType<AudioManager>().Play(Global.rand.Next(7, 15));

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        CraftingController.SlotMaterials(materialIDs);
        FindObjectOfType<AudioManager>().Play(Global.rand.Next(15, 17));

    }
}
