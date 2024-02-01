using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
   
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Bullet"))
        {
            //Debug.Log("Hello");
            // Destroy the bullet object
            Destroy(other.gameObject);
        }
    }
}
