using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ClickAction : MonoBehaviour
    /*, IPointerDownHandler*/
    , IBeginDragHandler
    , IDragHandler
    , IEndDragHandler
    /*, IPointerClickHandler*/
    /*, IPointerDownHandler
    , IPointerUpHandler*/
{
    public int materialID = -1;
    public Vector2 startPosition;
    public CraftingController CraftingController;
    void Update()
    {
        if (materialID > -1)
        {
            gameObject.GetComponent<Image>().sprite = CraftingController.GetImage(materialID);
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = CraftingController.GetImage(-1);
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = gameObject.transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        CraftingController.SelectMaterial(materialID);
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        gameObject.transform.position = startPosition;
        CraftingController.DeselectMaterial();
    }
}
