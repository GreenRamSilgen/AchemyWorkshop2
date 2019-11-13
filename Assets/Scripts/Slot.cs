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
    public bool filled = false;
    public CraftingController CraftingController;
    public void Start()
    {
        GetComponent<Image>().sprite = CraftingController.GetImage(-1);
    }
    //OnPointerDown is also required to receive OnPointerUp callbacks
    public void OnDrop(PointerEventData eventData)
    {
        
        AddMaterial(CraftingController.GetMaterial());
    }
    public void AddMaterial(int newID)
    {
        CraftingController.SlotMaterial(newID, materialID);
        
        materialID = newID;
        filled = true;
        gameObject.GetComponent<Image>().sprite = CraftingController.GetImage(materialID);
    }
    public void ResetSlot()
    {
        materialID = -1;
        gameObject.GetComponent<Image>().sprite = CraftingController.GetImage(-1);
        filled = false;
    }
}
