using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class Instruction : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    public GameObject moveableItem;
    [HideInInspector]
    public Transform parentAfterDrag;
    protected Movement movement;
    public virtual void SetPartent(Transform t)
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Instantiate(gameObject, transform.position, transform.rotation, transform.parent);

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
        Destroy(gameObject);
    }

    void Start()
    {
        movement = GameObject.FindGameObjectWithTag("player").GetComponent<Movement>();
    }
}
