using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SimpleChasePlayer : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;
    [SerializeField] private SCROBJ_CombatStartManager EnemyData;
    [SerializeField] bool ischasing =false;
    [SerializeField] GameObject TransMan;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position,player.transform.position)< 50)
        {
            ischasing = true;
        }

        
        if (ischasing == true)
        {
            agent.SetDestination(player.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
         




        }
    }
}
