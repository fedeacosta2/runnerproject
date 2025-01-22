using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyStickmans : MonoBehaviour
{
    private PlayerCtrl playerCtrl;

    private void Start()
    {
        playerCtrl = GetComponentInParent<PlayerCtrl>();
    }

    private void OnDestroy()
    {
        Debug.Log(playerCtrl.transform.childCount);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("red") && other.transform.parent.childCount > 0)
        {
            
            other.enabled = false;
            Destroy(other.gameObject);
            
            playerCtrl.DestroyStickmanInPlayerCtrl(gameObject);
            


        }
        
        
    }
    
 
}
