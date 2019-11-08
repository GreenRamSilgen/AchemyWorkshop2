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
    // Start is called before the first frame update
/*    public void Start()
    {
        startPosition = gameObject.transform.position;
    }*/

    /*public void OnPointerDown(PointerEventData eventData)
    {
        startPosition = transform.position;
    }*/
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
    /*public void OnPointerDown(PointerEventData eventData)
    {
        if (!selected)
        {
            startPosition = gameObject.transform.position;
            selected = true;
            CraftingController.SelectMaterial(materialID);
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
    }*/
    /*public void OnPointerClick(PointerEventData eventData)
    {
        if (!selected)
        {
            startPosition = gameObject.transform.position;
            selected = true;
            CraftingController.SelectMaterial(materialID);
        }*//*
        else
        {
            DeselectMaterial();
        }*//*
    }*/
    /*public void DeselectMaterial()
    {
        selected = false;
        gameObject.transform.position = startPosition;
    }
*/
    public void Update()
    {
        /*if (selected)
        {
            gameObject.transform.position = Input.mousePosition;
        }*/
    }
}
