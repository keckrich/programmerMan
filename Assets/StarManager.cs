using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour
{
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    private int numberOfStarsCollected;
    // Start is called before the first frame update
    void Start()
    {
        numberOfStarsCollected = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnStarPickup()
    {
        numberOfStarsCollected++;
        switch (numberOfStarsCollected)
        {
            case 1:
                star1.SetActive(true);
                break;
            case 2:
                star2.SetActive(true);
                break;
            case 3:
                star3.SetActive(true);
                break;
            default:
                break;
        }
    }
}
