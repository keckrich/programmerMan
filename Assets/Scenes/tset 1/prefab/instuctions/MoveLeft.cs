using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoveLeft : Instruction
{


    public override void SetPartent(Transform t)
    {
        GameObject newMove = Instantiate(moveableItem, transform.position, transform.rotation, t);
        DraggableItem draggableItem = newMove.GetComponent<DraggableItem>();
        draggableItem.text.text = "Move Lef";
        draggableItem.onExecute = movement.moveLeft;
    }
}