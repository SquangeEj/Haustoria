using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SimpleChasePlayer : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;
    [SerializeField] bool ischasing =false;
    private Vector3 origin;
   
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        agent.updateRotation = false;
        origin = this.transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 30)
        {
            ischasing = true;
        }
        else
        {
            ischasing = false;
        }

        
        if (ischasing == true)
        {
            agent.SetDestination(player.transform.position);
        }
        if (ischasing == false)
        {
            agent.SetDestination(origin);
        }
    }

   
}
