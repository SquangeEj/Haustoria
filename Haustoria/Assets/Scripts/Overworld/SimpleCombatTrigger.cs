using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCombatTrigger : MonoBehaviour
{
    [SerializeField] private SCROBJ_CombatStartManager EnemyData;
    [SerializeField] private int EnemyId, SceneAfter, Scenetoload;
    [SerializeField] GameObject TransMan;
    [SerializeField]
    private GameObject player;


    [SerializeField] private SCROBJ_BRIAR_STATS BriarStats;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TransMan.GetComponent<SCR_SceneTransitionManager>().SetDestinationX((int)player.transform.localPosition.x);
            TransMan.GetComponent<SCR_SceneTransitionManager>().SetDestinationY((int)player.transform.localPosition.y);
            TransMan.GetComponent<SCR_SceneTransitionManager>().SetDestinationZ((int)player.transform.localPosition.z);

            Debug.Log(player.transform.position);
            GameObject combatman = GameObject.Find("SceneTransitionManager");




            TransMan.GetComponent<SCR_SceneTransitionManager>().ForceSavePosition();
            EnemyData.EnemyID = EnemyId;
            EnemyData.Scenetogotoafter = SceneAfter;
            combatman.GetComponent<SCR_SceneTransitionManager>().SceneLoad = Scenetoload;
            combatman.GetComponent<SCR_SceneTransitionManager>().swapscene();

        }
    }

 
}
