using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;

    public LayerMask whatStopsMovement;
    // Start is called before the first frame update

    public int movePosX;
    public int movePosY;

    void Start()
    {
        // movePoint.parent = null; //makes it so the movepoint does not translate based on player object
    }

    public void moveUp()
    {
        movePosY = 1;
    }
    public void moveDown()
    {
        movePosY = -1;
    }
    public void moveRight()
    {
        movePosX = 1;
    }
    public void moveLeft()
    {
        movePosX = -1;
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.localPosition, movePoint.localPosition) <= .05f)
        {

            if (Mathf.Abs(movePosX) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.localPosition + new Vector3(movePosX, 0f, 0f), .2f, whatStopsMovement))
                {
                    movePoint.localPosition += new Vector3(movePosX, 0f, 0f);
                }

            }
            //Might have to add player offset depending on sprite
            else if (Mathf.Abs(movePosY) == 1f)
            {

                if (!Physics2D.OverlapCircle(movePoint.localPosition + new Vector3(0f, movePosY, 0f), .2f, whatStopsMovement))
                {
                    movePoint.localPosition += new Vector3(0f, movePosY, 0f);
                    Debug.Log($"Move Point = {movePoint.localPosition}");
                }
            }
        }

        movePosX = 0;
        movePosY = 0;

    }
}
