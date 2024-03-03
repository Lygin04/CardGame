using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Camera camera;
    private Vector3 offeet;

    public Transform defaultParent;
    
    private void Awake()
    {
        camera = Camera.main;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        offeet = transform.position - camera.ScreenToWorldPoint(eventData.position);

        defaultParent = transform.parent;
        transform.SetParent(defaultParent.parent);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 newPos = camera.ScreenToWorldPoint(eventData.position);
        newPos.z = 0f;
        transform.position = newPos + offeet;

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(defaultParent);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
