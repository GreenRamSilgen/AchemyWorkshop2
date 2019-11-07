using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Slot : MonoBehaviour, IPointerClickHandler

{
    public int materialID = -1;
    public CraftingController CraftingController;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (CraftingController.GetMaterial() > -1)
        {
            Debug.Log("Working");
            materialID = CraftingController.GetMaterial();
            gameObject.GetComponent<Image>().sprite = CraftingController.GetImage(materialID);
            CraftingController.DeselectMaterial();
        }
    }
}
