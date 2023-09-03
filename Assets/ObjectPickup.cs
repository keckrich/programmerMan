using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickaxePickup : MonoBehaviour
{
    public GameObject endText;
    public GameObject eventSystem;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && gameObject.name == "Pickaxe")
        {
            gameObject.SetActive(false);
        }
        else if (other.tag == "Player" && gameObject.name == "Exit")
        {
            // Trigger you won text 
            endText.SetActive(true);
        }
        else if (other.tag == "Player" && gameObject.name == "Star")
        {
            StarManager starManager = eventSystem.GetComponent<StarManager>();
            starManager.OnStarPickup();
            Destroy(gameObject);
        }

    }



}
