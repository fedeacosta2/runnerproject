using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

using TMPro;
using Unity.Mathematics;

public class PlayerCtrl : MonoBehaviour
{
    [Range(0,30)] public float speed;
    [Range(-30,30)] public float LeftandRightspeed;
    [SerializeField] Rigidbody m_rigidbody;
    public float horizontalInput;
    public Transform player;
    private int numberOfStickmans, numberOfEnemyStickmans;
    [SerializeField] private TextMeshPro CounterTxt;
    [SerializeField] private GameObject stickMan;
    [SerializeField] private Transform enemy;
    private bool attack;
    private List<GameObject> stickmansblue = new();

   [Range(0f,1f)] [SerializeField] private float DistanceFactor, Radius;
    // Start is called before the first frame update
    void Start()
    {   
        player = transform;
        MakeStickMan(1);
        numberOfStickmans = transform.childCount - 1;

        CounterTxt.text = numberOfStickmans.ToString();
        //MakeStickMan(10);
        m_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {   
        if (attack)
        {
            //attack = false;
                
            //FormatStickMan();

            
            //Invoke("DelayedAttack", 1f);
        }
        else
        {
            horizontalInput = Input.GetAxis("Horizontal");
            this.transform.Translate(speed * Time.deltaTime * Vector3.back);
            this.transform.Translate(LeftandRightspeed * Time.deltaTime * Vector3.right * horizontalInput);
            //Debug.Log(transform.childCount);
            
        }

    }

    /*private void DelayedAttack()
    {
        FormatStickMan();
        enemy.gameObject.SetActive(false);
    }*/
    public void FormatStickMan()
    {
        for (int i = 1; i < player.childCount; i++)
        {
            var x = DistanceFactor * Mathf.Sqrt(i) * Mathf.Cos(i * Radius);
            var z = DistanceFactor * Mathf.Sqrt(i) * Mathf.Sin(i * Radius);
            
            var NewPos = new Vector3(x,0f,z);

            //player.transform.GetChild(i).DOLocalMove(NewPos, 0.5f).SetEase(Ease.OutBack);
            player.transform.GetChild(i).localPosition = NewPos;
        }
    }

    public void DestroyStickmanInPlayerCtrl(GameObject stickman)
    {
        stickmansblue.Remove(stickman);
        Destroy(stickman);
        if (stickmansblue.Count == 0)
        {
            gameObject.SetActive(false);
        }
    }
    
    public void MakeStickMan(int number)
    {
        for (int i = numberOfStickmans; i < number; i++)
        {
            var stickman =Instantiate(stickMan, transform.position, Quaternion.Euler(0f, 180f, 0f), transform);
            stickmansblue.Add(stickman);
        }

        numberOfStickmans = transform.childCount - 1;
        CounterTxt.text = numberOfStickmans.ToString();
        FormatStickMan();
    }
     private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("gate"))
        {
            other.transform.parent.GetChild(0).GetComponent<BoxCollider>().enabled = false; // gate 1
            other.transform.parent.GetChild(1).GetComponent<BoxCollider>().enabled = false; // gate 2

            var gateManager = other.GetComponent<GateManager>();

            numberOfStickmans = transform.childCount - 1;

            if (gateManager.multiply)
            {
                MakeStickMan(numberOfStickmans * gateManager.randomNumber);
            }
            else
            {
                MakeStickMan(numberOfStickmans + gateManager.randomNumber);

            }
        }

        if (other.CompareTag("enemy"))
        {
            

            // Adding a delay of 1 second (you can change the delay duration as needed)
            StartCoroutine(UpdateTheNumberOfStickmans());
            //StartCoroutine(DeactivateEnemyAfterDelay(other.gameObject, 0.6f));
            
            
            
        }
    }
    private IEnumerator DeactivateEnemyAfterDelay(GameObject enemy, float delay)
    {
        yield return new WaitForSeconds(delay);

        // Deactivate the enemy after the specified delay
        enemy.SetActive(false);
    }

    public void DeleteCounter()
    {
        if (transform.childCount < 2)
        {
            Debug.Log("xddddd");
            // Set the parent game object to inactive
            transform.gameObject.SetActive(false);
                
        }
    }

    IEnumerator UpdateTheNumberOfStickmans()
    {
        while (transform.childCount > 0)
        {
            numberOfStickmans = transform.childCount - 1;

            CounterTxt.text = numberOfStickmans.ToString();

            yield return null;
        }
    }
}
