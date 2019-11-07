using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ClickAction : MonoBehaviour, IPointerClickHandler
{
    public int resourceID = 0;
    public Vector2 originalPosition;
    private bool selected = false;
    public CraftingController CraftingController;
    // Start is called before the first frame update
    public void Start()
    {
        originalPosition = gameObject.transform.position;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!selected)
        {
            originalPosition = gameObject.transform.position;
            selected = true;
            CraftingController.selectItem(resourceID);

        }
        else
        {
            deselectItem();
        }
    }
    public void deselectItem()
    {
        selected = false;
        gameObject.transform.position = originalPosition;
    }

    public void Update()
    {
        /*if (Input.GetMouseButtonUp(0))
        {
            mouseDown = false;
            gameObject.transform.position = originalPosition;
        }*/
        if(selected){
            gameObject.transform.position = Input.mousePosition;
        }
    }
}
