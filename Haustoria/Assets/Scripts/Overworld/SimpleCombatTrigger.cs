using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCombatTrigger : MonoBehaviour
{
    [SerializeField] private SCROBJ_CombatStartManager EnemyData;
    [SerializeField] private int EnemyId, SceneAfter, Scenetoload;
    [SerializeField] GameObject TransMan;
    private GameObject player;


    [SerializeField] private GameData Gamedata;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    [SerializeField] private SCROBJ_BRIAR_STATS BriarStats;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TransMan.GetComponent<SCR_SceneTransitionManager>().SetDestinationX((int)player.transform.localPosition.x);
            TransMan.GetComponent<SCR_SceneTransitionManager>().SetDestinationY((int)player.transform.localPosition.y);
            TransMan.GetComponent<SCR_SceneTransitionManager>().SetDestinationZ((int)player.transform.localPosition.z);

        
       





            GameObject combatman = GameObject.Find("SceneTransitionManager");


            EnemyData.EnemyID = EnemyId;
            EnemyData.Scenetogotoafter = SceneAfter;
            combatman.GetComponent<SCR_SceneTransitionManager>().SceneLoad = Scenetoload;
            combatman.GetComponent<SCR_SceneTransitionManager>().swapscene();

        }
    }

 
}
