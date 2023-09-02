using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public delegate void MyDelegate();
    public MyDelegate onExecute;

    [HideInInspector]
    public Transform parentAfterDrag;
    public Image image;
    public TMPro.TextMeshProUGUI text;
    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }

    void Start()
    {
    }


    // [ContextMenu("Set Text")]
    // public void SetText()
    // {
    //     SetText("test");
    // }
    public void SetText(String t)
    {
        text.text = t;
    }
}
