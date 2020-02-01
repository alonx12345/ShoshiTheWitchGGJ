using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    [SerializeField] private Canvas canvas = null;
    private RectTransform rectTransform;
    

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }


    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        print("a");
    }


    public void OnDrag(PointerEventData evetData)
    {
        rectTransform.anchoredPosition += evetData.delta / canvas.scaleFactor;
    }
}
