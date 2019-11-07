using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Slot : MonoBehaviour, IPointerClickHandler
/*    , IPointerEnterHandler, IPointerExitHandler
*/
{
    public bool filled = false;
    public int itemID = -1;
    /*public bool mouseOver = false;*/
    public CraftingController CraftingController;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (CraftingController.getItem() > -1)
        {
            Debug.Log("Working");
            filled = true;
            itemID = CraftingController.getItem();
            gameObject.GetComponent<Image>().sprite = CraftingController.GetImage(itemID);
            CraftingController.deselectItem();
        }
    }
    /*
    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseOver = false;
    }*/
}
