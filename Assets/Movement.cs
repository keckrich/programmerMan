using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;
    public Tilemap tilemap;


    public LayerMask whatStopsMovement;
    // Start is called before the first frame update

    public int movePosX;
    public int movePosY;

    void Start()
    {
        // movePoint.parent = null; //makes it so the movepoint does not translate based on player object
    }

    public void MoveUp()
    {
        movePosY = 1;
    }
    public void MoveDown()
    {
        movePosY = -1;
    }
    public void MoveRight()
    {
        movePosX = 1;
    }
    public void MoveLeft()
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
                if (!HasTileCollistion(movePosX, 0))
                {
                    movePoint.localPosition += new Vector3(movePosX, 0f, 0f);
                }

            }
            //Might have to add player offset depending on sprite
            else if (Mathf.Abs(movePosY) == 1f)
            {

                if (!HasTileCollistion(0, movePosY))
                {
                    movePoint.localPosition += new Vector3(0f, movePosY, 0f);
                    Debug.Log($"Move Point = {movePoint.localPosition}");
                }
            }
        }

        movePosX = 0;
        movePosY = 0;

    }

    public bool HasTileCollistion(int x, int y)
    {
        // Convert the world point to cell position
        Vector3Int cellPosition = tilemap.WorldToCell(transform.position) + new Vector3Int(x, y);
        // Check if the cell contains a tile
        return tilemap.HasTile(cellPosition);
    }
}
