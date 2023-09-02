using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    // Update is called once per frame

    void Update()//inputs
    {
        movement.x =Input.GetAxisRaw("Horizontal"); //-1 left, 1 right
        movement.y = Input.GetAxisRaw("Vertical");

    }

    void FixedUpdate()//Movements
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); // arrow key movement
        
        

    }


}
