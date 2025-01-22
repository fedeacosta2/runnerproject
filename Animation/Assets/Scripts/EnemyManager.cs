using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using Unity.Mathematics;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    public TextMeshPro CounterTxt;
    [SerializeField] private GameObject stickMan;
    
    public Transform enemy;
    public bool attack;

    [SerializeField] private GameObject EnemyZone;
    [Range(0f,1f)] [SerializeField] private float DistanceFactor, Radius;
    void Start()
    {
        for (int i = 0; i < Random.Range(10,50); i++)
        {
            Instantiate(stickMan, transform.position, Quaternion.Euler(0f, 0f, 0f), transform);
        }
        
        CounterTxt.text = (transform.childCount - 1).ToString();
        
        //FormatStickMan();
    }

    public void FormatStickMan()
    {
        for (int i = 1; i < transform.childCount; i++)
        {
            var x = DistanceFactor * Mathf.Sqrt(i) * Mathf.Cos(i * Radius);
            var z = DistanceFactor * Mathf.Sqrt(i) * Mathf.Sin(i * Radius);
            
            var NewPos = new Vector3(x,0f,z);

            
            transform.GetChild(i).localPosition = NewPos;
        }
    }
    void Update()
    {
        FormatStickMan();
    }
    
    /*public void AttackThem(Transform enemyForce)
    {
        enemy = enemyForce;
        attack = true;
    }*/
    private void OnTriggerEnter(Collider other)
    {
        
       

        if (other.CompareTag("blue"))
        {
            

            // Adding a delay of 1 second (you can change the delay duration as needed)
            
            StartCoroutine(DeactivateEnemyAfterDelay(gameObject, 0.6f));
            
            
            
        }
    }
    private IEnumerator DeactivateEnemyAfterDelay(GameObject enemy, float delay)
    {
        yield return new WaitForSeconds(delay);

        // Deactivate the enemy after the specified delay
        EnemyZone.gameObject.SetActive(false);
    }
    
    
}
