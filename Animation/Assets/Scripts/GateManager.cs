using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GateManager : MonoBehaviour
{   
    public TextMeshPro GatePowerUp;
    public int randomNumber;
    public bool multiply;
    // Start is called before the first frame update
    void Start()
    {
        if(multiply)
        {
            randomNumber = Random.Range(1,3);
            GatePowerUp.text = "X" + randomNumber;
        }
        else 
        {
            randomNumber = Random.Range(8,32);
            if (randomNumber % 2 != 0)
                randomNumber += 1;
            
            GatePowerUp.text = randomNumber.ToString();
            
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
