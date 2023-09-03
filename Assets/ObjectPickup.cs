using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickaxePickup : MonoBehaviour
{   
    public GameObject activeGameObject;
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){
            gameObject.SetActive(false);
        }
        
    }

    

}
