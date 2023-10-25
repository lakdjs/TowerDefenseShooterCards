using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorOverUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public Vector2 moveDirection;
    public Vector2 moveDirection2;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Enter");
        transform.Translate(moveDirection, Space.World);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Exit");
        transform.Translate(moveDirection2, Space.World);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Card!");
    }

}
