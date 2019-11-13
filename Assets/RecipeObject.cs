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
    public void Initialize(int recipeID, int resultID, List<int> ids)
    {
        recipeID = recipeID;
        resultID = resultID;
        materialIDs = ids;
        material1.GetComponent<Image>().sprite = CraftingController.GetImage(materialIDs[0]);
        material2.GetComponent<Image>().sprite = CraftingController.GetImage(materialIDs[1]);
        material3.GetComponent<Image>().sprite = CraftingController.GetImage(materialIDs[2]);
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        animator.SetTrigger("RecipeInfo");
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        animator.SetTrigger("RecipeInfo");
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        CraftingController.AddMaterials(materialIDs);
    }
}
