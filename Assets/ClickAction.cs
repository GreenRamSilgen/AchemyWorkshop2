using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ClickAction : MonoBehaviour, IPointerClickHandler
{
    public int materialID = 0;
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
            CraftingController.SelectMaterial(materialID);

        }
        else
        {
            DeselectMaterial();
        }
    }
    public void DeselectMaterial()
    {
        selected = false;
        gameObject.transform.position = originalPosition;
    }

    public void Update()
    {
        if(selected){
            gameObject.transform.position = Input.mousePosition;
        }
    }
}
