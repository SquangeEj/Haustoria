using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SimpleChasePlayer : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;
    [SerializeField] private SCROBJ_CombatStartManager EnemyData;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

           GameObject combatman =  GameObject.Find("SceneTransitionManager");


            EnemyData.EnemyID = 1;
            combatman.GetComponent<SCR_SceneTransitionManager>().SceneLoad = 1;
            combatman.GetComponent<SCR_SceneTransitionManager>().swapscene();



        }
    }
}
