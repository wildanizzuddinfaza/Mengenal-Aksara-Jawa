﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.EventSystems;


public class DragManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [HideInInspector] public Transform parent;
    public void OnBeginDrag(PointerEventData eventData)
    {
        parent = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parent);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
