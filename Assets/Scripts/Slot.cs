using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Slot : MonoBehaviour
    , IDropHandler
/*, IPointerClickHandler*/

{
    public int id;
    public int materialID = -1;
    public CraftingController CraftingController;
    //OnPointerDown is also required to receive OnPointerUp callbacks
    public void OnDrop(PointerEventData eventData)
    {
        if (CraftingController.GetMaterial() > -1)
        {
            materialID = CraftingController.GetMaterial();
            gameObject.GetComponent<Image>().sprite = CraftingController.GetImage(materialID);
        }
    }
    public void ResetSlot()
    {
        materialID = -1;
        gameObject.GetComponent<Image>().sprite = null;
    }
    /*public void OnDrop(PointerEventData eventData)
    {
        RectTransform slotTransform = transform as RectTransform;
        if(RectTransformUtility.RectangleContainsScreenPoint(slotTransform, Input.mousePosition))
        {
            if (CraftingController.GetMaterial() > -1)
            {
                materialID = CraftingController.GetMaterial();
                gameObject.GetComponent<Image>().sprite = CraftingController.GetImage(materialID);
                *//*CraftingController.DeselectMaterial();*//*
            }
        }
    }*/
    /*public void OnPointerClick(PointerEventData eventData)
    {
        if (CraftingController.GetMaterial() > -1)
        {
            materialID = CraftingController.GetMaterial();
            gameObject.GetComponent<Image>().sprite = CraftingController.GetImage(materialID);
            CraftingController.DeselectMaterial();
        }
    }*/
}
