using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ClickAction : MonoBehaviour
    /*, IPointerDownHandler*/
    , IBeginDragHandler
    , IDragHandler
    , IEndDragHandler
    /*, IPointerClickHandler*/
    /*, IPointerDownHandler
    , IPointerUpHandler*/
{
    public int materialID = 0;
    public Vector2 startPosition;
    public CraftingController CraftingController;
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
