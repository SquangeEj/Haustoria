using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_EnemySelect : MonoBehaviour
{
    [SerializeField] private GameObject[] Enemies;
    [SerializeField] private SCROBJ_CombatStartManager EnemyData;
    
    
    void Start()
    {
        foreach (GameObject enemy in Enemies)
        {

            enemy.SetActive(false);
            
        }

        Enemies[EnemyData.EnemyID].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
