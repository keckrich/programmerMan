using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class NewPlayer : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody2D rb;
    public LayerMask obstacleLayer; // Layer for obstacles such as walls

    Vector2 movement;

    public Tilemap tilemap;

    // Flag to check if character is walking
    bool isWalking = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isWalking)
            return; // Do not take input if walking

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    public void WalkForward()
    {
        if (HasTileCollistion(0, 1)) return;
        StartCoroutine(WalkCoroutine(new Vector2(0, 1)));
    }

    public void WalkLeft()
    {
        if (HasTileCollistion(-1, 0)) return;

        StartCoroutine(WalkCoroutine(new Vector2(-1, 0)));
    }

    public void WalkRight()
    {
        if (HasTileCollistion(1, 0)) return;

        StartCoroutine(WalkCoroutine(new Vector2(1, 0)));
    }

    public void WalkDown()
    {
        if (HasTileCollistion(0, -1)) return;

        StartCoroutine(WalkCoroutine(new Vector2(0, -1)));
    }

    public bool HasTileCollistion(int x, int y)
    {
        Vector3 worldPoint = (transform.position);
        Debug.Log("world pos: " + worldPoint);

        Debug.Log("cell pos 1: " + tilemap.WorldToCell(worldPoint));
        // Convert the world point to cell position
        Vector3Int cellPosition = tilemap.WorldToCell(worldPoint) + new Vector3Int(x, y);
        Debug.Log("cell pos 2: " + cellPosition);
        // Check if the cell contains a tile
        return tilemap.HasTile(cellPosition);
    }

    IEnumerator WalkCoroutine(Vector2 direction)
    {
        isWalking = true;
        Vector2 initialLocalPosition = rb.transform.localPosition;
        Vector2 targetLocalPosition = initialLocalPosition + direction;

        // // Draw a debug ray in the Unity Editor
        // Debug.DrawRay(initialLocalPosition, direction, Color.red, 100.0f);

        // // Check for obstacles using raycast
        // RaycastHit2D hit = Physics2D.Raycast(initialLocalPosition, direction, 1, obstacleLayer);
        // if (hit.collider != null)
        // {
        //     Debug.Log("Hit: " + hit.collider.name);  // Log what was hit
        //                                              // There is an obstacle in the way, stop and exit coroutine
        //     isWalking = false;
        //     yield break;
        // }

        float journeyLength = Vector2.Distance(initialLocalPosition, targetLocalPosition);
        float startTime = Time.time;

        float distanceCovered = 0;

        while (distanceCovered < journeyLength)
        {
            distanceCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = distanceCovered / journeyLength;

            rb.transform.localPosition = Vector2.Lerp(initialLocalPosition, targetLocalPosition, fractionOfJourney);
            yield return null;
        }

        isWalking = false;
    }

    void FixedUpdate()
    {
        if (!isWalking) // Only move if not walking
        {
            Vector2 currentLocalPosition = rb.transform.localPosition;
            Vector2 newLocalPosition = currentLocalPosition + movement * speed * Time.fixedDeltaTime;
            rb.transform.localPosition = newLocalPosition;
        }
    }
}
