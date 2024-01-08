using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractableObject : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    public virtual void OnPointerClick(PointerEventData eventData)
    {
        //Empty
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        //Empty
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        //Empty
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        //Empty
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        //Empty
    }
}
