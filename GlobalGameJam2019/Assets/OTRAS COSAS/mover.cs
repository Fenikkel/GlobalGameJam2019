using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class mover : MonoBehaviour
{
    public static GameObject itemDraged;
    Vector3 startPosition;

    public void OnBeginDrag (PointerEventData eventData)
    {
        itemDraged = gameObject;
        startPosition = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        itemDraged = null;
        transform.position = startPosition;
    }
}
