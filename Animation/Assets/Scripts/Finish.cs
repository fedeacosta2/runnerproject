using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("blue"))
        {
            Debug.Log("holaaaa");
            // Check if the colliding object has a parent
            if (other.transform.parent != null)
            {
                // Destroy the parent object
                Destroy(other.transform.parent.gameObject);
            }
            else
            {
                // If there's no parent, destroy the colliding object itself
                Destroy(other.gameObject);




            }
        }
    }
}
