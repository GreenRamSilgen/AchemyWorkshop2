using UnityEngine;

public class Rotation: MonoBehaviour
{
    private RectTransform rectComponent;
    private float rotateSpeed = 100f;
    public int style;

    private void Start()
    {
        rectComponent = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (style == 1)
        {
            rectComponent.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
        }
        else if (style == 2)
        {
            rectComponent.Rotate(0f, 0f, -rotateSpeed * Time.deltaTime);
        }
    }
}