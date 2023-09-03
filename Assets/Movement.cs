using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;
    public LayerMask whatStopsMovement;
    public LayerMask CanRemove;
    public int movePosX;
    public int movePosY;

    void Start()
    {
        movePoint.parent = null; //makes it so the movepoint does not translate based on player object
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


    public void mineBlock()
    {

    }


    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        
        if(Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            
            if(Mathf.Abs(movePosX) == 1f)
            {
                if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(movePosX, 0f, 0f), .2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(movePosX, 0f, 0f);
                }
                
            }
            //Might have to add player offset depending on sprite
            else if(Mathf.Abs(movePosY) == 1f)
            {
                
                if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, movePosY, 0f), .2f, whatStopsMovement))
                {
                        movePoint.position += new Vector3(0f, movePosY, 0f);
                        Debug.Log($"Move Point = {movePoint.position}");
                }
            }
        }
        
        movePosX = 0;
        movePosY = 0;
        
        // if(Physics2D.OverlapCircle(transform.position, 2f, CanRemove))
        // {
        //     Debug.Log($"Move Point");
        // }




    }
}
