using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCombatTrigger : MonoBehaviour
{
    [SerializeField] private SCROBJ_CombatStartManager EnemyData;
    [SerializeField] private int EnemyId;

    [SerializeField] private GameData Gamedata;
  

    [SerializeField] private SCROBJ_BRIAR_STATS BriarStats;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
     
          
            GameObject combatman = GameObject.Find("SceneTransitionManager");


            EnemyData.EnemyID = EnemyId;
            combatman.GetComponent<SCR_SceneTransitionManager>().SceneLoad = 1;
            combatman.GetComponent<SCR_SceneTransitionManager>().swapscene();

        }
    }

 
}
