using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Camera camera;
    private Vector3 offeet;

    public Transform defaultParent, defaultTempCardParent;
    public int countPlayer;

    private GameObject tempCardGO;
    
    private void Awake()
    {
        camera = Camera.main;
        tempCardGO = GameObject.Find("TempCardGO");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(countPlayer != 0)
            return;

        offeet = transform.position - camera.ScreenToWorldPoint(eventData.position);

        defaultParent = defaultTempCardParent = transform.parent;
        transform.SetParent(defaultParent.parent);
        
        tempCardGO.transform.SetParent(defaultParent);
        tempCardGO.transform.SetSiblingIndex(transform.GetSiblingIndex());
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(countPlayer != 0)
            return;

        Vector3 newPos = camera.ScreenToWorldPoint(eventData.position);
        transform.position = newPos + offeet; 
        
        if(tempCardGO.transform.parent != defaultTempCardParent)
            tempCardGO.transform.SetParent(defaultParent);
        
        CheckPosition();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(countPlayer != 0)
            return;

        transform.SetParent(defaultParent);
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        transform.SetSiblingIndex(tempCardGO.transform.GetSiblingIndex());
        tempCardGO.transform.SetParent(GameObject.Find("Canvas").transform);
        tempCardGO.transform.localPosition = new Vector3(2500, 0);
    }

    private void CheckPosition()
    {
        int newIndex = defaultTempCardParent.childCount;

        for (int i = 0; i < defaultTempCardParent.childCount; i++)
        {
            if (transform.position.x < defaultTempCardParent.GetChild(i).position.x)
            {
                newIndex = i;
                if (tempCardGO.transform.GetSiblingIndex() < newIndex) 
                    newIndex--;
                break;
            }
        }
        
        tempCardGO.transform.SetSiblingIndex(newIndex);
    }
}
