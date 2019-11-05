using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ClickAction : MonoBehaviour, IPointerClickHandler
{
    public int resourceID = 0;
    public Vector2 originalPosition;
    private bool mouseDown = false;
    public CraftingController CraftingController;
    // Start is called before the first frame update
    public void Start()
    {
        originalPosition = gameObject.transform.position;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        originalPosition = gameObject.transform.position;
        mouseDown = true;
        CraftingController.itemClicked = resourceID;
    }

    public void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            mouseDown = false;
            gameObject.transform.position = originalPosition;
        }
        if(mouseDown){
            Debug.Log("HERE");
            gameObject.transform.position = Input.mousePosition;
        }
    }
}
